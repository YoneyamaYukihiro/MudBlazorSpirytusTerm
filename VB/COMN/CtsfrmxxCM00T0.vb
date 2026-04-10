'ﾌｧｲﾙ名：xxCM00T0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：CFキャリア一覧／TFT/CFロット紐付き情報　メインフォーム
'作成日：2005/05/17 (Tue) 10:03:34 N.Kasai
'更新日：2014/12/02 (Tue) 10:17:59 H.Hayashi
'備　考：
'　　　：★作業開始、TPAL貼り合わせ登録からの起動の場合は「CFｷｬﾘｱ一覧」
'　　　：★装置別ﾛｯﾄ一覧、装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧、工程別ﾛｯﾄ一覧からの起動の場合は「TFT/CFﾛｯﾄ紐付き情報」
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00T0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00T0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00T0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00T0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00T0)
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
    '======================================Private==========================================
    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrcarrcflist__Ver                  As String = "02.00"                 'CFｷｬﾘｱ一覧
    Private Const CMstrlot_jbatchconnectedinfoVer       As String = "01.01"                 'TFT/CFﾛｯﾄ紐付き情報取得
    Private Const CMstrlot_jbatchconnectedinfo2Ver      As String = "01.01"                 'TFT/CFﾛｯﾄ紐付き情報取得2
    Private Const CMstrasm_curcflotinfoVer              As String = "01.00"                 '現在のCFロット情報の取得

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyCM00T0          'ﾛｰｶﾙ機能ID

    '@CFキャリア一覧の場合のｸﾞﾘｯﾄﾞ項目設定
    Private Const CMvsfLotCols                          As Integer = 9                      'CFキャリア一覧の場合のｶﾗﾑ数

    '@vsfLotListの定数宣言(ｶﾗﾑ)
    Private Const CMvsfLotColNo                         As Integer = 0                      '№
    Private Const CMvsfLotColCarrierID                  As Integer = 1                      'ｷｬﾘｱID
    Private Const CMvsfLotColLotID                      As Integer = 2                      'ﾛｯﾄID
    Private Const CMvsfLotColFlowClass                  As Integer = 3                      '種別
    Private Const CMvsfLotColPdID                       As Integer = 4                      '機種
    Private Const CMvsfLotColWfNum                      As Integer = 5                      'WF枚数
    Private Const CMvsfLotColChipNum                    As Integer = 6                      'ﾁｯﾌﾟ
    Private Const CMvsfLotColPriority                   As Integer = 7                      '優先度
    Private Const CMvsfLotColOdfReserveInfo             As Integer = 8                      'ODF予約情報


    '@vsfLotListの定数宣言(表示幅)
    Private Const CMvsfLotColWNo                        As Integer = 34                     '№
    Private Const CMvsfLotColWCarrierID                 As Integer = 117                    'ｷｬﾘｱID
    Private Const CMvsfLotColWLotID                     As Integer = 137                    'ﾛｯﾄID
    Private Const CMvsfLotColWFlowClass                 As Integer = 42                     '種別
    Private Const CMvsfLotColWPdID                      As Integer = 42                     '機種
    Private Const CMvsfLotColWWfNum                     As Integer = 76                     'WF枚数
    Private Const CMvsfLotColWChipNum                   As Integer = 76                     'ﾁｯﾌﾟ
    Private Const CMvsfLotColWPriority                  As Integer = 42                     '優先度
    Private Const CMvsfLotColWOdfReserveInfo            As Integer = 200                    'ODF予約情報

    '@vsfLotListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMvsfLotColTNo                        As String = "№"                    '№
    Private Const CMvsfLotColTCarrierID                 As String = "キャリアID"            'ｷｬﾘｱID
    Private Const CMvsfLotColTLotID                     As String = "ロットID"              'ﾛｯﾄID
    Private Const CMvsfLotColTFlowClass                 As String = "種別"                  '種別
    Private Const CMvsfLotColTPdID                      As String = "機種"                  '機種
    Private Const CMvsfLotColTWfNum                     As String = "WF枚数"                'WF枚数
    Private Const CMvsfLotColTChipNum                   As String = "チップ"                'ﾁｯﾌﾟ
    Private Const CMvsfLotColTPriority                  As String = "優"                    '優先度
    Private Const CMvsfLotColTOdfReserveInfo            As String = "予約情報"

    '@↓2013/03/13 (Wed) 16:39:42 T.Oide **************************************************
    '@TFT/CFロット紐付き情報の場合のｸﾞﾘｯﾄﾞ項目設定
    Private Const CMlngvsfTftCfCols                     As Integer = 10             'TFT/CFロット紐付き情報の場合のｶﾗﾑ数

    '@ｸﾞﾘｯﾄﾞの列設定
    Private Const CMlngvsfTftCfBatchClass               As Integer = 0              '装置種別
    Private Const CMlngvsfTftCfWPID                     As Integer = 1              '号機
    Private Const CMlngvsfTftCfLOTID                    As Integer = 3              'ﾛｯﾄID
    Private Const CMlngvsfTftCfWFID                     As Integer = 4              'WFID
    Private Const CMlngvsfTftCfTPLOT1                   As Integer = 5              'TPロット1
    Private Const CMlngvsfTftCfTPLOT2                   As Integer = 6              'TPロット2
    Private Const CMlngvsfTftCfChipNum                  As Integer = 7              'チップ
    Private Const CMlngvsfTftCfStepID                   As Integer = 8              '小工程
    Private Const CMlngvsfTftCfBatchID                  As Integer = 2              'ﾊﾞｯﾁID
    Private Const CMlngvsfTftCfTpalClass                As Integer = 9              '貼合制限

    '@ｸﾞﾘｯﾄﾞの幅設定
    Private Const CMlngvsfTftCfBatchClassW              As Integer = 91             '装置種別
    Private Const CMlngvsfTftCfWPIDW                    As Integer = 42             '号機
    Private Const CMlngvsfTftCfLOTIDW                   As Integer = 120            'ﾛｯﾄID
    Private Const CMlngvsfTftCfWFIDW                    As Integer = 90             'WFID
    Private Const CMlngvsfTftCfTPLOT1W                  As Integer = 120            'TPロット1
    Private Const CMlngvsfTftCfTPLOT2W                  As Integer = 120            'TPロット2
    Private Const CMlngvsfTftCfChipNumW                 As Integer = 60             'チップ
    Private Const CMlngvsfTftCfStepIDW                  As Integer = 179            '小工程
    Private Const CMlngvsfTftCfBatchIDW                 As Integer = 76             'ﾊﾞｯﾁID
    Private Const CMlngvsfTftCfTpalClassW               As Integer = 97             '貼合制限

    '@ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ設定
    Private Const CMstrvsfTftCfBatchClassT              As String = "装置種別"
    Private Const CMstrvsfTftCfWPIDT                    As String = "号機"
    Private Const CMstrvsfTftCfLOTIDT                   As String = "ロットID"
    Private Const CMstrvsfTftCfWFIDT                    As String = "WFID"
    Private Const CMstrvsfTftCfTPLOT1T                  As String = "TPロット1"
    Private Const CMstrvsfTftCfTPLOT2T                  As String = "TPロット2"
    Private Const CMstrvsfTftCfChipNumT                 As String = "チップ"
    Private Const CMstrvsfTftCfStepIDT                  As String = "小工程"
    Private Const CMstrvsfTftCfBatchIDT                 As String = "バッチID"
    Private Const CMstrvsfTftCfTpalClassT               As String = "貼合制限"
    '@↑2013/03/13 (Wed) 16:39:42 T.Oide **************************************************


    '@その他ｸﾞﾘｯﾄの定数
    Private Const CMvsfLotListCols                      As Integer = 11                     '最大ｶﾗﾑ数
    Private Const CMvsfLotListTRow                      As Integer = 0                      'ﾀｲﾄﾙ行
    Private Const CMvsfHFontSize                        As Integer = 12                     'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMvsfLotListHdHeight                  As Integer = 27                     '行の高さ(ﾍｯﾀﾞｰのみ)
    Private Const CMvsfLotListHeight                    As Integer = 43                     '行の高さ
    Private Const CMlngvsfPageRows                      As Integer = 12                     '頁表示最大行

    '@↓2013/03/15 (Fri) 15:16:43 T.Oide **************************************************
    '@その他
    Private Const CMstrKuten                            As String = "､"                    'WF№表示用
    Private Const CMstrJyoucyaku                        As String = "斜方蒸着"             '斜方蒸着
    Private Const CMstrHyoumen                          As String = "表面処理"             '表面処理
    Private Const CMstrKakoL                            As String = "【"
    Private Const CMstrKakoR                            As String = "】"
    Private Const CMstrTpalJBatchName                   As String = "[蒸]ﾊﾞｯﾁ"              '蒸着ﾊﾞｯﾁ貼合
    Private Const CMstrTpalJLRName                      As String = "[蒸]左右"              '蒸着左右側貼合
    Private Const CMstrTpalJBatchLRName                 As String = "[蒸](ﾊﾞｯﾁ＋左右)"      '蒸着ﾊﾞｯﾁ+左右側貼合
    Private Const CMstrTpalHBatchName                   As String = "[表]ﾊﾞｯﾁ"              '表面ﾊﾞｯﾁ貼合
    Private Const CMstrLOT_EVENT_END                    As String = "90"                    '流動終了ｲﾍﾞﾝﾄ
    Private Const CMstrLOT_EVENT_END_NAME               As String = "【流動終了】"          '流動終了ｲﾍﾞﾝﾄ
    '@↑2013/03/15 (Fri) 15:16:43 T.Oide **************************************************

    '@ﾚｽﾎﾟﾝｽ用定数
    Private Const CMstrFormName                         As String = "frmxxCM00T0"           '自ﾌｫｰﾑ名
    Private Const CMstrCmdNowListClick                  As String = "cmdNowList_Click"      'ｲﾍﾞﾝﾄ名称(最新ﾎﾞﾀﾝ)

    'ODF貼り合せ予約内容
    Private Const CMstrCFReserveOK                      As String = "○"
    Private Const CMstrCFReserveNG                      As String = "×"                   
    Private Const CMstrCFReservePartialOK               As String = "△ 一部予約WFなし"    

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用
    Private mblnNowListClick                            As Boolean                          '最新取得結果判定ﾌﾗｸﾞ(True：取得成功、False：初期値orﾌｫｰﾑﾛｰﾄﾞ時に最新取得失敗)

    Private mtypCFListRec                               As CFListRec                        'CFﾘｽﾄ要求格納構造体
    Private mtypCFListAns                               As CFListAns                        'CFﾘｽﾄ応答格納構造体
    Private mtypJBatchConnectedInfoRec                  As JBatchConnectedInfoRec           'TFT/CFﾛｯﾄ紐付き情報要求格納構造体
    Private mtypJBatchConnectedInfoAns                  As JBatchConnectedInfoAns           'TFT/CFﾛｯﾄ紐付き情報応答格納構造体
    Private mtypJBatchConnectedInfoAns2                 As JBatchConnectedInfoAns2          'TFT/CFﾛｯﾄ紐付き情報応答格納構造体2

    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ


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

        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfLotList, cmdUp, cmdDown, cmdLeft, cmdRight)

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
    '作成日：2005/05/19 (Thu) 09:31:26 N.Kasai
    '更新日：2013/03/14 (Thu) 10:24:07 T.Oide
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
    '　　　：2013/03/14 (Thu) 10:24:07 T.Oide       TFT/CFﾛｯﾄ紐付き情報機能修正
    Private Sub Form_Load()

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ ※ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない為の対応
            Me.CancelButton = Nothing

            'NSYS 初期画面位置設定
            Me.Left = 0 - My.Settings.FormOffset             
            Me.Top = 0

            '@暗黙でFormが表示されたか
            'If Not Me Is Me Then
                '@暗黙で表示されていない場合

                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ CFｷｬﾘｱ一覧／TFT/CFﾛｯﾄ紐付き情報　起動処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                'Call Load(Me)
                
                '@Escﾎﾞﾀﾝを有効にする
                'Me.CancelButton = cmdClose
                
                'Exit Sub
            'End If
            
            '@[確定]ﾎﾞﾀﾝ押下判定ﾌﾗｸﾞの初期化(ﾃﾞﾌｫﾙﾄ"True"で[確定]ﾎﾞﾀﾝが押下された時のみ"False")
            pblnCancel = True


            '@ｿｰﾄ構造体の初期化
            With mtypChgSort

                .lngCnt = 0                 'ｿｰﾄ数
                .typChgSortList = New List(Of ChgSortList)  'ｿｰﾄﾃﾞｰﾀ格納配列
                .blnChgWidth = False        '列幅変更ﾌﾗｸﾞ(False：未変更)
                .strKey = vbNullString      'ｶﾚﾝﾄ行検索ｷｰ
            End With

            '@=======================
            '@ 画面情報初期化処理
            '@=======================
            Call prvFrmxxCM00T0_Init()

            '@=======================
            '@ ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvvsfLotList_Init()


            '@最新取得結果判定ﾌﾗｸﾞ初期化(True：取得成功、False：初期値orﾌｫｰﾑﾛｰﾄﾞ時に最新取得失敗)
            mblnNowListClick = False


            '@=======================
            '@ 最新取得ﾎﾞﾀﾝ押下処理
            '@=======================
            Call cmdNowList_Click(cmdNowList, EventArgs.Empty)


            '@Escﾎﾞﾀﾝを有効にする
            Me.CancelButton = cmdClose
            
            '@最新取得結果判定ﾌﾗｸﾞが"True：取得成功"か
            If mblnNowListClick = True Then

                '@TFT/CFﾛｯﾄ一覧にﾃﾞｰﾀが存在するか
                If vsfLotList.Rows.Count > 1 Then

                    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動処理成功"をｾｯﾄ
                    pblnFormLoad = True

                Else
                    '@TFT/CFﾛｯﾄ一覧にﾃﾞｰﾀが0件の場合

                    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"False：起動処理失敗"をｾｯﾄ
                    pblnFormLoad = False

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM29I>$$該当件数 ： %1 件"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, lblLotCnt.Text)
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)

                End If
            End If

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

    '関数名：cmdHyoumen_Click
    '機　能：表面処理の情報のみ表示
    '引　数：なし
    '戻り値：
    '作成日：2013/03/19 (Tue) 11:15:13 T.Oide
    '更新日：2013/03/19 (Tue) 11:15:13
    '備　考：
    Private Sub cmdHyoumen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHyoumen.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@表面処理の情報を表示
            Call prvTftCfDisp(CPstrEqTypeHyoumenSyori)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdJyoucyaku_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdJyoucyaku_Click
    '機　能：蒸着の情報のみ表示
    '引　数：なし
    '戻り値：
    '作成日：2013/03/19 (Tue) 11:15:16 T.Oide
    '更新日：2013/03/19 (Tue) 11:15:16
    '備　考：
    Private Sub cmdJyoucyaku_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdJyoucyaku.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@表面処理の情報を表示
            Call prvTftCfDisp(CPstrEqTypeJyoucyaku)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdJyoucyaku_Click"
                .strErrMessage = vbNullString
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
    '　　　：Shift  ：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 10:38:33 N.Kasai
    '更新日：2009/10/02 (Fri) 16:58:36 N.Kojima
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                e.Handled = True
                Exit Sub
            End If


            '@有効ｺﾝﾄﾛｰﾙが[TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞか
            If ActiveControl.Name = vsfLotList.Name Then

                '@=======================
                '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ用上下ｽｸﾛｰﾙﾎﾞﾀﾝの共通処理：ｸﾞﾘｯﾄﾞ、上(▲)、下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ)
                '@=======================
                Call pubVsf_KeyDown(e, ActiveControl.Name, vsfLotList, cmdUP, cmdDown)
                
                '@=======================
                '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ用左右ｽｸﾛｰﾙﾎﾞﾀﾝ共通処理：ｸﾞﾘｯﾄﾞ、左(<<)、右(>>)ｽｸﾛｰﾙﾎﾞﾀﾝ)
                '@=======================
                Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfLotList, cmdLeft, cmdRight)

            End If


            '@★ 押下ｷｰにより処理分岐 ★
            Select Case e.KeyCode

                '@〓 Enterｷｰ 〓
                Case Keys.Return

                    With vsfLotList

                        '@有効ｺﾝﾄﾛｰﾙが[TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞか
                        If ActiveControl.Name = .Name Then

                            '@ﾀｲﾄﾙ行orﾃﾞｰﾀ行か
                            If .Row >= .Rows.Fixed Then

                                '@=======================
                                '@ 確定ﾎﾞﾀﾝ押下処理
                                '@=======================
                                Call cmdRegist_Click(cmdRegist, EventArgs.Empty)
                            End If
                        Else
                            '@有効ｺﾝﾄﾛｰﾙが[TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ以外の場合

                            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄし、ｷｰｺｰﾄﾞを初期化
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                        End If
                    End With

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
    '引　数：Cancel     ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode ：終了方法
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 10:24:01 N.Kasai
    '更新日：2009/10/02 (Fri) 16:58:36 N.Kojima
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

    '@↓2009/10/07 (Wed) 10:14:03 N.Kojima **************************************************

        Dim ltypCFListRec                   As CFListRec                    'CFﾘｽﾄ要求格納構造体
        Dim ltypCFListAns                   As CFListAns                    'CFﾘｽﾄ応答格納構造体
        Dim ltypJBatchConnectedInfoRec      As JBatchConnectedInfoRec       'TFT/CFﾛｯﾄ紐付き情報要求格納構造体
        Dim ltypJBatchConnectedInfoAns      As JBatchConnectedInfoAns       'TFT/CFﾛｯﾄ紐付き情報応答格納構造体

    '@↑2009/10/07 (Wed) 10:14:03 N.Kojima **************************************************

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then

                '@ｸｴﾘｱﾝﾛｰﾄﾞをｷｬﾝｾﾙし、処理終了
                e.Cancel = True
                Exit Sub
            End If

            '@ｿｰﾄ保持用構造体の配列初期化
            mtypChgSort.typChgSortList = Nothing
            
        '@↓2009/10/07 (Wed) 10:12:42 N.Kojima **************************************************

            '@各種通信用構造体の初期化
            mtypCFListRec = ltypCFListRec                               'CFﾘｽﾄ要求格納構造体
            mtypCFListAns = ltypCFListAns                               'CFﾘｽﾄ応答格納構造体
            mtypJBatchConnectedInfoRec = ltypJBatchConnectedInfoRec     'TFT/CFﾛｯﾄ紐付き情報要求格納構造体
            mtypJBatchConnectedInfoAns = ltypJBatchConnectedInfoAns     'TFT/CFﾛｯﾄ紐付き情報応答格納構造体

        '@↑2009/10/07 (Wed) 10:12:42 N.Kojima **************************************************

            '@CFｷｬﾘｱ情報取得時に使用したPublic変数の初期化
            pstrVaFlag = vbNullString       '無機ﾌﾗｸﾞ格納用変数
            pstrTpalClass = vbNullString    'TPAL貼り合わせ方式

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

    '関数名：cmdNowList_Click
    '機　能：[最新取得]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 11:11:23 N.Kasai
    '更新日：2009/10/02 (Fri) 16:58:36 N.Kojima
    '備　考：
    '　　　：2005/06/06 (Mon) 09:00:29 N.Kasai      不要ﾀｸﾞの整理
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click

        Dim lblnAns     As Boolean      '通信結果格納用変数(True：取得成功、False：取得失敗)

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計
            '@ ②ﾌｫｰﾑのﾛｯｸ中
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If


        '@↓2009/10/05 (Mon) 18:10:22 N.Kojima **************************************************

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdNowListClick)

            '@ﾌｫｰﾑ起動区分が"1：TFT/CFﾛｯﾄ紐付き情報起動"か
            If plngfrmxxCM00T0Kbn = CPlngNumOne Then

        '@↓2013/03/14 (Thu) 13:21:37 T.Oide **************************************************
        '@        '@***********************
        '@        '@ 送信ﾃﾞｰﾀ作成
        '@        '@***********************
        '@        With mtypJBatchConnectedInfoRec
        '@
        '@            .strMsgVer = CMstrlot_jbatchconnectedinfoVer    'Msgﾊﾞｰｼﾞｮﾝ
        '@            .strSbId = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸID
        '@            .strLotId = lblLotID.Caption                    'ﾛｯﾄID
        '@            .strJBatchID = ptypCommonInfo.strBatchID        '蒸着ﾊﾞｯﾁID
        '@            .strCfFlag = ptypCommonInfo.strCfFlag           'CFﾌﾗｸﾞ
        '@        End With
        '@
        '@        '@通信中は画面をﾛｯｸする
        '@        frmxxCM00T0.Enabled = False
        '@
        '@
        '@        '@=======================
        '@        '@ TFT/CFﾛｯﾄ紐付き情報取得
        '@        '@=======================
        '@        lblnAns = pubblnLotJBatchConnectedInfo_Sel(mtypJBatchConnectedInfoRec, _
        '@                                                   mtypJBatchConnectedInfoAns)
        '@---------------------------------------------------------------------------------------
                                  
                '@***********************
                '@ 送信ﾃﾞｰﾀ作成
                '@***********************
                With mtypJBatchConnectedInfoRec

                    .strMsgVer = CMstrlot_jbatchconnectedinfo2Ver   'Msgﾊﾞｰｼﾞｮﾝ
                    .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸID
                    .strLotID = lblLotID.Text                       'ﾛｯﾄID

                End With
                
                 
                '@=======================
                '@ TFT/CFﾛｯﾄ紐付き情報取得2
                '@=======================
                lblnAns = pubblnLotJBatchConnectedInfo_Sel2(mtypJBatchConnectedInfoRec, _
                                                            mtypJBatchConnectedInfoAns2)


            Else
                '@ﾌｫｰﾑ起動区分が"0：CFｷｬﾘｱ一覧起動"

                '@***********************
                '@ 送信ﾃﾞｰﾀ作成
                '@***********************
                With mtypCFListRec
            
                    .strMsgVer = CMstrcarrcflist__Ver           'Msgﾊﾞｰｼﾞｮﾝ
                    .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸID
                    .strTFTLotID = lblLotID.Text                'TFTﾛｯﾄID
                    .strWfNum = lblWFNo.Text                    'WF枚数
                End With
            
                '@=======================
                '@ CFｷｬﾘｱ一覧取得
                '@=======================
                lblnAns = pubblnCarrCFList_Sel(mtypCFListRec, _
                                               mtypCFListAns, _
                                               pstrVaFlag, _
                                               pstrTpalClass)

            End If

            '@TFT/CFﾛｯﾄ紐付き情報取得orCFｷｬﾘｱ一覧取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdNowListClick)

                '@=======================
                '@ TFT/CFﾛｯﾄ一覧表示処理
                '@=======================
                Call prvvsfLotList_Disp()

                '@最新取得結果判定ﾌﾗｸﾞに"True：取得成功"をｾｯﾄ(True：取得成功、False：ﾌｫｰﾑﾛｰﾄﾞ時に最新取得失敗)
                mblnNowListClick = True

            Else
                '@TFT/CFﾛｯﾄ紐付き情報取得orCFｷｬﾘｱ一覧取得結果が"False：取得失敗"の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdNowListClick)

                '@最新取得結果判定ﾌﾗｸﾞに"False：最新取得失敗"をｾｯﾄ(True：取得成功、False：ﾌｫｰﾑﾛｰﾄﾞ時に最新取得失敗)
                mblnNowListClick = False

                Exit Sub
            End If

            'ODF予約情報から予約CFロットを取得する
            '作業開始からの起動
            '組立工程の場合
            If plngfrmxxCM00T0Kbn = CPlngNumZero And pstrSBID = CPstrSBID2A0 Then
                'レスポンス開始
                Call pubResponseStart(CMstrFormName, CMstrCmdNowListClick)

                Dim ltypCurCfLotInfo As New List(Of typCurCfLotInfo)
                lblnAns = pubblnCurCfLotInfo_Sel(CMstrasm_curcflotinfoVer, lblLotID.Text, ltypCurCfLotInfo)

                If lblnAns = False Then
                    'レスポンス中止
                    Call pubResponseCancel(CMstrFormName, CMstrCmdNowListClick)
                    Exit Sub
                End If

                'レスポンス終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdNowListClick)

                '@=======================
                '@ 予約情報の表示
                '@=======================
                Call prvvsfCfReserveLot_Disp(ltypCurCfLotInfo)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowList_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_AfterSort
    '機　能：[TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 10:19:09 N.Kasai
    '更新日：2009/10/02 (Fri) 16:58:36 N.Kojima
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
    Private Sub vsfLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            AddHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange

            '@ｿｰﾄ情報格納
            With mtypChgSort
                Dim ltypChgSortListTmp As ChgSortList

                .lngCnt = .lngCnt + 1                       'ｿｰﾄﾘｽﾄ数
                ltypChgSortListTmp.lngCol = e.Col           'ｿｰﾄ列番号
                ltypChgSortListTmp.lngOrder = e.Order       '並び替え方法を格納(昇順/降順)

                .typChgSortList.Add(ltypChgSortListTmp)
            End With

            '@=======================
            '@ ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列(ｷｰ)、上下ｽｸﾛｰﾙﾎﾞﾀﾝ)
            '@=======================
            Call pubVsfAfterSort(vsfLotList, CMvsfLotColNo, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_AfterUserResize
    '機　能：[TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ﾕｰｻﾞｰ列幅変更後処理
    '引　数：Row    ：行番号
    '　　　：Col    ：列番号
    '戻り値：なし
    '作成日：2009/10/07 (Wed) 10:44:20 N.Kojima
    '更新日：2009/10/07 (Wed) 10:44:20 N.Kojima
    '備　考：
    Private Sub vsfLotList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotList.AfterResizeColumn, vsfLotList.AfterResizeRow

        Try

            '@列幅変更ﾌﾗｸﾞに"True：変更"をｾｯﾄ
            mtypChgSort.blnChgWidth = True

            '@=======================
            '@ 左右("<<",">>")ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            '@=======================
            Call pubCmdLREnable_Set(vsfLotList, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_BeforeRowColChange
    '機　能：[TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　行列変更前処理
    '引　数：OldRow ：旧行
    '　　　：OldCol ：旧列
    '　　　：NewRow ：新行
    '　　　：NewCol ：新列
    '　　　：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 10:23:42 N.Kasai
    '更新日：2009/10/02 (Fri) 16:58:36 N.Kojima
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
    Private Sub vsfLotList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotList.BeforeRowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@旧選択行と新選択行が異なり、かつ新選択行がﾃﾞｰﾀ行か
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then

                '@ｶﾚﾝﾄ行検索ｷｰを格納(№)
                mtypChgSort.strKey = vsfLotList.GetData(e.NewRange.r1, CMvsfLotColNo)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_BeforeSort
    '機　能：[TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 10:20:30 N.Kasai
    '更新日：2009/10/02 (Fri) 16:58:36 N.Kojima
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
    Private Sub vsfLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ ｿｰﾄ前のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列(ｷｰ))
            '@=======================
            Call pubVsfBeforeSort(vsfLotList, CMvsfLotColNo)

            'NSYS ソート時にBeforeRowColChangeイベントが発生し、検索キー mtypChgSort.strKey
            'NSYS が設定されるのを避けるため
            RemoveHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_DblClick
    '機　能：[TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ﾀﾞﾌﾞﾙClick時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 10:24:48 N.Kasai
    '更新日：2009/10/02 (Fri) 16:58:36 N.Kojima
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
    Private Sub vsfLotList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.DoubleClick

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀの位置がﾀｲﾄﾙ行か
            If vsfLotList.MouseRow <= 0 Then
                Exit Sub
            End If

            '@無機ﾌﾗｸﾞが"1：無機ﾛｯﾄ"、またはTPAL設定がNULL以外(設定あり)か
            If pstrVaFlag = CPstrOne Or pstrTpalClass <> vbNullString Then
                Exit Sub
            End If

            '@=======================
            '@ 確定ﾎﾞﾀﾝ押下処理
            '@=======================
            Call cmdRegist_Click(cmdRegist, EventArgs.Empty)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_DblClick"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_RowColChange
    '機　能：[TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 10:21:16 N.Kasai
    '更新日：2009/10/02 (Fri) 16:58:36 N.Kojima
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
    Private Sub vsfLotList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.RowColChange

        Try

            '@選択行がﾀｲﾄﾙ行以外か
            If vsfLotList.Row <> CMvsfLotListTRow Then
                '@確定ﾎﾞﾀﾝを有効にする
                cmdRegist.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：[上(▲)ｽｸﾛｰﾙ]ﾎﾞﾀﾝ([TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 10:19:32 N.Kasai
    '更新日：2009/10/02 (Fri) 16:58:36 N.Kojima
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
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
            '@ 上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdUp(vsfLotList, cmdUP, cmdDown)

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
    '機　能：[下(▼)ｽｸﾛｰﾙ]ﾎﾞﾀﾝ([TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 10:19:45 N.Kasai
    '更新日：2009/10/02 (Fri) 16:58:36 N.Kojima
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
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
            '@ 下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdDown(vsfLotList, cmdUP, cmdDown)

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
    '機　能：[左(<<)ｽｸﾛｰﾙ]ﾎﾞﾀﾝ([TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/10/07 (Wed) 10:47:13 N.Kojima
    '更新日：2009/10/07 (Wed) 10:47:13 N.Kojima
    '備　考：
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
            '@ 左(<<)ｽｸﾛｰﾙ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdLeft(vsfLotList, cmdLeft, cmdRight)

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
    '機　能：[右(>>)ｽｸﾛｰﾙ]ﾎﾞﾀﾝ([TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/10/07 (Wed) 10:47:13 N.Kojima
    '更新日：2009/10/07 (Wed) 10:47:13 N.Kojima
    '備　考：
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
            '@ 右(>>)ｽｸﾛｰﾙ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdRight(vsfLotList, cmdLeft, cmdRight)

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

    '関数名：cmdClose_Click
    '機　能：[閉じる]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 10:26:39 N.Kasai
    '更新日：2009/10/02 (Fri) 16:58:36 N.Kojima
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
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

    '関数名：cmdRegist_Click
    '機　能：[確定]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 10:27:06 N.Kasai
    '更新日：2009/10/02 (Fri) 16:58:36 N.Kojima
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfLotList

                '@ﾀｲﾄﾙ行orﾃﾞｰﾀ行が選択されてるか
                If .Row > CMvsfLotListTRow Then

                    '@選択行のｷｬﾘｱIDを格納
                    pstrCFCarrierID = vsfLotList.GetData(.Row, CMvsfLotColCarrierID)

                    '@∇∇∇∇∇∇∇∇∇∇∇
                    '@ ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    Me.Close()
                End If
            End With

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

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvFrmxxCM00T0_Init
    '機　能：画面情報の初期化処理(起動元機能によっては引継ぎ情報設定処理も有り)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 09:33:17 N.Kasai
    '更新日：2013/03/19 (Tue) 12:12:55 T.Oide
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
    Private Sub prvFrmxxCM00T0_Init()

        Dim ltypCFListRec                   As CFListRec                    'CFﾘｽﾄ要求格納構造体
        Dim ltypCFListAns                   As CFListAns                    'CFﾘｽﾄ応答格納構造体
        Dim ltypJBatchConnectedInfoRec      As JBatchConnectedInfoRec       'TFT/CFﾛｯﾄ紐付き情報要求格納構造体
        Dim ltypJBatchConnectedInfoAns      As JBatchConnectedInfoAns       'TFT/CFﾛｯﾄ紐付き情報応答格納構造体

        Try


            '@-----------------------
            '@ TPAL貼り合わせ登録、作業開始からの起動(CFｷｬﾘｱ一覧としての起動)の場合は
            '@ ptypOdfInfo構造体に格納されている引継ぎ値をｾｯﾄする。
            '@ 装置別ﾛｯﾄ一覧等からの起動(TFT/CFﾛｯﾄ紐付き情報としての起動)の場合は
            '@ ptypCommonInfo構造体に格納されている引継ぎ値をｾｯﾄする。
            '@-----------------------

            '@ﾌｫｰﾑ起動区分が"1：TFT/CFﾛｯﾄ紐付き情報起動"か
            If plngfrmxxCM00T0Kbn = 1 Then

                '@画面のﾌｫｰﾑｷｬﾌﾟｼｮﾝに"TFT/CFﾛｯﾄ紐付き情報"を設定
                Me.Text = CPstrSubFormCM00T0

                With ptypCommonInfo

                    lblCarrierID.Text = .strCarrierId                                'ｷｬﾘｱID
                    lblLotID.Text = .strLotID                                        'ﾛｯﾄID
                    lblFlowClass.Text = .strFlowClass                                '種別
                    lblPdID.Text = .strPdId                                          '機種
                    lblStatus.Text = .strNowST                                       '状態
                    lblWFNo.Text = .strWfNum                                         '数量(WF)
                    If IsNumeric(.strChipQuantity) Then                              '数量(CHIP)
                        lblChipNum.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)
                    Else
                        lblChipNum.Text = .strChipQuantity
                    End If
                    lblOpName.Text = .strOpID                                        '大工程
                    lblStepName.Text = .strStepID                                    '小工程
                    
                End With

            Else
                '@ﾌｫｰﾑ起動区分が"0：CFｷｬﾘｱ一覧起動"の場合

                With ptypOdfInfo
            
                    lblCarrierID.Text = .strLoaderCarrier                            'ｷｬﾘｱID
                    lblLotID.Text = .strLotID                                        'ﾛｯﾄID
                    lblFlowClass.Text = .strFlowClass                                '種別
                    lblPdID.Text = .strPdId                                          '機種
                    lblStatus.Text = .strStatus                                      '状態
                    lblWFNo.Text = .strWfNum                                         '数量(WF)
                    If IsNumeric(.strChipNum) Then                                   '数量(CHIP)
                        lblChipNum.Text = Format$(CInt(.strChipNum), CPstrCFKnmaFormat)
                    Else
                        lblChipNum.Text = .strChipNum
                    End If
                    lblOpName.Text = .strOpID                                        '大工程
                    lblStepName.Text = .strStepID                                    '小工程
                End With

            End If

            '@各種通信用構造体の初期化
            mtypCFListRec = ltypCFListRec                               'CFﾘｽﾄ要求格納構造体
            mtypCFListAns = ltypCFListAns                               'CFﾘｽﾄ応答格納構造体
            mtypJBatchConnectedInfoRec = ltypJBatchConnectedInfoRec     'TFT/CFﾛｯﾄ紐付き情報要求格納構造体
            mtypJBatchConnectedInfoAns = ltypJBatchConnectedInfoAns     'TFT/CFﾛｯﾄ紐付き情報応答格納構造体

            '@各種ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString                                      '情報取得日時
            lblLotCnt.Text = vbNullString                                       '該当件数

            '@各種ﾎﾞﾀﾝの初期化
            cmdUP.Enabled = False                                               '上(▲)ｽｸﾛｰﾙ
            cmdDown.Enabled = False                                             '下(▼)ｽｸﾛｰﾙ
            cmdLeft.Enabled = False                                             '左(<<)ｽｸﾛｰﾙ
            cmdRight.Enabled = False                                            '右(>>)ｽｸﾛｰﾙ
            cmdRegist.Enabled = False                                           '確定
        '@↓2013/03/14 (Thu) 11:23:05 T.Oide **************************************************
            cmdHyoumen.Enabled = False                                          '表面処理のみ
            cmdJyoucyaku.Enabled = False                                        '蒸着のみ
            
            '@ﾎﾞﾀﾝの表示/非表示を設定
            '@ﾌｫｰﾑ起動区分が"1：TFT/CFﾛｯﾄ紐付き情報起動"か
            If plngfrmxxCM00T0Kbn = 1 Then
                cmdRegist.Visible = False
                cmdHyoumen.Visible = True
                cmdJyoucyaku.Visible = True
            Else
                cmdRegist.Visible = True
                cmdHyoumen.Visible = False
                cmdJyoucyaku.Visible = False
            End If
        '@↑2013/03/14 (Thu) 11:23:05 T.Oide **************************************************


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxCM00T0_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2013/03/14 (Thu) 10:26:51 T.Oide **************************************************
    '関数名：prvvsfLotListTftCf
    '機　能：TFT/CF紐付き情報用にｸﾞﾘｯﾄﾞを設定
    '引　数：なし
    '戻り値：
    '作成日：2013/03/14 (Thu) 10:26:38 T.Oide
    '更新日：2013/03/14 (Thu) 10:26:45 T.Oide
    '備　考：
    Private Sub prvvsfLotListTftCf()

        Try
                
            With vsfLotList
                
                '@ｶﾗﾑ数設定
                .Cols.Count = CMlngvsfTftCfCols
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMvsfLotListTRow, CMlngvsfTftCfBatchClass, CMstrvsfTftCfBatchClassT) '装置種別
                .SetData(CMvsfLotListTRow, CMlngvsfTftCfWPID, CMstrvsfTftCfWPIDT)             '号機
                .SetData(CMvsfLotListTRow, CMlngvsfTftCfLOTID, CMstrvsfTftCfLOTIDT)           'ロットID
                .SetData(CMvsfLotListTRow, CMlngvsfTftCfWFID, CMstrvsfTftCfWFIDT)             'WFID
                .SetData(CMvsfLotListTRow, CMlngvsfTftCfTPLOT1, CMstrvsfTftCfTPLOT1T)         'TPロット1
                .SetData(CMvsfLotListTRow, CMlngvsfTftCfTPLOT2, CMstrvsfTftCfTPLOT2T)         'TPロット2
                .SetData(CMvsfLotListTRow, CMlngvsfTftCfChipNum, CMstrvsfTftCfChipNumT)       'チップ
                .SetData(CMvsfLotListTRow, CMlngvsfTftCfStepID, CMstrvsfTftCfStepIDT)         '小工程
                .SetData(CMvsfLotListTRow, CMlngvsfTftCfBatchID, CMstrvsfTftCfBatchIDT)       'バッチID
                .SetData(CMvsfLotListTRow, CMlngvsfTftCfTpalClass, CMstrvsfTftCfTpalClassT)   '貼合制限

                '@ﾀｲﾄﾙ文字の表示位置設定
                .Cols(CMlngvsfTftCfBatchClass).TextAlign = TextAlignEnum.CenterCenter         '装置種別
                .Cols(CMlngvsfTftCfWPID).TextAlign = TextAlignEnum.CenterCenter               '号機
                .Cols(CMlngvsfTftCfLOTID).TextAlign = TextAlignEnum.CenterCenter              'ロットID
                .Cols(CMlngvsfTftCfWFID).TextAlign = TextAlignEnum.LeftCenter                 'WFID
                .Cols(CMlngvsfTftCfTPLOT1).TextAlign = TextAlignEnum.CenterCenter             'TPロット1
                .Cols(CMlngvsfTftCfTPLOT2).TextAlign = TextAlignEnum.CenterCenter             'TPロット2
                .Cols(CMlngvsfTftCfChipNum).TextAlign = TextAlignEnum.CenterCenter            'チップ
                .Cols(CMlngvsfTftCfStepID).TextAlign = TextAlignEnum.LeftCenter               '小工程
                .Cols(CMlngvsfTftCfBatchID).TextAlign = TextAlignEnum.CenterCenter            'バッチID
                .Cols(CMlngvsfTftCfTpalClass).TextAlign = TextAlignEnum.CenterCenter          '貼合制限

                '@列幅設定
                .Cols(CMlngvsfTftCfBatchClass).Width = CMlngvsfTftCfBatchClassW               '装置種別
                .Cols(CMlngvsfTftCfWPID).Width = CMlngvsfTftCfWPIDW                           '号機
                .Cols(CMlngvsfTftCfLOTID).Width = CMlngvsfTftCfLOTIDW                         'ロットID
                .Cols(CMlngvsfTftCfWFID).Width = CMlngvsfTftCfWFIDW                           'WFID
                .Cols(CMlngvsfTftCfTPLOT1).Width = CMlngvsfTftCfTPLOT1W                       'TPロット1
                .Cols(CMlngvsfTftCfTPLOT2).Width = CMlngvsfTftCfTPLOT2W                       'TPロット2
                .Cols(CMlngvsfTftCfChipNum).Width = CMlngvsfTftCfChipNumW                     'チップ
                .Cols(CMlngvsfTftCfStepID).Width = CMlngvsfTftCfStepIDW                       '小工程
                .Cols(CMlngvsfTftCfBatchID).Width = CMlngvsfTftCfBatchIDW                     'バッチID
                .Cols(CMlngvsfTftCfTpalClass).Width = CMlngvsfTftCfTpalClassW                 '貼合制限
                
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListTftCf"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListCFCarrier
    '機　能：CFキャリア一覧用にｸﾞﾘｯﾄﾞを設定
    '引　数：なし
    '戻り値：
    '作成日：2013/03/14 (Thu) 10:26:38 T.Oide
    '更新日：2013/03/14 (Thu) 10:26:45 T.Oide
    '備　考：
    Private Sub prvvsfLotListCFCarrier()

        Try
                
            With vsfLotList
                
                '@ｶﾗﾑ数設定
                .Cols.Count = CMvsfLotCols
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMvsfLotListTRow, CMvsfLotColNo, CMvsfLotColTNo)                 '№
                .SetData(CMvsfLotListTRow, CMvsfLotColCarrierID, CMvsfLotColTCarrierID)   'ｷｬﾘｱID
                .SetData(CMvsfLotListTRow, CMvsfLotColLotID, CMvsfLotColTLotID)           'ﾛｯﾄID
                .SetData(CMvsfLotListTRow, CMvsfLotColFlowClass, CMvsfLotColTFlowClass)   '種別
                .SetData(CMvsfLotListTRow, CMvsfLotColPdID, CMvsfLotColTPdID)             '機種
                .SetData(CMvsfLotListTRow, CMvsfLotColWfNum, CMvsfLotColTWfNum)           '数量(WF)
                .SetData(CMvsfLotListTRow, CMvsfLotColChipNum, CMvsfLotColTChipNum)       '数量(CHIP)
                .SetData(CMvsfLotListTRow, CMvsfLotColPriority, CMvsfLotColTPriority)     '優先度
                .SetData(CMvsfLotListTRow, CMvsfLotColOdfReserveInfo, CMvsfLotColTOdfReserveInfo)
                

                '@ﾀｲﾄﾙ文字の表示位置設定
                .Cols(CMvsfLotColNo).TextAlign = TextAlignEnum.CenterCenter               '№
                .Cols(CMvsfLotColCarrierID).TextAlign = TextAlignEnum.CenterCenter        'ｷｬﾘｱID
                .Cols(CMvsfLotColLotID).TextAlign = TextAlignEnum.CenterCenter            'ﾛｯﾄID
                .Cols(CMvsfLotColFlowClass).TextAlign = TextAlignEnum.CenterCenter        '種別
                .Cols(CMvsfLotColPdID).TextAlign = TextAlignEnum.CenterCenter             '機種
                .Cols(CMvsfLotColWfNum).TextAlign = TextAlignEnum.CenterCenter            '数量(WF)
                .Cols(CMvsfLotColChipNum).TextAlign = TextAlignEnum.CenterCenter          '数量(CHIP)
                .Cols(CMvsfLotColPriority).TextAlign = TextAlignEnum.CenterCenter         '優先度
                .Cols(CMvsfLotColOdfReserveInfo).TextAlign = TextAlignEnum.CenterCenter

                '@列幅設定
                .Cols(CMvsfLotColNo).Width = CMvsfLotColWNo                               '№
                .Cols(CMvsfLotColCarrierID).Width = CMvsfLotColWCarrierID                 'ｷｬﾘｱID
                .Cols(CMvsfLotColLotID).Width = CMvsfLotColWLotID                         'ﾛｯﾄID
                .Cols(CMvsfLotColFlowClass).Width = CMvsfLotColWFlowClass                 '種別
                .Cols(CMvsfLotColPdID).Width = CMvsfLotColWPdID                           '機種
                .Cols(CMvsfLotColWfNum).Width = CMvsfLotColWWfNum                         '数量(WF)
                .Cols(CMvsfLotColChipNum).Width = CMvsfLotColWChipNum                     '数量(CHIP)
                .Cols(CMvsfLotColPriority).Width = CMvsfLotColWPriority                   '優先度
                .Cols(CMvsfLotColOdfReserveInfo).Width = CMvsfLotColWOdfReserveInfo

            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListCFCarrier"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub
    '@↑2013/03/14 (Thu) 10:26:51 T.Oide **************************************************

    '関数名：prvvsfLotList_Init
    '機　能：[TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 09:34:06 N.Kasai
    '更新日：2013/03/14 (Thu) 10:36:46 T.Oide
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
    '　　　：2013/03/14 (Thu) 10:24:07 T.Oide       TFT/CFﾛｯﾄ紐付き情報機能修正
    Private Sub prvvsfLotList_Init()

        Try

            '@-----------------------
            '@★当Subの処理概要
            '@　①各種ﾌﾟﾛﾊﾟﾃｨの設定
            '@　②各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            '@-----------------------

            With vsfLotList

                '@各種ﾌﾟﾛﾊﾟﾃｨ値を設定
                .Redraw = False                          '描画(停止)
                '.Clear                                   'ｸﾘｱ(する)
                .Rows.Count = .Rows.Fixed                '行数
                .Cols.Count = CMvsfLotListCols           '列数
                .Cols.Frozen = .Cols.Fixed               '固定列数
                .SelectionMode = SelectionModeEnum.Row   'ｾﾙ選択単位(行単位)
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter  '省略符号(...)表示(文字列最後に表示)
                .HighLight = HighLightEnum.Always        'ﾊｲﾗｲﾄ表示(する)
                .FocusRect = FocusRectEnum.Light         'ﾌｫｰｶｽ枠のｽﾀｲﾙ(細い枠)
                
        '@↓2013/03/15 (Fri) 15:46:45 T.Oide **************************************************
                '@ﾌｫｰﾑ起動区分が"1：TFT/CFﾛｯﾄ紐付き情報起動"か
                If plngfrmxxCM00T0Kbn = CPlngNumOne Then
                    .AllowResizing = AllowResizingEnum.Columns          'ﾏｳｽでの行列変更(可)
                    .Styles.Normal.WordWrap = True                      '文章の折り返し(OK)
                    .AllowMerging = AllowMergingEnum.Free               'ｾﾙﾏｰｼﾞする
                    .Cols(CMlngvsfTftCfBatchClass).AllowMerging = True  '装置種別列ﾏｰｼﾞする
                    .Cols(CMlngvsfTftCfWPID).AllowMerging = True        '装置列ﾏｰｼﾞする
                    .Cols(CMlngvsfTftCfBatchID).AllowMerging = True     'ﾊﾞｯﾁID列ﾏｰｼﾞする
                    .SelectionMode = SelectionModeEnum.Default          '選択ﾓｰﾄﾞﾌﾘｰ
                Else
                    .AllowResizing = AllowResizingEnum.None             'ﾏｳｽでの行列変更(不可)
                    .Styles.Normal.WordWrap = False                     '文章の折り返し(しない)
                End If
        '@↑2013/03/15 (Fri) 15:46:45 T.Oide **************************************************
                
                '@ﾀｲﾄﾙ設定
                .Select(CMvsfLotListTRow, .Cols.Fixed, CMvsfLotListTRow, .Cols.Count - 1)
                Dim lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                                                '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                   '背景色
                With .Font                                                                          'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMvsfHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                lFixedStyle.Trimming = StringTrimming.None

        '@↓2013/03/14 (Thu) 10:36:40 T.Oide **************************************************
                '@ﾌｫｰﾑ起動区分が"1：TFT/CFﾛｯﾄ紐付き情報起動"か
                If plngfrmxxCM00T0Kbn = CPlngNumOne Then
                
                    '@TFT/CFﾛｯﾄ紐付き情報の設定
                    Call prvvsfLotListTftCf()
                    
                Else
                
                    '@CFｷｬﾘｱ一覧の設定
                    Call prvvsfLotListCFCarrier()
                    
                End If
        '@↑2013/03/14 (Thu) 10:36:40 T.Oide **************************************************

                '@ﾀｲﾄﾙ行の高さ設定
                .Rows(CMvsfLotListTRow).Height = CMvsfLotListHdHeight

                '@非表示列の設定
                '@非表示列なし

                '@描画(する)
                .Redraw = True

                '@[TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞを無効にする
                .Enabled = False
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                cmdUP.Enabled = False           '上(▲)ｽｸﾛｰﾙ
                cmdDown.Enabled = False         '下(▼)ｽｸﾛｰﾙ

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfLotList_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvGridBackColer
    '機　能：背景色を灰色にする
    '引　数：strCfFlag：CFﾌﾗｸﾞ
    '　　　：lngRowCnt：行ｶｳﾝﾀ
    '戻り値：
    '作成日：2013/03/25 (Mon) 11:31:55 T.Oide
    '更新日：2013/03/25 (Mon) 11:31:55
    '備　考：
    Private Sub prvGridBackColer(ByVal strCfFlag As String, ByVal lngRowCnt As Integer)

        Try
            
            '@CF以外か
            If strCfFlag = 1 Then
                '@背景色を灰色に変更
                Call prvGreyBkCloler(lngRowCnt, CMlngvsfTftCfWFID)
            End If
            
            '@貼合制限が空の場合背景ｸﾞﾚｰ
            If vsfLotList.GetData(lngRowCnt, CMlngvsfTftCfTpalClass) = vbNullString Then
                '@背景色を灰色に変更
                Call prvGreyBkCloler(lngRowCnt, CMlngvsfTftCfTpalClass)
            End If

            '@TPALﾛｯﾄ1が空の場合背景ｸﾞﾚｰ
            If vsfLotList.GetData(lngRowCnt, CMlngvsfTftCfTPLOT1) = vbNullString Then
                '@背景色を灰色に変更
                Call prvGreyBkCloler(lngRowCnt, CMlngvsfTftCfTPLOT1)
            End If
            
            '@TPALﾛｯﾄ2が空の場合背景ｸﾞﾚｰ
            If vsfLotList.GetData(lngRowCnt, CMlngvsfTftCfTPLOT2) = vbNullString Then
                '@背景色を灰色に変更
                Call prvGreyBkCloler(lngRowCnt, CMlngvsfTftCfTPLOT2)
            End If
            
        Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGridBackColer"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvTPDataDisp
    '機　能：TPALの情報を表示する
    '引　数：なし
    '戻り値：ltypeLotList   :表示ﾃﾞｰﾀ構造体
    '      ：lngRowCnt     :行ｶｳﾝﾀ
    '作成日：2013/03/25 (Mon) 11:11:31 T.Oide
    '更新日：2013/03/25 (Mon) 11:31:10 T.Oide
    '備　考：
    Private Sub prvTPDataDisp(ByRef ltypeLotList As TftCfLotList, ByVal lngRowCnt As Integer)

        Dim llngTpalChip1       As Integer
        Dim llngTpalChip2       As Integer
        Dim lstrTpalStepId1     As String
        Dim lstrTpalStepId2     As String
        Dim llngCnt3            As Integer
        
        Try
            
            With ltypeLotList
                
                '@TPALﾛｯﾄ
                llngTpalChip1 = 0
                llngTpalChip2 = 0
                For llngCnt3 = 0 To .lngTpalLotListCnt -1
                    If llngCnt3 = 0 Then
                        vsfLotList.SetData(lngRowCnt, CMlngvsfTftCfTPLOT1, _
                            .typeTpalLotList(llngCnt3).strTpalLotId & " " & _
                            .typeTpalLotList(llngCnt3).strCarrierId)                    'TPAL_LOT_ID ｷｬﾘｱID
                        llngTpalChip1 = .typeTpalLotList(llngCnt3).strChipQuantity      'ﾁｯﾌﾟ数退避
                        
                        If .typeTpalLotList(llngCnt3).strStepID = vbNullString And _
                           .typeTpalLotList(llngCnt3).strLotEventId = CMstrLOT_EVENT_END Then
                            lstrTpalStepId1 = CMstrLOT_EVENT_END_NAME
                        Else
                            lstrTpalStepId1 = .typeTpalLotList(llngCnt3).strStepID      '小工程
                        End If
                    Else
                        vsfLotList.SetData(lngRowCnt, CMlngvsfTftCfTPLOT2, _
                            .typeTpalLotList(llngCnt3).strTpalLotId & " " & _
                            .typeTpalLotList(llngCnt3).strCarrierId)                    'TPAL_LOT_ID ｷｬﾘｱID
                        llngTpalChip2 = .typeTpalLotList(llngCnt3).strChipQuantity      'ﾁｯﾌﾟ数退避
                        
                        If .typeTpalLotList(llngCnt3).strStepID = vbNullString And _
                           .typeTpalLotList(llngCnt3).strLotEventId = CMstrLOT_EVENT_END Then
                            lstrTpalStepId2 = CMstrLOT_EVENT_END_NAME
                        Else
                            lstrTpalStepId2 = .typeTpalLotList(llngCnt3).strStepID      '小工程
                        End If
                        
                    End If
                Next
                
                '@TPALﾛｯﾄがﾁｯﾌﾟ数を持つ場合はﾁｯﾌﾟ数、工程を書き換える
                If llngTpalChip1 <> 0 Or llngTpalChip2 <> 0 Then
                    vsfLotList.SetData(lngRowCnt, CMlngvsfTftCfChipNum, _
                        llngTpalChip1 & vbCrLf & llngTpalChip2)                          'ﾁｯﾌﾟ数
                    
                    vsfLotList.SetData(lngRowCnt, CMlngvsfTftCfStepID, _
                        lstrTpalStepId1 & vbCrLf & lstrTpalStepId2)                      '小工程
                
                End If
                
            End With
            
        Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTPDataDisp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvTftCfDisp
    '機　能：TFT/CF紐付き情報一覧表示
    '引　数：lstrDispClass  :空(両方表示)、19(蒸着のみ表示)、20(表面処理のみ表示)　←EqTypeの番号を使用
    '戻り値：
    '作成日：2013/03/19 (Tue) 11:27:53 T.Oide
    '更新日：2013/03/19 (Tue) 11:35:24 T.Oide
    '備　考：
    Private Sub prvTftCfDisp(ByVal lstrDispClass As String)

        Dim llngCnt             As Integer
        Dim llngCnt2            As Integer
        Dim llngCnt3            As Integer
        Dim llngRowCnt          As Integer
        Dim lstrEqTypeName      As String
        Dim lstrWPName          As String
        Dim lstrBatchID         As String
        Dim lstrWFNO            As String
        Dim strTpalClassName    As String

        Try

            With mtypJBatchConnectedInfoAns2
                
                '@行を0に設定
                llngRowCnt = 0
                vsfLotList.Rows.Count = 1
                
                '@ﾊﾞｯﾁIDの回数ﾙｰﾌﾟ
                For llngCnt = 0 To .lngJHBatchListCnt - 1
            
                    With .typeJHBatchList(llngCnt)
                        
                        '@Eqﾀｲﾌﾟは蒸着か
                        If .strEqType = CPstrEqTypeJyoucyaku Then
                            lstrEqTypeName = CMstrJyoucyaku
                        Else
                            lstrEqTypeName = CMstrHyoumen
                        End If
                        
                        lstrWPName = .strWpName         'WP名
                        lstrBatchID = .strJHBatchID     'ﾊﾞｯﾁID
                
                        '@ﾛｯﾄIDのﾙｰﾌﾟ(ｸﾞﾘｯﾄﾞの行は1ﾛｯﾄ1行)
                        For llngCnt2 = 0 To .llngLotListCnt - 1
                        
                            '@表示対象か
                            If lstrDispClass = .strEqType Or _
                               lstrDispClass = vbNullString Then
                            
                                '@行を1行追加
                                llngRowCnt = llngRowCnt + 1
                                vsfLotList.Rows.Count = llngRowCnt + 1
                                '@行高設定
                                vsfLotList.Rows(llngRowCnt).Height = CMvsfLotListHeight
                                
                                With .typLotList(llngCnt2)
                                    
                                    vsfLotList.SetData(llngRowCnt, CMlngvsfTftCfBatchClass, _
                                        lstrEqTypeName)                                                      '装置種別
                                    vsfLotList.SetData(llngRowCnt, CMlngvsfTftCfWPID, _
                                        Mid$(lstrWPName, InStr(1, lstrWPName, "#"), 3))                      '号機(斜方蒸着#1→#1表示)
                                    vsfLotList.SetData(llngRowCnt, CMlngvsfTftCfLOTID, _
                                        .strLotID & " " & .strCarrierId)                                     'ﾛｯﾄID ｷｬﾘｱID
                                    vsfLotList.SetData(llngRowCnt, CMlngvsfTftCfChipNum, _
                                        .strChipQuantity)                                                    'ﾁｯﾌﾟ数
                                        
                                    '@小工程が空の場合は状態を表示する
                                    If .strStepID <> vbNullString Then
                                        vsfLotList.SetData(llngRowCnt, CMlngvsfTftCfStepID, _
                                            .strStepID)                                                      '小工程
                                    Else
                                        vsfLotList.SetData(llngRowCnt, CMlngvsfTftCfStepID, _
                                            CMstrKakoL & .strCurrentStatusName & CMstrKakoR)                 '小工程(現在状態)
                                    End If
                                    
                                    vsfLotList.SetData(llngRowCnt, CMlngvsfTftCfBatchID, _
                                        lstrBatchID)                                                         'ﾊﾞｯﾁID
                                    
                                    '@TPAL_CLASSによって分岐
                                    Select Case .strTpalClass
                                    
                                        '@Bの場合
                                        Case CPstrTpalJBatch
                                            strTpalClassName = CMstrTpalJBatchName
                                        '@LとRの場合
                                        Case CPstrTpalJLeft, CPstrTpalJRight
                                            strTpalClassName = CMstrTpalJLRName
                                        '@BLとBRの場合
                                        Case CPstrTpalJBatchLeft, CPstrTpalJBatchRight
                                            strTpalClassName = CMstrTpalJBatchLRName
                                        '@HBの場合
                                        Case CPstrTpalHBatch
                                            strTpalClassName = CMstrTpalHBatchName
                                        '@以外
                                        Case Else
                                            strTpalClassName = .strTpalClass
                                        
                                    End Select
                                    
                                    vsfLotList.SetData(llngRowCnt, CMlngvsfTftCfTpalClass, _
                                        strTpalClassName)                                                    '貼合制限
                                    
                                    '@CF以外か
                                    If .strCfFlag = 0 Then
                                        '@WF_ID(#01、#02の形式で表示する)
                                        lstrWFNO = vbNullString
                                        For llngCnt3 = 0 To .lngWfListCnt - 1
                                            If llngCnt3 = 0 Then
                                                lstrWFNO = Mid$(.strWfList(llngCnt3), 8, 3)
                                            Else
                                                lstrWFNO = lstrWFNO & CMstrKuten & Mid$(.strWfList(llngCnt3), 8, 3)
                                            End If
                                        Next
                                        vsfLotList.SetData(llngRowCnt, CMlngvsfTftCfWFID, _
                                            lstrWFNO)                                                            'WF№
                                    
                                    End If
                                    
                                    '@TPALﾛｯﾄ情報表示
                                    Call prvTPDataDisp( _
                                        mtypJBatchConnectedInfoAns2.typeJHBatchList(llngCnt).typLotList(llngCnt2), _
                                        llngRowCnt)

                                    '@背景色を灰色に変更
                                    Call prvGridBackColer(.strCfFlag, llngRowCnt)

                                End With
                            End If
                            
                        Next
                    End With
                    
                Next
                
                '@データが1つ以上あれば[蒸着のみ][表面処理のみ]ﾎﾞﾀﾝ有効
                If .lngJHBatchListCnt > 0 Then
                    cmdHyoumen.Enabled = True                                          '表面処理のみ
                    cmdJyoucyaku.Enabled = True                                        '蒸着のみ
                End If
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTftCfDisp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvGreyBkCloler
    '機　能：指定のセルを灰色にする
    '引　数：lngRow：行
    '　　　：lngCol：列
    '戻り値：
    '作成日：2013/03/19 (Tue) 14:05:34 T.Oide
    '更新日：2013/03/19 (Tue) 14:05:34
    '備　考：
    Private Sub prvGreyBkCloler(ByVal lngRow As Integer, ByVal lngCol As Integer)

        Try

            Dim newStyle As CellStyle = vsfLotList.Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
            newStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
            Dim cellRange As CellRange = vsfLotList.GetCellRange(lngRow, lngCol)
            cellRange.Style = newStyle
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGreyBkCloler"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotList_Disp
    '機　能：[TFT/CFﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 10:07:55 N.Kasai
    '更新日：2013/03/15 (Fri) 13:17:48 T.Oide
    '備　考：
    '　　　：2009/10/02 (Fri) 16:58:36 N.Kojima     TFT/CFﾛｯﾄ紐付き情報表示機能追加に伴う修正。(案件№03791)
    '　　　：2013/03/14 (Thu) 10:24:07 T.Oide       TFT/CFﾛｯﾄ紐付き情報機能修正(大幅修正のため元情報削除)
    Private Sub prvvsfLotList_Disp()

        Dim llngCnt         As Integer  '汎用ｶｳﾝﾀ
        Dim llngListData    As Integer  'ﾘｽﾄﾃﾞｰﾀ数

        Try

            '@ﾌｫｰﾑ起動区分が"1：TFT/CFﾛｯﾄ紐付き情報起動"か
            If plngfrmxxCM00T0Kbn = 1 Then

                '@TFT/CFﾛｯﾄ紐付き情報構造体からﾘｽﾄ件数を格納
                llngListData = mtypJBatchConnectedInfoAns2.lngJHBatchListCnt
            Else
                '@ﾌｫｰﾑ起動区分が"0：CFｷｬﾘｱ一覧起動"か

                '@CFｷｬﾘｱ一覧構造体からﾘｽﾄ件数を格納
                llngListData = mtypCFListAns.llngCFListCnt
            End If

            With vsfLotList

                '@表示ﾃﾞｰﾀが0件か
                If llngListData = 0 Then

                    .Enabled = False            '無効
                    .Redraw = False             '描画(停止)
                    .Rows.Count = .Rows.Fixed   '行数(初期化：ﾀｲﾄﾙ行のみ)
                    .Redraw = True              '描画(直接描画)

                    '@各種ﾗﾍﾞﾙの設定
                    lblNowDate.Text = Format$(Now, CPstrDateFormat)                    '情報取得日時
                    lblLotCnt.Text = Format$(.Rows.Count - 1, CPstrDateFormatKanma)    '該当件数

                    '@各種ﾎﾞﾀﾝを無効にする
                    cmdUP.Enabled = False       '上(▲)ｽｸﾛｰﾙ
                    cmdDown.Enabled = False     '下(▼)ｽｸﾛｰﾙ
                    cmdLeft.Enabled = False     '左(<<)ｽｸﾛｰﾙ
                    cmdRight.Enabled = False    '右(>>)ｽｸﾛｰﾙ

                    Exit Sub
                End If

                '@-----------------------
                '@ 表示ﾃﾞｰﾀが0件以外の場合
                '@-----------------------
                .Enabled = True                             '有効
                .Redraw = False                             '描画(停止)
                .Rows.Count = .Rows.Fixed                   '行数(初期化：ﾀｲﾄﾙ行のみ)
                RemoveHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange
                .Rows.Count = llngListData + 1              '行数(ﾀｲﾄﾙ行＋CFﾛｯﾄ情報ﾘｽﾄ件数)
                AddHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange

                '@範囲選択(1列1行目～N列N行目)
                .Select(CMvsfLotListTRow, .Cols.Fixed, CMvsfLotListTRow, .Cols.Count - 1)

                '@-----------------------
                '@ TFT/CFﾛｯﾄ一覧表示
                '@-----------------------
                llngCnt = 1

                '@ﾌｫｰﾑ起動区分が"1：TFT/CFﾛｯﾄ紐付き情報起動"か
                '@ ※毎回ﾙｰﾌﾟ内で起動区分を判定させると処理効率が悪いのでここで条件判定。
                If plngfrmxxCM00T0Kbn = 1 Then
                
                    '@TFT/CF紐付き一覧を表示する(表示対象は両方)
                    Call prvTftCfDisp(vbNullString)

                Else
                    '@ﾌｫｰﾑ起動区分が"0：CFｷｬﾘｱ一覧起動"か

                    Do While .Rows.Count > llngCnt
            
                        With mtypCFListAns
            
                            vsfLotList.SetData(llngCnt, CMvsfLotColNo, llngCnt)                                       '№
                            vsfLotList.SetData(llngCnt, CMvsfLotColCarrierID, .typCFList(llngCnt - 1).strCarrierId)   'ｷｬﾘｱID
                            vsfLotList.SetData(llngCnt, CMvsfLotColLotID, .typCFList(llngCnt - 1).strLotID)           'ﾛｯﾄID
                            vsfLotList.SetData(llngCnt, CMvsfLotColFlowClass, .typCFList(llngCnt - 1).strFlowClass)   '種別
                            vsfLotList.SetData(llngCnt, CMvsfLotColPdID, .typCFList(llngCnt - 1).strPdId)             '機種
                            vsfLotList.SetData(llngCnt, CMvsfLotColWfNum, .typCFList(llngCnt - 1).strWfNum)           '数量(WF)
                            vsfLotList.SetData(llngCnt, CMvsfLotColChipNum, .typCFList(llngCnt - 1).strChipNum)       '数量(CHIP)
                            vsfLotList.SetData(llngCnt, CMvsfLotColPriority, .typCFList(llngCnt - 1).strPriority)     '優先度
                        End With
            
                        '@行高設定
                        .Rows(llngCnt).Height = CMvsfLotListHeight
            
                        '@ﾙｰﾌﾟｶｳﾝﾀを+1する
                        llngCnt = llngCnt + 1
                    Loop
                    
                    
                    '@ﾃﾞｰﾀｱﾗｲﾒﾝﾄ設定(文字表示位置設定)
                    .Cols(CMvsfLotColNo).TextAlign = TextAlignEnum.RightCenter             '右詰の中央揃え(№)
                    .Cols(CMvsfLotColCarrierID).TextAlign = TextAlignEnum.LeftCenter       '左詰の中央揃え(ｷｬﾘｱ位置)
                    .Cols(CMvsfLotColLotID).TextAlign = TextAlignEnum.LeftCenter           '左詰の中央揃え(ﾛｯﾄID)
                    .Cols(CMvsfLotColFlowClass).TextAlign = TextAlignEnum.LeftCenter       '左詰の中央揃え(種別)
                    .Cols(CMvsfLotColPdID).TextAlign = TextAlignEnum.LeftCenter            '左詰の中央揃え(機種)
                    .Cols(CMvsfLotColWfNum).TextAlign = TextAlignEnum.RightCenter          '右詰の中央揃え(数量(WF))
                    .Cols(CMvsfLotColChipNum).TextAlign = TextAlignEnum.RightCenter        '右詰の中央揃え(数量(CHIP))
                    .Cols(CMvsfLotColPriority).TextAlign = TextAlignEnum.RightCenter       '右詰の中央揃え(優先順位)
                    
                End If

                '@ﾀｲﾄﾙ行高設定
                .Rows(CMvsfLotListTRow).Height = CMvsfLotListHdHeight


                '@ﾕｰｻﾞﾘｻｲｽﾞが行われているか(False：未変更)
                ' CF一覧か(TFT/CF紐付き情報は複数行表示するため自動で幅調整はしない)
                If mtypChgSort.blnChgWidth = False And _
                   plngfrmxxCM00T0Kbn <> 1 Then

                    '@自動で列幅調整を行う
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMvsfLotColNo, .Cols.Count - 1, 6)
                End If

                '@ｸﾞﾘｯﾄﾞを初期値へ移動
                .LeftCol = CMvsfLotColNo            '列
                .TopRow = CMvsfLotListTRow          '行
                .Row = CMvsfLotListTRow             'ｶﾚﾝﾄ行の移動

                '@=======================
                '@ 左右("<<",">>")ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                '@=======================
                Call pubCmdLREnable_Set(vsfLotList, cmdLeft, cmdRight)


                '@-----------------------
                '@ ｽｸﾛｰﾙﾎﾞﾀﾝ設定
                '@-----------------------
                '@表示先頭行が1行目か
                If .TopRow = .Rows.Fixed Then

                    '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                    cmdUP.Enabled = False
                Else
                    '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                    cmdUP.Enabled = True
                End If

                '@(表示先頭行+12(1ﾍﾟｰｼﾞの表示行数))が総行数より多いか
                If .TopRow + CMlngvsfPageRows >= .Rows.Count Then

                    '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                    cmdDown.Enabled = False
                Else
                    '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                    cmdDown.Enabled = True
                End If


                '@ﾕｰｻﾞによりｿｰﾄされているか
                If mtypChgSort.lngCnt > 0 Then

                    RemoveHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange
                    '@ｿｰﾄ構造体(保持ﾘｽﾄ)のﾃﾞｰﾀがなくなるまでﾙｰﾌﾟ
                    For llngCnt = 0 To mtypChgSort.lngCnt - 1

                        '@ｿｰﾄﾃﾞｰﾀを表示する
                        .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)

                    Next llngCnt
                    AddHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange
                Else
                
                    'NSYS バッチIDのヘッダ列ちらつき対策(ソート完了までインジケータ非表示)
                    vsfLotList.ShowSortPosition = ShowSortPositionEnum.None 

                    '@ﾊﾞｯﾁIDの順番で並替え
                    vsfLotList.Cols(CMlngvsfTftCfBatchID).Sort = SortFlags.Ascending
                    vsfLotList.Select(1, 0, .Rows.Count - 1, .Cols.Count - 1)
                    vsfLotList.Sort(SortFlags.UseColSort, 0, .Cols.Count - 1)
                    vsfLotList.Select(1, .Cols.Count - 1)
                    
                    'NSYS 「@ﾊﾞｯﾁIDの順番で並替え」でソートを行った際、.NET版では
                    '      ソートインジケータが表示されるため、ここで非表示に再設定
                    vsfLotList.Cols(CMlngvsfTftCfBatchID).Sort = SortFlags.None
                    
                    'NSYS バッチIDのヘッダ列ちらつき対策(インジケータが表示されるように設定を戻す)
                    vsfLotList.ShowSortPosition = ShowSortPositionEnum.Auto
                End If



                '@ｿｰﾄ検索用ｷｰがNULL以外か
                If mtypChgSort.strKey <> vbNullString Then

                    For llngCnt = .Rows.Fixed To .Rows.Count - 1

                        '@一覧の№とｿｰﾄｷｰが同じか
                        If .GetData(llngCnt, CMvsfLotColNo) = mtypChgSort.strKey Then

                            '@ｿｰﾄｷｰと一致した行を選択状態にする
                            .Row = llngCnt

                            '@=======================
                            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfBeforeSort(vsfLotList, CMvsfLotColNo)

                            '@=======================
                            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfAfterSort(vsfLotList, CMvsfLotColNo, cmdUP, cmdDown)

                            Exit For
                        End If
                    Next llngCnt
                End If

                .LeftCol = CMvsfLotColNo

                '@描画(直接描画)
                .Redraw = True

                '@各種ﾗﾍﾞﾙの設定
                lblNowDate.Text = Format$(Now, CPstrDateFormat)                    '情報取得日時
                lblLotCnt.Text = Format$(.Rows.Count - 1, CPstrDateFormatKanma)    '該当件数

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfLotList_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' CFロットの予約内容表示
    ''' </summary>
    ''' <param name="ltypCurCfLotInfo"></param>
    Private Sub prvvsfCfReserveLot_Disp(ByRef ltypCurCfLotInfo As List(Of typCurCfLotInfo))

        Try

            With vsfLotList
                Dim lintRow As Integer
                For lintRow = 1 To .Rows.Count - 1

                    '選択可能なCFロットリスト
                    For Each tmp As typCurCfLotInfo In ltypCurCfLotInfo
                        'CFロットが予約情報と一致した場合
                        If tmp.strCfLotId = .GetData(lintRow, CMvsfLotColLotID) Then
                            'WF数が同じ場合
                            If tmp.strWfNum = .GetData(lintRow, CMvsfLotColWfNum) Then
                                .SetData(lintRow, CMvsfLotColOdfReserveInfo, CMstrCFReserveOK)
                                Exit For
                            'WF数が異なる場合
                            Else
                                .SetData(lintRow, CMvsfLotColOdfReserveInfo, CMstrCFReservePartialOK)
                                Exit For
                            End If  
                        Else
                            .SetData(lintRow, CMvsfLotColOdfReserveInfo, CMstrCFReserveNG)
                        End If 
                    Next
                Next
            End With
 
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCfReserveLot_Disp"
                .strErrMessage = vbNullString
            End With

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

        End If

    End Sub

End Class
