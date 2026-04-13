'ﾌｧｲﾙ名：xxEN01I0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：部材履歴ﾒｲﾝﾌｫｰﾑ
'作成日：2004/11/02 (Tue) 10:33:18 S.Deguchi
'更新日：2011/12/27 (Tue) 16:23:47 T.Oide
'備　考：
'　　　：2005/02/08 (Tue) 11:39:34 S.Deguchi    不具合№502対応で受入元ﾛｯﾄID追加
'　　　：2007/08/27 (Mon) 11:47:39 N.Kasai      ｿｰｽ整備
'　　　：2011/12/27 (Tue) 16:23:47 T.Oide       REQ-1115 不良、払出の区分け対応
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01I0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01I0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01I0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01I0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01I0)
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
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2011/12/27 (Tue) 16:25:44 T.Oide **************************************************
    'Private Const CMstrLocalVersion                     As String = "02.02"                 '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                     As String = "02.03"                 '機能ﾊﾞｰｼﾞｮﾝ
    '@↑2011/12/27 (Tue) 16:25:44 T.Oide **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN01I0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_partlistVer                  As String = "03.00"                 '部材ﾘｽﾄ
    Private Const CMstrmas_vendclasslistVer             As String = "02.00"                 'ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄ取得
    Private Const CMstrinv_history_Ver                  As String = "03.00"                 '部材履歴要求

    '@vsfStockListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfStockLColNo                   As Integer = 0                      '№
    Private Const CMlngvsfStockLColDate                 As Integer = 1                      '日時
    Private Const CMlngvsfStockLColStLotID              As Integer = 2                      '在庫ID
    Private Const CMlngvsfStockLColPrLotID              As Integer = 3                      '製造ﾛｯﾄID
    Private Const CMlngvsfStockLColCFLotID              As Integer = 4                      'CFﾛｯﾄID
    Private Const CMlngvsfStockLColBoardThickness       As Integer = 5                      '板厚
    Private Const CMlngvsfStockLColStatus               As Integer = 6                      '状態
    Private Const CMlngvsfStockLColNumGet               As Integer = 7                      '数量受入
    Private Const CMlngvsfStockLColNumPut               As Integer = 8                      '数量払出
    Private Const CMlngvsfStockLColLotID                As Integer = 9                      'ﾛｯﾄID
    Private Const CMlngvsfStockLColReworkCount          As Integer = 10                     'ﾘﾜｰｸ回数
    Private Const CMlngvsfStockLColReworkLotID          As Integer = 11                     '受入元ﾛｯﾄID
    Private Const CMlngvsfStockLColReasonCode           As Integer = 12                     '理由ｺｰﾄﾞ
    Private Const CMlngvsfStockLColEmpID                As Integer = 13                     '担当
    Private Const CMlngvsfStockLColWorkMemoFlag         As Integer = 14                     '作業ﾒﾓ
    Private Const CMlngvsfStockLColWorkMemo             As Integer = 15                     '作業ﾒﾓ内容

    '@vsfStockListの定数宣言(幅)
    Private Const CMlngvsfStockLWColNo                  As Integer = 40                     '№
    Private Const CMlngvsfStockLWColDate                As Integer = 160                    '日時
    Private Const CMlngvsfStockLWColStLotID             As Integer = 113                    '在庫ID
    Private Const CMlngvsfStockLWColPrLotID             As Integer = 113                    '製造ﾛｯﾄID
    Private Const CMlngvsfStockLWColCFLotID             As Integer = 113                    'CFﾛｯﾄID
    Private Const CMlngvsfStockLWColBoardThickness      As Integer = 53                     '板厚
    Private Const CMlngvsfStockLWColStatus              As Integer = 93                     '状態
    Private Const CMlngvsfStockLWColNumGet              As Integer = 80                     '数量受入
    Private Const CMlngvsfStockLWColNumPut              As Integer = 80                     '数量払出
    Private Const CMlngvsfStockLWColLotID               As Integer = 93                     'ﾛｯﾄID
    Private Const CMlngvsfStockLWColReworkCount         As Integer = 53                     'ﾘﾜｰｸ回数
    Private Const CMlngvsfStockLWColReworkLotID         As Integer = 113                    '受入元ﾛｯﾄID
    Private Const CMlngvsfStockLWColReasonCode          As Integer = 100                    '理由ｺｰﾄﾞ
    Private Const CMlngvsfStockLWColEmpID               As Integer = 100                    '担当
    Private Const CMlngvsfStockLWColWorkMemoFlag        As Integer = 100                    '作業ﾒﾓ
    Private Const CMlngvsfStockLWColWorkMemo            As Integer = 160                    '作業ﾒﾓ内容

    '@vsfStockListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfStockLColNo                   As String = "№"
    Private Const CMstrvsfStockLColDate                 As String = "日時"
    Private Const CMstrvsfStockLColStLotID              As String = "在庫ID"
    Private Const CMstrvsfStockLColPrLotID              As String = "製造ロットID"
    Private Const CMstrvsfStockLColCFLotID              As String = "出荷ロットID"
    Private Const CMstrvsfStockLColBoardThickness       As String = "板厚"
    Private Const CMstrvsfStockLColStatus               As String = "状態"
    Private Const CMstrvsfStockLColNumGet               As String = "受入数量"
    Private Const CMstrvsfStockLColNumPut               As String = "払出数量"
    Private Const CMstrvsfStockLColLotID                As String = "ロットID"
    Private Const CMstrvsfStockLColReworkCount          As String = "ﾘﾜｰｸ"
    Private Const CMstrvsfStockLColReworkLotID          As String = "受入元ロットID"
    Private Const CMstrvsfStockLColReasonCode           As String = "理由コード"
    Private Const CMstrvsfStockLColEmpID                As String = "担当"
    Private Const CMstrvsfStockLColWorkMemoFlag         As String = "作業メモ"
    Private Const CMstrvsfStockLColWorkMemo             As String = "作業メモ内容"

    '@vsfの定数宣言
    Private Const CMlngvsfStockLRowTitle                As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngvsfStockLColTitle                As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngvsfmlngSortCol                   As Integer = 0                      'ｿｰﾄ列初期値
    Private Const CMlngvsfmlngOrderCol                  As Integer = 0                      'ｿｰﾄ方法初期値
    Private Const CMlngvsfStockRowFrezon                As Integer = 1                      '固定列(=1)
    Private Const CMlngvsfStockLHFontSize               As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfRowTop                        As Integer = 0                      '選択最上段行
    Private Const CMlngvsfStockLHHeight                 As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfStockLHeight                  As Integer = 18                     '1ｽﾛｯﾄの高さ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName                   As Integer = 1                      '名称列番
    Private Const CMlngCmbGridColID                     As Integer = 0                      'ID列番(非表示項目)
    Private Const CMlngCmbDispCols                      As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbDispCols2                     As Integer = 2                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                     As Integer = 18                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbHeight                        As Integer = 28                     '高さ
    Private Const CMlngCmbValueCol                      As Integer = 0                      '値取得列
    Private Const CMlngCmbGetCol                        As Integer = 2                      '値表示列
    Private Const CMlngCmbClearListIndex                As Integer = -1                     'ﾃｷｽﾄ値初期化

    '@部品種別Combo
    Private Const CMlngGetIDValueCol                    As Integer = 1                      'ID取得Col数

    '@部品Combo
    Private Const CMlngGetPartIDValueCol                As Integer = 0                      '部品ID取得Col数

    Private Const CMlngDisplayMaxCnt                    As Integer = 500                    '表示最大件数
    Private Const CMlngDisp0                            As Integer = 0                      '0 表示
    Private Const CMstrBrank                            As String = " "                     '空白
    Private Const CMstrStartSecond                      As String = ":00"                   '開始：秒
    Private Const CMstrEndSecond                        As String = ":59"                   '終了：秒
    Private Const CMstrMaxString                        As String = "最大"                  '表示件数表記
    Private Const CMstrDateSelectOn                     As String = "検　索"                '検索(最新取得ﾎﾞﾀﾝ名)
    Private Const CMstrDateSelectOff                    As String = "最新取得"              '最新取得(最新取得ﾎﾞﾀﾝ名)
    Private Const CMstrTotalTitle                       As String = "【数量合計】"          '数量合計ﾀｲﾄﾙ

    '@ﾁｪｯｸﾎﾞｯｸｽの定数宣言
    Private Const CMlngchkValueTrue                     As Integer = 0                      'ﾁｪｯｸ未
    Private Const CMlngchkValueFalse                    As Integer = 1                      'ﾁｪｯｸ状態

    '@ﾛｯﾄｲﾍﾞﾝﾄIDの定数宣言
    Private Const CMstrLotEventID17                     As String = "17"                    '受入
    Private Const CMstrLotEventID18                     As String = "18"                    '払出
    '@↓2011/12/27 (Tue) 16:23:31 T.Oide **************************************************
    Private Const CMstrLotEventID97                     As String = "97"                    '不良
    '@↑2011/12/27 (Tue) 16:23:31 T.Oide **************************************************

    Private Const CMlngBackColorSel                     As Integer = &H8000000D             '選択ｾﾙの色
    Private Const CMlngBackColorSBlue                   As Integer = &HFFFFC0               '水色

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Public==========================================
    '========================================Private=========================================
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用
    Private mtypInvHistoryList                          As InvHistory                       '部材履歴応答構造体
    Private mtypVenderlist                              As VenderList                       'ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄ
    Private mstrPartClass                               As String                           '部品種別退避領域
    Private mstrPart                                    As String                           '部品退避領域
    Private mstrEventName                               As String                           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
    Private mlngSortCol                                 As Integer                          'ｿｰﾄ列格納
    Private mlngSortOrder                               As Integer                          'ｿｰﾄ方法格納
    Private mblnCmdFlag                                 As Boolean                          'ﾎﾞﾀﾝ制御ﾌﾗｸﾞ
    Private mblncmbPartFlag                             As Boolean                          '部品変更ﾌﾗｸﾞ
    Private mblnFormActivateFlag                        As Boolean                          'ﾌｫｰﾑのｱｸﾃｨﾍﾞｨﾄﾌﾗｸﾞ

    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ
    Private mblnInValidatingCmbPartClass                As Boolean                          'NSYS 部品種別コンボValidate中
    Private mblnInValidatingCmbPart                     As Boolean                          'NSYS 部品コンボValidate中
    Private mblnNotInValidating                         As Boolean                          'NSYS 非Validate中

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
        medFromTime.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
        medToTime.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
        Form_Load()

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：Form_Load
    '機　能：ACT初期設定および初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 13:09:32 S.Deguchi
    '更新日：2004/11/02 (Tue) 13:09:32
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01I0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@部品種別ｺﾝﾎﾞの初期化
            cmbPartClass.Clear
            
            '@ﾌｫｰﾑのﾓｼﾞｭｰﾙ変数を初期化
            mblnFormActivateFlag = False
            mstrPartClass = vbNullString
            mstrPart = vbNullString
            
            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call prvfrmxxEN01I0_Init()
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            mstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, mstrEventName)
            
           
            '@部品種別情報の取得【CPstrCD02：全て】
            lblnAns = pubblnVendClassList_Sel(CMstrmas_vendclasslistVer, _
                                              CPstrCD02, _
                                              mtypVenderlist)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
            End If

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
    '機　能：ﾌｫｰﾑのｱｸﾃｨﾍﾞｨﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/05 (Fri) 09:09:55 S.Deguchi
    '更新日：2004/11/05 (Fri) 09:09:55
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@起動時処理(部品種別が1件の場合)
            If mblnFormActivateFlag = False Then
                '@部品種別情報表示
                Call prvCmbClassName_Disp(mtypVenderlist)
                
                '@部品種別情報の件数ﾁｪｯｸ(件数によって処理を分岐)
                With cmbPartClass
                    If mtypVenderlist.lngVenderClassListCnt = 1 Then
                        '@取得件数が1件
                        .ListIndex = mtypVenderlist.lngVenderClassListCnt - 1       '取得した1件を表示
                        
                        mblnNotInValidating = True
                        Call cmbPartClass_Validate(cmbPartClass, New CancelEventArgs(False))    '部品種別のValidateｲﾍﾞﾝﾄを呼び出す
                        mblnNotInValidating = False
                    Else
                        '@部品Comboへｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmbPartClass)
                    End If
                End With
                
                '@ﾌﾗｸﾞ変更
                mblnFormActivateFlag = True
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
                'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
                Dim lfuncActivate As Action = Sub()
                                                  Me.Activate()
                                              End Sub
                Me.BeginInvoke(lfuncActivate)
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
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 13:11:24 S.Deguchi
    '更新日：2004/11/02 (Tue) 13:11:24
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

            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理判別
            Select Case ActiveControl.Name
                '@部品種別の場合
                Case cmbPartClass.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@部品種別Validate処理へ
                            mblnNotInValidating = True
                            Call cmbPartClass_Validate(cmbPartClass, New CancelEventArgs(True))
                            mblnNotInValidating = False
                            e.Handled = True
                        Case Else
                    End Select

                '@部品の場合
                Case cmbPart.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@部品Validate処理へ
                            mblnNotInValidating = True
                            Call cmbPart_Validate(cmbPart, New CancelEventArgs(True))
                            mblnNotInValidating = False
                            e.Handled = True
                        Case Else
                    End Select

                '@部品/部品種別以外の場合
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
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 13:10:51 S.Deguchi
    '更新日：2004/11/02 (Tue) 13:10:51
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ﾌﾟﾗｲﾍﾞｰﾄ変数のｸﾘｱ
            mtypInvHistoryList.typInvHistoryList = Nothing
            mtypVenderlist.typVenderClassList = Nothing
            mtypChgSort.typChgSortList = Nothing
            
            '@ﾊﾟﾌﾞﾘｯｸ変数のｸﾘｱ・初期化
            pstrWorkMemo = vbNullString
            
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
    '作成日：2004/11/02 (Tue) 12:56:14 S.Deguchi
    '更新日：2004/11/02 (Tue) 12:56:14
    '備　考：なし
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim ltypCommonInfo  As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@終了関数を実行する
            Call publngEnd_Proc(CPstrKeyEN01I0, ltypCommonInfo)
            
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

    '関数名：cmdWorkMemo_Click
    '機　能：作業ﾒﾓ内容表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/04 (Thu) 09:56:11 S.Deguchi
    '更新日：2012/01/24 (Tue) 13:26:27 T.Oide
    '備　考：
    Private Sub cmdWorkMemo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkMemo.Click

        Dim lstrKeyID   As String   'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow  As Integer  '現在行を格納

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@初期化
            pstrWorkMemo = vbNullString
            
            With vsfStockList
                '@引継ぎ情報格納
                '@作業ﾒﾓﾌﾗｸﾞが"あり"の場合には,ﾎﾞﾀﾝを活性する
                If .GetData(.Row, CMlngvsfStockLColWorkMemoFlag) = CPstrAriFlg Then
                    '@作業ﾒﾓ内容をﾊﾟﾌﾞﾘｯｸ変数へ格納
                    pstrWorkMemo = .GetData(.Row, CMlngvsfStockLColWorkMemo)
                End If
            
                '@ﾌｫｰｶｽ戻り位置を取得
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfStockLColNo)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            
                '@作業ﾒﾓ表示画面起動
                frmxxCM00Q0.Instance.ShowDialog(Me)
                frmxxCM00Q0.Instance = Nothing
            
                '@ﾌｫｰｶｽ戻り位置を設定
        '@↓2012/01/24 (Tue) 12:01:28 T.Oide **************************************************
        '        Call prvFocus_Set(vsfStockList, lstrKeyID, CMlngvsfStockLColNo, llngTopRow)
                Call pubGridFocus_Set(vsfStockList, lstrKeyID, CMlngvsfStockLColNo, cmdClose)
        '@↑2012/01/24 (Tue) 12:01:28 T.Oide **************************************************
            
                '@先頭列へ
                .Select(llngTopRow, CMlngvsfStockLColNo)
                
                '@ｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(vsfStockList)
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkMemo_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCopy_Click
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
    '引　数：なし
    '戻り値：
    '作成日：2004/11/04 (Thu) 09:56:13 S.Deguchi
    '更新日：2004/11/04 (Thu) 09:56:13
    '備　考：
    Private Sub cmdCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopy.Click

        Dim llngRowCnt     As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngColCnt     As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrRET        As String       'ｺﾋﾟｰ文字列
        Dim lstrWk         As String       '文字列編集

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@Clipboardの内容を削除
            Clipboard.Clear
            
            With vsfStockList
                '@一覧をｺﾋﾟｰする
                For llngRowCnt = 0 To .Rows.Count - 1
                    For llngColCnt = 0 To .Cols.Count - 1
                        '@列が非表示でない場合
                        If .Cols(llngColCnt).Visible Then
                            
                            '@文字列編集変数に値をｾｯﾄ
                            lstrWk = .GetDataDisplay(llngRowCnt, llngColCnt)
                                
                            '@先頭の文字列が「-」「+」の場合は罫線文字に置き換える
                            If Mid$(lstrWk, 1, 1) = CPstrMinus Then
                                Mid$(lstrWk, 1, 1) = CPstrMinusWide
                            End If
                            If Mid$(lstrWk, 1, 1) = CPstrPlus Then
                                Mid$(lstrWk, 1, 1) = CPstrPlusWide
                            End If
                                
                            '@最終列の場合Tabいらない
                            If llngColCnt = CMlngvsfStockLColWorkMemoFlag Then
                                '@ｺﾋﾟｰ文字列作成
                                lstrRET = lstrRET & lstrWk
                            Else
                                '@ｺﾋﾟｰ文字列作成
                                lstrRET = lstrRET & lstrWk & vbTab
                            End If
                        End If
                    Next llngColCnt
                        
                    '@ｺﾋﾟｰ文字列作成
                    lstrRET = lstrRET & vbCrLf
                        
                Next llngRowCnt
            End With
            
            '@Clipboard にﾃｷｽﾄ文字列を挿入
            Clipboard.SetText(lstrRET)
            
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0041)
            
            '@publngMsgBoxInfo("メッセージコード：C_I41%0$$クリップボードにコピーしました。
            '@(Excel等に Ctrl＋Vキー で貼り付けてください)")
            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCopy_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowList_Click
    '機　能：最新取得(検索)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/04 (Thu) 09:56:16 S.Deguchi
    '更新日：2004/11/04 (Thu) 09:56:16
    '備　考：
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypHistoryRequest      As HistoryRequest       '要求構造体

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

            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Sub
            End If

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            mstrEventName = "cmdNowList_Click"
            
            '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞが実行不可の場合
            If mblnCmdFlag = False Then
                Exit Sub
            End If
               
            '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(実行不可)
            mblnCmdFlag = False
            
            '@検索ﾁｪｯｸ
            If prvblnSearch_Chk() = False Then
                Exit Sub
            End If
            
            '@初期化
            mtypInvHistoryList.typInvHistoryList = New List(Of AnswerHistory)
            mtypInvHistoryList.lngInvHistoryListCnt = 0
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@要求構造体へ情報をｾｯﾄ
            With ltypHistoryRequest
                '@ｼｽﾃﾑﾌﾞﾛｯｸ格納
                .strSbID = pstrSBID
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ格納
                .strMsgVer = CMstrinv_history_Ver
                '@ﾍﾞﾝﾀﾞｰｸﾗｽID格納
                cmbPartClass.ValueCol = CMlngGetIDValueCol
                .strVenderClassId = cmbPartClass.Value
                '@部品ｺｰﾄﾞ格納
                cmbPart.ValueCol = CMlngGetPartIDValueCol
                .strPartCode = cmbPart.Value
                
                '@処理区分・期間・各ﾛｯﾄID格納
                If chkDateSelectKbn.Checked = False Then
                    .strClassDivision = CPstrCD07           '最新取得(07)
                    .strStartDate = vbNullString
                    .strEndDate = vbNullString
                    .strProductionLotId = vbNullString
                Else
                    .strClassDivision = CPstrCD3G           '期間指定(3G)
                    .strStartDate = calFromDate.Value & CMstrBrank & medFromTime.Text & CMstrStartSecond    '検索開始日時
                    .strEndDate = calToDate.Value & CMstrBrank & medToTime.Text & CMstrEndSecond            '検索終了日時
                    .strProductionLotId = txtProLotID.Text                                                  '製造ﾛｯﾄID
                End If
            End With
            
            '@MSG[部材履歴一覧]の実行
            lblnAns = pubblnInvHistory_Sel(ltypHistoryRequest, mtypInvHistoryList)
            '@結果判定
            If lblnAns = False Then
            '@部材一覧取得に失敗
                '@部材一覧表示情報初期化
                Call prvvsfStockList_Init()

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                
                '@失敗時には部品へﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmbPart)
                
                '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(実行可)
                mblnCmdFlag = True
                
                '@最新情報取得日時の時間設定
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                
                '@表示件数の初期化
                lblLotCnt.Text = CPstrZero
                
                '@現在数量の初期化
                lblNowTotal.Text = CPstrZero
                
                Exit Sub
            End If
                        
            '@部材一覧表示情報
            Call prvvsfStockList_Disp(mtypInvHistoryList)
                    
            '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(実行可)
            mblnCmdFlag = True
                    
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, mstrEventName)
            
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

    '関数名：cmbPartClass_Change
    '機　能：部品種別変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/04 (Thu) 09:43:35 S.Deguchi
    '更新日：2004/11/04 (Thu) 09:43:35
    '備　考：
    Private Sub cmbPartClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPartClass.Change

        Try
            '@ｿｰﾄ列初期化
            mlngSortCol = CMlngvsfmlngSortCol
            
            '@ｿｰﾄ方法初期化
            mlngSortOrder = CMlngvsfmlngOrderCol
            
            '@退避領域と比較して同じ場合には処理抜け
            If mstrPartClass <> cmbPartClass.Text Then
                '@起動時の初期化時には処理を飛ばす
                If mblnFormActivateFlag = True Then
                    '@部材一覧初期化処理
                    Call prvvsfStockList_Init()
                    
                    '@ｺﾝﾄﾛｰﾙ制御
                    cmdNowList.Enabled = True                           '最新取得ﾎﾞﾀﾝ有効
                    cmdCopy.Enabled = False                             'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ無効
                    cmdWorkMemo.Enabled = False                         '作業ﾒﾓ表示ﾎﾞﾀﾝ無効
                    
                    '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
                    txtProLotID.Text = vbNullString
                    
                    '@ｶﾚﾝﾄ行検索ｷｰを初期化
                    mtypChgSort.strKey = vbNullString
                End If
            End If
                        
            '@ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString
            lblNowTotal.Text = vbNullString
            lblLotCnt.Text = vbNullString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPartClass_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPartClass_CloseUp
    '機　能：部品種別のCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/04 (Thu) 09:43:35 S.Deguchi
    '更新日：2004/11/04 (Thu) 09:43:35
    '備　考：
    Private Sub cmbPartClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPartClass.CloseUp

        Try
            
            '@部品種別が空欄でない場合
            If cmbPartClass.Text <> vbNullString Then
                '@部品種別_Validate処理
                mblnNotInValidating = True
                Call cmbPartClass_Validate(cmbPartClass, New CancelEventArgs(True))
                mblnNotInValidating = False
            End If
          
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPartClass_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPartClass_Validate
    '機　能：部品種別_Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/04 (Thu) 09:43:35 S.Deguchi
    '更新日：2004/11/04 (Thu) 09:43:35
    '備　考：
    Private Sub cmbPartClass_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPartClass.Validating
        
        Dim llngpartcnt         As Integer                      '部品数
        Dim lblnClassAns        As Boolean                      '部品情報取得処理結果
        Dim ltypMasPartlist     As MasPartlist                  '部材ｺｰﾄﾞﾘｽﾄ要求構造体
        Dim ltypPartList        As List(Of PartClassList)       '部品ﾘｽﾄ構造体

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            mstrEventName = "cmbPartClass_Validate"
            
            'NSYS Validate中
            mblnInValidatingCmbPartClass = True
            
            '@選択されていない場合
            If cmbPartClass.Text = vbNullString Then
                '@閉じるﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                Call prvSetFocus(cmdClose)
                Exit Sub
            Else
                '@部品ｺﾝﾎﾞﾎﾞｯｸｽ使用可能
                cmbPart.Enabled = True
            End If
                
            '@退避領域と比較して同じ場合には処理抜け
            If mstrPartClass = cmbPartClass.Text Then
                '@次項目へｾｯﾄﾌｫｰｶｽ
                If cmbPart.Enabled = True Then
                    Call prvSetFocus(cmbPart)
                Else
                    Call prvSetFocus(cmdClose)
                End If
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@部材ｺｰﾄﾞﾘｽﾄ要求構造体へ格納
            With ltypMasPartlist
                .strSbID = pstrSBID                     '処理区分
                .strMsgVer = CMstrmas_partlistVer       'ﾒｯｾｰｼﾞVersion
                .strPdId = vbNullString                 '機種ID(取得できない為)
                .strMasPdVersion = vbNullString         'PDVersion(取得できない為)
                
                '@ﾍﾞﾝﾀﾞｰｸﾗｽ取得
                cmbPartClass.ValueCol = CMlngGetIDValueCol
                .strVenderClassId = cmbPartClass.Value  '部品ID(部材ID)
            End With
                                
            '@部材ｺｰﾄﾞ、ﾍﾞﾝﾀﾞｰ取得
            lblnClassAns = pubblnMasPartList_Sel(ltypMasPartlist, _
                                                 llngpartcnt, _
                                                 ltypPartList)
            '@結果判定
            If lblnClassAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                            
                '@部品ｺﾝﾎﾞﾎﾞｯｸｽ使用不可
                cmbPart.Enabled = False
                            
                '@最新取得ﾎﾞﾀﾝを非活性化
                cmdNowList.Enabled = False
                
                '@ﾓｼﾞｭｰﾙ変数へ退避
                mstrPartClass = vbNullString
                mstrPart = vbNullString
                
                '@ﾌｫｰｶｽそのまま
                e.Cancel = True
                
                Exit Sub
            Else
                '@取得した部品が0件の場合にはComboを使用不可にする
                If llngpartcnt = 0 Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                
                    '@部品ｺﾝﾎﾞﾎﾞｯｸｽ使用不可
                    cmbPart.Enabled = False
                    
                    '@最新取得ﾎﾞﾀﾝを非活性化
                    cmdNowList.Enabled = False
                    
                    '@ﾓｼﾞｭｰﾙ変数へ退避
                    mstrPartClass = vbNullString
                    mstrPart = vbNullString
                        
                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                    
                    Exit Sub
                Else
                    '@部品情報表示
                    Call prvCmbPartName_Disp(ltypPartList, llngpartcnt)
                    
                    '@ﾓｼﾞｭｰﾙ変数へ退避
                    mstrPartClass = cmbPartClass.Text
                    mstrPart = vbNullString

                    '@最新取得ﾎﾞﾀﾝを非活性化
                    cmdNowList.Enabled = False

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
            
                    '@部品情報の件数ﾁｪｯｸ(件数によって処理を分岐)
                    If llngpartcnt = 1 Then
                        '@取得件数が1件
                        cmbPart.ListIndex = llngpartcnt - 1              '取得した1件を表示
                        
                        Call cmbPart_Validate(cmbPart, New CancelEventArgs(False))  '部品のValidateｲﾍﾞﾝﾄを呼び出す
                    Else
                        If cmbPart.Enabled = True Then
                            '@部品Comboへｾｯﾄﾌｫｰｶｽ
                            Call prvSetFocus(cmbPart)
                        End If
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPartClass_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        Finally
            'NSYS 戻す
            mblnInValidatingCmbPartClass = False

        End Try
    End Sub

    '関数名：cmbPart_Change
    '機　能：部品変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/04 (Thu) 09:48:31 S.Deguchi
    '更新日：2004/11/04 (Thu) 09:48:31
    '備　考：
    Private Sub cmbPart_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPart.Change

        Try
            '@ｿｰﾄ列初期化
            mlngSortCol = CMlngvsfmlngSortCol
            
            '@ｿｰﾄ方法初期化
            mlngSortOrder = CMlngvsfmlngOrderCol
            
            If mstrPart <> cmbPart.Text Then
                '@部材一覧初期化処理
                Call prvvsfStockList_Init()
                
                '@ｺﾝﾄﾛｰﾙ制御
                cmdNowList.Enabled = True                           '最新取得ﾎﾞﾀﾝ有効
                cmdCopy.Enabled = False                             'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ無効
                cmdWorkMemo.Enabled = False                         '作業ﾒﾓ表示ﾎﾞﾀﾝ無効
                
                '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
                txtProLotID.Text = vbNullString
                        
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                mtypChgSort.strKey = vbNullString
            End If

            '@ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString
            lblNowTotal.Text = vbNullString
            lblLotCnt.Text = vbNullString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPart_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPart_CloseUp
    '機　能：部品Validate処理呼び出し
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/04 (Thu) 09:48:31 S.Deguchi
    '更新日：2004/11/04 (Thu) 09:48:31
    '備　考：
    Private Sub cmbPart_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPart.CloseUp

        Try

            '@空白以外の場合
            If cmbPart.Text <> vbNullString Then
                '@部品Validate処理呼び出し
                mblnNotInValidating = True
                Call cmbPart_Validate(cmbPart, New CancelEventArgs(True))
                mblnNotInValidating = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPart_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPart_Validate
    '機　能：部品Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/04 (Thu) 09:48:31 S.Deguchi
    '更新日：2004/11/04 (Thu) 09:48:31
    '備　考：
    Private Sub cmbPart_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPart.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            'NSYS Validate中
            mblnInValidatingCmbPart = True
            
            '@部品ｺﾝﾎﾞﾎﾞｯｸｽが選択されていない場合には処理抜け
            If cmbPart.Text = vbNullString Then
                '@次項目が非活性化の場合
                If vsfStockList.Enabled = True Then
                    Call prvSetFocus(vsfStockList)
                Else
                    Call prvSetFocus(cmdClose)
                End If
                
                Exit Sub
            Else
                '@退避領域と比較
                If mstrPart = cmbPart.Text Then
                    '@次項目へﾌｫｰｶｽｾｯﾄ
                    If vsfStockList.Enabled = True Then
                        '@一覧へｾｯﾄ
                        Call prvSetFocus(vsfStockList)
                    Else
                        If chkDateSelectKbn.Enabled = True Then
                            '@"指定する"ﾁｪｯｸﾎﾞｯｸｽへｾｯﾄ
                            Call prvSetFocus(chkDateSelectKbn)
                        Else
                            '@"閉じる"へｾｯﾄ
                            Call prvSetFocus(cmdClose)
                        End If
                    End If
                    
                    Exit Sub
                Else
                    '@"指定する"ﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸが入っている場合
                    If chkDateSelectKbn.Checked = True Then
                        '@次項目へｾｯﾄﾌｫｰｶｽ
                        Call prvSetFocus(txtProLotID)
                    Else
                        '@ﾎﾞﾀﾝ押下処理の実行
                        Call cmdNowList_Click(cmdNowList, e)           '最新取得ﾎﾞﾀﾝ
                        
                        '@取得件数のﾁｪｯｸ
                        If mtypInvHistoryList.lngInvHistoryListCnt > 0 Then
                            If vsfStockList.Enabled = True Then
                                '@取得件数が0件以上の場合はﾌｫｰｶｽを移動
                                Call prvSetFocus(vsfStockList)
                            Else
                                '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽ移動
                                If cmdNowList.Enabled = True Then
                                    Call prvSetFocus(cmdNowList)
                                Else
                                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽ移動
                                    Call prvSetFocus(cmdClose)
                                End If
                            End If
                        Else
                            '@ﾌｫｰｶｽそのまま
                            e.Cancel = True
                        End If
                    
                        '@退避領域に値をｾｯﾄ
                        mstrPart = cmbPart.Text
                    
                        '@期間ｺﾝﾄﾛｰﾙを活性化
                        chkDateSelectKbn.Enabled = True
                    End If
                    
                    '@部材変更ﾌﾗｸﾞ初期化
                    mblncmbPartFlag = False
                                    
                    '@最新取得ﾎﾞﾀﾝ使用可能
                    cmdNowList.Enabled = True
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPart_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        Finally
            'NSYS 戻す
            mblnInValidatingCmbPart = False

        End Try
    End Sub

    '関数名：chkDateSelectKbn_Click
    '機　能：期間指定区分の変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 16:16:40 S.Deguchi
    '更新日：2004/11/02 (Tue) 16:16:40
    '備　考：2004/11/08 (Mon) 15:28:33 S.Deguchi 製造ﾛｯﾄID入力欄を追加
    Private Sub chkDateSelectKbn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkDateSelectKbn.CheckedChanged

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@期間指定するかしないかにより、期間を有効制御する
            If chkDateSelectKbn.Checked = True Then
                '@最新取得ﾎﾞﾀﾝ名の変更
                cmdNowList.Text = CMstrDateSelectOn                         '検索(最新取得ﾎﾞﾀﾝ名)
                
                '@製造ﾛｯﾄID欄を初期設定する
                If vsfStockList.Row > 1 Then
                    txtProLotID.Text = vsfStockList.GetData(vsfStockList.Row, CMlngvsfStockLColPrLotID)
                Else
                    txtProLotID.Text = vbNullString
                End If
                
                '@製造ﾛｯﾄID欄を有効にする
                txtProLotID.Enabled = True
                
                '@期間を有効にする
                calFromDate.Enabled = True                                  '開始日
                calToDate.Enabled = True                                    '終了日
                medFromTime.Enabled = True                                  '開始時刻
                medToTime.Enabled = True                                    '終了時刻
                
                '@期間を初期値設定する
                calFromDate.Value = Format$(Now, CPstrDateTimeYMD)          '当日に設定
                calToDate.Value = Format$(Now, CPstrDateTimeYMD)            '当日に設定
                medFromTime.Text = CPstrTimeFormat0H0M                      '0時固定
                medToTime.Text = Format$(Now, CPstrTimeFormatHM)            '現在時刻を初期値設定
            
                '@部品履歴情報の初期化
                Call prvvsfStockList_Init()
                
                '@ﾌｫｰｶｽ移動する
                SendKeys.SendWait(CPstrSendKeysTab)

                
            Else
                '@最新取得ﾎﾞﾀﾝ名の変更
                cmdNowList.Text = CMstrDateSelectOff                        '最新取得(最新取得ﾎﾞﾀﾝ名)
            
                '@製造ﾛｯﾄID欄を初期設定する
                txtProLotID.Text = vbNullString
            
                '@製造ﾛｯﾄID欄を無効にする
                txtProLotID.Enabled = False
                
                '@期間をｸﾘｱする
                calFromDate.Value = vbNullString                            '開始日
                calToDate.Value = vbNullString                              '終了日
                medFromTime.Text = CPstrNullTime                            '開始時刻
                medToTime.Text = CPstrNullTime                              '終了時刻
                
                '@期間を無効にする
                calFromDate.Enabled = False                                 '開始日
                calToDate.Enabled = False                                   '終了日
                medFromTime.Enabled = False                                 '開始時刻
                medToTime.Enabled = False                                   '終了時刻
                
                '@最新情報を取得する
                Call cmdNowList_Click(cmdNowList, e)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "chkDateSelectKbn_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFromDate_Change
    '機　能：検索開始日の変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 16:16:40 S.Deguchi
    '更新日：2004/11/02 (Tue) 16:16:40
    '備　考：
    Private Sub calFromDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calFromDate.Change

        Try
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString

            '@部品履歴情報の初期化
            Call prvvsfStockList_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calFromDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFromDate_CalendarSelect
    '機　能：検索開始日の選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 16:16:40 S.Deguchi
    '更新日：2004/11/02 (Tue) 16:16:40
    '備　考：
    Private Sub calFromDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calFromDate.CalendarSelect

        Try

            With calFromDate
                '@開始日付が選択されている場合
                If .Value <> CPstrNullDate Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calFromDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFromDate_Validate
    '機　能：検索開始日のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 16:16:40 S.Deguchi
    '更新日：2004/11/02 (Tue) 16:16:40
    '備　考：
    Private Sub calFromDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calFromDate.Validating
        
        Dim lstrNowDT As String     '現在日時の退避

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            If calFromDate.Value = CPstrNullDate Then
                Exit Sub
            End If
            
            '@日付の有効性ﾁｪｯｸ
            If pubblnYearRange_Chk(calFromDate.Value) = True Then
                '@現在日付取得
                lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                '@未来日付の場合
                If Format$(CDate(calFromDate.Value), CPstrDateTimeYMD) > lstrNowDT Then
                    calFromDate.Focus()
                   '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                    '@"未来日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                End If
            Else
                calFromDate.Focus()
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                '@"正しい日付を入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@ﾌｫｰｶｽを移さない
                e.Cancel = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calFromDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calToDate_Change
    '機　能：検索終了日の変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 16:16:40 S.Deguchi
    '更新日：2004/11/02 (Tue) 16:16:40
    '備　考：
    Private Sub calToDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calToDate.Change

        Try
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString

            '@部品履歴情報の初期化
            Call prvvsfStockList_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calToDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calToDate_CalendarSelect
    '機　能：検索終了日の選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 16:16:40 S.Deguchi
    '更新日：2004/11/02 (Tue) 16:16:40
    '備　考：
    Private Sub calToDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calToDate.CalendarSelect

        Try

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            With calToDate
                '@終了日付が選択されている場合
                If .Value <> CPstrNullDate Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calToDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calToDate_Validate
    '機　能：検索終了日のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 16:16:40 S.Deguchi
    '更新日：2004/11/02 (Tue) 16:16:40
    '備　考：
    Private Sub calToDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calToDate.Validating
        
        Dim lstrNowDT As String     '現在日時の退避

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            If calToDate.Value = CPstrNullDate Then
                Exit Sub
            End If
            
            '@日付の有効性ﾁｪｯｸ
            If pubblnYearRange_Chk(calToDate.Value) = True Then
                '@現在日付取得
                lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                '@未来日付の場合
                If Format$(CDate(calToDate.Value), CPstrDateTimeYMD) > lstrNowDT Then
                    calToDate.Focus()
                   '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                    '@"未来日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                End If
            Else
                calToDate.Focus()
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                '@"正しい日付を入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@ﾌｫｰｶｽを移さない
                e.Cancel = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calToDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medFromTime_Change
    '機　能：検索開始時刻の変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 16:16:40 S.Deguchi
    '更新日：2004/11/02 (Tue) 16:16:40
    '備　考：
    Private Sub medFromTime_Change(ByVal sender As Object, ByVal e As EventArgs) Handles medFromTime.TextChanged

        Try
            If pblnFormLoad = False Then
                Exit Sub
            End If

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString

            '@部品履歴情報の初期化
            Call prvvsfStockList_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medFromTime_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medFromTime_GotFocus
    '機　能：検索開始時刻のﾌｫｰｶｽ取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 16:16:40 S.Deguchi
    '更新日：2004/11/02 (Tue) 16:16:40
    '備　考：
    Private Sub medFromTime_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles medFromTime.GotFocus

        Try
            '@ﾊｲﾗｲﾄ処理
            Call pubHighlight(medFromTime)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medFromTime_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medFromTime_Validate
    '機　能：検索開始時刻のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 16:16:40 S.Deguchi
    '更新日：2004/11/02 (Tue) 16:16:40
    '備　考：
    Private Sub medFromTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles medFromTime.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If medFromTime.Text = CPstrNullTime Then
                Exit Sub
            End If
            
            If IsDate(medFromTime.Text) = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003C)
                '@"時刻の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@ｾｯﾄﾌｫｰｶｽ
                e.Cancel = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medFromTime_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medToTime_Change
    '機　能：検索終了時刻の変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 16:16:40 S.Deguchi
    '更新日：2004/11/02 (Tue) 16:16:40
    '備　考：
    Private Sub medToTime_Change(ByVal sender As Object, ByVal e As EventArgs) Handles medToTime.TextChanged

        Try

            If pblnFormLoad = False Then
                Exit Sub
            End If

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString

            '@部品履歴情報の初期化
            Call prvvsfStockList_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medToTime_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medToTime_GotFocus
    '機　能：検索終了時刻のﾌｫｰｶｽ取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 16:16:40 S.Deguchi
    '更新日：2004/11/02 (Tue) 16:16:40
    '備　考：
    Private Sub medToTime_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles medToTime.GotFocus

        Try

            '@ﾊｲﾗｲﾄ処理
            Call pubHighlight(medToTime)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medToTime_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medToTime_Validate
    '機　能：検索終了時刻のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 16:16:40 S.Deguchi
    '更新日：2004/11/02 (Tue) 16:16:40
    '備　考：
    Private Sub medToTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles medToTime.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@日付が空欄の場合には,処理抜け
            If medToTime.Text = CPstrNullTime Then
                Exit Sub
            End If
            
            If IsDate(medToTime.Text) = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003C)
                '@"時刻の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@ｾｯﾄﾌｫｰｶｽ
                e.Cancel = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medToTime_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfStockList_AfterSort
    '機　能：部材履歴一覧AfterSort処理
    '引　数：Col：ｿｰﾄ列
    '　　　：Order：ｿｰﾄ方法
    '戻り値：なし
    '作成日：2004/11/05 (Fri) 11:14:42 S.Deguchi
    '更新日：2004/11/05 (Fri) 11:14:42
    '備　考：
    Private Sub vsfStockList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfStockList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfStockList.Rows.Count <= vsfStockList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄされた列を格納
            mlngSortCol = e.Col
            '@ｿｰﾄ方法を格納
            mlngSortOrder = e.Order
            
            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1

                Dim ltypChgSortList As ChgSortList
                '@ｿｰﾄ列番号を格納
                ltypChgSortList.lngCol = e.Col
                '@並び替え方法を格納(昇順/降順)
                ltypChgSortList.lngOrder = e.Order
                .typChgSortList.Add(ltypChgSortList)
            End With

            'NSYS 横スクロールをキャンセル
            Dim ltypScrollPos As Point = vsfStockList.ScrollPosition
            vsfStockList.Redraw = False

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfAfterSort(vsfStockList, CMlngvsfStockLRowTitle)

            'NSYS 選択行が見つからない場合、共通関数は.Rowを0にしてくるので、1にする
            If vsfStockList.Row = 0 Then
                vsfStockList.Row = 1
                'NSYS 横方向を復元
                ltypScrollPos.Y = vsfStockList.ScrollPosition.Y
                vsfStockList.ScrollPosition = ltypScrollPos
            End If
            vsfStockList.Redraw = True

            'NSYS ソート時はBeforeRowColChange/RowColChangeを抑制を解除する
            RemoveHandler vsfStockList.BeforeRowColChange, AddressOf vsfStockList_BeforeRowColChange
            RemoveHandler vsfStockList.RowColChange, AddressOf vsfStockList_RowColChange
            AddHandler vsfStockList.BeforeRowColChange, AddressOf vsfStockList_BeforeRowColChange
            AddHandler vsfStockList.RowColChange, AddressOf vsfStockList_RowColChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfStockList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfStockList_AfterUserResize
    '機　能：ｸﾞﾘｯﾄﾞｻｲｽﾞ変更
    '引　数：Row：変更行
    '　　　：Col：変更列
    '戻り値：なし
    '作成日：2004/11/05 (Fri) 16:37:29 S.Deguchi
    '更新日：2004/11/05 (Fri) 16:37:29
    '備　考：
    Private Sub vsfStockList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfStockList.AfterResizeColumn, vsfStockList.AfterResizeRow

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfStockList.Rows.Count <= vsfStockList.Rows.Fixed Then
                Return
            End If

             '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfStockList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfStockList_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/05 (Fri) 11:17:03 S.Deguchi
    '更新日：2004/11/05 (Fri) 11:17:03
    '備　考：
    Private Sub vsfStockList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfStockList.BeforeRowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfStockList.Rows.Count <= vsfStockList.Rows.Fixed Then
                Return
            End If

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            '@NewRowは先頭行が合計行の為、1以上とする。
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 1 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(№)
                mtypChgSort.strKey = vsfStockList.GetData(e.NewRange.r1, CMlngvsfStockLColNo)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfStockList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfStockList_BeforeSort
    '機　能：部材履歴一覧BeforeSort処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/11/05 (Fri) 11:15:39 S.Deguchi
    '更新日：2004/11/05 (Fri) 11:15:39
    '備　考：
    Private Sub vsfStockList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfStockList.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfStockList.Rows.Count <= vsfStockList.Rows.Fixed Then
                Return
            End If

            'NSYS ソート時はBeforeRowColChange/RowColChangeを抑制する
            RemoveHandler vsfStockList.BeforeRowColChange, AddressOf vsfStockList_BeforeRowColChange
            RemoveHandler vsfStockList.RowColChange, AddressOf vsfStockList_RowColChange

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfStockList, CMlngvsfStockLRowTitle)

            If e.Col = CMlngvsfStockLColNumGet OrElse e.Col = CMlngvsfStockLColNumPut Then
                'NSYS 「受入数量」「払出数量」は数字の0の前に空白""が来るようにするComparerでソートする
                vsfStockList.Sort(New VsfStockLColNumComparer(e.Order, e.Col))
                'NSYS 標準のSort処理がキャンセルされAfterSortイベントが呼ばれないため、直接呼び出す
                vsfStockList_AfterSort(sender, e)
                e.Handled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfStockList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfStockList_RowColChange
    '機　能：一覧の行選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/04 (Thu) 14:50:49 S.Deguchi
    '更新日：2004/11/04 (Thu) 14:50:49
    '備　考：
    Private Sub vsfStockList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfStockList.RowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfStockList.Rows.Count <= vsfStockList.Rows.Fixed OrElse _
                vsfStockList.Row < 0 Then
                Return
            End If

            With vsfStockList
            
        '        If .Row < 2 Then
        '            Exit Sub
        '        End If
                '@作業ﾒﾓﾌﾗｸﾞが"あり"の場合には,ﾎﾞﾀﾝを活性する
                If .GetData(.Row, CMlngvsfStockLColWorkMemoFlag) = CPstrAriFlg Then
                    'ﾎﾞﾀﾝ使用可
                    cmdWorkMemo.Enabled = True
                Else
                    'ﾎﾞﾀﾝ使用不可
                    cmdWorkMemo.Enabled = False
                End If
                
                If .Row < 2 Then
                    Exit Sub
                End If
                '@選択行の製造ﾛｯﾄIDを絞込条件に反映
                If .GetData(.Row, CMlngvsfStockLColPrLotID) <> vbNullString Then
                    txtProLotID.Text = .GetData(.Row, CMlngvsfStockLColPrLotID)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfStockList_RowColChange"
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

    '関数名：prvfrmxxEN01I0_Init
    '機　能：ﾒｲﾝﾌｫｰﾑの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 15:06:52 S.Deguchi
    '更新日：2004/11/02 (Tue) 15:06:52
    '備　考：
    Private Sub prvfrmxxEN01I0_Init()

        Dim lctlControl         As Control                      'ｺﾝﾄﾛｰﾙ名称取得用変数
        Dim lstrFormTitle       As String                       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim lcmbComboBoxEx      As SEComboBoxEx.ComboBoxEx      'NSYS ComboBox設定用変数

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01I0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            '@ｶﾚﾝﾀﾞｰ設定
            With calFromDate
                .CalendarHeight = CPlngMClHeight                    '高さ
                .CalendarWidth = CPlngMClWidth                      '幅
                With .Font                                          'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    calFromDate.Font = New Font(.FontFamily, CPlngMClFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .TitleFont                                     'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                    calFromDate.TitleFont = New Font(.FontFamily, CPlngMClTlFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                      'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    calFromDate.GridFont = New Font(.FontFamily, CPlngMClGridFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .Value = Format$(Now, CPstrDateTimeYMD)             '一覧取得開始日時
            End With
            
            With calToDate
                .CalendarHeight = CPlngMClHeight                    '高さ
                .CalendarWidth = CPlngMClWidth                      '幅
                With .Font                                          'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    calToDate.Font = New Font(.FontFamily, CPlngMClFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .TitleFont                                     'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                    calToDate.TitleFont = New Font(.FontFamily, CPlngMClTlFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                      'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    calToDate.GridFont = New Font(.FontFamily, CPlngMClGridFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .Value = Format$(Now, CPstrDateTimeYMD)             '一覧取得終了日時
            End With

            '@ｶﾚﾝﾀﾞｰの無効/ｸﾘｱ
            calFromDate.Value = vbNullString                        '開始日
            calToDate.Value = vbNullString                          '終了日
            calFromDate.Enabled = False                             '開始日
            calToDate.Enabled = False                               '終了日
            
            '@ComboBox設定(外枠設定のみ)
            For Each lctlControl In Me.Controls
                If TypeOf lctlControl Is SEComboBoxEx.ComboBoxEx Then
                    lcmbComboBoxEx = CType(lctlControl, SEComboBoxEx.ComboBoxEx)
                    With lcmbComboBoxEx
                        '@初期化
                        .DirectInput = False                        '直接入力(Flase)
                        With .Font                                  'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                            lcmbComboBoxEx.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        With .GridFont                              'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                            lcmbComboBoxEx.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        .RowHeight = CMlngCmbRowHeight              'ﾘｽﾄ行の高さ
                    End With
                End If
            Next

            '@部品Combo無効/ｸﾘｱ
            cmbPart.Enabled = False
            cmbPart.Clear
            
            '@期間指定ﾁｪｯｸﾎﾞｯｸｽ
            chkDateSelectKbn.Checked = False                        '指定しない
            chkDateSelectKbn.Enabled = False                        '指定するﾁｪｯｸﾎﾞｯｸｽ
                
            '@期間時間設定の無効/ｸﾘｱ
            medFromTime.Text = CPstrNullTime                        '開始時刻
            medToTime.Text = CPstrNullTime                          '終了時刻
            medFromTime.Enabled = False                             '開始時刻
            medToTime.Enabled = False                               '終了時刻
            
            '@製造ﾛｯﾄID欄の無効/ｸﾘｱ
            txtProLotID.Text = vbNullString
            txtProLotID.Enabled = False
            
            '@ｺﾝﾄﾛｰﾙ制御
            cmdNowList.Text = CMstrDateSelectOff                    '最新取得(最新取得ﾎﾞﾀﾝ名)
            cmdNowList.Enabled = False                              '最新取得ﾎﾞﾀﾝ無効
            
            '@現在数量のｸﾘｱ
            lblNowTotal.Text = vbNullString
            
            '@部材ｺﾝﾎﾞ変更ﾌﾗｸﾞ初期化
            mblncmbPartFlag = False
                
            '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(実行可)
            mblnCmdFlag = True
            
            '@部材一覧の初期化
            Call prvvsfStockList_Init()
                   
            '@構造体初期化(ｿｰﾄ順保持)
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
                   
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01I0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfStockList_Init
    '機　能：部材履歴一覧表示情報初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 15:11:32 S.Deguchi
    '更新日：2004/11/02 (Tue) 15:11:32
    '備　考：
    '　　　：2005/12/20 (Tue) 11:17:25 S.Deguchi    固定列を明示的に設定
    Private Sub prvvsfStockList_Init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfStockList
                 '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                '.Sort = flexSortNone
                .Row = -1
                '@初期行数設定
                .Rows.Count = 1
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                                                '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                   '背景色
                With .Font
                    lFixedStyle.Font = New Font(.FontFamily, CMlngvsfStockLHFontSize, .Style,       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColNo, CMstrvsfStockLColNo)                           'No.
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColDate, CMstrvsfStockLColDate)                       '日時
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColStatus, CMstrvsfStockLColStatus)                   '状態
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColReasonCode, CMstrvsfStockLColReasonCode)           '理由ｺｰﾄﾞ
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColStLotID, CMstrvsfStockLColStLotID)                 '在庫ID
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColPrLotID, CMstrvsfStockLColPrLotID)                 '製造ﾛｯﾄID
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColCFLotID, CMstrvsfStockLColCFLotID)                 'CFﾛｯﾄID
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColLotID, CMstrvsfStockLColLotID)                     'ﾛｯﾄID
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColEmpID, CMstrvsfStockLColEmpID)                     '受入担当
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColNumGet, CMstrvsfStockLColNumGet)                   '受入数量
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColNumPut, CMstrvsfStockLColNumPut)                   '払出数量
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColBoardThickness, CMstrvsfStockLColBoardThickness)   '板厚
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColReworkCount, CMstrvsfStockLColReworkCount)         'ﾘﾜｰｸ回数
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColReworkLotID, CMstrvsfStockLColReworkLotID)         '受入元ﾛｯﾄID
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColWorkMemoFlag, CMstrvsfStockLColWorkMemoFlag)       '作業ﾒﾓ
                .SetData(CMlngvsfStockLRowTitle, CMlngvsfStockLColWorkMemo, CMstrvsfStockLColWorkMemo)               '作業ﾒﾓ内容
                
                '@非表示列設定
                .Cols(CMlngvsfStockLColWorkMemo).Visible = False                                      '作業ﾒﾓ内容
                If pstrSBID = CPstrSBID1A0 Then
                    '@WFの場合
                    .Cols(CMlngvsfStockLColCFLotID).Visible = False                                   'CFﾛｯﾄID
                    .Cols(CMlngvsfStockLColBoardThickness).Visible = False                            '板厚
                    .Cols(CMlngvsfStockLColReworkCount).Visible = False                               'ﾘﾜｰｸ
                    .Cols(CMlngvsfStockLColReworkLotID).Visible = False                               '受入元ﾛｯﾄID
                Else
                    '@対向基板の場合
                    .Cols(CMlngvsfStockLColCFLotID).Visible = True                                    'CFﾛｯﾄID
                    .Cols(CMlngvsfStockLColBoardThickness).Visible = True                             '板厚
                    .Cols(CMlngvsfStockLColReworkCount).Visible = True                                'ﾘﾜｰｸ
                    .Cols(CMlngvsfStockLColReworkLotID).Visible = True                                '受入元ﾛｯﾄID
                End If
                        
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfStockLColNo).Width = CMlngvsfStockLWColNo                           'No.
                    .Cols(CMlngvsfStockLColDate).Width = CMlngvsfStockLWColDate                       '日時
                    .Cols(CMlngvsfStockLColStatus).Width = CMlngvsfStockLWColStatus                   '状態
                    .Cols(CMlngvsfStockLColReasonCode).Width = CMlngvsfStockLWColReasonCode           '理由ｺｰﾄﾞ
                    .Cols(CMlngvsfStockLColStLotID).Width = CMlngvsfStockLWColStLotID                 '在庫ID
                    .Cols(CMlngvsfStockLColPrLotID).Width = CMlngvsfStockLWColPrLotID                 '製造ﾛｯﾄID
                    .Cols(CMlngvsfStockLColCFLotID).Width = CMlngvsfStockLWColCFLotID                 'CFﾛｯﾄID
                    .Cols(CMlngvsfStockLColLotID).Width = CMlngvsfStockLWColLotID                     'ﾛｯﾄID
                    .Cols(CMlngvsfStockLColEmpID).Width = CMlngvsfStockLWColEmpID                     '受入担当
                    .Cols(CMlngvsfStockLColNumGet).Width = CMlngvsfStockLWColNumGet                   '受入数量
                    .Cols(CMlngvsfStockLColNumPut).Width = CMlngvsfStockLWColNumPut                   '払出数量
                    .Cols(CMlngvsfStockLColBoardThickness).Width = CMlngvsfStockLWColBoardThickness   '板厚
                    .Cols(CMlngvsfStockLColReworkCount).Width = CMlngvsfStockLWColReworkCount         'ﾘﾜｰｸ回数
                    .Cols(CMlngvsfStockLColReworkLotID).Width = CMlngvsfStockLWColReworkLotID         '受入元ﾛｯﾄID
                    .Cols(CMlngvsfStockLColWorkMemoFlag).Width = CMlngvsfStockLWColWorkMemoFlag       '作業ﾒﾓ
                    .Cols(CMlngvsfStockLColWorkMemo).Width = CMlngvsfStockLWColWorkMemo               '作業ﾒﾓ内容
                End If
                
                '@表示位置の設定
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                                    'ｾﾙ表示位置：中央中央
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngvsfStockLRowTitle).Height = CMlngvsfStockLHHeight                          '高さ
                
                '@ﾌｫｰｶｽ位置
                .LeftCol = CMlngvsfStockLColNo
                .TopRow = 0
                '@ﾛｯｸ
                .Enabled = False
                .SelectionMode = SelectionModeEnum.Row
                .HighLight = HighLightEnum.Always
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@幅の変更を許可
                .AllowResizing = AllowResizingEnum.Columns
            End With
            
            '@ｺﾝﾄﾛｰﾙ制御(ｸﾞﾘｯﾄﾞに関係するので)
            cmdWorkMemo.Enabled = False                                 '作業ﾒﾓ表示ﾎﾞﾀﾝ無効
            cmdCopy.Enabled = False                                     'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ無効
            
            '@最新情報取得日時の初期化
            lblNowDate.Text = vbNullString
            
            '@表示件数の初期化
            lblLotCnt.Text = vbNullString
            
            '@現在数量の初期化
            lblNowTotal.Text = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfStockList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfStockList_Disp
    '機　能：部材履歴一覧表示
    '引　数：mtypInvHistoryList：部材履歴構造体
    '戻り値：なし
    '作成日：2004/11/04 (Thu) 10:49:26 S.Deguchi
    '更新日：2011/12/27 (Tue) 16:24:34 T.Oide
    '備　考：
    '　　　：2005/01/28 (Fri) 13:19:15 S.Deguchi    取得情報変更による修正
    '　　　：2005/12/20 (Tue) 11:16:34 S.Deguchi    固定列設定変更
    '　　　：2006/10/17 (Tue) 13:14:14 M.Miura      受入元ﾛｯﾄID列を左中央に設定(案件№1590)
    '　　　：2011/12/27 (Tue) 16:24:34 T.Oide       REQ-1115 不良、払出区分け対応
    Private Sub prvvsfStockList_Disp(ByRef mtypInvHistoryList As InvHistory)

        Dim llngDoCnt               As Integer      'ｶｳﾝﾄ
        Dim llngCnt                 As Integer      'ｶｳﾝﾄ
        Dim lobjStyleFormatKanma    As CellStyle    'NSYS セルスタイル Format "#,##0"
        Dim lobjStyleCFKnmaFormat   As CellStyle    'NSYS セルスタイル Format "#,###"
        Dim newStyle                As CellStyle    'NSYS セルスタイル
        Dim cellRange               As CellRange    'NSYS セルレンジ
        Dim ltypScrollPos           As Point        'NSYS スクロール位置

        Try
            
            With vsfStockList
                
                If mtypInvHistoryList.lngInvHistoryListCnt <> 0 Then
                    '@格納ﾃﾞｰﾀがある場合

                    ltypScrollPos = .ScrollPosition
                    
                    '@描画ﾛｯｸ
                    .Redraw = False

                    '@行数設定
                    .Rows.Count = mtypInvHistoryList.lngInvHistoryListCnt + 2
                    
                    'NSYS スタイル準備
                    lobjStyleFormatKanma = .Styles.Add("Normal_Format_CPstrDateFormatKanma", .Styles.Normal)
                    lobjStyleFormatKanma.Format = CPstrDateFormatKanma
                    lobjStyleCFKnmaFormat = .Styles.Add("Normal_Format_CPstrCFKnmaFormat", .Styles.Normal)
                    lobjStyleCFKnmaFormat.Format = CPstrCFKnmaFormat

                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1
                    Dim tmpCnt As Integer = 1
                    '@部材一覧表示情報設定
                    For llngDoCnt = 0 To mtypInvHistoryList.lngInvHistoryListCnt - 1
                        '@№
                        .SetData(tmpCnt + 1, CMlngvsfStockLColNo, llngDoCnt+1)
                        '@日付
                        .SetData(tmpCnt + 1, CMlngvsfStockLColDate, _
                            Format$(CDate(mtypInvHistoryList.typInvHistoryList(llngDoCnt).strRecordTime), CPstrDateTimeYMDHMS))
                        '@状態
                        .SetData(tmpCnt + 1, CMlngvsfStockLColStatus, _
                            mtypInvHistoryList.typInvHistoryList(llngDoCnt).strEventName)
                        '@理由ｺｰﾄﾞ
                        .SetData(tmpCnt + 1, CMlngvsfStockLColReasonCode, _
                            mtypInvHistoryList.typInvHistoryList(llngDoCnt).strReasonName)
                        '@在庫ID
                        .SetData(tmpCnt + 1, CMlngvsfStockLColStLotID, _
                            mtypInvHistoryList.typInvHistoryList(llngDoCnt).strLotID)
                        '@製造ﾛｯﾄID
                        .SetData(tmpCnt + 1, CMlngvsfStockLColPrLotID, _
                            mtypInvHistoryList.typInvHistoryList(llngDoCnt).strProductionLotId)
                        '@CFﾛｯﾄID
                        .SetData(tmpCnt + 1, CMlngvsfStockLColCFLotID, _
                            mtypInvHistoryList.typInvHistoryList(llngDoCnt).strShippingLotID)
                        '@ﾛｯﾄID
                        .SetData(tmpCnt + 1, CMlngvsfStockLColLotID, _
                            mtypInvHistoryList.typInvHistoryList(llngDoCnt).strIssueLotID)
                        '@担当
                        .SetData(tmpCnt + 1, CMlngvsfStockLColEmpID, _
                            mtypInvHistoryList.typInvHistoryList(llngDoCnt).strEmpName)
                        
                        '@受入数量
                        .SetData(tmpCnt + 1, CMlngvsfStockLColNumGet, _
                            CInt(mtypInvHistoryList.typInvHistoryList(llngDoCnt).strAcceptNum))
                                
                        '@払出数量
                        .SetData(tmpCnt + 1, CMlngvsfStockLColNumPut, _
                            CInt(mtypInvHistoryList.typInvHistoryList(llngDoCnt).strScrapNum))
                        
        '@↓2011/12/27 (Tue) 16:22:10 T.Oide **************************************************
        '@                '@ｲﾍﾞﾝﾄにより,"0"表示するか否かを判別する(受入/払出のみ)
        '@                If mtypInvHistoryList.typInvHistoryList(llngDoCnt).strEventClass = CMstrLotEventID17 Or _
        '@                    mtypInvHistoryList.typInvHistoryList(llngDoCnt).strEventClass = CMstrLotEventID18 Then
                            
                        '@ｲﾍﾞﾝﾄにより,"0"表示するか否かを判別する(受入/不良/払出のみ)
                        If mtypInvHistoryList.typInvHistoryList(llngDoCnt).strEventClass = CMstrLotEventID17 Or _
                           mtypInvHistoryList.typInvHistoryList(llngDoCnt).strEventClass = CMstrLotEventID18 Or _
                           mtypInvHistoryList.typInvHistoryList(llngDoCnt).strEventClass = CMstrLotEventID97 Then
        '@↑2011/12/27 (Tue) 16:22:10 T.Oide **************************************************
                            
                            '@受入数量
                            .SetCellStyle(tmpCnt + 1, CMlngvsfStockLColNumGet, lobjStyleFormatKanma)
                                
                            '@払出数量
                            .SetCellStyle(tmpCnt + 1, CMlngvsfStockLColNumPut, lobjStyleFormatKanma)
                        Else
                            '@受入数量
                            .SetCellStyle(tmpCnt + 1, CMlngvsfStockLColNumGet, lobjStyleCFKnmaFormat)
                                
                            '@払出数量
                            .SetCellStyle(tmpCnt + 1, CMlngvsfStockLColNumPut, lobjStyleCFKnmaFormat)
                        End If
                        
                        '@板厚
                        .SetData(tmpCnt + 1, CMlngvsfStockLColBoardThickness, _
                            mtypInvHistoryList.typInvHistoryList(llngDoCnt).strThicknessCode)
                        
                        '@ﾘﾜｰｸ回数
                        'NSYS グリッドの列フォーマットを使用しカンマ区切りフォーマットする
                        .SetData(tmpCnt + 1, CMlngvsfStockLColReworkCount, _
                            mtypInvHistoryList.typInvHistoryList(llngDoCnt).strReworkCount)
                            
                        '@受入元ﾛｯﾄID
                        .SetData(tmpCnt + 1, CMlngvsfStockLColReworkLotID, _
                            mtypInvHistoryList.typInvHistoryList(llngDoCnt).strAcceptLotID)
                            
                        '@作業ﾒﾓﾌﾗｸﾞ/作業ﾒﾓ内容
                        If mtypInvHistoryList.typInvHistoryList(llngDoCnt).strComments <> vbNullString Then
                            .SetData(tmpCnt + 1, CMlngvsfStockLColWorkMemoFlag, CPstrAriFlg)   'あり
                            
                            .SetData(tmpCnt + 1, CMlngvsfStockLColWorkMemo, _
                                mtypInvHistoryList.typInvHistoryList(llngDoCnt).strComments)   '作業ﾒﾓ内容
                        Else
                            .SetData(tmpCnt + 1, CMlngvsfStockLColWorkMemoFlag, vbNullString)  '空欄
                            
                            .SetData(tmpCnt + 1, CMlngvsfStockLColWorkMemo, vbNullString)      '空欄
                        End If
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt + 1).Height = CMlngvsfStockLHeight
                        tmpCnt = tmpCnt + 1
                    Next llngDoCnt
                    
                    '@固定行設定
                    .Rows.Fixed = CMlngvsfStockRowFrezon + 1

                    'NSYS VB6と同じイベント順番を再現する
                    Dim lfuncScrollCancelHandler As RangeEventHandler =
                        Sub(sender As Object, e As RangeEventArgs)
                            e.Cancel = True
                        End Sub

                    AddHandler vsfStockList.BeforeScroll, lfuncScrollCancelHandler
                    RemoveHandler vsfStockList.BeforeRowColChange, AddressOf vsfStockList_BeforeRowColChange
                    .Row = 2
                    AddHandler vsfStockList.BeforeRowColChange, AddressOf vsfStockList_BeforeRowColChange
                    .Select(1, 0)
                    RemoveHandler vsfStockList.BeforeScroll, lfuncScrollCancelHandler
                    
                    '@受入合計
                    .SetData(CMlngvsfStockRowFrezon, CMlngvsfStockLColNumGet, _
                        Format$(CInt(mtypInvHistoryList.strAcceptTotalNum), CPstrDateFormatKanma))
                    
                    '@払出合計
                    .SetData(CMlngvsfStockRowFrezon, CMlngvsfStockLColNumPut, _
                        Format$(CInt(mtypInvHistoryList.strScrapTotalNum), CPstrDateFormatKanma))
                    
                    
                    '@合計表示
                    .SetData(CMlngvsfStockRowFrezon, CMlngvsfStockLColDate, CMstrTotalTitle)
                    '@合計表示
                    .SetData(CMlngvsfStockRowFrezon, CMlngvsfStockLColDate, CMstrTotalTitle)

                    newStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue_Fixed")
                    '@背景色設定
                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                    '@文字色設定
                    newStyle.ForeColor = Color.Black
                    cellRange = .GetCellRange(CMlngvsfStockRowFrezon, CMlngvsfStockLColTitle, _
                                           CMlngvsfStockRowFrezon, .Cols.Count - 1)
                    cellRange.Style = newStyle
                    
                    'NSYS 文字配置
                    newStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue_TextAlign_RightCenter", newStyle)
                    newStyle.TextAlign = TextAlignEnum.RightCenter
                    cellRange = .GetCellRange(CMlngvsfStockRowFrezon, CMlngvsfStockLColNumGet, _
                                           CMlngvsfStockRowFrezon, CMlngvsfStockLColNumPut)
                    cellRange.Style = newStyle

                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '@列幅設定(固定列は元に戻す)
                        'NSYS 「№」列は2桁の自動列幅調整後で固定されても3桁が省略表示されないように広めにする
                        .AutoSizeCol(CMlngvsfStockLColNo, 8)
                        .AutoSizeCols(CMlngvsfStockLColDate, CMlngvsfStockLColWorkMemo, 6)
                    End If
                    
                    '@表示位置設定
                    .Cols(CMlngvsfStockLColNo).TextAlign = TextAlignEnum.RightCenter                   '№(右中央)
                    .Cols(CMlngvsfStockLColDate).TextAlign = TextAlignEnum.LeftCenter                  '日時(左中央)
                    .Cols(CMlngvsfStockLColStatus).TextAlign = TextAlignEnum.LeftCenter                '状態(左中央)
                    .Cols(CMlngvsfStockLColReasonCode).TextAlign = TextAlignEnum.LeftCenter            '理由ｺｰﾄﾞ(左中央)
                    .Cols(CMlngvsfStockLColStLotID).TextAlign = TextAlignEnum.LeftCenter               '在庫ID(左中央)
                    .Cols(CMlngvsfStockLColPrLotID).TextAlign = TextAlignEnum.LeftCenter               '製造ﾛｯﾄID(左中央)
                    .Cols(CMlngvsfStockLColCFLotID).TextAlign = TextAlignEnum.LeftCenter               'CFﾛｯﾄID(左中央)
                    .Cols(CMlngvsfStockLColLotID).TextAlign = TextAlignEnum.LeftCenter                 'ﾛｯﾄID(左中央)
                    .Cols(CMlngvsfStockLColEmpID).TextAlign = TextAlignEnum.LeftCenter                 '受入担当(左中央)
                    .Cols(CMlngvsfStockLColNumGet).TextAlign = TextAlignEnum.RightCenter               '数量(右中央)
                    .Cols(CMlngvsfStockLColNumPut).TextAlign = TextAlignEnum.RightCenter               '数量(右中央)
                    .Cols(CMlngvsfStockLColBoardThickness).TextAlign = TextAlignEnum.LeftCenter        '板厚(左中央)
                    .Cols(CMlngvsfStockLColReworkCount).TextAlign = TextAlignEnum.RightCenter          'ﾘﾜｰｸ回数(右中央)
                    .Cols(CMlngvsfStockLColWorkMemoFlag).TextAlign = TextAlignEnum.LeftCenter          '作業ﾒﾓ(左中央)
                    .Cols(CMlngvsfStockLColWorkMemo).TextAlign = TextAlignEnum.LeftCenter              '作業ﾒﾓ内容(左中央)
                    .Cols(CMlngvsfStockLColReworkLotID).TextAlign = TextAlignEnum.LeftCenter           '受入元ﾛｯﾄID(左中央)
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        'NSYS ソート時はBeforeRowColChange/RowColChangeを抑制する
                        RemoveHandler vsfStockList.BeforeRowColChange, AddressOf vsfStockList_BeforeRowColChange
                        RemoveHandler vsfStockList.RowColChange, AddressOf vsfStockList_RowColChange

                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt -1
                            '@該当行をｿｰﾄ
                            If mtypChgSort.typChgSortList(llngCnt).lngCol = CMlngvsfStockLColNumGet OrElse _
                                mtypChgSort.typChgSortList(llngCnt).lngCol = CMlngvsfStockLColNumPut Then
                                'NSYS 「受入数量」「払出数量」は数字の0の前に空白""が来るようにするComparerでソートする
                                .Sort(New VsfStockLColNumComparer(mtypChgSort.typChgSortList(llngCnt).lngOrder, _
                                                                  mtypChgSort.typChgSortList(llngCnt).lngCol))
                            Else
                                .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                            End If
                        Next llngCnt
                        'NSYS ソートすると.Rowが2にセットされるので戻す
                        AddHandler vsfStockList.BeforeScroll, lfuncScrollCancelHandler
                        .Row = 1
                        RemoveHandler vsfStockList.BeforeScroll, lfuncScrollCancelHandler

                        'NSYS ソート時はBeforeRowColChange/RowColChangeを抑制を解除する
                        AddHandler vsfStockList.BeforeRowColChange, AddressOf vsfStockList_BeforeRowColChange
                        AddHandler vsfStockList.RowColChange, AddressOf vsfStockList_RowColChange
                    End If

                    '@描画ﾛｯｸ解除
                    .Redraw = True

                    '@ｿｰﾄ検索用ｷｰ(在庫ID)がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@在庫IDが同じ場合
                            If .GetData(llngCnt, CMlngvsfStockLColNo) = mtypChgSort.strKey Then
                                AddHandler vsfStockList.BeforeScroll, lfuncScrollCancelHandler
                                .Row = llngCnt
                                RemoveHandler vsfStockList.BeforeScroll, lfuncScrollCancelHandler
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                Call pubVsfBeforeSort(vsfStockList, CMlngvsfStockLColNo)

                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                'NSYS lblnSetFocus := False 追加
                                Call pubVsfAfterSort(vsfStockList, CMlngvsfStockLColNo, lblnSetFocus:=False)

                                Exit For
                            End If
                        Next llngCnt
                    Else
                        .Row = 1
                        If chkDateSelectKbn.Checked = False Then
                            txtProLotID.Text = vbNullString
                        End If
                        'NSYS スクロール位置復元
                        .ScrollPosition = ltypScrollPos
                    End If

                    '@文字が表示しきれない場合のH処理
                    .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                    
                    '@ﾛｯｸ解除
                    .Enabled = True

                    '@表にﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(vsfStockList)
                
                    '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ使用可
                    cmdCopy.Enabled = True
                Else
                    '@ｸﾞﾘｯﾄﾞの初期化
                    .Redraw = False
                    .Rows.Count = 1
                    .Redraw = True
                End If

                '@描画ﾛｯｸ解除
                .Redraw = True
            End With
               
            '@現在数量
            lblNowTotal.Text = Format$(CInt(mtypInvHistoryList.strNowNum), CPstrDateFormatKanma)
            
            '@情報取得日時表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)

            '@該当件数ﾗﾍﾞﾙに取得件数を表示
            If mtypInvHistoryList.lngInvHistoryListCnt = CMlngDisplayMaxCnt Then
                '@「最大 500」表示
                lblLotCnt.Text = CMstrMaxString & CMstrBrank & mtypInvHistoryList.lngInvHistoryListCnt
            Else
                '@「件数そのまま」表示
                lblLotCnt.Text = mtypInvHistoryList.lngInvHistoryListCnt
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfStockList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbClassName_Disp
    '機　能：部品種別情報表示
    '引　数：mtypVenderlist：取得情報格納ﾃﾞｰﾀ
    '戻り値：なし
    '作成日：2004/11/04 (Thu) 09:42:19 S.Deguchi
    '更新日：2004/11/04 (Thu) 09:42:19
    '備　考：
    Private Sub prvCmbClassName_Disp(ByRef mtypVenderlist As VenderList)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbPartClass
                '@部品種別情報初期化
                .Clear
                .Height = CMlngCmbHeight                                            '高さ
                .DispCols = CMlngCmbDispCols                                        'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol                                        '値取得列
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter       '左寄中央揃え
                .BackColor = SystemColors.Window
                
                '@部品種別情報ｾｯﾄ
                For llngCnt = 0 To mtypVenderlist.lngVenderClassListCnt - 1
                    '@「部品名」&「部品ID」
                    .AddItem(mtypVenderlist.typVenderClassList(llngCnt).strVenderClassName _
                            & vbTab _
                            & mtypVenderlist.typVenderClassList(llngCnt).strVenderClassId)
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbClassName_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbPartName_Disp
    '機　能：部品情報表示
    '引　数：mtypClassList() ：取得情報格納ﾃﾞｰﾀ
    '　　　：llngpartcnt：取得情報ﾃﾞｰﾀ数
    '戻り値：なし
    '作成日：2004/11/04 (Thu) 09:42:19 S.Deguchi
    '更新日：2004/11/04 (Thu) 09:42:19
    '備　考：
    Private Sub prvCmbPartName_Disp(ByRef ltypPartList As List(Of PartClassList), _
                                    ByVal llngpartcnt As Integer)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbPart
                '@部品情報初期化
                .Clear
                .Height = CMlngCmbHeight                                        '高さ
                .DispCols = CMlngCmbDispCols2                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol                                    '値取得列
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
                .ColAlignment(CMlngCmbGridColID) = TextAlignEnum.LeftCenter     '左寄中央揃え
                .BackColor = SystemColors.Window
                
                '@部品情報ｾｯﾄ
                For llngCnt = 0 To llngpartcnt - 1
                    '@'「部品ID」&「部品名」&「部品ID 部品名」
                    .AddItem(ltypPartList(llngCnt).strPartCode _
                            & vbTab _
                            & ltypPartList(llngCnt).strPartName _
                            & vbTab _
                            & ltypPartList(llngCnt).strPartCode & CPstrSpace & ltypPartList(llngCnt).strPartName)
                Next llngCnt
                
                .GetCol = CMlngCmbGetCol                                        '値表示列
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbPartName_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

