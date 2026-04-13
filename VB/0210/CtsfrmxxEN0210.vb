'ﾌｧｲﾙ名：xxEN0210.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：部材受入
'作成日：2004/04/26 (Mon) 16:57:20 S.Deguchi
'更新日：2008/04/24 (Thu) 11:24:28 N.Kojima
'備　考：
'　　　：2004/10/26 (Tue) 10:43:19 S.Deguchi    "calDate_Validate"のDoEventsを削除(理由：不要なｺｰﾄﾞなので)
'　　　：2007/08/24 (Fri) 10:30:25 N.Kasai      ｿｰｽ整備
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0210
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0210    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0210
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0210
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0210)
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
    Private Const CMstrLocalVersion                 As String = "01.02"         '機能ﾊﾞｰｼﾞｮﾝ

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrinv_accept__Ver              As String = "01.00"         '部材受入要求
    Private Const CMstrmas_empname_Ver              As String = "02.01"         '作業者名取得
    Private Const CMstrmas_partlistVer              As String = "03.00"         '部材ﾘｽﾄ
    Private Const CMstrmas_thicklistVer             As String = "01.00"         '板厚区分取得
    Private Const CMstrmas_vendclasslistVer         As String = "02.00"         'ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄ取得

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN0210  'ﾛｰｶﾙﾒﾆｭｰKey

    '@ComboBox設定
    Private Const CMlngCmbFontSize                  As Integer = 16             'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 16             'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispColIndex              As Integer = 0              '表示列番
    Private Const CMlngCmbDispColName               As Integer = 1              '名称表示列
    Private Const CMlngCmbValueCol                  As Integer = 0              '値表示列
    Private Const CMlngCmbGetCol                    As Integer = 3              '値取得列
    Private Const CMlngCmbDispCols                  As Integer = 1              'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbDispCols2                 As Integer = 2              'ｸﾞﾘｯﾄﾞ表示列数=2(種別/部品Comboの場合のみ)
    Private Const CMlngCmbRowHeight                 As Integer = 43             'ﾘｽﾄ行の高さ

    '@部品種別Combo
    Private Const CMlngGetIDValueCol                As Integer = 1              'ID取得Col数

    '@部品Combo
    Private Const CMlngGetPartIDValueCol            As Integer = 0              '部品ID取得Col数
    Private Const CMlngGetPartIndexValueCol         As Integer = 2              '部品ｲﾝﾃﾞｯｸｽ取得Col数

    '@ﾌﾞﾗﾝｸ(日付と時間の間)
    Private Const CMstrBrank                        As String = " "             'ﾌﾞﾗﾝｸ(ｽﾍﾟｰｽ)

    '@WF,CF
    Private Const CMstrWFID                         As String = "01"            '原料基板
    Private Const CMstrCFID                         As String = "02"            '対向基板
    Private Const CMstrDMID                         As String = "03"            'ﾀﾞﾐｰ基板

    '@ﾘﾜｰｸ回数
    Private Const CMlngReworkCount                  As Integer = 0              'ﾘﾜｰｸ回数初期値(=0)&ﾘﾜｰｸComboIndex値(=0)

    '@ﾁｪｯｸ定数
    Private Const CMlngCheckNum                     As Integer = 0              'ﾁｪｯｸ項目最小値

    '@ｹｰｽ数
    Private Const CMlngCFCaseNum                    As Integer = 1              'WF(基準基板)以外用ｹｰｽ数

    '@部材受入要求用秒
    Private Const CMstrDefaultSecond                As String = ":00"           '渡し用秒設定

    '@表示ﾒｯｾｰｼﾞ
    Private Const CMstrEmpIDTitle                   As String = "受入担当者ID"  '受入担当者ID

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mstrEventName                           As String                      'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
    Private mstrTaihiClassName                      As String                      '退避用部品種別名
    Private mstrTaihiClassID                        As String                      '退避用部品種別ID
    Private mstrTaihiPartID                         As String                      '退避用部品ID
    Private mtyppartlist                            As List(Of PartClassList)      '部品ﾘｽﾄ
    Private mtypThicknessClassList                  As List(Of ThicknessClassList) '板厚区分ﾘｽﾄ
    Private mlngTaihiPartIndex                      As Integer                     '退避用部品ｲﾝﾃﾞｯｸｽ
    Private mlngThicknessCnt                        As Integer                     '板厚区分数
    Private mblnFormActivateFlag                    As Boolean                     'ﾌｫｰﾑのｱｸﾃｨﾍﾞｲﾄﾌﾗｸﾞ(True:無効/False:有効)
    Private buttonProcessing                        As Boolean                     'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                     'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                     'NSYS WindowCloseフラグ

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
        medTime.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
        Form_Load()
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：Form_Load
    '機　能：初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 16:59:25 S.Deguchi
    '更新日：2004/06/10 (Thu) 16:59:19 T.Kitagawa
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim ltypVenderlist      As VenderList           'ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄ

        Try
            'NSYS 画面表示位置
            Me.StartPosition = FormStartPosition.Manual
            Me.Top  = 0
            Me.Left = 0 - My.Settings.FormOffset

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0210, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                '@ﾌｫｰﾑを閉じる
                Me.CancelButton = Nothing
                Exit Sub
            End If
            
            '@画面情報の初期化
            Call prvfrmxxEN0210_Init()

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            mstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, mstrEventName)

            '@部品種別情報の取得【CPstrCD02：全て】
            lblnAns = pubblnVendClassList_Sel(CMstrmas_vendclasslistVer, CPstrCD02, ltypVenderlist)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            Else
                '@部品種別情報表示
                Call prvCmbClassName_Disp(ltypVenderlist)
            End If
            
            '@板厚区分(ﾘｽﾄ)情報の取得
            lblnAns = pubblnThicknessClass_Sel(CMstrmas_thicklistVer, mtypThicknessClassList, mlngThicknessCnt)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, mstrEventName)
            
            '@閉じるボタンへCausesValidationを設定する
            cmdClose.CausesValidation = False

            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
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

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/16 (Tue) 18:16:58 S.Deguchi
    '更新日：2004/11/16 (Tue) 18:16:58
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            '@ﾌｫｰﾑﾛｰﾄﾞの最初の一回のみ処理を行う為の処理
            If mblnFormActivateFlag = False Then
                '@ﾌﾗｸﾞ変更(現処理を行わなくする1)
                mblnFormActivateFlag = True
                
                '@部品種別情報が１件の場合
                With cmbPartClass
                    If .ListCount = 1 Then
                        '@１件目表示
                        .ListIndex = 0
                        '@部品種別のValidate処理を呼出す
                        RemoveHandler cmbPartClass.Validating,AddressOf cmbPartClass_Validate
                        Call cmbPartClass_Validate(sender,New CancelEventArgs(False))
                        AddHandler cmbPartClass.Validating,AddressOf cmbPartClass_Validate
                    End If
                End With
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
    '作成日：2004/04/26 (Mon) 17:25:04 S.Deguchi
    '更新日：2004/06/16 (Wed) 19:19:55 K.Takano
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理判別
            Select Case ActiveControl.Name
                '@部品種別の場合
                Case cmbPartClass.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@部品種別Validate処理へ
                            RemoveHandler cmbPartClass.Validating,AddressOf cmbPartClass_Validate
                            Call cmbPartClass_Validate(sender,New CancelEventArgs(True))
                            AddHandler cmbPartClass.Validating,AddressOf cmbPartClass_Validate
                            '@入力ﾁｪｯｸ
                            Call prvLock_Check()
                            e.Handled = True
                        Case Else
                    End Select
                '@受入担当者IDの場合
                Case txtUser.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@受入担当者IDValidate処理へ
                            RemoveHandler txtUser.Validating,AddressOf txtUser_Validate
                            Call txtUser_Validate(sender,New CancelEventArgs(True))
                            AddHandler txtUser.Validating,AddressOf txtUser_Validate
                        Case Else
                    End Select
                    
                '@上記以外の場合
                Case Else
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@入力ﾁｪｯｸ
                            Call prvLock_Check()
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
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:18:23 S.Deguchi
    '更新日：2004/11/01 (Mon) 15:20:02 T.Kitagawa
    '備　考：2004/11/01 (Mon) 15:20:02 T.Kitagawa　閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ﾌﾟﾗｲﾍﾞｰﾄ変数のｸﾘｱ
            mtyppartlist = Nothing
            mtypThicknessClassList = Nothing

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

            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄとの関連付けを解除
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
    '作成日：2004/04/26 (Mon) 17:16:28 S.Deguchi
    '更新日：2004/04/26 (Mon) 17:16:28
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim llngRet As Integer          '関数戻り値
        Dim ltypCommonInfo  As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@終了関数を実行する
            llngRet = publngEnd_Proc(CPstrKeyEN0210, ltypCommonInfo)
            
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

    '関数名：cmbPartClass_Change
    '機　能：部品種別変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 11:14:21 S.Deguchi
    '更新日：2004/04/27 (Tue) 11:14:21
    '備　考：
    Private Sub cmbPartClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPartClass.Change

        Try
            '@入力ｺﾝﾄﾛｰﾙ初期化
            Call prvfraCommPart_Init()
            Call prvfraCFInfo_Init()
            Call prvfraCFInfo_Set(False)

            '@部品種別以外Comboのｸﾘｱ
            cmbPart.Clear()
            cmbBoardThickness.Clear()
            cmbRework.Clear()

            '@部品種別以外Comboの非活性化
            cmbPart.Enabled = False
            cmbBoardThickness.Enabled = False
            cmbRework.Enabled = False
            
            '@確定ﾎﾞﾀﾝ制御
            cmdRegist.Enabled = False

            '@退避領域のｸﾘｱ
            mstrTaihiClassID = vbNullString
            mstrTaihiPartID = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPartClass_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPartClass_CloseUp
    '機　能：ｸﾛｰｽﾞｱｯﾌﾟ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/12 (Wed) 17:07:55 S.Deguchi
    '更新日：2004/05/12 (Wed) 17:07:55
    '備　考：
    Private Sub cmbPartClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPartClass.CloseUp

        Try
            '@空白の場合はﾌｫｰｶｽの移動はしない
            If cmbPartClass.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbPartClass.Validating,AddressOf cmbPartClass_Validate
                Call cmbPartClass_Validate(sender,New CancelEventArgs(True))
                AddHandler cmbPartClass.Validating,AddressOf cmbPartClass_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPartClass_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPartClass_Validate
    '機　能：部品種別_Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:00:38 S.Deguchi
    '更新日：2004/11/16 (Tue) 14:12:39 N.Kojima
    '備　考：2004/09/06 (Mon) 19:01:07 N.Kasai　pubblnMasPartList_Sel Ver3.0対応
    '　　　：2004/11/16 (Tue) 14:12:39 N.Kojima　部品種別ｺﾝﾎﾞ1件表示時の対応
    Private Sub cmbPartClass_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPartClass.Validating
        
        Dim lblnClassAns        As Boolean
        Dim llngpartcnt         As Integer              '部材ﾘｽﾄｶｳﾝﾄ
        Dim ltypMasPartlist     As MasPartlist          '部材ｺｰﾄﾞﾘｽﾄ要求構造体

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            mstrEventName = "cmbPartClass_Validate"
            
            '@前回部品種別IDと同じ場合は処理を抜ける
            If cmbPartClass.Text = mstrTaihiClassName Then
                '@部品名が有効か
                If cmbPart.Enabled = True Then
                    '@部品名にﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbPartClass.Name Then
                        Call pubSetFocus(cmbPart)
                    End If
                End If
                Exit Sub
            End If
            
            '@選択されていない場合には処理抜け&部品Combo非活性化
            cmbPartClass.ValueCol = CMlngGetIDValueCol                  'ID取得Col
            If cmbPartClass.Value = vbNullString Then
                '@画面設定初期化
                Call prvfrmxxEN0210_Init()
                '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = cmbPartClass.Name Then
                    Call pubSetFocus(cmdClose)
                End If
                Exit Sub
            Else
                cmbPart.Enabled = True
            End If
            
            '@選択された部品種別により入力ﾌﾚｰﾑを制御
            With cmbPartClass
                
                '@共通部分を活性化
                txtInvLotID.Enabled = True                             '製造ﾛｯﾄID
                txtPartNum.Enabled = True                              '受入数
                calDate.Enabled = True                                 '受入日時(年月日)
                medTime.Enabled = True                                 '受入日時(時間)
                txtUser.Enabled = True                                 '受入担当者
                cmdNowDate.Enabled = True                              '現在時刻取得
                
                '@対向基板(CF)の場合
                .ValueCol = CMlngGetIDValueCol
                If .Value = CMstrCFID Then
                    '@CF追加入力欄入力ｺﾝﾄﾛｰﾙを活性化にする
                    Call prvfraCFInfo_Set(True)
                Else
                    '@CF追加入力欄入力ｺﾝﾄﾛｰﾙを非活性化にする
                    Call prvfraCFInfo_Set(False)
                End If
            End With
            
            '@部品ﾘｽﾄ取得
            cmbPart.ValueCol = CMlngGetPartIDValueCol
            
            If cmbPart.Value <> mstrTaihiPartID Or cmbPart.Value = vbNullString Then
            '@部材退避領域と異なる場合と空欄の場合
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, mstrEventName)
                
                '@部材ｺｰﾄﾞﾘｽﾄ要求構造体へ格納
                With ltypMasPartlist
                    .strSbID = pstrSBID                     '処理区分
                    .strMsgVer = CMstrmas_partlistVer       'ﾒｯｾｰｼﾞVersion
                    .strPdId = vbNullString                 '機種ID(取得できない為)
                    .strMasPdVersion = vbNullString         'PDVersion(取得できない為)
                    
                    '@ﾍﾞﾝﾀﾞｰｸﾗｽ取得
                    cmbPartClass.ValueCol = CMlngGetIDValueCol
                    .strVenderClassId = cmbPartClass.Value  '部品ID(部材ID)
                End With
                                
                '@部材ｺｰﾄﾞ、ﾍﾞﾝﾀﾞｰ取得
                lblnClassAns = pubblnMasPartList_Sel(ltypMasPartlist, llngpartcnt, mtyppartlist)
                
                '@結果判定
                If lblnClassAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    
                    '@部品種別IDの退避領域ｸﾘｱ
                    mstrTaihiClassID = vbNullString
                    
                    Exit Sub
                Else
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
                    
                    '@部品情報表示
                    Call prvCmbPartName_Disp(mtyppartlist, llngpartcnt)
                    
                    '@部品種別IDを退避領域へ取得
                    With cmbPartClass
                        .ValueCol = CMlngGetIDValueCol
                        mstrTaihiClassID = .Value
                        mstrTaihiClassName = .Text
                    End With
                    
                    '@部品Comboへｾｯﾄﾌｫｰｶｽ
                    If ActiveControl.Name = cmbPartClass.Name Then
                        Call pubSetFocus(cmbPart)
                    End If
                End If
            Else
                '@退避領域と同じIDの場合

                '@部品Comboへｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = cmbPartClass.Name Then
                    Call pubSetFocus(cmbPart)
                End If
            End If

            '@入力ﾁｪｯｸ
            Call prvLock_Check()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPartClass_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPart_CloseUp
    '機　能：ｸﾛｰｽﾞｱｯﾌﾟ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/12 (Wed) 17:11:35 S.Deguchi
    '更新日：2004/05/12 (Wed) 17:11:35
    '備　考：
    Private Sub cmbPart_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPart.CloseUp

        Try
            If cmbPart.Text <> vbNullString Then
                '@製造ﾛｯﾄIDがﾛｯｸ解除されている場合
                If txtInvLotID.Enabled = True Then
                    '@製造ﾛｯﾄIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtInvLotID)
                End If
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

    '関数名：cmbPart_Change
    '機　能：部品変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 10:02:57 M.Miura
    '更新日：2004/06/02 (Wed) 10:02:57
    '備　考：
    Private Sub cmbPart_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPart.Change

        Dim llngIndex           As Integer              '部品ID
        Dim lstrThicknessClass  As String               '板厚区分

        Try
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            mstrEventName = "cmbPart_Validate"
            
            '@選択されていない場合には処理抜け
            If cmbPart.Value = vbNullString Then
                Exit Sub
            End If

            '@部品ID取得
            With cmbPart
                .ValueCol = 3
                If .Value <> mstrTaihiPartID Or .Value = vbNullString Then
                '@退避領域と異なる場合,ﾘｽﾄ設定処理

                    '@部品IDを退避領域へ取得
                    mstrTaihiPartID = .Value
            
                    '@選択された部品IDを取得
                    llngIndex = .ListIndex
                    mlngTaihiPartIndex = llngIndex
                    
                    '@CFの場合には板厚,ﾘﾜｰｸ回数のCombo作成へ
                    If mstrTaihiClassID = CMstrCFID Then
                        '@板厚,ﾘﾜｰｸ数Combo活性化
                        cmbBoardThickness.Enabled = True
                        cmbRework.Enabled = True

                        '@板厚Combo作成処理へ
                        .ValueCol = 2
                        lstrThicknessClass = .Value
                        Call prvCmbThicknessName_Disp(mtypThicknessClassList, lstrThicknessClass, mlngThicknessCnt)
            
                        '@ﾘﾜｰｸ数Combo作成処理へ
                        Call prvCmbReworkName_Disp(mtyppartlist, llngIndex)
                
                        '@ﾘﾜｰｸ回数の初期値ｾｯﾄ
                        cmbRework.ListIndex = CMlngReworkCount
                    End If
                    
                Else
                '@退避領域と同じID場合
                
                    '@CFの場合
                    If mstrTaihiClassID = CMstrCFID Then
                        '@板厚,ﾘﾜｰｸ数Combo活性化
                        cmbBoardThickness.Enabled = True
                        cmbRework.Enabled = True
                    End If
            
                End If
            End With
            
            '@入力ﾁｪｯｸ
            Call prvLock_Check()

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

    '関数名：txtInvLotID_Change
    '機　能：製造ﾛｯﾄID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:16:24 M.Miura
    '更新日：2004/06/02 (Wed) 09:16:24
    '備　考：
    Private Sub txtInvLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtInvLotID.Change

        Try
            '@入力ﾁｪｯｸ
            Call prvLock_Check()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInvLotID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPartNum_Change
    '機　能：受入数変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:28:48 M.Miura
    '更新日：2004/06/02 (Wed) 09:28:48
    '備　考：
    Private Sub txtPartNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtPartNum.Change

        Try
            '@入力ﾁｪｯｸ
            Call prvLock_Check()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPartNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPartNum_Validate
    '機　能：受入数Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 17:59:42 S.Deguchi
    '更新日：2004/09/26 (Sun) 14:27:51 H.Wajima
    '備　考：2004/06/23 (Wed) 19:52:58 N.Kojima
    '　　　：2004/09/26 (Sun) 14:27:51 H.Wajima  部品種別の判定に"ﾀﾞﾐｰ基板"を追加
    Private Sub txtPartNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtPartNum.Validating
        
        Dim llngCal As Integer  '計算結果
        Dim llngMod As Integer  '計算結果(余)
        Dim llngNum As Object   '受入数退避領域

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            llngNum = txtPartNum.Text

            '@部品種別が"原料基板"、"ﾀﾞﾐｰ基板"の場合
            cmbPartClass.ValueCol = CMlngGetIDValueCol
            Select Case cmbPartClass.Value
                Case CMstrWFID, CMstrDMID
                    '@空欄でない場合下記処理
                    If txtPartNum.Text <> vbNullString Then
                        '@１ｹｰｽで割り切れるか計算
                        llngCal = CLng(llngNum) / 25                'ｹｰｽ数
                        llngMod = CLng(llngNum) Mod 25              '余り
                        
                        '@登録上限ﾁｪｯｸ
                        If llngCal >= 100 Then
                        '@同一受入ﾛｯﾄ通番99越えﾁｪｯｸ
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0044)
                            'NSYS エラー時のフォーカスちらつき対応
                            sender.Focus()
                            '@"原料基板、ダミー基板の場合には、1日の受入数は2475(99ケース)が上限です。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            '@ｹｰｽ数ｸﾘｱ
                            txtCaseNum.Text = vbNullString
                            '@受入数入力欄にｾｯﾄﾌｫｰｶｽ
                            e.Cancel = True
                            
                            Exit Sub
                        End If
                        
                        '@ｹｰｽ数に対しての余り計算
                        If llngMod > 0 Then
                        '@余が発生した場合
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0045)
                            'NSYS エラー時のフォーカスちらつき対応
                            sender.Focus()
                            '@"受入数には25(1ケース)で割り切れる値を入力してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            '@ｹｰｽ数ｸﾘｱ
                            txtCaseNum.Text = vbNullString
                            '@受入数入力欄にｾｯﾄﾌｫｰｶｽ
                            e.Cancel = True
                        Else
                            '@ｹｰｽ数ｸﾘｱ
                            txtCaseNum.Text = vbNullString
                        '@余が発生しない場合
                            txtCaseNum.Text = llngCal
                            txtPartNum.NumFormat = "#,###"
                        End If
                    End If
            End Select

            '@入力ﾁｪｯｸ
            Call prvLock_Check()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPartNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCaseNum_Change
    '機　能：ｹｰｽ数変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:30:46 M.Miura
    '更新日：2004/06/02 (Wed) 09:30:46
    '備　考：
    Private Sub txtCaseNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCaseNum.Change

        Try
            '@入力ﾁｪｯｸ
            Call prvLock_Check()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCaseNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calDate_CalendarSelect
    '機　能：受入日時選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/13 (Thu) 15:46:41 S.Deguchi
    '更新日：2004/05/13 (Thu) 15:46:41
    '備　考：
    Private Sub calDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calDate.CalendarSelect

        Try
            '@日付が選択されている場合
            If calDate.Value <> CPstrNullDate Then
                '@Validate処理に飛ぶ
                RemoveHandler calDate.Validating,AddressOf calDate_Validate
                Call calDate_Validate(sender,New CancelEventArgs(True))
                AddHandler calDate.Validating,AddressOf calDate_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calDate_Change
    '機　能：受入日時
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:35:50 M.Miura
    '更新日：2004/06/02 (Wed) 09:35:50
    '備　考：
    Private Sub calDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calDate.Change

        Try
            '@入力ﾁｪｯｸ
            Call prvLock_Check()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calDate_Validate
    '機　能：受入日時Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 17:50:54 S.Deguchi
    '更新日：2004/08/31 (Tue) 14:09:41 N.Kasai
    '備　考：2004/08/31 (Tue) 14:09:41 N.Kasai 未来日付の入力ﾁｪｯｸを追加
    '　　　：2004/10/26 (Tue) 09:49:08 S.Deguchi DoEventsを削除(意味がなかったので)
    Private Sub calDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calDate.Validating
        
        Dim lstrNowDT As String     '現在日時の退避

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@日付の有効性ﾁｪｯｸ
            
            If pubblnYearRange_Chk(calDate.Value) = False Then
                '@日付が入力されていない(空欄)場合
                If calDate.Value = CPstrNullDate Then
                    '@入力ﾁｪｯｸ
                    Call prvLock_Check()
                    Exit Sub
                End If
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0046)

                'NSYS エラー時のフォーカスちらつき対応
                sender.Focus()

                '@"受入日時の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@受入年月日入力欄にｾｯﾄﾌｫｰｶｽ
                e.Cancel = True
                
                '@現在日時が即使用出来るようにValidationを制御
                cmdNowDate.CausesValidation = False
                
                '@入力ﾁｪｯｸ
                Call prvLock_Check()
            
            Else
                '@現在日付取得
                lstrNowDT = Format(Now(), CPstrDateTimeYMD)
                '@未来日付の場合
                If Format(CDate(calDate.Value), CPstrDateTimeYMD) > lstrNowDT Then
                   '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)

                    'NSYS エラー時のフォーカスちらつき対応
                    sender.Focus()
                    
                    '@"未来日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                    
                    '@現在日時が即使用出来るようにValidationを制御
                    cmdNowDate.CausesValidation = False
                Else
                    '@受入時間にﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = calDate.Name Then
                        Call pubSetFocus(medTime)
                    End If
                End If
                
                '@入力ﾁｪｯｸ
                Call prvLock_Check()
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medTime_GotFocus
    '機　能：受入日時ﾌｫｰｶｽ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 13:01:44 S.Deguchi
    '更新日：2004/04/27 (Tue) 13:01:44
    '備　考：MaskEdBox使用のためﾊｲﾗｲﾄ処理
    Private Sub medTime_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles medTime.Enter

        Try
            '@ﾊｲﾗｲﾄ処理
            Call pubHighlight(medTime)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medTime_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medTime_Change
    '機　能：受入日時変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:37:57 M.Miura
    '更新日：2004/06/02 (Wed) 09:37:57
    '備　考：
    Private Sub medTime_Change(ByVal sender As Object, ByVal e As EventArgs) Handles medTime.TextChanged

        Try
            '@入力ﾁｪｯｸ
            Call prvLock_Check()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medTime_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medTime_Validate
    '機　能：受入日時Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 17:55:02 S.Deguchi
    '更新日：2004/04/27 (Tue) 17:55:02
    '備　考：
    Private Sub medTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles medTime.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@時間の有効性ﾁｪｯｸ
            If IsDate(medTime.Text) = False Then
                '@時間入力されていない(空欄)場合
                If Replace(Trim (medTime.Text),":",vbNullString) = vbNullString Then
                    '@入力ﾁｪｯｸ
                    Call prvLock_Check()
                    
                    Exit Sub
                End If
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0046)

                'NSYS エラー時のフォーカスちらつき対応
                sender.Focus()

                '@"受入日時の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@受入時間入力欄にｾｯﾄﾌｫｰｶｽ
                e.Cancel = True
                
                '@入力ﾁｪｯｸ
                Call prvLock_Check()
            
            Else
                '@入力ﾁｪｯｸ
                Call prvLock_Check()
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medTime_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowDate_Click
    '機　能：現在日時取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/29 (Thu) 10:57:23 S.Deguchi
    '更新日：2004/08/31 (Tue) 14:30:02 N.Kasai
    '備　考：2004/08/31 (Tue) 14:30:02 N.Kasai　最新日時のValidationを制御を追加
    '　　　：2004/11/09 (Tue) 16:14:06 S.Deguchi 時刻のﾌｫｰﾏｯﾄ"HH:MM"をﾊﾟﾌﾞﾘｯｸ定数へ変更
    Private Sub cmdNowDate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowDate.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@現在日時取得
            calDate.Value = Format$(Now(), CPstrDateTimeYMD)    '受入日時(年月日)
            medTime.Text = Format$(Now(), CPstrTimeFormatHM)    '受入日時(時間)

            '@入力ﾁｪｯｸ
            Call prvLock_Check()
            
            '@最新日時のValidationを制御(日付がｴﾗｰとなった場合に即使用できるように制御)
            cmdNowDate.CausesValidation = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowDate_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtUser_Change
    '機　能：受入担当者変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:39:26 M.Miura
    '更新日：2004/06/02 (Wed) 09:39:26
    '備　考：
    Private Sub txtUser_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtUser.Change

        Try
            '@入力ﾁｪｯｸ
            Call prvLock_Check()
            
            '@受入担当者名ｸﾘｱ
            lblEmpName.Text = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtUser_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtUser_Validate
    '機　能：受入担当者Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/29 (Thu) 15:19:59 S.Deguchi
    '更新日：2004/07/26 (Mon) 11:59:45 N.Kojima
    '更新日：2004/09/23 (Thu) 11:42:34 N.Kojima
    '備　考：
    '　　　：2004/09/23 (Thu) 11:42:34 N.Kojima　作業者検索ｴﾗｰMsgをSVで表示するように修正(不具合№895)
    Private Sub txtUser_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtUser.Validating
        
        Dim lstrEmpID               As String               '受入担当者ID
        Dim lstrEmpName             As String               '受入担当者名
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@受入担当者ID変数代入
            lstrEmpID = txtUser.Text
            
            '@空白時はそのまま
            If lstrEmpID = vbNullString Then
                '@出荷ﾛｯﾄIDが有効な場合
                If txtCFLotID.Enabled = True Then
                    '@出荷ﾛｯﾄIDにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtUser.Name Then
                        Call pubSetFocus(txtCFLotID)
                    End If
                Else
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtUser.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                Exit Sub
            End If
            
            '@受入担当者IDが入力されている場合
            If lstrEmpID <> vbNullString Then
                '@受入担当者IDの桁ﾁｪｯｸ
                If txtUser.NowByte < txtUser.ChrMaxByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003K, CMstrEmpIDTitle)

                    'NSYS エラー時のフォーカスちらつき対応
                    sender.Focus()

                    '@"[受入担当者ID]は7桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    e.Cancel = True
                    If ActiveControl.Name = txtUser.Name Then
                        Call pubSetFocus(txtUser)
                    End If
                    Exit Sub
                End If
                
                '@受入担当者名取得
                lblnAns = pubblnMasEmpName_Sel(CMstrmas_empname_Ver, lstrEmpID, lstrEmpName)
                '@結果判定
                If lblnAns = True Then
                    '@受入担当者名設定
                    lblEmpName.Text = lstrEmpName
                Else
                    e.Cancel = True
                    Exit Sub
                End If
            Else
                '@受入担当者名設定
                lblEmpName.Text = vbNullString
            End If
            
            '@入力ﾁｪｯｸ(確定ﾎﾞﾀﾝの有効無効判別)
            Call prvLock_Check()
            
            '@出荷ﾛｯﾄIDが有効な場合
            If txtCFLotID.Enabled = True Then
                '@出荷ﾛｯﾄIDにﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtUser.Name Then
                    Call pubSetFocus(txtCFLotID)
                End If
            Else
                '@確定ﾎﾞﾀﾝが有効な場合
                If cmdRegist.Enabled = True Then
                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtUser.Name Then
                        Call pubSetFocus(cmdRegist)
                    End If
                Else
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtUser.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtUser_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCFLotID_Change
    '機　能：出荷ﾛｯﾄID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:41:15 M.Miura
    '更新日：2004/06/02 (Wed) 09:41:15
    '備　考：
    Private Sub txtCFLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCFLotID.Change

        Try
            '@入力ﾁｪｯｸ
            Call prvLock_Check()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCFLotID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCFLotID_Validate
    '機　能：出荷ﾛｯﾄID_Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 18:01:08 S.Deguchi
    '更新日：2004/04/27 (Tue) 18:01:08
    '備　考：
    Private Sub txtCFLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCFLotID.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@入力ﾁｪｯｸ
            Call prvLock_Check()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCFLotID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbBoardThickness_Change
    '機　能：板厚Combo変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 18:02:11 S.Deguchi
    '更新日：2004/04/27 (Tue) 18:02:11
    '備　考：
    Private Sub cmbBoardThickness_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBoardThickness.Change

        Try
            '@板厚が選択されていない場合は処理抜け
            If cmbBoardThickness.Value = vbNullString Then
                Exit Sub
            Else
            '@板厚が選択された場合は入力ﾁｪｯｸ
                Call prvLock_Check()
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbBoardThickness_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbBoardThickness_CloseUp
    '機　能：ｸﾛｰｽﾞｱｯﾌﾟ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/12 (Wed) 17:13:40 S.Deguchi
    '更新日：2004/05/12 (Wed) 17:13:40
    '備　考：
    Private Sub cmbBoardThickness_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBoardThickness.CloseUp

        Try
            '@板厚が選択されていない場合は処理抜け
            If cmbBoardThickness.Value = vbNullString Then
                Exit Sub
            Else
            '@板厚が選択された場合は入力ﾁｪｯｸ
                Call prvLock_Check()
                
                '@次項目へｾｯﾄﾌｫｰｶｽ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbBoardThickness_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbBoardThickness_Validate
    '機　能：板厚_Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/29 (Thu) 17:21:17 S.Deguchi
    '更新日：2004/04/29 (Thu) 17:21:17
    '備　考：
    Private Sub cmbBoardThickness_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbBoardThickness.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@入力ﾁｪｯｸ
            Call prvLock_Check()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbBoardThickness_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRework_Change
    '機　能：ﾘﾜｰｸ回数変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/29 (Thu) 16:08:40 S.Deguchi
    '更新日：2004/04/29 (Thu) 16:08:40
    '備　考：
    Private Sub cmbRework_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRework.Change

        Try
            '@ﾘﾜｰｸ回数が選択されていない場合は処理抜け
            If cmbRework.Value = vbNullString Then
                Exit Sub
            Else
            '@ﾘﾜｰｸ回数が選択された場合は入力ﾁｪｯｸ
                Call prvLock_Check()
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRework_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRework_CloseUp
    '機　能：ｸﾛｰｽﾞｱｯﾌﾟ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/12 (Wed) 17:16:19 S.Deguchi
    '更新日：2004/05/12 (Wed) 17:16:19
    '備　考：
    Private Sub cmbRework_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRework.CloseUp

        Try
            '@ﾘﾜｰｸ回数が選択されていない場合は処理抜け
            If cmbRework.Value = vbNullString Then
                Exit Sub
            Else
            '@ﾘﾜｰｸ回数が選択された場合は入力ﾁｪｯｸ
                Call prvLock_Check()
                
                '@次項目へｾｯﾄﾌｫｰｶｽ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRework_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRework_Validate
    '機　能：ﾘﾜｰｸ回数_Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/29 (Thu) 17:22:01 S.Deguchi
    '更新日：2004/04/29 (Thu) 17:22:01
    '備　考：
    Private Sub cmbRework_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbRework.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@入力ﾁｪｯｸ
            Call prvLock_Check()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRework_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 13:23:53 S.Deguchi
    '更新日：2004/06/03 (Thu) 11:20:10 S.Deguchi
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltyppartaccept          As PartAcceptList       '受入要求構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@画面入力ﾁｪｯｸ
            lblnAns = prvblnInput_Check
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
            mstrEventName = "cmdRegist_Click"

            '@部品受入ﾃﾞｰﾀ格納
            With ltyppartaccept
                .strClassCode = mstrTaihiClassID                                '部品種別ｺｰﾄﾞ
                .strPartCode = mtyppartlist(mlngTaihiPartIndex).strPartCode     '部品ｺｰﾄﾞ
                .strSbID = pstrSBID                                             'ｼｽﾃﾑﾌﾞﾛｯｸID
                .strProductionLotId = txtInvLotID.Text                          '製造ﾛｯﾄID
                
                '@ｹｰｽ数の入力制御
                If Trim(txtCaseNum.Text) <> vbNullString Then   'ｹｰｽ数
                    .strCaseNum = txtCaseNum.Text
                Else
                    .strCaseNum = CMlngCFCaseNum
                End If
                
                .strNum = txtPartNum.Text                       '受入数
                .strDate = calDate.Value & _
                           CMstrBrank & _
                           medTime.Text & _
                           CMstrDefaultSecond                   '受入日時(YYYY/MM/DD hh:mm:ss)
                .strEmpID = txtUser.Text                        '作業者ID
                
                '@出荷ﾛｯﾄIDの入力制御
                .strShippingLotID = txtCFLotID.Text             '出荷ﾛｯﾄID
                
                '@CF板厚の入力制御
                .strBoardThickness = cmbBoardThickness.Value    'CF板厚
                
                '@ﾘﾜｰｸ数の入力制御
                .strReworkCount = cmbRework.Value               'ﾘﾜｰｸ数
                
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnInvPartaccept_Ins(CMstrinv_accept__Ver, ltyppartaccept)
            
            '@結果取得
            If lblnAns = True Then
                '@成功ﾒｯｾｰｼﾞ表示
                cmbPart.ValueCol = CMlngGetPartIDValueCol
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0036, cmbPart.Value, txtInvLotID.Text, txtPartNum.Text)
                '@pubVsfInfo_Disp("メッセージコード：C_I36%0$$部材受入を登録しました。部品[ %1 ] 製造ロット[ %2 ] 受入数[ %3 ]")
                Call pubVsfInfo_Disp(pstrDMsg)

                '@受入数,ｹｰｽ数の初期化
                txtPartNum.Text = vbNullString
                txtCaseNum.Text = vbNullString
                
                '@確定ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
            End If
            
            '@部品にｾｯﾄﾌｫｰｶｽ
            Call pubSetFocus(cmbPart)

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

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：prvfrmxxEN0210_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:03:16 S.Deguchi
    '更新日：2004/10/04 (Mon) 14:43:05 H.Wajima
    '備　考：2004/10/04 (Mon) 14:43:05 H.Wajima  ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/11/09 (Tue) 16:15:08 S.Deguchi 時刻のﾌｫｰﾏｯﾄ"HH:MM"をﾊﾟﾌﾞﾘｯｸ定数へ変更
    '　　　：2004/11/16 (Tue) 17:59:26 S.Deguchi ﾌｫｰﾑのｱｸﾃｨﾍﾞｲﾄﾌﾗｸﾞを初期化する処理追加
    Private Sub prvfrmxxEN0210_Init()
        
        Dim lctlControl         As Control          'ｺﾝﾄﾛｰﾙ名称取得用変数
        Dim lstrFormTitle       As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0210, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@部品種別以外Comboのｸﾘｱ
            cmbPart.Clear()
            cmbBoardThickness.Clear()
            cmbRework.Clear()
            
            '@部品種別以外Comboの非活性化処理
            cmbPart.Enabled = False                                 '部品
            cmbBoardThickness.Enabled = False                       '板厚
            cmbRework.Enabled = False                               'ﾘﾜｰｸ回数
            
            '@共通部分の制御
            Call prvfraCommPart_Init()
            calDate.Value = Format$(Now(), CPstrDateTimeYMD)        '受入日時(年月日)
            medTime.Text = Format$(Now(), CPstrTimeFormatHM)        '受入日時(時間)
            txtUser.Text = vbNullString                             '受入担当者ID
            lblEmpName.Text = vbNullString                          '受入担当者名
            txtInvLotID.Enabled = False                             '製造ﾛｯﾄID
            txtPartNum.Enabled = False                              '受入数
            txtCaseNum.Enabled = False                              'ｹｰｽ数
            calDate.Enabled = False                                 '受入日時(年月日)
            medTime.Enabled = False                                 '受入日時(時間)
            cmdNowDate.Enabled = False                              '現在日時取得ﾎﾞﾀﾝ
            With txtUser
                .Enabled = False                                    '受入担当者
                .ChrMaxByte = CPlngEmpIDLength                      '文字数
            End With
            
            txtCaseNum.BackColor = SystemColors.ControlLight        'ｹｰｽ数(ﾊﾞｯｸｶﾗｰ灰色)
                
            '@CF受入時追加入力Fraの制御
            Call prvfraCFInfo_Init()
            Call prvfraCFInfo_Set(False)
            
            '@退避情報の初期化
            mstrTaihiClassID = vbNullString
            mstrTaihiPartID = vbNullString
            
            '@ﾌｫｰﾑのｱｸﾃｨﾍﾞｲﾄﾌﾗｸﾞの初期化
            mblnFormActivateFlag = False

            '確定ﾎﾞﾀﾝを非活性化処理
            cmdRegist.Enabled = False
            
            '@ｶﾚﾝﾀﾞｰ設定
            With calDate
                .CalendarHeight = CPlngClHeight                     '高さ
                .CalendarWidth = CPlngClWidth                       '幅
                .DayFont = New Font(.DayFont.FontFamily, CPlngClFontSize, .DayFont.Style And FontStyle.Bold, .DayFont.Unit)                   'ﾌｫﾝﾄｻｲｽﾞ
                .TitleFont = New Font(.TitleFont.FontFamily, CPlngClTlFontSize, .TitleFont.Style And FontStyle.Bold, .TitleFont.Unit)         'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CSng(CPlngClGridFontSize-0.25), .GridFont.Style And FontStyle.Bold, .GridFont.Unit)'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
            End With

            '@ComboBox設定(外枠設定のみ)
            For Each lctlControl In Me.Controls
                If TypeOf lctlControl Is SEComboBoxEx.ComboBoxEx Then
                    With CType(lctlControl, SEComboBoxEx.ComboBoxEx)
                        '@初期化
                        .DirectInput = False                        '直接入力(Flase)
                        .DispCols = CMlngCmbDispCols                'ｸﾞﾘｯﾄﾞ表示列数
                        With lctlControl.Font
                            'ﾌｫﾝﾄｻｲｽﾞ
                            lctlControl.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style And FontStyle.Bold, .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        .RowHeight = CMlngCmbRowHeight              'ﾘｽﾄ行の高さ
                    End With
                End If
            Next

            'NSYS CF受入時追加入力グループボックス内のComboBox設定
            '     (.NETではグループボックスはコントロールの単位が異なるため、別途記述が必要)
            For Each lctlControl In Me.fraCFInfo.Controls
                If TypeOf lctlControl Is SEComboBoxEx.ComboBoxEx Then
                    With CType(lctlControl, SEComboBoxEx.ComboBoxEx)
                        '@初期化
                        .DirectInput = False                        '直接入力(Flase)
                        .DispCols = CMlngCmbDispCols                'ｸﾞﾘｯﾄﾞ表示列数
                        With lctlControl.Font
                            'ﾌｫﾝﾄｻｲｽﾞ
                            lctlControl.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style And FontStyle.Bold, .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        .RowHeight = CMlngCmbRowHeight              'ﾘｽﾄ行の高さ
                    End With
                End If
            Next

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0210_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfraCommPart_Init
    '機　能：共通部分のｺﾝﾄﾛｰﾙｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:07:47 S.Deguchi
    '更新日：2004/04/27 (Tue) 14:07:47
    '備　考：
    Private Sub prvfraCommPart_Init()

        Try

            '@入力欄ｸﾘｱ
            txtInvLotID.Text = vbNullString                         '製造ﾛｯﾄID
            txtPartNum.Text = vbNullString                          '受入数
            txtCaseNum.Text = vbNullString                          'ｹｰｽ数
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfraCommPart_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfraCFInfo_Init
    '機　能：CF受入時追加入力のｺﾝﾄﾛｰﾙｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:07:47 S.Deguchi
    '更新日：2004/04/27 (Tue) 14:07:47
    '備　考：
    Private Sub prvfraCFInfo_Init()

        Try

            '@入力･選択欄ｸﾘｱ
            txtCFLotID.Text = vbNullString                          '出荷ﾛｯﾄID
            cmbBoardThickness.Clear()                               '板厚Combo
            cmbRework.Clear()                                       'ﾘﾜｰｸ数Combo

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfraCFInfo_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfraCFInfo_Set
    '機　能：CF受入時追加入力のｺﾝﾄﾛｰﾙ制御
    '引　数：lblnEnable：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 12:40:51 S.Deguchi
    '更新日：2004/04/27 (Tue) 12:40:51
    '備　考：
    Private Sub prvfraCFInfo_Set(Optional ByVal lblnEnable As Boolean = False)

        Try

            '@ｺﾝﾄﾛｰﾙ設定
            txtCFLotID.Enabled = lblnEnable                         '出荷ﾛｯﾄID

            '@ﾊﾞｯｸｶﾗｰ制御
            If lblnEnable = True Then
                '@Trueの場合：ﾊﾞｯｸｶﾗｰ白
                txtCFLotID.BackColor = SystemColors.Window          '出荷ﾛｯﾄID
                cmbBoardThickness.BackColor = SystemColors.Window   '板厚
                cmbRework.BackColor = SystemColors.Window           'ﾘﾜｰｸ回数
            Else
                '@Flaseの場合：ﾊﾞｯｸｶﾗｰｸﾞﾚｰ
                txtCFLotID.BackColor = SystemColors.ControlLight         '出荷ﾛｯﾄID
                cmbBoardThickness.BackColor = SystemColors.ControlLight  '板厚
                cmbRework.BackColor = SystemColors.ControlLight          'ﾘﾜｰｸ回数
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfraCFInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbClassName_Disp
    '機　能：部品種別情報表示
    '引　数：ltypVenderlist：部品種別情報格納ﾃﾞｰﾀ
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 10:36:56 S.Deguchi
    '更新日：2004/11/16 (Tue) 14:18:02 N.Kojima
    '備　考：
    '　　　：2004/11/16 (Tue) 14:18:02 N.Kojima　部品種別が1件の時は、部品ｺﾝﾎﾞを有効に
    '　　　：2004/11/16 (Tue) 17:55:00 S.Deguchi 部品種別が1件の場合の処理をForm_Activateへ移動(Validate処理を使用)
    Private Sub prvCmbClassName_Disp(ByRef ltypVenderlist As VenderList)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbPartClass
                '@部品種別情報初期化
                .Clear()
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbDispCols2                                   '値取得列
                With .Font
                    cmbPartClass.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style And FontStyle.Bold, .Unit, .GdiCharSet, .GdiVerticalFont)         'ﾌｫﾝﾄｻｲｽﾞ
                    cmbPartClass.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style And FontStyle.Bold, .Unit, .GdiCharSet, .GdiVerticalFont) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                End With
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbDispColIndex) = TextAlignEnum.LeftCenter  '左寄中央揃え
                .BackColor = SystemColors.Window                                'NSYS 背景色
                
                '@部品種別情報ｾｯﾄ
                For llngCnt = 0 To ltypVenderlist.lngVenderClassListCnt - 1
                    .AddItem(ltypVenderlist.typVenderClassList(llngCnt).strVenderClassName & vbTab & _
                             ltypVenderlist.typVenderClassList(llngCnt).strVenderClassId)                 '部品名&部品ID
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbClassName_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbPartName_Disp
    '機　能：部品情報表示
    '引　数：mtypClassList() ：部品情報格納ﾃﾞｰﾀ
    '　　　：llngpartcnt：取得情報ﾃﾞｰﾀ数
    '戻り値：なし
    '作成日：2004/04/28 (Wed) 15:20:08 S.Deguchi
    '更新日：2004/04/28 (Wed) 15:20:08
    '備　考：
    Private Sub prvCmbPartName_Disp(ByRef mtyppartlist As List(Of PartClassList), ByVal llngpartcnt As Integer)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try
            
            With cmbPart
                '@部品情報初期化
                .Clear()
                .DispCols = CMlngCmbDispCols2                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol                                    '値取得列
                With .Font
                    cmbPart.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style And FontStyle.Bold, .Unit, .GdiCharSet, .GdiVerticalFont)         'ﾌｫﾝﾄｻｲｽﾞ
                    cmbPart.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style And FontStyle.Bold, .Unit, .GdiCharSet, .GdiVerticalFont) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                End With
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbDispColIndex) = TextAlignEnum.LeftCenter  '左寄中央揃え
                .ColAlignment(CMlngCmbDispColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
                .BackColor = SystemColors.Window                                'NSYS 背景色
                
                '@部品情報ｾｯﾄ
                For llngCnt = 0 To llngpartcnt - 1
                    .AddItem(mtyppartlist(llngCnt).strPartCode & _
                             vbTab & _
                             mtyppartlist(llngCnt).strPartName & _
                             vbTab & _
                             mtyppartlist(llngCnt).strThicknessClass & _
                             vbTab & _
                             mtyppartlist(llngCnt).strPartCode & CPstrSpace & mtyppartlist(llngCnt).strPartName) '部品ID&部品名&Index&板厚区分
                Next llngCnt
                
                .GetCol = CMlngCmbGetCol                                        '値表示列
                
                '@部品情報が１件の場合
                If .ListCount = 1 Then
                    '@１件目表示
                    .ListIndex = 0
                End If
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbPartName_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbThicknessName_Disp
    '機　能：板厚情報表示
    '引　数：mtypThicknessList() ：板厚情報格納ﾃﾞｰﾀ
    '　　　：lstrThicknessClass：取得板厚区分
    '　　　：mlngThicknessCnt：取得板厚区分ﾘｽﾄ数
    '戻り値：なし
    '作成日：2004/04/28 (Wed) 16:19:59 S.Deguchi
    '更新日：2004/04/28 (Wed) 16:19:59
    '備　考：
    Private Sub prvCmbThicknessName_Disp(ByRef mtypThicknessClassList As List(Of ThicknessClassList), _
                                         ByVal lstrThicknessClass As String, _
                                         ByVal mlngThicknessCnt As Integer)

        Dim llngCnt1     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCnt2     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbBoardThickness
                '@板厚情報初期化
                .Clear
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol                                    '値取得列
                With .Font
                    cmbBoardThickness.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style And FontStyle.Bold, .Unit, .GdiCharSet, .GdiVerticalFont)         'ﾌｫﾝﾄｻｲｽﾞ
                    cmbBoardThickness.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style And FontStyle.Bold, .Unit, .GdiCharSet, .GdiVerticalFont) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                End With
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbDispColIndex) = TextAlignEnum.LeftCenter  '左中央揃え
                .BackColor = SystemColors.Window                                'NSYS 背景色
                
                '@板厚情報ｾｯﾄ
                For llngCnt1 = 0 To mlngThicknessCnt - 1
                    If mtypThicknessClassList(llngCnt1).strThicknessClass = lstrThicknessClass Then
                        For llngCnt2 = 0 To mtypThicknessClassList(llngCnt1).strThicknessCount - 1
                            .AddItem(mtypThicknessClassList(llngCnt1).typThicknessList(llngCnt2).strThicknessCode & _
                             vbTab & _
                             llngCnt2)                                            '板厚&Index
                        Next llngCnt2
                        '@板厚情報が１件の場合
                        If .ListCount = 1 Then
                            '@１件目表示
                            .ListIndex = 0
                        End If
                    End If
                Next llngCnt1
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbThicknessName_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbReworkName_Disp
    '機　能：ﾘﾜｰｸ回数情報表示
    '引　数：mtypClassList() ：取得情報格納ﾃﾞｰﾀ
    '　　　：llngIndex：取得ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/04/29 (Thu) 09:06:41 S.Deguchi
    '更新日：2004/04/29 (Thu) 09:06:41
    '備　考：
    Private Sub prvCmbReworkName_Disp(ByRef mtyppartlist As List(Of PartClassList), ByVal llngIndex As Integer)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngRCnt    As Integer      'ｶｳﾝﾄ

        Try

            With cmbRework
                '@ﾘﾜｰｸ回数情報初期化
                .Clear
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol                                    '値取得列
                With .Font
                    cmbRework.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style And FontStyle.Bold, .Unit, .GdiCharSet, .GdiVerticalFont)         'ﾌｫﾝﾄｻｲｽﾞ
                    cmbRework.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style And FontStyle.Bold, .Unit, .GdiCharSet, .GdiVerticalFont) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                End With
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbDispColIndex) = TextAlignEnum.RightCenter '右中央揃え
                
                '@ﾘﾜｰｸ回数が数字ではない場合
                If IsNumeric(mtyppartlist(llngIndex).strRegenerationCount) = False Then
                    llngRCnt = 0
                Else
                    llngRCnt = mtyppartlist(llngIndex).strRegenerationCount
                End If
                
                '@部品情報ｾｯﾄ
                For llngCnt = 0 To llngRCnt
                    .AddItem(llngCnt)                                            'Index(回数)
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbReworkName_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Check
    '機　能：確定時の入力ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2004/04/27 (Tue) 13:27:56 S.Deguchi
    '更新日：2004/04/27 (Tue) 13:27:56
    '備　考：
    Private Function prvblnInput_Check() As Boolean

        Try

            '@設定初期化
            prvblnInput_Check = False

            '@部品種別ﾁｪｯｸ
            If cmbPartClass.Value = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0047)
                '@"部品種別が選択されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@部品種別選択欄にｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbPartClass)
                Exit Function
            End If
            
            '@部品ﾁｪｯｸ
            If cmbPart.Value = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0048)
                '@"部品が選択されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@部品選択欄にｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbPart)
                Exit Function
            End If
            
            '@製造ﾛｯﾄIDﾁｪｯｸ
            If txtInvLotID.Text = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0049)
                '@"製造ロットIDが入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@製造ﾛｯﾄID入力欄にｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(txtInvLotID)
                Exit Function
            End If
            
            '@受入数ﾁｪｯｸ
            If txtPartNum.Text = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0050)
                '@"受入数が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@受入数入力欄にｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(txtPartNum)
                Exit Function
            Else
                If CLng(txtPartNum.Text) < CMlngCheckNum Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0051)
                    '@"受入数の設定が正しくありません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@受入数入力欄にｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(txtPartNum)
                    Exit Function
                End If
            End If
            
            '@ｹｰｽ数ﾁｪｯｸ
            If txtPartNum.Text = vbNullString Then
                If txtCaseNum.Text = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0052)
                    '@"ケース数が入力されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@受入数入力欄にｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(txtCaseNum)
                    Exit Function
                Else
                    If CLng(txtCaseNum.Text) = CMlngCheckNum Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0053)
                        '@"ケース数の設定が正しくありません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@受入数入力欄にｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(txtCaseNum)
                        Exit Function
                    End If
                End If
            End If

            '@受入数とｹｰｽ数の大小ﾁｪｯｸ
            If txtPartNum.Enabled = True And txtCaseNum.Enabled = True Then
                If txtPartNum.Text <> vbNullString And txtCaseNum.Text <> vbNullString Then
                    If CLng(txtPartNum.Text) < CLng(txtCaseNum.Text) Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0054)
                        '@"受入数にはケース数より大きな値を入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@受入数入力欄にｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(txtCaseNum)
                        Exit Function
                    End If
                End If
            End If

            '@受入日時ﾁｪｯｸ
            If IsDate(calDate.Value) = False Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0046)
                '@"受入日時の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@受入年月日入力欄にｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(calDate)
                Exit Function
            End If
            If IsDate(medTime.Text) = False Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0046)
                '@"受入日時の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@受入時間入力欄にｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(medTime)
                Exit Function
            End If
            
            '@受入担当者ﾁｪｯｸ
            If txtUser.Text = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0055)
                '@"受入担当者が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@受入担当者入力欄にｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(txtUser)
                Exit Function
            End If
            
            '@出荷ﾛｯﾄIDﾁｪｯｸ
            If txtCFLotID.Enabled = True Then
                If txtCFLotID.Text = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0056)
                    '@"出荷ロットIDが入力されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@出荷ﾛｯﾄID入力欄にｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(txtCFLotID)
                    Exit Function
                End If
            End If

            '@板厚ﾁｪｯｸ
            If cmbBoardThickness.Enabled = True Then
                If cmbBoardThickness.Value = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0057)
                    '@"板厚が選択されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@板厚選択欄にｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbBoardThickness)
                    Exit Function
                End If
            End If
            
            '@ﾘﾜｰｸ回数ﾁｪｯｸ
            If cmbRework.Enabled = True Then
                If cmbRework.Value = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0058)
                    '@"リワーク回数が選択されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ﾘﾜｰｸ回数欄にｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbRework)
                    Exit Function
                End If
            End If
            
            '@入力ﾁｪｯｸでOKの場合
            prvblnInput_Check = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInput_Check"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvLock_Check
    '機　能：ｺﾝﾄﾛｰﾙ使用可否ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:03:26 M.Miura
    '更新日：2004/06/02 (Wed) 09:03:26
    '備　考：
    Private Sub prvLock_Check()
        
        Try

            '@部品種別ﾁｪｯｸ
            If cmbPartClass.Value = vbNullString Then
                '@ﾛｯｸ
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            '@部品ﾁｪｯｸ
            If cmbPart.Value = vbNullString Then
                '@ﾛｯｸ
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            '@製造ﾛｯﾄIDﾁｪｯｸ
            If txtInvLotID.Text = vbNullString Then
                '@ﾛｯｸ
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            '@受入数ﾁｪｯｸ
            If txtPartNum.Text = vbNullString Then
                '@ﾛｯｸ
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            '@ｹｰｽ数ﾁｪｯｸ
            If txtPartNum.Text = vbNullString Then
                If txtCaseNum.Text = vbNullString Then
                    '@ﾛｯｸ
                    cmdRegist.Enabled = False
                    Exit Sub
                Else
                    If CLng(txtCaseNum.Text) = CMlngCheckNum Then
                        '@ﾛｯｸ
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
            End If
            
            '@受入日時ﾁｪｯｸ
            If pubblnYearRange_Chk(calDate.Value) = False Then
                '@ﾛｯｸ
                cmdRegist.Enabled = False
                Exit Sub
            End If
            If IsDate(medTime.Text) = False Then
                '@ﾛｯｸ
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            '@受入担当者ﾁｪｯｸ
            If txtUser.Text = vbNullString Then
                '@ﾛｯｸ
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            '@出荷ﾛｯﾄIDﾁｪｯｸ
            If txtCFLotID.Enabled = True Then
                If txtCFLotID.Text = vbNullString Then
                    '@ﾛｯｸ
                    cmdRegist.Enabled = False
                    Exit Sub
                End If
            End If

            '@板厚ﾁｪｯｸ
            If cmbBoardThickness.Enabled = True Then
                If cmbBoardThickness.Value = vbNullString Then
                    '@ﾛｯｸ
                    cmdRegist.Enabled = False
                    Exit Sub
                End If
            End If
            
            '@ﾘﾜｰｸ回数ﾁｪｯｸ
            If cmbRework.Enabled = True Then
                If cmbRework.Value = vbNullString Then
                    '@ﾛｯｸ
                    cmdRegist.Enabled = False
                    Exit Sub
                End If
            End If
            
            '@ﾛｯｸ解除
            cmdRegist.Enabled = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLock_Check"
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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraCFInfo.Paint, fraCommPart.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

    '関数名：textbox_Enter
    '機　能：ハイライト処理用 フォーカス取得イベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles medTime.Enter
        'NSYS フォーカスインでハイライト処理 開始
        sender.ScrollToCaret()
        If (sender.MouseButtons And MouseButtons.Left) = MouseButtons.Left Then
            sender.Tag("OnHighlight") = True
        Else
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：textbox_Leave
    '機　能：ハイライト処理用 フォーカス喪失イベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles medTime.Leave
        'NSYS マウス選択でのハイライトをキャンセルする
        sender.Tag("OnHighlight") = False
    End Sub

    '関数名：textbox_KeyUp
    '機　能：ハイライト処理用 キーアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles medTime.KeyUp
        'NSYS Tabキー押下の場合
        If e.KeyCode = Keys.Tab Then
            'NSYS マウス選択でのハイライトをキャンセルする
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：textbox_MouseDown
    '機　能：ハイライト処理用 マウスダウンイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medTime.MouseDown
        'NSYS MouseDown時のカーソル位置を保持
        sender.Tag("MouseDownStart") = sender.SelectionStart
    End Sub

    '関数名：textbox_MouseUp
    '機　能：ハイライト処理用 マウスアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medTime.MouseUp
        Dim curpos As Integer   'NSYS ｶｰｿﾙ位置

        '@ﾊｲﾗｲﾄするになっている場合
        If CBool(sender.Tag("OnHighlight")) = True Then
            ''@ｶｰｿﾙ位置までﾊｲﾗｲﾄ表示
            curpos = sender.SelectionStart
            sender.SelectionStart = 0 
            If curpos < CInt(sender.Tag("MouseDownStart")) Then
                'NSYS 左ドラッグ時
                sender.SelectionLength = curpos
            Else
                sender.SelectionLength = curpos + sender.SelectedText.Length
            End If
            sender.ScrollToCaret()
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：cursor_Enter	
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。	
    '作成日：2019/07/02 NSYS	
    '更新日：	
    '備　考：Handlesは画面で入力できるすべての項目が対象	
    Private Sub cursor_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPartClass.Enter, cmbPart.Enter, txtInvLotID.Enter, _
        txtPartNum.Enter, txtCaseNum.Enter, calDate.Enter, medTime.Enter, cmdNowDate.Enter, txtUser.Enter, txtCFLotID.Enter, cmbBoardThickness.Enter,  _
        cmbRework.Enter, cmdRegist.Enter, cmdClose.Enter

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

End Class
