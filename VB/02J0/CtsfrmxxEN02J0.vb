'ﾌｧｲﾙ名：xxEN02J0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：TEOS F/B変更/参照 メインフォーム
'作成日：2012/02/17 (Fri) 24:00:00 H.Hayashi
'更新日：2012/02/17 (Fri) 24:00:00
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2012-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02J0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02J0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02J0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02J0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02J0)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    '******************************************************************************************
    '                                       *定数の記述*
    '******************************************************************************************
    '=========================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                 As String = "01.00"

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN02J0      'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrfb_teosresultcondlistVer     As String = "01.00"             'TEOS F/B 結果検索条件取得
    Private Const CMstrfb_teosresultlistVer         As String = "01.00"             'TEOS F/B 結果取得
    Private Const CMstrfb_teosresultupdateVer       As String = "01.00"             'TEOS F/B 結果更新
    Private Const CMstrmas_wplist__Ver              As String = "05.01"             '装置一覧取得

    '@ｸﾞﾘｯﾄﾞの初期値定数宣言
    Private Const CMstrGridFontName                 As String = "ＭＳ ゴシック"     'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄ名
    Private Const CMlngGridFontSize                 As Integer = 11                 'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngGridFixedCols                As Integer = 0                  'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngGridFixedRows                As Integer = 1                  'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngGridTitleHeight              As Integer = 20                 'ﾍｯﾀﾞｰの高さ
    Private Const CMlngGridRowHeight                As Integer = 18                 '1明細の高さ
    Private Const CMlngGridPageRows                 As Integer = 10                 '1ﾍﾟｰｼﾞのｾﾙの行数
    Private Const CMlngGrid3DBlank                  As Integer = 4                  'ｸﾞﾘｯﾄﾞの3D表示の余白
    Private Const CMlngGridRowTitle                 As Integer = 0                  'ﾀｲﾄﾙ行(行)
    Private Const CMlngGridScrollBarWidth           As Integer = 16                 '縦ｽｸﾛｰﾙﾊﾞｰの幅

    '@vsf共通のｶﾗﾑ定数
    Private Const CMlngvsfFbListRowTitle            As Integer = 0                  '行ﾀｲﾄﾙ
    Private Const CMlngvsfFbListColTitle            As Integer = 0                  '列ﾀｲﾄﾙ
    Private Const CMlngvsfFbListHHeight             As Integer = 33                 'ﾍｯﾀﾞｰ高さ
    Private Const CMlngvsfFbListHeight              As Integer = 18                 '行高さ
    Private Const CMlngvsfFbListHFontSize           As Integer = 11                 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ：11
    Private Const CMlngvsfFbListFontSize            As Integer = 11                 'ﾌｫﾝﾄｻｲｽﾞ：11

    '@ｸﾞﾘｯﾄﾞの列設定
    Private Const CMlngvsfFbListNo                  As Integer = 0                  'No
    Private Const CMlngvsfFbListState               As Integer = 1                  '状態
    Private Const CMlngvsfFbListEntryTime           As Integer = 2                  '実施日時
    Private Const CMlngvsfFbListFbStatName          As Integer = 3                  '更新種別
    Private Const CMlngvsfFbListProcessTime         As Integer = 4                  '補正値(sec)
    Private Const CMlngvsfFbListMinProcessTime      As Integer = 5                  '補正DEPO時間Min(sec)
    Private Const CMlngvsfFbListMaxProcessTime      As Integer = 6                  '補正DEPO時間Max(sec)
    Private Const CMlngvsfFbListFbLotId             As Integer = 7                  '補正ﾛｯﾄID
    Private Const CMlngvsfFbListFbRecipeId1         As Integer = 8                  '補正ﾚｼﾋﾟ1
    Private Const CMlngvsfFbListFbRecipeId2         As Integer = 9                  '補正ﾚｼﾋﾟ2
    Private Const CMlngvsfFbListUserName            As Integer = 10                 '実施ﾕｰｻﾞ

    '@ｸﾞﾘｯﾄﾞの幅設定
    Private Const CMlngvsfFbListNoW                 As Integer = 39                 'No
    Private Const CMlngvsfFbListStateW              As Integer = 41                 '状態
    Private Const CMlngvsfFbListEntryTimeW          As Integer = 167                '実施日時
    Private Const CMlngvsfFbListFbStatNameW         As Integer = 137                '更新種別
    Private Const CMlngvsfFbListProcessTimeW        As Integer = 120                '補正値(sec)
    Private Const CMlngvsfFbListMinProcessTimeW     As Integer = 120                '補正DEPO時間Min(sec)
    Private Const CMlngvsfFbListMaxProcessTimeW     As Integer = 120                '補正DEPO時間Max(sec)
    Private Const CMlngvsfFbListFbLotIdW            As Integer = 104                '補正ﾛｯﾄID
    Private Const CMlngvsfFbListFbRecipeId1W        As Integer = 104                '補正ﾚｼﾋﾟ1
    Private Const CMlngvsfFbListFbRecipeId2W        As Integer = 104                '補正ﾚｼﾋﾟ2
    Private Const CMlngvsfFbListUserNameW           As Integer = 180                '実施ﾕｰｻﾞ

    '@ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ設定
    Private Const CMstrvsfFbListNoT                 As String = "No"
    Private Const CMstrvsfFbListStateT              As String = "状態"
    Private Const CMstrvsfFbListEntryTimeT          As String = "実施日時"
    Private Const CMstrvsfFbListFbStatNameT         As String = "更新種別"
    Private Const CMstrvsfFbListProcessTimeT        As String = "DEPO時間[sec]"
    Private Const CMstrvsfFbListMinProcessTimeT     As String = "DEPO時間[sec]"&ChrW(13)&ChrW(10)&"下限値"
    Private Const CMstrvsfFbListMaxProcessTimeT     As String = "DEPO時間[sec]"&ChrW(13)&ChrW(10)&"上限値"
    Private Const CMstrvsfFbListFbLotIdT            As String = "補正ロットID"
    Private Const CMstrvsfFbListFbRecipeId1T        As String = "補正レシピ1"
    Private Const CMstrvsfFbListFbRecipeId2T        As String = "補正レシピ2"
    Private Const CMstrvsfFbListUserNameT           As String = "実施者"

    '@色宣言
    Private Const CMlngEnableFalseColor             As Integer = &HE0E0E0           '灰色(使用不可)
    Private Const CMlngOkForeColor                  As Integer = &H000000           '黒色(通常色)
    Private Const CMlngBKColorCel                   As Integer = &HFFC0C0           '薄紫(ｸﾞﾘｯﾄﾞ選択時のﾊﾞｯｸｶﾗｰ)

    '@TEOS F/B結果 更新･禁止･解除理由
    Private Const CMlngDepoDataUpdate               As Integer = 2                  '手動補正値更新
    Private Const CMlngUpdateNg                     As Integer = 3                  '書き換え禁止開始設定
    Private Const CMlngUpdateOk                     As Integer = 4                  '書き換え禁止解除設定

    '******************************************************************************************
    '                                       *変数の記述*
    '******************************************************************************************
    '=========================================Private==========================================
    Private llngWpCnt                               As Integer                      '装置IDのｶｳﾝﾄ
    Private ltypFbTeosResultCondList                As typFbTeosResultCondList      'TEOS F/B結果検索条件ﾘｽﾄ
    Private lpubTypFbTeosRresultList                As pubTypFbTeosRresultList      'TEOS F/B結果ﾘｽﾄ

    Private buttonProcessing                        As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                      'NSYS WindowCloseフラグ
    Private mIntFbListBeforeSortRow                 As Integer                      'NSYS グリッドのソート前選択行

    '******************************************************************************************
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
    '                                 *イベントハンドラの記述*
    '******************************************************************************************
    '=========================================Private==========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：

    Private Sub Form_Load()
        Dim llngCnt         As Integer      'ｶｳﾝﾀ
        Dim lblnAns         As Boolean      '戻り値
        Dim lstrFormName    As String       'ﾌｫｰﾑ名
        Dim lstrEventName   As String       'ｲﾍﾞﾝﾄ名

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02J0, CMstrLocalVersion)

            '@戻り値の判定
            '@異常終了の場合
            If lblnAns = False Then
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            
            End If

            '@画面初期化
            Call prvfrmxxEN02J0_Init()

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞｾｯﾄ
            pblnFormLoad = True

            '@ﾘｱｸﾀを選択不可
            With cmbRc
                .Text = vbNullString                    'NULL
                .Enabled = False                        '無効
            End With
            
            '@ﾚｼﾋﾟを選択不可
            With cmbRecipe
                .Text = vbNullString                    'NULL
                .Enabled = False                        '無効
            End With

            '@更新種別を選択不可
            With cmbEvent
                .Text = vbNullString                    'NULL
                .Enabled = False                        '無効
            End With
            
            '@初期値
            lblNowDate.Text = vbNullString                                       '情報取得日時表示
            lbDepoDataCnt.Text = Format$(CPlngNumZero, CPstrDateFormatKanma)     '該当件数
            
            
            '@検索を選択不可
            cmdSerch.Enabled = False                    '無効
            
            '@ﾚｽﾎﾟﾝ開始
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@装置一覧取
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, _
                                       llngWpCnt, _
                                       pstrSBID, _
                                       CPstrCD02, _
                                       , , , , CPstrEqTypeTEOS)
                                       
            '@結果判定
            With cmbWpID
                
                '@成功の場合
                If lblnAns = True Then

                    '@初期化
                    .Clear()
                    .BackColor = SystemColors.Window
                    .ColAlignment(0) = TextAlignEnum.LeftCenter
                    llngCnt = 0
                    
                    '装置ﾘｽﾄ有り
                    If llngWpCnt > 0 Then
                    
                        For llngCnt = 0 To llngWpCnt - 1
                            
                            '@ﾘｽﾄｾｯﾄ
                            .AddItem (ptypWPList(llngCnt).strWpName _
                                   & vbTab _
                                   & ptypWPList(llngCnt).strWpID)
                                   
                        Next
                        
                    End If
                    
                '@異常の場合終了
                Else
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose

                    Exit Sub
                
                End If

            End With

            '@ﾚｽﾎﾟﾝｽ終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

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

    '関数名：cmdClose_Click
    '機　能："閉じる"ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo  As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@画面初期化実行
            Call prvfrmxxEN02J0_Init()

            '@終了関数を実行する
            Call publngEnd_Proc(CPstrKeyEN02J0, ltypCommonInfo)

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


    '関数名：cmbWpID_Change
    '機　能：装置情報変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：

    Private Sub cmbWpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpID.Change
        Dim lblnAns         As Boolean      '戻り値
        Dim llngCnt         As Integer      'ｶｳﾝﾀ
        Dim lstrFormName    As String       'ﾌｫｰﾑ名
        Dim lstrEventName   As String       'ｲﾍﾞﾝﾄ名
        
        Try

            '@ﾘｱｸﾀを選択不可
            With cmbRc
                .Text = vbNullString                    'NULL
                .Enabled = False                        '無効
            End With
            
            '@ﾚｼﾋﾟを選択不可
            With cmbRecipe
                .Text = vbNullString                    'NULL
                .Enabled = False                        '無効
            End With

            '@更新種別を選択不可
            With cmbEvent
                .Text = vbNullString                    'NULL
                .Enabled = False                        '無効
            End With

            '@初期値
            lblNowDate.Text = vbNullString                                       '情報取得日時表示
            lbDepoDataCnt.Text = Format$(CPlngNumZero, CPstrDateFormatKanma)     '該当件数
            
            '@検索を選択不可
            cmdSerch.Enabled = False                    '無効

            '@ﾚｽﾎﾟﾝ開始
            lstrFormName = Me.Name
            lstrEventName = "cmbWpID_Change"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ﾘｽﾄよりWP_ID取得のため
            cmbWpID.ValueCol = 1

            '@TEOS F/B 結果検索条件取得
            lblnAns = pubblnFbTeosResultCondList_Sel(CMstrfb_teosresultcondlistVer, _
                                                     pstrSBID, _
                                                     cmbWpID.Value, _
                                                     ltypFbTeosResultCondList)
            '@解除
            cmbWpID.ValueCol = 0
            
            '@成功の場合
            If lblnAns = True Then
            
                '@ﾘｱｸﾀﾘｽﾄ
                With cmbRc
                               
                    '@初期化
                    .Clear()
                    .ColAlignment(0) = TextAlignEnum.LeftCenter
                    llngCnt = 0

                    '@TEOS F/B結果検索条件 ﾘｱｸﾀ情報有り
                    If ltypFbTeosResultCondList.lngRcListCnt > 0 Then
                        
                        For llngCnt = 0 To ltypFbTeosResultCondList.lngRcListCnt - 1
                            
                            '@ﾘｽﾄｾｯﾄ
                            .AddItem (ltypFbTeosResultCondList.rcList(llngCnt).strRcName _
                                      & vbTab _
                                      & ltypFbTeosResultCondList.rcList(llngCnt).strRc)
                        
                        Next

                        '@ﾘｱｸﾀを選択可
                        With cmbRc
                            .Text = vbNullString        'NULL
                            .Enabled = True             '有効
                        End With

                    End If

                End With
           
                '@ﾚｼﾋﾟﾘｽﾄ
                With cmbRecipe

                    '@初期化
                    .Clear()
                    .ColAlignment(0) = TextAlignEnum.LeftCenter
                    llngCnt = 0

                    '@TEOS F/B結果検索条件 ﾚｼﾋﾟ情報有り
                    If ltypFbTeosResultCondList.lngRecipeListCnt > 0 Then
                        
                        For llngCnt = 0 To ltypFbTeosResultCondList.lngRecipeListCnt - 1
                            
                            '@ﾘｽﾄｾｯﾄ
                            .AddItem (ltypFbTeosResultCondList.recipeList(llngCnt).strRecipeId)
                        
                        Next
                    
                    End If

                End With
           
                '@更新種別ﾘｽﾄ
                With cmbEvent

                    '@初期化
                    .Clear()
                    .ColAlignment(0) = TextAlignEnum.LeftCenter
                    llngCnt = 0
                    
                    '@TEOS F/B結果検索条件 更新種別情報有り
                    If ltypFbTeosResultCondList.lngFbReasonListCnt > 0 Then
                    
                        For llngCnt = 0 To ltypFbTeosResultCondList.lngFbReasonListCnt - 1
                        
                            '@ﾘｽﾄｾｯﾄ
                            .AddItem (ltypFbTeosResultCondList.fbReasonList(llngCnt).strFbReasonName _
                                      & vbTab _
                                      & ltypFbTeosResultCondList.fbReasonList(llngCnt).strFbReasonId)
                                                    
                        Next
                    
                    End If
                    
                End With
                
            '@異常の場合終了
            Else

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
                
            End If
            
            '@ﾚｽﾎﾟﾝｽ終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWpID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbRc_Change
    '機　能：ﾘｱｸﾀ情報変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：

    Private Sub cmbRc_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRc.Change

        Try

            '@ﾚｼﾋﾟ情報ｸﾘｱｰ
            cmbRecipe.ListIndex = -1

            '@更新種別情報ｸﾘｱｰ
            cmbEvent.ListIndex = -1

            '@画面初期化
            Call prvfrmxxEN02J0_Init()
            
            '@ﾚｼﾋﾟを選択可
             With cmbRecipe
               .Text = vbNullString                    'NULL
               .Enabled = True                         '有効
             End With

            '@更新種別を選択不可
            With cmbEvent
               .Text = vbNullString                    'NULL
               .Enabled = False                        '無効
            End With

            '@初期値
            lblNowDate.Text = vbNullString                                       '情報取得日時表示
            lbDepoDataCnt.Text = Format$(CPlngNumZero, CPstrDateFormatKanma)     '該当件数
            
            '@検索を選択不可
            cmdSerch.Enabled = False                    '無効
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRc_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRecipe_Change
    '機　能：ﾚｼﾋﾟ情報変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：

    Private Sub cmbRecipe_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRecipe.Change
        
        Try
            
            '@更新種別情報ｸﾘｱｰ
            cmbEvent.ListIndex = -1
            
            '@画面初期化
            Call prvfrmxxEN02J0_Init()
            
            '@更新種別を選択可
            With cmbEvent
               .Text = vbNullString                    'NULL
               .Enabled = True                         '有効
            End With

            '@初期値
            lblNowDate.Text = vbNullString                                       '情報取得日時表示
            lbDepoDataCnt.Text = Format$(CPlngNumZero, CPstrDateFormatKanma)     '該当件数
            
            '@検索を選択不可
            cmdSerch.Enabled = False                    '無効
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRecipe_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbEvent_Change
    '機　能：更新種別情報変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：

    Private Sub cmbEvent_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbEvent.Change

        Try
            
            '@画面初期化
            Call prvfrmxxEN02J0_Init()
            
            '@初期値
            lblNowDate.Text = vbNullString                                       '情報取得日時表示
            lbDepoDataCnt.Text = Format$(CPlngNumZero, CPstrDateFormatKanma)     '該当件数

            '@検索を選択可
            cmdSerch.Enabled = True                    '有効
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbEvent_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdSerch_Click
    '機　能：検索実行
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：

    Private Sub cmdSerch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSerch.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾃﾞｰﾀを検索して表示する
            Call prvvsfFbListShow()

            '初期化
            lblOldDepoData.Text = vbNullString
            With txtNewDepoData
                .Text = vbNullString                                           'NULL
                .BackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)  'ｸﾞﾚｰ
                .Enabled = False                                               '無効
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSerch_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtNewDepoData_Change
    '機　能：補正値入力変更制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：

    Private Sub txtNewDepoData_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtNewDepoData.Change

        Try

            '@入力状況を判定（1文字でも入力している場合）
            If txtNewDepoData.Text <> vbNullString Then
                
                '@補正値手動設定ﾎﾞﾀﾝ使用可
                cmdDepoDataUpdate.Enabled = True
                
                '@補正値書換禁止ﾎﾞﾀﾝ使用不可
                cmdUpdateNg.Enabled = False
                
                '@補正値書換許可ﾎﾞﾀﾝ使用不可
                cmdUpdateOk.Enabled = False

            Else
            
                '@補正値手動設定ﾎﾞﾀﾝ使用不可
                cmdDepoDataUpdate.Enabled = False

                If vsfFbList.Row >= CMlngGridRowTitle Then
                    '@ﾃﾞｰﾀﾘｽﾄ表示されている状態が有効の場合
                    If vsfFbList.GetData(vsfFbList.Row, CMlngvsfFbListState) = CPstrStateFbData Then

                        '@補正値書換禁止ﾎﾞﾀﾝ使用可
                        cmdUpdateNg.Enabled = True
                    
                        '@補正値書換許可ﾎﾞﾀﾝ使用不可
                        cmdUpdateOk.Enabled = False
           
                    '@ﾃﾞｰﾀﾘｽﾄ表示されている状態が禁止の場合
                    ElseIf vsfFbList.GetData(vsfFbList.Row, CMlngvsfFbListState) = CPstrStateFbNg Then

                        '@補正値書換禁止ﾎﾞﾀﾝ使用不可
                        cmdUpdateNg.Enabled = False
                    
                        '@補正値書換許可ﾎﾞﾀﾝ使用可
                        cmdUpdateOk.Enabled = True
                    
                    Else

                        '@補正値書換禁止ﾎﾞﾀﾝ使用不可
                        cmdUpdateNg.Enabled = False
                    
                        '@補正値書換許可ﾎﾞﾀﾝ使用不可
                        cmdUpdateOk.Enabled = False
            
                    End If

                Else
                    '@補正値書換禁止ﾎﾞﾀﾝ使用不可
                    cmdUpdateNg.Enabled = False
                    
                    '@補正値書換許可ﾎﾞﾀﾝ使用不可
                    cmdUpdateOk.Enabled = False

                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtNewDepoData_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbList_EnterCell
    '機　能：補正値入力前ﾃﾞｰﾀ表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：

    Private Sub vsfFbList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFbList.EnterCell

        Try
            
            '@変更前DEPO時間
            lblOldDepoData.Text = vbNullString       'NULL
           
            '@変更後DEPO時間
            With txtNewDepoData
                .Text = vbNullString                                          'NULL
                .BackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor) 'ｸﾞﾚｰ
                .Enabled = False                                              '無効(使用不可)
            End With

            If vsfFbList.Row >= CMlngGridRowTitle Then
                '@ﾃﾞｰﾀﾘｽﾄ表示されている状態が有効の場合
                If vsfFbList.GetData(vsfFbList.Row, CMlngvsfFbListState) = CPstrStateFbData Then

                    '@補正値書換禁止ﾎﾞﾀﾝ使用可
                    cmdUpdateNg.Enabled = True

                    '@補正値書換許可ﾎﾞﾀﾝ使用不可
                    cmdUpdateOk.Enabled = False

                '@ﾃﾞｰﾀﾘｽﾄ表示されている状態が禁止の場合
                ElseIf vsfFbList.GetData(vsfFbList.Row, CMlngvsfFbListState) = CPstrStateFbNg Then

                    '@補正値書換禁止ﾎﾞﾀﾝ使用不可
                    cmdUpdateNg.Enabled = False

                    '@補正値書換許可ﾎﾞﾀﾝ使用可
                    cmdUpdateOk.Enabled = True

                Else

                    '@補正値書換禁止ﾎﾞﾀﾝ使用不可
                    cmdUpdateNg.Enabled = False

                    '@補正値書換許可ﾎﾞﾀﾝ使用不可
                    cmdUpdateOk.Enabled = False

                End If
            Else
                '@補正値書換禁止ﾎﾞﾀﾝ使用不可
                cmdUpdateNg.Enabled = False

                '@補正値書換許可ﾎﾞﾀﾝ使用不可
                cmdUpdateOk.Enabled = False

            End If

            '@ﾃﾞｰﾀﾘｽﾄ表示が一件以上存在する場合
            If vsfFbList.Row > 0 Then

                '@ﾃﾞｰﾀﾘｽﾄ表示されている状態が有効の場合
                If vsfFbList.GetData(vsfFbList.Row, CMlngvsfFbListState) = CPstrStateFbData Then

                    '@変更前DEPO時間表示
                    lblOldDepoData.Text = Format$(vsfFbList.GetData(vsfFbList.Row, CMlngvsfFbListProcessTime), CPstrDoubleFormat1String)

                    '@変更後DEPO時間使用可
                    With txtNewDepoData
                        .Text = vbNullString                    'NULL
                        .BackColor = Color.White                '白
                        .Enabled = True                         '有効(使用可)
                    End With

                End If

            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbList_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDepoDataUpdate_Click
    '機　能：補正値手動設定ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：
    Private Sub cmdDepoDataUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDepoDataUpdate.Click

        Dim lblnAns                 As Boolean      '結果取得(True:正常,False:異常)
        Dim lstrMsg                 As String       '変換後ﾒｯｾｰｼﾞ
        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim llngAddCnt              As Integer      'ｸﾞﾘｯﾄﾞ行を示す表示用ｶｳﾝﾀ
        Dim lstrTeosFbUpdateResult  As String       '更新結果(0:更新成功，1:更新失敗)
        Dim lstrFormName            As String       'ﾌｫｰﾑ名
        Dim lstrEventName           As String       'ｲﾍﾞﾝﾄ名
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                
                '@一覧にｾｯﾄﾌｫｰｶｽｾｯﾄ
                With vsfFbList
                
                    If .Enabled = True Then
                        
                        '@ﾌｫｰｶｽ設定
                        Call pubSetFocus(vsfFbList)
                    
                    End If
                
                End With
            
                Exit Sub
            End If
            
            '@ﾘｽﾄ選択不可
            vsfFbList.Enabled = False                                   'ﾘｽﾄ選択可不可
            
            '@ﾚｽﾎﾟﾝ開始
            lstrFormName = Me.Name
            lstrEventName = "cmdDepoDataUpdate_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡す為
            cmbWpID.ValueCol = 1
            cmbRc.ValueCol = 1
            cmbEvent.ValueCol = 1

            '@TEOS F/B 計算結果更新
            lblnAns = pubblnFbTeosResult_Update(CMstrfb_teosresultupdateVer, _
                                        pstrSBID, _
                                        cmbWpID.Value, _
                                        cmbRc.Value, _
                                        cmbRecipe.Value, _
                                        CMlngDepoDataUpdate, _
                                        txtNewDepoData.Text, _
                                        pstrUserID, _
                                        lstrTeosFbUpdateResult)

            '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡したため元に戻す
            cmbWpID.ValueCol = 0
            cmbRc.ValueCol = 0
            cmbEvent.ValueCol = 0
            
            '@結果取得
            If lblnAns = True Then

                '@表示ﾒｯｾｰｼﾞ変換(<TRM7EI>$$DEPO時間(%1→%2)を変更しました。装置[%3]リアクタ[%4]レシピ[%5])
                lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf007E, _
                                    Format$(vsfFbList.GetData(vsfFbList.Row, CMlngvsfFbListProcessTime), CPstrDoubleFormat1String), _
                                    Format$(CDbl(txtNewDepoData.Text), CPstrDoubleFormat1String), cmbWpID.Value, cmbRc.Value, cmbRecipe.Value)

                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(lstrMsg)

                '@更新失敗の場合
                If lstrTeosFbUpdateResult <> 0 Then
                    '@表示ﾒｯｾｰｼﾞ変換(<TRM119W>$$DEPO時間(%1→%2)の更新失敗。装置[%3]リアクタ[%4]レシピ[%5])
                    lstrMsg = pubstrMsgReplace_Set(CPstrMsgWar0119, _
                                    Format$(vsfFbList.GetData(vsfFbList.Row, CMlngvsfFbListProcessTime), CPstrDoubleFormat1String), _
                                    Format$(CDbl(txtNewDepoData.Text), CPstrDoubleFormat1String), cmbWpID.Value, cmbRc.Value, cmbRecipe.Value)

                    '@ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(lstrMsg)

                    '@ｴﾗｰﾒｯｾｰｼﾞ表示(<TRM119W>$$DEPO時間(%1→%2)の更新失敗。装置[%3]リアクタ[%4]レシピ[%5])
                    pstrDMsg = lstrMsg
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                End If
            
                '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡す為
                cmbWpID.ValueCol = 1
                cmbRc.ValueCol = 1
                cmbEvent.ValueCol = 1
            
                '@TEOS F/B 計算結果ﾃﾞｰﾀ検索
                lblnAns = pubblnFbTeosResult_Sel(CMstrfb_teosresultlistVer, _
                                        pstrSBID, _
                                        cmbWpID.Value, _
                                        cmbRc.Value, _
                                        cmbRecipe.Value, _
                                        cmbEvent.Value, _
                                        lpubTypFbTeosRresultList)
                                        
                '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡したため元に戻す
                cmbWpID.ValueCol = 0
                cmbRc.ValueCol = 0
                cmbEvent.ValueCol = 0

                '@結果判定
                '@成功の場合
                If lblnAns = True Then
                   
                    lblNowDate.Text = Format$(Now, CPstrDateFormat)                      '情報取得日時表示
         
                    '@取得結果をｸﾞﾘｯﾄﾞに表示
                    With lpubTypFbTeosRresultList

                        vsfFbList.Redraw = False
                        RemoveHandler vsfFbList.EnterCell, AddressOf vsfFbList_EnterCell

                        '@新規表示の場合
                        vsfFbList.Rows.Count = 1

                        '@変数のﾃﾞｰﾀ数文ﾙｰﾌﾟする
                        llngAddCnt = 1
                        For llngCnt = 0 To .lngFbTeosRresultListCnt - 1

                            '@ﾃﾞｰﾀは表示
                            vsfFbList.Rows.Count = vsfFbList.Rows.Count + 1
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListNo, _
                                                                    llngAddCnt)                                                                          'No
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListState, _
                                                                    .fbTeosRresultList(llngCnt).strState)                                                '状態
                            If IsDate(.fbTeosRresultList(llngCnt).strEntryTime) Then
                                vsfFbList.SetData(llngAddCnt, CMlngvsfFbListEntryTime, _
                                                                    Format(CDate(.fbTeosRresultList(llngCnt).strEntryTime), CPstrDateTimeYMDHMS))        '実施日時
                            Else
                                vsfFbList.SetData(llngAddCnt, CMlngvsfFbListEntryTime, _
                                                                    .fbTeosRresultList(llngCnt).strEntryTime)                                            '実施日時
                            End If
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbStatName, _
                                                                    .fbTeosRresultList(llngCnt).strFbStatName)                                           '更新種別
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListProcessTime, _
                                                                    .fbTeosRresultList(llngCnt).strProcessTime)                                          '補正値(sec)
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListMinProcessTime, _
                                                                    .fbTeosRresultList(llngCnt).strMinProcessTime)                                       '補正DEPO時間Min(sec)
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListMaxProcessTime, _
                                                                    .fbTeosRresultList(llngCnt).strMaxProcessTime)                                       '補正DEPO時間Max(sec)
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbLotId, _
                                                                    .fbTeosRresultList(llngCnt).strFbLotId)                                              '補正ﾛｯﾄID
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbRecipeId1, _
                                                                    .fbTeosRresultList(llngCnt).strFbRecipeId1)                                          '補正ﾚｼﾋﾟ1
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbRecipeId2, _
                                                                    .fbTeosRresultList(llngCnt).strFbRecipeId2)                                          '補正ﾚｼﾋﾟ2
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListUserName, _
                                                                    .fbTeosRresultList(llngCnt).strUserName)                                             '実施ﾕｰｻﾞ
                    
                            llngAddCnt = llngAddCnt + 1

                        Next llngCnt

                        AddHandler vsfFbList.EnterCell, AddressOf vsfFbList_EnterCell
                        vsfFbList.Row = CMlngGridRowTitle
                        vsfFbList.Redraw = True

                    End With
                
                    lbDepoDataCnt.Text = Format$(vsfFbList.Rows.Count - 1, CPstrDateFormatKanma)    '該当件数
                    vsfFbList.Enabled = True
         
                    '@変更前DEPO時間
                    lblOldDepoData.Text = vbNullString       'NULL
           
                    '@変更後DEPO時間
                    With txtNewDepoData
                        .Text = vbNullString                                          'NULL
                        .BackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor) 'ｸﾞﾚｰ
                        .Enabled = False                                              '無効(使用不可)
                    End With
                    
                    '@検索ﾃﾞｰﾀが存在した場合
                    If llngAddCnt - 1 > 0 Then
                        vsfFbList.Enabled = True                                                    'ﾘｽﾄ選択可能化
                    End If
                
                    '@表示位置を左に移動
                    vsfFbList.ShowCell(0, CMlngvsfFbListEntryTime)
                    
                Else
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                    
                    Exit Sub
                
                End If
                
            Else

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                 Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                 Me.CancelButton = cmdClose
                    
                Exit Sub
            
            End If
            
            '@ﾚｽﾎﾟﾝｽ終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDepoDataUpdate_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUpdateOk_Click
    '機　能：補正値書換解除設定ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：
    Private Sub cmdUpdateOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateOk.Click

        Dim lblnAns                 As Boolean      '結果取得(True:正常,False:異常)
        Dim lstrMsg                 As String       '変換後ﾒｯｾｰｼﾞ
        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim llngAddCnt              As Integer      'ｸﾞﾘｯﾄﾞ行を示す表示用ｶｳﾝﾀ
        Dim lstrTeosFbUpdateResult  As String       '更新結果(0:更新成功，1:更新失敗)
        Dim lstrFormName            As String       'ﾌｫｰﾑ名
        Dim lstrEventName           As String       'ｲﾍﾞﾝﾄ名
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                
                '@一覧にｾｯﾄﾌｫｰｶｽｾｯﾄ
                With vsfFbList
                
                    If .Enabled = True Then
                        
                        '@ﾌｫｰｶｽ設定
                        Call pubSetFocus(vsfFbList)
                    
                    End If
                
                End With
            
                Exit Sub
            End If
            
            '@ﾘｽﾄ選択不可
            vsfFbList.Enabled = False                                                        'ﾘｽﾄ選択可不可
            
            '@ﾚｽﾎﾟﾝ開始
            lstrFormName = Me.Name
            lstrEventName = "cmdDepoDataUpdate_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡す為
            cmbWpID.ValueCol = 1
            cmbRc.ValueCol = 1
            cmbEvent.ValueCol = 1

            '@TEOS F/B 計算結果更新
            lblnAns = pubblnFbTeosResult_Update(CMstrfb_teosresultupdateVer, _
                                        pstrSBID, _
                                        cmbWpID.Value, _
                                        cmbRc.Value, _
                                        cmbRecipe.Value, _
                                        CMlngUpdateOk, _
                                        txtNewDepoData.Text, _
                                        pstrUserID, _
                                        lstrTeosFbUpdateResult)

            '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡したため元に戻す
            cmbWpID.ValueCol = 0
            cmbRc.ValueCol = 0
            cmbEvent.ValueCol = 0
            
            '@結果取得
            If lblnAns = True Then
                
                '@表示ﾒｯｾｰｼﾞ変換(<TRM7GI>$$更新禁止解除を行いました。装置[%1]リアクタ[%2]レシピ[%3])
                lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf007G, cmbWpID.Value, cmbRc.Value, cmbRecipe.Value)

                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(lstrMsg)

                '@更新失敗の場合
                If lstrTeosFbUpdateResult <> 0 Then
                    '@表示ﾒｯｾｰｼﾞ変換(<TRM122W>$$更新禁止解除の更新失敗。装置[%1]リアクタ[%2]レシピ[%3])
                    lstrMsg = pubstrMsgReplace_Set(CPstrMsgWar0122, cmbWpID.Value, cmbRc.Value, cmbRecipe.Value)

                    '@ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(lstrMsg)

                    '@ｴﾗｰﾒｯｾｰｼﾞ表示(<TRM122W>$$更新禁止解除の更新失敗。装置[%1]リアクタ[%2]レシピ[%3])
                    pstrDMsg = lstrMsg
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                End If
            
                '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡す為
                cmbWpID.ValueCol = 1
                cmbRc.ValueCol = 1
                cmbEvent.ValueCol = 1
            
                '@TEOS F/B 計算結果ﾃﾞｰﾀ検索
                lblnAns = pubblnFbTeosResult_Sel(CMstrfb_teosresultlistVer, _
                                        pstrSBID, _
                                        cmbWpID.Value, _
                                        cmbRc.Value, _
                                        cmbRecipe.Value, _
                                        cmbEvent.Value, _
                                        lpubTypFbTeosRresultList)
                                        
                '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡したため元に戻す
                cmbWpID.ValueCol = 0
                cmbRc.ValueCol = 0
                cmbEvent.ValueCol = 0

                '@結果判定
                '@成功の場合
                If lblnAns = True Then
                   
                    lblNowDate.Text = Format$(Now, CPstrDateFormat)                      '情報取得日時表示
         
                    '@取得結果をｸﾞﾘｯﾄﾞに表示
                    With lpubTypFbTeosRresultList

                        vsfFbList.Redraw = False
                        RemoveHandler vsfFbList.EnterCell, AddressOf vsfFbList_EnterCell

                        '@新規表示の場合
                        vsfFbList.Rows.Count = 1

                        '@変数のﾃﾞｰﾀ数文ﾙｰﾌﾟする
                        llngAddCnt = 1
                        For llngCnt = 0 To .lngFbTeosRresultListCnt - 1
                        
                            '@ﾃﾞｰﾀは表示
                            vsfFbList.Rows.Count = vsfFbList.Rows.Count + 1
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListNo, _
                                                                    llngAddCnt)                                                                          'No
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListState, _
                                                                    .fbTeosRresultList(llngCnt).strState)                                                '状態
                            If IsDate(.fbTeosRresultList(llngCnt).strEntryTime) Then
                                vsfFbList.SetData(llngAddCnt, CMlngvsfFbListEntryTime, _
                                                                    Format(CDate(.fbTeosRresultList(llngCnt).strEntryTime), CPstrDateTimeYMDHMS))        '実施日時
                            Else
                                vsfFbList.SetData(llngAddCnt, CMlngvsfFbListEntryTime, _
                                                                    .fbTeosRresultList(llngCnt).strEntryTime)                                            '実施日時
                            End If
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbStatName, _
                                                                    .fbTeosRresultList(llngCnt).strFbStatName)                                           '更新種別
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListProcessTime, _
                                                                    .fbTeosRresultList(llngCnt).strProcessTime)                                          '補正値(sec)
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListMinProcessTime, _
                                                                    .fbTeosRresultList(llngCnt).strMinProcessTime)                                       '補正DEPO時間Min(sec)
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListMaxProcessTime, _
                                                                    .fbTeosRresultList(llngCnt).strMaxProcessTime)                                       '補正DEPO時間Max(sec)
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbLotId, _
                                                                    .fbTeosRresultList(llngCnt).strFbLotId)                                              '補正ﾛｯﾄID
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbRecipeId1, _
                                                                    .fbTeosRresultList(llngCnt).strFbRecipeId1)                                          '補正ﾚｼﾋﾟ1
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbRecipeId2, _
                                                                    .fbTeosRresultList(llngCnt).strFbRecipeId2)                                          '補正ﾚｼﾋﾟ2
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListUserName, _
                                                                    .fbTeosRresultList(llngCnt).strUserName)                                             '実施者ﾕｰｻﾞ
                            llngAddCnt = llngAddCnt + 1

                        Next llngCnt

                        AddHandler vsfFbList.EnterCell, AddressOf vsfFbList_EnterCell
                        vsfFbList.Row = CMlngGridRowTitle
                        vsfFbList.Redraw = True

                    End With
                
                    lbDepoDataCnt.Text = Format$(vsfFbList.Rows.Count - 1, CPstrDateFormatKanma)    '該当件数
                    vsfFbList.Enabled = True
         
                    '@変更前DEPO時間
                    lblOldDepoData.Text = vbNullString       'NULL
           
                    '@変更後DEPO時間
                    With txtNewDepoData
                        .Text = vbNullString                                          'NULL
                        .BackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor) 'ｸﾞﾚｰ
                        .Enabled = False                                              '無効(使用不可)
                    End With
                    txtNewDepoData_Change(txtNewDepoData, New EventArgs())
                    
                    '@検索ﾃﾞｰﾀが存在した場合
                    If llngAddCnt - 1 > 0 Then
                        vsfFbList.Enabled = True                                                    'ﾘｽﾄ選択可能化
                    End If
                
                    '@表示位置を左に移動
                    vsfFbList.ShowCell(0, CMlngvsfFbListEntryTime)
                    
                Else
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                    
                    Exit Sub
                
                End If
                
            Else

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                 Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                    
                Exit Sub
            
            End If
            
            '@ﾚｽﾎﾟﾝｽ終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDepoDataUpdate_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDepoDataUpdate_Click
    '機　能：補正値書換禁止設定ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：
    Private Sub cmdUpdateNg_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdateNg.Click

        Dim lblnAns                 As Boolean      '結果取得(True:正常,False:異常)
        Dim lstrMsg                 As String       '変換後ﾒｯｾｰｼﾞ
        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim llngAddCnt              As Integer      'ｸﾞﾘｯﾄﾞ行を示す表示用ｶｳﾝﾀ
        Dim lstrTeosFbUpdateResult  As String       '更新結果(0:更新成功，1:更新失敗)
        Dim lstrFormName            As String       'ﾌｫｰﾑ名
        Dim lstrEventName           As String       'ｲﾍﾞﾝﾄ名
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                
                '@一覧にｾｯﾄﾌｫｰｶｽｾｯﾄ
                With vsfFbList
                
                    If .Enabled = True Then
                        
                        '@ﾌｫｰｶｽ設定
                        Call pubSetFocus(vsfFbList)
                    
                    End If
                
                End With
            
                Exit Sub
            End If
            
            '@ﾘｽﾄ選択不可
            vsfFbList.Enabled = False                                                        'ﾘｽﾄ選択可不可
            
            '@ﾚｽﾎﾟﾝ開始
            lstrFormName = Me.Name
            lstrEventName = "cmdUpdateNg_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡す為
            cmbWpID.ValueCol = 1
            cmbRc.ValueCol = 1
            cmbEvent.ValueCol = 1

            '@TEOS F/B 計算結果更新
            lblnAns = pubblnFbTeosResult_Update(CMstrfb_teosresultupdateVer, _
                                        pstrSBID, _
                                        cmbWpID.Value, _
                                        cmbRc.Value, _
                                        cmbRecipe.Value, _
                                        CMlngUpdateNg, _
                                        txtNewDepoData.Text, _
                                        pstrUserID, _
                                        lstrTeosFbUpdateResult)

            '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡したため元に戻す
            cmbWpID.ValueCol = 0
            cmbRc.ValueCol = 0
            cmbEvent.ValueCol = 0
            
            '@結果取得
            If lblnAns = True Then
                
                '@表示ﾒｯｾｰｼﾞ変換(<TRM7FI>$$更新禁止設定を行いました。装置[%1]リアクタ[%2]レシピ[%3])
                lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf007F, cmbWpID.Value, cmbRc.Value, cmbRecipe.Value)

                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(lstrMsg)

                '@更新失敗の場合
                If lstrTeosFbUpdateResult <> 0 Then
                    '@表示ﾒｯｾｰｼﾞ変換(<TRM121W>$$更新禁止設定の更新失敗。装置[%1]リアクタ[%2]レシピ[%3])
                    lstrMsg = pubstrMsgReplace_Set(CPstrMsgWar0121, cmbWpID.Value, cmbRc.Value, cmbRecipe.Value)

                    '@ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(lstrMsg)

                    '@ｴﾗｰﾒｯｾｰｼﾞ表示(<TRM121W>$$更新禁止設定の更新失敗。装置[%1]リアクタ[%2]レシピ[%3])
                    pstrDMsg = lstrMsg
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                End If
            
                '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡す為
                cmbWpID.ValueCol = 1
                cmbRc.ValueCol = 1
                cmbEvent.ValueCol = 1
            
                '@TEOS F/B 計算結果ﾃﾞｰﾀ検索
                lblnAns = pubblnFbTeosResult_Sel(CMstrfb_teosresultlistVer, _
                                        pstrSBID, _
                                        cmbWpID.Value, _
                                        cmbRc.Value, _
                                        cmbRecipe.Value, _
                                        cmbEvent.Value, _
                                        lpubTypFbTeosRresultList)
                                        
                '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡したため元に戻す
                cmbWpID.ValueCol = 0
                cmbRc.ValueCol = 0
                cmbEvent.ValueCol = 0

                '@結果判定
                '@成功の場合
                If lblnAns = True Then
                   
                    lblNowDate.Text = Format$(Now, CPstrDateFormat)                      '情報取得日時表示
         
                    '@取得結果をｸﾞﾘｯﾄﾞに表示
                    With lpubTypFbTeosRresultList

                        vsfFbList.Redraw = False
                        RemoveHandler vsfFbList.EnterCell, AddressOf vsfFbList_EnterCell

                        '@新規表示の場合
                        vsfFbList.Rows.Count = 1

                        '@変数のﾃﾞｰﾀ数文ﾙｰﾌﾟする
                        llngAddCnt = 1
                        For llngCnt = 0 To .lngFbTeosRresultListCnt - 1

                            '@ﾃﾞｰﾀは表示
                            vsfFbList.Rows.Count = vsfFbList.Rows.Count + 1
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListNo, _
                                                                    llngAddCnt)                                                                          'No
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListState, _
                                                                    .fbTeosRresultList(llngCnt).strState)                                                '状態
                            If IsDate(.fbTeosRresultList(llngCnt).strEntryTime) Then
                                vsfFbList.SetData(llngAddCnt, CMlngvsfFbListEntryTime, _
                                                                    Format(CDate(.fbTeosRresultList(llngCnt).strEntryTime), CPstrDateTimeYMDHMS))        '実施日時
                            Else
                                vsfFbList.SetData(llngAddCnt, CMlngvsfFbListEntryTime, _
                                                                    .fbTeosRresultList(llngCnt).strEntryTime)                                            '実施日時
                            End If
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbStatName, _
                                                                    .fbTeosRresultList(llngCnt).strFbStatName)                                           '更新種別
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListProcessTime, _
                                                                    .fbTeosRresultList(llngCnt).strProcessTime)                                          '補正値(sec)
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListMinProcessTime, _
                                                                    .fbTeosRresultList(llngCnt).strMinProcessTime)                                       '補正DEPO時間Min(sec)
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListMaxProcessTime, _
                                                                    .fbTeosRresultList(llngCnt).strMaxProcessTime)                                       '補正DEPO時間Max(sec)
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbLotId, _
                                                                    .fbTeosRresultList(llngCnt).strFbLotId)                                              '補正ﾛｯﾄID
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbRecipeId1, _
                                                                    .fbTeosRresultList(llngCnt).strFbRecipeId1)                                          '補正ﾚｼﾋﾟ1
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbRecipeId2, _
                                                                    .fbTeosRresultList(llngCnt).strFbRecipeId2)                                          '補正ﾚｼﾋﾟ2
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListUserName, _
                                                                    .fbTeosRresultList(llngCnt).strUserName)                                             '実施者ﾕｰｻﾞ

                            llngAddCnt = llngAddCnt + 1

                        Next llngCnt

                        AddHandler vsfFbList.EnterCell, AddressOf vsfFbList_EnterCell
                        vsfFbList.Row = CMlngGridRowTitle
                        vsfFbList.Redraw = True

                    End With
                
                    lbDepoDataCnt.Text = Format$(vsfFbList.Rows.Count - 1, CPstrDateFormatKanma)    '該当件数
                    vsfFbList.Enabled = True
         
                    '@変更前DEPO時間
                    lblOldDepoData.Text = vbNullString       'NULL
           
                    '@変更後DEPO時間
                    With txtNewDepoData
                        .Text = vbNullString                                           'NULL
                        .BackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)  'ｸﾞﾚｰ
                        .Enabled = False                                               '無効(使用不可)
                    End With
                    txtNewDepoData_Change(txtNewDepoData, New EventArgs())
                    
                    '@検索ﾃﾞｰﾀが存在した場合
                    If llngAddCnt - 1 > 0 Then
                        vsfFbList.Enabled = True                                                    'ﾘｽﾄ選択可能化
                    End If
                
                    '@表示位置を左に移動
                    vsfFbList.ShowCell(0, CMlngvsfFbListEntryTime)
                
                Else
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                    
                    Exit Sub
                
                End If
                
            Else

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                 Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                    
                Exit Sub
            
            End If
            
            '@ﾚｽﾎﾟﾝｽ終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUpdateNg_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
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
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

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

    '******************************************************************************************
    '                                       *関数の記述*
    '******************************************************************************************
    '=========================================Private==========================================
    '関数名：prvfrmxxEN02J0_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：
    Private Sub prvfrmxxEN02J0_Init()

        Try

            '@ﾎﾞﾀﾝ初期化
            cmdUpdateNg.Enabled = False
            cmdUpdateOk.Enabled = False
            cmdDepoDataUpdate.Enabled = False

            '@ｸﾞﾘｯﾄの初期化
            Call prvvsfFbList_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02J0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfFbList_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：
    Private Sub prvvsfFbList_Init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfFbList
                .Redraw = False
                '@ﾌﾟﾛﾊﾟﾃｨ初期値
                '.Clear                                 'ｸﾘｱ不要
                RemoveHandler vsfFbList.EnterCell, AddressOf vsfFbList_EnterCell
                .Rows.Count = CMlngGridFixedRows
                .Cols.Fixed = CMlngGridFixedCols
                .Rows.Fixed = CMlngGridFixedRows
                AddHandler vsfFbList.EnterCell, AddressOf vsfFbList_EnterCell
                .Row = CMlngGridRowTitle
                .SelectionMode = SelectionModeEnum.Row
                .FocusRect =  FocusRectEnum.Light        'ｶﾚﾝﾄｾﾙ枠線の設定(細枠)
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                .HighLight = HighLightEnum.Always        'ｸﾞﾘｯﾄﾞからﾌｫｰｶｽが外れた場合でも選択中のｾﾙを分かるようにする
                .Font = New Font(CMstrGridFontName, CMlngGridFontSize, .Font.Style, .Font.Unit)
                .Rows.DefaultSize = 18
                .ScrollBars = ScrollBars.Both
                .ExtendLastCol = True
                .AllowSorting = AllowSortingEnum.SingleColumn

                .Cols(CMlngvsfFbListNo).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfFbListState).TextAlign = TextAlignEnum.CenterCenter
                .Cols(CMlngvsfFbListEntryTime).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfFbListFbStatName).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfFbListProcessTime).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfFbListMinProcessTime).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfFbListMaxProcessTime).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfFbListFbLotId).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfFbListFbRecipeId1).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfFbListFbRecipeId2).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfFbListUserName).TextAlign = TextAlignEnum.LeftCenter
                .Styles.Highlight.BackColor = ColorTranslator.FromWin32(CMlngBKColorCel)   '選択時のﾊﾞｯｸｶﾗｰ(薄紫)
                .Styles.Highlight.ForeColor = ColorTranslator.FromWin32(CMlngOkForeColor)  '選択時の文字色(黒)
                .Styles.Focus.BackColor = ColorTranslator.FromWin32(CMlngBKColorCel)       '選択時のﾊﾞｯｸｶﾗｰ(薄紫)
                .Styles.Focus.ForeColor = ColorTranslator.FromWin32(CMlngOkForeColor)      '選択時の文字色(黒)

                '@一覧表ﾀｲﾄﾙの設定
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfFbListRowTitle, CMlngvsfFbListColTitle, .Rows.Count - 1, .Cols.Count - 1) '表題
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                  '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)     '背景色
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                    '文字位置
                headerStyle.Trimming  = StringTrimming.None                           'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle
                .Rows(CMlngvsfFbListRowTitle).Height = CMlngvsfFbListHHeight          '高さ

                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfFbListNo).Width = CMlngvsfFbListNoW                                                      'No(幅)
                '.Cell(flexcpText, CMlngvsfFbListRowTitle, CMlngvsfFbListNo) = CMstrvsfFbListNoT                        'No(ﾀｲﾄﾙ) 指定不要
                .Cols(CMlngvsfFbListNo).TextAlign = TextAlignEnum.RightCenter                                          'No(ｱﾗｲﾒﾝﾄ)

                .Cols(CMlngvsfFbListState).Width = CMlngvsfFbListStateW                                                '状態(幅)
                '.Cell(flexcpText, CMlngvsfFbListRowTitle, CMlngvsfFbListState) = CMstrvsfFbListStateT                  '状態(ﾀｲﾄﾙ) 指定不要
                .Cols(CMlngvsfFbListState).TextAlign = TextAlignEnum.LeftCenter                                        '状態(ｱﾗｲﾒﾝﾄ)

                .Cols(CMlngvsfFbListEntryTime).Width = CMlngvsfFbListEntryTimeW                                        '実施日時(幅)
                '.Cell(flexcpText, CMlngvsfFbListRowTitle, CMlngvsfFbListEntryTime) = CMstrvsfFbListEntryTimeT          '実施日時(ﾀｲﾄﾙ) 指定不要
                .Cols(CMlngvsfFbListEntryTime).TextAlign = TextAlignEnum.RightCenter                                   '実施日時(ｱﾗｲﾒﾝﾄ)

                .Cols(CMlngvsfFbListFbStatName).Width = CMlngvsfFbListFbStatNameW                                      '更新種別(幅)
                '.Cell(flexcpText, CMlngvsfFbListRowTitle, CMlngvsfFbListFbStatName) = CMstrvsfFbListFbStatNameT        '更新種別(ﾀｲﾄﾙ) 指定不要
                .Cols(CMlngvsfFbListFbStatName).TextAlign = TextAlignEnum.LeftCenter                                   '更新種別(ｱﾗｲﾒﾝﾄ)

                .Cols(CMlngvsfFbListProcessTime).Width = CMlngvsfFbListProcessTimeW                                    '補正値(sec)(幅)
                '.Cell(flexcpText, CMlngvsfFbListRowTitle, CMlngvsfFbListProcessTime) = CMstrvsfFbListProcessTimeT      '補正値(sec)(ﾀｲﾄﾙ) 指定不要
                .Cols(CMlngvsfFbListProcessTime).TextAlign = TextAlignEnum.RightCenter                                 '補正値(sec)(ｱﾗｲﾒﾝﾄ)
                
                .Cols(CMlngvsfFbListMinProcessTime).Width = CMlngvsfFbListMinProcessTimeW                              '補正DEPO時間Min(sec)(幅)
                '.Cell(flexcpText, CMlngvsfFbListRowTitle, CMlngvsfFbListMinProcessTime) = CMstrvsfFbListMinProcessTimeT'補正DEPO時間Min(sec)(ﾀｲﾄﾙ) 指定不要
                .SetData(CMlngvsfFbListRowTitle, CMlngvsfFbListMinProcessTime, CMstrvsfFbListMinProcessTimeT)          '補正DEPO時間Min(sec)(ﾀｲﾄﾙ)
                .Cols(CMlngvsfFbListMinProcessTime).TextAlign = TextAlignEnum.RightCenter                              '補正DEPO時間Min(sec)(ｱﾗｲﾒﾝﾄ)

                .Cols(CMlngvsfFbListMaxProcessTime).Width = CMlngvsfFbListMaxProcessTimeW                              '補正DEPO時間Max(sec)(幅)
                '.Cell(flexcpText, CMlngvsfFbListRowTitle, CMlngvsfFbListMaxProcessTime) = CMstrvsfFbListMaxProcessTimeT'補正DEPO時間Max(sec)(ﾀｲﾄﾙ) 指定不要
                .SetData(CMlngvsfFbListRowTitle, CMlngvsfFbListMaxProcessTime, CMstrvsfFbListMaxProcessTimeT)          '補正DEPO時間Max(sec)(ﾀｲﾄﾙ)
                .Cols(CMlngvsfFbListMaxProcessTime).TextAlign = TextAlignEnum.RightCenter                              '補正DEPO時間Max(sec)(ｱﾗｲﾒﾝﾄ)

                .Cols(CMlngvsfFbListFbLotId).Width = CMlngvsfFbListFbLotIdW                                            '補正ﾛｯﾄID(幅)
                '.Cell(flexcpText, CMlngvsfFbListRowTitle, CMlngvsfFbListFbLotId) = CMstrvsfFbListFbLotIdT              '補正ﾛｯﾄID(ﾀｲﾄﾙ) 指定不要
                .Cols(CMlngvsfFbListFbLotId).TextAlign = TextAlignEnum.LeftCenter                                      '補正ﾛｯﾄID(ｱﾗｲﾒﾝﾄ)

                .Cols(CMlngvsfFbListFbRecipeId1).Width = CMlngvsfFbListFbRecipeId1W                                    '補正ﾚｼﾋﾟ1(幅)
                '.Cell(flexcpText, CMlngvsfFbListRowTitle, CMlngvsfFbListFbRecipeId1) = CMstrvsfFbListFbRecipeId1T      '補正ﾚｼﾋﾟ1(ﾀｲﾄﾙ) 指定不要
                .Cols(CMlngvsfFbListFbRecipeId1).TextAlign = TextAlignEnum.LeftCenter                                  '補正ﾚｼﾋﾟ1(ｱﾗｲﾒﾝﾄ)

                .Cols(CMlngvsfFbListFbRecipeId2).Width = CMlngvsfFbListFbRecipeId2W                                    '補正ﾚｼﾋﾟ2(幅)
                '.Cell(flexcpText, CMlngvsfFbListRowTitle, CMlngvsfFbListFbRecipeId2) = CMstrvsfFbListFbRecipeId2T      '補正ﾚｼﾋﾟ2(ﾀｲﾄﾙ) 指定不要
                .Cols(CMlngvsfFbListFbRecipeId2).TextAlign = TextAlignEnum.LeftCenter                                  '補正ﾚｼﾋﾟ2(ｱﾗｲﾒﾝﾄ)

                .Cols(CMlngvsfFbListUserName).Width = CMlngvsfFbListUserNameW                                          '設定ﾕｰｻﾞ(幅)
                '.Cell(flexcpText, CMlngvsfFbListRowTitle, CMlngvsfFbListUserName) = CMstrvsfFbListUserNameT            '設定ﾕｰｻﾞ(ﾀｲﾄﾙ) 指定不要
                .Cols(CMlngvsfFbListUserName).TextAlign = TextAlignEnum.LeftCenter                                     '設定ﾕｰｻﾞ(ｱﾗｲﾒﾝﾄ)

                .Redraw = True
                '@無効化
                .Enabled = False
            
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFbList_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfFbListShow
    '機　能：ﾃﾞｰﾀを検索して表示する
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 15:34:41 H.Hayashi
    '更新日：2012/03/19 (Mon) 15:34:41
    '備　考：

    Private Sub prvvsfFbListShow()
        Dim lblnAns         As Boolean      'ﾃﾞｰﾀ取得結果
        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
        Dim llngAddCnt      As Integer      'ｸﾞﾘｯﾄﾞ行を示す表示用ｶｳﾝﾀ
        Dim lstrFormName    As String       'ﾌｫｰﾑ名
        Dim lstrEventName   As String       'ｲﾍﾞﾝﾄ名
        
        Try

            '@装置名設定状態確認
            If cmbWpID.Value = vbNullString Then
            
                '@各種ﾗﾍﾞﾙの表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)                      '情報取得日時表示
               
                '@ﾒｯｾｰｼﾞ表示(<TRM18W>$$装置名が設定されていません。設定を見直してください。)
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0018)

                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub

            End If

            '@ﾘｱｸﾀ設定状態確認
            If cmbRc.Value = vbNullString Then
            
                '@各種ﾗﾍﾞﾙの表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)                      '情報取得日時表示
                
                '@ﾒｯｾｰｼﾞ表示(<TRM116W>$$リアクタが設定されていません。設定を見直してください。)
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0116)

                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub

            End If

            '@ﾚｼﾋﾟ設定状態確認
            If cmbRecipe.Value = vbNullString Then
            
                '@各種ﾗﾍﾞﾙの表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)                      '情報取得日時表示
                
                '@ﾒｯｾｰｼﾞ表示(<TRM117W>$$レシピが設定されていません。設定を見直してください。)
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0117)

                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub

            End If
            
            '@更新種別設定状態確認
            If cmbEvent.Value = vbNullString Then
            
                '@各種ﾗﾍﾞﾙの表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)                      '情報取得日時表示
                
                '@ﾒｯｾｰｼﾞ表示(<TRM118W>$$更新種別が設定されていません。設定を見直してください。)
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0118)

                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub

            End If

            '@ﾘｽﾄ選択不可
            vsfFbList.Enabled = False                                                        'ﾘｽﾄ選択可不可

            '@ﾚｽﾎﾟﾝ開始
            lstrFormName = Me.Name
            lstrEventName = "prvvsfFbListShow"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡す為
            cmbWpID.ValueCol = 1
            cmbRc.ValueCol = 1
            cmbEvent.ValueCol = 1
            
            '@TEOS F/B 計算結果ﾃﾞｰﾀ検索
            lblnAns = pubblnFbTeosResult_Sel(CMstrfb_teosresultlistVer, _
                                        pstrSBID, _
                                        cmbWpID.Value, _
                                        cmbRc.Value, _
                                        cmbRecipe.Value, _
                                        cmbEvent.Value, _
                                        lpubTypFbTeosRresultList)
                                        
            '@装置ID、ﾘｱｸﾀNo、更新種別IDを渡したため元に戻す
            cmbWpID.ValueCol = 0
            cmbRc.ValueCol = 0
            cmbEvent.ValueCol = 0
                                       
            '@結果判定
            '@成功の場合
            If lblnAns = True Then
                   
                lblNowDate.Text = Format$(Now, CPstrDateFormat)                      '情報取得日時表示

                '@取得結果をｸﾞﾘｯﾄﾞに表示
                With lpubTypFbTeosRresultList

                    vsfFbList.Redraw = False

                    RemoveHandler vsfFbList.EnterCell, AddressOf vsfFbList_EnterCell

                    '@新規表示の場合
                    vsfFbList.Rows.Count = 1

                    '@変数のﾃﾞｰﾀ数文ﾙｰﾌﾟする
                    llngAddCnt = 1
                    For llngCnt = 0 To .lngFbTeosRresultListCnt - 1

                        '@ﾃﾞｰﾀは表示
                        vsfFbList.Rows.Count = vsfFbList.Rows.Count + 1
                        vsfFbList.SetData(llngAddCnt, CMlngvsfFbListNo, _
                                                                    llngAddCnt)                                                                          'No
                        vsfFbList.SetData(llngAddCnt, CMlngvsfFbListState, _
                                                                    .fbTeosRresultList(llngCnt).strState)                                                '状態
                        If IsDate(.fbTeosRresultList(llngCnt).strEntryTime) Then
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListEntryTime, _
                                                                    Format(CDate(.fbTeosRresultList(llngCnt).strEntryTime), CPstrDateTimeYMDHMS))        '実施日時
                        Else
                            vsfFbList.SetData(llngAddCnt, CMlngvsfFbListEntryTime, _
                                                                    .fbTeosRresultList(llngCnt).strEntryTime)                                            '実施日時
                        End If
                        vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbStatName, _
                                                                    .fbTeosRresultList(llngCnt).strFbStatName)                                           '更新種別
                        vsfFbList.SetData(llngAddCnt, CMlngvsfFbListProcessTime, _
                                                                    .fbTeosRresultList(llngCnt).strProcessTime)                                          '補正値(sec)
                        vsfFbList.SetData(llngAddCnt, CMlngvsfFbListMinProcessTime, _
                                                                    .fbTeosRresultList(llngCnt).strMinProcessTime)                                       '補正DEPO時間Min(sec)
                        vsfFbList.SetData(llngAddCnt, CMlngvsfFbListMaxProcessTime, _
                                                                    .fbTeosRresultList(llngCnt).strMaxProcessTime)                                       '補正DEPO時間Max(sec)
                        vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbLotId, _
                                                                    .fbTeosRresultList(llngCnt).strFbLotId)                                              '補正ﾛｯﾄID
                        vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbRecipeId1, _
                                                                    .fbTeosRresultList(llngCnt).strFbRecipeId1)                                          '補正ﾚｼﾋﾟ1
                        vsfFbList.SetData(llngAddCnt, CMlngvsfFbListFbRecipeId2, _
                                                                    .fbTeosRresultList(llngCnt).strFbRecipeId2)                                          '補正ﾚｼﾋﾟ2
                        vsfFbList.SetData(llngAddCnt, CMlngvsfFbListUserName, _
                                                                    .fbTeosRresultList(llngCnt).strUserName)                                             '実施ﾕｰｻﾞ
                    
                        llngAddCnt = llngAddCnt + 1

                    Next llngCnt

                    AddHandler vsfFbList.EnterCell, AddressOf vsfFbList_EnterCell
                    vsfFbList.Row = CMlngGridRowTitle

                    vsfFbList.Redraw = True

                End With
                
                lbDepoDataCnt.Text = Format$(vsfFbList.Rows.Count - 1, CPstrDateFormatKanma)       '該当件数
                
                '@検索ﾃﾞｰﾀが存在した場合
                If llngAddCnt - 1 > 0 Then
                    vsfFbList.Enabled = True                                                    'ﾘｽﾄ選択可能化
                End If
                
                '@表示位置を左に移動
                vsfFbList.ShowCell(0, CMlngvsfFbListEntryTime)
                
            Else
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
                
            End If
            
            '@ﾚｽﾎﾟﾝｽ終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFbListShow"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraLot.Paint, frmSerch0.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfFbList.BeforeDoubleClick

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

    '関数名：vsfFbList_BeforeSort
    '機　能：FbListグリッドのソート前処理
    '作成日：2020/05/14 (THU) NSYS
    '更新日：
    '備　考：
    Private Sub vsfFbList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfFbList.BeforeSort
        Try
            mIntFbListBeforeSortRow = vsfFbList.Row
            vsfFbList.Redraw = False

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFbList_AfterSort
    '機　能：FbListグリッドのソート後処理
    '作成日：2020/05/14 (THU) NSYS
    '更新日：
    '備　考：
    Private Sub vsfFbList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfFbList.AfterSort
        Try
            vsfFbList.Row = mIntFbListBeforeSortRow
            vsfFbList.Redraw = True
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFbList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

End Class
