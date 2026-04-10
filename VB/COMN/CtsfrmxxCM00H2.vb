'ﾌｧｲﾙ名：xxCM00H2.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：作業ﾐｽ報告書 ﾒｲﾝﾌｫｰﾑ
'作成日：2004/08/19 (Thu) 13:07:46 S.Deguchi
'更新日：2004/08/19 (Thu) 13:07:46
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00H2
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00H2    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00H2
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00H2
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00H2)
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
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM00H2          'ﾛｰｶﾙ機能ID

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    Private Const CMstrExcpWKReportInfoVer          As String = "01.00"                 '作業ﾐｽ報告書取得
    Private Const CMstrExcpChgWKReportVer           As String = "01.00"                 '作業ﾐｽ報告書更新
    Private Const CMstrmasdepartmentlistVer         As String = "01.01"                 '部署名取得
    Private Const CMstrmasdeptemplistVer            As String = "01.00"                 '社員名取得

    '@登録/更新/表示の定数宣言
    Private Const CMstrExcpFlag0                    As String = "0"                     '新規登録
    Private Const CMstrExcpFlag1                    As String = "1"                     '更新登録
    Private Const CMstrExcpFlag2                    As String = "2"                     '表示(承認済み)

    '@TabのIndex定数宣言
    Private Const CMlngssTab1                       As Integer = 0                      '作業ﾐｽ報告書１
    Private Const CMlngssTab2                       As Integer = 1                      '作業ﾐｽ報告書２

    '@ｵﾌﾟｼｮﾝのIndex定数宣言
    Private Const CMlngopt0                         As Integer = 0                      'なし
    Private Const CMlngopt1                         As Integer = 1                      'あり/正規/A
    Private Const CMlngopt2                         As Integer = 2                      '特務/B
    Private Const CMlngopt3                         As Integer = 3                      '応援/C
    Private Const CMlngopt4                         As Integer = 4                      '日総正規/D
    Private Const CMlngopt5                         As Integer = 5                      '日総期間/E
    Private Const CMlngopt6                         As Integer = 6                      'F
    Private Const CMlngopt7                         As Integer = 7                      'G
    Private Const CMlngopt8                         As Integer = 8                      'H
    Private Const CMlngopt9                         As Integer = 9                      'I
    Private Const CMlngopt10                        As Integer = 10                     'J
    Private Const CMlngopt11                        As Integer = 11                     'K

    '@ｺﾝﾎﾞﾎﾞｯｸｽ共通の定数宣言
    Private Const CMlngCmbFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols1                 As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbValueCol1                 As Integer = 1                      '値取得個数=1
    Private Const CMlngCmbValueCol2                 As Integer = 2                      '値取得個数=2
    Private Const CMlngCmbRowHeight                 As Integer = 19                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                  As Integer = 0                      'ｺﾝﾎﾞ内列数(=0)
    Private Const CMlngCmbGridCol1                  As Integer = 1                      'ｺﾝﾎﾞ内列数(=1)

    '@文字列定数宣言
    Private Const CMstrKubunA                       As String = "A"                     'A
    Private Const CMstrKubunB                       As String = "B"                     'B
    Private Const CMstrKubunC                       As String = "C"                     'C
    Private Const CMstrKubunD                       As String = "D"                     'D
    Private Const CMstrKubunE                       As String = "E"                     'E
    Private Const CMstrKubunF                       As String = "F"                     'F
    Private Const CMstrKubunG                       As String = "G"                     'G
    Private Const CMstrKubunH                       As String = "H"                     'H
    Private Const CMstrKubunI                       As String = "I"                     'I
    Private Const CMstrKubunJ                       As String = "J"                     'J
    Private Const CMstrKubunK                       As String = "K"                     'K

    Private Const CMstrKubun0                       As String = "0"                     '0
    Private Const CMstrKubun1                       As String = "1"                     '1
    Private Const CMstrKubun2                       As String = "2"                     '2
    Private Const CMstrKubun3                       As String = "3"                     '3
    Private Const CMstrKubun4                       As String = "4"                     '4
        
    Private Const CMstrEN                           As String = " 円"                   '単位:円

    '@定数宣言
    Private Const CMlngMonth12                      As Integer = 12                     '12ヶ月

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow                   As Integer = 4                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ｺﾒﾝﾄ入力欄)

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@作業ﾐｽ報告書構造体を定義
    Private mtypExcpWKReportList                    As ExcpWKReportList
        
    '@部署名取得構造体を定義
    Private mtypDepartmentList                      As DepartmentInfo

    '@発生者名取得構造体を定義
    Private mtypDeptEmpList                         As DeptEmpInfo

    '@退避領域を定義
    Private mstrOccurTeam                           As String                           '発生職場退避領域
    Private mstrOccurName                           As String                           '発生者退避領域
    Private mstrDeptID                              As String                           '発生職場ID

    '@引継ぎ承認ﾌﾗｸﾞの退避
    Private mstrExcpInsFlag                         As String

    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの設定
    Private mblnFormLoadFlag                        As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ:True:1回目/False:2回目

    '@ｼｽﾃﾑﾌﾞﾛｯｸのﾓｼﾞｭｰﾙ変数
    Private mstrSBID                                As String                           'ｼｽﾃﾑﾌﾞﾛｯｸは引継ぎ構造体から格納

    '@編集ﾌﾗｸﾞ
    Private mblnEditFlag                            As Boolean

    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                          'NSYS WindowCloseフラグ

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
    '作成日：2004/08/19 (Thu) 13:09:15 S.Deguchi
    '更新日：2004/11/04 (Thu) 13:08:04 S.Deguchi
    '備　考：2004/11/04 (Thu) 13:08:08 S.Deguchi 承認済みで作業ﾐｽ報告書がない場合にはﾌｫｰﾑを起動しない
    '　　　：2004/11/04 (Thu) 17:11:27 S.Deguchi 結果判定ﾌﾗｸﾞを追加して処理を整理(構造体の中身を見て判断していた処理をﾌﾗｸﾞ判断へ変更)
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrResultFlag          As String               '結果判定用ﾌﾗｸﾞ

        Try

            'NSYS 画面表示位置
            Me.StartPosition = FormStartPosition.Manual
            Me.Top  = 0
            Me.Left = 0 - My.Settings.FormOffset

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "Form_Load"
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)

            '@画面情報の初期化
            Call prvfrmxxCM00H2_Init()

            '@ﾌﾗｸﾞ初期化
            lstrResultFlag = vbNullString
            
            '@部署名を取得する
            lblnAns = pubblnMasDepartmentList_Sel(CMstrmasdepartmentlistVer, mtypDepartmentList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
                
                Exit Sub
            Else
                '@部署ｺﾝﾎﾞ作成
                Call prvcmbOccurTeam_Disp()
                
            End If
            
            '@引継ぎ構造体の情報による処理分岐
            With ptypWkReportConnect
                mstrExcpInsFlag = .strExcpInsFlag               '処理分岐用ﾌﾗｸﾞをﾓｼﾞｭｰﾙへ定義
                '@ｼｽﾃﾑﾌﾞﾛｯｸを退避領域に設定
                mstrSBID = ptypWkReportConnect.strSbID
                
                Select Case mstrExcpInsFlag
                    Case CMstrExcpFlag1
                    '@新規/更新登録
                        '@登録されている情報を取得する
                        lblnAns = prvblnExcpWKReportInfo_Sel(.strExcpNo, lstrResultFlag)
                        '@結果判定
                        If lblnAns = False Then
                        '@取得失敗
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, lstrEventName)
                        Else
                        '@取得成功
                            '@登録されていない(該当件数0件)場合
                            If lstrResultFlag = "1" Then
                                '@引継ぎ構造体の内容をﾛｰｶﾙ変数へ置換する
                                Call prvConnectInfo_Set()
                            End If
                        End If
                        
                    Case CMstrExcpFlag2
                    '@承認済み表示
                        '@登録されている情報を取得する
                        lblnAns = prvblnExcpWKReportInfo_Sel(.strExcpNo, lstrResultFlag)
                        '@結果判定
                        If lblnAns = False Then
                        '@取得失敗
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, lstrEventName)
                            
                            '@ﾒｯｾｰｼﾞを表示する
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004B)
                            
                            '@「作業ミス報告書は登録されていません」
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@Escﾎﾞﾀﾝを有効
                            Me.CancelButton = Me.cmdClose
                            
                            Exit Sub
                        Else
                        '@取得成功
                            '@登録されていない(該当件数0件)場合
                            If lstrResultFlag = "1" Then
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(Me.Name, lstrEventName)
                                
                                '@ﾒｯｾｰｼﾞを表示する
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004B)
                                
                                '@「作業ミス報告書は登録されていません」
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@Escﾎﾞﾀﾝを有効
                                Me.CancelButton = Me.cmdClose
                                
                                Exit Sub
                            End If
                        End If
                End Select
            End With
                        
            '@画面に情報をｾｯﾄする
            Call prvfrmxxCM00H2_Disp()

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞを設定
            mblnFormLoadFlag = True
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            '@引継ぎﾌﾗｸﾞをTrue設定
            pblnfrmxxCM00H2Kbn = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/06 (Mon) 13:47:01 S.Deguchi
    '更新日：2004/09/06 (Mon) 13:47:01
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If mblnFormLoadFlag = True Then
                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞを戻す
                mblnFormLoadFlag = False
                
                '@発生職場と氏名の表記処理
                If mstrExcpInsFlag <> CMstrExcpFlag2 Then
                    Call prvcmbEmpDept_Set()
                Else
                    '@取得情報をｾｯﾄ
                    With mtypExcpWKReportList
                        cmbOccurTeam.Text = .strGenDeptName
                        cmbOccurName.Text = .strGenEmpName
                    End With
                End If

                '@NSYS 初期ﾌｫｰｶｽｾｯﾄ
                If mstrExcpInsFlag = CMstrExcpFlag2 Then
                    Call pubSetFocus(txtOccurComments)
                Else
                    Call pubSetFocus(cmbOccurName)
                End If
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:16:09 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:16:09
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

            '@Enterｷｰで次ﾌｫｰｶｽｾｯﾄ
            Select Case ActiveControl.Name
                '@ssTab1
                Case cmbOccurName.Name                          '発生者
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler cmbOccurName.Validating,AddressOf cmbOccurName_Validate
                            Call cmbOccurName_Validate(sender,New CancelEventArgs(False))
                            AddHandler cmbOccurName.Validating,AddressOf cmbOccurName_Validate
                    End Select
                    
                Case cmbOccurTeam.Name                          '発生職場
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler cmbOccurTeam.Validating,AddressOf cmbOccurTeam_Validate
                            Call cmbOccurTeam_Validate(sender,New CancelEventArgs(False))
                            AddHandler cmbOccurTeam.Validating,AddressOf cmbOccurTeam_Validate
                    End Select
                    
                Case txtOccurComments.Name
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                
                '@ssTab2
                Case calTaskDate1.Name                          '標準面
                    '@ｶﾚﾝﾀﾞｰの場合
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler calTaskDate1.Validating,AddressOf calTaskDate1_Validate
                            Call calTaskDate1_Validate(sender,New CancelEventArgs(False))
                            AddHandler calTaskDate1.Validating,AddressOf calTaskDate1_Validate
                            e.Handled = True
                    End Select
                        
                Case calTaskDate2.Name                          '教育面
                    '@ｶﾚﾝﾀﾞｰの場合
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler calTaskdate2.Validating,AddressOf calTaskdate2_Validate
                            Call calTaskdate2_Validate(sender,New CancelEventArgs(False))
                            AddHandler calTaskdate2.Validating,AddressOf calTaskdate2_Validate
                            e.Handled = True
                    End Select
                        
                Case calTaskDate3.Name                          '人
                    '@ｶﾚﾝﾀﾞｰの場合
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler calTaskdate3.Validating,AddressOf calTaskdate3_Validate
                            Call calTaskdate3_Validate(sender,New CancelEventArgs(False))
                            AddHandler calTaskdate3.Validating,AddressOf calTaskdate3_Validate
                            e.Handled = True
                    End Select
                        
                Case calTaskDate4.Name                          '装置面
                    '@ｶﾚﾝﾀﾞｰの場合
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler calTaskdate4.Validating,AddressOf calTaskdate4_Validate
                            Call calTaskdate4_Validate(sender,New CancelEventArgs(False))
                            AddHandler calTaskdate4.Validating,AddressOf calTaskdate4_Validate
                            e.Handled = True
                    End Select
                        
                Case txtCause1.Name
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                Case txtTask1.Name
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                Case txtCause2.Name
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                Case txtTask2.Name
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                Case txtCause3.Name
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                Case txtTask3.Name
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                Case txtCause4.Name
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                Case txtTask4.Name
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                Case txtHeadComments.Name
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                Case txtManagerComemnts.Name
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub

                Case Else
                '@その他
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ機能
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:01:24 S.Deguchi
    '更新日：2004/11/01 (Mon) 15:20:24 N.Kasai
    '備　考：2004/11/01 (Mon) 15:20:24 N.Kasai  閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim ltypExcpWKReportList    As ExcpWKReportList     '初期化用構造体
        Dim ltypFlowRecord          As FlowRecord           '流動履歴引継ぎ構造体
        
        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ﾓｼﾞｭｰﾙ変数のｸﾘｱ
            If mtypDepartmentList.typDepartmentList IsNot Nothing Then
                mtypDepartmentList.typDepartmentList.Clear()
            End If
            If mtypDeptEmpList.typDeptEmpList IsNot Nothing Then
                mtypDeptEmpList.typDeptEmpList.Clear()
            End If
            If ptypWkReportConnect.typLotList IsNot Nothing Then
                ptypWkReportConnect.typLotList.Clear()
            End If

        '@↓2005/12/27 (Tue) 15:17:51 S.Deguchi **************************************************
            '@引継ぎ情報格納構造体を初期化
            mtypExcpWKReportList = ltypExcpWKReportList
            ptypFlowRecord = ltypFlowRecord
        '@↑2005/12/27 (Tue) 15:17:51 S.Deguchi **************************************************
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：閉じるﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 13:59:25 S.Deguchi
    '更新日：2004/08/26 (Thu) 13:59:25
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
            
            'ｱﾝﾛｰﾄﾞ
            Me.Close()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 13:59:28 S.Deguchi
    '更新日：2004/08/26 (Thu) 13:59:28
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@確定ﾎﾞﾀﾝﾁｪｯｸ
            lblnAns = prvblnRegist_Chk
            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "cmdRegist_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)

            '@更新処理を行う
            Call prvtab1_Set()
            Call prvtab2_Set()

            '@作業ﾐｽ報告書の登録
            lblnAns = pubblnExcpChgWKReport_Ins(CMstrExcpChgWKReportVer, _
                                                mstrSBID, _
                                                mtypExcpWKReportList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            '@登録完了ﾒｯｾｰｼﾞを表示する
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001V, mtypExcpWKReportList.strExcpNo)
            
            '@成功ﾒｯｾｰｼﾞ表示
            '@pubVsfInfo_Disp("作業ミス報告書を登録しました。異常処理№[ %1 ]")
            Call pubVsfInfo_Disp(pstrDMsg)

            '@ﾊﾟﾌﾞﾘｯｸ変数に確定ﾌﾗｸﾞを格納
            ptypWkReportConnect.lngRegistFlag = 1
            
            '@登録ﾌｫｰﾑを閉じる
            Me.Close()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optMissKubun_Click
    '機　能：区分を選択した場合の処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/08/27 (Fri) 19:04:39 S.Deguchi
    '更新日：2004/08/27 (Fri) 19:04:39
    '備　考：
    Private Sub optMissKubun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optMissKubun1.Click,
                                                                                         optMissKubun2.Click,
                                                                                         optMissKubun3.Click,
                                                                                         optMissKubun4.Click,
                                                                                         optMissKubun5.Click,
                                                                                         optMissKubun6.Click,
                                                                                         optMissKubun7.Click,
                                                                                         optMissKubun8.Click,
                                                                                         optMissKubun9.Click,
                                                                                         optMissKubun10.Click,
                                                                                         optMissKubun11.Click

        Try

            '@区分を選択することによって確定ﾎﾞﾀﾝを活性化する
            If sender.checked = True Then
                '@確定ﾎﾞﾀﾝを活性化
                cmdRegist.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optMissKubun_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：tabControl_Click
    '機　能：ﾀﾌﾞ制御
    '引　数：PreviousTab：使用しない
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 12:53:31 S.Deguchi
    '更新日：2004/08/26 (Thu) 12:53:31
    '備　考：
    Private Sub tabControl_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tabControl.SelectedIndexChanged

        Try

             '@選択ﾀﾌﾞ別処理
            Select Case tabControl.SelectedIndex
                Case CMlngssTab1
                '@工程異常是正処置欄1-3
                    '@表示Tabの変更で登録/更新構造体へ情報を更新する
                    Call prvtab1_Set()
                    Call prvtab2_Set()
                
                    '@表示しているTab以外はﾌｫｰｶｽを移動しないように制御する
                    '@引継ぎ承認ﾌﾗｸﾞによるﾌｫｰﾑのﾛｯｸ
                    'If mstrExcpInsFlag = CMstrExcpFlag2 Then
                    '    fraMiss1.Enabled = False
                    '    fraMiss2.Enabled = False
                    'Else
                    '    fraMiss1.Enabled = True
                    '    fraMiss2.Enabled = False
                    'End If
                    
                Case CMlngssTab2
                '@工程異常是正処置欄4-6
                    '@表示Tabの変更で登録/更新構造体へ情報を更新する
                    Call prvtab1_Set()
                    Call prvtab2_Set()
                    
                    '@表示しているTab以外はﾌｫｰｶｽを移動しないように制御する
                    '@引継ぎ承認ﾌﾗｸﾞによるﾌｫｰﾑのﾛｯｸ
                    'If mstrExcpInsFlag = CMstrExcpFlag2 Then
                    '     fraMiss1.Enabled = False
                    '     fraMiss2.Enabled = False
                    'Else
                    '    fraMiss1.Enabled = False
                    '    fraMiss2.Enabled = True
                    'End If
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "tabControl_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@ssTab1**************************************************ここから
    '関数名：cmbOccurName_CloseUp
    '機　能：発生者名CloseUP処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/27 (Fri) 19:14:38 S.Deguchi
    '更新日：2004/08/27 (Fri) 19:14:38
    '備　考：
    Private Sub cmbOccurName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOccurName.CloseUp

        Try

            If cmbOccurName.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbOccurName.Validating,AddressOf cmbOccurName_Validate
                Call cmbOccurName_Validate(sender,New CancelEventArgs(False))
                AddHandler cmbOccurName.Validating,AddressOf cmbOccurName_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOccurName_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOccurName_Validate
    '機　能：発生者名称Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/27 (Fri) 19:14:41 S.Deguchi
    '更新日：2004/08/27 (Fri) 19:14:41
    '備　考：
    Private Sub cmbOccurName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbOccurName.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If cmbOccurName.Text <> mstrOccurName Then
                '@退避領域に値をｾｯﾄ
                mstrOccurName = cmbOccurName.Text
            End If
            
            '@次項目へﾌｫｰｶｽｾｯﾄ
            If Me.ActiveControl.Name = cmbOccurName.Name Then
                Call pubSetFocus(txtProYear)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOccurName_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOccurTeam_Change
    '機　能：発生職場の変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 15:24:58 S.Deguchi
    '更新日：2004/08/26 (Thu) 15:24:58
    '備　考：
    Private Sub cmbOccurTeam_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOccurTeam.Change

        Try

            '@職場を変更したら発生者はｸﾘｱする
            cmbOccurName.Text = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOccurTeam_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOccurTeam_CloseUp
    '機　能：発生職場のCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 15:25:00 S.Deguchi
    '更新日：2004/08/26 (Thu) 15:25:00
    '備　考：
    Private Sub cmbOccurTeam_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOccurTeam.CloseUp

        Try

            If cmbOccurTeam.Text <> vbNullString Then
                '@Validate処理へ
                Call cmbOccurTeam_Validate(sender,New CancelEventArgs(False))
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOccurTeam_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOccurTeam_Validate
    '機　能：発生職場のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 15:25:02 S.Deguchi
    '更新日：2004/08/26 (Thu) 15:25:02
    '備　考：
    Private Sub cmbOccurTeam_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbOccurTeam.Validating

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Or Me.ActiveControl.Name = tabControl.Name Then
                Exit Sub
            End If

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "cmbOccurTeam_Validate"

            '@選択されていない場合
            If cmbOccurTeam.Text = vbNullString Then
                '@次へﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtProYear)
                
                Exit Sub
            End If
            
            '@変数へ置き換える
            cmbOccurTeam.ValueCol = CMlngCmbValueCol1
            mstrDeptID = cmbOccurTeam.Value
            
            '@社員名ﾘｽﾄ取得(選択されている所属と退避領域の所属が異なる場合行う)
            If cmbOccurTeam.Text <> mstrOccurTeam Then
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, lstrEventName)
                
                '@発生者名取得
                lblnAns = pubblnMasDeptEmpList_Sel(CMstrmasdeptemplistVer, mstrDeptID, mtypDeptEmpList)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
                    
                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                    
                    Exit Sub
                Else
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, lstrEventName)
            
                    '@取得した名称が0件の場合にはﾒｯｾｰｼﾞを表示して使用不可にする
                    If mtypDeptEmpList.lngDeptEmpListCnt = 0 Then
                        '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002O)
                        
                        '@「発生者職場に対する社員が存在しません。設定を見直してください。」
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@発生者ｺﾝﾎﾞﾎﾞｯｸｽ使用不可
                        cmbOccurName.Enabled = False
                        
                        '@退避領域をｸﾘｱ
                        mstrOccurTeam = vbNullString
                        
                        '@ﾌｫｰｶｽそのまま
                        e.Cancel = True
                        
                        Exit Sub
                        
                    Else
                        '@発生者ｺﾝﾎﾞ作成
                        Call prvcmbDeptEmpList_Disp(mtypDeptEmpList)
                        
                        '@退避領域に値をｾｯﾄ
                        mstrOccurTeam = cmbOccurTeam.Text
                        
                        '@発生者ｺﾝﾎﾞを使用可能にする
                        cmbOccurName.Enabled = True
                        
                        '@次へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbOccurName)
                    End If
                End If
            Else
                '@次へﾌｫｰｶｽｾｯﾄ
                If cmbOccurName.Enabled = True Then
                    If ActiveControl.Name = cmbOccurTeam.Name Then
                        Call pubSetFocus(cmbOccurName)
                    End If
                Else
                    If ActiveControl.Name = cmbOccurTeam.Name Then
                        Call pubSetFocus(txtProYear)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOccurTeam_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdOccur_Click
    '機　能：発生工程検索処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 13:59:53 S.Deguchi
    '更新日：2004/08/26 (Thu) 13:59:53
    '備　考：意味をなしていない機能！：流動票(履歴)から情報を取得しているが,確定時保存していない
    Private Sub cmdOccur_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdOccur.Click

        Dim ltypFlowRecord           As FlowRecord       '流動履歴引継ぎ構造体

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

        '@↓2005/12/27 (Tue) 15:17:27 S.Deguchi **************************************************
            '@引継ぎ情報格納構造体を初期化
            ptypFlowRecord = ltypFlowRecord
        '@↑2005/12/27 (Tue) 15:17:27 S.Deguchi **************************************************
            
            '@引継ぎﾌﾗｸﾞをTrue設定
            pblnfrmxxCM00H4Kbn = True
            
            '@選択ﾛｯﾄIDをﾊﾟﾌﾞﾘｯｸ変数へ設定
            pstrLotID = cmbLotList.Text
            
        '@↓2005/12/27 (Tue) 15:22:38 S.Deguchi **************************************************
            '@引継いだｼｽﾃﾑﾌﾞﾛｯｸをｾｯﾄ
            pstrConnectSBID = mstrSBID
        '@↑2005/12/27 (Tue) 15:22:38 S.Deguchi **************************************************
            
            '@子画面の起動
            frmxxCM00H4.Instance = New frmxxCM00H4()
            
            If pblnfrmxxCM00H4Kbn = False Then
                '@子画面をｱﾝﾛｰﾄﾞする
                frmxxCM00H4.Instance = Nothing
                
                '@処理抜け
                Exit Sub
            Else
                '@ﾌｫｰﾑを表示
                frmxxCM00H4.Instance.ShowDialog(Me)
                frmxxCM00H4.Instance = Nothing
            End If

            '@引継ぎ情報をﾗﾍﾞﾙにｾｯﾄ
            With ptypFlowRecord
                '@引継ぎ情報がない場合にはそのまま
                If .strOpID = vbNullString Then
                    Exit Sub
                Else
                    lblOccurOpID.Text = .strOpID             '大工程
                    lblOccurStepID.Text = .strStepID         '小工程
                    lblOccurWpID.Text = .strWpName           '装置名
                End If
            End With
            
        '@↓2005/12/27 (Tue) 15:17:31 S.Deguchi **************************************************
            '@ﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrLotID = vbNullString                            'ﾛｯﾄID
            pstrConnectSBID = vbNullString                      'ｼｽﾃﾑﾌﾞﾛｯｸ
        '@↑2005/12/27 (Tue) 15:17:31 S.Deguchi **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdOccur_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtProYear_Validate
    '機　能：TFT製造経験年数のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 13:44:19 S.Deguchi
    '更新日：2004/08/31 (Tue) 13:44:19
    '備　考：
    Private Sub txtProYear_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtProYear.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If txtProYear.Text = vbNullString Then
            '@空欄の場合
                txtProYear.Text = 0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtProYear_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtProMonth_Validate
    '機　能：TFT製造経験月数のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 13:21:09 S.Deguchi
    '更新日：2004/08/31 (Tue) 13:21:09
    '備　考：
    Private Sub txtProMonth_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtProMonth.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Or Me.ActiveControl.Name = tabControl.Name Then
                Exit Sub
            End If

            If txtProMonth.Text <> vbNullString Then
            '@空欄以外の場合
                '@11ヶ月以上を入力した場合には,ﾒｯｾｰｼﾞを表示してﾌｫｰｶｽそのまま
                If txtProMonth.Text >= CMlngMonth12 Then
                    '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002F)
                    
                    '@「入力された値は正しくありません。0～11までの値を入力してください。」
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                End If
            Else
            '@空欄の場合
                '@「0ヶ月」とする
                txtProMonth.Text = 0
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtProMonth_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtExpYear_Validate
    '機　能：TFT該当工程経月数のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 13:43:10 S.Deguchi
    '更新日：2004/08/31 (Tue) 13:43:10
    '備　考：
    Private Sub txtExpYear_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtExpYear.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If txtExpYear.Text = vbNullString Then
            '@空欄の場合
                txtExpYear.Text = 0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtExpYear_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtExpMonth_Validate
    '機　能：TFT該当工程経月数のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 13:21:07 S.Deguchi
    '更新日：2004/08/31 (Tue) 13:21:07
    '備　考：
    Private Sub txtExpMonth_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtExpMonth.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Or Me.ActiveControl.Name = tabControl.Name Then
                Exit Sub
            End If

            If txtExpMonth.Text <> vbNullString Then
            '@空欄以外の場合
                '@11ヶ月以上を入力した場合には,ﾒｯｾｰｼﾞを表示してﾌｫｰｶｽそのまま
                If txtExpMonth.Text >= CMlngMonth12 Then
                    '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002F)
                    
                    '@「入力された値は正しくありません。0～11までの値を入力してください。」
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                End If
            Else
            '@空欄の場合
                '@「0ヶ月」とする
                txtExpMonth.Text = 0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtExpMonth_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbLotList_CloseUp
    '機　能：ﾛｯﾄﾘｽﾄのCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 15:04:44 S.Deguchi
    '更新日：2004/08/26 (Thu) 15:04:44
    '備　考：
    Private Sub cmbLotList_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotList.CloseUp

        Try


            If cmbLotList.Text <> vbNullString Then
                '@Validate処理へ
                Call cmbLotList_Validate(sender,New CancelEventArgs(False))
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbLotList_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbLotList_Validate
    '機　能：ﾛｯﾄﾘｽﾄのValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 15:04:47 S.Deguchi
    '更新日：2004/08/26 (Thu) 15:04:47
    '備　考：
    Private Sub cmbLotList_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbLotList.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@選択ﾛｯﾄIDをﾊﾟﾌﾞﾘｯｸ変数へ設定
            pstrLotID = cmbLotList.Text
            
            '@ｾｯﾄﾌｫｰｶｽ
            If ActiveControl.Name = cmbLotList.Name Then
                Call pubSetFocus(txtWFNo)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbLotList_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWorkMemoUp_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 15:03:07 S.Deguchi
    '更新日：2005/12/05 (Mon) 11:26:04 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 11:26:04 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdWorkMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkMemoUp.Click

        Try

        '@↓2005/12/05 (Mon) 11:26:02 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtOccurComments)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtOccurComments, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)
        '@↑2005/12/05 (Mon) 11:26:02 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkMemoUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWorkMemoDown_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 15:03:10 S.Deguchi
    '更新日：2005/12/05 (Mon) 11:26:57 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 11:26:57 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdWorkMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkMemoDown.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 11:26:53 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtOccurComments)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtOccurComments, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)
        '@↑2005/12/05 (Mon) 11:26:53 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkMemoDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtOccurComments_Change
    '機　能：発生状況変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtOccurComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtOccurComments.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            
            Call pubtxtChange_Proc(txtOccurComments, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtOccurComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtOccurComments_KeyUp
    '機　能：発生状況操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtOccurComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtOccurComments.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtOccurComments, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtOccurComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtOccurComments_MouseUp
    '機　能：発生状況操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txtOccurComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtOccurComments.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtOccurComments, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtOccurComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@ssTab1**************************************************ここまで

    '@ssTab2**************************************************ここから
    '関数名：cmdCauseUp1_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:35 S.Deguchi
    '更新日：2005/12/05 (Mon) 11:39:13 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 11:39:13 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdCauseUp1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCauseUp1.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 11:39:10 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtCause1)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtCause1, CMlngMaxDispRow, cmdCauseUp1, cmdCauseDown1)
        '@↑2005/12/05 (Mon) 11:39:10 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCauseUp1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCauseDown1_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:37 S.Deguchi
    '更新日：2005/12/05 (Mon) 11:40:26 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 11:40:26 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdCauseDown1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCauseDown1.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 11:40:23 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtCause1)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtCause1, CMlngMaxDispRow, cmdCauseUp1, cmdCauseDown1)
        '@↑2005/12/05 (Mon) 11:40:23 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCauseDown1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause1_Change
    '機　能：原因1変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtCause1_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCause1.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtCause1, CMlngMaxDispRow, cmdCauseUp1, cmdCauseDown1)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause1_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause1_KeyUp
    '機　能：原因1ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtCause1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCause1.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtCause1, CMlngMaxDispRow, cmdCauseUp1, cmdCauseDown1)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause1_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause1_MouseUp
    '機　能：原因1ﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txtCause1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtCause1.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtCause1, CMlngMaxDispRow, cmdCauseUp1, cmdCauseDown1, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause1_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTaskUp1_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:39 S.Deguchi
    '更新日：2005/12/05 (Mon) 12:05:29 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 12:05:29 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdTaskUp1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTaskUp1.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 12:05:24 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtTask1)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtTask1, CMlngMaxDispRow, cmdTaskUp1, cmdTaskDown1)
        '@↑2005/12/05 (Mon) 12:05:24 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTaskUp1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTaskDown1_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:42 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:41:42
    '備　考：
    Private Sub cmdTaskDown1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTaskDown1.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 12:06:04 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtTask1)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtTask1, CMlngMaxDispRow, cmdTaskUp1, cmdTaskDown1)
        '@↑2005/12/05 (Mon) 12:06:04 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTaskDown1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTask1_Change
    '機　能：対策1変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtTask1_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtTask1.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtTask1, CMlngMaxDispRow, cmdTaskUp1, cmdTaskDown1)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTask1_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTask1_KeyUp
    '機　能：対策1ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtTask1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtTask1.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtTask1, CMlngMaxDispRow, cmdTaskUp1, cmdTaskDown1)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTask1_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTask1_MouseUp
    '機　能：対策1ﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txtTask1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtTask1.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtTask1, CMlngMaxDispRow, cmdTaskUp1, cmdTaskDown1, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTask1_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calTaskDate1_CalendarSelect
    '機　能：対策日付の処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:35:48 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:35:48
    '備　考：
    Private Sub calTaskDate1_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calTaskDate1.CalendarSelect

        Try

            If calTaskDate1.Value <> CPstrNullDate Then
                '@Validate処理へ
                RemoveHandler calTaskDate1.Validating,AddressOf calTaskDate1_Validate
                Call calTaskDate1_Validate(sender,New CancelEventArgs(False))
                AddHandler calTaskDate1.Validating,AddressOf calTaskDate1_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calTaskDate1_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calTaskDate1_Validate
    '機　能：対策日付のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:35:51 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:35:51
    '備　考：
    Private Sub calTaskDate1_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calTaskDate1.Validating

        Dim lstrNowDT           As String       '現在日付取得

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Or Me.ActiveControl.Name = tabControl.Name Then
                Exit Sub
            End If

            '@日付が入力されていいる場合
            If calTaskDate1.Value <> CPstrNullDate Then
                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(calTaskDate1.Value) = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                    
                    Exit Sub
                Else
                    '@現在日付取得
                    lstrNowDT = Format(Now, CPstrDateTimeYMD)
                    '@未来日付の場合
                    If Format(CDate(calTaskDate1.Value), CPstrDateTimeYMD) > lstrNowDT Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                        '@"未来日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                           
                        '@ﾌｫｰｶｽを移さない
                        e.Cancel = True
                        
                        Exit Sub
                    End If
                End If
            End If
            
            '@次項目へﾌｫｰｶｽｾｯﾄ
            If opt2AriNashi0.Checked = True Then
                If ActiveControl.Name = calTaskDate1.Name Then
                    Call pubSetFocus(opt2AriNashi0)
                End If
            Else
                If ActiveControl.Name = calTaskDate1.Name Then
                    Call pubSetFocus(opt2AriNashi1)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calTaskDate1_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCauseUp2_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:35 S.Deguchi
    '更新日：2005/12/05 (Mon) 12:59:24 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 12:59:24 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdCauseUp2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCauseUp2.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 12:57:52 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtCause2)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtCause2, CMlngMaxDispRow, cmdCauseUp2, cmdCauseDown2)
        '@↑2005/12/05 (Mon) 12:57:52 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCauseUp2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCauseDown2_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:37 S.Deguchi
    '更新日：2005/12/05 (Mon) 12:59:05 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 12:59:05 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdCauseDown2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCauseDown2.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 12:58:06 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtCause2)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtCause2, CMlngMaxDispRow, cmdCauseUp2, cmdCauseDown2)
        '@↑2005/12/05 (Mon) 12:58:06 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCauseDown2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause2_Change
    '機　能：原因2変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtCause2_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCause2.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtCause2, CMlngMaxDispRow, cmdCauseUp2, cmdCauseDown2)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause2_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause2_KeyUp
    '機　能：原因2ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtCause2_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCause2.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtCause2, CMlngMaxDispRow, cmdCauseUp2, cmdCauseDown2)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause2_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause2_MouseUp
    '機　能：原因2ﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txtCause2_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtCause2.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtCause2, CMlngMaxDispRow, cmdCauseUp2, cmdCauseDown2, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause2_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：cmdTaskUp2_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:39 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:03:02 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:03:02 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdTaskUp2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTaskUp2.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:02:59 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtTask2)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtTask2, CMlngMaxDispRow, cmdTaskUp2, cmdTaskDown2)
        '@↑2005/12/05 (Mon) 13:02:59 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTaskUp2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTaskDown2_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:42 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:03:20 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:03:20 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdTaskDown2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTaskDown2.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:03:50 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtTask2)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtTask2, CMlngMaxDispRow, cmdTaskUp2, cmdTaskDown2)
        '@↑2005/12/05 (Mon) 13:03:50 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTaskDown2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTask2_Change
    '機　能：対策2変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtTask2_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtTask2.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtTask2, CMlngMaxDispRow, cmdTaskUp2, cmdTaskDown2)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTask2_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTask2_KeyUp
    '機　能：対策2ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtTask2_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtTask2.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtTask2, CMlngMaxDispRow, cmdTaskUp2, cmdTaskDown2)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTask2_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTask2_MouseUp
    '機　能：対策2ﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtTask2_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtTask2.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtTask2, CMlngMaxDispRow, cmdTaskUp2, cmdTaskDown2, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTask2_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：calTaskdate2_CalendarSelect
    '機　能：対策日付の処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:35:48 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:35:48
    '備　考：
    Private Sub calTaskdate2_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calTaskdate2.CalendarSelect

        Try

            If calTaskDate2.Value <> CPstrNullDate Then
                '@Validate処理へ
                RemoveHandler calTaskdate2.Validating,AddressOf calTaskdate2_Validate
                Call calTaskdate2_Validate(sender,New CancelEventArgs(False))
                AddHandler calTaskdate2.Validating,AddressOf calTaskdate2_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calTaskdate2_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calTaskdate2_Validate
    '機　能：対策日付のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:35:51 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:35:51
    '備　考：
    Private Sub calTaskdate2_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calTaskdate2.Validating

        Dim lstrNowDT           As String       '現在日付取得

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Or Me.ActiveControl.Name = tabControl.Name Then
                Exit Sub
            End If

            '@日付が入力されていいる場合
            If calTaskDate2.Value <> CPstrNullDate Then
                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(calTaskDate2.Value) = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                    Exit Sub
                Else
                    '@現在日付取得
                    lstrNowDT = Format(Now, CPstrDateTimeYMD)
                    '@過去日付の場合
                    If Format(CDate(calTaskDate2.Value), CPstrDateTimeYMD) > lstrNowDT Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                        '@"未来日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                           
                        '@ﾌｫｰｶｽを移さない
                        e.Cancel = True
                        
                        Exit Sub
                    End If
                End If
            End If
            
            '@次項目へﾌｫｰｶｽｾｯﾄ
            If opt3AriNashi0.Checked = True Then
                If ActiveControl.Name = calTaskdate2.Name Then
                    Call pubSetFocus(opt3AriNashi0)
                End If
            Else
                If ActiveControl.Name = calTaskdate2.Name Then
                    Call pubSetFocus(opt3AriNashi1)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calTaskdate2_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCauseUp3_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:35 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:07:35 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:07:35 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdCauseUp3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCauseUp3.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:08:37 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtCause3)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtCause3, CMlngMaxDispRow, cmdCauseUp3, cmdCauseDown3)
        '@↑2005/12/05 (Mon) 13:08:37 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCauseUp3_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCauseDown3_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:37 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:07:53 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:07:53 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdCauseDown3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCauseDown3.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:08:55 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtCause3)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtCause3, CMlngMaxDispRow, cmdCauseUp3, cmdCauseDown3)
        '@↑2005/12/05 (Mon) 13:08:55 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCauseDown3_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause3_Change
    '機　能：原因3変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtCause3_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCause3.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtCause3, CMlngMaxDispRow, cmdCauseUp3, cmdCauseDown3)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause3_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause3_KeyUp
    '機　能：原因3ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtCause3_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCause3.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtCause3, CMlngMaxDispRow, cmdCauseUp3, cmdCauseDown3)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause3_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause3_MouseUp
    '機　能：原因3ﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txtCause3_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtCause3.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtCause3, CMlngMaxDispRow, cmdCauseUp3, cmdCauseDown3, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause3_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：cmdTaskUp3_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:39 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:13:01 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:13:01 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdTaskUp3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTaskUp3.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:12:24 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtTask3)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtTask3, CMlngMaxDispRow, cmdTaskUp3, cmdTaskDown3)
        '@↑2005/12/05 (Mon) 13:12:24 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTaskUp3_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTaskDown3_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:42 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:12:44 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:12:44 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdTaskDown3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTaskDown3.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:12:40 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtTask3)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtTask3, CMlngMaxDispRow, cmdTaskUp3, cmdTaskDown3)
        '@↑2005/12/05 (Mon) 13:12:40 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTaskDown3_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calTaskdate3_CalendarSelect
    '機　能：対策日付の処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:35:48 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:35:48
    '備　考：
    Private Sub calTaskdate3_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calTaskdate3.CalendarSelect

        Try

            If calTaskDate3.Value <> CPstrNullDate Then
                '@Validate処理へ
                RemoveHandler calTaskdate3.Validating,AddressOf calTaskdate3_Validate
                Call calTaskdate3_Validate(sender,New CancelEventArgs(False))
                AddHandler calTaskdate3.Validating,AddressOf calTaskdate3_Validate
            End If
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calTaskdate3_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTask3_Change
    '機　能：対策3変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtTask3_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtTask3.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtTask3, CMlngMaxDispRow, cmdTaskUp3, cmdTaskDown3)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTask3_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTask3_KeyUp
    '機　能：対策3ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtTask3_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtTask3.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtTask3, CMlngMaxDispRow, cmdTaskUp3, cmdTaskDown3)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTask3_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTask3_MouseUp
    '機　能：対策3ﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtTask3_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtTask3.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtTask3, CMlngMaxDispRow, cmdTaskUp3, cmdTaskDown3, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTask3_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calTaskdate3_Validate
    '機　能：対策日付のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:35:51 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:35:51
    '備　考：
    Private Sub calTaskdate3_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calTaskdate3.Validating

        Dim lstrNowDT           As String       '現在日付取得

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Or Me.ActiveControl.Name = tabControl.Name Then
                Exit Sub
            End If

            '@日付が入力されていいる場合
            If calTaskDate3.Value <> CPstrNullDate Then
                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(calTaskDate3.Value) = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                    Exit Sub
                Else
                    '@現在日付取得
                    lstrNowDT = Format(Now, CPstrDateTimeYMD)
                    '@過去日付の場合
                    If Format(CDate(calTaskDate3.Value), CPstrDateTimeYMD) > lstrNowDT Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                        '@"未来日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                           
                        '@ﾌｫｰｶｽを移さない
                        e.Cancel = True
                        
                        Exit Sub
                    End If
                End If
            End If
            
            '@次項目へﾌｫｰｶｽｾｯﾄ
            If opt4AriNashi0.Checked = True Then
                If ActiveControl.Name = calTaskdate3.Name Then
                    Call pubSetFocus(opt4AriNashi0)
                End If
            Else
                If ActiveControl.Name = calTaskdate3.Name Then
                    Call pubSetFocus(opt4AriNashi1)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calTaskdate3_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCauseUp4_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:35 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:15:36 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:15:36 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdCauseUp4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCauseUp4.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:15:33 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtCause4)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtCause4, CMlngMaxDispRow, cmdCauseUp4, cmdCauseDown4)
        '@↑2005/12/05 (Mon) 13:15:33 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCauseUp4_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCauseDown4_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:37 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:16:27 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:16:27 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdCauseDown4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCauseDown4.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:16:14 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtCause4)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtCause4, CMlngMaxDispRow, cmdCauseUp4, cmdCauseDown4)
        '@↑2005/12/05 (Mon) 13:16:14 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCauseDown4_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause4_Change
    '機　能：原因4変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtCause4_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCause4.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtCause4, CMlngMaxDispRow, cmdCauseUp4, cmdCauseDown4)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause4_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause4_KeyUp
    '機　能：原因4ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtCause4_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCause4.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtCause4, CMlngMaxDispRow, cmdCauseUp4, cmdCauseDown4)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause4_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause4_MouseUp
    '機　能：原因4ﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txtCause4_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtCause4.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtCause4, CMlngMaxDispRow, cmdCauseUp4, cmdCauseDown4, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause4_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTaskUp4_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:39 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:19:17 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:19:17 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdTaskUp4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTaskUp4.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:18:39 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtTask4)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtTask4, CMlngMaxDispRow, cmdTaskUp4, cmdTaskDown4)
        '@↑2005/12/05 (Mon) 13:18:39 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTaskUp4_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTaskDown4_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:42 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:19:32 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:19:32 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdTaskDown4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTaskDown4.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:19:05 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtTask4)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtTask4, CMlngMaxDispRow, cmdTaskUp4, cmdTaskDown4)
        '@↑2005/12/05 (Mon) 13:19:05 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTaskDown4_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTask4_Change
    '機　能：対策4変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtTask4_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtTask4.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtTask4, CMlngMaxDispRow, cmdTaskUp4, cmdTaskDown4)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTask4_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTask4_KeyUp
    '機　能：対策4ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtTask4_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtTask4.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtTask4, CMlngMaxDispRow, cmdTaskUp4, cmdTaskDown4)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTask4_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTask4_MouseUp
    '機　能：対策4ﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtTask4_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtTask4.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtTask4, CMlngMaxDispRow, cmdTaskUp4, cmdTaskDown4, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTask4_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calTaskdate4_CalendarSelect
    '機　能：対策日付の処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:35:48 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:35:48
    '備　考：
    Private Sub calTaskdate4_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calTaskdate4.CalendarSelect

        Try

            If calTaskDate4.Value <> CPstrNullDate Then
                '@Validate処理へ
                Call calTaskdate4_Validate(sender,New CancelEventArgs(False))
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calTaskdate4_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calTaskdate4_Validate
    '機　能：対策日付のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:35:51 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:35:51
    '備　考：
    Private Sub calTaskdate4_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calTaskdate4.Validating

        Dim lstrNowDT           As String       '現在日付取得

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Or Me.ActiveControl.Name = tabControl.Name Then
                Exit Sub
            End If

            '@日付が入力されていいる場合
            If calTaskDate4.Value <> CPstrNullDate Then
                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(calTaskDate4.Value) = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                    Exit Sub
                Else
                    '@現在日付取得
                    lstrNowDT = Format(Now, CPstrDateTimeYMD)
                    '@過去日付の場合
                    If Format(CDate(calTaskDate4.Value), CPstrDateTimeYMD) > lstrNowDT Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                        '@"未来日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                           
                        '@ﾌｫｰｶｽを移さない
                        e.Cancel = True
                        
                        Exit Sub
                    End If
                End If
            End If
                
            '@次項目へﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtReUnit)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calTaskdate4_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtReUnit_Change
    '機　能：再生単価変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/02 (Fri) 09:53:53 S.Deguchi
    '更新日：2005/09/02 (Fri) 09:53:53
    '備　考：
    Private Sub txtReUnit_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtReUnit.Change

        Try

            If mblnEditFlag = True Then
                '@ﾌｫｰﾏｯﾄ変換
                txtReUnit.Text = Format$(CDec(txtReUnit.Text), CPstrDateFormatKanma)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtReUnit_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtReUnit_Validate
    '機　能：再生単価変更処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:29:47 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:29:47
    '備　考：
    Private Sub txtReUnit_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtReUnit.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@空欄の場合には「0」ｾｯﾄ
            If txtReUnit.Text = vbNullString Then
                txtReUnit.Text = 0
            End If
            
            '@金額計算
            Call prvblnTotalMoney_Cal()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtReUnit_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtReNum_Change
    '機　能：再生数量変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/02 (Fri) 09:53:53 S.Deguchi
    '更新日：2005/09/02 (Fri) 09:53:53
    '備　考：
    Private Sub txtReNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtReNum.Change

        Try

            If mblnEditFlag = True Then
                '@ﾌｫｰﾏｯﾄ変換
                txtReNum.Text = Format$(CDec(txtReNum.Text), CPstrDateFormatKanma)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtReNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtReNum_Validate
    '機　能：再生数量変更処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:29:44 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:29:44
    '備　考：
    Private Sub txtReNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtReNum.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@空欄の場合には「0」ｾｯﾄ
            If txtReNum.Text = vbNullString Then
                txtReNum.Text = 0
            End If
            
            '@金額計算
            Call prvblnTotalMoney_Cal()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtReNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtBadUnit_Change
    '機　能：不良単価変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/02 (Fri) 09:53:53 S.Deguchi
    '更新日：2005/09/02 (Fri) 09:53:53
    '備　考：
    Private Sub txtBadUnit_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtBadUnit.Change

        Try

            If mblnEditFlag = True Then
                '@ﾌｫｰﾏｯﾄ変換
                txtBadUnit.Text = Format$(CDec(txtBadUnit.Text), CPstrDateFormatKanma)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtBadUnit_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtBadUnit_Validate
    '機　能：不良単価変更処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:29:42 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:29:42
    '備　考：
    Private Sub txtBadUnit_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtBadUnit.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@空欄の場合には「0」ｾｯﾄ
            If txtBadUnit.Text = vbNullString Then
                txtBadUnit.Text = 0
            End If
            
            '@金額計算
            Call prvblnTotalMoney_Cal()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtBadUnit_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtBadNum_Change
    '機　能：不良数量変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/02 (Fri) 09:53:53 S.Deguchi
    '更新日：2005/09/02 (Fri) 09:53:53
    '備　考：
    Private Sub txtBadNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtBadNum.Change

        Try

            If mblnEditFlag = True Then
                '@ﾌｫｰﾏｯﾄ変換
                txtBadNum.Text = Format$(CDec(txtBadNum.Text), CPstrDateFormatKanma)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtBadNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtBadNum_Validate
    '機　能：不良数量変更処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:29:39 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:29:39
    '備　考：
    Private Sub txtBadNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtBadNum.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@空欄の場合には「0」ｾｯﾄ
            If txtBadNum.Text = vbNullString Then
                txtBadNum.Text = 0
            End If
            
            '@金額計算
            Call prvblnTotalMoney_Cal()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtBadNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdForemanUp_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:35 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:22:36 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:22:36 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdForemanUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdForemanUp.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:30:37 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtHeadComments)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtHeadComments, CMlngMaxDispRow, cmdForemanUp, cmdForemanDown)
        '@↑2005/12/05 (Mon) 13:30:37 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdForemanUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdForemanDown_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:37 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:31:38 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:31:38 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdForemanDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdForemanDown.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:31:27 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtHeadComments)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtHeadComments, CMlngMaxDispRow, cmdForemanUp, cmdForemanDown)
        '@↑2005/12/05 (Mon) 13:31:27 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdForemanDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHeadComments_Change
    '機　能：作業長ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtHeadComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtHeadComments.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtHeadComments, CMlngMaxDispRow, cmdForemanUp, cmdForemanDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHeadComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHeadComments_KeyUp
    '機　能：作業長ｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtHeadComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHeadComments.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtHeadComments, CMlngMaxDispRow, cmdForemanUp, cmdForemanDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHeadComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHeadComments_MouseUp
    '機　能：作業長ｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txtHeadComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtHeadComments.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtHeadComments, CMlngMaxDispRow, cmdForemanUp, cmdForemanDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHeadComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdChiefUp_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:39 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:36:19 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:36:19 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdChiefUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChiefUp.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:36:17 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtManagerComemnts)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtManagerComemnts, CMlngMaxDispRow, cmdChiefUp, cmdChiefDown)
        '@↑2005/12/05 (Mon) 13:36:17 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdChiefUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdChiefDown_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:41:42 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:36:59 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:36:59 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdChiefDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChiefDown.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 13:36:57 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtManagerComemnts)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtManagerComemnts, CMlngMaxDispRow, cmdChiefUp, cmdChiefDown)
        '@↑2005/12/05 (Mon) 13:36:57 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdChiefDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtManagerComemnts_Change
    '機　能：課長ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtManagerComemnts_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtManagerComemnts.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtManagerComemnts, CMlngMaxDispRow, cmdChiefUp, cmdChiefDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtManagerComemnts_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtManagerComemnts_KeyUp
    '機　能：課長ｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtManagerComemnts_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtManagerComemnts.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtManagerComemnts, CMlngMaxDispRow, cmdChiefUp, cmdChiefDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtManagerComemnts_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtManagerComemnts_MouseUp
    '機　能：課長ｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtManagerComemnts_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtManagerComemnts.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtManagerComemnts, CMlngMaxDispRow, cmdChiefUp, cmdChiefDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtManagerComemnts_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@ssTab2**************************************************ここまで

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvfrmxxCM00H2_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 21:29:46 S.Deguchi
    '更新日：2005/12/06 (Tue) 10:14:00 N.Kasai
    '備　考：
    '　　　：2005/12/06 (Tue) 10:14:00 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub prvfrmxxCM00H2_Init()
        
        Try

            '@退避領域を初期化
            mstrOccurTeam = vbNullString
            mstrOccurName = vbNullString
            mstrDeptID = vbNullString
            mstrExcpInsFlag = vbNullString
            mblnFormLoadFlag = False
            mstrSBID = vbNullString
            
            '@作業ﾐｽ報告書１の初期化
            Call prvtab1_Init()
            
        '@↓2005/12/06 (Tue) 10:14:15 N.Kasai **************************************************
            '@ｽｸﾛｰﾙﾎﾞﾀﾝ初期化
            cmdWorkMemoUp.Enabled = False       '発生状況▲ﾎﾞﾀﾝ
            cmdWorkMemoDown.Enabled = False     '発生状況▼ﾎﾞﾀﾝ
        '@↑2005/12/06 (Tue) 10:14:15 N.Kasai **************************************************
          
            
            '@作業ﾐｽ報告書２の初期化
            Call prvtab2_Init()
            
        '@↓2005/12/06 (Tue) 10:19:46 N.Kasai **************************************************
            '@ｽｸﾛｰﾙﾎﾞﾀﾝ初期化
            '@原因
            cmdCauseUp1.Enabled = False         '標準▲ﾎﾞﾀﾝ
            cmdCauseDown1.Enabled = False       '標準▼ﾎﾞﾀﾝ
            cmdCauseUp2.Enabled = False         '教育▲ﾎﾞﾀﾝ
            cmdCauseDown2.Enabled = False       '教育▼ﾎﾞﾀﾝ
            cmdCauseUp3.Enabled = False         '本人▲ﾎﾞﾀﾝ
            cmdCauseDown3.Enabled = False       '本人▼ﾎﾞﾀﾝ
            cmdCauseUp4.Enabled = False         '装置▲ﾎﾞﾀﾝ
            cmdCauseDown4.Enabled = False       '装置▼ﾎﾞﾀﾝ
            '@対策
            cmdTaskUp1.Enabled = False          '標準▲ﾎﾞﾀﾝ
            cmdTaskDown1.Enabled = False        '標準▼ﾎﾞﾀﾝ
            cmdTaskUp2.Enabled = False          '教育▲ﾎﾞﾀﾝ
            cmdTaskDown2.Enabled = False        '教育▼ﾎﾞﾀﾝ
            cmdTaskUp3.Enabled = False          '本人▲ﾎﾞﾀﾝ
            cmdTaskDown3.Enabled = False        '本人▼ﾎﾞﾀﾝ
            cmdTaskUp4.Enabled = False          '装置▲ﾎﾞﾀﾝ
            cmdTaskDown4.Enabled = False        '装置▼ﾎﾞﾀﾝ
            '@作業長ｺﾒﾝﾄ
            cmdForemanUp.Enabled = False        '▲ﾎﾞﾀﾝ
            cmdForemanDown.Enabled = False      '▼ﾎﾞﾀﾝ
            '@課長ｺﾒﾝﾄ
            cmdChiefUp.Enabled = False          '▲ﾎﾞﾀﾝ
            cmdChiefDown.Enabled = False        '▼ﾎﾞﾀﾝ
        '@↑2005/12/06 (Tue) 10:19:46 N.Kasai **************************************************
            
            '@表示Tab制御
            tabControl.SelectedIndex = CMlngssTab1
            
            '@表示しているTab以外はﾌｫｰｶｽを移動しないように制御する
            'fraMiss1.Enabled = True
            'fraMiss2.Enabled = False
            
            '@確定ﾎﾞﾀﾝを非活性化
            cmdRegist.Enabled = False
            
            '@「閉じる」ﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00H2_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab1_Init
    '機　能：Tab1の画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 21:33:28 S.Deguchi
    '更新日：2004/08/25 (Wed) 21:33:28
    '備　考：
    Private Sub prvtab1_Init()

        Try
            
            '@大元のﾌﾚｰﾑを活性化する
            fraMiss1.Enabled = True

            '@ﾗﾍﾞﾙの初期化
            lblDate.Text = vbNullString          '発見日時
            lblFindName.Text = vbNullString      '発見者
            lblNo.Text = vbNullString            '工程異常№
            lblOccurOpID.Text = vbNullString     '大工程
            lblOccurStepID.Text = vbNullString   '小工程
            lblOccurWpID.Text = vbNullString     '装置名
            lblPdID.Text = vbNullString          '機種名
            '各枚数
            lblNum1.Text = vbNullString
            lblNum2.Text = vbNullString
            lblNum3.Text = vbNullString
            lblNum4.Text = vbNullString
            lblNum5.Text = vbNullString
            lblNum6.Text = vbNullString
            lblNum7.Text = vbNullString
            lblNum8.Text = vbNullString
            
            '@ﾃｷｽﾄの初期化
            txtProYear.Text = vbNullString          '製造経験年
            txtProMonth.Text = vbNullString         '製造経験月
            txtExpYear.Text = vbNullString          '工程経験年
            txtExpMonth.Text = vbNullString         '工程経験月
            txtWFNo.Text = vbNullString             'wf№
            txtOccurComments.Text = vbNullString    '発生状況
            
            '@ｺﾝﾎﾞの初期化
            cmbOccurName.Clear                      '発生者
            cmbOccurTeam.Clear                      '発生職場
            cmbLotList.Clear                        'ﾛｯﾄﾘｽﾄ
            
            '@ｵﾌﾟｼｮﾝの初期化
            optKubun1.Checked = True                '区分
            optKubun2.Checked = False
            optKubun3.Checked = False
            optKubun4.Checked = False
            optKubun5.Checked = False
            
            optMissKubun1.Checked = True            '発生区分
            optMissKubun2.Checked = False
            optMissKubun3.Checked = False
            optMissKubun4.Checked = False
            optMissKubun5.Checked = False
            optMissKubun6.Checked = False
            optMissKubun7.Checked = False
            optMissKubun8.Checked = False
            optMissKubun9.Checked = False
            optMissKubun10.Checked = False
            optMissKubun11.Checked = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab1_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab2_Init
    '機　能：Tab2の画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 21:33:31 S.Deguchi
    '更新日：2004/08/25 (Wed) 21:33:31
    '備　考：
    Private Sub prvtab2_Init()

        Try

            '@大元のﾌﾚｰﾑを活性化する
            fraMiss2.Enabled = True

            '@ﾗﾍﾞﾙの初期化
            lblReTotal.Text = vbNullString           '再生金額
            lblBadTotal.Text = vbNullString          '不良金額
            lblTotal.Text = vbNullString             '合計
            
            '@ﾃｷｽﾄの初期化
            txtCause1.Text = vbNullString               '１．原因
            txtTask1.Text = vbNullString                '１．対策
            txtCause2.Text = vbNullString               '２．原因
            txtTask2.Text = vbNullString                '２．対策
            txtCause3.Text = vbNullString               '３．原因
            txtTask3.Text = vbNullString                '３．対策
            txtCause4.Text = vbNullString               '４．原因
            txtTask4.Text = vbNullString                '４．対策
            txtReUnit.Text = vbNullString               '再生金額単価
            txtReNum.Text = vbNullString                '再生金額数量
            txtBadUnit.Text = vbNullString              '不良金額単価
            txtBadNum.Text = vbNullString               '不良金額数量
            txtHeadComments.Text = vbNullString         '作業長ｺﾒﾝﾄ
            txtManagerComemnts.Text = vbNullString      '課長ｺﾒﾝﾄ
            
            '@ｶﾚﾝﾀﾞｰ設定
            calTaskDate1.Value = CPstrNullDate          '１．対策日付
            With calTaskDate1
                .CalendarHeight = CPlngMClHeight
                .CalendarWidth = CPlngMClWidth
                .DayFont = New Font(.Font.FontFamily, CPlngMClFontSize, .Font.Style, _
                                         .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .TitleFont = New Font(.Font.FontFamily, CPlngMClTlFontSize, .Font.Style, _
                                         .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .GridFont =  New Font(.Font.FontFamily, CPlngMClGridFontSize, .Font.Style, _
                                         .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
            End With
            
            calTaskDate2.Value = CPstrNullDate          '２．対策日付
            With calTaskDate2
                .CalendarHeight = CPlngMClHeight
                .CalendarWidth = CPlngMClWidth
                .DayFont = New Font(.Font.FontFamily, CPlngMClFontSize, .Font.Style, _
                                         .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .TitleFont = New Font(.Font.FontFamily, CPlngMClTlFontSize, .Font.Style, _
                                         .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .GridFont =  New Font(.Font.FontFamily, CPlngMClGridFontSize, .Font.Style, _
                                         .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
            End With
            
            calTaskDate3.Value = CPstrNullDate          '３．対策日付
            With calTaskDate3
                .CalendarHeight = CPlngMClHeight
                .CalendarWidth = CPlngMClWidth
                .DayFont = New Font(.Font.FontFamily, CPlngMClFontSize, .Font.Style, _
                                         .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .TitleFont = New Font(.Font.FontFamily, CPlngMClTlFontSize, .Font.Style, _
                                         .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .GridFont =  New Font(.Font.FontFamily, CPlngMClGridFontSize, .Font.Style, _
                                         .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
            End With
            
            calTaskDate4.Value = CPstrNullDate          '４．対策日付
            With calTaskDate4
                .CalendarHeight = CPlngMClHeight
                .CalendarWidth = CPlngMClWidth
                .DayFont = New Font(.Font.FontFamily, CPlngMClFontSize, .Font.Style, _
                                         .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .TitleFont = New Font(.Font.FontFamily, CPlngMClTlFontSize, .Font.Style, _
                                         .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .GridFont =  New Font(.Font.FontFamily, CPlngMClGridFontSize, .Font.Style, _
                                         .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab2_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM00H2_Disp
    '機　能：画面の取得/引継いだ情報をｾｯﾄする
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 22:26:17 S.Deguchi
    '更新日：2004/08/25 (Wed) 22:26:17
    '備　考：
    Private Sub prvfrmxxCM00H2_Disp()

        Try

            '@編集ﾌﾗｸﾞを立てる
            mblnEditFlag = True
            
            '@作業ﾐｽ報告書１の表示
            Call prvtab1_Disp()
            
            '@作業ﾐｽ報告書２の表示
            Call prvtab2_Disp()

            '@ﾛｯﾄ情報を画面表示
            Call prvtab1LotInfo_Disp()
            
            '@金額計算
            Call prvblnTotalMoney_Cal()
            
            '@引継ぎ承認ﾌﾗｸﾞによるﾌｫｰﾑのﾛｯｸ
            If mstrExcpInsFlag = CMstrExcpFlag2 Then
                Call prvtab1_Lock()
                Call prvtab2_Lock()
                
                cmdRegist.Enabled = False
            End If
            
            '@編集ﾌﾗｸﾞを初期化
            mblnEditFlag = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00H2_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab1_Disp
    '機　能：Tab1の画面に情報をｾｯﾄする
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 22:26:12 S.Deguchi
    '更新日：2004/08/25 (Wed) 22:26:12
    '備　考：
    Private Sub prvtab1_Disp()

        Try
            
            With mtypExcpWKReportList
                If .strGenDate <> vbNullString Then         '発生日付
                    lblDate.Text = Format$(CDate(.strGenDate), CPstrDateTimeYMDHM)
                Else
                    lblDate.Text = .strGenDate
                End If
                lblFindName.Text = .strFindEmpName          '発見者
                
                cmbOccurTeam.Text = .strGenDeptName         '発生職場
                cmbOccurName.Text = .strGenEmpName          '発生者
                
                txtProYear.Text = .strManuExpYear           '製造年数
                txtProMonth.Text = .strManuExpMon           '製造月数
                
                '@社員区分
                Select Case .strEmpFlag
                    Case CMstrKubun0
                        optKubun1.Checked = True
                        
                    Case CMstrKubun1
                        optKubun2.Checked = True
                    
                    Case CMstrKubun2
                        optKubun3.Checked = True
                    
                    Case CMstrKubun3
                        optKubun4.Checked = True
                    
                    Case CMstrKubun4
                        optKubun5.Checked = True
                End Select
                
                txtExpYear.Text = .strProcExpYear           '経験年数
                txtExpMonth.Text = .strProcExpMon           '経験月数
                
                txtWFNo.Text = .strWfNoComments             'wf№ｺﾒﾝﾄ
                
                txtOccurComments.Text = .strGenComments     '発生ｺﾒﾝﾄ
                
                '@ﾐｽ区分
                Select Case .strClass
                    Case CMstrKubunA
                        optMissKubun1.Checked = True
                        
                        '@確定ﾎﾞﾀﾝを活性化
                        cmdRegist.Enabled = True
                        
                    Case CMstrKubunB
                        optMissKubun2.Checked = True
                    
                        '@確定ﾎﾞﾀﾝを活性化
                        cmdRegist.Enabled = True
                        
                    Case CMstrKubunC
                        optMissKubun3.Checked = True
                    
                        '@確定ﾎﾞﾀﾝを活性化
                        cmdRegist.Enabled = True
                        
                    Case CMstrKubunD
                        optMissKubun4.Checked = True
                    
                        '@確定ﾎﾞﾀﾝを活性化
                        cmdRegist.Enabled = True
                        
                    Case CMstrKubunE
                        optMissKubun5.Checked = True
                    
                        '@確定ﾎﾞﾀﾝを活性化
                        cmdRegist.Enabled = True
                        
                    Case CMstrKubunF
                        optMissKubun6.Checked = True
                    
                        '@確定ﾎﾞﾀﾝを活性化
                        cmdRegist.Enabled = True
                        
                    Case CMstrKubunG
                        optMissKubun7.Checked = True
                    
                        '@確定ﾎﾞﾀﾝを活性化
                        cmdRegist.Enabled = True
                        
                    Case CMstrKubunH
                        optMissKubun8.Checked = True
                    
                        '@確定ﾎﾞﾀﾝを活性化
                        cmdRegist.Enabled = True
                        
                    Case CMstrKubunI
                        optMissKubun9.Checked = True
                    
                        '@確定ﾎﾞﾀﾝを活性化
                        cmdRegist.Enabled = True
                        
                    Case CMstrKubunJ
                        optMissKubun10.Checked = True
                    
                        '@確定ﾎﾞﾀﾝを活性化
                        cmdRegist.Enabled = True
                        
                    Case CMstrKubunK
                        optMissKubun11.Checked = True
                    
                        '@確定ﾎﾞﾀﾝを活性化
                        cmdRegist.Enabled = True
                        
                    Case Else           '(NUll)
                        optMissKubun1.Checked = False
                        optMissKubun2.Checked = False
                        optMissKubun3.Checked = False
                        optMissKubun4.Checked = False
                        optMissKubun5.Checked = False
                        optMissKubun6.Checked = False
                        optMissKubun7.Checked = False
                        optMissKubun8.Checked = False
                        optMissKubun9.Checked = False
                        optMissKubun10.Checked = False
                        optMissKubun11.Checked = False
                End Select
                
                '@退避領域にｾｯﾄ
                mstrOccurTeam = .strGenDeptName                     '発生職場
                mstrOccurName = .strGenEmpName                      '発生者
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab1_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab2_Disp
    '機　能：Tab2の画面に情報をｾｯﾄする
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 22:26:14 S.Deguchi
    '更新日：2004/08/25 (Wed) 22:26:14
    '備　考：2004/11/04 (Thu) 13:44:15 S.Deguchi 各Flag/金額の部分で型一致ｴﾗｰが出ないように修正
    Private Sub prvtab2_Disp()

        Try

            With mtypExcpWKReportList
                '@標準
                If .strStrdFlag = "0" Then                      '関連ﾌﾗｸﾞ
                    opt1AriNashi0.Checked = True
                Else
                    opt1AriNashi1.Checked = True
                End If
                txtCause1.Text = .strStrdCause                  '原因
                txtTask1.Text = .strStrdMeasure                 '対策
                If .strStrdInputDate <> vbNullString Then       '日付
                    calTaskDate1.Value = Format$(CDate(.strStrdInputDate), _
                                     CPstrDateTimeYMD)          
                Else
                    calTaskDate1.Value = .strStrdInputDate
                End If
                
                '@教育
                If .strEduFlag = "0" Then                       '関連ﾌﾗｸﾞ
                    opt2AriNashi0.Checked = True
                Else
                    opt2AriNashi1.Checked = True
                End If
                txtCause2.Text = .strEduCause                   '原因
                txtTask2.Text = .strEduMeasure                  '対策
                If .strEduInputDate <> vbNullString Then        '日付
                    calTaskDate2.Value = Format$(CDate(.strEduInputDate), _
                                     CPstrDateTimeYMD)
                Else
                    calTaskDate2.Value = .strEduInputDate
                End If
                
                '@人
                If .strHimFlag = "0" Then                       '関連ﾌﾗｸﾞ
                    opt3AriNashi0.Checked = True
                Else
                    opt3AriNashi1.Checked = True
                End If
                txtCause3.Text = .strHimCause                   '原因
                txtTask3.Text = .strHimMeasure                  '対策
                If .strHimInputDate <> vbNullString Then        '日付
                    calTaskDate3.Value = Format$(CDate(.strHimInputDate), _
                                     CPstrDateTimeYMD)          '日付
                Else
                    calTaskDate3.Value = .strHimInputDate
                End If
                
                '@装置
                If .strEqpFlag = "0" Then                       '関連ﾌﾗｸﾞ
                    opt4AriNashi0.Checked = True
                Else
                    opt4AriNashi1.Checked = True
                End If
                txtCause4.Text = .strEqpCause                   '原因
                txtTask4.Text = .strEqpMeasure                  '対策
                If .strEqpInputDate <> vbNullString Then        '日付
                    calTaskDate4.Value = Format$(CDate(.strEqpInputDate), _
                                     CPstrDateTimeYMD)          '日付
                Else
                    calTaskDate4.Value = .strEqpInputDate
                End If
                
                '@金額計算
                If .strReproPrice <> vbNullString Then
                    txtReUnit.Text = Format$(CDec(.strReproPrice), CPstrDateFormatKanma)          '再生単価
                Else
                    txtReUnit.Text = 0
                End If
                If .strReproQuantity <> vbNullString Then
                    txtReNum.Text = Format$(CDec(.strReproQuantity), CPstrDateFormatKanma)        '再生数量
                Else
                    txtReNum.Text = 0
                End If
                If .strDefectPrice <> vbNullString Then
                    txtBadUnit.Text = Format$(CDec(.strDefectPrice), CPstrDateFormatKanma)        '不良単価
                Else
                    txtBadUnit.Text = 0
                End If
                If .strDefectQuantity <> vbNullString Then
                    txtBadNum.Text = Format$(CDec(.strDefectQuantity), CPstrDateFormatKanma)      '不良数量
                Else
                    txtBadNum.Text = 0
                End If
                
                '@長ｺﾒﾝﾄ
                txtHeadComments.Text = .strForemanComments      '作業長ｺﾒﾝﾄ
                txtManagerComemnts.Text = .strChiefComments     '課長ｺﾒﾝﾄ
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab2_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab1LotInfo_Disp
    '機　能：引継いだﾛｯﾄ情報を画面にｾｯﾄする
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:50:15 S.Deguchi
    '更新日：2004/08/26 (Thu) 10:50:15
    '備　考：
    Private Sub prvtab1LotInfo_Disp()

        Dim llngCnt     As Integer                              'ｶｳﾝﾄ
        Dim llngHOLD    As Integer                              '保留枚数
        Dim llngABANDON As Integer                              '廃却枚数
        Dim llngAMEND   As Integer                              '手直し枚数
        Dim llngCORRECT As Integer                              '修正枚数
        Dim llngUSUAL   As Integer                              '通常枚数
        Dim llngEVAL    As Integer                              '評価枚数
        Dim llngTAKE    As Integer                              '特採枚数
        Dim llngToTal   As Integer                              '合計(対象枚数)

        Try
            
            '@情報をｾｯﾄ
            With ptypWkReportConnect
                lblNo.Text = .strExcpNo                          '異常処理№
                lblOccurOpID.Text = .strFindOpIDName             '大工程
                lblOccurStepID.Text = .strFindStepIDName         '小工程
                lblOccurWpID.Text = .strFindWpName               '装置名
                lblPdID.Text = .strPdId                          '機種
                
                '@枚数計算
                For llngCnt = 0 To .lngLotListCnt - 1
                    llngHOLD = llngHOLD + CLng(.typLotList(llngCnt).strWFReserveQuantity)
                    llngABANDON = llngABANDON + CLng(.typLotList(llngCnt).strWFAbandonQuantity)
                    llngAMEND = llngAMEND + CLng(.typLotList(llngCnt).strWFAmendQuantity)
                    llngCORRECT = llngCORRECT + CLng(.typLotList(llngCnt).strWFCorrectQuantity)
                    llngEVAL = llngEVAL + CLng(.typLotList(llngCnt).strWFEvalQuantity)
                    llngTAKE = llngTAKE + CLng(.typLotList(llngCnt).strWFTakeQuantity)
                    llngUSUAL = llngUSUAL + CLng(.typLotList(llngCnt).strWFUsualQuantity)
                    
                    '@対象枚数の計算
                    llngToTal = CLng(llngHOLD) _
                              + CLng(llngABANDON) _
                              + CLng(llngAMEND) _
                              + CLng(llngCORRECT) _
                              + CLng(llngEVAL) _
                              + CLng(llngTAKE) _
                              + CLng(llngUSUAL)
                Next llngCnt
                
                lblNum1.Text = llngToTal
                lblNum2.Text = llngUSUAL
                lblNum3.Text = llngAMEND
                lblNum4.Text = llngCORRECT
                lblNum5.Text = llngTAKE
                lblNum6.Text = llngEVAL
                lblNum7.Text = llngABANDON
                lblNum8.Text = llngHOLD
            End With
                
            '@ﾛｯﾄﾘｽﾄ作成
            If ptypWkReportConnect.lngLotListCnt > 0 Then
                With cmbLotList
                    .Clear                                              '初期化
                    .DirectInput = False                                '直接入力不可

                    .GroupRows = ptypWkReportConnect.lngLotListCnt      'ｸﾞﾙｰﾌﾟﾛｳ
                    .BackColor = Color.White                            'ﾊﾞｯｸｶﾗｰ(白)
                    '@ﾘｽﾄ設定
                    For llngCnt = 0 To ptypWkReportConnect.lngLotListCnt - 1
                        .AddItem(ptypWkReportConnect.typLotList(llngCnt).strLotID)
                    Next llngCnt
                    
                    '@1件の場合は表示する
                    .ListIndex = 0
                End With
            
                '@ｺﾝﾎﾞを使用可能とする
                cmbLotList.Enabled = True
            Else
                '@ｺﾝﾎﾞを使用不可とする
                cmbLotList.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab1LotInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvConnectInfo_Set
    '機　能：引継いだ情報をﾓｼﾞｭｰﾙ変数へｾｯﾄする
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:51:11 S.Deguchi
    '更新日：2004/08/26 (Thu) 10:51:11
    '備　考：
    Private Sub prvConnectInfo_Set()

        Try

            With mtypExcpWKReportList
                .strExcpNo = ptypWkReportConnect.strExcpNo                          '異常処理№
                .strGenDate = ptypWkReportConnect.strGenDate                        '発生日時
                .strGenEmpName = ptypWkReportConnect.strGenEmpName                  '発生者
                .strGenDeptName = ptypWkReportConnect.strGenDeptName                '発生職場
                .strFindEmpName = ptypWkReportConnect.strFindEmpName                '発見者
                
                .strManuExpYear = 0                                                 '製造経験年数
                .strManuExpMon = 0                                                  '製造経験月数
                .strEmpFlag = 0                                                     '社員区分
                .strProcExpYear = 0                                                 '工程経験年数
                .strProcExpMon = 0                                                  '工程経験月数
                .strGenComments = vbNullString                                      '発生ｺﾒﾝﾄ
                .strClass = vbNullString                                            '区分(Null)
                
                .strStrdFlag = 0                                                    '標準：ﾌﾗｸﾞ
                .strStrdCause = vbNullString                                        '標準：原因
                .strStrdMeasure = vbNullString                                      '標準：対策
                .strStrdInputDate = vbNullString                                    '標準：日付
                
                .strEduFlag = 0                                                     '教育：ﾌﾗｸﾞ
                .strEduCause = vbNullString                                         '教育：原因
                .strEduMeasure = vbNullString                                       '教育：対策
                .strEduInputDate = vbNullString                                     '教育：日付
                
                .strHimFlag = 0                                                     '人：ﾌﾗｸﾞ
                .strHimCause = vbNullString                                         '人：原因
                .strHimMeasure = vbNullString                                       '人：対策
                .strHimInputDate = vbNullString                                     '人：日付
                
                .strEqpFlag = 0                                                     '装置：ﾌﾗｸﾞ
                .strEqpCause = vbNullString                                         '装置：原因
                .strEqpMeasure = vbNullString                                       '装置：対策
                .strEqpInputDate = vbNullString                                     '装置：日付
                
                .strReproPrice = 0                                                  '再生単価
                .strReproQuantity = 0                                               '再生数量
                .strDefectPrice = 0                                                 '不良単価
                .strDefectQuantity = 0                                              '不良数量
                
                .strForemanComments = vbNullString                                  '作業長ｺﾒﾝﾄ
                .strChiefComments = vbNullString                                    '課長ｺﾒﾝﾄ
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvConnectInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab1_Set
    '機　能：Tab1の内容を登録構造体に情報をｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 13:39:34 S.Deguchi
    '更新日：2004/08/26 (Thu) 13:39:34
    '備　考：
    Private Sub prvtab1_Set()

        Try

            With mtypExcpWKReportList
                .strGenEmpName = cmbOccurName.Text                  '発生者
                .strGenDeptName = cmbOccurTeam.Text                 '発生職場
                .strManuExpYear = txtProYear.Text                   '製造年数
                .strManuExpMon = txtProMonth.Text                   '製造月数
                .strProcExpYear = txtExpYear.Text                   '経験年数
                .strProcExpMon = txtExpMonth.Text                   '経験月数
                
                '@社員区分
                If optKubun1.Checked = True Then                    '正規
                    .strEmpFlag = CMstrKubun0
                End If
                If optKubun2.Checked = True Then                    '特務
                    .strEmpFlag = CMstrKubun1
                End If
                If optKubun3.Checked = True Then                    '応援
                    .strEmpFlag = CMstrKubun2
                End If
                If optKubun4.Checked = True Then                    '日総正規
                    .strEmpFlag = CMstrKubun3
                End If
                If optKubun5.Checked = True Then                    '日総期間
                    .strEmpFlag = CMstrKubun4
                End If
            
                .strWfNoComments = txtWFNo.Text                     'wf№
                .strGenComments = txtOccurComments.Text             '発生ｺﾒﾝﾄ
                
                '@区分
                If optMissKubun1.Checked = True Then                'A
                    .strClass = CMstrKubunA
                End If
                If optMissKubun2.Checked = True Then                'B
                    .strClass = CMstrKubunB
                End If
                If optMissKubun3.Checked = True Then                'C
                    .strClass = CMstrKubunC
                End If
                If optMissKubun4.Checked = True Then                'D
                    .strClass = CMstrKubunD
                End If
                If optMissKubun5.Checked = True Then                'E
                    .strClass = CMstrKubunE
                End If
                If optMissKubun6.Checked = True Then                'F
                    .strClass = CMstrKubunF
                End If
                If optMissKubun7.Checked = True Then                'G
                    .strClass = CMstrKubunG
                End If
                If optMissKubun8.Checked = True Then                'H
                    .strClass = CMstrKubunH
                End If
                If optMissKubun9.Checked = True Then                'I
                    .strClass = CMstrKubunI
                End If
                If optMissKubun10.Checked = True Then               'J
                    .strClass = CMstrKubunJ
                End If
                If optMissKubun11.Checked = True Then               'K
                    .strClass = CMstrKubunK
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab1_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab2_Set
    '機　能：Tab2の内容を登録構造体に情報をｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 13:39:36 S.Deguchi
    '更新日：2004/08/26 (Thu) 13:39:36
    '備　考：
    Private Sub prvtab2_Set()

        Try

            With mtypExcpWKReportList
                '@標準項目
                If opt1AriNashi0.Checked = True Then            'ﾌﾗｸﾞ
                    .strStrdFlag = "0"
                Else
                    .strStrdFlag = "1"
                End If
                .strStrdCause = txtCause1.Text                  '原因ｺﾒﾝﾄ
                .strStrdMeasure = txtTask1.Text                 '対策ｺﾒﾝﾄ
                If calTaskDate1.Value = CPstrNullDate Then
                    .strStrdInputDate = vbNullString            '対策日付(Null)
                Else
                    .strStrdInputDate = calTaskDate1.Value      '対策日付(ｶﾚﾝﾀﾞ)
                End If
            
                '@教育項目
                If opt2AriNashi0.Checked = True Then            'ﾌﾗｸﾞ
                    .strEduFlag = "0"
                Else
                    .strEduFlag = "1"
                End If
                .strEduCause = txtCause2.Text                  '原因ｺﾒﾝﾄ
                .strEduMeasure = txtTask2.Text                 '対策ｺﾒﾝﾄ
                If calTaskDate2.Value = CPstrNullDate Then
                    .strEduInputDate = vbNullString            '対策日付(Null)
                Else
                    .strEduInputDate = calTaskDate2.Value      '対策日付(ｶﾚﾝﾀﾞ)
                End If
            
                '@人項目
                If opt3AriNashi0.Checked = True Then            'ﾌﾗｸﾞ
                    .strHimFlag = "0"
                Else
                    .strHimFlag = "1"
                End If
                .strHimCause = txtCause3.Text                  '原因ｺﾒﾝﾄ
                .strHimMeasure = txtTask3.Text                 '対策ｺﾒﾝﾄ
                If calTaskDate3.Value = CPstrNullDate Then
                    .strHimInputDate = vbNullString            '対策日付(Null)
                Else
                    .strHimInputDate = calTaskDate3.Value      '対策日付(ｶﾚﾝﾀﾞ)
                End If
            
                '@装置項目
                If opt4AriNashi0.Checked = True Then            'ﾌﾗｸﾞ
                    .strEqpFlag = "0"
                Else
                    .strEqpFlag = "1"
                End If
                .strEqpCause = txtCause4.Text                  '原因ｺﾒﾝﾄ
                .strEqpMeasure = txtTask4.Text                 '対策ｺﾒﾝﾄ
                If calTaskDate4.Value = CPstrNullDate Then
                    .strEqpInputDate = vbNullString            '対策日付(Null)
                Else
                    .strEqpInputDate = calTaskDate4.Value      '対策日付(ｶﾚﾝﾀﾞ)
                End If
            
                '@金額
                .strReproPrice = Format$(CDec(txtReUnit.Text), CPstrNoKanmaFormat)                '再生単価
                .strReproQuantity = Format$(CDec(txtReNum.Text), CPstrNoKanmaFormat)              '再生数量
                .strDefectPrice = Format$(CDec(txtBadUnit.Text), CPstrNoKanmaFormat)              '不良単価
                .strDefectQuantity = Format$(CDec(txtBadNum.Text), CPstrNoKanmaFormat)            '不良数量
                
                '@ｺﾒﾝﾄ
                .strForemanComments = txtHeadComments.Text      '作業長
                .strChiefComments = txtManagerComemnts.Text     '課長
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab2_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbOccurTeam_Disp
    '機　能：部署ｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 15:21:51 S.Deguchi
    '更新日：2004/08/26 (Thu) 15:21:51
    '備　考：
    Private Sub prvcmbOccurTeam_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbOccurTeam
                '@所属ｺﾝﾎﾞ初期化
                .Clear
                .DirectInput = False
                .Height = CMlngCmbRowHeight                                     '高さ
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .Font = New Font(.Font.FontFamily, 9, .Font.Style, .Font.Unit)  'ﾌｫﾝﾄｻｲｽﾞ設定
                .BackColor = Color.White                                        'ﾊﾞｯｸｶﾗｰ(白)
                .GroupRows = mtypDepartmentList.lngDepartmentListCnt
                
                '@機種情報ｾｯﾄ
                For llngCnt = 0 To mtypDepartmentList.lngDepartmentListCnt - 1
                    .AddItem(mtypDepartmentList.typDepartmentList(llngCnt).strDeptName & _
                             vbTab & _
                             mtypDepartmentList.typDepartmentList(llngCnt).strDeptCode)             '所属名&所属ID
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbOccurTeam_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbDeptEmpList_Disp
    '機　能：発生者(発生者)Combo作成
    '引　数：ltypDeptEmpList:発生者構造体
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 15:32:16 S.Deguchi
    '更新日：2004/08/26 (Thu) 15:32:16
    '備　考：
    Private Sub prvcmbDeptEmpList_Disp(ByRef ltypDeptEmpList As DeptEmpInfo)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbOccurName
                '@所属ｺﾝﾎﾞ(依頼者)初期化
                .Clear
                .DirectInput = False
                .Height = CMlngCmbRowHeight                                     '高さ
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .BackColor = Color.White                                        'ﾊﾞｯｸｶﾗｰ(白)
                .GroupRows = ltypDeptEmpList.lngDeptEmpListCnt
                
                '@機種情報ｾｯﾄ
                For llngCnt = 0 To ltypDeptEmpList.lngDeptEmpListCnt - 1
                    .AddItem(ltypDeptEmpList.typDeptEmpList(llngCnt).strEmpName & _
                             vbTab & _
                             ltypDeptEmpList.typDeptEmpList(llngCnt).strEmpID)              '発生者名&発生者ID
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbDeptEmpList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnMasDeptEmpList_Sel
    '機　能：社員一覧を取得する
    '引　数：lstrDeptID：所属ID
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/26 (Thu) 11:50:43 S.Deguchi
    '更新日：2004/08/26 (Thu) 11:50:43
    '備　考：
    Private Function prvblnMasDeptEmpList_Sel(ByVal lstrDeptID As String) As Boolean

        Dim lblnAns                 As Boolean              '結果格納

        Try
            
            '@初期化
            prvblnMasDeptEmpList_Sel = False
            
            '@発生者名取得
            lblnAns = pubblnMasDeptEmpList_Sel(CMstrmasdeptemplistVer, _
                                               lstrDeptID, _
                                               mtypDeptEmpList)
            '@結果判定
            If lblnAns = False Then

                Exit Function
            Else
                prvblnMasDeptEmpList_Sel = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnMasDeptEmpList_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnExcpWKReportInfo_Sel
    '機　能：作業ﾐｽ報告書情報取得
    '引　数：lstrExcpNo：異常処理№
    '　　　：lstrResultFlag：結果判定ﾌﾗｸﾞ
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/26 (Thu) 10:46:24 S.Deguchi
    '更新日：2004/08/26 (Thu) 10:46:24
    '備　考：2004/09/21 (Tue) 14:41:07 S.Deguchi ｼｽﾃﾑﾌﾞﾛｯｸ対応
    '　　　：2004/11/04 (Thu) 16:49:55 S.Deguchi 情報取得ﾒｯｾｰｼﾞに結果判定ﾌﾗｸﾞを追加
    Private Function prvblnExcpWKReportInfo_Sel(ByVal lstrExcpNo As String, _
                                                ByRef lstrResultFlag As String) As Boolean

        Dim lblnAns                 As Boolean              '結果格納

        Try

            '@初期化
            prvblnExcpWKReportInfo_Sel = False
            
            lblnAns = pubblnExcpWKReportInfo_Sel(CMstrExcpWKReportInfoVer, _
                                                 mstrSBID, _
                                                 lstrExcpNo, _
                                                 mtypExcpWKReportList, _
                                                 lstrResultFlag)
            '@結果判定
            If lblnAns = False Then
                Exit Function
            Else
                prvblnExcpWKReportInfo_Sel = True
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnExcpWKReportInfo_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnTotalMoney_Cal
    '機　能：合計金額計算
    '引　数：なし
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/26 (Thu) 14:23:18 S.Deguchi
    '更新日：2004/08/26 (Thu) 14:23:18
    '備　考：
    Private Function prvblnTotalMoney_Cal() As Boolean

        Dim lCurReTotal     As Decimal          '再生合計
        Dim lCurBadTotal    As Decimal          '不良合計

        Try

            '@初期化
            prvblnTotalMoney_Cal = False
            
            '@再生金額計算
            lCurReTotal = CDec(txtReUnit.Text) * CDec(txtReNum.Text)

            '@再生金額計算
            lCurBadTotal = CDec(txtBadUnit.Text) * CDec(txtBadNum.Text)

            '@画面表記
            lblReTotal.Text = Format$(lCurReTotal, CPstrDateFormatKanma)
            lblBadTotal.Text = Format$(lCurBadTotal, CPstrDateFormatKanma)
            lblTotal.Text = Format$((lCurReTotal + lCurBadTotal), CPstrDateFormatKanma) & CMstrEN
            
            prvblnTotalMoney_Cal = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnTotalMoney_Cal"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnRegist_Chk
    '機　能：確定処理ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/31 (Tue) 13:35:06 S.Deguchi
    '更新日：2004/08/31 (Tue) 13:35:06
    '備　考：
    Private Function prvblnRegist_Chk() As Boolean
        
        Dim llngCnt As Integer  'ｶｳﾝﾄ

        Try

            '@初期化
            prvblnRegist_Chk = False

            '@区分を選択することによって確定ﾎﾞﾀﾝを活性化する
            For llngCnt = CMlngopt1 To CMlngopt11
                If CType(Me.fraKubun2.Controls("optMissKubun" & llngCnt.ToString),RadioButton).Checked = True Then
                    '@確定OK
                    prvblnRegist_Chk = True
                
                    '@処理を抜ける
                    Exit Function
                End If
            Next llngCnt

            '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002G)
            
            '@「区分が選択されていません。設定を見直してください。」
            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvcmbEmpDept_Set
    '機　能：起動時に取得した発生者/発生職場のｺﾝﾎﾞ表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 09:22:59 S.Deguchi
    '更新日：2004/08/31 (Tue) 09:22:59
    '備　考：
    Private Sub prvcmbEmpDept_Set()

        Dim llngCnt         As Integer      'ｶｳﾝﾄ
        Dim llngLoopFlag    As Integer      'ﾙｰﾌﾟﾌﾗｸﾞ
        Dim llngLoopFlag1   As Integer      'ﾙｰﾌﾟﾌﾗｸﾞ
        Dim lblnAns         As Boolean      '結果格納

        Try
            
            '@ﾊﾟﾀｰﾝ①
            '@発生職場と発生者が空欄の場合
            If mstrOccurTeam = vbNullString And mstrOccurName = vbNullString Then
                '@発生職場ｺﾝﾎﾞのﾃｷｽﾄ部分にNullを設定
                cmbOccurTeam.Text = vbNullString
                
                '@発生者ｺﾝﾎﾞのﾃｷｽﾄ部分にNullを設定して使用不可として,ﾒｯｾｰｼﾞを表示する
                cmbOccurName.Text = vbNullString
                cmbOccurName.Enabled = False
                
                '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002C)
                
                '@「発生者職場が存在しません。発生者職場を見直してください。」
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            End If

            '@ﾊﾟﾀｰﾝ②
            '@発生職場が空欄で発生者が判明している場合
            If mstrOccurTeam = vbNullString And mstrOccurName <> vbNullString Then
                '@発生職場ｺﾝﾎﾞのﾃｷｽﾄ部分にNullを設定
                cmbOccurTeam.Text = vbNullString
                
                '@発生者ｺﾝﾎﾞのﾃｷｽﾄ部分にNullを設定して使用不可として,ﾒｯｾｰｼﾞを表示する
                cmbOccurName.Text = vbNullString
                cmbOccurName.Enabled = False
                
                '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002C)
                
                '@「発生者職場が存在しません。発生者職場を見直してください。」
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            End If

            '@ﾊﾟﾀｰﾝ③
            '@発生職場が判明していて発生者が空欄の場合
            If mstrOccurTeam <> vbNullString And mstrOccurName = vbNullString Then
                '@初期化
                llngLoopFlag = 0
                
                '@発生職場の名称から所属IDを取得する
                For llngCnt = 0 To mtypDepartmentList.lngDepartmentListCnt - 1
                    If mstrOccurTeam = mtypDepartmentList.typDepartmentList(llngCnt).strDeptName Then
                        '@退避領域にIDをｾｯﾄ
                        mstrDeptID = mtypDepartmentList.typDepartmentList(llngCnt).strDeptCode
                        
                        '@ﾌﾗｸﾞ変更(一致する名称があった)
                        llngLoopFlag = 1
                        
                        '@ﾙｰﾌﾟ抜け
                        Exit For
                    End If
                Next llngCnt
            
                '@ﾌﾗｸﾞにによる処理分岐
                If llngLoopFlag = 1 Then
                '@一致する名称があった場合
                    '@ｺﾝﾎﾞのﾃｷｽﾄ部分に名称をｾｯﾄ
                    cmbOccurTeam.Text = mstrOccurTeam
                    
                    '@社員名取得処理
                    lblnAns = prvblnMasDeptEmpList_Sel(mstrDeptID)
                    '@結果判定
                    If lblnAns = True Then
                        '@ｺﾝﾎﾞｾｯﾄ
                        Call prvcmbDeptEmpList_Disp(mtypDeptEmpList)
                    Else
                        '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002B)
                        
                        '@「発生者が存在しません。発生者職場を見直してください。」
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾃｷｽﾄ部にNullをｾｯﾄ
                        cmbOccurName.Text = vbNullString
                    End If
                    
                    '@発生者へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbOccurName)
                Else
                '@一致する名称がなかった場合
                    '@発生職場ｺﾝﾎﾞのﾃｷｽﾄ部分にNullを設定
                    cmbOccurTeam.Text = vbNullString
                    
                    '@発生者ｺﾝﾎﾞのﾃｷｽﾄ部分にNullを設定して使用不可として,ﾒｯｾｰｼﾞを表示する
                    cmbOccurName.Text = vbNullString
                    cmbOccurName.Enabled = False
                    
                    '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002C)
                    
                    '@「発生者職場が存在しません。発生者職場を見直してください。」
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If
            End If

            '@ﾊﾟﾀｰﾝ④
            '@発生職場が判明していて発生者も判明している場合
            If mstrOccurTeam <> vbNullString And mstrOccurName <> vbNullString Then
                '@初期化
                llngLoopFlag = 0
                
                '@発生職場の名称から所属IDを取得する
                For llngCnt = 0 To mtypDepartmentList.lngDepartmentListCnt - 1
                    If mstrOccurTeam = mtypDepartmentList.typDepartmentList(llngCnt).strDeptName Then
                        '@退避領域にIDをｾｯﾄ
                        mstrDeptID = mtypDepartmentList.typDepartmentList(llngCnt).strDeptCode
                        
                        '@ﾌﾗｸﾞ変更(一致する名称があった)
                        llngLoopFlag = 1
                        
                        '@ﾙｰﾌﾟ抜け
                        Exit For
                    End If
                Next llngCnt

                '@ﾌﾗｸﾞにによる処理分岐
                If llngLoopFlag = 1 Then
                '@一致する名称があった場合
                    '@ｺﾝﾎﾞのﾃｷｽﾄ部分に名称をｾｯﾄ
                    cmbOccurTeam.Text = mstrOccurTeam
                    
                    '@社員名取得処理
                    lblnAns = prvblnMasDeptEmpList_Sel(mstrDeptID)
                    '@結果判定
                    If lblnAns = True Then
                        '@ｺﾝﾎﾞｾｯﾄ
                        Call prvcmbDeptEmpList_Disp(mtypDeptEmpList)
                        
                        For llngCnt = 0 To mtypDeptEmpList.lngDeptEmpListCnt - 1
                            '@一致する名称があるか否かを検索する
                            If mstrOccurName = mtypDeptEmpList.typDeptEmpList(llngCnt).strEmpName Then
                                
                                '@ﾙｰﾌﾟﾌﾗｸﾞ変更
                                llngLoopFlag1 = 1
                                
                                '@ﾙｰﾌﾟ抜け
                                Exit For
                            End If
                        Next llngCnt
                        
                        If llngLoopFlag1 = 1 Then
                            '@ﾃｷｽﾄにｾｯﾄ
                            cmbOccurName.Text = mstrOccurName
                        Else
                            '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002B)
                            
                            '@「発生者が存在しません。発生者職場を見直してください。」
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@ﾃｷｽﾄ部にNullをｾｯﾄ
                            cmbOccurName.Text = vbNullString
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                '@一致する名称がなかった場合
                    '@発生職場ｺﾝﾎﾞのﾃｷｽﾄ部分にNullを設定
                    cmbOccurTeam.Text = vbNullString
                    
                    '@発生者ｺﾝﾎﾞのﾃｷｽﾄ部分にNullを設定して使用不可として,ﾒｯｾｰｼﾞを表示する
                    cmbOccurName.Text = vbNullString
                    cmbOccurName.Enabled = False
                    
                    '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002C)
                    
                    '@「発生者職場が存在しません。発生者職場を見直してください。」
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbEmpDept_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab1_Lock
    '機　能：Tab1の画面ｺﾝﾄﾛｰﾙﾛｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2005/09/02 (Fri) 10:32:25 S.Deguchi
    '更新日：2005/09/02 (Fri) 10:32:25
    '備　考：
    Private Sub prvtab1_Lock()

        Try

            '@ﾌﾚｰﾑﾛｯｸ
            'fraMiss1.Enabled = False
            cmbOccurName.Enabled = False
            cmbOccurTeam.Enabled = False
            cmbLotList.Enabled = False
            fraKubun1.Enabled = False
            fraKubun2.Enabled = False
            txtProMonth.Enabled = False
            txtProYear.Enabled = False
            txtExpMonth.Enabled = False
            txtExpYear.Enabled = False
            txtWFNo.Enabled = False
            cmdOccur.Enabled = False
            cmbOccurName.BackColor = Color.White    'ﾊﾞｯｸｶﾗｰ(白)
            
            '@ﾃｷｽﾄﾎﾞｯｸｽのﾛｯｸ
            txtOccurComments.Locked = True          '発生状況
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab1_Lock"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab2_Lock
    '機　能：Tab2の画面ｺﾝﾄﾛｰﾙﾛｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2005/09/02 (Fri) 10:32:25 S.Deguchi
    '更新日：2005/09/02 (Fri) 10:32:25
    '備　考：
    Private Sub prvtab2_Lock()

        Try

            '@ﾌﾚｰﾑﾛｯｸ
            'fraMiss2.Enabled = False
            fraUmu1.Enabled = False
            fraUmu2.Enabled = False
            fraUmu3.Enabled = False
            fraUmu4.Enabled = False
            txtReUnit.Enabled = False
            txtBadUnit.Enabled = False
            txtReNum.Enabled = False
            txtBadNum.Enabled = False
            calTaskDate1.Enabled = False
            calTaskDate2.Enabled = False
            calTaskDate3.Enabled = False
            calTaskDate4.Enabled = False
            calTaskDate1.BackColor = Color.White    'ﾊﾞｯｸｶﾗｰ(白)
            calTaskDate2.BackColor = Color.White    'ﾊﾞｯｸｶﾗｰ(白)
            calTaskDate3.BackColor = Color.White    'ﾊﾞｯｸｶﾗｰ(白)
            calTaskDate4.BackColor = Color.White    'ﾊﾞｯｸｶﾗｰ(白)

            '@ﾃｷｽﾄﾎﾞｯｸｽのﾛｯｸ
            txtCause1.Locked = True             '標準面：原因
            txtTask1.Locked = True              '標準面：対策
            txtCause2.Locked = True             '教育面：原因
            txtTask2.Locked = True              '教育面：対策
            txtCause3.Locked = True             '人：原因
            txtTask3.Locked = True              '人：対策
            txtCause4.Locked = True             '装置：原因
            txtTask4.Locked = True              '装置：対策
            
            txtHeadComments.Locked = True       '作業長ｺﾒﾝﾄ
            txtManagerComemnts.Locked = True    '課長ｺﾒﾝﾄ

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab2_Lock"
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

    '関数名：cursor_Enter
    '機　能 ： 項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmbOccurName.Enter,
                                                                       cmbOccurTeam.Enter,
                                                                       cmbLotList.Enter,
                                                                       cmdClose.Enter,
                                                                       cmdRegist.Enter,
                                                                       cmdOccur.Enter,
                                                                       cmdWorkMemoUp.Enter,
                                                                       cmdWorkMemoDown.Enter,
                                                                       cmdForemanUp.Enter,
                                                                       cmdForemanDown.Enter,
                                                                       cmdChiefUp.Enter,
                                                                       cmdChiefDown.Enter,
                                                                       cmdCauseDown1.Enter,
                                                                       cmdCauseUp1.Enter,
                                                                       cmdCauseDown2.Enter,
                                                                       cmdCauseUp2.Enter,
                                                                       cmdCauseDown3.Enter,
                                                                       cmdCauseUp3.Enter,
                                                                       cmdCauseDown4.Enter,
                                                                       cmdCauseUp4.Enter,
                                                                       cmdTaskDown1.Enter,
                                                                       cmdTaskUp1.Enter,
                                                                       cmdTaskDown2.Enter,
                                                                       cmdTaskUp2.Enter,
                                                                       cmdTaskDown3.Enter,
                                                                       cmdTaskUp3.Enter,
                                                                       cmdTaskDown4.Enter,
                                                                       cmdTaskUp4.Enter,
                                                                       txtProYear.Enter,
                                                                       txtProMonth.Enter,
                                                                       txtExpYear.Enter,
                                                                       txtExpMonth.Enter,
                                                                       txtWFNo.Enter,
                                                                       txtReUnit.Enter,
                                                                       txtReNum.Enter,
                                                                       txtBadUnit.Enter,
                                                                       txtBadNum.Enter,
                                                                       txtOccurComments.Enter,
                                                                       txtCause1.Enter,
                                                                       txtCause2.Enter,
                                                                       txtCause3.Enter,
                                                                       txtCause4.Enter,
                                                                       txtTask1.Enter,
                                                                       txtTask2.Enter,
                                                                       txtTask3.Enter,
                                                                       txtTask4.Enter,
                                                                       txtManagerComemnts.Enter,
                                                                       txtHeadComments.Enter,
                                                                       calTaskDate1.Enter,
                                                                       calTaskDate2.Enter,
                                                                       calTaskDate3.Enter,
                                                                       calTaskDate4.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = AutoValidate.Disable
                '自動Validate = ON
            Case Else
                Me.AutoValidate = AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
