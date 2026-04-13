'ﾌｧｲﾙ名：xxEN0100.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット次工程送出　メインフォーム
'作成日：2004/03/23 (Tue) 08:25:18 T.Sawaguchi
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0100
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0100    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0100
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0100
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0100)
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

    '======================================Private===========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                 As String = "15.00"


    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN0100

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 13:03:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer              As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer              As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 13:03:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_nextsteplistVer          As String = "03.01"            'ﾛｯﾄ次工程取得
    Private Const CMstrlot_nextSendVer              As String = "03.03"            'ﾛｯﾄ次工程送出

    Private Const CMstrlot_chkchangeorderVer        As String = "01.00"            '量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
    Private Const CMstrlot_detail__Ver              As String = "03.00"            'ﾛｯﾄ詳細情報
    Private Const CMstrlot_chkeasycombineVer        As String = "01.00"            '簡易統合可否ﾁｪｯｸ
    Private Const CMstrctl_updwaitinglotVer         As String = "01.01"            '処理待ちﾛｯﾄ更新
    Private Const CPstrlot_cfend___Ver              As String = "02.00"            'CFﾛｯﾄ終了
	Private Const CMstrlot_afterjrsvcompletechkVer  As String = "01.00"			　　'蒸着後流動予約完了確認

    Private Const CMlngStsBarIndex                  As Integer = 1                 'ｽﾃｰﾀｽﾊﾞｰの表示ｲﾝﾃﾞｯｸｽ
    Private Const CMlngCarrierMaxLength             As Integer = 6                 'ｷｬﾘｱIDの最大桁数
    Private Const CMlngNextStepListIndex            As Integer = 1                 'LIST表示用ｲﾝﾃﾞｯｸｽ

    '@ｸﾞﾘｯﾄﾞの初期値定数宣言
    Private Const CMstrGridFontName                 As String = "ＭＳ ゴシック"    'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄ名
    Private Const CMlngGridFontSize                 As Integer = 11                'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngGridFixedCols                As Integer = 0                 'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngGridFixedRows                As Integer = 1                 'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngGridTitleHeight              As Integer = 20                'ﾍｯﾀﾞｰの高さ
    Private Const CMlngGridRowHeight                As Integer = 18                '1明細の高さ
    Private Const CMlngGridPageRows                 As Integer = 7                 '1ﾍﾟｰｼﾞのｾﾙの行数
    Private Const CMlngGrid3DBlank                  As Integer = 3                 'ｸﾞﾘｯﾄﾞの3D表示の余白
    Private Const CMlngScrollButtonSize             As Integer = 49                'ｽｸﾛｰﾙﾎﾞﾀﾝのｻｲｽﾞ

    Private Const CMlngGridRowTitle                 As Integer = 0                 'ﾀｲﾄﾙ行(行)
    Private Const CMstrDefaultStep                  As String = "○"               'ﾃﾞﾌｫﾙﾄ小工程
    Private Const CMstrDaitaiStep                   As String = "　"               '代替小工程

    '@ｸﾞﾘｯﾄﾞの定数宣言（ColWidth）
    Private Const CMlngGridColWidthOpID             As Integer = 200               '大工程ID
    Private Const CMlngGridColWidthStepID           As Integer = 200               '小工程ID
    Private Const CMlngGridColWidthDefault          As Integer = 67                'ﾃﾞﾌｫﾙﾄ
    Private Const CMlngGridColWidthWPID             As Integer = 272               'WPID

    '@vsfNextStepInfoの定数宣言(ｶﾗﾑ)
    Private Const CMlngNextStepInfoColOpID          As Integer = 0                 '大工程ID
    Private Const CMlngNextStepInfoColStepID        As Integer = 1                 '小工程ID
    Private Const CMlngNextStepInfoColDefault       As Integer = 2                 'ﾃﾞﾌｫﾙﾄ
    Private Const CMlngNextStepInfoColWPID          As Integer = 3                 'WPID

    '@ｸﾞﾘｯﾄﾞの幅
    Private Const CMlngGridWidth                    As Integer = CMlngGridColWidthOpID _
                                                    + CMlngGridColWidthStepID _
                                                    + CMlngGridColWidthDefault _
                                                    + CMlngGridColWidthWPID _
                                                    + CMlngGrid3DBlank 
    '@ｸﾞﾘｯﾄﾞの高さ
    Private Const CMlngGridHeight                   As Integer = (CMlngGridTitleHeight _
                                                    * CMlngGridFixedRows) _
                                                    + (CMlngGridRowHeight _
                                                    * CMlngGridPageRows) _
                                                    + CMlngGrid3DBlank

    '@vsfNextStepInfoの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrNextStepInfoColTOpID         As String = "次大工程"         '大工程ID
    Private Const CMstrNextStepInfoColTStepID       As String = "次小工程"         '小工程ID
    Private Const CMstrNextStepInfoColTDefault      As String = "ﾃﾞﾌｫﾙﾄ"           'ﾃﾞﾌｫﾙﾄ
    Private Const CMstrNextStepInfoColTWPID         As String = "装置名"           'WPID

    '@簡易統合チェック
    Private Const CMlngLeftLength                   As Integer = 7                 'ﾛｯﾄID比較文字数
    Private Const CMlngCarrierIDLeftStr             As Integer = 1                 '仮想ｷｬﾘｱ識別文字列抽出番号
    Private Const CMstrCarrierIDLeftStrI            As String = "I"                '仮想ｷｬﾘｱ識別文字列

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '======================================Private==========================================
    Private mstrLotLastUpdate                       As String                      'ﾛｯﾄ最終更新日時
    Private mstrCarrier                             As String                      'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mlngTopRow                              As Short                       'ﾍﾟｰｼﾞ先頭行
    Private mblnLotLastStep                         As Boolean                     '最終工程ﾌﾗｸﾞ(True：最終工程、False：次工程あり)
    Private mblnTakeOverDispFlg                     As Boolean                     '引継ぎ表示ﾌﾗｸﾞ
    '@↓2012/09/20 (Thu) 14:01:02 T.Oide **************************************************
    Private mblnCfkiFlg                             As Boolean                     'CFKIﾌﾗｸﾞ(True：CFKI、False：CFKI以外)
    '@↑2012/09/20 (Thu) 14:01:02 T.Oide **************************************************
    Private mstrDivLotID                            As String                      '分割LotID(親、子)
    Private mstrDivCarrier                          As String                      '分割Lotが入ったｷｬﾘｱID(親、子)
    Private mstrResult                              As String                      '簡易統合可否
	Private mstrEqType								As String
    Private buttonProcessing                        As Boolean                     'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                     'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                     'NSYS WindowCloseフラグ

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
        pubVsfMouseWheelManager_Set(vsfNextStepInfo, cmdNextUP, cmdNextDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：Form_Load
    '機　能：ACT初期設定および初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 08:33:31 T.Sawaguchi
    '更新日：2004/03/23 (Tue) 08:33:31
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns             As Boolean      '戻り値

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@簡易統合制御
            If pstrSBID = CPstrSBID2A0 Then
				'蒸着治具紐付け機能改修により不要になったため無効に設定
                cmdEasyComb.Visible = False
                cmdEasyComb.Enabled = False
            End If
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0100, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                
                '@=======================
                '@　ﾌｫｰﾑ終了時処理
                '@=======================
                Call Form_QueryUnload(False, New FormClosingEventArgs(CloseReason.UserClosing,  False))
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN0100_Init()
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
            Call prvfrmxxEN0100_CmbInit(False)
            
            '@次工程表示LISTの初期化
            Call prvVsfNextStepInfo_Init()
            
            '@ｷｬﾘｱIDのｸﾘｱ
            txtCarrier.Text = vbNullString
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            '@簡易統合中のﾛｯﾄは再読込をかける
            If pblnfrmxxEN0100kbn And txtCarrier.Text <> vbNullString Then
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
            End If
            
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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 15:17:35 H.Wajima
    '更新日：2004/07/27 (Tue) 15:17:35
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

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

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            'NSYS 表示位置設定
            Me.Left = 0 - My.Settings.FormOffset
            Me.Top = 0

            '@引数のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合
                '@ｷｬﾘｱIDの初期値を設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId

                '@ｷｬﾘｱ情報を取得する
                RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
            Else
            '@空白の場合
                '@ｷｬﾘｱID初期化
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 19:03:19 T.Sawaguchi
    '更新日：2004/03/23 (Tue) 19:03:19
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

            '@ｸﾞﾘｯﾄﾞ共通関数のKeyDown処理を実行する
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfNextStepInfo, cmdNextUP, cmdNextDown)

            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                '@ﾌｫｰｶｽがｷｬﾘｱIDにある場合
                    If ActiveControl.Name = "txtCarrier" Then
                        '@明細を表示する
                        RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                        Call txtCarrier_Validate(txtCarrier,New CancelEventArgs(False))
                        AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                        Exit Sub
                    End If
                               
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel    ：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 19:05:31 T.Sawaguchi
    '更新日：2004/11/01 (Mon) 16:28:47 T.Kitagawa
    '備　考：2004/11/01 (Mon) 16:28:47 T.Kitagawa　閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            '@呼び出しﾁｪｯｸﾌﾗｸﾞを戻す
            If pblnfrmxxEN0100kbn Then
                pstrLotID = vbNullString
                pstrToCarrierID = vbNullString
                pblnfrmxxEN0100kbn = False
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
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
    '作成日：2004/03/23 (Tue) 19:05:04 T.Sawaguchi
    '更新日：2018/11/19 (Mon) 10:01:29 Y.Yoneyama
    '備　考：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
    '      ：2018/11/19 (Mon) 10:01:29 Y.Yoneyama   防湿ALD対応
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
            
            mblnWindowClose = True

            '@引継ぎ情報のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合
                '@装置別ﾛｯﾄ一覧から引き継いで起動された場合
                If pblnfrmxxEN0150Kbn = True Then
                    '@装置別ﾛｯﾄ一覧を起動する
                    Call pubMenuSelect_Proc(CPstrKeyEN0150)
        '@↓2018/11/19 (Mon) 10:01:29 Y.Yoneyama **************************************************
                '@装置別ﾛｯﾄ一覧(防湿ALD)から引き継いで起動された場合
                ElseIf pblnfrmxxEN0151Kbn = True Then
                    '@装置別ﾛｯﾄ一覧を起動する
                    Call pubMenuSelect_Proc(CPstrKeyEN0151)
        '@↑2018/11/19 (Mon) 10:01:29 Y.Yoneyama **************************************************
                Else
                    '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧から引き継いで起動された場合
                    If pblnfrmxxEN00J0Kbn = True Then
                        '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧を起動する
                        Call pubMenuSelect_Proc(CPstrKeyEN00J0)
                    Else
                    '@工程別ﾛｯﾄ一覧から引き継いで起動された場合
                        '@工程別ﾛｯﾄ一覧を起動する
                        Call pubMenuSelect_Proc(CPstrKeyEN0200)
                    End If
                End If
            Else
            '@空白の場合
                '@終了関数を実行する
                Call publngEnd_Proc(CPstrKeyEN0100, ltypCommonInfo)
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

    '関数名：cmdProcEnd_Click
    '機　能：処理終了確定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 19:06:19 T.Sawaguchi
    '更新日：2018/03/02 (Fri) 16:27:27 T.Oide
    '備　考：
    Private Sub cmdProcEnd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdProcEnd.Click

        Dim lblnInputCheck              As Boolean              '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnAns                     As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrFormName                As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypLotCfEnd                As LotCfEnd             'CFﾛｯﾄ終了要求構造体
        Dim lstrActionFlag              As String               'ｱｸｼｮﾝ実行ﾌﾗｸﾞ
        Dim lstrSendResult              As String               '次工程送出結果格納(Null:次工程送出/0:中間在庫/1:完成在庫/2:組立送品)
        Dim lblnCtlAns                  As Boolean              'CtlSvr2結果取得(True:正常,False:異常)
        Dim ltypCtlUpdWaitingLotList    As CtlUpWaitingLot      'CtlSvr2送信構造体
        Dim lstrGuidMsg                 As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode             As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance            As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrDividedCheckFlag        As String               'ﾛｯﾄ分割確認要求ﾌﾗｸﾞ
        Dim llngMsgAns                  As Integer              'ﾎﾟｯﾌﾟｱｯﾌﾟ結果格納用
        Dim lblnChkChangeOrderAns       As Boolean              '量産ｵｰﾀﾞｰ振替ﾁｪｯｸ戻り値格納用
        Dim lstrComment                 As String               '次行程送出結果のｺﾒﾝﾄ格納

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@画面入力ﾁｪｯｸ
            lblnInputCheck = prvblnProcEndInput_Check
            If lblnInputCheck = False Then
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdProcEnd_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@最終工程以外か
            If mblnLotLastStep = False Then
                '@次工程ありの場合
                
                '@ﾛｯﾄ分割ﾁｪｯｸを無効化
                lstrDividedCheckFlag = CPstrEnableFlagFalse
                
                '@起動SBが組立か
                If pstrSBID = CPstrSBID2A0 Then
                    '@2A0：組立の場合
                    
                    '@=======================
                    '@ 量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
                    '@=======================
                    '@【量産ｵｰﾀﾞｰ振替ﾁｪｯｸ】ﾒｯｾｰｼﾞ送受信処理
                    lblnChkChangeOrderAns = pubblnLotChkChgOrder_Chk(CMstrlot_chkchangeorderVer, _
                                                                    lblLotID.Text, _
                                                                    lstrGuidMsg, _
                                                                    lstrGuidMsgCode)
            
                    '@量産ｵｰﾀﾞｰ振替ﾁｪｯｸ結果が"True：ﾁｪｯｸ処理成功"か
                    If lblnChkChangeOrderAns = True Then
            
                        '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞがNULL以外か
                        If lstrGuidMsgCode <> vbNullString Then
            
                            '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                            lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                               CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                               CPstrMsgCrCode & lstrGuidMsg
            
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「上記編集済みｶﾞｲﾀﾞﾝｽMsg」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        End If
                    End If


					'@=======================
                    '@ kkw 蒸着後流動予約ﾁｪｯｸ
                    '@=======================
                    '@【蒸着後流動予約情報取得】ﾒｯｾｰｼﾞ送受信処理
					If mstrEqType = CPstrEqTypeJyoucyaku Then
						Dim lstrCompleteChk As String
						lblnAns =  pubblnAfterJReserveCompleteChk(CMstrlot_afterjrsvcompletechkVer, lblLotID.Text, lstrCompleteChk)
						If lblnAns = True Then
							'蒸着後流動予約処理が完了していない場合(グループ内のWF全てが揃っていない場合）
							'ユーザーへ確認ﾒｯｾｰｼﾞ
							If lstrCompleteChk = CPstrFlagOff Then
								'@表示ﾒｯｾｰｼﾞ変換
								'@「 "<TRM198W>$$ロット[%1]は、蒸着後流動予約WFが揃っていません。$次工程送出を中止しますか？"」のﾒｯｾｰｼﾞ表示
								pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0198, lblLotID.Text)
								llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)
				
								'@ 「いいえ」なら処理を中断
								If llngMsgAns = vbNo Then
									Exit Sub
								End If

							End If
						End If
					End if
                End If
                
                '@CFKIの工程か
                If mblnCfkiFlg = True Then
                
                    '@CFの最終処理ﾒｯｾｰｼﾞ送信
                    With ltypLotCfEnd
                        .strEmpID = pstrUserID
                        .strLotID = lblLotID.Text
                        .strLotLastUpdate = mstrLotLastUpdate
                        .strMsgVer = CPstrlot_cfend___Ver
                        .strSbID = pstrSBID
                    End With
                    lblnAns = pubblnLotCfEnd_Upd(ltypLotCfEnd, lstrGuidMsg, lstrGuidMsgCode)
                    
                Else
                
                    '@通常の【次工程送出】ﾒｯｾｰｼﾞ送信
                    '@=======================
                    '@ 次工程送出(DIVIDED_CHECK_FLAG = 0)
                    '@ ※最終更新日時は、確定時に返される値を使う。ﾒｯｾｰｼﾞ関数内で書き換えている
                    '@=======================
        '@↓2018/03/02 (Fri) 16:36:26 T.Oide **************************************************
        '@            lblnAns = pubblnLotNextSend_Upd(CMstrlot_nextSendVer, _
        '@                                        lblLotID.Caption, _
        '@                                        mstrLotLastUpdate, _
        '@                                        pstrUserID, _
        '@                                        lstrDividedCheckFlag, , , , , _
        '@                                        lstrActionFlag, , _
        '@                                        lstrSendResult)
        '@--------------------------------------------------------------------------------------
                    lblnAns = pubblnLotNextSend_Upd(CMstrlot_nextSendVer, _
                                                lblLotID.Text, _
                                                mstrLotLastUpdate, _
                                                pstrUserID, _
                                                lstrDividedCheckFlag, , , lstrComment, , _
                                                lstrActionFlag, , _
                                                lstrSendResult)
        '@↑2018/03/02 (Fri) 16:36:26 T.Oide **************************************************
                                    
        '@↓2018/03/02 (Fri) 16:39:04 T.Oide**************************************************
        '@            '@表示ﾒｯｾｰｼﾞ変換("メッセージコード：C_I23%0$$次工程送出しました。ｷｬﾘｱ[ %1 ] ロット[ %2 ]")
        '@            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0023, txtCarrier.Text, lblLotID.Caption)
        '@--------------------------------------------------------------------------------------
                    '@ｺﾒﾝﾄは空か
                    If lstrComment = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換("メッセージコード：C_I23%0$$次工程送出しました。ｷｬﾘｱ[ %1 ] ロット[ %2 ]")
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0023, txtCarrier.Text, lblLotID.Text)
                    End If
        '@↑2018/03/02 (Fri) 16:39:04 T.Oide **************************************************
                
                End If

            Else
                '@最終工程の場合

                '@ﾛｯﾄ分割ﾁｪｯｸを有効化
                lstrDividedCheckFlag = CPstrEnableFlagTrue

                '@起動SBが組立か
                If pstrSBID = CPstrSBID2A0 Then
                    '@2A0：組立の場合

                    '@=======================
                    '@ 量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
                    '@=======================
                    '@【量産ｵｰﾀﾞｰ振替ﾁｪｯｸ】ﾒｯｾｰｼﾞ送受信処理
                    lblnChkChangeOrderAns = pubblnLotChkChgOrder_Chk(CMstrlot_chkchangeorderVer, _
                                                                    lblLotID.Text, _
                                                                    lstrGuidMsg, _
                                                                    lstrGuidMsgCode)
            
                    '@量産ｵｰﾀﾞｰ振替ﾁｪｯｸ結果が"True：ﾁｪｯｸ処理成功"か
                    If lblnChkChangeOrderAns = True Then
            
                        '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞがNULL以外か
                        If lstrGuidMsgCode <> vbNullString Then
            
                            '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                            lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                               CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                               CPstrMsgCrCode & lstrGuidMsg
            
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「上記編集済みｶﾞｲﾀﾞﾝｽMsg」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        End If
                    End If
                End If
                
                
                '@=======================
                '@ 次工程送出(DIVIDED_CHECK_FLAG = 1)
                '@=======================
                '@【次工程送出】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnLotNextSend_Upd(CMstrlot_nextSendVer, _
                                                lblLotID.Text, _
                                                mstrLotLastUpdate, _
                                                pstrUserID, _
                                                lstrDividedCheckFlag, _
                                                CPstrCD24, , , , _
                                                lstrActionFlag, , _
                                                lstrSendResult)
                '@結果判定
                If lblnAns = True Then

                    '@送出結果がTrueの場合の処理。
                    '@まず，(9：送品中断)かどうか先に判断する。
                    If lstrSendResult = CPstrSendAbort Then

                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(lstrFormName, lstrEventName)

                        '@「送品中断」の場合は，ﾎﾟｯﾌﾟｱｯﾌﾟ表示し，作業者に指示を仰ぐ。
                        '@表示ﾒｯｾｰｼﾞ変換("<TRM9JW>$$ロット[%1]は、ロット分割されています。ロット分割状態のまま送出しますか？")
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009J, lblLotID.Text)
                        llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)

                        '@「はい」なら分割状態で送品していいので，DIVIDED_CHECK_FLAG=0(ﾛｯﾄ分割ﾁｪｯｸ無し) とし，再度，ﾒｯｾｰｼﾞを発行する。
                        If llngMsgAns = vbYes Then

                            '@ﾛｯﾄ分割ﾁｪｯｸを無効化ｾｯﾄ
                            lstrDividedCheckFlag = CPstrEnableFlagFalse

                            '@起動SBが組立か
                            If pstrSBID = CPstrSBID2A0 Then
                                '@2A0：組立の場合

                                '@=======================
                                '@ 量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
                                '@=======================
                                '@【量産ｵｰﾀﾞｰ振替ﾁｪｯｸ】ﾒｯｾｰｼﾞ送受信処理
                                lblnChkChangeOrderAns = pubblnLotChkChgOrder_Chk(CMstrlot_chkchangeorderVer, _
                                                                                lblLotID.Text, _
                                                                                lstrGuidMsg, _
                                                                                lstrGuidMsgCode)
            
                                '@量産ｵｰﾀﾞｰ振替ﾁｪｯｸ結果が"True：ﾁｪｯｸ処理成功"か
                                If lblnChkChangeOrderAns = True Then
            
                                    '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞがNULL以外か
                                    If lstrGuidMsgCode <> vbNullString Then
            
                                        '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                                        lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                                           CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                                           CPstrMsgCrCode & lstrGuidMsg
            
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        '@「上記編集済みｶﾞｲﾀﾞﾝｽMsg」のﾒｯｾｰｼﾞ表示
                                        pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    End If
                                End If
                            End If
                            
                            
                            '@=======================
                            '@ 次工程送出(DIVIDED_CHECK_FLAG = 0)
                            '@=======================
                            '@【次工程送出】ﾒｯｾｰｼﾞ送受信処理
                            lblnAns = pubblnLotNextSend_Upd(CMstrlot_nextSendVer, _
                                                            lblLotID.Text, _
                                                            mstrLotLastUpdate, _
                                                            pstrUserID, _
                                                            lstrDividedCheckFlag, _
                                                            CPstrCD24, , , , _
                                                            lstrActionFlag, , _
                                                            lstrSendResult)

                            '@結果判定
                            If lblnAns = True Then
                                '@送出結果がTrueの場合に表示するﾒｯｾｰｼﾞを分ける
                                Call pubLotNextSendResultPopUp(lstrSendResult, txtCarrier.Text, lblLotID.Text)
                            
                            End If
                        Else
                            '@「いいえ」の場合は，処理中断させる
                            '@
                            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtCarrier)

                            Exit Sub

                        End If

                    Else
                    
                        '@肯定応答で，「搬送中断」以外の場合
                        '@
                        '@送出結果がTrueの場合に表示するﾒｯｾｰｼﾞを分ける
                        Call pubLotNextSendResultPopUp(lstrSendResult, txtCarrier.Text, lblLotID.Text)

                    End If
                End If
            End If


            '@次行程送出するか
            If lblnAns = True Then

                '@CFKIの工程か
                If mblnCfkiFlg = True Then
                
                    '@CFKI工程の場合
                    '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っている場合
                    If lstrGuidMsgCode <> vbNullString Then
                        '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                        lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                           CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                           CPstrMsgCrCode & lstrGuidMsg
                        
                        '@ﾒｯｾｰｼﾞ表示"<編集済みｶﾞｲﾀﾞﾝｽMsg"
                        pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                        '@ﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN0060.Instance.Text, True, 16)
                    End If
                    
                    '@pubVsfInfo_Disp("メッセージコード：C_I32%0$$ロット[ %2 ]終了しました。キャリア[ %1 ]")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0032, txtCarrier.Text, lblLotID.Text)
                
                Else
                    
                    '@通常の作業終了の場合
                    '@次工程送出結果格納(Null:次工程送出/0:中間在庫/1:完成在庫/2:組立送品)
                    '@次工程送出の場合のみ処理待ちﾛｯﾄ更新処理を行う
                    If lstrSendResult = vbNullString Then
                        '@更新処理の為送信構造体に状態をｾｯﾄする
                        With ltypCtlUpdWaitingLotList
                            .strClassDivision = CPstrCD01                                                       '処理区分(=01)
                            .strMsgVer = CMstrctl_updwaitinglotVer                                              'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                            .strSbID = pstrSBID                                                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                            .strWpID = vbNullString                                                             'WPID(=vbNullString)
                            .lngWaitingLotListCnt = 1                                                           'ﾘｽﾄｶｳﾝﾄ(=1)
                            
                            '@領域確保
                            If IsNothing(.typWaitingLotList) Then
                                .typWaitingLotList = New List(Of UpWaitingLotList)
                            Else
                                .typWaitingLotList.Clear()
                            End If

                            Dim typWaitingLotListTmp As UpWaitingLotList = New UpWaitingLotList
                                                            
                            typWaitingLotListTmp.strLotID = lblLotID.Text               'ﾛｯﾄID
                            typWaitingLotListTmp.strOpID = lblOpID.Text                 '大工程
                            typWaitingLotListTmp.strStepID = lblStepID.Text             '小工程
                            typWaitingLotListTmp.strSeqNum = vbNullString                '処理順(=vbNullString)

                            .typWaitingLotList.Add(typWaitingLotListTmp)
                        End With
                        
                        '@結果OKの場合,処理待ちﾛｯﾄ更新処理を行う
                        lblnCtlAns = pubblnCtlUpdWaitingLot_Upd(ltypCtlUpdWaitingLotList)
                        '@結果判定
                        If lblnCtlAns = False Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)
            
                            '@処理を終了させる
                            Exit Sub
                        End If
                    End If
                    
        '@↓2018/03/02 (Fri) 16:50:04 T.Oide **************************************************
                    '@送品中止の場合(ﾚｼﾋﾟ選択APCの測定行程ﾁｪｯｸNG)
                    If lstrSendResult = CPstrSendAbort And lstrComment <> vbNullString Then
                        '@ﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(lstrComment)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
        '@↑2018/03/02 (Fri) 16:50:04 T.Oide **************************************************
                    
                    '@ｽﾃｰﾀｽﾊﾞｰ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
            
                    '@表示ﾒｯｾｰｼﾞ初期化
                    pstrDMsg = vbNullString
            
                    '@ｱｸｼｮﾝﾌﾗｸﾞによる分岐
                    Select Case lstrActionFlag
                        '@停止の場合
                        Case CPstrActionFlag1
                            '@表示ﾒｯｾｰｼﾞ変換"<TRM2SI>$$アクション予約によりロット[ %1 ] は [停止] されました。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, lblLotID.Text, CPstrStopSt)
                        '@保留の場合
                        Case CPstrActionFlag2
                            '@表示ﾒｯｾｰｼﾞ変換"<TRM2SI>$$アクション予約によりロット[ %1 ] は [保留] されました。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, lblLotID.Text, CPstrHoldSt)
                    End Select
                    
                End If
                
                '@表示ﾒｯｾｰｼﾞがある場合
                If pstrDMsg <> vbNullString Then
                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                End If
                
                '@ｷｬﾘｱIDのｸﾘｱ
                txtCarrier.Text = vbNullString
                
                '@ﾛｯﾄ情報の初期化
                Call prvfrmxxEN0100_Init()
                
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                Call prvfrmxxEN0100_CmbInit(False)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdProcEnd_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 19:03:56 T.Sawaguchi
    '更新日：2004/03/23 (Tue) 19:03:56
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN0100_Init()
            
            '@ﾎﾞﾀﾝ状態
            Call prvfrmxxEN0100_CmbInit(False)
            
            '@LISTﾎﾞｯｸｽｸﾘｱ
            Call prvVsfNextStepInfo_Init()
            
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

    '関数名：cmdNextDown_Click
    '機　能：▼ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/27 (Fri) 12:07:15 N.Kasai
    '更新日：2004/08/27 (Fri) 12:07:15
    '備　考：
    Private Sub cmdNextDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNextDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞ共通関数の▼ﾎﾞﾀﾝ処理を実行する
            Call pubVsfCmdDown(vsfNextStepInfo, cmdNextUP, cmdNextDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNextDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNextUP_Click
    '機　能：▲ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/27 (Fri) 12:07:20 N.Kasai
    '更新日：2004/08/27 (Fri) 12:07:20
    '備　考：
    Private Sub cmdNextUP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNextUP.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞ共通関数の▲ﾎﾞﾀﾝ処理を実行する
            Call pubVsfCmdUp(vsfNextStepInfo, cmdNextUP, cmdNextDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNextUP_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdEasyComb_Click
    '機　能：簡易統合ﾎﾞﾀﾝ制御
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/29 (Mon) 19:04:41 K.Nishizawa
    '更新日：2004/06/29 (Mon) 19:04:41
    '備　考：
    Private Sub cmdEasyComb_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEasyComb.Click

        Dim ltypOldCommonInfo       As CommonInfo
        Dim lblnAns                 As Boolean
        Dim ltypLotCurState         As Lotprestate  '分割ロット情報

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '引継ぎ構造体の退避
            ltypOldCommonInfo = ptypCommonInfo
            
            With ptypCommonInfo
                .strCarrierId = txtCarrier.Text
                .strDivision = vbNullString
                .strLotID = vbNullString
                .strOpID = vbNullString
                .strStepID = vbNullString
                .strWpID = vbNullString
                .strWpName = vbNullString
                .strEqType = vbNullString
            End With

            '@ｷｬﾘｱIDが仮想ｷｬﾘｱID('1桁目が"I")かﾁｪｯｸ
            'If Strings.Left(txtCarrier.Text, CMlngCarrierIDLeftStr) = CMstrCarrierIDLeftStrI Then
            '    '@ｷｬﾘｱが"仮想ｷｬﾘｱ(左1桁が"I")"の場合はErrorを表示する
            '    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000P, txtCarrier.Text)
            '    '@ <TRM0OP>キャリア%1は仮想キャリアです。$別の分割ロットで簡易統合を実施して下さい。"
            '    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            '    cmdEasyComb.Enabled = False
            '    Exit Sub
            'End If
            '@分割子ﾛｯﾄが統合できるかﾁｪｯｸ
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD1B, mstrDivCarrier, ltypLotCurState)
            If Not lblnAns Then
                cmdEasyComb.Enabled = False
                Exit Sub
            End If
            '@ロットIDの確認
            If Strings.Left(lblLotID.Text, CMlngLeftLength) <> _
                        Strings.Left(mstrDivLotID, CMlngLeftLength) Then
                '@"<TRM0AW>$$分割元ロットが異なります。同一ロットから分割されたロットを統合してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000A)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                cmdEasyComb.Enabled = False
                Exit Sub
            End If
            '@"作業待ち"か"作業終了か確認
            If (lblStatus.Text <> CPstrWaitWorkSt And lblStatus.Text <> CPstrEndWorkSt) Or _
                (ltypLotCurState.strNowST <> CPstrWaitWorkSt And ltypLotCurState.strNowST <> CPstrEndWorkSt) Then
                '@"<TRM0DW>$$「作業待ち」、「作業終了」以外のロットは統合できません。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000D)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                cmdEasyComb.Enabled = False
                Exit Sub
            End If
            '@状態確認
            If (lblStatus.Text <> ltypLotCurState.strNowST) Then
                '@"<TRM4NW>$$ロット状態が異なります。同一状態でロットを統合してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004N)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                cmdEasyComb.Enabled = False
                Exit Sub
            End If
            '@小工程確認
            If (lblStepID.Text <> ltypLotCurState.strStepID) Then
                '@"<TRM0EW>$$小工程が異なります。同一小工程でロットを統合してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000E)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                cmdEasyComb.Enabled = False
                Exit Sub
            End If


            '分割子ﾛｯﾄの退避
            pstrLotID = mstrDivLotID
            pstrToCarrierID = mstrDivCarrier
            
            pblnfrmxxEN0100kbn = True
            
            '@ﾌｫｰﾑﾛｰﾄﾞ初期化
            pblnFormLoad = False
            
            '@ﾌｫｰﾑﾛｰﾄﾞ
            frmxxEN0161.Instance = New frmxxEN0161()
            
            If pblnFormLoad Then
                frmxxEN0161.Instance.ShowDialog(Me)
                frmxxEN0161.Instance = Nothing
            Else
                frmxxEN0161.Instance = Nothing
                ptypCommonInfo = ltypOldCommonInfo
                pstrLotID = vbNullString
                pstrToCarrierID = vbNullString
                pblnfrmxxEN0100kbn = False
                Exit Sub
            End If
            
            '@ﾌｫｰﾑﾛｰﾄﾞを戻す
            ptypCommonInfo = ltypOldCommonInfo
            pblnFormLoad = False

            '@統合画面からの呼び出しは再読込
            If pblnfrmxxEN0100kbn Then
                mstrCarrier = vbNullString
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
            End If
            
            'pblnfrmxxEN0100kbn = False
            
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

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '======================================Public===========================================

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱIDﾌｫｰｶｽ制御
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 19:04:41 T.Sawaguchi
    '更新日：2004/03/23 (Tue) 19:04:41
    '備　考：
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAns         As Boolean  '戻り値
        Dim lstrFormName    As String   'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName   As String   'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose Then
                Exit Sub
            End If
           
            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrier.Text) = vbNullString Then
                '@空ENTERの場合はﾌｫｰｶｽ移動
                If Not IsNothing(Me.ActiveControl) AndAlso Me.ActiveControl.Name = txtCarrier.Name Then
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then          
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                
                '@"ｷｬﾘｱIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを留める
                e.Cancel = True
                
                '@ﾌｫｰｶｽ関数設定
                If Not IsNothing(Me.ActiveControl) AndAlso Me.ActiveControl.Name = txtCarrier.Name Then
                    Call pubSetFocus(txtCarrier)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If txtCarrier.Text <> mstrCarrier Then
                '@ﾚｽﾎﾟﾝｽ取得開始
                lstrFormName = Me.Name
                lstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(lstrFormName, lstrEventName)
            
                '@情報取得処理
                lblnAns = txtCarrier_Enter(sender,New EventArgs)
                '@結果判定
                If lblnAns = False Then
                '@失敗の場合
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@ﾌｫｰｶｽを留める
                    e.Cancel = True
                    
                    '@ﾊｲﾗｲﾄ
                    Call pubHighlight(txtCarrier)
                    
                    '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ失敗時)
                    mstrCarrier = vbNullString
                    
                    Exit Sub
                End If

        '↓'09/06/29（Mon）15:21:22 K.Nishizawa **********************************************
                If mstrResult = CPstrOne Then
                    cmdEasyComb.Enabled = True
                Else
                    cmdEasyComb.Enabled = False
                End If
        '↑'09/06/29（Mon）15:21:22 K.Nishizawa **********************************************

                '@ｸﾞﾘｯﾄﾞ表示後処理
                Call pubVsfDisp(vsfNextStepInfo, cmdNextUP, cmdNextDown)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)

                '@CFKIのﾁｪｯｸ
                '@EQ_TYPEﾌﾗｸﾞを判定しCFKIの場合のみCFﾛｯﾄ確定可能ﾌﾗｸﾞを判定して確定ﾎﾞﾀﾝの使用可否を行う。
                With ptypLotprestate
                    '@CFKIの場合
                    If .strEqType = CPstrEqTypeCFKI Then
                        '@確定可否判定
                        If .strCfCompFlag = CPstrCOMP Then   '0；CFﾛｯﾄ確定不可　1；CFﾛｯﾄ確定可能
                            '@確定ﾎﾞﾀﾝ使用可
                            cmdProcEnd.Enabled = True
                        Else
                            '@確定ﾎﾞﾀﾝ使用不可
                            cmdProcEnd.Enabled = False
            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001K, txtCarrier.Text)
                            
                            '@"<TRM1KI>$$このｷｬﾘｱ[ %1 ]はCFKI作業終了入力が必要です。"
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                            
                            Exit Sub
                        End If
                    End If
                End With

                '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                mstrCarrier = txtCarrier.Text
            End If
            
            '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
            If Not IsNothing(Me.ActiveControl) AndAlso Me.ActiveControl.Name = txtCarrier.Name Then
                Call pubSetFocus(cmdProcEnd)
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

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvfrmxxEN0100_Init
    '機　能：ﾛｯﾄ情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 19:08:06 T.Sawaguchi
    '更新日：2008/06/11 (Wed) 14:15:35 N.Kojima
    '備　考：
    '　　　：2004/08/30 (Mon) 18:16:31 M.Miura　    ﾘﾜｰｸﾙｰﾄID追加(ﾘﾜｰｸ対応)
    '　　　：2004/10/04 (Mon) 13:55:21 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/10/18 (Mon) 13:14:18 M.Miura　    ﾘﾜｰｸﾙｰﾄIDの削除
    '　　　：2008/06/11 (Wed) 14:15:35 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2012/09/20 (Thu) 14:02:04 T.Oide       CFKIの作業終了でアクション予約等で保留が掛かった場合の対応
    Private Sub prvfrmxxEN0100_Init()
        
        Dim lstrFormTitle   As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0100, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            '@ﾎﾞﾀﾝの非表示化                                         '簡易統合
            '@各ｺﾝﾄﾛｰﾙの初期化
            lblLotID.Text = vbNullString                             'ﾛｯﾄID
            lblFlowClass.Text = vbNullString                         '流動区分
            lblWFNo.Text = vbNullString                              'FW枚数
            lblOpID.Text = vbNullString                              '大工程ID
            lblStartDayTime.Text = vbNullString                      '開始日時
            lblPdID.Text = vbNullString                              '機種名
            lblS.Text = vbNullString                                 '特殊特性
            lblStatus.Text = vbNullString                            '状態
            lblStepID.Text = vbNullString                            '小工程ID
            lblLotManager.Text = vbNullString                        'ﾛｯﾄ担当
            lblTimeLimit.Text = vbNullString                         '時間制約
            '@↓2019/12/27 (Fri) 15:31:09 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString                               'GRB
            lblGRB.BackColor = lblPdID.BackColor
            '@↑2019/12/27 (Fri) 15:31:09 Y.Yoneyama 「.Netへ反映未」 **************************************************
            mstrLotLastUpdate = vbNullString                         'ﾛｯﾄ最終更新日時
            mstrCarrier = vbNullString                               'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
            mstrDivLotID = vbNullString                              '分割LOTID
			mstrEqType = vbNullString
            vsfNextStepInfo.Enabled = False

            '@次工程ｸﾞﾘｯﾄﾞの初期化
            Call prvVsfNextStepInfo_Init()
            
            '@CFKIﾌﾗｸﾞの初期化
            mblnCfkiFlg = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0100_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0100_CmbInit
    '機　能：確定ﾎﾞﾀﾝの制御
    '引　数：lblnEnable：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 09:31:29 T.Sawaguchi
    '更新日：2004/03/23 (Tue) 09:31:29
    '備　考：
    Private Sub prvfrmxxEN0100_CmbInit(Optional ByVal lblnEnable As Boolean = False)

        Try
            
            '@各ｺﾏﾝﾄﾞﾎﾞﾀﾝのｺﾝﾄﾛｰﾙ
            cmdProcEnd.Enabled = lblnEnable             '確定ﾎﾞﾀﾝ

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0100_CmbInit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0100_Disp
    '機　能：画面の表示
    '引　数：ltypLotprestate：ﾛｯﾄ現在状態取得構造体
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 09:32:18 T.Sawaguchi
    '更新日：2008/06/11 (Wed) 14:16:10 N.Kojima
    '備　考：
    '　　　：2004/08/25 (Wed) 14:15:30 N.Kasai      CFﾌﾗｸﾞ判定追加、"mm/dd hh:mm:ss"を共通変数化
    '　　　：2004/08/30 (Mon) 18:21:53 M.Miura      ﾘﾜｰｸﾙｰﾄIDを追加(ﾘﾜｰｸ対応)
    '　　　：2004/09/09 (Thu) 20:20:01 Y.Yamagishi　時間制限表示変更(不具合改善№693)
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima　   数量表示(TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2004/09/24 (Fri) 11:25:30 Y.Yamagishi  制限時間以上の場合文字色を青に変更(不具合改善№825)
    '　　　：2004/10/18 (Mon) 13:28:05 M.Miura      ﾘﾜｰｸﾙｰﾄIDを削除
    '　　　：2005/05/26 (Thu) 15:12:05 N.Kasai      LP_FLAG判定追加
    '　　　：2006/06/08 (Thu) 15:09:05 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/11 (Wed) 14:16:10 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2012/09/20 (Thu) 13:59:10 T.Oide       CFKIの作業終了でアクション予約等で保留が掛かった場合の対応
    Private Sub prvfrmxxEN0100_Disp(ByRef ltypLotprestate As Lotprestate)

        Try
            
            '@ﾛｯﾄ情報の表示
            With ltypLotprestate
                lblLotID.Text = .strLotID                                            'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                    '流動区分
                lblOpID.Text = .strOpID                                              '大工程ID
                If IsDate(.strStartTime) Then
                    lblStartDayTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat)'開始日時 "MM/dd HH:mm:ss"
                Else
                    lblStartDayTime.Text = .strStartTime
                End If
                lblPdID.Text = .strPdId                                              '機種名
                lblS.Text = .strSpecialFlg                                           '特殊特性
                lblStatus.Text = .strNowST                                           '状態
                lblStepID.Text = .strStepID                                          '小工程ID
                lblLotManager.Text = .strEngEmpName                                  'ﾛｯﾄ担当
                '@↓2019/12/27 (Fri) 15:20:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                                           'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotManager.BackColor)
                '@↑2019/12/27 (Fri) 15:20:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
 
                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then
                    '@時間制約がﾌﾟﾗｽの場合
                    If CLng(.strLimitTime) >= 0 Then

                        '@制限時間以下or処理時間制限以下の場合
                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@制限時間先大工程+制限時間先小工程+制限時間
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            '@右寄せ
                            lblTimeLimit.TextAlign = ContentAlignment.MiddleRight
                            
                            '@警告時間が設定されている場合
                            If .strWarnTime <> vbNullString Then
                                '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                If CLng(.strWarnTime) < 0 And CLng(.strLimitTime) >= 0 Then
                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)    '紫色
                                Else
                                     '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                    lblTimeLimit.ForeColor = Color.Black    '黒
                                End If
                            End If
                        End If

                    Else
                        '@制限時間がﾏｲﾅｽの場合
                        '@制限時間先大工程+制限時間先小工程+制限時間
                        '@右寄せ
                        lblTimeLimit.TextAlign = ContentAlignment.MiddleRight
                        '@ForColorの変更
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)  '赤色
                        
                        '@制限時間以下or処理時間制限以下の場合
                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                        End If
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Replace(Format(CLng(.strLimitTime), CPstrDateFormatKanma), _
                                                           CPstrReplaceMinus, _
                                                           vbNullString) & CPstrh
                        End If
                    End If
                End If
 
                mstrLotLastUpdate = .strLotLastUpdate                                   'ﾛｯﾄ最終更新日時
            
                '@枚数表示判定(CF_FLAGを判定し、WF枚数とﾁｯﾌﾟ枚数の表示を切替)
                Select Case .strCfFlag
                    '@CFﾛｯﾄ
                    Case CPstrCF
                        '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                        If .strLpFlag = CPstrLP Then
                            '@大判の場合
                            lblWFNo.Text = .strWfNum                                               'WF枚数
                        Else
                            If IsNumeric(.strChipQuantity) Then
                                lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)  'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity
                            End If
                        End If 
                   '@CFﾛｯﾄ以外
                    Case Else
                        '@TPALﾛｯﾄ
                        If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                            lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)            'ﾁｯﾌﾟ枚数
                        Else
                            '@CF,TPALﾛｯﾄ以外
                            lblWFNo.Text = .strWfNum                                               'WF枚数
                        End If
                End Select
        '@↓2012/09/20 (Thu) 13:59:10 T.Oide **************************************************    
                '@装置ﾀｲﾌﾟがCFKIの場合
                If .strEqType = CPstrEqTypeCFKI Then
                    '@CFKIﾌﾗｸﾞ(有効)
                    mblnCfkiFlg = True
                Else
                    '@CFKIﾌﾗｸﾞ(無効)
                    mblnCfkiFlg = False
                End If
        '@↑2012/09/20 (Thu) 13:59:10 T.Oide **************************************************
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0100_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnProcEndInput_Check
    '機　能：入力確認
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/23 (Tue) 09:33:49 T.Sawaguchi
    '更新日：2004/10/18 (Mon) 13:10:57 M.Miura
    '備　考：2004/08/30 (Mon) 18:32:11 M.Miura  ﾘﾜｰｸ設定ﾁｪｯｸを追加(ﾘﾜｰｸ対応)
    '　　　：2004/10/18 (Mon) 13:10:57 M.Miura　ﾘﾜｰｸ設定ﾁｪｯｸを削除
    Private Function prvblnProcEndInput_Check() As Boolean

        Try
            
            '@初期化
            prvblnProcEndInput_Check = False
            
            '@ｷｬﾘｱIDの入力ﾁｪｯｸ
            If txtCarrier.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                
               '@"ｷｬﾘｱIDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Call pubSetFocus(txtCarrier)
                
                Exit Function
            End If
            
            '@ｷｬﾘｱIDが6桁であるかﾁｪｯｸ
            If Len(txtCarrier.Text) <> CMlngCarrierMaxLength Then         
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                
                '@"ｷｬﾘｱIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Call pubSetFocus(txtCarrier)
                
                Exit Function
            End If
            
            '@状態ﾁｪｯｸ
            If lblStatus.Text <> CPstrEndWorkSt Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0033)
                
                '@"「作業終了」以外のロットは次工程送出できません。”
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Call pubSetFocus(txtCarrier)
                
                Exit Function
            End If

            '@入力OK
            prvblnProcEndInput_Check = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnProcEndInput_Check"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：txtCarrier_Enter
    '機　能：ｷｬﾘｱID Enter処理
    '引　数：なし
    '戻り値：True：正常、False：エラー
    '作成日：2004/03/23 (Tue) 09:34:15 T.Sawaguchi
    '更新日：2004/03/23 (Tue) 09:34:15
    '備　考：
    Private Function txtCarrier_Enter(ByVal sender As Object, ByVal e As EventArgs) As Boolean 

        Dim ltypLotprestate         As Lotprestate          'ﾛｯﾄ情報格納構造体
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrLotCarrierID        As String               'ｷｬﾘｱID
        Dim lstrCarrierIDWk         As String               'ｷｬﾘｱID比較用
        Dim ltypLotNextStep         As LotNextStep          '次工程取得ﾃﾞｰﾀ格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

        Try
          
           
            txtCarrier_Enter = False
                
             '@ﾚｽﾎﾟﾝｽ情報格納
            lstrFormName = Me.Name
            lstrEventName = "txtCarrier_Enter"
            
           '@ｷｬﾘｱID取得
            lstrLotCarrierID = txtCarrier.Text
            
            '@ｷｬﾘｱIDが入力されている場合
            If lstrLotCarrierID <> vbNullString Then
                '@ｷｬﾘｱID比較用
                lstrCarrierIDWk = mstrCarrier
            
                '@次回ｷｬﾘｱID比較用
                mstrCarrier = txtCarrier.Text
                
                '@最終工程ﾌﾗｸﾞ(次工程あり)
                mblnLotLastStep = False
            
                '@ﾛｯﾄ情報の取得
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                CPstrCD16, _
                                                lstrLotCarrierID, _
                                                ltypLotprestate)
                '@結果判定
                If lblnAns = True Then
                    '@前回ｷｬﾘｱIDと違う場合
                    If lstrCarrierIDWk <> mstrCarrier Then
                        '@画面表示処理
                        Call prvfrmxxEN0100_Disp(ltypLotprestate)
                    End If
                    
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用可)
                    Call prvfrmxxEN0100_CmbInit(True)

                    '@結果OKをｾｯﾄ
                    txtCarrier_Enter = True

                    '@次工程情報取得
                    lblnAns = pubblnLotNextStepList_Sel(CMstrlot_nextsteplistVer, _
                                                        ltypLotprestate.strLotID, _
                                                        ltypLotprestate.strOpID, _
                                                        ltypLotprestate.strStepID, _
                                                        ltypLotNextStep)
                    '@取得に成功したら次工程を表示
                    If lblnAns = True Then
                        '@次工程が最終工程の場合の判定
                        With ltypLotNextStep
                            If .strNextStepList(0).strNextOpId = vbNullString And _
                                .strNextStepList(0).strNextStepId = vbNullString And _
                                .strNextStepList(0).strStepDivision = vbNullString Then
                            '@大工程、小工程、工程ﾌﾗｸﾞが空白の場合
                                
                                '@最終工程ﾌﾗｸﾞ(最終工程)
                                mblnLotLastStep = True
                            Else
                            '@大工程、小工程、工程ﾌﾗｸﾞが空白以外の場合
                                '@小工程名、装置名をｾｯﾄ
                                Call vsfNextStepInfo_Disp(ltypLotNextStep, ltypLotNextStep.lngNextStepListCnt)
                            End If
                        End With
                        
                    Else
                        '@確定ﾎﾞﾀﾝは使用不可
                        cmdProcEnd.Enabled = False

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)

                        '@失敗をｾｯﾄ
                        txtCarrier_Enter = False
                    End If

					mstrEqType = ltypLotprestate.strEqType

        '@ ↓'09/06/29（Mon） K.Nishizawa *******************************************************
                    If (ltypLotprestate.strVaFlag = CPstrOne And _
                            (ltypLotprestate.strEqType = CPstrEqTypeJyoucyaku Or _
                                ltypLotprestate.strEqType = CPstrEqTypeTPAL)) Then
                         
                        lblnAns = pubblnLotChkEasyCombine_sel(CMstrlot_chkeasycombineVer, _
                                            pstrSBID, _
                                            ltypLotprestate.strLotID, _
                                            mstrResult, _
                                            mstrDivCarrier, _
                                            mstrDivLotID)

                        If Not lblnAns Then
                            '@確定ﾎﾞﾀﾝは使用不可
                            cmdProcEnd.Enabled = False
                            
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)
                            
                            '@失敗をｾｯﾄ
                            txtCarrier_Enter = False
                        End If
                    End If
        '@ ↑'09/06/29（Mon） K.Nishizawa *******************************************************
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@結果OKをｾｯﾄ
                txtCarrier_Enter = True
            End If
           
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Enter"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvvsfNextStepInfo_Init
    '機　能：次工程一覧を初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/17 (Mon) 14:42:21 H.Wajima
    '更新日：2004/07/23 (Fri) 15:28:43 N.Kojima
    '備　考：
    Private Sub prvVsfNextStepInfo_Init()

        Try
            
            With vsfNextStepInfo
                .Redraw = False
                '@ﾌﾟﾛﾊﾟﾃｨ初期値
                .Clear
                .Cols.Count = CMlngNextStepInfoColWPID + 1
                .Rows.Count = CMlngGridFixedRows
                .Cols.Fixed = CMlngGridFixedCols
                .Rows.Fixed = CMlngGridFixedRows
                .SelectionMode = SelectionModeEnum.RowRange
                '.FillStyle = flexFillRepeat
                .FocusRect = FocusRectEnum.None
                .HighLight = HighLightEnum.Never
                .Font = New Font(CMstrGridFontName, CMlngGridFontSize,.Font.Style)
                .ScrollBars = ScrollBars.None
                .Width = CMlngGridWidth
                .Height = CMlngGridHeight
                
                '@表示位置の設定(ﾃﾞﾌｫﾙﾄ)
                .Cols(CMlngNextStepInfoColOpID).TextAlign = TextAlignEnum.LeftCenter        '左中央寄せ
                .Cols(CMlngNextStepInfoColStepID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngNextStepInfoColDefault).TextAlign = TextAlignEnum.LeftCenter    
                .Cols(CMlngNextStepInfoColWPID).TextAlign = TextAlignEnum.LeftCenter 
                
                '@ｸﾞﾘｯﾄﾞの表題設定
                .Select(CMlngGridRowTitle, CMlngNextStepInfoColOpID, CMlngGridRowTitle, CMlngNextStepInfoColWPID)

                Dim headerSellRange = .GetCellRange(CMlngGridRowTitle, CMlngNextStepInfoColOpID, CMlngGridRowTitle, CMlngNextStepInfoColWPID)
                Dim headerStyle = .Styles.Add("headerStyle")

                headerStyle.ForeColor = Color.Yellow                                        '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)           '背景色
                headerStyle.Font = New Font(.Font.Name, CMlngGridFontSize, .Font.Style)     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                          '文字位置
                
                headerSellRange.Style = headerStyle

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColOpID, CMstrNextStepInfoColTOpID)          '大工程ID
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColStepID, CMstrNextStepInfoColTStepID)      '小工程ID
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColDefault, CMstrNextStepInfoColTDefault)    'ﾃﾞﾌｫﾙﾄ
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColWPID, CMstrNextStepInfoColTWPID)          'WPID
                
                '@列幅の設定
                .Cols(CMlngNextStepInfoColOpID).Width = CMlngGridColWidthOpID          '大工程ID
                .Cols(CMlngNextStepInfoColStepID).Width = CMlngGridColWidthStepID      '小工程ID
                .Cols(CMlngNextStepInfoColDefault).Width = CMlngGridColWidthDefault    'ﾃﾞﾌｫﾙﾄ
                .Cols(CMlngNextStepInfoColWPID).Width = CMlngGridColWidthWPID          'WPID
                
                '@結合セルの設定
                .AllowMerging = AllowMergingEnum.RestrictAll
                .Cols(CMlngNextStepInfoColOpID).AllowMerging = True
                .Cols(CMlngNextStepInfoColStepID).AllowMerging = True
                .Cols(CMlngNextStepInfoColDefault).AllowMerging = True
                
                '@ﾀｲﾄﾙの高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight

                .Redraw = True
                
                '@ﾛｯｸ
                .Enabled = False
            
                '@ｽｸﾛｰﾙﾎﾞﾀﾝの表示初期化
                Call pubVsfDisp(vsfNextStepInfo, cmdNextUP, cmdNextDown)
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfNextStepInfo_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfNextStepInfo_Disp
    '機　能：次工程一覧表示
    '引　数：ltypLotNextStep：次工程取得情報構造体
    '　　　：llngCnt：次工程ｶｳﾝﾄ
    '戻り値：なし
    '作成日：2004/05/18 (Tue) 12:31:33 N.Kasai
    '更新日：2004/05/19 (Wed) 16:10:37 H.Wajima
    '備　考：
    Private Sub vsfNextStepInfo_Disp(ByVal ltypLotNextStep As LotNextStep, ByVal llngCnt As Integer)

        Dim lllngWPListCnt  As Integer  'WPListCntｶｳﾝﾀ
        Dim llngStepCnt     As Integer  '小工程ｶｳﾝﾀ
        Dim llngRowCnt      As Integer  '行ｶｳﾝﾀ

        Try

            '@一覧表示
            With vsfNextStepInfo
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@ｶｳﾝﾀの初期化
                llngRowCnt = .Rows.Fixed
                
                '@ｸﾞﾘｯﾄﾞの明細行ﾙｰﾌﾟ
                For llngStepCnt = 0 To llngCnt -1
                    For lllngWPListCnt = 0 To ltypLotNextStep.strNextStepList(llngStepCnt).lngWpListCnt -1
                        '@行数の設定
                        .Rows.Count = llngRowCnt + 1
                        
                        '@大工程
                        .SetData(llngRowCnt, CMlngNextStepInfoColOpID,ltypLotNextStep.strNextStepList(llngStepCnt).strNextOpId)
                            
                        '@小工程
                        .SetData(llngRowCnt, CMlngNextStepInfoColStepID,ltypLotNextStep.strNextStepList(llngStepCnt).strNextStepId)
                            
                        '@ﾃﾞﾌｫﾙﾄ
                        Select Case ltypLotNextStep.strNextStepList(llngStepCnt).strStepDivision
                            Case "0"
                                .SetData(llngRowCnt, CMlngNextStepInfoColDefault, CMstrDaitaiStep)
                            Case "1"
                                .SetData(llngRowCnt, CMlngNextStepInfoColDefault, CMstrDefaultStep)
                            Case Else
                                .SetData(llngRowCnt, CMlngNextStepInfoColDefault, vbNullString)
                        End Select
                        
                        '@装置
                        .SetData(llngRowCnt, CMlngNextStepInfoColWPID,ltypLotNextStep.strNextStepList(llngStepCnt).strWPList(lllngWPListCnt).strWpName)
                        
                        '@明細の行の高さ
                        .Rows(llngRowCnt).Height = CMlngGridRowHeight

                        '@ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                        llngRowCnt = llngRowCnt + 1
                    Next lllngWPListCnt
                Next llngStepCnt
                
                '@ﾀｲﾄﾙの行の高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight
                
                '@描画の再開
                .Redraw = True

                '@ｽｸﾛｰﾙﾎﾞﾀﾝの表示初期化
                Call pubVsfDisp(vsfNextStepInfo, cmdNextUP, cmdNextDown)
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfNextStepInfo_Disp"
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
        Dim lblnSysCommandScClose   As Boolean  = False     'NSYS コントロールメニュー SC_CLOSE処理時 True

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

        End Select

        MyBase.WndProc(m)

        If lblnSysCommandScClose = True Then
            'NSYS SC_CLOSE 処理後 WM_CLOSE が発生しないでキャンセルされることもあるため、フラグを戻す
            'NSYS WM_CLOSE が発生していれば、すでにこの時点では画面は閉じている
            mblnCloseFromControlMenu = False
        End If
    End Sub

End Class
