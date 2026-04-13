'ﾌｧｲﾙ名：xxEN0280.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：移載(ソーター)　メインフォーム
'作成日：2004/05/28 (Fri) 16:13:29 Y.Yamagishi
'更新日：2009/08/12 (Wed) 17:46:00 N.Kojima
'備　考：
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0280
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0280    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0280
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0280
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0280)
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
    '====================================Private============================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2020/03/06 (Fri) 11:44:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion                     As String = "02.01"
    Private Const CMstrLocalVersion                     As String = "03.00"
    '@↑2020/03/06 (Fri) 11:44:17 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2019/12/31 (Tue) 13:11:55 Y.Yoneyama 「.Netへ反映未」 **************************************************
    '@Private Const CMstrlot_moveinfoVer                  As String = "01.00"                         'ﾛｯﾄ移載情報取得
    Private Const CMstrlot_moveinfoVer                  As String = "02.00"                         'ﾛｯﾄ移載情報取得
    '@↑2019/12/31 (Tue) 13:11:55 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_move____Ver                  As String = "02.00"                         'ﾛｯﾄ移載

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN0280                  'ﾛｰｶﾙﾒﾆｭｰKey

    Private Const CMlngMaxByte                          As Integer = 6                              'ｷｬﾘｱIDMAX桁数
    Private Const CMlngLeftLength                       As Integer = 7                              'ﾛｯﾄID左7桁比較文字数
    Private Const CMlngRightLength                      As Integer = 2                              'ﾛｯﾄID右2桁比較文字数

    '@ﾀﾌﾞｲﾝﾃﾞｯｸｽ
    Private Const CMlngtabLot0                          As Integer = 0                              '移載先ｷｬﾘｱ1
    Private Const CMlngtabLot1                          As Integer = 1                              '移載先ｷｬﾘｱ2

    '@vsfSlotMapの定数宣言(ｶﾗﾑ)
    Private Const CMlngColSlot                          As Integer = 0                              'ｽﾛｯﾄ№
    Private Const CMlngColWFID                          As Integer = 1                              'WFID
    '@↓2019/12/31 (Tue) 14:46:08 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngColGRB                           As Integer = 2                              'GRB
    Private Const CMlngColToCarrySlotPosition           As Integer = 3                              '移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ(非表示)
    Private Const CMlngColDivideCombineLotID            As Integer = 4                              '分割/統合ﾛｯﾄID(非表示　組立在庫分割時に使用)
    'Private Const CMlngColToCarrySlotPosition           As Integer = 2                              '移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ(非表示)
    'Private Const CMlngColDivideCombineLotID            As Integer = 3                              '分割/統合ﾛｯﾄID(非表示　組立在庫分割時に使用)
    '@↑2019/12/31 (Tue) 14:46:08 Y.Yoneyama 「.Netへ反映未」 **************************************************


    '@vsfSlotMapの定数宣言(表示幅)
    Private Const CMlngColSlotWidth                     As Integer = 24                             'ｽﾛｯﾄWidth
    Private Const CMlngColWFIDWidth                     As Integer = 110                            'WFIDWidth
    Private Const CMlngColToCarrySlotPositionWidth      As Integer = 0                              '移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ(非表示)Width
    Private Const CMlngColDivideCombineLotIDWidth       As Integer = 0                              '分割/統合ﾛｯﾄID(非表示　組立在庫分割時に使用)Width
    '@↓2019/12/31 (Tue) 14:48:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngColGRBWidth                      As Integer = 30                             'GRB
    '@↑2019/12/31 (Tue) 14:48:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngSlotMapRowS                      As Integer = 26                             '行数
    '@↓2019/12/31 (Tue) 14:52:31 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMlngSlotMapCols                      As Integer = 4                              '列数
    Private Const CMlngSlotMapCols                      As Integer = 5                              '列数
    '@↑2019/12/31 (Tue) 14:52:31 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngSlotMapHeight                    As Integer = 20                             '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfSlotMapColWFID                As Integer = 0                              'WFID
    Private Const CMlngRowTop                           As Integer = 25                             '最上段行
    Private Const CMlngRowBottom                        As Integer = 1                              '最下段行

    '@vsfSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMlngSlotMapRowTitle                  As Integer = 0                              'ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ
    Private Const CMstrSlotMapColTSlot                  As String = vbNullString                    'ｽﾛｯﾄNO
    Private Const CMstrSlotMapColTWFID                  As String = "WFID"                          'WFID
    '@↓2019/12/31 (Tue) 14:50:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrSlotMapColTGRB                   As String = "GRB"                           'GRB
    '@↑2019/12/31 (Tue) 14:50:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngSlotHMaCellFontSize              As Integer = 12                             'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ

    '@ﾛｯﾄｲﾍﾞﾝﾄID
    Private Const CMlngLotEvent0                        As Integer = 0                              'ﾛｯﾄｲﾍﾞﾝﾄID(投入前)
    Private Const CMlngLotEvent6                        As Integer = 6                              'ﾛｯﾄｲﾍﾞﾝﾄID(作業終了)
    Private Const CMlngLotEvent99                       As Integer = 99                             'ﾛｯﾄｲﾍﾞﾝﾄID(ﾛｯﾄ終了)
    Private Const CMlngLotEventIDD                      As Integer = 10                             'ﾛｯﾄｲﾍﾞﾝﾄID(分割)
    Private Const CMlngLotEventIDC                      As Integer = 11                             'ﾛｯﾄｲﾍﾞﾝﾄID(統合)
    Private Const CMlngLotEventID                       As Integer = 12                             'ﾛｯﾄｲﾍﾞﾝﾄID(不良/保留/払出)

    '@移載ﾌﾗｸﾞ
    Private Const CMstrWFCarryFlag1                     As String = "1"                             'WF移載ﾌﾗｸﾞ(1:必要)
    Private Const CMstrWFCarryFlag0                     As String = "0"                             'WF移載ﾌﾗｸﾞ(0:不要)
    Private Const CMstrEQFlag                           As String = "0"                             '装置ﾌﾗｸﾞ(ｸﾗｲｱﾝﾄからは"0"固定)

    '@ｽﾃｰﾀｽ
    Private Const CMstrDivide                           As String = "分割"                          '分割
    Private Const CMstrCombine                          As String = "統合"                          '統合
    Private Const CMstrScrap                            As String = "不良/払出/保留"                '不良/払出/保留

    '@ﾌﾚｰﾑ見出し用
    Private Const CMstrFromMove                         As String = "移載元"
    Private Const CMstrToMove                           As String = "移載先"

    Private Const CMstrDivideCombineStatusD1            As String = "D1"                            '分割
    Private Const CMstrDivideCombineStatusC1            As String = "C1"                            '統合

    '@色定数
    Private Const CMlngDivideLot                        As Integer = &HE0E0E0                          '分割ﾛｯﾄ

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                         As String = "frmxxEN00Y1"                   '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"                     'ﾌｫｰﾑ起動時処理
    Private Const CMstrCmdRegistClick                   As String = "cmdRegist_Click"               '確定ﾎﾞﾀﾝ押下時処理

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '====================================Private============================================
    Private mstrLotLastUpdate1                          As String                                   '移載元ﾛｯﾄ最終更新日時
    Private mstrLotLastUpdate2                          As String                                   '移載先ﾛｯﾄ1最終更新日時
    Private mblnTxtCarrierChange                        As Boolean                                  '移載元ｷｬﾘｱID変更ﾌﾗｸﾞ(True：変更、False：未変更)
    Private mstrTxtCarrierChange                        As String                                   '移載元ｷｬﾘｱID退避用変数

    Private mstrEventName                               As String                                   'ﾚｽﾎﾟﾝｽ用ｲﾍﾞﾝﾄ名
    Private mstrLotEventID                              As String                                   'ﾛｯﾄｲﾍﾞﾝﾄID格納
    Private mstrLotEventIDMove                          As String                                   'ﾛｯﾄｲﾍﾞﾝﾄID格納
    Private mblnCarrierMoveFlg                          As Boolean                                  '移載可能ﾌﾗｸﾞ
    Private mblnTakeOverDispFlg                         As Boolean                                  '引継ぎ表示ﾌﾗｸﾞ
    Private mstrSlotSize                                As String                                   'ｽﾛｯﾄｻｲｽﾞ
    Private mstrCarrierTypeID                           As String                                   'ｷｬﾘｱﾀｲﾌﾟID
    Private mstrDivideCombineLotID1                     As String                                   '分割先ﾛｯﾄID1退避用変数
    Private mlngWFListCnt                               As Integer                                  '分割元ﾛｯﾄﾏｯﾌﾟのWFList数
    Private mstrSLotID                                  As String                                   '親(S)ﾛｯﾄID
    Private mstrOrgDivideCombineLotID1                  As String                                   '編集元分割先ﾛｯﾄID1退避用変数

    Private buttonProcessing                           As Boolean                                   'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                   As Boolean                                   'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                            As Boolean                                   'NSYS WindowCloseフラグ


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
    '====================================Private============================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 16:13:29 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値

        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = 0 - My.Settings.FormOffset

            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0280, CMstrLocalVersion)
            
            '@機能ﾊﾞｰｼﾞｮﾝ判定処理結果が"False：Ver不一致"か
            If lblnAns = False Then
                
                '@=======================
                '@ ﾒﾆｭｰ伸縮処理
                '@=======================
                Call pubMenuExpand_Disp()
                
                '@=======================
                '@ ﾌｫｰﾑ終了処理
                '@=======================
                Call Form_QueryUnload(Me, New FormClosingEventArgs(CloseReason.UserClosing,  False))

                Exit Sub
            End If
            
            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN0280_Init(True)
            
            '@Form_Loadﾌﾗｸﾞに"True：起動成功"をｾｯﾄ
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
    '作成日：2004/07/27 (Tue) 17:24:09 H.Wajima
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@-----------------------
            '@ 引継ぎ情報表示済みﾌﾗｸﾞの判定
            '@ ※FormLoad後、最初の1回しか処理しない
            '@-----------------------
            '@引継ぎ情報表示済みﾌﾗｸﾞが"True：表示済"か
            If mblnTakeOverDispFlg = True Then
                Exit Sub
            End If
            
            '@引継ぎ情報表示済みﾌﾗｸﾞに"True：表示済"をｾｯﾄ
            mblnTakeOverDispFlg = True

            '@引数のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then

                '@引継ぎｷｬﾘｱをｷｬﾘｱIDの初期値として設定
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                
                '@=======================
                '@ ｷｬﾘｱIDﾃｷｽﾄValidate処理
                '@=======================
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate

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
    '　　　：Shift  ：Ctrl、Shift、Altの状態ｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 13:04:25 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
            Select Case e.KeyCode

                '@〓 Enterｷｰ 〓
                Case Keys.Return
                    
                    '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                    Select Case ActiveControl.Name
                        
                        '@〓〓 ｷｬﾘｱIDﾃｷｽﾄ 〓〓
                        Case txtCarrier.Name
                            
                            '@=======================
                            '@ ｷｬﾘｱIDﾃｷｽﾄValidate処理
                            '@=======================
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                            
                            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙがｷｬﾘｱID、かつ退避移載元ｷｬﾘｱIDが現在の移載元ｷｬﾘｱID名と同じか
                            If ActiveControl.Name = txtCarrier.Name And _
                                mstrTxtCarrierChange = txtCarrier.Text Then
                                
                                '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄし、ｷｰｺｰﾄﾞを初期化
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            End If
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate

                            Exit Sub

                    End Select
                               
                    '@退避移載元ｷｬﾘｱIDに現在のｷｬﾘｱIDを格納
                    mstrTxtCarrierChange = txtCarrier.Text
                    
                    '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ、ｷｰｺｰﾄﾞを初期化
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
    '引　数：Cancel     ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 16:45:55 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 14:55:09 T.Kitagawa   閉じるﾎﾞﾀﾝ統合
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@ﾌｫｰﾑの"×"ﾎﾞﾀﾝにて閉じたか
            If mblnCloseFromControlMenu Then

                '@=======================
                '@ 閉じるﾎﾞﾀﾝ処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@画面間の引渡し用LotIDの初期化
            pstrLotID = vbNullString

            '@ACT初期化ﾌﾗｸﾞが"True：自前で初期化"か
            If pblnActInitFlg = True Then
                
                '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                lblnAnsTerm = pubblnAct_Term
                If lblnAnsTerm = True Then
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@ACT初期化ﾌﾗｸﾞが"False：自前で初期化"以外の場合

                '@=======================
                '@ ﾒﾆｭｰ伸縮処理
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
    '作成日：2004/06/01 (Tue) 12:57:33 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            
            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN0280_Init(False)
            
            '@移載元ｷｬﾘｱID変更ﾌﾗｸﾞに"True：変更"をｾｯﾄ
            mblnTxtCarrierChange = True
            
            '@移載元ｷｬﾘｱID退避用変数の初期化
            mstrTxtCarrierChange = vbNullString
            
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
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　入力確定時(Validate)処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 12:20:47 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2004/08/27 (Fri) 17:31:53 N.Kasai      ｷｬﾘｱﾀｲﾌﾟ追加
    '　　　：2004/09/22 (Wed) 20:02:42 M.Miura      WF移載ﾌﾗｸﾞ判定の位置変更(ｴﾗｰ時にﾛｯﾄ情報を表示しない)
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAns                         As Boolean              '結果取得(True：正常、False：異常)
        Dim ltypLotmoveinfo                 As Lotmoveinfo          'ﾛｯﾄ移載情報格納構造体
        Dim llngCnt                         As Integer              'ｶｳﾝﾄ数
        Dim lblnNextCtrl                    As Boolean              'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            If ActiveControl.Name = txtCarrier.Name OrElse _
                (cmdRegist.Enabled = True And ActiveControl.Name = cmdRegist.Name) OrElse _
                (cmdRegist.Enabled = False And ActiveControl.Name = cmdClose.Name) Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If

            '@-----------------------
            '@ ｷｬﾘｱIDのﾁｪｯｸ
            '@-----------------------
            '@ｷｬﾘｱIDがNULLか
            If Trim(txtCarrier.Text) = vbNullString Then
                
                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If lblnNextCtrl Then
                    Call pubSetFocus(cmdClose)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDが6桁未満か
            If LenB(txtCarrier.Text) < CMlngMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                e.Cancel = True
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                If lblnNextCtrl Then
                    Call pubSetFocus(txtCarrier)
                End If
                Exit Sub
            End If

            '@移載元ｷｬﾘｱID変更ﾌﾗｸﾞが"False：未変更"か
            If mblnTxtCarrierChange = False Then
            
                '@移載元ｷｬﾘｱID退避変数に現在ｷｬﾘｱIDをｾｯﾄ
                mstrTxtCarrierChange = txtCarrier.Text
                Exit Sub
            End If


            '@ｷｬﾘｱIDがNULL以外、かつ6桁か
            If Trim(txtCarrier.Text) <> vbNullString And _
                Len(Trim(txtCarrier.Text)) = txtCarrier.ChrMaxByte Then

                '@移載元ｷｬﾘｱID変更ﾌﾗｸﾞに"True：変更"をｾｯﾄ
                mblnTxtCarrierChange = True
                
                '@ﾛｯﾄｲﾍﾞﾝﾄIDを初期化
                mstrLotEventID = vbNullString

                '@ﾚｽﾎﾟﾝｽ測定開始
                mstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(CMstrFormName, mstrEventName)
                
                '@=======================
                '@ ﾛｯﾄ移載情報取得
                '@=======================
                lblnAns = pubblnLotmoveinfo_Sel(CMstrlot_moveinfoVer, _
                                                txtCarrier.Text, _
                                                ltypLotmoveinfo)

                                    
                '@ﾛｯﾄ移載情報取得結果が"True：取得成功"か
                If lblnAns = True Then

                    '@ﾚｽﾎﾟﾝｽ測定終了
                    Call publngResponseEnd(CMstrFormName, mstrEventName)

                    '@WF移載ﾌﾗｸﾞが"1：必要"以外(不要)か
                    If ltypLotmoveinfo.strWfCarryFlag <> CMstrWFCarryFlag1 Then
                        
                        '@=======================
                        '@ 移載不要時処理
                        '@=======================
                        Call prvWfCarryFlag0_Proc(lblnNextCtrl)
                        
                        '@移載元ｷｬﾘｱID変更ﾌﾗｸﾞに"True：変更"をｾｯﾄ
                        mblnTxtCarrierChange = True
                        Exit Sub
                    End If

                    '@-----------------------
                    '@ 画面情報表示処理
                    '@-----------------------
                    With ltypLotmoveinfo

                        mlngWFListCnt = .lngWfListCnt               'WF数
                        mstrCarrierTypeID = .strCarrierTypeID       'ｷｬﾘｱﾀｲﾌﾟID
                        mstrSLotID = .strOrgLotID1                  '親(S)ﾛｯﾄID

                        For llngCnt = 0 To .lngWfListCnt - 1
                            
                            '@★ 分割/統合ｽﾃｰﾀｽにより処理分岐 ★
                            Select Case .typMoveInfoWFList(llngCnt).strDivideCombineStatus
                                
                                '@〓 D1：分割 〓
                                Case CMstrDivideCombineStatusD1

                                    mstrLotEventID = CMlngLotEventIDD           'ﾛｯﾄｲﾍﾞﾝﾄ：10(分割)
                                    lblLotID.Text = .strLotID1               '移載元ﾛｯﾄID
                                    lblFlowClass.Text = .strFlowClass        '移載元ﾛｯﾄ流動区分
                                    mstrLotLastUpdate1 = .strLotLastUpdate1     '移載元最終更新日時
                                    mstrLotLastUpdate2 = .strLotLastUpdate2     '移載元1最終更新日時
                                    
                                    Exit For


                                '@〓 C1：統合 〓
                                Case CMstrDivideCombineStatusC1

                                    mstrLotEventID = CMlngLotEventIDC           'ﾛｯﾄｲﾍﾞﾝﾄ：11(統合)
                                    '@ﾌﾚｰﾑ見出し設定
                                    fraLot.Text = CMstrToMove                '移載元
                                    fraLot2.Text = CMstrFromMove             '移載先
                                    
                                    '@"→"を非表示
                                    picRightAllow.Visible = False
                                    '@"←"を表示
                                    picLeftAllow.Visible = True
                                    
                                    lblLotIDMove.Text = .strLotID1           'ﾛｯﾄID
                                    lblFlowClassMove.Text = .strFlowClass    '流動区分
                                    mstrLotLastUpdate1 = .strLotLastUpdate2     '移載元最終更新日時
                                    mstrLotLastUpdate2 = .strLotLastUpdate1     '移載元1最終更新日時
                                    
                                    Exit For


                                '@〓 その他 〓
                                Case Else

                                    lblLotID.Text = .strLotID1               'ﾛｯﾄID
                                    lblFlowClass.Text = .strFlowClass        '流動区分
                                    mstrLotLastUpdate1 = .strLotLastUpdate1     '移載元最終更新日時
                                    mstrLotLastUpdate2 = .strLotLastUpdate2     '移載元1最終更新日時

                            End Select
                        Next llngCnt
                        
                        '@ﾛｯﾄｲﾍﾞﾝﾄがNULLか
                        If mstrLotEventID = vbNullString Then
                            
                            '@12：不良/払出/保留をｾｯﾄ
                            mstrLotEventID = CMlngLotEventID
                        End If
                    
                    End With
                    
                    '@=======================
                    '@ 移載必要時処理
                    '@=======================
                    Call prvWfCarryFlag1_Proc(ltypLotmoveinfo, lblnNextCtrl)

                    '@移載元ｷｬﾘｱID変更ﾌﾗｸﾞに"False：未変更"をｾｯﾄ
                    mblnTxtCarrierChange = False

                Else
                    '@ﾛｯﾄ移載情報取得結果が"False：取得失敗"か

                    '@ﾚｽﾎﾟﾝｽ測定中止
                    Call pubResponseCancel(CMstrFormName, mstrEventName)

                    '@ｷｬﾘｱIDへﾌｫｰｶｽを留める
                    e.Cancel = True

                    '@ｷｬﾘｱIDのﾊｲﾗｲﾄ処理
                    Call pubHighlight(txtCarrier)

                End If

            Else
                '@ｷｬﾘｱIDがNULL、かつ6桁以外か(※一応残すが、この処理に入ることは無い)

                '@=======================
                '@ 画面初期化処理
                '@=======================
                Call prvFrmxxEN0280_Init(True)
            End If
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝ有効/無効制御
            '@=======================
            Call prvcmdRegist_Chk(lblnNextCtrl)
            
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

    '関数名：cmdClose_Click
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 16:46:44 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim llngRet             As Integer      '戻り値
        Dim ltypCommonInfo      As CommonInfo   'ﾀﾞﾐｰ構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
 
            '@引継ぎｷｬﾘｱIDがNULL以外か(引継ぎ起動)
            If ptypCommonInfo.strCarrierId <> vbNullString Then

                '@装置別ﾛｯﾄ一覧から引き継いで起動されたか
                If pblnfrmxxEN0150Kbn = True Then
                    
                    '@=======================
                    '@ ﾒﾆｭｰからの機能選択処理(装置別ﾛｯﾄ一覧起動)
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN0150)

                Else
                    '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧から引き継いで起動されたか
                    If pblnfrmxxEN00J0Kbn = True Then

                        '@=======================
                        '@ ﾒﾆｭｰからの機能選択処理(装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧)
                        '@=======================
                        Call pubMenuSelect_Proc(CPstrKeyEN00J0)
                    Else
                        '@工程別ﾛｯﾄ一覧から引き継いで起動された場合

                        '@=======================
                        '@ ﾒﾆｭｰからの機能選択処理(工程別ﾛｯﾄ一覧)
                        '@=======================
                        Call pubMenuSelect_Proc(CPstrKeyEN0200)
                    End If
                End If
            Else
                '@引継ぎｷｬﾘｱIDがNULLの場合(単独起動)

                '@=======================
                '@ 終了関数実行(戻り値は使用しない)
                '@=======================
                llngRet = publngEnd_Proc(CPstrKeyEN0280, ltypCommonInfo)
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

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 13:52:49 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2009/08/10 (Mon) 17:57:44 N.Kojima     試作実験ﾛｯﾄの場合、確定時に検査工数削減のMsgを表示する。(案件№03542)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAnsChk              As Boolean              '項目ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnLotOut              As Boolean              'ﾛｯﾄｱｳﾄﾌﾗｸﾞ(True：ﾛｯﾄｱｳﾄ、False：ﾛｯﾄｱｳﾄ以外)
        Dim lblnAnsLotMove          As Boolean              'ﾛｯﾄ移載情報結果格納用
        Dim ltypReqLotMove          As LotMove____          'ﾛｯﾄ移載情報要求格納用
        Dim llngCnt                 As Integer              '一覧表のSlot№ｶｳﾝﾄ
        Dim llngListCnt             As Integer              'ﾘｽﾄｶｳﾝﾄ
        Dim llngMaxCnt              As Integer              'WF数ｶｳﾝﾄ
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrMsg                 As String               '変換後ﾒｯｾｰｼﾞ1
        Dim lstrMsg2                As String               '変換後ﾒｯｾｰｼﾞ2

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
            lblnAnsChk = prvblnRegist_Chk()
            
            '@確定時ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnAnsChk = False Then
                Exit Sub
            End If


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@作業者ｺｰﾄﾞ入力画面でｷｬﾝｾﾙﾎﾞﾀﾝが押下されたか
            If pblnCancel = True Then
                Exit Sub
            End If

            
            '@ﾛｯﾄｱｳﾄﾌﾗｸﾞの初期化
            lblnLotOut = True

            '@-----------------------
            '@ 移載元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap

                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        
                        '@ﾛｯﾄｱｳﾄﾌﾗｸﾞに"False：ﾛｯﾄｱｳﾄ以外"をｾｯﾄ
                        lblnLotOut = False
                        Exit For
                    End If
                Next llngCnt
            End With


            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypReqLotMove
                
                .strSbID = pstrSBID                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                
                '@★ 移載区分により処理分岐 ★
                Select Case lblMoveClass.Text
                    
                    '@〓 分割 〓
                    Case CMstrDivide

                        .strCarrierID1 = txtCarrier.Text                        '移載元ｷｬﾘｱID
                        .strLotLastUpdate1 = mstrLotLastUpdate1                 '移載元ﾛｯﾄ最終更新日時
                        .strCarrierID2 = lblCarrierMove.Text                 '移載先ｷｬﾘｱID
                        .strLotID2 = lblLotIDMove.Text                       '移載先ﾛｯﾄID
                        .strLotLastUpdate2 = mstrLotLastUpdate2                 '移載先ﾛｯﾄ最終更新日時


                    '@〓 統合 〓
                    Case CMstrCombine

                        .strCarrierID1 = lblCarrierMove.Text                 '移載元ｷｬﾘｱID
                        .strLotLastUpdate1 = mstrLotLastUpdate2                 '移載元ﾛｯﾄ最終更新日時
                        .strCarrierID2 = txtCarrier.Text                        '移載先ｷｬﾘｱID
                        .strLotID2 = lblLotID.Text                           '移載先ﾛｯﾄID
                        .strLotLastUpdate2 = mstrLotLastUpdate1                 '移載先ﾛｯﾄ最終更新日時

                    
                    '@〓 不良/保留/払出 〓
                    Case Else

                        .strCarrierID1 = txtCarrier.Text                        '移載元ｷｬﾘｱID
                        .strLotLastUpdate1 = mstrLotLastUpdate1                 '移載元ﾛｯﾄ最終更新日時
                        .strCarrierID2 = lblCarrierMove.Text                 '移載先ｷｬﾘｱID
                        .strLotID2 = vbNullString                               '移載先ﾛｯﾄID
                        .strLotLastUpdate2 = vbNullString                       '移載先ﾛｯﾄ最終更新日時
                        
                        '@WFｶｳﾝﾄの初期化
                        llngMaxCnt = 0
                        
                        '@移載先WFの枚数をｶｳﾝﾄ
                        '@移載先ｷｬﾘｱﾏｯﾌﾟのﾙｰﾌﾟ
                        For llngCnt = 1 To CMlngSlotMapRowS - 1
                            
                            With vsfSlotMapMove
                                
                                '@WFIDがNULL以外か
                                If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                                    
                                    '@WFｶｳﾝﾄを+1する
                                    llngMaxCnt = llngMaxCnt + 1
                                End If
                            End With
                        Next llngCnt
                        
                        '@構造体定義
                        ltypReqLotMove.typWFMapList = New List(Of Move____WFMapList)()
                        
                        '@ﾘｽﾄｶｳﾝﾄ初期化
                        llngListCnt = 0
                        
                        '@移載先ｷｬﾘｱﾏｯﾌﾟのﾙｰﾌﾟ
                        For llngCnt = 1 To CMlngSlotMapRowS - 1
                            
                            With vsfSlotMapMove
                                '@WFIDがNULL以外か
                                If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                                    Dim tmpMove____WFMapList As Move____WFMapList = New Move____WFMapList()        
                                    '@ﾘｽﾄｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                                    llngListCnt = llngListCnt + 1

                                    '@移載先ｽﾛｯﾄ№
                                    tmpMove____WFMapList.strSlotPosition = _
                                        .GetData(llngCnt, CMlngColSlot)
                                    
                                    '@移載先WFID
                                    tmpMove____WFMapList.strWfId = _
                                        .GetData(llngCnt, CMlngColWFID)

                                    ltypReqLotMove.typWFMapList.Add(tmpMove____WFMapList)
                                End If
                            End With
                            
                        Next llngCnt
                        
                End Select
                
                .strEmpID = pstrUserID                          '作業者ID
                .strClassDivision = CPstrCD01                   '処理区分(01:ｸﾗｲｱﾝﾄ)
            End With


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)

            '@=======================
            '@ ﾛｯﾄ移載
            '@=======================
            lblnAnsLotMove = pubblnLotMove_____Upd(CMstrlot_move____Ver, _
                                                   ltypReqLotMove, _
                                                   llngListCnt, _
                                                   lstrGuidMsg, _
                                                   lstrGuidMsgCode)
            
            '@ﾛｯﾄ移載結果が"True：処理成功"か
            If lblnAnsLotMove = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)

                '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞがNULL以外か
                If lstrGuidMsgCode <> vbNullString Then
                    
                    '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                    lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                       CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                       CPstrMsgCrCode & lstrGuidMsg
                    
                    '@上記の"編集済みｶﾞｲﾀﾞﾝｽMsg"を表示
                    pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If


                '@★ 移載区分により処理分岐(成功ﾒｯｾｰｼﾞ表示内容) ★
                Select Case lblMoveClass.Text
                    
                    '@〓 分割 〓
                    Case CMstrDivide

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM62I>$$移載しました。移載先キャリア[%1] 移載後ロット[%2]"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0062, lblCarrierMove.Text, lblLotIDMove.Text)
                        Call pubVsfInfo_Disp(pstrDMsg)


                    '@〓 統合 〓
                    Case CMstrCombine

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM62I>$$移載しました。移載先キャリア[%1] 移載後ロット[%2]"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0062, txtCarrier.Text, lblLotID.Text)
                        Call pubVsfInfo_Disp(pstrDMsg)


                    '@〓 不良/払出/保留 〓
                    Case CMstrScrap
                        
                        '@ﾛｯﾄｱｳﾄﾌﾗｸﾞが"True：ﾛｯﾄｱｳﾄ"か
                        If lblnLotOut = True Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM32I>$$ロット[%2]終了しました。キャリア[%1]"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0032, lblCarrierMove.Text, lblLotIDMove.Text)
                        
                        Else
                            '@ﾛｯﾄｱｳﾄﾌﾗｸﾞが"False：ﾛｯﾄｱｳﾄ以外"か

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM63I>$$移載しました。移載先キャリア[%1] "のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0063, lblCarrierMove.Text)

                        End If
                        '@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰにもﾒｯｾｰｼﾞ表示
                        Call pubVsfInfo_Disp(pstrDMsg)

                End Select
                          
        '@↓2009/08/10 (Mon) 17:28:41 N.Kojima **************************************************

                '@起動SBが"1A0：基板"か
                If pstrSBID = CPstrSBID1A0 Then
            
                    '@ﾛｯﾄの種別が"試作/実験品：GG,TS,WS,ZZ"か
                    If lblFlowClass.Text = CPstrFlowClassGG Or _
                        lblFlowClass.Text = CPstrFlowClassTS Or _
                        lblFlowClass.Text = CPstrFlowClassWS Or _
                        lblFlowClass.Text = CPstrFlowClassZZ Then
                        
                        '@★ 移載区分により処理分岐(成功ﾒｯｾｰｼﾞ表示内容) ★
                        Select Case lblMoveClass.Text
                        
                            '@〓 分割 〓
                            Case CMstrDivide
                        
                                '@表示ﾒｯｾｰｼﾞを編集(分割元ロット[XXX] 分割先ロット[XXX])
                                lstrMsg = CPstrDivideFrom & CPstrBrLeft & mstrSLotID & CPstrBrRight
                                lstrMsg2 = CPstrDivideTo & CPstrBrLeft & lblLotIDMove.Text & CPstrBrRight
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                '@"<TRM1ZI>$$%1が[%2]されました。$検査工数削減の為、必要に応じて外観・現像検査工程の
                                '@ 検査ウェハ枚数を見直して下さい。$%3 %4"のﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0024, CPstrLot, CPstrDivide, lstrMsg, lstrMsg2)


                            '@〓 統合 〓
                            Case CMstrCombine
                            
                                '@表示ﾒｯｾｰｼﾞを編集(統合先ロット[XXX])
                                lstrMsg = CPstrCombineTo & CPstrBrLeft & mstrSLotID & CPstrBrRight
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                '@"<TRM1ZI>$$%1が[%2]されました。$検査工数削減の為、必要に応じて外観・現像検査工程の
                                '@ 検査ウェハ枚数を見直して下さい。$%3 %4"のﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0025, CPstrLot, CPstrCombine, lstrMsg, vbNullString)


                            '@〓 不良/払出/保留 〓
                            Case CMstrScrap
            
                                '@表示ﾒｯｾｰｼﾞを編集(ロット[XXX])
                                lstrMsg = CPstrLot & CPstrBrLeft & mstrSLotID & CPstrBrRight
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                '@"<TRM1ZI>$$%1が[%2]されました。$検査工数削減の為、必要に応じて外観・現像検査工程の
                                '@ 検査ウェハ枚数を見直して下さい。$%3 %4"のﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0024, CPstrWF, CPstrScrap, lstrMsg, vbNullString)

                        End Select
                        
                        '@ﾒｯｾｰｼﾞBOX表示
                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                        
                    End If
                End If

        '@↑2009/08/10 (Mon) 17:28:41 N.Kojima **************************************************
                   
                '@=======================
                '@ 画面初期化処理
                '@=======================
                Call prvFrmxxEN0280_Init(True)

                Exit Sub
            Else
                '@ﾛｯﾄ移載結果が"False：処理失敗"か

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
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
    '====================================Private============================================

    '関数名：prvFrmxxEN0280_Init
    '機　能：画面初期化処理
    '引　数：lblnAllClear   ：True：全項目初期化、False：lblnCarrier依存
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 16:48:33 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 15:00:17 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvFrmxxEN0280_Init(ByVal lblnAllClear As Boolean)

        Dim lstrFormTitle       As String       'ﾌｫｰﾑﾀｲﾄﾙ

        Try
            
            '@=======================
            '@ 機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0280, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@初期化
            If lblnAllClear = True Then
                txtCarrier.Text = vbNullString          '移載元ｷｬﾘｱID
            End If
            
            '@-----------------------
            '@ 移載元情報の初期化
            '@-----------------------
            lblLotID.Text = vbNullString             '移載元ﾛｯﾄID
            lblFlowClass.Text = vbNullString         '移載元流動区分

            '@-----------------------
            '@ 移載先情報の初期化
            '@-----------------------
            lblCarrierMove.Text = vbNullString       '移載先ｷｬﾘｱID
            lblLotIDMove.Text = vbNullString         '移載先ﾛｯﾄID
            lblFlowClassMove.Text = vbNullString     '移載先流動区分
            
            lblMoveClass.Text = vbNullString         '移載区分
            
            '@ﾓｼﾞｭｰﾙ変数の初期化
            mstrDivideCombineLotID1 = vbNullString      '分割先ﾛｯﾄID1退避用変数
            mlngWFListCnt = 0                           '分割元ﾛｯﾄﾏｯﾌﾟのWFList数
            mstrSLotID = vbNullString                   '親(S)ﾛｯﾄID
            
            '@確定ﾎﾞﾀﾝを無効にする
            cmdRegist.Enabled = False

            '@=======================
            '@ 移載元・移載先ｽﾛｯﾄﾏｯﾌﾟの初期化
            '@=======================
            Call prvvsfSlotMap_init(vsfSlotMap)         '移載元
            Call prvvsfSlotMap_init(vsfSlotMapMove)     '移載先
            
            '@ﾌﾚｰﾑ見出し設定
            fraLot.Text = CMstrFromMove              '移載元
            fraLot2.Text = CMstrToMove               '移載先
            
            '@移載方向表示
            picRightAllow.Visible = True                '"→"：表示
            picLeftAllow.Visible = False                '"←"：非表示

            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN0280_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMap_Init
    '機　能：移載元・移載先ｽﾛｯﾄﾏｯﾌﾟの初期化処理
    '引　数：lobjControl    ：ｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 16:57:14 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvvsfSlotMap_init(ByRef lobjControl As C1FlexGrid)

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            '@対象ｵﾌﾞｼﾞｪｸﾄがｸﾞﾘｯﾄﾞか
            If TypeOf lobjControl Is C1FlexGrid Then
                
                '@-----------------------
                '@ ｸﾞﾘｯﾄﾞの初期設定
                '@-----------------------
                With lobjControl
                    .Redraw = False

                    '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                    .Clear(ClearFlags.Content)
                    
                    '@各種ﾌﾟﾛﾊﾟﾃｨ設定
                    .Rows.Count = CMlngSlotMapRowS                                                                '行数
                    .Cols.Count = CMlngSlotMapCols                                                                '列数
                    
                    '@↓2019/12/31 (Tue) 14:54:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    'Dim cellRange As CellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngColSlot, CMlngSlotMapRowTitle, CMlngColWFID) '表題
                    Dim cellRange As CellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngColSlot, CMlngSlotMapRowTitle, CMlngColGRB) '表題
                    '@↑2019/12/31 (Tue) 14:54:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                    headerStyle.ForeColor = Color.Yellow                                                     '文字色
                    headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))       '背景色
                    headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngSlotHMaCellFontSize, _
                                                headerStyle.Font.Style, headerStyle.Font.Unit)               'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    headerStyle.TextAlign = TextAlignEnum.CenterCenter                                       '文字位置
                    headerStyle.Trimming  = StringTrimming.None                                              'NSYS ﾍｯﾀﾞは省略表示なしに設定
                    cellRange.Style = headerStyle

                    
                    '@ﾊﾞｯｸｶﾗｰ設定(白)
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                    newStyle.BackColor = Color.White
                    newStyle.TextAlign = TextAlignEnum.LeftCenter    'WFID：左中央
                    '@↓2019/12/31 (Tue) 14:54:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    'cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                    cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColGRB)
                    '@↑2019/12/31 (Tue) 14:54:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    cellRange.Style = newStyle
                    
                    '@列幅、ﾀｲﾄﾙの設定
                    .Cols(CMlngColSlot).Width = CMlngColSlotWidth                                   'ｽﾛｯﾄ№幅
                    .Cols(CMlngColWFID).Width = CMlngColWFIDWidth                                   'WFID列幅
                    .Cols(CMlngColToCarrySlotPosition).Width = CMlngColToCarrySlotPositionWidth     '移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ(非表示)列幅
                    .SetData(CMlngSlotMapRowTitle, CMlngColWFID, CMstrSlotMapColTWFID)              'WFID)
                    '@↓2019/12/31 (Tue) 14:50:24 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    .Cols(CMlngColGRB).Width = CMlngColGRBWidth                                     'GRB
                    .SetData(CMlngSlotMapRowTitle, CMlngColGRB, CMstrSlotMapColTGRB)                'GRB
                    '@↑2019/12/31 (Tue) 14:50:24 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    
                    '@非表示列の設定
                    .Cols(CMlngColToCarrySlotPosition).Visible = False                                          'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                    .Cols(CMlngColDivideCombineLotID).Visible = False                                           '移載先ﾛｯﾄID
                    
                    '@ｽﾛｯﾄ№設定
                    For llngCnt = 1 To CMlngSlotMapRowS - 1
                        
                        .Col = CMlngColSlot
                        .Row = llngCnt
                        '.CellFontSize = CMlngSlotHMaCellFontSize
                        .SetData(llngCnt, CMlngColSlot, CStr(Format$(CMlngSlotMapRowS - llngCnt, CPstrSlotNoFormat)))
                        .Rows(llngCnt).Height = CMlngSlotMapHeight
                    Next llngCnt

                    Dim fixedStyle As CellStyle = .Styles.Fixed
                    fixedStyle.TextAlign = TextAlignEnum.RightCenter      'ｽﾛｯﾄ№：右中央
                    fixedStyle.Font = New Font(fixedStyle.Font.FontFamily, CMlngSlotHMaCellFontSize, _
                                               fixedStyle.Font.Style, fixedStyle.Font.Unit)
                    
                    .Row = 0
                    .Redraw = True
                    '@無効にする
                    .Enabled = False
                    
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

    '関数名：prvVsfSlotMapDivide_Disp
    '機　能：分割時ｽﾛｯﾄﾏｯﾌﾟ表示処理
    '引　数：ltypLotmoveinfo    ：ﾛｯﾄ移載情報取得構造体
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 12:37:00 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvVsfSlotMapDivide_Disp(ByRef ltypLotmoveinfo As Lotmoveinfo)

        Dim llngCnt         As Integer      'ｶｳﾝﾄ数
        Dim llngWriteRow    As Integer      '書き込み行
        Dim cellRange       As CellRange

        Try
           
            '@-----------------------
            '@ 移載元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
                
                '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                '@↓2019/12/31 (Tue) 15:00:26 Y.Yoneyama 「.Netへ反映未」 **************************************************
                'cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColGRB)
                '@↑2019/12/31 (Tue) 15:00:26 Y.Yoneyama 「.Netへ反映未」 **************************************************
                cellRange.Style = newStyle
            End With

            '@-----------------------
            '@ 移載先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapMove
                
                '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                '@↓2019/12/31 (Tue) 15:00:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                'cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColGRB)
                '@↑2019/12/31 (Tue) 15:00:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                cellRange.Style = newStyle
            End With


            '@移載元・移載先ｽﾛｯﾄﾏｯﾌﾟの初期化
            For llngCnt = 1 To CMlngSlotMapRowS - 1
                
                '@ｽﾛｯﾄ№がｽﾛｯﾄｻｲｽﾞ以内か
                If ltypLotmoveinfo.strSlotSize < CMlngSlotMapRowS - llngCnt Then
                    
                    '@ｽﾛｯﾄ№の初期化
                    vsfSlotMap.SetData(llngCnt, CMlngColSlot, vbNullString)
                    vsfSlotMapMove.SetData(llngCnt, CMlngColSlot, vbNullString)
                    
                    '@背景色の初期化
                    '@WFID
                    '@GRB
                    Dim newStyle1 As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                    newStyle1.BackColor = SystemColors.ControlLight
                    '@↓2019/12/31 (Tue) 15:01:26 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    'cellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID)
                    cellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColGRB)
                    '@↑2019/12/31 (Tue) 15:01:26 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    cellRange.Style = newStyle1
                    Dim newStyle2 As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                    newStyle2.BackColor = SystemColors.ControlLight
                    '@↓2019/12/31 (Tue) 15:01:26 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    'cellRange  = vsfSlotMapMove.GetCellRange(llngCnt, CMlngColWFID)
                    cellRange  = vsfSlotMapMove.GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColGRB)
                    '@↑2019/12/31 (Tue) 15:01:26 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    cellRange.Style = newStyle2
                End If
            Next llngCnt
                
            '@ｶｳﾝﾀの初期化
            llngCnt = 0
            
            Do While ltypLotmoveinfo.lngWfListCnt > llngCnt
            
                With ltypLotmoveinfo.typMoveInfoWFList(llngCnt)
                    
                    '@書き込み行の設定
                    llngWriteRow = CMlngSlotMapRowS - CInt(.strSlotPosition)
                    
                    '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝがNULLか
                    If .strToCarrySlotPosition = vbNullString Then
                        
                        '@移載元ｽﾛｯﾄﾏｯﾌﾟの設定
                        vsfSlotMap.SetData(llngWriteRow, CMlngColWFID, .strWfId)                      'WFID
                        vsfSlotMap.SetData(llngWriteRow, CMlngColToCarrySlotPosition, vbNullString)   'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                        Dim newStyle As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        cellRange = vsfSlotMap.GetCellRange(llngWriteRow, CMlngColWFID)
                        cellRange.Style = newStyle                  'WFID列ﾊﾞｯｸｶﾗｰ：白

                        '@↓2019/12/31 (Tue) 15:05:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        vsfSlotMap.SetData(llngWriteRow, CMlngColGRB, .strGRBClass)                   'GRB
                        '@GRB背景色
                        newStyle = vsfSlotMap.Styles.Add("GRBColor" + llngWriteRow.ToString)
                        newStyle.BackColor = pubGRBBackColor(.strGRBClass, Color.White)
                        cellRange = vsfSlotMap.GetCellRange(llngWriteRow, CMlngColGRB)
                        cellRange.Style = newStyle                  
                        '@↑2019/12/31 (Tue) 15:05:34 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    Else
                        '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝがNULL以外の場合

                        '@移載先ｽﾛｯﾄﾏｯﾌﾟの設定
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColWFID, .strWfId)                                'WFID
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColToCarrySlotPosition, .strToCarrySlotPosition)  'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColDivideCombineLotID, .strDivideCombineLotID)    'ﾛｯﾄID
                        '@↓2019/12/31 (Tue) 15:05:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColGRB, .strGRBClass)                             'GRB
                        '@↑2019/12/31 (Tue) 15:05:34 Y.Yoneyama 「.Netへ反映未」 **************************************************                        

                        '@WFLISTの1枚目の分割先1ﾛｯﾄIDを退避
                        If llngCnt = 0 Then
                            
                            '@分割先1ﾛｯﾄIDを退避させる
                            mstrDivideCombineLotID1 = .strDivideCombineLotID
                            mstrOrgDivideCombineLotID1 = .strOrgDivideCombineLotID
                        Else
                            '@分割先1ﾛｯﾄID退避用変数で分割先1ﾛｯﾄIDが空白ではない場合、分割先1ﾛｯﾄIDを退避
                            If mstrDivideCombineLotID1 = vbNullString And _
                                .strDivideCombineLotID <> vbNullString Then
                                
                                '@分割先1ﾛｯﾄIDを退避させる
                                mstrDivideCombineLotID1 = .strDivideCombineLotID
                                mstrOrgDivideCombineLotID1 = .strOrgDivideCombineLotID
                            End If
                        End If
                        
                        '@移載先ｷｬﾘｱIDがNULLか
                        If lblCarrierMove.Text = vbNullString Then
                            
                            '@移載先ｷｬﾘｱIDをｾｯﾄ
                            lblCarrierMove.Text = .strToCarrierId
                        End If
                        
                        '@移載先ﾛｯﾄIDがNULLか
                        If lblLotIDMove.Text = vbNullString Then
                            
                            '@移載先ﾛｯﾄIDをｾｯﾄ
                            lblLotIDMove.Text = .strDivideCombineLotID
                        End If
                        
                        '@移載先流動区分がNULLか
                        If lblFlowClassMove.Text = vbNullString Then
                            
                            '@移載先流動区分をｾｯﾄ
                            lblFlowClassMove.Text = .strToFlowClass
                        End If
                        
                        '@ﾊﾞｯｸｶﾗｰを白に変更
                        Dim newStyle As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        cellRange = vsfSlotMapMove.GetCellRange(llngWriteRow, CMlngColWFID)
                        cellRange.Style = newStyle
                        '@↓2019/12/31 (Tue) 15:03:10 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        '@GRB背景色
                        newStyle = vsfSlotMapMove.Styles.Add("GRBColor" + llngWriteRow.ToString)
                        newStyle.BackColor = pubGRBBackColor(.strGRBClass, Color.White)
                        cellRange = vsfSlotMapMove.GetCellRange(llngWriteRow, CMlngColGRB)
                        cellRange.Style = newStyle
                        '@↑2019/12/31 (Tue) 15:03:10 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    End If

                    '@ｶｳﾝﾄｱｯﾌﾟ
                    llngCnt = llngCnt + 1

                End With
            Loop
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMapDivide_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMapCombine_Disp
    '機　能：統合時ｽﾛｯﾄﾏｯﾌﾟ表示処理
    '引　数：ltypLotmoveinfo    ：ﾛｯﾄ移載情報取得構造体
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 12:37:00 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvVsfSlotMapCombine_Disp(ByRef ltypLotmoveinfo As Lotmoveinfo)

        Dim llngCnt         As Integer      'ｶｳﾝﾄ数
        Dim llngWriteRow    As Integer      '書き込み行
        Dim cellRange       As CellRange

        Try

            '@-----------------------
            '@ 移載元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
                
                '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                '@↓2019/12/31 (Tue) 15:03:45 Y.Yoneyama 「.Netへ反映未」 **************************************************
                'cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColGRB)
                '@↑2019/12/31 (Tue) 15:03:45 Y.Yoneyama 「.Netへ反映未」 **************************************************
                cellRange.Style = newStyle
            End With

            '@-----------------------
            '@ 移載先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapMove
                
                '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                '@↓2019/12/31 (Tue) 15:03:55 Y.Yoneyama 「.Netへ反映未」 **************************************************
                'cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColGRB)
                '@↑2019/12/31 (Tue) 15:03:55 Y.Yoneyama 「.Netへ反映未」 **************************************************
                cellRange.Style = newStyle
            End With
            

            For llngCnt = 1 To CMlngSlotMapRowS - 1
                
                '@ｽﾛｯﾄ№がｽﾛｯﾄｻｲｽﾞ以内か
                If ltypLotmoveinfo.strSlotSize < CMlngSlotMapRowS - llngCnt Then
                    
                    '@ｽﾛｯﾄ№の初期化
                    vsfSlotMap.SetData(llngCnt, CMlngColSlot, vbNullString)
                    vsfSlotMapMove.SetData(llngCnt, CMlngColSlot, vbNullString)
                    
                    '@背景色の初期化
                    '@WFID
                    '@GRB
                    Dim newStyle1 As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                    newStyle1.BackColor = SystemColors.ControlLight
                    '@↓2019/12/31 (Tue) 15:04:21 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    'cellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID)
                    cellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColGRB)
                    '@↑2019/12/31 (Tue) 15:04:21 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    cellRange.Style = newStyle1
                    Dim newStyle2 As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                    newStyle2.BackColor = SystemColors.ControlLight
                    '@↓2019/12/31 (Tue) 15:04:21 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    'cellRange = vsfSlotMapMove.GetCellRange(llngCnt, CMlngColWFID)
                    cellRange = vsfSlotMapMove.GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColGRB)
                    '@↑2019/12/31 (Tue) 15:04:21 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    cellRange.Style = newStyle2
                End If
            Next llngCnt
                
            '@ｶｳﾝﾀの初期化
            llngCnt = 0

            Do While ltypLotmoveinfo.lngWfListCnt > llngCnt
            
                With ltypLotmoveinfo.typMoveInfoWFList(llngCnt)
                    
                    '@書き込み行の設定
                    llngWriteRow = CMlngSlotMapRowS - CLng(.strSlotPosition)
                    
                    '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝがNULLか
                    If .strToCarrySlotPosition = vbNullString Then

                        vsfSlotMap.SetData(llngWriteRow, CMlngColWFID, .strWfId)                      'WFID
                        vsfSlotMap.SetData(llngWriteRow, CMlngColToCarrySlotPosition, vbNullString)   'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                        Dim newStyle As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        cellRange = vsfSlotMap.GetCellRange(llngWriteRow, CMlngColWFID)
                        cellRange.Style = newStyle                  'WFID列の背景色：白

                        '@↓2019/12/31 (Tue) 15:05:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        vsfSlotMap.SetData(llngWriteRow, CMlngColGRB, .strGRBClass)                   'GRB
                        '@GRB背景色
                        newStyle = vsfSlotMap.Styles.Add("GRBColor" + llngWriteRow.ToString)
                        newStyle.BackColor = pubGRBBackColor(.strGRBClass, Color.White)
                        cellRange = vsfSlotMap.GetCellRange(llngWriteRow, CMlngColGRB)
                        cellRange.Style = newStyle
                        '@↑2019/12/31 (Tue) 15:05:34 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    Else
                        '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝがNULL以外の場合

                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColWFID, .strWfId)                                  'WFID
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColToCarrySlotPosition, .strToCarrySlotPosition)    'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                        Dim newStyle As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        cellRange = vsfSlotMapMove.GetCellRange(llngWriteRow, CMlngColWFID)
                        cellRange.Style = newStyle                              'WFID列の背景色：白

                        '@↓2019/12/31 (Tue) 15:05:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColGRB, .strGRBClass)               'GRB
                        '@GRB背景色
                        newStyle = vsfSlotMapMove.Styles.Add("GRBColor" + llngWriteRow.ToString)
                        newStyle.BackColor = pubGRBBackColor(.strGRBClass, Color.White)
                        cellRange = vsfSlotMapMove.GetCellRange(llngWriteRow, CMlngColGRB)
                        cellRange.Style = newStyle
                        '@↑2019/12/31 (Tue) 15:05:34 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        '@移載先ｷｬﾘｱIDがNULLか
                        If lblCarrierMove.Text = vbNullString Then
                            
                            '@移載先ｷｬﾘｱIDをｾｯﾄ
                            lblCarrierMove.Text = .strToCarrierId
                        End If
                        
                        '@移載先ﾛｯﾄIDがNULLか
                        If lblLotID.Text = vbNullString Then
                            
                            '@移載先ﾛｯﾄIDをｾｯﾄ
                            lblLotID.Text = .strDivideCombineLotID
                        End If
                        
                        '@移載先流動区分がNULLか
                        If lblFlowClass.Text = vbNullString Then
                            
                            '@移載先流動区分をｾｯﾄ
                            lblFlowClass.Text = .strToFlowClass
                        End If
                        
                    End If

                    '@ｶｳﾝﾄｱｯﾌﾟ
                    llngCnt = llngCnt + 1

                End With
            Loop
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMapCombine_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMapScrap_Disp
    '機　能：不良/払出/保留時ｽﾛｯﾄﾏｯﾌﾟ表示処理
    '引　数：ltypLotmoveinfo    ：ﾛｯﾄ移載情報取得構造体
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 12:37:00 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvVsfSlotMapScrap_Disp(ByRef ltypLotmoveinfo As Lotmoveinfo)

        Dim llngCnt         As Integer      'ｶｳﾝﾄ数
        Dim llngWriteRow    As Integer      '書き込み行
        Dim cellRange       As CellRange

        Try

            '@-----------------------
            '@ 移載元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
                
                '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更(移載元)
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                '@↓2019/12/31 (Tue) 15:07:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                'cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColGRB)
                '@↑2019/12/31 (Tue) 15:07:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                cellRange.Style = newStyle
            End With

            '@-----------------------
            '@ 移載先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapMove
                
                '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更(移載先)
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                '@↓2019/12/31 (Tue) 15:07:45 Y.Yoneyama 「.Netへ反映未」 **************************************************
                'cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColGRB)
                '@↑2019/12/31 (Tue) 15:07:45 Y.Yoneyama 「.Netへ反映未」 **************************************************
                cellRange.Style = newStyle
            End With


            For llngCnt = 1 To CMlngSlotMapRowS - 1
                
                '@ｽﾛｯﾄ№がｽﾛｯﾄｻｲｽﾞ以内か
                If ltypLotmoveinfo.strSlotSize < CMlngSlotMapRowS - llngCnt Then
                    
                    '@ｽﾛｯﾄ№の初期化
                    vsfSlotMap.SetData(llngCnt, CMlngColSlot, vbNullString)
                    vsfSlotMapMove.SetData(llngCnt, CMlngColSlot, vbNullString)
                    
                    '@背景色の初期化
                    '@WFID
                    '@GRB
                    Dim newStyle1 As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                    newStyle1.BackColor = SystemColors.ControlLight
                    '@↓2019/12/31 (Tue) 15:08:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    'cellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID)
                    cellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColGRB)
                    '@↑2019/12/31 (Tue) 15:08:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    cellRange.Style = newStyle1
                    Dim newStyle2 As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                    newStyle2.BackColor = SystemColors.ControlLight
                    '@↓2019/12/31 (Tue) 15:08:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    'cellRange = vsfSlotMapMove.GetCellRange(llngCnt, CMlngColWFID)
                    cellRange = vsfSlotMapMove.GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColGRB)
                    '@↑2019/12/31 (Tue) 15:08:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    cellRange.Style = newStyle2
                End If
            Next llngCnt

            '@WF枚数分ﾙｰﾌﾟ
            llngCnt = 0
            
            Do While ltypLotmoveinfo.lngWfListCnt > llngCnt
            
                With ltypLotmoveinfo.typMoveInfoWFList(llngCnt)
                    
                    '@書き込み行の設定
                    llngWriteRow = CMlngSlotMapRowS - CLng(.strSlotPosition)
                    
                    '@WF状態が"良品"か
                    If .strWFStatus = CPstrClass1J Then

                        vsfSlotMap.SetData(llngWriteRow, CMlngColWFID, .strWfId)                      'WFID
                        vsfSlotMap.SetData(llngWriteRow, CMlngColToCarrySlotPosition, vbNullString)   'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                        Dim newStyle As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        cellRange = vsfSlotMap.GetCellRange(llngWriteRow, CMlngColWFID)
                        cellRange.Style = newStyle                  'WFID列の背景色：白

                        '@↓2019/12/31 (Tue) 15:05:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        vsfSlotMap.SetData(llngWriteRow, CMlngColGRB, .strGRBClass)                   'GRB
                        '@GRB背景色
                        newStyle = vsfSlotMap.Styles.Add("GRBColor" + llngWriteRow.ToString)
                        newStyle.BackColor = pubGRBBackColor(.strGRBClass, Color.White)
                        cellRange = vsfSlotMap.GetCellRange(llngWriteRow, CMlngColGRB)
                        cellRange.Style = newStyle
                        '@↑2019/12/31 (Tue) 15:05:34 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    Else
                        '@WF状態が"良品"以外の場合

                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColWFID, .strWfId)                          'WFID
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColToCarrySlotPosition, .strSlotPosition)   'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                        Dim newStyle As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        cellRange = vsfSlotMapMove.GetCellRange(llngWriteRow, CMlngColWFID)
                        cellRange.Style = newStyle                      'WFID列の背景色：白

                        '@↓2019/12/31 (Tue) 15:05:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColGRB, .strGRBClass)               'GRB
                        '@GRB背景色
                        newStyle = vsfSlotMapMove.Styles.Add("GRBColor" + llngWriteRow.ToString)
                        newStyle.BackColor =  pubGRBBackColor(.strGRBClass, Color.White)
                        cellRange = vsfSlotMapMove.GetCellRange(llngWriteRow, CMlngColGRB)
                        cellRange.Style = newStyle
                        '@↑2019/12/31 (Tue) 15:05:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
  
                        '@移載先ｷｬﾘｱIDがNULLか
                        If lblCarrierMove.Text = vbNullString Then
                            
                            '@移載先ｷｬﾘｱIDをｾｯﾄ
                            lblCarrierMove.Text = .strToCarrierId
                        End If
                        
                    End If
                
                    '@ｶｳﾝﾀを+1する
                    llngCnt = llngCnt + 1

                End With
            Loop
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMapScrap_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWfCarryFlag0_Proc
    '機　能：移載不要時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/08 (Tue) 12:48:57 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvWfCarryFlag0_Proc(Optional ByVal lblnFocus As Boolean = True)

        Try
            
            '@表示ﾒｯｾｰｼﾞ変換
            '@"<TRM66I>$$このキャリア[%1]は移載予約されていません。"のﾒｯｾｰｼﾞ表示
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0066, txtCarrier.Text)
            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
            If lblnFocus Then
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
            
                '@ｷｬﾘｱIDのﾊｲﾗｲﾄ処理
                Call pubHighlight(txtCarrier)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWfCarryFlag0_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWfCarryFlag1_Proc
    '機　能：移載元ｷｬﾘｱIDﾌｫｰｶｽﾛｽﾄ時、WF移載ﾌﾗｸﾞが1(移載必要)の場合の処理
    '引　数：ltypLotmoveinfo    ：ﾛｯﾄ移載情報取得構造体
    '戻り値：なし
    '作成日：2004/06/08 (Tue) 12:48:57 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2004/09/01 (Wed) 15:45:08 N.Kasai      移載の条件判定を削除(ｷｬﾘｱID入力時、ｻｰﾊﾞで行う為、ｸﾗｲｱﾝﾄでは必要なし)
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvWfCarryFlag1_Proc(ByRef ltypLotmoveinfo As Lotmoveinfo, Optional ByVal lblnFocus As Boolean = True)

        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim lblnCombineJudgeFlag    As Boolean      '統合判定ﾌﾗｸﾞ(True：統合処理、False：統合処理以外)

        Try
            
            '@★ ﾛｯﾄｲﾍﾞﾝﾄIDにより処理分岐 ★
            Select Case mstrLotEventID
            
                '@〓 10：分割 〓
                Case CMlngLotEventIDD
                    
                    '@=======================
                    '@ 分割時ｽﾛｯﾄﾏｯﾌﾟ表示処理
                    '@=======================
                    Call prvVsfSlotMapDivide_Disp(ltypLotmoveinfo)
                    
                    '@移載区分に"分割"を表示
                    lblMoveClass.Text = CMstrDivide
                    
                    With ltypLotmoveinfo

                        For llngCnt = 0 To .lngWfListCnt - 1
                            
                            '@分割/統合先ﾛｯﾄIDがNULL以外か
                            If .typMoveInfoWFList(llngCnt).strDivideCombineLotID <> vbNullString Then
                                Exit For
                            End If
                        Next llngCnt
                    End With


                '@〓統合〓
                Case CMlngLotEventIDC
                    
                    With ltypLotmoveinfo
                        
                        '@統合判定ﾌﾗｸﾞの初期化
                        lblnCombineJudgeFlag = False

                        For llngCnt = 0 To .lngWfListCnt - 1
                            
                            '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝがNULL以外か
                            If .typMoveInfoWFList(llngCnt).strToCarrySlotPosition <> vbNullString Then

                                '@統合判定ﾌﾗｸﾞに"True：統合処理"をｾｯﾄ
                                lblnCombineJudgeFlag = True
                                Exit For
                            End If
                        Next llngCnt

                        For llngCnt = 0 To .lngWfListCnt - 1
                            
                            '@分割/統合先ﾛｯﾄIDがNULL以外か
                            If .typMoveInfoWFList(llngCnt).strDivideCombineLotID <> vbNullString Then
                                Exit For
                            End If
                        Next llngCnt
                    End With
                    
                    '@統合判定ﾌﾗｸﾞが"True：統合処理"か
                    If lblnCombineJudgeFlag = True Then
                        
                        '@=======================
                        '@ 統合時ｽﾛｯﾄﾏｯﾌﾟ表示処理
                        '@=======================
                        Call prvVsfSlotMapCombine_Disp(ltypLotmoveinfo)
                        
                        '@移載区分に"統合"をｾｯﾄ
                        lblMoveClass.Text = CMstrCombine

                    Else
                        '@統合判定ﾌﾗｸﾞが"False：統合処理以外"の場合
            
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM59I>$$このキャリア[%1]は統合元に指定できません。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0059, txtCarrier.Text)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                        If lblnFocus Then
                            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtCarrier)
                        
                            '@ｷｬﾘｱIDのﾊｲﾗｲﾄ処理
                            Call pubHighlight(txtCarrier)
                        End If

                    End If
                    
                    
                '@〓 その他：不良/払出/保留 〓
                Case Else

                    '@=======================
                    '@ 不良/払出/保留時ｽﾛｯﾄﾏｯﾌﾟ表示処理
                    '@=======================
                    Call prvVsfSlotMapScrap_Disp(ltypLotmoveinfo)
                    
                    '@移載区分に"不良/払出/保留"をｾｯﾄ
                    lblMoveClass.Text = CMstrScrap

            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWfCarryFlag1_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmdRegist_Chk
    '機　能：確定ﾎﾞﾀﾝ有効/無効制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/11 (Wed) 18:04:47 Y.Yamagishi
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvcmdRegist_Chk(Optional ByVal lblnFocus As Boolean = True)
        
        Dim lblnButtonEnableFlag    As Boolean      '確定ﾎﾞﾀﾝ有効判定ﾌﾗｸﾞ(True：有効、False：無効)
        Dim llngCnt                 As Integer      'ｶｳﾝﾄ

        Try
            
            '@確定ﾎﾞﾀﾝ有効判定ﾌﾗｸﾞの初期化
            lblnButtonEnableFlag = False
            
            '@移載区分が"不良/払出/保留"か
            If lblMoveClass.Text = CMstrScrap Then
                
                '@移載先ｷｬﾘｱIDがNULL以外か
                If lblCarrierMove.Text <> vbNullString Then
                    
                    '@確定ﾎﾞﾀﾝ有効判定ﾌﾗｸﾞに"True：有効"をｾｯﾄ
                    lblnButtonEnableFlag = True
                End If
            Else
                '@移載区分が"不良/払出/保留"以外か

                '@移載先ｷｬﾘｱID、移載先ﾛｯﾄIDがNULL以外か
                If lblCarrierMove.Text <> vbNullString And _
                    lblLotIDMove.Text <> vbNullString Then
                    
                    '@確定ﾎﾞﾀﾝ有効判定ﾌﾗｸﾞに"True：有効"をｾｯﾄ
                    lblnButtonEnableFlag = True
                End If
            End If


            '@'@確定ﾎﾞﾀﾝ有効判定ﾌﾗｸﾞが"True：有効"か(第一関門突破!!)
            If lblnButtonEnableFlag = True Then
                
                '@確定ﾎﾞﾀﾝ有効判定ﾌﾗｸﾞの初期化(第二関門)
                lblnButtonEnableFlag = False
                
                '@ｶｳﾝﾀの初期化
                llngCnt = 1
                
                Do While CMlngSlotMapRowS - 1 >= llngCnt
                    
                    '@移載先ｽﾛｯﾄﾏｯﾌﾟにWFがあるか
                    If vsfSlotMapMove.GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        
                        '@確定ﾎﾞﾀﾝ有効判定ﾌﾗｸﾞに"True：有効"をｾｯﾄ(第二関門突破!!)
                        lblnButtonEnableFlag = True
                        Exit Do
                    End If
                    
                    '@ｶｳﾝﾀを+1する
                    llngCnt = llngCnt + 1
                Loop
            End If


            '@'@確定ﾎﾞﾀﾝ有効判定ﾌﾗｸﾞが"False：無効"か
            If lblnButtonEnableFlag = False Then
                
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            '@確定ﾎﾞﾀﾝを有効にし、ﾌｫｰｶｽｾｯﾄ
            cmdRegist.Enabled = True
            If lblnFocus Then
                Call pubSetFocus(cmdRegist)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnRegist_Chk
    '機　能：確定時ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2004/04/15 (Thu) 14:51:04 K.Takano
    '更新日：2009/08/12 (Wed) 17:49:49 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Function prvblnRegist_Chk() As Boolean

        Try
            
            '@戻り値の初期化
            prvblnRegist_Chk = False
            
            '@-----------------------
            '@ ｷｬﾘｱID関連ﾁｪｯｸ
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
            
            '@ｷｬﾘｱIDが6桁以外か
            If Len(txtCarrier.Text) <> CMlngMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@移載先ｷｬﾘｱIDがNULLか
            If lblCarrierMove.Text = vbNullString Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
                    
            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblnRegist_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRegist_Chk"
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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraLot.Paint, fraLot2.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfSlotMap.BeforeDoubleClick, vsfSlotMapMove.BeforeDoubleClick

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
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmdClose.Enter, _
            cmdRegist.Enter, vsfSlotMap.Enter, vsfSlotMapMove.Enter, txtCarrier.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '自動Validate = OFF
            Case cmdClose.Name, cmdRegist.Name
                Me.AutoValidate = AutoValidate.Disable

            '自動Validate = ON
            Case Else
                Me.AutoValidate = AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
