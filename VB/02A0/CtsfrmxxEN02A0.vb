'ﾌｧｲﾙ名：xxEN02A0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：工程戻し　メインフォーム
'作成日：2008/05/12 (Mon) 10:41:47 N.Kojima
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02A0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02A0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02A0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02A0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02A0)
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
    '========================================Public==========================================
    '========================================Private=========================================
    '@機能ﾊﾞｰｼﾞｮﾝ用定数宣言
    '@↓2020/03/06 (Fri) 11:45:45 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion                                 As String = "03.01"                 '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                                 As String = "04.00"                 '機能ﾊﾞｰｼﾞｮﾝ
    '@↑2020/03/06 (Fri) 11:45:45 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@機能ID用定数宣言
    Private Const CMstrLocalMenuKey                                 As String = CPstrKeyEN02A0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ用定数宣言
    '@↓2020/01/15 (Wed) 14:14:45 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer                              As String = "03.04"                 'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer                              As String = "04.00"                 'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:14:45 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrmnt_opsteplistVer                            As String = "01.00"                 '流動済工程情報取得
    Private Const CMstrmnt_eventhistVer                             As String = "01.00"                 'ｲﾍﾞﾝﾄ履歴取得
    Private Const CMstrmnt_delhist_Ver                              As String = "01.00"                 'ｲﾍﾞﾝﾄ履歴削除

    '@vsfEventHistoryListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfEventHistoryListColNo                     As Integer = 0                      '№
    Private Const CMlngvsfEventHistoryListColOpID                   As Integer = 1                      '大工程
    Private Const CMlngvsfEventHistoryListColStepID                 As Integer = 2                      '小工程
    Private Const CMlngvsfEventHistoryListColLotEventID             As Integer = 3                      'ﾛｯﾄｲﾍﾞﾝﾄID(非表示)
    Private Const CMlngvsfEventHistoryListColLotEventName           As Integer = 4                      'ﾛｯﾄｲﾍﾞﾝﾄ名
    Private Const CMlngvsfEventHistoryListColEntryTime              As Integer = 5                      '登録日時
    Private Const CMlngvsfEventHistoryListColEmpID                  As Integer = 6                      '作業者ID(非表示)
    Private Const CMlngvsfEventHistoryListColEmpName                As Integer = 7                      '作業者名
    Private Const CMlngvsfEventHistoryListColWorkMemo               As Integer = 8                      '作業ﾒﾓ(あり/なし)
    Private Const CMlngvsfEventHistoryListColWorkMemoContents       As Integer = 9                      '作業ﾒﾓ内容(非表示)
    Private Const CMlngvsfEventHistoryListColDeleteProhibited       As Integer = 10                     '削除可否判定ﾌﾗｸﾞ(0:削除可、1:削除不可)(非表示)

    '@vsfEventHistoryListの定数宣言(幅)
    Private Const CMlngvsfEventHistoryListColWNo                    As Integer = 50                     '№
    Private Const CMlngvsfEventHistoryListColWOpID                  As Integer = 260                    '大工程
    Private Const CMlngvsfEventHistoryListColWStepID                As Integer = 260                    '小工程
    Private Const CMlngvsfEventHistoryListColWLotEventID            As Integer = 0                      'ﾛｯﾄｲﾍﾞﾝﾄID(非表示)
    Private Const CMlngvsfEventHistoryListColWLotEventName          As Integer = 227                    'ﾛｯﾄｲﾍﾞﾝﾄ名
    Private Const CMlngvsfEventHistoryListColWEntryTime             As Integer = 213                    '登録日時
    Private Const CMlngvsfEventHistoryListColWEmpID                 As Integer = 0                      '作業者ID(非表示)
    Private Const CMlngvsfEventHistoryListColWEmpName               As Integer = 87                     '作業者名
    Private Const CMlngvsfEventHistoryListColWWorkMemo              As Integer = 87                     '作業ﾒﾓ(あり/なし)
    Private Const CMlngvsfEventHistoryListColWWorkMemoContents      As Integer = 0                      '作業ﾒﾓ内容(非表示)
    Private Const CMlngvsfEventHistoryListColWDeleteProhibited      As Integer = 0                      '削除可否判定ﾌﾗｸﾞ(0:削除可、1:削除不可)(非表示)

    '@vsfEventHistoryListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfEventHistoryListColTNo                    As String = "№"                    '№
    Private Const CMstrvsfEventHistoryListColTOpID                  As String = "大工程"                '大工程
    Private Const CMstrvsfEventHistoryListColTStepID                As String = "小工程"                '小工程
    Private Const CMstrvsfEventHistoryListColTLotEventID            As String = "ﾛｯﾄｲﾍﾞﾝﾄID"            'ﾛｯﾄｲﾍﾞﾝﾄID(非表示)
    Private Const CMstrvsfEventHistoryListColTLotEventName          As String = "作業"                  'ﾛｯﾄｲﾍﾞﾝﾄ名
    Private Const CMstrvsfEventHistoryListColTEntryTime             As String = "日時"                  '登録日時
    Private Const CMstrvsfEventHistoryListColTEmpID                 As String = "作業者ID"              '作業者ID(非表示)
    Private Const CMstrvsfEventHistoryListColTEmpName               As String = "作業者"                '作業者名
    Private Const CMstrvsfEventHistoryListColTWorkMemo              As String = "作業メモ"              '作業ﾒﾓ(あり/なし)
    Private Const CMstrvsfEventHistoryListColTWorkMemoContents      As String = "作業メモ内容"          '作業ﾒﾓ内容(非表示)
    Private Const CMstrvsfEventHistoryListColTDeleteProhibited      As String = "削除可否フラグ"        '削除可否判定ﾌﾗｸﾞ(0:削除可、1:削除不可)(非表示)

    '@ｸﾞﾘｯﾄﾞのﾌﾟﾛﾊﾟﾃｨ設定用定数宣言
    Private Const CMlngVsfRowTitle                                  As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                                  As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                                 As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                                   As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                                    As Integer = 17                     '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfFontSize                                  As Integer = 11                     'ﾃﾞｰﾀ行ﾌｫﾝﾄｻｲｽﾞ

    '@ｺﾝﾎﾞﾎﾞｯｸｽのﾌﾟﾛﾊﾟﾃｨ設定用定数宣言
    Private Const CMlngCmbFontSize                                  As Integer = 16                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                              As Integer = 16                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName                               As Integer = 0                      'ﾃｷｽﾄ(名称)列番
    Private Const CMlngCmbGridColID                                 As Integer = 1                      'ID列番(非表示項目)
    Private Const CMlngCmbDispCols                                  As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbAlignLeftCenter                           As Integer = 1                      'ｸﾞﾘｯﾄﾞ文字表示位置(左中央)
    Private Const CMlngCmbHeight                                    As Integer = 43                     'ﾘｽﾄの高さ
    Private Const CMlngCmbValueCol                                  As Integer = 0                      '値取得列
    Private Const CMlngCmbGetCol                                    As Integer = 2                      '値表示列

    '@ﾃｷｽﾄ制御用定数宣言
    Private Const CMlngMemoDefault                                  As Integer = 0                      '作業ﾒﾓの初期値(=0)
    Private Const CMlngMaxDispMemoRow                               As Integer = 4                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@ﾚｽﾎﾟﾝｽ計測用定数宣言
    Private Const CMstrFormName                                     As String = "frmxxEN02A0"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                                     As String = "Form_Load"                 'ｲﾍﾞﾝﾄ名定数(ﾌｫｰﾑﾛｰﾄﾞ)
    Private Const CMstrTxtCarrierValidate                           As String = "txtCarrier_Validate"       'ｲﾍﾞﾝﾄ名定数(ｷｬﾘｱIDValidate)
    Private Const CMstrCmbRollBackOpIDValidate                      As String = "cmbRollBackOpID_Validate"  'ｲﾍﾞﾝﾄ名定数(部材種別Validate)
    Private Const CMstrCmbRollBackStepIDValidate                    As String = "cmbRollBackStepID_Validate" 'ｲﾍﾞﾝﾄ名定数(部材Validate)
    Private Const CMstrCmdRegistClick                               As String = "cmdRegist_Click"           'ｲﾍﾞﾝﾄ名定数(使用開始)

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Public==========================================
    '========================================Private=========================================
    Private mtypChgSort                                             As ChgSort                          'ｿｰﾄ保持用
    Private mlngSortCol                                             As Integer                          'ｿｰﾄ列格納
    Private mlngSortOrder                                           As Integer                          'ｿｰﾄ方法格納
    Private mblnFormActivateFlag                                    As Boolean                          'ﾌｫｰﾑのｱｸﾃｨﾍﾞｲﾄ処理走行済み判定ﾌﾗｸﾞ(True:走行済、False:未走行)
    Private mtypOpStepList                                          As OpStepList                       '流動済工程情報格納用構造体
    Private mtypReqEventInfo                                        As ReqEventInfo                     'ｲﾍﾞﾝﾄ履歴取得/削除要求ﾃﾞｰﾀ格納用構造体
    Private mtypAnsEventInfo                                        As AnsEventInfo                     'ｲﾍﾞﾝﾄ履歴取得応答ﾃﾞｰﾀ格納用構造体
    Private mstrCarrier                                             As String                           'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrRetainCarrier                                       As String                           '引継ぎｷｬﾘｱ退避用(Loader側)
    Private mstrRollBackOpID                                        As String                           '戻り大工程退避領域
    Private mstrRollBackStepID                                      As String                           '戻り小工程退避領域

    Private buttonProcessing                                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                                As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                                         As Boolean                          'NSYS WindowCloseフラグ
    Private mintEventHistoryListRowBeforeSort                       As Integer                          'NSYS CarrierListのソート前選択行

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
    '作成日：2008/05/12 (Mon) 11:13:36 N.Kojima
    '更新日：2008/05/12 (Mon) 11:13:36
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納

        Try
            
            '@Escﾎﾞﾀﾝを無効にする(ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させないようにする為)
            Me.CancelButton = Nothing
            
            '@=======================
            '@　機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02A0, CMstrLocalVersion)
            
            '@機能ﾊﾞｰｼﾞｮﾝ判定処理結果判定
            If lblnAns = False Then
                '@機能ﾊﾞｰｼﾞｮﾝ判定処理結果：正常の場合
                
                '@Escﾎﾞﾀﾝを有効にする
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@=======================
            '@　各種初期化処理(画面情報、ｺﾝﾎﾞ、ｸﾞﾘｯﾄﾞ、ｿｰﾄ構造体etc...)
            '@=======================
            Call prvAllInit_Proc()
            
            '@ｷｬﾘｱIDのｸﾘｱ
            txtCarrier.Text = vbNullString

            '@起動ﾌﾗｸﾞに"True:起動処理成功"をｾｯﾄ
            pblnFormLoad = True

            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効にする
            Me.CancelButton = cmdClose

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
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/12 (Mon) 13:17:35 N.Kojima
    '更新日：2008/05/12 (Mon) 13:17:35
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@当処理が未走行か
            If mblnFormActivateFlag = False Then
                '@未走行の場合
                
                '@Escﾎﾞﾀﾝを有効にする
                Me.CancelButton = cmdClose
                
                '@ｱｸﾃｨﾍﾞｲﾄ処理走行済み判定ﾌﾗｸﾞに"True:走行済"をｾｯﾄ
                mblnFormActivateFlag = True
                
                With ptypCommonInfo
                
                    '@引数情報のｷｬﾘｱIDがNULL以外か
                    If .strCarrierId <> vbNullString Then
                        '@NULL以外の場合
                        
                        '@初期値として、引継ぎｷｬﾘｱIDをｾｯﾄする
                        txtCarrier.Text = .strCarrierId
                        
                        '@=======================
                        '@　ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                        '@=======================
                        RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                        Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                        AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                        
                    Else
                        '@NULLの場合
                        
                        '@ｷｬﾘｱIDにNULLをｾｯﾄする
                        .strCarrierId = vbNullString
                        mstrCarrier = vbNullString
                        
                        '@ｷｬﾘｱIDが有効か
                        If txtCarrier.Enabled = True Then
                            '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtCarrier)
                        Else
                            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End With

                'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
                'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
                Dim lfuncActivate As Action = Sub()
                    Me.Activate()
                    End Sub
                Me.BeginInvoke(lfuncActivate)

            End If
            
            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効にする
            Me.CancelButton = cmdClose

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
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2008/05/12 (Mon) 13:22:21 N.Kojima
    '更新日：2008/05/12 (Mon) 13:22:21
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            '@以下の条件の場合、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If
            
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
            
                '@〓 ｷｬﾘｱID 〓
                Case txtCarrier.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return

                            '@ｷｬﾘｱIDがNULL以外か
                            If txtCarrier.Text <> vbNullString Then
                                
                                '@=======================
                                '@　ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                                '@=======================
                                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Else
                                '@NULLの場合
                            
                                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(cmdClose)
                            End If
                        
                        End Select
                
                
                '@〓 作業ﾒﾓ 〓
                Case txtWorkMemo.Name

                    Exit Sub
            
                
                '@〓 戻り大工程 〓
                Case cmbRollBackOpID.Name
                    
                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                            
                            '@=======================
                            '@　戻り大工程のValidate処理
                            '@=======================
                            RemoveHandler cmbRollBackOpID.Validating, AddressOf cmbRollBackOpID_Validate
                            Call cmbRollBackOpID_Validate(cmbRollBackOpID, New CancelEventArgs(True))
                            AddHandler cmbRollBackOpID.Validating, AddressOf cmbRollBackOpID_Validate
                            e.Handled = True

                    End Select


                '@〓 戻り小工程 〓
                Case cmbRollBackStepID.Name
                    
                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                            
                            '@=======================
                            '@　戻り小工程のValidate処理
                            '@=======================
                            RemoveHandler cmbRollBackStepID.Validating, AddressOf cmbRollBackStepID_Validate
                            Call cmbRollBackStepID_Validate(cmbRollBackStepID, New CancelEventArgs(True))
                            AddHandler cmbRollBackStepID.Validating, AddressOf cmbRollBackStepID_Validate
                            e.Handled = True

                    End Select
                        
                        
                '@〓 その他 〓
                Case Else
                    
                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
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

    '関数名：Form_KeyPress
    '機　能：ﾌｫｰﾑ　ｷｰ押下時処理
    '引　数：KeyAscii   ：入力ｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2008/05/19 (Mon) 15:33:00 N.Kojima
    '更新日：2008/05/19 (Mon) 15:33:00
    '備　考：
    Private Sub Form_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress

        Try
            '@入力ｷｰが"44:ｶﾝﾏ"か
            If Asc(e.KeyChar) = 44 Then
                '@ｶﾝﾏは入力禁止
                e.Handled = True
            End If

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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2008/05/12 (Mon) 14:00:20 N.Kojima
    '更新日：2008/05/12 (Mon) 14:00:20
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm         As Boolean          'Act開放結果格納
        Dim ltypOpStepList      As OpStepList       '流動済工程情報格納用構造体初期化用
        Dim ltypReqEventInfo    As ReqEventInfo     'ｲﾍﾞﾝﾄ履歴取得/削除要求ﾃﾞｰﾀ格納用構造体初期化用
        Dim ltypAnsEventInfo    As AnsEventInfo     'ｲﾍﾞﾝﾄ履歴取得応答ﾃﾞｰﾀ格納用構造体初期化用

        Try
            
            '@"×"にて閉じた場合か
            If mblnCloseFromControlMenu Then
            
                '@=======================
                '@　閉じるﾎﾞﾀﾝ押下時処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ﾓｼﾞｭｰﾙ、ﾊﾟﾌﾞﾘｯｸ構造体の初期化
            If Not IsNothing(mtypChgSort.typChgSortList) Then
                mtypChgSort.typChgSortList.Clear()       'ｿｰﾄ保持用
            End If
            mtypOpStepList = ltypOpStepList             '流動済工程情報格納用構造体
            mtypReqEventInfo = ltypReqEventInfo         'ｲﾍﾞﾝﾄ履歴取得/削除要求ﾃﾞｰﾀ格納用構造体
            mtypAnsEventInfo = ltypAnsEventInfo         'ｲﾍﾞﾝﾄ履歴取得応答ﾃﾞｰﾀ格納用構造体
            
            '@ﾓｼﾞｭｰﾙ変数のｸﾘｱ・初期化
            mstrRollBackOpID = vbNullString             '戻り大工程退避用
            mstrRollBackStepID = vbNullString           '戻り小工程退避用
            mstrCarrier = vbNullString                  'ｷｬﾘｱID退避用
            mstrRetainCarrier = vbNullString            '引継ぎｷｬﾘｱID退避用
            
            '@Act初期化ﾌﾗｸﾞが"True:初期化済"か
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@=======================
                '@　ACTｵﾌﾞｼﾞｪｸﾄ開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                '@処理結果判定
                If lblnAnsTerm = True Then
                    '@結果：正常の場合
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@Act初期化ﾌﾗｸﾞが"False:未初期化"の場合
            
                '@=======================
                '@　ﾒｲﾝﾒﾆｭｰ画面拡張処理
                '@=======================
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

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/12 (Mon) 14:13:56 N.Kojima
    '更新日：2008/05/12 (Mon) 14:13:56
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            
            '@=======================
            '@　各種初期化処理(画面情報、ｺﾝﾎﾞ、ｸﾞﾘｯﾄﾞ、ｿｰﾄ構造体etc...)
            '@=======================
            Call prvAllInit_Proc()
            
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
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　Validate処理(入力確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/05/12 (Mon) 14:15:10 N.Kojima
    '更新日：2008/05/12 (Mon) 14:15:10
    '備　考：
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnNextCtrl            As Boolean              'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If ActiveControl Is txtCarrier Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If

            '@ｷｬﾘｱIDがNULLか
            If txtCarrier.Text = vbNullString Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDが6桁以下か
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@ﾒｯｾｰｼﾞ表示："<TRM07W>$$キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽ保持
                e.Cancel = True
                Exit Sub
            End If
            
            '@入力ｷｬﾘｱIDと入力前のｷｬﾘｱIDが同じか
            If txtCarrier.Text = mstrCarrier Then
                '@同じ場合

                '@戻り大工程が有効か
                If cmbRollBackOpID.Enabled = True Then
                    '@戻り大工程にﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmbRollBackOpID)
                    End If
                Else
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrTxtCarrierValidate)
            
            '@=======================
            '@　画面情報初期化処理
            '@=======================
            Call prvFrmxxEN02A0_Init()
            
            '@【ﾛｯﾄ現在状態取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                            CPstrCD08, _
                                            txtCarrier.Text, _
                                            ptypLotprestate)
            
            '@ﾛｯﾄ現在状態取得結果判定
            If lblnAns = True Then
                '@ﾛｯﾄ現在状態取得結果：正常の場合

                '@ｷｬﾘｱIDがNULLか
                If ptypLotprestate.strCarrierId = vbNullString Then
                    '@入力されたｷｬﾘｱを引継ぎｷｬﾘｱ退避用に格納(Loader側)
                    mstrRetainCarrier = txtCarrier.Text
                Else
                    '@ﾛｯﾄ現在状態取得で取得したｷｬﾘｱを引継ぎｷｬﾘｱ退避用に格納(Loader側)
                    mstrRetainCarrier = ptypLotprestate.strCarrierId
                End If
                
                '@=======================
                '@　ﾛｯﾄ情報表示処理
                '@=======================
                Call prvFrmxxEN02A0_Disp()
                
                '@【流動済工程情報取得】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnMntOpStepList_Sel(CMstrmnt_opsteplistVer, _
                                                  ptypLotprestate.strLotID, _
                                                  mtypOpStepList)
                
                '@流動済工程情報取得結果判定
                If lblnAns = True Then
                    '@流動済工程情報取得結果：正常の場合
                    
                    '@=======================
                    '@　戻り大工程ｺﾝﾎﾞ作成処理
                    '@=======================
                    Call prvCmbRollBackOpID_Disp()
                    
                    '@戻り大工程ｺﾝﾎﾞのﾃﾞｰﾀが1件か
                    If mtypOpStepList.lngOpListCnt = 1 Then
                        
                        '@1件の場合はﾃﾞﾌｫﾙﾄで表示し、戻り大工程退避変数にｾｯﾄ
                        cmbRollBackOpID.ListIndex = 0
                        mstrRollBackOpID = cmbRollBackOpID.Text
            
                        '@=======================
                        '@　戻り小工程ｺﾝﾎﾞ作成処理
                        '@=======================
                        Call prvCmbRollBackStepID_Disp()
                        
                        '@戻り小工程ｺﾝﾎﾞのﾃﾞｰﾀが1件か
                        If mtypOpStepList.typOpList(cmbRollBackOpID.Value).lngStepListCnt = 1 Then
                        
                            '@1件の場合はﾃﾞﾌｫﾙﾄで表示し、戻り小工程退避変数にｾｯﾄ
                            cmbRollBackStepID.ListIndex = 0
                            mstrRollBackStepID = cmbRollBackStepID.Text
                            
                            '@=======================
                            '@　ｲﾍﾞﾝﾄ履歴取得/削除要求ﾃﾞｰﾀ作成処理(引数は"1:ｲﾍﾞﾝﾄ履歴取得")
                            '@=======================
                            Call prvEventRequestDateSet_Proc(CPstrOne)
                            
                            '@【ｲﾍﾞﾝﾄ履歴取得】ﾒｯｾｰｼﾞ送受信処理
                            lblnAns = pubblnMntEventHist_Sel(mtypReqEventInfo, _
                                                             mtypAnsEventInfo)
                            
                            '@ｲﾍﾞﾝﾄ履歴取得結果判定
                            If lblnAns = True Then
                                '@ｲﾍﾞﾝﾄ履歴取得結果：正常の場合
                            
                                '@=======================
                                '@　ｲﾍﾞﾝﾄ履歴一覧表示処理
                                '@=======================
                                Call prvVsfEventHistoryList_Disp()
                                
                                '@作業ﾒﾓが有効か
                                If txtWorkMemo.Enabled = True Then
                                    '@作業ﾒﾓにﾌｫｰｶｽｾｯﾄ
                                    If lblnNextCtrl Then
                                        Call pubSetFocus(txtWorkMemo)
                                    End If
                                Else
                                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                    If lblnNextCtrl Then
                                        Call pubSetFocus(cmdClose)
                                    End If
                                End If
                            Else
                                '@ｲﾍﾞﾝﾄ履歴取得結果：異常の場合
                            
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                                
                                '@ｷｬﾘｱIDにﾌｫｰｶｽ保持
                                e.Cancel = True
                                
                                '@=======================
                                '@　ﾊｲﾗｲﾄ処理
                                '@=======================
                                Call pubHighlight(txtCarrier)

                                Exit Sub
                            End If
                        Else
                            '@戻り小工程が1件以外
                            
                            '@戻り小工程が1件以上存在するか
                            If mtypOpStepList.typOpList(cmbRollBackOpID.Value).lngStepListCnt <> 0 Then
                            
                                '@戻り小工程が有効か
                                If cmbRollBackStepID.Enabled = True Then
                                    '@戻り小工程にﾌｫｰｶｽｾｯﾄ
                                    If lblnNextCtrl Then
                                        Call pubSetFocus(cmbRollBackStepID)
                                    End If
                                Else
                                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                    If lblnNextCtrl Then
                                        Call pubSetFocus(cmdClose)
                                    End If
                                End If
                            Else
                                '@戻り小工程が0件の場合
                            
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001G, lblLotID.Text)
                                '@ﾒｯｾｰｼﾞ表示："<TRM1GW>$$削除可能な履歴が存在しません。ロット[%1]"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@ｷｬﾘｱIDにﾌｫｰｶｽ保持
                                e.Cancel = True
                                
                                '@=======================
                                '@　ﾊｲﾗｲﾄ処理
                                '@=======================
                                 Call pubHighlight(txtCarrier)
                            End If
                        End If
                    Else
                        '@戻り大工程が1件以外
                        
                        '@戻り大工程が1件以上存在するか
                        If mtypOpStepList.lngOpListCnt <> 0 Then
                        
                            '@戻り大工程が有効か
                            If cmbRollBackOpID.Enabled = True Then
                                '@戻り大工程にﾌｫｰｶｽｾｯﾄ
                                If lblnNextCtrl Then
                                    Call pubSetFocus(cmbRollBackOpID)
                                End If
                            Else
                                '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                If lblnNextCtrl Then
                                    Call pubSetFocus(cmdClose)
                                End If
                            End If
                        Else
                            '@戻り大工程が0件の場合
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001G, lblLotID.Text)
                            '@ﾒｯｾｰｼﾞ表示："<TRM1GW>$$削除可能な履歴が存在しません。ロット[%1]"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@ｷｬﾘｱIDにﾌｫｰｶｽ保持
                            e.Cancel = True
                            
                            '@=======================
                            '@　ﾊｲﾗｲﾄ処理
                            '@=======================
                            Call pubHighlight(txtCarrier)
                        End If
                    End If
                Else
                    '@流動済工程情報取得結果：異常の場合
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)

                    '@ｷｬﾘｱIDにﾌｫｰｶｽ保持
                    e.Cancel = True
                    
                    '@=======================
                    '@　ﾊｲﾗｲﾄ処理
                    '@=======================
                    Call pubHighlight(txtCarrier)
                    
                    Exit Sub
                End If
            Else
                '@ﾛｯﾄ現在状態取得結果：異常の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽ保持
                e.Cancel = True
                
                '@=======================
                '@　ﾊｲﾗｲﾄ処理
                '@=======================
                Call pubHighlight(txtCarrier)
                
                Exit Sub
            End If

            '@次回ｷｬﾘｱIDが入力されて同じだったら処理をｷｬﾝｾﾙする為に格納
            mstrCarrier = txtCarrier.Text
            
            '@流動ﾀｲﾌﾟが"M:移載工程"か
            If ptypLotprestate.strFlowType = CPstrLotCurstateFlowTypeMove Then
                '@"M:移載工程"の場合
                
                '@各種ﾎﾞﾀﾝを無効にする
                cmdLotComment.Enabled = False           'ﾛｯﾄｺﾒﾝﾄ
                cmdWorkMemoChk.Enabled = False          '作業ﾒﾓ確認
             
                '@作業ﾒﾓ関連ｺﾝﾄﾛｰﾙを無効にする
                txtWorkMemo.Enabled = False             '作業ﾒﾓ
                cmdMemoUp.Enabled = False               '上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ
                cmdMemoDown.Enabled = False             '下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ
            Else
                '@"M:移載工程"以外の場合
                
                '@各種ｺﾝﾄﾛｰﾙを有効にする
                txtWorkMemo.Enabled = True              '作業ﾒﾓ
                cmdLotComment.Enabled = True            'ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrTxtCarrierValidate)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ﾌｫｰﾑﾛｯｸ解除
            'Me.Enabled = True
            
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

    '関数名：cmbRollBackOpID_Change
    '機　能：戻り大工程ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/13 (Tue) 10:13:50 N.Kojima
    '更新日：2008/05/13 (Tue) 10:13:50
    '備　考：
    Private Sub cmbRollBackOpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRollBackOpID.Change

        Try
            
            '@戻り大工程退避領域と比較して、変更された戻り大工程が異なるか
            If mstrRollBackOpID <> cmbRollBackOpID.Text Then
                '@異なる場合
                
                '@ｱｸﾃｨﾍﾞｲﾄ処理走行済み判定ﾌﾗｸﾞが"True:走行済"か
                '@　※Load時、Activate時の初期化で走行する場合は処理ｽｷｯﾌﾟ
                If mblnFormActivateFlag = True Then
            
                    '@ｶﾚﾝﾄ行検索ｷｰを初期化
                    mtypChgSort.strKey = vbNullString
                    
                    '@=======================
                    '@　ｲﾍﾞﾝﾄ履歴一覧ｸﾞﾘｯﾄﾞ初期化処理
                    '@=======================
                    Call prvVsfEventHistoryList_Init()
                    
                    '@各種ﾎﾞﾀﾝの無効化
                    cmdRegist.Enabled = False           '確定ﾎﾞﾀﾝ
                    cmdWorkMemoChk.Enabled = False      '作業ﾒﾓ確認
                    
                    '@戻り小工程の初期化&無効化
                    cmbRollBackStepID.Clear()
                    cmbRollBackStepID.Enabled = False
                    
                    '@退避用変数の初期化
                    mstrRollBackOpID = vbNullString     '戻り大工程退避用
                    mstrRollBackStepID = vbNullString   '戻り小工程退避用

                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRollBackOpID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRollBackOpID_CloseUp
    '機　能：戻り大工程ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/13 (Tue) 11:12:56 N.Kojima
    '更新日：2008/05/13 (Tue) 11:12:56
    '備　考：
    Private Sub cmbRollBackOpID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRollBackOpID.CloseUp

        Try
            
            '@戻り大工程がNULL以外か
            If cmbRollBackOpID.Text <> vbNullString Then
                
                '@=======================
                '@　戻り大工程ｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbRollBackOpID.Validating, AddressOf cmbRollBackOpID_Validate
                Call cmbRollBackOpID_Validate(cmbRollBackOpID, New CancelEventArgs(True))
                AddHandler cmbRollBackOpID.Validating, AddressOf cmbRollBackOpID_Validate
            End If
          
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRollBackOpID_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRollBackOpID_Validate
    '機　能：戻り大工程ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/05/13 (Tue) 11:15:35 N.Kojima
    '更新日：2008/05/13 (Tue) 11:15:35
    '備　考：
    Private Sub cmbRollBackOpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbRollBackOpID.Validating
        
        Dim lblnAns             As Boolean              'ｲﾍﾞﾝﾄ履歴一覧取得の戻り値格納用
        Dim lblnNextCtrl        As Boolean              'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If ActiveControl Is cmbRollBackOpID Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If
            
            '@戻り大工程ｺﾝﾎﾞがNULLか
            If cmbRollBackOpID.Text = vbNullString Then
                '@NULLの場合
                
                '@戻り小工程ｺﾝﾎﾞが有効か
                If cmbRollBackStepID.Enabled = True Then
                    '@戻り小工程ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmbRollBackStepID)
                    End If
                Else
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                
                Exit Sub
            Else
                '@NULL以外の場合
            
                '@退避用戻り大工程と選択戻り大工程が同じか
                If mstrRollBackOpID = cmbRollBackOpID.Text Then
                    '@同じ場合
                    
                    '@戻り小工程ｺﾝﾎﾞが有効か
                    If cmbRollBackStepID.Enabled = True Then
                        '@戻り小工程ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                        If lblnNextCtrl Then
                            Call pubSetFocus(cmbRollBackStepID)
                        End If
                    Else
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If lblnNextCtrl Then
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                    
                    Exit Sub
                Else
                    '@異なる場合
                        
                    '@戻り大工程退避変数にｾｯﾄ
                    mstrRollBackOpID = cmbRollBackOpID.Text
                        
                    '@=======================
                    '@　戻り小工程ｺﾝﾎﾞ作成処理
                    '@=======================
                    Call prvCmbRollBackStepID_Disp()
                    
                    '@戻り小工程ｺﾝﾎﾞのﾃﾞｰﾀが1件か
                    If mtypOpStepList.typOpList(cmbRollBackOpID.Value).lngStepListCnt = 1 Then
                    
                        '@1件の場合はﾃﾞﾌｫﾙﾄで表示し、戻り小工程退避変数にｾｯﾄ
                        cmbRollBackStepID.ListIndex = 0
                        mstrRollBackStepID = cmbRollBackStepID.Text
                        
                        '@ﾚｽﾎﾟﾝｽ取得開始
                        Call pubResponseStart(CMstrFormName, CMstrCmbRollBackOpIDValidate)
                        
                        '@=======================
                        '@　ｲﾍﾞﾝﾄ履歴取得要求ﾃﾞｰﾀ作成処理
                        '@=======================
                        Call prvEventRequestDateSet_Proc(CPstrOne)
                        
                        '@【ｲﾍﾞﾝﾄ履歴取得】ﾒｯｾｰｼﾞ送受信処理
                        lblnAns = pubblnMntEventHist_Sel(mtypReqEventInfo, _
                                                         mtypAnsEventInfo)
                                                        
                        '@ｲﾍﾞﾝﾄ履歴取得結果判定
                        If lblnAns = True Then
                            '@ｲﾍﾞﾝﾄ履歴取得結果：正常の場合
                        
                            '@=======================
                            '@　ｲﾍﾞﾝﾄ履歴一覧表示処理
                            '@=======================
                            Call prvVsfEventHistoryList_Disp()
                            
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(CMstrFormName, CMstrCmbRollBackOpIDValidate)
                            
                            '@作業ﾒﾓが有効か
                            If txtWorkMemo.Enabled = True Then
                                '@作業ﾒﾓへﾌｫｰｶｽｾｯﾄ
                                If lblnNextCtrl Then
                                    Call pubSetFocus(txtWorkMemo)
                                End If
                            Else
                                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                                If lblnNextCtrl Then
                                    Call pubSetFocus(cmdClose)
                                End If
                            End If
                        Else
                            '@ｲﾍﾞﾝﾄ履歴取得結果：異常の場合
                        
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrCmbRollBackOpIDValidate)
                        End If
                    Else
                        '@戻り小工程ｺﾝﾎﾞのﾃﾞｰﾀが1件以上存在する場合
                    
                        '@戻り小工程が有効か
                        If cmbRollBackStepID.Enabled = True Then
                            '@戻り小工程へﾌｫｰｶｽｾｯﾄ
                            If lblnNextCtrl Then
                                Call pubSetFocus(cmbRollBackStepID)
                            End If
                        Else
                            '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                            If lblnNextCtrl Then
                                Call pubSetFocus(cmdClose)
                            End If
                        End If
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRollBackOpID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRollBackStepID_Change
    '機　能：戻り小工程ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/13 (Tue) 17:18:13 N.Kojima
    '更新日：2008/05/13 (Tue) 17:18:13
    '備　考：
    Private Sub cmbRollBackStepID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRollBackStepID.Change

        Try
            
            '@退避領域と比較して同じかつ使用装置ｺﾝﾎﾞが有効な場合には処理抜け
            If mstrRollBackStepID <> cmbRollBackStepID.Text Then
                '@異なる場合
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                mtypChgSort.strKey = vbNullString
                
                '@=======================
                '@　ｲﾍﾞﾝﾄ履歴一覧ｸﾞﾘｯﾄﾞ初期化処理
                '@=======================
                Call prvVsfEventHistoryList_Init()
                
                '@確定ﾎﾞﾀﾝの無効化
                cmdRegist.Enabled = False
                
                '@退避用変数の初期化
                mstrRollBackStepID = vbNullString         '戻り小工程

            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRollBackStepID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRollBackStepID_CloseUp
    '機　能：戻り小工程ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/15 (Thu) 10:11:25 N.Kojima
    '更新日：2008/05/15 (Thu) 10:11:25
    '備　考：
    Private Sub cmbRollBackStepID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRollBackStepID.CloseUp

        Try

            '@戻り小工程がNULL以外か
            If cmbRollBackStepID.Text <> vbNullString Then
            
                '@=======================
                '@　戻り小工程ｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbRollBackStepID.Validating, AddressOf cmbRollBackStepID_Validate
                Call cmbRollBackStepID_Validate(cmbRollBackStepID, New CancelEventArgs(True))
                AddHandler cmbRollBackStepID.Validating, AddressOf cmbRollBackStepID_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRollBackStepID_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRollBackStepID_Validate
    '機　能：戻り小工程ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/05/15 (Thu) 10:18:36 N.Kojima
    '更新日：2008/05/15 (Thu) 10:18:36
    '備　考：
    Private Sub cmbRollBackStepID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbRollBackStepID.Validating

        Dim lblnAns      As Boolean      'ｲﾍﾞﾝﾄ履歴取得の戻り値格納用
        Dim lblnNextCtrl As Boolean              'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            If ActiveControl Is cmbRollBackStepID Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If

            '@戻り小工程がNULLか
            If cmbRollBackStepID.Text = vbNullString Then
                
                '@作業ﾒﾓが有効か
                If txtWorkMemo.Enabled = True Then
                    '@作業ﾒﾓへﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(txtWorkMemo)
                    End If
                Else
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                
                Exit Sub
            Else
                '@戻り小工程がNULL以外の場合
            
                '@戻り小工程退避領域と現在選択されている戻り小工程が同じか
                If mstrRollBackStepID = cmbRollBackStepID.Text Then
                    '@同じ場合
                
                    '@作業ﾒﾓが有効か
                    If txtWorkMemo.Enabled = True Then
                        '@作業ﾒﾓへﾌｫｰｶｽｾｯﾄ
                        If lblnNextCtrl Then
                            Call pubSetFocus(txtWorkMemo)
                        End If
                    Else
                        '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        If lblnNextCtrl Then
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                    
                    Exit Sub
                Else
                    '@異なる場合
                              
                    '@戻り小工程退避変数にｾｯﾄ
                    mstrRollBackStepID = cmbRollBackStepID.Text
                              
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmbRollBackStepIDValidate)
                                        
                    '@=======================
                    '@　ｲﾍﾞﾝﾄ履歴取得要求ﾃﾞｰﾀ作成処理
                    '@=======================
                    Call prvEventRequestDateSet_Proc(CPstrOne)
                    
                    '@【ｲﾍﾞﾝﾄ履歴取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnMntEventHist_Sel(mtypReqEventInfo, _
                                                     mtypAnsEventInfo)
                                                    
                    '@ｲﾍﾞﾝﾄ履歴取得結果判定
                    If lblnAns = True Then
                        '@ｲﾍﾞﾝﾄ履歴取得結果：正常の場合
                    
                        '@=======================
                        '@　ｲﾍﾞﾝﾄ履歴一覧表示処理
                        '@=======================
                        Call prvVsfEventHistoryList_Disp()
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmbRollBackStepIDValidate)
                        
                        '@作業ﾒﾓが有効か
                        If txtWorkMemo.Enabled = True Then
                            '@作業ﾒﾓへﾌｫｰｶｽｾｯﾄ
                            If lblnNextCtrl Then
                                Call pubSetFocus(txtWorkMemo)
                            End If
                        Else
                            '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                            If lblnNextCtrl Then
                                Call pubSetFocus(cmdClose)
                            End If
                        End If
                    Else
                        '@ｲﾍﾞﾝﾄ履歴取得結果：異常の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmbRollBackStepIDValidate)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRollBackStepID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：作業ﾒﾓﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/15 (Thu) 10:25:39 N.Kojima
    '更新日：2008/05/15 (Thu) 10:25:39
    '備　考：
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change
        
        Dim llngNowByte     As Integer  'ﾊﾞｲﾄ数
        
        Try

            '@作業ﾒﾓの入力ﾃﾞｰﾀﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@=======================
            '@　ﾃｷｽﾄ変更時処理
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
            
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
    '機　能：作業ﾒﾓﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2008/05/15 (Thu) 10:30:12 N.Kojima
    '更新日：2008/05/15 (Thu) 10:30:12
    '備　考：
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：作業ﾒﾓﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2008/05/15 (Thu) 10:30:38 N.Kojima
    '更新日：2008/05/15 (Thu) 10:30:38
    '備　考：
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄ変更時処理
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown, e.Button)
            
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
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/15 (Thu) 10:49:43 N.Kojima
    '更新日：2008/05/15 (Thu) 10:49:43
    '備　考：
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ﾃｷｽﾄ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            '@=======================
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

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
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/15 (Thu) 10:49:59 N.Kojima
    '更新日：2008/05/15 (Thu) 10:49:59
    '備　考：
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ﾃｷｽﾄ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            '@=======================
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

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

    '関数名：vsfEventHistoryList_AfterSort
    '機　能：ｲﾍﾞﾝﾄ履歴一覧ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col    ：ｿｰﾄ列
    '　　　：Order  ：ｿｰﾄ方法
    '戻り値：なし
    '作成日：2008/05/15 (Thu) 10:50:30 N.Kojima
    '更新日：2008/05/15 (Thu) 10:50:30
    '備　考：
    Private Sub vsfEventHistoryList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfEventHistoryList.AfterSort

        Try
            'NSYS ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If mintEventHistoryListRowBeforeSort <  vsfEventHistoryList.Rows.Fixed Then
                vsfEventHistoryList.Row = 0
            End If
            'NSYS ソート時のBeforeRowColChange/RowColChangeイベントの抑制を解除する
            RemoveHandler vsfEventHistoryList.BeforeRowColChange, AddressOf vsfEventHistoryList_BeforeRowColChange
            RemoveHandler vsfEventHistoryList.RowColChange, AddressOf vsfEventHistoryList_RowColChange
            AddHandler vsfEventHistoryList.BeforeRowColChange, AddressOf vsfEventHistoryList_BeforeRowColChange
            AddHandler vsfEventHistoryList.RowColChange, AddressOf vsfEventHistoryList_RowColChange
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfEventHistoryList.Rows.Count <= vsfEventHistoryList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄされた列を格納
            mlngSortCol = e.Col
            '@ｿｰﾄ方法を格納
            mlngSortOrder = e.Order
            
            '@ｿｰﾄ情報を格納
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
            
            '@=======================
            '@　ｿｰﾄ後のｶﾚﾝﾄ行設定処理(ｸﾞﾘｯﾄﾞ、保持列)
            '@=======================
            Call pubVsfAfterSort(vsfEventHistoryList, CMlngvsfEventHistoryListColOpID & vbTab & CMlngvsfEventHistoryListColStepID)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEventHistoryList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEventHistoryList_AfterUserResize
    '機　能：ｲﾍﾞﾝﾄ履歴一覧ｸﾞﾘｯﾄﾞ　ﾕｰｻﾞｰｻｲｽﾞ変更後処理
    '引　数：Row    ：変更行
    '　　　：Col    ：変更列
    '戻り値：なし
    '作成日：2008/05/15 (Thu) 10:52:56 N.Kojima
    '更新日：2008/05/15 (Thu) 10:52:56
    '備　考：
    Private Sub vsfEventHistoryList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfEventHistoryList.AfterResizeColumn, vsfEventHistoryList.AfterResizeRow
        
        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfEventHistoryList.Rows.Count <= vsfEventHistoryList.Rows.Fixed Then
                Return
            End If
            
            '@列幅変更フラグ(変更)
            mtypChgSort.blnChgWidth = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEventHistoryList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEventHistoryList_BeforeRowColChange
    '機　能：ｲﾍﾞﾝﾄ履歴一覧ｸﾞﾘｯﾄﾞ　ﾌｫｰｶｽ移動前処理
    '引　数：OldRow ：旧行
    '　　　：OldCol ：旧列
    '　　　：NewRow ：新行
    '　　　：NewCol ：新列
    '　　　：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 13:58:58 N.Kojima
    '更新日：2006/04/14 (Fri) 13:58:58
    '備　考：
    Private Sub vsfEventHistoryList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfEventHistoryList.BeforeRowColChange

        Dim OldRow,NewRow As Integer
        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfEventHistoryList.Rows.Count <= vsfEventHistoryList.Rows.Fixed Then
                Return
            End If

            OldRow = e.OldRange.r1
            NewRow = e.NewRange.r1

            '@旧行と新行が違っていて、かつ新行がﾃﾞｰﾀ行か
            If OldRow <> NewRow And NewRow > 0 Then
            
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(№)
                mtypChgSort.strKey = vsfEventHistoryList.GetData(NewRow, CMlngvsfEventHistoryListColNo)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEventHistoryList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEventHistoryList_BeforeSort
    '機　能：ｲﾍﾞﾝﾄ履歴一覧ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ順
    '戻り値：なし
    '作成日：2008/05/15 (Thu) 10:55:22 N.Kojima
    '更新日：2008/05/15 (Thu) 10:55:22
    '備　考：
    Private Sub vsfEventHistoryList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfEventHistoryList.BeforeSort

        Try
            'NSYS ソート時はBeforeRowColChange/RowColChangeを抑制する
            RemoveHandler vsfEventHistoryList.BeforeRowColChange, AddressOf vsfEventHistoryList_BeforeRowColChange
            RemoveHandler vsfEventHistoryList.RowColChange, AddressOf vsfEventHistoryList_RowColChange
            mintEventHistoryListRowBeforeSort = vsfEventHistoryList.Row 'NSYS ソート前の選択行を保持
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfEventHistoryList.Rows.Count <= vsfEventHistoryList.Rows.Fixed Then
                Return
            End If
            
            '@=======================
            '@　ｶﾚﾝﾄ行の保持処理(ｸﾞﾘｯﾄﾞ、保持列)
            '@=======================
            Call pubVsfBeforeSort(vsfEventHistoryList, CMlngvsfEventHistoryListColNo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEventHistoryList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEventHistoryList_RowColChange
    '機　能：ｲﾍﾞﾝﾄ履歴一覧ｸﾞﾘｯﾄﾞ　行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/15 (Thu) 10:56:27 N.Kojima
    '更新日：2008/06/26 (Thu) 15:44:02 N.Kojima
    '備　考：
    '　　　：2008/06/26 (Thu) 15:44:02 N.Kojima     確定ﾎﾞﾀﾝ制御を削除。(案件№03029)
    Private Sub vsfEventHistoryList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfEventHistoryList.RowColChange

        Try
            
            With vsfEventHistoryList
                
                '@ﾃﾞｰﾀが存在しない場合及びﾃﾞｰﾀ行以外が選択された場合
                '@　(ﾃﾞｰﾀ行以外が選択された場合は本ｲﾍﾞﾝﾄは発生しないが念の為)
                If .Rows.Count <= 1 Or .Row = 0 Then
                    
                    '@作業ﾒﾓ確認ﾎﾞﾀﾝを無効にする
                    cmdWorkMemoChk.Enabled = False
                    Exit Sub
                End If
                
                '@作業ﾒﾓが存在するか
                If .Row >= .Rows.Fixed AndAlso .GetData(.Row, CMlngvsfEventHistoryListColWorkMemoContents) <> vbNullString Then
                    
                    '@作業ﾒﾓ確認ﾎﾞﾀﾝを有効にする
                    cmdWorkMemoChk.Enabled = True
                Else
                    '@作業ﾒﾓが存在しない場合

                    '@作業ﾒﾓ確認ﾎﾞﾀﾝを無効にする
                    cmdWorkMemoChk.Enabled = False
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEventHistoryList_RowColChange"
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
    '作成日：2008/05/13 (Tue) 15:06:53 N.Kojima
    '更新日：2008/05/13 (Tue) 15:06:53
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '戻り値判定用
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                    
            '@以下の条件の場合、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If
            
            '@***********************
            '@　工程戻し可/不可ﾁｪｯｸ
            '@***********************
            With vsfEventHistoryList
            
                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@削除可否判定ﾌﾗｸﾞが"1:削除不可"か
                    If .GetData(llngCnt, CMlngvsfEventHistoryListColDeleteProhibited) = CPstrOne Then
                        '@削除不可の場合
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0011, lblLotID.Text, CPstrRollBackOpStep)
                        '@ﾒｯｾｰｼﾞ表示："<TRM11W>$$ロット[%1]の履歴には削除不可の履歴が含まれている為、$[%2]できません。システム担当者に連絡して下さい。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Exit Sub
                    End If
                Next llngCnt
            End With
                    
            '@=======================
            '@　工程戻し権限ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnRegistAuthority_Chk()
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If
                
            '@=======================
            '@　ｲﾍﾞﾝﾄ履歴取得/削除要求ﾃﾞｰﾀ作成処理(引数は"2:ｲﾍﾞﾝﾄ履歴削除")
            '@=======================
            Call prvEventRequestDateSet_Proc(CPstrTwo)
            
            '@【ｲﾍﾞﾝﾄ履歴削除】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMntDelHist__Upd(mtypReqEventInfo)
            
            '@ｲﾍﾞﾝﾄ履歴削除通信結果判定
            If lblnAns = True Then
                '@ｲﾍﾞﾝﾄ履歴削除通信結果：正常の場合
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001F, txtCarrier.Text, lblLotID.Text)
                '@成功ﾒｯｾｰｼﾞ表示："<TRM1FI>$$工程戻しを行ないました。キャリア[%1] ロット[%2]"
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                
                '@ｷｬﾘｱIDのｸﾘｱ
                txtCarrier.Text = vbNullString
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽをｾｯﾄする
                Call pubSetFocus(txtCarrier)
                
            Else
                '@ｲﾍﾞﾝﾄ履歴削除通信結果：異常の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                
                Exit Sub
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

    '関数名：cmdWorkMemoChk_Click
    '機　能：作業ﾒﾓ表示画面起動処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/15 (Thu) 10:59:56 N.Kojima
    '更新日：2008/05/15 (Thu) 10:59:56
    '備　考：
    Private Sub cmdWorkMemoChk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkMemoChk.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の条件の場合、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If
            
            '@作業ﾒﾓ引継ぎ用ﾊﾟﾌﾞﾘｯｸ変数の初期化
            pstrWorkMemo = vbNullString
            
            With vsfEventHistoryList
            
                '@作業ﾒﾓ内容をﾊﾟﾌﾞﾘｯｸ変数へ格納
                pstrWorkMemo = .GetData(.Row, CMlngvsfEventHistoryListColWorkMemoContents)
            End With
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業ﾒﾓ画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00Q0.Instance.ShowDialog(Me)
            frmxxCM00Q0.Instance = Nothing
            
            '@作業ﾒﾓ引継ぎ用ﾊﾟﾌﾞﾘｯｸ変数の初期化
            pstrWorkMemo = vbNullString
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkMemoChk_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotComment_Click
    '機　能：ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/12 (Mon) 14:07:23 N.Kojima
    '更新日：2008/05/12 (Mon) 14:07:23
    '備　考：
    Private Sub cmdLotComment_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotComment.Click
        
        Dim lstrTitle       As String       'ﾀｲﾄﾙ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の条件の場合、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            '@ﾛｯﾄ状態が「後処理」か
            If lblLotStatus.Text = CPstrAfterProgressSt Then
            
                '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱを引き継ぎ変数に格納
                pstrCarrierID = txtCarrier.Text
            Else
                '@ﾛｰﾀﾞｰｷｬﾘｱを引き継ぎ変数に格納
                pstrCarrierID = mstrRetainCarrier
            End If
                
            '@子画面起動ﾌﾗｸﾞに"True:子画面として起動"をｾｯﾄ
            pblnfrmxxCM0030Kbn = True

            '@起動ﾌﾗｸﾞに"False:起動処理未完"をｾｯﾄ
            pblnFormLoad = False
                
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　ﾛｯﾄｺﾒﾝﾄ画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0030.Instance = New frmxxCM0030()
            
            '@=======================
            '@　機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0140, lstrTitle)

            '@ﾛｯﾄｺﾒﾝﾄ画面のﾌｫｰﾑ名称を設定する
            frmxxCM0030.Instance.Text = lstrTitle
                
            '@"frmxxCM0030.frm"のForm_Load処理が正常に終了したか
            If pblnFormLoad = True Then
                '@起動処理結果：正常の場合
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　ﾛｯﾄｺﾒﾝﾄ画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0030.Instance.ShowDialog(Me)
                frmxxCM0030.Instance = Nothing
                
                '@最終更新日時が変更された場合は、子画面のﾛｯﾄｺﾒﾝﾄの確定処理にて
                '@"ptypLotprestate.strLotLastUpdate"を更新している為、親画面での更新処理はなし。
                 
            Else
                '@起動処理結果：異常の場合
            
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0030.Instance = Nothing
            
                '@起動ﾌﾗｸﾞを初期化する
                pblnFormLoad = True
                
                Exit Sub
            End If
            
            '@引継ぎ用ｷｬﾘｱID格納変数を初期化
            pstrCarrierID = vbNullString

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotComment_Click"
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
    '作成日：2008/05/15 (Thu) 14:35:29 N.Kojima
    '更新日：2018/11/16 (Fri) 09:47:55 Y.Yoneyama
    '備　考：
    '      ：2018/11/16 (Fri) 09:47:55 Y.Yoneyama   防湿ALD対応
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim ltypCommonInfo      As CommonInfo       '共通引継ぎ用構造体
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の条件の場合、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If
            
            '@引継ぎ情報のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@NULL以外の場合
                
                '@装置別ﾛｯﾄ一覧からの引継ぎ起動か
                If pblnfrmxxEN0150Kbn = True Then
                    
                    '@=======================
                    '@　装置別ﾛｯﾄ一覧起動処理
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN0150)
                    
        '@↓2018/11/16 (Fri) 09:47:55 Y.Yoneyama **************************************************
                '@装置別ﾛｯﾄ(防湿ALD)一覧から引き継いで起動された場合
                ElseIf pblnfrmxxEN0151Kbn = True Then
                    '@装置別ﾛｯﾄ(防湿ALD)一覧を起動する
                    Call pubMenuSelect_Proc(CPstrKeyEN0151)
        '@↑2018/11/16 (Fri) 09:47:55 Y.Yoneyama **************************************************
                    
                Else
                    '@装置別ﾛｯﾄ一覧から以外
                
                    '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧からの引継ぎ起動か
                    If pblnfrmxxEN00J0Kbn = True Then
                    
                        '@=======================
                        '@　装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧起動処理
                        '@=======================
                        Call pubMenuSelect_Proc(CPstrKeyEN00J0)
                    Else
                        '@工程別ﾛｯﾄ一覧からの引継ぎ起動の場合
                        
                        '@=======================
                        '@　工程別ﾛｯﾄ一覧起動処理
                        '@=======================
                        Call pubMenuSelect_Proc(CPstrKeyEN0200)
                    End If
                End If
            Else
                '@引継ぎｷｬﾘｱIDがNULLの場合
                
                '@=======================
                '@　終了処理
                '@=======================
                Call publngEnd_Proc(CPstrKeyEN02A0, ltypCommonInfo)
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

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvFrmxxEN02A0_Init
    '機　能：画面情報初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/12 (Mon) 11:25:59 N.Kojima
    '更新日：2008/06/12 (Thu) 14:51:54 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 14:51:54 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvFrmxxEN02A0_Init()

        Dim lstrFormTitle           As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim ltypLotprestate         As Lotprestate          'ﾛｯﾄ現在状態情報格納構造体初期化用
        Dim ltypOpStepList          As OpStepList           '流動済工程情報格納用構造体初期化用
        Dim ltypReqEventInfo        As ReqEventInfo         'ｲﾍﾞﾝﾄ履歴取得/削除要求ﾃﾞｰﾀ格納用構造体初期化用
        Dim ltypAnsEventInfo        As AnsEventInfo         'ｲﾍﾞﾝﾄ履歴取得応答ﾃﾞｰﾀ格納用構造体初期化用

        Try
            
            '@=======================
            '@　ﾒﾆｭｰ関連付け処理(ﾌｫｰﾑ名、引継ぎﾌﾗｸﾞetc･･･)
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02A0, lstrFormTitle)
            
            '@ﾌｫｰﾑ名を設定する
            Me.Text = lstrFormTitle
            
            '@各種ﾗﾍﾞﾙの初期化
            lblPdID.Text = vbNullString                  '機種
            lblNum.Text = vbNullString                   '数量
            lblOpID.Text = vbNullString                  '大工程
            lblProcStartTime.Text = vbNullString         '処理開始日時
            lblSpecialFlag.Text = vbNullString           '特殊特性
            lblLotID.Text = vbNullString                 'ﾛｯﾄID
            lblFlowClass.Text = vbNullString             '流動区分
            lblLotStatus.Text = vbNullString             '状態
            lblLimitTime.Text = vbNullString             '時間制限
            lblStepID.Text = vbNullString                '小工程
            lblLotManager.Text = vbNullString            'ﾛｯﾄ担当
            '@↓2020/02/19 (Wed) 13:58:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString                   'GRB
            '@GRB背景色
            lblGRB.BackColor = lblLotManager.BackColor
            '@↑2020/02/19 (Wed) 13:58:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
            
            '@作業ﾒﾓの初期化
            With txtWorkMemo
            
                .ChrMaxByte = CPlngLotCommentsMaxByte       '最大入力文字数
                .Text = vbNullString                        'ﾃｷｽﾄ
                
                '@=======================
                '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換)
                '@=======================
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, CMlngMemoDefault, CPlngLotCommentsMaxByte)
                
                .Enabled = False                            '無効
            End With
            
            '@ﾎﾞﾀﾝの初期化(無効化)
            cmdRegist.Enabled = False                       '確定
            cmdWorkMemoChk.Enabled = False                  '作業ﾒﾓ確認
            cmdLotComment.Enabled = False                   'ﾛｯﾄｺﾒﾝﾄ
            
            '@ﾓｼﾞｭｰﾙ変数、ﾊﾟﾌﾞﾘｯｸ変数の初期化
            mstrRollBackOpID = vbNullString                 '戻り大工程退避用
            mstrRollBackStepID = vbNullString               '戻り小工程退避用
            mstrCarrier = vbNullString                      'ｷｬﾘｱID退避用
            mstrRetainCarrier = vbNullString                '引継ぎｷｬﾘｱID退避用
            
            '@ﾓｼﾞｭｰﾙ構造体の初期化
            mtypOpStepList = ltypOpStepList                 '流動済工程情報格納用構造体
            mtypReqEventInfo = ltypReqEventInfo             'ｲﾍﾞﾝﾄ履歴取得/削除要求ﾃﾞｰﾀ格納用構造体
            mtypAnsEventInfo = ltypAnsEventInfo             'ｲﾍﾞﾝﾄ履歴取得応答ﾃﾞｰﾀ格納用構造体

            '@ﾊﾟﾌﾞﾘｯｸ構造体の初期化
            ptypLotprestate = ltypLotprestate               'ﾛｯﾄ現在状態情報格納構造体
                            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            '@　⇒閉じるﾎﾞﾀﾝ押下時は入力ﾁｪｯｸを行なわないようにする為
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN02A0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxEN02A0_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/13 (Tue) 09:32:36 N.Kojima
    '更新日：2008/06/12 (Thu) 14:52:15 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 14:52:15 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvFrmxxEN02A0_Disp()

        Try

            '@ﾛｯﾄ情報の表示
            With ptypLotprestate
            
                lblPdID.Text = .strPdId                                              '機種
                lblOpID.Text = .strOpID                                              '大工程
                If IsDate(.strStartTime) Then
                    lblProcStartTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat)  '処理開始日時"MM/dd HH:mm:ss"
                Else
                    lblProcStartTime.Text = .strStartTime                            '処理開始日時"MM/dd HH:mm:ss"
                End If
                lblSpecialFlag.Text = .strSpecialFlg                                 '特殊特性
                lblLotID.Text = .strLotID                                            'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                    '流動区分
                lblLotStatus.Text = .strNowST                                        'ﾛｯﾄ状態
                lblStepID.Text = .strStepID                                          '小工程
                lblLotManager.Text = .strEngEmpName                                  'ﾛｯﾄ担当
                '@↓2020/02/19 (Wed) 13:49:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                                           'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotManager.BackColor)
                '@↑2020/02/19 (Wed) 13:49:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then
                    
                    '@時間制約がﾌﾟﾗｽの場合
                    If CLng(.strLimitTime) >= 0 Then
                        
                        '@制限時間以下or処理時間制限以下の場合
                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@制限時間先大工程+制限時間先小工程+制限時間
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"、右寄せ表示
                            lblLimitTime.Text = Format(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            lblLimitTime.TextAlign = ContentAlignment.TopRight
                            
                            '@警告時間が設定されている場合
                            If .strWarnTime <> vbNullString Then
                            
                                '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                If CLng(.strWarnTime) < 0 And CLng(.strLimitTime) >= 0 Then
                                
                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                    lblLimitTime.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)
                                Else
                                     '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                    lblLimitTime.ForeColor = Color.Black
                                End If
                            End If
                        End If
                        
                    Else
                        '@制限時間がﾏｲﾅｽの場合
                        
                        '@制限時間先大工程+制限時間先小工程+制限時間
                        '@文字色を赤にして、右寄せ表示
                        lblLimitTime.TextAlign = ContentAlignment.TopRight
                        lblLimitTime.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                        
                        '@制限時間以下or処理時間制限以下の場合
                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblLimitTime.Text = Format(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                        End If
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                        
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblLimitTime.Text = Replace(Format(CLng(.strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString) & CPstrh
                        End If
                    End If
                End If

                '@★ CF_FLAG(対向基板判定ﾌﾗｸﾞ)により処理分岐(WF枚数とﾁｯﾌﾟ枚数の表示を切替) ★
                Select Case .strCfFlag
                
                    '@〓 1:CFﾛｯﾄ 〓
                    Case CPstrCF
                    
                        '@ODFﾌﾗｸﾞ(LP_FLAG)が"1:ODF"か
                        If .strLpFlag = CPstrLP Then
                            '@"1:ODF"の場合
                            
                            '@数量にWF枚数を表示する
                            lblNum.Text = .strWfNum
                        Else
                            '@"1:ODF"以外の場合
                            
                            '@数量にﾁｯﾌﾟ数を表示する
                            If IsNumeric(.strChipQuantity) Then
                                lblNum.Text = Format$(CLng(.strChipQuantity), CPstrCFKnmaFormat)
                            Else
                                lblNum.Text = .strChipQuantity
                            End If
                        End If
                    
                    
                    '@〓 その他 〓
                    Case Else

                        '@TPALﾛｯﾄか(LotIDの頭2文字が"TP"か)
                        If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                            '@TPALﾛｯﾄの場合
                            
                            '@数量にﾁｯﾌﾟ数を表示する
                            If IsNumeric(.strChipQuantity) Then
                                lblNum.Text = Format$(CLng(.strChipQuantity), CPstrCFKnmaFormat)
                            Else
                                lblNum.Text = .strChipQuantity
                            End If
                        Else
                            '@TPALﾛｯﾄ以外の場合
                            
                            '@数量にWF枚数を表示する
                            lblNum.Text = .strWfNum
                        End If
                End Select
            End With
            
            '@作業ﾒﾓを有効にする
            txtWorkMemo.Enabled = True

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN02A0_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvAllInit_Proc
    '機　能：各種初期化処理
    '引　数：なし
    '戻り値：True:成功、False:失敗
    '作成日：2008/05/15 (Thu) 14:38:35 N.Kojima
    '更新日：2008/05/15 (Thu) 14:38:35
    '備　考：
    Private Sub prvAllInit_Proc()

        Try
            
            '@=======================
            '@　画面情報初期化処理
            '@=======================
            Call prvFrmxxEN02A0_Init()
            
            '@=======================
            '@　ｺﾝﾎﾞの初期化処理(戻り大工程ｺﾝﾎﾞ、戻り小工程ｺﾝﾎﾞ)
            '@=======================
            Call prvAllCombo_Init()
            
            '@=======================
            '@　ｲﾍﾞﾝﾄ履歴一覧ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvVsfEventHistoryList_Init()
            
            '@ｿｰﾄ保持構造体初期化
            With mtypChgSort
                .lngCnt = 0
                .blnChgWidth = False        '列幅変更ﾌﾗｸﾞ(未変更)
                .strKey = vbNullString      'ｶﾚﾝﾄ行検索ｷｰを初期化
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)()  '配列
                Else
                    .typChgSortList.Clear()  '配列
                End If
            End With

            '@各種ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝの制御
            cmdMemoUp.Enabled = False       '作業ﾒﾓ ▲ﾎﾞﾀﾝ
            cmdMemoDown.Enabled = False     '作業ﾒﾓ ▼ﾎﾞﾀﾝ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvAllInit_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvAllCombo_Init
    '機　能：画面内全ｺﾝﾎﾞﾎﾞｯｸｽの初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/12 (Mon) 12:58:15 N.Kojima
    '更新日：2008/05/12 (Mon) 12:58:15
    '備　考：
    Private Sub prvAllCombo_Init()

        Dim lctlControl     As Control      'ｺﾝﾄﾛｰﾙ名称取得用変数

        Try

            '@ｺﾝﾎﾞの初期化＆初期設定
            For Each lctlControl In Me.Controls
                
                '@ｺﾝﾎﾞか
                If TypeOf lctlControl Is SEComboBoxEx.ComboBoxEx Then
                    
                    With Ctype(lctlControl, SEComboBoxEx.ComboBoxEx)

                        '.Enabled = True                             '有効
                        .Clear()                                    'ｸﾘｱ
                        .DispCols = CMlngCmbDispCols                'ｸﾞﾘｯﾄﾞ表示列数
                        .GetCol = CMlngCmbGridColName               'ﾃｷｽﾄ表示列
                        .ValueCol = CMlngCmbGridColID               '値取得列
                        .DirectInput = False                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                        .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                         .Font.Style, .Font.Unit)   'ﾌｫﾝﾄｻｲｽﾞ
                        .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                             .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                        .RowHeight = CMlngCmbHeight                 'ｸﾞﾘｯﾄﾞの高さ
                        .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter 'ｸﾞﾘｯﾄﾞ表示位置(左中央)
                    End With
                End If
            Next
            
            '@全てのｺﾝﾎﾞの無効化
            cmbRollBackOpID.Enabled = False         '戻り大工程
            cmbRollBackStepID.Enabled = False       '戻り小工程

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvAllCombo_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbRollBackOpID_Disp
    '機　能：戻り大工程ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/13 (Tue) 14:35:56 N.Kojima
    '更新日：2008/05/13 (Tue) 14:35:56
    '備　考：
    Private Sub prvCmbRollBackOpID_Disp()

        Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ

        Try

            With cmbRollBackOpID

                .Clear()                                                      'ｸﾘｱ
                .Height = CMlngCmbHeight                                      'ﾃﾞｰﾀ行の高さ
                .DispCols = CMlngCmbDispCols                                  'ﾃﾞｰﾀの表示列数
                .ValueCol = CMlngCmbGridColID                                 '値取得列
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter '左寄中央揃え
                
                '@戻り大工程情報をｺﾝﾎﾞにｾｯﾄ
                For llngCnt = 0 To mtypOpStepList.lngOpListCnt - 1

                    '@大工程ID/ｲﾝﾃﾞｯｸｽ
                    .AddItem(mtypOpStepList.typOpList(llngCnt).strOpID & vbTab & llngCnt)
                    
                    '@戻り大工程を有効にする
                    .Enabled = True
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbRollBackOpID_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbRollBackStepID_Disp
    '機　能：戻り小工程ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/13 (Tue) 14:39:40 N.Kojima
    '更新日：2008/05/13 (Tue) 14:39:40
    '備　考：
    Private Sub prvCmbRollBackStepID_Disp()

        Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ
        Dim llngCnt2    As Integer      '汎用ｶｳﾝﾀ2

        Try

            With cmbRollBackStepID

                .Clear()                                                   'ｸﾘｱ
                .Height = CMlngCmbHeight                                   'ﾃﾞｰﾀ行の高さ
                .DispCols = CMlngCmbDispCols                               'ﾃﾞｰﾀ表示列数
                .ValueCol = CMlngCmbGridColID                              '値取得列
                .ColAlignment(CMlngCmbDispCols) = TextAlignEnum.LeftCenter '左寄中央揃え
                
                For llngCnt = 0 To mtypOpStepList.lngOpListCnt - 1
                    
                    '@選択大工程とﾘｽﾄの大工程が同じか
                    If cmbRollBackOpID.Text = mtypOpStepList.typOpList(llngCnt).strOpID Then
                    
                        '@戻り小工程情報をｺﾝﾎﾞにｾｯﾄ
                        For llngCnt2 = 0 To mtypOpStepList.typOpList(llngCnt).lngStepListCnt - 1
                        
                            '@小工程ID/ｲﾝﾃﾞｯｸｽ
                            .AddItem(mtypOpStepList.typOpList(llngCnt).typStepList(llngCnt2).strStepID & vbTab & llngCnt)
                            
                            '@戻り小工程を有効にする
                            .Enabled = True
                        Next llngCnt2
                    End If
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbRollBackStepID_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfEventHistoryList_Init
    '機　能：工程間履歴一覧ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/12 (Mon) 13:01:20 N.Kojima
    '更新日：2008/05/12 (Mon) 13:01:20
    '備　考：
    Private Sub prvVsfEventHistoryList_Init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfEventHistoryList
                .Redraw = False

                .Clear(ClearFlags.Content)                                  'ｸﾘｱ
                .AllowSorting = AllowSortingEnum.SingleColumn               'ｿｰﾄあり(ｿｰﾄ方向表示あり)
                .Rows.Count = .Rows.Fixed                                   '初期行数設定
                .SelectionMode = SelectionModeEnum.Row                      '行選択
                .FocusRect = FocusRectEnum.Light                            'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠(細い枠)
                .ScrollBars = ScrollBars.Both                               'ｽｸﾛｰﾙﾊﾞｰ(水平、垂直両方)
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter　'文字列の最後に省略符号
                .AllowResizing = AllowResizingEnum.Columns                  '列幅の変更許可
                .ExtendLastCol = True                                       '右端の列をｸﾞﾘｯﾄﾞに合わせる
                .Font = New Font(.Font.FontFamily, CMlngvsfFontSize, _
                                 .Font.Style, .Font.Unit)                   'ﾌｫﾝﾄｻｲｽﾞ指定(=11)
                
                '@ﾀｲﾄﾙ行の設定(文字色、背景色、ﾌｫﾝﾄｻｲｽﾞ、ｾﾙ表示位置：中央中央)
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngVsfColTitle, CMlngVsfRowTitle, .Cols.Count - 1) '表題
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                     '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))       '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngVsfHFontSize, _
                                            headerStyle.Font.Style, headerStyle.Font.Unit)               'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                       '文字位置
                headerStyle.Trimming  = StringTrimming.None                                              'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfEventHistoryListColNo, CMstrvsfEventHistoryListColTNo)                                 '№
                .SetData(CMlngVsfRowTitle, CMlngvsfEventHistoryListColOpID, CMstrvsfEventHistoryListColTOpID)                             '大工程
                .SetData(CMlngVsfRowTitle, CMlngvsfEventHistoryListColStepID, CMstrvsfEventHistoryListColTStepID)                         '小工程
                .SetData(CMlngVsfRowTitle, CMlngvsfEventHistoryListColLotEventID, CMstrvsfEventHistoryListColTLotEventID)                 'ﾛｯﾄｲﾍﾞﾝﾄID(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfEventHistoryListColLotEventName, CMstrvsfEventHistoryListColTLotEventName)             'ﾛｯﾄｲﾍﾞﾝﾄ名
                .SetData(CMlngVsfRowTitle, CMlngvsfEventHistoryListColEntryTime, CMstrvsfEventHistoryListColTEntryTime)                   '登録日時
                .SetData(CMlngVsfRowTitle, CMlngvsfEventHistoryListColEmpID, CMstrvsfEventHistoryListColTEmpID)                           '作業者ID(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfEventHistoryListColEmpName, CMstrvsfEventHistoryListColTEmpName)                       '作業者名
                .SetData(CMlngVsfRowTitle, CMlngvsfEventHistoryListColWorkMemo, CMstrvsfEventHistoryListColTWorkMemo)                     '作業ﾒﾓ(あり/なし)
                .SetData(CMlngVsfRowTitle, CMlngvsfEventHistoryListColWorkMemoContents, CMstrvsfEventHistoryListColTWorkMemoContents)     '作業ﾒﾓ内容(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfEventHistoryListColDeleteProhibited, CMstrvsfEventHistoryListColTDeleteProhibited)     '削除可否判定ﾌﾗｸﾞ(0:削除可、1:削除不可)(非表示)
                        
                '@ﾕｰｻﾞによる列幅変更されていないか
                If mtypChgSort.blnChgWidth = False Then
                    '@列幅が変更されていない場合

                    ''@列幅設定
                    '.Cols(CMlngvsfEventHistoryListColNo).Width = CMlngvsfEventHistoryListColWNo                                   '№
                    '.Cols(CMlngvsfEventHistoryListColOpID).Width = CMlngvsfEventHistoryListColWOpID                               '大工程
                    '.Cols(CMlngvsfEventHistoryListColStepID).Width = CMlngvsfEventHistoryListColWStepID                           '小工程
                    '.Cols(CMlngvsfEventHistoryListColLotEventID).Width = CMlngvsfEventHistoryListColWLotEventID                   'ﾛｯﾄｲﾍﾞﾝﾄID(非表示)
                    '.Cols(CMlngvsfEventHistoryListColLotEventName).Width = CMlngvsfEventHistoryListColWLotEventName               'ﾛｯﾄｲﾍﾞﾝﾄ名
                    '.Cols(CMlngvsfEventHistoryListColEntryTime).Width = CMlngvsfEventHistoryListColWEmpID                         '登録日時
                    '.Cols(CMlngvsfEventHistoryListColEmpID).Width = CMlngvsfEventHistoryListColWEmpName                           '作業者ID(非表示)
                    '.Cols(CMlngvsfEventHistoryListColEmpName).Width = CMlngvsfEventHistoryListColWEntryTime                       '作業者名
                    '.Cols(CMlngvsfEventHistoryListColWorkMemo).Width = CMlngvsfEventHistoryListColWWorkMemo                       '作業ﾒﾓ(あり/なし)
                    '.Cols(CMlngvsfEventHistoryListColWorkMemoContents).Width = CMlngvsfEventHistoryListColWWorkMemoContents       '作業ﾒﾓ内容(非表示)
                    '.Cols(CMlngvsfEventHistoryListColDeleteProhibited).Width = CMlngvsfEventHistoryListColWDeleteProhibited       '削除可否判定ﾌﾗｸﾞ(0:削除可、1:削除不可)(非表示)
                End If
                
                '@非表示列設定
                .Cols(CMlngvsfEventHistoryListColLotEventID).Visible = False            'ﾛｯﾄｲﾍﾞﾝﾄID
                .Cols(CMlngvsfEventHistoryListColEmpID).Visible = False                 '作業者ID
                .Cols(CMlngvsfEventHistoryListColWorkMemoContents).Visible = False      '作業ﾒﾓ内容
                .Cols(CMlngvsfEventHistoryListColDeleteProhibited).Visible = False      '削除可否判定ﾌﾗｸﾞ(0:削除可、1:削除不可)
                
                '@ﾀｲﾄﾙ設定後の各種設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    'ﾍｯﾀﾞｰの高さを設定
                .LeftCol = CMlngvsfEventHistoryListColNo            'ﾌｫｰｶｽ位置
                .FocusRect = FocusRectEnum.Light                    'ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .AllowResizing = AllowResizingEnum.Columns          '幅の変更を許可

                .Redraw = True

                .Enabled = False                                    'ﾛｯｸ解除
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfEventHistoryList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfEventHistoryList_Disp
    '機　能：ｲﾍﾞﾝﾄ履歴一覧ｸﾞﾘｯﾄﾞ表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/05/13 (Tue) 14:58:53 N.Kojima
    '更新日：2008/05/13 (Tue) 14:58:53
    '備　考：
    Private Sub prvVsfEventHistoryList_Disp()

        Dim llngCnt                 As Integer      'ｶｳﾝﾄ
        Dim lblnRegistControlFlag   As Boolean      '確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(True:確定ﾎﾞﾀﾝ有効、False:確定ﾎﾞﾀﾝ無効)

        Try
            
            '@確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞを初期化する
            lblnRegistControlFlag = True
            
            With vsfEventHistoryList
                        
                '@ｲﾍﾞﾝﾄ履歴一覧ﾃﾞｰﾀが1件以上存在するか
                If mtypAnsEventInfo.lngEventListCnt > 0 Then
                    '@ﾃﾞｰﾀがある場合
                     .Enabled = True                         'ﾛｯｸ解除

                    'NSYS 不要イベント発生抑止
                    RemoveHandler vsfEventHistoryList.BeforeRowColChange, AddressOf vsfEventHistoryList_BeforeRowColChange
                    RemoveHandler vsfEventHistoryList.RowColChange, AddressOf vsfEventHistoryList_RowColChange

                    .Redraw = False                                      '描画ﾛｯｸ
                    .Rows.Count = mtypAnsEventInfo.lngEventListCnt + 1   '行数設定

                    For llngCnt = 1 To mtypAnsEventInfo.lngEventListCnt
                    
                        '@№
                        .SetData(llngCnt, CMlngvsfEventHistoryListColNo, llngCnt)
                        
                        '@大工程
                        .SetData(llngCnt, CMlngvsfEventHistoryListColOpID, _
                            mtypAnsEventInfo.typEventList(llngCnt-1).strOpID)
                        
                        '@小工程
                        .SetData(llngCnt, CMlngvsfEventHistoryListColStepID, _
                            mtypAnsEventInfo.typEventList(llngCnt-1).strStepID)
                        
                        '@ﾛｯﾄｲﾍﾞﾝﾄID
                        .SetData(llngCnt, CMlngvsfEventHistoryListColLotEventID, _
                            mtypAnsEventInfo.typEventList(llngCnt-1).strLotEventId)

                        '@ﾛｯﾄｲﾍﾞﾝﾄ名
                        .SetData(llngCnt, CMlngvsfEventHistoryListColLotEventName, _
                            mtypAnsEventInfo.typEventList(llngCnt-1).strLotEventName)

                        '@登録日時
                        If IsDate(mtypAnsEventInfo.typEventList(llngCnt-1).strEntryTime) Then
                            .SetData(llngCnt, CMlngvsfEventHistoryListColEntryTime, _
                                Format$(CDate(mtypAnsEventInfo.typEventList(llngCnt-1).strEntryTime), CPstrDateTimeYMDHMS))
                        Else
                            .SetData(llngCnt, CMlngvsfEventHistoryListColEntryTime, _
                                mtypAnsEventInfo.typEventList(llngCnt-1).strEntryTime)
                        End If

                        '@作業者ID
                        .SetData(llngCnt, CMlngvsfEventHistoryListColEmpID, _
                            mtypAnsEventInfo.typEventList(llngCnt-1).strEmpID)
                            
                        '@作業者名
                        .SetData(llngCnt, CMlngvsfEventHistoryListColEmpName, _
                            mtypAnsEventInfo.typEventList(llngCnt-1).strEmpName)

                        '@作業ﾒﾓ内容
                        .SetData(llngCnt, CMlngvsfEventHistoryListColWorkMemoContents, _
                            mtypAnsEventInfo.typEventList(llngCnt-1).strComments)
                        
                        '@作業ﾒﾓ内容がNULL以外か
                        If .GetData(llngCnt, CMlngvsfEventHistoryListColWorkMemoContents) <> vbNullString Then
                            '@作業ﾒﾓがある場合
                        
                            '@作業ﾒﾓ(あり)
                            .SetData(llngCnt, CMlngvsfEventHistoryListColWorkMemo, CPstrAriFlg)
                        Else
                            '@作業ﾒﾓがない場合
                        
                            '@作業ﾒﾓ(なし:NULL)
                            .SetData(llngCnt, CMlngvsfEventHistoryListColWorkMemo, vbNullString)
                        End If

                        '@削除可否判定ﾌﾗｸﾞ(0:削除可、1:削除不可)
                        .SetData(llngCnt, CMlngvsfEventHistoryListColDeleteProhibited, _
                            mtypAnsEventInfo.typEventList(llngCnt-1).strDeleteProhibited)

                        '@削除可否判定ﾌﾗｸﾞが"1:削除不可"か
                        If .GetData(llngCnt, CMlngvsfEventHistoryListColDeleteProhibited) = CPstrOne Then
                        
                            '@背景色を灰色に設定する
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfEventHistoryListColNo, _
                                    llngCnt, CMlngvsfEventHistoryListColDeleteProhibited)
                            cellRange.Style = newStyle
                            
                            '@確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"False:確定ﾎﾞﾀﾝ無効"をｾｯﾄ
                            lblnRegistControlFlag = False
                        End If

                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngCnt).Height = CMlngVsfHeight

                    Next llngCnt
                                
                    '@ﾕｰｻﾞｰにより列幅変更されていないか
                    If mtypChgSort.blnChgWidth = False Then
                        '@変更されていない場合
                    
                        '@列幅設定(固定列は元に戻す)
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCols(CMlngvsfEventHistoryListColNo, CMlngvsfEventHistoryListColDeleteProhibited, 6)
                    End If
                    
                    '@文字表示位置設定
                    .Cols(CMlngvsfEventHistoryListColNo).TextAlign = TextAlignEnum.RightCenter                 '№(右中央)
                    .Cols(CMlngvsfEventHistoryListColOpID).TextAlign = TextAlignEnum.LeftCenter                '大工程ID(左中央)
                    .Cols(CMlngvsfEventHistoryListColStepID).TextAlign = TextAlignEnum.LeftCenter              '小工程ID(左中央)
                    .Cols(CMlngvsfEventHistoryListColLotEventID).TextAlign = TextAlignEnum.LeftCenter          'ﾛｯﾄｲﾍﾞﾝﾄID(左中央)
                    .Cols(CMlngvsfEventHistoryListColLotEventName).TextAlign = TextAlignEnum.LeftCenter        'ﾛｯﾄｲﾍﾞﾝﾄ名(左中央)
                    .Cols(CMlngvsfEventHistoryListColEntryTime).TextAlign = TextAlignEnum.LeftCenter           '登録日時(左中央)
                    .Cols(CMlngvsfEventHistoryListColEmpID).TextAlign = TextAlignEnum.LeftCenter               '作業者ID(左中央)
                    .Cols(CMlngvsfEventHistoryListColEmpName).TextAlign = TextAlignEnum.LeftCenter             '作業者名(左中央)
                    .Cols(CMlngvsfEventHistoryListColWorkMemo).TextAlign = TextAlignEnum.LeftCenter            '作業ﾒﾓ(あり/なし)(左中央)
                    .Cols(CMlngvsfEventHistoryListColWorkMemoContents).TextAlign = TextAlignEnum.LeftCenter    '作業ﾒﾓ内容(左中央)
                    .Cols(CMlngvsfEventHistoryListColDeleteProhibited).TextAlign = TextAlignEnum.LeftCenter    '削除可否判定ﾌﾗｸﾞ(左中央)
                            
                    '@ﾕｰｻﾞｰによりｿｰﾄされているか
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄされている場合
                        
                        '@ｿｰﾄ保持ﾘｽﾄ分ﾙｰﾌﾟ
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                        
                            '@該当行をｿｰﾄする
                            .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort,mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If

                    'NSYS 不要イベント発生抑止解除
                    AddHandler vsfEventHistoryList.BeforeRowColChange, AddressOf vsfEventHistoryList_BeforeRowColChange
                    AddHandler vsfEventHistoryList.RowColChange, AddressOf vsfEventHistoryList_RowColChange
                    
                    '@ｿｰﾄ検索用ｷｰがあるか
                    If mtypChgSort.strKey <> vbNullString Then
                        '@ｿｰﾄ検索用ｷｰがある場合
                        
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            
                            '@"大工程+小工程"がｿｰﾄ検索ｷｰと同じか
                            If .GetData(llngCnt, CMlngvsfEventHistoryListColOpID) & _
                                .GetData(llngCnt, CMlngvsfEventHistoryListColStepID) = mtypChgSort.strKey Then
                                
                                .Row = llngCnt
                                
                                '@=======================
                                '@　ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列(大工程＆小工程))処理
                                '@=======================
                                Call pubVsfBeforeSort(vsfEventHistoryList, CMlngvsfEventHistoryListColOpID & vbTab & CMlngvsfEventHistoryListColStepID)
                                
                                '@=======================
                                '@　ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列(大工程＆小工程))処理
                                '@=======================
                                Call pubVsfAfterSort(vsfEventHistoryList, CMlngvsfEventHistoryListColOpID & vbTab & CMlngvsfEventHistoryListColStepID)
                                
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        .Row = CMlngVsfRowTitle
                    End If
                    
                    '@ﾃﾞｰﾀ表示後のｸﾞﾘｯﾄﾞ処理
                    .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter  '文字切れの場合、語尾に"..."表示
                    .Redraw = True                          '描画
                    Call pubSetFocus(vsfEventHistoryList)   'ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                
                End If
            End With
            
            '@確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞが"True:確定ﾎﾞﾀﾝ有効"か
            If lblnRegistControlFlag = True Then
                '@"True:確定ﾎﾞﾀﾝ有効"の場合
            
                '@確定ﾎﾞﾀﾝを有効にする
                cmdRegist.Enabled = True
            Else
                '@"False:確定ﾎﾞﾀﾝ無効"の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfEventHistoryList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvEventRequestDateSet_Proc
    '機　能：ｲﾍﾞﾝﾄ履歴取得/削除要求ﾃﾞｰﾀ作成処理
    '引　数：lstrEventID    ：呼び元ｲﾍﾞﾝﾄID(1:ｲﾍﾞﾝﾄ履歴取得、2:ｲﾍﾞﾝﾄ履歴削除)
    '戻り値：なし
    '作成日：2006/10/24 (Tue) 15:27:53 N.Kojima
    '更新日：2007/06/13 (Wed) 10:16:18 N.Kasai  №01941
    '備　考：
    Private Sub prvEventRequestDateSet_Proc(ByVal lstrEventID As String)

        Dim ltypReqEventInfo    As ReqEventInfo     'ｲﾍﾞﾝﾄ履歴取得/削除要求ﾃﾞｰﾀ格納用構造体初期化用
        
        Try
            
            '@要求ﾃﾞｰﾀ格納構造体の初期化
            mtypReqEventInfo = ltypReqEventInfo
            
            '@****************
            '@　要求ﾃﾞｰﾀ作成
            '@****************
            With mtypReqEventInfo
                
                '@呼び元ｲﾍﾞﾝﾄが"1:ｲﾍﾞﾝﾄ履歴取得"か(呼び元ｲﾍﾞﾝﾄIDにより設定を変更する)
                If lstrEventID = CPstrOne Then
                    '@"1:ｲﾍﾞﾝﾄ履歴取得"の場合

                    .strMsgVer = CMstrmnt_eventhistVer                      'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                    .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸID
                    .strLotID = ptypLotprestate.strLotID                    'ﾛｯﾄID
                    .strOpID = cmbRollBackOpID.Text                         '大工程
                    .strStepID = cmbRollBackStepID.Text                     '小工程
                    .strEmpID = vbNullString                                '作業者ID
                    .strComments = vbNullString                             '作業ﾒﾓ
                    .strLotLastUpdate = vbNullString                        '最終更新日時
                
                Else
                    '@"2:ｲﾍﾞﾝﾄ履歴削除"の場合

                    .strMsgVer = CMstrmnt_delhist_Ver                       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                    .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸID
                    .strLotID = ptypLotprestate.strLotID                    'ﾛｯﾄID
                    .strOpID = cmbRollBackOpID.Text                         '大工程
                    .strStepID = cmbRollBackStepID.Text                     '小工程
                    .strEmpID = pstrUserID                                  '作業者ID
                    .strComments = txtWorkMemo.Text                         '作業ﾒﾓ
                    .strLotLastUpdate = ptypLotprestate.strLotLastUpdate    '最終更新日時
                End If
         
            End With
            
            Exit Sub

        Catch ex As Exception

            '@画面の使用禁止解除
            'Me.Enabled = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvEventRequestDateSet_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnRegistAuthority_Chk
    '機　能：工程戻し権限ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True:成功、False:失敗
    '作成日：2008/05/15 (Thu) 14:38:35 N.Kojima
    '更新日：2008/05/15 (Thu) 14:38:35
    '備　考：
    Private Function prvblnRegistAuthority_Chk() As Boolean
        
        Dim lstrFunctionID          As String       '機能ID
        Dim lstrActionID            As String       'ｱｸｼｮﾝID
        Dim lstrEmpName             As String       '作業者名
        Dim lblnAns                 As Boolean      '戻り値格納用

        Try
            
            '@戻り値を初期化する
            prvblnRegistAuthority_Chk = False

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Function
            End If
                
            '@実行権限の処理を追加
            lstrFunctionID = CMstrLocalMenuKey          '機能ID：EN02A0(工程戻し)
            lstrActionID = CPstrRollBackOpStep          'ｱｸｼｮﾝID：工程戻し
            lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名：NULL
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
            
            '@=======================
            '@　実行権限ﾁｪｯｸ処理
            '@=======================
            lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                       lstrActionID, _
                                       pstrUserID, _
                                       pstrUserName, _
                                       pstrSBID)

            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, pstrUserName, lstrActionID)
                '@ﾒｯｾｰｼﾞ表示："<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
            
                Exit Function
            End If

            '@戻り値に"True:権限ﾁｪｯｸOK"をｾｯﾄ
            prvblnRegistAuthority_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRegistAuthority_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
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


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfEventHistoryList.BeforeDoubleClick

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
    Private Sub cursor_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Enter, _
            cmdMemoUp.Enter, cmdMemoDown.Enter, cmdRegist.Enter, cmdLotComment.Enter,  cmdWorkMemoChk.Enter,  _
            cmbRollBackOpID.Enter, cmbRollBackStepID.Enter, txtCarrier.Enter, txtWorkMemo.Enter, vsfEventHistoryList.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = AutoValidate.Disable

            '自動Validate = ON
            Case Else
                Me.AutoValidate = AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
