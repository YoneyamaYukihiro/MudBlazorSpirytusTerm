'ﾌｧｲﾙ名：xxEN00L0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：バッチ処理開始　メインフォーム
'作成日：2004/07/20 (Tue) 17:55:35 N.Kasai
'更新日：2019/06/10 (Mon) 09:49:21 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2019, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00L0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00L0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00L0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00L0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00L0)
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
    '@機能ﾊﾞｰｼﾞｮﾝ
    'Private Const CMstrLocalVersion                     As String = "03.03"                 '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                     As String = "03.04"                 '機能ﾊﾞｰｼﾞｮﾝ

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝの宣言
    '@↓2019/06/06 (Thu) 15:40:58 Y.Yoneyama **************************************************
    'Private Const CMstrbat_lotlist_Ver                  As String = "02.02"                 'ﾊﾞｯﾁ組ﾛｯﾄ情報取得
    Private Const CMstrbat_lotlist_Ver                  As String = "03.00"                 'ﾊﾞｯﾁ組ﾛｯﾄ情報取得
    '@↑2019/06/06 (Thu) 15:40:58 Y.Yoneyama **************************************************
    Private Const CMstrbat_prcstartVer                  As String = "03.01"                 'ﾊﾞｯﾁ処理開始
    Private Const CMstrlot_comntinfo_Ver                As String = "01.00"                 'ﾛｯﾄｺﾒﾝﾄ取得

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN00L0          'ﾛｰｶﾙ機能ID

    '@vsfBatListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfColNo                         As Integer = 0                      '順序
    Private Const CMlngvsfColCarrierID                  As Integer = 1                      'ｷｬﾘｱID
    Private Const CMlngvsfColUldCarrierID               As Integer = 2                      'ULDｷｬﾘｱID
    Private Const CMlngvsfColLotID                      As Integer = 3                      'ﾛｯﾄID
    Private Const CMlngvsfColFlowClass                  As Integer = 4                      '種別
    Private Const CMlngvsfColOpID                       As Integer = 5                      '大工程
    Private Const CMlngvsfColStepID                     As Integer = 6                      '小工程
    Private Const CMlngvsfColWFID                       As Integer = 7                      'WFID(#+2桁(例：#01))
    Private Const CMlngvsfColWFQuantity                 As Integer = 8                      'WF枚数
    Private Const CMlngvsfColJigID                      As Integer = 9                      '冶具ID
    Private Const CMlngvsfColS                          As Integer = 10                     '特殊特性
    Private Const CMlngvsfColTimeLimit                  As Integer = 11                     '時間制限
    Private Const CMlngvsfColLotManager                 As Integer = 12                     'ﾛｯﾄ担当
    Private Const CMlngvsfColPDID                       As Integer = 13                     '機種
    Private Const CMlngvsfColLotComment                 As Integer = 14                     'ﾛｯﾄｺﾒﾝﾄ
    Private Const CMlngvsfColLastUpdate                 As Integer = 15                     '最終更新日時
    Private Const CMlngvsfColOptionText                 As Integer = 16                     '作業条件
    Private Const CMlngvsfColStatus                     As Integer = 17                     'ﾛｯﾄ状態
    Private Const CMlngvsfColRealTimeLimit              As Integer = 18                     '時間制限(実数)
    Private Const CMlngvsfColRestrictTypeID             As Integer = 19                     '制限時間ﾀｲﾌﾟID
    Private Const CMlngvsfColStartDayTime               As Integer = 20                     '処理開始日時

    '@vsfBatListの定数宣言(幅)
    Private Const CMlngvsfWColNo                        As Integer = 39                     '順序
    Private Const CMlngvsfWcolCarrierID                 As Integer = 86                     'ｷｬﾘｱID
    Private Const CMlngvsfWColUldCarrierID              As Integer = 86                     'ULDｷｬﾘｱID
    Private Const CMlngvsfWColLotID                     As Integer = 78                     'ﾛｯﾄID
    Private Const CMlngvsfWColStatus                    As Integer = 39                     'ﾛｯﾄ状態
    Private Const CMlngvsfWcolFlowClass                 As Integer = 30                     '種別
    Private Const CMlngvsfWColPDID                      As Integer = 57                     '機種
    Private Const CMlngvsfWColOpID                      As Integer = 136                    '大工程
    Private Const CMlngvsfWColStepID                    As Integer = 136                    '小工程
    Private Const CMlngvsfWColWFID                      As Integer = 39                     'WFID(#+2桁(例：#01))
    Private Const CMlngvsfWColWFQuantity                As Integer = 30                     'WF枚数
    Private Const CMlngvsfWColJigID                     As Integer = 86                     '冶具ID
    Private Const CMlngvsfWColS                         As Integer = 30                     '特殊特性
    Private Const CMlngvsfWColTimeLimit                 As Integer = 78                     '時間制約
    Private Const CMlngvsfWColLotManager                As Integer = 80                     'ﾛｯﾄ担当
    Private Const CMlngvsfWColStartDayTime              As Integer = 136                    '処理開始日時
    Private Const CMlngvsfWColLotComment                As Integer = 133                    'ﾛｯﾄｺﾒﾝﾄ
    Private Const CMlngvsfWColLastUpdate                As Integer = 133                    '最終更新日時
    Private Const CMlngvsfWColRealTimeLimit             As Integer = 0                      '時間制限(実数)
    Private Const CMlngvsfWColRestrictTypeID            As Integer = 0                      '制限時間ﾀｲﾌﾟID
    Private Const CMlngvsfWColOptionText                As Integer = 133                    '作業条件

    '@vsfBatListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfColNo                         As String = "順"                    '順序
    Private Const CMstrvsfColCarrierID                  As String = "ｷｬﾘｱID"                'ｷｬﾘｱID
    Private Const CMstrvsfColUldCarrierID               As String = "ULDｷｬﾘｱID"             'ULDｷｬﾘｱID
    Private Const CMstrvsfColLotID                      As String = "ﾛｯﾄID"                 'ﾛｯﾄID
    Private Const CMstrvsfColStatus                     As String = "状態"                  'ﾛｯﾄ状態
    Private Const CMstrvsfColFlowClass                  As String = "種"                    '種別
    Private Const CMstrvsfColPDID                       As String = "機種"                  '機種
    Private Const CMstrvsfColOpID                       As String = "大工程"                '大工程
    Private Const CMstrvsfColStepID                     As String = "小工程"                '小工程
    Private Const CMstrvsfColWFID                       As String = "WFID"                  'WFID(#+2桁(例：#01))
    Private Const CMstrvsfColWFQuantity                 As String = "WF"                    'WF枚数
    Private Const CMstrvsfColJigID                      As String = "冶具ID"                '冶具ID
    Private Const CMstrvsfColS                          As String = "特"                    '特殊特性
    Private Const CMstrvsfColTimeLimit                  As String = "時間制限"              '時間制限
    Private Const CMstrvsfColLotManager                 As String = "ﾛｯﾄ担当"               'ﾛｯﾄ担当
    Private Const CMstrvsfColStartDayTime               As String = "処理開始予定"          '処理開始日時
    Private Const CMstrvsfColLotComment                 As String = "コメント"              'ﾛｯﾄｺﾒﾝﾄ
    Private Const CMstrvsfColLastUpdate                 As String = "更新日時"              '最終更新日時
    Private Const CMstrvsfColOptionText                 As String = "作業条件"              '作業条件

    '@vsfBatListの定数宣言
    Private Const CMlngVsfRowTitle                      As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                      As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                     As Integer = 12                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                       As Integer = 21                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                        As Integer = 43                     '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfFrozenCols                    As Integer = 4                      '固定列数
    Private Const CMlngvsfLeftHiddenCols                As Integer = 3                      '最左表示

    '@定数宣言
    Private Const CMstrCarrierIDTitle                   As String = "ｷｬﾘｱID： "             'ｺﾒﾝﾄ入力ｷｬﾘｱ表示
    Private Const CMstrHour                             As String = "h"                     '時間制約
    Private Const CMlngStartPDID                        As Integer = 1                      '機種IDの取得開始位置
    Private Const CMlngLengthPDID                       As Integer = 3                      '機種IDの取得長
    Private Const CMlngSideScrollOnFlag                 As Integer = 1                      '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag                As Integer = 2                      '横ｽｸﾛｰﾙ非活性化
    Private Const CMstrBrLeft                           As String = "["                     '成功ﾒｯｾｰｼﾞ用
    Private Const CMstrBrRight                          As String = "]"                     '成功ﾒｯｾｰｼﾞ用
    Private Const CMlngMaxDispRowW                      As Integer = 3                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)
    Private Const CMlngMaxDispRowC                      As Integer = 4                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ｺﾒﾝﾄ)

    '@制限ﾀｲﾌﾟ
    Private Const CMstrRestrictTypeID1                  As String = "1"                     '以下
    Private Const CMstrRestrictTypeID2                  As String = "2"                     '以上

    '@ﾚｽﾎﾟﾝｽ計測用
    Private Const CMstrFormName                         As String = "frmxxEN00L0"           '自ﾌｫｰﾑ名
    Private Const CMstrCmdRegistClick                   As String = "cmdRegist_Click"       'ｲﾍﾞﾝﾄ名定数(確定ﾎﾞﾀﾝ押下)
    Private Const CMstrTxtCarrierValidate               As String = "txtCarrier_Validate"   'ｲﾍﾞﾝﾄ名定数(ｷｬﾘｱIDﾃｷｽﾄValidate処理)

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mstrCarrier                                 As String                           'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mlngSideScrollFlag                          As Integer                          '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
    Private mstrWpID                                    As String                           'WPID
    Private mblnTakeOverDispFlg                         As Boolean                          '引継ぎ表示ﾌﾗｸﾞ
    Private mtypBatLotList                              As BatLotList                       'ﾊﾞｯﾁ組ﾛｯﾄ情報応答構造体
    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ

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
        pubVsfMouseWheelManager_Set(vsfBatList, cmdUp, cmdDown,cmdLeft,cmdRight)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 18:20:45 N.Kasai
    '更新日：2009/06/26 (Fri) 19:37:38 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 19:37:38 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_Load()

        Dim lblnAns         As Boolean      '戻り値

        Try
            
            '@Escﾎﾞﾀﾝを無効にする(ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない為)
            Me.CancelButton = Nothing
            
            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00L0, CMstrLocalVersion)
            
            '@機能ﾊﾞｰｼﾞｮﾝ判定処理が"False：取得失敗"か
            If lblnAns = False Then
                
                '@Escﾎﾞﾀﾝを有効にし、処理終了
                Me.CancelButton = Me.cmdClose
                Exit Sub
            End If


            '@=======================
            '@ 画面情報初期化処理
            '@=======================
            Call prvFrmxxEN00L0_Init()


            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動処理成功"をｾｯﾄ
            pblnFormLoad = True

            '@引継ぎ情報表示済みﾌﾗｸﾞの初期化
            mblnTakeOverDispFlg = False

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
    '作成日：2004/07/27 (Tue) 18:40:07 H.Wajima
    '更新日：2009/06/26 (Fri) 19:43:30 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 19:43:30 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            '@引継ぎ情報表示済みﾌﾗｸﾞが"True：表示済"か
            '@ ※FormLoad後、最初の1回しか処理しない為のﾁｪｯｸ
            If mblnTakeOverDispFlg = True Then

                '@Escﾎﾞﾀﾝを有効にし、処理終了
                Me.CancelButton = Me.cmdClose
                Exit Sub
            End If
            
            '@Escﾎﾞﾀﾝを有効にする
            Me.CancelButton = Me.cmdClose
            
            '@引継ぎ情報表示済みﾌﾗｸﾞに"True：表示済"をｾｯﾄ
            mblnTakeOverDispFlg = True
            
            '@引継ぎ構造体のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@NULL以外の場合
                
                '@引継ぎｷｬﾘｱIDをｾｯﾄする
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                
                '@=======================
                '@ ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                '@=======================
                RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier,New CancelEventArgs(False))
                AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate

            Else
                '@NULLの場合
                
                '@引継ぎｷｬﾘｱIDを初期化
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 18:20:51 N.Kasai
    '更新日：2009/06/26 (Fri) 19:46:26 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 19:46:26 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            '@以下の条件の場合、ｷｰｺｰﾄﾞを無効にし処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                e.Handled = True
                Exit Sub
            End If
          
            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、上(▲)ﾎﾞﾀﾝ、下(▼)ﾎﾞﾀﾝ)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfBatList, cmdUP, cmdDown)
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左(<<)ﾎﾞﾀﾝ、右(>>)ﾎﾞﾀﾝ)
            '@=======================
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfBatList, cmdLeft, cmdRight)
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name

                '@〓 ｷｬﾘｱID 〓
                Case txtCarrier.Name

                    '@Enterｷｰか
                    If e.KeyCode = Keys.Return Then
                        
                        '@=======================
                        '@ ｷｬﾘｱIDﾃｷｽﾄValidate処理
                        '@=======================
                        'NSYS Validateingの多重起動抑止
                        RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                        Call txtCarrier_Validate(sender,New CancelEventArgs(False))
                        AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                        
                        Exit Sub
                    End If
                
                '@〓 作業ﾒﾓ 〓
                Case txtWorkMemo.Name

                    Exit Sub
                
                '@〓 その他 〓
                Case Else
                    
                    '@Enterｷｰか
                    If e.KeyCode = Keys.Return Then
                    
                        '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽをｾｯﾄし、ｷｰｺｰﾄﾞを無効にする
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 18:21:22 N.Kasai
    '更新日：2009/06/26 (Fri) 19:49:59 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 16:00:43 M.Miura      閉じるﾎﾞﾀﾝ統合
    '　　　：2009/06/26 (Fri) 19:49:59 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            '@"×"ﾎﾞﾀﾝにて閉じたか
            If mblnCloseFromControlMenu Then
            
                '@=======================
                '@ 閉じるﾎﾞﾀﾝ押下処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
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
                '@=======================
                '@ ﾒﾆｭｰ伸縮処理
                '@=======================
                Call pubMenuExpand_Disp()

            End If

            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄの開放
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

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 18:21:22 N.Kasai
    '更新日：2009/06/26 (Fri) 09:59:30 N.Kojima
    '備　考：
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
    '　　　：2009/06/26 (Fri) 09:59:30 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo      As CommonInfo           '戻り構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@引継ぎ情報のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@NULL以外の場合

                '@装置別ﾛｯﾄ一覧から引き継いで起動されたか
                If pblnfrmxxEN0150Kbn = True Then

                    '@=======================
                    '@ 装置別ﾛｯﾄ一覧を起動する
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN0150)
                Else
                    '@装置別ﾛｯﾄ一覧以外からの引継ぎ起動
                    
                    '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧から引き継いで起動されたか
                    If pblnfrmxxEN00J0Kbn = True Then

                        '@=======================
                        '@ 装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧を起動する
                        '@=======================
                        Call pubMenuSelect_Proc(CPstrKeyEN00J0)
                    Else
                        '@工程別ﾛｯﾄ一覧から引き継いで起動された場合

                        '@=======================
                        '@ 工程別ﾛｯﾄ一覧を起動する
                        '@=======================
                        Call pubMenuSelect_Proc(CPstrKeyEN0200)
                    End If
                End If
            Else
                '@NULLの場合

                '@=======================
                '@ 終了関数を実行する
                '@=======================
                Call publngEnd_Proc(CPstrKeyEN00L0, ltypCommonInfo)
            End If

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

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 18:21:22 N.Kasai
    '更新日：2009/06/26 (Fri) 10:01:41 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:01:41 N.Kojima     無機対応。(案件№03560)
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            '@=======================
            '@ 画面情報初期化処理
            '@=======================
            Call prvFrmxxEN00L0_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　選択確定時処理(Validate処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/20 (Tue) 18:21:22 N.Kasai
    '更新日：2006/03/07 (Tue) 16:35:37 N.Kojima
    '備　考：
    '　　　：2006/03/07 (Tue) 16:35:37 N.Kojima     ltypBatLotListの値を「cmdRegist_Click」でも使用したい為、
    '　　　：                                       "ltypBatLotList"を"mtypBatLotList"に変更。(不具合№3444)
    '　　　：2009/06/25 (Thu) 13:58:45 N.Kojima     無機対応。(案件№03560)
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim ltypBatRequestList      As BatRequestList       'ﾊﾞｯﾁ組ﾛｯﾄ情報要求構造体
        Dim lblnAns                 As Boolean              '結果格納

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@-----------------------
            '@ ｷｬﾘｱﾁｪｯｸ
            '@-----------------------
            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrier.Text) = vbNullString Then

                'NSYS ActiveControlが自身の場合のみフォーカス処理
                If ActiveControl.Name = txtCarrier.Name Then
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDが6桁以上か
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM07W>$$キャリアIDは6桁で入力してください。"」のﾒｯｾｰｼﾞを表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                e.Cancel = True
                Exit Sub
            End If


            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If Trim(txtCarrier.Text) <> vbNullString And txtCarrier.Text <> mstrCarrier Then
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrTxtCarrierValidate)
                
                '@=======================
                '@ 画面情報初期化処理
                '@=======================
                Call prvFrmxxEN00L0_Init()
                
                '@ﾊﾞｯﾁ組ﾛｯﾄ情報取得要求構造体に値を設定
                With ltypBatRequestList

                    .strClassDivision = CPstrCD11               '処理区分(処理開始：11)
                    .strCarrierId = txtCarrier.Text             'ｷｬﾘｱID
                    .strMcGroupID = vbNullString                '装置ｸﾞﾙｰﾌﾟID
                    .strWpID = vbNullString                     'WP_ID
                    .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                    .strMsgVer = CMstrbat_lotlist_Ver           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                End With
                
                '@=======================
                '@ ﾊﾞｯﾁ組ﾛｯﾄ情報取得
                '@=======================
                lblnAns = pubblnBatLotList_Sel(ltypBatRequestList, mtypBatLotList)
                
                '@ﾊﾞｯﾁ組ﾛｯﾄ情報取得結果が"True：通信成功"か
                If lblnAns = True Then
                    '@True：成功の場合

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrTxtCarrierValidate)

                    '@=======================
                    '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ表示処理
                    '@=======================
                    Call prvVsfBatList_Disp()
                    
                    '@=======================
                    '@ 画面情報表示処理
                    '@=======================
                    Call prvFrmxxEN00L0_Disp()
                    
                    '@=======================
                    '@ 確定ﾎﾞﾀﾝ制御ﾁｪｯｸ処理
                    '@=======================
                    lblnAns = prvblncmdRegist_Chk()
                    
                    '@ﾁｪｯｸ処理結果が"True：ﾁｪｯｸOK"か
                    If lblnAns = True Then
                    
                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdRegist.Enabled = True
                    Else
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    End If
                    
                    '@作業ﾒﾓを有効にする
                    txtWorkMemo.Enabled = True

                Else
                    '@False：通信失敗の場合
                
                    '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                    e.Cancel = True
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                    
                    Exit Sub
                End If
                    
                '@ｷｬﾘｱIDを退避する
                mstrCarrier = txtCarrier.Text
                
                '@ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞが有効か
                If vsfBatList.Enabled = True Then
                    'NSYS ActiveControlが自身の場合のみフォーカス処理
                    If ActiveControl.Name = txtCarrier.Name Then
                        '@ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfBatList)
                    End If
                Else
                    '@ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞが無効の場合
                
                    '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                    e.Cancel = True
                End If

            Else
                '@ｷｬﾘｱIDがNULL、または前回入力ｷｬﾘｱと同じ場合
            
                '@ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞが有効か
                If vsfBatList.Enabled = True Then
                    'NSYS ActiveControlが自身の場合のみフォーカス処理
                    If ActiveControl.Name = txtCarrier.Name Then
                        '@ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfBatList)
                    End If
                Else
                    '@ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞが無効の場合
                    'NSYS ActiveControlが自身の場合のみフォーカス処理
                    If ActiveControl.Name = txtCarrier.Name Then
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：作業ﾒﾓﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 17:52:58 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:16:13 N.Kojima
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2009/06/26 (Fri) 10:16:13 N.Kojima     無機対応。(案件№03560)
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Dim llngNowByte     As Integer  'ﾊﾞｲﾄ数

        Try
            '@現在のﾊﾞｲﾄ数を格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@=======================
            '@ 現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                          llngNowByte, _
                                                          CPlngLotCommentsMaxByte)

            '@=======================
            '@ ﾃｷｽﾄ変更処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRowW, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：作業ﾒﾓﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/12/01 (Thu) 13:10:57 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:18:09 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:18:09 N.Kojima     無機対応。(案件№03560)
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try
            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispRowW, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
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
    '作成日：2005/12/01 (Thu) 13:11:47 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:19:23 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:19:23 N.Kojima     無機対応。(案件№03560)
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try
            '@=======================
            '@ ﾃｷｽﾄ変更処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRowW, cmdMemoUp, cmdMemoDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoUp_Click
    '機　能：作業ﾒﾓ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 17:54:36 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:20:54 N.Kojima
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2009/06/26 (Fri) 10:20:54 N.Kojima     無機対応。(案件№03560)
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
            '@ ﾃｷｽﾄﾎﾞｯｸｽ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通仕様)
            '@=======================
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispRowW, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoUp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：作業ﾒﾓ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 17:54:39 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:22:14 N.Kojima
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2009/06/26 (Fri) 10:22:14 N.Kojima     無機対応。(案件№03560)
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
            '@ ﾃｷｽﾄﾎﾞｯｸｽ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通仕様)
            '@=======================
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispRowW, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_Change
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:26:29 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:23:24 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:23:24 N.Kojima     無機対応。(案件№03560)
    Private Sub txtLotCommnt_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotCommnt.Change

        Try
            '@=======================
            '@ ﾃｷｽﾄ変更処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRowC, cmdTxtUp, cmdTxtDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_KeyUp
    '機　能：ｺﾒﾝﾝﾄﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:27:19 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:25:02 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:25:02 N.Kojima     無機対応。(案件№03560)
    Private Sub txtLotCommnt_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLotCommnt.KeyUp

        Try
            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtLotCommnt, CMlngMaxDispRowC, cmdTxtUp, cmdTxtDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_MouseUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:19:54 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:25:34 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:25:34 N.Kojima     無機対応。(案件№03560)
    Private Sub txtLotCommnt_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtLotCommnt.MouseUp

        Try
            '@=======================
            '@ ﾃｷｽﾄ変更処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRowC, cmdTxtUp, cmdTxtDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtUp_Click
    '機　能：ｺﾒﾝﾄ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 17:55:58 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:26:44 N.Kojima
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2009/06/26 (Fri) 10:26:44 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@ ﾃｷｽﾄﾎﾞｯｸｽ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通仕様)
            '@=======================
            Call pubtxtCmdUp_Proc(txtLotCommnt, CMlngMaxDispRowC, cmdTxtUp, cmdTxtDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTxtUp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtDown_Click
    '機　能：ｺﾒﾝﾄ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 17:56:02 S.Deguchi
    '更新日：2009/06/26 (Fri) 10:27:36 N.Kojima
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2009/06/26 (Fri) 10:27:36 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@ ﾃｷｽﾄﾎﾞｯｸｽ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通仕様)
            '@=======================
            Call pubtxtCmdDown_Proc(txtLotCommnt, CMlngMaxDispRowC, cmdTxtUp, cmdTxtDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTxtDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBatList_AfterUserResize
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ　ﾕｰｻﾞｰ列幅変更後処理
    '引　数：Row    ：行番号
    '　　　：Col    ：列番号
    '戻り値：なし
    '作成日：2004/09/06 (Mon) 14:45:42 N.Kasai
    '更新日：2009/06/26 (Fri) 10:30:04 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:30:04 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfBatList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfBatList.AfterResizeColumn, vsfBatList.AfterResizeRow

        Try
            '@=======================
            '@ 左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            '@=======================
            Call pubCmdLREnable_Set(vsfBatList, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfBatList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBatList_EnterCell
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 14:54:41 N.Kasai
    '更新日：2009/06/25 (Thu) 14:25:24 N.Kojima
    '備　考：
    '　　　：2009/06/25 (Thu) 14:25:24 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfBatList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfBatList.EnterCell

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfBatList.Rows.Count <= vsfBatList.Rows.Fixed Then
                Return
            End If

            With vsfBatList
            
                '@ﾀｲﾄﾙ行以外(ﾃﾞｰﾀ行)が選択されたか
                If .Row > 0 Then
                    '@ﾃﾞｰﾀ行の場合

                    '@作業ﾒﾓ ﾀｲﾄﾙに表示するｷｬﾘｱID
                    lblCarrierS.Text = CMstrCarrierIDTitle & .GetData(.Row, CMlngvsfColCarrierID)
                    
                    '@作業ﾒﾓを表示
                    txtOpeCond.Text = .GetData(.Row, CMlngvsfColOptionText)
                    
                    '@ﾛｯﾄｺﾒﾝﾄ ﾀｲﾄﾙに表示するｷｬﾘｱID
                    lblCarrierC.Text = CMstrCarrierIDTitle & .GetData(.Row, CMlngvsfColCarrierID)
                    
                    '@ﾛｯﾄｺﾒﾝﾄを表示
                    txtLotCommnt.Text = .GetData(.Row, CMlngvsfColLotComment)
                    
        '@↓2009/06/26 (Fri) 19:27:27 N.Kojima **************************************************

                    '@ﾛｯﾄIDがNULL以外か
                    If .GetData(.Row, CMlngvsfColLotID) <> vbNullString Then
                        
                        '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝを有効にする
                        cmdCommntInput.Enabled = True
                    Else
                        '@NULLの場合(ﾀﾞﾐｰ冶具or未使用処理部)
                        
                        '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝを無効にする
                        cmdCommntInput.Enabled = False
                    End If

        '@↑2009/06/26 (Fri) 19:27:27 N.Kojima **************************************************

                Else
                    '@ﾃﾞｰﾀ行以外の場合
                
                    '@各種ﾎﾞﾀﾝを無効にする
                    cmdTxtUp.Enabled = False            'ﾛｯﾄｺﾒﾝﾄ用▲(上)ｽｸﾛｰﾙ
                    cmdTxtDown.Enabled = False          'ﾛｯﾄｺﾒﾝﾄ用▼(下)ｽｸﾛｰﾙ
                    cmdCommntInput.Enabled = False      'ﾛｯﾄｺﾒﾝﾄ
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfBatList_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 14:52:12 N.Kasai
    '更新日：2009/06/26 (Fri) 10:31:51 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:31:51 N.Kojima     無機対応。(案件№03560)
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
            '@ ｸﾞﾘｯﾄﾞ上(▲)ｽｸﾛｰﾙ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdUp(vsfBatList, cmdUP, cmdDown)

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
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 14:52:12 N.Kasai
    '更新日：2009/06/26 (Fri) 10:33:04 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:33:04 N.Kojima     無機対応。(案件№03560)
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
            '@ ｸﾞﾘｯﾄﾞ下(▼)ｽｸﾛｰﾙ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdDown(vsfBatList, cmdUP, cmdDown, False)

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
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ用左(<<)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 14:52:48 N.Kasai
    '更新日：2009/06/26 (Fri) 10:33:33 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:33:33 N.Kojima     無機対応。(案件№03560)
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
            '@ ｸﾞﾘｯﾄﾞ左(<<)ｽｸﾛｰﾙ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdLeft(vsfBatList, cmdLeft, cmdRight)

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
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ用右(>>)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 14:53:08 N.Kasai
    '更新日：2004/07/23 (Fri) 14:53:08
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
            '@ ｸﾞﾘｯﾄﾞ右(>>)ｽｸﾛｰﾙ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdRight(vsfBatList, cmdLeft, cmdRight)

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

    '関数名：cmdCommntInput_Click
    '機　能：ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 14:53:25 N.Kasai
    '更新日：2008/06/16 (Mon) 15:33:20 N.Kojima
    '備　考：
    '　　　：2005/10/26 (Wed) 08:46:12 S.Deguchi    不具合№2404の対応で,画面引継処理を修正
    '　　　：2006/03/28 (Tue) 10:52:32 N.Kojima     引継ぎﾊﾞｸﾞ改修の為、時間制限の格納構造体を変更。(ﾕｰｻﾞｰ要望№0155関連)
    '　　　：2008/06/16 (Mon) 15:33:20 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/06/26 (Fri) 10:43:50 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdCommntInput_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommntInput.Click
        
        Dim lstrTitle       As String       'ﾀｲﾄﾙ格納変数

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2009/06/29 (Mon) 09:40:27 N.Kojima **************************************************

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾛｯﾄIDがNULLの場合
            If Cursor.Current = Cursors.WaitCursor Or _
                vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLotID) = vbNullString Then

                Exit Sub
            End If

        '@↑2009/06/29 (Mon) 09:40:27 N.Kojima **************************************************

            '@***********************
            '@ 引継ぎﾃﾞｰﾀを格納
            '@ ※ptypLotprestateに格納してfrmxxCM0030を呼ぶ
            '@***********************
            With ptypLotprestate
                
                .strLotID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLotID)                      'ﾛｯﾄID
                .strFlowClass = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColFlowClass)              '流動区分
                .strWfNum = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColWFQuantity)                 'WF枚数
                .strOpID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColOpID)                        '大工程
                .strStartTime = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColStartDayTime)           '処理開始予定日時
                .strPdId = Mid(vsfBatList.GetData(vsfBatList.Row, CMlngvsfColPDID), _
                               CMlngStartPDID, _
                               CMlngLengthPDID)                                                                '機種
                .strSpecialFlg = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColS)                     '特殊特性
                .strNowST = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColStatus)                     'Lot状態
                .strStepID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColStepID)                    '小工程
                .strEngEmpName = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLotManager)            'ﾛｯﾄ担当
                .strLimitTime = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColRealTimeLimit)          '時間制限(実数)
                .strRestrictTypeID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColRestrictTypeID)    '制限時間ﾀｲﾌﾟID
                .strComments = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLotComment)              'ﾛｯﾄｺﾒﾝﾄ
                .strLotLastUpdate = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColLastUpdate)         '最終更新日時

                pstrCarrierID = vsfBatList.GetData(vsfBatList.Row, CMlngvsfColCarrierID)              'ｷｬﾘｱID
            
                '@親ﾌｫｰﾑからの呼び出しを識別するために起動識別ﾌﾗｸﾞをTrueにする
                pblnfrmxxCM0030Kbn = True
            
                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                pblnFormLoad = False
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ ﾛｯﾄｺﾒﾝﾄ画面　起動処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0030.Instance = New frmxxCM0030()
                
                '@=======================
                '@ 機能関連情報取得処理
                '@=======================
                Call pubMenuItemCorrelation_Set(CPstrKeyEN0140, lstrTitle)

                '@ﾛｯﾄｺﾒﾝﾄ画面の名称設定
                frmxxCM0030.Instance.Text = lstrTitle
                
                '@ﾌｫｰﾑﾛｰﾄﾞ結果が"True：起動成功"か
                If pblnFormLoad = True Then
                    
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    '@ ﾛｯﾄｺﾒﾝﾄ画面　表示処理
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    frmxxCM0030.Instance.ShowDialog(Me)
                    frmxxCM0030.Instance = Nothing
                    
                    '@ｺﾒﾝﾄｾｯﾄ(ｺﾒﾝﾄﾃｷｽﾄ、ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞのｺﾒﾝﾄ格納列)
                    txtLotCommnt.Text = .strComments
                    vsfBatList.SetData(vsfBatList.Row, CMlngvsfColLotComment, .strComments)
                
                    '@最終更新日時ｾｯﾄ
                    vsfBatList.SetData(vsfBatList.Row, CMlngvsfColLastUpdate, .strLotLastUpdate)
                Else
                    '@ﾌｫｰﾑﾛｰﾄﾞ結果が"False：起動失敗"の場合
                
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    '@ ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    frmxxCM0030.Instance = Nothing
                
                    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                    pblnFormLoad = True
                    
                    Exit Sub
                End If
                
                '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommntInput_Click"
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
    '作成日：2004/07/21 (Wed) 16:09:06 N.Kasai
    '更新日：2009/07/15 (Wed) 16:59:17 N.Kojima
    '備　考：
    '　　　：2005/09/27 (Tue) 11:22:34 N.Kasai      成功ﾒｯｾｰｼﾞ修正余白削除(№2299)
    '　　　：2006/03/06 (Mon) 16:06:47 N.Kojima     時間制限設定時のMsg表示対応。(不具合№3444)
    '　　　：2007/08/30 (Thu) 09:21:04 N.Kasai      時間制限ﾒｯｾｰｼﾞ内容変更(№02014)
    '　　　：2009/06/26 (Fri) 10:48:49 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/15 (Wed) 16:59:17 N.Kojima     無機対応Phase2、確定ﾒｯｾｰｼﾞの判定処理変更。(案件№03661)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnLotMatchFlag        As Boolean              '送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞ(True:格納済,False:未格納)
        Dim lstrCarrierID           As String               '登録ｷｬﾘｱID
        Dim lstrCompareCarrierID    As String               '比較用ｷｬﾘｱID
        Dim ltypBatPrcStart         As BatPrcStartEnd       'ﾊﾞｯﾁ処理開始構造体
        Dim ltypRestrictInfo        As RestrictInfo         '時間制限情報格納構造体
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ1
        Dim llngCnt2                As Integer              '汎用ｶｳﾝﾀ2
        Dim llngAns                 As Integer              'ﾎﾟｯﾌﾟｱｯﾌﾟﾒｯｾｰｼﾞ戻り値格納用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑのﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then
                
                Exit Sub
            End If
            
            '@=======================
            '@ 確定前ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInputInfo_Chk()
            
            '@確定前ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
                Exit Sub
            End If


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@作業者ｺｰﾄﾞ入力画面でｷｬﾝｾﾙﾎﾞﾀﾝを押されたか
            If pblnCancel = True Then
                Exit Sub
            End If


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)

            '@ﾌｫｰﾑﾛｯｸ

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypBatPrcStart

        '        .lngBLotListCnt = lblLotNum.Caption     'ﾛｯﾄ数

                .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strBatchId = lblBatID.Text             'ﾊﾞｯﾁID
                .strComments = txtWorkMemo.Text         '作業ﾒﾓ
                .strEmpID = pstrUserID                  '作業者ID
                .strMsgVer = CMstrbat_prcstartVer       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strClassDivision = CPstrCD3B           '処理区分(3B=制限時間ﾁｪｯｸ有り)
                .strEqType = mtypBatLotList.typBatLot(0).strEqType  '装置ﾀｲﾌﾟ

        '@↓2009/06/26 (Fri) 11:44:51 N.Kojima **************************************************
        '@無機対応によりﾀﾞﾐｰ冶具や未使用処理部はﾛｯﾄIDが存在しないので送信ﾒｯｾｰｼﾞから除外する

        '        '@ﾊﾞｯﾁ組ﾛｯﾄIDと最終更新日時を構造体へ
        '        ReDim Preserve .typBLotList(.lngBLotListCnt)
        '        For llngCnt = 1 To .lngBLotListCnt
        '            .typBLotList(llngCnt).strLotId = _
        '                vsfBatList.Cell(flexcpText, llngCnt, CMlngvsfColLotID)          'ﾛｯﾄID
        '
        '            .typBLotList(llngCnt).strLotLastUpdate = _
        '                vsfBatList.Cell(flexcpText, llngCnt, CMlngvsfColLastUpdate)     '最終更新日時
        '        Next llngCnt

                'NSYS 初期化されていない場合は初期化
                If IsNothing(.typBLotList) Then
                    .typBLotList = New List(Of BLotList)
                End If
                
                '@ﾊﾞｯﾁ組ﾛｯﾄIDと最終更新日時を構造体へ
                For llngCnt = 1 To vsfBatList.Rows.Count - 1
                
                    '@ﾛｯﾄIDがNULL以外か
                    If vsfBatList.GetData(llngCnt, CMlngvsfColLotID) <> vbNullString Then
                        
                        '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞの初期化
                        lblnLotMatchFlag = False
                        
                        For llngCnt2 = 0 To .lngBLotListCnt - 1
                            
                            '@送信ﾃﾞｰﾀのﾛｯﾄﾘｽﾄに既に対象ﾛｯﾄが格納済みか
                            If .typBLotList(llngCnt2).strLotID = _
                                vsfBatList.GetData(llngCnt, CMlngvsfColLotID) Then
                                
                                '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞに"True：格納済"をｾｯﾄ
                                lblnLotMatchFlag = True
                            End If
                        Next llngCnt2
                            
                        '@送信ﾃﾞｰﾀのﾛｯﾄ格納済み判定ﾌﾗｸﾞが"False：格納済"か
                        If lblnLotMatchFlag = False Then
                            
                            '@ﾘｽﾄを+1する
                            .lngBLotListCnt = .lngBLotListCnt + 1
                            Dim typBLotListTmp As BLotList
                            typBLotListTmp.strLotID = vsfBatList.GetData(llngCnt, CMlngvsfColLotID)              'ﾛｯﾄID
                            typBLotListTmp.strLotLastUpdate = vsfBatList.GetData(llngCnt, CMlngvsfColLastUpdate) '最終更新日時
                            .typBLotList.Add(typBLotListTmp)
                        End If
                    End If
                Next llngCnt

        '@↑2009/06/26 (Fri) 11:44:51 N.Kojima **************************************************

            End With


            '@=======================
            '@ 1回目のﾊﾞｯﾁ処理開始(まずは制限時間の確認のみ)
            '@=======================
            lblnAns = pubblnbatPrcStart_Ins(ltypBatPrcStart, ltypRestrictInfo)
            
            '@1回目のﾊﾞｯﾁ作業開始結果が"True：通信成功"か
            If lblnAns = True Then
                
                '@ﾌｫｰﾑﾛｯｸ解除
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                
                '@制限時間超過の警告が発生している、または時間制限設定が存在しないか
                If ltypRestrictInfo.strToOpId <> vbNullString Or _
                    ltypRestrictInfo.strToStepId <> vbNullString Or _
                    ltypRestrictInfo.strLimitTime <> vbNullString Then
                    
                    For llngCnt2 = 0 To mtypBatLotList.typBatLot(mtypBatLotList.lngBatLotCnt - 1).lngBatLotListCnt - 1
                    
                        '@制限時間が設定されているか
                        '@※以下(CMstrRestrictTypeID1=以下設定),以上(CMstrRestrictTypeID2=以上設定)の場合
                        If mtypBatLotList.typBatLot(mtypBatLotList.lngBatLotCnt - 1).typBatList(llngCnt2).strRestrictTypeID = _
                            CMstrRestrictTypeID1 Or _
                            mtypBatLotList.typBatLot(mtypBatLotList.lngBatLotCnt - 1).typBatList(llngCnt2).strRestrictTypeID = _
                            CMstrRestrictTypeID2 Then
                
                            '@↓2007/08/30 (Thu) 09:11:22 N.Kasai **************************************************
                            '@=備忘録=
                            '@時間制限のﾒｯｾｰｼﾞ内容を時間制限ﾀｲﾌﾟを判定し、ﾒｯｾｰｼﾞ内容を作業開始と同じﾒｯｾｰｼﾞとしたが
                            '@複数時間制限が超過されていてもSVからの応答は1件のみ返却される。(作成当初から)
                            '@このことからﾒｯｾｰｼﾞ内容は曖昧な表現を使用していたのであろう。元の表記に戻す。
                            '@又、既存の作りで確定時に一度、登録要求を行いSVで時間制限超過を判定する。ｴﾗｰがある場合は応答ﾒｯｾｰｼﾞに文字列が
                            '@返却される仕組み(エラーがない場合はそのまま登録)でCLは文字列の有無でｲﾝﾌｫﾒｰｼｮﾝﾒｯｾｰｼﾞを表示する。この時点でﾛｯﾄの判別は不能です。
                            '@詳細を表示する場合はSVからｴﾗｰ情報を全て返却してもらう必要あり。
                            '@R4-08ﾃｽﾄ前ﾚﾋﾞｭｰで落合様より複数超過の場合ｴﾗｰが存在してもﾒｯｾｰｼﾞは最初の1件のみ。応答「はい」でその他の超過は無視して登録する仕組み
                            '@であれば、ﾛｯﾄIDを表示する意味もないとのこと。(三浦様　談)

        '                    '@時間制限ﾒｯｾｰｼﾞ表示
        '                    Select Case mtypBatLotList.typBatLot(mtypBatLotList.lngBatLotCnt).typBatList(llngCnt2).strRestrictTypeID
        '                        '@制限時間以下の場合
        '                        Case CMstrRestrictTypeID1
        '                            '@"<TRM3BW>$$ロット[xxx]は[xxx xxx]までの工程において制限時間を経過しています。処理を継続しますか？"
        '                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003F, mtypBatLotList.typBatLot(mtypBatLotList.lngBatLotCnt).typBatList(llngCnt2).strLotID, ltypRestrictInfo.strToOpID, ltypRestrictInfo.strToStepID)
        '
        '                        '@制限時間以上の場合
        '                        Case CMstrRestrictTypeID2
        '                            '@"<TRM3IW>$$ロット[xxx]は[xxx xxx]までの工程において制限時間を経過していません。処理を継続しますか？"
        '                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003I, mtypBatLotList.typBatLot(mtypBatLotList.lngBatLotCnt).typBatList(llngCnt2).strLotID, ltypRestrictInfo.strToOpID, ltypRestrictInfo.strToStepID)
        '
        '                        '@例外処理
        '                        Case Else


                            '@旧ﾒｯｾｰｼﾞ
                            '@"<TRM7NW>$$バッチ組されているロットに[%1 %2]までの工程において$制限時間が守られていないロットが存在します。処理を継続しますか？"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007N, ltypRestrictInfo.strToOpId, ltypRestrictInfo.strToStepId)


        '                    End Select
                            '@↑2007/08/30 (Thu) 09:11:22 N.Kasai **************************************************


                            '@=======================
                            '@ ｲﾝﾌｫﾒｰｼｮﾝﾒｯｾｰｼﾞBOX表示
                            '@=======================
                            llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                            '@ﾒｯｾｰｼﾞBOXにて「いいえ」が選択されたか
                            If llngAns = vbNo Then

                                '@処理終了
                                Exit Sub
                            Else
                                '@「はい」が選択された場合
                                
                                '@ﾌｫｰﾑﾛｯｸ
                                 
                                '@ﾚｽﾎﾟﾝｽ取得開始
                                Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
                
                                '@処理区分再設定(02=指定なし)
                                ltypBatPrcStart.strClassDivision = CPstrCD02
                                
                                '@=======================
                                '@ 2回目のﾊﾞｯﾁ処理開始(こちらはﾊﾞｯﾁ組ﾛｯﾄ処理開始のみ)
                                '@=======================
                                lblnAns = pubblnbatPrcStart_Ins(ltypBatPrcStart, ltypRestrictInfo)
                
                                '@2回目のﾊﾞｯﾁ作業開始結果が"True：通信成功"か
                                If lblnAns = True Then
                                    
                                    '@ﾌｫｰﾑﾛｯｸ解除
                
                                    '@ﾚｽﾎﾟﾝｽ取得終了
                                    Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                
                                    '@表示ﾒｯｾｰｼﾞ作成
                                    lstrCarrierID = vbNullString
                                    
        '@↓2009/06/26 (Fri) 21:23:40 N.Kojima **************************************************

                                    With vsfBatList
                                        
                                        For llngCnt = 1 To .Rows.Count - 1
                                            
                                            '@ﾛｯﾄIDがNULL以外か
                                            If .GetData(llngCnt, CMlngvsfColLotID) <> vbNullString Then
                                                
                                                '@比較用ｷｬﾘｱIDに格納
                                                lstrCompareCarrierID = .GetData(llngCnt, CMlngvsfColCarrierID)
                                                
                                                '@-----------------------
                                                '@ 既にｷｬﾘｱIDが格納されているかﾁｪｯｸ(蒸着ﾊﾞｯﾁ組対応)
                                                '@-----------------------
                                                '@表示ﾒｯｾｰｼﾞ用ｷｬﾘｱIDにﾙｰﾌﾟ行のｷｬﾘｱIDが含まれていないか
                                                If InStr(1, lstrCarrierID, lstrCompareCarrierID) = 0 Then
                                                
                                                    '@表示ﾒｯｾｰｼﾞ用のｷｬﾘｱID連結処理：[[ｷｬﾘｱID1][ｷｬﾘｱID2]]
                                                    lstrCarrierID = lstrCarrierID & _
                                                                    CMstrBrLeft & _
                                                                    .GetData(llngCnt, CMlngvsfColCarrierID) & _
                                                                    CMstrBrRight
                                                End If
                                            End If
                                        Next llngCnt
                                    End With

        '@↑2009/06/26 (Fri) 21:23:40 N.Kojima **************************************************
                                    
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000M, lstrCarrierID)
                                    
                                    '@成功ﾒｯｾｰｼﾞ表示
                                    '@pubVsfInfo_Disp("<TRM0MI>$$バッチ処理開始しました。ｷｬﾘｱ%1")
                                    Call pubVsfInfo_Disp(pstrDMsg)
                                    
                                    '@ｷｬﾘｱIDのｸﾘｱ
                                    txtCarrier.Text = vbNullString
                                    
                                    '@=======================
                                    '@ 画面情報初期化処理
                                    '@=======================
                                    Call prvFrmxxEN00L0_Init()
                                    
                                    Exit For
                                Else
                                    '@2回目のﾊﾞｯﾁ処理開始結果が"False：通信失敗"か
                                
                                    '@ﾌｫｰﾑﾛｯｸ解除
                                    
                                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                    Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                                    
                                    Exit Sub
                                End If
                            End If
                        End If
                    Next llngCnt2
                Else
                    '@制限時間が超過していない、又は時間制限設定が存在しない場合
                
                    '@ﾌｫｰﾑﾛｯｸ解除

                    '@表示ﾒｯｾｰｼﾞ作成
                    lstrCarrierID = vbNullString
                    
        '@↓2009/06/26 (Fri) 21:26:38 N.Kojima **************************************************

                    With vsfBatList

                        For llngCnt = 1 To .Rows.Count - 1
                            
                            '@ﾛｯﾄIDがNULL以外か
                            If .GetData(llngCnt, CMlngvsfColLotID) <> vbNullString Then
                                
                                '@比較用ｷｬﾘｱIDに格納
                                lstrCompareCarrierID = .GetData(llngCnt, CMlngvsfColCarrierID)
                                
                                '@-----------------------
                                '@ 既にｷｬﾘｱIDが格納されているかﾁｪｯｸ(蒸着ﾊﾞｯﾁ組対応)
                                '@-----------------------
                                '@表示ﾒｯｾｰｼﾞ用ｷｬﾘｱIDにﾙｰﾌﾟ行のｷｬﾘｱIDが含まれていないか
                                If InStr(1, lstrCarrierID, lstrCompareCarrierID) = 0 Then
                                    
                                    '@表示ﾒｯｾｰｼﾞ用のｷｬﾘｱID連結処理：[[ｷｬﾘｱID1][ｷｬﾘｱID2]]
                                    lstrCarrierID = lstrCarrierID & _
                                                    CMstrBrLeft & _
                                                    .GetData(llngCnt, CMlngvsfColCarrierID) & _
                                                    CMstrBrRight
                                End If
                            End If
                        Next llngCnt
                    End With

        '@↑2009/06/26 (Fri) 21:26:38 N.Kojima **************************************************
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000M, lstrCarrierID)
                    
                    '@成功ﾒｯｾｰｼﾞ表示
                    '@pubVsfInfo_Disp("<TRM0MI>$$バッチ処理開始しました。ｷｬﾘｱ%1")
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@ｷｬﾘｱIDのｸﾘｱ
                    txtCarrier.Text = vbNullString
                    
                    '@=======================
                    '@ 画面情報初期化処理
                    '@=======================
                    Call prvFrmxxEN00L0_Init()

                End If
            Else
                '@1回目のﾊﾞｯﾁ処理開始結果が"False：通信失敗"か

                '@ﾌｫｰﾑﾛｯｸ解除
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)

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

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvFrmxxEN00L0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/21 (Wed) 16:08:58 N.Kasai
    '更新日：2009/06/25 (Thu) 13:37:41 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 13:20:31 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2009/06/25 (Thu) 13:37:41 N.Kojima     無機対応。(案件№03560)
    Private Sub prvFrmxxEN00L0_Init()

        Dim llngNowByte         As Integer          '現在のﾊﾞｲﾄ数格納
        Dim lstrFormTitle       As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@=======================
            '@ 機能毎関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00L0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mstrCarrier = vbNullString              'ｷｬﾘｱID
            mlngSideScrollFlag = 0                  '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
            mstrWpID = vbNullString                 '装置ID
            
            
            '@-----------------------
            '@ ﾍｯﾀﾞｰ情報の初期化
            '@-----------------------
            '@各種ﾗﾍﾞﾙの初期化
            lblLotStatus.Text = vbNullString     '状態
            lblWpName.Text = vbNullString        '装置
            lblRecipe.Text = vbNullString        'ﾚｼﾋﾟ
            lblBatID.Text = vbNullString         'ﾊﾞｯﾁID
            lblLotNum.Text = vbNullString        'ﾊﾞｯﾁ数
            
            '@作業条件の初期化
            txtOpeCond.Text = vbNullString
            
            '@ｺﾒﾝﾄ表示
            lblCarrierS.Text = CMstrCarrierIDTitle & "      "     '作業条件-ｷｬﾘｱID
            lblCarrierC.Text = CMstrCarrierIDTitle & "      "     'ｺﾒﾝﾄ-ｷｬﾘｱID


            '@-----------------------
            '@ 作業ﾒﾓ関連の初期化
            '@-----------------------
            With txtWorkMemo
                
                '@各種ﾌﾟﾛﾊﾟﾃｨ設定
                .ChrMaxByte = CPlngLotCommentsMaxByte       '最大文字数：2048Byte
                .Text = vbNullString                        'ﾃｷｽﾄ：NULL
                
                '@=======================
                '@ 現状のﾊﾞｲﾄ数を格納し、現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                '@=======================
                llngNowByte = .NowByte
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)

                .Enabled = False                            '無効
            End With
            
            '@作業ﾒﾓの上下ｽｸﾛｰﾙﾎﾞﾀﾝの初期化
            cmdMemoUp.Enabled = False                       '▲(上)：無効
            cmdMemoDown.Enabled = False                     '▼(下)：無効


            '@-----------------------
            '@ 作業条件関連の初期化
            '@-----------------------
            With txtOpeCond

                '@各種ﾌﾟﾛﾊﾟﾃｨの初期化
                .BackColor = SystemColors.ControlLight      '背景色：ｸﾞﾚｰ
                .GotBackColor = SystemColors.ControlLight   'ﾌｫｰｶｽ取得時背景色：ｸﾞﾚｰ
                .Locked = True                              'ﾛｯｸ：ﾛｯｸする
            End With


            '@-----------------------
            '@ ﾛｯﾄｺﾒﾝﾄ関連の初期化
            '@-----------------------
            With txtLotCommnt
                
                '@各種ﾌﾟﾛﾊﾟﾃｨの初期化
                .ChrMaxByte = CPlngLotCommentsMaxByte       '最大文字数：2048Byte
                .Text = vbNullString                        'ﾃｷｽﾄ：NULL
                .BackColor = SystemColors.ControlLight      '背景色：ｸﾞﾚｰ
                .GotBackColor = SystemColors.ControlLight   'ﾌｫｰｶｽ取得時背景色：ｸﾞﾚｰ
                .Locked = True                              'ﾛｯｸ：ﾛｯｸする
            End With
            
            cmdTxtUp.Enabled = False                        '▲(上)：無効
            cmdTxtDown.Enabled = False                      '▼(下)：無効
            

            '@-----------------------
            '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞの初期化
            '@-----------------------
            Call prvVsfBatList_Init()

            cmdUP.Enabled = False                           '▲(上)：無効
            cmdDown.Enabled = False                         '▼(下)：無効
            cmdLeft.Enabled = False                         '<<(左)：無効
            cmdRight.Enabled = False                        '>>(右)：無効
            
            
            '@-----------------------
            '@ 各種ﾎﾞﾀﾝの初期化
            '@-----------------------
            cmdWorkDirect.Enabled = False                   '作業指示書
            cmdCommntInput.Enabled = False                  'ﾛｯﾄｺﾒﾝﾄ
            cmdRegist.Enabled = False                       '確定
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN00L0_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxEN00L0_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/21 (Wed) 16:09:41 N.Kasai
    '更新日：2006/03/07 (Tue) 16:42:09 N.Kojima
    '備　考：
    '　　　：2006/03/07 (Tue) 16:42:09 N.Kojima     "ltypBatLotList"を"mtypBatLotList"に変更。(不具合№3444)
    '　　　：2009/06/25 (Thu) 14:16:47 N.Kojima     無機対応。(案件№03560)
    Private Sub prvFrmxxEN00L0_Disp()
        
        Dim llngLoopCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCnt         As Integer      'ﾊﾞｯﾁ数

        Try
            
            '@ﾊﾞｯﾁ組ﾛｯﾄ情報取得でﾃﾞｰﾀがあったか
            If mtypBatLotList.lngBatLotCnt > 0 Then
                '@1件以上あった場合
                
                '@ﾊﾞｯﾁ数を格納
                llngCnt = mtypBatLotList.lngBatLotCnt - 1
            
                '@共通項目をﾗﾍﾞﾙに設定する
                lblBatID.Text = mtypBatLotList.typBatLot(llngCnt).strBatchId             'ﾊﾞｯﾁID
                lblWpName.Text = mtypBatLotList.typBatLot(llngCnt).strWpName             '装置名
                lblRecipe.Text = mtypBatLotList.typBatLot(llngCnt).strRecipeId           'ﾚｼﾋﾟID
        '        lblLotNum.Caption = mtypBatLotList.typBatLot(llngCnt).lngBatLotListCnt      'ﾛｯﾄ数
                
                '@退避領域に装置IDを格納
                mstrWpID = mtypBatLotList.typBatLot(llngCnt).strWpID
            
                With vsfBatList
                    
                    '@入力されたｷｬﾘｱIDをﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞから探す
                    For llngLoopCnt = 1 To .Rows.Count - 1
                        
                        '@入力されたｷｬﾘｱと同じか
                        If .GetData(llngLoopCnt, CMlngvsfColCarrierID) = txtCarrier.Text Then
                            
                            '@先頭へ持っていく
                            .TopRow = llngLoopCnt
                            
                            '@状態を表示
                            lblLotStatus.Text = mtypBatLotList.typBatLot(llngCnt).typBatList(llngLoopCnt - 1).strCurrentStatusName
                            
                            '@選択状態にする
                            .Row = llngLoopCnt
                            .Select(llngLoopCnt, CMlngVsfColTitle)
                            
                            '@-----------------------
                            '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙﾎﾞﾀﾝ設定
                            '@-----------------------
                            '@=======================
                            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfBeforeSort(vsfBatList, CMlngvsfColCarrierID)
                            
                            '@=======================
                            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfAfterSort(vsfBatList, CMlngvsfColCarrierID, cmdUP, cmdDown, False, False)
                        
                        End If
                        
                        '@=======================
                        '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ選択時処理
                        '@=======================
                        Call vsfBatList_EnterCell(vsfBatList,New EventArgs())

                    Next llngLoopCnt
                End With
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN00L0_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfBatList_Init
    '機　能：ﾊﾞｯﾁ組一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 14:58:05 N.Kasai
    '更新日：2009/07/16 (Thu) 15:25:27 N.Kojima
    '備　考：
    '　　　：2006/03/28 (Tue) 18:47:17 N.Kojima     ﾛｯﾄｺﾒﾝﾄ画面引継ぎ用の時間制限Col追加に伴う修正。(不具合№3444関連)
    '　　　：2008/06/16 (Mon) 15:33:50 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/06/25 (Thu) 13:48:34 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/16 (Thu) 15:25:27 N.Kojima     無機対応Phase2、非表示列設定を追加。(案件№03661)
    Private Sub prvVsfBatList_Init()

        Try

            '@-----------------------
            '@ ﾊﾞｯﾁ組情報一覧の初期設定(各ｶﾗﾑの幅、ﾀｲﾄﾙを設定 etc...)
            '@-----------------------
            With vsfBatList

                .Clear                          'ｸﾘｱ
                .AllowSorting = AllowSortingEnum.None 'ｿｰﾄ：不可
                'NSYS 不要なHandler処理を抑止
                RemoveHandler vsfBatList.EnterCell,AddressOf vsfBatList_EnterCell
                .Rows.Count = 1                       '初期行数：1
                .Row = 0                              'NSYS 初期はヘッダー選択
                AddHandler vsfBatList.EnterCell,AddressOf vsfBatList_EnterCell
                '.FillStyle = flexFillRepeat     '選択単位：行
                '.AllowBigSelection = False      'ﾀｲﾄﾙ行ｸﾘｯｸでの全列選択：不可
                '.AllowSelection = False         'ﾏｳｽでｾﾙ範囲選択：不可
                
                '@ﾀｲﾄﾙ行の文字色、背景色の設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_vsfBatList_Header")
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfColNo, CMlngVsfRowTitle, .Cols.Count - 1)
                newStyle.ForeColor = Color.Yellow                              '文字色
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor) '背景色
                newStyle.TextAlign = TextAlignEnum.CenterCenter                '@表示位置の設定(中央表示)
                newStyle.Font = New Font(.Font.FontFamily, CMlngVsfHFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont) 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                cellRange.Style = newStyle

                '@列幅
                .Cols(CMlngvsfColNo).Width = CMlngvsfWColNo                                                       '順序
                .Cols(CMlngvsfColCarrierID).Width = CMlngvsfWcolCarrierID                                         'ｷｬﾘｱID
                .Cols(CMlngvsfColUldCarrierID).Width = CMlngvsfWColUldCarrierID                                   'ULDｷｬﾘｱID
                .Cols(CMlngvsfColLotID).Width = CMlngvsfWColLotID                                                 'ﾛｯﾄID
                .Cols(CMlngvsfColStatus).Width = CMlngvsfWColStatus                                               'ﾛｯﾄ状態
                .Cols(CMlngvsfColPDID).Width = CMlngvsfWColPDID                                                   '機種
                .Cols(CMlngvsfColFlowClass).Width = CMlngvsfWcolFlowClass                                         '種別
                .Cols(CMlngvsfColOpID).Width = CMlngvsfWColOpID                                                   '大工程
                .Cols(CMlngvsfColStepID).Width = CMlngvsfWColStepID                                               '小工程
                .Cols(CMlngvsfColWFID).Width = CMlngvsfWColWFID                                                   'WFID(#+2桁(例：#01))
                .Cols(CMlngvsfColWFQuantity).Width = CMlngvsfWColWFQuantity                                       'WF枚数
                .Cols(CMlngvsfColJigID).Width = CMlngvsfWColJigID                                                 '冶具ID
                .Cols(CMlngvsfColS).Width = CMlngvsfWColS                                                         '特殊特性
                .Cols(CMlngvsfColTimeLimit).Width = CMlngvsfWColTimeLimit                                         '時間制約
                .Cols(CMlngvsfColLotManager).Width = CMlngvsfWColLotManager                                       'ﾛｯﾄ担当
                .Cols(CMlngvsfColStartDayTime).Width = CMlngvsfWColStartDayTime                                   '処理開始日時
                .Cols(CMlngvsfColLotComment).Width = CMlngvsfWColLotComment                                       'ﾛｯﾄｺﾒﾝﾄ
                .Cols(CMlngvsfColLastUpdate).Width = CMlngvsfWColLastUpdate                                       '最終更新日時
                .Cols(CMlngvsfColRealTimeLimit).Width = CMlngvsfWColRealTimeLimit                                 '時間制限(実数)
                .Cols(CMlngvsfColRestrictTypeID).Width = CMlngvsfWColRestrictTypeID                               '制限時間ﾀｲﾌﾟID
                .Cols(CMlngvsfColOptionText).Width = CMlngvsfWColOptionText                                       '作業条件

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfColNo, CMstrvsfColNo)                              '順序
                .SetData(CMlngVsfRowTitle, CMlngvsfColCarrierID, CMstrvsfColCarrierID)                'ｷｬﾘｱID
                .SetData(CMlngVsfRowTitle, CMlngvsfColUldCarrierID, CMstrvsfColUldCarrierID)          'ULDｷｬﾘｱID
                .SetData(CMlngVsfRowTitle, CMlngvsfColLotID, CMstrvsfColLotID)                        'ﾛｯﾄID
                .SetData(CMlngVsfRowTitle, CMlngvsfColStatus, CMstrvsfColStatus)                      '状態
                .SetData(CMlngVsfRowTitle, CMlngvsfColPDID, CMstrvsfColPDID)                          '機種
                .SetData(CMlngVsfRowTitle, CMlngvsfColFlowClass, CMstrvsfColFlowClass)                '種別
                .SetData(CMlngVsfRowTitle, CMlngvsfColOpID, CMstrvsfColOpID)                          '大工程
                .SetData(CMlngVsfRowTitle, CMlngvsfColStepID, CMstrvsfColStepID)                      '小工程
                .SetData(CMlngVsfRowTitle, CMlngvsfColWFID, CMstrvsfColWFID)                          'WFID(#+2桁(例：#01))
                .SetData(CMlngVsfRowTitle, CMlngvsfColWFQuantity, CMstrvsfColWFQuantity)              'WF枚数
                .SetData(CMlngVsfRowTitle, CMlngvsfColJigID, CMstrvsfColJigID)                        '冶具ID
                .SetData(CMlngVsfRowTitle, CMlngvsfColS, CMstrvsfColS)                                '特殊特性
                .SetData(CMlngVsfRowTitle, CMlngvsfColTimeLimit, CMstrvsfColTimeLimit)                '時間制約
                .SetData(CMlngVsfRowTitle, CMlngvsfColLotManager, CMstrvsfColLotManager)              'ﾛｯﾄ担当
                .SetData(CMlngVsfRowTitle, CMlngvsfColStartDayTime, CMstrvsfColStartDayTime)          '処理開始日時
                .SetData(CMlngVsfRowTitle, CMlngvsfColLotComment, CMstrvsfColLotComment)              'ﾛｯﾄｺﾒﾝﾄ
                .SetData(CMlngVsfRowTitle, CMlngvsfColLastUpdate, CMstrvsfColLastUpdate)              '最終更新日時
                .SetData(CMlngVsfRowTitle, CMlngvsfColOptionText, CMstrvsfColOptionText)              '作業条件


                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight                                                  '高さ


                .Cols.Frozen = CMlngvsfFrozenCols                          '固定列：4
                .AllowResizing = AllowResizingEnum.Columns                 'ﾏｳｽによる列幅変更：列のみ可
                .Styles.Fixed.Trimming = StringTrimming.None               'NSYS ヘッダーは省略表示なし
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '省略符号(...)表示：する
                .FocusRect = FocusRectEnum.Light                           'ﾌｫｰｶｽ枠のｽﾀｲﾙ：細枠

                '@非表示項目の設定
        '@↓2009/07/22 (Wed) 09:24:10 N.Kojima **************************************************
                .Cols(CMlngvsfColUldCarrierID).Visible = False     'ULDｷｬﾘｱID
                .Cols(CMlngvsfColWFID).Visible = False             'WFID
                .Cols(CMlngvsfColJigID).Visible = False            '冶具ID
        '@↑2009/07/22 (Wed) 09:24:10 N.Kojima **************************************************
                .Cols(CMlngvsfColPDID).Visible = False             '機種:ﾊﾞｰｼﾞｮﾝ
                .Cols(CMlngvsfColStatus).Visible = False           '状態
                .Cols(CMlngvsfColLotComment).Visible = False       'ﾛｯﾄｺﾒﾝﾄ
                .Cols(CMlngvsfColLastUpdate).Visible = False       '最終更新日時
                .Cols(CMlngvsfColOptionText).Visible = False       '作業条件
                
                '@隠れている項目を表示する
                .LeftCol = CMlngvsfLeftHiddenCols
                
                '@無効
                .Enabled = False

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfBatList_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfBatList_Disp
    '機　能：ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞ表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 15:01:30 N.Kasai
    '更新日：2012/03/12 (Mon) 14:18:36 T.Oide
    '備　考：
    '　　　：2004/09/09 (Thu) 16:09:02 Y.Yamagishi  時間制限を分表示に変更(不具合改善№693)
    '　　　：2006/03/07 (Tue) 16:43:59 N.Kojima     "ltypBatLotList"を"mtypBatLotList"に変更。(不具合№3444)
    '　　　：2006/03/28 (Tue) 18:46:28 N.Kojima     ﾛｯﾄｺﾒﾝﾄ画面引継ぎ用の時間制限Col追加に伴う修正。(不具合№3444関連)
    '　　　：2006/05/12 (Fri) 15:59:28 T.Kitagawa   制限時間の表示を分合計から時間と分で分割表示する(#,##0時間 #0分)(ﾕｰｻﾞ要望№0186)
    '　　　：2006/06/08 (Thu) 15:00:04 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/16 (Mon) 15:34:41 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/06/25 (Thu) 14:04:44 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/16 (Thu) 15:29:41 N.Kojima     無機対応Phase2、各種表示追加。(案件№03661)
    '　　　：2012/03/12 (Mon) 09:41:52 T.Oide       無機装置追加対応(REQ-1303)
    Private Sub prvVsfBatList_Disp()

        Dim lblnAns                 As Boolean          '結果格納
        Dim ltypLotComntInfo        As LotComntInfo     'ﾛｯﾄｺﾒﾝﾄ取得構造体
        Dim llngDoCnt               As Integer          'ｶｳﾝﾄ
        Dim llngCnt                 As Integer          '汎用ｶｳﾝﾀ1
        Dim llngCnt2                As Integer          '汎用ｶｳﾝﾀ2
        Dim llngLotCnt              As Integer          'ﾛｯﾄ数
        Dim lstrLimitTimeAns        As String           '時間制限変換用変数(#,##0時間 #0分)
        Dim lstrInfoGetCompLotID    As String           '情報取得済みﾛｯﾄID(同じ情報を2度取得しない対応)
        Dim lstrSearchLotID         As String           '検索ﾛｯﾄID
        Dim llngRowCnt              As Integer          '行ｶｳﾝﾀｰ
        Dim lstrTmpLotId            As String           'ﾛｯﾄID退避用    '@↑2012/03/12 (Mon) 11:28:19 T.Oide **************************************************
        Dim newStyle                As CellStyle        'NSYS グリッド書式設定用
        Dim cellRange               As CellRange        'NSYS グリッド書式設定用

        Try


            With vsfBatList
            
                '@ﾊﾞｯﾁ組情報ﾃﾞｰﾀが0件か
                If mtypBatLotList.lngBatLotCnt = 0 Then
                    '@0件の場合
                    
                    '@=======================
                    '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞの初期化
                    '@=======================
                    Call prvVsfBatList_Init()
                    
                    '@横ｽｸﾛｰﾙ(左右)ﾎﾞﾀﾝを無効にする
                    cmdLeft.Enabled = False
                    cmdRight.Enabled = False
                    
                    Exit Sub
                Else
                    '@1件以上ある場合
                    
                    '@ﾊﾞｯﾁ組情報数を格納
                    llngCnt = mtypBatLotList.lngBatLotCnt - 1
                    
                    '@ﾊﾞｯﾁ組情報のﾊﾞｯﾁ組ﾛｯﾄ数が0件か
                    If mtypBatLotList.typBatLot(llngCnt).lngBatLotListCnt = 0 Then
                        '@0件の場合
                        
                        '@=======================
                        '@ ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞの初期化
                        '@=======================
                        Call prvVsfBatList_Init()
                        
                        '@横ｽｸﾛｰﾙ(左右)ﾎﾞﾀﾝを無効にする
                        cmdLeft.Enabled = False
                        cmdRight.Enabled = False
                        
                        Exit Sub
                    Else
                        '@1件以上ある場合
                        '@ﾊﾞｯﾁ組情報一覧ｸﾞﾘｯﾄﾞを有効にする
                        .Enabled = True
                        
                        '@描画ﾛｯｸ
                        .Redraw = False
                        
        '@↓2012/03/12 (Mon) 14:20:03 T.Oide **************************************************
        '@
        '@                '@行数設定
        '@                .Rows = mtypBatLotList.typBatLot(llngCnt).lngBatLotListCnt + 1
        '@
        '@                '@ｶｳﾝﾀの初期化
        '@                llngDoCnt = 1
        '@
        '@                '@***********************
        '@                '@ ﾊﾞｯﾁ組情報表示
        '@                '@***********************
        '@                Do While .Rows > llngDoCnt
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColNo) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strSeqNum                     '順序
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColCarrierID) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strCarrierId                  'ｷｬﾘｱID
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColUldCarrierID) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strUldCarrierID               'ULDｷｬﾘｱID
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColLotID) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLotId                      'ﾛｯﾄID
        '@
        '@                    '@ﾛｯﾄIDがNULLか
        '@                    If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLotId = vbNullString Then
        '@
        '@                        '@ﾛｯﾄIDがNULLの場合は、ﾀﾞﾐｰ冶具or未使用処理部である為、ｷｬﾘｱID列に"ﾀﾞﾐｰ"or"未使用"をｾｯﾄ
        '@                        .Cell(flexcpText, llngDoCnt, CMlngvsfColCarrierID) = _
        '@                            mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strWfID                     'ｷｬﾘｱID(ﾀﾞﾐｰ、未使用処理部用)
        '@                    End If
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColStatus) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strCurrentStatusName          'ﾛｯﾄ状態
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColFlowClass) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strFlowClass                  '種別
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColPDID) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strPdID                       '機種
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColOpID) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strOpId                       '大工程
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColStepID) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strStepId                     '小工程
        '@
        '@                    '@ﾛｯﾄIDがNULL以外か
        '@                    If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLotId <> vbNullString Then
        '@
        '@                        .Cell(flexcpText, llngDoCnt, CMlngvsfColWFID) = _
        '@                            CPstrSharp & Right(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strWfID, 2)    'WFID(#+2桁(例：#01))
        '@                    End If
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColWFQuantity) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strWFQuantity                 'WF枚数
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColJigID) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strjigId                      '冶具ID
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColS) _
        '@                                = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strSpecialFlag        '特殊特性
        '@
        '@                    '@-----------------------
        '@                    '@ 時間制約有無の表示
        '@                    '@-----------------------
        '@                    If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime <> vbNullString Then
        '@
        '@                        '@時間制約がﾌﾟﾗｽの場合
        '@                        If CLng(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime) >= 0 Then
        '@
        '@                            '@制限時間以下or処理時間制限以下の場合
        '@                            '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
        '@                            If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID1 Or _
        '@                                mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID3 Then
        '@
        '@                                '@ﾌｫｰﾏｯﾄ変換(##,##0)
        '@                                '@制限時間を時間と分で分割表示する
        '@                                lstrLimitTimeAns = pubstrLimitTime_Set(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime)
        '@                                .Cell(flexcpText, llngDoCnt, CMlngvsfColTimeLimit) = lstrLimitTimeAns
        '@
        '@                                '@警告時間が設定されている場合
        '@                                If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strWarnTime <> vbNullString Then
        '@
        '@                                    '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
        '@                                    If CLng(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strWarnTime) < 0 And _
        '@                                        CLng(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime) >= 0 Then
        '@
        '@                                        '@ﾌｫﾝﾄｶﾗｰを紫に変更
        '@                                        .Cell(flexcpForeColor, llngDoCnt, CMlngvsfColTimeLimit, llngDoCnt, CMlngvsfColTimeLimit) _
        '@                                                = CPlngVbColorPurple
        '@                                    Else
        '@                                        '@ﾌｫﾝﾄｶﾗｰを黒に変更
        '@                                        .Cell(flexcpForeColor, llngDoCnt, CMlngvsfColTimeLimit, llngDoCnt, CMlngvsfColTimeLimit) _
        '@                                                = vbBlack
        '@                                    End If
        '@                                End If
        '@                            End If
        '@
        '@                        Else
        '@                            '@制限時間がﾏｲﾅｽの場合
        '@
        '@                            '@ﾌｫﾝﾄｶﾗｰを赤に変更
        '@                            .Cell(flexcpForeColor, llngDoCnt, CMlngvsfColTimeLimit, llngDoCnt, CMlngvsfColTimeLimit) _
        '@                                    = CPlngVbColorRed
        '@
        '@                            '@制限時間以下or処理時間制限以下の場合
        '@                            '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
        '@                            If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID1 Or _
        '@                                mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID3 Then
        '@
        '@                                '@ﾌｫｰﾏｯﾄ変換(##,##0)
        '@                                '@制限時間を時間と分で分割表示する
        '@                                lstrLimitTimeAns = pubstrLimitTime_Set(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime)
        '@                                .Cell(flexcpText, llngDoCnt, CMlngvsfColTimeLimit) = lstrLimitTimeAns
        '@                            End If
        '@
        '@                            '@制限時間以上の場合
        '@                            If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID2 Then
        '@                                '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,##0)+"分"
        '@
        '@                                '@制限時間を時間と分で分割表示する
        '@                                lstrLimitTimeAns = pubstrLimitTime_Set(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime)
        '@                                .Cell(flexcpText, llngDoCnt, CMlngvsfColTimeLimit) = Replace(lstrLimitTimeAns, CPstrReplaceMinus, vbNullString)
        '@                            End If
        '@                        End If
        '@                    End If
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColLotManager) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strEngEmpName                 'ﾛｯﾄ担当
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColStartDayTime) _
        '@                        = Format$(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strStartTime, _
        '@                                 CPstrDateFormat)                                                               '処理開始予定日時
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColRealTimeLimit) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLimitTime                  '時間制限(実数)
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColRestrictTypeID) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strRestrictTypeID             '制限時間ﾀｲﾌﾟID
        '@
        '@                    '@ｺﾒﾝﾄ取得前に初期化
        '@                    ltypLotComntInfo.strComments = vbNullString
        '@                    ltypLotComntInfo.strLotLastUpdate = vbNullString
        '@
        '@                    '@-----------------------
        '@                    '@ ﾀﾞﾐｰ冶具、未使用処理部はﾛｯﾄｺﾒﾝﾄ取得を行わない
        '@                    '@-----------------------
        '@
        '@                    '@ﾛｯﾄIDがNULL以外か
        '@                    If .Cell(flexcpText, llngDoCnt, CMlngvsfColLotID) <> vbNullString Then
        '@
        '@                        '@検索用にﾛｯﾄIDを退避(長いので)
        '@                        lstrSearchLotID = .Cell(flexcpText, llngDoCnt, CMlngvsfColLotID)
        '@
        '@                        '@情報取得済みﾛｯﾄIDではないか
        '@                        If InStr(1, lstrInfoGetCompLotID, lstrSearchLotID) = 0 Then
        '@
        '@                            '@=======================
        '@                            '@ ﾛｯﾄｺﾒﾝﾄ取得処理
        '@                            '@=======================
        '@                            lblnAns = pubblnlotComntInfo_Sel(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strCarrierId, _
        '@                                                             CMstrlot_comntinfo_Ver, _
        '@                                                             ltypLotComntInfo)
        '@
        '@                            '@ﾛｯﾄｺﾒﾝﾄ取得処理結果が"True：通信成功"か
        '@                            If lblnAns = True Then
        '@                                '@True：通信成功の場合
        '@
        '@                                .Cell(flexcpText, llngDoCnt, CMlngvsfColLotComment) = _
        '@                                    ltypLotComntInfo.strComments                                    'ﾛｯﾄｺﾒﾝﾄ：取得値
        '@                            Else
        '@                                .Cell(flexcpText, llngDoCnt, CMlngvsfColLotComment) = _
        '@                                    vbNullString                                                    'ﾛｯﾄｺﾒﾝﾄ：NULL
        '@                            End If
        '@
        '@                            '@ﾛｯﾄ数を+1する
        '@                            llngLotCnt = llngLotCnt + 1
        '@                        Else
        '@                            '@取得済みﾛｯﾄの場合
        '@
        '@                            For llngCnt2 = 1 To .Rows - 1
        '@
        '@                                '@ﾛｯﾄIDが同じか
        '@                                If .Cell(flexcpText, llngDoCnt, CMlngvsfColLotID) = _
        '@                                    .Cell(flexcpText, llngCnt2, CMlngvsfColLotID) Then
        '@
        '@                                    '@同じﾛｯﾄIDの取得済みﾛｯﾄｺﾒﾝﾄをｺﾋﾟｰ
        '@                                    .Cell(flexcpText, llngDoCnt, CMlngvsfColLotComment) = _
        '@                                        .Cell(flexcpText, llngCnt2, CMlngvsfColLotComment)
        '@
        '@                                    Exit For
        '@                                End If
        '@                            Next llngCnt2
        '@                        End If
        '@
        '@                        '@情報取得済みﾛｯﾄIDに情報取得したﾛｯﾄIDを退避(結合して格納していく)
        '@                        lstrInfoGetCompLotID = lstrInfoGetCompLotID & CPstrSpace & _
        '@                                                .Cell(flexcpText, llngDoCnt, CMlngvsfColLotID)
        '@
        '@                    Else
        '@                        '@ﾛｯﾄIDがNULLの場合(ﾀﾞﾐｰ冶具or未使用処理部)
        '@
        '@                        .Cell(flexcpText, llngDoCnt, CMlngvsfColLotComment) = vbNullString      'ﾛｯﾄｺﾒﾝﾄ：NULL
        '@                    End If
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColLastUpdate) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strLotLastUpdate              '最終更新日時
        '@
        '@                    .Cell(flexcpText, llngDoCnt, CMlngvsfColOptionText) _
        '@                        = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt).strOptionText                 '作業条件
        '@
        '@                    '@ｽﾛｯﾄの高さの設定
        '@                    .RowHeight(llngDoCnt) = CMlngVsfHeight
        '@
        '@                    '@ｶｳﾝﾄｱｯﾌﾟ
        '@                    llngDoCnt = llngDoCnt + 1
        '@                Loop
        '--------------------------------------------------------------------------------------------------


                        '@変数初期化
                        llngDoCnt = 1       '構造体のｶｳﾝﾀ
                        llngRowCnt = 1      '表示行
                        lstrTmpLotId = vbNullString
                        
                        '@***********************
                        '@ ﾊﾞｯﾁ組情報表示
                        '@
                        '@ - 表面処理でﾛｯﾄIDが前回値と同じ場合は表示ﾙｰﾌﾟをﾊﾟｽする
                        '@ - 表面処理装置のﾊﾞｯﾁ情報をJ_BATCHﾃｰﾌﾞﾙに格納した対応の影響として対応
                        '@
                        '@***********************
                        
                        Do While mtypBatLotList.typBatLot(llngCnt).lngBatLotListCnt >= llngDoCnt
                            
                            '@表面処理装置でﾛｯﾄIDが前回値と同じか
                            If lstrTmpLotId = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strLotID And _
                               mtypBatLotList.typBatLot(llngCnt).strEqType = CPstrEqTypeHyoumenSyori Then
                            
                                '何もしない
                            
                            Else
                                
                                'バッチ情報を描画する
                                
                                '@行数設定
                                .Rows.Count = llngRowCnt + 1
                                
                                .SetData(llngRowCnt, CMlngvsfColNo, llngRowCnt)                                   '順序
                                
                                .SetData(llngRowCnt, CMlngvsfColCarrierID _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strCarrierId)                  'ｷｬﾘｱID
            
                                .SetData(llngRowCnt, CMlngvsfColUldCarrierID _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strUldCarrierID)               'ULDｷｬﾘｱID
            
                                .SetData(llngRowCnt, CMlngvsfColLotID _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strLotID)                      'ﾛｯﾄID
            
                                '@ﾛｯﾄIDがNULLか
                                If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strLotID = vbNullString Then
                                    
                                    '@ﾛｯﾄIDがNULLの場合は、ﾀﾞﾐｰ冶具or未使用処理部である為、ｷｬﾘｱID列に"ﾀﾞﾐｰ"or"未使用"をｾｯﾄ
                                    .SetData(llngRowCnt, CMlngvsfColCarrierID, _
                                        mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strWfId)                     'ｷｬﾘｱID(ﾀﾞﾐｰ、未使用処理部用)
                                End If
            
                                .SetData(llngRowCnt, CMlngvsfColStatus _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strCurrentStatusName)          'ﾛｯﾄ状態
                                    
                                .SetData(llngRowCnt, CMlngvsfColFlowClass _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strFlowClass)                  '種別
                                    
                                .SetData(llngRowCnt, CMlngvsfColPDID _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strPdId)                       '機種
                                    
                                .SetData(llngRowCnt, CMlngvsfColOpID _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strOpID)                       '大工程
                                    
                                .SetData(llngRowCnt, CMlngvsfColStepID _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strStepID)                     '小工程
            
                                '@ﾛｯﾄIDがNULL以外か
                                If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strLotID <> vbNullString Then
            
                                    .SetData(llngRowCnt, CMlngvsfColWFID, _
                                        CPstrSharp & Strings.Right$(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strWfId, 2))    'WFID(#+2桁(例：#01))
                                End If
            
                                .SetData(llngRowCnt, CMlngvsfColWFQuantity _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strWFQuantity)                 'WF枚数
            
                                .SetData(llngRowCnt, CMlngvsfColJigID _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strjigId)                      '冶具ID
            
                                .SetData(llngRowCnt, CMlngvsfColS _
                                            , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strSpecialFlag)        '特殊特性
                                    
                                '@-----------------------
                                '@ 時間制約有無の表示
                                '@-----------------------
                                If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strLimitTime <> vbNullString Then
                                    
                                    '@時間制約がﾌﾟﾗｽの場合
                                    If CLng(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strLimitTime) >= 0 Then
                                        
                                        '@制限時間以下or処理時間制限以下の場合
                                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                                        If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                            mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strRestrictTypeID = CPstrRestrictTypeID3 Then
            
                                            '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                            '@制限時間を時間と分で分割表示する
                                            lstrLimitTimeAns = pubstrLimitTime_Set(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strLimitTime)
                                            .SetData(llngRowCnt, CMlngvsfColTimeLimit, lstrLimitTimeAns)
                                            
                                            '@警告時間が設定されている場合
                                            If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strWarnTime <> vbNullString Then
                                                
                                                '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                                If CLng(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strWarnTime) < 0 And _
                                                    CLng(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strLimitTime) >= 0 Then
                                                    
                                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                                    newStyle = .Styles.Add("CustomStyle_ForeColor_CPlngVbColorPurple" & llngDoCnt.ToString)
                                                    newStyle.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)
                                                    cellRange = .GetCellRange(llngRowCnt, CMlngvsfColTimeLimit, llngRowCnt, CMlngvsfColTimeLimit)
                                                    cellRange.Style = newStyle
                                                Else
                                                    '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                                    newStyle = .Styles.Add("CustomStyle_ForeColor_CPlngVbColorBlack" & llngDoCnt.ToString)
                                                    newStyle.ForeColor = SystemColors.WindowText
                                                    cellRange = .GetCellRange(llngRowCnt, CMlngvsfColTimeLimit, llngRowCnt, CMlngvsfColTimeLimit)
                                                    cellRange.Style = newStyle
                                                End If
                                            End If
                                        End If
            
                                    Else
                                        '@制限時間がﾏｲﾅｽの場合
                                        
                                        '@ﾌｫﾝﾄｶﾗｰを赤に変更
                                        newStyle = .Styles.Add("CustomStyle_ForeColor_CPlngVbColorRed" & llngDoCnt.ToString)
                                        newStyle.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                                        cellRange = .GetCellRange(llngRowCnt, CMlngvsfColTimeLimit, llngRowCnt, CMlngvsfColTimeLimit)
                                        cellRange.Style = newStyle
                                        
                                        '@制限時間以下or処理時間制限以下の場合
                                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                                        If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                            mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strRestrictTypeID = CPstrRestrictTypeID3 Then
                                            
                                            '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                            '@制限時間を時間と分で分割表示する
                                            lstrLimitTimeAns = pubstrLimitTime_Set(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strLimitTime)
                                            .SetData(llngRowCnt, CMlngvsfColTimeLimit, lstrLimitTimeAns)
                                        End If
                                        
                                        '@制限時間以上の場合
                                        If mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strRestrictTypeID = CPstrRestrictTypeID2 Then
                                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,##0)+"分"
                                            
                                            '@制限時間を時間と分で分割表示する
                                            lstrLimitTimeAns = pubstrLimitTime_Set(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strLimitTime)
                                            .SetData(llngRowCnt, CMlngvsfColTimeLimit, Replace(lstrLimitTimeAns, CPstrReplaceMinus, vbNullString))
                                        End If
                                    End If
                                End If
                                
                                .SetData(llngRowCnt, CMlngvsfColLotManager _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strEngEmpName)                 'ﾛｯﾄ担当
                                    
                                '処理開始予定日時
                                Dim strDateTmp As String = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strStartTime
                                If IsDate(strDateTmp) Then
                                    .SetData(llngRowCnt, CMlngvsfColStartDayTime, Format$(strDateTmp, CPstrDateFormat))
                                Else
                                    .SetData(llngRowCnt, CMlngvsfColStartDayTime, strDateTmp)
                                End If
                                
                                .SetData(llngRowCnt, CMlngvsfColRealTimeLimit _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strLimitTime)                  '時間制限(実数)
                                
                                .SetData(llngRowCnt, CMlngvsfColRestrictTypeID _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strRestrictTypeID)             '制限時間ﾀｲﾌﾟID
                                    
                                '@ｺﾒﾝﾄ取得前に初期化
                                ltypLotComntInfo.strComments = vbNullString
                                ltypLotComntInfo.strLotLastUpdate = vbNullString
            
                                '@-----------------------
                                '@ ﾀﾞﾐｰ冶具、未使用処理部はﾛｯﾄｺﾒﾝﾄ取得を行わない
                                '@-----------------------
            
                                '@ﾛｯﾄIDがNULL以外か
                                If .GetData(llngRowCnt, CMlngvsfColLotID) <> vbNullString Then
            
                                    '@検索用にﾛｯﾄIDを退避(長いので)
                                    lstrSearchLotID = .GetData(llngRowCnt, CMlngvsfColLotID)
                                    
                                    '@情報取得済みﾛｯﾄIDではないか
                                    If InStr(1, lstrInfoGetCompLotID, lstrSearchLotID) = 0 Then
            
                                        '@=======================
                                        '@ ﾛｯﾄｺﾒﾝﾄ取得処理
                                        '@=======================
                                        lblnAns = pubblnlotComntInfo_Sel(mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strCarrierId, _
                                                                         CMstrlot_comntinfo_Ver, _
                                                                         ltypLotComntInfo)
                
                                        '@ﾛｯﾄｺﾒﾝﾄ取得処理結果が"True：通信成功"か
                                        If lblnAns = True Then
                                            '@True：通信成功の場合
                                        
                                            .SetData(llngRowCnt, CMlngvsfColLotComment, _
                                                ltypLotComntInfo.strComments)                                    'ﾛｯﾄｺﾒﾝﾄ：取得値
                                        Else
                                            .SetData(llngRowCnt, CMlngvsfColLotComment, _
                                                vbNullString)                                                    'ﾛｯﾄｺﾒﾝﾄ：NULL
                                        End If
                                        
                                        '@ﾛｯﾄ数を+1する
                                        llngLotCnt = llngLotCnt + 1
                                    Else
                                        '@取得済みﾛｯﾄの場合
                                        
                                        For llngCnt2 = 1 To .Rows.Count - 1
                                            
                                            '@ﾛｯﾄIDが同じか
                                            If .GetData(llngRowCnt, CMlngvsfColLotID) = _
                                                .GetData(llngCnt2, CMlngvsfColLotID) Then
                                            
                                                '@同じﾛｯﾄIDの取得済みﾛｯﾄｺﾒﾝﾄをｺﾋﾟｰ
                                                .SetData(llngRowCnt, CMlngvsfColLotComment, _
                                                    .GetData(llngCnt2, CMlngvsfColLotComment))
                                                
                                                Exit For
                                            End If
                                        Next llngCnt2
                                    End If
                                    
                                    '@情報取得済みﾛｯﾄIDに情報取得したﾛｯﾄIDを退避(結合して格納していく)
                                    lstrInfoGetCompLotID = lstrInfoGetCompLotID & CPstrSpace & _
                                                            .GetData(llngRowCnt, CMlngvsfColLotID)
                                    
                                Else
                                    '@ﾛｯﾄIDがNULLの場合(ﾀﾞﾐｰ冶具or未使用処理部)
                                
                                    .SetData(llngRowCnt, CMlngvsfColLotComment, vbNullString)      'ﾛｯﾄｺﾒﾝﾄ：NULL
                                End If
                                
                                .SetData(llngRowCnt, CMlngvsfColLastUpdate _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strLotLastUpdate)              '最終更新日時
                                
                                .SetData(llngRowCnt, CMlngvsfColOptionText _
                                    , mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strOptionText)                 '作業条件
                
                                '@ｽﾛｯﾄの高さの設定
                                .Rows(llngRowCnt).Height = CMlngVsfHeight
                                
                                '@行ｶｳﾝﾄ+1
                                llngRowCnt = llngRowCnt + 1
                                
                            End If
                            
                            '@前回値としてﾛｯﾄID退避
                            lstrTmpLotId = mtypBatLotList.typBatLot(llngCnt).typBatList(llngDoCnt - 1).strLotID
                            
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngDoCnt = llngDoCnt + 1
                            
                        Loop
        '@↑2012/03/12 (Mon) 14:20:03 T.Oide **************************************************


                        '@★ 装置ﾀｲﾌﾟにより処理分岐 ★
                        Select Case mtypBatLotList.typBatLot(0).strEqType
                        
                            '@〓 "19：斜方蒸着装置" 〓
                            Case CPstrEqTypeJyoucyaku
                            
                                '@各種表示列の表示/非表示設定
                                .Cols(CMlngvsfColUldCarrierID).Visible = False     'ULDｷｬﾘｱID  ：非表示
                                .Cols(CMlngvsfColWFID).Visible = True              'WFID       ：表示
                                .Cols(CMlngvsfColJigID).Visible = True             '冶具ID     ：表示


                            '@〓 "20：表面処理装置" 〓
                            Case CPstrEqTypeHyoumenSyori
                                
                                '@各種表示列の表示/非表示設定
                                .Cols(CMlngvsfColUldCarrierID).Visible = True      'ULDｷｬﾘｱID  ：表示
                                .Cols(CMlngvsfColWFID).Visible = False             'WFID       ：非表示
                                .Cols(CMlngvsfColJigID).Visible = False            '冶具ID     ：非表示


                            '@〓 その他 〓
                            Case Else
                                
                                '@各種表示列を非表示にする
                                .Cols(CMlngvsfColUldCarrierID).Visible = False     'ULDｷｬﾘｱID
                                .Cols(CMlngvsfColWFID).Visible = False             'WFID
                                .Cols(CMlngvsfColJigID).Visible = False            '冶具ID

                        End Select


                        '@描画開始
                        .Redraw = True
            
                        '@書式設定
                        .Cols(CMlngvsfColNo).TextAlign = TextAlignEnum.RightCenter                  '中央右寄せ
                        .Cols(CMlngvsfColCarrierID).TextAlign = TextAlignEnum.LeftCenter            '中央左寄せ
                        .Cols(CMlngvsfColUldCarrierID).TextAlign = TextAlignEnum.LeftCenter         '中央左寄せ
                        .Cols(CMlngvsfColLotID).TextAlign = TextAlignEnum.LeftCenter                '中央左寄せ
                        .Cols(CMlngvsfColStatus).TextAlign = TextAlignEnum.LeftCenter               '中央左寄せ
                        .Cols(CMlngvsfColFlowClass).TextAlign = TextAlignEnum.LeftCenter            '中央左寄せ
                        .Cols(CMlngvsfColPDID).TextAlign = TextAlignEnum.LeftCenter                 '中央左寄せ
                        .Cols(CMlngvsfColOpID).TextAlign = TextAlignEnum.LeftCenter                 '中央左寄せ
                        .Cols(CMlngvsfColStepID).TextAlign = TextAlignEnum.LeftCenter               '中央左寄せ
                        .Cols(CMlngvsfColWFID).TextAlign = TextAlignEnum.LeftCenter                 '中央右寄せ
                        .Cols(CMlngvsfColWFQuantity).TextAlign = TextAlignEnum.RightCenter          '中央右寄せ
                        .Cols(CMlngvsfColJigID).TextAlign = TextAlignEnum.LeftCenter                '中央左寄せ
                        .Cols(CMlngvsfColS).TextAlign = TextAlignEnum.LeftCenter                    '中央左寄せ
                        .Cols(CMlngvsfColTimeLimit).TextAlign = TextAlignEnum.RightCenter           '中央右寄せ
                        .Cols(CMlngvsfColLotManager).TextAlign = TextAlignEnum.LeftCenter           '中央左寄せ
                        .Cols(CMlngvsfColStartDayTime).TextAlign = TextAlignEnum.LeftCenter         '中央左寄せ
                        .Cols(CMlngvsfColLotComment).TextAlign = TextAlignEnum.LeftCenter           '中央左寄せ
                        .Cols(CMlngvsfColLastUpdate).TextAlign = TextAlignEnum.LeftCenter           '中央左寄せ
                        .Cols(CMlngvsfColOptionText).TextAlign = TextAlignEnum.LeftCenter           '中央左寄せ
            
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCol(CMlngvsfColNo, 6)                                              '順序
                        .AutoSizeCol(CMlngvsfColCarrierID, 6)                                       'ｷｬﾘｱID
                        .AutoSizeCol(CMlngvsfColUldCarrierID, 6)                                    'ULDｷｬﾘｱID
                        .AutoSizeCol(CMlngvsfColLotID, 6)                                           'ﾛｯﾄID
                        .AutoSizeCol(CMlngvsfColStatus, 6)                                          'ﾛｯﾄ状態
                        .AutoSizeCol(CMlngvsfColFlowClass, 6)                                       '流動区分
                        .AutoSizeCol(CMlngvsfColPDID, 6)                                            '機種
                        .AutoSizeCol(CMlngvsfColOpID, 6)                                            '大工程
                        .AutoSizeCol(CMlngvsfColStepID, 6)                                          '小工程
                        .AutoSizeCol(CMlngvsfColWFID, 6)                                            'WFID(#+2桁(例：#01))
                        .AutoSizeCol(CMlngvsfColWFQuantity, 6)                                      'WF枚数
                        .AutoSizeCol(CMlngvsfColJigID, 6)                                           '冶具ID
                        .AutoSizeCol(CMlngvsfColS, 6)                                               '特殊特性
                        .AutoSizeCol(CMlngvsfColTimeLimit, 6)                                       '時間制約
                        .AutoSizeCol(CMlngvsfColLotManager, 6)                                      'ﾛｯﾄ担当
                        .AutoSizeCol(CMlngvsfColStartDayTime, 6)                                    '処理開始予定日時
                        .AutoSizeCol(CMlngvsfColLotComment, 6)                                      'ﾛｯﾄｺﾒﾝﾄ
                        .AutoSizeCol(CMlngvsfColLastUpdate, 6)                                      '最終更新日時
                        .AutoSizeCol(CMlngvsfColOptionText, 6)                                      '作業条件
                        
                        '@非表示設定
                        .Cols(CMlngvsfColRealTimeLimit).Visible = False                             '時間制限(実数)
                        .Cols(CMlngvsfColRestrictTypeID).Visible = False                            '制限時間ﾀｲﾌﾟID
                        
                        '@=======================
                        '@ 左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                        '@=======================
                        Call pubCmdLREnable_Set(vsfBatList, cmdLeft, cmdRight)
                        
                    End If
                End If
            End With
            

            '@ﾛｯﾄ数を表示
            lblLotNum.Text = CStr(llngLotCnt)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfBatList_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnCmdRegist_Chk
    '機　能：確定ﾎﾞﾀﾝ制御ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2004/07/23 (Fri) 09:09:13 N.Kasai
    '更新日：2009/07/22 (Wed) 12:29:51 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 10:11:24 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/22 (Wed) 12:29:51 N.Kojima     無機対応Phase2、ﾁｪｯｸ条件からｷｬﾘｱIDを削除。(案件№03661)
    Private Function prvblncmdRegist_Chk() As Boolean

        Dim llngCnt     As Integer  'ｶｳﾝﾄ

        Try

            '@戻り値の初期化
            prvblncmdRegist_Chk = True
            
            With vsfBatList
                
                For llngCnt = 1 To .Rows.Count - 1
                    
        '@↓2009/06/26 (Fri) 11:50:55 N.Kojima **************************************************

        '            '@前処理以外のｽﾃｰﾀｽがあるか
        '            If .Cell(flexcpText, llngCnt, CMlngvsfColStatus) <> CPstrBeforeProgressSt Then
                    '@ﾛｯﾄIDがNULL以外で、かつ前処理以外のｽﾃｰﾀｽか
                    If .GetData(llngCnt, CMlngvsfColLotID) <> vbNullString And _
                        .GetData(llngCnt, CMlngvsfColStatus) <> CPstrBeforeProgressSt Then
                        '@ある場合
                        
                        '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                        prvblncmdRegist_Chk = False
                        Exit For
                    End If
                    
        '@↑2009/06/26 (Fri) 11:50:55 N.Kojima **************************************************
                    
                Next llngCnt
            End With
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblncmdRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnInputInfo_Chk
    '機　能：確定前ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True:OK/False:NG
    '作成日：2004/07/23 (Fri) 09:09:24 N.Kasai
    '更新日：2009/07/22 (Wed) 12:29:51 N.Kojima
    '備　考：
    '　　　：2009/06/26 (Fri) 11:31:29 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/22 (Wed) 12:29:51 N.Kojima     無機対応Phase2、ﾁｪｯｸ条件からｷｬﾘｱIDを削除。(案件№03661)
    Private Function prvblnInputInfo_Chk() As Boolean

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ

        Try
            
            '@戻り値の初期化
            prvblnInputInfo_Chk = False

            '@ﾊﾞｯﾁIDがNULLか
            If lblBatID.Text = vbNullString Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM0JW>$$バッチIDが存在しません。設定を見直して下さい。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000J)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Function
            End If
            
            '@ﾛｯﾄID/最終更新日時ﾁｪｯｸ
            With vsfBatList
                
                For llngCnt = 1 To .Rows.Count - 1
                
        '@↓2009/06/26 (Fri) 11:35:47 N.Kojima **************************************************

                    '@ﾛｯﾄIDがNULL以外(ﾀﾞﾐｰ冶具 or 未使用処理部以外)か
                    If .GetData(llngCnt, CMlngvsfColLotID) <> vbNullString Then
                    
                        '@最終更新日時ﾁｪｯｸ
                        If .GetData(llngCnt, CMlngvsfColLastUpdate) = vbNullString Then
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM0LW>$$バッチ組みされているロットの最終更新日時が存在しません。設定を見直して下さい。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000L)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Function
                        End If
                    Else
                        '@ﾛｯﾄIDがNULLの場合

                        '@ﾀﾞﾐｰ冶具以外、かつ未使用処理部以外か
                        If .GetData(llngCnt, CMlngvsfColCarrierID) <> CPstrDummyJig And _
                            InStr(1, .GetData(llngCnt, CMlngvsfColCarrierID), CPstrNotUse) = 0 Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM0KW>$$バッチ組みされているロットIDが存在しません。設定を見直して下さい。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000K)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Function
                        End If
                    End If
                    
        '@↑2009/06/26 (Fri) 11:35:47 N.Kojima **************************************************
                    
                Next llngCnt
            End With
            
            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblnInputInfo_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInputInfo_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfBatList.BeforeDoubleClick

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
