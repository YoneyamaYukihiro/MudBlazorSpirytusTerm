'ﾌｧｲﾙ名：xxCM00Z1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：故障現象名選択/保全記録票選択画面
'作成日：2007/03/14 (Wed) 16:17:57 N.Kojima
'更新日：2008/03/17 (Mon) 10:00:24 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00Z1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00Z1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00Z1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00Z1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00Z1)
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
    '====================================Private============================================
    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyCM00Z1      'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrrep_repairlistVer                As String = "01.01"             '故障修理記録票一覧取得
    Private Const CMstrpre_preservelistVer              As String = "01.00"             '保全記録票一覧取得
    Private Const CMstrpre_chgpreservereportVer         As String = "01.00"             '保全記録票登録/更新

    '@故障修理記録票選択時用--------------------------------------------------------------------------------
    '@故障修理記録票選択時の列数
    Private Const CMlngvsfRepairCols                    As Integer = 6                     '列数

    '@vsfMainteListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfRepColNo                      As Integer = 0                     '№
    Private Const CMlngvsfRepColRepairNo                As Integer = 1                     '発行№
    Private Const CMlngvsfRepColRepairName              As Integer = 2                     '故障現象名
    Private Const CMlngvsfRepColRepairNameAll           As Integer = 3                     '故障現象名(全文)(非表示)
    Private Const CMlngvsfRepColRepairContents          As Integer = 4                     '故障現象詳細
    Private Const CMlngvsfRepColRepairContentsAll       As Integer = 5                     '故障現象詳細(全文)(非表示)

    '@vsfMainteListの定数宣言(幅)
    Private Const CMlngvsfRepColWNo                     As Integer = 36                   '№
    Private Const CMlngvsfRepColWRepairNo               As Integer = 76                  '発行№
    Private Const CMlngvsfRepColWRepairName             As Integer = 317                   '故障現象名
    Private Const CMlngvsfRepColWRepairNameAll          As Integer = 0                     '故障現象名(全文)(非表示)
    Private Const CMlngvsfRepColWRepairContents         As Integer = 317                   '故障現象詳細
    Private Const CMlngvsfRepColWRepairContentsAll      As Integer = 0                     '故障現象詳細(全文)(非表示)

    '@vsfMainteListの定数宣言(ｶﾗﾑ名)
    Private Const CMstrvsfRepColTNo                     As String = "№"                '№
    Private Const CMstrvsfRepColTRepairNo               As String = "発行№"            '発行№
    Private Const CMstrvsfRepColTRepairName             As String = "故障現象名"        '故障現象名
    Private Const CMstrvsfRepColTRepairNameAll          As String = "故障現象名(全文)"   '故障現象名(全文)(非表示)
    Private Const CMstrvsfRepColTRepairContents         As String = "故障現象詳細"      '故障現象詳細
    Private Const CMstrvsfRepColTRepairContentsAll      As String = "故障現象詳細(全文)" '故障現象詳細(全文)(非表示)
    '@故障修理記録票選択時用--------------------------------------------------------------------------------

    '@保全記録票選択時用------------------------------------------------------------------------------------
    '@故障修理記録票選択時の列数
    Private Const CMlngvsfPreserveCols                  As Integer = 16                    '列数

    '@vsfMainteListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfPreColNo                      As Integer = 0                     '№
    Private Const CMlngvsfPreColPreserveNo              As Integer = 1                     '発行№
    Private Const CMlngvsfPreColCategoryID              As Integer = 2                     'ｶﾃｺﾞﾘID(非表示)
    Private Const CMlngvsfPreColCategoryName            As Integer = 3                     'ｶﾃｺﾞﾘ名(非表示)
    Private Const CMlngvsfPreColPreserveCategoryID      As Integer = 4                     '保全ｶﾃｺﾞﾘID(非表示)
    Private Const CMlngvsfPreColPreserveCategoryName    As Integer = 5                     '保全ｶﾃｺﾞﾘ名
    Private Const CMlngvsfPreColPreserveStartDate       As Integer = 6                     '開始(予定)日時
    Private Const CMlngvsfPreColPreserveEndDate         As Integer = 7                     '終了(予定)日時
    Private Const CMlngvsfPreColPreserveItem            As Integer = 8                     '実施項目
    Private Const CMlngvsfPreColPreserveItemAll         As Integer = 9                     '実施項目(全文)(非表示)
    Private Const CMlngvsfPreColComment                 As Integer = 10                    'ｺﾒﾝﾄ(全文)(非表示)
    Private Const CMlngvsfPreColWpID                    As Integer = 11                    '装置ID(非表示)
    Private Const CMlngvsfPreColWpName                  As Integer = 12                    '装置名(非表示)
    Private Const CMlngvsfPreColEntryTime               As Integer = 13                    '登録日時(非表示)
    Private Const CMlngvsfPreColEditTime                As Integer = 14                    '更新日時(非表示)
    Private Const CMlngvsfPreColPreserveStatus          As Integer = 15                    '保全記録票状態(非表示)

    '@vsfMainteListの定数宣言(幅)
    Private Const CMlngvsfPreColWNo                     As Integer = 36                    '№
    Private Const CMlngvsfPreColWPreserveNo             As Integer = 76                    '発行№
    Private Const CMlngvsfPreColWCategoryID             As Integer = 0                     'ｶﾃｺﾞﾘID(非表示)
    Private Const CMlngvsfPreColWCategoryName           As Integer = 0                     'ｶﾃｺﾞﾘ名
    Private Const CMlngvsfPreColWPreserveCategoryID     As Integer = 0                     '保全ｶﾃｺﾞﾘID(非表示)
    Private Const CMlngvsfPreColWPreserveCategoryName   As Integer = 113                   '保全ｶﾃｺﾞﾘ名
    Private Const CMlngvsfPreColWPreserveStartDate      As Integer = 133                   '開始(予定)日時
    Private Const CMlngvsfPreColWPreserveEndDate        As Integer = 133                   '終了(予定)日時
    Private Const CMlngvsfPreColWPreserveItem           As Integer = 303                   '実施項目
    Private Const CMlngvsfPreColWPreserveItemAll        As Integer = 0                     '実施項目(全文)(非表示)
    Private Const CMlngvsfPreColWComment                As Integer = 0                     'ｺﾒﾝﾄ(全文)(非表示)
    Private Const CMlngvsfPreColWWpID                   As Integer = 0                     '装置ID(非表示)
    Private Const CMlngvsfPreColWWpName                 As Integer = 0                     '装置名(非表示)
    Private Const CMlngvsfPreColWEntryTime              As Integer = 0                     '登録日時(非表示)
    Private Const CMlngvsfPreColWEditTime               As Integer = 0                     '更新日時(非表示)
    Private Const CMlngvsfPreColWPreserveStatus         As Integer = 0                     '保全記録票状態(非表示)

    '@vsfMainteListの定数宣言(ｶﾗﾑ名)
    Private Const CMstrvsfPreColTNo                     As String = "№"                '№
    Private Const CMstrvsfPreColTPreserveNo             As String = "発行№"            '発行№
    Private Const CMstrvsfPreColTCategoryID             As String = "カテゴリID"        'ｶﾃｺﾞﾘID(非表示)
    Private Const CMstrvsfPreColTCategoryName           As String = "カテゴリ"          'ｶﾃｺﾞﾘ名
    Private Const CMstrvsfPreColTPreserveCategoryID     As String = "保全カテゴリID"    '保全ｶﾃｺﾞﾘID(非表示)
    Private Const CMstrvsfPreColTPreserveCategoryName   As String = "保全カテゴリ"      '保全ｶﾃｺﾞﾘ名
    Private Const CMstrvsfPreColTPreserveStartDate      As String = "開始(予定)日時"    '開始(予定)日時
    Private Const CMstrvsfPreColTPreserveEndDate        As String = "終了(予定)日時"    '終了(予定)日時
    Private Const CMstrvsfPreColTPreserveItem           As String = "実施項目"          '実施項目
    Private Const CMstrvsfPreColTPreserveItemAll        As String = "実施項目(全文)"     '実施項目(全文)(非表示)
    Private Const CMstrvsfPreColTComment                As String = "コメント"          'ｺﾒﾝﾄ(全文)(非表示)
    Private Const CMstrvsfPreColTWpID                   As String = "装置ID"            '装置ID(非表示)
    Private Const CMstrvsfPreColTWpName                 As String = "装置名"            '装置名(非表示)
    Private Const CMstrvsfPreColTEntryTime              As String = "登録日時"          '登録日時(非表示)
    Private Const CMstrvsfPreColTEditTime               As String = "更新日時"          '更新日時(非表示)
    Private Const CMstrvsfPreColTPreserveStatus         As String = "保全記録票状態"     '保全記録票状態(非表示)
    '@保全記録票選択時用------------------------------------------------------------------------------------

    '@ｸﾞﾘｯﾄﾞの設定
    Private Const CMlngvsfMainteListRowHeight           As Integer = 18                    '行高さ
    Private Const CMlngvsfMainteListTitleRowHeight      As Integer = 20                    'ﾀｲﾄﾙ行高さ
    Private Const CMlngvsfMainteListFontSize            As Integer = 11                    'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfMainteListTitleFontSize       As Integer = 11                    'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfMainteListTitleRow            As Integer = 0                     'ﾀｲﾄﾙ行

    '@ﾌｫｰﾑﾀｲﾄﾙ用定数
    Private Const CMstrRepairTitle                      As String = "故障現象名選択"     '故障修理記録での起動時ﾀｲﾄﾙ
    Private Const CMstrPreserveTitle                    As String = "保全記録票選択"     '保全記録での起動時ﾀｲﾄﾙ

    '@ｸﾞﾘｯﾄﾞ関連用定数
    Private Const CMlngDisplayByte30                    As Integer = 30                    '30ﾊﾞｲﾄ(一部表示用)
    Private Const CMstrPreserveCategoryName1            As String = "予防保全"           '保全ｶﾃｺﾞﾘ表示用
    Private Const CMstrPreserveCategoryName2            As String = "改良/改善保全"      '保全ｶﾃｺﾞﾘ表示用
    Private Const CMstrPreserveCategoryName3            As String = "ルーチンメンテ"     '保全ｶﾃｺﾞﾘ表示用

    '@ｺﾝﾎﾞ設定用定数
    Private Const CMlngCmbFontSize                      As Integer = 11                    'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 11                    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                      As Integer = 1                     'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbValueCol                      As Integer = 1                     '値取得列
    Private Const CMlngCmbGetCol                        As Integer = 0                     '表示列
    Private Const CMlngCmbDispColIndex                  As Integer = 0                     '表示列番

    '@ﾃｷｽﾄ関連用定数
    Private Const CMlngMaxDisp4Row                      As Integer = 4                     'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ｺﾒﾝﾄ4行入力欄)
    Private Const CMlngMaxRepairNameByte                As Integer = 128                   '故障現象名MaxByte

    '@検索日時用定数
    Private Const CMstrStartTime                        As String = " 00:00:00"         '00:00:00
    Private Const CMstrEndTime                          As String = " 23:59:59"         '23:59:59
    Private Const CMstrM                                As String = "M"                 '3ヶ月後計算用
    Private Const CMstrOneYear                          As String = "1年"               '表示ﾒｯｾｰｼﾞ(期間指定)

    '@表示ﾒｯｾｰｼﾞ用定数
    Private Const CMstrPreserveReport                   As String = "保全記録票"        '更新成功MSG(保全記録)
    Private Const CMstrUpdateMsg                        As String = "更新"              '更新成功MSG

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                         As String = "frmxxCM00Z1"       '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"         'ｲﾍﾞﾝﾄ名(ﾌｫｰﾑﾛｰﾄﾞ処理)
    Private Const CMstrCmdRegistClick                   As String = "cmdRegist_Click"   'ｲﾍﾞﾝﾄ名(確定ﾎﾞﾀﾝClick処理)
    Private Const CMstrPrvRepairListSearchProc          As String = "prvRepairListSearch_Proc"      'ｲﾍﾞﾝﾄ名(故障修理記録票一覧 検索処理)
    Private Const CMstrPrvPreserveListSearchProc        As String = "prvPreserveListSearch_Proc"    'ｲﾍﾞﾝﾄ名(故障修理記録票一覧 検索処理)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '@通信情報格納用ﾓｼﾞｭｰﾙ変数/構造体
    Private mtypRepairInfoReq                           As RepairInfoReq                '故障修理記録票一覧取得要求構造体
    Private mtypRepairInfoAns                           As List(Of RepairInfoAns)       '故障修理記録票一覧取得応答構造体
    Private mlngRepairListCnt                           As Integer                      '故障修理記録票一覧ﾘｽﾄ数格納用

    Private mtypPreserveInfoReq                         As PreserveInfoReq              '保全記録票一覧取得要求構造体
    Private mtypPreserveInfoAns                         As List(Of PreserveInfoAns)     '保全記録票一覧取得応答構造体
    Private mlngPreserveListCnt                         As Integer                      '保全記録票一覧ﾘｽﾄ数格納用

    Private mtypChgPreserveInfoReq                      As PreserveInfo                 '保全記録情報登録/更新要求構造体

    Private mtypChgSort                                 As ChgSort                      'ｿｰﾄ保持用
    Private mblnFormLoadFlag                            As Boolean                      'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private buttonProcessing                            As Boolean                      'NSYS ボタン2度押し対策   
    Private mblnCloseFromControlMenu                    As Boolean                      'NSYS システムコマンドでの画面クローズ   
    Private mblnWindowClose                             As Boolean                      'NSYS WindowCloseフラグ
    Private form_Load1st                                As Boolean                      'NSYS初回起動時のグリッドの選択行設定用フラグ
    Private RowTmp                                      As Integer                      'NSYS カレント行保持用

    Private lblLengthCountArray()  As Label

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


        lblLengthCountArray = {lblLengthCount1,lblLengthCount2}

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Form_Load()
        
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　ﾛｰﾄﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/14 (Wed) 16:28:36 N.Kojima
    '更新日：2008/02/07 (Thu) 11:22:29 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 11:22:29 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub Form_Load()
        
        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing 
            
            '@ｿｰﾄ保持構造体初期化
            With mtypChgSort
                .blnChgWidth = False        '列幅変更ﾌﾗｸﾞ(未変更)
                .strKey = vbNullString      'ｶﾚﾝﾄ行検索ｷｰ
                .lngCnt = 0                 '配列ｶｳﾝﾀ
                
                If .typChgSortList Is Nothing 
                 .typChgSortList = New List(Of ChgSortList) '配列
                Else 
                 .typChgSortList.Clear()
                End If

            End With
            
            '@=======================
            '@　ﾒｲﾝﾌｫｰﾑの初期化処理
            '@=======================
            Call prvFrmxxCM00Z1_Init()
            
            '@=======================
            '@　故障修理/保全記録票一覧ｸﾞﾘｯﾄﾞの初期化処理
            '@=======================
            Call prvVsfMainteList_Init()
            
            '@保全記録票起票済みﾌﾗｸﾞを初期化
            pblnPreserveReportRegistFlag = False
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            'NSYS 初回起動時のグリッドの選択行設定用フラグ
            form_Load1st = True

                                    
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/14 (Wed) 16:44:55 N.Kojima
    '更新日：2008/02/07 (Thu) 11:21:43 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 11:21:43 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Dim lstrDate        As String       '日付格納用
        Dim lstrWpId        As String       '装置ID格納用
        
        Try
                       
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理判別
            If mblnFormLoadFlag = False Then
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
                
                '@★ 起動区分により処理分岐 ★
                Select Case plngLoadClass
                    
                    '@〓 "1:故障修理記録" 〓
                    Case CPlngNumOne
                        
                        '@ﾌｫｰﾑのﾀｲﾄﾙ設定
                        Me.Text = CMstrRepairTitle
                        
                        '@装置名表示
                        lblWpName.Text = ptypRepairConnectInfo.strWpName
                        
                        '@装置ID退避
                        lstrWpId = ptypRepairConnectInfo.strWpID
                        
                        '@共通ﾌｨｰﾙﾄﾞ(ﾃｷｽﾄ)のﾀｲﾄﾙを変更
                        lblCommonField1Title.Text = CMstrvsfRepColTRepairName        '故障現象名
                        lblCommonField2Title.Text = CMstrvsfRepColTRepairContents    '故障現象詳細
                        
                        '@故障修理記録の場合は、新規作成ﾎﾞﾀﾝ無効
                        cmdNewEntry.Enabled = False


                    '@〓 "2:保全記録" 〓
                    Case CPlngNumTwo
                    
                        '@ﾌｫｰﾑのﾀｲﾄﾙ設定
                        Me.Text = CMstrPreserveTitle
                    
                        '@装置名表示
                        lblWpName.Text = ptypPreserveConnectInfo.strWpName
                        
                        '@装置ID退避
                        lstrWpId = ptypPreserveConnectInfo.strWpID
                        
                        '@共通ﾌｨｰﾙﾄﾞ(ﾃｷｽﾄ)のﾀｲﾄﾙを変更
                        lblCommonField1Title.Text = CMstrvsfPreColTPreserveItem      '実施項目
                        lblCommonField2Title.Text = CMstrvsfPreColTComment           'ｺﾒﾝﾄ
                
                End Select
                
                '@検索終了日に現在日時を、検索開始日に1年前の日付をｾｯﾄ
                calEnd.Value = Format$(Now, CPstrDateTimeYMD)
                lstrDate = Format$(DateAdd(CMstrM, -12, calEnd.Value), CPstrDateTimeYMD)
                calStart.Value = lstrDate
                
                '@=======================
                '@　検索処理
                '@=======================
                Call cmdSearch_Click(Me, New EventArgs())
                
                '@装置ID、検索開始日時、検索終了日時が設定されている場合
                If lstrWpId <> vbNullString And _
                    calStart.Value <> CPstrNullDate And _
                    calEnd.Value <> CPstrNullDate Then
                
                    '@検索ﾎﾞﾀﾝを有効にする
                    cmdSearch.Enabled = True
                Else
                    '@検索ﾎﾞﾀﾝを無効にする
                    cmdSearch.Enabled = False
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/14 (Wed) 16:47:46 N.Kojima
    '更新日：2007/03/14 (Wed) 16:47:46
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
                        
            '@以下の条件の場合、Key入力を受け付けないで処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
                
                '@〓 検索開始日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ 〓
                Case calStart.Name
                    
                    Select Case e.KeyCode
                        Case Keys.Return
                        
                            '@=======================
                            '@　検索開始日ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
                            '@=======================
                            RemoveHandler calStart.Validating, AddressOf calStart_Validate 
                            Call calStart_Validate(calStart, New CancelEventArgs(False))
                            AddHandler calStart.Validating, AddressOf calStart_Validate
                            e.Handled = True
                    End Select
                
                '@〓 検索終了日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ 〓
                Case calEnd.Name
                
                    Select Case e.KeyCode
                        Case Keys.Return
                        
                            '@=======================
                            '@　検索終了日ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
                            '@=======================
                            RemoveHandler calEnd.Validating, AddressOf calEnd_Validate 
                            Call calEnd_Validate(calEnd, New CancelEventArgs(False))
                            AddHandler calEnd.Validating, AddressOf calEnd_Validate 
                            e.Handled = True
                    End Select
                    
                '@〓 その他 〓
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
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌｫｰﾑ　ｱﾝﾛｰﾄﾞ時処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：なし
    '作成日：2007/03/14 (Wed) 16:48:49 N.Kojima
    '更新日：2008/02/07 (Thu) 11:23:07 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 11:23:07 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim ltypRepairInfoReq       As RepairInfoReq        '故障修理記録一覧取得要求構造体初期化用
        Dim ltypPreserveInfoReq     As PreserveInfoReq      '保全記録一覧取得要求構造体初期化用
        
        Try
            
            

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If
            
            '@起動区分が"2:保全記録"で、かつ保全記録票起票済みﾌﾗｸﾞが"False：未登録"か
            If plngLoadClass = CPlngNumTwo And pblnPreserveReportRegistFlag = False Then
                '@起動区分が"2:保全記録"で、保全記録票起票が未登録の場合
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000O)
                '@""<TRM0OW>$$保全記録票が登録(起票)されていません$[新規登録]ボタン押下で新規登録画面を起動し、$保全記録票を登録してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@新規登録ﾎﾞﾀﾝが有効か
                If cmdNewEntry.Enabled = True Then
                
                    '@新規登録ﾎﾞﾀﾝにﾌｫｰｶｽをｾｯﾄ
                    Call pubSetFocus(cmdNewEntry)
                End If
                
                e.Cancel = True
                Exit Sub
            End If
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If mtypChgSort.typChgSortList Is Nothing 
                mtypChgSort.typChgSortList = New List(Of ChgSortList) 
            Else 
                mtypChgSort.typChgSortList.Clear()
            End If 
            mtypChgSort.lngCnt = 0
            mtypChgSort.strKey = vbNullString
            mtypChgSort.blnChgWidth = False

            '@通信情報格納用ﾓｼﾞｭｰﾙ変数/構造体の初期化
            mtypRepairInfoReq = ltypRepairInfoReq           '故障修理記録一覧取得要求構造体

            '故障修理記録一覧取得応答構造体
            If mtypRepairInfoAns Is Nothing 
              mtypRepairInfoAns = New List(Of RepairInfoAns) 
            Else 
              mtypRepairInfoAns.Clear()
            End If
            
            mlngRepairListCnt = 0                           '故障修理記録一覧ﾘｽﾄ数格納用
            mtypPreserveInfoReq = ltypPreserveInfoReq       '保全記録一覧取得要求構造体

            '保全記録一覧取得応答構造体
            If mtypPreserveInfoAns Is Nothing 
              mtypPreserveInfoAns = New List(Of PreserveInfoAns) 
            Else 
               mtypPreserveInfoAns.Clear()
            End If                     
            mlngPreserveListCnt = 0                         '保全記録一覧ﾘｽﾄ数格納用
            
            '@各種Public変数を初期化
            pblnPreserveReportRegistFlag = False            '保全記録票起票済みﾌﾗｸﾞ
            pblnUseChangLoadKbn = False                     '起動区分
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
           
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStart_CalendarSelect
    '機　能：検索開始日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　ｶﾚﾝﾀﾞｰ選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 10:09:06 N.Kojima
    '更新日：2007/03/15 (Thu) 10:09:06
    '備　考：
    Private Sub calStart_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calStart.CalendarSelect

        Try
            
            '@=======================
            '@　検索開始日ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
            '@=======================
            RemoveHandler calStart.Validating, AddressOf calStart_Validate 
            Call calStart_Validate(calStart, New CancelEventArgs(False))
            AddHandler calStart.Validating, AddressOf calStart_Validate


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStart_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStart_Change
    '機　能：検索開始日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 10:09:20 N.Kojima
    '更新日：2008/02/07 (Thu) 11:23:40 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 11:23:40 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub calStart_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calStart.Change

        Try
            'NSYS 選択行を退避
             RowTmp = vsfMainteList.Row 
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞの初期化処理
            '@=======================
            prvVsfMainteList_Init
            
            '@共通ﾌｨｰﾙﾄﾞ1、2ﾃｷｽﾄをｸﾘｱ
            txtCommonField1.Text = vbNullString         '故障現象名or実施項目
            txtCommonField2.Text = vbNullString         '故障現象詳細orｺﾒﾝﾄ
            
            '@装置名、検索開始日時、検索終了日時が有効な日付で設定されている場合
            If lblWpName.Text <> vbNullString And _
                IsDate(calStart.Value) = True And _
                IsDate(calEnd.Value) = True Then
            
                '@検索ﾎﾞﾀﾝを有効にする
                cmdSearch.Enabled = True
            Else
                '@検索ﾎﾞﾀﾝを無効にする
                cmdSearch.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStart_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStart_Validate
    '機　能：検索開始日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 10:09:56 N.Kojima
    '更新日：2008/02/07 (Thu) 11:23:40 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 11:23:40 N.Kojima     検索期間を1年間にする対応&ｿｰｽ整備。(案件№02504)
    Private Sub calStart_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calStart.Validating

        Dim lstrNowDT           As String       '現在日付取得
        Dim lstrDate            As String       '3ヵ月後の日付格納用

        Try
           
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
           
                
            '@以下の条件の場合は処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If
                
            '@検索開始日が入力されているか
            If calStart.Value <> CPstrNullDate Then
                '@検索開始日が入力されている場合
                
                '@検索開始日の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(calStart.Value) = False Then
                    '@無効日付の場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽを保持
                    e.Cancel = True
                    Exit Sub
                Else
                    '@有効日付の場合
                    
                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                    
                    '@未来日付の場合
                    If Format$(Cdate(calStart.Value), CPstrDateTimeYMD) > lstrNowDT Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                        '@"未来日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                           
                        '@ﾌｫｰｶｽを保持
                        e.Cancel = True
                        Exit Sub
                    Else
                        '@未来日付以外の場合
                    
                        '@開始日付 > 終了日付か
                        If Format$(Cdate(calStart.Value), CPstrDateTimeYMD) > Format$(Cdate(calEnd.Value), CPstrDateTimeYMD) Then
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                            '@"開始日が終了日より大きくなっています。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@ﾌｫｰｶｽを保持
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                End If
            Else
                '@入力されていない(NULL：____/__/__)の場合
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002V)
                '@"開始日を入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを保持
                e.Cancel = True
                Exit Sub
            End If
            
            '@検索終了日が指定されている場合
            If calEnd.Value <> CPstrNullDate Then
            
                '@検索開始日の1年後を格納
                lstrDate = Format$(DateAdd(CMstrM, 12, calStart.Value), CPstrDateTimeYMDHM)
                
                '@検索開始日が検索終了日の1年後より大きい場合
                If lstrDate < calEnd.Value Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008W, CMstrOneYear)
                    '@"<TRM8WW>$$期間指定について、開始～終了までの間は$1年以内で設定してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@検索開始日にｾｯﾄﾌｫｰｶｽ
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            
            If ActiveControl.Name = calStart.name
                '@検索終了日が有効か
                If calEnd.Enabled = True Then
                    '@検索終了日にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(calEnd)
                Else
                    '@閉じるにｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmdClose)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStart_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calEnd_CalendarSelect
    '機　能：検索終了日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　ｶﾚﾝﾀﾞｰ選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 10:12:14 N.Kojima
    '更新日：2007/03/15 (Thu) 10:12:14
    '備　考：
    Private Sub calEnd_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calEnd.CalendarSelect

        Try
                        
            '@=======================
            '@　検索終了日ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
            '@=======================
            RemoveHandler calEnd.Validating, AddressOf calEnd_Validate 
            Call calEnd_Validate(calEnd, New CancelEventArgs(False))
            AddHandler calEnd.Validating, AddressOf calEnd_Validate 


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calEnd_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calEnd_Change
    '機　能：検索終了日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 10:12:27 N.Kojima
    '更新日：2008/02/07 (Thu) 11:23:40 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 11:23:40 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub calEnd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calEnd.Change

        Try
            'NSYS 選択行を退避
             RowTmp = vsfMainteList.Row 
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞの初期化処理
            '@=======================
            prvVsfMainteList_Init
            
            '@共通ﾌｨｰﾙﾄﾞ1、2ﾃｷｽﾄをｸﾘｱ
            txtCommonField1.Text = vbNullString         '故障現象名or実施項目
            txtCommonField2.Text = vbNullString         '故障現象詳細orｺﾒﾝﾄ
            
            '@装置名、検索開始日時、検索終了日時が有効な日付で設定されている場合
            If lblWpName.Text <> vbNullString And _
                IsDate(calStart.Value) = True And _
                IsDate(calEnd.Value) = True Then
            
                '@検索ﾎﾞﾀﾝを有効にする
                cmdSearch.Enabled = True
            Else
                '@検索ﾎﾞﾀﾝを無効にする
                cmdSearch.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calEnd_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calEnd_Validate
    '機　能：検索終了日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 10:12:47 N.Kojima
    '更新日：2007/03/15 (Thu) 10:12:47
    '備　考：
    Private Sub calEnd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calEnd.Validating

        Dim lstrNowDT           As String       '現在日付取得
        Dim lstrDate            As String       '3ヵ月前の日付格納用

        Try
                        
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
            '@以下の条件の場合は処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If
            
            '@検索終了日が入力されているか
            If calEnd.Value <> CPstrNullDate Then
                '@検索終了日が入力されている場合
                
                '@日付が有効か
                If pubblnYearRange_Chk(calEnd.Value) = False Then
                    '@日付が無効な場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽを保持
                    e.Cancel = True
                    Exit Sub
                Else
                    '@日付が有効な場合
                
                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                    
                    '@未来日付か
                    If Format$(Cdate(calEnd.Value), CPstrDateTimeYMD) > lstrNowDT Then
                        '@未来日付の場合
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                        '@"未来日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                           
                        '@ﾌｫｰｶｽを保持
                        e.Cancel = True
                        Exit Sub
                    Else
                        '@未来日付以外の場合
                    
                        '@開始日付 > 終了日時か
                        If Format$(Cdate(calStart.Value), CPstrDateTimeYMD) > Format$(Cdate(calEnd.Value), CPstrDateTimeYMD) Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                            '@"開始日が終了日より大きくなっています。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@ﾌｫｰｶｽを保持
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                End If
            Else
                '@入力されていない(NULL：____/__/__)の場合
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002W)
                '@"終了日を入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを保持
                e.Cancel = True
                Exit Sub
            End If
            
            '@検索開始日が指定されている場合
            If calStart.Value <> CPstrNullDate Then
            
                '@検索開始日の1年後を格納
                lstrDate = Format$(DateAdd(CMstrM, 12, calStart.Value), CPstrDateTimeYMDHM)
                
                '@検索開始日が検索終了日の1年後より大きい場合
                If lstrDate < calEnd.Value Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008W, CMstrOneYear)
                    '@"<TRM8WW>$$期間指定について、開始～終了までの間は$1年以内で設定してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@検索開始日にｾｯﾄﾌｫｰｶｽ
                    e.Cancel = True
                    Exit Sub
                End If
            End If

            'NSYS 動確時に確かめる
            If ActiveControl.Name = calEnd.Name 
                '@最新取得ﾎﾞﾀﾝが有効か
                If cmdSearch.Enabled = True Then
                    '@有効な場合は最新取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdSearch)
                Else
                    '@無効な場合は閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End If 

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calEnd_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSearch_Click
    '機　能：検索ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/14 (Wed) 16:59:14 N.Kojima
    '更新日：2008/02/07 (Thu) 11:04:43 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 11:04:43 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@以下の条件の場合は処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If
            
            
            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass
                
                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne
                    
                    '@装置ID、検索開始日、検索終了日が空白(NULL)の場合は処理中断
                    If ptypRepairConnectInfo.strWpID = vbNullString Or _
                        calStart.Value = CPstrNullDate Or calEnd.Value = CPstrNullDate Then
                        
                        Exit Sub
                    End If
                    
                    '@=======================
                    '@　故障修理記録票一覧　検索&作成処理
                    '@=======================
                    Call prvRepairListSearch_Proc()

                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo
                
                    '@装置ID、検索開始日、検索終了日が空白(NULL)の場合は処理中断
                    If ptypPreserveConnectInfo.strWpID = vbNullString Or _
                        calStart.Value = CPstrNullDate Or calEnd.Value = CPstrNullDate Then
                        
                        Exit Sub
                    End If
                
                    '@=======================
                    '@　保全記録票一覧　検索&作成処理
                    '@=======================
                    Call prvPreserveListSearch_Proc()
            
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSearch_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfMainteList_AfterSort
    '機　能：故障修理記録票/保全記録票一覧ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ順
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 10:15:52 N.Kojima
    '更新日：2008/02/07 (Thu) 11:23:40 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 11:23:40 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub vsfMainteList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfMainteList.AfterSort

        Try
            AddHandler vsfMainteList.BeforeRowColChange, AddressOf vsfMainteList_BeforeRowColChange

            'NSYS データ行がない場合は処理を抜ける
            If vsfMainteList.Rows.Count <= vsfMainteList.Rows.Fixed Then
                Return
            End If
            

            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                Dim typChgSortListTmp As ChgSortList = New ChgSortList
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納（昇順/降順）
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList.Add(typChgSortListTmp)
            End With
            

            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass

                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne
            
                    '@=======================
                    '@　ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列)
                    '@=======================
                    Call pubVsfAfterSort(vsfMainteList, CMlngvsfRepColRepairNo & vbTab & CMlngvsfRepColRepairNameAll)


                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo
            
                    '@=======================
                    '@　ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列)
                    '@=======================
                    Call pubVsfAfterSort(vsfMainteList, CMlngvsfPreColPreserveNo & vbTab & CMlngvsfPreColPreserveItemAll)

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMainteList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMainteList_AfterUserResize
    '機　能：故障修理記録票/保全記録票一覧ｸﾞﾘｯﾄﾞ　列幅変更時処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 10:16:51 N.Kojima
    '更新日：2007/03/15 (Thu) 10:16:51
    '備　考：
    Private Sub vsfMainteList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfMainteList.AfterResizeColumn, vsfMainteList.AfterResizeRow

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfMainteList.Rows.Count <= vsfMainteList.Rows.Fixed Then
                Return
            End If
            

            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMainteList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMainteList_BeforeRowColChange
    '機　能：故障修理記録票/保全記録票一覧ｸﾞﾘｯﾄﾞ　行/列変更前処理
    '引　数：OldRow ：旧行
    '　　　：OldCol ：旧列
    '　　　：NewRow ：新行
    '　　　：NewCol ：新列
    '　　　：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 10:17:06 N.Kojima
    '更新日：2008/02/07 (Thu) 11:23:40 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 11:23:40 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub vsfMainteList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfMainteList.BeforeRowColChange
                                                   
        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfMainteList.Rows.Count <= vsfMainteList.Rows.Fixed Then
                Return
            End If
           
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0  Then
                
                '@ｶﾚﾝﾄ行検索用のｷｰを格納
                With vsfMainteList

                    '@★ 起動区分により処理分岐 ★
                    Select Case plngLoadClass
                        
                        '@〓 "1:故障修理記録" 〓
                        Case CPlngNumOne
                        
                            mtypChgSort.strKey = .GetData(e.NewRange.r1, CMlngvsfRepColRepairNo) & _
                                                 .GetData(e.NewRange.r1, CMlngvsfRepColRepairNameAll)

                        '@〓 "2:保全記録" 〓
                        Case CPlngNumTwo
                        
                            mtypChgSort.strKey = .GetData(e.NewRange.r1, CMlngvsfPreColPreserveNo) & _
                                                 .GetData(e.NewRange.r1, CMlngvsfPreColPreserveItemAll)
                           
                    End Select
                End With
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMainteList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMainteList_BeforeSort
    '機　能：故障修理記録票/保全記録票一覧ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ順
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 10:17:55 N.Kojima
    '更新日：2008/02/07 (Thu) 11:23:40 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 11:23:40 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub vsfMainteList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfMainteList.BeforeSort

        Try
            RemoveHandler vsfMainteList.BeforeRowColChange, AddressOf vsfMainteList_BeforeRowColChange 

            'NSYS データ行がない場合は処理を抜ける
            If vsfMainteList.Rows.Count <= vsfMainteList.Rows.Fixed Then
                Return
            End If
            

            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass

                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne

                    '@=======================
                    '@　ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                    '@=======================
                    Call pubVsfBeforeSort(vsfMainteList, CMlngvsfRepColRepairNo & vbTab & CMlngvsfRepColRepairNameAll)

                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo

                    '@=======================
                    '@　ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                    '@=======================
                    Call pubVsfBeforeSort(vsfMainteList, CMlngvsfPreColPreserveNo & vbTab & CMlngvsfPreColPreserveItemAll)

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMainteList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMainteList_DblClick
    '機　能：故障修理記録票/保全記録票一覧ｸﾞﾘｯﾄﾞ　ﾀﾞﾌﾞﾙｸﾘｯｸ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 10:29:53 N.Kojima
    '更新日：2007/03/15 (Thu) 10:29:53
    '備　考：
    Private Sub vsfMainteList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMainteList.DoubleClick

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfMainteList.Rows.Count <= vsfMainteList.Rows.Fixed Then
                Return
            End If
            
            
            '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
            If vsfMainteList.MouseRow = 0 Then
                Exit Sub
            End If
            
            '@=======================
            '@　選択確定処理
            '@=======================
            Call cmdRegist_Click(sender, New EventArgs)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMainteList_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMainteList_RowColChange
    '機　能：故障修理記録票/保全記録票一覧ｸﾞﾘｯﾄﾞ　行/列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 10:18:24 N.Kojima
    '更新日：2008/02/07 (Thu) 11:23:40 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 11:23:40 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub vsfMainteList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMainteList.RowColChange

        Try
            
            With vsfMainteList
                
                '@選択行がﾀｲﾄﾙ行以外の場合には,編集ﾎﾞﾀﾝの活性化処理を行う
                If .Row <> 0 And .Row >= 1　Then

                    '@★ 起動区分により処理分岐 ★
                    Select Case plngLoadClass

                        '@〓 "1:故障修理記録" 〓
                        Case CPlngNumOne
                
                            '@故障現象名ﾃｷｽﾄに全文表示
                            txtCommonField1.Text = .GetData(.Row, CMlngvsfRepColRepairNameAll)
                            '@故障現象詳細ﾃｷｽﾄに全文表示
                            txtCommonField2.Text = .GetData(.Row, CMlngvsfRepColRepairContentsAll)

                        '@〓 "2:保全記録" 〓
                        Case CPlngNumTwo
                
                            '@実施項目ﾃｷｽﾄに全文表示
                            txtCommonField1.Text = .GetData(.Row, CMlngvsfPreColPreserveItemAll)
                            '@ｺﾒﾝﾄﾃｷｽﾄに全文表示
                            txtCommonField2.Text = .GetData(.Row, CMlngvsfPreColComment)
                            
                    End Select
                    
                    '@確定ﾎﾞﾀﾝを有効にする
                    cmdRegist.Enabled = True
                Else
                    '@確定ﾎﾞﾀﾝを無効にする
                    cmdRegist.Enabled = False
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMainteList_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/03/10 (Mon) 19:03:51 N.Kojima **************************************************
    '関数名：txtCommonField1_Change
    '機　能：故障現象名/実施項目ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：
    Private Sub txtCommonField1_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCommonField1.Change

        Dim llngNowByte     As Integer  'ﾊﾞｲﾄ数
        Dim llngMaxByte     As Integer  '最大ﾊﾞｲﾄ数

        Try
                        
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtCommonField1.NowByte
                
            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass
                
                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne
                
                    llngMaxByte = CMlngMaxRepairNameByte        'MAX128Byte

                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo
                
                    llngMaxByte = CPlngLotCommentsMaxByte       'MAX2048Byte
                    
            End Select

            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblLengthCount1.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                           llngNowByte, _
                                                           llngMaxByte)
            
            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtCommonField1, CMlngMaxDisp4Row, cmdField1Up, cmdField1Down)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCommonField1_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/03/10 (Mon) 19:03:51 N.Kojima **************************************************

    '@↓2008/03/10 (Mon) 19:04:15 N.Kojima **************************************************
    '関数名：txtCommonField1_KeyUp
    '機　能：故障現象名/実施項目ﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：
    Private Sub txtCommonField1_KeyUp(ByVal sender As Object, ByVal e As keyEventArgs) Handles txtCommonField1.KeyUp

        Try
                        
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtCommonField1, CMlngMaxDisp4Row, cmdField1Up, cmdField1Down)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCommonField1_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/03/10 (Mon) 19:04:15 N.Kojima **************************************************

    '@↓2008/03/10 (Mon) 19:04:51 N.Kojima **************************************************
    '関数名：txtCommonField1_MouseUp
    '機　能：故障現象名/実施項目ﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：
    Private Sub txtCommonField1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtCommonField1.MouseUp

        Try
                        
            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtCommonField1, CMlngMaxDisp4Row, cmdField1Up, cmdField1Down, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCommonField1_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/03/10 (Mon) 19:04:51 N.Kojima **************************************************

    '@↓2008/02/29 (Fri) 11:10:27 N.Kojima **************************************************
    '関数名：cmdField1Up_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(故障現象詳細/実施項目ﾃｷｽﾄ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/02/29 (Fri) 10:59:31 N.Kojima
    '更新日：2008/02/29 (Fri) 10:59:31
    '備　考：
    Private Sub cmdField1Up_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdField1Up.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@以下の条件の場合は処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If
            
            '@=======================
            '@　上ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubtxtCmdUp_Proc(txtCommonField1, CMlngMaxDisp4Row, cmdField1Up, cmdField1Down)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdField1Up_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/02/29 (Fri) 11:10:27 N.Kojima **************************************************

    '@↓2008/02/29 (Fri) 11:09:18 N.Kojima **************************************************
    '関数名：cmdField1Down_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(故障現象名/実施項目ﾃｷｽﾄ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/02/29 (Fri) 11:00:49 N.Kojima
    '更新日：2008/02/29 (Fri) 11:00:49
    '備　考：
    Private Sub cmdField1Down_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdField1Down.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@以下の条件の場合は処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If
            
            '@=======================
            '@　下ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubtxtCmdDown_Proc(txtCommonField1, CMlngMaxDisp4Row, cmdField1Up, cmdField1Down)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdField1Down_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/02/29 (Fri) 11:09:18 N.Kojima **************************************************

    '@↓2008/03/10 (Mon) 19:03:51 N.Kojima **************************************************
    '関数名：txtCommonField2_Change
    '機　能：故障現象詳細/停止ｺﾒﾝﾄﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：
    Private Sub txtCommonField2_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCommonField2.Change

        Dim llngNowByte     As Integer  'ﾊﾞｲﾄ数

        Try
                        
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtCommonField2.NowByte
            
            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblLengthCount2.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                           llngNowByte, _
                                                           CPlngLotCommentsMaxByte)
            
            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtCommonField2, CMlngMaxDisp4Row, cmdField2Up, cmdField2Down)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCommonField2_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/03/10 (Mon) 19:03:51 N.Kojima **************************************************

    '@↓2008/03/10 (Mon) 19:04:15 N.Kojima **************************************************
    '関数名：txtCommonField2_KeyUp
    '機　能：故障現象詳細/停止ｺﾒﾝﾄﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：
    Private Sub txtCommonField2_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCommonField2.KeyUp

        Try
                        
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtCommonField2, CMlngMaxDisp4Row, cmdField2Up, cmdField2Down)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCommonField2_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/03/10 (Mon) 19:04:15 N.Kojima **************************************************

    '@↓2008/03/10 (Mon) 19:04:51 N.Kojima **************************************************
    '関数名：txtCommonField2_MouseUp
    '機　能：故障現象詳細/停止ｺﾒﾝﾄﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：
    Private Sub txtCommonField2_MouseUp(ByVal sender As Object, ByVal e As mouseEventArgs) Handles txtCommonField2.MouseUp

        Try
            
            
            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtCommonField2, CMlngMaxDisp4Row, cmdField2Up, cmdField2Down, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCommonField2_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/03/10 (Mon) 19:04:51 N.Kojima **************************************************

    '関数名：cmdField2Up_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(故障現象詳細/ｺﾒﾝﾄﾃｷｽﾄ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 12:46:59 N.Kojima
    '更新日：2007/02/02 (Fri) 12:46:59
    '備　考：
    Private Sub cmdField2Up_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdField2Up.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@以下の条件の場合は処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If
            
            '@=======================
            '@　上ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubtxtCmdUp_Proc(txtCommonField2, CMlngMaxDisp4Row, cmdField2Up, cmdField2Down)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdField2Up_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdField2Down_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(故障現象詳細/ｺﾒﾝﾄﾃｷｽﾄ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 12:58:19 N.Kojima
    '更新日：2007/02/02 (Fri) 12:58:19
    '備　考：
    Private Sub cmdField2Down_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdField2Down.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@以下の条件の場合は処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If
            
            '@=======================
            '@　下ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubtxtCmdDown_Proc(txtCommonField2, CMlngMaxDisp4Row, cmdField2Up, cmdField2Down)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdField2Down_Click"
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
    '作成日：2007/03/14 (Wed) 16:49:23 N.Kojima
    '更新日：2007/03/14 (Wed) 16:49:23
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
            

                       
            '@起動区分が"2:保全記録"で、かつ保全記録票起票済みﾌﾗｸﾞが"True：登録"か
            If plngLoadClass <> CPlngNumTwo Then
            
                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                Me.Close()
            
            Else
                '@起動区分が"2:保全記録"で、保全記録票起票が未登録か
                If pblnPreserveReportRegistFlag = False Then
            
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000O)
                    '@""<TRM0OW>$$保全記録票が登録(起票)されていません$[新規登録]ボタン押下で新規登録画面を起動し、$保全記録票を登録してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@新規登録ﾎﾞﾀﾝが有効か
                    If cmdNewEntry.Enabled = True Then
                    
                        '@新規登録ﾎﾞﾀﾝにﾌｫｰｶｽをｾｯﾄ
                        Call pubSetFocus(cmdNewEntry)
                    End If
                Else
                    '@保全記録票が登録済みの場合は画面を閉じる
                
                    '@∇∇∇∇∇∇∇∇∇
                    '@　ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇
                    Me.Close()
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '@↓2008/02/07 (Thu) 11:35:04 N.Kojima **************************************************
    '関数名：cmdNewEntry_Click
    '機　能：新規作成ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/02/07 (Thu) 11:35:10 N.Kojima
    '更新日：2008/02/07 (Thu) 11:35:10
    '備　考：
    Private Sub cmdNewEntry_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNewEntry.Click

        Dim llngAns     As Integer  '戻り値格納用

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@以下の条件の場合は処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor
                
                
                Exit Sub
            End If
            
            '@選択候補保全記録票が存在しているか
            If mlngPreserveListCnt > 0 Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM1EI>$$紐付け可能な保全記録票が存在しますが、新規登録を行ないますか？"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001E)
                '@確認ﾒｯｾｰｼﾞBOXを表示する
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                If llngAns = vbNo Then
                    '@"いいえ"選択の場合、処理ｷｬﾝｾﾙ
                    Exit Sub
                End If
            End If
            
            '@起動区分の設定(装置状態変更での起動を子画面で判定するのに使用)
            pblnUseChangLoadKbn = True
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　新規登録画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxEN01Z1.Instance = New frmxxEN01Z1()
            
            '@Form_LoadﾌﾗｸﾞがFalse(起動失敗)か
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                frmxxEN01Z1.Instance = Nothing
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　新規登録画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxEN01Z1.Instance.ShowDialog(Me)
            frmxxEN01Z1.Instance = Nothing
            
            '@保全記録票起票済みﾌﾗｸﾞに"True：登録"をｾｯﾄ
            If pblnPreserveReportRegistFlag = True Then
            
                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                Me.Close()
            End If
            
            '@起動区分の初期化(装置状態変更での起動を子画面で判定するのに使用)
            pblnUseChangLoadKbn = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNewEntry_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/02/07 (Thu) 11:35:04 N.Kojima **************************************************

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/14 (Wed) 16:49:47 N.Kojima
    '更新日：2008/02/07 (Thu) 11:23:40 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 11:23:40 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim ltypPreserveInfo        As PreserveInfo     '保全記録情報引継ぎ構造体初期化用
        Dim ltypChgPreserveInfoReq  As PreserveInfo     '保全記録票更新要求構造体初期化用
        Dim lstrEditTime            As String           '更新日時
        Dim lstrRequestFunction     As String           '要求元機能
        Dim llngAns                 As Integer          '戻り値格納用(MsgBox用)
        Dim lblnAns                 As Boolean          '戻り値格納用(通信結果用)
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@以下の条件の場合は処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            With vsfMainteList
                
                '@行が選択されていない場合は格納しない
                If .Row >= 1 Then

                    '@★ 起動区分により処理分岐 ★
                    Select Case plngLoadClass

                        '@〓 "1:故障修理記録" 〓
                        Case CPlngNumOne
                            
                            '@引継ぎ情報をｾｯﾄ
                            ptypRepairConnectInfo.strRepairName = _
                                .GetData(.Row, CMlngvsfRepColRepairNameAll)        '故障現象名(全文)
                            ptypRepairConnectInfo.strRepairContents = _
                                .GetData(.Row, CMlngvsfRepColRepairContentsAll)    '故障現象詳細(全文)
                                
                            '@∇∇∇∇∇∇∇∇∇
                            '@　ｱﾝﾛｰﾄﾞ処理
                            '@∇∇∇∇∇∇∇∇∇
                            Me.Close()


                        '@〓 "2:保全記録" 〓
                        Case CPlngNumTwo
                            
                            '@装置状態変更日時が選択された保全記録票の開始～終了(予定)日時から外れているか
                            If Format$(Cdate(Mid$(ptypPreserveConnectInfo.strEntryTime, 1, 16)), CPstrDateTimeYMDHM) < Format$(CDate(.GetData(.Row, CMlngvsfPreColPreserveStartDate)), CPstrDateTimeYMDHM) Or _
                                Format$(Cdate(Mid$(ptypPreserveConnectInfo.strEntryTime, 1, 16)), CPstrDateTimeYMDHM) > Format$(CDate(.GetData(.Row, CMlngvsfPreColPreserveEndDate)), CPstrDateTimeYMDHM) Then

                                '@表示ﾒｯｾｰｼﾞ変換
                                '@"<TRM1AI>$$計画段階の開始～終了(予定)日時と異なりますが、$保全記録票[%2]を今回の計画保全の記録票として紐付けても$よろしいですか？"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001A, vbNullString, .GetData(.Row, CMlngvsfPreColPreserveNo))
                                '@確認ﾒｯｾｰｼﾞBOXを表示する
                                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                                
                                If llngAns = vbNo Then
                                    '@"いいえ"選択の場合、処理ｷｬﾝｾﾙ
                                    Exit Sub
                                End If
                            Else
                                '@開始～終了(予定)日時内の場合
                            
                                '@表示ﾒｯｾｰｼﾞ変換
                                '@"<TRM11I>$$保全記録票[%1]を今回の計画保全の記録票として紐付けます。$よろしいですか？"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0011, .GetData(.Row, CMlngvsfPreColPreserveNo))
                                '@確認ﾒｯｾｰｼﾞBOXを表示する
                                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                                
                                If llngAns = vbNo Then
                                    '@"いいえ"選択の場合、処理ｷｬﾝｾﾙ
                                    Exit Sub
                                End If
                            End If
                            
                            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                            '@　作業者ｺｰﾄﾞ入力画面　表示処理
                            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                            frmxxCM0010.Instance.ShowDialog(Me)
                            frmxxCM0010.Instance = Nothing
                            
                            '@取消ﾎﾞﾀﾝによる戻りなら処理中止
                            If pblnCancel = True Then
                                Exit Sub
                            End If
                            
                            '@ﾚｽﾎﾟﾝｽ開始
                            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
                            
                            '@****************
                            '@　要求ﾃﾞｰﾀ作成
                            '@****************
                            '@構造体の初期化
                            mtypChgPreserveInfoReq = ltypChgPreserveInfoReq
                        
                            mtypChgPreserveInfoReq.strSbID = pstrSBID                           'ｼｽﾃﾑﾌﾞﾛｯｸID
                            mtypChgPreserveInfoReq.strMsgVer = CMstrpre_chgpreservereportVer    'ﾒｯｾｰｼﾞVer
                            mtypChgPreserveInfoReq.strEmpID = pstrUserID                        '作業者ID(更新者ID)
                            mtypChgPreserveInfoReq.strEmpName = pstrUserName                    '作業者名(更新者名)
                            mtypChgPreserveInfoReq.strActionID = CPstrTwo                       'ｱｸｼｮﾝID(2:更新)
                            mtypChgPreserveInfoReq.strEntryClass = CPstrOne                     '起票区分(1:自動起票)
                            lstrRequestFunction = CPstrThree                                    '要求元機能(3:保全記録票選択)
                            mtypChgPreserveInfoReq.strPreserveStatus = _
                                .GetData(.Row, CMlngvsfPreColPreserveStatus)           '保全記録票状態(取得値を送信)
                            mtypChgPreserveInfoReq.strPreserveNo = _
                                .GetData(.Row, CMlngvsfPreColPreserveNo)               '保全記録票№
                            mtypChgPreserveInfoReq.strWpID = _
                                .GetData(.Row, CMlngvsfPreColWpID)                     '装置ID
                            mtypChgPreserveInfoReq.strWpName = _
                                .GetData(.Row, CMlngvsfPreColWpName)                   '装置名
                            mtypChgPreserveInfoReq.strUseId = _
                                .GetData(.Row, CMlngvsfPreColCategoryID)               'ｶﾃｺﾞﾘID(MCUSE0005:計画保全)
                            mtypChgPreserveInfoReq.strEditTime = _
                                .GetData(.Row, CMlngvsfPreColEditTime)                 '更新日時
                            mtypChgPreserveInfoReq.strPreserveStartDate = _
                                Format$(Cdate(Mid$(ptypPreserveConnectInfo.strEntryTime, 1, 16)), CPstrDateTimeYMDHM)  '登録日時(装置状態変更日時)

                            
                            
                            Me.KeyPreview = False
                            
                            '@【保全記録票情報更新】ﾒｯｾｰｼﾞ送受信処理
                            lblnAns = pubblnPreChgPreserveReport_Upd(mtypChgPreserveInfoReq, _
                                                                     lstrEditTime, _
                                                                     vbNullString, _
                                                                     lstrRequestFunction)
                            
                            
                            Me.KeyPreview = True
                            
                            '@通信結果判定
                            If lblnAns = False Then
                                '@結果：異常の場合
                                
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                                Exit Sub
                            End If
                            
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                            
                            '@ﾒｯｾｰｼﾞを表示する
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Q, CMstrPreserveReport, CMstrUpdateMsg, _
                                                            .GetData(.Row, CMlngvsfPreColPreserveNo))
                            '@ｽﾃｰﾀｽﾊﾞｰ表示
                            Call pubVsfInfo_Disp(pstrDMsg)
                    
                    
                            '@****************
                            '@　引継ぎ情報をｾｯﾄ
                            '@****************
                            ptypPreserveInfo.strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸID
                            ptypPreserveInfo.strPreserveNo = _
                                .GetData(.Row, CMlngvsfPreColPreserveNo)           '保全記録票№
                            ptypPreserveInfo.strWpID = _
                                .GetData(.Row, CMlngvsfPreColWpID)                 '装置ID
                            ptypPreserveInfo.strWpName = _
                                .GetData(.Row, CMlngvsfPreColWpName)               '装置名
                            ptypPreserveInfo.strCategoryID = _
                                .GetData(.Row, CMlngvsfPreColCategoryID)           'ｶﾃｺﾞﾘID
                            ptypPreserveInfo.strCategoryName = _
                                .GetData(.Row, CMlngvsfPreColCategoryName)         'ｶﾃｺﾞﾘ名
                            ptypPreserveInfo.strPreserveCategory = _
                                .GetData(.Row, CMlngvsfPreColPreserveCategoryID)   '保全ｶﾃｺﾞﾘID
                            ptypPreserveInfo.strEntryTime = _
                                .GetData(.Row, CMlngvsfPreColEntryTime)            '登録日時
                            ptypPreserveInfo.strEditTime = _
                                .GetData(.Row, CMlngvsfPreColEditTime)             '更新日時
                            
                            ptypPreserveInfo.strEntryClass = CPstrOne                       '起票区分(1:自動起票)

                            ptypPreserveInfo.strEmpID = pstrUserID                          '作業者ID(起案者、更新者、発見者)
                            ptypPreserveInfo.strEmpName = pstrUserName                      '作業者名(起案者、更新者、発見者)

                            '@起動区分の設定(装置状態変更での起動を子画面で判定するのに使用)
                            pblnUseChangLoadKbn = True

                            '@保全記録票起票済みﾌﾗｸﾞに"True：登録"をｾｯﾄ
                            pblnPreserveReportRegistFlag = True
                            
                            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                            '@　装置ﾒﾝﾃﾅﾝｽ記録票画面　起動処理
                            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                            frmxxCM00Z0.Instance = New frmxxCM00Z0()
                            
                            '@Form_LoadﾌﾗｸﾞがFalse(起動失敗)か
                            If pblnFormLoad = False Then
                            
                                '@∇∇∇∇∇∇∇∇∇
                                '@　ｱﾝﾛｰﾄﾞ処理
                                '@∇∇∇∇∇∇∇∇∇
                                frmxxCM00Z0.Instance = Nothing
                                
                                Exit Sub
                            End If
                            
                            '@∇∇∇∇∇∇∇∇∇
                            '@　ｱﾝﾛｰﾄﾞ処理
                            '@∇∇∇∇∇∇∇∇∇
                            Me.Close()
                            
                            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                            '@　装置ﾒﾝﾃﾅﾝｽ記録票画面　表示処理
                            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                            frmxxCM00Z0.Instance.ShowDialog(Me)
                            frmxxCM00Z0.Instance = Nothing
                            
                            '@引継ぎ構造体を初期化する
                            ptypPreserveInfo = ltypPreserveInfo

                    End Select
                    
                End If
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
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

    '関数名：prvFrmxxCM00Z1_Init
    '機　能：ﾒｲﾝﾌｫｰﾑの初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/14 (Wed) 16:30:38 N.Kojima
    '更新日：2008/02/07 (Thu) 11:23:40 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 11:23:40 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub prvFrmxxCM00Z1_Init()
        
        Dim lstrNowDate             As String               '現在日時格納用
        Dim ltypRepairInfoReq       As RepairInfoReq        '故障修理記録一覧取得要求構造体初期化用
        Dim ltypPreserveInfoReq     As PreserveInfoReq      '保全記録一覧取得要求構造体初期化用
        
        Try
            
            '@ｶﾚﾝﾀﾞｰｺﾝﾎﾞ設定
            lstrNowDate = Format$(Now, CPstrDateTimeYMD)
            Call pubblnCalendar_Init(calStart, CPlngCalModeTool, lstrNowDate)   '検索開始日
            Call pubblnCalendar_Init(calEnd, CPlngCalModeTool, lstrNowDate)     '検索終了日
            
            '@ﾗﾍﾞﾙの初期化
            lblWpName.Text = vbNullString                        '装置名
            lblDataCnt.Text = vbNullString                       '該当件数
            lblNowDate.Text = vbNullString                       '情報取得日時
            
            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            '@故障現象名/実施項目ﾃｷｽﾄ
            txtCommonField1.Text = vbNullString
            txtCommonField1.Locked = True
            txtCommonField1.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor) 'ﾊﾞｯｸｶﾗｰ
            txtCommonField1.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ
            txtCommonField1.TabStop = False                         'Tabでﾌｫｰｶｽを取得しない
            '@故障現象詳細/ｺﾒﾝﾄﾃｷｽﾄ
            txtCommonField2.Text = vbNullString
            txtCommonField2.Locked = True
            txtCommonField2.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)'ﾊﾞｯｸｶﾗｰ
            txtCommonField2.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor) 'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ
            txtCommonField2.TabStop = False                         'Tabでﾌｫｰｶｽを取得しない
            
            '@上下ｽｸﾛｰﾙﾎﾞﾀﾝの制御
            cmdField1Up.Enabled = False                             '故障現象名/実施項目ﾃｷｽﾄ用上ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdField1Down.Enabled = False                           '故障現象名/実施項目ﾃｷｽﾄ用下ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdField2Up.Enabled = False                             '故障現象詳細/ｺﾒﾝﾄﾃｷｽﾄ用上ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdField2Down.Enabled = False                           '故障現象詳細/ｺﾒﾝﾄﾃｷｽﾄ用下ｽｸﾛｰﾙﾎﾞﾀﾝ
            
            '@各種ﾎﾞﾀﾝの初期化
            cmdRegist.Enabled = False                               '確定ﾎﾞﾀﾝ
            cmdSearch.Enabled = False                               '検索ﾎﾞﾀﾝ

            'NSYS コメント欄の初期化
            For llngCnt = 0 To 1
                If llngCnt  = 0 Then
                    lblLengthCountArray(llngCnt).Text = pubstrMsgReplace_Set(CPstrCommentLength, 0, CMlngMaxRepairNameByte)
                Else
                    lblLengthCountArray(llngCnt).Text = pubstrMsgReplace_Set(CPstrCommentLength, 0, CPlngLotCommentsMaxByte)
                End If
            Next
            
            '@通信情報格納用ﾓｼﾞｭｰﾙ変数/構造体の初期化
            mtypRepairInfoReq = ltypRepairInfoReq                   '故障修理記録一覧取得要求構造体
             If mtypRepairInfoAns Is Nothing                        '故障修理記録一覧取得応答構造体
                mtypRepairInfoAns = New List(Of RepairInfoAns) 
             Else 
                mtypRepairInfoAns.Clear()
             End If                                                       
            mlngRepairListCnt = 0                                   '故障修理記録一覧ﾘｽﾄ数格納用
            mtypPreserveInfoReq = ltypPreserveInfoReq               '保全記録一覧取得要求構造体
            If mtypPreserveInfoAns Is Nothing                       '保全記録一覧取得応答構造体
              mtypPreserveInfoAns = New List(Of PreserveInfoAns) 
            Else 
              mtypPreserveInfoAns.Clear()
            End If
            mlngPreserveListCnt = 0                                 '保全記録一覧ﾘｽﾄ数格納用
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxCM00Z1_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvvsfMainteList_Init
    '機　能：故障修理記録票/保全記録票一覧ｸﾞﾘｯﾄﾞ　初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/14 (Wed) 16:36:16 N.Kojima
    '更新日：2008/02/07 (Thu) 10:18:41 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 10:18:41 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub prvVsfMainteList_Init()

        Dim headerStyle As CellStyle　　'NSYS ヘッダー用追加Style
        Dim llngCnt     As Integer  　　'汎用ｶｳﾝﾀ
        
        Try
            
            With vsfMainteList

                '.Clear(ClearFlags.Content)                          'ｸﾘｱ
                .AllowSorting = AllowSortingEnum.SingleColumn       'ｿｰﾄあり(ｿｰﾄ方向表示あり)
                .Rows.Count = .Rows.Fixed                           '初期行数設定
                .Row = 0                                            'NSYS初期化時の選択行
                RowTmp = .Row                                       'カレント行退避
                '.FillStyle = flexFillRepeat                        '選択された行の全てのｾﾙ
                '.AllowBigSelection = False                         'ﾍｯﾀﾞｸﾘｯｸで全選択不可
                .SelectionMode  = SelectionModeEnum.Row             'ﾏｳｽでｾﾙ範囲選択不可
                .Font = New Font(.Font.Name, _ 
                   CMlngvsfMainteListTitleFontSize,.Font.Style)     'ﾌｫﾝﾄｻｲｽﾞ指定(=11)   
                .Styles.Normal.Trimming = StringTrimming.Character  '表示しきれない場合の対応("..."を表示する)
                .ScrollBars = ScrollBars.Both                       'ｽｸﾛｰﾙ設定(行/列両方向)
                .Rows.DefaultSize = CMlngvsfMainteListRowHeight      '行の高さ指定
                .Rows(0).Height  = CMlngvsfMainteListTitleRowHeight 'ﾀｲﾄﾙ行の高さ指定
                
                '@★ 起動区分により処理分岐 ※列幅、ﾀｲﾄﾙの設定 ★
                Select Case plngLoadClass

                    '@〓 "1:故障修理記録 〓
                    Case CPlngNumOne
                        
                        .Cols.Count = CMlngvsfRepairCols          '故障修理記録用列数
                        
                        For llngCnt = 0 To .Cols.Count - 1
                            '@非表示設定を一旦ｸﾘｱ
                            .Cols(llngCnt).Visible = True
                        Next llngCnt
                        
                        '@列幅
                        .Cols(CMlngvsfRepColNo).Width = CMlngvsfRepColWNo                                 '№
                        .Cols(CMlngvsfRepColRepairNo).Width = CMlngvsfRepColWRepairNo                     '発行№
                        .Cols(CMlngvsfRepColRepairName).Width = CMlngvsfRepColWRepairName                 '故障現象名
                        .Cols(CMlngvsfRepColRepairNameAll).Width = CMlngvsfRepColWRepairNameAll           '故障現象名(全文)
                        .Cols(CMlngvsfRepColRepairContents).Width = CMlngvsfRepColWRepairContents         '故障現象詳細
                        .Cols(CMlngvsfRepColRepairContentsAll).Width = CMlngvsfRepColWRepairContentsAll   '故障現象詳細(全文)
                
                        '@ﾀｲﾄﾙ
                        .SetData(0, CMlngvsfRepColNo, CMstrvsfRepColTNo)                                 '№
                        .SetData(0, CMlngvsfRepColRepairNo, CMstrvsfRepColTRepairNo)                     '発行№
                        .SetData(0, CMlngvsfRepColRepairName, CMstrvsfRepColTRepairName)                 '故障現象名
                        .SetData(0, CMlngvsfRepColRepairNameAll, CMstrvsfRepColTRepairNameAll)           '故障現象名(全文)
                        .SetData(0, CMlngvsfRepColRepairContents, CMstrvsfRepColTRepairContents)         '故障現象詳細
                        .SetData(0, CMlngvsfRepColRepairContentsAll, CMstrvsfRepColTRepairContentsAll)   '故障現象詳細(全文)
                
                        '@非表示
                        .Cols(CMlngvsfRepColRepairNameAll).Visible  = false      '故障現象名(全文)
                        .Cols(CMlngvsfRepColRepairContentsAll).Visible  = False  '故障現象詳細(全文)
                

                    '@〓 "2:保全記録" 〓
                    Case CPlngNumTwo
                        
                        .Cols.Count = CMlngvsfPreserveCols        '保全記録用列数
                        
                        For llngCnt = 0 To .Cols.Count - 1
                            '@非表示設定を一旦ｸﾘｱ
                            .Cols(llngCnt).Visible  = True
                        Next llngCnt
                        
                        '@列幅
                        .Cols(CMlngvsfPreColNo).Width = CMlngvsfPreColWNo                                     '№
                        .Cols(CMlngvsfPreColPreserveNo).Width = CMlngvsfPreColWPreserveNo                     '発行№
                        .Cols(CMlngvsfPreColCategoryID).Width = CMlngvsfPreColWCategoryID                     'ｶﾃｺﾞﾘID
                        .Cols(CMlngvsfPreColCategoryName).Width = CMlngvsfPreColWCategoryName                 'ｶﾃｺﾞﾘ名
                        .Cols(CMlngvsfPreColPreserveCategoryID).Width = CMlngvsfPreColWPreserveCategoryID     '保全ｶﾃｺﾞﾘID
                        .Cols(CMlngvsfPreColPreserveCategoryName).Width = CMlngvsfPreColWPreserveCategoryName '保全ｶﾃｺﾞﾘ名
                        .Cols(CMlngvsfPreColPreserveStartDate).Width = CMlngvsfPreColWPreserveStartDate       '開始(予定)日時
                        .Cols(CMlngvsfPreColPreserveEndDate).Width = CMlngvsfPreColWPreserveEndDate           '終了(予定)日時
                        .Cols(CMlngvsfPreColPreserveItem).Width = CMlngvsfPreColWPreserveItem                 '実施項目
                        .Cols(CMlngvsfPreColPreserveItemAll).Width = CMlngvsfPreColWPreserveItemAll           '実施項目(全文)
                        .Cols(CMlngvsfPreColComment).Width = CMlngvsfPreColWComment                           'ｺﾒﾝﾄ(全文)
                        .Cols(CMlngvsfPreColWpID).Width = CMlngvsfPreColWWpID                                 '装置ID
                        .Cols(CMlngvsfPreColWpName).Width = CMlngvsfPreColWWpName                             '装置名
                        .Cols(CMlngvsfPreColEntryTime).Width = CMlngvsfPreColWEntryTime                       '登録日時
                        .Cols(CMlngvsfPreColEditTime).Width = CMlngvsfPreColWEditTime                         '更新日時
                        .Cols(CMlngvsfPreColPreserveStatus).Width = CMlngvsfPreColWPreserveStatus             '保全記録票状態
                
                        '@ﾀｲﾄﾙ
                        .SetData(0, CMlngvsfPreColNo, CMstrvsfPreColTNo)                          '№
                        .SetData(0, CMlngvsfPreColPreserveNo, CMstrvsfPreColTPreserveNo)          '発行№
                        .SetData(0, CMlngvsfPreColCategoryID, CMstrvsfPreColTCategoryID)          'ｶﾃｺﾞﾘID
                        .SetData(0, CMlngvsfPreColCategoryName, CMstrvsfPreColTCategoryName)      'ｶﾃｺﾞﾘ名
                        .SetData(0, CMlngvsfPreColPreserveCategoryID, CMstrvsfPreColTPreserveCategoryID)      '保全ｶﾃｺﾞﾘID
                        .SetData(0, CMlngvsfPreColPreserveCategoryName, CMstrvsfPreColTPreserveCategoryName)  '保全ｶﾃｺﾞﾘ名
                        .SetData(0, CMlngvsfPreColPreserveStartDate, CMstrvsfPreColTPreserveStartDate)        '開始(予定)日時
                        .SetData(0, CMlngvsfPreColPreserveEndDate, CMstrvsfPreColTPreserveEndDate)            '終了(予定)日時
                        .SetData(0, CMlngvsfPreColPreserveItem, CMstrvsfPreColTPreserveItem)                  '実施項目
                        .SetData(0, CMlngvsfPreColPreserveItemAll, CMstrvsfPreColTPreserveItemAll)            '実施項目(全文)
                        .SetData(0, CMlngvsfPreColComment, CMstrvsfPreColTComment)                'ｺﾒﾝﾄ(全文)
                        .SetData(0, CMlngvsfPreColWpID, CMstrvsfPreColTWpID)                      '装置ID
                        .SetData(0, CMlngvsfPreColWpName, CMstrvsfPreColTWpName)                  '装置名
                        .SetData(0, CMlngvsfPreColEntryTime, CMstrvsfPreColTEntryTime)            '登録日時
                        .SetData(0, CMlngvsfPreColEditTime, CMstrvsfPreColTEditTime)              '更新日時
                        .SetData(0, CMlngvsfPreColPreserveStatus, CMstrvsfPreColTPreserveStatus)  '保全記録票状態
                
                        '@非表示
                        .Cols(CMlngvsfPreColPreserveItemAll).Visible = False        '実施項目(全文)
                        .Cols(CMlngvsfPreColComment).Visible = False                'ｺﾒﾝﾄ(全文)
                        .Cols(CMlngvsfPreColWpID).Visible = False                   '装置ID
                        .Cols(CMlngvsfPreColWpName).Visible = False                 '装置名
                        .Cols(CMlngvsfPreColCategoryID).Visible = False             'ｶﾃｺﾞﾘID
                        .Cols(CMlngvsfPreColCategoryName).Visible = False           'ｶﾃｺﾞﾘ名
                        .Cols(CMlngvsfPreColPreserveCategoryID).Visible = False     '保全ｶﾃｺﾞﾘID
                        .Cols(CMlngvsfPreColEntryTime).Visible = False              '登録日時
                        .Cols(CMlngvsfPreColEditTime).Visible = False               '更新日時
                        .Cols(CMlngvsfPreColPreserveStatus).Visible = False         '保全記録票状態
                        
                End Select
                
                '@ﾀｲﾄﾙ行設定
                headerStyle = .Styles.Fixed 
                headerStyle.ForeColor = Color.Yellow                                                     '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                        '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, _
                     CMlngvsfMainteListTitleFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign  =  TextAlignEnum.CenterCenter                                     '中央中央寄せ
                
                '@ｸﾞﾘｯﾄﾞを無効にする
                .Enabled = False
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMainteList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvvsfRepairList_Disp
    '機　能：故障修理記録票一覧ｸﾞﾘｯﾄﾞ　作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 09:54:07 N.Kojima
    '更新日：2008/02/07 (Thu) 10:18:41 N.Kojima
    '備　考：
    '　　　：2008/02/07 (Thu) 10:18:41 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub prvVsfRepairList_Disp()

        Dim llngDoCnt               As Integer      '描画用ｶｳﾝﾄ
        Dim llngCnt                 As Integer      '担当者用ｶｳﾝﾄ
        Dim lstrChgSpace            As String       '変換後文字列格納用(改行ｷｰ→空白変換)
        Dim lstrStringByte30        As String       '30ﾊﾞｲﾄ表示用
        Dim llngStringCnt           As Integer      '文字ｶｳﾝﾀ

        Try
            
            With vsfMainteList
                
                If mlngRepairListCnt > 0 Then
                    '@格納ﾃﾞｰﾀがあるの場合
                    
                    '.Clear(ClearFlags.Content)           'ｸﾘｱ(固定行、列以外の領域)
                    .Redraw = false                       '直接描画しない 
                    RemoveHandler vsfMainteList.BeforeRowColChange, AddressOf vsfMainteList_BeforeRowColChange 
                    .Rows.Count = mlngRepairListCnt + 1   '行数設定

                    If form_Load1st = True
                       .Row = 0                           'NSYS 初期フォーカス位置対策
                        form_Load1st = False 
                    Else 
                        .Row = RowTmp
                    End If
                    AddHandler vsfMainteList.BeforeRowColChange, AddressOf vsfMainteList_BeforeRowColChange 
                    
                    '@故障修理記録情報を表示
                    For llngDoCnt = 0 To mlngRepairListCnt -1
                        
                        '@№設定
                        .SetData(llngDoCnt+1, CMlngvsfRepColNo, llngDoCnt+1)
                        '@発行№
                        .SetData(llngDoCnt+1, CMlngvsfRepColRepairNo, mtypRepairInfoAns(llngDoCnt).strRepairNo)
                        
                        '@故障現象名の改行ｷｰ変換(→Spaceへ変換)
                        lstrChgSpace = Replace$(mtypRepairInfoAns(llngDoCnt).strRepairName, vbCrLf, Space$(1))
                        lstrStringByte30 = vbNullString
                        For llngStringCnt = 1 To Len(lstrChgSpace)
                            '@30ﾊﾞｲﾄﾁｪｯｸ
                            If LenB(lstrStringByte30 & Mid$(lstrChgSpace, llngStringCnt, 1)) > CMlngDisplayByte30 Then
                                Exit For
                            Else
                                lstrStringByte30 = lstrStringByte30 & Mid$(lstrChgSpace, llngStringCnt, 1)
                            End If
                        Next llngStringCnt
                        '@故障現象名
                        .SetData(llngDoCnt+1, CMlngvsfRepColRepairName, lstrStringByte30)
                        '@故障現象名(全文)
                        .SetData(llngDoCnt+1, CMlngvsfRepColRepairNameAll, mtypRepairInfoAns(llngDoCnt).strRepairName)
                        
                        '@変数の初期化
                        lstrChgSpace = vbNullString
                        
                        '@故障現象詳細の改行ｷｰ変換(→Spaceへ変換)
                        lstrChgSpace = Replace$(mtypRepairInfoAns(llngDoCnt).strRepairContents, vbCrLf, Space$(1))
                        lstrStringByte30 = vbNullString
                        For llngStringCnt = 1 To Len(lstrChgSpace)
                            '@30ﾊﾞｲﾄﾁｪｯｸ
                            If LenB(lstrStringByte30 & Mid$(lstrChgSpace, llngStringCnt, 1)) > CMlngDisplayByte30 Then
                                Exit For
                            Else
                                lstrStringByte30 = lstrStringByte30 & Mid$(lstrChgSpace, llngStringCnt, 1)
                            End If
                        Next llngStringCnt
                        '@故障現象詳細
                        .SetData(llngDoCnt+1, CMlngvsfRepColRepairContents, lstrStringByte30)
                        '@故障現象詳細(全文)
                        .SetData(llngDoCnt+1, CMlngvsfRepColRepairContentsAll, mtypRepairInfoAns(llngDoCnt).strRepairContents)
                    
                    Next llngDoCnt
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCols(CMlngvsfRepColNo, CMlngvsfRepColRepairNo, 6)
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfRepColNo).TextAlign = TextAlignEnum.RightCenter                 '№
                    .Cols(CMlngvsfRepColRepairNo).TextAlign = TextAlignEnum.LeftCenter            '故障修理記録№
                    .Cols(CMlngvsfRepColRepairName).TextAlign = TextAlignEnum.LeftCenter          '故障現象名
                    .Cols(CMlngvsfRepColRepairNameAll).TextAlign = TextAlignEnum.LeftCenter       '故障現象名(全文)
                    .Cols(CMlngvsfRepColRepairContents).TextAlign = TextAlignEnum.LeftCenter      '故障現象詳細
                    .Cols(CMlngvsfRepColRepairContentsAll).TextAlign = TextAlignEnum.LeftCenter   '故障現象詳細(全文)
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt -1
                            RemoveHandler vsfMainteList.BeforeRowColChange, AddressOf vsfMainteList_BeforeRowColChange 
                            '@該当行をｿｰﾄ
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)           
                            .Row = RowTmp
                            AddHandler vsfMainteList.BeforeRowColChange, AddressOf vsfMainteList_BeforeRowColChange
                        Next llngCnt
                    End If
                    
                    '@ｿｰﾄ検索用ｷｰがある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            
                            '@発行№と故障現象名(全文)が同じ場合
                            If .GetData(llngCnt, CMlngvsfRepColRepairNo) & _
                                .GetData(llngCnt, CMlngvsfRepColRepairNameAll) = _
                                mtypChgSort.strKey Then
                                
                                .Row = llngCnt
                                
                                '@=======================
                                '@　ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                '@=======================
                                Call pubVsfBeforeSort(vsfMainteList, CMlngvsfRepColRepairNo & vbTab & CMlngvsfRepColRepairNameAll)
                                
                                '@=======================
                                '@　ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                '@=======================
                                Call pubVsfAfterSort(vsfMainteList, CMlngvsfRepColRepairNo & vbTab & CMlngvsfRepColRepairNameAll)
                                
                                Exit For
                            End If
                        Next llngCnt
                    End If
                    
                    '@行列のﾏｳｽでの変更を不可設定にする
                    .AllowDragging =  AllowDraggingEnum.None 
                                
                    '@描画ﾛｯｸ解除
                    .Redraw = True
                                
                    '@ﾛｯｸ解除
                    .Enabled = True
                Else
                    '@=======================
                    '@　故障修理記録票/保全記録票一覧ｸﾞﾘｯﾄﾞ　初期化処理
                    '@=======================
                    Call prvVsfMainteList_Init()
                End If
            End With
            
            '@各種表示
            lblDataCnt.Text = Format$(mlngRepairListCnt, CPstrDateFormatKanma)   '該当件数
            lblNowDate.Text = Format(Now, CPstrDateFormat)                       '現在日時表示

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfRepairList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/02/07 (Thu) 10:20:27 N.Kojima **************************************************
    '関数名：prvvsfPreserveList_Disp
    '機　能：保全記録票一覧ｸﾞﾘｯﾄﾞ　作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/02/07 (Thu) 10:18:41 N.Kojima
    '更新日：2008/02/07 (Thu) 10:18:41
    '備　考：
    Private Sub prvVsfPreserveList_Disp()

        Dim llngDoCnt               As Integer      '描画用ｶｳﾝﾄ
        Dim llngCnt                 As Integer      '担当者用ｶｳﾝﾄ
        Dim lstrChgSpace            As String       '変換後文字列格納用(改行ｷｰ→空白変換)
        Dim lstrStringByte30        As String       '30ﾊﾞｲﾄ表示用
        Dim llngStringCnt           As Integer      '文字ｶｳﾝﾀ

        Try
            
            With vsfMainteList
                
                If mlngPreserveListCnt > 0 Then
                    '@格納ﾃﾞｰﾀがあるの場合
                    
                    .Clear(ClearFlags.Content)          'ｸﾘｱ(固定行、列以外の領域)
                    .Redraw = false                '直接描画しない
                     'RowTmp = vsfMainteList.Row            'NSYS カレント行を退避
                    .Rows.Count = mlngPreserveListCnt + 1     '行数設定

                    If form_Load1st = True
                       .Row = 0                           'NSYS 初期フォーカス位置対策
                        form_Load1st = False 
                    Else 
                        .Row = RowTmp
                    End If
                    
                    '@保全記録情報を表示
                    For llngDoCnt = 0 To mlngPreserveListCnt-1

                        .SetData(llngDoCnt+1, CMlngvsfPreColNo, llngDoCnt)      '№
                        .SetData(llngDoCnt+1, CMlngvsfPreColPreserveNo, _
                            mtypPreserveInfoAns(llngDoCnt).strPreserveNo)                '発行№
                        .SetData(llngDoCnt+1, CMlngvsfPreColCategoryID, _
                            mtypPreserveInfoAns(llngDoCnt).strCategoryID)                'ｶﾃｺﾞﾘID
                        .SetData(llngDoCnt+1, CMlngvsfPreColCategoryName, _
                            mtypPreserveInfoAns(llngDoCnt).strCategoryName)              'ｶﾃｺﾞﾘ名
                        .SetData(llngDoCnt+1, CMlngvsfPreColPreserveCategoryID, _
                            mtypPreserveInfoAns(llngDoCnt).strPreserveCategory)          '保全ｶﾃｺﾞﾘID
                        
                        '@★ 保全ｶﾃｺﾞﾘIDにより処理分岐 ★
                        Select Case .GetData(llngDoCnt, CMlngvsfPreColPreserveCategoryID)
                        
                            '@〓 "1:予防保全" 〓
                            Case CPstrOne
                            
                                .SetData(llngDoCnt+1, CMlngvsfPreColPreserveCategoryName, _
                                    CMstrPreserveCategoryName1)      '予防保全
                                    
                                    
                            '@〓 "2:改良/改善保全" 〓
                            Case CPstrTwo
                            
                                .SetData(llngDoCnt+1, CMlngvsfPreColPreserveCategoryName, _
                                    CMstrPreserveCategoryName2)      '改良/改善保全
                                    
                                    
                            '@〓 "3:ﾙｰﾁﾝﾒﾝﾃ" 〓
                            Case CPstrThree
                            
                                .SetData(llngDoCnt+1, CMlngvsfPreColPreserveCategoryName, _
                                    CMstrPreserveCategoryName3)      'ﾙｰﾁﾝﾒﾝﾃ
                        
                        End Select
                        
                        If IsDate(mtypPreserveInfoAns(llngDoCnt).strPreserveStartDate)
                            .SetData(llngDoCnt, CMlngvsfPreColPreserveStartDate, _
                                Format$(Cdate(mtypPreserveInfoAns(llngDoCnt).strPreserveStartDate), CPstrDateTimeY2MDHM))   '開始(予定)日時
                        End if

                        If IsDate(mtypPreserveInfoAns(llngDoCnt).strPreserveEndDate)
                            .SetData(llngDoCnt, CMlngvsfPreColPreserveEndDate, _
                                Format$(Cdate(mtypPreserveInfoAns(llngDoCnt).strPreserveEndDate), CPstrDateTimeY2MDHM))     '終了(予定)日時
                        End if 
                        
                        '@実施項目の改行ｷｰ変換(→Spaceへ変換)
                        lstrChgSpace = Replace$(mtypPreserveInfoAns(llngDoCnt).strPreserveItem, vbCrLf, Space$(1))
                        lstrStringByte30 = vbNullString
                        For llngStringCnt = 1 To Len(lstrChgSpace)
                            '@30ﾊﾞｲﾄﾁｪｯｸ
                            If LenB(lstrStringByte30 & Mid$(lstrChgSpace, llngStringCnt, 1)) > CMlngDisplayByte30 Then
                                Exit For
                            Else
                                lstrStringByte30 = lstrStringByte30 & Mid$(lstrChgSpace, llngStringCnt, 1)
                            End If
                        Next llngStringCnt
                        .SetData(llngDoCnt+1, CMlngvsfPreColPreserveItem, lstrStringByte30)                '実施項目
                        .SetData(llngDoCnt+1, CMlngvsfPreColPreserveItemAll, _
                            mtypPreserveInfoAns(llngDoCnt).strPreserveItem)                              '実施項目(全文)
                        
                        .SetData(llngDoCnt+1, CMlngvsfPreColComment, _
                            mtypPreserveInfoAns(llngDoCnt).strPreserveComments)                          'ｺﾒﾝﾄ(全文)
                        .SetData(llngDoCnt+1, CMlngvsfPreColWpID, _
                            mtypPreserveInfoAns(llngDoCnt).strWpID)                                      '装置ID
                        .SetData(llngDoCnt+1, CMlngvsfPreColWpName, _
                            mtypPreserveInfoAns(llngDoCnt).strWpName)                                    '装置名
                        .SetData(llngDoCnt+1, CMlngvsfPreColEntryTime, _
                            mtypPreserveInfoAns(llngDoCnt).strEntryTime)                                 '登録日時
                        .SetData(llngDoCnt+1, CMlngvsfPreColEditTime, _
                            mtypPreserveInfoAns(llngDoCnt).strEditTime)                                  '更新日時
                        .SetData(llngDoCnt+1, CMlngvsfPreColPreserveStatus, _
                            mtypPreserveInfoAns(llngDoCnt).strPreserveStatus)                            '保全記録票状態
                    
                    Next llngDoCnt
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCol(CMlngvsfPreColPreserveCategoryName,6) '保全ｶﾃｺﾞﾘ
                        .AutoSizeCol(CMlngvsfPreColPreserveStartDate,6)    '開始(予定)日時
                        .AutoSizeCol(CMlngvsfPreColPreserveEndDate, 6)     '終了(予定)日時
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfPreColNo).TextAlign = TextAlignEnum.RightCenter                  '№
                    .Cols(CMlngvsfPreColPreserveNo).TextAlign = TextAlignEnum.LeftCenter           '発行№
                    .Cols(CMlngvsfPreColCategoryID).TextAlign = TextAlignEnum.LeftCenter           'ｶﾃｺﾞﾘID
                    .Cols(CMlngvsfPreColCategoryName).TextAlign = TextAlignEnum.LeftCenter         'ｶﾃｺﾞﾘ名
                    .Cols(CMlngvsfPreColPreserveCategoryID).TextAlign = TextAlignEnum.LeftCenter   '保全ｶﾃｺﾞﾘID
                    .Cols(CMlngvsfPreColPreserveCategoryName).TextAlign = TextAlignEnum.LeftCenter '保全ｶﾃｺﾞﾘ名
                    .Cols(CMlngvsfPreColPreserveStartDate).TextAlign = TextAlignEnum.LeftCenter    '開始(予定)日時
                    .Cols(CMlngvsfPreColPreserveEndDate).TextAlign = TextAlignEnum.LeftCenter      '終了(予定)日時
                    .Cols(CMlngvsfPreColPreserveItem).TextAlign = TextAlignEnum.LeftCenter         '実施項目
                    .Cols(CMlngvsfPreColPreserveItemAll).TextAlign = TextAlignEnum.LeftCenter      '実施項目(全文)
                    .Cols(CMlngvsfPreColComment).TextAlign = TextAlignEnum.LeftCenter              'ｺﾒﾝﾄ(全文)
                    .Cols(CMlngvsfPreColWpID).TextAlign = TextAlignEnum.LeftCenter                 '装置ID
                    .Cols(CMlngvsfPreColWpName).TextAlign = TextAlignEnum.LeftCenter               '装置名
                    .Cols(CMlngvsfPreColEntryTime).TextAlign = TextAlignEnum.LeftCenter            '登録日時
                    .Cols(CMlngvsfPreColEditTime).TextAlign = TextAlignEnum.LeftCenter             '更新日時
                    .Cols(CMlngvsfPreColPreserveStatus).TextAlign = TextAlignEnum.LeftCenter       '保全記録票状態
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    '@ｿｰﾄ検索用ｷｰがある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            
                            '@発行№と実施項目(全文)が同じ場合
                            If .GetData(llngCnt, CMlngvsfPreColPreserveNo) & _
                                .GetData(llngCnt, CMlngvsfPreColPreserveItemAll) = _
                                mtypChgSort.strKey Then
                                
                                .Row = llngCnt
                                
                                '@=======================
                                '@　ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                '@=======================
                                Call pubVsfBeforeSort(vsfMainteList, CMlngvsfPreColPreserveNo & vbTab & CMlngvsfPreColPreserveItemAll)
                                
                                '@=======================
                                '@　ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                '@=======================
                                Call pubVsfAfterSort(vsfMainteList, CMlngvsfPreColPreserveNo & vbTab & CMlngvsfPreColPreserveItemAll)
                                
                                Exit For
                            End If
                        Next llngCnt
                    End If
                    
                    '@行列のﾏｳｽでの変更を不可設定にする
                    .AllowDragging =  AllowDraggingEnum.None 
                                
                    '@描画ﾛｯｸ解除
                    .Redraw = True
                                
                    '@ﾛｯｸ解除
                    .Enabled = True
                Else
                    '@=======================
                    '@　故障修理記録票/保全記録票一覧ｸﾞﾘｯﾄﾞ　初期化処理
                    '@=======================
                    Call prvVsfMainteList_Init()
                End If
            End With
            
            '@各種表示
            lblDataCnt.Text = Format$(mlngPreserveListCnt, CPstrDateFormatKanma)   '該当件数
            lblNowDate.Text = Format(Now, CPstrDateFormat)                       '現在日時表示

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfPreserveList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/02/07 (Thu) 10:20:27 N.Kojima **************************************************

    '@↓2008/02/07 (Thu) 10:53:56 N.Kojima **************************************************
    '関数名：prvRepairListSearch_Proc
    '機　能：故障修理記録票一覧　検索処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/02/07 (Thu) 10:55:16 N.Kojima
    '更新日：2008/02/07 (Thu) 10:55:16
    '備　考：
    Private Sub prvRepairListSearch_Proc()
        
        Dim lblnAns      As Boolean          '故障修理記録票ﾘｽﾄ取得結果
        
        Try
            
            '@ﾚｽﾎﾟﾝｽ開始
            Call pubResponseStart(CMstrFormName, CMstrPrvRepairListSearchProc)
            
            '@****************
            '@　要求ﾃﾞｰﾀ作成
            '@****************
            With mtypRepairInfoReq
                
                .strSbID = pstrSBID                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrrep_repairlistVer                 'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strStartDate = calStart.Value & CMstrStartTime     '検索開始日(+時間)
                .strEndDate = calEnd.Value & CMstrEndTime           '検索終了日(+時間)
                
                '@-----------------
                '@　装置構造体作成
                '@-----------------
                .lngWPCnt = 1                   '装置選択数
                If .typWpList Is Nothing     '配列再定義
                  .typWpList = New List(Of WP) 
                Else 
                  .typWpList.Clear()
                End If
                
                Dim typWpListtmp As WP = New WP 
                typWpListtmp.strWpID = ptypRepairConnectInfo.strWpID   '装置ID
                .typWpList.Add(typWpListtmp)

            End With
            
            
            Me.KeyPreview = False
            
            '@【故障修理記録票一覧取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnRepRepairList_Sel(mtypRepairInfoReq, _
                                              mtypRepairInfoAns, _
                                              mlngRepairListCnt)
                        
            Me.KeyPreview = True
            
            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvRepairListSearchProc)
                Exit Sub
            Else
                '@結果：正常の場合
                
                '@=======================
                '@　故障修理記録一覧の作成
                '@=======================
                Call prvVsfRepairList_Disp()
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvRepairListSearchProc)
            End If

            '@該当件数が0件か
            If lblDataCnt.Text <> CPstrZero Then
                '@件数が1件以上ある場合
                '@ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfMainteList)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            
            Me.KeyPreview = True
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrPrvRepairListSearchProc
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub
    '@↑2008/02/07 (Thu) 10:53:56 N.Kojima **************************************************

    '@↓2008/02/07 (Thu) 10:53:56 N.Kojima **************************************************
    '関数名：prvPreserveListSearch_Proc
    '機　能：保全記録票一覧　検索処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/02/07 (Thu) 10:55:16 N.Kojima
    '更新日：2008/02/07 (Thu) 10:55:16
    '備　考：
    Private Sub prvPreserveListSearch_Proc()
        
        Dim lblnAns      As Boolean          '故障修理記録票ﾘｽﾄ取得結果
        
        Try
            
            '@ﾚｽﾎﾟﾝｽ開始
            Call pubResponseStart(CMstrFormName, CMstrPrvPreserveListSearchProc)
            
            '@****************
            '@　要求ﾃﾞｰﾀ作成
            '@****************
            With mtypPreserveInfoReq
                
                .strSbID = pstrSBID                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrpre_preservelistVer               'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strStartDate = calStart.Value & CMstrStartTime     '検索開始日(+時間)
                .strEndDate = calEnd.Value & CMstrEndTime           '検索終了日(+時間)
                
                '@-----------------
                '@　装置構造体作成
                '@-----------------
                .lngWPCnt = 1                           '装置選択数
                If .typWpList Is Nothing             '配列再定義
                    .typWpList = New List(Of WP) 
                Else 
                    .typWpList.Clear()
                End If
                Dim typWpListtmp As WP = New WP
                typWpListtmp.strWpID = ptypPreserveConnectInfo.strWpID                     '装置ID
                .typWpList.Add(typWpListtmp)

                '@-----------------
                '@　ｶﾃｺﾞﾘ構造体作成
                '@-----------------
                .lngCategoryCnt = 1                     '装置選択数
                      
                If .typCategoryList Is Nothing          '配列再定義
                    .typCategoryList = New List(Of MasCategoryId) 
                Else 
                    .typCategoryList.Clear()
                End If
                Dim typCategoryListtmp As MasCategoryId = New MasCategoryId 
                typCategoryListtmp.strCategoryID = ptypPreserveConnectInfo.strCategoryID   'ｶﾃｺﾞﾘID
                .typCategoryList.Add(typCategoryListtmp)
            End With
            
            '@ﾌｫｰﾑﾛｯｸ
            'Me.Enabled = False
            Me.KeyPreview = False
            
            '@【保全記録票一覧取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnPrePreserveList_Sel(mtypPreserveInfoReq, _
                                                mtypPreserveInfoAns, _
                                                mlngPreserveListCnt, _
                                                CPstrCD4G)
            
            '@ﾌｫｰﾑﾛｯｸ解除
            'Me.Enabled = True
            Me.KeyPreview = True
            
            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvPreserveListSearchProc)
                Exit Sub
            Else
                '@結果：正常の場合
                
                '@=======================
                '@　保全記録一覧の作成
                '@=======================
                Call prvVsfPreserveList_Disp()
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvPreserveListSearchProc)
            End If

            '@該当件数が0件か
            If lblDataCnt.Text <> CPstrZero Then
                '@件数が1件以上ある場合
                
                '@ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfMainteList)
            Else
                '@該当件数が0件の場合
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000O)
                '@""<TRM0OW>$$保全記録票が登録(起票)されていません$[新規登録]ボタン押下で新規登録画面を起動し、$保全記録票を登録してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@新規登録ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdNewEntry)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
           
            Me.KeyPreview = True
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrPrvPreserveListSearchProc
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub
    '@↑2008/02/07 (Thu) 10:53:56 N.Kojima **************************************************


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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfMainteList.BeforeDoubleClick

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

End Class
