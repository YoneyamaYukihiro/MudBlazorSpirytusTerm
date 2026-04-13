'ﾌｧｲﾙ名：xxEN00Q0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット投入(組立)　メインフォーム
'作成日：2004/07/26 (Mon) 17:07:34 S.Deguchi
'更新日：2016/02/09 (Tue) 00:04:51 H.Hayashi
'備　考：
'　　　：2004/10/06 (Wed) 09:48:19 S.Deguchi    在庫ﾛｯﾄ取得ﾒｯｾｰｼﾞ変更によるﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝのｱｯﾌﾟ
'　　　：(Tag追加だがこのPGでは関係ない為機能ﾊﾞｰｼﾞｮﾝそのまま)
'　　　：2004/11/24 (Wed) 16:15:20 S.Deguchi    技術担当者欄を追加
'　　　：2004/12/01 (Wed) 17:43:41 S.Deguchi    ｶﾚﾝﾄ行保持機能を追加
'　　　：2005/05/16 (Mon) 09:18:17 S.Deguchi    ATLAS連携対応で画面修正
'　　　：                                       ｺﾒﾝﾄ表示子画面を共通画面と変更(xxEN00Q1.frm ⇒ xxCM00V0.frm)
'　　　：2006/11/06 (Mon) 15:09:32 T.Kitagawa   量産(ODF対向基板)投入対応(案件№01544)
'　　　：2008/07/07 (Mon) 12:00:00 S.Ochiai     欠損ﾁｯﾌﾟ表示対応(No.03046)及びSource整備
'　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
'　　　：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
'      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00Q0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00Q0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00Q0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00Q0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00Q0)
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
    '@↓2013/11/27 (Wed) 19:41:25 T.Oide **************************************************
    'Private Const CMstrLocalVersion                 As String = "11.00"
    Private Const CMstrLocalVersion                 As String = "13.00"
    '@↑2013/11/27 (Wed) 19:41:25 T.Oide **************************************************


    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN00Q0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_flowlistVer              As String = "04.00"                 '種別区分一覧取得
    Private Const CMstrmas_pdlist__Ver              As String = "03.00"                 '機種区分一覧取得
    Private Const CMstrmas_pdentrylistVer           As String = "03.00"                 'ﾏｽﾀ工順取得
    Private Const CMstrlot_sppdentrylistVer         As String = "01.00"                 '特殊工順取得(未実装)
    Private Const CMstrmas_priolistVer              As String = "01.00"                 '優先度情報取得
    '@↓2016/01/30 (Sat) 11:47:17 H.Hayashi **************************************************
    'Private Const CMstrinv_acptlotlistVer           As String = "04.01"                 '在庫ﾛｯﾄﾘｽﾄ
    Private Const CMstrinv_acptlotlistVer           As String = "05.00"                 '在庫ﾛｯﾄﾘｽﾄ
    '@↑2016/01/30 (Sat) 11:47:17 H.Hayashi **************************************************
    Private Const CMstrlot_asmthrowinVer            As String = "06.02"                 '投入確定処理
    Private Const CMstrmas_emplist_Ver              As String = "02.00"                 '作業者ﾘｽﾄ取得
    '@↓2013/11/28 (Thu) 13:07:56 T.Oide **************************************************
    '@Private Const CMstratlsorderlistVer             As String = "02.01"                 'ｵｰﾀﾞｰﾘｽﾄ取得
    '@↑2013/11/28 (Thu) 13:07:56 T.Oide **************************************************

    '@vsfLotListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfColNo                     As Integer = 0                      '№
    Private Const CMlngvsfColCarrierID              As Integer = 1                      'ｷｬﾘｱID
    Private Const CMlngvsfColLotID                  As Integer = 2                      'ﾛｯﾄID
    Private Const CMlngvsfColFlowClass              As Integer = 3                      '種別
    Private Const CMlngvsfColWFNum                  As Integer = 4                      'WF枚数
    Private Const CMlngvsfColChipNum                As Integer = 5                      'ﾁｯﾌﾟ枚数
    Private Const CMlngvsfColComments               As Integer = 6                      'ｺﾒﾝﾄ内容(非表示)
    Private Const CMlngvsfColCommentDisp            As Integer = 7                      'ｺﾒﾝﾄ有無
    Private Const CMlngvsfColEngEmpID               As Integer = 8                      'ﾛｯﾄ担当者ID(非表示)
    Private Const CMlngvsfColEngEmpName             As Integer = 9                      'ﾛｯﾄ担当者名(非表示)
    Private Const CMlngvsfColSendSBID               As Integer = 10                     '送品先ID(非表示)
    Private Const CMlngvsfColSendSBName             As Integer = 11                     '送品先名
    Private Const CMlngvsfColLostChipInfo           As Integer = 12                     '欠損ﾁｯﾌﾟ情報

    '@vsfLotListの定数宣言(幅)
    Private Const CMlngvsfWColNo                    As Integer = 30                     '№
    Private Const CMlngvsfWcolCarrierID             As Integer = 65                     'ｷｬﾘｱID
    Private Const CMlngvsfWColLotID                 As Integer = 106                    'ﾛｯﾄID
    Private Const CMlngvsfWcolFlowClass             As Integer = 30                     '種別
    Private Const CMlngvsfWcolWFNum                 As Integer = 27                     'WF枚数
    Private Const CMlngvsfWcolChipNum               As Integer = 60                     'ﾁｯﾌﾟ枚数
    Private Const CMlngvsfWColComments              As Integer = 0                      'ｺﾒﾝﾄ内容(非表示)
    Private Const CMlngvsfWColCommentDisp           As Integer = 43                     'ｺﾒﾝﾄ有無
    Private Const CMlngvsfWColEngEmpID              As Integer = 0                      'ﾛｯﾄ担当者ID(非表示)
    Private Const CMlngvsfWColEngEmpName            As Integer = 0                      'ﾛｯﾄ担当者名(非表示)
    Private Const CMlngvsfWColSendSBID              As Integer = 0                      '送品先ID(非表示)
    Private Const CMlngvsfWColSendSBName            As Integer = 30                     '送品先名
    Private Const CMlngvsfWColLostChipInfo          As Integer = 27                     '欠損ﾁｯﾌﾟ情報

    '@vsfLotListの定数宣言(ｶﾗﾑ)
    Private Const CMstrvsfTColNo                    As String = "№"                    '№
    Private Const CMstrvsfTColCarrierID             As String = "ｷｬﾘｱID"                'ｷｬﾘｱID
    Private Const CMstrvsfTColLotID                 As String = "ﾛｯﾄID"                 'ﾛｯﾄID
    Private Const CMstrvsfTColFlowClass             As String = "種"                    '種別
    Private Const CMstrvsfTColWFNum                 As String = "WF"                    'WF枚数
    Private Const CMstrvsfTColChipNum               As String = "ﾁｯﾌﾟ"                  'CHIP枚数
    Private Const CMstrvsfTColComments              As String = "ｺﾒﾝﾄ内容"              'ｺﾒﾝﾄ内容(非表示)
    Private Const CMstrvsfTColCommentDisp           As String = "ｺﾒﾝﾄ"                  'ｺﾒﾝﾄ有無
    Private Const CMstrvsfTColEngEmpID              As String = "ﾛｯﾄ担当者ID"           'ﾛｯﾄ担当者ID(非表示)
    Private Const CMstrvsfTColEngEmpName            As String = "ﾛｯﾄ担当"               'ﾛｯﾄ担当者名(非表示)
    Private Const CMstrvsfTColSendSBID              As String = "送品先ID"              '送品先ID（非表示)
    Private Const CMstrvsfTColSendSBName            As String = "送"                    '送品先名
    Private Const CMstrvsfTColLostChipInfo          As String = "欠"                    '欠損ﾁｯﾌﾟ情報

    '@↓2013/11/27 (Wed) 19:47:37 T.Oide **************************************************
    '@'@vsfOrderListの定数宣言(ｶﾗﾑ)
    '@Private Const CMlngvsfOrderColNo                As Long = 0                         '№
    '@Private Const CMlngvsfOrderColThrowInDate       As Long = 1                         '投入予定日
    '@Private Const CMlngvsfOrderColPDID              As Long = 2                         '機種
    '@Private Const CMlngvsfOrderColLRFlag            As Long = 3                         'L/R
    '@Private Const CMlngvsfOrderColSendSBName        As Long = 4                         '送品先名(和名)
    '@Private Const CMlngvsfOrderColSendSBID          As Long = 5                         '送品先ID
    '@Private Const CMlngvsfOrderColOrderNo           As Long = 6                         'ｵｰﾀﾞｰ№
    '@Private Const CMlngvsfOrderColParentPDID        As Long = 7                         '親機種
    '@
    '@'@vsfOrderListの定数宣言(幅)
    '@Private Const CMlngvsfOrderWColNo               As Long = 450                       '№
    '@Private Const CMlngvsfOrderWColThrowInDate      As Long = 1750                      '投入予定日
    '@Private Const CMlngvsfOrderWColPDID             As Long = 1200                      '機種
    '@Private Const CMlngvsfOrderWColLRFlag           As Long = 950                       'L/R
    '@Private Const CMlngvsfOrderWColSendSBName       As Long = 465                       '送品先名(和名)
    '@Private Const CMlngvsfOrderWColSendSBID         As Long = 0                         '送品先ID
    '@Private Const CMlngvsfOrderWColOrderNo          As Long = 2000                      'ｵｰﾀﾞｰ№
    '@Private Const CMlngvsfOrderWColParentPDID       As Long = 950                       '親機種
    '@
    '@'@vsfOrderListの定数宣言(ｶﾗﾑ)
    '@Private Const CMstrvsfOrderTColNo               As String = "№"
    '@Private Const CMstrvsfOrderTColThrowInDate      As String = "投入予定日"
    '@Private Const CMstrvsfOrderTColPDID             As String = "機種"
    '@Private Const CMstrvsfOrderTColLRFlag           As String = "L/R"
    '@Private Const CMstrvsfOrderTColSendSBName       As String = "送"
    '@Private Const CMstrvsfOrderTColSendSBID         As String = "送品先ID"
    '@Private Const CMstrvsfOrderTColOrderNo          As String = "オーダー"
    '@Private Const CMstrvsfOrderTColParentPDID       As String = "親機種"
    '@↑2013/11/27 (Wed) 19:47:37 T.Oide **************************************************

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                  As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                  As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                 As Integer = 12                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfFontSize                  As Integer = 14                     'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                   As Integer = 21                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                    As Integer = 40                     '1ｽﾛｯﾄの高さ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                  As Integer = 14                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 14                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                  As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbDispCol2                  As Integer = 2                      'ｸﾞﾘｯﾄﾞ表示列数=2
    Private Const CMlngCmbGroupCols                 As Integer = 1                      '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCMbSelectMode                As Integer = 0                      '選択ﾓｰﾄﾞ(単選択ﾓｰﾄﾞ=0)
    Private Const CMlngCmbRowHeight                 As Integer = 43                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                  As Integer = 0                      '選択列数
    Private Const CMlngCmbValueCol1                 As Integer = 1                      '値取得列=1
    Private Const CMlngCmbGetCol0                   As Integer = 0                      'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=0
    Private Const CMlngCmbGetCol1                   As Integer = 1                      'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=1
    Private Const CMlngCmbGetCol5                   As Integer = 5                      'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=5(ﾊﾞｯｸｶﾗｰ)

    '@優先順位ｺﾝﾎﾞﾎﾞｯｸｽ初期値
    Private Const CMstrcmbPrioSel                   As Integer = 1                       'ﾘｽﾄｲﾝﾃﾞｯｸｽ(2:普通)

    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの定数宣言
    Private Const CMlngOptIndexThrow                As Integer = 0                         '機種ｴﾝﾄﾘ宣言(=0)
    Private Const CMlngOptIndexUser                 As Integer = 1                         'ﾕｰｻﾞｰﾌﾟﾛｾｽ宣言(=1)

    '@ﾌｫｰﾑの起動区分の定数宣言
    Private Const CMlng00Q0PDProc                   As Integer = 0                         'ﾌｫｰﾑの起動区分(=0)
    Private Const CMlng00Q0PDALLProc                As Integer = 1                         'ﾌｫｰﾑの起動区分(=1)
    Private Const CMlng00Q0UserProc                 As Integer = 2                         'ﾌｫｰﾑの起動区分(=2)

    '@ｴﾝﾄﾘﾌﾗｸﾞの定数宣言
    Private Const CMlngEntryFlag0                   As Integer = 0                         '機種ｴﾝﾄﾘ選択(=0)
    Private Const CMlngEntryFlag1                   As Integer = 1                         'ﾕｰｻﾞｰﾌﾟﾛｾｽ選択(=1)

    '@TabIndexの定数宣言
    Private Const CMlngPRTab0                       As Integer = 0                         '量産(TFT)TabIndex
    Private Const CMlngODFTab1                      As Integer = 1                         '量産(ODF)TabIndex
    Private Const CMlngZZTab2                       As Integer = 2                         '試作/実験TabIndex

    Private Const CMlngMaxDispRow                   As Integer = 3                         'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@ﾌｫｰﾑ起動時に取得する情報を格納する構造体
    Private mtypProductList                         As List(Of ProductList)             '投入機種格納変数
    Private mlngProductListCnt                      As Integer                          '投入機種格納数
    Private mtypOdfProductList                      As List(Of ProductList)             'ODF投入機種格納変数
    Private mlngOdfProductListCnt                   As Integer                          'ODF投入機種格納数
    Private mtypTftProductList                      As List(Of ProductList)             'TFT投入機種格納変数
    Private mlngTftProductListCnt                   As Integer                          'TFT投入機種格納数

    Private mtypDivisionList                        As List(Of DivisionList)            '投入種別格納変数
    Private mlngDivisionListCnt                     As Integer                          '投入種別格納数
    Private mtypPriorityReasonList                  As List(Of typPriorityReasonList)   '優先度格納構造体
    Private mlngPriorityReasonListCnt               As Integer                          '優先度格納数
    Private mtypSpPDEntryList                       As MasSppdentryList                 '特殊工順格納構造体
    Private mtypLotManagerList                      As List(Of TechManList)             'ﾛｯﾄ担当一覧格納用
    Private mlngLotManagerListCnt                   As Integer                          'ﾛｯﾄ担当一覧格納数
    Private mtypChgSort                             As ChgSort                          'Sort保持用(在庫ﾘｽﾄ)
    Private mtypChgSortOrder                        As ChgSort                          'Sort保持用(ｵｰﾀﾞｰﾘｽﾄ)
    Private mblnFormLoadFlag                        As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞ(ﾓｼﾞｭｰﾙ)ﾌﾗｸﾞ
    Private mtypAtlsOrderList                       As AtlsOrderList                    'ｵｰﾀﾞｰﾘｽﾄ

    Private mlngJudgeFlag                           As Integer                          'Tab別制御ﾌﾗｸﾞ(0:ﾃﾞﾌｫﾙﾄ、1:量産/ES(TFT)、2:量産/ES(ODF)、3:試作/実験)

    '@退避領域
    Private mstrPDID                                As String                           '退避領域(投入機種)
    Private mstrOdfPDID                             As String                           '退避領域(量産ODF投入機種)
    Private mstrTftPDID                             As String                           '退避領域(TFT基板投入機種)
    Private mstrLotManagerID                        As String                           '退避領域(ﾛｯﾄ担当者ID)
    Private mstrTFTFlowClass                        As String                           '退避領域(TFT流動区分)
    Private mstrODFFlowClass                        As String                           '退避領域(ODF流動区分)

    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                          'NSYS WindowCloseフラグ
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
        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfLotList, cmdUp, cmdDown)

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
    '作成日：2004/07/26 (Mon) 15:17:50 S.Deguchi
    '更新日：2013/11/28 (Thu) 15:59:40 T.Oide
    '備　考：
    '　　　：2004/10/04 (Mon) 13:30:31 H.Wajima     暗黙でFormがLoadされたときの処理が残っていたので削除
    '　　　：2004/11/24 (Wed) 13:42:43 S.Deguchi    技術担当者の情報取得処理を追加
    '　　　：2004/12/01 (Wed) 17:45:00 S.Deguchi    ｶﾚﾝﾄ行保持機能を追加(初期化処理)
    '　　　：2005/05/16 (Mon) 11:16:54 S.Deguchi    ATLAS連携処理追加でｵｰﾀﾞｰﾘｽﾄのｿｰﾄ保持初期化処理追加
    '　　　：2006/11/06 (Mon) 11:35:04 T.Kitagawa   量産(ODF対向基板)対応(案件№01544)
    '　　　：2008/01/22 (Tue) 15:36:20 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2008/06/11 (Wed) 13:03:17 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/23 (Mon) 14:14:23 N.Kojima     ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連処理削除、ﾁｯﾌﾟ電特区分(限定工程設定)関連処理追加。(案件№3402)
    '　　　：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrClassDivision   As String               'ClassDivision設定
        
        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00Q0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(Me, New FormClosingEventArgs(CloseReason.UserClosing,  False))
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@L/R表示
            lblTitleL.BackColor = ColorTranslator.FromWin32(CPlngLColor)   '機種L
            lblTitleR.BackColor = ColorTranslator.FromWin32(CPlngRColor)   '機種R
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@ｿｰﾄ保持構造体初期化
            With mtypChgSort
                .lngCnt = 0
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)()
                End If
                
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@ｿｰﾄ保持構造体初期化
            With mtypChgSortOrder
                .lngCnt = 0
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)()
                End If
                
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@Tab別制御ﾌﾗｸﾞの初期化
            mlngJudgeFlag = 0
            
        '@↓2009/02/23 (Mon) 14:14:06 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。

        '    '@ﾁｯﾌﾟ電特工程有無判定ﾌﾗｸﾞの初期化
        '    pblnCdenProcJudgeFlag = False

        '@↑2009/02/23 (Mon) 14:14:06 N.Kojima **************************************************
            
            '@画面情報の初期化
            Call prvfrmxxEN00Q0_Init(True)
            
            '@投入機種区分一覧取得
            lstrClassDivision = CPstrCD2A & CPstrCD30                           '処理区分(=2A30)
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          lstrClassDivision, _
                                          mtypProductList, _
                                          mlngProductListCnt, _
                                          pstrSBID)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If
            
            '@量産(ODF対向基板)の投入機種区分一覧取得
            lstrClassDivision = CPstrCD2A & CPstrCD4B                           '処理区分(=2A4B)
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          lstrClassDivision, _
                                          mtypOdfProductList, _
                                          mlngOdfProductListCnt, _
                                          pstrSBID)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If
            
            '@量産(TFT基板)の投入機種区分一覧取得
            lstrClassDivision = CPstrCD2A & CPstrCD4C                           '処理区分(=2A4C)
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          lstrClassDivision, _
                                          mtypTftProductList, _
                                          mlngTftProductListCnt, _
                                          pstrSBID)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If
            
            '@優先度情報の取得
            lblnAns = pubblnMasPriolist_Sel(CMstrmas_priolistVer, _
                                            mlngPriorityReasonListCnt, _
                                            mtypPriorityReasonList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If
            
            '@【作業者ﾘｽﾄ(ﾛｯﾄ担当者ﾘｽﾄ)取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasEmplist_Sel(CMstrmas_emplist_Ver, _
                                           mtypLotManagerList, _
                                           mlngLotManagerListCnt)

            '@結果格納
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If
            
        '@↓2013/11/27 (Wed) 19:39:08 T.Oide **************************************************
        '@    '@ATLASｵｰﾀﾞｰﾘｽﾄ取得
        '@    lblnAns = prvblnAtlsOrderList_Sel(mtypAtlsOrderList)
        '@    '@結果格納
        '@    If lblnAns = False Then
        '@    '@失敗の場合
        '@        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
        '@        Call pubResponseCancel(Me.Name, lstrEventName)
        '@
        '@        '@Escﾎﾞﾀﾝを有効
        '@        cmdClose.Cancel = True
        '@
        '@        Exit Sub
        '@    End If
        '@↑2013/11/27 (Wed) 19:39:08 T.Oide **************************************************

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_Load"              '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/16 (Mon) 11:14:04 S.Deguchi
    '更新日：2013/11/28 (Thu) 15:59:13 T.Oide
    '備　考：
    '　　　：2006/11/06 (Mon) 11:50:23 T.Kitagawa   量産(ODF対向基板)対応。(案件№01544)
    '　　　：2007/12/25 (Tue) 15:24:03 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2008/06/11 (Wed) 12:44:24 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐(起動時のみ処理)
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
            
                '@優先度の表示処理
                Call prvcmbPrioList_Disp()
                
                '@ﾛｯﾄ担当の表示処理
                Call prvCmbLotManagerList_Disp()
                
                '@投入機種情報表示処理
                Call prvcmbPdList_Disp()
                
                '@量産(ODF対向基板)投入機種情報表示処理
                Call prvcmbOdfPdList_Disp()
                
                '@量産(TFT対向基板)投入機種情報表示処理
                Call prvcmbTftPdList_Disp()
                
                '@投入流動区分ｺﾝﾎﾞ(TFT)
                Call prvcmbFlowClassList_Disp(cmbTftFlowClass)
                
                '@投入流動区分ｺﾝﾎﾞ(ODF)
                Call prvcmbFlowClassList_Disp(cmbOdfFlowClass)
                
                '@ﾁｯﾌﾟ電特ｺﾝﾎﾞ
                Call prvcmbChipElectric_Disp()
                
        '@↓2013/11/27 (Wed) 19:47:55 T.Oide **************************************************
        '@        '@ｱﾄﾗｽｵｰﾀﾞｰ情報取得処理
        '@        Call prvvsfOrderList_Disp(mtypAtlsOrderList)
        '@↑2013/11/27 (Wed) 19:47:55 T.Oide **************************************************
                
                '@機種ｺﾝﾎﾞﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbTftProduct)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
            End If
            
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
    '機　能：ﾌｫｰﾑのKeyDown処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 15:46:41 S.Deguchi
    '更新日：2013/11/28 (Thu) 15:58:56 T.Oide
    '備　考：
    '　　　：2006/11/06 (Mon) 11:52:56 T.Kitagawa   量産(ODF対向基板)対応(案件№01544)
    '　　　：2007/01/23 (Tue) 14:02:23 N.Kasai      量産(TFT基板)対応
    '　　　：2007/12/25 (Tue) 15:27:14 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
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

        '@↓2013/11/27 (Wed) 19:42:52 T.Oide **************************************************
        '@    '@ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、前頁ﾎﾞﾀﾝ、次頁ﾎﾞﾀﾝ)
        '@    Call pubVsf_KeyDown(KeyCode, ActiveControl.Name, vsfLotList, cmdUp, cmdDown)
        '@
        '@    '@ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、前頁ﾎﾞﾀﾝ、次頁ﾎﾞﾀﾝ)
        '@    Call pubVsf_KeyDown(KeyCode, ActiveControl.Name, vsfOrderList, cmdOrderUp, cmdOrderDown)
        '@↑2013/11/27 (Wed) 19:42:52 T.Oide **************************************************

            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名称による処理分岐
            Select Case ActiveControl.Name
            
                '@ﾌｫｰｶｽが量産(TFT基板)投入機種にある場合
                Case cmbTftProduct.Name
                    '@Enterで次ﾌｫｰｶｽへ
                    If e.KeyCode = Keys.Return Then
                        '@量産(ODF対向基板)投入機種のValidate処理へ
                        RemoveHandler cmbTftProduct.Validating, AddressOf cmbTftProduct_Validate
                        Call cmbTftProduct_Validate(cmbTftProduct, New CancelEventArgs(False))
                        AddHandler cmbTftProduct.Validating, AddressOf cmbTftProduct_Validate
                    End If
            
                '@ﾌｫｰｶｽが量産(ODF対向基板)投入機種にある場合
                Case cmbOdfProduct.Name
                    '@Enterで次ﾌｫｰｶｽへ
                    If e.KeyCode = Keys.Return Then
                        '@量産(ODF対向基板)投入機種のValidate処理へ
                        RemoveHandler cmbOdfProduct.Validating, AddressOf cmbOdfProduct_Validate
                        Call cmbOdfProduct_Validate(cmbOdfProduct, New CancelEventArgs(False))
                        AddHandler cmbOdfProduct.Validating, AddressOf cmbOdfProduct_Validate
                    End If
                
                '@ﾌｫｰｶｽが投入機種にある場合
                Case cmbProduct.Name
                    '@Enterで次ﾌｫｰｶｽへ
                    If e.KeyCode = Keys.Return Then
                        '@投入機種のValidate処理へ
                        RemoveHandler cmbProduct.Validating, AddressOf cmbProduct_Validate
                        Call cmbProduct_Validate(cmbProduct, New CancelEventArgs(False))
                        AddHandler cmbProduct.Validating, AddressOf cmbProduct_Validate
                    End If
                
                '@ﾌｫｰｶｽが投入種別にある場合
                Case cmbFlowClass.Name
                    '@Enterで次ﾌｫｰｶｽへ
                    If e.KeyCode = Keys.Return Then
                        '@投入種別のValidate処理へ
                        RemoveHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_Validate
                        Call cmbFlowClass_Validate(cmbFlowClass, New CancelEventArgs(False))
                        AddHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_Validate
                    End If

                '@ﾌｫｰｶｽがﾁｯﾌﾟ電特にある場合
                Case cmbChipElectric.Name
                    '@Enterで次ﾌｫｰｶｽへ
                    If e.KeyCode = Keys.Return Then
                        '@ﾁｯﾌﾟ電特のValidate処理へ
                        RemoveHandler cmbChipElectric.Validating, AddressOf cmbChipElectric_Validate
                        Call cmbChipElectric_Validate(cmbChipElectric, New CancelEventArgs(False))
                        AddHandler cmbChipElectric.Validating, AddressOf cmbChipElectric_Validate
                    End If

                '@ﾌｫｰｶｽが優先度にある場合
                Case cmbPrioSel.Name
                    '@Enterで次ﾌｫｰｶｽへ
                    If e.KeyCode = Keys.Return Then
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    End If
                
                '@ﾌｫｰｶｽが量産(TFT)投入流動区分にある場合
                Case cmbTftFlowClass.Name
                    '@Enterで次ﾌｫｰｶｽへ
                    If e.KeyCode = Keys.Return Then
                        '@量産(ODF対向基板)投入機種のValidate処理へ
                        RemoveHandler cmbTftFlowClass.Validating, AddressOf cmbTftFlowClass_Validate
                        Call cmbTftFlowClass_Validate(cmbTftFlowClass, New CancelEventArgs(False))
                        AddHandler cmbTftFlowClass.Validating, AddressOf cmbTftFlowClass_Validate
                    End If
                
                '@ﾌｫｰｶｽが量産(ODF)投入流動区分にある場合
                Case cmbOdfFlowClass.Name
                    '@Enterで次ﾌｫｰｶｽへ
                    If e.KeyCode = Keys.Return Then
                        '@量産(ODF対向基板)投入機種のValidate処理へ
                        RemoveHandler cmbOdfFlowClass.Validating, AddressOf cmbOdfFlowClass_Validate
                        Call cmbOdfFlowClass_Validate(cmbOdfFlowClass, New CancelEventArgs(False))
                        AddHandler cmbOdfFlowClass.Validating, AddressOf cmbOdfFlowClass_Validate
                    End If

				'@ｷｬﾘｱID
                Case txtCarrier.Name 
					'@EnterでキャリアIDvalidateへ
                    If e.KeyCode = Keys.Return Then
						'@ｷｬﾘｱID処理
                        RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                        Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(True))
                        AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                        Exit Sub

                    End If
                
                '@ﾌｫｰｶｽが作業ﾒﾓにある場合
                Case txtWorkMemo.Name
                    
                    '@Enterで改行
                    Exit Sub

                Case Else
                    '@Enterで次ﾌｫｰｶｽへ
                    If e.KeyCode = Keys.Return Then
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    End If
            End Select

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"               '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/07/26 (Mon) 15:46:44 S.Deguchi
    '更新日：2009/02/23 (Mon) 14:33:52 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 16:18:30 N.Kasai      閉じるﾎﾞﾀﾝ統合
    '　　　：2004/11/26 (Fri) 14:49:07 S.Deguchi    構造体初期化処理に技術担当者を追加
    '　　　：2004/12/01 (Wed) 17:45:53 S.Deguchi    ｶﾚﾝﾄ行保持機能を追加(ｸﾘｱ処理)
    '　　　：2006/11/06 (Mon) 11:54:54 T.Kitagawa   量産(ODF対向基板)対応(案件№01544)
    '　　　：2008/01/22 (Tue) 15:36:20 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2009/02/23 (Mon) 14:33:52 N.Kojima     ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連処理削除、ﾁｯﾌﾟ電特区分(限定工程設定)関連処理追加。(案件№3402)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm                 As Boolean              '開放結果格納
        Dim ltypSpPDEntryList           As MasSppdentryList     '解放構造体
        
        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@暗黙でFormが表示されたかどうかの判定
            If Not Me Is Me Then
                '@暗黙で表示されたものでない場合は処理を抜ける
                Exit Sub
            End If

            '@ﾓｼﾞｭｰﾙ構造体の初期化
            If Not IsNothing(mtypOdfProductList) Then
                mtypOdfProductList.Clear()
            End If
            mlngOdfProductListCnt = 0
            If Not IsNothing(mtypTftProductList) Then
                mtypTftProductList.Clear()
            End If
            mlngTftProductListCnt = 0
            If Not IsNothing(mtypProductList) Then
                mtypProductList.Clear()
            End If
            mlngProductListCnt = 0
            If Not IsNothing(mtypDivisionList) Then
                mtypDivisionList.Clear()
            End If
            mlngDivisionListCnt = 0
            If Not IsNothing(mtypPriorityReasonList) Then
                mtypPriorityReasonList.Clear()
            End If
            mlngPriorityReasonListCnt = 0
            If Not IsNothing(mtypLotManagerList) Then
                mtypLotManagerList.Clear()
            End If
            mlngLotManagerListCnt = 0
            mtypSpPDEntryList = ltypSpPDEntryList
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If Not IsNothing(mtypChgSort.typChgSortList) Then
                mtypChgSort.typChgSortList.Clear()
            End If
            If Not IsNothing(mtypChgSortOrder.typChgSortList) Then
                mtypChgSortOrder.typChgSortList.Clear()
            End If
            
        '@↓2009/02/23 (Mon) 14:33:44 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。

        '    '@ﾁｯﾌﾟ電特工程有無判定ﾌﾗｸﾞの初期化
        '    pblnCdenProcJudgeFlag = False

        '@↑2009/02/23 (Mon) 14:33:44 N.Kojima **************************************************
            
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

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 15:17:50 S.Deguchi
    '更新日：2004/07/26 (Mon) 15:17:50
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
            Call publngEnd_Proc(CPstrKeyEN00Q0, ltypCommonInfo)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdLotMake_Click
    '機　能：投入確定ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 09:02:38 S.Deguchi
    '更新日：2013/11/28 (Thu) 15:58:35 T.Oide
    '備　考：
    '　　　：2004/09/15 (Wed) 17:59:19 S.Deguchi    確定後,ｸﾘｱ処理を追加
    '　　　：2004/09/26 (Sun) 11:05:31 S.Deguchi    確定ﾒｯｾｰｼﾞ復活(№930)
    '　　　：2004/09/27 (Mon) 10:42:57 S.Deguchi    機種ｴﾝﾄﾘﾎﾞﾀﾝの復活によるｴﾝﾄﾘID制御
    '　　　：2004/11/24 (Wed) 18:16:20 S.Deguchi    技術担当者を追加
    '　　　：2004/11/29 (Mon) 16:43:02 S.Deguchi    技術担当者にNullを許可の為,Trim処理を追加
    '　　　：2005/03/31 (Thu) 14:10:06 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/05/19 (Thu) 13:08:19 S.Deguchi    確定処理＆ｵｰﾀﾞｰﾘｽﾄ取得処理を追加
    '　　　：2006/11/06 (Mon) 11:56:35 T.Kitagawa   量産(ODF対向基板)対応(案件№01544)
    '　　　：2007/12/25 (Tue) 15:31:54 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2008/06/11 (Wed) 13:04:29 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/23 (Mon) 14:14:23 N.Kojima     ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連処理削除、ﾁｯﾌﾟ電特区分(限定工程設定)関連処理追加。(案件№3402)
    '　　　：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
    Private Sub cmdLotMake_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotMake.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypLotAsmThrowIn       As LotAsmThrowIn        '投入確定格納構造体
        Dim lstrCarrierID           As String               'ｷｬﾘｱID
        Dim lstrLotID               As String               'ﾛｯﾄID
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        
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
            lblnAns = prvblnUserEntry_Chk()
            '@画面項目ﾁｪｯｸ結果判定
            If lblnAns = False Then
                '@不正項目あり
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "cmdLotMake_Click"
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@表示Tabにより処理分岐
            Select Case tabSelect.SelectedIndex
                
                '@量産(TFT基板)の場合
                Case CMlngPRTab0
                
                    '@投入確定構造体へ格納
                    With ltypLotAsmThrowIn
        '@↓2013/11/28 (Thu) 11:48:54 T.Oide **************************************************
        '@                .strPdID = _
        '@                    vsfOrderList.Cell(flexcpText, vsfOrderList.Row, CMlngvsfOrderColPDID)       '投入機種
        '@-------------------------------------------------------------------------------------
                        .strPdId = cmbTftProduct.Text                                                  '投入機種
        '@↑2013/11/28 (Thu) 11:48:54 T.Oide **************************************************
                        .strFlowClass = cmbTftFlowClass.Text                                            '投入種別
                        .strEntryFlag = vbNullString                                                    'ｴﾝﾄﾘﾌﾗｸﾞ
                        .strEntryID = vbNullString                                                      'ｴﾝﾄﾘID
            
                        '@優先度取得
                        cmbPrioSel.ValueCol = CMlngCmbGetCol1
                        .strLotPriority = cmbPrioSel.Value                                              '優先度
                        
                        .strLotID = vsfLotList.GetData(vsfLotList.Row, CMlngvsfColLotID)       'ﾛｯﾄID
                        .strComments = txtWorkMemo.Text                                                 '作業ﾒﾓ
                        .strEmpID = pstrUserID                                                          '作業者ID
                        .strSbID = pstrSBID                                                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strMsgVer = CMstrlot_asmthrowinVer                                             'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        .strEngEmpId = vbNullString                                                     'ﾛｯﾄ担当者ID
        '@↓2013/11/27 (Wed) 19:48:54 T.Oide **************************************************
        '@                .strOrderNum = _
        '@                    vsfOrderList.Cell(flexcpText, vsfOrderList.Row, CMlngvsfOrderColOrderNo)    'ｵｰﾀﾞｰ
        '@↑2013/11/27 (Wed) 19:48:54 T.Oide **************************************************
                        .strClassDivision = CPstrCD3X                                                   '処理区分：3X
                        
        '@↓2009/02/23 (Mon) 14:35:07 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。

        '                '@選択ｵｰﾀﾞｰのSB_IDが"自SB_ID"か
        '                If vsfOrderList.Cell(flexcpText, vsfOrderList.Row, CMlngvsfOrderColSendSBID) = pstrSBID Then
        '                    '@自SB_IDと同じ場合
        '                    .strCdenFlag = CPstrOne                                                     '1:ﾁｯﾌﾟ電特工程あり
        '                Else
        '                    '@自SB_IDと異なる場合
        '                    .strCdenFlag = CPstrZero                                                    '0:ﾁｯﾌﾟ電特工程なし
        '                End If

        '@↑2009/02/23 (Mon) 14:35:07 N.Kojima **************************************************
                        
                        '@Tab別制御ﾌﾗｸﾞに"1:量産/ES(TFT)"を設定
                        mlngJudgeFlag = 1
                        
                    End With
                
                '@量産(ODF対向基板)の場合
                Case CMlngODFTab1
                
                    '@投入確定構造体へ格納
                    With ltypLotAsmThrowIn
                        .strPdId = cmbOdfProduct.Text                                                   '投入機種
                        .strFlowClass = cmbOdfFlowClass.Text                                            '投入種別
                        .strEntryFlag = vbNullString                                                    'ｴﾝﾄﾘﾌﾗｸﾞ
                        .strEntryID = vbNullString                                                      'ｴﾝﾄﾘID
            
                        '@優先度取得
                        cmbPrioSel.ValueCol = CMlngCmbGetCol1
                        .strLotPriority = cmbPrioSel.Value                                              '優先度
                        
                        .strLotID = vsfLotList.GetData(vsfLotList.Row, CMlngvsfColLotID)                'ﾛｯﾄID
                        .strComments = txtWorkMemo.Text                                                 '作業ﾒﾓ
                        .strEmpID = pstrUserID                                                          '作業者ID
                        .strSbID = pstrSBID                                                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strMsgVer = CMstrlot_asmthrowinVer                                             'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        .strEngEmpId = vbNullString                                                     'ﾛｯﾄ担当者ID
                        .strOrderNum = vbNullString                                                     'ｵｰﾀﾞｰ
                        .strClassDivision = CPstrCD4B                                                   '処理区分：4B
                        
        '@↓2009/02/23 (Mon) 14:35:20 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。
                     
        '                '@量産(ODF対向基板)の場合は固定で"0"を送信
        '                .strCdenFlag = CPstrZero                                                        '0:ﾁｯﾌﾟ電特工程なし

        '@↑2009/02/23 (Mon) 14:35:20 N.Kojima **************************************************
                        
                    End With
                    
                '@試作実験の場合
                Case CMlngZZTab2
                
                    '@投入確定構造体へ格納
                    With ltypLotAsmThrowIn
                        .strPdId = cmbProduct.Text                                                      '投入機種
                        .strFlowClass = cmbFlowClass.Text                                               '投入種別
                        
                        '@ｴﾝﾄﾘ情報の取得処理
                        If optThrowUser0.Checked = True Then
                        '@機種ｴﾝﾄﾘが選択されている場合
                            .strEntryFlag = CMlngEntryFlag0                                             'ｴﾝﾄﾘﾌﾗｸﾞ
                            .strEntryID = lblEntryID.Text                                               '機種ｴﾝﾄﾘID
                        Else
                        '@ﾕｰｻﾞｰﾌﾟﾛｾｽが選択されている場合
                            .strEntryFlag = CMlngEntryFlag1                                             'ｴﾝﾄﾘﾌﾗｸﾞ
                            .strEntryID = txtUserEntry.Text                                             'ﾕｰｻﾞｰﾌﾟﾛｾｽID
							txtWorkMemo.Text = txtWorkMemo.Text & txtUserEntry.Text & ":" & lblUserEntry.Text 'どのユーザープロセスで投入したかを作業メモで残す
                        End If
                        
                        '@優先度取得
                        cmbPrioSel.ValueCol = CMlngCmbGetCol1
                        .strLotPriority = cmbPrioSel.Value                                              '優先度
                        
                        .strLotID = vsfLotList.GetData(vsfLotList.Row, CMlngvsfColLotID)                'ﾛｯﾄID
                        .strComments = txtWorkMemo.Text                                                 '作業ﾒﾓ
                        .strEmpID = pstrUserID                                                          '作業者ID
                        .strSbID = pstrSBID                                                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strMsgVer = CMstrlot_asmthrowinVer                                             'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        .strEngEmpId = Trim(mstrLotManagerID)                                           'ﾛｯﾄ担当者ID
                        .strOrderNum = vbNullString                                                     'ｵｰﾀﾞｰ
                        .strClassDivision = CPstrCD0V                                                   '処理区分：0V
                        
        '@↓2009/02/23 (Mon) 14:35:30 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。
                   
        '                '@ﾁｯﾌﾟ電特"あり"か
        '                If cmbChipElectric.Text = CPstrAriFlg Then                                      'ﾁｯﾌﾟ電特ﾌﾗｸﾞ
        '                    '@"あり"の場合
        '                    .strCdenFlag = CPstrOne                                                     '1:ﾁｯﾌﾟ電特工程あり
        '                Else
        '                    '@"なし"の場合
        '                    .strCdenFlag = CPstrZero                                                    '0:ﾁｯﾌﾟ電特工程なし
        '                End If

        '@↑2009/02/23 (Mon) 14:35:30 N.Kojima **************************************************

                    End With
                    
            End Select
            
            '@TFT基板在庫一覧情報更新処理
            lblnAns = pubblnLotAsmthrowin_Upd(ltypLotAsmThrowIn, lstrGuidMsg, lstrGuidMsgCode)
            
            '@結果判定
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)
                
                '@ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ表示制御
                Call pubGuidMsg_Set(lstrGuidMsgCode, lstrGuidMsg, Me)
                
                '@投入したﾛｯﾄのｷｬﾘｱIDとﾛｯﾄIDを格納
                With vsfLotList
                    lstrCarrierID = .GetData(vsfLotList.Row, CMlngvsfColCarrierID)
                    lstrLotID = .GetData(vsfLotList.Row, CMlngvsfColLotID)
                End With
                
                '@"<TRM07I>$$ロット[%2]を投入しました。キャリア[%1]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0007, lstrCarrierID, lstrLotID)
                '@ﾒｯｾｰｼﾞを表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@画面情報の初期化を行う(全部取消処理へ)
                Call cmdClear_Click(cmdClear, New EventArgs())
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                Exit Sub
            End If

            '@Tabによる処理分岐
            Select Case tabSelect.SelectedIndex
                
                Case CMlngPRTab0
        '@↓2013/11/27 (Wed) 19:50:06 T.Oide **************************************************
        '@            If vsfOrderList.Enabled = True Then
        '@                '@ｸﾞﾘｯﾄﾞの選択状態を解除する
        '@                vsfOrderList.Row = 0
        '@            Else
        '@                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
        '@                Call pubSetFocus(cmdClose)
        '@            End If
        '@------------------------------------------------------------------------------------
                    '@量産(TFT機種)投入機種へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbTftProduct)
        '@↑2013/11/27 (Wed) 19:50:06 T.Oide **************************************************
                
                Case CMlngODFTab1
                    '@量産(ODF対向基板)投入機種へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbOdfProduct)
                
                Case CMlngZZTab2
                    '@試作実験の投入機種へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbProduct)
            
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdLotMake_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdClear_Click
    '機　能：画面項目全取消
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 13:17:31 S.Deguchi
    '更新日：2013/11/28 (Thu) 15:58:02 T.Oide
    '備　考：
    '　　　：2005/05/19 (Thu) 13:11:09 S.Deguchi    表示Tabによるﾌｫｰｶｽ処理を修正
    '　　　：2006/11/06 (Mon) 12:09:15 T.Kitagawa   量産(ODF対向基板)対応(案件№01544)
    '　　　：2007/01/23 (Tue) 15:56:51 N.Kasai      量産(TFT基板)対応
    '　　　：2008/01/09 (Wed) 13:40:45 N.Kojima     試作/実験Tabからの確定の場合は、ｵｰﾀﾞｰの再取得は行なわない。(案件№02263)
    '　　　：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click
        
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
            
            '@画面情報の初期化
            Call prvfrmxxEN00Q0_Init(False)

            '@量産/ES(ODF)Tabの投入機種ｺﾝﾎﾞの設定
            Call prvcmbOdfPdList_Disp()
            
            '@試作/実験Tabの投入機種ｺﾝﾎﾞの設定
            Call prvcmbPdList_Disp()
            
            '@量産/ES(TFT)Tabの投入機種ｺﾝﾎﾞの設定
            Call prvcmbTftPdList_Disp()

            '@Tab別制御ﾌﾗｸﾞが"1:量産/ES(TFT)"か
            If mlngJudgeFlag = 1 Then

                '@Tab別制御ﾌﾗｸﾞの初期化
                mlngJudgeFlag = 0

        '@↓2013/11/28 (Thu) 13:05:16 T.Oide **************************************************
        '@        '@ﾚｽﾎﾟﾝｽ取得開始
        '@        lstrEventName = "cmdClear_Click"
        '@        Call pubResponseStart(Me.Name, lstrEventName)
        '@
        '@        '@ATLASｵｰﾀﾞｰﾘｽﾄ取得
        '@        lblnAns = prvblnAtlsOrderList_Sel(mtypAtlsOrderList)
        '@        '@結果格納
        '@        If lblnAns = False Then
        '@        '@失敗の場合
        '@            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
        '@            Call pubResponseCancel(Me.Name, lstrEventName)
        '@            Exit Sub
        '@        End If
        '@
        '@        '@ﾚｽﾎﾟﾝｽ取得終了
        '@        Call publngResponseEnd(Me.Name, lstrEventName)
        '@↑2013/11/28 (Thu) 13:05:16 T.Oide **************************************************
            End If
            
        '@↓2013/11/27 (Wed) 19:51:42 T.Oide **************************************************
        '@    '@ｵｰﾀﾞｰ情報表示処理
        '@    Call prvvsfOrderList_Disp(mtypAtlsOrderList)
        '@↑2013/11/27 (Wed) 19:51:42 T.Oide **************************************************
            
            '@優先度ｺﾝﾎﾞを初期値へ
            cmbPrioSel.ListIndex = CMstrcmbPrioSel      '2 普通
            
            '@Tabによる処理分岐
            Select Case tabSelect.SelectedIndex
                
                Case CMlngPRTab0
        '@↓2013/11/27 (Wed) 19:52:06 T.Oide **************************************************
        '@            '@ｸﾞﾘｯﾄﾞの選択状態を解除する
        '@            vsfOrderList.Row = 0
        '@↑2013/11/27 (Wed) 19:52:06 T.Oide **************************************************
                    '@量産(TFT基板)投入機種へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbTftProduct)
                
                Case CMlngODFTab1
                    '@量産(ODF対向基板)投入機種へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbOdfProduct)
                
                Case CMlngZZTab2
                    '@試作実験の投入機種へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbProduct)
            
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdClear_Click"         '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：tabSelect_Click
    '機　能：検索条件Tab処理
    '引　数：PreviousTab：使用しない
    '戻り値：なし
    '作成日：2005/05/16 (Mon) 11:34:27 S.Deguchi
    '更新日：2013/11/28 (Thu) 15:57:42 T.Oide
    '備　考：
    '　　　：2005/07/21 (Thu) 15:38:41 N.Kasai      L/R表示機能追加
    '　　　：2005/07/29 (Fri) 08:44:20 N.Kasai      機種ｺﾝﾎﾞｸﾘｱ追加
    '　　　：2006/11/06 (Mon) 12:12:00 T.Kitagawa   量産(ODF対向基板)対応(案件№01544)
    '　　　：2007/01/23 (Tue) 13:29:05 N.Kasai      量産(TFT基板)対応
    '　　　：2007/12/26 (Wed) 15:51:02 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2008/06/11 (Wed) 12:45:03 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
    Private Sub tabSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tabSelect.SelectedIndexChanged
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが立っていない場合処理抜け
            If mblnFormLoadFlag = False Then
                Exit Sub
            End If
            
            '@ﾀﾌﾞ選択処理
            Select Case tabSelect.SelectedIndex
                
                '@量産/ES(TFT)
                Case CMlngPRTab0

                    '@試作/実験のTab内容をｸﾘｱ
                    '@ﾘｽﾄｲﾝﾃﾞｯｸｽをｸﾘｱしないと前回取得した内容が再表示される。
                    cmbProduct.ListIndex = -1                   '機種ｺﾝﾎﾞｸﾘｱ
                    cmbProduct.BackColor = Color.White          '機種(ﾊﾞｯｸｶﾗｰ白)
                    cmbFlowClass.ListIndex = -1                 '種別
                    cmbChipElectric.Text = vbNullString         'ﾁｯﾌﾟ電特ｺﾝﾎﾞ
                    cmbChipElectric.Enabled = False
                    lblEntryID.Text = vbNullString              'ｴﾝﾄﾘID
                    lblEntry.Text = vbNullString                'ｴﾝﾄﾘ名
                    txtUserEntry.Text = vbNullString            'ﾕｰｻﾞｰｴﾝﾄﾘID
                    lblUserEntry.Text = vbNullString            'ﾕｰｻﾞｰｴﾝﾄﾘ名
                    '@試作/実験のTabを使用不可とする
                    fraThrowIn.Enabled = False

                    '@量産(ODF対向基板)のTab内容をｸﾘｱ
                    '@ﾘｽﾄｲﾝﾃﾞｯｸｽをｸﾘｱしないと前回取得した内容が再表示される。
                    cmbOdfProduct.ListIndex = -1                '機種ｺﾝﾎﾞｸﾘｱ
                    cmbOdfProduct.BackColor = Color.White       '機種(ﾊﾞｯｸｶﾗｰ白)
                    cmbOdfFlowClass.ListIndex = -1              '流動区分
                    cmbOdfFlowClass.BackColor = Color.White     '流動区分(ﾊﾞｯｸｶﾗｰ白)
                    '@量産(ODF対向基板)のTabを使用不可とする
                    fraOdfThrowIn.Enabled = False

        '@↓2013/11/27 (Wed) 19:52:22 T.Oide **************************************************
        '@            '@量産Tabを使用可能に
        '@            vsfOrderList.Enabled = True
        '@↑2013/11/27 (Wed) 19:52:22 T.Oide **************************************************

                    '@在庫一覧を初期化
                    Call prvvsfLotList_Init()

                    '@TFT基板在庫情報のﾗﾍﾞﾙ初期化
                    lblTFTProduct.Text = vbNullString        'TFT基板機種
                    lblNowDate.Text = vbNullString           '情報取得日時
                    lblLotCnt.Text = vbNullString            '該当件数
                    cmdLotList.Enabled = False               '最新取得ﾎﾞﾀﾝ

					txtCarrier.Text = vbNullString

                    '@ﾛｯﾄ担当ｺﾝﾎﾞを使用不可へ
                    cmbLotManager.Text = vbNullString
                    cmbLotManager.Enabled = False

                    '@優先度Comboを初期化
                    cmbPrioSel.ListIndex = CMstrcmbPrioSel      '2 普通

        '@↓2013/11/27 (Wed) 19:53:11 T.Oide **************************************************
        '@            '@ﾌｫｰｶｽ処理
        '@            With vsfOrderList
        '@                If .Enabled = True Then
        '@                    '@行選択
        '@                    .Row = CMlngVsfRowTitle
        '@
        '@                    '@ｵｰﾀﾞｰ一覧へﾌｫｰｶｽｾｯﾄ(ﾀｲﾄﾙ)
        '@                    Call pubSetFocus(vsfOrderList)
        '@                Else
        '@                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
        '@                    Call pubSetFocus(cmdClose)
        '@                End If
        '@            End With
        '@↑2013/11/27 (Wed) 19:53:11 T.Oide **************************************************

                    '@機種へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbTftProduct)
                
                '@量産/ES(ODF)
                Case CMlngODFTab1

                    '@試作/実験のTab内容をｸﾘｱ
                    '@ﾘｽﾄｲﾝﾃﾞｯｸｽをｸﾘｱしないと前回取得した内容が再表示される。
                    cmbProduct.ListIndex = -1                   '機種ｺﾝﾎﾞｸﾘｱ
                    cmbProduct.BackColor = Color.White          '機種(ﾊﾞｯｸｶﾗｰ白)
                    cmbFlowClass.ListIndex = -1                 '種別
                    cmbChipElectric.Text = vbNullString         'ﾁｯﾌﾟ電特ｺﾝﾎﾞ
                    cmbChipElectric.Enabled = False
                    lblEntryID.Text = vbNullString              'ｴﾝﾄﾘID
                    lblEntry.Text = vbNullString                'ｴﾝﾄﾘ名
                    txtUserEntry.Text = vbNullString            'ﾕｰｻﾞｰｴﾝﾄﾘID
                    lblUserEntry.Text = vbNullString            'ﾕｰｻﾞｰｴﾝﾄﾘ名
                    '@試作/実験のTabを使用不可とする
                    fraThrowIn.Enabled = False

                    '@量産(ODF対向基板)のTabを使用可能に
                    fraOdfThrowIn.Enabled = True
                    cmbOdfProduct.Enabled = True
                    cmbOdfFlowClass.Enabled = True

        '@↓2013/11/27 (Wed) 19:53:26 T.Oide **************************************************
        '@            '@量産/ES(TFT)Tabを使用不可に
        '@            vsfOrderList.Enabled = False
        '@↑2013/11/27 (Wed) 19:53:26 T.Oide **************************************************

                    '@在庫一覧を初期化
                    Call prvvsfLotList_Init()

                    '@TFT基板在庫情報のﾗﾍﾞﾙ初期化
                    lblTFTProduct.Text = vbNullString        'TFT基板機種
                    lblNowDate.Text = vbNullString           '情報取得日時
                    lblLotCnt.Text = vbNullString            '該当件数
                    cmdLotList.Enabled = False               '最新取得ﾎﾞﾀﾝ

					txtCarrier.Text = vbNullString

                    '@ﾛｯﾄ担当ｺﾝﾎﾞを使用不可へ
                    cmbLotManager.Text = vbNullString
                    cmbLotManager.Enabled = False

                    '@優先度Comboを初期化
                    cmbPrioSel.ListIndex = CMstrcmbPrioSel      '2 普通

                    '@機種へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbOdfProduct)
                
                '@試作/実験
                Case CMlngZZTab2
                
                    '@量産(ODF対向基板)のTab内容をｸﾘｱ
                    '@ﾘｽﾄｲﾝﾃﾞｯｸｽをｸﾘｱしないと前回取得した内容が再表示される。
                    cmbOdfProduct.ListIndex = -1                '機種ｺﾝﾎﾞｸﾘｱ
                    cmbOdfProduct.BackColor = Color.White       '機種(ﾊﾞｯｸｶﾗｰ白)
                    cmbOdfFlowClass.ListIndex = -1              '流動区分
                    cmbOdfFlowClass.BackColor = Color.White     '流動区分(ﾊﾞｯｸｶﾗｰ白)
                    '@量産(ODF対向基板)のTabを使用不可とする
                    fraOdfThrowIn.Enabled = False

                    '@試作/実験のTabを使用可能に
                    fraThrowIn.Enabled = True
                    cmbProduct.Enabled = True
                    
        '@↓2013/11/27 (Wed) 19:53:47 T.Oide **************************************************
        '@            '@量産Tabを使用不可に
        '@            vsfOrderList.Enabled = False
        '@↑2013/11/27 (Wed) 19:53:47 T.Oide **************************************************

                    '@在庫一覧を初期化
                    Call prvvsfLotList_Init()

                    '@TFT基板在庫情報のﾗﾍﾞﾙ初期化
                    lblTFTProduct.Text = vbNullString        'TFT基板機種
                    lblNowDate.Text = vbNullString           '情報取得日時
                    lblLotCnt.Text = vbNullString            '該当件数
                    cmdLotList.Enabled = False               '最新取得ﾎﾞﾀﾝ

					txtCarrier.Text = vbNullString

                    '@ﾛｯﾄ担当ｺﾝﾎﾞを使用可能
                    cmbLotManager.Text = vbNullString
                    cmbLotManager.Enabled = True

                    '@機種へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbProduct)

                    '@優先度Comboを使用可能
                    cmbPrioSel.ListIndex = CMstrcmbPrioSel      '2 普通
                    cmbPrioSel.Enabled = True

            End Select
            
            '@TFT機種が既に選択済みの場合
            If cmbTftProduct.ListIndex > 0 Then
                
                '@TFT機種初期化
                cmbTftProduct.ListIndex = 0
                cmbTftProduct.BackColor = Color.White           '機種(ﾊﾞｯｸｶﾗｰ白)
                
        '@↓2013/11/28 (Thu) 13:06:14 T.Oide **************************************************
        '@        '@ﾚｽﾎﾟﾝｽ取得開始
        '@        lstrEventName = "tabSelect_Click"
        '@        Call pubResponseStart(Me.Name, lstrEventName)
        '@
        '@        '@ATLASｵｰﾀﾞｰﾘｽﾄ取得
        '@        lblnAns = prvblnAtlsOrderList_Sel(mtypAtlsOrderList)
        '@        '@結果格納
        '@        If lblnAns = False Then
        '@        '@失敗の場合
        '@            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
        '@            Call pubResponseCancel(Me.Name, lstrEventName)
        '@            Exit Sub
        '@        End If
        '@
        '@        '@ｱﾄﾗｽｵｰﾀﾞｰ情報取得処理
        '@        Call prvvsfOrderList_Disp(mtypAtlsOrderList)
        '@
        '@        '@ﾚｽﾎﾟﾝｽ取得終了
        '@        Call publngResponseEnd(Me.Name, lstrEventName)
        '@↑2013/11/28 (Thu) 13:06:14 T.Oide **************************************************

            End If

            '@作業ﾒﾓｸﾘｱ
            txtWorkMemo.Text = vbNullString
            '@全部取消ﾎﾞﾀﾝを使用不可
            cmdClear.Enabled = False
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "tabSelect_Click"        '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbOdfProduct_Change
    '機　能：量産(ODF対向基板)投入機種変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/06 (Mon) 13:25:17 T.Kitagawa
    '更新日：2006/11/06 (Mon) 13:25:17
    '備　考：
    Private Sub cmbOdfProduct_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOdfProduct.Change

        Try

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString

            '@量産(ODF対向基板)投入機種を変更する場合には、画面情報の初期化を行う
            Call prvfrmxxEN00Q0_Init(False)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbOdfProduct_Change"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOdfProduct_CloseUp
    '機　能：量産(ODF対向基板)投入機種のCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/06 (Mon) 13:47:26 T.Kitagawa
    '更新日：2006/11/06 (Mon) 13:47:26
    '備　考：
    Private Sub cmbOdfProduct_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOdfProduct.CloseUp

        Try

            '@項目の空白判定
            If cmbOdfProduct.Text <> vbNullString Then
            '@空白以外の場合
                '@投入機種のValidate処理へ
                RemoveHandler cmbOdfProduct.Validating, AddressOf cmbOdfProduct_Validate
                Call cmbOdfProduct_Validate(cmbOdfProduct, New CancelEventArgs(True))
                AddHandler cmbOdfProduct.Validating, AddressOf cmbOdfProduct_Validate
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbOdfProduct_CloseUp"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOdfProduct_Validate
    '機　能：量産(ODF対向基板)投入機種のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/11/06 (Mon) 13:49:49 T.Kitagawa
    '更新日：2006/11/06 (Mon) 13:49:49
    '備　考：
    Private Sub cmbOdfProduct_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbOdfProduct.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@量産(ODF対向基板)投入機種が選択されている場合のみ処理を行う
            If cmbOdfProduct.Text <> vbNullString Then
                '@退避領域と同じ場合には処理終了(ﾌｫｰｶｽ遷移)
                If mstrOdfPDID = cmbOdfProduct.Text Then
                    '@次項目へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbOdfFlowClass)
                    Exit Sub
                End If
                        
                '@値取得(ﾊﾞｯｸｶﾗｰ値)
                cmbOdfProduct.ValueCol = CMlngCmbGetCol5
                
                If Me.ActiveControl Is cmbOdfProduct Then
                    ' NSYS フォーカスがある場合
                    Me.ActiveControl = Nothing '一旦フォーカスを外す
                    If cmbOdfProduct.Value <> vbNullString Then
                        '@ﾊﾞｯｸｶﾗｰ反映
                        cmbOdfProduct.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(cmbOdfProduct.Value))
                    Else
                        cmbOdfProduct.BackColor = Color.White
                    End If
                    Me.ActiveControl = cmbOdfProduct 'フォーカスを戻す
                    pubSetFocus(cmbOdfProduct)
                Else
                    If cmbOdfProduct.Value <> vbNullString Then
                        '@ﾊﾞｯｸｶﾗｰ反映
                        cmbOdfProduct.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(cmbOdfProduct.Value))
                    Else
                        cmbOdfProduct.BackColor = Color.White
                    End If
                End If

                '@TFT基板機種(親機種ID)をﾗﾍﾞﾙにｾｯﾄ
                With cmbOdfProduct
                    .ValueCol = CMlngCmbGetCol1
                    lblTFTProduct.Text = .Value
                End With
            End If
            
            '@次項目へﾌｫｰｶｽｾｯﾄ
            If ActiveControl Is cmbOdfProduct Then
                Call pubSetFocus(cmbOdfFlowClass)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbOdfProduct_Validate" '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbTftProduct_Change
    '機　能：TFT基板機種ｺﾝﾎﾞ変更
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/18 (Thu) 15:20:10 N.Kasai
    '更新日：2013/11/28 (Thu) 15:57:06 T.Oide
    '備　考：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
    Private Sub cmbTftProduct_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTftProduct.Change

        Try

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString

            '@投入機種を変更する場合には、画面情報の初期化を行う
            Call prvfrmxxEN00Q0_Init(False)
            
        '@↓2013/11/27 (Wed) 19:43:28 T.Oide **************************************************
        '@    '@ｵｰﾀﾞｰ一覧の初期化
        '@    Call prvvsfOrderList_Init
        '@    cmdOrderUp.Enabled = False
        '@    cmdOrderDown.Enabled = False
        '@↑2013/11/27 (Wed) 19:43:28 T.Oide **************************************************

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbTftProduct_Change"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbTftProduct_CloseUp
    '機　能：TFT基板機種ｺﾝﾎﾞ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/18 (Thu) 15:20:26 N.Kasai
    '更新日：2007/01/18 (Thu) 15:20:26
    '備　考：
    Private Sub cmbTftProduct_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTftProduct.CloseUp

        Try

            '@項目の空白判定
            If cmbTftProduct.Text <> vbNullString Then
                '@空白以外の場合
                '@投入機種のValidate処理へ
                RemoveHandler cmbTftProduct.Validating, AddressOf cmbTftProduct_Validate
                Call cmbTftProduct_Validate(cmbTftProduct, New CancelEventArgs(True))
                AddHandler cmbTftProduct.Validating, AddressOf cmbTftProduct_Validate
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbTftProduct_CloseUp"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbTftProduct_Validate
    '機　能：TFT基板機種処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/01/18 (Thu) 15:21:11 N.Kasai
    '更新日：2013/11/28 (Thu) 15:56:46 T.Oide
    '備　考：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
    Private Sub cmbTftProduct_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbTftProduct.Validating

        Dim lblnNextCtrl    As Boolean      'NSYS Focus設定フラグ

        Try
 
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If ActiveControl Is cmbTftProduct Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If
            
            '@量産(TFT基板)投入機種が選択されている場合のみ処理を行う
            If cmbTftProduct.Text <> vbNullString Then
                '@退避領域と同じ場合には処理終了(ﾌｫｰｶｽ遷移)
                If mstrTftPDID = cmbTftProduct.Text Then
                    '@次項目へﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmbTftFlowClass)
                    End If
                    Exit Sub
                End If
            Else
                '@次項目へﾌｫｰｶｽｾｯﾄ
                If lblnNextCtrl Then
                    Call pubSetFocus(cmbTftFlowClass)
                End If
                Exit Sub
            End If
            
            '@値取得(ﾊﾞｯｸｶﾗｰ値)
            With cmbTftProduct
                .ValueCol = CMlngCmbGetCol5
                If Me.ActiveControl Is cmbTftProduct Then
                    ' NSYS フォーカスがある場合
                    Me.ActiveControl = Nothing '一旦フォーカスを外す
                    If .Value <> vbNullString Then
                        '@ﾊﾞｯｸｶﾗｰ反映
                        .BackColor = ColorTranslator.FromWin32(Convert.ToInt32(.Value))
                    Else
                        .BackColor = Color.White
                    End If
                    Me.ActiveControl = cmbTftProduct 'フォーカスを戻す
                    pubSetFocus(cmbTftProduct)
                Else
                    If .Value <> vbNullString Then
                        '@ﾊﾞｯｸｶﾗｰ反映
                        .BackColor = ColorTranslator.FromWin32(Convert.ToInt32(.Value))
                    Else
                        .BackColor = Color.White
                    End If
                End If
            End With
            
        '@↓2013/11/28 (Thu) 13:07:00 T.Oide **************************************************
        '@    '@ﾚｽﾎﾟﾝｽ取得開始
        '@    lstrEventName = "cmbTftProduct_Validate"
        '@    Call pubResponseStart(Me.Name, lstrEventName)
        '@
        '@    '@ATLASｵｰﾀﾞｰﾘｽﾄ取得
        '@    lblnAns = prvblnAtlsOrderList_Sel(mtypAtlsOrderList)
        '@    '@結果格納
        '@    If lblnAns = False Then
        '@    '@失敗の場合
        '@        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
        '@        Call pubResponseCancel(Me.Name, lstrEventName)
        '@        Exit Sub
        '@    End If
        '@
        '@    '@ｱﾄﾗｽｵｰﾀﾞｰ情報表示処理
        '@    Call prvvsfOrderList_Disp(mtypAtlsOrderList)
        '@
        '@    '@ﾚｽﾎﾟﾝｽ取得終了
        '@    Call publngResponseEnd(Me.Name, lstrEventName)
        '@-------------------------------------------------------------------------------------

                '@TFT基板機種(親機種ID)をﾗﾍﾞﾙにｾｯﾄ
                With cmbTftProduct
                    .ValueCol = CMlngCmbGetCol1
                    lblTFTProduct.Text = .Value
                End With
        '@↑2013/11/28 (Thu) 13:07:00 T.Oide **************************************************

            '@退避領域へ値をｾｯﾄ
            mstrTftPDID = cmbTftProduct.Text
            
            '@次項目へﾌｫｰｶｽｾｯﾄ
            If lblnNextCtrl Then
                Call pubSetFocus(cmbTftFlowClass)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbTftProduct_Validate" '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOdfFlowClass_Change
    '機　能：ODF種別ｺﾝﾎﾞ変更
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/25 (Tue) 18:11:33 N.Kasai
    '更新日：2007/09/25 (Tue) 18:11:33
    '備　考：
    Private Sub cmbOdfFlowClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOdfFlowClass.Change

        Try
            
            '@退避変数初期化
            mstrODFFlowClass = vbNullString
            
            '@在庫一覧を初期化
            Call prvvsfLotList_Init()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbOdfFlowClass_Change"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbOdfFlowClass_CloseUp
    '機　能：ODF種別ｺﾝﾎﾞ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/25 (Tue) 18:13:09 N.Kasai
    '更新日：2007/09/25 (Tue) 18:13:09
    '備　考：
    Private Sub cmbOdfFlowClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOdfFlowClass.CloseUp

        Try
            
            '@ODF種別ｺﾝﾎﾞ処理へ
            RemoveHandler cmbOdfFlowClass.Validating, AddressOf cmbOdfFlowClass_Validate
            Call cmbOdfFlowClass_Validate(cmbOdfFlowClass, New CancelEventArgs(True))
            AddHandler cmbOdfFlowClass.Validating, AddressOf cmbOdfFlowClass_Validate
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbOdfFlowClass_CloseUp"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOdfFlowClass_Validate
    '機　能：ODF種別ｺﾝﾎﾞ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/09/25 (Tue) 18:14:14 N.Kasai
    '更新日：2007/09/25 (Tue) 18:14:14
    '備　考：
    Private Sub cmbOdfFlowClass_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbOdfFlowClass.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@変更内容確認
             If mstrODFFlowClass = cmbOdfFlowClass.Text Then
                Exit Sub
             End If
             
            '@変更内容退避
            mstrODFFlowClass = cmbOdfFlowClass.Text
            
            If cmbOdfFlowClass.Text <> vbNullString And _
                cmbOdfProduct.Text <> vbNullString Then
                
                cmdLotList.Enabled = True

                '@最新取得
                Call cmdLotList_Click(cmdLotList, New EventArgs())
            Else
                '@ﾌｫｰｶｽ移動
                If ActiveControl Is cmbOdfFlowClass Then
                    Call pubSetFocus(cmdClose)
                End If
            End If
                
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "cmbOdfFlowClass_Validate"       '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbTftFlowClass_Change
    '機　能：TFT種別ｺﾝﾎﾞ変更
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/25 (Tue) 18:16:15 N.Kasai
    '更新日：2007/09/25 (Tue) 18:16:15
    '備　考：
    Private Sub cmbTftFlowClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTftFlowClass.Change

        Try
            
            '@退避変数初期化
            mstrTFTFlowClass = vbNullString
            
            '@在庫一覧を初期化
            Call prvvsfLotList_Init()

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "cmbTftFlowClass_Change"         '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbTftFlowClass_CloseUp
    '機　能：TFT種別ｺﾝﾎﾞ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/25 (Tue) 18:17:17 N.Kasai
    '更新日：2007/09/25 (Tue) 18:17:17
    '備　考：
    Private Sub cmbTftFlowClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTftFlowClass.CloseUp

        Try

            '@TFT種別ｺﾝﾎﾞ処理へ
            RemoveHandler cmbTftFlowClass.Validating, AddressOf cmbTftFlowClass_Validate
            Call cmbTftFlowClass_Validate(cmbTftFlowClass, New CancelEventArgs(True))
            AddHandler cmbTftFlowClass.Validating, AddressOf cmbTftFlowClass_Validate

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "cmbTftFlowClass_CloseUp"        '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：cmbTftFlowClass_Validate
    '機　能：TFT種別ｺﾝﾎﾞ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/09/25 (Tue) 18:18:20 N.Kasai
    '更新日：2013/11/28 (Thu) 15:56:21 T.Oide
    '備　考：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
    Private Sub cmbTftFlowClass_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbTftFlowClass.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@変更内容確認
            If mstrTFTFlowClass = cmbTftFlowClass.Text Then
                Exit Sub
            End If
            
            '@変更内容退避
            mstrTFTFlowClass = cmbTftFlowClass.Text
            
        '@↓2013/11/27 (Wed) 19:55:20 T.Oide **************************************************
        '@    '@ｵｰﾀﾞ一覧が表示されている場合
        '@    If vsfOrderList.Row > 0 Then
        '@        '@最新取得
        '@        Call cmdLotList_Click
        '@    End If
        '@
        '@
        '@    '@ｸﾞﾘｯﾄﾞ使用可能の場合
        '@    If vsfOrderList.Enabled = True Then
        '@        '@次項目へﾌｫｰｶｽｾｯﾄ
        '@        Call pubSetFocus(vsfOrderList)
        '@    Else
        '@        Call pubSetFocus(cmdClose)
        '@    End If
        '@------------------------------------------------------------------------------------

            '@流動区分と機種は空でなないか
            If cmbTftFlowClass.Text <> vbNullString And _
                cmbTftProduct.Text <> vbNullString Then
                
                cmdLotList.Enabled = True

                '@最新取得
                Call cmdLotList_Click(cmdLotList, New EventArgs())
            Else
                '@ﾌｫｰｶｽ移動
                If ActiveControl Is cmbTftFlowClass Then
                    Call pubSetFocus(cmdClose)
                End If
            End If
        '@↑2013/11/27 (Wed) 19:55:20 T.Oide **************************************************

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "cmbTftFlowClass_Validate"       '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optThrowUser_Click
    '機　能：ｴﾝﾄﾘ選択機能
    '引　数：Index：0:投入ｴﾝﾄﾘ/1:ﾕｰｻﾞｰﾌﾟﾛｾｽ
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 08:46:04 S.Deguchi
    '更新日：2013/11/28 (Thu) 17:14:21 T.Oide
    '備　考：
    '　　　：2007/12/26 (Wed) 15:50:25 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2009/02/23 (Mon) 14:14:23 N.Kojima     ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連処理削除、ﾁｯﾌﾟ電特区分(限定工程設定)関連処理追加。(案件№3402)
    '　　　：2013/11/28 (Thu) 17:14:21 T.Oide       R11-01 GNS対応
    Private Sub optThrowUser_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optThrowUser0.Click, optThrowUser1.Click

        Dim Index   As Integer      'NSYS ｲﾝﾃﾞｯｸｽ
        
        Try

            ' ｲﾝﾃﾞｯｸｽ設定
            If sender Is optThrowUser0 Then
                Index = CMlngOptIndexThrow
            Else If sender Is optThrowUser1 Then
                Index = CMlngOptIndexUser
            Else
                Throw(New IndexOutOfRangeException())
            End If

            '@選択されたIndexにより活性化するｴﾝﾄﾘ項目を変更する
            Select Case Index
                
                '@機種ｴﾝﾄﾘが選択されている場合
                Case CMlngOptIndexThrow
                    
                    '@機種ｴﾝﾄﾘIDﾗﾍﾞﾙを活性化
                    lblEntryID.Enabled = True
                
                    '@機種ｴﾝﾄﾘﾗﾍﾞﾙを活性化
                    lblEntry.Enabled = True
                    
                    '@機種ｴﾝﾄﾘﾎﾞﾀﾝを活性化
                    cmdEntry.Enabled = True
                    
        '@↓2009/02/23 (Mon) 14:35:42 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。
              
        '            '@ﾁｯﾌﾟ電特工程有無判定ﾌﾗｸﾞの初期化
        '            If pblnCdenProcJudgeFlag = True Then
        '                '@ﾁｯﾌﾟ電特ｺﾝﾎﾞを有効にする
        '                cmbChipElectric.Enabled = True
        '            Else
        '                '@ﾁｯﾌﾟ電特ｺﾝﾎﾞを無効にする
        '                cmbChipElectric.Text = vbNullString
        '                cmbChipElectric.Enabled = False
        '            End If

        '@↑2009/02/23 (Mon) 14:35:42 N.Kojima **************************************************
                    
                    '@ﾕｰｻﾞｰﾌﾟﾛｾｽID欄を非活性化
                    txtUserEntry.Enabled = False
                    
                    '@ﾕｰｻﾞｰﾌﾟﾛｾｽID欄のﾊﾞｯｸｶﾗｰを灰色に
                    txtUserEntry.BackColor = SystemColors.ControlLight
                    
                    '@ﾕｰｻﾞｰﾌﾟﾛｾｽ名ﾗﾍﾞﾙを非活性化
                    lblUserEntry.Enabled = False
                    
                    '@ﾕｰｻﾞｰﾌﾟﾛｾｽﾎﾞﾀﾝを非活性化
                    cmdUserEntry.Enabled = False
                
                '@ﾕｰｻﾞｰﾌﾟﾛｾｽが選択されている場合
                Case CMlngOptIndexUser
            
                    '@機種ｴﾝﾄﾘIDﾗﾍﾞﾙを非活性化
                    lblEntryID.Enabled = False
                
                    '@機種ｴﾝﾄﾘﾗﾍﾞﾙを非活性化
                    lblEntry.Enabled = False
                    
                    '@機種ｴﾝﾄﾘﾎﾞﾀﾝを非活性化
                    cmdEntry.Enabled = False
                    
                    '@ﾁｯﾌﾟ電特ｺﾝﾎﾞを初期化し、無効にする
                    cmbChipElectric.Text = vbNullString
                    cmbChipElectric.Enabled = False
                    
                    '@ﾕｰｻﾞｰﾌﾟﾛｾｽID欄を活性化
                    txtUserEntry.Enabled = True
                    
                    '@ﾕｰｻﾞｰﾌﾟﾛｾｽID欄のﾊﾞｯｸｶﾗｰを白に
                    txtUserEntry.BackColor = Color.White
                    
                    '@ﾕｰｻﾞｰﾌﾟﾛｾｽ名ﾗﾍﾞﾙを活性化
                    lblUserEntry.Enabled = True
                    
                    '@ﾕｰｻﾞｰﾌﾟﾛｾｽﾎﾞﾀﾝを活性化
                    cmdUserEntry.Enabled = True
                    
            End Select

        '@↓2013/11/28 (Thu) 17:13:53 T.Oide **************************************************
        '@    '@確定ﾎﾞﾀﾝの活性化ﾁｪｯｸを行う
        '@    lblnAns = prvblnLotmake_Chk
        '@    '@結果判定
        '@    If lblnAns = True Then
        '@        '@投入確定ﾎﾞﾀﾝの活性化
        '@        cmdLotMake.Enabled = True
        '@    Else
        '@        '@投入確定ﾎﾞﾀﾝの非活性化
        '@        cmdLotMake.Enabled = False
        '@    End If
        '@-------------------------------------------------------------------------------------

            '@確定ﾎﾞﾀﾝ、送品先変更ﾎﾞﾀﾝの有効/無効制御
            Call prvButtonCtrl()
            
        '@↑2013/11/28 (Thu) 17:13:53 T.Oide **************************************************

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optThrowUser_Click"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProduct_Change
    '機　能：投入機種変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 12:10:02 S.Deguchi
    '更新日：2004/07/27 (Tue) 12:10:02
    '備　考：
    Private Sub cmbProduct_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProduct.Change

        Try

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString

            '@投入機種を変更する場合には,画面情報の初期化を行う
            Call prvfrmxxEN00Q0_Init(False)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbProduct_Change"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProduct_CloseUp
    '機　能：投入機種のCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 12:07:31 S.Deguchi
    '更新日：2004/10/01 (Fri) 12:14:55 H.Wajima
    '備　考：
    '　　　：2004/10/01 (Fri) 12:14:55 H.Wajima     空白判定追加
    Private Sub cmbProduct_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProduct.CloseUp

        Try

            '@項目の空白判定
            If cmbProduct.Text <> vbNullString Then
            '@空白以外の場合
                '@投入機種のValidate処理へ
                RemoveHandler cmbProduct.Validating, AddressOf cmbProduct_Validate
                Call cmbProduct_Validate(cmbProduct, New CancelEventArgs(True))
                AddHandler cmbProduct.Validating, AddressOf cmbProduct_Validate
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbProduct_CloseUp"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProduct_Validate
    '機　能：投入機種のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 12:07:34 S.Deguchi
    '更新日：2016/02/09 (Tue) 00:05:39 H.Hayashi
    '備　考：
    '　　　：2004/10/01 (Fri) 12:13:53 H.Wajima     退避領域と同じ場合のExitSub追加
    '　　　：2004/10/19 (Tue) 10:44:56 Y.Yamagishi  ﾒｯｾｰｼﾞﾎﾞｯｸｽの0件表示をしない(不具合改善対応№87)
    '　　　：2007/12/25 (Tue) 17:32:50 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2008/07/07 (Mon) 12:00:00 S.Ochiai     欠損ﾁｯﾌﾟ表示対応(No.03046)及びSource整備
    '　　　：2009/02/23 (Mon) 14:14:23 N.Kojima     ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連処理削除、ﾁｯﾌﾟ電特区分(限定工程設定)関連処理追加。(案件№3402)
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub cmbProduct_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbProduct.Validating

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrClassDivision       As String               'ClassDivision設定
        Dim ltypEntryList           As List(Of EntryList)   'ﾏｽﾀ工順取得構造体
        Dim llngEntryListCnt        As Integer              'ﾏｽﾀ工順取得件数
        Dim ltypInvAcptLotListReq   As invAcptLotListReq    '在庫ﾛｯﾄ一覧要求格納構造体
        Dim ltypInvAcptLotListAns   As InvAcptLotListAns    '在庫ﾛｯﾄ一覧応答格納構造体
        Dim llngInvAcptLotListCnt   As Integer              '在庫ﾛｯﾄ一覧応答ﾃﾞｰﾀ数
        Dim lblnNextCtrl            As Boolean              'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If ActiveControl Is cmbProduct Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "cmbProduct_Validate"
            
            '@投入機種が選択されている場合のみ処理を行う
            If cmbProduct.Text <> vbNullString Then
                
                '@退避領域と同じ場合には処理終了(ﾌｫｰｶｽ遷移)
                If mstrPDID = cmbProduct.Text Then
                    '@次項目へﾌｫｰｶｽｾｯﾄ
                    If cmbFlowClass.Enabled = True Then
                        '@種別Comboへｾｯﾄﾌｫｰｶｽ
                        If lblnNextCtrl Then
                            Call pubSetFocus(cmbFlowClass)
                        End If
                    Else
                        '@閉じるﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                        If lblnNextCtrl Then
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                    Exit Sub
                End If
                        
                '@値取得(ﾊﾞｯｸｶﾗｰ値)
                cmbProduct.ValueCol = CMlngCmbGetCol5
                
                If Me.ActiveControl Is cmbProduct Then
                    ' NSYS フォーカスがある場合
                    Me.ActiveControl = Nothing '一旦フォーカスを外す
                    If cmbProduct.Value <> vbNullString Then
                        '@ﾊﾞｯｸｶﾗｰ反映
                        cmbProduct.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(cmbProduct.Value))
                    Else
                        cmbProduct.BackColor = Color.White
                    End If
                    Me.ActiveControl = cmbProduct 'フォーカスを戻す
                    pubSetFocus(cmbProduct)
                Else
                    If cmbProduct.Value <> vbNullString Then
                        '@ﾊﾞｯｸｶﾗｰ反映
                        cmbProduct.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(cmbProduct.Value))
                    Else
                        cmbProduct.BackColor = Color.White
                    End If
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, lstrEventName)
            
                '@投入流動区分一覧取得
                lstrClassDivision = CPstrCD04                               'ClassDivision 04:機種指定
                lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                                mtypDivisionList, _
                                                mlngDivisionListCnt, _
                                                pstrSBID, _
                                                lstrClassDivision, _
                                                cmbProduct.Text)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)

                    Exit Sub
                End If
            
                '@機種ｴﾝﾄﾘ取得
                lstrClassDivision = CPstrCD07                               'ClassDivision 07:ｴﾝﾄﾘIDの適用日が最新のものを検索する
                lblnAns = pubblnmasPdEntryList_Sel(CMstrmas_pdentrylistVer, _
                                                   cmbProduct.Text, _
                                                   ltypEntryList, _
                                                   llngEntryListCnt, _
                                                   pstrSBID, lstrClassDivision)
                                                   
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
                
                    Exit Sub
                End If
                
                '@TFT基板機種(親機種ID)をﾗﾍﾞﾙにｾｯﾄ
                With cmbProduct
                    .ValueCol = CMlngCmbGetCol1
                    lblTFTProduct.Text = .Value
                End With
            
                '@TFT基板在庫一覧構造体の初期化
                ltypInvAcptLotListReq.typPdList = New List(Of PDList)()
                ltypInvAcptLotListReq.typFlowClassList = New List(Of FlowClassList)()
                
                '@親機種IDが空欄の場合には,処理を停止する
                If lblTFTProduct.Text = vbNullString Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000S)
                    
                    '@publngMsgBoxInfo("選択された組立機種に対するTFT基板機種が存在しません。設定を見直してください。")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
            
                '@要求格納構造体へ格納
                With ltypInvAcptLotListReq
                    .strMsgVer = CMstrinv_acptlotlistVer                                'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                    .strSbID = pstrSBID                                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                    .strClassDivision = CPstrCD0V                                       '0V:組立投入可能ﾛｯﾄ(試作/実験)
        '@↓2016/01/30 (Sat) 12:13:37 H.Hayashi **************************************************
                    .strAssemblePdId = cmbProduct.Text                                  '組立投入機種
        '            .strAssemblePdId = mstrPdID
        '@↑2016/01/30 (Sat) 12:13:37 H.Hayashi **************************************************
                    .lngPdCnt = 1                                                       '機種ｶｳﾝﾄ数(=1)単独選択
                    '@機種区分構造体作成
                    Dim tmpPDList As PDList = New PDList()
                    tmpPDList.strPdId = lblTFTProduct.Text                              '親機種ID
                    .typPdList.Add(tmpPDList)

					'kkw 組立投入WF枚数変更
					'(PR/ES)以外を取得する
					' 種別カウント数はリストから自動で取るほうが安全
					.typFlowClassList = New List(Of FlowClassList) From {
						New FlowClassList With {.strFlowClass = "TS"},
						New FlowClassList With {.strFlowClass = "WS"},
						New FlowClassList With {.strFlowClass = "QU"},
						New FlowClassList With {.strFlowClass = "GG"},
						New FlowClassList With {.strFlowClass = "SY"},
						New FlowClassList With {.strFlowClass = "ZZ"}
					}

					.lngFlowClassCnt = .typFlowClassList.Count

                   '.lngFlowClassCnt = 0                                                '種別ｶｳﾝﾄ数(=0)
                End With
                
                '@TFT基板在庫一覧情報取得処理
                lblnAns = prvblnInvAcptLotList_Sel(ltypInvAcptLotListReq, ltypInvAcptLotListAns, llngInvAcptLotListCnt)
                '@結果判定
                If lblnAns = True Then
                    '@成功した場合には取得したTFT基板在庫一覧を表記しているのでここでは記載しない
                    
                Else
                    '@最新取得ﾎﾞﾀﾝ非活性化
                    cmdLotList.Enabled = False

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)

                    '@TFT基板機種が空欄の場合にｴﾗｰﾒｯｾｰｼﾞを表示する
                    If lblTFTProduct.Text = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000S)
                        
                        '@publngMsgBoxInfo("選択された組立機種に対するTFT基板機種が存在しません。設定を見直してください。")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                    
                    Exit Sub
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)
                
                '@該当件数が0件の場合には,0件ﾒｯｾｰｼﾞを表示する
                If llngInvAcptLotListCnt = 0 Then
                    '@退避領域へ値をｾｯﾄ
                    mstrPDID = cmbProduct.Text
                    
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmbProduct)
                    End If
                Else
                    '@種別表示処理
                    Call prvcmbDivisionList_Disp()
                    
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの選択を機種ｴﾝﾄﾘに設定する
                    optThrowUser0.Checked = True
                    
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝを活性化する
                    optThrowUser0.Enabled = True
                    optThrowUser1.Enabled = True

                    '@ﾕｰｻﾞｰﾌﾟﾛｾｽﾎﾞﾀﾝを活性化する
                    cmdUserEntry.Enabled = True

                    '@機種ｴﾝﾄﾘが取得できた場合のみ(最新の機種ｴﾝﾄﾘ情報が1件返ってくる)
                    If llngEntryListCnt <> 0 Then
                    
                        '@ｴﾝﾄﾘID表示処理
                        lblEntryID.Text = ltypEntryList(llngEntryListCnt-1).strEntryID
                    
                        '@ﾏｽﾀ工順表示処理(最新の機種ｴﾝﾄﾘ情報が1件返ってくる)
                        lblEntry.Text = ltypEntryList(llngEntryListCnt-1).strEntryName
                        
                        '@機種ｴﾝﾄﾘﾎﾞﾀﾝを使用可能にする
                        cmdEntry.Enabled = True
                    End If
                    
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝのValue設定による処理を行う為,ｸﾘｯｸ処理を呼ぶ
                    Call optThrowUser_Click(optThrowUser0, New EventArgs())
                    
        '@↓2009/02/23 (Mon) 14:36:02 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるのでｺｰﾄﾞは残しておく。

        '            '@下記の条件を満たす場合、「ﾁｯﾌﾟ電特」ｺﾝﾎﾞを有効にする
        '            '@　①ﾏｽﾀ工順が設定されている場合
        '            '@　②mas_.pdentrylistの応答、"CDEN_FLAG=1"の場合
        '            '@　③選択機種がTFT基板ﾛｯﾄ機種の場合
        '            If optThrowUser(CMlngOptIndexThrow).Value = True And _
        '                ltypEntryList(llngEntryListCnt).strCdenFlag = CPstrOne Then
        '
        '                '@投入機種がTFT基板か
        '                For llngCnt = 1 To mlngProductListCnt
        '                    With mtypProductList(llngCnt)
        '                        '@選択機種で、かつTFT基板ﾛｯﾄ機種か
        '                        If .strProductID = cmbProduct.Text And _
        '                            (.strCfFlag = CPstrZero And .strLpFlag = CPstrZero) Then
        '
        '                            '@ﾁｯﾌﾟ電特ｺﾝﾎﾞを有効にする
        '                            cmbChipElectric.Enabled = True
        '                            '@ﾁｯﾌﾟ電特ｺﾝﾎﾞ制御ﾌﾗｸﾞに"True:有効"をｾｯﾄ
        '                            pblnCdenProcJudgeFlag = True
        '                            Exit For
        '                        Else
        '                            '@ﾁｯﾌﾟ電特ｺﾝﾎﾞを無効にする
        '                            cmbChipElectric.Enabled = False
        '                            '@ﾁｯﾌﾟ電特ｺﾝﾎﾞ制御ﾌﾗｸﾞに"False:無効"をｾｯﾄ
        '                            pblnCdenProcJudgeFlag = False
        '                        End If
        '                    End With
        '                Next llngCnt
        '            Else
        '                '@ﾏｽﾀ工順が選択されていない、又はmas_.pdentrylistの応答、"CDEN_FLAG=0"の場合
        '
        '                '@ﾁｯﾌﾟ電特ｺﾝﾎﾞを無効にする
        '                cmbChipElectric.Enabled = False
        '                '@ﾁｯﾌﾟ電特ｺﾝﾎﾞ制御ﾌﾗｸﾞに"False:無効"をｾｯﾄ
        '                pblnCdenProcJudgeFlag = False
        '            End If

        '@↑2009/02/23 (Mon) 14:36:02 N.Kojima **************************************************
                    
                    '@優先度を使用可能にする
                    Call prvcmbPrioList_Disp()
                    
                    '@作業ﾒﾓを使用可能にする
                    txtWorkMemo.Enabled = True
                    
                    '@最新取得ﾎﾞﾀﾝ活性化
                    cmdLotList.Enabled = True
                    
                    '@全部取消ﾎﾞﾀﾝを活性化
                    cmdClear.Enabled = True
                
                    '@退避領域へ値をｾｯﾄ
                    mstrPDID = cmbProduct.Text
                    
                    '@次項目へﾌｫｰｶｽｾｯﾄ
                    If cmbFlowClass.Enabled = True Then
                        '@種別Comboへｾｯﾄﾌｫｰｶｽ
                        If lblnNextCtrl Then
                            Call pubSetFocus(cmbFlowClass)
                        End If
                    Else
                        '@閉じるﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                        If lblnNextCtrl Then
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If
            
            Else
                '@空Enterの場合
                
                '@優先度へﾌｫｰｶｽｾｯﾄ
                If cmbPrioSel.Enabled = True Then
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmbPrioSel)
                    End If
                Else
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbProduct_Validate"    '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbFlowClass_CloseUp
    '機　能：投入種別のCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 13:04:27 S.Deguchi
    '更新日：2004/07/27 (Tue) 13:04:27
    '備　考：
    Private Sub cmbFlowClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.CloseUp

        Try
 
            '@投入種別のValidate処理へ
            RemoveHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_Validate
            Call cmbFlowClass_Validate(cmbFlowClass, New CancelEventArgs(True))
            AddHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_Validate

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbFlowClass_CloseUp"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbFlowClass_Validate
    '機　能：投入種別のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 13:04:29 S.Deguchi
    '更新日：2013/11/28 (Thu) 17:15:51 T.Oide
    '備　考：
    '　　　：2007/12/27 (Thu) 11:09:48 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2013/11/28 (Thu) 17:14:21 T.Oide       R11-01 GNS対応
    Private Sub cmbFlowClass_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbFlowClass.Validating

        Dim lblnNextCtrl As Boolean      'NSYS Focus設定フラグ

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If ActiveControl Is cmbFlowClass Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If
            
            If cmbFlowClass.Text = vbNullString Then
                '@種別が空欄の場合にはﾌｫｰｶｽはそのまま
                Exit Sub
            Else
                '@ﾁｯﾌﾟ電特が有効か
                If cmbChipElectric.Enabled = True Then
                    '@ﾁｯﾌﾟ電特にﾌｫｰｶｽをｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmbChipElectric)
                    End If
                Else
                    If optThrowUser0.Checked = True Then
                        '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ：機種ｴﾝﾄﾘが活性化している場合にはｵﾌﾟｼｮﾝﾎﾞﾀﾝ：機種ｴﾝﾄﾘにﾌｫｰｶｽをｾｯﾄ
                        If lblnNextCtrl Then
                            Call pubSetFocus(optThrowUser0)
                        End If
                    Else
                        '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ：ﾕｰｻﾞｰﾌﾟﾛｾｽが活性化している場合にはｵﾌﾟｼｮﾝﾎﾞﾀﾝ：ﾕｰｻﾞｰﾌﾟﾛｾｽにﾌｫｰｶｽをｾｯﾄ
                        If lblnNextCtrl Then
                            Call pubSetFocus(optThrowUser1)
                        End If
                    End If
                End If
            
        '@↓2013/11/28 (Thu) 17:15:06 T.Oide **************************************************
        '@        '@確定ﾎﾞﾀﾝの活性化ﾁｪｯｸを行う
        '@        lblnAns = prvblnLotmake_Chk
        '@        '@結果判定
        '@        If lblnAns = True Then
        '@            '@投入確定ﾎﾞﾀﾝの活性化
        '@            cmdLotMake.Enabled = True
        '@        Else
        '@            '@投入確定ﾎﾞﾀﾝの非活性化
        '@            cmdLotMake.Enabled = False
        '@        End If
        '@-------------------------------------------------------------------------------------
                '@確定ﾎﾞﾀﾝ、送品先変更ﾎﾞﾀﾝの有効/無効制御
                Call prvButtonCtrl()
                
        '@↑2013/11/28 (Thu) 17:15:06 T.Oide **************************************************
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbFlowClass_Validate"      '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbChipElectric_CloseUp
    '機　能：ﾁｯﾌﾟ電特のCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/12/25 (Tue) 15:15:28 N.Kojima
    '更新日：2007/12/25 (Tue) 15:15:28
    '備　考：
    Private Sub cmbChipElectric_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbChipElectric.CloseUp

        Try

            '@ﾁｯﾌﾟ電特のValidate処理へ
            RemoveHandler cmbChipElectric.Validating, AddressOf cmbChipElectric_Validate
            Call cmbChipElectric_Validate(cmbChipElectric, New CancelEventArgs(True))
            AddHandler cmbChipElectric.Validating, AddressOf cmbChipElectric_Validate

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbChipElectric_CloseUp"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbChipElectric_Validate
    '機　能：ﾁｯﾌﾟ電特のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/12/25 (Tue) 15:16:41 N.Kojima
    '更新日：2013/11/28 (Thu) 17:16:37 T.Oide
    '備　考：2013/11/28 (Thu) 17:14:21 T.Oide       R11-01 GNS対応
    Private Sub cmbChipElectric_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbChipElectric.Validating

        Dim lblnNextCtrl As Boolean      'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If ActiveControl Is cmbChipElectric Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If
            
            '@項目が選択されているか
            If cmbChipElectric.Text = vbNullString Then
                '@空欄の場合にはﾌｫｰｶｽはそのまま
                Exit Sub
            Else
                '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝが有効か
                If optThrowUser0.Checked = True Then
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ："機種ｴﾝﾄﾘ"が活性化している場合にはｵﾌﾟｼｮﾝﾎﾞﾀﾝ：機種ｴﾝﾄﾘにﾌｫｰｶｽをｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(optThrowUser0)
                    End If
                Else
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ："ﾕｰｻﾞｰﾌﾟﾛｾｽ"が活性化している場合にはｵﾌﾟｼｮﾝﾎﾞﾀﾝ：ﾕｰｻﾞｰﾌﾟﾛｾｽにﾌｫｰｶｽをｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(optThrowUser1)
                    End If
                End If
            
        '@↓2013/11/28 (Thu) 17:16:19 T.Oide **************************************************
        '@        '@確定ﾎﾞﾀﾝの活性化ﾁｪｯｸを行う
        '@        lblnAns = prvblnLotmake_Chk
        '@        '@結果判定
        '@        If lblnAns = True Then
        '@            '@投入確定ﾎﾞﾀﾝの活性化
        '@            cmdLotMake.Enabled = True
        '@        Else
        '@            '@投入確定ﾎﾞﾀﾝの非活性化
        '@            cmdLotMake.Enabled = False
        '@        End If
        '@-------------------------------------------------------------------------------------

                '@確定ﾎﾞﾀﾝ、送品先変更ﾎﾞﾀﾝの有効/無効制御
                Call prvButtonCtrl()
            
        '@↑2013/11/28 (Thu) 17:16:19 T.Oide **************************************************

            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbChipElectric_Validate"   '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdEntry_Click
    '機　能：機種ｴﾝﾄﾘ一覧を表示する処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 12:02:02 S.Deguchi
    '更新日：2013/11/28 (Thu) 17:17:29 T.Oide
    '備　考：
    '　　　：2008/01/22 (Tue) 15:36:20 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2009/02/23 (Mon) 14:14:23 N.Kojima     ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連処理削除、ﾁｯﾌﾟ電特区分(限定工程設定)関連処理追加。(案件№3402)
    '　　　：2013/11/28 (Thu) 17:14:21 T.Oide       R11-01 GNS対応
    Private Sub cmdEntry_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEntry.Click

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

            '@使用するﾊﾟﾌﾞﾘｯｸ変数を初期化する
            pstrPDID = vbNullString                 'PD_ID
            pstrEntryID = vbNullString              'ｴﾝﾄﾘID
            pstrEntryName = vbNullString            'ｴﾝﾄﾘ名
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@機種IDの退避(ﾏｽﾀ工順取得用)
            pstrPDID = cmbProduct.Text
            
            '@ﾌｫｰﾑの起動区分を設定(機種ｴﾝﾄﾘ指定)
            plngfrmxxCM00F0Kbn = CMlng00Q0PDALLProc
            
            '機種ｴﾝﾄﾘ一覧画面をﾛｰﾄﾞ
            frmxxCM00F0.Instance = New frmxxCM00F0()
            
            '@ｻﾌﾞﾌｫｰﾑの名称設定
            frmxxCM00F0.Instance.Text = CPstrSubDispTitlePDEntryList
           
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00F0.Instance = Nothing
                Exit Sub
            End If

            '@機種ｴﾝﾄﾘ一覧表示
            frmxxCM00F0.Instance.ShowDialog(Me)
            frmxxCM00F0.Instance = Nothing
            
            If pstrEntryName <> vbNullString Then
            '@機種ｴﾝﾄﾘが選択されている場合
                '@機種ｴﾝﾄﾘIDをｾｯﾄ
                lblEntryID.Text = pstrEntryID
                
                '@機種ｴﾝﾄﾘ名をｾｯﾄ
                lblEntry.Text = pstrEntryName
            Else
            '@機種ｴﾝﾄﾘが選択されていない(閉じる処理)場合は変更しない
                '@機種ｴﾝﾄﾘIDをｾｯﾄ
                lblEntryID.Text = lblEntryID.Text
                
                '@機種ｴﾝﾄﾘ名をｾｯﾄ
                lblEntry.Text = lblEntry.Text
            End If
            
        '@↓2009/02/23 (Mon) 14:36:36 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。

        '    '@ﾁｯﾌﾟ電特工程有無判定ﾌﾗｸﾞの初期化
        '    If pblnCdenProcJudgeFlag = True Then
        '        '@ﾁｯﾌﾟ電特ｺﾝﾎﾞを有効にする
        '        cmbChipElectric.Enabled = True
        '    Else
        '        '@ﾁｯﾌﾟ電特ｺﾝﾎﾞを無効にする
        '        cmbChipElectric.Text = vbNullString
        '        cmbChipElectric.Enabled = False
        '    End If

        '@↑2009/02/23 (Mon) 14:36:36 N.Kojima **************************************************
            
        '@↓2013/11/28 (Thu) 17:17:00 T.Oide **************************************************
        '@    '@確定ﾎﾞﾀﾝの活性化ﾁｪｯｸを行う
        '@    lblnAns = prvblnLotmake_Chk
        '@    '@結果判定
        '@    If lblnAns = True Then
        '@        '@投入確定ﾎﾞﾀﾝの活性化
        '@        cmdLotMake.Enabled = True
        '@    Else
        '@        '@投入確定ﾎﾞﾀﾝの非活性化
        '@        cmdLotMake.Enabled = False
        '@    End If
        '@-------------------------------------------------------------------------------------

            '@確定ﾎﾞﾀﾝ、送品先変更ﾎﾞﾀﾝの有効/無効制御
            Call prvButtonCtrl()
            
        '@↑2013/11/28 (Thu) 17:17:00 T.Oide **************************************************
            
            '@次項目ﾌｫｰｶｽｾｯﾄ
            SendKeys.SendWait(CPstrSendKeysTab)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdEntry_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtUserEntry_Change
    '機　能：ﾕｰｻﾞｰﾌﾟﾛｾｽID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/29 (Thu) 10:35:19 S.Deguchi
    '更新日：2013/11/28 (Thu) 17:18:06 T.Oide
    '備　考：2013/11/28 (Thu) 17:14:21 T.Oide       R11-01 GNS対応
    Private Sub txtUserEntry_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtUserEntry.Change

        Try
            
            '@ﾕｰｻﾞｰﾌﾟﾛｾｽIDが変更された場合は,ﾕｰｻﾞｰﾌﾟﾛｾｽ名称は空欄にする
            lblUserEntry.Text = vbNullString
            
        '@↓2013/11/28 (Thu) 17:17:49 T.Oide **************************************************
        '@    '@確定ﾎﾞﾀﾝの活性化ﾁｪｯｸを行う
        '@    lblnAns = prvblnLotmake_Chk
        '@    '@結果判定
        '@    If lblnAns = True Then
        '@        '@投入確定ﾎﾞﾀﾝの活性化
        '@        cmdLotMake.Enabled = True
        '@    Else
        '@        '@投入確定ﾎﾞﾀﾝの非活性化
        '@        cmdLotMake.Enabled = False
        '@    End If
        '@-------------------------------------------------------------------------------------

            '@確定ﾎﾞﾀﾝ、送品先変更ﾎﾞﾀﾝの有効/無効制御
            Call prvButtonCtrl()
            
        '@↑2013/11/28 (Thu) 17:17:49 T.Oide **************************************************
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtUserEntry_Change"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Sub

    '関数名：txtUserEntry_Validate
    '機　能：ﾕｰｻﾞｰﾌﾟﾛｾｽIDを入力後,ﾕｰｻﾞｰﾌﾟﾛｾｽ名称を取得する処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 20:37:37 S.Deguchi
    '更新日：2013/11/28 (Thu) 17:18:47 T.Oide
    '備　考：
    '　　　：2004/10/19 (Tue) 10:44:32 Y.Yamagishi　ﾒｯｾｰｼﾞﾎﾞｯｸｽの0件表示をしない(不具合改善対応№87)
    '　　　：2005/06/22 (Wed) 15:56:23 S.Deguchi    ﾕｰｻﾞｰﾌﾟﾛｾｽ処理を修正(該当するﾌﾟﾛｾｽが見当たらない場合,表示するﾒｯｾｰｼﾞ)
    '　　　：2013/11/28 (Thu) 17:14:21 T.Oide       R11-01 GNS対応
    Private Sub txtUserEntry_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtUserEntry.Validating

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypEntryList       As List(Of EntryList)   'ﾕｰｻﾞｰﾌﾟﾛｾｽ一覧格納用
        Dim llngEntryListCnt    As Integer              'ﾕｰｻﾞｰﾌﾟﾛｾｽ一覧格納数
        Dim llngCnt             As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "txtUserEntry_Validate"
            
            '@ﾕｰｻﾞｰﾌﾟﾛｾｽIDが空欄以外の場合
            If txtUserEntry.Text <> vbNullString Then
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, lstrEventName)
                
                '@ﾕｰｻﾞｰﾌﾟﾛｾｽ取得
                lblnAns = pubblnLotSppdentrylist_Sel(CMstrlot_sppdentrylistVer, _
                                                     pstrSBID, _
                                                     ltypEntryList, _
                                                     llngEntryListCnt)
                '@結果判定
                If lblnAns = True Then
                    '@取得したﾕｰｻﾞｰﾌﾟﾛｾｽから入力されたIDを検索する
                    If llngEntryListCnt > 0 Then
                    '@ﾕｰｻﾞｰﾌﾟﾛｾｽが0件以上の場合処理
                        For llngCnt = 0 To llngEntryListCnt - 1
                            With ltypEntryList(llngCnt)
                                '@入力されたIDと一致するIDが取得した構造体の中にある場合
                                If txtUserEntry.Text = .strEntryID Then
                                    '@ﾗﾍﾞﾙにﾌﾟﾛｾｽ名称を表記する
                                    lblUserEntry.Text = .strEntryName
                                    
                                    '@処理を抜ける
                                    Exit For
                                Else
                                    '@入力されたIDと一致するIDが取得した構造体の中にない場合は空欄設定
                                    lblUserEntry.Text = vbNullString
                                End If
                            End With
                        Next llngCnt
                        
                        '@ﾕｰｻﾞｰﾌﾟﾛｾｽの内容による処理判別
                        If lblUserEntry.Text = vbNullString Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, lstrEventName)
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005Z, txtUserEntry.Text)
            
                            '@<TRM5ZW>$$ユーザープロセス[%1]は存在しません。設定を見直してください。
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@空欄設定
                            lblUserEntry.Text = vbNullString
                            
                            '@ﾌｫｰｶｽそのまま
                            If Me.ActiveControl.Name = tabSelect.Name Then
                                mblnTabSelectEnabled = False
                                sender.Focus()
                            Else
	                            e.Cancel = True
                            End If
                            
                            Exit Sub
                        End If
                    Else
                    '@ﾕｰｻﾞｰﾌﾟﾛｾｽが0件の場合処理
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, lstrEventName)
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005Z, txtUserEntry.Text)

                        '@<TRM5ZW>$$ユーザープロセス[%1]は存在しません。設定を見直してください。
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                        '@空欄設定
                        lblUserEntry.Text = vbNullString
                    
                        '@ﾌｫｰｶｽそのまま
                        If Me.ActiveControl.Name = tabSelect.Name Then
                            mblnTabSelectEnabled = False
                            sender.Focus()
                        Else
	                        e.Cancel = True
                        End If
                        
                        Exit Sub
                    End If
                                
        '@↓2013/11/28 (Thu) 17:18:23 T.Oide **************************************************
        '@            '@確定ﾎﾞﾀﾝの活性化ﾁｪｯｸを行う
        '@            lblnAns = prvblnLotmake_Chk
        '@            '@結果判定
        '@            If lblnAns = True Then
        '@                '@投入確定ﾎﾞﾀﾝの活性化
        '@                cmdLotMake.Enabled = True
        '@            Else
        '@                '@投入確定ﾎﾞﾀﾝの非活性化
        '@                cmdLotMake.Enabled = False
        '@            End If
        '@-------------------------------------------------------------------------------------

                    '@確定ﾎﾞﾀﾝ、送品先変更ﾎﾞﾀﾝの有効/無効制御
                    Call prvButtonCtrl()
            
        '@↑2013/11/28 (Thu) 17:18:23 T.Oide **************************************************
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)

                    Exit Sub
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtUserEntry_Validate"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUserEntry_Click
    '機　能：ﾕｰｻﾞｰﾌﾟﾛｾｽ一覧を表示する処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 13:42:57 S.Deguchi
    '更新日：2013/11/28 (Thu) 17:19:21 T.Oide
    '備　考：2013/11/28 (Thu) 17:14:21 T.Oide       R11-01 GNS対応
    Private Sub cmdUserEntry_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUserEntry.Click

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
            
            '@使用するﾊﾟﾌﾞﾘｯｸ変数を初期化する
            pstrEntryID = vbNullString              'ｴﾝﾄﾘID
            pstrEntryName = vbNullString            'ｴﾝﾄﾘ名
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@ﾌｫｰﾑの起動区分を設定(ﾕｰｻﾞｰﾌﾟﾛｾｽ指定)
            plngfrmxxCM00F0Kbn = CMlng00Q0UserProc
            
            'ﾕｰｻﾞｰﾌﾟﾛｾｽ一覧画面をﾛｰﾄﾞ
            frmxxCM00F0.Instance = New frmxxCM00F0()
            
            '@ｻﾌﾞﾌｫｰﾑの名称設定
            frmxxCM00F0.Instance.Text = CPstrSubDispTitleUserPrcList
           
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00F0.Instance = Nothing
                
                Exit Sub
            End If

            '@ﾕｰｻﾞｰﾌﾟﾛｾｽ一覧表示
            frmxxCM00F0.Instance.ShowDialog(Me)
            frmxxCM00F0.Instance = Nothing
            
            If pstrEntryName <> vbNullString Then
            '@ﾕｰｻﾞｰﾌﾟﾛｾｽが選択されている場合
                '@ﾕｰｻﾞｰﾌﾟﾛｾｽIDをｾｯﾄ
                txtUserEntry.Text = pstrEntryID
                
                '@ﾕｰｻﾞｰﾌﾟﾛｾｽ名をｾｯﾄ
                lblUserEntry.Text = pstrEntryName
            Else
            '@ﾕｰｻﾞｰﾌﾟﾛｾｽが選択されていない(閉じる処理)場合
                '@ﾕｰｻﾞｰﾌﾟﾛｾｽIDをｾｯﾄ
                txtUserEntry.Text = vbNullString
                
                '@ﾕｰｻﾞｰﾌﾟﾛｾｽ名をｾｯﾄ
                lblUserEntry.Text = vbNullString
            End If
            
        '@↓2013/11/28 (Thu) 17:19:05 T.Oide **************************************************
        '@    '@確定ﾎﾞﾀﾝの活性化ﾁｪｯｸを行う
        '@    lblnAns = prvblnLotmake_Chk
        '@    '@結果判定
        '@    If lblnAns = True Then
        '@        '@投入確定ﾎﾞﾀﾝの活性化
        '@        cmdLotMake.Enabled = True
        '@    Else
        '@        '@投入確定ﾎﾞﾀﾝの非活性化
        '@        cmdLotMake.Enabled = False
        '@    End If
        '@-------------------------------------------------------------------------------------

            '@確定ﾎﾞﾀﾝ、送品先変更ﾎﾞﾀﾝの有効/無効制御
            Call prvButtonCtrl()
            
        '@↑2013/11/28 (Thu) 17:19:05 T.Oide **************************************************
            
            '@ﾕｰｻﾞｰﾌﾟﾛｾｽにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtUserEntry)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdUserEntry_Click"     '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbPrioSel_CloseUp
    '機　能：優先度のCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 13:07:31 S.Deguchi
    '更新日：2004/07/27 (Tue) 13:07:31
    '備　考：
    Private Sub cmbPrioSel_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPrioSel.CloseUp

        Try
            '@優先度のValidate処理へ
            RemoveHandler cmbPrioSel.Validating, AddressOf cmbPrioSel_Validate
            Call cmbPrioSel_Validate(cmbPrioSel, New CancelEventArgs(True))
            AddHandler cmbPrioSel.Validating, AddressOf cmbPrioSel_Validate

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbPrioSel_CloseUp"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPrioSel_Validate
    '機　能：優先度のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 13:07:33 S.Deguchi
    '更新日：2013/11/28 (Thu) 17:20:02 T.Oide
    '備　考：
    '　　　：2008/06/11 (Wed) 12:46:04 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2013/11/28 (Thu) 17:14:21 T.Oide       R11-01 GNS対応
    Private Sub cmbPrioSel_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPrioSel.Validating
            
        Dim lblnNextCtrl As Boolean      'NSYS Focus設定フラグ
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If ActiveControl Is cmbPrioSel Then
                lblnNextCtrl  = True
            Else
                lblnNextCtrl  = False
            End If
            
        '@↓2013/11/28 (Thu) 17:19:40 T.Oide **************************************************
        '@    '@確定ﾎﾞﾀﾝの活性化ﾁｪｯｸを行う
        '@    lblnAns = prvblnLotmake_Chk
        '@    '@結果判定
        '@    If lblnAns = True Then
        '@        '@投入確定ﾎﾞﾀﾝの活性化
        '@        cmdLotMake.Enabled = True
        '@    Else
        '@        '@投入確定ﾎﾞﾀﾝの非活性化
        '@        cmdLotMake.Enabled = False
        '@    End If
        '@-------------------------------------------------------------------------------------

            '@確定ﾎﾞﾀﾝ、送品先変更ﾎﾞﾀﾝの有効/無効制御
            Call prvButtonCtrl()
            
        '@↑2013/11/28 (Thu) 17:19:40 T.Oide **************************************************
                
            '@ﾌｫｰｶｽ処理
            If cmdLotMake.Enabled = True Then
                '@確定ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If lblnNextCtrl Then
                    Call pubSetFocus(cmdLotMake)
                End If
            Else
                '@ﾛｯﾄ担当が有効か
                If cmbLotManager.Enabled = True Then
                    '@ﾛｯﾄ担当へﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmbLotManager)
                    End If
                Else
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            Exit Sub
                
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbPrioSel_Validate"    '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
                
        End Try
    End Sub

    '関数名：cmbLotManager_CloseUp
    '機　能：ﾛｯﾄ担当のCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/24 (Wed) 18:04:01 S.Deguchi
    '更新日：2008/06/11 (Wed) 12:46:28 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 12:46:28 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmbLotManager_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotManager.CloseUp

        Try
            '@Validate処理へ
            RemoveHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate
            Call cmbLotManager_Validate(cmbLotManager, New CancelEventArgs(False))
            AddHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbLotManager_CloseUp"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbLotManager_Validate
    '機　能：ﾛｯﾄ担当のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/24 (Wed) 18:04:03 S.Deguchi
    '更新日：2013/11/28 (Thu) 17:20:36 T.Oide
    '備　考：
    '　　　：2008/06/11 (Wed) 12:46:54 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2013/11/28 (Thu) 17:14:21 T.Oide       R11-01 GNS対応
    Private Sub cmbLotManager_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbLotManager.Validating

        Dim lblnNextCtrl As Boolean      'NSYS Focus設定フラグ

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If ActiveControl Is cmbLotManager Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If

            '@退避領域にﾛｯﾄ担当者IDを退避する
            With cmbLotManager
                .ValueCol = CMlngCmbDispCols
                mstrLotManagerID = .Value
            End With
            
        '@↓2013/11/28 (Thu) 17:20:21 T.Oide **************************************************
        '@    '@確定ﾎﾞﾀﾝの活性化ﾁｪｯｸを行う
        '@    lblnAns = prvblnLotmake_Chk
        '@    '@結果判定
        '@    If lblnAns = True Then
        '@        '@投入確定ﾎﾞﾀﾝの活性化
        '@        cmdLotMake.Enabled = True
        '@    Else
        '@        '@投入確定ﾎﾞﾀﾝの非活性化
        '@        cmdLotMake.Enabled = False
        '@    End If
        '@-------------------------------------------------------------------------------------

            '@確定ﾎﾞﾀﾝ、送品先変更ﾎﾞﾀﾝの有効/無効制御
            Call prvButtonCtrl()
            
        '@↑2013/11/28 (Thu) 17:20:21 T.Oide **************************************************
            
            '@ﾌｫｰｶｽｾｯﾄ
            If cmdLotMake.Enabled = True Then
                '@確定ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If lblnNextCtrl Then
                    Call pubSetFocus(cmdLotMake)
                End If
            Else
                '@ｺﾒﾝﾄ表示ﾎﾞﾀﾝの状況による処理分岐
                If cmdComments.Enabled = True Then
                    '@ｺﾒﾝﾄ表示ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmdComments)
                    End If
                Else
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbLotManager_Validate" '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：作業ﾒﾓ欄変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 12:05:07 N.Kojima
    '更新日：2004/07/27 (Tue) 12:05:07
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Dim llngNowByte         As Integer      'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                          llngNowByte, _
                                                          CPlngLotCommentsMaxByte)
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/12/01 (Thu) 13:10:57 S.Deguchi
    '更新日：2005/12/01 (Thu) 13:10:57
    '備　考：
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/12/01 (Thu) 13:11:47 S.Deguchi
    '更新日：2005/12/01 (Thu) 13:11:47
    '備　考：
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoUp_Click
    '機　能：作業ﾒﾓの前頁切替
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 17:54:36 S.Deguchi
    '更新日：2004/07/13 (Tue) 17:54:36
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：作業ﾒﾓの次頁切替
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 17:54:39 S.Deguchi
    '更新日：2004/07/13 (Tue) 17:54:39
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotList_Click
    '機　能：最新取得ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 09:00:34 S.Deguchi
    '更新日：2016/02/09 (Tue) 00:06:03 H.Hayashi
    '備　考：
    '　　　：2006/06/06 (Tue) 09:01:12 M.Miura      最新取得後に確定ﾎﾞﾀﾝの有効/無効制御追加　不具合№3469
    '　　　：2006/11/06 (Mon) 14:27:28 T.Kitagawa   量産(ODF対向基板)対応(案件№01544)
    '　　　：2008/07/07 (Mon) 12:00:00 S.Ochiai     欠損ﾁｯﾌﾟ表示対応(No.03046)及びSource整備
    '　　　：2013/11/28 (Thu) 17:14:21 T.Oide       R11-01 GNS対応
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub cmdLotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotList.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypInvAcptLotListReq   As invAcptLotListReq    '在庫ﾛｯﾄ一覧要求格納構造体
        Dim ltypInvAcptLotListAns   As InvAcptLotListAns    '在庫ﾛｯﾄ一覧応答格納構造体
        Dim llngInvAcptLotListCnt   As Integer              '在庫ﾛｯﾄ一覧応答ﾃﾞｰﾀ数

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
            
            '@親機種IDが空欄の場合には,処理を停止する
            If lblTFTProduct.Text = vbNullString Then
                Exit Sub
            End If
            
            '@選択されたﾀﾌﾞによって処理区分を変更
            Select Case tabSelect.SelectedIndex
                '@量産/ES(TFT)の場合
                Case CMlngPRTab0
                    If cmbTftFlowClass.ListIndex = -1 Then
                        Exit Sub
                    End If
                
                '@量産/ES(ODF)の場合
                Case CMlngODFTab1
                    If cmbOdfFlowClass.ListIndex = -1 Then
                        Exit Sub
                    End If
            End Select
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdLotList_Click"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@TFT基板在庫一覧構造体の初期化
            ltypInvAcptLotListReq.typPdList = New List(Of PDList)()
            ltypInvAcptLotListReq.typFlowClassList = New List(Of FlowClassList)()
            
            '@要求格納構造体へ格納
            With ltypInvAcptLotListReq
                .strMsgVer = CMstrinv_acptlotlistVer            'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                
                '@選択されたﾀﾌﾞによって処理区分を変更
                Select Case tabSelect.SelectedIndex
                    
                    '@量産(TFT基板)の場合
                    Case CMlngPRTab0
                        .strClassDivision = CPstrCD3X                   '3X:組立投入可能ﾛｯﾄ(量産/ES(TFT))
                        .lngFlowClassCnt = 1                            '流動区分ｶｳﾝﾄ数(=1)単独選択
                        Dim tmpFlowClassList As FlowClassList = New FlowClassList()
                        tmpFlowClassList.strFlowClass = cmbTftFlowClass.Text
                        .typFlowClassList.Add(tmpFlowClassList)
        '@↓2016/01/30 (Sat) 13:59:41 H.Hayashi **************************************************
                        .strAssemblePdId = cmbTftProduct.Text
        '@↑2016/01/30 (Sat) 13:59:41 H.Hayashi **************************************************

                    '@量産(ODF対向基板)の場合
                    Case CMlngODFTab1
                        .strClassDivision = CPstrCD4B                   '4B:組立投入可能ﾛｯﾄ(量産/ES(ODF))
                        .lngFlowClassCnt = 1                            '流動区分ｶｳﾝﾄ数(=1)単独選択
                        Dim tmpFlowClassList As FlowClassList = New FlowClassList()
                        tmpFlowClassList.strFlowClass = cmbOdfFlowClass.Text
                        .typFlowClassList.Add(tmpFlowClassList)
        '@↓2016/01/30 (Sat) 14:00:21 H.Hayashi **************************************************
                        .strAssemblePdId = cmbOdfProduct.Text
        '@↑2016/01/30 (Sat) 14:00:21 H.Hayashi **************************************************

                    '@試作/実験の場合
                    Case CMlngZZTab2
                        .strClassDivision = CPstrCD0V                   '0V:組立投入可能ﾛｯﾄ(試作/実験)
						'@試作/実験の場合は全てのﾛｯﾄを対象とする為, 表示する種別は限定しない
                        '.lngFlowClassCnt = 0                            '種別ｶｳﾝﾄ数(=0)

						'kkw 組立投入WF枚数変更
						'PR/ESを取得しないように(TS,WS,ZZ,QU,GG)のみ取得する
						.typFlowClassList = New List(Of FlowClassList) From {
							New FlowClassList With {.strFlowClass = "TS"},
							New FlowClassList With {.strFlowClass = "WS"},
							New FlowClassList With {.strFlowClass = "QU"},
							New FlowClassList With {.strFlowClass = "GG"},
							New FlowClassList With {.strFlowClass = "SY"},
							New FlowClassList With {.strFlowClass = "ZZ"}
						}

						.lngFlowClassCnt = .typFlowClassList.Count


        '@↓2016/01/30 (Sat) 14:00:21 H.Hayashi **************************************************
                        .strAssemblePdId = cmbProduct.Text
        '@↑2016/01/30 (Sat) 14:00:21 H.Hayashi **************************************************
                        
                End Select
                
                .lngPdCnt = 1                                           '機種ｶｳﾝﾄ数(=1)単独選択
                '@機種区分構造体作成
                Dim tmpPDList As PDList = New PDList()
                tmpPDList.strPdId = lblTFTProduct.Text   '親機種ID
                .typPdList.Add(tmpPDList)
            
            End With

            '@TFT基板在庫一覧情報取得処理
            lblnAns = prvblnInvAcptLotList_Sel(ltypInvAcptLotListReq, ltypInvAcptLotListAns, llngInvAcptLotListCnt)
            
            '@結果判定
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)
                '@最新取得ﾎﾞﾀﾝ
                cmdLotList.Enabled = True
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                '@最新取得ﾎﾞﾀﾝ
                cmdLotList.Enabled = False
                Exit Sub
            End If

            '@次項目へﾌｫｰｶｽｾｯﾄ
            If vsfLotList.Enabled = True Then
                '@TFT基板在庫一覧へｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(vsfLotList)
            Else
                '@閉じるﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmdClose)
            End If
            
        '@↓2013/11/28 (Thu) 17:20:53 T.Oide **************************************************
        '@    '@確定ﾎﾞﾀﾝの活性化ﾁｪｯｸを行う
        '@    lblnAns = prvblnLotmake_Chk
        '@    '@結果判定
        '@    If lblnAns = True Then
        '@        '@投入確定ﾎﾞﾀﾝの活性化
        '@        cmdLotMake.Enabled = True
        '@    Else
        '@        '@投入確定ﾎﾞﾀﾝの非活性化
        '@        cmdLotMake.Enabled = False
        '@    End If
        '@-------------------------------------------------------------------------------------

            '@確定ﾎﾞﾀﾝ、送品先変更ﾎﾞﾀﾝの有効/無効制御
            Call prvButtonCtrl()
            
        '@↑2013/11/28 (Thu) 17:20:53 T.Oide **************************************************
            
            '@作業ﾒﾓ
            txtWorkMemo.Enabled = True
            '@全部取消ﾎﾞﾀﾝ
            cmdClear.Enabled = True
            
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
            
        End Try
    End Sub

    '関数名：cmdComments_Click
    '機　能：ｺﾒﾝﾄ表示ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 14:44:40 S.Deguchi
    '更新日：2010/01/27 (Wed) 16:46:07 N.Kojima
    '備　考：
    '　　　：2004/12/07 (Tue) 09:08:58 S.Deguchi    不具合№237の差し戻しで下記処理を追加
    '　　　：2005/06/01 (Wed) 08:39:21 S.Deguchi    ｺﾒﾝﾄ表示ﾌｫｰﾑを共通化による修正
    '　　　：2010/01/27 (Wed) 16:46:07 N.Kojima     ｺﾒﾝﾄ表示画面がﾛｯﾄ処理順変更からも呼ばれるようになったことに伴い処理修正。(案件№03897)
    Private Sub cmdComments_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdComments.Click

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

           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@引継ぎ構造体に格納
            With vsfLotList
                '@ﾀｲﾄﾙ以外を選択した場合のみ下記処理を行う
                If .Row > 0 Then
                    ptypHoldConnect.strCommnents = .GetData(.Row, CMlngvsfColComments)
                End If
            End With
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfLotList
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfColLotID)
                
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With

        '@↓2010/01/27 (Wed) 16:46:04 N.Kojima **************************************************

            '@起動区分を設定(2：ﾛｯﾄ投入(組立))
            plngfrmxxCM00V0Kbn = CPlngNumTwo

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ ｺﾒﾝﾄ表示画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00V0.Instance.ShowDialog(Me)
            frmxxCM00V0.Instance = Nothing

            '@起動区分の初期化(0：ﾃﾞﾌｫﾙﾄ値(初期化値))
            plngfrmxxCM00V0Kbn = CPlngNumZero

        '@↑2010/01/27 (Wed) 16:46:04 N.Kojima **************************************************

            '@ﾌｫｰｶｽ戻り位置を設定
            Call prvFocus_Set(vsfLotList, lstrKeyID, CMlngvsfColLotID, llngTopRow)
            
            '@ｿｰﾄ前処理
            Call pubVsfBeforeSort(vsfLotList, CMlngvsfColLotID)
            
            '@ｿｰﾄ後処理
            Call pubVsfAfterSort(vsfLotList, CMlngvsfColLotID, cmdUP, cmdDown, False, False)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdComments_Click"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdChangeSendSB_Click
    '機　能：送品先変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2013/11/28 (Thu) 15:16:58 T.Oide
    '更新日：2013/11/28 (Thu) 15:16:58 T.Oide
    '備　考：GNS対応で追加
    Private Sub cmdChangeSendSB_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChangeSendSB.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@子ﾌｫｰﾑの表示情報を変数に格納
            With ptypCommonInfo
                '@引継ぎ情報ｾｯﾄ
                .strCarrierId = vbNullString
                .strLotID = vsfLotList.GetData(vsfLotList.Row, CMlngvsfColLotID)   'ﾛｯﾄID
            End With

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@投入予定ﾛｯﾄ変更/削除
            pblnfrmxxCM01A0Kbn = True
            
            '@子画面をﾛｰﾄﾞ
            frmxxCM01A0.Instance = New frmxxCM01A0()
                
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM01A0.Instance = Nothing
                Exit Sub
            End If
            
            '@子画面起動
            frmxxCM01A0.Instance.ShowDialog(Me)
            frmxxCM01A0.Instance = Nothing
            
            '@引継ぎ情報の初期化
            ptypCommonInfo.strLotID = vbNullString
            pblnfrmxxCM01A0Kbn = False
            
            '@最新情報を取得し直す
            Call cmdLotList_Click(cmdLotList, New EventArgs())
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdChangeSendSB_Click"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2013/11/27 (Wed) 19:57:39 T.Oide **************************************************
    '@'関数名：vsfOrderList_BeforeRowColChange
    '@'機　能：ｶﾚﾝﾄ行保持の為
    '@'引　数：OldRow：旧行
    '@'　　　：OldCol：旧列
    '@'　　　：NewRow：新行
    '@'　　　：NewCol：新列
    '@'　　　：Cancel：ｷｬﾝｾﾙ値
    '@'戻り値：なし
    '@'作成日：2005/05/16 (Mon) 14:49:48 S.Deguchi
    '@'更新日：2005/05/16 (Mon) 14:49:48
    '@'備　考：
    '@Private Sub vsfOrderList_BeforeRowColChange(ByVal OldRow As Long, _
    '@                                            ByVal OldCol As Long, _
    '@                                            ByVal NewRow As Long, _
    '@                                            ByVal NewCol As Long, _
    '@                                            Cancel As Boolean)
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@起動時に処理を行わない
    '@    If mblnFormLoadFlag = True Then
    '@        '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
    '@        If OldRow <> NewRow And NewRow > 0 Then
    '@            '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｬﾘｱID)
    '@            mtypChgSortOrder.strKey = vsfOrderList.Cell(flexcpText, NewRow, CMlngvsfOrderColOrderNo)
    '@        End If
    '@    End If
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey                     '機能ID
    '@        .strProcName = "vsfOrderList_BeforeRowColChange"    '処理名
    '@        .strErrMessage = vbNullString                       'ｴﾗｰﾒｯｾｰｼﾞ
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2013/11/27 (Wed) 19:57:39 T.Oide **************************************************

    '@↓2013/11/27 (Wed) 19:58:11 T.Oide **************************************************
    '@'関数名：vsfOrderList_AfterSort
    '@'機　能：ｿｰﾄ後処理
    '@'引　数：Col：列番号
    '@'　　　：Order：ｿｰﾄ順
    '@'戻り値：なし
    '@'作成日：2005/05/16 (Mon) 14:49:36 S.Deguchi
    '@'更新日：2013/11/27 (Wed) 19:43:57 T.Oide
    '@'備　考：
    '@Private Sub vsfOrderList_AfterSort(ByVal Col As Long, Order As Integer)
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@ｿｰﾄ順を格納
    '@    With mtypChgSortOrder
    '@        '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
    '@        .lngCnt = .lngCnt + 1
    '@        ReDim Preserve .typChgSortList(.lngCnt)
    '@        '@ｿｰﾄ列番号を格納
    '@        .typChgSortList(.lngCnt).lngCol = Col
    '@        '@並び替え方法を格納(昇順/降順)
    '@        .typChgSortList(.lngCnt).lngOrder = Order
    '@    End With
    '@
    '@    '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
    '@    Call pubVsfAfterSort(vsfOrderList, CMlngvsfOrderColOrderNo, cmdOrderUp, cmdOrderDown)
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey             '機能ID
    '@        .strProcName = "vsfOrderList_AfterSort"     '処理名
    '@        .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2013/11/27 (Wed) 19:58:11 T.Oide **************************************************

    '@↓2013/11/27 (Wed) 19:58:32 T.Oide **************************************************
    '@'関数名：vsfOrderList_BeforeSort
    '@'機　能：ｵｰﾀﾞｰﾘｽﾄｿｰﾄ前処理
    '@'引　数：Col：列
    '@'　　　：Order：番号
    '@'戻り値：なし
    '@'作成日：2005/05/16 (Mon) 14:49:39 S.Deguchi
    '@'更新日：2005/05/16 (Mon) 14:49:39
    '@'備　考：
    '@Private Sub vsfOrderList_BeforeSort(ByVal Col As Long, Order As Integer)
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
    '@    Call pubVsfBeforeSort(vsfOrderList, CMlngvsfOrderColOrderNo)
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey             '機能ID
    '@        .strProcName = "vsfOrderList_BeforeSort"    '処理名
    '@        .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2013/11/27 (Wed) 19:58:32 T.Oide **************************************************

    '@↓2013/11/27 (Wed) 19:58:54 T.Oide **************************************************
    '@'関数名：vsfOrderList_RowColChange
    '@'機　能：ｵｰﾀﾞｰﾘｽﾄ選択処理
    '@'引　数：なし
    '@'戻り値：なし
    '@'作成日：2005/05/16 (Mon) 14:47:30 S.Deguchi
    '@'更新日：2006/09/19 (Tue) 13:06:56 N.Kojima
    '@'備　考：
    '@'　　　：2006/09/19 (Tue) 13:06:56 N.Kojima     送品先指定機能追加に伴い、処理追加。(案件№01452)
    '@Private Sub vsfOrderList_RowColChange()
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐(起動時以外のみ処理)
    '@    If mblnFormLoadFlag = False Then
    '@        Exit Sub
    '@    End If
    '@
    '@    With vsfOrderList
    '@        '@選択行がﾀｲﾄﾙ以外
    '@        If .Row < 1 Then
    '@            Exit Sub
    '@        End If
    '@
    '@        '@親機種をﾗﾍﾞﾙにｾｯﾄ
    '@        lblTFTProduct.Caption = .Cell(flexcpText, .Row, CMlngvsfOrderColParentPDID)
    '@
    '@        '@親機種IDが空欄の場合には,処理を停止する
    '@        If lblTFTProduct.Caption = vbNullString Then
    '@            Exit Sub
    '@        End If
    '@
    '@        '@流動区分の判定
    '@        If cmbTftFlowClass.ListIndex = -1 Then
    '@            Exit Sub
    '@        End If
    '@
    '@        '@最新取得
    '@        Call cmdLotList_Click
    '@
    '@    End With
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey                 '機能ID
    '@        .strProcName = "vsfOrderList_RowColChange"      '処理名
    '@        .strErrMessage = ""                             'ｴﾗｰﾒｯｾｰｼﾞ
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2013/11/27 (Wed) 19:58:54 T.Oide **************************************************

    '@↓2013/11/27 (Wed) 19:44:14 T.Oide **************************************************
    '@'関数名：cmdOrderUp_Click
    '@'機　能：前頁
    '@'引　数：なし
    '@'戻り値：なし
    '@'作成日：2005/05/16 (Mon) 16:21:21 S.Deguchi
    '@'更新日：2005/05/16 (Mon) 16:21:21
    '@'備　考：
    '@Private Sub cmdOrderUp_Click()
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@前頁処理(ｸﾞﾘｯﾄﾞ、前頁、次頁)
    '@    Call pubVsfCmdUp(vsfOrderList, cmdOrderUp, cmdOrderDown)
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey             '機能ID
    '@        .strProcName = "cmdOrderUp_Click"           '処理名
    '@        .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2013/11/27 (Wed) 19:44:14 T.Oide **************************************************

    '@↓2013/11/27 (Wed) 19:44:43 T.Oide **************************************************
    '@'関数名：cmdOrderDown_Click
    '@'機　能：次頁
    '@'引　数：なし
    '@'戻り値：なし
    '@'作成日：2005/05/16 (Mon) 16:21:23 S.Deguchi
    '@'更新日：2005/05/16 (Mon) 16:21:23
    '@'備　考：
    '@Private Sub cmdOrderDown_Click()
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@次頁処理(ｸﾞﾘｯﾄﾞ、前頁、次頁)
    '@    Call pubVsfCmdDown(vsfOrderList, cmdOrderUp, cmdOrderDown)
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey             '機能ID
    '@        .strProcName = "cmdOrderDown_Click"         '処理名
    '@        .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2013/11/27 (Wed) 19:44:43 T.Oide **************************************************

    '関数名：vsfLotList_BeforeRowColChange
    '機　能：ｶﾚﾝﾄ行保持の為
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/12/01 (Wed) 17:49:02 S.Deguchi
    '更新日：2004/12/01 (Wed) 17:49:02
    '備　考：
    Private Sub vsfLotList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotList.BeforeRowColChange

        Dim OldRow As Integer
        Dim NewRow As Integer

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            OldRow = e.OldRange.r1
            NewRow = e.NewRange.r1

            '@起動時には処理を行わない
            If mblnFormLoadFlag = True Then
                '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
                If OldRow <> NewRow And NewRow > 0 Then
                    '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｬﾘｱID)
                    mtypChgSort.strKey = vsfLotList.GetData(NewRow, CMlngvsfColCarrierID)
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "vsfLotList_BeforeRowColChange"  '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotList_EnterCell
    '機　能：TFT基板在庫一覧の選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 19:28:02 S.Deguchi
    '更新日：2013/11/28 (Thu) 15:47:45 T.Oide
    '備　考：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
    Private Sub vsfLotList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.EnterCell

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            With vsfLotList
                '@ﾀｲﾄﾙ行の場合に処理を抜ける
                If .Row > 0 Then
        '@↓2013/11/28 (Thu) 17:21:48 T.Oide **************************************************
        '@            '@確定ﾎﾞﾀﾝの活性化ﾁｪｯｸを行う
        '@            lblnAns = prvblnLotmake_Chk
        '@            '@結果判定
        '@            If lblnAns = True Then
        '@                '@投入確定ﾎﾞﾀﾝの活性化
        '@                cmdLotMake.Enabled = True
        '@            Else
        '@                '@投入確定ﾎﾞﾀﾝの非活性化
        '@                cmdLotMake.Enabled = False
        '@            End If
        '@-------------------------------------------------------------------------------------

                    '@確定ﾎﾞﾀﾝ、送品先変更ﾎﾞﾀﾝの有効/無効制御
                    Call prvButtonCtrl()
            
        '@↑2013/11/28 (Thu) 17:21:48 T.Oide **************************************************
                    
                    '@選択された行のﾛｯﾄｺﾒﾝﾄﾌﾗｸﾞが立っている場合には,ｺﾒﾝﾄ表示ﾎﾞﾀﾝを活性化する
                    If .GetData(.Row, CMlngvsfColComments) <> vbNullString Then
                        cmdComments.Enabled = True
                    Else
                        cmdComments.Enabled = False
                    End If
                Else
                    Exit Sub
                End If
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotList_EnterCell"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotList_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 19:28:02 S.Deguchi
    '更新日：2004/07/28 (Wed) 19:28:02
    '備　考：
    '　　　：2004/12/01 (Wed) 17:47:52 S.Deguchi    ｶﾚﾝﾄ行保持機能を初期化
    Private Sub vsfLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.AfterSort

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
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

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
            Call pubVsfAfterSort(vsfLotList, CMlngvsfColNo, cmdUP, cmdDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotList_AfterSort"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 19:28:02 S.Deguchi
    '更新日：2004/07/28 (Wed) 19:28:02
    '備　考：
    Private Sub vsfLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfLotList, CMlngvsfColNo)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotList_BeforeSort"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_RowColChange
    '機　能：行選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/24 (Wed) 17:28:54 S.Deguchi
    '更新日：2013/11/28 (Thu) 17:22:49 T.Oide
    '備　考：
    '　　　：2006/11/06 (Mon) 14:37:52 T.Kitagawa   量産(ODF対向基板)対応(案件№01544)
    '　　　：2008/06/11 (Wed) 12:47:38 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/16 (Wed) 14:02:28 N.Kojima     案件№03046のﾃｽﾄ不具合修正(ﾛｯﾄ担当者ID退避変数にﾛｯﾄ担当者名がｾｯﾄされていた不具合の修正)
    '　　　：2013/11/28 (Thu) 17:14:21 T.Oide       R11-01 GNS対応
    Private Sub vsfLotList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.RowColChange

        Dim llngCnt         As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        
        Try
            
            With vsfLotList
                '@試作/実験の場合
                If tabSelect.SelectedIndex = CMlngZZTab2 Then
                    '@ﾀｲﾄﾙ以外
                    If .Row > 0 Then
                        '@ﾛｯﾄ担当を使用可能にする
                        cmbLotManager.Enabled = True
                        
                        '@選択行のﾛｯﾄ担当が空欄の場合
                        If .GetData(.Row, CMlngvsfColEngEmpName) = vbNullString Then
                            '@ﾛｯﾄ担当にNULLをｾｯﾄ
                            cmbLotManager.Text = vbNullString
                            
                            '@ﾛｯﾄ担当者IDにNULLをｾｯﾄ
                            mstrLotManagerID = vbNullString
                        Else
                            
                            For llngCnt = 0 To mlngLotManagerListCnt - 1
                            
                                '@ﾛｯﾄ担当者ﾘｽﾄと在庫情報のﾛｯﾄ担当者名を比較し、同じﾃﾞｰﾀがあるか
                                If .GetData(.Row, CMlngvsfColEngEmpName) = _
                                    mtypLotManagerList(llngCnt).strTechManName Then
                                    
                                    '@取得したﾛｯﾄ担当をｾｯﾄ
                                    cmbLotManager.Text = .GetData(.Row, CMlngvsfColEngEmpName)
                                    
                                    '@ﾛｯﾄ担当者IDを退避
                                    mstrLotManagerID = .GetData(.Row, CMlngvsfColEngEmpID)
                                    
                                    Exit For
                                Else
                                    '@ﾛｯﾄ担当にNULLをｾｯﾄ
                                    cmbLotManager.Text = vbNullString
                                
                                    '@ﾛｯﾄ担当者IDにNULLをｾｯﾄ
                                    mstrLotManagerID = vbNullString
                                End If
                            Next llngCnt
                        End If
                    Else
                        '@ﾛｯﾄ担当にNULLをｾｯﾄ&使用不可能に
                        cmbLotManager.Text = vbNullString
                        cmbLotManager.Enabled = False
                    End If
                End If
            End With
            
        '@↓2013/11/28 (Thu) 17:22:30 T.Oide **************************************************
        '@    '@確定ﾎﾞﾀﾝの活性化ﾁｪｯｸを行う
        '@    lblnAns = prvblnLotmake_Chk
        '@    '@結果判定
        '@    If lblnAns = True Then
        '@        '@投入確定ﾎﾞﾀﾝの活性化
        '@        cmdLotMake.Enabled = True
        '@    Else
        '@        '@投入確定ﾎﾞﾀﾝの非活性化
        '@        cmdLotMake.Enabled = False
        '@    End If
        '@-------------------------------------------------------------------------------------

            '@確定ﾎﾞﾀﾝ、送品先変更ﾎﾞﾀﾝの有効/無効制御
            Call prvButtonCtrl()
            
        '@↑2013/11/28 (Thu) 17:22:30 T.Oide **************************************************
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotList_RowColChange"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdUP_Click
    '機　能：前頁
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 19:28:02 S.Deguchi
    '更新日：2004/07/28 (Wed) 19:28:02
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

            '@前頁処理(ｸﾞﾘｯﾄﾞ、前頁、次頁)
            Call pubVsfCmdUp(vsfLotList, cmdUP, cmdDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdUp_Click"                '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：次頁
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 19:28:02 S.Deguchi
    '更新日：2004/07/28 (Wed) 19:28:02
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

            '@次頁処理(ｸﾞﾘｯﾄﾞ、前頁、次頁)
            Call pubVsfCmdDown(vsfLotList, cmdUP, cmdDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdDown_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	
    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱIDﾌｫｰｶｽﾛｽﾄ時処理(1)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    '　　　：
    '　　　：
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAns                         As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrCarriaName                  As String               'ｷｬﾘｱID欄名
		Dim llngCnt							As Integer

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
			If Me.ActiveControl.Name = tabSelect.Name Then
				Exit Sub
			End If

            '@投入予定ｷｬﾘｱIDの桁ﾁｪｯｸ
            If LenB(txtCarrier.Text) < CPlngCarrierMaxLength And _
               txtCarrier.Text <> vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                
                '@"C_WAR0007　ｷｬﾘｱIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽそのまま
                e.Cancel = True
                
                '@ｷｬﾘｱIDのﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                
                Exit Sub
            End If

			'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Exit Sub
            End If


			lstrCarriaName = txtCarrier.Text

  
			With vsfLotList
				For llngCnt = 1 To .Rows.Count - 1
					If lstrCarriaName = .GetData(llngCnt,CMlngvsfColCarrierID) Then
						.Select(llngCnt,CMlngvsfColCarrierID)
						pubSetFocus(vsfLotList)
						Exit For

					End If

				Next

			End With

		
    

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


    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvfrmxxEN00Q0_Init
    '機　能：画面情報の初期化
    '引　数：lblnClearFlag：True：起動時初期化/False：設定項目のみ初期化
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 15:19:01 S.Deguchi
    '更新日：2013/11/28 (Thu) 15:44:55 T.Oide
    '備　考：
    '　　　：2004/10/04 (Mon) 13:31:37 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/11/24 (Wed) 16:21:41 S.Deguchi    技術担当者欄の初期化処理を追加
    '　　　：2005/05/17 (Tue) 10:09:24 S.Deguchi    引数：lblnClearFlagを追加で処理を分岐
    '　　　：2006/11/06 (Mon) 13:35:22 T.Kitagawa   量産(ODF対向基板)対応(案件№01544)
    '　　　：2007/12/25 (Tue) 18:52:49 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2008/06/11 (Wed) 12:49:09 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
    Private Sub prvfrmxxEN00Q0_Init(ByVal lblnClearFlag As Boolean)

        Dim llngNowByte     As Integer      '現在のﾊﾞｲﾄ数格納
        Dim lstrFormTitle   As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        
        Try
            
            '@ｸﾘｱﾌﾗｸﾞによる処理分岐
            If lblnClearFlag = True Then
                
                '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
                Call pubMenuItemCorrelation_Set(CPstrKeyEN00Q0, lstrFormTitle)
                
                '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
                Me.Text = lstrFormTitle
            
                '@ﾀﾌﾞ表示、対象ﾌﾚｰﾑの有効化
                tabSelect.SelectTab(CMlngPRTab0)
                fraTftThrowIn.Enabled = True
                
                '@表示Tab以外のTabの内容を非活性化
                fraOdfThrowIn.Enabled = False
                fraThrowIn.Enabled = False

        '@↓2013/11/27 (Wed) 19:44:57 T.Oide **************************************************
        '@        '@ｵｰﾀﾞｰ一覧の初期化
        '@        Call prvvsfOrderList_Init
        '@
        '@        cmdOrderUp.Enabled = False              'ｵｰﾀﾞｰﾘｽﾄの上ｽｸﾛｰﾙﾎﾞﾀﾝ
        '@        cmdOrderDown.Enabled = False            'ｵｰﾀﾞｰﾘｽﾄの下ｽｸﾛｰﾙﾎﾞﾀﾝ
        '@↑2013/11/27 (Wed) 19:44:57 T.Oide **************************************************
            
                cmbLotManager.Enabled = False           'ﾛｯﾄ担当ｺﾝﾎﾞ
                cmbLotManager.Text = vbNullString       'ﾛｯﾄ担当ﾃｷｽﾄ
            End If
            
            '@各種退避領域初期化
            mstrOdfPDID = vbNullString                  '量産ODF投入機種
            mstrTftPDID = vbNullString                  '量産TFT基板機種
            mstrPDID = vbNullString                     '投入機種
            mstrLotManagerID = vbNullString             'ﾛｯﾄ担当
            mstrTFTFlowClass = vbNullString             'TFT流動区分
            mstrODFFlowClass = vbNullString             'ODF流動区分
            
            '@Comboの非活性化
            cmbFlowClass.Enabled = False                '試作実験種別
            cmbFlowClass.ListIndex = -1
            cmbChipElectric.Text = vbNullString         'ﾁｯﾌﾟ電特
            cmbChipElectric.Enabled = False
            cmbTftFlowClass.ListIndex = -1              '量産/ES(TFT基板)種別
            cmbOdfFlowClass.ListIndex = -1              '量産/ES(ODF)種別
            cmbChipElectric.Enabled = False             'ﾁｯﾌﾟ電特
            
            '@ｴﾝﾄﾘを選択するｵﾌﾟｼｮﾝﾎﾞﾀﾝのValue値/Enabled値を全てFalseに設定する
            optThrowUser0.Checked = False
            optThrowUser1.Checked = False
            optThrowUser0.Enabled = False
            optThrowUser1.Enabled = False
            
            '@ﾗﾍﾞﾙの初期化
            lblEntryID.Text = vbNullString           'ｴﾝﾄﾘID
            lblEntry.Text = vbNullString             'ｴﾝﾄﾘ名

            '@機種ｴﾝﾄﾘﾎﾞﾀﾝを非活性化
            cmdEntry.Enabled = False

            '@ﾕｰｻﾞｰﾌﾟﾛｾｽ初期化
            With txtUserEntry
                .Text = vbNullString                    'ﾃｷｽﾄ
                .Enabled = False                        '無効
                .BackColor = SystemColors.ControlLight  'ﾊﾞｯｸｶﾗｰ(灰色)
            End With
            
            '@ﾕｰｻﾞｰﾌﾟﾛｾｽﾎﾞﾀﾝを非活性化
            cmdUserEntry.Enabled = False

            '@ﾗﾍﾞﾙの初期化
            lblUserEntry.Text = vbNullString         'ﾕｰｻﾞｰﾌﾟﾛｾｽ名
            lblTFTProduct.Text = vbNullString        'TFT基板機種
            lblNowDate.Text = vbNullString           '情報取得日時
            lblLotCnt.Text = vbNullString            '該当件数

			txtCarrier.Text = vbNullString
            
            '@作業ﾒﾓ初期化
            With txtWorkMemo
                .Enabled = False                        '無効
                .ChrMaxByte = CPlngLotCommentsMaxByte   'MAXByte
                .Text = vbNullString                    'ﾃｷｽﾄ
                llngNowByte = .NowByte                  'NowByte
                
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                              llngNowByte, _
                                                              CPlngLotCommentsMaxByte)
            End With
            
            '@作業ﾒﾓｽｸﾛｰﾙﾎﾞﾀﾝの初期化(非活性化)
            cmdMemoUp.Enabled = False                   '上ｽｸﾛｰﾙ
            cmdMemoDown.Enabled = False                 '下ｽｸﾛｰﾙ
            
            '@TFT在庫一覧の初期化(ｽｸﾛｰﾙﾎﾞﾀﾝの初期化：非活性化)
            Call prvvsfLotList_Init()
            
            '@TFT在庫一覧ｽｸﾛｰﾙﾎﾞﾀﾝの初期化(非活性化)
            cmdUP.Enabled = False                       '上ｽｸﾛｰﾙ
            cmdDown.Enabled = False                     '下ｽｸﾛｰﾙ
            
            '@ﾎﾞﾀﾝの非活性化
            cmdLotList.Enabled = False                  '最新取得
            cmdComments.Enabled = False                 'ｺﾒﾝﾄ
            cmdClear.Enabled = False                    '全部取消
            cmdLotMake.Enabled = False                  '確定
        '@↓2013/11/28 (Thu) 15:44:42 T.Oide **************************************************
            cmdChangeSendSB.Enabled = False             '送品先変更
        '@↑2013/11/28 (Thu) 15:44:42 T.Oide **************************************************

            '@「閉じる」ﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN00Q0_Init"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbOdfPdList_Disp
    '機　能：量産(ODF対向基板)投入/TFT基板機種Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/06 (Mon) 14:39:56 T.Kitagawa
    '更新日：2006/11/06 (Mon) 14:39:56
    '備　考：
    Private Sub prvcmbOdfPdList_Disp()

        Dim llngCnt                     As Integer                          'ﾙｰﾌﾟｶｳﾝﾄ
        
        Try
            
            '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)-投入機種
            With cmbOdfProduct
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear()
                .Enabled = True                                                 '活性化
                .DirectInput = False                                            '直接入力(False)
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .BackColor = Color.White                                        'ﾊﾞｯｸｶﾗｰ初期化(白)
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                 .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                     .GridFont.Style, .GridFont.Unit)           'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成(ID/親ID/Index/null/ForeColor/BackColor)
                For llngCnt = 0 To mlngOdfProductListCnt - 1
                    .AddItem(mtypOdfProductList(llngCnt).strProductID & _
                            vbTab & _
                            mtypOdfProductList(llngCnt).strParentPdId & _
                            vbTab & _
                            llngCnt & _
                            vbTab & _
                            vbNullString & _
                            vbTab & _
                            mtypOdfProductList(llngCnt).strForeColor & _
                            vbTab & _
                            mtypOdfProductList(llngCnt).strBackColor)
                Next llngCnt
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbOdfPdList_Disp"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbTftPdList_Disp
    '機　能：TFT機種ｺﾝﾎﾞ設定
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/19 (Fri) 17:12:40 N.Kasai
    '更新日：2007/01/19 (Fri) 17:12:40
    '備　考：
    Private Sub prvcmbTftPdList_Disp()

        Dim llngCnt                     As Integer                          'ﾙｰﾌﾟｶｳﾝﾄ
        
        Try
            
            '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)-投入機種
            With cmbTftProduct
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear()
                .Enabled = True                                                 '活性化
                .DirectInput = False                                            '直接入力(False)
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .BackColor = Color.White                                        'ﾊﾞｯｸｶﾗｰ初期化(白)
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                 .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                     .GridFont.Style, .GridFont.Unit)           'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成(ID/親ID/Index/null/ForeColor/BackColor)
                '@空欄ありの為,最初の1行は空欄をｾｯﾄ
                .AddItem(CPstrSpace & vbTab & CPstrSpace)
                For llngCnt = 0 To mlngTftProductListCnt - 1
                    .AddItem(mtypTftProductList(llngCnt).strProductID & _
                            vbTab & _
                            mtypTftProductList(llngCnt).strParentPdId & _
                            vbTab & _
                            llngCnt & _
                            vbTab & _
                            vbNullString & _
                            vbTab & _
                            mtypTftProductList(llngCnt).strForeColor & _
                            vbTab & _
                            mtypTftProductList(llngCnt).strBackColor)
                Next llngCnt
            
                .ListIndex = 0
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbTftPdList_Disp"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPdList_Disp
    '機　能：投入/TFT基板機種Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 15:25:19 S.Deguchi
    '更新日：2005/07/21 (Thu) 15:31:23 N.Kasai
    '備　考：
    '　　　：2005/07/21 (Thu) 15:31:23 N.Kasai      ｺﾝﾎﾞL/R表示機能追加
    Private Sub prvcmbPdList_Disp()

        Dim llngCnt                     As Integer                          'ﾙｰﾌﾟｶｳﾝﾄ
        
        Try
            
            '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)-投入機種
            With cmbProduct
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear()
                .Enabled = True                                                 '活性化
                .DirectInput = False                                            '直接入力(False)
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .BackColor = Color.White                                        'ﾊﾞｯｸｶﾗｰ初期化(白)
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                 .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                     .GridFont.Style, .GridFont.Unit)           'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え

                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成(ID/親ID/Index/null/ForeColor/BackColor)
                For llngCnt = 0 To mlngProductListCnt - 1
                    .AddItem(mtypProductList(llngCnt).strProductID & _
                            vbTab & _
                            mtypProductList(llngCnt).strParentPdId & _
                            vbTab & _
                            llngCnt & _
                            vbTab & _
                            vbNullString & _
                            vbTab & _
                            mtypProductList(llngCnt).strForeColor & _
                            vbTab & _
                            mtypProductList(llngCnt).strBackColor)
                Next llngCnt
            
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbPdList_Disp"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbDivisionList_Disp
    '機　能：種別Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 16:58:43 S.Deguchi
    '更新日：2007/09/11 (Tue) 16:40:00 N.Kasai
    '備　考：
    '　　　：2005/05/16 (Mon) 12:28:46 S.Deguchi    種別"PR"はｾｯﾄしないようにする処理を追加
    '　　　：2007/09/11 (Tue) 16:40:00 N.Kasai      種別"ES"対象外(№02142)
    Private Sub prvcmbDivisionList_Disp()

        Dim llngCnt             As Integer                                  'ﾙｰﾌﾟｶｳﾝﾄ
        
        Try
            
            '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)-投入種別
            With cmbFlowClass
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear()
                .Enabled = True                                                 '活性化
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=0)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                 .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                     .GridFont.Style, .GridFont.Unit)           'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngDivisionListCnt - 1
                    '@種別"PR"&"ES"は表示しない
                    If mtypDivisionList(llngCnt).strDivisionID <> CPstrFlowClassPR And _
                        mtypDivisionList(llngCnt).strDivisionID <> CPstrFlowClassES Then
                        .AddItem(mtypDivisionList(llngCnt).strDivisionID & _
                                 vbTab & _
                                 llngCnt)
                    End If
                Next llngCnt                                                    'ID/Index
            
                .GroupRows = .ListCount                                         '行方向のﾚｺｰﾄﾞ数
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbDivisionList_Disp"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvcmbFlowClassList_Disp
    '機　能：量産/ES(TFT,ODF)ｺﾝﾎﾞ設定
    '引　数：lobjCmb：ｵﾌﾞｼﾞｪｸﾄ名
    '戻り値：なし
    '作成日：2007/09/11 (Tue) 17:17:04 N.Kasai
    '更新日：2007/09/11 (Tue) 17:17:04
    '備　考：
    Private Sub prvcmbFlowClassList_Disp(ByRef lobjCmb As SECmbIchiran.ComboIchiran)
        
        Try
            
            '@ｺﾝﾎﾞ制御-投入種別
            With lobjCmb
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear()
                .Enabled = True                                                 '活性化
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=0)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                 .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                     .GridFont.Style, .GridFont.Unit)           'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                '@種別"PR"&"ES"のみ表示
                .AddItem(CPstrFlowClassPR)
                .AddItem(CPstrFlowClassES)
                .GroupRows = .ListCount                                         '行方向のﾚｺｰﾄﾞ数
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbFlowClassList_Disp"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvcmbChipElectric_Disp
    '機　能：ﾁｯﾌﾟ電特ｺﾝﾎﾞ設定
    '引　数：なし
    '戻り値：なし
    '作成日：2007/12/25 (Tue) 15:22:27 N.Kojima
    '更新日：2007/12/25 (Tue) 15:22:27
    '備　考：
    Private Sub prvcmbChipElectric_Disp()
        
        Try
            
            '@ｺﾝﾎﾞ制御-ﾁｯﾌﾟ電特
            With cmbChipElectric
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear()
                .Enabled = False                                                '活性化
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=0)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                 .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                     .GridFont.Style, .GridFont.Unit)           'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                '@"あり"&"なし"のみ表示
                .AddItem(CPstrAriFlg)
                .AddItem(CPstrNasiFlg)
                .GroupRows = .ListCount                                         '行方向のﾚｺｰﾄﾞ数
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbChipElectric_Disp"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvcmbPrioList_Disp
    '機　能：優先度Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 11:27:15 S.Deguchi
    '更新日：2004/07/27 (Tue) 11:27:15
    '備　考：
    Private Sub prvcmbPrioList_Disp()

        Dim llngCnt             As Integer                                  'ﾙｰﾌﾟｶｳﾝﾄ
        
        Try
            
            '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)-優先度
            With cmbPrioSel
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear()
                .Enabled = True
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=0)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngPriorityReasonListCnt                          '行方向のﾚｺｰﾄﾞ数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                 .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                     .GridFont.Style, .GridFont.Unit)           'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngPriorityReasonListCnt - 1
                    .AddItem(mtypPriorityReasonList(llngCnt).strMasPriorityId _
                           & CPstrSpace _
                           & mtypPriorityReasonList(llngCnt).strMasPriorityName _
                           & vbTab _
                           & mtypPriorityReasonList(llngCnt).strMasPriorityId)
                Next llngCnt                                                    '[ID 和名] & ID
                
                '@優先順位ｺﾝﾎﾞﾎﾞｯｸｽ初期値ｾｯﾄ
                .ListIndex = CMstrcmbPrioSel
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbPrioList_Disp"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbLotManagerList_DIsp
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/24 (Wed) 16:26:43 S.Deguchi
    '更新日：2008/06/11 (Wed) 12:49:41 N.Kojima
    '備　考：
    '　　　：2004/11/29 (Mon) 16:40:48 S.Deguchi    技術担当でNull欄を追加
    '　　　：2008/06/11 (Wed) 12:49:41 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvCmbLotManagerList_Disp()

        Dim llngCnt             As Integer                                  'ﾙｰﾌﾟｶｳﾝﾄ
        
        Try

            With cmbLotManager
            
                .Clear()                                                        'ｸﾘｱ
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=0)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngPriorityReasonListCnt                          '行方向のﾚｺｰﾄﾞ数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                 .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                     .GridFont.Style, .GridFont.Unit)           'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                
                '@空欄ありの為,最初の1行は空欄をｾｯﾄ
                .AddItem(CPstrSpace & vbTab & CPstrSpace)
                
                For llngCnt = 0 To mlngLotManagerListCnt - 1
                    
                    '@ｺﾝﾎﾞ内容設定：ﾛｯﾄ担当者名/ﾛｯﾄ担当者ID
                    .AddItem(mtypLotManagerList(llngCnt).strTechManName _
                           & vbTab _
                           & mtypLotManagerList(llngCnt).strTechManID)
                Next llngCnt
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbLotManagerList_Disp"  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInvAcptLotList_Sel
    '機　能：TFT基板在庫一覧情報取得処理
    '引　数：ltypRequestList：TFT基板在庫一覧情報要求構造体
    '　　　：ltypInvActptLotList：TFT基板在庫一覧情報格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2004/07/28 (Wed) 08:53:32 S.Deguchi
    '更新日：2004/07/28 (Wed) 08:53:32
    '備　考：ﾒｯｾｰｼﾞ取得部分のみﾓｼﾞｭｰﾙ化して共通使用する
    Private Function prvblnInvAcptLotList_Sel(ByRef ltypInvAcptLotListReq As invAcptLotListReq, _
                                              ByRef ltypInvAcptLotListAns As InvAcptLotListAns, _
                                              ByRef llngInvAcptLotListCnt As Integer) As Boolean

        Dim lblnAns As Boolean              '結果判定
        
        Try
            
            '@TFT基板在庫一覧情報取得処理
            lblnAns = pubblnInvAcptlotList_Sel(ltypInvAcptLotListReq, _
                                               ltypInvAcptLotListAns, _
                                               llngInvAcptLotListCnt)
            
            '@結果判定
            If lblnAns = True Then
                '@TFT基板在庫一覧情報表示処理
                Call prvvsfLotList_Disp(ltypInvAcptLotListAns, llngInvAcptLotListCnt)
                
                '@成功結果を返す
                prvblnInvAcptLotList_Sel = True
            Else
                '@失敗結果を返す
                prvblnInvAcptLotList_Sel = False
            End If

            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnInvAcptLotList_Sel"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '@↓2013/11/28 (Thu) 13:03:54 T.Oide **************************************************
    '@'関数名：prvblnAtlsOrderList_Sel
    '@'機　能：ｱﾄﾗｽｵｰﾀﾞｰ情報取得処理
    '@'引　数：mtypAtlsOrderList：ｱﾄﾗｽｵｰﾀﾞｰ
    '@'戻り値：True:成功/False:失敗
    '@'作成日：2005/05/16 (Mon) 15:22:56 S.Deguchi
    '@'更新日：2005/05/16 (Mon) 15:22:56
    '@'備　考：
    '@Private Function prvblnAtlsOrderList_Sel(ByRef mtypAtlsOrderList As AtlsOrderList) As Boolean
    '@
    '@    Dim lblnAns     As Boolean              '結果判定
    '@    Dim lstrPdID    As String               '機種ID
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@機種ID取得
    '@    lstrPdID = Trim$(cmbTftProduct.Text)
    '@
    '@    '@ｱﾄﾗｽｵｰﾀﾞｰ情報取得処理
    '@    lblnAns = pubblnAtlsOrderList_Sel(pstrSBID, CMstratlsorderlistVer, lstrPdID, mtypAtlsOrderList)
    '@    '@結果判定
    '@    If lblnAns = True Then
    '@        '@成功結果を返す
    '@        prvblnAtlsOrderList_Sel = True
    '@    Else
    '@
    '@        '@TFT基板在庫一覧情報初期化処理
    '@        Call prvvsfOrderList_Init
    '@
    '@        '@失敗結果を返す
    '@        prvblnAtlsOrderList_Sel = False
    '@    End If
    '@
    '@    Exit Function
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey             '機能ID
    '@        .strProcName = "prvblnAtlsOrderList_Sel"    '処理名
    '@        .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Function
    '@↑2013/11/28 (Thu) 13:03:54 T.Oide **************************************************

    '関数名：prvvsfLotList_Init
    '機　能：TFT基板在庫一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 16:29:19 S.Deguchi
    '更新日：2008/06/11 (Wed) 12:57:56 N.Kojima
    '備　考：
    '　　　：2004/11/24 (Wed) 17:30:40 S.Deguchi    技術担当者ID＆名称列を追加
    '　　　：2006/09/14 (Thu) 14:57:59 N.Kojima     送品先追加に伴い、処理追加。(案件№01452)
    '　　　：2008/06/11 (Wed) 12:57:56 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvvsfLotList_Init()

        Try

            With vsfLotList

                .Redraw = False
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear()
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '@ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Row
                
                '@ﾌｫﾝﾄｻｲｽﾞ指定(=14)
                .Font = New Font(.Font.FontFamily, CMlngvsfFontSize, .Font.Style, .Font.Unit)

                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfColNo, CMlngVsfRowTitle, .Cols.Count - 1) '表題
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                  '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)     '背景色
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                    '文字位置
                headerStyle.Trimming  = StringTrimming.None                           'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfColNo, CMstrvsfTColNo)                         'No.
                .SetData(CMlngVsfRowTitle, CMlngvsfColCarrierID, CMstrvsfTColCarrierID)           'ｷｬﾘｱID
                .SetData(CMlngVsfRowTitle, CMlngvsfColLotID, CMstrvsfTColLotID)                   'ﾛｯﾄID
                .SetData(CMlngVsfRowTitle, CMlngvsfColFlowClass, CMstrvsfTColFlowClass)           '種別
                .SetData(CMlngVsfRowTitle, CMlngvsfColWFNum, CMstrvsfTColWFNum)                   'WF
                .SetData(CMlngVsfRowTitle, CMlngvsfColChipNum, CMstrvsfTColChipNum)               'ﾁｯﾌﾟ
                .SetData(CMlngVsfRowTitle, CMlngvsfColComments, CMstrvsfTColComments)             'ｺﾒﾝﾄ内容
                .SetData(CMlngVsfRowTitle, CMlngvsfColCommentDisp, CMstrvsfTColCommentDisp)       'ｺﾒﾝﾄ有無
                .SetData(CMlngVsfRowTitle, CMlngvsfColEngEmpID, CMstrvsfTColEngEmpID)             'ﾛｯﾄ担当者ID
                .SetData(CMlngVsfRowTitle, CMlngvsfColEngEmpName, CMstrvsfTColEngEmpName)         'ﾛｯﾄ担当者名
                .SetData(CMlngVsfRowTitle, CMlngvsfColSendSBID, CMstrvsfTColSendSBID)             '送品先ID
                .SetData(CMlngVsfRowTitle, CMlngvsfColSendSBName, CMstrvsfTColSendSBName)         '送品先名
                .SetData(CMlngVsfRowTitle, CMlngvsfColLostChipInfo, CMstrvsfTColLostChipInfo)     '欠損ﾁｯﾌﾟ情報

                '@列幅設定
                .Cols(CMlngvsfColNo).Width = CMlngvsfWColNo                                                   'No.
                .Cols(CMlngvsfColCarrierID).Width = CMlngvsfWcolCarrierID                                     'ｷｬﾘｱID
                .Cols(CMlngvsfColLotID).Width = CMlngvsfWColLotID                                             'ﾛｯﾄID
                .Cols(CMlngvsfColFlowClass).Width = CMlngvsfWcolFlowClass                                     '種別
                .Cols(CMlngvsfColWFNum).Width = CMlngvsfWcolWFNum                                             'WF
                .Cols(CMlngvsfColChipNum).Width = CMlngvsfWcolChipNum                                         'ﾁｯﾌﾟ
                .Cols(CMlngvsfColComments).Width = CMlngvsfWColComments                                       'ｺﾒﾝﾄ内容
                .Cols(CMlngvsfColCommentDisp).Width = CMlngvsfWColCommentDisp                                 'ｺﾒﾝﾄ有無
                .Cols(CMlngvsfColEngEmpID).Width = CMlngvsfWColEngEmpID                                       'ﾛｯﾄ担当者ID
                .Cols(CMlngvsfColEngEmpName).Width = CMlngvsfWColEngEmpName                                   'ﾛｯﾄ担当者名
                .Cols(CMlngvsfColSendSBID).Width = CMlngvsfWColSendSBID                                       '送品先ID
                .Cols(CMlngvsfColSendSBName).Width = CMlngvsfWColSendSBName                                   '送品先名
                .Cols(CMlngvsfColLostChipInfo).Width = CMlngvsfWColLostChipInfo                               '欠損ﾁｯﾌﾟ情報                                   '送品先名

                '@DataType設定
                .Cols(CMlngvsfColNo).DataType = GetType(Int32)
                .Cols(CMlngvsfColWFNum).DataType = GetType(Int32)
                .Cols(CMlngvsfColChipNum).DataType = GetType(Int32)
                '@Format設定
                .Cols(CMlngvsfColChipNum).Format = "##,###"

                .ExtendLastCol = True
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight
                
                '@非表示項目の設定
                .Cols(CMlngvsfColComments).Visible = False          'ｺﾒﾝﾄ退避内容
                .Cols(CMlngvsfColEngEmpID).Visible = False          'ﾛｯﾄ担当者ID
                .Cols(CMlngvsfColEngEmpName).Visible = False        'ﾛｯﾄ担当者
                .Cols(CMlngvsfColSendSBID).Visible = False          '送品先ID
                
                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.None
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfLotList_Init"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvvsfLotList_Disp
    '機　能：TFT基板在庫一覧の表記処理
    '引　数：ltypInvActptLotList：基板在庫一覧格納構造体
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 10:43:00 S.Deguchi
    '更新日：2013/11/28 (Thu) 15:54:52 T.Oide
    '備　考：
    '　　　：2004/09/22 (Wed) 10:35:56 S.Deguchi    ｺﾒﾝﾄをありなし表示へ変更
    '　　　：2004/09/26 (Sun) 09:29:28 S.Deguchi    ｺﾒﾝﾄをあり/Null表示へ変更
    '　　　：2004/11/24 (Wed) 17:30:40 S.Deguchi    技術担当者ID＆名称列を追加
    '　　　：2006/05/25 (Thu) 18:21:12 N.Kojima     種別によって背景色を変える処理追加。
    '　　　：2006/09/14 (Thu) 15:16:51 N.Kojima     送品先追加に伴い、処理追加。(案件№01452)
    '　　　：2006/11/06 (Mon) 14:43:52 T.Kitagawa   量産(ODF対向基板)対応(案件№01544)
    '　　　：2007/12/25 (Tue) 18:37:19 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2008/06/11 (Wed) 12:59:39 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/07 (Mon) 12:00:00 S.Ochiai     欠損ﾁｯﾌﾟ表示対応(No.03046)及びSource整備
    '　　　：2009/02/25 (Wed) 16:54:58 N.Kojima     送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。(案件№03402)
    '　　　：2009/12/02 (Wed) 11:32:35 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    '　　　：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
    Private Sub prvvsfLotList_Disp(ByRef ltypInvAcptLotListAns As InvAcptLotListAns, _
                                   ByVal llngInvAcptLotListCnt As Integer)

        Dim llngDoCnt   As Integer  'ｶｳﾝﾄ
        
        Try
            
            With vsfLotList
                
                '@ﾃﾞｰﾀがあるか
                If llngInvAcptLotListCnt <> 0 Then
                    '@ﾃﾞｰﾀがあるの場合
                    
                    '@描画ﾛｯｸ
                    .Redraw = False

                    RemoveHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange
                    RemoveHandler vsfLotList.RowColChange, AddressOf vsfLotList_RowColChange
                    RemoveHandler vsfLotList.EnterCell, AddressOf vsfLotList_EnterCell
                                
                    '@まず初期化
                    .Rows.Count = .Rows.Fixed

                    '@行数設定
                    .Rows.Count = llngInvAcptLotListCnt + 1
                    
                    'NSYS 設定Style定義
                    Dim newStyle_BC_vbWhite As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                    newStyle_BC_vbWhite.ForeColor = SystemColors.WindowText '黒色
                    newStyle_BC_vbWhite.BackColor = Color.White '白色
                    Dim newStyle_BC_NotInputColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                    newStyle_BC_NotInputColor.ForeColor = SystemColors.WindowText '黒色
                    newStyle_BC_NotInputColor.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor) '薄いグレー
                    Dim newStyle_FC_vbBlue_BC_vbWhite As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue_BackColor_vbWhite")
                    newStyle_FC_vbBlue_BC_vbWhite.ForeColor = Color.Blue '青色
                    newStyle_FC_vbBlue_BC_vbWhite.BackColor = Color.White '白色
                    Dim newStyle_FC_vbBlue_BC_NotInputColor As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue_BackColor_CPlngNotInputColor")
                    newStyle_FC_vbBlue_BC_NotInputColor.ForeColor = Color.Blue '青色
                    newStyle_FC_vbBlue_BC_NotInputColor.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor) '薄いグレー
                    Dim newStyle_FC_vbBlue As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue")
                    newStyle_FC_vbBlue.ForeColor = Color.Blue '青色
                    Dim cellRange As CellRange

                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1
                    
                    '@ﾛｯﾄ一覧表示情報設定
                    Do While .Rows.Count > llngDoCnt
                        
                        .SetData(llngDoCnt, CMlngvsfColNo, llngDoCnt)                                 '通し番号

                        .SetData(llngDoCnt, CMlngvsfColCarrierID, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strCarrierId)                         'ｷｬﾘｱID

                        .SetData(llngDoCnt, CMlngvsfColLotID, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strLotID)                             'ﾛｯﾄID

                        .SetData(llngDoCnt, CMlngvsfColFlowClass, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strFlowClass)                         '種別

                        .SetData(llngDoCnt, CMlngvsfColWFNum, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strWFQuantity)                        'WF

                        If IsNumeric(ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strChipQuantity) Then
                            .SetData(llngDoCnt, CMlngvsfColChipNum, _
                                Format$(CInt(ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strChipQuantity), "##,###"))   'ﾁｯﾌﾟ
                        Else
                            .SetData(llngDoCnt, CMlngvsfColChipNum, _
                                ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strChipQuantity)                  'ﾁｯﾌﾟ
                        End If

                        .SetData(llngDoCnt, CMlngvsfColComments, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strLotComments)                       'ｺﾒﾝﾄ内容
                        
                        '@ｺﾒﾝﾄﾌﾗｸﾞ設定
                        If ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strLotComments <> vbNullString Then
                            '@ｺﾒﾝﾄが空欄以外の場合
                            .SetData(llngDoCnt, CMlngvsfColCommentDisp, CPstrAriFlg)                            'ｺﾒﾝﾄ有無
                        End If
                        
                        .SetData(llngDoCnt, CMlngvsfColEngEmpID, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strEngEmpId)                          'ﾛｯﾄ担当者ID

                        .SetData(llngDoCnt, CMlngvsfColEngEmpName, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strEngEmpName)                        'ﾛｯﾄ担当者名
                        
                        .SetData(llngDoCnt, CMlngvsfColSendSBID, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strSendSBID)                          '送品先ID
                        
                        .SetData(llngDoCnt, CMlngvsfColSendSBName, _
                            Mid$(ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strSendSBName, 1, 1))            '送品先名
                        
                        .SetData(llngDoCnt, CMlngvsfColLostChipInfo, _
                            ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strLostChipInfo)                      '欠損ﾁｯﾌﾟ情報
                        
                        '@選択Tabによる処理分岐
                        Select Case tabSelect.SelectedIndex
                            
                            '@量産/ES(TFT)Tab選択時
                            Case CMlngPRTab0

        '@↓2013/11/28 (Thu) 11:19:14 T.Oide **************************************************
        '@                        '@ｵｰﾀﾞｰﾘｽﾄの「送品先」が"自SB:2A0"か
        '@                        If pstrSBID = vsfOrderList.Cell(flexcpText, vsfOrderList.Row, CMlngvsfOrderColSendSBID) Then
        '@                            '@ｵｰﾀﾞｰﾘｽﾄの「送品先」が"自SB:2A0"
        '@
        '@                            '@ﾛｯﾄﾘｽﾄの「送品先」が"実装:4x0"か
        '@                            If Mid$(.Cell(flexcpText, llngDoCnt, CMlngvsfColSendSBID), 1, 1) = CPstrFour Then
        '@                                '@ﾊﾞｯｸｶﾗｰを白にする
        '@                                .Cell(flexcpBackColor, llngDoCnt, CMlngvsfColNo, llngDoCnt, .Cols - 1) = _
        '@                                    vbWhite             'ﾎﾜｲﾄ
        '@                            Else
        '@                                '@ﾊﾞｯｸｶﾗｰをｸﾞﾚｰにする
        '@                                .Cell(flexcpBackColor, llngDoCnt, CMlngvsfColNo, llngDoCnt, .Cols - 1) = _
        '@                                    CPlngNotInputColor  'ｸﾞﾚｰ
        '@                            End If
        '@                        Else
        '@                            '@ｵｰﾀﾞｰﾘｽﾄの「送品先」が"自SB:2A0"以外の場合
        '@
        '@                            '@ｵｰﾀﾞｰﾘｽﾄに表示されている「送品先」と、ﾛｯﾄﾘｽﾄに表示されている「送品先」が
        '@                            '@同じ場合はﾊﾞｯｸｶﾗｰをﾎﾜｲﾄ、異なる場合はﾊﾞｯｸｶﾗｰをｸﾞﾚｰ。
        '@                            If vsfOrderList.Cell(flexcpText, vsfOrderList.Row, CMlngvsfOrderColSendSBID) = _
        '@                                .Cell(flexcpText, llngDoCnt, CMlngvsfColSendSBID) Then
        '@
        '@                                '@「送品先」がNULLの場合もｸﾞﾚｰ
        '@                                If .Cell(flexcpText, llngDoCnt, CMlngvsfColSendSBID) <> vbNullString Then
        '@                                    .Cell(flexcpBackColor, llngDoCnt, CMlngvsfColNo, llngDoCnt, .Cols - 1) = _
        '@                                        vbWhite             'ﾎﾜｲﾄ
        '@                                Else
        '@                                    .Cell(flexcpBackColor, llngDoCnt, CMlngvsfColNo, llngDoCnt, .Cols - 1) = _
        '@                                        CPlngNotInputColor  'ｸﾞﾚｰ
        '@                                End If
        '@                            Else
        '@                                '@ｵｰﾀﾞｰﾘｽﾄの「送品先」と、ﾛｯﾄﾘｽﾄの「送品先」が異なる場合
        '@
        '@                                .Cell(flexcpBackColor, llngDoCnt, CMlngvsfColNo, llngDoCnt, .Cols - 1) = _
        '@                                    CPlngNotInputColor  'ｸﾞﾚｰ
        '@                            End If
        '@                        End If
        '@↑2013/11/28 (Thu) 11:19:14 T.Oide **************************************************
                                '@-----------------------------------------------
                                '@ ﾌｫﾝﾄ色の設定
                                '@　①ﾁｯﾌﾟ品LOT：青色
                                '@-----------------------------------------------
                                If ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strSbArea = CPstrProductChip Then
                                    '@ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
                                    '@文字色を青色に変更
                                    cellRange = .GetCellRange(llngDoCnt, CMlngvsfColNo, llngDoCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle_FC_vbBlue
                                End If
                            
                            '@量産(ODF対向基板)Tab選択時
                            Case CMlngODFTab1
                                
                                '@PR/ESを条件に表示する為、ﾊﾞｯｸｶﾗｰの制御はなし
                                '@-----------------------------------------------
                                '@ ﾌｫﾝﾄ色の設定
                                '@　①ﾁｯﾌﾟ品LOT：青色
                                '@-----------------------------------------------
                                If ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strSbArea = CPstrProductChip Then
                                    '@ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
                                    '@文字色を青色に変更
                                    cellRange = .GetCellRange(llngDoCnt, CMlngvsfColNo, llngDoCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle_FC_vbBlue
                                End If
                                
                            '@試作/実験Tab選択時
                            Case CMlngZZTab2
                                
                                '@流動区分がPR/ES以外の場合
                                If .GetData(llngDoCnt, CMlngvsfColFlowClass) <> CPstrFlowClassPR And _
                                    .GetData(llngDoCnt, CMlngvsfColFlowClass) <> CPstrFlowClassES Then
                                    cellRange = .GetCellRange(llngDoCnt, CMlngvsfColNo, llngDoCnt, .Cols.Count - 1)
                                    '@-----------------------------------------------
                                    '@ ﾌｫﾝﾄ色の設定
                                    '@　①ﾁｯﾌﾟ品LOT：青色
                                    '@-----------------------------------------------
                                    If ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strSbArea = CPstrProductChip Then
                                        '@ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
                                        '@文字色を青色に変更
                                        cellRange.Style = newStyle_FC_vbBlue_BC_vbWhite
                                    Else
                                        cellRange.Style = newStyle_BC_vbWhite
                                    End If
                                Else
                                    cellRange = .GetCellRange(llngDoCnt, CMlngvsfColNo, llngDoCnt, .Cols.Count - 1)
                                    '@-----------------------------------------------
                                    '@ ﾌｫﾝﾄ色の設定
                                    '@　①ﾁｯﾌﾟ品LOT：青色
                                    '@-----------------------------------------------
                                    If ltypInvAcptLotListAns.typLotList(llngDoCnt-1).strSbArea = CPstrProductChip Then
                                        '@ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
                                        '@文字色を青色に変更
                                        cellRange.Style = newStyle_FC_vbBlue_BC_NotInputColor
                                    Else
                                        cellRange.Style = newStyle_BC_NotInputColor
                                    End If
                                End If
                        End Select
                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height = CMlngVsfHeight
                        
                        '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                    Loop

                    '@書式設定
                    .Cols(CMlngvsfColNo).TextAlign = TextAlignEnum.RightCenter                         '№
                    .Cols(CMlngvsfColCarrierID).TextAlign = TextAlignEnum.LeftCenter                   'ｷｬﾘｱID
                    .Cols(CMlngvsfColLotID).TextAlign = TextAlignEnum.LeftCenter                       'ﾛｯﾄID
                    .Cols(CMlngvsfColFlowClass).TextAlign = TextAlignEnum.LeftCenter                   '種別
                    .Cols(CMlngvsfColWFNum).TextAlign = TextAlignEnum.RightCenter                      'WF枚数
                    .Cols(CMlngvsfColChipNum).TextAlign = TextAlignEnum.RightCenter                    'CHIP枚数
                    .Cols(CMlngvsfColComments).TextAlign = TextAlignEnum.LeftCenter                    'ｺﾒﾝﾄ内容
                    .Cols(CMlngvsfColCommentDisp).TextAlign = TextAlignEnum.LeftCenter                 'ｺﾒﾝﾄ有無
                    .Cols(CMlngvsfColEngEmpID).TextAlign = TextAlignEnum.LeftCenter                    'ﾛｯﾄ担当者ID
                    .Cols(CMlngvsfColEngEmpName).TextAlign = TextAlignEnum.LeftCenter                  'ﾛｯﾄ担当者名
                    .Cols(CMlngvsfColSendSBID).TextAlign = TextAlignEnum.LeftCenter                    '送品先ID
                    .Cols(CMlngvsfColSendSBName).TextAlign = TextAlignEnum.LeftCenter                  '送品先名
                    .Cols(CMlngvsfColLostChipInfo).TextAlign = TextAlignEnum.RightCenter               '欠損ﾁｯﾌﾟ情報
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngDoCnt = 0 To mtypChgSort.lngCnt - 1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort.typChgSortList(llngDoCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngDoCnt).lngOrder
                            .Sort(SortFlags.UseColSort,mtypChgSort.typChgSortList(llngDoCnt).lngCol)
                        Next llngDoCnt
                    End If
                
                    '@行列のﾏｳｽでの変更を不可設定にする
                    .AllowResizing =  AllowResizingEnum.None 'flexResizeNone
                    
                    .Row = 0
                    AddHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange
                    AddHandler vsfLotList.RowColChange, AddressOf vsfLotList_RowColChange
                    AddHandler vsfLotList.EnterCell, AddressOf vsfLotList_EnterCell

                    '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngDoCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ｷｬﾘｱID、大工程、小工程が同じ場合
                            If .GetData(llngDoCnt, CMlngvsfColCarrierID) = mtypChgSort.strKey Then
                                .Row = llngDoCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                Call pubVsfBeforeSort(vsfLotList, CMlngvsfColNo)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                Call pubVsfAfterSort(vsfLotList, CMlngvsfColNo, cmdUP, cmdDown)
                                Exit For
                            End If
                        Next llngDoCnt
                    End If
                    
                    '@描画ﾛｯｸ解除
                    .Redraw = True
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                                
                    '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfLotList)
                Else
                    .Redraw = False
                    '@初期化
                    .Rows.Count = .Rows.Fixed
                    .Row = 0
                    .Redraw = True
                End If
            End With

            '@TFT基板在庫一覧ｽｸﾛｰﾙﾎﾞﾀﾝの設定
            '@ｿｰﾄ前処理
            Call pubVsfBeforeSort(vsfLotList, CMlngvsfColNo)
            
            '@ｿｰﾄ後処理
            Call pubVsfAfterSort(vsfLotList, CMlngvsfColNo, cmdUP, cmdDown, False)

            '@該当件数
            lblLotCnt.Text = Format$(llngInvAcptLotListCnt, CPstrDateFormatKanma)

            '@現在日時表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvvsfLotList_Disp"     '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnLotmake_Chk
    '機　能：確定ﾎﾞﾀﾝの活性化ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:投入可能/False:情報不足
    '作成日：2004/07/28 (Wed) 19:13:53 S.Deguchi
    '更新日：2013/11/28 (Thu) 15:53:38 T.Oide
    '備　考：
    '　　　：2004/11/24 (Wed) 18:09:37 S.Deguchi    技術担当者の処理を追加
    '　　　：2004/11/29 (Mon) 16:42:10 S.Deguchi    技術担当者の処理を削除(Null許可の為)
    '　　　：2005/06/06 (Mon) 09:49:54 S.Deguchi    ATLAS連携対応で量産Tab選択時の処理を追加
    '　　　：2005/06/27 (Mon) 14:43:40 S.Deguchi    ﾕｰｻﾞｰﾌﾟﾛｾｽ処理見直し
    '　　　：2006/09/14 (Thu) 15:23:47 N.Kojima     送品先追加に伴い、確定ﾎﾞﾀﾝ押下可能となる条件を追加。(案件№01452)
    '　　　：2006/11/06 (Mon) 14:52:44 T.Kitagawa   量産(ODF対向基板)対応(案件№01544)
    '　　　：2007/09/12 (Wed) 08:41:21 N.Kasai      流動区分ES対応(№02142)
    '　　　：2007/12/25 (Tue) 18:43:03 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2013/11/28 (Thu) 15:53:38 T.Oide       R11-01 GNS対応
    Private Function prvblnLotmake_Chk() As Boolean

        Try

            '@初期化
            prvblnLotmake_Chk = False
            
            '@選択Tabによる処理分岐
            Select Case tabSelect.SelectedIndex
                
                '@量産Tab選択時
                Case CMlngPRTab0
                    
                    '@優先度のNullﾁｪｯｸ
                    If cmbPrioSel.Text = vbNullString Then
                        Exit Function
                    End If
                    
                    '@流動区分のﾁｪｯｸ
                    If cmbTftFlowClass.ListIndex = -1 Then
                        Exit Function
                    End If
                    
        '@↓2013/11/28 (Thu) 11:22:29 T.Oide **************************************************
        '@            '@TFT基板在庫一覧の選択状況
        '@            With vsfLotList
        '@
        '@                '@ﾀｲﾄﾙ以外を選択されている場合
        '@                If .Row <> 0 Then
        '@
        '@                    '@ ① 選択されている箇所のﾛｯﾄIDが空欄ではない。
        '@                    '@ ② ｵｰﾀﾞｰﾘｽﾄの「送品先」とﾛｯﾄﾘｽﾄの「送品先」がNULLではない。
        '@                    If .Cell(flexcpText, .Row, CMlngvsfColLotID) <> vbNullString And _
        '@                        vsfOrderList.Cell(flexcpText, vsfOrderList.Row, CMlngvsfOrderColSendSBID) <> vbNullString And _
        '@                        .Cell(flexcpText, .Row, CMlngvsfColSendSBID) <> vbNullString Then
        '@
        '@                        '@選択ｵｰﾀﾞｰの送品先が自SBか
        '@                        If vsfOrderList.Cell(flexcpText, vsfOrderList.Row, CMlngvsfOrderColSendSBID) = pstrSBID Then
        '@                            '@選択ｵｰﾀﾞｰの「送品先」が自SBの場合
        '@
        '@                            '@ﾛｯﾄﾘｽﾄに表示されている「送品先」が実装(4x0)か
        '@                            If Mid$(.Cell(flexcpText, .Row, CMlngvsfColSendSBID), 1, 1) = CPstrFour Then
        '@                                '@結果OKを返す
        '@                                prvblnLotmake_Chk = True
        '@                            End If
        '@                        Else
        '@                            '@選択ｵｰﾀﾞｰの「送品先」が自SB以外の場合
        '@
        '@                            '@選択ｵｰﾀﾞｰの「送品先」と、選択ﾛｯﾄの「送品先」が同じか
        '@                            If vsfOrderList.Cell(flexcpText, vsfOrderList.Row, CMlngvsfOrderColSendSBID) = _
        '@                                .Cell(flexcpText, .Row, CMlngvsfColSendSBID) Then
        '@
        '@                                '@結果OKを返す
        '@                                prvblnLotmake_Chk = True
        '@                            End If
        '@                        End If
        '@                    End If
        '@                End If
        '@
        '@            End With
        '@------------------------------------------------------------------------------

                    '@確定ﾁｪｯｸ
                    prvblnLotmake_Chk = prvblnKakutei_Chk(cmbTftProduct, cmbTftFlowClass)


        '@↑2013/11/28 (Thu) 11:22:29 T.Oide **************************************************
                
                '@量産(ODF対向基板)Tab選択時
                Case CMlngODFTab1
                    
        '@↓2013/11/28 (Thu) 14:05:17 T.Oide **************************************************
        '@            '@投入機種のNullﾁｪｯｸ
        '@            If cmbOdfProduct.Text = vbNullString Then
        '@                Exit Function
        '@            End If
        '@
        '@            '@流動区分のﾁｪｯｸ
        '@            If cmbOdfFlowClass.ListIndex = -1 Then
        '@                Exit Function
        '@            End If
        '@
        '@            '@優先度のNullﾁｪｯｸ
        '@            If cmbPrioSel.Text = vbNullString Then
        '@                Exit Function
        '@            End If
        '@
        '@            '@TFT基板在庫一覧の選択状況
        '@            With vsfLotList
        '@
        '@                '@ﾀｲﾄﾙ以外を選択されている場合
        '@                If .Row <> 0 Then
        '@
        '@                    If .Cell(flexcpText, .Row, CMlngvsfColLotID) <> vbNullString And _
        '@                        .Cell(flexcpText, .Row, CMlngvsfColFlowClass) = cmbOdfFlowClass.Text Then
        '@
        '@                        '@結果OKを返す
        '@                        prvblnLotmake_Chk = True
        '@                    End If
        '@                End If
        '@            End With
        '@------------------------------------------------------------------------------------

                    '@確定ﾁｪｯｸ
                    prvblnLotmake_Chk = prvblnKakutei_Chk(cmbOdfProduct, cmbOdfFlowClass)

        '@↑2013/11/28 (Thu) 14:05:17 T.Oide **************************************************
                
                '@試作/実験Tab選択時
                Case CMlngZZTab2
                    
                    '@投入機種のNullﾁｪｯｸ
                    If cmbProduct.Text = vbNullString Then
                        Exit Function
                    End If
                    
                    '@投入種別のNullﾁｪｯｸ
                    If cmbFlowClass.Text = vbNullString Then
                        Exit Function
                    End If
                    
                    '@ﾁｯﾌﾟ電特のNullﾁｪｯｸ
                    If cmbChipElectric.Enabled = True And _
                        cmbChipElectric.Text = vbNullString Then
                        Exit Function
                    End If
                    
                    '@ｴﾝﾄﾘ情報のNullﾁｪｯｸ
                    If optThrowUser0.Checked = True Then
                        '@機種ｴﾝﾄﾘが選択されている場合
                        
                        If lblEntryID.Text = vbNullString Then
                            '@機種ｴﾝﾄﾘIDが空欄の場合にはNG
                            Exit Function
                        End If
                    Else
                        '@ﾕｰｻﾞｰﾌﾟﾛｾｽが選択されている場合
                        If txtUserEntry.Text <> vbNullString _
                            And lblUserEntry.Text <> vbNullString Then
                            '@ﾕｰｻﾞｰﾌﾟﾛｾｽID,名が共に空欄以外の場合にはOK
                        
                        Else
                            '@ﾕｰｻﾞｰﾌﾟﾛｾｽID,名が空欄の場合にはNG
                            Exit Function
                            
                        End If
                    End If
                    
                    '@優先度のNullﾁｪｯｸ
                    If cmbPrioSel.Text = vbNullString Then
                        Exit Function
                    End If
                    
                    '@TFT基板在庫一覧の選択状況
                    With vsfLotList
                        '@ﾀｲﾄﾙ以外を選択されている場合
                        If .Row > 0 Then
                            '@選択されている箇所のﾛｯﾄIDが空欄でなければOKとする
                            If .GetData(.Row, CMlngvsfColLotID) <> vbNullString And _
                                .GetData(.Row, CMlngvsfColFlowClass) <> CPstrFlowClassPR And _
                                .GetData(.Row, CMlngvsfColFlowClass) <> CPstrFlowClassES Then
                                
                                '@結果OKを返す
                                prvblnLotmake_Chk = True
                            End If
                        End If
                    End With
            End Select

            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnLotmake_Chk"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvFocus_Set
    '機　能：ﾌｫｰｶｽの戻り位置を設定
    '引　数：lobjControl    ：VSFlexGridオブジェクト
    '　　　：lstrKeyID      ：KeyID
    '　　　：llngKeyColNo   ：KeyIDのCol位置
    '　　　：llngTopRow：先頭行
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 14:34:29 S.Deguchi
    '更新日：2004/08/03 (Tue) 14:34:29
    '備　考：ﾛｯﾄNoを検索してHitした場合は該当行にﾌｫｰｶｽｾｯﾄする。ない場合はｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
    Private Sub prvFocus_Set(ByVal lobjControl As C1FlexGrid, _
                             ByVal lstrKeyID As String, _
                             ByRef llngKeyColNo As Integer, _
                             ByVal llngTopRow As Integer)

        Dim llngRowCnt     As Integer      'ｶｳﾝﾄ

        Try

            With lobjControl
                '@確定ﾎﾞﾀﾝ押下前のﾌｫｰｶｽ位置を検索
                For llngRowCnt = 0 To .Rows.Count - 1
                    '@ﾛｯﾄNo検索
                    If .GetData(llngRowCnt, llngKeyColNo) = lstrKeyID Then
                        
                        '@行の選択範囲を設定
                        .Row = llngRowCnt
                        
                        '@選択行を表示
                        .ShowCell(llngRowCnt, llngKeyColNo)
                        .TopRow = llngTopRow
                        Exit Sub
                    End If
                Next llngRowCnt
                
                '@ﾌｫｰｶｽｾｯﾄ
                '@明細行が１件もない場合ﾌｫｰｶｽの戻り位置を制御
                If .Enabled = False Then
                    Call pubSetFocus(cmdClose)
                Else
                    Call pubSetFocus(lobjControl)
                End If
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvFocus_Set"           '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvblnUserEntry_Chk
    '機　能：確定ﾎﾞﾀﾝﾁｪｯｸ
    '引　数：なし
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2004/08/30 (Mon) 16:52:14 N.Kasai
    '更新日：2006/11/06 (Mon) 15:02:59 T.Kitagawa
    '備　考：
    '　　　：2004/09/27 (Mon) 10:47:33 S.Deguchi    ﾁｪｯｸに機種ｴﾝﾄﾘ部分を追加
    '　　　：2006/11/06 (Mon) 15:02:59 T.Kitagawa   量産(ODF対向基板)対応(案件№01544)
    Private Function prvblnUserEntry_Chk() As Boolean

        Try

            '@初期化
            prvblnUserEntry_Chk = False
           
           '@選択Tab荷夜処理分岐
            Select Case tabSelect.SelectedIndex
                '@量産
                Case CMlngPRTab0
                
                '@量産(ODF対向基板)
                Case CMlngODFTab1
                
                '@試作/実験
                Case CMlngZZTab2
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの選択先によるﾁｪｯｸ
                    If optThrowUser0.Checked = True Then
                        '@機種ｴﾝﾄﾘ
                        If Trim$(lblEntryID.Text) = vbNullString Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                        
                            '@"設定されていない項目があります。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@機種ｴﾝﾄﾘﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdEntry)
                            
                            Exit Function
                        End If
                    Else
                        'ﾕｰｻﾞﾌﾟﾛｾｽ
                        If Trim$(txtUserEntry.Text) = vbNullString Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                        
                            '@"設定されていない項目があります。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@ﾕｰｻﾞﾌﾟﾛｾｽにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtUserEntry)
                            
                            Exit Function
                        End If
                    End If
            End Select
            
            '@正常
            prvblnUserEntry_Chk = True
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvblnUserEntry_Chk"    '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '@↓2013/11/28 (Thu) 11:23:02 T.Oide **************************************************
    '@'関数名：prvvsfOrderList_Init
    '@'機　能：ｵｰﾀﾞｰﾘｽﾄ初期化処理
    '@'引　数：なし
    '@'戻り値：なし
    '@'作成日：2005/05/16 (Mon) 11:03:36 S.Deguchi
    '@'更新日：2006/09/13 (Wed) 16:05:56 N.Kojima
    '@'備　考：
    '@'　　　：2006/09/13 (Wed) 16:05:56 N.Kojima     量産ﾘｽﾄのColの変更(数量削除、送品先追加)に伴い、処理修正。(案件№01452)
    '@Public Sub prvvsfOrderList_Init()
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    With vsfOrderList
    '@        '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
    '@        .Clear
    '@
    '@        '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
    '@        .ExplorerBar = flexExSortShow
    '@
    '@        '@初期行数設定
    '@        .Rows = .FixedRows
    '@
    '@        '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
    '@        .FillStyle = flexFillRepeat
    '@
    '@        '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
    '@        .AllowBigSelection = False
    '@
    '@        '@ﾏｳｽでｾﾙ範囲選択不可
    '@        .AllowSelection = False
    '@
    '@        '@ﾌｫﾝﾄｻｲｽﾞ指定(=14)
    '@        .FontSize = CMlngVsfFontSize
    '@
    '@        '@一覧表の表題設定
    '@        .Select CMlngVsfRowTitle, CMlngvsfOrderColNo, CMlngVsfRowTitle, .Cols - 1
    '@        .CellForeColor = vbYellow                                                                       '文字色
    '@        .CellBackColor = CPlngBlueColor                                                                 '背景色
    '@        .CellFontSize = CMlngVsfHFontSize                                                               'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    '@
    '@        '@ﾀｲﾄﾙ設定
    '@        .Cell(flexcpText, CMlngVsfRowTitle, CMlngvsfOrderColNo) = CMstrvsfOrderTColNo                    'No.
    '@        .Cell(flexcpText, CMlngVsfRowTitle, CMlngvsfOrderColThrowInDate) = CMstrvsfOrderTColThrowInDate  '投入予定日
    '@        .Cell(flexcpText, CMlngVsfRowTitle, CMlngvsfOrderColPDID) = CMstrvsfOrderTColPDID                '機種
    '@        .Cell(flexcpText, CMlngVsfRowTitle, CMlngvsfOrderColLRFlag) = CMstrvsfOrderTColLRFlag            'L/R
    '@        .Cell(flexcpText, CMlngVsfRowTitle, CMlngvsfOrderColSendSBName) = CMstrvsfOrderTColSendSBName    '送品先名(和名)
    '@        .Cell(flexcpText, CMlngVsfRowTitle, CMlngvsfOrderColSendSBID) = CMstrvsfOrderTColSendSBID        '送品先ID
    '@        .Cell(flexcpText, CMlngVsfRowTitle, CMlngvsfOrderColOrderNo) = CMstrvsfOrderTColOrderNo          'ｵｰﾀﾞｰ№
    '@        .Cell(flexcpText, CMlngVsfRowTitle, CMlngvsfOrderColParentPDID) = CMstrvsfOrderTColParentPDID    '親機種
    '@
    '@        '@列幅設定
    '@        .ColWidth(CMlngvsfOrderColNo) = CMlngvsfOrderWColNo                                             'No.
    '@        .ColWidth(CMlngvsfOrderColThrowInDate) = CMlngvsfOrderWColThrowInDate                           '投入予定日
    '@        .ColWidth(CMlngvsfOrderColPDID) = CMlngvsfOrderWColPDID                                         '機種
    '@        .ColWidth(CMlngvsfOrderColLRFlag) = CMlngvsfOrderWColLRFlag                                     'L/R
    '@        .ColWidth(CMlngvsfOrderColSendSBName) = CMlngvsfOrderWColSendSBName                             '送品先名(和名)
    '@        .ColWidth(CMlngvsfOrderColSendSBID) = CMlngvsfOrderWColSendSBID                                 '送品先ID
    '@        .ColWidth(CMlngvsfOrderColOrderNo) = CMlngvsfOrderWColOrderNo                                   'ｵｰﾀﾞｰ№
    '@        .ColWidth(CMlngvsfOrderColParentPDID) = CMlngvsfOrderWColParentPDID                             '親機種
    '@
    '@        '@表示位置の設定
    '@        .Cell(flexcpAlignment, CMlngVsfRowTitle, CMlngVsfColTitle, .Rows - 1, .Cols - 1) _
    '@            = flexAlignCenterCenter                                                                     'ﾀｲﾄﾙ(中央寄せ中央揃え)
    '@
    '@        '@ﾍｯﾀﾞｰの高さを設定
    '@        .RowHeight(CMlngVsfRowTitle) = CMlngVsfHHeight                                                  '高さ
    '@
    '@        '@非表示項目の設定
    '@        .ColHidden(CMlngvsfOrderColLRFlag) = True                                                       'L/R
    '@        .ColHidden(CMlngvsfOrderColParentPDID) = True                                                   '親機種
    '@        .ColHidden(CMlngvsfOrderColSendSBID) = True                                                     '送品先ID
    '@
    '@        '@ﾛｯｸ
    '@        .Enabled = False
    '@
    '@        '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
    '@        .FocusRect = flexFocusNone
    '@    End With
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey             '機能ID
    '@        .strProcName = "prvvsfOrderList_Init"       '処理名
    '@        .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2013/11/28 (Thu) 11:23:02 T.Oide **************************************************

    '@↓2013/11/28 (Thu) 11:24:04 T.Oide **************************************************
    '@'関数名：prvvsfOrderList_Disp
    '@'機　能：ｵｰﾀﾞｰﾘｽﾄ表示
    '@'引　数：mtypAtlsOrderList：ｵｰﾀﾞｰﾘｽﾄ構造体
    '@'戻り値：なし
    '@'作成日：2005/05/16 (Mon) 15:27:40 S.Deguchi
    '@'更新日：2009/12/02 (Wed) 11:35:53 H.Hayashi
    '@'備　考：
    '@'　　　：2005/07/21 (Thu) 15:54:16 N.Kasai      L/R表示機能追加
    '@'　　　：2005/07/28 (Thu) 13:13:19 N.Kasai      ｽｸﾛｰﾙﾎﾞﾀﾝ制御修正
    '@'　　　：2009/02/25 (Wed) 16:57:03 N.Kojima     送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。(案件№03402)
    '@'　　　：2009/12/02 (Wed) 11:35:53 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    '@Private Sub prvvsfOrderList_Disp(ByRef mtypAtlsOrderList As AtlsOrderList)
    '@
    '@    Dim llngDoCnt   As Long     'ｶｳﾝﾄ
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    With vsfOrderList
    '@
    '@        '@ﾃﾞｰﾀがあるか
    '@        If mtypAtlsOrderList.lngAltsOrderListCnt <> 0 Then
    '@            '@格納ﾃﾞｰﾀがあるの場合
    '@
    '@            '@まずｸﾘｱ
    '@            .Rows = .FixedRows
    '@
    '@            '@描画ﾛｯｸ
    '@            .Redraw = flexRDNone
    '@
    '@            '@行数設定
    '@            .Rows = mtypAtlsOrderList.lngAltsOrderListCnt + 1
    '@
    '@            '@行列のﾏｳｽでの変更を不可設定にする
    '@            .AllowUserResizing = flexResizeNone
    '@
    '@            '@ｶｳﾝﾀの初期化
    '@            llngDoCnt = 1
    '@
    '@            Do While .Rows > llngDoCnt
    '@                '@ｵｰﾀﾞｰ一覧表示情報設定
    '@                .Cell(flexcpText, llngDoCnt, CMlngvsfOrderColNo) = llngDoCnt                            '通し番号
    '@
    '@                .Cell(flexcpText, llngDoCnt, CMlngvsfOrderColThrowInDate) _
    '@                    = Format$(mtypAtlsOrderList.typOrderList(llngDoCnt).strPlanThrowinDate, CPstrDateTimeYMD) '投入予定日
    '@
    '@                .Cell(flexcpText, llngDoCnt, CMlngvsfOrderColPDID) _
    '@                    = mtypAtlsOrderList.typOrderList(llngDoCnt).strPdID                                 '機種
    '@
    '@                .Cell(flexcpText, llngDoCnt, CMlngvsfOrderColLRFlag) _
    '@                    = mtypAtlsOrderList.typOrderList(llngDoCnt).strLcDirection                          'L/Rﾌﾗｸﾞ
    '@
    '@                .Cell(flexcpText, llngDoCnt, CMlngvsfOrderColSendSBName) _
    '@                    = Mid$(mtypAtlsOrderList.typOrderList(llngDoCnt).strSendSBName, 1, 1)               '送品先名(和名)
    '@
    '@                .Cell(flexcpText, llngDoCnt, CMlngvsfOrderColSendSBID) _
    '@                    = mtypAtlsOrderList.typOrderList(llngDoCnt).strSendSBID                             '送品先ID
    '@
    '@                .Cell(flexcpText, llngDoCnt, CMlngvsfOrderColOrderNo) _
    '@                    = mtypAtlsOrderList.typOrderList(llngDoCnt).strOrderNum                             'ｵｰﾀﾞｰ№
    '@
    '@                .Cell(flexcpText, llngDoCnt, CMlngvsfOrderColParentPDID) _
    '@                    = mtypAtlsOrderList.typOrderList(llngDoCnt).strParentPDID                           '親機種
    '@
    '@                '@L/Rによる文字色変更
    '@                Select Case .Cell(flexcpText, llngDoCnt, CMlngvsfOrderColLRFlag)
    '@                    Case CPstrPDIDL
    '@                         '@ｾﾙ背景色変更
    '@                        .Cell(flexcpBackColor, llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols - 1) _
    '@                            = CPlngLColor                                                               'Lｶﾗｰ(水色)
    '@                    Case CPstrPDIDR
    '@                         '@ｾﾙ背景色変更
    '@                        .Cell(flexcpBackColor, llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols - 1) _
    '@                            = CPlngRColor                                                               'Rｶﾗｰ(ﾋﾟﾝｸ)
    '@                    Case Else
    '@                        '@ｾﾙ背景色変更
    '@                        .Cell(flexcpBackColor, llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols - 1) _
    '@                            = vbWhite                                                                   '初期(白)
    '@                End Select
    '@
    '@'@↓2009/02/24 (Tue) 15:48:35 N.Kojima **************************************************
    '@
    '@                '@-----------------------------------------------
    '@                '@ ﾌｫﾝﾄ色の設定
    '@                '@　①ﾁｯﾌﾟ品LOT：青色
    '@                '@-----------------------------------------------
    '@'@↓2009/12/02 (Wed) 11:36:49 H.Hayashi **************************************************
    '@                '@ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"か
    '@'                If Left$(mtypAtlsOrderList.typOrderList(llngDoCnt).strSendSBID, 1) = CPstrProductChip Then
    '@
    '@                If mtypAtlsOrderList.typOrderList(llngDoCnt).strSbArea = CPstrProductChip Then
    '@
    '@                    '@ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
    '@'@↑2009/12/02 (Wed) 11:36:49 H.Hayashi **************************************************
    '@
    '@                    '@文字色を青色に変更
    '@                    .Cell(flexcpForeColor, llngDoCnt, CMlngvsfOrderColNo, _
    '@                        llngDoCnt, CMlngvsfOrderColParentPDID) = vbBlue
    '@
    '@                End If
    '@
    '@'@↑2009/02/24 (Tue) 15:48:35 N.Kojima **************************************************
    '@
    '@                '@ｽﾛｯﾄの高さの設定
    '@                .RowHeight(llngDoCnt) = CMlngVsfHeight
    '@
    '@                '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
    '@                llngDoCnt = llngDoCnt + 1
    '@            Loop
    '@
    '@            '@書式設定
    '@            .ColAlignment(CMlngvsfOrderColNo) = flexAlignRightCenter                        '№(右寄せ中央揃え)
    '@            .ColAlignment(CMlngvsfOrderColThrowInDate) = flexAlignLeftCenter                '投入予定日(左寄せ中央揃え)
    '@            .ColAlignment(CMlngvsfOrderColPDID) = flexAlignLeftCenter                       '機種(左寄せ中央揃え)
    '@            .ColAlignment(CMlngvsfOrderColLRFlag) = flexAlignLeftCenter                     'L/R(左寄せ中央揃え)
    '@            .ColAlignment(CMlngvsfOrderColSendSBName) = flexAlignLeftCenter                 '送品先名(和名)(右寄せ中央揃え)
    '@            .ColAlignment(CMlngvsfOrderColSendSBID) = flexAlignLeftCenter                   '送品先ID(右寄せ中央揃え)
    '@            .ColAlignment(CMlngvsfOrderColOrderNo) = flexAlignLeftCenter                    'ｵｰﾀﾞｰ№(左寄せ中央揃え)
    '@
    '@            '@ﾕｰｻﾞによりｿｰﾄされている場合
    '@            If mtypChgSortOrder.lngCnt > 0 Then
    '@                '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
    '@                For llngDoCnt = 1 To mtypChgSortOrder.lngCnt
    '@                    '@該当行をｿｰﾄ
    '@                    .Cell(flexcpSort, .FixedRows, mtypChgSortOrder.typChgSortList(llngDoCnt).lngCol, .Rows - 1) _
    '@                        = mtypChgSortOrder.typChgSortList(llngDoCnt).lngOrder
    '@                Next llngDoCnt
    '@            End If
    '@
    '@            '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がある場合
    '@            If mtypChgSortOrder.strKey <> vbNullString Then
    '@                For llngDoCnt = .FixedRows To .Rows - 1
    '@                    '@ｷｬﾘｱID、大工程、小工程が同じ場合
    '@                    If .Cell(flexcpText, llngDoCnt, CMlngvsfOrderColOrderNo) = mtypChgSortOrder.strKey Then
    '@                        .Row = llngDoCnt
    '@                        '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
    '@                        Call pubVsfBeforeSort(vsfOrderList, CMlngvsfOrderColOrderNo)
    '@'@↓2013/11/27 (Wed) 19:45:22 T.Oide **************************************************
    '@'@                        '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
    '@'@                        Call pubVsfAfterSort(vsfOrderList, CMlngvsfOrderColOrderNo, cmdOrderUp, cmdOrderDown)
    '@'@↑2013/11/27 (Wed) 19:45:22 T.Oide **************************************************
    '@                        Exit For
    '@                    End If
    '@                Next llngDoCnt
    '@            End If
    '@
    '@            .Select CMlngVsfRowTitle, CMlngVsfColTitle
    '@
    '@            '@描画ﾛｯｸ解除
    '@            .Redraw = flexRDDirect
    '@
    '@            '@ﾛｯｸ解除
    '@            .Enabled = True
    '@        Else
    '@            '@ｸﾘｱ
    '@            .Rows = .FixedRows
    '@        End If
    '@    End With
    '@
    '@    '@ｵｰﾀﾞｰ一覧ｽｸﾛｰﾙﾎﾞﾀﾝの設定
    '@    vsfOrderList.Select CMlngVsfRowTitle, CMlngVsfColTitle
    '@
    '@    '@ｿｰﾄ前処理
    '@    Call pubVsfBeforeSort(vsfOrderList, CMlngvsfOrderColOrderNo)
    '@
    '@'@↓2013/11/27 (Wed) 19:45:42 T.Oide **************************************************
    '@'@    '@ｿｰﾄ後処理
    '@'@    Call pubVsfAfterSort(vsfOrderList, CMlngvsfOrderColOrderNo, cmdOrderUp, cmdOrderDown, False)
    '@'@↑2013/11/27 (Wed) 19:45:42 T.Oide **************************************************
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey             '機能ID
    '@        .strProcName = "prvvsfOrderList_Disp"       '処理名
    '@        .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2013/11/28 (Thu) 11:24:04 T.Oide **************************************************

    '関数名：prvblnKakutei_Chk
    '機　能：TFTとODFの量産Tabの「確定」有効/無効ﾁｪｯｸ
    '引　数：objProduct：ｺﾝﾎﾞ機種
    '　　　：objFlowClass：ｺﾝﾎﾞ流動区分
    '戻り値：True：ボタン有効、False：ボタン無効
    '作成日：2013/11/28 (Thu) 14:00:15 T.Oide
    '更新日：2013/11/28 (Thu) 14:00:15
    '備　考：
    Private Function prvblnKakutei_Chk(ByRef objProduct As SEComboBoxEx.ComboBoxEx, ByRef objFlowClass As SECmbIchiran.ComboIchiran) As Boolean

        Try

            '@初期化
            prvblnKakutei_Chk = False
            
            '@投入機種のNullﾁｪｯｸ
            If objProduct.Text = vbNullString Then
                Exit Function
            End If
            
            '@流動区分のﾁｪｯｸ
            If objFlowClass.ListIndex = -1 Then
                Exit Function
            End If
            
            '@優先度のNullﾁｪｯｸ
            If cmbPrioSel.Text = vbNullString Then
                Exit Function
            End If

            '@TFT基板在庫一覧の選択状況
            With vsfLotList
                
                '@ﾀｲﾄﾙ以外を選択しているか
                If .Row > 0 Then
                    
                    '@選択行のLotIDは空以外で流動区分はｺﾝﾎﾞの流動区分と同じか
                    If .GetData(.Row, CMlngvsfColLotID) <> vbNullString And _
                       .GetData(.Row, CMlngvsfColFlowClass) = objFlowClass.Text Then
                        
                        '@結果OKを返す
                        prvblnKakutei_Chk = True
                        
                    End If
                
                End If
                
            End With

            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvblnKakutei_Chk"    '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvButton_chk
    '機　能：確定と送品先変更のﾎﾞﾀﾝの有効/無効を制御する
    '引　数：なし
    '戻り値：
    '作成日：2013/11/28 (Thu) 17:10:26 T.Oide
    '更新日：2013/11/28 (Thu) 17:10:26
    '備　考：
    Private Sub prvButtonCtrl()

        Dim lblnAns     As Boolean

        Try

                '@確定ﾎﾞﾀﾝの有効/無効ﾁｪｯｸを行う
                lblnAns = prvblnLotmake_Chk()
                
                '@結果判定
                If lblnAns = True Then
                
                    '@投入確定ﾎﾞﾀﾝ有効
                    cmdLotMake.Enabled = True
                    
                    '@量産/ES(TFT)のタブか
                    If tabSelect.SelectedIndex = CMlngPRTab0 Then
                        '@送品先変更ﾎﾞﾀﾝ有効
                        cmdChangeSendSB.Enabled = True
                    End If
                
                Else
                
                    '@投入確定ﾎﾞﾀﾝ無効
                    cmdLotMake.Enabled = False
                    
                    '@送品先変更ﾎﾞﾀﾝ無効
                    cmdChangeSendSB.Enabled = False
                
                End If
                    
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvblnKakutei_Chk"    '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraOdfThrowIn.Paint, fraPDEntry.Paint, fraTFT.Paint, fraTftThrowIn.Paint, fraThrowIn.Paint, fraUserEntry.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfLotList.BeforeDoubleClick

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

    '関数名：cursor_Enter
    '機　能 ： 項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles tabSelect.Enter, _
            cmbTftProduct.Enter, cmbTftFlowClass.Enter, cmbOdfProduct.Enter, cmbOdfFlowClass.Enter, cmbProduct.Enter, cmbFlowClass.Enter, _
            cmbChipElectric.Enter, optThrowUser1.Enter, optThrowUser0.Enter, cmdEntry.Enter, txtUserEntry.Enter, cmdUserEntry.Enter, _
            cmdLotList.Enter, vsfLotList.Enter, cmdDown.Enter, cmdUp.Enter, _
            cmbPrioSel.Enter, cmbLotManager.Enter, txtWorkMemo.Enter, cmdMemoDown.Enter, cmdMemoUp.Enter, _
            cmdClose.Enter, cmdChangeSendSB.Enter, cmdComments.Enter, cmdClear.Enter, cmdLotMake.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '自動Validate = OFF
            Case cmdClose.Name, cmdComments.Name
                Me.AutoValidate = AutoValidate.Disable

            '自動Validate = ON
            Case Else
                Me.AutoValidate = AutoValidate.EnablePreventFocusChange
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
    Private Sub tabList_Deselecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles tabSelect.Deselecting

        '処理中の場合またはタブ切り替えが無効の場合はタブ選択をキャンセルする
        If Me.buttonProcessing = True OrElse mblnTabSelectEnabled = False Then
            e.Cancel = True
            mblnTabSelectEnabled = True
        End If

    End Sub


End Class
