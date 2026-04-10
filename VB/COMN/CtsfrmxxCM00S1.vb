'ﾌｧｲﾙ名：xxCM00S1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：宛先検索
'作成日：2005/04/28 (Thu) 11:07:59 N.Kasai
'更新日：2005/04/28 (Thu) 11:07:59
'備　考：
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00S1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00S1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00S1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00S1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00S1)
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
    Private Const CMstrLocalVersion                 As String = "01.00"         '機能ﾊﾞｰｼﾞｮﾝ

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM00S1  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmasdeptemplistVer            As String = "01.01"         '社員名取得

    '@vsfDeptListの定数宣言（ｶﾗﾑ）
    Private Const CMvsfDeptColIndex                 As Integer = 0              'INDEX
    Private Const CMvsfDeptColDeptName              As Integer = 1              '所属名
    Private Const CMvsfDeptColDeptCode              As Integer = 2              '所属ｺｰﾄﾞ

    '@vsfDeptListの定数宣言（表示幅）
    Private Const CMvsfDeptColWIndex                As Integer = 33             'INDEX
    Private Const CMvsfDeptColWDeptName             As Integer = 200            '所属名
    Private Const CMvsfDeptColWDeptCode             As Integer = 67             '所属ｺｰﾄﾞ

    '@vsfDeptListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMvsfDeptColTIndex                As String = "INDEX"         'INDEX
    Private Const CMvsfDeptColTDeptName             As String = "所属"          '所属名
    Private Const CMvsfDeptColTDeptCode             As String = "所属ｺｰﾄﾞ"      '所属ｺｰﾄﾞ

    '@vsfEmpListの定数宣言（ｶﾗﾑ）
    Private Const CMvsfEmpColIndex                  As Integer = 0              'INDEX
    Private Const CMvsfEmpColChk                    As Integer = 1              'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMvsfEmpColEmpID                  As Integer = 2              'ﾕｰｻﾞID
    Private Const CMvsfEmpColEmpName                As Integer = 3              'ﾕｰｻﾞ名
    Private Const CMvsfEmpColMail                   As Integer = 4              'ﾒﾙｱﾄﾞ

    '@vsfEmpListの定数宣言（表示幅）
    Private Const CMvsfEmpColWIndex                 As Integer = 33             'INDEX
    Private Const CMvsfEmpColWChk                   As Integer = 23             'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMvsfEmpColWEmpID                 As Integer = 100            'ﾕｰｻﾞID
    Private Const CMvsfEmpColWEmpName               As Integer = 160            'ﾕｰｻﾞ名
    Private Const CMvsfEmpColWMail                  As Integer = 133            'ﾒﾙｱﾄﾞ

    '@vsfEmpListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMvsfEmpColTIndex                 As String = "INDEX"         'INDEX
    Private Const CMvsfEmpColTChk                   As String = ""              'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMvsfEmpColTEmpID                 As String = "ID"            'ﾕｰｻﾞID
    Private Const CMvsfEmpColTEmpName               As String = "ユーザ名"      'ﾕｰｻﾞ名
    Private Const CMvsfEmpColTMail                  As String = "メールアドレス" 'ﾒﾙｱﾄﾞ

    '@vsfMailListの定数宣言（ｶﾗﾑ）
    Private Const CMvsfMailColEmpName               As Integer = 0              'ﾕｰｻﾞ名
    Private Const CMvsfMailColMail                  As Integer = 1              'ﾒﾙｱﾄﾞ
    Private Const CMvsfMailColEmpID                 As Integer = 2              'ﾕｰｻﾞID

    '@vsfMailListの定数宣言（表示幅）
    Private Const CMvsfMailColWEmpName              As Integer = 1000           'ﾕｰｻﾞ名
    Private Const CMvsfMailColWMail                 As Integer = 1000           'ﾒﾙｱﾄﾞ
    Private Const CMvsfMailColWEmpID                As Integer = 1000           'ﾕｰｻﾞID

    '@vsfMailListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMvsfMailColTEmpName              As String = "ﾕｰｻﾞ"          'ﾕｰｻﾞ名
    Private Const CMvsfMailColTMail                 As String = "ﾒﾙｱﾄﾞ"         'ﾒﾙｱﾄﾞ
    Private Const CMvsfMailColTEmpID                As String = "ﾕｰｻﾞID"        'ﾕｰｻﾞID

    '@その他ｸﾞﾘｯﾄの定数
    Private Const CMvsfDeptListCol                  As Integer = 3              'ｶﾗﾑ数
    Private Const CMvsfEmpListCol                   As Integer = 5              'ｶﾗﾑ数
    Private Const CMvsfMailListCol                  As Integer = 3              'ｶﾗﾑ数

    Private Const CMlngvsfDeptPageRows              As Integer = 12             'ﾍﾟｰｼﾞRows
    Private Const CMlngvsfEmpPageRows               As Integer = 12             'ﾍﾟｰｼﾞRows

    Private Const CMvsfTRow                         As Integer = 0              'ﾀｲﾄﾙ行
    Private Const CMlngvsfFrozenCols                As Integer = 0              '固定列
    Private Const CMvsfHFontSize                    As Integer = 12             'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMvsfHdHeight                     As Integer = 27             '行の高さ（ﾍｯﾀﾞｰのみ）
    Private Const CMvsfRowHeight                    As Integer = 43             '行の高さ

    '@ﾚｽﾎﾟﾝｽ用定数
    Private Const CMstrFormName                     As String = "frmxxCM00S1"           '自ﾌｫｰﾑ名
    Private Const CMstrDeptListEnterCell            As String = "vsfDeptList_EnterCell" 'ｲﾍﾞﾝﾄ名称（ﾌｫｰﾑﾛｰﾄﾞ）

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================

    Private mtypChgSort1                            As ChgSort                  'ｿｰﾄ保持用(DeptList)
    Private mtypChgSort2                            As ChgSort                  'ｿｰﾄ保持用(EmpList)

    Private buttonProcessing                        As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                  'NSYS WindowCloseフラグ

    Private ReadOnly flexRDNone                     As Boolean = False          'NSYS ReDraw用
    Private ReadOnly flexRDDirect                   As Boolean = True           'NSYS ReDraw用

    Private ReadOnly vbWhite                        As Color = Color.White      'NSYS vbWhite定義
    Private ReadOnly vbYellow                       As Color = Color.Yellow     'NSYS vbYellow定義

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
        pubVsfMouseWheelManager_Set(vsfDeptList, cmdDeptUp, cmdDeptDown)
        pubVsfMouseWheelManager_Set(vsfEmpList, cmdEmpUp, cmdEmpDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/28 (Thu) 11:32:22 N.Kasai
    '更新日：2005/04/28 (Thu) 11:32:22
    '備　考：
    Private Sub Form_Load()

        Try

            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfDeptList_init()
            Call prvvsfEmpList_init()
            Call prvvsfMailList_init()

            '@構造体よりDept、Mail取得
            Call prvvsfDeptList_Disp()
            Call prvvsfMailList_Disp()
            
            '@構造体の初期化(dept)
            With mtypChgSort1
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@構造体の初期化(emp)
            With mtypChgSort2
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList  = New List(Of ChgSortList)
                
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With

            'NSYS ﾌｫｰﾑ左上表示
            With Me
                StartPosition = FormStartPosition.Manual 
                .Left = -My.Settings.FormOffset
                .Top = 0
            End With
            
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

    '関数名：Form_KeyDown
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 16:32:05 N.Kasai
    '更新日：2005/05/09 (Mon) 16:32:05
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            Select Case ActiveControl.Name
                '@DEPTｸﾞﾘｯﾄﾞ
                Case vsfDeptList.Name
                    '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfDeptList, cmdDeptUp, cmdDeptDown)
                    
                '@EMPｸﾞﾘｯﾄﾞ
                Case vsfEmpList.Name
                    '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfEmpList, cmdEmpUp, cmdEmpDown)
                    
                    '@Enterｷｰの場合
                    Select Case e.KeyCode
                        '@ｽﾍﾟｰｽｷｰを押下された場合はｸﾘｯｸと同様の動作
                        Case Keys.Space
                            '@EMPｸﾞﾘｯﾄﾞｸﾘｯｸ処理
                            Call vsfEmpList_Click(vsfEmpList, New EventArgs)
                    End Select
            End Select
            
            '@Enterｷｰの場合
            Select Case e.KeyCode
                Case Keys.Return
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
    '機　能：画面終了
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：終了方法
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 16:31:30 N.Kasai
    '更新日：2005/05/09 (Mon) 16:31:30
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKeyを受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            mtypChgSort1.typChgSortList = New List(Of ChgSortList)
            mtypChgSort2.typChgSortList = New List(Of ChgSortList)

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
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 15:58:57 N.Kasai
    '更新日：2005/05/09 (Mon) 15:58:57
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

            '@ﾌｫｰﾑを閉じる
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

    '関数名：cmdChoice_Click
    '機　能：選択確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 15:59:30 N.Kasai
    '更新日：2005/05/09 (Mon) 15:59:30
    '備　考：
    '　　　：2005/09/21 (Wed) 16:11:20 S.Deguchi    ﾕｰｻﾞｰID格納処理を追加
    Private Sub cmdChoice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChoice.Click

        Dim llngCnt     As Integer  '汎用ｶｸﾝﾀ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfMailList
                '@件数0件の場合は処理なし
                If .Rows.Count = .Rows.Fixed Then
                    Exit Sub
                End If
                
                '@宛先人件数格納
                ptypSendMailList.lngSendMailCnt = .Rows.Count - 1
                
                '@領域の確保
                ptypSendMailList.typSendMail = New List(Of SendMail)
                Dim typSendMailTmp As SendMail = New SendMail

                '@宛先人の格納
                For llngCnt = 1 To .Rows.Count - 1
                    typSendMailTmp.strMail1 _
                        = .GetData(llngCnt, CMvsfMailColMail)              '宛先人ﾒｰﾙｱﾄﾞﾚｽ
                        
        '@↓2005/09/21 (Wed) 16:12:45 S.Deguchi **************************************************
                    typSendMailTmp.strId _
                        = .GetData(llngCnt, CMvsfMailColEmpID)             '宛先人ID
        '@↑2005/09/21 (Wed) 16:12:45 S.Deguchi **************************************************
                    
                    typSendMailTmp.strName _
                        = .GetData(llngCnt, CMvsfMailColEmpName)           '宛先人名称


                    ptypSendMailList.typSendMail.Add(typSendMailTmp)
                Next llngCnt
            End With
            
            '@ﾌｫｰﾑを閉じる
            Call cmdClose_Click(cmdClose, New EventArgs)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdChoice_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfDeptList_AfterSort
    '機　能：ソート後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 16:36:24 N.Kasai
    '更新日：2005/05/09 (Mon) 16:36:24
    '備　考：
    Private Sub vsfDeptList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfDeptList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfDeptList.Rows.Count <= vsfDeptList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort1

                Dim ltypChgSortListTmp As ChgSortList = New ChgSortList

                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1

                '@ｿｰﾄ列番号を格納
                ltypChgSortListTmp.lngCol = e.Col
                
                '@並び替え方法を格納（昇順/降順）
                ltypChgSortListTmp.lngOrder = e.Order

                .typChgSortList.Add(ltypChgSortListTmp)

            End With

            'NSYS VB6版と動作を合わせるために抑制した処理を有効にする。
            AddHandler vsfDeptList.BeforeRowColChange, AddressOf vsfDeptList_BeforeRowColChange
            AddHandler vsfDeptList.EnterCell, AddressOf vsfDeptList_EnterCell

            '@ｶﾚﾝﾄ行の設定（ｸﾞﾘｯﾄﾞ、保持列 [ INDEX]、前頁、次頁 ）
            Call pubVsfAfterSort(vsfDeptList, CMvsfDeptColIndex, cmdDeptUp, cmdDeptDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfDeptList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfDeptList_BeforeSort
    '機　能：ソート前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 16:36:06 N.Kasai
    '更新日：2005/05/09 (Mon) 16:36:06
    '備　考：
    Private Sub vsfDeptList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfDeptList.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfDeptList.Rows.Count <= vsfDeptList.Rows.Fixed Then
                Return
            End If

            'NSYS VB6版と動作を合わせるために処理を抑制する。
            RemoveHandler vsfDeptList.BeforeRowColChange, AddressOf vsfDeptList_BeforeRowColChange
            RemoveHandler vsfDeptList.EnterCell, AddressOf vsfDeptList_EnterCell

            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 [INDEX ] ）
            Call pubVsfBeforeSort(vsfDeptList, CMvsfDeptColIndex)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfDeptList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfDeptList_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞのﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 16:34:08 N.Kasai
    '更新日：2005/05/09 (Mon) 16:34:08
    '備　考：
    Private Sub vsfDeptList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfDeptList.BeforeRowColChange

        Dim OldRow              As Integer          'NSYS 
        Dim NewRow              As Integer          'NSYS 

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfDeptList.Rows.Count <= vsfDeptList.Rows.Fixed Then
                Return
            End If

            '選択値を設定
            OldRow = e.OldRange.r1
            NewRow = e.NewRange.r1

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If OldRow <> NewRow And NewRow > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（INDEX）
                mtypChgSort1.strKey = vsfDeptList.GetData(NewRow, CMvsfDeptColIndex)
                
                '@構造体の初期化(emp)
                With mtypChgSort2
                    '@ｿｰﾄ保持構造体初期化
                    .lngCnt = 0
                    If .typChgSortList Is Nothing Then
                        .typChgSortList = New List(Of ChgSortList)
                    Else
                        .typChgSortList.Clear
                    End If
                    
                    '@列幅変更ﾌﾗｸﾞ（未変更）
                    .blnChgWidth = False
                    
                    '@ｶﾚﾝﾄ行検索ｷｰを初期化
                    .strKey = vbNullString
                End With
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfDeptList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfDeptList_EnterCell
    '機　能：所属ｸﾞﾘｯﾄﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/07 (Sat) 15:03:39 N.Kasai
    '更新日：2005/05/07 (Sat) 15:03:39
    '備　考：
    Private Sub vsfDeptList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfDeptList.EnterCell

        Dim lblnAns         As Boolean      '戻り値
        Dim lstrDeptID      As String       '所属ｺｰﾄﾞ
        Dim llngIndex       As Integer      '所属ｺｰﾄﾞ退避（index値）
        Dim llngCnt         As Integer      '汎用ｶｳﾝﾄ

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfDeptList.Rows.Count <= vsfDeptList.Rows.Fixed Then
                Return
            End If
            
            With vsfDeptList
                '@DEPTｸﾞﾘｯﾄﾞ0件の場合
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If
                
                '@index取得
                llngIndex = CLng(.GetData(.Row, CMvsfDeptColIndex)) -1
                
                '@所属ｺｰﾄﾞ取得
                lstrDeptID = .GetData(.Row, CMvsfDeptColDeptCode)

                '@構造体のｶｳﾝﾄを判定して件数がある場合は取得済みと判断し再読み込みはしない
                If ptypDepartmentList.typDepartmentList(llngIndex).typDeptEmpInfo.lngDeptEmpListCnt = 0 Then
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrDeptListEnterCell)
                    
                    '@作業者名取得
                    lblnAns = pubblnMasDeptEmpList_Sel(CMstrmasdeptemplistVer, lstrDeptID, ptypDeptEmpList)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrDeptListEnterCell)
                        Exit Sub
                    End If
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrDeptListEnterCell)
                    
                    '@取得件数がある場合は構造体に格納
                    If ptypDeptEmpList.lngDeptEmpListCnt -1 >= 0 Then

                        '@領域を確保
                        Dim typDepartmentListTmp As DepartmentList = ptypDepartmentList.typDepartmentList(llngIndex)
                        typDepartmentListTmp.typDeptEmpInfo.typDeptEmpList = New List(Of DeptEmpList)

                        Dim typDeptEmpListTmp As DeptEmpList = New DeptEmpList
                        
                        '@件数を格納
                        typDepartmentListTmp.typDeptEmpInfo.lngDeptEmpListCnt = ptypDeptEmpList.lngDeptEmpListCnt
                        
                        '@EMPﾘｽﾄを格納
                        For llngCnt = 0 To ptypDeptEmpList.lngDeptEmpListCnt -1
                            typDeptEmpListTmp.strEmpID _
                                = ptypDeptEmpList.typDeptEmpList(llngCnt).strEmpID                                      'ﾕｰｻﾞID
                                
                            typDeptEmpListTmp.strEmpName _
                                = ptypDeptEmpList.typDeptEmpList(llngCnt).strEmpName                                    'ﾕｰｻﾞ名
                                
                            typDeptEmpListTmp.strMailAddress _
                                = ptypDeptEmpList.typDeptEmpList(llngCnt).strMailAddress                                'ﾒﾙｱﾄﾞ

                            typDepartmentListTmp.typDeptEmpInfo.typDeptEmpList.Add(typDeptEmpListTmp)
                        Next

                        ptypDepartmentList.typDepartmentList(llngIndex) = typDepartmentListTmp

                    End If
                End If
            End With
            
            '@EMPｸﾞﾘｯﾄﾞ表示
            Call prvvsfEmpList_Disp(llngIndex)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfDeptList_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEmpList_AfterSort
    '機　能：ソート後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 18:33:50 N.Kasai
    '更新日：2005/05/09 (Mon) 18:33:50
    '備　考：
    Private Sub vsfEmpList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfEmpList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfEmpList.Rows.Count <= vsfEmpList.Rows.Fixed Then
                Return
            End If
            
            '@ｿｰﾄ順を格納
            With mtypChgSort2

                Dim ltypChgSortListTmp As ChgSortList = New ChgSortList

                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                'ReDim Preserve .typChgSortList(.lngCnt)
                
                '@ｿｰﾄ列番号を格納
                ltypChgSortListTmp.lngCol = e.Col
                
                '@並び替え方法を格納（昇順/降順）
                ltypChgSortListTmp.lngOrder = e.Order

                .typChgSortList.Add(ltypChgSortListTmp)

            End With

            'NSYS VB6版と動作を合わせるために抑制した処理を有効にする。
            AddHandler vsfEmpList.BeforeRowColChange, AddressOf vsfEmpList_BeforeRowColChange

            '@ｶﾚﾝﾄ行の設定（ｸﾞﾘｯﾄﾞ、保持列 [ INDEX]、前頁、次頁 ）
            Call pubVsfAfterSort(vsfEmpList, CMvsfEmpColIndex, cmdEmpUp, cmdEmpDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEmpList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEmpList_BeforeSort
    '機　能：ソート前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 16:36:06 N.Kasai
    '更新日：2005/05/09 (Mon) 16:36:06
    '備　考：
    Private Sub vsfEmpList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfEmpList.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfEmpList.Rows.Count <= vsfEmpList.Rows.Fixed Then
                Return
            End If

            'NSYS VB6版と動作を合わせるために処理を抑制する。
            RemoveHandler vsfEmpList.BeforeRowColChange, AddressOf vsfEmpList_BeforeRowColChange

            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 [INDEX ] ）
            Call pubVsfBeforeSort(vsfEmpList, CMvsfEmpColIndex)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEmpList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEmpList_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞのﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 16:34:08 N.Kasai
    '更新日：2005/05/09 (Mon) 16:34:08
    '備　考：
    Private Sub vsfEmpList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfEmpList.BeforeRowColChange
        
        Dim OldRow              As Integer          'NSYS 
        Dim NewRow              As Integer          'NSYS 

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfEmpList.Rows.Count <= vsfEmpList.Rows.Fixed Then
                Return
            End If

            '選択値を設定
            OldRow = e.OldRange.r1
            NewRow = e.NewRange.r1

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If OldRow <> NewRow And NewRow > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（INDEX）
                mtypChgSort2.strKey = vsfEmpList.GetData(NewRow, CMvsfEmpColIndex)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEmpList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEmpList_Click
    '機　能：EMPｸﾞﾘｯﾄﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 18:04:03 N.Kasai
    '更新日：2005/05/09 (Mon) 18:04:03
    '備　考：
    '　　　：2005/09/21 (Wed) 16:27:29 S.Deguchi    ﾕｰｻﾞｰID格納処理を追加
    Private Sub vsfEmpList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfEmpList.Click
        
        
        Dim llngDeptIndex       As Integer      'DEPTｸﾞﾘｯﾄﾞINDEX退避
        Dim llngEmpIndex        As Integer      'EMPｸﾞﾘｯﾄﾞINDEX退避
        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ
        Dim lblnAns             As Boolean      '結果判定

        Dim flexEDKbd           As Boolean = True  'NSYS
        Dim flexEDNone          As Boolean = False 'NSYS

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfEmpList.Rows.Count <= vsfEmpList.Rows.Fixed Then
                Return
            End If
            
            'NSYS ヘッダ行クリック時、処理を抜ける
            If vsfEmpList.MouseRow = 0 Then
                Return
            End If

            With vsfEmpList
                '@ﾀｲﾄﾙ以外
                If .Row > 0 Then
                    '@選択されたｾﾙにﾒﾙｱﾄﾞがある場合
                    If .GetData(.Row, CMvsfEmpColMail) <> vbNullString Then
                        '@ﾁｪｯｸが外れている場合
                        If .GetCellCheck(.Row, CMvsfEmpColChk) = CheckEnum.Unchecked Then
                            '@ﾁｪｯｸなし→ﾁｪｯｸ
                            .AllowEditing = flexEDKbd                                             'ｸﾞﾘｯﾄﾞ編集許可
                            .SetCellCheck(.Row, CMvsfEmpColChk, CheckEnum.Checked)                'ﾁｪｯｸ
                            .AllowEditing = flexEDNone                                            'ｸﾞﾘｯﾄﾞ編集禁止
                            
                            '@ﾁｪｯｸ内容を反映する。
                            llngDeptIndex = CLng(vsfDeptList.GetData(vsfDeptList.Row, CMvsfDeptColIndex))  'INDEX
                            llngEmpIndex = CLng(.GetData(.Row, CMvsfEmpColIndex))                          'INDEX
                            
                            '@初回のみ場合は重複のﾁｪｯｸは行わない。
                            If vsfMailList.Rows.Count > vsfMailList.Rows.Fixed Then
                                '件数ありの場合
                                '@結果初期化
                                lblnAns = False
                                
                                '@重複ﾁｪｯｸ
                                For llngCnt = 1 To vsfMailList.Rows.Count - 1
                                    '@EMP&Mailｸﾞﾘｯﾄﾞを比較（key:ﾒﾙｱﾄﾞ）
                                    If .GetData(.Row, CMvsfEmpColMail) _
                                        = vsfMailList.GetData(llngCnt, CMvsfMailColMail) Then
                                        
                                        '@重複ﾁｪｯｸあり
                                        lblnAns = True
                                        
                                        Exit For
                                    End If
                                Next
                                
                                '@重複なしの場合はMailｸﾞﾘｯﾄﾞに追加
                                If lblnAns = False Then
        '@↓2005/09/21 (Wed) 16:27:12 S.Deguchi **************************************************
                                    '@宛先格納処理（ﾕｰｻﾞ名/ﾒﾙｱﾄﾞ/ﾕｰｻﾞｰID）
                                    vsfMailList.AddItem(.GetData(.Row, CMvsfEmpColEmpName) _
                                                      & vbTab _
                                                      & .GetData(.Row, CMvsfEmpColMail) _
                                                      & vbTab _
                                                      & .GetData(.Row, CMvsfEmpColEmpID))
        '@↑2005/09/21 (Wed) 16:27:12 S.Deguchi **************************************************
                                End If
                            Else
                            '件数なしの場合（初回）
        '@↓2005/09/21 (Wed) 16:28:36 S.Deguchi **************************************************
                                '@宛先格納処理（ﾕｰｻﾞ名/ﾒﾙｱﾄﾞ/ﾕｰｻﾞｰID）
                                    vsfMailList.AddItem(.GetData(.Row, CMvsfEmpColEmpName) _
                                                      & vbTab _
                                                      & .GetData(.Row, CMvsfEmpColMail) _
                                                      & vbTab _
                                                      & .GetData(.Row, CMvsfEmpColEmpID))
        '@↑2005/09/21 (Wed) 16:28:36 S.Deguchi **************************************************
                            End If
                            
                        Else
                            '@ﾁｪｯｸ→ﾁｪｯｸなし
                            .AllowEditing = flexEDKbd                                             'ｸﾞﾘｯﾄﾞ編集許可
                            .SetCellCheck(.Row, CMvsfEmpColChk, CheckEnum.Unchecked)              'ﾁｪｯｸ解除
                            .AllowEditing = flexEDNone                                            'ｸﾞﾘｯﾄﾞ編集禁止
                            
                            
                            '@万が一、同一ﾒﾙｱﾄﾞが存在した場合は重複しているﾁｪｯｸも外す
                            For llngCnt = 1 To .Rows.Count - 1
                                If .GetData(.Row, CMvsfEmpColMail) = .GetData(llngCnt, CMvsfEmpColMail) Then
                                    '@ﾁｪｯｸ→ﾁｪｯｸなし
                                    .AllowEditing = flexEDKbd                                             'ｸﾞﾘｯﾄﾞ編集許可
                                    .SetCellCheck(llngCnt, CMvsfEmpColChk, CheckEnum.Unchecked)           'ﾁｪｯｸ解除
                                    .AllowEditing = flexEDNone                                            'ｸﾞﾘｯﾄﾞ編集禁止
                                End If
                            Next llngCnt
                            
                            '@初回のみ場合は重複のﾁｪｯｸは行わない。
                            If vsfMailList.Rows.Count > vsfMailList.Rows.Fixed Then
                                '@結果初期化
                                lblnAns = False
                                '@重複ﾁｪｯｸ
                                For llngCnt = 1 To vsfMailList.Rows.Count - 1
                                    '@EMP&Mailｸﾞﾘｯﾄﾞを比較（key:ﾒﾙｱﾄﾞ）
                                    If .GetData(.Row, CMvsfEmpColMail) _
                                        = vsfMailList.GetData(llngCnt, CMvsfMailColMail) Then
                                       
                                       '@Mailｸﾞﾘｯﾄﾞ行削除
                                       vsfMailList.Redraw = False  
                                       vsfMailList.RemoveItem(llngCnt)
                                       vsfMailList.Redraw = True
                                       
                                       Exit For
                                    End If
                                Next
                            End If
                        End If
                    End If
                    
                    '@確定ﾎﾞﾀﾝの制御
                    If vsfMailList.Rows.Count > 1 Then
                        cmdChoice.Enabled = True
                    Else
                        cmdChoice.Enabled = False
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEmpList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDeptUp_Click
    '機　能：前ﾍﾟｰｼﾞ(dept)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 15:53:32 N.Kasai
    '更新日：2005/05/09 (Mon)
    '備　考：
    Private Sub cmdDeptUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeptUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdUp(vsfDeptList, cmdDeptUp, cmdDeptDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDeptUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDeptDown_Click
    '機　能：次ﾍﾟｰｼﾞ(dept)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 15:53:46 N.Kasai
    '更新日：2005/05/09 (Mon) 15:53:46
    '備　考：
    Private Sub cmdDeptDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeptDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdDown(vsfDeptList, cmdDeptUp, cmdDeptDown)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDeptDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdEmpDown_Click
    '機　能：次頁（emp)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 15:54:30 N.Kasai
    '更新日：2005/05/09 (Mon) 15:54:30
    '備　考：
    Private Sub cmdEmpDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEmpDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdDown(vsfEmpList, cmdEmpUp, cmdEmpDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdEmpDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdEmpUp_Click
    '機　能：全頁(emp)
    '引　数：なし
    '戻り値：
    '作成日：2005/05/09 (Mon) 15:54:33 N.Kasai
    '更新日：2005/05/09 (Mon) 15:54:33
    '備　考：
    Private Sub cmdEmpUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEmpUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdUp(vsfEmpList, cmdEmpUp, cmdEmpDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdEmpUp_Click"
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

    '関数名：prvvsfDeptList_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/28 (Thu) 11:40:01 N.Kasai
    '更新日：2005/04/28 (Thu) 11:40:01
    '備　考：
    Private Sub prvvsfDeptList_init()

        Dim lNormalStyle As CellStyle 'NSYS スタイル定義
        Dim lFixedStyle As CellStyle 'NSYS スタイル定義

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfDeptList

                'NSYS スタイルを変数に設定
                lNormalStyle = .Styles.Normal 
                lFixedStyle = .Styles.Fixed 

                '@描画なし
                .Redraw = flexRDNone
                
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@列数設定
                .Cols.Count = CMvsfDeptListCol
                
                '@固定列の設定
                .Cols.Frozen = CMlngvsfFrozenCols
                
                '@行列のﾏｳｽでの変更を不可にする
                .AllowResizing = AllowResizingEnum.None
                
                '@ｾﾙ選択の設定
                .SelectionMode = SelectionModeEnum.Row
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号（...）を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.None
                
                '@ﾊｲﾗｲﾄ表示
                .HighLight = HighlightEnum.Always
                
                '@一覧表の表題設定
                lFixedStyle.ForeColor = vbYellow                                     '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)    '背景色
                lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CType(CMvsfHFontSize,Single), lFixedStyle.Font.Style ) 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                
                '@列の調整を不可にする
                '.AutoSizeMode = flexAutoSizeColWidth
                
                '@表示位置設定
                .Cols(CMvsfDeptColIndex).TextAlign = TextAlignEnum.LeftTop            'index
                .Cols(CMvsfDeptColDeptName).TextAlign = TextAlignEnum.LeftTop         '所属名
                .Cols(CMvsfDeptColDeptCode).TextAlign = TextAlignEnum.LeftTop         '所属ｺｰﾄﾞ

                '@列幅設定
                .Cols(CMvsfDeptColIndex).Width = CMvsfDeptColWIndex                   'index
                .Cols(CMvsfDeptColDeptName).Width = CMvsfDeptColWDeptName             '所属名
                .Cols(CMvsfDeptColDeptCode).Width = CMvsfDeptColWDeptCode             '所属ｺｰﾄﾞ
                
                'ﾀｲﾄﾙ設定
                .SetData(CMvsfTRow, CMvsfDeptColIndex, CMvsfDeptColTIndex)            'index
                .SetData(CMvsfTRow, CMvsfDeptColDeptName, CMvsfDeptColTDeptName)      '所属名
                .SetData(CMvsfTRow, CMvsfDeptColDeptCode, CMvsfDeptColTDeptCode)      '所属ｺｰﾄﾞ
                

                '@表示位置の設定
                .Cols(.Rows.Count - 1).TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMvsfTRow).Height = CMvsfHdHeight         '高さ
                
                '@非表示設定
                .Cols(CMvsfDeptColIndex).Visible = False        'index
                .Cols(CMvsfDeptColDeptCode).Visible = False     '所属ｺｰﾄﾞ

                '@直接描画
                .Redraw = flexRDDirect
                
                '@ﾛｯｸ
                .Enabled = False
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝ
                cmdDeptUp.Enabled = False                   'ｽｸﾛｰﾙ上
                cmdDeptDown.Enabled = False                 'ｽｸﾛｰﾙ下
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfDeptList_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfMailList_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化(Mail)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/28 (Thu) 11:40:01 N.Kasai
    '更新日：2005/04/28 (Thu) 11:40:01
    '備　考：
    '　　　：2005/09/21 (Wed) 16:17:48 S.Deguchi    ｶﾗﾑ：ﾕｰｻﾞｰID追加
    Private Sub prvvsfMailList_init()

        Dim lNormalStyle As CellStyle 'NSYS スタイル定義
        Dim lFixedStyle As CellStyle 'NSYS スタイル定義

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfMailList

                'NSYS スタイルを変数に設定
                lNormalStyle = .Styles.Normal 
                lFixedStyle = .Styles.Fixed 

                '@描画なし
                .Redraw = flexRDNone
                
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                '.Clear
                
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@列数設定
                .Cols.Count = CMvsfMailListCol
                
                '@固定列の設定
                .Cols.Frozen = CMlngvsfFrozenCols
                
                '@行列のﾏｳｽでの変更を不可にする
                .AllowResizing = AllowResizingEnum.None
                               
                '@ｾﾙ選択の設定
                .SelectionMode = SelectionModeEnum.Row
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号（...）を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.None
                
                '@ﾊｲﾗｲﾄ表示
                .HighLight = HighlightEnum.Always
                
                '@一覧表の表題設定
                lFixedStyle.ForeColor = vbYellow                                     '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)    '背景色
                lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CType(CMvsfHFontSize,Single), lFixedStyle.Font.Style ) 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                
                '@列の調整を不可にする
                '.AutoSizeMode = flexAutoSizeColWidth
                
                '@表示位置設定
                .Cols(CMvsfMailColEmpName).TextAlign = TextAlignEnum.LeftTop          'ﾕｰｻﾞ名
                .Cols(CMvsfMailColMail).TextAlign = TextAlignEnum.LeftTop             'ﾒﾙｱﾄﾞ
        '@↓2005/09/21 (Wed) 16:21:01 S.Deguchi **************************************************
                .Cols(CMvsfMailColEmpID).TextAlign = TextAlignEnum.LeftTop            'ﾕｰｻﾞID
        '@↑2005/09/21 (Wed) 16:21:01 S.Deguchi **************************************************

                '@列幅設定
                .Cols(CMvsfMailColEmpName).Width = CMvsfMailColWEmpName               'ﾕｰｻﾞ名
                .Cols(CMvsfMailColMail).Width = CMvsfMailColWMail                     'ﾒﾙｱﾄﾞ
        '@↓2005/09/21 (Wed) 16:21:05 S.Deguchi **************************************************
                .Cols(CMvsfMailColEmpID).Width = CMvsfMailColWEmpID                   'ﾕｰｻﾞID
        '@↑2005/09/21 (Wed) 16:21:05 S.Deguchi **************************************************
                
                'ﾀｲﾄﾙ設定
                .SetData(CMvsfTRow, CMvsfMailColEmpName, CMvsfMailColTEmpName)        'ﾕｰｻﾞ名
                .SetData(CMvsfTRow, CMvsfMailColMail, CMvsfMailColTMail)              'ﾒﾙｱﾄﾞ
        '@↓2005/09/21 (Wed) 16:21:08 S.Deguchi **************************************************
                .SetData(CMvsfTRow, CMvsfMailColEmpID, CMvsfMailColTEmpID)            'ﾕｰｻﾞID
        '@↑2005/09/21 (Wed) 16:21:08 S.Deguchi **************************************************

                '@表示位置の設定
                .Cols(.Rows.Count - 1).TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMvsfTRow).Height = CMvsfHdHeight    '高さ

                '@直接描画
                .Redraw = flexRDDirect
                
                '@ﾛｯｸ
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMailList_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfEmpList_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/28 (Thu) 11:40:01 N.Kasai
    '更新日：2005/04/28 (Thu) 11:40:01
    '備　考：
    Private Sub prvvsfEmpList_init()

        Dim lNormalStyle As CellStyle 'NSYS スタイル定義
        Dim lFixedStyle As CellStyle 'NSYS スタイル定義

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfEmpList

                'NSYS スタイルを変数に設定
                lNormalStyle = .Styles.Normal 
                lFixedStyle = .Styles.Fixed 

                '@描画なし
                .Redraw = flexRDNone
                
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@列数設定
                .Cols.Count = CMvsfEmpListCol
                
                '@固定列の設定
                .Cols.Frozen = CMlngvsfFrozenCols
                
                '@行列のﾏｳｽでの変更を不可にする
                .AllowResizing = AllowResizingEnum.None
                                
                '@ｾﾙ選択の設定
                .SelectionMode = SelectionModeEnum.Row
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号（...）を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.None
                .Styles.Normal.WordWrap = True
                
                '@ﾊｲﾗｲﾄ表示
                .HighLight = HighLightEnum.Always
                
                '@一覧表の表題設定
                lFixedStyle.ForeColor = vbYellow                                     '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)    '背景色
                lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CType(CMvsfHFontSize,Single), lFixedStyle.Font.Style ) 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                
                '@列の調整を不可にする
                '.AutoSizeMode = flexAutoSizeColWidth
                
                '@表示位置設定
                .Cols(CMvsfEmpColChk).TextAlign = TextAlignEnum.CenterCenter              'ﾁｪｯｸﾎﾞｯｸｽ
                .Cols(CMvsfEmpColEmpID).TextAlign = TextAlignEnum.LeftTop                 'ﾕｰｻﾞID
                .Cols(CMvsfEmpColEmpName).TextAlign = TextAlignEnum.LeftTop               'ﾕｰｻﾞ名
                .Cols(CMvsfEmpColMail).TextAlign = TextAlignEnum.LeftTop                  'ﾒﾙｱﾄﾞ

                '@列幅設定
                .Cols(CMvsfEmpColChk).Width = CMvsfEmpColWChk                             'ﾁｪｯｸﾎﾞｯｸｽ
                .Cols(CMvsfEmpColEmpID).Width = CMvsfEmpColWEmpID                         'ﾕｰｻﾞID
                .Cols(CMvsfEmpColEmpName).Width = CMvsfEmpColWEmpName                     'ﾕｰｻﾞ名
                .Cols(CMvsfEmpColMail).Width = CMvsfEmpColWMail                           'ﾒﾙｱﾄﾞ
            
                'ﾀｲﾄﾙ設定
                .SetData(CMvsfTRow, CMvsfEmpColChk, CMvsfEmpColTChk)          'ﾁｪｯｸﾎﾞｯｸｽ
                .SetData(CMvsfTRow, CMvsfEmpColEmpID, CMvsfEmpColTEmpID)      'ﾕｰｻﾞID
                .SetData(CMvsfTRow, CMvsfEmpColEmpName, CMvsfEmpColTEmpName)  'ﾕｰｻﾞ名
                .SetData(CMvsfTRow, CMvsfEmpColMail, CMvsfEmpColTMail)        'ﾒﾙｱﾄﾞ

                '@表示位置の設定
                .Cols(.Rows.Count - 1).TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMvsfTRow).Height = CMvsfHdHeight       '高さ
                
                '@非表示設定
                .Cols(CMvsfEmpColIndex).Visible = False      'index
                .Cols(CMvsfEmpColEmpID).Visible = False      'ﾕｰｻﾞID
                
                '@直接描画
                .Redraw = flexRDDirect
                
                '@ﾛｯｸ
                .Enabled = False
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝ
                cmdEmpUp.Enabled = False                   'ｽｸﾛｰﾙ上
                cmdEmpDown.Enabled = False                 'ｽｸﾛｰﾙ下
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfEmpList_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfDeptList_Disp
    '機　能：所属一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 18:01:38 N.Kasai
    '更新日：2005/05/09 (Mon) 18:01:38
    '備　考：
    Private Sub prvvsfDeptList_Disp()

        Dim llngCnt         As Integer  'ｶｳﾝﾄ

        Try

            With vsfDeptList

                'NSYS 不要イベント発生抑止
                RemoveHandler vsfDeptList.BeforeRowColChange, AddressOf vsfDeptList_BeforeRowColChange

                 '@0件の場合
                If ptypDepartmentList.lngDepartmentListCnt = 0 Then
                    '@ﾛｯｸ
                    .Enabled = False
                    
                    '@描画なし
                    .Redraw = flexRDNone
                    
                    '@ﾘｽﾄ行数格納
                    .Rows.Count = .Rows.Fixed
                    
                    '@直接描画なし
                    .Redraw = flexRDDirect
                    
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用不可
                    cmdDeptUp.Enabled = False
                    cmdDeptDown.Enabled = False
                    
                    Exit Sub
                End If
            
                '@件数ありの場合
                '@ｸﾞﾘｯﾄﾞのﾛｯｸ解除
                .Enabled = True
                
                '@描画なし
                .Redraw = flexRDNone
                
                '@ﾘｽﾄ行数格納
                '.Rows.Count = .Rows.Fixed
                RemoveHandler vsfDeptList.EnterCell, AddressOf vsfDeptList_EnterCell
                .Rows.Count = ptypDepartmentList.lngDepartmentListCnt + 1
                AddHandler vsfDeptList.EnterCell, AddressOf vsfDeptList_EnterCell
                
                '@行選択
                .Select(CMvsfTRow, .Cols.Fixed, CMvsfTRow, .Cols.Count - 1)
                    
                '@ｴﾝﾄﾘ一覧表示
                llngCnt = 1
                Do While ptypDepartmentList.lngDepartmentListCnt >= llngCnt
                    'INDEX
                    .SetData(llngCnt, CMvsfDeptColIndex, llngCnt)             
                    '所属名
                    .SetData(llngCnt, CMvsfDeptColDeptName, ptypDepartmentList.typDepartmentList(llngCnt -1).strDeptName)     
                    '所属ｺｰﾄﾞ    
                    .SetData(llngCnt, CMvsfDeptColDeptCode, ptypDepartmentList.typDepartmentList(llngCnt -1).strDeptCode)     
                    
                    '@行高さ設定
                    .Rows(llngCnt).Height = CMvsfRowHeight
                    llngCnt = llngCnt + 1
                Loop
                
                '@書式設定
                .Cols(CMvsfDeptColIndex).TextAlign = TextAlignEnum.LeftCenter      '左詰の中央揃え(INDEX)
                .Cols(CMvsfDeptColDeptName).TextAlign = TextAlignEnum.LeftCenter   '左詰の中央揃え(所属名)
                .Cols(CMvsfDeptColDeptCode).TextAlign = TextAlignEnum.LeftCenter   '左詰の中央揃え(所属ｺｰﾄﾞ）

                '@ﾍｯﾀﾞｰの高さ設定
                .Rows(CMvsfTRow).Height = CMvsfHdHeight
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝ設定
                '@頁先頭行が一覧先頭行の場合
                If .TopRow = .Rows.Fixed Then
                    '@ﾛｯｸ
                    cmdDeptUp.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdDeptUp.Enabled = True
                End If
                
                '@最終行が表示頁にある場合
                If .TopRow + CMlngvsfDeptPageRows >= .Rows.Count Then
                    '@ﾛｯｸ
                    cmdDeptDown.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdDeptDown.Enabled = True
                End If
                
                Dim llngRow As Integer = .Row
                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort1.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort1.lngCnt -1
                        '@該当行をｿｰﾄ
                        .Cols(mtypChgSort1.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort1.typChgSortList(llngCnt).lngOrder
                        .Sort(SortFlags.UseColSort,mtypChgSort1.typChgSortList(llngCnt).lngCol)
                    Next llngCnt
                    .Row = llngRow
                End If

                'NSYS 不要イベント発生抑止解除
                AddHandler vsfDeptList.BeforeRowColChange, AddressOf vsfDeptList_BeforeRowColChange
                
                '@ｿｰﾄ検索用ｷｰ（所属ｺｰﾄﾞ）がある場合
                If mtypChgSort1.strKey <> vbNullString Then
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@所属ｺｰﾄﾞが同じ場合
                        If .GetData(llngCnt, CMvsfDeptColDeptCode) = mtypChgSort1.strKey Then
                            .Row = llngCnt
                            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                            Call pubVsfBeforeSort(vsfDeptList, CMvsfDeptColDeptCode)
                            
                            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                            Call pubVsfAfterSort(vsfDeptList, CMvsfDeptColDeptCode, cmdDeptUp, cmdDeptDown)
                            
                            Exit For
                        End If
                    Next llngCnt
                Else
                    .TopRow = 0    '行
                    .Row = 0       'ｶﾚﾝﾄ行の移動
                End If
                
                '@直接描画
                .Redraw = flexRDDirect
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfDeptList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfEmpList_Disp
    '機　能：ﾕｰｻﾞ一覧表示
    '引　数：llngIndex：該当行判定INDEX
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 17:35:11 N.Kasai
    '更新日：2005/05/09 (Mon) 17:35:11
    '備　考：
    Private Sub prvvsfEmpList_Disp(ByVal llngIndex As Integer)

        Dim llngCnt             As Integer  '汎用ｶｳﾝﾄ
        Dim lblnAns             As Boolean  '汎用戻り値
        Dim llngChkCnt          As Integer  'ｶｳﾝﾄ（ﾁｪｯｸ）

        Try
            
            With vsfEmpList

                'NSYS 不要イベント発生抑止
                RemoveHandler vsfEmpList.BeforeRowColChange, AddressOf vsfEmpList_BeforeRowColChange

                '@0件の場合
                If ptypDepartmentList.typDepartmentList(llngIndex).typDeptEmpInfo.lngDeptEmpListCnt = 0 Then
                    '@ﾛｯｸ
                    .Enabled = False
                    
                    '@描画なし
                    .Redraw = flexRDNone
                    
                    '@ﾘｽﾄ行数格納
                    .Rows.Count = .Rows.Fixed
                    
                    '@直接描画なし
                    .Redraw = flexRDDirect
                    
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用不可
                    cmdEmpUp.Enabled = False
                    cmdEmpDown.Enabled = False
                    
                    Exit Sub
                End If
            
                '@件数ありの場合
                '@ｸﾞﾘｯﾄﾞのﾛｯｸ解除
                .Enabled = True
                
                '@描画なし
                .Redraw = flexRDNone
                
                '@ﾘｽﾄ行数初期化
                .Rows.Count = .Rows.Fixed
                
                '@ﾘｽﾄ行数格納
                .Rows.Count = ptypDepartmentList.typDepartmentList(llngIndex).typDeptEmpInfo.lngDeptEmpListCnt +1
                
                '@行選択
                .Select(CMvsfTRow, CMvsfEmpColChk, CMvsfTRow, CMvsfEmpColMail)
                    
                '@ｴﾝﾄﾘ一覧表示
                llngCnt = 1
                Do While .Rows.Count -1 >= llngCnt
                    'INDEX
                    .SetData(llngCnt, CMvsfEmpColIndex, llngCnt)                                                          
                    'ﾕｰｻﾞID
                    .SetData(llngCnt, CMvsfEmpColEmpID, ptypDepartmentList.typDepartmentList(llngIndex).typDeptEmpInfo.typDeptEmpList(llngCnt -1).strEmpID)           
                    'ﾕｰｻﾞ名
                    .SetData(llngCnt, CMvsfEmpColEmpName, ptypDepartmentList.typDepartmentList(llngIndex).typDeptEmpInfo.typDeptEmpList(llngCnt -1).strEmpName)         
                    'ﾒﾙｱﾄﾞ
                    .SetData(llngCnt, CMvsfEmpColMail, ptypDepartmentList.typDepartmentList(llngIndex).typDeptEmpInfo.typDeptEmpList(llngCnt -1).strMailAddress)   
                    
                    '@戻り値の初期化
                    lblnAns = False
                    
                    '@選択済みﾁｪｯｸ（KEY:ﾒﾙｱﾄﾞ）
                    For llngChkCnt = 1 To vsfMailList.Rows.Count - 1
                        '@Mail&Empｸﾞﾘｯﾄﾞのﾒﾙｱﾄﾞを比較
                        If vsfMailList.GetData(llngChkCnt, CMvsfMailColMail) = _
                           ptypDepartmentList.typDepartmentList(llngIndex).typDeptEmpInfo.typDeptEmpList(llngCnt -1).strMailAddress Then
                            
                            '@選択済み
                            lblnAns = True
                            
                            Exit For
                        End If
                    Next
                    
                    '@ﾁｪｯｸﾎﾞｯｸｽ制御
                    Select Case lblnAns
                        '@選択済み
                        Case True
                            .SetCellCheck(llngCnt, CMvsfEmpColChk, CheckEnum.Checked)         'ﾁｪｯｸあり
                            
                        '@未選択
                        Case Else
                            .SetCellCheck(llngCnt, CMvsfEmpColChk, CheckEnum.Unchecked)       'ﾁｪｯｸなし
                    End Select
                   
                    '@ﾊﾞｯｸｶﾗｰ変更（ﾒﾙｱﾄﾞが空白の場合はｸﾞﾘｯﾄﾞの使用不可）
                    If ptypDepartmentList.typDepartmentList(llngIndex).typDeptEmpInfo.typDeptEmpList(llngCnt-1).strMailAddress _
                       = vbNullString Then
                        
                        '@ｾﾙ色変更(薄灰)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfEmpColChk, llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle
                    Else
                        '@ｾﾙ色変更(白)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = vbWhite
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMvsfEmpColChk, llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle
                    End If
                   
                   '@行の高さ
                    .Rows(llngCnt).Height = CMvsfRowHeight
                    
                    llngCnt = llngCnt + 1
                Loop
                
                '@書式設定
                .Cols(CMvsfEmpColChk).ImageAlign = ImageAlignEnum.CenterCenter                 '中央の中央揃え(ﾁｪｯｸﾎﾞｯｸｽ)
                .Cols(CMvsfEmpColEmpName).TextAlign = TextAlignEnum.LeftCenter                 '左詰の中央揃え（ﾕｰｻﾞ名）
                .Cols(CMvsfEmpColEmpID).TextAlign = TextAlignEnum.LeftCenter                   '左詰の中央揃え（ﾕｰｻﾞID）
                .Cols(CMvsfEmpColMail).TextAlign = TextAlignEnum.LeftCenter                    '左詰の中央揃え（ﾒﾙｱﾄﾞ）

                '@ﾍｯﾀﾞｰの高さ設定
                .Rows(CMvsfTRow).Height = CMvsfHdHeight
                
                'NSYS ReDraw = True になった後に処理する必要があるため、タイミング調整
                ''@ｽｸﾛｰﾙﾎﾞﾀﾝ設定 
                ''@頁先頭行が一覧先頭行の場合
                'If .TopRow = .Rows.Fixed Then
                '    '@ﾛｯｸ
                '    cmdEmpUp.Enabled = False
                'Else
                '    '@ﾛｯｸ解除
                '    cmdEmpUp.Enabled = True
                'End If
                
                ''@最終行が表示頁にある場合
                'If .TopRow + CMlngvsfEmpPageRows >= .Rows.Count Then
                '    '@ﾛｯｸ
                '    cmdEmpDown.Enabled = False
                'Else
                '    '@ﾛｯｸ解除
                '    cmdEmpDown.Enabled = True
                'End If
                
                Dim llngRow As Integer = .Row
                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort2.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort2.lngCnt -1
                        '@該当行をｿｰﾄ
                        .Cols(mtypChgSort2.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort2.typChgSortList(llngCnt).lngOrder
                        .Sort(SortFlags.UseColSort,mtypChgSort2.typChgSortList(llngCnt).lngCol)
                    Next llngCnt
                    .Row = llngRow
                End If

                'NSYS 不要イベント発生抑止解除
                AddHandler vsfEmpList.BeforeRowColChange, AddressOf vsfEmpList_BeforeRowColChange
                
                '@ｿｰﾄ検索用ｷｰ（INDEX）がある場合
                If mtypChgSort2.strKey <> vbNullString Then
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@所属ｺｰﾄﾞが同じ場合
                        If .GetData(llngCnt, CMvsfEmpColIndex) = mtypChgSort2.strKey Then
                            .Row = llngCnt
                            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                            Call pubVsfBeforeSort(vsfEmpList, CMvsfEmpColIndex)
                            
                            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                            Call pubVsfAfterSort(vsfEmpList, CMvsfEmpColIndex, cmdEmpUp, cmdEmpDown)
                            
                            Exit For
                        End If
                    Next llngCnt
                Else
                    .TopRow = 0    '行
                    .Row = 0       'ｶﾚﾝﾄ行の移動
                End If
                
                '@直接描画
                .Redraw = flexRDDirect

                'NSYS ReDraw = Trueにしたタイミングでボタンの活性制御を行う
                '@ｽｸﾛｰﾙﾎﾞﾀﾝ設定
                '@頁先頭行が一覧先頭行の場合
                If .TopRow <= .Rows.Fixed Then '前のIF判定でTopRowが0になる場合があるため、= → <= に変更
                    '@ﾛｯｸ
                    cmdEmpUp.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdEmpUp.Enabled = True
                End If
                
                '@最終行が表示頁にある場合
                If .TopRow + CMlngvsfEmpPageRows >= .Rows.Count Then
                    '@ﾛｯｸ
                    cmdEmpDown.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdEmpDown.Enabled = True
                End If
              
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfEmpList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfMailList_Disp
    '機　能：ﾕｰｻﾞ一覧表示(mail)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 17:54:31 N.Kasai
    '更新日：2005/05/09 (Mon) 17:54:31
    '備　考：
    '　　　：2005/09/21 (Wed) 16:19:25 S.Deguchi    ﾕｰｻﾞｰID欄を追加
    Private Sub prvvsfMailList_Disp()

        Dim llngCnt         As Integer  'ｶｳﾝﾄ

        Try
            
            With vsfMailList
                '@ｸﾞﾘｯﾄﾞのﾛｯｸ解除
                .Enabled = True
                
                '@描画なし
                .Redraw = flexRDNone
                '@ﾘｽﾄ行数格納
                .Rows.Count = .Rows.Fixed
                .Rows.Count = ptypSendMailList.lngSendMailCnt + 1
                
                '@行選択
                .Select(CMvsfTRow, .Cols.Fixed, CMvsfTRow, CMvsfMailColMail)
                    
                '@ｴﾝﾄﾘ一覧表示
                llngCnt = 1
                Do While .Rows.Count > llngCnt
                    'ﾕｰｻﾞ名
                    .SetData(llngCnt, CMvsfMailColEmpName, ptypSendMailList.typSendMail(llngCnt -1).strName)                     
                    'ﾒﾙｱﾄﾞ
                    .SetData(llngCnt, CMvsfMailColMail, ptypSendMailList.typSendMail(llngCnt -1).strMail1)                   
        '@↓2005/09/21 (Wed) 16:20:11 S.Deguchi **************************************************
                    'ﾕｰｻﾞID
                    .SetData(llngCnt, CMvsfMailColEmpID, ptypSendMailList.typSendMail(llngCnt -1).strId)                       
        '@↑2005/09/21 (Wed) 16:20:11 S.Deguchi **************************************************
                    
                    llngCnt = llngCnt + 1
                Loop
                
                '@書式設定
                .Cols(CMvsfMailColEmpName).TextAlign = TextAlignEnum.LeftCenter                 '左詰の中央揃え（ﾕｰｻﾞ名）
                .Cols(CMvsfMailColMail).TextAlign = TextAlignEnum.LeftCenter                    '左詰の中央揃え（ﾒﾙｱﾄﾞ）

                '@ﾍｯﾀﾞｰの高さ設定
                .Rows(CMvsfTRow).Height = CMvsfHdHeight
                
                '@直接描画
                .Redraw = flexRDDirect
              
            End With
            
            '@確定ﾎﾞﾀﾝの制御
            If ptypSendMailList.lngSendMailCnt > 0 Then
                cmdChoice.Enabled = True
            Else
                cmdChoice.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMailList_Disp"
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
        Dim lblnSysCommandScClose   As Boolean = False  'NSYS コントロールメニュー SC_CLOSE処理時 True

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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraMail.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
