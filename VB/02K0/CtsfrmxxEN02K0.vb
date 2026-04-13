'ﾌｧｲﾙ名：xxEN02K0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：CONTエッチャーFR使用履歴 メインフォーム
'作成日：2014/11/07 (Fri) 15:12:55 T.Oide
'更新日：2016/06/13 (Mon) 16:07:53 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2014-2016, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02K0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02K0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02K0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02K0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02K0)
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
    '@↓2016/06/13 (Mon) 16:07:44 T.Oide **************************************************
    'Private Const CMstrLocalVersion                 As String = "01.00"
    Private Const CMstrLocalVersion                 As String = "01.01"
    '@↑2016/06/13 (Mon) 16:07:44 T.Oide **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN02K0      'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_wplist__Ver              As String = "05.01"             '装置一覧取得
    Private Const CMstrmas_wpprocessingnamelistVer  As String = "01.00"             '装置処理部用途取得
    '@↓2016/06/13 (Mon) 16:34:31 T.Oide **************************************************
    'Private Const CMstrfb__contetfrhistVer          As String = "01.00"             'CONTｴｯﾁｬｰFR使用履歴取得
    Private Const CMstrfb__contetfrhistVer          As String = "01.01"             'CONTｴｯﾁｬｰFR使用履歴取得
    '@↑2016/06/13 (Mon) 16:34:31 T.Oide **************************************************
    Private Const CMstrfb__contetfrhistregVer       As String = "01.00"             'CONTｴｯﾁｬｰFR使用履歴登録


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
    Private Const CMlngvsfFrListRowTitle            As Integer = 0                  '行ﾀｲﾄﾙ
    Private Const CMlngvsfFrListColTitle            As Integer = 0                  '列ﾀｲﾄﾙ
    Private Const CMlngvsfFrListHHeight             As Integer = 33                 'ﾍｯﾀﾞｰ高さ(2行分)
    Private Const CMlngvsfFrListHeight              As Integer = 18                 '行高さ
    Private Const CMlngvsfFrListHFontSize           As Integer = 11                 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ：11
    Private Const CMlngvsfFrListFontSize            As Integer = 11                 'ﾌｫﾝﾄｻｲｽﾞ：11
        

    '@ｸﾞﾘｯﾄﾞの列設定
    Private Const CMlngvsfFrListNo                  As Integer = 0                  'No
    Private Const CMlngvsfFrListFrId                As Integer = 1                  'FR_ID
    Private Const CMlngvsfFrListLot                 As Integer = 2                  'ロットID
    Private Const CMlngvsfFrListRecip               As Integer = 3                  'レシピID
    Private Const CMlngvsfFrListCumProcessTime      As Integer = 4                  'FR累積処理時間(h)
    Private Const CMlngvsfFrListProcessTime         As Integer = 5                  '処理時間(h)
    Private Const CMlngvsfFrListAcceleFacter        As Integer = 6                  'FR消耗度加速係数
    Private Const CMlngvsfFrListCalcCumProTime      As Integer = 7                  'FR(計算)累積処理時間(h)
    Private Const CMlngvsfFrListDate                As Integer = 8                  '登録日時
    Private Const CMlngvsfFrListUser                As Integer = 9                  'ユーザ


    '@ｸﾞﾘｯﾄﾞの幅設定
    Private Const CMlngvsfFrListNoW                 As Integer = 33                 'No
    Private Const CMlngvsfFrListFrIdW               As Integer = 76                 'FR_ID
    Private Const CMlngvsfFrListLotW                As Integer = 100                'ロットID
    Private Const CMlngvsfFrListRecipW              As Integer = 225                'レシピID
    Private Const CMlngvsfFrListCumProcessTimeW     As Integer = 103                'FR累積処理時間(h)
    Private Const CMlngvsfFrListProcessTimeW        As Integer = 72                 '処理時間(h)
    Private Const CMlngvsfFrListAcceleFacterW       As Integer = 81                 'FR消耗度加速係数
    Private Const CMlngvsfFrListCalcCumProTimeW     As Integer = 103                'FR(計算)累積処理時間(h)
    Private Const CMlngvsfFrListDateW               As Integer = 145                '登録日時
    Private Const CMlngvsfFrListUserW               As Integer = 145                'ユーザ

    '@ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ設定
    Private Const CMstrvsfFrListNoT                 As String = "No"
    Private Const CMstrvsfFrListFrIdT               As String = "ﾌｫｰｶｽ"&ChrW(13)&ChrW(10)&"ﾘﾝｸﾞID"
    Private Const CMstrvsfFrListLotT                As String = "ロットID"
    Private Const CMstrvsfFrListRecipT              As String = "レシピ"
    Private Const CMstrvsfFrListCumProcessTimeT     As String = "FR累積"&ChrW(13)&ChrW(10)&"処理時間(h)"
    Private Const CMstrvsfFrListProcessTimeT        As String = "処理"&ChrW(13)&ChrW(10)&"時間(h)"
    Private Const CMstrvsfFrListAcceleFacterT       As String = "FR消耗度"&ChrW(13)&ChrW(10)&"加速係数"
    Private Const CMstrvsfFrListCalcCumProTimeT     As String = "FR(計算)累積"&ChrW(13)&ChrW(10)&"処理時間(h)"
    Private Const CMstrvsfFrListDateT               As String = "登録日時"
    Private Const CMstrvsfFrListUserT               As String = "登録者"


    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMstrCmbFontName                  As String = "ＭＳ ゴシック"     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄ名
    Private Const CMlngCmbFontSize                  As Integer = 11                 'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                 'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName               As Integer = 0                  '名称列番
    Private Const CMlngCmbGridColID                 As Integer = 1                  'ID列番(非表示項目：PD_ID)
    Private Const CMlngCmbGridColID2                As Integer = 2                  'ID列番2(非表示項目：USE_ID)
    Private Const CMlngCmbSortAsc                   As Integer = 1                  '昇順(ｿｰﾄ)
    Private Const CMlngCmbDispCols                  As Integer = 1                  'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                 As Integer = 18                 'ﾘｽﾄ行の高さ
    Private Const CMlngCmbClearListIndex            As Integer = -1                 'ﾃｷｽﾄ値初期化
    Private Const CMlngCMbSelectMode                As Integer = 1                  '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMlngCmbFirstListIndex            As Integer = 0                  'ｺﾝﾎﾞLISTの表示位置
    Private Const CMlngCmbGetCol5                   As Integer = 5                  'ﾊﾞｯｸｶﾗｰ格納Col


    '@その他宣言

    '@色宣言
    Private Const CMlngEnableFalseColor             As Integer = &HE0E0E0           '灰色(使用不可)
    Private Const CMlngInputColor                   As Integer = &HC0C0FF           'ﾋﾟﾝｸ
    Private Const CMlngNotInputColor                As Integer = &HE0E0E0           '薄灰色
    Private Const CMlngOkForeColor                  As Integer = &H000000           '黒色(通常色)
    Private Const CMlngBKColorCel                   As Integer = &HFFC0C0           '薄紫(ｸﾞﾘｯﾄﾞ選択時のﾊﾞｯｸｶﾗｰ)

    Private Const CMlngCmbNoSelect                  As Integer = -1

    Private Const CMlngZero                         As Integer = 0                  '0(数値)
    Private Const CMlngOne                          As Integer = 1                  '1(数値)
    Private Const CMlngTwo                          As Integer = 2                  '2(数値)
    Private Const CMlngThree                        As Integer = 3                  '3(数値)
    Private Const CMlngFour                         As Integer = 4                  '4(数値)
    Private Const CMlngFive                         As Integer = 5                  '5(数値)
    Private Const CMlngTen                          As Integer = 10                 '10(数値)
    Private Const CMlng80                           As Integer = 80                 '80(数値)

    Private Const CMstrEditMark                     As String = "*"                 '編集中行のﾏｰｸ
    Private Const CMstrFuyou                        As String = "入力不要"          '入力不要
    Private Const CMstrKizonFrId                    As String = "既存FRID"          '既存FR_ID
    Private Const CMstrSinkiFrId                    As String = "新規FRID"          '既存FR_ID

    Private Const CMstrFrRefValueLab                As String = "FR異常差異基準値：" 'FR異常差異基準値：
    Private Const CMstrWarTimeLab                   As String = "警告時間："        '警告時間：
    Private Const CMstrErrTimeLab                   As String = "エラー時間："      'エラー時間：
    Private Const CMstrh                            As String = "h"                 'h（時間）



    '******************************************************************************************
    '                                       *変数の記述*
    '******************************************************************************************
    '=========================================Private==========================================
    Private mblnEventCancelFlag                     As Boolean                      'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
    Private mstrBeforEditValue                      As String                       'ｸﾞﾘｯﾄﾞ変更前の値

    Private buttonProcessing                        As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                      'NSYS WindowCloseフラグ
    Private mstrChangeEditValue                     As String                       'NSYS 編集時の文字列保持

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
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns         As Boolean      '戻り値

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02K0, CMstrLocalVersion)
            
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If

            '@画面初期化
            Call prvfrmxxEN02K0_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞｾｯﾄ
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
    '機　能：起動時にﾎﾞﾀﾝの有効/無効を設定する
    '引　数：なし
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
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

    '関数名：cmdSerch_Click
    '機　能：検索実行
    '引　数：なし
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub cmdSerch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSerch.Click
        
        Dim llngMsgAns      As Integer
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
           '@編集中の場合はユーザに本当にやめるか確認する
            If prvChkEdit() = True Then
                
                '@$$編集中のデータは破棄されます。$終了してもよろしいですか？
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001W)
                '@メッセージを表示
                llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16)
            
                '@メッセージボックスの戻り値判定
                If llngMsgAns = vbNo Then '「いいえ」を選択
                    Exit Sub
                End If
                
            End If
            
            '@ﾃﾞｰﾀを検索して表示する
            Call prvvsfFrListShow()
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub
                
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDetail_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdAdd_Click
    '機　能：行追加
    '引　数：なし
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAdd.Click
        
        Dim strAddItemData  As String
        Dim lintRow         As Integer
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            vsfFrList.Redraw = False
            RemoveHandler vsfFrList.RowColChange, AddressOf vsfFrList_RowColChange

            With vsfFrList
                
                lintRow = .Row
                strAddItemData = CMstrEditMark & vbTab                      'No（「*」を設定）
                strAddItemData = strAddItemData + CMstrFuyou & vbTab        'FR_ID（「入力不要」を設定）
                strAddItemData = strAddItemData + CMstrFuyou & vbTab        'ﾛｯﾄID（「入力不要」を設定)
                strAddItemData = strAddItemData + CMstrFuyou & vbTab        'ﾚｼﾋﾟID（「入力不要」を設定)
                strAddItemData = strAddItemData + vbNullString & vbTab      'FR累積処理時間(h)
                strAddItemData = strAddItemData + vbNullString & vbTab      '処理時間(h)
                strAddItemData = strAddItemData + vbNullString & vbTab      'FR消耗度加速係数
                strAddItemData = strAddItemData + vbNullString & vbTab      'FR(計算)累積処理時間(h)
                strAddItemData = strAddItemData + CMstrFuyou & vbTab        '登録日時（「入力不要」を設定)
                strAddItemData = strAddItemData + CMstrFuyou                '登録車（「入力不要」を設定)
                
                '@1行目に行を追加(ﾀｲﾄﾙ行の場合空行追加)
                .AddItem(strAddItemData, CMlngOne)
                .Row = lintRow
            End With

            AddHandler vsfFrList.RowColChange, AddressOf vsfFrList_RowColChange
            
            '@ﾚｼﾋﾟ列のみ幅調整
            vsfFrList.AutoSizeCol(CMlngvsfFrListRecip, 6)

            vsfFrList.Redraw = True
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub
                
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdAdd_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdDel_Click
    '機　能：選択行削除(編集中行のみ削除可能)
    '引　数：なし
    '戻り値：
    '作成日：2014/11/11 (Tue) 13:17:04 T.Oide
    '更新日：2014/11/11 (Tue) 13:17:04
    '備　考：
    Private Sub cmdDel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDel.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfFrList
            
                '@編集中行か
                If .GetDataDisplay(.Row, CMlngvsfFrListNo) = CMstrEditMark Then
                    '@行を削除
                    .Redraw = False
                    .RemoveItem(.Row)
                    .Redraw = True
                End If
                
            End With
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub
                
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdClipCopy_Click
    '機　能：表示中のﾃﾞｰﾀをｸﾘｯﾌﾟﾎﾞｰﾄﾞにｺﾋﾟｰする
    '引　数：なし
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
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
            Clipboard.Clear()
            
            '@一覧をｺﾋﾟｰする
            With vsfFrList
                '@行
                For llngRowCnt = 0 To .Rows.Count - 1
                    '@列
                    For llngColCnt = 0 To .Cols.Count - 1
                        '@列が非表示でない場合
                        If .Cols(llngColCnt).Visible Then
                            
                            '@文字列編集変数に値をｾｯﾄ
                            lstrWk = Replace(.GetData(llngRowCnt, llngColCnt), vbCrLf, "")
                                
                            '@先頭の文字列が「-」「+」の場合は罫線文字に置き換える
                            If Mid$(lstrWk, 1, 1) = CPstrMinus Then
                                Mid$(lstrWk, 1, 1) = CPstrMinusWide
                            End If
                            If Mid$(lstrWk, 1, 1) = CPstrPlus Then
                                Mid$(lstrWk, 1, 1) = CPstrPlusWide
                            End If
                                
                            '@最終列の場合Tabいらない
                            If llngColCnt = .Cols.Count - 1 Then
                                '@ｺﾋﾟｰ文字列作成
                                lstrRET = lstrRET & lstrWk
                            Else
                                '@ｺﾋﾟｰ文字列作成
                                lstrRET = lstrRET & lstrWk & vbTab
                            End If
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
            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClipCopy_Click"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              'ﾃﾞｰﾀ取得結果
        Dim lblnCheck               As Boolean              '登録前のﾁｪｯｸ結果
        Dim lstrFormName            As String               'ﾌｫｰﾑ名
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名
        Dim lstrMsgCode             As String               'ｴﾗｰﾒｯｾｰｼﾞｺｰﾄﾞ
        Dim lstrMsg                 As String               'ｴﾗｰﾒｯｾｰｼﾞ
        Dim lTypeFbContFrHistReg    As typFbConstFrHistReg  'FR使用履歴登録用

        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            pstrMessageName = "FR累積使用時間登録"
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@ﾌｫｰﾑのﾛｯｸ中は処理を行わない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            '@設定状態ﾁｪｯｸ
            lblnCheck = prvblnChkReg()
            
            '@結果確認
            If lblnCheck = False Then
                '@ｴﾗｰﾒｯｾｰｼﾞ表示「<TRM128W>$$時間および係数は空の設定はできません。$設定を見直してください。」
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0128)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                
                Exit Sub
            End If

            '@注意ﾒｯｾｰｼﾞ表示「<TRM129W>$$「FR累積処理時間(h)」と「FR(計算)累積処理時間(h)」は、$"
            '                                次回の「FR(計算)累積処理時間(h)」の計算に影響を及ぼします。$"
            '                                十分に確認した上で確定を実行してください｡
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0129)
            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If
            
            With lTypeFbContFrHistReg
            
                '@登録する行は先頭行だけ(一応「＊」があることを確認する）
                If vsfFrList.GetDataDisplay(CMlngOne, CMlngvsfFrListNo) = CMstrEditMark Then
                    
                    '@構造体に登録する情報を格納する
                    .strWpID = cmbWp.Value                                                                 '装置ID
                    .strProcessingId = cmbChanber.Value                                                    '処理部ID
                    .strLotID = vsfFrList.GetData(CMlngOne, CMlngvsfFrListLot)                             'LOT_ID
                    .strRcipId = vsfFrList.GetData(CMlngOne, CMlngvsfFrListRecip)                          'ﾚｼﾋﾟID
                    .strAcceleFacter = vsfFrList.GetDataDisplay(CMlngOne, CMlngvsfFrListAcceleFacter)      'FR消耗度加速係数
                    .strCumProcTime = vsfFrList.GetDataDisplay(CMlngOne, CMlngvsfFrListCumProcessTime)     'FR累積使用時間
                    .strProcTime = vsfFrList.GetDataDisplay(CMlngOne, CMlngvsfFrListProcessTime)           '処理時間
                    .strCalcCumProcTime = vsfFrList.GetDataDisplay(CMlngOne, CMlngvsfFrListCalcCumProTime) 'FR(計算)累積使用時間
                    .strEmpID = pstrUserID
                
                Else
                    '@登録データなし
                    
                    '@ﾒｯｾｰｼﾞ表示("<TRM43W>$$登録データがありません。")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0043)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                    
                    Exit Sub
                End If
            
            End With
            
            '@ﾚｽﾎﾟﾝ開始
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@FR使用履歴登録
            lblnAns = pubblnContFrHist_Reg(CMstrfb__contetfrhistregVer, lTypeFbContFrHistReg)
            
            '@結果判定
            If lblnAns = True Then
            
                '@成功の場合
                
                '@ﾚｽﾎﾟﾝｽ終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@変数を初期化(一部初期化)
                Call prvMemInit(False)
                
                '@ﾃﾞｰﾀを再検索して再表示
                Call prvvsfFrListShow()
                
            Else
            
                '@異常の場合終了
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@ﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(lstrMsgCode & vbCrLf & vbCrLf & lstrMsg)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                
            
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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
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
            
            '@ｺﾝﾄﾛｰﾙによって処理分岐
            Select Case ActiveControl.Name
            
               
                '@ｸﾞﾘｯﾄﾞの場合
                Case vsfFrList.Name
                
                    '@ｷｰによって処理分岐
                    Select Case e.KeyCode
                            
                        '@F2ｷｰの場合
                        Case Keys.F2
                        
                            '@編集可否判定
                            Call vsfFrList_Edit()
                            
                    End Select
                
                '@その他のｺﾝﾄﾛｰﾙにﾌｫｰｶｽがある場合
                Case Else
                    
                    '@Enterの場合
                    Select Case e.KeyCode
                        
                        Case Keys.Return
                            
                            If ActiveControl IsNot vsfFrList.Editor Then
                                '@次ﾌｫｰｶｽへ
                                SendKeys.SendWait(CPstrSendKeysTab)
                            
                                e.Handled = True
                            End If
                            
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

    '関数名：Form_KeyPress
    '機　能：ﾌｫｰﾑｷｰﾌﾟﾚｽ処理
    '引　数：KeyAscii：ｱｽｷｰｺｰﾄﾞ
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub Form_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress

        Try

            Select Case Asc(e.KeyChar)
                '@ｺﾛﾝ(:)58の場合は入力不可
        '        Case CMlngColonKeyAscii
        '           KeyAscii = 0
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyPress"
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
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納
        Dim llngMsgAns      As Integer

        Try

            '@編集中の場合メッセージ表示
            If prvChkEdit() = True Then
                
                '@$$編集中のデータは破棄されます。$終了してもよろしいですか？
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001W)
                '@メッセージを表示
                llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16)
            
                '@メッセージボックスの戻り値判定
                If llngMsgAns = vbNo Then '「いいえ」を選択
                    e.Cancel = True
                    Exit Sub
                End If
                
            End If
            
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
            
            '@変数初期化(全部初期化)
            Call prvMemInit(True)

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
    '機　能："閉じる"ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
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

            '@終了関数を実行する
            Call publngEnd_Proc(CPstrKeyEN02K0, ltypCommonInfo)
            
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

    '関数名：cmbWp_Change
    '機　能：フォーカスを次のTabIndexに移動
    '引　数：なし
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbWp_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.Change

        Try
            
            '@処理部ｺﾝﾎﾞ初期化
            Call prvcmb_Init(cmbChanber)
            
            '@ｸﾞﾘｯﾄﾞ初期化
            Call prvvsfFrList_Init()
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWp_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbChanber_Change
    '機　能：フォーカスを次のTabIndexに移動
    '引　数：なし
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbChanber_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbChanber.Change

        Try
            
            '@ｸﾞﾘｯﾄﾞ初期化
            Call prvvsfFrList_Init()
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbChanber_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWp_Validate
    '機　能：装置に紐付く処理部情報取得して処理部ｺﾝﾎﾞのﾘｽﾄに設定
    '引　数：Cancel：
    '戻り値：
    '作成日：2014/11/10 (Mon) 09:30:50 T.Oide
    '更新日：2014/11/10 (Mon) 09:30:50
    '備　考：
    Private Sub cmbWp_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWp.Validating

        Dim ltypWpProcessingNameListReq As WpProcessingNameListReq      '装置処理部用途取得(要求)用構造体
        Dim ltypWpProcessingNameListAns As WpProcessingNameListAns      '装置処理部用途取得(応答)用構造体
        Dim lblnAns                     As Boolean
        Dim llngCnt                     As Integer

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@装置IDは選択済か
            If cmbWp.Text = vbNullString Then
                '@装置が未選択の場合何もしない
                Exit Sub
            End If
            
            '@処理部情報ｸﾘｱ
            cmbChanber.Clear()
            
            '@***********************
            '@ 要求ﾃﾞｰﾀ作成
            '@***********************
            With ltypWpProcessingNameListReq
                .strMsgVer = CMstrmas_wpprocessingnamelistVer   'ﾒｯｾｰｼﾞVer
                .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strWpID = cmbWp.Value                          '装置ID
            End With

            '@【装置処理部用途取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasWpProcessingList_Sel(ltypWpProcessingNameListReq, _
                                                    ltypWpProcessingNameListAns)

            '@結果はFalseか
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If

            '@装置処理部用途取得件数が0件か
            If ltypWpProcessingNameListAns.lngProcessingListCnt = 0 Then
                '@処理部情報がないのは想定外(この画面では何もできない)
                Exit Sub
            Else
                '@装置処理部ﾃﾞｰﾀがある場合
                
                '@***********************
                '@ ｺﾝﾎﾞ設定
                '@***********************
                For llngCnt = 0 To ltypWpProcessingNameListAns.lngProcessingListCnt - 1
                    With ltypWpProcessingNameListAns.typProcessingList(llngCnt)
                    
                        cmbChanber.AddItem ( _
                                .strProcessingName & _
                                vbTab & _
                                .strChamberId)
                    End With
                Next llngCnt
            
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWp_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWp_CloseUp
    '機　能：処理部情報取得するためにValidateイベント呼ぶ
    '引　数：なし
    '戻り値：
    '作成日：2014/11/10 (Mon) 09:30:02 T.Oide
    '更新日：2014/11/10 (Mon) 09:30:02
    '備　考：
    Private Sub cmbWp_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.CloseUp

        Try
            
            '@処理部情報取得するためにValidateイベント呼ぶ
            SendKeys.SendWait(CPstrSendKeysTab)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWp_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfFrList_AfterEdit
    '機　能：設定値を空に変えられた場合の処理
    '引　数：Row：
    '　　　：Col：
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub vsfFrList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFrList.AfterEdit

        Dim strData         As String

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfFrList.Rows.Count <= vsfFrList.Rows.Fixed Then
                Return
            End If
            
            With vsfFrList
            
                strData = .GetDataDisplay(e.Row, e.Col)
            
                '@列で分岐
                Select Case .Col
            
                    Case CMlngvsfFrListCumProcessTime, CMlngvsfFrListProcessTime, CMlngvsfFrListAcceleFacter, CMlngvsfFrListCalcCumProTime
                    
                        '@値は数値か
                        If IsNumeric(strData) = False Then
                        
                            '@対象ｾﾙ選択
                            .ShowCell(e.Row, e.Col)
                            
                            '@数値以外は設定できません
                            '@ﾒｯｾｰｼﾞ表示("<TRM7QW>$$数値を入力して下さい。")
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007Q)
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                
                            '@元の値に戻す
                            .SetData(e.Row, e.Col, mstrBeforEditValue)
                            Exit Sub
                        End If
                        
                        'FR累積使用時間かの設定が前回値より小さい場合は新規FR_IDと判断する
                        If CMlngvsfFrListCumProcessTime = .Col Then
                        
                            '@既存の履歴はあるか
                            If .Rows.Count > 2 Then
                                '@既存履歴あり
                                
                                'FR累積使用時間の設定が前回値より小さい場合は新規FR_IDと判断する
                                If CLng(.GetData(e.Row, e.Col)) < CLng(.GetData(e.Row + 1, e.Col)) Then
                                
                                    '@ﾒｯｾｰｼﾞ表示("<TRM130W>$$「FR累積処理時間(h)」が前回値より小さい場合、新規FRIDとなります。")
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0130)
                                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                    
                                    '@新規FRIDに表示を変更
                                    .SetData(e.Row, CMlngvsfFrListFrId, CMstrSinkiFrId)
                                Else
                                    '@既存FRIDに表示を変更
                                    .SetData(e.Row, CMlngvsfFrListFrId, CMstrKizonFrId)
                                End If
                            
                            Else
                                '@既存の履歴なし
                                '@新規FRIDに表示を変更
                                .SetData(e.Row, CMlngvsfFrListFrId, CMstrSinkiFrId)
                            
                            End If
                            
                        End If
                        
                    Case Else
                        '@特に何もしない
                        
                End Select
                
            End With

            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFrList_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfFrList_BeforeEdit
    '機　能：ｸﾞﾘｯﾄﾞ変更前の値を退避(異常値入力された場合に戻すため)
    '引　数：Row：
    '　　　：Col：
    '　　　：Cancel：
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub vsfFrList_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFrList.SetupEditor

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfFrList.Rows.Count <= vsfFrList.Rows.Fixed Then
                Return
            End If
            
            '@ｷｬﾝｾﾙﾌﾗｸﾞはTrueか
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            With vsfFrList

                Dim tb As TextBox = CType(vsfFrList.Editor, TextBox)
                '@ｶﾗﾑによって分岐
                Select Case e.Col
                    
                    '@「ロットID」の場合
                    Case CMlngvsfFrListLot
                        '@入力桁数Max10桁
                        tb.MaxLength = CMlngTen
                        
                    '@「ﾚｼﾋﾟID」の場合
                    Case CMlngvsfFrListRecip
                        '@入力桁数Max10桁
                        tb.MaxLength = CMlng80
                        
                    '@「FR累積処理時間(h)」「処理時間(h)」「FR(計算)累積処理時間(h)」の場合
                    Case CMlngvsfFrListCumProcessTime, CMlngvsfFrListProcessTime, CMlngvsfFrListCalcCumProTime
                        '@入力桁数Max5桁
                        tb.MaxLength = CMlngFive
                        
                    '@「FR消耗度加速係数」の場合
                    Case CMlngvsfFrListAcceleFacter
                        '@入力桁数Max4桁
                        tb.MaxLength = CMlngFour
                
                    Case Else
                        '特に何もしない
                
                End Select
                
                
                '@変更前の値を退避
                mstrBeforEditValue = .GetData(.Row, .Col)
                mstrChangeEditValue = mstrBeforEditValue
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFrList_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFrList_DblClick
    '機　能：ｸﾞﾘｯﾄﾞを編集状態にする
    '引　数：なし
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub vsfFrList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFrList.DoubleClick

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfFrList.Rows.Count <= vsfFrList.Rows.Fixed Then
                Return
            End If

            'NSYS データ行以外のクリックの場合は処理を抜ける
            If vsfFrList.MouseRow < vsfFrList.Rows.Fixed Then
                Return
            End If
            
            '@編集可否判定
            Call vsfFrList_Edit()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFrList_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfFrList_RowColChange
    '機　能：ﾎﾞﾀﾝの有効/無効を設定
    '引　数：なし
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub vsfFrList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFrList.RowColChange

        Try
            
            '@ｷｬﾝｾﾙﾌﾗｸﾞTrueか
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            '@ﾎﾞﾀﾝの有効/無効設定
            Call prvButtonControl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFrList_RowColChange"
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
    '関数名：prvfrmxxEN02K0_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub prvfrmxxEN02K0_Init()

        Dim lstrFormTitle               As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim lblnAns                     As Boolean      '汎用戻り値(True/False)
        Dim llngCnt                     As Integer      '汎用ｶｳﾝﾀ
        Dim lstrFormName                As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngWpCnt                   As Integer      '装置IDのｶｳﾝﾄ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02K0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@装置ｺﾝﾎﾞ初期化
            Call prvcmb_Init(cmbWp)
            
            '@処理部ｺﾝﾎﾞ初期化
            Call prvcmb_Init(cmbChanber)
            
            '@ｸﾞﾘｯﾄの初期化
            Call prvvsfFrList_Init()
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            Call pubResponseStart(lstrFormName, lstrEventName)
            

            '@装置一覧取(CONTｴｯﾁｬｰ)
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, _
                                       llngWpCnt, _
                                       pstrSBID, _
                                       CPstrCD3U, _
                                       , _
                                       , _
                                       , _
                                       , _
                                       CPstrEqTypeContEt)
            '@結果判定
            With cmbWp
                If lblnAns = True Then
                    '@成功の場合、一旦ﾘｽﾄをｸﾘｱして入れなおす
                    .Clear()
                    llngCnt = 0
                    If llngWpCnt > 0 Then
                        For llngCnt = 0 To llngWpCnt - 1
                            '@ｺﾝﾎﾞﾘｽﾄｾｯﾄ
                            .AddItem (ptypWPList(llngCnt).strWpName & vbTab & _
                                      ptypWPList(llngCnt).strWpID)
                        Next
                    End If
                    
                Else
                    '@異常の場合終了、ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)

                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose

                    Exit Sub
                End If

            End With
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02K0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmb_Init
    '機　能：ｺﾝﾎﾞﾎﾞｯｸｽの初期化
    '引　数：ｺﾝﾎﾞﾎﾞｯｸｽｵﾌﾞｼﾞｪｸﾄ
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub prvcmb_Init(ByRef cmbObj As SEComboBoxEx.ComboBoxEx)

        Try

            '@ｺﾝﾎﾞﾎﾞｯｸｽ初期化
            With cmbObj
                .Clear()
                .Enabled = True
                .DirectInput = False
                .DispCols = 1
                .GetCol = 0
                .ColAlignment(.GetCol) = TextAlignEnum.LeftCenter
                .Font = New Font(CMstrCmbFontName, CMlngCmbFontSize, .Font.Style, .Font.Unit)
                .GridFont = New Font(CMstrCmbFontName, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)
                .BackColor = SystemColors.Window
                .ValueCol = 1
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmb_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfFrList_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub prvvsfFrList_Init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfFrList
                
                mblnEventCancelFlag = True
                
                .Redraw = False
                '@ﾌﾟﾛﾊﾟﾃｨ初期値
                .Clear(ClearFlags.Content)
                .Rows.Count = CMlngGridFixedRows
                .Cols.Fixed = CMlngGridFixedCols
                .Rows.Fixed = CMlngGridFixedRows
                .SelectionMode = SelectionModeEnum.Row
                .FocusRect = FocusRectEnum.Light           'ｶﾚﾝﾄｾﾙ枠線の設定(細枠)
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                .HighLight = HighLightEnum.Always          'ｸﾞﾘｯﾄﾞからﾌｫｰｶｽが外れた場合でも選択中のｾﾙを分かるようにする
                .Font = New Font(CMstrGridFontName, CMlngGridFontSize, .Font.Style, .Font.Unit)
                .Rows.DefaultSize = 18
                .ScrollBars = ScrollBars.Both
                .ExtendLastCol = True
                .AllowSorting = AllowSortingEnum.None       'ﾍｯﾀﾞｰのｸﾘｯｸでｿｰﾄしない(行追加時のFR_ID新規/既存の判定が大変になるので)
                .Cols(CMlngvsfFrListNo).TextAlign = TextAlignEnum.LeftCenter               '数値左
                .Cols(CMlngvsfFrListFrId).TextAlign = TextAlignEnum.RightCenter 
                .Cols(CMlngvsfFrListLot).TextAlign = TextAlignEnum.RightCenter             '文字右
                .Cols(CMlngvsfFrListRecip).TextAlign = TextAlignEnum.LeftCenter 
                .Cols(CMlngvsfFrListAcceleFacter).TextAlign = TextAlignEnum.RightCenter 
                .Cols(CMlngvsfFrListCumProcessTime).TextAlign = TextAlignEnum.RightCenter 
                .Cols(CMlngvsfFrListProcessTime).TextAlign = TextAlignEnum.RightCenter 
                .Cols(CMlngvsfFrListCalcCumProTime).TextAlign = TextAlignEnum.RightCenter 
                .Cols(CMlngvsfFrListDate).TextAlign = TextAlignEnum.LeftCenter 
                .Cols(CMlngvsfFrListUser).TextAlign = TextAlignEnum.LeftCenter 
                .Styles.Highlight.BackColor = ColorTranslator.FromWin32(CMlngBKColorCel)   '選択時のﾊﾞｯｸｶﾗｰ(薄紫)
                .Styles.Highlight.ForeColor = ColorTranslator.FromWin32(CMlngOkForeColor)  '選択時の文字色(黒)
                .Styles.Focus.BackColor = ColorTranslator.FromWin32(CMlngBKColorCel)       '選択時のﾊﾞｯｸｶﾗｰ(薄紫)
                .Styles.Focus.ForeColor = ColorTranslator.FromWin32(CMlngOkForeColor)      '選択時の文字色(黒)
                .AllowMerging =  AllowMergingEnum.RestrictRows                             '縦のﾏｰｼﾞ
                .Cols(CMlngvsfFrListFrId).AllowMerging = True                              'FR_IDはﾏｰｼﾞして表示
                
                '@一覧表ﾀｲﾄﾙの設定
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfFrListRowTitle, CMlngvsfFrListColTitle, .Rows.Count - 1, .Cols.Count - 1) '表題
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                       '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)          '背景色
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                         '文字位置 中央表示
                headerStyle.Trimming  = StringTrimming.None                                'NSYS ﾍｯﾀﾞは省略表示なしに設定
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfFrListHFontSize, _
                                            headerStyle.Font.Style, headerStyle.Font.Unit) 'ﾌｫﾝﾄｻｲｽﾞ
                cellRange.Style = headerStyle
                .Rows(CMlngvsfFrListRowTitle).Height = CMlngvsfFrListHHeight               '高さ
                
                
                '@列幅設定
                .Cols(CMlngvsfFrListNo).Width = CMlngvsfFrListNoW
                .Cols(CMlngvsfFrListFrId).Width = CMlngvsfFrListFrIdW
                .Cols(CMlngvsfFrListLot).Width = CMlngvsfFrListLotW
                .Cols(CMlngvsfFrListRecip).Width = CMlngvsfFrListRecipW
                .Cols(CMlngvsfFrListAcceleFacter).Width = CMlngvsfFrListAcceleFacterW
                .Cols(CMlngvsfFrListCumProcessTime).Width = CMlngvsfFrListCumProcessTimeW
                .Cols(CMlngvsfFrListProcessTime).Width = CMlngvsfFrListProcessTimeW
                .Cols(CMlngvsfFrListCalcCumProTime).Width = CMlngvsfFrListCalcCumProTimeW
                .Cols(CMlngvsfFrListDate).Width = CMlngvsfFrListDateW
                .Cols(CMlngvsfFrListUser).Width = CMlngvsfFrListUserW

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfFrListRowTitle, CMlngvsfFrListNo, CMstrvsfFrListNoT)
                .SetData(CMlngvsfFrListRowTitle, CMlngvsfFrListFrId, CMstrvsfFrListFrIdT)
                .SetData(CMlngvsfFrListRowTitle, CMlngvsfFrListLot, CMstrvsfFrListLotT)
                .SetData(CMlngvsfFrListRowTitle, CMlngvsfFrListRecip, CMstrvsfFrListRecipT)
                .SetData(CMlngvsfFrListRowTitle, CMlngvsfFrListCumProcessTime, CMstrvsfFrListCumProcessTimeT)
                .SetData(CMlngvsfFrListRowTitle, CMlngvsfFrListProcessTime, CMstrvsfFrListProcessTimeT)
                .SetData(CMlngvsfFrListRowTitle, CMlngvsfFrListAcceleFacter, CMstrvsfFrListAcceleFacterT)
                .SetData(CMlngvsfFrListRowTitle, CMlngvsfFrListCalcCumProTime, CMstrvsfFrListCalcCumProTimeT)
                .SetData(CMlngvsfFrListRowTitle, CMlngvsfFrListDate, CMstrvsfFrListDateT)
                .SetData(CMlngvsfFrListRowTitle, CMlngvsfFrListUser, CMstrvsfFrListUserT)
                
                .Redraw = True

                '@無効化
                .Enabled = False
                
                mblnEventCancelFlag = False
                
            End With
            
            '@情報取得日時
            lblNowDate.Text = vbNullString
            
            '@該当件数
            lblLotCnt.Text = vbNullString
            
            '@時間注意と時間オーバーのラベル設定
            lblWarTime.Text = CMstrWarTimeLab & CMstrh
            lblErrTime.Text = CMstrErrTimeLab & CMstrh
        '@↓2016/06/13 (Mon) 16:18:12 T.Oide **************************************************
            labRefValue.Text = CMstrFrRefValueLab & CMstrh
        '@↑2016/06/13 (Mon) 16:18:12 T.Oide **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFrList_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnChkReg
    '機　能：登録前の設定ﾁｪｯｸを実施
    '引　数：
    '戻り値：True：設定OK、Fase:設定に問題あり
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Function prvblnChkReg() As Boolean

        Dim llngCnt         As Integer      'ｶｳﾝﾀｰ
        Dim lblnFindFlag    As Boolean      '編集行発見ﾌﾗｸﾞ

        Try
            
            '@結果初期化
            prvblnChkReg = False
            
            '@ｸﾞﾘｯﾄﾞの行数ぶんﾙｰﾌﾟ
            lblnFindFlag = False
            llngCnt = 1
            Do While vsfFrList.Rows.Count > llngCnt
            
                '@編集行か
                If vsfFrList.GetDataDisplay(llngCnt, CMlngvsfFrListNo) = CMstrEditMark Then
                    
                    '@編集行発見
                    lblnFindFlag = True
                    
                    '@登録日時、登録者 以外NULLはないか
                    If vsfFrList.GetDataDisplay(llngCnt, CMlngvsfFrListNo) = vbNullString Or _
                       vsfFrList.GetData(llngCnt, CMlngvsfFrListFrId) = vbNullString Or _
                       vsfFrList.GetData(llngCnt, CMlngvsfFrListLot) = vbNullString Or _
                       vsfFrList.GetData(llngCnt, CMlngvsfFrListRecip) = vbNullString Or _
                       vsfFrList.GetData(llngCnt, CMlngvsfFrListCumProcessTime) = vbNullString Or _
                       vsfFrList.GetData(llngCnt, CMlngvsfFrListProcessTime) = vbNullString Or _
                       vsfFrList.GetData(llngCnt, CMlngvsfFrListAcceleFacter) = vbNullString Or _
                       vsfFrList.GetData(llngCnt, CMlngvsfFrListCalcCumProTime) = vbNullString Then
                             
                        '@NULLがある場合はFalseのまま終了
                        Exit Function
                    
                    End If
                    
                End If
                
                llngCnt = llngCnt + 1
            Loop
            
            '@編集行はあったか
            If lblnFindFlag = True Then
                '@結果OKを格納
                prvblnChkReg = True
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnChkReg"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：vsfFrList_Edit
    '機　能：ｸﾞﾘｯﾄﾞの編集可否を判定
    '引　数：なし
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub vsfFrList_Edit()

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfFrList.Rows.Count <= vsfFrList.Rows.Fixed Then
                Return
            End If

            With vsfFrList
            
                Select Case .Col
                    
                    '@FR累積処理時間(h)、処理時間(h)、FR消耗度加速係数、FR(計算)累積処理時間(h)、ロットID、レシピID
                    Case CMlngvsfFrListCumProcessTime, CMlngvsfFrListProcessTime, _
                         CMlngvsfFrListAcceleFacter, CMlngvsfFrListCalcCumProTime, CMlngvsfFrListLot, CMlngvsfFrListRecip
                    
                        '@編集行か
                        If .GetDataDisplay(.Row, CMlngvsfFrListNo) = CMstrEditMark Then
                            
                            '@編集状態にする
                            .Select(.Row, .Col)
                            .Styles.Editor.BackColor = SystemColors.Window
                            .StartEditing()
                            
                        End If
                        
                    '@その他
                    Case Else
                        
                        '@編集は不可
                        
                End Select
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFrList_Edit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfFrListShow
    '機　能：ﾃﾞｰﾀを検索して表示する
    '引　数：なし
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：2016/06/13 (Mon) 16:23:43
    '備　考：
    Private Sub prvvsfFrListShow()

        Dim llngCnt             As Integer              '汎用ｶｳﾝﾀ
        Dim lblnAns             As Boolean              '関数結果
        Dim lstrFormName        As String               'ﾌｫｰﾑ名
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名
        Dim lTypeFbContFrHist   As pubTypFbContFrHist   'FR使用履歴格納用

        Try
            
            '@ﾚｽﾎﾟﾝ開始
            lstrFormName = Me.Name
            lstrEventName = "cmdSerch_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@FR使用履歴情報取得
            lblnAns = pubblnFrHistry_Sel(CMstrfb__contetfrhistVer, _
                                         cmbWp.Value, _
                                         cmbChanber.Value, _
                                         lTypeFbContFrHist)
            '@結果判定
            If lblnAns = True Then
                '@成功の場合
                
                '@時間注意と時間オーバーのラベル設定
                lblWarTime.Text = CMstrWarTimeLab & lTypeFbContFrHist.strWarMsgTime & CMstrh
                lblErrTime.Text = CMstrErrTimeLab & lTypeFbContFrHist.strErrMsgTime & CMstrh
        '@↓2016/06/13 (Mon) 16:18:58 T.Oide **************************************************
                labRefValue.Text = CMstrFrRefValueLab & lTypeFbContFrHist.strRfRefValueTime & CMstrh
        '@↑2016/06/13 (Mon) 16:18:58 T.Oide **************************************************

                '@取得結果をｸﾞﾘｯﾄﾞに表示
                With lTypeFbContFrHist

                    '@ｸﾞﾘｯﾄﾞを有効にする
                    vsfFrList.Enabled = True

                    RemoveHandler vsfFrList.RowColChange, AddressOf vsfFrList_RowColChange
                    vsfFrList.Redraw = False
                    vsfFrList.Rows.Count = 1

                    '@変数のﾃﾞｰﾀ数文ﾙｰﾌﾟする
                    llngCnt = 1
                    vsfFrList.Rows.Count = .lngFbConstFrHistCnt + 1

                    For llngCnt = 1 To .lngFbConstFrHistCnt
                        With .fbConstFrHistList(llngCnt-1)
                    
                            '@ﾃﾞｰﾀをｸﾞﾘｯﾄﾞに表示
                            vsfFrList.SetData(llngCnt, CMlngvsfFrListNo, vsfFrList.Rows.Count - llngCnt)  'No
                            vsfFrList.SetData(llngCnt, CMlngvsfFrListFrId, .strFrId)                      'FR_ID
                            vsfFrList.SetData(llngCnt, CMlngvsfFrListLot, .strLotID)                      'ﾛｯﾄID
                            vsfFrList.SetData(llngCnt, CMlngvsfFrListRecip, .strRrecipId)                 'ﾚｼﾋﾟID
                            vsfFrList.SetData(llngCnt, CMlngvsfFrListCumProcessTime, .strCumProcTime)     'FR累積使用時間
                            vsfFrList.SetData(llngCnt, CMlngvsfFrListProcessTime, .strProcTime)           '処理時間
                            vsfFrList.SetData(llngCnt, CMlngvsfFrListAcceleFacter, .strAcceleFacter)      '加速係数
                            vsfFrList.SetData(llngCnt, CMlngvsfFrListCalcCumProTime, .strCalcCumProcTime) 'FR(計算)累積使用時間
                            vsfFrList.SetData(llngCnt, CMlngvsfFrListDate, .strEntryTime)                 '登録日時
                            vsfFrList.SetData(llngCnt, CMlngvsfFrListUser, .strEmpName)                   '登録者
                        
                            '@背景色設定(ﾜｰﾆﾝｸﾞ：黄色、ｵｰﾊﾞｰ：赤）
                            If CLng(.strCalcCumProcTime) >= CLng(lTypeFbContFrHist.strErrMsgTime) Then
                                '@背景赤
                                Dim newStyle As CellStyle = vsfFrList.Styles.Add("CustomStyle_BackColor_vbRed")
                                newStyle.BackColor = Color.Red 'vbRed
                                Dim cellRange As CellRange = vsfFrList.GetCellRange(llngCnt, CMlngvsfFrListCalcCumProTime)
                                cellRange.Style = newStyle
                            ElseIf CLng(.strCalcCumProcTime) >= CLng(lTypeFbContFrHist.strWarMsgTime) Then
                                '@背景黄
                                Dim newStyle As CellStyle = vsfFrList.Styles.Add("CustomStyle_BackColor_vbYellow")
                                newStyle.BackColor = Color.Yellow 'vbYellow
                                Dim cellRange As CellRange = vsfFrList.GetCellRange(llngCnt, CMlngvsfFrListCalcCumProTime)
                                cellRange.Style = newStyle
                            End If
                            
                        End With
                        
                    Next llngCnt

                    AddHandler vsfFrList.RowColChange, AddressOf vsfFrList_RowColChange
                    vsfFrList.Row = CMlngvsfFrListRowTitle

                End With

                '@列幅自動調整(ﾚｼﾋﾟだけ、それ以外はほぼ幅が変わらないのでやってない)
                vsfFrList.AutoSizeCol(CMlngvsfFrListRecip, 6)

                vsfFrList.Redraw = True
            Else
                '@異常の場合終了
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
                
            End If
            
            '@各種ﾗﾍﾞﾙの表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)                           '情報取得日時表示
            lblLotCnt.Text = Format$(vsfFrList.Rows.Count - 1, CPstrDateFormatKanma)  '該当件数
            
            '@ﾚｽﾎﾟﾝｽ終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
                
            '@結果からだった場合はﾒｯｾｰｼﾞを表示する
            If vsfFrList.Rows.Count = 1 Then
            
                '@表示を初期化
                vsfFrList.Rows.Count = 1
                
                '@変数を初期化(一部初期化)
                Call prvMemInit(False)
                
                '@ﾒｯｾｰｼﾞ表示(<TRM04I>$$該当データがありません。)
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0004)
                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfFrListShow"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvButtonControl
    '機　能：ﾎﾞﾀﾝの有効/無効をｺﾝﾄﾛｰﾙ
    '引　数：なし
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub prvButtonControl()

        Dim lblnFuncResul   As Boolean

        Try
            
            '@============================
            '@ [検索]ﾎﾞﾀﾝ
            '@============================
                
            '@装置または処理部の設定は空か
            If cmbWp.Text = vbNullString Or _
               cmbChanber.Text = vbNullString Then
                cmdSerch.Enabled = False
            Else
                cmdSerch.Enabled = True
            End If
                    
            
            '@============================
            '@ [ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ] ﾎﾞﾀﾝ
            '@============================
            
            '一覧にデータはあるか
            If vsfFrList.Rows.Count = CMlngOne Then
                cmdClipCopy.Enabled = False
            Else
                cmdClipCopy.Enabled = True
            End If
            
            '@============================
            '@ [行追加]ﾎﾞﾀﾝ
            '@============================
            
            '@選択行がﾀｲﾄﾙ以外または、検索件数がNULL以外か
            If vsfFrList.Row > CMlngZero Or lblLotCnt.Text <> vbNullString Then
                '@「*」列が既に存在するか
                If prvChkEdit() = True Then
                    '@編集行は一度に1行しか登録させない(同時に登録されるとデータの順番が時間で判断できないので)
                    cmdAdd.Enabled = False
                Else
                    cmdAdd.Enabled = True
                End If
            Else
                cmdAdd.Enabled = False
            End If
            
            '@============================
            '@ [削除]ﾎﾞﾀﾝ
            '@============================
            
            '@編集中の行か
            If vsfFrList.Row > CMlngZero AndAlso _
                vsfFrList.GetDataDisplay(vsfFrList.Row, CMlngvsfFrListNo) = CMstrEditMark Then
                cmdDel.Enabled = True
            Else
                cmdDel.Enabled = False
            End If
            
            '@============================
            '@ [確定]ﾎﾞﾀﾝ
            '@============================

            '編集行ﾁｪｯｸ
            lblnFuncResul = prvChkEdit()
            
            '@編集中行はあったか
            If lblnFuncResul = True Then
                cmdRegist.Enabled = True
            Else
                cmdRegist.Enabled = False
            End If
            
            
            '@============================
            '@ [閉じる]ﾎﾞﾀﾝ
            '@============================
            
            '常に有効
            cmdClose.Enabled = True
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvButtonControl"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvChkEdit
    '機　能：編集中か判定する
    '引　数：なし
    '戻り値：True：編集中、False：編集中じゃない
    '作成日：2014/11/11 (Tue) 11:41:41 T.Oide
    '更新日：2014/11/11 (Tue) 11:41:41
    '備　考：
    Private Function prvChkEdit() As Boolean

        Dim llngCnt     As Integer
        
        Try
            
            prvChkEdit = False
            
            '@全レコード確認
            For llngCnt = 1 To vsfFrList.Rows.Count - 1
            
                '@ No列は「*」か（No列が｢*｣が編集中の列)
                If vsfFrList.GetDataDisplay(llngCnt, CMlngvsfFrListNo) = CMstrEditMark Then
                    '@編集中
                    prvChkEdit = True
                    Exit For
                End If
                
            Next llngCnt
                
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvChkEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvMemInit
    '機　能：Private変数を初期化する
    '引　数：blnAllInitFlag:True：全て初期化、False：一部初期化
    '戻り値：
    '作成日：2014/11/07 (Fri) 15:12:55 T.Oide
    '更新日：
    '備　考：
    Private Sub prvMemInit(ByVal blnAllInitFlag As Boolean)

        Try

            '@変数を初期化する
            mblnEventCancelFlag = False         'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
            mstrBeforEditValue = vbNullString   'ｸﾞﾘｯﾄﾞ変更前の値

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMemInit"
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


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfFrList.BeforeDoubleClick

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


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfFrList.KeyDownEdit

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

    '関数名：flex_SetupEditor
    '機　能：グリッド内コンボボックス表示行数調整
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/11/14 (Thu) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFrList.SetupEditor

        Try
            If TypeOf sender.Editor Is ComboBox
                '行の高さを変更
                Dim editor As ComboBox = CType(sender.Editor, ComboBox)
                editor.DrawMode = DrawMode.OwnerDrawFixed
                editor.DropDownHeight = 106
                editor.MaxDropDownItems = 12
            End If

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub

    '関数名：cursor_Enter
    '機　能 ： 項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Enter, _
            cmdSerch.Enter, cmdAdd.Enter, cmdDel.Enter, cmdClipCopy.Enter, cmdRegist.Enter, _
            cmbWp.Enter, cmbChanber.Enter, vsfFrList.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '自動Validate = OFF
            Case cmdClose.Name, cmdAdd.Name, cmdDel.Name
                Me.AutoValidate = AutoValidate.Disable

            '自動Validate = ON
            Case Else
                Me.AutoValidate = AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

    '関数名：vsfParameterList_ChangeEdit
    '機　能：ﾊﾟﾗﾒｰﾀﾘｽﾄ 編集変更時
    '引　数：sender ：イベント発生元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/03/08 (Fri) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub vsfFrList_ChangeEdit(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFrList.ChangeEdit
        Try

            With vsfFrList
            
                Select Case .Col
                    Case CMlngvsfFrListLot,
                         CMlngvsfFrListRecip,
                         CMlngvsfFrListCumProcessTime,
                         CMlngvsfFrListProcessTime,
                         CMlngvsfFrListAcceleFacter,
                         CMlngvsfFrListCalcCumProTime

                        'テキスト長を文字数でなくバイト数で切り詰める
                        '内部で .Editor.Text への代入処理があるので、イベント再帰を回避する
                        RemoveHandler vsfFrList.ChangeEdit, AddressOf vsfFrList_ChangeEdit
                        pubTextBoxLimit_Set(CType(.Editor, TextBox), mstrChangeEditValue)
                        AddHandler vsfFrList.ChangeEdit, AddressOf vsfFrList_ChangeEdit

                        '@編集前文字列の設定
                        mstrChangeEditValue = vsfFrList.Editor.Text
                End Select
                    
            End With

            Exit Sub
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFrList_ChangeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try

    End Sub

End Class
