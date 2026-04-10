'ﾌｧｲﾙ名：xxCM00U0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ODF貼り合せ登録　メインフォーム
'作成日：2005/04/28 (Thu) 11:07:59 N.Kasai
'更新日：2014/11/21 (Fri) 19:12:51 T.Oide
'備　考：
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00U0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00U0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00U0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00U0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00U0)
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
    '@機能ID
    Private Const CMstrLocalMenuKey As String = CPstrKeyCM00U0  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_waferlistVer As String = "02.05"         'ﾛｯﾄWF情報取得(新)
    Private Const CMstrlot_curstateVer As String = "04.00"          'ﾛｯﾄ現在状態取得
    Private Const CMstrwf__chgodf__Ver As String = "01.01"          'ODFｳｪﾊ登録
    Private Const CMstrwf__odflist_Ver As String = "01.01"          'ODFｳｪﾊ結果取得
    Private Const CMstrasm_chkodfreserveVer As String = "01.00"     '貼り合せ予約とのチェック

    '@vsfBeforSlotMapの定数宣言(ｶﾗﾑ)
    Private Const CMvsfBColNo As Integer = 0                 '№
    Private Const CMvsfBColTFT As Integer = 1                 'WF_ID(TFT)
    Private Const CMvsfBColCF As Integer = 2                 'WF_ID(CF)

    '@vsfBeforSlotMapの定数宣言(表示幅)
    Private Const CMvsfBColWNo As Integer = 33 '500               '№
    Private Const CMvsfBColWTFT As Integer = 133 '2000              'WF_ID(TFT)
    Private Const CMvsfBColWCF As Integer = 133 '2000              'WF_ID(CF)

    '@vsfBeforSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMvsfBColTNo As String = ""              '№
    Private Const CMvsfBColTTFT As String = "TFT"           'WF_ID(TFT)
    Private Const CMvsfBColTCF As String = "CF"            'WF_ID(CF)

    '@vsfAfterSlotMapの定数宣言(ｶﾗﾑ)
    Private Const CMvsfAColNo As Integer = 0                 '№
    Private Const CMvsfAColTFT As Integer = 1                 'WF_ID(TFT)
    Private Const CMvsfAColCF As Integer = 2                 'WF_ID(CF)
    Private Const CMvsfAColFixFlag As Integer = 3                 'ODF_COVER_FIX_FLAG(0:未、1:済)

    '@vsfAfterSlotMapの定数宣言(表示幅)
    Private Const CMvsfAColWNo As Integer = 33   '500               '№
    Private Const CMvsfAColWTFT As Integer = 133 '2000              'WF_ID(TFT)
    Private Const CMvsfAColWCF As Integer = 133  '2000              'WF_ID(CF)
    Private Const CMvsfAColWFixFlag As Integer = 20 '300            'ODF_COVER_FIX_FLAG

    '@vsfAfterSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMvsfAColTNo As String = ""              '№
    Private Const CMvsfAColTTFT As String = "TFT"           'WF_ID(TFT)
    Private Const CMvsfAColTCF As String = "CF"            'WF_ID(CF)
    Private Const CMvsfAColTFixFlag As String = "Flag"          'ODF_COVER_FIX_FLAG

    '@その他ｸﾞﾘｯﾄの定数
    Private Const CMvsfBeforSlotMapCol As Integer = 3             'ｶﾗﾑ数
    Private Const CMvsfAfterSlotMapCol As Integer = 4             'ｶﾗﾑ数
    Private Const CMlngMaxSlotRows As Integer = 26                'ｽﾛｯﾄﾏｯﾌﾟの行数
    Private Const CMlngSlotNo10Row As Integer = 17                '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№10の行番号
    Private Const CMlngSlotNo16Row As Integer = 11                '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№16の行番号
    Private Const CMlngVsfDispRows As Integer = 10                '頁行
    Private Const CMstrNoInputString As String = "'"              '禁則文字："'"
    Private Const CMlngWFMaxLength As Integer = 10                'ﾛｯﾄIDの最大桁数
    Private Const CMvsfTRow As Integer = 0                        'ﾀｲﾄﾙ行
    Private Const CMlngvsfFrozenCols As Integer = 0               '固定列
    Private Const CMvsfHFontSize As Integer = 12                  'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMvsfHdHeight As Integer = 27 '400              '行の高さ(ﾍｯﾀﾞｰのみ)
    Private Const CMvsfRowHeight As Integer = 43 '640             '行の高さ

    '@その他
    Private Const CMstrDB As String = "0"             'FROM_TYPE(DBから取得)
    Private Const CMstrWP As String = "1"             'FROM_TYPE(WPから取得)

    '@ﾚｽﾎﾟﾝｽ用定数
    Private Const CMstrFormLoad As String = "Form_Load"             'ｲﾍﾞﾝﾄ名称(ﾌｫｰﾑﾛｰﾄﾞ)
    Private Const CMstrKakuteiClick As String = "cmdRegist_Click"      'ｲﾍﾞﾝﾄ名称(確定ﾎﾞﾀﾝ)
    Private Const CMstrMapDownLoadClick As String = "cmdMapDownLoad_Click"  'ｲﾍﾞﾝﾄ名称(貼り合せ実績取得)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypChgSort1 As ChgSort                  'ｿｰﾄ保持用(Befor)
    Private mtypChgSort2 As ChgSort                  'ｿｰﾄ保持用(After)
    Private mblnFirstLoad As Boolean                 'ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ(True：初回　False:初回以降)

    '@ｺﾋﾟﾍﾟ用格納変数
    Private mstrTFTCopy As String                   'BeforTFTWFID退避
    Private mstrTFTPaste As String                  'BeforCFWFID退避
    Private mstrCFCopy As String                    'AfterTFTWFID退避
    Private mstrCFPaste As String                   'AfterCFWFID退避
    Private mtypTFTList As Waferlist                'TFTWF情報格納用構造体

    Private buttonProcessing As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu As Boolean          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose As Boolean                   'NSYS WindowCloseフラグ

    Private ReadOnly flexRDNone   As Boolean = False                   'NSYS ReDraw用
    Private ReadOnly flexRDDirect As Boolean = True                    'NSYS ReDraw用
    Private ReadOnly flexEDNone   As Boolean = False                   'NSYS AllowEditing用
    Private ReadOnly flexEDKbd As Boolean = True                       'NSYS AllowEditing用
    Private ReadOnly vbWhite      As Color = Color.White               'NSYS vbWhite定義
    Private ReadOnly vbYellow     As Color = Color.Yellow              'NSYS vbYellow定義
    Private ReadOnly vbButtonFace As Color = SystemColors.ControlLight 'NSYS ボタンの背

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
        pubVsfMouseWheelManager_Set(vsfAfterSlotMap, cmdAUp, cmdADown)
        pubVsfMouseWheelManager_Set(vsfBeforSlotMap, cmdBUp, cmdBDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 12:45:15 N.Kasai
    '更新日：2006/02/17 (Fri) 09:45:11 N.Kojima
    '備　考：
    '　　　：2006/02/17 (Fri) 09:45:11 N.Kojima     TFT基板ﾛｯﾄのWF情報取得Msgの処理区分を「02→0T」に変更。(R2-27戻り対応)
    Private Sub Form_Load()

        Dim lblnAns As Boolean          '汎用戻り値
        Dim llngCnt As Integer          '汎用ｶｳﾝﾄ
        Dim ltypCFList As Waferlist        'WFおよびﾁｯﾌﾟ情報格納用構造体
        Dim ltypLotCurState As Lotprestate      'ﾛｯﾄ状態格納
        Dim ltypWfOdfListRec As WfOdfListRec     'ODFｳｪﾊ結果取得要求
        Dim ltypWfOdfListAns As WfOdfListAns     'ODFｳｪﾊ結果取得応答

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False

            Me.Left = 0 - My.Settings.FormOffset             'NSYS 初期画面位置設定
            Me.Top = 0

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrFormLoad)

            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfBeforSlotMap_init()
            Call prvvsfAfterSlotMap_init()

            '@WF情報取得(TFT)
            '@CPstrCD0T:有効ｳｪﾊ
            lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                             ptypOdfInfo.strUnloaderCarrier, _
                                             CPstrCD0T, _
                                             mtypTFTList)

            '@取得に成功したら表示
            If lblnAns = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                '@失敗の場合ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrFormLoad)

                Exit Sub
            End If

            '@CF情報の取得
            '@CPstrCD02:全て(ﾁｪｯｸなし)
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                            CPstrCD02, _
                                            ptypOdfInfo.strCFCarrierID, _
                                            ltypLotCurState)
            '@結果判定
            If lblnAns = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                '@失敗の場合ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrFormLoad)

                Exit Sub
            End If

            '@WF情報取得(CF)
            '@CPstrCD0T:有効ｳｪﾊ
            lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                             ptypOdfInfo.strCFCarrierID, _
                                             CPstrCD0T, _
                                             ltypCFList)
            '@結果判定
            If lblnAns = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                '@失敗の場合ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrFormLoad)

                Exit Sub
            End If

            'ODFｳｪﾊ結果要求取得
            With ltypWfOdfListRec
                .strMsgVer = CMstrwf__odflist_Ver                       'Msgﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strCarrierId = ptypOdfInfo.strUnloaderCarrier          'ｷｬﾘｱID
                .strWpID = ptypOdfInfo.strWpID                          '装置ID
                .lngTftWfListCnt = mtypTFTList.lngListCnt               'WF数
                .strFromType = CMstrDB                                  'DBから取得
                '@要素数が0以外ならﾃﾞｰﾀ格納
                If .lngTftWfListCnt > 0 Then
                    '@領域確保
                    Dim typTftWfListTmp As TftWfList = New TftWfList

                    '@格納
                    .typTftWfList = New List(Of TftWfList)
                    For llngCnt = 0 To mtypTFTList.lngListCnt -1

                        typTftWfListTmp = New TftWfList
                        typTftWfListTmp.strWfId  = mtypTFTList.typWfList(llngCnt).strWfId    'WF数
                        .typTftWfList.Add(typTftWfListTmp)

                    Next llngCnt
                End If
            End With

            '@ODFｳｪﾊ結果取得
            lblnAns = pubblnWfOdfList_Sel(ltypWfOdfListRec, ltypWfOdfListAns)
            '@結果判定
            If lblnAns = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                '@失敗の場合ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrFormLoad)

                Exit Sub
            End If

            '@----------
            '@ﾍｯﾀﾞ部表示
            '@----------
            '@TFT/CF情報
            Call prvMainHeder_Disp(ltypLotCurState)

            '@----------
            '@明細部表示
            '@----------
            '@貼り合せ前ｽﾛｯﾄ
            Call prvBeforSlotMap_Disp(mtypTFTList, ltypCFList)
            '@貼り合せ後ｽﾛｯﾄ
            Call prvAfterSlotMap_Disp(ltypWfOdfListAns)

            '@ｽﾛｯﾄﾏｯﾌﾟ初期表示位置設定
            Call prvVsfSlotMapTopRow_Set(vsfBeforSlotMap)
            Call prvVsfSlotMapTopRow_Set(vsfAfterSlotMap)

            '@----------
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
            '@----------
            '@↓2006/01/17 (Tue) 17:57:48 N.Kasai **************************************************
            If ptypOdfInfo.strOdfCoverFixFlag = "1" Then
                cmdMapDownLoad.Enabled = False      '貼り合せ実績取得
            Else
                cmdMapDownLoad.Enabled = True       '貼り合せ実績取得
            End If
            '@↑2006/01/17 (Tue) 17:57:48 N.Kasai **************************************************
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, CMstrFormLoad)

            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            '@ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ(True：初回　False:初回以降)
            mblnFirstLoad = True

            '@確定ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            lblnAns = prvblncmdRegist_Chk
            '@結果判定
            If lblnAns = False Then
                cmdRegist.Enabled = False
            Else
                cmdRegist.Enabled = True
            End If

            '@全部取消ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            lblnAns = prvblncmdClear_Chk
            '@結果判定
            If lblnAns = False Then
                cmdClear.Enabled = False
            Else
                cmdClear.Enabled = True
            End If

            '@構造体の初期化(dept)
            With mtypChgSort1
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If Not IsNothing(.typChgSortList) Then
                    .typChgSortList.Clear
                    .typChgSortList = Nothing
                End If

                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False

                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With

            '@構造体の初期化(AfterList)
            With mtypChgSort2
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If Not IsNothing(.typChgSortList) Then
                    .typChgSortList.Clear
                    .typChgSortList = Nothing
                End If

                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False

                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With

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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/25 (Wed) 11:38:24 N.Kasai
    '更新日：2005/05/25 (Wed) 11:38:24
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

           '@Form_Loadﾌﾗｸﾞ(正常)
           If pblnFormLoad = True Then
                '@初回のみ
                If mblnFirstLoad = True Then
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose

                    '@初回ﾌﾗｸﾞ初期化
                    mblnFirstLoad = False

                    '@FTP結果判定処理
                    Call prvblnFTP_Chk()

                    'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
                    'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
                    Dim lfuncActivate As Action = Sub()
                        Me.Activate()
                    End Sub
                    Me.BeginInvoke(lfuncActivate)
                End If
            Else
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
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
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 12:45:32 N.Kasai
    '更新日：2005/05/19 (Thu) 12:45:32
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Dim lblnAns As Boolean      '汎用戻り値

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

            Select Case ActiveControl.Name
                '@Beforｸﾞﾘｯﾄﾞ
                Case vsfBeforSlotMap.Name
                    '@ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfBeforSlotMap, cmdBUp, cmdBDown)

                    '@ｺﾋﾟﾍﾟ対応(Ctrl+C)
                    If e.Control = True Then
                        Select Case e.KeyCode
                            '@ｺﾋﾟｰ
                            Case Keys.C
                                With vsfBeforSlotMap
                                    Select Case .Col
                                        Case CMvsfBColCF
                                            mstrCFCopy = .GetData(.Row, .Col)
                                    End Select
                                End With
                        End Select
                    End If

                '@Afterｸﾞﾘｯﾄﾞ
                Case vsfAfterSlotMap.Name
                    '@ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfAfterSlotMap, cmdAUp, cmdADown)

                    '@ｺﾋﾟﾍﾟ対応(Ctrl+V)
                    If e.Control = True Then
                        Select Case e.KeyCode
                            '@ｺﾋﾟｰ
                            Case Keys.V
                                With vsfAfterSlotMap
                                    '@ｽﾛｯﾄﾏｯﾌﾟ対象外の場合は貼り付け不可
                                    If .GetData(.Row, CMvsfAColTFT) <> vbNullString Then
                                        Select Case .Col
                                            Case CMvsfAColCF

                                                '@↓2006/01/17 (Tue) 16:09:43 N.Kasai **************************************************
                                                '@貼り合せ前の場合は貼り付け可
                                                If .GetData(.Row, CMvsfAColFixFlag) <> "1" Then
                                                    .SetData(.Row, .Col, mstrCFCopy)
                                                    mstrCFCopy = vbNullString
                                                End If
                                                '@↑2006/01/17 (Tue) 16:09:43 N.Kasai **************************************************
                                        End Select

                                        '@確定ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
                                        lblnAns = prvblncmdRegist_Chk

                                        '@結果判定
                                        If lblnAns = False Then
                                            cmdRegist.Enabled = False
                                        Else
                                            cmdRegist.Enabled = True
                                        End If

                                        '@全部取消ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
                                        lblnAns = prvblncmdClear_Chk
                                        '@結果判定
                                        If lblnAns = False Then
                                            cmdClear.Enabled = False
                                        Else
                                            cmdClear.Enabled = True
                                        End If
                                    End If
                                End With
                        End Select
                    End If
            End Select

            '@Enterｷｰの場合
            Select Case e.KeyCode
                Case Keys.Return
                    If ActiveControl IsNot vsfAfterSlotMap.Editor Then
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    End If
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
    '機　能：画面終了
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：終了方法
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 16:31:30 N.Kasai
    '更新日：2005/05/09 (Mon) 16:31:30
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim ltypTFTList As Waferlist      'TFTWF情報格納用構造体

        Try
           
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKeyを受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

            '@構造体のｸﾘｱ
            mtypTFTList = ltypTFTList

            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If Not IsNothing(mtypChgSort1.typChgSortList) Then
                mtypChgSort1.typChgSortList.Clear
                mtypChgSort1.typChgSortList = Nothing
            End If

            If Not IsNothing(mtypChgSort2.typChgSortList) Then
                mtypChgSort2.typChgSortList.Clear
                mtypChgSort2.typChgSortList = Nothing
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

    '関数名：cmdClear_Click
    '機　能：全部取消ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 13:12:20 N.Kasai
    '更新日：2005/05/19 (Thu) 13:12:20
    '備　考：
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Dim llngCnt As Integer  '汎用ｶｳﾝﾄ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfAfterSlotMap
                '@描画なし
                .Redraw = flexRDNone

                '@WF枚数分ﾙｰﾌﾟ(cf)
                llngCnt = 1
                Do While CMlngMaxSlotRows > llngCnt

                    If vsfAfterSlotMap.GetData(llngCnt, CMvsfAColFixFlag) <> "1" Then
                        '@ﾃﾞｰﾀｸﾘｱ
                        vsfAfterSlotMap.SetData(llngCnt, CMvsfAColCF, vbNullString)          'WFID(cf)
                    End If

                    '@行の高さ
                    .Rows(llngCnt).Height = CMvsfRowHeight

                    '@ｶｳﾝﾄｱｯﾌﾟ
                    llngCnt = llngCnt + 1
                Loop

                '@書式設定
                .Cols(CMvsfAColNo).TextAlign = TextAlignEnum.LeftCenter                '左詰の中央揃え(№)
                .Cols(CMvsfAColTFT).TextAlign = TextAlignEnum.LeftCenter               '左詰の中央揃え(WFID(TFT))
                .Cols(CMvsfAColCF).TextAlign = TextAlignEnum.LeftCenter                '左詰の中央揃え(WFID(CF))

                '@ﾍｯﾀﾞｰの高さ設定
                .Rows(CMvsfTRow).Height = CMvsfHdHeight

                '@直接描画なし
                .Redraw = flexRDDirect

                '@ﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfAfterSlotMap)
            End With

            '@確定ﾎﾞﾀﾝ使用不可
            cmdRegist.Enabled = False

            '@全部取消ﾎﾞﾀﾝ使用不可
            cmdClear.Enabled = False

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

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/20 (Fri) 13:58:17 N.Kasai
    '更新日：2005/05/20 (Fri) 13:58:17
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns As Boolean                  '結果取得(True:正常,False:異常)
        Dim ltypWfChgOdfRec As WfChgOdfRec              '@ODFｳｪﾊ登録要求格納構造体
        Dim llngCnt As Integer                  '汎用ｶｳﾝﾀ
        Dim llngSlotCnt As Integer                  '構造体格納番号
        Dim lstrMsg As String                   'ﾒｯｾｰｼﾞ内容格納
        Dim lstrCoverFlag As String                   '貼り合せ結果格納
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

            '@確定ﾎﾞﾀﾝ入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk
            '@結果判定
            If lblnAns = False Then
                '@ｴﾗｰあり
                Exit Sub
            End If

            'ODF予約情報とのTFT/CFのWF確認
            'ODF予約情報が無い場合は、作業開始で確認済みなので、ここで情報が無い場合は、ユーザーが承知しているので
            'ここでは予約情報がある場合のWFを確認する
            Call prvOdfReserveCfWf_Chk()

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ODFｳｪﾊ登録要求データ格納
            With ltypWfChgOdfRec
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstrwf__chgodf__Ver

                '@SBID
                .strSbID = pstrSBID

                '@対象件数格納
                .lngOdfListCnt = lblTftWfNum.Text            'WF枚数
                llngSlotCnt = 1

                '@ODF情報格納
                .typOdfList = New List(Of OdfList)
                Dim typOdfListTmp As OdfList = New OdfList

                For llngCnt = 1 To vsfAfterSlotMap.Rows.Count - 1
                    If vsfAfterSlotMap.GetData(llngCnt, CMvsfAColTFT) <> vbNullString Then

                        typOdfListTmp = New OdfList

                        typOdfListTmp.strSlotPosition _
                            = vsfAfterSlotMap.GetData(llngCnt, CMvsfAColNo)           'ｽﾛｯﾄﾅﾝﾊﾞｰ

                        typOdfListTmp.strTftWfID _
                            = vsfAfterSlotMap.GetData(llngCnt, CMvsfAColTFT)           'WF_ID(TFT)

                        typOdfListTmp.strCfWfID _
                            = vsfAfterSlotMap.GetData(llngCnt, CMvsfAColCF)            'WF_ID(CF)

                        .typOdfList.Add(typOdfListTmp)

                        llngSlotCnt = llngSlotCnt + 1
                    End If
                Next llngCnt
            End With

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrKakuteiClick)

            '@ﾌｫｰﾑﾛｯｸ
            'Me.Enabled = False

            '@ﾒｯｾｰｼﾞ送信【ODFｳｪﾊ登録】
            lblnAns = pubblnWfCngOdf_Upd(ltypWfChgOdfRec, lstrCoverFlag)
            '@結果取得
            If lblnAns = True Then
                '@ﾌｫｰﾑﾛｯｸ解除
                'Me.Enabled = True

                '@表示ﾒｯｾｰｼﾞ変換("<TRM4UI>$$ODF貼り合わせ登録しました。キャリア[%1] ロット[%2]")
                lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf004U, lblTftCarrierID.Text, lblTftLotID.Text)
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(lstrMsg)

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, CMstrKakuteiClick)

                '@貼り合せ成功の場合
                ptypLotprestate.strCoverFlag = lstrCoverFlag

                '@画面終了
                Call cmdClose_Click(cmdClose, New EventArgs)
            Else
                '@ﾌｫｰﾑﾛｯｸ解除
                'Me.Enabled = True

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrKakuteiClick)
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

    '関数名：cmdMapDownLoad_Click
    '機　能：貼り合せ実績取得ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 13:14:17 N.Kasai
    '更新日：2005/05/19 (Thu) 13:14:17
    '備　考：
    Private Sub cmdMapDownLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMapDownLoad.Click

        Dim ltypWfOdfListRec As WfOdfListRec     'ODFｳｪﾊ結果取得要求
        Dim ltypWfOdfListAns As WfOdfListAns     'ODFｳｪﾊ結果取得応答
        Dim llngSlotCnt As Integer          '構造体格納№
        Dim llngCnt As Integer          '汎用ｶｳﾝﾀ
        Dim lblnAns As Boolean          '汎用戻り値

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

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@↓2006/01/17 (Tue) 16:08:43 N.Kasai **************************************************
            '    '@一度ｸﾘｱ後取得する
            '    Call cmdClear_Click
            '@↑2006/01/17 (Tue) 16:08:43 N.Kasai **************************************************

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrMapDownLoadClick)

            '@ﾌｫｰﾑﾛｯｸ
            'Me.Enabled = False

            'NSYS　リストの初期化
            ltypWfOdfListRec = New WfOdfListRec
            ltypWfOdfListRec.typTftWfList = New List(Of TftWfList)

            '@ODFｳｪﾊ結果取得
            With ltypWfOdfListRec
                .strMsgVer = CMstrwf__odflist_Ver                           'Msgﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strCarrierId = ptypOdfInfo.strUnloaderCarrier              'ｷｬﾘｱID
                .strWpID = ptypOdfInfo.strWpID                              '装置ID
                .lngTftWfListCnt = lblTftWfNum.Text                      'WF枚数

                '@↓2006/01/17 (Tue) 16:06:25 N.Kasai **************************************************
                '        .strFromType = CMstrWP                                      'WPから取得
                .strFromType = CMstrDB                                      'DBから取得
                '@↑2006/01/17 (Tue) 16:06:25 N.Kasai **************************************************

                '@要素数が0以外ならﾃﾞｰﾀ格納
                If .lngTftWfListCnt > 0 Then
                    '@領域確保
                    Dim typTftWfListTmp As TftWfList = New TftWfList
                    '@構造体格納№の初期化
                    llngSlotCnt = 1
                    '@格納
                    For llngCnt = 1 To vsfBeforSlotMap.Rows.Count - 1

                        typTftWfListTmp = New TftWfList
                             
                        If vsfBeforSlotMap.GetData(llngCnt, CMvsfBColTFT) <> vbNullString Then
                            typTftWfListTmp.strWfId _
                                = vsfBeforSlotMap.GetData(llngCnt, CMvsfBColTFT)               'WF_ID(TFT)

                            .typTftWfList.Add(typTftWfListTmp)

                            llngSlotCnt = llngSlotCnt + 1
                        End If
                    Next llngCnt
                End If
            End With

            lblnAns = pubblnWfOdfList_Sel(ltypWfOdfListRec, ltypWfOdfListAns)
            '@結果判定
            If lblnAns = False Then
                '@ﾌｫｰﾑﾛｯｸ解除
                'Me.Enabled = True

                '@失敗の場合ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrMapDownLoadClick)

                Exit Sub
            Else
                '@ﾌｫｰﾑﾛｯｸ解除
                'Me.Enabled = True
            End If

            '@貼り合せ後ｽﾛｯﾄ表示
            Call prvAfterSlotMap_Disp(ltypWfOdfListAns)

            '@ｽﾛｯﾄﾏｯﾌﾟ初期表示位置設定
            Call prvVsfSlotMapTopRow_Set(vsfAfterSlotMap)

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, CMstrMapDownLoadClick)

            '@ftp転写結果ﾁｪｯｸ
            lblnAns = prvblnFTP_Chk
            '@結果判定
            If lblnAns = False Then
                Call pubSetFocus(vsfAfterSlotMap)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMapDownLoad_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 15:58:57 N.Kasai
    '更新日：2005/05/09 (Mon) 15:58:57
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾌｫｰﾑを閉じる
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

    '関数名：cmdBUp_Click
    '機　能：前ﾍﾟｰｼﾞ(dept)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 15:53:32 N.Kasai
    '更新日：2005/05/09 (Mon)
    '備　考：
    Private Sub cmdBUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfBeforSlotMap, cmdBUp, cmdBDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdBUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdBDown_Click
    '機　能：次ﾍﾟｰｼﾞ(dept)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 15:53:46 N.Kasai
    '更新日：2005/05/09 (Mon) 15:53:46
    '備　考：
    Private Sub cmdBDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfBeforSlotMap, cmdBUp, cmdBDown, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdBDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdAUp_Click
    '機　能：全頁(AfterList)
    '引　数：なし
    '戻り値：
    '作成日：2005/05/09 (Mon) 15:54:33 N.Kasai
    '更新日：2005/05/09 (Mon) 15:54:33
    '備　考：
    Private Sub cmdAUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
                '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
                Call pubVsfCmdUp(vsfAfterSlotMap, cmdAUp, cmdADown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdAUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdADown_Click
    '機　能：次頁(AfterList)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 15:54:30 N.Kasai
    '更新日：2005/05/09 (Mon) 15:54:30
    '備　考：
    Private Sub cmdADown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdADown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfAfterSlotMap, cmdAUp, cmdADown, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdADown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAfterSlotMap_AfterEdit
    '機　能：貼り付け後ｸﾞﾘｯﾄﾞ編集後処理
    '引　数：Row：対象行
    '　　　：Col：対象列
    '戻り値：なし
    '作成日：2005/05/26 (Thu) 11:26:56 N.Kasai
    '更新日：2005/05/26 (Thu) 11:26:56
    '備　考：
    Private Sub vsfAfterSlotMap_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfAfterSlotMap.AfterEdit

        Dim lblnAns As Boolean

        Try
            '@確定ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            lblnAns = prvblncmdRegist_Chk
            '@結果判定
            If lblnAns = False Then
                cmdRegist.Enabled = False
            Else
                cmdRegist.Enabled = True
            End If

            '@全部取消ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            lblnAns = prvblncmdClear_Chk
            '@結果判定
            If lblnAns = False Then
                cmdClear.Enabled = False
            Else
                cmdClear.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfAfterSlotMap_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAfterSlotMap_BeforeEdit
    '機　能：貼り付け後ｸﾞﾘｯﾄﾞ編集前処理
    '引　数：Row：対象行
    '　　　：Col：対象列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/05/24 (Tue) 15:40:24 N.Kasai
    '更新日：2005/05/24 (Tue) 15:40:24
    '備　考：
    Private Sub vsfAfterSlotMap_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfAfterSlotMap.SetupEditor

        Try
           
            With vsfAfterSlotMap

                '@固定行の場合はｽｷｯﾌﾟ
                If e.Row < .Rows.Fixed Then
                    e.Cancel = True
                    Exit Sub
                End If

                '@入力対象不可の場合はｽｷｯﾌﾟ
                If .GetData(.Row, CMvsfAColTFT) = vbNullString Then
                    Exit Sub
                End If

                '@↓2006/01/17 (Tue) 16:12:14 N.Kasai **************************************************
                '@確定済みの場合はｽｷｯﾌﾟ
                If .GetData(.Row, CMvsfAColFixFlag) = "1" Then
                    Exit Sub
                End If
                '@↑2006/01/17 (Tue) 16:12:14 N.Kasai **************************************************


                '@最大入力文字数の設定
                '@10ﾊﾞｲﾄ迄入力可能
                CType(.Editor, TextBox).MaxLength = CMlngWFMaxLength
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfAfterSlotMap_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAfterSlotMap_BeforeRowColChange
    '機　能：vsfAfterｸﾞﾘｯﾄﾞ編集後処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/05/26 (Thu) 10:07:02 N.Kasai
    '更新日：2005/05/26 (Thu) 10:07:02
    '備　考：
    Private Sub vsfAfterSlotMap_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfAfterSlotMap.BeforeRowColChange


        Dim OldRow                  As Integer              'NSYS 
        Dim NewRow                  As Integer              'NSYS 
        Dim NewCol                  As Integer              'NSYS 

        Try
            OldRow = e.OldRange.r1
            NewRow = e.NewRange.r1
            NewCol = e.NewRange.c1 

            'NSYS データ行がない場合は処理を抜ける
            If vsfAfterSlotMap.Rows.Count <= vsfAfterSlotMap.Rows.Fixed Then
                Return
            End If
            
            '@ﾌｫｰﾑﾛｰﾄﾞ中は処理しない
            If pblnFormLoad = False Then
                Exit Sub
            End If

            With vsfAfterSlotMap
                '@ﾃﾞｰﾀ行ではない場合は抜ける
                If NewRow < .Rows.Fixed Then
                    Exit Sub
                End If

                '@CFWFIDのみ編集可
                If NewCol = CMvsfAColCF Then

                    '@↓2006/01/17 (Tue) 16:13:39 N.Kasai **************************************************
                    '@確定済みの場合はｽｷｯﾌﾟ
                    If .GetData(NewRow, CMvsfAColFixFlag) = "1" Then
                        '@変更不可
                        .AllowEditing = flexEDNone
                        Exit Sub
                    End If
                    '@↑2006/01/17 (Tue) 16:13:39 N.Kasai **************************************************

                    '@変更可否判定
                    If .GetData(NewRow, CMvsfAColTFT) <> vbNullString Then
                        '@変更可
                        .AllowEditing = flexEDKbd
                    Else
                        '@変更不可
                        .AllowEditing = flexEDNone
                    End If
                Else
                    '@変更不可
                    .AllowEditing = flexEDNone
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfAfterSlotMap_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAfterSlotMap_EnterCell
    '機　能：ｸﾞﾘｯﾄﾞ編集
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/26 (Thu) 12:48:11 N.Kasai
    '更新日：2005/05/26 (Thu) 12:48:11
    '備　考：
    Private Sub vsfAfterSlotMap_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfAfterSlotMap.EnterCell

        Dim lblnAns As Boolean      '@汎用戻り値

        Try

            '@確定ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            lblnAns = prvblncmdRegist_Chk
            '@結果判定
            If lblnAns = False Then
                cmdRegist.Enabled = False
            Else
                cmdRegist.Enabled = True
            End If

            '@全部取消ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            lblnAns = prvblncmdClear_Chk
            '@結果判定
            If lblnAns = False Then
                cmdClear.Enabled = False
            Else
                cmdClear.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfAfterSlotMap_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAfterSlotMap_ValidateEdit
    '機　能：貼り付け後ｸﾞﾘｯﾄﾞ編集
    '引　数：Row：対象行
    '　　　：Col：対象列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/05/24 (Tue) 15:53:57 N.Kasai
    '更新日：2005/05/24 (Tue) 15:53:57
    '備　考：
    Private Sub vsfAfterSlotMap_ValidateEdit(ByVal sender As Object, ByVal e As ValidateEditEventArgs) Handles vsfAfterSlotMap.ValidateEdit

        Dim llngCnt As Integer  '@汎用ｶｳﾝﾀ

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfAfterSlotMap.Rows.Count <= vsfAfterSlotMap.Rows.Fixed Then
                Return
            End If

            '@入力ﾁｪｯｸ
            With vsfAfterSlotMap
                '@読込判定
                If .Row < 1 Then
                    Exit Sub
                End If

                '@入力対象不可の場合はｽｷｯﾌﾟ
                If .GetData(.Row, CMvsfAColTFT) = vbNullString Then
                    Exit Sub
                End If

                '@確定済みの場合はｽｷｯﾌﾟ
                If .GetData(.Row, CMvsfAColFixFlag) = "1" Then
                    Exit Sub
                End If

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
                    'NSYS 値を変更前に戻す
                    .Editor.Text = .GetData(.Row,.Col)
                    '@ｷｬﾝｾﾙ
                    e.Cancel = True
                    Exit Sub
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfAfterSlotMap_ValidateEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAfterSlotMap_KeyDown
    '機　能：貼り付け後ｸﾞﾘｯﾄﾞ入力制限
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2005/05/24 (Tue) 15:51:38 N.Kasai
    '更新日：2005/05/24 (Tue) 15:51:38
    '備　考：
    Private Sub vsfAfterSlotMap_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfAfterSlotMap.KeyDown

        Try

            With vsfAfterSlotMap
                Select Case e.KeyCode
                    '@Delete/BackSpaceｷｰの場合
                    Case Keys.Delete, Keys.Back

                        '@↓2006/01/17 (Tue) 16:19:48 N.Kasai **************************************************
                        '@貼り合せ後CFWF_IDの場合
                        If .Col = CMvsfAColCF Then
                            '@確定済み以外
                            If .GetData(.Row, CMvsfAColFixFlag) <> "1" Then
                                '@Nullにする
                                .SetData(.Row, .Col, vbNullString)
                                '@編集処理
                                .StartEditing()

                                If e.KeyCode = Keys.Back AndAlso (TypeOf .Editor Is TextBox)
                                    CType(.Editor, TextBox).Clear()
                                End If
                            End If
                            '@↑2006/01/17 (Tue) 16:19:48 N.Kasai **************************************************

                        End If
                    Case Keys.Space
                        '[F2][Space]キー
                        e.SuppressKeyPress = True 

                End Select
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfAfterSlotMap_KeyDown"
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
    '関数名：prvMainHeder_Disp
    '機　能：画面初期設定(ﾍｯﾀﾞ)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 09:33:17 N.Kasai
    '更新日：2005/05/20 (Fri) 10:35:41 N.Kasai
    '備　考：
    Private Sub prvMainHeder_Disp(ByRef ltypLotCurState As Lotprestate)

        Try

            '@ﾍｯﾀﾞ部引継ぎ
            '@tft情報
            With ptypOdfInfo
                lblTftCarrierID.Text = .strUnloaderCarrier                           'TFTｷｬﾘｱID
                lblTftLotID.Text = .strLotID                                         'TFTﾛｯﾄID
                lblTftFlowClass.Text = .strFlowClass                                 '種別
                lblTftPdID.Text = .strPdId                                           '機種
                lblTftStatus.Text = .strStatus                                       '状態
                lblTftWfNum.Text = .strWfNum                                         '数量(WF)
                '数量(CHIP)
                If IsNumeric(.strChipNum) = True Then
                    lblTftChipNum.Text = Format$(CLng(.strChipNum), CPstrCFKnmaFormat)         
                Else
                    lblTftChipNum.Text = .strChipNum
                End If
                lblCfCarrierID.Text = .strCFCarrierID                                'CFｷｬﾘｱID
            End With

            '@cfｷｬﾘｱ情報
            With ltypLotCurState
                lblCfLotID.Text = .strLotID                                          'CFﾛｯﾄID
                lblCfFlowClass.Text = .strFlowClass                                  '種別
                lblCfPdID.Text = .strPdId                                            '機種
                lblCfStatus.Text = .strNowST                                         '状態
                lblCfWfNum.Text = .strWfNum                                          '数量(WF)
                '数量(CHIP)
                If IsNumeric(.strChipQuantity) = True Then
                    lblCfChipNum.Text = Format$(CLng(.strChipQuantity), CPstrCFKnmaFormat)  
                Else
                    lblCfChipNum.Text =.strChipQuantity
                End If
            End With

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用不可
            cmdClear.Enabled = False                                                    '全部取消
            cmdMapDownLoad.Enabled = False                                              '貼り合せ実績取得
            cmdRegist.Enabled = False                                                   '確定

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMainHeder_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfBeforSlotMap_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/28 (Thu) 11:40:01 N.Kasai
    '更新日：2005/04/28 (Thu) 11:40:01
    '備　考：
    Private Sub prvvsfBeforSlotMap_init()

        Dim lFixedlStyle As CellStyle 'NSYS スタイル定義

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfBeforSlotMap

                'NSYS スタイルを変数に設定
                lFixedlStyle = .Styles.Fixed

                '@描画なし
                .Redraw = flexRDNone
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                '@列数設定
                .Cols.Count = CMvsfBeforSlotMapCol
                '@固定列の設定
                .Cols.Frozen = CMlngvsfFrozenCols
                '@行列のﾏｳｽでの変更を不可にする
                .AllowResizing = AllowResizingEnum.None
                ''@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                '.FillStyle = flexFillRepeat
                ''@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowBigSelection = False
                ''@ﾏｳｽでｾﾙ範囲選択不可
                '.AllowSelection = False
                '@ｾﾙ選択の設定
                .SelectionMode = SelectionModeEnum.Default
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                '@ﾊｲﾗｲﾄ表示
                .HighLight = .HighLight = HighLightEnum.WithFocus
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.None
                '@編集可否(不可)
                .AllowEditing = flexEDNone

                '@一覧表の表題設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngBlueColor")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor) '背景色
                newStyle.ForeColor = vbYellow                                  '文字色
                'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                With .Font                                              
                    newStyle.Font = New Font(.FontFamily, CMvsfHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                '@見出し行の文字位置設定
                newStyle.TextAlign = TextAlignEnum.CenterCenter

                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed - 1, .Cols.Fixed -1, .Rows.Fixed - 1, .Cols.Count - 1)
                cellRange.Style = newStyle

                '@列の調整を不可にする
                '.AutoSizeMode = flexAutoSizeColWidth

                '@表示位置設定
                .Cols(CMvsfBColNo).TextAlign = TextAlignEnum.LeftTop          '№
                .Cols(CMvsfBColTFT).TextAlign = TextAlignEnum.LeftTop         'WF_IF(TFT)
                .Cols(CMvsfBColCF).TextAlign = TextAlignEnum.LeftTop          'WF_ID(CF)

                '@列幅設定
                .Cols(CMvsfBColNo).Width = CMvsfBColWNo                       '№
                .Cols(CMvsfBColTFT).Width = CMvsfBColWTFT                     'WF_IF(TFT)
                .Cols(CMvsfBColCF).Width = CMvsfBColWCF                       'WF_ID(CF)

                'ﾀｲﾄﾙ設定
                .SetData(CMvsfTRow, CMvsfBColNo, CMvsfBColTNo)    '№
                .SetData(CMvsfTRow, CMvsfBColTFT, CMvsfBColTTFT)  'WF_IF(TFT)
                .SetData(CMvsfTRow, CMvsfBColCF, CMvsfBColTCF)    'WF_ID(CF)


                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMvsfTRow).Height = CMvsfHdHeight                       '高さ

                '@非表示設定
                '@なし

                '@直接描画
                .Redraw = flexRDDirect

                '@ﾛｯｸ
                .Enabled = False

                '@ｽｸﾛｰﾙﾎﾞﾀﾝ
                cmdBUp.Enabled = False                   '前頁
                cmdBDown.Enabled = False                 '後頁
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfBeforSlotMap_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfAfterSlotMap_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/28 (Thu) 11:40:01 N.Kasai
    '更新日：2005/04/28 (Thu) 11:40:01
    '備　考：
    Private Sub prvvsfAfterSlotMap_init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfAfterSlotMap
                '@描画なし
                .Redraw = flexRDNone
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                '@列数設定
                .Cols.Count = CMvsfAfterSlotMapCol
                '@固定列の設定
                .Cols.Frozen = CMlngvsfFrozenCols
                '@行列のﾏｳｽでの変更を不可にする
                .AllowResizing = AllowResizingEnum.None
                ''@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                '.FillStyle = flexFillRepeat
                ''@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowBigSelection = False
                ''@ﾏｳｽでｾﾙ範囲選択不可
                '.AllowSelection = False
                '@ｾﾙ選択の設定
                .SelectionMode = SelectionModeEnum.Default
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                '.Ellipsis = flexEllipsisEnd
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                '@ﾊｲﾗｲﾄ表示
                .HighLight = .HighLight = HighLightEnum.WithFocus
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.None
                '@編集可否(可能)
                .AllowEditing = flexEDKbd
                'NSYS 編集モード時にセルの背景を白にする
                .Styles.Editor.BackColor = SystemColors.Window 
                .Styles.Editor.ForeColor = Color.Black

                '@一覧表の表題設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngBlueColor")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor) '背景色
                newStyle.ForeColor = vbYellow                                  '文字色
                'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                With .Font                                              
                    newStyle.Font = New Font(.FontFamily, CMvsfHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                '@見出し行の文字位置設定
                newStyle.TextAlign = TextAlignEnum.CenterCenter

                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed - 1, .Cols.Fixed -1, .Rows.Fixed - 1, .Cols.Count - 1)
                cellRange.Style = newStyle

                '@列の調整を不可にする
                '.AutoSizeMode = flexAutoSizeColWidth

                '@表示位置設定
                .Cols(CMvsfAColNo).TextAlign = TextAlignEnum.LeftTop                       '№
                .Cols(CMvsfAColTFT).TextAlign = TextAlignEnum.CenterCenter                 'WF_ID(TFT)
                .Cols(CMvsfAColCF).TextAlign = TextAlignEnum.LeftTop                       'WF_ID(CF)
                .Cols(CMvsfAColFixFlag).TextAlign = TextAlignEnum.LeftTop                  'ODF_COVER_FIX_FLAG

                '@列幅設定
                .Cols(CMvsfAColNo).Width = CMvsfAColWNo                               '№
                .Cols(CMvsfAColTFT).Width = CMvsfAColWTFT                             'WF_ID(TFT)
                .Cols(CMvsfAColCF).Width = CMvsfAColWCF                               'WF_ID(CF)
                .Cols(CMvsfAColFixFlag).Width = CMvsfAColWFixFlag                     'ODF_COVER_FIX_FLAG

                'ﾀｲﾄﾙ設定
                .SetData(CMvsfTRow, CMvsfAColNo, CMvsfAColTNo)            '№
                .SetData(CMvsfTRow, CMvsfAColTFT, CMvsfAColTTFT)          'WF_ID(TFT)
                .SetData(CMvsfTRow, CMvsfAColCF, CMvsfAColTCF)            'WF_ID(CF)
                .SetData(CMvsfTRow, CMvsfAColFixFlag, CMvsfAColTFixFlag)  'ODF_COVER_FIX_FLAG

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMvsfTRow).Height = CMvsfHdHeight                               '高さ

                '@非表示設定
                .Cols(CMvsfAColFixFlag).Visible = False                             'ODF_COVER_FLAG

                '@直接描画
                .Redraw = flexRDDirect

                '@ﾛｯｸ
                .Enabled = False

                '@ｽｸﾛｰﾙﾎﾞﾀﾝ
                cmdAUp.Enabled = False                   '前頁
                cmdADown.Enabled = False                 '後頁

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfAfterSlotMap_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvBeforSlotMap_Disp
    '機　能：貼り合せ前ｽﾛｯﾄ一覧表示
    '引　数：ltypTFTList：TFTｳｴﾊ情報格納
    '　　　：ltypCFList：CFｳｴﾊ情報格納
    '戻り値：なし
    '作成日：2005/05/24 (Tue) 15:44:52 N.Kasai
    '更新日：2005/05/24 (Tue) 15:44:52
    '備　考：
    Private Sub prvBeforSlotMap_Disp(ByRef ltypTFTList As Waferlist, ByRef ltypCFList As Waferlist)

        Dim llngCnt As Integer  '汎用ｶｳﾝﾄ
        Dim llngWriteRow As Integer  'ｽﾛｯﾄﾏｯﾌﾟ位置

        Try

            '@---------------
            '@0件の場合
            '@---------------
            With vsfBeforSlotMap
                If ltypTFTList.lngListCnt = 0 Then
                    '@ﾛｯｸ
                    .Enabled = False
                    '@描画なし
                    .Redraw = flexRDNone
                    '@ﾘｽﾄ行数格納
                    .Rows.Count = .Rows.Fixed
                    '@直接描画なし
                    .Redraw = flexRDDirect
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用不可
                    cmdBUp.Enabled = False
                    cmdBDown.Enabled = False
                    Exit Sub
                End If
            End With

            '@---------------
            '@件数ありの場合
            '@---------------
            With vsfBeforSlotMap
                '@ｸﾞﾘｯﾄﾞのﾛｯｸ解除
                .Enabled = True
                '@描画なし
                .Redraw = flexRDNone
                '@ﾘｽﾄ行数格納
                .Rows.Count = .Rows.Fixed
                .Rows.Count = CMlngMaxSlotRows
                '@行選択
                .Select(CMvsfTRow, .Cols.Fixed, CMvsfTRow, .Cols.Count - 1)

                '@---------------
                '@ｽﾛｯﾄ№を設定(TFTをﾒｲﾝに考えてます)
                '@---------------
                '@ｶｳﾝﾀ初期化
                llngCnt = 1
                '@ｽﾛｯﾄﾏｯﾌﾟ分ﾙｰﾌﾟ
                Do While .Rows.Count > llngCnt

                    '@MAXｽﾛｯﾄ以上の判定
                    If ltypTFTList.strSlotSize >= llngCnt Then
                        '@ｽﾛｯﾄ№
                        .SetData(.Rows.Count - llngCnt, CMvsfBColNo, Format$(llngCnt, CPstrSlotNoFormat))
                    Else
                        '@ｽﾛｯﾄ№(空白)
                        .SetData(.Rows.Count - llngCnt, CMvsfBColNo, vbNullString)
                    End If

                    '@ｽﾛｯﾄｻｲｽﾞを判定しﾊﾞｯｸｶﾗｰ変更
                    If ltypTFTList.strSlotSize >= .Rows.Count - llngCnt Then
                        '@ﾊﾞｯｸｶﾗｰ(薄ｸﾞﾚｰ)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfBColTFT, llngCnt, CMvsfBColCF)
                        cellRange.Style = newStyle
                    Else
                        '@ﾊﾞｯｸｶﾗｰ(ｸﾞﾚｰ)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbButtonFace")
                        newStyle.BackColor = vbButtonFace
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfBColTFT, llngCnt, CMvsfBColCF)
                        cellRange.Style = newStyle
                    End If

                    '@行の高さ
                    .Rows(llngCnt).Height = CMvsfRowHeight

                    llngCnt = llngCnt + 1
                Loop

                '@---------------
                '@ﾃﾞｰﾀ表示
                '@---------------
                '@WF枚数分ﾙｰﾌﾟ(tft)
                llngCnt = 0
                Do While ltypTFTList.lngListCnt -1 >= llngCnt
                    With ltypTFTList.typWfList(llngCnt)
                        '@書き込み行設定
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが数値の場合のみ
                        If IsNumeric(.strSlotPosition) = True Then
                            llngWriteRow = CMlngMaxSlotRows - CLng(.strSlotPosition)
                            '@ﾃﾞｰﾀ表示
                            vsfBeforSlotMap.SetData(llngWriteRow, CMvsfBColTFT, .strWfId)    'WFID
                        End If
                    End With

                    llngCnt = llngCnt + 1
                Loop

                '@WF枚数分ﾙｰﾌﾟ(cf)
                llngCnt = 0
                Do While ltypCFList.lngListCnt -1 >= llngCnt
                    With ltypCFList.typWfList(llngCnt)
                        '@書き込み行設定
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが数値の場合のみ
                        If IsNumeric(.strSlotPosition) = True Then
                            llngWriteRow = CMlngMaxSlotRows - CLng(.strSlotPosition)
                            '@ﾃﾞｰﾀ表示
                            vsfBeforSlotMap.SetData(llngWriteRow, CMvsfBColCF, .strWfId)    'WFID
                        End If
                    End With

                    llngCnt = llngCnt + 1
                Loop

                '@---------------
                '@ﾊﾞｯｸｶﾗｰの設定
                '@---------------
                '@ｶｳﾝﾀ初期化
                llngCnt = 1

                '@ｽﾛｯﾄﾏｯﾌﾟ分ﾙｰﾌﾟ
                Do While .Rows.Count > llngCnt
                    '@ｽﾛｯﾄ№が空白以外
                    If .GetData(llngCnt, CMvsfBColNo) <> vbNullString Then
                        '@TFTWFIDが空白以外
                        If .GetData(llngCnt, CMvsfBColTFT) <> vbNullString Then

                            '@TFTﾊﾞｯｸｶﾗｰ(薄いｸﾞﾚｰ)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfBColTFT, llngCnt, CMvsfBColTFT)
                            cellRange.Style = newStyle
                        Else
                            '@ﾊﾞｯｸｶﾗｰ(濃いｸﾞﾚｰ)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfBColTFT, llngCnt, CMvsfBColTFT)
                            cellRange.Style = newStyle
                        End If

                        '@CFWFIDが空白以外
                        If .GetData(llngCnt, CMvsfBColCF) <> vbNullString Then

                            '@TFTﾊﾞｯｸｶﾗｰ(薄いｸﾞﾚｰ)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfBColCF, llngCnt, CMvsfBColCF)
                            cellRange.Style = newStyle
                        Else
                            '@ﾊﾞｯｸｶﾗｰ(濃いｸﾞﾚｰ)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfBColCF, llngCnt, CMvsfBColCF)
                            cellRange.Style = newStyle
                        End If
                    End If

                    '@ｶｳﾝﾄUP
                    llngCnt = llngCnt + 1
                Loop

                '@書式設定
                .Cols(CMvsfBColNo).TextAlign = TextAlignEnum.LeftCenter        '左詰の中央揃え(№)
                .Cols(CMvsfBColTFT).TextAlign = TextAlignEnum.LeftCenter       '左詰の中央揃え(WF_ID(TFT))
                .Cols(CMvsfBColCF).TextAlign = TextAlignEnum.LeftCenter        '左詰の中央揃え(WF_ID(CF))

                '@ﾍｯﾀﾞｰの高さ設定
                .Rows(CMvsfTRow).Height = CMvsfHdHeight

                '@ｽｸﾛｰﾙﾎﾞﾀﾝ設定
                '@頁先頭行が一覧先頭行の場合
                If .TopRow = .Rows.Fixed Then
                    '@ﾛｯｸ
                    cmdBUp.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdBUp.Enabled = True
                End If

                '@最終行が表示頁にある場合
                If .TopRow + CMlngVsfDispRows >= .Rows.Count Then
                    '@ﾛｯｸ
                    cmdBDown.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdBDown.Enabled = True
                End If

                '@直接描画
                .Redraw = flexRDDirect
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvBeforSlotMap_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvAfterSlotMap_Disp
    '機　能：貼り合せ後ｽﾛｯﾄ一覧表示
    '引　数：ltypWfOdfListAns：TFT/CF情報格納
    '戻り値：なし
    '作成日：2005/05/24 (Tue) 15:47:19 N.Kasai
    '更新日：2005/05/24 (Tue) 15:47:19
    '備　考：
    Private Sub prvAfterSlotMap_Disp(ByRef ltypWfOdfListAns As WfOdfListAns)

        Dim llngCnt As Integer  '汎用ｶｳﾝﾄ
        Dim llngWriteRow As Integer  'ｽﾛｯﾄ№

        Try

            '@------------
            '@0件の場合
            '@------------
            With vsfAfterSlotMap
                If ltypWfOdfListAns.lngOdfListCnt = 0 Then
                    '@ｸﾞﾘｯﾄﾞのﾛｯｸ解除
                    .Enabled = True
                    '@描画なし
                    .Redraw = flexRDNone
                    '@ﾘｽﾄ行数格納
                    .Rows.Count = .Rows.Fixed
                    .Rows.Count = CMlngMaxSlotRows

                    '@---------------
                    '@ｽﾛｯﾄ№を設定
                    '@---------------
                    '@ｶｳﾝﾀ初期化
                    llngCnt = 1
                    '@ｽﾛｯﾄﾏｯﾌﾟ分ﾙｰﾌﾟ
                    Do While .Rows.Count > llngCnt
                        '@MAXｽﾛｯﾄ以上の判定
                        If ltypWfOdfListAns.strSlotSize >= llngCnt Then
                            '@ｽﾛｯﾄ№
                            .SetData(.Rows.Count - llngCnt, CMvsfAColNo, Format$(llngCnt, CPstrSlotNoFormat))
                        Else
                            '@ｽﾛｯﾄ№(空白)
                            .SetData(.Rows.Count - llngCnt, CMvsfAColNo, vbNullString)
                        End If

                        '@ｽﾛｯﾄｻｲｽﾞを判定しﾊﾞｯｸｶﾗｰ変更
                        If ltypWfOdfListAns.strSlotSize >= .Rows.Count - llngCnt Then
                            '@ﾊﾞｯｸｶﾗｰ(白)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite1")
                            newStyle.BackColor = vbWhite
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfAColTFT, llngCnt, CMvsfAColCF)
                            cellRange.Style = newStyle
                        Else
                            '@ﾊﾞｯｸｶﾗｰ(ｸﾞﾚｰ)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbButtonFace1")
                            newStyle.BackColor = vbButtonFace
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfAColTFT, llngCnt, CMvsfAColCF)
                            cellRange.Style = newStyle
                        End If

                        '@行の高さ
                        .Rows(llngCnt).Height = CMvsfRowHeight
                        llngCnt = llngCnt + 1
                    Loop

                    '@---------------
                    '@ﾃﾞｰﾀ表示
                    '@---------------
                    '@WF枚数分ﾙｰﾌﾟ(tft)
                    llngCnt = 0
                    Do While mtypTFTList.lngListCnt -1 >= llngCnt
                        With mtypTFTList.typWfList(llngCnt)
                            '@書き込み行設定
                            '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが数値の場合のみ
                            If IsNumeric(.strToCarrySlotPosition) = True Then
                                llngWriteRow = CMlngMaxSlotRows - CLng(.strToCarrySlotPosition)
                                '@ﾃﾞｰﾀ表示
                                vsfAfterSlotMap.SetData(llngWriteRow, CMvsfAColTFT, .strWfId)     'WFID(tft)
                                vsfAfterSlotMap.SetData(llngWriteRow, CMvsfAColFixFlag, "0")      'ODF_COVER_FIX_FLAG(0:未)
                            End If
                        End With

                        llngCnt = llngCnt + 1
                    Loop

                    '@WF枚数分ﾙｰﾌﾟ(cf)
                    llngCnt = 0
                    Do While ltypWfOdfListAns.lngOdfListCnt -1 >= llngCnt
                        '@ﾃﾞｰﾀ表示
                        vsfAfterSlotMap.SetData(llngWriteRow, CMvsfAColCF, vbNullString)          'WFID(cf)
                        '@ｶｳﾝﾄUP
                        llngCnt = llngCnt + 1
                    Loop

                    '@---------------
                    '@ﾊﾞｯｸｶﾗｰの設定
                    '@---------------
                    '@ｶｳﾝﾀ初期化
                    llngCnt = 0

                    '@ｽﾛｯﾄﾏｯﾌﾟ分ﾙｰﾌﾟ
                    Do While .Rows.Count > llngCnt
                        '@ｽﾛｯﾄ№が空白以外
                        If .GetData(llngCnt, CMvsfAColNo) <> vbNullString Then
                            '@TFTWFIDが空白以外
                            If .GetData(llngCnt, CMvsfAColTFT) <> vbNullString Then

                                '@TFTﾊﾞｯｸｶﾗｰ(薄いｸﾞﾚｰ)
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray2")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                                Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfAColTFT, llngCnt, CMvsfAColTFT)
                                cellRange.Style = newStyle

                                '@CFﾊﾞｯｸｶﾗｰ(白)
                                Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite2")
                                newStyle2.BackColor = vbWhite
                                Dim cellRange2 As CellRange = .GetCellRange(llngCnt, CMvsfAColCF, llngCnt, CMvsfAColCF)
                                cellRange2.Style = newStyle2

                            Else
                                '@ﾊﾞｯｸｶﾗｰ(濃いｸﾞﾚｰ)
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray2")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                                Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfAColTFT, llngCnt, CMvsfAColCF)
                                cellRange.Style = newStyle
                            End If
                        End If
                        '@ｶｳﾝﾄUP
                        llngCnt = llngCnt + 1
                    Loop

                    '@書式設定
                    .Cols(CMvsfAColNo).TextAlign = TextAlignEnum.LeftCenter               '左詰の中央揃え(№)
                    .Cols(CMvsfAColTFT).TextAlign = TextAlignEnum.LeftCenter              '左詰の中央揃え(WFID(TFT))
                    .Cols(CMvsfAColCF).TextAlign =TextAlignEnum.LeftCenter                '左詰の中央揃え(WFID(CF))
                    .Cols(CMvsfAColFixFlag).TextAlign = TextAlignEnum.LeftCenter          '左詰の中央揃え(ODF_COVER_FIXFLAG)

                    '@ﾍｯﾀﾞｰの高さ設定
                    .Rows(CMvsfTRow).Height = CMvsfHdHeight

                    '@直接描画なし
                    .Redraw = flexRDDirect
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用不可
                    cmdAUp.Enabled = False
                    cmdADown.Enabled = False
                    Exit Sub
                End If
            End With

            '@------------
            '@件数ありの場合
            '@------------
            With vsfAfterSlotMap

                '@ｸﾞﾘｯﾄﾞのﾛｯｸ解除
                .Enabled = True
                '@描画なし
                .Redraw = flexRDNone
                '@ﾘｽﾄ行数初期化
                .Rows.Count = .Rows.Fixed
                '@ﾘｽﾄ行数格納
                .Rows.Count = CMlngMaxSlotRows
                '@行選択
                .Select(CMvsfTRow, CMvsfAColTFT, CMvsfTRow, .Cols.Count - 1)

                '@---------------
                '@ｽﾛｯﾄ№を設定
                '@---------------
                '@ｶｳﾝﾀ初期化
                llngCnt = 1
                '@ｽﾛｯﾄﾏｯﾌﾟ分ﾙｰﾌﾟ
                Do While .Rows.Count > llngCnt
                    '@MAXｽﾛｯﾄ以上の判定
                    If ltypWfOdfListAns.strSlotSize >= llngCnt Then
                        '@ｽﾛｯﾄ№
                        .SetData(.Rows.Count - llngCnt, CMvsfAColNo, Format$(llngCnt, CPstrSlotNoFormat))
                    Else
                        '@ｽﾛｯﾄ№(空白)
                        .SetData(.Rows.Count - llngCnt, CMvsfAColNo, vbNullString)
                    End If

                    '@ｽﾛｯﾄｻｲｽﾞを判定しﾊﾞｯｸｶﾗｰ変更
                    If ltypWfOdfListAns.strSlotSize >= .Rows.Count - llngCnt Then
                        '@ﾊﾞｯｸｶﾗｰ(白)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite3")
                        newStyle.BackColor = vbWhite
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfAColTFT, llngCnt, CMvsfAColCF)
                        cellRange.Style = newStyle
                    Else
                        '@ﾊﾞｯｸｶﾗｰ(ｸﾞﾚｰ)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbButtonFace3")
                        newStyle.BackColor = vbButtonFace
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfAColTFT, llngCnt, CMvsfAColCF)
                        cellRange.Style = newStyle
                    End If

                    '@行の高さ
                    .Rows(llngCnt).Height = CMvsfRowHeight
                    llngCnt = llngCnt + 1
                Loop

                '@---------------
                '@ﾃﾞｰﾀ表示
                '@---------------
                '@WF枚数分ﾙｰﾌﾟ(tft)
                llngCnt = 0
                Do While mtypTFTList.lngListCnt -1 >= llngCnt
                    With mtypTFTList.typWfList(llngCnt)
                        '@書き込み行設定
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが数値の場合のみ
                        If IsNumeric(.strToCarrySlotPosition) = True Then
                            llngWriteRow = CMlngMaxSlotRows - CLng(.strToCarrySlotPosition)
                            '@ﾃﾞｰﾀ表示
                            vsfAfterSlotMap.SetData(llngWriteRow, CMvsfAColTFT, .strWfId)    'WFID
                        End If
                    End With
                    '@ｶｳﾝﾄUP
                    llngCnt = llngCnt + 1
                Loop

                '@WF枚数分ﾙｰﾌﾟ(cf)
                llngCnt = 0
                Do While ltypWfOdfListAns.lngOdfListCnt -1 >= llngCnt
                    With ltypWfOdfListAns.typOdfList(llngCnt)
                        '@書き込み行設定
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが数値の場合のみ記載
                        If IsNumeric(.strSlotPosition) = True Then
                            llngWriteRow = CMlngMaxSlotRows - CLng(.strSlotPosition)
                            '@ﾃﾞｰﾀ表示
                            vsfAfterSlotMap.SetData(llngWriteRow, CMvsfAColCF, .strCfWfID)                    'WFID(cf)
                            vsfAfterSlotMap.SetData(llngWriteRow, CMvsfAColFixFlag, .strOdfCoverFixFlag)      'ODF_COVER_FIX_FLAG

                        End If
                    End With
                    llngCnt = llngCnt + 1
                Loop

                '@---------------
                '@ﾊﾞｯｸｶﾗｰの設定
                '@---------------
                '@ｶｳﾝﾀ初期化
                llngCnt = 0

                '@ｽﾛｯﾄﾏｯﾌﾟ分ﾙｰﾌﾟ
                Do While .Rows.Count > llngCnt
                    '@ｽﾛｯﾄ№が空白以外
                    If .GetData(llngCnt, CMvsfAColNo) <> vbNullString Then
                        '@TFTWFIDが空白以外
                        If .GetData(llngCnt, CMvsfAColTFT) <> vbNullString Then

                            '@TFTﾊﾞｯｸｶﾗｰ(薄いｸﾞﾚｰ)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray4")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfAColTFT, llngCnt, CMvsfAColTFT)
                            cellRange.Style = newStyle


                            If .GetData(llngCnt, CMvsfAColFixFlag) = "1" Then
                                '@CFﾊﾞｯｸｶﾗｰ(薄いｸﾞﾚｰ)
                                Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray4")
                                newStyle2.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                                Dim cellRange2 As CellRange = .GetCellRange(llngCnt, CMvsfAColCF, llngCnt, CMvsfAColCF)
                                cellRange2.Style = newStyle2
                            Else
                                '@CFﾊﾞｯｸｶﾗｰ(白)
                                Dim newStyle3 As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite4")
                                newStyle3.BackColor = vbWhite
                                Dim cellRange3 As CellRange = .GetCellRange(llngCnt, CMvsfAColCF, llngCnt, CMvsfAColCF)
                                cellRange3.Style = newStyle3
                            End If
                        Else
                            '@ﾊﾞｯｸｶﾗｰ(濃いｸﾞﾚｰ)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray4")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfAColTFT, llngCnt, CMvsfAColCF)
                            cellRange.Style = newStyle
                        End If
                    End If
                    '@ｶｳﾝﾄUP
                    llngCnt = llngCnt + 1
                Loop

                '@書式設定
                .Cols(CMvsfAColNo).TextAlign = TextAlignEnum.LeftCenter                '左詰の中央揃え(№)
                .Cols(CMvsfAColTFT).TextAlign = TextAlignEnum.LeftCenter               '左詰の中央揃え(WFID(TFT))
                .Cols(CMvsfAColCF).TextAlign = TextAlignEnum.LeftCenter                '左詰の中央揃え(WFID(CF))
                .Cols(CMvsfAColFixFlag).TextAlign = TextAlignEnum.LeftCenter           '左詰の中央揃え(ODF_COVER_FIXFLAG)

                '@ﾍｯﾀﾞｰの高さ設定
                .Rows(CMvsfTRow).Height = CMvsfHdHeight

                '@ｽｸﾛｰﾙﾎﾞﾀﾝ設定
                '@頁先頭行が一覧先頭行の場合
                If .TopRow = .Rows.Fixed Then
                    '@ﾛｯｸ
                    cmdAUp.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdAUp.Enabled = True
                End If

                '@最終行が表示頁にある場合
                If .TopRow + CMlngVsfDispRows >= .Rows.Count Then
                    '@ﾛｯｸ
                    cmdADown.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdADown.Enabled = True
                End If

                '@直接描画
                .Redraw = flexRDDirect

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvAfterSlotMap_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMapTopRow_Set
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの初期表示頁設定
    '引　数：vsfObject：ｵﾌﾞｼﾞｬｸﾄ名(ｸﾞﾘｯﾄﾞ)
    '戻り値：なし
    '作成日：2005/05/24 (Tue) 15:49:25 N.Kasai
    '更新日：2005/05/24 (Tue) 15:49:25
    '備　考：
    Private Sub prvVsfSlotMapTopRow_Set(ByRef vsfObject As C1FlexGrid)

        Dim llngCnt As Integer  'ｶｳﾝﾄ
        Dim llngRows As Integer  '行数
        Dim lblnFlag As Boolean  '判定ﾌﾗｸﾞ

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfObject
                '@ｽﾛｯﾄﾏｯﾌﾟの行数取得
                llngRows = .Rows.Count
                '@最大ｽﾛｯﾄが25より小さい場合
                If llngRows < CMlngMaxSlotRows Then
                    '@ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Fixed - 1
                    Exit Sub
                End If

                '@ｽﾛｯﾄ№01～10まで
                For llngCnt = CMlngMaxSlotRows - 1 To CMlngSlotNo10Row Step -1
                    '@WFが存在する場合
                    If .GetData(llngCnt, 1) <> vbNullString Then
                        '@WFあり
                        lblnFlag = True
                        Exit For
                    End If
                Next llngCnt

                '@ｽﾛｯﾄ№01～10にWFがない場合
                If lblnFlag = False Then
                    '@ｽﾛｯﾄ№25～16まで
                    For llngCnt = .Rows.Fixed To CMlngSlotNo16Row
                        '@WFが存在する場合
                        If .GetData(llngCnt, 1) <> vbNullString Then
                            '@ｽﾛｯﾄﾏｯﾌﾟの初期表示は上部
                            lblnFlag = True
                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@ｽﾛｯﾄﾏｯﾌﾟの初期表示は下部
                    lblnFlag = False
                End If


                '@頁ﾎﾞﾀﾝ制御
                Select Case vsfObject.Name
                    Case "vsfBeforSlotMap"
                        '@ｽﾛｯﾄﾏｯﾌﾟ上部表示の場合
                        If lblnFlag = True Then
                            '@ｽﾛｯﾄﾏｯﾌﾟの頁先頭行を設定
                            .TopRow = .Rows.Fixed
                            '@ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行を設定
                            .Select(1, CMvsfBColTFT)

                            '@前頁ﾎﾞﾀﾝを無効
                            cmdBUp.Enabled = False
                            '@最大ｽﾛｯﾄ数が1頁を超えている場合
                            If .Rows.Count > CMlngVsfDispRows + 1 Then
                                '@次頁ﾎﾞﾀﾝを有効
                                cmdBDown.Enabled = True
                            Else
                                '@次頁ﾎﾞﾀﾝを無効
                                cmdBDown.Enabled = False
                            End If
                        Else
                            '@ｽﾛｯﾄﾏｯﾌﾟの頁先頭行を設定
                            .TopRow = CMlngSlotNo10Row
                            '@ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行を設定
                            .Select(CMlngMaxSlotRows - 1, CMvsfBColTFT)

                            '@前頁ﾎﾞﾀﾝを無効
                            cmdBUp.Enabled = True
                            '@次頁ﾎﾞﾀﾝを無効
                            cmdBDown.Enabled = False
                        End If

                    Case "vsfAfterSlotMap"
                        '@ｽﾛｯﾄﾏｯﾌﾟ上部表示の場合
                        If lblnFlag = True Then
                            '@ｽﾛｯﾄﾏｯﾌﾟの頁先頭行を設定
                            .TopRow = .Rows.Fixed
                            '@ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行を設定
                            .Select(1, CMvsfAColTFT)
                            '@前頁ﾎﾞﾀﾝを無効
                            cmdAUp.Enabled = False
                            '@最大ｽﾛｯﾄ数が1頁を超えている場合
                            If .Rows.Count > CMlngVsfDispRows + 1 Then
                                '@次頁ﾎﾞﾀﾝを有効
                                cmdADown.Enabled = True
                            Else
                                '@次頁ﾎﾞﾀﾝを無効
                                cmdADown.Enabled = False
                            End If
                        Else
                            '@ｽﾛｯﾄﾏｯﾌﾟの頁先頭行を設定
                            .TopRow = CMlngSlotNo10Row
                            '@ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行を設定
                            .Select(CMlngMaxSlotRows - 1, CMvsfAColTFT)

                            '@前頁ﾎﾞﾀﾝを無効
                            cmdAUp.Enabled = True
                            '@次頁ﾎﾞﾀﾝを無効
                            cmdADown.Enabled = False
                        End If
                End Select
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMapTopRow_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：確定ﾎﾞﾀﾝﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2005/05/24 (Tue) 12:26:17 N.Kasai
    '更新日：2006/01/17 (Tue) 17:03:18 N.Kasai
    '備　考：
    '　　　：2006/01/17 (Tue) 17:03:18 N.Kasai  突然仕様変更
    Private Function prvblnInput_Chk() As Boolean

        Dim llngCntB As Integer      '汎用ｶｳﾝﾀ(Befor)
        Dim llngCntA As Integer      '汎用ｶｳﾝﾀ(After)
        Dim llngDataCnt As Integer      'ﾃﾞｰﾀｶｳﾝﾄ
        Dim lstrAColCF As String       'AfterCFWF退避
        Dim lblnChk As Boolean      '重複ﾁｪｯｸ判定

        Try

            '@初期化
            prvblnInput_Chk = False

            '@↓2006/01/17 (Tue) 17:17:15 N.Kasai **************************************************
            '    '@---------------------
            '    '@ｽﾛｯﾄﾏｯﾌﾟ件数ﾁｪｯｸ
            '    '@---------------------
            '    With vsfAfterSlotMap
            '        llngDataCnt = 0
            '        For llngCntA = 1 To .Rows - 1
            '            '@TFTWF設定ﾁｪｯｸ
            '            If .Cell(flexcpText, llngCntA, CMvsfAColTFT) <> vbNullString Then
            '                llngDataCnt = llngDataCnt + 1
            '            End If
            '        Next llngCntA
            '    End With
            '
            '    '@数値ﾁｪｯｸ
            '    If IsNumeric(lblTftWfNum.Caption) = True Then
            '        '@件数ﾁｪｯｸ
            '        If llngDataCnt <> CLng(lblTftWfNum.Caption) Then
            '            Exit Function
            '        End If
            '    End If
            '
            '    '@---------------------
            '    '@ｽﾛｯﾄﾏｯﾌﾟCFWF設定有無ﾁｪｯｸ
            '    '@---------------------
            '    With vsfAfterSlotMap
            '        For llngCntA = 1 To .Rows - 1
            '            '@CFWF設定ﾁｪｯｸ
            '            If .Cell(flexcpText, llngCntA, CMvsfAColTFT) <> vbNullString Then
            '                If .Cell(flexcpText, llngCntA, CMvsfAColCF) = vbNullString Then
            '                    Exit Function
            '                End If
            '            End If
            '        Next llngCntA
            '    End With

            '    '@---------------------
            '    '@ｽﾛｯﾄﾏｯﾌﾟTFT重複ﾁｪｯｸ
            '    '@---------------------
            '    With vsfBeforSlotMap
            '        llngDataCnt = 0
            '        For llngCntB = 1 To .Rows - 1
            '            '@TFTWF設定ﾁｪｯｸ
            '            If .Cell(flexcpText, llngCntB, CMvsfBColTFT) <> vbNullString Then
            '                lstrBColTFT = .Cell(flexcpText, llngCntB, CMvsfBColTFT)
            '
            '                '@ｽﾛｯﾄﾏｯﾌﾟCFWF設定ﾁｪｯｸ
            '                With vsfAfterSlotMap
            '                    For llngCntA = 1 To .Rows - 1
            '                        '@CFWF設定ﾁｪｯｸ
            '                        If .Cell(flexcpText, llngCntA, CMvsfAColTFT) <> vbNullString Then
            '
            '                            If lstrBColTFT = .Cell(flexcpText, llngCntA, CMvsfAColTFT) Then
            '                                '@ﾃﾞｰﾀ一致(ｶｳﾝﾄUP)
            '                                llngDataCnt = llngDataCnt + 1
            '                                Exit For
            '                            End If
            '                        End If
            '                    Next llngCntA
            '                End With
            '
            '            End If
            '        Next llngCntB
            '    End With

            '    '@数値ﾁｪｯｸ(TFT)
            '    If IsNumeric(lblTftWfNum.Caption) = True Then
            '        '@件数ﾁｪｯｸ
            '        If llngDataCnt <> CLng(lblTftWfNum.Caption) Then
            '            Exit Function
            '        End If
            '    End If

            '    '@---------------------
            '    '@ｽﾛｯﾄﾏｯﾌﾟCF重複ﾁｪｯｸ
            '    '@---------------------
            '    With vsfBeforSlotMap
            '        llngDataCnt = 0
            '        For llngCntB = 1 To .Rows - 1
            '            '@TFTWF設定ﾁｪｯｸ
            '            If .Cell(flexcpText, llngCntB, CMvsfBColCF) <> vbNullString Then
            '                lstrBColCF = .Cell(flexcpText, llngCntB, CMvsfBColCF)
            '
            '                '@ｽﾛｯﾄﾏｯﾌﾟCFWF設定ﾁｪｯｸ
            '                With vsfAfterSlotMap
            '                    For llngCntA = 1 To .Rows - 1
            '                        '@CFWF設定ﾁｪｯｸ
            '                        If .Cell(flexcpText, llngCntA, CMvsfAColCF) <> vbNullString Then
            '
            '                            If lstrBColCF = .Cell(flexcpText, llngCntA, CMvsfAColCF) Then
            '                                '@ﾃﾞｰﾀ一致(ｶｳﾝﾄUP)
            '                                llngDataCnt = llngDataCnt + 1
            '                                Exit For
            '                            End If
            '                        End If
            '                    Next llngCntA
            '                End With
            '
            '            End If
            '        Next llngCntB
            '    End With
            '
            '    '@数値ﾁｪｯｸ(CF)
            '    If IsNumeric(lblTftWfNum.Caption) = True Then
            '        '@件数ﾁｪｯｸ
            '        If llngDataCnt <> CLng(lblTftWfNum.Caption) Then
            '            Exit Function
            '        End If
            '    End If

            '@---------------------
            '@ｽﾛｯﾄﾏｯﾌﾟCF正当性ﾁｪｯｸ
            '@---------------------
            lblnChk = False
            With vsfAfterSlotMap
                llngDataCnt = 0
                For llngCntB = 1 To .Rows.Count - 1
                    '@TFTWF設定ﾁｪｯｸ
                    If .GetData(llngCntB, CMvsfAColCF) <> vbNullString Then
                        lstrAColCF = .GetData(llngCntB, CMvsfAColCF)
                        lblnChk = False
                        '@ｽﾛｯﾄﾏｯﾌﾟCFWF設定ﾁｪｯｸ
                        With vsfBeforSlotMap
                            For llngCntA = 1 To .Rows.Count - 1
                                '@CFWF設定ﾁｪｯｸ
                                If .GetData(llngCntA, CMvsfBColCF) <> vbNullString Then

                                    If lstrAColCF = .GetData(llngCntA, CMvsfBColCF) Then

                                        lblnChk = True
                                        Exit For
                                    End If
                                End If
                            Next llngCntA
                        End With

                        If lblnChk = False Then

                            '@"<TRM5WW>$$貼り合せ後WFIDの設定に不備があります。[%1]$設定を見直してください。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005W, "WFID不一致")
                            '@警告ﾒｯｾｰｼﾞ
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            .Row = llngCntB
                            .Col = CMvsfAColCF
                            .Select(.Row, .Col)

                            '@ｾｯﾄﾌｫｰｶｽ処理
                            Call pubSetFocus(vsfAfterSlotMap)
                            Exit Function
                        End If

                    End If
                Next llngCntB
            End With

            '@---------------------
            '@ｽﾛｯﾄﾏｯﾌﾟCF重複ﾁｪｯｸ
            '@---------------------
            With vsfAfterSlotMap
                For llngCntB = 1 To .Rows.Count - 1
                    '@CFWF設定ﾁｪｯｸ
                    If .GetData(llngCntB, CMvsfAColCF) <> vbNullString Then
                        lstrAColCF = .GetData(llngCntB, CMvsfAColCF)
                        llngDataCnt = 0
                        For llngCntA = 1 To .Rows.Count - 1
                            If lstrAColCF = .GetData(llngCntA, CMvsfAColCF) Then
                                '@ﾃﾞｰﾀ一致(ｶｳﾝﾄUP)
                                llngDataCnt = llngDataCnt + 1
                            End If
                        Next llngCntA
                        '@1件以上存在する場合は重複だ
                        If llngDataCnt > 1 Then


                            '@"<TRM5WW>$$貼り合せ後WFIDの設定に不備があります。[%1]$設定を見直してください。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005W, "重複設定あり")
                            '@警告ﾒｯｾｰｼﾞ
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            .Row = llngCntB
                            .Col = CMvsfAColCF
                            .Select(.Row, .Col)

                            '@ｾｯﾄﾌｫｰｶｽ処理
                            Call pubSetFocus(vsfAfterSlotMap)
                            Exit Function
                        End If
                    End If
                Next llngCntB
            End With
            '@↑2006/01/17 (Tue) 17:17:15 N.Kasai **************************************************

            '@成功
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

    '関数名：prvblnFTP_Chk
    '機　能：FTP転写結果ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:成功　False:失敗
    '作成日：2005/05/24 (Tue) 16:38:24 N.Kasai
    '更新日：2005/05/24 (Tue) 16:38:24
    '備　考：
    Private Function prvblnFTP_Chk() As Boolean

        Dim llngDataCnt As Integer  'ﾃﾞｰﾀｶｳﾝﾄ
        Dim llngCnt As Integer  '汎用ｶｳﾝﾀ

        Try

            '@初期化
            prvblnFTP_Chk = False

            '@---------------------
            '@ｽﾛｯﾄﾏｯﾌﾟ件数ﾁｪｯｸ
            '@---------------------
            With vsfAfterSlotMap
                llngDataCnt = 0
                For llngCnt = 1 To .Rows.Count - 1
                    '@TFTWF設定ﾁｪｯｸ
                    If .GetData(llngCnt, CMvsfAColCF) <> vbNullString Then
                        llngDataCnt = llngDataCnt + 1
                    End If
                Next llngCnt
            End With

            '@数値ﾁｪｯｸ
            If IsNumeric(lblTftWfNum.Text) = True Then
                '@件数ﾁｪｯｸ
                If llngDataCnt <> CLng(lblTftWfNum.Text) Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005V)
                    '@"<TRM5VW>$$装置より貼り合せ実績が取得できないWFがあります。$手動で入力を行って下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    Exit Function
                End If
            End If

            '@初期化
            prvblnFTP_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnFTP_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblncmdClear_Chk
    '機　能：全部取消ﾎﾞﾀﾝ使用可否
    '引　数：なし
    '戻り値：True:成功　False:失敗
    '作成日：2005/05/26 (Thu) 09:07:49 N.Kasai
    '更新日：2006/01/17 (Tue) 16:23:33 N.Kasai
    '備　考：
    '　　　：2006/01/17 (Tue) 16:23:33 N.Kasai      突然仕様変更(部分貼り付け可)
    Private Function prvblncmdClear_Chk() As Boolean

        Dim llngCnt As Integer  '汎用ｶｳﾝﾀ

        Try

            '@初期化
            prvblncmdClear_Chk = False
            '@---------------------
            '@ｽﾛｯﾄﾏｯﾌﾟ件数ﾁｪｯｸ
            '@---------------------
            With vsfAfterSlotMap
                For llngCnt = 1 To .Rows.Count - 1
                    '@↓2006/01/17 (Tue) 16:23:26 N.Kasai **************************************************
                    '            '@TFTWF設定ﾁｪｯｸ
                    '            If .Cell(flexcpText, llngCnt, CMvsfAColCF) <> vbNullString Then
                    '                '@OK
                    '                prvblncmdClear_Chk = True
                    '                Exit For
                    '            End If

                    '@CFWF設定ﾁｪｯｸ
                    If .GetData(llngCnt, CMvsfAColCF) <> vbNullString Then
                        If .GetData(llngCnt, CMvsfAColFixFlag) <> "1" Then
                            '@OK
                            prvblncmdClear_Chk = True
                            Exit For
                        End If
                    End If
                    '@↑2006/01/17 (Tue) 16:23:26 N.Kasai **************************************************
                Next llngCnt
            End With

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblncmdClear_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblncmdRegist_Chk
    '機　能：確定ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:成功　False:失敗
    '作成日：2005/05/26 (Thu) 09:12:49 N.Kasai
    '更新日：2006/01/17 (Tue) 16:26:38 N.Kasai
    '備　考：
    '　　　：2006/01/17 (Tue) 16:26:38 N.Kasai      突然仕様変更(部分貼り付け可)
    Private Function prvblncmdRegist_Chk() As Boolean

        Dim llngCnt As Integer  '汎用ｶｳﾝﾀ

        Try

            '@初期化
            prvblncmdRegist_Chk = False

            '@↓2006/01/17 (Tue) 16:28:55 N.Kasai **************************************************
            '    '@---------------------
            '    '@ｽﾛｯﾄﾏｯﾌﾟ件数ﾁｪｯｸ
            '    '@---------------------
            '    With vsfAfterSlotMap
            '        llngDataCnt = 0
            '        For llngCnt = 1 To .Rows - 1
            '            '@TFTWF設定ﾁｪｯｸ
            '            If .Cell(flexcpText, llngCnt, CMvsfAColTFT) <> vbNullString Then
            '                llngDataCnt = llngDataCnt + 1
            '            End If
            '        Next llngCnt
            '    End With
            '
            '    '@数値ﾁｪｯｸ
            '    If IsNumeric(lblTftWfNum.Caption) = True Then
            '        '@件数ﾁｪｯｸ
            '        If llngDataCnt <> CLng(lblTftWfNum.Caption) Then
            '            Exit Function
            '        End If
            '    End If
            '
            '    With vsfAfterSlotMap
            '        llngDataCnt = 0
            '        For llngCnt = 1 To .Rows - 1
            '            '@TFTWF設定ﾁｪｯｸ
            '            If .Cell(flexcpText, llngCnt, CMvsfAColCF) <> vbNullString Then
            '                llngDataCnt = llngDataCnt + 1
            '            End If
            '        Next llngCnt
            '    End With
            '
            '    '@数値ﾁｪｯｸ
            '    If IsNumeric(lblTftWfNum.Caption) = True Then
            '        '@件数ﾁｪｯｸ
            '        If llngDataCnt <> CLng(lblTftWfNum.Caption) Then
            '            Exit Function
            '        End If
            '    End If

            '@---------------------
            '@ｽﾛｯﾄﾏｯﾌﾟ件数ﾁｪｯｸ
            '@---------------------
            With vsfAfterSlotMap
                For llngCnt = 1 To .Rows.Count - 1
                    '@CFWF設定ﾁｪｯｸ
                    If .GetData(llngCnt, CMvsfAColCF) <> vbNullString Then
                        If .GetData(llngCnt, CMvsfAColFixFlag) <> "1" Then
                            '@OK
                            prvblncmdRegist_Chk = True
                            Exit For
                        End If
                    End If
                Next llngCnt
            End With
            '@↑2006/01/17 (Tue) 16:28:55 N.Kasai **************************************************

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblncmdRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    ''' <summary>
    ''' ODF予約情報とのCFWFチェック
    ''' ODF予約情報が無い場合は、作業開始で確認済みなので、ここで情報が無い場合は、ユーザーが承知しているので
    ''' ここでは予約情報がある場合のWFを確認する
    ''' </summary>
    Private Sub prvOdfReserveCfWf_Chk()

        Dim llngCnt As Integer
        Dim lblnAns As Boolean

        Try

            'レスポンス開始
            Call pubResponseStart(Me.Name, "prvOdfReserveCfWf_Chk")

            Dim ltypChkOdfReserve As New List(Of typChkOdfReserve)
            Dim lstrResult As String = vbNullString
            '予約検索(引数:TFT_LOT/CF_LOT/TFT_WF/CF_WF)
            lblnAns = pubblnChkOdfReserve(CMstrasm_chkodfreserveVer, lblTftLotID.Text, lblCfLotID.Text, vbNullString, vbNullString, lstrResult, ltypChkOdfReserve)

            If lblnAns = False Then
                'レスポンス中止
                Call pubResponseCancel(Me.Name, "prvOdfReserveCfWf_Chk")
                Exit Sub
            End If

            'レスポンス終了
            Call publngResponseEnd(Me.Name, "prvOdfReserveCfWf_Chk")

            'ODF貼り合せ予約情報を検索して対となるTFT/CFのWFIDを探す
            Dim strWarningMsg As String = vbNullString
            For Each tmp As typChkOdfReserve In ltypChkOdfReserve
                For llngCnt = 1 To vsfAfterSlotMap.Rows.Count - 1
                    If (tmp.strWfId = vsfAfterSlotMap.GetData(llngCnt, CMvsfAColTFT)) Then
                        'CF WFIDが予約WFと異なる場合
                        If (tmp.strCfWfId <> vsfAfterSlotMap.GetData(llngCnt, CMvsfAColCF)) Then
                            '表示用Message作成
                            If strWarningMsg = vbNullString Then
                                strWarningMsg = vsfAfterSlotMap.GetData(llngCnt, CMvsfAColCF)
                            Else
                                If strWarningMsg.IndexOf(vsfAfterSlotMap.GetData(llngCnt, CMvsfAColCF)) = -1 Then
                                    strWarningMsg = strWarningMsg + "/" + vsfAfterSlotMap.GetData(llngCnt, CMvsfAColCF)
                                End If
                            End If
                        End If
                    End If
                Next
            Next

            If strWarningMsg <> vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                '"<TRM177W>$$ウエハ[%1]は、$貼り合せ予約情報と異なります。$確認してから処理を継続してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0177, strWarningMsg)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            End If

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvOdfReserveCfWf_Chk"
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
        Const WM_SYSCOMMAND As Integer = &H0112
        Const WM_CLOSE As Integer = &H0010
        Const WM_ENDSESSION As Integer = &H0016
        Const SC_MOVE As Long = &HF010L
        Const SC_CLOSE As Long = &HF060L
        Dim lblnSysCommandScClose As Boolean = False  'NSYS コントロールメニュー SC_CLOSE処理時 True
        Dim lblnWMClose As Boolean = False  'NSYS WM_CLOSE処理時 True

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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Frame1.Paint, Frame2.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfAfterSlotMap.KeyDownEdit, vsfBeforSlotMap.KeyDownEdit

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

End Class
