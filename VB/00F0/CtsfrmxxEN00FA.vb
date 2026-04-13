'ﾌｧｲﾙ名：xxEN00FA.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：WF情報(在庫管理サブフォーム)
'作成日：2005/09/01 (Thu) 14:24:17 N.Kojima
'更新日：2009/04/23 (Thu) 10:24:36 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00FA
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00FA    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00FA
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00FA
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00FA)
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
    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN00FA          'ﾛｰｶﾙ機能ID

    '@↓2009/04/15 (Wed) 10:10:36 N.Kojima **************************************************
    '@Msgﾊﾞｰｼﾞｮﾝ
    'Private Const CMstrinv_waferlistVer         As String = "03.01"                 'ｳｪﾊ在庫情報取得
    Private Const CMstrinv_waferlistVer         As String = "04.00"                 'ｳｪﾊ在庫情報取得
    '@↑2009/04/15 (Wed) 10:10:36 N.Kojima **************************************************

    '@vsfSlotMapの定数宣言(ｶﾗﾑ)
    '@↓2019/10/03 (Thu) 15:10:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMlngColSlot                  As Integer = 0                         'ｽﾛｯﾄ
    'Private Const CMlngColWFID                  As Integer = 1                         'WFID
    'Private Const CMlngColClassID               As Integer = 2                         'CALSSID
    'Private Const CMlngColClass                 As Integer = 3                         'CALSS
    'Private Const CMlngColChipQuantity          As Integer = 4                         '良品ﾁｯﾌﾟ数
    'Private Const CMlngColChipOutQuantity       As Integer = 5                         '不良ﾁｯﾌﾟ数
    'Private Const CMlngColChipForwardQuantity   As Integer = 6                         '払出ﾁｯﾌﾟ数
    'Private Const CMlngColChipMarkQuantity      As Integer = 7                         '傾向ﾁｯﾌﾟ数
    Private Const CMlngColSlot                  As Integer = 0                    'ｽﾛｯﾄ
    Private Const CMlngColWFID                  As Integer = 1                    'WFID
    Private Const CMlngColGRB                   As Integer = 2                    'GRB
    Private Const CMlngColClassID               As Integer = 3                    'CALSSID
    Private Const CMlngColClass                 As Integer = 4                    'WF状態
    Private Const CMlngColChipQuantity          As Integer = 5                    '良品ﾁｯﾌﾟ数
    Private Const CMlngColChipOutQuantity       As Integer = 6                    '不良ﾁｯﾌﾟ数
    Private Const CMlngColChipForwardQuantity   As Integer = 7                    '払出ﾁｯﾌﾟ数
    Private Const CMlngColChipMarkQuantity      As Integer = 8                    '傾向ﾁｯﾌﾟ数
    '@↑2019/10/03 (Thu) 15:10:20 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsfSlotMapの定数宣言(表示幅)
    Private Const CMlngColWSlot                 As Integer = 37                   'ｽﾛｯﾄ
    Private Const CMlngColWWFID                 As Integer = 97                   'WFID
    '@↓2019/10/03 (Thu) 15:13:50 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngColWGRB                  As Integer = 30                   'GRB
    '@↑2019/10/03 (Thu) 15:13:50 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngColWClassID              As Integer = 0                    'CALSSID
    Private Const CMlngColWClass                As Integer = 60                   'CALSS(状態名)
    Private Const CMlngColWChipQuantity         As Integer = 70                   '良品ﾁｯﾌﾟ数
    Private Const CMlngColWChipOutQuantity      As Integer = 70                   '不良ﾁｯﾌﾟ数
    Private Const CMlngColWChipForwardQuantity  As Integer = 70                   '払出ﾁｯﾌﾟ数
    Private Const CMlngColWChipMarkQuantity     As Integer = 70                   '傾向ﾁｯﾌﾟ数

    '@vsfSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrColTSlot                 As String = " "                   'ｽﾛｯﾄNO
    Private Const CMstrColTWFID                 As String = "WFID"                'WFID
    '@↓2019/10/03 (Thu) 15:14:06 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrColTGRB                  As String = "GRB"                 'GRB
    '@↑2019/10/03 (Thu) 15:14:06 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrColTClassID              As String = "Class_ID"            'CLASS_ID
    Private Const CMstrColTClass                As String = "WF状態"              'CLASS
    Private Const CMstrColTChipQuantity         As String = "良品"                '良品ﾁｯﾌﾟ数
    Private Const CMstrColTChipOutQuantity      As String = "不良"                '不良ﾁｯﾌﾟ数
    Private Const CMstrColTChipForwardQuantity  As String = "払出"                '払出ﾁｯﾌﾟ数
    Private Const CMstrColTChipMarkQuantity     As String = "傾向"                '傾向ﾁｯﾌﾟ数

    '@ｸﾞﾘｯﾄﾞの初期値定数宣言
    Private Const CMlngSlotMapRowTitle          As Integer = 0                      'ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ
    Private Const CMlngSlotMapColTitle          As Integer = 0                      'ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ
    Private Const CMlngGridFixedCols            As Integer = 0                      'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngGridFixedRows            As Integer = 1                      'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngGridPageRows             As Integer = 25                     'ｽﾛｯﾄの行数
    Private Const CMlngGrid3DBlank              As Integer = 60                     'ｸﾞﾘｯﾄﾞの3D表示の余白
    Private Const CMlngSlotHMaCellFontSize      As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngSlotMapRowS              As Integer = 26                     '行数
    Private Const CMlngSlotMapHHeight           As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngSlotMapHeight            As Integer = 18                     '1ｽﾛｯﾄの高さ

    '@ﾚｽﾎﾟﾝｽ計測用
    Private Const CMstrFormName                 As String = "frmxxEN00FA"           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                 As String = "Form_Load "            'ｲﾍﾞﾝﾄ名(Form_Load)
    Private Const CMstrCmdChgPlanClick          As String = "cmdChgPlan_Click"      'ｲﾍﾞﾝﾄ名(cmdChgPlan_Click)
    Private Const CMstrCmdCancelPlanClick       As String = "cmdCancelPlan_Click"   'ｲﾍﾞﾝﾄ名(cmdCancelPlan_Click)

    '@その他
    Private Const CMlngPutTab                   As Integer = 0                         '受入在庫ﾀﾌﾞIndex
    Private Const CMlngFinishTab                As Integer = 3                         '完成在庫ﾀﾌﾞIndex
    Private Const CMstrKonsei                   As String = "混成"                  '複数ﾛｯﾄで編成されている場合
    Private Const CMstrTitleCaption             As String = "元ロットID"            '中間WF在庫から起動されている場合
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mtypInvWaferList                    As InvWaferList                     '在庫WFﾘｽﾄ格納構造体
    Private mtypLotCfkinuminfo                  As LotCfkinuminfo                   'CF数量格納構造体
    Private mstrSlotSize                        As String                           'ｽﾛｯﾄｻｲｽﾞ
    Private mlngChipQuantity                    As Integer                          '良品ﾁｯﾌﾟ計
    Private mlngChipOutQuantity                 As Integer                          '不良ﾁｯﾌﾟ計
    Private mlngChipForwardQuantity             As Integer                          '払出ﾁｯﾌﾟ計
    Private mlngChipMarkQuantity                As Integer                          '傾向ﾁｯﾌﾟ計
    Private mstrFirstSlotNo                     As String                           'ｽﾛｯﾄ№(有効WF№の最小値)
    Private mblnFormLoadFlag                    As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：起動時以外/False：起動時のみ)

    Private buttonProcessing                    As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                          'NSYS WindowCloseフラグ
    Private ReadOnly vbButtonFace               As Color = SystemColors.ControlLight 'NSYS ボタンの背景色定義
    Private ReadOnly vbWhite                        As Color = Color.white           'NSYS 白色定義
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
        'TODO
        '!! ↓要修正：グリッドに対応する「▲」「▼」ボタンの変数名に修正すること !!
        '!!           「▲」「▼」ボタンのないグリッドの設定は行わないので、削除すること !!
        ''NSYS スクロールバーなしグリッドのマウスホイール対応
        'pubVsfMouseWheelManager_Set(vsfSlotMap, cmdUp, cmdDown)
        '!! ↑ !!

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/01 (Thu) 14:52:16 N.Kojima
    '更新日：2009/04/23 (Thu) 10:34:18 N.Kojima
    '備　考：
    '　　　：2009/04/23 (Thu) 10:34:18 N.Kojima     ﾁｯﾌﾟ払出対応。(案件№03434)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean          'ﾛｯﾄ保留理由取得戻り値(True/False)

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN00FA_Init()
            
            '@=======================
            '@ WF情報一覧初期化処理
            '@=======================
            Call prvvsfSlotMap_init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
                    
            '@在庫管理-中間WF在庫Tabからの起動か
            If ptypCommonInfo.strSbID <> vbNullString Then
                
                '@=======================
                '@ WF情報一覧取得
                '@=======================
                lblnAns = pubblnInvWaferlist_Sel(CMstrinv_waferlistVer, _
                                                 ptypCommonInfo.strCarrierId, _
                                                 ptypCommonInfo.strSbID, _
                                                 mtypInvWaferList)
            Else
                '@中間WF在庫ﾀﾌﾞ以外からの起動
                
                '@=======================
                '@ WF情報一覧取得
                '@=======================
                lblnAns = pubblnInvWaferlist_Sel(CMstrinv_waferlistVer, _
                                                 ptypCommonInfo.strCarrierId, _
                                                 pstrSBID, _
                                                 mtypInvWaferList)
            End If
            
            '@WF情報一覧取得結果が"True：取得成功"か
            If lblnAns = True Then
                '@"True：取得成功"の場合

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@ｽﾛｯﾄﾏｯﾌﾟ取得(=0件)時処理
                If mtypInvWaferList.lngInvWaferListCnt = 0 Then
                    
                    '@TPALﾛｯﾄか(CF_FLAG=2)
                    If ptypCommonInfo.strCfFlag <> CPstrTwo Then
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM2ZW>$$ウエハ情報が設定されていません。"」のﾒｯｾｰｼﾞを表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002Z)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Exit Sub
                    End If
                End If
            Else
                '@"False：取得失敗"の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)

            'NSYS ヘッダ行を選択状態にする
            vsfSlotMap.Row = 0

            '@Form_Loadﾌﾗｸﾞに"True：起動成功"をｾｯﾄ
            pblnFormLoad = True
            
            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

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
    '作成日：2005/09/01 (Thu) 16:03:14 N.Kojima
    '更新日：2009/04/23 (Thu) 10:34:18 N.Kojima
    '備　考：
    '　　　：2009/04/23 (Thu) 10:34:18 N.Kojima     ﾁｯﾌﾟ払出対応。(案件№03434)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Try
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If mblnFormLoadFlag = False Then
                
                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化(2度目以降は全てTrue値で処理する為)
                mblnFormLoadFlag = True
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@=======================
                '@ WF情報一覧表示処理
                '@=======================
                Call prvVsfSlotMap_Disp(mtypInvWaferList)
                
                '@=======================
                '@ 画面表示処理
                '@=======================
                Call prvFrmxxEN00FA_Disp()
            Else
                '@2回目以降のﾌｫｰﾑが有効になる場合
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
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
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/09/01 (Thu) 16:28:56 N.Kojima
    '更新日：2009/04/23 (Thu) 10:34:18 N.Kojima
    '備　考：
    '　　　：2009/04/23 (Thu) 10:34:18 N.Kojima     ﾁｯﾌﾟ払出対応。(案件№03434)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@以下の場合、ｷｰｺｰﾄﾞを無効にして処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

            '@★ 押下ｷｰにより処理分岐 ★
            Select Case e.KeyCode

                '@〓 Enterｷｰ 〓
                Case Keys.Return

                    '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True

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
    '作成日：2005/09/01 (Thu) 16:52:04 N.Kojima
    '更新日：2009/04/23 (Thu) 10:34:18 N.Kojima
    '備　考：
    '　　　：2009/04/23 (Thu) 10:34:18 N.Kojima     ﾁｯﾌﾟ払出対応。(案件№03434)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If
            
            '@在庫WFﾘｽﾄ格納構造体の初期化
            mtypInvWaferList.typInvWaferList = Nothing
            mtypInvWaferList.lngInvWaferListCnt = 0
            
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
    '作成日：2005/09/01 (Thu) 16:52:31 N.Kojima
    '更新日：2009/04/23 (Thu) 10:34:18 N.Kojima
    '備　考：
    '　　　：2009/04/23 (Thu) 10:34:18 N.Kojima     ﾁｯﾌﾟ払出対応。(案件№03434)
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

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvFrmxxEN00FA_Init
    '機　能：ﾌｫｰﾑ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/01 (Thu) 16:55:01 N.Kojima
    '更新日：2009/04/23 (Thu) 10:34:18 N.Kojima
    '備　考：
    '　　　：2009/04/23 (Thu) 10:34:18 N.Kojima     ﾁｯﾌﾟ払出対応。(案件№03434)
    Private Sub prvFrmxxEN00FA_Init()

        Try
            
            '@変数の初期化
            mstrSlotSize = vbNullString                 'ｽﾛｯﾄｻｲｽﾞ
            mstrFirstSlotNo = vbNullString              '有効WFｽﾛｯﾄ№(Min)
            mlngChipQuantity = 0                        '良品ﾁｯﾌﾟ計
            mlngChipOutQuantity = 0                     '不良ﾁｯﾌﾟ計
            mlngChipForwardQuantity = 0                 '払出ﾁｯﾌﾟ計
            mlngChipMarkQuantity = 0                    '傾向ﾁｯﾌﾟ計
            
            '@在庫WFﾘｽﾄ格納構造体の初期化
            mtypInvWaferList.typInvWaferList = New List(Of InvWafer)
            mtypInvWaferList.lngInvWaferListCnt = 0
            
            '@ﾗﾍﾞﾙの初期化
            lblCarrier.Text = vbNullString           'ｷｬﾘｱID
            lblLotID.Text = vbNullString             'ﾛｯﾄID
            lblFlowClass.Text = vbNullString         '種別
            lblChipQuantity.Text = vbNullString              '良品ﾁｯﾌﾟ計
            lblChipOutQuantity.Text = vbNullString           '不良ﾁｯﾌﾟ計
            lblChipForwardQuantity.Text = vbNullString       '払出ﾁｯﾌﾟ計
            lblChipMarkQuantity.Text = vbNullString          '傾向ﾁｯﾌﾟ計
            
            '@終了時にValidateｲﾍﾞﾝﾄを実行しない
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN00FA_Init"
                .strErrMessage = vbNullString
            End With
            
            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMap_Init
    '機　能：WF情報一覧初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/01 (Thu) 16:56:38 N.Kojima
    '更新日：2009/04/23 (Thu) 10:34:18 N.Kojima
    '備　考：
    '　　　：2009/04/23 (Thu) 10:34:18 N.Kojima     ﾁｯﾌﾟ払出対応。(案件№03434)
    Private Sub prvvsfSlotMap_init()

        Dim llngCnt     As Integer  'ｶｳﾝﾄ
        Dim newStyle    As CellStyle    'NSYS セルスタイル
        Dim cellRange   As CellRange    'NSYS セルレンジ

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfSlotMap
                
                .Clear(ClearFlags.Content)                  'ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .SelectionMode = SelectionModeEnum.Row      '行単位
                .ExtendLastCol = True                       '最終列幅自動調整
                .AllowEditing = False                       '編集不可
                
                '@一覧表設定
                .Rows.Count = CMlngSlotMapRowS                                                                        '行数
                .BackColor = Color.White                                                                'ｾﾙ背景色：白
                Dim lfixedStyle As CellStyle
                lfixedStyle = .Styles.Fixed
                lfixedStyle.ForeColor = Color.Yellow                                                    '文字色
                lfixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                       '背景色
                With .Font                                                                              'ﾌｫﾝﾄｻｲｽﾞ
                    lfixedStyle.Font = New Font(.FontFamily, CMlngSlotHMaCellFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .Rows(CMlngSlotMapRowTitle).Height = CMlngSlotMapHHeight                                '高さ
                                
                '@一覧表のSlot№設定
                newStyle = .Styles.Add("CustomStyle_ForeColor_WindowText_BackColor_ControlLight_Font")
                newStyle.ForeColor = SystemColors.WindowText
                newStyle.BackColor = SystemColors.ControlLight
                newStyle.Font = .Styles.Normal.Font
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    .SetData(llngCnt, CMlngColSlot, _
                        CStr(Format$(CMlngSlotMapRowS - llngCnt, CPstrSlotNoFormat)))
                    .Rows(llngCnt).Height = CMlngSlotMapHeight
                    cellRange = .GetCellRange(llngCnt, CMlngColSlot)
                    cellRange.Style = newStyle
                Next llngCnt

                '@列幅、ﾀｲﾄﾙ設定
                '@ｽﾛｯﾄ№
                .Cols(CMlngColSlot).Width = CMlngColWSlot
                .SetData(CMlngSlotMapRowTitle, CMlngColSlot, CMstrColTSlot)
                
                '@WFID
                .Cols(CMlngColWFID).Width = CMlngColWWFID
                .SetData(CMlngSlotMapRowTitle, CMlngColWFID, CMstrColTWFID)

                '@↓2019/10/03 (Thu) 15:17:57 Y.Yoneyama 「.Netへ反映未」 **************************************************
                '@GRB
                .Cols(CMlngColGRB).Width = CMlngColWGRB
                .SetData(CMlngSlotMapRowTitle, CMlngColGRB, CMstrColTGRB)
        
                '@状態ID
                .Cols(CMlngColClassID).Width = CMlngColWClassID
                .SetData(CMlngSlotMapRowTitle, CMlngColClassID, CMstrColTClassID)
                '@↑2019/10/03 (Thu) 15:17:57 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                '@状態
                .Cols(CMlngColClass).Width = CMlngColWClass
                .SetData(CMlngSlotMapRowTitle, CMlngColClass, CMstrColTClass)
                
                '@良品ﾁｯﾌﾟ数
                .Cols(CMlngColChipQuantity).Width = CMlngColWChipQuantity
                .SetData(CMlngSlotMapRowTitle, CMlngColChipQuantity, CMstrColTChipQuantity)
                
                '@不良ﾁｯﾌﾟ数
                .Cols(CMlngColChipOutQuantity).Width = CMlngColWChipOutQuantity
                .SetData(CMlngSlotMapRowTitle, CMlngColChipOutQuantity, CMstrColTChipOutQuantity)
                
                '@払出ﾁｯﾌﾟ数
                .Cols(CMlngColChipForwardQuantity).Width = CMlngColWChipForwardQuantity
                .SetData(CMlngSlotMapRowTitle, CMlngColChipForwardQuantity, CMstrColTChipForwardQuantity)
                
                '@傾向ﾁｯﾌﾟ数
                .Cols(CMlngColChipMarkQuantity).Width = CMlngColWChipMarkQuantity
                .SetData(CMlngSlotMapRowTitle, CMlngColChipMarkQuantity, CMstrColTChipMarkQuantity)
                
                '@表示位置設定
                .Cols(CMlngColSlot).TextAlign = TextAlignEnum.RightCenter                  'ｽﾛｯﾄ№
                .Cols(CMlngColWFID).TextAlign = TextAlignEnum.LeftCenter                   'WFID
                '@↓2019/10/03 (Thu) 15:18:08 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngColGRB).TextAlign = TextAlignEnum.LeftCenter                    'GRB
                '@↑2019/10/03 (Thu) 15:18:08 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngColClass).TextAlign = TextAlignEnum.LeftCenter                  '状態
                .Cols(CMlngColClassID).TextAlign = TextAlignEnum.LeftCenter                '状態ID
                .Cols(CMlngColChipQuantity).TextAlign = TextAlignEnum.RightCenter          '良品ﾁｯﾌﾟ数
                .Cols(CMlngColChipOutQuantity).TextAlign = TextAlignEnum.RightCenter       '不良ﾁｯﾌﾟ数
                .Cols(CMlngColChipForwardQuantity).TextAlign = TextAlignEnum.RightCenter   '払出ﾁｯﾌﾟ数
                .Cols(CMlngColChipMarkQuantity).TextAlign = TextAlignEnum.RightCenter      '傾向ﾁｯﾌﾟ数
                
                '@↓2019/10/03 (Thu) 16:57:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
                '@非表示設定
                .Cols(CMlngColClassID).Visible = False

                .AutoSizeCol(CMlngColGRB)
                .AutoSizeCol(CMlngColChipMarkQuantity)
                '@↑2019/10/03 (Thu) 16:57:28 Y.Yoneyama 「.Netへ反映未」 **************************************************

                '@ﾛｯｸ
                .Enabled = False

            End With

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

    '関数名：prvVsfSlotMap_Disp
    '機　能：WF情報一覧表示処理
    '引　数：ltypInvWaferList：取得構造体
    '戻り値：なし
    '作成日：2005/09/01 (Thu) 16:04:44 N.Kojima
    '更新日：2009/04/23 (Thu) 10:34:18 N.Kojima
    '備　考：
    '　　　：2009/04/23 (Thu) 10:34:18 N.Kojima     ﾁｯﾌﾟ払出対応。(案件№03434)
    Private Sub prvVsfSlotMap_Disp(ByRef ltypInvWaferList As InvWaferList)

        Dim llngCnt         As Integer  'ｶｳﾝﾄ(=1:固定)
        Dim llngLoopCnt     As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngWriteRow    As Integer  '書き込み行

        Try

            '@ｽﾛｯﾄｻｲｽﾞの設定
            mstrSlotSize = ptypCommonInfo.strSlotSize

            With vsfSlotMap

                '@描画ﾛｯｸ
                .Redraw = False
                
                '@WF情報ﾃﾞｰﾀが1件以上あるか
                If ltypInvWaferList.lngInvWaferListCnt > 0 Then
                    '@ある場合
                    
                    '@取得WF枚数を退避
                    llngCnt = ltypInvWaferList.lngInvWaferListCnt
                    
                    '@-----------------------
                    '@ ｽﾛｯﾄﾏｯﾌﾟの表示変更
                    '@-----------------------
                    '@取得したｽﾛｯﾄｻｲｽﾞが数字か
                    If IsNumeric(mstrSlotSize) = True Then
                        '@数字の場合
                        
                        '@ｽﾛｯﾄｻｲｽﾞ以上のｽﾛｯﾄ№を空白に、背景色を灰色(ﾎﾞﾀﾝの表面の色)に変更(初期化)
                        For llngCnt = 1 To CMlngSlotMapRowS - 1
                            
                            If llngCnt <= CMlngSlotMapRowS - CLng(mstrSlotSize) - 1 Then
                                
                                '@ｽﾛｯﾄ№は空白
                                .SetData(llngCnt, CMlngColSlot, vbNullString)                         'ｽﾛｯﾄ№
                                
                                Dim newStyle1 As CellStyle = .Styles.Add("CustomStyle_BackColor_vbButtonFace")
                                newStyle1.BackColor = vbButtonFace
                                '@↓2019/10/03 (Thu) 16:13:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                'Dim cellRange1 As CellRange = .GetCellRange(llngCnt, CMlngColWFID)
                                Dim cellRange1 As CellRange = .GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColChipMarkQuantity)
                                '@↑2019/10/03 (Thu) 16:13:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                cellRange1.Style = newStyle1                    'WFID

                            Else
                                Dim newStyle1 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                                newStyle1.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                                '@↓2019/10/03 (Thu) 16:13:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                'Dim cellRange1 As CellRange = .GetCellRange(llngCnt, CMlngColWFID)
                                Dim cellRange1 As CellRange = .GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColChipMarkQuantity)
                                '@↑2019/10/03 (Thu) 16:13:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                cellRange1.Style = newStyle1               'WFID

                            End If
                        Next llngCnt
                    Else
                        '@ｽﾛｯﾄｻｲｽﾞが数字以外
                    
                        '@背景色を灰色(ﾎﾞﾀﾝの表面の色)に変更(初期化)
                        For llngCnt = 1 To CMlngSlotMapRowS - 1
                            
                            Dim newStyle1 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                            newStyle1.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                            '@↓2019/10/03 (Thu) 16:13:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            'Dim cellRange1 As CellRange = .GetCellRange(llngCnt, CMlngColWFID)
                            Dim cellRange1 As CellRange = .GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColChipMarkQuantity)
                            '@↑2019/10/03 (Thu) 16:13:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            cellRange1.Style = newStyle1               'WFID

                        Next llngCnt
                    End If


                    '@WF情報の設定
                    For llngLoopCnt = 0 To ltypInvWaferList.lngInvWaferListCnt -1
                        
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが数値か
                        If IsNumeric(ltypInvWaferList.typInvWaferList(llngLoopCnt).strSlotPosition) = True Then
                            
                            '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝの設定
                            llngWriteRow = CMlngSlotMapRowS - _
                                           CLng(ltypInvWaferList.typInvWaferList(llngLoopCnt).strSlotPosition)

                            .SetData(llngWriteRow, CMlngColWFID, _
                                ltypInvWaferList.typInvWaferList(llngLoopCnt).strWfId)                       'WF_ID

                            '@↓2019/10/03 (Thu) 15:20:01 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .SetData(llngWriteRow, CMlngColGRB, _
                                ltypInvWaferList.typInvWaferList(llngLoopCnt).strGRBClass)                   'GRB
                            '@↑2019/10/03 (Thu) 15:20:01 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                
                            .SetData(llngWriteRow, CMlngColClassID, _
                                ltypInvWaferList.typInvWaferList(llngLoopCnt).strWFStatusID)                 'ClassID
                                
                            .SetData(llngWriteRow, CMlngColClass, _
                                ltypInvWaferList.typInvWaferList(llngLoopCnt).strWFStatus)                   '状態
                            
                            .SetData(llngWriteRow, CMlngColChipQuantity, _
                                ltypInvWaferList.typInvWaferList(llngLoopCnt).strChipQuantity)               '良品ﾁｯﾌﾟ数
                            
                            .SetData(llngWriteRow, CMlngColChipOutQuantity, _
                                ltypInvWaferList.typInvWaferList(llngLoopCnt).strChipOutQuantity)            '不良ﾁｯﾌﾟ数
                            
                            .SetData(llngWriteRow, CMlngColChipForwardQuantity, _
                                ltypInvWaferList.typInvWaferList(llngLoopCnt).strChipForwardQuantity)        '払出ﾁｯﾌﾟ数
                            
                            .SetData(llngWriteRow, CMlngColChipMarkQuantity, _
                                ltypInvWaferList.typInvWaferList(llngLoopCnt).strChipMarkQuantity)           '傾向ﾁｯﾌﾟ数
                                    
                            '@背景色変更
                            Dim newStyle1 As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle1.BackColor = vbWhite
                            '@↓2019/10/03 (Thu) 16:13:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            'Dim cellRange1 As CellRange = .GetCellRange(llngWriteRow, CMlngColWFID)
                            Dim cellRange1 As CellRange = .GetCellRange(llngWriteRow, CMlngColWFID, llngWriteRow, CMlngColChipMarkQuantity)
                            cellRange1.Style = newStyle1                    'WFID

                            '@GRB背景色
                            Dim newStyleGRB As CellStyle = .Styles.Add("CustomStyle_BackColor_GRB" + llngWriteRow.ToString)
                            newStyleGRB.BackColor = pubGRBBackColor(ltypInvWaferList.typInvWaferList(llngLoopCnt).strGRBClass, Color.White)
                            Dim cellRangeGRB As CellRange = .GetCellRange(llngWriteRow, CMlngColGRB)
                            cellRangeGRB.Style = newStyleGRB
                            '@↑2019/10/03 (Thu) 16:13:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            
                            '@合計表示用に値(良品、不良、傾向)を格納
                            If .GetData(llngWriteRow, CMlngColChipQuantity) <> vbNullString Or _
                                .GetData(llngWriteRow, CMlngColChipOutQuantity) <> vbNullString Or _
                                .GetData(llngWriteRow, CMlngColChipMarkQuantity) <> vbNullString Then
                                
                                '@数量格納
                                mlngChipQuantity = mlngChipQuantity + CLng(.GetData(llngWriteRow, CMlngColChipQuantity))                       '良品
                                mlngChipOutQuantity = mlngChipOutQuantity + CLng(.GetData(llngWriteRow, CMlngColChipOutQuantity))              '不良
                                mlngChipForwardQuantity = mlngChipForwardQuantity + CLng(.GetData(llngWriteRow, CMlngColChipForwardQuantity))  '払出
                                mlngChipMarkQuantity = mlngChipMarkQuantity + CLng(.GetData(llngWriteRow, CMlngColChipMarkQuantity))           '傾向
                            End If
                        End If
                    
                    Next llngLoopCnt
                Else
                    '@ﾃﾞｰﾀなしの場合
                
                    '@背景色を灰色(ﾎﾞﾀﾝの表面の色)に変更(初期化)
                    For llngCnt = 1 To CMlngSlotMapRowS - 1
                        
                        Dim newStyle1 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                        newStyle1.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                        '@↓2019/10/03 (Thu) 16:13:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        'Dim cellRange1 As CellRange = .GetCellRange(llngCnt, CMlngColWFID)
                        Dim cellRange1 As CellRange = .GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColChipMarkQuantity)
                        cellRange1.Style = newStyle1  
                        '@↑2019/10/03 (Thu) 16:13:13 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    Next llngCnt
                End If
                
                '@↓2019/10/03 (Thu) 16:57:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .AutoSizeCol(CMlngColChipMarkQuantity)
                '@↑2019/10/03 (Thu) 16:57:28 Y.Yoneyama 「.Netへ反映未」 **************************************************

                '@描画ﾛｯｸ解除
                .Redraw = True
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMap_Disp"
                .strErrMessage = vbNullString
            End With
            
            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxEN00FA_Disp
    '機　能：画面情報表示
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/01 (Thu) 16:03:42 N.Kojima
    '更新日：2009/04/23 (Thu) 10:34:18 N.Kojima
    '備　考：
    '　　　：2005/11/08 (Tue) 14:19:58 N.Kojima     元ﾛｯﾄIDが複数ﾛｯﾄで構成されている場合の処理を追加。(運用障害№567)
    '　　　：2009/04/23 (Thu) 10:34:18 N.Kojima     ﾁｯﾌﾟ払出対応。(案件№03434)
    Private Sub prvFrmxxEN00FA_Disp()

        Try

            '@引継ぎ情報の表示
            With ptypCommonInfo
                
                lblCarrier.Text = .strCarrierId                  'ｷｬﾘｱID
                
                '@複数ﾛｯﾄで編成されている場合
                If plngLotStatus = 2 Then

                    lblLotID.Text = CMstrKonsei                  'ﾛｯﾄID(=混成)
                    lblFlowClass.Text = vbNullString             '流動区分(=NULL)
                Else
                    '@複数ﾛｯﾄでの編成ではない場合
                    
                    lblLotID.Text = .strLotID                    'ﾛｯﾄID
                    lblFlowClass.Text = .strFlowClass            '流動区分
                End If
                
                '@画面表示判定
                If plngLotStatus <> 0 Then
                    lblTitle1.Text = CMstrTitleCaption         'ﾀｲﾄﾙを"元ロットID"に変更
                End If
            
                '@TPALﾛｯﾄの場合
                If ptypCommonInfo.strCfFlag = CPstrTwo Then
                
                    lblChipQuantity.Text = .strChipQuantity      '良品ﾁｯﾌﾟ計
                    lblChipOutQuantity.Text = CPstrZero          '不良ﾁｯﾌﾟ計
                    lblChipForwardQuantity.Text = CPstrZero      '払出ﾁｯﾌﾟ計
                    lblChipMarkQuantity.Text = CPstrZero         '傾向ﾁｯﾌﾟ計
                Else
                    '@TPALﾛｯﾄ以外の場合
                    
                    lblChipQuantity.Text = CStr(mlngChipQuantity)                    '良品ﾁｯﾌﾟ計
                    lblChipOutQuantity.Text = CStr(mlngChipOutQuantity)              '不良ﾁｯﾌﾟ計
                    lblChipForwardQuantity.Text = CStr(mlngChipForwardQuantity)      '払出ﾁｯﾌﾟ計
                    lblChipMarkQuantity.Text = CStr(mlngChipMarkQuantity)            '傾向ﾁｯﾌﾟ計
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN00FA_Disp"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraWFInfo.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
