'ﾌｧｲﾙ名：xxEN02L0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：GRB属性設定　メインフォーム
'作成日：2016/02/11 (Thu) 23:23:37 H.Hayashi
'更新日：
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2016-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02L0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02L0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02L0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02L0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02L0)
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
    '@↓2020/03/06 (Fri) 12:50:56 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion             As String = "01.00"         '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion             As String = "01.01"         '機能ﾊﾞｰｼﾞｮﾝ
    '@↑2020/03/06 (Fri) 12:50:56 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN02L0  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 14:08:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer          As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer          As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:08:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_waferlistVer         As String = "02.05"         'ﾛｯﾄWF情報取得(新)
    'Private Const CMstrwf__directscrapVer       As String = "02.00"         'WF直接廃棄処理

    Private Const CMstrmas_definelistVer        As String = "01.00"         'DEFINE情報取得
    Private Const CMstrwf__grbset_Ver           As String = "01.00"         'GRB属性設定
    Private Const CMstrlot_grbstatusVer         As String = "01.00"         'GRB状態取得

    '@vsfCodeListのｶﾗﾑ定数
    Private Const CMlngVsfCodeListCode          As Integer = 0              'ｺｰﾄﾞのｶﾗﾑ
    Private Const CMlngVsfCodeListName          As Integer = 1              '名称のｶﾗﾑ

    '@vsfWFListのｶﾗﾑ定数
    Private Const CMlngVsfWFListSlotNo          As Integer = 0              'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝのｶﾗﾑ
    Private Const CMlngVsfWFListWFID            As Integer = 1              'WFID
    Private Const CMlngVsfWFListClassID         As Integer = 2              'ｸﾗｽIDのｶﾗﾑ
    Private Const CMlngVsfWFListClass           As Integer = 3              'ｸﾗｽのｶﾗﾑ(隠し)(1:良品、2：不良、3：払出し、4：保留)
    Private Const CMlngVsfWFListChange          As Integer = 4              '変更可否(1：変更可、0：変更不可)
    Private Const CMlngVsfWFListGrbClass        As Integer = 5              'GRB区分

    '@vsfWFListのﾌﾟﾛﾊﾟﾃｨ定数
    Private Const CMlngvsfRowHeight             As Integer = 38             '行の高さ
    Private Const CMlngVsfWFListVisibleRows     As Integer = 10             '表示行数
    Private Const CMlngVsfDispRows              As Integer = 10             '画面の表示行数(ｽｸﾛｰﾙﾎﾞﾀﾝの計算で使用)
    Private Const CMlngvsfBottomRow             As Integer = 25             '画面の一番下の行(WF№01の行)
    Private Const CMlngvsfTitle                 As Integer = 0              'ﾌﾚｯｸｽｸﾞﾘｯﾄﾞのﾀｲﾄﾙ行
    Private Const CMlngVsfWFListRows            As Integer = 26             'ｽﾛｯﾄﾏｯﾌﾟの行数
    Private Const CMlngSlotNo10Row              As Integer = 17             '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№10の行番号
    Private Const CMlngSlotNo16Row              As Integer = 11             '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№16の行番号

    '@↓2019/12/13 (Fri) 16:30:43 Y.Yoneyama 「.Netへ反映未」 **************************************************
    '@CM0040へ移動
    '@色宣言
    ''Private Const CMlngEnableTrueColor          As Long = &H80000005        '白(使用可)
    'Private Const CMlngG_BackColor              As Integer = &HCCFFCC       '緑系色(G区分ﾊﾞｯｸｶﾗｰ)
    'Private Const CMlngR_BackColor              As Integer = &HCC99FF       '赤系色(R区分ﾊﾞｯｸｶﾗｰ)
    'Private Const CMlngB_BackColor              As Integer = &HFFCC99       '青系色(B区分ﾊﾞｯｸｶﾗｰ)
    'Private Const CMlngGR_BackColor             As Integer = &H99FFFF       '緑赤系色(GR区分ﾊﾞｯｸｶﾗｰ)
    'Private Const CMlngGB_BackColor             As Integer = &H669933       '緑青系色(GB区分ﾊﾞｯｸｶﾗｰ)
    'Private Const CMlngRB_BackColor             As Integer = &HFF99CC       '赤青系色(RB区分ﾊﾞｯｸｶﾗｰ)
    '
    ''@GRB区分
    'Private Const CMstrGRB_G                    As String = "G"             'G属性
    'Private Const CMstrGRB_R                    As String = "R"             'R属性
    'Private Const CMstrGRB_B                    As String = "B"             'B属性
    'Private Const CMstrGRB_GR                   As String = "GR"            'GR属性
    'Private Const CMstrGRB_GB                   As String = "GB"            'GB性
    'Private Const CMstrGRB_RB                   As String = "RB"            'RB属性
    '@↑2019/12/13 (Fri) 16:30:43 Y.Yoneyama 「.Netへ反映未」 **************************************************

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

    '@DEFINE情報
    Private Const CMstrTableName                As String = "GRB_CLASS"
    Private Const CMstrColumnName               As String = "GRB_DATA"

    'GRB状態
    Private Const CMstrGrbStatus0               As String = "0"              'GRB設定なし
    Private Const CMstrGrbStatus1               As String = "1"              'GRB属性設定済み
    Private Const CMstrGrbStatus2               As String = "2"              'GRB分割有り
    Private Const CMstrGrbStatus3               As String = "3"              'GRB区分設定済み(ﾛｯﾄ)
    Private Const CMstrGrbStatus4               As String = "4"              'GRB区分設定済み(工程)
    Private Const CMstrGrbStatus5               As String = "5"              'GRB分割工程以外

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                 As String = "frmxxEN02L0"           '自ﾌｫｰﾑ名
    Private Const CMstrTxtCarrierValidate       As String = "txtCarrier_Validate"   'ｷｬﾘｱ確定時処理
    Private Const CMstrCmdConfirmClick          As String = "cmdConfirm_Click"      'GRB属性設定処理

    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypLotInsprst                      As LotInsprst               '変更登録ﾃﾞｰﾀ格納構造体
    Private mtypDirectScrap                     As DirectScrap              '廃棄登録ﾃﾞｰﾀ格納構造体
    Private mstrClass                           As String                   '1:良品、2:払出し、3:保留
    Private mstrCarrier                         As String                   'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mblnTakeOverDispFlg                 As Boolean                  '引継ぎ表示ﾌﾗｸﾞ
    Private mlngVsfBottomRow                    As Integer                  '画面の一番下の行(WF№01の行)
    Private mstrWPTYPE                          As String                   'WP_TYPE(=0：ﾊﾝﾄﾞﾜｰｸ/1：装置)
    Private mstrGrbStatus                       As String                   'GRB状態

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
        pubVsfMouseWheelManager_Set(vsfCodeList, cmdUp1, cmdDown1)
        pubVsfMouseWheelManager_Set(vsfWFList, cmdUp2, cmdDown2)

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
    '作成日：2016/02/11 (Thu) 23:45:27 H.Hayashi
    '更新日：
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns                 As Boolean      '戻り値

        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = 0 - My.Settings.FormOffset

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@=======================
            '@　機能ﾊﾞｰｼﾞｮﾝの判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02L0, CMstrLocalVersion)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            '@ﾌｫｰﾑ起動区分が子画面としての起動か
            If pblnfrmxxEN02L0Kbn = True Then
                '@子画面起動の場合
                
                '@=======================
                '@　画面初期化処理
                '@=======================
                Call prvFrmxxEN02L0_Init()
                
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
                Call prvFrmxxEN02L0_Init()
                
                '@=======================
                '@　単独起動時初期化処理
                '@=======================
                Call prvIndependentLoad_Init()
                
                '@=======================
                '@　各種ﾎﾞﾀﾝ制御処理(使用不可)
                '@=======================
                Call prvFrmxxEN02L0_CmbInit(False)
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
    '作成日：2016/02/11 (Thu) 23:46:27 H.Hayashi
    '更新日：
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@子画面としての起動か
            If pblnfrmxxEN02L0Kbn = True Then
            
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
    '作成日：2016/02/11 (Thu) 23:46:27 H.Hayashi
    '更新日：
    '備　考：
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
            '@　GRB属性ｺｰﾄﾞ一覧ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfCodeList, cmdUP1, cmdDown1)
            
            '@=======================
            '@　WF情報ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfWFList, cmdUP2, cmdDown2, False)
            
            
            '@子画面起動か
            If pblnfrmxxEN02L0Kbn = True Then
                '@子画面起動の場合
            
                Select Case e.KeyCode
                    
                    '@Enterｷｰの場合
                    Case Keys.Return
                        
                        '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙがWF情報ｸﾞﾘｯﾄﾞか
                        If ActiveControl.Name = vsfWFList.Name Then
                            '@WF情報ｸﾞﾘｯﾄﾞのｸﾘｯｸ処理
                            
                            '@=======================
                            '@　GRB属性ｺｰﾄﾞ等をWFｸﾞﾘｯﾄﾞへの記入処理
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
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Exit Sub
                        End If
                        
                        '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙがWF情報ｸﾞﾘｯﾄﾞか
                        If ActiveControl.Name = vsfWFList.Name Then

                            '@=======================
                            '@　GRB属性ｺｰﾄﾞ等をWFｸﾞﾘｯﾄﾞへの記入処理
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
                    
                    'NSYS [↑]ｷｰ
                    Case Keys.Up                        
                        If ActiveControl.Name = vsfWFList.Name Then
                            With vsfWFList
                                'NSYS VB6互換動作 複数行選択されている場合グリッドをスクロールさせない
                                If .Row <> .RowSel AndAlso .RowSel = .TopRow AndAlso e.Shift Then
                                    e.Handled = True
                                End If
                            End With
                        End If
                    'NSYS [↓]ｷｰ
                    Case Keys.Down
                        If ActiveControl.Name = vsfWFList.Name Then
                            With vsfWFList
                                'NSYS VB6互換動作 複数行選択されている場合グリッドをスクロールさせない
                                If .Row <> .RowSel AndAlso .RowSel = .BottomRow AndAlso e.Shift Then
                                    e.Handled = True
                                End If
                            End With
                        End If
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
    '作成日：2016/02/11 (Thu) 23:46:27 H.Hayashi
    '更新日：
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm         As Boolean          '開放結果格納
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
            mtypLotInsprst = ltypLotInsprst         '変更登録ﾃﾞｰﾀ格納構造体
            mtypDirectScrap = ltypDirectScrap       '廃棄登録ﾃﾞｰﾀ格納構造体

            '@子画面起動か
            If pblnfrmxxEN02L0Kbn = True Then
                '@子画面起動の場合
            
                '@ﾌｫｰﾑ起動区分を初期化
                pblnfrmxxEN02L0Kbn = False
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
    '作成日：2016/02/12 (Fri) 00:02:52 H.Hayashi
    '更新日：
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try

            '@子画面起動か
            If pblnfrmxxEN02L0Kbn = True Then
                '@子画面起動の場合
                Exit Sub
            Else
                '@単独起動の場合
                
                '@=======================
                '@　画面初期化処理(ｷｬﾘｱID未編集)
                '@=======================
                Call prvFrmxxEN02L0_Init(False)
                
                '@=======================
                '@　WF情報ｸﾘｱ(固定行および列以外をｸﾘｱ)
                '@=======================
                'Call vsfWFList.Clear(ClearFlags.Content Or ClearFlags.Style) 'flexClearScrollable
                'vsfWFList.SetData(vsfWFList.Rows.Fixed - 1, CMlngVsfWFListWFID, "WFID")
                'vsfWFList.SetData(vsfWFList.Rows.Fixed - 1, CMlngVsfWFListClassID, "GRB")
                
                '@=======================
                '@　各種ﾎﾞﾀﾝ制御処理(使用不可)
                '@=======================
                Call prvFrmxxEN02L0_CmbInit(False)
                
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
    '作成日：2016/02/12 (Fri) 02:01:54 H.Hayashi
    '更新日：
    '備　考：
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAnsFWInfo           As Boolean              'WF情報の取得結果格納
        Dim ltypWaferList           As Waferlist            'WFおよびﾁｯﾌﾟ情報格納用構造体
        Dim lblnAnsScrap            As Boolean              '不良ｺｰﾄﾞ取得結果格納
        Dim lblnAns                 As Boolean              '戻り値格納用
        Dim lstrRWEndFlag           As String               '特殊流動最終工程判断ﾌﾗｸﾞ
        Dim lstrRWFlag              As String               '特殊流動中ﾌﾗｸﾞ
        Dim lstrSelect              As String               '特殊流動名退避領域
        Dim ltypMasDefineReq        As MasDefineReq         'DEFINE情報（要求）
        Dim ltypMasDefineAns        As MasDefineAns         'DEFINE情報（応答）
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
            
            '@子画面起動か
            If pblnfrmxxEN02L0Kbn = True Then
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
                If pblnfrmxxEN02L0Kbn = False AndAlso lblnNextCtrl Then
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
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
                If pblnfrmxxEN02L0Kbn = False AndAlso lblnNextCtrl Then
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
           
                    '@【GRB状態情報取得】ﾒｯｾｰｼﾞ送受信処理
                    mstrGrbStatus = vbNullString
                    lblnAns = pubblnGrbChk_Sel(CMstrlot_grbstatusVer, _
                                                ptypLotprestate.strLotID, _
                                                mstrGrbStatus)
                        
                    '@通信結果判定
                    If lblnAns = False Then
                    
                        '@結果：異常の場合
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                        
                        '@子画面起動か
                        If pblnfrmxxEN02L0Kbn = True Then
                            '@Form_Loadﾌﾗｸﾞに"False:起動失敗"をｾｯﾄ
                            pblnFormLoad = False
                        End If
                                        
                        Exit Sub
                    End If
                    
                    '@=======================
                    '@　画面表示処理
                    '@=======================
                    Call prvFrmxxEN02L0_Disp()
                    
                Else
                    '@結果：異常の場合
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                    
                    '@子画面起動か
                    If pblnfrmxxEN02L0Kbn = True Then
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
                        Call prvFrmxxEN02L0_CmbInit(True)
                        
                        '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                        mstrCarrier = txtCarrier.Text
                        
                    Else
                        '@結果：異常の場合
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                        
                        '@子画面起動か
                        If pblnfrmxxEN02L0Kbn = True Then
                            '@Form_Loadﾌﾗｸﾞに"False:起動失敗"をｾｯﾄ
                            pblnFormLoad = False
                        End If
                                        
                        Exit Sub
                    End If
                    
                    '@GRB属性情報取得
                    With ltypMasDefineReq
                        .strMsgVer = CMstrmas_definelistVer 'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        .strTableName = CMstrTableName      'ﾃｰﾌﾞﾙ名
                        .strColumnName = CMstrColumnName    'ｶﾗﾑ名
                    End With
                    
                    '@GRB属性情報取得MSG通信
                    lblnAnsScrap = pubblnMasDfineList_Sel(ltypMasDefineReq, ltypMasDefineAns)
                    
                    '@↓2019/12/13 (Fri) 15:14:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    ''@GRB属性が取得出来ない場合選択不可
                    'If lblGrbClass.Caption <> vbNullString Then
                    '  vsfCodeList.Enabled = False
                    'End If
            
                    '@EQ_TYPEがGRB設定以外はNG
                    If lblEqType.Text <> CPstrEqTypeGRBSet Then
                        vsfCodeList.Enabled = False
                    End If
                    '@↑2019/12/13 (Fri) 15:14:36 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    '@↓2020/03/25 (Wed) 14:16:35 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    '@GR状態確認結果下記以外選択不可
                    'If mstrGrbStatus <> CMstrGrbStatus0 And mstrGrbStatus <> CMstrGrbStatus1 Then
                    '    vsfCodeList.Enabled = False
                    '    
                    'End If
                    '@↑2020/03/25 (Wed) 14:16:35 Y.Yoneyama 「.Netへ反映未」 **************************************************                

                    '@GRB属性表示
                    Call prvcmbDataKind_Disp(ltypMasDefineAns)

                    '@=======================
                    '@　ｽｸﾛｰﾙﾎﾞﾀﾝ有効/無効をﾁｪｯｸCode(最終行の空白も)
                    '@=======================
                    Call prvScrollButtonCheckCode_Disp()
                    'Call pubVsfDisp(vsfCodeList, CmdUp1, CmdDown1)
                    
                    '@=======================
                    '@　ｽｸﾛｰﾙﾎﾞﾀﾝ有効/無効をﾁｪｯｸWF(最終行の空白も)
                    '@=======================
                    Call prvScrollButtonCheckWF_Disp()
                    'Call pubVsfDisp(vsfWFList, CmdUp2, CmdDown2)
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

    '関数名：txtCarrier_Validate2
    '機　能：再描画処理
    '引　数：Cancel：ｷｬﾝｾﾙ値(True:ﾌｫｰｶｽを留める、False:ﾌｫｰｶｽ移動)
    '戻り値：なし
    '作成日：2016/02/12 (Fri) 02:04:59 H.Hayashi
    '更新日：
    '備　考：
    Private Sub txtCarrier_Validate2(ByRef Cancel As Boolean)

        Dim lblnAnsFWInfo           As Boolean              'WF情報の取得結果格納
        Dim ltypWaferList           As Waferlist            'WFおよびﾁｯﾌﾟ情報格納用構造体
        Dim lblnAnsScrap            As Boolean              '不良ｺｰﾄﾞ取得結果格納
        Dim lblnAns                 As Boolean              '戻り値格納用
        Dim lstrRWEndFlag           As String               '特殊流動最終工程判断ﾌﾗｸﾞ
        Dim lstrRWFlag              As String               '特殊流動中ﾌﾗｸﾞ
        Dim lstrSelect              As String               '特殊流動名退避領域
        Dim ltypMasDefineReq        As MasDefineReq         'DEFINE情報（要求）
        Dim ltypMasDefineAns        As MasDefineAns         'DEFINE情報（応答）
        Dim lblnNextCtrl            As Boolean              'NSYS Focus設定フラグ

        Try
            
            '@子画面起動か
            If pblnfrmxxEN02L0Kbn = True Then
                '@子画面起動の場合、Form_Loadﾌﾗｸﾞに"True:起動正常"をｾｯﾄ
                pblnFormLoad = True
            End If
            
            '@ｷｬﾘｱIDがﾛｯｸされているか
            If txtCarrier.Locked = True Then
                Exit Sub
            End If

            If ActiveControl Is txtCarrier Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If
                
            '@ｷｬﾘｱIDがNULLか
            If Trim(txtCarrier.Text) = vbNullString Then
                '@単独起動か
                If pblnfrmxxEN02L0Kbn = False AndAlso lblnNextCtrl Then
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
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
                
                Cancel = True
                
                '@単独起動か
                If pblnfrmxxEN02L0Kbn = False AndAlso lblnNextCtrl Then
                    '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrier)
                End If
                
                Exit Sub
            End If
            
            '@******************
            '@　ﾛｯﾄ情報の取得
            '@******************
            
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
                Call prvFrmxxEN02L0_Disp()
                    
            Else
                '@結果：異常の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                    
                '@子画面起動か
                If pblnfrmxxEN02L0Kbn = True Then
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
                     Call prvFrmxxEN02L0_CmbInit(True)
                        
                    '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                     mstrCarrier = txtCarrier.Text
                        
                Else
                    '@結果：異常の場合
                        
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                     Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                        
                    '@子画面起動か
                    If pblnfrmxxEN02L0Kbn = True Then
                        '@Form_Loadﾌﾗｸﾞに"False:起動失敗"をｾｯﾄ
                        pblnFormLoad = False
                    End If
                                        
                    Exit Sub
                End If

                '@=======================
                '@　ｽｸﾛｰﾙﾎﾞﾀﾝ有効/無効をﾁｪｯｸCode(最終行の空白も)
                '@=======================
                Call prvScrollButtonCheckCode_Disp()
                    
                '@=======================
                '@　ｽｸﾛｰﾙﾎﾞﾀﾝ有効/無効をﾁｪｯｸWF(最終行の空白も)
                '@=======================
                Call prvScrollButtonCheckWF_Disp()
                              
                '@通信結果判定
                If lblnAnsScrap = False Then
                    '@結果：異常の場合

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                        
                    '@子画面起動か
                    If pblnfrmxxEN02L0Kbn = True Then
                        '@Form_Loadﾌﾗｸﾞに"False:起動失敗"をｾｯﾄ
                        pblnFormLoad = False
                    End If
                        
                    Exit Sub
                End If
                    
                '@DEFINE情報取得
                With ltypMasDefineReq
                    .strMsgVer = CMstrmas_definelistVer 'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                    .strTableName = CMstrTableName      'ﾃｰﾌﾞﾙ名
                    .strColumnName = CMstrColumnName    'ｶﾗﾑ名
                End With
                    
                '@MSG通信【DEFINE情報取得】
                lblnAnsScrap = pubblnMasDfineList_Sel(ltypMasDefineReq, ltypMasDefineAns)
                    
                '@=======================
                '@　ｽｸﾛｰﾙﾎﾞﾀﾝ有効/無効をﾁｪｯｸCode(最終行の空白も)
                '@=======================
                Call prvScrollButtonCheckCode_Disp()
                'Call pubVsfDisp(vsfCodeList, CmdUp1, CmdDown1)
                    
                '@=======================
                '@　ｽｸﾛｰﾙﾎﾞﾀﾝ有効/無効をﾁｪｯｸWF(最終行の空白も)
                '@=======================
                Call prvScrollButtonCheckWF_Disp()
                'Call pubVsfDisp(vsfWFList, CmdUp2, CmdDown2)
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

            With ptypLotprestate
                
                
                '@EQ_TYPE=5(移載工程)か
                If .strEqType = CPstrEqTypeSORTER Then
                
                    '@GRB属性一覧を無効にする
                    vsfCodeList.Enabled = False
            
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

    '関数名：cmdDown1_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(ｺｰﾄﾞｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/12 (Fri) 00:38:20 H.Hayashi
    '更新日：
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
    '作成日：2016/02/12 (Fri) 00:38:20 H.Hayashi
    '更新日：
    '備　考：
    Private Sub vsfWFList_AfterSelChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWFList.AfterSelChange

        Try            
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
    '作成日：2016/02/12 (Fri) 00:38:20 H.Hayashi
    '更新日：
    '備　考：
    Private Sub vsfWFList_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfWFList.MouseUp

        Try
            
            '@=======================
            '@　GRB属性ｺｰﾄﾞ等をWFｸﾞﾘｯﾄﾞへの記入処理
            '@=======================
            If vsfWFList.MouseRow >= vsfWFList.Rows.Fixed OrElse _
               (vsfWFList.MouseRow = CMlngvsfTitle AndAlso _
                vsfWFList.MouseCol = CMlngVsfWFListSlotNo) Then
                Call prvVsfWFList_Set()
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
    '作成日：2016/02/12 (Fri) 00:38:20 H.Hayashi
    '更新日：
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
    '作成日：2016/02/12 (Fri) 00:38:20 H.Hayashi
    '更新日：
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
    '作成日：2016/02/12 (Fri) 00:38:20 H.Hayashi
    '更新日：
    '備　考：
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
            
                '@【GRB属性設定】ﾒｯｾｰｼﾞ送受信処理
                lblnAnsKakutei = pubblnwfGrp_Set(CMstrwf__grbset_Ver, _
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

                        '@表示ﾒｯｾｰｼﾞ変換(" <TRM7KI>$$GRB属性設定をしました。キャリア[%1] ロット[%2]")
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007K, txtCarrier.Text, lblLotID.Text)
                    End If
                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)

            
                    '@子画面起動か
                    If pblnfrmxxEN02L0Kbn = True Then
                        '@子画面起動の場合
                    
                        '@引継構造体に情報をｾｯﾄ
                        With ptypWorkEndInfo
                            .strCarrierId = txtCarrier.Text         'ｷｬﾘｱID
                            .strLotID = lblLotID.Text            'ﾛｯﾄID
                            .strfrmxxKbn = CPstrKeyEN02L0           '機能ID
                            
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
                        
                        End With
                                      
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
    '作成日：2016/02/12 (Fri) 00:44:30 H.Hayashi
    '更新日：
    '備　考：
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
            
            vsfWFList.Redraw = False
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

            '@ｶﾚﾝﾄ行ｾｯﾄ
            vsfWFList.Row = CMlngvsfTitle

            vsfWFList.Redraw = True

           
            '@=======================
            '@　各種ﾎﾞﾀﾝの有効/無効制御処理
            '@=======================
            Call prvCmdButtonControl_Proc()

            '@=======================
            '@　再描画処理
            '@=======================
            Call txtCarrier_Validate2(False)
            
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

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/12 (Fri) 00:51:14 H.Hayashi
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
            
            '@子画面起動か
            If pblnfrmxxEN02L0Kbn = True Then
            
                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                Me.Close()

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
                    llngRet = publngEnd_Proc(CPstrKeyEN02L0, ltypCommonInfo)
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
    '作成日：2016/02/12 (Fri) 00:51:14 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvIndependentLoad_Init()

        Try
            
            '@ｷｬﾘｱIDの初期化
            With txtCarrier
                .BackColor = Color.White 'vbWhite        'ﾊﾞｯｸｶﾗｰ：白
                .GotBackColor = Color.White 'vbWhite     'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ：白
                .Locked = False             'ﾛｯｸ解除
                .TabStop = True             'ﾀﾌﾞｽﾄｯﾌﾟ:有効
            End With
            
            '@ﾌｫｰﾑに対してのｷｰｲﾍﾞﾝﾄを最優先に設定
            Me.KeyPreview = True
            
            With vsfWFList

                For lintCnt As Integer = 0 To .Rows.Count - 1
                    .Rows(lintCnt).Height = CMlngvsfRowHeight      '行の高さ
                Next
                .Row = .Rows.Count - 1                        '№01の一番下の行を初期選択状態にする
                
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
            Call prvFrmxxEN02L0_CmbInit(False)
            
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

    '関数名：prvFrmxxEN02L0_Init
    '機　能：画面情報初期化処理
    '引　数：lblnCarrierClear：(True：ｷｬﾘｱIDｸﾘｱ、False：ｷｬﾘｱID未編集)
    '戻り値：なし
    '作成日：2016/02/12 (Fri) 00:51:14 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvFrmxxEN02L0_Init(Optional ByVal lblnCarrierClear As Boolean = True)
        
        Dim lstrFormTitle       As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim ltypLotInsprst      As LotInsprst       '変更登録ﾃﾞｰﾀ格納構造体初期化用
        Dim ltypDirectScrap     As DirectScrap      '廃棄登録ﾃﾞｰﾀ格納構造体初期化用
        Dim cellRange As CellRange
        Dim headerStyle As CellStyle

        Try
            
            '@=======================
            '@　機能毎関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02L0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@基本情報ｸﾘｱ
            If lblnCarrierClear = True Then
                '@ｷｬﾘｱをｸﾘｱする場合
                txtCarrier.Text = vbNullString          'ｷｬﾘｱID
            End If
            lblLotID.Text = vbNullString             'ﾛｯﾄID
            lblFlowClass.Text = vbNullString         '流動区分
            lblGrbClass.Text = vbNullString          'GRB区分
            lblWFNo.Text = vbNullString              'WF枚数
            lblOpName.Text = vbNullString            '大工程ID
            lblStatus.Text = vbNullString            '状態
            lblStepName.Text = vbNullString          '小工程ID
            '@↓2019/12/13 (Fri) 15:17:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblEqType.Text = vbNullString            'EQ_TYPE
            lblTtlEqType.Visible = False
            lblEqType.Visible = False
            lblGrbClass.BackColor = lblOpName.BackColor
            '@↑2019/12/13 (Fri) 15:17:18 Y.Yoneyama 「.Netへ反映未」 **************************************************

            '@ｺｰﾄﾞｸﾞﾘｯﾄﾞの初期化
            With vsfCodeList
                cellRange = .GetCellRange(.Rows.Fixed - 1, .Cols.Fixed, .Rows.Fixed - 1, .Cols.Count - 1) '表題
                headerStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                               '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)  '背景色
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                 '文字位置
                headerStyle.Trimming  = StringTrimming.None                        'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle
                .Rows.Count = 1                                                    '行数：1
                .Rows(0).Height = CMlngvsfRowHeight                                '行高：570
                .FocusRect = FocusRectEnum.None                                    'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠：なし
            End With
            
            '@=======================
            '@　WFｸﾞﾘｯﾄﾞのｸﾘｱ処理(固定行および列以外をｸﾘｱ)
            '@=======================
            Call vsfWFList.Clear(ClearFlags.Content Or ClearFlags.Style)

            '@WFｸﾞﾘｯﾄﾞの初期化
            With vsfWFList
                '列幅設定
                .Cols(CMlngVsfWFListSlotNo).Width = 29
                .Cols(CMlngVsfWFListWFID).Width = 145
                .Cols(CMlngVsfWFListClassID).Width = 105
                .Cols(CMlngVsfWFListClass).Width = 64
                .Cols(CMlngVsfWFListChange).Width = 66
                .Cols(CMlngVsfWFListGrbClass).Width = 96
                '列文字表示位置設定
                .Cols(CMlngVsfWFListSlotNo).TextAlign = TextAlignEnum.CenterCenter
                .Cols(CMlngVsfWFListWFID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngVsfWFListClassID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngVsfWFListClass).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngVsfWFListChange).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngVsfWFListGrbClass).TextAlign = TextAlignEnum.LeftCenter
                '列表示設定
                .Cols(CMlngVsfWFListClass).Visible = False
                .Cols(CMlngVsfWFListChange).Visible = False
                .Cols(CMlngVsfWFListGrbClass).Visible = False
                '列ﾀｲﾄﾙ
                .SetData(.Rows.Fixed - 1, CMlngVsfWFListWFID, "WFID")
                .SetData(.Rows.Fixed - 1, CMlngVsfWFListClassID, "GRB")

                cellRange = .GetCellRange(.Rows.Fixed - 1, .Cols.Fixed - 1, .Rows.Fixed - 1, .Cols.Count - 1) '表題
                headerStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                  '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)     '背景色
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                    '文字位置
                headerStyle.Trimming  = StringTrimming.None                           'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle
                .FocusRect = FocusRectEnum.None                                       'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠：なし
                'No列データ設定
                For lintCnt As Integer = 1 To .Rows.Count - 1
                    .SetData(lintCnt, CMlngVsfWFListSlotNo, (CMlngVsfWFListRows - lintCnt).ToString("00"))
                Next
                .Row = CMlngvsfTitle
            End With
            
            '@下記ﾎﾞﾀﾝ押下時は、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙのValidateｲﾍﾞﾝﾄを実行しないように設定
            cmdClose.CausesValidation = False       '閉じるﾎﾞﾀﾝ
            cmdClear.CausesValidation = False       '取消ﾎﾞﾀﾝ
            
            '@ﾓｼﾞｭｰﾙ変数を初期化
            mstrCarrier = vbNullString              'ｷｬﾘｱID退避用
            mstrWPTYPE = vbNullString               '装置ﾀｲﾌﾟ格納用
            mstrGrbStatus = vbNullString            'GRB状態
              
            '@各構造体初期化
            mtypLotInsprst = ltypLotInsprst         '変更登録ﾃﾞｰﾀ格納構造体
            mtypDirectScrap = ltypDirectScrap       '廃棄登録ﾃﾞｰﾀ格納構造体

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN02L0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxEN02L0_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/12 (Fri) 01:05:27 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvFrmxxEN02L0_Disp()

        Try

            With ptypLotprestate
            
                lblLotID.Text = .strLotID                'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass        '流動区分
                lblGrbClass.Text = .strGrbClass          'GRB区分
                lblOpName.Text = .strOpID                '大工程ID
                lblStatus.Text = .strNowST               '状態
                lblStepName.Text = .strStepID            '小工程名
                '@↓2019/12/13 (Fri) 15:18:46 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblEqType.Text = .strEqType              'GRB区分

                '@GRB背景色
                lblGrbClass.BackColor = pubGRBBackColor(.strGRBClass, lblOpName.BackColor)
                '@↑2019/12/13 (Fri) 15:18:46 Y.Yoneyama 「.Netへ反映未」 **************************************************

                '@子画面起動か
                If pblnfrmxxEN02L0Kbn = True Then
                
                    '@子画面起動の場合は、WF枚数はそのまま表示(CFﾌﾗｸﾞの判定は親ﾌｫｰﾑで行う為)
                    lblWFNo.Text = Format$(CInt(.strWfNum), CPstrCFKnmaFormat)                         'WF枚数
                Else
                    '@単独起動の場合
                
                    '@★CF_FLAGにより処理分岐(WF枚数とﾁｯﾌﾟ枚数の表示を切替) ★
                    Select Case .strCfFlag
                    
                        '@〓 1:CFﾛｯﾄ 〓
                        Case CPstrCF
                        
                            '@ODFﾌﾗｸﾞ(LP_FLAG)が"1:ODF"か
                            If .strLpFlag = CPstrLP Then
                                '@ODFの場合
                                lblWFNo.Text = .strWfNum                                         'WF枚数
                            Else
                                '@ODF以外の場合
                                lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)      'ﾁｯﾌﾟ枚数
                            End If
                            
                        '@〓 CFﾛｯﾄ以外 〓
                        Case Else
                        
                            '@TPALﾛｯﾄか
                            If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                                '@TPALﾛｯﾄの場合
                            
                                lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)      'ﾁｯﾌﾟ枚数
                            Else
                                '@CF,TPALﾛｯﾄ以外
                                lblWFNo.Text = .strWfNum                                         'WF枚数
                            End If
                    End Select
                End If
                
                '@WP_TYPE取得
                mstrWPTYPE = .strWpTypeFlag
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN02L0_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxEN02L0_CmbInit
    '機　能：各ﾎﾞﾀﾝの制御処理
    '引　数：lblnEnable：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2016/02/12 (Fri) 01:07:55 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvFrmxxEN02L0_CmbInit(Optional ByVal lblnEnable As Boolean = False)

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
             cmdClipCopy.Enabled = lblnEnable
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN02L0_CmbInit"
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
    '作成日：2016/02/12 (Fri) 01:17:53 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvVsfWFList_Disp(ByRef ltypWaferList As Waferlist)
        
        Dim llngCnt         As Integer  'ｶｳﾝﾀ
        Dim llngWriteRow    As Integer  'ｸﾞﾘｯﾄﾞに書き込む行

        Try
            
            vsfWFList.Enabled = True
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
            
            '@↓2019/12/13 (Fri) 15:22:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@EQ_TYPE取得
            lblEqType.Text = ltypWaferList.strEqType
            '@↑2019/12/13 (Fri) 15:22:13 Y.Yoneyama 「.Netへ反映未」 **************************************************

            Dim newStyle_BC_GridDarkGray As CellStyle = vsfWFList.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
            newStyle_BC_GridDarkGray.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
            Dim newStyle_BC_White As CellStyle = vsfWFList.Styles.Add("CustomStyle_BackColor_vbWhite")
            newStyle_BC_White.BackColor = Color.White

            Dim newStyleGRB As CellStyle
            Dim cellRange As CellRange 'NSYS セル範囲

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
                        vsfWFList.SetData(llngWriteRow, CMlngVsfWFListClassID, .strGrbClass)  'ｸﾗｽID(GRB)
                        vsfWFList.SetData(llngWriteRow, CMlngVsfWFListClass, .strClass)       'ｸﾗｽ
                        
                        '@良品WF以外か
                        If vsfWFList.GetData(llngWriteRow, CMlngVsfWFListClass) <> CPstrClass1 Then
                            '@変更不可にする
                            vsfWFList.SetData(llngWriteRow, CMlngVsfWFListChange, CMlngChangeNG)              '変更可否ﾌﾗｸﾞに"0:変更不可"をｾｯﾄ
                            cellRange = vsfWFList.GetCellRange(llngWriteRow, CMlngVsfWFListClassID)
                            cellRange.Style = newStyle_BC_GridDarkGray    'ｸﾞﾚｰに変更
                        Else
                            '@変更可にする
                            vsfWFList.SetData(llngWriteRow, CMlngVsfWFListChange, CMlngChangeOK)              '変更可否ﾌﾗｸﾞに"1:変更可"をｾｯﾄ
                            cellRange = vsfWFList.GetCellRange(llngWriteRow, CMlngVsfWFListClassID)
                            cellRange.Style = newStyle_BC_White              '白色に変更

                            '@↓2019/12/27 (Fri) 10:15:21 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            '@GRB背景色
                            newStyleGRB = vsfWFList.Styles.Add("GRBColor" & llngWriteRow.ToString)
                            newStyleGRB.BackColor = pubGRBBackColor(vsfWFList.GetData(llngWriteRow, CMlngVsfWFListClassID), Color.White)
                            cellRange.Style = newStyleGRB
                            '@↑2019/12/27 (Fri) 10:15:21 Y.Yoneyama 「.Netへ反映未」 **************************************************

                            '@↓2019/12/13 (Fri) 15:07:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            '@GRB設定に関係なく設定を可能にする
                            '@確定ﾁｪｯｸで整合性をとる為ｺﾒﾝﾄｱｳﾄ
                            'If lblGrbClass.Text <> vbNullString Then
                            '    vsfWFList.SetData(llngWriteRow, CMlngVsfWFListChange, CMlngChangeNG)          '変更可否ﾌﾗｸﾞに"0:変更不可"をｾｯﾄ
                            ' 
                            'End If
                            '
                            'If mstrGrbStatus <> CMstrGrbStatus0 And mstrGrbStatus <> CMstrGrbStatus1 Then
                            '    vsfWFList.SetData(llngWriteRow, CMlngVsfWFListChange, CMlngChangeNG)          '変更可否ﾌﾗｸﾞに"0:変更不可"をｾｯﾄ
                            'End If
                            '@↑2019/12/13 (Fri) 15:07:17 Y.Yoneyama 「.Netへ反映未」 **************************************************

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
                    cellRange  = vsfWFList.GetCellRange(llngCnt, CMlngVsfWFListWFID, llngCnt, CMlngVsfWFListClassID)
                    cellRange.Style = newStyle_BC_GridDarkGray
                End If
                llngCnt = llngCnt + 1
            Loop
            
            llngCnt = 1
            
            With vsfWFList
                '@行の高さを設定する
                For lintCnt As Integer = 0 To .Rows.Count - 1
                    .Rows(lintCnt).Height = CMlngvsfRowHeight    '行の高さ
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
                Call pubVsfAfterSort(vsfWFList, CMlngVsfWFListSlotNo, cmdUP2, cmdDown2, False, False)
                
                '@不具合No3472　単独起動時のSLOTNo01の色表示を白にする
                '@擬似的にｶﾚﾝﾄ行をﾀｲﾄﾙ行へｾｯﾄしﾌｫｰｶｽを当たっていない様にする
                .Row = CMlngvsfTitle
            End With

            vsfWFList.Redraw = True
            
            '@↓2019/12/26 (Thu) 13:30:06 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@EQ_TYPEがGRB設定以外はNG
            If lblEqType.Text <> CPstrEqTypeGRBSet Then
    
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM7VI>$$この工程では[%1]はできません。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007V, Me.Text)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
    
            End If
            '@↑2019/12/26 (Thu) 13:30:06 Y.Yoneyama 「.Netへ反映未」 **************************************************

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

        Finally
            vsfWFList.Redraw = True
        End Try
    End Sub

    '関数名：prvVsfWFList_Set
    '機　能：GRB属性ｺｰﾄﾞ等をWFｸﾞﾘｯﾄﾞへの記入処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/12 (Fri) 01:17:53 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvVsfWFList_Set()

        Dim llngCnt             As Integer  'ｶｳﾝﾄ
        Dim llngRowTop          As Integer  '選択最上段行
        Dim llngRowBottom       As Integer  '選択最下段行

        Try
            
            '@以下の条件の場合、処理抜け
            '@　①ｺｰﾄﾞが選択されている
            '@　②WFが選択されている
            If vsfCodeList.Row <= 0 Or vsfWFList.Row <= 0 Then
                Exit Sub
            End If
            
            '@WFｸﾞﾘｯﾄﾞ
            With vsfWFList
            
                If .Rows.Selected.Count < 1 Then
                    '選択行なし
                    Exit Sub
                End If
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

                Dim newStyle_BC_White As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                newStyle_BC_White.BackColor = Color.White
                Dim GRBColor As CellStyle
                Dim cellRange As CellRange
                
                For llngCnt = llngRowBottom To llngRowTop Step -1
                    
                    '@選択された行が表示されているか
                    If .TopRow <= llngCnt AndAlso _
                        .BottomRow >= llngCnt Then
                        
                        '@変更可否ﾌﾗｸﾞが"1"か(良品のもののみ変更可能)
                        If .GetData(llngCnt, CMlngVsfWFListChange) = CMlngChangeOK Then
                            
                            '@既に同じｺｰﾄﾞが記述されているか
                            If .GetData(llngCnt, CMlngVsfWFListClassID) = _
                                vsfCodeList.GetData(vsfCodeList.Row, CMlngVsfCodeListCode) Then
                                
                                '@既に同じｺｰﾄﾞが記述されていたら取り消す
                                .SetData(llngCnt, CMlngVsfWFListClassID, vbNullString)    'ｺｰﾄﾞ
                                .SetData(llngCnt, CMlngVsfWFListClass, CPstrClass1)       'ｸﾗｽ
                                '@↓2016/02/12 (Fri) 13:26:31 H.Hayashi **************************************************
                                cellRange = .GetCellRange(llngCnt, CMlngVsfWFListClassID)
                                cellRange.Style = newStyle_BC_White    '白色に変更
                                '@↑2016/02/12 (Fri) 13:26:31 H.Hayashi **************************************************

                            Else
                                '@ｺｰﾄﾞをWFへ記入
                                .SetData(llngCnt, CMlngVsfWFListClassID, vsfCodeList.GetData(vsfCodeList.Row, CMlngVsfCodeListCode))
                                '@ｸﾗｽを記入(mstrClassは一覧取得時に変更)
                                .SetData(llngCnt, CMlngVsfWFListClass, mstrClass)

                                '@↓2019/12/27 (Fri) 10:18:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                '@GRB背景色
                                GRBColor = .Styles.Add("GRBColor" & llngCnt.ToString)
                                GRBColor.BackColor = pubGRBBackColor(.GetData(llngCnt, CMlngVsfWFListClassID), Color.White)
                                cellRange = .GetCellRange(llngCnt, CMlngVsfWFListClassID)
                                cellRange.Style = GRBColor
                                '@↑2019/12/27 (Fri) 10:18:02 Y.Yoneyama 「.Netへ反映未」 **************************************************

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

    '関数名：prvScrollButtonCheckCode_Disp
    '機　能：ｺｰﾄﾞｸﾞﾘｯﾄﾞのｽｸﾛｰﾙﾎﾞﾀﾝ制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/12 (Fri) 01:20:53 H.Hayashi
    '更新日：
    '備　考：
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
    '作成日：2016/02/12 (Fri) 01:20:53 H.Hayashi
    '更新日：
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
    '作成日：2016/02/12 (Fri) 01:20:53 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvCmdButtonControl_Proc()
        
        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
        Dim lblnResurut     As Boolean      '確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(True:有効、False:無効)
        Dim lblnClear       As Boolean      '取消ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(True:有効、False:無効)
        
        Try
            
            '@ﾌﾗｸﾞ初期設定
            lblnResurut = False
            lblnClear = False
            
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
                    Else
                        
                        lblnResurut = False     '確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
                        lblnClear = False       '取消ﾎﾞﾀﾝ制御ﾌﾗｸﾞ：False
                    End If
                End If
            End With
            
            
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
                    Exit Do
                End If
                llngCnt = llngCnt + 1
            Loop


            '@確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞが"True：有効にする"か
            If lblnResurut = True Then
                cmdConfirm.Enabled = True       '有効
            Else
                cmdConfirm.Enabled = False      '無効
            End If
            
            '@取消ﾎﾞﾀﾝ制御ﾌﾗｸﾞが"True：有効にする"か
            If lblnClear = True Then
                cmdClear.Enabled = True         '有効
            Else
                cmdClear.Enabled = False        '無効
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
    '作成日：2016/02/12 (Fri) 01:20:53 H.Hayashi
    '更新日：
    '備　考：
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

    '関数名：prvcmbDataKind_Disp
    '機　能：GRB属性ﾃﾞｰﾀｺﾝﾎﾞ設定
    '引　数：ltypMasDefineAns：ﾃﾞｰﾀ構造体
    '戻り値：なし
    '作成日：2016/02/12 (Fri) 01:32:53 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvcmbDataKind_Disp(ByRef ltypMasDefineAns As MasDefineAns)

        Dim llngCnt     As Integer  'ｶｳﾝﾄ

        Try
            
            vsfCodeList.Redraw = False
            '@ﾃﾞｰﾀｾｯﾄ
                
            vsfCodeList.Rows.Count = 1
                
            With ltypMasDefineAns

                llngCnt = 0
                Do While .lngMasDefineListCnt > llngCnt

                    vsfCodeList.Rows.Count = vsfCodeList.Rows.Count + 1
                    vsfCodeList.SetData(vsfCodeList.Rows.Count - 1, CMlngVsfCodeListCode, _
                        .typMasDefineList(llngCnt).strName)       'ｺｰﾄﾞID
                    vsfCodeList.SetData(vsfCodeList.Rows.Count - 1, CMlngVsfCodeListName, _
                        .typMasDefineList(llngCnt).strId)         'ｺｰﾄﾞ名

        '@↓2016/02/12 (Fri) 12:26:45 H.Hayashi **************************************************

                    '@GRB区分有りか
                    If vsfCodeList.GetData(vsfCodeList.Rows.Count - 1, CMlngVsfCodeListCode) <> vbNullString Then
                            
                        '@GRB区分より背景色を設定
                        Select Case vsfCodeList.GetData(vsfCodeList.Rows.Count - 1, CMlngVsfCodeListCode)

                            '@G属性指定
                            Case CPstrGRB_G
                                    
                                '@緑系色(G区分ﾊﾞｯｸｶﾗｰ)
                                Dim newStyle As CellStyle = vsfCodeList.Styles.Add("CustomStyle_BackColor_CMlngG_BackColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngG_BackColor)
                                Dim cellRange As CellRange = vsfCodeList.GetCellRange(vsfCodeList.Rows.Count - 1, CMlngVsfCodeListCode)
                                cellRange.Style = newStyle

                            '@R属性指定
                            Case CPstrGRB_R
                                    
                                '@赤系色(R区分ﾊﾞｯｸｶﾗｰ)
                                Dim newStyle As CellStyle = vsfCodeList.Styles.Add("CustomStyle_BackColor_CMlngR_BackColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngR_BackColor)
                                Dim cellRange As CellRange = vsfCodeList.GetCellRange(vsfCodeList.Rows.Count - 1, CMlngVsfCodeListCode)
                                cellRange.Style = newStyle
                            
                            '@B属性指定
                            Case CPstrGRB_B
                                    
                                '@青系色(B区分ﾊﾞｯｸｶﾗｰ)
                                Dim newStyle As CellStyle = vsfCodeList.Styles.Add("CustomStyle_BackColor_CMlngB_BackColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngB_BackColor)
                                Dim cellRange As CellRange = vsfCodeList.GetCellRange(vsfCodeList.Rows.Count - 1, CMlngVsfCodeListCode)
                                cellRange.Style = newStyle
                        
                            '@GR属性指定
                            Case CPstrGRB_GR
                                    
                                '@緑赤系色(GR区分ﾊﾞｯｸｶﾗｰ)
                                Dim newStyle As CellStyle = vsfCodeList.Styles.Add("CustomStyle_BackColor_CMlngGR_BackColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGR_BackColor)
                                Dim cellRange As CellRange = vsfCodeList.GetCellRange(vsfCodeList.Rows.Count - 1, CMlngVsfCodeListCode)
                                cellRange.Style = newStyle
                                
                            '@GB属性指定
                            Case CPstrGRB_GB
                                    
                                '@緑青系色(GB区分ﾊﾞｯｸｶﾗｰ)
                                Dim newStyle As CellStyle = vsfCodeList.Styles.Add("CustomStyle_BackColor_CMlngGB_BackColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGB_BackColor)
                                Dim cellRange As CellRange = vsfCodeList.GetCellRange(vsfCodeList.Rows.Count - 1, CMlngVsfCodeListCode)
                                cellRange.Style = newStyle
                                
                            '@RB属性指定
                            Case CPstrGRB_RB
                                    
                                '@赤青系色(RB区分ﾊﾞｯｸｶﾗｰ)
                                Dim newStyle As CellStyle = vsfCodeList.Styles.Add("CustomStyle_BackColor_CMlngRB_BackColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngRB_BackColor)
                                Dim cellRange As CellRange = vsfCodeList.GetCellRange(vsfCodeList.Rows.Count - 1, CMlngVsfCodeListCode)
                                cellRange.Style = newStyle
                            '@上記以外
                            Case Else
                    
                                '@色指定なし
                        End Select
                            
                    End If
        '@↑2016/02/12 (Fri) 12:26:45 H.Hayashi **************************************************

                    llngCnt = llngCnt + 1

                Loop
                     
            End With

            '@行の高さを設定する
            For lintCnt As Integer = 0 To vsfCodeList.Rows.Count - 1
                vsfCodeList.Rows(lintCnt).Height = CMlngvsfRowHeight
            Next

            vsfCodeList.Row = CMlngvsfTitle
            vsfCodeList.Redraw = True
             
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbDataKind_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClipCopy_Click
    '機　能：クリップボードコピー
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/12 (Fri) 01:32:53 H.Hayashi
    '更新日：
    '備　考：
    Private Sub cmdClipCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClipCopy.Click

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
            Clipboard.Clear()
            
            '@一覧をｺﾋﾟｰする
             With vsfWFList

                '@行
                For llngRowCnt = 0 To .Rows.Count - 1
                    '@列
                    For llngColCnt = 0 To .Cols.Count - 1
                        '@列が非表示でない場合
                        If .Cols(llngColCnt).Visible Then
                        
                            '@文字列編集変数に値をｾｯﾄ
                            lstrWk = Replace(.GetData(llngRowCnt, llngColCnt), vbCrLf, ",")
                            
                            '@先頭の文字列が「-」「+」の場合は罫線文字に置き換える
                            If Mid$(lstrWk, 1, 1) = CPstrMinus Then
                                Mid$(lstrWk, 1, 1) = CPstrMinusWide
                            End If
                            If Mid$(lstrWk, 1, 1) = CPstrPlus Then
                                Mid$(lstrWk, 1, 1) = CPstrPlusWide
                            End If
                            
                            '@最終列の場合Tabいらない
                            If llngColCnt = CMlngVsfWFListGrbClass Then
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
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClipCopy_Click"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：prvblnDataSet_Proc
    '機　能：変更登録情報格納処理(変更になったWFのﾃﾞｰﾀのみ)
    '引　数：lstrEventID    ：呼び元ｲﾍﾞﾝﾄ(確定or廃棄)
    '戻り値：なし
    '作成日：2016/02/12 (Fri) 01:45:05 H.Hayashi
    '更新日：
    '備　考：
    Private Function prvblnDataSet_Proc(ByVal lstrEventID As String) As Boolean
        
        Dim llngCnt                     As Integer      'ｶｳﾝﾀ
        Dim llngChangeWFCnt             As Integer      '変更するWFの数

        Try
            
            '@戻り値の初期化
            prvblnDataSet_Proc = False

            '@ｶｳﾝﾀ初期化
            llngCnt = 1
            llngChangeWFCnt = 1

            Do While vsfWFList.Rows.Count > llngCnt
                
                '@変更可否ﾌﾗｸﾞが｢1:変更可｣で、かつｸﾗｽが「1:良品」以外のﾚｺｰﾄﾞを格納
                If vsfWFList.GetData(llngCnt, CMlngVsfWFListChange) = CMlngChangeOK And _
                    vsfWFList.GetData(llngCnt, CMlngVsfWFListClass) <> CPstrClass1 Then
                    
                    '@呼び元ｲﾍﾞﾝﾄが"確定ﾎﾞﾀﾝ押下"か
                    If lstrEventID = CMstrCmdConfirmClick Then
                        '@「確定ﾎﾞﾀﾝ押下」の場合
                    
                        '@構造体の領域確保
                        If llngChangeWFCnt = 1 Then
                            If IsNothing(mtypLotInsprst.typWfList) Then
                                mtypLotInsprst.typWfList = New List(Of LotInsprstWF)
                            Else
                                mtypLotInsprst.typWfList.Clear()
                            End If
                        End If
                        Dim tmpLotInsprstWF As LotInsprstWF = New LotInsprstWF()
                        With tmpLotInsprstWF
                            .strWfId = vsfWFList.GetData(llngCnt, CMlngVsfWFListWFID)              'WFID
                            .strSlotPosition = vsfWFList.GetData(llngCnt, CMlngVsfWFListSlotNo)    'ｽﾛｯﾄ№
                            .strGrbClass = vsfWFList.GetData(llngCnt, CMlngVsfWFListGrbClass)      'GRB区分
                            .strClass = vsfWFList.GetData(llngCnt, CMlngVsfWFListClass)            'ｸﾗｽ
                            .strClassID = vsfWFList.GetData(llngCnt, CMlngVsfWFListClassID)        'ｸﾗｽID

                        End With
                        mtypLotInsprst.typWfList.Add(tmpLotInsprstWF)

                    Else
                        '@「廃棄ﾎﾞﾀﾝ押下」の場合
                        
                        '@構造体の領域確保
                        If llngChangeWFCnt = 1 Then
                            If IsNothing(mtypDirectScrap.typScrapWFList) Then
                                mtypDirectScrap.typScrapWFList = New List(Of ScrapWF)
                            Else
                                mtypDirectScrap.typScrapWFList.Clear()
                            End If
                        End If
                        Dim tmpScrapWF As ScrapWF = New ScrapWF()
                        With tmpScrapWF
                            .strWfId = vsfWFList.GetData(llngCnt, CMlngVsfWFListWFID)              'WFID
                            .strSlotPosition = vsfWFList.GetData(llngCnt, CMlngVsfWFListSlotNo)    'ｽﾛｯﾄ№
                            .strGrbClass = vsfWFList.GetData(llngCnt, CMlngVsfWFListGrbClass)      'GRB区分
                            .strClass = vsfWFList.GetData(llngCnt, CMlngVsfWFListClass)            'ｸﾗｽ
                            .strClassID = vsfWFList.GetData(llngCnt, CMlngVsfWFListClassID)        'ｸﾗｽID

                        End With
                        mtypDirectScrap.typScrapWFList.Add(tmpScrapWF)
                    End If
                    
                    '@変更/廃棄WFｶｳﾝﾄを+1する
                    llngChangeWFCnt = llngChangeWFCnt + 1
                    
                ElseIf vsfWFList.GetData(llngCnt, CMlngVsfWFListChange) = CMlngChangeOK And _
                            vsfWFList.GetData(llngCnt, CMlngVsfWFListClass) = CPstrClass1 Then
                    
                    If vsfWFList.GetData(llngCnt, CMlngVsfWFListClassID) = vbNullString Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0138)
                        '@"<TRM138W>$$GRB設定が未設定なウェハが有ります。$設定を見直して下さい。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Exit Function
                    
                    End If
                    
                End If
                
                '@WFｸﾞﾘｯﾄﾞのﾙｰﾌﾟｶｳﾝﾀを+1する
                llngCnt = llngCnt + 1
            Loop
            
            '@登録するﾃﾞｰﾀがない場合は中止
            If llngChangeWFCnt = 1 Then
            
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
                    .lngListCnt = llngChangeWFCnt - 1                       '変更情報のあるWFの数
                    .strLotID = lblLotID.Text                            'ﾛｯﾄID
                    .strLotLastUpdate = ptypLotprestate.strLotLastUpdate    '最終更新日時
                    .strClassDivision = CPstrCD17                           'WF処置登録(処理区分：17)
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
    '機　能：GRB属性設定権限ﾁｪｯｸ処理
    '引　数：lstrEventID    ：呼び元ｲﾍﾞﾝﾄ(確定)
    '戻り値：True:成功、False:失敗
    '作成日：2016/02/12 (Fri) 01:47:20 H.Hayashi
    '更新日：
    '備　考：
    Private Function prvblnRegistAuthority_Chk(ByVal lstrEventID As String) As Boolean

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


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfCodeList.BeforeDoubleClick, vsfWFList.BeforeDoubleClick

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
                If .MouseRow = 0 AndAlso .MouseCol = CMlngvsfWFListSlotNo AndAlso _
                    e.Button = MouseButtons.Left Then
                    '@全選択
                    .Select(.Rows.Fixed, .Cols.Fixed, .Rows.Count - 1, .Cols.Count - 1 , False)
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
    '機　能 ： 項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Enter, _
            cmdClipCopy.Enter, cmdClear.Enter, cmdConfirm.Enter, cmdUp1.Enter,  cmdDown1.Enter,  _
            cmdUp2.Enter, cmdDown2.Enter, vsfCodeList.Enter, vsfWFList.Enter, txtCarrier.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '自動Validate = OFF
            Case cmdClose.Name, cmdClear.Name
                Me.AutoValidate = AutoValidate.Disable

            '自動Validate = ON
            Case Else
                Me.AutoValidate = AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