'未使用機能NSYS ↓
''関数名：prvvsfFocus_Set
''機　能：ﾌｫｰｶｽの戻り位置を設定
''引　数：lobjControl: VSFlexGridオブジェクト
''　　　：lstrKeyID：KeyID
''　　　：llngKeyColNo：KeyIDのCol位置
''　　　：llngTopRow：先頭行
''戻り値：なし
''作成日：2004/11/04 (Thu) 09:42:19 S.Deguchi
''更新日：2004/11/04 (Thu) 09:42:19
''備　考：
'Private Sub prvvsfFocus_Set(ByVal lobjControl As VSFlexGrid, _
'                            ByVal lstrKeyID As String, _
'                            llngKeyColNo As Long, ByVal llngTopRow)

'    Dim llngRowCnt     As Long         'ｶｳﾝﾄ

'    On Error GoTo Error_Handler
    
'    With lobjControl
'        '@確定ﾎﾞﾀﾝ押下前のﾌｫｰｶｽ位置を検索
'        For llngRowCnt = 0 To .Rows - 1
'            '@ﾛｯﾄNo検索
'            If .Cell(flexcpText, llngRowCnt, llngKeyColNo) = lstrKeyID Then
                
'                '@行の選択範囲を設定
'                .Row = llngRowCnt
                
