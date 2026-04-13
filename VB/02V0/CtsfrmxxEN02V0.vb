'ﾌｧｲﾙ名：xxEN02V0.frm 
'説　明：蒸着マスク組立　メインフォーム
'作成日：
'更新日：
'備　考：
'　　　：
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02V0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02V0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02V0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02V0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02V0)
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

    Private Const CMstrLocalVersion							As String = "01.00"

    '@機能ID
    Private Const CMstrLocalMenuKey							As String = CPstrKeyEN02V0

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrjig_jusechkVer						As String = "01.00"         '治具使用可否判定
    Private Const CMstrjig_jmasksetVer						As String = "01.00"         '治具Waferｾｯﾄ


    '@治具状態
    Private Const CMstrJigStatusCanUse						As String = "0"             '使用可
	Private Const CMstrJigStatusRdyUseBeforeSetId			As String = "5"				'使用可(組前)

	'蒸着治具イベントID
	Private Const CMstrJigEventIdWash						As String = "1"				'洗浄
	Private Const CMstrJigEventIdWashComp					As String = "2"				'受入
	Private Const CMstrJigEventIdJMaskSet					As String = "5"				'蒸着マスク組立
	Private Const CMstrJigEventIdNotUse						As String = "3"				'使用不可
	Private Const CMstrJigEventIdScrap						As String = "4"				'廃却

    '@vsfJMaskSetListの定数宣言(ｶﾗﾑ)
    Private Const CMlngColNo								As Integer = 0              'No.
    Private Const CMlngColGuideId							As Integer = 1              'ガイドリングID
    Private Const CMlngColMaskId							As Integer = 2              'マスクID

    '@vsfJMaskSetListの定数宣言(表示幅)
    Private Const CMlngColNoWidth							As Integer = 30             'No.Width
    Private Const CMlngColGuideIdWidth						As Integer = 450			'ガイドリングIDWidth
    Private Const CMlngColMaskIdWidth						As Integer = 450			'マスクIDWidth

    '@vsfJMaskSetListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrColNo								As String = "No."			
    Private Const CMstrColGuideId							As String = "ガイドリングID"   
    Private Const CMstrColMaskId							As String = "マスクID"		

    '@vsfJMaskSetListの定数宣言(その他)
    Private Const CMlngGuideMaskListRowTitle				As Integer = 0              'ﾀｲﾄﾙ
    Private Const CMlngGuideMaskListHMaCellFontSize			As Integer = 12             'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngGuideMaskListRowS					As Integer = 11             '行数
    Private Const CMlngGuideMaskListHHeight					As Integer = 38             'ﾍｯﾀﾞｰの高さ
    Private Const CMlngGuideMaskListHeight					As Integer = 38             '1ｽﾛｯﾄの高さ

    Private Const CMlngMaxLength							As Integer = 10             '最大桁数
	Private Const CMlngStartEditRow							As Integer = 1				'編集開始行番号

    Private Const CMlnStartGridRows							As Integer = 1              'ｸﾞﾘｯﾄﾞの初期行数
    Private Const CMlngBackColorCel							As Integer = &H8000000D     'ｸﾞﾘｯﾄﾞのﾊﾞｯｸｶﾗｰｾﾙ(紺)

	Private Const CMstrCmbJJigCategoryGuideId				As String = "G"	
	Private Const CMstrCmbJJigCategoryMaskId				As String = "M"	

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '========================================Private========================================
    Private mstrEventName                       As String                   'ﾚｽﾎﾟﾝｽ用ｲﾍﾞﾝﾄ名
    Private mblnTakeOverDispFlg                 As Boolean                  '引継ぎ表示ﾌﾗｸﾞ
    Private mblnEventCancelFlag                 As Boolean                  'イベントキャンセルフラグ
    Private buttonProcessing                    As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                  'NSYS WindowCloseフラグ
    Private mblnTxtWfScanForEnabled             As Boolean                  'NSYS WAFERスキャンテキストボックス有効化か
    Private mblnGuideIdSelectFlag				As Boolean                  '空治具選択押下時の編集セル判別用
    Private mblnMaskIdSelectFlag				As Boolean                  '空治具選択押下時の編集セル判別用
	Private mstrJJigCategoryID                  As String                   '蒸着治具ｶﾃｺﾞﾘ
	Private mstrLastJigId						As String					'前回値


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
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02V0, CMstrLocalVersion)
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
            Call prvfrmxxEN02V0_Init()
			'ボタン有効無効ﾁｪｯｸ
			Call prvCmdButtonEnableChk()

            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            '@引継ぎ情報表示済みﾌﾗｸﾞ
            mblnTakeOverDispFlg = False
            
            Exit Sub

        Catch ex As Exception

			pblnFormLoad = False

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
            
            'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
            'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
            Dim lfuncActivate As Action = Sub()
            Me.Activate()
            End Sub
            Me.BeginInvoke(lfuncActivate)
            
			'初期セルを編集状態に
			vsfJMaskSetList.Select(CMlngStartEditRow, CMlngColGuideId)
			vsfJMaskSetList.StartEditing(CMlngStartEditRow,CMlngColGuideId)
			Call vsfJMaskSetList_Click(vsfJMaskSetList, New EventArgs)
            
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
            
            If ActiveControl.Name = vsfJMaskSetList.Name Then
                With vsfJMaskSetList
                    lintKeyCode = e.KeyCode
                    llngRow = .Row
                    llngTopRow = .TopRow
                    lstrCRow = pubstrVsfTag_Get(vsfJMaskSetList, 1)
                    '@ｸﾞﾘｯﾄﾞｷｰ制御
                    Call pubVsf_KeyDown(e, .Name, vsfJMaskSetList, Nothing, Nothing, False)            

                    '@ﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfJMaskSetList)
                End With
            End If
            
            '@ｷｰｺｰﾄﾞの確認
            Select Case Asc(e.KeyCode)

				Case CPlngKeyAsciiNum0 To CPlngKeyAsciiNum9, _
                     CPlngKeyAsciiUppA To CPlngKeyAsciiUppZ, _
                     CPlngKeyAsciiLowA To CPlngKeyAsciiLowZ, _
                     CPlngKeyBackSpace
                
					If ActiveControl.Name = vsfJMaskSetList.Name  Then
						vsfJMaskSetList.Select(vsfJMaskSetList.Row, vsfJMaskSetList.Col)
						vsfJMaskSetList.StartEditing()     '編集可能にする
					End If
				'@Enterｷｰの場合
                Case Keys.Return

					'ここで次のセルに移る処理呼び出しか？

                    If ActiveControl.Name <> vsfJMaskSetList.Name AndAlso _
                            ActiveControl IsNot vsfJMaskSetList.Editor Then
						 e.Handled = True
                    End If

					Call vsfJMaskSetList_AfterEdit(sender, New RowColEventArgs(vsfJMaskSetList.Row, CMlngColGuideId))

                    
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
    '作成日：
    '更新日：
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@ｸﾞﾛｰﾊﾞﾙな変数を初期化
			pstrJigID = vbNullString

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
            If ptypCommonInfo.strJigId <> vbNullString Then
            '@空白でない場合
                '@親ﾌｫｰﾑから呼ばれた場合
                '@親画面切り替え引継ぎ制御
                Call pubChangeScreen_Set(Me)
            Else
            '@空白の場合
                '@終了関数を実行する
                Call publngEnd_Proc(CPstrKeyEN02V0, ltypCommonInfo)
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




    '関数名：vsfJMaskSetList_AfterEdit
    '機　能：分割元ｽﾛｯﾄﾏｯﾌﾟの変更後処理
    '引　数：行 Row 列 Col
    '戻り値：なし
    '作成日：2009/06/10 (Thu) 15:43:29 K.Nishizawa
    '更新日：2009/08/06 (Thu) 15:14:30 T.Oide
    '備　考：
    Private Sub vsfJMaskSetList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfJMaskSetList.AfterEdit
        
        Dim ltypjJigChk				As jJigCheck           '治具使用可否判定確認Msg
        Dim llngRowCnt              As Integer
		Dim lblnAns					As Boolean
		Dim lstrGuideMsgCode		As String
		Dim	lstrGuideMsg			As String
		Dim	lstrEditGuidance		As String
		Dim lstrJigId				As String

        Try


            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl is cmdClose OrElse mblnWindowClose Then
                Exit Sub
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfJMaskSetList.Rows.Count <= vsfJMaskSetList.Rows.Fixed Then
                Return
            End If
            
            mstrEventName = "vsfJMaskSetList_AfterEdit"
            
            With vsfJMaskSetList

				lstrJigId = .GetData(e.Row,e.Col)


				'空の場合は何もしない
                If Trim(lstrJigId) = vbNullString Then
					Exit Sub
				End If

				'前回値と同じ場合は何もしない
				If lstrJigId = mstrLastJigId Then
					Exit Sub
				End If

				'大文字変換
				.SetData(e.Row, e.Col, StrConv(lstrJigId, vbUpperCase))

				'桁数の確認
                If Len(.GetData(e.Row, e.Col)) <> CMlngMaxLength Then
					'@表示ﾒｯｾｰｼﾞ変換
					pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009O)
					'@"治具IDは10桁で入力してください。"
					Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
					e.Cancel = True
                
					'@空にしてﾌｫｰｶｽｾｯﾄ
					.SetData(e.Row, e.Col,vbNullString)
					Call pubSetFocus(vsfJMaskSetList)
					.Select(e.Row,e.Col)
					'前回値初期化
					mstrLastJigId = vbNullString
					Exit Sub

				End If

				'重複チェック
				If prvblnDuplicationChk(lstrJigId) = False Then
					'@表示ﾒｯｾｰｼﾞ変換
					pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009M)
					'@"<TRM9MW>$$治具IDが重複しています。設定を見直してください。。"
					Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					'@空にしてﾌｫｰｶｽｾｯﾄ
					.SetData(e.Row, e.Col,vbNullString)
					pubSetFocus(sender)
