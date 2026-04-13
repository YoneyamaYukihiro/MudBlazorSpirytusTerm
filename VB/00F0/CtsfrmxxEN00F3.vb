'ﾌｧｲﾙ名：xxEN00F3.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：組立在庫分割予約(在庫管理サブフォーム)
'作成日：2004/07/02 (Fri) 17:20:37 S.Deguchi
'更新日：2008/06/24 (Tue) 15:58:23 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00F3
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00F3    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00F3
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00F3
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00F3)
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
    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN00F3                 'ﾛｰｶﾙ機能ID
                                                                                               
    '@Msgﾊﾞｰｼﾞｮﾝ                                                                               
    '@↓2020/01/27 (Mon) 16:07:23 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrinv_waferlistVer             As String = "03.01"                     'ｳｪﾊ在庫情報取得
    Private Const CMstrinv_waferlistVer             As String = "04.00"                     'ｳｪﾊ在庫情報取得
    '@↑2020/01/27 (Mon) 16:07:23 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_asmdivideVer             As String = "04.00"                        '組立在庫分割
    Private Const CMstrcarrcurstateVer              As String = "05.02"                        'ｷｬﾘｱ状態確認

    '@vsfSlotMapの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfSlotMapColNo              As Integer = 0                             '№
    Private Const CMlngvsfSlotMapColWFID            As Integer = 1                             'WF ID
    Private Const CMlngvsfSlotMapColClassID         As Integer = 2                             'Class_ID
    Private Const CMlngvsfSlotMapColStatus          As Integer = 3                             '状況
    Private Const CMlngvsfSlotMapColBNo             As Integer = 4                             '通し番号
    '@↓2019/09/30 (Mon) 18:28:54 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfSlotMapColGRB             As Integer = 5                             'GRB
    '@↑2019/09/30 (Mon) 18:28:54 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsfSlotMapの定数宣言(幅)
    Private Const CMlngvsfSlotMapWColNo             As Integer = 33                            '№
    Private Const CMlngvsfSlotMapWColWFID           As Integer = 121                           'WF ID
    Private Const CMlngvsfSlotMapWColClassID        As Integer = 121                           'Class_ID
    Private Const CMlngvsfSlotMapWColStatus         As Integer = 60                            '状況
    Private Const CMlngvsfSlotMapWColBNo            As Integer = 33                            '通し番号
    '@↓2019/09/30 (Mon) 18:29:32 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfSlotMapWColGRB            As Integer = 33                             'GRB
    '@↑2019/09/30 (Mon) 18:29:32 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsfSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfSlotMapColNo              As String = ""                             '№
    Private Const CMstrvsfSlotMapColWFID            As String = "WFID"                         'WF_ID
    Private Const CMstrvsfSlotMapColClassID         As String = "Class_ID"                     'Class_ID
    Private Const CMstrvsfSlotMapColStatus          As String = "状況"                         '状況
    Private Const CMstrvsfSlotMapColBNo             As String = "番号"                         '通し番号
    '@↓2019/09/30 (Mon) 18:28:42 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrvsfSlotMapColGRB             As String = "GRB"                           'GRB
    '@↑2019/09/30 (Mon) 18:28:42 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                  As Integer = 0                             'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                  As Integer = 0                             'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                 As Integer = 14                            'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                   As Integer = 22                            'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfFontSize                  As Integer = 16                            'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHeight                    As Integer = 43                            '1ｽﾛｯﾄの高さ
    Private Const CMlngSlotRow                      As Integer = 26                            '全ｽﾛｯﾄ
    Private Const CMlngSlotTopRow                   As Integer = 16                            '全ｽﾛｯﾄ
    Private Const CMlngCarrierRowS                  As Integer = 25                            'ｽﾛｯﾄ数
    Private Const CMlngGrid3DBlank                  As Integer = 90                            'ｸﾞﾘｯﾄﾞの3D表示の余白
    Private Const CMlngSlotNo0                      As Integer = 0                             '記載ｽﾛｯﾄ=0
    Private Const CMlngSlotNo1                      As Integer = 1                             '記載ｽﾛｯﾄ=1
    Private Const CMlngSlotNo2                      As Integer = 2                             '記載ｽﾛｯﾄ=2
    Private Const CMlngSlotNo3                      As Integer = 3                             '記載ｽﾛｯﾄ=3
    Private Const CMlngSlotNo4                      As Integer = 4                             '記載ｽﾛｯﾄ=4
    Private Const CMlngSlotNo5                      As Integer = 5                             '記載ｽﾛｯﾄ=5
    Private Const CMlngSlotNo6                      As Integer = 6                             '記載ｽﾛｯﾄ=6
    Private Const CMlngSlotNo7                      As Integer = 7                             '記載ｽﾛｯﾄ=7
    Private Const CMlngSlotNo8                      As Integer = 8                             '記載ｽﾛｯﾄ=8
    Private Const CMlngSlotNo9                      As Integer = 9                             '記載ｽﾛｯﾄ=9
    Private Const CMlngSlotNo10                     As Integer = 10                            '記載ｽﾛｯﾄ=10
    Private Const CMlngSlotNo11                     As Integer = 11                            '記載ｽﾛｯﾄ=11
    Private Const CMlngSlotNo12                     As Integer = 12                            '記載ｽﾛｯﾄ=12
    Private Const CMlngSlotNo13                     As Integer = 13                            '記載ｽﾛｯﾄ=13
    Private Const CMlngSlotNo14                     As Integer = 14                            '記載ｽﾛｯﾄ=14
    Private Const CMlngSlotNo15                     As Integer = 15                            '記載ｽﾛｯﾄ=15
    Private Const CMlngSlotNo16                     As Integer = 16                            '記載ｽﾛｯﾄ=16
    Private Const CMlngSlotNo17                     As Integer = 17                            '記載ｽﾛｯﾄ=17
    Private Const CMlngSlotNo18                     As Integer = 18                            '記載ｽﾛｯﾄ=18
    Private Const CMlngSlotNo19                     As Integer = 19                            '記載ｽﾛｯﾄ=19
    Private Const CMlngSlotNo20                     As Integer = 20                            '記載ｽﾛｯﾄ=20
    Private Const CMlngSlotMap1                     As Integer = 1                             'ｽﾛｯﾄﾄｰﾀﾙ数(移載の最小数)
    Private Const CMlngSlotMap5                     As Integer = 5                             'ｽﾛｯﾄﾄｰﾀﾙ数(移載の最大数)
    Private Const CMlngSlotMap6                     As Integer = 6                             'ｽﾛｯﾄﾄｰﾀﾙ数(移載/分割の最小数)
    Private Const CMlngSlotMap10                    As Integer = 10                            'ｽﾛｯﾄﾄｰﾀﾙ数(移載/分割の最大数)
    Private Const CMlngSlotMap11                    As Integer = 11                            'ｽﾛｯﾄﾄｰﾀﾙ数(移載の最小数)
    Private Const CMlngSlotMap15                    As Integer = 15                            'ｽﾛｯﾄﾄｰﾀﾙ数(移載の最大数)
    Private Const CMlngSlotMap16                    As Integer = 16                            'ｽﾛｯﾄﾄｰﾀﾙ数(移載/分割の最小数)
    Private Const CMlngSlotMap20                    As Integer = 20                            'ｽﾛｯﾄﾄｰﾀﾙ数(移載/分割の最大数)
    Private Const CMlngSlotMapRowS                  As Integer = 26                            '行数

    Private Const CMlngRowNo1                       As Integer = 1                             'SlotMapのTopRow判定用
    Private Const CMlngRowNo6                       As Integer = 6                             'SlotMapのTopRow判定用
    Private Const CMlngRowNo10                      As Integer = 10                            'SlotMapのTopRow判定用
    Private Const CMlngRowNo11                      As Integer = 11                            'SlotMapのTopRow判定用
    Private Const CMlngRowNo15                      As Integer = 15                            'SlotMapのTopRow判定用
    Private Const CMlngRowNo16                      As Integer = 16                            'SlotMapのTopRow判定用
    Private Const CMlngRowNo25                      As Integer = 25                            'SlotMapのTopRow判定用

    '@vsfSlotMapの高さ設定
    Private Const CMlngvsfGridHeight                As Integer = 454

    '@移載/分割ﾌﾗｸﾞ
    Private Const CMlngNothing                      As Integer = 0                             '該当件数なし=0
    Private Const CMlngTransfer                     As Integer = 1                             '移載=1
    Private Const CMlngPartition                    As Integer = 2                             '分割=2
    Private Const CMlngManual                       As Integer = 3                             '該当件数10件以上

    '@元ｽﾛｯﾄﾏｯﾌﾟ用定数宣言
    Private Const CMlngSlotMapNo0                   As Integer = 0                             '元ｷｬﾘｱ ｽﾛｯﾄﾏｯﾌﾟ
    Private Const CMlngSlotMapNo1                   As Integer = 1                             '分割予約1 ｽﾛｯﾄﾏｯﾌﾟ
    Private Const CMlngSlotMapNo2                   As Integer = 2                             '分割予約2 ｽﾛｯﾄﾏｯﾌﾟ

    Private Const CMlngEnableFalseColor             As Integer = &H80000004                    '灰色(使用不可)

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                     As String = "frmxxEN00F3"                  '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                     As String = "Form_Load"                    'Form_Load処理
    Private Const CMstrCmdRegistClick               As String = "cmdRegist_Click"              '確定ﾎﾞﾀﾝ押下時処理
    Private Const CMstrCmdLumpDivideWF1Click        As String = "cmdLumpDivideWF1_Click"       '一括分割#01-10ﾎﾞﾀﾝ押下時処理
    Private Const CMstrCmdLumpDivideWF2Click        As String = "cmdLumpDivideWF2_Click"       '一括分割#11-20ﾎﾞﾀﾝ押下時処理
    Private Const CMstrTxtToCarrierID1Validate      As String = "txtToCarrierID1_Validate"     '分割予約1ｷｬﾘｱValidate処理
    Private Const CMstrTxtToCarrierID2Validate      As String = "txtToCarrierID2_Validate"     '分割予約2ｷｬﾘｱValidate処理

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mtypInvWaferList                        As InvWaferList                         '在庫WFﾘｽﾄ格納構造体
    Private mstrLotLastUpdate                       As String                               '最終更新日時
    Private mstrToCarrierID1                        As String                               'ｷｬﾘｱID1退避
    Private mstrToCarrierID2                        As String                               'ｷｬﾘｱID2退避
    Private mstrSlotSize                            As String                               'ｽﾛｯﾄｻｲｽﾞ
    Private mlngWFNum                               As Integer                              '分割元ｽﾛｯﾄﾏｯﾌﾟWF数
    Private mlngFormationFlag                       As Integer                              '移載/分割ﾌﾗｸﾞ(該当件数なし=0/移載=1/分割=2/手動移載分割=3)
    Private mblnFormLoadFlag                        As Boolean                              'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：起動時以外/False：起動時のみ)

    '@内部構造体(ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ格納)
    Private Structure SlotPosition
        Dim lngSlotNo                                   As Integer                          'ｽﾛｯﾄ№
        Dim strWfId                                     As String                           'WF_ID
        Dim strStatus                                   As String                           '状況
        Dim strClassID                                  As String                           'ClassID
        '@↓2019/10/01 (Tue) 11:41:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
        Dim strGRB                                      As String                           'GRB
        '@↑2019/10/01 (Tue) 11:41:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
    End Structure
    Private mtypSlotPosition1                       As List(Of SlotPosition)                 '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報格納用配列(#01-05)
    Private mtypSlotPosition2                       As List(Of SlotPosition)                 '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報格納用配列(#06-10)
    Private mtypSlotPosition3                       As List(Of SlotPosition)                 '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報格納用配列(#11-15)
    Private mtypSlotPosition4                       As List(Of SlotPosition)                 '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報格納用配列(#16-20)
    Private mlngSlotPosition1Cnt                    As Integer                               '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#01-05)
    Private mlngSlotPosition2Cnt                    As Integer                               '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#06-10)
    Private mlngSlotPosition3Cnt                    As Integer                               '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#11-15)
    Private mlngSlotPosition4Cnt                    As Integer                               '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#16-20)
    Private mtypTransfer                            As SlotPosition                          '手動移動時元ｷｬﾘｱ情報格納
    Private mtyplotasmdivide                        As LotAsmdivide                          '組立在庫分割構造体
    Private buttonProcessing                        As Boolean                               'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                               'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                               'NSYS WindowCloseフラグ

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
        pubVsfMouseWheelManager_Set(vsfSlotMap2, cmdUp2, cmdDown2)
        pubVsfMouseWheelManager_Set(vsfSlotMap1, cmdUp1, cmdDown1)
        pubVsfMouseWheelManager_Set(vsfSlotMap, cmdUp, cmdDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　ﾛｰﾄﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 17:24:49 S.Deguchi
    '更新日：2008/04/09 (Wed) 09:39:14 N.Kojima
    '備　考：
    '　　　：2004/07/27 (Tue) 17:49:59 Y.Yamagishi
    '　　　：2004/10/13 (Wed) 17:03:20 N.Kasai      pubblnInvWaferlist_Selﾒｯｾｰｼﾞ変更対応
    '　　　：2008/04/09 (Wed) 09:39:14 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean          'ﾛｯﾄ保留理由取得戻り値(True/False)

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
                        
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@=======================
            '@　画面情報の初期化処理
            '@=======================
            Call prvFrmxxEN00F3_Init()
                
            '@ｷｬﾘｱIDの背景色
            lblCarrier.BackColor = SystemColors.ControlLight
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@構造体の初期化
            '移載/分割元WFID位置(#01-05)
            If mtypSlotPosition1 Is Nothing Then
                mtypSlotPosition1 = New List(Of SlotPosition)
            Else
                mtypSlotPosition1.Clear
            End If 
            '移載/分割元WFID位置(#06-10)
            If mtypSlotPosition2 Is Nothing Then
                mtypSlotPosition2 = New List(Of SlotPosition)
            Else
                mtypSlotPosition2.Clear
            End If 
            '移載/分割元WFID位置(#11-15)
            If mtypSlotPosition3 Is Nothing Then
                mtypSlotPosition3 = New List(Of SlotPosition)
            Else
                mtypSlotPosition3.Clear
            End If 
            '移載/分割元WFID位置(#16-20)
            If mtypSlotPosition4 Is Nothing Then
                mtypSlotPosition4 = New List(Of SlotPosition)
            Else
                mtypSlotPosition4.Clear
            End If 
            If mtypInvWaferList.typInvWaferList Is Nothing Then
                mtypInvWaferList.typInvWaferList = New List(Of InvWafer)
            Else
                mtypInvWaferList.typInvWaferList.Clear
            End If 
            mlngSlotPosition1Cnt = 0                        '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#01-05)
            mlngSlotPosition2Cnt = 0                        '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#06-10)
            mlngSlotPosition3Cnt = 0                        '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#11-15)
            mlngSlotPosition4Cnt = 0                        '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#16-20)
            
            '@【在庫WFﾘｽﾄ取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnInvWaferlist_Sel(CMstrinv_waferlistVer, _
                                             ptypHoldConnect.strCarrierId, _
                                             pstrSBID, _
                                             mtypInvWaferList)
            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            
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
    '機　能：ﾌｫｰﾑ　有効時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/04 (Mon) 11:41:04 S.Deguchi
    '更新日：2008/04/09 (Wed) 09:40:49 N.Kojima
    '備　考：
    '　　　：2006/05/15 (Mon) 10:10:34 M.Miura      不具合№3434対応 組立在庫分割予約画面のSLOT表示が適正でない
    '　　　：2008/04/09 (Wed) 09:40:49 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Dim llngCnt         As Integer          '汎用ｶｳﾝﾀ
        Dim llngTopRow      As Integer          '先頭行格納
        Dim llngRow         As Integer          'ｽﾛｯﾄﾏｯﾌﾟ№

        Try
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If mblnFormLoadFlag = False Then
            
                '画面表示位置
                Me.Top = 0
                Me.Left = 0 - My.Settings.FormOffset

                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@=======================
                '@　画面情報表示処理
                '@=======================
                Call prvConnectInfo_Disp()
                
                '@=======================
                '@　元ｷｬﾘｱのWF情報表示処理
                '@=======================
                Call prvVsfSlotMap_Disp()
                
                '@=======================
                '@　ｿｰﾄ前処理
                '@=======================
                Call pubVsfBeforeSort(vsfSlotMap, CMlngvsfSlotMapColWFID)
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝの活性化制御
                cmdUP.Enabled = True
                
                '@=======================
                '@　分割元ｽﾛｯﾄﾏｯﾌﾟ情報格納処理
                '@=======================
                Call prvVsfSlotMapInfo_Set(mlngWFNum)
                
                '@分割元ｽﾛｯﾄﾏｯﾌﾟ
                With vsfSlotMap
                
                    For llngCnt = 1 To .Rows.Count - 1
                        
                        '@ｽﾛｯﾄ番号を行番号へ置換
                        llngRow = CMlngSlotMapRowS - llngCnt
                        
                        '@WFIDがNULL以外か
                        If .GetData(llngRow, CMlngvsfSlotMapColWFID) <> vbNullString Then
                            
                            '@先頭行の設定
                            '@★ 選択行により処理分岐 ★
                            Select Case llngCnt
                            
                                '@〓 ｽﾛｯﾄ№25～16(行番号：1～10) 〓
                                Case 1 To 10
                                
                                    '@先頭行をｽﾛｯﾄ№25(1行目)に設定
                                    llngTopRow = CMlngRowNo16
                                    Exit For
                                    
                                '@〓 ｽﾛｯﾄ№15～06(行番号：11～20) 〓
                                Case 11 To 20
                                
                                    '@先頭行をｽﾛｯﾄ№20(6行目)に設定
                                    llngTopRow = CMlngRowNo6
                                    Exit For
                                
                                '@〓 ｽﾛｯﾄ№05～01(行番号：21～25) 〓
                                Case 21 To 25
                                
                                    '@先頭行をｽﾛｯﾄ№10(16行目)に設定
                                    llngTopRow = CMlngRowNo1
                                    Exit For
                            End Select
                        End If
                    Next llngCnt
                    
                    '@先頭行設定
                    .TopRow = llngTopRow
                    
                    '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御
                    '@★ 上記で設定した先頭行により処理分岐 ★
                    Select Case llngTopRow
                        
                        '@〓 先頭行がｽﾛｯﾄ№10(16行目) 〓
                        Case CMlngSlotTopRow
                            
                            '@ｽｸﾛｰﾙﾎﾞﾀﾝの活性化制御
                            cmdUP.Enabled = True
                            cmdDown.Enabled = False
                        
                        '@〓 先頭行がｽﾛｯﾄ№20(6行目) 〓
                        Case CMlngSlotMap6
                            
                            '@ｽｸﾛｰﾙﾎﾞﾀﾝの活性化制御
                            cmdUP.Enabled = True
                            cmdDown.Enabled = True
                            
                        '@〓 先頭行がｽﾛｯﾄ№25(1行目) 〓
                        Case Else
                            
                            '@ｽｸﾛｰﾙﾎﾞﾀﾝの活性化制御
                            cmdUP.Enabled = False
                            cmdDown.Enabled = True
                    End Select
                End With
                
                '@=======================
                '@　各種ﾎﾞﾀﾝ制御
                '@=======================
                Call prvObjectControl_Proc()
                
                '@★ 有効なﾎﾞﾀﾝによりﾌｫｰｶｽ遷移処理分岐 〓
                Select Case True
                
                    '@〓 一括分割#01-10ﾎﾞﾀﾝ、一括分割#11-20ﾎﾞﾀﾝ 〓
                    Case cmdLumpDivideWF1.Enabled And cmdLumpDivideWF2.Enabled
                    
                        Call pubSetFocus(cmdLumpDivideWF1)
                
                    '@〓 一括分割#01-10ﾎﾞﾀﾝ 〓
                    Case cmdLumpDivideWF1.Enabled
                    
                        Call pubSetFocus(cmdLumpDivideWF1)
                
                    '@〓 一括分割#11-20ﾎﾞﾀﾝ 〓
                    Case cmdLumpDivideWF2.Enabled
                    
                        Call pubSetFocus(cmdLumpDivideWF2)
                
                    '@〓 編成用手動分割ﾎﾞﾀﾝ 〓
                    Case Else
                    
                        Call pubSetFocus(cmdManual)
                
                End Select
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
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode    ：ｷｰｺｰﾄﾞ
    '　　　：Shift      ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2004/07/08 (Thu) 16:39:30 S.Deguchi
    '更新日：2008/04/09 (Wed) 09:46:53 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 09:46:53 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@以下の条件の場合Key入力を無効にする
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If

            '@=======================
            '@　分割元ｸﾞﾘｯﾄﾞｷｰ制御
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfSlotMap, cmdUP, cmdDown)
            
            '@=======================
            '@　分割予約1ｸﾞﾘｯﾄﾞｷｰ制御
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfSlotMap1, cmdUP1, cmdDown1)
            
            '@=======================
            '@　分割予約2ｸﾞﾘｯﾄﾞｷｰ制御
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfSlotMap2, cmdUP2, cmdDown2)

            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
                
                '@〓 分割予約1ｷｬﾘｱID 〓
                Case txtToCarrierID1.Name
                    
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@=======================
                            '@　分割予約1ｷｬﾘｱIDのValidate処理
                            '@=======================
                            RemoveHandler txtToCarrierID1.Validating,AddressOf txtToCarrierID1_Validate
                            Call txtToCarrierID1_Validate(txtToCarrierID1,New CancelEventArgs(True))
                            AddHandler txtToCarrierID1.Validating,AddressOf txtToCarrierID1_Validate
                    End Select
                    
                '@〓 分割予約2ｷｬﾘｱID 〓
                Case txtToCarrierID2.Name
                
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@=======================
                            '@　分割予約2ｷｬﾘｱIDのValidate処理
                            '@=======================
                            RemoveHandler txtToCarrierID2.Validating,AddressOf txtToCarrierID2_Validate
                            Call txtToCarrierID2_Validate(txtToCarrierID2,New CancelEventArgs(True))
                            AddHandler txtToCarrierID2.Validating,AddressOf txtToCarrierID2_Validate
                    End Select
                
                '@〓 分割元ｸﾞﾘｯﾄﾞ 〓
                Case vsfSlotMap.Name
                
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@=======================
                            '@　ｸﾘｯｸｲﾍﾞﾝﾄを呼出す
                            '@=======================
                            Call vsfSlotMap_Click(vsfSlotMap,New EventArgs)
                    End Select
                
                
                '@〓 分割予約1ｸﾞﾘｯﾄﾞ 〓
                Case vsfSlotMap1.Name
                
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@=======================
                            '@　ｸﾘｯｸｲﾍﾞﾝﾄを呼出す
                            '@=======================
                            Call vsfSlotMap1_Click(vsfSlotMap1,New EventArgs)
                    End Select
                    
                '@〓 分割予約2ｸﾞﾘｯﾄﾞ 〓
                Case vsfSlotMap2.Name
                
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@=======================
                            '@　ｸﾘｯｸｲﾍﾞﾝﾄを呼出す
                            '@=======================
                            Call vsfSlotMap2_Click(vsfSlotMap2,New EventArgs)
                    End Select
                
                '@〓 その他 〓
                Case Else

                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
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
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/07/09 (Fri) 08:51:51 S.Deguchi
    '更新日：2008/04/09 (Wed) 09:53:18 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 09:53:18 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim ltypInvWaferList    As InvWaferList         '在庫WFﾘｽﾄ格納構造体初期化用
        Dim ltypTransfer        As SlotPosition         '手動移動時分割元情報格納用構造体初期化用
        Dim ltyplotasmdivide    As LotAsmdivide         '組立在庫分割構造体初期化用

        Try

            


            '@構造体の初期化
            '移載/分割元WFID位置(#01-05)
            If mtypSlotPosition1 Is Nothing Then
                mtypSlotPosition1 = New List(Of SlotPosition)
            End If
            '移載/分割元WFID位置(#06-10)
            If mtypSlotPosition2 Is Nothing Then
                mtypSlotPosition2 = New List(Of SlotPosition)
            End If
            '移載/分割元WFID位置(#11-15)
            If mtypSlotPosition3 Is Nothing Then
                mtypSlotPosition3 = New List(Of SlotPosition)
            End If
            '移載/分割元WFID位置(#16-20)
            If mtypSlotPosition4 Is Nothing Then
                mtypSlotPosition4 = New List(Of SlotPosition)
            End If

            mtypInvWaferList = ltypInvWaferList         '在庫WFﾘｽﾄ格納構造体
            mlngSlotPosition1Cnt = 0                    '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#01-05)
            mlngSlotPosition2Cnt = 0                    '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#06-10)
            mlngSlotPosition3Cnt = 0                    '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#11-15)
            mlngSlotPosition4Cnt = 0                    '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#16-20)
            mtypTransfer = ltypTransfer                 '手動移動時元ｷｬﾘｱ情報格納
            mtyplotasmdivide = ltyplotasmdivide         '組立在庫分割構造体
            
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

    '関数名：vsfSlotMap_Click
    '機　能：分割元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/06 (Wed) 09:25:50 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub vsfSlotMap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap.Click
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If

            With vsfSlotMap
                
                '@ﾀｲﾄﾙ以外か
                If .Row > 0 Then
                    
                    '@選択行のWFIDがNULL以外か
                    If .GetData(.Row, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        
                        '@選択行のWFIDの文字色が黒色か
                        If .GetCellRange(.Row, CMlngvsfSlotMapColWFID).StyleDisplay.ForeColor = Color.Black Then
                        
                            '@退避構造体へ選択行の情報をｾｯﾄ
                            mtypTransfer.strWfId = .GetData(.Row, CMlngvsfSlotMapColWFID)          'WFID
                            mtypTransfer.strStatus = .GetData(.Row, CMlngvsfSlotMapColStatus)      '状況
                            mtypTransfer.strClassID = .GetData(.Row, CMlngvsfSlotMapColClassID)    'ClassID
                            mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfSlotMapColBNo)         '移載元№
                            '@↓2019/10/01 (Tue) 11:39:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            mtypTransfer.strGRB = .GetData(.Row, CMlngvsfSlotMapColGRB)            'GRB
                            '@↑2019/10/01 (Tue) 11:39:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        Else
                            '@文字色がｸﾞﾚｰの場合
                            
                            '@退避：移載元№と同じ場合
                            If mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfSlotMapColBNo) Then
                                
                                '@=======================
                                '@　ｸﾞﾘｯﾄﾞ反映処理
                                '@=======================
                                Call prvVsfSlotMapCell_Proc(vsfSlotMap, .Row)
                            End If
                        End If
                    End If
                End If
            End With
            
            '@=======================
            '@　WF枚数をｶｳﾝﾄし、ﾗﾍﾞﾙに表示する処理
            '@=======================
            Call prvVsfSlotMap_Cal()
            
            '@=======================
            '@　ﾃｷｽﾄﾎﾞｯｸｽ、ｷｬﾘｱ選択ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCarrierControl_Proc(vsfSlotMap1, txtToCarrierID1, cmdCarrierSelect1)    '分割予約1
            Call prvCarrierControl_Proc(vsfSlotMap2, txtToCarrierID2, cmdCarrierSelect2)    '分割予約2
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdRegistControl_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap_LostFocus
    '機　能：分割元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　LostFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/06 (Wed) 13:36:17 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub vsfSlotMap_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap.Leave
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If
            
            'NSYS ヘッダー選択時処理を抜ける
            If vsfSlotMap.Row < vsfSlotMap.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽが抜ける段階で退避構造体と選択ｾﾙの内容が異なる場合、
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfSlotMap
                
                '@選択行のWFIDがNULL以外か
                If .GetData(.Row, CMlngvsfSlotMapColWFID) <> vbNullString Then
                    
                    '@選択行のWFIDの文字色が黒色か
                    If .GetCellRange(.Row, CMlngvsfSlotMapColWFID).StyleDisplay.ForeColor = Color.Black Then
                        
                        '@退避構造体のWFIDと選択行のWFIDが異なるか
                        If mtypTransfer.strWfId <> .GetData(.Row, CMlngvsfSlotMapColWFID) Then
                        
                            '@退避構造体へ情報をｾｯﾄ
                            mtypTransfer.strWfId = .GetData(.Row, CMlngvsfSlotMapColWFID)          'WFID
                            mtypTransfer.strStatus = .GetData(.Row, CMlngvsfSlotMapColStatus)      '状況
                            mtypTransfer.strClassID = .GetData(.Row, CMlngvsfSlotMapColClassID)    'ClassID
                            mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfSlotMapColBNo)         '移載元№
                            '@↓2019/10/01 (Tue) 11:42:32 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            mtypTransfer.strGRB = .GetData(.Row, CMlngvsfSlotMapColGRB)            'GRB
                            '@↑2019/10/01 (Tue) 11:42:32 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        End If
                    Else
                        '@選択行のWFIDの文字色が黒色以外の場合
                        
                        '@退避構造体のWFIDと選択行のWFIDが異なるか
                        If mtypTransfer.strWfId <> .GetData(.Row, CMlngvsfSlotMapColWFID) Then
                            
                            '@退避構造体の情報をｸﾘｱ
                            mtypTransfer.strWfId = vbNullString         'WFID
                            mtypTransfer.strStatus = vbNullString       '状況
                            mtypTransfer.strClassID = vbNullString      'ClassID
                            mtypTransfer.lngSlotNo = 0                  '移載元№
                            '@↓2019/10/01 (Tue) 11:43:16 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            mtypTransfer.strGRB = vbNullString          'GRB
                            '@↑2019/10/01 (Tue) 11:43:16 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        End If
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：上ｽｸﾛｰﾙ(▲)ﾎﾞﾀﾝ(分割元ｽﾛｯﾄﾏｯﾌﾟ)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/04 (Mon) 12:02:37 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:47:44 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:47:44 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
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
            '@　上ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubVsfCmdUp(vsfSlotMap, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUP_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：下ｽｸﾛｰﾙ(▼)ﾎﾞﾀﾝ(分割元ｽﾛｯﾄﾏｯﾌﾟ)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/04 (Mon) 12:02:35 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
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
            '@　下ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubVsfCmdDown(vsfSlotMap, cmdUP, cmdDown, False)

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

    '@↓2008/04/14 (Mon) 14:33:19 N.Kojima **************************************************
    '関数名：cmdLumpDivideWF1_Click
    '機　能：一括分割#01-10ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/04/09 (Wed) 10:06:41 N.Kojima
    '更新日：2008/04/09 (Wed) 10:06:41
    '備　考：
    Private Sub cmdLumpDivideWF1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLumpDivideWF1.Click

        Dim llngCnt             As Integer      'ｶｳﾝﾀ
        Dim llngMapJudgeFlag    As Integer      '分割元用判定ﾌﾗｸﾞ(1:№05-01にWFあり、2:№10-06にWFあり、3:№10-06&05-01にWFあり)

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfSlotMap
                
                '@分割元ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄ№10-06分ﾙｰﾌﾟ
                For llngCnt = 16 To 20
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟにて、ｽﾛｯﾄ№10-06にWFIDが存在するか
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        '@分割元用判定ﾌﾗｸﾞに"2:№10-06にWFあり"をｾｯﾄ
                        llngMapJudgeFlag = 2
                        Exit For
                    End If
                Next llngCnt
                
                '@分割元ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄ№05-01分ﾙｰﾌﾟ
                For llngCnt = 21 To 25
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟにて、ｽﾛｯﾄ№05-01にWFIDが存在するか
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        '@分割元用判定ﾌﾗｸﾞが"2:№10-06にWFあり"か
                        If llngMapJudgeFlag = 2 Then
                            '@分割元用判定ﾌﾗｸﾞに"3:№10-06&05-01にWFあり"をｾｯﾄ
                            llngMapJudgeFlag = 3
                            Exit For
                        Else
                            '@分割元用判定ﾌﾗｸﾞに"1:№05-01にWFあり"をｾｯﾄ
                            llngMapJudgeFlag = 1
                            Exit For
                        End If
                    End If
                Next llngCnt
                
                '@★ 分割元用判定ﾌﾗｸﾞにより処理分岐 ★
                Select Case llngMapJudgeFlag
                
                    '@〓 "1:№05-01にWFあり" 〓
                    Case 1
                        '@分割/移載ﾌﾗｸﾞを"1:移載"に設定
                        mlngFormationFlag = CMlngTransfer
                    
                    '@〓 "2:№10-06にWFあり"or"3:№10-06&05-01にWFあり" 〓
                    Case 2, 3
                        '@分割/移載ﾌﾗｸﾞに"2:移載＆分割"に設定
                        mlngFormationFlag = CMlngPartition

                End Select
            End With

            '@=======================
            '@　一括分割処理
            '@=======================
            Call prvLumpDivide_Proc(llngMapJudgeFlag, _
                                    CMstrCmdLumpDivideWF1Click)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLumpDivideWF1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/04/14 (Mon) 14:33:19 N.Kojima **************************************************

    '@↓2008/04/14 (Mon) 14:32:48 N.Kojima **************************************************
    '関数名：cmdLumpDivideWF2_Click
    '機　能：一括分割#11-20ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/04/09 (Wed) 10:06:41 N.Kojima
    '更新日：2008/04/09 (Wed) 10:06:41
    '備　考：
    Private Sub cmdLumpDivideWF2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLumpDivideWF2.Click

        Dim llngCnt             As Integer      'ｶｳﾝﾀ
        Dim llngMapJudgeFlag    As Integer      '分割元用判定ﾌﾗｸﾞ(1:№15-11にWFあり、2:№20-16にWFあり、3:№20-16&15-11にWFあり)

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfSlotMap
            
                '@分割元ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄ№20-16分ﾙｰﾌﾟ
                For llngCnt = 6 To 10
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟにて、ｽﾛｯﾄ№20-16にWFIDが存在するか
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        '@分割元用判定ﾌﾗｸﾞに"2:№20-16にWFあり"をｾｯﾄ
                        llngMapJudgeFlag = 2
                        Exit For
                    End If
                Next llngCnt
                
                '@分割元ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄ№15-11分ﾙｰﾌﾟ
                For llngCnt = 11 To 15
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟにて、ｽﾛｯﾄ№15-11にWFIDが存在するか
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        '@分割元用判定ﾌﾗｸﾞが"2:№20-16にWFあり"か
                        If llngMapJudgeFlag = 2 Then
                            '@分割元用判定ﾌﾗｸﾞに"3:№20-16&15-11にWFあり"をｾｯﾄ
                            llngMapJudgeFlag = 3
                            Exit For
                        Else
                            '@分割元用判定ﾌﾗｸﾞに"1:№15-11にWFあり"をｾｯﾄ
                            llngMapJudgeFlag = 1
                        End If
                    End If
                Next llngCnt
                
                '@★ 分割元用判定ﾌﾗｸﾞにより処理分岐 ★
                Select Case llngMapJudgeFlag
                
                    '@〓 "1:№15-11にWFあり" 〓
                    Case 1
                        '@分割/移載ﾌﾗｸﾞを"1:移載"に設定
                        mlngFormationFlag = CMlngTransfer
                    
                    '@〓 "2:№20-16にWFあり"or"3:№20-16&15-11にWFあり" 〓
                    Case 2, 3
                        '@分割/移載ﾌﾗｸﾞに"2:移載＆分割"に設定
                        mlngFormationFlag = CMlngPartition

                End Select
            End With
            
            '@=======================
            '@　一括分割処理
            '@=======================
            Call prvLumpDivide_Proc(llngMapJudgeFlag, _
                                    CMstrCmdLumpDivideWF2Click)
          
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLumpDivideWF2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/04/14 (Mon) 14:32:48 N.Kojima **************************************************

    '関数名：cmdManual_Click
    '機　能：編成用手動分割ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/04 (Mon) 13:48:25 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:07:04 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:07:04 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub cmdManual_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdManual.Click
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@　分割予約ｽﾛｯﾄﾏｯﾌﾟ WF移載ﾌｫｰﾏｯﾄ表示処理
            '@=======================
            Call prvVsfSlotMapFormat_Set(vsfSlotMap1)       '分割予約1
            Call prvVsfSlotMapFormat_Set(vsfSlotMap2)       '分割予約2
            
            '@---------------------
            '@　各種ﾎﾞﾀﾝ制御
            '@---------------------
            '@有効化
            cmdUP1.Enabled = True               '分割予約1 上ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdUP2.Enabled = True               '分割予約2 上ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdClear.Enabled = True             '取消ﾎﾞﾀﾝ
            '@無効化
            cmdDown1.Enabled = False            '分割予約1 下ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdDown2.Enabled = False            '分割予約2 下ｽｸﾛｰﾙﾎﾞﾀﾝ
        '    cmdLump.Enabled = False             '編成用一括分割ﾎﾞﾀﾝ
            cmdLumpDivideWF1.Enabled = False    '一括分割#01－10ﾎﾞﾀﾝ
            cmdLumpDivideWF2.Enabled = False    '一括分割#11－20ﾎﾞﾀﾝ
            cmdManual.Enabled = False           '編成用手動分割ﾎﾞﾀﾝ
            
            '@分割/移載ﾌﾗｸﾞ設定(=3：手動)
            mlngFormationFlag = CMlngManual
            
            '@=======================
            '@　WF枚数をｶｳﾝﾄし、ﾗﾍﾞﾙに表示する処理
            '@=======================
            Call prvVsfSlotMap_Cal()
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdRegistControl_Proc()
          
            '@分割元ｽﾛｯﾄﾏｯﾌﾟを有効にする
            vsfSlotMap.Enabled = True
            
            '@ﾌｫｰｶｽｾｯﾄ＆行選択処理
            Call pubSetFocus(vsfSlotMap)
            vsfSlotMap.Select(-1, 1)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdManual_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtToCarrierID1_Change
    '機　能：分割予約1ｷｬﾘｱ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/08 (Fri) 15:26:23 N.Kasai
    '更新日：2008/04/09 (Wed) 10:36:31 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:36:31 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub txtToCarrierID1_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtToCarrierID1.Change

        Try

            '@移載構造体の初期化
            With mtypTransfer
                .lngSlotNo = 0
                .strClassID = vbNullString
                .strStatus = vbNullString
                .strWfId = vbNullString
            End With
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdRegistControl_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtToCarrierID1_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtToCarrierID1_Validate
    '機　能：分割予約1ｷｬﾘｱ　Valiadte処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/24 (Fri) 22:38:15 N.Kasai
    '更新日：2008/04/09 (Wed) 10:37:48 N.Kojima
    '備　考：
    '　　　：2004/10/08 (Fri) 15:25:30 N.Kasai      ｷｬﾘｱﾀｲﾌﾟﾁｪｯｸ追加
    '　　　：2008/04/09 (Wed) 10:37:48 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub txtToCarrierID1_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtToCarrierID1.Validating

        Dim ltypCarrCurstate    As CarrCurstate     'ｷｬﾘｱ状態確認構造体
        Dim lblnAns             As Boolean          '戻り値
        Dim lstrSlotSize        As String           'ｽﾛｯﾄｻｲｽﾞ格納

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@以下の場合は空きｷｬﾘｱ選択ﾎﾞﾀﾝにﾌｫｰｶｽをｾｯﾄし、処理抜け
            '@　①空白の場合
            '@　②前回入力ｷｬﾘｱIDと同じ
            If txtToCarrierID1.Text = vbNullString Or mstrToCarrierID1 = txtToCarrierID1.Text Then
                
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrierID1.Name Then
                    Call pubSetFocus(cmdCarrierSelect1)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtToCarrierID1.NowByte < txtToCarrierID1.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽは保持
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrTxtToCarrierID1Validate)

            '@ｷｬﾘｱ情報(要求)格納
            With ltypCarrCurstate
                .strCarrierId = txtToCarrierID1.Text        'ｷｬﾘｱID
                .strClassDivision = CPstrCD2D               '空ｷｬﾘｱﾁｪｯｸ
                .strMsgVer = CMstrcarrcurstateVer           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸID
                .strCarrierTypeID = CPstrCarrTypeFOUP       'ｷｬﾘｱﾀｲﾌﾟ(FOUP限定)
                .strLotID = vbNullString                    'ﾛｯﾄID
            End With

            '@【ｷｬﾘｱ状態確認】】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, _
                                             True, _
                                             lstrSlotSize)

            '@通信結果確認
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@ｷｬﾘｱIDの退避
                mstrToCarrierID1 = txtToCarrierID1.Text
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrTxtToCarrierID1Validate)
            
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrierID1.Name Then
                    Call pubSetFocus(cmdCarrierSelect1)
                End If
            Else
                '@結果：異常の場合
                
                '@ｷｬﾘｱIDの退避ｸﾘｱ
                mstrToCarrierID1 = vbNullString
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrTxtToCarrierID1Validate)
                
                '@ﾌｫｰｶｽは保持
                e.Cancel = True
                Exit Sub
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtToCarrierID1_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierSelect1_Click
    '機　能：空きｷｬﾘｱ選択ﾎﾞﾀﾝ(分割予約1)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/24 (Fri) 18:20:44 N.Kasai
    '更新日：2008/04/09 (Wed) 10:17:46 N.Kojima
    '備　考：
    '　　　：2005/10/06 (Thu) 16:34:39 S.Deguchi    ｷｬﾘｱの洗浄条件設定処理を追加
    '　　　：2008/04/09 (Wed) 10:17:46 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub cmdCarrierSelect1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect1.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　空きｷｬﾘｱ選択画面起動処理
            '@=======================
            Call prvLoadCarrierSelect_Proc(cmdCarrierSelect1)
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierSelect1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap1_Click
    '機　能：分割予約1ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/06 (Wed) 09:27:06 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub vsfSlotMap1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap1.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap1.Rows.Count <= vsfSlotMap1.Rows.Fixed Then
                Return
            End If

            '@選択処理
            With vsfSlotMap1
                
                '@ﾀｲﾄﾙ以外
                If .Row > 0 Then
                    
                    '@背景色が白の場合
                    If .GetCellRange(.Row, CMlngvsfSlotMapColWFID).StyleDisplay.BackColor = SystemColors.Window Then
                        
                        '@空欄の場合
                        If .GetData(.Row, CMlngvsfSlotMapColWFID) = vbNullString Then
                            
                            '@=======================
                            '@　ｸﾞﾘｯﾄﾞ反映処理
                            '@=======================
                            Call prvVsfSlotMapCell_Proc(vsfSlotMap1, .Row)
                        Else
                            '@退避構造体へ情報をｾｯﾄ
                            mtypTransfer.strWfId = .GetData(.Row, CMlngvsfSlotMapColWFID)                  'WF_ID
                            mtypTransfer.strStatus = .GetData(.Row, CMlngvsfSlotMapColStatus)              '状況
                            mtypTransfer.strClassID = .GetData(.Row, CMlngvsfSlotMapColClassID)            'Class_ID
                            mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfSlotMapColBNo)                 '移載元№
                            '@↓2019/10/01 (Tue) 11:43:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            mtypTransfer.strGRB = .GetData(.Row, CMlngvsfSlotMapColGRB)                    'GRB
                            '@↑2019/10/01 (Tue) 11:43:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        End If
                    End If
                End If
            End With
            
            '@=======================
            '@　WF枚数をｶｳﾝﾄし、ﾗﾍﾞﾙに表示する処理
            '@=======================
            Call prvVsfSlotMap_Cal()
            
            '@=======================
            '@　ﾃｷｽﾄﾎﾞｯｸｽ活性化処理
            '@=======================
            Call prvCarrierControl_Proc(vsfSlotMap1, txtToCarrierID1, cmdCarrierSelect1)    '分割予約1
            Call prvCarrierControl_Proc(vsfSlotMap2, txtToCarrierID2, cmdCarrierSelect2)    '分割予約2
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdRegistControl_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap1_GotFocus
    '機　能：分割予約1ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　GotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/06 (Wed) 13:14:35 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub vsfSlotMap1_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap1.Enter

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap1.Rows.Count <= vsfSlotMap1.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー選択時処理を抜ける
            If vsfSlotMap1.Row < vsfSlotMap1.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽがあたった段階で,退避構造体がNullの場合には,
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfSlotMap1
                
                '@退避構造体がNullの場合
                If mtypTransfer.strWfId = vbNullString Then
                    
                    '@選択行が空欄でない場合
                    If .GetData(.Row, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        '@退避構造体へ情報をｾｯﾄ
                        mtypTransfer.strWfId = .GetData(.Row, CMlngvsfSlotMapColWFID)                  'WF_ID
                        mtypTransfer.strStatus = .GetData(.Row, CMlngvsfSlotMapColStatus)              '状況
                        mtypTransfer.strClassID = .GetData(.Row, CMlngvsfSlotMapColClassID)            'Class_ID
                        mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfSlotMapColBNo)                 '移載元№
                        '@↓2019/10/01 (Tue) 11:44:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        mtypTransfer.strGRB = .GetData(.Row, CMlngvsfSlotMapColGRB)                    'GRB
                        '@↑2019/10/01 (Tue) 11:44:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap1_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap1_LostFocus
    '機　能：分割予約1ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　LostFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/06 (Wed) 13:36:17 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub vsfSlotMap1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap1.Leave

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap1.Rows.Count <= vsfSlotMap1.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー選択時処理を抜ける
            If vsfSlotMap1.Row < vsfSlotMap1.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽが抜ける段階で,退避構造体と選択ｾﾙの内容が異なる場合,
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfSlotMap1
                
                '@選択行が空欄でない場合
                If .GetData(.Row, CMlngvsfSlotMapColWFID) <> vbNullString Then
                    
                    '@退避構造体と選択行の内容が異なる場合
                    If mtypTransfer.strWfId <> .GetData(.Row, CMlngvsfSlotMapColWFID) Then
                        
                        '@退避構造体へ情報をｾｯﾄ
                        mtypTransfer.strWfId = .GetData(.Row, CMlngvsfSlotMapColWFID)                  'WF_ID
                        mtypTransfer.strStatus = .GetData(.Row, CMlngvsfSlotMapColStatus)              '状況
                        mtypTransfer.strClassID = .GetData(.Row, CMlngvsfSlotMapColClassID)            'Class_ID
                        mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfSlotMapColBNo)                 '移載元№
                        '@↓2019/10/01 (Tue) 11:44:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        mtypTransfer.strGRB = .GetData(.Row, CMlngvsfSlotMapColGRB)                    'GRB
                        '@↑2019/10/01 (Tue) 11:44:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    End If
                Else
                    '@退避構造体の情報をｸﾘｱ
                    mtypTransfer.strWfId = vbNullString                                                         'WF_ID
                    mtypTransfer.strStatus = vbNullString                                                       '状況
                    mtypTransfer.strClassID = vbNullString                                                      'Class_ID
                    mtypTransfer.lngSlotNo = 0                                                                  '移載元№
                    '@↓2019/10/01 (Tue) 11:44:58 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    mtypTransfer.strGRB = vbNullString                                                          'GRB
                    '@↑2019/10/01 (Tue) 11:44:58 Y.Yoneyama 「.Netへ反映未」 **************************************************
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap1_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUP1_Click
    '機　能：上ｽｸﾛｰﾙ(▲)ﾎﾞﾀﾝ(分割予約1ｽﾛｯﾄﾏｯﾌﾟ)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/04 (Mon) 12:02:37 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub cmdUP1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUP1.Click
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　上ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubVsfCmdUp(vsfSlotMap1, cmdUP1, cmdDown1)

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
    '機　能：下ｽｸﾛｰﾙ(▼)ﾎﾞﾀﾝ(分割予約1ｽﾛｯﾄﾏｯﾌﾟ)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/04 (Mon) 12:02:35 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub cmdDown1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown1.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@　下ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubVsfCmdDown(vsfSlotMap1, cmdUP1, cmdDown1, False)

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

    '関数名：txtToCarrierID2_Change
    '機　能：分割予約2ｷｬﾘｱ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/26 (Sun) 18:52:44 N.Kasai
    '更新日：2008/04/09 (Wed) 10:41:46 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:41:46 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub txtToCarrierID2_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtToCarrierID2.Change

        Try
            
            '@移載構造体の初期化
            With mtypTransfer
                .lngSlotNo = 0
                .strClassID = vbNullString
                .strStatus = vbNullString
                .strWfId = vbNullString
            End With
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdRegistControl_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtToCarrierID2_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtToCarrierID2_Validate
    '機　能：分割予約2ｷｬﾘｱ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/24 (Fri) 22:39:00 N.Kasai
    '更新日：2008/04/09 (Wed) 10:43:02 N.Kojima
    '備　考：
    '　　　：2004/10/08 (Fri) 15:25:01 N.Kasai      ｷｬﾘｱﾀｲﾌﾟﾁｪｯｸ追加
    '　　　：2008/04/09 (Wed) 10:43:02 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub txtToCarrierID2_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtToCarrierID2.Validating
        
        Dim ltypCarrCurstate    As CarrCurstate     'ｷｬﾘｱ状態確認構造体
        Dim lblnAns             As Boolean          '戻り値
        Dim lstrSlotSize        As String           'ｽﾛｯﾄｻｲｽﾞ格納

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@以下の場合は空きｷｬﾘｱ選択ﾎﾞﾀﾝにﾌｫｰｶｽをｾｯﾄし、処理抜け
            '@　①空白の場合
            '@　②前回入力ｷｬﾘｱIDと同じ
            If txtToCarrierID2.Text = vbNullString Or mstrToCarrierID2 = txtToCarrierID2.Text Then
            
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrierID2.Name Then
                    Call pubSetFocus(cmdCarrierSelect2)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtToCarrierID2.NowByte < txtToCarrierID2.ChrMaxByte Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽは保持
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrTxtToCarrierID2Validate)

            '@ｷｬﾘｱ情報(要求)格納
            With ltypCarrCurstate
                .strCarrierId = txtToCarrierID2.Text        'ｷｬﾘｱID
                .strClassDivision = CPstrCD2D               '空ｷｬﾘｱﾁｪｯｸ
                .strMsgVer = CMstrcarrcurstateVer           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸID
                .strCarrierTypeID = CPstrCarrTypeFOUP       'ｷｬﾘｱﾀｲﾌﾟ(FOUP限定)
                .strLotID = vbNullString                    'ﾛｯﾄID
            End With

            '@【ｷｬﾘｱ状態確認】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, _
                                             True, _
                                             lstrSlotSize)
            
            '@通信結果確認
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@ｷｬﾘｱIDの退避
                mstrToCarrierID2 = txtToCarrierID2.Text
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrTxtToCarrierID2Validate)
                
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrierID2.Name Then
                    Call pubSetFocus(cmdCarrierSelect2)
                End If
            Else
                '@結果：異常の場合
            
                '@ｷｬﾘｱIDの退避のｸﾘｱ
                mstrToCarrierID2 = vbNullString
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrTxtToCarrierID2Validate)
                
                '@ﾌｫｰｶｽは保持
                e.Cancel = True
                Exit Sub
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtToCarrierID2_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierSelect2_Click
    '機　能：空きｷｬﾘｱ選択ﾎﾞﾀﾝ(分割予約2)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/24 (Fri) 18:20:44 N.Kasai
    '更新日：2008/04/09 (Wed) 10:27:08 N.Kojima
    '備　考：
    '　　　：2005/10/06 (Thu) 16:34:39 S.Deguchi    ｷｬﾘｱの洗浄条件設定処理を追加
    '　　　：2008/04/09 (Wed) 10:27:08 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub cmdCarrierSelect2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@　空きｷｬﾘｱ選択画面起動処理
            '@=======================
            Call prvLoadCarrierSelect_Proc(cmdCarrierSelect2)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierSelect2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap2_Click
    '機　能：分割予約2ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/06 (Wed) 09:27:33 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub vsfSlotMap2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap2.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap2.Rows.Count <= vsfSlotMap2.Rows.Fixed Then
                Return
            End If

            With vsfSlotMap2
                
                '@ﾀｲﾄﾙ以外か
                If .Row > 0 Then
                    
                    '@選択行のWFID列の背景色が白か
                    If .GetCellRange(.Row, CMlngvsfSlotMapColWFID).StyleDisplay.BackColor = SystemColors.Window Then
                        
                        '@選択行のWFIDがNULLか
                        If .GetData(.Row, CMlngvsfSlotMapColWFID) = vbNullString Then
                            
                            '@=======================
                            '@　ｸﾞﾘｯﾄﾞ反映処理
                            '@=======================
                            Call prvVsfSlotMapCell_Proc(vsfSlotMap2, .Row)
                        Else
                            '@選択行のWFIDがNULL以外か
                        
                            '@退避構造体へ情報をｾｯﾄ
                            mtypTransfer.strWfId = .GetData(.Row, CMlngvsfSlotMapColWFID)          'WFID
                            mtypTransfer.strStatus = .GetData(.Row, CMlngvsfSlotMapColStatus)      '状況
                            mtypTransfer.strClassID = .GetData(.Row, CMlngvsfSlotMapColClassID)    'ClassID
                            mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfSlotMapColBNo)         '移載元№
                            '@↓2019/10/01 (Tue) 12:52:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            mtypTransfer.strGRB = .GetData(.Row, CMlngvsfSlotMapColGRB)            'GRB
                            '@↑2019/10/01 (Tue) 12:52:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        End If
                    End If
                End If
            End With
            
            '@=======================
            '@　WF枚数をｶｳﾝﾄし、ﾗﾍﾞﾙに表示する処理
            '@=======================
            Call prvVsfSlotMap_Cal()
            
            '@=======================
            '@　ﾃｷｽﾄﾎﾞｯｸｽ、ｷｬﾘｱ選択ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCarrierControl_Proc(vsfSlotMap1, txtToCarrierID1, cmdCarrierSelect1)    '分割予約1
            Call prvCarrierControl_Proc(vsfSlotMap2, txtToCarrierID2, cmdCarrierSelect2)    '分割予約2
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdRegistControl_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap2_GotFocus
    '機　能：分割予約2ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　GotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/06 (Wed) 13:14:35 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub vsfSlotMap2_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap2.Enter

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap2.Rows.Count <= vsfSlotMap2.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー選択時処理を抜ける
            If vsfSlotMap2.Row < vsfSlotMap2.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽがあたった段階で退避構造体がNullの場合には、
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfSlotMap2
                
                '@退避構造体のWFIDがNULLか
                If mtypTransfer.strWfId = vbNullString Then
                    
                    '@選択行のWFIDがNULL以外か
                    If .GetData(.Row, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        
                        '@退避構造体へ情報をｾｯﾄ
                        mtypTransfer.strWfId = .GetData(.Row, CMlngvsfSlotMapColWFID)              'WFID
                        mtypTransfer.strStatus = .GetData(.Row, CMlngvsfSlotMapColStatus)          '状況
                        mtypTransfer.strClassID = .GetData(.Row, CMlngvsfSlotMapColClassID)        'ClassID
                        mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfSlotMapColBNo)             '移載元№
                        '@↓2019/10/01 (Tue) 12:53:38 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        mtypTransfer.strGRB = .GetData(.Row, CMlngvsfSlotMapColGRB)                'GRB
                        '@↑2019/10/01 (Tue) 12:53:38 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap2_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap2_LostFocus
    '機　能：分割予約2ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　LostFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/06 (Wed) 13:36:17 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub vsfSlotMap2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap2.Leave

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap2.Rows.Count <= vsfSlotMap2.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー選択時処理を抜ける
            If vsfSlotMap2.Row < vsfSlotMap2.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽが抜ける段階で退避構造体と選択ｾﾙの内容が異なる場合、
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfSlotMap2
                
                '@選択行のWFIDがNULLか
                If .GetData(.Row, CMlngvsfSlotMapColWFID) <> vbNullString Then
                    
                    '@退避構造体のWFIDと選択行のWFIDが異なるか
                    If mtypTransfer.strWfId <> .GetData(.Row, CMlngvsfSlotMapColWFID) Then
                    
                        '@退避構造体へ情報をｾｯﾄ
                        mtypTransfer.strWfId = .GetData(.Row, CMlngvsfSlotMapColWFID)          'WFID
                        mtypTransfer.strStatus = .GetData(.Row, CMlngvsfSlotMapColStatus)      '状況
                        mtypTransfer.strClassID = .GetData(.Row, CMlngvsfSlotMapColClassID)    'ClassID
                        mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfSlotMapColBNo)         '移載元№
                        '@↓2019/10/01 (Tue) 12:54:06 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        mtypTransfer.strGRB = .GetData(.Row, CMlngvsfSlotMapColGRB)            'GRB
                        '@↑2019/10/01 (Tue) 12:54:06 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    End If
                Else
                    '@選択行のWFIDがNULL以外の場合
                
                    '@退避構造体の情報をｸﾘｱ
                    mtypTransfer.strWfId = vbNullString         'WFID
                    mtypTransfer.strStatus = vbNullString       '状況
                    mtypTransfer.strClassID = vbNullString      'ClassID
                    mtypTransfer.lngSlotNo = 0                  '移載元№
                    '@↓2019/10/01 (Tue) 12:54:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    mtypTransfer.strGRB = vbNullString          'GRB
                    '@↑2019/10/01 (Tue) 12:54:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap2_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUP2_Click
    '機　能：上ｽｸﾛｰﾙ(▲)ﾎﾞﾀﾝ(分割予約2ｽﾛｯﾄﾏｯﾌﾟ)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/04 (Mon) 12:02:37 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub cmdUp2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp2.Click
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　上ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubVsfCmdUp(vsfSlotMap2, cmdUP2, cmdDown2)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUP2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown2_Click
    '機　能：下ｽｸﾛｰﾙ(▼)ﾎﾞﾀﾝ(分割予約2ｽﾛｯﾄﾏｯﾌﾟ)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/04 (Mon) 12:02:35 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub cmdDown2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown2.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@　下ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubVsfCmdDown(vsfSlotMap2, cmdUP2, cmdDown2, False)

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

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 12:12:27 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:30:25 N.Kojima
    '備　考：
    '　　　：2004/09/03 (Fri) 15:32:25 N.Kasai　    最終更新日時(在庫)
    '　　　：2004/10/21 (Thu) 11:06:56 N.Kojima     空ﾀｸﾞ挿入処理削除に伴う、ﾘｽﾄ0件ﾁｪｯｸ追加
    '　　　：2004/10/27 (Wed) 15:32:10 K.Takano     WFﾘｽﾄ0件ﾁｪｯｸで分割予約2側を削除
    '　　　：2008/04/09 (Wed) 10:30:25 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lstrLotDivideLotID1     As String               '分割1ﾛｯﾄID
        Dim lstrLotDivideLotID2     As String               '分割2ﾛｯﾄID
        Dim lblnAns                 As Boolean              '結果格納
        Dim lblnDivideFlag1         As Boolean              '分割1存在ﾌﾗｸﾞ(True:あり、False:なし)
        Dim lblnDivideFlag2         As Boolean              '分割2存在ﾌﾗｸﾞ(True:あり、False:なし)

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
            
            '@=======================
            '@　確定ﾎﾞﾀﾝﾁｪｯｸ
            '@=======================
            lblnAns = prvblnInput_Chk
            
            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@↓2019/10/02 (Wed) 10:16:35 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@=======================
            '@ GRBのWF混在ﾁｪｯｸ
            '@=======================
            lblnAns = prvblnGRBWafer_Chk
    
            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
            '@↑2019/10/02 (Wed) 10:16:35 Y.Yoneyama 「.Netへ反映未」 **************************************************

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
            
            '@=======================
            '@　確定情報設定処理
            '@=======================
            Call prvRegistDataSet_Proc(lblnDivideFlag1, lblnDivideFlag2)

            '@【組立在庫分割予約】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnLotAsmdivide_Ins(CMstrlot_asmdivideVer, _
                                             mtyplotasmdivide, _
                                             lstrLotDivideLotID1, _
                                             lstrLotDivideLotID2)

            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合

                '@**************************************
                '@　①分割予約1ｽﾛｯﾄﾏｯﾌﾟ：WF存在
                '@　②分割予約2ｽﾛｯﾄﾏｯﾌﾟ：WF存在　か
                '@**************************************
                If lblnDivideFlag1 = True And lblnDivideFlag2 = True Then
                    
        '            '@登録時に採番された分割先1のﾛｯﾄIDを表示する
        '            lblLotID1.Caption = lstrLotDivideLotID1
        '            '@分割先1の流動区分は親ﾛｯﾄの流動区分を引継ぐ
        '            lblFlowClass1.Caption = lblFlowClass.Caption
        '
        '            '@登録時に採番された分割先2のﾛｯﾄIDを表示する
        '            lblLotID2.Caption = lstrLotDivideLotID2
        '            '@分割先2の流動区分は親ﾛｯﾄの流動区分を引継ぐ
        '            lblFlowClass2.Caption = lblFlowClass.Caption
            
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM0WI>$$組立在庫分割予約しました。キャリア[%1] 分割先キャリア１[%2] 分割ロット１[%3]"
                    '@"分割先キャリア２[%4] 分割ロット２[%5]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002I, _
                                                    lblCarrier.Text, _
                                                    txtToCarrierID1.Text, lstrLotDivideLotID1, _
                                                    txtToCarrierID2.Text, lstrLotDivideLotID2)
                End If
                
                '@**************************************
                '@　①分割予約1ｽﾛｯﾄﾏｯﾌﾟ：WF存在
                '@　②分割予約2ｽﾛｯﾄﾏｯﾌﾟ：WF存在しない　か
                '@**************************************
                If lblnDivideFlag1 = True And lblnDivideFlag2 = False Then
                    
        '            '@登録時に採番された分割先1のﾛｯﾄIDを表示する
        '            lblLotID1.Caption = lstrLotDivideLotID1
        '            '@分割先1の流動区分は親ﾛｯﾄの流動区分を引継ぐ
        '            lblFlowClass1.Caption = lblFlowClass.Caption
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM0WI>$$組立在庫分割予約しました。キャリア[%1] 分割先キャリア[%2]　分割ロット[%3]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000W, _
                                                    lblCarrier.Text, _
                                                    txtToCarrierID1.Text, lstrLotDivideLotID1)
                End If
                
                '@**************************************
                '@　①分割予約1ｽﾛｯﾄﾏｯﾌﾟ：WF存在しない
                '@　②分割予約2ｽﾛｯﾄﾏｯﾌﾟ：WF存在　か
                '@**************************************
                If lblnDivideFlag1 = False And lblnDivideFlag2 = True Then
                    
        '            '@登録時に採番された分割先2のﾛｯﾄIDを表示する
        '            lblLotID2.Caption = lstrLotDivideLotID1
        '            '@分割先2の流動区分は親ﾛｯﾄの流動区分を引継ぐ
        '            lblFlowClass2.Caption = lblFlowClass.Caption
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM0WI>$$組立在庫分割予約しました。キャリア[%1] 分割先キャリア[%2]　分割ロット[%3]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000W, _
                                                    lblCarrier.Text, _
                                                    txtToCarrierID2.Text, lstrLotDivideLotID1)
                End If
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@各種ﾎﾞﾀﾝの無効化
                cmdClear.Enabled = False        '取消ﾎﾞﾀﾝ
                cmdRegist.Enabled = False       '確定ﾎﾞﾀﾝ
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                
                '@"ﾒｯｾｰｼﾞ変換<TRM2XI>$$在庫移載を行って下さい。キャリア[%1] ロット[%2]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002X, lblCarrier.Text, lblLotID.Text)
                '@ﾒｯｾｰｼﾞ表示
                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                
                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                Me.Close()
            Else
                '@結果：異常の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
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

    '関数名：cmdClear_Click
    '機　能：取消ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 18:27:15 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:12:03 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:12:03 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Dim llngCnt         As Integer          '汎用ｶｳﾝﾀ
        Dim llngTopRow      As Integer          '先頭行格納
        Dim llngRow         As Integer          'ｽﾛｯﾄﾏｯﾌﾟ№

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ｽﾛｯﾄﾏｯﾌﾟの表示処理
            '@=======================
            Call prvVsfSlotMap_Disp()
            
            '@=======================
            '@　ｿｰﾄ前処理
            '@=======================
            Call pubVsfBeforeSort(vsfSlotMap, CMlngvsfSlotMapColWFID)


            '@分割元ｽﾛｯﾄﾏｯﾌﾟ
            With vsfSlotMap
            
                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@ｽﾛｯﾄ番号を行番号へ置換
                    llngRow = CMlngSlotMapRowS - llngCnt
                    
                    '@選択行のWFIDがNULL以外か
                    If .GetData(llngRow, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        
                        '@先頭行の設定
                        '@★ 選択行により処理分岐 ★
                        Select Case llngCnt
                        
                            '@〓 ｽﾛｯﾄ№25～16(行番号：1～10) 〓
                            Case 1 To 10
                            
                                '@先頭行をｽﾛｯﾄ№25(1行目)に設定
                                llngTopRow = CMlngRowNo16
                                Exit For
                                
                            '@〓 ｽﾛｯﾄ№15～06(行番号：11～20) 〓
                            Case 11 To 20
                            
                                '@先頭行をｽﾛｯﾄ№20(6行目)に設定
                                llngTopRow = CMlngRowNo6
                                Exit For
                            
                            '@〓 ｽﾛｯﾄ№05～01(行番号：21～25) 〓
                            Case 21 To 25
                            
                                '@先頭行をｽﾛｯﾄ№10(16行目)に設定
                                llngTopRow = CMlngRowNo1
                                Exit For
                        End Select
                    End If
                Next llngCnt
                
                '@先頭行設定
                .TopRow = llngTopRow
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御
                '@★ 先頭行により処理分岐 ★
                Select Case llngTopRow
                
                    '@〓 先頭行がｽﾛｯﾄ№10(16行目) 〓
                    Case CMlngSlotTopRow
                    
                        '@ｽｸﾛｰﾙﾎﾞﾀﾝの活性化制御
                        cmdUP.Enabled = True
                        cmdDown.Enabled = False
                    
                    '@〓 先頭行がｽﾛｯﾄ№20(6行目) 〓
                    Case CMlngSlotMap6
                    
                        '@ｽｸﾛｰﾙﾎﾞﾀﾝの活性化制御
                        cmdUP.Enabled = True
                        cmdDown.Enabled = True
                        
                    '@〓 先頭行がｽﾛｯﾄ№25(1行目) 〓
                    Case Else
                    
                        '@ｽｸﾛｰﾙﾎﾞﾀﾝの活性化制御
                        cmdUP.Enabled = False
                        cmdDown.Enabled = True
                End Select
            End With
            
            '@=======================
            '@　分割予約1ｽﾛｯﾄﾏｯﾌﾟの初期化
            '@=======================
            Call prvvsfSlotMap_init(vsfSlotMap1)
           
            '@分割予約1ｽﾛｯﾄﾏｯﾌﾟの上下ｽｸﾛｰﾙﾎﾞﾀﾝの無効化
            cmdUP1.Enabled = False
            cmdDown1.Enabled = False
           
            '@=======================
            '@　分割予約2ｽﾛｯﾄﾏｯﾌﾟの初期化
            '@=======================
            Call prvvsfSlotMap_init(vsfSlotMap2)

            '@分割予約2ｽﾛｯﾄﾏｯﾌﾟの上下ｽｸﾛｰﾙﾎﾞﾀﾝの無効化
            cmdUP2.Enabled = False
            cmdDown2.Enabled = False

        '    '@分割予約1のﾗﾍﾞﾙ初期化
        '    lblLotID1.Caption = vbNullString            'ﾛｯﾄID
        '    lblFlowClass1.Caption = vbNullString        '流動区分
        '    '@分割予約2のﾗﾍﾞﾙ初期化
        '    lblLotID2.Caption = vbNullString            'ﾛｯﾄID
        '    lblFlowClass2.Caption = vbNullString        '流動区分
            
            '@分割予約1、2ｷｬﾘｱIDの初期化
            txtToCarrierID1.Text = vbNullString         'NULL
            txtToCarrierID2.Text = vbNullString
            txtToCarrierID1.Enabled = False             '無効
            txtToCarrierID2.Enabled = False
            
            '@取消ﾎﾞﾀﾝ、空きｷｬﾘｱ選択の無効化
            cmdClear.Enabled = False
            cmdCarrierSelect1.Enabled = False           '分割予約1
            cmdCarrierSelect2.Enabled = False           '分割予約2
            
            '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ
            vsfSlotMap.Enabled = False                  '分割元ｽﾛｯﾄﾏｯﾌﾟ
            vsfSlotMap1.Enabled = False                 '分割予約1ｽﾛｯﾄﾏｯﾌﾟ
            vsfSlotMap2.Enabled = False                 '分割予約2ｽﾛｯﾄﾏｯﾌﾟ
            
            '@各種ﾎﾞﾀﾝを有効にする
            cmdManual.Enabled = True                    '編成用手動分割ﾎﾞﾀﾝ
        '    cmdLump.Enabled = True                      '編成用一括分割ﾎﾞﾀﾝ
            
            '@=======================
            '@　WF枚数をｶｳﾝﾄし、ﾗﾍﾞﾙに表示する処理
            '@=======================
            Call prvVsfSlotMap_Cal()
            
            '@手動移載構造体をｸﾘｱ
            With mtypTransfer
                .lngSlotNo = 0
                .strStatus = vbNullString
                .strClassID = vbNullString
                .strWfId = vbNullString
            End With
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdRegistControl_Proc()
            
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

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 17:30:34 S.Deguchi
    '更新日：2008/04/09 (Wed) 09:55:57 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 09:55:57 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            
            '@∇∇∇∇∇∇∇∇∇
            '@　ｱﾝﾛｰﾄﾞ処理
            '@∇∇∇∇∇∇∇∇∇
            Me.Close()

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

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：prvFrmxxEN00F3_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 17:29:32 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2004/10/19 (Tue) 12:11:03 M.Miura　    CausesValidation設定を追加
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub prvFrmxxEN00F3_Init()

        Dim ltypInvWaferList    As InvWaferList         '在庫WFﾘｽﾄ格納構造体初期化用
        Dim ltypTransfer        As SlotPosition         '手動移動時分割元情報格納用構造体初期化用
        Dim ltyplotasmdivide    As LotAsmdivide         '組立在庫分割構造体初期化用

        Try

            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　各種ﾌﾚｰﾑ内のｺﾝﾄﾛｰﾙ、ﾎﾞﾀﾝ等の初期化を行なう
            '@****************************************************************************

            '@変数初期化
            mstrLotLastUpdate = vbNullString                '最終更新日時
            mstrSlotSize = vbNullString                     'ｽﾛｯﾄｻｲｽﾞ退避
            mlngWFNum = 0                                   '元ｷｬﾘｱWF数
            mlngFormationFlag = 0                           '移載/分割ﾌﾗｸﾞ
            mstrToCarrierID1 = vbNullString                 '分割予約1ｷｬﾘｱID退避用
            mstrToCarrierID2 = vbNullString                 '分割予約2ｷｬﾘｱID退避用
            
            '@分割元ﾌﾚｰﾑの初期化
            lblCarrier.Text = vbNullString                  'ｷｬﾘｱIDﾗﾍﾞﾙ
            lblLotID.Text = vbNullString                    'ﾛｯﾄIDﾗﾍﾞﾙ
            lblFlowClass.Text = vbNullString                '流動区分ﾗﾍﾞﾙ
            Call prvvsfSlotMap_init(vsfSlotMap)             'ｽﾛｯﾄﾏｯﾌﾟ初期化
            cmdUP.Enabled = False                           '上ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdDown.Enabled = False                         '下ｽｸﾛｰﾙﾎﾞﾀﾝ
            
            '@分割予約1ﾌﾚｰﾑの初期化
            txtToCarrierID1.Enabled = False                 'ｷｬﾘｱIDﾃｷｽﾄ
            cmdCarrierSelect1.Enabled = False               '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
        '    lblLotID1.Caption = vbNullString                'ﾛｯﾄIDﾗﾍﾞﾙ
        '    lblFlowClass1.Caption = vbNullString            '流動区分ﾗﾍﾞﾙ
            Call prvvsfSlotMap_init(vsfSlotMap1)            'ｽﾛｯﾄﾏｯﾌﾟ初期化
            cmdUP1.Enabled = False                          '上ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdDown1.Enabled = False                        '下ｽｸﾛｰﾙﾎﾞﾀﾝ
            
            '@分割予約2ﾌﾚｰﾑの初期化
            txtToCarrierID2.Enabled = False                 'ｷｬﾘｱIDﾃｷｽﾄ
            cmdCarrierSelect2.Enabled = False               '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
        '    lblLotID2.Caption = vbNullString                'ﾛｯﾄIDﾗﾍﾞﾙ
        '    lblFlowClass2.Caption = vbNullString            '流動区分ﾗﾍﾞﾙ
            Call prvvsfSlotMap_init(vsfSlotMap2)            'ｽﾛｯﾄﾏｯﾌﾟ初期化
            cmdUP2.Enabled = False                          '上ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdDown2.Enabled = False                        '下ｽｸﾛｰﾙﾎﾞﾀﾝ
            
            '@各種ﾎﾞﾀﾝの初期化
            cmdClear.Enabled = False                        '全部取消
            cmdRegist.Enabled = False                       '確定
            cmdManual.Enabled = False                       '編成用手動分割
        '    cmdLump.Enabled = False                         '編成用一括分割
            cmdLumpDivideWF1.Enabled = False                '一括分割#01－10
            cmdLumpDivideWF2.Enabled = False                '一括分割#11－20
            
            '@各種ﾓｼﾞｭｰﾙ構造体初期化
            '移載/分割元WFID位置(#01-05)
            If mtypSlotPosition1 Is Nothing Then
                mtypSlotPosition1 = New List(Of SlotPosition)
            End If
            '移載/分割元WFID位置(#06-10)
            If mtypSlotPosition2 Is Nothing Then
                mtypSlotPosition2 = New List(Of SlotPosition)
            End If
            '移載/分割元WFID位置(#11-15)
            If mtypSlotPosition3 Is Nothing Then
                mtypSlotPosition3 = New List(Of SlotPosition)
            End If
            '移載/分割元WFID位置(#16-20)
            If mtypSlotPosition4 Is Nothing Then
                mtypSlotPosition4 = New List(Of SlotPosition)
            End If
            mtypInvWaferList = ltypInvWaferList             '在庫WFﾘｽﾄ格納構造体
            mlngSlotPosition1Cnt = 0                        '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#01-05)
            mlngSlotPosition2Cnt = 0                        '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#06-10)
            mlngSlotPosition3Cnt = 0                        '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#11-15)
            mlngSlotPosition4Cnt = 0                        '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報ｶｳﾝﾄ(#16-20)
            mtypTransfer = ltypTransfer                     '手動移動時元ｷｬﾘｱ情報格納
            mtyplotasmdivide = ltyplotasmdivide             '組立在庫分割構造体
            
            '@CausesValidation設定
            cmdClose.CausesValidation = False               '閉じるﾎﾞﾀﾝ
            cmdCarrierSelect1.CausesValidation = False      '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
            cmdCarrierSelect2.CausesValidation = False      '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN00F3_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvConnectInfo_Disp
    '機　能：引継ぎ情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 16:16:53 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2004/10/13 (Wed) 16:47:06 N.Kasai      ｽﾛｯﾄｻｲｽﾞ追加
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub prvConnectInfo_Disp()

        Try

            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　親画面(在庫管理⇒受入在庫Tab)からの引継ぎ情報を設定する
            '@****************************************************************************

            '@引継ぎ情報の表示
            With ptypHoldConnect
                lblCarrier.Text = .strCarrierId      'ｷｬﾘｱID
                lblLotID.Text = .strLotID            'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass    '流動区分
                mstrLotLastUpdate = .strLastUpdate      '最終更新日時
                mstrSlotSize = .strSlotSize             'ｽﾛｯﾄｻｲｽﾞ
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvConnectInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMap_Init
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの初期化
    '引　数：lctlcontrol:ｺﾝﾄﾛｰﾙ
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 15:23:29 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub prvvsfSlotMap_init(ByRef lctlControl As C1FlexGrid)

        Dim llngCnt        As Integer       'ｶｳﾝﾄ

        Try
            
            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　引数で渡されたｸﾞﾘｯﾄﾞの初期化処理を行なう
            '@****************************************************************************
            
            With lctlControl
                
                .Redraw = False

                .Clear(ClearFlags.Content)                      'ｸﾘｱ
                .ScrollBars = ScrollBars.None                   'ｽｸﾛｰﾙﾊﾞｰなし
                
                '@一覧表の表題設定
                .Rows.Count = CMlngSlotRow                                                                      '行数(26)

                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                '文字色
                headerStyle.BackColor = Color.Navy                  '背景色
                '@表示位置：固定列(中央寄せ中央揃え)
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                
                With .Font                                          'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    headerStyle.Font = New Font(.FontFamily, CMlngVsfHFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                '@↓2019/10/01 (Tue) 15:37:42 Y.Yoneyama 「.Netへ反映未」 **************************************************
                'Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfSlotMapColNo, CMlngVsfRowTitle, CMlngvsfSlotMapColClassID)
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfSlotMapColNo, CMlngVsfRowTitle, CMlngvsfSlotMapColGRB)
                '@↑2019/10/01 (Tue) 15:37:42 Y.Yoneyama 「.Netへ反映未」 **************************************************
                cellRange.Style = headerStyle

                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight                                                 'ﾍｯﾀﾞｰ高さ
                
                '@ﾊﾞｯｸｶﾗｰを白に変更
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                newStyle.BackColor = SystemColors.Window
                '@↓2019/10/01 (Tue) 15:38:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
                'Dim cellRange2 As CellRange = .GetCellRange(.Rows.Fixed, CMlngvsfSlotMapColWFID, CMlngCarrierRowS, CMlngvsfSlotMapColClassID)
                Dim cellRange2 As CellRange = .GetCellRange(.Rows.Fixed, CMlngvsfSlotMapColWFID, CMlngCarrierRowS, CMlngvsfSlotMapColGRB)
                '@↑2019/10/01 (Tue) 15:38:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
                cellRange2.Style = newStyle
                
                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfSlotMapColWFID).Width = CMlngvsfSlotMapWColWFID                                     'WFID
                .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColWFID, CMstrvsfSlotMapColWFID)
                
                .Cols(CMlngvsfSlotMapColClassID).Width = CMlngvsfSlotMapWColClassID                               'Class_ID
                .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColClassID, CMstrvsfSlotMapColClassID)
                
                .Cols(CMlngvsfSlotMapColStatus).Width = CMlngvsfSlotMapWColStatus                                 '状況
                .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColStatus, CMstrvsfSlotMapColStatus)
                
                .Cols(CMlngvsfSlotMapColBNo).Width = CMlngvsfSlotMapWColBNo                                       '通し番号
                .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColBNo, CMstrvsfSlotMapColBNo)

                '@↓2019/10/01 (Tue) 12:55:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfSlotMapColGRB).Width = CMlngvsfSlotMapWColGRB                                       'GRB
                .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColGRB, CMstrvsfSlotMapColGRB)
                '@↑2019/10/01 (Tue) 12:55:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                '@一覧表のSlot№設定
                For llngCnt = 1 To CMlngSlotRow - 1
                    .Col = CMlngvsfSlotMapColNo                                                                 '選択列
                    .Row = llngCnt                                                                              '選択行
                    With .Font                                                                                  'ﾌｫﾝﾄｻｲｽﾞ
                        lctlControl.Font = New Font(.FontFamily, CMlngVsfHFontSize, .Style, _
                                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                    End With
                    .Rows(llngCnt).Height = CMlngVsfHeight                                                      '行高さ
                    
                    '@ｽﾛｯﾄ№設定(ﾌｫｰﾏｯﾄ："00")
                    .SetData(llngCnt, CMlngvsfSlotMapColNo, _
                        CStr(Format$(CMlngSlotRow - llngCnt, CPstrSlotNoFormat)))
                Next llngCnt
                
                '@表示位置：ｽﾛｯﾄ№(右寄せ)
                .Cols(CMlngvsfSlotMapColNo).TextAlign = TextAlignEnum.RightCenter
                
                '@非表示設定
                .Cols(CMlngvsfSlotMapColClassID).Visible = False
                .Cols(CMlngvsfSlotMapColStatus).Visible = False
                .Cols(CMlngvsfSlotMapColBNo).Visible = False
                
                '@高さ設定
                .Height = CMlngvsfGridHeight
                
                '@初期表示行
                .TopRow = CMlngSlotTopRow

                '@選択指定
                .SelectionMode =SelectionModeEnum.Row
                .HighLight = HighLightEnum.WithFocus

                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMap_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMap_Disp
    '機　能：分割元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞのWF情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 16:40:14 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2004/10/12 (Tue) 09:05:57 N.Kasai      ｽﾛｯﾄｻｲｽﾞに応じたﾏｯﾌﾟ表示機能追加
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub prvVsfSlotMap_Disp()

        Dim llngCnt             As Integer      'ｶｳﾝﾄ(=1:固定)
        Dim llngLoopCnt         As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngWriteRow        As Integer      '書き込み行
        Dim lblnWF1JudgeFlag    As Boolean      '一括分割#01－10判定用ﾌﾗｸﾞ(True:判定抜け、False:判定継続)
        Dim lblnWF2JudgeFlag    As Boolean      '一括分割#11－20判定用ﾌﾗｸﾞ(True:判定抜け、False:判定継続)

        Try

            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　分割元ｽﾛｯﾄﾏｯﾌﾟの表示処理を行なう
            '@****************************************************************************
            
            '@判定用ﾌﾗｸﾞの初期化
            lblnWF1JudgeFlag = False
            lblnWF2JudgeFlag = False
            
            With vsfSlotMap
                
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@在庫WFﾘｽﾄの表示
                If mtypInvWaferList.lngInvWaferListCnt > 0 Then
                    
                    '@ﾙｰﾌﾟｶｳﾝﾄ格納
                    llngCnt = mtypInvWaferList.lngInvWaferListCnt
                    
                    '@ｽﾛｯﾄﾏｯﾌﾟの表示変更
                    '@ｽﾛｯﾄｻｲｽﾞが数値か
                    If IsNumeric(mstrSlotSize) = True Then
                        
                        '@ｽﾛｯﾄｻｲｽﾞ以上のｽﾛｯﾄ№を空白に、背景色を灰色(ﾎﾞﾀﾝの表面の色)に変更する
                        For llngCnt = 1 To CMlngSlotMapRowS - 1
                            
                            '@ｽﾛｯﾄｻｲｽﾞ以下のｽﾛｯﾄﾎﾟｼﾞｼｮﾝか
                            If llngCnt <= CMlngSlotMapRowS - CLng(mstrSlotSize) - 1 Then
                                '@ｽﾛｯﾄ№は空白
                                .SetData(llngCnt, CMlngvsfSlotMapColNo, vbNullString)
                                '@WFID列の背景色はｸﾞﾚｰにする
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbButtonFace")
                                newStyle.BackColor = SystemColors.ControlLight
                                '@↓2019/10/01 (Tue) 16:19:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                'Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColWFID)
                                Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColWFID, llngCnt, CMlngvsfSlotMapColGRB)
                                '@↑2019/10/01 (Tue) 16:19:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                cellRange.Style = newStyle
                            Else
                                '@WFID列の背景色はｸﾞﾚｰにする
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                                '@↓2019/10/01 (Tue) 16:18:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                'Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColWFID)
                                Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColWFID, llngCnt, CMlngvsfSlotMapColGRB)
                                '@↑2019/10/01 (Tue) 16:18:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                cellRange.Style = newStyle
                            End If
                        Next
                    End If
                    
                    '@WF情報の設定
                    For llngLoopCnt = 0 To mtypInvWaferList.lngInvWaferListCnt -1
                        
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝがNULL以外か
                        If mtypInvWaferList.typInvWaferList(llngLoopCnt).strSlotPosition <> vbNullString Then
                            
                            '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝの設定
                            llngWriteRow = CMlngSlotRow - _
                                           CLng(mtypInvWaferList.typInvWaferList(llngLoopCnt).strSlotPosition)

                            .SetData(llngWriteRow, CMlngvsfSlotMapColWFID, _
                                 mtypInvWaferList.typInvWaferList(llngLoopCnt).strWfId)                         'WFID
                                
                            .SetData(llngWriteRow, CMlngvsfSlotMapColClassID, _
                                 mtypInvWaferList.typInvWaferList(llngLoopCnt).strWFStatusID)                   'ClassID
                                
                            .SetData(llngWriteRow, CMlngvsfSlotMapColStatus, _
                                 mtypInvWaferList.typInvWaferList(llngLoopCnt).strWFStatus)                     '状態
                            
                            .SetData(llngWriteRow, CMlngvsfSlotMapColBNo, llngWriteRow)                         '行番号

                            '@↓2019/10/01 (Tue) 12:57:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngWriteRow, CMlngvsfSlotMapColGRB, _
                                mtypInvWaferList.typInvWaferList(llngLoopCnt).strGRBClass)                     'GRB
                            '@↑2019/10/01 (Tue) 12:57:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            
                            '@設定文字色は黒で表示する
                            '@WFIDﾊﾞｯｸｶﾗｰを白に変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite_ForeColor_vbBlack")
                            newStyle.BackColor = SystemColors.Window
                            newStyle.ForeColor = Color.Black
                            Dim cellRange As CellRange = .GetCellRange(llngWriteRow, CMlngvsfSlotMapColWFID)
                            cellRange.Style = newStyle      'WFID
                        
                            Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack")
                            newStyle2.ForeColor = Color.Black

                            Dim cellRange2 As CellRange = .GetCellRange(llngWriteRow, CMlngvsfSlotMapColClassID)
                            cellRange2.Style = newStyle2           'ClassID

                            Dim cellRange3 As CellRange = .GetCellRange(llngWriteRow, CMlngvsfSlotMapColStatus)
                            cellRange3.Style = newStyle2            '状況
                            
                            '@↓2019/10/01 (Tue) 12:58:44 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            '@GRB背景色
                            Dim newStyleGRB As CellStyle = .Styles.Add("GRBColor" + llngWriteRow.ToString)
                            newStyleGRB.ForeColor = Color.Black
                            newStyleGRB.BackColor = pubGRBBackColor(mtypInvWaferList.typInvWaferList(llngLoopCnt).strGRBClass, Color.White)
                            Dim cellRangeGRB As CellRange = .GetCellRange(llngWriteRow, CMlngvsfSlotMapColGRB)
                            cellRangeGRB.Style = newStyleGRB      
                            '@↑2019/10/01 (Tue) 12:58:44 Y.Yoneyama 「.Netへ反映未」 **************************************************

                            '@判定用ﾌﾗｸﾞが"False:判定継続"か
                            If lblnWF1JudgeFlag = False Or lblnWF2JudgeFlag = False Then
                            
                                '@★ WFのｽﾛｯﾄﾎﾟｼﾞｼｮﾝにより処理分岐 ★
                                Select Case mtypInvWaferList.typInvWaferList(llngLoopCnt).strSlotPosition
                                    
                                    '@〓 ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ01～10に表示するWFあり 〓
                                    Case CPstrZeroOne To CPstrTen
                                    
                                        '@一括分割#01-10ﾎﾞﾀﾝを有効にし、判定ﾌﾗｸﾞに"True:判定抜け"をｾｯﾄする
                                        cmdLumpDivideWF1.Enabled = True
                                        lblnWF1JudgeFlag = True
                                    
                                    '@〓 ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ11～20に表示するWFあり 〓
                                    Case CPstrEleven To CPstrTwentyTime
                                    
                                        '@一括分割#11-20ﾎﾞﾀﾝを有効にし、判定ﾌﾗｸﾞに"True:判定抜け"をｾｯﾄする
                                        cmdLumpDivideWF2.Enabled = True
                                        lblnWF2JudgeFlag = True
                                         
                                End Select
                            End If
                        End If
                    Next llngLoopCnt
                    
                    '@一括分割#01-10判定ﾌﾗｸﾞが"False"か
                    If lblnWF1JudgeFlag = False Then
                        
                        '@一括分割#01-10ﾎﾞﾀﾝを無効にする
                        cmdLumpDivideWF1.Enabled = False
                    End If
                    
                    '@一括分割#11-20判定ﾌﾗｸﾞが"False"か
                    If lblnWF2JudgeFlag = False Then
                        
                        '@一括分割#11-20ﾎﾞﾀﾝを無効にする
                        cmdLumpDivideWF2.Enabled = False
                    End If

                    '@ﾌｫﾝﾄｻｲｽﾞ設定
                    '@↓2019/10/01 (Tue) 15:39:25 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    '.Select(1, CMlngvsfSlotMapColNo, CMlngCarrierRowS, CMlngvsfSlotMapColClassID)                'ｸﾞﾘｯﾄﾞ
                    .Select(1, CMlngvsfSlotMapColNo, CMlngCarrierRowS, CMlngvsfSlotMapColGRB)                'ｸﾞﾘｯﾄﾞ
                    '@↑2019/10/01 (Tue) 15:39:25 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    With .Font
                        vsfSlotMap.Font = New Font(.FontFamily, CMlngvsfFontSize, .Style, _
                                                    .Unit, .GdiCharSet, .GdiVerticalFont)                        'ﾌｫﾝﾄｻｲｽﾞ
                    End With                                                     
            
                    '@左寄中央寄せ
                    .Cols(CMlngvsfSlotMapColWFID).TextAlign = TextAlignEnum.LeftCenter         'WFID
                    .Cols(CMlngvsfSlotMapColClassID).TextAlign = TextAlignEnum.LeftCenter      'ClassID
                    .Cols(CMlngvsfSlotMapColStatus).TextAlign = TextAlignEnum.LeftCenter       '状態
                    '@↓2019/10/01 (Tue) 15:40:05 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    .Cols(CMlngvsfSlotMapColGRB).TextAlign = TextAlignEnum.LeftCenter          'GRB
                    '@↑2019/10/01 (Tue) 15:40:05 Y.Yoneyama 「.Netへ反映未」 **************************************************
                End If
                
                '@描画する
                .Redraw = True
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMap_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvDivideVsfSlotMap_Set
    '機　能：分割予約1、2ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞの設定処理
    '引　数：ltypSlotPosition1()    ：移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報格納用配列(#01-05 or #11-15)
    '　　　：ltypSlotPosition2()    ：移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報格納用配列(#06-10 or #16-20)
    '　　　：lstrCallFunction       ：呼び元Function
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 17:56:29 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応とｿｰｽ整備。(案件№02539)
    Private Sub prvDivideVsfSlotMap_Set(ByRef ltypSlotPosition1 As List(Of SlotPosition), _
                                        ByRef ltypSlotPosition2 As List(Of SlotPosition), _
                                        ByVal lstrCallFunction As String)
        
        Dim llngLoopCnt             As Integer                   'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngFirstLoopEndCnt     As Integer                   '#01-05or#11-15用ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngLoopEndCnt          As Integer                   'ﾙｰﾌﾟｴﾝﾄﾞｶｳﾝﾄ
        Dim llngSelectJudgeCnt      As Integer                   '選択処理判定用ｶｳﾝﾀ
        Dim llngSelectArrayCnt      As Integer                   '配列選択用ｶｳﾝﾀ
        Dim lblnSkipFlag            As Boolean                   '処理ｽｷｯﾌﾟﾌﾗｸﾞ(True:ｽｷｯﾌﾟする、False:ｽｷｯﾌﾟしない)
        Dim lctlVsfControl          As C1FlexGrid                '処理対象ｸﾞﾘｯﾄﾞ
        Dim ltypSlotPosition        As List(Of SlotPosition)     '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報格納用配列

        Try
            
            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　分割予約1、2ｽﾛｯﾄﾏｯﾌﾟの表示処理を行なう
            '@****************************************************************************
            
            '@処理ｽｷｯﾌﾟﾌﾗｸﾞ、配列ｶｳﾝﾀの初期化
            lblnSkipFlag = False
            llngSelectJudgeCnt = 5
            
            '@呼び元Functionが"一括分割#01-10ﾎﾞﾀﾝClick処理"か
            If lstrCallFunction = CMstrCmdLumpDivideWF1Click Then
            
                '@各種処理用ｶｳﾝﾀを設定
                llngFirstLoopEndCnt = mlngSlotPosition1Cnt                      '#01-05判定用
                llngLoopEndCnt = mlngSlotPosition1Cnt + mlngSlotPosition2Cnt    '#01-10判定用
                llngSelectArrayCnt = mlngSlotPosition1Cnt                       '#01-05配列選択用ｶｳﾝﾀ
            Else
            
                '@各種処理用ｶｳﾝﾀを設定
                llngFirstLoopEndCnt = mlngSlotPosition3Cnt                      '#11-15判定用
                llngLoopEndCnt = mlngSlotPosition3Cnt + mlngSlotPosition4Cnt    '#11-20判定用
                llngSelectArrayCnt = mlngSlotPosition3Cnt                       '#11-15配列選択用ｶｳﾝﾀ
            End If
            
            '@#01-05 or #11-15用に配列をｺﾋﾟｰする
            ltypSlotPosition = ltypSlotPosition1
            
            '@処理対象ｸﾞﾘｯﾄﾞを"分割予約1"に設定
            lctlVsfControl = vsfSlotMap1
            
            '@分割予約1ｸﾞﾘｯﾄﾞの描画ﾛｯｸ
            lctlVsfControl.Redraw = False
                
            For llngLoopCnt = 1 To llngLoopEndCnt
                            
                '@ﾙｰﾌﾟｶｳﾝﾀが分割予約1WF数以上、かつ処理ｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟしない"か
                If llngLoopCnt > llngFirstLoopEndCnt And lblnSkipFlag = False Then
                
                    '@分割予約1ｸﾞﾘｯﾄﾞのﾌｫﾝﾄｻｲｽﾞ設定
                    '@↓2019/10/01 (Tue) 15:40:49 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    'lctlVsfControl.Select(1, CMlngvsfSlotMapColNo, CMlngCarrierRowS, CMlngvsfSlotMapColClassID)    'ｸﾞﾘｯﾄﾞ                
                    lctlVsfControl.Select(1, CMlngvsfSlotMapColNo, CMlngCarrierRowS, CMlngvsfSlotMapColGRB)    'ｸﾞﾘｯﾄﾞ  
                    '@↑2019/10/01 (Tue) 15:40:49 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    With lctlVsfControl.Font                                             'ﾌｫﾝﾄｻｲｽﾞ
                        lctlVsfControl.Font = New Font(.FontFamily, CMlngvsfFontSize, .Style, _
                                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                    End With

                    '@分割予約1ｸﾞﾘｯﾄﾞの描画ﾛｯｸ解除
                    lctlVsfControl.Redraw = True
                
                    '@処理対象ｸﾞﾘｯﾄﾞを"分割予約2"に設定
                    lctlVsfControl = vsfSlotMap2
                    
                    '@分割予約2ｸﾞﾘｯﾄﾞの描画ﾛｯｸ
                    lctlVsfControl.Redraw = False
                    
                    '@処理ｽｷｯﾌﾟﾌﾗｸﾞに"True:ｽｷｯﾌﾟする"に設定
                    lblnSkipFlag = True
                    
                    '@#06-10 or #15-20用に配列をｺﾋﾟｰする
                    ltypSlotPosition = ltypSlotPosition2
                    
                    '@呼び元Functionが"一括分割#01-10ﾎﾞﾀﾝClick処理"か
                    If lstrCallFunction = CMstrCmdLumpDivideWF1Click Then
                        '@#01-05配列選択用ｶｳﾝﾀを設定
                        llngSelectArrayCnt = mlngSlotPosition2Cnt
                    Else
                        '@呼び元Functionが"一括分割#11-20ﾎﾞﾀﾝClick処理"の場合

                        '@#11-15配列選択用ｶｳﾝﾀを設定
                        llngSelectArrayCnt = mlngSlotPosition4Cnt
                    End If
                    
                    '@選択処理判定用ｶｳﾝﾀの設定
                    llngSelectJudgeCnt = 5
                End If
                            
                '@★ 選択ｽﾛｯﾄにより処理分岐 ★
                Select Case llngSelectJudgeCnt
                
                    '@〓 ｽﾛｯﾄ№10 〓
                    Case CMlngSlotNo1, CMlngSlotNo6

                        lctlVsfControl.SetData(16, CMlngvsfSlotMapColWFID, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strWfId)                          'WFID
                        lctlVsfControl.SetData(16, CMlngvsfSlotMapColStatus, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strStatus)                        '状況
                        lctlVsfControl.SetData(16, CMlngvsfSlotMapColClassID, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strClassID)                       'ClassID
                        lctlVsfControl.SetData(16, CMlngvsfSlotMapColBNo, _
                            ltypSlotPosition(llngSelectArrayCnt -1).lngSlotNo)                        '元ｽﾛｯﾄNo.
                        '@↓2019/10/01 (Tue) 13:00:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        lctlVsfControl.SetData(16, CMlngvsfSlotMapColGRB, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strGRB)                           'GRB
                        '@↑2019/10/01 (Tue) 13:00:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    
                    '@〓 ｽﾛｯﾄ№08 〓
                    Case CMlngSlotNo2, CMlngSlotNo7

                        lctlVsfControl.SetData(18, CMlngvsfSlotMapColWFID, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strWfId)                          'WFID
                        lctlVsfControl.SetData(18, CMlngvsfSlotMapColStatus, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strStatus)                        '状況
                        lctlVsfControl.SetData(18, CMlngvsfSlotMapColClassID, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strClassID)                       'ClassID
                        lctlVsfControl.SetData(18, CMlngvsfSlotMapColBNo, _
                            ltypSlotPosition(llngSelectArrayCnt -1).lngSlotNo)                        '元ｽﾛｯﾄNo.
                        '@↓2019/10/01 (Tue) 13:00:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        lctlVsfControl.SetData(18, CMlngvsfSlotMapColGRB, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strGRB)                         'GRB
                        '@↑2019/10/01 (Tue) 13:00:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    
                    '@〓 ｽﾛｯﾄ№06 〓
                    Case CMlngSlotNo3, CMlngSlotNo8

                        lctlVsfControl.SetData(20, CMlngvsfSlotMapColWFID, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strWfId)                          'WFID
                        lctlVsfControl.SetData(20, CMlngvsfSlotMapColStatus, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strStatus)                        '状況
                        lctlVsfControl.SetData(20, CMlngvsfSlotMapColClassID, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strClassID)                       'ClassID
                        lctlVsfControl.SetData(20, CMlngvsfSlotMapColBNo, _
                            ltypSlotPosition(llngSelectArrayCnt -1).lngSlotNo)                        '元ｽﾛｯﾄNo.
                        '@↓2019/10/01 (Tue) 13:00:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        lctlVsfControl.SetData(20, CMlngvsfSlotMapColGRB, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strGRB)                         'GRB
                        '@↑2019/10/01 (Tue) 13:00:36 Y.Yoneyama 「.Netへ反映未」 **************************************************          
                    
                    '@〓 ｽﾛｯﾄ№04 〓
                    Case CMlngSlotNo4, CMlngSlotNo9

                        lctlVsfControl.SetData(22, CMlngvsfSlotMapColWFID, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strWfId)                          'WFID
                        lctlVsfControl.SetData(22, CMlngvsfSlotMapColStatus, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strStatus)                        '状況
                        lctlVsfControl.SetData(22, CMlngvsfSlotMapColClassID, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strClassID)                       'ClassID
                        lctlVsfControl.SetData(22, CMlngvsfSlotMapColBNo, _
                            ltypSlotPosition(llngSelectArrayCnt -1).lngSlotNo)                        '元ｽﾛｯﾄNo.
                        '@↓2019/10/01 (Tue) 13:00:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        lctlVsfControl.SetData(22, CMlngvsfSlotMapColGRB, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strGRB)                         'GRB
                        '@↑2019/10/01 (Tue) 13:00:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    
                    '@〓 ｽﾛｯﾄ№02 〓
                    Case CMlngSlotNo5, CMlngSlotNo10

                        lctlVsfControl.SetData(24, CMlngvsfSlotMapColWFID, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strWfId)                          'WFID
                        lctlVsfControl.SetData(24, CMlngvsfSlotMapColStatus, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strStatus)                        '状況
                        lctlVsfControl.SetData(24, CMlngvsfSlotMapColClassID, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strClassID)                       'ClassID
                        lctlVsfControl.SetData(24, CMlngvsfSlotMapColBNo, _
                            ltypSlotPosition(llngSelectArrayCnt -1).lngSlotNo)                        '元ｽﾛｯﾄNo.
                        '@↓2019/10/01 (Tue) 13:00:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        lctlVsfControl.SetData(24, CMlngvsfSlotMapColGRB, _
                            ltypSlotPosition(llngSelectArrayCnt -1).strGRB)                         'GRB
                        '@↑2019/10/01 (Tue) 13:00:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                End Select
                
                '@選択処理判定用ｶｳﾝﾀ、配列選択用ｶｳﾝﾀのﾃﾞｸﾘﾒﾝﾄ
                llngSelectJudgeCnt = llngSelectJudgeCnt - 1
                llngSelectArrayCnt = llngSelectArrayCnt - 1
                
            Next llngLoopCnt
            
            '@分割予約1or2ｸﾞﾘｯﾄﾞのﾌｫﾝﾄｻｲｽﾞ設定
            '@↓2019/10/01 (Tue) 16:11:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
            'lctlVsfControl.Select(1, CMlngvsfSlotMapColNo, CMlngCarrierRowS, CMlngvsfSlotMapColClassID)    'ｸﾞﾘｯﾄﾞ
            lctlVsfControl.Select(1, CMlngvsfSlotMapColNo, CMlngCarrierRowS, CMlngvsfSlotMapColGRB)    'ｸﾞﾘｯﾄﾞ
            '@↑2019/10/01 (Tue) 16:11:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
            With lctlVsfControl.Font                                             'ﾌｫﾝﾄｻｲｽﾞ
                lctlVsfControl.Font = New Font(.FontFamily, CMlngvsfFontSize, .Style, _
                                            .Unit, .GdiCharSet, .GdiVerticalFont)
            End With

            '@分割予約1or2ｸﾞﾘｯﾄﾞの描画ﾛｯｸ解除
            lctlVsfControl.Redraw = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvDivideVsfSlotMap_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMap_Cal
    '機　能：各ｽﾛｯﾄﾏｯﾌﾟのWF枚数検索＆表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/08 (Thu) 16:07:41 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub prvVsfSlotMap_Cal()

        Dim llngLoopCnt     As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngFCnt        As Integer  'ｽﾛｯﾄﾏｯﾌﾟ記載数

        Try
            
            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　ｽﾛｯﾄﾏｯﾌﾟ(分割元 or 分割予約1 or 分割予約2)のWF枚数を加算し、ﾗﾍﾞﾙに表示する
            '@****************************************************************************
            
            '@初期化
            llngFCnt = 0
                
            '@分割元ﾛｯﾄのｽﾛｯﾄﾏｯﾌﾟ
            With vsfSlotMap
                For llngLoopCnt = 1 To .Rows.Count - 1
                    '@WFIDがNULL以外か
                    If .GetData(llngLoopCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        '@WFIDの文字色がｸﾞﾚｰ以外(白)か
                        If .GetCellRange(llngLoopCnt, CMlngvsfSlotMapColWFID).StyleDisplay.ForeColor <> ColorTranslator.FromWin32(CMlngEnableFalseColor) Then
                            '@WF枚数を+1する
                            llngFCnt = llngFCnt + 1
                        End If
                    End If
                Next llngLoopCnt
            End With
            
            '@分割元のWF枚数ﾗﾍﾞﾙに表示する
            lblWfNum.Text = llngFCnt
                
                
            '@初期化
            llngFCnt = 0
                
            '@分割予約1ｽﾛｯﾄﾏｯﾌﾟ
            With vsfSlotMap1
                For llngLoopCnt = 1 To .Rows.Count - 1
                    '@WFIDがNULL以外か
                    If .GetData(llngLoopCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        '@WF枚数を+1する
                        llngFCnt = llngFCnt + 1
                    End If
                Next llngLoopCnt
            End With
                    
            '@分割予約1のWF枚数ﾗﾍﾞﾙに表示する
            lblWFNum1.Text = llngFCnt
                    

            '@初期化
            llngFCnt = 0

            '@分割予約2ｽﾛｯﾄﾏｯﾌﾟ
            With vsfSlotMap2
                For llngLoopCnt = 1 To .Rows.Count - 1
                    '@WFIDがNULL以外か
                    If .GetData(llngLoopCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        '@WF枚数を+1する
                        llngFCnt = llngFCnt + 1
                    End If
                Next llngLoopCnt
            End With
            
            '@分割予約2のWF枚数ﾗﾍﾞﾙに表示する
            lblWFNum2.Text = llngFCnt

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMap_Cal"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMapFormat_Set
    '機　能：分割予約ｽﾛｯﾄﾏｯﾌﾟ WF移載ﾌｫｰﾏｯﾄ表示処理
    '引　数：lctlcontrol：SlotMapｸﾞﾘｯﾄﾞ
    '戻り値：なし
    '作成日：2005/07/04 (Mon) 13:55:59 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub prvVsfSlotMapFormat_Set(ByRef lctlControl As C1FlexGrid)

        Dim llngCnt        As Integer       'ｶｳﾝﾄ

        Try
            
            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　引数で渡されたｽﾛｯﾄﾏｯﾌﾟの初期化処理を行なう
            '@****************************************************************************
            
            With lctlControl
            
                .Redraw = False                 '描画ﾛｯｸ
                .Clear(ClearFlags.Content)      'ｸﾘｱ
                .ScrollBars = ScrollBars.None   'ｽｸﾛｰﾙﾊﾞｰ表示なし

                '@一覧表の表題設定
                .Rows.Count = CMlngSlotRow                                                                      '行数(26)

                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                '文字色
                headerStyle.BackColor = Color.Navy                  '背景色
                '@左寄せ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter
               
                With .Font                                             'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    headerStyle.Font = New Font(.FontFamily, CMlngVsfHFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With

                '@↓2019/10/01 (Tue) 16:12:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
                'Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfSlotMapColNo, CMlngVsfRowTitle, CMlngvsfSlotMapColClassID)
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfSlotMapColNo, CMlngVsfRowTitle, CMlngvsfSlotMapColGRB)
                '@↑2019/10/01 (Tue) 16:12:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
                cellRange.Style = headerStyle

                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight                                                  '高さ

                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfSlotMapColWFID).Width = CMlngvsfSlotMapWColWFID                                     'WFID
                .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColWFID, CMstrvsfSlotMapColWFID)
                
                .Cols(CMlngvsfSlotMapColClassID).Width = CMlngvsfSlotMapWColClassID                               'Class_ID
                .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColClassID, CMstrvsfSlotMapColClassID)
                
                .Cols(CMlngvsfSlotMapColStatus).Width = CMlngvsfSlotMapWColStatus                                 '状況
                .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColStatus, CMstrvsfSlotMapColStatus)
                
                .Cols(CMlngvsfSlotMapColBNo).Width = CMlngvsfSlotMapWColBNo                                       '元ｽﾛｯﾄNo.
                .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColBNo, CMstrvsfSlotMapColBNo)

                '@↓2019/10/01 (Tue) 13:03:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfSlotMapColGRB).Width = CMlngvsfSlotMapWColGRB                                       'GRB
                .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColGRB, CMstrvsfSlotMapColGRB)
                '@↑2019/10/01 (Tue) 13:03:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                '@一覧表のSlot№設定&ﾊﾞｯｸｶﾗｰ設定
                For llngCnt = 1 To CMlngCarrierRowS
                    
                    .Col = CMlngvsfSlotMapColWFID                                                                 '選択列
                    .Row = llngCnt                                                                              '選択行
                    With .Font                                                                                  'ﾌｫﾝﾄｻｲｽﾞ
                        lctlControl.Font = New Font(.FontFamily, CMlngVsfHFontSize, .Style, _
                                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                    End With
                    .Rows(llngCnt).Height = CMlngVsfHeight                                                      '行高さ
                    
                    '@SlotMap№のﾌｫｰﾏｯﾄ変換("00")
                    .SetData(llngCnt, CMlngvsfSlotMapColNo, _
                         CStr(Format$(CMlngSlotRow - llngCnt, CPstrSlotNoFormat)))
                
                    '@WF移載可能行の背景色設定
                    Select Case CInt(.GetData(llngCnt, CMlngvsfSlotMapColNo))
                        Case CMlngSlotNo20, CMlngSlotNo18, CMlngSlotNo16, CMlngSlotNo14, CMlngSlotNo12, CMlngSlotNo10, CMlngSlotNo8, CMlngSlotNo6, CMlngSlotNo4, CMlngSlotNo2
                        '@ｽﾛｯﾄ偶数(02,04,06,08,10)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = SystemColors.Window
                            '@↓2019/10/01 (Tue) 16:12:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            'Dim cellRange2 As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColWFID, llngCnt, CMlngvsfSlotMapColClassID)
                            Dim cellRange2 As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColWFID, llngCnt, CMlngvsfSlotMapColGRB)
                            '@↑2019/10/01 (Tue) 16:12:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            cellRange2.Style = newStyle                'ﾊﾞｯｸｶﾗｰ白
                    
                        Case Else
                        '@上記以外
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                            '@↓2019/10/01 (Tue) 16:13:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            'Dim cellRange2 As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColWFID, llngCnt, CMlngvsfSlotMapColClassID)
                            Dim cellRange2 As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColWFID, llngCnt, CMlngvsfSlotMapColGRB)
                            '@↑2019/10/01 (Tue) 16:13:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            cellRange2.Style = newStyle      'ﾊﾞｯｸｶﾗｰｸﾞﾚｰ
                    End Select
                Next llngCnt
                
                '@ｽﾛｯﾄ№の右寄せ
                .Cols(CMlngvsfSlotMapColNo).TextAlign = TextAlignEnum.RightCenter
                                                
                '@非表示設定
                .Cols(CMlngvsfSlotMapColClassID).Visible = False
                .Cols(CMlngvsfSlotMapColStatus).Visible = False
                .Cols(CMlngvsfSlotMapColBNo).Visible = False
                
                '@高さ設定
                .Height = CMlngvsfGridHeight
                
                '@初期表示行
                .TopRow = CMlngSlotTopRow
                .Row = -1

                '@描画ﾛｯｸ解除
                .Redraw = True
                
                '@ﾛｯｸ解除
                .Enabled = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMapFormat_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMapInfo_Set
    '機　能：分割元ｽﾛｯﾄﾏｯﾌﾟ情報格納処理
    '引　数：mlngWFNum：元ｷｬﾘｱWF数
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 17:10:07 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub prvVsfSlotMapInfo_Set(ByRef mlngWFNum As Integer)

        Dim llngLoopCnt     As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngSlotCnt1    As Integer  '分割予約1ｽﾛｯﾄｶｳﾝﾄ(#01-05)
        Dim llngSlotCnt2    As Integer  '分割予約1ｽﾛｯﾄｶｳﾝﾄ(#06-10)
        Dim llngSlotCnt3    As Integer  '分割予約2ｽﾛｯﾄｶｳﾝﾄ(#11-15)
        Dim llngSlotCnt4    As Integer  '分割予約2ｽﾛｯﾄｶｳﾝﾄ(#16-20)

        Try
            
            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　分割元ｽﾛｯﾄﾏｯﾌﾟの情報格納処理を行なう
            '@****************************************************************************
            
            '@初期化
            llngSlotCnt1 = 0
            llngSlotCnt2 = 0
            llngSlotCnt3 = 0
            llngSlotCnt4 = 0
            
            '@ｽﾛｯﾄﾏｯﾌﾟの分割元ｷｬﾘｱWF枚数の表示
            lblWfNum.Text = CStr(mtypInvWaferList.lngInvWaferListCnt)
            
            '@ﾓｼﾞｭｰﾙ変数へ格納
            mlngWFNum = mtypInvWaferList.lngInvWaferListCnt
            
            '@分割元ｷｬﾘｱのWFのｽﾛｯﾄ内容を内部変数へ格納
            With vsfSlotMap
            
                For llngLoopCnt = 1 To 20
                    
                    '@★ ｽﾛｯﾄ№により処理分岐 ★
                    Select Case CLng(.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColNo))
                    
                        '@〓 ｽﾛｯﾄ№01-05 〓
                        Case Is <= 5
                        
                            '@WFIDがNULL以外か
                            If .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                
                                Dim mtypSlotPosition1Tmp As New SlotPosition

                                '@ｽﾛｯﾄ№空白以外の場合
                                If .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColNo) <> vbNullString Then
                                
                                    '@領域確保(ｽﾛｯﾄ№01-05)
                                    mlngSlotPosition1Cnt = mlngSlotPosition1Cnt + 1

                                    mtypSlotPosition1Tmp.lngSlotNo _
                                        = CLng(.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColNo))             'ｽﾛｯﾄﾅﾝﾊﾞｰ
                                End If
                                
                                mtypSlotPosition1Tmp.strWfId _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID)                     'WFID
                                    
                                mtypSlotPosition1Tmp.strStatus _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColStatus)                   '状況
                                    
                                mtypSlotPosition1Tmp.strClassID _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColClassID)                  'ClassID

                                '@↓2019/10/01 (Tue) 16:14:25 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                mtypSlotPosition1Tmp.strGRB _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColGRB)                      'GRB
                                '@↑2019/10/01 (Tue) 16:14:25 Y.Yoneyama 「.Netへ反映未」 **************************************************

                                mtypSlotPosition1.Add(mtypSlotPosition1Tmp)

                                '@配列ｶｳﾝﾀ+1
                                llngSlotCnt1 = llngSlotCnt1 + 1
                            End If


                        '@〓 ｽﾛｯﾄ№06-10 〓
                        Case Is <= 10
                                        
                            '@WFIDがNULL以外か
                            If .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                
                                Dim mtypSlotPosition2Tmp As New SlotPosition

                                '@ｽﾛｯﾄ№空白以外の場合
                                If .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColNo) <> vbNullString Then
                                
                                    '@領域確保(ｽﾛｯﾄ№06-10)
                                    mlngSlotPosition2Cnt = mlngSlotPosition2Cnt + 1
                                
                                    mtypSlotPosition2Tmp.lngSlotNo _
                                        = CLng(.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColNo))             'ｽﾛｯﾄﾅﾝﾊﾞｰ
                                End If
                                
                                mtypSlotPosition2Tmp.strWfId _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID)                     'WFID
                                    
                                mtypSlotPosition2Tmp.strStatus _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColStatus)                   '状況
                                    
                                mtypSlotPosition2Tmp.strClassID _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColClassID)                  'ClassID

                                '@↓2019/10/01 (Tue) 16:15:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                mtypSlotPosition2Tmp.strGRB _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColGRB)                      'GRB
                                '@↑2019/10/01 (Tue) 16:15:04 Y.Yoneyama 「.Netへ反映未」 **************************************************

                                mtypSlotPosition2.Add(mtypSlotPosition2Tmp)

                                '@配列ｶｳﾝﾀ+1
                                llngSlotCnt2 = llngSlotCnt2 + 1
                            End If
                            
                            
                        '@〓 ｽﾛｯﾄ№11-15 〓
                        Case Is <= 15
                                        
                            '@WFIDがNULL以外か
                            If .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                
                                Dim mtypSlotPosition3Tmp As New SlotPosition

                                '@ｽﾛｯﾄ№空白以外の場合
                                If .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColNo) <> vbNullString Then
                                
                                    '@領域確保(ｽﾛｯﾄ№11-15)
                                    mlngSlotPosition3Cnt = mlngSlotPosition3Cnt + 1
                                
                                    mtypSlotPosition3Tmp.lngSlotNo _
                                        = CLng(.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColNo))             'ｽﾛｯﾄﾅﾝﾊﾞｰ
                                End If
                                
                                mtypSlotPosition3Tmp.strWfId _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID)                     'WFID
                                    
                                mtypSlotPosition3Tmp.strStatus _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColStatus)                   '状況
                                    
                                mtypSlotPosition3Tmp.strClassID _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColClassID)                  'ClassID

                                '@↓2019/10/01 (Tue) 16:15:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                mtypSlotPosition3Tmp.strGRB _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColGRB)                      'GRB
                                '@↑2019/10/01 (Tue) 16:15:39 Y.Yoneyama 「.Netへ反映未」 **************************************************

                                mtypSlotPosition3.Add(mtypSlotPosition3Tmp)

                                '@配列ｶｳﾝﾀ+1
                                llngSlotCnt3 = llngSlotCnt3 + 1
                            End If
                            
                            
                        '@〓 ｽﾛｯﾄ№16-20 〓
                        Case Is <= 20
                            
                            '@WFIDがNULL以外か
                            If .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                
                                Dim mtypSlotPosition4Tmp As New SlotPosition

                                '@ｽﾛｯﾄ№空白以外の場合
                                If .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColNo) <> vbNullString Then
                                
                                    '@領域確保(ｽﾛｯﾄ№16-20)
                                    mlngSlotPosition4Cnt = mlngSlotPosition4Cnt + 1
                                
                                    mtypSlotPosition4Tmp.lngSlotNo _
                                        = CLng(.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColNo))             'ｽﾛｯﾄﾅﾝﾊﾞｰ
                                End If
                                
                                mtypSlotPosition4Tmp.strWfId _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID)                     'WFID
                                    
                                mtypSlotPosition4Tmp.strStatus _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColStatus)                   '状況
                                    
                                mtypSlotPosition4Tmp.strClassID _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColClassID)                  'ClassID

                                '@↓2019/10/01 (Tue) 16:16:15 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                mtypSlotPosition4Tmp.strGRB _
                                    = .GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColGRB)                      'GRB
                                '@↑2019/10/01 (Tue) 16:16:15 Y.Yoneyama 「.Netへ反映未」 **************************************************

                                mtypSlotPosition4.Add(mtypSlotPosition4Tmp)

                                '@配列ｶｳﾝﾀ+1
                                llngSlotCnt4 = llngSlotCnt4 + 1
                            End If
                            
                    End Select
                Next llngLoopCnt
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMapInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvObjectControl_Proc
    '機　能：各種ｺﾝﾄﾛｰﾙ(ｵﾌﾞｼﾞｪｸﾄ)制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/08 (Thu) 16:35:35 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Public Sub prvObjectControl_Proc()

        Try
            
            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　分割元ｽﾛｯﾄﾏｯﾌﾟのWF枚数を判定し、各種ﾎﾞﾀﾝとｽﾛｯﾄﾏｯﾌﾟの有効/無効制御を行なう
            '@****************************************************************************
            
            '@★ 分割元ｽﾛｯﾄﾏｯﾌﾟのWF数により処理分岐 ★
            Select Case mlngWFNum
            
                '@〓 WF枚数=0 〓
                Case 0
                
                    '@各ﾎﾞﾀﾝの制御
                    cmdManual.Enabled = False               '編成用手動分割
        '            cmdLump.Enabled = False                 '編成用一括分割
                    cmdLumpDivideWF1.Enabled = False        '一括分割#01-10
                    cmdLumpDivideWF2.Enabled = False        '一括分割#11-20
                    
                    '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ
                    vsfSlotMap.Enabled = False              '元ｷｬﾘｱｽﾛｯﾄﾏｯﾌﾟ
                    vsfSlotMap1.Enabled = False             '分割先ｽﾛｯﾄﾏｯﾌﾟ1
                    vsfSlotMap2.Enabled = False             '分割先ｽﾛｯﾄﾏｯﾌﾟ2
                    
                '@〓 WF枚数=0以外 〓
                Case Else
                
                    '@各ﾎﾞﾀﾝの制御
                    cmdManual.Enabled = True                '編成用手動分割
        '            cmdLump.Enabled = True                  '編成用一括分割
                
                    '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ
                    vsfSlotMap.Enabled = False              '元ｷｬﾘｱｽﾛｯﾄﾏｯﾌﾟ
                    vsfSlotMap1.Enabled = False             '分割先ｽﾛｯﾄﾏｯﾌﾟ1
                    vsfSlotMap2.Enabled = False             '分割先ｽﾛｯﾄﾏｯﾌﾟ2
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvObjectControl_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmdRegistControl_Proc
    '機　能：確定ﾎﾞﾀﾝ制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/08 (Thu) 15:20:52 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub prvCmdRegistControl_Proc()

        Dim llngCnt             As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lblnSlotMapFlag1    As Boolean      'ｽﾛｯﾄﾏｯﾌﾟﾌﾗｸﾞ(True:WF有/False:WF無)
        Dim lblnSlotMapFlag2    As Boolean      'ｽﾛｯﾄﾏｯﾌﾟﾌﾗｸﾞ(True:WF有/False:WF無)

        Try

            '@**************************************************************************
            '@★当Functionの処理概要★
            '@  移載/分割ﾌﾗｸﾞ毎に対象ｷｬﾘｱIDの入力状況をﾁｪｯｸし、確定ﾎﾞﾀﾝの有効/無効を制御する
            '@**************************************************************************
            
            '@該当件数0件時 処理抜け
            If mlngFormationFlag = CMlngNothing Then
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                Exit Sub
            End If
                
            '@★ 移載/分割ﾌﾗｸﾞ(該当件数なし:0、移載:1、分割:2、手動移載:3)により処理分岐 〓
            Select Case mlngFormationFlag
                
                '@〓 1:移載 or 2:分割 〓
                Case CMlngTransfer, CMlngPartition

                    '@分割予約1
                    With vsfSlotMap1
                        For llngCnt = 1 To .Rows.Count - 1
                            '@WFIDがNULL以外か
                            If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                '@分割予約1ｷｬﾘｱIDがNullか
                                If txtToCarrierID1.Text = vbNullString Then
                                    '@確定ﾎﾞﾀﾝを無効にする
                                    cmdRegist.Enabled = False
                                    Exit Sub
                                Else
                                    Exit For
                                End If
                            End If
                        Next llngCnt
                    End With
                
                    '@移載/分割ﾌﾗｸﾞが"2:分割"か
                    If mlngFormationFlag = CMlngPartition Then
                    
                        '@分割予約2
                        With vsfSlotMap2
                            For llngCnt = 1 To .Rows.Count - 1
                                '@WFIDがNULL以外か
                                If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                    '@分割予約2ｷｬﾘｱIDがNullか
                                    If txtToCarrierID2.Text = vbNullString Then
                                        '@確定ﾎﾞﾀﾝを無効にする
                                        cmdRegist.Enabled = False
                                        Exit Sub
                                    Else
                                        Exit For
                                    End If
                                End If
                            Next llngCnt
                        End With
                    End If
                
                
                '@〓 0:該当件数なし or 3:手動移載 〓
                Case Else

                    '@初期化
                    lblnSlotMapFlag1 = False        '分割予約1ｽﾛｯﾄﾏｯﾌﾟﾌﾗｸﾞ
                    lblnSlotMapFlag2 = False        '分割予約2ｽﾛｯﾄﾏｯﾌﾟﾌﾗｸﾞ
                    
                    '@分割予約1
                    With vsfSlotMap1
                        For llngCnt = 1 To .Rows.Count - 1
                            '@WFIDがNULL以外か
                            If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                
                                '@分割予約1ｽﾛｯﾄﾏｯﾌﾟﾌﾗｸﾞを"True:有効"にする
                                lblnSlotMapFlag1 = True
                                Exit For
                            End If
                        Next llngCnt
                    End With
                            
                    '@分割予約2
                    With vsfSlotMap2
                        For llngCnt = 1 To .Rows.Count - 1
                            '@WFIDがNULL以外か
                            If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                
                                '@分割予約2ｽﾛｯﾄﾏｯﾌﾟﾌﾗｸﾞを"True:有効"にする
                                lblnSlotMapFlag2 = True
                                Exit For
                            End If
                        Next llngCnt
                    End With
                    
                    
                    '@★ 分割予約1 or 2ｽﾛｯﾄﾏｯﾌﾟﾌﾗｸﾞがTrueかにより処理分岐 ★
                    Select Case True
                    
                        '@〓 分割予約1と分割予約2 〓
                        Case lblnSlotMapFlag1 And lblnSlotMapFlag2

                            '@分割予約1ｷｬﾘｱIDがNullか
                            If txtToCarrierID1.Text = vbNullString Then
                                '@確定ﾎﾞﾀﾝを無効にする
                                cmdRegist.Enabled = False
                                Exit Sub
                            End If
                            
                            '@分割予約2ｷｬﾘｱIDがNullか
                            If txtToCarrierID2.Text = vbNullString Then
                                '@確定ﾎﾞﾀﾝを無効にする
                                cmdRegist.Enabled = False
                                Exit Sub
                            End If
                        
                        '@〓 分割予約1のみ 〓
                        Case lblnSlotMapFlag1
                        
                            '@分割予約1ｷｬﾘｱIDがNullか
                            If txtToCarrierID1.Text = vbNullString Then
                                '@確定ﾎﾞﾀﾝを無効にする
                                cmdRegist.Enabled = False
                                Exit Sub
                            End If
                        
                        '@〓 分割予約2のみ 〓
                        Case lblnSlotMapFlag2

                            '@分割予約2ｷｬﾘｱIDがNullか
                            If txtToCarrierID2.Text = vbNullString Then
                                '@確定ﾎﾞﾀﾝを無効にする
                                cmdRegist.Enabled = False
                                Exit Sub
                            End If
                        
                        '@〓 その他 〓
                        Case Else
                        
                            '@確定ﾎﾞﾀﾝを無効にする
                            cmdRegist.Enabled = False
                            Exit Sub
                        
                    End Select
            End Select
            
            '@上記のﾁｪｯｸに引っ掛からなかった場合、確定ﾎﾞﾀﾝを有効にする
            cmdRegist.Enabled = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdRegistControl_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：各種入力ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True:OK/False:NG
    '作成日：2004/09/26 (Sun) 16:46:20 N.Kasai
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Function prvblnInput_Chk() As Boolean
        
        Dim llngCnt             As Integer          '汎用ｶｳﾝﾀ
        Dim lblnSlotMap1        As Boolean          'ｽﾛｯﾄﾏｯﾌﾟ1ﾁｪｯｸ対象判定ﾌﾗｸﾞ
        Dim lblnSlotMap2        As Boolean          'ｽﾛｯﾄﾏｯﾌﾟ2ﾁｪｯｸ対象判定ﾌﾗｸﾞ
        
        Try

            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　確定ﾎﾞﾀﾝ押下の際のﾁｪｯｸ。移載/分割ﾌﾗｸﾞを判定し、入力ﾁｪｯｸを行なう
            '@****************************************************************************

            '@戻り値の初期化
            prvblnInput_Chk = False
            
            '@★ 移載/分割ﾌﾗｸﾞ(0:該当件数なし、1:移載、2:分割、3:手動移載分割)により処理分岐 ★
            Select Case mlngFormationFlag
                
                '@〓 1:移載 〓
                Case CMlngTransfer
                
                    '@分割予約1ｷｬﾘｱIDがNULLか
                    If txtToCarrierID1.Text = vbNullString Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                        '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@分割予約1ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtToCarrierID1)
                        Exit Function
                    End If


                '@〓 2:分割 〓
                Case CMlngPartition
                
                    '@分割予約1ｽﾛｯﾄﾏｯﾌﾟのﾁｪｯｸ
                    With vsfSlotMap1
                        For llngCnt = 1 To .Rows.Count - 1
                            '@WFIDがNULL以外か
                            If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                '@分割予約1ｷｬﾘｱIDがNULLか
                                If txtToCarrierID1.Text = vbNullString Then
                                
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                                    '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    
                                    '@分割予約1ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(txtToCarrierID1)
                                    Exit Function
                                Else
                                    Exit For
                                End If
                            End If
                        Next llngCnt
                    End With

                    '@分割予約2ｽﾛｯﾄﾏｯﾌﾟのﾁｪｯｸ
                    With vsfSlotMap2
                        For llngCnt = 1 To .Rows.Count - 1
                            '@WFIDがNULL以外か
                            If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                '@分割予約2ｷｬﾘｱIDがNULLか
                                If txtToCarrierID2.Text = vbNullString Then
                                
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                                    '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    
                                    '@分割予約2ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(txtToCarrierID2)
                                    Exit Function
                                Else
                                    Exit For
                                End If
                            End If
                        Next llngCnt
                    End With
            
                    '@分割予約1ｷｬﾘｱIDと分割予約2ｷｬﾘｱIDが同一ｷｬﾘｱか
                    If txtToCarrierID1.Text = txtToCarrierID2.Text Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003M)
                        '@"同一キャリアIDの指定はできません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@分割予約2ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtToCarrierID2)
                        Exit Function
                    End If


                '@〓 3:手動分割 〓
                Case CMlngManual
                
                    '@各種ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ対象判定ﾌﾗｸﾞを初期化
                    lblnSlotMap1 = False
                    lblnSlotMap2 = False
                    
                    '@分割予約1ｽﾛｯﾄﾏｯﾌﾟのﾁｪｯｸ
                    With vsfSlotMap1
                        For llngCnt = 1 To .Rows.Count - 1
                            '@WFIDがNULL以外か
                            If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                
                                '@分割予約1ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ対象判定ﾌﾗｸﾞに"True:ﾁｪｯｸ対象"をｾｯﾄ
                                lblnSlotMap1 = True
                                Exit For
                            End If
                        Next llngCnt
                    End With
            
                    '@分割予約2ｽﾛｯﾄﾏｯﾌﾟのﾁｪｯｸ
                    With vsfSlotMap2
                        For llngCnt = 1 To .Rows.Count - 1
                            '@WFIDがNULL以外か
                            If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                
                                '@分割予約2ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ対象判定ﾌﾗｸﾞに"True:ﾁｪｯｸ対象"をｾｯﾄ
                                lblnSlotMap2 = True
                                Exit For
                            End If
                        Next llngCnt
                    End With
            
                    '@分割予約1ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ対象判定ﾌﾗｸﾞが"True:ﾁｪｯｸ対象"か
                    If lblnSlotMap1 = True Then
                    
                        '@分割予約1ｷｬﾘｱIDがNULLか
                        If txtToCarrierID1.Text = vbNullString Then
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                            '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@分割予約1ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtToCarrierID1)
                            Exit Function
                        End If
                    End If
                    
                    '@分割予約2ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ対象判定ﾌﾗｸﾞが"True:ﾁｪｯｸ対象"か
                    If lblnSlotMap2 = True Then
                        
                        '@分割予約2ｷｬﾘｱIDがNULLか
                        If txtToCarrierID2.Text = vbNullString Then
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                            '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@分割予約2ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtToCarrierID2)
                            Exit Function
                        End If
                    End If
            
                    '@分割予約1ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ対象判定ﾌﾗｸﾞ、分割予約2ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ対象判定ﾌﾗｸﾞが
                    '@両方共"True:ﾁｪｯｸ対象"か
                    If lblnSlotMap1 = True And lblnSlotMap2 = True Then
                        
                        '@分割予約1ｷｬﾘｱIDと分割予約2ｷｬﾘｱIDが同一ｷｬﾘｱか
                        If txtToCarrierID1.Text = txtToCarrierID2.Text Then
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003M)
                            '@"同一キャリアIDの指定はできません。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@分割予約2ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtToCarrierID2)
                            Exit Function
                        End If
                    End If
            End Select
            
            '@戻り値に"True:成功"を返す
            prvblnInput_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInput_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCarrierControl_Proc
    '機　能：ﾃｷｽﾄﾎﾞｯｸｽ、ｷｬﾘｱ選択ﾎﾞﾀﾝ制御処理
    '引　数：lctlvsfcontrol：ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ
    '　　　：lctltxtcontrol：ﾃｷｽﾄﾎﾞｯｸｽｺﾝﾄﾛｰﾙ
    '　　　：lctlcmdcontrol：ｺﾏﾝﾄﾞﾎﾞﾀﾝｺﾝﾄﾛｰﾙ
    '戻り値：なし
    '作成日：2005/07/05 (Tue) 08:30:40 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub prvCarrierControl_Proc(ByRef lctlVsfControl As C1FlexGrid, _
                                       ByRef lctltxtcontrol As SETextBoxEx.TextBoxEx, _
                                       ByRef lctlcmdcontrol As Button)

        Dim llngCnt             As Integer          'ｶｳﾝﾄ
        Dim lblnEnabledFlag     As Boolean          '制御ﾌﾗｸﾞ(True:有効、False:無効)

        Try

            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　引継ぎ情報のｸﾞﾘｯﾄﾞのWFIDの存在有無を判定し、ﾃｷｽﾄﾎﾞｯｸｽ、ｷｬﾘｱ選択ﾎﾞﾀﾝ制御処理を行なう
            '@****************************************************************************

            '@初期化
            lblnEnabledFlag = False
            
            '@対象ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ
            With lctlVsfControl
            
                '@ﾀｲﾄﾙ以外か
                If .Row <> 0 Then
                
                    For llngCnt = 1 To .Rows.Count - 1
                        
                        '@WFIDがNULL以外か
                        If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                            
                            '@制御ﾌﾗｸﾞに"True:有効"をｾｯﾄする
                            lblnEnabledFlag = True
                            Exit For
                        End If
                    Next llngCnt
                End If
            End With
                
            '@制御ﾌﾗｸﾞが"True:有効"か
            If lblnEnabledFlag = True Then
                
                '@各種ｺﾝﾄﾛｰﾙを有効にする
                lctltxtcontrol.Enabled = True       'ｷｬﾘｱIDﾃｷｽﾄ
                lctlcmdcontrol.Enabled = True       '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
            Else
                '@制御ﾌﾗｸﾞが"False:無効"の場合
                
                '@各種ｺﾝﾄﾛｰﾙを無効にする
                lctltxtcontrol.Enabled = False      'ｷｬﾘｱIDﾃｷｽﾄ
                lctltxtcontrol.Text = vbNullString
                lctlcmdcontrol.Enabled = False      '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMapFormat_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMapCell_Proc
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ選択行以外の情報をｸﾘｱし情報を反映
    '引　数：lctlvsfcontrol ：選択ｸﾞﾘｯﾄﾞ名
    '　　　：llngRow        ：選択行
    '戻り値：なし
    '作成日：2005/07/05 (Tue) 11:02:23 S.Deguchi
    '更新日：2008/04/09 (Wed) 10:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/09 (Wed) 10:48:56 N.Kojima     要望対応のついでにｿｰｽ整備。(案件№02539)
    Private Sub prvVsfSlotMapCell_Proc(ByRef lctlVsfControl As C1FlexGrid, _
                                       ByVal llngRow As Integer)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        
        Try
            
            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　各種ｸﾞﾘｯﾄﾞのWFIDが退避構造体のWFIDと同じか判定し、各種ｸﾞﾘｯﾄﾞの表示制御を行なう
            '@****************************************************************************
            
            '@分割元ｽﾛｯﾄﾏｯﾌﾟ
            With vsfSlotMap
            
                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@退避構造体のWFIDと分割元ｽﾛｯﾄﾏｯﾌﾟに同じWFIDが存在するか
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) = mtypTransfer.strWfId Then
                        Dim newStyle    As CellStyle    
                        Dim cellRange   As CellRange    

                        '@分割元ｽﾛｯﾄﾏｯﾌﾟの対象行の文字色をｸﾞﾚｰにする
                        newStyle = .Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseColor")
                        newStyle.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                        cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColWFID, llngCnt, CMlngvsfSlotMapColBNo)
                        cellRange.Style = newStyle

                        '@↓2019/10/01 (Tue) 15:30:56 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        newStyle = .Styles.Add("GRBColor" + llngCnt.ToString)
                        newStyle.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                        cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColGRB)
                        cellRange.Style = newStyle   'GRB
                        '@↑2019/10/01 (Tue) 15:30:56 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    End If
                Next llngCnt
            End With
            
            
            '@分割予約1ｽﾛｯﾄﾏｯﾌﾟ
            With vsfSlotMap1
            
                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@退避構造体のWFIDと分割予約1ｽﾛｯﾄﾏｯﾌﾟに同じWFIDが存在するか
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) = mtypTransfer.strWfId Then
                        
                        '@分割予約1ｽﾛｯﾄﾏｯﾌﾟの対象行をNULLにする
                        .SetData(llngCnt, CMlngvsfSlotMapColWFID, vbNullString)                   'WFID
                        .SetData(llngCnt, CMlngvsfSlotMapColClassID, vbNullString)                'ClassID
                        .SetData(llngCnt, CMlngvsfSlotMapColStatus, vbNullString)                 '状況
                        .SetData(llngCnt, CMlngvsfSlotMapColBNo, vbNullString)                    '移載元№
                        '@↓2019/10/01 (Tue) 13:05:21 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .SetData(llngCnt, CMlngvsfSlotMapColGRB, vbNullString)                    'GRB

                        '@GRB背景色
                        Dim styleGRB As CellStyle = .Styles.Add("GRBColor" + llngCnt.ToString)
                        styleGRB.BackColor = .GetCellStyle(llngCnt, CMlngvsfSlotMapColWFID).BackColor
                        Dim cellGRB = .GetCellRange(llngCnt, CMlngvsfSlotMapColGRB)
                        cellGRB.Style.BackColor = styleGRB.BackColor
                        '@↑2019/10/01 (Tue) 13:05:21 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    End If
                Next llngCnt
            End With
            
            
            '@分割予約2ｽﾛｯﾄﾏｯﾌﾟ
            With vsfSlotMap2
            
                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@退避構造体のWFIDと分割予約2ｽﾛｯﾄﾏｯﾌﾟに同じWFIDが存在するか
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) = mtypTransfer.strWfId Then
                        
                        '@分割予約2ｽﾛｯﾄﾏｯﾌﾟの対象行をNULLにする
                        .SetData(llngCnt, CMlngvsfSlotMapColWFID, vbNullString)                   'WFID
                        .SetData(llngCnt, CMlngvsfSlotMapColClassID, vbNullString)                'ClassID
                        .SetData(llngCnt, CMlngvsfSlotMapColStatus, vbNullString)                 '状況
                        .SetData(llngCnt, CMlngvsfSlotMapColBNo, vbNullString)                    '移載元№
                        '@↓2019/10/01 (Tue) 13:05:43 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .SetData(llngCnt, CMlngvsfSlotMapColGRB, vbNullString)                    'GRB

                        '@GRB背景色
                        Dim styleGRB As CellStyle = .Styles.Add("GRBColor" + llngCnt.ToString)
                        styleGRB.BackColor = .GetCellStyle(llngCnt, CMlngvsfSlotMapColWFID).BackColor
                        Dim cellGRB = .GetCellRange(llngCnt, CMlngvsfSlotMapColGRB)
                        cellGRB.Style.BackColor = styleGRB.BackColor
                        '@↑2019/10/01 (Tue) 13:05:43 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    End If
                Next llngCnt
            End With
            
            
            '@退避した情報をｽﾛｯﾄﾏｯﾌﾟへ反映
            With lctlVsfControl
            
                .SetData(llngRow, CMlngvsfSlotMapColWFID, mtypTransfer.strWfId)                   'WFID
                .SetData(llngRow, CMlngvsfSlotMapColClassID, mtypTransfer.strClassID)             'ClassID
                .SetData(llngRow, CMlngvsfSlotMapColStatus, mtypTransfer.strStatus)               '状況
                .SetData(llngRow, CMlngvsfSlotMapColBNo, mtypTransfer.lngSlotNo)                  '移載元№
                '@↓2019/10/01 (Tue) 15:31:24 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .SetData(llngRow, CMlngvsfSlotMapColGRB, mtypTransfer.strGRB)                     'GRB
                '@↑2019/10/01 (Tue) 15:31:24 Y.Yoneyama 「.Netへ反映未」 **************************************************
            
                '@設定文字色は黒で表示する
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack")
                Dim cellRange As CellRange
                newStyle.ForeColor = Color.Black
                cellRange = .GetCellRange(llngRow, CMlngvsfSlotMapColWFID, llngRow, CMlngvsfSlotMapColBNo)
                cellRange.Style = newStyle

                '@↓2019/10/01 (Tue) 15:31:55 Y.Yoneyama 「.Netへ反映未」 **************************************************
                newStyle = .Styles.Add("GRBColor" + llngRow.ToString)
                newStyle.BackColor = pubGRBBackColor(.GetData(llngRow, CMlngvsfSlotMapColGRB))
                cellRange = .GetCellRange(llngRow, CMlngvsfSlotMapColGRB)
                cellRange.Style = newStyle                         'GRB
                '@↑2019/10/01 (Tue) 15:31:55 Y.Yoneyama 「.Netへ反映未」 **************************************************
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMapCell_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLoadCarrierSelect_Proc
    '機　能：空きｷｬﾘｱ選択画面起動処理
    '引　数：lctlcmdcontrol：ｺﾏﾝﾄﾞﾎﾞﾀﾝｺﾝﾄﾛｰﾙ
    '戻り値：なし
    '作成日：2008/04/09 (Wed) 10:27:08 N.Kojima
    '更新日：2008/04/09 (Wed) 10:27:08
    '備　考：
    Private Sub prvLoadCarrierSelect_Proc(ByRef lctlcmdcontrol As Button)

        Try

            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　空きｷｬﾘｱ選択画面の起動処理を行う。また、処理が戻された際は引継ぎｺﾝﾄﾛｰﾙを
            '@　判定し、対象ｷｬﾘｱIDの処理を行う
            '@****************************************************************************

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@ｷｬﾘｱﾀｲﾌﾟID引渡し(FOUP限定)
            pstrCarrierTypeID = CPstrCarrTypeFOUP
            
            '@ｷｬﾘｱの洗浄条件：未洗浄不可
            pstrCleanCondition = CPstrCarrierClean2
            
            '@初期化
            pstrCarrierID = vbNullString
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　空きｷｬﾘｱ一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00K0.Instance = New frmxxCM00K0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
            
                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                frmxxCM00K0.Instance = Nothing
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　空きｷｬﾘｱ一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00K0.Instance.ShowDialog(Me)
            frmxxCM00K0.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrCarrierID <> vbNullString Then
                
                '@呼び元が分割予約1か
                If lctlcmdcontrol.Name = cmdCarrierSelect1.Name Then
                
                    '@分割予約1ｷｬﾘｱIDにｾｯﾄ
                    txtToCarrierID1.Text = pstrCarrierID
                    
                    '@=======================
                    '@　分割予約1ｷｬﾘｱのValidate処理
                    '@=======================
                    RemoveHandler txtToCarrierID1.Validating, AddressOf txtToCarrierID1_Validate
                    Call txtToCarrierID1_Validate(txtToCarrierID1,New CancelEventArgs(True))
                    AddHandler txtToCarrierID1.Validating, AddressOf txtToCarrierID1_Validate

                    '@分割予約1ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtToCarrierID1)
                Else
                    '@分割予約2ｷｬﾘｱIDにｾｯﾄ
                    txtToCarrierID2.Text = pstrCarrierID
                    
                    '@=======================
                    '@　分割予約2ｷｬﾘｱのValidate処理
                    '@=======================
                    RemoveHandler txtToCarrierID2.Validating, AddressOf txtToCarrierID2_Validate
                    Call txtToCarrierID2_Validate(txtToCarrierID2,New CancelEventArgs(True))
                    AddHandler txtToCarrierID2.Validating, AddressOf txtToCarrierID2_Validate

                    '@分割予約2ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtToCarrierID2)
                End If
            End If

            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLoadCarrierSelect_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvRegistDataSet_Proc
    '機　能：確定情報設定処理
    '引　数：lblnDivideFlag1    ：分割1存在ﾌﾗｸﾞ(True:あり、False:なし)
    '　　　：lblnDivideFlag2    ：分割2存在ﾌﾗｸﾞ(True:あり、False:なし)
    '戻り値：なし
    '作成日：2008/04/09 (Wed) 10:27:08 N.Kojima
    '更新日：2008/04/09 (Wed) 10:27:08
    '備　考：
    Private Sub prvRegistDataSet_Proc(ByRef lblnDivideFlag1 As Boolean, _
                                      ByRef lblnDivideFlag2 As Boolean)

        Dim llngSCnt                As Integer              'ｶｳﾝﾄ
        Dim llngLoopCnt             As Integer              'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　分割予約1、分割予約2に情報が存在するかのﾊﾞﾘｴｰｼｮﾝで、確定時に送信する
            '@　要求ﾒｯｾｰｼﾞの設定を行なう
            '@****************************************************************************

            '@分割予約1ｷｬﾘｱIDがNULL以外か
            If txtToCarrierID1.Text <> vbNullString Then
                '@分割1存在ﾌﾗｸﾞを"True:存在"をｾｯﾄ
                lblnDivideFlag1 = True
            Else
                '@分割1存在ﾌﾗｸﾞを"False:存在しない"をｾｯﾄ
                lblnDivideFlag1 = False
            End If
            
            '@分割予約2ｷｬﾘｱIDがNULL以外か
            If txtToCarrierID2.Text <> vbNullString Then
                '@分割2存在ﾌﾗｸﾞを"True:存在"をｾｯﾄ
                lblnDivideFlag2 = True
            Else
                '@分割2存在ﾌﾗｸﾞを"False:存在しない"をｾｯﾄ
                lblnDivideFlag2 = False
            End If
            
            
            '@確定の情報を格納
            With mtyplotasmdivide
                
                .strLotID = lblLotID.Text                                '分割元ﾛｯﾄID
                
                '@--------------------
                '@　存在ﾁｪｯｸから判別
                '@--------------------
                
                '@**************************************
                '@　①分割予約1ｽﾛｯﾄﾏｯﾌﾟ：WF存在
                '@　②分割予約2ｽﾛｯﾄﾏｯﾌﾟ：WF存在　か
                '@**************************************
                If lblnDivideFlag1 = True And lblnDivideFlag2 = True Then
                    
                    '@---------------------
                    '@　分割予約1の設定
                    '@---------------------
        '            .strDivedeLotID = lblLotID1.Caption                      '分割予約1ﾛｯﾄID
                    .strDivedeLotID = lblLotID.Text                      '分割元ﾛｯﾄID
                    .lngDivedewfMapListCnt = CInt(lblWFNum1.Text)        '分割予約1ｽﾛｯﾄﾏｯﾌﾟ
                
                    '@分割予約1ｽﾛｯﾄﾏｯﾌﾟ
                    llngSCnt = 0
                    
                    '@分割予約1ﾛｯﾄのWF枚数が0以外か
                    If lblWFNum1.Text <> 0 Then

                        '@領域確保
                        If .typDivedeWfMapList Is Nothing Then
                            .typDivedeWfMapList = New List(Of DivideWFMap)
                        End If
                        Dim typDivedeWfMapLisTmp As New DivideWFMap
                        
                        For llngLoopCnt = CMlngSlotMap1 To CMlngSlotRow - 1
                            
                            '@分割予約1ｽﾛｯﾄﾏｯﾌﾟのWFIDがNULL以外か
                            If vsfSlotMap1.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                
                                '@分割予約1ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄﾎﾟｼﾞｼｮﾝ格納
                                typDivedeWfMapLisTmp.strSlotPosition _
                                    = vsfSlotMap1.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColNo)
                                
                                '@分割予約1ｽﾛｯﾄﾏｯﾌﾟのWFID格納
                                typDivedeWfMapLisTmp.strWfId _
                                    = vsfSlotMap1.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID)
                                
                                .typDivedeWfMapList.Add(typDivedeWfMapLisTmp)

                                '@ｶｳﾝﾄｱｯﾌﾟ
                                llngSCnt = llngSCnt + 1
                            End If
                        Next llngLoopCnt
                    End If
                
                
                    '@---------------------
                    '@　分割予約2の設定
                    '@---------------------
        '            .strDivedeLotID2 = lblLotID2.Caption                    '分割予約2ﾛｯﾄID
                    .lngDivedewfMapListCnt2 = CInt(lblWFNum2.Text)         '分割予約2ｽﾛｯﾄﾏｯﾌﾟ
                    
                    '@分割予約2ｽﾛｯﾄﾏｯﾌﾟ
                    llngSCnt = 0
                    
                    '@分割予約2ﾛｯﾄのWF枚数が0以外か
                    If lblWFNum2.Text <> 0 Then
                        
                        '@領域確保
                        If .typDivedeWfMapList2 Is Nothing Then
                            .typDivedeWfMapList2 = New List(Of DivideWFMap)
                        End If
                        Dim typDivedeWfMapLis2Tmp As New DivideWFMap

                        For llngLoopCnt = CMlngSlotMap1 To CMlngSlotRow - 1
                            
                            '@分割予約2ｽﾛｯﾄﾏｯﾌﾟのWFIDがNULL以外か
                            If vsfSlotMap2.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                
                                '@分割予約2ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄﾎﾟｼﾞｼｮﾝ格納
                                typDivedeWfMapLis2Tmp.strSlotPosition _
                                    = vsfSlotMap2.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColNo)
                                
                                '@分割予約2ｽﾛｯﾄﾏｯﾌﾟのWFID格納
                                typDivedeWfMapLis2Tmp.strWfId _
                                    = vsfSlotMap2.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID)
                                
                                .typDivedeWfMapList2.Add(typDivedeWfMapLis2Tmp)

                                '@ｶｳﾝﾄｱｯﾌﾟ
                                llngSCnt = llngSCnt + 1
                            End If
                        Next llngLoopCnt
                    End If
                
                    .strToCarrierID1 = txtToCarrierID1.Text                 '分割予約1ｷｬﾘｱID
                    .strToCarrierID2 = txtToCarrierID2.Text                 '分割予約2ｷｬﾘｱID
                End If
                
                
                '@**************************************
                '@　①分割予約1ｽﾛｯﾄﾏｯﾌﾟ：WF存在
                '@　②分割予約2ｽﾛｯﾄﾏｯﾌﾟ：WF存在しない　か
                '@**************************************
                If lblnDivideFlag1 = True And lblnDivideFlag2 = False Then
                    
                    '@---------------------
                    '@　分割予約1の設定
                    '@---------------------
                    .strDivedeLotID = lblLotID.Text                      '分割予約1ﾛｯﾄID
                    .lngDivedewfMapListCnt = CInt(lblWFNum1.Text)        '分割予約1ｽﾛｯﾄﾏｯﾌﾟ
                
                    '@分割予約1ｽﾛｯﾄﾏｯﾌﾟ
                    llngSCnt = 0
                    
                    '@分割予約1ﾛｯﾄのWF枚数が0以外か
                    If lblWFNum1.Text <> 0 Then
                        
                        '@領域確保
                        If .typDivedeWfMapList Is Nothing Then
                            .typDivedeWfMapList = New List(Of DivideWFMap)
                        End If
                        Dim typDivedeWfMapListTmp As New DivideWFMap

                        For llngLoopCnt = CMlngSlotMap1 To CMlngSlotRow - 1
                        
                            '@分割予約1ｽﾛｯﾄﾏｯﾌﾟのWFIDがNULL以外か
                            If vsfSlotMap1.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                
                                '@分割予約1ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄﾎﾟｼﾞｼｮﾝ格納
                                typDivedeWfMapListTmp.strSlotPosition _
                                    = vsfSlotMap1.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColNo)
                                
                                '@分割予約1ｽﾛｯﾄﾏｯﾌﾟのWFID格納
                                typDivedeWfMapListTmp.strWfId _
                                    = vsfSlotMap1.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID)
                                
                                .typDivedeWfMapList.Add(typDivedeWfMapListTmp)

                                '@ｶｳﾝﾄｱｯﾌﾟ
                                llngSCnt = llngSCnt + 1
                            End If
                        Next llngLoopCnt
                    End If
                
                    .strDivedeLotID2 = vbNullString                         '分割予約2ﾛｯﾄID
                    .lngDivedewfMapListCnt2 = 0                             '分割予約2ｽﾛｯﾄﾏｯﾌﾟ
                    
                    '@領域解放(念のため)
                    If .typDivedeWfMapList2 Is Nothing Then
                        .typDivedeWfMapList2 = New List(Of DivideWFMap)
                    Else
                        .typDivedeWfMapList2.Clear
                    End If

                    .strToCarrierID1 = txtToCarrierID1.Text                 '分割予約1ｷｬﾘｱID
                    .strToCarrierID2 = vbNullString                         '分割予約2ｷｬﾘｱID
                End If
                
                '@**************************************
                '@　①分割予約1ｽﾛｯﾄﾏｯﾌﾟ：WF存在しない
                '@　②分割予約2ｽﾛｯﾄﾏｯﾌﾟ：WF存在　か
                '@**************************************
                If lblnDivideFlag2 = True And lblnDivideFlag1 = False Then
                    
                    .strDivedeLotID = lblLotID.Text                      '分割元ﾛｯﾄID
                    .lngDivedewfMapListCnt = CInt(lblWFNum2.Text)        '分割予約2ｽﾛｯﾄﾏｯﾌﾟ
                
                    '@分割予約2ｽﾛｯﾄﾏｯﾌﾟ
                    llngSCnt = 0
                    
                    '@分割予約2ﾛｯﾄのWF枚数が0以外か
                    If lblWFNum2.Text <> 0 Then
                        
                        '@領域確保
                        If .typDivedeWfMapList Is Nothing Then
                            .typDivedeWfMapList = New List(Of DivideWFMap)
                        End If
                        Dim typDivedeWfMapListTmp As New DivideWFMap

                        For llngLoopCnt = CMlngSlotMap1 To CMlngSlotRow - 1
                        
                            '@分割予約2ｽﾛｯﾄﾏｯﾌﾟのWFIDがNULL以外か
                            If vsfSlotMap2.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                                
                                '@分割予約2ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄﾎﾟｼﾞｼｮﾝ格納
                                typDivedeWfMapListTmp.strSlotPosition _
                                    = vsfSlotMap2.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColNo)
                                
                                '@分割予約2ｽﾛｯﾄﾏｯﾌﾟのWFID格納
                                typDivedeWfMapListTmp.strWfId _
                                    = vsfSlotMap2.GetData(CMlngSlotRow - llngLoopCnt, CMlngvsfSlotMapColWFID)
                                
                                .typDivedeWfMapList.Add(typDivedeWfMapListTmp)

                                '@ｶｳﾝﾄｱｯﾌﾟ
                                llngSCnt = llngSCnt + 1
                            End If
                        Next llngLoopCnt
                    End If
                
                    .strDivedeLotID2 = vbNullString                         '分割予約2ﾛｯﾄID
                    .lngDivedewfMapListCnt2 = 0                             '分割予約2ｽﾛｯﾄﾏｯﾌﾟ
                    
                    '@領域解放(念のため)
                    If .typDivedeWfMapList2 Is Nothing Then
                        .typDivedeWfMapList2 = New List(Of DivideWFMap)
                    Else
                        .typDivedeWfMapList2.Clear
                    End If
                
                    .strToCarrierID1 = txtToCarrierID2.Text                 '分割予約1ｷｬﾘｱID
                    .strToCarrierID2 = vbNullString                         '分割予約2ｷｬﾘｱID
                End If
                
                .strEmpID = pstrUserID                                      '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate                       '最終更新日時
                .strSbID = pstrSBID                                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrlot_asmdivideVer                          'ﾒｯｾｰｼﾞﾊﾊﾞｰｼﾞｮﾝ
            End With

            '@**************************************
            '@　①分割予約1ｽﾛｯﾄﾏｯﾌﾟ：WF存在しない
            '@　②分割予約2ｽﾛｯﾄﾏｯﾌﾟ：WF存在しない　か
            '@**************************************
            If lblnDivideFlag1 = False And lblnDivideFlag2 = False Then
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003R)
                '@"分割先ウエハマップ情報が設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRegistDataSet_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLumpDivide_Proc
    '機　能：一括分割処理
    '引　数：llngMapJudgeFlag   ：分割元用判定ﾌﾗｸﾞ(1:№05-01にWFあり、2:№10-06にWFあり、3:№10-06&05-01にWFあり)
    '　　　：lstrCallFunction   ：呼び元Function
    '戻り値：なし
    '作成日：2008/04/09 (Wed) 10:27:08 N.Kojima
    '更新日：2008/04/09 (Wed) 10:27:08
    '備　考：
    Private Sub prvLumpDivide_Proc(ByVal llngMapJudgeFlag As Integer, _
                                   ByVal lstrCallFunction As String)

        Dim llngCnt                 As Integer          'ｶｳﾝﾀ
        Dim lblnMap1JudgeFlag       As Boolean          '分割予約1用判定ﾌﾗｸﾞ(True:WFあり、Flase:WFなし)
        Dim lblnMap2JudgeFlag       As Boolean          '分割予約2用判定ﾌﾗｸﾞ(True:WFあり、Flase:WFなし)
        Dim ltypSlotPosition1       As List(Of SlotPosition)     '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報格納用(#01-05)
        Dim ltypSlotPosition2       As List(Of SlotPosition)     '移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報格納用(#06-10)

        Try
                
            '@分割元ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄ№21～25分ﾙｰﾌﾟ
            For llngCnt = 1 To CMlngSlotMapRowS - 21
                
                '@ｽﾛｯﾄ№21～25にWFが存在している場合
                If vsfSlotMap.GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001J)
                    '@"<TRM1JW>$$元キャリアのスロット№21～№25にウエハが存在しています。
                    '@ $[編成用手動分割]ボタンにて手動で編成するか、$またはウエハの位置を変更してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@編成用手動分割ﾎﾞﾀﾝが有効か
                    If cmdManual.Enabled = True Then
                        Call pubSetFocus(cmdManual)
                    End If
                    
                    Exit Sub
                End If
            Next
            
            '@呼び元Functionが"一括分割#01-10ﾎﾞﾀﾝClick処理"か
            If lstrCallFunction = CMstrCmdLumpDivideWF1Click Then
            
                '@移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報を処理用の構造体にｺﾋﾟｰ
                ltypSlotPosition1 = mtypSlotPosition1
                ltypSlotPosition2 = mtypSlotPosition2
            Else
                '@呼び元Functionが"一括分割#11-20ﾎﾞﾀﾝClick処理"の場合
                
                '@移載/分割元ｽﾛｯﾄﾏｯﾌﾟ情報を処理用の構造体にｺﾋﾟｰ
                ltypSlotPosition1 = mtypSlotPosition3
                ltypSlotPosition2 = mtypSlotPosition4
            End If
            
            '@移載/分割ﾌﾗｸﾞが"1:移載"か
            If mlngFormationFlag = CMlngTransfer Then
                
                '@=======================
                '@　分割予約1、2ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞの設定処理
                '@=======================
                Call prvDivideVsfSlotMap_Set(ltypSlotPosition1, _
                                             ltypSlotPosition2, _
                                             lstrCallFunction)
                
                '@分割予約1用判定ﾌﾗｸﾞの初期化
                lblnMap1JudgeFlag = False
                
                '@分割予約2のｷｬﾘｱIDとﾎﾞﾀﾝを無効にする
                txtToCarrierID2.Enabled = False             '分割ｷｬﾘｱ2
                cmdCarrierSelect2.Enabled = False           '空きｷｬﾘｱ選択ﾎﾞﾀﾝ2
                
                '@分割予約1ｽﾛｯﾄﾏｯﾌﾟの行数分ﾙｰﾌﾟ
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                
                    '@分割予約1ｽﾛｯﾄﾏｯﾌﾟにて、ｽﾛｯﾄにWFIDが存在するか
                    If vsfSlotMap1.GetData(llngCnt, CMlngvsfSlotMapColWFID) = vbNullString Then
                        '@WFIDが存在しないｽﾛｯﾄは、背景色をｸﾞﾚｰにする
                        Dim newStyle As CellStyle = vsfSlotMap1.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                        '@↓2019/10/01 (Tue) 16:23:31 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        'Dim cellRange As CellRange = vsfSlotMap1.GetCellRange(llngCnt, CMlngvsfSlotMapColWFID)
                        Dim cellRange As CellRange = vsfSlotMap1.GetCellRange(llngCnt, CMlngvsfSlotMapColWFID, llngCnt, CMlngvsfSlotMapColGRB)
                        '@↑2019/10/01 (Tue) 16:23:31 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        cellRange.Style = newStyle
                    Else
                        '@WFIDが存在するｽﾛｯﾄは、背景色を白にする
                        Dim newStyle As CellStyle = vsfSlotMap1.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = SystemColors.Window
                        'Dim cellRange As CellRange = vsfSlotMap1.GetCellRange(llngCnt, CMlngvsfSlotMapColWFID)
                        Dim cellRange As CellRange = vsfSlotMap1.GetCellRange(llngCnt, CMlngvsfSlotMapColWFID, llngCnt, CMlngvsfSlotMapColGRB)
                        cellRange.Style = newStyle
                        
                        '@↓2019/10/01 (Tue) 16:23:45 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        Dim newStyleGRB As CellStyle = vsfSlotMap1.Styles.Add("GRBColor" + llngCnt.ToString)
                        newStyleGRB.BackColor = pubGRBBackColor(vsfSlotMap1.GetData(llngCnt, CMlngvsfSlotMapColGRB), Color.White)
                        Dim cellRangeGRB As CellRange = vsfSlotMap1.GetCellRange(llngCnt, CMlngvsfSlotMapColGRB)
                        cellRangeGRB.Style = newStyleGRB
                        '@↑2019/10/01 (Tue) 16:23:45 Y.Yoneyama 「.Netへ反映未」 **************************************************


                        '@存在した場合、分割予約1用判定ﾌﾗｸﾞに"True:WF存在"をｾｯﾄ
                        lblnMap1JudgeFlag = True
                        
                        '@分割予約1のｷｬﾘｱIDとﾎﾞﾀﾝを有効にする
                        txtToCarrierID1.Enabled = True              '分割ｷｬﾘｱ1
                        cmdCarrierSelect1.Enabled = True            '空きｷｬﾘｱ選択ﾎﾞﾀﾝ1
                    End If
                Next
                
                '@=======================
                '@　ｿｰﾄ前処理
                '@=======================
                Call pubVsfBeforeSort(vsfSlotMap1, CMlngvsfSlotMapColWFID)

                '@分割予約1用判定ﾌﾗｸﾞが"False:WFなし"か
                If lblnMap1JudgeFlag = False Then
                    '@分割予約1ｽﾛｯﾄﾏｯﾌﾟの上下ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                    cmdUP1.Enabled = False
                    cmdDown1.Enabled = False
                Else
                    '@分割予約1ｽﾛｯﾄﾏｯﾌﾟの上ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                    cmdUP1.Enabled = True
                End If
            Else
                '@移載/分割ﾌﾗｸﾞが"1:移載"以外か
                
                '@=======================
                '@　分割予約1、2ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞの設定処理
                '@=======================
                Call prvDivideVsfSlotMap_Set(ltypSlotPosition1, _
                                             ltypSlotPosition2, _
                                             lstrCallFunction)
                
                '@判定ﾌﾗｸﾞの初期化
                lblnMap1JudgeFlag = False           '分割予約1用
                lblnMap2JudgeFlag = False           '分割予約2用
                
                '@分割予約1、2ｽﾛｯﾄﾏｯﾌﾟの行数分ﾙｰﾌﾟ
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    
                    '@分割予約1ｽﾛｯﾄﾏｯﾌﾟにて、ｽﾛｯﾄにWFIDが存在するか
                    If vsfSlotMap1.GetData(llngCnt, CMlngvsfSlotMapColWFID) = vbNullString Then
                        '@背景色をｸﾞﾚｰにする
                        Dim newStyle As CellStyle = vsfSlotMap1.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                        '@↓2019/10/01 (Tue) 16:24:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        'Dim cellRange As CellRange = vsfSlotMap1.GetCellRange(llngCnt, CMlngvsfSlotMapColWFID)
                        Dim cellRange As CellRange = vsfSlotMap1.GetCellRange(llngCnt, CMlngvsfSlotMapColWFID, llngCnt, CMlngvsfSlotMapColGRB)
                        '@↑2019/10/01 (Tue) 16:24:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        cellRange.Style = newStyle

                    Else
                        '@背景色を白にする
                        Dim newStyle As CellStyle = vsfSlotMap1.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = SystemColors.Window
                        Dim cellRange As CellRange = vsfSlotMap1.GetCellRange(llngCnt, CMlngvsfSlotMapColWFID, llngCnt, CMlngvsfSlotMapColGRB)
                        cellRange.Style = newStyle
                        
                        '@↓2019/10/01 (Tue) 16:24:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        Dim newStyleGRB As CellStyle = vsfSlotMap1.Styles.Add("GRBColor" + llngCnt.ToString)
                        newStyleGRB.BackColor = pubGRBBackColor(vsfSlotMap1.GetData(llngCnt, CMlngvsfSlotMapColGRB), Color.White)
                        Dim cellRangeGRB As CellRange = vsfSlotMap1.GetCellRange(llngCnt, CMlngvsfSlotMapColGRB)
                        cellRangeGRB.Style = newStyleGRB
                        '@↑2019/10/01 (Tue) 16:24:20 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        '@存在した場合、分割予約1用判定ﾌﾗｸﾞに"True:WF存在"をｾｯﾄ
                        lblnMap1JudgeFlag = True
                        
                        '@分割予約1のｷｬﾘｱIDとﾎﾞﾀﾝを有効にする
                        txtToCarrierID1.Enabled = True      '分割ｷｬﾘｱ1
                        cmdCarrierSelect1.Enabled = True    '空きｷｬﾘｱ選択ﾎﾞﾀﾝ1
                    End If
                    
                    '@分割予約2ｽﾛｯﾄﾏｯﾌﾟにて、ｽﾛｯﾄにWFIDが存在するか
                    If vsfSlotMap2.GetData(llngCnt, CMlngvsfSlotMapColWFID) = vbNullString Then
                        '@背景色をｸﾞﾚｰにする
                        Dim newStyle As CellStyle = vsfSlotMap2.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                        '@↓2019/10/01 (Tue) 16:24:35 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        'Dim cellRange As CellRange = vsfSlotMap2.GetCellRange(llngCnt, CMlngvsfSlotMapColWFID)
                        Dim cellRange As CellRange = vsfSlotMap2.GetCellRange(llngCnt, CMlngvsfSlotMapColWFID, llngCnt, CMlngvsfSlotMapColGRB)
                        '@↑2019/10/01 (Tue) 16:24:35 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        cellRange.Style = newStyle

                    Else
                        '@背景色を白にする
                        Dim newStyle As CellStyle = vsfSlotMap2.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = SystemColors.Window
                        Dim cellRange As CellRange = vsfSlotMap2.GetCellRange(llngCnt, CMlngvsfSlotMapColWFID, llngCnt, CMlngvsfSlotMapColGRB)
                        cellRange.Style = newStyle
                        
                        '@↓2019/10/01 (Tue) 16:24:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        Dim newStyleGRB As CellStyle = vsfSlotMap2.Styles.Add("GRBColor" + llngCnt.ToString)
                        newStyleGRB.BackColor = pubGRBBackColor(vsfSlotMap2.GetData(llngCnt, CMlngvsfSlotMapColGRB), Color.White)
                        Dim cellRangeGRB As CellRange = vsfSlotMap2.GetCellRange(llngCnt, CMlngvsfSlotMapColGRB)
                        cellRangeGRB.Style = newStyleGRB
                        '@↑2019/10/01 (Tue) 16:24:48 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        '@存在した場合、分割予約2用判定ﾌﾗｸﾞに"True:WF存在"をｾｯﾄ
                        lblnMap2JudgeFlag = True
                        
                        '@分割予約2のｷｬﾘｱIDとﾎﾞﾀﾝを有効にする
                        txtToCarrierID2.Enabled = True      '分割ｷｬﾘｱ2
                        cmdCarrierSelect2.Enabled = True    '空きｷｬﾘｱ選択ﾎﾞﾀﾝ2
                    End If
                Next
                
                '@=======================
                '@　ｿｰﾄ前処理
                '@=======================
                Call pubVsfBeforeSort(vsfSlotMap1, CMlngvsfSlotMapColWFID)      '分割予約1
                Call pubVsfBeforeSort(vsfSlotMap2, CMlngvsfSlotMapColWFID)      '分割予約2
            
                '@分割予約1用判定ﾌﾗｸﾞが"False:WFなし"か
                If lblnMap1JudgeFlag = False Then
                    '@分割予約1ｽﾛｯﾄﾏｯﾌﾟの上下ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                    cmdUP1.Enabled = False
                    cmdDown1.Enabled = False
                Else
                    '@分割予約1ｽﾛｯﾄﾏｯﾌﾟの上ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                    cmdUP1.Enabled = True
                End If

                '@分割予約2用判定ﾌﾗｸﾞが"False:WFなし"か
                If lblnMap2JudgeFlag = False Then
                    '@分割予約2ｽﾛｯﾄﾏｯﾌﾟの上下ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                    cmdUP2.Enabled = False
                    cmdDown2.Enabled = False
                Else
                    '@分割予約2ｽﾛｯﾄﾏｯﾌﾟの上ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                    cmdUP2.Enabled = True
                End If

            End If
            
            '@各種ﾎﾞﾀﾝの制御を行なう
            cmdClear.Enabled = True             '全部取消ﾎﾞﾀﾝ
            cmdManual.Enabled = False           '編成用手動分割ﾎﾞﾀﾝ
            cmdLumpDivideWF1.Enabled = False    '一括分割#01-10ﾎﾞﾀﾝ
            cmdLumpDivideWF2.Enabled = False    '一括分割#11-20ﾎﾞﾀﾝ
            
            '@分割元ﾛｯﾄのWF枚数が10枚以下か
            If CInt(lblWfNum.Text) <= 20 Then
            
                '@分割元ﾛｯﾄのｽﾛｯﾄﾏｯﾌﾟのWFIDをｸﾞﾚｰ表記にする
                With vsfSlotMap
                
                    '@呼び元Functionが"一括分割#01-10ﾎﾞﾀﾝClick処理"か
                    If lstrCallFunction = CMstrCmdLumpDivideWF1Click Then
                        
                        '@分割元ｽﾛｯﾄﾏｯﾌﾟ#01-10の文字色をｸﾞﾚｰにする
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseColor")
                        newStyle.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                        Dim cellRange As CellRange = .GetCellRange(CMlngSlotMap16, CMlngvsfSlotMapColWFID, CMlngCarrierRowS, CMlngvsfSlotMapColBNo)
                        cellRange.Style = newStyle

                        '@↓2019/10/01 (Tue) 15:32:49 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        '@分割元ｽﾛｯﾄﾏｯﾌﾟ#01-10の文字色をｸﾞﾚｰにする
                        For llngCnt = CMlngSlotMap16 To .Rows.Count - 1
                            Dim newStyleGRB As CellStyle = .Styles.Add("GRBColor" + llngCnt.ToString)
                            newStyleGRB.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                            Dim cellRangeGRB As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColGRB)
                            cellRangeGRB.Style = newStyleGRB
                        Next
                        '@↑2019/10/01 (Tue) 15:32:49 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    Else
                        '@呼び元Functionが"一括分割#11-20ﾎﾞﾀﾝClick処理"の場合
                        
                        '@分割元ｽﾛｯﾄﾏｯﾌﾟ#11-20の文字色をｸﾞﾚｰにする
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseColor")
                        newStyle.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                        Dim cellRange As CellRange = .GetCellRange(CMlngSlotMap5, CMlngvsfSlotMapColWFID, CMlngSlotMap15, CMlngvsfSlotMapColBNo)
                        cellRange.Style = newStyle

                        '@↓2019/10/01 (Tue) 15:32:49 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        '@分割元ｽﾛｯﾄﾏｯﾌﾟ#11-20の文字色をｸﾞﾚｰにする
                        For llngCnt = CMlngSlotMap5 To CMlngSlotMap15
                            Dim newStyleGRB As CellStyle = .Styles.Add("GRBColor" + llngCnt.ToString)
                            newStyleGRB.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                            Dim cellRangeGRB As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColGRB)
                            cellRangeGRB.Style = newStyleGRB
                        Next
                        '@↑2019/10/01 (Tue) 15:32:49 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    End If
                End With
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝ設定
                cmdUP.Enabled = True        '分割元ｽﾛｯﾄﾏｯﾌﾟ上ｽｸﾛｰﾙﾎﾞﾀﾝ
                cmdDown.Enabled = False     '分割元ｽﾛｯﾄﾏｯﾌﾟ下ｽｸﾛｰﾙﾎﾞﾀﾝ
            End If
            
            '@=======================
            '@　WF枚数をｶｳﾝﾄし、ﾗﾍﾞﾙに表示する処理
            '@=======================
            Call prvVsfSlotMap_Cal()
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdRegistControl_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLumpDivide_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2019/10/02 (Wed) 10:23:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
    '関数名：prvblnGRBWafer_Chk
    '機　能：GRBのWF混在ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:OK/False:NG
    '作成日：2019/10/02 (Wed) 10:22:39 Y.Yoneyama
    '更新日：2019/10/02 (Wed) 10:22:39 Y.Yoneyama
    '備　考：
    Private Function prvblnGRBWafer_Chk() As Boolean
    
        Dim llngCnt         As Integer
        Dim llngFirstRow    As Integer
    
        Try

            '@戻り値の初期化
            prvblnGRBWafer_Chk = False
            
            '@分割ｽﾛｯﾄ1
            With vsfSlotMap1
    
                '@初期化
                llngFirstRow = 0
        
                For llngCnt = 1 To .Rows.Count - 1
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
            
                        '@FirstRow値(基準)
                        If llngFirstRow = 0 Then
                            llngFirstRow = llngCnt
                
                        Else
                            '@最初のROW値を比較
                            If .GetData(llngFirstRow, CMlngvsfSlotMapColGRB) <> _
                                .GetData(llngCnt, CMlngvsfSlotMapColGRB) Then
                    
                                '@表示ﾒｯｾｰｼﾞ変換
                                '@"<TRM172W>$$GRB設定のウエハが混在しています。$設定を見直してください。"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0172)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                                '@分割予約1ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(txtToCarrierID1)
                                Exit Function
                            End If
                        End If
                
                    End If
                Next
            End With
    
            '@分割ｽﾛｯﾄ2
            With vsfSlotMap2
    
                '@初期化
                llngFirstRow = 0
        
                For llngCnt = 1 To .Rows.Count - 1
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
            
                        '@FirstRow値(基準)
                        If llngFirstRow = 0 Then
                            llngFirstRow = llngCnt
                
                        Else
                            '@最初のROW値を比較
                            If .GetData(llngFirstRow, CMlngvsfSlotMapColGRB) <> _
                                .GetData(llngCnt, CMlngvsfSlotMapColGRB) Then
                    
                                '@表示ﾒｯｾｰｼﾞ変換
                                '@"<TRM172W>$$GRB設定のウエハが混在しています。$設定を見直してください。"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0172)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                                '@分割予約1ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(txtToCarrierID2)
                                Exit Function
                            End If
                        End If
                
                    End If
                Next
            End With
    
            prvblnGRBWafer_Chk = True
    
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnGRBWafer_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try

    End Function
    '@↑2019/10/02 (Wed) 10:23:13 Y.Yoneyama 「.Netへ反映未」 **************************************************

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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraOrigin.Paint, fraPartition1.Paint, fraPartition2.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfSlotMap.BeforeDoubleClick, vsfSlotMap1.BeforeDoubleClick, vsfSlotMap2.BeforeDoubleClick

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
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
                                                                        cmdLumpDivideWF2.Enter, 
                                                                        cmdLumpDivideWF1.Enter, 
                                                                        cmdManual.Enter, 
                                                                        cmdCarrierSelect2.Enter, 
                                                                        cmdDown2.Enter,  
                                                                        cmdUP2.Enter,  
                                                                        vsfSlotMap2.Enter,  
                                                                        txtToCarrierID2.Enter,  
                                                                        cmdLump.Enter,  
                                                                        cmdCarrierSelect1.Enter, 
                                                                        cmdDown1.Enter,  
                                                                        cmdUP1.Enter,  
                                                                        vsfSlotMap1.Enter,  
                                                                        txtToCarrierID1.Enter,  
                                                                        cmdClear.Enter,  
                                                                        cmdRegist.Enter,  
                                                                        cmdClose.Enter,  
                                                                        cmdDown.Enter,  
                                                                        cmdUP.Enter,  
                                                                        vsfSlotMap.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name,cmdCarrierSelect1.Name,cmdCarrierSelect2.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
