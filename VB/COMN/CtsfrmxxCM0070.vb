'ﾌｧｲﾙ名：xxCM0070.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：WFの不良/保留/払出し画面
'作成日：2004/03/23 (Tue) 10:13:14 T.Oide
'更新日：2014/11/25 (Tue) 09:16:51 T.Oide
'備　考：メニュー起動：xxCM0080.bas 　　　　　　　が必要。
'　　　：単独起動　　：xxCM0080.bas xxEN0180.bas が必要。
'　　　：2005/03/01 (Tue) 09:35:50 S.Deguchi    不具合№261/352/561の対応を追加
'　　　：2005/05/20 (Fri) 09:06:15 S.Deguchi    不具合№820対応を追加
'　　　：2005/08/26 (Fri) 11:12:58 S.Deguchi    On Error/SetFocus対応
'　　　：2011/10/19 (Wed) 17:04:46 T.Oide       払出、保留時の確認ﾒｯｾｰｼﾞ対応
'　　　：2012/12/17 (Mon) 10:47:50 T.Oide       権限の常時チェック
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM0070
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM0070    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM0070
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM0070
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM0070)
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
    '@↓2012/12/17 (Mon) 09:39:06 T.Oide **************************************************
    '@↓2020/03/06 (Fri) 10:33:31 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion             As String = "11.06"         '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion             As String = "11.07"         '機能ﾊﾞｰｼﾞｮﾝ
    '@↑2020/03/06 (Fri) 10:33:31 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN0180  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 13:03:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer         As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer          As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 13:03:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_insprst_Ver          As String = "02.01"        '不良保留払出傾向登録結果登録
    '@↓2010/06/17 (Thu) 19:36:49 Y.Yoneyama **************************************************
    Private Const CMstrlot_waferlistVer         As String = "02.05"         'ﾛｯﾄWF情報取得(新)
    '@↑2010/06/17 (Thu) 19:36:49 Y.Yoneyama **************************************************
    Private Const CMstrmas_reasoncodeVer        As String = "02.00"         '理由ｺｰﾄﾞ取得
    Private Const CMstrmas_empname_Ver          As String = "02.01"         '作業者名取得
    Private Const CMstrmas_scplist_Ver          As String = "03.00"         '不良項目入力項目取得
    Private Const CMstrwf__directscrapVer       As String = "02.01"         'WF直接廃棄処理

    '@vsfCodeListのｶﾗﾑ定数
    Private Const CMlngVsfCodeListCode          As Integer = 0              'ｺｰﾄﾞのｶﾗﾑ
    Private Const CMlngVsfCodeListName          As Integer = 1              '名称のｶﾗﾑ

    '@vsfWFListのｶﾗﾑ定数
    Private Const CMlngVsfWFListSlotNo          As Integer = 0              'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝのｶﾗﾑ
    Private Const CMlngVsfWFListWFID            As Integer = 1              'WFID
    Private Const CMlngVsfWFListClassID         As Integer = 2              'ｸﾗｽIDのｶﾗﾑ
    Private Const CMlngVsfWFListClass           As Integer = 3              'ｸﾗｽのｶﾗﾑ(隠し)(1:良品、2：不良、3：払出し、4：保留)
    Private Const CMlngVsfWFListChange          As Integer = 4              '変更可否(1：変更可、0：変更不可)

    '@vsfWFListのﾌﾟﾛﾊﾟﾃｨ定数
    Private Const CMlngvsfRowHeight             As Integer = 38             '行の高さ
    Private Const CMlngVsfWFListVisibleRows     As Integer = 10             '表示行数
    Private Const CMlngVsfDispRows              As Integer = 10             '画面の表示行数(ｽｸﾛｰﾙﾎﾞﾀﾝの計算で使用)
    Private Const CMlngvsfBottomRow             As Integer = 25             '画面の一番下の行(WF№01の行)
    Private Const CMlngvsfTitle                 As Integer = 0              'ﾌﾚｯｸｽｸﾞﾘｯﾄﾞのﾀｲﾄﾙ行
    Private Const CMlngVsfWFListRows            As Integer = 26             'ｽﾛｯﾄﾏｯﾌﾟの行数
    Private Const CMlngSlotNo10Row              As Integer = 17             '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№10の行番号
    Private Const CMlngSlotNo16Row              As Integer = 11             '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№16の行番号

    '@色宣言
    Private Const CMlngEnableTrueColor          As Integer = &H80000005     '白(使用可)

    '@Class定数
    Private Const CMstrClssRyouHin              As String = "良品"          '良品
    Private Const CMstrClssScrap                As String = "不良"          '不良
    Private Const CMstrClssTake                 As String = "払出"          '払出し
    Private Const CMstrClssHold                 As String = "保留"          '保留

    '@表示ﾒｯｾｰｼﾞ
    Private Const CMstrEmpIDTitle               As String = "責任者ID"      '責任者ID

    '@特殊流動中ﾌﾗｸﾞ用
    Private Const CMstrReworkFlag0              As String = "0"             '特殊流動なし
    Private Const CMstrReworkFlag1              As String = "1"             '分割先(子)特殊流動中
    Private Const CMstrReworkFlag2              As String = "2"             '分割元(親)特殊流動中
    Private Const CMstrReworkFlag3              As String = "3"             '全数特殊流動中
    Private Const CMstrReworkFinishFlag0        As String = "0"             '特殊流動工程ﾌﾗｸﾞ_通常工程
    Private Const CMstrReworkFinishFlag1        As String = "1"             '特殊流動工程ﾌﾗｸﾞ_最終工程
    Private Const CMlngReworkLen                As Integer = 3              '特殊流動状態桁数
    Private Const CMlngReworkLen1               As Integer = 1              '特殊流動桁
    Private Const CMlngReworkLen2               As Integer = 2              '特殊流動桁
    Private Const CMlngReworkLen3               As Integer = 3              '特殊流動桁

    '@画面表示ﾒｯｾｰｼﾞ用
    Private Const CMstrMsgSpecialR              As String = "リワーク"      'ﾘﾜｰｸ
    Private Const CMstrMsgSpecialA              As String = "追加流動"      '追加流動

    '@定数宣言
    Private Const CMlngChangeOK                 As Integer = 1              '変更可
    Private Const CMlngChangeNG                 As Integer = 0              '変更不可
    Private Const CMstrHandWork                 As String = "0"             'ﾊﾝﾄﾞﾜｰｸ
    Private Const CMstrLotEventMove             As String = "2"             '移載
    Private Const CMstrLotEventLotOut           As String = "3"             'ﾛｯﾄ終了
    Private Const CMstrLotEventScrap            As String = "4"             'WF廃棄
    Private Const CMstrResultPartScrap          As String = "1"             '部分WF廃棄
    Private Const CMstrResultAllScrap           As String = "2"             'ﾛｯﾄｱｳﾄ全数WF廃棄

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                 As String = "frmxxCM0070"           '自ﾌｫｰﾑ名
    Private Const CMstrTxtCarrierValidate       As String = "txtCarrier_Validate"   'ｷｬﾘｱ確定時処理
    Private Const CMstrCmdScrapCodeClick        As String = "cmdScrapCode_Click"    '不良ﾎﾞﾀﾝ押下＆Click時処理
    Private Const CMstrCmdTakeReasonClick       As String = "cmdTakeReason_Click"   '払出ﾎﾞﾀﾝ押下＆Click時処理
    Private Const CMstrCmdHoldReasonClick       As String = "cmdHoldReason_Click"   '保留ﾎﾞﾀﾝ押下＆Click時処理
    Private Const CMstrCmdConfirmClick          As String = "cmdConfirm_Click"      '不良/保留/払出登録処理
    Private Const CMstrCmdScrapClick            As String = "cmdScrap_Click"        'WF廃棄処理

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypMasScrapList                    As MasItemList              '不良入力項目ﾘｽﾄ
    Private mtypMasHoldList                     As MasItemList              '保留入力項目ﾘｽﾄ
    Private mtypMasTakeList                     As MasItemList              '払出し項目ﾘｽﾄ
    Private mtypLotInsprst                      As LotInsprst               '変更登録ﾃﾞｰﾀ格納構造体
    Private mtypDirectScrap                     As DirectScrap              '廃棄登録ﾃﾞｰﾀ格納構造体
    Private mstrClass                           As String                   '1:良品、2:払出し、3:保留
    Private mstrCarrier                         As String                   'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mblnTakeOverDispFlg                 As Boolean                  '引継ぎ表示ﾌﾗｸﾞ
    Private mlngVsfBottomRow                    As Integer                  '画面の一番下の行(WF№01の行)
    Private mstrWPTYPE                          As String                   'WP_TYPE(=0：ﾊﾝﾄﾞﾜｰｸ/1：装置)

    Private mblnFuryouClass                     As Boolean                  '不良存在判定ﾌﾗｸﾞ(True：不良あり、False：不良なし)
    Private mblnHaraidashiClass                 As Boolean                  '払出存在判定ﾌﾗｸﾞ(True：払出あり、False：払出なし)
    '@↓2011/10/19 (Wed) 16:54:36 T.Oide **************************************************
    Private mblnHoryuClass                      As Boolean                  '保留存在判定ﾌﾗｸﾞ(True：保留あり、False：保留なし)
    '@↑2011/10/19 (Wed) 16:54:36 T.Oide **************************************************
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
        pubVsfMouseWheelManager_Set(vsfWFList, cmdUp2, cmdDown2)
        pubVsfMouseWheelManager_Set(vsfCodeList, cmdUp1, cmdDown1)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　Load時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 10:51:33 T.Oide
    '更新日：2008/04/22 (Tue) 11:15:10 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 11:15:10 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_Load()
        
        Dim lblnAns                 As Boolean      '戻り値

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@=======================
            '@　機能ﾊﾞｰｼﾞｮﾝの判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0180, CMstrLocalVersion)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            'NSYS フォーム位置設定
            Me.Top = 0
            Me.Left = 0 - My.Settings.FormOffset

            '@ﾌｫｰﾑ起動区分が子画面としての起動か
            If pblnfrmxxCM0070Kbn = True Then
                '@子画面起動の場合
                
                '@=======================
                '@　画面初期化処理
                '@=======================
                Call prvFrmxxCM0070_Init()
                
                '@ｷｬﾘｱIDの設定
                With txtCarrier
                    .Locked = False                             'ｷｬﾘｱを入力可(Validateの実行の為)
                    .Text = ptypCommonInfo.strCarrierId         '引継ぎｷｬﾘｱｾｯﾄ
                    .TabIndex = cmdClose.TabIndex + 1           '初期表示を不良ﾎﾞﾀﾝに設定
                    .GotHighLight = False                       'ﾊｲﾗｲﾄ設定：ﾊｲﾗｲﾄなし
                    .TabStop = False                            'ﾀﾌﾞｽﾄｯﾌﾟ：無効
                End With
                        
                '@=======================
                '@　ｷｬﾘｱIDのValidate処理
                '@=======================
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                
                '@ｷｬﾘｱ情報表示出来ない場合
                If pblnFormLoad = False Then
                
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                    Exit Sub
                End If
                
                '@ｷｬﾘｱを入力不可
                txtCarrier.Locked = True
                
                '@=======================
                '@　全部取消および確定ﾎﾞﾀﾝの有効/無効処理
                '@　(ここでは必ず無効となる)
                '@=======================
                Call prvCmdButtonControl_Proc()
            Else
                '@単独の場合
                
                '@=======================
                '@　画面初期化処理
                '@=======================
                Call prvFrmxxCM0070_Init()
                
                '@=======================
                '@　単独起動時初期化処理
                '@=======================
                Call prvIndependentLoad_Init()
                
                '@=======================
                '@　各種ﾎﾞﾀﾝ制御処理(使用不可)
                '@=======================
                Call prvFrmxxCM0070_CmbInit(False)
            End If
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            '@引継ぎ情報表示済みﾌﾗｸﾞ
            mblnTakeOverDispFlg = False

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
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 15:58:34 H.Wajima
    '更新日：2008/04/22 (Tue) 11:21:37 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 11:21:37 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@子画面としての起動か
            If pblnfrmxxCM0070Kbn = True Then
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@引継ぎ情報表示済みﾌﾗｸﾞの判定
            '@FormLoad後、最初の1回しか処理しない
            If mblnTakeOverDispFlg = True Then
                '@引継ぎ情報が表示済みの場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@引継ぎ情報表示済みﾌﾗｸﾞにTrueを設定する
            mblnTakeOverDispFlg = True

            '@引数のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@NULL以外の場合
                
                '@ｷｬﾘｱIDに引継ぎｷｬﾘｱIDをｾｯﾄする
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                
                '@=======================
                '@　ｷｬﾘｱIDのValidate処理
                '@=======================
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
            End If

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰ押下時処理
    '引　数：KeyCode：入力されたキー
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 10:02:29 T.Oide
    '更新日：2008/04/22 (Tue) 11:27:16 N.Kojima
    '備　考：
    '　　　：2005/01/05 (Wed) 09:29:25 H.Wajima     ｸﾞﾘｯﾄﾞの外でﾏｳｽのﾎﾞﾀﾝを離した時の対応。
    '　　　：2008/04/22 (Tue) 11:27:16 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@以下の条件の場合、入力されたｷｰを無効にし処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If
            
            '@=======================
            '@　不良ｺｰﾄﾞ一覧ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfCodeList, cmdUP1, cmdDown1)
            
            '@=======================
            '@　WF情報ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfWFList, cmdUP2, cmdDown2, False)
            
            
            '@子画面起動か
            If pblnfrmxxCM0070Kbn = True Then
                '@子画面起動の場合
            
                Select Case e.KeyCode
                    
                    '@Enterｷｰの場合
                    Case Keys.Return
                        
                        '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙがWF情報ｸﾞﾘｯﾄﾞか
                        If ActiveControl.Name = vsfWFList.Name Then
                            '@WF情報ｸﾞﾘｯﾄﾞのｸﾘｯｸ処理
                            
                            '@=======================
                            '@　不良ｺｰﾄﾞ等をWFへ記入する処理
                            '@=======================
                            Call prvVsfWFList_Set()
                            
                            '@=======================
                            '@　各種ﾎﾞﾀﾝの制御処理
                            '@=======================
                            Call prvCmdButtonControl_Proc()
                            
                            Exit Sub
                        End If
                        
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                End Select
            Else
                '@単独起動の場合
            
                Select Case e.KeyCode
                    
                    '@Enterｷｰの場合
                    Case Keys.Return
                        
                        '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙがｷｬﾘｱIDか
                        If ActiveControl.Name = txtCarrier.Name Then
                        
                            '@=======================
                            '@　ｷｬﾘｱIDのValidate処理
                            '@=======================
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Exit Sub
                        End If
                        
                        '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙがWF情報ｸﾞﾘｯﾄﾞか
                        If ActiveControl.Name = vsfWFList.Name Then

                            '@=======================
                            '@　不良ｺｰﾄﾞ等をWFへ記入する処理
                            '@=======================
                            Call prvVsfWFList_Set()
                            
                            '@=======================
                            '@　各種ﾎﾞﾀﾝの制御処理
                            '@=======================
                            Call prvCmdButtonControl_Proc()
                            
                            Exit Sub
                        End If
                        
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
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
    '機　能：ﾌｫｰﾑ　終了処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：
    '作成日：2004/04/20 (Tue) 10:55:28 N.Kasai
    '更新日：2008/04/22 (Tue) 11:36:40 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 15:01:59 N.Kasai      閉じるﾎﾞﾀﾝ統合。
    '　　　：2008/04/22 (Tue) 11:36:40 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm         As Boolean          '開放結果格納
        Dim ltypeListInit       As MasItemList      '不良入力項目構造体、保留入力項目構造体、払出項目構造体初期化用
        Dim ltypLotInsprst      As LotInsprst       '変更登録ﾃﾞｰﾀ格納構造体初期化用
        Dim ltypDirectScrap     As DirectScrap      '廃棄登録ﾃﾞｰﾀ格納構造体初期化用

        Try
            
            '@×にて閉じた場合か
            If mblnCloseFromControlMenu Then
                
                '@=======================
                '@　閉じるﾎﾞﾀﾝ押下時処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@各構造体初期化
            mtypMasScrapList = ltypeListInit        '不良入力項目構造体
            mtypMasHoldList = ltypeListInit         '保留入力項目構造体
            mtypMasTakeList = ltypeListInit         '払出項目構造体
            mtypLotInsprst = ltypLotInsprst         '変更登録ﾃﾞｰﾀ格納構造体
            mtypDirectScrap = ltypDirectScrap       '廃棄登録ﾃﾞｰﾀ格納構造体
            mblnFuryouClass = False                 '不良存在判定ﾌﾗｸﾞ
            mblnHaraidashiClass = False             '払出存在判定ﾌﾗｸﾞ
        '@↓2011/10/19 (Wed) 16:55:15 T.Oide **************************************************
            mblnHoryuClass = False                  '保留判定ﾌﾗｸﾞ
        '@↑2011/10/19 (Wed) 16:55:15 T.Oide **************************************************


            '@子画面起動か
            If pblnfrmxxCM0070Kbn = True Then
                '@子画面起動の場合
            
                '@ﾌｫｰﾑ起動区分を初期化
                pblnfrmxxCM0070Kbn = False
            Else
                '@単独起動の場合
            
                '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
                pblnFormLoad = False
                
                '@ActInitﾌﾗｸﾞの判定
                If pblnActInitFlg = True Then
                    '@Actを自前で初期化した場合
                    
                    '@=======================
                    '@　ACTｵﾌﾞｼﾞｪｸﾄの開放処理
                    '@=======================
                    lblnAnsTerm = pubblnAct_Term
                Else
                    '@=======================
                    '@　ﾒｲﾝﾒﾆｭｰ画面拡張処理
                    '@=======================
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

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/11 (Fri) 15:05:26 K.Takano
    '更新日：2008/04/22 (Tue) 12:37:31 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 12:37:31 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            
            '@子画面起動か
            If pblnfrmxxCM0070Kbn = True Then
                '@子画面起動の場合
                Exit Sub
            Else
                '@単独起動の場合
                
                '@=======================
                '@　画面初期化処理(ｷｬﾘｱID未編集)
                '@=======================
                Call prvFrmxxCM0070_Init(False)
                
                '@=======================
                '@　WF情報ｸﾘｱ(固定行および列以外をｸﾘｱ)
                '@=======================
                vsfWFList.Clear(ClearFlags.Content, vsfWFList.Rows.Fixed, vsfWFList.Cols.Fixed, vsfWFList.Rows.Count-1, vsfWFList.Cols.Count-1)
                
                '@=======================
                '@　各種ﾎﾞﾀﾝ制御処理(使用不可)
                '@=======================
                Call prvFrmxxCM0070_CmbInit(False)
            End If

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
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　確定時処理
    '引　数：Cancel：ｷｬﾝｾﾙ値(True:ﾌｫｰｶｽを留める、False:ﾌｫｰｶｽ移動)
    '戻り値：なし
    '作成日：2004/04/20 (Tue) 14:58:34 N.Kasai
    '更新日：2008/04/22 (Tue) 12:39:36 N.Kojima
    '備　考：
    '　　　：2004/09/03 (Fri) 13:20:00 T.Kitagawa   不良入力項目取得Msg変更対応
    '　　　：2004/09/21 (Tue) 21:12:15 H.Wajima     不良ｺｰﾄﾞが0件の場合、払出ｺｰﾄﾞをﾃﾞﾌｫﾙﾄ表示するよう変更。(№653)
    '　　　：2004/10/20 (Wed) 14:57:08 T.Kitagawa   不良入力項目取得Msg変更対応
    '　　　：2004/10/26 (Tue) 17:37:18 S.Deguchi    DoEvents処理を削除(処理不要の為)
    '　　　：2005/03/01 (Tue) 08:33:48 S.Deguchi    不具合№261 ﾊﾝﾄﾞﾜｰｸ工程対応
    '　　　：2005/05/20 (Fri) 09:06:52 S.Deguchi    不具合№820対応でﾛｯﾄ情報取得時に特殊流動最終工程の場合処理強制終了
    '　　　：2005/08/24 (Wed) 09:43:33 N.Kojima     貼り合わせ済みﾁｪｯｸを追加。(運用障害№501)
    '　　　：2005/09/06 (Tue) 16:25:01 S.Deguchi    移載工程中のﾁｪｯｸ処理を追加。(運用障害№525)
    '　　　：2006/11/07 (Tue) 13:06:18 N.Kasai      廃棄処理追加(№01595)
    '　　　：2008/04/22 (Tue) 12:39:36 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAnsFWInfo           As Boolean              'WF情報の取得結果格納
        Dim ltypWaferList           As Waferlist            'WFおよびﾁｯﾌﾟ情報格納用構造体
        Dim lblnAnsScrap            As Boolean              '不良ｺｰﾄﾞ取得結果格納
        Dim lblnAns                 As Boolean              '戻り値格納用
        Dim lstrRWEndFlag           As String               '特殊流動最終工程判断ﾌﾗｸﾞ
        Dim lstrRWFlag              As String               '特殊流動中ﾌﾗｸﾞ
        Dim lstrSelect              As String               '特殊流動名退避領域
        Dim lblnKeyFlag             As Boolean              'NSYS キー判定ﾌﾗｸﾞ
        Dim lctrlCurrent            As Control              'NSYS ActiveControl格納

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '現在のアクティブコントロールを取得
            lctrlCurrent = ActiveControl

            If Not IsNothing(ActiveControl) AndAlso (ActiveControl.Name = txtCarrier.Name OrElse _
               ActiveControl.Name =  txtEmpID.Name) Then
                lblnKeyFlag = True
            Else
                lblnKeyFlag = False
            End If

            '@子画面起動か
            If pblnfrmxxCM0070Kbn = True Then
                '@子画面起動の場合、Form_Loadﾌﾗｸﾞに"True:起動正常"をｾｯﾄ
                pblnFormLoad = True
            End If
            
            '@ｷｬﾘｱIDがﾛｯｸされているか
            If txtCarrier.Locked = True Then
                Exit Sub
            End If
                
            '@ｷｬﾘｱIDがNULLか
            If Trim(txtCarrier.Text) = vbNullString Then
                '@単独起動か
                If pblnfrmxxCM0070Kbn = False Then
                    If lblnKeyFlag Then
                        '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                
                Exit Sub
            End If
            
            '@入力されているｷｬﾘｱIDの桁数が6桁以外か
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
                '@6桁以外の場合
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                e.Cancel = True
                
                '@単独起動か
                If pblnfrmxxCM0070Kbn = False Then
                    '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrier)
                End If
                
                Exit Sub
            End If
            
            '@******************
            '@　ﾛｯﾄ情報の取得
            '@******************
            '@入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)が異なるか
            If txtCarrier.Text <> mstrCarrier Then
                '@異なる場合
            
                '@ﾚｽﾎﾟﾝｽ測定開始
                Call pubResponseStart(CMstrFormName, CMstrTxtCarrierValidate)
            
                '@【ﾛｯﾄ現在情報取得】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                CPstrCD17, _
                                                txtCarrier.Text, _
                                                ptypLotprestate)
                        
                '@通信結果判定
                If lblnAns = True Then
                    '@結果：正常の場合
                
                    With ptypLotprestate
                        
                        lstrRWEndFlag = Mid$(.strReworkFlag, CMlngReworkLen1, CMlngReworkLen1)      '特殊流動終了工程ﾌﾗｸﾞ
                        lstrRWFlag = Mid$(.strReworkFlag, CMlngReworkLen2, CMlngReworkLen1)         '特殊流動ﾌﾗｸﾞ
                        
                        '@特殊流動中でかつ特殊流動の最終工程か
                        If lstrRWFlag = CMstrReworkFlag1 And _
                            lstrRWEndFlag = CMstrReworkFinishFlag1 Then
                            
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                            
                            '@ﾘﾜｰｸﾙｰﾄIDがNULL以外か
                            If .strReworkRouteID <> vbNullString Then
                                '@ﾘﾜｰｸ中の場合
                                lstrSelect = CMstrMsgSpecialR
                            Else
                                '@ﾘﾜｰｸﾙｰﾄIDがNULLの場合
                                
                                '@追加流動ﾙｰﾄIDがNULL以外か
                                If .strSpecialRouteID <> vbNullString Then
                                    '@追加流動中の場合
                                    lstrSelect = CMstrMsgSpecialA
                                End If
                            End If
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005T, lstrSelect, Me.Text)
                            '@ﾒｯｾｰｼﾞ表示("<TRM5TW>$$[%1]の最終工程で[%2]できません。")
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Sub
                        End If
                    End With
                    
                    '@=======================
                    '@　画面表示処理
                    '@=======================
                    Call prvFrmxxCM0070_Disp()
                    
                Else
                    '@結果：異常の場合
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                    
                    '@子画面起動か
                    If pblnfrmxxCM0070Kbn = True Then
                        '@Form_Loadﾌﾗｸﾞに"False:起動失敗"をｾｯﾄ
                        pblnFormLoad = False
                    End If
                    
                    Exit Sub
                End If
            
                '@ｷｬﾘｱIDがNULL以外か(親画面から呼ばれた場合)
                If txtCarrier.Text <> vbNullString Then
                
                    '@【WF情報取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAnsFWInfo = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                                           txtCarrier.Text, _
                                                           CPstrCD0T, _
                                                           ltypWaferList)

                    '@通信結果判定
                    If lblnAnsFWInfo = True Then
                        '@結果：正常の場合
                    
                        '@ｽﾛｯﾄｻｲｽﾞを退避
                        mlngVsfBottomRow = ltypWaferList.strSlotSize
                        
                        '@=======================
                        '@　WF情報表示処理
                        '@=======================
                        Call prvVsfWFList_Disp(ltypWaferList)
                        
                        '@=======================
                        '@　ｽﾛｯﾄﾏｯﾌﾟ初期表示位置設定処理
                        '@=======================
                        Call prvVsfSlotMapTopRow_Set()
                        
                        '@=======================
                        '@　各種ﾎﾞﾀﾝ制御処理
                        '@=======================
                        Call prvFrmxxCM0070_CmbInit(True)
                        
                        '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                        mstrCarrier = txtCarrier.Text
                        
                        '@単独起動か
                        If pblnfrmxxCM0070Kbn = False Then
                        
                            '@責任者IDが有効か
                            If txtEmpID.Enabled = True Then
                                If lblnKeyFlag Then
                                    '@責任者IDにﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(txtEmpID)
                                Else
                                    Call pubSetFocus(lctrlCurrent)
                                End If
                            End If
                        End If
                    Else
                        '@結果：異常の場合
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                        
                        '@子画面起動か
                        If pblnfrmxxCM0070Kbn = True Then
                            '@Form_Loadﾌﾗｸﾞに"False:起動失敗"をｾｯﾄ
                            pblnFormLoad = False
                        End If
                                        
                        Exit Sub
                    End If
                    
                    '@【不良入力項目取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAnsScrap = pubblnMasScpList_Sel(pstrSBID, _
                                                        CMstrmas_scplist_Ver, _
                                                        CPstrCD3I, _
                                                        ptypLotprestate.strLotScrapSetID, _
                                                        mtypMasScrapList)
                    
                    '@通信結果判定
                    If lblnAnsScrap = False Then
                        '@結果：異常の場合

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                        
                        '@子画面起動か
                        If pblnfrmxxCM0070Kbn = True Then
                            '@Form_Loadﾌﾗｸﾞに"False:起動失敗"をｾｯﾄ
                            pblnFormLoad = False
                        End If
                        
                        Exit Sub
                    End If
                    
                    '@不良項目数が0より大きいか
                    '@　(新たに取得した場合と、既に取得している場合がある)
                    If mtypMasScrapList.lngListCnt > 0 Then
                        
                        '@=======================
                        '@　不良項目表示処理
                        '@=======================
                        Call prvVsfCodeList_Disp(mtypMasScrapList)
                        
                        '@現在のｸﾗｽを不良にする
                        mstrClass = CPstrClass2
                        
                        '@=======================
                        '@　各種ﾎﾞﾀﾝの有効/無効制御処理
                        '@=======================
                        Call prvCmdButon_Edit(cmdScrapCode.Name)
                    Else
                        '@0件の場合
                        
                        '@=======================
                        '@　払出理由ﾎﾞﾀﾝ Click処理
                        '@=======================
                        Call cmdTakeReason_Click(cmdTakeReason, New EventArgs())
                        
                        '@不良ｺｰﾄﾞﾎﾞﾀﾝを非活性にする
                        cmdScrapCode.Enabled = False
                    End If
                    
                    '@=======================
                    '@　ｽｸﾛｰﾙﾎﾞﾀﾝ有効/無効をﾁｪｯｸCode(最終行の空白も)
                    '@=======================
                    Call prvScrollButtonCheckCode_Disp()
                    
                    '@=======================
                    '@　ｽｸﾛｰﾙﾎﾞﾀﾝ有効/無効をﾁｪｯｸWF(最終行の空白も)
                    '@=======================
                    Call prvScrollButtonCheckWF_Disp()
                Else
                    '@結果：異常の場合
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                End If
                
                '@=======================
                '@　各種ﾎﾞﾀﾝの有効/無効判定(ここでは必ず無効となる)
                '@=======================
                Call prvCmdButtonControl_Proc()
                
                '@ﾚｽﾎﾟﾝｽ終了
                Call publngResponseEnd(CMstrFormName, CMstrTxtCarrierValidate)
            Else
                '@前回入力ｷｬﾘｱIDと同じ場合
            
                '@責任者IDが有効か
                If txtEmpID.Enabled = True Then
                    If lblnKeyFlag Then
                        '@責任者IDにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtEmpID)
                    Else
                        Call pubSetFocus(lctrlCurrent)
                    End If
                End If
            End If

            '@ﾊﾝﾄﾞﾜｰｸ工程対応の為,ﾛｯﾄの現在状態ﾁｪｯｸでWP_TYPEの判別処理を追加する
            '@ﾊﾝﾄﾞﾜｰｸ工程か
            If mstrWPTYPE = CMstrHandWork Then
                '@ﾊﾝﾄﾞﾜｰｸ工程の場合
            
                '@ﾛｯﾄ状態が"処理中"or"後処理"or"作業終了"か
                If lblStatus.Text = CPstrAfterProgressSt Or _
                    lblStatus.Text = CPstrProcessingSt Or _
                    lblStatus.Text = CPstrEndWorkSt Then

                    '@責任者IDを有効にする
                    txtEmpID.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                    txtEmpID.GotBackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                    txtEmpID.Enabled = True
                Else
                    '@不良/払出/保留一覧を無効にする
                    vsfCodeList.Enabled = False
            
                    '@責任者IDを無効にする
                    txtEmpID.Enabled = False
                    txtEmpID.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)
                    txtEmpID.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)
                End If
            Else
                '@通常工程の場合
                
                '@★ ﾛｯﾄ状態により処理分岐 ★
                Select Case lblStatus.Text
                
                    '@〓 前処理 or 処理中 〓
                    Case CPstrBeforeProgressSt, CPstrProcessingSt
                    
                        '@不良/払出/保留一覧を無効にする
                        vsfCodeList.Enabled = False
            
                        '@責任者IDを無効にする
                        txtEmpID.Enabled = False
                        txtEmpID.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)
                        txtEmpID.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)
                    
                    '@〓 その他 〓
                    Case Else
                    
                        '@責任者IDを有効にする
                        txtEmpID.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                        txtEmpID.GotBackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                        txtEmpID.Enabled = True
                End Select

            End If


            With ptypLotprestate
                
                '@EQ_TYPE=4(TPAL工程)か
                If .strEqType = CPstrEqTypeTPAL Then
                
                    '@貼合せ未完か(CoverFlag=0：貼合せ未完、CoverFlag=1：貼合せ完)
                    If .strCoverFlag <> CPstrOne Then
                    
                        '@不良/払出/保留一覧を無効にする
                        vsfCodeList.Enabled = False
                
                        '@責任者IDを無効にする
                        txtEmpID.Enabled = False
                        txtEmpID.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)
                        txtEmpID.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)
                    End If
                End If
                
                '@EQ_TYPE=5(移載工程)か
                If .strEqType = CPstrEqTypeSORTER Then
                
                    '@不良/払出/保留一覧を無効にする
                    vsfCodeList.Enabled = False
            
                    '@責任者IDを無効にする
                    txtEmpID.Enabled = False
                    txtEmpID.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)
                    txtEmpID.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)
                End If
            End With
            
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

    '関数名：txtEmpID_Change
    '機　能：責任者IDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/29 (Thu) 09:54:01 M.Miura
    '更新日：2008/04/22 (Tue) 13:40:57 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 13:40:57 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtEmpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtEmpID.Change

        Try
            
            '@責任者名ﾗﾍﾞﾙをｸﾘｱする
            lblEmpName.Text = vbNullString
            
            '@=======================
            '@　各種ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdButtonControl_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtEmpID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtEmpID_Validate
    '機　能：責任者IDﾃｷｽﾄ　確定時処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/07/29 (Thu) 09:54:30 M.Miura
    '更新日：2008/04/22 (Tue) 13:42:35 N.Kojima
    '備　考：
    '　　　：2004/09/23 (Thu) 11:42:34 N.Kojima　   作業者検索ｴﾗｰMsgをSVで表示するように修正(不具合№895)
    '　　　：2008/04/22 (Tue) 13:42:35 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtEmpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtEmpID.Validating
        
        Dim lstrEmpName             As String               '責任者名退避用
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@責任者IDが無効か
            If txtEmpID.Enabled = False Then
                Exit Sub
            End If
            
            '@責任者IDが入力されているか
            If txtEmpID.Text <> vbNullString Then
                
                '@責任者IDの桁数が7桁以外か
                If txtEmpID.NowByte < txtEmpID.ChrMaxByte Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003K, CMstrEmpIDTitle)
                    '@"[責任者ID]は7桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    e.Cancel = True
                    Exit Sub
                End If
            
                '@【作業者名取得】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnMasEmpName_Sel(CMstrmas_empname_Ver, txtEmpID.Text, lstrEmpName)
                
                '@通信結果判定
                If lblnAns = True Then
                    '@結果：正常の場合
                
                    '@責任者名設定
                    lblEmpName.Text = lstrEmpName
                Else
                    '@結果：異常の場合
                
                    e.Cancel = True
                    Exit Sub
                End If
            
            Else
                '@責任者名設定
                lblEmpName.Text = vbNullString
            End If
            
            '@=======================
            '@　確定ﾎﾞﾀ制御処理
            '@=======================
            Call prvCmdButtonControl_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtEmpID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdScrapCode_Click
    '機　能：不良ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 13:57:14 T.Oide
    '更新日：2008/04/22 (Tue) 14:08:48 N.Kojima
    '備　考：
    '　　　：2004/09/03 (Fri) 13:27:49 T.Kitagawa　 不良入力項目取得Msg変更対応
    '　　　：2004/10/20 (Wed) 14:54:03 T.Kitagawa　 不良入力項目取得Msg変更対応
    '　　　：2008/04/22 (Tue) 14:08:48 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdScrapCode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdScrapCode.Click
        
        Dim lblnAns                 As Boolean          '不良ｺｰﾄﾞ取得結果格納
        Dim lstrOpID                As String           '大工程ID
        Dim lstrStepID              As String           '小工程ID

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の条件の場合、処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計
            '@　②ﾌｫｰﾑのﾛｯｸ中
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ測定開始
            Call pubResponseStart(CMstrFormName, CMstrCmdScrapCodeClick)
            
            With vsfCodeList

                '@=======================
                '@ WF情報ｸﾘｱ(固定行および列以外をｸﾘｱ)
                '@=======================
                .Redraw = False
                'NSYS コード一覧グリッドにデータ行がある場合クリアする
                If .Rows.Count > .Rows.Fixed Then
                    .Clear(ClearFlags.Content, .Rows.Fixed, .Cols.Fixed, .Rows.Count-1, .Cols.Count-1)
                End If
                .Rows.Count = .Rows.Fixed
                .Redraw = True
            End With
            
            lstrOpID = lblOpName.Text        '大工程IDを格納
            lstrStepID = lblStepName.Text    '小工程IDを格納
            
            '@不良ｺｰﾄﾞが0件か
            If mtypMasScrapList.lngListCnt = 0 Then
                '@0件の場合
            
                '@【不良入力項目取得】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnMasScpList_Sel(pstrSBID, _
                                               CMstrmas_scplist_Ver, _
                                               CPstrCD3I, _
                                               ptypLotprestate.strLotScrapSetID, _
                                               mtypMasScrapList)
                
                '@通信結果判定
                If lblnAns = False Then
                    '@結果：異常の場合
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdScrapCodeClick)
                    Exit Sub
                End If
            Else
                '@1件以上ある場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdScrapCodeClick)
            End If
            
            '@不良ｺｰﾄﾞが1件以上あるか(新たに取得した場合と、既に取得している場合がある)
            If mtypMasScrapList.lngListCnt > 0 Then
                
                '@=======================
                '@　不良ｺｰﾄﾞ表示処理
                '@=======================
                Call prvVsfCodeList_Disp(mtypMasScrapList)
                
                '@現在のｸﾗｽを不良にする
                mstrClass = CPstrClass2
            End If
            
            '@=======================
            '@　ﾎﾞﾀﾝの強調表示処理
            '@=======================
            Call prvCmdButon_Edit(cmdScrapCode.Name)
            
            '@=======================
            '@　ｽｸﾛｰﾙﾎﾞﾀﾝ有効/無効制御処理(最終行の空白も)
            '@=======================
            Call prvScrollButtonCheckCode_Disp()
            
            '@ﾚｽﾎﾟﾝｽ測定終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdScrapCodeClick)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdScrapCode_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTakeReason_Click
    '機　能：払出ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 11:31:50 T.Oide
    '更新日：2008/04/22 (Tue) 14:15:57 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 14:15:57 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdTakeReason_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTakeReason.Click
        
        Dim lblnAnsTake             As Boolean          '払出しｺｰﾄﾞ取得結果格納
        Dim lstrOpID                As String           '大工程ID
        Dim lstrStepID              As String           '小工程ID

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾚｽﾎﾟﾝｽ測定開始
            Call pubResponseStart(CMstrFormName, CMstrCmdTakeReasonClick)
            
            With vsfCodeList
            
                '@=======================
                '@　WF情報ｸﾘｱ処理(固定行および列以外をｸﾘｱ)
                '@=======================
                .Redraw = False
                'NSYS コード一覧グリッドにデータ行がある場合クリアする
                If .Rows.Count > .Rows.Fixed Then
                    .Clear(ClearFlags.Content, .Rows.Fixed, .Cols.Fixed, .Rows.Count-1, .Cols.Count-1)
                End If
                .Rows.Count = .Rows.Fixed
                .Redraw = True
            End With
            
            lstrOpID = lblOpName.Text       '大工程IDを格納
            lstrStepID = lblStepName.Text   '小工程IDを格納
            
            '@払出ｺｰﾄﾞが0件か
            If mtypMasTakeList.lngListCnt = 0 Then
                '@0件の場合
            
                '@【理由ｺｰﾄﾞ取得】ﾒｯｾｰｼﾞ送受信処理
                lblnAnsTake = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, _
                                                     CPstrCD2V, _
                                                     mtypMasTakeList)
                
                '@通信結果判定
                If lblnAnsTake = False Then
                    '@結果：異常の場合
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdTakeReasonClick)
                    Exit Sub
                End If
            Else
                '@1件以上ある場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdTakeReasonClick)
            End If
            
            '@払出ｺｰﾄﾞが1件以上存在するか(新たに取得した場合と、既に取得している場合がある)
            If mtypMasTakeList.lngListCnt > 0 Then
            
                '@=======================
                '@　払出ｺｰﾄﾞ表示処理
                '@=======================
                Call prvVsfCodeList_Disp(mtypMasTakeList)
                
                '@現在のｸﾗｽを払出しにする
                mstrClass = CPstrClass3
            End If
            
            '@=======================
            '@　ﾎﾞﾀﾝの強調表示処理
            '@=======================
            Call prvCmdButon_Edit(cmdTakeReason.Name)
            
            '@=======================
            '@　ｽｸﾛｰﾙﾎﾞﾀﾝ有効/無効制御処理(最終行の空白も)
            '@=======================
            Call prvScrollButtonCheckCode_Disp()
            
            '@ﾚｽﾎﾟﾝｽ測定終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdTakeReasonClick)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTakeReason_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHoldReason_Click
    '機　能：保留理由ｺｰﾄﾞ一覧取得
    '引　数：なし
    '戻り値：ない
    '作成日：2004/03/24 (Wed) 13:21:02 T.Oide
    '更新日：2004/05/11 (Tue) 15:34:49 T.Kitagawa
    '備　考：
    Private Sub cmdHoldReason_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHoldReason.Click
        
        Dim lblnAnsHold             As Boolean          '保留理由取得結果格納
        Dim lstrOpID                As String           '大工程ID
        Dim lstrStepID              As String           '小工程ID

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾚｽﾎﾟﾝｽ測定開始
            Call pubResponseStart(CMstrFormName, CMstrCmdHoldReasonClick)
            
            With vsfCodeList
            
                '@=======================
                '@　WF情報ｸﾘｱ処理(固定行および列以外をｸﾘｱ)
                '@=======================
                .Redraw = False
                'NSYS コード一覧グリッドにデータ行がある場合クリアする
                If .Rows.Count > .Rows.Fixed Then
                    .Clear(ClearFlags.Content, .Rows.Fixed, .Cols.Fixed, .Rows.Count-1, .Cols.Count-1)
                End If
                .Rows.Count = .Rows.Fixed
                .Redraw = True
            End With
            
            lstrOpID = lblOpName.Text       '大工程IDを格納
            lstrStepID = lblStepName.Text   '小工程IDを格納
            
            '@保留ｺｰﾄﾞが0件か
            If mtypMasHoldList.lngListCnt = 0 Then
                '@0件の場合
                
                '@【理由ｺｰﾄﾞ取得】ﾒｯｾｰｼﾞ送受信処理
                lblnAnsHold = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, _
                                                     CPstrCD2U, _
                                                     mtypMasHoldList)
                
                '@通信結果判定
                If lblnAnsHold = False Then
                    '@結果：異常の場合
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdHoldReasonClick)
                    Exit Sub
                End If
            Else
                '@1件以上ある場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdHoldReasonClick)
            End If
            
            '@保留ｺｰﾄﾞが1件以上あるか(新たに取得した場合と、既に取得している場合がある)
            If mtypMasHoldList.lngListCnt > 0 Then
            
                '@=======================
                '@　保留ｺｰﾄﾞ表示処理
                '@=======================
                Call prvVsfCodeList_Disp(mtypMasHoldList)
                
                '@現在のｸﾗｽを保留にする
                mstrClass = CPstrClass4
            End If
            
            '@=======================
            '@　ﾎﾞﾀﾝの強調表示処理
            '@=======================
            Call prvCmdButon_Edit(cmdHoldReason.Name)
            
            '@=======================
            '@　ｽｸﾛｰﾙﾎﾞﾀﾝ有効/無効制御処理(最終行の空白も)
            '@=======================
            Call prvScrollButtonCheckCode_Disp()
            
            '@ﾚｽﾎﾟﾝｽ測定終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdHoldReasonClick)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHoldReason_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp1_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(ｺｰﾄﾞｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 13:17:05 T.Oide
    '更新日：2008/04/22 (Tue) 14:35:36 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 14:35:36 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdUP1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUP1.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            '@=======================
            Call pubVsfCmdUp(vsfCodeList, cmdUP1, cmdDown1)

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
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(ｺｰﾄﾞｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 13:17:48 T.Oide
    '更新日：2008/04/22 (Tue) 14:35:36 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 14:35:36 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdDown1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown1.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            '@=======================
            Call pubVsfCmdDown(vsfCodeList, cmdUP1, cmdDown1)

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

    '関数名：vsfWFList_AfterSelChange
    '機　能：WFｸﾞﾘｯﾄﾞ　ｾﾙ変更後処理
    '引　数：OldRowSel：未使用
    '　　　：OldColSel：未使用
    '　　　：NewRowSel：未使用
    '　　　：NewColSel：未使用
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 18:57:07 T.Oide
    '更新日：2008/04/22 (Tue) 14:29:42 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 14:29:42 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub vsfWFList_AfterSelChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWFList.AfterSelChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfWFList.Rows.Count <= vsfWFList.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@　各種ﾎﾞﾀﾝの有効/無効制御処理
            '@=======================
            Call prvCmdButtonControl_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWFList_AfterSelChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWFList_MouseUp
    '機　能：WFｸﾞﾘｯﾄﾞ　ﾏｳｽUP時処理
    '引　数：Button ：未使用
    '　　　：Shift  ：未使用
    '　　　：X      ：未使用
    '　　　：Y      ：未使用
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 20:26:55 T.Oide
    '更新日：2008/04/22 (Tue) 14:31:21 N.Kojima
    '備　考：
    '　　　：2005/01/05 (Wed) 09:26:22 H.Wajima     ｸﾞﾘｯﾄﾞの外でﾏｳｽのﾎﾞﾀﾝを離した時の対応。
    '　　　：2008/04/22 (Tue) 14:31:21 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub vsfWFList_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWFList.MouseUp

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfWFList.Rows.Count <= vsfWFList.Rows.Fixed Then
                Return
            End If
            
            '@=======================
            '@　WFｸﾞﾘｯﾄﾞへのｺｰﾄﾞ表示処理
            '@=======================
            Call prvVsfWFList_Set()
            
            '@=======================
            '@　各種ﾎﾞﾀﾝの有効/無効制御処理
            '@=======================
            Call prvCmdButtonControl_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWFList_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp2_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(WFｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 13:38:10 T.Oide
    '更新日：2004/03/24 (Wed) 13:38:10
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
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            '@=======================
            Call pubVsfCmdUp(vsfWFList, cmdUP2, cmdDown2)

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
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(WFｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 13:38:20 T.Oide
    '更新日：2004/03/24 (Wed) 13:38:20
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
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            '@=======================
            Call pubVsfCmdDown(vsfWFList, cmdUP2, cmdDown2, False)

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

    '関数名：cmdConfirm_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/26 (Fri) 13:41:33 T.Oide
    '更新日：2009/08/11 (Tue) 10:29:20 N.Kojima
    '備　考：
    '　　　：2004/10/29 (Fri) 15:06:12 M.Miura　    ﾛｯﾄｱｳﾄﾁｪｯｸとﾛｯﾄｱｳﾄ時のﾒｯｾｰｼﾞ表示を追加(不具合№104)
    '　　　：2005/02/28 (Mon) 08:41:51 S.Deguchi    不具合№352/561の対応で確定処理後,作業終了画面に戻る場合,処理内容を返す
    '　　　：2005/07/12 (Tue) 13:34:19 N.Kojima     作業終了画面でのﾁｪｯｸﾎﾞｯｸｽの制御用に値を退避させる処理追加。(不具合№1875)
    '　　　：2005/07/13 (Wed) 15:37:46 S.Deguchi    引継処理修正
    '　　　：2008/04/22 (Tue) 14:38:22 N.Kojima     ｿｰｽ整備、不良/払出時の権限ﾁｪｯｸ機能追加。(案件№02786)
    '　　　：2009/08/11 (Tue) 10:29:20 N.Kojima     試作実験ﾛｯﾄの場合、確定時に検査工数削減のMsgを表示する。(案件№03542)
    Private Sub cmdConfirm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdConfirm.Click
        
        Dim lblnAnsKakutei          As Boolean      '確定結果格納
        Dim lblnAnsDataSet          As Boolean      'ﾃﾞｰﾀｾｯﾄ結果格納
        Dim lblnAnsAuthorityChk     As Boolean      '権限ﾁｪｯｸ結果格納
        Dim lstrResult              As String       '結果(2:WF移載/3:ﾛｯﾄ終了)

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の条件の場合は処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then
                
                Exit Sub
            End If
                
            '@=======================
            '@　登録情報格納処理
            '@=======================
            lblnAnsDataSet = prvblnDataSet_Proc(CMstrCmdConfirmClick)
            
            '@処理結果判定
            If lblnAnsDataSet = True Then
                '@結果：正常の場合
                
                '@=======================
                '@　WF状態変更権限ﾁｪｯｸ処理
                '@=======================
                lblnAnsAuthorityChk = prvblnRegistAuthority_Chk(CMstrCmdConfirmClick)
                
                '@処理結果判定
                If lblnAnsAuthorityChk = False Then
                    '@結果：異常の場合
                    Exit Sub
                End If
                
            
                '@ﾚｽﾎﾟﾝｽ測定開始
                Call pubResponseStart(CMstrFormName, CMstrCmdConfirmClick)
            
                '@【不良/保留/払出/傾向登録】ﾒｯｾｰｼﾞ送受信処理
                lblnAnsKakutei = pubblnLotInsprst_Ins(CMstrlot_insprst_Ver, _
                                                      mtypLotInsprst, _
                                                      lstrResult)
                                                      
                '@通信結果判定
                If lblnAnsKakutei = True Then
                    '@結果：正常の場合
                
                    '@ﾚｽﾎﾟﾝｽ終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdConfirmClick)
                
                    '@応答の結果(lstrResult)が"2:移載"か
                    If lstrResult = CMstrLotEventMove Then
                        '@"2:移載"の場合
                    
                        '@表示ﾒｯｾｰｼﾞ変換("<TRM21I>$$WF情報を登録しました。キャリア[ %1 ] ロット[ %2 ]")
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0021, txtCarrier.Text, lblLotID.Text)
                    Else
                        '@"2:移載"以外
                    
                        '@表示ﾒｯｾｰｼﾞ変換("<TRM32I>$$ロット[%2]終了しました。キャリア[%1]")
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0032, txtCarrier.Text, lblLotID.Text)
                    End If
                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)

            
                    '@子画面起動か
                    If pblnfrmxxCM0070Kbn = True Then
                        '@子画面起動の場合
                    
                        '@引継構造体に情報をｾｯﾄ
                        With ptypWorkEndInfo
                            .strCarrierId = txtCarrier.Text         'ｷｬﾘｱID
                            .strLotID = lblLotID.Text               'ﾛｯﾄID
                            .strfrmxxKbn = CPstrKeyEN0180           '機能ID
                            
                            '@★ 応答の結果(lstrResult)により処理分岐 ★
                            Select Case lstrResult
                            
                                '@〓 2:移載 〓
                                Case CMstrLotEventMove
                                
                                    .strWorkKbn = CMstrLotEventMove
                                
                                '@〓 3:ﾛｯﾄｱｳﾄ 〓
                                Case CMstrLotEventLotOut

                                    .strWorkKbn = CMstrLotEventLotOut
                                    
                                '@〓 その他 〓
                                Case Else

                                    .strWorkKbn = vbNullString
                            End Select
                            
                            '@作業終了画面ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御用に値を格納
                            pstrLotInsprstResult.strOpID = lblOpName.Text                   '大工程ID
                            pstrLotInsprstResult.strStepID = lblStepName.Text               '小工程ID
                            pstrLotInsprstResult.strLotID = lblLotID.Text                   'ﾛｯﾄID
                            pstrLotInsprstResult.strWorkKbn = .strWorkKbn                   '登録結果
                            pstrLotInsprstResult.strSpecialRuteFlag = .strSpecialRuteFlag   '特殊ﾙｰﾄﾌﾗｸﾞ
                            
                        End With
                        
                        '@∇∇∇∇∇∇∇∇∇
                        '@　ｱﾝﾛｰﾄﾞ処理
                        '@∇∇∇∇∇∇∇∇∇
                        Me.Close()

                    Else
                        '@単独起動の場合
                    
                        '@作業終了画面ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御用に値を格納
                        With ptypWorkEndInfo
                            
                            '@★ 応答の結果(lstrResult)により処理分岐 ★
                            Select Case lstrResult
                                
                                '@〓 2:移載 〓
                                Case CMstrLotEventMove

                                    .strWorkKbn = CMstrLotEventMove
                                    
                                '@〓 3:ﾛｯﾄｱｳﾄ 〓
                                Case CMstrLotEventLotOut

                                    .strWorkKbn = CMstrLotEventLotOut
                                    
                                '@〓 その他 〓
                                Case Else

                                    .strWorkKbn = vbNullString
                            End Select
                        
                            pstrLotInsprstResult.strOpID = lblOpName.Text                   '大工程ID
                            pstrLotInsprstResult.strStepID = lblStepName.Text               '小工程ID
                            pstrLotInsprstResult.strLotID = lblLotID.Text                   'ﾛｯﾄID
                            pstrLotInsprstResult.strWorkKbn = .strWorkKbn                   '登録結果
                            pstrLotInsprstResult.strSpecialRuteFlag = .strSpecialRuteFlag   '特殊ﾙｰﾄﾌﾗｸﾞ
                        End With
                        
                        '@=======================
                        '@　画面初期化処理
                        '@=======================
                        Call prvFrmxxCM0070_Init()
                        
                        '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtCarrier)
                    End If
                        
                Else
                    '@結果：異常の場合
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdConfirmClick)
                End If
            Else
                '@結果：異常の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdConfirmClick)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdConfirm_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClear_Click
    '機　能：取消ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 15:04:40 T.Oide
    '更新日：2008/04/22 (Tue) 14:38:22 N.Kojima
    '備　考：
    '　　　：2004/09/08 (Wed) 15:11:46 Y.Yamagishi  不具合515対応
    '　　　：2004/09/21 (Tue) 21:14:45 H.Wajima     不良ｺｰﾄﾞ0件の場合対応(№653)
    '　　　：2006/06/08 (Thu) 10:29:13 T.Sawaguchi  不具合No3742の横にらみで修正
    '　　　：2008/04/22 (Tue) 14:38:22 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click
        
        Dim llngCnt         As Integer  'ｶｳﾝﾀ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@変更ﾃﾞｰﾀ取り消し
            llngCnt = 2
            
            With vsfWFList
                '@WF行分繰り返し
                Do While .Rows.Count >= llngCnt
                
                    '変更可否ﾌﾗｸﾞが｢1｣か
                    If .GetData(llngCnt - 1, CMlngVsfWFListChange) = CMlngChangeOK Then
                    
                        .SetData(llngCnt - 1, CMlngVsfWFListClassID, vbNullString)        'ｸﾗｽIDをNULLに変更
                        .SetData(llngCnt - 1, CMlngVsfWFListClass, CPstrClass1)           'ｸﾗｽを"1:良品"に変更
                    End If
                    llngCnt = llngCnt + 1
                Loop
            End With

            '@不具合No3742の横にらみで修正 CmlngVsfBottomRow(25)→CMlngVsfTitle(0)　に変更,
            '@擬似的にｶﾚﾝﾄ行をﾀｲﾄﾙにｾｯﾄしﾌｫｰｶｽを当たっていない様にする
            '@ｶﾚﾝﾄ行ｾｯﾄ
            vsfWFList.Row = CMlngvsfTitle

            '@責任者IDをNULLにする
            txtEmpID.Text = vbNullString
            '@責任者名をNULLにする
            lblEmpName.Text = vbNullString
            
            '@責任者IDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtEmpID)
            
            '@不良ﾎﾞﾀﾝが有効か
            If cmdScrapCode.Enabled = True Then
                '@有効な場合
                
                '@=======================
                '@　不良ﾎﾞﾀﾝ押下＆Click時処理
                '@=======================
                Call cmdScrapCode_Click(cmdScrapCode, New EventArgs())
            Else
                '@無効な場合
                
                '@=======================
                '@　払出ﾎﾞﾀﾝ押下＆Click時処理
                '@=======================
                Call cmdTakeReason_Click(cmdTakeReason, New EventArgs())
            End If
            
            '@=======================
            '@　各種ﾎﾞﾀﾝの有効/無効制御処理
            '@=======================
            Call prvCmdButtonControl_Proc()
            
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

    '関数名：cmdScrap_Click
    '機　能：廃棄ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/07 (Tue) 13:23:07 N.Kasai
    '更新日：2009/08/11 (Tue) 10:29:20 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 14:38:22 N.Kojima     ｿｰｽ整備、不良/払出時の権限ﾁｪｯｸ機能追加。(案件№02786)
    '　　　：2009/08/11 (Tue) 10:29:20 N.Kojima     試作実験ﾛｯﾄの場合、確定時に検査工数削減のMsgを表示する。(案件№03542)
    Private Sub cmdScrap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdScrap.Click
        
        Dim lblnAns                 As Boolean      '戻り値
        Dim lstrResult              As String       '結果(1:WF移載/2:ﾛｯﾄ終了)
        Dim lstrMsg                 As String       '変換後ﾒｯｾｰｼﾞ
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@　WF破棄送信ﾃﾞｰﾀ格納処理
            '@=======================
            lblnAns = prvblnDataSet_Proc(CMstrCmdScrapClick)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If
            
            '@=======================
            '@　WF廃棄権限ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnRegistAuthority_Chk(CMstrCmdScrapClick)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ開始処理
            Call pubResponseStart(CMstrFormName, CMstrCmdScrapClick)
            
            '@【WF直接廃棄】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnWfDirectScrap_Upd(mtypDirectScrap, _
                                              lstrResult)
                                              
            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdScrapClick)
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ終了処理
            Call publngResponseEnd(CMstrFormName, CMstrCmdScrapClick)

            '@応答の結果(lstrResult)が"2:ﾛｯﾄｱｳﾄ(全数WF廃棄)"か
            If lstrResult = CMstrResultAllScrap Then
                '@"2:ﾛｯﾄｱｳﾄ(全数WF廃棄)"の場合
                
                '@"<TRM6MI>$$ロットを終了し、全ウエハを廃棄しました。キャリア[%1] ロット[%2]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006M, txtCarrier.Text, lblLotID.Text)
            Else
                '@"2:ﾛｯﾄｱｳﾄ(全数WF廃棄)"以外、即ち"部分廃棄"の場合
                
                '@"<TRM6NI>$$ウエハを廃棄しました。キャリア[%1] ロット[%2]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006N, txtCarrier.Text, lblLotID.Text)
            End If
            '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
            Call pubVsfInfo_Disp(pstrDMsg)


        '@↓2009/08/11 (Tue) 10:23:01 N.Kojima **************************************************

            '@起動SBが"1A0：基板"か
            If pstrSBID = CPstrSBID1A0 Then

                '@ﾛｯﾄの種別が"試作/実験品：GG,TS,WS,ZZ"か
                If lblFlowClass.Text = CPstrFlowClassGG Or _
                    lblFlowClass.Text = CPstrFlowClassTS Or _
                    lblFlowClass.Text = CPstrFlowClassWS Or _
                    lblFlowClass.Text = CPstrFlowClassZZ Then
                    
                    '@表示ﾒｯｾｰｼﾞを編集(ロット[XXX])
                    lstrMsg = CPstrLot & CPstrBrLeft & lblLotID.Text & CPstrBrRight
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM1ZI>$$%1が[%2]されました。$検査工数削減の為、必要に応じて外観・現像検査工程の
                    '@ 検査ウェハ枚数を見直して下さい。$%3 %4"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0024, CPstrWF, CPstrDirectScrap, lstrMsg, vbNullString)
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                End If
            End If

        '@↑2009/08/11 (Tue) 10:23:01 N.Kojima **************************************************
            
            
            '@子画面起動か
            If pblnfrmxxCM0070Kbn = True Then
                '@子画面起動の場合
            
                '@引継構造体に情報をｾｯﾄ
                With ptypWorkEndInfo
                
                    .strCarrierId = txtCarrier.Text         'ｷｬﾘｱID
                    .strLotID = lblLotID.Text               'ﾛｯﾄID
                    .strfrmxxKbn = CPstrKeyEN0180           '機能ID
                    
                    '@★ 結果(lstrResult)により処理分岐 ★
                    Select Case lstrResult
                    
                        '@〓 "1:部分WF廃棄" 〓
                        Case CMstrResultPartScrap
                        
                            .strWorkKbn = CMstrLotEventScrap
                            
                        '@〓 "2:ﾛｯﾄｱｳﾄ(全数廃棄)" 〓
                        Case CMstrResultAllScrap

                            .strWorkKbn = CMstrLotEventLotOut
                            
                        '@〓 その他 〓
                        Case Else

                            .strWorkKbn = vbNullString
                    End Select
                    
                    '@作業終了画面ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御用に値を格納
                    pstrLotInsprstResult.strOpID = lblOpName.Text                   '大工程ID
                    pstrLotInsprstResult.strStepID = lblStepName.Text               '小工程ID
                    pstrLotInsprstResult.strLotID = lblLotID.Text                   'ﾛｯﾄID
                    pstrLotInsprstResult.strWorkKbn = .strWorkKbn                   '登録結果
                    pstrLotInsprstResult.strSpecialRuteFlag = .strSpecialRuteFlag   '特殊ﾙｰﾄﾌﾗｸﾞ
                    
                End With
                
                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                Me.Close()
            Else
                '@単独起動の場合
                
                '@=======================
                '@　画面初期化処理
                '@=======================
                Call prvFrmxxCM0070_Init()
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
            End If
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdScrap_Click"
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
    '作成日：2004/03/23 (Tue) 10:15:30 T.Oide
    '更新日：2008/04/22 (Tue) 15:13:41 N.Kojima
    '備　考：
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
    '　　　：2007/07/17 (Tue) 09:52:48 N.Kasai      親画面連携共通化
    '　　　：2008/04/22 (Tue) 15:13:41 N.Kojima     ｿｰｽ整備。(案件№02786)
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
            
            '@子画面起動か
            If pblnfrmxxCM0070Kbn = True Then
            
                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                RemoveHandler txtEmpID.Validating, AddressOf txtEmpID_Validate
                Me.Close()
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                AddHandler txtEmpID.Validating, AddressOf txtEmpID_Validate

            Else
                '@単独起動の場合
            
                '@引継ぎ情報のｷｬﾘｱIDがNULL以外か
                If ptypCommonInfo.strCarrierId <> vbNullString Then
                    '@NULL以外の場合(=子画面起動の場合)
                    
                    '@=======================
                    '@　画面切替え制御処理
                    '@=======================
                    Call pubChangeScreen_Set(Me)
                Else
                    '@NULLの場合
                    
                    '@=======================
                    '@　終了処理
                    '@=======================
                    RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                    RemoveHandler txtEmpID.Validating, AddressOf txtEmpID_Validate
                    llngRet = publngEnd_Proc(CPstrKeyEN0180, ltypCommonInfo)
                    AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                    AddHandler txtEmpID.Validating, AddressOf txtEmpID_Validate
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

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvIndependentLoad_Init
    '機　能：単独起動時の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/08 (Thu) 13:40:51 Y.Yamagishi
    '更新日：2008/04/22 (Tue) 18:13:22 N.Kojima
    '備　考：
    '　　　：2006/06/08 (Thu) 10:29:13 T.Sawaguchi  不具合No3472　単独起動時のSLOTNo01の色表示を白にする
    '　　　：2008/04/22 (Tue) 18:13:22 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvIndependentLoad_Init()

        Try
            
            '@ｷｬﾘｱIDの初期化
            With txtCarrier
                .BackColor = Color.White        'ﾊﾞｯｸｶﾗｰ：白
                .GotBackColor = Color.White     'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ：白
                .Locked = False                 'ﾛｯｸ解除
                .TabStop = True                 'ﾀﾌﾞｽﾄｯﾌﾟ:有効
            End With
            
            '@ﾌｫｰﾑに対してのｷｰｲﾍﾞﾝﾄを最優先に設定
            Me.KeyPreview = True
            
            With vsfWFList

                For i As Integer = 0 To .Rows.Count - 1
                    .Rows(i).Height = CMlngvsfRowHeight      '行の高さ
                Next
                .Row = .Rows.Count - 1                       '№01の一番下の行を初期選択状態にする
                
                '@=======================
                '@　ｿｰﾄ前のｶﾚﾝﾄKey値の格納処理
                '@=======================
                Call pubVsfBeforeSort(vsfWFList, CMlngVsfWFListSlotNo)
                
                '@=======================
                '@　ｿｰﾄ後のｶﾚﾝﾄKey値の格納処理
                '@=======================
                Call pubVsfAfterSort(vsfWFList, CMlngVsfWFListSlotNo, cmdUP2, cmdDown2, False, False)

                '@不具合No3472　単独起動時のSLOTNo01の色表示を白にする
                '@擬似的にｶﾚﾝﾄ行をﾀｲﾄﾙ行へｾｯﾄしﾌｫｰｶｽを当たっていない様にする
                .Row = CMlngvsfTitle

            End With
            
            '@=======================
            '@　各種ﾎﾞﾀﾝの制御処理(使用不可)
            '@=======================
            Call prvFrmxxCM0070_CmbInit(False)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvIndependentLoad_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxCM0070_Init
    '機　能：画面情報初期化処理
    '引　数：lblnCarrierClear：(True：ｷｬﾘｱIDｸﾘｱ、False：ｷｬﾘｱID未編集)
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 13:49:38 T.Oide
    '更新日：2008/04/22 (Tue) 15:58:06 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 10:24:55 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/11/26 (Fri) 08:45:11 S.Deguchi    不良項目のﾀｲﾄﾙ高さの設定をｽﾛｯﾄﾏｯﾌﾟへ統一
    '　　　：2005/03/01 (Tue) 08:40:54 S.Deguchi    不具合№261対応用のﾓｼﾞｭｰﾙ変数初期化処理追加
    '　　　：2008/04/22 (Tue) 15:58:06 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvFrmxxCM0070_Init(Optional ByVal lblnCarrierClear As Boolean = True)
        
        Dim lstrFormTitle       As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim ltypeListInit       As MasItemList      '不良入力項目構造体、保留入力項目構造体、払出項目構造体初期化用
        Dim ltypLotInsprst      As LotInsprst       '変更登録ﾃﾞｰﾀ格納構造体初期化用
        Dim ltypDirectScrap     As DirectScrap      '廃棄登録ﾃﾞｰﾀ格納構造体初期化用

        Try
            
            '@=======================
            '@　機能毎関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0180, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@基本情報ｸﾘｱ
            If lblnCarrierClear = True Then
                '@ｷｬﾘｱをｸﾘｱする場合
                txtCarrier.Text = vbNullString          'ｷｬﾘｱID
            End If
            lblLotID.Text = vbNullString                'ﾛｯﾄID
            lblFlowClass.Text = vbNullString            '流動区分
            lblWFNo.Text = vbNullString                 'WF枚数
            lblOpName.Text = vbNullString               '大工程ID
            lblStatus.Text = vbNullString               '状態
            lblStepName.Text = vbNullString             '小工程ID
            lblEmpName.Text = vbNullString              '責任者名
            
            '@責任者IDの初期化
            With txtEmpID
                .Text = vbNullString                    'NULL
                .BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)       '白
                .Enabled = False                        '無効
                .ChrMaxByte = CPlngEmpIDLength          '最大桁数を7桁に設定
            End With
            
            '@ｺｰﾄﾞｸﾞﾘｯﾄﾞの初期化
            With vsfCodeList
                .Redraw = False
                .SelectionMode = SelectionModeEnum.Row
                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed - 1, .Cols.Fixed, .Rows.Fixed - 1, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle_vsfCodeList")
                headerStyle.ForeColor = Color.Yellow                                '文字色：黄色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)   '背景色：青色
                headerStyle.Trimming = StringTrimming.None                          'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle

                .Rows.Count = 1                         '行数：1
                .Rows(0).Height = CMlngvsfRowHeight     '行高：570
                .FocusRect = FocusRectEnum.None         'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠：なし
                .Redraw = True
            End With

            '@=======================
            '@　WFｸﾞﾘｯﾄﾞのｸﾘｱ処理(固定行および列以外をｸﾘｱ)
            '@=======================
            For i = 1 To vsfWFList.Rows.Count - 1
                vsfWFList.Rows(i).Clear(ClearFlags.All)
                Dim newStyle As CellStyle = vsfWFList.Styles.Add("CustomStyle_BackColor_vbWhite")
                newStyle.BackColor = Color.White
                Dim cellRange As CellRange = vsfWFList.GetCellRange(i, CMlngvsfWFListClassID)
                cellRange.Style = newStyle         '白色に変更
            Next i
            
            '@WFｸﾞﾘｯﾄﾞの初期化
            With vsfWFList
                .Redraw = False
                .SelectionMode = SelectionModeEnum.ListBox 
                'NSYS スロットポジション番号を設定
                For i As Integer = 1 To .Rows.Count - 1
                    .SetData(i, CMlngvsfWFListSlotNo, CStr(Format$(.Rows.Count - i, CPstrSlotNoFormat)))
                Next
                .Select(.Rows.Fixed - 1, .Cols.Fixed, .Rows.Fixed - 1, .Cols.Count - 1)
                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed - 1, .Cols.Fixed - 1, .Rows.Fixed - 1, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle_vsfWFList")
                headerStyle.ForeColor = Color.Yellow                                '文字色：黄色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)   '背景色：青色
                headerStyle.Trimming = StringTrimming.None                          'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle
                .FocusRect = FocusRectEnum.None                                     'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠：なし
                .Redraw = True
            End With
            
            '@下記ﾎﾞﾀﾝ押下時は、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙのValidateｲﾍﾞﾝﾄを実行しないように設定
            cmdClose.CausesValidation = False       '閉じるﾎﾞﾀﾝ
            cmdClear.CausesValidation = False       '取消ﾎﾞﾀﾝ
            
            '@ﾓｼﾞｭｰﾙ変数を初期化
            mstrCarrier = vbNullString              'ｷｬﾘｱID退避用
            mstrWPTYPE = vbNullString               '装置ﾀｲﾌﾟ格納用
            mblnFuryouClass = False                 '不良存在判定ﾌﾗｸﾞ
            mblnHaraidashiClass = False             '払出存在判定ﾌﾗｸﾞ
        '@↓2011/10/19 (Wed) 16:55:15 T.Oide **************************************************
            mblnHoryuClass = False                  '保留判定ﾌﾗｸﾞ
        '@↑2011/10/19 (Wed) 16:55:15 T.Oide **************************************************

            '@各構造体初期化
            mtypMasScrapList = ltypeListInit        '不良入力項目構造体
            mtypMasHoldList = ltypeListInit         '保留入力項目構造体
            mtypMasTakeList = ltypeListInit         '払出項目構造体
            mtypLotInsprst = ltypLotInsprst         '変更登録ﾃﾞｰﾀ格納構造体
            mtypDirectScrap = ltypDirectScrap       '廃棄登録ﾃﾞｰﾀ格納構造体
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxCM0070_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxCM0070_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 13:44:04 T.Oide
    '更新日：2008/04/22 (Tue) 16:25:35 N.Kojima
    '備　考：
    '　　　：2004/08/25 (Wed)CF判定追加
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima　   数量表示(TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2005/03/01 (Tue) 08:42:05 S.Deguchi    不具合№261の対応でWP_TYPEをﾓｼﾞｭｰﾙ変数へ退避する処理を追加
    '　　　：2005/05/26 (Thu) 13:47:58 N.Kasai      LP_FLAG判定追加
    '　　　：2008/04/22 (Tue) 16:25:35 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvFrmxxCM0070_Disp()

        Try

            With ptypLotprestate
            
                lblLotID.Text = .strLotID                'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass        '流動区分
                lblOpName.Text = .strOpID                '大工程ID
                lblStatus.Text = .strNowST               '状態
                lblStepName.Text = .strStepID            '小工程名
                
                '@子画面起動か
                If pblnfrmxxCM0070Kbn = True Then
                
                    '@子画面起動の場合は、WF枚数はそのまま表示(CFﾌﾗｸﾞの判定は親ﾌｫｰﾑで行う為)
                    If IsNumeric(.strWfNum) Then
                        lblWFNo.Text = Format$(CInt(.strWfNum), CPstrCFKnmaFormat)                         'WF枚数
                    Else
                        lblWFNo.Text = .strWfNum
                    End If
                Else
                    '@単独起動の場合
                
                    '@★CF_FLAGにより処理分岐(WF枚数とﾁｯﾌﾟ枚数の表示を切替) ★
                    Select Case .strCfFlag
                    
                        '@〓 1:CFﾛｯﾄ 〓
                        Case CPstrCF
                        
                            '@ODFﾌﾗｸﾞ(LP_FLAG)が"1:ODF"か
                            If .strLpFlag = CPstrLP Then
                                '@ODFの場合
                                lblWFNo.Text = .strWfNum                                                'WF枚数
                            Else
                                '@ODF以外の場合
                                If IsNumeric(.strChipQuantity) Then
                                    lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)   'ﾁｯﾌﾟ枚数
                                Else
                                    lblWFNo.Text = .strChipQuantity                                     'ﾁｯﾌﾟ枚数
                                End If
                            End If
                            
                        '@〓 CFﾛｯﾄ以外 〓
                        Case Else
                        
                            '@TPALﾛｯﾄか
                            If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                                '@TPALﾛｯﾄの場合
                            
                                If IsNumeric(.strChipQuantity) Then
                                    lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)   'ﾁｯﾌﾟ枚数
                                Else
                                    lblWFNo.Text = .strChipQuantity                                     'ﾁｯﾌﾟ枚数
                                End If
                            Else
                                '@CF,TPALﾛｯﾄ以外
                                lblWFNo.Text = .strWfNum                                                'WF枚数
                            End If
                    End Select
                End If
                
                '@WP_TYPE取得
                mstrWPTYPE = .strWpTypeFlag
            End With
            
            '@責任者IDを有効にする
            txtEmpID.Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxCM0070_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxCM0070_CmbInit
    '機　能：各ﾎﾞﾀﾝの制御処理
    '引　数：lblnEnable：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 13:12:37 N.Kasai
    '更新日：2008/04/22 (Tue) 16:29:13 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 16:29:13 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvFrmxxCM0070_CmbInit(Optional ByVal lblnEnable As Boolean = False)

        Try
            
            '@ｸﾞﾘｯﾄﾞの制御
            vsfCodeList.Enabled = lblnEnable        'ｺｰﾄﾞｸﾞﾘｯﾄﾞ
            vsfWFList.Enabled = lblnEnable          'WFｸﾞﾘｯﾄﾞ

            '@上下ｽｸﾛｰﾙﾎﾞﾀﾝの制御
            cmdUP1.Enabled = lblnEnable             'ｺｰﾄﾞｸﾞﾘｯﾄﾞ用上ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdDown1.Enabled = lblnEnable           'ｺｰﾄﾞｸﾞﾘｯﾄﾞ用下ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdUP2.Enabled = lblnEnable             'WFｸﾞﾘｯﾄﾞ用上ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdDown2.Enabled = lblnEnable           'WFｸﾞﾘｯﾄﾞ用下ｽｸﾛｰﾙﾎﾞﾀﾝ
            
            '@各種ﾎﾞﾀﾝの制御
            cmdScrapCode.Enabled = lblnEnable       '不良
            cmdTakeReason.Enabled = lblnEnable      '払出
            cmdHoldReason.Enabled = lblnEnable      '保留
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxCM0070_CmbInit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfCodeList_Disp
    '機　能：不良/払出/保留ｺｰﾄﾞ＆名称の表示処理
    '引　数：ltypMasItemList：ｺｰﾄﾞ格納用構造体
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 18:05:30 T.Oide
    '更新日：2009/08/20 (Thu) 20:28:41 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 16:41:07 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/05/12 (Tue) 19:37:13 N.Kojima     ﾁｯﾌﾟ払出対応。不良ｺｰﾄﾞ表示時に払出ｺｰﾄﾞを表示しないようにする。(案件№03434)
    '　　　：2009/08/20 (Thu) 20:28:41 N.Kojima     ﾁｯﾌﾟ払出ｺｰﾄﾞが存在する場合、ｲﾝﾃﾞｯｸｽｴﾗｰになる件を修正。(案件№03736)
    Private Sub prvVsfCodeList_Disp(ByRef ltypMasItemList As MasItemList)
        
        Dim llngCnt             As Integer      'ｶｳﾝﾀｰ

        Try
            vsfCodeList.Redraw = False
            
            '@不良ｺｰﾄﾞｸﾞﾘｯﾄﾞの行数の初期設定
            vsfCodeList.Rows.Count = 1

            With ltypMasItemList
                
                '@ﾃﾞｰﾀ分繰り返し
                llngCnt = 1
                Do While .lngListCnt >= llngCnt
                
                    With .typeMasItem(llngCnt - 1)
                        
                        '@払出ｺｰﾄﾞか
                        If .strItemID = CPstrForwardCode Then
                        
                            '@払出ｺｰﾄﾞは表示しない
                        Else
                            '@払出ｺｰﾄﾞ以外
                        
                            '@行数設定
                            vsfCodeList.Rows.Count = vsfCodeList.Rows.Count + 1
                        
        '@↓2009/08/20 (Thu) 20:27:47 N.Kojima **************************************************

        '                    vsfCodeList.Cell(flexcpText, llngCnt, CMlngVsfCodeListCode) = .strItemID      'ｺｰﾄﾞID
        '                    vsfCodeList.Cell(flexcpText, llngCnt, CMlngVsfCodeListName) = .strItemName    'ｺｰﾄﾞ名
                            vsfCodeList.SetData(vsfCodeList.Rows.Count - 1, CMlngVsfCodeListCode, .strItemID)       'ｺｰﾄﾞID
                            vsfCodeList.SetData(vsfCodeList.Rows.Count - 1, CMlngVsfCodeListName, .strItemName)     'ｺｰﾄﾞ名

        '@↑2009/08/20 (Thu) 20:27:47 N.Kojima **************************************************

                        End If
                        
                        llngCnt = llngCnt + 1
                    End With
                Loop
            End With
            
            '@行の高さを設定する
            For i As Integer = 0 To vsfCodeList.Rows.Count - 1
                vsfCodeList.Rows(i).Height = CMlngvsfRowHeight
            Next

            'NSYS 選択行をヘッダに設定
            vsfCodeList.Row = 0

            vsfCodeList.Redraw = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfCodeList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfWFList_Disp
    '機　能：WFｸﾞﾘｯﾄﾞの不良/払出/保留状態の表示処理
    '引　数：ltypWFMapInfo：WFの状態ﾃﾞｰﾀ格納構造体
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 18:20:19 T.Oide
    '更新日：2008/04/22 (Tue) 16:46:39 N.Kojima
    '備　考：
    '　　　：2004/11/18 (Thu) 16:49:18 S.Deguchi    ｽﾛｯﾄの判断処理にｽﾛｯﾄﾎﾟｼﾞｼｮﾝが数値であるか否かの処理を追加
    '　　　：2006/06/08 (Thu) 10:29:13 T.Sawaguchi  不具合No3472　単独起動時のSLOTNo01の色表示を白にする
    '　　　：2008/04/22 (Tue) 16:46:39 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvVsfWFList_Disp(ByRef ltypWaferList As Waferlist)
        
        Dim llngCnt         As Integer  'ｶｳﾝﾀ
        Dim llngWriteRow    As Integer  'ｸﾞﾘｯﾄﾞに書き込む行

        Try
            vsfWFList.Redraw = False
            
            With vsfWFList
            
                '@ｽﾛｯﾄﾏｯﾌﾟの最大ｽﾛｯﾄ数をｷｬﾘｱに応じたｽﾛｯﾄ数に変更
                .Rows.Count = ltypWaferList.strSlotSize + 1
                
                '@ｽﾛｯﾄ№を設定
                llngCnt = 1
                Do While .Rows.Count > llngCnt
                    .SetData(.Rows.Count - llngCnt, CMlngVsfWFListSlotNo, _
                        Format$(llngCnt, CPstrSlotNoFormat))     'ｽﾛｯﾄ№
                    llngCnt = llngCnt + 1
                Loop
            End With
            
            '@WF枚数分ﾙｰﾌﾟ
            llngCnt = 0
            Do While ltypWaferList.lngListCnt > llngCnt
            
                With ltypWaferList.typWfList(llngCnt)
                
                    '@書き込み行設定
                    '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが数値の場合のみ記載
                    If IsNumeric(.strSlotPosition) = True Then
                    
                        llngWriteRow = mlngVsfBottomRow + 1 - CLng(.strSlotPosition)
                        
                        '@ﾃﾞｰﾀ表示
                        vsfWFList.SetData(llngWriteRow, CMlngVsfWFListWFID, .strWfId)         'WFID
                        vsfWFList.SetData(llngWriteRow, CMlngVsfWFListClassID, .strClassID)   'ｸﾗｽID
                        vsfWFList.SetData(llngWriteRow, CMlngVsfWFListClass, .strClass)       'ｸﾗｽ
                        
                        '@良品WF以外か
                        If vsfWFList.GetData(llngWriteRow, CMlngVsfWFListClass) <> CPstrClass1 Then
                            '@変更不可にする
                            vsfWFList.SetData(llngWriteRow, CMlngVsfWFListChange, CMlngChangeNG)    '変更可否ﾌﾗｸﾞに"0:変更不可"をｾｯﾄ
                            Dim newStyle As CellStyle = vsfWFList.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                            Dim cellRange As CellRange = vsfWFList.GetCellRange(llngWriteRow, CMlngVsfWFListClassID)
                            cellRange.Style = newStyle                                              'ｸﾞﾚｰに変更
                        Else
                            '@変更可にする
                            vsfWFList.SetData(llngWriteRow, CMlngVsfWFListChange, CMlngChangeOK)    '変更可否ﾌﾗｸﾞに"1:変更可"をｾｯﾄ
                            Dim newStyle As CellStyle = vsfWFList.Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White
                            Dim cellRange As CellRange = vsfWFList.GetCellRange(llngWriteRow, CMlngVsfWFListClassID)
                            cellRange.Style = newStyle                                              '白色に変更
                        End If
                    End If
                End With
                llngCnt = llngCnt + 1
            Loop
            
            '@WFがない場所または、既にｺｰﾄﾞが入っている個所(基本的にない)を灰色に変更する
            llngCnt = 1
            Do While vsfWFList.Rows.Count > llngCnt
                '@ｸﾗｽがNULLか
                If vsfWFList.GetData(llngCnt, CMlngVsfWFListClass) = vbNullString Then
                    '@ｸﾗｽがNULLのｽﾛｯﾄﾎﾟｼﾞｼｮﾝは背景色=ｸﾞﾚｰに変更
                    Dim newStyle As CellStyle = vsfWFList.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                    Dim cellRange As CellRange = vsfWFList.GetCellRange(llngCnt, CMlngVsfWFListClassID)
                    cellRange.Style = newStyle
                End If
                llngCnt = llngCnt + 1
            Loop
            
            llngCnt = 1
            
            With vsfWFList
                '@行の高さを設定する
                For i As Integer = 0 To .Rows.Count - 1
                    .Rows(i).Height = CMlngvsfRowHeight    '行の高さ
                Next

                '@WF№01の一番下の行を初期選択状態にする
                .Row = .Rows.Count - 1
                
                '@=======================
                '@　ｿｰﾄ前のｶﾚﾝﾄKey値の格納
                '@=======================
                Call pubVsfBeforeSort(vsfWFList, CMlngVsfWFListSlotNo)
                
                '@=======================
                '@　ｿｰﾄ後のｶﾚﾝﾄKey値の格納
                '@=======================
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                Call pubVsfAfterSort(vsfWFList, CMlngVsfWFListSlotNo, cmdUP2, cmdDown2, False, False)
                'NSYS グリッドのtagに保持しているTopRowが不正な値になっているため、設定し直し
                .Tag = .TopRow
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                
                '@不具合No3472　単独起動時のSLOTNo01の色表示を白にする
                '@擬似的にｶﾚﾝﾄ行をﾀｲﾄﾙ行へｾｯﾄしﾌｫｰｶｽを当たっていない様にする
                .Row = CMlngvsfTitle
            End With

            vsfWFList.Redraw = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfWFList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfWFList_Set
    '機　能：ｺｰﾄﾞのWFｸﾞﾘｯﾄﾞへの記入処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 14:58:33 T.Oide
    '更新日：2008/04/22 (Tue) 16:31:36 N.Kojima
    '備　考：
    '　　　：2005/01/05 (Wed) 09:22:19 H.Wajima     ｸﾞﾘｯﾄﾞの外でﾏｳｽのﾎﾞﾀﾝを離した時の対応
    '　　　：2008/04/22 (Tue) 16:31:36 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvVsfWFList_Set()

        Dim llngCnt             As Integer  'ｶｳﾝﾄ
        Dim llngRowTop          As Integer  '選択最上段行
        Dim llngRowBottom       As Integer  '選択最下段行

        Try
            
            '@以下の条件の場合、処理抜け
            '@　①ｺｰﾄﾞが選択されている
            '@　②WFが選択されている
            If vsfCodeList.Row = 0 Or vsfWFList.Row = 0 Then
                Exit Sub
            End If
            
            '@WFｸﾞﾘｯﾄﾞ
            With vsfWFList
            
                '@選択最上段行を格納
                llngRowTop = .Rows.Selected(.Rows.Fixed - 1).Index
                '@選択最下段行を格納
                llngRowBottom = llngRowTop + .Rows.Selected.Count - 1
                
                '@選択最下行が表示最下行より下かどうかを判定
                '@表示最下行の境目でRowIsVisibleが正しく判定されない為
                '@→ｸﾞﾘｯﾄﾞの高さを縮めるとRowIsVisibleが正しく判定できるが、一番下にｽｸﾛｰﾙしたときに
                '@　ｾﾙのない部分が表示されてしまうので注意
                If llngRowBottom > .TopRow + CMlngVsfWFListVisibleRows - 1 Then
                    '@選択最下行が表示最下行より下の場合
                    
                    '@選択最下行に表示最下行を設定
                    llngRowBottom = .TopRow + CMlngVsfWFListVisibleRows - 1
                End If
                
                For llngCnt = llngRowBottom To llngRowTop Step -1
                    
                    '@選択された行が表示されているか
                    If llngCnt >= .TopRow AndAlso llngCnt <= .BottomRow Then
                        
                        '@変更可否ﾌﾗｸﾞが"1"か(良品のもののみ変更可能)
                        If .GetData(llngCnt, CMlngVsfWFListChange) = CMlngChangeOK Then
                            
                            '@既に同じｺｰﾄﾞが記述されているか
                            If .GetData(llngCnt, CMlngVsfWFListClassID) = _
                                vsfCodeList.GetData(vsfCodeList.Row, CMlngVsfCodeListCode) Then
                                
                                '@既に同じｺｰﾄﾞが記述されていたら取り消す
                                .SetData(llngCnt, CMlngVsfWFListClassID, vbNullString)    'ｺｰﾄﾞ
                                .SetData(llngCnt, CMlngVsfWFListClass, CPstrClass1)       'ｸﾗｽ
                            Else
                                '@ｺｰﾄﾞをWFへ記入
                                .SetData(llngCnt, CMlngVsfWFListClassID, vsfCodeList.GetData(vsfCodeList.Row, CMlngVsfCodeListCode))
                                '@ｸﾗｽを記入(mstrClassは一覧取得時に変更)
                                .SetData(llngCnt, CMlngVsfWFListClass, mstrClass)
                            End If
                        End If
                    End If
                Next llngCnt
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfWFList_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmdButon_Edit
    '機　能：ﾎﾞﾀﾝ表示の強調処理
    '引　数：lstrButtonNmae：ﾎﾞﾀﾝ名
    '戻り値：なし
    '作成日：2004/03/31 (Wed) 09:15:23 T.Oide
    '更新日：2008/04/22 (Tue) 17:16:52 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 17:16:52 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvCmdButon_Edit(ByVal lstrButtonNmae As String)

        Try
            
            '@★ ﾎﾞﾀﾝにより処理分岐 ★
            Select Case lstrButtonNmae
            
                '@〓 不良 〓
                Case cmdScrapCode.Name
                
                    cmdScrapCode.Font = New Font(cmdScrapCode.Font, FontStyle.Bold)         '不良ﾎﾞﾀﾝ：有効
                    cmdTakeReason.Font = New Font(cmdTakeReason.Font, FontStyle.Regular)    '払出ﾎﾞﾀﾝ：無効
                    cmdHoldReason.Font = New Font(cmdHoldReason.Font, FontStyle.Regular)    '保留ﾎﾞﾀﾝ：無効
                    
                '@〓 払出 〓
                Case cmdTakeReason.Name
                
                    cmdScrapCode.Font = New Font(cmdScrapCode.Font, FontStyle.Regular)      '不良ﾎﾞﾀﾝ：無効
                    cmdTakeReason.Font = New Font(cmdTakeReason.Font, FontStyle.Bold)       '払出ﾎﾞﾀﾝ：有効
                    cmdHoldReason.Font = New Font(cmdHoldReason.Font, FontStyle.Regular)    '保留ﾎﾞﾀﾝ：無効
                
                '@〓 保留 〓
                Case cmdHoldReason.Name
                
                    cmdScrapCode.Font = New Font(cmdScrapCode.Font, FontStyle.Regular)      '不良ﾎﾞﾀﾝ：無効
                    cmdTakeReason.Font = New Font(cmdTakeReason.Font, FontStyle.Regular)    '払出ﾎﾞﾀﾝ：無効
                    cmdHoldReason.Font = New Font(cmdHoldReason.Font, FontStyle.Bold)       '保留ﾎﾞﾀﾝ：有効
                    
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdButon_Edit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvScrollButtonCheckCode_Disp
    '機　能：ｺｰﾄﾞｸﾞﾘｯﾄﾞのｽｸﾛｰﾙﾎﾞﾀﾝ制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/31 (Wed) 09:51:49 T.Oide
    '更新日：2008/04/22 (Tue) 17:21:45 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 17:21:45 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvScrollButtonCheckCode_Disp()
        
        Dim lngDispStatus           As Integer  'ｽｸﾛｰﾙの状態を格納(1：先頭行表示中、2：最終行表示中、3:両方表示中、以外)

        Try
            
            '@先頭行か判定
            If vsfCodeList.TopRow = 1 Then
                lngDispStatus = 1
            End If
            
            '@最終行か判定
            If vsfCodeList.TopRow + CMlngVsfDispRows = vsfCodeList.Rows.Count Then
                lngDispStatus = 2
            End If
            
            '@表示行がﾘｽﾄ数以下か判定
            If CMlngVsfDispRows >= vsfCodeList.Rows.Count - 1 Then
                lngDispStatus = 3
            End If
            
            With vsfCodeList
            
                '@★ ｺｰﾄﾞｸﾞﾘｯﾄﾞの表示状態により処理分岐 ★
                Select Case lngDispStatus
                
                    '@〓 先頭行が表示されている 〓
                    Case 1

                        cmdUP1.Enabled = False      '上ｽｸﾛｰﾙﾎﾞﾀﾝ：有効
                        cmdDown1.Enabled = True     '下ｽｸﾛｰﾙﾎﾞﾀﾝ：有効
                        
                    '@〓 最終行が表示されている 〓
                    Case 2

                        cmdUP1.Enabled = True       '上ｽｸﾛｰﾙﾎﾞﾀﾝ：有効
                        cmdDown1.Enabled = False    '下ｽｸﾛｰﾙﾎﾞﾀﾝ：無効
                        
                    '@〓 1ﾍﾟｰｼﾞに全て表示されている 〓
                    Case 3

                        cmdUP1.Enabled = False      '上ｽｸﾛｰﾙﾎﾞﾀﾝ：無効
                        cmdDown1.Enabled = False    '下ｽｸﾛｰﾙﾎﾞﾀﾝ：無効
                        
                    '@〓 上記以外 〓
                    Case Else
                    
                        cmdUP1.Enabled = True       '上ｽｸﾛｰﾙﾎﾞﾀﾝ：有効
                        cmdDown1.Enabled = True     '下ｽｸﾛｰﾙﾎﾞﾀﾝ：有効

                End Select
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvScrollButtonCheckCode_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvScrollButtonCheckWF_Disp
    '機　能：WFｸﾞﾘｯﾄﾞのｽｸﾛｰﾙﾎﾞﾀﾝ制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/31 (Wed) 09:51:49 T.Oide
    '更新日：2004/03/31 (Wed) 09:51:49
    '備　考：
    Private Sub prvScrollButtonCheckWF_Disp()

        Dim lngDispStatus           As Integer  'ｽｸﾛｰﾙの状態を格納(1：先頭行表示中、2：最終行表示中、3:両方表示中、以外)

        Try
            
            '@先頭行か判定
            If vsfWFList.TopRow = 1 Then
                lngDispStatus = 1
            End If
            
            '@最終行か判定
            If vsfWFList.TopRow + CMlngVsfDispRows = vsfWFList.Rows.Count Then
                lngDispStatus = 2
            End If
            
            '@表示行がﾘｽﾄ数以下か判定
            If CMlngVsfDispRows > vsfWFList.Rows.Count - 1 Then
                lngDispStatus = 3
            End If
            
            With vsfWFList
            
                '@★ ｺｰﾄﾞｸﾞﾘｯﾄﾞの表示状態により処理分岐 ★
                Select Case lngDispStatus

                    '@〓 先頭行が表示されている 〓
                    Case 1

                        cmdUP2.Enabled = False      '上ｽｸﾛｰﾙﾎﾞﾀﾝ：有効
                        cmdDown2.Enabled = True     '下ｽｸﾛｰﾙﾎﾞﾀﾝ：有効
                        
                    '@〓 最終行が表示されている 〓
                    Case 2

                        cmdUP2.Enabled = True       '上ｽｸﾛｰﾙﾎﾞﾀﾝ：有効
                        cmdDown2.Enabled = False    '下ｽｸﾛｰﾙﾎﾞﾀﾝ：無効
                        
                    '@〓 1ﾍﾟｰｼﾞに全て表示されている 〓
                    Case 3

                        cmdUP2.Enabled = False      '上ｽｸﾛｰﾙﾎﾞﾀﾝ：無効
                        cmdDown2.Enabled = False    '下ｽｸﾛｰﾙﾎﾞﾀﾝ：無効
                        
                    '@〓 上記以外 〓
                    Case Else
                    
                        cmdUP2.Enabled = True       '上ｽｸﾛｰﾙﾎﾞﾀﾝ：有効
                        cmdDown2.Enabled = True     '下ｽｸﾛｰﾙﾎﾞﾀﾝ：有効
                        
                End Select
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvScrollButtonCheckWF_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmdButtonControl_Proc
    '機　能：確定、取消、廃棄ﾎﾞﾀﾝの有効/無効制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 19:03:00 T.Oide
    '更新日：2012/01/26 (Thu) 12:11:49 T.Oide
    '備　考：
    '　　　：2004/09/27 (Mon) 10:37:40 Y.Yamagishi  後処理以外の場合は無効
    '　　　：2005/03/01 (Tue) 08:35:48 S.Deguchi    不具合№261 ﾊﾝﾄﾞﾜｰｸ工程対応
    '　　　：2005/08/24 (Wed) 09:33:53 N.Kojima     貼り合わせ済みﾁｪｯｸの追加。(運用障害№501)
    '　　　：2008/04/22 (Tue) 17:48:18 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2012/01/26 (Thu) 12:11:49 T.Oide       REQ-1283 messvrダウン対応(ﾀﾞﾐｰ再投入を可能にする)
    Private Sub prvCmdButtonControl_Proc()
        
        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
        Dim lblnResurut     As Boolean      '確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(True:有効、False:無効)
        Dim lblnClear       As Boolean      '取消ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(True:有効、False:無効)
        Dim lblnScrap       As Boolean      '廃棄ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(True:有効、False:無効)
        
        Try
            
            '@ﾌﾗｸﾞ初期設定
            lblnResurut = False
            lblnClear = False
            lblnScrap = False
            
            '@*****************
            '@　ﾛｯﾄ情報のﾁｪｯｸ
            '@*****************
            '@ﾊﾝﾄﾞﾜｰｸ工程か
            If mstrWPTYPE = CMstrHandWork Then
                '@ﾊﾝﾄﾞﾜｰｸ工程の場合
                
                '@処理中/後処理か
                If lblStatus.Text = CPstrAfterProgressSt Or _
                   lblStatus.Text = CPstrProcessingSt Then
                   
                    '@H/W工程で処理中or後処理の場合は処理なし
                Else
                    '@H/W工程で処理中/後処理以外の場合

                    lblnResurut = False     '確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
                    lblnClear = False       '取消ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
                    
                    '@H/W工程で作業待ち以外か
                    If lblStatus.Text <> CPstrEndWorkSt Then
                        
                        lblnScrap = False   '廃棄ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
                    End If
                End If
            Else
                '@通常工程の場合
                
                '@後処理以外か
                If lblStatus.Text <> CPstrAfterProgressSt Then
                    
                    lblnResurut = False     '確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
                End If
                
                '@前処理/処理中か
                If lblStatus.Text = CPstrBeforeProgressSt Or _
                    lblStatus.Text = CPstrProcessingSt Then

                    lblnClear = False       '取消ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
                    lblnScrap = False       '廃棄ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
                End If
                
            End If

            '@*****************
            '@　ﾛｯﾄ情報のﾁｪｯｸ
            '@*****************
            '@TPAL貼り合わせ済みかﾁｪｯｸ
            With ptypLotprestate

                '@EQ_TYPE=4(TPAL工程)か
                If .strEqType = CPstrFour Then

                    '@貼り合わせ済みか(strCoverFlag=0：貼り合わせ未完,strCoverFlag=1：貼り合わせ完)
                    If .strCoverFlag = CPstrOne Then
                        
                        lblnResurut = True      '確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：True
                        lblnClear = True        '取消ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：True
                        lblnScrap = True        '廃棄ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：True
                    Else
                        
                        lblnResurut = False     '確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
                        lblnClear = False       '取消ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
                        lblnScrap = False       '廃棄ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
                    End If
                End If
            End With
            
            
            '@*****************
            '@　責任者IDのﾁｪｯｸ
            '@*****************
            '@責任者IDがNULLか
            If txtEmpID.Text = vbNullString Then
            
                lblnResurut = False             '確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
                lblnScrap = False               '廃棄ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
            Else
                lblnClear = True                '取消ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
            End If
            
            
            '@*****************
            '@　WFｸﾞﾘｯﾄﾞのﾁｪｯｸ
            '@*****************
            '@WFｸﾞﾘｯﾄﾞの全てのｽﾛｯﾄに関してﾁｪｯｸ
            llngCnt = 1

            Do While vsfWFList.Rows.Count > llngCnt
            
                '@ｸﾗｽが"1:良品"以外で、かつ変更可否ﾌﾗｸﾞが"1"か(全部取消または確定できる)
                If vsfWFList.GetData(llngCnt, CMlngVsfWFListClass) <> CPstrClass1 And _
                   vsfWFList.GetData(llngCnt, CMlngVsfWFListChange) = CMlngChangeOK Then

                    lblnResurut = True      '確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：True
                    lblnClear = True        '取消ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：True
                    lblnScrap = True        '廃棄ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：True
                    Exit Do
                End If
                llngCnt = llngCnt + 1
            Loop


            '@確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞが"True：有効にする"か
            If lblnResurut = True Then
        '@↓2012/01/26 (Thu) 11:59:41 T.Oide **************************************************
        '@        cmdConfirm.Enabled = True       '有効
        '@-------------------------------------------------------------------------------------
                '@ﾛｯﾄがダミー(SD,FD,ED)の場合「確定」は無効
                '（確定で処理した場合、移載が入って、ダミーの再投入ができなくなる。ﾀﾞﾐｰは「廃棄」で処理する)
                If ptypLotprestate.strFlowClass = CPstrSideDummy Or _
                   ptypLotprestate.strFlowClass = CPstrFillerDummy Or _
                   ptypLotprestate.strFlowClass = CPstrExtraDummy Then
                   
                    '@ﾀﾞﾐｰの場合無効
                    cmdConfirm.Enabled = False       '無効
                Else
                    '@ﾀﾞﾐｰ以外は有効
                    cmdConfirm.Enabled = True       '有効
                End If
        '@↑2012/01/26 (Thu) 11:59:41 T.Oide **************************************************
            
            Else
                cmdConfirm.Enabled = False      '無効
            End If
            
            '@取消ﾎﾞﾀﾝ制御ﾌﾗｸﾞが"True：有効にする"か
            If lblnClear = True Then
                cmdClear.Enabled = True         '有効
            Else
                cmdClear.Enabled = False        '無効
            End If
            
            '@廃棄ﾎﾞﾀﾝ制御ﾌﾗｸﾞが"True：有効にする"か
            If lblnScrap = True Then
                cmdScrap.Enabled = True         '有効
            Else
                cmdScrap.Enabled = False        '無効
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdButtonControl_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMapTopRow_Set
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの初期表示頁設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/26 (Tue) 13:17:15 M.Miura
    '更新日：2008/04/22 (Tue) 15:53:18 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 15:53:18 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvVsfSlotMapTopRow_Set()

        Dim llngCnt     As Integer  'ｶｳﾝﾄ
        Dim llngRows    As Integer  '行数
        Dim lblnFlag    As Boolean  'WF存在判定ﾌﾗｸﾞ(True:WFあり、False:WFなし)

        Try
              
            '@WFｸﾞﾘｯﾄﾞの各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfWFList
                
                '@WF存在判定ﾌﾗｸﾞの初期化
                lblnFlag = False
                
                '@ｽﾛｯﾄﾏｯﾌﾟの行数取得
                llngRows = .Rows.Count
                
                '@最大ｽﾛｯﾄが25より小さい場合
                If llngRows < CMlngVsfWFListRows Then
                    '@ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Fixed - 1
                    Exit Sub
                End If
                
                '@ｽﾛｯﾄ№01～10まで
                For llngCnt = CMlngVsfWFListRows - 1 To CMlngSlotNo10Row Step -1
                    '@WFが存在する場合
                    If .GetData(llngCnt, CMlngVsfWFListWFID) <> vbNullString Then
                        '@WFあり
                        lblnFlag = True
                        Exit For
                    End If
                Next llngCnt
                
                '@ｽﾛｯﾄ№01～10にWFがない場合
                If lblnFlag = False Then
                    '@ｽﾛｯﾄ№25～16まで
                    For llngCnt = .Rows.Fixed To CMlngSlotNo16Row
                        '@WFが存在する場合
                        If .GetData(llngCnt, CMlngVsfWFListWFID) <> vbNullString Then
                            '@ｽﾛｯﾄﾏｯﾌﾟの初期表示は上部
                            lblnFlag = True
                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@ｽﾛｯﾄﾏｯﾌﾟの初期表示は下部
                    lblnFlag = False
                End If
                
                '@ｽﾛｯﾄﾏｯﾌﾟ上部表示の場合
                If lblnFlag = True Then
                    
                    .TopRow = .Rows.Fixed            'ｽﾛｯﾄﾏｯﾌﾟのﾍﾟｰｼﾞ先頭行を設定
                    .Row = .Rows.Fixed - 1           'ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    
                    '@上ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                    cmdUP2.Enabled = False
                    
                    '@最大ｽﾛｯﾄ数が1ﾍﾟｰｼﾞを超えている場合
                    If .Rows.Count > CMlngVsfDispRows + 1 Then
                        '@下ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                        cmdDown2.Enabled = True
                    Else
                        '@下ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                        cmdDown2.Enabled = False
                    End If
                Else
                    '@WFなしの場合

                    .TopRow = CMlngSlotNo10Row      'ｽﾛｯﾄﾏｯﾌﾟのﾍﾟｰｼﾞ先頭行を設定
                    .Row = .Rows.Fixed - 1           'ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMapTopRow_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnLotOut_Chk
    '機　能：ﾛｯﾄｱｳﾄﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾛｯﾄｱｳﾄ、False：不良、保留、払出し
    '作成日：2004/10/29 (Fri) 13:30:26 M.Miura
    '更新日：2008/04/22 (Tue) 15:51:04 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 15:51:04 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Function prvblnLotOut_Chk() As Boolean

        Dim llngRow     As Integer '行番号

        Try
            
            With vsfWFList
            
                '@WFｸﾞﾘｯﾄﾞのﾃﾞｰﾀ行がない場合
                If .Rows.Count <= .Rows.Fixed Then
                    Exit Function
                End If
                
                '@戻り値に"True:ﾛｯﾄｱｳﾄ"をｾｯﾄ
                prvblnLotOut_Chk = True
            
                '@WFｸﾞﾘｯﾄﾞの行数分ﾙｰﾌﾟ
                For llngRow = .Rows.Fixed To .Rows.Count - 1
                    '@良品WFの場合
                    If .GetData(llngRow, CMlngVsfWFListClassID) = vbNullString And _
                       .GetCellRange(llngRow, CMlngVsfWFListClassID).StyleDisplay.BackColor <> ColorTranslator.FromWin32(CPlngGridDarkGray) Then
                       
                        '@戻り値に"False:ﾛｯﾄｱｳﾄ以外"をｾｯﾄ
                        prvblnLotOut_Chk = False
                        Exit For
                    End If
                Next llngRow
            End With

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotOut_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnDataSet_Proc
    '機　能：変更/廃棄登録情報格納処理(変更になったWFのﾃﾞｰﾀのみ)
    '引　数：lstrEventID    ：呼び元ｲﾍﾞﾝﾄ(確定or廃棄)
    '戻り値：なし
    '作成日：2004/03/26 (Fri) 14:54:33 T.Oide
    '更新日：2011/10/19 (Wed) 17:04:36 T.Oide
    '備　考：
    '　　　：2005/03/22 (Tue) 15:19:03 N.Kasai      WFのﾙｰﾌﾟｶｳﾝﾄ数修正。(不具合№626対応)
    '　　　：2007/02/13 (Tue) 16:45:46 N.Kasai      処理区分追加(№01739)
    '　　　：2008/04/22 (Tue) 17:11:42 N.Kojima     ｿｰｽ整備、不良/払出登録に権限ﾁｪｯｸ機能を追加する対応。(案件№02786)
    '　　　：2011/10/19 (Wed) 17:04:46 T.Oide       払出、保留時の確認ﾒｯｾｰｼﾞ対応
    Private Function prvblnDataSet_Proc(ByVal lstrEventID As String) As Boolean
        
        Dim llngCnt                     As Integer      'ｶｳﾝﾀ
        Dim llngChangeWFCnt             As Integer      '変更するWFの数
    '@↓2011/10/19 (Wed) 17:04:27 T.Oide **************************************************
        Dim llngAns                     As Integer      'ﾒｯｾｰｼﾞの結果格納
    '@↑2011/10/19 (Wed) 17:04:27 T.Oide **************************************************

        Try
            
            '@戻り値の初期化
            prvblnDataSet_Proc = False
            
            '@責任者ID、または責任者名がNULLか
            If txtEmpID.Text = vbNullString Or lblEmpName.Text = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001B)
                '@"<TRM1BW>$$責任者IDを入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@責任者IDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtEmpID)
                Exit Function
            End If

            '@ｶｳﾝﾀ初期化
            llngCnt = 1
            llngChangeWFCnt = 0
            
            '@ﾓｼﾞｭｰﾙ変数の初期化
            mblnFuryouClass = False         '不良存在判定ﾌﾗｸﾞ
            mblnHaraidashiClass = False     '払出存在判定ﾌﾗｸﾞ
        '@↓2011/10/19 (Wed) 16:55:15 T.Oide **************************************************
            mblnHoryuClass = False          '保留判定ﾌﾗｸﾞ
        '@↑2011/10/19 (Wed) 16:55:15 T.Oide **************************************************
            
            Do While vsfWFList.Rows.Count > llngCnt
                
                '@変更可否ﾌﾗｸﾞが｢1:変更可｣で、かつｸﾗｽが「1:良品」以外のﾚｺｰﾄﾞを格納
                If vsfWFList.GetData(llngCnt, CMlngVsfWFListChange) = CMlngChangeOK And _
                    vsfWFList.GetData(llngCnt, CMlngVsfWFListClass) <> CPstrClass1 Then
                    
                    '@呼び元ｲﾍﾞﾝﾄが"確定ﾎﾞﾀﾝ押下"か
                    If lstrEventID = CMstrCmdConfirmClick Then
                        '@「確定ﾎﾞﾀﾝ押下」の場合
                    
                        '@構造体の領域確保
                        Dim typWfListTmp As LotInsprstWF = New LotInsprstWF
                    
                        With typWfListTmp
                            .strWfId = vsfWFList.GetData(llngCnt, CMlngVsfWFListWFID)              'WFID
                            .strSlotPosition = vsfWFList.GetData(llngCnt, CMlngVsfWFListSlotNo)    'ｽﾛｯﾄ№
                            .strClass = vsfWFList.GetData(llngCnt, CMlngVsfWFListClass)            'ｸﾗｽ
                            .strClassID = vsfWFList.GetData(llngCnt, CMlngVsfWFListClassID)        'ｸﾗｽID
                            
                            '@不良登録WFか
                            If .strClass = CPstrClass2 Then
                                '@不良存在判定ﾌﾗｸﾞに"True:不良あり"をｾｯﾄ
                                mblnFuryouClass = True
                            End If
                            
                            '@払出登録WFか
                            If .strClass = CPstrClass3 Then
                                '@払出存在判定ﾌﾗｸﾞに"True:払出あり"をｾｯﾄ
                                mblnHaraidashiClass = True
                            End If
                            
        '@↓2011/10/19 (Wed) 16:52:53 T.Oide **************************************************
                            '@保留登録WFか
                            If .strClass = CPstrClass4 Then
                                '@払出存在判定ﾌﾗｸﾞに"True:払出あり"をｾｯﾄ
                                mblnHoryuClass = True
                            End If
        '@↑2011/10/19 (Wed) 16:52:53 T.Oide **************************************************
                            If mtypLotInsprst.typWfList Is Nothing Then
                                mtypLotInsprst.typWfList = New List(Of LotInsprstWF)
                            End If
                            mtypLotInsprst.typWfList.Add(New LotInsprstWF())
                            mtypLotInsprst.typWfList(llngChangeWFCnt) = typWfListTmp
                        End With
                    Else
                        '@「廃棄ﾎﾞﾀﾝ押下」の場合
                        
                        '@構造体の領域確保
                        Dim typScrapWFListTmp As ScrapWF = New ScrapWF
                    
                        With typScrapWFListTmp
                            .strWfId = vsfWFList.GetData(llngCnt, CMlngVsfWFListWFID)              'WFID
                            .strSlotPosition = vsfWFList.GetData(llngCnt, CMlngVsfWFListSlotNo)    'ｽﾛｯﾄ№
                            .strClass = vsfWFList.GetData(llngCnt, CMlngVsfWFListClass)            'ｸﾗｽ
                            .strClassID = vsfWFList.GetData(llngCnt, CMlngVsfWFListClassID)        'ｸﾗｽID
                            
                            '@不良登録WFか
                            If .strClass = CPstrClass2 Then
                                '@不良存在判定ﾌﾗｸﾞに"True:不良あり"をｾｯﾄ
                                mblnFuryouClass = True
                            End If
                            
                            '@払出登録WFか
                            If .strClass = CPstrClass3 Then
                                '@払出存在判定ﾌﾗｸﾞに"True:払出あり"をｾｯﾄ
                                mblnHaraidashiClass = True
                            End If
                            
        '@↓2011/10/19 (Wed) 16:52:53 T.Oide **************************************************
                            '@保留登録WFか
                            If .strClass = CPstrClass4 Then
                                '@払出存在判定ﾌﾗｸﾞに"True:払出あり"をｾｯﾄ
                                mblnHoryuClass = True
                            End If
        '@↑2011/10/19 (Wed) 16:52:53 T.Oide **************************************************
                            If mtypDirectScrap.typScrapWFList Is Nothing Then
                                mtypDirectScrap.typScrapWFList = New List(Of ScrapWF)
                            End If
                            mtypDirectScrap.typScrapWFList.Add(New ScrapWF())
                            mtypDirectScrap.typScrapWFList(llngChangeWFCnt) = typScrapWFListTmp
                        End With
                    End If
                    
                    '@変更/廃棄WFｶｳﾝﾄを+1する
                    llngChangeWFCnt = llngChangeWFCnt + 1
                End If
                
                '@WFｸﾞﾘｯﾄﾞのﾙｰﾌﾟｶｳﾝﾀを+1する
                llngCnt = llngCnt + 1
            Loop

        '@↓2011/10/19 (Wed) 16:58:25 T.Oide **************************************************
            '@PR Or Es で且つ 払出 Or 保留 か
            If (lblFlowClass.Text = CPstrFlowClassPR Or lblFlowClass.Text = CPstrFlowClassES) And _
               (mblnHaraidashiClass = True Or mblnHoryuClass = True) Then
                
                '@ﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0114, Me.Text)
                '@<TRM114W>$$PR/ES品を$[払出/保留]の理由で[%1]する場合、$別途伝票の発行が必要です。
                '　　　　　$$生産管理部門と調整のうえ伝票の発行を行ってください｡
                llngAns = publngMsgBox(pstrDMsg, vbNo, Me.Text, True, 16)
                
                '@いいえの場合は処理を中止
                If llngAns = vbNo Then
                    Exit Function
                End If
            End If
        '@↑2011/10/19 (Wed) 16:58:25 T.Oide **************************************************
            
            '@登録するﾃﾞｰﾀがない場合は中止
            If llngChangeWFCnt = 0 Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0031)
                '@"<TRM31W>$$登録するデータがありません。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Function
            End If
            
            
            '@呼び元ｲﾍﾞﾝﾄが"確定ﾎﾞﾀﾝ押下"か
            If lstrEventID = CMstrCmdConfirmClick Then
                '@「確定ﾎﾞﾀﾝ押下」の場合
                
                '@基本ﾃﾞｰﾀ格納
                With mtypLotInsprst
                    .lngListCnt = llngChangeWFCnt                           '変更情報のあるWFの数
                    .strLotID = lblLotID.Text                               'ﾛｯﾄID
                    .strResponsble_Emp_ID = txtEmpID.Text                   '責任者ID
                    .strLotLastUpdate = ptypLotprestate.strLotLastUpdate    '最終更新日時
                    .strClassDivision = CPstrCD17                           'WF処置登録(処理区分：17)
                End With
            Else
                '@「廃棄ﾎﾞﾀﾝ押下」の場合
                
                '@基本ﾃﾞｰﾀ格納
                With mtypDirectScrap
                    .lngScrapWFListCnt = llngChangeWFCnt                    '対象WF数
                    .strMsgVer = CMstrwf__directscrapVer                    'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                    .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸID
                    .strCarrierId = txtCarrier.Text                         'ｷｬﾘｱID
                    .strLotID = lblLotID.Text                               'ﾛｯﾄID
                    .strResponsble_Emp_ID = txtEmpID.Text                   '責任者ID
                    .strLotLastUpdate = ptypLotprestate.strLotLastUpdate    '最終更新日時
                End With
            End If
            
            
            '@戻り値に"True:成功"をｾｯﾄ
            prvblnDataSet_Proc = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnDataSet_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnRegistAuthority_Chk
    '機　能：WF状態変更/WF廃棄権限ﾁｪｯｸ処理
    '引　数：lstrEventID    ：呼び元ｲﾍﾞﾝﾄ(確定 or 廃棄)
    '戻り値：True:成功、False:失敗
    '作成日：2008/04/22 (Tue) 15:18:39 N.Kojima
    '更新日：2012/12/17 (Mon) 10:47:50 T.Oide
    '備　考：
    Private Function prvblnRegistAuthority_Chk(ByVal lstrEventID As String) As Boolean
        
        Dim lstrFunctionID          As String       '機能ID
        Dim lstrActionID            As String       'ｱｸｼｮﾝID
        Dim lstrWkEmpID             As String       '作業者ID(退避用)
        Dim lstrEmpName             As String       '作業者名
        Dim lblnAuthorityCheckFlag  As Boolean      '権限ﾁｪｯｸ制御ﾌﾗｸﾞ(True：権限ﾁｪｯｸを行なう、Flase：権限ﾁｪｯｸを行なわない)
        Dim lblnAns                 As Boolean      '戻り値格納用

        Try
            
            '@戻り値を初期化する
            prvblnRegistAuthority_Chk = False

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Function
            End If
            
            '@作業者IDを退避
            lstrWkEmpID = pstrUserID
            
            '@***************************
            '@　権限ﾁｪｯｸが必要か判定する
            '@***************************
            '@★ 所属ｸﾞﾙｰﾌﾟIDにより処理分岐 ★
            Select Case pstrGroupID
            
        '@↓2012/12/17 (Mon) 10:49:47 T.Oide **************************************************
        '@        '@〓 STAFF(技術) 〓
        '@        Case CPstrDeptIDStaff
        '@
        '@            '@職場IDが"STAFF"で、かつ登録ﾃﾞｰﾀに"不良"が存在するか
        '@            If mblnFuryouClass = True Then
        '@                '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
        '@                lblnAuthorityCheckFlag = True
        '@            End If
        '@
        '@        '@〓 LINE(製造) 〓
        '@        Case CPstrDeptIDLine
        '@
        '@            '@職場IDが"LINE"で、かつ登録ﾃﾞｰﾀに"払出"が存在するか
        '@            If mblnHaraidashiClass = True Then
        '@                '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
        '@                lblnAuthorityCheckFlag = True
        '@            End If
        '@ -----------------------------------------------------------------------------------

                '@〓 STAFF(技術) 〓,〓 LINE(製造) 〓
                Case CPstrDeptIDStaff, CPstrDeptIDLine
                
                    '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
                    lblnAuthorityCheckFlag = True
                    
        '@↑2012/12/17 (Mon) 10:49:47 T.Oide **************************************************
                    
                '@〓 その他(現在はSYSTEMのみ) 〓
                Case Else

                    '@職場IDが"STAFF"or"LINE"以外で、かつ登録ﾃﾞｰﾀに"不良"or"払出"が存在するか
                    If mblnFuryouClass = True Or mblnHaraidashiClass = True Then
                        '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
                        lblnAuthorityCheckFlag = True
                    End If
                    
            End Select
                    
            '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
            If lblnAuthorityCheckFlag = True Then
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　ﾊﾟｽﾜｰﾄﾞ付き作業者ｺｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                With frmxxCM0020.Instance
                    .txtUserID.Text = lstrWkEmpID
                    .txtUserID.Enabled = False
                    .ShowDialog(Me)
                End With

                frmxxCM0020.Instance = Nothing
                
                '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
                If pblnCancel = True Then
                    Exit Function
                End If
                
                '@実行権限の処理を追加
                lstrFunctionID = CPstrKeyEN0180             '機能ID：EN0180(WF状態変更登録)
                lstrActionID = CPstrWFStatusChange          'ｱｸｼｮﾝID：不良/払出
                lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名：NULL
                
                '@=======================
                '@　実行権限ﾁｪｯｸ処理
                '@=======================
                lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                           lstrActionID, _
                                           pstrUserID, _
                                           lstrEmpName, _
                                           pstrSBID)

                '@通信結果判定
                If lblnAns = False Then
                    '@結果：異常の場合
            
                    '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    Exit Function
                End If
            End If
            
            '@呼び元ｲﾍﾞﾝﾄが"確定ﾎﾞﾀﾝ押下"か
            If lstrEventID = CMstrCmdConfirmClick Then
                '@「確定ﾎﾞﾀﾝ押下」の場合
                mtypLotInsprst.strEngEmpId = pstrUserID     '作業者ID
            Else
                '@「廃棄ﾎﾞﾀﾝ押下」の場合
                mtypDirectScrap.strEngEmpId = pstrUserID    '作業者ID
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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraCodeList.Paint, fraWFInfo.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub


    '関数名：vsfWFList_MouseDown
    '機　能：ヘッダを左クリックされたら全選択する
    '引　数：sender：イベント発生源のオブジェクト
    '　　　：e  ：イベントに関連する補足情報
    '戻り値：なし
    '作成日：2019/06/14 (Fri) 14:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub vsfWFList_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfWFList.MouseDown

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfWFList.Rows.Count <= vsfWFList.Rows.Fixed Then
                Return
            End If
            
            With vsfWFList
                '@ﾍｯﾀﾞｰの№列を左ｸﾘｯｸされたら
                If .MouseRow = 0 And .MouseCol = CMlngvsfWFListSlotNo Then
                    Select Case e.Button
                        Case MouseButtons.Left
                            '@全選択
                            .Select(.Rows.Fixed, .Cols.Fixed, .Rows.Count - 1, .Cols.Count - 1 , False)
                    End Select
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWFList_MouseDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmdClear.Enter,
                                                                       cmdClose.Enter,
                                                                       cmdConfirm.Enter,
                                                                       cmdDown1.Enter,
                                                                       cmdDown2.Enter,
                                                                       cmdHoldReason.Enter,
                                                                       cmdScrap.Enter,
                                                                       cmdScrapCode.Enter,
                                                                       cmdTakeReason.Enter,
                                                                       cmdUp1.Enter,
                                                                       cmdUp2.Enter,
                                                                       txtCarrier.Enter,
                                                                       txtEmpID.Enter,
                                                                       vsfCodeList.Enter,
                                                                       vsfWFList.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタン、取消ボタンの場合は自動Validate = OFF
            Case "cmdClose","cmdClear"
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
                '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

    '関数名：flex_OwnerDrawCell
    '機　能：オーナー描画イベント。Focusの背景色のカスタマイズ
    '引　数：sender：イベント発生元
    '　　　：e     ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/03/13 (Wed) 18:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flex_OwnerDrawCell(ByVal sender As Object, ByVal e As OwnerDrawCellEventArgs) Handles vsfWFList.OwnerDrawCell
        pubVsfOwnerDrawCell(CType(sender, C1FlexGrid), e)
    End Sub
    
End Class
