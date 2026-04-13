'ﾌｧｲﾙ名：xxEN01T0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾌｫﾄF/Bﾊﾟﾗﾒｰﾀ変更
'作成日：2004/10/22 (Fri) 18:47:50 N.Kasai
'更新日：2006/06/20 (Tue) 13:52:19 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01T0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01T0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01T0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01T0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01T0)
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
    '======================================Public===========================================
    '======================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    'Private Const CMstrLocalVersion                     As String = "02.01"
    Private Const CMstrLocalVersion                     As String = "02.02"

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_wplist__Ver                  As String = "05.01"             '装置一覧取得
    Private Const CMstreq__photofbeqprmlistVer          As String = "02.00"             'ﾌｫﾄF/B装置ﾊﾟﾗﾒｰﾀ取得
    Private Const CMstreq__photofbeqparameterchgVer     As String = "02.00"             'ﾌｫﾄF/B装置ﾊﾟﾗﾒｰﾀ変更
    Private Const CMstrmas_definelistVer                As String = "01.00"             'DEFINE情報取得

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN01T0      'ﾛｰｶﾙﾒﾆｭｰKey

    '@vsfUnCarryListの定数宣言（ｶﾗﾑ）
    Private Const CMlngvsfListColNo                     As Integer = 0                  '№
    Private Const CMlngvsfListColItemName               As Integer = 1                  '装置ﾊﾟﾗﾒｰﾀ
    Private Const CMlngvsfListColItemValue              As Integer = 2                  '現在値
    Private Const CMlngvsfListColNewValue               As Integer = 3                  '変更値
    Private Const CMlngvsfListColLowerValue             As Integer = 4                  '下限値
    Private Const CMlngvsfListColUpperValue             As Integer = 5                  '上限値
    Private Const CMlngvsfListColEditTime               As Integer = 6                  '最終更新日時
    Private Const CMlngvsfListColEditEmp                As Integer = 7                  '最終更新者
    Private Const CMlngvsfListColDigit                  As Integer = 8                  '小数点以下

    '@vsfUnCarryListの定数宣言（表示幅）
    Private Const CMlngvsfListColWNo                    As Integer = 30                 '№
    Private Const CMlngvsfListColwItemName              As Integer = 200                '装置ﾊﾟﾗﾒｰﾀ
    Private Const CMlngvsfListColwItemValue             As Integer = 133                '現在値
    Private Const CMlngvsfListColwNewValue              As Integer = 133                '変更値
    Private Const CMlngvsfListColwLowerValue            As Integer = 133                '下限値
    Private Const CMlngvsfListColwUpperValue            As Integer = 133                '上限値
    Private Const CMlngvsfListColwEditTime              As Integer = 167                '最終更新日時
    Private Const CMlngvsfListColwEditEmp               As Integer = 133                '最終更新者
    Private Const CMlngvsfListColwDigit                 As Integer = 30                 '小数点以下

    '@vsfUnCarryListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrvsfListColTNo                    As String = ""
    Private Const CMstrvsfListColtItemName              As String = "装置パラメータ"
    Private Const CMstrvsfListColtItemValue             As String = "現在値"
    Private Const CMstrvsfListColtNewValue              As String = "変更値"
    Private Const CMstrvsfListColtLowerValue            As String = "下限値"
    Private Const CMstrvsfListColtUpperValue            As String = "上限値"
    Private Const CMstrvsfListColtEditTime              As String = "最終更新日時"
    Private Const CMstrvsfListColtEditEmp               As String = "最終更新者"
    Private Const CMstrvsfListColtDigit                 As String = "小数点"

    '@ｸﾞﾘｯﾄﾞ制御
    Private Const CMlngvsfListCols                      As Integer = 9                  'ｶﾗﾑ数
    Private Const CMlngvsfTRow                          As Integer = 0                  'ﾀｲﾄﾙ行
    Private Const CMlngVsfHFontSize                     As Integer = 12                 'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                       As Integer = 27                 '行の高さ(ﾍｯﾀﾞｰ)
    'Private Const CMlngvsfBHeight                       As Integer = 43                 '行の高さ(ﾎﾞﾃﾞｨ)
    Private Const CMlngvsfBHeight                       As Integer = 33                 '行の高さ(ﾎﾞﾃﾞｨ)
    Private Const CMlngInputNDataMaxByte                As Integer = 10                 '文字入力の最大ﾊﾞｲﾄ数(数値）

    '@ｽｸﾛｰﾙ制御
    Private Const CMlngSideScrollOnFlag                 As Integer = 1                  '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag                As Integer = 2                  '横ｽｸﾛｰﾙ非活性化
    Private Const CMlngUpDownindex                      As Integer = 0                  '縦ｽｸﾛｰﾙﾗﾍﾞﾙｲﾝﾃﾞｯｸｽ
    Private Const CMlngLeftRightindex                   As Integer = 1                  '横ｽｸﾛｰﾙﾗﾍﾞﾙｲﾝﾃﾞｯｸｽ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 15.75              'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 15.75              'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols1                     As Integer = 1                  'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbRowHeight                     As Integer = 43                 'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                      As Integer = 0                  '名称列番=0
    Private Const CMlngCmbGridCol1                      As Integer = 1                  '名称列番=1

    '@DEFINE情報
    Private Const CMstrTableName                        As String = "FB_EQ_PARAMETER"
    Private Const CMstrColumnName                       As String = "DATA_KIND"

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypChgSort                                 As ChgSort                      'ｿｰﾄ保持用
    Private mlngSideScrollFlag                          As Integer                      '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
    Private mlngcmbWpIndex                              As Integer                      'ｺﾝﾎﾞ内容を退避（ﾌｫﾄ号機）
    Private mlngcmbDetaKindIndex                        As Integer                      'ｺﾝﾎﾞ内容を退避（ﾃﾞｰﾀ種別）
    Private mblnFirstLoadFlag                           As Boolean                      '初回ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ（True:初回、False:初回以降）
    Private buttonProcessing                            As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                      'NSYS WindowCloseフラグ

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
        pubVsfMouseWheelManager_Set(vsfFbParameterList, cmdUP, cmdDown, cmdLeft, cmdRight)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:30:21 N.Kasai
    '更新日：2006/02/23 (Thu) 13:30:21
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns                     As Boolean              '汎用戻り値
        Dim lstrEventName               As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngWpListCnt               As Integer              '装置一覧件数
        Dim ltypMasDefineReq            As MasDefineReq         'DEFINE情報（要求）
        Dim ltypMasDefineAns            As MasDefineAns         'DEFINE情報（応答）
        
        Try
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            '@起動区分：Null(単体起動)
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01T0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(False, New FormClosingEventArgs(New CloseReason,  False))
                Exit Sub
            End If
            
            '@構造体の初期化（ｿｰﾄ用）
            With mtypChgSort
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
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｺﾝﾎﾞ内容を初期化
            mlngcmbWpIndex = -1
            mlngcmbDetaKindIndex = -1
            
            '@画面初期化
            Call prvMainForm_Init()
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "Form_Load"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@装置一覧取得結果【ﾚﾁｸﾙ装置】
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, llngWpListCnt, pstrSBID, CPstrCD2J)
            
            '@戻り値判定
            If lblnAns = True Then
                '@正常の場合
                
                '@配列の件数ﾁｪｯｸ
                If llngWpListCnt > 0 Then
                    '@ﾌｫﾄ号機ｺﾝﾎﾞｾｯﾄ
                    Call prvcmbWp_Disp(llngWpListCnt)
                End If
            Else
                '@異常の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                Exit Sub
            End If
            
            '@DEFINE情報取得
            With ltypMasDefineReq
                .strMsgVer = CMstrmas_definelistVer 'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strTableName = CMstrTableName      'ﾃｰﾌﾞﾙ名
                .strColumnName = CMstrColumnName    'ｶﾗﾑ名
            End With
            
            '@MSG通信【DEFINE情報取得】
            lblnAns = pubblnMasDfineList_Sel(ltypMasDefineReq, ltypMasDefineAns)
            
            '@戻り値判定
            If lblnAns = True Then
                '配列の件数ﾁｪｯｸ
                If ltypMasDefineAns.lngMasDefineListCnt > 0 Then
                    '@ﾌｫﾄ号機ｺﾝﾎﾞｾｯﾄ
                    Call prvcmbDataKind_Disp(ltypMasDefineAns)
                End If
            Else
                '@異常の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
                                                       
            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True
            
            '@初回起動判定ﾌﾗｸﾞ
            mblnFirstLoadFlag = True
            
            Exit Sub

        Catch ex As Exception
            
            '@異常の場合
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(Me.Name, lstrEventName)
            
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
    '機　能：ﾛｰﾄﾞ後処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/28 (Tue) 15:05:34 N.Kasai
    '更新日：2006/02/28 (Tue) 15:05:34
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@初回起動
            If mblnFirstLoadFlag = True Then
            
                '@ﾌｫﾄ号機、ﾃﾞｰﾀ種別ｺﾝﾎﾞﾃﾞｰﾀが1件の場合初期表示して起動する。
                '@但し、実ﾃﾞｰﾀとしてはあり得ません。
            
                '@最新ﾎﾞﾀﾝ制御
                Call prvcmdLotSearch_Proc()
                
                '@ﾃﾞｰﾀ件数が存在する場合
                If vsfFbParameterList.Rows.Count > 1 Then
                    '@ｸﾞﾘｯﾄﾞが使用可能の場合
                    If vsfFbParameterList.Enabled = True Then
                        '@次項目にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfFbParameterList)
                    Else
                        '@終了ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                Else
                    '@最新取得ﾎﾞﾀﾝが使用可能の場合
                    If cmdLotSearch.Enabled = True Then
                        '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdLotSearch)
                    End If
                End If
            End If
            
            '@初回判定ﾌﾗｸﾞOFF
            mblnFirstLoadFlag = False

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

    '関数名：cmbWP_Change
    '機　能：装置ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/28 (Tue) 15:31:24 N.Kasai
    '更新日：2006/02/28 (Tue) 15:31:24
    '備　考：
    Private Sub cmbWp_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.Change

        Try

                '@ｸﾞﾘｯﾄﾞの初期化
                vsfFbParameterList.Rows.Count = 1
                
                '@ﾗﾍﾞﾙ初期化
                lblNowDate.Text = vbNullString      '情報取得日時
                lblLotCnt.Text = vbNullString       '該当件数
                
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用禁止
                cmdUP.Enabled = False               '前ﾍﾟｰｼﾞ
                cmdDown.Enabled = False             '次ﾍﾟｰｼﾞ
                cmdLeft.Enabled = False             '左ﾎﾞﾀﾝ
                cmdRight.Enabled = False            '右ﾎﾞﾀﾝ
                cmdProcEnd.Enabled = False          '確定ﾎﾞﾀﾝ
                
                '@ｺﾝﾎﾞ内容を初期化
                mlngcmbWpIndex = -1
                
                mlngcmbDetaKindIndex = -1
                cmbDataKind.ListIndex = -1
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWP_CloseUp
    '機　能：装置ｺﾝﾎﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/28 (Tue) 15:21:19 N.Kasai
    '更新日：2006/02/28 (Tue) 15:21:19
    '備　考：
    Private Sub cmbWp_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.CloseUp

        Try
            '@ｺﾝﾎﾞが選択済みの場合
            If cmbWp.ListIndex > -1 Then
                '@Validate処理
                RemoveHandler cmbWp.Validating, AddressOf cmbWp_Validate
                Call cmbWp_Validate(cmbWp, New CancelEventArgs(True))
                AddHandler cmbWp.Validating, AddressOf cmbWp_Validate
            Else
                '@最新取得ﾎﾞﾀﾝ
                cmdLotSearch.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWP_Validate
    '機　能：装置ｺﾝﾎﾞValidate処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/28 (Tue) 15:21:47 N.Kasai
    '更新日：2006/02/28 (Tue) 15:21:47
    '備　考：
    Private Sub cmbWp_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWp.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｺﾝﾎﾞ内容に変更がある場合
            If mlngcmbWpIndex = cmbWp.ListIndex Then
                '@ﾃﾞｰﾀ種別にﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = cmbWp.Name Then
                    Call pubSetFocus(cmbDataKind)
                End If
                Exit Sub
            End If
            
            '@ｺﾝﾎﾞ内容を変更
            mlngcmbWpIndex = cmbWp.ListIndex
            
            '@最新ﾎﾞﾀﾝ制御
            Call prvcmdLotSearch_Proc()
            
            
            '@ﾃﾞｰﾀ件数が存在する場合
            If vsfFbParameterList.Rows.Count > 1 Then
                '@ｸﾞﾘｯﾄﾞが使用可能の場合
                If vsfFbParameterList.Enabled = True Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfFbParameterList)
                Else
                    '@終了ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbDataKind)
                End If
            Else
                '@ﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = cmbWp.Name Then
                    Call pubSetFocus(cmbDataKind)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDataKind_Change
    '機　能：ﾃﾞｰﾀ種別ｺﾝﾎﾞ変更
    '引　数：なし
    '戻り値：なし
    '作成日：2007/05/30 (Wed) 16:37:50 N.Kasai
    '更新日：2007/05/30 (Wed) 16:37:50
    '備　考：
    Private Sub cmbDataKind_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDataKind.Change


        Try
            
                '@ｸﾞﾘｯﾄﾞの初期化
                vsfFbParameterList.Rows.Count = 1
                
                '@ﾗﾍﾞﾙ初期化
                lblNowDate.Text = vbNullString      '情報取得日時
                lblLotCnt.Text = vbNullString       '該当件数
                
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用禁止
                cmdUP.Enabled = False               '前ﾍﾟｰｼﾞ
                cmdDown.Enabled = False             '次ﾍﾟｰｼﾞ
                cmdLeft.Enabled = False             '左ﾎﾞﾀﾝ
                cmdRight.Enabled = False            '右ﾎﾞﾀﾝ
                cmdProcEnd.Enabled = False          '確定ﾎﾞﾀﾝ
                
                '@ｺﾝﾎﾞ内容を初期化
                mlngcmbDetaKindIndex = -1
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbDataKind_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDataKind_CloseUp
    '機　能：ﾃﾞｰﾀ種別ｺﾝﾎﾞ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2007/05/30 (Wed) 16:38:13 N.Kasai
    '更新日：2007/05/30 (Wed) 16:38:13
    '備　考：
    Private Sub cmbDataKind_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDataKind.CloseUp

        Try
            '@ｺﾝﾎﾞが選択済みの場合
            If cmbDataKind.ListIndex > -1 Then
                '@Validate処理
                RemoveHandler cmbDataKind.Validating, AddressOf cmbDataKind_Validate
                Call cmbDataKind_Validate(cmbDataKind, New CancelEventArgs(True))
                AddHandler cmbDataKind.Validating, AddressOf cmbDataKind_Validate
            Else
                '@最新ﾎﾞﾀﾝ使用不可
                cmdLotSearch.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbDataKind_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDataKind_Validate
    '機　能：ﾃﾞｰﾀ種別ｺﾝﾎﾞ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/05/30 (Wed) 16:38:32 N.Kasai
    '更新日：2007/05/30 (Wed) 16:38:32
    '備　考：
    Private Sub cmbDataKind_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbDataKind.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｺﾝﾎﾞ内容に変更がある場合
            If mlngcmbDetaKindIndex = cmbDataKind.ListIndex Then
            
                '@ﾃﾞｰﾀ件数が存在する場合
                If vsfFbParameterList.Rows.Count > 1 Then
                    '@ｸﾞﾘｯﾄﾞが使用可能の場合
                    If vsfFbParameterList.Enabled = True Then
                        '@次項目にﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = cmbDataKind.Name Then
                            Call pubSetFocus(vsfFbParameterList)
                        End If
                    Else
                        '@終了ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = cmbDataKind.Name Then
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                Else
                    '@最新取得ﾎﾞﾀﾝが使用可能の場合
                    If cmdLotSearch.Enabled = True Then
                        '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = cmbDataKind.Name Then
                            Call pubSetFocus(cmdLotSearch)
                        End If
                    Else
                        '@終了ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = cmbDataKind.Name Then
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If
            
                Exit Sub
            End If
            
            '@ｺﾝﾎﾞ内容を変更
            mlngcmbDetaKindIndex = cmbDataKind.ListIndex
            
            '@最新ﾎﾞﾀﾝ制御
            Call prvcmdLotSearch_Proc()
            
            '@ﾃﾞｰﾀ件数が存在する場合
            If vsfFbParameterList.Rows.Count > 1 Then
                '@ｸﾞﾘｯﾄﾞが使用可能の場合
                If vsfFbParameterList.Enabled = True Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                     Call pubSetFocus(vsfFbParameterList)
                Else
                    '@終了ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            Else
                '@最新取得ﾎﾞﾀﾝが使用可能の場合
                If cmdLotSearch.Enabled = True Then
                    '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbDataKind.Name Then
                        Call pubSetFocus(cmdLotSearch)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:31:41 N.Kasai
    '更新日：2006/02/23 (Thu) 13:31:41
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim llngRet As Integer
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
            llngRet = publngEnd_Proc(CPstrKeyEN01T0, ltypCommonInfo)

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

    '関数名：cmdProcEnd_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/28 (Tue) 16:46:43 N.Kasai
    '更新日：2007/05/22 (Tue) 09:33:13 N.Kasai
    '備　考：
    '　　　：2006/06/20 (Tue) 10:06:04 N.Kojima     送信構造体への格納の際に四捨五入し、表示されている値と同じﾌｫｰﾏｯﾄで格納するように修正。(R3-4指摘)
    '　　　：2007/05/22 (Tue) 09:33:13 N.Kasai      ﾃﾞｰﾀ種別追加（№01935）
    Private Sub cmdProcEnd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdProcEnd.Click
        
        Dim lblnAns                     As Boolean                  '登録戻り値(True/False)
        Dim llngCnt                     As Integer                  'ｶｳﾝﾄ
        Dim llngDataCnt                 As Integer                  '登録ﾃﾞｰﾀｶｳﾝﾄ
        Dim lstrFormName                As String                   'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName               As String                   'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim ltypPhotoFbEqPrmchgReq      As PhotoFbEqPrmchgReq       'ﾌｫﾄF/Bﾊﾟﾗﾒｰﾀ変更要求格納構造体
        Dim lstrDoubleFormatString      As String
        
        'NSYS クリック処理中は処理を抜ける
        If Me.ActiveControl Is sender Then
            If Me.buttonProcessing = True Then
                Return
            End If
            Me.buttonProcessing = True
        End If

        '@入力値のﾁｪｯｸ
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
        lstrFormName = Me.Name
        lstrEventName = "cmdProcEnd_Click"
        Call pubResponseStart(lstrFormName, lstrEventName)
        
        '@更新内容の設定
        With ltypPhotoFbEqPrmchgReq
            '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
            .strMsgVer = CMstreq__photofbeqparameterchgVer
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            .strSbID = pstrSBID
            '@装置ID
            cmbWp.ValueCol = CMlngCmbGridCol1
            .strWpID = cmbWp.Value
            '@作業者ID
            .strEmpID = pstrUserID
            
    '@↓2007/05/22 (Tue) 09:33:03 N.Kasai **************************************************
            '@ﾃﾞｰﾀ種別
            cmbDataKind.ValueCol = CMlngCmbGridCol1
            .strDataKind = cmbDataKind.Value
    '@↑2007/05/22 (Tue) 09:33:03 N.Kasai **************************************************
            
            'NSYS リストを初期化
            If IsNothing(.typFbItemList) Then
                .typFbItemList = New List(Of FbItemList)
            Else
                .typFbItemList.Clear()
            End If

            '@ﾊﾟﾗﾒｰﾀﾘｽﾄ
            For llngCnt = 1 To vsfFbParameterList.Rows.Count - 1
                '@変更値が入力済みのﾃﾞｰﾀを対象
                If vsfFbParameterList.GetData(llngCnt, CMlngvsfListColNewValue) <> vbNullString Then
                    '@配列の再定義
                    Dim typFbItemListTmp As FbItemList = New FbItemList
                    
                    '@ﾃﾞｰﾀの格納
                    typFbItemListTmp.strItemName = _
                            vsfFbParameterList.GetData(llngCnt, CMlngvsfListColItemName)       'ﾊﾟﾗﾒｰﾀ名
                    
                    '@小数点以下が設定済みの場合
                    If vsfFbParameterList.GetData(llngCnt, CMlngvsfListColDigit) <> vbNullString Then
                        '@ﾌｫｰﾏｯﾄ設定
                        Select Case vsfFbParameterList.GetData(llngCnt, CMlngvsfListColDigit)
                            Case "1"
                                lstrDoubleFormatString = CPstrDoubleFormat1String
                            Case "2"
                                lstrDoubleFormatString = CPstrDoubleFormat2String
                            Case "3"
                                lstrDoubleFormatString = CPstrDoubleFormat3String
                            Case "4"
                                lstrDoubleFormatString = CPstrDoubleFormat4String
                            Case "5"
                                lstrDoubleFormatString = CPstrDoubleFormat5String
                            Case "6"
                                lstrDoubleFormatString = CPstrDoubleFormat6String
                            Case "7"
                                lstrDoubleFormatString = CPstrDoubleFormat7String
                            Case "8"
                                lstrDoubleFormatString = CPstrDoubleFormat8String
                            Case "9"
                                lstrDoubleFormatString = CPstrDoubleFormat9String
                        End Select
                        
                        typFbItemListTmp.strItemValue = _
                                CDbl(Format$(CDbl(vsfFbParameterList.GetData(llngCnt, CMlngvsfListColNewValue)), lstrDoubleFormatString))     'ﾊﾟﾗﾒｰﾀ値(ﾃｷｽﾄ値)
                    Else
                        '@小数点以下が設定されていない場合
                        typFbItemListTmp.strItemValue = _
                                CDbl(vsfFbParameterList.GetData(llngCnt, CMlngvsfListColNewValue))     'ﾊﾟﾗﾒｰﾀ値(ﾃｷｽﾄ値)
                    End If

                    .typFbItemList.Add(typFbItemListTmp)

                    llngDataCnt = llngDataCnt + 1
                End If
            Next
            '@ﾘｽﾄ件数
            .lngFbItemListCnt = llngDataCnt
        End With
        
        '@【ﾌｫﾄF/Bﾊﾟﾗﾒｰﾀ変更】
        lblnAns = pubblnPhotoFbEqParameter_Upd(ltypPhotoFbEqPrmchgReq)
        
        '@結果判定
        If lblnAns = True Then
            '@ﾒｯｾｰｼﾞ表示"<TRM40I>$$フォトF/B装置パラメータを変更しました。"
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0040)
            '@成功ﾒｯｾｰｼﾞ表示
            Call pubVsfInfo_Disp(pstrDMsg)
            
            '@確定後の最新を取得する。
            Call cmdLotSearch_Click(cmdLotSearch, New EventArgs)
            
            '@該当件数の有無
            If vsfFbParameterList.Rows.Count > vsfFbParameterList.Rows.Fixed Then
                '@該当件数あり
                Call pubSetFocus(vsfFbParameterList)
            Else
                '@該当件数なし
                '@構造体の初期化（ｿｰﾄ用）
                With mtypChgSort
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
            
            '@確定ﾎﾞﾀﾝ使用不可
            cmdProcEnd.Enabled = False
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
        Else
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(lstrFormName, lstrEventName)
            
            '@異常の場合終了
            Exit Sub
        End If

        Exit Sub
        
    Error_Handler:

        '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
        With ptypOnErrorInfo
            .strMenuKey = CMstrLocalMenuKey
            .strProcName = "cmdProcEnd_Click"
            .strErrMessage = vbNullString
        End With

        '@共通ｴﾗｰ処理
        Call pubOnError_Proc()

    End Sub

    '関数名：cmdLeft_Click
    '機　能：左ｽｸﾛｰﾙﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:32:06 N.Kasai
    '更新日：2007/07/06 (Fri) 13:46:29 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 13:46:29 N.Kasai  ｸﾞﾘｯﾄﾞ共通化
    Private Sub cmdLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2007/07/06 (Fri) 13:46:27 N.Kasai **************************************************
            '@左ｽｸﾛｰﾙﾎﾞﾀﾝ制御
            Call pubVsfCmdLeft(vsfFbParameterList, cmdLeft, cmdRight)
        '@↑2007/07/06 (Fri) 13:46:27 N.Kasai **************************************************
            
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
    '機　能：右ｽｸﾛｰﾙﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:32:17 N.Kasai
    '更新日：2007/07/06 (Fri) 13:45:39 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 13:45:39 N.Kasai  ｸﾞﾘｯﾄﾞ共通化
    Private Sub cmdRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2007/07/06 (Fri) 13:45:37 N.Kasai **************************************************
            '@右ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            Call pubVsfCmdRight(vsfFbParameterList, cmdLeft, cmdRight)
        '@↑2007/07/06 (Fri) 13:45:37 N.Kasai **************************************************

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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:32:29 N.Kasai
    '更新日：2006/02/23 (Thu) 13:32:29
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,New CancelEventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@配列の解放（ｿｰﾄ用）
            If mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort.typChgSortList.Clear
            End If
            
            '@ActInitフラグの判定
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

    '関数名：vsfFbParameterList_AfterEdit
    '機　能：ｸﾞﾘｯﾄﾞ変更後処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2006/03/01 (Wed) 10:44:52 N.Kasai
    '更新日：2006/03/29 (Wed) 10:20:04 N.Kasai
    '備　考：
    '　　　：2006/03/29 (Wed) 10:20:04 N.Kasai      桁拡張
    Private Sub vsfFbParameterList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFbParameterList.AfterEdit
        
        Dim lstrDoubleFormatString      As String       'ﾌｫｰﾏｯﾄ
        Dim lblnAns                     As Boolean      '戻り値
        Dim llngCnt                     As Integer      'ｶｳﾝﾀ
        Dim llngWidthAll                As Integer      '幅格納

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbParameterList.Rows.Count <= vsfFbParameterList.Rows.Fixed Then
                Return
            End If
            
            With vsfFbParameterList
            
                Select Case e.Col
                    '@変更値の場合
                    Case CMlngvsfListColNewValue
                        
                        '@小数点以下が設定済みの場合
                        If .GetData(e.Row, CMlngvsfListColDigit) <> vbNullString Then
                            '@ﾌｫｰﾏｯﾄ設定
                            Select Case .GetData(e.Row, CMlngvsfListColDigit)
                                Case "1"
                                    lstrDoubleFormatString = CPstrDoubleFormat1String
                                Case "2"
                                    lstrDoubleFormatString = CPstrDoubleFormat2String
                                Case "3"
                                    lstrDoubleFormatString = CPstrDoubleFormat3String
                                Case "4"
                                    lstrDoubleFormatString = CPstrDoubleFormat4String
                                Case "5"
                                    lstrDoubleFormatString = CPstrDoubleFormat5String
        '@↓2006/03/29 (Wed) 10:18:56 N.Kasai **************************************************
                                Case "6"
                                    lstrDoubleFormatString = CPstrDoubleFormat6String
                                Case "7"
                                    lstrDoubleFormatString = CPstrDoubleFormat7String
                                Case "8"
                                    lstrDoubleFormatString = CPstrDoubleFormat8String
                                Case "9"
                                    lstrDoubleFormatString = CPstrDoubleFormat9String
        '@↑2006/03/29 (Wed) 10:18:56 N.Kasai **************************************************
                            End Select
                        End If
                        
                        '@ﾌｫｰﾏｯﾄにより四捨五入
                        If IsNumeric(.GetData(e.Row, e.Col)) Then
                            .SetData(e.Row, e.Col, Format$(CDbl(.GetData(e.Row, e.Col)), lstrDoubleFormatString))
                        End If
                        
                        '@ｵｰﾄ幅設定
                        '@ﾕｰｻﾞによる列幅変更されていない場合
                        If mtypChgSort.blnChgWidth = False Then
                            '@入力後、ﾘｻｲｽﾞする。
                            '.AutoSizeMode = flexAutoSizeColWidth
                            .AutoSizeCol(CMlngvsfListColNewValue, 6)
                        End If
                        
                        '@入力ｴﾘｱがﾁﾋﾞｯｺにならないよう最低限のｴﾘｱを確保
                        If .Cols(CMlngvsfListColNewValue).Width < CMlngvsfListColwNewValue Then
                            .Cols(CMlngvsfListColNewValue).Width = CMlngvsfListColwNewValue
                        End If
                        
                        '@全列数の幅取得(非表示項目は含めない)
                        For llngCnt = 0 To .Cols.Count - 1
                            If .Cols(llngCnt).Visible <> False Then
                                llngWidthAll = llngWidthAll + .Cols(llngCnt).Width
                            End If
                        Next llngCnt
                        '@ｸﾞﾘｯﾄﾞ幅と比較して横ｽｸﾛｰﾙﾎﾞﾀﾝを活性化するか判断
                        If .Width - llngWidthAll >= 0 Then
                            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=2:非活性化)
                            mlngSideScrollFlag = CMlngSideScrollOffFlag
                            
                            '@右ｽｸﾛｰﾙ非活性化
                            cmdRight.Enabled = False
                        Else
                            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=1:活性化)
                            mlngSideScrollFlag = CMlngSideScrollOnFlag
                            
                            '@右ｽｸﾛｰﾙ活性化
                            cmdRight.Enabled = True
                        End If
                        
                        '@戻り値の初期化
                        lblnAns = False
                        '@ｸﾞﾘｯﾄﾞ内検索
                        For llngCnt = 1 To .Rows.Count - 1
                            '@変更値に値が設定されている場合
                            If .GetData(llngCnt, CMlngvsfListColNewValue) <> vbNullString Then
                                '@値発見！！
                                lblnAns = True
                                Exit For
                            End If
                        Next
                        '@入力判定
                        If lblnAns = True Then
                            '@確定ﾎﾞﾀﾝ使用可
                            cmdProcEnd.Enabled = True
                        Else
                            '@確定ﾎﾞﾀﾝ使用不可
                            cmdProcEnd.Enabled = False
                        End If
                End Select
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbParameterList_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbParameterList_AfterUserResize
    '機　能：ｸﾞﾘﾄﾞｻｲｽﾞ変更
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:33:02 N.Kasai
    '更新日：2006/02/23 (Thu) 13:33:02
    '備　考：
    Private Sub vsfFbParameterList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFbParameterList.AfterResizeColumn, vsfFbParameterList.AfterResizeRow

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbParameterList.Rows.Count <= vsfFbParameterList.Rows.Fixed Then
                Return
            End If
            
            '@列幅変更フラグ（変更）
            mtypChgSort.blnChgWidth = True
            
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御（ｸﾞﾘｯﾄﾞ共通化関数）
            Call pubCmdLREnable_Set(vsfFbParameterList, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbParameterList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbParameterList_BeforeEdit
    '機　能：ｸﾞﾘｯﾄﾞ編集前
    '引　数：Row：行
    '　　　：Col：列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/03/24 (Fri) 16:22:25 N.Kasai
    '更新日：2006/03/24 (Fri) 16:22:25
    '備　考：
    Private Sub vsfFbParameterList_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFbParameterList.SetupEditor
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbParameterList.Rows.Count <= vsfFbParameterList.Rows.Fixed Then
                Return
            End If

            With vsfFbParameterList
                Select Case e.Col
                    '@変更値の場合
                    Case CMlngvsfListColNewValue
                        '@見出し以外
                        If e.Row > 0 Then
                            '@入力最大桁数
                            CType(.Editor, Textbox).MaxLength = CMlngInputNDataMaxByte
                        End If
                End Select
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbParameterList_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbParameterList_BeforeRowColChange
    '機　能：行列変更前処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙt値
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:33:21 N.Kasai
    '更新日：2006/02/23 (Thu) 13:33:21
    '備　考：
    Private Sub vsfFbParameterList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfFbParameterList.BeforeRowColChange
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbParameterList.Rows.Count <= vsfFbParameterList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（№）
                mtypChgSort.strKey = vsfFbParameterList.GetData(e.NewRange.r1, CMlngvsfListColNo)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbParameterList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotSearch_Click
    '機　能：ﾊﾟﾗﾒｰﾀﾘｽﾄ取得
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:33:47 N.Kasai
    '更新日：2007/05/22 (Tue) 09:31:45 N.Kasai
    '備　考：
    '　　　：2007/05/22 (Tue) 09:31:45 N.Kasai  ﾃﾞｰﾀ種別追加（№01935）
    Private Sub cmdLotSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotSearch.Click

        Dim lblnAns                 As Boolean              '戻り値
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim ltypPhotoFbEqPrmListReq As PhotoFbEqPrmListReq  '要求格納用構造体
        Dim ltypPhotoFbEqPrmListAns As PhotoFbEqPrmListAns  '応答格納用構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdLotSearch_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾗﾍﾞﾙ初期化
            lblNowDate.Text = vbNullString   '情報取得日時
            lblLotCnt.Text = vbNullString    '該当件数
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用禁止
            cmdUP.Enabled = False               '前ﾍﾟｰｼﾞ
            cmdDown.Enabled = False             '次ﾍﾟｰｼﾞ
            cmdLeft.Enabled = False             '左ﾎﾞﾀﾝ
            cmdRight.Enabled = False            '右ﾎﾞﾀﾝ
            cmdProcEnd.Enabled = False          '確定ﾎﾞﾀﾝ
            
            '@要求構造体へ格納
            With ltypPhotoFbEqPrmListReq
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstreq__photofbeqprmlistVer
                '@SBID
                .strSbID = pstrSBID
                '@装置ID
                cmbWp.ValueCol = CMlngCmbGridCol1
                .strWpID = cmbWp.Value
            
        '@↓2007/05/22 (Tue) 09:31:36 N.Kasai **************************************************
                '@ﾃﾞｰﾀ種別
                cmbDataKind.ValueCol = CMlngCmbGridCol1
                .strDataKind = cmbDataKind.Value
        '@↑2007/05/22 (Tue) 09:31:36 N.Kasai **************************************************
            End With
            
            '@【装置ﾊﾟﾗﾒｰﾀﾘｽﾄ取得】
            lblnAns = pubblnPhotoFbEqParameter_Sel(ltypPhotoFbEqPrmListReq, ltypPhotoFbEqPrmListAns)
            
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            '@ﾊﾟﾗﾒｰﾀﾘｽﾄ表示
            Call prvvsfFbParaList_Disp(ltypPhotoFbEqPrmListAns)
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@ﾌｫｰｶｽの設定
            With vsfFbParameterList
                '@ﾃﾞｰﾀ件数がある場合
                If .Rows.Count > 1 Then
                    .Enabled = True
                    '@ｸﾞﾘｯﾄﾞが使用可能
                    If .Enabled = True Then
                        '@ｺﾝﾎﾞが1件で画面初期表示する場合はLOAD中に付きﾌｫｰｶｽを当てない！
                        If pblnFormLoad = True Then
                            '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽ設定
                            Call pubSetFocus(vsfFbParameterList)
                        End If
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotSearch_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：上ｽｸﾛｰﾙﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:34:00 N.Kasai
    '更新日：2006/02/23 (Thu) 13:34:00
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
            Call pubVsfCmdUp(vsfFbParameterList, cmdUP, cmdDown)
            
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

    '関数名：cmdDown_Click
    '機　能：下ｽｸﾛｰﾙﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:34:13 N.Kasai
    '更新日：2006/02/23 (Thu) 13:34:13
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
            Call pubVsfCmdDown(vsfFbParameterList, cmdUP, cmdDown)
            
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

    '関数名：Form_KeyDown
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:34:35 N.Kasai
    '更新日：2007/07/06 (Fri) 13:51:26 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 13:51:26 N.Kasai  ｸﾞﾘｯﾄﾞ共通化
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfFbParameterList, cmdUP, cmdDown)
            
        '@↓2007/07/06 (Fri) 13:51:19 N.Kasai **************************************************
            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ）
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfFbParameterList, cmdLeft, cmdRight)
        '@↑2007/07/06 (Fri) 13:51:19 N.Kasai **************************************************

            '@Enterｷｰの場合
            Select Case e.KeyCode
                Case Keys.Return
                    Select Case ActiveControl.Name
                        Case cmbWp.Name
                        '@ﾌｫﾄ号機ｺﾝﾎﾞの場合
                            '@ｺﾝﾎﾞ選択の有無を判定
                            If cmbWp.ListIndex = -1 Then
                                '@最新取得ﾎﾞﾀﾝ(使用不可)
                                cmdLotSearch.Enabled = False
                                SendKeys.SendWait(CPstrSendKeysTab)
                            Else
                                '@ﾌｫﾄ号機のValidate処理を呼ぶ
                                RemoveHandler cmbWp.Validating, AddressOf cmbWp_Validate
                                Call cmbWp_Validate(cmbWp, New CancelEventArgs(True))
                                AddHandler cmbWp.Validating, AddressOf cmbWp_Validate
                                e.Handled = True
                            End If
                        Case cmbDataKind.Name
                            '@ｺﾝﾎﾞ選択の有無を判定
                            If cmbDataKind.ListIndex = -1 Then
                                '@最新取得ﾎﾞﾀﾝ(使用不可)
                                cmdLotSearch.Enabled = False
                                SendKeys.SendWait(CPstrSendKeysTab)
                            Else
                                '@ﾃﾞｰﾀ種別Validate処理を呼ぶ
                                RemoveHandler cmbDataKind.Validating, AddressOf cmbDataKind_Validate
                                Call cmbDataKind_Validate(cmbDataKind, New CancelEventArgs(True))
                                AddHandler cmbDataKind.Validating, AddressOf cmbDataKind_Validate
                                e.Handled = True
                            End If
                        
                        
                        Case Else
                        '@その他
                            If ActiveControl IsNot vsfFbParameterList.Editor Then
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            End If
                    End Select

                Case Keys.PageUp, Keys.PageDown
                    'NSYS [PageUp][PageDown]キーは無効
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

    '関数名：vsfFbParameterList_BeforeSort
    '機　能：ソート前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:35:14 N.Kasai
    '更新日：2006/02/23 (Thu) 13:35:14
    '備　考：
    Private Sub vsfFbParameterList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfFbParameterList.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbParameterList.Rows.Count <= vsfFbParameterList.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 [№] ）
            Call pubVsfBeforeSort(vsfFbParameterList, CMlngvsfListColNo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbParameterList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbParameterList_AfterSort
    '機　能：ソート後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 13:35:26 N.Kasai
    '更新日：2006/02/23 (Thu) 13:35:26
    '備　考：
    Private Sub vsfFbParameterList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfFbParameterList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbParameterList.Rows.Count <= vsfFbParameterList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                'NSYS リストを初期化
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If

                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                Dim ltypChgSortList As ChgSortList
                
                '@ｿｰﾄ列番号を格納
                ltypChgSortList.lngCol = e.Col
                '@並び替え方法を格納（昇順/降順）
                ltypChgSortList.lngOrder = e.Order

                .typChgSortList.Add(ltypChgSortList)
            End With

            '@ｶﾚﾝﾄ行の設定（ｸﾞﾘｯﾄﾞ、保持列 [№]、前頁、次頁 ）
            Call pubVsfAfterSort(vsfFbParameterList, CMlngvsfListColNo, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbParameterList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbParameterList_DblClick
    '機　能：ｸﾞﾘｯﾄﾞﾀﾞﾌﾞﾙｸﾘｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/01 (Wed) 10:46:29 N.Kasai
    '更新日：2006/03/01 (Wed) 10:46:29
    '備　考：
    Private Sub vsfFbParameterList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFbParameterList.DoubleClick

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbParameterList.Rows.Count <= vsfFbParameterList.Rows.Fixed Then
                Return
            End If

            With vsfFbParameterList
             
                '@ﾍｯﾀﾞｰ行の場合、処理中止
                If .Row = 0 Then
                    Exit Sub
                End If
                
                '@列判定
                 Select Case .Col
                    '@変更値
                    Case CMlngvsfListColNewValue
                        '@編集可能ｾﾙの場合
                        .Select(.Row, .Col)  '編集可能ｾﾙの範囲選択
                        .StartEditing()           '編集可能にする
                End Select
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbParameterList_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbParameterList_KeyDown
    '機　能：ｸﾞﾘｯﾄﾞKeyDown
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2006/02/28 (Tue) 16:25:13 N.Kasai
    '更新日：2006/02/28 (Tue) 16:25:13
    '備　考：
    Private Sub vsfFbParameterList_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfFbParameterList.KeyDown

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbParameterList.Rows.Count <= vsfFbParameterList.Rows.Fixed Then
                Return
            End If
            
            With vsfFbParameterList
                '@ﾍｯﾀﾞｰ行の場合、処理中止
                If .Row = 0 Then
                    Exit Sub
                End If
                
                Select Case e.KeyCode
                    Case Keys.Up, Keys.Down, Keys.Left, Keys.Right
                        '@処理なし
                    Case Else
                            
                        Select Case .Col
                            '@変更値
                            Case CMlngvsfListColNewValue
                                'NSYS [F2][Space]キーの場合
                                If e.KeyCode = Keys.F2 OrElse e.KeyCode = Keys.Space Then
                                    e.SuppressKeyPress = True
                                End If

                                '@DELETEｷｰの場合は値をｸﾘｱする。
                                If e.KeyCode = Keys.Delete Then
                                    .SetData(.Row, CMlngvsfListColNewValue, vbNullString)
                                End If
                                '@編集可能ｾﾙの場合
                                .Select(.Row, .Col)  '編集可能ｾﾙの範囲選択
                                .StartEditing()           '編集可能にする

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
                .strProcName = "vsfFbParameterList_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbParameterList_KeyPressEdit
    '機　能：ｸﾞﾘｯﾄﾞKeyPressEdit
    '引　数：Row：行
    '　　　：Col：列
    '　　　：KeyAscii：ｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2006/02/28 (Tue) 16:25:18 N.Kasai
    '更新日：2006/02/28 (Tue) 16:25:18
    '備　考：
    Private Sub vsfFbParameterList_KeyPressEdit(ByVal sender As Object, ByVal e As KeyPressEditEventArgs) Handles vsfFbParameterList.KeyPressEdit

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFbParameterList.Rows.Count <= vsfFbParameterList.Rows.Fixed Then
                Return
            End If

             With vsfFbParameterList
                    Select Case e.Col
                        '@変更値
                        Case CMlngvsfListColNewValue
                            '@半角数字,「.」「-」のみ入力可
                            Select Case Asc(e.KeyChar)
                                Case CPlngKeyAsciiNum0 To CPlngKeyAsciiNum9, CPlngKeyBackSpace, CPlngKeyReturn, CPlngKeyAsciiDecPoint, CPlngKeyAsciiMinus
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
                .strProcName = "vsfFbParameterList_KeyPressEdit"
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

    '関数名：prvvsfFbParaList_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/23 (Thu) 14:21:43 N.Kasai
    '更新日：2006/02/23 (Thu) 14:21:43
    '備　考：
    Private Sub prvvsfFbParaList_init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfFbParameterList
                '@描画なし
                .Redraw = False
                '@ｸﾞﾘｯﾄﾞの行設定
                .Rows.Count = CMlngvsfTRow + 1
                '@ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMlngvsfListCols
                '@固定列の設定
                .Cols.Frozen = CMlngvsfListColLowerValue                    '下限値まで
                '@ｸﾞﾘｯﾄﾞ設定
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
                .Rows(CMlngvsfTRow).Height = CMlngVsfHHeight                                'ﾍｯﾀﾞｰの高さを設定
                
                '@列幅設定
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    .Cols(CMlngvsfListColNo).Width = CMlngvsfListColWNo                           '№
                    .Cols(CMlngvsfListColItemName).Width = CMlngvsfListColwItemName               '装置ﾊﾟﾗﾒｰﾀ
                    .Cols(CMlngvsfListColItemValue).Width = CMlngvsfListColwItemValue             '現在値
                    .Cols(CMlngvsfListColNewValue).Width = CMlngvsfListColwNewValue               '変更値
                    .Cols(CMlngvsfListColLowerValue).Width = CMlngvsfListColwLowerValue           '下限値
                    .Cols(CMlngvsfListColUpperValue).Width = CMlngvsfListColwUpperValue           '上限値
                    .Cols(CMlngvsfListColEditTime).Width = CMlngvsfListColwEditTime               '最終更新日時
                    .Cols(CMlngvsfListColEditEmp).Width = CMlngvsfListColwEditEmp                 '最終更新者
                    .Cols(CMlngvsfListColDigit).Width = CMlngvsfListColwDigit                     '小数点
                End If
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfTRow, CMlngvsfListColNo, CMstrvsfListColTNo)                     '№
                .SetData(CMlngvsfTRow, CMlngvsfListColItemName, CMstrvsfListColtItemName)         '装置ﾊﾟﾗﾒｰﾀ
                .SetData(CMlngvsfTRow, CMlngvsfListColItemValue, CMstrvsfListColtItemValue)       '現在値
                .SetData(CMlngvsfTRow, CMlngvsfListColNewValue, CMstrvsfListColtNewValue)         '変更値
                .SetData(CMlngvsfTRow, CMlngvsfListColLowerValue, CMstrvsfListColtLowerValue)     '下限値
                .SetData(CMlngvsfTRow, CMlngvsfListColUpperValue, CMstrvsfListColtUpperValue)     '上限値
                .SetData(CMlngvsfTRow, CMlngvsfListColEditTime, CMstrvsfListColtEditTime)         '最終更新日時
                .SetData(CMlngvsfTRow, CMlngvsfListColEditEmp, CMstrvsfListColtEditEmp)           '最終更新者
                .SetData(CMlngvsfTRow, CMlngvsfListColDigit, CMstrvsfListColtDigit)               '小数点

                '@非表示Col設定
                .Cols(CMlngvsfListColDigit).Visible = False                                       '小数点
                
                '@表示ﾌｫｰﾏｯﾄ
                .Cols(CMlngvsfListColNo).TextAlign = TextAlignEnum.RightCenter              '№（左中央寄せ）
                .Cols(CMlngvsfListColItemName).TextAlign = TextAlignEnum.LeftCenter         '装置ﾊﾟﾗﾒｰﾀ（左中央寄せ）
                .Cols(CMlngvsfListColItemValue).TextAlign = TextAlignEnum.RightCenter       '現在値（右中央寄せ）
                .Cols(CMlngvsfListColNewValue).TextAlign = TextAlignEnum.RightCenter        '変更値（右中央寄せ）
                .Cols(CMlngvsfListColLowerValue).TextAlign = TextAlignEnum.RightCenter      '下限値（右中央寄せ）
                .Cols(CMlngvsfListColUpperValue).TextAlign = TextAlignEnum.RightCenter      '上限値（右中央寄せ）
                .Cols(CMlngvsfListColEditTime).TextAlign = TextAlignEnum.LeftCenter         '最終更新日（左中央寄せ）
                .Cols(CMlngvsfListColEditEmp).TextAlign = TextAlignEnum.LeftCenter          '最終更新者（左中央寄せ）
                .Cols(CMlngvsfListColDigit).TextAlign = TextAlignEnum.RightCenter           '小数点（右中央寄せ）

                'NSYS 編集モードのセル前景色,背景色を設定
                .Styles.Editor.ForeColor = SystemColors.WindowText
                .Styles.Editor.BackColor = ColorTranslator.FromWin32(CPlngInputColor)

                'NSYS 初期横スクロール位置を設定
                .LeftCol = .Cols.Fixed
                
                '@直接描画
                .Redraw = True
                '@ﾛｯｸ
                .Enabled = False
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFbParaList_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMainForm_Init
    '機　能：画面初期設定
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/28 (Tue) 14:59:30 N.Kasai
    '更新日：2006/02/28 (Tue) 14:59:30
    '備　考：
    Private Sub prvMainForm_Init()

        Dim lstrFormTitle           As String   'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01T0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString                      '情報取得日時
            lblLotCnt.Text = vbNullString                       '該当件数
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfFbParaList_init                          'ﾊﾟﾗﾒｰﾀ一覧
            
            '@ｺﾝﾎﾞ初期化
            Call prvcmb_Init                                    'ﾌｫﾄ号機/ﾃﾞｰﾀ種別
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用不可
            cmdLotSearch.Enabled = False                        '最新取得ﾎﾞﾀﾝ
            cmdUP.Enabled = False                               '前ﾍﾟｰｼﾞ
            cmdDown.Enabled = False                             '次ﾍﾟｰｼﾞ
            cmdLeft.Enabled = False                             '左ﾎﾞﾀﾝ
            cmdRight.Enabled = False                            '右ﾎﾞﾀﾝ
            cmdProcEnd.Enabled = False                          '確定ﾎﾞﾀﾝ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMainForm_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfFbParaList_Disp
    '機　能：ﾌｫﾄF/Bﾊﾟﾗﾒｰﾀﾘｽﾄ表示
    '引　数：ltypPhotoFbEqPrmListAns：応答格納用構造体
    '戻り値：なし
    '作成日：2006/03/10 (Fri) 11:46:00 N.Kasai
    '更新日：2007/07/09 (Mon) 15:38:08 N.Kasai
    '備　考：
    '　　　：2006/03/29 (Wed) 10:22:20 N.Kasai  桁拡張
    '　　　：2007/07/09 (Mon) 15:38:08 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub prvvsfFbParaList_Disp(ByRef ltypPhotoFbEqPrmListAns As PhotoFbEqPrmListAns)

        Dim llngDoCnt                   As Integer      'Doの回数ｶｳﾝﾄ
        Dim llngCnt                     As Integer      '汎用ｶｳﾝﾄ（ｿｰﾄ用に使用）
        Dim lstrDoubleFormatString      As CellStyle    'ﾌｫｰﾏｯﾄ
        Dim cellRange2                  As CellRange    'NSYS グリッド2列目フォーマット設定用
        Dim cellRange4                  As CellRange    'NSYS グリッド4列目フォーマット設定用
        Dim cellRange5                  As CellRange    'NSYS グリッド5列目フォーマット設定用
        
        Try
            
            '@一覧表示
            With vsfFbParameterList
                
                '@描画なし
                .Redraw = False

                RemoveHandler vsfFbParameterList.BeforeRowColChange, AddressOf vsfFbParameterList_BeforeRowColChange
            
                '@行数設定
                .Rows.Count = .Rows.Fixed
                .Rows.Count = ltypPhotoFbEqPrmListAns.lngEqPrmListCnt + 1

                AddHandler vsfFbParameterList.BeforeRowColChange, AddressOf vsfFbParameterList_BeforeRowColChange
                
                '@ｶｳﾝﾀの初期化
                llngDoCnt = 0
                
                'NSYS フォーマット設定用
                Dim formatStyle1 As CellStyle = .Styles.Add("CustomStyle_Format_CPstrDoubleFormat1String")
                Dim formatStyle2 As CellStyle = .Styles.Add("CustomStyle_Format_CPstrDoubleFormat2String")
                Dim formatStyle3 As CellStyle = .Styles.Add("CustomStyle_Format_CPstrDoubleFormat3String")
                Dim formatStyle4 As CellStyle = .Styles.Add("CustomStyle_Format_CPstrDoubleFormat4String")
                Dim formatStyle5 As CellStyle = .Styles.Add("CustomStyle_Format_CPstrDoubleFormat5String")
                Dim formatStyle6 As CellStyle = .Styles.Add("CustomStyle_Format_CPstrDoubleFormat6String")
                Dim formatStyle7 As CellStyle = .Styles.Add("CustomStyle_Format_CPstrDoubleFormat7String")
                Dim formatStyle8 As CellStyle = .Styles.Add("CustomStyle_Format_CPstrDoubleFormat8String")
                Dim formatStyle9 As CellStyle = .Styles.Add("CustomStyle_Format_CPstrDoubleFormat9String")
                lstrDoubleFormatString = .Styles.Normal

                'NSYS フォーマットの設定
                formatStyle1.Format = CPstrDoubleFormat1String
                formatStyle2.Format = CPstrDoubleFormat2String
                formatStyle3.Format = CPstrDoubleFormat3String
                formatStyle4.Format = CPstrDoubleFormat4String
                formatStyle5.Format = CPstrDoubleFormat5String
                formatStyle6.Format = CPstrDoubleFormat6String
                formatStyle7.Format = CPstrDoubleFormat7String
                formatStyle8.Format = CPstrDoubleFormat8String
                formatStyle9.Format = CPstrDoubleFormat9String
                
                '@ﾛｯﾄ一覧表示情報設定
                Do While .Rows.Count > llngDoCnt + 1
                    .SetData(llngDoCnt + 1, CMlngvsfListColItemName, _
                            ltypPhotoFbEqPrmListAns.typEqPrmList(llngDoCnt).strItemName)             '装置ﾊﾟﾗﾒｰﾀ
                    .SetData(llngDoCnt + 1, CMlngvsfListColItemValue, _
                            ltypPhotoFbEqPrmListAns.typEqPrmList(llngDoCnt).strItemValue)            '現在値
                    .SetData(llngDoCnt + 1, CMlngvsfListColNewValue, vbNullString)                   '変更値
                    .SetData(llngDoCnt + 1, CMlngvsfListColLowerValue, _
                            ltypPhotoFbEqPrmListAns.typEqPrmList(llngDoCnt).strLowerLimit)           '下限値
                    .SetData(llngDoCnt + 1, CMlngvsfListColUpperValue, _
                            ltypPhotoFbEqPrmListAns.typEqPrmList(llngDoCnt).strUpperLimit)           '上限値

                    If IsDate(ltypPhotoFbEqPrmListAns.typEqPrmList(llngDoCnt).strEntryTime) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColEditTime, _
                                Format(CDate(ltypPhotoFbEqPrmListAns.typEqPrmList(llngDoCnt).strEntryTime), _
                                    CPstrDateTimeYMDHMS))                                            '最終更新日時
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColEditTime, _
                                ltypPhotoFbEqPrmListAns.typEqPrmList(llngDoCnt).strEntryTime)        '最終更新日時
                    End If

                    .SetData(llngDoCnt + 1, CMlngvsfListColEditEmp, _
                            ltypPhotoFbEqPrmListAns.typEqPrmList(llngDoCnt).strEmpName)              '最終更新者
                    .SetData(llngDoCnt + 1, CMlngvsfListColDigit, _
                            ltypPhotoFbEqPrmListAns.typEqPrmList(llngDoCnt).strItemValidDigit)       '小数点以下制御
                    
                    cellRange2 = .GetCellRange(llngDoCnt + 1, CMlngvsfListColItemValue)
                    cellRange4 = .GetCellRange(llngDoCnt + 1, CMlngvsfListColLowerValue)
                    cellRange5 = .GetCellRange(llngDoCnt + 1, CMlngvsfListColUpperValue)
                            
                    '@小数点以下が設定済みの場合
                    If .GetData(llngDoCnt + 1, CMlngvsfListColDigit) <> vbNullString Then
                        '@ﾌｫｰﾏｯﾄ設定
                        Select Case .GetData(llngDoCnt + 1, CMlngvsfListColDigit)
                            Case "1"
                                lstrDoubleFormatString = formatStyle1
                                cellRange2.Style = formatStyle1
                                cellRange4.Style = formatStyle1
                                cellRange5.Style = formatStyle1
                            Case "2"
                                lstrDoubleFormatString = formatStyle2
                                cellRange2.Style = formatStyle2
                                cellRange4.Style = formatStyle2
                                cellRange5.Style = formatStyle2
                            Case "3"
                                lstrDoubleFormatString = formatStyle3
                                cellRange2.Style = formatStyle3
                                cellRange4.Style = formatStyle3
                                cellRange5.Style = formatStyle3
                            Case "4"
                                lstrDoubleFormatString = formatStyle4
                                cellRange2.Style = formatStyle4
                                cellRange4.Style = formatStyle4
                                cellRange5.Style = formatStyle4
                            Case "5"
                                lstrDoubleFormatString = formatStyle5
                                cellRange2.Style = formatStyle5
                                cellRange4.Style = formatStyle5
                                cellRange5.Style = formatStyle5
        '@↓2006/03/29 (Wed) 10:18:56 N.Kasai **************************************************
                            Case "6"
                                lstrDoubleFormatString = formatStyle6
                                cellRange2.Style = formatStyle6
                                cellRange4.Style = formatStyle6
                                cellRange5.Style = formatStyle6
                            Case "7"
                                lstrDoubleFormatString = formatStyle7
                                cellRange2.Style = formatStyle7
                                cellRange4.Style = formatStyle7
                                cellRange5.Style = formatStyle7
                            Case "8"
                                lstrDoubleFormatString = formatStyle8
                                cellRange2.Style = formatStyle8
                                cellRange4.Style = formatStyle8
                                cellRange5.Style = formatStyle8
                            Case "9"
                                lstrDoubleFormatString = formatStyle9
                                cellRange2.Style = formatStyle9
                                cellRange4.Style = formatStyle9
                                cellRange5.Style = formatStyle9
        '@↑2006/03/29 (Wed) 10:18:56 N.Kasai **************************************************
                            Case Else
                                'NSYS 1～9以外の場合は前行のフォーマットを設定
                                cellRange2.Style = lstrDoubleFormatString
                                cellRange4.Style = lstrDoubleFormatString
                                cellRange5.Style = lstrDoubleFormatString
                        End Select
                    Else
                        'NSYS 小数点以下が未設定の場合は前行のフォーマットを設定
                        cellRange2.Style = lstrDoubleFormatString
                        cellRange4.Style = lstrDoubleFormatString
                        cellRange5.Style = lstrDoubleFormatString
                    End If
                        
                    '@ﾌｫｰﾏｯﾄにより四捨五入
                    If IsNumeric(.GetData(llngDoCnt + 1, CMlngvsfListColItemValue)) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColItemValue, _
                                CDbl(.GetData(llngDoCnt + 1, CMlngvsfListColItemValue)))
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColItemValue, .GetData(llngDoCnt + 1, CMlngvsfListColItemValue))
                    End If

                    If IsNumeric(.GetData(llngDoCnt + 1, CMlngvsfListColLowerValue)) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColLowerValue, _
                                CDbl(.GetData(llngDoCnt + 1, CMlngvsfListColLowerValue)))
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColLowerValue, .GetData(llngDoCnt + 1, CMlngvsfListColLowerValue))
                    End If

                    If IsNumeric(.GetData(llngDoCnt + 1, CMlngvsfListColUpperValue)) Then
                        .SetData(llngDoCnt + 1, CMlngvsfListColUpperValue, _
                                CDbl(.GetData(llngDoCnt + 1, CMlngvsfListColUpperValue)))
                    Else
                        .SetData(llngDoCnt + 1, CMlngvsfListColUpperValue, .GetData(llngDoCnt + 1, CMlngvsfListColUpperValue))
                    End If
                            
                    '@ｽﾛｯﾄの高さの設定
                    .Rows(llngDoCnt + 1).Height = CMlngvsfBHeight
                    llngDoCnt = llngDoCnt + 1
                Loop

                '@№設定
                For llngDoCnt = 1 To .Rows.Count - 1
                    .SetData(llngDoCnt, CMlngvsfListColNo, llngDoCnt)
                Next llngDoCnt
                                
                '@ﾃﾞｰﾀなしの場合は注意
                If .Rows.Count > .Rows.Fixed Then
                    '@ﾊﾞｯｸｶﾗｰの変更(入力可能色：ﾋﾟﾝｸ)
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngInputColor")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngInputColor)
                    Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngvsfListColNewValue, .Rows.Count - 1, CMlngvsfListColNewValue)
                    cellRange.Style = newStyle
                    
                    '@ｵｰﾄ幅設定
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCols(CMlngvsfListColNo, CMlngvsfListColItemValue, 6)
                        .AutoSizeCols(CMlngvsfListColLowerValue, .Cols.Count - 1, 6)
                    End If
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    '@ｿｰﾄ検索用ｷｰがある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@退避ｷｰと№が同じ場案
                            If .GetData(llngCnt, CMlngvsfListColNo) = mtypChgSort.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 ）
                                Call pubVsfBeforeSort(vsfFbParameterList, CMlngvsfListColNo)
                                '@ｶﾚﾝﾄ行の設定（ｸﾞﾘｯﾄﾞ、保持列 、前頁、次頁 ）
                                Call pubVsfAfterSort(vsfFbParameterList, CMlngvsfListColNo, cmdUP, cmdDown)
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        '@ｶﾚﾝﾄ行初期化
                        .Row = .Rows.Fixed - 1
                        .TopRow = .Rows.Fixed
                    End If
                    
                    '@左右ｽｸﾛｰﾙ制御の記述
                    '@ｶﾚﾝﾄ列初期化
                    .Col = .Cols.Fixed
                    .LeftCol = .Cols.Fixed
                           
        '@↓2007/07/09 (Mon) 15:38:03 N.Kasai **************************************************
        '            '@全列数の幅取得(非表示項目は含めない)
        '            For llngDoCnt = 0 To .Cols - 1
        '                If .ColHidden(llngDoCnt) <> True Then
        '                    llngWidthAll = llngWidthAll + .ColWidth(llngDoCnt)
        '                End If
        '            Next llngDoCnt
        '            '@ｸﾞﾘｯﾄﾞ幅と比較して横ｽｸﾛｰﾙﾎﾞﾀﾝを活性化するか判断
        '            If .Width - llngWidthAll >= 0 Then
        '                '@ｽｸﾛｰﾙﾌﾗｸﾞ(=2:非活性化)
        '                mlngSideScrollFlag = CMlngSideScrollOffFlag
        '
        '                '@右ｽｸﾛｰﾙ非活性化
        '                cmdRight.Enabled = False
        '            Else
        '                '@ｽｸﾛｰﾙﾌﾗｸﾞ(=1:活性化)
        '                mlngSideScrollFlag = CMlngSideScrollOnFlag
        '
        '                '@右ｽｸﾛｰﾙ活性化
        '                cmdRight.Enabled = True
        '            End If

                    '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御（ｸﾞﾘｯﾄﾞ共通化関数）
                    Call pubCmdLREnable_Set(vsfFbParameterList, cmdLeft, cmdRight)
        '@↑2007/07/09 (Mon) 15:38:03 N.Kasai **************************************************

                    '@前ﾍﾟｰｼﾞ、次ﾍﾟｰｼﾞ、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                    If .Rows.Count > 1 Then
                        cmdUP.Enabled = True
                        cmdDown.Enabled = True
                        '@ｸﾞﾘｯﾄﾞﾎﾞﾀﾝ制御、保持値ｸﾘｱ
                        Call pubVsfDisp(vsfFbParameterList, cmdUP, cmdDown)
                    Else
                        cmdUP.Enabled = False
                        cmdDown.Enabled = False
                    End If
                End If
                '@ﾃﾞｰﾀ件数の有無
                If .Rows.Count > .Rows.Fixed Then
                    '@該当件数設定
                    lblLotCnt.Text = Format$(.Rows.Count - 1, CPstrDateFormatKanma)
                    '@ﾛｯｸ解除
                    .Enabled = True
                Else
                    '@該当ﾃﾞｰﾀが存在しない場合
                    lblLotCnt.Text = 0
                    '@ﾛｯｸ
                    .Enabled = False
                    cmdUP.Enabled = False                               '前ﾍﾟｰｼﾞ
                    cmdDown.Enabled = False                             '次ﾍﾟｰｼﾞ
                    cmdLeft.Enabled = False                             '左ﾎﾞﾀﾝ
                    cmdRight.Enabled = False                            '右ﾎﾞﾀﾝ
                    cmdProcEnd.Enabled = False                          '確定ﾎﾞﾀﾝ
                End If
            
                '@情報取得日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                '@直接描画
                .Redraw = True
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFbParaList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmb_Init
    '機　能：ｺﾝﾎﾞﾎﾞｯｸｽ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/28 (Tue) 16:22:14 N.Kasai
    '更新日：2007/05/21 (Mon) 12:45:56 N.Kasai
    '備　考：
    Private Sub prvcmb_Init()

        Try

            '@ｺﾝﾎﾞﾎﾞｯｸｽ設定
            
            '@ﾌｫﾄ号機
            With cmbWp
                .Clear
                .DispCols = CMlngCmbDispCols1                               'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridCol0                                  'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridCol1                                '値取得列
                .DirectInput = False                                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CSng(CMlngCmbFontSize), _
                                 .Font.Style, .Font.Unit)                   'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CSng(CMlngCmbGridFontSize), _
                                     .GridFont.Style, .GridFont.Unit)       'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                              '行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左中央
                .BackColor = SystemColors.Window                            'NSYS 背景色を白色に設定
            End With
            
        '@↓2007/05/21 (Mon) 12:44:04 N.Kasai **************************************************
            '@ﾃﾞｰﾀ種別
            With cmbDataKind
                .Clear
                .DispCols = CMlngCmbDispCols1                               'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridCol0                                  'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridCol1                                '値取得列
                .DirectInput = False                                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CSng(CMlngCmbFontSize), _
                                 .Font.Style, .Font.Unit)                   'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CSng(CMlngCmbGridFontSize), _
                                     .GridFont.Style, .GridFont.Unit)       'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                              '行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左中央
                .BackColor = SystemColors.Window                            'NSYS 背景色を白色に設定
            End With
        '@↑2007/05/21 (Mon) 12:44:04 N.Kasai **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmb_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdLotSearch_Proc
    '機　能：最新取得ﾎﾞﾀﾝ制御
    '引　数：なし
    '戻り値：なし
    '作成日：2007/05/22 (Tue) 13:51:58 N.Kasai
    '更新日：2007/05/22 (Tue) 13:51:58
    '備　考：
    Private Sub prvcmdLotSearch_Proc()

        Try
            
            '@ﾌｫﾄ号機ｺﾝﾎﾞ
            If cmbWp.ListIndex = -1 Then
                cmdLotSearch.Enabled = False
                Exit Sub
            End If
            
            '@ﾃﾞｰﾀ種別ｺﾝﾎﾞ
            If cmbDataKind.ListIndex = -1 Then
                cmdLotSearch.Enabled = False
                Exit Sub
            End If
            
            cmdLotSearch.Enabled = True
            
            '@最新取得
            Call cmdLotSearch_Click(cmdLotSearch, New EventArgs)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdLotSearch_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub



    '関数名：prvcmbWP_Disp
    '機　能：ﾌｫﾄ号機ｺﾝﾎﾞｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/02/28 (Tue) 16:22:32 N.Kasai
    '更新日：2006/02/28 (Tue) 16:22:32
    '備　考：
    Private Sub prvcmbWp_Disp(ByVal llngWpListCnt As Integer)

        Dim llngCnt                 As Integer  'ｶｳﾝﾄ

        Try
                
                '@投入装置ｾｯﾄ
                With cmbWp
                    .Clear
                    For llngCnt = 0 To llngWpListCnt - 1
                        '@【装置名/装置ID】
                        .AddItem(ptypWPList(llngCnt).strWpName & vbTab & ptypWPList(llngCnt).strWpID)
                    Next llngCnt
                    
                    '@装置が1件の場合、ﾃﾞﾌｫﾙﾄ表示
                    If .ListCount = 1 Then
                        '@1件目表示
                        .ListIndex = 0
                    End If
                End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbWP_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbDataKind_Disp
    '機　能：ﾃﾞｰﾀ種別ｺﾝﾎﾞ設定
    '引　数：ltypMasDefineAns：ﾃﾞｰﾀ構造体
    '戻り値：なし
    '作成日：2007/05/22 (Tue) 08:52:40 N.Kasai
    '更新日：2007/05/22 (Tue) 08:52:40
    '備　考：
    Private Sub prvcmbDataKind_Disp(ByRef ltypMasDefineAns As MasDefineAns)

        Dim llngCnt     As Integer  'ｶｳﾝﾄ

        Try
                
                '@ﾃﾞｰﾀ種別ｾｯﾄ
                With cmbDataKind
                    .Clear
                    For llngCnt = 0 To ltypMasDefineAns.lngMasDefineListCnt - 1
                        '@【ID名/ID】
                        .AddItem(ltypMasDefineAns.typMasDefineList(llngCnt).strName & vbTab & _
                                ltypMasDefineAns.typMasDefineList(llngCnt).strId)
                    Next llngCnt
                    
                    '@1件の場合、ﾃﾞﾌｫﾙﾄ表示
                    If .ListCount = 1 Then
                        '@1件目表示
                        .ListIndex = 0
                    End If
                End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbDataKind_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnProcEnd_Chk
    '機　能：確定ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:正常、False:異常
    '作成日：2006/02/28 (Tue) 17:33:26 N.Kasai
    '更新日：2006/02/28 (Tue) 17:33:26
    '備　考：
    Private Function prvblnProcEnd_Chk() As Boolean

        Dim lblnAns     As Boolean  '戻り値
        Dim llngCnt     As Integer  'ｶｳﾝﾀ
        
        Try
            
            With vsfFbParameterList
            
                '@戻り値の初期化
                lblnAns = False
                prvblnProcEnd_Chk = False
                
                '@ｸﾞﾘｯﾄﾞ内検索
                For llngCnt = 1 To .Rows.Count - 1
                    '@変更値に値が設定されている場合
                    If .GetData(llngCnt, CMlngvsfListColNewValue) <> vbNullString Then
                        
                        '@------------------------
                        '@数値であること
                        '@------------------------
                        If IsNumeric(.GetData(llngCnt, CMlngvsfListColNewValue)) = False Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007Q)
                            '@"<TRM7QW>$$数値を入力して下さい。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            .Row = llngCnt
                            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 ）
                            Call pubVsfBeforeSort(vsfFbParameterList, CMlngvsfListColNo)
                            '@ｶﾚﾝﾄ行の設定（ｸﾞﾘｯﾄﾞ、保持列 、前頁、次頁 ）
                            Call pubVsfAfterSort(vsfFbParameterList, CMlngvsfListColNo, cmdUP, cmdDown)
                            '@編集可能ｾﾙの場合
                            .Select(llngCnt, CMlngvsfListColNewValue)    '編集可能ｾﾙの範囲選択
                            .StartEditing()                                   '編集可能にする
                            Exit Function
                        End If
                        '@------------------------
                        '@現在値≠変更値であること
                        '@------------------------
                        If .GetData(llngCnt, CMlngvsfListColItemValue) = _
                                    .GetData(llngCnt, CMlngvsfListColNewValue) Then
                                    
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007R)
                            '@"<TRM7RW>$$現行値と変更値が同じ値です。$設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            .Row = llngCnt
                            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 ）
                            Call pubVsfBeforeSort(vsfFbParameterList, CMlngvsfListColNo)
                            '@ｶﾚﾝﾄ行の設定（ｸﾞﾘｯﾄﾞ、保持列 、前頁、次頁 ）
                            Call pubVsfAfterSort(vsfFbParameterList, CMlngvsfListColNo, cmdUP, cmdDown)
                            '@編集可能ｾﾙの場合
                            .Select(llngCnt, CMlngvsfListColNewValue)    '編集可能ｾﾙの範囲選択
                            .StartEditing()                                   '編集可能にする
                            Exit Function
                                    
                        End If
                        '@------------------------
                        '@下限値範囲ﾁｪｯｸ
                        '@------------------------
                        '@下限値が数値以外の場合は比較の対象外
                        If IsNumeric(.GetData(llngCnt, CMlngvsfListColLowerValue)) = True Then
                            '@現在値が下限値の範囲内であること
                            If .GetData(llngCnt, CMlngvsfListColNewValue) < _
                                        .GetData(llngCnt, CMlngvsfListColLowerValue) Then
                                        
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007S)
                                '@"<TRM7SW>$$変更値が下限値を超えています。$設定を見直してください。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 ）
                                Call pubVsfBeforeSort(vsfFbParameterList, CMlngvsfListColNo)
                                '@ｶﾚﾝﾄ行の設定（ｸﾞﾘｯﾄﾞ、保持列 、前頁、次頁 ）
                                Call pubVsfAfterSort(vsfFbParameterList, CMlngvsfListColNo, cmdUP, cmdDown)
                                '@編集可能ｾﾙの場合
                                .Select(llngCnt, CMlngvsfListColNewValue)    '編集可能ｾﾙの範囲選択
                                .StartEditing()                                   '編集可能にする
                                Exit Function
                            End If
                        End If
                        '@------------------------
                        '@上限値範囲ﾁｪｯｸ
                        '@------------------------
                        '@上限値が数値以外の場合は比較の対象外
                        If IsNumeric(.GetData(llngCnt, CMlngvsfListColUpperValue)) = True Then
                            '@現在値が上限値の範囲内であること
                            If .GetData(llngCnt, CMlngvsfListColNewValue) > _
                                        .GetData(llngCnt, CMlngvsfListColUpperValue) Then
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007T)
                                '@"<TRM7TW>$$変更値が上限値を超えています。$設定を見直してください。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 ）
                                Call pubVsfBeforeSort(vsfFbParameterList, CMlngvsfListColNo)
                                '@ｶﾚﾝﾄ行の設定（ｸﾞﾘｯﾄﾞ、保持列 、前頁、次頁 ）
                                Call pubVsfAfterSort(vsfFbParameterList, CMlngvsfListColNo, cmdUP, cmdDown)
                                
                                '@編集可能ｾﾙの場合
                                .Select(llngCnt, CMlngvsfListColNewValue)    '編集可能ｾﾙの範囲選択
                                .StartEditing()                                   '編集可能にする
                                Exit Function
                            End If
                        End If
                        '@値発見！！
                        lblnAns = True
                    End If
                Next
                
                '@ﾁｪｯｸ判定
                If lblnAns = True Then
                    '@ﾁｪｯｸOK
                    prvblnProcEnd_Chk = True
                End If
            
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


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfFbParameterList.BeforeDoubleClick

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
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfFbParameterList.KeyDownEdit

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
    
End Class
