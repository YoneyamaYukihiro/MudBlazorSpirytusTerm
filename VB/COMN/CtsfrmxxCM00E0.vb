'ﾌｧｲﾙ名：xxCM00E0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：空ｷｬﾘｱ一覧表示画面
'作成日：2004/06/02 (Wed) 09:17:50 Y.Yamagishi
'更新日：2007/07/27 (Fri) 11:43:00 N.Kasai
'備　考：
'　　　：2005/06/16 (Thu) 10:51:14 S.Deguchi    ｾｯﾄﾌｫｰｶｽ対応＆ｸﾞﾘｯﾄﾞのﾌｫｰｶｽ位置をﾀｲﾄﾙへｾｯﾄする処理を追加
'　　　：2007/07/27 (Fri) 11:43:00 N.Kasai      ｿｰｽ整備
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00E0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00E0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00E0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00E0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00E0)
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
    '====================================Private============================================
    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM00E0  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrcarrlist____Ver              As String = "07.00"         'ｷｬﾘｱ一覧
    Private Const CMstrcarrmaslist_Ver              As String = "05.00"         'ｷｬﾘｱ関連ﾏｽﾀｰ

    '@ComboBox設定
    Private Const CMlngCmbFontSize                  As Integer = 16             'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 16             'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbRowHeight                 As Integer = 43             'ﾘｽﾄ行の高さ
    Private Const CMlngCmbDispCols                  As Integer = 1              'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbValueCol                  As Integer = 1              '値取得列
    Private Const CMlngCmbGetCol                    As Integer = 0              '表示列
    Private Const CMlngCmbDispColIndex              As Integer = 0              '表示列番

    '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
    Private Const CMstrvsfCarrierListNo             As String = "№"            '№
    Private Const CMstrvsfCarrierListCreanTime      As String = "最終洗浄日時"   '最終洗浄日
    Private Const CMstrvsfCarrierListCarrierID      As String = "空きキャリアID" 'ｷｬﾘｱID
    Private Const CMstrvsfCarrierListSMIFID         As String = "空きSMIFID"    'SMIFID
    Private Const CMstrvsfCurrentPositionName       As String = "現在位置"      '現在位置

    '@表の行ﾀｲﾄﾙ
    Private Const CMlngvsfCarrierListNo             As Integer = 0              '№
    Private Const CMlngvsfCarrierListCreanTime      As Integer = 1              '最終洗浄日
    Private Const CMlngvsfCarrierListCarrierID      As Integer = 2              'ｷｬﾘｱID
    Private Const CMlngvsfCurrentPositionName       As Integer = 3              '現在位置

    '@表の列幅
    Private Const CMlngvsfWCarrierListNo            As Integer = 47             '№
    Private Const CMlngvsfWCarrierListCreanTime     As Integer = 200            '最終洗浄日
    Private Const CMlngvsfWCarrierListCarrierID     As Integer = 133            'ｷｬﾘｱID
    Private Const CMlngvsfWCurrentPositionName      As Integer = 200            '現在位置

    '@ｸﾞﾘｯﾄﾞの設定
    Private Const CMlngvsfCarrierListRowHeight      As Integer = 38             '行高さ
    Private Const CMlngvsfCarrierListTitleRowHeight As Integer = 24             'ﾀｲﾄﾙ行高さ
    Private Const CMlngvsfCarrierListFontSize       As Integer = 16             'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfCarrierListTitleFontSize  As Integer = 12             'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngTitleRow                     As Integer = 0              'ﾀｲﾄﾙ行

    '@その他
    Private Const CMlngvsfCarrierListCnt            As Integer = 12             'ﾘｽﾄ行数


	Private Const CMstrCarrierTypeNameFoup			As String = "FOUP"		'Bキャリア(FOUP)
	Private Const CMstrCarrierTypeNameHotOP			As String = "耐熱オープンカセット"
	Private Const CMstrCarrierTypeNameI				As String = "簡易分割仮想キャリア"

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '====================================Private============================================
    Private mblnFormLoadFlag                        As Boolean                  'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mstrCarrTypName                         As String                   '退避ｷｬﾘｱﾀｲﾌﾟ名
    Private mstrEventName                           As String                   'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
    Private mtypCarrierEmptyList                    As CarrList                 'ｷｬﾘｱﾘｽﾄ取得結果格納
    Private mtypChgSort                             As ChgSort                  'ソート保持用
    Private buttonProcessing                        As Boolean                  'NSYS ボタン2度押し対策

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
        pubVsfMouseWheelManager_Set(vsfCarrierList, cmdUp, cmdDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ初期設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:19:26 Y.Yamagishi
    '更新日：2005/01/05 (Wed) 15:50:02 N.Kasai
    '備　考：2004/10/14 (Thu) 16:49:13 Y.Yamagishi  列幅、ソート順、ｶﾚﾝﾄ行の保持修正
    '　　　：2004/10/14 (Thu) 16:49:13 Y.Yamagishi  親画面からｷｬﾘｱﾀｲﾌﾟID引渡し処理追加
    '　　　：2004/10/22 (Fri) 17:02:10 Y.Yamagishi  親画面から洗浄条件引渡し処理追加
    '　　　：2005/01/05 (Wed) 15:50:02 N.Kasai      pubblnCarrMasList_Selに引数追加（SBID)
    Private Sub Form_Load()
        
        Dim lblnAns                 As Boolean          '戻り値
        Dim llngCarrTypListCnt      As Integer          'ｷｬﾘｱﾀｲﾌﾟ一覧ｶｳﾝﾄ
        Dim ltypCarrierMaster       As List(Of CarrierMaster)    'ｷｬﾘｱﾀｲﾌﾟ一覧取得結果格納
        
        Try
            
            '@ｲﾍﾞﾝﾄ名格納
            mstrEventName = "Form_Load"
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@画面の初期化
            Call prvfrmxxCM00E0_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            ltypCarrierMaster = New List(Of CarrierMaster)

            '@ｷｬﾘｱﾀｲﾌﾟ一覧取得（CPstrCD38：ｷｬﾘｱﾀｲﾌﾟ）
            lblnAns = pubblnCarrMasList_Sel(CMstrcarrmaslist_Ver, _
                                                       CPstrCD38, _
                                                       llngCarrTypListCnt, _
                                                       ltypCarrierMaster, _
                                                       pstrSBID)
            '@結果確認
            If lblnAns = True Then
                '@取得OKなら結果表示
                Call prvcmbCarrTyp_Disp(llngCarrTypListCnt, ltypCarrierMaster)

                '@親画面からｷｬﾘｱﾀｲﾌﾟID引渡しありの場合
                If pstrCarrierTypeID <> vbNullString Then
                    
					'@ｺﾝﾎﾞﾎﾞｯｸｽ無効
					'@kkw 簡易分割の場合有効のままにする
					If pblnMkEasyDivFlag <> False Then
						cmbCarrTyp.Enabled = True
                    End If

                    '@空ｷｬﾘｱ取得処理
                    lblnAns = prvblnCarrList_Sel()
                    '@結果確認
                    If lblnAns = True Then
                        '@ｷｬﾘｱﾀｲﾌﾟを判定して見出を変更
                        Select Case pstrCarrierTypeID
                            '@SMIF
                            Case CPstrCarrTypeSMIF
                                '@一覧の空きSMIF表示列ﾀｲﾄﾙ変更
                                vsfCarrierList.SetData(CMlngTitleRow, CMlngvsfCarrierListCarrierID, _
                                            CMstrvsfCarrierListSMIFID)
                                
                        End Select
                    
                        '@ｷｬﾘｱが0件の場合
                        If mtypCarrierEmptyList.lngCarrierListCnt <> 0 Then
                            '@Form_Loadﾌﾗｸﾞ（正常）
                            pblnFormLoad = True
                        Else
							'@ｷｬﾘｱﾘｽﾄｺﾝﾎﾞが２件以上ある場合はエラーにしない
                            If cmbCarrTyp.ListCount <= 1 Then
								'@Form_Loadﾌﾗｸﾞ（異常）
								pblnFormLoad = False
                            
								'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
								Call pubResponseCancel(Me.Name, mstrEventName)
                            
								'@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
								'@"<TRM29I>$$該当件数 ： %1 件"
								pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, mtypCarrierEmptyList.lngCarrierListCnt)
								'@ｲﾝﾌｫﾒｰｼｮﾝ表示
								Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                            
								Exit Sub
							Else
								'@Form_Loadﾌﾗｸﾞ（正常）
                                pblnFormLoad = True
							End If
                        End If
                        
                        '@ｷｬﾘｱﾀｲﾌﾟ名を取得する
                        mstrCarrTypName = cmbCarrTyp.Text
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(Me.Name, mstrEventName)
                        
                        Exit Sub
                    Else
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, mstrEventName)
                    End If
                Else
                    '@ｷｬﾘｱ引継ぎなし
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
                    '@Form_Loadﾌﾗｸﾞ（正常）
                    pblnFormLoad = True
                    
                    Exit Sub
                End If
            Else
                '@ｷｬﾘｱﾀｲﾌﾟ一覧取得に失敗
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"                  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑのｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 11:44:57 Y.Yamagishi
    '更新日：2004/09/23 (Thu) 11:44:57
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Try
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理判別
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
            
                '@取得OKなら結果表示
                Call prvfrmxxCM00E0_Disp(mtypCarrierEmptyList)
                
                '@ﾘｽﾄが0件以上の場合最新取得ﾎﾞﾀﾝを活性化
                If mtypCarrierEmptyList.lngCarrierListCnt > 0 Then
                    cmdLotList.Enabled = True
                End If
            End If
            
            '@ｷｬﾘｱﾀｲﾌﾟｺﾝﾎﾞﾎﾞｯｸｽが無効の場合
            If cmbCarrTyp.Enabled = False Then
                '@ｸﾞﾘｯﾄﾞにｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(vsfCarrierList)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Activate"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:18:55 Y.Yamagishi
    '更新日：2005/06/23 (Thu) 12:57:20 N.Kasai
    '備　考：
    '　　　：2005/06/23 (Thu) 12:57:20 N.Kasai  ｸﾞﾘｯﾄﾞｽｸﾛｰﾙ機能追加
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
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
                e.Handled = True
                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If
            
            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfCarrierList, cmdUP, cmdDown)
            
            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理判別
            Select Case ActiveControl.Name
                '@ｷｬﾘｱﾀｲﾌﾟIDの場合
                Case cmbCarrTyp.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@前と同じｷｬﾘｱﾀｲﾌﾟ名の場合は次項目へｾｯﾄﾌｫｰｶｽ
                            If mstrCarrTypName = cmbCarrTyp.Text Then
                                '@次項目へｾｯﾄﾌｫｰｶｽ
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            Else
                                '@ｷｬﾘｱﾀｲﾌﾟIDValidate処理へ
                                Call cmbCarrTyp_Validate(cmbCarrTyp, New CancelEventArgs)
                            End If
                                            
                        Case Else
                    End Select
                    
                '@一覧の場合
                Case vsfCarrierList.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            With vsfCarrierList
                                If .Row >= .Rows.Fixed Then
                                    '@確定処理
                                    Call cmdChoice_Click(cmdChoice, New EventArgs)
                                End If
                            End With
                    End Select
                    
                '@その他の場合
                Case Else
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@次項目へｾｯﾄﾌｫｰｶｽ
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"               '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 09:28:01 H.Wajima
    '更新日：2004/10/21 (Thu) 09:19:02 Y.Yamagishi
    '備　考：2004/10/21 (Thu) 09:19:02 Y.Yamagishi　引渡しｷｬﾘｱﾀｲﾌﾟID初期化処理追加
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            mtypChgSort.typChgSortList = Nothing
            
            '@引継ｷｬﾘｱﾀｲﾌﾟの初期化
            pstrCarrierTypeID = vbNullString

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_QueryUnload"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:27:46 Y.Yamagishi
    '更新日：2004/06/02 (Wed) 09:27:46
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞ
            Me.Close()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdChoice_Click
    '機　能：選択確定ﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:21:40 Y.Yamagishi
    '更新日：2004/06/02 (Wed) 09:21:40
    '備　考：
    Private Sub cmdChoice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChoice.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@行が選択されていない場合は格納しない
            If vsfCarrierList.Row >= 1 Then
                With vsfCarrierList
                    pstrCarrierID = .GetData(.Row, CMlngvsfCarrierListCarrierID)    'ｷｬﾘｱID
                End With
                
                '@ﾌｫｰﾑを閉じる
                Me.Close()
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdChoice_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotList_Click
    '機　能：最新取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/16 (Fri) 15:38:17 N.Kojima
    '更新日：2004/10/22 (Fri) 17:03:09 Y.Yamagishi
    '備　考：2004/10/18 (Mon) 14:52:29 Y.Yamagishi  0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    '　　　：2004/10/22 (Fri) 17:03:09 Y.Yamagishi 親画面から洗浄条件引渡し処理追加
    Private Sub cmdLotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotList.Click
        
        Dim lblnAns      As Boolean          '戻り値
        
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
            
            '@ｲﾍﾞﾝﾄ名格納
            mstrEventName = "cmdLotList_Click"
            
            '@空白の場合抜ける
            If cmbCarrTyp.Text = vbNullString Then
                '@最新取得ﾎﾞﾀﾝをﾛｯｸ
                cmdLotList.Enabled = False
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ開始
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@空ｷｬﾘｱﾘｽﾄ取得
            lblnAns = prvblnCarrList_Sel()
            '@結果確認
            If lblnAns = True Then
                '@ﾃﾞｰﾀ表示行が存在するかどうかを判定
                If vsfCarrierList.Rows.Fixed <> vsfCarrierList.Rows.Count Then
                    '@ﾃﾞｰﾀ行がある場合
                    Call pubSetFocus(vsfCarrierList)
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
                
                '@ｷｬﾘｱﾀｲﾌﾟ名を取得する
                mstrCarrTypName = cmbCarrTyp.Text
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdLotList_Click"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbCarrTyp_Change
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/09 (Wed) 13:40:05 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 16:49:57 Y.Yamagishi
    '備　考：2004/10/14 (Thu) 16:49:57 Y.Yamagishi 列幅、ソート順、ｶﾚﾝﾄ行の保持修正
    Private Sub cmbCarrTyp_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCarrTyp.Change

        Try

            '@起動時には処理を行わない
            If mblnFormLoadFlag = True Then
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                mtypChgSort.strKey = vbNullString
                
                '@ｸﾞﾘｯﾄﾞの初期化
                Call prvvsfCarrierList_Init()
                
                '@最新取得ﾎﾞﾀﾝをﾛｯｸ解除
                cmdLotList.Enabled = True
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbCarrTyp_Change"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbCarrTyp_CloseUp
    '機　能：ｷｬﾘｱ一覧表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/09 (Wed) 14:21:40 Y.Yamagishi
    '更新日：2004/09/30 (Thu) 20:26:45 H.Wajima
    '備　考：2004/09/30 (Thu) 20:26:45 H.Wajima ﾀﾌﾞ遷移処理追加
    Private Sub cmbCarrTyp_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCarrTyp.CloseUp

        Try

            '@Validate処理へ
            Call cmbCarrTyp_Validate(cmbCarrTyp, New CancelEventArgs)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbCarrTyp_CloseUp"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbCarrTyp_Validate
    '機　能：ｷｬﾘｱ一覧表示処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/09 (Wed) 11:38:57 Y.Yamagishi
    '更新日：2004/10/18 (Mon) 14:55:35 Y.Yamagishi
    '備　考：2004/10/18 (Mon) 14:55:35 Y.Yamagishi  0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    Private Sub cmbCarrTyp_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbCarrTyp.Validating

        Dim lblnAns     As Boolean      '戻り値
        
        Try
            
            '@ｲﾍﾞﾝﾄ名格納
            mstrEventName = "cmbCarrTyp_Validate"
            
            '@空白の場合抜ける
            If cmbCarrTyp.Text = vbNullString Then
                '@最新取得ﾎﾞﾀﾝをﾛｯｸ
                cmdLotList.Enabled = False
                Exit Sub
            End If
            
            '@前と同じｷｬﾘｱﾀｲﾌﾟ名の場合は処理を抜ける
            If mstrCarrTypName = cmbCarrTyp.Text Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ開始
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@空ｷｬﾘｱﾘｽﾄ取得
            lblnAns = prvblnCarrList_Sel()
            '@結果確認
            If lblnAns = True Then
                '@ﾃﾞｰﾀ表示行が存在するかどうかを判定
                If vsfCarrierList.Rows.Fixed <> vsfCarrierList.Rows.Count Then
                    '@ﾃﾞｰﾀ行がある場合
                    RemoveHandler cmbCarrTyp.Validating, AddressOf cmbCarrTyp_Validate
                    Call pubSetFocus(vsfCarrierList)
                    AddHandler cmbCarrTyp.Validating, AddressOf cmbCarrTyp_Validate
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
                
                '@ｷｬﾘｱﾀｲﾌﾟ名を取得する
                mstrCarrTypName = cmbCarrTyp.Text
                
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                e.Cancel = True
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbCarrTyp_Validate"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：次ﾍﾟｰｼﾞﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:26:17 Y.Yamagishi
    '更新日：2004/06/02 (Wed) 09:26:17
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

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdDown(vsfCarrierList, cmdUP, cmdDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdDown_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUP_Click
    '機　能：前ﾍﾟｰｼﾞﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:26:35 Y.Yamagishi
    '更新日：2004/06/02 (Wed) 09:26:35
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

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdUp(vsfCarrierList, cmdUP, cmdDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdUp_Click"                '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCarrierList_AfterSort
    '機　能：vsfCarrierList_AfterSort処理
    '引　数：Col：未使用
    '　　　：Order：未使用
    '戻り値：なし
    '作成日：2004/06/03 (Thu) 09:45:50 H.Wajima
    '更新日：2005/06/23 (Thu) 12:47:06 N.Kasai
    '備　考：2004/10/14 (Thu) 16:50:49 Y.Yamagishi  列幅、ソート順、ｶﾚﾝﾄ行の保持修正
    '　　　：2005/06/23 (Thu) 12:47:06 N.Kasai      ｿｰﾄ後のｽｸﾙｰﾙ制御追加
    Private Sub vsfCarrierList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfCarrierList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If

                
            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                Dim ltypChgSortListTmp As ChgSortList
                
                '@ｿｰﾄ列番号を格納
                ltypChgSortListTmp.lngCol = e.Col
                
                '@並び替え方法を格納（昇順/降順）
                ltypChgSortListTmp.lngOrder = e.Order
                .typChgSortList.Add(ltypChgSortListTmp)
            End With
            
            '@ｿｰﾄ後処理
            Call pubVsfAfterSort(vsfCarrierList, _
                                 CMlngvsfCarrierListNo & _
                                 vbTab & _
                                 CMlngvsfCarrierListCreanTime & _
                                 vbTab & _
                                 CMlngvsfCarrierListCarrierID & _
                                 vbTab & CMlngvsfCurrentPositionName, cmdUP, cmdDown)
            
            'NSYS ソート時にBeforeRowColChangeイベントが発生し、検索キー mtypChgSort.strKey が設定されるのを避けるため
            'NSYS 元に戻す
            AddHandler vsfCarrierList.BeforeRowColChange, AddressOf vsfCarrierList_BeforeRowColChange
            AddHandler vsfCarrierList.RowColChange, AddressOf vsfCarrierList_RowColChange

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfCarrierList_AfterSort"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：vsfCarrierList_BeforeRowColChange
    '機　能：変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 16:53:00 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 16:53:00
    '備　考：
    Private Sub vsfCarrierList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfCarrierList.BeforeRowColChange
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｬﾘｱID)
                mtypChgSort.strKey = vsfCarrierList.GetData( _
                                                         e.NewRange.r1, _
                                                         CMlngvsfCarrierListCarrierID)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                         '機能ID
                .strProcName = "vsfCarrierList_BeforeRowColChange"      '処理名
                .strErrMessage = vbNullString                           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfCarrierList_BeforeSort
    '機　能：vsfCarrierList_BeforeSort処理
    '引　数：Col：未使用
    '　　　：Order：未使用
    '戻り値：なし
    '作成日：2004/06/03 (Thu) 09:44:21 H.Wajima
    '更新日：2004/06/03 (Thu) 09:44:21
    '備　考：
    Private Sub vsfCarrierList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfCarrierList.BeforeSort
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If
            
            '@ｿｰﾄ前処理
            Call pubVsfBeforeSort(vsfCarrierList, _
                                  CMlngvsfCarrierListNo & _
                                  vbTab & _
                                  CMlngvsfCarrierListCreanTime & _
                                  vbTab & _
                                  CMlngvsfCarrierListCarrierID & _
                                  vbTab & _
                                  CMlngvsfCurrentPositionName)

            'NSYS ソート時にBeforeRowColChangeイベントが発生し、検索キー mtypChgSort.strKey が設定されるのを避けるため
            RemoveHandler vsfCarrierList.BeforeRowColChange, AddressOf vsfCarrierList_BeforeRowColChange
            RemoveHandler vsfCarrierList.RowColChange, AddressOf vsfCarrierList_RowColChange

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfCarrierList_BeforeSort"  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCarrierList_DblClick
    '機　能：ｷｬﾘｱ一覧ﾀﾞﾌﾞﾙｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:25:40 Y.Yamagishi
    '更新日：2004/06/02 (Wed) 09:25:40
    '備　考：
    Private Sub vsfCarrierList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfCarrierList.DoubleClick

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If

            '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
            If vsfCarrierList.MouseRow = 0 Then
                Exit Sub
            End If
                
            '@選択確定
            Call cmdChoice_Click(cmdChoice, New EventArgs)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfCarrierList_DblClick"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCarrierList_RowColChange
    '機　能：ｷｬﾘｱ一覧選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/16 (Thu) 11:37:23 S.Deguchi
    '更新日：2005/06/16 (Thu) 11:37:23
    '備　考：
    Private Sub vsfCarrierList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfCarrierList.RowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If

            '@ﾀｲﾄﾙ以外を選択した場合
            With vsfCarrierList
                If .Row > 0 Then
                    '@選択行のｷｬﾘｱIDが空欄ではない場合
                    If .GetData(.Row, CMlngvsfCarrierListCarrierID) <> vbNullString Then
                        '@確定ﾎﾞﾀﾝ活性化
                        cmdChoice.Enabled = True
                    Else
                        '@確定ﾎﾞﾀﾝ非活性化
                        cmdChoice.Enabled = False
                    End If
                End If
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "vsfCarrierList_RowColChange"    '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvfrmxxCM00E0_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:23:01 Y.Yamagishi
    '更新日：2004/06/02 (Wed) 09:23:01
    '備　考：
    Private Sub prvfrmxxCM00E0_Init()
        
        Try
            
            '@最新取得ﾎﾞﾀﾝをﾛｯｸ
            cmdLotList.Enabled = False
            
            '@情報取得日時初期化
            lblNowDate.Text = vbNullString
            '@件数ｸﾘｱ
            lblLotCnt.Text = vbNullString
            
            '@閉じるﾎﾞﾀﾝはValidate無効
            cmdClose.CausesValidation = False
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfCarrierList_Init()
            
            '@選択確定ﾎﾞﾀﾝ使用不可
            cmdChoice.Enabled = False
            
            '@ｷｬﾘｱID引継ぎ変数初期化
            pstrCarrierID = vbNullString
            
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM00E0_Init"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvvsfCarrierList_Init
    '機　能：ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/09 (Wed) 11:32:16 Y.Yamagishi
    '更新日：2004/06/09 (Wed) 11:32:16
    '備　考：
    Private Sub prvvsfCarrierList_Init()
        Dim lNormalStyle    As CellStyle
        Dim lFixedStyle     As CellStyle

        Try
            
            With vsfCarrierList
                '@行初期化
                .Rows.Count = 1
            
                '@行の高さ指定
                .Rows.DefaultSize = CMlngvsfCarrierListRowHeight
                .Rows(0).Height = CMlngvsfCarrierListTitleRowHeight
                
                '@ﾌｫﾝﾄの設定
                lNormalStyle = .Styles.Normal
                lFixedStyle = .Styles.Fixed
                With .Font
                    lNormalStyle.Font = New Font(.FontFamily, CMlngvsfCarrierListFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .Select(0, CMlngvsfCarrierListNo, .Rows.Fixed - 1, CMlngvsfCurrentPositionName)
                With .Font
                    lFixedStyle.Font = New Font(.FontFamily, CMlngvsfCarrierListTitleFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                
                '@見出し行の色設定
                lFixedStyle.BackColor = Color.Navy
                lFixedStyle.ForeColor = Color.Yellow
                
                '@列幅の設定
                .Cols(CMlngvsfCarrierListNo).Width = CMlngvsfWCarrierListNo
                .Cols(CMlngvsfCarrierListCreanTime).Width = CMlngvsfWCarrierListCreanTime
                .Cols(CMlngvsfCarrierListCarrierID).Width = CMlngvsfWCarrierListCarrierID
                .Cols(CMlngvsfCurrentPositionName).Width = CMlngvsfWCurrentPositionName
                
                'NSYS ﾍｯﾀﾞは省略表示なしに設定
                lFixedStyle.Trimming = StringTrimming.None

                '@見出し行の文字位置設定
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞのｿｰﾄ指定
                .AllowSorting = AllowSortingEnum.SingleColumn
                
                '@ﾛｯｸ
                .Enabled = False
            End With
            
            '@次,前ﾍﾟｰｼﾞﾎﾞﾀﾝ使用不可
            cmdUP.Enabled = False
            cmdDown.Enabled = False
            
            '@ｷｬﾘｱﾀｲﾌﾟ名初期化
            mstrCarrTypName = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfCarrierList_Init"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM00E0_Disp
    '機　能：ｷｬﾘｱﾘｽﾄ表示
    '引　数：ltypCarrierAllList:表示ﾃﾞｰﾀ格納
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:23:54 Y.Yamagishi
    '更新日：2005/06/01 (Wed) 17:08:00 N.Kojima
    '備　考：2004/10/14 (Thu) 16:58:27 Y.Yamagishi  列幅、ソート順、ｶﾚﾝﾄ行の保持修正
    '　　　：2005/06/01 (Wed) 17:08:00 N.Kojima     最終洗浄日時のﾌｫｰﾏｯﾄを「YYYY/MM/DD HH:MM」に統一(不具合№430)
    Private Sub prvfrmxxCM00E0_Disp(ByRef ltypCarrierEmptyList As CarrList)
        
        Dim llngCnt                     As Integer      'ｷｬﾘｱのｶｳﾝﾄ数
        Dim llngCarrierListCnt          As Integer      'ｷｬﾘｱﾘｽﾄのｶｳﾝﾄ数
        
        Try
            
            '@変数初期化
            llngCnt = 0
            llngCarrierListCnt = 1
            
            '@ﾃﾞｰﾀ表示
            With vsfCarrierList
                '@描画ﾛｯｸ
                .Redraw = False
                .Row = -1
                '@行数設定
                .Rows.Count = ltypCarrierEmptyList.lngCarrierListCnt + 1
                
                '@ﾃﾞｰﾀｾｯﾄ(ﾃﾞｰﾀがある場合)
                If .Rows.Count > 1 Then
                    Do While ltypCarrierEmptyList.lngCarrierListCnt > llngCnt
                        With ltypCarrierEmptyList.typCarrierList(llngCnt)
                            vsfCarrierList.SetData(llngCarrierListCnt, CMlngvsfCarrierListNo, llngCarrierListCnt) '№

                            '@最終洗浄日時が「0000/00/00 00:00:00」の場合
                            If .strCreanTime = CPstrDefYmdHms Then
                                vsfCarrierList.SetData(llngCarrierListCnt, CMlngvsfCarrierListCreanTime, _
                                    CPstrDefY2mdHms)   '最終洗浄日時（「00/00/00 00:00:00」）
                            ElseIf IsDate(.strCreanTime)
                                vsfCarrierList.SetData(llngCarrierListCnt, CMlngvsfCarrierListCreanTime, _
                                                       Format$(CDate(.strCreanTime), CPstrDateTimeY2MDHMS)) '最終洗浄日時
                            Else
                                vsfCarrierList.SetData(llngCarrierListCnt, CMlngvsfCarrierListCreanTime, _
                                    .strCreanTime)     '最終洗浄日時
                            End If
                            vsfCarrierList.SetData(llngCarrierListCnt, CMlngvsfCarrierListCarrierID, .strCarrierId)   'ｷｬﾘｱID
                            
                            vsfCarrierList.SetData(llngCarrierListCnt, CMlngvsfCurrentPositionName, _
                                .strCurrentPositionName)                           '現在位置
                            
                            '@行の高さ設定
                            vsfCarrierList.Rows(llngCarrierListCnt).Height = CMlngvsfCarrierListRowHeight
                            
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCarrierListCnt = llngCarrierListCnt + 1
                            llngCnt = llngCnt + 1
                        End With
                    Loop
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                            '@該当行をｿｰﾄ
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ｷｬﾘｱIDが同じ場合
                            If .GetData(llngCnt, CMlngvsfCarrierListCarrierID) = mtypChgSort.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ,保持列)
                                Call pubVsfBeforeSort(vsfCarrierList, CMlngvsfCarrierListNo)
                                
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ,保持列,前頁,次頁)
                                Call pubVsfAfterSort(vsfCarrierList, CMlngvsfCarrierListNo)
                                
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        '@ﾀｲﾄﾙ行を選択する
                        .Row = CMlngTitleRow
                    End If
                End If
                '@描画ﾛｯｸ解除
                .Redraw = True
                
                '@情報取得日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                '@件数表示
                lblLotCnt.Text = llngCarrierListCnt - 1
                
                '@ﾃﾞｰﾀ表示行が存在するかどうかを判定
                If .Rows.Fixed <> .Rows.Count Then
                    '@一覧使用可能
                    .Enabled = True
                Else
                    '@選択確定ﾎﾞﾀﾝ使用不可
                    cmdChoice.Enabled = False
                End If
            
                '@1ﾍﾟｰｼﾞに収まる場合
                If .Rows.Count - 1 <= CMlngvsfCarrierListCnt Then
                    '@次,前ﾍﾟｰｼﾞﾎﾞﾀﾝ使用不可
                    cmdUP.Enabled = False
                    cmdDown.Enabled = False
                Else
                    '@前ﾍﾟｰｼﾞﾎﾞﾀﾝ使用不可,次ﾍﾟｰｼﾞﾎﾞﾀﾝ使用可
                    cmdUP.Enabled = False
                    cmdDown.Enabled = True
                End If
                
                '@ｸﾞﾘｯﾄﾞ表示後処理
                Call pubVsfDisp(vsfCarrierList, cmdUP, cmdDown)
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM00E0_Disp"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbCarrTyp_Disp
    '機　能：ｷｬﾘｱﾀｲﾌﾟ一覧情報表示
    '引　数：llngCarrierCnt：ｷｬﾘｱﾀｲﾌﾟ一覧ﾃﾞｰﾀ数
    '　　　：mtypCarrierMaster()：ｷｬﾘｱﾀｲﾌﾟ一覧情報格納ﾃﾞｰﾀ
    '戻り値：なし
    '作成日：2004/06/09 (Wed) 11:13:30 Y.Yamagishi
    '更新日：2004/10/21 (Thu) 09:20:20 Y.Yamagishi
    '備　考：2004/10/21 (Thu) 09:20:20 Y.Yamagishi 引継ぎｷｬﾘｱﾀｲﾌﾟID処理追加
    Private Sub prvcmbCarrTyp_Disp(ByRef llngCarrierCnt As Integer, ByRef mtypCarrierMaster As List(Of CarrierMaster))

        Dim llngCarrTypCnt      As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngFirstCarrTypDisp    As Integer          '初回ｷｬﾘｱﾀｲﾌﾟ表示用        
        Try
            
            With cmbCarrTyp
                '@ｷｬﾘｱﾀｲﾌﾟ情報初期化
                .Clear
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol                                    '値取得列
                .GetCol = CMlngCmbGetCol                                        '表示列
                With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                    cmbCarrTyp.Font = _
                        New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbCarrTyp.GridFont = _
                        New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .ColAlignment(CMlngCmbDispColIndex) = TextAlignEnum.LeftCenter  '左寄中央揃え
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .DirectInput = False                                            '直接入力(Flase)
                         
                '@配列のﾙｰﾌﾟ
                For llngCarrTypCnt = 0 To llngCarrierCnt - 1
                    If pstrCarrierTypeID <> vbNullString Then
                        '@引継ｷｬﾘｱﾀｲﾌﾟが存在する場合：そのｷｬﾘｱﾀｲﾌﾟのみｾｯﾄ
                        If pstrCarrierTypeID = mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeID Then
                            .AddItem(mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeName _
                                   & vbTab _
                                   & mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeID)         'ｷｬﾘｱﾀｲﾌﾟ名&ｷｬﾘｱﾀｲﾌﾟID

							'簡易分割画面からの呼び出し かつ 引継ｷｬﾘｱﾀｲﾌﾟがFOUP かつ 組立の場合は、簡易分割仮想ｷｬﾘｱもセット（kkw 蒸着治具紐付け機能改修）
							If pblnMkEasyDivFlag = True And pstrCarrierTypeID = CPstrCarrTypeFOUP And pstrSBID = CPstrSBID2A0 Then
								.AddItem(CMstrCarrierTypeNameI _
								& vbTab _
								& CPstrCarrTypeI)
							End If

							'もし引継ｷｬﾘｱﾀｲﾌﾟが簡易分割仮想ｷｬﾘｱの場合は、FOUPもセット（kkw 蒸着治具紐付け機能改修）
							If pblnMkEasyDivFlag = True And pstrCarrierTypeID = CPstrCarrTypeI And pstrSBID = CPstrSBID2A0 Then
								.AddItem(CMstrCarrierTypeNameFoup _
								& vbTab _
								& CPstrCarrTypeFOUP)
							End If

							Exit For
                        End If
                    Else
                        '@引継ｷｬﾘｱﾀｲﾌﾟが存在しない場合：全てｾｯﾄ
                        .AddItem(mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeName _
                               & vbTab _
                               & mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeID)             'ｷｬﾘｱﾀｲﾌﾟ名&ｷｬﾘｱﾀｲﾌﾟID
                    End If

					'@引継ぎｷｬﾘｱﾀｲﾌﾟIDと取得(格納)ｷｬﾘｱﾀｲﾌﾟが同じか
                    If pstrCarrierTypeID = mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeID Then
                        '@同じ場合、初期値としてｷｬﾘｱﾘｽﾄを取得する為にｲﾝﾃﾞｯｸｽを退避
                        llngFirstCarrTypDisp = .ListCount - 1
                    End If

                Next llngCarrTypCnt
                         
                '@部品種別情報が１件の場合
                If .ListCount = 1 Then
                    '@１件目表示
                    .ListIndex = 0
				Else
					.ListIndex = llngFirstCarrTypDisp
                End If
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbCarrTyp_Disp"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvblnCarrList_Sel
    '機　能：空ｷｬﾘｱﾘｽﾄ取得処理
    '引　数：なし
    '戻り値：True：成功/False：失敗
    '作成日：2005/06/16 (Thu) 12:46:59 S.Deguchi
    '更新日：2006/02/27 (Mon) 10:42:50 N.Kojima
    '備　考：
    '　　　：2005/10/06 (Thu) 14:53:02 S.Deguchi    不具合№2995の対応で要求情報を構造体に変更
    '　　　：2006/02/27 (Mon) 10:42:50 N.Kojima     ｷｬﾘｱ一覧取得 要求に「ｶﾃｺﾞﾘID」追加
    Private Function prvblnCarrList_Sel() As Boolean

        Dim lblnAns             As Boolean          '結果格納
        Dim ltypCarrierListReq  As CarrierListReq   '要求構造体
        
        Try
            
            '@初期化
            prvblnCarrList_Sel = False

			'@ｷｬﾘｱ一覧取得 要求構造体へ情報を格納
            With ltypCarrierListReq
                .strMsgVer = CMstrcarrlist____Ver                       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strClassDivision = CPstrCD2D                           '処理区分：2D 空ｷｬﾘｱ
				If pblnDoubleJPdFlag = True Then
					.strRestrictedSBID = vbNullString                   'ｷｬﾘｱ使用可能ｼｽﾃﾑﾌﾞﾛｯｸID
					.strCategoryID = vbNullString						'ｶﾃｺﾞﾘID
				Else
					.strRestrictedSBID = pstrSBID                       'ｷｬﾘｱ使用可能ｼｽﾃﾑﾌﾞﾛｯｸID
					.strCategoryID = pstrCarrierCategoryID              'ｶﾃｺﾞﾘID
				End If
                
                .strCarrierTypeID = cmbCarrTyp.Value                    'ｷｬﾘｱﾀｲﾌﾟ
                .strCarrierId = vbNullString                            'ｷｬﾘｱID(ｷｬﾘｱID指定時設定)
                .strCleanCondition = pstrCleanCondition                 '洗浄条件
            End With
            
            '@ｷｬﾘｱ一覧取得
            lblnAns = pubblnCarrList_Sel(ltypCarrierListReq, mtypCarrierEmptyList)
            
            '@結果判定
            If lblnAns = True Then
                '@成功の場合
                
                '@描画処理
                If mblnFormLoadFlag = True Then
                    '@初回起動時以外は描画を行う
                    '@取得OKなら結果表示
                    Call prvfrmxxCM00E0_Disp(mtypCarrierEmptyList)
                End If
                
                prvblnCarrList_Sel = True
            End If
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnCarrList_Sel"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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

End Class
