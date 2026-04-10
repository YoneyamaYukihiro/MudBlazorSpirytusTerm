'ﾌｧｲﾙ名：xxCM00I0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：工程異常/不適合品処理票登録 ﾒｲﾝﾌｫｰﾑ
'作成日：2005/08/04 (Thu) 09:53:45 S.Deguchi
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00I0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00I0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00I0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00I0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00I0)
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
    '@機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion             As String = "08.01"

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyCM00I0          'ﾛｰｶﾙ機能ID

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_McGrouplistVer       As String = "01.00"                 '装置ｸﾞﾙｰﾌﾟ取得
    Private Const CMstreq__areacurlistVer       As String = "02.00"                 'ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置状態情報取得
    Private Const CMstrexcplotcheckVer          As String = "01.00"                 'ﾛｯﾄ情報ﾁｪｯｸ
    Private Const CMstrexcpchgreportVer         As String = "01.00"                 '工程異常/不適合品処理票登録

    '@vsfLotListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfColLotID              As Integer = 0                         'ﾛｯﾄID

    '@vsfLotListの定数宣言(幅)
    Private Const CMlngvsfWColLotID             As Integer = 24                         'ﾛｯﾄID

    '@vsfLotListの定数宣言(ｶﾗﾑ)
    Private Const CMstrvsfColLotID              As String = "ロットID"                 'ﾛｯﾄID

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle              As Integer = 0                        'ﾀｲﾄﾙ行（行）
    Private Const CMlngVsfColTitle              As Integer = 0                        'ﾀｲﾄﾙ行（列）
    Private Const CMlngVsfHFontSize             As Integer = 12                       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfFontSize              As Integer = 16                       'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight               As Integer = 24                       'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                As Integer = 38                       '1ｽﾛｯﾄの高さ
    '@↓2008/01/08 (Tue) 16:16:49 N.Kojima **************************************************
    Private Const CMlngvsfMaxDispRows           As Integer = 5                         '1ﾍﾟｰｼﾞの最大表示数
    '@↑2008/01/08 (Tue) 16:16:49 N.Kojima **************************************************

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize              As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize          As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbRowHeight             As Integer = 43                        'ﾘｽﾄ行の高さ
    Private Const CMlngCmbDispCols1             As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbValueCol0             As Integer = 0                         '値取得個数=0
    Private Const CMlngCmbValueCol1             As Integer = 1                         '値取得個数=1
    Private Const CMlngCmbGridCol0              As Integer = 0                         '名称列番=0

    '@定数宣言
    Private Const CMstrDefault0                 As String = "0"                     '初期設定値(=0)
    Private Const CMstrDefault1                 As String = "1"                     '初期設定値(=1)
    Private Const CMlngDefault1                 As Integer = 1                         '初期設定値(=1)
    Private Const CMlngDefault2                 As Integer = 2                         '初期設定値(=2)
    Private Const cmlngMaxByte10                As Integer = 10                        'ﾛｯﾄIDMaxByte=10

    '@工程異常/不適合品のﾌﾗｸﾞ設定
    Private Const CMlngoptTroubleLot            As Integer = 0                         '工程異常処理(ﾛｯﾄ)
    Private Const CMlngoptIncongLot             As Integer = 1                         '不適合品処理(ﾛｯﾄ)
    Private Const CMlngoptTroubleWp             As Integer = 2                         '工程異常処理(装置)
    Private Const CMstrTroubleFlag              As String = "0"                     '工程異常処理ﾌﾗｸﾞ
    Private Const CMstrIncongFlag               As String = "1"                     '不適合品処理ﾌﾗｸﾞ
    Private Const CMstrUnitWF                   As String = "1"                     '単位：WF
    Private Const CMstrUnitChip                 As String = "2"                     '単位：Chip
    Private Const CMstrCFFlag_WF                As String = "0"                     'CFﾌﾗｸﾞ：WF(0)
    Private Const CMstrCFFlag_CF                As String = "1"                     'CFﾌﾗｸﾞ：CF(1)
    Private Const CMstrCFFlag_All               As String = "2"                     'CFﾌﾗｸﾞ：ALL(2)
    Private Const CMstrDispose                  As String = "0"                     '処置ﾌﾗｸﾞの初期値：未処置

    '@ｼｽﾃﾑﾌﾞﾛｯｸ定数宣言
    Private Const CMstrA0                       As String = "A0"                    'ｼｽﾃﾑﾌﾞﾛｯｸ

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@ﾛｯﾄﾘｽﾄ構造体
    Private Structure LocalLotList
        Dim strLotID                                As String                           'ﾛｯﾄID
        Dim strCFLotFlag                            As String                           'CFﾛｯﾄﾌﾗｸﾞ(0:CFﾛｯﾄ以外 1:CFﾛｯﾄ)
        Dim strWFQuantity                           As String                           'WF枚数
        Dim strChipQuantity                         As String                           'ﾁｯﾌﾟ数
        Dim strPdId                                 As String                           '機種
        Dim strOpID                                 As String                           '大工程
        Dim strStepID                               As String                           '小工程
        Dim strWpID                                 As String                           '装置ID
        Dim strWpName                               As String                           '装置名
    End Structure
    Private mtypLotList                         As LocalLotList                     '比較基準ﾛｯﾄ格納構造体

    Private Structure LocalExcpLotList
        Dim lngLocalLotListCnt                      As Integer                          'ﾛｯﾄ数
        Dim typLotList                          As List(Of LocalLotList)                '構造体
    End Structure
    Private mtypExcpLotList                     As LocalExcpLotList                 '登録時ﾛｯﾄ構造体

    '@退避領域
    Private mstrFindDate                        As String                           '発見日時退避領域
    Private mstrEmpID                           As String                           '発見者ID退避領域
    Private mstrEmpName                         As String                           '発見者名退避領域
    Private mstrDeptID                          As String                           '発見職場ID退避領域
    Private mstrDeptName                        As String                           '発見職場名退避領域
    Private mstrMcGroupName                     As String                           '装置ｸﾞﾙｰﾌﾟID格納領域
    Private mstrWpID                            As String                           '装置ID格納領域
    Private mstrWpName                          As String                           '装置名称格納領域
    Private mtypMcGroupList                     As McGroupList                      'ｴﾘｱﾘｽﾄ格納
   Private mtypWpList                          As List(Of AreaEquipmentList)        '装置ﾘｽﾄ格納
    Private mlngWpListCnt                       As Integer                          '装置ﾘｽﾄ数
    Private mblnFormActivateFlag                As Boolean                          'ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄﾌﾗｸﾞ

    Private buttonProcessing                    As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                          'NSYS WindowCloseフラグ
    Private FocusControlFlag                    As Boolean                          'NSYS ActiveControl格納

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
        
        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfLotList, cmdUp, cmdDown)
       

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
    '作成日：2004/08/09 (Mon) 16:58:12 S.Deguchi
    '更新日：2005/10/25 (Tue) 09:57:56 S.Deguchi
    '備　考：
    '　　　：2005/10/26 (Tue) 09:44:16 S.Deguchi    不具合№2404の対応で機能ﾊﾞｰｼﾞｮﾝ判定処理修正
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean              '結果格納
        
        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00U0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                Exit Sub
            End If

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄﾌﾗｸﾞの初期化
            mblnFormActivateFlag = False
            
            '@画面の初期化
            Call prvfrmxxCM00I0_Init()
            
            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True
            
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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/18 (Wed) 13:52:37 S.Deguchi
    '更新日：2004/08/18 (Wed) 13:52:37
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）

        Try
                          
            '@引継ぎ情報表示済みﾌﾗｸﾞの判定
            '@FormLoad後、最初の1回しか処理しない
            If mblnFormActivateFlag = False Then
                '@ﾌﾗｸﾞを立てる
                mblnFormActivateFlag = True
                
                '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
                lstrFormName = Me.Name
                lstrEventName = "Form_Activate"
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@装置ｸﾞﾙｰﾌﾟ取得（処理区分：全件）
                lblnAns = pubblnMasMcGroupList_Sel(CMstrmas_McGrouplistVer, _
                                                   CPstrCD02, _
                                                   pstrSBID, _
                                                   mtypMcGroupList)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                    
                    Exit Sub
                End If
                    
                '@情報引継処理を呼出す
                Call prvfrmxxCM00I0_Set()
            
                '@引継情報が存在する場合
                If vsfLotList.Rows.Count > 1 Then
                    '@ﾛｯﾄﾘｽﾄの1件目のWF/CF情報を取得する
                    With mtypLotList
                        .strLotID = vsfLotList.GetData(1, CMlngvsfColLotID)
                    End With
                    '@ﾛｯﾄ情報取得
                    lblnAns = prvblnExcpLotCheck_Sel(mtypLotList)
                    '@結果判定
                    If lblnAns = False Then
                    '@失敗の場合
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        '@Escﾎﾞﾀﾝを有効
                        Me.CancelButton = cmdClose
                        
                        Exit Sub
                    End If
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@装置ｸﾞﾙｰﾌﾟCombo作成
                Call prvcmbMcGroupList_Disp(mtypMcGroupList)
                
                '@装置ｸﾞﾙｰﾌﾟ/装置Comboを使用不可に設定
                cmbMcGroupName.Enabled = False
                cmbMcGroupName.Text = vbNullString
                cmbWpID.Enabled = False
                cmbWpID.Text = vbNullString
                
                '@ﾁｪｯｸ処理へ
                Call prvcmdRegist_Chk()
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
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
    '機　能：ﾌｫｰﾑのKeyDown処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2004/08/09 (Mon) 17:08:06 S.Deguchi
    '更新日：2008/01/08 (Tue) 17:00:23 N.Kojima
    '備　考：
    '　　　：2008/01/08 (Tue) 17:00:23 N.Kojima     ｷｰﾎﾞｰﾄﾞでのｽｸﾛｰﾙ不備修正。(案件№02499)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

        '@↓2008/01/08 (Tue) 16:07:53 N.Kojima **************************************************
            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、前頁ﾎﾞﾀﾝ、次頁ﾎﾞﾀﾝ）
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfLotList, cmdUP, cmdDown)
        '@↑2008/01/08 (Tue) 16:07:53 N.Kojima **************************************************

            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名称による処理分岐
            Select Case ActiveControl.Name
                '@ﾌｫｰｶｽが追加ﾛｯﾄIDにある場合
                Case txtAddLotID.Name
                    '@Enterで次ﾌｫｰｶｽへ
                    If e.KeyCode = Keys.Return Then
                        '@追加ﾛｯﾄIDのValidate処理へ
                        RemoveHandler txtAddLotID.Validating,AddressOf txtAddLotID_Validate
                        Call txtAddLotID_Validate(txtAddLotID,New CancelEventArgs(False))
                        AddHandler txtAddLotID.Validating,AddressOf txtAddLotID_Validate
                    End If
                
                Case cmbMcGroupName.Name
                    '@Enterで次ﾌｫｰｶｽへ
                    If e.KeyCode = Keys.Return Then
                        '@装置ｸﾞﾙｰﾌﾟのValidate処理へ
                        RemoveHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate 
                        Call cmbMcGroupName_Validate(cmbMcGroupName,New CancelEventArgs(False))
                        AddHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate 
                    End If
                    
                Case cmbWpID.Name
                    '@Enterで次ﾌｫｰｶｽへ
                    If e.KeyCode = Keys.Return Then
                        '@装置のValidate処理へ
                        RemoveHandler cmbWpID.Validating,AddressOf cmbWpID_Validate
                        Call cmbWpID_Validate(cmbWpID,New CancelEventArgs(False))
                        AddHandler cmbWpID.Validating,AddressOf cmbWpID_Validate
                    End If
                
                Case Else
                    '@Enterで次ﾌｫｰｶｽへ
                    If e.KeyCode = Keys.Return Then
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    End If
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
    '機　能：×ﾎﾞﾀﾝで終了する場合のﾌｫｰﾑ終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/08/09 (Mon) 16:58:12 S.Deguchi
    '更新日：2004/11/01 (Mon) 15:26:10 N.Kasai
    '備　考：2004/11/01 (Mon) 15:26:10 N.Kasai      閉じるﾎﾞﾀﾝ追加
    '　　　：2005/03/07 (Mon) 14:27:40 S.Deguchi    ﾊﾟﾌﾞﾘｯｸ構造体の初期化処理を追加
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm             As Boolean              '開放結果格納
        Dim ltypExcpConnectList     As ExcpConnectList      '初期化用構造体
        Dim ltypLocalExcpLotList    As LocalExcpLotList     '初期化用構造体
        Dim ltypLocalLotList        As LocalLotList         '初期化用構造体
        
        Try
                                 
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ﾊﾟﾌﾞﾘｯｸ・ﾓｼﾞｭｰﾙ構造体を初期化する(画面終了時構造体をｸﾘｱ)
            ltypExcpConnectList = New ExcpConnectList
            ltypLocalExcpLotList = New LocalExcpLotList
            ltypLocalLotList = New LocalLotList
            ptypExcpConnectList = ltypExcpConnectList
            mtypExcpLotList = ltypLocalExcpLotList
            mtypLotList = ltypLocalLotList
            
            If mtypMcGroupList.typMcGroupList Is Nothing Then
                mtypMcGroupList.typMcGroupList = New List(Of McList)
            Else
                mtypMcGroupList.typMcGroupList.clear
            End If
            If mtypWpList Is Nothing Then
                mtypWpList = New List(Of AreaEquipmentList)
            Else
                mtypWpList.clear
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化
            '@（装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要）
            pblnFormLoad = False
            
            If pblnfrmxxCM00I0Kbn = True Then
            '@引継起動の場合
                '@ﾊﾟﾌﾞﾘｯｸ変数を初期化
                pblnfrmxxCM00I0Kbn = False
            Else
            '@単独起動の場合
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
            End If
            
            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄとの関連付けを解除
            
            
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
    '機　能：処理中止
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/09 (Mon) 16:58:12 S.Deguchi
    '更新日：2018/11/19 (Mon) 10:04:08 Y.Yoneyama
    '備　考：
    '　　　：2005/03/03 (Thu) 11:44:07 S.Deguchi    戻り関数の処理を追加しました。(不具合№594)
    '　　　：2018/11/19 (Mon) 10:04:08 Y.Yoneyama   防湿ALD対応
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo          As CommonInfo           '構造体(ﾀﾞﾐｰ)
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            
            
            '@親ﾌｫｰﾑから起動か否かによる処理分岐
            If pblnfrmxxCM00I0Kbn = True Then
            '@親ﾌｫｰﾑからの場合
                '@ﾌｫｰﾑを閉じる
                Me.Close()
            Else
            '@単独起動の場合
                '@引継起動の場合はﾁｪｯｸ処理をまず動かす
                Call prvfrmxxCM00I0_Chk()
                
                '@引継ぎ情報のキャリアIDが空白かどうか判定する
                If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合
                    '@装置別ﾛｯﾄ一覧から引き継いで起動された場合
                    If pblnfrmxxEN0150Kbn = True Then
                        '@装置別ﾛｯﾄ一覧を起動する
                        Call pubMenuSelect_Proc(CPstrKeyEN0150)
                        
        '@↓2018/11/19 (Mon) 10:04:08 Y.Yoneyama **************************************************
                    '@装置別ﾛｯﾄ一覧(防湿ALD)から引き継いで起動された場合
                    ElseIf pblnfrmxxEN0151Kbn = True Then
                        '@装置別ﾛｯﾄ一覧(防湿ALD)を起動する
                        Call pubMenuSelect_Proc(CPstrKeyEN0151)
        '@↑2018/11/19 (Mon) 10:04:08 Y.Yoneyama **************************************************
                        
                    Else
                        '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧から引き継いで起動された場合
                        If pblnfrmxxEN00J0Kbn = True Then
                            '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧を起動する
                            Call pubMenuSelect_Proc(CPstrKeyEN00J0)
                        Else
                        '@工程別ﾛｯﾄ一覧から引き継いで起動された場合
                            '@工程別ﾛｯﾄ一覧を起動する
                            Call pubMenuSelect_Proc(CPstrKeyEN0200)
                        End If
                    End If
                Else
                '@空白の場合
                    '@終了関数を実行する
                    Call publngEnd_Proc(CPstrKeyEN00U0, ltypCommonInfo)
                End If
            End If
            
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
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/09 (Mon) 16:58:12 S.Deguchi
    '更新日：2004/08/09 (Mon) 16:58:12
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrExcpNo              As String               '登録異常処理№
        
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
            
            '@発見日時を退避領域にｾｯﾄ
            mstrFindDate = Format$(Now, CPstrDateTimeYMDHMS)
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@登録情報のﾁｪｯｸ
            lblnAns = prvblnExcpReport_Chk()
            '@結果判定
            If lblnAns = False Then
            '@登録情報にNG項目が存在した場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            Else
            '@取得情報を内部変数へ退避
                mstrEmpID = pstrUserID              '作業者ID
                mstrEmpName = pstrUserName          '作業者名
                mstrDeptID = pstrDeptID             '作業者職場ID
                mstrDeptName = pstrDeptName         '作業者職場名
            End If
            
            '@ﾊﾟﾌﾞﾘｯｸ起動変数を初期化
            pblnfrmxxCM00H0Kbn = False
            
            '@工程異常/不適合品処理票登録処理へ
            lblnAns = prvblnExcpChgReport_Ins(lstrExcpNo)
            '@結果判定
            If lblnAns = False Then
            '@登録情報にNG項目が存在した場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@引継ぎ構造体に情報をｾｯﾄ
            With ptypExcpEditList
                '@異常処理№
                .strExcpNo = lstrExcpNo
                
                '@起案ｼｽﾃﾑﾌﾞﾛｯｸ
                '.strSbID = Mid(.strExcpNo, 2, 1) & CMstrA0
                .strSBId = pstrSBID
                
                '@起案時のﾛｯﾄ構成でCFﾌﾗｸﾞを返す
                If mtypExcpLotList.lngLocalLotListCnt > 0 Then
                    If mtypExcpLotList.typLotList(CMstrDefault0).strCFLotFlag = CMstrCFFlag_WF Then
                        .strCFLotFlag = CMstrCFFlag_WF
                    Else
                        .strCFLotFlag = CMstrCFFlag_CF
                    End If
                Else
                    '@装置で起案の場合
                    .strCFLotFlag = CMstrCFFlag_All
                End If
                
                '@ﾊﾟﾌﾞﾘｯｸ起動変数を初期化
                pblnfrmxxCM00H0Kbn = False
                
                '@起動処理
                frmxxCM00H0.Instance = New frmxxCM00H0()
                
                '@起動変数による処理分岐
                If pblnfrmxxCM00H0Kbn = False Then
                    '@画面をｱﾝﾛｰﾄﾞする
                    frmxxCM00H0.Instance = Nothing
                    
                    Exit Sub
                Else
                    '@工程異常登録ﾌｫｰﾑを表示
                    frmxxCM00H0.Instance.ShowDialog(Me)
                    frmxxCM00H0.Instance = Nothing
                
                    '@選択ﾌｫｰﾑをｱﾝﾛｰﾄﾞする
                    Call cmdClose_Click(sender,New EventArgs())
                End If
            End With
            
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

    '関数名：optAbnormal_Click
    '機　能：処理選択
    '引　数：Index：0：工程異常(ﾛｯﾄ)/1：不適合品(ﾛｯﾄ)/2：工程異常(装置)
    '戻り値：なし
    '作成日：2005/08/04 (Thu) 13:39:50 S.Deguchi
    '更新日：2005/08/04 (Thu) 13:39:50
    '備　考：
    Private Sub optAbnormal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optAbnormal0.Click,optAbnormal1.Click,optAbnormal2.Click
        
        Try
                '@工程異常処理票(ﾛｯﾄ),不適合品処理票(ﾛｯﾄ)
               If optAbnormal0.Checked = True Or optAbnormal1.Checked = True
                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ使用不可
                cmbMcGroupName.Enabled = False
                cmbMcGroupName.Text = vbNullString
                cmbMcGroupName.ListIndex = -1
                    
                '@装置ｺﾝﾎﾞ使用不可
                cmbWpID.Enabled = False
                cmbWpID.Text = vbNullString
                cmbWpID.ListIndex = -1
                    
                '@退避領域ｸﾘｱ
                mstrMcGroupName = vbNullString
                mstrWpID = vbNullString
                mstrWpName = vbNullString
                    
            '@工程異常処理票(装置)
            Else optAbnormal2.Checked = True
                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ使用可能
                cmbMcGroupName.Enabled = True                   
            End If
            
            '@ﾁｪｯｸ処理へ
            Call prvcmdRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optAbnormal_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroupName_Change
    '機　能：装置ｸﾞﾙｰﾌﾟ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/04 (Thu) 13:37:51 S.Deguchi
    '更新日：2005/08/04 (Thu) 13:37:51
    '備　考：
    Private Sub cmbMcGroupName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroupName.Change

        Try
            
            '@退避領域と異なる場合
            If mstrMcGroupName <> cmbMcGroupName.Text Then
                '@退避領域をｸﾘｱ
                mstrWpID = vbNullString
                mstrWpName = vbNullString
                
                '@装置ｺﾝﾎﾞをｸﾘｱ
                cmbWpID.Clear
                
                cmbWpID.Enabled = False
            
                '@ﾁｪｯｸ処理へ
                Call prvcmdRegist_Chk()
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroupName_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroupName_CloseUp
    '機　能：装置ｸﾞﾙｰﾌﾟCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/04 (Thu) 13:38:00 S.Deguchi
    '更新日：2005/08/04 (Thu) 13:38:00
    '備　考：
    Private Sub cmbMcGroupName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroupName.CloseUp

        Try
           
          '@cmbMcGroupNameのValidateｲﾍﾞﾝﾄ呼び出す
            If cmbMcGroupName.Text <> vbNullString Then
                RemoveHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_validate
                Call cmbMcGroupName_Validate(cmbMcGroupName,New CancelEventArgs(True))
                AddHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroupName_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroupName_Validate
    '機　能：装置ｸﾞﾙｰﾌﾟValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/04 (Thu) 13:38:03 S.Deguchi
    '更新日：2005/08/04 (Thu) 13:38:03
    '備　考：
    Private Sub cmbMcGroupName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMcGroupName.Validating

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrMcGroupID           As String               '退避装置ｸﾞﾙｰﾌﾟ

        Try
            
           'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@退避領域と異なる場合
            If mstrMcGroupName <> cmbMcGroupName.Text Then
                '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
                lstrFormName = Me.Name
                lstrEventName = "cmbMcGroupName_Validate"
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@装置ｸﾞﾙｰﾌﾟIDを内部変数へ退避
                With cmbMcGroupName
                    .ValueCol = CMlngCmbValueCol1
                    lstrMcGroupID = .Value
                End With
                
                '@MSG[ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置状態情報取得]を実行
                lblnAns = pubblnEqAreaCurList_Sel(CMstreq__areacurlistVer, _
                                                  vbNullString, _
                                                  pstrSBID, _
                                                  mtypWpList, _
                                                  mlngWpListCnt, _
                                                  CPstrCD20, _
                                                  lstrMcGroupID)
                '@結果判定
                If lblnAns = True Then
                '@成功の場合
                    '@退避領域へｾｯﾄ
                    mstrMcGroupName = cmbMcGroupName.Text
                    
                    '@装置Combo作成
                    Call prvcmbWpID_Disp(mtypWpList, mlngWpListCnt)
                
                    '@ﾁｪｯｸ処理へ
                    Call prvcmdRegist_Chk()
                Else
                '@失敗の場合
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    Exit Sub
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            End If
            
            '@ﾌｫｰｶｽｾｯﾄ
            'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが自身の場合
            If cmbMcGroupName.Name = ActiveControl.Name Then
                If cmbWpID.Enabled = True Then
                    '@装置へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbWpID)
                Else
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroupName_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpID_CloseUp
    '機　能：装置CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/04 (Thu) 16:14:38 S.Deguchi
    '更新日：2005/08/04 (Thu) 16:14:38
    '備　考：
    Private Sub cmbWpID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpID.CloseUp

        Try

          '@cmbWpIDのValidateｲﾍﾞﾝﾄ呼び出す
            If cmbWpID.Text <> vbNullString Then
                RemoveHandler cmbWpID.Validating,AddressOf cmbWpID_Validate
                Call cmbWpID_Validate(cmbWpID,New CancelEventArgs(True))
                AddHandler cmbWpID.Validating,AddressOf cmbWpID_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWpID_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpID_Validate
    '機　能：装置Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/04 (Thu) 14:50:21 S.Deguchi
    '更新日：2005/08/04 (Thu) 14:50:21
    '備　考：
    Private Sub cmbWpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWpID.Validating

        Try

           'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@Validate時に情報を退避
            With cmbWpID
                '@装置名退避
                .ValueCol = CMlngCmbValueCol0
                mstrWpName = .Value
                
                '@装置ID退避
                .ValueCol = CMlngCmbValueCol1
                mstrWpID = .Value
            End With
            
            '@ﾁｪｯｸ処理へ
            Call prvcmdRegist_Chk()
            
            '@ﾌｫｰｶｽｾｯﾄ
            If ActiveControl.Name = cmbWpID.Name Then 
                If cmdRegist.Enabled = True Then
                    '@確定へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdRegist)
                Else
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End if
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWpID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtAddLotID_Validate
    '機　能：ﾛｯﾄID追加Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/08 (Wed) 11:17:39 S.Deguchi
    '更新日：2004/09/08 (Wed) 11:17:39
    '備　考：
    '　　　：
    Private Sub txtAddLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtAddLotID.Validating

        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim lblnAns                 As Boolean              '戻り値
        Dim ltypLotList             As LocalLotList         'ﾛｯﾄ情報格納構造体

        Try

            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
            '@追加ﾛｯﾄID欄ﾁｪｯｸ
            If txtAddLotID.Text = vbNullString Then
            '@追加ﾛｯﾄID欄が空欄の場合
                '@ﾛｯﾄﾘｽﾄｸﾞﾘｯﾄﾞが非活性の場合
                If vsfLotList.Enabled = False Then
                   'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが自身の場合
                    If ActiveControl.Name = txtAddLotID.Name Then
                        '@処理選択にﾌｫｰｶｽｾｯﾄ
                        Select Case True
                            '@工程異常処理票(ﾛｯﾄ)
                            Case optAbnormal0.Checked
                                Call pubSetFocus(optAbnormal0)
                            '@不適合品処理票(ﾛｯﾄ)
                            Case optAbnormal1.Checked
                                Call pubSetFocus(optAbnormal1)
                            '@工程異常処理票(装置)
                            Case optAbnormal2.Checked
                                Call pubSetFocus(optAbnormal2)
                        End Select
                    End If
                Else
                 'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが自身の場合
                    If ActiveControl.Name = txtAddLotID.Name Then
                        '@ﾛｯﾄID登録欄へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfLotList)
                    End If
                End If

                Exit Sub
            Else
            '@追加ﾛｯﾄID欄が空欄ではない場合
                '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
                lstrFormName = Me.Name
                lstrEventName = "txtAddLotID_Validate"
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@桁ﾁｪｯｸ
                If txtAddLotID.NowByte <> cmlngMaxByte10 Then
                '@入力されたﾛｯﾄIDが10桁未満の場合
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                    sender.Focus()
                    '@"ロットIDは10桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@追加ﾛｯﾄIDにﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    
                    Exit Sub
                Else
                '@入力されたﾛｯﾄIDが10桁の場合
                    With vsfLotList
                        '@重複ﾁｪｯｸ
                        If vsfLotList.Rows.Count > 1 Then
                            For llngCnt = 1 To .Rows.Count - 1
                                '@同じIDがある場合
                                If .GetData(llngCnt, CMlngvsfColLotID) = txtAddLotID.Text Then
                                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                    Call pubResponseCancel(lstrFormName, lstrEventName)
                                    
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005E)
                                    
                                    '@"ロットIDが重複しています。設定を見直してください。"
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    
                                    '@追加ﾛｯﾄIDにﾌｫｰｶｽｾｯﾄ
                                    e.Cancel = True
                                    
                                    Exit Sub
                                End If
                            Next llngCnt
                        End If
                                       
                        '@ﾛｯﾄ状態取得
                        With ltypLotList
                            .strLotID = txtAddLotID.Text
                        End With
                        lblnAns = prvblnExcpLotCheck_Sel(ltypLotList)
                        '@結果判定
                        If lblnAns = False Then
                            '@失敗した場合には処理抜け
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)
                            
                            '@追加ﾛｯﾄIDにﾌｫｰｶｽｾｯﾄ
                            e.Cancel = True
                            
                            Exit Sub
                        Else
                            '@比較用ﾛｯﾄが空欄の場合には取得した情報をｾｯﾄ
                            If mtypLotList.strLotID = vbNullString Then
                                mtypLotList = ltypLotList
                            End If
                        End If
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(lstrFormName, lstrEventName)
                        
                        '@比較対象ﾛｯﾄと比較する
                        lblnAns = prvblnLotCFWFStatus_Chk(ltypLotList)
                        '@結果判定
                        If lblnAns = False Then
                        '@失敗の場合
                            Exit Sub
                        End If
                        
                        '@行を追加してﾃｷｽﾄの内容を反映させる
                        .Enabled = True                                                 '活性化
                        .AddItem(txtAddLotID.Text)                                      'ﾃｷｽﾄ内容反映
                        .Row = .Rows.Count - 1                                          '行設定
                        .Col = CMlngvsfColLotID                                         '列設定
                        .Rows(.Row).Height = CMlngVsfHeight                             '行高さ設定
                        Dim newStyle As CellStyle = .Styles.Add("vsfLotListCellStyle")
                        newStyle.TextAlign  = TextAlignEnum.LeftCenter                  '行内の文字表示位置設定
                        Dim cellRange As CellRange = .GetCellRange(.Row,.Col,.Row,.Col)
                        .Select(.Row, .Col)                                             '選択状態とする
                    
                        '@次頁処理▼
                        Call pubVsfCmdDown(vsfLotList, cmdUP, cmdDown, False)
                        
                        '@ﾃｷｽﾄの内容をｸﾘｱ
                        txtAddLotID.Text = vbNullString
                    
                        '@ｸﾞﾘｯﾄﾞへﾌｫｰｶｽをｾｯﾄ
                        If ActiveControl.Name = txtAddLotID.Name Then 
                            Call pubSetFocus(vsfLotList)
                        End if
                    End With
            
                    '@ﾁｪｯｸ処理へ
                    Call prvcmdRegist_Chk()
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtAddLotID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdDel_Click
    '機　能：ﾛｯﾄID削除
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/18 (Wed) 18:25:46 S.Deguchi
    '更新日：2008/01/08 (Tue) 16:18:51 N.Kojima
    '備　考：
    '　　　：2008/01/08 (Tue) 16:18:51 N.Kojima     ﾛｯﾄ削除時の上下ｽｸﾛｰﾙﾎﾞﾀﾝの制御追加。(案件№02499)
    Private Sub cmdDel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDel.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
            
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "cmdDel_Click"

            '@選択されている行を削除する
            With vsfLotList
                .redraw = false
                .RemoveItem (.Row)
                .redraw = True

                '@↓2008/01/08 (Tue) 16:18:46 N.Kojima **************************************************
                '@行が5行以下の場合
                If .Rows.Count - 1 <= CMlngvsfMaxDispRows Then
                    cmdUP.Enabled = False       '上ｽｸﾛｰﾙﾎﾞﾀﾝ
                    cmdDown.Enabled = False     '下ｽｸﾛｰﾙﾎﾞﾀﾝ
                End If
        '@↑2008/01/08 (Tue) 16:18:46 N.Kojima **************************************************

            End With
            
            '@ﾛｯﾄが1件以上存在する場合
            If vsfLotList.Rows.Count > 1 Then
                '@比較基準ﾛｯﾄの再取得
                
                '@ﾛｯﾄﾘｽﾄの1件目のWF/CF情報を取得する
                With mtypLotList
                    .strLotID = vsfLotList.GetData(1, CMlngvsfColLotID)
                    .strCFLotFlag = vbNullString
                    .strChipQuantity = vbNullString
                    .strWFQuantity = vbNullString
                    .strPdId = vbNullString
                End With
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@ﾛｯﾄ情報取得
                lblnAns = prvblnExcpLotCheck_Sel(mtypLotList)
                '@結果判定
                If lblnAns = True Then
                '@成功の場合
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                Else
                '@失敗の場合
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                End If
            Else
                '@比較基準ﾛｯﾄ構造体の初期化
                With mtypLotList
                    .strLotID = vbNullString
                    .strCFLotFlag = vbNullString
                    .strChipQuantity = vbNullString
                    .strWFQuantity = vbNullString
                    .strPdId = vbNullString
                End With
            End If
            
            '@ﾁｪｯｸ処理へ
            Call prvcmdRegist_Chk()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：前頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 19:12:04 S.Deguchi
    '更新日：2004/09/07 (Tue)
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
            

            '@前頁処理▲
            Call pubVsfCmdUp(vsfLotList, cmdUP, cmdDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：次頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 19:12:04 S.Deguchi
    '更新日：2004/09/07 (Tue)
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
            

            '@次頁処理▼
            Call pubVsfCmdDown(vsfLotList, cmdUP, cmdDown, False)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_EnterCell
    '機　能：ｸﾞﾘｯﾄﾞｸﾘｯｸ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 08:42:15 S.Deguchi
    '更新日：2004/08/19 (Thu) 08:42:15
    '備　考：
    Private Sub vsfLotList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.EnterCell
        
        Try
            
            
            '@選択行がﾀｲﾄﾙ以外の場合
            With vsfLotList
                If .Row > 0 Then
                    '@削除ﾎﾞﾀﾝを活性化
                    cmdDel.Enabled = True
                Else
                    '@削除ﾎﾞﾀﾝを非活性化
                    cmdDel.Enabled = False
                End If
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_EnterCell"
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

    '関数名：prvfrmxxCM00I0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/11 (Wed) 11:24:37 S.Deguchi
    '更新日：2004/10/04 (Mon) 11:08:27 H.Wajima
    '備　考：
    Private Sub prvfrmxxCM00I0_Init()

        Dim lstrFormTitle           As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00U0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@退避領域を初期化
            mstrEmpID = vbNullString                                '発見者ID
            mstrFindDate = vbNullString                             '発見日時
            mstrDeptID = vbNullString                               '発見職場ID
            mstrDeptName = vbNullString                             '発見職場名
            
            mstrMcGroupName = vbNullString                          '装置ｸﾞﾙｰﾌﾟ退避領域
            mstrWpID = vbNullString                                 '装置ID退避領域
            mstrWpName = vbNullString                               '装置名退避領域
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ設定
            optAbnormal0.Checked = True                             '工程異常・Lo(初期値設定=True)
            optAbnormal1.Checked = False                            '不適合品・Lot(初期値設定=False)
            optAbnormal2.Checked = False                            '工程異常・WP(初期値設定=False)
            
            '@ﾃｷｽﾄﾎﾞｯｸｽ設定
            txtAddLotID.Text = vbNullString                         '追加ﾛｯﾄID
            
            '@ﾛｯﾄﾘｽﾄの初期化
            Call prvvsfLotList_Init()
            
            '@削除ﾎﾞﾀﾝの非活性化
            cmdDel.Enabled = False
                
            '@ｽｸﾛｰﾙﾎﾞﾀﾝの非活性化
            cmdUP.Enabled = False
            cmdDown.Enabled = False
            
            '@「装置ｸﾞﾙｰﾌﾟ」の非活性化
            cmbMcGroupName.Enabled = False
            
            '@「装置」の非活性化
            cmbWpID.Enabled = False
            
            '@「確定」ﾎﾞﾀﾝの非活性化
            cmdRegist.Enabled = False

            '@「閉じる」ﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00I0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvvsfLotList_Init
    '機　能：ﾛｯﾄﾘｽﾄの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/17 (Tue) 16:36:04 S.Deguchi
    '更新日：2004/08/17 (Tue) 16:36:04
    '備　考：
    Private Sub prvvsfLotList_Init()

        Try

            With vsfLotList
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)

                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化(ｿｰﾄなし)
                .AllowSorting = AllowSortingEnum.None

                '@初期行数設定
                .Rows.Count = .Rows.Fixed

                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '@ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Row

                '@ﾌｫﾝﾄｻｲｽﾞ指定(=11)
                .Font = New Font(.Font.Name, CMlngvsfFontSize)

                '@一覧表の表題設定
                Dim headerSellRange As CellRange = .GetCellRange(CMlngvsfRowTitle, CMlngvsfColLotID, CMlngvsfRowTitle, .Cols.Count - 1)
                Dim headerStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                            '文字色
                headerStyle.BackColor = Color.Navy                                                              '背景色
                headerStyle.Font = New Font(.Font.Name, CMlngvsfHFontSize)                                      'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerSellRange.Style = headerStyle

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfColLotID, CMstrvsfColLotID)                                  'ﾛｯﾄID

                '@列幅設定
                .Cols(CMlngvsfColLotID).Width = CMlngvsfWColLotID                                               'ﾛｯﾄID

                '@表示位置の設定
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                              'ﾀｲﾄﾙ(中央寄せ中央揃え)

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngvsfHHeight                                                '高さ

                '@ﾛｯｸ
                .Enabled = False

                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.None
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvfrmxxCM00I0_Set
    '機　能：ｷｬﾘｱ(ﾛｯﾄ)ID引継起動時の情報ｾｯﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/03 (Thu) 10:35:04 S.Deguchi
    '更新日：2005/03/03 (Thu) 10:35:04
    '備　考：
    Private Sub prvfrmxxCM00I0_Set()

        Dim llngLoopCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            '@装置別ﾛｯﾄ一覧から情報を引継いできた場合
            '@引継ぎ情報のﾛｯﾄIDが空白かどうか判定する
            If ptypCommonInfo.strLotId <> vbNullString Then
                '@空白でない場合には一覧へ追加
                With vsfLotList
                    .Rows.Count = CMlngDefault2
                    .SetData(CMlngDefault1, CMlngvsfColLotID, ptypCommonInfo.strLotId)
                    
                    '@ｽﾛｯﾄの高さの設定
                    .Rows(CMlngDefault1).Height = CMlngvsfHeight
                    .Rows.DefaultSize = CMlngvsfHeight
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                End With
            Else
                '@ﾛｯﾄ作業終了/ﾊﾞｯﾁ作業終了から情報を引継いできた場合
                If ptypExcpConnectList.typLotList.lngBatLotListCnt > 0 Then
                    '@引継ぎ情報が存在する場合にはｸﾞﾘｯﾄﾞにｾｯﾄ
                    With vsfLotList
                        '@ｸﾞﾘｯﾄﾞの最大Rowをｾｯﾄ
                        .Rows.Count = ptypExcpConnectList.typLotList.lngBatLotListCnt + 1
                        
                        '@ｸﾞﾘｯﾄﾞにﾛｯﾄIDをｾｯﾄ
                        For llngLoopCnt = 0 To ptypExcpConnectList.typLotList.lngBatLotListCnt -1
                            .SetData(llngLoopCnt+1, CMlngvsfColLotID, _
                                ptypExcpConnectList.typLotList.typBatList(llngLoopCnt).strLotId)
                            
                            '@ｽﾛｯﾄの高さの設定
                            .Rows(llngLoopCnt+1).Height = CMlngvsfHeight
            
                        Next llngLoopCnt

                        .Rows.DefaultSize = CMlngvsfHeight
                        
                        '@ﾛｯｸ解除
                        .Enabled = True
                    End With
                End If
            End If

            '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御
            If vsfLotList.Rows.Count > 1 Then
                '@ｵｰﾀﾞｰ一覧ｽｸﾛｰﾙﾎﾞﾀﾝの設定
                vsfLotList.Select(CMlngVsfRowTitle, CMlngvsfColTitle)

                '@ｿｰﾄ前処理
                Call pubVsfBeforeSort(vsfLotList, CMlngvsfColLotID)

                '@ｿｰﾄ後処理
                Call pubVsfAfterSort(vsfLotList, CMlngvsfColLotID, cmdUP, cmdDown, False)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00I0_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM00I0_Chk
    '機　能：ｷｬﾘｱ(ﾛｯﾄ)ID引継起動時の情報ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/03 (Thu) 13:19:33 S.Deguchi
    '更新日：2005/03/03 (Thu) 13:19:33
    '備　考：
    Private Sub prvfrmxxCM00I0_Chk()

        Dim lstrLotID               As String       '退避ﾛｯﾄID
        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾄ
        Dim lblnRet                 As Boolean      '結果格納
        
        Try
            
            '@初期化
            lblnRet = False
            
            '@引継構造体の情報が起案ﾛｯﾄに存在するかﾁｪｯｸする
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@引継いだﾛｯﾄIDを退避
                lstrLotID = ptypCommonInfo.strLotID
                
                '@ｸﾞﾘｯﾄﾞの一覧の内容から存在するか否かを判別する
                With vsfLotList
                    If .Rows.Count > 1 Then
                        For llngCnt = 1 To .Rows.Count - 1
                            If .GetData(llngCnt, CMlngvsfColLotID) = lstrLotID Then
                                '@存在している場合そのまま
                                lblnRet = True
                                
                                Exit For
                            End If
                        Next llngCnt
                        
                        '@結果判別
                        If lblnRet <> True Then
                            '@引継構造体を初期化
                            ptypCommonInfo.strCarrierId = CMstrDefault0
                        End If
                    Else
                    '@ﾀｲﾄﾙ以外ない場合
                        '@引継構造体を初期化
                        ptypCommonInfo.strCarrierId = CMstrDefault0
                    End If
                End With
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00I0_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvcmbMcGroupList_Disp
    '機　能：装置ｸﾞﾙｰﾌﾟ情報Combo作成
    '引　数：mtypAreaList()：ｴﾘｱ情報格納構造体
    '戻り値：なし
    '作成日：2005/08/04 (Thu) 13:36:55 S.Deguchi
    '更新日：2005/08/04 (Thu) 13:36:55
    '備　考：
    Private Sub prvcmbMcGroupList_Disp(ByRef ltypMcGroupList As McGroupList)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbMcGroupName
                '@装置ｸﾞﾙｰﾌﾟ情報初期化
                .Enabled = True
                .Clear
                .DirectInput = False                                            '直接入力不可
                .Height = CMlngCmbRowHeight                                     '高さ
                .RowHeight = CMlngCmbRowHeight                                  '高さ(行)
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .Font = New Font(.Font.Name,CMlngCmbFontSize)                   'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.Name,CMlngCmbGridFontSize)           'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                
                '@装置ｸﾞﾙｰﾌﾟ情報ｾｯﾄ
                 For llngCnt = 0 To ltypMcGroupList.lngMcGroupListCnt -1
                    .AddItem(ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupName & _
                             vbTab & _
                             ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupID)
                Next llngCnt
                    
                '@装置ｸﾞﾙｰﾌﾟが1件の場合、ﾃﾞﾌｫﾙﾄ表示
                If .ListCount = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbMcGroupList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbWpID_Disp
    '機　能：装置情報Combo作成
    '引　数：mtypWpList()：装置情報格納構造体
    '　　　：mlngWpListCnt：装置情報格納ｶｳﾝﾄ数
    '戻り値：なし
    '作成日：2005/08/04 (Thu) 14:46:35 S.Deguchi
    '更新日：2005/08/04 (Thu) 14:46:35
    '備　考：
    Private Sub prvcmbWpID_Disp(ByRef mtypWpList As List(of AreaEquipmentList), _
                                ByVal mlngWpListCnt As Integer)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbWpID
                '@装置名情報初期化
                .Enabled = True
                .Clear
                .DirectInput = False                                            '直接入力不可
                .Height = CMlngCmbRowHeight                                     '高さ
                .RowHeight = CMlngCmbRowHeight                                  '高さ(行)
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .Font = New Font(.Font.Name,CMlngCmbFontSize)                   'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.Name,CMlngCmbGridFontSize)           'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                
                '@装置名情報ｾｯﾄ
                For llngCnt = 0 To mlngWpListCnt -1
                    .AddItem(mtypWpList(llngCnt).strWpName & _
                             vbTab & _
                             mtypWpList(llngCnt).strWpID)
                Next llngCnt
                
                '@装置が1件の場合、ﾃﾞﾌｫﾙﾄ表示
                If .ListCount = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
            
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbWpID_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdRegist_Chk
    '機　能：確定ﾎﾞﾀﾝﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 08:44:23 S.Deguchi
    '更新日：2004/08/19 (Thu) 08:44:23
    '備　考：
    Private Sub prvcmdRegist_Chk()

        Try

            '@処理選択の状態から判別
            Select Case True
                '@工程異常処理票(ﾛｯﾄ)/不適合品処理票(ﾛｯﾄ)
                Case optAbnormal0.Checked, optAbnormal1.Checked
                    If vsfLotList.Rows.Count > 1 Then
                    '@一覧が0件以上の場合には確定ﾎﾞﾀﾝ活性化
                        cmdRegist.Enabled = True
                    Else
                    '@一覧が0件の場合には確定ﾎﾞﾀﾝ非活性化
                        cmdRegist.Enabled = False
                    End If
                    
                '@工程異常処理票(装置)
                Case optAbnormal2.Checked
                    If cmbMcGroupName.Text <> vbNullString And _
                       cmbWpID.Text <> vbNullString Then
                    '@装置ｸﾞﾙｰﾌﾟ/装置が選択されている場合には確定ﾎﾞﾀﾝ活性化
                        cmdRegist.Enabled = True
                    Else
                    '@装置ｸﾞﾙｰﾌﾟ/装置が選択されていない場合には確定ﾎﾞﾀﾝ非活性化
                        cmdRegist.Enabled = False
                    End If
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvblnExcpReport_Chk
    '機　能：工程異常/不適合品処理票登録情報ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：成功/False：失敗
    '作成日：2005/08/04 (Thu) 16:26:12 S.Deguchi
    '更新日：2005/08/04 (Thu) 16:26:12
    '備　考：
    Private Function prvblnExcpReport_Chk() As Boolean

        Dim lblnAns                 As Boolean              '汎用戻り値
        Dim lblnRet                 As Boolean              '汎用戻り値
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim ltypLotList             As LocalLotList         'ﾛｯﾄ情報取得構造体

        Try
            
            '@初期化
            prvblnExcpReport_Chk = False
            
            '@処理選択の状態から判別
            Select Case True
                '@工程異常処理票(ﾛｯﾄ)/不適合品処理票(ﾛｯﾄ)
                Case optAbnormal0.Checked, optAbnormal1.Checked
                    '@一覧が0件の場合には処理中断
                    If vsfLotList.Rows.Count < 1 Then
                        Exit Function
                    End If
                    
                '@工程異常処理票(装置)
                Case optAbnormal2.Checked
                    If cmbMcGroupName.Text <> vbNullString And _
                       cmbWpID.Text <> vbNullString Then
                    
                    Else
                    '@装置ｸﾞﾙｰﾌﾟ/装置が選択されていない場合には処理中断
                        Exit Function
                    End If
            End Select

            With vsfLotList
                '@初期化
                If mtypExcpLotList.typLotList IsNot Nothing Then
                    mtypExcpLotList.typLotList.Clear()
                    mtypExcpLotList.typLotList = Nothing
                End If
                mtypExcpLotList.lngLocalLotListCnt = 0
                
                '@ﾛｯﾄが存在するか否かで処理分岐
                If .Rows.Count > 1 Then
                '@構成しているﾛｯﾄの情報がWF/CFの統一がされているかﾁｪｯｸ&構造体へ必要情報を格納
                For llngCnt = 1 To .Rows.Count - 1
                    '@情報取得の初期化
                    ltypLotList.strLotID = .GetData(llngCnt, CMlngvsfColLotID)
                    ltypLotList.strCFLotFlag = vbNullString
                    ltypLotList.strWFQuantity = vbNullString
                    ltypLotList.strChipQuantity = vbNullString
                    ltypLotList.strPdId = vbNullString
                    ltypLotList.strOpID = vbNullString
                    ltypLotList.strStepID = vbNullString
                    ltypLotList.strWpID = vbNullString
                    ltypLotList.strWpName = vbNullString
                    
                    '@ﾛｯﾄ情報取得
                    lblnAns = prvblnExcpLotCheck_Sel(ltypLotList)
                    '@結果判定
                    If lblnAns = True Then
                    '@成功の場合
                        '@取得情報のﾁｪｯｸ
                        lblnRet = prvblnLotCFWFStatus_Chk(ltypLotList)
                        '@結果判定
                        If lblnRet = False Then
                        '@失敗の場合
                            Exit Function
                        End If
                    Else
                    '@失敗の場合
                        Exit Function
                    End If
                        
                    '@登録構造体へ情報をｾｯﾄ
                    '@領域確保
                   If mtypExcpLotList.typLotList Is Nothing Then
                        mtypExcpLotList.typLotList = New List(Of LocalLotList)
                    End If

                    Dim typLotListTmp As LocalLotList = New LocalLotList
                    '@情報をｾｯﾄ
                    With typLotListTmp
                        .strLotID = ltypLotList.strLotID                    'ﾛｯﾄID
                        .strWFQuantity = ltypLotList.strWFQuantity          'WF良品数
                        .strChipQuantity = ltypLotList.strChipQuantity      'ﾁｯﾌﾟ良品数
                        .strCFLotFlag = ltypLotList.strCFLotFlag            'CFﾛｯﾄﾌﾗｸﾞ
                        .strPdId = ltypLotList.strPdId                      '機種
                        .strOpID = ltypLotList.strOpID                      '大工程
                        .strStepID = ltypLotList.strStepID                  '小工程
                        .strWpID = ltypLotList.strWpID                      '装置ID
                        .strWpName = ltypLotList.strWpName                  '装置名
                    End With
                    mtypExcpLotList.typLotList.Add(typLotListTmp)
                    '@ｶｳﾝﾄｱｯﾌﾟ
                    mtypExcpLotList.lngLocalLotListCnt = mtypExcpLotList.lngLocalLotListCnt + 1
                Next llngCnt
                End If
            End With

            '@成功を返す
            prvblnExcpReport_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnExcpReport_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnExcpLotCheck_Sel
    '機　能：ﾛｯﾄ情報取得
    '引　数：ltypLotList：ﾛｯﾄ情報取得構造体
    '戻り値：True：成功/False：失敗
    '作成日：2005/08/04 (Thu) 17:02:56 S.Deguchi
    '更新日：2005/08/04 (Thu) 17:02:56
    '備　考：
    Private Function prvblnExcpLotCheck_Sel(ByRef ltypLotList As LocalLotList) As Boolean

        Dim lblnAns                 As Boolean              '汎用戻り値
        Dim ltypExcpLotCheckReq     As ExcpCheckLotReq      '要求構造体
        Dim ltypExcpLotCheckAns     As ExcpCheckLotAns      '応答構造体

        Try
            
            '@初期化
            prvblnExcpLotCheck_Sel = False
            
            '@要求構造体へ情報をｾｯﾄ
            With ltypExcpLotCheckReq
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrexcplotcheckVer           'Msgﾊﾞｰｼﾞｮﾝ
                .strLotID = ltypLotList.strLotID            'ﾛｯﾄID
            End With
            
            '@情報取得
            lblnAns = pubblnExcpLotCheck_Sel(ltypExcpLotCheckReq, _
                                             ltypExcpLotCheckAns)
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
                '@応答構造体の内容をﾛｰｶﾙ変数へ退避
                With ltypLotList
                    .strCFLotFlag = ltypExcpLotCheckAns.strCFLotFlag            'CFﾛｯﾄﾌﾗｸﾞ
                    .strWFQuantity = ltypExcpLotCheckAns.strWfNum               'WF良品数
                    .strChipQuantity = ltypExcpLotCheckAns.strChipNum           'ﾁｯﾌﾟ良品数
                    .strPdId = ltypExcpLotCheckAns.strPdId                      '機種
                    .strOpID = ltypExcpLotCheckAns.strOpID                      '大工程
                    .strStepID = ltypExcpLotCheckAns.strStepID                  '小工程
                    .strWpID = ltypExcpLotCheckAns.strWpID                      '装置ID
                    .strWpName = ltypExcpLotCheckAns.strWpName                  '装置名
                End With
            Else
            '@失敗の場合
                Exit Function
            End If
            
            '@成功を返す
            prvblnExcpLotCheck_Sel = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnExcpLotCheck_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnLotCFWFStatus_Chk
    '機　能：比較対象ﾛｯﾄと比較する
    '引　数：ltypLotList：ﾛｯﾄ情報構造体
    '戻り値：True：OK/False：NG
    '作成日：2005/08/04 (Thu) 17:43:02 S.Deguchi
    '更新日：2005/08/04 (Thu) 17:43:02
    '備　考：
    Private Function prvblnLotCFWFStatus_Chk(ByRef ltypLotList As LocalLotList) As Boolean
        
        Try

            '@初期化
            prvblnLotCFWFStatus_Chk = False
            
            '@比較対象ﾛｯﾄと比較
            If mtypLotList.strCFLotFlag <> ltypLotList.strCFLotFlag Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006K)
                
                '@"基板ロットとCFロットを混在して登録することはできません。$設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Function
            End If
            
            '@成功を返す
            prvblnLotCFWFStatus_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotCFWFStatus_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnExcpChgReport_Ins
    '機　能：工程異常/不適合品処理票登録処理
    '引　数：lstrExcpNo：異常処理№
    '戻り値：True：成功/False：失敗
    '作成日：2005/08/05 (Fri) 13:04:23 S.Deguchi
    '更新日：2005/08/05 (Fri) 13:04:23
    '備　考：
    Private Function prvblnExcpChgReport_Ins(ByRef lstrExcpNo As String) As Boolean

        Dim lblnAns                 As Boolean              '汎用戻り値
        Dim ltypExcpReport          As ExcpReport           '工程異常不適合品処理票登録構造体
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim llngTarget              As Integer              '登録対象ｶｳﾝﾄ
        Dim llngTempQuantity        As Integer              '対象数量計算値格納

        Try

            '@初期化
            prvblnExcpChgReport_Ins = False
            
            '@登録情報を構造体へ格納
            With ltypExcpReport
                .strSbID = pstrSBID                     'SBID
                .strMsgVer = CMstrexcpchgreportVer      'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strExcpNo = vbNullString               '異常処理№
                .strFindDate = mstrFindDate             '発見日時
                .strEntryTime = mstrFindDate            '登録日時
                .strFindDeptID = mstrDeptID             '発見職場ID
                .strFindDeptName = mstrDeptName         '発見職場名
                .strFindEmpID = mstrEmpID               '発見者ID
                .strFindEmpName = mstrEmpName           '発見者名
                .strEmpID = mstrEmpID                   '更新者ID
                .strEmpName = mstrEmpName               '更新者名
                .strHoldFlag = CMstrDefault1            '保留ﾌﾗｸﾞ(1:保留有り)
                
                '@帳票種別/不適合品発生有無ﾌﾗｸﾞの設定
                Select Case True
                    Case optAbnormal0.Checked, optAbnormal2.Checked
                    '@工程異常処理票(ﾛｯﾄ/装置)
                        .strDocClass = CMstrTroubleFlag
                        .strIncongFlag = CMstrTroubleFlag
                    
                    Case optAbnormal1.Checked
                    '@不適合品処理票
                        .strDocClass = CMstrIncongFlag
                        .strIncongFlag = CMstrIncongFlag
                End Select
                
                '@ﾛｯﾄの件数を設定
                .lngExcpReportLotListCnt = mtypExcpLotList.lngLocalLotListCnt
                '@発見情報の設定
                If mtypExcpLotList.lngLocalLotListCnt > 0 Then
                    '@1件目の情報をｾｯﾄ
                    llngTarget = 0
                    
                    .strFindOpID = mtypExcpLotList.typLotList(llngTarget).strOpID           '大工程
                    .strFindStepID = mtypExcpLotList.typLotList(llngTarget).strStepID       '小工程
                    .strFindWpID = mtypExcpLotList.typLotList(llngTarget).strWpId           '装置ID
                    .strFindWpName = mtypExcpLotList.typLotList(llngTarget).strWpName       '装置名
                    .strTargetPDID = mtypExcpLotList.typLotList(llngTarget).strPdId         '機種
                    
                    '@ﾘｽﾄに対しての処理
                    llngTempQuantity = 0
                    '@CFﾌﾗｸﾞが"0"：WFの場合か否かで処理分岐
                    If mtypExcpLotList.typLotList(llngTarget).strCFLotFlag = CMstrCFFlag_WF Then
                        '@対象合計数の計算
                        For llngCnt = 0 To mtypExcpLotList.lngLocalLotListCnt -1
                            llngTempQuantity = llngTempQuantity + CLng(mtypExcpLotList.typLotList(llngCnt).strWFQuantity)
                        Next llngCnt
                        .strTargetQuantity = llngTempQuantity                               '合計WF数
                        .strTargetUnit = CMstrUnitWF                                        'WF
                    Else
                        '@対象合計数の計算
                        For llngCnt = 0 To mtypExcpLotList.lngLocalLotListCnt -1
                            llngTempQuantity = llngTempQuantity + CLng(mtypExcpLotList.typLotList(llngCnt).strChipQuantity)
                        Next llngCnt
                        .strTargetQuantity = llngTempQuantity                               '合計Chip数
                        .strTargetUnit = CMstrUnitChip                                      'Chip
                    End If
                    
                    '@ﾛｯﾄﾘｽﾄ作成
                    '@領域確保
                    If .typExcpLotList Is Nothing Then
                        .typExcpLotList = New List(Of ExcpLot)
                    End If

                    Do While (.typExcpLotList.Count - 1 < mtypExcpLotList.lngLocalLotListCnt)
                        .typExcpLotList.Add(New ExcpLot)
                    Loop

                    Dim typExcpLotListTmp As ExcpLot = New ExcpLot

                    For llngCnt = 0 To mtypExcpLotList.lngLocalLotListCnt -1
                        typExcpLotListTmp.strLotId = mtypExcpLotList.typLotList(llngCnt).strLotId            'ﾛｯﾄID
                        '@ﾛｯﾄを構成するWF/CFの枚数をｾｯﾄ
                        If mtypExcpLotList.typLotList(llngCnt).strCFLotFlag = CMstrCFFlag_WF Then
                        '@WFの場合
                            typExcpLotListTmp.strTotalQuantity = mtypExcpLotList.typLotList(llngCnt).strWFQuantity
                        Else
                        '@CFの場合
                            typExcpLotListTmp.strTotalQuantity = mtypExcpLotList.typLotList(llngCnt).strChipQuantity
                        End If
                        
                        '@初期設定：全て"0"
                        typExcpLotListTmp.strReserveQuantity = "0"                   '保留
                        typExcpLotListTmp.strAbandonQuantity = "0"                   '廃却
                        typExcpLotListTmp.strAmendQuantity = "0"                     '手直し
                        typExcpLotListTmp.strCorrectQuantity = "0"                   '修正
                        typExcpLotListTmp.strUsualQuantity = "0"                     '通常
                        typExcpLotListTmp.strEvalQuantity = "0"                      '評価
                        typExcpLotListTmp.strTakeQuantity = "0"                      '特採
                        typExcpLotListTmp.strTargetQuantity = "0"                    '対象数量
                        
                        '@処置ﾌﾗｸﾞ："0"⇒未処置
                        typExcpLotListTmp.strDisposalFlag = CMstrDispose
                        .typExcpLotList(llngCnt) = typExcpLotListTmp
                    Next llngCnt

                Else
                    .strFindOpID = vbNullString                                      '大工程
                    .strFindStepID = vbNullString                                    '小工程
                    .strFindWpID = mstrWpID                                          '装置ID
                    .strFindWpName = mstrWpName                                      '装置名
                    .strTargetPDID = vbNullString                                    '機種
                    .strTargetQuantity = "0"                                         '数量
                    .strTargetUnit = CMstrUnitWF                                     '単位：WF(初期設定)
                End If
                '@その他ﾌﾗｸﾞ設定：初期値"0"
                .strInflFlag = "0"                                                   '後工程/信頼性影響
                .strApprovalFlag = "0"                                               '適用ﾌﾗｸﾞ(=0：未適用)
                .strAllDisposalFlag = "0"                                            '全処置ﾌﾗｸﾞ(=0：未処置)
                .strDispoScrapFlag = "0"                                             '廃却
                .strDispoMdifyFlag = "0"                                             '手直し
                .strDispoPickFlag = "0"                                              '特採
                .strDispoRegularFlag = "0"                                           '通常
                .strDispoAmendFlag = "0"                                             '修正
                .strDispoRatingFlag = "0"                                            '評価
                .strImproKind = "0"                                                  '改善取組
                '@##########その他ｾｯﾄしていない変数はNull##########
            End With
            
            '@工程異常/不適合品処理票登録
            lblnAns = pubblnExcpChgReport_Upd(ltypExcpReport, lstrGuidMsg, lstrGuidMsgCode)
            '@結果判定
            If lblnAns = True Then
                '@異常処理№を退避
                lstrExcpNo = ltypExcpReport.strExcpNo
            Else
                Exit Function
            End If
            
            '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っている場合
            If lstrGuidMsgCode <> vbNullString Then
                '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                   CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                   CPstrMsgCrCode & lstrGuidMsg
                
                '@ﾒｯｾｰｼﾞ表示"編集済みｶﾞｲﾀﾞﾝｽMsg"
                pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                '@ﾒｯｾｰｼﾞ表示
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            End If
            
            '@登録完了ﾒｯｾｰｼﾞを表示する
            If optAbnormal1.Checked = True Then
            '@不適合品処理票の場合
                '@表示ﾒｯｾｰｼﾞ変換：<TRM1UI>$$不適合品処理票を登録しました。異常処理№[%1]
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001U, lstrExcpNo)
            Else
            '@工程異常処理票の場合
                '@表示ﾒｯｾｰｼﾞ変換：<TRM1GI>$$工程異常処理票を登録しました。異常処理№[%1]
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001G, lstrExcpNo)
            End If
            
            '@成功ﾒｯｾｰｼﾞ表示
            Call pubVsfInfo_Disp(pstrDMsg)
            
            '@成功を返す
            prvblnExcpChgReport_Ins = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnExcpChgReport_Ins"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraLot.Paint, fraSelect.Paint, fraWp.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfLotList.BeforeDoubleClick

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

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles txtAddLotID.Enter, _
                                                                       vsfLotList.Enter,
                                                                       cmdUP.Enter,
                                                                       cmdDown.Enter,
                                                                       cmdDel.Enter,
                                                                       cmbMcGroupName.Enter,
                                                                       cmbWpID.Enter,
                                                                       cmdClose.Enter,
                                                                       cmdRegist.Enter,
                                                                       optAbnormal0.Enter,
                                                                       optAbnormal1.Enter,
                                                                       optAbnormal2.Enter
                                                                       

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select
    End Sub

    '関数名：pubVsfCmdDown
    '機　能：ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）
    '引　数：lobjCmdUp：前頁ﾎﾞﾀﾝ
    '　　　：lobjCmdDown：次頁ﾎﾞﾀﾝ
    '　　　：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    '戻り値：なし
    '作成日：2004/04/01 (Thu) 15:59:43 M.Miura
    '更新日：2004/04/01 (Thu) 15:59:43
    '備　考：ｸﾞﾘｯﾄﾞ次頁ﾎﾞﾀﾝの Click ｲﾍﾞﾝﾄで使用
    Private Sub prvVsfCmdDown00I0(ByVal lobjvsfGrid As C1.Win.C1FlexGrid.C1FlexGrid, Optional ByVal lobjcmdUp As Button = Nothing,
                         	 Optional ByVal lobjcmdDown As Button = Nothing, Optional ByVal lblnLastSpace As Boolean = True)
        Dim llngRow 		As Integer     '行
        Dim llngRows 		As Integer     '１頁行数
        Dim llngCnt 		As Integer     'ｶｳﾝﾄ
        Dim CMstrNothing 	As String = "Nothing"   'Nothing
        With CType(lobjvsfGrid,C1FlexGrid)

            'NSYS データ行がない場合、 .TopRow = -1 となるため処理を除外する
            If (.Rows.Fixed + .Rows.Frozen) >= .Rows.Count Then
                '@頁切替ﾎﾞﾀﾝがある場合
                If TypeName(lobjcmdUp) <> CMstrNothing Then
                    '@ﾛｯｸ
                    lobjcmdUp.Enabled = False
                End If
                If TypeName(lobjcmdDown) <> CMstrNothing Then
                    '@ﾛｯｸ
                    lobjcmdDown.Enabled = False
                End If
                Exit Sub
            End If

            '@ｸﾞﾘｯﾄﾞの１頁の行数を取得
            llngRows = publngVsfPageRows_Get(lobjvsfGrid)

            '@一覧最終頁の場合
            If .TopRow + llngRows >= .Rows.Count Then
                '@頁切替ﾎﾞﾀﾝがない場合
                If TypeName(lobjcmdDown) <> CMstrNothing Then
                    '@ﾛｯｸ
                    lobjcmdDown.Enabled = False
                End If

                Exit Sub
            End If

            '@一覧最上段にﾌｫｰｶｽ
            llngRow = .TopRow + (llngRows)

            If llngRow + llngRows >= .Rows.Count Then
                '@頁切替ﾎﾞﾀﾝがある場合
                If TypeName(lobjcmdDown) <> CMstrNothing Then
                    '@ﾛｯｸ
                    lobjcmdDown.Enabled = False
                End If
            Else
                '@頁切替ﾎﾞﾀﾝがある場合
                If TypeName(lobjcmdDown) <> CMstrNothing Then
                    '@ﾛｯｸ解除
                    lobjcmdDown.Enabled = True
                End If
            End If

            '@頁切替ﾎﾞﾀﾝがある場合
            If TypeName(lobjcmdDown) <> CMstrNothing Then
                If lblnLastSpace = True Then
                    '@非表示
                    For llngCnt = .Rows.Fixed To llngRow - 1
                        .Rows(llngCnt).Visible = False
                    Next llngCnt
                    .TopRow = llngRow
                Else
                    .TopRow = llngRow
                End If
            Else
                .TopRow = llngRow
            End If

            '@頁切替ﾎﾞﾀﾝがある場合
            If TypeName(lobjcmdUp) <> CMstrNothing Then
                If .Rows.Fixed >= .Rows.Count Then
                    '@ﾛｯｸ
                    lobjcmdUp.Enabled = False
                Else
                    '@頁先頭行が先頭行の場合
                    If .Rows(.Rows.Fixed).Visible = False Then
                        '@ﾛｯｸ解除
                        lobjcmdUp.Enabled = True
                    Else
                        If .TopRow = .Rows.Fixed Then
                            '@ﾛｯｸ
                            lobjcmdUp.Enabled = False
                        Else
                            '@ﾛｯｸ解除
                            lobjcmdUp.Enabled = True
                        End If
                    End If
                End If
            End If


            '@先頭行格納
            Call pubblnVsfTag_Set(lobjvsfGrid, 1, .TopRow)

        End With

    End Sub

   

End Class
