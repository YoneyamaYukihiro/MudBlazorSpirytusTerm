'ﾌｧｲﾙ名：xxCM00N0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：中間WF在庫選択
'作成日：2004/09/27 (Mon) 10:13:29 H.Wajima
'更新日：2004/09/27 (Mon) 10:13:29
'備　考：EN0120 ﾛｯﾄ編成(保留/払出WF)で使用
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00N0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00N0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00N0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00N0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00N0)
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
    Private Const CMstrmas_sblist__Ver                  As String = "01.00"         'ｼｽﾃﾑﾌﾞﾛｯｸ取得
    Private Const CMstrinv_lotlist_Ver                  As String = "02.00"         '在庫ﾛｯﾄﾘｽﾄ取得

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyCM00N0  'ﾛｰｶﾙ機能ID

    '@vsfLotListWFの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfWFColNo                       As Integer = 0              '№
    Private Const CMlngvsfWFColPutDay                   As Integer = 1              '受入日
    Private Const CMlngvsfWFColCarrierID                As Integer = 2              'ｷｬﾘｱID
    Private Const CMlngvsfWFColCarrierPosition          As Integer = 3              'ｷｬﾘｱ位置
    Private Const CMlngvsfWFColLotID                    As Integer = 4              '元ﾛｯﾄID
    Private Const CMlngvsfWFColLastUpdate               As Integer = 5              '最終更新日
    Private Const CMlngvsfWFColWfNum                    As Integer = 6              'WF
    Private Const CMlngvsfWFColCfNum                    As Integer = 7              'ﾁｯﾌﾟ

    '@vsfLotListWFの定数宣言(幅)
    Private Const CMlngvsfWFWColNo                      As Integer = 47             '№
    Private Const CMlngvsfWFWColPutDay                  As Integer = 134            '受入日
    Private Const CMlngvsfWFWColCarrierID               As Integer = 100            'ｷｬﾘｱID
    Private Const CMlngvsfWFWColCarrierPosition         As Integer = 294            'ｷｬﾘｱ位置
    Private Const CMlngvsfWFWColLotID                   As Integer = 167            '元ﾛｯﾄID
    Private Const CMlngvsfWFWColLastUpdate              As Integer = 74             '最終更新日
    Private Const CMlngvsfWFWColWfNum                   As Integer = 74             'WF
    Private Const CMlngvsfWFWColCfNum                   As Integer = 74             'ﾁｯﾌﾟ

    '@vvsfLotListWFの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfWFColNo                       As String = "№"            '№
    Private Const CMstrvsfWFColPutDay                   As String = "受入日"        '受入日
    Private Const CMstrvsfWFColCarrierID                As String = "キャリアID"    'ｷｬﾘｱID
    Private Const CMstrvsfWFColCarrierPosition          As String = "キャリア位置"  'ｷｬﾘｱ位置
    Private Const CMstrvsfWFColLotID                    As String = "元ロットID"    '元ﾛｯﾄID
    Private Const CMstrvsfWFColLastUpdate               As String = "最終更新日"    '最終更新日
    Private Const CMstrvsfWFColWfNum                    As String = "WF"            'WF
    Private Const CMstrvsfWFColCfNum                    As String = "チップ"        'ﾁｯﾌﾟ

    '@その他ｸﾞﾘｯﾄの定数
    Private Const CMvsfLotListWfCols                    As Integer = 8              '列数
    Private Const CMvsfLotListWfFixedRow                As Integer = 0              'ﾀｲﾄﾙ行
    Private Const CMvsfLotListWfFixedRows               As Integer = 1              'ﾀｲﾄﾙ行数
    Private Const CMlngvsfLotListWFRowHeight            As Integer = 38             '行高さ
    Private Const CMlngvsfLotListWFTitleRowHeight       As Integer = 24             'ﾀｲﾄﾙ行高さ
    Private Const CMlngvsfLotListWFFontSize             As Integer = 16             'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfLotListWFTitleFontSize        As Integer = 12             'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
    Private Const CMstrvsfLotListWFFontName             As String = "ＭＳ ゴシック" 'ﾌｫﾝﾄ名
    Private Const CMlngFrozenCol                        As Integer = 3              '固定列
    Private Const CMlngSideScrollOnFlag                 As Integer = 1              '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag                As Integer = 2              '横ｽｸﾛｰﾙ非活性化

    '@cmbSBID(利用SBｺﾝﾎﾞﾎﾞｯｸｽ)の定数
    Private Const CMlngCmbDispCol2                      As Integer = 2              'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbValueCol1                     As Integer = 1              '値取得列
    Private Const CMlngCmbGetCol0                       As Integer = 0              '表示列
    Private Const CMlngCmbGetCol1                       As Integer = 1              '表示列
    Private Const CMlngCmbFontSize                      As Integer = 16             'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 16             'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMstrCmbFontName                      As String = "ＭＳ ゴシック"  'ﾌｫﾝﾄ名
    Private Const CMstrCmbGridFontName                  As String = "ＭＳ ゴシック"  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄ名
    Private Const CMlngCmbRowHeight                     As Integer = 43             '行の高さ
    Private Const CMlngCmbGroupCols                     As Integer = 1              'ｸﾞﾙｰﾌﾟ列数

    '@その他定数宣言
    Private Const CMlngTxtLotIDMinLen                   As Integer = 2              '元ﾛｯﾄIDMinLen
    Private Const CMlngTxtLotIDMaxLen                   As Integer = 10             '元ﾛｯﾄIDMaxLen
    Private Const CMstrSlash                            As String = "/"             '/
    Private Const CMstrZero                             As String = "0"             '0
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypInvLotList                              As InvLotListAns            '在庫ﾛｯﾄﾘｽﾄ構造体
    Private mstrSBID                                    As String                   '前回SBID
    Private mtypChgSort                                 As ChgSort                  'ｿｰﾄ保持用
    Private mlngSideScrollFlag                          As Integer                  '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
    Private mstrLotId                                   As String                   'ﾛｯﾄID退避領域
    Private buttonProcessing                            As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                  'NSYS WindowCloseフラグ
    Private mctlValidating                              As Control                  'NSYS Validating中のコントロール(なし:Nothing)


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
        pubVsfMouseWheelManager_Set(vsfLotListWF, cmdUP, cmdDown, cmdLeft, cmdRight)

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
    '作成日：2004/09/27 (Mon) 10:26:09 H.Wajima
    '更新日：2004/10/15 (Fri) 15:20:37 N.Kasai  ｿｰﾄ順保持機能追加
    '備　考：
    '　　　：2005/02/07 (Mon) 08:47:48 S.Deguchi    情報取得失敗時処理追加
    Private Sub Form_Load()

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset
            
            '@画面初期化
            Call prvfrmxxCM00N0_Init()
            
            '@利用SBｺﾝﾎﾞﾎﾞｯｸｽの初期化
            Call prvcmbSBID_Init()
            
            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfLotListWF_Init()
            
            '@構造体初期化（ｿｰﾄ順格納）
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@一覧表示
            Call cmdNowList_Click(cmdNowList, EventArgs.Empty)
            
            '@中間WF在庫情報の取得状況による判別
            If vsfLotListWF.Rows.Count < 2 Then
                '@Form_Loadﾌﾗｸﾞ（異常）
                pblnFormLoad = False
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
            Else
                '@Form_Loadﾌﾗｸﾞ（正常）
                pblnFormLoad = True
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
            End If
            
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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 15:35:06 H.Wajima
    '更新日：2004/09/27 (Mon) 15:35:06
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated, MyBase.Shown

        Try

            With vsfLotListWF
                RemoveHandler cmbSBID.Validating, AddressOf cmbSBID_Validate
                RemoveHandler txtLotID.Validating, AddressOf txtLotID_Validate
                If vsfLotListWF.Enabled = True Then
                    '@一覧にﾌｫｰｶｽをｾｯﾄ
                    Call pubSetFocus(vsfLotListWF)
                Else
                    '@利用SBにﾌｫｰｶｽをｾｯﾄ
                    Call pubSetFocus(cmbSBID)
                End If
                AddHandler cmbSBID.Validating, AddressOf cmbSBID_Validate
                AddHandler txtLotID.Validating, AddressOf txtLotID_Validate
            End With

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
    '作成日：2004/09/27 (Mon) 17:03:15 H.Wajima
    '更新日：2007/07/05 (Thu) 11:03:13 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 11:03:13 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
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

            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfLotListWF, cmdUP, cmdDown)
            
        '@↓2007/07/05 (Thu) 11:00:20 N.Kasai **************************************************
        '    '@ｸﾞﾘｯﾄﾞｷｰ制御（ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ）
        '    Call prvSideKeyDown_Proc(KeyCode, ActiveControl.Name, vsfLotListWF, cmdLeft, cmdRight)
            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ）
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfLotListWF, cmdLeft, cmdRight)
        '@↑2007/07/05 (Thu) 11:00:20 N.Kasai **************************************************

            '@選択確定ﾎﾞﾀﾝが非表示の場合
            If cmdRegist.Visible = False Then
                '@Enterｷｰの場合
                Select Case e.KeyCode
                    Case Keys.Return
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                End Select
            Else
                '@Enterｷｰの場合
                Select Case e.KeyCode
                    Case Keys.Return
                        Select Case ActiveControl.Name
                            Case vsfLotListWF.Name
                            '@一覧にﾌｫｰｶｽがある場合
                                '@ﾃﾞｰﾀ行の場合
                                If vsfLotListWF.Row >= vsfLotListWF.Rows.Fixed Then
                                    '@選択確定処理
                                    Call cmdRegist_Click(cmdRegist, EventArgs.Empty)
                                End If
                            
                            Case cmbSBID.Name
                            '@ｼｽﾃﾑﾌﾞﾛｯｸ選択ﾁｪｯｸ
                                Call cmbSBID_Validate(cmbSBID, New CancelEventArgs(False))
                            
                            Case txtLotID.Name
                            '@ﾛｯﾄID
                                Call txtLotID_Validate(txtLotID, New CancelEventArgs(True))
                                
                            Case Else
                            '@その他
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                        End Select
                End Select
            End If
            
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
    '機　能：ﾌｫｰﾑ ｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/09/29 (Wed) 15:52:24 H.Wajima
    '更新日：2004/11/02 (Tue) 16:49:34 M.Miura
    '備　考：2004/11/01 (Mon) 15:31:16 N.Kasai  変数初期化追加（pstrCarrierID）
    '　　　：2004/11/02 (Tue) 16:49:34 M.Miura  変数初期化削除（pstrCarrierID）（ｷｬﾘｱが選択されない為）
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@SBIDの初期化
            mstrSBID = vbNullString
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            mtypChgSort.typChgSortList = Nothing
            
            '@情報取得構造体のｸﾘｱ
            mtypInvLotList.typLotListAns = Nothing
            
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
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 17:02:32 H.Wajima
    '更新日：2004/09/27 (Mon) 17:02:32
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

    '関数名：cmbSBID_Change
    '機　能：利用SB 変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/30 (Thu) 20:27:50 H.Wajima
    '更新日：2004/10/15 (Fri) 15:22:11 N.Kasai  ｿｰﾄ保持機能追加
    '備　考：
    Private Sub cmbSBID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSBID.Change

        Try
            
            '@中間WF在庫一覧のｸﾘｱ
            Call prvvsfLotListWF_Init()
            
            '@退避領域を初期化
            mstrLotId = vbNullString
            
            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txtLotID.Text = vbNullString
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@情報取得日時の初期化
            lblNowDate.Text = vbNullString
            
            '@該当件数の初期化
            lblLotCnt.Text = CMstrZero
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSBID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSBID_CloseUp
    '機　能：利用SB CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/29 (Wed) 18:58:33 H.Wajima
    '更新日：2004/09/29 (Wed) 18:58:33
    '備　考：
    Private Sub cmbSBID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSBID.CloseUp

        Try
            
            '@Validate処理へ
            Call cmbSBID_Validate(cmbSBID, New CancelEventArgs(False))
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSBID_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSBID_Validate
    '機　能：ｼｽﾃﾑﾌﾞﾛｯｸValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/29 (Wed) 11:21:48 H.Wajima
    '更新日：2004/09/29 (Wed) 11:21:48
    '備　考：
    Private Sub cmbSBID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbSBID.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            With vsfLotListWF
                '@前回SBIDの比較
                If mstrSBID = cmbSBID.Value Then
                '@前回SBIDと同じSBIDの場合は処理を抜ける
                    Call prvSetFocus(txtLotID, cmbSBID)
                    
                    Exit Sub
                End If
                
                '@最新取得ﾎﾞﾀﾝｸﾘｯｸ処理を実行する
                mctlValidating = cmbSBID
                Call cmdNowList_Click(cmdNowList, EventArgs.Empty)
                mctlValidating = Nothing
            
                '@中間在庫一覧が表示されているか確認
                If .Enabled = True Then
                    '@ﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(vsfLotListWF, cmbSBID)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSBID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Change
    '機　能：元ﾛｯﾄID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/04 (Fri) 10:46:53 S.Deguchi
    '更新日：2005/02/04 (Fri) 10:46:53
    '備　考：
    Private Sub txtLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotID.Change

        Try

            '@中間在庫一覧のｸﾘｱ
            Call prvvsfLotListWF_Init()
            
            '@退避領域を初期化
            mstrLotId = vbNullString
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@情報取得日時の初期化
            lblNowDate.Text = vbNullString
            
            '@該当件数の初期化
            lblLotCnt.Text = CMstrZero
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Validate
    '機　能：元ﾛｯﾄIDValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/02/04 (Fri) 10:46:56 S.Deguchi
    '更新日：2005/02/04 (Fri) 10:46:56
    '備　考：
    Private Sub txtLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLotID.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@元ﾛｯﾄID欄の入力状況による処理分岐
            If txtLotID.Text = vbNullString Then
            '@空欄時の場合(ﾌｫｰｶｽｾｯﾄ)
                If vsfLotListWF.Enabled = True Then
                '@一覧が表示されている場合
                    Call prvSetFocus(vsfLotListWF, txtLotID)
                Else
                    If cmdNowList.Enabled = True Then
                    '@最新取得が使用できる場合
                        Call prvSetFocus(cmdNowList, txtLotID)
                    Else
                        Call prvSetFocus(cmdClose, txtLotID)
                    End If
                End If
            Else
                '@入力文字数による処理(2文字以下の入力)
                If Len(txtLotID.Text) < CMlngTxtLotIDMinLen Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001H)
                    '@「ロットIDは2桁以上入力してください。」
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                    
                    '@処理ｽｷｯﾌﾟ
                    Exit Sub
                End If
            End If
            
            '@退避領域と同じ場合には処理抜け
            If mstrLotId = txtLotID.Text Then
                If vsfLotListWF.Enabled = True Then
                '@一覧が表示されている場合
                    Call prvSetFocus(vsfLotListWF, txtLotID)
                Else
                    If cmdNowList.Enabled = True Then
                    '@最新取得が使用できる場合
                        Call prvSetFocus(cmdNowList, txtLotID)
                    Else
                        Call prvSetFocus(cmdClose, txtLotID)
                    End If
                End If
                '@処理ｽｷｯﾌﾟ
                Exit Sub
            Else
                '@最新情報取得処理へ
                mctlValidating = txtLotID
                Call cmdNowList_Click(cmdNowList, EventArgs.Empty)
                mctlValidating = Nothing
                
                If vsfLotListWF.Enabled = True Then
                '@中間在庫が表示された場合
                    Call prvSetFocus(vsfLotListWF, txtLotID)
                Else
                '@中間在庫が表示されない場合
                    If cmdNowList.Enabled = True Then
                        Call prvSetFocus(cmdNowList, txtLotID)
                    Else
                        Call prvSetFocus(cmdClose, txtLotID)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowList_Click
    '機　能：最新取得ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 17:02:32 H.Wajima
    '更新日：2005/11/25 (Fri) 11:48:46 N.Kasai
    '備　考：2004/10/13 (Wed) 20:14:25 H.Wajima     inv_.waferlist→inv_.lotlist_変更対応
    '　　　：2004/10/19 (Tue) 09:07:17 Y.Yamagishi　ﾒｯｾｰｼﾞﾎﾞｯｸｽの0件表示をしない(不具合改善対応№87)
    '　　　：2005/02/04 (Fri) 13:22:45 S.Deguchi    不具合№471対応(ﾒｯｾｰｼﾞ修正対応)
    '　　　：2005/11/25 (Fri) 11:48:46 N.Kasai      処理区分追加
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click
        
        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim ltypInvLotListReq       As InvLotListReq        '要求構造体

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
            
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "cmdNowList_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@中間在庫一覧のｸﾘｱ
            Call prvvsfLotListWF_Init(False, False)
            
            '@要求構造体に格納
            With ltypInvLotListReq
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                .strSbID = cmbSBID.Value
                
        '@↓2005/11/25 (Fri) 11:50:11 N.Kasai **************************************************
                '@処理区分（ﾛｯﾄ編成を指定した場合はFOSBは対象外
                If txtLotID.Text = vbNullString Then
                    .strClassDivision = CPstrCD02 & CPstrCD1W   '全件&ﾛｯﾄ編成
                Else
                    .strClassDivision = CPstrCD0L & CPstrCD1W   'ﾛｯﾄ指定&ﾛｯﾄ編成
                End If
        '@↑2005/11/25 (Fri) 11:50:11 N.Kasai **************************************************
                
                '@ｷｬﾘｱID(空欄)
                .strCarrierId = vbNullString
                
                '@ﾛｯﾄID
                .strLotID = txtLotID.Text
                
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstrinv_lotlist_Ver
            End With
            
            '@在庫ﾛｯﾄﾘｽﾄ取得
            lblnAns = pubblnInvLotList_Sel(ltypInvLotListReq, mtypInvLotList)
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
                
                '@一覧表示
                Call prvvsfLotListWF_Disp()
                
                '@最新取得ﾎﾞﾀﾝ活性化
                cmdNowList.Enabled = True
                
                '@SBIDの退避
                mstrSBID = cmbSBID.Value
                
                '@ﾛｯﾄIDの退避
                mstrLotId = txtLotID.Text
                
                '@ﾌｫｰｶｽ処理
                With vsfLotListWF
                    If .Enabled = True Then
                        '@Form_Load中ではない場合
                        If pblnFormLoad = True Then
                            '@ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                            If mctlValidating Is Nothing Then
                                Call pubSetFocus(vsfLotListWF)
                            Else
                                Call prvSetFocus(vsfLotListWF, mctlValidating)
                            End If
                        End If
                    End If
                End With
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
            '@失敗の場合
                vsfLotListWF.Redraw = True
                vsfLotListWF.Enabled = False
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
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

    '関数名：cmdRegist_Click
    '機　能：選択確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 17:03:01 H.Wajima
    '更新日：2004/09/27 (Mon) 17:03:01
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@行が選択されていない場合は格納しない
            If vsfLotListWF.Row >= 1 Then
                '@ｷｬﾘｱIDを格納
                pstrCarrierID = vsfLotListWF.GetData(vsfLotListWF.Row, CMlngvsfWFColCarrierID)
                
                '@ﾌｫｰﾑを閉じる
                Me.Close()
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

    '関数名：cmdUp_Click
    '機　能：前ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 15:44:18 H.Wajima
    '更新日：2004/09/27 (Mon) 15:44:18
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

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdUp(vsfLotListWF, cmdUP, cmdDown)
            
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
    '作成日：2004/09/27 (Mon) 15:44:30 H.Wajima
    '更新日：2004/09/27 (Mon) 15:44:30
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
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdDown(vsfLotListWF, cmdUP, cmdDown)
            
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

    '関数名：cmdLeft_Click
    '機　能：左一項目移動
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/04 (Fri) 17:34:04 S.Deguchi
    '更新日：2007/07/05 (Thu) 11:04:04 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 11:04:04 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub cmdLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@左ｽｸﾛｰﾙﾎﾞﾀﾝ制御
            Call pubVsfCmdLeft(vsfLotListWF, cmdLeft, cmdRight)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLeft_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRight_Click
    '機　能：右一項目移動
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/04 (Fri) 17:33:42 S.Deguchi
    '更新日：2007/07/05 (Thu) 11:04:40 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 11:04:40 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub cmdRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@右ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            Call pubVsfCmdRight(vsfLotListWF, cmdLeft, cmdRight)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRight_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListWF_AfterSort
    '機　能：ソート後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 15:44:03 H.Wajima
    '更新日：2004/10/15 (Fri) 15:24:06 N.Kasai  ｿｰﾄ順保持機能追加
    '備　考：
    Private Sub vsfLotListWF_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListWF.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListWF.Rows.Count <= vsfLotListWF.Rows.Fixed Then
                Return
            End If

            AddHandler vsfLotListWF.BeforeRowColChange, AddressOf vsfLotListWF_BeforeRowColChange
            
            '@ｿｰﾄ順を格納
            With mtypChgSort
                Dim ltypChgSortListTmp As ChgSortList
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                
                '@ｿｰﾄ列番号を格納
                ltypChgSortListTmp.lngCol = e.Col
                
                '@並び替え方法を格納（昇順/降順）
                ltypChgSortListTmp.lngOrder = e.Order

                .typChgSortList.Add(ltypChgSortListTmp)
            End With
            
            '@ｶﾚﾝﾄ行の設定（ｸﾞﾘｯﾄﾞ,保持列[№,受入日,ｷｬﾘｱID,ｷｬﾘｱ位置,WF,ﾁｯﾌﾟ],前頁,次頁）
            Call pubVsfAfterSort(vsfLotListWF, _
                                 CMlngvsfWFColNo & vbTab & _
                                 CMlngvsfWFColPutDay & vbTab & _
                                 CMlngvsfWFColCarrierID & vbTab & _
                                 CMlngvsfWFColCarrierPosition & vbTab & _
                                 CMlngvsfWFColWfNum & vbTab & _
                                 CMlngvsfWFColCfNum, _
                                 cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListWF_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListWF_AfterUserResize
    '機　能：ｸﾞﾘｯﾄﾞﾕｰｻﾞﾘｻｲｽﾞ
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2007/07/05 (Thu) 11:28:53 N.Kasai
    '更新日：2007/07/05 (Thu) 11:28:53
    '備　考：
    Private Sub vsfLotListWF_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotListWF.AfterResizeColumn, vsfLotListWF.AfterResizeRow

        Try

            '@列幅変更ﾌﾗｸﾞ（変更）
            mtypChgSort.blnChgWidth = True
            
        '@↓2007/07/09 (Mon) 13:14:16 N.Kasai **************************************************
        '    With vsfLotListWF
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
        '            '@右ｽｸﾛｰﾙ非活性化
        '            cmdRight.Enabled = False
        '        Else
        '            '@右ｽｸﾛｰﾙ活性化
        '            cmdRight.Enabled = True
        '        End If
        '    End With
            
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御（ｸﾞﾘｯﾄﾞ共通化関数）
            Call pubCmdLREnable_Set(vsfLotListWF, cmdLeft, cmdRight)
        '@↑2007/07/09 (Mon) 13:14:16 N.Kasai **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListWF_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListWF_BeforeSort
    '機　能：ソート前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 15:43:47 H.Wajima
    '更新日：2004/09/27 (Mon) 15:43:47
    '備　考：
    Private Sub vsfLotListWF_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListWF.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListWF.Rows.Count <= vsfLotListWF.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の設定（ｸﾞﾘｯﾄﾞ,保持列[№,受入日,ｷｬﾘｱID,ｷｬﾘｱ位置,WF,ﾁｯﾌﾟ],前頁,次頁）
            Call pubVsfBeforeSort(vsfLotListWF, _
                                  CMlngvsfWFColNo & vbTab & _
                                  CMlngvsfWFColPutDay & vbTab & _
                                  CMlngvsfWFColCarrierID & vbTab & _
                                  CMlngvsfWFColCarrierPosition & vbTab & _
                                  CMlngvsfWFColWfNum & vbTab & _
                                  CMlngvsfWFColCfNum)
            

            'NSYS ソート時にBeforeRowColChangeイベントが発生し、検索キー mtypChgSort.strKey
            'NSYS が設定されるのを避けるため
            RemoveHandler vsfLotListWF.BeforeRowColChange, AddressOf vsfLotListWF_BeforeRowColChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListWF_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListWF_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 15:25:28 N.Kasai
    '更新日：2004/10/15 (Fri) 15:25:28
    '備　考：
    Private Sub vsfLotListWF_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotListWF.BeforeRowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListWF.Rows.Count <= vsfLotListWF.Rows.Fixed Then
                Return
            End If

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（ｷｬﾘｱID）
                mtypChgSort.strKey = vsfLotListWF.GetData(e.NewRange.r1, CMlngvsfWFColCarrierID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListWF_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListWF_DblClick
    '機　能：機種ｴﾝﾄﾘ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 15:47:04 H.Wajima
    '更新日：2004/09/27 (Mon) 15:47:04
    '備　考：
    Private Sub vsfLotListWF_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotListWF.DoubleClick

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@確定ﾎﾞﾀﾝが表示されている場合
            If cmdRegist.Visible = True Then
                '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
                If vsfLotListWF.MouseRow <= 0 Then
                    Exit Sub
                End If
                
                '@選択確定処理へ
                Call cmdRegist_Click(cmdRegist, EventArgs.Empty)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListWF_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotListWF_RowColChange
    '機　能：ｽﾛｯﾄ変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 15:46:45 H.Wajima
    '更新日：2004/09/27 (Mon) 15:46:45
    '備　考：
    Private Sub vsfLotListWF_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotListWF.RowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListWF.Rows.Count <= vsfLotListWF.Rows.Fixed Then
                Return
            End If
            
            '@ｶﾚﾝﾄ行がﾍｯﾀﾞｰ以外か
            Select Case vsfLotListWF.Row
                Case <= 0
                '@明細が選択されていない場合
                    '@何もしない
                Case Else
                '@明細が選択されている場合
                    '@選択確定ﾎﾞﾀﾝのﾛｯｸ解除
                    cmdRegist.Enabled = True
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotListWF_RowColChange"
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
    '関数名：prvfrmxxCM00N0_Init
    '機　能：画面初期設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 10:27:30 H.Wajima
    '更新日：2004/09/27 (Mon) 10:27:30
    '備　考：
    Private Sub prvfrmxxCM00N0_Init()

        Try

            '@情報取得日時初期化
            lblNowDate.Text = vbNullString
                
            '@該当件数ｸﾘｱ
            lblLotCnt.Text = vbNullString
            
            '@ﾛｯﾄIDの初期化
            txtLotID.Text = vbNullString
            
            '@ﾓｼﾞｭｰﾙ変数の初期化
            mlngSideScrollFlag = 0

            '@非表示
            cmdUP.Enabled = False       '前ﾍﾟｰｼﾞ
            cmdDown.Enabled = False     '次ﾍﾟｰｼﾞ
            cmdRegist.Enabled = False   '選択確定
            cmdLeft.Enabled = False     '左
            cmdRight.Enabled = False    '右
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00N0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListWF_Init
    '機　能：vsfLotListWFの初期化
    '引　数：lblnDoEnableFalse     ：Enable=False処理の実行有無（省略可）True：実行する、False：実行しない(NSYS追加)
    '      ：lblnDoRedrawTrue      ：Redraw=True処理の実行有無（省略可）True：実行する、False：実行しない(NSYS追加)
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 10:28:30 H.Wajima
    '更新日：
    '備　考：
    '　　　：2005/02/07 (Mon) 08:43:25 S.Deguchi    元ﾛｯﾄID追加による修正
    Private Sub prvvsfLotListWF_Init(Optional ByVal lblnDoEnableFalse As Boolean = True, _
                                     Optional ByVal lblnDoRedrawTrue As Boolean = True)
        
        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfLotListWF

                '@描画ﾛｯｸ
                .Redraw = False
                
                .Rows.DefaultSize = CMlngvsfLotListWFRowHeight                          '行の高さ
                .Rows.Fixed = CMvsfLotListWfFixedRows                                   'ﾀｲﾄﾙ行
                .Cols.Fixed = 0                                                         'ﾀｲﾄﾙ列
                .Cols.Count = CMvsfLotListWfCols                                        '列数
                .Rows.Count = .Rows.Fixed                                               '行数
                With .Font                                                              'ﾌｫﾝﾄｻｲｽﾞ
                                                                                        'ﾌｫﾝﾄ名
                    vsfLotListWF.Font = New Font(CMstrvsfLotListWFFontName, CMlngvsfLotListWFFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .ScrollBars = ScrollBars.None                                           'ｽｸﾛｰﾙﾊﾞｰ
                .FocusRect = FocusRectEnum.Light                                        'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠（有り）
                .SelectionMode = SelectionModeEnum.Row                                  '選択ｽﾀｲﾙ設定：行単位
                .AllowSorting = AllowSortingEnum.SingleColumn                           'ﾀｲﾄﾙﾊﾞｰｿｰﾄ
                .Cols.Frozen = CMlngFrozenCol                                           '固定列
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter              '最終行･･･
                
                '@列幅変更可
                .AllowResizing = AllowResizingEnum.Columns
                
                '@表示位置設定
                .Cols(CMlngvsfWFColNo).TextAlign = TextAlignEnum.RightCenter                  '№
                .Cols(CMlngvsfWFColPutDay).TextAlign = TextAlignEnum.LeftCenter               '受入日
                .Cols(CMlngvsfWFColCarrierID).TextAlign = TextAlignEnum.LeftCenter            'ｷｬﾘｱID
                .Cols(CMlngvsfWFColCarrierPosition).TextAlign = TextAlignEnum.LeftCenter      'ｷｬﾘｱ位置
                .Cols(CMlngvsfWFColLotID).TextAlign = TextAlignEnum.LeftCenter                'ﾛｯﾄID
                .Cols(CMlngvsfWFColLastUpdate).TextAlign = TextAlignEnum.LeftCenter           '最終更新日
                .Cols(CMlngvsfWFColWfNum).TextAlign = TextAlignEnum.RightCenter               'WF
                .Cols(CMlngvsfWFColCfNum).TextAlign = TextAlignEnum.RightCenter               'ﾁｯﾌﾟ
                
                '@列幅変更ﾌﾗｸﾞ（変更なし）
                If mtypChgSort.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfWFColNo).Width = CMlngvsfWFWColNo                           '№
                    .Cols(CMlngvsfWFColPutDay).Width = CMlngvsfWFWColPutDay                   '受入日
                    .Cols(CMlngvsfWFColCarrierID).Width = CMlngvsfWFWColCarrierID             'ｷｬﾘｱID
                    .Cols(CMlngvsfWFColCarrierPosition).Width = CMlngvsfWFWColCarrierPosition 'ｷｬﾘｱ位置
                    .Cols(CMlngvsfWFColLotID).Width = CMlngvsfWFWColLotID                     'ﾛｯﾄID
                    .Cols(CMlngvsfWFColLastUpdate).Width = CMlngvsfWFWColLastUpdate           '最終更新日
                    .Cols(CMlngvsfWFColWfNum).Width = CMlngvsfWFWColWfNum                     'WF
                    .Cols(CMlngvsfWFColCfNum).Width = CMlngvsfWFWColCfNum                     'ﾁｯﾌﾟ
                End If
                
                '@ﾀｲﾄﾙ行設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)       '背景色
                lFixedStyle.ForeColor = Color.Yellow                                    '文字色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                      '配置
                With .Font                                                              'ﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngvsfLotListWFTitleFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .Rows(CMvsfLotListWfFixedRow).Height = CMlngvsfLotListWFTitleRowHeight  'ﾀｲﾄﾙ行高さ
                lFixedStyle.Trimming = StringTrimming.None
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMvsfLotListWfFixedRow, CMlngvsfWFColNo, CMstrvsfWFColNo)                            '№
                .SetData(CMvsfLotListWfFixedRow, CMlngvsfWFColPutDay, CMstrvsfWFColPutDay)                    '受入日
                .SetData(CMvsfLotListWfFixedRow, CMlngvsfWFColCarrierID, CMstrvsfWFColCarrierID)              'ｷｬﾘｱID
                .SetData(CMvsfLotListWfFixedRow, CMlngvsfWFColCarrierPosition, CMstrvsfWFColCarrierPosition)  'ｷｬﾘｱ位置
                .SetData(CMvsfLotListWfFixedRow, CMlngvsfWFColLotID, CMstrvsfWFColLotID)                      'ﾛｯﾄID
                .SetData(CMvsfLotListWfFixedRow, CMlngvsfWFColLastUpdate, CMstrvsfWFColLastUpdate)            '最終更新日
                .SetData(CMvsfLotListWfFixedRow, CMlngvsfWFColWfNum, CMstrvsfWFColWfNum)                      'WF
                .SetData(CMvsfLotListWfFixedRow, CMlngvsfWFColCfNum, CMstrvsfWFColCfNum)                      'ﾁｯﾌﾟ
                
                '@非表示設定
                .Cols(CMlngvsfWFColLastUpdate).Visible = False                                                '最終更新日

                '@列データタイプ設定
                .Cols(CMlngvsfWFColNo).DataType = GetType(Int32)
                .Cols(CMlngvsfWFColWfNum).DataType = GetType(Int32)
                .Cols(CMlngvsfWFColCfNum).DataType = GetType(Int32)

                '@列フォーマット設定
                .Cols(CMlngvsfWFColCfNum).Format = CPstrCFKnmaFormat

                If lblnDoRedrawTrue Then
                    '@描画ﾛｯｸ解除
                    .Redraw = True
                End If

                If lblnDoEnableFalse = True
                    '@ﾛｯｸ
                    .Enabled = False
                End If

                '@無効
                cmdUP.Enabled = False                   'ｽｸﾛｰﾙ上
                cmdDown.Enabled = False                 'ｽｸﾛｰﾙ下
                cmdRegist.Enabled = False               '確定
                cmdLeft.Enabled = False                 'ｽｸﾛｰﾙ左
                cmdRight.Enabled = False                'ｽｸﾛｰﾙ右
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListWF_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotListWF_Disp
    '機　能：中間WF在庫一覧作成
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 14:08:46 H.Wajima
    '更新日：2007/07/09 (Mon) 13:15:44 N.Kasai
    '備　考：2004/10/13 (Wed) 20:15:46 H.Wajima     inv_.waferlist→inv_.lotlist_変更対応
    '　　　：2004/10/15 (Fri) 15:40:27 N.Kasai      ｿｰﾄ順保持機能追加
    '　　　：2005/02/04 (Fri) 13:53:13 S.Deguchi    不具合№471対応で修正
    '　　　：2007/07/09 (Mon) 13:15:44 N.Kasai      ｸﾞﾘｯﾄﾞ共通
    Private Sub prvvsfLotListWF_Disp()

        Dim llngDoCnt       As Integer  'ｶｳﾝﾄ
        Dim llngCnt         As Integer  '汎用ｶｳﾝﾀ
        Dim lstrLotID       As String   'ﾛｯﾄID格納

        Try
            
            With vsfLotListWF
                If mtypInvLotList.lngLotListAnsCnt <> 0 Then
                '@格納ﾃﾞｰﾀがあるの場合
                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    'NSYS BeforeRowColChangeイベントを抑止し、ボタンの状態変更やｿｰﾄ検索用ｷｰ設定を抑える
                    RemoveHandler vsfLotListWF.BeforeRowColChange, AddressOf vsfLotListWF_BeforeRowColChange
                    RemoveHandler vsfLotListWF.RowColChange, AddressOf vsfLotListWF_RowColChange

                    '@一覧の取得行数の初期化
                    .Row = -1
                    .Rows.Count = .Rows.Fixed
                    .Rows.Count = mtypInvLotList.lngLotListAnsCnt + 1
                    
                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1
                    
                    Do While .Rows.Count > llngDoCnt
                    '@ﾛｯﾄ一覧表示情報設定
                        '@№設定
                        .SetData(llngDoCnt, CMlngvsfWFColNo, llngDoCnt)
                        
                        '@受入日
                        If IsDate(mtypInvLotList.typLotListAns(llngDoCnt - 1).strEntryTime) Then
                            .SetData(llngDoCnt, CMlngvsfWFColPutDay, _
                                Format$(CDate(mtypInvLotList.typLotListAns(llngDoCnt - 1).strEntryTime), CPstrDateTimeYMD))
                        Else
                            .SetData(llngDoCnt, CMlngvsfWFColPutDay, _
                                mtypInvLotList.typLotListAns(llngDoCnt - 1).strEntryTime)
                        End If
                        
                        '@ｷｬﾘｱID
                        .SetData(llngDoCnt, CMlngvsfWFColCarrierID, _
                            mtypInvLotList.typLotListAns(llngDoCnt - 1).strCarrierId)
                        
                        '@ｷｬﾘｱ位置
                        .SetData(llngDoCnt, CMlngvsfWFColCarrierPosition, _
                            mtypInvLotList.typLotListAns(llngDoCnt - 1).strCurrentPositionName)
                        
                        '@元ﾛｯﾄID(/区切り表記処理)
                        lstrLotID = vbNullString
                        For llngCnt = 0 To mtypInvLotList.typLotListAns(llngDoCnt - 1).lngBFLotListCnt - 1
                            '@1行目
                            If llngCnt = 0 Then
                                lstrLotID = mtypInvLotList.typLotListAns(llngDoCnt - 1).typBFLotList(llngCnt).strLotID
                            Else
                            '@それ以外
                                lstrLotID = lstrLotID & _
                                            CMstrSlash & _
                                            mtypInvLotList.typLotListAns(llngDoCnt - 1).typBFLotList(llngCnt).strLotID
                            End If
                        Next
                        .SetData(llngDoCnt, CMlngvsfWFColLotID, lstrLotID)
                        
                        '@WF
                        .SetData(llngDoCnt, CMlngvsfWFColWfNum, _
                            mtypInvLotList.typLotListAns(llngDoCnt - 1).strWFQuantity)
                        
                        '@ﾁｯﾌﾟ
                        .SetData(llngDoCnt, CMlngvsfWFColCfNum, _
                            mtypInvLotList.typLotListAns(llngDoCnt - 1).strChipQuantity)
                        
                        '@最終更新日時
                        .SetData(llngDoCnt, CMlngvsfWFColLastUpdate, _
                            mtypInvLotList.typLotListAns(llngDoCnt - 1).strEditTime)
                        
                        '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                    Loop
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '@列幅設定
                        .AutoSizeCol(CMlngvsfWFColPutDay, 6)             '受入日
                        .AutoSizeCol(CMlngvsfWFColCarrierID, 6)          'ｷｬﾘｱID
                        .AutoSizeCol(CMlngvsfWFColCarrierPosition, 6)    'ｷｬﾘｱ位置
                        .AutoSizeCol(CMlngvsfWFColLotID, 6)              'ﾛｯﾄID
                        .AutoSizeCol(CMlngvsfWFColWfNum, 6)              'WF
                        .AutoSizeCol(CMlngvsfWFColCfNum, 6)              'ﾁｯﾌﾟ
                        .AutoSizeCol(CMlngvsfWFColLastUpdate, 6)         '最終更新日時
                    End If
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                            '@該当行をｿｰﾄ
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    '@ｿｰﾄ検索用ｷｰ（ｷｬﾘｱID）がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ｷｬﾘｱIDが同じ場合
                            If .GetData(llngCnt, CMlngvsfWFColCarrierID) = mtypChgSort.strKey Then
                                '@行指定
                                .Row = llngCnt
                                
                                '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                                Call pubVsfBeforeSort(vsfLotListWF, CMlngvsfWFColNo)
                                
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                                Call pubVsfAfterSort(vsfLotListWF, CMlngvsfWFColNo, cmdUP, cmdDown)
                                
                                Exit For
                            End If
                        Next llngCnt
                    End If

                    If .Row < 0 Then
                        .Row = CMvsfLotListWfFixedRow
                    End If
                    .Col = CMlngvsfWFColNo
                                
                    '@描画ﾛｯｸ解除
                    .Redraw = True
                    
        '@↓2007/07/10 (Tue) 14:45:16 N.Kasai **************************************************
        '            '@全列数の幅取得(非表示項目は含めない)
        '            For llngLoopCnt = 0 To .Cols - 1
        '                If .ColHidden(llngLoopCnt) <> True Then
        '                    llngWidthAll = llngWidthAll + .ColWidth(llngLoopCnt)
        '                End If
        '            Next llngLoopCnt
        '
        '            '@ｸﾞﾘｯﾄﾞ幅と比較して横ｽｸﾛｰﾙﾎﾞﾀﾝを活性化するか判断
        '            If .Width - llngWidthAll >= 0 Then
        '                '@ｽｸﾛｰﾙﾌﾗｸﾞ(=2:非活性化)
        '                mlngSideScrollFlag = CMlngSideScrollOffFlag
        '
        '                '@右ｽｸﾛｰﾙ非活性化
        '                cmdRight.Enabled = False
        '            Else
        '                '@ｽｸﾛｰﾙﾌﾗｸﾞ(=1:活性化)
        '                mlngSideScrollFlag = CMlngSideScrollOnFlag
        '
        '                '@右ｽｸﾛｰﾙ活性化
        '                cmdRight.Enabled = True
        '            End If
                    
                    '@ﾌｫｰｶｽの初期化
                    .Col = .Cols.Fixed
                    .LeftCol = .Cols.Fixed
                    
                    '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御（ｸﾞﾘｯﾄﾞ共通化関数）
                    Call pubCmdLREnable_Set(vsfLotListWF, cmdLeft, cmdRight)
        '@↑2007/07/10 (Tue) 14:45:16 N.Kasai **************************************************
                    
                    'NSYS イベントハンドラーを元に戻す
                    AddHandler vsfLotListWF.BeforeRowColChange, AddressOf vsfLotListWF_BeforeRowColChange
                    AddHandler vsfLotListWF.RowColChange, AddressOf vsfLotListWF_RowColChange

                    '@ﾛｯｸ解除
                    .Enabled = True
                Else
                    .Redraw = True
                    .Enabled = False
                End If
                
            End With

            '@該当件数
            lblLotCnt.Text = Format$(mtypInvLotList.lngLotListAnsCnt, CPstrDateFormatKanma)

            '@現在日時表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)

            '@ｽｸﾛｰﾙﾎﾞﾀﾝの表示初期化
            Call pubVsfDisp(vsfLotListWF, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotListWF_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbSBID_Init
    '機　能：利用SBｺﾝﾎﾞﾎﾞｯｸｽ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/29 (Wed) 10:49:35 H.Wajima
    '更新日：2004/09/29 (Wed) 10:49:35
    '備　考：
    Private Sub prvcmbSBID_Init()
        
        Dim lstrEventName           As String       'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        Dim lstrFormName            As String       'ﾌｫｰﾑ名
        Dim ltypMasSbList           As MasSbList    'ｼｽﾃﾑﾌﾞﾛｯｸ構造体
        Dim lblnAns                 As Boolean      '戻り値

        Try
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "prvcmbSBID_Init"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ｼｽﾃﾑﾌﾞﾛｯｸ取得結果
            lblnAns = pubblnMasSbList_Sel(CMstrmas_sblist__Ver, ltypMasSbList)
            '@結果半知恵
            If lblnAns = False Then
            '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            Else
            '@成功の場合
                '@利用SB表示
                Call prvcmbSbID_Disp(ltypMasSbList)
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbSBID_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbSbID_Disp
    '機　能：利用SB表示
    '引　数：ltypMasSbList：ｼｽﾃﾑﾌﾞﾛｯｸ構造体
    '戻り値：なし
    '作成日：2004/09/29 (Wed) 10:53:47 H.Wajima
    '更新日：2004/09/29 (Wed) 10:53:47
    '備　考：
    Private Sub prvcmbSbID_Disp(ByRef ltypMasSbList As MasSbList)

        Dim llngCnt             As Integer              'ｶｳﾝﾄ

        Try
             
            With cmbSBID
                '@利用SB初期化
                .Clear
                .DispCols = CMlngCmbDispCol2                            'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                           '値取得列
                .GetCol = CMlngCmbGetCol0                               '表示列
                With .Font                                              'ﾌｫﾝﾄｻｲｽﾞ
                                                                        'ﾌｫﾝﾄ名
                    cmbSBID.Font = _
                        New Font(CMstrCmbFontName, CMlngCmbFontSize, .Style, _
                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                          'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                                                                        'ｸﾞﾘｯﾄﾞﾌｫﾝﾄ名
                    cmbSBID.GridFont = _
                        New Font(CMstrCmbGridFontName, CMlngCmbGridFontSize, .Style, _
                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .ColAlignment(CMlngCmbGetCol0) = TextAlignEnum.LeftCenter    '左寄中央揃え
                .ColAlignment(CMlngCmbGetCol1) = TextAlignEnum.LeftCenter    '左寄中央揃え
                .DirectInput = False                                    '直接入力(Flase)
                .GroupCols = CMlngCmbGroupCols                          'ｸﾞﾙｰﾌﾟ列数
                .RowHeight = CMlngCmbRowHeight                          '行高さ
                
                '@利用SBがない場合
                If ltypMasSbList.lngSbListCnt = 0 Then
                    Exit Sub
                End If
                
                '@利用SBがなくなるまで
                For llngCnt = 0 To ltypMasSbList.lngSbListCnt - 1
                    With ltypMasSbList.typSbList(llngCnt)
                        '@ｺﾝﾎﾞﾎﾞｯｸｽの項目追加
                        cmbSBID.AddItem(.strSBName & vbTab & .strSbID)          'ｼｽﾃﾑﾌﾞﾛｯｸID&ｼｽﾃﾑﾌﾞﾛｯｸ名
                        
                        '@ﾃﾞﾌｫﾙﾄ表示行の判定
                        If .strSbID = pstrSBID Then
                        '@起動中のｼｽﾃﾑﾌﾞﾛｯｸと一致した場合
                            '@ｺﾝﾎﾞﾎﾞｯｸｽの初期表示行に設定する
                            cmbSBID.ListIndex = llngCnt
                        End If
                    End With
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbSbID_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2007/07/05 (Thu) 11:31:25 N.Kasai **************************************************
    ''関数名：prvSideKeyDown_Proc
    ''機　能：ｸﾞﾘｯﾄﾞｷｰ制御
    ''引　数：lintKeyCode：ｷｰｺｰﾄﾞ
    ''　　　：lstrActiveCtlNm：ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名
    ''　　　：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    ''　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    ''　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    ''戻り値：なし
    ''作成日：2005/02/04 (Fri) 09:10:01 S.Deguchi
    ''更新日：2005/02/04 (Fri) 09:10:01
    ''備　考：
    'Public Sub prvSideKeyDown_Proc(ByRef lintKeyCode As Integer, _
    '                               ByVal lstrActiveCtlNm As String, _
    '                               ByVal lobjvsfGrid As Object, _
    '                               Optional ByVal lobjcmdLeft As Object = Nothing, _
    '                               Optional ByVal lobjcmdRight As Object = Nothing)
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
    '        Select Case lstrActiveCtlNm
    '            '@ｸﾞﾘｯﾄﾞﾌｫｰｶｽがある場合
    '            Case .Name
    '                Select Case lintKeyCode
    '                   '@ｸﾞﾘｯﾄﾞｷｰ制御（[←]ｷｰﾎﾞﾀﾝ）
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
    '                            If llngLeftCol > llngMinCol Then
    '                                llngLeftColCal = llngLeftCol - 1
    '                                .ShowCell llngRow, llngLeftColCal
    '                            Else
    '                                If llngLeftCol = llngMinCol Then
    '                                    llngLeftColCal = llngLeftCol
    '                                    .ShowCell llngRow, llngLeftColCal
    '                                End If
    '                            End If
    '                            lobjcmdRight.Enabled = True
    '                            lobjcmdLeft.Enabled = True
    '                        End If
    '
    '                        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御
    '                        '@ﾌｫｰｶｽｾﾙの列場所による処理分岐
    '                        If llngActiveCol = llngMinCol + 1 Then
    '                            lobjcmdLeft.Enabled = False
    '                            lobjcmdRight.Enabled = True
    '                        Else
    '                            If llngActiveCol = llngMaxCol Then
    '                                lobjcmdLeft.Enabled = True
    '                                lobjcmdRight.Enabled = False
    '                            End If
    '                        End If
    '
    '                   '@ｸﾞﾘｯﾄﾞｷｰ制御（[→]ｷｰﾎﾞﾀﾝ）
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
    '                            If .ColHidden(llngloopcount) <> True Then
    '                                llngMaxCol = llngMaxCol + 1
    '                            End If
    '                        Next llngloopcount
    '
    '                        '@全列数の幅取得(非表示項目は含めない)
    '                        For llngloopcount = 0 To .Cols - 1
    '                            If .ColHidden(llngloopcount) <> True Then
    '                                llngWidthAll = llngWidthAll + .ColWidth(llngloopcount)
    '                            End If
    '                        Next llngloopcount
    '
    '                        '@ｽｸﾛｰﾙ制御用幅計算
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
    '
    '                            lobjcmdRight.Enabled = True
    '                            lobjcmdLeft.Enabled = True
    '                        End If
    '
    '                        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御
    '                        If llngActiveCol = llngMinCol Then
    '                            lobjcmdLeft.Enabled = False
    '                            lobjcmdRight.Enabled = True
    '                        Else
    '                            If llngActiveCol = .Cols - 1 Then
    '                                lobjcmdLeft.Enabled = True
    '                                lobjcmdRight.Enabled = False
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
    '        .strProcName = "prvSideKeyDown_Proc"
    '        .strErrMessage = vbNullString
    '    End With
    '
    '    '@共通ｴﾗｰ処理
    '    Call pubOnError_Proc
    '
    'End Sub
    '@↑2007/07/05 (Thu) 11:31:25 N.Kasai **************************************************


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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfLotListWF.BeforeDoubleClick

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

        'NSYS コントロールとValidateハンドラーの組み合わせ定義
        ldicCtrlToHandler = New Dictionary(Of Control, CancelEventHandler) From { _
                { cmbSBID, AddressOf cmbSBID_Validate }, _
                { txtLotID, AddressOf txtLotID_Validate } _
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
