'ﾌｧｲﾙ名：xxEN00O0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：投入予定ロット登録(品確、モニタ、ダミー)　メインフォーム
'作成日：2004/07/27 (Tue) 09:05:55 N.Kojima
'更新日：2011/04/27 (Wed) 11:51:34 T.Oide
'備　考：2008/09/03 (Wed) 11:53:42 T.Sawaguchi 最大WF枚数でﾁｪｯｸする様に変更　(案件03044)
'　　　：2011/04/27 (Wed) 11:51:34 T.Oide      CHR0001319 QUを組立に送品可能にする
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Imports SEComboBoxEx
Public Class frmxxEN00O0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00O0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00O0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00O0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00O0)
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
    '======================================Private===========================================
    '@ﾛｰｶﾙ機能ﾊﾞｰｼﾞｮﾝ
    '@↓2011/05/06 (Fri) 16:45:13 T.Oide **************************************************
    'Private Const CMstrLocalVersion             As String = "06.00"         '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion             As String = "07.00"         '機能ﾊﾞｰｼﾞｮﾝ
    '@↑2011/05/06 (Fri) 16:45:13 T.Oide **************************************************


    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    'Private Const CMstrmas_pdlist__Ver          As String = "02.02"         '機種区分一覧取得
    Private Const CMstrmas_pdlist__Ver          As String = "03.00"         '機種区分一覧取得
    '@↑2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    '@↓2011/05/09 (Mon) 10:45:39 T.Oide **************************************************
    'Private Const CMstrmas_flowlistVer          As String = "03.00"         '種別区分一覧取得
    Private Const CMstrmas_flowlistVer          As String = "04.00"         '種別区分一覧取得
    '@↑2011/05/09 (Mon) 10:45:39 T.Oide **************************************************
    Private Const CMstrmas_pdentrylistVer       As String = "03.00"         'ﾏｽﾀ工順一覧
    Private Const CMstrmas_emplist_Ver          As String = "02.00"         '作業者ﾘｽﾄ取得
    Private Const CMstrlot_throwrsvVer          As String = "03.00"         '投入予約登録
    Private Const CMstrlot_approveVer           As String = "01.04"         '投入ﾛｯﾄ承認要求

    '@frmxxEN00O0の定数宣言
    Private Const CMfrmxxEN00O0Height           As Integer = 681            'ﾌｫｰﾑの高さ
    Private Const CMfrmxxEN00O0Width            As Integer = 1001           'ﾌｫｰﾑの幅

    '@ｺﾝﾎﾞﾎﾞｯｸｽの定数宣言
    Private Const CMlngComboDispCols1           As Integer = 1                 '表示列数
    Private Const CMlngComboGetCol              As Integer = 0                 '値取得列
    Private Const CMlngComboFontSize            As Integer = 16                'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboGridFontSize        As Integer = 16                'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboRowHeight           As Integer = 640               '行高さ
    Private Const CMlngComboAlignLeftCenter     As Integer = 1                 '左中央
    Private Const CMlngComboGetCol1             As Integer = 1                 'WFｶｳﾝﾄ格納Col
    Private Const CMlngComboGetCol5             As Integer = 5                 'ﾊﾞｯｸｶﾗｰ格納Col

    '@起動区分の定数宣言
    Private Const CMlngPDEntry                  As Integer = 1                 'ｴﾝﾄﾘ表示用
    Private Const CMlngDummy                    As Integer = 2                 '投入予定一覧表示用

    '@その他の定数
    Private Const CMstrWFDefault                As String = "0"             '数量ｾﾞﾛ入力時比較用定数
    Private Const CMlngMaxWfCount               As Integer = 25                'MAXWF枚数
    Private Const CMlngMaxDispRow               As Integer = 3                 'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@ﾚｽﾎﾟﾝｽ計測用
    Private Const CMstrFormName                 As String = "frmxxEN00O0"       '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                 As String = "Form_Load"         'ｲﾍﾞﾝﾄ名定数(ﾌｫｰﾑ起動処理)
    Private Const CMstrCmbPdValidate            As String = "cmbPd_Validate"    'ｲﾍﾞﾝﾄ名定数(機種選択確定処理)
    Private Const CMstrCmbGroupValidate         As String = "cmbGroup_Validate" 'ｲﾍﾞﾝﾄ名定数(部門選択確定処理)
    Private Const CMstrCmdRegistClick           As String = "cmdRegist_Click"   'ｲﾍﾞﾝﾄ名定数(確定ﾎﾞﾀﾝ押下処理)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private===========================================
    Private mstrPDID                            As String                   '機種ID退避領域
    Private mstrGroupID                         As String                   '部門ID退避領域
    Private mtypPdList                          As List(Of ProductList)     '機種一覧格納用
    Private mlngPdListCnt                       As Integer                  '機種一覧ｶｳﾝﾄ
    Private mtypDivisionList                    As List(Of DivisionList)    '種別一覧格納用
    Private mlngDivisionCnt                     As Integer                  '種別一覧ｶｳﾝﾄ
    Private mtypLotManagerList                  As List(Of TechManList)     'ﾛｯﾄ担当一覧格納用
    Private mlngLotManagerListCnt               As Integer                  'ﾛｯﾄ担当一覧ｶｳﾝﾄ
    Private mtypEntryList                       As List(Of EntryList)       'ﾏｽﾀ工順一覧格納用
    Private mlngEntryListCnt                    As Integer                  'ﾏｽﾀ工順一覧ｶｳﾝﾄ

    Private mlngPdEntryMaxWFCount               As Integer                  '現在選択されている機種ｴﾝﾄﾘの最大WF枚数
    Private mblnFormLoadFlag                    As Boolean                  'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mtypLotReserve                      As LotReserve               '投入予約渡し用

    Private buttonProcessing                    As Boolean               'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean               'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean               'NSYS WindowCloseフラグ

    Private ReadOnly vbWhite                    As Color = Color.White   'NSYS vbWhite定義

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
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 09:09:17 N.Kojima
    '更新日：2008/06/12 (Thu) 16:14:51 N.Kojima
    '備　考：
    '　　　：2004/08/26 (Thu) 15:39:22 N.Kojima     数値の比較はlong型で行うように修正(122行目)。
    '　　　：2008/06/12 (Thu) 16:14:51 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean      '戻り値
        Dim lstrClassDivision   As String       '作成処理区分

        Try

            '@=======================
            '@　機能ﾊﾞｰｼﾞｮﾝの判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00O0, CMstrLocalVersion)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@=======================
                '@　ﾒｲﾝﾒﾆｭｰ画面拡張処理
                '@=======================
                Call pubMenuExpand_Disp()
                
                '@=======================
                '@　ﾌｫｰﾑ終了時処理
                '@=======================
                Call Form_QueryUnload(False, New FormClosingEventArgs(CloseReason.UserClosing,  False))
                
                Exit Sub
            End If
            
            'NSYS ESCキーで画面閉じる
            Me.CancelButton = Me.cmdClose
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@=======================
            '@　各種初期化処理(画面ｺﾝﾄﾛｰﾙ、変数等)
            '@=======================
            Call prvfrmxxEN00O0_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化(ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ："False:未表示")
            mblnFormLoadFlag = False
            
            
            '@処理区分:"2Z02(品確/ﾀﾞﾐｰ/ﾓﾆﾀｰ品)"に設定
            lstrClassDivision = CPstrCD2Z & CPstrCD02
            
            '@【機種区分一覧取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          lstrClassDivision, _
                                          mtypPdList, _
                                          mlngPdListCnt, _
                                          pstrSBID)

            '@機種区分一覧取得結果判定
            If lblnAns = False Then
                '@機種区分一覧取得結果：正常の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                Exit Sub
            End If
            
            'NSYS 背景色に白を設定
            cmbPD.BackColor = Color.White
            cmbDivision.BackColor = Color.White
            calStartDate.BackColor = Color.White
            cmbLotSend.BackColor = Color.White

            'NSYS 初期表示時に機種にフォーカスを設定
            Me.ActiveControl = Me.cmbPD

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            
            '@Form_Loadﾌﾗｸﾞに"True:正常起動"をｾｯﾄ
            pblnFormLoad = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/24 (Fri) 08:41:01 S.Deguchi
    '更新日：2008/06/12 (Thu) 16:21:48 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 16:21:48 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False:未表示"か
            If mblnFormLoadFlag = False Then
            
                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True:表示済"をｾｯﾄ
                mblnFormLoadFlag = True
                
                '@=======================
                '@　機種ｺﾝﾎﾞ作成処理
                '@=======================
                Call prvcmbPdList_Disp()
                
                
                '@=======================
                '@　部門ｺﾝﾎﾞ作成処理
                '@　※部門ｺﾝﾎﾞ作成(1回作成するだけでよい為、Function化しない)
                '@=======================
                With cmbGroup
                    
                    .Clear              'ｸﾘｱ
                    .ValueCol = 1       '値取得列を部門IDに設定
                    
                    '@ｺﾝﾎﾞ設定内容：部門名(技術or製造)/部門ID(STAFForLINE)
                    .AddItem(CPstrDeptNameStaff & vbTab & CPstrDeptIDStaff)      '技術/STAFF
                    .AddItem(CPstrDeptNameLine & vbTab & CPstrDeptIDLine)        '製造/LINE
                
                    .Enabled = False    '無効
                End With

                '@投入予定一覧ﾎﾞﾀﾝを有効にする
                cmdPlanList.Enabled = True

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "Form_Activate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 11:19:27 N.Kojima
    '更新日：2008/06/12 (Thu) 16:23:28 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 16:23:28 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
            
                '@〓 作業ﾒﾓ 〓
                Case txtWorkMemo.Name
                
                    '@作業ﾒﾓは改行できるように何もしない
                    Exit Sub
                
                
                '@〓 機種 〓
                Case cmbPD.Name
                    
                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                        
                            '@=======================
                            '@　機種ｺﾝﾎﾞのValidate処理
                            '@=======================
                            ' NSYS validateの2重起動防止
                            RemoveHandler cmbPD.Validating, AddressOf cmbPd_Validate
                            Call cmbPd_Validate(cmbPD, New CancelEventArgs(True))
                            AddHandler cmbPD.Validating, AddressOf cmbPd_Validate
                            e.Handled = True
                    End Select
                
                
                '@〓 種別 〓
                Case cmbDivision.Name
                    
                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                        
                            '@=======================
                            '@　種別ｺﾝﾎﾞのValidate処理
                            '@=======================
                            ' NSYS validateの2重起動防止
                            RemoveHandler cmbDivision.Validating, AddressOf cmbDivision_Validate
                            Call cmbDivision_Validate(cmbDivision, New CancelEventArgs(True))
                            AddHandler cmbDivision.Validating, AddressOf cmbDivision_Validate

                            e.Handled = True
                    End Select
                
                
                '@〓 WF枚数 〓
                Case txtWFNum.Name
                    
                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                        
                            '@=======================
                            '@　WF枚数ﾃｷｽﾄのValidate処理
                            '@=======================
                            ' NSYS validateの2重起動防止
                            RemoveHandler txtWFNum.Validating, AddressOf txtWFNum_Validate
                            Call txtWFNum_Validate(sender,New CancelEventArgs(True))
                            AddHandler txtWFNum.Validating, AddressOf txtWFNum_Validate   
                            e.Handled = True
                    End Select
                
                
                '@〓 投入予定日 〓
                Case calStartDate.Name
                
                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                        
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                        
                            '@=======================
                            '@　投入予定日ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
                            '@=======================
                            ' NSYS validateの2重起動防止
                            RemoveHandler calStartDate.Validating, AddressOf calStartDate_Validate
                            Call calStartDate_Validate(sender,New CancelEventArgs(True))
                            AddHandler calStartDate.Validating, AddressOf calStartDate_Validate   
                            e.Handled = True
                    End Select
                

                '@〓 部門 〓
                Case cmbGroup.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                            
                            '@=======================
                            '@　部門ｺﾝﾎﾞのValidate処理
                            '@=======================
                            ' NSYS validateの2重起動防止
                            RemoveHandler cmbGroup.Validating, AddressOf cmbGroup_Validate
                            Call cmbGroup_Validate(sender,New CancelEventArgs(True))
                            AddHandler cmbGroup.Validating, AddressOf cmbGroup_Validate   
                            e.Handled = True
                    End Select
                
                
                '@〓 ﾛｯﾄ担当 〓
                Case cmbLotManager.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                            
                            '@=======================
                            '@　ﾛｯﾄ担当ｺﾝﾎﾞのValidate処理
                            '@=======================
                            ' NSYS validateの2重起動防止
                            RemoveHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate
                            Call cmbLotManager_Validate(sender,New CancelEventArgs(True))
                            AddHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate   
                            e.Handled = True
                    End Select
                
                
                '@〓 その他 〓
                Case Else
                    
                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                            
                            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "Form_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：ｷｬﾝｾﾙ
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 11:20:15 N.Kojima
    '更新日：2008/06/12 (Thu) 16:29:52 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 16:00:35 S.Deguchi    閉じるﾎﾞﾀﾝ統合
    '　　　：2004/12/08 (Wed) 09:37:17 S.Deguchi    ﾊﾟﾌﾞﾘｯｸ変数の初期化処理を追加
    '　　　：2008/06/12 (Thu) 16:29:52 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      'ACT開放結果格納

        Try
            
            '@構造体のｸﾘｱ
            '機種格納配列
            If Not IsNothing(mtypPdList) Then
                mtypPdList.Clear()
                mtypPdList = Nothing
            End If
            '種別格納配列
            If Not IsNothing(mtypDivisionList) Then
                mtypDivisionList.Clear()
                mtypDivisionList = Nothing
            End If
            'ﾛｯﾄ担当格納配列
            If Not IsNothing(mtypLotManagerList) Then
                mtypLotManagerList.Clear()
                mtypLotManagerList = Nothing
            End If
            'ｴﾝﾄﾘ格納配列
            If Not IsNothing(mtypEntryList) Then
                mtypEntryList.Clear()
                mtypEntryList = Nothing
            End If

            
            '@ﾊﾟﾌﾞﾘｯｸ変数を初期化
            plngfrmxxCM00F0Kbn = 0
            pstrfrmxxCM0090Kbn = vbNullString

            '@"×"ﾎﾞﾀﾝでの終了か
            If mblnCloseFromControlMenu Then
                '@=======================
                '@　閉じるﾎﾞﾀﾝ押下時処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@Act初期化ﾌﾗｸﾞが"True:初期化済"か
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@=======================
                '@　ACTｵﾌﾞｼﾞｪｸﾄ開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                '@処理結果判定
                If lblnAnsTerm = True Then
                    '@結果：正常の場合
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@Act初期化ﾌﾗｸﾞが"False:未初期化"の場合
            
                '@=======================
                '@　ﾒｲﾝﾒﾆｭｰ画面拡張処理
                '@=======================
                Call pubMenuExpand_Disp()
            End If
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_Change
    '機　能：機種ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/29 (Thu) 15:23:58 N.Kojima
    '更新日：2011/04/26 (Tue) 15:22:58 T.Oide
    '備　考：
    '　　　：2005/06/24 (Fri) 08:43:36 S.Deguchi    退避機種のｸﾘｱとｴﾝﾄﾘ情報ｸﾘｱ処理追加
    '　　　：2008/06/12 (Thu) 16:54:56 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    '　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
    Private Sub cmbPd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPD.Change

        Try
            
            '@退避領域の機種と、選択機種が異なるか
            If mstrPDID <> cmbPD.Text Then
                
                '@各種ｺﾝﾄﾛｰﾙをｸﾘｱする
                cmbDivision.Clear                           '種別
                txtWFNum.Text = vbNullString                'WF枚数
                calStartDate.Value = CPstrNullDate          '投入予定日
                cmbGroup.ListIndex = -1                     '部門
                cmbLotManager.ListIndex = -1                'ﾛｯﾄ担当
        '@↓2011/04/26 (Tue) 15:22:44 T.Oide **************************************************
                cmbLotSend.ListIndex = -1                   '送品
        '@↑2011/04/26 (Tue) 15:22:44 T.Oide **************************************************
                lblEntryID.Text = vbNullString           'ｴﾝﾄﾘ
                lblEntryName.Text = vbNullString         'ｴﾝﾄﾘ名
                lblLotID.Text = CPstrMsgNull             'ﾛｯﾄID
                
                mstrGroupID = vbNullString                  '部門退避変数
            End If
            
            '@=======================
            '@　入力(選択)ﾁｪｯｸ＆確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbPd_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_CloseUp
    '機　能：機種ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 10:53:35 N.Kojima
    '更新日：2008/06/12 (Thu) 17:00:24 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 17:00:24 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub cmbPd_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPD.CloseUp

        Try
            
            '@機種がNULL以外か
            If cmbPD.Text <> vbNullString Then
            
                '@=======================
                '@　機種ｺﾝﾎﾞのValidate処理
                '@=======================
                ' NSYS validateの2重起動防止
                RemoveHandler cmbPD.Validating, AddressOf cmbPd_Validate
                Call cmbPd_Validate(cmbPD, New CancelEventArgs(False))
                AddHandler cmbPD.Validating, AddressOf cmbPd_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbPd_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_Validate
    '機　能：機種ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 09:14:23 N.Kojima
    '更新日：2008/06/12 (Thu) 17:01:18 N.Kojima
    '備　考：機種ｴﾝﾄﾘごとに最大WF枚数を表示 2004/09/02 (Thu) 09:38:17 Y.Yamagishi
    '　　　：2005/07/26 (Tue) 11:14:15 N.Kasai      L/R色追加
    '　　　：2008/06/12 (Thu) 17:01:18 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub cmbPd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPD.Validating

        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)
        Dim lstrClassDivision   As String       '処理区分

        Try

          
            '@機種がNULLか
            If cmbPD.Text = vbNullString Then
            
                '@投入予定一覧にﾌｫｰｶｽｾｯﾄ
                'NSYS Active項目の判定
                If ActiveControl.Name = cmbPD.Name Then
                    Call pubSetFocus(cmdPlanList)
                End If
                Exit Sub
            Else
                '@機種がNULL以外の場合
                
                '@選択機種が退避機種と同じか
                If mstrPDID = cmbPD.Text Then
                    '@同じ場合
                    
                    'NSYS Active項目の判定
                    If ActiveControl.Name = cmbPD.Name Then
                        '@種別が有効か
                        If cmbDivision.Enabled = True Then
                    
                            '@種別にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbDivision)
                        Else
                            '@種別が無効な場合
                    
                            '@投入予定一覧にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdPlanList)
                        End If
                    End If
                    
                    Exit Sub
                End If
            End If
            
            '@機種ｺﾝﾎﾞの値取得列を"5：ﾊﾞｯｸｶﾗｰ値"列に設定する
            cmbPD.ValueCol = CMlngComboGetCol5
            '@機種ｺﾝﾎﾞの値がNULL以外か
            If cmbPD.Value <> vbNullString Then
            
                '@NULL以外の場合は、ﾊﾞｯｸｶﾗｰを変更する
                cmbPD.BackColor = ColorTranslator.FromWin32(CLng(cmbPD.Value))
            Else
                '@NULLの場合は、ﾃﾞﾌｫﾙﾄ色(白)を設定する
                cmbPD.BackColor = vbWhite
            End If
            '@機種ｺﾝﾎﾞの値取得列を"1：最大WF枚数"列に設定する
            cmbPD.ValueCol = CMlngComboGetCol1
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormLoad, CMstrCmbPdValidate)
            
            
            '@処理区分："04(機種別)"を設定する
            lstrClassDivision = CPstrCD04
            '@【流動区分一覧取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                            mtypDivisionList, _
                                            mlngDivisionCnt, _
                                            pstrSBID, _
                                            lstrClassDivision, _
                                            cmbPD.Text)

            '@流動区分一覧取得結果判定
            If lblnAns = True Then
                '@流動区分一覧取得結果：正常の場合
                
                '@=======================
                '@　種別ｺﾝﾎﾞ作成処理
                '@=======================
                Call prvcmbDivisionList_Disp()
            Else
                '@流動区分一覧取得結果：異常の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormLoad, CMstrCmbPdValidate)
                Exit Sub
            End If
            
            
            '@処理区分："07(最新ｴﾝﾄﾘ取得)"を設定
            lstrClassDivision = CPstrCD07
            '@【ﾏｽﾀ工順一覧取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnmasPdEntryList_Sel(CMstrmas_pdentrylistVer, _
                                               cmbPD.Text, _
                                               mtypEntryList, _
                                               mlngEntryListCnt, _
                                               pstrSBID, _
                                               lstrClassDivision)

            '@ﾏｽﾀ工順一覧取得結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順一覧取得結果：正常の場合
            
                '@ｴﾝﾄﾘ名・ｴﾝﾄﾘIDを格納
                lblEntryID.Text = mtypEntryList(mlngEntryListCnt -1).strEntryID
                lblEntryName.Text = mtypEntryList(mlngEntryListCnt -1).strEntryName
                
                '@WF枚数にﾏｽﾀｴﾝﾄﾘの最大WF枚数をｾｯﾄする
                txtWFNum.Text = mtypEntryList(mlngEntryListCnt -1).strMaxWFCount
                
                '@ｴﾝﾄﾘに紐付く最大WF枚数を退避
                mlngPdEntryMaxWFCount = txtWFNum.Text
                
                '@ｴﾝﾄﾘﾎﾞﾀﾝを有効にする
                cmdEntry.Enabled = True
            End If
            
            '@各種ｺﾝﾄﾛｰﾙを有効にする
            txtWFNum.Enabled = True         'WF枚数
            calStartDate.Enabled = True     '投入予定日
            cmbGroup.Enabled = True         '部門
            
            '@機種退避領域に現在選択されている機種を格納
            mstrPDID = cmbPD.Text

            
            '@=======================
            '@　入力(選択)ﾁｪｯｸ＆確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()
            
            '@種別が有効か
            If cmbDivision.Enabled = True Then
                '@種別へﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbDivision)
            Else
                '@投入予定一覧にﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdPlanList)
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormLoad, CMstrCmbPdValidate)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbPd_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivision_CloseUp
    '機　能：種別ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 11:27:40 N.Kojima
    '更新日：2008/06/12 (Thu) 17:26:22 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 17:26:22 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub cmbDivision_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDivision.CloseUp

        Try
            
            '@種別がNULL以外か
            If cmbDivision.Text <> vbNullString Then
                
                '@=======================
                '@　種別ｺﾝﾎﾞのValidate処理
                '@=======================
                ' NSYS validateの2重起動防止
                RemoveHandler cmbDivision.Validating, AddressOf cmbDivision_Validate
                Call cmbDivision_Validate(cmbDivision, New CancelEventArgs(True))
                AddHandler cmbDivision.Validating, AddressOf cmbDivision_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbDivision_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivision_Validate
    '機　能：種別ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 11:27:55 N.Kojima
    '更新日：2008/06/12 (Thu) 17:27:32 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 17:27:32 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub cmbDivision_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbDivision.Validating

        Try
            
            '@=======================
            '@　入力(選択)ﾁｪｯｸ＆確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()

            'NSYS ActiveControlの判定
            If ActiveControl.Name = cmbDivision.Name Then
	            '@WF枚数が有効か
	            If txtWFNum.Enabled = True Then
	                '@WF枚数へﾌｫｰｶｽｾｯﾄ
	                Call pubSetFocus(txtWFNum)
	            End If
            End If            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbDivision_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWFNum_Change
    '機　能：WF枚数ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/12 (Thu) 13:18:52 N.Kojima
    '更新日：2008/06/12 (Thu) 17:31:49 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 17:31:49 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub txtWFNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWFNum.Change

        Try
            
            '@WF枚数が"0"、またはNULLか
            If txtWFNum.Text = CMstrWFDefault Or txtWFNum.Text = vbNullString Then
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            Else
                '@WF枚数が"0"以外、かつNULL以外の場合
            
                '@確定ﾎﾞﾀﾝを有効にする
                cmdRegist.Enabled = True
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "txtWFNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWFNum_Validate
    '機　能：WF枚数ﾃｷｽﾄ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 11:34:47 N.Kojima
    '更新日：2008/06/12 (Thu) 17:36:26 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 17:36:26 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    '　　　：2008/09/03 (Wed) 11:45:53 T.Sawaguchi  最大WF枚数でﾁｪｯｸする様に変更　(案件03044)
    Private Sub txtWFNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtWFNum.Validating

        Try
            'NSYS ×ボタンの場合処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@WF枚数がNULL以外か
            If txtWFNum.Text <> vbNullString Then
            
        '@↓2008/09/03 (Wed) 07:32:28 T.Sawaguchi 案件03044 **************************
                '@[WF枚数が機種の最大WF枚数より大きいか] から
                '@｢WF枚数が最大WF枚数25より大きいか」　に変更
                If CLng(txtWFNum.Text) > CMlngMaxWfCount Then
                
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0086, txtWFNum.Text, CMlngMaxWfCount)
                    '@ﾒｯｾｰｼﾞ：""<TRM86W>$$ウエハ枚数[%1]が最大WF枚数の設定値[%2]を超えています。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                               
                    '@ﾌｫｰｶｽを保持
                    e.Cancel = True
                    Exit Sub
                End If
        '@↑2008/09/03 (Wed) 07:32:28 T.Sawaguchi 案件03044 **************************
            End If
            
            '@=======================
            '@　入力(選択)ﾁｪｯｸ＆確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()
            
            'NSYS Validate処理の項目がアクティブの場合
            If ActiveControl.Name = txtWFNum.Name Then
                '@投入予定日が有効か
                If calStartDate.Enabled = True Then
            
                    '@投入予定日へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(calStartDate)
                End If
            End If
               
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "txtWFNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStartDate_CalendarSelect
    '機　能：投入予定日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　ｶﾚﾝﾀﾞｰ選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 11:44:11 N.Kojima
    '更新日：2008/06/12 (Thu) 17:35:45 N.Kojima
    '備　考：
    '　　　：2004/10/01 (Fri) 13:26:30 Y.Yamagishi  ｶﾚﾝﾀﾞｰが空でﾌｫｰｶｽ移動しないように修正
    '　　　：2008/06/12 (Thu) 17:35:45 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub calStartDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calStartDate.CalendarSelect

        Try
            
            '@投入予定日が"____/__/__"以外か
            If calStartDate.Value <> CPstrNullDate Then
                
                '@=======================
                '@　投入予定日ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
                '@=======================
                ' NSYS validateの2重起動防止
                RemoveHandler calStartDate.Validating, AddressOf calStartDate_Validate
                Call calStartDate_Validate(sender,New CancelEventArgs(True))
                AddHandler calStartDate.Validating, AddressOf calStartDate_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "calStartDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/06/13 (Fri) 11:05:18 N.Kojima **************************************************
    '関数名：calStartDate_Change
    '機　能：投入予定日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/13 (Fri) 11:05:24 N.Kojima
    '更新日：2008/06/13 (Fri) 11:05:24
    '備　考：
    Private Sub calStartDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calStartDate.Change

        Try
            
            '@=======================
            '@　入力(選択)ﾁｪｯｸ＆確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "calStartDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/06/13 (Fri) 11:05:18 N.Kojima **************************************************

    '関数名：calStartDate_Validate
    '機　能：投入予定日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　Validate処理(選択/入力確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 11:46:16 N.Kojima
    '更新日：2008/06/12 (Thu) 17:38:46 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 17:38:46 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub calStartDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calStartDate.Validating

        Dim lstrNowDT           As String       '現在日付取得

        Try
            'NSYS ×ボタンの場合処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@日付が"____/__/__"以外か
            If calStartDate.Value <> CPstrNullDate Then
            
                '@日付が有効日付か(1900/01/01～2100/12/31か)　※1900/_1/01等も不可
                If pubblnYearRange_Chk(calStartDate.Value) = False Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@ﾒｯｾｰｼﾞ："<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽを保持
                    e.Cancel = True
                    Exit Sub
                Else
                    '@有効日付の場合
                    
                    '@現在日付を取得する
                    lstrNowDT = Format(Now, CPstrDateTimeYMD)
                    
                    'NSYS 正しい日付かを判定する
                    Dim FormatDate As String
                    If IsDate(calStartDate.Value) = True Then
                        FormatDate = Format$(CDate(calStartDate.Value), CPstrDateTimeYMD)
                    Else
                        FormatDate = calStartDate.Value
                    End If

                    '@日付が現在日付より過去か
                    If FormatDate < lstrNowDT Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                        '@ﾒｯｾｰｼﾞ："<TRM10W>$$過去の日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                           
                        '@ﾌｫｰｶｽを保持
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
            
            '@=======================
            '@　入力(選択)ﾁｪｯｸ＆確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()

            'NSYS Active項目の判定
            If ActiveControl.Name = calStartDate.Name Then
	            '@部門が有効か
	            If cmbGroup.Enabled = True Then
	            
	                '@部門にﾌｫｰｶｽｾｯﾄ
	                Call pubSetFocus(cmbGroup)
	            Else
	                '@投入予定一覧ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
	                Call pubSetFocus(cmdPlanList)
	            End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "calStartDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/06/12 (Thu) 17:54:12 N.Kojima **************************************************
    '関数名：cmbGroup_Change
    '機　能：部門ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/12 (Thu) 16:54:56 N.Kojima
    '更新日：2011/04/26 (Tue) 15:42:08 T.Oide
    '備　考：
    Private Sub cmbGroup_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbGroup.Change

        Try
            
            '@退避領域の部門と、選択部門が異なるか
            If mstrGroupID <> cmbGroup.Value Then
                
                '@ﾛｯﾄ担当ｺﾝﾎﾞをｸﾘｱする
                cmbLotManager.ListIndex = -1
        '@↓2011/04/26 (Tue) 15:42:04 T.Oide **************************************************
                '@送品ｺﾝﾎﾞをｸﾘｱする
                cmbLotSend.ListIndex = -1
                cmbLotSend.Enabled = False
        '@↑2011/04/26 (Tue) 15:42:04 T.Oide **************************************************
            End If
            
            '@部門がNULLか
            If cmbGroup.Value = vbNullString Then

                '@ﾛｯﾄ担当ｺﾝﾎﾞを無効にする
                cmbLotManager.Enabled = False
            End If
            
            '@=======================
            '@　入力(選択)ﾁｪｯｸ＆確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbGroup_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/06/12 (Thu) 17:54:12 N.Kojima **************************************************

    '@↓2008/06/12 (Thu) 17:54:21 N.Kojima **************************************************
    '関数名：cmbGroup_CloseUp
    '機　能：部門ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/12 (Thu) 17:00:24 N.Kojima
    '更新日：2008/06/12 (Thu) 17:00:24
    '備　考：
    Private Sub cmbGroup_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbGroup.CloseUp

        Try
            
            '@部門がNULL以外か
            If cmbGroup.Text <> vbNullString Then
            
                '@=======================
                '@　部門ｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbGroup.Validating, AddressOf cmbGroup_Validate
                Call cmbGroup_Validate(sender,New CancelEventArgs(False))
                AddHandler cmbGroup.Validating, AddressOf cmbGroup_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbGroup_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/06/12 (Thu) 17:54:21 N.Kojima **************************************************

    '@↓2008/06/12 (Thu) 17:54:54 N.Kojima **************************************************
    '関数名：cmbGroup_Validate
    '機　能：部門ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/06/12 (Thu) 17:01:18 N.Kojima
    '更新日：2008/06/12 (Thu) 17:01:18
    '備　考：
    Private Sub cmbGroup_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbGroup.Validating

        Dim lblnAns             As Boolean      '戻り値結果格納(True:OK、False:NG)

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@部門がNULLか
            If cmbGroup.Text = vbNullString Then
            
                'NSYS Active項目の判定
                If ActiveControl.Name = cmbGroup.Name Then
                    '@投入予定一覧にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdPlanList)
                End If
                Exit Sub

            Else
                '@部門がNULL以外の場合
                
                '@選択部門が退避部門と同じか
                If mstrGroupID = cmbGroup.Value Then
                    '@同じ場合
                    
                    'NSYS Active項目の判定
                    If ActiveControl.Name = cmbGroup.Name Then
                        '@ﾛｯﾄ担当が有効か
                        If cmbLotManager.Enabled = True Then
                    
                            '@ﾛｯﾄ担当にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbLotManager)
                        Else
                            '@ﾛｯﾄ担当が無効な場合
                    
                            '@投入予定一覧にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdPlanList)
                        End If
                    End If
                    Exit Sub
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormLoad, CMstrCmbGroupValidate)
            
            
            '@【作業者ﾘｽﾄ(ﾛｯﾄ担当)取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasEmplist_Sel(CMstrmas_emplist_Ver, _
                                           mtypLotManagerList, _
                                           mlngLotManagerListCnt, _
                                           cmbGroup.Value)

            '@作業者ﾘｽﾄ(ﾛｯﾄ担当)取得結果判定
            If lblnAns = True Then
                '@作業者ﾘｽﾄ(ﾛｯﾄ担当)取得結果：正常の場合
                
                '@=======================
                '@　ﾛｯﾄ担当ｺﾝﾎﾞ作成処理
                '@=======================
                Call prvCmbLotManager_Disp()
            Else
                '@作業者ﾘｽﾄ(ﾛｯﾄ担当)取得結果：異常の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmbGroupValidate)
                Exit Sub
            End If
            
            
            '@部門退避領域に現在選択されている部門IDを格納
            mstrGroupID = cmbGroup.Value

            
            '@=======================
            '@　入力(選択)ﾁｪｯｸ＆確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()
            
            '@ﾛｯﾄ担当が有効か
            If cmbLotManager.Enabled = True Then
                '@ﾛｯﾄ担当へﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbLotManager)
            Else
                '@投入予定一覧にﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdPlanList)
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormLoad, CMstrCmbGroupValidate)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbGroup_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/06/12 (Thu) 17:54:54 N.Kojima **************************************************

    '関数名：cmbLotManager_Change
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/12 (Thu) 17:43:54 N.Kojima
    '更新日：2011/04/26 (Tue) 15:10:41 T.Oide
    '備　考：
    Private Sub cmbLotManager_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotManager.Change

        Try
            'NSYS ロット担当が選択状態の場合
            If cmbLotManager.ListIndex > -1 Then
        '@↓2011/04/26 (Tue) 15:10:36 T.Oide **************************************************
                '@送品ｺﾝﾎﾞ設定
                Select Case cmbDivision.Value
            
                    Case CPstrFlowClassQU
                        '送品ｺﾝﾎﾞ「有効」
                        cmbLotSend.Enabled = True
                    
                    Case Else
                        '送品ｺﾝﾎﾞ「無効」
                        cmbLotSend.Enabled = False
            
                End Select
           
                '@送品ｺﾝﾎﾞﾃﾞﾌｫﾙﾄ設定(未選択 or QU以外か　→　QUで選択済みの場合はそのまま)
                If cmbLotSend.ListIndex = -1 Or cmbDivision.Value <> CPstrFlowClassQU Then
                    '「なし」
                    cmbLotSend.ListIndex = CPlngLotSendNasi
                End If
        '@↑2011/04/26 (Tue) 15:10:36 T.Oide **************************************************
            
                '@=======================
                '@　入力(選択)ﾁｪｯｸ＆確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvblnInput_Chk()
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbLotManager_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/06/12 (Thu) 17:55:15 N.Kojima **************************************************
    '関数名：cmbLotManager_CloseUp
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/12 (Thu) 17:46:57 N.Kojima
    '更新日：2008/06/12 (Thu) 17:46:57
    '備　考：
    Private Sub cmbLotManager_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotManager.CloseUp

        Try
            
            '@ﾛｯﾄ担当がNULL以外か
            If cmbLotManager.Text <> vbNullString Then
            
                '@=======================
                '@　ﾛｯﾄ担当ｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler calStartDate.Validating, AddressOf cmbLotManager_Validate
                Call cmbLotManager_Validate(sender,New CancelEventArgs(True))
                AddHandler calStartDate.Validating, AddressOf cmbLotManager_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbLotManager_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/06/12 (Thu) 17:55:15 N.Kojima **************************************************

    '@↓2008/06/12 (Thu) 17:55:26 N.Kojima **************************************************
    '関数名：cmbLotManager_Validate
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/06/12 (Thu) 17:47:21 N.Kojima
    '更新日：2008/06/12 (Thu) 17:47:21
    '備　考：
    Private Sub cmbLotManager_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbLotManager.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@=======================
            '@　入力(選択)ﾁｪｯｸ＆確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()
            
            'NSYS Active項目の判定
            If ActiveControl.Name = cmbLotManager.Name Then
                '@確定ﾎﾞﾀﾝが有効か
                If cmdRegist.Enabled = True Then
                
                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdRegist)
                Else
                    '@作業ﾒﾓにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtWorkMemo)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbLotManager_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/06/12 (Thu) 17:55:26 N.Kojima **************************************************

    '@↓2011/04/26 (Tue) 15:35:10 T.Oide **************************************************
    '関数名：cmbLotSend_Change
    '機　能：送品ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：
    '作成日：2011/04/26 (Tue) 15:35:03 T.Oide
    '更新日：2011/04/26 (Tue) 15:35:03
    '備　考：
    Private Sub cmbLotSend_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotSend.Change

        Try
            
            '@=======================
            '@　入力(選択)ﾁｪｯｸ＆確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbLotSend_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub
    '@↑2011/04/26 (Tue) 15:35:10 T.Oide **************************************************

    '@↓2011/04/26 (Tue) 15:38:31 T.Oide **************************************************
    '関数名：cmbLotSend_CloseUp
    '機　能：送品ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：
    '作成日：2011/04/26 (Tue) 15:35:23 T.Oide
    '更新日：2011/04/26 (Tue) 15:35:23
    '備　考：
    Private Sub cmbLotSend_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotSend.CloseUp

        Try
           
            '@ﾛｯﾄ担当がNULL以外か
            If cmbLotManager.Text <> vbNullString Then
            
                '@=======================
                '@　送品ｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler calStartDate.Validating, AddressOf cmbLotManager_Validate
                Call cmbLotManager_Validate(sender,New CancelEventArgs(True))
                AddHandler calStartDate.Validating, AddressOf cmbLotManager_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbLotSend_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub
    '@↑2011/04/26 (Tue) 15:38:31 T.Oide **************************************************

    '@↓2011/04/26 (Tue) 15:38:20 T.Oide **************************************************
    '関数名：cmbLotSend_Validate
    '機　能：送品ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：
    '作成日：2011/04/26 (Tue) 15:35:26 T.Oide
    '更新日：2011/04/26 (Tue) 15:35:26
    '備　考：
    Private Sub cmbLotSend_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbLotSend.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@=======================
            '@　入力(選択)ﾁｪｯｸ＆確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()
            
            'NSYS Active項目の判定
            If ActiveControl.Name = cmbLotSend.Name Then
                '@確定ﾎﾞﾀﾝが有効か
                If cmdRegist.Enabled = True Then
                
                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdRegist)
                Else
                    '@作業ﾒﾓにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtWorkMemo)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmbLotSend_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub
    '@↑2011/04/26 (Tue) 15:38:20 T.Oide **************************************************


    '関数名：txtWorkMemo_Change
    '機　能：作業ﾒﾓﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 12:05:07 N.Kojima
    '更新日：2008/06/13 (Fri) 09:05:22 N.Kojima
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2008/06/13 (Fri) 09:05:22 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Dim llngNowByte         As Integer      'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                          llngNowByte, _
                                                          CPlngLotCommentsMaxByte)
            
            '@=======================
            '@　ﾃｷｽﾄ変更時処理(共通処理)
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "txtWorkMemo_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：作業ﾒﾓﾃｷｽﾄ　ｷｰ押上時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/12/01 (Thu) 13:10:57 S.Deguchi
    '更新日：2008/06/13 (Fri) 09:07:44 N.Kojima
    '備　考：
    '　　　：2008/06/13 (Fri) 09:07:44 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try
            '@=======================
            '@　ﾃｷｽﾄｷｰ押上時処理(共通処理)
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "txtWorkMemo_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：作業ﾒﾓﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2005/12/01 (Thu) 13:11:47 S.Deguchi
    '更新日：2008/06/13 (Fri) 09:08:20 N.Kojima
    '備　考：
    '　　　：2008/06/13 (Fri) 09:08:20 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try
            '@=======================
            '@　ﾃｷｽﾄ変更時処理(共通処理)
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "txtWorkMemo_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 17:54:36 S.Deguchi
    '更新日：2008/06/13 (Fri) 09:09:19 N.Kojima
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2008/06/13 (Fri) 09:09:19 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@　ﾃｷｽﾄ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通処理)
            '@=======================
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmdMemoUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 17:54:39 S.Deguchi
    '更新日：2008/06/13 (Fri) 09:10:06 N.Kojima
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2008/06/13 (Fri) 09:10:06 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ﾃｷｽﾄ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通処理)
            '@=======================
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmdMemoDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdEntry_Click
    '機　能：ｴﾝﾄﾘﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 13:03:17 N.Kojima
    '更新日：2008/06/13 (Fri) 09:11:00 N.Kojima
    '備　考：
    '　　　：2005/06/24 (Fri) 17:59:57 N.Kojima     Public変数の初期化処理追加(運用障害№438)　※緊急対応
    '　　　：2008/06/13 (Fri) 09:11:00 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub cmdEntry_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEntry.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
             
            '@機種IDの退避(ﾏｽﾀ工順取得用)
            pstrPDID = cmbPD.Text
            
            '@起動区分指定(ｴﾝﾄﾘ表示用)
            plngfrmxxCM00F0Kbn = CMlngPDEntry
            
            '@引継ﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrEntryID = vbNullString          'ｴﾝﾄﾘID
            pstrEntryName = vbNullString        'ｴﾝﾄﾘ名
            
            '@Form_Loadﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　機種ｴﾝﾄﾘ選択画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00F0.Instance = New frmxxCM00F0()
            
            '@子画面のLoad処理にて、Form_Loadﾌﾗｸﾞが"False：異常"のままか
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00F0.Instance = Nothing
                
                Exit Sub
            End If
            
            '@機種ｴﾝﾄﾘ選択画面のﾌｫｰﾑ名称を設定
            frmxxCM00F0.Instance.Text = CPstrSubDispTitlePDEntryList
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　機種ｴﾝﾄﾘ選択画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00F0.Instance.ShowDialog(Me)
            frmxxCM00F0.Instance = Nothing
            
            '@ｴﾝﾄﾘ名(ﾊﾟﾌﾞﾘｯｸ変数)がNULL以外か　※子画面にてｴﾝﾄﾘが選択されたか
            If pstrEntryName <> vbNullString Then
                
                '@子画面の選択情報を反映
                lblEntryID.Text = pstrEntryID            'ｴﾝﾄﾘ
                lblEntryName.Text = pstrEntryName        'ｴﾝﾄﾘ名
                
                txtWFNum.Text = pstrMaxWFCount              'WF枚数
                mlngPdEntryMaxWFCount = txtWFNum.Text       'ｴﾝﾄﾘに紐付く最大WF枚数を退避
                
                '@確定ﾎﾞﾀﾝを有効にする
                cmdRegist.Enabled = True
                
                '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdRegist)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmdEntry_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdPlanList_Click
    '機　能：投入予定一覧ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 12:07:02 N.Kojima
    '更新日：2008/06/13 (Fri) 09:16:07 N.Kojima
    '備　考：
    '　　　：2004/12/06 (Mon) 18:01:58 N.Kasai      投入予定ﾛｯﾄ一覧起動変数(pstrfrmxxCM0090Kbn)CPstrCD0M→CPstrCD0Zへ変更
    '　　　：2004/12/08 (Wed) 09:35:26 S.Deguchi    plngfrmxxCM00F0Kbnを削除
    '　　　：2008/06/13 (Fri) 09:16:07 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub cmdPlanList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPlanList.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
         
            '@子画面で使用する種別取得区分に"0Z:品確、ﾓﾆﾀｰ・ﾀﾞﾐｰﾛｯﾄ"をｾｯﾄ
            pstrfrmxxCM0090Kbn = CPstrCD0Z
            
            '@Form_Loadﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　投入予定ﾛｯﾄ一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0090.Instance = New frmxxCM0090()
            
            '@子画面のLoad処理にて、Form_Loadﾌﾗｸﾞが"False：異常"のままか
            If pblnFormLoad = False Then
            
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0090.Instance = Nothing
                
                Exit Sub
            End If
            
            '@投入予定ﾛｯﾄ一覧画面のﾌｫｰﾑ名称を設定
            frmxxCM0090.Instance.Text = CPstrSubDispTitleLotThrwList

            '@投入予定一覧画面の確定ﾎﾞﾀﾝを非表示にする
            frmxxCM0090.Instance.cmdChoice.Visible = False
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　投入予定ﾛｯﾄ一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0090.Instance.ShowDialog(Me)
            frmxxCM0090.Instance = Nothing
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmdPlanList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 12:07:33 N.Kojima
    '更新日：2008/06/13 (Fri) 09:19:14 N.Kojima
    '備　考：
    '　　　：2006/10/31 (Tue) 16:05:14 N.Kasai      送品ﾌﾗｸﾞ対応(№01500)
    '　　　：2008/06/13 (Fri) 09:19:14 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean      '戻り値(True：OK、False：NG)

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　確定時ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnLotReserve_Chk
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With mtypLotReserve
            
                .strPdId = cmbPD.Text                           '機種ID
                .strFlowClass = cmbDivision.Text                '流動区分(種別)
                .strWfNum = txtWFNum.Text                       'WF枚数
                .strPlanThrowinDate = calStartDate.Value        '投入予定日
                .strMasVer = lblEntryID.Text                 'ｴﾝﾄﾘID
                .strComment = txtWorkMemo.Text                  '作業ﾒﾓ
                .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸID
                .strClassDivision = CPstrCD0M & CPstrCD2Z       '処理区分(0M2Z)
                .strEngEmpId = cmbLotManager.Value              'ﾛｯﾄ担当者ID
                .strCopySeqLotID = vbNullString                 'ｺﾋﾟｰ元ﾛｯﾄID(品確、ﾓﾆﾀｰ・ﾀﾞﾐｰはNULL)
                .strDivideLotID = vbNullString                  '分割元ﾛｯﾄID(品確、ﾓﾆﾀｰ・ﾀﾞﾐｰはNULL)
        '@↓2011/04/26 (Tue) 13:04:58 T.Oide **************************************************
        '@        .strLotSendFlag = CPlngLotSendNasi              '送品ﾌﾗｸﾞ(送品なし固定)
                .strLotSendFlag = cmbLotSend.Value              '送品ﾌﾗｸﾞ
        '@↑2011/04/26 (Tue) 13:04:58 T.Oide **************************************************
            End With
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@取消ﾎﾞﾀﾝが押された場合は処理終了
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
            
            '@作業者ID設定
            mtypLotReserve.strEmpID = pstrUserID
            
            '@ﾛｯﾄIDｸﾘｱ
            lblLotID.Text = vbNullString
            
            '@【ﾛｯﾄ投入予約】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnLotThrowrsv_Ins(CMstrlot_throwrsvVer, _
                                            mtypLotReserve)
            
            '@ﾛｯﾄ投入予約結果判定
            If lblnAns = True Then
                '@ﾛｯﾄ投入予約結果：正常の場合
            
                '@ﾛｯﾄIDを表示する
                lblLotID.Text = mtypLotReserve.strLotID
                        
                '@【ﾛｯﾄ予約承認】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnLotApprove_Ins(CMstrlot_approveVer, _
                                               mtypLotReserve)
                
                '@ﾛｯﾄ予約承認結果判定
                If lblnAns = True Then
                    '@ﾛｯﾄ予約承認結果：正常の場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0003, lblLotID.Text)
                    '@ﾒｯｾｰｼﾞ："<TRM03I>$$投入予定ロット[%1]を登録しました。"
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)

                    '@作業ﾒﾓｸﾘｱ
                    txtWorkMemo.Text = vbNullString
                    
                    Exit Sub
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 11:20:30 N.Kojima
    '更新日：2008/06/12 (Thu) 16:34:06 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 16:34:06 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo      As CommonInfo       'PG間ﾃﾞｰﾀ受け渡し用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@　画面終了処理
            '@=======================
            Call publngEnd_Proc(CPstrKeyEN00O0, ltypCommonInfo)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "cmdClose_Click"
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
    '関数名：prvfrmxxEN00O0_Init
    '機　能：各種初期化処理(画面ｺﾝﾄﾛｰﾙ、変数等)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 12:11:48 N.Kojima
    '更新日：2008/06/12 (Thu) 16:19:01 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 13:28:45 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2008/06/12 (Thu) 16:19:01 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub prvfrmxxEN00O0_Init()
        
        Dim lctlControl         As Control      'ｺﾝﾄﾛｰﾙ名称
        Dim llngNowByte         As Integer      'ﾊﾞｲﾄ数を格納
        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim ltypLotReserve      As LotReserve   'ﾛｯﾄ投入予約情報格納構造体の初期化用構造体

        Try
            
            '@=======================
            '@　ﾒﾆｭｰ関連付け処理(ﾌｫｰﾑ名、引継ぎﾌﾗｸﾞetc･･･)
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00O0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
                
            '@画面ｻｲｽﾞの初期値設定
            With Me
                .Height = CMfrmxxEN00O0Height           '高さ
                .Width = CMfrmxxEN00O0Width             '幅
            End With
            
            
            '@-----------------------
            '@　各種ｺﾝﾄﾛｰﾙの初期化
            '@-----------------------
            cmbPD.ListIndex = -1                        '機種
            cmbDivision.ListIndex = -1                  '種別
            calStartDate.Value = _
                Format$(Now, CPstrDateTimeYMD)          '投入予定日
            cmbGroup.ListIndex = -1                     '部門
            cmbLotManager.ListIndex = -1                'ﾛｯﾄ担当
            
        '@↓2011/04/26 (Tue) 13:17:25 T.Oide **************************************************
            With cmbLotSend                                         '@送品ｺﾝﾎﾞ-----------
                .ValueCol = 1                                       '値取得列：あり/なし
                .AddItem(CPstrNasiFlg & vbTab & CPlngLotSendNasi)    '0/なし
                .AddItem(CPstrAriFlg & vbTab & CPlngLotSendAri)      '1/あり
                .ListIndex = -1                                     '選択なし
            End With
        '@↑2011/04/26 (Tue) 13:17:25 T.Oide **************************************************
            
            lblEntryID.Text = vbNullString           'ｴﾝﾄﾘID
            lblEntryName.Text = vbNullString         'ｴﾝﾄﾘ名
            lblLotID.Text = vbNullString             'ﾛｯﾄID
            
            
            '@-----------------------
            '@　各種ｺﾝﾄﾛｰﾙの初期設定
            '@-----------------------
            '@各種ｺﾝﾎﾞの初期設定(ﾌｫｰﾑ上のｺﾝﾄﾛｰﾙに対して処理を行う)
            For Each lctlControl In Me.Controls
                
                '@ｺﾝﾄﾛｰﾙがComboBoxExか
                If TypeOf lctlControl Is ComboBoxEx Then

                    With Ctype(lctlControl, ComboBoxEx)
                        .DirectInput = False                        '直接入力：不可
                        .DispCols = CMlngComboDispCols1             '表示列数：1
                        .GetCol = CMlngComboGetCol                  '値取得列：0
                        .Font = New Font(.GridFont.FontFamily, _
                            CMlngComboFontSize, .GridFont.Style, .GridFont.Unit)     'ﾌｫﾝﾄｻｲｽﾞ：流動系ｻｲｽﾞ
                        .GridFont = New Font(.GridFont.FontFamily, _
                            CMlngComboGridFontSize, .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ：流動系ｻｲｽﾞ
                        .RowHeight = CMlngComboRowHeight            '行高：流動系ｻｲｽﾞ
                    End With
                End If
            Next
            
            '@各種ｺﾝﾎﾞの文字表示位置設定(左中央)
            cmbPD.ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter            '機種
            cmbDivision.ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter      '種別
            cmbGroup.ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter         '部門
            cmbLotManager.ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter    'ﾛｯﾄ担当
        '@↓2011/04/26 (Tue) 13:15:16 T.Oide **************************************************
            cmbLotSend.ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter       '送品
        '@↑2011/04/26 (Tue) 13:15:16 T.Oide **************************************************

            '@各種ｶﾚﾝﾀﾞｰの初期設定(投入予定日)
            With calStartDate
                .CalendarHeight = CPlngClHeight         '表示：現在日
                .CalendarWidth = CPlngClWidth           '高さ
                .DayFont = New Font(.GridFont.FontFamily, _
                       CPlngClFontSize, .GridFont.Style, .GridFont.Unit)     'ﾌｫﾝﾄｻｲｽﾞ
                .TitleFont = New Font(.GridFont.FontFamily, _
                       CPlngClTlFontSize, .GridFont.Style, .GridFont.Unit)   'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, _
                       CPlngClGridFontSize, .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
            End With
            
            '@作業ﾒﾓの設定
            With txtWorkMemo
                
                .ChrMaxByte = CPlngLotCommentsMaxByte   '最大入力可能Byte数を格納
                .Text = vbNullString                    '初期化
                llngNowByte = .NowByte                  '現状のﾊﾞｲﾄ数を格納
                
                '@=======================
                '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換)
                '@=======================
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            End With
            
            '@各種ｺﾝﾄﾛｰﾙの有効/無効制御
            cmbDivision.Enabled = False                 '種別
            txtWFNum.Enabled = False                    'WF枚数
            calStartDate.Enabled = False                '投入予定日
            cmbGroup.Enabled = False                    '部門
            cmbLotManager.Enabled = False               'ﾛｯﾄ担当
        '@↓2011/04/26 (Tue) 13:19:19 T.Oide **************************************************
            cmbLotSend.Enabled = False                  '無効
        '@↑2011/04/26 (Tue) 13:19:19 T.Oide **************************************************

            cmdEntry.Enabled = False                    'ｴﾝﾄﾘﾎﾞﾀﾝ
            cmdPlanList.Enabled = False                 '投入予定一覧ﾎﾞﾀﾝ
            cmdRegist.Enabled = False                   '確定ﾎﾞﾀﾝ
            
            '@各種ﾎﾞﾀﾝのCausesValidationをFalseに設定
            cmdClose.CausesValidation = False           '閉じるﾎﾞﾀﾝ
            cmdPlanList.CausesValidation = False        '投入予定一覧ﾎﾞﾀﾝ
            
            
            '@-----------------------
            '@　各種変数/構造体の初期化
            '@-----------------------
            mstrPDID = vbNullString                     '機種退避用
            mstrGroupID = vbNullString                  '部門退避用
            mlngPdEntryMaxWFCount = 0                   'ﾏｽﾀｴﾝﾄﾘの最大WF枚数
            
            '機種一覧格納用
            If Not IsNothing(mtypPdList) Then
                mtypPdList.Clear()
                mtypPdList = Nothing
            End If
            mlngPdListCnt = 0                           '機種一覧ｶｳﾝﾄ
            '種別一覧格納用
            If Not IsNothing(mtypDivisionList) Then
                mtypDivisionList.Clear()
                mtypDivisionList = Nothing
            End If
            mlngDivisionCnt = 0                         '種別一覧ｶｳﾝﾄ
            'ﾛｯﾄ担当一覧格納用
            If Not IsNothing(mtypLotManagerList) Then
                mtypLotManagerList.Clear()
                mtypLotManagerList = Nothing
            End If
            mlngLotManagerListCnt = 0                   'ﾛｯﾄ担当一覧ｶｳﾝﾄ
            'ﾏｽﾀ工順一覧格納用
            If Not IsNothing(mtypEntryList) Then
                mtypEntryList.Clear()
                mtypEntryList = Nothing
            End If
            mlngEntryListCnt = 0                        'ﾏｽﾀ工順一覧ｶｳﾝﾄ
            mtypLotReserve = ltypLotReserve             'ﾛｯﾄ投入予約情報格納構造体
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "prvfrmxxEN00O0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：入力(選択)ﾁｪｯｸ＆確定ﾎﾞﾀﾝ制御処理
    '引　数：llngCheckFlg   ：ﾁｪｯｸﾌﾗｸﾞ(1:ﾛｯﾄ作成基礎情報)
    '戻り値：True：OK、False：NG
    '作成日：2004/07/27 (Tue) 11:01:40 N.Kojima
    '更新日：2011/04/26 (Tue) 15:18:36 T.Oide
    '備　考：
    '　　　：2008/06/13 (Fri) 09:53:34 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    '　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
    Private Function prvblnInput_Chk()

        Dim lstrStartDT             As String       '投入予定日
        Dim lstrNowDT               As String       'ｼｽﾃﾑ日付

        Try
            
        '@↓2011/04/26 (Tue) 15:17:54 T.Oide **************************************************
        '@    '@新規ﾛｯﾄ採番ｴﾘｱが全て入力されているか
        '@    '@　⇒機種、種別、WF枚数、投入予定日、部門、ﾛｯﾄ担当
        '@    If cmbPd.Text <> vbNullString And _
        '@        cmbDivision.Text <> vbNullString And _
        '@        txtWFNum.Text <> vbNullString And _
        '@        calStartDate.Value <> vbNullString And _
        '@        cmbGroup.Text <> vbNullString And _
        '@        cmbLotManager.Text <> vbNullString Then
                
            '@新規ﾛｯﾄ採番ｴﾘｱが全て入力されているか
            '@　⇒機種、種別、WF枚数、投入予定日、部門、ﾛｯﾄ担当
            If cmbPD.Text <> vbNullString And _
                cmbDivision.Text <> vbNullString And _
                txtWFNum.Text <> vbNullString And _
                calStartDate.Value <> vbNullString And _
                cmbGroup.Text <> vbNullString And _
                cmbLotManager.Text <> vbNullString And _
                cmbLotSend.Text <> vbNullString Then
        '@↑2011/04/26 (Tue) 15:17:54 T.Oide **************************************************
                
                
                '@全て選択されている場合
                
                '@WF枚数が"0"以外か
                If txtWFNum.Text <> CPstrZero Then

                    '@ｴﾝﾄﾘﾎﾞﾀﾝを有効にする
                    cmdEntry.Enabled = True
                Else
                    '@ｴﾝﾄﾘﾎﾞﾀﾝを無効にする
                    cmdEntry.Enabled = False
                End If
            Else
                '@1つでも未選択の項目がある場合
                
                '@ｴﾝﾄﾘﾎﾞﾀﾝを無効にする
                cmdEntry.Enabled = False
            End If
            
            
            '@-----------------------
            '@　各種ｺﾝﾄﾛｰﾙの個別ﾁｪｯｸ
            '@-----------------------
            '@機種がNULLか
            If cmbPD.Value = vbNullString Then
                
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                Exit Function
            End If
            
            '@種別がNULLか
            If cmbDivision.Value = vbNullString Then
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                Exit Function
            End If
            
            '@WF枚数が"0"、またはNULLか
            If txtWFNum.Text = vbNullString Or txtWFNum.Text = "0" Then
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                Exit Function
            End If
            
            '@投入予定日を"YYYY/MM/DD"のﾌｫｰﾏｯﾄで格納する
            'NSYS 正しい日付かを判定する
            If IsDate(calStartDate.Value) = True Then
                lstrStartDT = Format$(CDate(calStartDate.Value), CPstrDateTimeYMD)
            Else
                lstrStartDT = calStartDate.Value
            End If
            '@現在日付を格納する
            lstrNowDT = Format$(Now, CPstrDateTimeYMD)
            
            '@投入予定日が日付型か
            If IsDate(lstrStartDT) = True Then
            
                '@投入予定日が過去日付か
                If lstrStartDT < lstrNowDT Then
                
                    '@確定ﾎﾞﾀﾝを無効にする
                    cmdRegist.Enabled = False
                    Exit Function
                End If
            Else
                '@日付型ではない場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                Exit Function
            End If
            
            '@部門がNULLか
            If cmbGroup.Value = vbNullString Then
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                Exit Function
            End If

            '@ﾛｯﾄ担当がNULLか
            If cmbLotManager.Value = vbNullString Then
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                Exit Function
            End If

        '@↓2011/04/26 (Tue) 15:24:08 T.Oide **************************************************
            '@送品がNULLか
            If cmbLotSend.Value = vbNullString Then
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                Exit Function
            End If
        '@↑2011/04/26 (Tue) 15:24:08 T.Oide **************************************************


            '@ｴﾝﾄﾘIDがNULLか
            If lblEntryID.Text = vbNullString Then
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                Exit Function
            Else
                '@ｴﾝﾄﾘIDがNULL以外か
            
                '@確定ﾎﾞﾀﾝを有効にする
                cmdRegist.Enabled = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "prvblnInput_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnLotReserve_Chk
    '機　能：確定時ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2004/07/27 (Tue) 11:11:20 N.Kojima
    '更新日：2011/05/06 (Fri) 16:07:58 T.Oide
    '備　考：
    '　　　：2005/09/28 (Wed) 12:06:32 S.Deguchi    機種/種別でNullﾁｪｯｸをValueで行っていたのをﾃｷｽﾄで行うように修正
    '　　　：2008/06/13 (Fri) 10:13:08 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    '　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
    Private Function prvblnLotReserve_Chk() As Boolean

        Dim lstrStartDT             As String       '投入予定日
        Dim lstrNowDT               As String       'ｼｽﾃﾑ日付
    '@↓2011/05/06 (Fri) 15:54:47 T.Oide **************************************************
        Dim lstrAns                 As String       '確認結果
    '@↑2011/05/06 (Fri) 15:54:47 T.Oide **************************************************

        Try
            
            '@戻り値の初期化
            prvblnLotReserve_Chk = False
            
            '@-----------------------
            '@　機種のﾁｪｯｸ
            '@-----------------------
            '@機種がNULLか
            If cmbPD.Value = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0013)
                '@ﾒｯｾｰｼﾞ："<TRM13W>$$機種が設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@機種にﾌｫｰｶｽｾｯﾄし、処理終了
                Call pubSetFocus(cmbPD)
                Exit Function
            End If
            
            '@-----------------------
            '@　種別のﾁｪｯｸ
            '@-----------------------
            '@種別がNULLか
            If cmbDivision.Value = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0014)
                '@ﾒｯｾｰｼﾞ："<TRM14W>$$種別が設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@種別にﾌｫｰｶｽｾｯﾄし、処理終了
                Call pubSetFocus(cmbDivision)
                Exit Function
            End If
            
            '@-----------------------
            '@　WF枚数のﾁｪｯｸ
            '@-----------------------
            '@WF枚数がNULL、または"0"か
            If txtWFNum.Text = vbNullString Or txtWFNum.Text = CPstrZero Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0015)
                '@ﾒｯｾｰｼﾞ："<TRM15W>$$ウエハ枚数を指定して下さい。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@WF枚数にﾌｫｰｶｽｾｯﾄし、処理終了
                Call pubSetFocus(txtWFNum)
                Exit Function
            End If

            '@-----------------------
            '@　投入予定日のﾁｪｯｸ
            '@-----------------------
            '@投入予定日を"YYYY/MM/DD"のﾌｫｰﾏｯﾄで格納
            If IsDate(calStartDate.Value) = True Then
                lstrStartDT = Format$(CDate(calStartDate.Value), CPstrDateTimeYMD)
            Else
                lstrStartDT = calStartDate.Value
            End If
            '@現在日付を格納
            lstrNowDT = Format$(Now, CPstrDateTimeYMD)
            
            '@投入予定日が日付型か
            If IsDate(lstrStartDT) = True Then
            
                '@投入予定日が過去か
                If lstrStartDT < lstrNowDT Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                    '@ﾒｯｾｰｼﾞ："<TRM10W>$$過去の日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@投入予定日にﾌｫｰｶｽｾｯﾄし、処理終了
                    Call pubSetFocus(calStartDate)
                    Exit Function
                End If
            Else
                '@投入予定日が日付型ではない場合
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                '@ﾒｯｾｰｼﾞ："<TRM16W>$$設定されていない項目があります。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@投入予定日にﾌｫｰｶｽｾｯﾄし、処理終了
                Call pubSetFocus(calStartDate)
                Exit Function
            End If
            
            '@-----------------------
            '@　部門のﾁｪｯｸ
            '@-----------------------
            '@部門がNULLか
            If cmbGroup.Value = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000Y, lblGroupTitle.Text)
                '@ﾒｯｾｰｼﾞ："<TRM0YW>$$[部門]が選択されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@部門にﾌｫｰｶｽｾｯﾄし、処理終了
                Call pubSetFocus(cmbGroup)
                Exit Function
            End If

            '@-----------------------
            '@　ﾛｯﾄ担当のﾁｪｯｸ
            '@-----------------------
            '@ﾛｯﾄ担当がNULLか
            If cmbLotManager.Value = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0017)
                '@ﾒｯｾｰｼﾞ："<TRM17W>$$ロット担当が設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾛｯﾄ担当にﾌｫｰｶｽｾｯﾄし、処理終了
                Call pubSetFocus(cmbLotManager)
                Exit Function
            End If

            '@-----------------------
            '@　ｴﾝﾄﾘのﾁｪｯｸ
            '@-----------------------
            '@ｴﾝﾄﾘﾁｪｯｸ
            If lblEntryID.Text = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                '@ﾒｯｾｰｼﾞ："<TRM16W>$$設定されていない項目があります。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｴﾝﾄﾘﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄし、処理終了
                Call pubSetFocus(cmdEntry)
                Exit Function
            End If
            
        '@↓2011/05/06 (Fri) 15:37:11 T.Oide **************************************************
            'QUで送品[あり]か
            If cmbDivision.Text = CPstrFlowClassQU And cmbLotSend.Value = 1 Then
            
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0109)
                    '@ﾒｯｾｰｼﾞ："<TRM14W>$$品確ロットで送品[あり]が選択されています。よろしいですか?"
                    lstrAns = publngMsgBoxInfo(pstrDMsg, vbOKCancel, frmxxCM00M0.Instance.Text, True, 16)
                    
                    If lstrAns = vbCancel Then
                        '@処理終了
                        Exit Function
                    End If
            End If
        '@↑2011/05/06 (Fri) 15:37:11 T.Oide **************************************************
            
            
            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblnLotReserve_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "prvblnLotReserve_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvcmbPdList_Disp
    '機　能：機種ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/24 (Fri) 08:34:43 S.Deguchi
    '更新日：2008/06/13 (Fri) 10:34:20 N.Kojima
    '備　考：
    '　　　：2005/07/26 (Tue) 10:57:25 N.Kasai      L/R色追加
    '　　　：2008/06/13 (Fri) 10:34:20 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub prvcmbPdList_Disp()

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ

        Try

            With cmbPD
            
                '@機種が1件以上存在するか
                If mlngPdListCnt > 0 Then
                    Dim tmp As ProductList 
                    For llngCnt = 0 To mlngPdListCnt -1
                    
                        '@最大WF枚数が数値か
                        If IsNumeric(mtypPdList(llngCnt).strMaxWFCount) = True Then
                        
                            '@最大WF枚数が25枚以上か
                            If CLng(mtypPdList(llngCnt).strMaxWFCount) > CMlngMaxWfCount Then
                            	tmp = mtypPdList(llngCnt)
                                '@最大WF枚数にNULLをｾｯﾄする
                                tmp.strMaxWFCount = vbNullString
                                mtypPdList(llngCnt) = tmp
                            End If
                            
                            '@ｺﾝﾎﾞ内容設定：機種ID/最大WF枚数/NULL/NULL/文字色/背景色
                            .AddItem(mtypPdList(llngCnt).strProductID _
                                   & vbTab _
                                   & mtypPdList(llngCnt).strMaxWFCount _
                                   & vbTab _
                                   & vbNullString _
                                   & vbTab _
                                   & vbNullString _
                                   & vbTab _
                                   & mtypPdList(llngCnt).strForeColor _
                                   & vbTab _
                                   & mtypPdList(llngCnt).strBackColor)
                        End If
                    Next
                    
                    '@機種が1件か
                    If .ListCount = 1 Then
                    
                        '@ﾃﾞﾌｫﾙﾄで表示する
                        .ListIndex = 0
                    End If
                End If
                
                '@値取得列を最大WF枚数列に設定
                .ValueCol = CMlngComboDispCols1
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "prvCmbPdList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbDivisionList_Disp
    '機　能：種別ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/24 (Fri) 08:47:54 S.Deguchi
    '更新日：2008/06/13 (Fri) 10:38:27 N.Kojima
    '備　考：
    '　　　：2008/06/13 (Fri) 10:38:27 N.Kojima     部門＆ﾛｯﾄ担当を追加。(案件№02884)
    Private Sub prvcmbDivisionList_Disp()

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ

        Try

            With cmbDivision
            
                .Clear      'ｸﾘｱ
            
                '@種別ﾃﾞｰﾀ数が1件以上存在するか
                If mlngDivisionCnt > 0 Then

                    For llngCnt = 0 To mlngDivisionCnt -1
                    
                        '@ｺﾝﾎﾞ内容設定：種別
                        .AddItem(mtypDivisionList(llngCnt).strDivisionID)
                    Next llngCnt
            
                    '@種別が1件か
                    If .ListCount = 1 Then
                    
                        '@ﾃﾞﾌｫﾙﾄで表示する
                        .ListIndex = 0
                    End If
                    
                    '@種別ｺﾝﾎﾞを有効にする
                    .Enabled = True
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "prvCmbDivisionList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/06/12 (Thu) 17:58:58 N.Kojima **************************************************
    '関数名：prvCmbLotManager_Disp
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/12 (Thu) 17:59:02 N.Kojima
    '更新日：2008/06/12 (Thu) 17:59:02
    '備　考：
    Private Sub prvCmbLotManager_Disp()

        Dim llngCnt As Integer      '汎用ｶｳﾝﾀ

        Try

            With cmbLotManager
            
                .Clear      'ｸﾘｱ
            
                For llngCnt = 0 To mlngLotManagerListCnt -1
                            
                    '@ｺﾝﾎﾞ内容設定：ﾛｯﾄ担当者名/ﾛｯﾄ担当者ID
                    .AddItem(mtypLotManagerList(llngCnt).strTechManName _
                           & vbTab _
                           & mtypLotManagerList(llngCnt).strTechManID)
                Next
                
                '@値取得列をﾛｯﾄ担当者ID列に設定
                .ValueCol = CMlngComboDispCols1
                
                '@ﾛｯﾄ担当が1件の場合は表示
                If .ListCount = 1 Then
                    .ListIndex = 0
                End If
                
                '@ﾛｯﾄ担当を有効にする
                .Enabled = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN00O0
                .strProcName = "prvCmbLotManager_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/06/12 (Thu) 17:58:58 N.Kojima **************************************************



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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraMster.Paint, fraNew.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
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

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmbPD.Enter,
                                                                       cmbDivision.Enter,
                                                                       txtWFNum.Enter,
                                                                       calStartDate.Enter,
                                                                       txtWorkMemo.Enter,
                                                                       cmdEntry.Enter,
                                                                       cmdMemoDown.Enter,
                                                                       cmdMemoUp.Enter,
                                                                       cmdClose.Enter,
                                                                       cmdRegist.Enter,
                                                                       cmdPlanList.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '投入予定一覧ボタン、閉じるボタンの場合は自動Validate = OFF
            Case cmdPlanList.Name,cmdClose.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
