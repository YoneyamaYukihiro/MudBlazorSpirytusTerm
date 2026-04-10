'ﾌｧｲﾙ名：xxCM00Y0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：使用部材選択画面
'作成日：2006/06/27 (Tue) 10:03:10 N.Kojima
'更新日：2010/06/21 (Mon) 10:12:39 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00Y0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00Y0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00Y0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00Y0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00Y0)
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
    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM00Y0          'ﾛｰｶﾙﾒﾆｭｰKey

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmat_materiallistVer          As String = "02.01"                 '装置部材情報取得

    '@ｸﾞﾘｯﾄﾞ共通
    Private Const CMlngVsfHFontSize                 As Integer = 12                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                   As Integer = 27                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfUseMaterialListHeight     As Integer = 43                     '1ｽﾛｯﾄの高さ(使用部材ﾘｽﾄ)
    Private Const CMlngvsfRestrictPdHeight          As Integer = 18                     '1ｽﾛｯﾄの高さ(機種ﾘｽﾄ)
    Private Const CMlngvsfFixedRow                  As Integer = 0                      'ﾀｲﾄﾙ行
    Private Const CMlngvsfFixedRows                 As Integer = 1                      'ﾀｲﾄﾙ行数
    Private Const CMlngvsfAllRow                    As Integer = -1                     '全行指定
    Private Const CMlngvsfColS                      As Integer = 8                      '列数
    Private Const CMlngvsfUseMaterialListFontSize   As Integer = 16                     'ﾌｫﾝﾄｻｲｽﾞ(使用部材ﾘｽﾄ)
    Private Const CMlngvsfRestrictPdFontSize        As Integer = 11                     'ﾌｫﾝﾄｻｲｽﾞ(機種ﾘｽﾄ)
    Private Const CMlngUseMaterialFontSize          As Integer = 9                      'ﾌｫﾝﾄｻｲｽﾞ(選択)
    Private Const CMlngvsfFrozenCols                As Integer = 0                      '固定列

    '@使用部材一覧定数(列番号)
    Private Const CMlngvsfColMaterialTypeID         As Integer = 0                      '部材種別
    Private Const CMlngvsfColParameterID            As Integer = 1                      'ﾊﾟﾗﾒｰﾀID
    Private Const CMlngvsfColMaterialID             As Integer = 2                      '部材
    Private Const CMlngvsfColMaterialLotID          As Integer = 3                      '部材管理ID
    Private Const CMlngvsfColUseMaterial            As Integer = 4                      '選択

    '@使用部材一覧定数(列幅)
    Private Const CMlngvsfColWMaterialTypeID        As Integer = 175                    '部材種別
    Private Const CMlngvsfColWParameterID           As Integer = 175                    'ﾊﾟﾗﾒｰﾀID
    Private Const CMlngvsfColWMaterialID            As Integer = 333                    '部材
    Private Const CMlngvsfColWMaterialLotID         As Integer = 179                    '部材管理ID
    Private Const CMlngvsfColWUseMaterial           As Integer = 66                     '選択

    '@使用部材一覧定数(ﾀｲﾄﾙ)
    Private Const CMstrvsfColTMaterialTypeID        As String = "部材種別"               '部材種別
    Private Const CMstrvsfColTParameterID           As String = "パラメータ"             '部材種別
    Private Const CMstrvsfColTMaterialID            As String = "部材"                   '部材
    Private Const CMstrvsfColTMaterialLotID         As String = "部材管理ID"             '部材管理ID
    Private Const CMstrvsfColTUseMaterial           As String = "選択"                   '選択

    '@機種一覧定数(列番号)
    Private Const CMlngvsfColPDID                   As Integer = 0                      '機種ID

    '@使用部材一覧定数(列幅)
    Private Const CMlngvsfColWPdID                  As Integer = 175                    '機種ID

    '@使用部材一覧定数(ﾀｲﾄﾙ)
    Private Const CMstrvsfColTPdID                  As String = "機種"                  '機種ID

    '@機種限定あり／なし表示用
    Private Const CMstrPdRestrictON                 As String = "機種限定あり"                  'ｷｬﾌﾟｼｮﾝ
    Private Const CMstrPdRestrictOFF                As String = "機種限定なし"                  'ｷｬﾌﾟｼｮﾝ

    '@ﾚｽﾎﾟﾝｽ計測用
    Private Const CMstrFormName                     As String = "frmxxCM00Y0"            '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                     As String = "Form_Load"              'ｲﾍﾞﾝﾄ名定数(ﾌｫｰﾑﾛｰﾄﾞ)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypMaterialList                        As MaterialWPList                   '部材ﾘｽﾄ(装置IDｷｰ)
    Private mblnFormLoadFlag                        As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：起動時以外/False：起動時のみ)
    Private mblnMaterialFlag                        As Boolean                          '使用可能な部材存在ﾌﾗｸﾞ(True：あり/False：なし)
    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                          'NSYS WindowCloseフラグ

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
        pubVsfMouseWheelManager_Set(vsfUseMaterialList, cmdUp, cmdDown, cmdLeft, cmdRight)
        pubVsfMouseWheelManager_Set(vsfRestrictPd, cmdUp2, cmdDown2)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ Load処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/27 (Tue) 10:24:24 N.Kojima
    '更新日：2006/10/13 (Fri) 09:43:48 N.Kojima
    '備　考：
    '　　　：2006/10/13 (Fri) 09:43:48 N.Kojima     機種限定情報表示に伴い、処理追加。(案件№01472)
    Private Sub Form_Load()
        
        Dim lblnAns     As Boolean      '戻り値格納用
        
        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化
            cmdRegist.Enabled = False       '確定
            cmdLeft.Enabled = False         '≪ﾎﾞﾀﾝ
            cmdRight.Enabled = False        '≫ﾎﾞﾀﾝ
            
            '@ﾗﾍﾞﾙの初期化
            lblPdRestrict.Visible = False    '機種限定情報
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@部材情報の取得
            lblnAns = pubblnMatMaterialList_Sel(CMstrmat_materiallistVer, _
                                                pstrWPID, _
                                                mtypMaterialList)
            
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            End If
            
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Me.Left = 0 - My.Settings.FormOffset
            Me.Top = 0

            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True
            
            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/27 (Tue) 10:33:15 N.Kojima
    '更新日：2006/06/27 (Tue) 10:33:15
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Dim lblnRtn As Boolean  '汎用戻り値
        
        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If mblnFormLoadFlag = False Then
                    
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
               
                '@使用部材ﾘｽﾄ初期化処理
                Call prvGrid_Init()
                    
                '@使用部材ﾘｽﾄ表示処理
                Call prvGrid_Disp()
                
                '@ｸﾞﾘｯﾄﾞにﾃﾞｰﾀ行が存在する場合
                If vsfUseMaterialList.Rows.Count > 1 Then
                    '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfUseMaterialList)
                Else
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If

                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True

                '@使用可能な部材存在ﾌﾗｸﾞ(True：あり/False：なし)
                mblnMaterialFlag = True

                '@部材種別が存在する場合
                If mtypMaterialList.lngMaterialTypeCnt > 0 Then
                    '@使用可能な部材ﾁｪｯｸ
                    lblnRtn = prvblnMaterialCnt_Chk

                    '@ｴﾗｰの場合
                    If lblnRtn = False Then
                        '@使用可能な部材存在ﾌﾗｸﾞ(True：あり/False：なし)
                        mblnMaterialFlag = False
                    End If
                End If

            End If

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
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2006/07/04 (Tue) 10:01:23 N.Kojima
    '更新日：2007/07/05 (Thu) 12:05:52 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 12:05:52 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
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

            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfUseMaterialList, cmdUP, cmdDown)
            
            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ）
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfUseMaterialList, cmdLeft, cmdRight)
            
            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理判別
            Select Case ActiveControl.Name

                '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙがｽﾌﾟﾚｯﾄﾞの場合
                Case vsfUseMaterialList.Name
                    '@ｸﾞﾘｯﾄﾞｷｰ制御（[→]ｷｰﾎﾞﾀﾝ,[←]ｷｰﾎﾞﾀﾝ）
                    With vsfUseMaterialList
                        Select Case e.KeyCode
        '@↓2007/07/05 (Thu) 12:06:30 N.Kasai **************************************************
        '@この記述では制御出来ません
        '                    '@ｸﾞﾘｯﾄﾞｷｰ制御（[←]ｷｰﾎﾞﾀﾝ）
        '                    Case vbKeyLeft
        '
        '                        '@左ｽｸﾛｰﾙﾎﾞﾀﾝが有効か
        '                        If cmdLeft.Enabled = True Then
        '                            '@左(<<)ｽｸﾛｰﾙﾎﾞﾀﾝ処理をCall
        '                            Call cmdLeft_Click
        '                            KeyCode = 0
        '                        End If
        '
        '                   '@ｸﾞﾘｯﾄﾞｷｰ制御（[→]ｷｰﾎﾞﾀﾝ）
        '                    Case vbKeyRight
        '                        '@右ｽｸﾛｰﾙﾎﾞﾀﾝが有効か
        '                        If cmdRight.Enabled = True Then
        '                            '@右(>>)ｽｸﾛｰﾙﾎﾞﾀﾝ処理をCall
        '                            Call cmdRight_Click
        '                            KeyCode = 0
        '                        End If
        '@↑2007/07/05 (Thu) 12:06:30 N.Kasai **************************************************

                            '@Enterｷｰの場合
                            Case Keys.Return
                                '@次項目へｾｯﾄﾌｫｰｶｽ
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True

                            Case Else
                                '@その他の場合はｽﾙｰ
                        End Select
                    End With
                        
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
    '機　能：ﾌｫｰﾑ終了前処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：
    '作成日：2006/06/27 (Tue) 10:33:46 N.Kojima
    '更新日：2006/06/27 (Tue) 10:33:46
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

            '@構造体の初期化
            mtypMaterialList.typMaterialTypeList = Nothing

            '@ﾓｼﾞｭｰﾙ変数構造体の初期化
            mblnFormLoadFlag = False

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
    '機　能：閉じるﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/27 (Tue) 10:33:56 N.Kojima
    '更新日：2006/06/27 (Tue) 10:33:56
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

    '関数名：cmdDown_Click
    '機　能：▼ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/27 (Tue) 10:34:22 N.Kojima
    '更新日：2006/06/27 (Tue) 10:34:22
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
            Call pubVsfCmdDown(vsfUseMaterialList, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：▲ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/27 (Tue) 10:34:42 N.Kojima
    '更新日：2006/06/27 (Tue) 10:34:42
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
            Call pubVsfCmdUp(vsfUseMaterialList, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown2_Click
    '機　能：▼ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/27 (Tue) 10:34:22 N.Kojima
    '更新日：2006/06/27 (Tue) 10:34:22
    '備　考：
    Private Sub cmdDown2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdDown(vsfRestrictPd, cmdUP2, cmdDown2)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp2_Click
    '機　能：▲ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/27 (Tue) 10:34:42 N.Kojima
    '更新日：2006/06/27 (Tue) 10:34:42
    '備　考：
    Private Sub cmdUp2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdUp(vsfRestrictPd, cmdUP2, cmdDown2)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLeft_Click
    '機　能："≪"ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/27 (Tue) 10:35:13 N.Kojima
    '更新日：2007/07/05 (Thu) 12:01:52 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 12:01:52 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub cmdLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2007/07/05 (Thu) 12:01:47 N.Kasai **************************************************
        '    '@左ｽｸﾛｰﾙ処理
        '    Call prvcmdLeft_Proc(vsfUseMaterialList, cmdLeft, cmdRight)
            '@左ｽｸﾛｰﾙﾎﾞﾀﾝ制御
            Call pubVsfCmdLeft(vsfUseMaterialList, cmdLeft, cmdRight)
        '@↑2007/07/05 (Thu) 12:01:47 N.Kasai **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLeft_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRight_Click
    '機　能："≫"ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/27 (Tue) 10:35:35 N.Kojima
    '更新日：2007/07/05 (Thu) 12:00:54 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 12:00:54 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub cmdRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2007/07/05 (Thu) 12:00:51 N.Kasai **************************************************
            '@右ｽｸﾛｰﾙ処理
        '    Call prvcmdRight_Proc(vsfUseMaterialList, cmdLeft, cmdRight)
            '@右ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            Call pubVsfCmdRight(vsfUseMaterialList, cmdLeft, cmdRight)
        '@↑2007/07/05 (Thu) 12:00:51 N.Kasai **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRight_Click"
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
    '作成日：2006/06/27 (Tue) 16:46:55 N.Kojima
    '更新日：2006/12/21 (Thu) 09:15:20 N.Kasai
    '備　考：
    '　　　：2006/10/03 (Tue) 14:53:58 N.Kojima     送信用構造体に"MatchFlag"を追加し、機種限定の一致or相違を設定。(案件№01472)
    '　　　：2006/12/21 (Thu) 09:15:20 N.Kasai      ﾊﾟﾗﾒｰﾀ追加（№01515）
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ1
        Dim llngCnt2        As Integer      '汎用ｶｳﾝﾀ2
        Dim llngCnt3        As Integer      '汎用ｶｳﾝﾀ3
        Dim lblnChkFlag     As Boolean      'ﾁｪｯｸﾌﾗｸﾞ
        
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
            
            '@ﾁｪｯｸﾌﾗｸﾞ,汎用ｶｳﾝﾀの初期化
            lblnChkFlag = False
            llngCnt = 1             'ｸﾞﾘｯﾄ行ﾙｰﾌﾟ用ｶｳﾝﾀ
            llngCnt2 = 0            '部材種別IDﾙｰﾌﾟ用ｶｳﾝﾀ
            llngCnt3 = 1            '部材ID,部材管理IDﾙｰﾌﾟ用ｶｳﾝﾀ
            
            '@使用部材選択済み判定ﾌﾗｸﾞの初期化
            pblnMaterialSelectFlag = False
            
            '@送信用構造体への格納処理
            ptypChkMaterial.typMaterialTypeList = New List(Of MaterialTypeList)
            For llngCnt = 1 To vsfUseMaterialList.Rows.Count - 1
                '@ﾁｪｯｸが付いている場合
                If vsfUseMaterialList.GetCellCheck(llngCnt, CMlngvsfColUseMaterial) = CheckEnum.Checked Then
                    
                    llngCnt2 = llngCnt2 + 1
                    
                    '@送信ﾃﾞｰﾀ作成(ここでは選択されている部材情報のみ格納)
                    With ptypChkMaterial
                        
                        Dim tmpMaterialTypeList As New MaterialTypeList
                        With tmpMaterialTypeList
                        
                            .typMaterialIDList = New List(Of MaterialIDList)
                            '@部材種別ID,
                            .strMaterialTypeID = _
                                vsfUseMaterialList.GetData(llngCnt, CMlngvsfColMaterialTypeID)
                                
        '@↓2006/12/21 (Thu) 09:16:51 N.Kasai **************************************************
                            '@ﾊﾟﾗﾒｰﾀID,
                            .strParameterID = _
                                vsfUseMaterialList.GetData(llngCnt, CMlngvsfColParameterID)
        '@↑2006/12/21 (Thu) 09:16:51 N.Kasai **************************************************
                            
                            '@部材ID数の格納(必ず"1")
                            .lngMaterialCnt = llngCnt3
                            
                            Dim tmpMaterialIDList As New MaterialIDList
                            With tmpMaterialIDList
                            
                                .typMaterialLotIDList = New List(Of MaterialLotIDList)
                                '@部材ID
                                .strMaterialID = _
                                    vsfUseMaterialList.GetData(llngCnt, CMlngvsfColMaterialID)
                                    
                                '@部材管理ID数の格納(必ず"1")
                                .lngMaterialLotCnt = llngCnt3
                                
        '@↓2006/10/03 (Tue) 14:53:05 N.Kojima **************************************************
        '@現在は使用していません。使用する時はｺﾒﾝﾄｱｳﾄを解除して下さい。
        '                        '@背景色がｸﾞﾚｰか
        '                        If vsfUseMaterialList.Cell(flexcpBackColor, llngCnt, CMlngvsfColMaterialID) = CPlngNotInputColor Then
        '                            '@ｸﾞﾚｰの場合は、"1=機種限定相違"を設定
        '                            .strMatchFlag = CPstrOne
        '                        Else
        '                            '@ｸﾞﾚｰの場合は、"0=機種限定一致"を設定
        '                            .strMatchFlag = CPstrZero
        '                        End If
        '@↑2006/10/03 (Tue) 14:53:05 N.Kojima **************************************************
                                    
                                Dim tmpMaterialLotIDList As New MaterialLotIDList
                                With tmpMaterialLotIDList
                                
                                    '@部材管理ID
                                    .strMaterialLotID = _
                                        vsfUseMaterialList.GetData(llngCnt, CMlngvsfColMaterialLotID)
                                End With
                                .typMaterialLotIDList.Add(tmpMaterialLotIDList)
                            End With
                            .typMaterialIDList.Add(tmpMaterialIDList)
                        End With
                        .typMaterialTypeList.Add(tmpMaterialTypeList)
                    End With
                End If
            Next
            
            '@部材種別数の格納
            ptypChkMaterial.lngMaterialTypeCnt = llngCnt2
                                        
            '@汎用ｶｳﾝﾀの初期化
            llngCnt2 = 1
                                        
            '@部材種別に対して1部材が最低選択されているかのﾁｪｯｸ
            With mtypMaterialList
                For llngCnt = 0 To .lngMaterialTypeCnt - 1
                    With .typMaterialTypeList(llngCnt)
                        
                        For llngCnt2 = 0 To ptypChkMaterial.lngMaterialTypeCnt - 1
                            '@構造体の部材種別とｸﾞﾘｯﾄﾞに表示されている部材種別が同じ場合
                            If .strMaterialTypeID = ptypChkMaterial.typMaterialTypeList(llngCnt2).strMaterialTypeID Then
                                lblnChkFlag = True
                                Exit For
                            Else
                                lblnChkFlag = False
                            End If
                        Next
                        
                        '@ﾁｪｯｸﾌﾗｸﾞをFalse(=未選択)
                        If lblnChkFlag = False Then
                    
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008D)
                            '@publngMsgBoxInfo("<TRM8DW>$$部材種別に対し、最低1つ部材を選択してください。")
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                            '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfUseMaterialList)
                            Exit Sub
                        End If
                    End With
                Next
            End With
            
            '@使用部材選択済みﾌﾗｸﾞをTrue(=選択済み)にする
            pblnMaterialSelectFlag = True

            '@画面を閉じる
            Call cmdClose_Click(cmdClose, New EventArgs)
            
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

    '関数名：vsfUseMaterialList_Click
    '機　能：使用部材ﾘｽﾄClick処理
    '引　数：なし
    '戻り値：
    '作成日：2006/06/27 (Tue) 16:49:02 N.Kojima
    '更新日：2006/06/27 (Tue) 16:49:02
    '備　考：
    Private Sub vsfUseMaterialList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfUseMaterialList.Click

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfUseMaterialList.Rows.Count <= vsfUseMaterialList.Rows.Fixed Then
                Return
            End If
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If mblnFormLoadFlag = False Then
                Exit Sub
            End If
            
            '@ｶﾚﾝﾄｾﾙを編集ﾓｰﾄﾞにする
            With vsfUseMaterialList
                
                '@ｶﾚﾝﾄｾﾙがﾍｯﾀﾞｰ行でなく、「選択」列の場合
                If .Row <> 0 And .Col = CMlngvsfColUseMaterial Then
                    
                    '@現在のﾁｪｯｸ状況を判定し、処理を分岐
                    If .GetCellCheck(.Row, CMlngvsfColUseMaterial) = CheckEnum.Unchecked Then
                        '@現在ﾁｪｯｸなし→ﾁｪｯｸする
                        .AllowEditing = True
                        .SetCellCheck(.Row, CMlngvsfColUseMaterial, CheckEnum.Checked)     'ﾁｪｯｸ
                        .AllowEditing = False
                    Else
                        '@現在ﾁｪｯｸあり→ﾁｪｯｸ解除
                        .AllowEditing = True
                        .SetCellCheck(.Row, CMlngvsfColUseMaterial, CheckEnum.Unchecked)   'ﾁｪｯｸ解除
                        .AllowEditing = False
                    End If
                    
        '@↓2007/05/09 (Wed) 17:00:30 N.Kasai **************************************************
                    '@使用可能な部材が存在する場合
                    If mblnMaterialFlag = True Then
                        For llngCnt = 1 To .Rows.Count - 1
                            '@ﾁｪｯｸが付いている場合
                            If .GetCellCheck(llngCnt, CMlngvsfColUseMaterial) = CheckEnum.Checked Then
                                '@確定ﾎﾞﾀﾝを有効にする
                                cmdRegist.Enabled = True
                                Exit For
                            Else
                                '@確定ﾎﾞﾀﾝを無効にする
                                cmdRegist.Enabled = False
                            End If
                        Next
                    End If
        '@↑2007/05/09 (Wed) 17:00:30 N.Kasai **************************************************
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUseMaterialList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseMaterialList_KeyDown
    '機　能：使用部材一覧ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：keycode
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2006/07/05 (Wed) 15:39:50 N.Kojima
    '更新日：2006/07/05 (Wed) 15:39:50
    '備　考：
    Private Sub vsfUseMaterialList_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfUseMaterialList.KeyDown

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfUseMaterialList.Rows.Count <= vsfUseMaterialList.Rows.Fixed Then
                Return
            End If

            Select Case e.KeyCode
                '@Spaceｷｰの場合
                Case Keys.Space
                    '@ｸﾞﾘｯﾄﾞ編集(ﾁｪｯｸﾎﾞｯｸｽ)を許可する制御
                    Call vsfUseMaterialList_Click(sender, e)
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUseMaterialList_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseMaterialList_RowColChange
    '機　能：使用部材一覧行列変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/28 (Wed) 19:30:31 N.Kojima
    '更新日：2006/10/13 (Fri) 09:41:18 N.Kojima
    '備　考：
    '　　　：2006/10/13 (Fri) 09:41:18 N.Kojima     機種限定情報を表示する対応を追加。(案件№01472)
    Private Sub vsfUseMaterialList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfUseMaterialList.RowColChange

        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ1
        Dim llngCnt2            As Integer      '汎用ｶｳﾝﾀ2
        Dim llngCnt3            As Integer      '汎用ｶｳﾝﾀ3
        Dim lblnReDrawFlag      As Boolean      '再描画中ﾌﾗｸﾞ(True:再描画中、False:再描画中以外)
        
        '@再描画中ﾌﾗｸﾞがTrue(=再描画中)、又は初回起動時か
        If lblnReDrawFlag = True Or mblnFormLoadFlag = False Then
            Exit Sub
        End If
        
        '@再描画ﾌﾗｸﾞの初期化
        lblnReDrawFlag = False
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfUseMaterialList.Rows.Count <= vsfUseMaterialList.Rows.Fixed Then
                Return
            End If
            
            With mtypMaterialList
                
                '@再描画ﾌﾗｸﾞをTrue(=再描画中)に設定
                lblnReDrawFlag = True
                
                For llngCnt = 0 To .lngMaterialTypeCnt - 1
                    
                    With .typMaterialTypeList(llngCnt)
                                        
                        '@機種限定の確認(選択されている部材種別の機種限定)
                        If .strMaterialTypeID = _
                            vsfUseMaterialList.GetData(vsfUseMaterialList.Row, CMlngvsfColMaterialTypeID) Then
                            
                            '@機種限定情報ﾗﾍﾞﾙを表示
                            lblPdRestrict.Visible = True
                            
                            '@機種限定ﾌﾗｸﾞが「1：設定あり」か
                            If .strPdLimitFlag = CPstrOne Then
                                '@機種限定あり
                                
                                '@「機種限定あり」をﾗﾍﾞﾙに表示する
                                lblPdRestrict.Text = CMstrPdRestrictON
                                lblPdRestrict.ForeColor = Color.Red
                            Else
                                '@機種限定なし
                                
                                '@「機種限定なし」をﾗﾍﾞﾙに表示する
                                lblPdRestrict.Text = CMstrPdRestrictOFF
                                lblPdRestrict.ForeColor = Color.Black
                            End If
                        End If
                                        
                        For llngCnt2 = 0 To .lngMaterialCnt - 1
                            
                            '@選択されている部材と構造体の部材を比較
                            If .typMaterialIDList(llngCnt2).strMaterialID = _
                                vsfUseMaterialList.GetData(vsfUseMaterialList.Row, CMlngvsfColMaterialID) Then
                                
                                '@同じ場合
                                vsfRestrictPd.Row = -1
                                vsfRestrictPd.Rows.Count = 1      'ｸﾘｱ
                                
                                With .typMaterialIDList(llngCnt2)
                                    For llngCnt3 = 0 To .lngPdListCnt - 1
                                        
                                        '@機種がNULLじゃない場合
                                        If .typPdList(llngCnt3).strPdId <> vbNullString Then
                                            '@機種一覧の再描画
                                            
                                            '@行数設定
                                            vsfRestrictPd.Rows.Count = vsfRestrictPd.Rows.Count + 1
                                            '@機種ID表示
                                            vsfRestrictPd.SetData(vsfRestrictPd.Rows.Count - 1, CMlngvsfColPDID, _
                                                .typPdList(llngCnt3).strPdId)
                                        End If
                                    Next
                                End With
                            End If
                        Next
                    End With
                Next
            End With
            
            '@行の高さ
            vsfRestrictPd.Rows.DefaultSize = CMlngvsfRestrictPdHeight        '機種ﾘｽﾄ
            vsfRestrictPd.Rows(CMlngvsfFixedRow).Height = CMlngVsfHHeight
            
            '@機種ﾘｽﾄが0件の場合
            If vsfRestrictPd.Rows.Count <= 1 Then
                '@使用不可
                vsfRestrictPd.Enabled = False       '機種ﾘｽﾄ
            Else
                '@ﾃﾞｰﾀ行が存在する場合
                '@使用可
                vsfRestrictPd.Enabled = True        '機種ﾘｽﾄ
            End If
            
            '@機種ﾘｽﾄの"▲","▼"ﾎﾞﾀﾝ初期化
            Call pubVsfDisp(vsfRestrictPd, cmdUP2, cmdDown2)
            
            '@再描画ﾌﾗｸﾞの初期化
            lblnReDrawFlag = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUseMaterialList_RowColChange"
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

    '関数名：prvGrid_Init
    '機　能：ｸﾞﾘｯﾄﾞの初期化処理　①使用部材ﾘｽﾄ,②機種ﾘｽﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/27 (Tue) 10:27:13 N.Kojima
    '更新日：2006/06/27 (Tue) 10:27:13
    '備　考：
    Private Sub prvGrid_Init()

        Try
            
            '@★★★★★★★★★★
            '@　　使用部材ﾘｽﾄ
            '@★★★★★★★★★★
            With vsfUseMaterialList
                .Row = -1
                '@列数
                .Cols.Count = CMlngvsfColS
                '@行数
                .Rows.Count = .Rows.Fixed
                '@ﾌｫﾝﾄｻｲｽﾞ(16)
                .Font = New Font(.Font.FontFamily, CType(CMlngvsfUseMaterialListFontSize, Single), .Font.Style)
                .Cols(CMlngvsfColUseMaterial).Style.Font = New Font(.Font.FontFamily, CType(CMlngUseMaterialFontSize, Single), .Font.Style)
                '@行選択
                .SelectionMode = SelectionModeEnum.Row
                '@ﾌｫｰｶｽ表示あり
                .FocusRect = FocusRectEnum.Light
                '@ﾊｲﾗｲﾄ表示
                .HighLight = HighLightEnum.Always
                '@列幅自動設定
                '.AutoSizeMode = flexAutoSizeColWidth
                '@省略符号（...）を表示
                .Styles.Normal.Trimming = StringTrimming.None
                '@ｿｰﾄ機能なし
                .AllowSorting = AllowSortingEnum.None
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                With .Font                                              'ﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngvsfHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                lFixedStyle.ForeColor = Color.Yellow                                                                     '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                       '背景色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                                                       '配置
                lFixedStyle.Trimming = StringTrimming.None                                                               '省略表示なし
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfFixedRow, CMlngvsfColMaterialTypeID, CMstrvsfColTMaterialTypeID)         '部材種別
                .SetData(CMlngvsfFixedRow, CMlngvsfColParameterID, CMstrvsfColTParameterID)               'ﾊﾟﾗﾒｰﾀID
                .SetData(CMlngvsfFixedRow, CMlngvsfColMaterialID, CMstrvsfColTMaterialID)                 '部材
                .SetData(CMlngvsfFixedRow, CMlngvsfColMaterialLotID, CMstrvsfColTMaterialLotID)           '部材管理ID
                .SetData(CMlngvsfFixedRow, CMlngvsfColUseMaterial, CMstrvsfColTUseMaterial)               '選択
                
                '@列幅設定
                .Cols(CMlngvsfColMaterialTypeID).Width = CMlngvsfColWMaterialTypeID       '部材種別
                .Cols(CMlngvsfColParameterID).Width = CMlngvsfColWParameterID             'ﾊﾟﾗﾒｰﾀID
                .Cols(CMlngvsfColMaterialID).Width = CMlngvsfColWMaterialID               '部材
                .Cols(CMlngvsfColMaterialLotID).Width = CMlngvsfColWMaterialLotID         '部材管理ID
                .Cols(CMlngvsfColUseMaterial).Width = CMlngvsfColWUseMaterial             '選択

                '@行の高さ
                .Rows.DefaultSize = CMlngvsfUseMaterialListHeight
                .Rows(CMlngvsfFixedRow).Height = CMlngVsfHHeight

                '@結合ｾﾙの設定
                .AllowMerging = AllowMergingEnum.RestrictAll
                .Cols(CMlngvsfColMaterialTypeID).AllowMerging = True         '部材種別
                .Cols(CMlngvsfColParameterID).AllowMerging = True            'ﾊﾟﾗﾒｰﾀID
                .Cols(CMlngvsfColMaterialID).AllowMerging = True             '部材
                .Cols(CMlngvsfColMaterialLotID).AllowMerging = True          '部材管理ID
                .Cols(CMlngvsfColUseMaterial).AllowMerging = True            '選択

                '@横ｽｸﾛｰﾙ画面初期化処理
                .LeftCol = CMlngvsfFrozenCols
                
                '@ﾛｯｸ
                .Enabled = False
                
            End With
            
            '@★★★★★★★★★★
            '@　　機種ﾘｽﾄ
            '@★★★★★★★★★★
            With vsfRestrictPd
                .Row = -1
                '@列数
                .Cols.Count = 1
                '@行数
                .Rows.Count = .Rows.Fixed
                '@ﾌｫﾝﾄｻｲｽﾞ(11)
                .Font = New Font(.Font.FontFamily, CMlngvsfRestrictPdFontSize, .Font.Style, .Font.Unit)
                '@行選択
                .SelectionMode = SelectionModeEnum.Row
                '@ﾌｫｰｶｽ表示なし
                .FocusRect = FocusRectEnum.None
                '@ﾊｲﾗｲﾄ表示
                .HighLight = HighLightEnum.Never
                '@列幅自動設定
                '.AutoSizeMode = flexAutoSizeColWidth
                '@省略符号（...）を表示
                .Styles.Normal.Trimming = StringTrimming.None
                '@ｿｰﾄ機能あり
                .AllowSorting = AllowSortingEnum.SingleColumn
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                With .Font                                              'ﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngvsfHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                lFixedStyle.ForeColor = Color.Yellow                                                                     '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                       '背景色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                                                       '配置
                lFixedStyle.Trimming = StringTrimming.None                                                               '省略表示なし

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfFixedRow, CMlngvsfColPDID, CMstrvsfColTPdID)         '機種
                
                '@列幅設定
                .Cols(CMlngvsfColPDID).Width = CMlngvsfColWPdID       '機種

                '@行の高さ
                .Rows.DefaultSize = CMlngvsfRestrictPdHeight
                .Rows(CMlngvsfFixedRow).Height = CMlngVsfHHeight
                
                '@横ｽｸﾛｰﾙ画面初期化処理
                .LeftCol = CMlngvsfFrozenCols
                
                '@ﾛｯｸ
                .Enabled = False
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ﾌﾗｸﾞを戻す
            mblnFormLoadFlag = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGrid_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvGrid_Disp
    '機　能：ｸﾞﾘｯﾄﾞの表示処理　①使用部材ﾘｽﾄ,②機種ﾘｽﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/27 (Tue) 16:02:00 N.Kojima
    '更新日：2010/06/18 (Fri) 14:50:26 T.Oide
    '備　考：
    '　　　：2006/10/04 (Wed) 16:49:30 N.Kojima     部材の機種限定機能への仕様追加に伴い、処理追加。(案件№01472)
    '　　　：2006/11/28 (Tue) 20:16:36 N.Kojima     部材管理IDの色分け処理に、制約期限警告状態・制約期限超過状態の色分けを追加。(案件№01586)
    '　　　：2007/01/19 (Fri) 09:26:13 N.Kojima     ｲﾝﾃﾞｯｸｽｴﾗｰで落ちる件の緊急対応。(案件№01733)
    '　　　：2007/05/10 (Thu) 10:39:44 N.Kasai      部材idが0件の場合ｼｽﾃﾑｴﾗｰ発生（既存ﾊﾞｸﾞだ）
    '　　　：2010/06/16 (Wed) 17:03:09 T.Oide       №04097 使用部材ﾎﾞﾀﾝ追加対応
    Private Sub prvGrid_Disp()
        
        Dim llngCnt                 As Integer  '汎用ﾙｰﾌﾟｶｳﾝﾀ1
        Dim llngCnt2                As Integer  '汎用ﾙｰﾌﾟｶｳﾝﾀ2
        Dim llngCnt3                As Integer  '汎用ﾙｰﾌﾟｶｳﾝﾀ3
        Dim llngCnt4                As Integer  '汎用ﾙｰﾌﾟｶｳﾝﾀ4
        Dim llngRowCnt1             As Integer  '描画行識別用1
        Dim llngRowCnt2             As Integer  '描画行識別用2
        Dim llngRowCnt3             As Integer  '描画行識別用3
        Dim llngRowCnt4             As Integer  '描画行識別用4
        Dim llngNullRow             As Integer  '空行格納用
    '@↓2010/06/18 (Fri) 15:28:18 T.Oide **************************************************
        Dim llngCnt5                As Integer
        Dim llngCnt6                As Integer
    '@↑2010/06/18 (Fri) 15:28:18 T.Oide **************************************************
        
        Try
            
            '@ｶｳﾝﾀの初期化
            llngCnt = 1
            llngCnt2 = 1

            '@使用部材一覧&機種一覧
            With vsfUseMaterialList
                
                '@描画なし
                .Redraw = False
                vsfRestrictPd.Redraw = False       '機種ﾘｽﾄ
                
                '@部材種別が1件以上存在する場合
                If mtypMaterialList.lngMaterialTypeCnt > 0 Then
                
                    '@行数を格納
                    With mtypMaterialList
                        
                        '@部材種別数分ﾙｰﾌﾟ
                        For llngCnt = 0 To .lngMaterialTypeCnt - 1
                            With .typMaterialTypeList(llngCnt)
                                '@部材種別ID数 + 部材ID数(ﾙｰﾌﾟ)
                                For llngCnt2 = 0 To .lngMaterialCnt - 1
                                    With .typMaterialIDList(llngCnt2)
                                        '@部材種別ID数 + 部材ID数(ﾙｰﾌﾟ) + 部材管理ID数(ﾙｰﾌﾟ)
                                        vsfUseMaterialList.Rows.Count = vsfUseMaterialList.Rows.Count + .lngMaterialLotCnt
                                    End With
                                Next
                            End With
                        Next
                    End With
                    
                    '@ｶｳﾝﾀの初期化
                    llngCnt = 0
                    llngCnt2 = 0
                    llngCnt3 = 0
                    llngCnt4 = 1
                    llngRowCnt1 = 1
                    llngRowCnt2 = 1
                    llngRowCnt3 = 1
                    llngRowCnt4 = 1

                    With mtypMaterialList
                                    
                        '@部材ﾘｽﾄのﾙｰﾌﾟ
                        Do While llngCnt <= .lngMaterialTypeCnt - 1
                            
                            With .typMaterialTypeList(llngCnt)
                                
                                '@部材種別IDがNULLではない場合
                                If .strMaterialTypeID <> vbNullString Then

                                    '@部材が存在する場合
                                    If .lngMaterialCnt > 0 Then
                                        '@部材種別ID
                                        vsfUseMaterialList.SetData(llngRowCnt1, CMlngvsfColMaterialTypeID, _
                                            .strMaterialTypeID)
            
                                        If .strParameterID = vbNullString Then
                                            '@空白設定（ｾﾙﾏｰｼﾞ用）
                                            vsfUseMaterialList.SetData(llngRowCnt1, CMlngvsfColParameterID, CPstrSpace)
                                        Else
                                            '@ﾊﾟﾗﾒｰﾀID
                                            vsfUseMaterialList.SetData(llngRowCnt1, CMlngvsfColParameterID, _
                                                .strParameterID)
                                        End If
                                    
                                    End If
                                
                                End If
                                
                                '@部材IDのﾙｰﾌﾟ
                                Do While llngCnt2 <= .lngMaterialCnt - 1
                                    With .typMaterialIDList(llngCnt2)
                                        
                                        '@部材IDがNULLじゃない場合
                                        If .strMaterialID <> vbNullString Then
                                            '@部材種別ID
                                            vsfUseMaterialList.SetData(llngRowCnt2, CMlngvsfColMaterialTypeID, _
                                                vsfUseMaterialList.GetData(llngRowCnt1, CMlngvsfColMaterialTypeID))
                                                
                                            '@ﾊﾟﾗﾒｰﾀID
                                            vsfUseMaterialList.SetData(llngRowCnt2, CMlngvsfColParameterID, _
                                                vsfUseMaterialList.GetData(llngRowCnt1, CMlngvsfColParameterID))


                                            '@部材ID
                                            vsfUseMaterialList.SetData(llngRowCnt2, CMlngvsfColMaterialID, _
                                                .strMaterialID)
                                        End If
                                        
                                        '@部材管理IDのﾙｰﾌﾟ
                                        Do While llngCnt3 <= .lngMaterialLotCnt - 1
                                            With .typMaterialLotIDList(llngCnt3)
                                                
                                                '@部材管理IDがNULLじゃない場合
                                                If .strMaterialLotID <> vbNullString Then
                                                    '@部材種別ID
                                                    vsfUseMaterialList.SetData(llngRowCnt3, CMlngvsfColMaterialTypeID, _
                                                        vsfUseMaterialList.GetData(llngRowCnt1, CMlngvsfColMaterialTypeID))
                                                        

                                                    '@ﾊﾟﾗﾒｰﾀID
                                                    vsfUseMaterialList.SetData(llngRowCnt3, CMlngvsfColParameterID, _
                                                        vsfUseMaterialList.GetData(llngRowCnt1, CMlngvsfColParameterID))

                                                        
                                                    '@部材ID
                                                    vsfUseMaterialList.SetData(llngRowCnt3, CMlngvsfColMaterialID, _
                                                        vsfUseMaterialList.GetData(llngRowCnt2, CMlngvsfColMaterialID))
                                                    '@部材管理ID
                                                    vsfUseMaterialList.SetData(llngRowCnt3, CMlngvsfColMaterialLotID, _
                                                        .strMaterialLotID)
                                                                                            
                                                    '@機種限定が設定されているか(1:機種限定あり)
                                                    If mtypMaterialList.typMaterialTypeList(llngCnt).strPdLimitFlag = CPstrOne Then
                                                        
        '@↓2010/06/18 (Fri) 15:08:13 T.Oide **************************************************
        '@                                                '@限定機種ぶんﾙｰﾌﾟ
        '@                                                For llngCnt4 = 1 To mtypMaterialList.typMaterialTypeList(llngCnt).typMaterialIDList(llngCnt2).lngPdListCnt
        '@
        '@                                                    '@ﾛｯﾄの機種と部材の機種制限の機種が同じ場合
        '@                                                    If mtypMaterialList.typMaterialTypeList(llngCnt).typMaterialIDList(llngCnt2).typPdList(llngCnt4).strPdID = frmxxEN0030.lblPdID.Caption Then
        '@
        '@                                                        '@背景色の設定(白色)
        '@                                                        vsfUseMaterialList.Cell(flexcpBackColor, llngRowCnt3, _
        '@                                                                                CMlngvsfColMaterialTypeID, llngRowCnt3, _
        '@                                                                                CMlngvsfColUseMaterial) = vbWhite
        '@
        '@                                                        '@制約期限警告状態(ﾒｰｶｰ保証ﾜｰﾆﾝｸﾞ期間、受入制限ﾜｰﾆﾝｸﾞ期間、ﾜｰﾆﾝｸﾞ表示時間の何れか)か
        '@                                                        If .strVenderWarrantWarningDaysJudge = CPstrOne Or _
        '@                                                            .strAcceptWarrantWarningDaysJudge = CPstrOne Or _
        '@                                                            .strWarningPeriodJudge = CPstrOne Then
        '@
        '@                                                            '@背景色の設定(黄色)
        '@                                                            vsfUseMaterialList.Cell(flexcpBackColor, llngRowCnt3, _
        '@                                                                                    CMlngvsfColMaterialTypeID, llngRowCnt3, _
        '@                                                                                    CMlngvsfColUseMaterial) = CPlngHoldLotColor
        '@                                                        Else
        '@                                                            '@制限警告状態ではない場合
        '@
        '@                                                            '@背景色の設定(白色)
        '@                                                            vsfUseMaterialList.Cell(flexcpBackColor, llngRowCnt3, _
        '@                                                                                    CMlngvsfColMaterialTypeID, llngRowCnt3, _
        '@                                                                                    CMlngvsfColUseMaterial) = vbWhite
        '@                                                        End If
        '@
        '@                                                        '@制約期限超過状態(ﾒｰｶｰ保証期間、受入制限期間、使用可能時間の何れか)か
        '@                                                        If .strVenderWarrantDaysJudge = CPstrOne Or _
        '@                                                            .strAcceptWarrantDaysJudge = CPstrOne Or _
        '@                                                            .strUseValidPeriodJudge = CPstrOne Then
        '@
        '@                                                            '@背景色の設定(ﾋﾟﾝｸ色)
        '@                                                            vsfUseMaterialList.Cell(flexcpBackColor, llngRowCnt3, _
        '@                                                                                    CMlngvsfColMaterialTypeID, llngRowCnt3, _
        '@                                                                                    CMlngvsfColUseMaterial) = CPlngStopLotColor
        '@                                                        End If
        '@
        '@                                                        '@ﾏｯﾁしている場合
        '@                                                        Exit For
        '@                                                    Else
        '@                                                        '@異なる場合
        '@
        '@                                                        '@背景色の設定(灰色)
        '@                                                        vsfUseMaterialList.Cell(flexcpBackColor, llngRowCnt3, _
        '@                                                                                CMlngvsfColMaterialTypeID, llngRowCnt3, _
        '@                                                                                CMlngvsfColUseMaterial) = CPlngNotInputColor
        '@                                                    End If
        '@
        '@                                              Next
        '@                                              '--------------------------------------------------------------------
                                                        
                                                        '@機種限定がﾛｯﾄの機種と一致しているか確認
                                                        
                                                        llngCnt6 = 0
                                                        '@限定機種ぶんﾙｰﾌﾟ
                                                        For llngCnt4 = 0 To mtypMaterialList.typMaterialTypeList(llngCnt).typMaterialIDList(llngCnt2).lngPdListCnt - 1
                                                            
                                                            '@機種ぶんﾙｰﾌﾟ(ﾊﾞｯﾁ作業開始の場合複数機種の可能性があり全て一致していないと灰色にする)
                                                            llngCnt5 = 0
                                                            Do While pstrPDIDAry.Count - 1 >= llngCnt5
                                                            
                                                                '@限定機種とﾛｯﾄの機種が一致しているか
                                                                If mtypMaterialList.typMaterialTypeList(llngCnt).typMaterialIDList(llngCnt2).typPdList(llngCnt4).strPdId = _
                                                                    pstrPDIDAry(llngCnt5) Then
                                                                    
                                                                    llngCnt6 = llngCnt6 + 1
                                                                    
                                                                End If
                                                                llngCnt5 = llngCnt5 + 1
                                                            Loop
                                                        
                                                        Next
                                                        
                                                        '@pstrPDIDAryの全ての要素が限定の機種であったか
                                                        If pstrPDIDAry.Count = llngCnt6 Then
                                                            
                                                            '限定OKの場合
                                                            
                                                            '@背景色の設定(白色)
                                                            Dim newStyle As CellStyle = vsfUseMaterialList.Styles.Add("CustomStyle_BackColor_vbWhite")
                                                            newStyle.BackColor = Color.White
                                                            Dim cellRange As CellRange = vsfUseMaterialList.GetCellRange(llngRowCnt3, _
                                                                                    CMlngvsfColMaterialTypeID, llngRowCnt3, _
                                                                                    CMlngvsfColUseMaterial)
                                                            cellRange.Style = newStyle

                                                            '@制約期限警告状態(ﾒｰｶｰ保証ﾜｰﾆﾝｸﾞ期間、受入制限ﾜｰﾆﾝｸﾞ期間、ﾜｰﾆﾝｸﾞ表示時間の何れか)か
                                                            If .strVenderWarrantWarningDaysJudge = CPstrOne Or _
                                                                .strAcceptWarrantWarningDaysJudge = CPstrOne Or _
                                                                .strWarningPeriodJudge = CPstrOne Then
                                                                
                                                                '@背景色の設定(黄色)
                                                                Dim newStyle2 As CellStyle = vsfUseMaterialList.Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                                                                newStyle2.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                                                                cellRange.Style = newStyle2
                                                            Else
                                                                '@制限警告状態ではない場合
                                                            End If
                                                                                        
                                                            '@制約期限超過状態(ﾒｰｶｰ保証期間、受入制限期間、使用可能時間の何れか)か
                                                            If .strVenderWarrantDaysJudge = CPstrOne Or _
                                                                .strAcceptWarrantDaysJudge = CPstrOne Or _
                                                                .strUseValidPeriodJudge = CPstrOne Then
                                                                
                                                                '@背景色の設定(ﾋﾟﾝｸ色)
                                                                Dim newStyle3 As CellStyle = vsfUseMaterialList.Styles.Add("CustomStyle_BackColor_CPlngStopLotColor")
                                                                newStyle3.BackColor = ColorTranslator.FromWin32(CPlngStopLotColor)
                                                                cellRange.Style = newStyle3
                                                            End If
                                                            
                                                        Else
                                                            '@異なる場合
                                                        
                                                            '@背景色の設定(灰色)
                                                            Dim newStyle As CellStyle = vsfUseMaterialList.Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                                                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                                                            Dim cellRange As CellRange = vsfUseMaterialList.GetCellRange(llngRowCnt3, _
                                                                                    CMlngvsfColMaterialTypeID, llngRowCnt3, _
                                                                                    CMlngvsfColUseMaterial)
                                                            cellRange.Style = newStyle
                                                        End If
        '@↑2010/06/18 (Fri) 15:08:13 T.Oide **************************************************
                                                    Else
                                                        '@機種限定が設定されていない場合(0:機種限定なし)
                                                        
                                                        
                                                        '@背景色の設定(白色)
                                                        Dim newStyle As CellStyle = vsfUseMaterialList.Styles.Add("CustomStyle_BackColor_vbWhite")
                                                        newStyle.BackColor = Color.White
                                                        Dim cellRange As CellRange = vsfUseMaterialList.GetCellRange(llngRowCnt3, _
                                                                                CMlngvsfColMaterialTypeID, llngRowCnt3, _
                                                                                CMlngvsfColUseMaterial)
                                                        cellRange.Style = newStyle

                                                        '@制約期限警告状態(ﾒｰｶｰ保証ﾜｰﾆﾝｸﾞ期間、受入制限ﾜｰﾆﾝｸﾞ期間、ﾜｰﾆﾝｸﾞ表示時間の何れか)か
                                                        If .strVenderWarrantWarningDaysJudge = CPstrOne Or _
                                                            .strAcceptWarrantWarningDaysJudge = CPstrOne Or _
                                                            .strWarningPeriodJudge = CPstrOne Then
                                                            
                                                            '@背景色の設定(黄色)
                                                            Dim newStyle2 As CellStyle = vsfUseMaterialList.Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                                                            newStyle2.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                                                            cellRange.Style = newStyle2
                                                        Else
                                                            '@制限警告状態ではない場合
                                                        End If
                                                                                    
                                                        '@制約期限超過状態(ﾒｰｶｰ保証期間、受入制限期間、使用可能時間の何れか)か
                                                        If .strVenderWarrantDaysJudge = CPstrOne Or _
                                                            .strAcceptWarrantDaysJudge = CPstrOne Or _
                                                            .strUseValidPeriodJudge = CPstrOne Then
                                                            
                                                            '@背景色の設定(ﾋﾟﾝｸ色)
                                                            Dim newStyle3 As CellStyle = vsfUseMaterialList.Styles.Add("CustomStyle_BackColor_CPlngStopLotColor")
                                                            newStyle3.BackColor = ColorTranslator.FromWin32(CPlngStopLotColor)
                                                            cellRange.Style = newStyle3
                                                        End If

                                                    End If
                                            
                                                End If
                                            End With
                                            '@ﾙｰﾌﾟｶｳﾝﾀ,描画行識別用変数のｶｳﾝﾄUP
                                            llngCnt3 = llngCnt3 + 1
                                            llngRowCnt3 = llngRowCnt3 + 1
                                        Loop
                                            
                                        '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                                        llngCnt3 = 0
                                        
                                    End With
                                    '@ﾙｰﾌﾟｶｳﾝﾀ,描画行識別用変数のｶｳﾝﾄUP
                                    llngCnt2 = llngCnt2 + 1
                                    llngRowCnt2 = llngRowCnt3
                                Loop
                            End With
                            '@ﾙｰﾌﾟｶｳﾝﾀ,描画行識別用変数のｶｳﾝﾄUP
                            llngCnt = llngCnt + 1
                            llngRowCnt1 = llngRowCnt3
                            llngCnt2 = 0
                            llngCnt3 = 0
                        Loop
                    End With
                    
                    '@空行を検索(部材種別IDが空白)
                    llngCnt = 1
                    For llngCnt = 1 To .Rows.Count - 1
                        If .GetData(llngCnt, CMlngvsfColMaterialTypeID) = vbNullString Then
                            llngNullRow = llngCnt
                            Exit For
                        End If
                    Next

                    '@空行があった場合のみ空行を削除
                    If llngNullRow <> 0 Then
                        '@空行削除
                        .Rows.Count = (.Rows.Count - 1) - ((.Rows.Count - 1) - llngNullRow)
                    End If

                    '@行の高さ
                    .Rows.DefaultSize = CMlngvsfUseMaterialListHeight
                    .Rows(CMlngvsfFixedRow).Height = CMlngVsfHHeight
                    vsfRestrictPd.Rows.DefaultSize = CMlngvsfRestrictPdHeight        '機種ﾘｽﾄ
                    vsfRestrictPd.Rows(CMlngvsfFixedRow).Height = CMlngVsfHHeight
                    
                    '@右端の列の幅を自動調整をやめる
                    .ExtendLastCol = False
                    
                    '@列幅設定
                    .AutoSizeCols(CMlngvsfColMaterialTypeID, .Cols.Count - 1, 6)
                    
                    '@右端の列の幅を自動調整する
                    .ExtendLastCol = True
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                    '@機種ﾘｽﾄが0件の場合
                    If vsfRestrictPd.Rows.Count <= 1 Then
                        '@使用不可
                        vsfRestrictPd.Enabled = False       '機種ﾘｽﾄ
                    Else
                        '@ﾃﾞｰﾀ行が存在する場合
                        '@使用可
                        vsfRestrictPd.Enabled = True        '機種ﾘｽﾄ
                    End If
                
                    

                End If
                
                '@直接描画
                .Redraw = True
                vsfRestrictPd.Redraw = True     '機種ﾘｽﾄ
                
            End With
            
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御（ｸﾞﾘｯﾄﾞ共通化関数）
            Call pubCmdLREnable_Set(vsfUseMaterialList, cmdLeft, cmdRight)
            
            '@使用部材ﾘｽﾄの"▲","▼"ﾎﾞﾀﾝ初期化
            Call pubVsfDisp(vsfUseMaterialList, cmdUP, cmdDown)
            
            '@機種ﾘｽﾄの"▲","▼"ﾎﾞﾀﾝ初期化
            Call pubVsfDisp(vsfRestrictPd, cmdUP2, cmdDown2)
            
            '@登録済みﾃﾞｰﾀの反映
            For llngCnt4 = 1 To vsfUseMaterialList.Rows.Count - 1
                
                '@部材種別ｶｳﾝﾄ数が1件以上ある場合
                If ptypChkMaterial.lngMaterialTypeCnt > 0 Then
                
                    With ptypChkMaterial
                        For llngCnt = 0 To .lngMaterialTypeCnt - 1
                            With .typMaterialTypeList(llngCnt)
                                '@選択されていた部材種別IDと表示されている部材種別IDを比較
                                If .strMaterialTypeID = vsfUseMaterialList.GetData(llngCnt4, CMlngvsfColMaterialTypeID) Then
                                    For llngCnt2 = 0 To .lngMaterialCnt - 1
                                        With .typMaterialIDList(llngCnt2)
                                            '@選択されていた部材IDと表示されている部材IDを比較
                                            If .strMaterialID = vsfUseMaterialList.GetData(llngCnt4, CMlngvsfColMaterialID) Then
                                                For llngCnt3 = 0 To .lngMaterialLotCnt - 1
                                                    With .typMaterialLotIDList(llngCnt3)
                                                        '@選択されていた部材管理IDと表示されている部材管理IDを比較
                                                        If .strMaterialLotID = vsfUseMaterialList.GetData(llngCnt4, CMlngvsfColMaterialLotID) Then
                                                            '@同じ場合はﾁｪｯｸを付ける
                                                            vsfUseMaterialList.SetCellCheck(llngCnt4, CMlngvsfColUseMaterial, CheckEnum.Checked)
                                                        End If
                                                    End With
                                                Next
                                            End If
                                        End With
                                    Next
                                End If
                            End With
                        Next
                    End With
                End If
            Next
            
            Exit Sub

        Catch ex As Exception

            '@ﾌﾗｸﾞを戻す
            mblnFormLoadFlag = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGrid_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnMaterialCnt_Chk
    '機　能：使用可能な部材ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:正常、False:ｴﾗｰ
    '作成日：2007/05/09 (Wed) 17:01:58 N.Kasai
    '更新日：2007/05/09 (Wed) 17:01:58
    '備　考：
    Private Function prvblnMaterialCnt_Chk() As Boolean
        
        Dim llngCnt             As Integer  'ｶｳﾝﾄ
        Dim lstrMaterialTypeID  As String   '部材種別
        Dim lblnErrFlag         As Boolean  'ｴﾗｰ判定ﾌﾗｸﾞ
        Dim llngNo              As Integer  'ｴﾗｰｶｳﾝﾄ№
        
        Try
            
            '@戻り値初期化
            prvblnMaterialCnt_Chk = False
            '@ｴﾗｰﾌﾗｸﾞ初期化
            lblnErrFlag = False
            '@ｴﾗｰｶｳﾝﾄ初期化
            llngNo = 0
            
            '@該当ﾃﾞｰﾀ検索
            For llngCnt = 0 To mtypMaterialList.lngMaterialTypeCnt - 1
                '@利用可能な部材IDが存在しない場合はｴﾗｰ
                If mtypMaterialList.typMaterialTypeList(llngCnt).lngMaterialCnt = 0 Then
                    
                    '@ｴﾗｰｶｳﾝﾄ
                    llngNo = llngNo + 1
                    
                    '@ﾒｯｾｰｼﾞ表示用　部材種別退避
                    lstrMaterialTypeID = lstrMaterialTypeID & llngNo & "、 [" & _
                    mtypMaterialList.typMaterialTypeList(llngCnt).strMaterialTypeID & "]" & vbCrLf
                    
                    '@ｴﾗｰあり
                    lblnErrFlag = True
                    
                End If
            Next
            
            '@ｴﾗｰ判定
            If lblnErrFlag = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009C, lstrMaterialTypeID)
                '@"<TRM9CW>$$[部材種別]に紐付く部材がありません。$装置使用部材管理画面で設定を確認して下さい。$$ %1"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Function
            End If
            
            '@ﾁｪｯｸ正常
            prvblnMaterialCnt_Chk = True

            Exit Function

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnMaterialCnt_Chk"      '処理名
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

    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraRestrictPd.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

    '関数名：vsfUseMaterialList_MouseUp
    '機　能：使用部材一覧 ﾏｳｽｱｯﾌﾟ処理
    '引　数：Button：未使用
    '　　　：Shift：未使用
    '　　　：X：未使用
    '　　　：Y：未使用
    '戻り値：なし
    '作成日：2020/03/27 (Fri) 11:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub vsfUseMaterialList_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfUseMaterialList.MouseUp

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfUseMaterialList.Rows.Count <= vsfUseMaterialList.Rows.Fixed Then
                Return
            End If

            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御（ｸﾞﾘｯﾄﾞ共通化関数）
            Call pubCmdLREnable_Set(vsfUseMaterialList, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUseMaterialList_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

End Class
