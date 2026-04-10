'ﾌｧｲﾙ名：xxCM00B0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：対向基板処置登録　メインフォーム
'作成日：2004/07/05 (Mon) 09:38:18 T.Kitagawa
'更新日：2011/10/18 (Tue) 13:06:18 M.Sakka
'備　考：
'　　　：2004/10/29 (Fri) 08:51:58 S.Deguchi    ﾊﾟﾚｯﾄ表示のｸﾞﾘｯﾄﾞを追加(ﾁｯﾌﾟ数量表示処理を修正)
'　　　：2005/01/17 (Mon) 16:05:52 S.Deguchi    不具合改善№136対応(機能ﾊﾞｰｼﾞｮﾝ/ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ,ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ未)
'　　　：2005/01/21 (Fri) 14:53:35 S.Deguchi    引継ぎ処理修正(不具合改善№463)
'　　　：2005/04/01 (Fri) 15:15:51 S.Deguchi    確定処理で数量入力にｶﾝﾏ編集解除処理を追加
'　　　：2005/11/01 (Tue) 16:50:30 T.Kitagawa   ﾘﾜｰｸも不良管理とし、要因で切分けする(ﾕｰｻﾞ要望№0073)
'　　　：2007/07/30 (Mon) 13:06:18 N.Kasai      ｿｰｽ整備
'　　　：2011/10/18 (Tue) 13:06:18 M.Sakka      Ver05.03: 不良コード表示時のシステムエラー発生を修正(REQ-1229)
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00B0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00B0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00B0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00B0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00B0)
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
    '======================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ

    '@↓2011/10/18 (Tue) 13:06:18 M.Sakka **************************************************
    'Private Const CMstrLocalVersion             As String = "05.02"
    Private Const CMstrLocalVersion             As String = "05.03"
    '@↑2011/10/18 (Tue) 13:06:18 M.Sakka **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_cfinsprstVer         As String = "02.00"     'CF不良登録
    Private Const CMstrlot_cfkireworkVer        As String = "02.00"     'CFﾘﾜｰｸ変更
    Private Const CMstrmas_scplist_Ver          As String = "03.00"     '不良項目入力項目取得
    Private Const CMstrlot_cfkinuminfoVer       As String = "01.01"     'CFKI数量取得
    Private Const CMstrlot_cfkilotinfoVer       As String = "01.02"     'CFKIﾛｯﾄ情報取得
    Private Const CMstrinv_cflotinfoVer         As String = "01.00"     'CFﾛｯﾄ情報取得

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN00H0      'ﾛｰｶﾙ機能ID

    '@vsfの定数宣言
    Private Const CMlngGridTitleHeight          As Integer = 21         'ﾀｲﾄﾙの高さ
    Private Const CMlngGridRowHeight            As Integer = 43         '1明細の高さ
    Private Const CMlngGridHFontSize            As Integer = 12         'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngGridFontSize             As Integer = 14         'ﾌｫﾝﾄｻｲｽﾞ

    '@ｽﾛｯﾄ情報
    Private Const CMlngvsfPSlotTitle            As Integer = 0          'ﾀｲﾄﾙ
    Private Const CMlngvsfPSlotNum              As Integer = 0          'ｽﾛｯﾄｶｳﾝﾄ
    Private Const CMlngvsfPSlotID               As Integer = 1          'ﾊﾟﾚｯﾄID
    Private Const CMlngvsfPSlotThicknessCode    As Integer = 2          '板厚
    Private Const CMlngvsfPSlotReworkCheck      As Integer = 3          'ﾁｪｯｸﾎﾞｯｸｽ：ﾘﾜｰｸ
    Private Const CMlngvsfPSlotScrapCheck       As Integer = 4          'ﾁｪｯｸﾎﾞｯｸｽ：不良
    Private Const CMlngvsfPSlotMinRow           As Integer = 1          'Rowの1行目
    Private Const CMlngvsfPSlotMaxRow           As Integer = 18         'Rowの最終行
    Private Const CMlngvsfPSlotPageRows         As Integer = 9          '1頁の表示行数

    '@ﾘﾜｰｸ情報
    Private Const CMlngvsfReworkTitle           As Integer = 0          'ﾀｲﾄﾙ
    Private Const CMlngvsfReworkThicknessCode   As Integer = 0          'CF板厚
    Private Const CMlngvsfReworkChipNum         As Integer = 1          'CFﾘﾜｰｸ数量
    Private Const CMlngvsfReworkPageRows        As Integer = 9          '1頁の表示行数

    '@不良ｺｰﾄﾞ情報
    Private Const CMlngvsfScrapTitle            As Integer = 0          'ﾀｲﾄﾙ
    Private Const CMlngvsfScrapCode             As Integer = 0          '不良ｺｰﾄﾞ
    Private Const CMlngvsfScrapName             As Integer = 1          '不良名称
    Private Const CMlngvsfScrapChipNum          As Integer = 2          '不良数量
    Private Const CMlngvsfScrapPageRows         As Integer = 9          '1頁の表示行数

    '@その他宣言
    Private Const CMlngInputByte                As Integer = 5          '数字入力の最大ﾊﾞｲﾄ数
    Private Const CMstrHandWork                 As String = "0"         'ﾊﾝﾄﾞﾜｰｸ
    Private Const CMstrTPAL                     As String = "TP"        'TPAL

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mstrTaihiCarrierID                  As String               'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrLotLastUpdate                   As String               'ﾛｯﾄ最終更新日時
    Private mstrWPTYPE                          As String               'WP_TYPE退避領域
    Private mstrEventName                       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

    Private mlngChipReworkInputSumNum           As Integer              'ﾘﾜｰｸ入力合計数量
    Private mlngChipScrapInputSumNum            As Integer              '要因入力合計数量
    Private mlngChipTxtScrapInputNum            As Integer              '不良入力数量
    Private mlngChipNomalCnt                    As Integer              '情報取得時のﾁｯﾌﾟ良品数量
    Private mblnTakeOverDispFlg                 As Boolean              '引継ぎ表示ﾌﾗｸﾞ
    Private mblnReworkAfterEditFlag             As Boolean              'ﾘﾜｰｸAfterEditﾌﾗｸﾞ(True:AfterEdit実行)
    Private mblnScrapAfterEditFlag              As Boolean              '不良AfterEditﾌﾗｸﾞ(True:AfterEdit実行)
    Private mblnReworkDrawFlag                  As Boolean              'ﾘﾜｰｸ描写ﾌﾗｸﾞ
    Private mblnScrapDrawFlag                   As Boolean              '不良描写ﾌﾗｸﾞ

    Private buttonProcessing                    As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean              'NSYS WindowCloseフラグ
    Private mstrBeforeReworkEditString          As String               'NSYS リワーク変更前文字列
    Private mstrBeforeScrapEditString           As String               'NSYS スクラップ変更前文字列
    Private lpreRow                             As Integer              'NSYS 要因ソート前選択行
    Private lprePos                             As Point                'NSYS 要因ソート前スクロール位置

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
        pubVsfMouseWheelManager_Set(vsfPaletteSlotMap, cmdSlotUp, cmdSlotDown)
        pubVsfMouseWheelManager_Set(vsfRework, cmdReworkUp, cmdReworkDown)
        pubVsfMouseWheelManager_Set(vsfScrap, cmdScrapUp, cmdScrapDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '======================================Private==========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 11:06:34 T.Kitagawa
    '更新日：2004/10/25 (Mon) 11:23:15 N.Kojima
    '備　考：
    '　　　：2004/10/25 (Mon) 18:36:24 N.Kojima　   引継ぎ時の処理追加。(不具合№124)
    '　　　：2004/10/29 (Fri) 08:54:43 S.Deguchi    引継ぎ処理を修正(作業終了から/CFKI作業終了から/装置別一覧からのﾊﾟﾀｰﾝで修正)
    '　　　：2005/01/21 (Fri) 14:53:35 S.Deguchi    引継ぎ処理修正(不具合改善№463)
    '　　　：2005/10/26 (Wed) 15:25:08 S.Deguchi    引継処理の修正(不具合№2404)
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値

        Try
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00H0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                Exit Sub
            End If
            
            '@画面初期化
            Call prvfrmxxCM00B0_Init()
            
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@ﾌｫｰﾑ起動区分判定
            If pblnfrmxxCM00B0Kbn = False Then
                '@単独起動の場合
                '@ｷｬﾘｱIDのﾃｷｽﾄﾎﾞｯｸｽを使用可能にする
                With txtCarrier
                    .Enabled = True
                    .BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                End With
                
                '@Form_Loadﾌﾗｸﾞ(正常)
                pblnFormLoad = True
            Else
                '@他機能からの起動
                '@ｷｬﾘｱIDのﾃｷｽﾄﾎﾞｯｸｽを使用不可能にする
                With txtCarrier
                    .Enabled = True
                    .Locked = True
                    .TabStop = False
                    .BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
                    .GotBackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
                    .GotHighLight = False
                    
                    '@ﾃｷｽﾄﾎﾞｯｸｽに(作業終了/CFKI作業終了から引継いだ)ｷｬﾘｱIDをｾｯﾄ
                    .Text = ptypCfkiRenkeiInfo.strCarrierId
                End With
                
                '@ｷｬﾘｱIDの自動取得
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs())
            
                '@引継ぎ情報表示済みﾌﾗｸﾞ
                mblnTakeOverDispFlg = True
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
    '作成日：2004/07/27 (Tue) 16:18:36 H.Wajima
    '更新日：2004/09/09 (Thu) 09:47:04 N.Kasai
    '備　考：2004/09/09 (Thu) 09:47:04 N.Kasai      ｷｬﾘｱ引継ぎ機能追加
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@引継ぎ情報表示済みﾌﾗｸﾞの判定
            '@FormLoad後、最初の1回しか処理しない
            If mblnTakeOverDispFlg = True Then
                '@引継ぎ情報が表示済みの場合
                Exit Sub
            End If
            
            '@引継ぎ情報表示済みﾌﾗｸﾞにTrueを設定する
            mblnTakeOverDispFlg = True
            
            '@引数のｷｬﾘｱIDが空白かどうか判定する(装置別一覧から起動の場合)
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合
                '@ｷｬﾘｱIDの初期値を設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                '@ｷｬﾘｱIDの自動取得
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs())
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 11:13:14 T.Kitagawa
    '更新日：2004/09/28 (Tue) 20:58:25 T.Kitagawa
    '備　考：2004/09/09 (Thu) 09:48:04 N.Kasai　    ｷｬﾘｱ引継ぎ機能追加
    '　　　：2004/09/28 (Tue) 20:58:25 T.Kitagawa　 ﾌｫｰﾑ起動区分の初期化(不具合№978)
    '　　　：2004/11/01 (Mon) 15:00:22 S.Deguchi    閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm             As Boolean             '開放結果格納
        Dim ltypCfkiRenkeiInfo      As CfkiRenkeiInfo      '連携情報初期化用構造体

        Try

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@自ﾌｫｰﾑ起動の場合はACT開放後、終了する
            If pblnfrmxxCM00B0Kbn = True Then
            '@引継起動の場合
                '@ﾌｫｰﾑ起動区分を初期化
                pblnfrmxxCM00B0Kbn = False
            Else
            '@単独起動の場合
                '@ActInitﾌﾗｸﾞの判定
                If pblnActInitFlg = True Then
                    '@Actを自前で初期化した場合
                    
                    '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                    lblnAnsTerm = pubblnAct_Term
                    If lblnAnsTerm = True Then
                        '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                    End If
                Else
                    '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
                    pblnFormLoad = False
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
                End If
                
                '@対向基板ﾘﾜｰｸ不良登録連携格納変数のｸﾘｱ
                ptypCfkiRenkeiInfo = ltypCfkiRenkeiInfo
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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 11:16:08 T.Kitagawa
    '更新日：2004/12/10 (Fri) 17:15:17 H.Wajima
    '備　考：2004/10/19 (Tue) 18:38:18 M.Miura　    ﾘﾜｰｸ数、不良数ｸﾞﾘｯﾄﾞｷｰ制御追加
    '　　　：2004/10/29 (Fri) 09:06:15 S.Deguchi    ｽﾛｯﾄ数のｸﾞﾘｯﾄﾞｷｰ制御追加
    '　　　：2004/12/10 (Fri) 17:15:17 H.Wajima     操作により、ﾘﾜｰｸと不良のｸﾞﾘｯﾄﾞでEditが有効にならない場合の対応
    '　　　：2004/12/29 (Wed) 10:07:03 S.Deguchi    ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙによる処理判別を追加
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@ｽﾛｯﾄ数ｸﾞﾘｯﾄﾞｷｰ制御
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfPaletteSlotMap, cmdSlotUp, cmdSlotDown)

            '@ﾘﾜｰｸ数ｸﾞﾘｯﾄﾞｷｰ制御
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfRework, cmdReworkUP, cmdReworkDown)
            
            '@不良数ｸﾞﾘｯﾄﾞｷｰ制御
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfScrap, cmdScrapUp, cmdScrapDown)

            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙによる処理判別
            Select Case ActiveControl.Name
                Case txtCarrier.Name
                '@ｷｬﾘｱIDの場合
                    Select Case e.KeyCode
                        '@Enterの場合
                        Case Keys.Return
                            '@Validate処理を動かす
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs())
                    End Select

                Case vsfPaletteSlotMap.Name
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞが有効な場合
                    Select Case e.KeyCode
                        Case Keys.Return
                        '@Enterの場合
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select

                Case vsfRework.Name
                '@ﾘﾜｰｸｸﾞﾘｯﾄﾞが有効な場合
                    Select Case e.KeyCode
                        Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.F2
                        '@↑↓←→とF2ｷｰの場合
                            '@F2と←の場合はｷｰ無効
                            If vsfRework.Col = CMlngvsfReworkChipNum AndAlso (e.KeyCode = Keys.F2 Or e.KeyCode = Keys.Left) Then
                                e.SuppressKeyPress = True
                            End If
                            '@ﾘﾜｰｸｸﾞﾘｯﾄﾞClick処理を実行する
                            Call vsfRework_Click(vsfRework, New EventArgs())
                            
                        Case Keys.Return
                        '@Enterの場合
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
                    
                Case vsfScrap.Name
                '@不良ｸﾞﾘｯﾄﾞが有効な場合
                    Select Case e.KeyCode
                        Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.F2
                        '@↑↓←→とF2ｷｰの場合
                            '@F2と←の場合はｷｰ無効
                            If vsfScrap.Col = CMlngvsfScrapChipNum AndAlso (e.KeyCode = Keys.F2 Or e.KeyCode = Keys.Left) Then
                                e.SuppressKeyPress = True
                            End If
                            '@不良ｸﾞﾘｯﾄﾞclick処理を実行する
                            Call vsfScrap_Click(vsfScrap, New EventArgs())
                        
                        Case Keys.Return
                        '@Enterの場合
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
                
                Case Else
                    Select Case e.KeyCode
                        '@Enterの場合
                        Case Keys.Return
                            If ActiveControl IsNot vsfRework.Editor And ActiveControl IsNot vsfScrap.Editor Then
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            Else
                                If ActiveControl Is vsfRework.Editor Then
                                    vsfRework.HighLight = HighLightEnum.WithFocus
                                Else
                                    vsfScrap.HighLight = HighLightEnum.WithFocus
                                End If
                            End If
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
    '機　能：ｷｰ入力の制限
    '引　数：KeyAscii：ｱｽｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 19:51:37 T.Kitagawa
    '更新日：2004/07/15 (Thu) 19:51:37
    '備　考：
    Private Sub Form_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress

        Try

            Select Case Asc(e.KeyChar)
                '@ｶﾝﾏ(44),ﾏｲﾅｽ(45),ﾋﾟﾘｵﾄﾞ(46)の場合
                Case 44, 45, 46
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

    '関数名：cmdClose_Click
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 11:22:08 T.Kitagawa
    '更新日：2005/02/15 (Tue) 13:25:37 N.Kojima
    '備　考：
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
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

            '@親ﾌｫｰﾑ起動の場合
            If pblnfrmxxCM00B0Kbn = True Then
                '@ﾌｫｰﾑを閉じる
                Me.Close()
            Else
                '@引継ぎ情報のｷｬﾘｱIDが空白かどうか判定する
                If ptypCommonInfo.strCarrierId <> vbNullString Then
                    '@空白でない場合
                    '@親画面切り替え引継ぎ制御
                    Call pubChangeScreen_Set(Me)
                Else
                    '@空白の場合
                    '@終了関数を実行する
                    llngRet = publngEnd_Proc(CPstrKeyEN00H0, ltypCommonInfo)
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

    '関数名：cmdClear_Click
    '機　能：全部取消ﾎﾞﾀﾝのｸﾘｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 17:39:21 T.Kitagawa
    '更新日：2005/05/11 (Wed) 14:06:12 N.Kojima
    '備　考：
    '　　　：2005/05/11 (Wed) 14:06:12 N.Kojima     ｷｬﾘｱが有効で入力可の場合、ﾌｫｰｶｽをｷｬﾘｱにｾｯﾄする(不具合№718)
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@画面ｸﾘｱ処理(取得情報はそのまま)
            Call prvfrmxxCM00B0_Clear()
            
            '@ｷｬﾘｱが有効かつ、入力可の状態か
            If txtCarrier.Enabled = True And _
               txtCarrier.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) Then
                '@ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
            End If

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
    '機　能：確定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 11:24:36 T.Kitagawa
    '更新日：2005/11/09 (Wed) 13:15:10 T.Kitagawa
    '備　考：
    '　　　：2005/01/18 (Tue) 11:18:43 S.Deguchi    ﾛｯﾄｱｳﾄﾒｯｾｰｼﾞ追加
    '　　　：2005/03/16 (Wed) 10:46:54 S.Deguchi    ﾛｯﾄｱｳﾄﾒｯｾｰｼﾞがﾀﾞﾌﾞってしまっているので削除
    '　　　：2005/11/09 (Wed) 13:15:10 T.Kitagawa   連携情報の不良数へ設定する際は不良ﾃｷｽﾄBOX値を設定する(ﾕｰｻﾞ要望0073)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnInputCheck          As Boolean              '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnReworkAns           As Boolean              'ﾘﾜｰｸ登録結果取得(True:正常,False:異常)
        Dim lblnScrapAns            As Boolean              '不良登録結果取得(True:正常,False:異常)
        Dim ltypLotCfkiRework       As LotCfkiRework        'CFﾘﾜｰｸ変更構造体
        Dim ltypLotCfinsprst        As LotCfinsprst         'CF不良登録構造体
        Dim ltypLotCfkiLotInfo      As LotCfkiLotinfo       'CFKIﾛｯﾄ情報取得構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@画面入力ﾁｪｯｸ
            lblnInputCheck = prvblnInput_Chk
            If lblnInputCheck = False Then
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "cmdRegist_Click"
            Call pubResponseStart(Me.Name, mstrEventName)

            '@CFﾘﾜｰｸ変更構造体ﾃﾞｰﾀ格納
            If mlngChipReworkInputSumNum > 0 Then
                Call prvLotCfkiRework_Set(ltypLotCfkiRework)
            End If
            
            '@CF不良登録構造体ﾃﾞｰﾀ格納
            If mlngChipScrapInputSumNum > 0 Then
                Call prvLotCfkiScrap_Set(ltypLotCfinsprst)
            End If
            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = False
            Select Case True
                Case mlngChipReworkInputSumNum > 0 And mlngChipScrapInputSumNum <= 0
                    '@ﾘﾜｰｸ登録のみの場合
                    lblnAns = pubblnLotCfkiRework_Upd(CMstrlot_cfkireworkVer, ltypLotCfkiRework)
                    
                Case mlngChipReworkInputSumNum <= 0 And mlngChipScrapInputSumNum > 0
                    '@不良登録のみの場合
                    lblnAns = pubblnLotCfinsprst_Ins(CMstrlot_cfinsprstVer, ltypLotCfinsprst)
                
                Case mlngChipReworkInputSumNum > 0 And mlngChipScrapInputSumNum > 0
                    '@ﾘﾜｰｸ登録、不良登録の両方の場合
                    '@ﾘﾜｰｸ登録の実行
                    lblnReworkAns = pubblnLotCfkiRework_Upd(CMstrlot_cfkireworkVer, ltypLotCfkiRework)
                    If lblnReworkAns = True Then
                        '@不良登録の実行
                        lblnScrapAns = pubblnLotCfinsprst_Ins(CMstrlot_cfinsprstVer, ltypLotCfinsprst)
                        If lblnScrapAns = True Then
                            '@登録正常
                            lblnAns = True
                        Else
                            '@登録異常
                            lblnAns = False
                        End If
                    Else
                        '@登録異常
                        lblnAns = False
                    End If
            End Select
            
            '@登録結果の判定
            If lblnAns = True Then
                '@良品数が0枚の場合には表示ﾒｯｾｰｼﾞを変更する
                If lblChipNormalNum.Text = CPstrZero Then
                    '@表示ﾒｯｾｰｼﾞ変換(ﾛｯﾄｱｳﾄﾒｯｾｰｼﾞ)
                    '@"<TRM4AI>$$対向基板処置登録を行い、$ロット終了しました。キャリア[%1] ロット[%2]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004A, txtCarrier.Text, lblLotID.Text)
                Else
                    '@表示ﾒｯｾｰｼﾞ変換(通常ﾒｯｾｰｼﾞ)
                    '@"<TRM0KI>$$対向基板処置登録しました。キャリア[%1] ロット[%2]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000K, txtCarrier.Text, lblLotID.Text)
                End If
                
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                                                  
                '@ﾌｫｰﾑ起動区分判定
                If pblnfrmxxCM00B0Kbn = False Then
                    '@ｷｬﾘｱIDのｸﾘｱ
                    txtCarrier.Text = vbNullString
                    
                    '@ﾛｯﾄ情報の初期化
                    Call prvfrmxxCM00B0_Init()
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
                    
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrier)
                Else
                    '@ﾛｯﾄｱｳﾄ処理を行った場合
                    If lblChipNormalNum.Text = CPstrZero Then
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(Me.Name, mstrEventName)
                        
                        '@連携情報の初期化
                        With ptypCfkiRenkeiInfo
                            '@連携情報再ｾｯﾄ
                            .strCarrierId = vbNullString                                        'ｷｬﾘｱID
                            .strLotLastUpdate = vbNullString                                    '最終更新日時
                        End With
                        
                        '@画面を閉じる
                        Call cmdClose_Click(cmdClose, EventArgs.Empty)
                    Else
                        '@CFKIﾛｯﾄ情報の最終更新日時の再取得
                        lblnAns = pubblnLotCfkilotinfo_Sel(CMstrlot_cfkilotinfoVer, txtCarrier.Text, ltypLotCfkiLotInfo)
                        '@結果判定
                        If lblnAns = True Then
                            '@連携情報へ設定
                            With ptypCfkiRenkeiInfo
                                '@連携情報から再ｾｯﾄ
                                .lngChipRemainCount = lblChipNormalNum.Text                         '良品数
                                .lngChipScrapCount = mlngChipTxtScrapInputNum                       '不良数
                                .lngChipReworkCount = lblReworkNum.Text                             'ﾘﾜｰｸ数
                                .strLotLastUpdate = ltypLotCfkiLotInfo.strLotLastUpdate             '最終更新日時
                            End With
                            
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(Me.Name, mstrEventName)
                            
                            '@画面を閉じる
                            Call cmdClose_Click(cmdClose, EventArgs.Empty)
                        Else
                            '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                            Call pubResponseCancel(Me.Name, mstrEventName)
                        End If
                    End If
                End If
            Else
                '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
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

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱID変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 14:22:25 T.Kitagawa
    '更新日：2004/07/06 (Tue) 14:22:25
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try

            '@画面ｸﾘｱ処理
            Call prvfrmxxCM00B0_Init()

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

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱ情報取得
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 14:56:05 T.Kitagawa
    '更新日：2005/11/09 (Wed) 13:38:56 T.Kitagawa
    '備　考：2004/10/20 (Wed) 15:27:58 T.Kitagawa   不良項目取得Msg変更
    '　　　：2004/10/25 (Mon) 18:36:24 N.Kojima　   不良項目がない場合の処理追加。(不具合№124)
    '　　　：2004/10/29 (Fri) 09:03:51 S.Deguchi    ﾚｽﾎﾟﾝｽ取得終了関数位置変更
    '　　　：2005/03/01 (Tue) 14:33:43 S.Deguchi    不具合№261の対応でﾛｯﾄの現在状態でのﾁｪｯｸに「処理中」許可を追加
    '　　　：2005/05/11 (Wed) 19:23:56 N.Kojima     TPAL処置可能対応(不具合№718)
    '　　　：2005/11/09 (Wed) 13:38:56 T.Kitagawa   不良ﾃｷｽﾄBOX値へﾌｫｰｶｽ初期設定する(ﾕｰｻﾞ要望0073)
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotCfkiLotInfo      As LotCfkiLotinfo       'CFKIﾛｯﾄ情報取得構造体
        Dim ltypLotCfkinuminfo      As LotCfkinuminfo       'CFKI数量取得構造体
        Dim ltypMasItemList         As MasItemList          '不良ｺｰﾄﾞ情報格納構造体
        Dim ltypInvCFLotInfo        As InvCFLotInfo         '要求構造体
        Dim ltypInvCFLotInfoList    As InvCFLotInfoList     '応答構造体

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ起動区分判定
            If pblnfrmxxCM00B0Kbn = False Then
            
                '@ｷｬﾘｱIDの空白ﾁｪｯｸ
                If Trim(txtCarrier.Text) = vbNullString Then
                    If Not IsNothing(Me.ActiveControl) AndAlso Me.ActiveControl.Name = txtCarrier.Name Then
                        '@閉じるへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                    '@処理終了
                    Exit Sub
                End If
                
                '@ｷｬﾘｱIDの桁ﾁｪｯｸ
                If txtCarrier.NowByte < CPlngCarrierMaxLength Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    '@"<TRM07W>$$キャリアIDは6桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    e.Cancel = True
                    
                    Exit Sub
                End If
            End If
            
            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If Trim(txtCarrier.Text) <> vbNullString And _
                Len(Trim(txtCarrier.Text)) = CPlngCarrierMaxLength And _
                txtCarrier.Text <> mstrTaihiCarrierID Then
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                mstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(Me.Name, mstrEventName)
                
                '@ﾛｯﾄ情報の初期化
                Call prvfrmxxCM00B0_Init()
                
                '@CFKIﾛｯﾄ情報の取得
                lblnAns = pubblnLotCfkilotinfo_Sel(CMstrlot_cfkilotinfoVer, _
                                                   txtCarrier.Text, _
                                                   ltypLotCfkiLotInfo)
                '@結果判定
                If lblnAns = True Then
                    '@CFKI数量情報の取得
                    lblnAns = pubblnLotCfkinuminfo_Sel(CMstrlot_cfkinuminfoVer, _
                                                       txtCarrier.Text, _
                                                       ltypLotCfkinuminfo)
                    '@結果判定
                    If lblnAns = True Then
                        '@不良ｺｰﾄﾞ情報の取得
                        lblnAns = pubblnMasScpList_Sel(pstrSBID, _
                                                       CMstrmas_scplist_Ver, _
                                                       CPstrCD3I, _
                                                       ltypLotCfkiLotInfo.strLotScrapSetID, _
                                                       ltypMasItemList)
                        '@結果判定
                        If lblnAns = True Then
                        
                            '@情報要求構造体に情報をｾｯﾄ
                            ltypInvCFLotInfo.strCarrierId = txtCarrier.Text           'ｷｬﾘｱID
                            ltypInvCFLotInfo.strMsgVer = CMstrinv_cflotinfoVer        'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                            ltypInvCFLotInfo.strSbID = pstrSBID                       'ｼｽﾃﾑﾌﾞﾛｯｸ
                            
                            '@CFﾛｯﾄ情報取得ﾒｯｾｰｼﾞ
                            lblnAns = pubblnInvCFLotInfo_Sel(ltypInvCFLotInfo, ltypInvCFLotInfoList)
                            
                            '@結果判定
                            If lblnAns = True Then

                                '@ｷｬﾘｱIDの退避
                                mstrTaihiCarrierID = txtCarrier.Text                'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
                                
                                '@ﾛｯﾄ情報の画面表示処理
                                Call prvfrmxxCM00B0_Disp(ltypLotCfkinuminfo, ltypLotCfkiLotInfo)

                                '@ﾊﾟﾚｯﾄﾏｯﾌﾟ表示処理
                                Call prvvsfPaletteSlotMap_Disp(ltypLotCfkiLotInfo)
                                
                                '@ﾘﾜｰｸ入力一覧表示処理
                                Call prvvsfRework_Disp(ltypLotCfkinuminfo, ltypLotCfkiLotInfo, ltypInvCFLotInfoList)
                            
                                '@不良入力一覧表示処理
                                Call prvvsfScrap_Disp(ltypMasItemList)

                                
                                '@不良項目がない場合
                                If ltypMasItemList.lngListCnt = 0 Then
                                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                    Call pubResponseCancel(Me.Name, mstrEventName)
                                    
                                    '@WP_TYPEによる処理判別
                                    If mstrWPTYPE = CMstrHandWork Then
                                        '@ﾊﾝﾄﾞﾜｰｸ工程の場合
                                        '@状態が「処理中」「後処理」の場合
                                        If lblStatus.Text = CPstrAfterProgressSt Or _
                                           lblStatus.Text = CPstrProcessingSt Then
                                           
                                            '@"<TRM3DI>$$不良項目が設定されていないので、対向基板処置登録はできません。"
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003D)
                                            '@警告ﾒｯｾｰｼﾞ
                                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                        End If
                                    Else
                                        '@それ以外
                                        '@状態が「後処理」の場合
                                        If lblStatus.Text = CPstrAfterProgressSt Then
                                            '@"<TRM3DI>$$不良項目が設定されていないので、対向基板処置登録はできません。"
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003D)
                                            '@警告ﾒｯｾｰｼﾞ
                                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                        End If
                                    End If
                                    
                                    Exit Sub
                                End If
                                
                                '@ﾚｽﾎﾟﾝｽ取得終了
                                Call publngResponseEnd(Me.Name, mstrEventName)
                                
                                '@ﾌｫｰｶｽｾｯﾄ処理
                                If pblnFormLoad = True Then
                                    '@子画面(孫画面)起動の場合でﾌｫｰｶｽｾｯﾄ
                                    If vsfPaletteSlotMap.Enabled = True Then
                                        '@ｽﾛｯﾄﾏｯﾌﾟへﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(vsfPaletteSlotMap)
                                            
                                        '@AfterEditﾌﾗｸﾞ設定
                                        mblnReworkAfterEditFlag = True
                                        
                                        '@AfterEditﾌﾗｸﾞ設定
                                        mblnScrapAfterEditFlag = True
                                    Else
                                        '@不良数へ
                                        Call pubSetFocus(txtScrap)
                                    End If
                                Else
                                    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ設定
                                    pblnFormLoad = True
                                End If
                                
                                Exit Sub
                            Else
                                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                                e.Cancel = True
                                
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(Me.Name, mstrEventName)
                                
                                Exit Sub
                                
                            End If
                        Else
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, mstrEventName)
                            
                            '@ﾌｫｰﾑ起動区分判定
                            If pblnfrmxxCM00B0Kbn = False Then
                                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                                e.Cancel = True
                            End If
                            
                            Exit Sub
                        End If
                    Else
                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                        e.Cancel = True
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, mstrEventName)
                        
                        Exit Sub
                    End If
                Else
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    
                    Exit Sub
                End If
            Else
                '@ﾌｫｰｶｽｾｯﾄ処理
                If pblnFormLoad = True Then
                    If vsfPaletteSlotMap.Enabled = True Then
                        '@ｽﾛｯﾄﾏｯﾌﾟへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfPaletteSlotMap)
                            
                        '@AfterEditﾌﾗｸﾞ設定
                        mblnReworkAfterEditFlag = True
                        
                        '@AfterEditﾌﾗｸﾞ設定
                        mblnScrapAfterEditFlag = True
                    Else
                        '@不良数へ
                        Call pubSetFocus(txtScrap)
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

    '関数名：txtScrap_Validate
    '機　能：不良数のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/11/09 (Wed) 13:24:27 T.Kitagawa
    '更新日：2005/11/09 (Wed) 13:24:27
    '備　考：
    Private Sub txtScrap_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtScrap.Validating

        Dim lblnAns         As Boolean      '結果判定
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@数値か否かのﾁｪｯｸ
            If IsNumeric(txtScrap.Text) = True Then
                
                '@良品数量の計算結果からﾏｲﾅｽの場合にﾒｯｾｰｼﾞを表示する
                '@残数確認
                If mlngChipNomalCnt < (mlngChipReworkInputSumNum + CLng(txtScrap.Text)) Then
                    '@"<TRM4SW>$$数量には良品数より小さい値を入力してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004S)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@入力した情報を反映させない
                    e.Cancel = True
                Else
                    '@入力した情報を反映させる
                    e.Cancel = False
                    '@不良入力数量の変数へ格納
                    mlngChipTxtScrapInputNum = CLng(txtScrap.Text)
                End If
            Else
                '@入力した情報を反映させる
                e.Cancel = False
                '@不良入力数量の初期化
                mlngChipTxtScrapInputNum = 0
            End If
            
            '@編集後の情報から良品数,ﾘﾜｰｸ数,不良数の計算を行い,ﾗﾍﾞﾙに反映させる
            Call prvReworkScrap_Cal()
            
            '@取消ﾎﾞﾀﾝﾁｪｯｸ処理へ
            lblnAns = prvblncmdClearEnabled_Chk
            '@結果判定
            If lblnAns = True Then
                '@取消ﾎﾞﾀﾝ活性化
                cmdClear.Enabled = True
            Else
                '@取消ﾎﾞﾀﾝ非活性化
                cmdClear.Enabled = False
            End If
            
            '@確定ﾎﾞﾀﾝﾁｪｯｸ処理へ
            lblnAns = prvblncmdRegistEnabled_Chk
            '@結果判定
            If lblnAns = True Then
                '@確定ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtScrap_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPaletteSlotMap_Click
    '機　能：ｽﾛｯﾄﾏｯﾌﾟでのﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/29 (Fri) 13:15:17 S.Deguchi
    '更新日：2004/10/29 (Fri) 13:15:17
    '備　考：
    Private Sub vsfPaletteSlotMap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfPaletteSlotMap.Click
        
        Dim lblnAns         As Boolean      '結果判定

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfPaletteSlotMap.Rows.Count <= vsfPaletteSlotMap.Rows.Fixed Then
                Return
            End If
            
            With vsfPaletteSlotMap
                '@ﾀｲﾄﾙ以外
                If .Row > 0 Then
                    '@選択されたｾﾙにﾊﾟﾚｯﾄIDがある場合
                    If .GetData(.Row, CMlngvsfPSlotID) <> vbNullString Then
                        Select Case .Col
                            Case CMlngvsfPSlotReworkCheck
                            '@選択されてたｾﾙのColがﾘﾜｰｸﾁｪｯｸの場合
                                '@不良ﾁｪｯｸにﾁｪｯｸが入っていない場合のみ操作可能とする
                                If .GetCellCheck(.Row, CMlngvsfPSlotScrapCheck) = CheckEnum.Unchecked Then
                                    '@ﾁｪｯｸが外れている場合
                                    If .GetCellCheck(.Row, CMlngvsfPSlotReworkCheck) = CheckEnum.Unchecked Then
                                        '@ﾁｪｯｸなし→ﾁｪｯｸ
                                        .AllowEditing = True                                                  'ｸﾞﾘｯﾄﾞ編集許可
                                        .SetCellCheck(.Row, CMlngvsfPSlotReworkCheck, CheckEnum.Checked)      'ﾁｪｯｸ
                                        .AllowEditing = False                                                 'ｸﾞﾘｯﾄﾞ編集禁止
                                    Else
                                        '@ﾁｪｯｸ→ﾁｪｯｸなし
                                        .AllowEditing = True                                                  'ｸﾞﾘｯﾄﾞ編集許可
                                        .SetCellCheck(.Row, CMlngvsfPSlotReworkCheck, CheckEnum.Unchecked)    'ﾁｪｯｸ解除
                                        .AllowEditing = False                                                 'ｸﾞﾘｯﾄﾞ編集禁止
                                    End If
                                End If
                                
                            Case CMlngvsfPSlotScrapCheck
                            '@選択されてたｾﾙのColが不良ﾁｪｯｸの場合
                                '@ﾘﾜｰｸﾁｪｯｸにﾁｪｯｸが入っていない場合のみ操作可能とする
                                If .GetCellCheck(.Row, CMlngvsfPSlotReworkCheck) = CheckEnum.Unchecked Then
                                    '@ﾁｪｯｸが外れている場合
                                    If .GetCellCheck(.Row, CMlngvsfPSlotScrapCheck) = CheckEnum.Unchecked Then
                                        '@ﾁｪｯｸなし→ﾁｪｯｸ
                                        .AllowEditing = True                                                  'ｸﾞﾘｯﾄﾞ編集許可
                                        .SetCellCheck(.Row, CMlngvsfPSlotScrapCheck, CheckEnum.Checked)       'ﾁｪｯｸ
                                        .AllowEditing = False                                                 'ｸﾞﾘｯﾄﾞ編集禁止
                                    Else
                                        '@ﾁｪｯｸ→ﾁｪｯｸなし
                                        .AllowEditing = True                                                  'ｸﾞﾘｯﾄﾞ編集許可
                                        .SetCellCheck(.Row, CMlngvsfPSlotScrapCheck, CheckEnum.Unchecked)     'ﾁｪｯｸ解除
                                        .AllowEditing = False                                                 'ｸﾞﾘｯﾄﾞ編集禁止
                                    End If
                                End If
                        End Select
                    End If
                End If
            End With

            '@取消ﾎﾞﾀﾝﾁｪｯｸ処理へ
            lblnAns = prvblncmdClearEnabled_Chk
            '@結果判定
            If lblnAns = True Then
                '@取消ﾎﾞﾀﾝ活性化
                cmdClear.Enabled = True
            Else
                '@取消ﾎﾞﾀﾝ非活性化
                cmdClear.Enabled = False
            End If
            
            '@確定ﾎﾞﾀﾝﾁｪｯｸ処理へ
            lblnAns = prvblncmdRegistEnabled_Chk
            '@結果判定
            If lblnAns = True Then
                '@確定ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfPaletteSlotMap_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRework_AfterEdit
    '機　能：ﾘﾜｰｸｸﾞﾘｯﾄの入力制限設定
    '引　数：Row：変更行
    '　　　：Col：変更列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '作成日：2004/12/29 (Wed) 08:38:29 S.Deguchi
    '更新日：2004/12/29 (Wed) 08:38:29
    '備　考：
    Private Sub vsfRework_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRework.AfterEdit

        Dim lblnAns     As Boolean      '汎用結果格納変数

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRework.Rows.Count <= vsfRework.Rows.Fixed Then
                Return
            End If

            '@AfterEditﾌﾗｸﾞによる処理判定
            If mblnReworkAfterEditFlag = True Then
                '@編集後の情報から良品数,ﾘﾜｰｸ数,不良数の計算を行い,ﾗﾍﾞﾙに反映させる
                Call prvReworkScrap_Cal()
            End If
            
            '@取消ﾎﾞﾀﾝﾁｪｯｸ処理へ
            lblnAns = prvblncmdClearEnabled_Chk
            '@結果判定
            If lblnAns = True Then
                '@取消ﾎﾞﾀﾝ活性化
                cmdClear.Enabled = True
            Else
                '@取消ﾎﾞﾀﾝ非活性化
                cmdClear.Enabled = False
            End If
            
            '@確定ﾎﾞﾀﾝﾁｪｯｸ処理へ
            lblnAns = prvblncmdRegistEnabled_Chk
            '@結果判定
            If lblnAns = True Then
                '@確定ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRework_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRework_BeforeEdit
    '機　能：ﾘﾜｰｸｸﾞﾘｯﾄの入力制限設定
    '引　数：Row：変更行
    '　　　：Col：変更列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/20 (Fri) 13:45:27 T.Kitagawa
    '更新日：2004/08/20 (Fri) 13:45:27
    '備　考：
    Private Sub vsfRework_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRework.SetupEditor

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRework.Rows.Count <= vsfRework.Rows.Fixed Then
                Return
            End If

            '@描画ﾌﾗｸﾞがTrueの場合
            If mblnReworkDrawFlag = True Then
                '@固定行の場合はｽｷｯﾌﾟ
                If e.Row < vsfRework.Rows.Fixed Then
                    e.Cancel = True
                    Exit Sub
                End If
                
                '@編集項目以外はｽｷｯﾌﾟ
                If e.Col <> CMlngvsfReworkChipNum Then
                    e.Cancel = True
                    Exit Sub
                End If
            
                '@最大入力文字数の設定
                '@5ﾊﾞｲﾄ迄入力可能
                Dim tb As TextBox = CType(vsfRework.Editor, TextBox)
                tb.MaxLength = CMlngInputByte

                '@変更前文字列を取得
                mstrBeforeReworkEditString = vsfRework.GetData(e.Row, e.Col)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRework_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRework_Click
    '機　能：ﾘﾜｰｸｸﾞﾘｯﾄの使用可能設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/28 (Tue) 16:59:41 S.Deguchi
    '更新日：2004/12/28 (Tue) 16:59:41
    '備　考：
    Private Sub vsfRework_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfRework.Click

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRework.Rows.Count <= vsfRework.Rows.Fixed Then
                Return
            End If

            '@ﾍｯﾀﾞｰｸﾘｯｸの場合
            If vsfRework.MouseRow = 0 AndAlso vsfRework.MouseCol = 0 Then
                vsfRework.HighLight = HighLightEnum.WithFocus
                Exit Sub
            End If

            '@描画ﾌﾗｸﾞがTrueの場合
            If mblnReworkDrawFlag = True Then
                '@固定行の場合はｽｷｯﾌﾟ
                If vsfRework.Row < vsfRework.Rows.Fixed Then
                    Exit Sub
                End If
            
                With vsfRework
                    If .Col = CMlngvsfReworkChipNum Then
                        'ハイライトを消す
                        .HighLight = HighLightEnum.Never
                        '@編集を許可
                        .Styles.Editor.BackColor = SystemColors.Window
                        .Styles.Editor.ForeColor = SystemColors.WindowText
                        .StartEditing()
                    Else
                        .HighLight = HighLightEnum.WithFocus
                        .AllowEditing = False
                    End If
                End With
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRework_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRework_RowColChange
    '機　能：ﾘﾜｰｸｸﾞﾘｯﾄﾞ編集制御
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/12 (Mon) 14:51:06 N.Kojima
    '更新日：2005/12/12 (Mon) 14:51:06
    '備　考：
    Private Sub vsfRework_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfRework.RowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRework.Rows.Count <= vsfRework.Rows.Fixed Then
                Return
            End If

            '@描画ﾌﾗｸﾞがTrueの場合
            If mblnReworkDrawFlag = True Then
                '@固定行の場合はｽｷｯﾌﾟ
                If vsfRework.Row < vsfRework.Rows.Fixed Then
                    Exit Sub
                End If

                With vsfRework
                    If .Col = CMlngvsfReworkChipNum Then
                        'ハイライトを消す
                        .HighLight = HighLightEnum.Never
                        '@編集を許可
                        .Styles.Editor.BackColor = SystemColors.Window
                        .Styles.Editor.ForeColor = SystemColors.WindowText
                        .StartEditing()
                    Else
                        .HighLight = HighLightEnum.WithFocus
                        .AllowEditing = False
                    End If
                End With
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRework_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRework_ValidateEdit
    '機　能：ﾘﾜｰｸｸﾞﾘｯﾄの変更処理
    '引　数：Row：変更行
    '　　　：Col：変更列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/12 (Mon) 11:30:32 T.Kitagawa
    '更新日：2005/11/09 (Wed) 15:46:52 T.Kitagawa
    '備　考：
    '　　　：2004/12/29 (Wed) 08:40:15 S.Deguchi    数量計算の見直し
    '　　　：2005/11/09 (Wed) 15:46:52 T.Kitagawa   不良数入力対応(ﾕｰｻﾞ要望0073)
    Private Sub vsfRework_ValidateEdit(ByVal sender As Object, ByVal e As ValidateEditEventArgs) Handles vsfRework.ValidateEdit

        Dim llngCnt         As Integer  'ｶｳﾝﾀ
        Dim llngReworkNum   As Integer  'リﾜｰｸ数量

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRework.Rows.Count <= vsfRework.Rows.Fixed Then
                Return
            End If

            '@固定行の場合はｽｷｯﾌﾟ
            If e.Row < vsfRework.Rows.Fixed Then
                Exit Sub
            End If
            
            '@ﾘﾜｰｸ入力ﾁｪｯｸ
            With vsfRework
                '@数値か否かのﾁｪｯｸ
                If IsNumeric(.Editor.Text) = True Then
                    '@Long型へ変換("0"以上の数値が入力されている場合)
                    If CLng(.Editor.Text) >= 0 Then
                        
                        '@ﾘﾜｰｸ数量の計算
                        llngReworkNum = 0                   'ﾘﾜｰｸ合計数量(初期化)
                        
                        For llngCnt = 1 To .Rows.Count - 1
                            '@ｸﾞﾘｯﾄﾞに表示されている情報から合計数量を計算する
                            '@入力行の場合
                            If llngCnt = e.Row Then
                                '@ﾘﾜｰｸ入力数量の加算
                                llngReworkNum = llngReworkNum + CLng(.Editor.Text)
                            Else
                                If IsNumeric(.GetData(llngCnt, CMlngvsfReworkChipNum)) = True Then
                                    '@ﾘﾜｰｸ表示数量の加算
                                    llngReworkNum = llngReworkNum + CLng(.GetData(llngCnt, CMlngvsfReworkChipNum))
                                End If
                            End If
                        Next llngCnt
                    
                        '@良品数量の計算結果からﾏｲﾅｽの場合にﾒｯｾｰｼﾞを表示する
                        '@残数確認
                        If mlngChipNomalCnt < (llngReworkNum + mlngChipTxtScrapInputNum) Then
                            .Editor.Text = mstrBeforeReworkEditString
                            '@"<TRM4SW>$$数量には良品数より小さい値を入力してください。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004S)
                            '@警告ﾒｯｾｰｼﾞ
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@入力した情報を反映させない
                            e.Cancel = True
                        Else
                            '@入力した情報を反映させる
                            e.Cancel = False
                        
                            '@ﾌﾗｸﾞをTrueに設定
                            mblnReworkAfterEditFlag = True
                        End If
                    Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                        '@"数量が入力されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@入力した情報を反映させない
                        e.Cancel = True
                    End If
                Else
                    '@入力欄が空欄以外の場合
                    If Trim(.Editor.Text) <> vbNullString Then
                        .Editor.Text = mstrBeforeReworkEditString
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                        '@"数量が入力されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@入力した情報を反映させない
                        e.Cancel = True
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRework_ValidateEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfScrap_AfterEdit
    '機　能：不良ｸﾞﾘｯﾄの入力制限設定
    '引　数：Row：変更行
    '　　　：Col：変更列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/12/29 (Wed) 08:39:05 S.Deguchi
    '更新日：2004/12/29 (Wed) 08:39:05
    '備　考：
    Private Sub vsfScrap_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfScrap.AfterEdit
        
        Dim lblnAns     As Boolean      '汎用結果格納変数

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfScrap.Rows.Count <= vsfScrap.Rows.Fixed Then
                Return
            End If
            
            '@AfterEditﾌﾗｸﾞによる処理判定
            If mblnScrapAfterEditFlag = True Then
                '@編集後の情報から良品数,ﾘﾜｰｸ数,不良数の計算を行い,ﾗﾍﾞﾙに反映させる
                Call prvReworkScrap_Cal()
            End If
                
            '@取消ﾎﾞﾀﾝﾁｪｯｸ処理へ
            lblnAns = prvblncmdClearEnabled_Chk
            '@結果判定
            If lblnAns = True Then
                '@取消ﾎﾞﾀﾝ活性化
                cmdClear.Enabled = True
            Else
                '@取消ﾎﾞﾀﾝ非活性化
                cmdClear.Enabled = False
            End If
            
            '@確定ﾎﾞﾀﾝﾁｪｯｸ処理へ
            lblnAns = prvblncmdRegistEnabled_Chk
            '@結果判定
            If lblnAns = True Then
                '@確定ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfScrap_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfScrap_BeforeEdit
    '機　能：不良ｸﾞﾘｯﾄの入力制限設定
    '引　数：Row：変更行
    '　　　：Col：変更列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/20 (Fri) 13:45:27 T.Kitagawa
    '更新日：2004/08/20 (Fri) 13:45:27
    '備　考：
    Private Sub vsfScrap_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfScrap.SetupEditor

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfScrap.Rows.Count <= vsfScrap.Rows.Fixed Then
                Return
            End If


            '@固定行の場合はｽｷｯﾌﾟ
            If e.Row < vsfScrap.Rows.Fixed Then
                e.Cancel = True
                Exit Sub
            End If
            
            '@編集項目以外はｽｷｯﾌﾟ
            If e.Col <> CMlngvsfScrapChipNum Then
                e.Cancel = True
                Exit Sub
            End If

            '@最大入力文字数の設定
            '@5ﾊﾞｲﾄ迄入力可能
            Dim tb As TextBox = CType(vsfScrap.Editor, TextBox)
            tb.MaxLength = CMlngInputByte

            '@変更前文字列を取得
            mstrBeforeScrapEditString = vsfScrap.GetData(e.Row, e.Col)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfScrap_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfScrap_Click
    '機　能：不良ｸﾞﾘｯﾄの使用可能設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/28 (Tue) 17:01:15 S.Deguchi
    '更新日：2004/12/28 (Tue) 17:01:15
    '備　考：
    Private Sub vsfScrap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfScrap.Click

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfScrap.Rows.Count <= vsfScrap.Rows.Fixed Then
                Return
            End If

            '@ﾍｯﾀﾞｰｸﾘｯｸの場合
            If vsfScrap.MouseRow = 0 Then
                Exit Sub
            End If

            '@描画ﾌﾗｸﾞがTrueの場合
            If mblnScrapDrawFlag = True Then
                '@固定行の場合はｽｷｯﾌﾟ
                If vsfScrap.Row < vsfScrap.Rows.Fixed Then
                    Exit Sub
                End If
                
                With vsfScrap
                    '選択行を退避
                    lpreRow = .Row
                    If .Col = CMlngvsfScrapChipNum Then
                        'ハイライトを消す
                        .HighLight = HighLightEnum.Never
                        '@編集を許可
                        .Styles.Editor.BackColor = SystemColors.Window
                        .Styles.Editor.ForeColor = SystemColors.WindowText
                        .StartEditing()
                    Else
                        .HighLight = HighLightEnum.WithFocus
                        .AllowEditing = False
                    End If
                End With
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfScrap_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfScrap_RowColChange
    '機　能：要因ｸﾞﾘｯﾄﾞ編集制御
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/12 (Mon) 15:00:27 N.Kojima
    '更新日：2005/12/12 (Mon) 15:00:27
    '備　考：ｶｰｿﾙｷｰで数量欄にﾌｫｰｶｽを当てた際、入力が出来るようにする為の制御。
    Private Sub vsfScrap_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfScrap.RowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfScrap.Rows.Count <= vsfScrap.Rows.Fixed Then
                Return
            End If

            '@ﾍｯﾀﾞｰｸﾘｯｸの場合
            If vsfScrap.MouseRow = 0 Then
                Exit Sub
            End If

            '@描画ﾌﾗｸﾞがTrueの場合
            If mblnScrapDrawFlag = True Then
                '@固定行の場合はｽｷｯﾌﾟ
                If vsfScrap.Row < vsfScrap.Rows.Fixed Then
                    Exit Sub
                End If
                
                With vsfScrap
                    '選択行を退避
                    lpreRow = .Row
                    If .Col = CMlngvsfScrapChipNum Then
                        'ハイライトを消す
                        .HighLight = HighLightEnum.Never
                        '@編集を許可
                        .Styles.Editor.BackColor = SystemColors.Window
                        .Styles.Editor.ForeColor = SystemColors.WindowText
                        .StartEditing()
                    Else
                        .HighLight = HighLightEnum.WithFocus
                        .AllowEditing = False
                    End If
                End With
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfScrap_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfScrap_ValidateEdit
    '機　能：不良ｸﾞﾘｯﾄの変更処理
    '引　数：Row：変更行
    '　　　：Col：変更列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/12 (Mon) 11:30:32 T.Kitagawa
    '更新日：2005/11/09 (Wed) 15:51:07 T.Kitagawa
    '備　考：2005/11/09 (Wed) 15:51:07 T.Kitagawa　現在数量ﾁｪｯｸを外す(ﾕｰｻﾞ要望№0073)
    Private Sub vsfScrap_ValidateEdit(ByVal sender As Object, ByVal e As ValidateEditEventArgs) Handles vsfScrap.ValidateEdit

        Dim llngCnt         As Integer  'ｶｳﾝﾀ
        Dim llngScrapNum    As Integer  '不良数量

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfScrap.Rows.Count <= vsfScrap.Rows.Fixed Then
                Return
            End If
            
            '@固定行の場合はｽｷｯﾌﾟ
            If e.Row < vsfScrap.Rows.Fixed Then
                Exit Sub
            End If
            
            '@入力ﾁｪｯｸ
            With vsfScrap
                '@数値か否かのﾁｪｯｸ
                If IsNumeric(.Editor.Text) = True Then
                    '@Long型へ変換
                    If CLng(.Editor.Text) >= 0 Then
                        '@不良数量の計算
                        llngScrapNum = 0            '不良入力合計数量(初期化)

                        For llngCnt = 1 To .Rows.Count - 1
                            '@ｸﾞﾘｯﾄﾞに表示されている情報から合計数量を計算する
                            If llngCnt = e.Row Then
                                '@不良入力合計数量の加算
                                llngScrapNum = llngScrapNum + CLng(.Editor.Text)
                            Else
                                If IsNumeric(.GetData(llngCnt, CMlngvsfScrapChipNum)) = True Then
                                    '@不良入力合計数量の加算
                                    llngScrapNum = llngScrapNum + CLng(.GetData(llngCnt, CMlngvsfScrapChipNum))
                                End If
                            End If
                        Next llngCnt

                        '@良品数量の計算結果からﾏｲﾅｽの場合にﾒｯｾｰｼﾞを表示する
                        '@残数確認
                        If mlngChipNomalCnt < llngScrapNum Then
                            .Editor.Text = mstrBeforeScrapEditString
                            '@"<TRM4SW>$$数量には良品数より小さい値を入力してください。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004S)
                            '@警告ﾒｯｾｰｼﾞ
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@入力した情報を反映させない
                            e.Cancel = True
                        Else
                            '@入力した情報を反映させる
                            e.Cancel = False

                            '@ﾌﾗｸﾞをTrueに設定
                            mblnScrapAfterEditFlag = True
                        End If
                    Else
                        '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                        '@警告ﾒｯｾｰｼﾞ
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@入力した情報を反映させない
                        e.Cancel = True
                        
                        Exit Sub
                    End If
                Else
                    '@入力欄が空欄以外の場合
                    If Trim(.Editor.Text) <> vbNullString Then
                        .Editor.Text = mstrBeforeScrapEditString
                        '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                        '@警告ﾒｯｾｰｼﾞ
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@入力した情報を反映させない
                        e.Cancel = True
                        
                        Exit Sub
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfScrap_ValidateEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSlotUp_Click
    '機　能：ｽﾛｯﾄ数ｸﾞﾘｯﾄﾞの前頁改行処理
    '引　数：なし
    '戻り値：
    '作成日：2004/10/29 (Fri) 09:08:20 S.Deguchi
    '更新日：2004/10/29 (Fri) 09:08:20
    '備　考：なし
    Private Sub cmdSlotUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSlotUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@前頁処理▲
            Call pubVsfCmdUp(vsfPaletteSlotMap, cmdSlotUp, cmdSlotDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSlotUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSlotDown_Click
    '機　能：ｽﾛｯﾄ数ｸﾞﾘｯﾄﾞの次頁改行処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/29 (Fri) 09:08:26 S.Deguchi
    '更新日：2004/10/29 (Fri) 09:08:26
    '備　考：
    Private Sub cmdSlotDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSlotDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@次頁処理▼
            Call pubVsfCmdDown(vsfPaletteSlotMap, cmdSlotUp, cmdSlotDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSlotDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdReworkUP_Click
    '機　能：前頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/19 (Tue) 18:30:50 M.Miura
    '更新日：2004/10/19 (Tue) 18:30:50
    '備　考：
    Private Sub cmdReworkUP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdReworkUP.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@前頁処理▲
            Call pubVsfCmdUp(vsfRework, cmdReworkUP, cmdReworkDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdReworkUP_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdReworkDown_Click
    '機　能：次頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/19 (Tue) 18:34:42 M.Miura
    '更新日：2004/10/19 (Tue) 18:34:42
    '備　考：
    Private Sub cmdReworkDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdReworkDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@次頁処理▼
            Call pubVsfCmdDown(vsfRework, cmdReworkUP, cmdReworkDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdReworkDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdScrapUP_Click
    '機　能：前頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/19 (Tue) 18:35:54 M.Miura
    '更新日：2004/10/19 (Tue) 18:35:54
    '備　考：
    Private Sub cmdScrapUP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdScrapUP.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@前頁処理▲
            Call pubVsfCmdUp(vsfScrap, cmdScrapUp, cmdScrapDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdScrapUP_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdScrapDown_Click
    '機　能：次頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/19 (Tue) 18:36:13 M.Miura
    '更新日：2004/10/19 (Tue) 18:36:13
    '備　考：
    Private Sub cmdScrapDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdScrapDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@次頁処理▼
            Call pubVsfCmdDown(vsfScrap, cmdScrapUp, cmdScrapDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdScrapDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                                      *関数の記述*
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：prvfrmxxCM00B0_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 18:43:04 T.Kitagawa
    '更新日：2008/06/10 (Tue) 12:58:33 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 10:40:43 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理追加
    '　　　：2004/10/20 (Wed) 09:44:15 M.Miura　    頁切替えﾎﾞﾀﾝの無効制御追加
    '　　　：2004/10/29 (Fri) 11:28:37 S.Deguchi    ﾊﾟﾚｯﾄのｽﾛｯﾄﾏｯﾌﾟ追加/ﾁｯﾌﾟの数量表示をﾗﾍﾞﾙへ変更
    '　　　：2005/11/09 (Wed) 16:03:26 T.Kitagawa   不良数ﾃｷｽﾄBOX追加(ﾕｰｻﾞ要望№0073)
    '　　　：2008/06/10 (Tue) 12:58:33 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxCM00B0_Init()
        
        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lstrFormTitle           As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00H0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@ﾛｯﾄ情報取得時のｷｬﾘｱID退避情報を初期化
            mstrTaihiCarrierID = vbNullString                           'CKI数量取得情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)

            '@AfterEditﾌﾗｸﾞの初期化
            mblnReworkAfterEditFlag = False                             'ﾘﾜｰｸ
            mblnScrapAfterEditFlag = False                              '不良

            '@描画ﾌﾗｸﾞの初期化
            mblnReworkDrawFlag = False                                  'ﾘﾜｰｸ
            mblnScrapDrawFlag = False                                   '不良

            '@WP_TYPE退避領域の初期化
            mstrWPTYPE = vbNullString
            
            '@各ﾎﾞﾀﾝの初期化
            cmdRegist.Enabled = False                                   '確定ﾎﾞﾀﾝ
            cmdClear.Enabled = False                                    '全取消ﾎﾞﾀﾝ
            
            '@各ｺﾝﾄﾛｰﾙを初期化
            lblLotID.Text = vbNullString                                'ﾛｯﾄID
            lblFlowClass.Text = vbNullString                            '流動区分
            lblWFNo.Text = vbNullString                                 'WF枚数
            lblOpID.Text = vbNullString                                 '大工程ID
            lblStartDayTime.Text = vbNullString                         '開始日時
            lblPdID.Text = vbNullString                                 '機種
            lblS.Text = vbNullString                                    '特殊特性
            lblStatus.Text = vbNullString                               '状態
            lblStepID.Text = vbNullString                               '小工程ID
            lblLotManager.Text = vbNullString                           'ﾛｯﾄ担当
            lblTimeLimit.Text = vbNullString                            '時間制約
            lblReworkCount.Text = vbNullString                          'ﾘﾜｰｸ回数
            lblChipNormalNum.Text = vbNullString                        '良品数
            lblReworkNum.Text = vbNullString                            'ﾘﾜｰｸ数
            lblScrapNum.Text = vbNullString                             '不良数

            txtScrap.Text = vbNullString                                '不良数(ﾃｷｽﾄBOX)
            
            '@ｸﾞﾘｯﾄ領域の初期化

            '@ﾊﾟﾚｯﾄのｽﾛｯﾄ情報
            With vsfPaletteSlotMap

                '@ﾀｲﾄﾙの設定
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfPSlotTitle, CMlngvsfPSlotTitle, CMlngvsfPSlotTitle, .Cols.Count - 1)
                headerStyle.ForeColor = Color.Yellow
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                '@ﾌｫﾝﾄｻｲｽﾞ設定
                With .Font
                    headerStyle.Font = New Font(.FontFamily, CMlngGridHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                headerStyle.Trimming = StringTrimming.None              'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle
                .Rows(CMlngvsfPSlotTitle).Height = CMlngGridTitleHeight '高さ

                'NSYS ｽﾛｯﾄ№設定
                .Cols(CMlngvsfPSlotNum).Style.Font = New Font(.Font.FontFamily, CType(CMlngGridHFontSize, Single), .Font.Style)
                .Cols(CMlngvsfPSlotNum).TextAlign = TextAlignEnum.RightCenter

                .Row = -1

                '@行数の初期設定
                .Rows.Count = 19
                For llngCnt = CMlngvsfPSlotMinRow To CMlngvsfPSlotMaxRow
                    .Rows(llngCnt).Height = CMlngGridRowHeight
                    .SetData(llngCnt, CMlngvsfPSlotNum, CStr(Format$(llngCnt, CPstrSlotNoFormat)))
                    .SetData(llngCnt, CMlngvsfPSlotID, vbNullString)
                    .SetData(llngCnt, CMlngvsfPSlotThicknessCode, vbNullString)
                    .SetCellCheck(llngCnt, CMlngvsfPSlotReworkCheck, 0)
                    .SetCellCheck(llngCnt, CMlngvsfPSlotScrapCheck, 0)
                    .SetData(llngCnt, CMlngvsfPSlotReworkCheck, vbNullString)
                    .SetData(llngCnt, CMlngvsfPSlotScrapCheck, vbNullString)
                Next llngCnt
                
                '行の初期化時には背景色を白設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                Dim cellRange1 As CellRange = .GetCellRange(CMlngvsfPSlotMinRow, CMlngvsfPSlotID, CMlngvsfPSlotMaxRow, .Cols.Count - 1)
                cellRange1.Style = newStyle
                
                '@ｸﾞﾘｯﾄﾞﾛｯｸ
                .Enabled = False
            End With
            
            '@ﾘﾜｰｸ数情報
            With vsfRework
                
                '@ﾀｲﾄﾙの設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed

                lFixedStyle.ForeColor = Color.Yellow                                 '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)    '背景色
                'ﾌｫﾝﾄｻｲｽﾞ設定
                With .Font
                    lFixedStyle.Font = New Font(.FontFamily, CMlngGridHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                lFixedStyle.Trimming = StringTrimming.None               'NSYS ﾍｯﾀﾞは省略表示なしに設定
                .Rows(CMlngvsfReworkTitle).Height = CMlngGridTitleHeight '高さ

                '@行数の初期設定
                .Rows.Count = 1
                
                '@ｸﾞﾘｯﾄﾞﾛｯｸ
                .Enabled = False
            End With
                
            '@不良数情報
            With vsfScrap
                
                '@ﾀｲﾄﾙの設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed

                lFixedStyle.ForeColor = Color.Yellow                                 '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)    '背景色
                'ﾌｫﾝﾄｻｲｽﾞ設定
                With .Font
                    lFixedStyle.Font = New Font(.FontFamily, CMlngGridHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                lFixedStyle.Trimming = StringTrimming.None              'NSYS ﾍｯﾀﾞは省略表示なしに設定
                .Rows(CMlngvsfScrapTitle).Height = CMlngGridTitleHeight '高さ
                
                '@行数の初期設定
                .Rows.Count = 1
            
                '@ｸﾞﾘｯﾄﾞﾛｯｸ
                .Enabled = False
            End With
            
            '@数量のｸﾘｱ
            mlngChipReworkInputSumNum = 0       'ﾘﾜｰｸ入力数
            mlngChipScrapInputSumNum = 0        '不良入力数
            mlngChipNomalCnt = 0                '良品数
            mlngChipTxtScrapInputNum = 0        '不良入力数(ﾃｷｽﾄBOX)
                
            '@頁切替えﾎﾞﾀﾝを無効
            cmdSlotUp.Enabled = False
            cmdSlotDown.Enabled = False
            cmdReworkUP.Enabled = False
            cmdReworkDown.Enabled = False
            cmdScrapUp.Enabled = False
            cmdScrapDown.Enabled = False
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00B0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM00B0_Clear
    '機　能：画面のｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 10:04:38 T.Kitagawa
    '更新日：2005/11/09 (Wed) 16:19:16 T.Kitagawa
    '備　考：2004/10/20 (Wed) 09:43:34 M.Miura　    頁切替えﾎﾞﾀﾝの無効制御追加
    '　　　：2004/10/29 (Fri) 14:36:11 S.Deguchi    画面変更による対応追加
    '　　　：2005/05/11 (Wed) 14:01:25 N.Kojima     TPALが入力された場合は、描画してないのでﾊﾟﾚｯﾄﾏｯﾌﾟのｸﾘｱ処理をｽｷｯﾌﾟする。(不具合№718)
    '　　　：2005/11/09 (Wed) 16:19:16 T.Kitagawa   不良数ﾃｷｽﾄBOX追加(ﾕｰｻﾞ要望№0073)
    Private Sub prvfrmxxCM00B0_Clear()

        Dim llngCnt                 As Integer                              'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            
            '@各ﾎﾞﾀﾝの初期化
            cmdRegist.Enabled = False                                       '確定ﾎﾞﾀﾝ
            cmdClear.Enabled = False                                        '全取消ﾎﾞﾀﾝ
            
            '@AfterEditﾌﾗｸﾞの初期化
            mblnReworkAfterEditFlag = False                                 'ﾘﾜｰｸ
            mblnScrapAfterEditFlag = False                                  '不良
            
            txtScrap.Text = vbNullString                                    '不良数(ﾃｷｽﾄBOX)
            
            '@ﾜｰｸ/不良の数量情報のｸﾘｱ
            mlngChipReworkInputSumNum = 0                                   'ﾘﾜｰｸ数
            mlngChipScrapInputSumNum = 0                                    '不良数
            mlngChipTxtScrapInputNum = 0                                    '不良入力数(ﾃｷｽﾄBOX)
            
            '@数量設定を初期化する(良品数はそのまま)
            lblChipNormalNum.Text = mlngChipNomalCnt                        '良品数
            lblReworkNum.Text = mlngChipReworkInputSumNum                   'ﾘﾜｰｸ数
            lblScrapNum.Text = mlngChipScrapInputSumNum                     '不良
            
            '@ｸﾞﾘｯﾄ領域のｸﾘｱ
            '@入力ｷｬﾘｱ(ﾛｯﾄ)がTPALかの判定(採番ﾙｰﾙにより頭2文字が"TP"の場合)
            If Trim$(Strings.Left(lblLotID.Text, 2)) <> CMstrTPAL Then
            
                '@ﾊﾟﾚｯﾄのｽﾛｯﾄﾏｯﾌﾟ情報
                With vsfPaletteSlotMap
                    
                    '@ｽﾛｯﾄﾏｯﾌﾟのﾁｪｯｸのみをはずす
                    For llngCnt = CMlngvsfPSlotMinRow To CMlngvsfPSlotMaxRow
                        '@ﾊﾟﾚｯﾄIDが空欄ではないｽﾛｯﾄの情報をｸﾘｱ
                        If .GetData(llngCnt, CMlngvsfPSlotID) <> vbNullString Then
                            .SetCellCheck(llngCnt, CMlngvsfPSlotReworkCheck, CheckEnum.Unchecked)     'ﾘﾜｰｸ(=ﾁｪｯｸ未)
                            .SetCellCheck(llngCnt, CMlngvsfPSlotScrapCheck, CheckEnum.Unchecked)      '不良(=ﾁｪｯｸ未)
                        End If
                    Next llngCnt
                    
                    '@頁先頭行が一覧先頭行の場合
                    If .TopRow = .Rows.Fixed Then
                        '@ﾛｯｸ
                        cmdSlotUp.Enabled = False
                    Else
                        '@ﾛｯｸ解除
                        cmdSlotUp.Enabled = True
                    End If
                    
                    '@最終行が表示頁にある場合
                    If .TopRow + CMlngvsfPSlotPageRows >= .Rows.Count Then
                        '@ﾛｯｸ
                        cmdSlotDown.Enabled = False
                    Else
                        '@ﾛｯｸ解除
                        cmdSlotDown.Enabled = True
                    End If
            
                End With
                
            End If
            
            '@ﾘﾜｰｸ数情報
            With vsfRework
                '@ﾘﾜｰｸ数量のｸﾘｱ
                For llngCnt = 1 To .Rows.Count - 1
                    .SetData(llngCnt, CMlngvsfReworkChipNum, vbNullString)
                Next llngCnt
                If .Rows.Count > 1 Then
                    .Row = 1
                    .ShowCell(.Row, CMlngvsfReworkChipNum)
                End If
            
                '@頁先頭行が一覧先頭行の場合
                If .TopRow <= .Rows.Fixed Then
                    '@ﾛｯｸ
                    cmdReworkUP.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdReworkUP.Enabled = True
                End If
                
                '@最終行が表示頁にある場合
                If .TopRow + CMlngvsfReworkPageRows >= .Rows.Count Then
                    '@ﾛｯｸ
                    cmdReworkDown.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdReworkDown.Enabled = True
                End If
            End With
            
            '@不良数情報
            With vsfScrap
                '@不良数量のｸﾘｱ
                For llngCnt = 1 To .Rows.Count - 1
                    .SetData(llngCnt, CMlngvsfScrapChipNum, vbNullString)
                Next llngCnt
                
                If .Rows.Count > 1 Then
                    .Row = 1
                    .ShowCell(.Row, CMlngvsfScrapChipNum)
                End If
                
                '@頁先頭行が一覧先頭行の場合
                If .TopRow <= .Rows.Fixed Then
                    '@ﾛｯｸ
                    cmdScrapUp.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdScrapUp.Enabled = True
                End If
                
                '@最終行が表示頁にある場合
                If .TopRow + CMlngvsfScrapPageRows >= .Rows.Count Then
                    '@ﾛｯｸ
                    cmdScrapDown.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdScrapDown.Enabled = True
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00B0_Clear"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM00B0_Disp
    '機　能：ﾛｯﾄ情報の画面表示処理
    '引　数：ltypLotCfkinuminfo：CFKI数量取得構造体
    '　　　：ltypLotCfkilotinfo：CFKIﾛｯﾄ情報取得構造体
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 17:42:12 T.Kitagawa
    '更新日：2008/06/10 (Tue) 13:00:09 N.Kojima
    '備　考：
    '　　　：2004/09/15 (Wed) 18:58:08 N.Kasai　    数量表示をﾊﾟﾚｯﾄ数からﾁｯﾌﾟ数表示へ変更
    '　　　：2004/10/29 (Fri) 14:36:11 S.Deguchi    画面変更による対応追加
    '　　　：2004/12/28 (Tue) 13:00:24 S.Deguchi    ｽﾛｯﾄﾏｯﾌﾟが存在しない場合もあり得る為,その対応を追加
    '　　　：2005/01/17 (Mon) 09:12:56 S.Deguchi    ｽﾛｯﾄﾎﾟｼﾞｼｮﾝからﾏｯﾌﾟ作成する処理を追加(処理漏れ)
    '　　　：2005/03/01 (Tue) 14:49:22 S.Deguchi    不具合№261の対応でWP_TYPEを退避領域へ格納する処理を追加
    '　　　：2005/05/11 (Wed) 16:36:18 N.Kojima     ﾛｯﾄ状態により、処理開始予定・処理開始日時の表示を分ける。(SCH対応)
    '　　　：2005/11/09 (Wed) 16:28:00 T.Kitagawa   不良数ﾃｷｽﾄBOX追加(ﾕｰｻﾞ要望№0073)
    '　　　：2006/06/08 (Thu) 14:27:41 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/10 (Tue) 13:00:09 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxCM00B0_Disp(ByRef ltypLotCfkinuminfo As LotCfkinuminfo, ByRef ltypLotCfkiLotInfo As LotCfkiLotinfo)

        Try
            
            '@ﾛｯﾄ情報の表示
            With ltypLotCfkinuminfo
                lblLotID.Text = .strLotID                                        'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                '流動区分
                lblWFNo.Text = .strChipQuantity                                  'ﾁｯﾌﾟ数量
                lblStatus.Text = .strNowST                                       '状態
                lblOpID.Text = .strOpID                                          '大工程名
                lblStepID.Text = .strStepID                                      '小工程名
                
                '@ﾛｯﾄ状態
                Select Case .strNowST
                    '@「作業待ち」「前処理」の場合
                    Case CPstrWaitWorkSt, CPstrBeforeProgressSt
                        '@日付ﾀｲﾄﾙ設定「処理開始予定」
                        lblStartTime.Text = CPstrDispatchTime
                    '@その他
                    Case Else
                        '@日付ﾀｲﾄﾙ設定「処理開始日時」
                        lblStartTime.Text = CPstrStartTime
                End Select
                '@開始日時(作業待ち,前処理の場合はDispatchStartTime、処理中,後処理の場合はStartTimeが入る)
                If IsDate(.strStartTime) = True Then
                    lblStartDayTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat)
                End If
                
                lblLotManager.Text = .strEngEmpName                                 'ﾛｯﾄ担当
                lblPdID.Text = ltypLotCfkiLotInfo.strPdId                           '機種
                lblReworkCount.Text = ltypLotCfkiLotInfo.strReworkCount             'ﾘﾜｰｸ回数
                lblS.Text = .strSpecialFlg                                          '特殊特性
                
                mstrLotLastUpdate = .strLotLastUpdate                               'ﾛｯﾄ最終更新日時
                mstrWPTYPE = .strWPType                                             'WP_TYPE
                
                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then
                    '@時間制約がﾌﾟﾗｽの場合
                    If CLng(.strLimitTime) >= 0 Then
                        
                        '@制限時間以下or処理時間制限以下の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@制限時間先大工程+制限時間先小工程+制限時間
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(CLng(.strLimitTime), "##,##0") & CPstrh
                            '@右寄せ
                            lblTimeLimit.TextAlign = ContentAlignment.TopRight
                            
                            '@警告時間が設定されている場合
                            If .strWarnTime <> vbNullString Then
                                '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                If CLng(.strWarnTime) < 0 And CLng(.strLimitTime) >= 0 Then
                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)     '紫色
                                Else
                                     '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                    lblTimeLimit.ForeColor = Color.Black                '黒
                                End If
                            End If
                        End If
                        
                    Else
                    '@制限時間がﾏｲﾅｽの場合
                        '@制限時間先大工程+制限時間先小工程+制限時間
                        '@右寄せ
                        lblTimeLimit.TextAlign = ContentAlignment.TopRight
                        '@ForColorの変更
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)                    '赤色
                        
                        '@制限時間以下or処理時間制限以下の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(CLng(.strLimitTime), "##,##0") & CPstrh
                        End If
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Replace(Format(CLng(.strLimitTime), "##,##0"), _
                                                           CPstrReplaceMinus, vbNullString) _
                                                 & CPstrh
                        End If
                    End If
                End If

                '@数量設定
                '@ﾌｫｰﾑ起動区分が自ﾌｫｰﾑ起動の場合は数量を再設定する
                If pblnfrmxxCM00B0Kbn = False Then
                    '@件数の設定
                    mlngChipNomalCnt = ltypLotCfkinuminfo.strChipQuantity               '内部変数へｾｯﾄ
                    lblChipNormalNum.Text = Format$(mlngChipNomalCnt, "#,##0")          '良品
                    lblReworkNum.Text = CPstrZero                                       'ﾘﾜｰｸ(初期設定)
                    lblScrapNum.Text = CPstrZero                                        '不良(初期設定)
                    txtScrap.Text = vbNullString                                        '不良数(初期設定)
                Else
                    '@連携情報からｾｯﾄ
                    mlngChipNomalCnt = ptypCfkiRenkeiInfo.lngChipRemainCount            '内部変数へｾｯﾄ
                    lblChipNormalNum.Text = Format$(mlngChipNomalCnt, "#,##0")          '良品
                    lblReworkNum.Text = CPstrZero                                       'ﾘﾜｰｸ(初期設定)
                    lblScrapNum.Text = CPstrZero                                        '不良(初期設定)
                    txtScrap.Text = vbNullString                                        '不良数(初期設定)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00B0_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblncmdRegistEnabled_Chk
    '機　能：確定ﾎﾞﾀﾝの活性化ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/29 (Fri) 13:25:27 S.Deguchi
    '更新日：2005/11/09 (Wed) 16:37:10 T.Kitagawa
    '備　考：
    '　　　：2005/01/18 (Tue) 14:56:54 S.Deguchi    処理見直し(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸが存在しない場合の処理を追加)
    '　　　：2005/11/09 (Wed) 16:37:10 T.Kitagawa   ﾘﾜｰｸも不良管理とし、要因で切分けする(ﾕｰｻﾞ要望№0073)
    Private Function prvblncmdRegistEnabled_Chk() As Boolean

        Dim llngCnt             As Integer  'ｶｳﾝﾄ
        Dim llngPaletteNum      As Integer  'ﾊﾟﾚｯﾄ数量
        Dim llngReworkChk       As Integer  'ﾘﾜｰｸ数量
        Dim llngScrapChk        As Integer  '不良数量
        Dim llngChkNum          As Integer  'ﾁｪｯｸﾄｰﾀﾙ数量
        Dim lblnRWOKFlag        As Boolean  'ﾘﾜｰｸ処理
        Dim lblnSCOKFlag        As Boolean  '不良処理

        Try
            
            '@初期化
            prvblncmdRegistEnabled_Chk = False
            llngPaletteNum = 0
            llngReworkChk = 0
            llngScrapChk = 0
            lblnRWOKFlag = True
            lblnSCOKFlag = True
            
            '@**************************************************
            '@確定ﾎﾞﾀﾝが押せる条件
            '@①ﾘﾜｰｸの数量が入力された場合
            '@②不良の数量が入力された場合
            '@③ｽﾛｯﾄでﾘﾜｰｸにﾁｪｯｸ＆ﾘﾜｰｸ数量入力の場合
            '@④ｽﾛｯﾄで不良にﾁｪｯｸ＆不良数量入力の場合
            '@⑤ｽﾛｯﾄ全ﾁｪｯｸ＆ﾘﾜｰｸ/不良の合計が良品数の場合
            '@⑥不良数＋ﾘﾜｰｸ合計数が要因合計数の場合
            '@**************************************************
           
            '@ｽﾛｯﾄﾏｯﾌﾟ状況のﾁｪｯｸ
            With vsfPaletteSlotMap
                '@ｽﾛｯﾄﾏｯﾌﾟ状況取得
                For llngCnt = 1 To .Rows.Count - 1
                    '@ﾊﾟﾚｯﾄIDは存在する数を取得
                    If .GetData(llngCnt, CMlngvsfPSlotID) <> vbNullString Then
                        llngPaletteNum = llngPaletteNum + 1
                    End If
                    
                    '@ﾘﾜｰｸﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸが入っている数を取得
                    If .GetCellCheck(llngCnt, CMlngvsfPSlotReworkCheck) = CheckEnum.Checked Then
                        llngReworkChk = llngReworkChk + 1
                    End If
                    
                    '@不良ﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸが入っている数を取得
                    If .GetCellCheck(llngCnt, CMlngvsfPSlotScrapCheck) = CheckEnum.Checked Then
                        llngScrapChk = llngScrapChk + 1
                    End If
                Next llngCnt
                '@ﾁｪｯｸ数量とｽﾛｯﾄﾏｯﾌﾟの状況
                llngChkNum = llngReworkChk + llngScrapChk
            End With
           
           '@確定ﾎﾞﾀﾝﾁｪｯｸの判断(ﾁｪｯｸ数量)
            Select Case llngChkNum
                Case 0
                    '@ひとつもｽﾛｯﾄにﾁｪｯｸが入っていない場合
                    '@ﾘﾜｰｸ数量が設定されている場合
                    If lblReworkNum.Text <> CPstrZero Then
                        '@処理OK
                        prvblncmdRegistEnabled_Chk = True
                    Else
                        '@不良数量が設定されている場合
                        If lblScrapNum.Text <> CPstrZero Then
                            '@処理OK
                            prvblncmdRegistEnabled_Chk = True
                        Else
                            '@処理NG
                            prvblncmdRegistEnabled_Chk = False
                        End If
                    End If
            Case Else
                '@上記以外
                '@ﾘﾜｰｸﾁｪｯｸの状況による処理分岐
                Select Case llngReworkChk
                    Case 0
                    '@ﾘﾜｰｸﾁｪｯｸが0の場合(無条件許可)
                    
                    Case Else
                        '@ﾘﾜｰｸﾁｪｯｸが0以外の場合
                        '@ﾘﾜｰｸﾁｪｯｸが0以外なのに数量が入力されていない場合
                        If lblReworkNum.Text = CPstrZero Then
                            '@処理NG
                            lblnRWOKFlag = False
                        End If
                End Select
                
                '@不良ﾁｪｯｸの状況による処理分岐
                Select Case llngScrapChk
                    Case 0
                    '@不良ﾁｪｯｸが0の場合(無条件許可)
                    
                    Case Else
                    '@不良ﾁｪｯｸが0以外の場合
                        '@不良ﾁｪｯｸが0以外なのに数量が入力されていない場合
                        If mlngChipTxtScrapInputNum = 0 Then
                            '@処理NG
                            lblnSCOKFlag = False
                        End If
                End Select
                    
                '@数量による処理分岐(ﾘﾜｰｸ/不良のﾁｪｯｸ数と数量入力状況)
                If lblnRWOKFlag = True And lblnSCOKFlag = True Then
                    '@処理OK
                    prvblncmdRegistEnabled_Chk = True
                Else
                    '@処理NG
                    prvblncmdRegistEnabled_Chk = False
                End If
            End Select

            '@不良数＋ﾘﾜｰｸ合計＝要因合計かﾁｪｯｸ
            If prvblncmdRegistEnabled_Chk = True Then
                If (mlngChipTxtScrapInputNum + lblReworkNum.Text) = lblScrapNum.Text Then
                    '@処理OK
                    prvblncmdRegistEnabled_Chk = True
                Else
                    '@処理NG
                    prvblncmdRegistEnabled_Chk = False
                End If
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblncmdRegistEnabled_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblncmdClearEnabled_Chk
    '機　能：取り消しﾎﾞﾀﾝの活性化ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/29 (Fri) 15:48:40 S.Deguchi
    '更新日：2005/11/09 (Wed) 17:39:13 T.Kitagawa
    '備　考：
    '　　　：2004/12/28 (Tue) 13:08:53 S.Deguchi    ｽﾛｯﾄﾏｯﾌﾟが存在しない場合の処理を追加
    '　　　：2005/11/09 (Wed) 17:39:13 T.Kitagawa   不良数ﾃｷｽﾄBOX追加(ﾕｰｻﾞ要望№0073)
    Private Function prvblncmdClearEnabled_Chk() As Boolean

        Dim llngCnt             As Integer  'ｶｳﾝﾄ
        Dim lblnEnabledPSFlag   As Boolean  'ﾌﾗｸﾞ処理(ｽﾛｯﾄ)
        Dim lblnEnabledRWFlag   As Boolean  'ﾌﾗｸﾞ処理(ﾘﾜｰｸ)
        Dim lblnEnabledSCFlag   As Boolean  'ﾌﾗｸﾞ処理(不良)

        Try
            
            '@初期化
            prvblncmdClearEnabled_Chk = False
            lblnEnabledPSFlag = False
            lblnEnabledRWFlag = False
            lblnEnabledSCFlag = False
            
            '@ｽﾛｯﾄのﾁｪｯｸ有無判別
            With vsfPaletteSlotMap
                '@ｽﾛｯﾄﾏｯﾌﾟに情報が存在する場合
                If .Enabled = True Then
                    For llngCnt = 1 To .Rows.Count - 1
                        '@ﾁｪｯｸ状態でひとつでも入っていれば処理を終了する
                        '@ﾘﾜｰｸﾁｪｯｸ
                        If .GetCellCheck(llngCnt, CMlngvsfPSlotReworkCheck) = CheckEnum.Checked Then
                            '@処理OKﾌﾗｸﾞ
                            lblnEnabledPSFlag = True
                            
                            Exit For
                        Else
                            '@ﾁｪｯｸ状態でひとつでも入っていれば処理を終了する
                            '@不良ﾁｪｯｸ
                            If .GetCellCheck(llngCnt, CMlngvsfPSlotScrapCheck) = CheckEnum.Checked Then
                                '@処理OKﾌﾗｸﾞ
                                lblnEnabledPSFlag = True
                                
                                Exit For
                            End If
                        End If
                    Next
                End If
            End With
                    
            '@ﾘﾜｰｸ
            With vsfRework
                For llngCnt = 1 To .Rows.Count - 1
                    '@一つでも空欄以外がある場合には処理を終了する
                    If .GetData(llngCnt, CMlngvsfReworkChipNum) <> vbNullString Then
                        '@処理OKﾌﾗｸﾞ
                        lblnEnabledRWFlag = True
                        
                        Exit For
                    End If
                Next llngCnt
            End With
            
            '@不良
            With vsfScrap
                For llngCnt = 1 To .Rows.Count - 1
                    '@一つでも空欄以外がある場合には処理を終了する
                    If .GetData(llngCnt, CMlngvsfScrapChipNum) <> vbNullString Then
                        '@処理OKﾌﾗｸﾞ
                        lblnEnabledSCFlag = True
                        
                        Exit For
                    End If
                Next llngCnt
            End With
            
            '@ﾁｪｯｸ結果返信(一つでもOKﾌﾗｸﾞが立っている場合に結果OKを返す)
            If lblnEnabledPSFlag = True Or _
                lblnEnabledRWFlag = True Or _
                lblnEnabledSCFlag = True Or _
                txtScrap.Text <> vbNullString Then
                
                '@結果OKﾌﾗｸﾞ
                prvblncmdClearEnabled_Chk = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblncmdClearEnabled_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnInput_Chk
    '機　能：確定時の入力ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2004/07/07 (Wed) 13:38:35 T.Kitagawa
    '更新日：2005/11/10 (Thu) 09:49:16 T.Kitagawa
    '備　考：
    '　　　：2005/01/18 (Tue) 15:57:26 S.Deguchi    処理見直し(ｽﾛｯﾄﾏｯﾌﾟﾁｪｯｸが存在しない場合の処理追加)
    '　　　：2005/11/10 (Thu) 09:49:16 T.Kitagawa   ﾘﾜｰｸも不良管理とし、要因で切分けする(ﾕｰｻﾞ要望№0073)
    Private Function prvblnInput_Chk() As Boolean
        
        Dim llngCnt             As Integer  'ｶｳﾝﾄ
        Dim llngPaletteNum      As Integer  'ﾊﾟﾚｯﾄ数量
        Dim llngReworkChk       As Integer  'ﾘﾜｰｸ数量
        Dim llngScrapChk        As Integer  '不良数量
        Dim llngChkNum          As Integer  'ﾁｪｯｸﾄｰﾀﾙ数量
        Dim lblnRWOKFlag        As Boolean  'ﾘﾜｰｸ処理
        Dim lblnSCOKFlag        As Boolean  '不良処理

        Try
            
            '@初期化
            prvblnInput_Chk = False
            
            llngPaletteNum = 0
            llngReworkChk = 0
            llngScrapChk = 0
            lblnRWOKFlag = True
            lblnSCOKFlag = True
            
            '@**************************************************
            '@確定ﾎﾞﾀﾝが押せる条件
            '@①ﾘﾜｰｸの数量が入力された場合
            '@②不良の数量が入力された場合
            '@③ｽﾛｯﾄでﾘﾜｰｸにﾁｪｯｸ＆ﾘﾜｰｸ数量入力の場合
            '@④ｽﾛｯﾄで不良にﾁｪｯｸ＆不良数量入力の場合
            '@⑤ｽﾛｯﾄ全ﾁｪｯｸ＆ﾘﾜｰｸ/不良の合計が良品数の場合
            '@⑥不良数＋ﾘﾜｰｸ合計数が要因合計数の場合
            '@**************************************************
           
            '@ｽﾛｯﾄﾏｯﾌﾟ状況のﾁｪｯｸ
            With vsfPaletteSlotMap
                '@ｽﾛｯﾄﾏｯﾌﾟ状況取得
                For llngCnt = 1 To .Rows.Count - 1
                    '@ﾊﾟﾚｯﾄIDは存在する数を取得
                    If .GetData(llngCnt, CMlngvsfPSlotID) <> vbNullString Then
                        llngPaletteNum = llngPaletteNum + 1
                    End If
                    
                    '@ﾘﾜｰｸﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸが入っている数を取得
                    If .GetCellCheck(llngCnt, CMlngvsfPSlotReworkCheck) = CheckEnum.Checked Then
                        llngReworkChk = llngReworkChk + 1
                    End If
                    
                    '@不良ﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸが入っている数を取得
                    If .GetCellCheck(llngCnt, CMlngvsfPSlotScrapCheck) = CheckEnum.Checked Then
                        llngScrapChk = llngScrapChk + 1
                    End If
                Next llngCnt
                '@ﾁｪｯｸ数量とｽﾛｯﾄﾏｯﾌﾟの状況
                llngChkNum = llngReworkChk + llngScrapChk
            End With
            
            '@確定ﾁｪｯｸ
            Select Case llngChkNum
                Case 0
                    '@ひとつもｽﾛｯﾄにﾁｪｯｸが入っていない場合
                    '@ﾘﾜｰｸ数量が設定されている場合
                    If lblReworkNum.Text <> CPstrZero Then
                        '@処理OK
                        prvblnInput_Chk = True
                    Else
                        '@不良数量が設定されている場合
                        If lblScrapNum.Text <> CPstrZero Then
                            '@処理OK
                            prvblnInput_Chk = True
                        Else
                            '@処理NG
                            prvblnInput_Chk = False
                            
                            '@"<TRM31W>$$登録するデータがありません。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0031)
                            '@警告ﾒｯｾｰｼﾞ
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Function
                        End If
                    End If
                
                Case Else
                    '@ｽﾛｯﾄﾁｪｯｸあり＆全数ではない
                    '@ﾘﾜｰｸﾁｪｯｸの状況による処理分岐
                    Select Case llngReworkChk
                        Case 0
                        '@ﾘﾜｰｸﾁｪｯｸが0の場合
                        
                        Case Else
                            '@ﾘﾜｰｸﾁｪｯｸが0以外の場合
                            '@ﾘﾜｰｸﾁｪｯｸが0以外なのに数量が入力されていない場合
                            If lblReworkNum.Text = CPstrZero Then
                                '@処理NG
                                lblnRWOKFlag = False
                                prvblnInput_Chk = False
                                
                                '@"<TRM4AW>$$スロット[%1]にチェックがはいっていないか､数量が設定されていません。$設定を見直してください。"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004A, lblTtl11.Text)
                                '@警告ﾒｯｾｰｼﾞ
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                Exit Function
                            End If
                    End Select
                    
                    '@不良ﾁｪｯｸの状況による処理分岐
                    Select Case llngScrapChk
                        Case 0
                            '@不良ﾁｪｯｸが0の場合
                            '@不良ﾁｪｯｸが0なのに数量が入力されている場合
                        
                        Case Else
                            '@不良ﾁｪｯｸが0以外の場合
                            '@不良ﾁｪｯｸが0以外なのに数量が入力されていない場合
                            If mlngChipTxtScrapInputNum = 0 Then
                                '@処理NG
                                lblnSCOKFlag = False
                                prvblnInput_Chk = False
                                
                                '@"<TRM4AW>$$スロット[%1]にチェックがはいっていないか､数量が設定されていません。$設定を見直してください。"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004A, lblTtl12.Text)
                                '@警告ﾒｯｾｰｼﾞ
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                Exit Function
                            End If
                    End Select
                    
                    '@上記ﾘﾜｰｸ/不良のﾁｪｯｸ通過(削除ﾁｪｯｸあり＆数量入力済み)後,良品数と比較
                    If lblnRWOKFlag = True And lblnSCOKFlag = True Then
                        If llngPaletteNum = llngChkNum Then
                            '@全てのｽﾛｯﾄにﾁｪｯｸが入っている場合
                            '@良品数が0となっている場合
                            If lblChipNormalNum.Text = CPstrZero Then
                                '@処理OK
                                prvblnInput_Chk = True
                            
                                Exit Function
                            Else
                                '@処理NG
                                prvblnInput_Chk = False
                                
                                '@"<TRM4RW>$$全てのパレットIDに削除指定が入っていますが、リワーク不良数量の合計が
                                '@$良品数と等しくなっていません。設定を見直してください。"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004R)
                                '@警告ﾒｯｾｰｼﾞ
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                Exit Function
                            End If
                        Else
                        '@全てのｽﾛｯﾄにﾁｪｯｸが入っていない場合
                            '@良品数が0となっていない場合
                            If lblChipNormalNum.Text <> CPstrZero Then
                                '@処理OK
                                prvblnInput_Chk = True
                            
                                Exit Function
                            Else
                                '@処理NG
                                prvblnInput_Chk = False
                                
                                '@"<TRM4TW>$$リワーク不良数量の合計が良品数と等しくなっていますが、全てのパレットIDに
                                '@$削除指定が入っていません。設定を見直してください。"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004T)
                                '@警告ﾒｯｾｰｼﾞ
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                Exit Function
                            End If
                        End If
                    End If
            End Select

            '@不良数＋ﾘﾜｰｸ合計＝要因合計かﾁｪｯｸ
            If prvblnInput_Chk = True Then
                If (mlngChipTxtScrapInputNum + lblReworkNum.Text) = lblScrapNum.Text Then
                    '@処理OK
                    prvblnInput_Chk = True
                    Exit Function
                Else
                    '@処理NG
                    prvblnInput_Chk = False
                    '@"<TRM7FW>$$リワーク不良数量の合計が要因合計と等しくなっていません。$設定を見直してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007F)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Exit Function
                End If
            End If
            
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

    '関数名：prvLotCfkiRework_Set
    '機　能：CFﾘﾜｰｸ変更構造体ﾃﾞｰﾀ格納
    '引　数：ltypLotCfkiRework：CFﾘﾜｰｸ変更構造体
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 14:59:44 T.Kitagawa
    '更新日：2004/07/07 (Wed) 14:59:44
    '備　考：
    '　　　：2004/10/29 (Fri) 17:16:18 S.Deguchi    ﾊﾟﾚｯﾄIDﾘｽﾄを追加
    '　　　：2005/04/01 (Fri) 15:15:51 S.Deguchi    確定処理で数量入力にｶﾝﾏ編集解除処理を追加
    Private Sub prvLotCfkiRework_Set(ByRef ltypLotCfkiRework As LotCfkiRework)
        
        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            
            '@登録構造体ﾃﾞｰﾀ格納
            With ltypLotCfkiRework
                .strLotID = lblLotID.Text                               'ﾛｯﾄID
                .strEmpID = pstrUserID                                  '作業者ID
                '@CF板厚ﾘｽﾄ情報
                .lngThicknessReworkListCnt = 0
                .typThicknessReworkList = New List(Of ThicknessReworkList)
                For llngCnt = 1 To vsfRework.Rows.Count - 1
                    If IsNumeric(vsfRework.GetData(llngCnt, CMlngvsfReworkChipNum)) = True Then
                        If vsfRework.GetData(llngCnt, CMlngvsfReworkChipNum) > 0 Then
                            '@ﾘｽﾄ件数のｶｳﾝﾄｱｯﾌﾟ
                            .lngThicknessReworkListCnt = .lngThicknessReworkListCnt + 1
                            '@構造体の格納
                            Dim typThicknessReworkListtmp = New ThicknessReworkList
                            With typThicknessReworkListtmp
                                .strThicknessCode = vsfRework.GetData(llngCnt, CMlngvsfReworkThicknessCode)    '板厚
                                .strChipNum = Format$(vsfRework.GetData(llngCnt, CMlngvsfReworkChipNum), CPstrNoKanmaFormat)                'CFﾘﾜｰｸ数量
                            End With
                            .typThicknessReworkList.Add(typThicknessReworkListtmp)
                        End If
                    End If
                Next llngCnt
                
                '@ﾊﾟﾚｯﾄIDﾘｽﾄ情報
                .lngPaletteListCnt = 0
                .typPaletteList = New List(Of PaletteList)
                For llngCnt = 1 To vsfPaletteSlotMap.Rows.Count - 1
                    '@ﾘﾜｰｸにﾁｪｯｸがついているものを抽出
                    If vsfPaletteSlotMap.GetCellCheck(llngCnt, CMlngvsfPSlotReworkCheck) = CheckEnum.Checked Then
                        '@ﾘｽﾄ件数のｶｳﾝﾄｱｯﾌﾟ
                        .lngPaletteListCnt = .lngPaletteListCnt + 1
                        '@構造体の格納
                        Dim typPaletteListtmp = New PaletteList
                        With typPaletteListtmp
                            .strPaletteID = vsfPaletteSlotMap.GetData(llngCnt, CMlngvsfPSlotID)    'ﾊﾟﾚｯﾄID
                        End With
                        .typPaletteList.Add(typPaletteListtmp)
                    End If
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLotCfkiRework_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLotCfkiScrap_Set
    '機　能：CF不良登録構造体ﾃﾞｰﾀ格納
    '引　数：ltypLotCfinsprst：CF不良登録構造体
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 15:19:12 T.Kitagawa
    '更新日：2004/07/07 (Wed) 15:19:12
    '備　考：
    '　　　：2004/10/29 (Fri) 17:16:18 S.Deguchi    ﾊﾟﾚｯﾄIDﾘｽﾄを追加
    '　　　：2005/04/01 (Fri) 15:15:51 S.Deguchi    確定処理で数量入力にｶﾝﾏ編集解除処理を追加
    Private Sub prvLotCfkiScrap_Set(ByRef ltypLotCfinsprst As LotCfinsprst)
        
        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            
            '@登録構造体ﾃﾞｰﾀ格納
            With ltypLotCfinsprst
                .strLotID = lblLotID.Text                               'ﾛｯﾄID
                .strEmpID = pstrUserID                                  '作業者ID
                '@不良ﾘｽﾄ情報
                .lngScrapListCnt = 0
                .typScrapList = New List(Of ScrapList)
                For llngCnt = 1 To vsfScrap.Rows.Count - 1
                    If IsNumeric(vsfScrap.GetData(llngCnt, CMlngvsfScrapChipNum)) = True Then
                        If vsfScrap.GetData(llngCnt, CMlngvsfScrapChipNum) > 0 Then
                            '@ﾘｽﾄ件数のｶｳﾝﾄｱｯﾌﾟ
                            .lngScrapListCnt = .lngScrapListCnt + 1
                            '@構造体の格納
                            Dim typScrapListtmp = New ScrapList
                            With typScrapListtmp
                                .strClass = CPstrClass2                                                       '不良ｸﾗｽ(2)
                                .strClassID = vsfScrap.GetData(llngCnt, CMlngvsfScrapCode)                    '項目ID(不良ｺｰﾄﾞ)
                                .strNum = Format$(vsfScrap.GetData(llngCnt, CMlngvsfScrapChipNum), CPstrNoKanmaFormat)                     'ﾁｯﾌﾟ数
                            End With
                            .typScrapList.Add(typScrapListtmp)
                        End If
                    End If
                Next llngCnt
            
                '@ﾊﾟﾚｯﾄIDﾘｽﾄ情報
                .lngPaletteListCnt = 0
                .typPaletteList = New List(Of PaletteList)
                For llngCnt = 1 To vsfPaletteSlotMap.Rows.Count - 1
                    '@不良にﾁｪｯｸがついているものを抽出
                    If vsfPaletteSlotMap.GetCellCheck(llngCnt, CMlngvsfPSlotScrapCheck) = CheckEnum.Checked Then
                        '@ﾘｽﾄ件数のｶｳﾝﾄｱｯﾌﾟ
                        .lngPaletteListCnt = .lngPaletteListCnt + 1
                        '@構造体の格納
                        Dim typPaletteListtmp = New PaletteList
                        With typPaletteListtmp
                            .strPaletteID = vsfPaletteSlotMap.GetData(llngCnt, CMlngvsfPSlotID)    'ﾊﾟﾚｯﾄID
                        End With
                        .typPaletteList.Add(typPaletteListtmp)
                    End If
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLotCfkiScrap_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvReworkScrap_Cal
    '機　能：良品/ﾘﾜｰｸ/不良数量計算
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/29 (Wed) 08:52:50 S.Deguchi
    '更新日：2005/11/10 (Thu) 10:55:16 T.Kitagawa
    '備　考：
    '　　　：2005/11/10 (Thu) 10:55:16 T.Kitagawa   ﾘﾜｰｸも不良管理とし、要因で切分けする(ﾕｰｻﾞ要望№0073)
    Private Sub prvReworkScrap_Cal()

        Dim llngCnt         As Integer  'ｶｳﾝﾀ

        Try

            '@ﾘﾜｰｸ入力ﾁｪｯｸ
            With vsfRework
                '@ﾘﾜｰｸ数量の計算
                mlngChipReworkInputSumNum = 0           'ﾘﾜｰｸ合計数量(初期化)
                
                For llngCnt = 1 To .Rows.Count - 1
                    '@ｸﾞﾘｯﾄﾞに表示されている情報から合計数量を計算する
                    If IsNumeric(.GetData(llngCnt, CMlngvsfReworkChipNum)) = True Then
                        '@ﾘﾜｰｸ表示数量の加算
                        mlngChipReworkInputSumNum = mlngChipReworkInputSumNum _
                                                  + CLng(.GetData(llngCnt, CMlngvsfReworkChipNum))
                    End If
                Next llngCnt
            End With

            '@入力ﾁｪｯｸ
            With vsfScrap
                '@不良数量の計算
                mlngChipScrapInputSumNum = 0            '不良合計数量(初期化)
                
                For llngCnt = 1 To .Rows.Count - 1
                    '@ｸﾞﾘｯﾄﾞに表示されている情報から合計数量を計算する
                    If IsNumeric(.GetData(llngCnt, CMlngvsfScrapChipNum)) = True Then
                        '@不良入力合計数量の加算
                        mlngChipScrapInputSumNum = mlngChipScrapInputSumNum _
                                                 + CLng(.GetData(llngCnt, CMlngvsfScrapChipNum))
                    End If
                Next llngCnt
            End With

            '@ﾘﾜｰｸ数量をﾗﾍﾞﾙに反映
            lblReworkNum.Text = Format(mlngChipReworkInputSumNum, CPstrDateFormatKanma)
            
            '@不良数量をﾗﾍﾞﾙに反映
            lblScrapNum.Text = Format(mlngChipScrapInputSumNum, CPstrDateFormatKanma)
            
            '@良品数量を計算しﾗﾍﾞﾙに反映
            lblChipNormalNum.Text = Format((mlngChipNomalCnt - _
                                              (mlngChipReworkInputSumNum + mlngChipTxtScrapInputNum)), CPstrDateFormatKanma)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvReworkScrap_Cal"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfPaletteSlotMap_Disp
    '機　能：ﾊﾟﾚｯﾄﾏｯﾌﾟ表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/11 (Wed) 18:49:50 N.Kojima
    '更新日：2005/05/11 (Wed) 11:41:49 N.Kojima
    '備　考：
    '　　　：2005/05/11 (Wed) 11:41:49 N.Kojima     TPALが入力された場合は、ﾊﾟﾚｯﾄﾏｯﾌﾟを使用不可とする。(不具合№718)
    Private Sub prvvsfPaletteSlotMap_Disp(ByRef ltypLotCfkiLotInfo As LotCfkiLotinfo)
        
        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngSlotNo              As Integer      'ｽﾛｯﾄ番号
        Dim lstrTempPaletteID       As String       'ﾊﾟﾚｯﾄID
        Dim lstrTempThicknessCode   As String       '板厚

        Try
            
            '@ﾊﾟﾚｯﾄのｽﾛｯﾄ情報の表示
            With vsfPaletteSlotMap
            
                '@入力ｷｬﾘｱ(ﾛｯﾄ)がTPALかの判定(採番ﾙｰﾙにより頭2文字が"TP"の場合)
                If Trim$(Strings.Left(lblLotID.Text, 2)) <> CMstrTPAL Then
                
                    '@ﾊﾟﾚｯﾄの情報がある場合
                    If ltypLotCfkiLotInfo.lngMetalPaletteMapListCnt > 0 Then
                        '@ｽﾛｯﾄﾏｯﾌﾟの活性化
                        .Enabled = True
            
                        '@描画を行わない
                        .Redraw = False
                                    
                        '@ｽﾛｯﾄ情報の設定
                        For llngCnt = 0 To ltypLotCfkiLotInfo.lngMetalPaletteMapListCnt - 1
                            '@内部変数にﾊﾟﾚｯﾄID/板厚/ｽﾛｯﾄ№を退避
                            lstrTempPaletteID = ltypLotCfkiLotInfo.typMetalPaletteMapList(llngCnt).strPaletteID             'ﾊﾟﾚｯﾄID
                            lstrTempThicknessCode = ltypLotCfkiLotInfo.typMetalPaletteMapList(llngCnt).strThicknessCode     '板厚
                            llngSlotNo = CLng(ltypLotCfkiLotInfo.typMetalPaletteMapList(llngCnt).strSlotPosition)           'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                            '@ﾊﾟﾚｯﾄID
                            .SetData(llngSlotNo, CMlngvsfPSlotID, lstrTempPaletteID)
                            '@板厚
                            .SetData(llngSlotNo, CMlngvsfPSlotThicknessCode, lstrTempThicknessCode)
                            '@ﾁｪｯｸを外す
                            .SetCellCheck(llngSlotNo, CMlngvsfPSlotReworkCheck, CheckEnum.Unchecked)
                            .SetCellCheck(llngSlotNo, CMlngvsfPSlotScrapCheck, CheckEnum.Unchecked)
                        Next llngCnt
                        
                        '@ﾌｫﾝﾄｻｲｽﾞ設定
                        .Cols(CMlngvsfPSlotNum).Style.Font = New Font(.Font.FontFamily, CType(CMlngGridFontSize, Single), .Font.Style)
                        .Cols(CMlngvsfPSlotID).Style.Font = New Font(.Font.FontFamily, CType(CMlngGridFontSize, Single), .Font.Style)
                        .Cols(CMlngvsfPSlotNum).TextAlign = TextAlignEnum.RightCenter
            
                        '@ｽﾛｯﾄﾏｯﾌﾟでﾘｽﾄｶｳﾝﾄがMaxRowに満たない場合は濃いｸﾞﾚｰ表記とする
                        If ltypLotCfkiLotInfo.lngMetalPaletteMapListCnt < CMlngvsfPSlotMaxRow Then
                            '@ｽﾛｯﾄﾏｯﾌﾟの表示設定
                            For llngCnt = CMlngvsfPSlotMinRow To CMlngvsfPSlotMaxRow
                                If .GetData(llngCnt, CMlngvsfPSlotID) = vbNullString Then
                                    '@空欄をｾｯﾄする
                                    .SetData(llngCnt, CMlngvsfPSlotReworkCheck, vbNullString)
                                    .SetData(llngCnt, CMlngvsfPSlotScrapCheck, vbNullString)
                                    '@ﾊﾟﾚｯﾄID空欄ｾﾙは背景色を濃いｸﾞﾚｰ
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfPSlotID, _
                                                           llngCnt, CMlngvsfPSlotScrapCheck)
                                    cellRange.Style = newStyle
                                End If
                            Next llngCnt
                        End If
            
                        '@再描画
                        .Redraw = True
            
                        '@頁先頭行が一覧先頭行の場合
                        If .TopRow = .Rows.Fixed Then
                            '@ﾛｯｸ
                            cmdSlotUp.Enabled = False
                        Else
                            '@ﾛｯｸ解除
                            cmdSlotUp.Enabled = True
                        End If
                        
                        '@最終行が表示頁にある場合
                        If .TopRow + CMlngvsfPSlotPageRows >= .Rows.Count Then
                            '@ﾛｯｸ
                            cmdSlotDown.Enabled = False
                        Else
                            '@ﾛｯｸ解除
                            cmdSlotDown.Enabled = True
                        End If
                        
                        '@選択行設定(ﾀｲﾄﾙ行へﾌｫｰｶｽｾｯﾄ)
                        .Row = 0
                        .Col = CMlngvsfPSlotID
                        
                    End If
            
                Else
                    '@TPALの場合
                    
                    '@ｽﾛｯﾄﾏｯﾌﾟの表示設定
                    For llngCnt = CMlngvsfPSlotMinRow To CMlngvsfPSlotMaxRow
                        If .GetData(llngCnt, CMlngvsfPSlotID) = vbNullString Then
                            '@空欄をｾｯﾄする
                            .SetData(llngCnt, CMlngvsfPSlotReworkCheck, vbNullString)
                            .SetData(llngCnt, CMlngvsfPSlotScrapCheck, vbNullString)
                            '@ﾊﾟﾚｯﾄID空欄ｾﾙは背景色を濃いｸﾞﾚｰ
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfPSlotID, _
                                                   llngCnt, CMlngvsfPSlotScrapCheck)
                            cellRange.Style = newStyle
                        End If
                    Next llngCnt
                    
                    '@ﾊﾟﾚｯﾄﾏｯﾌﾟを無効にする
                    vsfPaletteSlotMap.Enabled = False
                End If
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfPaletteSlotMap_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfRework_Disp
    '機　能：ﾘﾜｰｸ入力一覧表示処理
    '引　数：ltypLotCfkiLotInfo     :CFKIﾛｯﾄ情報取得構造体
    '　　　：ltypInvCFLotInfoList   ：CFﾛｯﾄ情報取得構造体
    '戻り値：なし
    '作成日：2005/05/11 (Wed) 18:51:42 N.Kojima
    '更新日：2005/05/11 (Wed) 11:41:49 N.Kojima
    '備　考：
    '　　　：2005/05/11 (Wed) 11:41:49 N.Kojima     TPALが入力された場合は、CFﾛｯﾄ情報で取得した板厚を表示する。(不具合№718)
    Private Sub prvvsfRework_Disp(ByRef ltypLotCfkinuminfo As LotCfkinuminfo, _
                                  ByRef ltypLotCfkiLotInfo As LotCfkiLotinfo, _
                                  ByRef ltypInvCFLotInfoList As InvCFLotInfoList)

        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngScrapGridCnt        As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lblnThcknessFindFlg     As Boolean      '板厚存在ﾌﾗｸﾞ(False:無し、True:有り)

        Try
            
            '@ﾘﾜｰｸ情報の表示(ﾘﾜｰｸ回数が再生可能回数未満の場合、使用可能)
            With ltypLotCfkiLotInfo
                
                '@ﾘﾜｰｸ回数が最大未満の場合はﾘﾜｰｸｸﾞﾘｯﾄを表示する
                '@再生可能回数は部品で決定し、在庫ﾛｯﾄから引継いだﾘﾜｰｸ回数が再生可能数以上の場合はﾘﾜｰｸ不可！！(在庫には入れない)
                If .strReworkCount < ltypLotCfkinuminfo.strRegenerationCount Then
                    
                    '@ﾘﾜｰｸｸﾞﾘｯﾄﾞの初期化
                    'vsfRework.Clear
                    
                    '@描画を行わない
                    vsfRework.Redraw = False
                    
                    '@板厚の設定
                    If .lngMetalPaletteMapListCnt > 0 Then
                        vsfRework.AllowEditing = True
                    End If
                    
                    '@入力ｷｬﾘｱ(ﾛｯﾄ)がTPALかの判定(採番ﾙｰﾙにより頭2文字が"TP"の場合)
                    If Trim$(Strings.Left(lblLotID.Text, 2)) <> CMstrTPAL Then
                        '@板厚のﾏｰｼﾞ
                        For llngCnt = 0 To .lngMetalPaletteMapListCnt - 1
                            
                            '@板厚存在ﾌﾗｸﾞの初期化
                            lblnThcknessFindFlg = False              '無し
                            
                            With .typMetalPaletteMapList(llngCnt)
                                
                                For llngScrapGridCnt = 1 To vsfRework.Rows.Count - 1
                                    If vsfRework.GetData(llngScrapGridCnt, CMlngvsfReworkThicknessCode) = .strThicknessCode Then
                                        '@板厚存在ﾌﾗｸﾞ設定(存在する)
                                        lblnThcknessFindFlg = True
                                        Exit For
                                    End If
                                Next llngScrapGridCnt
                                
                                '@ﾘﾜｰｸｸﾞﾘｯﾄの行追加判定
                                If lblnThcknessFindFlg = False Then
                                    '@板厚が存在しない場合は新規行を追加する
                                    vsfRework.Rows.Count = vsfRework.Rows.Count + 1
                                    
                                    vsfRework.SetData(llngScrapGridCnt, CMlngvsfReworkThicknessCode, .strThicknessCode)
                                    vsfRework.SetData(llngScrapGridCnt, CMlngvsfReworkChipNum, vbNullString)
                                    vsfRework.Rows(llngScrapGridCnt).Height = CMlngGridRowHeight
                                    
                                    '@表示ｾﾙは背景色を薄いｸﾞﾚｰ
                                    Dim newStyle As CellStyle = vsfRework.Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                                    Dim cellRange As CellRange = vsfRework.GetCellRange(llngScrapGridCnt, CMlngvsfReworkThicknessCode)
                                    cellRange.Style = newStyle
                                End If
                                
                            End With
                        Next llngCnt
                        
                    Else
                        '@TPALの場合
                        
                        '@板厚分新規行を追加する
                        vsfRework.Rows.Count = ltypInvCFLotInfoList.lngThicknessCnt + 1
                            
                        '@CFﾛｯﾄ情報ﾒｯｾｰｼﾞで取得した板厚数分ﾙｰﾌﾟ
                        For llngCnt = 1 To ltypInvCFLotInfoList.lngThicknessCnt

                            vsfRework.SetData(llngCnt, CMlngvsfReworkThicknessCode, _
                                ltypInvCFLotInfoList.typThicknessList(llngCnt - 1).strThicknessCode)             '板厚
                                
                            vsfRework.SetData(llngCnt, CMlngvsfReworkChipNum, vbNullString)
                            
                            vsfRework.Rows(llngCnt).Height = CMlngGridRowHeight
                            
                            '@表示ｾﾙは背景色を薄いｸﾞﾚｰ
                            Dim newStyle As CellStyle = vsfRework.Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                            Dim cellRange As CellRange = vsfRework.GetCellRange(llngCnt, CMlngvsfReworkThicknessCode)
                            cellRange.Style = newStyle
                            
                        Next llngCnt
                        
                    End If
                    
                    '@ﾌｫﾝﾄｻｲｽﾞ設定
                    vsfRework.Font = New Font(vsfRework.Font.FontFamily, CType(CMlngGridFontSize, Single), vsfRework.Font.Style)
                    
                    '@ｿｰﾄ設定(板厚ｱﾙﾌｧﾍﾞｯﾄ順)
                    vsfRework.Col = CMlngvsfReworkTitle
                    vsfRework.Sort(SortFlags.Ascending,CMlngvsfReworkTitle)
                    
                    '@再描画
                    vsfRework.Redraw = True
                End If
                
            End With
            
            '@ﾘﾜｰｸのｽｸﾛｰﾙﾎﾞﾀﾝ/選択行設定
            With vsfRework
                '@頁先頭行が一覧先頭行の場合
                If .TopRow <= .Rows.Fixed Then
                    '@ﾛｯｸ
                    cmdReworkUP.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdReworkUP.Enabled = True
                End If
                
                '@最終行が表示頁にある場合
                If .TopRow + CMlngvsfReworkPageRows >= .Rows.Count Then
                    '@ﾛｯｸ
                    cmdReworkDown.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdReworkDown.Enabled = True
                End If
                
                '@選択行設定(ﾀｲﾄﾙ行)
                .Row = 0
                
                '@描画ﾌﾗｸﾞをTrue設定
                mblnReworkDrawFlag = True
                        
                '@活性化
                .Enabled = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfRework_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfScrap_Disp
    '機　能：不良入力一覧表示処理
    '引　数：ltypMasItemList     ：不良ｺｰﾄﾞ情報格納構造体
    '戻り値：なし
    '作成日：2005/05/11 (Wed) 18:53:36 N.Kojima
    '更新日：2009/04/08 (Wed) 17:07:22 N.Kojima
    '備　考：
    '　　　：2005/12/12 (Mon) 19:20:31 N.Kojima     ﾘﾜｰｸｸﾞﾘｯﾄﾞとの動作統一の為、列指定処理追加。(不具合№3255)
    '　　　：2009/04/08 (Wed) 17:07:22 N.Kojima     払出ｺｰﾄﾞは表示しないようにする。(案件№03434)
    Private Sub prvvsfScrap_Disp(ByRef ltypMasItemList As MasItemList)
        
        Dim llngCnt     As Integer  'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            
            '@不良情報の表示(ﾏｽﾀの設定で不良項目をｾｯﾄしている場合は使用可能)
            With ltypMasItemList
                
                '@ﾘﾜｰｸｸﾞﾘｯﾄﾞの初期化
                'vsfScrap.Clear
                
        '@↓2009/04/08 (Wed) 17:24:17 N.Kojima **************************************************
        '        '@行数の設定
        '        vsfScrap.Rows = .lngListCnt + 1
        '@↑2009/04/08 (Wed) 17:24:17 N.Kojima **************************************************
                
                '@描画を行わない
                vsfScrap.Redraw = False
                
                '@改行
                vsfScrap.Styles.Normal.WordWrap = True
                
                '@不良ｺｰﾄﾞﾘｽﾄの設定
                If .lngListCnt > 0 Then
                    vsfScrap.AllowEditing = True
                End If
                
                For llngCnt = 0 To .lngListCnt - 1
                    
                    With .typeMasItem(llngCnt)
                        
        '@↓2009/04/08 (Wed) 17:06:55 N.Kojima **************************************************

                        '@払出ｺｰﾄﾞ以外か(※払出ｺｰﾄﾞは表示しない。CFのﾁｯﾌﾟ払出登録機能も実装していない)
                        If .strItemID <> CPstrForwardCode Then
                            '@払出ｺｰﾄﾞ以外の場合
                            
                            vsfScrap.Rows.Count = vsfScrap.Rows.Count + 1
                            
                            vsfScrap.SetData(vsfScrap.Rows.Count - 1, CMlngvsfScrapCode, .strItemID)          '不良ｺｰﾄﾞ
                            vsfScrap.SetData(vsfScrap.Rows.Count - 1, CMlngvsfScrapName, .strItemName)        '不良ｺｰﾄﾞ名称
                            vsfScrap.SetData(vsfScrap.Rows.Count - 1, CMlngvsfScrapChipNum, vbNullString)     '数量入力欄
                            vsfScrap.Rows(vsfScrap.Rows.Count - 1).Height = CMlngGridRowHeight                            '高さ設定
                            
                            '@表示ｾﾙは背景色を薄いｸﾞﾚｰ
                            Dim newStyle As CellStyle = vsfScrap.Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                            Dim cellRange As CellRange = vsfScrap.GetCellRange(vsfScrap.Rows.Count - 1, CMlngvsfScrapCode, _
                                                                               vsfScrap.Rows.Count - 1, CMlngvsfScrapName)
                            cellRange.Style = newStyle
                        End If

        '@↑2009/04/08 (Wed) 17:06:55 N.Kojima **************************************************

                    End With
                Next llngCnt
                
                '@ﾌｫﾝﾄｻｲｽﾞ設定
                vsfScrap.Font = New Font(vsfScrap.Font.FontFamily, CType(CMlngGridFontSize, Single), vsfScrap.Font.Style)
                
                '@再描画
                vsfScrap.Redraw = True
                
                '@要因ｺｰﾄﾞ列を指定しておく(ﾘﾜｰｸｸﾞﾘｯﾄとの動作統一)
                vsfScrap.Col = CMlngvsfScrapCode
                
            End With
                
            '@不良のｽｸﾛｰﾙﾎﾞﾀﾝ/選択行設定
            With vsfScrap
                '@頁先頭行が一覧先頭行の場合
                If .TopRow <= .Rows.Fixed Then
                    '@ﾛｯｸ
                    cmdScrapUp.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdScrapUp.Enabled = True
                End If
                
                '@最終行が表示頁にある場合
                If .TopRow + CMlngvsfScrapPageRows >= .Rows.Count Then
                    '@ﾛｯｸ
                    cmdScrapDown.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdScrapDown.Enabled = True
                End If
                
                '@選択行設定(ﾀｲﾄﾙ行)
                .Row = 0
                
                '@描画ﾌﾗｸﾞをTrue設定
                mblnScrapDrawFlag = True
                
                '@活性化
                .Enabled = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfScrap_Disp"
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


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfPaletteSlotMap.KeyDownEdit, vsfRework.KeyDownEdit, vsfScrap.KeyDownEdit

        With CType(sender, C1FlexGrid)
            '@'ｶﾚﾝﾄｾﾙがﾍｯﾀﾞｰ行でない場合
            If e.Row >= .Rows.Fixed Then
                Select Case e.KeyCode
                    Case Keys.Up  '[↑]ｷｰ押下
                        If e.Row = .Rows.Fixed Then
                            e.Handled = True
                        End If
                    Case Keys.Down  '[↓]ｷｰ押下
                        If e.Row = .Rows.Count -1 Then
                            e.Handled = True
                        End If
                    Case Keys.PageUp  '[PageUp]ｷｰ押下
                        If e.Row = .Rows.Fixed Then
                            e.Handled = True
                        End If
                    Case Keys.PageDown  '[PageDown]ｷｰ押下
                        If e.Row = .Rows.Count - 1 Then
                            e.Handled = True
                        End If
                    Case Keys.Left  '[←]ｷｰ押下
                        Dim editor As Object = CType(.Editor, Object)
                        If e.Col = .Cols.Count - 1 AndAlso .Editor.Text.Length > 0 Then
                            e.Handled = True
                        Else
                            ' 編集不可のコンボボックスの場合
                            ' または、
                            ' テキストボックスで、かつ、カーソルが先頭の場合は、
                            '   左隣へ
                            If TypeOf editor Is TextBox AndAlso _
                                    (editor.SelectionStart = 0 AndAlso editor.SelectionLength = 0) Then
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
                        End If
                    Case Keys.Right '[→]ｷｰ押下
                        If e.Col = .Cols.Count - 1 Then
                            e.Handled = True
                        End If
                    Case Keys.Escape
                        'NSYS Escキー押下時の動作をVB6版と合わせるために追加
                        .HighLight = HighLightEnum.WithFocus
                End Select
            End If
        End With

    End Sub


    '関数名：flex_Leave
    '機　能：グリッドフォーカスアウト処理
    '引　数：なし
    '戻り値：なし
    '作成日：2020/03/30 (Mon) 14:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flex_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles vsfPaletteSlotMap.Leave, vsfRework.Leave, vsfScrap.Leave

       Try
           'ハイライトを元に戻す
           With CType(sender, C1FlexGrid)
               .HighLight = HighLightEnum.WithFocus
           End With
       
       Catch ex As Exception
            '異常終了した場合は何もしない

       End Try

    End Sub

    '関数名：vsfScrap_BeforeSort
    '機　能：要因　ｿｰﾄ前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2020/04/03 (Fri) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub vsfScrap_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfScrap.BeforeSort
        Try

            '@要因のソート前のスクロール位置を退避しておく
            lprePos = vsfScrap.ScrollPosition

            Exit Sub
        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try
    End Sub

    '関数名：vsfScrap_AfterSort
    '機　能：要因　ｿｰﾄ後処理
    '引　数：なし
    '戻り値：なし
    '作成日：2020/04/03 (Fri) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub vsfScrap_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfScrap.AfterSort
        Try

            '@要因が選択されている場合は退避しておいた、行、スクロール位置を戻す
            With vsfScrap
                If .Rows.Count > .Rows.Fixed Then
                    .Row = lpreRow
                    .Col = 1
                    .ShowCell(.Row,.Col)
                    .HighLight = HighLightEnum.WithFocus
                    .ScrollPosition = lprePos
                End If
            End With

            Exit Sub
        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try
    End Sub

End Class
