'ﾌｧｲﾙ名：xxEN00M1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：モニタロット一覧　メインフォーム
'作成日：2004/07/29 (Thu) 11:47:34 T.Kitagawa
'更新日：2019/06/10 (Mon) 09:47:14 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00M1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00M1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00M1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00M1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00M1)
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
    '======================================Public===========================================
    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '@↓2019/06/06 (Thu) 15:15:36 Y.Yoneyama **************************************************
    'Private Const CMstrlot_mcgplotlistVer       As String = "03.01"                     '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ取得
    Private Const CMstrlot_mcgplotlistVer       As String = "04.00"                     '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ取得
    '@↑2019/06/06 (Thu) 15:15:36 Y.Yoneyama **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN00M1              'ﾛｰｶﾙ機能ID

    '@ﾌﾚｯｸｽｸﾞﾘｯﾄﾞのｶﾗﾑ定数
    Private Const CMlngGridTitleHeight          As Integer = 20                         'ﾀｲﾄﾙの高さ
    Private Const CMlngGridRowHeight            As Integer = 19                         '1明細の高さ
    Private Const CMlngGridTitleCol             As Integer = 0                          'ﾀｲﾄﾙ列

    '@製品ﾛｯﾄ/ﾓﾆﾀﾛｯﾄ情報(列定義)
    Private Const CMlngvsfLotNoC                As Integer = 0                          '№
    Private Const CMlngvsfLotWpNoC              As Integer = 1                          '装置№
    Private Const CMlngvsfLotCarrierIdC         As Integer = 2                          'ｷｬﾘｱID
    Private Const CMlngvsfLotLotIdC             As Integer = 3                          'ﾛｯﾄID
    Private Const CMlngvsfLotFlowClassC         As Integer = 4                          '種別
    Private Const CMlngvsfLotPriorityC          As Integer = 5                          '優先順位
    Private Const CMlngvsfLotWfNumC             As Integer = 6                          'WF枚数
    Private Const CMlngvsfLotRecipeIdC          As Integer = 7                          'ﾚｼﾋﾟID
    Private Const CMlngvsfLotLimitTimeC         As Integer = 8                          '時間制限
    Private Const CMlngvsfLotOptionTextC        As Integer = 9                          '作業条件
    Private Const CMlngvsfLotOpIdC              As Integer = 10                         '大工程
    Private Const CMlngvsfLotStepIdC            As Integer = 11                         '小工程
    Private Const CMlngvsfLotDispatchStartC     As Integer = 12                         '処理開始予定
    Private Const CMlngvsfLotLastUpdateC        As Integer = 13                         '最終更新日
    Private Const CMlngvsfLotUseIDC             As Integer = 14                         '機種区分
    '@↓2012/03/21 (Wed) 10:00:57 T.Oide **************************************************
    Private Const CMlngvsfLotWF_IDC             As Integer = 15                            'WF_ID
    '@↑2012/03/21 (Wed) 10:00:57 T.Oide **************************************************

    '@製品ﾛｯﾄ/ﾓﾆﾀﾛｯﾄ情報(ﾀｲﾄﾙ定義)
    Private Const CMstrvsfLotNoT                As String = "№"                        '№
    Private Const CMstrvsfLotWpNoT              As String = "1"                         '装置№
    Private Const CMstrvsfLotCarrierIdT         As String = "キャリアID"                'ｷｬﾘｱID
    Private Const CMstrvsfLotLotIdT             As String = "ロットID"                  'ﾛｯﾄID
    Private Const CMstrvsfLotFlowClassT         As String = "種"                        '種別
    Private Const CMstrvsfLotPriorityT          As String = "優"                        '優先順位
    Private Const CMstrvsfLotWfNumT             As String = "WF"                        'WF枚数
    Private Const CMstrvsfLotRecipeIdT          As String = "レシピ"                    'ﾚｼﾋﾟ
    Private Const CMstrvsfLotLimitTimeT         As String = "時間制限"                  '時間制限
    Private Const CMstrvsfLotOptionTextT        As String = "作業条件"                  '作業条件
    Private Const CMstrvsfLotOpIdT              As String = "大工程"                    '大工程
    Private Const CMstrvsfLotStepIdT            As String = "小工程"                    '小工程
    Private Const CMstrvsfLotDispatchStartT     As String = "処理開始予定"              '処理開始予定日時
    Private Const CMstrvsfLotLastUpdateT        As String = "最終更新日"                '最終更新日
    Private Const CMstrvsfLotUseIDT             As String = "機種区分"                  '機種区分
    '@↓2012/03/21 (Wed) 10:01:48 T.Oide **************************************************
    Private Const CMstrvsfLotWF_IDT             As String = "WF_ID"                     'WF_ID
    '@↑2012/03/21 (Wed) 10:01:48 T.Oide **************************************************

    '@製品ﾛｯﾄ/ﾓﾆﾀﾛｯﾄ情報(幅定義)
    Private Const CMlngvsfLotNoW                As Integer = 25                         '№
    Private Const CMlngvsfLotWpNoW              As Integer = 25                         '装置№
    Private Const CMlngvsfLotCarrierIdW         As Integer = 100                        'ｷｬﾘｱID
    Private Const CMlngvsfLotLotIdW             As Integer = 87                         'ﾛｯﾄID
    Private Const CMlngvsfLotFlowClassW         As Integer = 25                         '種別
    Private Const CMlngvsfLotPriorityW          As Integer = 25                         '優先順位
    Private Const CMlngvsfLotWfNumW             As Integer = 25                         'WF枚数
    Private Const CMlngvsfLotRecipeIdW          As Integer = 67                         'ﾚｼﾋﾟID
    Private Const CMlngvsfLotLimitTimeW         As Integer = 67                         '時間制限
    Private Const CMlngvsfLotOptionTextW        As Integer = 67                         '作業条件
    Private Const CMlngvsfLotOpIdW              As Integer = 67                         '大工程
    Private Const CMlngvsfLotStepIdW            As Integer = 67                         '小工程
    Private Const CMlngvsfLotDispatchStartW     As Integer = 67                         '処理開始予定
    Private Const CMlngvsfLotLastUpdateT        As Integer = 67                         '最終更新日
    Private Const CMlngvsfLotUseIDW             As Integer = 0                          '機種区分
    '@↓2012/03/21 (Wed) 10:02:30 T.Oide **************************************************
    Private Const CMlngvsfLotWF_IDW             As Integer = 67                         'WF_ID
    '@↑2012/03/21 (Wed) 10:02:30 T.Oide **************************************************

    '@ﾊﾞｯﾁ編成情報(列定義)
    Private Const CMlngvsfBatSeqNumC            As Integer = 0                          '順序
    Private Const CMlngvsfBatCarrierIdC         As Integer = 1                          'ｷｬﾘｱID
    Private Const CMlngvsfBatJigIDC             As Integer = 2                          '冶具ID
    Private Const CMlngvsfBatLotIdC             As Integer = 3                          'ﾛｯﾄID
    Private Const CMlngvsfBatLastUpdateC        As Integer = 4                          '最終更新日
    Private Const CMlngvsfBatProductOldNoC      As Integer = 5                          '製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号(<ﾎﾞﾀﾝ用)
    Private Const CMlngvsfBatUldCarrierIDC      As Integer = 6                          'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
    Private Const CMlngvsfBatWFIDC              As Integer = 7                          'WFID
    Private Const CMlngvsfBatPanelKindC         As Integer = 8                          'ﾊﾟﾈﾙ種類(0：TFT,1：CF)
    Private Const CMlngvsfBatConditionIDC       As Integer = 9                          '処理条件
    Private Const CMlngvsfBatWFNumC             As Integer = 10                         'WF枚数
    Private Const CMlngvsfBatUseIDC             As Integer = 11                         '機種区分

    '@ｺﾝﾎﾞの値取得列用定数
    Private Const CMlngCmbWpNameName            As Integer = 0                          '装置名ｺﾝﾎﾞの名前列
    Private Const CMlngCmbWpNameId              As Integer = 1                          '装置名ｺﾝﾎﾞのID列
    Private Const CMlngCmbWpNameMaxProcessBox   As Integer = 2                          '装置名ｺﾝﾎﾞの最大処理単位ﾎﾞｯｸｽ数列
    Private Const CMlngCmbWpNameMesModeID       As Integer = 3                          '装置名ｺﾝﾎﾞの運用ﾓｰﾄﾞ列
    Private Const CMlngCmbWpNameEqType          As Integer = 4                          '装置名ｺﾝﾎﾞの装置ﾀｲﾌﾟ(EqType)列

    '@色宣言
    Private Const CMlngEnableFalseForeColor     As Integer = &H80000004                 '灰色(使用不可)
    Private Const CMlngEnableTrueForeColor      As Integer = &H0&                       '黒色
    Private Const CMlngLimitOverForeColor       As Integer = &HFF&                      '赤色

    '@その他
    Private Const CMstrFormName                 As String = "frmxxEN00M1"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                 As String = "Form_Load"                 'ｲﾍﾞﾝﾄ名称
    Private Const CMstrMade                     As String = " まで "                    '時間制限結合文字列
    Private Const CMstrh                        As String = "h"                         '時間制限結合文字列
    Private Const CMstrKouho                    As String = "△"                        '候補
    Private Const CMstrJidou                    As String = "○"                        '自動
    Private Const CMstrKakutei                  As String = "◎"                        '確定
    Private Const CMstrColon                    As String = "："                        'ｺﾛﾝ
    Private Const CMlngGridMaxWpCnt             As Integer = 13                         'ｸﾞﾘｯﾄﾞの最大装置数

    '@引数用ｲﾍﾞﾝﾄ名
    Private Const CMstrVsfLotListEnterCell      As String = "vsfLotList_EnterCell"      'ﾓﾆﾀﾛｯﾄ一覧選択時処理
    Private Const CMstrCmdKakuteiClick          As String = "cmdKakutei_Click"          '確定ﾎﾞﾀﾝ押下時処理

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************

    '======================================Private==========================================

    '@製品ﾛｯﾄ/ﾓﾆﾀﾛｯﾄ情報(可変列定義)
    Private mlngvsfLotNoC                       As Integer                              '№
    Private mlngvsfLotWpStartNoC                As Integer                              '開始装置№
    Private mlngvsfLotWpEndNoC                  As Integer                              '終了装置№
    Private mlngvsfLotCarrierIdC                As Integer                              'ｷｬﾘｱID
    Private mlngvsfLotLotIdC                    As Integer                              'ﾛｯﾄID
    Private mlngvsfLotFlowClassC                As Integer                              '種別
    Private mlngvsfLotPriorityC                 As Integer                              '優先順位
    Private mlngvsfLotWfNumC                    As Integer                              'WF枚数
    Private mlngvsfLotRecipeIdC                 As Integer                              'ﾚｼﾋﾟID
    Private mlngvsfLotLimitTimeC                As Integer                              '時間制限
    Private mlngvsfLotOptionTextC               As Integer                              '作業条件
    Private mlngvsfLotOpIdC                     As Integer                              '大工程
    Private mlngvsfLotStepIdC                   As Integer                              '小工程
    Private mlngvsfLotDispatchStartC            As Integer                              '処理開始予定
    Private mlngvsfLotLastUpdateC               As Integer                              '最終更新日
    Private mlngvsfLotUseIDC                    As Integer                              '機種区分
    '@↓2012/03/21 (Wed) 10:05:48 T.Oide **************************************************
    Private mlngvsfLotWfIdC                     As Integer                              'WF_ID
    '@↑2012/03/21 (Wed) 10:05:48 T.Oide **************************************************

    '@配列定義
    Private mtypWpList()                        As WpList                               'WPﾘｽﾄ
    Private mlngWpListCnt                       As Integer                              'WPﾘｽﾄ数

    Private buttonProcessing                    As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean              'NSYS WindowCloseフラグ


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
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/29 (Thu) 11:54:42 T.Kitagawa
    '更新日：2009/08/06 (Thu) 10:17:06 N.Kojima
    '備　考：
    '　　　：2009/06/09 (Tue) 18:46:20 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/08/06 (Thu) 10:17:06 N.Kojima     無機対応Phase3、ﾌｨﾙﾀﾞﾐｰ表示用画面として使用されることが無くなったことによる修正。(案件№03704)
    Private Sub Form_Load()

        Try

            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN00M1_Init()
            
            '@=======================
            '@ ﾓﾆﾀﾛｯﾄ一覧取得処理
            '@=======================
            Call prvLotInfo_Sel()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"                  'ﾌﾟﾛｼｰｼﾞｬ名
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
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 15:29:11 T.Kitagawa
    '更新日：2009/06/09 (Tue) 18:46:20 N.Kojima
    '備　考：
    '　　　：2009/06/09 (Tue) 18:46:20 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try

            '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
            Select Case e.KeyCode
                
                '@〓 Enterｷｰ 〓
                Case Keys.Return
                    
                    '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙがﾓﾆﾀ/ﾀﾞﾐｰﾛｯﾄ一覧ｸﾞﾘｯﾄﾞか
                    If ActiveControl.Name = vsfLotList.Name Then
                        
                        With vsfLotList
                            
                            '@選択行がﾃﾞｰﾀ行か
                            If .Row >= .Rows.Fixed Then
                                
                                '@確定ﾎﾞﾀﾝの押下
                                If cmdKakutei.Enabled = True Then
                                    
                                    '@=======================
                                    '@ 確定ﾎﾞﾀﾝ処理
                                    '@=======================
                                    Call cmdKakutei_Click(cmdKakutei, New EventArgs)
                                End If
                            End If
                        End With
                    Else
                        '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙがﾓﾆﾀ/ﾀﾞﾐｰﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ以外
                        
                        '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽをｾｯﾄし、ｷｰｺｰﾄﾞを無効にする
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    End If
            End Select


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"               'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 09:37:44 T.Kitagawa
    '更新日：2009/06/09 (Tue) 18:46:20 N.Kojima
    '備　考：
    '　　　：2009/06/09 (Tue) 18:46:20 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Try
            
            '@ﾌﾟﾗｲﾍﾞｰﾄ変数構造体のｸﾘｱ
            mlngWpListCnt = 0
            Erase mtypWpList
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_QueryUnload"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_AfterSort
    '機　能：ﾓﾆﾀﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 09:42:02 T.Kitagawa
    '更新日：2009/06/09 (Tue) 18:46:20 N.Kojima
    '備　考：
    '　　　：2009/06/09 (Tue) 18:46:20 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.AfterSort
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            '@=======================
            '@ ｿｰﾄ後のｶﾚﾝﾄ行設定処理(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfAfterSort(vsfLotList, CMlngGridTitleCol)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotList_AfterSort"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_BeforeSort
    '機　能：ﾓﾆﾀﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 09:56:41 T.Kitagawa
    '更新日：2009/06/09 (Tue) 18:46:20 N.Kojima
    '備　考：
    '　　　：2009/06/09 (Tue) 18:46:20 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.BeforeSort
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            '@=======================
            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納処理(ｸﾞﾘｯﾄﾞ、保持列)(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfBeforeSort(vsfLotList, CMlngGridTitleCol)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotList_BeforeSort"      'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_EnterCell
    '機　能：ﾓﾆﾀﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ　ｶﾚﾝﾄ行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 15:18:13 T.Kitagawa
    '更新日：2009/06/09 (Tue) 18:46:20 N.Kojima
    '備　考：
    '　　　：2009/06/09 (Tue) 18:46:20 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfLotList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.EnterCell
        
        Dim lblnAns         As Boolean      '戻り値格納用

        Try
            
            '@確定ﾎﾞﾀﾝを無効にする
            cmdKakutei.Enabled = False
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝﾁｪｯｸ
            '@=======================
            lblnAns = prvblnLot_Chk(CMstrVsfLotListEnterCell)
            
            '@ﾁｪｯｸ結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdKakutei.Enabled = False
            Else
                '@ﾁｪｯｸ結果が"True：ﾁｪｯｸOK"か
            
                '@確定ﾎﾞﾀﾝを有効にする
                cmdKakutei.Enabled = True
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotList_EnterCell"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_DblClick
    '機　能：ﾓﾆﾀﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ　ﾀﾞﾌﾞﾙｸﾘｯｸ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/29 (Thu) 14:44:23 T.Kitagawa
    '更新日：2009/06/09 (Tue) 18:46:20 N.Kojima
    '備　考：
    '　　　：2009/06/09 (Tue) 18:46:20 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfLotList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.DoubleClick
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@ﾀｲﾄﾙ行のﾀﾞﾌﾞﾙｸﾘｯｸか
            If vsfLotList.MouseRow <= 0 Then
                Exit Sub
            End If
            
            '@確定ﾎﾞﾀﾝが有効か
            If cmdKakutei.Enabled = True Then
            
                '@=======================
                '@ 確定ﾎﾞﾀﾝ処理
                '@=======================
                Call cmdKakutei_Click(cmdKakutei, New EventArgs())
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotList_DblClick"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdKakutei_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/29 (Thu) 14:33:04 T.Kitagawa
    '更新日：2009/06/09 (Tue) 18:46:20 N.Kojima
    '備　考：
    '　　　：2009/06/09 (Tue) 18:46:20 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdKakutei_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdKakutei.Click

        Dim lblnFindFlag    As Boolean      '検索ﾌﾗｸﾞ(True：有、False：無)
        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
        Dim lblnAns         As Boolean      '戻り値格納用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
             
            '@=======================
            '@ 確定ﾎﾞﾀﾝﾁｪｯｸ
            '@=======================
            lblnAns = prvblnLot_Chk(CMstrCmdKakuteiClick)
            
            '@ﾁｪｯｸ結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
            
                '@=======================
                '@ 閉じるﾎﾞﾀﾝ処理
                '@=======================
                Call cmdClose_Click(cmdClose, New EventArgs())
                Exit Sub
            End If
           
            '@ﾊﾞｯﾁ管理画面のﾚｼﾋﾟ表示がNULLか
            If frmxxEN00M0.Instance.lblRecipeID.Text = vbNullString Then
                
                '@ﾚｼﾋﾟを表示する
                frmxxEN00M0.Instance.lblRecipeID.Text = _
                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotRecipeIdC)
            End If


            '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞの表示
            With frmxxEN00M0.Instance.vsfBat
            
                '@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
                frmxxEN00M0.Instance.cmbWpName.ValueCol = CMlngCmbWpNameEqType
                    
                '@★ 選択装置の装置ﾀｲﾌﾟにより処理分岐 ★
                Select Case frmxxEN00M0.Instance.cmbWpName.Value
                
                    '@〓 20：表面処理装置 〓
                    Case CPstrEqTypeHyoumenSyori

                        '@検索ﾌﾗｸﾞの初期化
                        lblnFindFlag = False
                        
                        '@-----------------------
                        '@ 一応ﾊﾞｯﾁ組予定ﾛｯﾄに対象ﾛｯﾄがあるかﾁｪｯｸ
                        '@-----------------------
                        '@ﾊﾞｯﾁ管理画面のﾊﾞｯﾁ組予定ﾛｯﾄ一覧にﾃﾞｰﾀがあるか
                        If frmxxEN00M0.Instance.vsfBat.Rows.Count > 1 Then
                            '@ﾃﾞｰﾀがある
                            
                            For llngCnt = 1 To frmxxEN00M0.Instance.vsfBat.Rows.Count - 1

                                '@ﾓﾆﾀﾛｯﾄが既にﾊﾞｯﾁ組されているか
                                If frmxxEN00M0.Instance.vsfBat.GetData(llngCnt, CMlngvsfBatLotIdC) = _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotLotIdC) Then
                                    '@ﾊﾞｯﾁ組されている場合
                                    
                                    '@検索ﾌﾗｸﾞに"True：有"をｾｯﾄ
                                    lblnFindFlag = True
                                    Exit For
                                Else
                                    '@ﾊﾞｯﾁ組されていない場合
                                
                                    '@検索ﾌﾗｸﾞに"False：無"をｾｯﾄ
                                    lblnFindFlag = False
                                End If
                            Next llngCnt
                        Else
                            '@ﾊﾞｯﾁ管理画面のﾊﾞｯﾁ組予定ｸﾞﾘｯﾄﾞにﾃﾞｰﾀが無い場合
                            
                            '@検索ﾌﾗｸﾞに"False：無"をｾｯﾄ
                            lblnFindFlag = False
                        End If
                        
                        
                        '@検索ﾌﾗｸﾞが"True：有"か
                        If lblnFindFlag = True Then
                            '@True：有の場合、情報を上書きする
                            
                            '@ｷｬﾘｱIDの設定
                            .SetData(llngCnt, CMlngvsfBatCarrierIdC, _
                                vsfLotList.GetData(vsfLotList.Row, mlngvsfLotCarrierIdC))
                            
                            '@ﾛｯﾄIDの設定
                            .SetData(llngCnt, CMlngvsfBatLotIdC, _
                                vsfLotList.GetData(vsfLotList.Row, mlngvsfLotLotIdC))
                            
                            '@最終予定日の設定
                            .SetData(llngCnt, CMlngvsfBatLastUpdateC, _
                                vsfLotList.GetData(vsfLotList.Row, mlngvsfLotLastUpdateC))

                            '@機種区分の設定
                            .SetData(llngCnt, CMlngvsfBatUseIDC, _
                                vsfLotList.GetData(vsfLotList.Row, mlngvsfLotUseIDC))

        '@↓2012/03/21 (Wed) 10:29:15 T.Oide **************************************************
                            '@WF_IDの設定
                            .SetData(llngCnt, CMlngvsfBatWFIDC, _
                                vsfLotList.GetData(vsfLotList.Row, mlngvsfLotWfIdC))
        '@↑2012/03/21 (Wed) 10:29:15 T.Oide **************************************************
                            
                            '@製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号("<"ﾎﾞﾀﾝ用)
                            .SetData(llngCnt, CMlngvsfBatProductOldNoC, vbNullString)
                                
                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDの設定
                            .SetData(llngCnt, CMlngvsfBatUldCarrierIDC, _
                                vsfLotList.GetData(vsfLotList.Row, mlngvsfLotCarrierIdC))
                        
                        Else
                            '@"False：無"の場合、情報を追加する


        '@↓2012/03/21 (Wed) 10:30:56 T.Oide **************************************************
        '@                    '@行を追加する(1:順,2:ｷｬﾘｱID,3:冶具ID(NULL),4:ﾛｯﾄID,5:最終更新日,
        '@                    '@            6:製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号(NULL),7:ｱﾝﾛｰﾀﾞｷｬﾘｱID(ﾛｰﾀﾞｰｷｬﾘｱID),
        '@                    '@            8:WFID(NULL),9:ﾊﾟﾈﾙ種類(NULL),10:処理条件(NULL),11:WF枚数),12:機種区分
        '@                    .AddItem .Rows & vbTab & _
        '@                            vsfLotList.Cell(flexcpText, vsfLotList.Row, mlngvsfLotCarrierIdC) & vbTab & _
        '@                            vbNullString & vbTab & _
        '@                            vsfLotList.Cell(flexcpText, vsfLotList.Row, mlngvsfLotLotIdC) & vbTab & _
        '@                            vsfLotList.Cell(flexcpText, vsfLotList.Row, mlngvsfLotLastUpdateC) & vbTab & _
        '@                            vbNullString & vbTab & _
        '@                            vsfLotList.Cell(flexcpText, vsfLotList.Row, mlngvsfLotCarrierIdC) & vbTab & _
        '@                            vbNullString & vbTab & _
        '@                            vbNullString & vbTab & _
        '@                            vbNullString & vbTab & _
        '@                            vsfLotList.Cell(flexcpText, vsfLotList.Row, mlngvsfLotWfNumC) & vbTab & _
        '@                            vsfLotList.Cell(flexcpText, vsfLotList.Row, mlngvsfLotUseIDC)
        '@--------------------------------------------------------------------------------------

                            '@行を追加する(1:順,2:ｷｬﾘｱID,3:冶具ID(NULL),4:ﾛｯﾄID,5:最終更新日,
                            '@            6:製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号(NULL),7:ｱﾝﾛｰﾀﾞｷｬﾘｱID(ﾛｰﾀﾞｰｷｬﾘｱID),
                            '@            8:WFID,9:ﾊﾟﾈﾙ種類(NULL),10:処理条件(NULL),11:WF枚数),12:機種区分
                            .AddItem(.Rows.Count & vbTab & _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotCarrierIdC) & vbTab & _
                                    vbNullString & vbTab & _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotLotIdC) & vbTab & _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotLastUpdateC) & vbTab & _
                                    vbNullString & vbTab & _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotCarrierIdC) & vbTab & _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotWfIdC) & vbTab & _
                                    vbNullString & vbTab & _
                                    vbNullString & vbTab & _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotWfNumC) & vbTab & _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotUseIDC))
        '@↑2012/03/21 (Wed) 10:30:56 T.Oide **************************************************


                        End If

                
                    '@〓 その他(表面処理以外) 〓
                    Case Else

                        '@検索ﾌﾗｸﾞの初期化
                        lblnFindFlag = False
                        
                        '@ﾊﾞｯﾁ管理画面のﾊﾞｯﾁ組予定ﾛｯﾄ一覧にﾃﾞｰﾀがあるか
                        If frmxxEN00M0.Instance.vsfBat.Rows.Count > 1 Then
                            '@ﾃﾞｰﾀがある
                        
                            '@ﾓﾆﾀﾛｯﾄが既にﾊﾞｯﾁ組されているか
                            If frmxxEN00M0.Instance.vsfBat.GetData(1, CMlngvsfBatSeqNumC) = 0 Then
                                '@順=0の表示が有る場合
                                
                                '@検索ﾌﾗｸﾞに"True：有"をｾｯﾄ
                                lblnFindFlag = True
                            Else
                                '@順=0の表示が無い場合
                            
                                '@検索ﾌﾗｸﾞに"False：無"をｾｯﾄ
                                lblnFindFlag = False
                            End If
                        Else
                            '@ﾊﾞｯﾁ管理画面のﾊﾞｯﾁ組予定ｸﾞﾘｯﾄﾞにﾃﾞｰﾀが無い場合
                            
                            '@検索ﾌﾗｸﾞに"False：無"をｾｯﾄ
                            lblnFindFlag = False
                        End If
                        
                        
                        '@検索ﾌﾗｸﾞが"True：有"か
                        If lblnFindFlag = True Then
                            '@True：有の場合、情報を上書きする
                            
                            '@ｷｬﾘｱIDの設定
                            .SetData(1, CMlngvsfBatCarrierIdC, _
                                vsfLotList.GetData(vsfLotList.Row, mlngvsfLotCarrierIdC))
                            
                            '@ﾛｯﾄIDの設定
                            .SetData(1, CMlngvsfBatLotIdC, _
                                vsfLotList.GetData(vsfLotList.Row, mlngvsfLotLotIdC))
                            
                            '@最終予定日の設定
                            .SetData(1, CMlngvsfBatLastUpdateC, _
                                vsfLotList.GetData(vsfLotList.Row, mlngvsfLotLastUpdateC))
                            

                            '@機種区分の設定
                            .SetData(1, CMlngvsfLotUseIDC, _
                                vsfLotList.GetData(vsfLotList.Row, mlngvsfLotUseIDC))

                            
        '@↓2012/03/21 (Wed) 10:29:15 T.Oide **************************************************
                            '@WF_IDの設定
                            .SetData(llngCnt, CMlngvsfBatWFIDC, _
                                vsfLotList.GetData(vsfLotList.Row, mlngvsfLotWfIdC))
        '@↑2012/03/21 (Wed) 10:29:15 T.Oide **************************************************
                            
                            
                            '@製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号("<"ﾎﾞﾀﾝ用)
                            .SetData(1, CMlngvsfBatProductOldNoC, vbNullString)

                        Else
                            '@False：無の場合、情報を追加する
                            

        '@↓2012/03/21 (Wed) 10:33:49 T.Oide **************************************************
        '@                    '@順=0へ追加する(1:順(0),2:ｷｬﾘｱID,3:冶具ID(NULL),4:ﾛｯﾄID,5:最終更新日,
        '@                    '@              6:製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号(NULL),7:ｱﾝﾛｰﾀﾞｷｬﾘｱID(ﾛｰﾀﾞｰｷｬﾘｱID),
        '@                    '@              8:WFID(NULL),9:ﾊﾟﾈﾙ種類(NULL),10:処理条件(NULL),11:WF枚数,12:機種区分
        '@                    .AddItem 0 & vbTab & _
        '@                            vsfLotList.Cell(flexcpText, vsfLotList.Row, mlngvsfLotCarrierIdC) & vbTab & _
        '@                            vbNullString & vbTab & _
        '@                            vsfLotList.Cell(flexcpText, vsfLotList.Row, mlngvsfLotLotIdC) & vbTab & _
        '@                            vsfLotList.Cell(flexcpText, vsfLotList.Row, mlngvsfLotLastUpdateC) & vbTab & _
        '@                            vbNullString & vbTab & _
        '@                            vbNullString & vbTab & _
        '@                            vbNullString & vbTab & _
        '@                            vbNullString & vbTab & _
        '@                            vbNullString & vbTab & _
        '@                            vsfLotList.Cell(flexcpText, vsfLotList.Row, mlngvsfLotWfNumC) & vbTab & _
        '@                            vsfLotList.Cell(flexcpText, vsfLotList.Row, mlngvsfLotUseIDC), 1


                            '@順=0へ追加する(1:順(0),2:ｷｬﾘｱID,3:冶具ID(NULL),4:ﾛｯﾄID,5:最終更新日,
                            '@              6:製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号(NULL),7:ｱﾝﾛｰﾀﾞｷｬﾘｱID(ﾛｰﾀﾞｰｷｬﾘｱID),
                            '@              8:WFID(NULL),9:ﾊﾟﾈﾙ種類(NULL),10:処理条件(NULL),11:WF枚数,12:機種区分
                            .AddItem(0 & vbTab & _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotCarrierIdC) & vbTab & _
                                    vbNullString & vbTab & _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotLotIdC) & vbTab & _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotLastUpdateC) & vbTab & _
                                    vbNullString & vbTab & _
                                    vbNullString & vbTab & _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotWfIdC) & vbTab & _
                                    vbNullString & vbTab & _
                                    vbNullString & vbTab & _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotWfNumC) & vbTab & _
                                    vsfLotList.GetData(vsfLotList.Row, mlngvsfLotUseIDC), 1)
        '@↑2012/03/21 (Wed) 10:33:49 T.Oide **************************************************


                        End If

                End Select
                
                '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
                frmxxEN00M0.Instance.cmbWpName.ValueCol = CMlngCmbWpNameName
                
                '@ﾊﾞｯﾁ管理画面の「ﾊﾞｯﾁ組WF枚数」がNULL以外か
                If frmxxEN00M0.Instance.lblBatLotWFCnt.Text <> vbNullString Then
                
                    '@ﾊﾞｯﾁ組WF数を加算する
                    frmxxEN00M0.Instance.lblBatLotWFCnt.Text = _
                        CStr(CLng(frmxxEN00M0.Instance.lblBatLotWFCnt.Text) + _
                            CLng(vsfLotList.GetData(vsfLotList.Row, mlngvsfLotWfNumC)))
                Else
                    '@NULLの場合
                
                    '@ﾊﾞｯﾁ組WF数にﾓﾆﾀﾛｯﾄのWF枚数を反映
                    frmxxEN00M0.Instance.lblBatLotWFCnt.Text = _
                        vsfLotList.GetData(vsfLotList.Row, mlngvsfLotWfNumC)
                End If

                
            End With
            
            '@=======================
            '@ 閉じるﾎﾞﾀﾝ処理
            '@=======================
            Call cmdClose_Click(cmdClose, New EventArgs())

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdKakutei_Click"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/07/23 (Fri) 15:21:56 T.Kitagawa
    '更新日：2009/06/09 (Tue) 18:46:20 N.Kojima
    '備　考：
    '　　　：2009/06/09 (Tue) 18:46:20 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@∇∇∇∇∇∇∇∇∇∇∇
            '@ ｱﾝﾛｰﾄﾞ処理
            '@∇∇∇∇∇∇∇∇∇∇∇
            Me.Close()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"             'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvFrmxxEN00M1_Init
    '機　能：画面初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 14:20:12 T.Kitagawa
    '更新日：2009/08/06 (Thu) 10:47:07 N.Kojima
    '備　考：
    '　　　：2005/09/13 (Tue) 16:04:21 T.Kitagawa   処理開始予定日を追加(不具合№2972)
    '　　　：2009/06/09 (Tue) 18:46:20 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/08/06 (Thu) 10:47:07 N.Kojima     無機対応Phase3、装置が表面処理の場合、説明ﾗﾍﾞﾙの表示等の処理追加。(案件№03704)
    Private Sub prvFrmxxEN00M1_Init()
        
        Try
            
            '@確定ﾎﾞﾀﾝを無効にする
            cmdKakutei.Enabled = False
            
            '@各種ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString           '情報取得日時
            lblLotListCnt.Text = vbNullString        '該当件数
            lblWpList.Text = vbNullString            'ﾓﾆﾀﾛｯﾄWPﾘｽﾄ
            lblWpList.Width = vsfLotList.Width          'ﾓﾆﾀﾛｯﾄWPﾘｽﾄの幅
            
        '@↓2009/08/06 (Thu) 10:46:55 N.Kojima **************************************************

            '@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
            frmxxEN00M0.Instance.cmbWpName.ValueCol = CMlngCmbWpNameEqType

            '@★ 選択装置の装置ﾀｲﾌﾟにより処理分岐 ★
            Select Case frmxxEN00M0.Instance.cmbWpName.Value
            
                '@〓 20：表面処理装置 〓
                Case CPstrEqTypeHyoumenSyori

                    lblInstruction.Visible = True           '表面処理装置ﾊﾞｯﾁ組仕様の説明：表示
                    lblWpList.Top = 94                      '装置候補
                    vsfLotList.Top = 121                    'ﾓﾆﾀﾛｯﾄ一覧の表示位置(Top)
                    vsfLotList.Height = 308                 'ﾓﾆﾀﾛｯﾄ一覧の高さ

                '@〓 その他 〓
                Case Else
            
                    lblInstruction.Visible = False          '表面処理装置ﾊﾞｯﾁ組仕様の説明：非表示
                    lblWpList.Top = 56                      '装置候補
                    vsfLotList.Top = 83                     'ﾓﾆﾀﾛｯﾄ一覧の表示位置(Top)
                    vsfLotList.Height = 344                 'ﾓﾆﾀﾛｯﾄ一覧の高さ

            End Select
            
            '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
            frmxxEN00M0.Instance.cmbWpName.ValueCol = CMlngCmbWpNameName

        '@↑2009/08/06 (Thu) 10:46:55 N.Kojima **************************************************


            '@ﾓﾆﾀﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの初期化
            With vsfLotList
                .Redraw = False

                .Clear(ClearFlags.Content)
                
                '@行数、列数の初期設定
                .Rows.Count = 1
                
                '@列幅、ﾀｲﾄﾙ設定
                .SetData(CMlngGridTitleCol, CMlngvsfLotNoC, CMstrvsfLotNoT)                   'No
                .Cols(CMlngvsfLotNoC).Width = CMlngvsfLotNoW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotWpNoC, CMstrvsfLotWpNoT)               '装置№
                .Cols(CMlngvsfLotWpNoC).Width = CMlngvsfLotWpNoW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotCarrierIdC, CMstrvsfLotCarrierIdT)     'ｷｬﾘｱID
                .Cols(CMlngvsfLotCarrierIdC).Width = CMlngvsfLotCarrierIdW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotLotIdC, CMstrvsfLotLotIdT)             'ﾛｯﾄID
                .Cols(CMlngvsfLotLotIdC).Width = CMlngvsfLotLotIdW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotFlowClassC, CMstrvsfLotFlowClassT)     '種別
                .Cols(CMlngvsfLotFlowClassC).Width = CMlngvsfLotFlowClassW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotPriorityC, CMstrvsfLotPriorityT)       '優先順位
                .Cols(CMlngvsfLotPriorityC).Width = CMlngvsfLotPriorityW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotWfNumC, CMstrvsfLotWfNumT)             'WF枚数
                .Cols(CMlngvsfLotWfNumC).Width = CMlngvsfLotWfNumW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotRecipeIdC, CMstrvsfLotRecipeIdT)       'ﾚｼﾋﾟ
                .Cols(CMlngvsfLotRecipeIdC).Width = CMlngvsfLotRecipeIdW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotLimitTimeC, CMstrvsfLotLimitTimeT)     '時間制限
                .Cols(CMlngvsfLotLimitTimeC).Width = CMlngvsfLotLimitTimeW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotOptionTextC, CMstrvsfLotOptionTextT)   '作業条件
                .Cols(CMlngvsfLotOptionTextC).Width = CMlngvsfLotOptionTextW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotOpIdC, CMstrvsfLotOpIdT)               '大工程
                .Cols(CMlngvsfLotOpIdC).Width = CMlngvsfLotOpIdW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotStepIdC, CMstrvsfLotStepIdT)           '小工程
                .Cols(CMlngvsfLotStepIdC).Width = CMlngvsfLotStepIdW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotDispatchStartC, CMstrvsfLotDispatchStartT)     '処理開始予定
                .Cols(CMlngvsfLotDispatchStartC).Width = CMlngvsfLotDispatchStartW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotLastUpdateC, CMstrvsfLotLastUpdateT)   '最終更新日
                .Cols(CMlngvsfLotLastUpdateC).Width = CMlngvsfLotNoW
                
        '@↓2009/08/06 (Thu) 10:24:41 N.Kojima **************************************************

                .SetData(CMlngGridTitleCol, CMlngvsfLotUseIDC, CMstrvsfLotUseIDT)             '機種区分
                .Cols(CMlngvsfLotUseIDC).Width = CMlngvsfLotUseIDW

        '@↑2009/08/06 (Thu) 10:24:41 N.Kojima **************************************************
                
                '@非表示設定
                '.ColHidden(-1) = False
                For lintCnt As Integer = 0 To .Cols.Count - 1
                    .Cols(lintCnt).Visible = True
                Next
                .Cols(CMlngvsfLotLastUpdateC).Visible = False                                               '最終更新日
        '@↓2009/08/06 (Thu) 10:25:07 N.Kojima **************************************************
                .Cols(CMlngvsfLotUseIDC).Visible = False                                                    '機種区分
        '@↑2009/08/06 (Thu) 10:25:07 N.Kojima **************************************************
                
                '@ﾀｲﾄﾙの設定
                Dim headerStyle As CellStyle = .Styles.Fixed
                headerStyle.ForeColor = Color.Yellow
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                headerStyle.TextAlign = TextAlignEnum.CenterCenter
                headerStyle.Trimming = StringTrimming.None
                
                '@行高設定
                .Rows(CMlngGridTitleCol).Height = CMlngGridTitleHeight
                
                .Redraw = True

                '@使用不可設定
                .Enabled = False

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvFrmxxEN00M1_Init"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLotInfo_Sel
    '機　能：ﾓﾆﾀﾛｯﾄ一覧取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 11:38:17 T.Kitagawa
    '更新日：2009/06/09 (Tue) 18:46:20 N.Kojima
    '備　考：
    '　　　：2004/10/18 (Mon) 14:09:31 N.Kasai      0件MSG前にﾚｽﾎﾟﾝｽｷｬﾝｾﾙ追加
    '　　　：2009/06/09 (Tue) 18:46:20 N.Kojima     無機対応。(案件№03560)
    Private Sub prvLotInfo_Sel()

        Dim lblnAns                     As Boolean              '結果格納
        Dim ltypMcGpLotInfo             As McGpLotInfo          '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体
        Dim llngCnt                     As Integer              'ｶｳﾝﾀ(汎用)

        Try

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@WPﾘｽﾄﾗﾍﾞﾙの設定
            lblWpList.Text = frmxxEN00M0.Instance.lblProductWpList.Text
            
            '@WPﾘｽﾄ格納構造体の初期化
            Erase mtypWpList
            mlngWpListCnt = 0
            
            '@WPﾘｽﾄの設定
            mlngWpListCnt = ptypWPList.Count
            ReDim mtypWpList(mlngWpListCnt-1)
            
            '@引継ぎ情報をｾｯﾄ
            For llngCnt = 0 To mlngWpListCnt-1
                mtypWpList(llngCnt).strWpID = ptypWPList(llngCnt).strWpID
                mtypWpList(llngCnt).strWpName = ptypWPList(llngCnt).strWpName
                mtypWpList(llngCnt).strMaxProcessBox = ptypWPList(llngCnt).strMaxProcessBox
            Next llngCnt

            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ取得(2Z：ﾓﾆﾀﾛｯﾄ)
            '@=======================
            lblnAns = pubblnLotMcGpLotList_Sel(CMstrlot_mcgplotlistVer, _
                                               pstrSBID, _
                                               frmxxEN00M0.Instance.cmbMcGpName.Value, _
                                               CPstrCD2Z, _
                                               ltypMcGpLotInfo)
            
            '@結果判定
            If lblnAns = True Then
                
                '@取得日時、該当件数の表示
                'lblNowDate.Text = Format$(Date, CPstrDateTimeMD) & Space(1) & Format$(Time, CPstrDateFormatHMS)      '取得日時
                lblNowDate.Text = Format$(Now, CPstrDateFormat)     '取得日時
                lblLotListCnt.Text = Format$(ltypMcGpLotInfo.lngMcGpLotListCnt, CPstrDateFormatKanma)                '該当件数
                
                '@=======================
                '@ ﾓﾆﾀﾛｯﾄ一覧表示処理
                '@=======================
                Call prvvsfLotList_Disp(ltypMcGpLotInfo)
            
                '@該当件数がNULL以外か
                If lblLotListCnt.Text <> vbNullString Then
                    
                    '@該当件数が0件か
                    If lblLotListCnt.Text = CPstrLotCnt0 Then
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM29I>$$該当件数 ： %1 件"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, lblLotListCnt.Text)
                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                    
                    End If
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"False：異常"をｾｯﾄ
                pblnFormLoad = False
                Exit Sub
            End If
            
            '@ﾓﾆﾀﾛｯﾄが有るか
            If vsfLotList.Rows.Count > 1 Then
                
                '@ﾓﾆﾀﾛｯﾄ一覧ｸﾞﾘｯﾄﾞを有効にする
                vsfLotList.Enabled = True
            End If
            
             '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
           

            '@ﾓﾆﾀﾛｯﾄが無いか
            If vsfLotList.Rows.Count <= 1 Then
                
                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"False：異常"をｾｯﾄ
                pblnFormLoad = False
                Exit Sub
            End If
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：正常"をｾｯﾄ
            pblnFormLoad = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvLotInfo_Sel"             'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotList_Disp
    '機　能：ﾓﾆﾀﾛｯﾄ一覧表示処理
    '引　数：ltypMcGpLotInfo    ：装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 17:30:55 T.Kitagawa
    '更新日：2012/03/21 (Wed) 10:03:57 T.Oide
    '備　考：
    '　　　：2004/09/10 (Fri) 10:00:43 Y.Yamagishi  時間制限表示変更
    '　　　：2005/09/13 (Tue) 16:09:07 T.Kitagawa   処理開始予定日を追加(不具合№2972)
    '　　　：2006/05/12 (Fri) 15:27:08 T.Kitagawa   制限時間の表示を分合計から時間と分で分割表示する(#,##0時間 #0分)(ﾕｰｻﾞ要望№0186)
    '　　　：2006/06/08 (Thu) 16:35:29 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2009/06/09 (Tue) 18:46:20 N.Kojima     無機対応。(案件№03560)
    '　　　：2012/03/12 (Mon) 09:41:52 T.Oide       無機装置追加対応(REQ-1303)
    Private Sub prvvsfLotList_Disp(ByRef ltypMcGpLotInfo As McGpLotInfo)

        Dim lblnFindFlag                As Boolean              '検索ﾌﾗｸﾞ(True:有、False:無)
        Dim llngCnt                     As Integer              'ｶｳﾝﾀ(汎用)
        Dim llngCnt2                    As Integer              'ｶｳﾝﾀ2(汎用)
        Dim llngCnt3                    As Integer              'ｶｳﾝﾀ3(汎用)
        Dim llngCnt4                    As Integer              'ｶｳﾝﾀ4(汎用)
    '@↓2012/03/21 (Wed) 10:15:46 T.Oide **************************************************
        Dim llngCnt5                    As Integer              'ｶｳﾝﾀ5(汎用)
    '@↑2012/03/21 (Wed) 10:15:46 T.Oide **************************************************
        Dim lstrLimitTime               As String               '制限時間ﾌｫｰﾏｯﾄ用変数
        Dim lstrLimitTimeAns            As String               '時間制限変換用変数(#,##0時間 #0分)

        Try
            
            '@ﾓﾆﾀﾛｯﾄ一覧ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ可変列設定
            mlngvsfLotNoC = CMlngvsfLotNoC                                          'No
            mlngvsfLotWpStartNoC = CMlngvsfLotWpNoC                                 '開始装置№
            mlngvsfLotWpEndNoC = CMlngvsfLotWpNoC + mlngWpListCnt - 1               '終了装置№
            mlngvsfLotCarrierIdC = CMlngvsfLotCarrierIdC + mlngWpListCnt - 1        'ｷｬﾘｱID
            mlngvsfLotLotIdC = CMlngvsfLotLotIdC + mlngWpListCnt - 1                'ﾛｯﾄID
            mlngvsfLotFlowClassC = CMlngvsfLotFlowClassC + mlngWpListCnt - 1        '種別
            mlngvsfLotPriorityC = CMlngvsfLotPriorityC + mlngWpListCnt - 1          '優先順位
            mlngvsfLotWfNumC = CMlngvsfLotWfNumC + mlngWpListCnt - 1                'WF枚数
            mlngvsfLotRecipeIdC = CMlngvsfLotRecipeIdC + mlngWpListCnt - 1          'ﾚｼﾋﾟID
            mlngvsfLotLimitTimeC = CMlngvsfLotLimitTimeC + mlngWpListCnt - 1        '時間制限
            mlngvsfLotOptionTextC = CMlngvsfLotOptionTextC + mlngWpListCnt - 1      '作業条件
            mlngvsfLotOpIdC = CMlngvsfLotOpIdC + mlngWpListCnt - 1                  '大工程
            mlngvsfLotStepIdC = CMlngvsfLotStepIdC + mlngWpListCnt - 1              '小工程
            mlngvsfLotDispatchStartC = CMlngvsfLotDispatchStartC + mlngWpListCnt - 1    '処理開始予定
            mlngvsfLotLastUpdateC = CMlngvsfLotLastUpdateC + mlngWpListCnt - 1      '最終更新日
            mlngvsfLotUseIDC = CMlngvsfLotUseIDC + mlngWpListCnt - 1                '機種区分
        '@↓2012/03/21 (Wed) 10:04:51 T.Oide **************************************************
            mlngvsfLotWfIdC = CMlngvsfLotWF_IDC + mlngWpListCnt - 1                 'WF_ID
        '@↑2012/03/21 (Wed) 10:04:51 T.Oide **************************************************

            '@ﾓﾆﾀﾛｯﾄ一覧ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ(列)設定
            With vsfLotList
                
                .Redraw = False

                '@初期設定
                .Rows.Count = 1
                
                '@列数設定
                .Cols.Count = .Cols.Count + mlngWpListCnt - 1
                
                '@ﾀｲﾄﾙの文字設定
                .SetData(CMlngGridTitleCol, mlngvsfLotNoC, CMstrvsfLotNoT)                        'No
                
                For llngCnt = mlngvsfLotWpStartNoC To mlngvsfLotWpEndNoC
                    .SetData(CMlngGridTitleCol, llngCnt, str$(llngCnt))                           '装置№
                Next llngCnt
                
                .SetData(CMlngGridTitleCol, mlngvsfLotCarrierIdC, CMstrvsfLotCarrierIdT)          'ｷｬﾘｱID
                .SetData(CMlngGridTitleCol, mlngvsfLotLotIdC, CMstrvsfLotLotIdT)                  'ﾛｯﾄID
                .SetData(CMlngGridTitleCol, mlngvsfLotFlowClassC, CMstrvsfLotFlowClassT)          '種別
                .SetData(CMlngGridTitleCol, mlngvsfLotPriorityC, CMstrvsfLotPriorityT)            '優先順位
                .SetData(CMlngGridTitleCol, mlngvsfLotWfNumC, CMstrvsfLotWfNumT)                  'WF枚数
                .SetData(CMlngGridTitleCol, mlngvsfLotRecipeIdC, CMstrvsfLotRecipeIdT)            'ﾚｼﾋﾟ
                .SetData(CMlngGridTitleCol, mlngvsfLotLimitTimeC, CMstrvsfLotLimitTimeT)          '時間制限
                .SetData(CMlngGridTitleCol, mlngvsfLotOptionTextC, CMstrvsfLotOptionTextT)        '作業条件
                .SetData(CMlngGridTitleCol, mlngvsfLotOpIdC, CMstrvsfLotOpIdT)                    '大工程
                .SetData(CMlngGridTitleCol, mlngvsfLotStepIdC, CMstrvsfLotStepIdT)                '小工程
                .SetData(CMlngGridTitleCol, mlngvsfLotDispatchStartC, CMstrvsfLotDispatchStartT)  '処理開始予定
                .SetData(CMlngGridTitleCol, mlngvsfLotLastUpdateC, CMstrvsfLotLastUpdateT)        '最終更新日
                .SetData(CMlngGridTitleCol, mlngvsfLotUseIDC, CMstrvsfLotUseIDT)                  '機種区分
        '@↓2012/03/21 (Wed) 10:12:44 T.Oide **************************************************
                .SetData(CMlngGridTitleCol, mlngvsfLotWfIdC, CMstrvsfLotWF_IDT)                   'WF_ID
        '@↑2012/03/21 (Wed) 10:12:44 T.Oide **************************************************
                
                '@非表示設定
                '.ColHidden(-1) = False
                For lintCnt As Integer = 0 To .Cols.Count - 1
                    .Cols(lintCnt).Visible = True
                Next
                .Cols(mlngvsfLotLastUpdateC).Visible = False        '最終更新日
                .Cols(mlngvsfLotUseIDC).Visible = False             '機種区分
        '@↓2012/03/21 (Wed) 10:13:27 T.Oide **************************************************
                .Cols(mlngvsfLotWfIdC).Visible = False              'WF_ID
        '@↑2012/03/21 (Wed) 10:13:27 T.Oide **************************************************
                
                
                '@ﾀｲﾄﾙの色、表示位置、高さ設定
                Dim headerStyle As CellStyle = .Styles.Fixed
                headerStyle.ForeColor = Color.Yellow
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                headerStyle.TextAlign = TextAlignEnum.CenterCenter
                headerStyle.Trimming = StringTrimming.None
                
                '@行高設定
                .Rows(CMlngGridTitleCol).Height = CMlngGridTitleHeight
            End With


            '@-----------------------
            '@ ﾓﾆﾀﾛｯﾄ一覧ｸﾞﾘｯﾄﾞのﾃﾞｰﾀ表示
            '@-----------------------
            'vsfLotList.Redraw = flexRDBuffered          'ﾊﾞｯﾌｧ経由で描画

            'Dim newStyle_FC_EnableTrueForeColor As CellStyle = vsfLotList.Styles.Add("CustomStyle_ForeColor_CMlngEnableTrueForeColor")
            'newStyle_FC_EnableTrueForeColor.ForeColor = ColorTranslator.FromWin32(CMlngEnableTrueForeColor)      '黒色
            Dim newStyle_FC_EnableTrueForeColorL As CellStyle = vsfLotList.Styles.Add("CustomStyle_ForeColor_CMlngEnableTrueForeColor")
            newStyle_FC_EnableTrueForeColorL.ForeColor = ColorTranslator.FromWin32(CMlngEnableTrueForeColor)      '黒色左寄せ
            newStyle_FC_EnableTrueForeColorL.TextAlign = TextAlignEnum.LeftCenter
            Dim newStyle_FC_VbColorPurple As CellStyle = vsfLotList.Styles.Add("CustomStyle_ForeColor_CPlngVbColorPurple")
            newStyle_FC_VbColorPurple.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)                  '紫色
            newStyle_FC_VbColorPurple.TextAlign = TextAlignEnum.LeftCenter
            Dim newStyle_FC_vbBlack As CellStyle = vsfLotList.Styles.Add("CustomStyle_ForeColor_vbBlack")
            newStyle_FC_vbBlack.ForeColor = Color.Black                                                          '黒色
            newStyle_FC_vbBlack.TextAlign = TextAlignEnum.LeftCenter
            Dim newStyle_FC_VbColorRed As CellStyle = vsfLotList.Styles.Add("CustomStyle_ForeColor_CPlngVbColorRed")
            newStyle_FC_VbColorRed.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)                        '赤色
            newStyle_FC_VbColorRed.TextAlign = TextAlignEnum.LeftCenter
            Dim newStyle_FC_EnableFalseForeColor As CellStyle = vsfLotList.Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseForeColor")
            newStyle_FC_EnableFalseForeColor.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor) '灰色(使用不可)

            Dim cellRange As CellRange

            RemoveHandler vsfLotList.EnterCell, AddressOf vsfLotList_EnterCell
            For llngCnt = 0 To ltypMcGpLotInfo.lngMcGpLotListCnt - 1
                
                '@行数の設定
                vsfLotList.Rows.Count = ltypMcGpLotInfo.lngMcGpLotListCnt + 1
                
                With ltypMcGpLotInfo.typMcGpLotList(llngCnt)
                    
                    '@ForeColor色設定
                    'cellRange = vsfLotList.GetCellRange(llngCnt+1, CMlngGridTitleCol, llngCnt+1, vsfLotList.Cols.Count - 1)
                    'cellRange.Style = newStyle_FC_EnableTrueForeColor     '黒色
                    
                    '@№の設定
                    vsfLotList.SetData(llngCnt+1, CMlngvsfLotNoC, llngCnt+1)                        'No
                    
                    '@装置№の設定
                    For llngCnt2 = 0 To .lngMcGpLotWpListCnt - 1
                        
                        With .typMcGpLotWpList(llngCnt2)
                            
                            '@検索ﾌﾗｸﾞの初期化
                            lblnFindFlag = False
                            
                            '@装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄWPﾘｽﾄの検索
                            For llngCnt3 = 0 To mlngWpListCnt - 1
                                
                                If .strWpID = mtypWpList(llngCnt3).strWpID Then
                                    
                                    '@検索ﾌﾗｸﾞの有設定
                                    lblnFindFlag = True
                                    Exit For
                                End If
                            Next llngCnt3
                            
                            '@検索ﾌﾗｸﾞ判定(WPID有の場合は設定)
                            If lblnFindFlag = True Then
                                
                                '@★ 使用可能装置数により処理分岐 ★
                                Select Case ltypMcGpLotInfo.typMcGpLotList(llngCnt).lngMcGpLotWpListCnt
                                    
                                    '@〓 1装置の場合 〓
                                    Case 1
                                        
                                        '@1件の場合は確定(◎)を設定する
                                        vsfLotList.SetData(llngCnt+1, llngCnt3+1, CMstrKakutei)      '装置№
                                    
                                    
                                    '@〓 1装置以上の場合 〓
                                    Case Is >= 2
                                        
                                        '@2件の場合は候補(△)を設定する
                                        vsfLotList.SetData(llngCnt+1, llngCnt3+1, CMstrKouho)        '装置№
                                
                                End Select
                            End If
                        End With
                    Next llngCnt2
                    
                    '@装置№以降の設定
                    vsfLotList.SetData(llngCnt+1, mlngvsfLotCarrierIdC, .strCarrierId)         'ｷｬﾘｱID
                    vsfLotList.SetData(llngCnt+1, mlngvsfLotLotIdC, .strLotID)                 'ﾛｯﾄID
                    vsfLotList.SetData(llngCnt+1, mlngvsfLotFlowClassC, .strFlowClass)         '種別
                    vsfLotList.SetData(llngCnt+1, mlngvsfLotPriorityC, .strLotPriority)        '優先順位
                    vsfLotList.SetData(llngCnt+1, mlngvsfLotWfNumC, .strWFQuantity)            'WF枚数
                    vsfLotList.SetData(llngCnt+1, mlngvsfLotRecipeIdC, .strRecipeId)           'ﾚｼﾋﾟ
                                
                    '@時間制約有無の表示
                    If ltypMcGpLotInfo.typMcGpLotList(llngCnt).strLimitTime <> vbNullString Then
                        
                        '@時間制約がﾌﾟﾗｽの場合
                        If CInt(ltypMcGpLotInfo.typMcGpLotList(llngCnt).strLimitTime) >= 0 Then
                            
                            '@制限時間以下or処理時間制限以下の場合
                            If ltypMcGpLotInfo.typMcGpLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                ltypMcGpLotInfo.typMcGpLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID3 Then
                                
                                '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                lstrLimitTime = Format$(CInt(ltypMcGpLotInfo.typMcGpLotList(llngCnt).strLimitTime), CPstrDateFormatKanma)
                                
                                '@制限時間先大工程+制限時間先小工程+制限時間+「以内」
                                '@制限時間を時間と分で分割表示する
                                lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
                                vsfLotList.SetData(llngCnt+1, mlngvsfLotLimitTimeC, ltypMcGpLotInfo.typMcGpLotList(llngCnt).strToOpId & CPstrSpace & _
                                                                                ltypMcGpLotInfo.typMcGpLotList(llngCnt).strToStepId & CPstrMade & _
                                                                                lstrLimitTimeAns & CPstrinai)
                                
                                '@左寄せ
                                cellRange = vsfLotList.GetCellRange(llngCnt+1, mlngvsfLotLimitTimeC, llngCnt+1, mlngvsfLotLimitTimeC)
                                cellRange.Style = newStyle_FC_EnableTrueForeColorL                '黒左寄せ

                                '@警告時間が設定されている場合
                                If ltypMcGpLotInfo.typMcGpLotList(llngCnt).strWarnTime <> vbNullString Then
                                    
                                    '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                    If CLng(ltypMcGpLotInfo.typMcGpLotList(llngCnt).strWarnTime) < 0 And CLng(ltypMcGpLotInfo.typMcGpLotList(llngCnt).strLimitTime) >= 0 Then
                                        '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                        cellRange.Style = newStyle_FC_VbColorPurple    '紫色
                                    Else
                                        '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                        cellRange.Style = newStyle_FC_vbBlack                '黒
                                    End If
                                End If
                            End If
                            
                        Else
                            '@制限時間がﾏｲﾅｽの場合
                            
                            '@左寄せ
                            '@ForColorの変更
                            cellRange = vsfLotList.GetCellRange(llngCnt+1, mlngvsfLotLimitTimeC, llngCnt+1, mlngvsfLotLimitTimeC)
                            cellRange.Style = newStyle_FC_VbColorRed    '赤色
                            
                            '@制限時間以下or処理時間制限以下の場合
                            If ltypMcGpLotInfo.typMcGpLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                ltypMcGpLotInfo.typMcGpLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID3 Then
                                
                                '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                lstrLimitTime = Format$(CInt(ltypMcGpLotInfo.typMcGpLotList(llngCnt).strLimitTime), CPstrDateFormatKanma)
                                
                                '@制限時間先大工程+制限時間先小工程+制限時間+「以内」
                                '@制限時間を時間と分で分割表示する
                                lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
                                vsfLotList.SetData(llngCnt+1, mlngvsfLotLimitTimeC, ltypMcGpLotInfo.typMcGpLotList(llngCnt).strToOpId & CPstrSpace & _
                                                        ltypMcGpLotInfo.typMcGpLotList(llngCnt).strToStepId & CPstrMade & _
                                                        lstrLimitTimeAns & CPstrinai)
                            End If
                            
                            '@制限時間以上の場合
                            If ltypMcGpLotInfo.typMcGpLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID2 Then
                                
                                '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,##0)+"分"
                                lstrLimitTime = Replace(Format$(CInt(ltypMcGpLotInfo.typMcGpLotList(llngCnt).strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString)
                                
                                '@制限時間先大工程+制限時間先小工程+制限時間+「以上」
                                '@制限時間を時間と分で分割表示する
                                lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
                                vsfLotList.SetData(llngCnt, mlngvsfLotLimitTimeC, ltypMcGpLotInfo.typMcGpLotList(llngCnt).strToOpId & CPstrSpace & _
                                                        ltypMcGpLotInfo.typMcGpLotList(llngCnt).strToStepId & CPstrMade & _
                                                        lstrLimitTimeAns & CPstrijyou)
                            End If
                        End If
                    End If
                    
                    vsfLotList.SetData(llngCnt+1, mlngvsfLotOptionTextC, .strOptionText)        '作業条件
                    vsfLotList.SetData(llngCnt+1, mlngvsfLotOpIdC, .strOpID)                    '大工程
                    vsfLotList.SetData(llngCnt+1, mlngvsfLotStepIdC, .strStepID)                '小工程
                    If IsDate(.strDispatchStartTime) Then
                        vsfLotList.SetData(llngCnt+1, mlngvsfLotDispatchStartC, _
                                           Format$(CDate(.strDispatchStartTime), CPstrDateFormatMDHM))    '処理開始予定
                    Else
                        vsfLotList.SetData(llngCnt+1, mlngvsfLotDispatchStartC, .strDispatchStartTime)    '処理開始予定
                    End If
                    vsfLotList.SetData(llngCnt+1, mlngvsfLotLastUpdateC, .strLotLastUpdate)     '最終更新日
                    vsfLotList.SetData(llngCnt+1, mlngvsfLotUseIDC, UCase(.strUseId))           '機種区分
                    
        '@↓2012/03/21 (Wed) 10:14:37 T.Oide **************************************************
                    '@WF_IDを「,」区切りで書き込む
                    For llngCnt5 = 0 To .lngMcGpLotWFListCnt - 1
                        If llngCnt5 = 0 Then
                            vsfLotList.SetData(llngCnt+1, mlngvsfLotWfIdC, .typMcGpLotWFList(llngCnt5).strWfId)
                        Else
                            vsfLotList.SetData(llngCnt+1, mlngvsfLotWfIdC, _
                                vsfLotList.GetData(llngCnt+1, mlngvsfLotWfIdC) & CPstrComma & .typMcGpLotWFList(llngCnt5).strWfId)
                        End If
                    Next
        '@↑2012/03/21 (Wed) 10:14:37 T.Oide **************************************************

                    
                    '@行高設定
                    vsfLotList.Rows(llngCnt+1).Height = CMlngGridRowHeight
                    
                    '@既に選択ﾓﾆﾀﾛｯﾄが編成されている場合はForeColorをｸﾞﾚｰを設定する
                    If frmxxEN00M0.Instance.vsfBat.Rows.Count > 1 Then
                        
                        For llngCnt4 = 1 To frmxxEN00M0.Instance.vsfBat.Rows.Count - 1
                            
                            '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧に同じﾛｯﾄIDが存在するか
                            If frmxxEN00M0.Instance.vsfBat.GetData(llngCnt4, CMlngvsfBatLotIdC) = _
                                vsfLotList.GetData(llngCnt+1, mlngvsfLotLotIdC) Then

                                '@ForeColor設定
                                cellRange = vsfLotList.GetCellRange(llngCnt+1, mlngvsfLotNoC, llngCnt+1, mlngvsfLotLastUpdateC)
                                cellRange.Style = newStyle_FC_EnableFalseForeColor
                            End If
                        Next llngCnt4
                    End If
                End With
            Next llngCnt

            '@ﾃﾞｰﾀが1件以上の場合
            If vsfLotList.Rows.Count > 1 Then
                
                '@表示位置の設定
                With vsfLotList
                    
                    .Cols(mlngvsfLotNoC).DataType = GetType(Integer)                     'No
                    .Cols(mlngvsfLotNoC).TextAlign = TextAlignEnum.RightCenter
                    
                    For llngCnt = mlngvsfLotWpStartNoC To mlngvsfLotWpEndNoC
                        .Cols(llngCnt).DataType = GetType(Object)                        '装置№
                        .Cols(llngCnt).TextAlign = TextAlignEnum.LeftCenter
                    Next llngCnt
                    
                    .Cols(mlngvsfLotCarrierIdC).DataType = GetType(Object)               'ｷｬﾘｱID
                    .Cols(mlngvsfLotCarrierIdC).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(mlngvsfLotLotIdC).DataType = GetType(Object)                   'ﾛｯﾄID
                    .Cols(mlngvsfLotLotIdC).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(mlngvsfLotFlowClassC).DataType = GetType(Object)               '種別
                    .Cols(mlngvsfLotFlowClassC).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(mlngvsfLotPriorityC).DataType = GetType(Object)               '優先順位
                    .Cols(mlngvsfLotPriorityC).TextAlign = TextAlignEnum.RightCenter
                    .Cols(mlngvsfLotWfNumC).DataType = GetType(Integer)                  'WF枚数
                    .Cols(mlngvsfLotWfNumC).TextAlign = TextAlignEnum.RightCenter
                    .Cols(mlngvsfLotRecipeIdC).DataType = GetType(Object)                'ﾚｼﾋﾟ
                    .Cols(mlngvsfLotRecipeIdC).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(mlngvsfLotLimitTimeC).DataType = GetType(Object)               '時間制限
                    .Cols(mlngvsfLotLimitTimeC).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(mlngvsfLotOptionTextC).DataType = GetType(Object)              '作業条件
                    .Cols(mlngvsfLotOptionTextC).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(mlngvsfLotOpIdC).DataType = GetType(Object)                    '大工程
                    .Cols(mlngvsfLotOpIdC).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(mlngvsfLotStepIdC).DataType = GetType(Object)                  '小工程
                    .Cols(mlngvsfLotStepIdC).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(mlngvsfLotDispatchStartC).DataType = GetType(Object)           '処理開始予定
                    .Cols(mlngvsfLotDispatchStartC).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(mlngvsfLotLastUpdateC).DataType = GetType(Object)              '最終更新日
                    .Cols(mlngvsfLotLastUpdateC).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(mlngvsfLotUseIDC).DataType = GetType(Object)                   '機種区分
                    .Cols(mlngvsfLotUseIDC).TextAlign = TextAlignEnum.LeftCenter
        '@↓2012/03/21 (Wed) 10:22:49 T.Oide **************************************************
                    .Cols(mlngvsfLotWfIdC).DataType = GetType(Object)                    'WF_ID
                    .Cols(mlngvsfLotWfIdC).TextAlign = TextAlignEnum.LeftCenter
        '@↑2012/03/21 (Wed) 10:22:49 T.Oide **************************************************
                End With
            End If
                
            '@列幅の自動調整
            With vsfLotList
                
                '.AutoSizeMode = flexAutoSizeColWidth
                
                For llngCnt = CMlngGridTitleCol To .Cols.Count - 1
                    .AutoSizeCol(llngCnt, 6)
                Next llngCnt
            End With

            '@固定列の設定
            If mlngWpListCnt <= CMlngGridMaxWpCnt Then
                vsfLotList.Cols.Frozen = mlngvsfLotCarrierIdC + 1
            Else
                '@装置数が14個以上の場合は固定列なし
                vsfLotList.Cols.Frozen = 0
            End If
            
            '@ﾏｳｽよる列ｻｲｽﾞ変更の可／不可設定
            vsfLotList.AllowResizing = AllowResizingEnum.Columns

            vsfLotList.Row = 0
            AddHandler vsfLotList.EnterCell, AddressOf vsfLotList_EnterCell

            vsfLotList.Redraw = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvVsfLotList_Disp"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnLot_Chk
    '機　能：ﾓﾆﾀﾛｯﾄﾁｪｯｸ処理
    '引　数：lstrCallEvent      ：呼び元ｲﾍﾞﾝﾄ
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2009/06/11 (Thu) 14:52:32 N.Kojima
    '更新日：2009/08/17 (Mon) 08:57:19 N.Kojima
    '備　考：
    '　　　：2009/07/30 (Thu) 15:21:08 N.Kojima     無機対応Phase2、ﾓﾆﾀ選択確定条件を追加。(案件№03661)
    '　　　：2009/08/06 (Thu) 12:42:21 N.Kojima     無機対応Phase3、表面処理装置仕様のﾊﾞｯﾁ組順ﾁｪｯｸを追加。(案件№03704)
    '　　　：2009/08/17 (Mon) 08:57:19 N.Kojima     運用障害対応。ﾓﾆﾀﾛｯﾄが編成出来ない不具合を修正。(案件№03714)
    Private Function prvblnLot_Chk(ByRef lstrCallEvent As String) As Boolean

        Dim lblnEditBatchErrFlag        As Boolean              'ﾊﾞｯﾁ編成ｴﾗｰﾌﾗｸﾞ(True：ｴﾗｰ、False：初期値)

        Try
            
            '@戻り値の初期化
            prvblnLot_Chk = False

            '@***********************
            '@ 以下の条件の場合、処理しない
            '@ ①ﾓﾆﾀﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾃﾞｰﾀが存在しない
            '@ ②選択ﾓﾆﾀﾛｯﾄが既にﾊﾞｯﾁ編成中
            '@ ③装置名が未選択
            '@ ④最大ﾛｯﾄ数が未設定
            '@ ⑤ﾊﾞｯﾁ組予定ﾛｯﾄ数が最大ﾛｯﾄ数を超えている
            '@ ⑥使用可能装置ではない
            '@ ⑦ﾚｼﾋﾟが異なる
            '@ ⑧基板の場合、既にﾓﾆﾀが編成されている
            '@ ⑨表面処理の場合、装置仕様のﾊﾞｯﾁ組順と異なる(確定ﾎﾞﾀﾝ処理からCallされた場合のみﾁｪｯｸ)
            '@***********************
            With vsfLotList
            
                '@①ﾃﾞｰﾀ行以外か
                If .Row < 1 Then
                    Exit Function
                End If

                '@②既にﾊﾞｯﾁ編成中(文字色がｸﾞﾚｰ)か
                If .GetCellRange(.Row, mlngvsfLotNoC).StyleDisplay.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor) Then
                    Exit Function
                End If
            
                '@③装置名が未選択か
                If frmxxEN00M0.Instance.cmbWpName.Text = vbNullString Then
                    Exit Function
                End If
                
                '@④最大ﾛｯﾄ数が未設定か
                If IsNumeric(frmxxEN00M0.Instance.lblMaxLotCnt.Text) = False Then
                    Exit Function
                End If
                
                '@⑤ﾊﾞｯﾁ組予定ﾛｯﾄ数が最大ﾛｯﾄ数を超えているか
                If frmxxEN00M0.Instance.vsfBat.Rows.Count - 1 >= CLng(frmxxEN00M0.Instance.lblMaxLotCnt.Text) Then
                    Exit Function
                End If
                
                '@⑥使用可能装置か
                '@★ 使用可能装置により処理分岐 ★
                Select Case .GetData(.Row, frmxxEN00M0.Instance.cmbWpName.ListIndex + 1)
                    
                    '@〓 "△" or "○" or "◎" 〓
                    Case CMstrKouho, CMstrJidou, CMstrKakutei
                        
                        '@処理なし
                    
                    '@〓 その他(NULL) 〓
                    Case Else

                        Exit Function
                
                End Select
                
                '@⑦ﾚｼﾋﾟ設定済、かつ選択ﾛｯﾄとﾚｼﾋﾟが異なるか
                If frmxxEN00M0.Instance.lblRecipeID.Text <> vbNullString And _
                    .GetData(.Row, mlngvsfLotRecipeIdC) <> frmxxEN00M0.Instance.lblRecipeID.Text Then
                    
                    Exit Function
                End If
                
        '@↓2009/07/30 (Thu) 15:20:25 N.Kojima **************************************************
        '@↓2009/08/17 (Mon) 09:35:40 N.Kojima **************************************************
                '@⑧基板起動で、かつﾊﾞｯﾁ管理画面のﾊﾞｯﾁ組ﾛｯﾄ情報ｸﾞﾘｯﾄﾞに既にﾓﾆﾀが編成されているか
                If pstrSBID = CPstrSBID1A0 Then
                    
                    '@ﾊﾞｯﾁ組予定ﾛｯﾄｸﾞﾘｯﾄﾞにﾃﾞｰﾀが存在するか
                    If frmxxEN00M0.Instance.vsfBat.Rows.Count > 1 Then
                    
                        '@順=0の行のﾛｯﾄIDがNULL以外(既にﾓﾆﾀﾛｯﾄが編成されている)
                        If frmxxEN00M0.Instance.vsfBat.GetData(1, CMlngvsfBatSeqNumC) = CPstrZero And _
                            frmxxEN00M0.Instance.vsfBat.GetData(1, CMlngvsfBatLotIdC) <> vbNullString Then
                            
                            Exit Function
                        End If
                    End If
                End If
        '@↑2009/08/17 (Mon) 09:35:40 N.Kojima **************************************************
        '@↑2009/07/30 (Thu) 15:20:25 N.Kojima **************************************************

        '@↓2009/08/06 (Thu) 10:46:55 N.Kojima **************************************************
                
                '@呼び元ｲﾍﾞﾝﾄが確定ﾎﾞﾀﾝ処理か
                If lstrCallEvent = CMstrCmdKakuteiClick Then
                
                    '@⑨表面処理の場合、装置仕様のﾊﾞｯﾁ組順と異なるか
                    '@-----------------------
                    '@ 編成順ﾁｪｯｸ(表面処理装置)
                    '@
                    '@ << 仕様 >>
                    '@ 　表面処理装置のﾊﾞｯﾁ組順は「製品ﾛｯﾄ、試作/実験品ﾛｯﾄ(PRODUCT(TEG))⇒ﾓﾆﾀﾛｯﾄ(MONITOR)⇒ﾌｨﾙﾀﾞﾐｰ(FILLER(DUMMY))⇒その他」の
                    '@ 　順でﾊﾞｯﾁ組されていなければ装置的にﾀﾞﾒだそうです。
                    '@ 　例)PRODUCT(TEG) Only ：OK、PRODUCT(TEG) ⇒ MONITOR：OK、PRODUCT(TEG) ⇒ FILLER(DUMMY)：OK
                    '@ 　　 MONITOR Only ：OK、MONITOR ⇒ FILLER(DUMMY) ：OK
                    '@ 　　 FILLER(DUMMY)  Only ：OK
                    '@ 　　 MONITOR ⇒ PRODUCT(TEG) ：NG、FILLER(DUMMY) ⇒ PRODUCT(TEG) ：NG、FILLER(DUMMY) ⇒ MONITOR ：NG
                    '@-----------------------
            
                    '@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
                    frmxxEN00M0.Instance.cmbWpName.ValueCol = CMlngCmbWpNameEqType
                
                    '@装置ﾀｲﾌﾟが"20：表面処理装置"か
                    If frmxxEN00M0.Instance.cmbWpName.Value = CPstrEqTypeHyoumenSyori Then

                        '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
                        frmxxEN00M0.Instance.cmbWpName.ValueCol = CMlngCmbWpNameName

                        '@ﾊﾞｯﾁ組予定ﾛｯﾄ数が1件以上あるか(1ﾛｯﾄ目は何が編成されてもOK)
                        If frmxxEN00M0.Instance.vsfBat.Rows.Count > 2 Then
                        
                            '@ﾊﾞｯﾁ編成ｴﾗｰﾌﾗｸﾞの初期化
                            lblnEditBatchErrFlag = False
                            
                            '@★ ﾊﾞｯﾁ組予定ﾛｯﾄの機種区分により処理分岐 ★
                            Select Case UCase(.GetData(.Row, mlngvsfLotUseIDC))
                            
                                '@〓 PRODUCT(TEG)：製品ﾛｯﾄ、試作/実験品ﾛｯﾄ 〓
                                Case CPstrUseIDProduct, CPstrUseIDTeg
                                    
                                    '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の製品ﾛｯﾄ行より上に"MONITOR" or "FILLER(DUMMY)"ﾛｯﾄが存在するか
                                    If frmxxEN00M0.Instance.vsfBat.GetData(frmxxEN00M0.Instance.vsfBat.Rows.Count - 1, CMlngvsfBatUseIDC) = CPstrUseIDMonitor Or _
                                        frmxxEN00M0.Instance.vsfBat.GetData(frmxxEN00M0.Instance.vsfBat.Rows.Count - 1, CMlngvsfBatUseIDC) = CPstrUseIDFiller Or _
                                        frmxxEN00M0.Instance.vsfBat.GetData(frmxxEN00M0.Instance.vsfBat.Rows.Count - 1, CMlngvsfBatUseIDC) = CPstrUseIDDummy Then
                                        
                                        '@ﾊﾞｯﾁ編成ｴﾗｰﾌﾗｸﾞに"True：ｴﾗｰ"をｾｯﾄ
                                        lblnEditBatchErrFlag = True
                                    End If
            
            
                                '@〓 MONITOR：ﾓﾆﾀﾛｯﾄ 〓
                                Case CPstrUseIDMonitor
                
                                    '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧のﾓﾆﾀﾛｯﾄ行より上に"FILLER(DUMMY)"ﾛｯﾄが存在するか
                                    If frmxxEN00M0.Instance.vsfBat.GetData(frmxxEN00M0.Instance.vsfBat.Rows.Count - 1, CMlngvsfBatUseIDC) = CPstrUseIDFiller Or _
                                        frmxxEN00M0.Instance.vsfBat.GetData(frmxxEN00M0.Instance.vsfBat.Rows.Count - 1, CMlngvsfBatUseIDC) = CPstrUseIDDummy Then
                                        
                                        '@ﾊﾞｯﾁ編成ｴﾗｰﾌﾗｸﾞに"True：ｴﾗｰ"をｾｯﾄ
                                        lblnEditBatchErrFlag = True
                                    End If
            
            
                                '@〓 FILLER(DUMMY)：ﾌｨﾙﾀﾞﾐｰﾛｯﾄ 〓
                                Case CPstrUseIDFiller
                                
                                    '@ﾊﾞｯﾁ編成順の最下位なので上位の順がOKなら良い
            
            
                                '@〓 その他 〓
                                Case CPstrUseIDDummy
                
                                    '@制約なし
                
                            End Select
                
                            '@編成順ﾁｪｯｸでｴﾗｰがあったか
                            If lblnEditBatchErrFlag = True Then
                
                                '@表示ﾒｯｾｰｼﾞ変換
                                '@"<TRM1SW>$$表面処理装置のバッチ組は装置仕様に従い、
                                '@ $[製品ロット]⇒[モニタロット]⇒[フィルダミーロット]
                                '@ $の順でバッチ組してください。"のﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001S)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                Exit Function
                            End If
                        End If
                    Else
                        '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
                        frmxxEN00M0.Instance.cmbWpName.ValueCol = CMlngCmbWpNameName
                    End If
                    
                End If

        '@↑2009/08/06 (Thu) 10:46:55 N.Kojima **************************************************

            End With
            
            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblnLot_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnLot_Chk"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
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
            gridObj.AutoSizeCol(colindex,6)
        End If

    End Sub

End Class
