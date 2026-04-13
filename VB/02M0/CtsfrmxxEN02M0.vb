'ﾌｧｲﾙ名：xxEN02M0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：GRBロット分割　メインフォーム
'作成日：2016/02/14 (Sun) 16:18:00 H.Hayashi
'更新日：
'備　考：
'Copyright(C)2016-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02M0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02M0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02M0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02M0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02M0)
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
    '========================================Public=========================================
    '========================================Private========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2020/03/06 (Fri) 12:52:19 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion             As String = "01.00"
    Private Const CMstrLocalVersion             As String = "01.01"
    '@↑2020/03/06 (Fri) 12:52:19 Y.Yoneyama 「.Netへ反映未」 **************************************************
    
    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN02M0

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 14:08:46 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer          As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer          As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:08:46 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_divide__Ver          As String = "02.00"         'ﾛｯﾄ分割
    Private Const CMstrlot_waferlistVer         As String = "02.05"         'ﾛｯﾄWF情報取得(新)
    Private Const CMstrlot_dividedirectVer      As String = "01.00"         'ﾛｯﾄ分割(一括移載)
    Private Const CMstrlot_throwrsvVer          As String = "03.00"         '投入予約登録
    Private Const CMstrlot_approveVer           As String = "01.04"         '投入ﾛｯﾄ承認要求
    '@↓2019/12/19 (Thu) 19:13:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_rsvlist_Ver          As String = "02.00"         '投入予定ﾛｯﾄ一覧
    Private Const CMstrlot_rsvlist_Ver          As String = "03.00"         '投入予定ﾛｯﾄ一覧
    '@↑2019/12/19 (Thu) 19:13:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrcarrcurstateVer          As String = "05.02"         'ｷｬﾘｱ状態確認
    Private Const CMstrlot_dividerecipeVer      As String = "01.00"         'ﾛｯﾄ分割ﾚｼﾋﾟ状態ﾁｪｯｸ
    Private Const CMstrlot_chksecpriorityVer    As String = "01.00"         'ﾛｯﾄ区間優先状態ﾁｪｯｸ
    Private Const CMstrmas_definelistVer        As String = "01.00"         'DEFINE情報取得
    Private Const CMstrlot_chggrbclassVer       As String = "01.00"         'GRB区分更新(親ﾛｯﾄ単体)

    '@vsfSlotMapの定数宣言(ｶﾗﾑ)
    Private Const CMlngColSlot                  As Integer = 0                 'ｽﾛｯﾄ
    Private Const CMlngColWFID                  As Integer = 1                 'WFID
    Private Const CMlngColClass                 As Integer = 2                 'CLASS
    Private Const CMlngColBatchId               As Integer = 3                 'ﾊﾞｯﾁID
    Private Const CMlngColGrbClass              As Integer = 4                 'GRB区分
    Private Const CMlngColNum                   As Integer = 5                 '無機流動TPAL前ｽﾛｯﾄ情報ｶﾗﾑ数

    '@vsfSlotMapの定数宣言(表示幅)
    Private Const CMlngColSlotWidth             As Integer = 29                'ｽﾛｯﾄWidth
    Private Const CMlngColWFIDWidth             As Integer = 147               'WFIDWidth
    Private Const CMlngColClassWidth            As Integer = 80                'CLASSWidth
    Private Const CMlngColGrbClassWidth         As Integer = 29                'GRB区分

    '@vsfSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrSlotMapColTSlot          As String = vbNullString    'ｽﾛｯﾄNO
    Private Const CMstrSlotMapColTWFID          As String = "WFID"          'WFID
    Private Const CMstrSlotMapColTGrbClass      As String = "GRB"           'GRB区分

    '@vsfSlotMapの定数宣言(その他)
    Private Const CMlngSlotMapRowTitle          As Integer = 0                 'ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ
    Private Const CMlngSlotHMaCellFontSize      As Integer = 12                'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngSlotMapRowS              As Integer = 26                '行数
    Private Const CMlngSlotMapHHeight           As Integer = 20                'ﾍｯﾀﾞｰの高さ
    Private Const CMlngSlotMapHeight            As Integer = 38                '1ｽﾛｯﾄの高さ
    Private Const CMlngSlotMapSTopRow           As Integer = 16                '初期表示行番号
    Private Const CMlngSlotMapPageRows          As Integer = 10                '1ﾍﾟｰｼﾞ表示行数
    Private Const CMlngSlotMapSlotNo10Row       As Integer = 17                '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№10の行番号
    Private Const CMlngSlotMapSlotNo16Row       As Integer = 11                '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№16の行番号

    '@その他
    Private Const CMlngDivideNumTwo             As Integer = 2                 '分割先LOTのWF枚数
    Private Const CMlngBackColorCel             As Integer = &H8000000D        'ｸﾞﾘｯﾄﾞのﾊﾞｯｸｶﾗｰｾﾙ(紺)

    '@ﾃｷｽﾄの1ﾍﾟｰｼﾞの行数
    Private Const CMlngMaxDispMemoRow           As Integer = 3                 'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@DEFINE情報
    Private Const CMstrTableName                As String = "GRB_CLASS"
    Private Const CMstrColumnName               As String = "GRB_DATA"

    '@その他
    Private Const CMstrGrbDivideComment         As String = "ロットGRB分割実施"  'GRB分割(理由)
    Private Const CMstrPipeString               As String = " | "                'ﾊﾟｲﾌﾟ文字
    Private Const CMstrGrbPlural                As String = "GRB_PLURAL"         'GRB区分複数有り

    '************************************************************************************\***
    '                                    *構造体の記述*
    '***************************************************************************************
    '========================================Private========================================
    '@ｽﾛｯﾄﾏｯﾌﾟ退避用構造体
    Private Structure WFTmp
        Dim strSlotNo                               As String                   'ｽﾛｯﾄ№
        Dim strWfId                                 As String                   'WFID
        Dim strClass                                As String                   '状態
        Dim strGrbClass                             As String                   'GRB区分　状態
    End Structure

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '========================================Private========================================
    Private mstrLotLastUpdate                   As String                   'ﾛｯﾄ最終更新日時
    Private mstrEventName                       As String                   'ﾚｽﾎﾟﾝｽ用ｲﾍﾞﾝﾄ名
    Private mstrCarrier                         As String                   'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrCarrierTypeID                   As String                   'ｷｬﾘｱﾀｲﾌﾟID(LOADER側)
    Private mstrLotId                           As String                   '分割子ﾛｯﾄID
    Private mstrFlowClass                       As String                   '分割子ﾛｯﾄ区分
    Private mblnTakeOverDispFlg                 As Boolean                  '引継ぎ表示ﾌﾗｸﾞ
    Private mlngVsfBottomRow                    As Integer                  '画面の一番下の行(WF№01の行)
    Private mlngSlotMapRowS                     As Integer                  '行数
    Private mlngWFNum                           As Integer                  'WF枚数
    Private mstrOyaLotLGrbClass                 As String                   '親ﾛｯﾄGRB区分
    Private mstrTmpOyaLotLGrbClass              As String                   '親ﾛｯﾄGRB区分(子ﾛｯﾄ無し時設定)
    Private buttonProcessing                    As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                  'NSYS WindowCloseフラグ
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
        pubVsfMouseWheelManager_Set(vsfSlotMap, cmdUp, cmdDown)
        pubVsfMouseWheelManager_Set(vsfSlotMapStck, cmdUp, cmdDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '========================================Private========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:28:21 H.Hayashi
    '更新日：
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値

        Try
            
            '@Escﾎﾞﾀﾝを無効(ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない対応)
            Me.CancelButton = Nothing
            
            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02M0, CMstrLocalVersion)
            
            '@機能ﾊﾞｰｼﾞｮﾝ判定処理結果が"False：機能Ver不一致"か
            If lblnAns = False Then
                
                '@=======================
                '@ ﾒﾆｭｰｻｲｽﾞ変更処理
                '@=======================
                Call pubMenuExpand_Disp()
                
                '@=======================
                '@　ﾌｫｰﾑ終了時処理
                '@=======================
                Call Form_QueryUnload(False, New FormClosingEventArgs(CloseReason.UserClosing,  False))
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@作業ﾒﾓ用の上下ｽｸﾛｰﾙﾎﾞﾀﾝを初期化
            cmdMemoUp.Enabled = False           '上(▲)
            cmdMemoDown.Enabled = False         '下(▼)
            
            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN02M0_Init()
            
            '@Form_Loadﾌﾗｸﾞに"True：正常"をｾｯﾄ
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
    '作成日：2016/02/14 (Sun) 15:29:01 H.Hayashi
    '更新日：
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@-----------------------
            '@ 引継ぎ情報表示済みﾌﾗｸﾞの判定
            '@ ⇒FormLoad後、最初の1回しか処理しない
            '@-----------------------
            If mblnTakeOverDispFlg = True Then
                '@"True：引継ぎ情報が表示済み"
                
                '@Escﾎﾞﾀﾝを有効にする
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@引継ぎ情報表示済みﾌﾗｸﾞに"True：表示済"をｾｯﾄ
            mblnTakeOverDispFlg = True

            '@Escﾎﾞﾀﾝを有効にする
            Me.CancelButton = cmdClose

            '@引数のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@NULL以外(引継ぎｷｬﾘｱあり)
                
                '@ｷｬﾘｱIDにｾｯﾄ
                txtCarrier.Text = ptypCommonInfo.strCarrierId

                '@=======================
                '@ ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                '@=======================
                RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier,New CancelEventArgs(False))
                AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
            Else
                '@NULL以外(引継ぎｷｬﾘｱなし)

                '@引継ぎｷｬﾘｱIDの初期化
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
    '機　能：ﾌｫｰﾑ　ｷｰﾎﾞｰﾄﾞｷｰ押下時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：Shift,Ctrl,Altｷｰ状態
    '戻り値：
    '作成日：2016/02/14 (Sun) 15:29:42 H.Hayashi
    '更新日：
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Dim llngRow              As Integer      '対象行格納用
        Dim llngTopRow           As Integer      '先頭行
        Dim lstrCRow             As String       'ｶﾚﾝﾄ行
        Dim lintKeyCode          As Short        'ｶﾚﾝﾄ行

        Try
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
                
                '@〓 分割元ｽﾛｯﾄﾏｯﾌﾟ 〓
                Case vsfSlotMapStck.Name
                    
                    With vsfSlotMapStck
                        
                        '@各種値を退避
                        lintKeyCode = e.KeyCode       'ｷｰｺｰﾄﾞ
                        llngRow = .Row              '現在行
                        llngTopRow = .TopRow        '先頭行
                        
                        '@=======================
                        '@ Tag値(前回TopRow、前回Key値)取得(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        lstrCRow = pubstrVsfTag_Get(vsfSlotMapStck, 1)
                        
                        '@=======================
                        '@ Tag値(前回TopRow、前回Key値)保持(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        Call pubblnVsfTag_Set(vsfSlotMap, 1, lstrCRow)
                        
                        '@=======================
                        '@ 分割元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        Call pubVsf_KeyDown(e, .Name, vsfSlotMapStck, cmdUP, cmdDown, False)                  '分割元ﾏｯﾌﾟ
                        
                        Select Case e.KeyCode
                            'NSYS [↑]ｷｰ
                            Case Keys.Up                        
                                If ActiveControl.Name = vsfSlotMapStck.Name Then
                                    With vsfSlotMapStck
                                        'NSYS VB6互換動作 複数行選択されている場合グリッドをスクロールさせない
                                        If .Row <> .RowSel AndAlso .RowSel = .TopRow AndAlso e.Shift Then
                                            e.Handled = True
                                        End If
                                    End With
                                End If
                            'NSYS [↓]ｷｰ
                            Case Keys.Down
                                If ActiveControl.Name = vsfSlotMapStck.Name Then
                                    With vsfSlotMapStck
                                        'NSYS VB6互換動作 複数行選択されている場合グリッドをスクロールさせない
                                        If .Row <> .RowSel AndAlso .RowSel = .BottomRow AndAlso e.Shift Then
                                            e.Handled = True
                                        End If
                                    End With
                                End If
                        End Select

                        '@各種退避しておいた値を戻す
                        'e.KeyCode = lintKeyCode
                        vsfSlotMap.Row = llngRow
                        vsfSlotMap.TopRow = llngTopRow
                        
                        '@=======================
                        '@ 分割先ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        Call pubVsf_KeyDown(e, vsfSlotMap.Name, vsfSlotMap, cmdUP, cmdDown, False)            '分割先ﾏｯﾌﾟ
                        
                        '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfSlotMapStck)
                                                
                    End With
                    
                    
                '@〓 分割先ｽﾛｯﾄﾏｯﾌﾟ 〓
                Case vsfSlotMap.Name
                    
                    With vsfSlotMap
                        
                        '@各種値を退避
                        lintKeyCode = e.KeyCode       'ｷｰｺｰﾄﾞ
                        llngRow = .Row              '現在行
                        llngTopRow = .TopRow        '先頭行
                        
                        '@=======================
                        '@ Tag値(前回TopRow、前回Key値)取得(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        lstrCRow = pubstrVsfTag_Get(vsfSlotMap, 1)
                        
                        '@=======================
                        '@ Tag値(前回TopRow、前回Key値)保持(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        Call pubblnVsfTag_Set(vsfSlotMapStck, 1, lstrCRow)

                        '@=======================
                        '@ 分割先ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        Call pubVsf_KeyDown(e, .Name, vsfSlotMap, cmdUP, cmdDown, False)                      '分割元ﾏｯﾌﾟ
                        
                        Select Case e.KeyCode
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

                        '@各種退避しておいた値を戻す
                        'e.KeyCode = lintKeyCode
                        vsfSlotMapStck.Row = llngRow
                        vsfSlotMapStck.TopRow = llngTopRow
                        
                        '@=======================
                        '@ 分割元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        Call pubVsf_KeyDown(e, vsfSlotMapStck.Name, vsfSlotMapStck, cmdUP, cmdDown, False)    '分割先ﾏｯﾌﾟ
                        
                        '@分割先ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfSlotMap)
                                                
                    End With

            End Select


            '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
            Select Case e.KeyCode
                
                '@〓 vbKeyReturn：Enterｷｰ 〓
                Case Keys.Return
                    
                    '@ﾌｫｰｶｽがｷｬﾘｱIDにある場合
                    If ActiveControl.Name = "txtCarrier" Then
                        
                        '@=======================
                        '@ ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                        '@=======================
                        RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                        Call txtCarrier_Validate(txtCarrier,New CancelEventArgs(True))
                        AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate

                        Exit Sub
                    End If
                    
                    '@ｺﾒﾝﾄにﾌｫｰｶｽがある場合
                    If ActiveControl.Name = "txtWorkMemo" Then
                        
                        '@改行処理は行わないようにする
                        Exit Sub
                    End If

                    '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽをｾｯﾄし、ｷｰｺｰﾄﾞを無効にする
                    SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True


                '@〓 vbKeyDelete：Deleteｷｰ 〓
                Case Keys.Delete
                    
                    '@ﾌｫｰｶｽが分割先ｽﾛｯﾄﾏｯﾌﾟにある場合
                    If ActiveControl.Name = "vsfSlotMap" Then
                        
                        '@削除ﾎﾞﾀﾝが有効か
                        If cmdDel.Enabled = True Then
                            
                            '@=======================
                            '@ 分割WF戻し("<")ﾎﾞﾀﾝ処理
                            '@=======================
                            Call cmdDel_Click(cmdDel,New EventArgs)
                        End If
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
    '機　能：ﾌｫｰﾑ　ｱﾝﾛｰﾄﾞ時処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:30:20 H.Hayashi
    '更新日：
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      'ACT開放結果格納

        Try

            
            
            '@ﾌｫｰﾑの"×"押下ﾄﾘｶﾞでのCallか
            If mblnCloseFromControlMenu Then

                '@=======================
                '@ 閉じるﾎﾞﾀﾝ処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload

            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@ACT初期化ﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@ACTを自前で初期化した場合
                
                '@=======================
                '@ ACTｵﾌﾞｼﾞｪｸﾄの開放
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                If lblnAnsTerm = True Then
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                
                '@=======================
                '@ ﾒﾆｭｰ伸縮処理
                '@=======================
                Call pubMenuExpand_Disp()

            End If
                       
            '@画面連携用変数の初期値
            pstrLotID = vbNullString
            pstrFlowClass = vbNullString
            pblnMkEasyDivFlag = False
                
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
    '作成日：2016/02/14 (Sun) 15:31:22 H.Hayashi
    '更新日：
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo      As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@引継ぎｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then

                '@=======================
                '@ 親画面切り替え引継ぎ制御
                '@=======================
                Call pubChangeScreen_Set(Me)

            Else
                '@引継ぎｷｬﾘｱIDがNULLの場合
                
                '@=======================
                '@ 終了処理
                '@=======================
                Call publngEnd_Proc(CPstrKeyEN02M0, ltypCommonInfo)
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
    '作成日：2016/02/14 (Sun) 15:36:33 H.Hayashi
    '更新日：
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change
        
        Try
            
            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN02M0_Init(False)
            
            '@初期値をｾｯﾄ
            ptypLotRlst.strLotID = vbNullString             '分割先ﾛｯﾄID
            ptypLotRlst.strFlowClass = vbNullString         '流動区分
            
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

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱﾃｷｽﾄ　選択確定時(Validate)処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:37:06 H.Hayashi
    '更新日：
    '備　考：
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating
        
        Dim lblnAns                         As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotprestate                 As Lotprestate          'ﾛｯﾄ現在状態格納構造体
        Dim ltypWaferList                   As Waferlist            'WF情報格納用構造体

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDが空白か
            If txtCarrier.Text = vbNullString Then
                
                '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽをｾｯﾄし、処理終了
                SendKeys.SendWait(CPstrSendKeysTab)
                Exit Sub
            End If

            '@投入予定ｷｬﾘｱIDの桁ﾁｪｯｸ
            If LenB(txtCarrier.Text) < CPlngCarrierMaxLength Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@=======================
                '@ ｽﾛｯﾄﾏｯﾌﾟ初期化処理(分割元ﾛｯﾄのｽﾛｯﾄﾏｯﾌﾟ)
                '@=======================
                Call prvvsfSlotMap_init(vsfSlotMapStck)

                '@ｽﾛｯﾄﾏｯﾌﾟ上下(▲,▼)ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                cmdUP.Enabled = False
                cmdDown.Enabled = False

                '@ﾌｫｰｶｽをｷｬﾘｱIDに留める
                e.Cancel = True
                Exit Sub
            End If


            '@ｷｬﾘｱIDがNULL以外、かつ前回入力ｷｬﾘｱIDと異なるか
            If Trim$(txtCarrier.Text) <> vbNullString And _
                txtCarrier.Text <> mstrCarrier Then
                '@NULL以外、前回入力ｷｬﾘｱと異なる場合
                
                '@ﾚｽﾎﾟﾝｽ測定開始
                mstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(Me.Name, mstrEventName)
                
                '@=======================
                '@ ﾛｯﾄ現在状態取得(1A：ﾛｯﾄ分割)
                '@=======================
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                CPstrCD1Z, _
                                                txtCarrier.Text, _
                                                ltypLotprestate)
                
                '@ﾛｯﾄ現在状態取得結果が"True：取得成功"か
                If lblnAns = True Then
                    
                    '@ﾚｽﾎﾟﾝｽ測定終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
                    
                    '@=======================
                    '@ 画面情報表示処理
                    '@=======================
                    Call prvFrmxxEN02M0_Disp(ltypLotprestate)
                    
                    '@↓2020/03/26 (Thu) 11:17:27 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    '@状態に関係なく分割可能にする
                    '@GRB区分が親である場合
                    'If mstrOyaLotLGrbClass <> vbNullString Then
                    '    '@表示ﾒｯｾｰｼﾞ変換
                    '    '@"<TRM141W>$$ロット[%1]はロットGRB分割済みです。"のﾒｯｾｰｼﾞ表示
                    '    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0141, lblLotID.Text)
                    '    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '               
                    '    Exit Sub
                    'End If
                    '@↑2020/03/26 (Thu) 11:17:27 Y.Yoneyama 「.Netへ反映未」 **************************************************                    

                    '@WF枚数、ｷｬﾘｱﾀｲﾌﾟをﾓｼﾞｭｰﾙ変数に格納
                    mlngWFNum = CLng(ltypLotprestate.strWfNum)
                    mstrCarrierTypeID = ltypLotprestate.strCarrierTypeID
                    
                    '@ﾚｽﾎﾟﾝｽ測定開始
                    Call pubResponseStart(Me.Name, mstrEventName)
                    
                    '@=======================
                    '@ ﾛｯﾄWF情報取得(0T：有効WF)
                    '@=======================
                    lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                                     txtCarrier.Text, _
                                                     CPstrCD0T, _
                                                     ltypWaferList)
                    
                    '@ﾛｯﾄWF情報取得結果が"True：取得成功"か
                    If lblnAns = True Then
                        
                        '@ﾚｽﾎﾟﾝｽ測定終了
                        Call publngResponseEnd(Me.Name, mstrEventName)
                        
                        '@各種値をﾓｼﾞｭｰﾙ変数に格納
                        mlngVsfBottomRow = ltypWaferList.strSlotSize        'WF№01の行
                        mlngSlotMapRowS = ltypWaferList.strSlotSize + 1     'ｽﾛｯﾄ数
                        mstrCarrier = txtCarrier.Text                       'ｷｬﾘｱID
                        
                        '@=======================
                        '@ ｽﾛｯﾄﾏｯﾌﾟ表示処理
                        '@=======================
                        Call prvvsfSlotMap_Set(ltypWaferList, vsfSlotMapStck)
                        
                        '@=======================
                        '@ ｽﾛｯﾄﾏｯﾌﾟの先頭行表示設定処理
                        '@=======================
                        Call prvVsfSlotMapTopRow_Set()
                        
                        With vsfSlotMapStck
                            
                            '@対象ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄ数が10以上か
                            If .Rows.Count > CMlngSlotMapPageRows + 1 Then
                                
                                '@ﾍﾟｰｼﾞの先頭行が"1"か
                                If .TopRow = .Rows.Fixed Then
                                    
                                    '@上下(▲,▼)ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                                    cmdUP.Enabled = False       '上(▲)：無効
                                    cmdDown.Enabled = True      '下(▼)：有効
                                Else
                                    '@ﾍﾟｰｼﾞの先頭行が"1"以外か
                                
                                    '@上下(▲,▼)ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                                    cmdUP.Enabled = True        '上(▲)：有効
                                    cmdDown.Enabled = False     '下(▼)：無効
                                End If
                            Else
                                '@対象ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄ数が10以下の場合
                            
                                '@1ﾍﾟｰｼﾞで表示出来るので、ｽｸﾛｰﾙは無効
                                cmdUP.Enabled = False           '上(▲)：無効
                                cmdDown.Enabled = False         '下(▼)：無効
                            End If
                        End With

                        '@親GRB区分が自動で一意に決まらなかった場合
                        If mstrTmpOyaLotLGrbClass = vbNullString Then
                            '各種ｺﾝﾄﾛｰﾙを有効にする
                            cmdLotSelect.Enabled = True                 '投入予定ﾛｯﾄ選択ﾎﾞﾀﾝ
                            chkMoveSkip.Enabled = True                  '移載ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽ
                            
                            '@移載ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽにﾌｫｰｶｽｾｯﾄ
                            If ActiveControl.Name = txtCarrier.Name Then
                                Call pubSetFocus(chkMoveSkip)
                            End If
                        Else
                            If ActiveControl.Name = txtCarrier.Name Then
                                Call pubSetFocus(txtCarrier)
                                txtCarrier.SelectionStart = txtCarrier.Text.Length
                            End If
                        End If
                      
                    Else
                        '@ﾛｯﾄWF情報取得結果が"False：取得失敗"か
                    
                        '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                        e.Cancel = True
                        
                        '@ﾚｽﾎﾟﾝｽ測定ｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, mstrEventName)
                    End If
                Else
                    '@ﾛｯﾄ現在状態取得結果が"False：取得失敗"か

                    '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                    e.Cancel = True
                    
                    '@ﾚｽﾎﾟﾝｽ測定ｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                End If
            Else
                '@NULL、または前回入力ｷｬﾘｱと同じ場合
                If ActiveControl.Name = txtCarrier.Name Then
                    '@親GRB区分が自動で一意に決まらなかった場合
                    If mstrTmpOyaLotLGrbClass = vbNullString Then
                        '@移載ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(chkMoveSkip)
                    Else
                        Call pubSetFocus(txtCarrier)
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

    '関数名：chkMoveSkip_Click
    '機　能：移載工程ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:56:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub chkMoveSkip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkMoveSkip.CheckedChanged

        Dim lblnAns     As Boolean      '戻り値

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@移載工程ｽｷｯﾌﾟがﾁｪｯｸONか
            If chkMoveSkip.Checked = True Then
                
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝを有効にする
                cmdCarrierSelect.Enabled = True
                
                '@ｱﾝﾛｰﾄﾞｷｬﾘｱﾃｷｽﾄの設定
                With txtToCarrier

                    .Enabled = True                             '有効
                    .GotBackColor = SystemColors.Window         '白(ﾌｫｰｶｽ取得ﾊﾞｯｸｶﾗｰ)
                    .BackColor = SystemColors.Window            '白(ﾊﾞｯｸｶﾗｰ)
                End With
            Else
                '@移載工程ｽｷｯﾌﾟがﾁｪｯｸOFFか
            
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝを無効にする
                cmdCarrierSelect.Enabled = False

                '@ｱﾝﾛｰﾄﾞｷｬﾘｱﾃｷｽﾄの設定
                With txtToCarrier

                    .Text = vbNullString                         'NULL
                    .Enabled = False                             '無効
                    .GotBackColor = SystemColors.ControlLight    'ｸﾞﾚｰ(ﾌｫｰｶｽ取得ﾊﾞｯｸｶﾗｰ)
                    .BackColor = SystemColors.ControlLight       'ｸﾞﾚｰ(ﾊﾞｯｸｶﾗｰ)
                End With
            End If
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblncmdRegist_Chk

            '@確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：ﾁｪｯｸOK"か
            If lblnAns = True Then
                
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdRegist_Proc(True)
            Else
                
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdRegist_Proc(False)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "chkMoveSkip_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtToCarrier_Change
    '機　能：ｱﾝﾛｰﾀﾞｷｬﾘｱﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:57:29 H.Hayashi
    '更新日：
    '備　考：
    Private Sub txtToCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtToCarrier.Change

        Dim lblnAns     As Boolean      '戻り値
        
        Try
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblncmdRegist_Chk

            '@確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：ﾁｪｯｸOK"か
            If lblnAns = True Then
                
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdRegist_Proc(True)
            Else
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdRegist_Proc(False)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtToCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtToCarrier_Validate
    '機　能：ｱﾝﾛｰﾀﾞｷｬﾘｱﾃｷｽﾄ　選択確定時(Validate)処理
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:57:58 H.Hayashi
    '更新日：
    '備　考：
    Private Sub txtToCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtToCarrier.Validating
        
        Dim lblnAns                 As Boolean              '汎用戻り値結果取得(True:正常,False:異常)
        Dim ltypCarrCurstate        As CarrCurstate         'ｷｬﾘｱ状態確認要求構造体

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLか
            If Trim(txtToCarrier.Text) = vbNullString Then
                Exit Sub
            End If
            
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDが6桁以上か
            If txtToCarrier.NowByte < txtToCarrier.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱにﾌｫｰｶｽを留める
                e.Cancel = True

                '@ｱﾝﾛｰﾀﾞｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtToCarrier)
                Exit Sub
            End If


            '@***********************
            '@ ｷｬﾘｱ情報(要求ﾃﾞｰﾀ)格納
            '@***********************
            With ltypCarrCurstate
                
                .strCarrierId = txtToCarrier.Text           'UnLoaderｷｬﾘｱID
                .strClassDivision = CPstrCD2D               '2D：空ｷｬﾘｱﾁｪｯｸ
                .strMsgVer = CMstrcarrcurstateVer           'ﾒｯｾｰｼﾞVer
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strCarrierTypeID = mstrCarrierTypeID       'Loaderｷｬﾘｱﾀｲﾌﾟ
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "txtToCarrier_Validate"
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@=======================
            '@ ｷｬﾘｱ状態確認
            '@=======================
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, True)
            
            '@ｷｬﾘｱ状態確認結果が"True：確認OK"か
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
            Else
                '@ｷｬﾘｱ状態確認結果が"False：確認NG"の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽを留める
                e.Cancel = True
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtToCarrier)
                Exit Sub
            End If
            
            If ActiveControl.Name = txtToCarrier.Name Then
                '@確定ﾎﾞﾀﾝが有効か
                If cmdRegist.Enabled = True Then
                
                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdRegist)
                Else
            
                    '@投入予定ﾛｯﾄ選択ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdLotSelect)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtToCarrier_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierSelect_Click
    '機　能：空きｷｬﾘｱ選択ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:57:58 H.Hayashi
    '更新日：
    '備　考：
    Private Sub cmdCarrierSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect.Click
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@Form_Loadﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            '@***********************
            '@ 起動条件格納
            '@ 条件の確認(2007/07/23 落合様確認)
            '@ ｷｬﾘｱﾀｲﾌﾟはLOADER側と同じﾀｲﾌﾟであること。(同一ﾀｲﾌﾟ以外の分割はあり得ません！！)
            '@ 洗浄ﾀｲﾌﾟは見る必要はありません。
            '@***********************
            
            pstrCarrierID = txtToCarrier.Text       'ｱﾝﾛｰﾀﾞｷｬﾘｱID
            pstrCarrierTypeID = mstrCarrierTypeID   'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString       '洗浄条件(NULL)
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 空きｷｬﾘｱ一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E0.Instance = New frmxxCM00E0()
            
            '@Form_Loadﾌﾗｸﾞが"False：起動処理失敗"か
            If pblnFormLoad = False Then
            
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00E0.Instance = Nothing
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 空きｷｬﾘｱ一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E0.Instance.ShowDialog(Me)
            frmxxCM00E0.Instance = Nothing
                 
            '@子画面で空きｷｬﾘｱが選択されたか
            If pstrCarrierID <> vbNullString Then
                
                '@選択されたｱﾝﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                txtToCarrier.Text = pstrCarrierID
            End If
            
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID
            
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtToCarrier)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierSelect_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMapStck_Click
    '機　能：分割元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub vsfSlotMapStck_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMapStck.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMapStck.Rows.Count <= vsfSlotMapStck.Rows.Fixed Then
                Return
            End If
            
            '@=======================
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　ｾﾙ選択時処理
            '@=======================
            Call vsfSlotMapStck_EnterCell(vsfSlotMapStck,New EventArgs)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMapStck_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMapStck_EnterCell
    '機　能：分割元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　ｾﾙ選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub vsfSlotMapStck_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMapStck.EnterCell
        
        Dim llngCnt             As Integer      'ｶｳﾝﾄ
        Dim llngRowTop          As Integer      '選択最上段行
        Dim llngRowBottom       As Integer      '選択最下段行

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMapStck.Rows.Count <= vsfSlotMapStck.Rows.Fixed Then
                Return
            End If
            
            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck
                
                '@ﾀｲﾄﾙ行か
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If
                
                '@選択行が選択範囲行より下か
                If .Row < .RowSel Then

                    llngRowTop = .Row           '選択最上段行を格納
                    llngRowBottom = .RowSel     '選択最下段行を格納
                Else

                    llngRowTop = .RowSel        '選択最下段行を格納
                    llngRowBottom = .Row        '選択最上段行を格納
                End If

                '@選択行数分ﾙｰﾌﾟ
                For llngCnt = llngRowBottom To llngRowTop Step -1
                    
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟのﾊﾞｯｸｶﾗｰが灰色、またはWFIDがNULLか
                    If .GetCellRange(llngCnt, CMlngColWFID).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Or _
                        .GetData(llngCnt, CMlngColWFID) = vbNullString Then
                        
                        '@分割(">")ﾎﾞﾀﾝを無効にする
                        cmdMove.Enabled = False
                        Exit For
                    Else
                        '@ﾊﾞｯｸｶﾗｰが白、かつWFIDがNULL以外
                        
                        '@***********************
                        '@ 無機対応
                        '@***********************
                        '@無機用簡易分割識別ﾌﾗｸﾞが"True：簡易分割実施"か
                        If pblnMkEasyDivFlag = True Then
                            
                            '@分割(">")ﾎﾞﾀﾝを無効にする
                            cmdMove.Enabled = False
                        Else
                            '@分割(">")ﾎﾞﾀﾝを有効にする
                            cmdMove.Enabled = True
                        End If
                    
                    End If
                Next llngCnt
            
            End With


            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
            
                '@選択行数分ﾙｰﾌﾟ
                For llngCnt = llngRowBottom To llngRowTop Step -1
                    
                    '@分割先ｽﾛｯﾄﾏｯﾌﾟのﾊﾞｯｸｶﾗｰが灰色、またはWFIDがNULLか
                    If .GetCellRange(llngCnt, CMlngColWFID).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Or _
                        .GetData(llngCnt, CMlngColWFID) = vbNullString Then
                        
                        '@分割WF戻し("<")ﾎﾞﾀﾝを無効にする
                        cmdDel.Enabled = False
                        Exit Sub
                    Else
                        '@ﾊﾞｯｸｶﾗｰが白、かつWFIDがNULL以外
                        
                        '@分割WF戻し("<")ﾎﾞﾀﾝを有効にする
                        cmdDel.Enabled = True
                                          
                    End If
                Next llngCnt
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMapStck_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotSelect_Click
    '機　能：投入予定ﾛｯﾄ選択ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub cmdLotSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotSelect.Click

        Dim ltypMasDefineReq    As MasDefineReq         'DEFINE情報（要求）
        Dim ltypMasDefineAns    As MasDefineAns         'DEFINE情報（応答）
        Dim lblnAnsGrb          As Boolean              'GRBｺｰﾄﾞ取得結果格納
     
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@取得区分に値ｾｯﾄ(0N：分割ﾛｯﾄ)
            pstrfrmxxCM0090Kbn = CPstrCD0N
            
            '@引継ぎ変数にﾛｯﾄIDを格納
            pstrLotID = lblLotID.Text
            
            '@Form_Loadﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 投入予定ﾛｯﾄ一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0090.Instance = New frmxxCM0090()
            
            '@Form_Loadﾌﾗｸﾞが"False：起動処理失敗"か
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0090.Instance = Nothing
                Exit Sub
            End If
            
            '@子画面を一旦非表示にし、ﾓｰﾀﾞﾙ表示にする
            frmxxCM0090.Instance.Hide
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 投入予定ﾛｯﾄ一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0090.Instance.ShowDialog(Me)
            frmxxCM0090.Instance = Nothing
            
            '@値をｾｯﾄ
            lblDivideLotID.Text = ptypLotRlst.strLotID               '分割先ﾛｯﾄID
            lblDivideFlowClass.Text = ptypLotRlst.strFlowClass       '分割先ﾛｯﾄ流動区分
            
            '@ﾛｯｸ解除
            lblDivideLotID.Enabled = True                               '分割先ﾛｯﾄID
            lblDivideFlowClass.Enabled = True                           '分割先ﾛｯﾄ流動区分
            
            '@分割先ﾛｯﾄIDがNULLか
            If lblDivideLotID.Text = vbNullString Then
                Exit Sub
            End If
            
            '@=======================
            '@ 取消ﾎﾞﾀﾝ押下時処理
            '@=======================
            Call cmdClear_Click(cmdClear,New EventArgs)

            '@分割元ﾛｯﾄIDがNULLか
            If lblLotID.Text = vbNullString Then
                Exit Sub
            End If

            '@分割先ｽﾛｯﾄﾏｯﾌﾟ制御
            With vsfSlotMap
                .Enabled = True
            End With


            '@分割元ｽﾛｯﾄﾏｯﾌﾟ制御
            With vsfSlotMapStck

                '@分割元ｽﾛｯﾄﾏｯﾌﾟを有効にする
                .Enabled = True
                    
                '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfSlotMapStck)
            
                '@WFIDがNULLか
                If .GetData(.Row, CMlngColWFID) = vbNullString Then
                    
                    '@=======================
                    '@ ｽﾛｯﾄﾏｯﾌﾟのｾﾙの背景色変更処理
                    '@=======================
                    Call prvVsfSlotMapBackColor_Set()
                End If
            End With
            
            '@分割(">")ﾎﾞﾀﾝを無効にする
            cmdMove.Enabled = False

            '@ｺﾝﾎﾞﾎﾞｯｸｽの初期化
            cmbDivideGrbSel.Clear                                   '分割先GRB区分
            cmbDivideGrbSel.Enabled = True                          '有効
            cmbDivideGrbSel.CausesValidation = True                 'Validate処理不要
            cmbDivideGrbSel.BackColor = SystemColors.Window         '白(ﾊﾞｯｸｶﾗｰ)

            '@DEFINE情報取得(GRBｺｰﾄﾞ)
            With ltypMasDefineReq
                .strMsgVer = CMstrmas_definelistVer     'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strTableName = CMstrTableName          'ﾃｰﾌﾞﾙ名
                .strColumnName = CMstrColumnName        'ｶﾗﾑ名
            End With
                    
            '@MSG通信【DEFINE情報取得】
            lblnAnsGrb = pubblnMasDfineList_Sel(ltypMasDefineReq, ltypMasDefineAns)

            '@戻り値判定
            If lblnAnsGrb = False Then
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            Else
                
                '@配列の件数ﾁｪｯｸ
                If ltypMasDefineAns.lngMasDefineListCnt > 0 Then
                    '@GRBｺｰﾄﾞをｺﾝﾎﾞへｾｯﾄ
                    Call prvGrbInfo_Disp(ltypMasDefineAns)
                End If
            End If

            '@作業ﾒﾓを有効にする
            txtWorkMemo.Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotSelect_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(ｽﾛｯﾄﾏｯﾌﾟ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
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
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdUp(vsfSlotMapStck, cmdUP, cmdDown)            '分割元ｽﾛｯﾄﾏｯﾌﾟ
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdUp(vsfSlotMap, cmdUP, cmdDown)                '分割先ｽﾛｯﾄﾏｯﾌﾟ
            
            '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝが無効か
            If cmdUP.Enabled = False Then
                
                '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdDown)
            Else
                '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdUP)
            End If
            
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
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(ｽﾛｯﾄﾏｯﾌﾟ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
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
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdDown(vsfSlotMapStck, cmdUP, cmdDown, False)       '分割元ｽﾛｯﾄﾏｯﾌﾟ
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdDown(vsfSlotMap, cmdUP, cmdDown, False)           '分割先ｽﾛｯﾄﾏｯﾌﾟ
            
            '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝが無効か
            If cmdDown.Enabled = False Then

                '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdUP)
            Else
                '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdDown)
            End If
            
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

    '関数名：cmdMove_Click
    '機　能：分割(">")ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub cmdMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMove.Click

        Dim lblnRtn             As Boolean      '戻り値変数
        Dim lblnVsfSlotMapNull  As Boolean      'ﾍﾟｰｼﾞDOWNのﾎﾞﾀﾝ状態退避
        Dim llngCnt             As Integer      'ﾙｰﾌﾟのｶｳﾝﾄ
        Dim llngRowTop          As Integer      '選択最上段行
        Dim llngRowBottom       As Integer      '選択最下段行
        Dim ltypWFTmp           As WFTmp        'ｽﾛｯﾄﾏｯﾌﾟの内容格納のための構造体
        Dim lstrOyaGrb          As String       '親側のGRB
        Dim ScrollPosition      As Point        'NSYS スクロール位置格納用変数

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            ScrollPosition = vsfSlotMapStck.ScrollPosition
            vsfSlotMap.Redraw = False
            vsfSlotMapStck.Redraw = False

            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck
                
                '@選択行が選択範囲行より下か
                If .Row < .RowSel Then

                    llngRowTop = .Row           '選択最上段行を格納
                    llngRowBottom = .RowSel     '選択最下段行を格納
                Else

                    llngRowTop = .RowSel        '選択最下段行を格納
                    llngRowBottom = .Row        '選択最上段行を格納
                End If
                
                '@-----------------------
                '@ 最上段と最下段を画面に表示されている範囲に限定
                '@-----------------------
                '@最上段
                For llngCnt = llngRowTop To llngRowBottom
                    
                    '@選択された行が表示領域か
                    If .Rows(llngCnt).Visible = True Then
                        '@表示領域内の場合
                        
                        '@選択最上段行に設定
                        llngRowTop = llngCnt
                        Exit For
                    End If
                Next llngCnt
                
                '@-----------------------
                '@ 選択最下行が表示最下行より下かどうかを判定
                '@ 表示最下行の境目でRowIsVisibleが正しく判定されない為
                '@ →ｸﾞﾘｯﾄﾞの高さを縮めるとRowIsVisibleが正しく判定できるが、一番下にｽｸﾛｰﾙしたときに
                '@ 　ｾﾙのない部分が表示されてしまうので注意
                '@-----------------------
                If llngRowBottom > .TopRow + CMlngSlotMapPageRows - 1 Then
                    '@選択最下行が表示最下行より下の場合
                    
                    '@選択最下行に表示最下行を設定
                    llngRowBottom = .TopRow + CMlngSlotMapPageRows - 1
                End If
            End With


            '@=======================
            '@ 分割元⇒分割先への移載処理
            '@=======================
            llngRowTop = 1
            llngRowBottom = 25
            Call prvWFTempSet_Proc(llngRowTop, llngRowBottom)
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
            '@=======================
            lblnRtn = prvblncmdRegist_Chk(lblnVsfSlotMapNull)
            
            '@確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：ﾁｪｯｸOK"か
            If lblnRtn = True Then
                
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdRegist_Proc(True)
            Else
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdRegist_Proc(False)
            End If
            
            '@分割先ｽﾛｯﾄﾏｯﾌﾟにWFなしの場合
            If lblnVsfSlotMapNull = True Then
                
                '@=======================
                '@ 分割WF戻し("<")ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdDelClear_Proc(False)
            Else
                '@=======================
                '@ 分割WF戻し("<")ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdDelClear_Proc(True)
            End If
            
            '@選択範囲の指定
            With vsfSlotMap
                
                '@分割先ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfSlotMap)

                .Row = llngRowTop                 'ｶﾚﾝﾄ行の設定
                .RowSel = llngRowBottom           '選択範囲の設定
            End With
            
            '@分割(">")ﾎﾞﾀﾝを無効にする
            cmdMove.Enabled = False

            With vsfSlotMapStck

                For llngCnt = llngRowBottom To llngRowTop Step -1
                        
                    '@GRB区分が有る場合
                    If .GetData(llngCnt, CMlngColGrbClass) <> vbNullString Then
                    
                        '@GRB区分の確認が初回又はGRB区分が同じ(一種類)の場合
                        If ((lstrOyaGrb = vbNullString) Or (lstrOyaGrb = .GetData(llngCnt, CMlngColGrbClass))) Then
                          lstrOyaGrb = .GetData(llngCnt, CMlngColGrbClass)
                          
                        '@GRB区分が複数存在した場合
                        Else
                          lstrOyaGrb = CMstrGrbPlural
                        End If
                    
                    End If
                        
                    '@分割先のGRB区分と同じ場合
                    If .GetData(llngCnt, CMlngColGrbClass) = cmbDivideGrbSel.Text Then

                        '@ｳｪﾊを移動
                        ltypWFTmp.strWfId = .GetData(llngCnt, CMlngColWFID)    'WFID
                    End If
                
                Next llngCnt
                
                '@分割元のGRB区分が決定した場合
                If lstrOyaGrb <> vbNullString And lstrOyaGrb <> CMstrGrbPlural Then
                
                    '@分割元のGRB区分を設定
                    lblGrbClass.Text = vbNullString
                    lblGrbClass.Text = lstrOyaGrb
                    '@↓2020/03/26 (Thu) 15:37:37 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    lblGrbClass.BackColor = pubGRBBackColor(lstrOyaGrb, lblFlowClass.BackColor)
                    '@↑2020/03/26 (Thu) 15:37:37 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    '@分割先のGRB区分が設定済みの場合
                    If cmbDivideGrbSel.Text <> vbNullString Then
                        mstrTmpOyaLotLGrbClass = vbNullString
                    End If
                
                End If
                
            End With

            '@=======================
            '@ 分割元/分割先の背景色変更
            '@=======================
            Call prvGridGRBBackColorChange

            vsfSlotMapStck.ScrollPosition = New Point (vsfSlotMap.ScrollPosition.X,ScrollPosition.Y) 
            vsfSlotMapStck.Redraw = True
            vsfSlotMap.ScrollPosition = New Point (vsfSlotMapStck.ScrollPosition.X,ScrollPosition.Y)  
            vsfSlotMap.Redraw = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMove_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDel_Click
    '機　能：分割WF戻し("<")ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub cmdDel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDel.Click

        Dim llngRow             As Integer      '分割先ｽﾛｯﾄﾏｯﾌﾟの戻し対象行格納用
        Dim llngSlotNo          As Integer      'ｽﾛｯﾄNo格納用
        Dim llngCnt             As Integer      'ｶｳﾝﾄ
        Dim llngRowTop          As Integer      '選択最上段行
        Dim llngRowBottom       As Integer      '選択最下段行
        Dim ScrollPosition      As Point        'NSYS スクロール位置格納用変数
        '@↓2020/03/26 (Thu) 17:16:21 Y.Yoneyama 「.Netへ反映未」 **************************************************
        Dim lstrTmpLotGRB       As String       'GRB
        '@↑2020/03/26 (Thu) 17:16:21 Y.Yoneyama 「.Netへ反映未」 **************************************************

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@分割先ｽﾛｯﾄﾏｯﾌﾟの戻し対象行格納
            llngRow = vsfSlotMap.Row

            '@分割先ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(vsfSlotMap)
            
            ScrollPosition = vsfSlotMapStck.ScrollPosition
            vsfSlotMap.Redraw = False
            vsfSlotMapStck.Redraw = False

            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
                
                '@選択行が選択範囲行より下か
                If .Row < .RowSel Then

                    llngRowTop = .Row           '選択最上段行を格納
                    llngRowBottom = .RowSel     '選択最下段行を格納
                Else
                    '@上の場合
                    
                    llngRowTop = .RowSel        '選択最下段行を格納
                    llngRowBottom = .Row        '選択最上段行を格納
                End If
                
                '@-----------------------
                '@ 最上段と最下段を画面に表示されている範囲に限定
                '@-----------------------
                '@最上段
                For llngCnt = llngRowTop To llngRowBottom
                    
                    '@選択された行が表示領域か
                    If .Rows(llngCnt).Visible = True Then
                        '@表示領域内の場合
                        
                        '@選択最上段行に設定
                        llngRowTop = llngCnt
                        Exit For
                    End If
                Next llngCnt
                
                '@-----------------------
                '@ 選択最下行が表示最下行より下かどうかを判定
                '@ 表示最下行の境目でRowIsVisibleが正しく判定されない為
                '@ →ｸﾞﾘｯﾄﾞの高さを縮めるとRowIsVisibleが正しく判定できるが、一番下にｽｸﾛｰﾙしたときに
                '@ 　ｾﾙのない部分が表示されてしまうので注意!!
                '@-----------------------
                If llngRowBottom > .TopRow + CMlngSlotMapPageRows - 1 Then
                    '@選択最下行が表示最下行より下の場合
                    
                    '@選択最下行に表示最下行を設定
                    llngRowBottom = .TopRow + CMlngSlotMapPageRows - 1
                End If

                llngRowBottom = 25
                llngRowTop = 1

                '@選択行数分ﾙｰﾌﾟ
                For llngCnt = llngRowBottom To llngRowTop Step -1
                
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        
                        '@=======================
                        '@ 分割WF戻し処理＆各種ﾎﾞﾀﾝ制御処理
                        '@=======================
                        Call prvWFTempDel_Proc(llngCnt)
            
                        '@分割先ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄ№格納
                        llngSlotNo = .GetData(llngCnt, CMlngColSlot)
                        
                        '@分割元ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄｾﾙ設定
                        vsfSlotMapStck.Row = mlngSlotMapRowS - llngSlotNo
                        
                        '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfSlotMapStck)
                        
                        '@分割WF戻し("<")ﾎﾞﾀﾝを無効にする
                        cmdDel.Enabled = False
                    End If
                Next llngCnt
                
            End With
            
            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck

                '@↓2020/03/26 (Thu) 17:10:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lstrTmpLotGRB = lblGrbClass.Text
                For llngCnt = llngRowBottom To llngRowTop Step -1
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        If .GetData(llngCnt, CMlngColGrbClass) <> lblGrbClass.Text Then
                            lstrTmpLotGRB = CPstrGRB_MIX
                            Exit For
                        End If
                    End If
                Next
        
                lblGrbClass.Text = lstrTmpLotGRB
                lblGrbClass.BackColor = pubGRBBackColor(lstrTmpLotGRB, lblFlowClass.BackColor)
                '@↑2020/03/26 (Thu) 17:10:39 Y.Yoneyama 「.Netへ反映未」 **************************************************

                '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfSlotMapStck)
                
                .Row = llngRowTop           'ｶﾚﾝﾄ行の設定
                .RowSel = llngRowBottom     '選択範囲の設定
            End With

            '@=======================
            '@ 分割元/分割先の背景色変更
            '@=======================
            Call prvGridGRBBackColorChange

            vsfSlotMapStck.ScrollPosition = New Point (vsfSlotMap.ScrollPosition.X,ScrollPosition.Y)
            vsfSlotMapStck.Redraw = True
            vsfSlotMap.ScrollPosition = New Point (vsfSlotMapStck.ScrollPosition.X,ScrollPosition.Y)  
            vsfSlotMap.Redraw = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDel_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap_Click
    '機　能：分割先ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub vsfSlotMap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟの選択時処理
            '@=======================
            Call vsfSlotMap_EnterCell(vsfSlotMap,New EventArgs)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap_EnterCell
    '機　能：分割先ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub vsfSlotMap_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap.EnterCell

        Dim llngCnt             As Integer      'ｶｳﾝﾄ
        Dim llngRowTop          As Integer      '選択最上段行
        Dim llngRowBottom       As Integer      '選択最下段行

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If
            
            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
                
                '@ﾀｲﾄﾙ行か
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If
                
                '@選択行が選択範囲行より下か
                If .Row < .RowSel Then

                    llngRowTop = .Row           '選択最上段行を格納
                    llngRowBottom = .RowSel     '選択最下段行を格納
                Else

                    llngRowTop = .RowSel        '選択最下段行を格納
                    llngRowBottom = .Row        '選択最上段行を格納
                End If
            End With
            
            
            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck
                
                '@選択行数分ﾙｰﾌﾟ
                For llngCnt = llngRowBottom To llngRowTop Step -1
                    
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟのWFIDのﾊﾞｯｸｶﾗｰがｸﾞﾚｰ、またはWFIDがNULLか
                    If .GetCellRange(llngCnt, CMlngColWFID).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Or _
                        .GetData(llngCnt, CMlngColWFID) = vbNullString Then
                        
                        '@分割(">")ﾎﾞﾀﾝを無効にする
                        cmdMove.Enabled = False
                        Exit For
                    Else
                        '@分割元ｽﾛｯﾄﾏｯﾌﾟのWFIDのﾊﾞｯｸｶﾗｰが白、かつWFIDがNULL以外
                        
                        '@分割(">")ﾎﾞﾀﾝを有効にする
                        cmdMove.Enabled = True
                        
                    End If
                Next llngCnt
            End With
            
            
            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            '@選択行数分ﾙｰﾌﾟ
            For llngCnt = llngRowBottom To llngRowTop Step -1
                
                '@分割先ｽﾛｯﾄﾏｯﾌﾟのﾊﾞｯｸｶﾗｰが灰色、またはWFIDがNULLか
                If vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Or _
                    vsfSlotMap.GetData(llngCnt, CMlngColWFID) = vbNullString Then
                    
                    '@分割WF戻し("<")ﾎﾞﾀﾝを無効にする
                    cmdDel.Enabled = False
                    Exit Sub
                Else
                
                    '@分割WF戻し("<")ﾎﾞﾀﾝを有効にする
                    cmdDel.Enabled = True

                End If
            Next llngCnt
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap_EnterCell"
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
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Dim llngNowByte     As Integer  '現在のﾊﾞｲﾄ数

        Try
            
            '@現在のﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@=======================
            '@ 現在のﾊﾞｲﾄ数を表示処理(表示ﾒｯｾｰｼﾞ変換)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
                           
            '@=======================
            '@ ﾃｷｽﾄ変更時処理(ﾃｷｽﾄ共通仕様)
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：作業ﾒﾓ　ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：Shift,Ctrl,Altｷｰ状態
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try

            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理(ﾃｷｽﾄ共通仕様)
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：作業ﾒﾓ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：Shift,Ctrl,Altｷｰ状態
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.MouseUp

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更時処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
            
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
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
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
            '@ ﾃｷｽﾄ上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理(ﾃｷｽﾄ共通仕様)
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
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
            '@ ﾃｷｽﾄ下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理(ﾃｷｽﾄ共通仕様)
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClear_Click
    '機　能：取消ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
             
            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
                
                For llngCnt = 1 To mlngSlotMapRowS - 1
                    
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        
                        '@=======================
                        '@ 分割WF戻し処理＆各種ﾎﾞﾀﾝ制御処理
                        '@=======================
                        Call prvWFTempDel_Proc(llngCnt)
                    End If
                Next llngCnt
                
                '@分割元ｽﾛｯﾄﾏｯﾌﾟを有効にする
                .Enabled = True
            End With


            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck
                
                .Enabled = True             '有効
                .Row = vsfSlotMap.Row       '分割先ｽﾛｯﾄﾏｯﾌﾟの選択行
                .TopRow = vsfSlotMap.TopRow

                '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfSlotMapStck)
            End With

            '@=======================
            '@ 取消・削除("<")ﾎﾞﾀﾝ制御処理(無効化)
            '@=======================
            Call prvCmdDelClear_Proc(False)
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdRegist_Proc(False)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClear_Click"
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
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim ltypUsechange           As Lotdivide            'Lot分割(要求)
        Dim lstrMsg                 As String               '変換後ﾒｯｾｰｼﾞ1
        Dim lstrMsg2                As String               '変換後ﾒｯｾｰｼﾞ2
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim ltypChkDivderRecipe     As typChkDivderRecipe   'ﾒｯｾｰｼﾞ送信用構造体
        Dim llngMsgAns              As Integer              'ﾒｯｾｰｼﾞﾎﾞｯｸｽの結果格納
        Dim llngCnt2                As Integer
        Dim llngCnt3                As Integer
        Dim lstrResult              As String               '区間優先度判定結果格納
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If


            '@=======================
            '@ 確定時ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(mstrTmpOyaLotLGrbClass)
            
            '@確定時ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@分割親ﾛｯﾄのみ処理する場合
            If (pstrSBID = CPstrSBID1A0) And mstrTmpOyaLotLGrbClass <> vbNullString Then

                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ 作業者ｺｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
                
                '@作業者ｺｰﾄﾞが入力されたか
                If pstrUserID = vbNullString Then
                    
                    '@未入力の場合、処理終了
                    Exit Sub
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                mstrEventName = "cmdUseChange_Click"
                Call pubResponseStart(Me.Name, mstrEventName)
                
                '@=======================
                '@ GRB属性設定
                '@ ※最終更新日時は、確定時に返される値を使う。ﾒｯｾｰｼﾞ関数内で書き換えている。
                '@=======================
                lblnAns = pubblnLotChgGrb_Upd(CMstrlot_chggrbclassVer, _
                                                   lblLotID.Text, _
                                                   pstrUserID, _
                                                   lblGrbClass.Text, _
                                                   mstrLotLastUpdate)
               
                '@GRB属性設定結果が"登録/更新成功"か
                  If lblnAns = True Then
                        

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
                    
                    '@=======================
                    '@ 画面初期化処理
                    '@=======================
                    Call prvFrmxxEN02M0_Init()

                '@GRB属性設定結果が"False：失敗"の場合
                Else
            
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                End If
                
            Else

                '@構造体に値をｾｯﾄ
                With ltypChkDivderRecipe
                    .strSbID = pstrSBID
                    .strLotID = lblLotID.Text
                    
                    '@ｳｪﾊｰﾘｽﾄを格納
                    llngCnt2 = 1
                    llngCnt3 = 1
                    If .strWfList Is Nothing Then
                        .strWfList = New List(Of String)
                    Else
                        .strWfList.Clear
                    End If
                    Dim strWfListTmp As String

                    Do While vsfSlotMapStck.Rows.Count > llngCnt2
                        If vsfSlotMapStck.GetData(llngCnt2, CMlngColWFID) <> vbNullString Then

                            strWfListTmp = vsfSlotMapStck.GetData(llngCnt2, CMlngColWFID)
                            .strWfList.Add(strWfListTmp)
                            llngCnt3 = llngCnt3 + 1
                        End If
                        llngCnt2 = llngCnt2 + 1
                    Loop
                    
                    .strDivLotID = lblDivideLotID.Text
                    
                    '@分割先ｳｪﾊｰﾘｽﾄを格納
                    llngCnt2 = 1
                    llngCnt3 = 1
                    If .strDiveWFList Is Nothing Then
                        .strDiveWFList = New List(Of String)
                    Else
                        .strDiveWFList.Clear
                    End If
                    Dim strDiveWFListTmp As String

                    Do While vsfSlotMap.Rows.Count > llngCnt2
                        If vsfSlotMap.GetData(llngCnt2, CMlngColWFID) <> vbNullString Then
                            strDiveWFListTmp = vsfSlotMap.GetData(llngCnt2, CMlngColWFID)
                            .strDiveWFList.Add(strDiveWFListTmp)
                            llngCnt3 = llngCnt3 + 1
                        End If
                        llngCnt2 = llngCnt2 + 1
                    Loop
                
                End With
                
                '@***********************
                '@ 分割前に枚葉ﾚｼﾋﾟが全て空になる工程が無いかﾁｪｯｸ
                '@***********************
                lblnAns = prvblnDivideWfRecipeNull_Chk(CMstrlot_dividerecipeVer, ltypChkDivderRecipe)
                
                '@確定時ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
                If lblnAns = False Then
                    Exit Sub
                End If
                
                '@ﾒｯｾｰｼﾞがある場合継続or中断のﾒｯｾｰｼﾞ表示
                If ltypChkDivderRecipe.strMsgCode <> vbNullString Then
                
                    '@"<MESI0001>$$レシピが未設定な工程が存在しますが、[ロット分割]を実行しますか....
                    pstrDMsg = pubstrMsgReplace_Set(CPstrStartMsgCode & ltypChkDivderRecipe.strMsgCode & _
                                                    CPstrEndMsgCode & CPstrMsgCrCode & ltypChkDivderRecipe.strMsg)
                    llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                    '@結果確認
                    If llngMsgAns = vbNo Then
                        '@いいえの場合は処理中止
                        Exit Sub
                    End If
                    
                End If
                
                '@***********************
                '@ 分割元ﾛｯﾄに区間優先度設定があるかﾁｪｯｸ
                '@***********************
                lblnAns = prvblnLotSectionPriority_Chk(CMstrlot_chksecpriorityVer, pstrLotID, lstrResult)
                
                '@確定時ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
                If lblnAns = False Then
                    Exit Sub
                End If
                
                '@結果「1」の場合継続or中断のﾒｯｾｰｼﾞ表示
                If lstrResult = CPstrOne Then
                
                    '@"<TRM79I>$$分割元ロット[%1]には区間優先設定がされています。$分割先ロットに区間優先設定はコピーされませんので、$必要に応じ再設定してください。$よろしいですか？"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0079, pstrLotID)
                    llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                    '@結果確認
                    If llngMsgAns = vbNo Then
                        '@いいえの場合は処理中止
                        Exit Sub
                    End If
                    
                End If

                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ 作業者ｺｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
                
                '@作業者ｺｰﾄﾞが入力されたか
                If pstrUserID = vbNullString Then
                    
                    '@未入力の場合、処理終了
                    Exit Sub
                End If
            
                '@***********************
                '@ 分割確定ﾃﾞｰﾀ作成
                '@***********************
                With ltypUsechange
                    
                    '@移載工程ｽｷｯﾌﾟがﾁｪｯｸOFFか
                    If chkMoveSkip.Checked = False Then
                        .strMsgVer = CMstrlot_divide__Ver           '移載工程あり
                    Else
                        .strMsgVer = CMstrlot_dividedirectVer       '移載工程なし
                    End If
            
                    .strLotID = lblLotID.Text                    '分割元ﾛｯﾄID
            
                    If lblGrbClass.Text <> vbNullString Then     '分割元GRB区分
                        .strGrbClass = lblGrbClass.Text
                    Else
                        .strGrbClass = vbNullString
                    End If
                    
                    .strDivideLotID = lblDivideLotID.Text        '分割先ﾛｯﾄID
                    
                    If cmbDivideGrbSel.Text <> vbNullString Then    '分割先GRB区分
                        .strDivideGrbClass = cmbDivideGrbSel.Text
                    Else
                        .strDivideGrbClass = vbNullString
                    End If

                    If txtWorkMemo.Text <> vbNullString Then        '作業ﾒﾓ
                        .strComments = txtWorkMemo.Text & CMstrPipeString & CMstrGrbDivideComment
                    Else
                        .strComments = CMstrGrbDivideComment
                    End If

                    .strEmpID = pstrUserID                          '作業者ｺｰﾄﾞ
                    .strLotLastUpdate = mstrLotLastUpdate           '最終更新日時
                    .strToCarrierId = txtToCarrier.Text             '分割先ｷｬﾘｱID(ｱﾝﾛｰﾀﾞｷｬﾘｱID)
                    
                    '@ｽﾛｯﾄﾏｯﾌﾟ処理
                    If .typWFMap Is Nothing Then
                        .typWFMap = New List(Of DivideWFMap)
                    Else
                        .typWFMap.Clear
                    End If

                    For llngCnt = 1 To mlngVsfBottomRow

                        Dim typWFMapTmp As New DivideWFMap

                        typWFMapTmp.strSlotPosition = _
                            CStr(Format$(llngCnt, CPstrSlotNoFormat))                      'ｽﾛｯﾄ№
                        typWFMapTmp.strWfId = _
                            vsfSlotMap.GetData(mlngSlotMapRowS - llngCnt, CMlngColWFID)    'WFID

                        .typWFMap.Add(typWFMapTmp)

                    Next llngCnt
                End With
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                mstrEventName = "cmdUseChange_Click"
                Call pubResponseStart(Me.Name, mstrEventName)
                
                '@移載工程ｽｷｯﾌﾟのﾁｪｯｸがOFFか
                If chkMoveSkip.Checked = False Then
                    
                    '@=======================
                    '@ ﾛｯﾄ分割(移載工程あり)
                    '@=======================
                    lblnAns = pubblnLotDivide_Upd(ltypUsechange, _
                                                  lstrGuidMsg, _
                                                  lstrGuidMsgCode)
                    
                    lstrMsg = "ロット分割予約"
                    
                    '@"<TRM30I>$$[%1]しました。分割元キャリア[%2] 分割元ロット[%3] 分割先ロット[%4]"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0030, lstrMsg, txtCarrier.Text, lblLotID.Text, lblDivideLotID.Text)
            
                Else
                
                    '@=======================
                    '@ ﾛｯﾄ分割(移載工程なし)
                    '@=======================
                    lblnAns = pubblnLotDivideDirect_Upd(ltypUsechange, lstrGuidMsg, lstrGuidMsgCode)
                    
                    lstrMsg = "ロット分割"
                    
                    '@"<TRM31I>$$[%1]しました。分割元キャリア[%2] 分割元ロット[%3] 分割先キャリア[%4] 分割先ロット[%5]"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0031, lstrMsg, txtCarrier.Text, lblLotID.Text, txtToCarrier.Text, lblDivideLotID.Text)
            
                End If
                    
                '@ﾛｯﾄ分割結果が"True：成功"か
                If lblnAns = True Then
            
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
                    
                    '@=======================
                    '@ ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ表示制御
                    '@=======================
                    Call pubGuidMsg_Set(lstrGuidMsgCode, lstrGuidMsg, Me)
                    
                    '@成功ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@起動SBが"1A0：基板"、かつ移載工程ｽｷｯﾌﾟか(♪移載工程ｽｷｯﾌﾟの場合はこのﾀｲﾐﾝｸﾞで表示)
                    If pstrSBID = CPstrSBID1A0 And chkMoveSkip.Checked = True Then
                
                        '@ﾛｯﾄの種別が"試作/実験品：GG,TS,WS,ZZ"か
                        If lblFlowClass.Text = CPstrFlowClassGG Or _
                            lblFlowClass.Text = CPstrFlowClassTS Or _
                            lblFlowClass.Text = CPstrFlowClassWS Or _
                            lblFlowClass.Text = CPstrFlowClassZZ Then
                            
                            '@表示ﾒｯｾｰｼﾞを編集(分割元ロット[XXX] 分割先ロット[XXX])
                            lstrMsg = CPstrDivideFrom & CPstrBrLeft & lblLotID.Text & CPstrBrRight
                            lstrMsg2 = CPstrDivideTo & CPstrBrLeft & lblDivideLotID.Text & CPstrBrRight
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM1ZI>$$%1が[%2]されました。$検査工数削減の為、必要に応じて外観・現像検査工程の
                            '@ 検査ウェハ枚数を見直して下さい。$%3 %4"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0024, CPstrLot, CPstrDivide, lstrMsg, lstrMsg2)
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                        End If
                    End If
            
                    '@=======================
                    '@ 画面初期化処理
                    '@=======================
                    Call prvFrmxxEN02M0_Init()
                Else
                    '@ﾛｯﾄ分割結果が"False：失敗"の場合
            
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                End If

            End If
            
            '@ｷｬﾘｱIDﾃｷｽﾄが無効か
            If txtCarrier.Enabled = False Then
                
                '@ｷｬﾘｱIDﾃｷｽﾄを有効にする
                txtCarrier.Enabled = True
            End If

            '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
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

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '========================================Private========================================

    '関数名：prvFrmxxEN02M0_Init
    '機　能：画面初期化処理
    '引　数：lblnCarrier    ：True：ｷｬﾘｱ項目削除、False：ｷｬﾘｱ項目未削除
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvFrmxxEN02M0_Init(Optional ByVal lblnCarrier As Boolean = True)

        Dim llngNowByte         As Integer      'ﾊﾞｲﾄ数格納
        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@=======================
            '@ 機能毎関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02M0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            '@ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝ
            cmdLotSelect.Text = "投入予定" & vbCrLf & "ロット選択"
            
            '@引数で"True：ｷｬﾘｱ項目削除"が渡されたか
            If lblnCarrier = True Then
                
                '@ｷｬﾘｱIDを初期化
                txtCarrier.Text = vbNullString
            End If
            
            '@-----------------------
            '@ ｱﾝﾛｰﾀﾞｷｬﾘｱの初期設定
            '@-----------------------
            With txtToCarrier
                
                .Text = vbNullString                                 'NULL
                .Enabled = False                                     '無効
                .GotBackColor = SystemColors.ControlLight            'ｸﾞﾚｰ
                .BackColor = SystemColors.ControlLight               'ｸﾞﾚｰ
            End With
            
            '@各種ﾗﾍﾞﾙの初期化
            lblLotID.Text = vbNullString             'ﾛｯﾄID
            lblFlowClass.Text = vbNullString         '種別ｺｰﾄﾞ
            lblStatus.Text = vbNullString            '状態
            lblOpID.Text = vbNullString              '大工程名
            lblStepID.Text = vbNullString            '小工程名
            lblDivideLotID.Text = vbNullString       '分割先ﾛｯﾄID
            lblDivideFlowClass.Text = vbNullString   '分割先種別ｺｰﾄﾞ
            lblGrbClass.Text = vbNullString          '分割元GRB区分
            '@↓2020/03/26 (Thu) 15:33:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGrbClass.BackColor = lblDivideFlowClass.BackColor
            '@↑2020/03/26 (Thu) 15:33:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
            
            '@ｺﾝﾎﾞﾎﾞｯｸｽの初期化
            cmbDivideGrbSel.Clear                                    '分割先GRB区分
            cmbDivideGrbSel.Enabled = False                          '無効
            cmbDivideGrbSel.CausesValidation = False                 'Validate処理不要
            cmbDivideGrbSel.BackColor = SystemColors.ControlLight    'ｸﾞﾚｰ(ﾊﾞｯｸｶﾗｰ)
            
            '@作業ﾒﾓ初期化
            With txtWorkMemo
                
                .ChrMaxByte = CPlngLotCommentsMaxByte   '2048byte
                .Text = vbNullString                    'NULL
                llngNowByte = .NowByte                  '現状のﾊﾞｲﾄ数を格納
                
                '@=======================
                '@ 現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                '@=======================
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            End With
            
            txtWorkMemo.Enabled = False                     'ｺﾒﾝﾄ：無効
            
            '@=======================
            '@ ｽﾛｯﾄﾏｯﾌﾟの初期化
            '@=======================
            Call prvvsfSlotMap_init(vsfSlotMapStck)         '左：分割元
            Call prvvsfSlotMap_init(vsfSlotMap)             '右：分割先

            '@両ｽﾛｯﾄﾏｯﾌﾟ共に初期値は無効
            vsfSlotMapStck.Enabled = False                  '分割元ｽﾛｯﾄﾏｯﾌﾟ
            vsfSlotMap.Enabled = False                      '分割先ｽﾛｯﾄﾏｯﾌﾟ

            '@各種ﾎﾞﾀﾝの初期化
            cmdLotSelect.Enabled = False                    '投入予定ﾛｯﾄ選択
            cmdClear.Enabled = False                        '一括取消
            cmdRegist.Enabled = False                       '確定
            cmdUP.Enabled = False                           '分割元ｽﾛｯﾄﾏｯﾌﾟの上(▲)ｽｸﾛｰﾙ
            cmdDown.Enabled = False                         '分割元ｽﾛｯﾄﾏｯﾌﾟの下(▼)ｽｸﾛｰﾙ
            cmdMove.Enabled = False                         '移動( > )
            cmdDel.Enabled = False                          '戻す( < )
            
            '@空きｷｬﾘｱ選択ﾎﾞﾀﾝの初期化
            cmdCarrierSelect.Enabled = False                '無効
            cmdCarrierSelect.CausesValidation = False       'Validate処理不要
            
            '@移載工程ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽの初期化
            chkMoveSkip.Enabled = False                     '無効
            chkMoveSkip.Checked = False                     'ﾁｪｯｸOFF
            
            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mstrCarrier = vbNullString                      'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
            mstrLotLastUpdate = vbNullString                'ﾛｯﾄ最終更新日時
            mstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟID(LOADER側)
            mstrTmpOyaLotLGrbClass = vbNullString           '親ﾛｯﾄGRB区分(子ﾛｯﾄ無し時設定)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN02M0_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxEN02M0_Disp
    '機　能：画面情報表示処理
    '引　数：ltypLotprestate：ﾛｯﾄ現在状態格納構造体
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvFrmxxEN02M0_Disp(ByRef ltypLotprestate As Lotprestate)

        Try
            
            '@ﾛｯﾄ情報の表示
            With ltypLotprestate
                
                lblLotID.Text = .strLotID                'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass        '流動区分
                lblOpID.Text = .strOpID                  '大工程
                lblStatus.Text = .strNowST               'ﾛｯﾄ状態
                lblStepID.Text = .strStepID              '小工程
                mstrLotLastUpdate = .strLotLastUpdate    '最終更新日時
                lblGrbClass.Text = .strGrbClass          '分割元GRB区分
                '@↓2020/03/26 (Thu) 15:34:31 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGrbClass.BackColor = pubGRBBackColor(.strGRBClass, lblFlowClass.BackColor)
                '@↑2020/03/26 (Thu) 15:34:31 Y.Yoneyama 「.Netへ反映未」 **************************************************   
                mstrOyaLotLGrbClass = .strGrbClass       '親ﾛｯﾄGRB区分

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN02M0_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMap_Init
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ初期化処理
    '引　数：lobjControl    ：対象ｸﾞﾘｯﾄﾞ
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvvsfSlotMap_init(ByRef lobjControl As C1FlexGrid)

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try
            
            '@引数で渡されたｵﾌﾞｼﾞｪｸﾄが「ｸﾞﾘｯﾄﾞ」か
            If TypeOf lobjControl Is C1FlexGrid Then

                With lobjControl

                    '@-----------------------
                    '@ 各種ﾌﾟﾛﾊﾟﾃｨ設定
                    '@-----------------------
                    .Clear(ClearFlags.Content)
                    .Cols.Count = CMlngColNum                                                                 '列数
                    .Rows.Count = CMlngSlotMapRowS                                                            '行数                                         
                    Dim cellRange As CellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngColSlot, CMlngSlotMapRowTitle, CMlngColGrbClass)              '表題
                    Dim headerStyle As CellStyle = .Styles.Add("headerStyle")       
                    headerStyle.ForeColor = Color.Yellow                                                                                                '文字色                             
                    headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                                 '背景色
                    headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngSlotHMaCellFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)   'ﾌｫﾝﾄｻｲｽﾞ
                    headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                                  '表題表示位置(中央)                                                                             
                    cellRange.Style = headerStyle
                    .Rows(CMlngSlotMapRowTitle).Height = CMlngSlotMapHHeight                             '高さ
                    .Cols(CMlngColBatchId).Visible = False                                               '非表示行選択
                    
                    '@Slot№設定
                    For llngCnt = 1 To CMlngSlotMapRowS - 1
                        
                        .SetData(llngCnt, CMlngColSlot, _
                            CStr(Format$(CMlngSlotMapRowS - llngCnt, CPstrSlotNoFormat)))

                        .Rows(llngCnt).Height = CMlngSlotMapHeight
                    Next llngCnt
                           
                    '@-----------------------
                    '@ 列幅、ﾀｲﾄﾙ設定
                    '@-----------------------
                    '@ｽﾛｯﾄID
                    .Cols(CMlngColSlot).Width = CMlngColSlotWidth
                    .SetData(CMlngSlotMapRowTitle, CMlngColSlot, CMstrSlotMapColTSlot)
                    
                    '@WFID
                    .Cols(CMlngColWFID).Width = CMlngColWFIDWidth
                    .SetData(CMlngSlotMapRowTitle, CMlngColWFID, CMstrSlotMapColTWFID)
                    
                    '@GRB区分
                    .Cols(CMlngColGrbClass).Width = CMlngColGrbClassWidth
                    .SetData(CMlngSlotMapRowTitle, CMlngColGrbClass, CMstrSlotMapColTGrbClass)
                                
                    '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                    .Cols(CMlngColSlot).TextAlign = TextAlignEnum.CenterCenter

                    '@スロットマップの色指定
                    ’@ここで色指定をしないと背景色を後で取得できない
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                    cellRange = .GetCellRange(CMlngSlotMapRowTitle + 1, CMlngColWFID, .Rows.Count - 1, CMlngColGrbClass)
                    cellRange.Style = newStyle

                    '@ﾛｯｸ
                    .Enabled = False
                    
                    '@初期表示行番号設定
                    .TopRow = CMlngSlotMapSTopRow
                    
                End With
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMap_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMap_Set
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ表示処理
    '引　数：ltypWaferInfo  ：ﾛｯﾄWF情報
    '　　　：lobjControl    ：対象ｸﾞﾘｯﾄﾞ
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvvsfSlotMap_Set(ByRef ltypWaferList As Waferlist, _
                                  ByRef lobjControl As Object)

        Dim llngCnt                 As Integer      'ｷｬﾘｱのｶｳﾝﾄ数
        Dim llngWriteRow            As Integer      '書き込む行
        Dim mstrGrbClassWork        As String       '親ﾛｯﾄの作業用GRB区分
        Dim lblnGrbClassWorkChk     As Boolean      '戻り値
        Dim llngCnt2                As Integer      'ｶｳﾝﾄ

        Try
            
            '@引数で渡されたｵﾌﾞｼﾞｪｸﾄが「ｸﾞﾘｯﾄﾞ」か
            If TypeOf lobjControl Is C1FlexGrid Then

                vsfSlotMapStck.Redraw = False
                vsfSlotMap.Redraw = False

                '@ｽﾛｯﾄﾏｯﾌﾟの最大ｽﾛｯﾄ数をｷｬﾘｱに応じたｽﾛｯﾄ数に変更
                vsfSlotMapStck.Rows.Count = ltypWaferList.strSlotSize + 1
                vsfSlotMap.Rows.Count = ltypWaferList.strSlotSize + 1
                
                vsfSlotMapStck.Redraw = True
                vsfSlotMap.Redraw = True

                '@-----------------------
                '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ、分割先ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄ№を設定
                '@-----------------------
                '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                llngCnt = 1
                
                Do While vsfSlotMapStck.Rows.Count > llngCnt
                    
                    '@分割元
                    vsfSlotMapStck.SetData(vsfSlotMapStck.Rows.Count - llngCnt, CMlngColSlot, _
                        Format$(llngCnt, CPstrSlotNoFormat))
                    
                    '@分割先
                    vsfSlotMap.SetData(vsfSlotMap.Rows.Count - llngCnt, CMlngColSlot, _
                        Format$(llngCnt, CPstrSlotNoFormat))
                    
                    '@ﾙｰﾌﾟｶｳﾝﾀを+1する
                    llngCnt = llngCnt + 1
                Loop

                '@-----------------------
                '@ WF情報の設定
                '@-----------------------
                '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                llngCnt = 0
                
                'Dim newStyleGRB As CellStyle
                'Dim cellRangeGRB As CellRange

                Do While ltypWaferList.lngListCnt -1 >= llngCnt
                    
                    With ltypWaferList.typWfList(llngCnt)
                        
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが数値か
                        If IsNumeric(.strSlotPosition) = True Then
                            
                            '@書き込み行設定(下から№01となる)
                            llngWriteRow = mlngVsfBottomRow + 1 - CLng(.strSlotPosition)
                            
                            '@WFID
                            lobjControl.SetData(llngWriteRow, CMlngColWFID, .strWfId)
                            
                            '@★ WF状態により処理分岐 ★
                            Select Case .strClass

                                '@〓 1：良品 〓
                                Case CPstrClass1

                                    lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass1J)    '"良品"を表示
                                
                                '@〓 2：不良 〓
                                Case CPstrClass2

                                    lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass2J)    '"不良"を表示
                                
                                '@〓 3：払出 〓
                                Case CPstrClass3

                                    lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass3J)    '"払出"を表示
                                
                                '@〓 4：保留 〓
                                Case CPstrClass4

                                    lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass4J)    '"保留"を表示
                                
                                '@〓 5：傾向 〓
                                Case CPstrClass5

                                    lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass5J)    '"傾向"を表示
                            
                            End Select
                            
                            '@GRB区分
                            lobjControl.SetData(llngWriteRow, CMlngColGrbClass, .strGrbClass)

                        End If
                        
                        '@ﾙｰﾌﾟｶｳﾝﾀを+1する
                        llngCnt = llngCnt + 1
                    
                    End With
                Loop
                
                lblnGrbClassWorkChk = False

                '@ｽﾛｯﾄﾏｯﾌﾟの件数ﾁｪｯｸ
                With vsfSlotMapStck
                    
                    '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                    llngCnt2 = 1
            
                    For llngCnt2 = 1 To mlngSlotMapRowS - 1
                        
                        '@WFIDがNULL以外か
                        If .GetData(llngCnt2, CMlngColGrbClass) <> vbNullString Then
                            
                            If mstrGrbClassWork = vbNullString Then
                                 mstrGrbClassWork = .GetData(llngCnt2, CMlngColGrbClass)
                                 lblnGrbClassWorkChk = True
                                 
                            End If
                            
                            If mstrGrbClassWork <> .GetData(llngCnt2, CMlngColGrbClass) Then
                            lblnGrbClassWorkChk = False
                                                      Exit For
                            End If
                            
                        End If
                    Next llngCnt2
                End With

                '@親単体の場合は非選択
                If lblnGrbClassWorkChk = True Then
            
                    '@GRB区分を設定
                    lblGrbClass.Text = mstrGrbClassWork
                    '@↓2020/03/26 (Thu) 15:36:24 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    lblGrbClass.BackColor = pubGRBBackColor(mstrGrbClassWork, lblFlowClass.BackColor)
                    '@↑2020/03/26 (Thu) 15:36:24 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    '@各種ｺﾝﾄﾛｰﾙを無効にする
                    cmdLotSelect.Enabled = False                 '投入予定ﾛｯﾄ選択ﾎﾞﾀﾝ
                    chkMoveSkip.Enabled = False                  '移載ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽ
                    
                    '@分割先GRB区分が未選択の場合
                    If cmbDivideGrbSel.Text = vbNullString Then
            
                        mstrTmpOyaLotLGrbClass = mstrGrbClassWork
                            
                        '@=======================
                        '@ 確定ﾎﾞﾀﾝ制御処理(有効化)
                        '@=======================
                        Call prvCmdRegist_Proc(True)
                    
                    End If
                
                End If
                
                '@-----------------------
                '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ(WFがない場所または、既にｺｰﾄﾞが入っている個所(基本的にない)を灰色に変更する)
                '@-----------------------
                With vsfSlotMapStck
                    
                    '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                    llngCnt = 1
                    
                    Dim newStyle As CellStyle
                    Dim cellRange As CellRange

                    Do While .Rows.Count > llngCnt

                        '@WFIDがNULLか
                        If .GetData(llngCnt, CMlngColWFID) = vbNullString Then
                            '@分割元ｽﾛｯﾄﾏｯｯﾌﾟを灰色に変更
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                            cellRange = .GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColGrbClass)
                            cellRange.Style = newStyle           
                            
                            '@分割先ｽﾛｯﾄﾏｯｯﾌﾟを灰色に変更
                            newStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                            cellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColGrbClass)
                            cellRange.Style = newStyle 
                        Else
                            '@分割元ｽﾛｯﾄﾏｯｯﾌﾟを白色に変更
                            newStyle = .Styles.Add("CustomStyle_BackColor_White")
                            newStyle.BackColor = SystemColors.Window
                            cellRange = .GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColGrbClass)
                            cellRange.Style = newStyle
                            
                            '@分割先ｽﾛｯﾄﾏｯｯﾌﾟを白色に変更
                            newStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_White")
                            newStyle.BackColor = SystemColors.Window
                            cellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColGrbClass)
                            cellRange.Style = newStyle
                        End If
                        
                        '@ﾙｰﾌﾟｶｳﾝﾀを+1する
                        llngCnt = llngCnt + 1
                    Loop
                End With

                '@=======================
                '@ 分割元/分割先の背景色変更
                '@=======================
                Call prvGridGRBBackColorChange

            End If
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMap_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnVsfSlotMapCnt_Chk
    '機　能：ｽﾛｯﾄﾏｯﾌﾟのWF有無ﾁｪｯｸ
    '引　数：lobjControl    ：対象ｵﾌﾞｼﾞｪｸﾄ
    '戻り値：True：WFあり、False：WFなし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Function prvblnVsfSlotMapCnt_Chk(ByRef lobjControl As Object) As Boolean

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            '@戻り値の初期化
            prvblnVsfSlotMapCnt_Chk = False
            
            '@ｽﾛｯﾄﾏｯﾌﾟの件数ﾁｪｯｸ
            With lobjControl
                
                '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                llngCnt = 1

                For llngCnt = 1 To mlngSlotMapRowS - 1
                    
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        
                        '@戻り値に"True：WFあり"をｾｯﾄ
                        prvblnVsfSlotMapCnt_Chk = True
                        Exit Function
                    End If
                Next llngCnt
            End With
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnVsfSlotMapCnt_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvVsfSlotMapBackColor_Set
    '機　能：ｽﾛｯﾄﾏｯﾌﾟのｾﾙの背景色変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvVsfSlotMapBackColor_Set()

        Dim lctlControl     As Control      'ｺﾝﾄﾛｰﾙ名称取得用変数

        Try

            '@当ﾌｫｰﾑ内のｺﾝﾄﾛｰﾙが対象
            For Each lctlControl In GetAllControls(Me)
                
                '@ｸﾞﾘｯﾄﾞか
                If TypeOf lctlControl Is C1FlexGrid Then
                    

                    '@ｽﾛｯﾄﾏｯﾌﾟのｾﾙの背景色をｸﾞﾚｰに変更
                    Ctype(lctlControl,C1FlexGrid).Styles.HighLight.BackColor = ColorTranslator.FromWin32(CMlngBackColorCel)
                End If
            Next
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMapBackColor_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMapTopRow_Set
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの先頭行表示設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvVsfSlotMapTopRow_Set()

        Dim llngCnt         As Integer      'ｶｳﾝﾄ
        Dim llngRows        As Integer      '行数
        Dim lblnWFFlag      As Boolean      'WF有無ﾌﾗｸﾞ(True：WF有り、False：WF無し)

        Try
            
            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@ ※一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            '@-----------------------
            With vsfSlotMapStck
                
                '@分割元ｽﾛｯﾄﾏｯﾌﾟの行数取得
                llngRows = .Rows.Count
                
                '@最大ｽﾛｯﾄが25より小さいか
                If llngRows < CMlngSlotMapRowS Then
                    
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Fixed - 1
                    
                    '@分割先ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    vsfSlotMap.Row = vsfSlotMap.Rows.Fixed - 1
                    Exit Sub
                End If
                
                '@ｽﾛｯﾄ№01～10までWFがあるかﾁｪｯｸ
                For llngCnt = CMlngSlotMapRowS - 1 To CMlngSlotMapSlotNo10Row Step -1
                    
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        
                        '@WF有無ﾌﾗｸﾞに"True：WF有り"をｾｯﾄ
                        lblnWFFlag = True
                        Exit For
                    End If
                Next llngCnt
                
                '@ｽﾛｯﾄ№01～10にWFがない場合
                If lblnWFFlag = False Then
                    
                    '@ｽﾛｯﾄ№25～16までWFがあるかﾁｪｯｸ
                    For llngCnt = .Rows.Fixed To CMlngSlotMapSlotNo16Row
                        
                        '@WFIDがNULL以外か
                        If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                            
                            '@WF有無ﾌﾗｸﾞに"True：WF有り"をｾｯﾄ
                            lblnWFFlag = True
                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@WF有無ﾌﾗｸﾞに"False：WF無し"をｾｯﾄ
                    lblnWFFlag = False
                End If
                
                '@WF有無ﾌﾗｸﾞが"True：WF有り"か
                If lblnWFFlag = True Then
                    
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟの先頭行を"1"(最上行)にｾｯﾄ
                    .TopRow = .Rows.Fixed
                    
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Fixed - 1
                    
                    '@分割先ｽﾛｯﾄﾏｯﾌﾟの先頭行を設定
                    vsfSlotMap.TopRow = vsfSlotMapStck.Rows.Fixed
                    
                    '@分割先ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    vsfSlotMap.Row = vsfSlotMapStck.Rows.Fixed - 1
                Else
                    '@WF有無ﾌﾗｸﾞが"False：WF無し"の場合
                
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟの先頭行を最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№10の行番号にｾｯﾄ
                    .TopRow = CMlngSlotMapSlotNo10Row
                    
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Fixed - 1
                    
                    '@分割先ｽﾛｯﾄﾏｯﾌﾟの先頭行を設定
                    vsfSlotMap.TopRow = CMlngSlotMapSlotNo10Row
                    
                    '@分割先ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    vsfSlotMap.Row = vsfSlotMap.Rows.Fixed - 1
                End If
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMapTopRow_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnCmdRegist_Chk
    '機　能：確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
    '引　数：lblnVsfSlotMapNull ：分割先ｽﾛｯﾄﾏｯﾌﾟのWF有無を返す(True：なし)
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Function prvblncmdRegist_Chk(Optional ByRef lblnVsfSlotMapNull As Boolean = False) As Boolean

        Dim lblnRtn1    As Boolean      '分割元ｽﾛｯﾄﾏｯﾌﾟの件数格納
        Dim lblnRtn2    As Boolean      '分割先ｽﾛｯﾄﾏｯﾌﾟの件数格納

        Try

            '@戻り値の初期化
            prvblncmdRegist_Chk = False
            
            '@ｷｬﾘｱIDがNULLか
            If txtCarrier.Text = vbNullString Then
                Exit Function
            End If
            
            '@投入予定ﾛｯﾄIDがNULLか
            If lblLotID.Text = vbNullString Then
                Exit Function
            End If
            
            '@=======================
            '@ ｽﾛｯﾄﾏｯﾌﾟのWF有無ﾁｪｯｸ(分割元ｽﾛｯﾄﾏｯﾌﾟ)
            '@=======================
            lblnRtn1 = prvblnVsfSlotMapCnt_Chk(vsfSlotMapStck)
            
            '@分割元ｽﾛｯﾄﾏｯﾌﾟにWFがないか
            If lblnRtn1 = False Then
                Exit Function
            End If

            '@=======================
            '@ ｽﾛｯﾄﾏｯﾌﾟのWF有無ﾁｪｯｸ(分割先ｽﾛｯﾄﾏｯﾌﾟ)
            '@=======================
            lblnRtn2 = prvblnVsfSlotMapCnt_Chk(vsfSlotMap)
            
            '@分割先ｽﾛｯﾄﾏｯﾌﾟにWFがないか
            If lblnRtn2 = False Then
                
                '@分割先ｽﾛｯﾄﾏｯﾌﾟのWF有無に"True：WFなし"をｾｯﾄ
                lblnVsfSlotMapNull = True
                Exit Function
            End If
            
            '@移載工程ｽｷｯﾌﾟにﾁｪｯｸが付いているのに、ｱﾝﾛｰﾀﾞｷｬﾘｱが指定されていないか
            If chkMoveSkip.Checked = True And _
                txtToCarrier.Text = vbNullString Then

                Exit Function
            End If
            
            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblncmdRegist_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnCmdRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCmdRegist_Proc
    '機　能：確定ﾎﾞﾀﾝ制御処理
    '引　数：lblnRtn    ：ﾎﾞﾀﾝの有効/無効(True or False)
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvCmdRegist_Proc(ByVal lblnRtn As Boolean)

        Try

            '@引数値により確定ﾎﾞﾀﾝの有効/無効を制御
            cmdRegist.Enabled = lblnRtn
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdRegist_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmdDelClear_Proc
    '機　能：取消・削除("<")ﾎﾞﾀﾝ制御処理
    '引　数：lblnRtn    ：ﾎﾞﾀﾝの有効/無効(True or False)
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvCmdDelClear_Proc(ByVal lblnRtn As Boolean)

        Try

            '@引数値により各種ﾎﾞﾀﾝの有効/無効を制御
            cmdClear.Enabled = lblnRtn              '取消ﾎﾞﾀﾝ
            cmdDel.Enabled = lblnRtn                '削除ﾎﾞﾀﾝ

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdDelClear_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWFTempSet_Proc
    '機　能：分割元⇒分割先への移載処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvWFTempSet_Proc(ByVal llngRowTop As Integer, ByVal llngRowBottom As Integer)

        Dim ltypWFTmp       As WFTmp    'ｽﾛｯﾄﾏｯﾌﾟの内容格納のための構造体
        Dim llngCnt         As Integer  '汎用ｶｳﾝﾀ

        Try
            
            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟの値を格納
            '@-----------------------
            With vsfSlotMapStck

                .Redraw = False

                Dim styleGRB As CellStyle
                Dim cellGRB As CellRange

                For llngCnt = llngRowBottom To llngRowTop Step -1
                    
                    '@WFIDがNULLか
                    If vsfSlotMap.GetData(llngCnt, CMlngColWFID) = vbNullString Then
                        
                        If .GetData(llngCnt, CMlngColGrbClass) = cmbDivideGrbSel.Text Then
                        
                            ltypWFTmp.strWfId = .GetData(llngCnt, CMlngColWFID)                     'WFID
                            ltypWFTmp.strClass = .GetData(llngCnt, CMlngColClass)                   'WF状態
                            ltypWFTmp.strGrbClass = .GetData(llngCnt, CMlngColGrbClass)             'GRB区分
            
                            '@分割先ｽﾛｯﾄﾏｯﾌﾟへ反映
                            vsfSlotMap.SetData(llngCnt, CMlngColWFID, ltypWFTmp.strWfId)            'WFID
                            vsfSlotMap.SetData(llngCnt, CMlngColClass, ltypWFTmp.strClass)          'WF状態
                            vsfSlotMap.SetData(llngCnt, CMlngColGrbClass, ltypWFTmp.strGrbClass)    'GRB区分
                            '@↓2020/03/26 (Thu) 16:06:10 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            '@GRB背景色
                            styleGRB = .Styles.Add("GRBColor" + llngCnt.ToString)
                            styleGRB.BackColor = pubGRBBackColor(ltypWFTmp.strGRBClass, vsfSlotMap.GetCellStyle(llngCnt, CMlngColWFID).BackColor)
                            cellGRB = .GetCellRange(llngCnt, CMlngColGrbClass)
                            cellGRB.Style = styleGRB
                            '@↑2020/03/26 (Thu) 16:06:10 Y.Yoneyama 「.Netへ反映未」 **************************************************

                            '@分割元ｽﾛｯﾄﾏｯﾌﾟにNULLをｾｯﾄ
                            .SetData(llngCnt, CMlngColWFID, vbNullString)                         'WFID
                            .SetData(llngCnt, CMlngColClass, vbNullString)                        'WF状態
                            .SetData(llngCnt, CMlngColGrbClass, vbNullString)                     'GRB区分
                            '@↓2020/03/26 (Thu) 16:04:29 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            styleGRB = .Styles.Add("GRBColor_white")
                            styleGRB.BackColor = .GetCellStyle(llngCnt, CMlngColWFID).BackColor
                            cellGRB = .GetCellRange(llngCnt, CMlngColGrbClass)
                            cellGRB.Style = styleGRB
                            '@↑2020/03/26 (Thu) 16:04:29 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        
                        End If

                    End If
                Next llngCnt

                .Redraw = True

            End With
                 
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWFTempSet_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWFTempDel_Proc
    '機　能：分割WF戻し処理＆各種ﾎﾞﾀﾝ制御処理
    '引　数：llngRow    ：対象行
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvWFTempDel_Proc(ByVal llngRow As Integer)

        Dim ltypWFTmp           As WFTmp        'ｽﾛｯﾄﾏｯﾌﾟの内容格納のための構造体
        Dim lblnRtn             As Boolean      '戻り値
        Dim llngRowTop          As Integer      '選択最上段行
        Dim llngRowBottom       As Integer      '選択最下段行

        Try

            '@分割先ｽﾛｯﾄﾏｯﾌﾟの情報を格納
            With vsfSlotMap
            
                ltypWFTmp.strSlotNo = .GetData(llngRow, CMlngColSlot)          'ｽﾛｯﾄNo
                ltypWFTmp.strWfId = .GetData(llngRow, CMlngColWFID)            'WFID
                ltypWFTmp.strClass = .GetData(llngRow, CMlngColClass)          'WF状態
                ltypWFTmp.strGrbClass = .GetData(llngRow, CMlngColGrbClass)    'GRB区分
                
                '@分割先ｽﾛｯﾄﾏｯﾌﾟの対象行に空白をｾｯﾄ
                .SetData(llngRow, CMlngColWFID, vbNullString)                 'WFID
                .SetData(llngRow, CMlngColClass, vbNullString)                'WF状態
                .SetData(llngRow, CMlngColGrbClass, vbNullString)             'GRB区分
                '@↓2020/03/26 (Thu) 16:11:25 Y.Yoneyama 「.Netへ反映未」 **************************************************
                '@GRB背景色
                'Dim styleGRB As CellStyle = .Styles.Add("GRBColor")
                'styleGRB.BackColor = .GetCellStyle(llngRow, CMlngColWFID).BackColor
                'Dim cellGRB As CellRange = .GetCellRange(llngRow, CMlngColGrbClass, llngRow, CMlngColGrbClass)
                'cellGRB.Style.BackColor = styleGRB.BackColor
                '@↑2020/03/26 (Thu) 16:11:25 Y.Yoneyama 「.Netへ反映未」 **************************************************

            End With
                    
            '@分割元ｽﾛｯﾄﾏｯﾌﾟへ戻し情報を反映
            With vsfSlotMapStck

                '@分割元ｽﾛｯﾄﾏｯﾌﾟの対象ｾﾙの背景色がｸﾞﾚｰ以外か
                If .GetCellStyleDisplay(llngRow,CMlngColSlot).BackColor <> ColorTranslator.FromWin32(CPlngGridDarkGray) Then

                    '@WFIDがNULLか
                    If .GetData(mlngSlotMapRowS - CInt(ltypWFTmp.strSlotNo), CMlngColWFID) = vbNullString Then

                        .SetData(mlngSlotMapRowS - CInt(ltypWFTmp.strSlotNo), CMlngColWFID, ltypWFTmp.strWfId)          'WFID
                        .SetData(mlngSlotMapRowS - CInt(ltypWFTmp.strSlotNo), CMlngColClass, ltypWFTmp.strClass)        'WF状態
                        .SetData(mlngSlotMapRowS - CInt(ltypWFTmp.strSlotNo), CMlngColGrbClass, ltypWFTmp.strGrbClass)  'GRB区分
                        '@↓2020/03/26 (Thu) 16:09:45 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        'Dim styleGRB As CellStyle = .Styles.Add("GRBColor")
                        'styleGRB.BackColor = .GetCellStyle(mlngSlotMapRowS - CInt(ltypWFTmp.strSlotNo), CMlngColWFID).BackColor
                        'Dim cellGRB As CellRange = .GetCellRange(mlngSlotMapRowS - ltypWFTmp.strSlotNo, CMlngColGrbClass, mlngSlotMapRowS - ltypWFTmp.strSlotNo, CMlngColGrbClass)
                        'cellGRB.Style.BackColor = styleGRB.BackColor
                        '@↑2020/03/26 (Thu) 16:09:45 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    End If
                Else
                    '@ｸﾞﾚｰの場合、処理終了
                    Exit Sub
                End If
            End With
            
            '@分割先ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(vsfSlotMap)

            With vsfSlotMap
                
                '@選択行が選択範囲行より下か
                If .Row < .RowSel Then
                    
                    llngRowTop = .Row           '選択最上段行を格納
                    llngRowBottom = .RowSel     '選択最下段行を格納
                Else
                    llngRowTop = .RowSel        '選択最下段行を格納
                    llngRowBottom = .Row        '選択最上段行を格納
                End If
            End With
            
            '@=======================
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ選択確定時処理
            '@=======================
            Call vsfSlotMapStck_EnterCell(vsfSlotMapStck,New EventArgs)
            
            '@=======================
            '@ ｽﾛｯﾄﾏｯﾌﾟのWF有無ﾁｪｯｸ(分割元ｽﾛｯﾄﾏｯﾌﾟ)
            '@=======================
            lblnRtn = prvblnVsfSlotMapCnt_Chk(vsfSlotMap)
            
            '@ﾁｪｯｸ結果が"False：WFなし"か
            If lblnRtn = False Then
                
                '@=======================
                '@ 取消・削除("<")ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdDelClear_Proc(False)
            Else
                '@ﾁｪｯｸ結果が"True：WFあり"か

                '@=======================
                '@ 取消・削除("<")ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdDelClear_Proc(True)
            End If
                    
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
            '@=======================
            lblnRtn = prvblncmdRegist_Chk
            
            '@確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：ﾁｪｯｸOK"か
            If lblnRtn = True Then
                
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdRegist_Proc(True)
            Else
                
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdRegist_Proc(False)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWFTempDel_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：確定時ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2016/02/14 (Sun) 15:58:55 H.Hayashi
    '更新日：
    '備　考：
    Private Function prvblnInput_Chk(ByVal strOyaOnlyGrb As String) As Boolean

        Dim llblRtn     As Boolean      '戻り値

        Try

            '@戻り値の初期化
            prvblnInput_Chk = False
            
            '@-----------------------
            '@ 分割元情報のﾁｪｯｸ
            '@-----------------------
            '@ｷｬﾘｱIDがNULLか
            If txtCarrier.Text = vbNullString Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@ｷｬﾘｱIDの桁数が6桁未満か
            If LenB(txtCarrier.Text) < CPlngCarrierMaxLength Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If

            '@分割元ﾛｯﾄIDがNULLか
            If lblLotID.Text = vbNullString Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM22W>$$ロットIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0022)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@=======================
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟのWF有無ﾁｪｯｸ
            '@=======================
            llblRtn = prvblnVsfSlotMapCnt_Chk(vsfSlotMapStck)
            
            '@"False：WF無し"か
            If llblRtn = False Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM38W>$$全数分割はできません。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0038)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfSlotMapStck)
                Exit Function
            End If

            '@分割元GRB区分が未設定の場合
            If strOyaOnlyGrb = vbNullString Then
            
                '@-----------------------
                '@ 分割先情報のﾁｪｯｸ
                '@-----------------------
                '@=======================
                '@ 分割先ｽﾛｯﾄﾏｯﾌﾟのWF有無ﾁｪｯｸ
                '@=======================
                llblRtn = prvblnVsfSlotMapCnt_Chk(vsfSlotMap)
                
                '@"False：WF無し"か
                If llblRtn = False Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM39W>$$ウエハIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0039)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@分割先ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfSlotMap)
                    Exit Function
                End If
                
            
                '@-----------------------
                '@ 移載工程ｽｷｯﾌﾟのﾁｪｯｸ
                '@-----------------------
                '@移載工程ｽｷｯﾌﾟがﾁｪｯｸONか
                If chkMoveSkip.Checked = True Then
                    
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLか
                    If txtToCarrier.Text = vbNullString Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtToCarrier)
                        Exit Function
                    End If
                    
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDの桁数が6桁未満か
                    If LenB(txtToCarrier.Text) < CPlngCarrierMaxLength Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtToCarrier)
                        Exit Function
                    End If
                End If
                
            
                '@分割元と分割先のGRB区分を確認
                If lblGrbClass.Text = cmbDivideGrbSel.Text Then
                            
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM140W>$$GRB設定が同じです。$GRB設定を見直して下さい。"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0140)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbDivideGrbSel)
                    Exit Function
                
                End If
               
            End If
            
            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblnInput_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInput_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvGrbInfo_Disp
    '機　能：GRB区分ｺｰﾄﾞをｺﾝﾎﾞへｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:23:40 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvGrbInfo_Disp(ByRef ltypMasDefineAns As MasDefineAns)
        
        Dim llngCnt     As Integer  'ｶｳﾝﾄ

        Try
            
            With cmbDivideGrbSel
            
                .Clear

                For llngCnt = 0 To ltypMasDefineAns.lngMasDefineListCnt -1
                    '@GRB区分ｺｰﾄﾞ
                    .AddItem(ltypMasDefineAns.typMasDefineList(llngCnt).strName)
                Next llngCnt
                
                '@GRB区分ｺｰﾄﾞが１件の場合
                If .ListCount = 1 Then
                    '@１件目表示
                    .ListIndex = 0
                End If
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGrbInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivideGrbSel_Change
    '機　能：GRB区分選択変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/12 (Fri) 09:29:34 H.Hayashi
    '更新日：
    '備　考：
    Private Sub cmbDivideGrbSel_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDivideGrbSel.Change

        Try
            
            '@=======================
            '@ 取消ﾎﾞﾀﾝ　押下＆Click時処理
            '@=======================
            cmdClear_Click(cmdClear,New EventArgs)

            '@分割(">")ﾎﾞﾀﾝを有効にする
            cmdMove.Enabled = True
                            
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

    '関数名：prvGridGRBBackColorChange
    '機　能：グリッドのGRBセルの背景色変更
    '引　数：なし
    '戻り値：なし
    '作成日：2020/11/06
    '更新日：
    '備　考：
    Private Sub prvGridGRBBackColorChange()
    
        Dim intCnt  As Integer

        Try

            If lblGrbClass.Text = vbNullString Then
                Exit Sub
            End If

            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck
                For intCnt = 1 To .Rows.Count -1
                    Dim styleGRB As CellStyle = .Styles.Add("GRBColor" + intCnt.ToString)
                    styleGRB.BackColor = pubGRBBackColor(.GetData(intCnt, CMlngColGrbClass), .GetCellStyle(intCnt, CMlngColWFID).BackColor)
                    Dim cellGRB As CellRange = .GetCellRange(intCnt, CMlngColGrbClass)
                    cellGRB.Style = styleGRB
                Next
            End With

            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
                For intCnt = 1 To .Rows.Count -1
                    Dim styleGRB As CellStyle = .Styles.Add("GRBColor" + intCnt.ToString)
                    styleGRB.BackColor = pubGRBBackColor(.GetData(intCnt, CMlngColGrbClass), .GetCellStyle(intCnt, CMlngColWFID).BackColor)
                    Dim cellGRB As CellRange = .GetCellRange(intCnt, CMlngColGrbClass)
                    cellGRB.Style = styleGRB
                Next
            End With
    
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGridGRBBackColorChange"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraFromLot.Paint, fraToLot.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
                                                                        vsfSlotMap.Enter,
                                                                        cmbDivideGrbSel.Enter,
                                                                        cmdCarrierSelect.Enter,
                                                                        chkMoveSkip.Enter,
                                                                        txtCarrier.Enter,
                                                                        vsfSlotMapStck.Enter,
                                                                        txtToCarrier.Enter,
                                                                        cmdMemoUp.Enter,
                                                                        cmdMemoDown.Enter,
                                                                        cmdClear.Enter,
                                                                        cmdLotSelect.Enter,
                                                                        cmdUp.Enter,
                                                                        cmdDown.Enter,
                                                                        cmdMove.Enter,
                                                                        cmdDel.Enter,
                                                                        cmdClose.Enter,
                                                                        cmdRegist.Enter,
                                                                        txtWorkMemo.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name,cmdCarrierSelect.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

    '関数名：vsfSlotMapStck_AfterScroll
    '機　能：グリッドスクロール時の動作
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/07/24 (Wed) 10:00:00 NSYS
    '備　考：
    Private Sub vsfSlotMapStck_AfterScroll(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfSlotMapStck.AfterScroll

        If Not IsNothing(Me.ActiveControl) Then
            If ActiveControl.Name = vsfSlotMapStck.Name Then
                vsfSlotMap.TopRow = vsfSlotMapStck.TopRow
            End If
        End If

    End Sub

    '関数名：vsfSlotMap_AfterScroll
    '機　能：グリッドスクロール時の動作
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/07/24 (Wed) 10:00:00 NSYS
    '備　考：
    Private Sub vsfSlotMap_AfterScroll(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfSlotMap.AfterScroll

        If Not IsNothing(Me.ActiveControl) Then
            If ActiveControl.Name = vsfSlotMap.Name Then
                vsfSlotMapStck.TopRow = vsfSlotMap.TopRow
            End If
        End If

    End Sub

End Class
