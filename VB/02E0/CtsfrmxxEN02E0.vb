'ﾌｧｲﾙ名：xxEN02E0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：MKロット編成　メインフォーム
'作成日：2009/05/19 (Tue) 17:22:00 T.Oide
'更新日：2014/11/21 (Fri) 19:29:45 T.Oide
'備　考：ｼｽﾃﾑﾌﾞﾛｯｸは、「2AO」を使用する
'　　　：2009/05/19　CFロット編成をベースに作成
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02E0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02E0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02E0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02E0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02E0)
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
    '@↓2020/03/06 (Fri) 12:46:22 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion                     As String = "01.03"
    Private Const CMstrLocalVersion                     As String = "01.04"
    '@↑2020/03/06 (Fri) 12:46:22 Y.Yoneyama 「.Netへ反映未」 **************************************************
    
    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN02E0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrcarrcurstateVer                  As String = "05.02"                 'ｷｬﾘｱ状態確認
    '@↓2020/01/15 (Wed) 14:06:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer                  As String = "03.04"                 'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer                  As String = "04.00"                 'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:06:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
    '@↓2010/06/17 (Thu) 19:36:49 Y.Yoneyama **************************************************
    Private Const CMstrlot_waferlistVer                 As String = "02.05"                 'ﾛｯﾄWF情報取得
    '@↑2010/06/17 (Thu) 19:36:49 Y.Yoneyama **************************************************
    Private Const CMstrlot_cfchipmoveVer                As String = "01.00"                 'CF移載情報
    Private Const CMstrlot_cfchipmoveinfoVer            As String = "01.00"                 'CF移載情報参照
    Private Const CMstrjig_usechkVer                    As String = "01.00"                 '治具使用可否判定
    '@vsfSlotMapの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfSlotMapColSlot                As Integer = 0                      'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
    Private Const CMlngvsfSlotMapColWFID                As Integer = 1                      'WF_ID
    Private Const CMlngvsfSlotMapColJigId               As Integer = 2                      '治具ID
    Private Const CMlngvsfSlotMapColReserveJigId        As Integer = 3                      '変更前治具ID
    '@vsfSlotMapの定数宣言(幅)
    Private Const CMlngvsfSlotMapColWSlot               As Integer = 33                     '№
    Private Const CMlngvsfSlotMapColWWFID               As Integer = 96                     'WF_ID
    Private Const CMlngvsfSlotMapColWJigId              As Integer = 96                     '治具ID
    Private Const CMlngvsfSlotMapColWReserveJigId       As Integer = 96                     '変更前治具ID
    '@vsfSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfSlotMapColSlot                As String = ""                      'ｽﾛｯﾄ№(空白)
    Private Const CMstrvsfSlotMapColWFID                As String = "WF_ID"                 'WF_ID(非表示)
    Private Const CMstrvsfSlotMapColJigId               As String = "治具ID"                '治具ID
    Private Const CMstrvsfSlotMapColReserveJigId        As String = "変更前治具ID"          '変更前治具ID(非表示)
    '@↓2009/09/11 (Fri) 16:31:08 T.Oide **************************************************
    '@その他
    Private Const CMstrNoInputString                    As String = "'"                     '禁則文字："'"
    '@↑2009/09/11 (Fri) 16:31:08 T.Oide **************************************************
    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                      As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                      As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                     As Integer = 12                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                       As Integer = 26                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                        As Integer = 38                     '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfPartMaxRow                    As Integer = 16                     '部材一覧最大行(ﾀｲﾄﾙ含む)
    Private Const CMvsfSlotMapVisibleRows               As Integer = 10                     '1ﾍﾟｰｼﾞ表示行数
    Private Const CMvsfSlotMapRowS                      As Integer = 6                      '行数
    Private Const CMvsfSlotMapSTopRow                   As Integer = 16                     '初期表示行番号
    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols1                     As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbDispCols2                     As Integer = 2                      'ｸﾞﾘｯﾄﾞ表示列数=2
    Private Const CMlngCmbValueCol1                     As Integer = 1                      '値取得個数=1
    Private Const CMlngCmbValueCol2                     As Integer = 2                      '値取得個数=2
    Private Const CMlngCmbValueCol3                     As Integer = 3                      '値取得個数=3
    Private Const CMlngCmbRowHeight                     As Integer = 18                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                      As Integer = 0                      '名称列番=0
    Private Const CMlngCmbGridCol1                      As Integer = 1                      '名称列番=1
    Private Const CMlngCmbGroupCol                      As Integer = 2                      'ｸﾞﾙｰﾌﾟCol
    Private Const CMlngCmbGroupRow                      As Integer = 0                      'ｸﾞﾙｰﾌﾟRow
    Private Const CMlngCmbGetCol5                       As Integer = 5                        'ﾊﾞｯｸｶﾗｰ格納Col

    Private Const CMstrNothing                          As String = "Nothing"               'Nothing
    Private Const CMlngOCSlotSize                       As Integer = 14                     'ｵｰﾌﾟﾝｶｾｯﾄのｽﾛｯﾄｻｲｽﾞ+1
    Private Const CMlngJCSlotSize                       As Integer = 6                      '蒸着ｶｾｯﾄのｽﾛｯﾄｻｲｽﾞ+1
    '@↓2009/09/11 (Fri) 14:54:22 T.Oide **************************************************
    Private Const CMlngJigLength                        As Integer = 10                     '治具IDの桁数
    Private Const CMlngStartSize                        As Integer = 1                      '画面初期状態(ﾀｲﾄﾙのみ)
    '@↑2009/09/11 (Fri) 14:54:22 T.Oide **************************************************

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mtypScreenSizeList                          As ScreenSizeList                   'ｽｸﾘｰﾝｻｲｽﾞ格納変数
    Private mtypLotCurState                             As Lotprestate                      'ﾛｯﾄ情報格納構造体
    Private mstrCarrierID                               As String                           'ｷｬﾘｱID退避
    Private mstrCarrierID2                              As String                           'ｷｬﾘｱID退避
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用
    Private mblnFormLoadFlag                            As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:処理なし/False:処理実行)
    Private mblnEnabled                                 As String                           'ﾛｯｸﾌﾗｸﾞ(True：ﾛｯｸ解除、False：ﾛｯｸ)
    Private mlngVsfBottomRow                            As Integer                          '画面の一番下の行(WF№01の行)
    Private mblnvsfSlotMap2Set                          As Boolean                          'ｽﾛｯﾄﾏｯﾌﾟ2のｾｯﾄ完了ﾌﾗｸﾞ
    Private mblntxtCarrierID1ValidateStop               As Boolean                          'ｷｬﾘｱID1のﾊﾞﾘﾃﾞｰﾄｲﾍﾞﾝﾄを止める
    Private mblntxtCarrierID2ValidateStop               As Boolean                          'ｷｬﾘｱID2のﾊﾞﾘﾃﾞｰﾄｲﾍﾞﾝﾄを止める
    Private mblngetCFmoveInfo                           As Boolean                          'CF移載情報取得ﾌﾗｸﾞ
    Private mblnTakeOverDispFlg                         As Boolean                          '引継ぎ表示ﾌﾗｸﾞ
    '@↓2009/07/31 (Fri) 09:22:34 T.Oide **************************************************
    Private mlngEditRow                                 As Integer                          '移載後ｽﾛｯﾄﾏｯﾌﾟの変更中行
    '@↑2009/07/31 (Fri) 09:22:34 T.Oide **************************************************
    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ
    Private mstrOldGridEditorText                       As String                           'NSYS グリッドの編集前文字列
    Private mblnMouseDrag                               As Boolean                          'NSYS マウスドラッグの場合 True
    Private mblnDoubleClickOn                           As Boolean                          'NSYS マウスダブルクリックの場合 True
    Private mblnMouseCancelFlag                         As Boolean                          'NSYS ﾏｳｽｷｬﾝｾﾙﾌﾗｸﾞ

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
        mblnMouseDrag = False

        Form_Load()

        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfSlotMap1, cmdUp1, cmdDown1)
        pubVsfMouseWheelManager_Set(vsfSlotMap2, cmdUp2, cmdDown2)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：Form_Load
    '機　能：初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：20042009/05/19 (Tue) T.Oide
    '更新日：
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02E0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@Private変数等の初期化
            Call prvfrmxxEN02C0_Minit()
            
            '@画面情報の初期化
            Call prvfrmxxEN02E0_Init()
            
            '@構造体の初期化(ｿｰﾄ)
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            'CF移載情報取得ﾌﾗｸﾞﾘｾｯﾄ
            mblngetCFmoveInfo = False
            
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
    '機　能：
    '引　数：KeyCode：
    '　　　：Shift：
    '戻り値：
    '作成日：2009/06/08 (Mon) 18:32:43 T.Oide
    '更新日：2009/09/15 (Tue) 13:20:46 T.Oide
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
            '@以下の条件の場合、ｷｰｺｰﾄﾞを初期化し処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            'Call pubVsf_KeyDown(KeyCode, ActiveControl.Name, vsfWP, cmdUp, cmdDown)
            
            '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
            Select Case e.KeyCode
            
                '@〓 Enterｷｰ 〓
                Case Keys.Return
                
                    '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                    Select Case ActiveControl.Name
                    
                        '@〓〓 ｷｬﾘｱID 〓〓
                        Case txtCarrierID1.Name
                            
                            SendKeys.SendWait(CPstrSendKeysTab)
                            '@情報を取得して明細を表示する
                            'Call txtCarrierID1_Validate(False)
                            'NSYS 移載数量がフォーカス状態ではあるが範囲選択状態にならないため明示的にフォーカスセットする※ただしValidate実行されないようにする
                            If ActiveControl.Name = txtMoveNum.Name Then
                                RemoveHandler txtCarrierID1.Validating,AddressOf txtCarrierID1_Validate
                                Call pubSetFocus(txtMoveNum)
                                AddHandler txtCarrierID1.Validating,AddressOf txtCarrierID1_Validate
                            End If
                            e.Handled = True
                                        
                        '@〓〓 UnloaderｷｬﾘｱID 〓〓
                        Case txtCarrierID2.Name
                        
                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱValidateへ
                            'Call txtCarrierID2_Validate(False)
                            e.Handled = True
                        
                        '@〓〓 移載数量 〓〓
                        'Case txtMoveNum.Name
                        
                            '@合計を計算
                            'Call txtMoveNum_Validate(False)
                            '@確定ﾎﾞﾀﾝの有効無効ﾁｪｯｸ
                            'Call prvFrmxxCM02E0_CmbInit(False)
                                                
                        '@〓〓 その他 〓〓
                        Case Else
                            If ActiveControl IsNot vsfSlotMap2.Editor Then
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            End If
                    End Select
                
        '@↓2009/09/15 (Tue) 12:57:11 T.Oide **************************************************
                '@〓 Deleteｷｰ 〓
                Case Keys.Delete
                    
                    '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                    Select Case ActiveControl.Name
                        
                        '@〓〓 移載後ｽﾛｯﾄﾏｯﾌﾟ 〓〓
                        Case vsfSlotMap2.Name
                        
                            With vsfSlotMap2
                            
                                '@ﾀｲﾄﾙ行以外で治具ID列であれば削除
                                If .Row <> CMlngVsfRowTitle And .Col = CMlngvsfSlotMapColJigId Then
                                    .SetData(.Row, .Col, vbNullString)
                                End If
                                
                            End With
                    
                    End Select
        '@↑2009/09/15 (Tue) 12:57:11 T.Oide **************************************************
                Case Keys.F2
                    Select Case ActiveControl.Name
                        '@〓〓 移載後ｽﾛｯﾄﾏｯﾌﾟ 〓〓
                        Case vsfSlotMap2.Name
                            With vsfSlotMap2
                                '@ﾀｲﾄﾙ行以外で治具ID列であれば削除
                                If .Row <> CMlngVsfRowTitle And .Col = CMlngvsfSlotMapColJigId Then
                                    .Styles.Editor.BackColor = SystemColors.Window
                                    .Styles.Editor.ForeColor = SystemColors.WindowText
                                    .StartEditing()
                                     e.SuppressKeyPress = True
                                End If
                            End With
                    End Select
                    
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02E0        '機能ID
                .strProcName = "Form_KeyDown"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:25:21 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            '@ﾌｫｰﾑﾛｰﾄﾞ時のみ行う処理
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞ変更
                mblnFormLoadFlag = True
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
            End If
            
            '@引継ぎ情報表示済みﾌﾗｸﾞにTrueを設定する
            mblnTakeOverDispFlg = True
            
            '@引数のキャリアIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合

                'NSYS 表示情報を最適化
                Me.Refresh

                '@キャリアIDの初期値を設定する
                txtCarrierID1.Text = ptypCommonInfo.strCarrierId
                    
                '@ｷｬﾘｱ情報の取得
                SendKeys.SendWait(CPstrSendKeysTab)

                'NSYS 移載数量がフォーカス状態ではあるが範囲選択状態にならないため明示的にフォーカスセットする※ただしValidate実行されないようにする
                If ActiveControl.Name = txtMoveNum.Name Then
                    RemoveHandler txtCarrierID1.Validating,AddressOf txtCarrierID1_Validate
                    Call pubSetFocus(txtMoveNum)
                    AddHandler txtCarrierID1.Validating,AddressOf txtCarrierID1_Validate
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:26:53 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@Private変数等の初期化
            Call prvfrmxxEN02C0_Minit()
            
            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                lblnAnsTerm = pubblnAct_Term
                If lblnAnsTerm = True Then
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                If pblnfrmxxEN02E0kbn = False Then
                    '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                    Call pubMenuExpand_Disp()
                End If
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

    '関数名：cmdCarrierSelect_Click
    '機　能：空きｷｬﾘｱ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:30:06 T.Oide
    '更新日：
    '備　考：
    '　　　：
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
            
            '@Form_Loadﾌﾗｸﾞ
            pblnFormLoad = False
            
            '@ｷｬﾘｱﾀｲﾌﾟID引渡し
            pstrCarrierTypeID = CPstrCarrTypeHotOP  '(耐熱ｵｰﾌﾟﾝｶｾｯﾄ)
            
            '@ｷｬﾘｱの洗浄条件：未洗浄可
            pstrCleanCondition = CPstrCarrierClean1
            
            '@空きｷｬﾘｱ一覧表示
            frmxxCM00K0.Instance = New frmxxCM00K0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00K0.Instance = Nothing
                Exit Sub
            End If
            
            '@空きｷｬﾘｱ一覧表示
            frmxxCM00K0.Instance.ShowDialog(Me)
            frmxxCM00K0.Instance = Nothing
            
            '@空きｷｬﾘｱが選択されている場合
            If pstrCarrierID <> vbNullString Then
                '@ｷｬﾘｱIDをｾｯﾄ
                txtCarrierID2.Text = pstrCarrierID
            End If
            
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID
            
            '@vsfSlotMap2を有効にする
            vsfSlotMap2.Enabled = True
            vsfSlotMap2.AllowEditing = True
            
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

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:32:21 T.Oide
    '更新日：
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim llngRet         As Integer
        Dim ltypCommonInfo  As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@======================================================================================
            '@ 当Functionの処理概要
            '@　①起動区分別終了処理(子画面起動:呼び元画面への戻り処理、単独起動:終了処理)
            '@======================================================================================
            
            '@以下の条件の場合、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②DoEventsﾌﾗｸﾞor読込中ﾌﾗｸﾞが立っている場合
            If Cursor.Current = Cursors.WaitCursor Or _
                pblnTrnFlag = True Then
                
                Exit Sub
            End If
            
            '@最終更新日時書換え
            'ptypLotprestate.strLotLastUpdate = mstrLotLastUpdate
            
            '@子画面起動か
            'If mblnFormStartKbn = True Then
            
            If pblnfrmxxEN02E0kbn = True Then
                '@子画面起動の場合
            
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                Me.Close()

            Else
                '@単独起動の場合
                
                '@引継ぎ情報のｷｬﾘｱIDがNULL以外か
                If ptypCommonInfo.strCarrierId <> vbNullString Then
                    '@NULL以外の場合
                    
                    '@装置別ﾛｯﾄ一覧から引き継いで起動されたのか
                    If pblnfrmxxEN0150Kbn = True Then
                    
                        '@=======================
                        '@ 装置別ﾛｯﾄ一覧を起動する
                        '@=======================
                        Call pubMenuSelect_Proc(CPstrKeyEN0150)

                    Else
                        '@装置別ﾛｯﾄ一覧以外からの起動
                    
                        '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧から引き継いで起動されたのか
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
                    '@ 終了処理
                    '@=======================
                    llngRet = publngEnd_Proc(CPstrKeyEN02E0, ltypCommonInfo)
                End If
            End If
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞをﾘｾｯﾄする
            mblnFormLoadFlag = False
            
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

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:32:42 T.Oide
    '更新日：
    '備　考：

    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim typcfchipmovejigList    As cfchipmovejigList    '取得結果格納用構造体
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCnt2                As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        
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
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@画面ﾃﾞｰﾀを構造体へｾｯﾄする処理記述
            With typcfchipmovejigList
                .strMsgVersion = CMstrlot_cfchipmoveVer
                .strClassDivision = CPstrCD01                   '@01：ｸﾗｲｱﾝﾄからのﾒｯｾｰｼﾞ
                .strLotID = lblLotID.Text
                .strCarrierId = txtCarrierID2.Text
                .strOpID = lblOpID.Text
                .strStepID = lblStepID.Text
                .strBeforMoveNum = lblNum.Text
                .strMoveNum = txtMoveNum.Text
                .strScrapNum = labScrapNum.Text
                .strReworkNum = labScrapNum.Text
                .strEmpID = pstrUserID
                
                'vsfSlotMap2の行分ﾙｰﾌﾟ
                llngCnt2 = 0
                .typcfjigList = New List(Of cfjigList)
                For llngCnt = 1 To vsfSlotMap2.Rows.Count - 1
                    '治具IDの入力があるところだけ構造体に格納
                    If vsfSlotMap2.GetData(llngCnt, CMlngvsfSlotMapColJigId) <> vbNullString Then
                        Dim typcfjigListTmp As cfjigList
                        typcfjigListTmp.strSlotNo = vsfSlotMap2.GetData(llngCnt, CMlngvsfSlotMapColSlot)    'ｽﾛｯﾄ№
                        typcfjigListTmp.strWfId = vsfSlotMap2.GetData(llngCnt, CMlngvsfSlotMapColWFID)      'WF_ID
                        typcfjigListTmp.strjigId = vsfSlotMap2.GetData(llngCnt, CMlngvsfSlotMapColJigId)    '治具ID
                        .typcfjigList.Add(typcfjigListTmp)
                        llngCnt2 = llngCnt2 + 1
                        .lngcfjigListCnt = llngCnt2
                    End If
                Next
            End With
            
            '@ﾒｯｾｰｼﾞ送信関数呼び出し
            lblnAns = pubblnLotCfChipMove_Upd(typcfchipmovejigList)
            
            '@結果判定
            If lblnAns = True Then
                
                '@移載情報登録ﾌﾗｸﾞｾｯﾄ(作業終了での判断用)
                pblnCFMoveDataFlag = True
                '登録結果表示
                '@ﾒｯｾｰｼﾞ表示："<TRM72I>$$CF移載情報を登録しました。キャリア[%1] ロット[%2]""
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0072, txtCarrierID2.Text, lblLotID.Text)
                Call pubVsfInfo_Disp(pstrDMsg)
                
            Else
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
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

    '関数名：txtCarrier1_Change
    '機　能：ｷｬﾘｱIDを消した場合の表示ｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 18:06:10 N.Kasai
    '更新日：2004/04/15 (Thu) 18:06:10
    '備　考：
    Private Sub txtCarrierID1_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID1.Change

        Try
            '@ｷｬﾘｱIDを修正する場合は画面情報をｸﾘｱする

            '@Private変数等の初期化
            Call prvfrmxxEN02C0_Minit()
            
            '@画面情報の初期化
            Call prvfrmxxEN02E0_Init()
            
            '@構造体の初期化(ｿｰﾄ)
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN02E0
                .strProcName = "txtCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID1_Validate
    '機　能：ｷｬﾘｱIDValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：2009/12/14 (Mon) 16:19:16 T.Oide
    '備　考：
    '　　　：
    Private Sub txtCarrierID1_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierID1.Validating

        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypWaferList           As Waferlist            'WFおよびﾁｯﾌﾟ情報格納用構造体
        Dim lblnAnsFWInfo           As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnAnsLot              As Boolean              '結果取得(True:正常,False:異常)
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If mblntxtCarrierID1ValidateStop = True Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrierID1.Text) = vbNullString Then
                'NSYS 自コントロールの場合のみフォーカス処理実施
                If ActiveControl.Name = txtCarrierID1.Name Then
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrierID1.NowByte < txtCarrierID1.ChrMaxByte Then
            
        '@↓2009/12/14 (Mon) 16:18:41 T.Oide **************************************************
                mblntxtCarrierID1ValidateStop = True
        '@↑2009/12/14 (Mon) 16:18:41 T.Oide **************************************************
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                e.Cancel = True

                'NSYS 自コントロールの場合のみフォーカス処理実施
                If ActiveControl.Name = txtCarrierID1.Name Then
                    '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrierID1)
                End If
                
        '@↓2009/12/14 (Mon) 16:18:55 T.Oide **************************************************
                mblntxtCarrierID1ValidateStop = False
        '@↑2009/12/14 (Mon) 16:18:55 T.Oide **************************************************
                
                Exit Sub
            End If
            
            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If Trim(txtCarrierID1.Text) <> vbNullString Then
                '@ﾛｯｸﾌﾗｸﾞ(ﾛｯｸ解除)
                mblnEnabled = True
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                lstrFormName = Me.Name
                lstrEventName = "txtCarrierID1_Validate"
                Call pubResponseStart(lstrFormName, lstrEventName)
                      
                '@ﾛｯﾄ情報構造体の初期化
                mtypLotCurState.strSteplist = New List(Of StepList)
                
                '@ﾛｯﾄ情報の取得
                mblntxtCarrierID1ValidateStop = True
                lblnAnsLot = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                   CPstrCD4L, _
                                                   txtCarrierID1.Text, _
                                                   mtypLotCurState)
                mblntxtCarrierID1ValidateStop = False
                '@結果判定
                If lblnAnsLot = True Then
                            
                    '@ﾛｯﾄ情報取得OKなら続けてｳｪﾊｰ情報取得
                    '@【WF情報取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAnsFWInfo = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                                           txtCarrierID1.Text, _
                                                           CPstrCD4H, _
                                                           ltypWaferList)

                    '@通信結果判定(ｳｪﾊｰ情報も取得OKなら画面に表示)
                    If lblnAnsFWInfo = True Then
                        
                        '@ｽﾛｯﾄｻｲｽﾞを退避
                        mlngVsfBottomRow = ltypWaferList.strSlotSize + 1
                        '@ｽﾛｯﾄｻｲｽﾞによりｸﾞﾘｯﾄﾞ初期化
                        Call prvvsfSlotMap_init(vsfSlotMap1, mlngVsfBottomRow)
                        
                                        
                        '@ﾛｯﾄの状態が「後処理」の場合は移載前ｷｬﾘｱIDを無効にして、ｷｬﾘｱIDを移載後に移す
                        If mtypLotCurState.strNowST = CPstrAfterProgressSt Then
                            '@ｲﾈｰﾌﾞﾙをFalseにするとValidateｲﾍﾞﾝﾄが起きるので抑止する
                            mblntxtCarrierID1ValidateStop = True
                            txtCarrierID1.Enabled = False
                            mblntxtCarrierID1ValidateStop = False
                            txtCarrierID2.Text = mstrCarrierID
                            
                            '移載前のｷｬﾘｱのｽﾛｯﾄ数設定
                            If mtypLotCurState.strEqType = CPstrEQ_TYPE_MoveB Then
                                '移載Bなら蒸着ｷｬﾘｱなので5段
                                vsfSlotMap1.Rows.Count = CMlngJCSlotSize
                                Call prvvsfSlotMap_init(vsfSlotMap1, CMlngJCSlotSize)
                            Else
                                '移載機CならOCなので13段
                                vsfSlotMap1.Rows.Count = CMlngOCSlotSize
                                 Call prvvsfSlotMap_init(vsfSlotMap1, CMlngOCSlotSize)
                            End If
                            
                        End If
                        
                        '@取得結果を画面に表示
                        Call prvLotInfo_Disp(mtypLotCurState, ltypWaferList)
                                    
                        '@各種ﾎﾞﾀﾝ制御処理
                        Call prvFrmxxCM02E0_CmbInit(False)
                        
                        '@ｷｬﾘｱｶﾃｺﾞﾘを変数に格納
                        pstrCarrierCategoryID = mtypLotCurState.strCarrierCategoryId
                        
                    Else
                        '@結果：異常の場合
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        '@子画面起動か
                        If pblnfrmxxEN02E0kbn = True Then
                            '@Form_Loadﾌﾗｸﾞに"False:起動失敗"をｾｯﾄ
                            pblnFormLoad = False
                        End If
                                        
                        Exit Sub
                    End If
                    
                Else
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    Exit Sub
                End If
                    
                '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                mstrCarrierID = txtCarrierID1.Text
                
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
            End If
            
            '@vsfSlotMap2のRowsをOC用に設定し初期化
            Call prvvsfSlotMap_init(vsfSlotMap2, CMlngOCSlotSize)
            
            '@登録済みﾃﾞｰﾀがある場合は表示する
            If mblngetCFmoveInfo = False Then
                Call prvCFMoveInfo_Sel()
            End If
            
            '@ﾌｫｰｶｽの制御
            If lblNum.Text = vbNullString Then
                'NSYS 自コントロールの場合のみフォーカス処理実施
                If ActiveControl.Name = txtCarrierID1.Name Then
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID1ID1_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID2_Validate
    '機　能：
    '引　数：Cancel：
    '戻り値：
    '作成日：2009/06/08 (Mon) 16:15:33 T.Oide
    '更新日：2009/06/08 (Mon) 16:15:33
    '備　考：
    Private Sub txtCarrierID2_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierID2.Validating
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrierID2.Text) = vbNullString Then
                '@vsfSlotMap2を初期化して変更不可にする
                Call prvvsfSlotMap_init(vsfSlotMap2, CMvsfSlotMapRowS)
                vsfSlotMap2.Enabled = False
                vsfSlotMap2.AllowEditing = False
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrierID2.NowByte < txtCarrierID2.ChrMaxByte Then
                '@vsfSlotMap2を初期化して変更不可にする
                Call prvvsfSlotMap_init(vsfSlotMap2, CMvsfSlotMapRowS)
                vsfSlotMap2.Enabled = False
                vsfSlotMap2.AllowEditing = False
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                e.Cancel = True
                
                Exit Sub
            End If
            
        '@    '@前回ｷｬﾘｱIDのﾁｪｯｸ
        '@    If mstrCarrierID2 = txtCarrierID2.Text Then
        '@        '@前回ｷｬﾘｱIDと同じ場合
        '@        Exit Sub
        '@    End If
            
            '@移載情報取得未なら登録済みCF移載情報を取得する
            If mblngetCFmoveInfo = False Then
                Call prvCFMoveInfo_Sel()
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID2_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdUP1_Click
    '機　能：前ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/02 (Tue) 17:04:32 M.Miura
    '更新日：2004/04/13 (Tue) 09:34:03 H.Wajima
    '備　考：
    Private Sub cmdUP1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUP1.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfSlotMap1, cmdUP1, cmdDown1)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '関数名：cmdDown1_Click
    '機　能：次ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/02 (Tue) 09:34:18 M.Miura
    '更新日：2004/04/13 (Tue) 09:33:58 H.Wajima
    '備　考：
    Private Sub cmdDown1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown1.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfSlotMap1, cmdUP1, cmdDown1, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUP2_Click
    '機　能：前ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/02 (Tue) 17:04:32 M.Miura
    '更新日：2004/04/13 (Tue) 09:34:03 H.Wajima
    '備　考：
    Private Sub cmdUp2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS 不要なValidate呼び出しを抑止
            RemoveHandler txtCarrierID1.Validating,AddressOf txtCarrierID1_Validate

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfSlotMap2, cmdUP2, cmdDown2)

            'NSYS 抑止していたValidateを復帰
            AddHandler txtCarrierID1.Validating,AddressOf txtCarrierID1_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '関数名：cmdDown2_Click
    '機　能：次ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/02 (Tue) 09:34:18 M.Miura
    '更新日：2004/04/13 (Tue) 09:33:58 H.Wajima
    '備　考：
    Private Sub cmdDown2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS 不要なValidate呼び出しを抑止
            RemoveHandler txtCarrierID1.Validating,AddressOf txtCarrierID1_Validate

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfSlotMap2, cmdUP2, cmdDown2, False)

            'NSYS 抑止していたValidateを復帰
            AddHandler txtCarrierID1.Validating,AddressOf txtCarrierID1_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：cmdTreatCF_Click
    '機　能：対向基板処置登録画面を呼び出す
    '引　数：なし
    '戻り値：
    '作成日：2009/06/08 (Mon) 13:00:37 T.Oide
    '更新日：2009/06/08 (Mon) 13:00:37
    '備　考：
    Private Sub cmdTreatCF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTreatCF.Click

        Dim lstrTitle           As String               'ﾀｲﾄﾙ
        Dim ltypCfkiRenkeiInfo  As CfkiRenkeiInfo       '初期化用構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体を使用する前に初期化
            ptypCfkiRenkeiInfo = ltypCfkiRenkeiInfo
            
            With ptypCfkiRenkeiInfo
                '@ﾛｯﾄ状態が「後処理」の場合
                If lblStatus.Text = CPstrAfterProgressSt Then
                    '@Unloader側ｷｬﾘｱ
                    .strCarrierId = txtCarrierID2.Text
                Else
                    '@「処理中」の場合
                    '@Loader側ｷｬﾘｱ
                    .strCarrierId = txtCarrierID1.Text
                End If
            End With
            
            '@ﾁｯﾌﾟ数を退避
            If lblNum.Text <> vbNullString Then
                With ptypCfkiRenkeiInfo
                    '@ﾁｯﾌﾟ数を退避
                    .lngChipRemainCount = CLng(lblNum.Text)
                End With
            End If
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@対向基板リワーク不良ﾌｫｰﾑを表示
            pblnfrmxxCM00B0Kbn = True
            
            '@子画面をﾛｰﾄﾞ
            frmxxCM00B0.Instance = New frmxxCM00B0()
                
            '@ﾒﾆｭｰｷｰから機能の関連情報を取得する
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00H0, lstrTitle)
            
            '@対向基板リワーク不良名称設定
            frmxxCM00B0.Instance.Text = lstrTitle
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00B0.Instance = Nothing

                ptypCfkiRenkeiInfo = ltypCfkiRenkeiInfo
                
                '@対向基板処置登録の起動区分を初期化
                pblnfrmxxCM00B0Kbn = False
                
                Exit Sub
            End If
            
            '@画面表示
            frmxxCM00B0.Instance.ShowDialog(Me)
            frmxxCM00B0.Instance = Nothing
            
            '@戻り処理
            If ptypCfkiRenkeiInfo.lngChipScrapCount <> 0 Or _
               ptypCfkiRenkeiInfo.lngChipReworkCount <> 0 Then
                
                '@作業終了画面の最新取得と復元
                '移載情報を取得するためにﾌﾗｸﾞﾘｾｯﾄ
                mblngetCFmoveInfo = False
                Call txtCarrierID1_Validate(sender,New CancelEventArgs())
                            
            Else
                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdClose)
            End If
            
            '@次項目にﾌｫｰｶｽｾｯﾄ
            If txtMoveNum.Enabled = True Then
                Call pubSetFocus(txtMoveNum)
            End If
            
            '@ﾌｫｰﾑ起動区分=False
            pblnfrmxxCM00B0Kbn = False

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTreatCF_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdJigSelect_Click
    '機　能：適切な(使用回数、機種、空)治具のﾘｽﾄを返す
    '引　数：なし
    '戻り値：
    '作成日：2009/06/09 (Tue) 19:57:32 T.Oide
    '更新日：2009/07/28 (Tue) 13:30:19 T.Oide
    '備　考：
    Private Sub cmdJigSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdJigSelect.Click
        
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
            
            '@治具ﾀｲﾌﾟID引渡し
            pstrJigTypeID = CPstrJigTypeHI                                  '平置き治具
            pstrJigStatus = CPstrJigStatusCanUse                            '使用可能
            pstrScreenSizeID = mtypLotCurState.strScreenSize                'ｽｸﾘｰﾝｻｲｽﾞ
            pstrJigCategoryID = mtypLotCurState.strNextCarrierCategoryId    'ｶﾃｺﾞﾘ
            
            '@空き治具一覧表示
            frmxxCM0130.Instance = New frmxxCM0130()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM0130.Instance = Nothing
                Exit Sub
            End If
            
            '@空き治具一覧表示
            frmxxCM0130.Instance.ShowDialog(Me)
            frmxxCM0130.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrJigID <> vbNullString Then
                '@治具IDをｾｯﾄ
                vsfSlotMap2.SetData(vsfSlotMap2.Row, CMlngvsfSlotMapColJigId, pstrJigID)
                '@治具IDの妥当性ﾁｪｯｸ
                Call vsfSlotMap2_AfterEdit(sender,e)
                
            End If
            
            '@治具ID格納変数初期化
            pstrJigID = vbNullString
            
            '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(vsfSlotMap2)
                
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdJigSelect_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdAllClear_Click
    '機　能：画面全ｸﾘｱ
    '引　数：なし
    '戻り値：
    '作成日：2009/06/11 (Thu) 10:59:25 T.Oide
    '更新日：2009/06/11 (Thu) 10:59:25
    '備　考：
    Private Sub cmdAllClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAllClear.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@Private変数等の初期化
            Call prvfrmxxEN02C0_Minit()
            
            '@画面情報の初期化
            Call prvfrmxxEN02E0_Init()
            
            
            '@構造体の初期化(ｿｰﾄ)
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@CF移載情報取得ﾌﾗｸﾞﾘｾｯﾄ
            mblngetCFmoveInfo = False
            
            '@画面初期化
            txtCarrierID1.Text = vbNullString
            Call pubSetFocus(txtCarrierID1)
            mstrCarrierID = vbNullString
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdAllClear_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtMoveNum_Change
    '機　能：ﾎﾞﾀﾝの有効無効をﾁｪｯｸする
    '引　数：なし
    '戻り値：
    '作成日：2009/06/11 (Thu) 13:59:03 T.Oide
    '更新日：2009/06/11 (Thu) 13:59:03
    '備　考：
    Private Sub txtMoveNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtMoveNum.Change

        Try
            '@合計計算
            Call prvCalcSum()
            
            '@確定ﾎﾞﾀﾝの有効無効ﾁｪｯｸ
            Call prvFrmxxCM02E0_CmbInit(False)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMoveNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfSlotMap2_AfterEdit
    '機　能：WF_IDが抜ける対応としてﾊﾞﾘﾃﾞｰﾄを呼ぶ
    '引　数：Row：
    '　　　：Col：
    '戻り値：
    '作成日：2009/06/11 (Thu) 15:58:00 T.Oide
    '更新日：2009/12/14 (Mon) 16:08:45 T.Oide
    '備　考：
    Private Sub vsfSlotMap2_AfterEdit(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap2.AfterEdit
        
        Dim ltypJigChk          As JigCheck         '治具使用可否判定確認Msg
        Dim lstrGuideMsgCode    As String           '返信ﾒｯｾｰｼﾞｺｰﾄﾞ
        Dim lstrGuideMsg        As String           '返信ﾒｯｾｰｼﾞ
        Dim lblnAns2            As Boolean          '結果
        Dim lstrDispGuidMsg     As String           '表示ﾒｯｾｰｼﾞ
        
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@治具が替わっていない場合はﾁｪｯｸはしない
            If vsfSlotMap2.GetData(vsfSlotMap2.Row, CMlngvsfSlotMapColJigId) = _
               vsfSlotMap2.GetData(vsfSlotMap2.Row, CMlngvsfSlotMapColReserveJigId) Or _
               vsfSlotMap2.GetData(vsfSlotMap2.Row, CMlngvsfSlotMapColJigId) = vbNullString Then
               
               '@治具IDの重複ﾁｪｯｸ、確定ﾎﾞﾀﾝの有効/無効制御
               Call vsfSlotMap2_Validate(sender,New CancelEventArgs(True))
               
               Exit Sub
            End If

        '@↓2009/12/14 (Mon) 16:07:38 T.Oide **************************************************
        '@    '@入力された治具IDが10桁以外の場合はｴﾗｰ表示する
        '@    If Len(vsfSlotMap2.Cell(flexcpText, vsfSlotMap2.Row, vsfSlotMap2.Col)) <> 10 Then

            '@入力された治具IDが10桁以外の場合はｴﾗｰ表示する
            If Len(vsfSlotMap2.GetData(vsfSlotMap2.Row, CMlngvsfSlotMapColJigId)) <> CMlngJigLength Then
        '@↑2009/12/14 (Mon) 16:07:38 T.Oide **************************************************

                '@ｴﾗｰMsgを表示(治具IDは10桁で入力してください。)
                lstrDispGuidMsg = CPstrMsgWar0106
                pstrDMsg = pubstrMsgReplace_Set(lstrDispGuidMsg)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                vsfSlotMap2.SetData(vsfSlotMap2.Row, vsfSlotMap2.Col, vbNullString)
                Exit Sub
                
            End If
            
            '@使用する治具のﾏｽﾀｰﾁｪｯｸ(ﾏｽﾀｰに登録済みか使用可能か、適切な治具かをﾁｪｯｸ)
            ltypJigChk.strSbID = pstrSBID
            ltypJigChk.strjigId = vsfSlotMap2.GetData(vsfSlotMap2.Row, CMlngvsfSlotMapColJigId)
            ltypJigChk.strLotID = lblLotID.Text
            ltypJigChk.strOpID = lblOpID.Text
            ltypJigChk.strStepID = lblStepID.Text
            ltypJigChk.strScreenSizeID = vbNullString
            
            lblnAns2 = pubblnJycJigUse_Check(CPstrCD4N, CMstrjig_usechkVer, ltypJigChk, _
                                            lstrGuideMsgCode, lstrGuideMsg)
            If lblnAns2 = True Then
                If lstrGuideMsg <> vbNullString Then
                    
                    '@ﾒｯｾｰｼﾞがあった場合は、ｴﾗｰMsgを表示
                    lstrDispGuidMsg = CPstrStartMsgCode & lstrGuideMsgCode & CPstrEndMsgCode & "$$" & lstrGuideMsg
                    pstrDMsg = pubstrMsgReplace_Set(lstrDispGuidMsg)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                    '@治具IDを削除する
                    vsfSlotMap2.SetData(vsfSlotMap2.Row, CMlngvsfSlotMapColJigId, vbNullString)
                    
                    Exit Sub
                End If
            
            Else
                
                '@治具IDを削除する
                vsfSlotMap2.SetData(vsfSlotMap2.Row, CMlngvsfSlotMapColJigId, vbNullString)
                
            End If
            
            '@治具IDの重複ﾁｪｯｸ、確定ﾎﾞﾀﾝの有効/無効制御
            Call vsfSlotMap2_Validate(sender,New CancelEventArgs(True))

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap2_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap2_BeforeEdit
    '機　能：空き治具選択ボタンを有効/無効にする
    '引　数：Row：
    '　　　：Col：
    '　　　：Cancel：
    '戻り値：
    '作成日：2009/07/23 (Thu) 17:13:48 T.Oide
    '更新日：2009/09/11 (Fri) 16:09:37 T.Oide
    '備　考：
    Private Sub vsfSlotMap2_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfSlotMap2.BeforeEdit

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap2.Rows.Count <= vsfSlotMap2.Rows.Fixed Then
                Return
            End If
            
            '@ﾀｲﾄﾙ行以外を選択した場合空き治具選択ﾎﾞﾀﾝを有効にする
            If vsfSlotMap2.Row > CMlngVsfRowTitle Then
            
                '@空き治具選択ボタンを有効にする
                cmdJigSelect.Enabled = True
            
            Else
                '@空き治具選択ボタンを無効にする
                cmdJigSelect.Enabled = False
            End If
            
        '@↓2009/09/11 (Fri) 16:09:25 T.Oide **************************************************
            'NSYS SetupEditor処理へ変更
            '@治具ID列の場合最大入力桁数は10桁とする
            'If vsfSlotMap2.Col = CMlngvsfSlotMapColJigId Then
            '    vsfSlotMap2.EditMaxLength = CMlngJigLength
            'End If
        '@↑2009/09/11 (Fri) 16:09:25 T.Oide **************************************************
        
        '@↓2009/07/31 (Fri) 09:22:45 T.Oide **************************************************
            '@変更中の行を退避
            mlngEditRow = vsfSlotMap2.Row
        '@↑2009/07/31 (Fri) 09:22:45 T.Oide **************************************************
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap2_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfSlotMap2_EnterCell
    '機　能：ﾀｲﾄﾙ行を選択させない
    '引　数：なし
    '戻り値：
    '作成日：2009/07/23 (Thu) 18:05:02 T.Oide
    '更新日：2009/07/23 (Thu) 18:05:02
    '備　考：
    Private Sub vsfSlotMap2_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap2.EnterCell
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾀｲﾄﾙ行を選択不可にする
            If vsfSlotMap2.Row <= 0 Then
        '@↓2009/07/31 (Fri) 09:23:00 T.Oide **************************************************
                If mlngEditRow <= 0 Then
                    '@ﾀｲﾄﾙ行を選択された場合は一番下の行を強制的に選択状態にする
                    If vsfSlotMap2.Rows.Count - 1 <= 0 Then
                        vsfSlotMap2.Row = - 1
                    Else
                        vsfSlotMap2.Row = vsfSlotMap2.Rows.Count - 1
                    End If
                Else
                    vsfSlotMap2.Row = mlngEditRow
                End If
        '@↑2009/07/31 (Fri) 09:23:00 T.Oide **************************************************
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap2_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfSlotMap2_Validate
    '機　能：WF_IDをｸﾞﾘｯﾄﾞにｾｯﾄする
    '引　数：Cancel：
    '戻り値：
    '作成日：2009/06/11 (Thu) 13:22:31 T.Oide
    '更新日：2009/09/25 (Fri) 14:38:16 T.Oide
    '備　考：
    Private Sub vsfSlotMap2_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles vsfSlotMap2.Validating
        
        Dim lngCnt          As Integer
        Dim lngCnt2         As Integer
        Dim strjigId        As String
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            If mblntxtCarrierID2ValidateStop = True Then
                Exit Sub
            End If
            
            '@ｽﾛｯﾄﾏｯﾌﾟｾｯﾄ完了ﾌﾗｸﾞをﾘｾｯﾄ
            mblnvsfSlotMap2Set = False
            
            With vsfSlotMap2
            
                '@グリッドの入力をしたから順に確認
                lngCnt2 = 1
                For lngCnt = 1 To .Rows.Count - 1
                    '@治具IDがｾｯﾄされていればｳｪﾊｰIDを記述
                    If .GetData(.Rows.Count - lngCnt, CMlngvsfSlotMapColJigId) <> vbNullString Then
                        .SetData(.Rows.Count - lngCnt, CMlngvsfSlotMapColWFID, lblLotID.Text & Format(lngCnt2,"0#"))
                        lngCnt2 = lngCnt2 + 1
                        mblnvsfSlotMap2Set = True
                    End If
                Next
                
                '@ｸﾞﾘｯﾄﾞの治具ID重複ﾁｪｯｸ
                '@治具IDがｾｯﾄされていれば値を格納
                If .Row > 0 AndAlso .GetData(.Row, CMlngvsfSlotMapColJigId) <> vbNullString Then
                    strjigId = .GetData(.Row, CMlngvsfSlotMapColJigId)
                    
                    '@ｸﾞﾘｯﾄﾞを上から順にﾁｪｯｸ
                    For lngCnt = 1 To .Rows.Count - 1
                
                        '@治具IDが同じか
                        If .GetData(lngCnt, CMlngvsfSlotMapColJigId) = strjigId Then
                            '@自分でなければ重複ありでｴﾗｰ
                            If .Row <> lngCnt Then
                                
                                '@ﾊﾞﾘﾃﾞｰﾄｷｬﾝｾﾙﾌﾗｸﾞ1
                                mblntxtCarrierID2ValidateStop = True
                                '@治具ID重複なのでｴﾗｰ
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009M)
        '@↓2009/09/25 (Fri) 14:36:14 T.Oide **************************************************
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                'Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN02E0.Name, True, 16)
        '@↑2009/09/25 (Fri) 14:36:14 T.Oide **************************************************
                                mblntxtCarrierID2ValidateStop = False
                                '@治具IDを削除
                                .SetData(.Row, CMlngvsfSlotMapColJigId, vbNullString)
                                
                                Exit Sub
                            End If
                        End If
                        
                    Next
                End If
                
            End With
            '@確定ﾎﾞﾀﾝの有効/無効ﾁｪｯｸ
            Call prvFrmxxCM02E0_CmbInit(False)
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap2_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '@↓2009/09/11 (Fri) 16:23:31 T.Oide **************************************************
    '関数名：vsfSlotMap2_ValidateEdit
    '機　能：入力値のﾁｪｯｸ(ﾚｼﾋﾟ値)
    '引　数：Row：行
    '　　　：Col：列
    '　　　：Cancel：
    '戻り値：
    '作成日：2009/09/11 (Fri) 16:23:00 T.Oide
    '更新日：2009/09/11 (Fri) 16:23:00
    '備　考：
    Private Sub vsfSlotMap2_ValidateEdit(ByVal sender As Object, ByVal e As ValidateEditEventArgs) Handles vsfSlotMap2.ValidateEdit
        
        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ
        
        Try
            '@入力値のﾁｪｯｸ
            '@固定行の場合はｽｷｯﾌﾟ
            If vsfSlotMap2.Row < vsfSlotMap2.Rows.Fixed Then
                Exit Sub
            End If

            '@編集項目以外はｽｷｯﾌﾟ
            Select Case vsfSlotMap2.Col
                '@ﾚｼﾋﾟ値列
                Case CMlngvsfSlotMapColJigId
                   
                        '@空白の場合はﾁｪｯｸなし
                        If vsfSlotMap2.Editor.Text = vbNullString Then
                            Exit Sub
                        End If
                        
                        '@入力ﾌｨｰﾙﾄﾞの編集後判定
                        For llngCnt = 1 To Len(vsfSlotMap2.Editor.Text)
                            Select Case Mid(vsfSlotMap2.Editor.Text, llngCnt, 1)
                                Case CMstrNoInputString
                                    '@禁則文字："'"
                                    e.Cancel = True
                                    
                                    Exit For
                                Case Else
                                    '@禁則文字以外
                            End Select
                        Next llngCnt
                        
                        If e.Cancel = False Then
                            vsfSlotMap2.Editor.Text = vsfSlotMap2.Editor.Text
                        Else
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004V, CMstrNoInputString)
                            '@"文字[%1]は入力できません。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            e.Cancel = True
                            
                            Exit Sub
                        End If
                        
            End Select

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "vsfSlotMap2_ValidateEdit"   '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2009/09/11 (Fri) 16:23:31 T.Oide **************************************************

    '関数名：vsfSlotMap2_ChangeEdit
    '機　能：入力値のﾁｪｯｸ(ﾚｼﾋﾟ値)
    '引　数：sender：行
    '　　　：e：列
    '戻り値：
    '作成日：2020/03/05 (Thu) 17:00:00 NSYS
    '更新日：2020/03/05 (Thu) 17:00:00 NSYS
    '備　考：
    Private Sub vsfSlotMap2_ChangeEdit(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap2.ChangeEdit

        Try
            With vsfSlotMap2
            
                Select Case .Col
                    Case CMlngvsfSlotMapColJigId

                        'テキスト長を文字数でなくバイト数で切り詰める
                        '内部で .Editor.Text への代入処理があるので、イベント再帰を回避する
                        RemoveHandler vsfSlotMap2.ChangeEdit, AddressOf vsfSlotMap2_ChangeEdit
                        pubTextBoxLimit_Set(CType(.Editor, TextBox), mstrOldGridEditorText)
                        AddHandler vsfSlotMap2.ChangeEdit, AddressOf vsfSlotMap2_ChangeEdit

                        '@編集前文字列の設定
                        mstrOldGridEditorText = vsfSlotMap2.Editor.Text
                End Select
                    
            End With

            Exit Sub
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "vsfSlotMap2_changeEdit"   '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap2_MouseDown
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ ﾏｳｽﾀﾞｳﾝ処理
    '引　数：Button：未使用
    '　　　：Shift：未使用
    '　　　：X：未使用
    '　　　：Y：未使用
    '戻り値：なし
    '作成日：2020/03/07 (Sat) 09:00:00 NSYS
    '更新日：2020/03/07 (Sat) 09:00:00 NSYS
    '備　考：
    Private Sub vsfSlotMap2_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfSlotMap2.MouseDown

        Try
            mblnMouseDrag = True

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap2.Rows.Count <= vsfSlotMap2.Rows.Fixed Then
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

            '@ﾏｳｽｷｬﾝｾﾙﾌﾗｸﾞにFalseを設定する
            mblnMouseCancelFlag = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap2_MouseDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap2_MouseUp
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ ﾏｳｽｱｯﾌﾟ処理
    '引　数：Button：未使用
    '　　　：Shift：未使用
    '　　　：X：未使用
    '　　　：Y：未使用
    '戻り値：なし
    '作成日：2020/03/07 (Sat) 09:00:00 NSYS
    '更新日：2020/03/07 (Sat) 09:00:00 NSYS
    '備　考：
    Private Sub vsfSlotMap2_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfSlotMap2.MouseUp

        Try
            mblnMouseDrag = False

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap2.Rows.Count <= vsfSlotMap2.Rows.Fixed Then
                Return
            End If

            If mblnDoubleClickOn = True Then
                'NSYS VB6互換動作でダブルクリック時処理を行わない
                Exit Sub
            End If

            '@ﾏｳｽｷｬﾝｾﾙﾌﾗｸﾞの判定
            If mblnMouseCancelFlag = False Then
                '@ﾏｳｽｷｬﾝｾﾙﾌﾗｸﾞにTrueを設定する
                mblnMouseCancelFlag = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap2_MouseUp"
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
'未使用機能NSYS ↓
''関数名：pubVsfCmdUp
''機　能：ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）
''引　数：lobjCmdUp  ：前頁ﾎﾞﾀﾝ
''　　　：lobjCmdDown：次頁ﾎﾞﾀﾝ
''　　　：lobjvsfGri ：ｸﾞﾘｯﾄﾞ
''戻り値：なし
''作成日：2004/03/31 (Wed) 15:28:52 M.Miura
''更新日：2004/03/31 (Wed) 15:28:52
''備　考：ｸﾞﾘｯﾄﾞ前頁ﾎﾞﾀﾝの Click ｲﾍﾞﾝﾄで使用
'Public Sub pubVsfCmdUp(ByVal lobjvsfGrid As Object, _
'                       Optional ByVal lobjcmdUp As Object = Nothing, _
'                       Optional ByVal lobjcmdDown As Object = Nothing)

'    Dim llngRow     As Long     '行
'    Dim llngRows    As Long     '１頁行数
'    Dim lstrTopRow  As String   '前回TopRow
    
'    With lobjvsfGrid
    
'        '@頁切替ﾎﾞﾀﾝがある場合
'        If TypeName(lobjcmdUp) <> CMstrNothing Then
'            '@非表示行を表示
'            For llngRow = .FixedRows To .Rows - 1
'                .RowHidden(llngRow) = False
'            Next llngRow
'        End If
        
'        '@ｸﾞﾘｯﾄﾞの１頁の行数を取得
'        llngRows = publngVsfPageRows_Get(lobjvsfGrid)
        
'        '@前回TopRowを取得
'        lstrTopRow = pubstrVsfTag_Get(lobjvsfGrid, 1)
        
'        If lstrTopRow = vbNullString Then
'            '@前回ｶﾚﾝﾄ行がない場合
'            '@頁先頭行格納
'            lstrTopRow = .TopRow
'        End If
        
'        If lstrTopRow - (llngRows) <= 1 Then
'            '@一覧最上段にﾌｫｰｶｽ
'            llngRow = .FixedRows
'            .TopRow = llngRow
            
'            '@頁切替ﾎﾞﾀﾝがある場合
'            If TypeName(lobjcmdUp) <> CMstrNothing Then
'                '@ﾛｯｸ
'                lobjcmdUp.Enabled = False
'            End If
'        Else
'            '@一覧前頁最上段にﾌｫｰｶｽ
'            llngRow = lstrTopRow - (llngRows)
'            .TopRow = llngRow
'            '@頁切替ﾎﾞﾀﾝがある場合
'            If TypeName(lobjcmdUp) <> CMstrNothing Then
'                '@ﾛｯｸ解除
'                lobjcmdUp.Enabled = True
'            End If
'        End If
        
'        If .Rows <= llngRows + .FixedRows Then
'            '@頁切替ﾎﾞﾀﾝがある場合
'            If TypeName(lobjcmdDown) <> CMstrNothing Then
'                '@ﾛｯｸ
'                lobjcmdDown.Enabled = False
'            End If
'        Else
'            '@頁切替ﾎﾞﾀﾝがある場合
'            If TypeName(lobjcmdDown) <> CMstrNothing Then
'                '@ﾛｯｸ解除
'                lobjcmdDown.Enabled = True
'            End If
'        End If
        
'        '@=======================
'        '@　ﾍﾟｰｼﾞ先頭行格納処理
'        '@=======================
'        Call pubblnVsfTag_Set(lobjvsfGrid, 1, .TopRow)
        
'        '@ﾌｫｰｶｽｾｯﾄ
'        If .Visible = True Then
'            If .Enabled = True Then
'                Call pubSetFocus(lobjvsfGrid)
'            End If
'        End If
        
'    End With
    
'End Sub

''関数名：pubVsfCmdDown
''機　能：ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）
''引　数：lobjCmdUp  ：前頁ﾎﾞﾀﾝ
''　　　：lobjCmdDown：次頁ﾎﾞﾀﾝ
''　　　：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
''戻り値：なし
''作成日：2004/04/01 (Thu) 15:59:43 M.Miura
''更新日：2004/04/01 (Thu) 15:59:43
''備　考：ｸﾞﾘｯﾄﾞ次頁ﾎﾞﾀﾝの Click ｲﾍﾞﾝﾄで使用
'Public Sub pubVsfCmdDown(ByVal lobjvsfGrid As Object, _
'                         Optional ByVal lobjcmdUp As Object = Nothing, _
'                         Optional ByVal lobjcmdDown As Object = Nothing, _
'                         Optional ByVal lblnLastSpace As Boolean = True)

'    Dim llngRow     As Long     '行
'    Dim llngRows    As Long     '１頁行数
'    Dim llngCnt     As Long     'ｶｳﾝﾄ
    
'    With lobjvsfGrid
    
'        '@ｸﾞﾘｯﾄﾞの１頁の行数を取得
'        llngRows = publngVsfPageRows_Get(lobjvsfGrid)
        
'        '@一覧最終頁の場合
'        If .TopRow + llngRows >= .Rows Then
'            '@頁切替ﾎﾞﾀﾝがない場合
'            If TypeName(lobjcmdDown) <> CMstrNothing Then
'                '@ﾛｯｸ
'                lobjcmdDown.Enabled = False
'            End If
            
'            '@ﾌｫｰｶｽｾｯﾄ
'            If .Visible = True Then
'                If .Enabled = True Then
'                    Call pubSetFocus(lobjvsfGrid)
'                End If
'            End If
            
'            Exit Sub
'        End If
        
'        '@一覧最上段にﾌｫｰｶｽ
'        llngRow = .TopRow + (llngRows)
        
'        If llngRow + llngRows >= .Rows Then
'            '@頁切替ﾎﾞﾀﾝがある場合
'            If TypeName(lobjcmdDown) <> CMstrNothing Then
'                '@ﾛｯｸ
'                lobjcmdDown.Enabled = False
'            End If
'        Else
'            '@頁切替ﾎﾞﾀﾝがある場合
'            If TypeName(lobjcmdDown) <> CMstrNothing Then
'                '@ﾛｯｸ解除
'                lobjcmdDown.Enabled = True
'            End If
'        End If
        
'        '@頁切替ﾎﾞﾀﾝがある場合
'        If TypeName(lobjcmdDown) <> CMstrNothing Then
'            If lblnLastSpace = True Then
'                '@非表示
'                For llngCnt = .FixedRows To llngRow - 1
'                    .RowHidden(llngCnt) = True
'                Next llngCnt
'            Else
'                .TopRow = llngRow
'            End If
'        Else
'            .TopRow = llngRow
'        End If
        
'        '@頁切替ﾎﾞﾀﾝがある場合
'        If TypeName(lobjcmdUp) <> CMstrNothing Then
'            If .FixedRows >= .Rows Then
'                '@ﾛｯｸ
'                lobjcmdUp.Enabled = False
'            Else
'                '@頁先頭行が先頭行の場合
'                If .RowHidden(.FixedRows) = True Then
'                    '@ﾛｯｸ解除
'                    lobjcmdUp.Enabled = True
'                Else
'                    If .TopRow = .FixedRows Then
'                        '@ﾛｯｸ
'                        lobjcmdUp.Enabled = False
'                    Else
'                        '@ﾛｯｸ解除
'                        lobjcmdUp.Enabled = True
'                    End If
'                End If
'            End If
'        End If
        
'        '@=======================
'        '@　ﾍﾟｰｼﾞ先頭行格納処理
'        '@=======================
'        Call pubblnVsfTag_Set(lobjvsfGrid, 1, .TopRow)
        
'        '@ﾌｫｰｶｽｾｯﾄ
'        If .Visible = True Then
'            If .Enabled = True Then
'                Call pubSetFocus(lobjvsfGrid)
'            End If
'        End If
        
'    End With
    
'End Sub
'未使用機能NSYS ↑

    '関数名：prvfrmxxEN02E0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub prvfrmxxEN02E0_Init()

        Dim lstrFormTitle   As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02E0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            '@各Cmdの初期化
            Call prvFrmxxCM02E0_CmbInit(True)

            '@Textﾎﾞｯｸｽの初期化
            txtCarrierID1.Enabled = True                        'ｷｬﾘｱID(移載前有効)
            txtCarrierID2.Enabled = False                       'ｷｬﾘｱID(移載後無効)
            txtCarrierID2.Text = vbNullString                   'ｷｬﾘｱID(移載後)
            txtMoveNum.Text = vbNullString                      '移載数量

            '@ﾗﾍﾞﾙの初期化
            lblLotID.Text = vbNullString                     'ﾛｯﾄID
            lblFlowClass.Text = vbNullString                 'ﾌﾛｰｸﾗｽ
            lblStatus.Text = vbNullString                    '状態
            lblPdID.Text = vbNullString                      '機種
            lblOpID.Text = vbNullString                      '大工程
            lblStepID.Text = vbNullString                    '小工程
            lblNum.Text = vbNullString                       '数量
            labReworkNum.Text = vbNullString                 'ﾘﾜｰｸ
            labScrapNum.Text = vbNullString                  '不良
            labSum.Text = vbNullString                       '合計

            '@vsfSlotMapの初期化
        '@↓2009/09/11 (Fri) 14:56:01 T.Oide **************************************************
            'Call prvvsfSlotMap_init(vsfSlotMap1, CMlngOCSlotSize)
            'Call prvvsfSlotMap_init(vsfSlotMap2, CMlngOCSlotSize)
            Call prvvsfSlotMap_init(vsfSlotMap1, CMlngStartSize)
            Call prvvsfSlotMap_init(vsfSlotMap2, CMlngStartSize)
        '@↑2009/09/11 (Fri) 14:56:01 T.Oide **************************************************
            
            '@閉じるﾎﾞﾀﾝのCausesValidationを設定する
            cmdClose.CausesValidation = False
            '@空きｷｬﾘｱ一覧のCausesValidationを設定する
            cmdCarrierSelect.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02C0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxCM02E0_CmbInit
    '機　能：ｺﾝﾎﾞﾎﾞｯｸｽの有効/無効を設定する
    '引　数：blnFormLoad：FormLoadから呼ばれる場合はTrue
    '戻り値：
    '作成日：2009/06/09 (Tue) 10:31:13 T.Oide
    '更新日：2009/09/11 (Fri) 14:15:43 T.Oide
    '備　考：
    Private Sub prvFrmxxCM02E0_CmbInit(ByVal blnFormLoad As Boolean)
        
        Try
            If blnFormLoad = True Then
                cmdClose.Enabled = True                             '閉じる
                cmdCarrierSelect.Enabled = False                    '空きｷｬﾘｱ選択
                cmdJigSelect.Enabled = False                        '空き治具選択
        '@↓2009/09/11 (Fri) 14:15:31 T.Oide **************************************************
                'cmdTreatCF.Enabled = True                           '対向基板処置登録
                cmdTreatCF.Enabled = False                          '対向基板処置登録
        '@↑2009/09/11 (Fri) 14:15:31 T.Oide **************************************************
                cmdRegist.Enabled = False                           '確定
                cmdUP1.Enabled = False                              'ｽｸﾛｰﾙ↑1
                cmdDown1.Enabled = False                            'ｽｸﾛｰﾙ↓1
                cmdUP2.Enabled = False                              'ｽｸﾛｰﾙ↑2
                cmdDown2.Enabled = False                            'ｽｸﾛｰﾙ↓2
            Else
                '@ﾃﾞｰﾀ取得後の各ｺﾝﾎﾞの設定
                If txtCarrierID1.Text <> vbNullString And _
                   lblNum.Text <> vbNullString Then
                    
                    cmdClose.Enabled = True                            '閉じる
                    cmdCarrierSelect.Enabled = False                   '空きｷｬﾘｱ選択
                    'cmdJigSelect.Enabled = True                        '空き治具選択
                    cmdTreatCF.Enabled = True                          '対向基板処置登録
                    
                    '@移載後のﾃﾞｰﾀ設定済みなら確定ﾎﾞﾀﾝも有効にする
                    'まず、移載後ｷｬﾘｱが空でなく、
                    '治具の設定が終わっていること
                    If txtCarrierID2.Text <> vbNullString And _
                       mblnvsfSlotMap2Set = True Then
                       
                       '@ﾛｯﾄの状態によって確定の有効/無効を変える
                       If lblStatus.Text = CPstrBeforeProgressSt Or _
                          lblStatus.Text = CPstrProcessingSt Then
                            '@前処理、処理中の場合は移載数量が0でも確定を許す
                            cmdRegist.Enabled = True
                       Else
                            '@後処理の場合は、合計に有効な数値が入っていること(初期はNULL表示ﾅﾉﾃﾞ)
                            If txtMoveNum.Text <> vbNullString And _
                               IsNumeric(labSum.Text) Then
                                '@合計数量と移載前数量が一致していること
                                If CLng(lblNum.Text) = CLng(labSum.Text) Then
                                    
                                    cmdRegist.Enabled = True
                                Else
                                
                                    cmdRegist.Enabled = False
                                End If
                            Else
                                cmdRegist.Enabled = False
                            End If
                        End If
                        
                    Else
                        cmdRegist.Enabled = False
                    End If
                    
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxCM02E0_CmbInit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：prvvsfSlotMap_Init
    '機　能：利用部材一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：2009/06/12 (Fri) 13:32:25 T.Oide
    '備　考：
    Private Sub prvvsfSlotMap_init(ByVal lobjvsfGrid As C1FlexGrid, _
                                   ByVal lngSlotSize As Integer)

        Dim llngCnt     As Integer

        Try
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With lobjvsfGrid
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                '.ExplorerBar = flexExNone
                        
                '@行数設定
                .Rows.Count = lngSlotSize
                
                '@10段以上ある場合は↑を有効にする
                If lngSlotSize > CMvsfSlotMapVisibleRows Then
                    If lobjvsfGrid.Name = "vsfSlotMap1" Then
                        cmdUP1.Enabled = True
                    Else
                        cmdUP2.Enabled = True
                    End If
                Else
                    '@ｽﾛｯﾄ数が10以下の場合は↑は無効
                    If lobjvsfGrid.Name = "vsfSlotMap1" Then
                        cmdUP1.Enabled = False
                    Else
                        cmdUP2.Enabled = False
                    End If
                    
                End If
                
                '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                '.FillStyle = flexFillRepeat
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowBigSelection = False
                
                '@ﾏｳｽでｾﾙ範囲選択不可
                '.AllowSelection = False
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@一覧表の表題設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_SlotMapHeader")
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfSlotMapColSlot, CMlngVsfRowTitle, CMlngvsfSlotMapColJigId)
                newStyle.Font = New Font(newStyle.Font.FontFamily, CType(CMlngVsfHFontSize, Single), newStyle.Font.Style) 'ﾌｫﾝﾄｻｲｽﾞ
                newStyle.TextAlign = TextAlignEnum.CenterCenter                '表示位置CenterCenter
                newStyle.ForeColor = Color.Yellow                              'ﾀｲﾄﾙ文字色黄色
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor) '背景色青
                cellRange.Style = newStyle

                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfSlotMapColSlot).Width = CMlngvsfSlotMapColWSlot                '幅(ｽﾛｯﾄ№)
                .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColSlot, CMstrvsfSlotMapColSlot)   'ﾀｲﾄﾙ(ｽﾛｯﾄ№)

                .Cols(CMlngvsfSlotMapColWFID).Width = CMlngvsfSlotMapColWWFID                '幅(WP_ID)
                .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColWFID, CMstrvsfSlotMapColWFID)   'ﾀｲﾄﾙ(WP_ID)

                .Cols(CMlngvsfSlotMapColJigId).Width = CMlngvsfSlotMapColWJigId              '幅(治具ID)
                .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColJigId, CMstrvsfSlotMapColJigId) 'ﾀｲﾄﾙ(治具ID)
                
                If lobjvsfGrid.Name = "vsfSlotMap2" Then
                    .Cols(CMlngvsfSlotMapColReserveJigId).Width = CMlngvsfSlotMapColWReserveJigId              '幅(変更前治具ID)
                    .SetData(CMlngVsfRowTitle, CMlngvsfSlotMapColReserveJigId, CMstrvsfSlotMapColReserveJigId) 'ﾀｲﾄﾙ(治具ID)
                    vsfSlotMap2.Cols(CMlngvsfSlotMapColReserveJigId).Visible = False
                End If
                
        '@↓2009/09/15 (Tue) 12:49:16 T.Oide **************************************************
                '@表示位置の設定
        '        .Cell(flexcpAlignment, CMlngVsfRowTitle, CMlngVsfColTitle, .Rows - 1, .Cols - 2) = flexAlignCenterCenter
        '@↑2009/09/15 (Tue) 12:49:16 T.Oide **************************************************
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    '高さ
                
                '@一覧表のSlot№設定
                For llngCnt = 1 To lngSlotSize - 1
                    .Font = New Font(.Font.FontFamily, CType(CMlngVsfHFontSize, Single), .Font.Style) 'ﾌｫﾝﾄｻｲｽﾞ
                    .SetData(llngCnt, CMlngvsfSlotMapColSlot,CStr(Format$(lngSlotSize - llngCnt, CPstrSlotNoFormat))) 'ｽﾛｯﾄ№
                    .Rows(llngCnt).Height = CMlngVsfHeight                        '行高さ
                    
                    'NSYS データ行の書式設定
                    newStyle = .Styles.Add("CustomStyle_SlotMap2DataRow")
                    cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColSlot, llngCnt, .Cols.Count - 1)
                    newStyle.Font = New Font(newStyle.Font.FontFamily, CType(15.75, Single), newStyle.Font.Style) 'ﾌｫﾝﾄｻｲｽﾞ
                    cellRange.Style = newStyle
                Next llngCnt
                
                '@WP_IDを非表示にする
                .Cols(CMlngvsfSlotMapColWFID).Visible = False
                
                '@初期表示行番号設定
                .TopRow = CMvsfSlotMapSTopRow
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.None

                '@ﾛｯｸ
                .Enabled = False

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMap1_Disp
    '機　能：取得した利用部材を一覧表示
    '引　数：ltypPartLotList()：部材ﾛｯﾄﾘｽﾄ格納ﾃﾞｰﾀ
    '　　　：llngpartlotlistcnt：部材ﾛｯﾄﾘｽﾄｶｳﾝﾄ数
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub prvvsfSlotMap1_Disp(ByRef ltypPartLotList() As PartLotList, _
                                       ByVal llngPartLotListCnt As Integer)

        Dim lstrFormatNum           As String               '該当件数ﾌｫｰﾏｯﾄ変更
        Dim llngDoCnt               As Integer              'ｶｳﾝﾄ
        Dim llngCnt                 As Integer              'ｶｳﾝﾄ
        Dim llngRow                 As Integer              '行ｶｳﾝﾄ

        Try
            
            With vsfSlotMap1
                If llngPartLotListCnt = 0 Then
                '@格納ﾃﾞｰﾀがない場合
                    '@部材一覧表示情報初期化
                    'Call prvvsfSlotMap1_Init
                    
                    Exit Sub
                Else
                '@格納ﾃﾞｰﾀがある場合
                    '@部材一覧表示情報初期化
                    'Call prvvsfSlotMap1_Init
                    
                    '@描画ﾛｯｸ
                    .Redraw = False

                    '@行ｶｳﾝﾀの初期化
                    llngRow = 0
                    For llngDoCnt = 0 To llngPartLotListCnt - 1
                        '@現在状態が保留以外の場合
                        If ltypPartLotList(llngDoCnt).strCurrentStatus <> CPstrClass4J Then
                            '@行ｶｳﾝﾀｶｳﾝﾄｱｯﾌﾟ
                            llngRow = llngRow + 1
                            
                            '@行数設定
                            .Rows.Count = llngRow + 1
                            
                            '@ｾﾙ色変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite" & llngRow.ToString)
                            Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngVsfColTitle, llngRow, .Cols.Count - 2)
                            newStyle.BackColor = Color.White
                            cellRange.Style = newStyle     '白色
                            '@ﾌｫﾝﾄ色変更
                            newStyle  = .Styles.Add("CustomStyle_ForeColor_vbBlack" & llngRow.ToString)
                            newStyle.ForeColor = Color.Black
                            cellRange = .GetCellRange(llngRow, CMlngVsfColTitle, llngRow, .Cols.Count - 2)
                            cellRange.Style = newStyle     '黒色
                                                            
                            '@ｽﾛｯﾄの高さの設定
                            .Rows(llngRow).Height = CMlngVsfHeight
                            
                            '.Cell(flexcpText, llngRow, CMlngvsfInvLLColCFLotID) _
                            '    = ltypPartLotList(llngDoCnt).strLotID                                   'CFﾛｯﾄID
                                
        '@                    .Cell(flexcpText, llngRow, CMlngvsfInvLLColPassedTime) _
        '@                        = Mid$(ltypPartLotList(llngDoCnt).strLimitTime, 3, 14)                  '制限時間
        '@                    '時間制限を越えている場合はﾊﾞｯｸｶﾗｰを赤に変更して使えないことをあらわす
        '@                    If ltypPartLotList(llngDoCnt).strLimitTime < Format(Now, "YYYY/MM/DD HH:MM:SS") Then
        '@                        .Cell(flexcpBackColor, llngRow, CMlngvsfInvLLColNo, llngRow, CMlngvsfInvLLColEditTime) = vbRed
        '@                    End If
        '@
        '@                    .Cell(flexcpText, llngRow, CMlngvsfInvLLColBoardThickness) _
        '@                        = ltypPartLotList(llngDoCnt).strThicknessCode                           '厚
        '@
        '@                    .Cell(flexcpText, llngRow, CMlngvsfInvLLColRegeneration) _
        '@                        = ltypPartLotList(llngDoCnt).strReworkCount                             'ﾘﾜｰｸ
        '@
        '@                    .Cell(flexcpText, llngRow, CMlngvsfInvLLColNum) _
        '@                        = Format$(ltypPartLotList(llngDoCnt).strNum, CPstrDateFormatKanma)      '在庫枚数
        '@
        '@                    .Cell(flexcpText, llngRow, CMlngvsfInvLLColEditTime) _
        '@                        = ltypPartLotList(llngDoCnt).strLotLastUpdate                           '更新日時
                                
                        End If
                    Next
                    
                    '@表示位置設定
        '@            .ColAlignment(CMlngvsfInvLLColCFLotID) = flexAlignLeftCenter               '左中央　CFﾛｯﾄID
        '@            .ColAlignment(CMlngvsfInvLLColPassedTime) = flexAlignLeftCenter            '左中央　経過時間
        '@            .ColAlignment(CMlngvsfInvLLColBoardThickness) = flexAlignLeftCenter        '左中央　厚
        '@            .ColAlignment(CMlngvsfInvLLColRegeneration) = flexAlignRightCenter         '右中央　ﾘﾜｰｸ
        '@            .ColAlignment(CMlngvsfInvLLColNum) = flexAlignRightCenter                  '右中央　在庫枚数
        '@            .ColAlignment(CMlngvsfInvLLColEditTime) = flexAlignRightCenter             '右中央　更新日時
                    
                    '@行表示
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        .Rows(llngCnt).Visible = True
                    Next llngCnt
                    
                    '@№設定
                    For llngDoCnt = 1 To .Rows.Count - 1
                        .SetData(llngDoCnt, CMlngvsfSlotMapColSlot, llngDoCnt)
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height = CMlngVsfHeight
                        
                        '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                        .Cols(CMlngvsfSlotMapColSlot).TextAlign = TextAlignEnum.RightCenter      '右中央

                    Next llngDoCnt
                    
                    '@件数ﾒｯｾｰｼﾞ表示
                    lstrFormatNum = Format$(llngDoCnt - 1, CPstrDateFormatKanma)
                    lblNum.Text = lstrFormatNum
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                            '@該当行をｿｰﾄ
                            '.Cell(flexcpSort, .Rows.Fixed, mtypChgSort.typChgSortList(llngCnt).lngCol, .Rows.Count - 1) _
                            '    = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            'NSYS ソート呼び出し変更
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@更新日時が同じ場合
                            'If .Cell(flexcpText, llngCnt, CMlngvsfInvLLColEditTime) = mtypChgSort.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                Call pubVsfBeforeSort(vsfSlotMap1, CMlngVsfColTitle)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                Call pubVsfAfterSort(vsfSlotMap1, CMlngVsfColTitle)
                                Exit For
                            'End If
                        Next llngCnt
                    End If
                    
                    '@描画ﾛｯｸ解除
                    .Redraw = True
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap1_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN02C0_Minit
    '機　能：Private変数等の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub prvfrmxxEN02C0_Minit()

        Try
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            mtypChgSort.typChgSortList = New List(Of ChgSortList)
            
            'CF移載情報取得ﾌﾗｸﾞﾘｾｯﾄ
            mblngetCFmoveInfo = False
            
            'ﾃﾞｰﾀｾｯﾄﾌﾗｸﾞｸﾘｱ
            mblnvsfSlotMap2Set = False
            
        '@↓2009/07/31 (Fri) 09:22:09 T.Oide **************************************************
            '@変更中の行を初期化
            mlngEditRow = 0
        '@↑2009/07/31 (Fri) 09:22:09 T.Oide **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02C0_Minit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：prvLotInfo_Disp
    '機　能：引数の情報で画面を表示する
    '引　数：mtypLotCurState：ﾛｯﾄ情報
    '　　　：ltypWaferList：ｳｪﾊｰﾘｽﾄ情報
    '　　　：objVsfg：ｸﾞﾘｯﾄﾞｵﾌﾞｼﾞｪｸﾄ
    '　　　：blnLotDisp：ﾛｯﾄ情報を表示する場合 True
    '戻り値：
    '作成日：2009/06/09 (Tue) 18:45:05 T.Oide
    '更新日：2009/06/09 (Tue) 18:45:05
    '備　考：
    Private Sub prvLotInfo_Disp(ByRef mtypLotCurState As Lotprestate, _
                                ByRef ltypWaferList As Waferlist)

        Dim lngCnt      As Integer
        Dim lngCnt2     As Integer

        Try
            
            '@ﾛｯﾄ情報表示
            With mtypLotCurState
                lblLotID.Text = .strLotID
                lblFlowClass.Text = .strFlowClass
                lblStatus.Text = .strNowST
                lblPdID.Text = .strPdId
                lblOpID.Text = .strOpID
                lblStepID.Text = .strStepID
                lblNum.Text = .strChipQuantity
                labScrapNum.Text = .strChipCurrentOutQuantity
                txtCarrierID2.Text = .strCarrierId                  '移載先ｷｬﾘｱID
            End With
            
            '@ｳｪﾊｰ情報表示
            With ltypWaferList
                '@ｸﾞﾘｯﾄﾞ行分繰り返し
                For lngCnt = 1 To vsfSlotMap1.Rows.Count - 1
                    '@配列分繰り返し
                    For lngCnt2 = 0 To .lngListCnt - 1
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが一致していたら表示
                        If vsfSlotMap1.GetData(vsfSlotMap1.Rows.Count - lngCnt, CMlngvsfSlotMapColSlot) = _
                            .typWfList(lngCnt2).strSlotPosition Then
                            vsfSlotMap1.SetData(vsfSlotMap1.Rows.Count - lngCnt, CMlngvsfSlotMapColSlot, _
                                                                            .typWfList(lngCnt2).strSlotPosition)      'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                            vsfSlotMap1.SetData(vsfSlotMap1.Rows.Count - lngCnt, CMlngvsfSlotMapColWFID, _
                                                                            .typWfList(lngCnt2).strWfId)              'WF_ID
                            vsfSlotMap1.SetData(vsfSlotMap1.Rows.Count - lngCnt, CMlngvsfSlotMapColJigId, _
                                                                            .typWfList(lngCnt2).strjigId)             '治具ID
                            Exit For
                        End If
                    Next
                Next
            End With

            'NSYS SlotMapの選択をヘッダーに設定
            vsfSlotMap1.Row = - 1
            vsfSlotMap2.Row = - 1

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLotInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCalcSum
    '機　能：合計値を計算する
    '引　数：なし
    '戻り値：
    '作成日：2009/06/11 (Thu) 18:28:44 T.Oide
    '更新日：2009/06/11 (Thu) 18:28:44
    '備　考：
    Private Sub prvCalcSum()

        Dim llngReworkNum   As Integer
        Dim llngScrapNum    As Integer

        Try
            
            'ﾘﾜｰｸ数を数値に変換
            If labReworkNum.Text = vbNullString Then
                llngReworkNum = 0
            Else
                llngReworkNum = CLng(labReworkNum.Text)
            End If
            
            '不良数を数値に変換
            If labScrapNum.Text = vbNullString Then
                llngScrapNum = 0
            Else
                llngScrapNum = CLng(labScrapNum.Text)
            End If
            
            
            '@入力が数値だったら合計を表示する
            If IsNumeric(txtMoveNum.Text) Then
                '@合計を計算
                labSum.Text = CLng(txtMoveNum.Text) + llngReworkNum + llngScrapNum
            Else
                '@入力をｸﾘｱ
                txtMoveNum.Text = vbNullString
                labSum.Text = llngReworkNum + llngScrapNum
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCalcSum"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：prvCFMoveInfo_Sel
    '機　能：登録済みCF移載情報を取得する
    '引　数：なし
    '戻り値：
    '作成日：2009/06/11 (Thu) 20:31:22 T.Oide
    '更新日：2009/07/23 (Thu) 17:10:48 T.Oide
    '備　考：
    Private Sub prvCFMoveInfo_Sel()

        Dim typcfchipmovejigList    As cfchipmovejigList    'CF移載情報登録用構造体
        Dim lstrFormName            As String               'ﾌｫｰﾑ名
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名
        Dim lblnAns                 As Boolean              '戻り値
        Dim lngCnt                  As Integer
        Dim lngCnt2                 As Integer
        Dim lngMoveNum              As Integer
        Dim lngScrapNum             As Integer
        Dim lngReworkNum            As Integer
        
        Try
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "txtCarrierID2_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ｷｬﾘｱ情報(要求)格納
            With typcfchipmovejigList
                .strMsgVersion = CMstrlot_cfchipmoveinfoVer 'MSGVER
                .strLotID = lblLotID.Text                   'ﾛｯﾄID
                .strCarrierId = txtCarrierID2.Text          'ｷｬﾘｱID
                .strOpID = lblOpID.Text                     '大工程
                .strStepID = lblStepID.Text                 '小工程
            End With

            '@CF移載情報取得
            lblnAns = pubblnCfChipMoveInfo_Sel(typcfchipmovejigList)

            '@取得結果確認
            If lblnAns = True Then
            
               '@vsfSlotMap2を変更可能にする
                vsfSlotMap2.Enabled = True
                vsfSlotMap2.AllowEditing = True
                
                '@ｷｬﾘｱIDの退避
                mstrCarrierID2 = txtCarrierID2.Text
                
                '@ﾃﾞｰﾀがある場合表示
                If typcfchipmovejigList.strCarrierId <> vbNullString Then
                
                    '@ｷｬﾘｱID表示
                    txtCarrierID2.Text = typcfchipmovejigList.strCarrierId
            
                    '@取得結果を画面に表示
                    With vsfSlotMap2
                    
                        '@ｸﾞﾘｯﾄﾞの行数ぶん繰り返し
                        For lngCnt = 1 To vsfSlotMap2.Rows.Count - 1
                            '@取得したﾃﾞｰﾀぶん繰り返し
                            For lngCnt2 = 0 To typcfchipmovejigList.lngcfjigListCnt - 1
                                '@取得した値とｸﾞﾘｯﾄﾞのｽﾛｯﾄﾏｯﾌﾟが一致したら値を表示
                                If vsfSlotMap2.GetData(vsfSlotMap2.Rows.Count - lngCnt, CMlngvsfSlotMapColSlot) _
                                    = typcfchipmovejigList.typcfjigList(lngCnt2).strSlotNo Then
                                    
                                    vsfSlotMap2.SetData(vsfSlotMap2.Rows.Count - lngCnt, CMlngvsfSlotMapColWFID, _
                                                        typcfchipmovejigList.typcfjigList(lngCnt2).strWfId)                'WF_ID
                                    vsfSlotMap2.SetData(vsfSlotMap2.Rows.Count - lngCnt, CMlngvsfSlotMapColJigId, _
                                                        typcfchipmovejigList.typcfjigList(lngCnt2).strjigId)               '治具ID
                                    vsfSlotMap2.SetData(vsfSlotMap2.Rows.Count - lngCnt, CMlngvsfSlotMapColReserveJigId, _
                                                        typcfchipmovejigList.typcfjigList(lngCnt2).strjigId)               '変更前治具ID
                                    '@ｸﾞﾘｯﾄﾞｾｯﾄﾌﾗｸﾞ
                                    mblnvsfSlotMap2Set = True
                                    Exit For
                                End If
                            Next
                        Next
                    
                    End With
                    
                    With typcfchipmovejigList
                        '@ﾘﾜｰｸ数量
                        labReworkNum.Text = .strReworkNum
                        '@不良数量
                        labScrapNum.Text = .strScrapNum
                        '@移載数量
                        txtMoveNum.Text = .strMoveNum
                        '@合計を求める
                        If IsNumeric(.strReworkNum) Then
                            lngReworkNum = .strReworkNum
                        Else
                            lngReworkNum = 0
                        End If
                        
                        If IsNumeric(.strScrapNum) Then
                            lngScrapNum = .strScrapNum
                        Else
                            lngScrapNum = 0
                        End If
                        
                        If IsNumeric(.strMoveNum) Then
                            lngMoveNum = .strMoveNum
                        Else
                            lngMoveNum = 0
                        End If
                        
                        '@合計表示
                        labSum.Text = lngMoveNum + lngScrapNum + lngReworkNum
                        
                    End With
                
                End If
                
                'CF移載情報取得ﾌﾗｸﾞｾｯﾄ(一度ﾃﾞｰﾀを取ったらもう取らない)
                mblngetCFmoveInfo = True
                        
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)

            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@ｷｬﾘｱIDのｸﾘｱ
                mstrCarrierID2 = vbNullString

                Exit Sub
            End If
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCFMoveInfo_Sel"
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

    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraSlotMap1.Paint, fraSlotMap2.Paint

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
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfSlotMap1.KeyDownEdit, vsfSlotMap2.KeyDownEdit

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

    '関数名：flex_SetupEditor
    '機　能：グリッド内コンボボックス表示行数調整
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/11/14 (Thu) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfSlotMap1.SetupEditor, vsfSlotMap2.SetupEditor

        Try
            If TypeOf sender.Editor Is ComboBox
                '行の高さを変更
                Dim editor As ComboBox = CType(sender.Editor, ComboBox)
                editor.DrawMode = DrawMode.OwnerDrawFixed
                editor.DropDownHeight = 106
                editor.MaxDropDownItems = 12
            End If

            '@治具ID列の場合最大入力桁数は10桁とする
            If vsfSlotMap2.Col = CMlngvsfSlotMapColJigId Then
                CType(vsfSlotMap2.Editor, Object).MaxLength = CMlngJigLength
            End If

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub

    '関数名：vsfSlotMap_BeforeScroll
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ ｽｸﾛｰﾙ前処理
    '引　数：sender：イベント発生元
    '　　　：e     ：Rangeイベントオブジェクト
    '戻り値：なし
    '作成日：2019/06/11 (Tue) 9:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub vsfSlotMap_BeforeScroll(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfSlotMap2.BeforeScroll

        If mblnMouseDrag = True Then
            e.Cancel = True
        End If

    End Sub

End Class
