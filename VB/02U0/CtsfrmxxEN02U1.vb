'ﾌｧｲﾙ名：xxEN02U1.frm 
'説　明：蒸着後流動予約一覧取得画面
'作成日：
'更新日：
'備　考：

'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02U1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02U1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02U1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02U1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02U1)
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
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN02U0   'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_afterjrsvlistVer		As String = "01.00"         '蒸着後流動予約情報一覧取得
    Private Const CMstrcarrmaslist_Ver              As String = "05.00"          'ｷｬﾘｱ関連ﾏｽﾀｰ



    '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
    Private Const CMstrFormAfterJReserveList				As String = "蒸着後流動予約情報一覧"   '空きSMIF一覧表示時ﾌｫｰﾑﾀｲﾄﾙ
    Private Const CMstrvsfAfterJReserveList					As String = "蒸着後流動予約情報一覧"     
    Private Const CMstrvsfAfterJReserveListNo				As String = "№"             '№
    Private Const CMstrvsfAfterJReserveListReserveId		As String = "予約ID"		'予約ID
    Private Const CMstrvsfAfterJReserveListLotId			As String = "予約時ロットID"		'ロットID
    Private Const CMstrvsfAfterJReserveListEntryTime		As String = "登録日時"     '現在位置
    Private Const CMstrvsfAfterJReserveListEmpName			As String = "登録者"       '登録者

    '@表の行ﾀｲﾄﾙ
    Private Const CMlngvsfAfterJReserveListNo				 As Integer = 0               '№
    Private Const CMlngvsfAfterJReserveListReserveId		As Integer = 1               '予約ID
    Private Const CMlngvsfAfterJReserveListLotId			As Integer = 2               'ロットID
	Private Const CMlngvsfAfterJReserveListEntryTime		As Integer = 3               '登録日
	Private Const CMlngvsfAfterJReserveListEmpName			As Integer = 4               '登録者

    '@表の列幅
    Private Const CMlngvsfAfterJReserveListNoW				As Integer = 30              '№
    Private Const CMlngvsfAfterJReserveListReserveIdW		As Integer = 60             '予約ID
    Private Const CMlngvsfAfterJReserveListLotIdW			As Integer = 130             'ロットID
    Private Const CMlngvsfAfterJReserveListEntryTimeW		As Integer = 160             '登録日
	Private Const CMlngvsfAfterJReserveListEmpNameW			As Integer = 130             '登録者

    '@ｸﾞﾘｯﾄﾞの設定
    Private Const CMlngvsfAfterJReserveListRowHeight      As Integer = 24              '行高さ
    Private Const CMlngvsfAfterJReserveListTitleRowHeight As Integer = 20              'ﾀｲﾄﾙ行高さ
    Private Const CMlngvsfAfterJReserveListFontSize       As Integer = 11              'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfAfterJReserveListTitleFontSize  As Integer = 11              'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfAfterJReserveListTitleRow       As Integer = 0               'ﾀｲﾄﾙ行

    Private Const CMstrDefYmdHms                    As String = "0000/00/00 00:00:00"   'ﾃﾞﾌｫﾙﾄ年月日日時
    Private Const CMstrDefY2mdHms                   As String = "00/00/00 00:00:00"     'ﾃﾞﾌｫﾙﾄ年月日日時
    Private Const CMstrDefMdHm                      As String = "00/00 00:00"           'ﾃﾞﾌｫﾙﾄ月日時


		
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '====================================Private============================================
    'Private mstrCarrTypName                         As String                    '退避ｷｬﾘｱﾀｲﾌﾟ名
    Private mtypAfterJReserveList                   As AfterJReserveList         'ﾘｽﾄ取得結果格納
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
    '作成日：
    '更新日：
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
    '作成日：
    '更新日：
    '備　考：

    Private Sub Form_Load()

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
            Call prvfrmxxEN02U1_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
			'最新取得ボタン押下処理
            Call cmdAfterJReserveList_Click(cmdAfterJReserveList,New EventArgs)

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
    '作成日：2004/09/23 (Thu) 11:44:57 
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
                Call prvfrmxxEN02U1_Disp(mtypAfterJReserveList)
                
                '@ﾘｽﾄが0件以上の場合最新取得ﾎﾞﾀﾝを活性化
                If mtypAfterJReserveList.lngAfterJReserveListCnt > 0 Then
                    cmdAfterJReserveList.Enabled = True
                End If
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
    '作成日：2004/09/23 (Thu) 13:53:30 
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
        
                    
                '@一覧の場合
                Case vsfAfterJReserveList.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            With vsfAfterJReserveList
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
    '作成日： 
    '更新日：
    '備　考：
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
    '作成日：2004/09/23 (Thu) 13:53:55 
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
    '作成日：2004/09/23 (Thu) 13:54:10 
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
            If vsfAfterJReserveList.Row >= 1 Then
                With vsfAfterJReserveList
                    pstrReserveId = .GetData(.Row, CMlngvsfAfterJReserveListReserveId)    '移載先ｷｬﾘｱID
					pstrLotId = .GetData(.Row, CMlngvsfAfterJReserveListLotId)    'ロットID
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

    '関数名：cmdAfterJReserveList_Click
    '機　能：最新取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日： 
    '備　考：
    Private Sub cmdAfterJReserveList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAfterJReserveList.Click
        
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

            '@ﾚｽﾎﾟﾝｽ開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾘｽﾄ取得
            RemoveHandler vsfAfterJReserveList.BeforeRowColChange, AddressOf vsfAfterJReserveList_BeforeRowColChange
            lblnAnsCarrierList = prvblnAfterJReserveList_Sel
            AddHandler vsfAfterJReserveList.BeforeRowColChange, AddressOf vsfAfterJReserveList_BeforeRowColChange

            '@結果確認
            If lblnAnsCarrierList = True Then
                '@ﾃﾞｰﾀ表示行が存在するかどうかを判定
                If vsfAfterJReserveList.Rows.Fixed <> vsfAfterJReserveList.Rows.Count Then
                    '@ﾃﾞｰﾀ行がある場合
                    Call pubSetFocus(vsfAfterJReserveList)
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
				End If
				
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

 





    '関数名：vsfAfterJReserveList_AfterSort
    '機　能：vsfAfterJReserveList_AfterSort処理
    '引　数：Col：未使用
    '　　　：Order：未使用
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 13:55:20 
    '更新日：2004/10/14 (Thu) 16:50:49 
    '備　考：2004/10/14 (Thu) 16:50:49   列幅、ソート順、ｶﾚﾝﾄ行の保持修正
    Private Sub vsfAfterJReserveList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfAfterJReserveList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfAfterJReserveList.Rows.Count <= vsfAfterJReserveList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ後処理
            Call pubVsfAfterSort(vsfAfterJReserveList, _
                                  CMlngvsfAfterJReserveListNo & _
                                  vbTab & _
                                  CMlngvsfAfterJReserveListReserveId & _
                                  vbTab & _
                                  CMlngvsfAfterJReserveListLotID & _
                                  vbTab & _
                                  CMlngvsfAfterJReserveListEntryTime & _
								  vbTab & _ 
								  CMlngvsfAfterJReserveListEmpName)
                
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
                .strProcName = "vsfAfterJReserveList_AfterSort"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfAfterJReserveList_BeforeRowColChange
    '機　能：変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 16:54:20 
    '更新日：2004/10/14 (Thu) 16:54:20
    '備　考：
    Private Sub vsfAfterJReserveList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfAfterJReserveList.BeforeRowColChange
        
        Try
        
            'NSYS ヘッダ行クリック時処理を抜ける
            If vsfAfterJReserveList.MouseRow <= 0 Then
                Exit Sub
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfAfterJReserveList.Rows.Count <= vsfAfterJReserveList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｬﾘｱID)
                mtypChgSort.strKey = vsfAfterJReserveList.GetData(e.NewRange.r1, _
                                                         CMlngvsfAfterJReserveListReserveID)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                         '機能ID
                .strProcName = "vsfAfterJReserveList_BeforeRowColChange"      '処理名
                .strErrMessage = vbNullString                           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfAfterJReserveList_BeforeSort
    '機　能：vsfAfterJReserveList_BeforeSort処理
    '引　数：Col：未使用
    '　　　：Order：未使用
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 13:55:31 
    '更新日：2004/09/23 (Thu) 13:55:31
    '備　考：
    Private Sub vsfAfterJReserveList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfAfterJReserveList.BeforeSort
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfAfterJReserveList.Rows.Count <= vsfAfterJReserveList.Rows.Fixed Then
                Return
            End If
            
            '@ｿｰﾄ前処理
            Call pubVsfBeforeSort(vsfAfterJReserveList, _
                                  CMlngvsfAfterJReserveListNo & _
                                  vbTab & _
                                  CMlngvsfAfterJReserveListReserveId & _
                                  vbTab & _
                                  CMlngvsfAfterJReserveListLotID & _
                                  vbTab & _
                                  CMlngvsfAfterJReserveListEntryTime & _
								  vbTab & _ 
								  CMlngvsfAfterJReserveListEmpName)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfAfterJReserveList_BeforeSort"  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAfterJReserveList_DblClick
    '機　能：ｷｬﾘｱ一覧ﾀﾞﾌﾞﾙｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 13:55:43 
    '更新日：2004/09/23 (Thu) 13:55:43
    '備　考：
    Private Sub vsfAfterJReserveList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfAfterJReserveList.DoubleClick

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            'NSYS データ行がない場合は処理を抜ける
            If vsfAfterJReserveList.Rows.Count <= vsfAfterJReserveList.Rows.Fixed Then
                Return
            End If

            '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
            If vsfAfterJReserveList.MouseRow = 0 Then
                Exit Sub
            End If
                
            '@選択確定
            Call cmdChoice_Click(cmdChoice, New EventArgs())

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfAfterJReserveList_DblClick"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAfterJReserveList_RowColChange
    '機　能：ｷｬﾘｱ一覧選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/16 (Thu) 11:37:23 S.Deguchi
    '更新日：2005/06/16 (Thu) 11:37:23
    '備　考：
    Private Sub vsfAfterJReserveList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfAfterJReserveList.RowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfAfterJReserveList.Rows.Count <= vsfAfterJReserveList.Rows.Fixed Then
                Return
            End If
            
            'NSYS クリック行がヘッダ行の場合は処理を抜ける
            If vsfAfterJReserveList.MouseRow < vsfAfterJReserveList.Rows.Fixed Then
                Return
            End If

            '@ﾀｲﾄﾙ以外を選択した場合
            With vsfAfterJReserveList
                If .Row > 0 Then
                    '@選択行のｷｬﾘｱIDが空欄ではない場合
                    If .GetData(.Row, CMlngvsfAfterJReserveListReserveID) <> vbNullString Then
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
                .strProcName = "vsfAfterJReserveList_RowColChange"    '処理名
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

    '関数名：prvfrmxxEN02U1_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日： 
    '更新日：
    '備　考：
    Private Sub prvfrmxxEN02U1_Init()
        
        Try
            
            '@最新取得ﾎﾞﾀﾝをﾛｯｸ
            cmdAfterJReserveList.Enabled = False
            
            '@情報取得日時初期化
            lblNowDate.Text = vbNullString
            
            '@件数ｸﾘｱ
            lblAfterJReserveCnt.Text = vbNullString
            
            '@閉じるﾎﾞﾀﾝはValidate無効
            cmdClose.CausesValidation = False
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfAfterJReserveList_Init()
            
            '@選択確定ﾎﾞﾀﾝ使用不可
            cmdChoice.Enabled = False
            
            '@ｷｬﾘｱID引継ぎ変数初期化
            pstrReserveId = vbNullString
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN02U1_Init"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvvsfAfterJReserveList_Init
    '機　能：ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub prvvsfAfterJReserveList_Init()
        Dim lNormalStyle    As CellStyle
        Dim lFixedStyle     As CellStyle
        
        Try
            
            With vsfAfterJReserveList

                'NSYS 再描画停止
                .Redraw = False

                '@ｷｬﾘｱﾘｽﾄｸﾘｱ
                vsfAfterJReserveList.Rows.Count = 1
            
                '@行の高さ指定
                .Rows.DefaultSize = CMlngvsfAfterJReserveListRowHeight
                .Rows(0).Height = CMlngvsfAfterJReserveListTitleRowHeight
                
                '@ﾌｫﾝﾄの設定
                lNormalStyle = .Styles.Normal
                lFixedStyle = .Styles.Fixed
                With .Font
                    lNormalStyle.Font = New Font(.FontFamily, CMlngvsfAfterJReserveListFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .Select(0, CMlngvsfAfterJReserveListNo, .Rows.Fixed - 1, CMlngvsfAfterJReserveListEmpName)
                With .Font
                    lFixedStyle.Font = New Font(.FontFamily, CMlngvsfAfterJReserveListTitleFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                
                '@見出し行の色設定
                lFixedStyle.BackColor = Color.Navy
                lFixedStyle.ForeColor = Color.Yellow
                
                '@列幅の設定
                .Cols(CMlngvsfAfterJReserveListNo).Width = CMlngvsfAfterJReserveListNoW
                .Cols(CMlngvsfAfterJReserveListReserveId).Width = CMlngvsfAfterJReserveListReserveIdW
                .Cols(CMlngvsfAfterJReserveListLotId).Width = CMlngvsfAfterJReserveListLotIdW
                .Cols(CMlngvsfAfterJReserveListEntryTime).Width = CMlngvsfAfterJReserveListEntryTimeW
				.Cols(CMlngvsfAfterJReserveListEmpName).Width = CMlngvsfAfterJReserveListEmpNameW

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfAfterJReserveListTitleRow, CMlngvsfAfterJReserveListNo, CMstrvsfAfterJReserveListNo)
                .SetData(CMlngvsfAfterJReserveListTitleRow, CMlngvsfAfterJReserveListReserveId, CMstrvsfAfterJReserveListReserveId)
                .SetData(CMlngvsfAfterJReserveListTitleRow, CMlngvsfAfterJReserveListLotId, CMstrvsfAfterJReserveListLotId)
                .SetData(CMlngvsfAfterJReserveListTitleRow, CMlngvsfAfterJReserveListEntryTime, CMstrvsfAfterJReserveListEntryTime)
                .SetData(CMlngvsfAfterJReserveListTitleRow, CMlngvsfAfterJReserveListEmpName, CMstrvsfAfterJReserveListEmpName)
                
                '@見出し行の文字位置設定
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞのｿｰﾄ指定
                .AllowSorting = AllowSortingEnum.SingleColumn
                
                'NSYS 再描画再開
                .Redraw = True
                
            End With
            
            '@ｷｬﾘｱﾀｲﾌﾟ名初期化
            'mstrCarrTypName = vbNullString
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfAfterJReserveList_Init"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With


            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

            
        End Try
    End Sub

    '関数名：prvfrmxxEN02U1_Disp
    '機　能：ｷｬﾘｱﾘｽﾄ表示
    '引　数：ltypAfterJReserveList:表示ﾃﾞｰﾀ格納
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub prvfrmxxEN02U1_Disp(ByRef ltypAfterJReserveList As AfterJReserveList)
        
        Dim llngCnt                     As Integer      'ｶｳﾝﾄ数
        Dim llngAfterJReserveListCnt    As Integer      'ﾘｽﾄのｶｳﾝﾄ数
        
        Try
            
            With vsfAfterJReserveList
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@ﾃﾞｰﾀ表示
                llngCnt = 0
                llngAfterJReserveListCnt = 1
                
                '@行数設定
                vsfAfterJReserveList.Rows.Count = ltypAfterJReserveList.lngAfterJReserveListCnt + 1
                
                '@ﾃﾞｰﾀｾｯﾄ(ﾃﾞｰﾀがある場合)
                If vsfAfterJReserveList.Rows.Count > 1 Then
                    Do While ltypAfterJReserveList.lngAfterJReserveListCnt -1 >= llngCnt
                        With ltypAfterJReserveList.typAfterJReserveList(llngCnt)

                            vsfAfterJReserveList.SetData(llngAfterJReserveListCnt, CMlngvsfAfterJReserveListNo, _
                                llngAfterJReserveListCnt)                                        '№

							                            
                            vsfAfterJReserveList.SetData(llngAfterJReserveListCnt, CMlngvsfAfterJReserveListReserveId, _
                                .strReserveID)                                             '予約ID
                            
                            vsfAfterJReserveList.SetData(llngAfterJReserveListCnt, CMlngvsfAfterJReserveListLotId, _
                                .strLotId)													'ロットID

                            '@登録日時が「0000/00/00 00:00:00」の場合
                            If .strEntryTime = CMstrDefYmdHms Then
                                vsfAfterJReserveList.SetData(llngAfterJReserveListCnt, CMlngvsfAfterJReserveListEntryTime, _
                                    CMstrDefY2mdHms)                                       '最終洗浄日時（「00/00/00 00:00:00」）
                            Else
                                If IsDate(.strEntryTime) = True Then
                                vsfAfterJReserveList.SetData(llngAfterJReserveListCnt, CMlngvsfAfterJReserveListEntryTime, _
                                    Format$(CDate(.strEntryTime), CPstrDateTimeY2MDHMS))   '最終洗浄日時

                                Else
                                	vsfAfterJReserveList.SetData(llngAfterJReserveListCnt, CMlngvsfAfterJReserveListEntryTime, .strEntryTime)
                                End If
                            End If
                   

							vsfAfterJReserveList.SetData(llngAfterJReserveListCnt, CMlngvsfAfterJReserveListEmpName, _
                                .strEmpName)                                   '登録者
                            
                            '@行の高さ設定
                            vsfAfterJReserveList.Rows(llngAfterJReserveListCnt).Height = CMlngvsfAfterJReserveListRowHeight
                            
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngAfterJReserveListCnt = llngAfterJReserveListCnt + 1
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
                            If .GetData(llngCnt, CMlngvsfAfterJReserveListReserveID) = mtypChgSort.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ,保持列)
                                Call pubVsfBeforeSort(vsfAfterJReserveList, CMlngvsfAfterJReserveListNo)
                                
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ,保持列,前頁,次頁)
                                Call pubVsfAfterSort(vsfAfterJReserveList, CMlngvsfAfterJReserveListNo)
                                
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        
                        '@ﾀｲﾄﾙ行を選択する
                        .Row = CMlngvsfAfterJReserveListTitleRow
                    End If
                End If
                '@描画ﾛｯｸ解除
                .Redraw = True
                
                '@情報取得日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                
                '@件数表示
                lblAfterJReserveCnt.Text = llngAfterJReserveListCnt - 1
                
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
                .strProcName = "prvfrmxxEN02U1_Disp"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub



    '関数名：prvblnAfterJReserveList_Sel
    '機　能：蒸着後流動予約一覧取得処理
    '引　数：なし
    '戻り値：True：成功/False：失敗
    '作成日：
    '更新日：
    '備　考：

    Private Function prvblnAfterJReserveList_Sel() As Boolean

        Dim lblnAns             As Boolean          '結果格納
       
        Try
            
            '@初期化
            prvblnAfterJReserveList_Sel = False

            '@一覧取得
            lblnAns = pubblnGetAfterJReserveList(CMstrlot_afterjrsvlistVer, mtypAfterJReserveList)
            
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
 
				'@Form_Loadﾌﾗｸﾞ（正常）
                pblnFormLoad = True

                '@描画処理
                If mblnFormLoadFlag = True Then
                '@初回起動時以外は描画を行う
                    '@取得OKなら結果表示
                    Call prvfrmxxEN02U1_Disp(mtypAfterJReserveList)
                End If
                
                prvblnAfterJReserveList_Sel = True
            End If
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnAfterJReserveList_Sel"         '処理名
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfAfterJReserveList.BeforeDoubleClick

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
