'ﾌｧｲﾙ名：xxEN01U2.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾌｫﾄF/B patch分割パラメータ設定画面
'作成日：2017/01/19 (Thu) 10:41:30 T.Oide
'更新日：2017/03/27 (Mon) 11:57:01 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2017-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01U2
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01U2    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01U2
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01U2
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01U2)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    '****************************************************************************************
    '                                      *定数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN01U2  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2017/03/09 (Thu) 09:24:04 T.Oide **************************************************
    '@Private Const CMstreq__photofbdatachgVer            As String = "03.01"             'ﾌｫﾄF/Bﾃﾞｰﾀ変更(合せ)
    Private Const CMstreq__photofbdatachgVer            As String = "04.00"             'ﾌｫﾄF/Bﾃﾞｰﾀ変更(合せ)
    '@↑2017/03/09 (Thu) 09:24:04 T.Oide **************************************************

    '@vsfFbDataListの定数宣言（ｶﾗﾑ）
    Private Const CMlngvsfListColNo                     As Integer = 0                  '№
    Private Const CMlngvsfListColItem1                  As Integer = 1                  'ﾊﾟﾗﾒｰﾀ1
    Private Const CMlngvsfListColItem2                  As Integer = 2                  'ﾊﾟﾗﾒｰﾀ2
    Private Const CMlngvsfListColItem3                  As Integer = 3                  'ﾊﾟﾗﾒｰﾀ3
    Private Const CMlngvsfListColItem4                  As Integer = 4                  'ﾊﾟﾗﾒｰﾀ4
    Private Const CMlngvsfListColItem5                  As Integer = 5                  'ﾊﾟﾗﾒｰﾀ5
    Private Const CMlngvsfListColItem6                  As Integer = 6                  'ﾊﾟﾗﾒｰﾀ6
    Private Const CMlngvsfListColItem7                  As Integer = 7                  'ﾊﾟﾗﾒｰﾀ7
    Private Const CMlngvsfListColItem8                  As Integer = 8                  'ﾊﾟﾗﾒｰﾀ8
    Private Const CMlngvsfListColItem9                  As Integer = 9                  'ﾊﾟﾗﾒｰﾀ9
    Private Const CMlngvsfListColItem10                 As Integer = 10                 'ﾊﾟﾗﾒｰﾀ10
    Private Const CMlngvsfListColItem11                 As Integer = 11                 'ﾊﾟﾗﾒｰﾀ11
    Private Const CMlngvsfListColItem12                 As Integer = 12                 'ﾊﾟﾗﾒｰﾀ12

    '@vsfFbDataListの定数宣言（表示幅）
    Private Const CMlngvsfListColWNo                    As Integer = 48                 '№
    'Private Const CMlngvsfListColwItem1                 As Integer = 108                'ﾊﾟﾗﾒｰﾀ1
    Private Const CMlngvsfListColwItem1                 As Integer = 74                 'ﾊﾟﾗﾒｰﾀ1
    Private Const CMlngvsfListColwItem2                 As Integer = 74                 'ﾊﾟﾗﾒｰﾀ2
    Private Const CMlngvsfListColwItem3                 As Integer = 74                 'ﾊﾟﾗﾒｰﾀ3
    Private Const CMlngvsfListColwItem4                 As Integer = 74                 'ﾊﾟﾗﾒｰﾀ4
    Private Const CMlngvsfListColwItem5                 As Integer = 74                 'ﾊﾟﾗﾒｰﾀ5
    Private Const CMlngvsfListColwItem6                 As Integer = 74                 'ﾊﾟﾗﾒｰﾀ6
    Private Const CMlngvsfListColwItem7                 As Integer = 74                 'ﾊﾟﾗﾒｰﾀ7
    Private Const CMlngvsfListColwItem8                 As Integer = 74                 'ﾊﾟﾗﾒｰﾀ8
    Private Const CMlngvsfListColwItem9                 As Integer = 74                 'ﾊﾟﾗﾒｰﾀ9
    Private Const CMlngvsfListColwItem10                As Integer = 74                 'ﾊﾟﾗﾒｰﾀ10
    Private Const CMlngvsfListColwItem11                As Integer = 74                 'ﾊﾟﾗﾒｰﾀ11
    Private Const CMlngvsfListColwItem12                As Integer = 74                 'ﾊﾟﾗﾒｰﾀ12

    '@vsfFbDataListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrvsfListColTNo                    As String = "patch"

    '@ｸﾞﾘｯﾄﾞ設定
    Private Const CMlngvsfTRow                          As Integer = 0                  'ﾀｲﾄﾙ行
    'Private Const CMlngVsfHFontSize                     As Integer = 12                 'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHFontSize                     As Integer = 10                 'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                       As Integer = 26                 '行の高さ(ﾍｯﾀﾞｰ)
    Private Const CMlngvsfBHeight                       As Integer = 37                 '行の高さ(ﾎﾞﾃﾞｨ)
    Private Const CMlngInputNDataMaxByte                As Integer = 10                 '文字入力の最大ﾊﾞｲﾄ数(数値）
    'Private Const CMlngvsfListCols                      As Integer = 9                  'ｶﾗﾑ数
    Private Const CMlngvsfListCols                      As Integer = 13                 'ｶﾗﾑ数

    '@その他
    Private Const CMlngCmbGridCol1                      As Integer = 1                  '名称列番=1
    Private Const CMlngKara                             As Integer = 0                  'ﾃﾞｰﾀを表示しない
    Private Const CMlngNew                              As Integer = 1                  '最新ﾃﾞｰﾀを表示
    Private Const CMlngParameterNum                     As Integer = 8 + 4              'ﾊﾟﾗﾒｰﾀ数ﾁｪｯｸ用(+Shot分離4)
    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mstrEntryTime                               As String                       '最新のENTRY_TIME(合せ)
    Private mblnEditFlag                                As Boolean                      '編集ﾌﾗｸﾞ
    Private buttonProcessing                            As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                      'NSYS WindowCloseフラグ


    '****************************************************************************************
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
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/01/19 (Thu) 10:46:23 T.Oide
    '更新日：2017/01/19 (Thu) 10:46:23
    '備　考：
    Private Sub Form_Load()

        Try
               
            '@画面情報の初期化
            Call prvfrmxxEN01U2_Init()
            
            '@画面情報表示処理
            Call prvfrmxxEN01U2_Disp(frmxxEN01U0.Instance.vsfFbDataList.Row)
            
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

    '関数名：Form_QueryUnload
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2017/01/19 (Thu) 10:46:23 T.Oide
    '更新日：2017/01/19 (Thu) 10:46:23
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            '@編集中ﾁｪｯｸ
            If prvEditCheck = False Then
                e.Cancel = True
                Exit Sub
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
    '作成日：2017/01/19 (Thu) 10:46:23 T.Oide
    '更新日：2017/01/19 (Thu) 10:46:23
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
            
            '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞしてﾌﾟﾛｸﾞﾗﾑ終了
            Me.Close()

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

    '関数名：cmdClear_Click
    '機　能：設定値をｸﾘｱする
    '引　数：なし
    '戻り値：
    '作成日：2017/01/26 (Thu) 15:43:05 T.Oide
    '更新日：2017/01/26 (Thu) 15:43:05
    '備　考：
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@編集中ﾁｪｯｸ
            If prvEditCheck = False Then
                Exit Sub
            End If

            '@ｺﾒﾝﾄｸﾘｱ
            txtComments.Text = vbNullString

            '@ｸﾞﾘｯﾄﾞ初期化
            Call prvvsfFbDataList_init()
            
            '@ﾃﾞｰﾀを空で表示
            Call prvfrmxxEN01U2_Disp(CMlngKara)
                
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

    '関数名：cmdCopy_Click
    '機　能：F/Bﾃﾞｰﾀの現在値(履歴の最新値)を構造体から表示する
    '引　数：なし
    '戻り値：
    '作成日：2017/01/24 (Tue) 11:11:22 T.Oide
    '更新日：2017/01/24 (Tue) 11:11:22
    '備　考：
    Private Sub cmdCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopy.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@編集中ﾁｪｯｸ
            If prvEditCheck = False Then
                Exit Sub
            End If
            
            '@構造体にﾃﾞｰﾀはあるか(履歴はあるか)
            If ptypPhotoFbDataListAns.lngFbDataItemListCnt <> 0 Then
                '@ﾃﾞｰﾀがある場合は、最新の値を表示
                Call prvfrmxxEN01U2_Disp(CMlngNew)
            Else
                '@ﾃﾞｰﾀがない場合は空を表示
                Call prvfrmxxEN01U2_Disp(CMlngKara)
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

    '関数名：cmdClipCopy_Click
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
    '引　数：なし
    '戻り値：なし
    '作成日：2017/01/26 (Thu) 11:44:50 T.Oide
    '更新日：2017/01/26 (Thu) 11:44:50 T.Oide
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
            Clipboard.Clear
            
            '@一覧をｺﾋﾟｰする
            With vsfFbDataList
                
                '@行ﾙｰﾌﾟ
                For llngRowCnt = 0 To .Rows.Count - 1
                    
                    '@列ﾙｰﾌﾟ
                    For llngColCnt = 0 To .Cols.Count - 1
                        
                        '@文字列編集変数に値をｾｯﾄ
                        lstrWk = .GetData(llngRowCnt, llngColCnt)
                        
                        '@最終列の場合Tabいらない
                        If llngColCnt = .Cols.Count - 1 Then
                            '@ｺﾋﾟｰ文字列作成
                            lstrRET = lstrRET & lstrWk
                        Else
                            '@ｺﾋﾟｰ文字列作成
                            lstrRET = lstrRET & lstrWk & vbTab
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
            Call publngMsgBoxInfo(pstrDMsg, vbInformation, frmxxEN0230.Instance.Text, True, 16)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCopy_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdClipPaste_Click
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞ貼付
    '引　数：なし
    '戻り値：
    '作成日：2017/01/26 (Thu) 12:53:51 T.Oide
    '更新日：2017/01/26 (Thu) 12:53:51
    '備　考：
    Private Sub cmdClipPaste_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClipPaste.Click

        Dim llngRowCnt              As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngColCnt              As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrDataLine()          As String       '1行分の文字列
        Dim lstrDataelement()       As String       '1ﾃﾞｰﾀ
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@編集中ﾁｪｯｸ
            If prvEditCheck = False Then
                Exit Sub
            End If
            
            '@1行のﾃﾞｰﾀを取得(line(0)～(8)に1行分のﾃﾞｰﾀがTab区切りで入っている状態
            lstrDataLine = Split(Clipboard.GetText, vbCrLf)
            
            '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞの中身をﾁｪｯｸ(ﾁｪｯｸNGの場合は処理中止)
            If prvClipCheck(lstrDataLine) = False Then
                Exit Sub
            End If
            
            With vsfFbDataList
            
                '@一覧に張付る
                '@行ﾙｰﾌﾟ
                For llngRowCnt = 0 To .Rows.Count - 2
                    
                    '@1つのﾃﾞｰﾀを取得(element(0)～(7)に各ﾊﾟﾗﾒｰﾀの値が入っている状態)
                    lstrDataelement = Split(lstrDataLine(llngRowCnt), vbTab)
                    
                    '@列ﾙｰﾌﾟ
                    For llngColCnt = 0 To .Cols.Count - 2
                                    
                        '@ｾﾙに値をｾｯﾄ
                        .SetData(llngRowCnt + 1, llngColCnt + 1, CDbl(lstrDataelement(llngColCnt)))

                    Next llngColCnt
                    
                Next llngRowCnt
                
            End With
            
            '編集ﾌﾗｸﾞON
            mblnEditFlag = True
            
            '@ボタン有効/無効制御
            Call prvCmdButton_Chk()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClipPaste_Click"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/01/19 (Thu) 10:46:23 T.Oide
    '更新日：2017/01/19 (Thu) 10:46:23
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean
        Dim lstrEventName           As String
        Dim ltypPhotoFbDataChgReq   As PhotoFbDataChgReq    'Publicの構造体ｸﾘｱ用
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@確定ﾁｪｯｸ(入力漏れﾁｪｯｸ)
            lblnAns = prvblnProcEnd_Chk
            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdProcEnd_Click"
            Call pubResponseStart(Me.Name, lstrEventName)

            '@登録ﾃﾞｰﾀを構造体にｾｯﾄ
            Call prvPhotoFbDataChgReq_set()

            '@【ﾌｫﾄF/Bﾃﾞｰﾀ変更(合せ)】
            lblnAns = pubblnPhotoFbDataChg_Upd(ptypPhotoFbDataChgReq)

            '@結果判定
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)

                '@登録用の構造体ｸﾘｱ
                ptypPhotoFbDataChgReq = ltypPhotoFbDataChgReq

                'NSYS 編集ﾌﾗｸﾞを初期化する
                mblnEditFlag = False

                '@ﾌｫｰﾑを閉じる終了
                Me.Close()
                
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                '@異常の場合終了
                Exit Sub
                
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

    '関数名：txtComments_Change
    '機　能：ｺﾒﾝﾄ変更
    '引　数：なし
    '戻り値：なし
    '作成日：2017/01/25 (Wed) 17:22:08 T.Oide
    '更新日：2017/01/25 (Wed) 17:22:08 T.Oide
    '備　考：
    Private Sub txtComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.Change

        Dim llngNowByte     As Integer  'ｺﾒﾝﾄ桁数

        Try
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtComments.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbDataList_AfterEdit
    '機　能：
    '引　数：Row：
    '　　　：Col：
    '戻り値：
    '作成日：2017/01/25 (Wed) 11:31:05 T.Oide
    '更新日：2017/01/25 (Wed) 11:31:05
    '備　考：
    Private Sub vsfFbDataList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFbDataList.AfterEdit

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList.Rows.Count <= vsfFbDataList.Rows.Fixed Then
                Return
            End If
            
            With vsfFbDataList
                'NSYS 編集内容が数値の場合、フォーマットして表示
                If IsNumeric(.GetData(e.Row, e.Col)) Then
                    .SetData(e.Row, e.Col, CDbl(.GetData(e.Row, e.Col)))
                End If

                ’Shot分離なしのレシピ
                If lblShotSeparateFlag.Text <> CPstrAriFlg Then
                    '「SHOTROT」を入力の場合
                    If e.Col = CMlngvsfListColItem7 Then
                        '「SHOTROTX」「SHOTROTY」に「SHOTROT」の値を入れる
                        .SetData(e.Row, CMlngvsfListColItem9, CDbl(Format$(.GetData(e.Row, e.Col), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotXValidDigit))))
                        .SetData(e.Row, CMlngvsfListColItem10, CDbl(Format$(.GetData(e.Row, e.Col), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotYValidDigit))))
                    End If

                    '「SHOTMAG」を入力の場合
                    If e.Col = CMlngvsfListColItem8 Then
                        '「SHOTMAGX」「SHOTMAGY」に「SHOTMAG」の値を入れる
                        .SetData(e.Row, CMlngvsfListColItem11, CDbl(Format$(.GetData(e.Row, e.Col), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagXValidDigit))))
                        .SetData(e.Row, CMlngvsfListColItem12, CDbl(Format$(.GetData(e.Row, e.Col), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagXValidDigit))))
                    End If

                ’Shot分離ありのレシピ
                Else
                    '「SHOTROTX」「SHOTROTY」を入力の場合
                    If e.Col = CMlngvsfListColItem9 Or e.Col = CMlngvsfListColItem10 Then
                        '「SHOTROT」に「SHOTROTX」「SHOTROTY」の平均値を入れる
                        If CStr(.GetData(e.Row, CMlngvsfListColItem9)) <> vbNullString And CStr(.GetData(e.Row, CMlngvsfListColItem10)) <> vbNullString Then
                            Dim tmp As Single =  Single.Parse(.GetData(e.Row, CMlngvsfListColItem9)) + Single.Parse(.GetData(e.Row, CMlngvsfListColItem10))
                            .SetData(e.Row, CMlngvsfListColItem7, CDbl(Format$(tmp/2, pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotValidDigit))))
                        End If
                    End If

                    '「SHOTMAGX」「SHOTMAGY」を入力の場合
                    If e.Col = CMlngvsfListColItem11 Or e.Col = CMlngvsfListColItem12 Then
                        '「SHOTMAG」に「SHOTMAGX」「SHOTMAGY」の平均値を入れる
                        If CStr(.GetData(e.Row, CMlngvsfListColItem11)) <> vbNullString And CStr(.GetData(e.Row, CMlngvsfListColItem12)) <> vbNullString Then
                            Dim tmp As Single =  Single.Parse(.GetData(e.Row, CMlngvsfListColItem11)) + Single.Parse(.GetData(e.Row, CMlngvsfListColItem12))
                            .SetData(e.Row, CMlngvsfListColItem8, CDbl(Format$(tmp/2, pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagValidDigit))))
                        End If
                    End If
                End If
            End With
            
            '@編集あり
            mblnEditFlag = True
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvCmdButton_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfFbDataList_KeyDown
    '機　能：ｷｰ入力時の編集可否設定
    '引　数：KeyCode：
    '　　　：Shift：
    '戻り値：
    '作成日：2017/01/25 (Wed) 10:12:28 T.Oide
    '更新日：2017/01/25 (Wed) 10:12:28
    '備　考：
    Private Sub vsfFbDataList_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfFbDataList.KeyDown

        Dim lblnCpy         As Boolean      'ｺﾋﾟｰﾌﾗｸﾞ
        Dim lblnPst         As Boolean      'ﾍﾟｰｽﾄﾌﾗｸﾞ

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList.Rows.Count <= vsfFbDataList.Rows.Fixed Then
                Return
            End If
            
            With vsfFbDataList
            
                '############################
                ' ｸﾘｯﾌﾟﾎﾞｰﾄﾞからのﾍﾟｰｽﾄ処理
                ' ｼｮｰﾄｶｯﾄｷｰでｺﾋﾟｰ/ﾍﾟｰｽﾄを行う場合は、ｸﾞﾘｯﾄﾞの非入力ｾﾙを選択して行う
                '############################
                '@ ペーストか(ctrl-v)
                If e.KeyCode = Keys.V And e.Modifiers = Keys.Control Then
                    lblnPst = True
                End If
                
                '@ コピーか(ctrl-c)
                If e.KeyCode = Keys.C And e.Modifiers = Keys.Control Then
                    lblnCpy = True
                End If
                
                '@ﾍﾟｰｽﾄ実行か
                If lblnPst Then
                    '@ ｸﾘｯﾌﾟﾎﾞｰﾄﾞお貼付
                    Call cmdClipPaste_Click(cmdClipPaste, New EventArgs)
                    Exit Sub
                ElseIf lblnCpy Then
                    '@ ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                    Call cmdClipCopy_Click(cmdClipCopy, New EventArgs)
                    Exit Sub
                End If
            
                '############################
                ' 通常のｷｰ入力判定処理
                '############################
                '@ﾍｯﾀﾞｰ行の場合なにもしない
                If .Row = 0 Then
                    Exit Sub
                End If
                
                '@ｷｰにより処理分岐
                Select Case e.KeyCode
                
                    Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.PageUp, Keys.PageDown
                        
                    Case Else
                    
                        '一時無効化
                        Select Case .Col

                            '@№
                            Case CMlngvsfListColNo
                                '@編集不可
                                .AllowEditing = False

                            '@ﾊﾟﾗﾒｰﾀ値
                            Case Else

                                'Shot分離対応、Shot分離有無で入力パラメータが異なるので、入力不可色の場合は編集不可とする
                                If .GetCellStyle(.Row, .Col).BackColor = ColorTranslator.FromWin32(CPlngNotInputColor) Then
                                    '@編集不可
                                    .AllowEditing = False
                                    Exit Sub
                                End If

                                If e.KeyCode = Keys.F2 OrElse e.KeyCode = Keys.Space Then
                                    'NSYS [F2][Space]キーの場合
                                    e.SuppressKeyPress = True
                                End If

                                If e.KeyCode = Keys.Space Then  'ｽﾍﾟｰｽは無効
                                    e.Handled = True
                                End If
                                '@DELETEｷｰの場合は値をｸﾘｱする。
                                If e.KeyCode = Keys.Delete Then
                                    .SetData(.Row, .Col, vbNullString)
                                End If

                                '@編集可能ｾﾙの場合
                                .Select(.Row, .Col)     '編集可能ｾﾙの範囲選択
                                .StartEditing()         '編集可能にする

                                'NSYS [BackSpace]キーの場合
                                If e.KeyCode = Keys.Back AndAlso (TypeOf .Editor Is TextBox)
                                    CType(.Editor, TextBox).Clear()
                                End If
                        End Select
                        
                End Select
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfFbDataList_KeyPressEdit
    '機　能：ｷｰ入力時の編集可否設定
    '引　数：Row：
    '　　　：Col：
    '　　　：KeyAscii：
    '戻り値：
    '作成日：2017/01/25 (Wed) 10:17:01 T.Oide
    '更新日：2017/01/25 (Wed) 10:17:01
    '備　考：
    Private Sub vsfFbDataList_KeyPressEdit(ByVal sender As Object, ByVal e As KeyPressEditEventArgs) Handles vsfFbDataList.KeyPressEdit

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList.Rows.Count <= vsfFbDataList.Rows.Fixed Then
                Return
            End If

            With vsfFbDataList
                
                Select Case e.Col
                    '@№
                     Case CMlngvsfListColNo
                        '@編集不可
                         .AllowEditing = False
                         
                    '@ﾊﾟﾗﾒｰﾀ値
                    Case Else
                        '@半角数字,「.」「-」のみ入力可
                        Select Case Asc(e.KeyChar)
                            Case CPlngKeyAsciiNum0 To CPlngKeyAsciiNum9, CPlngKeyBackSpace, CPlngKeyReturn, CPlngKeyAsciiDecPoint, CPlngKeyAsciiMinus
                                '@入力可能
                            Case Else
                                e.Handled = True 'ｷｰ無効
                        
                        End Select
                
                End Select
                   
            End With
            
            '@[']の入力禁止
            If Asc(e.KeyChar) = CPlngKeyAscSingleQ Then
                e.Handled = True
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList_KeyPressEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbDataList_DblClick
    '機　能：ﾀﾞﾌﾞﾙｸﾘｯｸ時の編集可否設定
    '引　数：なし
    '戻り値：
    '作成日：2017/01/25 (Wed) 10:20:54 T.Oide
    '更新日：2017/01/25 (Wed) 10:20:54
    '備　考：
    Private Sub vsfFbDataList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFbDataList.DoubleClick
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbDataList.Rows.Count <= vsfFbDataList.Rows.Fixed Then
                Return
            End If
            
            With vsfFbDataList
            
                '@ﾍｯﾀﾞｰ行の場合、処理中止
                If .Row = 0 Then
                    Exit Sub
                End If
                
                '@列判定
                Select Case .Col
                    '@№
                    Case CMlngvsfListColNo
                        '@編集不可
                        .AllowEditing = False
                    '@変更値
                    Case Else
                        '@編集可能ｾﾙの場合
                        .Select(.Row, .Col)     '編集可能ｾﾙの範囲選択
                        .StartEditing()         '編集可能にする
                End Select
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbDataList_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvfrmxxEN01U2_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2017/01/19 (Thu) 10:46:23 T.Oide
    '更新日：2017/01/19 (Thu) 10:46:23
    '備　考：
    Private Sub prvfrmxxEN01U2_Init()

        Try
            
            '@ﾗﾍﾞﾙ表示
            lblWpName.Text = frmxxEN01U0.Instance.cmbWp.Text        'フォト号機
            lblReferencePhoto.Text = frmxxEN01U0.Instance.cmbReferenceWP.Text   '1stフォト号機
            lblRecipe.Text = frmxxEN01U0.Instance.txtRecipeID.Text  'レシピ
            lblEmpName.Text = vbNullString                          '最終更新者
            lblEditTime.Text = vbNullString                         '更新時刻
            lblShotSeparateFlag.Text = frmxxEN01U0.Instance.lblShotSeparateFlag.Text
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfFbDataList_init()
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ有効/無効設定
            Call prvCmdButton_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01U2_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN01U2_Disp
    '機　能：画面情報表示
    '引　数：llngDispRow:表示するﾃﾞｰﾀの親画面の行
    '戻り値：なし
    '作成日：2017/01/19 (Thu) 10:46:23 T.Oide
    '更新日：2017/01/19 (Thu) 10:46:23
    '備　考：
    Private Sub prvfrmxxEN01U2_Disp(ByVal llngDispRow As Integer)

        Dim llngDoCnt                   As Integer      'Doの回数ｶｳﾝﾄ
        Dim lstrTmpShiftX               As String       'ﾊﾟﾗﾒｰﾀ1
        Dim lstrTmpShiftY               As String       'ﾊﾟﾗﾒｰﾀ2
        Dim lstrTmpWaferMagX            As String       'ﾊﾟﾗﾒｰﾀ3
        Dim lstrTmpWaferMagY            As String       'ﾊﾟﾗﾒｰﾀ4
        Dim lstrTmpWaferRotX            As String       'ﾊﾟﾗﾒｰﾀ5
        Dim lstrTmpWaferRotY            As String       'ﾊﾟﾗﾒｰﾀ6
        Dim lstrTmpShotRot              As String       'ﾊﾟﾗﾒｰﾀ7
        Dim lstrTmpShotMag              As String       'ﾊﾟﾗﾒｰﾀ8
        Dim lstrTmpShotRotX             As String       'ﾊﾟﾗﾒｰﾀ9
        Dim lstrTmpShotRotY             As String       'ﾊﾟﾗﾒｰﾀ10
        Dim lstrTmpShotMagX             As String       'ﾊﾟﾗﾒｰﾀ11
        Dim lstrTmpShotMagY             As String       'ﾊﾟﾗﾒｰﾀ12
        Dim llngPatchDivideNumRecipe    As Integer
        
        Try

            '@ﾊﾟｯﾁ分割設定か
            llngPatchDivideNumRecipe = 0
            If ptypPhotoFbDataListAns.strPatchDivideNumRecipe <> vbNullString Then
                '@ﾊﾟｯﾁ分割数設定
                llngPatchDivideNumRecipe = CLng(ptypPhotoFbDataListAns.strPatchDivideNumRecipe)
            End If

            '@一覧表示
            With vsfFbDataList
                '@描画なし
                .Redraw = False
                '@行数設定
                .Rows.Count = .Rows.Fixed
                .Rows.Count = llngPatchDivideNumRecipe + 1
                '@ｶｳﾝﾀの初期化
                llngDoCnt = 1

                '@ﾌｫｰﾏｯﾄにより四捨五入
                .Cols(CMlngvsfListColItem1).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShiftXValidDigit)       'ﾊﾟﾗﾒｰﾀ1【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem2).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShiftYValidDigit)       'ﾊﾟﾗﾒｰﾀ2【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem3).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferMagXValidDigit)    'ﾊﾟﾗﾒｰﾀ3【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem4).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferMagYValidDigit)    'ﾊﾟﾗﾒｰﾀ4【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem5).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferRotXValidDigit)    'ﾊﾟﾗﾒｰﾀ5【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem6).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferRotYValidDigit)    'ﾊﾟﾗﾒｰﾀ6【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem7).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotValidDigit)      'ﾊﾟﾗﾒｰﾀ7【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem8).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagValidDigit)      'ﾊﾟﾗﾒｰﾀ8【ﾌｫｰﾏｯﾄ】
                'Shot分離
                .Cols(CMlngvsfListColItem9).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotXValidDigit)     'ﾊﾟﾗﾒｰﾀ9【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem10).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotYValidDigit)    'ﾊﾟﾗﾒｰﾀ10【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem11).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagXValidDigit)    'ﾊﾟﾗﾒｰﾀ11【ﾌｫｰﾏｯﾄ】
                .Cols(CMlngvsfListColItem12).Format = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagYValidDigit)    'ﾊﾟﾗﾒｰﾀ12【ﾌｫｰﾏｯﾄ】

                '@ﾌｫﾄF/Bﾃﾞｰﾀ一覧表示
                For llngDoCnt = 1 To llngPatchDivideNumRecipe
                    
                    '@ 表示指定行があるか
                    If llngDispRow > 0 Then
                        '@選択中のﾃﾞｰﾀを子画面に表示
                        
                        '@ﾊﾟｯﾁ№に応じた値を構造体から取得
                        Call pubSetPatchNoItems(llngDoCnt, llngDispRow - 1, _
                                                lstrTmpShiftX, lstrTmpShiftY, _
                                                lstrTmpWaferMagX, lstrTmpWaferMagY, _
                                                lstrTmpWaferRotX, lstrTmpWaferRotY, _
                                                lstrTmpShotRot, lstrTmpShotMag, _
                                                lstrTmpShotRotX, lstrTmpShotRotY, _
                                                lstrTmpShotMagX, lstrTmpShotMagY)
                        
                        '@ﾃﾞｰﾀ表示
                        If IsNumeric(lstrTmpShiftX) Then
                            .SetData(llngDoCnt, CMlngvsfListColItem1, CDbl(lstrTmpShiftX))          'ShiftX
                        Else
                            .SetData(llngDoCnt, CMlngvsfListColItem1, lstrTmpShiftX)
                        End If

                        If IsNumeric(lstrTmpShiftY) Then
                            .SetData(llngDoCnt, CMlngvsfListColItem2, CDbl(lstrTmpShiftY))          'ShiftY
                        Else
                            .SetData(llngDoCnt, CMlngvsfListColItem2, lstrTmpShiftY)
                        End If

                        If IsNumeric(lstrTmpWaferMagX) Then
                            .SetData(llngDoCnt, CMlngvsfListColItem3, CDbl(lstrTmpWaferMagX))       'WaferMagX
                        Else
                            .SetData(llngDoCnt, CMlngvsfListColItem3, lstrTmpWaferMagX)
                        End If

                        If IsNumeric(lstrTmpWaferMagY) Then 
                            .SetData(llngDoCnt, CMlngvsfListColItem4, CDbl(lstrTmpWaferMagY))       'WaferMagY
                        Else
                            .SetData(llngDoCnt, CMlngvsfListColItem4, lstrTmpWaferMagY)
                        End If

                        If IsNumeric(lstrTmpWaferRotX) Then
                            .SetData(llngDoCnt, CMlngvsfListColItem5, CDbl(lstrTmpWaferRotX))       'WaferRotX
                        Else
                            .SetData(llngDoCnt, CMlngvsfListColItem5, lstrTmpWaferRotX)
                        End If

                        If IsNumeric(lstrTmpWaferRotY) Then
                            .SetData(llngDoCnt, CMlngvsfListColItem6, CDbl(lstrTmpWaferRotY))       'WaferRotY
                        Else
                            .SetData(llngDoCnt, CMlngvsfListColItem6, lstrTmpWaferRotY)
                        End If

                        If IsNumeric(lstrTmpShotRot) Then
                            .SetData(llngDoCnt, CMlngvsfListColItem7, CDbl(lstrTmpShotRot))         'ShotRot
                        Else
                            .SetData(llngDoCnt, CMlngvsfListColItem7, lstrTmpShotRot)
                        End If

                        If IsNumeric(lstrTmpShotMag) Then
                            .SetData(llngDoCnt, CMlngvsfListColItem8, CDbl(lstrTmpShotMag))         'ShotMag
                        Else
                            .SetData(llngDoCnt, CMlngvsfListColItem8, lstrTmpShotMag)
                        End If

                        'Shot分離
                        If IsNumeric(lstrTmpShotRotX) Then
                            .SetData(llngDoCnt, CMlngvsfListColItem9, CDbl(lstrTmpShotRotX))
                        Else
                            .SetData(llngDoCnt, CMlngvsfListColItem9, lstrTmpShotRotX)
                        End If

                        If IsNumeric(lstrTmpShotRotY) Then
                            .SetData(llngDoCnt, CMlngvsfListColItem10, CDbl(lstrTmpShotRotY))
                        Else
                            .SetData(llngDoCnt, CMlngvsfListColItem10, lstrTmpShotRotY)
                        End If

                        If IsNumeric(lstrTmpShotMagX) Then
                            .SetData(llngDoCnt, CMlngvsfListColItem11, CDbl(lstrTmpShotMagX))
                        Else
                            .SetData(llngDoCnt, CMlngvsfListColItem11, lstrTmpShotMagX)
                        End If

                        If IsNumeric(lstrTmpShotMagY) Then
                            .SetData(llngDoCnt, CMlngvsfListColItem12, CDbl(lstrTmpShotMagY))
                        Else
                            .SetData(llngDoCnt, CMlngvsfListColItem12, lstrTmpShotMagY)
                        End If

                        'Shot分離有無による自動入力
                        'Shot分離なし
                        If lblShotSeparateFlag.Text <> CPstrAriFlg Then
                            'Shot分離SHOTROTの値が全てNULLの場合は分離なしの値(SHOTROT)を入れる
                            If .GetData(llngDoCnt, CMlngvsfListColItem9) = vbNullString And _
                                .GetData(llngDoCnt, CMlngvsfListColItem10) = vbNullString Then

                                .SetData(llngDoCnt, CMlngvsfListColItem9, CDbl(Format$(.GetData(llngDoCnt, CMlngvsfListColItem7), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotXValidDigit))))
                                .SetData(llngDoCnt, CMlngvsfListColItem10, CDbl(Format$(.GetData(llngDoCnt, CMlngvsfListColItem7), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotYValidDigit))))

                            End If

                            'Shot分離SHOTMAGの値が全てNULLの場合は分離なしの値(SHOTMAG)を入れる
                            If .GetData(llngDoCnt, CMlngvsfListColItem11) = vbNullString And _
                                .GetData(llngDoCnt, CMlngvsfListColItem12) = vbNullString Then

                                .SetData(llngDoCnt, CMlngvsfListColItem11, CDbl(Format$(.GetData(llngDoCnt, CMlngvsfListColItem8), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagXValidDigit))))
                                .SetData(llngDoCnt, CMlngvsfListColItem12, CDbl(Format$(.GetData(llngDoCnt, CMlngvsfListColItem8), pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagXValidDigit))))

                            End If

                        ’Shot分離あり
                        Else
                            'Shot分離あり(SHOTROTX)(SHOTROTY)の値がある場合は平均値を分離なしの値(SHOTROT)に入れる
                            If .GetData(llngDoCnt, CMlngvsfListColItem9) <> vbNullString And _
                                .GetData(llngDoCnt, CMlngvsfListColItem10) <> vbNullString Then

                                Dim tmp As Single =  Single.Parse(.GetData(llngDoCnt, CMlngvsfListColItem9)) + Single.Parse(.GetData(llngDoCnt, CMlngvsfListColItem10))
                                .SetData(llngDoCnt, CMlngvsfListColItem7, CDbl(Format$(tmp/2, pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotValidDigit))))
                            End If

                            'Shot分離あり(SHOTMAGX)(SHOTMAGY)の値がある場合は平均値を分離なしの値(SHOTMAG)に入れる
                            If .GetData(llngDoCnt, CMlngvsfListColItem11) <> vbNullString And _
                                .GetData(llngDoCnt, CMlngvsfListColItem12) <> vbNullString Then

                                Dim tmp As Single =  Single.Parse(.GetData(llngDoCnt, CMlngvsfListColItem11)) + Single.Parse(.GetData(llngDoCnt, CMlngvsfListColItem12))
                                .SetData(llngDoCnt, CMlngvsfListColItem8, CDbl(Format$(tmp/2, pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagValidDigit))))
                            End If
                        End If
                    End If
                    
                    '@ﾊﾟｯﾁNo表示(ﾊﾟｯﾁNoは常に表示する)
                    .SetData(llngDoCnt, CMlngvsfListColNo, llngDoCnt)
                    
                    '@セルの高さの設定
                    .Rows(llngDoCnt).Height = CMlngvsfBHeight
                Next
            
                '@ 選択中の行があるか
                If llngDispRow > 0 Then
                    '@ｺﾒﾝﾄ
                    txtComments.Text = ptypPhotoFbDataListAns.typFbDataItemList(llngDispRow - 1).strComments
                End If
                
                '@既存の登録ﾃﾞｰﾀありか
                If ptypPhotoFbDataListAns.lngFbDataItemListCnt <> 0 Then
                
                    '@最終更新者
                    lblEmpName.Text = ptypPhotoFbDataListAns.typFbDataItemList(0).strEmpName

                    '@最終更新日時(TIMESTAMP型なのでCLでﾌｫｰﾏｯﾄする)
                    lblEditTime.Text = _
                        Format$(CDate(Strings.Left$(ptypPhotoFbDataListAns.typFbDataItemList(0).strEntryTime, _
                        Len(ptypPhotoFbDataListAns.typFbDataItemList(0).strEntryTime) - 4)), CPstrDateTimeYMDHMS)
                End If

                '@ﾊﾞｯｸｶﾗｰの変更
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                newStyle.BackColor = Color.White
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfTRow + 1, CMlngCmbGridCol1, .Rows.Count - 1, .Cols.Count - 1)
                cellRange.Style = newStyle

                'Shot分離なし
                If lblShotSeparateFlag.Text <> CPstrAriFlg Then
                    '@ﾊﾞｯｸｶﾗｰの変更(入力不可色：ｸﾞﾚｰ)
                    Dim newShotStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                    newShotStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                    Dim cellShot As CellRange = .GetCellRange(CMlngvsfTRow + 1, CMlngvsfListColItem9, .Rows.Count - 1, CMlngvsfListColItem12)
                    cellShot.Style = newShotStyle

                ’Shot分離あり
                Else
                    '@ﾊﾞｯｸｶﾗｰの変更(入力不可色：ｸﾞﾚｰ)
                    Dim newShotStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                    newShotStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                    Dim cellShot As CellRange = .GetCellRange(CMlngvsfTRow + 1, CMlngvsfListColItem7, .Rows.Count - 1, CMlngvsfListColItem8)
                    cellShot.Style = newShotStyle

                End If
                
                'NSYS ヘッダー行を選択
                .Row = 0

                '@直接描画
                .Redraw = True
                
                '@編集ﾌﾗｸﾞｸﾘｱ
                mblnEditFlag = False
                
            End With
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvCmdButton_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01U2_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfFbDataList_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化(ﾃﾞｰﾀﾘｽﾄ)
    '引　数：なし
    '戻り値：なし
    '作成日：2017/01/19 (Thu) 10:46:23 T.Oide
    '更新日：2017/01/19 (Thu) 10:46:23
    '備　考：
    Private Sub prvvsfFbDataList_init()

        Try

            '@ｸﾞﾘｯﾄﾞ設定
            With vsfFbDataList
                
                .Redraw = False                                             '描画なし
                .Rows.Count = .Rows.Fixed                                   'ｸﾞﾘｯﾄﾞの行設定
                .Cols.Count = CMlngvsfListCols                              'ｸﾞﾘｯﾄﾞの列設定
                .Cols.Frozen = 1                                            '固定列の設定
                '.AllowBigSelection = False                                 'ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowSelection = False                                    'ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Row                      '行選択
                '.FillStyle = flexFillRepeat                                'ﾌﾟﾛﾊﾟﾃｨの設定対象（選択ｾﾙ）
                .FocusRect = FocusRectEnum.Light                            'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠（細い枠）
                .ScrollBars = ScrollBars.None                               'ｽｸﾛｰﾙﾊﾞｰ（なし）
                '.AutoSizeMode = flexAutoSizeColWidth                       'ｵｰﾄｻｲｽﾞ（列）
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter  '文字列の最後に省略符号
                '.AllowUserResizing = flexResizeColumns                     '列幅の変更許可
                .ExtendLastCol = True                                       '右端の列をｸﾞﾘｯﾄﾞに合わせる
                .AllowSorting = AllowSortingEnum.None                       'ﾍｯﾀﾞｰｸﾘｯｸでｿｰﾄしない
                
                '@一覧表の表題設定
                .Select(CMlngvsfTRow, CMlngvsfListColNo, CMlngvsfTRow, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CMlngVsfHFontSize, _
                                            lFixedStyle.Font.Style, lFixedStyle.Font.Unit)  'ﾌｫﾝﾄｻｲｽﾞ
                lFixedStyle.ForeColor = Color.Yellow                                        '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)           '背景色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                          '配置
                lFixedStyle.Trimming = StringTrimming.None                                  'NSYS ヘッダー文字列を省略表示しない
                .Rows(CMlngvsfTRow).Height = CMlngVsfHHeight                                'ﾍｯﾀﾞｰ高さ
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfTRow, CMlngvsfListColNo, CMstrvsfListColTNo)                               'patch№
                .SetData(CMlngvsfTRow, CMlngvsfListColItem1, ptypPhotoFbDataListAns.strShiftXItemName)      'ﾊﾟﾗﾒｰﾀ1
                .SetData(CMlngvsfTRow, CMlngvsfListColItem2, ptypPhotoFbDataListAns.strShiftYItemName)      'ﾊﾟﾗﾒｰﾀ2
                .SetData(CMlngvsfTRow, CMlngvsfListColItem3, ptypPhotoFbDataListAns.strWaferMagXItemName)   'ﾊﾟﾗﾒｰﾀ3
                .SetData(CMlngvsfTRow, CMlngvsfListColItem4, ptypPhotoFbDataListAns.strWaferMagYItemName)   'ﾊﾟﾗﾒｰﾀ4
                .SetData(CMlngvsfTRow, CMlngvsfListColItem5, ptypPhotoFbDataListAns.strWaferRotXItemName)   'ﾊﾟﾗﾒｰﾀ5
                .SetData(CMlngvsfTRow, CMlngvsfListColItem6, ptypPhotoFbDataListAns.strWaferRotYItemName)   'ﾊﾟﾗﾒｰﾀ6
                .SetData(CMlngvsfTRow, CMlngvsfListColItem7, ptypPhotoFbDataListAns.strShotRotItemName)     'ﾊﾟﾗﾒｰﾀ7
                .SetData(CMlngvsfTRow, CMlngvsfListColItem8, ptypPhotoFbDataListAns.strShotMagItemName)     'ﾊﾟﾗﾒｰﾀ8
                'Shot分離
                .SetData(CMlngvsfTRow, CMlngvsfListColItem9, ptypPhotoFbDataListAns.strShotRotXItemName)    'ﾊﾟﾗﾒｰﾀ9
                .SetData(CMlngvsfTRow, CMlngvsfListColItem10, ptypPhotoFbDataListAns.strShotRotYItemName)   'ﾊﾟﾗﾒｰﾀ10
                .SetData(CMlngvsfTRow, CMlngvsfListColItem11, ptypPhotoFbDataListAns.strShotMagXItemName)   'ﾊﾟﾗﾒｰﾀ11
                .SetData(CMlngvsfTRow, CMlngvsfListColItem12, ptypPhotoFbDataListAns.strShotMagYItemName)   'ﾊﾟﾗﾒｰﾀ12

                '@表示ﾌｫｰﾏｯﾄ
                .Cols(CMlngvsfListColNo).TextAlign = TextAlignEnum.RightCenter              '№（右中央）
                .Cols(CMlngvsfListColItem1).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ1（右中央）
                .Cols(CMlngvsfListColItem2).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ2（右中央）
                .Cols(CMlngvsfListColItem3).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ3（右中央）
                .Cols(CMlngvsfListColItem4).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ4（右中央）
                .Cols(CMlngvsfListColItem5).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ5（右中央）
                .Cols(CMlngvsfListColItem6).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ6（右中央）
                .Cols(CMlngvsfListColItem7).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ7（右中央）
                .Cols(CMlngvsfListColItem8).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ8（右中央）
                'Shot分離
                .Cols(CMlngvsfListColItem9).TextAlign = TextAlignEnum.RightCenter           'ﾊﾟﾗﾒｰﾀ9（右中央）
                .Cols(CMlngvsfListColItem10).TextAlign = TextAlignEnum.RightCenter          'ﾊﾟﾗﾒｰﾀ10（右中央）
                .Cols(CMlngvsfListColItem11).TextAlign = TextAlignEnum.RightCenter          'ﾊﾟﾗﾒｰﾀ11（右中央）
                .Cols(CMlngvsfListColItem12).TextAlign = TextAlignEnum.RightCenter          'ﾊﾟﾗﾒｰﾀ12（右中央）

                .Cols(CMlngvsfListColNo).Width = CMlngvsfListColWNo                         '№
                .Cols(CMlngvsfListColItem1).Width = CMlngvsfListColwItem1                   'ﾊﾟﾗﾒｰﾀ1
                .Cols(CMlngvsfListColItem2).Width = CMlngvsfListColwItem2                   'ﾊﾟﾗﾒｰﾀ2
                .Cols(CMlngvsfListColItem3).Width = CMlngvsfListColwItem3                   'ﾊﾟﾗﾒｰﾀ3
                .Cols(CMlngvsfListColItem4).Width = CMlngvsfListColwItem4                   'ﾊﾟﾗﾒｰﾀ4
                .Cols(CMlngvsfListColItem5).Width = CMlngvsfListColwItem5                   'ﾊﾟﾗﾒｰﾀ5
                .Cols(CMlngvsfListColItem6).Width = CMlngvsfListColwItem6                   'ﾊﾟﾗﾒｰﾀ6
                .Cols(CMlngvsfListColItem7).Width = CMlngvsfListColwItem7                   'ﾊﾟﾗﾒｰﾀ7
                .Cols(CMlngvsfListColItem8).Width = CMlngvsfListColwItem8                   'ﾊﾟﾗﾒｰﾀ8
                'Shot分離
                .Cols(CMlngvsfListColItem9).Width = CMlngvsfListColwItem9                   'ﾊﾟﾗﾒｰﾀ9
                .Cols(CMlngvsfListColItem10).Width = CMlngvsfListColwItem10                 'ﾊﾟﾗﾒｰﾀ10
                .Cols(CMlngvsfListColItem11).Width = CMlngvsfListColwItem11                 'ﾊﾟﾗﾒｰﾀ11
                .Cols(CMlngvsfListColItem12).Width = CMlngvsfListColwItem12                 'ﾊﾟﾗﾒｰﾀ12

                'NSYS 編集時の前景色と背景色を設定
                .Styles.Editor.BackColor = SystemColors.Window
                .Styles.Editor.ForeColor = SystemColors.WindowText
                
                '@直接描画
                .Redraw = True
                
                '@ﾛｯｸ
                .Enabled = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFbDataList_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmdButton_Chk
    '機　能：ﾎﾞﾀﾝの有効/無効制御
    '引　数：なし
    '戻り値：
    '作成日：2017/01/25 (Wed) 11:41:03 T.Oide
    '更新日：2017/01/25 (Wed) 11:41:03
    '備　考：
    Private Sub prvCmdButton_Chk()

        Try
            
            '@閉じる(常に有効)
            cmdClose.Enabled = True
            
            '@設定ｸﾘｱ(常に有効)
            cmdClear.Enabled = True
            
            '@現在地ｺﾋﾟｰ(常に有効)
            cmdCopy.Enabled = True
            
            '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ(常に有効)
            cmdClipCopy.Enabled = True
            
            '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞﾍﾟｰｽﾄ(常に有効)
            cmdClipPaste.Enabled = True
            
            '@確定(編集ﾌﾗｸﾞ1の場合有効)
            If mblnEditFlag = True Then
                cmdRegist.Enabled = True
            Else
                cmdRegist.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdButton_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvblnProcEnd_Chk
    '機　能：確定時の入力ﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2017/01/25 (Wed) 12:40:17 T.Oide
    '更新日：2017/01/25 (Wed) 12:40:17
    '備　考：
    Private Function prvblnProcEnd_Chk() As Boolean

        Dim llngCnt     As Integer  '列ｶｳﾝﾀ
        Dim llngCntRow  As Integer  '行ｶｳﾝﾀ
        
        Try
            
            '@戻り値の初期化
            prvblnProcEnd_Chk = False
            
            With vsfFbDataList
            
                '@------------------------
                '@入力値のﾁｪｯｸ（空白ないこと、数値であること）
                '@------------------------
                '@行方向でﾙｰﾌﾟ
                For llngCntRow = 1 To .Rows.Count - 1
                    '@列方向でﾙｰﾌﾟ
                    For llngCnt = 1 To .Cols.Count - 1
                    
                        '@値が設定未設定の場合
                        If .GetData(llngCntRow, llngCnt) = vbNullString AndAlso .GetData(llngCntRow, llngCnt) <> "0" Then
                        
                            '@"<TRM7QW>$$数値を入力して下さい。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007Q)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@編集可能ｾﾙの場合
                            .Select(llngCntRow, llngCnt)     '編集可能ｾﾙの範囲選択
                            .StartEditing()                  '編集可能にする
                            Exit Function
                        
                        End If
                    
                        '@値が数値でない場合
                        If IsNumeric(.GetData(llngCntRow, llngCnt)) = False Then
                        
                            '@"<TRM7QW>$$数値を入力して下さい。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007Q)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@編集可能ｾﾙの場合
                            .Select(llngCntRow, llngCnt)     '編集可能ｾﾙの範囲選択
                            .StartEditing()                  '編集可能にする
                            Exit Function
                            
                        End If
                    Next
                Next
                
                '@ﾁｪｯｸOK
                prvblnProcEnd_Chk = True
            
            End With
                    
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnProcEnd_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvPhotoFbDataChgReq_set
    '機　能：ptypPhotoFbDataChgReqに登録ﾃﾞｰﾀをｾｯﾄする
    '引　数：なし
    '戻り値：
    '作成日：2017/01/25 (Wed) 14:58:55 T.Oide
    '更新日：2017/01/25 (Wed) 14:58:55
    '備　考：
    Private Sub prvPhotoFbDataChgReq_set()

        Dim llngCnt                 As Integer

        Dim lstrTmpShiftXDigit      As String   'ﾊﾟﾗﾒｰﾀ1のﾌｫｰﾏｯﾄ文字列
        Dim lstrTmpShiftYDigit      As String   'ﾊﾟﾗﾒｰﾀ2のﾌｫｰﾏｯﾄ文字列
        Dim lstrTmpWaferMagXDigit   As String   'ﾊﾟﾗﾒｰﾀ3のﾌｫｰﾏｯﾄ文字列
        Dim lstrTmpWaferMagYDigit   As String   'ﾊﾟﾗﾒｰﾀ4のﾌｫｰﾏｯﾄ文字列
        Dim lstrTmpWaferRotXDigit   As String   'ﾊﾟﾗﾒｰﾀ5のﾌｫｰﾏｯﾄ文字列
        Dim lstrTmpWaferRotYDigit   As String   'ﾊﾟﾗﾒｰﾀ6のﾌｫｰﾏｯﾄ文字列
        Dim lstrTmpShotRotDigit     As String   'ﾊﾟﾗﾒｰﾀ7のﾌｫｰﾏｯﾄ文字列
        Dim lstrTmpShotMagDigit     As String   'ﾊﾟﾗﾒｰﾀ8のﾌｫｰﾏｯﾄ文字列
        Dim lstrTmpShotRotXDigit    As String   'ﾊﾟﾗﾒｰﾀ7のﾌｫｰﾏｯﾄ文字列
        Dim lstrTmpShotRotYDigit    As String   'ﾊﾟﾗﾒｰﾀ7のﾌｫｰﾏｯﾄ文字列
        Dim lstrTmpShotMagXDigit    As String   'ﾊﾟﾗﾒｰﾀ8のﾌｫｰﾏｯﾄ文字列
        Dim lstrTmpShotMagYDigit    As String   'ﾊﾟﾗﾒｰﾀ8のﾌｫｰﾏｯﾄ文字列

        Dim lstrTmpShiftX           As String
        Dim lstrTmpShiftY           As String
        Dim lstrTmpWaferMagX        As String
        Dim lstrTmpWaferMagY        As String
        Dim lstrTmpWaferRotX        As String
        Dim lstrTmpWaferRotY        As String
        Dim lstrTmpShotRot          As String
        Dim lstrTmpShotMag          As String
        Dim lstrTmpShotRotX         As String
        Dim lstrTmpShotRotY         As String
        Dim lstrTmpShotMagX         As String
        Dim lstrTmpShotMagY         As String

        Try
            
            '@更新内容の設定
            With ptypPhotoFbDataChgReq
            
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstreq__photofbdatachgVer
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                .strSbID = pstrSBID
                
                '@ﾌｫﾄ号機
                frmxxEN01U0.Instance.cmbWp.ValueCol = CMlngCmbGridCol1
                .strWpID = frmxxEN01U0.Instance.cmbWp.Value
                
                '@ﾚｼﾋﾟID
                .strRecipeId = frmxxEN01U0.Instance.txtRecipeID.Text
                
                '@1stﾌｫﾄ号機
                frmxxEN01U0.Instance.cmbReferenceWP.ValueCol = CMlngCmbGridCol1
                .strReferencePhotoWpID = frmxxEN01U0.Instance.cmbReferenceWP.Value
                
                '@ﾊﾟｯﾁ分割数
                .lngPatchDivideNum = vsfFbDataList.Rows.Count - 1
                
                '@各ﾊﾟﾗﾒｰﾀのﾌｫｰﾏｯﾄ文字列取得
                lstrTmpShiftXDigit = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShiftXValidDigit)
                lstrTmpShiftYDigit = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShiftYValidDigit)
                lstrTmpWaferMagXDigit = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferMagXValidDigit)
                lstrTmpWaferMagYDigit = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferMagYValidDigit)
                lstrTmpWaferRotXDigit = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferRotXValidDigit)
                lstrTmpWaferRotYDigit = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strWaferRotYValidDigit)
                lstrTmpShotRotDigit = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotValidDigit)
                lstrTmpShotMagDigit = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagValidDigit)
                'Shot分離
                lstrTmpShotRotXDigit = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotXValidDigit)
                lstrTmpShotRotYDigit = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotRotYValidDigit)
                lstrTmpShotMagXDigit = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagXValidDigit)
                lstrTmpShotMagYDigit = pubStrFormatValue_Set(ptypPhotoFbDataListAns.strShotMagYValidDigit)

                '@ patch1~Nまでの値を構造体に設定
                For llngCnt = 1 To .lngPatchDivideNum
                
                    lstrTmpShiftX = CDbl(Format$(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem1), lstrTmpShiftXDigit))
                    lstrTmpShiftY = CDbl(Format$(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem2), lstrTmpShiftYDigit))
                    lstrTmpWaferMagX = CDbl(Format$(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem3), lstrTmpWaferMagXDigit))
                    lstrTmpWaferMagY = CDbl(Format$(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem4), lstrTmpWaferMagYDigit))
                    lstrTmpWaferRotX = CDbl(Format$(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem5), lstrTmpWaferRotXDigit))
                    lstrTmpWaferRotY = CDbl(Format$(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem6), lstrTmpWaferRotYDigit))
                    lstrTmpShotRot = CDbl(Format$(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem7), lstrTmpShotRotDigit))
                    lstrTmpShotMag = CDbl(Format$(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem8), lstrTmpShotMagDigit))
                    'Shot分離
                    lstrTmpShotRotX = CDbl(Format$(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem9), lstrTmpShotRotXDigit))
                    lstrTmpShotRotY = CDbl(Format$(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem10), lstrTmpShotRotYDigit))
                    lstrTmpShotMagX = CDbl(Format$(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem11), lstrTmpShotMagXDigit))
                    lstrTmpShotMagY = CDbl(Format$(vsfFbDataList.GetData(llngCnt, CMlngvsfListColItem12), lstrTmpShotMagYDigit))
                
                    '@ﾙｰﾌﾟｶｳﾝﾄで分岐
                    Select Case llngCnt
                        
                        Case CPlngPatchNo1
                            .strShiftX = lstrTmpShiftX
                            .strShiftY = lstrTmpShiftY
                            .strWaferMagX = lstrTmpWaferMagX
                            .strWaferMagY = lstrTmpWaferMagY
                            .strWaferRotX = lstrTmpWaferRotX
                            .strWaferRotY = lstrTmpWaferRotY
                            .strShotRot = lstrTmpShotRot
                            .strShotMag = lstrTmpShotMag
                            'Shot分離                          
                            .strShotRotX = lstrTmpShotRotX
                            .strShotRotY = lstrTmpShotRotY
                            .strShotMagX = lstrTmpShotMagX
                            .strShotMagY = lstrTmpShotMagY
                            
                        Case CPlngPatchNo2
                            .strShiftX_2 = lstrTmpShiftX
                            .strShiftY_2 = lstrTmpShiftY
                            .strWaferMagX_2 = lstrTmpWaferMagX
                            .strWaferMagY_2 = lstrTmpWaferMagY
                            .strWaferRotX_2 = lstrTmpWaferRotX
                            .strWaferRotY_2 = lstrTmpWaferRotY
                            .strShotRot_2 = lstrTmpShotRot
                            .strShotMag_2 = lstrTmpShotMag
                            'Shot分離                          
                            .strShotRotX_2 = lstrTmpShotRotX
                            .strShotRotY_2 = lstrTmpShotRotY
                            .strShotMagX_2 = lstrTmpShotMagX
                            .strShotMagY_2 = lstrTmpShotMagY
                            
                        Case CPlngPatchNo3
                            .strShiftX_3 = lstrTmpShiftX
                            .strShiftY_3 = lstrTmpShiftY
                            .strWaferMagX_3 = lstrTmpWaferMagX
                            .strWaferMagY_3 = lstrTmpWaferMagY
                            .strWaferRotX_3 = lstrTmpWaferRotX
                            .strWaferRotY_3 = lstrTmpWaferRotY
                            .strShotRot_3 = lstrTmpShotRot
                            .strShotMag_3 = lstrTmpShotMag
                            'Shot分離                          
                            .strShotRotX_3 = lstrTmpShotRotX
                            .strShotRotY_3 = lstrTmpShotRotY
                            .strShotMagX_3 = lstrTmpShotMagX
                            .strShotMagY_3 = lstrTmpShotMagY

                        Case CPlngPatchNo4
                            .strShiftX_4 = lstrTmpShiftX
                            .strShiftY_4 = lstrTmpShiftY
                            .strWaferMagX_4 = lstrTmpWaferMagX
                            .strWaferMagY_4 = lstrTmpWaferMagY
                            .strWaferRotX_4 = lstrTmpWaferRotX
                            .strWaferRotY_4 = lstrTmpWaferRotY
                            .strShotRot_4 = lstrTmpShotRot
                            .strShotMag_4 = lstrTmpShotMag
                            'Shot分離                          
                            .strShotRotX_4 = lstrTmpShotRotX
                            .strShotRotY_4 = lstrTmpShotRotY
                            .strShotMagX_4 = lstrTmpShotMagX
                            .strShotMagY_4 = lstrTmpShotMagY
                            
                        Case CPlngPatchNo5
                            .strShiftX_5 = lstrTmpShiftX
                            .strShiftY_5 = lstrTmpShiftY
                            .strWaferMagX_5 = lstrTmpWaferMagX
                            .strWaferMagY_5 = lstrTmpWaferMagY
                            .strWaferRotX_5 = lstrTmpWaferRotX
                            .strWaferRotY_5 = lstrTmpWaferRotY
                            .strShotRot_5 = lstrTmpShotRot
                            .strShotMag_5 = lstrTmpShotMag
                            'Shot分離                          
                            .strShotRotX_5 = lstrTmpShotRotX
                            .strShotRotY_5 = lstrTmpShotRotY
                            .strShotMagX_5 = lstrTmpShotMagX
                            .strShotMagY_5 = lstrTmpShotMagY
                            
                        Case CPlngPatchNo6
                            .strShiftX_6 = lstrTmpShiftX
                            .strShiftY_6 = lstrTmpShiftY
                            .strWaferMagX_6 = lstrTmpWaferMagX
                            .strWaferMagY_6 = lstrTmpWaferMagY
                            .strWaferRotX_6 = lstrTmpWaferRotX
                            .strWaferRotY_6 = lstrTmpWaferRotY
                            .strShotRot_6 = lstrTmpShotRot
                            .strShotMag_6 = lstrTmpShotMag
                            'Shot分離                          
                            .strShotRotX_6 = lstrTmpShotRotX
                            .strShotRotY_6 = lstrTmpShotRotY
                            .strShotMagX_6 = lstrTmpShotMagX
                            .strShotMagY_6 = lstrTmpShotMagY
                            
                        Case CPlngPatchNo7
                            .strShiftX_7 = lstrTmpShiftX
                            .strShiftY_7 = lstrTmpShiftY
                            .strWaferMagX_7 = lstrTmpWaferMagX
                            .strWaferMagY_7 = lstrTmpWaferMagY
                            .strWaferRotX_7 = lstrTmpWaferRotX
                            .strWaferRotY_7 = lstrTmpWaferRotY
                            .strShotRot_7 = lstrTmpShotRot
                            .strShotMag_7 = lstrTmpShotMag
                            'Shot分離                          
                            .strShotRotX_7 = lstrTmpShotRotX
                            .strShotRotY_7 = lstrTmpShotRotY
                            .strShotMagX_7 = lstrTmpShotMagX
                            .strShotMagY_7 = lstrTmpShotMagY
                            
                        Case CPlngPatchNo8
                            .strShiftX_8 = lstrTmpShiftX
                            .strShiftY_8 = lstrTmpShiftY
                            .strWaferMagX_8 = lstrTmpWaferMagX
                            .strWaferMagY_8 = lstrTmpWaferMagY
                            .strWaferRotX_8 = lstrTmpWaferRotX
                            .strWaferRotY_8 = lstrTmpWaferRotY
                            .strShotRot_8 = lstrTmpShotRot
                            .strShotMag_8 = lstrTmpShotMag
                            'Shot分離                          
                            .strShotRotX_8 = lstrTmpShotRotX
                            .strShotRotY_8 = lstrTmpShotRotY
                            .strShotMagX_8 = lstrTmpShotMagX
                            .strShotMagY_8 = lstrTmpShotMagY
                            
                        Case CPlngPatchNo9
                            .strShiftX_9 = lstrTmpShiftX
                            .strShiftY_9 = lstrTmpShiftY
                            .strWaferMagX_9 = lstrTmpWaferMagX
                            .strWaferMagY_9 = lstrTmpWaferMagY
                            .strWaferRotX_9 = lstrTmpWaferRotX
                            .strWaferRotY_9 = lstrTmpWaferRotY
                            .strShotRot_9 = lstrTmpShotRot
                            .strShotMag_9 = lstrTmpShotMag
                            'Shot分離                          
                            .strShotRotX_9 = lstrTmpShotRotX
                            .strShotRotY_9 = lstrTmpShotRotY
                            .strShotMagX_9 = lstrTmpShotMagX
                            .strShotMagY_9 = lstrTmpShotMagY
                    End Select
                    
                Next

                '@作業者ID
                .strEmpID = pstrUserID

                '@ｺﾒﾝﾄ
                .strComments = txtComments.Text

                '@最新ﾃﾞｰﾀ更新日時
                If lblEditTime.Text = vbNullString Then
                    '@新規ﾃﾞｰﾀとして登録
                    .strEntryTime = vbNullString
                Else
                    '@既存ﾃﾞｰﾀの排他用の時刻として渡す
                    .strEntryTime = ptypPhotoFbDataListAns.typFbDataItemList(0).strEntryTime
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvPhotoFbDataChgReq_set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvClipCheck
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞのﾃﾞｰﾀﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2017/01/26 (Thu) 14:42:54 T.Oide
    '更新日：2017/01/26 (Thu) 14:42:54
    '備　考：
    Private Function prvClipCheck(ByRef lstrDataLine() As String) As Boolean

        Dim llngRowCnt              As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngColCnt              As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrDataelement()       As String       '1ﾃﾞｰﾀ
        
        Try

            '@結果初期化
            prvClipCheck = False

            With vsfFbDataList
            
                'ﾃﾞｰﾀの貼付数確認
                If .Rows.Count - 1 <> UBound(lstrDataLine) Then
                    '@ﾊﾟｯﾁ数が正しくありません表示
            
                    '@"<TRM143W>$$設定patch数が異なっています。$ｸﾘｯﾌﾟﾎﾞｰﾄﾞのﾃﾞｰﾀを再確認してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0143)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Function
                End If
            
                'ﾃﾞｰﾀの型確認
                For llngRowCnt = 0 To UBound(lstrDataLine) - 1
                    
                    '@1つのﾃﾞｰﾀを取得(element(0)～(7)に各ﾊﾟﾗﾒｰﾀの値が入っている状態)
                    lstrDataelement = Split(lstrDataLine(llngRowCnt), vbTab)
                    
                    '@ﾊﾟﾗﾒｰﾀは8個か
                    If UBound(lstrDataelement) + 1 = CMlngParameterNum Then
                    
                        '@ﾃﾞｰﾀの型ﾁｪｯｸ
                        For llngColCnt = 0 To CMlngParameterNum - 1
                        
                            '@数値以外か
                            If IsNumeric(lstrDataelement(llngColCnt)) = False Then
                                '@数値ﾃﾞｰﾀではありません表示
                                
                                '@"<TRM145W>$$patch[%1]のﾊﾟﾗﾒｰﾀ[%2]に数値以外の値が設定されています。$ｸﾘｯﾌﾟﾎﾞｰﾄﾞのﾃﾞｰﾀを再確認してください。"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0145, llngRowCnt + 1, llngColCnt + 1)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                Exit Function
                                
                            End If
                        Next
                    Else
                        '@ﾊﾟﾗﾒｰﾀ数が正しくありません表示
                        
                        '@"<TRM144W>$$patch[%1]のﾊﾟﾗﾒｰﾀ数が正しくありません。$ｸﾘｯﾌﾟﾎﾞｰﾄﾞのﾃﾞｰﾀを再確認してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0144, llngRowCnt + 1)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Exit Function
                    End If

                Next
                
            End With

            '@結果格納
            prvClipCheck = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvClipCheck"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvEditCheck
    '機　能：編集中ﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2017/01/26 (Thu) 16:06:16 T.Oide
    '更新日：2017/01/26 (Thu) 16:06:16
    '備　考：
    Private Function prvEditCheck() As Boolean
        
        Dim llngAns     As Integer
        
        Try

            '@結果の初期化
            prvEditCheck = False

            '@編集中の場合ﾒｯｾｰｼﾞを表示
            If mblnEditFlag = True Then
                
                '@"<TRM1AW>$$編集中です。 内容を破棄してよろしいですか？"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, frmxxEN00M0.Instance.Text, True, 16)
                
                '@ﾒｯｾｰｼﾞBoxにて「いいえ」が選択されたか
                If llngAns = vbNo Then
                    Exit Function
                End If
                
            End If

            '@結果OK
            prvEditCheck = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvEditCheck"
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


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfFbDataList.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True
            
        End If

    End Sub


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfFbDataList.KeyDownEdit

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

    
    '関数名：vsfFbDataList_BeforeScroll
    '機　能：グリッドスクロール前処理
    '引　数：sender：イベント発生元
    '　　　：e     ：Rangeイベントオブジェクト
    '戻り値：なし
    '作成日：2020/07/03 (Fri) 16:30:00 NSYS
    '更新日：
    '備　考：

    Private Sub vsfFbDataList_BeforeScroll(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfFbDataList.BeforeScroll

        e.Cancel = True

    End Sub
    
End Class
