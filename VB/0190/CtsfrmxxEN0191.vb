'ﾌｧｲﾙ名：xxEN0191.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：現工程不良詳細画面
'作成日：2006/05/18 (Thu) 18:37:37 N.Kojima
'更新日：2019/02/13 (Wed) 15:14:32 T.Oide
'備　考：
'　　　：2006/07/07 (Fri) 14:09:59 T.Kitagawa　WFの不良合計(ﾕｰｻﾞ要望№0203)、不良率(ﾕｰｻﾞ要望№0210)の対応
'Copyright(C) SEIKO EPSON CORPORATION 2003-2019, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0191
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0191    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0191
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0191
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0191)
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
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN0191  'ﾛｰｶﾙ機能ID

    '@vsfLotScrapInfoの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfLotScrapInfoColScrapCode      As Integer = 0              '不良ｺｰﾄﾞ
    Private Const CMlngvsfLotScrapInfoColScrapName      As Integer = 1              '不良名称
    Private Const CMlngvsfLotScrapInfoColLotTotal       As Integer = 2              'Lot合計不良数
    Private Const CMlngvsfLotScrapInfoColLotScrapRate   As Integer = 3              'Lot不良発生率

    '@vsfLotScrapInfoの定数宣言(表示幅変更)
    Private Const CMlngvsfLotScrapInfoColWScrapCode     As Integer = 76             '不良ｺｰﾄﾞ
    Private Const CMlngvsfLotScrapInfoColWScrapName     As Integer = 136            '不良名称
    Private Const CMlngvsfLotScrapInfoColWLotTotal      As Integer = 60             'Lot合計不良数
    Private Const CMlngvsfLotScrapInfoColWLotScrapRate  As Integer = 83             'Lot不良発生率
    Private Const CMlngvsfLotScrapInfoColWWFID          As Integer = 93             'WFID(1～25枚)
    Private Const CMlngvsfLotScrapInfoColWWFID_Bold     As Integer = 100            'WFID(1～25枚)Bold時

    '@vsfLotScrapInfoの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfLotScrapInfoColTScrapCode     As String = "コード"        'ｽﾛｯﾄ
    Private Const CMstrvsfLotScrapInfoColTScrapName     As String = "名称"          'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMstrvsfLotScrapInfoColTLotTotal      As String = "合計数"        'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMstrvsfLotScrapInfoColTLotScrapRate  As String = "不良率(%)"     'Lot不良発生率

    '@vsfLotScrapInfoの定数宣言(初期設定値)
    Private Const CMstrGridFontName                     As String = "ＭＳ ゴシック" 'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄ名
    Private Const CMlngvsfLotScrapInfoCols              As Integer = 29             'ｶﾗﾑ数
    Private Const CMlngvsfLotScrapInfoFontSize          As Integer = 11             'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngGridFixedCols                    As Integer = 0              'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngGridFixedRows                    As Integer = 1              'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngGridRowTitle                     As Integer = 0              'ﾀｲﾄﾙ行(行)
    Private Const CMlngGridTitleHeight                  As Integer = 20             'ﾍｯﾀﾞｰの高さ
    Private Const CMlngGridRowHeight                    As Integer = 18             '1明細の高さ
    Private Const CMlngvsfFrozenCols                    As Integer = 4              '固定列数
    Private Const CMlngvsfFrozenCol                     As Integer = 3              '固定列(不良発生率)
    Private Const CMlngvsfFrezonRow                     As Integer = 1              '固定行(合計表示行=1)

    '@横ｽｸﾛｰﾙ制御用定数
    Private Const CMlngSideScrollOnFlag                 As Integer = 1              '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag                As Integer = 2              '横ｽｸﾛｰﾙ非活性化

    '@総合計用定数
    Private Const CMstrTotalTitle                       As String = "【合計】"      '合計ﾀｲﾄﾙ
    Private Const CMstrTotalKnmaFormat                  As String = "#,###"         '合計数ｶﾝﾏ編集
    Private Const CMstrTotalFormatRate                  As String = "##0.00"        '合計率編集
    Private Const CMlngTotalBackColor                   As Integer = &HFFFFC0       '合計色(水色)
    Private Const CMlngTotalForeColor                   As Integer = &H0&           '合計文字色(黒)
    Private Const CMlngTotalScrapRate100                As Integer = 100            'Lot不良発生率(× 100)
    Private Const CMlngTotalScrapRateRoundPos2          As Integer = 2              'Lot不良発生率の四捨五入表示位置(少数第２位)

    '@親画面(frmxxCM0080)のvsfWFMapのWF_ID列
    Private Const CMlngvsfWFMapID                       As Integer = 1              'WF_ID
    '@WPID判別用
    '@↓2019/01/30 (Wed) 13:51:44 Y.Yoneyama **************************************************
    'Private Const CMstrPakenWpId                        As String = "H2PANELGAI"    'パ検WPID判別用(10文字判定)
    Private Const CMstrPakenWpId                        As String = "H2PANEL"       'パ検WPID判別用(7文字判定)
    '@↑2019/01/30 (Wed) 13:51:44 Y.Yoneyama **************************************************

    '@未確定ラベル表示用
    Private Const CMstrMikakutei                        As String = "＜＜注意＞＞" & vbCrLf & "「未確定」ウェハーがあります！！"
    Private Const CMstrKakuteisumi                      As String = "全ウェハー確定済です"

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '======================================Private==========================================
    Private mblnActivateFlag                        As Boolean              'Activate完了ﾌﾗｸﾞ(True:Load完了,False:Load未完)
    Private mlngSideScrollFlag                      As Integer              '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
    Private mlngLotScrapCnt                         As Integer              'ﾛｯﾄ毎(全WF)のｺｰﾄﾞ別不良数格納用
    Private buttonProcessing                        As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean              'NSYS WindowCloseフラグ

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
        pubVsfMouseWheelManager_Set(vsfLotScrapInfo, cmdNextUP, cmdNextDown, cmdLeft, cmdRight)
        
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '======================================Private==========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/22 (Mon) 16:41:35 N.Kojima
    '更新日：2006/05/22 (Mon) 16:41:35
    '備　考：
    Private Sub Form_Load()

        Try

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = CPstrSubFormEN0191

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾓｼﾞｭｰﾙ変数の初期化
            mblnActivateFlag = False
            
            '@=======================
            '@ 現工程不良ﾘｽﾄ初期化処理
            '@=======================
            Call prvVsfLotScrapInfo_Init()

            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            '@Form_Loadﾌﾗｸﾞに"True：正常起動"をｾｯﾄ
            pblnFormLoad = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"                  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/23 (Tue) 10:07:42 N.Kojima
    '更新日：2006/05/23 (Tue) 10:07:42
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@FormLoad後、最初の1回しか処理しない
            If mblnActivateFlag = True Then
                '@Load済みの場合
                
                '@Escﾎﾞﾀﾝを有効にし、処理終了
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ位置を設定
            Me.Top = 160
            Me.Left = 127 - My.Settings.FormOffset
            
            '@ActivateﾌﾗｸﾞをTrue(=Load済み)にする
            mblnActivateFlag = True
            
            '@=======================
            '@ 現工程不良詳細表示処理
            '@=======================
            Call prvVsfLotScrapInfo_Disp()
            
            '@ﾌｫｰｶｽ処理
            If ptypMasItemList.lngListCnt <> 0 Then
                
                '@ｸﾞﾘｯﾄﾞにｾｯﾄ
                Call pubSetFocus(vsfLotScrapInfo)
            Else
                
                '@閉じるﾎﾞﾀﾝにｾｯﾄ
                Call pubSetFocus(cmdClose)
            End If
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰの場合はFalseで再起動可にする
            mblnActivateFlag = False
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Activate"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰ押下時処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2006/05/23 (Tue) 13:36:18 N.Kojima
    '更新日：2007/07/06 (Fri) 12:10:20 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 12:10:20 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@以下の条件の場合、ｷｰｺｰﾄﾞを無効にして処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                e.Handled = True
                Exit Sub
            End If

            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(共通処理)
            '@ ※ﾊﾟﾗﾒｰﾀ：ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、上ﾎﾞﾀﾝ、下ﾎﾞﾀﾝ
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfLotScrapInfo, cmdNextUP, cmdNextDown)
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(共通処理)
            '@ ※ﾊﾟﾗﾒｰﾀ：ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ
            '@=======================
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfLotScrapInfo, cmdLeft, cmdRight)

            '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
            Select Case e.KeyCode
                
                '@〓 Enterｷｰ 〓
                Case Keys.Return

                    '@次有効ｺﾝﾄﾛｰﾙへﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"               '処理名
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
    '引　数：Cancel     ：True：終了ｷｬﾝｾﾙ、False：終了
    '　　　：UnloadMode ：0:×ﾎﾞﾀﾝ終了、1：閉じるﾎﾞﾀﾝ終了
    '戻り値：なし
    '作成日：2006/05/22 (Mon) 16:48:23 N.Kojima
    '更新日：2006/05/22 (Mon) 16:48:23
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            '@Windowの"×"ﾎﾞﾀﾝにて閉じたか
            If mblnCloseFromControlMenu Then
            
                '@=======================
                '@ 閉じるﾎﾞﾀﾝ押下時処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@Activateﾌﾗｸﾞの初期化
            mblnActivateFlag = False
            
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/23 (Tue) 13:32:54 N.Kojima
    '更新日：2006/05/23 (Tue) 13:32:54
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

            '@∇∇∇∇∇∇∇∇∇∇∇
            '@ ｱﾝﾛｰﾄﾞ処理
            '@∇∇∇∇∇∇∇∇∇∇∇
            Me.Close()

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：vsfLotScrapInfo_AfterUserResize
    '機　能：現工程不良詳細ｸﾞﾘｯﾄﾞ　列幅変更後処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2006/05/23 (Tue) 13:35:20 N.Kojima
    '更新日：2007/07/09 (Mon) 15:16:10 N.Kasai
    '備　考：
    '　　　：2007/07/09 (Mon) 15:16:10 N.Kasai      左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御をｸﾞﾘｯﾄﾞ共通処理に変更。
    Private Sub vsfLotScrapInfo_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotScrapInfo.AfterResizeColumn, vsfLotScrapInfo.AfterResizeRow

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotScrapInfo.Rows.Count <= vsfLotScrapInfo.Rows.Fixed Then
                Return
            End If
            
            '@=======================
            '@ 左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御処理(ｸﾞﾘｯﾄﾞ共通化関数)
            '@=======================
            Call pubCmdLREnable_Set(vsfLotScrapInfo, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                     '機能ID
                .strProcName = "vsfLotScrapInfo_AfterUserResize"    '処理名
                .strErrMessage = vbNullString                       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNextUP_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(現工程不良詳細ｸﾞﾘｯﾄﾞ)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/23 (Tue) 13:33:50 N.Kojima
    '更新日：2006/05/23 (Tue) 13:33:50
    '備　考：
    Private Sub cmdNextUP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNextUP.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ 上ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdUp(vsfLotScrapInfo, cmdNextUP, cmdNextDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdNextUP_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNextDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(現工程不良詳細ｸﾞﾘｯﾄﾞ)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/23 (Tue) 13:34:03 N.Kojima
    '更新日：2006/05/23 (Tue) 13:34:03
    '備　考：
    Private Sub cmdNextDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNextDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ 下ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdDown(vsfLotScrapInfo, cmdNextUP, cmdNextDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdNextDown_Click"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLeft_Click
    '機　能：左(<<)ｽｸﾛｰﾙﾎﾞﾀﾝ(現工程不良詳細ｸﾞﾘｯﾄﾞ)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/23 (Tue) 13:34:18 N.Kojima
    '更新日：2007/07/06 (Fri) 12:09:16 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 12:09:16 N.Kasai      左ｽｸﾛｰﾙﾎﾞﾀﾝ制御処理を共通化。
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
            '@ 左ｽｸﾛｰﾙﾎﾞﾀﾝ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdLeft(vsfLotScrapInfo, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdLeft_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRight_Click
    '機　能：右(>>)ｽｸﾛｰﾙﾎﾞﾀﾝ(現工程不良詳細ｸﾞﾘｯﾄﾞ)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/23 (Tue) 13:34:34 N.Kojima
    '更新日：2007/07/06 (Fri) 12:08:24 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 12:08:24 N.Kasai      右ｽｸﾛｰﾙﾎﾞﾀﾝ制御処理を共通化。
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
            '@ 右ｽｸﾛｰﾙﾎﾞﾀﾝ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdRight(vsfLotScrapInfo, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdRight_Click"             '処理名
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

    '関数名：prvVsfLotScrapInfo_Init
    '機　能：現工程不良詳細ﾘｽﾄ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/23 (Tue) 10:15:42 N.Kojima
    '更新日：2016/12/09 (Fri) 16:06:30 T.Oide
    '備　考：
    '　　　：2006/07/07 (Fri) 15:44:36 T.Kitagawa   WFの不良合計(ﾕｰｻﾞ要望№0203)、不良率(ﾕｰｻﾞ要望№0210)の対応
    Private Sub prvVsfLotScrapInfo_Init()

        Dim llngCnt         As Integer      'ｶｳﾝﾀ
        Dim llngCnt2        As Integer      'ｶｳﾝﾀ2
        

        Try

            With vsfLotScrapInfo
                
                '@ﾌﾟﾛﾊﾟﾃｨ初期設定
                .Clear(ClearFlags.Content, .Rows.Fixed, .Cols.Fixed, .Rows.Count - 1, .Cols.Count - 1)      '初期化
                .Cols.Count = CMlngvsfLotScrapInfoCols                      '列数(ﾃﾞﾌｫﾙﾄ"29")
                .Rows.Count = CMlngGridFixedRows                            '行数
                .Cols.Fixed = CMlngGridFixedCols                            '固定列数
                .Rows.Fixed = CMlngGridFixedRows                            '固定行数
                .SelectionMode = SelectionModeEnum.Cell                     '行選択(不可)
                .FocusRect = FocusRectEnum.Light                            'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠(細い枠)
                .HighLight = HighLightEnum.Never                            'ﾊｲﾗｲﾄ表示しない
                .Font = new Font(CMstrGridFontName, CMlngvsfLotScrapInfoFontSize, .Font.Style, .Font.Unit)  'ﾌｫﾝﾄ(MSｺﾞｼｯｸ,11pts)
                .ScrollBars = ScrollBars.None                               'ｽｸﾛｰﾙﾊﾞｰ(なし)
                '.AutoSizeMode = flexAutoSizeColWidth                       'ｵｰﾄｻｲｽﾞ(列)
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter  '文字列の最後に省略符号
                .AllowResizing = AllowResizingEnum.Columns                  '列幅の変更許可
                .ExtendLastCol = True                                       '右端の列をｸﾞﾘｯﾄﾞに合わせる
                .Cols.Frozen = CMlngvsfFrozenCols                           '固定列の設定
                .Styles.Fixed.ForeColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngTotalForeColor))   '固定ｾﾙのForeColor色(黒)

                '@ｸﾞﾘｯﾄﾞの表題設定(不良ｺｰﾄﾞ～№25WFまで)
                Dim cellRange As CellRange = .GetCellRange(CMlngGridRowTitle, CMlngvsfLotScrapInfoColScrapCode, CMlngGridRowTitle, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))  '背景色
                headerStyle.Font = new Font(.Font.FontFamily, CMlngvsfLotScrapInfoFontSize)         'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                  '文字位置
                headerStyle.Trimming = StringTrimming.None                                          'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle
                
                '@不良ｺｰﾄﾞ,名称,ﾛｯﾄ合計数の初期設定
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngGridRowTitle, CMlngvsfLotScrapInfoColScrapCode, CMstrvsfLotScrapInfoColTScrapCode)      '不良ｺｰﾄﾞ
                .SetData(CMlngGridRowTitle, CMlngvsfLotScrapInfoColScrapName, CMstrvsfLotScrapInfoColTScrapName)      '不良名称
                .SetData(CMlngGridRowTitle, CMlngvsfLotScrapInfoColLotTotal, CMstrvsfLotScrapInfoColTLotTotal)        'ﾛｯﾄ合計数
                .SetData(CMlngGridRowTitle, CMlngvsfLotScrapInfoColLotScrapRate, CMstrvsfLotScrapInfoColTLotScrapRate)    'Lot不良発生率
                
                '@列幅設定
                .Cols(CMlngvsfLotScrapInfoColScrapCode).Width = CMlngvsfLotScrapInfoColWScrapCode         '不良ｺｰﾄﾞ
                .Cols(CMlngvsfLotScrapInfoColScrapName).Width = CMlngvsfLotScrapInfoColWScrapName         '不良名称
                .Cols(CMlngvsfLotScrapInfoColLotTotal).Width = CMlngvsfLotScrapInfoColWLotTotal           'ﾛｯﾄ合計数
                .Cols(CMlngvsfLotScrapInfoColLotScrapRate).Width = CMlngvsfLotScrapInfoColWLotScrapRate   'Lot不良発生率
                
                '@表示位置の設定
                .Cols(CMlngvsfLotScrapInfoColScrapCode).TextAlign = TextAlignEnum.LeftCenter       '不良ｺｰﾄﾞ(左中央寄せ)
                .Cols(CMlngvsfLotScrapInfoColScrapName).TextAlign = TextAlignEnum.LeftCenter       '不良名称(左中央寄せ)
                .Cols(CMlngvsfLotScrapInfoColLotTotal).TextAlign = TextAlignEnum.RightCenter       'ﾛｯﾄ合計数(右中央寄せ)
                .Cols(CMlngvsfLotScrapInfoColLotScrapRate).TextAlign = TextAlignEnum.RightCenter   'Lot不良発生率(右中央寄せ)
                
                '@WFIDの初期設定(WF枚数分)
                '@配列のWF数分ﾙｰﾌﾟ
                For llngCnt = 1 To ptypLotScrapInfo.typWFScrapInfo.Count
                    
                    '@Col番号"3"から開始(0,1,2は固定)
                     llngCnt2 = llngCnt + CMlngvsfFrozenCol
                    
                    '@ﾀｲﾄﾙ設定
                    .SetData(CMlngGridRowTitle, llngCnt2, ptypLotScrapInfo.typWFScrapInfo(llngCnt - 1).strWfId)
                    
                    '@列幅設定
                    .Cols(llngCnt2).Width = CMlngvsfLotScrapInfoColWWFID
                    
                    '@表示位置の設定(右中央)
                    .Cols(llngCnt2).TextAlign = TextAlignEnum.RightCenter
                Next llngCnt

                '@非表示列設定(列幅も"0"に設定)
                For llngCnt = llngCnt2 + 1 To .Cols.Count - 1
                    
                    .Cols(llngCnt).Width = 0
                    .Cols(llngCnt).Visible = False
                Next llngCnt

                '@ﾀｲﾄﾙの高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight

                '@ｸﾞﾘｯﾄﾞ,ﾎﾞﾀﾝの無効化
                .Enabled = False
                cmdLeft.Enabled = False     '<<ﾎﾞﾀﾝ
                cmdRight.Enabled = False    '>>ﾎﾞﾀﾝ
                
                '@=======================
                '@ ｽｸﾛｰﾙﾎﾞﾀﾝの表示初期化(共通処理)
                '@=======================
                Call pubVsfDisp(vsfLotScrapInfo, cmdNextUP, cmdNextDown)

                '@パ検工程か
        '@↓2019/01/30 (Wed) 13:59:22 Y.Yoneyama **************************************************
                'If Mid$(ptypLotprestate.strWpID, 1, 10) = CMstrPakenWpId Then
                If Mid$(ptypLotprestate.strWpID, 1, 7) = CMstrPakenWpId Then
        '@↑2019/01/30 (Wed) 13:59:22 Y.Yoneyama **************************************************
                    '@パ検確定済表示対応
                    '@確定したWF_IDの表示を赤にする　（作業漏れ対策）
                    Call prvPakenWfIdColor()
                End If
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvVsfLotScrapInfo_Init"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfLotScrapInfo_Disp
    '機　能：現工程不良詳細ﾘｽﾄ表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/23 (Tue) 10:14:18 N.Kojima
    '更新日：2016/06/07 (Tue) 13:58:01 T.Inafune
    '備　考：
    '　　　：2006/07/07 (Fri) 16:31:53 T.Kitagawa　 WFの不良合計(ﾕｰｻﾞ要望№0203)、不良率(ﾕｰｻﾞ要望№0210)の対応
    '　　　：2007/07/09 (Mon) 15:17:50 N.Kasai      上下、左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御処理を共通化。
    '　　　：2009/04/20 (Mon) 15:31:46 N.Kojima     払出数は表示しないようにする。(案件№03434)
    '　　　：2009/07/17 (Fri) 11:50:51 N.Kojima     払出ｺｰﾄﾞを表示しないようにする処理でｼｽﾃﾑｴﾗｰになる件を修正。(案件№03674)
    Private Sub prvVsfLotScrapInfo_Disp()

        Dim llngWFcnt           As Integer  'WFｶｳﾝﾀ
        Dim llngScrapCodeCnt    As Integer  '不良ｺｰﾄﾞｶｳﾝﾀ
        Dim llngRowCnt          As Integer  '行ｶｳﾝﾀ
        Dim llngColCnt          As Integer  '列ｶｳﾝﾀ
        Dim llngColTotal        As Integer  '列合計
        Dim lcurLotScrapRate    As Decimal  '不良率(少数点第３位四捨五入)
        Dim lstrScrapCode       As String   '不良/払出/保留ｺｰﾄﾞ
        Dim lstrScrapCode2      As String   '不良/払出/保留ｺｰﾄﾞ2

        Try

            With vsfLotScrapInfo
                
                '@不良項目が設定されている場合
                If ptypMasItemList.lngListCnt <> 0 Then
                
                    '@行設定(ﾃﾞﾌｫﾙﾄで合計表示列用に1行追加する)
                    .Rows.Count = .Rows.Count + 1
            
                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    '@不良項目数分ﾙｰﾌﾟ(行のﾙｰﾌﾟ)
                    For llngRowCnt = 1 To ptypMasItemList.lngListCnt
                        
                        lstrScrapCode = ptypMasItemList.typeMasItem(llngRowCnt - 1).strItemID

                        '@選択ｺｰﾄﾞが"払出ｺｰﾄﾞ"以外か
                        If lstrScrapCode <> CPstrForwardCode Then
                            '@払出ｺｰﾄﾞ以外(=不良ｺｰﾄﾞ)の場合
                        
                            '@行設定
                            .Rows.Count = .Rows.Count + 1
                        
                            '@不良ｺｰﾄﾞ
                            .SetData(.Rows.Count - 1, CMlngvsfLotScrapInfoColScrapCode, _
                                ptypMasItemList.typeMasItem(llngRowCnt - 1).strItemID)
                            
                            '@不良名称
                            .SetData(.Rows.Count - 1, CMlngvsfLotScrapInfoColScrapName, _
                                ptypMasItemList.typeMasItem(llngRowCnt - 1).strItemName)
                            
                            '@WF枚数分ﾙｰﾌﾟ(配列のﾙｰﾌﾟ(WF))
                            For llngWFcnt = 0 To ptypLotScrapInfo.typWFScrapInfo.Count - 1
                                
                                '@不良項目数分ﾙｰﾌﾟ(配列のﾙｰﾌﾟ(不良情報))
                                For llngScrapCodeCnt = 0 To ptypLotScrapInfo.typWFScrapInfo(llngWFcnt).typNowScrapList.Count - 1
                                
                                    '@ｸﾞﾘｯﾄﾞの表示不良ｺｰﾄﾞと配列内の不良ｺｰﾄﾞが同じ場合
                                    If .GetData(.Rows.Count - 1, CMlngvsfLotScrapInfoColScrapCode) = _
                                        ptypLotScrapInfo.typWFScrapInfo(llngWFcnt).typNowScrapList(llngScrapCodeCnt).strScrapCode Then
                                
                                        '@不良数
                                        If ptypLotScrapInfo.typWFScrapInfo(llngWFcnt).typNowScrapList(llngScrapCodeCnt).strScrapNum _
                                            <> CPstrZero Then
                                            '@"0"以外の場合
                                            
                                            lstrScrapCode2 = ptypLotScrapInfo.typWFScrapInfo(llngWFcnt).typNowScrapList(llngScrapCodeCnt).strScrapCode
                                            
                                            '@選択ｺｰﾄﾞが"払出ｺｰﾄﾞ"以外か
                                            If lstrScrapCode2 <> CPstrForwardCode Then
                                                '@払出ｺｰﾄﾞ以外(=不良ｺｰﾄﾞ)の場合
                                            
                                                .SetData(.Rows.Count - 1, llngWFcnt + CMlngvsfFrozenCol + 1, _
                                                    ptypLotScrapInfo.typWFScrapInfo(llngWFcnt).typNowScrapList(llngScrapCodeCnt).strScrapNum)
                                                
                                                '@ｺｰﾄﾞ別不良数の計上
                                                mlngLotScrapCnt = mlngLotScrapCnt + .GetData(.Rows.Count - 1, llngWFcnt + CMlngvsfFrozenCol + 1)
                                            End If
                                        Else
                                            
                                            '@"0"の場合はNULLで表示
                                            .SetData(.Rows.Count - 1, llngWFcnt + CMlngvsfFrozenCol + 1, vbNullString)
                                        End If
                                        
                                        Exit For
                                    End If
                                Next llngScrapCodeCnt
                            Next llngWFcnt
                            
                            '@ﾛｯﾄ合計数
                            If ptypLotScrapInfo.strLotOutQuantity <> CPstrZero Then
                                '@"0"以外の場合
                                
                                .SetData(.Rows.Count - 1, CMlngvsfLotScrapInfoColLotTotal, mlngLotScrapCnt)
                            Else
                                
                                '@"0"の場合はNULLで表示
                                .SetData(.Rows.Count - 1, CMlngvsfLotScrapInfoColLotTotal, vbNullString)
                            End If
            
                            '@不良ｺｰﾄﾞ毎の不良率の計算
                            If IsNumeric(.GetData(.Rows.Count - 1, CMlngvsfLotScrapInfoColLotTotal)) = True Then
                                
                                If ptypLotScrapInfo.lngScrapInputBeforeChipCnt > 0 Then
                                    
                                    '@不良率＝不良数÷不良入力前良品数(前工程迄)×100
                                    lcurLotScrapRate = .GetData(.Rows.Count - 1, CMlngvsfLotScrapInfoColLotTotal) / _
                                                        ptypLotScrapInfo.lngScrapInputBeforeChipCnt * CMlngTotalScrapRate100
                                    If lcurLotScrapRate <> 0 Then
                                        '@不良率の四捨五入設定
                                        .SetData(.Rows.Count - 1, CMlngvsfLotScrapInfoColLotScrapRate, _
                                            Math.Round(lcurLotScrapRate, CMlngTotalScrapRateRoundPos2))
                                    Else
                                        'NSYS 0の場合はNULLで表示
                                        .SetData(.Rows.Count - 1, CMlngvsfLotScrapInfoColLotScrapRate, vbNullString)
                                    End If
                                End If
                            End If
                            
                            '@ｺｰﾄﾞ別不良数ｶｳﾝﾀの初期化
                            mlngLotScrapCnt = 0
                        Else
                            
                        End If
                       
                    Next llngRowCnt
                        
                    '@【合計】文字表示
                    .SetData(CMlngvsfFrezonRow, CMlngvsfLotScrapInfoColScrapName, CMstrTotalTitle)
                    
                    '@合計数の表示
                    '@全列の合計計算(非表示項目は含めない)
                    For llngColCnt = CMlngvsfLotScrapInfoColLotTotal To .Cols.Count - 1
                        
                        '@表示列の場合
                        If .Cols(llngColCnt).Visible = True Then
                            
                            '@合計計算列の判定
                            If llngColCnt = CMlngvsfLotScrapInfoColLotScrapRate Then
                                
                                '@総合計の不良率の計算
                                If IsNumeric(.GetData(CMlngvsfFrezonRow, CMlngvsfLotScrapInfoColLotTotal)) = True Then
                                    
                                    If ptypLotScrapInfo.lngScrapInputBeforeChipCnt > 0 Then
                                        
                                        '@不良率＝不良数÷不良入力前良品数(前工程迄)×100
                                        lcurLotScrapRate = .GetData(CMlngvsfFrezonRow, CMlngvsfLotScrapInfoColLotTotal) / _
                                                            ptypLotScrapInfo.lngScrapInputBeforeChipCnt * CMlngTotalScrapRate100
                                        If lcurLotScrapRate <> 0 Then
                                            '@不良率の四捨五入設定
                                            .SetData(CMlngvsfFrezonRow, CMlngvsfLotScrapInfoColLotScrapRate, _
                                                Math.Round(lcurLotScrapRate, CMlngTotalScrapRateRoundPos2))
                                        Else
                                            '0の場合はNULLで表示
                                            .SetData(.Rows.Count - 1, CMlngvsfLotScrapInfoColLotScrapRate, vbNullString)
                                        End If
                                    End If
                                End If
                            Else
                                '@列合計(総合計、WF合計)の算出
                                
                                '@合計数の初期化
                                llngColTotal = 0
                                For llngRowCnt = CMlngvsfFrezonRow + 1 To .Rows.Count - 1
                                    
                                    If IsNumeric(.GetData(llngRowCnt, llngColCnt)) = True Then
                                        '@列合計へ加算
                                        llngColTotal = llngColTotal + .GetData(llngRowCnt, llngColCnt)
                                    End If
                                Next llngRowCnt
                                
                                '@列合計(総合計、WF合計)の表示
                                If llngColTotal > 0 Then
                                    .SetData(CMlngvsfFrezonRow, llngColCnt, llngColTotal)
                                End If
                            End If
                        End If
                    Next llngColCnt
                    

                    '@固定行設定
                    .Rows.Fixed = CMlngvsfFrezonRow + 1
                    
                    Dim newStyle_Sum As CellStyle = .Styles.Add("CustomStyle_Sum_Text_Color")
                    '@文字位置設定
                    newStyle_Sum.TextAlign = TextAlignEnum.CenterCenter
                    '@背景色設定
                    newStyle_Sum.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngTotalBackColor))
                    '@文字色設定
                    newStyle_Sum.ForeColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngTotalForeColor))
                    
                    Dim cellRange As CellRange = .GetCellRange( CMlngvsfFrezonRow, CMlngvsfLotScrapInfoColScrapCode, _
                                            CMlngvsfFrezonRow, CMlngvsfLotScrapInfoColScrapName)
                    cellRange.Style = newStyle_Sum
                    

                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_Text_Color")
                    '@文字位置設定
                    newStyle.TextAlign = TextAlignEnum.RightCenter
                    '@背景色設定
                    newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngTotalBackColor))
                    '@文字色設定
                    newStyle.ForeColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngTotalForeColor))
                    newStyle.Format = CMstrTotalKnmaFormat
                    cellRange = .GetCellRange( CMlngvsfFrezonRow, CMlngvsfLotScrapInfoColLotTotal, _
                                            CMlngvsfFrezonRow, .Cols.Count - 1)
                    cellRange.Style = newStyle
                    
                    Dim newStyle_Rate As CellStyle = .Styles.Add("CustomStyle_Rate_Format")
                    '@文字位置設定
                    newStyle_Rate.TextAlign = TextAlignEnum.RightCenter
                    '@newStyle_Rate
                    newStyle_Rate.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngTotalBackColor))
                    '@文字色設定
                    newStyle_Rate.ForeColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngTotalForeColor))
                    newStyle_Rate.Format = CMstrTotalFormatRate
                    cellRange = .GetCellRange( CMlngvsfFrezonRow, CMlngvsfLotScrapInfoColLotScrapRate)
                    cellRange.Style = newStyle_Rate
                    
                    '@明細の行の高さ
                    For i As Integer = 0 To .Rows.Count - 1 
                        .Rows(i).Height = CMlngGridRowHeight
                    Next
            
                    '@ﾀｲﾄﾙの行の高さ
                    .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight
            
                    '@=======================
                    '@ 左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御処理(ｸﾞﾘｯﾄﾞ共通化関数)
                    '@=======================
                    Call pubCmdLREnable_Set(vsfLotScrapInfo, cmdLeft, cmdRight)

                    '@描画の再開
                    .Redraw = True
            
                    '@ﾃﾞｰﾀがある場合
                    If .Rows.Count > .Rows.Fixed Then
                        
                        '@ｸﾞﾘｯﾄﾞを有効に
                        .Enabled = True
                    End If

                    '@=======================
                    '@ 上下ｽｸﾛｰﾙﾎﾞﾀﾝ制御処理(ｸﾞﾘｯﾄﾞ共通化関数)
                    '@=======================
                    Call pubVsfDisp(vsfLotScrapInfo, cmdNextUP, cmdNextDown)
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰの場合はFalseで再起動可にする
            mblnActivateFlag = False

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvVsfLotScrapInfo_Disp"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvPakenWfIdColor
    '機　能：親画面のWF_IDの色を見て確定済(赤の太字)なら本画面のWF_IDも確定済表示とする
    '引　数：なし
    '戻り値：
    '作成日：2016/12/09 (Fri) 16:54:08 T.Oide
    '更新日：2016/12/09 (Fri) 16:54:08
    '備　考：
    Private Sub prvPakenWfIdColor()
        
        Dim llngCnt         As Integer
        Dim llngCnt2        As Integer
        Dim lblnMikakutei   As Boolean
        
        Try
            
            '@初期化
            lblnMikakutei = False
            
            '@WF_IDの列を回す
            For llngCnt = CMlngvsfLotScrapInfoColLotScrapRate + 1 To vsfLotScrapInfo.Cols.Count - 1
                
                '@非表示列か(非表示列は対象外)
                If vsfLotScrapInfo.Cols(llngCnt).Visible = False Then
                    Exit For
                End If
                
                '@親画面のWF_IDのｸﾞﾘｯﾄﾞで回してWF_IDを探す
                For llngCnt2 = 1 To frmxxCM0080.Instance.vsfWFMap.Rows.Count - 1
                
                    '@WF_IDは同じか
                    If frmxxCM0080.Instance.vsfWFMap.GetData(llngCnt2, CMlngvsfWFMapID) = _
                       vsfLotScrapInfo.GetData(CMlngGridRowTitle, llngCnt) Then
                
                        '@親画面のWF_IDは赤字の太字か
                        If frmxxCM0080.Instance.vsfWFMap.GetCellRange(llngCnt2, CMlngvsfWFMapID).StyleDisplay.ForeColor = Color.Red And _
                           frmxxCM0080.Instance.vsfWFMap.GetCellRange(llngCnt2, CMlngvsfWFMapID).StyleDisplay.Font.Bold = True Then
                           
                            '@子画面のWF_IDも赤字の太字にする
                            Dim newStyle As CellStyle = vsfLotScrapInfo.Styles.Add("CustomStyle_ForeColor_vbRed")
                            newStyle.ForeColor = Color.Red
                            Dim cellRange As CellRange = vsfLotScrapInfo.GetCellRange(CMlngGridRowTitle, llngCnt)
                            cellRange.Style = newStyle
                            'vsfLotScrapInfo.Cell(flexcpFontBold, CMlngGridRowTitle, llngCnt) = True
                            'vsfLotScrapInfo.ColWidth(llngCnt) = CMlngvsfLotScrapInfoColWWFID_Bold          '幅調整
                        
                        Else
                            '@未確定あり
                            lblnMikakutei = True
                            
                        End If
                    End If
                Next
            Next
            
            '@未確定ありの注意ラベル表示
            labMikakutei.Visible = True
            If lblnMikakutei = True Then
                labMikakutei.Text = CMstrMikakutei
                labMikakutei.ForeColor = Color.Red
            Else
                labMikakutei.Text = CMstrKakuteisumi
                labMikakutei.ForeColor = Color.Blue
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvPakenWfIdColor"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfLotScrapInfo.BeforeDoubleClick

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
