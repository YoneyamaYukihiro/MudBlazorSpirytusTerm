'ﾌｧｲﾙ名：xxEN0040.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾛｯﾄ投入(基板)　ﾒｲﾝﾌｫｰﾑ
'作成日：2004/02/27 (Fri) 10:51:41 M.Miura
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0040
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0040    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0040
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0040
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0040)
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
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2020/09/18 (Fri) 12:11:48 T.Oide 「.Netへ反映未」 **************************************************
    '@Private Const CMstrLocalVersion                     As String = "07.03"
    Private Const CMstrLocalVersion                     As String = "07.04"
    '@↑2020/09/18 (Fri) 12:11:48 T.Oide 「.Netへ反映未」 **************************************************
    
    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_partlistVer                  As String = "03.00"     '部材ﾘｽﾄ
    Private Const CMstrmas_priolistVer                  As String = "01.00"     'ﾏｽﾀ優先順位項目取得
    Private Const CMstrmas_vendclasslistVer             As String = "02.00"     'ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄ取得
    Private Const CMstrcarrcurstateVer                  As String = "05.02"     'ｷｬﾘｱ状態確認
    Private Const CMstrlot_throwin_Ver                  As String = "04.00"     'ﾛｯﾄ投入
    Private Const CMstrmas_wplist__Ver                  As String = "05.01"     '装置一覧取得

    '@ﾛｰｶﾙ機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN0040

    '@vsfSlotMapの定数宣言(ｶﾗﾑ)
    Private Const CMvsfSlotMapColSlot                   As Integer = 0          'ｽﾛｯﾄ
    Private Const CMvsfSlotMapColVender                 As Integer = 1          'ﾍﾞﾝﾀﾞｰ
    Private Const CMvsfSlotMapColVenderLotID            As Integer = 2          'ﾍﾞﾝﾀﾞｰﾛｯﾄID

    '@vsfSlotMapの定数宣言(表示幅)
    Private Const CMvsfSlotMapColWSlot                  As Integer = 29         'ｽﾛｯﾄ
    Private Const CMvsfSlotMapColWVender                As Integer = 188        'ﾍﾞﾝﾀﾞｰ
    Private Const CMvsfSlotMapColWVenderLotID           As Integer = 140        'ﾍﾞﾝﾀﾞｰﾛｯﾄID

    '@vsfSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMvsfSlotMapColTSlot                  As String = ""
    Private Const CMvsfSlotMapColTVender                As String = "ベンダー"
    Private Const CMvsfSlotMapColTVenderLotID           As String = "在庫ロットID"

    '@vsfSlotMapの定数宣言(その他)
    Private Const CMvsfSlotMapVisibleRows               As Integer = 10         '表示行数
    Private Const CMvsfSlotMapRowTitle                  As Integer = 0          'ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ
    Private Const CMvsfSlotMapBottomRow                 As Integer = 25         'ｽﾛｯﾄﾏｯﾌﾟ№1行目
    Private Const CMvsfSlotMapColmNum                   As Integer = 3          'ｶﾗﾑ数
    Private Const CMvsfSlotMapRowS                      As Integer = 26         '行数
    Private Const CMvsfSlotMapHHeight                   As Integer = 27         'ﾍｯﾀﾞｰの高さ
    Private Const CMvsfSlotMapHeight                    As Integer = 38         '１ｽﾛｯﾄの高さ
    Private Const CMvsfSlotMapSTopRow                   As Integer = 16         '初期表示行番号
    Private Const CMvsfSlotMapPageRows                  As Integer = 10         '１ﾍﾟｰｼﾞ表示行数
    Private Const CMvsfSlotHMaCellFontSize              As Integer = 12         'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ

    '@利用部材ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngComboDispCols                    As Integer = 2          '表示列数
    Private Const CMlngComboColPartCode                 As Integer = 0          'PartCode列
    Private Const CMlngComboColPartName                 As Integer = 1          'PartName列
    Private Const CMlngComboColVenderName               As Integer = 2          'VenderName列
    Private Const CMlngComboColPart                     As Integer = 3          'PartCode + PartName列
    Private Const CMlngComboFontSize                    As Integer = 16         'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboGridFontSize                As Integer = 16         'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboRowHeight                   As Integer = 43         '行の高さ

    '@優先順位選択ｺﾝﾎﾞﾎﾞｯｸｽ/投入装置ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbPrioSelFontSize               As Integer = 16         'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbPrioSelGridFontSize           As Integer = 16         'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbPrioSelGridColPriorityName    As Integer = 0          '優先順位項目列番
    Private Const CMlngCmbPrioSelGridColPriorityID      As Integer = 1          '優先順位項目ID列番(非表示項目)
    Private Const CMlngCmbPrioSelDispCols               As Integer = 1          'ｸﾞﾘｯﾄﾞ表示列数

    '@優先順位ｺﾝﾎﾞﾎﾞｯｸｽ/投入装置ｺﾝﾎﾞﾎﾞｯｸｽの初期値
    Private Const CMstrcmbPrioSel                       As String = "1"         'ﾘｽﾄｲﾝﾃﾞｯｸｽ

    '@処理形態の定数宣言
    Private Const CMstrOnline                           As Integer = 1          '処理形態ｵﾝﾗｲﾝ
    Private Const CMstrOffline                          As Integer = 0          '処理形態ｵﾌﾗｲﾝ

    '@↓2020/03/27 (Fri) 13:51:02 T.Oide 「.Netへ反映未」 **************************************************
    Private Const CMstrLaserMarkTounyu                  As String = "投入時"
    Private Const CMstrLaserMarkRyudou                  As String = "流動中"
    '@↑2020/03/27 (Fri) 13:51:02 T.Oide 「.Netへ反映未」 **************************************************

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mblnMouseCancelFlag                         As Boolean                          'ﾏｳｽｷｬﾝｾﾙﾌﾗｸﾞ
    Private mcurInvNum                                  As Decimal                          '在庫数(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ用)
    Private mstrPDID                                    As String                           '機種ID退避用
    Private mstrSlotSize                                As String                           'ｽﾛｯﾄｻｲｽﾞ退避用
    Private mstrEventName                               As String                           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
    Private mlngWpListCnt                               As Integer                          '装置一覧件数
    Private mlngWFNum                                   As Integer                          'WF枚数(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ用)
    Private mtyppartlist                                As List(Of PartClassList)           '部材ﾘｽﾄ構造体
    Private mtypVenderlist                              As VenderList                       'ﾍﾞﾝﾀﾞｰｸﾗｽ構造体
    Private mtypPriorityReasonList                      As List(Of typPriorityReasonList)   '優先度ﾘｽﾄ構造体
    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnDoubleClickOn                           As Boolean                          'NSYS マウスダブルクリックの場合 True
    Private mblnMouseDrag                               As Boolean                          'NSYS マウスドラッグの場合 True
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
        mblnMouseDrag = False

        Form_Load()

        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfSlotMap, cmdUp, cmdDown)
        
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 11:12:47 M.Miura
    '更新日：2005/03/14 (Mon) 16:18:37 N.Kojima
    '備　考：2005/03/14 (Mon) 16:18:37 N.Kojima     投入装置追加に伴う修正(改善№577)
    Private Sub Form_Load()

        Dim llngPrioritydcodeListCnt    As Integer      'ﾛｯﾄ優先順位項目のｶｳﾝﾄ
        Dim lblnAns                     As Boolean      '汎用戻り値

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0040, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "Form_Load"
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@画面初期化
            Call prvfrmxxEN0040_Init()
                
            '@ｽﾛｯﾄﾏｯﾌﾟの初期化
            Call prvvsfSlotMap_init()
            
            '@利用部材取得【CPstrCD30：WFのみ取得】
            lblnAns = pubblnVendClassList_Sel(CMstrmas_vendclasslistVer, CPstrCD30, mtypVenderlist)
            '@結果判定
            If lblnAns = False Then
                '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@優先順位ｺﾝﾎﾞﾎﾞｯｸｽ初期化
            Call prvcmbPrioSel_Init()
            
            '@優先順位ﾏｽﾀ取得、結果ﾁｪｯｸ
            lblnAns = pubblnMasPriolist_Sel(CMstrmas_priolistVer, llngPrioritydcodeListCnt, mtypPriorityReasonList)
            '@結果判定
            If lblnAns = True Then
                '@成功の場合
                '配列の件数ﾁｪｯｸ
                If llngPrioritydcodeListCnt > 0 Then
                    '@優先情報項目ﾏｽﾀをｺﾝﾎﾞへｾｯﾄ
                    Call prvcmbPrioSel_Disp()
                End If
            Else
                '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@投入装置ｺﾝﾎﾞﾎﾞｯｸｽ初期化
            Call prvcmbThrowinWP_Init()
            
            '@装置一覧取得、結果ﾁｪｯｸ【CPstrCD3U：EQ_TYPE指定、CPstrEqTypeThrowin：13】
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, mlngWpListCnt, pstrSBID, CPstrCD3U, , , , , CPstrEqTypeThrowin)
            '@結果判定
            If lblnAns = True Then
                '@成功の場合
                '配列の件数ﾁｪｯｸ
                If mlngWpListCnt > 0 Then
                    '@投入装置をｺﾝﾎﾞへｾｯﾄ
                    Call prvcmbThrowinWP_Disp()
                End If
            Else
                '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            'NSYS 背景色に白を設定
            cmbPartName.BackColor = Color.White
            cmbPrioSel.BackColor = Color.White
            cmbThrowinWP.BackColor = Color.White
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, mstrEventName)
                
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
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
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 17:26:21 M.Miura
    '更新日：2004/04/13 (Tue) 09:34:53 H.Wajima
    '備　考：
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

            '@ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfSlotMap, cmdUP, cmdDown, False)
            
            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    '@ｽﾛｯﾄﾏｯﾌﾟ以外
                    If ActiveControl.Name <> vsfSlotMap.Name AndAlso
                        ActiveControl IsNot vsfSlotMap.Editor Then
                        '@次項目へﾌｫｰｶｽｾｯﾄ
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    Else If ActiveControl IsNot vsfSlotMap.Editor Then
                        '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｯｸ処理
                        Call prvvsfSlotMapSel_Proc()
                    End If

                'NSYS [↑]ｷｰ
                Case Keys.Up                        
                    If ActiveControl.Name = vsfSlotMap.Name Then
                        With vsfSlotMap
                            'NSYS VB6互換動作 複数行選択されている場合グリッドをスクロールさせない
                            If .Row <> .RowSel AndAlso .RowSel = .TopRow AndAlso e.Shift Then
                                e.Handled = True
                            End If
                        End With
                    End If
                'NSYS [↓]ｷｰ
                Case Keys.Down
                    If ActiveControl.Name = vsfSlotMap.Name Then
                        With vsfSlotMap
                            'NSYS VB6互換動作 複数行選択されている場合グリッドをスクロールさせない
                            If .Row <> .RowSel AndAlso .RowSel = .BottomRow AndAlso e.Shift Then
                                e.Handled = True
                            End If
                        End With
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
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/03/22 (Mon) 16:08:09 M.Miura
    '更新日：2004/11/01 (Mon) 16:13:41 N.Kasai
    '備　考：2004/11/01 (Mon) 16:13:41 N.Kasai  閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@構造体のｸﾘｱ
            mtyppartlist = Nothing
            mtypPriorityReasonList = Nothing
            mtypVenderlist.typVenderClassList = Nothing
            
            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
            '@Actを自前で初期化した場合
                '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                lblnAnsTerm = pubblnAct_Term
                '@結果判定
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
    '作成日：2004/02/27 (Fri) 15:44:16 M.Miura
    '更新日：2004/02/27 (Fri) 15:44:16
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypcomoninfo   As CommonInfo   '初期化構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@終了関数を実行する
            RemoveHandler txtCarrierID.Validating, AddressOf txtCarrierID_Validate
            Call publngEnd_Proc(CPstrKeyEN0040, ltypcomoninfo)
            AddHandler txtCarrierID.Validating, AddressOf txtCarrierID_Validate
            
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

    '関数名：cmbPartName_Change
    '機　能：利用部材ﾘｽﾄ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/08 (Thu) 10:46:30 S.Deguchi
    '更新日：2004/04/08 (Thu) 10:46:30
    '備　考：
    Private Sub cmbPartName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPartName.Change

        Try
            With cmbPartName
                '@一致した文字列に対応するIDを構造体にｾｯﾄする
                .ValueCol = CMlngComboColPartName       '部材名列
                ptypPart.strPartName = .Value           '利用部材
                
                .ValueCol = CMlngComboColPartCode       '部材ｺｰﾄﾞ列
                ptypPart.strPartCode = .Value           '部材ｺｰﾄﾞ
                
                .ValueCol = CMlngComboColVenderName     'ﾍﾞﾝﾀﾞｰ名列
                lblVenderName.Text = .Value             'ﾍﾞﾝﾀﾞｰ名
                ptypPart.strVenderName = .Value         'ﾍﾞﾝﾀﾞｰ名
            End With
            
            '@ﾍﾞﾝﾀﾞｰﾛｯﾄID削除
            lblInvLotID.Text = vbNullString
            
            '@製造ﾛｯﾄID削除
            lblProductionLotID.Text = vbNullString
            
            '@在庫数削除
            lblInvNum.Text = vbNullString
            
            '@部材ｺｰﾄﾞﾁｪｯｸ
            With cmbPartName
                .ValueCol = CMlngComboColPartCode
                If .Value <> vbNullString Then
                    '@ﾍﾞﾝﾀﾞｰﾛｯﾄID選択ﾎﾞﾀﾝ表示
                    cmdVenderLot.Enabled = True
                Else
                    '@ﾍﾞﾝﾀﾞｰﾛｯﾄID選択ﾎﾞﾀﾝ表示
                    cmdVenderLot.Enabled = False
                End If
            End With

            '@ﾍﾞﾝﾀﾞｰﾛｯﾄID、在庫数が設定されている場合
            If lblLotID.Text <> vbNullString And _
               lblInvLotID.Text <> vbNullString And _
               IsNumeric(lblInvNum.Text) = True Then
               
                '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ解除
                vsfSlotMap.Enabled = True
                cmdUP.Enabled = True
                cmdDown.Enabled = True
                
                Call pubVsfDisp(vsfSlotMap, cmdUP, cmdDown)
            
                '@在庫数格納(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ用)
                If IsNumeric(lblInvNum.Text) = True Then
                    '@在庫数項目が数値の場合
                    mcurInvNum = CDec(lblInvNum.Text)
                Else
                    mcurInvNum = 0
                End If
                
                '@入力ﾁｪｯｸ
                Call prvcmdRegist_Chk()
            Else
                '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ
                vsfSlotMap.Enabled = False
                cmdUP.Enabled = False
                cmdDown.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPartName_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPartName_CloseUp
    '機　能：利用部材ﾘｽﾄ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/08 (Thu) 10:32:44 S.Deguchi
    '更新日：2004/04/12 (Mon) 15:00:46 H.Wajima
    '備　考：
    Private Sub cmbPartName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPartName.CloseUp

        Try
            With cmbPartName
                '@一致した文字列に対応するIDを構造体とﾗﾍﾞﾙにｾｯﾄする
                .ValueCol = CMlngComboColPartName
                ptypPart.strPartName = .Value        '利用部材
                
                .ValueCol = CMlngComboColPartCode
                ptypPart.strPartCode = .Value        '部材ｺｰﾄﾞ
                
                .ValueCol = CMlngComboColVenderName
                lblVenderName.Text = .Value          'ﾍﾞﾝﾀﾞｰ名
                ptypPart.strVenderName = .Value      'ﾍﾞﾝﾀﾞｰ名
            End With
            
            With cmbPartName
                .ValueCol = CMlngComboColPartCode
                '@部材ｺｰﾄﾞﾁｪｯｸ
                If .Value <> vbNullString Then
                    '@ﾍﾞﾝﾀﾞｰﾛｯﾄID選択ﾎﾞﾀﾝ表示
                    cmdVenderLot.Enabled = True
                    
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdVenderLot)
                Else
                    '@ﾍﾞﾝﾀﾞｰﾛｯﾄID選択ﾎﾞﾀﾝ表示
                    cmdVenderLot.Enabled = False
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPartName_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPrioSel_CloseUp
    '機　能：優先度選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/14 (Fri) 12:33:44 M.Miura
    '更新日：2004/05/14 (Fri) 12:33:44
    '備　考：
    Private Sub cmbPrioSel_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPrioSel.CloseUp

        Try
            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
            With cmbPrioSel
                .ValueCol = 1
                '@優先度が選択されている場合
                If .Value <> vbNullString Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    Select Case True
                        Case optOnlineflg1.Checked
                            '@ｵﾝﾗｲﾝ
                            Call pubSetFocus(optOnlineflg1)
                            
                        Case optOnlineflg0.Checked
                            '@ｵﾌﾗｲﾝ
                            Call pubSetFocus(optOnlineflg0)
                    End Select
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPrioSel_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbThrowinWP_CloseUp
    '機　能：投入装置選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:21:25 N.Kojima
    '更新日：2005/03/14 (Mon) 16:21:25
    '備　考：
    Private Sub cmbThrowinWP_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbThrowinWP.CloseUp

        Try
            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
            '@Validate処理を呼ぶ
            Call cmbThrowinWP_Validate(cmbThrowinWP, New CancelEventArgs(False))
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbThrowinWP_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbThrowinWP_Validate
    '機　能：投入装置Validate処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 14:09:04 N.Kojima
    '更新日：2005/03/15 (Tue) 14:09:04
    '備　考：
    Private Sub cmbThrowinWP_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbThrowinWP.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            With cmbThrowinWP
                .ValueCol = 1
                '@投入装置が選択されている場合
                If .Value <> vbNullString Then
                    If ActiveControl Is cmbThrowinWP Then
                        '@ｽﾛｯﾄﾏｯﾌﾟが有効か
                        If vsfSlotMap.Enabled = True Then
                            '@次項目にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfSlotMap)
                        Else
                            '@全部取消ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClear)
                        End If
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbThrowinWP_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdResvLot_Click
    '機　能：投入予定ﾛｯﾄID選択画面表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 15:41:09 M.Miura
    '更新日：2008/06/04 (Wed) 10:30:27 N.Kojima
    '備　考：
    '　　　：2004/09/06 (Mon) 18:34:52 N.Kasai      pubblnMasPartList_Sel　Ver3.0対応
    '　　　：2004/09/17 (Fri) 16:07:56 Y.Yamagishi　VENDER_CLASSは空で送る(不具合改善№613)
    '　　　：2008/06/04 (Wed) 10:30:27 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmdResvLot_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdResvLot.Click
        
        Dim lstrVenderClassID           As String       '部品ID格納
        Dim llngPartLotListCnt          As Integer      '部材ﾘｽﾄのｶｳﾝﾄ
        Dim lblnAns                     As Boolean      '汎用戻り値
        Dim ltypMasPartlist             As MasPartlist  '部材ｺｰﾄﾞﾘｽﾄ要求構造体

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
            
            '@取得区分に値ｾｯﾄ
            pstrfrmxxCM0090Kbn = CPstrCD0M
            
            '@投入予定ﾛｯﾄ一覧画面をﾛｰﾄﾞ
            frmxxCM0090.Instance = New frmxxCM0090()
            
            '@投入予定ﾛｯﾄ一覧画面名設定
            frmxxCM0090.Instance.Text = CPstrSubDispTitleLotThrwList
           
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM0090.Instance = Nothing
                Exit Sub
            End If
            
            '@投入予定ﾛｯﾄ選択画面表示
            frmxxCM0090.Instance.ShowDialog(Me)
            frmxxCM0090.Instance = Nothing
            
            '@投入予定ﾛｯﾄ選択結果処理
            If pblnCancel = True Then
                '@ｷｬﾝｾﾙ初期化
                pblnCancel = False
            Else
                '@選択投入予定ﾛｯﾄ表示
                With ptypLotRlst
                    lblLotID.Text = .strLotID                    'ﾛｯﾄID
                    lblDivision.Text = .strFlowClass             '種別ID
                    lblPd.Text = .strPdId                        '機種ID
                    lblWF.Text = .strWfNum                       'WF枚数
                    If IsDate(.strPlanThrowinDate) Then 
                        lblThrowinDate.Text = Format$(CDate(.strPlanThrowinDate), CPstrDateTimeYMD)   '投入予定日
                    Else
                        lblThrowinDate.Text = .strPlanThrowinDate
                    End If
                    lblLotManager.Text = .strEngEmpName          'ﾛｯﾄ担当
                End With
                
                '@ﾌｫｰﾑ(ﾍｯﾀﾞｰ部以外)初期化処理
                Call prvInputInfo_Init()
                
                '@ｽﾛｯﾄﾏｯﾌﾟの初期化
                Call prvvsfSlotMap_init()
            
                'WFのみ取得(ﾃﾞｰﾀは必ず１件)
                If mtypVenderlist.lngVenderClassListCnt = 1 Then
                    '@部品IDを取得
                    lstrVenderClassID = mtypVenderlist.typVenderClassList(0).strVenderClassId

                    '@投入予定一覧表用に部品IDを格納する。
                    ptypPart.strVenderClassId = lstrVenderClassID
                    
                    '@機種IDを退避
                    mstrPDID = lblPd.Text
                    
                    '@部材ｺｰﾄﾞﾘｽﾄ要求構造体へ格納
                    With ltypMasPartlist
                        .strSbID = pstrSBID                         '処理区分
                        .strMsgVer = CMstrmas_partlistVer           'ﾒｯｾｰｼﾞVersion
                        .strPdId = mstrPDID                         '機種ID
                        .strMasPdVersion = ptypLotRlst.strMasVer    'PDVersion(投入予定ﾛｯﾄ取得より)
                        .strVenderClassId = vbNullString
                    End With
                                        
                    '@部材ｺｰﾄﾞ、ﾍﾞﾝﾀﾞｰ取得
                    lblnAns = pubblnMasPartList_Sel(ltypMasPartlist, llngPartLotListCnt, mtyppartlist)
                    '@結果判定
                    If lblnAns = False Then
                        '@ｴﾗｰの場合
                        '@異常の場合終了
                        Exit Sub
                    End If

                    '@利用部材ｺﾝﾎﾞﾎﾞｯｸｽ設定
                    Call prvCmbPartName_Disp(llngPartLotListCnt)
                    
                    '@利用部材が0件の場合
                    If llngPartLotListCnt = 0 Then
                        '@投入予定ﾛｯﾄ登録ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdResvLot)
                        Exit Sub
                    End If
                End If
                
                '@各ｺﾝﾄﾛｰﾙを使用可能にする
                cmdCarrierSelect.Enabled = True                     '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
                cmdClear.Enabled = True                             '全部取り消しﾎﾞﾀﾝ
                txtCarrierID.Enabled = True                         'ｷｬﾘｱID
                cmbPartName.Enabled = True                          '利用部材使用
                cmbPrioSel.Enabled = True                           '優先度
                cmbThrowinWP.Enabled = True                         '投入装置

                '@↓2020/03/27 (Fri) 13:51:43 T.Oide 「.Netへ反映未」 **************************************************
                optOnlineflg1.Enabled = True                        'ｵﾝﾗｲﾝ
                optOnlineflg0.Enabled = True                        'ｵﾌﾗｲﾝ
                optOnlineflg1.Checked = True                        '初期値はｵﾝﾗｲﾝにﾁｪｯｸ
                optOnlineflg0.Checked = False                       'ｵﾌﾗｲﾝ
                '@-----------------------------------------------------------------------------

                '@↓2020/09/18 (Fri) 12:01:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                '@ﾚｰｻﾞｰﾏｰｶｽｷｯﾌﾟﾌﾗｸﾞはOnか
                If ptypLotRlst.strLaserMarkerSkipFlag = CPstrFlagOn Then
                    labLaserMark.Text = CMstrLaserMarkRyudou  '流動中
                    'optOnlineflg(CMstrOnline).Value = False     'ｵﾝﾗｲﾝOff
                    'optOnlineflg(CMstrOnline).Enabled = False   'ｵﾝﾗｲﾝ無効
                    'optOnlineflg(CMstrOffline).Value = True     'ｵﾌﾗｲﾝOn
                    'optOnlineflg(CMstrOffline).Enabled = True   'ｵﾌﾗｲﾝ有効
                Else
                    labLaserMark.Text = CMstrLaserMarkTounyu   '投入時
                    'optOnlineflg(CMstrOnline).Value = True      'ｵﾝﾗｲﾝOn
                    'optOnlineflg(CMstrOnline).Enabled = True    'ｵﾝﾗｲﾝ有効
                    'optOnlineflg(CMstrOffline).Value = False    'ｵﾌﾗｲﾝOff
                    'optOnlineflg(CMstrOffline).Enabled = True   'ｵﾌﾗｲﾝ有効
                End If
                '@↑2020/09/18 (Fri) 12:01:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                '@↑2020/03/27 (Fri) 13:51:43 T.Oide 「.Netへ反映未」 **************************************************
            End If
            
            '@WF枚数格納(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ用)
            If IsNumeric(lblWF.Text) = True Then
                '@WF枚数項目が数値の場合
                mlngWFNum = lblWF.Text
            Else
                mlngWFNum = 0
            End If
                
            '@ﾛｯﾄID、ｷｬﾘｱID、ﾍﾞﾝﾀﾞｰﾛｯﾄID、在庫数が設定されている場合
            If lblLotID.Text <> vbNullString And _
               lblInvLotID.Text <> vbNullString And _
               IsNumeric(lblInvNum.Text) = True Then
               
                '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ解除
                vsfSlotMap.Enabled = True
                cmdUP.Enabled = True
                cmdDown.Enabled = True
                
                Call pubVsfDisp(vsfSlotMap, cmdUP, cmdDown)
                
                '@在庫数格納(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ用)
                If IsNumeric(lblInvNum.Text) = True Then
                    '@在庫数項目が数値の場合
                    mcurInvNum = CDec(lblInvNum.Text)
                Else
                    mcurInvNum = 0
                End If
            Else
                '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ
                vsfSlotMap.Enabled = False
                cmdUP.Enabled = False
                cmdDown.Enabled = False
            End If
            
            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
            '@空きｷｬﾘｱ選択ﾎﾞﾀﾝが有効の場合
            If cmdCarrierSelect.Enabled = True Then
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdCarrierSelect)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdResvLot_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdVenderLot_Click
    '機　能：ﾍﾞﾝﾀﾞｰﾛｯﾄ選択画面表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 15:42:45 M.Miura
    '更新日：2018/11/15 (Thu) 16:04:44 T.Oide
    '備　考：
    Private Sub cmdVenderLot_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVenderLot.Click

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

        '@↓2018/11/15 (Thu) 16:07:19 T.Oide **************************************************
            '@呼出元ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄｾｯﾄ
            ptypPart.objParentFrom = Me
        '@↑2018/11/15 (Thu) 16:07:19 T.Oide **************************************************

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@ﾍﾞﾝﾀﾞｰﾛｯﾄ一覧表示
        '@↓2018/11/15 (Thu) 16:04:35 T.Oide **************************************************
        '@    Load frmxxEN0042
            frmxxCM01C0.Instance = New frmxxCM01C0()
        '@↑2018/11/15 (Thu) 16:04:35 T.Oide **************************************************
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
        '@↓2018/11/15 (Thu) 16:05:11 T.Oide **************************************************
        '@        Unload frmxxEN0042
                frmxxCM01C0.Instance = Nothing
        '@↑2018/11/15 (Thu) 16:05:11 T.Oide **************************************************
                Exit Sub
            End If
            
            '@ﾍﾞﾝﾀﾞｰﾛｯﾄ選択画面表示
        '@↓2018/11/15 (Thu) 16:05:40 T.Oide **************************************************
        '@    Call frmxxEN0042.Show(vbModal)
            frmxxCM01C0.Instance.ShowDialog(Me)
            frmxxCM01C0.Instance = Nothing
        '@↑2018/11/15 (Thu) 16:05:40 T.Oide **************************************************

            '@ﾍﾞﾝﾀﾞｰﾛｯﾄID、在庫数が設定されている場合
            If lblLotID.Text <> vbNullString And _
               lblInvLotID.Text <> vbNullString And _
               IsNumeric(lblInvNum.Text) = True Then
               
                '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ解除
                vsfSlotMap.Enabled = True
                cmdUP.Enabled = True
                cmdDown.Enabled = True
                
                Call pubVsfDisp(vsfSlotMap, cmdUP, cmdDown)
                
                '@在庫数格納(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ用)
                If IsNumeric(lblInvNum.Text) = True Then
                    '@在庫数項目が数値の場合
                    mcurInvNum = CDec(lblInvNum.Text)
                Else
                    mcurInvNum = 0
                End If
                
                '@入力ﾁｪｯｸ
                Call prvcmdRegist_Chk()
            Else
                '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ
                vsfSlotMap.Enabled = False
                cmdUP.Enabled = False
                cmdDown.Enabled = False
            End If
            
            '@優先順位にﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(cmbPrioSel)
            
            '@ﾏｳｽｷｬﾝｾﾙﾌﾗｸﾞにTrueを設定する
            mblnMouseCancelFlag = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdVenderLot_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUP_Click
    '機　能：前ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/02 (Tue) 17:04:32 M.Miura
    '更新日：2004/04/13 (Tue) 09:34:03 H.Wajima
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

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfSlotMap, cmdUP, cmdDown)

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
    '機　能：次ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/02 (Tue) 09:34:18 M.Miura
    '更新日：2004/04/13 (Tue) 09:33:58 H.Wajima
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

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
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

    '関数名：cmdClear_Click
    '機　能：画面初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 11:13:13 M.Miura
    '更新日：2005/03/14 (Mon) 16:26:11 N.Kojima
    '備　考：2005/03/14 (Mon) 16:26:11 N.Kojima     投入装置追加に伴う修正(改善№577)
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@画面初期化
            Call prvfrmxxEN0040_Clear()
            
            '@優先順位ｺﾝﾎﾞﾎﾞｯｸｽ初期値ｾｯﾄ
            cmbPrioSel.ListIndex = CMstrcmbPrioSel
            
            '@投入装置ｺﾝﾎﾞﾎﾞｯｸｽ初期化
            cmbThrowinWP.ListIndex = -1
            
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
    '機　能：投入確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 11:40:16 M.Miura
    '更新日：2005/04/01 (Fri) 09:13:29 N.Kojima
    '備　考：2004/07/27 (Tue) 08:52:49 Y.Yamagishi
    '　　　：2004/10/12 (Tue) 16:36:09 N.Kasai      ｽﾛｯﾄ№の計算に不備発見修正
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean          '投入予約登録戻り値(True/False)
        Dim llngCnt                 As Integer          'ｶｳﾝﾄ
        Dim ltypLotThrowin          As LotThrowin       '投入要求格納用
        Dim lstrGuidMsg             As String           'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String           'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ

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
            
            '@画面項目ﾁｪｯｸ
            lblnAns = prvInputInfo_Chk(CMvsfSlotMapColVenderLotID)
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
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "cmdRegist_Click"
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@ﾛｯﾄ投入ﾃﾞｰﾀ作成
            With ltypLotThrowin
                .strMsgVer = CMstrlot_throwin_Ver               'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strLotID = lblLotID.Text                       'ﾛｯﾄID
                .strCarrierId = txtCarrierID.Text               'ｷｬﾘｱID
                .strEmpID = pstrUserID                          '作業者ｺｰﾄﾞ
                .strLotPriority = cmbPrioSel.Value              '優先度
                .strWpID = cmbThrowinWP.Value                   '装置ID(投入装置ID)

                '@処理形態でｵﾝﾗｲﾝにﾁｪｯｸがある場合
                If optOnlineflg1.Checked = True Then
                    '@構造体に"1"(ｵﾝﾗｲﾝ)をｾｯﾄ
                    .strOnlineFlag = CMstrOnline
                Else
                    '@構造体に"0"(ｵﾌﾗｲﾝ)をｾｯﾄ
                    .strOnlineFlag = CMstrOffline
                End If
                
                '@WFMap処理
                .typWFMapList = New List(Of LotThrowinWFMapList)(CInt(mstrSlotSize))
                For llngCnt = 1 To CInt(mstrSlotSize)
                    Dim typ As LotThrowinWFMapList = New LotThrowinWFMapList
                    '@設定されている場合
                    If vsfSlotMap.GetData(CMvsfSlotMapRowS - llngCnt, CMvsfSlotMapColVender) <> vbNullString Then
                        typ.strInvLotId = _
                            vsfSlotMap.GetData(CMvsfSlotMapRowS - llngCnt, CMvsfSlotMapColVenderLotID)      '在庫ﾛｯﾄID
                    End If
                        typ.strSlotNo = CStr(Format$(llngCnt, CPstrSlotNoFormat))                           'ｽﾛｯﾄ№
                    .typWFMapList.Add(typ)
                Next llngCnt
            End With
            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnLotThrowin_Sel(ltypLotThrowin, mstrSlotSize, lstrGuidMsg, lstrGuidMsgCode)
            '@結果判定
            If lblnAns = True Then
                '@"<TRM07I>$$ロット[%2]を投入しました。キャリア[%1]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0007, txtCarrierID.Text, lblLotID.Text)
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@画面初期化
                Call prvfrmxxEN0040_Clear()
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
                
                '@ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ表示制御
                Call pubGuidMsg_Set(lstrGuidMsgCode, lstrGuidMsg, Me)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
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

    '関数名：optOnlineflg_Click
    '機　能：ｵﾌﾟｼｮﾝﾎﾞﾀﾝ押下処理
    '引　数：Index：0→ｵﾌﾗｲﾝ、1：ｵﾝﾗｲﾝ
    '戻り値：
    '作成日：2005/03/17 (Thu) 10:39:53 N.Kojima
    '更新日：2005/03/17 (Thu) 10:39:53
    '備　考：
    Private Sub optOnlineflg_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optOnlineflg0.CheckedChanged, optOnlineflg1.CheckedChanged

        Try
            
            'NSYS チェックオンの時のみ本体処理を実行 (VB6互換)
            If CType(sender, RadioButton).Checked = False Then
                Exit Sub
            End If

            '@ｵﾌﾗｲﾝが選択された場合
            If optOnlineflg0.Checked = True Then
                '@投入装置を有効に
                cmbThrowinWP.Enabled = True
                
                '@装置が1件の場合、ﾃﾞﾌｫﾙﾄ表示
                If cmbThrowinWP.ListCount = 1 Then
                    '@1件目表示
                    cmbThrowinWP.ListIndex = 0
                End If
            Else
                '@ｺﾝﾎﾞ表示初期化
                cmbThrowinWP.ListIndex = -1
                '@投入装置を無効に
                cmbThrowinWP.Enabled = False
            End If
            
            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optOnlineflg_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optOnlineflg_Validate
    '機　能：ｵﾌﾟｼｮﾝﾎﾞﾀﾝValidate処理
    '引　数：Index：0=ｵﾌﾗｲﾝ,1=ｵﾝﾗｲﾝ
    '　　　：Cancel：true,false
    '戻り値：なし
    '作成日：2005/03/23 (Wed) 10:10:54 N.Kojima
    '更新日：2005/03/23 (Wed) 10:10:54
    '備　考：
    Private Sub optOnlineflg_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles optOnlineflg0.Validating, optOnlineflg1.Validating
        
        Dim llblFlag        As Boolean      'ﾃﾞｰﾀ判定ﾌﾗｸﾞ
        Dim llngCnt         As Integer      'ｶｳﾝﾄ

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            llblFlag = True
            
            With vsfSlotMap
                '@ｽﾛｯﾄﾏｯﾌﾟ(WF)の状況
                For llngCnt = 1 To .Rows.Count - 1
                    '@ﾍﾞﾝﾀﾞｰﾛｯﾄID存在ﾁｪｯｸ
                    If .GetData(llngCnt, CMvsfSlotMapColVenderLotID) <> vbNullString Then
                        llblFlag = False
                        Exit For
                    End If
                Next llngCnt
            End With
            
            '@ｽﾛｯﾄにﾃﾞｰﾀがない場合
            If llblFlag = True Then
                '@最下行にﾌｫｰｶｽｾｯﾄ
                vsfSlotMap.Row = CMvsfSlotMapBottomRow
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optOnlineflg_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Change
    '機　能：ｷｬﾘｱIDﾁｪﾝｼﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/22 (Thu) 12:57:02 Y.Yamagishi
    '更新日：2004/04/22 (Thu) 12:57:02
    '備　考：
    Private Sub txtCarrierID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID.Change

        Try
            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierSelect_Click
    '機　能：空きキャリア一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/12 (Mon) 13:32:16 M.Miura
    '更新日：2007/07/24 (Tue) 15:12:22 N.Kasai
    '備　考：2004/10/21 (Thu) 09:21:55 Y.Yamagishi  ｷｬﾘｱﾀｲﾌﾟID引渡し処理追加(FOUP)
    '　　　：2005/01/12 (Wed) 17:13:04 H.Wajima     ﾏｳｽｷｬｾﾙﾌﾗｸﾞ設定処理追加
    '　　　：2005/10/06 (Thu) 16:34:39 S.Deguchi    ｷｬﾘｱの洗浄条件設定処理を追加
    '　　　：2007/07/24 (Tue) 15:12:22 N.Kasai      ｷｬﾘｱ洗浄条件変更(№02075)
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
            pstrCarrierID = txtCarrierID.Text
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@ｷｬﾘｱﾀｲﾌﾟID引渡し
            pstrCarrierTypeID = CPstrCarrTypeFOUP
            
            '@未洗浄可
            pstrCleanCondition = CPstrCarrierClean1
            
            '@空きｷｬﾘｱ一覧表示
            frmxxCM00E0.Instance = New frmxxCM00E0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00E0.Instance = Nothing
                Exit Sub
            End If
            
            '@ｷｬﾘｱ一覧表示
            frmxxCM00E0.Instance.ShowDialog(Me)
            frmxxCM00E0.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrCarrierID <> vbNullString Then
                '@ｷｬﾘｱIDをｾｯﾄ
                txtCarrierID.Text = pstrCarrierID
            End If
            
            '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrierID)
            
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID
            
            '@ﾏｳｽｷｬﾝｾﾙﾌﾗｸﾞにTrueを設定する
            mblnMouseCancelFlag = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierSelect_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap_MouseDown
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ ﾏｳｽﾀﾞｳﾝ処理
    '引　数：Button：未使用
    '　　　：Shift：未使用
    '　　　：X：未使用
    '　　　：Y：未使用
    '戻り値：なし
    '作成日：2005/01/12 (Wed) 17:12:14 H.Wajima
    '更新日：2005/01/12 (Wed) 17:12:14
    '備　考：
    Private Sub vsfSlotMap_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfSlotMap.MouseDown

        Try
            mblnMouseDrag = True

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If
            
            'NSYS VB6互換でマウスのダブルクリックでMouseUp処理を行わない
            If e.Clicks = 1 Then
                'NSYS シングルクリック時
                mblnDoubleClickOn = False
            Else
                'NSYS ダブルクリック時
                mblnDoubleClickOn = True
                Exit Sub
            End If

            With vsfSlotMap
                '@ﾍｯﾀﾞｰの№列をｸﾘｯｸされたら
                If .MouseRow = 0 And .MouseCol = CMvsfSlotMapColSlot Then
                    '@全選択
                    .Select(CMvsfSlotMapRowTitle + 1, .Cols.Fixed , CMvsfSlotMapBottomRow, .Cols.Count - 1 , False)
                End If
            End With

            '@ﾏｳｽｷｬﾝｾﾙﾌﾗｸﾞにFalseを設定する
            mblnMouseCancelFlag = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap_MouseDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap_MouseUp
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ ﾏｳｽｱｯﾌﾟ処理
    '引　数：Button：未使用
    '　　　：Shift：未使用
    '　　　：X：未使用
    '　　　：Y：未使用
    '戻り値：なし
    '作成日：2004/12/29 (Wed) 10:27:21 H.Wajima
    '更新日：2005/01/12 (Wed) 17:10:55 H.Wajima
    '備　考：Clickから移動
    '　　　：2005/01/12 (Wed) 17:10:55 H.Wajima  ﾏｳｽｷｬｾﾙﾌﾗｸﾞの判定処理追加
    Private Sub vsfSlotMap_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfSlotMap.MouseUp

        Try
            mblnMouseDrag = False

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If

            If mblnDoubleClickOn = True Then
                'NSYS VB6互換動作でダブルクリック時処理を行わない
                Exit Sub
            End If

            '@ﾏｳｽｷｬﾝｾﾙﾌﾗｸﾞの判定
            If mblnMouseCancelFlag = False Then
                '@ｽﾛｯﾄﾏｯﾌﾟ選択処理を実行する
                Call prvvsfSlotMapSel_Proc()
                
                '@ﾏｳｽｷｬﾝｾﾙﾌﾗｸﾞにTrueを設定する
                mblnMouseCancelFlag = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '======================================Public===========================================

    '関数名：txtCarrierID_Validate
    '機　能：ｷｬﾘｱID入力ﾁｪｯｸ
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/03/09 (Tue) 13:01:10 M.Miura
    '更新日：2004/08/27 (Fri) 17:24:44 N.Kasai
    '備　考：空きｷｬﾘｱ確認ﾛｼﾞｯｸを追加(2004/08/03)
    '　　　：2004/08/27 (Fri) 17:24:44 N.Kasai　ｷｬﾘｱﾀｲﾌﾟ追加
    Public Sub txtCarrierID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierID.Validating
        
        Dim lblnAns                 As Boolean          '結果取得(True:正常,False:異常)
        Dim ltypCarrCurstate        As CarrCurstate     'ｷｬﾘｱ状態確認要求構造体

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDがある場合
            If Trim$(txtCarrierID.Text) <> vbNullString Then
                '@ｷｬﾘｱIDの桁ﾁｪｯｸ
                If txtCarrierID.NowByte < CPlngCarrierMaxLength Then
                    '@"<TRM07W>$$キャリアIDは6桁で入力してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    e.Cancel = True
                    Call pubSetFocus(txtCarrierID)
                    Exit Sub
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                mstrEventName = "txtCarrierID_Validate"
                Call pubResponseStart(Me.Name, mstrEventName)
                
                '@ｷｬﾘｱ情報(要求)格納
                With ltypCarrCurstate
                    .strCarrierId = txtCarrierID.Text   'ｷｬﾘｱID
                    .strClassDivision = CPstrCD1G       'ﾛｯﾄ投入
                    .strMsgVer = CMstrcarrcurstateVer   'MSGVER
                    .strSbID = pstrSBID                 '処理区分
                    .strCarrierTypeID = vbNullString    'ｷｬﾘｱﾀｲﾌﾟ(判断はできない)
                End With
                
                '@ｷｬﾘｱ状態取得
                lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, True, mstrSlotSize)
                
                '@取得結果確認
                If lblnAns = True Then
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    e.Cancel = True
                    Call pubSetFocus(txtCarrierID)
                    Exit Sub
                End If
            Else
                '@退避用ｽﾛｯﾄｻｲｽﾞ初期化
                mstrSlotSize = vbNullString
            End If
            
            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID_Validate"
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
    '関数名：prvfrmxxEN0040_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 11:26:36 M.Miura
    '更新日：2008/06/04 (Wed) 10:31:07 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 11:33:53 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理追加
    '　　　：2004/10/19 (Tue) 11:00:54 M.Miura      CausesValidation設定を追加
    '　　　：2004/10/27 (Wed) 15:08:49 M.Miura      在庫数(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ用)がﾗﾍﾞﾙになっていたので変数に変更
    '　　　：2005/03/14 (Mon) 17:10:59 N.Kojima     投入装置追加に伴う修正(改善№577)
    '　　　：2008/06/04 (Wed) 10:31:07 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN0040_Init()

        Dim lstrFormTitle       As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0040, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@初期値設定
            txtCarrierID.Text = vbNullString            'ｷｬﾘｱID
            lblLotID.Text = vbNullString                'ﾛｯﾄID
            lblDivision.Text = vbNullString             '種別ID
            lblPd.Text = vbNullString                   '機種ID
            lblWF.Text = vbNullString                   'WF枚数
            lblThrowinDate.Text = vbNullString          '投入予定日
            lblLotManager.Text = vbNullString           'ﾛｯﾄ担当
            lblVenderName.Text = vbNullString           'ﾍﾞﾝﾀﾞｰ
            lblInvLotID.Text = vbNullString             'ﾍﾞﾝﾀﾞｰﾛｯﾄID
            lblProductionLotID.Text = vbNullString      'ﾍﾞﾝﾀﾞｰﾛｯﾄID
            lblInvNum.Text = vbNullString               '在庫数
            optOnlineflg0.Checked = False               'ｵﾝﾗｲﾝTrue
            optOnlineflg1.Checked = False               'ｵﾌﾗｲﾝFalse
            mcurInvNum = 0                              '在庫数(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ用)
            mstrPDID = vbNullString                     '機種ID退避用
            
            '@ﾛｯｸ設定
            txtCarrierID.Enabled = False                'ｷｬﾘｱID
            cmbPartName.Enabled = False                 '利用部材
            cmbPrioSel.Enabled = False                  '優先度
            cmbThrowinWP.Enabled = False                '投入装置
            optOnlineflg0.Enabled = False               'ｵﾌﾗｲﾝ
            optOnlineflg1.Enabled = False               'ｵﾝﾗｲﾝ
            
            '@ﾎﾞﾀﾝ使用不可設定
            cmdCarrierSelect.Enabled = False            '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
            cmdVenderLot.Enabled = False                '在庫ﾛｯﾄ選択ﾎﾞﾀﾝ
            cmdUP.Enabled = False                       '前ﾍﾟｰｼﾞﾎﾞﾀﾝ
            cmdDown.Enabled = False                     '次ﾍﾟｰｼﾞﾎﾞﾀﾝ
            cmdRegist.Enabled = False                   '確定ﾎﾞﾀﾝ
            cmdClear.Enabled = False                    '全部取り消しﾎﾞﾀﾝ
            
            '@Validateを実行しない
            cmdCarrierSelect.CausesValidation = False   '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
            cmdClose.CausesValidation = False           '閉じるﾎﾞﾀﾝ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0040_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvInputInfo_Init
    '機　能：ﾌｫｰﾑ(ﾍｯﾀﾞｰ部以外)初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 11:26:36 M.Miura
    '更新日：2005/03/14 (Mon) 17:12:32 N.Kojima
    '備　考：2004/10/27 (Wed) 15:11:37 M.Miura      在庫数(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ用)がﾗﾍﾞﾙになっていたので変数に変更
    '　　　：2005/03/14 (Mon) 17:12:32 N.Kojima     投入装置追加に伴う修正(改善№577)
    Private Sub prvInputInfo_Init()

        Try

            '@初期値設定
            txtCarrierID.Text = vbNullString            'ｷｬﾘｱID
            lblVenderName.Text = vbNullString           'ﾍﾞﾝﾀﾞｰ
            lblInvLotID.Text = vbNullString             'ﾍﾞﾝﾀﾞｰﾛｯﾄID
            lblProductionLotID.Text = vbNullString      'ﾍﾞﾝﾀﾞｰﾛｯﾄID
            lblInvNum.Text = vbNullString               '在庫数
            optOnlineflg0.Checked = False               'ｵﾝﾗｲﾝTrue
            optOnlineflg1.Checked = False               'ｵﾌﾗｲﾝFalse
            mcurInvNum = 0                              '在庫数(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ用)
            mstrPDID = vbNullString                     '機種ID退避用
            
            '@ﾛｯｸ設定
            txtCarrierID.Enabled = False                'ｷｬﾘｱID
            cmbPartName.Enabled = False                 '利用部材
            cmbPrioSel.Enabled = False                  '優先度
            cmbThrowinWP.Enabled = False                '投入装置
            optOnlineflg0.Enabled = False               'ｵﾌﾗｲﾝ
            optOnlineflg1.Enabled = False               'ｵﾝﾗｲﾝ
            
            '@ﾎﾞﾀﾝ使用不可設定
            cmdCarrierSelect.Enabled = False            '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
            cmdVenderLot.Enabled = False                '在庫ﾛｯﾄ選択ﾎﾞﾀﾝ
            cmdUP.Enabled = False                       '前ﾍﾟｰｼﾞﾎﾞﾀﾝ
            cmdDown.Enabled = False                     '次ﾍﾟｰｼﾞﾎﾞﾀﾝ
            cmdRegist.Enabled = False                   '確定ﾎﾞﾀﾝ
            cmdClear.Enabled = False                    '全部取り消しﾎﾞﾀﾝ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvInputInfo_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMap_init
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 11:46:16 M.Miura
    '更新日：2004/10/27 (Wed) 10:48:18 Y.Yamagishi
    '備　考：2004/10/13 (Wed) 09:05:32 Y.Yamagishi　WF枚数以下のｽﾛｯﾄﾎﾟｼﾞｼｮﾝのみを有効にする(不具合改善№962)
    '　　　：2004/10/27 (Wed) 10:48:18 Y.Yamagishi　WF枚数より大きいｽﾛｯﾄのﾊﾞｯｸｶﾗｰを濃い灰色に変更
    Private Sub prvvsfSlotMap_init()

        Dim llngCnt As Integer  'ｶｳﾝﾄ

        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfSlotMap

                .Redraw = False
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear
                
                '@文字表示位置設定
                .Cols(CMvsfSlotMapColSlot).TextAlign = TextAlignEnum.LeftCenter                    '左中央
                .Cols(CMvsfSlotMapColVender).TextAlign = TextAlignEnum.LeftCenter                  '左中央
                .Cols(CMvsfSlotMapColVenderLotID).TextAlign = TextAlignEnum.LeftCenter             '左中央
                
                '@行数設定
                .Rows.Count = CMvsfSlotMapRowS
                .Rows.DefaultSize = CMvsfSlotMapHeight
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.None
                
                '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽがある時のみﾊｲﾗｲﾄ
                .HighLight = HighLightEnum.WithFocus

                '@一覧表の表題設定
                .Select(CMvsfSlotMapRowTitle, CMvsfSlotMapColSlot, CMvsfSlotMapRowTitle, CMvsfSlotMapColVenderLotID)
                Dim cellRange As CellRange = .GetCellRange(CMvsfSlotMapRowTitle, CMvsfSlotMapColSlot, CMvsfSlotMapRowTitle, CMvsfSlotMapColVenderLotID)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                      '中央表示
                headerStyle.ForeColor = Color.Yellow                                                    '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                       '背景色
                headerStyle.Font = new Font(.Font.FontFamily, CMvsfSlotHMaCellFontSize)                 'ﾌｫﾝﾄｻｲｽﾞ
                headerStyle.Trimming = StringTrimming.None                                              'NSYS ﾍｯﾀﾞは省略表示なしに設定
                .Rows(CMvsfSlotMapRowTitle).Height = CMvsfSlotMapHHeight                                '高さ
                
                '@一覧表のSlot№設定
                For llngCnt = 1 To CMvsfSlotMapRowS - 1
                    headerStyle.Font = new Font(.Font.FontFamily, CMvsfSlotHMaCellFontSize)     'ﾌｫﾝﾄｻｲｽﾞ


                    .SetData(llngCnt, CMvsfSlotMapColSlot, _
                        CStr(Format$(CMvsfSlotMapRowS - llngCnt, CPstrSlotNoFormat)))           'ｽﾛｯﾄ№
                    
                    .Rows(llngCnt).Height = CMvsfSlotMapHeight                                  '行高さ
                    
                    '@WF枚数が空白以外の場合
                    If lblWF.Text <> vbNullString Then
                        '@ｽﾛｯﾄ№がWF枚数以下の場合
                        If CInt(.GetData(llngCnt, CMvsfSlotMapColSlot)) <= CInt(lblWF.Text) Then
                            '@背景色を白に変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White
                            Dim cellSlotRange As CellRange = .GetCellRange(llngCnt, CMvsfSlotMapColVender, _
                                                   llngCnt, CMvsfSlotMapColVenderLotID)
                            cellSlotRange.Style = newStyle
                        Else
                        '@ｽﾛｯﾄ№がWF枚数より大きい場合
                            '@背景色を濃い灰色に変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                            Dim cellSlotRange As CellRange = .GetCellRange(llngCnt, CMvsfSlotMapColVender, _
                                                   llngCnt, CMvsfSlotMapColVenderLotID)
                            cellSlotRange.Style = newStyle
                        End If
                    End If

                    cellRange.Style = headerStyle
                    
                Next llngCnt
                
                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMvsfSlotMapColSlot).Width = CMvsfSlotMapColWSlot
                .SetData(CMvsfSlotMapRowTitle, CMvsfSlotMapColSlot, CMvsfSlotMapColTSlot)
                
                .Cols(CMvsfSlotMapColVender).Width = CMvsfSlotMapColWVender
                .SetData(CMvsfSlotMapRowTitle, CMvsfSlotMapColVender, CMvsfSlotMapColTVender)
                
                .Cols(CMvsfSlotMapColVenderLotID).Width = CMvsfSlotMapColWVenderLotID
                .SetData(CMvsfSlotMapRowTitle, CMvsfSlotMapColVenderLotID, CMvsfSlotMapColTVenderLotID)
                
                .Col = CMvsfSlotMapColVender
                
                .Redraw = True
                '@ﾛｯｸ
                .Enabled = False
                
                '@初期表示行番号設定
                .TopRow = CMvsfSlotMapSTopRow
                
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

        End Try
    End Sub

    '関数名：prvfrmxxEN0040_Clear
    '機　能：画面初期化(ｽﾃｰﾀｽﾊﾞｰ以外)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/05 (Fri) 14:26:20 M.Miura
    '更新日：2005/03/14 (Mon) 17:13:58 N.Kojima
    '備　考：2005/03/14 (Mon) 17:13:58 N.Kojima     投入装置追加に伴う修正(改善№577)
    Private Sub prvfrmxxEN0040_Clear()

        Try

            '@画面初期化
            Call prvfrmxxEN0040_Init()
            
            '@ｽﾛｯﾄﾏｯﾌﾟの初期化
            Call prvvsfSlotMap_init()
            
            '@部材ﾘｽﾄ初期化
            cmbPartName.ListIndex = -1
            '@優先順位ｺﾝﾎﾞﾎﾞｯｸｽ初期値ｾｯﾄ
            cmbPrioSel.ListIndex = CMstrcmbPrioSel
            '@投入装置ｺﾝﾎﾞﾎﾞｯｸｽ初期化
            cmbThrowinWP.ListIndex = -1
            
            '@投入予定ﾛｯﾄID選択ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(cmdResvLot)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0040_Clear"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMap_Chk
    '機　能：ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ
    '引　数：なし
    '戻り値：True：設定あり、False：設定なし
    '作成日：2004/03/09 (Tue) 14:47:41 M.Miura
    '更新日：2004/03/09 (Tue) 14:47:41
    '備　考：
    Private Function prvvsfSlotMap_Chk() As Boolean

        Dim llblErr     As Boolean  'ﾍﾞﾝﾀﾞｰﾛｯﾄ存在ﾌﾗｸﾞ　True：存在なし、False：存在あり
        Dim llngRCnt    As Integer  'ｶｳﾝﾄ
        Dim llngWFcnt   As Integer  'WF設定ｶｳﾝﾄ数

        Try
            
            '@初期化
            prvvsfSlotMap_Chk = False
            
            With vsfSlotMap
                '@存在ﾌﾗｸﾞを初期化
                llblErr = True
                
                '@ｽﾛｯﾄﾏｯﾌﾟ(WF)の状況
                For llngRCnt = 1 To .Rows.Count - 1
                    '@ﾍﾞﾝﾀﾞｰﾛｯﾄID存在ﾁｪｯｸ
                    If .GetData(llngRCnt, CMvsfSlotMapColVenderLotID) <> vbNullString Then
                        '@WF設定ｶｳﾝﾄｱｯﾌﾟ
                        llngWFcnt = llngWFcnt + 1
                        
                        '@存在ﾌﾗｸﾞ設定
                        llblErr = False
                    End If
                Next llngRCnt
                
                '@設定WF枚数が投入WF枚数より少ない場合
                If llngWFcnt <> CLng(lblWF.Text) Then
                    '@確定ﾎﾞﾀﾝ無効
                    cmdRegist.Enabled = False
                    
                    '@存在ﾌﾗｸﾞを戻す
                    llblErr = True
                Else
                    '@同じ場合
                    cmdRegist.Enabled = True
                End If
            End With
            
            '@ﾍﾞﾝﾀﾞｰﾛｯﾄ設定あり
            If llblErr = False Then
                '@成功を返す
                prvvsfSlotMap_Chk = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvInputInfo_Chk
    '機　能：投入確定前ﾁｪｯｸ
    '引　数：lvsfSlotMapColVender：ﾍﾞﾝﾀﾞｰ列番号
    '戻り値：True：ﾍﾞﾝﾀﾞｰあり、False：ﾍﾞﾝﾀﾞｰなし
    '作成日：2004/03/03 (Wed) 18:33:45 M.Miura
    '更新日：2005/03/15 (Tue) 13:00:32 N.Kojima
    '備　考：2005/03/15 (Tue) 13:00:32 N.Kojima     投入装置追加に伴う修正(改善№577)
    Private Function prvInputInfo_Chk(ByVal lvsfSlotMapColVenderLotID As Integer) As Boolean

        Dim llngRCnt        As Integer  'ｶｳﾝﾄ
        Dim llblErr         As Boolean  'ｴﾗｰﾌﾗｸﾞ(True：ｴﾗｰ、False：正常)
        Dim llngWFcnt       As Integer  'WF設定ｶｳﾝﾄ数

        Try
            
            '@初期化
            prvInputInfo_Chk = False
            llngWFcnt = 1
            llblErr = True
            
            '@ﾛｯﾄIDﾁｪｯｸ
            If lblLotID.Text = vbNullString Then
                '@"<TRM22W>$$ロットIDが設定されていません。設定を見直してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0022)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Call pubSetFocus(cmdResvLot)
                Exit Function
            End If
            
            '@ｷｬﾘｱIDﾁｪｯｸ
            If Trim(txtCarrierID.Text) = vbNullString Then
                '@"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Call pubSetFocus(txtCarrierID)
                Exit Function
            End If

            With vsfSlotMap
                '@ｽﾛｯﾄﾏｯﾌﾟ(WF)の状況
                For llngRCnt = 1 To .Rows.Count - 1
                    If .GetData(llngRCnt, lvsfSlotMapColVenderLotID) <> vbNullString Then
                        llngWFcnt = llngWFcnt + 1
                        llblErr = False
                    End If
                Next llngRCnt
                
                '@設定WF枚数確定
                If llngWFcnt <> 1 Then
                    llngWFcnt = llngWFcnt - 1
                End If
                
                '@ｽﾛｯﾄﾏｯﾌﾟ(WF)のﾁｪｯｸ
                If llblErr = True Then
                    '@"<TRM23W>$$ベンダーロットIDが設定されていません。設定を見直してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0023)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Exit Function
                End If
                
                If llngWFcnt <> CLng(lblWF.Text) Then
                    '@"<TRM24W>$$投入予定のウエハ枚数と設定数が異なります。設定を見直してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0024)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Exit Function
                End If
                
            End With
            
            '@投入装置ﾁｪｯｸ(ｵﾌﾗｲﾝが選択されていて、投入装置がNULLの場合)
            If cmbThrowinWP.Text = vbNullString And optOnlineflg0.Checked = True Then
                '@"<TRM5FW>$$投入装置が選択されていません。設定を見直してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005F)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@投入装置ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbThrowinWP)
                Exit Function
            End If
            
            '@成功を返す
            prvInputInfo_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvInputInfo_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvcmbPrioSel_Init
    '機　能：ｺﾝﾎﾞﾎﾞｯｸｽ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 13:28:15 Y.Yamagishi
    '更新日：2004/04/19 (Mon) 13:28:15
    '備　考：
    Private Sub prvcmbPrioSel_Init()

        Try

            '@ｺﾝﾎﾞﾎﾞｯｸｽ設定
            With cmbPrioSel
                .Clear
                .DispCols = CMlngCmbPrioSelDispCols                                     'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbPrioSelGridColPriorityName                            'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbPrioSelGridColPriorityID                            '値取得列
                .DirectInput = False                                                    'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = new Font(.Font.FontFamily, CMlngCmbPrioSelFontSize)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = new Font(.GridFont.FontFamily, CMlngCmbPrioSelGridFontSize) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngComboRowHeight                                        '行の高さ
                .ColAlignment(CMlngCmbPrioSelGridColPriorityName) = TextAlignEnum.LeftCenter  '左中央
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPrioSel_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPrioSel_Disp
    '機　能：優先順位情報項目ﾏｽﾀをｺﾝﾎﾞへｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 13:28:56 Y.Yamagishi
    '更新日：2004/06/03 (Thu) 15:26:09 N.Kasai
    '備　考：構造体の0件ﾁｪｯｸは上流工程でﾁｪｯｸ済み
    Private Sub prvcmbPrioSel_Disp()

        Dim llngCnt                 As Integer  'ｶｳﾝﾄ

        Try
                
                '@優先順位項目名ｾｯﾄ
                With cmbPrioSel
                    .Clear
                    For llngCnt = 0 To mtypPriorityReasonList.Count -1

                        .AddItem(mtypPriorityReasonList(llngCnt).strMasPriorityId & CPstrSpace & _
                                 mtypPriorityReasonList(llngCnt).strMasPriorityName & vbTab & _
                                 mtypPriorityReasonList(llngCnt).strMasPriorityId)
                    Next llngCnt
                
                    '@初期表示
                    .ListIndex = CMstrcmbPrioSel
                End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPrioSel_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMap_Disp
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/22 (Thu) 12:55:49 Y.Yamagishi
    '更新日：2004/09/03 (Fri) 10:11:43 Y.Yamagishi
    '備　考：ｽﾛｯﾄﾏｯﾌﾟの最大ｽﾛｯﾄ数をｷｬﾘｱに応じたｽﾛｯﾄ数に変更 2004/09/03 (Fri) 10:11:43 Y.Yamagishi
    Private Sub prvVsfSlotMap_Disp()
        
        Dim llngCnt                     As Integer  'ｶｳﾝﾀ
        Dim llngSlotMapCount            As Integer  'ｶｳﾝﾀ

        Try
            
            '@現在のｽﾛｯﾄ数を退避
            llngSlotMapCount = vsfSlotMap.Rows.Count - 1
            
            If IsNumeric(mstrSlotSize) = True Then
                '@現在のｽﾛｯﾄ数と最大ｽﾛｯﾄｻｲｽﾞを比較
                If llngSlotMapCount <> CLng(mstrSlotSize) Then
                '@違う場合
                    '@ｽﾛｯﾄﾏｯﾌﾟの最大ｽﾛｯﾄ数をｷｬﾘｱに応じたｽﾛｯﾄ数に変更
                    If mstrSlotSize <> vbNullString Then
                        '@ｽﾛｯﾄﾏｯﾌﾟの初期化
                        Call prvvsfSlotMap_init()
                        
                        vsfSlotMap.Rows.Count = CLng(mstrSlotSize) + 1
                        With vsfSlotMap
                            '@ｽﾛｯﾄ№を設定
                            llngCnt = 1
                            
                            Do While vsfSlotMap.Rows.Count > llngCnt
                                .SetData(vsfSlotMap.Rows.Count - llngCnt, CMvsfSlotMapColSlot, _
                                    Format$(llngCnt, CPstrSlotNoFormat))
                                    
                                llngCnt = llngCnt + 1
                            Loop
                        End With
                    End If
                End If
            End If
            
            '@WF枚数格納(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ用)
            If IsNumeric(lblWF.Text) = True Then
                '@WF枚数項目が数値の場合
                mlngWFNum = lblWF.Text
            End If
            
            '@ﾛｯﾄID、ﾍﾞﾝﾀﾞｰﾛｯﾄID、在庫数が設定されている場合
            If lblLotID.Text <> vbNullString And _
               lblInvLotID.Text <> vbNullString And _
               IsNumeric(lblInvNum.Text) = True Then
               
               '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ解除
                vsfSlotMap.Enabled = True
                cmdUP.Enabled = True
                cmdDown.Enabled = True
                
                Call pubVsfDisp(vsfSlotMap, cmdUP, cmdDown)
            
                '@在庫数格納(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ用)
                If IsNumeric(lblInvNum.Text) = True Then
                    '@在庫数項目が数値の場合
                    mcurInvNum = CDec(lblInvNum.Text)
                Else
                    mcurInvNum = 0
                End If
            Else
                '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ
                vsfSlotMap.Enabled = False
                cmdUP.Enabled = False
                cmdDown.Enabled = False
            End If

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

        End Try
    End Sub

    '関数名：prvcmdRegist_Chk
    '機　能：入力ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 16:20:05 M.Miura
    '更新日：2005/03/14 (Mon) 16:22:09 N.Kojima
    '備　考：2005/03/14 (Mon) 16:22:09 N.Kojima     投入装置追加に伴う修正(改善№577)
    Private Sub prvcmdRegist_Chk()
        
        Dim lblnAns As Boolean  '戻り値

        Try

            '@ﾛｯﾄIDがない場合
            If lblLotID.Text = vbNullString Then
                '@ﾛｯｸ
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDがない、又は、6桁以外の場合
            If txtCarrierID.Text = vbNullString Or Len(txtCarrierID.Text) <> CPlngCarrierMaxLength Then
                '@ﾛｯｸ
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            '@優先度IDがない場合
            With cmbPrioSel
                '@優先度ID列に設定
                .ValueCol = CMlngCmbPrioSelGridColPriorityID
                
                '@優先度IDがない場合
                If .Value = vbNullString Then
                    '@ﾛｯｸ
                    cmdRegist.Enabled = False
                    Exit Sub
                End If
            End With
            
            '@投入装置IDがない場合
            With cmbThrowinWP
                '@投入装置ID列に設定
                .ValueCol = CMlngCmbPrioSelGridColPriorityID
                '@投入装置IDがない場合
                If .Text = vbNullString And optOnlineflg0.Checked = True Then
                    '@ﾛｯｸ
                    cmdRegist.Enabled = False
                    Exit Sub
                End If
            End With
            
            '@ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸ
            lblnAns = prvvsfSlotMap_Chk
            If lblnAns = False Then
                '@ﾛｯｸ
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            '@ﾛｯｸ解除
            cmdRegist.Enabled = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPartName_Disp
    '機　能：利用部材ｺﾝﾎﾞﾎﾞｯｸｽの設定をする
    '引　数：llngPartLotListCnt:部材ﾘｽﾄのｶｳﾝﾄ
    '戻り値：なし
    '作成日：2004/08/05 (Thu) 17:40:23 Y.Yamagishi
    '更新日：2004/08/05 (Thu) 17:40:23
    '備　考：
    Private Sub prvCmbPartName_Disp(ByVal llngPartLotListCnt As Integer)

        Dim llngCnt                     As Integer      'ｶｳﾝﾀ変数

        Try
            
            '@ComboBoxExの設定
            With cmbPartName
                .Clear                                                              'ｸﾘｱ
                .DirectInput = False                                                '入力不可
                .DispCols = CMlngComboDispCols                                      '表示項目数(=2)
                .GetCol = CMlngComboColPart                                         '項目選択時返却
                .Font = new Font(.Font.FontFamily, CMlngComboFontSize)              'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = new Font(.GridFont.FontFamily, CMlngComboGridFontSize)  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngComboRowHeight                                    '行の高さ
                .ColAlignment(CMlngComboColPartCode) = TextAlignEnum.LeftCenter     '左中央
                .ColAlignment(CMlngComboColPartName) = TextAlignEnum.LeftCenter     '左中央

                '@配列の件数ﾁｪｯｸ
                If llngPartLotListCnt > 0 Then
                    For llngCnt = 0 To llngPartLotListCnt - 1
                        .AddItem(mtyppartlist(llngCnt).strPartCode & vbTab & _
                                 mtyppartlist(llngCnt).strPartName & vbTab & _
                                 mtyppartlist(llngCnt).strVenderName & vbTab & _
                                 mtyppartlist(llngCnt).strPartCode & CPstrSpace & _
                                 mtyppartlist(llngCnt).strPartName)
                    Next
                End If
                
                '@利用部材が0件の場合
                If .ListCount = 0 Then
                    '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                    '@"<TRM1CW>$$機種[%1]の利用部材は存在しません。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001C, lblPd.Text)
                    '@ｲﾝﾌｫﾒｰｼｮﾝ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                    Exit Sub
                End If
                
                '@利用部材が1件の場合
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
                .strProcName = "prvcmbPartName_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMapSel_Proc
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/29 (Wed) 10:27:04 H.Wajima
    '更新日：2004/12/29 (Wed) 10:27:04 H.Wajima
    '備　考：2004/12/29 (Wed) 10:27:04 H.Wajima ｻﾌﾞﾙｰﾁﾝ化、ｸﾞﾘｯﾄﾞの領域外でﾏｳｽを離しても
    '　　　：                                   選択が有効になるよう修正
    Private Sub prvvsfSlotMapSel_Proc()

        Dim llngCnt         As Integer  'ｶｳﾝﾄ
        Dim llngRowTop      As Integer  '選択最上段行
        Dim llngRowBottom   As Integer  '選択最下段行

        Try
            
            With vsfSlotMap
                If .Rows.Selected.Count <> 0 Then
                    '@選択最上段行を格納
                    llngRowTop = .Rows.Selected(CMvsfSlotMapRowTitle).index
                Else
                    llngRowTop = 0
                End If

                '@選択最下段行を格納
                llngRowBottom = llngRowTop + .Rows.Selected.Count - 1

                '@最上段行と最下段行が0の場合
                If llngRowTop = 0 And llngRowBottom = 0 Then
                    '@処理を抜ける
                    Exit Sub
                End If
                
                '@選択最下行が表示最下行より下かどうかを判定
                '@表示最下行の境目でRowIsVisibleが正しく判定されない為
                '@→ｸﾞﾘｯﾄﾞの高さを縮めるとRowIsVisibleが正しく判定できるが、一番下にｽｸﾛｰﾙしたときに
                '@　ｾﾙのない部分が表示されてしまうので注意
                If llngRowBottom > .TopRow + CMvsfSlotMapVisibleRows - 1 Then
                    '@選択最下行が表示最下行より下の場合
                    '@選択最下行に表示最下行を設定
                    llngRowBottom = .TopRow + CMvsfSlotMapVisibleRows - 1
                End If

                For llngCnt = llngRowBottom To llngRowTop Step -1
                    '@選択された行が表示されている行かどうかを判定
                    If llngCnt >= .TopRow AndAlso llngCnt <= .BottomRow Then
                    '@表示されている場合
                        '@背景色が灰色以外の場合
                        If .GetCellRange(llngCnt, CMvsfSlotMapColVender, _
                                                  llngCnt, CMvsfSlotMapColVenderLotID).StyleDisplay.BackColor <> ColorTranslator.FromWin32(CPlngGridDarkGray) Then
                            '@ｽﾛｯﾄﾏｯﾌﾟ設定/削除
                            If .GetData(llngCnt, CMvsfSlotMapColVenderLotID) = vbNullString Then
                                '@ﾍﾞﾝﾀｰﾛｯﾄIDと在庫数のﾁｪｯｸ
                                If lblInvLotID.Text <> vbNullString And IsNumeric(lblInvNum.Text) = True Then
                                    '@在庫数ﾁｪｯｸ
                                    If mcurInvNum > 0 And mlngWFNum > 0 Then
                                       .SetData(llngCnt, CMvsfSlotMapColVender, lblVenderName.Text)     'ﾍﾞﾝﾀﾞｰ
                                       .SetData(llngCnt, CMvsfSlotMapColVenderLotID, lblInvLotID.Text)  'ﾍﾞﾝﾀﾞｰﾛｯﾄID
                                        '@ﾁｪｯｸ用在庫数を1つ減らす
                                        mcurInvNum = mcurInvNum - 1
                                        
                                        '@ﾁｪｯｸ用WF枚数を1つ減らす
                                        mlngWFNum = mlngWFNum - 1
                                    End If
                                End If
                            Else
                                '@取消前ﾍﾞﾝﾀﾞｰとﾍﾞﾝﾀﾞｰﾛｯﾄIDが現在の「ベンダーロット選択」と同一の場合、減算する
                                If .GetData(llngCnt, CMvsfSlotMapColVender) = lblVenderName.Text And _
                                   .GetData(llngCnt, CMvsfSlotMapColVenderLotID) = lblInvLotID.Text Then
                                    '@ﾁｪｯｸ用在庫数を1つ増やす
                                    mcurInvNum = mcurInvNum + 1
                                End If
                                
                                '@ﾁｪｯｸ用WF枚数を1つ増やす
                                mlngWFNum = mlngWFNum + 1
                                
                                '@ﾍﾞﾝﾀﾞｰとﾍﾞﾝﾀﾞｰﾛｯﾄIDのｸﾘｱ
                                .SetData(llngCnt, CMvsfSlotMapColVender, vbNullString)              'ﾍﾞﾝﾀﾞｰ
                                .SetData(llngCnt, CMvsfSlotMapColVenderLotID, vbNullString)         'ﾍﾞﾝﾀﾞｰﾛｯﾄID
                            End If
                        End If
                    End If
                Next llngCnt
            End With
            
            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMapSel_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbThrowinWP_Init
    '機　能：投入装置ｺﾝﾎﾞﾎﾞｯｸｽ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:14:16 N.Kojima
    '更新日：2005/03/14 (Mon) 16:16:30 N.Kojima
    '備　考：
    Private Sub prvcmbThrowinWP_Init()

        Try

            '@ｺﾝﾎﾞﾎﾞｯｸｽ設定
            With cmbThrowinWP
                .Clear
                .DispCols = CMlngCmbPrioSelDispCols                                         'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbPrioSelGridColPriorityName                                'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbPrioSelGridColPriorityID                                '値取得列
                .DirectInput = False                                                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = new Font(.Font.FontFamily, CMlngCmbPrioSelFontSize)                 'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = new Font(.GridFont.FontFamily, CMlngCmbPrioSelGridFontSize)     'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngComboRowHeight                                            '行の高さ
                .ColAlignment(CMlngCmbPrioSelGridColPriorityName) = TextAlignEnum.LeftCenter    '左中央
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbThrowinWP_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbThrowinWP_Disp
    '機　能：投入装置をｺﾝﾎﾞへｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:15:36 N.Kojima
    '更新日：2005/03/14 (Mon) 16:15:36
    '備　考：
    Private Sub prvcmbThrowinWP_Disp()

        Dim llngCnt                 As Integer      'ｶｳﾝﾄ

        Try
                
            '@投入装置名ｾｯﾄ
            With cmbThrowinWP
                .Clear
                For llngCnt = 0 To mlngWpListCnt - 1
                    .AddItem(ptypWPList(llngCnt).strWpName & _
                             vbTab & _
                             ptypWPList(llngCnt).strWpID)
                Next llngCnt
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbThrowinWP_Disp"
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


    '関数名：flex_OwnerDrawCell
    '機　能：オーナー描画イベント。Focusの背景色のカスタマイズ
    '引　数：sender：イベント発生元
    '　　　：e     ：OwnerDrawCellイベントオブジェクト
    '戻り値：なし
    '作成日：2019/03/13 (Wed) 18:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flex_OwnerDrawCell(ByVal sender As Object, ByVal e As OwnerDrawCellEventArgs) Handles vsfSlotMap.OwnerDrawCell
        pubVsfOwnerDrawCell(CType(sender, C1FlexGrid), e)
    End Sub


    '関数名：vsfSlotMap_BeforeScroll
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ ｽｸﾛｰﾙ前処理
    '引　数：sender：イベント発生元
    '　　　：e     ：Rangeイベントオブジェクト
    '戻り値：なし
    '作成日：2019/06/11 (Tue) 9:00:00 NSYS
    '更新日：
    '備　考：

    Private Sub vsfSlotMap_BeforeScroll(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfSlotMap.BeforeScroll

        If mblnMouseDrag = True Then
            e.Cancel = True
        End If

    End Sub

End Class