'                '@選択行を表示
'                .ShowCell llngRowCnt, llngKeyColNo
'                Exit Sub
'            End If
'        Next llngRowCnt
        
'        '@ﾌｫｰｶｽｾｯﾄ
'        '@明細行が１件もない場合ﾌｫｰｶｽの戻り位置を制御
'        If .Enabled = False Then
'            Call pubSetFocus(cmdClose)
'        Else
'            Call pubSetFocus(lobjControl)
'        End If
'    End With

'    Exit Sub

'Error_Handler:

'    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
'    With ptypOnErrorInfo
'        .strMenuKey = CMstrLocalMenuKey
'        .strProcName = "prvvsfFocus_Set"
'        .strErrMessage = vbNullString
'    End With

'    '@共通ｴﾗｰ処理
'    Call pubOnError_Proc

'End Sub
'未使用機能NSYS ↑

    '関数名：prvblnSearch_Chk
    '機　能：最新取得ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：成功　False：失敗
    '作成日：2004/11/05 (Fri) 14:35:29 S.Deguchi
    '更新日：2004/11/05 (Fri) 14:35:29
    '備　考：
    Private Function prvblnSearch_Chk() As Boolean

        Dim lstrNowDT       As String       '現在日付

        Try
            
            '@初期化
            prvblnSearch_Chk = False
            
            '@検索日付ﾁｪｯｸ
            If chkDateSelectKbn.Checked = True Then
                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(calFromDate.Value) = True Then
                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                    '@未来日付の場合
                    If Format$(CDate(calFromDate.Value), CPstrDateTimeYMD) > lstrNowDT Then
                       '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                        '@"未来日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@ﾌｫｰｶｽを移さない
                        Call prvSetFocus(calFromDate)
                    
                        Exit Function
                    End If
                Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ﾌｫｰｶｽを移さない
                    Call prvSetFocus(calFromDate)
                
                    Exit Function
                End If
                
                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(calToDate.Value) = True Then
                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                    '@未来日付の場合
                    If Format$(CDate(calToDate.Value), CPstrDateTimeYMD) > lstrNowDT Then
                       '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                        '@"未来日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@ﾌｫｰｶｽを移さない
                        Call prvSetFocus(calToDate)
                    
                        Exit Function
                    End If
                Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ﾌｫｰｶｽを移さない
                    Call prvSetFocus(calToDate)
                
                    Exit Function
                End If
                
                '@検索日付大小ﾁｪｯｸ
                If calFromDate.Value <> CPstrNullDate And calToDate.Value <> CPstrNullDate Then
                    If calFromDate.Value > calToDate.Value Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                        '@"開始日が終了日より大きくなっています。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@ｾｯﾄﾌｫｰｶｽ
                        Call prvSetFocus(calFromDate)
                        
                        Exit Function
                    End If
                End If
                
                '@検索時刻の有効性ﾁｪｯｸ
                    If IsDate(medFromTime.Text) = False Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003C)
                        '@"時刻の設定が正しくありません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@ｾｯﾄﾌｫｰｶｽ
                        Call prvSetFocus(medFromTime)
                        
                        Exit Function
                    End If
                    If IsDate(medToTime.Text) = False Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003C)
                        '@"時刻の設定が正しくありません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@ｾｯﾄﾌｫｰｶｽ
                        Call prvSetFocus(medToTime)
                        
                        Exit Function
                    End If
                
                '@検索時刻大小ﾁｪｯｸ
                If medFromTime.Text <> CPstrNullTime And medToTime.Text <> CPstrNullTime Then
                    If calFromDate.Value = calToDate.Value Then
                        If medFromTime.Text > medToTime.Text Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003E)
                            '@"開始時刻が終了時刻より大きくなっています。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            '@ｾｯﾄﾌｫｰｶｽ
                            Call prvSetFocus(medFromTime)
                            
                            Exit Function
                        End If
                    End If
                End If
                
                '@時間を設定している場合の日付け入力ﾁｪｯｸ
                If medFromTime.Text <> CPstrNullTime And calFromDate.Value = CPstrNullDate Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003D)
                    '@"日付を設定していません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ｾｯﾄﾌｫｰｶｽ
                    Call prvSetFocus(calFromDate)
                    
                    Exit Function
                End If
                
                If medToTime.Text <> CPstrNullTime And calToDate.Value = CPstrNullDate Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003D)
                    '@"日付を設定していません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ｾｯﾄﾌｫｰｶｽ
                    Call prvSetFocus(calToDate)
                    
                    Exit Function
                End If
            End If
            
            '@成功
            prvblnSearch_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnSearch_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '@↓2012/01/24 (Tue) 12:02:43 T.Oide **************************************************共通関数pubGridFocus_Setに変更
    '@'関数名：prvFocus_Set
    '@'機　能：ﾌｫｰｶｽの戻り位置を設定
    '@'引　数：lobjControl: VSFlexGridオブジェクト
    '@'　　　：lstrKeyID：KeyID
    '@'　　　：llngKeyColNo：KeyIDのCol位置
    '@'　　　：llngTopRow：先頭行
    '@'戻り値：なし
    '@'作成日：2004/11/18 (Thu) 08:57:01 S.Deguchi
    '@'更新日：2004/11/18 (Thu) 08:57:01
    '@'備　考：ﾛｯﾄNoを検索してHitした場合は該当行にﾌｫｰｶｽｾｯﾄする。ない場合はｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
    '@Private Sub prvFocus_Set(ByVal lobjControl As VSFlexGrid, _
    '@                         ByVal lstrKeyID As String, _
    '@                         ByVal llngKeyColNo As Long, _
    '@                         ByVal llngTopRow)
    '@
    '@    Dim llngRowCnt     As Long         'ｶｳﾝﾄ
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    With lobjControl
    '@        '@確定ﾎﾞﾀﾝ押下前のﾌｫｰｶｽ位置を検索
    '@        For llngRowCnt = 0 To .Rows - 1
    '@            '@ﾛｯﾄNo検索
    '@            If .Cell(flexcpText, llngRowCnt, llngKeyColNo) = lstrKeyID Then
    '@
    '@                '@行の選択範囲を設定
    '@                .Row = llngRowCnt
    '@
    '@                '@選択行を表示
    '@                .ShowCell llngRowCnt, llngKeyColNo
    '@
    '@                Exit Sub
    '@            End If
    '@        Next llngRowCnt
    '@
    '@        '@ﾌｫｰｶｽｾｯﾄ
    '@        '@明細行が１件もない場合ﾌｫｰｶｽの戻り位置を制御
    '@        If .Enabled = False Then
    '@            Call pubSetFocus(cmdClose)
    '@        Else
    '@            Call pubSetFocus(lobjControl)
    '@        End If
    '@    End With
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "prvFocus_Set"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2012/01/24 (Tue) 12:02:43 T.Oide **************************************************


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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfStockList.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

            'NSYS VB6版のこのフォームの AutoSizeMouse=False のためダブルクリック自動幅調整機能は無効化
            'NSYS 以下のコメントを外せば有効になる

            'ダブルクリックした列番号を格納
            'colindex = gridObj.HitTest(e.X,e.Y).Column

            'サイズを自動調整
            'gridObj.AutoSizeCol(colindex,6)
        End If

    End Sub

    '関数名：prvSetFocus
    '機　能：フォーム専用のフォーカスセット追加処理
    '引　数：lctlNext：フォーカス先コントロールオブジェクト
    '戻り値：なし
    '作成日：2019/10/10 (Thu) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub prvSetFocus(ByVal lctlNext As Control)

        Dim lblnDoSetFocus          As Boolean      'NSYS フォーカス移動するかどうか

        If ActiveControl IsNot Nothing AndAlso ActiveControl.Enabled = True Then

            If mblnNotInValidating = True Then
                'NSYS Validate中でないときはフォーカス移動する
                lblnDoSetFocus = True
            Else
                If (mblnInValidatingCmbPartClass = True AndAlso ActiveControl IsNot cmbPartClass) OrElse _
                    (mblnInValidatingCmbPart = True AndAlso ActiveControl IsNot cmbPart) Then
                    'NSYS Validate中でActiveControlが異なる場合、フォーカス移動しない
                    lblnDoSetFocus = False
                Else
                    'NSYS Validate中でないときはフォーカス移動する
                    lblnDoSetFocus = True
                End If
            End If

            If lblnDoSetFocus = False Then
                'NSYS Validate中はフォーカス移動しない (VB6互換動作)
                Exit Sub
            End If
        End If

        Try
            'NSYS Validateをハンドリングしているコントロールの場合は、ハンドラーをはずす
            If mblnInValidatingCmbPartClass Then
                RemoveHandler cmbPartClass.Validating, AddressOf cmbPartClass_Validate
            End If
            If mblnInValidatingCmbPart Then
                RemoveHandler cmbPart.Validating, AddressOf cmbPart_Validate
            End If
            'NSYS フォーカスセット
            pubSetFocus(lctlNext)
        Finally
            'NSYS Validateハンドラーを戻す
            If mblnInValidatingCmbPartClass Then
                AddHandler cmbPartClass.Validating, AddressOf cmbPartClass_Validate
            End If
            If mblnInValidatingCmbPart Then
                AddHandler cmbPart.Validating, AddressOf cmbPart_Validate
            End If
        End Try

    End Sub

    'クラス：VsfStockLColNumComparer
    '機　能：数値と空白の混在している列のソートComparer
    '作成日：2019/10/12 (Sat) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Class VsfStockLColNumComparer
        Implements IComparer

        Private mlngOrder           As Integer          'NSYS 昇順:1, 降順:-1
        Private mlngCol             As Integer          'NSYS ソート列


        '関数名：コンストラクタ
        '機　能：Comparer生成
        '引　数：llngOrder：昇順降順フラグ
        '　　　：llngCol：ソート列
        '戻り値：なし
        '作成日：2019/10/12 (Sat) 12:00:00 NSYS
        '更新日：
        '備　考：
        Sub New(llngOrder As SortFlags, llngCol As Integer)

            mlngOrder = IIf(llngOrder = SortFlags.Ascending, 1, -1)
            mlngCol = llngCol
        End Sub

        '関数名：Compare
        '機　能：数値と空白の混在している列の比較処理
        '引　数：lobjX：比較対象行
        '　　　：lobjY：比較対象行
        '戻り値：IComparerインターフェースの規約に従う。昇順では0より空白が前にくる。
        '作成日：2019/10/12 (Sat) 12:00:00 NSYS
        '更新日：
        '備　考：
        Public Function Compare(lobjX As Object, lobjY As Object) As Integer Implements IComparer.Compare
            Dim lobjRowX As Row = CType(lobjX, Row)
            Dim lobjRowY As Row = CType(lobjY, Row)
            Dim llngValX As Integer = lobjRowX(mlngCol)
            Dim llngValY As Integer = lobjRowY(mlngCol)
            If llngValX = 0 AndAlso llngValY = 0 Then
                'NSYS 両方0の場合
                Dim lstrDispX As String = lobjRowX.Grid.GetDataDisplay(lobjRowX.Index, mlngCol)
                Dim lstrDispY As String = lobjRowX.Grid.GetDataDisplay(lobjRowY.Index, mlngCol)
                If lstrDispX = vbNullString Then
                    If lstrDispY = vbNullString Then
                        'NSYS 安定ソートのため同値の場合は相対位置で決める
                        Return lobjRowX.Index.CompareTo(lobjRowY.Index) * mlngOrder
                    Else
                        Return -1 * mlngOrder
                    End If
                Else
                    If lstrDispY = vbNullString Then
                        Return 1 * mlngOrder
                    Else
                        'NSYS 安定ソートのため同値の場合は相対位置で決める
                        Return lobjRowX.Index.CompareTo(lobjRowY.Index) * mlngOrder
                    End If
                End If
            Else
                'NSYS 両方0でない場合、通常の数値順で比較する
                Return llngValX.CompareTo(llngValY) * mlngOrder
            End If
        End Function
    End Class

    '関数名：textbox_Enter
    '機　能：ハイライト処理用 フォーカス取得イベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles medFromTime.Enter, medToTime.Enter
        'NSYS フォーカスインでハイライト処理 開始
        sender.ScrollToCaret()
        If (sender.MouseButtons And MouseButtons.Left) = MouseButtons.Left Then
            sender.Tag("OnHighlight") = True
        Else
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：textbox_Leave
    '機　能：ハイライト処理用 フォーカス喪失イベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles medFromTime.Leave, medToTime.Leave
        'NSYS マウス選択でのハイライトをキャンセルする
        sender.Tag("OnHighlight") = False
    End Sub

    '関数名：textbox_KeyUp
    '機　能：ハイライト処理用 キーアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles medFromTime.KeyUp, medToTime.KeyUp
        'NSYS Tabキー押下の場合
        If e.KeyCode = Keys.Tab Then
            'NSYS マウス選択でのハイライトをキャンセルする
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：textbox_MouseDown
    '機　能：ハイライト処理用 マウスダウンイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medFromTime.MouseDown, medToTime.MouseDown
        'NSYS MouseDown時のカーソル位置を保持
        sender.Tag("MouseDownStart") = sender.SelectionStart
    End Sub

    '関数名：textbox_MouseUp
    '機　能：ハイライト処理用 マウスアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medFromTime.MouseUp, medToTime.MouseUp
        Dim curpos As Integer   'NSYS ｶｰｿﾙ位置

        '@ﾊｲﾗｲﾄするになっている場合
        If CBool(sender.Tag("OnHighlight")) = True Then
            ''@ｶｰｿﾙ位置までﾊｲﾗｲﾄ表示
            curpos = sender.SelectionStart
            sender.SelectionStart = 0
            If curpos < CInt(sender.Tag("MouseDownStart")) Then
                'NSYS 左ドラッグ時
                sender.SelectionLength = curpos
            Else
                sender.SelectionLength = curpos + sender.SelectedText.Length
            End If
            sender.ScrollToCaret()
            sender.Tag("OnHighlight") = False
        End If
    End Sub
End Class
