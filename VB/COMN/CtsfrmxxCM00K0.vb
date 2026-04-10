'ﾌｧｲﾙ名：CtsfrmxxCM00K0.vb
'説　明：空SMIF一覧表示画面
'作成日：2004/09/23 (Thu) 13:53:30 Y.Yamagishi
'更新日：2026/04/01 (Wed) 13:17:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2026, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00K0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00K0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00K0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00K0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00K0)
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
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM00K0   'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrcarrlist____Ver              As String = "07.00"          'ｷｬﾘｱ一覧
    Private Const CMstrcarrmaslist_Ver              As String = "05.00"          'ｷｬﾘｱ関連ﾏｽﾀｰ

    '@ComboBox設定
    Private Const CMlngCmbFontSize                  As Integer = 11              'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11              'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                  As Integer = 1               'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbValueCol                  As Integer = 1               '値取得列
    Private Const CMlngCmbGetCol                    As Integer = 0               '表示列
    Private Const CMlngCmbDispColIndex              As Integer = 0               '表示列番

    '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
    Private Const CMstrFormSmif                     As String = "空きSMIF一覧"   '空きSMIF一覧表示時ﾌｫｰﾑﾀｲﾄﾙ
    Private Const CMstrvsfCarrierListSmif           As String = "空きSMIFID"     '空きSMIF一覧表示時ｸﾞﾘｯﾄﾞﾀｲﾄﾙ
    Private Const CMstrvsfCarrierListNo             As String = "№"             '№
    Private Const CMstrvsfCarrierListCreanTime      As String = "最終洗浄日時"   '最終洗浄日時
    Private Const CMstrvsfCarrierListCarrier        As String = "空きキャリアID" '空きキャリア一覧
    Private Const CMstrvsfCarrierListPositionName   As String = "現在位置"       '現在位置

    '@表の行ﾀｲﾄﾙ
    Private Const CMlngvsfCarrierListNo             As Integer = 0               '№
    Private Const CMlngvsfCarrierListCreanTime      As Integer = 1               '最終洗浄日
    Private Const CMlngvsfCarrierListCarrierID      As Integer = 2               'ｷｬﾘｱID
    Private Const CMlngvsfCurrentPositionName       As Integer = 3               '現在位置

    '@表の列幅
    Private Const CMlngvsfWCarrierListNo            As Integer = 30              '№
    Private Const CMlngvsfWCarrierListCreanTime     As Integer = 147             '最終洗浄日
    Private Const CMlngvsfWCarrierListCarrierID     As Integer = 117             'ｷｬﾘｱID
    Private Const CMlngvsfWCurrentPositionName      As Integer = 200             '現在位置

    '@ｸﾞﾘｯﾄﾞの設定
    Private Const CMlngvsfCarrierListRowHeight      As Integer = 24              '行高さ
    Private Const CMlngvsfCarrierListTitleRowHeight As Integer = 20              'ﾀｲﾄﾙ行高さ
    Private Const CMlngvsfCarrierListFontSize       As Integer = 11              'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfCarrierListTitleFontSize  As Integer = 11              'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfCarrierListTitleRow       As Integer = 0               'ﾀｲﾄﾙ行

    Private Const CMstrDefYmdHms                    As String = "0000/00/00 00:00:00"   'ﾃﾞﾌｫﾙﾄ年月日日時
    Private Const CMstrDefY2mdHms                   As String = "00/00/00 00:00:00"     'ﾃﾞﾌｫﾙﾄ年月日日時
    Private Const CMstrDefMdHm                      As String = "00/00 00:00"           'ﾃﾞﾌｫﾙﾄ月日時

	Private Const CMstrCarrierTypeNameFoup			As String = "FOUP"
	Private Const CMstrCarrierTypeNameI				As String = "簡易分割仮想キャリア"
	Private Const CMstrCarrierTypeNameHotOP			As String = "耐熱オープンカセット"
		
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '====================================Private============================================
    Private mstrCarrTypName                         As String                    '退避ｷｬﾘｱﾀｲﾌﾟ名
    Private mtypCarrierEmptyList                    As CarrList                  'ｷｬﾘｱﾘｽﾄ取得結果格納
    Private mtypChgSort                             As ChgSort                   'ｿｰﾄ保持用
    Private mblnFormLoadFlag                        As Boolean                   'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ    
    Private buttonProcessing                        As Boolean                   'NSYS ボタン2度押し対策

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
    '機　能：ﾌｫｰﾑ初期設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 09:23:04 Y.Yamagishi
    '更新日：2005/11/08 (Tue) 10:16:07 N.Kojima
    '備　考：
    '　　　：2004/10/14 (Thu) 16:49:13 Y.Yamagishi  列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
    '　　　：2005/01/05 (Wed) 15:48:00 N.Kasai      pubblnCarrMasList_Selに引数追加（SBID)
    '　　　：2005/11/08 (Tue) 10:16:07 N.Kojima     ①ｺﾝﾎﾞのﾘｽﾄが1件の場合のみ、ｺﾝﾎﾞを無効にする。
    '　　　：                                       ②ｷｬﾘｱﾀｲﾌﾟｺﾝﾎﾞ1件以上あるの場合は、引継ぎ元ｷｬﾘｱﾀｲﾌﾟ0件でも子画面を起動。(ﾕｰｻﾞｰ要望№0104)
    Private Sub Form_Load()
        
        Dim lblnAnsCarrierList      As Boolean                  'ｷｬﾘｱﾘｽﾄ取得結果
        Dim lblnAnsCarrTypList      As Boolean                  'ｷｬﾘｱﾀｲﾌﾟ一覧取得結果
        Dim llngCarrTypListCnt      As Integer                  'ｷｬﾘｱﾀｲﾌﾟ一覧ｶｳﾝﾄ
        Dim ltypCarrierMaster       As List(Of CarrierMaster)   'ｷｬﾘｱﾀｲﾌﾟ一覧取得結果格納
        Dim lstrFormName            As String                   'ﾌｫｰﾑ名
        Dim lstrEventName           As String                   'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        
        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            'cmdClose.Cancel = False
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "Form_Load"

            'NSYS 背景色
            cmbCarrTyp.BackColor = Color.White   
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)
                Else
                    .typChgSortList.Clear()
                End If
                
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@画面の初期化
            Call prvfrmxxCM00K0_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            If IsNothing(ltypCarrierMaster) Then
                ltypCarrierMaster = New List(Of CarrierMaster)
            Else
                ltypCarrierMaster.Clear()
            End If
            
            '@ｷｬﾘｱﾀｲﾌﾟ一覧取得（処理区分：38ｷｬﾘｱﾀｲﾌﾟ）
            lblnAnsCarrTypList = pubblnCarrMasList_Sel(CMstrcarrmaslist_Ver, _
                                                       CPstrCD38, _
                                                       llngCarrTypListCnt, _
                                                       ltypCarrierMaster, _
                                                       pstrSBID)
            '@結果確認
            If lblnAnsCarrTypList = True Then
                '@取得OKなら結果表示
                Call prvcmbCarrTyp_Disp(llngCarrTypListCnt, ltypCarrierMaster)

                '@親画面からｷｬﾘｱﾀｲﾌﾟID引渡しありの場合
                If pstrCarrierTypeID <> vbNullString Then
                    
                    '@情報が1件の場合
                    If cmbCarrTyp.ListCount = 1 Then
                        '@ｺﾝﾎﾞﾎﾞｯｸｽ無効
                        cmbCarrTyp.Enabled = False
                    End If
                    
                    '@空ｷｬﾘｱ取得処理
                    lblnAnsCarrierList = prvblnCarrList_Sel
                    '@結果確認
                    If lblnAnsCarrierList = True Then
                        '@ｷｬﾘｱﾀｲﾌﾟを判定して見出を変更
                        Select Case pstrCarrierTypeID
                            '@SMIF
                            Case CPstrCarrTypeSMIF
                                '@一覧の空きSMIF表示列ﾀｲﾄﾙ変更
                                vsfCarrierList.Redraw = False
                                vsfCarrierList.SetData(CMlngvsfCarrierListTitleRow, _
                                                    CMlngvsfCarrierListCarrierID, CMstrvsfCarrierListSmif)
                                vsfCarrierList.Redraw = True

                                '@ﾌｫｰﾑﾀｲﾄﾙ変更SMIF表示
                                Me.Text = CMstrFormSmif
                        End Select
                    
                        '@ｷｬﾘｱが0件ではない場合
                        If mtypCarrierEmptyList.lngCarrierListCnt <> 0 Then
                            '@Form_Loadﾌﾗｸﾞ（正常）
                            pblnFormLoad = True
                        Else
                            '@0件の場合
                        
                            '@ｷｬﾘｱﾘｽﾄｺﾝﾎﾞが0件ある場合
                            If cmbCarrTyp.ListCount <= 1 Then
                        
                                '@Escﾎﾞﾀﾝを有効
                                'cmdClose.Cancel = True
                                
                                '@Form_Loadﾌﾗｸﾞ（異常）
                                pblnFormLoad = False
                                
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(lstrFormName, lstrEventName)
                                
                                '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0004, lblLotCnt.Text)
                    
                                '@publngMsgBoxInfo("<TRM04I>$$該当データがありません。")
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
                        Call publngResponseEnd(lstrFormName, lstrEventName)
                        
                        Exit Sub
                    Else
                        '@Escﾎﾞﾀﾝを有効
                        'cmdClose.Cancel = True
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        Exit Sub
                    End If
                Else
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@Form_Loadﾌﾗｸﾞ（正常）
                    pblnFormLoad = True
                    
                    Exit Sub
                End If
            Else
                '@Escﾎﾞﾀﾝを有効
                'cmdClose.Cancel = True
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
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
                '@Escﾎﾞﾀﾝを有効
                'cmdClose.Cancel = True
                
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
            
                '@取得OKなら結果表示
                Call prvfrmxxCM00K0_Disp(mtypCarrierEmptyList)
                
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
    '作成日：2004/09/23 (Thu) 13:53:30 Y.Yamagishi
    '更新日：2004/09/23 (Thu) 13:53:30
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
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
                                RemoveHandler cmbCarrTyp.Validating,AddressOf cmbCarrTyp_Validate
                                Call cmbCarrTyp_Validate(cmbCarrTyp, New CancelEventArgs(True))
                                AddHandler cmbCarrTyp.Validating,AddressOf cmbCarrTyp_Validate
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
    '作成日：2004/09/23 (Thu) 13:55:09 Y.Yamagishi
    '更新日：2004/11/02 (Tue) 12:53:19 M.Miura
    '備　考：2004/11/02 (Tue) 12:53:19 M.Miura　    pstrCarrierIDの初期化を削除（空きｷｬﾘｱを選択されない為）
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If Not IsNothing(mtypChgSort.typChgSortList) Then
            	mtypChgSort.typChgSortList.Clear()
            	mtypChgSort.typChgSortList = Nothing
            End If
            
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
    '作成日：2004/09/23 (Thu) 13:53:55 Y.Yamagishi
    '更新日：2004/09/23 (Thu) 13:53:55
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
    '作成日：2004/09/23 (Thu) 13:54:10 Y.Yamagishi
    '更新日：2004/09/23 (Thu) 13:54:10
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
                    pstrCarrierID = .GetData(.Row, CMlngvsfCarrierListCarrierID)    '移載先ｷｬﾘｱID
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
    '作成日：2004/09/23 (Thu) 13:54:55 Y.Yamagishi
    '更新日：2004/10/18 (Mon) 16:54:49 Y.Yamagishi
    '備　考：2004/10/18 (Mon) 16:54:49 Y.Yamagishi 0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    Private Sub cmdLotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotList.Click
        
        Dim lblnAnsCarrierList      As Boolean          'ｷｬﾘｱﾘｽﾄ取得結果
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        
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
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Sub
            End If
                
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "cmdLotList_Click"
            
            '@空白の場合抜ける
            If cmbCarrTyp.Text = vbNullString Then
                '@最新取得ﾎﾞﾀﾝをﾛｯｸ
                cmdLotList.Enabled = False
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@空ｷｬﾘｱﾘｽﾄ取得
            RemoveHandler vsfCarrierList.BeforeRowColChange, AddressOf vsfCarrierList_BeforeRowColChange
            lblnAnsCarrierList = prvblnCarrList_Sel
            AddHandler vsfCarrierList.BeforeRowColChange, AddressOf vsfCarrierList_BeforeRowColChange

            '@結果確認
            If lblnAnsCarrierList = True Then
                '@ﾃﾞｰﾀ表示行が存在するかどうかを判定
                If vsfCarrierList.Rows.Fixed <> vsfCarrierList.Rows.Count Then
                    
                    '@ﾃﾞｰﾀ行がある場合
                    Call pubSetFocus(vsfCarrierList)
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                Else
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
        '
        '            '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
        '            '@表示ﾒｯｾｰｼﾞ変換
        '            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, lblLotCnt.Caption)
        '            '@publngMsgBoxInfo("メッセージコード：C_I29%0$$該当件数 ： 0 件")
        '            Call publngMsgBoxInfo(pstrDMsg, vbInformation, frmxxCM00K0.Caption, True, 16)
                End If
                
                '@ｷｬﾘｱﾀｲﾌﾟ名を取得する
                mstrCarrTypName = cmbCarrTyp.Text
                
                Exit Sub
            Else
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
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
    '作成日：2004/09/23 (Thu) 13:54:21 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 16:49:57 Y.Yamagishi
    '備　考：2004/10/14 (Thu) 16:49:57 Y.Yamagishi 列幅、ｿｰﾄ順、ｶﾚﾝﾄ行の保持修正
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
    '作成日：2004/09/23 (Thu) 13:54:32 Y.Yamagishi
    '更新日：2004/09/23 (Thu) 13:54:32
    '備　考：
    Private Sub cmbCarrTyp_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCarrTyp.CloseUp

        Try

            '@Validate処理へ
            RemoveHandler cmbCarrTyp.Validating,AddressOf cmbCarrTyp_Validate
            Call cmbCarrTyp_Validate(cmbCarrTyp, New CancelEventArgs(True))
            AddHandler cmbCarrTyp.Validating,AddressOf cmbCarrTyp_Validate

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
    '作成日：2004/09/23 (Thu) 13:54:43 Y.Yamagishi
    '更新日：2004/09/23 (Thu) 13:54:43
    '備　考：
    Private Sub cmbCarrTyp_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbCarrTyp.Validating

        Dim lblnAnsCarrierList      As Boolean          'ｷｬﾘｱﾘｽﾄ取得結果
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
        
        Try

            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "cmbCarrTyp_Validate"
            
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
            RemoveHandler cmbCarrTyp.Validating, AddressOf cmbCarrTyp_Validate
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@空ｷｬﾘｱﾘｽﾄ取得
            lblnAnsCarrierList = prvblnCarrList_Sel
            '@結果確認
            If lblnAnsCarrierList = True Then
                '@ﾃﾞｰﾀ表示行が存在するかどうかを判定
                If vsfCarrierList.Rows.Fixed <> vsfCarrierList.Rows.Count Then
                    '@ﾃﾞｰﾀ行がある場合
                    If ActiveControl.Name = cmbCarrTyp.Name Then
                        Call pubSetFocus(vsfCarrierList)
                    End If
                  
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

        '            '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
        '            '@表示ﾒｯｾｰｼﾞ変換
        '            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, lblLotCnt.Caption)
        '            '@publngMsgBoxInfo("メッセージコード：C_I29%0$$該当件数 ： 0 件")
        '            Call publngMsgBoxInfo(pstrDMsg, vbInformation, frmxxCM00K0.Caption, True, 16)
                End If
                
                '@ｷｬﾘｱﾀｲﾌﾟ名を取得する
                mstrCarrTypName = cmbCarrTyp.Text
                AddHandler cmbCarrTyp.Validating, AddressOf cmbCarrTyp_Validate 
                
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                AddHandler cmbCarrTyp.Validating, AddressOf cmbCarrTyp_Validate 
                
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

    '関数名：vsfCarrierList_AfterSort
    '機　能：vsfCarrierList_AfterSort処理
    '引　数：Col：未使用
    '　　　：Order：未使用
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 13:55:20 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 16:50:49 Y.Yamagishi
    '備　考：2004/10/14 (Thu) 16:50:49 Y.Yamagishi  列幅、ソート順、ｶﾚﾝﾄ行の保持修正
    Private Sub vsfCarrierList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfCarrierList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ後処理
            Call pubVsfAfterSort(vsfCarrierList, _
                                 CMlngvsfCarrierListNo & _
                                 vbTab & _
                                 CMlngvsfCarrierListCreanTime & _
                                 vbTab & _
                                 CMlngvsfCarrierListCarrierID & _
                                 vbTab & CMlngvsfCurrentPositionName)
                
            '@ｿｰﾄ順を格納
            With mtypChgSort
                Dim ltypChgSortListTmp As ChgSortList
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                
                '@ｿｰﾄ列番号を格納
                ltypChgSortListTmp.lngCol = e.Col
                
                '@並び替え方法を格納（昇順/降順）
                ltypChgSortListTmp.lngOrder = e.Order

                .typChgSortList.Add(ltypChgSortListTmp)
            End With
            
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
    '作成日：2004/10/14 (Thu) 16:54:20 Y.Yamagishi
    '更新日：2004/10/14 (Thu) 16:54:20
    '備　考：
    Private Sub vsfCarrierList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfCarrierList.BeforeRowColChange
        
        Try
        
            'NSYS ヘッダ行クリック時処理を抜ける
            If vsfCarrierList.MouseRow <= 0 Then
                Exit Sub
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfCarrierList.Rows.Count <= vsfCarrierList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｬﾘｱID)
                mtypChgSort.strKey = vsfCarrierList.GetData(e.NewRange.r1, _
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
    '作成日：2004/09/23 (Thu) 13:55:31 Y.Yamagishi
    '更新日：2004/09/23 (Thu) 13:55:31
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
    '作成日：2004/09/23 (Thu) 13:55:43 Y.Yamagishi
    '更新日：2004/09/23 (Thu) 13:55:43
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
            Call cmdChoice_Click(cmdChoice, New EventArgs())

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
            
            'NSYS クリック行がヘッダ行の場合は処理を抜ける
            If vsfCarrierList.MouseRow < vsfCarrierList.Rows.Fixed Then
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

    '関数名：prvfrmxxCM00K0_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 13:55:55 Y.Yamagishi
    '更新日：2004/09/23 (Thu) 13:55:55
    '備　考：
    Private Sub prvfrmxxCM00K0_Init()
        
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
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM00K0_Init"        '処理名
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
    '作成日：2004/09/23 (Thu) 13:56:07 Y.Yamagishi
    '更新日：2004/09/23 (Thu) 13:56:07
    '備　考：
    Private Sub prvvsfCarrierList_Init()
        Dim lNormalStyle    As CellStyle
        Dim lFixedStyle     As CellStyle
        
        Try
            
            With vsfCarrierList

                'NSYS 再描画停止
                .Redraw = False

                '@ｷｬﾘｱﾘｽﾄｸﾘｱ
                vsfCarrierList.Rows.Count = 1
            
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

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfCarrierListTitleRow, CMlngvsfCarrierListNo, CMstrvsfCarrierListNo)
                .SetData(CMlngvsfCarrierListTitleRow, CMlngvsfCarrierListCreanTime, CMstrvsfCarrierListCreanTime)
                .SetData(CMlngvsfCarrierListTitleRow, CMlngvsfCarrierListCarrierID, CMstrvsfCarrierListCarrier)
                .SetData(CMlngvsfCarrierListTitleRow, CMlngvsfCurrentPositionName, CMstrvsfCarrierListPositionName)
                    
                
                '@見出し行の文字位置設定
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞのｿｰﾄ指定
                .AllowSorting = AllowSortingEnum.SingleColumn
                
                'NSYS 再描画再開
                .Redraw = True
                
            End With
            
            '@ｷｬﾘｱﾀｲﾌﾟ名初期化
            mstrCarrTypName = vbNullString
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfCarrierList_Init"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvfrmxxCM00K0_Disp
    '機　能：ｷｬﾘｱﾘｽﾄ表示
    '引　数：ltypCarrierAllList:表示ﾃﾞｰﾀ格納
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 13:56:18 Y.Yamagishi
    '更新日：2005/06/01 (Wed) 15:42:06 N.Kojima
    '備　考：2004/10/12 (Tue) 11:45:40 N.Kasai      0件ﾀﾞｲｱﾛｸﾞ表示の後にﾚｽﾎﾟﾝｽ時間計測を終了している為、0件表示を外出し
    '　　　：2004/10/14 (Thu) 16:57:50 Y.Yamagishi  列幅、ソート順、ｶﾚﾝﾄ行の保持修正
    '　　　：2005/06/01 (Wed) 15:42:06 N.Kojima     最終洗浄日時のﾌｫｰﾏｯﾄを「YYYY/MM/DD HH:MM」に統一(不具合№430)
    '　　　：2005/06/16 (Thu) 11:06:28 S.Deguchi    起動時ﾀｲﾄﾙ行を選択させるように修正
    Private Sub prvfrmxxCM00K0_Disp(ByRef ltypCarrierEmptyList As CarrList)
        
        Dim llngCnt                     As Integer      'ｷｬﾘｱのｶｳﾝﾄ数
        Dim llngCarrierListCnt          As Integer      'ｷｬﾘｱﾘｽﾄのｶｳﾝﾄ数
        
        Try
            
            With vsfCarrierList
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@ﾃﾞｰﾀ表示
                llngCnt = 0
                llngCarrierListCnt = 1
                
                '@行数設定
                vsfCarrierList.Rows.Count = ltypCarrierEmptyList.lngCarrierListCnt + 1
                
                '@ﾃﾞｰﾀｾｯﾄ(ﾃﾞｰﾀがある場合)
                If vsfCarrierList.Rows.Count > 1 Then
                    Do While ltypCarrierEmptyList.lngCarrierListCnt -1 >= llngCnt
                        With ltypCarrierEmptyList.typCarrierList(llngCnt)
                            vsfCarrierList.SetData(llngCarrierListCnt, CMlngvsfCarrierListNo, _
                                llngCarrierListCnt)                                        '№

                            '@最終洗浄日時が「0000/00/00 00:00:00」の場合
                            If .strCreanTime = CMstrDefYmdHms Then
                                vsfCarrierList.SetData(llngCarrierListCnt, CMlngvsfCarrierListCreanTime, _
                                    CMstrDefY2mdHms)                                       '最終洗浄日時（「00/00/00 00:00:00」）
                            Else
                            	'NSYS 最終洗浄日時が日付形式の場合
                                If IsDate(.strCreanTime) = True Then
                                vsfCarrierList.SetData(llngCarrierListCnt, CMlngvsfCarrierListCreanTime, _
                                    Format$(CDate(.strCreanTime), CPstrDateTimeY2MDHMS))   '最終洗浄日時
                                'NSYS 最終洗浄日時が日付形式ではない場合
                                Else
                                	vsfCarrierList.SetData(llngCarrierListCnt, CMlngvsfCarrierListCreanTime, .strCreanTime)
                                End If
                            End If
                            
                            vsfCarrierList.SetData(llngCarrierListCnt, CMlngvsfCarrierListCarrierID, _
                                .strCarrierId)                                             'ｷｬﾘｱID
                            
                            vsfCarrierList.SetData(llngCarrierListCnt, CMlngvsfCurrentPositionName, _
                                .strCurrentPositionName)                                   '現在位置
                            
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
                        .Row = CMlngvsfCarrierListTitleRow
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
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM00K0_Disp"        '処理名
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
    '作成日：2004/09/23 (Thu) 13:56:31 Y.Yamagishi
    '更新日：2026/04/01 (Wed) 13:17:00 T.Oide
    '備　考：
    Private Sub prvcmbCarrTyp_Disp(ByRef llngCarrierCnt As Integer, ByRef mtypCarrierMaster As List(Of CarrierMaster))

        Dim llngCarrTypCnt          As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngFirstCarrTypDisp    As Integer              '初回ｷｬﾘｱﾀｲﾌﾟ表示用
        
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
                .DirectInput = False                                            '直接入力(Flase)

                '@配列のﾙｰﾌﾟ
                For llngCarrTypCnt = 0 To llngCarrierCnt - 1
                    
                    If pstrCarrierTypeID <> vbNullString Then
                            
                        '@ｷｬﾘｱ管理or在庫管理経由でのｷｬﾘｱ管理起動の場合
                        If pblnfrmxxCM00C0Kbn = True Or ptypHoldConnect.strSbID <> vbNullString Then
                            
                            '@ﾀｲﾌﾟﾌﾗｸﾞが"1"ではない場合(同一ｷｬﾘｱﾀｲﾌﾟのみ交換可の場合)
                            If pstrTypeFlag = CPstrOne Then
                                
                                '@ｷｬﾘｱﾀｲﾌﾟﾌﾗｸﾞ="1"のｷｬﾘｱﾀｲﾌﾟを全てｾｯﾄ
                                If mtypCarrierMaster(llngCarrTypCnt).strTypeFlag = CPstrOne Then
                                    '@ｷｬﾘｱﾀｲﾌﾟ=OPｶｾｯﾄはｾｯﾄしない
                                    If mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeID <> CPstrCarrTypeOP Then
                        
                                        '@引継ぎされたﾛｯﾄ状態が空白以外の場合(中間在庫以外）
                                        If pstrRelatedLotStatus <> vbNullString Then
                                            '@FOSBは対象外
                                            If mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeID <> CPstrCarrTypeFOSB Then
                                                
                                                .AddItem(mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeName _
                                                   & vbTab _
                                                   & mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeID)         'ｷｬﾘｱﾀｲﾌﾟ名&ｷｬﾘｱﾀｲﾌﾟID
                                            End If
                                        Else
                                            .AddItem(mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeName _
                                               & vbTab _
                                               & mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeID)         'ｷｬﾘｱﾀｲﾌﾟ名&ｷｬﾘｱﾀｲﾌﾟID
                                        End If
                                        
                                    Else
                                        '@SB=組立、引継ぎｷｬﾘｱID(交換元ｷｬﾘｱID)が"ｵｰﾌﾟﾝｶｾｯﾄ"の場合は、"ｵｰﾌﾟﾝｶｾｯﾄ"もｾｯﾄする
                                        If pstrCarrierTypeID = CPstrCarrTypeOP Or pstrSBID = CPstrSBID2A0 Or _
                                            ptypHoldConnect.strSbID = CPstrSBID2A0 Then
                                            
                                            .AddItem(mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeName _
                                                   & vbTab _
                                                   & mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeID)         'ｷｬﾘｱﾀｲﾌﾟ名&ｷｬﾘｱﾀｲﾌﾟID
                                        End If
									End If
                                End If
                            Else
                                '@引継ｷｬﾘｱﾀｲﾌﾟが存在する場合：そのｷｬﾘｱﾀｲﾌﾟのみｾｯﾄ
                                If pstrCarrierTypeID = mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeID Then
                                    .AddItem(mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeName _
                                           & vbTab _
                                           & mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeID)         'ｷｬﾘｱﾀｲﾌﾟ名&ｷｬﾘｱﾀｲﾌﾟID

									'ｷｬﾘｱ交換からの呼び出し かつ 引継ｷｬﾘｱﾀｲﾌﾟが簡易分割仮想ｷｬﾘｱ かつ　組立の場合は、FOUP、耐熱オープン(J)もセット（kkw 蒸着治具紐付け機能改修）
									If  pblnfrmxxCM00C0Kbn = True And pstrCarrierTypeID = CPstrCarrTypeI And pstrSBID = CPstrSBID2A0 Then
										.AddItem(CMstrCarrierTypeNameFoup _
										& vbTab _
										& CPstrCarrTypeFOUP)
										
										.AddItem(CMstrCarrierTypeNameHotOP _
										& vbTab _
										& CPstrCarrTypeHotOP)

									End If

                                    Exit For
                                End If
                            End If
                        Else

                            'ｷｬﾘｱﾀｲﾌﾟｺﾝﾎﾞのｱｲﾃﾑ追加ﾌﾗｸﾞ
                            Dim lblnAddFlag As Boolean = False

                            '@引継ｷｬﾘｱﾀｲﾌﾟが存在する場合：そのｷｬﾘｱﾀｲﾌﾟのみｾｯﾄ
                            If pstrCarrierTypeID = mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeID Then
                                .AddItem(mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeName _
                                    & vbTab _
                                    & mtypCarrierMaster(llngCarrTypCnt).strCarrierTypeID)         'ｷｬﾘｱﾀｲﾌﾟ名&ｷｬﾘｱﾀｲﾌﾟID
                                lblnAddFlag = True
                            End If

							'ODF予約(蒸着)からの呼び出し かつ　組立の場合は、耐熱オープン(J)もセット（kkw 組立投入方法変更）
							If pblnfrmxxEn02U0Kbn = True And pstrSBID = CPstrSBID2A0 Then								
								.AddItem(CMstrCarrierTypeNameHotOP _
								    & vbTab _
								    & CPstrCarrTypeHotOP)
                                lblnAddFlag = True
							End If
							
                            '上記いずれかで.AddItemした場合ﾙｰﾌﾟ終了
                            If lblnAddFlag = True Then
							    Exit For
                            End If

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
                         
                '@情報が1件の場合
                If .ListCount = 1 Then
                    '@1件目表示
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
    '更新日：2006/02/27 (Mon) 10:44:55 N.Kojima
    '備　考：
    '　　　：2005/10/06 (Thu) 14:53:02 S.Deguchi    不具合№2995の対応で要求情報を構造体に変更
    '　　　：2005/11/07 (Mon) 09:52:03 N.Kojima     ｷｬﾘｱ管理からの起動の場合は、要求に交換元ｷｬﾘｱIDをｾｯﾄする。(ﾕｰｻﾞｰ要望№0104)
    '　　　：2006/02/27 (Mon) 10:44:55 N.Kojima     ｷｬﾘｱ一覧取得 要求に「ｶﾃｺﾞﾘID」追加
    Private Function prvblnCarrList_Sel() As Boolean

        Dim lblnAns             As Boolean          '結果格納
        Dim ltypCarrierListReq  As CarrierListReq   '要求構造体
        
        Try
            
            '@初期化
            prvblnCarrList_Sel = False
            
            '@在庫管理からの起動の場合
            If ptypHoldConnect.strSbID <> vbNullString Then

                '@ｷｬﾘｱ一覧取得 要求構造体へ情報を格納
                With ltypCarrierListReq
                    .strMsgVer = CMstrcarrlist____Ver                       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                    .strSbID = ptypHoldConnect.strSbID                      'ｼｽﾃﾑﾌﾞﾛｯｸ
                    .strClassDivision = CPstrCD2D                           '処理区分：2D 空ｷｬﾘｱ
                    .strRestrictedSBID = ptypHoldConnect.strSbID            'ｷｬﾘｱ使用可能ｼｽﾃﾑﾌﾞﾛｯｸID
                    .strCarrierTypeID = cmbCarrTyp.Value                    'ｷｬﾘｱﾀｲﾌﾟ
                    .strCarrierId = vbNullString                            'ｷｬﾘｱID(交換元ｷｬﾘｱID指定)
                    .strCleanCondition = pstrCleanCondition                 '洗浄条件
                    .strCategoryID = vbNullString                           'ｶﾃｺﾞﾘID
                End With

            '@在庫管理以外からの起動の場合
            Else
            
                '@ｷｬﾘｱ一覧取得 要求構造体へ情報を格納
                With ltypCarrierListReq
                    .strMsgVer = CMstrcarrlist____Ver                       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                    .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                    .strClassDivision = CPstrCD2D                           '処理区分：2D 空ｷｬﾘｱ
                    .strRestrictedSBID = pstrSBID                           'ｷｬﾘｱ使用可能ｼｽﾃﾑﾌﾞﾛｯｸID
                    .strCarrierTypeID = cmbCarrTyp.Value                    'ｷｬﾘｱﾀｲﾌﾟ
                    .strCarrierId = vbNullString                            'ｷｬﾘｱID(ｷｬﾘｱID指定時設定)
                    .strCleanCondition = pstrCleanCondition                 '洗浄条件
				'@組立投入方法変更、耐熱オープンカセットの場合は蒸着カテゴリ限定とする
				If pblnfrmxxEn02U0Kbn = True And pstrSBID = CPstrSBID2A0 And .strCarrierTypeID = CPstrCarrTypeHotOP Then
					.strCategoryID = CPstrCarrCateJyo                  '耐熱オープンカセットの蒸着カテゴリ限定
				Else
					.strCategoryID = pstrCarrierCategoryID                  'ｶﾃｺﾞﾘID
				End If
                    
        '@↑2009/05/28 (Thu) 19:42:58 Y.Yoneyama **************************************************
                End With
            End If
            
            '@ｷｬﾘｱ一覧取得
            lblnAns = pubblnCarrList_Sel(ltypCarrierListReq, mtypCarrierEmptyList)
            
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
                
                '@描画処理
                If mblnFormLoadFlag = True Then
                '@初回起動時以外は描画を行う
                    '@取得OKなら結果表示
                    Call prvfrmxxCM00K0_Disp(mtypCarrierEmptyList)
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


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfCarrierList.BeforeDoubleClick

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
            gridObj.AutoSizeCol(colindex,6)
        End If

    End Sub

End Class
