'ﾌｧｲﾙ名：xxEN00Y1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：リワーク原因設定　メインフォーム
'作成日：2005/08/17 (Wed) 08:57:11 S.Deguchi
'更新日：2011/09/28 (Wed) 09:46:10 H.Hayashi
'備　考：
'　　　：2007/07/26 (Thu) 11:00:05 N.Kasai      ｿｰｽ整備
'      ：2011/09/28 (Wed) 09:46:10 H.Hayashi    ﾘﾜｰｸ原因(小分類)設定が必須化に伴う修正。
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00Y1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00Y1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00Y1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00Y1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00Y1)
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
    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN00Y1      'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_reworkreasonVer          As String = "01.00"             'ﾘﾜｰｸ理由取得
    Private Const CMstrmas_reworksubreasonVer       As String = "01.00"             'ﾘﾜｰｸ理由(小分類)取得
    Private Const CMstrlot_hold____Ver              As String = "02.01"             'ﾛｯﾄ保留設定
    Private Const CMstrexcpchgreportVer             As String = "01.00"             '工程異常/不適合品処理票登録

    '@理由ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                  As Integer = 16                 'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 16                 'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridCol0                  As Integer = 0                  'ｺﾝﾎﾞ列番(0列目：ﾃｷｽﾄ部)
    Private Const CMlngCmbGridCol1                  As Integer = 1                  'ｺﾝﾎﾞ列番(1列目：非表示項目)
    Private Const CMlngCmbSortAsc                   As Integer = 1                  '昇順(ｿｰﾄ)
    Private Const CMlngCmbDispCols                  As Integer = 1                  'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                 As Integer = 43                 'ﾘｽﾄ行の高さ
    Private Const CMlngCmbFirstListIndex            As Integer = 0                  '1件目のﾃﾞｰﾀ表示用
    Private Const CMlngCmbValueCol0                 As Integer = 0                  'ｸﾞﾘｯﾄﾞ情報設定列0
    Private Const CMlngCmbValueCol1                 As Integer = 1                  'ｸﾞﾘｯﾄﾞ情報設定列1
    Private Const CMlngCmbValueCol2                 As Integer = 2                  'ｸﾞﾘｯﾄﾞ情報設定列2
    Private Const CMlngCmbValueCol3                 As Integer = 3                  'ｸﾞﾘｯﾄﾞ情報設定列3

    '@定数宣言
    Private Const CMlngIndex0                       As Integer = 0
    Private Const CMlngIndex1                       As Integer = 1
    Private Const CMlngoptTroubleLot                As Integer = 0                  '工程異常処理(ﾛｯﾄ)
    Private Const CMstrTroubleFlag                  As String = "0"                 '工程異常処理ﾌﾗｸﾞ
    Private Const CMstrIncongFlag                   As String = "1"                 '不適合品処理ﾌﾗｸﾞ
    Private Const CMstrUnitWF                       As String = "1"                 '単位：WF
    Private Const CMstrUnitChip                     As String = "2"                 '単位：Chip
    Private Const CMstrDispose                      As String = "0"                 '処置ﾌﾗｸﾞの初期値：未処置
    Private Const CMstrCFFlag_WF                    As String = "0"                 'CFﾌﾗｸﾞ：WF(0)
    Private Const CMstrCFFlag_CF                    As String = "1"                 'CFﾌﾗｸﾞ：CF(1)
    Private Const CMstrCFFlag_All                   As String = "2"                 'CFﾌﾗｸﾞ：ALL(2)
    Private Const CMstrReworkJ                      As String = "リワーク"
    Private Const CMstrDefault0                     As String = "0"                 '初期設定値(=0)
    Private Const CMstrDefault1                     As String = "1"                 '初期設定値(=1)
    Private Const CMlngDefault1                     As Integer = 1                  '初期設定値(=1)
    Private Const CMlngDefault2                     As Integer = 2                  '初期設定値(=2)
    Private Const CMstrLpFlagTpal                   As String = "0"                 'LPﾌﾗｸﾞ：小板
    Private Const CMstrLpFlagOdf                    As String = "1"                 'LPﾌﾗｸﾞ：大板

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                     As String = "frmxxEN00Y1"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                     As String = "Form_Load"                 'ﾌｫｰﾑ起動時処理
    Private Const CMstrCmdRegistClick               As String = "cmdRegist_Click"           '確定ﾎﾞﾀﾝ押下時処理
    Private Const CMstrPrvReasonSubCodeGetProc      As String = "prvReasonSubCodeGet_Proc"  'ﾘﾜｰｸ原因(小分類)取得処理
    Private Const CMstrPrvblnExcpChgReportIns       As String = "prvblnExcpChgReport_Ins"   '工程異常/不適合品処理票登録処理

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mblnFormLoadFlag                        As Boolean                      'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：表示済、False：未完)
    Private mstrReasonCode                          As String                       '理由ｺｰﾄﾞ退避領域
    Private mtypReasonCodeList                      As ReasonCode                   '理由ｺｰﾄﾞ格納用構造体
    Private mtypReasonSubCodeList                   As ReasonSubCode                '理由ｺｰﾄﾞ(小分類)格納用構造体
    Private mtypLotReworkSet                        As LotReWorkSet                 'ﾛｯﾄ作業終了構造体
    Private mtypReworkInfoList                      As ReworkInfoList               'ﾘﾜｰｸ情報引継構造体
    Private mstrFindDate                            As String                       '発見日時退避領域
    Private mstrEmpID                               As String                       '発見者ID退避領域
    Private mstrEmpName                             As String                       '発見者名退避領域
    Private mstrDeptID                              As String                       '発見職場ID退避領域
    Private mstrDeptName                            As String                       '発見職場名退避領域
    Private buttonProcessing                        As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                      'NSYS WindowCloseフラグ

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
    '======================================Private==========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：
    '作成日：2005/08/17 (Wed) 08:58:17 S.Deguchi
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2008/07/28 (Mon) 16:21:13 N.Kojima     理由ｺｰﾄﾞ(小分類)選択ｺﾝﾎﾞ追加に伴う修正。(案件№03007)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub Form_Load()

        Dim lblnAns         As Boolean              '結果判定

        Try

            '@Escﾎﾞﾀﾝを無効にする
            '@　※ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない為
            Me.CancelButton = Nothing
            
            '@=======================
            '@ 画面情報初期化処理
            '@=======================
            Call prvfrmxxEN00Y1_Init()

            '@ﾌｫｰﾑﾛｰﾄﾞ済みﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@=======================
            '@ ﾘﾜｰｸ原因ｺｰﾄﾞ取得
            '@=======================
            lblnAns = pubblnMasReworkReson_Sel(CMstrmas_reworkreasonVer, _
                                               mtypReasonCodeList)
            
            '@ﾘﾜｰｸ原因ｺｰﾄﾞ取得結果判定
            If lblnAns = False Then
                '@ﾘﾜｰｸ原因ｺｰﾄﾞ取得結果：異常(失敗)の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@Escﾎﾞﾀﾝを有効にし、起動処理中断
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            
            '@引継ﾌﾗｸﾞに"True：起動成功"をｾｯﾄ
            pblnfrmxxEN00Y0Kbn = True

            'NSYS 背景色
            cmbReasonSubCode.BackColor = Color.White 
            
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

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/17 (Wed) 13:44:25 S.Deguchi
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2008/07/28 (Mon) 16:21:13 N.Kojima     理由ｺｰﾄﾞ(小分類)選択ｺﾝﾎﾞ追加に伴う修正。(案件№03007)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞ済ﾌﾗｸﾞが"False：未表示"か
            If mblnFormLoadFlag = False Then
            
                '@ﾌｫｰﾑﾛｰﾄﾞ済ﾌﾗｸﾞに"True：表示済"をｾｯﾄ
                mblnFormLoadFlag = True
                
                '@Escﾎﾞﾀﾝを有効にする
                Me.CancelButton = cmdClose
                
                '@ﾊﾟﾌﾞﾘｯｸ構造体に格納されている引継ぎ情報を、ﾓｼﾞｭｰﾙ構造体へ退避
                mtypLotReworkSet = ptypLotReworkSet
                mtypReworkInfoList = ptypReworkInfoList
                
                '@=======================
                '@ ﾘﾜｰｸ原因(大分類)ｺﾝﾎﾞ作成処理
                '@=======================
                Call prvCmbReasonCode_Disp()
                
                '@ﾘﾜｰｸ原因(大分類)ﾘｽﾄが1件か
                If mtypReasonCodeList.lngReasonCodeListCnt = 1 Then
                
                    '@1件の場合は直接表示する
                    cmbReasonCode.ListIndex = 0
                    
                    '@=======================
                    '@ ﾘﾜｰｸ原因(小分類)取得処理
                    '@=======================
                    Call prvReasonSubCodeGet_Proc()
                    
                    '@確定ﾎﾞﾀﾝが有効か
                    If cmdRegist.Enabled = True Then
                    
                        '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdRegist)
                        Exit Sub
                    End If
                End If
                
                '@ﾘﾜｰｸ原因(大分類)ｺﾝﾎﾞが有効か
                If cmbReasonCode.Enabled = True Then
                
                    '@ﾘﾜｰｸ原因(大分類)ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbReasonCode)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Activate"
                .strErrMessage = vbNullString
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
    '作成日：2005/08/17 (Wed) 08:58:31 S.Deguchi
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2008/07/28 (Mon) 16:21:13 N.Kojima     理由ｺｰﾄﾞ(小分類)選択ｺﾝﾎﾞ追加に伴う修正。(案件№03007)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@以下の条件の場合、Key入力を無効にし処理中断
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If

            '@★ 押下されたｷｰにより処理分岐 ★
            Select Case e.KeyCode

                '@〓 Enterｷｰ 〓
                Case Keys.Return

                    '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                    Select Case ActiveControl.Name
                    
                        '@〓〓 ﾘﾜｰｸ原因(大分類) 〓〓
                        Case cmbReasonCode.Name
                            
                            '@=======================
                            '@ ﾘﾜｰｸ原因(大分類)ｺﾝﾎﾞのValidate処理
                            '@=======================
                            RemoveHandler cmbReasonCode.Validating,AddressOf cmbReasonCode_Validate
                            Call cmbReasonCode_Validate(cmbReasonCode, New CancelEventArgs(False))
                            AddHandler cmbReasonCode.Validating,AddressOf cmbReasonCode_Validate

                        '@〓〓 ﾘﾜｰｸ原因(小分類) 〓〓
                        Case cmbReasonSubCode.Name
                            
                            '@=======================
                            '@ ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞのValidate処理
                            '@=======================
                            RemoveHandler cmbReasonSubCode.Validating,AddressOf cmbReasonSubCode_Validate
                            Call cmbReasonSubCode_Validate(cmbReasonSubCode, New CancelEventArgs(False))
                            AddHandler cmbReasonSubCode.Validating,AddressOf cmbReasonSubCode_Validate

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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：(True：終了ｷｬﾝｾﾙ、False：終了)
    '　　　：UnloadMode ：(0:×ﾎﾞﾀﾝ終了、1：閉じるﾎﾞﾀﾝ終了)
    '戻り値：なし
    '作成日：2005/08/17 (Wed) 08:58:42 S.Deguchi
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2008/07/28 (Mon) 16:21:13 N.Kojima     理由ｺｰﾄﾞ(小分類)選択ｺﾝﾎﾞ追加に伴う修正。(案件№03007)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾌｫｰﾑの"×"にて画面を閉じた場合、閉じるﾎﾞﾀﾝ押下時処理をCALLする
            If mblnCloseFromControlMenu Then
            
                '@=======================
                '@ 閉じるﾎﾞﾀﾝ押下時処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender, e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
            
                '@終了処理をｷｬﾝｾﾙする
                e.Cancel = True
                Exit Sub
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbReasonCode_Change
    '機　能：ﾘﾜｰｸ原因(大分類)ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/23 (Tue) 16:35:40 S.Deguchi
    '更新日：2011/09/28 (Wed) 09:46:10 H.Hayashi
    '備　考：
    '　　　：2008/07/28 (Mon) 16:21:13 N.Kojima     理由ｺｰﾄﾞ(小分類)選択ｺﾝﾎﾞ追加に伴う修正。(案件№03007)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    '　　　：2011/09/28 (Wed) 09:46:10 H.Hayashi    ﾘﾜｰｸ原因(小分類)設定が必須化に伴う修正。
    Private Sub cmbReasonCode_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbReasonCode.Change

        Try

            '@ﾘﾜｰｸ原因(大分類)が選択されているか
            If cmbReasonCode.Text <> vbNullString Then
                
                '@***********************
                '@ ｵﾌﾟｼｮﾝﾎﾞﾀﾝの制御
                '@***********************
                '@値取得列を「保留ﾌﾗｸﾞ」列に変更
                cmbReasonCode.ValueCol = CMlngCmbValueCol2
                
                '@保留ﾌﾗｸﾞが"0：保留なし"か
                If cmbReasonCode.Value = CMstrDefault0 Then
                
                    optHold0.Checked = False                    'ﾁｪｯｸなし   ：保留あり
                    optHold1.Checked = True                     'ﾁｪｯｸあり   ：保留なし
                    optHold0.Enabled = False                    '無効       ：保留あり
                    optHold1.Enabled = True                     '有効       ：保留なし
                Else
                    '@保留ﾌﾗｸﾞが"0：保留なし"以外の場合
                
                    optHold0.Checked = True                     'ﾁｪｯｸあり   ：保留あり
                    optHold1.Checked = False                    'ﾁｪｯｸなし   ：保留なし
                    optHold0.Enabled = True                     '有効       ：保留あり
                    optHold1.Enabled = False                    '無効       ：保留なし
                End If
                
                
                '@値取得列を「工程異常/不適合処理票発行ﾌﾗｸﾞ」列に変更
                cmbReasonCode.ValueCol = CMlngCmbValueCol3
                
                '@工程異常/不適合処理票発行ﾌﾗｸﾞが"0：発行なし"か
                If cmbReasonCode.Value = CMstrDefault0 Then
                
                    optExcpReport0.Checked = False              'ﾁｪｯｸなし   ：工程異常/不適合処理票発行あり
                    optExcpReport1.Checked = True               'ﾁｪｯｸあり   ：工程異常/不適合処理票発行なし
                    optExcpReport0.Enabled = False              '無効       ：工程異常/不適合処理票発行あり
                    optExcpReport1.Enabled = True               '有効       ：工程異常/不適合処理票発行なし
                Else
                    '@工程異常/不適合処理票発行ﾌﾗｸﾞが"0：発行なし"以外か
                
                    optExcpReport0.Checked = True               'ﾁｪｯｸあり   ：工程異常/不適合処理票発行あり
                    optExcpReport1.Checked = False              'ﾁｪｯｸなし   ：工程異常/不適合処理票発行なし
                    optExcpReport0.Enabled = True               '有効       ：工程異常/不適合処理票発行あり
                    optExcpReport1.Enabled = False              '無効       ：工程異常/不適合処理票発行なし
                End If
                
                '@値取得列を戻す
                cmbReasonCode.ValueCol = CMlngCmbValueCol1
                
                '@ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞを有効にする
                cmbReasonSubCode.Clear
                cmbReasonSubCode.Enabled = True
                
        '@↓2011/09/28 (Wed) 09:46:10 H.Hayashi **************************************************
        '        '@確定ﾎﾞﾀﾝを有効にする
        '        cmdRegist.Enabled = True
        '@↑2011/09/28 (Wed) 09:46:10 H.Hayashi **************************************************
                
            Else
                '@ﾘﾜｰｸ原因(大分類)が未選択の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbReasonCode_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbReasonCode_CloseUp
    '機　能：ﾘﾜｰｸ原因(大分類)ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/07/29 (Tue) 11:37:30 N.Kojima
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub cmbReasonCode_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbReasonCode.CloseUp

        Try
            
            '@ﾘﾜｰｸ原因(大分類)がNULL以外か
            If cmbReasonCode.Text <> vbNullString Then
                
                '@=======================
                '@ ﾘﾜｰｸ原因(大分類)ｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbReasonCode.Validating,AddressOf cmbReasonCode_Validate
                Call cmbReasonCode_Validate(cmbReasonCode, New CancelEventArgs(True))
                AddHandler cmbReasonCode.Validating,AddressOf cmbReasonCode_Validate
            End If
          
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbReasonCode_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbReasonCode_Validate
    '機　能：ﾘﾜｰｸ原因(大分類)ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/07/29 (Tue) 11:38:01 N.Kojima
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub cmbReasonCode_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbReasonCode.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@値取得列を「理由ｺｰﾄﾞ」列に変更
            cmbReasonCode.ValueCol = CMlngCmbValueCol1
            
            '@ﾘﾜｰｸ原因(大分類)がNULLか
            If cmbReasonCode.Value = vbNullString Then
                '@NULLの場合
                
                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = cmbReasonCode.Name Then
                    Call pubSetFocus(cmdClose)
                End If
            Else
                '@NULL以外の場合
                
                '@選択ﾘﾜｰｸ原因(大分類)が退避ﾘﾜｰｸ原因(大分類)と異なるか
                If cmbReasonCode.Value <> mstrReasonCode Then
                    '@異なる場合
                    
                    '@=======================
                    '@ ﾘﾜｰｸ原因(小分類)取得処理
                    '@=======================
                    Call prvReasonSubCodeGet_Proc()
                    
                    '@ﾘﾜｰｸ原因(小分類)が1件か
                    If mtypReasonSubCodeList.lngReasonSubCodeListCnt = 1 Then
                        Exit Sub
                    End If
                End If
                
                '@ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞが有効か
                If cmbReasonSubCode.Enabled = True Then

                    '@ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbReasonCode.Name Then
                        Call pubSetFocus(cmbReasonSubCode)
                    End If
                Else
                    '@確定ﾎﾞﾀﾝが有効か
                    If cmdRegist.Enabled = True Then

                        '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = cmbReasonCode.Name Then
                            Call pubSetFocus(cmdRegist)
                        End If
                    Else
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = cmbReasonCode.Name Then
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbReasonCode_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2011/09/28 (Wed) 09:41:11 H.Hayashi **************************************************
    '関数名：cmbReasonSubCode_Change
    '機　能：ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/07/29 (Tue) 11:38:12 N.Kojima
    '更新日：2011/09/28 (Wed) 09:41:11 H.Hayashi
    '備　考：
    '      ：2011/09/28 (Wed) 09:41:11 H.Hayashi　　ﾘﾜｰｸ原因(小分類)設定が必須化に伴う修正。
    Private Sub cmbReasonSubCode_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbReasonSubCode.Change

        Try

            '@ﾘﾜｰｸ原因(大分類)、ﾘﾜｰｸ原因(小分類)が選択されているか
            If cmbReasonCode.Text <> vbNullString And _
                cmbReasonSubCode.Text <> vbNullString Then
                '@選択されている場合

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
                .strProcName = "cmbReasonSubCode_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2011/09/28 (Wed) 09:41:11 H.Hayashi **************************************************


    '関数名：cmbReasonSubCode_CloseUp
    '機　能：ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/07/29 (Tue) 11:37:30 N.Kojima
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub cmbReasonSubCode_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbReasonSubCode.CloseUp

        Try
            
            '@ﾘﾜｰｸ原因(小分類)がNULL以外か
            If cmbReasonSubCode.Text <> vbNullString Then
                
                '@=======================
                '@ ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbReasonSubCode.Validating,AddressOf cmbReasonSubCode_Validate
                Call cmbReasonSubCode_Validate(cmbReasonSubCode, New CancelEventArgs(True))
                AddHandler cmbReasonSubCode.Validating,AddressOf cmbReasonSubCode_Validate
            End If
          
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbReasonSubCode_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbReasonSubCode_Validate
    '機　能：ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞ　変更時処理
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/07/29 (Tue) 11:38:12 N.Kojima
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub cmbReasonSubCode_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbReasonSubCode.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@★ 有効なｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case True

                '@〓 確定ﾎﾞﾀﾝ 〓
                Case cmdRegist.Enabled

                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbReasonSubCode.Name Then
                        Call pubSetFocus(cmdRegist)
                    End If

                '@〓 その他 〓
                Case Else

                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbReasonSubCode.Name Then
                        Call pubSetFocus(cmdClose)
                    End If

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbReasonSubCode_Validate"
                .strErrMessage = vbNullString
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
    '作成日：2005/08/17 (Wed) 10:11:21 S.Deguchi
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2008/07/28 (Mon) 16:21:13 N.Kojima     理由ｺｰﾄﾞ(小分類)選択ｺﾝﾎﾞ追加に伴う修正。(案件№03007)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾘﾜｰｸ情報引継ぎ構造体の初期化
            With mtypReworkInfoList
                .strExcpNo = vbNullString       '工程異常/不適合処理品№
                .strLotID = vbNullString        'ﾛｯﾄID
            End With
            
            '@ﾘﾜｰｸ情報をﾊﾟﾌﾞﾘｯｸ構造体(画面間引継ぎ用)へｾｯﾄ
            ptypReworkInfoList = mtypReworkInfoList
            
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
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/17 (Wed) 10:12:01 S.Deguchi
    '更新日：2009/08/11 (Tue) 10:29:20 N.Kojima
    '備　考：
    '　　　：2005/09/20 (Tue) 09:05:17 S.Deguchi    運用障害№540の対応で特殊流動Msgにﾘﾜｰｸ理由を追加
    '　　　：2005/12/16 (Fri) 14:10:13 S.Deguchi    種別による保留期限設定を修正
    '　　　：2008/07/28 (Mon) 16:21:13 N.Kojima     理由ｺｰﾄﾞ(小分類)選択ｺﾝﾎﾞ追加に伴う修正。(案件№03007)
    '　　　：2009/08/11 (Tue) 10:29:20 N.Kojima     試作実験ﾛｯﾄの場合、確定時に検査工数削減のMsgを表示する。(案件№03542)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '戻り値
        Dim lstrLotID               As String               '特殊流動ﾛｯﾄID
        Dim lstrTempDate            As String               '現在日退避(XXXX/YY/ZZ)
        Dim ltypLotHoldset          As LotHoldset           'ﾛｯﾄ保留設定要求格納用
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrExcpNo              As String               '登録異常処理№
        Dim lstrMsg                 As String               '変換後ﾒｯｾｰｼﾞ
        Dim lstrMsg3                As String               'ﾒｯｾｰｼﾞ:%3

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の場合、確定処理を中断する
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑのﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then
                
                Exit Sub
            End If
            
            '@***********************
            '@ 確定前ﾁｪｯｸ＆送信ﾃﾞｰﾀ格納(大分類は必須、小分類は任意)
            '@***********************
            '@ﾘﾜｰｸ原因(大分類)が未選択か
            If cmbReasonCode.Text = vbNullString Then

                '@ﾒｯｾｰｼﾞ変換処理
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006P)
                '@ﾒｯｾｰｼﾞ表示："<TRM6PW>$$リワーク原因が設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾘﾜｰｸ原因(大分類)ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbReasonCode)
                Exit Sub
            Else
                '@ﾘﾜｰｸ原因(大分類)が選択されている場合
                
                '@ﾘﾜｰｸ原因(大分類)ｺｰﾄﾞ(理由ｺｰﾄﾞ)を構造体にｾｯﾄ
                mtypLotReworkSet.strReworkReason = mstrReasonCode
            End If
            
            '@ﾘﾜｰｸ原因(小分類)が選択されているか
            If cmbReasonSubCode.Text <> vbNullString Then
            
                '@ﾘﾜｰｸ原因(小分類)ｺｰﾄﾞ(理由ｺｰﾄﾞ)を構造体にｾｯﾄ
                mtypLotReworkSet.strReworkSubReason = cmbReasonSubCode.Value
            Else
                '@ﾘﾜｰｸ原因(小分類)ｺｰﾄﾞ(理由ｺｰﾄﾞ)を構造体にｾｯﾄ
                mtypLotReworkSet.strReworkSubReason = vbNullString
            End If

            '@発見日時を退避領域にｾｯﾄ
            mstrFindDate = Format$(Now, CPstrDateTimeYMDHMS)
            
            '@ﾒｯｾｰｼﾞ用文字列
            lstrMsg3 = CMstrReworkJ
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@作業者ｺｰﾄﾞ入力画面で"ｷｬﾝｾﾙ"ﾎﾞﾀﾝが押下されたか
            If pblnCancel = True Then
                Exit Sub
            Else
                '@作業者ｺｰﾄﾞ入力画面で"確定"ﾎﾞﾀﾝ押下の場合
            
                '@取得情報を内部変数へ退避
                mstrEmpID = pstrUserID                  '作業者ID
                mstrEmpName = pstrUserName              '作業者名
                mstrDeptID = pstrDeptID                 '作業者職場ID
                mstrDeptName = pstrDeptName             '作業者職場名
                mtypLotReworkSet.strEmpID = pstrUserID  '作業者ID
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
            
            '@移載工程ｽｷｯﾌﾟﾌﾗｸﾞが"0：移載あり"か
            If mtypLotReworkSet.strMoveSkip = CPstrZero Then
                
                '@=======================
                '@ 特殊流動登録(移載工程ありVer)
                '@=======================
                lblnAns = pubblnLotReworkSet_Upd(mtypLotReworkSet, _
                                                 lstrLotID, _
                                                 lstrGuidMsg, _
                                                 lstrGuidMsgCode)

            Else
                '@"1：移載なし"の場合
            
                '@=======================
                '@ 特殊流動登録(移載工程なしVer)
                '@=======================
                lblnAns = pubblnLotReworkSetDirect_Upd(mtypLotReworkSet, _
                                                       lstrLotID, _
                                                       lstrGuidMsg, _
                                                       lstrGuidMsgCode)

            End If          
            
            '@特殊流動登録結果が"True：登録成功"か
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                
                '@=======================
                '@ ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ表示制御処理
                '@=======================
                Call pubGuidMsg_Set(lstrGuidMsgCode, lstrGuidMsg, Me)
                
                '@WF全選択、または分割ﾌﾗｸﾞが"0：分割無"か
                If mtypReworkInfoList.blnSelectFlag = True Or _
                    mtypLotReworkSet.strDivFlag = CPstrZero Then
                    '@全選択または部分(分割無)の場合
                    
                    '@ﾒｯｾｰｼﾞ表示："<TRM1LI>$$%3工程に送出しました。キャリア[%1] ロット[%2]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001L, mtypLotReworkSet.strCarrierId, lstrLotID, lstrMsg3)
                    
                Else
                    '@WF部分選択、または分割ﾌﾗｸﾞが"1：分割有"の場合

                    '@移載工程ｽｷｯﾌﾟﾌﾗｸﾞが"0：移載あり"か
                    If mtypLotReworkSet.strMoveSkip = CPstrZero Then
                    
                        '@ﾒｯｾｰｼﾞ表示："<TRM1MI>$$%3工程に送出しました。移載が必要です。移載元キャリア[%1] ロット[%2]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001M, mtypLotReworkSet.strCarrierId, lstrLotID, lstrMsg3)
                    Else
                        '@ﾒｯｾｰｼﾞ表示："<TRM1LI>$$%3工程に送出しました。キャリア[%1] ロット[%2]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001L, mtypLotReworkSet.strToCarrierId, lstrLotID, lstrMsg3)
                    End If
                End If
                
                '@=======================
                '@ ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰへのﾒｯｾｰｼﾞ表示処理
                '@=======================
                Call pubVsfInfo_Disp(pstrDMsg)
                
                
                '@***********************
                '@ 保留設定処理(工程異常処理票起案とは排他制御)
                '@***********************
                '@保留ありｵﾌﾟｼｮﾝﾎﾞﾀﾝが選択されているか
                If optHold0.Checked = True Then
                
                    '@保留設定ﾃﾞｰﾀ作成
                    With ltypLotHoldset
                        
                        '@-----------------------
                        '@ 保留ﾛｯﾄID設定
                        '@-----------------------
                        If mtypLotReworkSet.strToLotID <> vbNullString Then
                            .strLotID = mtypLotReworkSet.strToLotID                             'ﾛｯﾄID(分割の場合)：Mﾛｯﾄ
                        Else
                            .strLotID = lstrLotID                                               'ﾛｯﾄID(全数の場合)：Rﾛｯﾄ
                        End If
                        
                        .strHoldReasonID = CPstrReworkReasonCode                                '保留理由ID
                        .strHoldComment = vbNullString                                          '保留ｺﾒﾝﾄ
                        
                        '@-----------------------
                        '@ 保留期限ｾｯﾄ
                        '@-----------------------
                        '@★ 種別により処理分岐 ★
                        Select Case mtypLotReworkSet.strFlowClass

                            '@〓 PR or ES 〓
                            Case CPstrFlowClassES, CPstrFlowClassPR

                                lstrTempDate = DateAdd(DateInterval.Day, 2, DateTime.Today)     '2日後計算値

                            '@〓 その他 〓
                            Case Else

                                lstrTempDate = DateAdd(DateInterval.Day, 7, DateTime.Today)     '1週間後計算値

                        End Select
                        
                        .strHoldTermDate = lstrTempDate                                         '保留期限
                        .strHoldEmpID = pstrUserID                                              '保留責任者ID
                        .strEmpID = pstrUserID                                                  '作業者ID
                        .strLotLastUpdate = mtypLotReworkSet.strLotLastUpdate                   'ﾛｯﾄ最終更新日時
                    End With


                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)

                    '@=======================
                    '@ ﾛｯﾄ保留設定登録
                    '@=======================
                    lblnAns = pubblnLotHold_Ins(CMstrlot_hold____Ver, _
                                                ltypLotHoldset)

                    '@ﾛｯﾄ保留設定登録結果が"True：登録成功"か
                    If lblnAns = True Then

                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)

                        '@移載工程ｽｷｯﾌﾟﾌﾗｸﾞが"0：移載あり"か
                        If mtypLotReworkSet.strMoveSkip = CPstrZero Then
                        
                            '@ﾒｯｾｰｼﾞ表示："<TRM08I>$$ロット[%2]を保留しました。キャリア[%1]"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0008, mtypLotReworkSet.strCarrierId, ltypLotHoldset.strLotID)
                        Else
                            '@ﾒｯｾｰｼﾞ表示："<TRM08I>$$ロット[%2]を保留しました。キャリア[%1]"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0008, mtypLotReworkSet.strToCarrierId, ltypLotHoldset.strLotID)
                        End If
                        
                        '@=======================
                        '@ ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰへのﾒｯｾｰｼﾞ表示処理
                        '@=======================
                        Call pubVsfInfo_Disp(pstrDMsg)
                    Else
                        '@ﾛｯﾄ保留設定登録結果が"False：登録失敗"の場合
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                    End If
                End If
                
                '@***********************
                '@ 工程異常処理票発行設定(保留設定とは排他制御)
                '@***********************
                '@工程異常処理票発行ありが選択されているか
                If optExcpReport0.Checked = True Then
                    
                    '@=======================
                    '@ 工程異常/不適合品処理票登録処理
                    '@=======================
                    lblnAns = prvblnExcpChgReport_Ins(lstrExcpNo)
                    
                    '@工程異常/不適合品処理票登録処理結果が"False：処理失敗"か
                    If lblnAns = False Then
                        
                        '@ﾒｯｾｰｼﾞ変換処理
                        '@"<TRM1TW>$$工程異常/不適合品処理票登録に失敗しました。
                        '@ $工程異常/不適合品処理票登録画面より手動で起票してください。$ロット[%1]"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001T, mtypLotReworkSet.strLotID)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                End If
                
        '@↓2009/08/10 (Mon) 17:28:41 N.Kojima **************************************************

                '@起動SBが"1A0：基板"か
                If pstrSBID = CPstrSBID1A0 Then

                    '@WF部分選択、かつ分割ﾌﾗｸﾞが"1：分割有"、かつ移載工程ｽｷｯﾌﾟか(♪移載工程ｽｷｯﾌﾟの場合はこのﾀｲﾐﾝｸﾞで表示)
                    If mtypReworkInfoList.blnSelectFlag = False And _
                        mtypLotReworkSet.strDivFlag = CPstrOne And _
                        mtypLotReworkSet.strMoveSkip = CPstrOne Then

                        '@ﾛｯﾄの種別が"試作/実験品：GG,TS,WS,ZZ"か
                        If frmxxEN00Y0.Instance.lblFlowClass.Text = CPstrFlowClassGG Or _
                            frmxxEN00Y0.Instance.lblFlowClass.Text = CPstrFlowClassTS Or _
                            frmxxEN00Y0.Instance.lblFlowClass.Text = CPstrFlowClassWS Or _
                            frmxxEN00Y0.Instance.lblFlowClass.Text = CPstrFlowClassZZ Then
                            
                            '@表示ﾒｯｾｰｼﾞを編集(リワークロット[XXX])
                            lstrMsg = CPstrRework & CPstrBrLeft & lstrLotID & CPstrBrRight
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM1ZI>$$%1が[%2]されました。$検査工数削減の為、必要に応じて外観・現像検査工程の
                            '@ 検査ウェハ枚数を見直して下さい。$%3 %4"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0024, CPstrLot, CPstrDivide, lstrMsg, vbNullString)
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                        End If
                    End If
                End If

        '@↑2009/08/10 (Mon) 17:28:41 N.Kojima **************************************************
                
                '@工程異常/不適合品処理票発行結果を構造体へｾｯﾄ
                With mtypReworkInfoList
                    .strExcpNo = lstrExcpNo         '工程異常/不適合処理票№
                    .strLotID = lstrLotID           'ﾛｯﾄID
                End With
                
                '@処理結果をﾊﾟﾌﾞﾘｯｸ構造体(画面間引継ぎ用)へｾｯﾄ
                ptypReworkInfoList = mtypReworkInfoList
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理(閉じるﾎﾞﾀﾝ処理は呼ばない)
                '@∇∇∇∇∇∇∇∇∇∇∇
                Me.Close()

            Else
                '@特殊流動登録結果：異常(失敗)の場合     
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
            End If
            
            Exit Sub

        Catch ex As Exception
            
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)

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

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvfrmxxEN00Y1_Init
    '機　能：画面情報初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/17 (Wed) 10:12:40 S.Deguchi
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2008/07/28 (Mon) 16:21:13 N.Kojima     理由ｺｰﾄﾞ(小分類)選択ｺﾝﾎﾞ追加に伴う修正。(案件№03007)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvfrmxxEN00Y1_Init()
        
        Try

            '@ﾌｫｰﾑのﾀｲﾄﾙを設定
            Me.Text = CPstrSubFormEN00Y1
            
            '@内部変数の初期化
            mstrReasonCode = vbNullString               '理由ｺｰﾄﾞ退避領域
            mstrEmpID = vbNullString                    '発見者ID
            mstrEmpName = vbNullString                  '発見者名
            mstrFindDate = vbNullString                 '発見日時
            mstrDeptID = vbNullString                   '発見職場ID
            mstrDeptName = vbNullString                 '発見職場名
            
            '@各種ｺﾝﾎﾞの初期化
            cmbReasonCode.Clear                         'ﾘﾜｰｸ原因(大分類)ｺﾝﾎﾞ
            cmbReasonSubCode.Clear                      'ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞ
            cmbReasonSubCode.Enabled = False
            
            '@各種ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期化
            optHold0.Checked = False                    '保留(あり)
            optHold1.Checked = False                    '保留(なし)
            optExcpReport0.Checked = False              '工程異常/不適合処理票発行(あり)
            optExcpReport1.Checked = False              '工程異常/不適合処理票発行(なし)
            
            '@各種ﾌﾚｰﾑの初期化
            fraHoldIn.Enabled = False                   '保留設定
            fraExcpIn.Enabled = False                   '工程異常/不適合処理票発行設定
            
            '@確定ﾎﾞﾀﾝを無効にする
            cmdRegist.Enabled = False
            
            '@閉じるﾎﾞﾀﾝはﾌｫｰｶｽを失う際にﾁｪｯｸを行なわない(CausesValidation=False)
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00Y1_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbReasonCode_Disp
    '機　能：ﾘﾜｰｸ原因(大分類)ｺﾝﾎﾞ　作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/17 (Wed) 13:45:52 S.Deguchi
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2008/02/19 (Tue) 14:12:41 M.Koni       ﾘﾜｰｸ原因が1件の場合に直接表示するように対応。(案件№02602)
    '　　　：2008/07/28 (Mon) 16:21:13 N.Kojima     理由ｺｰﾄﾞ(小分類)選択ｺﾝﾎﾞ追加に伴う修正。(案件№03007)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvCmbReasonCode_Disp()

        Dim llngCnt     As Integer          '汎用ｶｳﾝﾄ

        Try
            
            '@ｺﾝﾎﾞﾎﾞｯｸｽ設定
            With cmbReasonCode
            
                .Clear                                                                                              'ｸﾘｱ
                .DispCols = CMlngCmbDispCols                                                                        'ｸﾞﾘｯﾄﾞ表示列数：1
                .GetCol = CMlngCmbGridCol0                                                                          'ﾃｷｽﾄ表示列：0
                .ValueCol = CMlngCmbGridCol1                                                                        '値取得列：1
                .DirectInput = False                                                                                '直接入力不可
                .Text = vbNullString                                                                                'ﾃｷｽﾄ初期化
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ：16        
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)   'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ：16
                .RowHeight = CMlngCmbRowHeight                                                                      '行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter                                          '左寄中央揃え
                
                '@ﾘﾜｰｸ原因(大分類)情報ｾｯﾄ(理由名/理由ID/保留ﾌﾗｸﾞ/異常処理ﾌﾗｸﾞ)
                For llngCnt = 0 To mtypReasonCodeList.lngReasonCodeListCnt - 1
                
                    .AddItem(mtypReasonCodeList.typReasonCodeList(llngCnt).strReasonName _
                           & vbTab _
                           & mtypReasonCodeList.typReasonCodeList(llngCnt).strReasonCode _
                           & vbTab _
                           & mtypReasonCodeList.typReasonCodeList(llngCnt).strHoldFlag _
                           & vbTab _
                           & mtypReasonCodeList.typReasonCodeList(llngCnt).strExcpFlag)
                Next llngCnt
            
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbReasonCode_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbReasonSubCode_Disp
    '機　能：ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞ　作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/07/28 (Mon) 16:21:13 N.Kojima
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvCmbReasonSubCode_Disp()

        Dim llngCnt     As Integer          '汎用ｶｳﾝﾀ

        Try
            
            '@ｺﾝﾎﾞﾎﾞｯｸｽ設定
            With cmbReasonSubCode
            
                .Clear                                                                                              'ｸﾘｱ
                .DispCols = CMlngCmbDispCols                                                                        'ｸﾞﾘｯﾄﾞ表示列数：1
                .GetCol = CMlngCmbGridCol0                                                                          'ﾃｷｽﾄ表示列：0
                .ValueCol = CMlngCmbGridCol1                                                                        '値取得列：1
                .DirectInput = False                                                                                '直接入力不可
                .Text = vbNullString                                                                                'ﾃｷｽﾄ初期化
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ：16        
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)   'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ：16
                .RowHeight = CMlngCmbRowHeight                                                                      '行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter                                          '左寄中央揃え
                
                '@***********************
                '@ ﾘﾜｰｸ原因(大分類)にて選択されている理由ｺｰﾄﾞの小分類をｾｯﾄする
                '@***********************
                
                '@ﾘﾜｰｸ原因(小分類)情報ｾｯﾄ(理由名/理由ID)
                For llngCnt = 0 To mtypReasonSubCodeList.lngReasonSubCodeListCnt - 1
                        
                    '@理由名(小分類)/理由ｺｰﾄﾞ(小分類)
                    .AddItem(mtypReasonSubCodeList.typReasonSubCodeList(llngCnt).strReasonSubName _
                           & vbTab _
                           & mtypReasonSubCodeList.typReasonSubCodeList(llngCnt).strReasonSubCode)
                
                Next llngCnt


                '@★ ﾘﾜｰｸ原因(小分類)の件数により処理分岐 ★
                Select Case mtypReasonSubCodeList.lngReasonSubCodeListCnt
                
                    '@〓 0件の場合 〓
                    Case Is < 1
                        
                        '@ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞを無効にする
                        .Enabled = False
                
                    '@〓 1件の場合 〓
                    Case Is = 1
                        
                        '@ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞを有効にし、1件のﾃﾞｰﾀを直接表示する
                        .Enabled = True
                        .ListIndex = 0
                        
                        '@確定ﾎﾞﾀﾝを有効にし、ﾌｫｰｶｽｾｯﾄ
                        cmdRegist.Enabled = True
                        Call pubSetFocus(cmdRegist)
                        
                    '@〓 1件以上の場合 〓
                    Case Is > 1
                        
                        '@ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞを有効にする
                        .Enabled = True

                End Select

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbReasonSubCode_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnExcpChgReport_Ins
    '機　能：工程異常/不適合品処理票登録処理
    '引　数：lstrExcpNo ：異常処理№
    '戻り値：True：処理成功、False：処理失敗
    '作成日：2005/08/05 (Fri) 13:04:23 S.Deguchi
    '更新日：2009/08/11 (Tue) 13:14:31 N.Kojima
    '備　考：
    '　　　：2007/05/01 (Tue) 13:03:35 N.Kasai      CF/LP判定追加(№01884)
    '　　　：2008/07/28 (Mon) 16:21:13 N.Kojima     理由ｺｰﾄﾞ(小分類)選択ｺﾝﾎﾞ追加に伴う修正。(案件№03007)
    '　　　：2009/08/11 (Tue) 13:14:31 N.Kojima     案件№03542対応のついでにｿｰｽ整備。
    Private Function prvblnExcpChgReport_Ins(ByRef lstrExcpNo As String) As Boolean

        Dim lblnAns                 As Boolean              '汎用戻り値
        Dim ltypExcpReport          As ExcpReport           '工程異常不適合品処理票登録構造体
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ

        Try

            '@戻り値の初期化
            prvblnExcpChgReport_Ins = False
            
            '@***********************
            '@ 登録情報を構造体へ格納
            '@***********************
            With ltypExcpReport
            
                .strSbID = pstrSBID                         'SBID
                .strMsgVer = CMstrexcpchgreportVer          'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strExcpNo = vbNullString                   '異常処理№
                .strFindDate = mstrFindDate                 '発見日時
                .strEntryTime = mstrFindDate                '登録日時
                .strFindDeptID = mstrDeptID                 '発見職場ID
                .strFindDeptName = mstrDeptName             '発見職場名
                .strFindEmpID = mstrEmpID                   '発見者ID
                .strFindEmpName = mstrEmpName               '発見者名
                .strEmpID = mstrEmpID                       '更新者ID
                .strEmpName = mstrEmpName                   '更新者名
                .strHoldFlag = CMstrDefault1                '保留ﾌﾗｸﾞ(1:保留有)
                .strDocClass = CMstrTroubleFlag             '帳票種別(工程異常処理(ﾛｯﾄ))
                .strIncongFlag = CMstrTroubleFlag           '不適合品発生有無(工程異常処理(ﾛｯﾄ))
                
                '@ﾛｯﾄの件数を設定(1件固定)
                .lngExcpReportLotListCnt = 1
                    
                .strFindOpID = mtypLotReworkSet.strOpID             '大工程
                .strFindStepID = mtypLotReworkSet.strStepID         '小工程
                .strFindWpID = mtypLotReworkSet.strWpID             '装置ID
                .strFindWpName = mtypLotReworkSet.strWpName         '装置名
                .strTargetPDID = mtypLotReworkSet.strPdId           '機種
                
                '@***********************
                '@ 数量関連ﾃﾞｰﾀ作成
                '@***********************
                '@★ 起動SBにより処理分岐 ★
                Select Case pstrSBID
                
                    '@〓 基板 〓
                    Case CPstrSBID1A0
                    
                        .strTargetQuantity = mtypLotReworkSet.strWFQuantity                         '合計WF数
                        .strTargetUnit = CMstrUnitWF                                                'WF
                    
                    '@〓 組立 〓
                    Case CPstrSBID2A0
                    
                        '@★★ CFﾌﾗｸﾞにより処理分岐 ★★
                        Select Case mtypLotReworkSet.strCfFlag
                        
                            '@〓〓 0：WF 〓〓
                            Case CMstrCFFlag_WF
                            
                                .strTargetQuantity = mtypLotReworkSet.strWFQuantity                 '合計WF数
                                .strTargetUnit = CMstrUnitWF                                        'WF
                        
                            '@〓〓 1：対向基板 〓〓
                            Case CMstrCFFlag_CF
                                
                                '@LPﾌﾗｸﾞが"1：貼り合せ方式(大板)"か
                                If mtypLotReworkSet.strLpFlag = CMstrLpFlagOdf Then
                                
                                    .strTargetQuantity = mtypLotReworkSet.strWFQuantity             '合計WF数
                                    .strTargetUnit = CMstrUnitWF                                    'WF
                                Else
                                    '@TPALの場合
                                
                                    .strTargetQuantity = mtypLotReworkSet.strChipQuantity           '合計ﾁｯﾌﾟ数
                                    .strTargetUnit = CMstrUnitChip                                  'ﾁｯﾌﾟ数
                                End If

                        End Select
                End Select
                 
                '@***********************
                '@ ﾛｯﾄﾘｽﾄ作成
                '@***********************
                '@格納領域確保(1件分)
                If .typExcpLotList Is Nothing Then
                    .typExcpLotList = New List(Of ExcpLot)
                Else
                    .typExcpLotList.Clear
                End If
                
                For llngCnt = 0 To .lngExcpReportLotListCnt - 1

                    'NSYS @編集用の一時構造体
                    Dim tmpExcpLot = New ExcpLot
                
                    tmpExcpLot.strLotID = mtypLotReworkSet.strLotID       'ﾛｯﾄID
                    
                    '@ﾛｯﾄを構成するWF/CF(ﾁｯﾌﾟ)の合計枚数をｾｯﾄ
                    If ltypExcpReport.strTargetUnit = CMstrUnitWF Then
                    
                        '@WFの場合
                        tmpExcpLot.strTotalQuantity = mtypLotReworkSet.strWFQuantity
                    Else
                        '@CF(ﾁｯﾌﾟ)の場合
                        tmpExcpLot.strTotalQuantity = mtypLotReworkSet.strChipQuantity
                    End If
                    
                    '@初期設定：全て"0"
                    tmpExcpLot.strReserveQuantity = "0"                   '保留
                    tmpExcpLot.strAbandonQuantity = "0"                   '廃却
                    tmpExcpLot.strAmendQuantity = "0"                     '手直し
                    tmpExcpLot.strCorrectQuantity = "0"                   '修正
                    tmpExcpLot.strUsualQuantity = "0"                     '通常
                    tmpExcpLot.strEvalQuantity = "0"                      '評価
                    tmpExcpLot.strTakeQuantity = "0"                      '特採
                    tmpExcpLot.strTargetQuantity = "0"                    '対象数量
                    
                    '@処置ﾌﾗｸﾞ："0"⇒未処置
                    tmpExcpLot.strDisposalFlag = CMstrDispose

                    'NSYS @編集後の構造体をリストへ追加
                    .typExcpLotList.Add(tmpExcpLot)

                Next llngCnt
                
                '@その他ﾌﾗｸﾞ設定：初期値"0"
                .strInflFlag = "0"              '後工程/信頼性影響
                .strApprovalFlag = "0"          '適用ﾌﾗｸﾞ(=0：未適用)
                .strDispoScrapFlag = "0"        '廃却
                .strDispoMdifyFlag = "0"        '手直し
                .strDispoPickFlag = "0"         '特採
                .strDispoRegularFlag = "0"      '通常
                .strDispoAmendFlag = "0"        '修正
                .strDispoRatingFlag = "0"       '評価
                .strImproKind = "0"             '改善取組
                
                '@##########その他ｾｯﾄしていない変数はNull##########
            End With


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnExcpChgReportIns)
            
            '@=======================
            '@ 工程異常/不適合品処理票登録
            '@=======================
            lblnAns = pubblnExcpChgReport_Upd(ltypExcpReport, _
                                              lstrGuidMsg, _
                                              lstrGuidMsgCode)
            
            '@工程異常/不適合品処理票登録結果が"True：登録成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvblnExcpChgReportIns)
            
                '@異常処理№を退避
                lstrExcpNo = ltypExcpReport.strExcpNo
            Else
                '@工程異常/不適合品処理票登録結果：異常(失敗)の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnExcpChgReportIns)
                Exit Function
            End If
            
            '@=======================
            '@ ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ表示制御処理
            '@=======================
            Call pubGuidMsg_Set(lstrGuidMsgCode, lstrGuidMsg, Me)
            
            '@=======================
            '@ ﾒｯｾｰｼﾞ変換処理
            '@=======================
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001G, lstrExcpNo)
            '@ﾒｯｾｰｼﾞ表示："<TRM1GI>$$工程異常処理票を登録しました。異常処理№[%1]"
            Call pubVsfInfo_Disp(pstrDMsg)
            
            '@戻り値に"True：処理成功"をｾｯﾄ
            prvblnExcpChgReport_Ins = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnExcpChgReport_Ins"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvReasonSubCodeGet_Proc
    '機　能：ﾘﾜｰｸ原因(小分類)取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/08/25 (Mon) 14:34:04 N.Kojima
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvReasonSubCodeGet_Proc()

        Dim lblnAns     As Boolean      '汎用ｶｳﾝﾀ

        Try
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvReasonSubCodeGetProc)
            
            '@=======================
            '@ ﾘﾜｰｸ原因(小分類)ｺｰﾄﾞ取得
            '@=======================
            lblnAns = pubblnMasReworkSubReson_Sel(CMstrmas_reworksubreasonVer, _
                                                  cmbReasonCode.Value, _
                                                  mtypReasonSubCodeList)
            
            '@ﾘﾜｰｸ原因(小分類)ｺｰﾄﾞ取得結果が"False：取得失敗"か
            If lblnAns = False Then
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvReasonSubCodeGetProc)
                Exit Sub
            End If

            '@=======================
            '@ ﾘﾜｰｸ原因(小分類)ｺﾝﾎﾞ作成処理
            '@=======================
            Call prvCmbReasonSubCode_Disp()
            
            '@ﾘﾜｰｸ原因(大分類)を退避する
            mstrReasonCode = cmbReasonCode.Value
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrPrvReasonSubCodeGetProc)
                    
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvReasonSubCodeGet_Proc"
                .strErrMessage = vbNullString
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraExcp.Paint, fraHold.Paint, fraReworkReason.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
