'ﾌｧｲﾙ名：xxEN02F0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：治具ウェハーセット　メインフォーム
'作成日：2009/06/04 (Thr) 17:56:45 K.Nishizawa
'更新日：2016/02/11 (Thu) 22:12:44 H.Hayashi
'備　考：
'　　　：
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02F0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02F0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02F0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02F0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02F0)
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
    'Private Const CMstrLocalVersion             As String = "02.01"
    Private Const CMstrLocalVersion             As String = "03.01"

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN02F0

    '@Msgﾊﾞｰｼﾞｮﾝ
    'Private Const CMstrlot_curstateVer          As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer          As String = "04.00"         'ﾛｯﾄ現在状態取得

	Private Const CMstrlot_waferlistVer         As String = "02.05"         'ﾛｯﾄWF情報取得(新)
	

	Private Const CMstrjig_jusechkVer           As String = "01.00"         '蒸着治具使用可否判定
	Private Const CMstrjig_jjiggetVer           As String = "01.00"         '蒸着治具情報単体取得
    Private Const CMstrwf_jigsetVer				As String = "02.00"         '治具Waferｾｯﾄ
    'Private Const CMstrlot_attributeVer        As String = "04.01"         'ﾛｯﾄ情報取得
    Private Const CMstrlot_attributeVer         As String = "05.00"         'ﾛｯﾄ情報取得

    '@治具状態
    Private Const CMstrJigStatusCanUse				As String = "0"             '使用可
    Private Const CMstrJigStatusUsing				As String = "1"             '使用中
    Private Const CMstrJigStatusNG					As String = "3"             '使用不可
	Private Const CMstrJigStatusRdyUseBeforeSetId	As String = "5"				'使用可(組前)
    '@フラグON
    Private Const CMstrFlagOn						As String = "1"             'フラグON

    '@vsfSlotMapの定数宣言(ｶﾗﾑ)
    Private Const CMlngColSlot                  As Integer = 0              'ｽﾛｯﾄ
	Private Const CMlngColSelect				As Integer = 1              '選択
    Private Const CMlngColWFID                  As Integer = 2              'WFID
    Private Const CMlngColJigId                 As Integer = 3              'ガイドリングID
    Private Const CMlngColBeforJigId            As Integer = 4              '変更前ガイドリングID
	Private Const CMlngColMaskID                As Integer = 5              'マスクID
    Private Const CMlngColWashUseNum            As Integer = 6              '洗浄後使用回数
	Private Const CMlngColWashUselimit          As Integer = 7              '洗浄後使用上限回数
    Private Const CMlngColHolderID				As Integer = 8              'ホルダID
	Private Const CMlngColHolderWashUseNum		As Integer = 9              'ホルダ洗浄後使用回数
	Private Const CMlngColJigWfSet				As Integer = 10             '治具WF紐づけ

    '@vsfSlotMapの定数宣言(表示幅)
    Private Const CMlngColSlotWidth             As Integer = 29             'ｽﾛｯﾄWidth
	Private Const CMlngColSelectWidth			As Integer = 35             '選択
    Private Const CMlngColWFIDWidth             As Integer = 140            'WFIDWidth
    Private Const CMlngColJigIdWidth            As Integer = 140            '治具IDWidth
    Private Const CMlngColBeforJigIdWidth       As Integer = 140            '変更前治具IDWidth
	Private Const CMlngColMaskIDWidth           As Integer = 140              'マスクID
    Private Const CMlngColWashUseNumWidth       As Integer = 80              '洗浄後使用回数
	Private Const CMlngColWashUseLimitWidth     As Integer = 80              '洗浄後使用上限回数
    Private Const CMlngColHolderIDWidth			As Integer = 140              'ホルダID
	Private Const CMlngColHolderWashUseNumWidth As Integer = 80              'ホルダ洗浄後使用回数
	Private Const CMlngColJigWfSetWidth			As Integer = 80              '治具WF紐づけ

    '@vsfSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrSlotMapColTSlot				As String = vbNullString    'ｽﾛｯﾄNO
    Private Const CMstrSlotMapColTSelect			As String = vbNullString    '選択
    Private Const CMstrSlotMapColTWFID				As String = "WFID"          'WFID
    Private Const CMstrSlotMapColTJigID				As String = "ガイドリングID"   
    Private Const CMstrSlotMapColTBeforJigID		As String = "変更前治具ID"  
    Private Const CMstrSlotMapColTMaskID			As String = "マスクID"          
    Private Const CMstrSlotMapColTWashUseNum		As String = "使用回数"  
	Private Const CMstrSlotMapColTWashUseLimit		As String = "使用上限回数" 
    Private Const CMstrSlotMapColTHolderID			As String = "ホルダID"  
	Private Const CMstrSlotMapColTHolderWashUseNum	As String = "使用回数"          '使用回数（ホルダ）
    Private Const CMstrSlotMapColTJigWfSet			As String = "治具WF紐付け"   

    '@vsfSlotMapの定数宣言(その他)
    Private Const CMlngSlotMapRowTitle          As Integer = 0              'ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ
    Private Const CMlngSlotHMaCellFontSize      As Integer = 12             'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngSlotMapRowS              As Integer = 26             '行数
    Private Const CMlngSlotMapHHeight           As Integer = 20             'ﾍｯﾀﾞｰの高さ
    Private Const CMlngSlotMapHeight            As Integer = 38             '1ｽﾛｯﾄの高さ
    Private Const CMlngSlotMapSTopRow           As Integer = 16             '初期表示行番号
    Private Const CMlngSlotMapPageRows          As Integer = 10             '1ﾍﾟｰｼﾞ表示行数
    Private Const CMlngSlotMapSlotNo10Row       As Integer = 16             '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№10の行番号
	Private Const CMlngSlotMapSlotNo11Row       As Integer = 15             '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№11の行番号
	Private Const CMlngSlotMapSlotNo15Row       As Integer = 11             '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№15の行番号
	Private Const CMlngSlotMapSlotNo20Row       As Integer = 6              '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№20の行番号

    '@txtWfScanの定数宣言
    Private Const CMlngWfIdLength               As Integer = 10             'WFIDの桁数
    Private Const CMlngWfIdSelPos               As Integer = 8              'WFIDを示す'#'の表示位置
    Private Const CMstrWfIdSel                  As String = "#"             'WFIDのｽﾛｯﾄ定義文字列
    Private Const CMstrPoint                    As String = "*"             '入力待ち治具の目印


    Private Const CMlnStartGridRows             As Integer = 1              'ｸﾞﾘｯﾄﾞの初期行数
    Private Const CMlngBackColorCel             As Integer = &H8000000D     'ｸﾞﾘｯﾄﾞのﾊﾞｯｸｶﾗｰｾﾙ(紺)

	Private Const CMlngBackColorYellow          As Integer = &HC0FFFF               '黄色

    Private Const CMstrScanTitle_Jig            As String = "治具 スキャン"  'ｽｷｬﾝのﾀｲﾄﾙ表示
    Private Const CMstrScanTitle_WF             As String = "WAFER スキャン" 'ｽｷｬﾝのﾀｲﾄﾙ表示

    '@ATLAS報告
    Private Const CMstrAtlasFlowNumberTPAL      As String = "1"              'TPAL
    Private Const CMstrAtlasFlowNumberODF       As String = "2"              'ODF

	'蒸着治具カテゴリ
	Private Const CMstrCmbJJigCategoryGuideId				As String = "G"	
	Private Const CMstrCmbJJigCategoryMaskId				As String = "M"	
	Private Const CMstrCmbJJigCategoryHolderId				As String = "H"	

	'治具イベントID	
	Private Const CMstrJigEventIdJigWfSet					As String = "6"			'治具WF紐付け
	Private Const CMstrJigEventIdCancelJigWfSet				As String = "7"			'治具WF紐付け解除

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '========================================Private========================================
    Private mstrEventName                       As String                   'ﾚｽﾎﾟﾝｽ用ｲﾍﾞﾝﾄ名
    Private mstrCarrierTypeID                   As String                   'ｷｬﾘｱﾀｲﾌﾟID(LOADER側)
    Private mblnTakeOverDispFlg                 As Boolean                  '引継ぎ表示ﾌﾗｸﾞ
    Private mlngVsfBottomRow                    As Integer                  '画面の一番下の行(WF№01の行)
    Private mlngSlotMapRowS                     As Integer                  '行数
    Private mblnWFIDScanWait                    As Boolean                  'スキャンウェハーID待ち
    Private mstrCategoryID                      As String                   'ｶﾃｺﾞﾘｰ
    Private mstrScreenSizeId                    As String                   'ｽｸﾘｰﾝｻｲｽﾞID
    Private mstrCfFlag                          As String                   'CFﾌﾗｸﾞ
    Private mstrLpFlag                          As String                   'ODFﾌﾗｸﾞ
    Private mblnEventCancelFlag                 As Boolean                  'イベントキャンセルフラグ
    Private buttonProcessing                    As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                  'NSYS WindowCloseフラグ
    Private mblnTxtWfScanForEnabled             As Boolean                  'NSYS WAFERスキャンテキストボックス有効化か
	Private mstrLastHolderId					As String					'ホルダの前回値
	Private mblnGuideIdSelectFlag				As Boolean                  '空治具選択押下時の編集セル判別用
    Private mblnHolderIdSelectFlag				As Boolean                  '空治具選択押下時の編集セル判別用
	Private mstrJJigCategoryID                  As String                   '蒸着治具ｶﾃｺﾞﾘ
	Private mstrpdId							As String                   '機種

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
        pubVsfMouseWheelManager_Set(vsfSlotMapStck, cmdUpStck, cmdDownStck)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '========================================Private========================================

    '関数名：Form_Load
    '機　能：ACT初期設定および初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/09 (Tue) 15:52:03 K.Nishizawa
    '更新日：
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値

        Try

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Me.Left = 0 - My.Settings.FormOffset
            Me.Top = 0
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02F0, CMstrLocalVersion)
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
            
            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call prvfrmxxEN02F0_Init()
            
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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 15:47:42 H.Wajima
    '更新日：2004/07/27 (Tue) 15:47:42
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

            '@引数のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合
                '@ｷｬﾘｱIDの初期値を設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId

                '@ｷｬﾘｱID情報表示
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
    '機　能：ﾌｫｰｶｽ制御
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｷｰｺｰﾄﾞ
    '戻り値：
    '作成日：2009/06/09 (Tue) 17:09:20 K.Nishizawa
    '更新日：2009/06/09 (Tue) 17:09:20
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Dim llngRow              As Integer      '対象行格納用
        Dim llngTopRow           As Integer      '先頭行
        Dim lstrCRow             As String       'ｶﾚﾝﾄ行
        Dim lintKeyCode          As Short        'ｶﾚﾝﾄ行

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
            
            If ActiveControl.Name = vsfSlotMapStck.Name Then
                With vsfSlotMapStck
                    lintKeyCode = e.KeyCode
                    llngRow = .Row
                    llngTopRow = .TopRow
                    lstrCRow = pubstrVsfTag_Get(vsfSlotMapStck, 1)
                    '@ｸﾞﾘｯﾄﾞｷｰ制御
                    Call pubVsf_KeyDown(e, .Name, vsfSlotMapStck, cmdUpStck, cmdDownStck, False)                  '分割元ﾏｯﾌﾟ

                    '@ﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfSlotMapStck)
                End With
            End If
            
            '@ｷｰｺｰﾄﾞの確認
            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    '@ﾌｫｰｶｽがｷｬﾘｱIDにある場合
                    If ActiveControl.Name = "txtCarrier" Then
                        '@明細を表示する
                        RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                        Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(TRue))
                        AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                        Exit Sub
                    End If

                    '@ｺﾒﾝﾄにﾌｫｰｶｽがある場合
                    If ActiveControl.Name = "txtWorkMemo" Then
                        '@改行処理はしない
                        Exit Sub
                    End If
                    
                    If txtWfScan.Text <> vbNullString Then
                        'Validateを起こしてｸﾞﾘｯﾄﾞに値を反映させる
                        SendKeys.SendWait(CPstrSendKeysTab)
                    End If

                    If ActiveControl.Name <> vsfSlotMapStck.Name AndAlso _
                            ActiveControl IsNot vsfSlotMapStck.Editor Then
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
         
        End Try
     End Sub


    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2009/06/09 (Tue) 15:55:55 K.Nishizawa
    '更新日：2013/05/16 (Thu) 16:08:15 T.Oide
    '備　考：2004/11/01 (Mon) 16:18:33 T.Kitagawa　閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@ｸﾞﾛｰﾊﾞﾙな変数を初期化
            pstrLotID = vbNullString
            pstrCarrierID = vbNullString
            pblnMkEasyDivFlag = False
        '@↓2013/05/16 (Thu) 16:08:15 T.Oide **************************************************
            pstrAtlasFlowNumber = vbNullString
        '@↑2013/05/16 (Thu) 16:08:15 T.Oide **************************************************

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
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

    '関数名：cmdClear_Click
    '機　能：Waferを治具から取り外す
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/09 (Tue) 15:55:24 K.Nishizawa
    '更新日：2005/02/15 (Tue) 13:25:37 N.Kojima
    '備　考：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Dim ltypWfJigSetReq         As JigSetInf
        Dim lblnAns                 As Boolean
        Dim llngCntFirst            As Integer
        Dim lstrtmpCarrierId        As String
        
        
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
            
            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnInput_Chk()
            If lblnAns = False Then
                '@不正項目あり
                Exit Sub
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If

            lstrtmpCarrierId = txtCarrier.Text

            With vsfSlotMapStck

				'@対象を抽出
                llngCntFirst = 0
                If IsNothing(ltypWfJigSetReq.typWfList) Then
                    ltypWfJigSetReq.typWfList = New List(Of JigWfList)
                Else
                    ltypWfJigSetReq.typWfList.Clear()
                End If
	
				For llngRowCnt = 1 To .Rows.Count - 1
					Dim typWfListTmp As JigWfList = New JigWfList
					If .GetCellCheck(llngRowCnt, CMlngColSelect) = CheckEnum.Checked Then
						typWfListTmp.strWfId = .GetData(llngRowCnt, CMlngColWFID)
						ltypWfJigSetReq.typWfList.Add(typWfListTmp)
					End if
				Next
            End With
            ltypWfJigSetReq.strEmpID = pstrUserID
            ltypWfJigSetReq.strLotID = lblLotID.Text
            ltypWfJigSetReq.strSbID = pstrSBID
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "cmdUseChange_Click"
            'Call pubResponseStart(Me.Name, mstrEventName)   
            
            '@Msg送信処理実行
            lblnAns = pubblnWaferJigSet_Upd(CMstrwf_jigsetVer, CMstrJigStatusCanUse, CMstrJigEventIdCancelJigWfSet, ltypWfJigSetReq)
            
            '@結果判定
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                'Call publngResponseEnd(Me.Name, mstrEventName)
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005B)
                '@"<TRM5BI>$$キャリア情報を更新しました。"
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@画面の初期化
                Call prvfrmxxEN02F0_Init(False, True)
                
                '@再ロード
                txtCarrier.Text = lstrtmpCarrierId
                mblnTxtWfScanForEnabled = False
                RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(True))
                AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate

                If mblnTxtWfScanForEnabled = False Then
                    '@"WFスキャン"ﾃｷｽﾄﾎﾞｯｸｽ無効
                    With txtWfScan
                        .Enabled = False
                        .BackColor = SystemColors.ControlLight
                    End With
                End If
                
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
            End If

            
            '@ﾌｫｰｶｽ制御
            If txtCarrier.Enabled = False Then
                txtCarrier.Enabled = True
            End If
            
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
    '作成日：2009/06/09 (Tue) 15:55:24 K.Nishizawa
    '更新日：2005/02/15 (Tue) 13:25:37 N.Kojima
    '備　考：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
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
            
            '@引継ぎ情報のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合
                '@親ﾌｫｰﾑから呼ばれた場合
                '@親画面切り替え引継ぎ制御
                Call pubChangeScreen_Set(Me)
            Else
            '@空白の場合
                '@終了関数を実行する
                Call publngEnd_Proc(CPstrKeyEN02F0, ltypCommonInfo)
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

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱ変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/17 (Wed) 07:38:09　T.Sawaguchi
    '更新日：2013/04/19 (Fri) 14:46:01 T.Oide
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change
        
        Try
        
            '@画面初期化
            Call prvfrmxxEN02F0_Init(False)
            
            '@初期値をｾｯﾄ
            ptypLotRlst.strLotID = vbNullString             '分割先ﾛｯﾄID
            ptypLotRlst.strFlowClass = vbNullString         '流動区分
            mstrCategoryID = vbNullString                   '治具ｶﾃｺﾞﾘｰ
            mstrScreenSizeId = vbNullString                 'ｽｸﾘｰﾝｻｲｽﾞID
            mstrCfFlag = vbNullString                       'CFﾌﾗｸﾞ
            mstrLpFlag = vbNullString                       'Lpﾌﾗｸﾞ
            
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

    '関数名：cmdEasyDivide_Click
    '機　能：簡易分割
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 09:58:42 K.Nishizawa
    '更新日：2004/10/26 (Tue) 09:43:07 M.Miura
    '備　考：
    Private Sub cmdEasyDivide_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEasyDivide.Click
        
        Dim ltypOldCommonInfo  As CommonInfo

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@必要情報を退避させる
            ltypOldCommonInfo = ptypCommonInfo
                
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱの退避
            pstrCarrierID = txtCarrier.Text
            pstrLotID = lblLotID.Text
                
            '@無機専用の簡易分割ﾌﾗｸﾞをたてる
            pblnMkEasyDivFlag = True
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@簡易分割ﾌﾗｸﾞ
            pblnfrmxxEN02F0kbn = True
            
            '@ﾌｫｰﾑﾛｰﾄﾞ
            frmxxEN0160.Instance = New frmxxEN0160()
                
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                pstrLotID = vbNullString
                pstrCarrierID = vbNullString
                pblnfrmxxEN02F0kbn = False
                frmxxEN0160.Instance = Nothing
                Exit Sub
            End If
            
            'ロット分割画面表示
            frmxxEN0160.Instance.ShowDialog(Me)
            frmxxEN0160.Instance = Nothing
            pstrLotID = vbNullString
            pblnFormLoad = False
            Call prvfrmxxEN02F0_Init()
            txtCarrier.Text = pstrCarrierID
            '@最新状態を取得するためにValidateを呼ぶ
            RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
            AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
            
            pstrCarrierID = vbNullString
            pblnfrmxxEN02F0kbn = False
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUpStck_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 作業開始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdWorkStart_Click(sender As Object, e As EventArgs) Handles cmdWorkStart.Click

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
            
            '@ｷｬﾘｱの退避
            pstrCarrierID = txtCarrier.Text
            pstrLotID = lblLotID.Text
                        
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '自フォームフラグ
            pblnfrmxxEN02F0kbn = True

            ptypCommonInfo.strCarrierId = txtCarrier.Text
            ptypCommonInfo.strLotID = lblLotID.Text

            'インスタンス生成
            frmxxEN0030.Instance = New frmxxEN0030()
                
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                pstrLotID = vbNullString
                pstrCarrierID = vbNullString
                pblnfrmxxEN02F0kbn = False
                frmxxEN0030.Instance = Nothing
                Exit Sub
            End If
            
            '「作業開始」画面表示
            frmxxEN0030.Instance.ShowDialog(Me)
            frmxxEN0030.Instance = Nothing
            pstrLotID = vbNullString
            pblnFormLoad = False
            Call prvfrmxxEN02F0_Init()
            txtCarrier.Text = pstrCarrierID

            '@最新状態を取得するためにValidateを呼ぶ
            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
            
            pstrCarrierID = vbNullString
            pblnfrmxxEN02F0kbn = False
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkStart_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 作業終了
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdWorkEnd_Click(sender As Object, e As EventArgs) Handles cmdWorkEnd.Click

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
            
            '@ｷｬﾘｱの退避
            pstrCarrierID = txtCarrier.Text
            pstrLotID = lblLotID.Text
                
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '自フォームフラグ
            pblnfrmxxEN02F0kbn = True

            ptypCommonInfo.strCarrierId = txtCarrier.Text
            ptypCommonInfo.strLotID = lblLotID.Text
            
            'インスタンス生成
            frmxxEN0060.Instance = New frmxxEN0060()
                
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                pstrLotID = vbNullString
                pstrCarrierID = vbNullString
                pblnfrmxxEN02F0kbn = False
                frmxxEN0060.Instance = Nothing
                Exit Sub
            End If
            
            '「作業終了」画面表示
            frmxxEN0060.Instance.ShowDialog(Me)
            frmxxEN0060.Instance = Nothing

            '作業終了を確定/未確定に関わらず初期化
            pstrCarrierID = vbNullString
            pstrLotID = vbNullString
            pblnFormLoad = False
            Call prvfrmxxEN02F0_Init()
            txtCarrier.Text = pstrCarrierID

            '@最新状態を取得するためにValidateを呼ぶ
            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
           
            pblnfrmxxEN02F0kbn = False
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkStart_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUpStck_Click
    '機　能：前ﾍﾟｰｼﾞ(編成元ﾏｯﾌﾟ)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 09:58:42 K.Nishizawa
    '更新日：2004/10/26 (Tue) 09:43:07 M.Miura
    '備　考：
    Private Sub cmdUpStck_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpStck.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理
            Call pubVsfCmdUp(vsfSlotMapStck, cmdUpStck, cmdDownStck)            '分割元WFﾏｯﾌﾟ
            
            '@次のﾌｫｰｶｽｾｯﾄ
            If cmdUpStck.Enabled = False Then
                Call pubSetFocus(cmdDownStck)
            Else
                Call pubSetFocus(cmdUpStck)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUpStck_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDownStck_Click
    '機　能：次ﾍﾟｰｼﾞ(編成元ﾏｯﾌﾟ)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 09:58:42 K.Nishizawa
    '更新日：2004/10/26 (Tue) 09:52:23 M.Miura
    '備　考：
    Private Sub cmdDownStck_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDownStck.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理
            Call pubVsfCmdDown(vsfSlotMapStck, cmdUpStck, cmdDownStck, False)       '分割元WFﾏｯﾌﾟ
            
            '@次のﾌｫｰｶｽｾｯﾄ
            If cmdDownStck.Enabled = False Then
                Call pubSetFocus(cmdUpStck)
            Else
                Call pubSetFocus(cmdDownStck)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDownStck_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWfScan_Validate
    '機　能：WFスキャン開始
    '引　数：Cancel
    '戻り値：なし
    '作成日：2009/06/15 (Mon) 09:58:42 K.Nishizawa
    '更新日：2012/12/05 (Wed) 09:47:37 T.Oide
    '備　考：2012/12/05 (Wed) 09:47:37 T.Oide           ウェハーIDを読んでも*が付かない不具合修正
    Private Sub txtWfScan_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtWfScan.Validating

        Dim llngRowCnt          As Integer
        Dim lblnHitWfId         As Boolean      '入力されたWFIDと一致したらTrue
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If
            
            lblnHitWfId = False
            
            '@空の場合はなにもしない
            If txtWfScan.Text = vbNullString Then
                Exit Sub
            End If
            
			'治具WF紐付け機能改修により仕様変更
			'紐付け前のデータの場合治具ＩＤ列を選択状態にするだけに変更
			'本来やりたかったWFスキャン→治具IDスキャンの形を維持できればOK
            '@入力データが10桁か
            If Len(txtWfScan.Text) = CMlngWfIdLength Then
               
                '@ｳｪﾊｰID入力待ちか
                If mblnWFIDScanWait = True Then

                        
                    '@同じｳｪﾊｰIDを探してその治具ID列を編集状態にする
                    With vsfSlotMapStck
                        .Redraw = False
                        For llngRowCnt = 1 To .Rows.Count - 1
                            If .GetData(llngRowCnt, CMlngColWFID) = txtWfScan.Text And _
								.GetData(llngRowCnt, CMlngColJigWfSet) = vbNullString Then
                                
 '                               mblnEventCancelFlag = True
                                .Row = llngRowCnt
                                .Col = CMlngColJigId
 '                              mblnEventCancelFlag = False
                                    
								'ガイドリングIDを選択、編集状態にする
								.Select(llngRowCnt, CMlngColJigId)
								.StartEditing()
                                

                                lblnHitWfId = True          '入力したｳｪﾊｰがSlotMap内にある

                                    
                                Exit For
                            End If
                        Next
                        .Redraw = True

                        If lblnHitWfId = False Then
                            
                            '@入力されたｳｪﾊｰIDに一致するｳｪﾊｰIDがありません。選択中のﾛｯﾄが正しいか確認してください。
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009Z, txtWfScan.Text)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                
                        End If
                            
                    End With
                    
                End If
            
            Else
                '@入力された値は不正です。正しい値を入力してください。
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0102)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
            End If
            
            '@入力値ｸﾘｱ
            txtWfScan.Text = vbNullString
            

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDownStck_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMapStck_AfterEdit
    '機　能：分割元ｽﾛｯﾄﾏｯﾌﾟの変更後処理
    '引　数：行 Row 列 Col
    '戻り値：なし
    '作成日：2009/06/10 (Thu) 15:43:29 K.Nishizawa
    '更新日：2009/08/06 (Thu) 15:14:30 T.Oide
    '備　考：
    Private Sub vsfSlotMapStck_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfSlotMapStck.AfterEdit
        
        Dim ltypjJigChk             As jJigCheck					'治具使用可否判定確認Msg
        Dim lblnAns                 As Boolean
		Dim lblnAns2				As Boolean
        Dim lstrGuideMsgCode        As String						'返信ﾒｯｾｰｼﾞｺｰﾄﾞ
        Dim lstrGuideMsg            As String						'返信ﾒｯｾｰｼﾞ
        Dim lstrDispGuidMsg         As String						'ﾒｯｾｰｼﾞ本体
        Dim llngRowCnt              As Integer
		Dim ltypJJigList			As JJigList						'蒸着治具
		Dim lblnCancel				As Boolean


        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMapStck.Rows.Count <= vsfSlotMapStck.Rows.Fixed Then
                Return
            End If
            
            mstrEventName = "vsfSlotMapStck_AfterEdit"
			'@ﾚｽﾎﾟﾝｽ測定開始
            Call pubResponseStart(Me.Name, mstrEventName)

			lblnCancel = False

            With vsfSlotMapStck
                '@ガイドリング,ホルダID列のみを確認する
                If e.Col = CMlngColJigId Or e.Col = CMlngColHolderID Then
                    '@変更前と異なる治具IDだった場合のみﾁｪｯｸ
                    If .GetData(e.Row, CMlngColJigId) <> .GetData(e.Row, CMlngColBeforJigId) Or _
						.GetData(e.Row, CMlngColHolderID) <> mstrLastHolderId Then

						'ﾁｪｯｸが入っていたら外す
						.SetCellCheck(e.Row, CMlngColSelect, CheckEnum.UnChecked)
						
						'@治具使用可否判定Msgのﾊﾝﾄﾞﾘﾝｸﾞ
                        '@空の場合は上記Msgを投げない
                        If .GetData(e.Row, e.Col) <> vbNullString Then
                            ltypjJigChk.strSbID = pstrSBID
                            ltypjJigChk.strjigId = .GetData(e.Row, e.Col)
							If e.Col = CMlngColJigId Then
								ltypjJigChk.strJJigCategory = CMstrCmbJJigCategoryGuideId
							Else If e.Col = CMlngColHolderId Then
								ltypjJigChk.strJJigCategory = CMstrCmbJJigCategoryHolderId
							End If

                            lblnAns = pubblnJJigUse_Check(CPstrCD4H, CMstrjig_jusechkVer, ltypjJigChk, _
                                                            lstrGuideMsgCode, lstrGuideMsg)
                            If lblnAns Then
                                If lstrGuideMsg = vbNullString Then

                                    '@入力した治具が別の治具に設定されている場合でDB未更新の場合
                                    '@Errorを表示する
                                    '@確定ボタンは有効のままで良い
                                    For llngRowCnt = 1 To .Rows.Count - 1
                                        If llngRowCnt <> e.Row Then
                                            '@治具IDが重複している場合は削除
                                            If .GetData(llngRowCnt, CMlngColJigId) = .GetData(e.Row, e.Col) Or
												.GetData(llngRowCnt, CMlngColHolderId) = .GetData(e.Row, e.Col) Then
                                            
                                                '@治具IDが重複しています。他の治具を選択してください。
                                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0103, txtWfScan.Text)
                                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
												vsfSlotMapStck_ClearRow(e.Row, e.Col)
                                                .Select(e.Row, e.Col)
                                                .StartEditing()
                                                lblnCancel = true
                                                Exit For
                                            End If
                                        End If
                                    Next
                                Else
                                    '@ﾒｯｾｰｼﾞがあった場合は、ｴﾗｰMsgをﾎﾟｯﾌﾟｱｯﾌﾟしてﾎﾞﾀﾝはDisable
                                    '@ｴﾗｰだった場合は再度"治具ID"の項目を選択する
                                    lstrDispGuidMsg = lstrGuideMsgCode & vbCrLf & vbCrLf & lstrGuideMsg
                                    pstrDMsg = pubstrMsgReplace_Set(lstrDispGuidMsg)
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
									vsfSlotMapStck_ClearRow(e.Row, e.Col)
                                    .Select(e.Row, e.Col)
                                    .StartEditing()
									lblnCancel = true
                                End If
                            Else
                                '@RET=FALSEの場合も治具IDにﾌｫｰｶｽ当てる
								vsfSlotMapStck_ClearRow(e.Row, e.Col)
                                .Select(e.Row, e.Col)
                                .StartEditing()
								lblnCancel = true
                            End If

							'前回値更新
							mstrLastHolderId = .GetData(e.Row, CMlngColHolderID)
							.SetData(e.Row, CMlngColBeforJigId, .GetData(e.Row, CMlngColJigID))

							If .Editor Is Nothing Then
								'NSYS 編集モードでない場合は、ハイライト表示を戻す
								.Styles.Highlight.BackColor = SystemColors.Highlight
								.Styles.Highlight.ForeColor = SystemColors.Window
							Else
								'NSYS エラー発生で再び編集モードの場合は、ハイライト表示を消す
								.Styles.Editor.BackColor = SystemColors.Window
								.Styles.Editor.ForeColor = SystemColors.WindowText
								.Styles.Highlight.BackColor = SystemColors.Window
								.Styles.Highlight.ForeColor = SystemColors.WindowText
							End If


							'組立マスクID、洗浄後使用回数、上限回数を取得する
							'治具情報単体取得
							lblnAns2 = pubblnJJig_Sel(CMstrjig_jjiggetVer, _
														.GetData(e.Row, e.Col), _
														ltypJJigList)
							'@取得結果反映
							If lblnAns2 Then
								'もしガイドリングIDだったら治具情報取得してマスクID列を埋める
								If e.Col = CMlngColJigId And lblnCancel = False Then
									If ltypJJigList.strSetMaskId = vbNullString Then
										'組立マスクIDが取得できなかった場合は、メッセージを表示しガイドリングIDを空にする
										'@表示ﾒｯｾｰｼﾞ変換
										pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0186)
										'@"組立相手が見つかりませんでした。"
										Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
										vsfSlotMapStck_ClearRow(e.Row, e.Col)
										.Select(e.Row, e.Col)
										.StartEditing()

										'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
										Call pubResponseCancel(Me.Name, mstrEventName)
							
									Else
										'正常に取得できた場合
										'@ﾃﾞｰﾀをｸﾞﾘｯﾄﾞにｾｯﾄ
										.SetData(e.Row, CMlngColMaskID, ltypJJigList.strSetMaskId)
										.SetData(e.Row, CMlngColWashUseNum, ltypJJigList.strWashUseNum)
										.SetData(e.Row, CMlngColWashUseLimit, ltypJJigList.strWashUseLimit)
										'在庫準備フラグOFF　かつ　使用回数+10 >= 上限回数だった場合は,「使用回数」列の背景色を黄色にする
										if CLng(ltypJJigList.strWashUseNum)+10 >= CLng(ltypJJigList.strWashUseLimit)　And _
											ltypJJigList.strNextStockReadyFlag <> CPstrFlagOn Then
											Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorYellow")
											newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorYellow)
											Dim cellRange As CellRange = .GetCellRange(e.Row, CMlngColWashUseNum)
											cellRange.Style = newStyle

										Else
											'背景色を白に戻す
											Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorWhite")
											newStyle.BackColor = Color.White         '初期（白）
											Dim cellRange As CellRange = .GetCellRange(e.Row, CMlngColWashUseNum)
											cellRange.Style = newStyle

										End If

										'ホルダーID列を選択
										.Select(e.Row,　CMlngColHolderId)
										mblnGuideIdSelectFlag = false
										mblnHolderIdSelectFlag = true

									End If
								'ホルダIDの場合はWASH_USE_NUM設定
								Else If e.Col = CMlngColHolderId And lblnCancel = False Then
									.SetData(e.Row, CMlngColHolderWashUseNum, ltypJJigList.strWashUseNum)
									'使用回数+10 >= 上限回数だった場合は,「使用回数」列の背景色を黄色にする
									if CLng(ltypJJigList.strWashUseNum)+10 >= CLng(ltypJJigList.strWashUseLimit) Then
										Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorYellow")
										newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorYellow)
										Dim cellRange As CellRange = .GetCellRange(e.Row, CMlngColHolderWashUseNum)
										cellRange.Style = newStyle

									Else
										'白に戻す
										Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorWhite")
										newStyle.BackColor = Color.White         '初期（白）
										Dim cellRange As CellRange = .GetCellRange(e.Row, CMlngColHolderWashUseNum)
										cellRange.Style = newStyle

									End If
								End If

							Else
								'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
								Call pubResponseCancel(Me.Name, mstrEventName)
						
					
							End If

						Else If e.Col = CMlngColJigId Then
							'ガイドリングIDが空になった場合はマスクID、ホルダIDを消す。ﾁｪｯｸが入っていたら消す
							.SetData(e.Row, CMlngColMaskID, vbNullString)
							.SetData(e.Row, CMlngColWashUseNum, vbNullString)
							.SetData(e.Row, CMlngColBeforJigId, vbNullString)
							.SetData(e.Row, CMlngColHolderID, vbNullString)
							.SetData(e.Row, CMlngColHolderWashUseNum, vbNullString)
							mstrLastHolderId = vbNullString

						Else If e.Col = CMlngColHolderId Then
							'ホルダIDが空になった場合
							.SetData(e.Row, CMlngColHolderWashUseNum, vbNullString)
							mstrLastHolderId = vbNullString
						End If
                    End If

                End If
            End With

			'@ﾚｽﾎﾟﾝｽ取得終了
			Call publngResponseEnd(Me.Name, mstrEventName)

            '@初期化
            With ltypjJigChk
                .strSbID = vbNullString
                .strjigId = vbNullString
                .strJJigCategory = vbNullString

            End With
            
            '@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
            Call prvsubcmdRegist_Chk()
            
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMapStck_BeforeEdit"
                .strErrMessage = vbNullString
            End With
			'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
			Call pubResponseCancel(Me.Name, mstrEventName)
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMapStck_Click
    '機　能：
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/10 (Thu) 15:43:29 K.Nishizawa
    '更新日：2009/06/10 (Thu) 15:43:29
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

			With vsfSlotMapStck
			'@ﾀｲﾄﾙ行でなければ処理
            If .Row > CMlngSlotMapRowTitle Then
					If .Col = CMlngColSelect Then
						'ホルダIDが入力されている→WF,ガイドリング、マスクも入力されている
						If .GetData(.Row, CMlngColHolderID) <> vbNullString  Then
							'.AllowEditing = True
							'ﾁｪｯｸを切り替える
							If .GetCellCheck(.Row,CMlngColSelect) = CheckEnum.Checked Then
								.SetCellCheck(.Row,CMlngColSelect, CheckEnum.Unchecked)
							Else
								.SetCellCheck(.Row,CMlngColSelect, CheckEnum.checked)
							End If
							'@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
							Call prvsubcmdRegist_Chk()
						Else
							'入力されていない行は編集不可
							'.AllowEditing = False
						End if
						

					End If
				End if
			End With

            '@分割元ｽﾛｯﾄﾏｯﾌﾟEnterCellｲﾍﾞﾝﾄ
            Call vsfSlotMapStck_EnterCell(vsfSlotMapStck, New EventArgs)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMapStck_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMapStck_EnterCell
    '機　能：空治具選択ﾎﾞﾀﾝ制御
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/07 (Wed) 11:20:27 N.Kasai
    '更新日：2012/12/05 (Wed) 09:57:25 T.Oide
    '備　考：
    Private Sub vsfSlotMapStck_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMapStck.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMapStck.Rows.Count <= vsfSlotMapStck.Rows.Fixed Then
                Return
            End If

            If mblnEventCancelFlag = True Then
                Exit Sub
            End If

            '@JIG_IDの登録ﾌｫｰﾑ作成
            With vsfSlotMapStck
                
                .Redraw = False
                '@ﾀｲﾄﾙ行でなければ処理
                If .Row > CMlngSlotMapRowTitle Then
                    '@WF_IDが空でなければ、治具IDのｾﾙを編集状態にする
                    If .GetData(.Row, CMlngColWFID) <> vbNullString And _
						.GetData(.Row, CMlngColJigWfSet) = vbNullString Then
                        If .Col = CMlngColJigId Then
                            .Select(.Row, CMlngColJigId)
                            .Styles.Editor.BackColor = SystemColors.Window
                            .Styles.Editor.ForeColor = SystemColors.WindowText
                            .Styles.Highlight.BackColor = SystemColors.Window
                            .Styles.Highlight.ForeColor = SystemColors.WindowText
                            .StartEditing()
							mblnGuideIdSelectFlag = true
							mblnHolderIdSelectFlag = false
							'@空治具選択ﾎﾞﾀﾝを有効にする
							cmdJigSelect.Enabled = True
							'@選択中の列のホルダIdの編集前の値を取得する
							mstrLastHolderId = .GetData(.Row, CMlngColHolderID)
                        Else If .Col = CMlngColMaskId Then
							’マスクID列は編集不可	
							.AllowEditing = False
							.Styles.Highlight.BackColor = SystemColors.Highlight
							.Styles.Highlight.ForeColor = SystemColors.Window
							mblnGuideIdSelectFlag = false
							mblnHolderIdSelectFlag = false
							'@空治具選択ﾎﾞﾀﾝを無効にする
							cmdJigSelect.Enabled = False
							'@選択中の列のホルダIdの編集前の値を取得する
							mstrLastHolderId = .GetData(.Row, CMlngColHolderID)
						Else If .Col = CMlngColHolderID Then
							If .GetData(.Row, CMlngColJigID) <> vbNullString And _
								.GetData(.Row, CMlngColJigWfSet) = vbNullString Then
								’ガイドリングが入力されていればホルダID列は編集可	
								.Select(.Row, CMlngColHolderId)
								.Styles.Editor.BackColor = SystemColors.Window
								.Styles.Editor.ForeColor = SystemColors.WindowText
								.Styles.Highlight.BackColor = SystemColors.Window
								.Styles.Highlight.ForeColor = SystemColors.WindowText
								.StartEditing()
								mblnGuideIdSelectFlag = false
								mblnHolderIdSelectFlag = true
								'@空治具選択ﾎﾞﾀﾝを有効にする
								cmdJigSelect.Enabled = True
								'@選択中の列のホルダIdの編集前の値を取得する
								mstrLastHolderId = .GetData(.Row, CMlngColHolderID)
							Else
								.AllowEditing = False
								.Styles.Highlight.BackColor = SystemColors.Highlight
								.Styles.Highlight.ForeColor = SystemColors.Window
								mblnGuideIdSelectFlag = false
								mblnHolderIdSelectFlag = false
								'@空治具選択ﾎﾞﾀﾝを無効にする
								cmdJigSelect.Enabled = False
								'@選択中の列のホルダIdの編集前の値を取得する
								mstrLastHolderId = .GetData(.Row, CMlngColHolderID)
							End if
						


						Else
                            .Styles.Highlight.BackColor = SystemColors.Highlight
                            .Styles.Highlight.ForeColor = SystemColors.Window
                        End If

                    Else
                        .AllowEditing = False
                        .Styles.Highlight.BackColor = SystemColors.Highlight
                        .Styles.Highlight.ForeColor = SystemColors.Window
                        '@空治具選択ﾎﾞﾀﾝを無効にする
                        cmdJigSelect.Enabled = False
                    End If
                    
                    ''@治具WF紐付けが入っていたら取消取外ﾎﾞﾀﾝを有効にする
                    'If .GetData(.Row, CMlngColJigWfSet) <> vbNullString Then
                    '    cmdClear.Enabled = True
                    'Else
                    '    cmdClear.Enabled = False
                    'End If
                End If
                .Redraw = True

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMapStck_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 13:50:34 K.Nishizawa
    '更新日：2005/04/01 (Fri) 10:32:05 N.Kojima
    '備　考：2004/09/10 (Fri) 09:23:43 K.Nishizawa  不具合対応(№358)
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean          '結果取得(True:正常,False:異常)
        Dim lstrtmpCarrierId        As String           'ｷｬﾘｱID退避用
        Dim ltypWfJigSetReq         As JigSetInf        '要求Msgｵﾌﾞｼﾞｪｸﾄ


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

            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnInput_Chk()
            If lblnAns = False Then
                '@不正項目あり
                Exit Sub
            End If

			'次回在庫準備確認
			prvChkNextStockReady()


            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If

            Call lprvgetWfwithJigInfo_Set(ltypWfJigSetReq)

            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "cmdUseChange_Click"
            'Call pubResponseStart(Me.Name, mstrEventName)

            lstrtmpCarrierId = txtCarrier.Text
            '@Msg送信処理実行
			'機種の確認含む
            lblnAns = pubblnWaferJigSet_Upd(CMstrwf_jigsetVer, CMstrJigStatusUsing, CMstrJigEventIdJigWfSet, ltypWfJigSetReq)

            '@結果判定
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                'Call publngResponseEnd(Me.Name, mstrEventName)

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005B)
                Call pubVsfInfo_Disp(pstrDMsg)

                '@画面の初期化
                Call prvfrmxxEN02F0_Init()

                '@再ロード
                txtCarrier.Text = lstrtmpCarrierId
                RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(True))
                AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate

            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
            End If

            '@ﾌｫｰｶｽ制御
            '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            'Call pubSetFocus(txtCarrier)

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

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱIDのValidateｲﾍﾞﾝﾄ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/06/09 (Tue) 15:56:42 K.Nishizawa
    '更新日：2013/05/16 (Thu) 15:53:16 T.Oide
    '備　考：
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAns                         As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotprestate                 As Lotprestate          'ﾛｯﾄ現在状態格納構造体
        Dim lstrCarriaName                  As String               'ｷｬﾘｱID欄名
        Dim ltypWaferList                   As Waferlist            'WF情報格納用構造体
		Dim ltypJigWfSetList                As JigWfSetlist         '治具WF紐付け情報格納用構造体
        Dim lblnAns2                        As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotAttribute                As LotAttribute         'ﾛｯﾄ属性情報格納

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDが空白の場合は処理を行わない。
            If Trim(txtCarrier.Text) = vbNullString Then               
                Exit Sub
            End If

            '@投入予定ｷｬﾘｱIDの桁ﾁｪｯｸ
            If LenB(txtCarrier.Text) < CPlngCarrierMaxLength Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)

                '@"ｷｬﾘｱIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                e.Cancel = True

                '@ｷｬﾘｱIDにﾌｫｰｶｽ移動
                If ActiveControl.Name = txtCarrier.Name Then
                    Call pubSetFocus(txtCarrier)
                End If

                Exit Sub
            End If

            '@ｷｬﾘｱID情報の取得
            lstrCarriaName = txtCarrier.Text
            If Trim$(lstrCarriaName) <> vbNullString And _
                Len(Trim(lstrCarriaName)) = txtCarrier.ChrMaxByte Then

                '@ﾚｽﾎﾟﾝｽ用ｲﾍﾞﾝﾄ名格納
                mstrEventName = "txtCarrier_Validate"

                '@ﾚｽﾎﾟﾝｽ測定開始
                Call pubResponseStart(Me.Name, mstrEventName)

                '@DBからﾛｯﾄ情報の取得
                ltypLotprestate = New Lotprestate
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD4H, lstrCarriaName, ltypLotprestate)

                If lblnAns = False Then
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True

                    '@ﾚｽﾎﾟﾝｽ測定中止
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    Exit Sub
                End If

                '@要求ﾒｯｾｰｼﾞ格納
                ltypLotAttribute = New LotAttribute
                With ltypLotAttribute
                    .strMsgVer = CMstrlot_attributeVer
                    .strSbID = pstrSBID
                    .strReqCarrierID = ltypLotprestate.strCarrierId
                    .strReqLotID = ltypLotprestate.strLotID
                End With
                
                '@ﾛｯﾄ属性情報取得
                lblnAns2 = pubblnLotAttribute_Sel(ltypLotAttribute)

                '@結果判定
                If lblnAns = True And lblnAns2 = True Then
                
                    '@画面表示処理
                    Call prvfrmxxEN02F0_Disp(ltypLotprestate)

                    mblnTxtWfScanForEnabled = True

                    '@ｷｬﾘｱﾀｲﾌﾟID退避
                    mstrCarrierTypeID = ltypLotprestate.strCarrierTypeID
                    
                    '@ｶﾃｺﾞﾘｰ退避
                    mstrCategoryID = ltypLotprestate.strCarrierCategoryId

					'機種ID取得
					mstrpdId = ltypLotprestate.strPdId

                    '@CF(ODF)ﾛｯﾄか(この画面ではCF(TPAL)は来ない)
                    If ltypLotprestate.strLpFlag = "1" Then
                        '@CF(ODF)ﾛｯﾄの場合自分自身のｽｸﾘｰﾝｻｲｽﾞを渡す
                        mstrScreenSizeId = ltypLotprestate.strScreenSize        'ｽｸﾘｰﾝｻｲｽﾞ退避
                    Else
                        '@TFTﾛｯﾄの場合貼合せ相手のｽｸﾘｰﾝｻｲｽﾞを渡す
                        mstrScreenSizeId = ltypLotAttribute.strCfScreenSizeID   'ｽｸﾘｰﾝｻｲｽﾞ退避
                    End If
                    mstrCfFlag = ltypLotprestate.strCfFlag              'CFﾌﾗｸﾞ退避
                    mstrLpFlag = ltypLotprestate.strLpFlag              'Lpﾌﾗｸﾞ退避

                    '@ﾛｯﾄWF情報取得
                    lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, txtCarrier.Text, CPstrCD4H, ltypWaferList)
                    '@結果確認
                    If lblnAns = True Then
                        '@ｽﾛｯﾄｻｲｽﾞの設定
                        mlngVsfBottomRow = ltypWaferList.strSlotSize

                        '@最大行数の設定
                        mlngSlotMapRowS = ltypWaferList.strSlotSize + 1

						'治具WF紐付け情報取得
						Call prvGetJigWfSetList(ltypWaferList ,ltypJigWfSetList)

                        '@取得OKなら結果表示
                        Call prvvsfSlotMap_Set(ltypJigWfSetList)


                        '@表示頁設定
                        Call prvVsfSlotMapTopRow_Set()

                        With vsfSlotMapStck
                            '@1頁の行数を超えている場合
                            If .Rows.Count > CMlngSlotMapPageRows + 1 Then
                                '@頁の先頭行がﾃﾞｰﾀの先頭行の場合
                                If .TopRow = .Rows.Fixed Then
                                    '@ﾍﾟｰｼﾞﾎﾞﾀﾝの制御
                                    cmdUpStck.Enabled = False
                                    cmdDownStck.Enabled = True
                                Else
                                    '@ﾍﾟｰｼﾞﾎﾞﾀﾝの制御
                                    cmdUpStck.Enabled = True
                                    cmdDownStck.Enabled = False
                                End If
                            Else
                                '@ﾍﾟｰｼﾞﾎﾞﾀﾝの制御
                                cmdUpStck.Enabled = False
                                cmdDownStck.Enabled = False
                            End If
                        End With

                        '作業待ち
                        If lblStatus.Text = CPstrWaitWorkSt Then
                            txtWfScan.Enabled = True
                            vsfSlotMapStck.Enabled = True
                            cmdEasyDivide.Enabled = True
                        Else
                            '読み取り専用の為、コントロールを無効
                            txtWfScan.Enabled = False
                            vsfSlotMapStck.Enabled = False
                            cmdEasyDivide.Enabled = False
                        End If
                        
                        '@ATLASﾌﾛｰﾅﾝﾊﾞｰ退避
                        pstrAtlasFlowNumber = ltypLotAttribute.strAtlasFlowNumber
                        
                        '@ﾚｽﾎﾟﾝｽ測定終了
                        Call publngResponseEnd(Me.Name, mstrEventName)
                        Call pubSetFocus(txtWfScan)

                    Else
                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                        e.Cancel = True

                        '@ﾚｽﾎﾟﾝｽ測定中止
                        Call pubResponseCancel(Me.Name, mstrEventName)
                        Exit Sub
                    End If
                Else
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True

                    '@ﾚｽﾎﾟﾝｽ測定中止
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    Exit Sub
                End If
            End If

            '作業開始/終了ボタンチェック
            Call prvsubWorkCmdEnabled_Chk()

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

    '関数名：cmdJigSelect_Click
    '機　能：空き治具選択
    '引　数：なし
    '戻り値：なし
    '作成日：2009/07/23 (Thu) 09:30:01 T.Oide
    '更新日：2013/04/19 (Fri) 14:33:42 T.Oide
    '備　考：
    '　　　：
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
                        
			'@治具ステータス引渡し
			pstrJigStatus = CMstrJigStatusCanUse              '使用可

			'@蒸着治具カテゴリ引渡し
			If mblnGuideIdSelectFlag = True Then
				'ガイドリングIDセルを選択した状態で空治具選択を押した場合
				mstrJJigCategoryID = CMstrCmbJJigCategoryGuideId
			Else If mblnHolderIdSelectFlag = True Then
				'マスクIDセルを選択した状態で空治具選択を押した場合
				mstrJJigCategoryID = CMstrCmbJJigCategoryHolderId
			Else
				mstrJJigCategoryID = vbNullString
			End If

            pstrJJigCategoryID = mstrJJigCategoryID                          '蒸着治具ｶﾃｺﾞﾘ

			pstrPDID = mstrpdId


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
                 
            ''@空き治具が選択されている場合
            'If pstrJigID <> vbNullString Then
            '    '@治具IDをｾｯﾄ
            '    vsfSlotMapStck.Redraw = False
            '    vsfSlotMapStck.SetData(vsfSlotMapStck.Row, CMlngColJigId, pstrJigID)
            '    vsfSlotMapStck.Redraw = True
            '    '@治具ﾁｪｯｸ
            '    Call vsfSlotMapStck_AfterEdit(vsfSlotMapStck, New RowColEventArgs(vsfSlotMapStck.Row, CMlngColJigId))
                
            'End If
			If pstrJigID <> vbNullString Then
				'@ガイドリングIDが選択されている場合
				If mblnGuideIdSelectFlag = true Then
					'@治具IDをｾｯﾄ
					vsfSlotMapStck.Redraw = False
					vsfSlotMapStck.SetData(vsfSlotMapStck.Row, CMlngColJigId, pstrJigID)
					vsfSlotMapStck.Redraw = True
					Call vsfSlotMapStck_AfterEdit(sender, New RowColEventArgs(vsfSlotMapStck.Row, CMlngColJigId))
				Else If  mblnHolderIdSelectFlag = true Then
					'@治具IDをｾｯﾄ
					vsfSlotMapStck.Redraw = False
					vsfSlotMapStck.SetData(vsfSlotMapStck.Row, CMlngColHolderId, pstrJigID)
					vsfSlotMapStck.Redraw = True
					Call vsfSlotMapStck_AfterEdit(sender, New RowColEventArgs(vsfSlotMapStck.Row, CMlngColHolderId))
				End If
			End If
            
            '@治具ID格納変数初期化
            pstrJigID = vbNullString
            mstrJJigCategoryID = vbNullString
            pstrJJigCategoryID = vbNullString
			pstrJigStatus = vbNullString
			pstrPDID = vbNullString

            '@治具にﾌｫｰｶｽｾｯﾄ
            If vsfSlotMapStck.Editor Is Nothing Then
                'NSYS エラー発生後、編集モードになっている(.Editorがある)時にSetFocusすると編集モードがキャンセルされる
                'NSYS 編集モードでない場合のみ、フォーカスをうつす
                Call pubSetFocus(vsfSlotMapStck)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdJigSelect_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub



    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '========================================Private========================================
    '関数名：prvfrmxxEN02F0_Init
    '機　能：各ｵﾌﾞｼﾞｪｸﾄの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/05 (Fri) 15:24:20 K.Nishizawa
    '更新日：2009/07/24 (Fri) 13:12:37 T.Oide
    '備　考：
    Private Sub prvfrmxxEN02F0_Init(Optional ByVal lblnCarrier As Boolean = True, _
                                    Optional ByVal lblnForReload As Boolean = False)

        Dim lstrFormTitle       As String

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02F0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            

            If lblnCarrier Then
                txtCarrier.Text = vbNullString
            End If
            
            '@各ﾗﾍﾞﾙの初期化
            lblLotID.Text = vbNullString
            lblFlowClass.Text = vbNullString
            lblStatus.Text = vbNullString
            lblWFNo.Text = vbNullString
            lblOpID.Text = vbNullString
            lblStepID.Text = vbNullString
            
            '@"WFスキャン"ﾃｷｽﾄﾎﾞｯｸｽ無効
            If lblnForReload = False Then
                With txtWfScan
                    .Enabled = False
                    .BackColor = SystemColors.ControlLight
                End With
            End If
            
            '@ウェハーIDスキャン待ち
            mblnWFIDScanWait = True
            
            '@ｸﾞﾘｯﾄﾞの設定
            With vsfSlotMapStck
                'NSYS 描画ﾛｯｸ
                .Redraw = False
                .Clear
                .HighLight = HighLightEnum.WithFocus
                '@列幅設定
                .Cols(CMlngColSlot).Width = CMlngColSlotWidth
                .Cols(CMlngColWFID).Width = CMlngColWFIDWidth
                .Cols(CMlngColJigId).Width = CMlngColJigIdWidth
                .Cols(CMlngColBeforJigId).Width = CMlngColBeforJigIdWidth
                .Cols(CMlngColSelect).Width = CMlngColSelectWidth
                .Cols(CMlngColMaskID).Width = CMlngColMaskIDWidth
                .Cols(CMlngColWashUseNum).Width = CMlngColWashUseNumWidth
                .Cols(CMlngColHolderID).Width = CMlngColHolderIDWidth
                .Cols(CMlngColHolderWashUseNum).Width = CMlngColHolderWashUseNumWidth
                .Cols(CMlngColJigWfSet).Width = CMlngColJigWfSetWidth
                .Cols(CMlngColBeforJigId).Visible = false
				.Cols(CMlngColWashUselimit).Visible = false
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngSlotMapRowTitle, CMlngColSlot, CMstrSlotMapColTSlot)
                .SetData(CMlngSlotMapRowTitle, CMlngColWFID, CMstrSlotMapColTWFID)
                .SetData(CMlngSlotMapRowTitle, CMlngColJigId, CMstrSlotMapColTJigID)
                .SetData(CMlngSlotMapRowTitle, CMlngColBeforJigId, CMstrSlotMapColTBeforJigID)
                .SetData(CMlngSlotMapRowTitle, CMlngColSelect, CMstrSlotMapColTSelect)
                .SetData(CMlngSlotMapRowTitle, CMlngColMaskID, CMstrSlotMapColTMaskID)
                .SetData(CMlngSlotMapRowTitle, CMlngColWashUseNum, CMstrSlotMapColTWashUseNum)
				.SetData(CMlngSlotMapRowTitle, CMlngColWashUseLimit, CMstrSlotMapColTWashUseLimit)
                .SetData(CMlngSlotMapRowTitle, CMlngColHolderID, CMstrSlotMapColTHolderID)
                .SetData(CMlngSlotMapRowTitle, CMlngColHolderWashUseNum, CMstrSlotMapColTHolderWashUseNum)
                .SetData(CMlngSlotMapRowTitle, CMlngColJigWfSet, CMstrSlotMapColTJigWfSet)


                '@ﾀｲﾄﾙﾊﾞｯｸｶﾗｰ設定
                '@ﾀｲﾄﾙﾌｫﾝﾄｶﾗｰ設定
                Dim cellRange As CellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngColSlot, CMlngSlotMapRowTitle, CMlngColJigWfSet)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow
                headerStyle.BackColor =  ColorTranslator.FromWin32(CPlngBlueColor)
                With .Styles.Normal.Font
                    headerStyle.Font = New Font(.FontFamily, CMlngSlotHMaCellFontSize, .Style, .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                headerStyle.TextAlign = TextAlignEnum.CenterCenter
                cellRange.Style = headerStyle
                '@ﾀｲﾄﾙ行のみ表示
                .Rows.Count = CMlnStartGridRows

                'NSYS 描画ﾛｯｸ
                .Redraw = True

                If lblnForReload = False Then
                    .Enabled = False
                End If
            End With
            
            'ｺﾏﾝﾄﾞﾎﾞﾀﾝ無効
            cmdEasyDivide.Enabled = False
            cmdRegist.Enabled = False
            cmdClear.Enabled = False
            cmdUpStck.Enabled = False
            cmdDownStck.Enabled = False
            cmdJigSelect.Enabled = False
            cmdWorkStart.Enabled = False
            cmdWorkEnd.Enabled = False

            '@簡易分割識別
            pblnMkEasyDivFlag = False
            pblnfrmxxEN02F0kbn = False
            
            pblnFormLoad = True
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02F0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN02F0_Disp()
    '機　能：Svr取得結果を表示
    '引　数：ﾛｯﾄ情報 Lotprestate
    '戻り値：なし
    '作成日：2009/06/05 (Fri) 15:24:20 K.Nishizawa
    '更新日：2009/06/05 (Fri) 15:24:20 K.Nishizawa
    '備　考：
    Private Sub prvfrmxxEN02F0_Disp(ByRef ltypLotprestate As Lotprestate)
        
        Try
            
            With ltypLotprestate
                lblLotID.Text = .strLotID
                lblFlowClass.Text = .strFlowClass
                lblWFNo.Text = .strWfNum
                lblStatus.Text = .strNowST
                lblOpID.Text = .strOpID
                lblStepID.Text = .strStepID
            End With

            '"WFスキャン"ﾃｷｽﾄﾎﾞｯｸｽを有効化
            With txtWfScan
                .Enabled = True
                .BackColor = Color.White
            End With

            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02F0_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：prvvsfSlotMap_Set
    '機　能：ｽﾛｯﾄ情報の取得
    '引　数：ｽﾛｯﾄ情報 Waferlist
    '      ：Grid Object
    '戻り値：なし
    '作成日：2009/06/05 (Fri) 15:24:20 K.Nishizawa
    '更新日：2009/06/05 (Fri) 15:24:20 K.Nishizawa
    '備　考：
    Private Sub prvvsfSlotMap_Set(ByRef ltypJigWfSetList As JigWfSetlist)
                            
        Dim llngRowCnt                      As Integer
        Dim llngCnt                         As Integer
        Dim llngWriteRow                    As Integer
		Dim llngBottomRow					As Integer

        Try
                
            With vsfSlotMapStck
                'NSYS 描画ﾛｯｸ
                .Redraw = False

                .Enabled = True
                .Rows.Count = ltypJigWfSetList.strSlotSize + 1
                
                '@ｽﾛｯﾄﾏｯﾌﾟのﾃﾞｰﾀ分繰り返し(ﾃﾞｰﾀ表示)
                For llngCnt = 0 To ltypJigWfSetList.lngJigWfSetCnt - 1
                    llngWriteRow = ltypJigWfSetList.strSlotSize + 1 - CLng(ltypJigWfSetList.typJigWfSet(llngCnt).strSlotPosition)
                    .SetData(llngWriteRow, CMlngColWFID, ltypJigWfSetList.typJigWfSet(llngCnt).strWfId)							'WF_ID
					.SetData(llngWriteRow, CMlngColJigId, ltypJigWfSetList.typJigWfSet(llngCnt).strGuideId)						'ガイドリングID
                    .SetData(llngWriteRow, CMlngColBeforJigId, ltypJigWfSetList.typJigWfSet(llngCnt).strGuideId)				'変更前治具ID
					.SetData(llngWriteRow, CMlngColMaskID, ltypJigWfSetList.typJigWfSet(llngCnt).strMaskId)						'マスクID
					.SetData(llngWriteRow, CMlngColWashUseNum, ltypJigWfSetList.typJigWfSet(llngCnt).strWashUseNum)				'洗浄後使用回数
					.SetData(llngWriteRow, CMlngColWashUseLimit, ltypJigWfSetList.typJigWfSet(llngCnt).strWashUseLimit)				'洗浄後使用上限回数
					.SetData(llngWriteRow, CMlngColHolderID, ltypJigWfSetList.typJigWfSet(llngCnt).strHolderId)					'ホルダID
					.SetData(llngWriteRow, CMlngColHolderWashUseNum, ltypJigWfSetList.typJigWfSet(llngCnt).strHolderWashUseNum) 'ホルダ洗浄後使用回数

					'紐付け済みの場合
					If ltypJigWfSetList.typJigWfSet(llngCnt).strHolderId <> vbNullString Then

						


						'在庫準備フラグOFF　かつ　使用回数+10 >= 上限回数だった場合は,「使用回数」列の背景色を黄色にする
						if CLng(ltypJigWfSetList.typJigWfSet(llngCnt).strWashUseNum)+10 >= _
								CLng(ltypJigWfSetList.typJigWfSet(llngCnt).strWashUseLimit)　And _
							ltypJigWfSetList.typJigWfSet(llngCnt).strNextStockReadyFlag <> CPstrFlagOn Then
							Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorYellow")
							newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorYellow)
							Dim cellRange As CellRange = .GetCellRange(llngWriteRow, CMlngColWashUseNum)
							cellRange.Style = newStyle
						End If

						'ホルダーは次回在庫準備フラグがないため使用回数+10 >= 上限回数だった場合は,「使用回数」列の背景色を黄色にする
						if CLng(ltypJigWfSetList.typJigWfSet(llngCnt).strHolderWashUseNum)+10 >= CLng(ltypJigWfSetList.typJigWfSet(llngCnt).strHolderWashUseLimit)　 Then
							Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorYellow")
							newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorYellow)
							Dim cellRange As CellRange = .GetCellRange(llngWriteRow, CMlngColHolderWashUseNum)
							cellRange.Style = newStyle
						End If

						'ホルダIDが最初から入っていたらWF紐付け済
						.SetData(llngWriteRow, CMlngColJigWfSet, "済")



					End If
                    .Rows(llngWriteRow).Height = CMlngSlotMapHeight
                Next

				'背景白用選択列
				Dim selectStyle As CellStyle = .Styles.Add("selectStyle")
				selectStyle.ImageAlign = TextAlignEnum.CenterCenter
				Dim cellRange1 = .GetCellRange(1, CMlngColSelect, .Rows.Count- 1, CMlngColSelect)
                cellRange1.Style = selectStyle



                '@ｸﾞﾘｯﾄﾞの行数分繰り返し
                llngWriteRow = .Rows.Count
                For llngRowCnt = 1 To .Rows.Count - 1
                    llngWriteRow = llngWriteRow - 1
                    .SetData(llngWriteRow, CMlngColSlot, Format$(llngRowCnt, CPstrSlotNoFormat))
					.SetCellCheck(llngWriteRow, CMlngColSelect, CheckEnum.Unchecked)
                    If .GetData(llngRowCnt, CMlngColWFID) = vbNullString Then
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbInactiveTitleBar")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                        Dim cellRang3 As CellRange = .GetCellRange(llngRowCnt, CMlngColSelect, llngRowCnt, CMlngColJigWfSet)
                        cellRang3.Style = newStyle
						
						'背景灰色用選択列
						Dim selectStyle2 As CellStyle = .Styles.Add("selectStyle2")
						selectStyle2.ImageAlign = TextAlignEnum.CenterCenter
						selectStyle2.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
						Dim cellRange4 As CellRange = .GetCellRange(llngRowCnt, CMlngColSelect, llngRowCnt, CMlngColJigWfSet)
                        cellRange4.Style = selectStyle2

                        .Rows(llngRowCnt).Height = CMlngSlotMapHeight

					Else
						'データのある最下行取得
						llngBottomRow = llngRowCnt
                    End If

					If .GetData(llngRowCnt,CMlngColJigWfSet) <> vbNullString Then
						'治具WF紐付け列用
						Dim jigWfSetStyle As CellStyle = .Styles.Add("jigWfSetStyle")
						jigWfSetStyle.TextAlign = TextAlignEnum.CenterCenter
						jigWfSetStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorYellow)
						Dim cellRange2 = .GetCellRange(llngRowCnt, CMlngColJigWfSet, llngRowCnt, CMlngColJigWfSet)
						cellRange2.Style = jigWfSetStyle

					End If



                Next

                'NSYS No.列
                Dim slotNoStyle As CellStyle = .Styles.Add("slotNoStyle")
                slotNoStyle.BackColor = System.Drawing.SystemColors.ControlLight
                slotNoStyle.TextAlign = TextAlignEnum.LeftCenter
                Dim cellRange5 = .GetCellRange(1, CMlngColSlot, .Rows.Count- 1, CMlngColSlot)
                cellRange5.Style = slotNoStyle

				'kkw 組立投入WF枚数変更
				If llngBottomRow > 15 Then
					.TopRow = 16
				Else If llngBottomRow <= 15 And llngBottomRow > 5 
					.TopRow = 16
				Else
					.TopRow = 16

				End If


				'NSYS 描画ﾛｯｸ
				.Redraw = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMapTopRow_Set
    '機　能：ｽﾛｯﾄ情報の表示位置設定
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/05 (Fri) 15:24:20 K.Nishizawa
    '更新日：2009/06/05 (Fri) 15:24:20 K.Nishizawa
    '備　考：
    Private Sub prvVsfSlotMapTopRow_Set()
        
        Dim llngRowCnt              As Integer
        Dim llngCnt                 As Integer
        Dim lbln1_10Flag            As Boolean
		Dim lbln11_15Flag           As Boolean


        Try
            
            With vsfSlotMapStck
                llngRowCnt = .Rows.Count
                .Row = .Rows.Fixed - 1
                If llngRowCnt < CMlngSlotMapRowS Then
                    '@ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Fixed - 1
                    Exit Sub
                End If
                
				'kkw 組立投入WF枚数変更
                '@ｽﾛｯﾄ№01～10まで
                For llngCnt = CMlngSlotMapRowS - 1 To CMlngSlotMapSlotNo10Row Step -1
                    '@WFが存在する場合
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        '@WFあり
                        lbln1_10Flag = True
                        Exit For
                    End If
                Next llngCnt
                
				'@ｽﾛｯﾄ№01～10にWFがない場合
                If lbln1_10Flag = False Then
                    '@ｽﾛｯﾄ№15～11まで
                    For llngCnt = CMlngSlotMapSlotNo15Row  To CMlngSlotMapSlotNo11Row 
                        '@WFが存在する場合
                        If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                            '@ｽﾛｯﾄﾏｯﾌﾟの初期表示は上部
                            lbln11_15Flag = True
                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@ｽﾛｯﾄﾏｯﾌﾟの初期表示は下部
                    lbln11_15Flag = False
                End If

 
                
                '@ｽﾛｯﾄﾏｯﾌﾟ上部表示の場合
                If lbln1_10Flag = True Then
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟの頁先頭行を設定
                    .TopRow = CMlngSlotMapSlotNo10Row
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Fixed - 1
                Else If lbln11_15Flag = True
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟの頁先頭行を設定
                    .TopRow = CMlngSlotMapSlotNo20Row
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Fixed - 1
				Else
					'@分割元ｽﾛｯﾄﾏｯﾌﾟの頁先頭行を設定
                    .TopRow = .Rows.Fixed
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Fixed - 1

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

    '関数名：prvblnInput_Chk
    '機　能：ｽﾛｯﾄ情報の表示位置設定
    '引　数：なし
    '戻り値：TRUE:成功 FALSE:失敗
    '作成日：2009/06/05 (Fri) 15:24:20 K.Nishizawa
    '更新日：2009/06/05 (Fri) 15:24:20 K.Nishizawa
    '備　考：
    Private Function prvblnInput_Chk() As Boolean
        
        Try
            
			Dim llngRowCnt		As Integer

            prvblnInput_Chk = False
            
            '@ロットIDが空だったら処理中断
            If (lblLotID.Text = vbNullString) Then
                Exit Function
            End If

			With vsfSlotMapStck
			
				For llngRowCnt = 1 To .Rows.Count - 1
				'@ﾁｪｯｸが入っていてWFが入力されている行は、治具IDが10文字入力されているか
					If .GetCellCheck(llngRowCnt, CMlngColSelect) = CheckEnum.Checked Then
						If .GetData(llngRowCnt, CMlngColJigId) = vbNullString Or _
							Len(.GetData(llngRowCnt, CMlngColJigId)) <> 10 Or _
							.GetData(llngRowCnt, CMlngColMaskId) = vbNullString Or _ 
							Len(.GetData(llngRowCnt, CMlngColMaskId)) <> 10 Or _
							.GetData(llngRowCnt, CMlngColHolderId) = vbNullString Or _ 
							Len(.GetData(llngRowCnt, CMlngColHolderId)) <> 10 Then
                
							Exit Function
						
						End If

					End If
				Next
		
			End With
            
            prvblnInput_Chk = True
            
            Exit Function
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInput_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：lprvgetWfwithJigInfo_Set
    '機　能：ﾃﾞｰﾀをMsg専用構造体に取得
    '引　数：ltypWfJigSetReq：Msg要求構造体
    '戻り値：なし
    '作成日：2009/06/05 (Fri) 15:24:20 K.Nishizawa
    '更新日：2009/06/05 (Fri) 15:24:20 K.Nishizawa
    '備　考：
    Private Sub lprvgetWfwithJigInfo_Set(ByRef ltypWfJigSetReq As JigSetInf)

        Dim llngCnt                 As Integer
        Dim llngRowCnt              As Integer
        
        Try
			
			If IsNothing(ltypWfJigSetReq.typWfList) Then
                ltypWfJigSetReq.typWfList = New List(Of JigWfList)
            Else
                ltypWfJigSetReq.typWfList.Clear()
            End If
            

            ltypWfJigSetReq.strEmpID = pstrUserID
            ltypWfJigSetReq.strLotID = lblLotID.Text
            ltypWfJigSetReq.strSbID = pstrSBID
            llngCnt = 0

            With vsfSlotMapStck
                For llngRowCnt = 1 To .Rows.Count - 1

					'ﾁｪｯｸがONの行のみ対象
					If .GetCellCheck(llngRowCnt, CMlngColSelect) = CheckEnum.Checked Then
						If .GetData(llngRowCnt, CMlngColWFID) <> vbNullString Then
							If llngCnt = 0 Then
								If IsNothing(ltypWfJigSetReq.typWfList) Then
									ltypWfJigSetReq.typWfList = New List(Of JigWfList)
								Else
									ltypWfJigSetReq.typWfList.Clear()
								End If
							End If
							Dim typWfListTmp As JigWfList = New JigWfList
							typWfListTmp.strWfId = .GetData(llngRowCnt, CMlngColWFID)
							typWfListTmp.strGuideId = .GetData(llngRowCnt, CMlngColJigId)
							typWfListTmp.strMaskId = .GetData(llngRowCnt, CMlngColMaskId)
							typWfListTmp.strHolderId = .GetData(llngRowCnt, CMlngColHolderId)
							ltypWfJigSetReq.typWfList.Add(typWfListTmp)
							llngCnt = llngCnt + 1
						End If
					End If
                Next
            End With
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "lprvgetWfwithJigInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvsubcmdRegist_Chk
    '機　能：有効/無効ﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2009/07/02 (Thu) 10:46:29 T.Oide
    '更新日：2012/12/07 (Fri) 11:20:27 T.Oide
    '備　考：
    Private Sub prvsubcmdRegist_Chk()
        
        Dim llngRowCnt              As Integer
        Dim blnChkSetAri            As Boolean
        Dim blnChkMiman             As Boolean
		Dim blnChkJigWfSet			As Boolean
        Dim blnChkCancelJigWfSet	As Boolean
        Try
            
           '@ﾁｪｯｸ方法修正
           ' 最低一箇所以上治具ID(10文字)が設定されていて、且つ、
           ' 不正な治具ID(10文字以外)の設定がなければチェックOKとする

            blnChkSetAri = False
            blnChkMiman = False
			blnChkJigWfSet = False
			blnChkCancelJigWfSet = False

           '@ｸﾞﾘｯﾄﾞの全ての行をﾁｪｯｸ
            For llngRowCnt = 1 To vsfSlotMapStck.Rows.Count - 1
                'ﾁｪｯｸが入った行が対象
				If vsfSlotMapStck.GetCellCheck(llngRowCnt,CMlngColSelect) = CheckEnum.Checked Then

					'@治具3つ全て埋まっているか
					If vsfSlotMapStck.GetData(llngRowCnt, CMlngColJigId) <> vbNullString And vsfSlotMapStck.GetData(llngRowCnt, CMlngColMaskId) <> vbNullString And vsfSlotMapStck.GetData(llngRowCnt, CMlngColHolderId) <> vbNullString Then
						'@設定あり
						blnChkSetAri = True
                    
						'@10文字じゃない治具ID設定はあるか
						If Len(vsfSlotMapStck.GetData(llngRowCnt, CMlngColJigId)) <> 10 And _
							Len(vsfSlotMapStck.GetData(llngRowCnt, CMlngColMaskId)) <> 10 And _
							Len(vsfSlotMapStck.GetData(llngRowCnt, CMlngColHolderId)) <> 10 Then

							'@10文字未満
							blnChkMiman = True
							Exit For
                        
						End If

						If  vsfSlotMapStck.GetData(llngRowCnt, CMlngColJigWfSet) = vbNullString Then
							blnChkJigWfSet = True
						Else
							blnChkCancelJigWfSet = True
						End If

					End If
                 
				End If   
            Next
                
            '@セット[あり]で10文字未満[なし]なら有効
            If blnChkSetAri = True And blnChkMiman = False Then
				'全て紐付け前の場合は確定のみ有効
				If blnChkJigWfSet = True And blnChkCancelJigWfSet = False Then
					cmdRegist.Enabled = True
					cmdClear.Enabled = False
				Else If blnChkJigWfSet = False And blnChkCancelJigWfSet = True Then
					'全て紐付け後の場合は紐付け解除のみ有効
					cmdRegist.Enabled = False
					cmdClear.Enabled = True
				Else
					'混在している場合は両方無効
					cmdRegist.Enabled = False
					cmdClear.Enabled = False
				End If
            Else
                cmdRegist.Enabled = False
				cmdClear.Enabled = False
            End If

			'作業開始/終了ボタンチェック
            Call prvsubWorkCmdEnabled_Chk()

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvsubcmdRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 作業開始/終了ボタン有効チェック
    ''' </summary>
    Private Sub prvsubWorkCmdEnabled_Chk()
        
        Dim lintRowCnt As Integer
        
        Try
            '初期化
            cmdWorkStart.Enabled = False
            cmdWorkEnd.Enabled = False

            '紐付けされているかﾁｪｯｸ
            For lintRowCnt = 1 To vsfSlotMapStck.Rows.Count - 1
                
                'WFIDがある行で治具WF紐付け列が全て済であること
                If vsfSlotMapStck.GetData(lintRowCnt, CMlngColWFID) <> vbNullString Then
                    If vsfSlotMapStck.GetData(lintRowCnt, CMlngColJigWfSet) = vbNullString Then
                        Exit Sub
                    End If
                End If
            Next

            '作業待ち
            If lblStatus.Text = CPstrWaitWorkSt Then
                '作業開始
                cmdWorkStart.Enabled = True
                Call pubSetFocus(cmdWorkStart)
            ElseIf lblStatus.Text = CPstrProcessingSt Then
                '作業終了
                cmdWorkEnd.Enabled = True
                Call pubSetFocus(cmdWorkEnd)
            End If

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvsubWorkCmdEnabled_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：prvGetJigWfSet
    '機　能：Wfﾃﾞｰﾀを元に紐づく治具情報を取得する
    '引　数：ltypWfJigSetReq：Msg要求構造体
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub prvGetJigWfSetList(ByRef ltypWaferListRep As Waferlist, ByRef ltypJigWfSetList As JigWfSetList)

        Dim llngCnt                         As Integer
		Dim llngListCnt						As Integer
		Dim lblnAns							As Boolean
		Dim lblnAns2						As Boolean
        Dim ltypJJigAns						As JJigList
		Dim ltypJJigAns2					As JJigList
        Try

			ltypJigWfSetList.typJigWfSet = New List(Of JigWfSet)
			ltypJigWfSetList.strSlotSize = ltypWaferListRep.strSlotSize
			llngListCnt = 0
            '@ｽﾛｯﾄﾏｯﾌﾟのﾃﾞｰﾀ分繰り返し(ﾃﾞｰﾀ表示)
            For llngCnt = 0 To ltypWaferListRep.lngListCnt - 1

				Dim ltypJigWfSetTemp As  New JigWfSet
				ltypJigWfSetTemp.strWfId = ltypWaferListRep.typWfList(llngCnt).strWfId					'WF_ID
				ltypJigWfSetTemp.strSlotPosition = ltypWaferListRep.typWfList(llngCnt).strSlotPosition	'スロットポジション
				ltypJigWfSetTemp.strGuideId = ltypWaferListRep.typWfList(llngCnt).strJigId			'治具ID
                If ltypJigWfSetTemp.strGuideId <> vbNullString Then
					'治具情報単体取得
					lblnAns = pubblnJJig_Sel(CMstrjig_jjiggetVer, _
											ltypJigWfSetTemp.strGuideId, _
											ltypJJigAns)
					if lblnAns = True Then
						'紐づくマスクIDを取得
						ltypJigWfSetTemp.strMaskId = ltypJJigAns.strSetMaskId
						ltypJigWfSetTemp.strWashUseNum = ltypJJigAns.strWashUseNum
						ltypJigWfSetTemp.strWashUseLimit = ltypJJigAns.strWashUseLimit
						ltypJigWfSetTemp.strNextStockReadyFlag = ltypJJigAns.strNextStockReadyFlag
						ltypJigWfSetTemp.strHolderId = ltypJJigAns.strSetHolderId

					Else
						ltypJigWfSetTemp.strMaskId = vbNullString
						ltypJigWfSetTemp.strWashUseNum = vbNullString
						ltypJigWfSetTemp.strWashUseLimit = vbNullString
						ltypJigWfSetTemp.strNextStockReadyFlag = vbNullString
						ltypJigWfSetTemp.strHolderId = vbNullString
					End If

                End If

				'ホルダの情報があれば取得する
				If ltypJigWfSetTemp.strHolderId <> vbNullString Then
					'治具情報単体取得
					lblnAns2 = pubblnJJig_Sel(CMstrjig_jjiggetVer, _
											ltypJigWfSetTemp.strHolderId, _
											ltypJJigAns2)
					if lblnAns2 = True Then
						'紐づくマスクIDを取得
						ltypJigWfSetTemp.strHolderWashUseNum = ltypJJigAns2.strWashUseNum
						ltypJigWfSetTemp.strHolderWashUseLimit = ltypJJigAns2.strWashUseLimit
					Else
						ltypJigWfSetTemp.strHolderWashUseNum = vbNullString
						ltypJigWfSetTemp.strHolderWashUseLimit = vbNullString
					End If

                End If

				
				ltypJigWfSetList.typJigWfSet.Add(ltypJigWfSetTemp)
                llngListCnt = llngListCnt + 1
                ltypJigWfSetList.lngJigWfSetCnt = llngListCnt


			Next

            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "lprvgetWfwithJigInfo_Set"
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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraFromLot.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfSlotMapStck.BeforeDoubleClick

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

        End If

    End Sub


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfSlotMapStck.KeyDownEdit

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
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfSlotMapStck.SetupEditor

        Try
            If TypeOf sender.Editor Is ComboBox
                '行の高さを変更
                Dim editor As ComboBox = CType(sender.Editor, ComboBox)
                editor.DrawMode = DrawMode.OwnerDrawFixed
                editor.DropDownHeight = 106
                editor.MaxDropDownItems = 12
            End If

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub

    '関数名：vsfSlotMapStck_LeaveEdit
    '機　能：分割元ｽﾛｯﾄﾏｯﾌﾟの編集モードから出た後
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2020/05/27 (Wed) 17:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub vsfSlotMapStck_LeaveEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfSlotMapStck.LeaveEdit
        
        Try

            With vsfSlotMapStck
                'NSYS 編集モードから出た後ハイライト表示を戻す
                .Styles.Highlight.BackColor = SystemColors.Highlight
                .Styles.Highlight.ForeColor = SystemColors.Window
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMapStck_LeaveEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：vsfSlotMapStck_ClearRow
    '機　能：エラー等で行をクリアする
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfSlotMapStck_ClearRow(ByVal Row As Integer, ByVal Col As Integer) 
        
        Try

            With vsfSlotMapStck
				If Col = CMlngColJigId  Then

					'背景色を白に戻す
					Dim newStyle As CellStyle = .Styles.Add			("CustomStyle_BackColor_CMlngBackColorWhite")
					newStyle.BackColor = Color.White         '初期（白）
					Dim cellRange As CellRange = .GetCellRange(Row,	CMlngColWashUseNum,Row,CMlngColHolderWashUseNum )
					cellRange.Style = newStyle
					.SetData(Row, CMlngColJigID, vbNullString)
					.SetData(Row, CMlngColBeforJigId, vbNullString)
					.SetData(Row, CMlngColMaskID, vbNullString)
					.SetData(Row, CMlngColWashUseNum, vbNullString)
					.SetData(Row, CMlngColWashUseLimit, vbNullString)
					.SetData(Row, CMlngColHolderID, vbNullString)
					.SetData(Row, CMlngColHolderWashUseNum, vbNullString)
				Else If Col = CMlngColHolderId Then
					'背景色を白に戻す
					Dim newStyle As CellStyle = .Styles.Add			("CustomStyle_BackColor_CMlngBackColorWhite")
					newStyle.BackColor = Color.White         '初期（白）
					Dim cellRange As CellRange = .GetCellRange(Row,CMlngColHolderWashUseNum)
					cellRange.Style = newStyle
					.SetData(Row, CMlngColHolderID, vbNullString)
					.SetData(Row, CMlngColHolderWashUseNum, vbNullString)
				End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMapStck_ClearRow"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：prvChkNextStockReady
    '機　能：次回在庫準備確認
    '引　数：なし
    '戻り値：TRUE:成功 FALSE:失敗
    '作成日：
    '更新日：
    '備　考：
    Private Sub prvChkNextStockReady()
        
        Try
            
			Dim llngRowCnt		As Integer

            


			With vsfSlotMapStck
			
				For llngRowCnt = 1 To .Rows.Count - 1
				'@ﾁｪｯｸが入っていて背景色が黄色（次回在庫準備がされておらず）、上限回数-1回の場合は警告を出す
					If .GetCellCheck(llngRowCnt, CMlngColSelect) = CheckEnum.Checked Then
						If .GetData(llngRowCnt, CMlngColWashUseNum) + 1 >= .GetData(llngRowCnt, CMlngColWashUseLimit) And .GetCellRange(.Row, CMlngColWashUseNum).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngBackColorYellow) Then 
							
							'@"<TRM188W>$$次回在庫準備されていない治具があります。ご注意ください。"
							pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0188)
							'@警告ﾒｯｾｰｼﾞ
							Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
							Exit Sub

						
						End If

					End If
				Next
		
			End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvChkNextStockReady"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

End Class
