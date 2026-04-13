'ﾌｧｲﾙ名：xxEN02C1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：混成治具作成
'作成日：2009/05/20 (Wed) 16:54:34 T.Oide
'更新日：2009/05/20 (Wed) 16:54:34
'備　考：
'　　　：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02C1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02C1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02C1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02C1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02C1)
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
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN02C1          'ﾛｰｶﾙ機能ID

    '@vsfInvLotListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfInvLLColChk               As Integer = 0                      'ﾁｪｯｸ
    Private Const CMlngvsfInvLLColNo                As Integer = 1                      '№
    Private Const CMlngvsfInvLLColCFLotID           As Integer = 2                      'CFﾛｯﾄID
    Private Const CMlngvsfInvLLColPassedTime        As Integer = 3                      '経過時間
    Private Const CMlngvsfInvLLColBoardThickness    As Integer = 4                      '厚
    Private Const CMlngvsfInvLLColRegeneration      As Integer = 5                      'ﾘﾜｰｸ
    Private Const CMlngvsfInvLLColNum               As Integer = 6                      '在庫枚数
    Private Const CMlngvsfInvLLColEditTime          As Integer = 7                      '更新日時
    Private Const CMlngvsfInvLLColUseNum            As Integer = 8                      '使用枚数

    '@vsfInvLotListの定数宣言(幅)
    Private Const CMlngvsfInvLLWColChk              As Integer = 33                     'ﾁｪｯｸ
    Private Const CMlngvsfInvLLWColNo               As Integer = 33                     '№
    Private Const CMlngvsfInvLLWColCFLotID          As Integer = 97                     'CFロットID
    Private Const CMlngvsfInvLLWColPassedTime       As Integer = 122                    '制限時間
    Private Const CMlngvsfInvLLWColBoardThickness   As Integer = 31                     '厚
    Private Const CMlngvsfInvLLWColRegeneration     As Integer = 47                     'ﾘﾜｰｸ
    Private Const CMlngvsfInvLLWColNum              As Integer = 75                     '在庫枚数
    Private Const CMlngvsfInvLLWColEditTime         As Integer = 65                     '更新日時
    Private Const CMlngvsfInvLLWColUseNum           As Integer = 73                     '使用枚数

    '@vsfInvLotListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfInvLLColChk               As String = ""                      'ﾁｪｯｸ
    Private Const CMstrvsfInvLLColNo                As String = "№"                    '№
    Private Const CMstrvsfInvLLColCFLotID           As String = "CFロットID"            'CFロットID
    Private Const CMstrvsfInvLLColPassedTime        As String = "経過時間"              '経過時間
    Private Const CMstrvsfInvLLColBoardThickness    As String = "厚"                    '厚
    Private Const CMstrvsfInvLLColRegeneration      As String = "ﾘﾜｰｸ"                  'ﾘﾜｰｸ
    Private Const CMstrvsfInvLLColNum               As String = "在庫枚数"              '在庫枚数
    Private Const CMstrvsfInvLLColEditTime          As String = "更新日時"              '更新日時
    Private Const CMstrvsfInvLLColUseNum            As String = "使用枚数"              '使用枚数

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                  As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                  As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                 As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                   As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                    As Integer = 24                     '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfPartMaxRow                As Integer = 16                     '部材一覧最大行(ﾀｲﾄﾙ含む)

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols1                 As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbDispCols2                 As Integer = 2                      'ｸﾞﾘｯﾄﾞ表示列数=2
    Private Const CMlngCmbValueCol1                 As Integer = 1                      '値取得個数=1
    Private Const CMlngCmbValueCol2                 As Integer = 2                      '値取得個数=2
    Private Const CMlngCmbValueCol3                 As Integer = 3                      '値取得個数=3
    Private Const CMlngCmbRowHeight                 As Integer = 18                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                  As Integer = 0                      '名称列番=0
    Private Const CMlngCmbGridCol1                  As Integer = 1                      '名称列番=1
    Private Const CMlngCmbGroupCol                  As Integer = 2                      'ｸﾞﾙｰﾌﾟCol
    Private Const CMlngCmbGroupRow                  As Integer = 0                      'ｸﾞﾙｰﾌﾟRow
    Private Const CMlngCmbGetCol5                   As Integer = 5                      'ﾊﾞｯｸｶﾗｰ格納Col

    Private Const CMstrinv_mktocfpartlistVer        As String = "02.00"                 'MK用部材一覧取得

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '====================================Private============================================
    Private mstrCarrTypName                         As String                   '退避ｷｬﾘｱﾀｲﾌﾟ名
    Private mtypCarrierEmptyList                    As CarrList                 'ｷｬﾘｱﾘｽﾄ取得結果格納
    Private mtypChgSort                             As ChgSort                  'ｿｰﾄ保持用
    Private mblnFormLoadFlag                        As Boolean                  'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mlngpartlistcnt                         As Integer                  '部品格納数
    Private mstrUsePart                             As String                   '利用部材
    Private mstrTaihiPartID                         As String                   '部品ID
    Private buttonProcessing                        As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                  'NSYS WindowCloseフラグ
    Private lpreRow                                 As Integer                  'NSYS ソート前選択行
    Private lprePos                                 As Point                    'NSYS ソート前スクロール位置

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
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：2009/05/21 (Thu) 10:25:11 T.Oide
    '更新日：2015/12/10 (Thu) 13:10:11 Y.Tanaka
    '備　考：
    Private Sub Form_Load()
        
        Dim lstrFormName    As String           'ﾌｫｰﾑ
        Dim llngRow         As Integer          '行ｶｳﾝﾄ
        Dim lngCnt          As Integer
        Dim konseiListNum   As Integer
        
        '@行ｶｳﾝﾀの初期化
        llngRow = 0
        
        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            
         
            '@画面の初期化
            Call prvfrmxxEN02C1_Init()
            
            lblSlotNo.Text = ptypeCfInvInfo.strSlotNo
            txtJig.Text = ptypeCfInvInfo.strjigId
        '@↓2009/08/04 (Tue) 15:39:21 T.Oide **************************************************
            LabStuffCount.Text = Format$(ptypeCfInvInfo.lngStuffCount, CPstrDateFormatKanma)
        '@↑2009/08/04 (Tue) 15:39:21 T.Oide **************************************************
           
        '@↓2015/12/10 (Thu) 13:10:11 Y.Tanaka **************************************************
            '@部品一覧のｸﾘｱ
            Call prvvsfInvLotList_Init()
            
            '@部品ｺﾝﾎﾞﾘｽﾄ表示
            Call prvcmbPart_Disp()
            
            '@画面に在庫ﾛｯﾄのﾃﾞｰﾀを表示する
            'Call prvInvList_Disp
            
            '@混成済みのデータがある場合は表示する
            konseiListNum = Format(CInt(lblSlotNo.Text), "#") -1
            With vsfInvLotList
            
                .Redraw = False 

                'NSYS 初期値
                .Row = - 1

                For lngCnt = 0 To ptypKonsei(konseiListNum).lngKonseiListCnt -1

                    '@行ｶｳﾝﾀｶｳﾝﾄｱｯﾌﾟ
                    llngRow = llngRow + 1
                            
                    '@行数設定
                    .Rows.Count = llngRow + 1
                        
                    '@ｽﾛｯﾄの高さの設定
                    .Rows(llngRow).Height = CMlngVsfHeight
                    '@ｾﾙ色変更
                    '@ﾌｫﾝﾄ色変更
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)'灰色
                    newStyle.ForeColor = Color.Black                             '黒色
                    Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngVsfColTitle, llngRow, .Cols.Count - 1)
                    cellRange.Style = newStyle                                      
                
                
                    .SetData(llngRow, CMlngvsfInvLLColChk, True)
                
                    .SetData(llngRow, CMlngvsfInvLLColCFLotID, _
                        ptypKonsei(konseiListNum).typKonseiList(lngCnt).strLotID)                        'CFﾛｯﾄID
            
                    .SetData(llngRow, CMlngvsfInvLLColPassedTime, _
                        ptypKonsei(konseiListNum).typKonseiList(lngCnt).strLimitTime)                    '制限時間
                    .SetData(llngRow, CMlngvsfInvLLColBoardThickness, _
                        ptypKonsei(konseiListNum).typKonseiList(lngCnt).strBodyThickness)                '厚
                    
                    .SetData(llngRow, CMlngvsfInvLLColRegeneration, _
                        ptypKonsei(konseiListNum).typKonseiList(lngCnt).strReworkCount)                  'ﾘﾜｰｸ
                        
                    '@↓2009/08/04 (Tue) 15:21:38 T.Oide **************************************************
                    .SetData(llngRow, CMlngvsfInvLLColNum, _
                        Format$(CInt(ptypKonsei(konseiListNum).typKonseiList(lngCnt).strInvCount), CPstrDateFormatKanma)) '在庫枚数
                    '@↑2009/08/04 (Tue) 15:21:38 T.Oide **************************************************
                
                    .SetData(llngRow, CMlngvsfInvLLColUseNum, _
                        ptypKonsei(konseiListNum).typKonseiList(lngCnt).strChipCount)                            '使用枚数


                    .SetData(llngRow, CMlngvsfInvLLColEditTime, _
                        ptypKonsei(konseiListNum).typKonseiList(lngCnt).strLotLastUpdate)                        '更新日時

                Next

                RemoveHandler vsfInvLotList.EnterCell, AddressOf vsfInvLotList_EnterCell
                .Row = 0
                AddHandler vsfInvLotList.EnterCell, AddressOf vsfInvLotList_EnterCell

                .Redraw = True 

                vsfInvLotList.Enabled = True
            End With
        '@↑2015/12/10 (Thu) 13:10:11 Y.Tanaka **************************************************
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
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
    '機　能：Form_Activate処理
    '引　数：なし
    '戻り値：
    '作成日：2009/05/21 (Thu) 10:25:25 T.Oide
    '更新日：2009/05/21 (Thu) 10:25:25
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Try
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理判別
            If mblnFormLoadFlag = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
                
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
    '機　能：
    '引　数：KeyCode：
    '　　　：Shift：
    '戻り値：
    '作成日：2009/05/21 (Thu) 10:46:17 T.Oide
    '更新日：2009/05/21 (Thu) 10:46:17
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理判別
            Select Case ActiveControl.Name
                
                '@ｸﾞﾘｯﾄﾞの場合
                Case vsfInvLotList.Name
                    
                    '@ｸﾞﾘｯﾄﾞの列判定
                    Select Case vsfInvLotList.Col
                    
                        '@チェックの場合
                        Case CMlngvsfInvLLColChk
                            If e.KeyCode = Keys.Return OrElse e.KeyCode = Keys.Space Then
                                e.SuppressKeyPress = True
                            End If

                        '@使用枚数の場合
                        Case CMlngvsfInvLLColUseNum
                            
                            '@処理なし
                            
                        '@その他の場合
                        Case Else
                            e.Handled = True
                        
                    End Select
                    
                Case Else
                    'e.Handled = True
                
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
    '機　能：
    '引　数：Cancel：
    '　　　：UnloadMode：
    '戻り値：
    '作成日：2009/05/21 (Thu) 10:46:31 T.Oide
    '更新日：2009/05/21 (Thu) 10:46:31
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort.typChgSortList.Clear
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
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：2009/05/21 (Thu) 10:46:42 T.Oide
    '更新日：2009/05/21 (Thu) 10:46:42
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


    '関数名：vsfInvLotList_AfterEdit
    '機　能：使用数量を変更した場合に合計値を計算する
    '　　　：またﾁｪｯｸを外した場合は使用数量を0にして合計値を再計算する
    '引　数：Row：
    '　　　：Col：
    '戻り値：
    '作成日：2009/05/29 (Fri) 10:07:42 T.Oide
    '更新日：2009/08/21 (Fri) 16:58:46 T.Oide
    '備　考：
    '      :2009/08/21 (Fri) 16:59:03 T.Oide R6-5緊急対応
    Private Sub vsfInvLotList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfInvLotList.AfterEdit
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfInvLotList.Rows.Count <= vsfInvLotList.Rows.Fixed Then
                Return
            End If
            
            Dim lngCnt          As Integer  'カウンター
            Dim lngSum          As Integer  '使用ﾁｯﾌﾟの合計値
            Dim llngUseNum      As Integer
            
            
            'ﾁｪｯｸのONなら使用数量を編集
            With vsfInvLotList
                If .Col = CMlngvsfInvLLColChk Then
                    If .GetData(e.Row, .Col) = True Then
                    
                        '詰数を自動ｾｯﾄ(ﾛｯﾄの在庫数が詰数以上ある場合は詰数をｾｯﾄ
                        '在庫数量が少ない場合は、あるだけｾｯﾄ
                        If CLng(.GetData(e.Row, CMlngvsfInvLLColNum)) >= CLng(LabStuffCount.Text) Then
                            '在庫数が十分ある場合は必要数(詰数になるだけ)をｾｯﾄ
                            .SetData(e.Row, CMlngvsfInvLLColUseNum, CLng(LabStuffCount.Text) - CLng(lblThrowNum.Text))
                        Else
                            '在庫数が少ない場合あるだけｾｯﾄ
                            .SetData(e.Row, CMlngvsfInvLLColUseNum, .GetData(e.Row, CMlngvsfInvLLColNum))
                        End If
                    Else
                        'ﾁｪｯｸOFFなら使用数量を0に変更
                        vsfInvLotList.SetData(e.Row, CMlngvsfInvLLColUseNum, vbNullString)
                    
                    End If
                End If
                
                '@数値以外の場合は空にする
                If Not IsNumeric(.GetData(e.Row, CMlngvsfInvLLColUseNum)) Then
                    .SetData(e.Row, CMlngvsfInvLLColUseNum, vbNullString)
                End If
                
        '@↓2009/08/04 (Tue) 17:24:28 T.Oide **************************************************
                '@10桁以上の場合は10桁で切る
                If Len(vsfInvLotList.GetData(vsfInvLotList.Row, CMlngvsfInvLLColUseNum)) >= 10 Then
                    '@10桁で切る
                    llngUseNum = Mid$(vsfInvLotList.GetData(vsfInvLotList.Row, CMlngvsfInvLLColUseNum), 1, 9)
                    vsfInvLotList.SetData(vsfInvLotList.Row, CMlngvsfInvLLColUseNum, llngUseNum)

                End If
        '@↑2009/08/04 (Tue) 17:24:28 T.Oide **************************************************
                
            End With
            
            
            '数量の変更なら合計値を計算
            For lngCnt = 1 To vsfInvLotList.Rows.Count - 1
                
                If Not IsNothing(vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColUseNum))  Then
                    lngSum = lngSum + vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColUseNum)
                End If
            
            Next
            
        '@↓2009/08/04 (Tue) 15:36:59 T.Oide **************************************************
            '合計値を表示
            lblThrowNum.Text = Format$(lngSum, CPstrDateFormatKanma)
        '@↑2009/08/04 (Tue) 15:36:59 T.Oide **************************************************
            
            '合計ｵｰﾊﾞならエラー
            If CLng(LabStuffCount.Text) < CLng(lblThrowNum.Text) Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0078, LabStuffCount.Text)
                '@エラーメッセージを表示
        '@↓2009/08/21 (Fri) 16:58:26 T.Oide **************************************************
                'Call publngMsgBox(pstrDMsg, vbExclamation, frmxxEN02C1.Name, True, 16)
                Call publngMsgBox(pstrDMsg, vbExclamation, Me.Text, True, 16)
        '@↑2009/08/21 (Fri) 16:58:26 T.Oide **************************************************
                '確定の有効/無効ﾁｪｯｸ
                Call prvcmdChoice_Chk()
                
                Exit Sub
            End If
            
            '使用数量に値が入っている場合ﾁｪｯｸ
            If Not IsNothing(vsfInvLotList.GetData(e.Row, CMlngvsfInvLLColUseNum)) Then
            
                
                '使用数量＞在庫数量ならエラー
                If CLng(vsfInvLotList.GetData(e.Row, CMlngvsfInvLLColUseNum)) > CLng(vsfInvLotList.GetData(e.Row, CMlngvsfInvLLColNum)) Then
                    '@表示ﾒｯｾｰｼﾞ変換
        '@↓2009/08/21 (Fri) 17:02:05 T.Oide **************************************************
                    'pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0078, LabStuffCount.Caption)
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0073)
                    '@エラーメッセージを表示
                    'Call publngMsgBox("在庫以上の数量を設定できません。", vbExclamation, frmxxEN02C1.Name, True, 16)
                    Call publngMsgBox(pstrDMsg, vbExclamation, Me.Text, True, 16)
        '@↑2009/08/21 (Fri) 17:02:05 T.Oide **************************************************
                    vsfInvLotList.SetData(e.Row, CMlngvsfInvLLColUseNum, vbNullString)
                    Exit Sub
                
                End If
            End If
            '確定ﾎﾞﾀﾝの有効/無効ﾁｪｯｸ
            Call prvcmdChoice_Chk()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                   '機能ID
                .strProcName = "vsfInvLotList_AfterEdit"          '処理名
                .strErrMessage = vbNullString                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
            
        End Try
    End Sub

    '関数名：vsfInvLotList_EnterCell
    '機　能：選択された列がﾁｪｯｸか使用数の場合だけｸﾞﾘｯﾄﾞを編集可能とする
    '引　数：なし
    '戻り値：
    '作成日：2009/05/29 (Fri) 10:00:53 T.Oide
    '更新日：2009/05/29 (Fri) 10:00:53
    '備　考：
    Private Sub vsfInvLotList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfInvLotList.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfInvLotList.Rows.Count <= vsfInvLotList.Rows.Fixed Then
                Return
            End If

            With vsfInvLotList
                'ﾁｪｯｸをｸﾘｯｸされたらｸﾞﾘｯﾄﾞを変更可能にする
                If .Col = CMlngvsfInvLLColChk Then
                    '@変更可能を設定
                    .AllowEditing = True
                    .Styles.Editor.BackColor = SystemColors.Window
                    .Styles.Editor.ForeColor = SystemColors.WindowText
                Else
                    '@変更不可を設定
                    .AllowEditing = False
                End If

                'ﾁｪｯｸがONで使用数量をｸﾘｯｸされたら入力を可能にする
                If .Col = CMlngvsfInvLLColUseNum And _
                   .GetData(.Row, CMlngvsfInvLLColChk) = True Then
                    '@変更可能を設定
                    .AllowEditing = True
                    .Styles.Editor.BackColor = SystemColors.Window
                    .Styles.Editor.ForeColor = SystemColors.WindowText
                Else
                    '@変更不可を設定
                    '.Editable = flexEDNone
                End If
                
                
            End With

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                      '機能ID
                .strProcName = "vsfInvLotList_EnterCell"             '処理名
                .strErrMessage = vbNullString                        'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
                
        End Try
    End Sub

    '関数名：cmdChoice_Click
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：2009/06/01 (Mon) 10:38:35 T.Oide
    '更新日：2009/06/01 (Mon) 10:38:35
    '備　考：
    Private Sub cmdChoice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChoice.Click

        Dim lngCnt          As Integer
        Dim lngCnt2         As Integer
        Dim lngCnt3         As Integer
        Dim strLastTime     As String

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            If prvFuncRework_Chk = False Then
                Exit Sub
            End If
            
            lngCnt3 = 1
                
            With ptypKonsei(Format(CInt(lblSlotNo.Text), "#") -1)
                '構造体にﾃﾞｰﾀを格納する
                .strSlotNo = lblSlotNo.Text
                .strjigId = txtJig.Text

                If .typKonseiList Is Nothing Then
                    .typKonseiList = New List(Of KonseiList)
                Else
                    .typKonseiList.Clear
                End If
                Dim typKonseiListTmp As New KonseiList

                'ﾁｪｯｸの入った行で数量が0以上の設定だけ格納
                For lngCnt = 1 To vsfInvLotList.Rows.Count - 1
                    If vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColChk) = True And _
                       vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColUseNum) > 0 Then
                       
                        typKonseiListTmp.strLotID = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColCFLotID)                  'ﾛｯﾄID
                        typKonseiListTmp.strBodyThickness = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColBoardThickness)   '厚
                        typKonseiListTmp.strReworkCount = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColRegeneration)       'ﾘﾜｰｸ数
                        typKonseiListTmp.strLimitTime = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColPassedTime)           '制限時間
                        typKonseiListTmp.strInvCount = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColNum)                   '在庫枚数
                        typKonseiListTmp.strChipCount = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColUseNum)               '使用枚数
                        typKonseiListTmp.strLotLastUpdate = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColEditTime)         '最終更新日時
                        .lngKonseiListCnt = lngCnt3

                        .typKonseiList.Add(typKonseiListTmp)
                        lngCnt3 = lngCnt3 + 1
                    End If
                Next
            
            End With
            
            '親画面を更新する(ｼﾞｸﾞID、CFﾛｯﾄID,ﾘﾜｰｸ回数)
            With frmxxEN02C0.Instance
                
                .txtJigID(plngvsfJigListRow - 1).Text = ptypKonsei(Format(CInt(lblSlotNo.Text), "#") -1).strjigId
                
        '@↓2009/08/05 (Wed) 15:25:10 T.Oide **************************************************
                '@部材が複数の場合はKONSEIを親画面に表示する
                If ptypKonsei(Format(CInt(lblSlotNo.Text), "#") -1).typKonseiList.Count > 1 Then
                
                    '@複数部材の場合
                    .vsfJigList.SetData(plngvsfJigListRow, 1, CPstrKonsei)
                    'ﾘｽﾄ中最も古いものを設定
                    For lngCnt2 = 0 To ptypKonsei(Format(CInt(lblSlotNo.Text), "#") -1).typKonseiList.Count -1
                        If ptypKonsei(Format(CInt(lblSlotNo.Text), "#") -1).typKonseiList(lngCnt2).strLimitTime < strLastTime Or _
                           strLastTime = vbNullString Then
                            strLastTime = ptypKonsei(Format(CInt(lblSlotNo.Text), "#") -1).typKonseiList(lngCnt2).strLimitTime
                        End If
                    
                    Next
                Else
                    
                    '@単一部材の場合
                    .vsfJigList.SetData(plngvsfJigListRow, 1, ptypKonsei(Format(CInt(lblSlotNo.Text), "#") -1).typKonseiList(0).strLotID)
                    strLastTime = ptypKonsei(Format(CInt(lblSlotNo.Text), "#") -1).typKonseiList(0).strLimitTime
                    
                End If
        '@↑2009/08/05 (Wed) 15:25:10 T.Oide **************************************************

                .vsfJigList.SetData(plngvsfJigListRow, 2, strLastTime)
                .vsfJigList.SetData(plngvsfJigListRow, 4, ptypKonsei(Format(CInt(lblSlotNo.Text), "#") -1).typKonseiList(0).strReworkCount)
                
            End With
            
            '画面を閉じる
            Me.Close()
            
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                      '機能ID
                .strProcName = "cmdChoice_Click"                     '処理名
                .strErrMessage = vbNullString                        'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvfrmxxEN02C1_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/21 (Thu) 10:12:23 T.Oide
    '更新日：2009/05/21 (Thu) 10:12:23
    '備　考：
    Private Sub prvfrmxxEN02C1_Init()
        
        Try
            
            
            '@閉じるﾎﾞﾀﾝはValidate無効
            cmdClose.CausesValidation = False
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfInvLotList_Init()
            
            '@選択確定ﾎﾞﾀﾝ使用不可
            cmdChoice.Enabled = False
            
            
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

    '関数名：prvvsfInvLotList_Init
    '機　能：利用部材一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：2009/05/21 (Thu) 10:46:58 T.Oide
    '備　考：
    Private Sub prvvsfInvLotList_Init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfInvLotList

                .Redraw = False

                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                '文字色
                lFixedStyle.BackColor = Color.Navy                  '背景色
                With .Font                                          'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngVsfHFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With

                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfInvLLColChk).Width = CMlngvsfInvLLWColChk
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColChk, CMstrvsfInvLLColChk)                         'ﾁｪｯｸ
                
                .Cols(CMlngvsfInvLLColNo).Width = CMlngvsfInvLLWColNo
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColNo, CMstrvsfInvLLColNo)                            '№

                .Cols(CMlngvsfInvLLColCFLotID).Width = CMlngvsfInvLLWColCFLotID
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColCFLotID, CMstrvsfInvLLColCFLotID)                  'CFﾛｯﾄID

                .Cols(CMlngvsfInvLLColPassedTime).Width = CMlngvsfInvLLWColPassedTime
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColPassedTime, CMstrvsfInvLLColPassedTime)            '経過時間

                .Cols(CMlngvsfInvLLColBoardThickness).Width = CMlngvsfInvLLWColBoardThickness
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColBoardThickness, CMstrvsfInvLLColBoardThickness)    '厚
                
                .Cols(CMlngvsfInvLLColRegeneration).Width = CMlngvsfInvLLWColRegeneration
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColRegeneration, CMstrvsfInvLLColRegeneration)        'ﾘﾜｰｸ

                .Cols(CMlngvsfInvLLColNum).Width = CMlngvsfInvLLWColNum
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColNum, CMstrvsfInvLLColNum)                          '在庫枚数

                .Cols(CMlngvsfInvLLColEditTime).Width = CMlngvsfInvLLWColEditTime
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColEditTime, CMstrvsfInvLLColEditTime)                '更新日時

                .Cols(CMlngvsfInvLLColUseNum).Width = CMlngvsfInvLLWColUseNum
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColUseNum, CMstrvsfInvLLColUseNum)                    '使用枚数
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    '高さ
                
                '@更新日時を非表示にする
                .Cols(CMlngvsfInvLLColEditTime).Visible = False
                
                .Redraw = True

                '@ﾛｯｸ
                '.Enabled = False
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Heavy
                
                'ｽﾛｯﾄ数は5なので要素数は5で固定
                ReDim Preserve ptypKonsei(4)

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfInvLotList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvInvList_Disp
    '機　能：llngPartLotListにｾｯﾄされているﾃﾞｰﾀを画面に表示する
    '引　数：なし
    '戻り値：
    '作成日：2009/05/28 (Thu) 20:16:34 T.Oide
    '更新日：2015/12/10 (Thu) 15:39:30 Y.Tanaka
    '備　考：
    Private Sub prvInvList_Disp(ByRef ltypPartLotList As List(Of PartLotList), _
                                ByVal partLotListCount As Integer, _
                                ByRef ltypUsePartList As List(Of KonseiList), _
                                ByVal llngUsePartListCnt As Integer)

        Dim lngCnt          As Integer
        Dim lngCnt3         As Integer
        Dim lngCnt4         As Integer
        Dim lngSum          As Integer
        Dim llngRow         As Integer              '行ｶｳﾝﾄ
        Dim llngNo          As Integer               'No
        Dim lblnLotNo       As Boolean
        Try
            
            'ｸﾞﾘｯﾄﾞの行数設定
            'vsfInvLotList.Rows = ptypeCfInvInfo.lngListCnt
            'vsfInvLotList.Rows = partLotListCount
            '@行ｶｳﾝﾀの初期化
            llngRow = 0
            llngNo = 0
            lblnLotNo = False
            
            '@↓2015/12/15 (Tue) 09:53:38 Y.Tanaka **************************************************
            
            '@一覧表示
            'For lngCnt = 1 To ptypeCfInvInfo.lngListCnt - 1
            
            With vsfInvLotList
               
                .Redraw = False  

                'NSYS 初期値
                .Row =  - 1

                '選択済みﾃﾞｰﾀ表示
                 For lngCnt = 0 To llngUsePartListCnt -1

                    '@行ｶｳﾝﾀｶｳﾝﾄｱｯﾌﾟ
                    llngRow = llngRow + 1
                            
                    '@行数設定
                    .Rows.Count = llngRow + 1
                        
                    '@ｽﾛｯﾄの高さの設定
                    .Rows(llngRow).Height = CMlngVsfHeight
                    '@ｾﾙ色変更
                    '@ﾌｫﾝﾄ色変更   
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)                                '灰色
                    newStyle.ForeColor = Color.Black                                                             '黒色
                    Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngVsfColTitle, llngRow, .Cols.Count - 1)
                    cellRange.Style = newStyle       
                    
                    .SetData(llngRow, CMlngvsfInvLLColChk, True)                                                 'ﾁｪｯｸ
                
                    .SetData(llngRow, CMlngvsfInvLLColCFLotID, _
                        ltypUsePartList(lngCnt).strLotID)                                                        'CFﾛｯﾄID
            
                    .SetData(llngRow, CMlngvsfInvLLColPassedTime, _
                        ltypUsePartList(lngCnt).strLimitTime)                                                    '制限時間
                    .SetData(llngRow, CMlngvsfInvLLColBoardThickness, _
                        ltypUsePartList(lngCnt).strBodyThickness)                                                '厚
                    
                    .SetData(llngRow, CMlngvsfInvLLColRegeneration, _
                        ltypUsePartList(lngCnt).strReworkCount)                                                  'ﾘﾜｰｸ
                        
                    .SetData(llngRow, CMlngvsfInvLLColNum, _
                        Format$(CInt(ltypUsePartList(lngCnt).strInvCount), CPstrDateFormatKanma))                '在庫枚数
                
                    .SetData(llngRow, CMlngvsfInvLLColUseNum, _
                        ltypUsePartList(lngCnt).strChipCount)                                                    '使用枚数


                    .SetData(llngRow, CMlngvsfInvLLColEditTime, _
                        ltypUsePartList(lngCnt).strLotLastUpdate)                                                '更新日時

                Next
            '@↑2015/12/15 (Tue) 09:53:38 Y.Tanaka **************************************************
            
                For lngCnt = 0 To partLotListCount -1
                
                    '時間制限を超えていないもののみ表示
                    If ltypPartLotList(lngCnt).strLimitTime > Format(Now, "yyyy/MM/dd HH:mm:ss") Then
                        If ltypPartLotList(lngCnt).strCurrentStatus <> CPstrClass4J Then
                    
                            '表示済みﾁｪｯｸ
                            For lngCnt3 = 1 To vsfInvLotList.Rows.Count - 1
                                If .GetData(lngCnt3, CMlngvsfInvLLColCFLotID) = ltypPartLotList(lngCnt).strLotID Then
                                     lblnLotNo = True
                                End If
                                If lblnLotNo = True Then Exit For
                            Next
                        
                            If lblnLotNo <> True Then
                        
                                '@行ｶｳﾝﾀｶｳﾝﾄｱｯﾌﾟ
                                llngRow = llngRow + 1
                            
                                'No
                                llngNo = llngNo + 1
                            
                                '@行数設定
                                .Rows.Count = llngRow + 1
                        
                                 '@ｽﾛｯﾄの高さの設定
                                .Rows(llngRow).Height = CMlngVsfHeight
                                '@ﾌｫﾝﾄ色変更
                                '@ｾﾙ色変更
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                                newStyle.BackColor = Color.White    '白色
                                newStyle.ForeColor = Color.Black    '黒色
                                Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngVsfColTitle, llngRow, .Cols.Count - 2)
                                cellRange.Style = newStyle     
                         
                        
                                .SetData(llngRow, CMlngvsfInvLLColNo, llngNo)                            '№
            
                                .SetData(llngRow, CMlngvsfInvLLColCFLotID, _
                                    ltypPartLotList(lngCnt).strLotID)                                                          'CFﾛｯﾄID
            
                                .SetData(llngRow, CMlngvsfInvLLColPassedTime, _
                                    Mid$(ltypPartLotList(lngCnt).strLimitTime, 3, 14))                                         '制限時間
                                .SetData(llngRow, CMlngvsfInvLLColBoardThickness, _
                                    ltypPartLotList(lngCnt).strThicknessCode)                                                  '厚
                    
                                .SetData(llngRow, CMlngvsfInvLLColRegeneration, _
                                    ltypPartLotList(lngCnt).strReworkCount)                                                    'ﾘﾜｰｸ
                        
                '@↓2009/08/04 (Tue) 15:21:38 T.Oide **************************************************
                                .SetData(llngRow, CMlngvsfInvLLColNum, _
                                    Format$(CInt(ltypPartLotList(lngCnt).strNum), CPstrDateFormatKanma))                       '在庫枚数
                '@↑2009/08/04 (Tue) 15:21:38 T.Oide **************************************************
                
                                .SetData(llngRow, CMlngvsfInvLLColEditTime, _
                                    ltypPartLotList(lngCnt).strLotLastUpdate)                                                  '更新日時
                    
                                '時間制限を越えている場合はﾊﾞｯｸｶﾗｰを赤に変更して使えないことをあらわす
                                'If ptypeCfInvInfo.typeCfInvList(lngCnt).strLimitTime < Format(Now, "YY/MM/DD HH:MM:SS") Then
                                '  .Cell(flexcpBackColor, lngCnt, CMlngvsfInvLLColChk, lngCnt, CMlngvsfInvLLColUseNum) = vbRed
                                'End If
                            End If
                        End If
                    End If
                Next

                RemoveHandler vsfInvLotList.EnterCell, AddressOf vsfInvLotList_EnterCell
                .Row = 0
                AddHandler vsfInvLotList.EnterCell, AddressOf vsfInvLotList_EnterCell

                .Redraw = True 

            End With
            
              '@↓2015/12/15 (Tue) 09:53:38 Y.Tanaka **************************************************
        '@    '既に入力済みのﾃﾞｰﾀがある場合は再現する
        '@    If ptypKonsei(5 - plngvsfJigListRow + 1).lngKonseiListCnt > 0 Then
        '@        lngCnt2 = 1
        '@        'ｸﾞﾘｯﾄﾞの一致するﾛｯﾄを探す
        '@        Do While vsfInvLotList.Rows > lngCnt2
        '@            lngCnt3 = 1
        '@            Do While UBound(ptypKonsei(5 - plngvsfJigListRow + 1).typKonseiList) >= lngCnt3
        '@                With ptypKonsei(5 - plngvsfJigListRow + 1).typKonseiList(lngCnt3)
        '@                    '同じCFﾛｯﾄIDを探す
        '@                    If vsfInvLotList.Cell(flexcpText, lngCnt2, CMlngvsfInvLLColCFLotID) = _
        '@                        ptypKonsei(5 - plngvsfJigListRow + 1).typKonseiList(lngCnt3).strLotId Then
        '@                        '使用数をｾｯﾄ
        '@                        vsfInvLotList.Cell(flexcpText, lngCnt2, CMlngvsfInvLLColChk) = True
        '@                        vsfInvLotList.Cell(flexcpText, lngCnt2, CMlngvsfInvLLColUseNum) = _
        '@                            ptypKonsei(5 - plngvsfJigListRow + 1).typKonseiList(lngCnt3).strChipCount
        '@
        '@                        Exit Do
        '@
        '@                    End If
        '@                    lngCnt3 = lngCnt3 + 1
        '@                End With
        '@            Loop
        '@            lngCnt2 = lngCnt2 + 1
        '@        Loop
        '@    End If
            '@↑2015/12/15 (Tue) 09:53:38 Y.Tanaka **************************************************
            
            '合計値を設定する
            For lngCnt4 = 1 To vsfInvLotList.Rows.Count - 1
                
                If Not IsNothing(vsfInvLotList.GetData(lngCnt4, CMlngvsfInvLLColUseNum)) Then
                    lngSum = lngSum + vsfInvLotList.GetData(lngCnt4, CMlngvsfInvLLColUseNum)
                End If
            
            Next
            
            '合計値を表示
            lblThrowNum.Text = lngSum
            
            
            vsfInvLotList.Enabled = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvInvList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：prvcmdChoice_Chk
    '機　能：確定ﾎﾞﾀﾝの有効/無効ﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2009/05/29 (Fri) 12:11:59 T.Oide
    '更新日：2009/05/29 (Fri) 12:11:59
    '備　考：
    Private Sub prvcmdChoice_Chk()

        
        Try
            
             cmdChoice.Enabled = False
            
            '@詰数と合計値が同じなら確定ﾎﾞﾀﾝを有効にする
            If LabStuffCount.Text = lblThrowNum.Text Then
                cmdChoice.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdChoice_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFuncRework_Chk
    '機　能：同じﾘﾜｰｸ回数であるかﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2009/06/03 (Wed) 16:40:06 T.Oide
    '更新日：2009/06/03 (Wed) 16:40:06
    '備　考：
    Private Function prvFuncRework_Chk()

        Dim llngCnt             As Integer
        Dim llngCnt2            As Integer
        Dim lstrRegeneration    As String


        Try

            prvFuncRework_Chk = False


            '@枚数のﾁｪｯｸ
            With vsfInvLotList
                For llngCnt = 1 To .Rows.Count - 1
                    '@ﾃﾞｰﾀがある初めの行をﾁｪｯｸ
                    If Not IsNothing(.GetData(llngCnt, CMlngvsfInvLLColUseNum)) Then
                        '@ﾃﾞｰﾀがある初めの行の在庫枚数を退避
                        lstrRegeneration = .GetData(llngCnt, CMlngvsfInvLLColRegeneration)
                        Exit For
                    End If
                Next llngCnt
                
                '@枚数のﾁｪｯｸ
                For llngCnt2 = llngCnt To .Rows.Count - 1
                    '@ﾘﾜｰｸ回数が異なる部材を混載下場合ｴﾗｰﾒｯｾｰｼﾞを表示する
                    If Not IsNothing(.GetData(llngCnt2, CMlngvsfInvLLColUseNum)) Then
                        If .GetData(llngCnt2, CMlngvsfInvLLColRegeneration) <> vbNullString And _
                            .GetData(llngCnt2, CMlngvsfInvLLColRegeneration) <> lstrRegeneration Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000V)
                            '@"リワーク回数が異なる対向基板を混載する事はできません｡。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@ﾌｫｰｶｽの移動
                            Call pubSetFocus(vsfInvLotList)
                            .Row = 1
                            Exit Function
                        End If
                    End If
                Next llngCnt2
            End With

            prvFuncRework_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFuncRework_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '@↓2009/08/05 (Wed) 14:07:26 T.Oide **************************************************
    '関数名：vsfInvLotList_KeyPressEdit
    '機　能：
    '引　数：Row：
    '　　　：Col：
    '　　　：KeyAscii：
    '戻り値：
    '作成日：2009/08/05 (Wed) 14:07:20 T.Oide
    '更新日：2009/08/05 (Wed) 14:07:20
    '備　考：
    Private Sub vsfInvLotList_KeyPressEdit(ByVal sender As Object, ByVal e As KeyPressEditEventArgs) Handles vsfInvLotList.KeyPressEdit

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfInvLotList.Rows.Count <= vsfInvLotList.Rows.Fixed Then
                Return
            End If

            With vsfInvLotList
                
                '@使用枚数列か
                If .Col = CMlngvsfInvLLColUseNum Then
                        
                    '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
                    Select Case Asc(e.KeyChar)
                        
                        '@〓 半角英数字、ﾊﾞｯｸｽﾍﾟｰｽ、Enterｷｰ 〓
                        Case CPlngKeyAsciiNum0 To CPlngKeyAsciiNum9, _
                                CPlngKeyAsciiUppA To CPlngKeyAsciiUppZ, _
                                CPlngKeyBackSpace, CPlngKeyReturn

                            '@処理なし
         
                        '@〓 その他 〓
                        Case Else

                            '@ｷｰ無効
                            e.Handled = True

                    End Select
                End If
            End With

            '@[']の入力禁止
            If Asc(e.KeyChar) = CPlngKeyAscSingleQ Then
                e.Handled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfInvLotList_KeyPressEdit" 'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2009/08/05 (Wed) 14:07:26 T.Oide **************************************************

    '関数名：prvcmbPart_Disp
    '機　能：部材Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2015/11/06 (Tue) 17:40:33 Y.Tanaka
    '更新日：
    '備　考：
    Private Sub prvcmbPart_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbPart
                '@部品ｺﾝﾎﾞ初期化
                .Clear
                .Height = CMlngCmbRowHeight                                         '高さ
                .DispCols = CMlngCmbDispCols2                                       '表示列
                .ValueCol = CMlngCmbValueCol3                                       '値列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter          '左寄中央揃え
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter          '左寄中央揃え
                .GroupCols = CMlngCmbGroupCol                                       '表示Col数
                .GroupRows = CMlngCmbGroupRow                                       '表示Row数
                .DirectInput = False                                                '直接入力不可
                
                '@部材情報ｾｯﾄ
                For llngCnt = 0 To ptypeKonseiPartList.lngPartListSize -1
                    .AddItem(ptypeKonseiPartList.typePartList(llngCnt).strPartCode & _
                             vbTab & _
                             ptypeKonseiPartList.typePartList(llngCnt).strPartName & _
                             vbTab & _
                             ptypeKonseiPartList.typePartList(llngCnt).strPartCode & _
                             CPstrComboBrank & ptypeKonseiPartList.typePartList(llngCnt).strPartName & _
                             vbTab & _
                             llngCnt)                                               'ID&名称&ID+名称&Index
                Next llngCnt
                .GetCol = CMlngCmbDispCols2                                         '取得列
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPart_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPart_Change
    '機　能：部品ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2015/11/06 (Tue) 17:40:33 Y.Tanaka
    '更新日：
    '備　考：
    Private Sub cmbPart_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPart.Change

        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypPartLotList         As List(Of PartLotList) '部材一覧取得情報格納
        Dim llngPartLotListCnt      As Integer              '部材一覧取得件数格納
        Dim ltypUsePartList         As List(Of KonseiList)  '部品ｺｰﾄﾞ選択時ﾁｪｯｸ付CFﾛｯﾄ格納
        Dim llngUsePartListCnt      As Integer              'ﾁｪｯｸ付CFﾛｯﾄ取得件数格納
        Dim lngCnt                  As Integer
        Dim lngCnt2                 As Integer
        Dim blnChk                  As Boolean

        Try

            blnChk = False
            lngCnt2 = 1
            
            'ｸﾞﾘｯﾄﾞのﾁｪｯｸ付行確認
            If vsfInvLotList.Rows.Count - 1 > 0 Then
                For lngCnt = 1 To vsfInvLotList.Rows.Count - 1
                    If vsfInvLotList.GetData(lngCnt2, CMlngvsfInvLLColChk) = True Then
                        blnChk = True
                        Exit For
                    Else
                    lngCnt2 = lngCnt2 + 1
                    End If
                Next
            End If
                
            'グリッドの値取得　チェックあり・使用枚数0以上
            If blnChk = True Then
            
                If ltypUsePartList Is Nothing Then
                    ltypUsePartList = New List(Of KonseiList)
                Else
                    ltypUsePartList.Clear
                End If
                Dim ltypUsePartListTmp As New KonseiList

                'ﾁｪｯｸの入った行で数量が0以上の設定だけ格納
                lngCnt2 = 1
                For lngCnt = 1 To vsfInvLotList.Rows.Count - 1
                    If vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColChk) = True Then
                        
                        ltypUsePartListTmp.strLotID = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColCFLotID)                  'ﾛｯﾄID
                        ltypUsePartListTmp.strBodyThickness = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColBoardThickness)   '厚
                        ltypUsePartListTmp.strReworkCount = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColRegeneration)       'ﾘﾜｰｸ数
                        ltypUsePartListTmp.strLimitTime = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColPassedTime)           '制限時間
                        ltypUsePartListTmp.strInvCount = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColNum)                   '在庫枚数
                        ltypUsePartListTmp.strChipCount = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColUseNum)               '使用枚数
                        ltypUsePartListTmp.strLotLastUpdate = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColEditTime)         '最終更新日時
                        llngUsePartListCnt = lngCnt2

                        ltypUsePartList.Add(ltypUsePartListTmp)
                        lngCnt2 = lngCnt2 + 1
                    End If
                Next

            End If
                
            '@部品一覧のｸﾘｱ
            Call prvvsfInvLotList_Init()
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
                
            '@退避領域へ部品IDを格納
            cmbPart.ValueCol = 0
            mstrTaihiPartID = cmbPart.Value
                
            '@部材一覧情報の取得
            lblnAns = pubblnInvMKToCFPartList_Sel(CMstrinv_mktocfpartlistVer, _
                                                  ptypeKonseiPartList.strPdId, _
                                                  mstrTaihiPartID, _
                                                  ptypeKonseiPartList.strBodyThickness, _
                                                  ptypeKonseiPartList.strReworkCount, _
                                                  ltypPartLotList, _
                                                  llngPartLotListCnt)
            '@結果判定
            If lblnAns = True = True Then
                '@取得結果を一覧表示
                Call prvInvList_Disp(ltypPartLotList, llngPartLotListCnt, ltypUsePartList, llngUsePartListCnt)
            Else
                '@部品Comboへｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbPart)
                
                Exit Sub
            End If
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPart_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPart_CloseUp
    '機　能：部品のCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:38:35 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbPart_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPart.CloseUp

        Try

            '@空欄以外の場合
            If cmbPart.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbPart.Validating,AddressOf cmbPart_Validate
                Call cmbPart_Validate(cmbPart,New CancelEventArgs(False))
                AddHandler cmbPart.Validating,AddressOf cmbPart_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPart_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPart_Validate
    '機　能：部品のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:39:01 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbPart_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPart.Validating

        Dim llngIndex                   As Integer      'ComboのIndex

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@前回と同じ場合は処理しない
            If cmbPart.Text = mstrUsePart Then
                Exit Sub
            End If
            
            '@次回比較用に部材を格納
            mstrUsePart = cmbPart.Text
            
            '@選択されたIndexを取得
            llngIndex = cmbPart.ListIndex + 1
            
            '@処理分岐
            If cmbPart.Text <> vbNullString Then
                
                '@退避領域へ部品IDを格納
                cmbPart.ValueCol = 0
                mstrTaihiPartID = cmbPart.Value
                    
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPart_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfInvLotList_Get
    '機　能：利用部材一覧の取得
    '引　数：なし
    '戻り値：なし
    '作成日：2015/12/04 (Fri) 10:14:05 Y.Tanaka
    '更新日：2015/12/04 (Fri) 10:14:05 Y.Tanaka
    '備　考：
    Private Function prvvsfInvLotList_Get(ByRef ltypUsePartList As List(Of KonseiList), _
                                    ByVal llngUsePartListCnt As Integer) As Boolean

        Try

            Dim lngCnt          As Integer
            Dim lngCnt2         As Integer
            
            prvvsfInvLotList_Get = False
            lngCnt2 = 1

            If ltypUsePartList Is Nothing Then
                ltypUsePartList = New List(Of KonseiList)
            Else
                ltypUsePartList.Clear
            End If
            Dim ltypUsePartListTmp As New KonseiList

            'ﾁｪｯｸの入った行で数量が0以上の設定だけ格納

            For lngCnt = 1 To vsfInvLotList.Rows.Count - 1
                If vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColChk) = True Then
                    
                    ltypUsePartListTmp.strLotID = vsfInvLotList.GetData(lngCnt2, CMlngvsfInvLLColCFLotID)                  'ﾛｯﾄID
                    ltypUsePartListTmp.strBodyThickness = vsfInvLotList.GetData(lngCnt2, CMlngvsfInvLLColBoardThickness)   '厚
                    ltypUsePartListTmp.strReworkCount = vsfInvLotList.GetData(lngCnt2, CMlngvsfInvLLColRegeneration)       'ﾘﾜｰｸ数
                    ltypUsePartListTmp.strLimitTime = vsfInvLotList.GetData(lngCnt2, CMlngvsfInvLLColPassedTime)           '制限時間
                    ltypUsePartListTmp.strInvCount = vsfInvLotList.GetData(lngCnt2, CMlngvsfInvLLColNum)                   '在庫枚数
                    ltypUsePartListTmp.strChipCount = vsfInvLotList.GetData(lngCnt2, CMlngvsfInvLLColUseNum)               '使用枚数
                    ltypUsePartListTmp.strLotLastUpdate = vsfInvLotList.GetData(lngCnt2, CMlngvsfInvLLColEditTime)         '最終更新日時
                    llngUsePartListCnt = lngCnt2
                    
                    ltypUsePartList.Add(ltypUsePartListTmp)
                    lngCnt2 = lngCnt2 + 1
                End If
            Next
            
            If llngUsePartListCnt > 0 Then
                prvvsfInvLotList_Get = True
            End If
                    
            Exit Function


        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfInvLotList_Get"
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

    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfInvLotList.KeyDownEdit

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

    '関数名：vsfInvLotList_Click
    '機　能：ﾘｽﾄｸﾘｯｸ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/03/12 (Tue) 14:00:00 NSYS
    '更新日：2019/03/12 (Tue) 14:00:00 NSYS
    '備　考：vsfOpList2_Clickが全てコメントのため、新規に作成
    Private Sub vsfInvLotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfInvLotList.Click
        Try

        '@大工程が選択されている場合は行を退避しておく
        With vsfInvLotList
            '@ﾃﾞｰﾀがある場合
            If .Rows.Count > 1 Then
                lpreRow = .Row
            End If
        End With

        Exit Sub
        Catch ex As Exception
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfInvLotList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try

    End Sub

    '関数名：vsfInvLotList_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/03/12 (Tue) 14:00:00 NSYS
    '更新日：2019/03/12 (Tue) 14:00:00 NSYS
    '備　考：
    Private Sub vsfInvLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfInvLotList.BeforeSort
        Try

            '@ソート前のスクロール位置を退避しておく
            lprePos = vsfInvLotList.ScrollPosition

            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfInvLotList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfInvLotList_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/03/12 (Tue) 14:00:00 NSYS
    '更新日：2019/03/12 (Tue) 14:00:00 NSYS
    '備　考：
    Private Sub vsfInvLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfInvLotList.AfterSort
        Try

            '@大工程が選択されている場合は退避しておいた、行、スクロール位置を戻す
            With vsfInvLotList
                If .Rows.Count > .Rows.Fixed Then
                    RemoveHandler vsfInvLotList.EnterCell, AddressOf vsfInvLotList_EnterCell
                    .Row = lpreRow
                    .Col = 1
                    AddHandler vsfInvLotList.EnterCell, AddressOf vsfInvLotList_EnterCell
                    .ShowCell(.Row,.Col)
                    .ScrollPosition = lprePos
                End If
            End With

            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPart_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

End Class