'							.Select(e.Row,e.Col)
					'前回値初期化
					mstrLastJigId = vbNullString
					Exit Sub
				End If

				'前回値更新
				mstrLastJigId = lstrJigId

				'@使用する治具情報が存在するか、ステータスが正しいか確認（カテゴリの確認は登録時に行う）
				ltypjJigChk.strSbID = pstrSBID
				ltypjJigChk.strjigId = .GetData(e.Row, e.Col)
				If e.Col = CMlngColGuideId Then
					ltypjJigChk.strJJigCategory = CMstrCmbJJigCategoryGuideId
				Else If e.Col = CMlngColMaskId Then
					ltypjJigChk.strJJigCategory = CMstrCmbJJigCategoryMaskId
				End If
                
				'蒸着治具使用可否判断
				lblnAns = pubblnJJigUse_Check(CPstrCD4T, CMstrjig_jusechkVer, ltypjJigChk, _
                                        lstrGuideMsgCode, lstrGuideMsg)
				If lblnAns = True Then
					If lstrGuideMsg <> vbNullString Then
                        
						'@ﾒｯｾｰｼﾞがあった場合は、ｴﾗｰMsgを表示
						lstrEditGuidance = lstrGuideMsgCode & _
											CPstrMsgCrCode & lstrGuideMsg
                        
						'@ﾒｯｾｰｼﾞ表示"編集済みｶﾞｲﾀﾞﾝｽMsg"
						pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                        
						'@ﾒｯｾｰｼﾞ表示
						Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                        
						'元の治具IDにﾌｫｰｶｽを戻す
						.SetData(e.Row, e.Col,vbNullString)
						pubSetFocus(sender)
						Exit Sub
					End If

				Else
					'元の治具IDにﾌｫｰｶｽを戻す
					.SetData(e.Row, e.Col,vbNullString)
					pubSetFocus(sender)
					Exit Sub
				End If


				If e.Col = CMlngColGuideId Then
					'ガイドリング入力の場合
					'真横のマスクIDセルに移動する
					'@ﾌｫｰｶｽｾｯﾄ
					Call pubSetFocus(vsfJMaskSetList)
					.Select(e.Row,　CMlngColMaskId)
					mblnGuideIdSelectFlag = false
					mblnMaskIdSelectFlag = true

				Else If e.Col = CMlngColMaskId Then
					'マスク入力の場合
					'最終行でなければ次の行のガイドリングIDセルに移動する
					If e.Row < CMlngGuideMaskListRowS - 1
						Call pubSetFocus(vsfJMaskSetList)
						.Select(e.Row + 1,　CMlngColGuideId)
						'ガイドリングID列選択ﾌﾗｸﾞをON
						mblnGuideIdSelectFlag = true
						mblnMaskIdSelectFlag = false
					Else
						'最終行なら確定ボタン
						Call pubSetFocus(cmdRegist)

					End If

				End If


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

            End With
            
            
            '@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
            Call prvCmdButtonEnableChk()
            
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJMaskSetList_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfJMaskSetList_Click
    '機　能：グリッドクリック
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfJMaskSetList_Click(ByVal sender As Object, ByVal e As EventArgs) 

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            ''NSYS データ行がない場合は処理を抜ける
            'If vsfJMaskSetList.Rows.Count <= vsfJMaskSetList.Rows.Fixed Then
            '    Return
            'End If

            '@EnterCellｲﾍﾞﾝﾄ
            Call vsfJMaskSetList_EnterCell(vsfJMaskSetList, e)
			
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJMaskSetList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：vsfJMaskSetList_EnterCell
    '機　能：空治具選択ﾎﾞﾀﾝ制御
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/07 (Wed) 11:20:27 N.Kasai
    '更新日：2012/12/05 (Wed) 09:57:25 T.Oide
    '備　考：
    Private Sub vsfJMaskSetList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJMaskSetList.click

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJMaskSetList.Rows.Count <= vsfJMaskSetList.Rows.Fixed Then
                Return
            End If

            If mblnEventCancelFlag = True Then
                Exit Sub
            End If

            '@JIG_IDの登録ﾌｫｰﾑ作成
            With vsfJMaskSetList
                
                .Redraw = False
                '@ﾀｲﾄﾙ行でなければ処理
                If .Row > CMlngGuideMaskListRowTitle Then
                    'ｾﾙを編集状態にする
                    If .Col = CMlngColGuideId Then
						'ガイドリングセル選択フラグをONに、マスク側をOFF
						mblnGuideIdSelectFlag = True
						mblnMaskIdSelectFlag = False

						'前回値更新
						mstrLastJigId = .GetData(.Row,.Col)

                        .Select(.Row, CMlngColGuideId)
                        .Styles.Editor.BackColor = SystemColors.Window
                        .Styles.Editor.ForeColor = SystemColors.WindowText
                        .Styles.Highlight.BackColor = SystemColors.Window
                        .Styles.Highlight.ForeColor = SystemColors.WindowText
                        .StartEditing()

                    Else If .Col = CMlngColMaskId Then
							'ガイドリングセル選択フラグをONに、マスク側をOFF
						mblnGuideIdSelectFlag = False
						mblnMaskIdSelectFlag = True

						'前回値更新
						mstrLastJigId = .GetData(.Row,.Col)

						.Select(.Row, CMlngColmaskId)
                        .Styles.Editor.BackColor = SystemColors.Window
                        .Styles.Editor.ForeColor = SystemColors.WindowText
                        .Styles.Highlight.BackColor = SystemColors.Window
                        .Styles.Highlight.ForeColor = SystemColors.WindowText
                        .StartEditing()

					Else
						'フラグをどちらもOFF
						mblnGuideIdSelectFlag = False
						mblnMaskIdSelectFlag = False

                        .AllowEditing = False
                        .Styles.Highlight.BackColor = SystemColors.Window
                        .Styles.Highlight.ForeColor = SystemColors.Window

                    End If
                    
  
                End If

				'有効無効確認
				prvCmdButtonEnableChk()

                .Redraw = True

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJMaskSetList_EnterCell"
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
    '作成日：
    '更新日：
    '備　考：
    '　　　：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns						As Boolean				'結果取得(True:正常,False:異常)
        Dim ltypJMaskSetList			As JMaskSetList			'要求Msgｵﾌﾞｼﾞｪｸﾄ

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


			'データを構造体に格納
            Call prvJmaskList_Set(ltypJMaskSetList)

            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "cmdUseChange_Click"
            'Call pubResponseStart(Me.Name, mstrEventName)

            '@Msg送信処理実行
			'機種の確認含む
            lblnAns = pubblnJMaskSet_Ins(CMstrjig_jmasksetVer, CMstrJigStatusCanUse, CMstrJigEventIdJMaskSet, ltypJMaskSetList)

            '@結果判定
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                'Call publngResponseEnd(Me.Name, mstrEventName)

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0088)
                '@"<TRM88I>$$蒸着マスク組立を行いました。"
                Call pubVsfInfo_Disp(pstrDMsg)

                '@画面の初期化
                Call prvfrmxxEN02V0_Init()


            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
            End If


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

 
    '関数名：cmdJigSelect_Click
    '機　能：空き治具選択
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
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
			pstrJigStatus = CMstrJigStatusRdyUseBeforeSetId              '使用可(組前)

			'@蒸着治具カテゴリ引渡し
			If mblnGuideIdSelectFlag = True Then
				'ガイドリングIDセルを選択した状態で空治具選択を押した場合
				mstrJJigCategoryID = CMstrCmbJJigCategoryGuideId
			Else If mblnMaskIdSelectFlag = True Then
				'マスクIDセルを選択した状態で空治具選択を押した場合
				mstrJJigCategoryID = CMstrCmbJJigCategoryMaskId
			Else
				mstrJJigCategoryID = vbNullString
			End If

            pstrJJigCategoryID = mstrJJigCategoryID                          '蒸着治具ｶﾃｺﾞﾘ

            
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
                 
            '@ガイドリングIDが選択されている場合
            If mblnGuideIdSelectFlag = true Then
                '@治具IDをｾｯﾄ
                vsfJMaskSetList.Redraw = False
                vsfJMaskSetList.SetData(vsfJMaskSetList.Row, CMlngColGuideId, pstrJigID)
                vsfJMaskSetList.Redraw = True
				RemoveHandler vsfJMaskSetList.AfterEdit,AddressOf vsfJMaskSetList_AfterEdit
				Call vsfJMaskSetList_AfterEdit(sender, New RowColEventArgs(vsfJMaskSetList.Row, CMlngColGuideId))
				AddHandler vsfJMaskSetList.AfterEdit,AddressOf vsfJMaskSetList_AfterEdit

            Else If  mblnMaskIdSelectFlag = true Then
				'@治具IDをｾｯﾄ
                vsfJMaskSetList.Redraw = False
                vsfJMaskSetList.SetData(vsfJMaskSetList.Row, CMlngColMaskId, pstrJigID)
                vsfJMaskSetList.Redraw = True

				RemoveHandler vsfJMaskSetList.AfterEdit,AddressOf vsfJMaskSetList_AfterEdit
				Call vsfJMaskSetList_AfterEdit(sender, New RowColEventArgs(vsfJMaskSetList.Row, CMlngColMaskId))
				AddHandler vsfJMaskSetList.AfterEdit,AddressOf vsfJMaskSetList_AfterEdit

			End If

            
            '@治具ID格納変数初期化
			mstrJJigCategoryID = vbNullString
            pstrJigID = vbNullString
            pstrJJigCategoryID = vbNullString
			pstrJigStatus = vbNullString


            '@治具にﾌｫｰｶｽｾｯﾄ
            If vsfJMaskSetList.Editor Is Nothing And ActiveControl IsNot cmdRegist Then
                'NSYS エラー発生後、編集モードになっている(.Editorがある)時にSetFocusすると編集モードがキャンセルされる
                'NSYS 編集モードでない場合かつ確定ボタンではない場合のみ、フォーカスをうつす
                Call pubSetFocus(vsfJMaskSetList)
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
    '関数名：prvfrmxxEN02V0_Init
    '機　能：各ｵﾌﾞｼﾞｪｸﾄの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub prvfrmxxEN02V0_Init(Optional ByVal lblnCarrier As Boolean = True, _
                                    Optional ByVal lblnForReload As Boolean = False)

        Dim lstrFormTitle       As String

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02V0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            

            '@ｸﾞﾘｯﾄﾞの設定
            With vsfJMaskSetList
                'NSYS 描画ﾛｯｸ
                .Redraw = False
                .Clear
                .HighLight = HighLightEnum.WithFocus
                '@列幅設定
                .Cols(CMlngColNo).Width = CMlngColNoWidth
                .Cols(CMlngColGuideId).Width = CMlngColGuideIdWidth
                .Cols(CMlngColMaskId).Width = CMlngColMaskIdWidth
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngGuideMaskListRowTitle, CMlngColNo, CMstrColNo)
                .SetData(CMlngGuideMaskListRowTitle, CMlngColGuideId, CMstrColGuideId)
                .SetData(CMlngGuideMaskListRowTitle, CMlngColMaskId, CMstrColMaskId)

                '@ﾀｲﾄﾙﾊﾞｯｸｶﾗｰ設定
                '@ﾀｲﾄﾙﾌｫﾝﾄｶﾗｰ設定
                Dim cellRange As CellRange = .GetCellRange(CMlngGuideMaskListRowTitle, CMlngColNo, CMlngGuideMaskListRowTitle, CMlngColMaskId)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow
                headerStyle.BackColor =  ColorTranslator.FromWin32(CPlngBlueColor)
                With .Styles.Normal.Font
                    headerStyle.Font = New Font(.FontFamily, CMlngGuideMaskListHMaCellFontSize, .Style, .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                headerStyle.TextAlign = TextAlignEnum.CenterCenter
                cellRange.Style = headerStyle
                
				'@タイトル+10行表示 0から数えるので10
                .Rows.Count = CMlngGuideMaskListRowS

				'@行表示
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    .Rows(llngCnt).Visible = True
                Next llngCnt
                
                '@№設定
                For llngCnt = 1 To .Rows.Count - 1
                    .SetData(llngCnt, CMlngColNo, CStr(llngCnt))
                    '@ｽﾛｯﾄの高さの設定
                    .Rows(llngCnt).Height = CMlngGuideMaskListHHeight
                    '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                    .Cols(CMlngColNo).TextAlign = TextAlignEnum.RightCenter      '右中央
                Next llngCnt


				
				'NSYS 描画ﾛｯｸ
                .Redraw = True



            End With
            
            'ｺﾏﾝﾄﾞﾎﾞﾀﾝ無効
            cmdClose.Enabled = True
            cmdRegist.Enabled = False
            cmdJigSelect.Enabled = True

			

            pblnFormLoad = True
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02V0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	''関数名：prvblnInput_Chk
	''機　能：
	''引　数：なし
	''戻り値：TRUE:成功 FALSE:失敗
	''作成日：
	''更新日：
	''備　考：
	Private Function prvblnInput_Chk() As Boolean

		Dim   blnChkSetAri As Boolean

		Try

			' 最低一行以上ガイドリングID(10文字)とマスクID(10文字)が設定されていて、且つ、
			' 不正な治具ID(10文字以外)の設定がなければチェックOKとする
			' 片側だけ入力は無視する
            blnChkSetAri = False

			'@ｸﾞﾘｯﾄﾞの全ての行をﾁｪｯｸ
            For llngRowCnt = 1 To vsfJMaskSetList.Rows.Count - 1

				'セットが1行以上あればＯＫ
				If vsfJMaskSetList.GetData(llngRowCnt, CMlngColGuideId) <> vbNullString And _
					 vsfJMaskSetList.GetData(llngRowCnt, CMlngColMaskId) <> vbNullString Then
					blnChkSetAri = True
				End If
                
                '@同じ行のガイドリング、マスクがすべて埋まっているか
                If vsfJMaskSetList.GetData(llngRowCnt, CMlngColGuideId) <> vbNullString Then
					If vsfJMaskSetList.GetData(llngRowCnt, CMlngColMaskId) = vbNullString Then
						'ガイドリングがnullじゃなく、マスクがnullの場合
						prvblnInput_Chk = False
						Exit Function

					Else
						'両方埋まっている場合
						'@10文字じゃない治具ID設定はあるか
						If Len(vsfJMaskSetList.GetData(llngRowCnt, CMlngColGuideId)) <> CMlngMaxLength Or _
							Len(vsfJMaskSetList.GetData(llngRowCnt, CMlngColMaskId)) <> CMlngMaxLength Then
							'@10文字未満
							prvblnInput_Chk = False
							Exit Function
						End if


					End If

				Else If vsfJMaskSetList.GetData(llngRowCnt, CMlngColMaskId) <> vbNullString Then
					’片側だけはＮＧ
					prvblnInput_Chk = False
					Exit Function

                End If
                    
            Next
                
            '@セット[あり]
            If blnChkSetAri = True  Then
                prvblnInput_Chk = True
            Else
                prvblnInput_Chk = False
				Exit Function
            End If


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

	'関数名：prvJMaskList_Set
	'機　能：ﾃﾞｰﾀをMsg専用構造体に取得
	'引　数：ltypWfJigSetReq：Msg要求構造体
	'戻り値：なし
	'作成日：
	'更新日：
	'備　考：
	Private Sub prvJMaskList_Set(ByRef ltypJMaskSetList As JMaskSetList)

        Dim llngCnt                 As Integer
        Dim llngRowCnt              As Integer
        
        Try
            
            llngCnt = 0

			           
            If ltypJMaskSetList.typJMaskSet Is Nothing Then
                ltypJMaskSetList.typJMaskSet = New List(Of JMaskSet)
            Else
                ltypJMaskSetList.typJMaskSet.Clear
            End If
			
			ltypJMaskSetList.strEmpID = pstrUserID
			ltypJMaskSetList.strJigStatus = CMstrJigStatusRdyUseBeforeSetId
		'	ltypJMaskSetList.strJigEventId = CMstrJigEventIdJMaskSet


            With vsfJMaskSetList
                For llngRowCnt = 1 To .Rows.Count - 1
                    If .GetData(llngRowCnt, CMlngColGuideId) <> vbNullString　And　_
						.GetData(llngRowCnt, CMlngColMaskId) <> vbNullString Then

                        Dim ltypJMaskSetTmp As JMaskSet = New JMaskSet
                        ltypJMaskSetTmp.strGuideId = .GetData(llngRowCnt, CMlngColGuideId)
                        ltypJMaskSetTmp.strMaskId = .GetData(llngRowCnt, CMlngColMaskId)

						'ﾘｽﾄにセット
					    ltypJMaskSetList.typJMaskSet.Add(ltypJMaskSetTmp)
						llngCnt = llngCnt + 1
						ltypJMaskSetList.lngtypJMaskSetCnt = llngCnt
					End If

                Next
            End With
            
            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvJMaskList_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmdButtonEnableChk
    '機　能：有効/無効ﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：
    '更新日：
    '備　考：
    Private Sub prvCmdButtonEnableChk()
        
        Dim llngRowCnt              As Integer
        Dim blnChkSetAri            As Boolean
        Dim blnChkMiman             As Boolean
        
        
        Try
            

           ' 最低一行以上ガイドリングID(10文字)とマスクID(10文字)が設定されていて、且つ、
           ' 不正な治具ID(10文字以外)の設定がなければチェックOKとする
		   ' 片側だけ入力は無視する
            blnChkSetAri = False
            blnChkMiman = False

           '@ｸﾞﾘｯﾄﾞの全ての行をﾁｪｯｸ
            For llngRowCnt = 1 To vsfJMaskSetList.Rows.Count - 1
                
                '@同じ行の治具ID設定行はあるか
                If vsfJMaskSetList.GetData(llngRowCnt, CMlngColGuideId) <> vbNullString And _
					vsfJMaskSetList.GetData(llngRowCnt, CMlngColMaskId) <> vbNullString Then
                    '@設定あり
                    blnChkSetAri = True
                    
                    '@10文字じゃない治具ID設定はあるか
                    If Len(vsfJMaskSetList.GetData(llngRowCnt, CMlngColGuideId)) <> CMlngMaxLength Or _
						Len(vsfJMaskSetList.GetData(llngRowCnt, CMlngColMaskId)) <> CMlngMaxLength Then
                        '@10文字未満
                        blnChkMiman = True
                        Exit For
                        
                    End If
                End If
                    
            Next
                
            '@セット[あり]で10文字未満[なし]なら有効
            If blnChkSetAri = True And blnChkMiman = False Then
                cmdRegist.Enabled = True
            Else
                cmdRegist.Enabled = False
            End If


			'空治具選択
			If mblnGuideIdSelectFlag = True Or mblnMaskIdSelectFlag = True Then
				cmdJigSelect.Enabled = True
			End If


            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdButtonEnableChk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：prvblnDuplicationChk
	'機　能：重複チェック
	'引　数：なし
	'戻り値：TRUE:成功 FALSE:失敗
	'作成日：
	'更新日：
	'備　考：
	Private Function prvblnDuplicationChk(byVal lstrJigId As String) As Boolean

		Dim	lintCnt			As Integer
		Dim	lintRowsCnt		As Integer
		
		Try

			lintCnt = 0

			'@ｸﾞﾘｯﾄﾞの全ての行をﾁｪｯｸ
            For lintRowsCnt = 1 To vsfJMaskSetList.Rows.Count - 1

				'セットが1行以上あればＯＫ
				If vsfJMaskSetList.GetData(lintRowsCnt, CMlngColGuideId) = lstrJigId  Then
					lintCnt = lintCnt + 1
				End If

				If vsfJMaskSetList.GetData(lintRowsCnt, CMlngColMaskId) = lstrJigId  Then
					lintCnt = lintCnt + 1
				End If
            

            Next
                
            '@2回以上出現したか
            If lintCnt < CPlngNumTwo  Then
                prvblnDuplicationChk = True
            Else
                prvblnDuplicationChk = False
            End If



			Exit Function

		Catch ex As Exception

			'@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
			With ptypOnErrorInfo
				.strMenuKey = CMstrLocalMenuKey
				.strProcName = "prvblnDuplicationChk"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraJMaskSet.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfJMaskSetList.BeforeDoubleClick

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
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfJMaskSetList.KeyDownEdit

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
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs)

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

    '関数名：vsfJMaskSetList_LeaveEdit
    '機　能：分割元ｽﾛｯﾄﾏｯﾌﾟの編集モードから出た後
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2020/05/27 (Wed) 17:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub vsfJMaskSetList_LeaveEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfJMaskSetList.LeaveEdit
        
        Try

            With vsfJMaskSetList
                'NSYS 編集モードから出た後ハイライト表示を戻す
                .Styles.Highlight.BackColor = SystemColors.Window
                .Styles.Highlight.ForeColor = SystemColors.Window
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJMaskSetList_LeaveEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


End Class
