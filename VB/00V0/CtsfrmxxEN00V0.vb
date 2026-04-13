'ﾌｧｲﾙ名：xxEN00V0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：工程異常/不適合品処理票一覧　メインフォーム
'作成日：2004/08/10 (Tue) 10:07:17 S.Deguchi
'更新日：2008/09/19 (Fri) 14:44:09 T.Inafune
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00V0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00V0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00V0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00V0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00V0)
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
    Private Const CMstrLocalVersion                 As String = "07.00"

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN00V0          'ﾛｰｶﾙ機能ID

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ定数宣言
    Private Const CMstrexcpreportlistVer            As String = "02.00"                 '工程異常/不適合品処理票一覧取得
    Private Const CMstrmas_empname_Ver              As String = "02.01"                 '作業者名取得
    Private Const CPstrexcpapply__Ver               As String = "02.00"                 '処理票適用
    Private Const CPstrexcpdelete__Ver              As String = "02.00"                 '処理票破棄
    Private Const CMstrrep_registworkflowVer        As String = "01.00"                 '確認依頼登録
    Private Const CMstrmas_sblist__Ver              As String = "01.00"                 'ｼｽﾃﾑﾌﾞﾛｯｸ取得
    Private Const CPstrexcpcancelapplyVer           As String = "01.00"                 '工程異常/不適合品承認取消

    '@vsfExcpListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfColNo                     As Integer = 0                      '№
    Private Const CMlngvsfColFlag                   As Integer = 1                      '異常/不適合
    Private Const CMlngvsfColApply                  As Integer = 2                      '承認
    Private Const CMlngvsfColEntryTime              As Integer = 3                      '登録日時
    Private Const CMlngvsfColProcEmpID              As Integer = 4                      '依頼先担当者ID
    Private Const CMlngvsfColProcEmpName            As Integer = 5                      '依頼先担当者名
    Private Const CMlngvsfColEmpID                  As Integer = 6                      '起案者ID
    Private Const CMlngvsfColEmpName                As Integer = 7                      '起案者名
    Private Const CMlngvsfColExcpName               As Integer = 8                      '工程異常名
    Private Const CMlngvsfColExcpNo                 As Integer = 9                      '工程異常№
    Private Const CMlngvsfColLotID                  As Integer = 10                     'ﾛｯﾄID
    Private Const CMlngvsfColWPID                   As Integer = 11                     '装置ID
    Private Const CMlngvsfColFromEmpID              As Integer = 12                     '依頼元担当者ID
    Private Const CMlngvsfColFromEmpName            As Integer = 13                     '依頼元担当者名
    Private Const CMlngvsfColFromEntryTime          As Integer = 14                     '依頼日時
    Private Const CMlngvsfColEditTime               As Integer = 15                     '更新日時
    '@↓2008/09/17 (Wed) T.Inafune No:03121 **************************************************
    Private Const CMlngvsfColFindOpID               As Integer = 16                     '大工程
    Private Const CMlngvsfColFindStepID             As Integer = 17                     '小工程
    Private Const CMlngvsfColWpName                 As Integer = 18                     '装置名
    Private Const CMlngvsfColDispoName              As Integer = 19                     '処置名
    Private Const CMlngvsfColDispoWfNum             As Integer = 20                     '処置WF数
    Private Const CMlngvsfColExcpSitu               As Integer = 21                     '工程異常発生状況
    '@↑2008/09/17 (Wed) T.Inafune No:03121 **************************************************

    '@vsfExcpListの定数宣言(幅)
    Private Const CMlngvsfWColNo                    As Integer = 38                     '№
    Private Const CMlngvsfWColFlag                  As Integer = 33                     '異常/不適合
    Private Const CMlngvsfWColApply                 As Integer = 33                     '未処置/処置済/承認済
    Private Const CMlngvsfWColEntryTime             As Integer = 145                    '登録日時
    Private Const CMlngvsfWColProcEmpID             As Integer = 114                    '担当者ID
    Private Const CMlngvsfWColProcEmpName           As Integer = 125                    '担当者名
    Private Const CMlngvsfWColEmpID                 As Integer = 114                    '起案者ID
    Private Const CMlngvsfWColEmpName               As Integer = 125                    '起案者名
    Private Const CMlngvsfWColExcpName              As Integer = 181                    '工程異常名
    Private Const CMlngvsfWColExcpNo                As Integer = 85                     '工程異常№
    Private Const CMlngvsfWColLotID                 As Integer = 97                     'ﾛｯﾄID
    Private Const CMlngvsfWColWpID                  As Integer = 97                     '装置ID
    Private Const CMlngvsfWColWpName                As Integer = 185                    '装置名
    Private Const CMlngvsfWColFromEmpID             As Integer = 114                    '依頼元担当者ID
    Private Const CMlngvsfWColFromEmpName           As Integer = 114                    '依頼元担当者名
    Private Const CMlngvsfWColFromEntryTime         As Integer = 145                    '依頼日時
    Private Const CMlngvsfWColEditTime              As Integer = 145                    '更新日時
    '@↓2008/09/17 (Wed) T.Inafune No:03121 **************************************************
    Private Const CMlngvsfWColFindOpID              As Integer = 81                     '大工程
    Private Const CMlngvsfWColFindStepID            As Integer = 81                     '小工程
    Private Const CMlngvsfWColDispoName             As Integer = 81                     '処置名
    Private Const CMlngvsfWColDispoWfNum            As Integer = 38                     '処置WF数
    Private Const CMlngvsfWColExcpSitu              As Integer = 145                    '工程異常発生状況
    '@↑2008/09/17 (Wed) T.Inafune No:03121 **************************************************

    '@vsfExcpListの定数宣言(ｶﾗﾑ)
    Private Const CMstrvsfColNo                     As String = "№"                    '№
    Private Const CMstrvsfColFlag                   As String = " "                     '異常/不適合
    Private Const CMstrvsfColApply                  As String = " "                     '承認
    Private Const CMstrvsfColEntryTime              As String = "発見日時"              '発見日時
    Private Const CMstrvsfColProcEmpID              As String = "担当者ID"              '担当者ID
    Private Const CMstrvsfColProcEmpName            As String = "担当者"                '担当者名
    Private Const CMstrvsfColEmpID                  As String = "起案者ID"              '起案者ID
    Private Const CMstrvsfColEmpName                As String = "起案者"                '起案者名
    Private Const CMstrvsfColExcpName               As String = "工程異常名"            '工程異常名
    Private Const CMstrvsfColExcpNo                 As String = "発行№"                '工程異常№
    Private Const CMstrvsfColLotID                  As String = "ロットID"              'ﾛｯﾄID
    Private Const CMstrvsfColWpID                   As String = "装置ID"                '装置ID
    Private Const CMstrvsfColWpName                 As String = "装置名"                '装置名
    Private Const CMstrvsfColFromEmpID              As String = "担当者"                '依頼元担当者ID
    Private Const CMstrvsfColFromEmpName            As String = "担当者"                '依頼元担当者名
    Private Const CMstrvsfColFromEntryTime          As String = "依頼日"                '依頼日時
    Private Const CMstrvsfColEditTime               As String = "更新日時"              '更新日時
    '@↓2008/09/17 (Wed) T.Inafune No:03121 **************************************************
    Private Const CMstrvsfColFindOpID               As String = "大工程"                '大工程
    Private Const CMstrvsfColFindStepID             As String = "小工程"                '小工程
    Private Const CMstrvsfColDispoName              As String = "処置"                  '処置名
    Private Const CMstrvsfColDispoWfNum             As String = "WF数"                  '処置WF数
    Private Const CMstrvsfColExcpSitu               As String = "工程異常発生状況"       '工程異常発生状況
    '@↑2008/09/17 (Wed) T.Inafune No:03121 **************************************************

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                  As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                  As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                 As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfFontSize                  As Integer = 11                     'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                   As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                    As Integer = 17                     '1ｽﾛｯﾄの高さ計算用

    '@ｺﾝﾎﾞﾎﾞｯｸｽ共通の定数宣言
    Private Const CMlngCmbFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbListIndex2                As Integer = 0                      '表示ﾘｽﾄｲﾝﾃﾞｯｸｽ
    Private Const CMlngCmbRowHeight                 As Integer = 18                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                  As Integer = 0                      'ｺﾝﾎﾞ内列数(=0)
    '@↓2007/09/04 (Tue) 10:44:38 N.Kojima **************************************************
    Private Const CMlngCmbGridCol2                  As Integer = 2                      'ｺﾝﾎﾞ内列数(=2)
    Private Const CMlngCmbValueCol0                 As Integer = 0                      '値取得列=0
    Private Const CMlngCmbValueCol1                 As Integer = 1                      '値取得列=1
    '@↑2007/09/04 (Tue) 10:44:38 N.Kojima **************************************************

    '@文字列の定数宣言
    Private Const CMstrExcp                         As String = "異"                    '異常
    Private Const CMstrIngong                       As String = "不"                    '不適合品
    Private Const CMstrApplyFlag                    As String = "済"                    '承認済
    Private Const CMstrDisposalFlag                 As String = "処"                    '処置済
    Private Const CMstrNoDisposalFlag               As String = "未"                    '未処置
    Private Const CMstrStartTime                    As String = " 00:00:00"             '00:00:00
    Private Const CMstrEndTime                      As String = " 23:59:59"             '23:59:59
    Private Const CMstrALL                          As String = "全て"                  '全て
    Private Const CMstrDispose                      As String = "未処置"                '未処置
    Private Const CMstrNoApply                      As String = "処置済"                '処置済
    Private Const CMstrApply                        As String = "承認済"                '承認済
    Private Const CMstrlblCnt0                      As String = "0"                     '0件
    Private Const CMstrDisposalFlag0                As String = "0"                     '未処置
    Private Const CMstrTroubleFlag                  As String = "0"                     '工程異常処理票
    Private Const CMstrIncongFlag                   As String = "1"                     '不適合品処理票
    '@↓2007/09/04 (Tue) 11:06:13 N.Kojima **************************************************
    Private Const CMstrNotAppoint                   As String = "指定なし"              '起票SB
    '@↑2007/09/04 (Tue) 11:06:13 N.Kojima **************************************************

    '@登録/更新/表示の定数宣言
    Private Const CMstrExcpFlag0                    As String = "0"                     '新規登録
    Private Const CMstrExcpFlag1                    As String = "1"                     '更新登録
    Private Const CMstrExcpFlag2                    As String = "2"                     '表示(承認済み)

    '@ｼｽﾃﾑﾌﾞﾛｯｸ定数宣言
    Private Const CMstrA0                           As String = "A0"                    'ｼｽﾃﾑﾌﾞﾛｯｸ


    '@検索期間
    Private Const CMlngPeriod                       As Integer = 3                      '検索期間(3年)


    '@表示ﾒｯｾｰｼﾞ
    Private Const CMstrEmpIDTitle                   As String = "起案者ID"              '起案者ID
    Private Const CMstrProcEmpIDTitle               As String = "担当者ID"              '担当者ID
    Private Const CMstrExcpTitle                    As String = "工程異常処理票"        '工程異常処理票(承認成功MSG)
    Private Const CMstrIngongTitle                  As String = "不適合品処理票"        '不適合品処理票(承認成功MSG)

    '@定数の宣言
    Private Const CMlngEmpNameLenB13                As Integer = 13                     '担当者の表示ﾊﾞｲﾄ数(13)
    Private Const CMlngEmpNameLenB12                As Integer = 12                     '担当者の表示ﾊﾞｲﾄ数(12)
    Private Const CMstrEmpNameLenAfter              As String = ".."                    '担当者の表示

    '@↓2007/09/04 (Tue) 11:52:25 N.Kojima **************************************************
    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                     As String = "frmxxEN00V0"           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                     As String = "Form_Load"             'Form_Load処理
    Private Const CMstrCmdNowListClick              As String = "cmdNowList_Click"      '最新取得ﾎﾞﾀﾝClick処理
    Private Const CMstrCmbSBIDValidate              As String = "cmbSBID_Validate"      '起票SB選択確定時処理
    Private Const CMstrCmdApplyClick                As String = "cmdApply_Click"        '承認ﾎﾞﾀﾝClick処理
    Private Const CMstrCmdApplyCancelClick          As String = "cmdApplyCancel_Click"  '承認取消ﾎﾞﾀﾝClick処理
    Private Const CMstrCmdDisconClick               As String = "cmdDiscon_Click"       '削除ﾎﾞﾀﾝClick処理
    Private Const CMstrCmdMailSendClick             As String = "cmdMailSend_Click"     '確認依頼ﾎﾞﾀﾝClick処理
    '@↑2007/09/04 (Tue) 11:52:25 N.Kojima **************************************************

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@起動情報取得時0件の場合用ﾌﾗｸﾞ
    Private mblnExcpFlag                            As Boolean                          'True:処理終了/False:処理未

    '@退避領域
    Private mstrStartDate                           As String                           '開始日の退避領域
    Private mstrEndDate                             As String                           '終了日の退避領域
    Private mstrSearch                              As String                           '検索条件の退避領域
    '@↓2007/09/04 (Tue) 18:20:30 N.Kojima **************************************************
    Private mstrSBID                                As String                           '起票SBの退避領域
    '@↑2007/09/04 (Tue) 18:20:30 N.Kojima **************************************************
    Private mtypChgSort                             As ChgSort                          'ｿｰﾄ保持用
    Private mtypExcpReportList                      As ExcpReportList                   '応答情報格納構造体
    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                          'NSYS WindowCloseフラグ
    Private vsfExcpListRowBeforeSort                As Integer                          'NSYS ｿｰﾄ時の選択行退避
    Private vsfExcpListScrollPositionX              As Integer                          'NSYS 横ｽｸﾛｰﾙ位置退避

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
    '作成日：2004/08/10 (Tue) 10:23:53 S.Deguchi
    '更新日：2007/09/04 (Tue) 10:45:10 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 13:37:15 H.Wajima     機能ﾊﾞｰｼﾞｮﾝの取得処理を先頭に移動
    '　　　：2004/10/14 (Thu) 17:04:54 S.Deguchi　  ｿｰﾄ保持用構造体初期化を追加
    '　　　：2007/09/04 (Tue) 10:45:10 N.Kojima     起票SBｺﾝﾎﾞ追加に伴い、SB取得処理追加。(案件№02158)
    Private Sub Form_Load()
        
        Dim lblnAns             As Boolean              '結果格納
        Dim ltypExcpList        As ReportListReq        '一覧取得要求構造体
    '@↓2007/09/04 (Tue) 10:55:59 N.Kojima **************************************************
        Dim ltypMasSbList       As MasSbList            'ｼｽﾃﾑﾌﾞﾛｯｸ構造体
    '@↑2007/09/04 (Tue) 10:55:59 N.Kojima **************************************************
        
        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00V0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose                
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
        '@↓2007/09/04 (Tue) 10:42:58 N.Kojima **************************************************
            '@ｼｽﾃﾑﾌﾞﾛｯｸ取得結果
            lblnAns = pubblnMasSbList_Sel(CMstrmas_sblist__Ver, ltypMasSbList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                Exit Sub
            End If
            
            '@画面情報の初期化
            Call prvfrmxxEN00V0_Init(ltypMasSbList)
        '@↑2007/09/04 (Tue) 10:42:58 N.Kojima **************************************************
            
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@情報を取得して要求構造体に格納
            With ltypExcpList
                .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrexcpreportlistVer             'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strClassDivision = CPstrCD02                   '全件
                .strStartDate = calStart.Value & CMstrStartTime '検索開始時間
                .strEndDate = calEnd.Value & CMstrEndTime       '検索終了時間
                .strFindEmpID = vbNullString                    '起案者ID
                .strToEmpID = vbNullString                      '担当者ID
            End With
            
            '@異常処理票取得処理へ
            lblnAns = prvblnExcpList_Sel(ltypExcpList, mtypExcpReportList)
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            Else
                '@退避領域に情報をｾｯﾄする
                mstrStartDate = calStart.Value          '開始日
                mstrEndDate = calEnd.Value              '終了日
                mstrSearch = cmbSearch.Text             '検索条件
        '@↓2007/09/04 (Tue) 18:21:28 N.Kojima **************************************************
                mstrSBID = cmbSBID.Text                 '起票SB
        '@↑2007/09/04 (Tue) 18:21:28 N.Kojima **************************************************

            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            
            '@Form_Loadﾌﾗｸﾞ(正常)
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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/01 (Wed) 13:18:39 S.Deguchi
    '更新日：2004/10/19 (Tue) 10:51:28 Y.Yamagishi
    '備　考：
    '　　　：2004/10/19 (Tue) 10:51:28 Y.Yamagishi  ﾒｯｾｰｼﾞﾎﾞｯｸｽの0件表示をしない(不具合改善対応№87)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated


        Try
            '@起動情報取得時に該当件数が0件の場合ﾒｯｾｰｼﾞを表示する
            If mblnExcpFlag = False Then
                '@ﾌﾗｸﾞ変更
                mblnExcpFlag = True
                
                '@一覧を表記する
                Call prvvsfExcpList_Disp(mtypExcpReportList)
                
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
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 17:50:12 S.Deguchi
    '更新日：2007/09/04 (Tue) 17:57:42 N.Kojima
    '備　考：
    '　　　：2007/09/04 (Tue) 17:57:42 N.Kojima     起票SBｺﾝﾎﾞ追加に伴い、処理追加。(案件№02158)
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

            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙによる処理分岐
            Select Case ActiveControl.Name
                Case calStart.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@開始日Validate処理へ
                            RemoveHandler calStart.Validating,AddressOf calStart_Validate
                            Call calStart_Validate(calStart, New CancelEventArgs(False))
                            AddHandler calStart.Validating,AddressOf calStart_Validate
                            e.Handled = True
                    End Select

                Case calEnd.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@終了日Validate処理へ
                            RemoveHandler calEnd.Validating,AddressOf calEnd_Validate
                            Call calEnd_Validate(calEnd, New CancelEventArgs(False))
                            AddHandler calEnd.Validating,AddressOf calEnd_Validate
                            e.Handled = True
                    End Select

                Case cmbSearch.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@検索条件Validate処理へ
                            RemoveHandler cmbSearch.Validating, AddressOf cmbSearch_Validate
                            Call cmbSearch_Validate(cmbSearch, New CancelEventArgs(False))
                            AddHandler cmbSearch.Validating, AddressOf cmbSearch_Validate
                            e.Handled = True
                        Case Keys.Up, Keys.Down
                            'NSYS キー操作で検索条件を変更した場合、一覧を非活性化
                            vsfExcpList.Enabled = False
                    End Select
                    
        '@↓2007/09/04 (Tue) 17:58:49 N.Kojima **************************************************
                Case cmbSBID.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@起票SBValidate処理へ
                            RemoveHandler cmbSBID.Validating, AddressOf cmbSBID_Validate
                            Call cmbSBID_Validate(cmbSBID, New CancelEventArgs(False))
                            AddHandler cmbSBID.Validating, AddressOf cmbSBID_Validate
                            e.Handled = True
                        Case Keys.Up, Keys.Down
                            'NSYS キー操作で検索条件を変更した場合、一覧を非活性化
                            vsfExcpList.Enabled = False
                    End Select
                
                Case txtProcEmpID.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@担当者IDValidate処理へ
                            RemoveHandler txtProcEmpID.Validating, AddressOf txtProcEmpID_Validate
                            Call txtProcEmpID_Validate(txtProcEmpID, New CancelEventArgs(False))
                            AddHandler txtProcEmpID.Validating, AddressOf txtProcEmpID_Validate
                            e.Handled = True
                    End Select
                
                Case txtEmpID.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@起案者IDValidate処理へ
                            RemoveHandler txtEmpID.Validating, AddressOf txtEmpID_Validate
                            Call txtEmpID_Validate(txtEmpID, New CancelEventArgs(False))
                            AddHandler txtEmpID.Validating, AddressOf txtEmpID_Validate
                            e.Handled = True
                    End Select
        '@↑2007/09/04 (Tue) 17:58:49 N.Kojima **************************************************

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
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:10:13 S.Deguchi
    '更新日：2007/02/19 (Mon) 13:31:05 N.Kojima
    '備　考：
    '　　　：2005/11/21 (Mon) 15:05:59 S.Deguchi    ﾜｰｸﾌﾛｰ用ﾊﾟﾌﾞﾘｯｸ構造体の初期化処理を追加
    '　　　：2007/02/19 (Mon) 13:31:05 N.Kojima     故障修理記録票機能追加に伴い、ﾜｰｸﾌﾛｰ登録処理を統合。(案件№01774)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm             As Boolean              '開放結果格納
        Dim ltypDepartmentList      As DepartmentInfo       '部署/所属格納構造体
        Dim ltypDeptEmpList         As DeptEmpInfo          'ﾕｰｻﾞ格納構造体
        Dim ltypSendMailList        As SendMailList         '宛先人格納構造体
        Dim ltypMailInfo            As MailInfo             'ﾒｰﾙ送信画面引継ぎ構造体
        Dim ltypWorkFlow            As WorkFlow             'ﾜｰｸﾌﾛｰ用初期化構造体


        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender, e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort.typChgSortList.Clear
            End If
            
            '@ﾒｰﾙ関連一式の構造体をｸﾘｱする。
            ptypDepartmentList = ltypDepartmentList
            ptypDeptEmpList = ltypDeptEmpList
            ptypSendMailList = ltypSendMailList
            ptypMailInfo = ltypMailInfo

            If ptypDepartmentList.typDepartmentList Is Nothing Then
                ptypDepartmentList.typDepartmentList = New List(Of DepartmentList)
            Else
                ptypDepartmentList.typDepartmentList.Clear
            End If
            If ptypDeptEmpList.typDeptEmpList Is Nothing Then
                ptypDeptEmpList.typDeptEmpList = New List(Of DeptEmpList)
            Else
                ptypDeptEmpList.typDeptEmpList.Clear
            End If
            If ptypSendMailList.typSendMail Is Nothing Then
                ptypSendMailList.typSendMail = New List(Of SendMail)
            Else
                ptypSendMailList.typSendMail.Clear
            End If
            
            '@確認依頼用情報格納構造体の初期化
            ptypWorkFlow = ltypWorkFlow
            If ptypWorkFlow.typEmpList Is Nothing Then
                ptypWorkFlow.typEmpList = New List(Of ExcpToEmpList)
            Else
                ptypWorkFlow.typEmpList.Clear
            End If
            
            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
            '@Actを自前で初期化した場合
                '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                lblnAnsTerm = pubblnAct_Term
                '@結果判定
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

    '関数名：calStart_CalendarSelect
    '機　能：検索開始日付選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 17:35:27 S.Deguchi
    '更新日：2004/08/31 (Tue) 17:35:27
    '備　考：
    Private Sub calStart_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calStart.CalendarSelect

        Try
            '@Validate処理へ
            RemoveHandler calStart.Validating, AddressOf calStart_Validate
            Call calStart_Validate(sender, New CancelEventArgs(False))
            AddHandler calStart.Validating, AddressOf calStart_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：検索開始日付変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/23 (Tue) 16:58:31 S.Deguchi
    '更新日：2005/08/23 (Tue) 16:58:31
    '備　考：
    Private Sub calStart_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calStart.Change

        Try
            '@一覧ｸﾘｱ
            prvvsfExcpList_Init()
            
            '@該当件数
            lblLotCnt.Text = vbNullString

            '@現在日時表示
            lblNowDate.Text = vbNullString

            'NSYS 入力値が日付型でない場合一覧を非活性化
            If IsDate(calStart.Value) = False Then
                vsfExcpList.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStart_Change"            '関数名
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStart_Validate
    '機　能：検索開始日付Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 17:35:30 S.Deguchi
    '更新日：2007/09/05 (Wed) 10:10:31 N.Kojima
    '備　考：
    '　　　：2007/09/05 (Wed) 10:10:31 N.Kojima     不用ﾌｫｰｶｽ処理をｺﾒﾝﾄｱｳﾄ。(案件№02158のついで)
    Private Sub calStart_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calStart.Validating

        Dim lstrNowDT           As String       '現在日付取得
        Dim lstrTempEndDate     As String       '終了日付

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@退避領域と異なる場合には下記処理
            If mstrStartDate <> calStart.Value Then
                '@日付が入力されている場合
                If calStart.Value <> CPstrNullDate Then
                    '@日付の有効性ﾁｪｯｸ
                    If pubblnYearRange_Chk(calStart.Value) = False Then
                        
                        'NSYS フォーカスを移動
                        Call pubSetFocus(calStart)

                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                        '@"正しい日付を入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        e.Cancel = True
                        
                        Exit Sub
                    Else
                        '@現在日付取得
                        lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                        
                        '@未来日付の場合
                        If Format$(CDate(calStart.Value), CPstrDateTimeYMD) > lstrNowDT Then
                            
                            'NSYS フォーカスを移動
                            Call pubSetFocus(calStart)

                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                            '@"未来日付は指定できません。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            e.Cancel = True
                            
                            Exit Sub
                        Else
                            '@さらに終了日付と比較
                            If Format$(CDate(calStart.Value), CPstrDateTimeYMD) > Format$(CDate(calEnd.Value), CPstrDateTimeYMD) Then
                                
                                'NSYS フォーカスを移動
                                Call pubSetFocus(calStart)

                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                                '@"開始日が終了日より大きくなっています。設定を見直してください。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                e.Cancel = True
                                
                                Exit Sub
                            End If
                        End If
                    End If
                    
        '@↓2007/12/05 (Wed) 14:03:47 N.Kasai **************************************************
                    '@3年期間のﾁｪｯｸ
                    lstrTempEndDate = DateAdd("yyyy", CMlngPeriod, calStart.Value)
                    If Format$(CDate(lstrTempEndDate), CPstrDateTimeYMD) < Format$(CDate(calEnd.Value), CPstrDateTimeYMD) Then
                        
                        'NSYS フォーカスを移動
                        Call pubSetFocus(calStart)

                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005O, CMlngPeriod & "年")
                        '@"<TRM5OW>$$日付検索期間が%1を超えています。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        e.Cancel = True
                        
                        Exit Sub
                    End If
        '@↑2007/12/05 (Wed) 14:03:47 N.Kasai **************************************************
                    
                Else
                    
                    'NSYS フォーカスを移動
                    Call pubSetFocus(calStart)

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002V)
                    '@"開始日を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                    
                    Exit Sub
                
                End If
            
                '@最新取得処理を行う(上記の条件を満たしている場合)
                Call cmdNowList_Click(sender, e)

            Else
                'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが開始日の場合のみ
                If ActiveControl.Name = calStart.Name Then
                    '@終了日にｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(calEnd)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：検索終了日付選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 17:35:32 S.Deguchi
    '更新日：2004/08/31 (Tue) 17:35:32
    '備　考：
    Private Sub calEnd_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calEnd.CalendarSelect

        Try
            '@Validate処理へ
            RemoveHandler calEnd.Validating, AddressOf calEnd_Validate
            Call calEnd_Validate(calEnd, New CancelEventArgs(False))
            AddHandler calEnd.Validating, AddressOf calEnd_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：検索終了日付変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/23 (Tue) 16:58:31 S.Deguchi
    '更新日：2005/08/23 (Tue) 16:58:31
    '備　考：
    Private Sub calEnd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calEnd.Change

        Try
            '@一覧ｸﾘｱ
            prvvsfExcpList_Init()
            
            '@該当件数
            lblLotCnt.Text = vbNullString

            '@現在日時表示
            lblNowDate.Text = vbNullString
            
            'NSYS 入力値が日付型でない場合一覧を非活性化
            If IsDate(calEnd.Value) = False Then
                vsfExcpList.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calEnd_Change"              '関数名
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calEnd_Validate
    '機　能：検索終了日付Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 17:35:34 S.Deguchi
    '更新日：2007/09/05 (Wed) 10:09:33 N.Kojima
    '備　考：
    '　　　：2007/09/05 (Wed) 10:09:33 N.Kojima     不用ﾌｫｰｶｽ処理をｺﾒﾝﾄｱｳﾄ。(案件№02158のついで)
    Private Sub calEnd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calEnd.Validating

        Dim lstrNowDT           As String       '現在日付取得
        Dim lstrTempEndDate     As String       '終了日付

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If

            '@退避領域と異なる場合には下記処理
            If mstrEndDate <> calEnd.Value Then
            
                '@日付が入力されていいる場合
                If calEnd.Value <> CPstrNullDate Then
                    '@日付の有効性ﾁｪｯｸ
                    If pubblnYearRange_Chk(calEnd.Value) = False Then
                        
                        'NSYS フォーカスを移動
                        Call pubSetFocus(calEnd)

                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                        '@"正しい日付を入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        e.Cancel = True
                        
                        Exit Sub
                    Else
                        '@現在日付取得
                        lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                        
                        '@未来日付の場合
                        If Format$(CDate(calEnd.Value), CPstrDateTimeYMD) > lstrNowDT Then
                            
                            'NSYS フォーカスを移動
                            Call pubSetFocus(calEnd)

                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                            '@"未来日付は指定できません。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            e.Cancel = True
                            
                            Exit Sub
                        Else
                        '@さらに開始日付と比較
                            If Format$(CDate(calStart.Value), CPstrDateTimeYMD) > Format$(CDate(calEnd.Value), CPstrDateTimeYMD) Then
                                
                                'NSYS フォーカスを移動
                                Call pubSetFocus(calEnd)

                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                                '@"開始日が終了日より大きくなっています。設定を見直してください。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                e.Cancel = True
                                
                                Exit Sub
                            End If
                        End If
                    End If
                    
        '@↓2007/12/05 (Wed) 14:03:27 N.Kasai **************************************************
                    '@3年期間のﾁｪｯｸ
                    lstrTempEndDate = DateAdd("yyyy", CMlngPeriod, calStart.Value)
                    If Format$(CDate(lstrTempEndDate), CPstrDateTimeYMD) < Format$(CDate(calEnd.Value), CPstrDateTimeYMD) Then
                        
                        'NSYS フォーカスを移動
                        Call pubSetFocus(calEnd)

                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005O, CMlngPeriod & "年")
                        '@"<TRM5OW>$$日付検索期間が%1を超えています。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        e.Cancel = True
                        
                        Exit Sub
                    End If
        '@↑2007/12/05 (Wed) 14:03:27 N.Kasai **************************************************
                    
                Else
                    
                    'NSYS フォーカスを移動
                    Call pubSetFocus(calEnd)

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002W)
                    '@"終了日を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    e.Cancel = True
                    
                    Exit Sub

                End If
                    
                '@最新取得処理を行う(上記の条件を満たしている場合)
                Call cmdNowList_Click(sender, e)
            
        '@↓2007/09/05 (Wed) 10:09:24 N.Kojima **************************************************
        '        '@ﾌｫｰｶｽをｾｯﾄ
        '        If vsfExcpList.Enabled = True Then
        '            '@ｸﾞﾘｯﾄﾞにｾｯﾄﾌｫｰｶｽ
        '            Call pubSetFocus(vsfExcpList)
        '        Else
        '            '@検索条件にｾｯﾄﾌｫｰｶｽ
        '            Call pubSetFocus(cmbSearch)
        '        End If
        '@↑2007/09/05 (Wed) 10:09:24 N.Kojima **************************************************

            Else
                'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが終了日の場合のみ
                If ActiveControl.Name = calEnd.Name Then
                    '@検索条件にｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbSearch)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calEnd_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSearch_Change
    '機　能：検索条件変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/23 (Tue) 17:03:12 S.Deguchi
    '更新日：2005/08/23 (Tue) 17:03:12
    '備　考：
    Private Sub cmbSearch_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSearch.Change

        Try
            '@退避領域と異なる場合には初期化
            If mstrSearch <> cmbSearch.Text Then
                '@一覧ｸﾘｱ
                prvvsfExcpList_Init()
                
                '@該当件数
                lblLotCnt.Text = vbNullString
            
                '@現在日時表示
                lblNowDate.Text = vbNullString
                
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSearch_Change"           '機能名
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSearch_CloseUp
    '機　能：検索条件CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 17:35:37 S.Deguchi
    '更新日：2004/08/31 (Tue) 17:35:37
    '備　考：
    Private Sub cmbSearch_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSearch.CloseUp

        Try
            '@Validate処理へ
            RemoveHandler cmbSearch.Validating, AddressOf cmbSearch_Validate
            Call cmbSearch_Validate(cmbSearch, New CancelEventArgs(False))
            AddHandler cmbSearch.Validating, AddressOf cmbSearch_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSearch_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSearch_Validate
    '機　能：検索条件Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 17:35:41 S.Deguchi
    '更新日：2007/09/04 (Tue) 17:36:49 N.Kojima
    '備　考：
    '　　　：2007/09/04 (Tue) 17:36:49 N.Kojima     選択内容変更なしの場合、起票SBｺﾝﾎﾞにﾌｫｰｶｽをｾｯﾄする。(案件№02158)
    Private Sub cmbSearch_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbSearch.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@退避領域と異なる場合には下記処理
            If mstrSearch <> cmbSearch.Text Then
                '@空欄以外の場合には処理を行う
                If cmbSearch.Text <> vbNullString Then
                    Call cmdNowList_Click(sender, e)
                Else
                    '@閉じるにｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmdClose)
                End If
            Else
            
        '@↓2007/09/04 (Tue) 17:38:10 N.Kojima **************************************************
                '@ﾌｫｰｶｽをｾｯﾄ
        '       If vsfExcpList.Enabled = True Then
                'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが自身の場合のみ閉じるﾎﾞﾀﾝをﾌｫｰｶｽ
                If ActiveControl.Name = cmbSearch.Name Then
                    If cmbSBID.Enabled = True Then
        '               '@ｸﾞﾘｯﾄﾞにｾｯﾄﾌｫｰｶｽ
        '               Call pubSetFocus(vsfExcpList)
                        '@起票SBにｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmbSBID)
                    Else
                        '@閉じるにｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
        '@↑2007/09/04 (Tue) 17:38:10 N.Kojima **************************************************
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSearch_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSBID_Change
    '機　能：起票SB変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/04 (Tue) 11:15:31 N.Kojima
    '更新日：2007/09/04 (Tue) 11:15:31
    '備　考：
    Private Sub cmbSBID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSBID.Change
            
        Try
            '@退避領域と異なる場合には初期化
            If mstrSBID <> cmbSBID.Text Then
                '@一覧ｸﾘｱ
                prvvsfExcpList_Init
                
                '@該当件数
                lblLotCnt.Text = vbNullString
            
                '@現在日時表示
                lblNowDate.Text = vbNullString
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSBID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSBID_CloseUp
    '機　能：起票SB選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/04 (Tue) 11:19:23 N.Kojima
    '更新日：2007/09/04 (Tue) 11:19:23
    '備　考：
    Private Sub cmbSBID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSBID.CloseUp
        
        Try
            '@Validate処理へ
            RemoveHandler cmbSBID.Validating, AddressOf cmbSBID_Validate
            Call cmbSBID_Validate(cmbSBID, New CancelEventArgs)
            AddHandler cmbSBID.Validating, AddressOf cmbSBID_Validate
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbSBID_CloseUp"        '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbSBID_Validate
    '機　能：起票SBValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/09/04 (Tue) 16:05:26 N.Kojima
    '更新日：2007/09/04 (Tue) 16:05:26
    '備　考：
    Private Sub cmbSBID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbSBID.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@退避領域と異なるか
            If mstrSBID <> cmbSBID.Text Then
                '@空欄以外の場合には処理を行う
                If cmbSBID.Text <> vbNullString Then
                    '@最新情報取得
                    Call cmdNowList_Click(sender, e)
                Else
                    '@閉じるにｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmdClose)
                End If
            Else
                'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが自身の場合のみ閉じるﾎﾞﾀﾝをﾌｫｰｶｽ
                If ActiveControl.Name = cmbSBID.Name Then
                    '@ﾌｫｰｶｽをｾｯﾄ
                    If txtProcEmpID.Enabled = True Then
                        '@担当者IDにｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(txtProcEmpID)
                    Else
                        '@閉じるにｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSBID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowList_Click
    '機　能：最新取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/08 (Mon) 14:22:09 S.Deguchi
    '更新日：2007/09/04 (Tue) 11:04:19 N.Kojima
    '備　考：
    '　　　：2005/09/22 (Thu) 09:45:05 S.Deguchi    簡易ﾜｰｸﾌﾛｰ対応
    '　　　：2007/09/04 (Tue) 11:04:19 N.Kojima     起票SBｺﾝﾎﾞ追加に伴い、処理追加。(案件№02158)
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs, Optional ByVal blnMovedFocusFlg As Boolean = False) Handles cmdNowList.Click

        Dim lblnAns             As Boolean              '結果格納
        Dim ltypExcpList        As ReportListReq        '一覧取得要求構造体
        Dim lstrSBID            As String               '選択SB格納用
        
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
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdNowListClick)

        '@↓2007/09/04 (Tue) 11:01:51 N.Kojima **************************************************
            '@起票SBのﾁｪｯｸ
            If cmbSBID.Value = vbNullString Then
                '@"指定なし"の場合
                lstrSBID = vbNullString
            Else
                '@指定されている場合
                lstrSBID = cmbSBID.Value
            End If
        '@↑2007/09/04 (Tue) 11:01:51 N.Kojima **************************************************

            '@情報を取得して要求構造体に格納
            With ltypExcpList
            
        '@↓2007/09/04 (Tue) 11:08:37 N.Kojima **************************************************
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
        '        .strSBID = pstrSBID
                .strSbID = lstrSBID
        '@↑2007/09/04 (Tue) 11:08:37 N.Kojima **************************************************
                
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstrexcpreportlistVer
                
                '@検索条件によりClassDivision選択
                Select Case cmbSearch.Text
                    Case CMstrApply
                    '@承認済のみ
                        .strClassDivision = CPstrCD2C
                    Case CMstrNoApply
                    '@処置済のみ
                        .strClassDivision = CPstrCD3A
                    Case CMstrALL
                    '@両方
                        .strClassDivision = CPstrCD02
                    Case CMstrDispose
                    '@未処置
                        .strClassDivision = CPstrCD3S
                End Select
                
                '@検索開始時間
                .strStartDate = calStart.Value & CMstrStartTime
                
                '@検索終了時間
                .strEndDate = calEnd.Value & CMstrEndTime
                
                '@起案者
                .strFindEmpID = txtEmpID.Text
                
                '@担当者
                .strToEmpID = txtProcEmpID.Text
            End With
            
            '@異常処理票取得処理へ
            lblnAns = prvblnExcpList_Sel(ltypExcpList, mtypExcpReportList)
            '@結果判定
            If lblnAns = False Then
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdNowListClick)
                
                Exit Sub
            Else

                '@一覧を表記する

                Call prvvsfExcpList_Disp(mtypExcpReportList)
                
                '@退避領域に情報をｾｯﾄする
                mstrStartDate = calStart.Value          '開始日
                mstrEndDate = calEnd.Value              '終了日
                mstrSearch = cmbSearch.Text             '検索条件
        '@↓2007/09/04 (Tue) 18:22:14 N.Kojima **************************************************
                mstrSBID = cmbSBID.Text                 '起票SB
        '@↑2007/09/04 (Tue) 18:22:14 N.Kojima **************************************************

            End If

            'NSYS 一覧0件の場合は一覧選択不可とする
            If vsfExcpList.Rows.count -1  = 0 Then
                vsfExcpList.Enabled = False
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdNowListClick)

            '@該当件数が0件の場合
            If lblLotCnt.Text = CMstrlblCnt0 Then
                '@開始日欄へｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(calStart)
            Else
                '@一覧へｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(vsfExcpList)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じる処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 11:30:27 S.Deguchi
    '更新日：2004/08/25 (Wed) 11:30:27
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo      As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@終了関数を実行する
            Call publngEnd_Proc(CPstrKeyEN00V0, ltypCommonInfo)

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

    '@↓2007/09/03 (Mon) 17:32:19 N.Kojima **************************************************
    '関数名：cmdCopy_Click
    '機　能：EXCELに貼り付ける際に、ｾﾙの先頭の文字列が、
    '　　　　「－」、「＋」の場合は、自動計算されるので、罫線文字におきかえる
    '引　数：なし
    '戻り値：なし
    '作成日：2007/09/03 (Mon) 17:35:14 N.Kojima
    '更新日：2007/12/06 (Thu) 15:56:04 N.Kasai
    '備　考：
    '　　　：2007/12/06 (Thu) 15:56:04 N.Kasai  改行ｺｰﾄﾞをｶﾝﾏに置き換え
    Private Sub cmdCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopy.Click

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
            Clipboard.Clear
            
            '@一覧をｺﾋﾟｰする
            With vsfExcpList
                '@行
                For llngRowCnt = 0 To .Rows.Count - 1
                    '@列
                    For llngColCnt = 0 To .Cols.Count - 1
                        '@列が非表示でない場合
                        If Not .Cols(llngColCnt).Visible = False Then
                        
                            '@文字列編集変数に値をｾｯﾄ
                            lstrWk = Replace(.GetData(llngRowCnt, llngColCnt), vbCrLf, ",")
                            
                            '@先頭の文字列が「-」「+」の場合は罫線文字に置き換える
                            If Mid$(lstrWk, 1, 1) = CPstrMinus Then
                                Mid$(lstrWk, 1, 1) = CPstrMinusWide
                            End If
                            If Mid$(lstrWk, 1, 1) = CPstrPlus Then
                                Mid$(lstrWk, 1, 1) = CPstrPlusWide
                            End If
                            
                            '@最終列の場合Tabいらない
                            If llngColCnt = CMlngvsfColFromEntryTime Then
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
                .strProcName = "cmdCopy_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub
    '@↑2007/09/03 (Mon) 17:32:19 N.Kojima **************************************************

    '関数名：cmdRegist_Click
    '機　能：編集処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 11:30:30 S.Deguchi
    '更新日：2004/08/25 (Wed) 11:30:30
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim lstrTemp                As Object               '一時取得

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

            '@引継構造体の初期化
            If ptypExcpEditList.typExcpEmpList Is Nothing Then
                ptypExcpEditList.typExcpEmpList = New List(Of ExcpEmpList)
            Else
                ptypExcpEditList.typExcpEmpList.Clear
            End If
            ptypExcpEditList.lnEmpListCnt = 0
            
            '@引継ぎ構造体に情報をｾｯﾄ
            With ptypExcpEditList
                '@異常処理№
                .strExcpNo = vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpNo)
                
                '@起案ｼｽﾃﾑﾌﾞﾛｯｸ
                .strSbID = Mid(.strExcpNo, 2, 1) & CMstrA0
                
                '@依頼日時
                .strFromEntryTime = vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColFromEntryTime)
                
                '@依頼元担当者
                .strFromEmpID = vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColFromEmpID)
                .strFromEmpName = vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColFromEmpName)
                
                '@依頼先担当者ﾘｽﾄ
                If vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColProcEmpName) <> vbNullString Then
                    lstrTemp = Split(vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColProcEmpName), vbCrLf)
                    For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)
                        Dim typExcpEmpListTmp As ExcpEmpList = New ExcpEmpList
                        typExcpEmpListTmp.strEmpName = lstrTemp(llngCnt)

                        .typExcpEmpList.Add(typExcpEmpListTmp)
                        .lnEmpListCnt = .lnEmpListCnt + 1
                    Next llngCnt
                Else
                    .lnEmpListCnt = 0
                    If .typExcpEmpList Is Nothing Then
                        .typExcpEmpList = New List(Of ExcpEmpList)
                    Else
                        .typExcpEmpList.Clear
                    End If
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
                End If
            End With
                
            '@最新取得処理を行う
            Call cmdNowList_Click(sender, e)
            
            '@選択処理を行う
            Call vsfExcpList_RowColChange(sender, New EventArgs())
            
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

    '関数名：cmdApply_Click  (2023/03/07　ﾕｰｻﾞ要望で「承認」ボタン非表示化)
    '機　能：承認処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 17:37:52 S.Deguchi
    '更新日：2007/12/13 (Thu) 15:22:55 N.Kasai
    '備　考：
    '　　　：2004/09/26 (Sun) 08:41:20 S.Deguchi    ｼｽﾃﾑﾌﾞﾛｯｸの取得方法を変更(異常処理№から作成)
    '　　　：2005/03/11 (Fri) 11:18:32 S.Deguchi    実行権限機能追加
    '　　　：2005/04/21 (Thu) 13:36:48 N.Kasai      承認時の成功ﾒｯｾｰｼﾞﾀｲﾄﾙを明確に表示
    '　　　：2006/11/29 (Wed) 18:54:39 T.Kitagawa　 ﾊﾟｽﾜｰﾄﾞ確認機能追加(案件№01581)
    '　　　：2007/09/04 (Tue) 11:46:31 N.Kojima     ﾚｽﾎﾟﾝｽ処理の引数を修正。(案件№02158のついで)
    '　　　：2007/12/13 (Thu) 15:22:55 N.Kasai      更新日時追加
    Private Sub cmdApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdApply.Click

        Dim lblnAns             As Boolean              '結果格納
        Dim ltypExcpApply       As ExcpApply            '要求格納構造体
        Dim lstrFunctionID      As String
        Dim lstrActionID        As String               'ｱｸｼｮﾝID
        Dim lstrEmpID           As String               '作業者ID
        Dim lstrEmpName         As String               '作業者名
        Dim lstrSBID            As String               'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim lstrITitle          As String               '承認成功ﾀｲﾄﾙ格納

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
                
            '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdApplyClick)
            
            '@実行権限の処理を追加
            lstrFunctionID = CPstrKeyEN00V0             '機能ID: EN00V0
            lstrActionID = CPstrExcpApply               'ｱｸｼｮﾝID：異常処理承認
            lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
            lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
            lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ

            '@実行権限ﾁｪｯｸ
            lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, lstrEmpID, lstrEmpName, lstrSBID)
            '@結果判定
            If lblnAns = False Then
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdApplyClick)

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrExcpApply)
                '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                Exit Sub
            End If
            
            '@情報を取得して要求構造体に格納
            With ltypExcpApply
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                .strSbID = Mid(vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpNo), 2, 1) & CMstrA0
                
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CPstrexcpapply__Ver
                
                '@異常処理ﾌﾗｸﾞ判定(0:工程異常/1:不適合品)
                If vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColFlag) = CMstrExcp Then
                    lstrITitle = CMstrExcpTitle
                Else
                    lstrITitle = CMstrIngongTitle
                End If
                
                '@異常処理№
                .strExcpNo = vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpNo)
                
                '@作業者ID
                .strEmpID = pstrUserID
                
                '@更新日時
                .strEditTime = vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColEditTime)
                
            End With
            
            '@異常処理承認登録
            lblnAns = pubblnExcpApply_Ins(ltypExcpApply)
            If lblnAns = True Then
            '@成功の場合

            Else
            '@失敗の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdApplyClick)
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdApplyClick)
            
            '@ﾒｯｾｰｼﾞを表示する
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001X, lstrITitle, "承認", _
                       vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpNo))

            '@成功ﾒｯｾｰｼﾞ表示
            '@pubVsfInfo_Disp("<TRM1XI>$$%1を%2しました。異常処理№[%3]")
            Call pubVsfInfo_Disp(pstrDMsg)

            '@選択行によるﾎﾞﾀﾝ制御処理を動作
            Call cmdNowList_Click(sender, e)
            Call vsfExcpList_RowColChange(sender, New EventArgs())
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdApply_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdApplyCancel_Click
    '機　能：承認取消ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2007/12/13 (Thu) 14:38:34 N.Kasai
    '更新日：2007/12/13 (Thu) 14:38:34
    '備　考：
    Private Sub cmdApplyCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdApplyCancel.Click

        Dim lblnAns             As Boolean              '結果格納
        Dim ltypExcpApply       As ExcpApply            '要求格納構造体
        Dim lstrFunctionID      As String               'ﾌｧﾝｸｼｮﾝID
        Dim lstrActionID        As String               'ｱｸｼｮﾝID
        Dim lstrEmpName         As String               '作業者名
        Dim lstrITitle          As String               '承認成功ﾀｲﾄﾙ格納

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
                
            '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdApplyCancelClick)
            
            '@実行権限の処理を追加
            lstrFunctionID = CPstrKeyEN00V0             '機能ID: EN00V0
            lstrActionID = CPstrExcpApply               'ｱｸｼｮﾝID：異常処理承認
            lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名

            '@実行権限ﾁｪｯｸ
            lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, pstrUserID, lstrEmpName, pstrSBID)
            '@結果判定
            If lblnAns = False Then
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdApplyCancelClick)

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrExcpApply)
                '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                Exit Sub
            End If
            
            '@情報を取得して要求構造体に格納
            With ltypExcpApply
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                .strSbID = Mid(vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpNo), 2, 1) & CMstrA0
                
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CPstrexcpcancelapplyVer
                
                '@異常処理ﾌﾗｸﾞ判定(0:工程異常/1:不適合品)
                If vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColFlag) = CMstrExcp Then
                    lstrITitle = CMstrExcpTitle
                Else
                    lstrITitle = CMstrIngongTitle
                End If
                
                '@異常処理№
                .strExcpNo = vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpNo)
                
                '@作業者ID
                .strEmpID = pstrUserID
                
                '@更新日時
                .strEditTime = vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColEditTime)

            End With
            
            '@異常処理承認取消
            lblnAns = pubblnExcpCancelApply_Upd(ltypExcpApply)
            If lblnAns = True Then
            '@成功の場合
                
            Else
            '@失敗の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdApplyCancelClick)
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdApplyCancelClick)
            
            '@ﾒｯｾｰｼﾞを表示する
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001X, lstrITitle, cmdApplyCancel.Text, _
                       vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpNo))

            '@成功ﾒｯｾｰｼﾞ表示
            '@pubVsfInfo_Disp("<TRM1XI>$$%1を%2しました。異常処理№[%3]")
            Call pubVsfInfo_Disp(pstrDMsg)

            '@選択行によるﾎﾞﾀﾝ制御処理を動作
            Call cmdNowList_Click(sender, e)
            Call vsfExcpList_RowColChange(sender, New EventArgs())
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdApplyCancel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDiscon_Click
    '機　能：破棄処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/01 (Mon) 13:01:10 S.Deguchi
    '更新日：2007/12/13 (Thu) 15:22:29 N.Kasai
    '備　考：
    '　　　：2006/11/29 (Wed) 18:53:12 T.Kitagawa   ﾊﾟｽﾜｰﾄﾞ確認機能追加(案件№01581)
    '　　　：2007/09/04 (Tue) 11:47:23 N.Kojima     ﾚｽﾎﾟﾝｽ処理の引数を修正。(案件№02158のついで)
    '　　　：2007/12/13 (Thu) 15:22:29 N.Kasai      更新日時追加
    Private Sub cmdDiscon_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDiscon.Click

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrFunctionID      As String
        Dim lstrActionID        As String               'ｱｸｼｮﾝID
        Dim lstrEmpID           As String               '作業者ID
        Dim lstrEmpName         As String               '作業者名
        Dim lstrSBID            As String               'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim lstrITitle          As String               '承認成功ﾀｲﾄﾙ格納
        Dim ltypExcpDiscon      As ExcpApply            '要求格納構造体

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
                
            '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdDisconClick)
            
            '@実行権限の処理を追加
            lstrFunctionID = CPstrKeyEN00V0             '機能ID: EN00V0
            lstrActionID = CPstrExcpDiscon              'ｱｸｼｮﾝID：工程異常/不適合品処理票破棄
            lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
            lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
            lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ

            '@実行権限ﾁｪｯｸ
            lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, lstrEmpID, lstrEmpName, lstrSBID)
            '@結果判定
            If lblnAns = False Then
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdDisconClick)

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrExcpDiscon)
                '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                Exit Sub
            End If
            
            '@情報を取得して要求構造体に格納
            With ltypExcpDiscon
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                .strSbID = Mid(vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpNo), 2, 1) & CMstrA0

                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CPstrexcpdelete__Ver

                '@異常処理ﾌﾗｸﾞ判定(0:工程異常/1:不適合品)
                If vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColFlag) = CMstrExcp Then
                    lstrITitle = CMstrExcpTitle
                Else
                    lstrITitle = CMstrIngongTitle
                End If

                '@異常処理№
                .strExcpNo = vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpNo)

                '@作業者ID
                .strEmpID = pstrUserID
                
                '@更新日時
                .strEditTime = vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColEditTime)

            End With
            
            '@異常処理破棄登録
            lblnAns = pubblnExcpDelete_Upd(ltypExcpDiscon)
            If lblnAns = True Then
            '@成功の場合
            Else
            '@失敗の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdDisconClick)
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdDisconClick)
            
            '@ﾒｯｾｰｼﾞを表示する
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004X, _
                                            lstrITitle, _
                                            vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpNo))

            '@成功ﾒｯｾｰｼﾞ表示
            '@pubVsfInfo_Disp("<TRM4XI>$$%1を破棄しました。異常処理№[%2]")
            Call pubVsfInfo_Disp(pstrDMsg)

            '@最新取得処理を行う
            Call cmdNowList_Click(sender, e)
            
            '@ﾌｫｰｶｽをﾀｲﾄﾙへ
            vsfExcpList.Row = 0
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDiscon_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMailSend_Click
    '機　能：確認依頼ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/15 (Thu) 14:27:16 S.Deguchi
    '更新日：2007/09/04 (Tue) 11:48:20 N.Kojima
    '備　考：
    '　　　：2005/10/25 (Tue) 16:14:59 S.Deguchi    引継起動処理を修正
    '　　　：2005/11/21 (Mon) 16:14:59 S.Deguchi    引継起動処理をさらに修正
    '　　　：2007/02/19 (Mon) 13:33:07 N.Kojima     故障修理記録票機能追加に伴い、ﾜｰｸﾌﾛｰ登録処理を統合。(案件№01774)
    '　　　：2007/09/04 (Tue) 11:48:20 N.Kojima     ﾚｽﾎﾟﾝｽ処理の引数を修正。(案件№02158のついで)
    Private Sub cmdMailSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMailSend.Click

        Dim lstrLotAll              As String               '対象ﾛｯﾄIDを格納
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾄ
        Dim lstrTemp                As Object               '一時取得
        Dim ltypWorkFlow            As WorkFlow             'ﾜｰｸﾌﾛｰ構造体初期化用構造体
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrMsg                 As String               'ﾒｯｾｰｼﾞ内容格納

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

            '@確認依頼用情報格納構造体の初期化
            ptypWorkFlow = ltypWorkFlow
            
            '@確認依頼情報を格納
            With ptypWorkFlow
                '@処理票№
                .strReportNo = vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpNo)
            
                '@起案ｼｽﾃﾑﾌﾞﾛｯｸ
                .strSbID = Mid(.strReportNo, 2, 1) & CMstrA0
            End With
            
            '@ﾒｰﾙ内容取得
            With ptypMailInfo
                '@初期化
                .strMailContents = vbNullString
                .strMailSubject = vbNullString
                lstrLotAll = vbNullString
                
                If ptypSendMailList.typSendMail Is Nothing Then
                    ptypSendMailList.typSendMail = New List(Of SendMail)
                Else
                    ptypSendMailList.typSendMail.Clear
                End If
                ptypSendMailList.lngSendMailCnt = 0
                
                '@ﾛｯﾄIDを取得する
                lstrTemp = Split(vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColLotID), vbCrLf)
                For llngCnt = 0 To UBound(lstrTemp)
                    If llngCnt = 0 Then
                        lstrLotAll = lstrTemp(llngCnt)
                    Else
                        lstrLotAll = lstrLotAll & "," & lstrTemp(llngCnt)
                    End If
                Next llngCnt
                    
                '@ﾒｰﾙ内容格納
                '@件名文字列作成
                .strMailSubject = CPstrMailSendTitleExcp & _
                                  Replace(CPstrMailSubjectExcp, _
                                          "%1", _
                                          vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpNo))
                
                '@##########ﾒｰﾙ本文固定表記##########
                '@送信者：XXXXXXXXXX
                '@発行№：XXXXXXXXXX
                '@工程異常名：XXXXXXXXXX
                '@対象ﾛｯﾄ№：XXXXXXXXXX
                '@対象装置：XXXXXXXXXX
                '@##########ﾒｰﾙ本文固定表記##########
                '@本文文字列作成
                .strMailContents = CPstrMailEXCPNO & vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpNo) & vbCrLf & _
                                   CPstrMailEXCPNAME & vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColExcpName) & vbCrLf & _
                                   CPstrMailLOT_S & lstrLotAll & vbCrLf & _
                                   CPstrMailWP & vsfExcpList.GetData(vsfExcpList.Row, CMlngvsfColWpName)
            End With
            
            '@引継起動ﾌﾗｸﾞの設定
            pblnfrmxxEN0050kbn = False
            pblnfrmxxEN00V0kbn = True               '工程異常/不適合品処理票 確認依頼
            
            '@引継処理ﾌﾗｸﾞの初期化
            plngfrmxxCM00S0Kbn = 0
            
            '@起動ﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            '@子画面の起動
            frmxxCM00S0.Instance = New frmxxCM00S0()
            
            '@起動区分による処理判別
            If pblnFormLoad = True Then
            '@成功の場合
                '@ﾒｰﾙ送信画面起動
                frmxxCM00S0.Instance.ShowDialog(Me)
                frmxxCM00S0.Instance = Nothing
            Else
            '@失敗の場合
                '@ｱﾝﾛｰﾄﾞ処理
                frmxxCM00S0.Instance = Nothing
                
                '@引継起動ﾌﾗｸﾞの初期化
                pblnfrmxxEN0050kbn = False
                pblnfrmxxEN00V0kbn = False
                
                '@引継処理ﾌﾗｸﾞの初期化
                plngfrmxxCM00S0Kbn = 0
                
                '@起動ﾌﾗｸﾞを戻す
                pblnFormLoad = True
                
                Exit Sub
            End If
            
            '@引継処理ﾌﾗｸﾞから処理分岐
            Select Case plngfrmxxCM00S0Kbn
                Case 2
                '@起動成功＆ﾒｰﾙ送信
                     
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmdMailSendClick)
                    
                    '@引継ぎ構造体にﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝをｾｯﾄ
                    With ptypWorkFlow
                        .strMsgVer = CMstrrep_registworkflowVer
                    End With
                    
                    '@ﾜｰｸﾌﾛｰ登録処理
                    lblnAns = pubblnRepRegistWorkFlow_Ins(ptypWorkFlow)
                    '@結果判定
                    If lblnAns = False Then
                    '@失敗の場合
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdMailSendClick)
                        
                        Exit Sub
                    End If
                    
                    '@ﾒｯｾｰｼﾞ送信【ﾒｰﾙ送信】
                    lblnAns = pubblnGuidSendMessage_Sel(ptypSendMessageList)
                    '@結果取得
                    If lblnAns = True Then
                    '@成功の場合
                        
                        '@表示ﾒｯｾｰｼﾞ変換("<TRM4SI>$$メールの送信を受け付けました。")
                        lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf004S)
                        
                        '@ﾒｯｾｰｼﾞ表示
                        Call pubVsfInfo_Disp(lstrMsg)
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdMailSendClick)
                    
                        '@最新情報に更新
                        Call cmdNowList_Click(sender, e)
                    End If

                Case Else
                '@起動失敗,起動成功＆閉じる,他
                    '@処理なし
            End Select

            '@引継起動ﾌﾗｸﾞの初期化
            pblnfrmxxEN0050kbn = False
            pblnfrmxxEN00V0kbn = False
            
            '@引継処理ﾌﾗｸﾞの初期化
            plngfrmxxCM00S0Kbn = 0
            
            '@起動ﾌﾗｸﾞを戻す
            pblnFormLoad = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMailSend_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtEmpID_Change
    '機　能：起案者ID入力欄
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/11 (Fri) 10:35:11 S.Deguchi
    '更新日：2005/03/11 (Fri) 10:35:11
    '備　考：
    Private Sub txtEmpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtEmpID.Change

        Try
            '@起案者名ｸﾘｱ
            lblEmpName.Text = vbNullString
            
            '@一覧ｸﾘｱ
            prvvsfExcpList_Init()
            
            '@該当件数
            lblLotCnt.Text = vbNullString

            '@現在日時表示
            lblNowDate.Text = vbNullString

            'NSYS 一覧を非活性化
            vsfExcpList.Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtEmpID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtEmpID_Validate
    '機　能：起案者ID確定処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2005/03/11 (Fri) 10:36:01 S.Deguchi
    '更新日：2007/09/05 (Wed) 10:24:19 N.Kojima
    '備　考：
    '　　　：2007/09/05 (Wed) 10:24:19 N.Kojima     ﾌｫｰｶｽ処理を追加。(案件№02158のついで)
    Private Sub txtEmpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtEmpID.Validating

        Dim lstrEmpName             As String               '起案者名
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim blnMovedFocusFlg        As Boolean              'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが自身の処理かTabまたはShift+Tabで発生した場合かのﾌﾗｸﾞ

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@起案者IDが無効の場合
            If txtEmpID.Enabled = False Then
                Exit Sub
            End If
            
            '@起案者IDが入力されている場合
            If txtEmpID.Text <> vbNullString Then
                '@起案者IDの桁ﾁｪｯｸ
                If txtEmpID.NowByte < txtEmpID.ChrMaxByte Then
                    
                    'NSYS フォーカスを移動
                    Call pubSetFocus(txtEmpID)

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003K, CMstrEmpIDTitle)
                    '@"[起案者ID]は7桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    e.Cancel = True

                    '@処理終了
                    Exit Sub
                End If
            
                '@起案者名取得
                lblnAns = pubblnMasEmpName_Sel(CMstrmas_empname_Ver, txtEmpID.Text, lstrEmpName)
                If lblnAns = True Then
                    '@起案者名設定
                    lblEmpName.Text = lstrEmpName

                    'NSYS ActiveControlによるcmdSearch_Click内でのpubSetFocusを実行するかの判定
                    If ActiveControl.Name = txtEmpID.Name Then
                        blnMovedFocusFlg = False
                    Else
                        blnMovedFocusFlg = True
                    End If

                    '@最新取得処理を行う(上記の条件を満たしている場合)
                    Call cmdNowList_Click(sender, e, blnMovedFocusFlg)
                Else
                    'NSYS フォーカスを移動
                    Call pubSetFocus(txtEmpID)

                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                    '@処理終了
                    Exit Sub
                End If
            
            Else
                '@起案者名設定
                lblEmpName.Text = vbNullString
                
        '@↓2007/09/05 (Wed) 10:22:44 N.Kojima **************************************************
                'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが起案者IDの場合のみ
                If ActiveControl.Name = txtEmpID.Name Then
                    '@最新取得ﾎﾞﾀﾝが有効か
                    If cmdNowList.Enabled = True Then
                        '@最新取得ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdNowList)
                    Else
                        '@無効の場合は閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
        '@↑2007/09/05 (Wed) 10:22:44 N.Kojima **************************************************

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtEmpID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtProcEmpID_Change
    '機　能：担当者ID入力欄
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/15 (Thu) 14:01:06 S.Deguchi
    '更新日：2005/09/15 (Thu) 14:01:06
    '備　考：
    Private Sub txtProcEmpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtProcEmpID.Change

        Try
            '@担当者名ｸﾘｱ
            lblProcEmpName.Text = vbNullString
            
            '@一覧ｸﾘｱ
            prvvsfExcpList_Init()
            
            '@該当件数
            lblLotCnt.Text = vbNullString

            '@現在日時表示
            lblNowDate.Text = vbNullString

            'NSYS 一覧を非活性化
            vsfExcpList.Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtProcEmpID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtProcEmpID_Validate
    '機　能：担当者ID確定処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2005/09/15 (Thu) 14:01:06 S.Deguchi
    '更新日：2007/09/05 (Wed) 10:23:47 N.Kojima
    '備　考：
    '　　　：2007/09/05 (Wed) 10:23:47 N.Kojima     ﾌｫｰｶｽ処理を追加。(案件№02158のついで)
    Private Sub txtProcEmpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtProcEmpID.Validating

        Dim lstrEmpName             As String               '担当者名
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@担当者IDが無効の場合
            If txtProcEmpID.Enabled = False Then
                Exit Sub
            End If
            
            '@担当者IDが入力されている場合
            If txtProcEmpID.Text <> vbNullString Then
                '@担当者IDの桁ﾁｪｯｸ
                If txtProcEmpID.NowByte < txtProcEmpID.ChrMaxByte Then
                    
                    'NSYS フォーカスを移動
                    Call pubSetFocus(txtProcEmpID)

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003K, CMstrProcEmpIDTitle)
                    '@"[担当者ID]は7桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    e.Cancel = True
                    '@処理終了
                    Exit Sub
                End If
            
                '@担当者名取得
                lblnAns = pubblnMasEmpName_Sel(CMstrmas_empname_Ver, txtProcEmpID.Text, lstrEmpName)
                If lblnAns = True Then
                    '@担当者名設定
                    lblProcEmpName.Text = lstrEmpName
                
                    '@最新取得処理を行う(上記の条件を満たしている場合)
                    Call cmdNowList_Click(sender, e)
                Else
                    'NSYS フォーカスを移動
                    Call pubSetFocus(txtProcEmpID)

                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                    '@処理終了
                    Exit Sub
                End If
            
            Else
                '@担当者名設定
                lblProcEmpName.Text = vbNullString
                
        '@↓2007/09/05 (Wed) 10:23:42 N.Kojima **************************************************
                'NSYS ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが担当者IDの場合のみ
                If ActiveControl.Name = txtProcEmpID.Name Then
                    '@起票者IDが有効か
                    If txtEmpID.Enabled = True Then
                        '@起票者IDへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtEmpID)
                    Else
                        '@無効の場合は閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
        '@↑2007/09/05 (Wed) 10:23:42 N.Kojima **************************************************

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtProcEmpID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfExcpList_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 18:32:56 S.Deguchi
    '更新日：2004/10/14 (Thu) 17:04:54 S.Deguchi
    '備　考：
    '　　　：2004/10/14 (Thu) 17:04:54 S.Deguchi    ｿｰﾄ順格納を追加
    Private Sub vsfExcpList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfExcpList.AfterSort

        Try
            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfExcpList.BeforeRowColChange, AddressOf vsfExcpList_BeforeRowColChange

            'NSYS ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If vsfExcpListRowBeforeSort <  vsfExcpList.Rows.Fixed Then
                vsfExcpList.Row = 0

                'NSYS ソート前の横スクロール位置を復元
                vsfExcpList.ScrollPosition = New Point(vsfExcpListScrollPositionX, vsfExcpList.ScrollPosition.Y)
            End If

            vsfExcpList.Redraw = True

            'NSYS データ行がない場合は処理を抜ける
            If vsfExcpList.Rows.Count <= vsfExcpList.Rows.Fixed Then
                Return
            End If
            
            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                
                Do While (.typChgSortList.Count < .lngCnt)
                    'NSYS 追加編集
                    Dim tmpChgSortList As ChgSortList = New ChgSortList
                    '@ｿｰﾄ列番号を格納
                    tmpChgSortList.lngCol = e.Col
                    '@並び替え方法を格納(昇順/降順)
                    tmpChgSortList.lngOrder = e.Order

                    .typChgSortList.Add(tmpChgSortList)
                Loop
            End With

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
            Call pubVsfAfterSort(vsfExcpList, CMlngvsfColExcpNo & vbTab & CMlngvsfColEntryTime)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfExcpList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfExcpList_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞ変更処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 16:47:02 S.Deguchi
    '更新日：2004/10/14 (Thu) 16:47:02
    '備　考：
    Private Sub vsfExcpList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfExcpList.BeforeRowColChange
                                                   
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfExcpList.Rows.Count <= vsfExcpList.Rows.Fixed Then
                Return
            End If

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納
                With vsfExcpList
                    mtypChgSort.strKey = .GetData(e.NewRange.r1, CMlngvsfColExcpNo) & _
                                         .GetData(e.NewRange.r1, CMlngvsfColEntryTime)
                End With
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfExcpList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfExcpList_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 18:32:56 S.Deguchi
    '更新日：2004/08/31 (Tue) 18:32:56
    '備　考：
    Private Sub vsfExcpList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfExcpList.BeforeSort

        Try
            'ソートでRowColChangeを発生しないようにする
            RemoveHandler vsfExcpList.BeforeRowColChange, AddressOf vsfExcpList_BeforeRowColChange
            vsfExcpListRowBeforeSort = vsfExcpList.Row                  'NSYS ソート前の選択行を保持
            vsfExcpListScrollPositionX = vsfExcpList.ScrollPosition.X   'NSYS ソート前の横スクロール位置を保持

            vsfExcpList.Redraw = False

            'NSYS データ行がない場合は処理を抜ける
            If vsfExcpList.Rows.Count <= vsfExcpList.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfExcpList, CMlngvsfColExcpNo & vbTab & CMlngvsfColEntryTime)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfExcpList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfExcpList_RowColChange
    '機　能：ｸﾞﾘｯﾄﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 18:32:56 S.Deguchi
    '更新日：2007/12/13 (Thu) 11:11:22 N.Kasai
    '備　考：
    '　　　：2005/03/17 (Thu) 08:46:59 S.Deguchi    未処置の場合にも承認ﾎﾞﾀﾝを使用できなくする
    '　　　：2005/08/01 (Mon) 14:55:17 S.Deguchi    破棄ﾎﾞﾀﾝ処理を追加
    '　　　：2005/09/15 (Thu) 14:07:36 S.Deguchi    確認依頼ﾎﾞﾀﾝ処理を追加
    '　　　：2007/09/04 (Tue) 12:09:34 N.Kojima     ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの制御追加。(案件№02158)
    '　　　：2007/12/13 (Thu) 11:11:22 N.Kasai      承認取消ﾎﾞﾀﾝ追加
    Private Sub vsfExcpList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfExcpList.RowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfExcpList.Rows.Count <= vsfExcpList.Rows.Fixed Then
                
                '@編集ﾎﾞﾀﾝの非活性化
                cmdRegist.Enabled = False
                    
                '@承認ﾎﾞﾀﾝの非活性化
                cmdApply.Enabled = False
                
                '@破棄ﾎﾞﾀﾝの非活性化
                cmdDiscon.Enabled = False
                
                '@確認依頼ﾎﾞﾀﾝの非活性化
                cmdMailSend.Enabled = False

                '@承認取消ﾎﾞﾀﾝの非活性化
                cmdApplyCancel.Enabled = False

                '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの非活性化
                cmdCopy.Enabled = False

                Return
            End If

            With vsfExcpList
                
                '@選択された行がﾀｲﾄﾙ行以外の場合には,編集ﾎﾞﾀﾝの活性化処理を行う
                If .Row <> CMlngVsfRowTitle Then
                    '@編集ﾎﾞﾀﾝの有効化
                    cmdRegist.Enabled = True
                
                    '@選択された行の状態により,承認ﾎﾞﾀﾝの有効化ﾁｪｯｸを行う
                    '@「承認済」か
                    If .GetData(.Row, CMlngvsfColApply) = CMstrApplyFlag Then
                        '@ﾎﾞﾀﾝの無効化
                        cmdApply.Enabled = False        '承認ﾎﾞﾀﾝ
                        cmdDiscon.Enabled = False       '破棄ﾎﾞﾀﾝ
                        cmdMailSend.Enabled = False     '確認依頼ﾎﾞﾀﾝ
                        cmdApplyCancel.Enabled = True   '承認取消ﾎﾞﾀﾝ
                    Else
                        '@「承認済」以外
                    
                        '@「未処置」か
                        If .GetData(.Row, CMlngvsfColApply) = CMstrNoDisposalFlag Then
                            '@承認ﾎﾞﾀﾝを無効にする
                            cmdApply.Enabled = False
                        Else
                            '@「処置済」の場合
                            
                            '@承認ﾎﾞﾀﾝを無効にする
                            cmdApply.Enabled = True
                        End If
                        
                        cmdApplyCancel.Enabled = False  '承認取消ﾎﾞﾀﾝ
                        
                        '@ﾎﾞﾀﾝの有効化
                        cmdDiscon.Enabled = True        '破棄ﾎﾞﾀﾝ
                        cmdMailSend.Enabled = True      '確認依頼ﾎﾞﾀﾝ
                    End If
                Else
                    '@ﾎﾞﾀﾝの無効化
                    cmdRegist.Enabled = False           '編集ﾎﾞﾀﾝ
                    cmdApply.Enabled = False            '承認ﾎﾞﾀﾝ
                    cmdApplyCancel.Enabled = False      '承認取消ﾎﾞﾀﾝ
                    cmdDiscon.Enabled = False           '破棄ﾎﾞﾀﾝ
                    cmdMailSend.Enabled = False         '確認依頼ﾎﾞﾀﾝ
                    cmdCopy.Enabled = False             'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfExcpList_RowColChange"
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

    '関数名：prvfrmxxEN00V0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/27 (Fri) 17:11:50 S.Deguchi
    '更新日：2007/09/04 (Tue) 10:32:56 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 13:40:04 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2005/03/10 (Thu) 15:13:46 S.Deguchi    改造対応
    '　　　：2005/08/01 (Mon) 13:09:51 S.Deguchi    破棄ﾎﾞﾀﾝ処理追加
    '　　　：2005/09/15 (Thu) 13:57:14 S.Deguchi    ﾕｰｻﾞｰ要望№0072　ｸﾞﾘｯﾄﾞに担当者列,検索条件に担当者欄,確認依頼ﾎﾞﾀﾝ追加
    '　　　：2007/09/04 (Tue) 10:32:56 N.Kojima     起票SBｺﾝﾎﾞ追加に伴い、初期化処理追加。(案件№02158)
    Private Sub prvfrmxxEN00V0_Init(ByRef ltypMasSbList As MasSbList)

        Dim lstrFormTitle   As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim lstrNowDate     As String       '日付一時置換格納
    '@↓2007/09/04 (Tue) 10:59:18 N.Kojima **************************************************
        Dim llngSBID        As Integer      '起票SBｲﾝﾃﾞｯｸｽ退避
        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
    '@↑2007/09/04 (Tue) 10:59:18 N.Kojima **************************************************

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00V0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@初期化
            mstrStartDate = vbNullString                                            '開始日
            mstrEndDate = vbNullString                                              '終了日
            mstrSearch = vbNullString                                               '検索条件
        '@↓2007/09/04 (Tue) 18:23:14 N.Kojima **************************************************
            mstrSBID = vbNullString                                                 '起票SB
        '@↑2007/09/04 (Tue) 18:23:14 N.Kojima **************************************************
            mblnExcpFlag = False                                                    '処理ﾌﾗｸﾞ
            
            '@ﾗﾍﾞﾙの初期化
            lblLotCnt.Text = vbNullString                                           '該当件数
            lblNowDate.Text = vbNullString                                          '現在日時表示

            '@起案者欄の初期化
            txtEmpID.Text = vbNullString
            lblEmpName.Text = vbNullString
            
            '@担当者欄の初期化
            txtProcEmpID.Text = vbNullString
            lblProcEmpName.Text = vbNullString
            
            '@ｶﾚﾝﾀﾞｰ設定
            lstrNowDate = Format$(Now, CPstrDateTimeYMD)
            Call pubblnCalendar_Init(calStart, CPlngCalModeTool, lstrNowDate)
            Call pubblnCalendar_Init(calEnd, CPlngCalModeTool, lstrNowDate)
            
            '@検索条件ｺﾝﾎﾞ作成
            With cmbSearch
                .Clear                                                              '初期化
                .DirectInput = False                                                '直接入力不可
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter          '左寄せ中央揃え
                .GroupRows = 4
                
                .AddItem(CMstrALL)                                                  '全て
                .AddItem(CMstrDispose)                                              '未処置
                .AddItem(CMstrNoApply)                                              '処置済
                .AddItem(CMstrApply)                                                '承認済
                
                '@表示「全て」
                .ListIndex = CMlngCmbListIndex2
            End With
            
        '@↓2007/09/04 (Tue) 12:00:59 N.Kojima **************************************************
            '@起票SBｺﾝﾎﾞの初期化＆作成
            With cmbSBID
                .Clear
                .DispCols = CMlngCmbGridCol2                                        'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                       '値取得列
                .GetCol = CMlngCmbValueCol0                                         '表示列
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize)                'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize)    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ColAlignment(CMlngCmbValueCol0) = TextAlignEnum.LeftCenter         '左寄中央揃え
                .ColAlignment(CMlngCmbValueCol1) = TextAlignEnum.LeftCenter         '左寄中央揃え
                .DirectInput = False                                                '直接入力(Flase)
                
                '@起票SBがない場合
                If ltypMasSbList.lngSbListCnt = 0 Then
                    Exit Sub
                End If
                
                '@起票SB = "指定なし"設定
                 .AddItem(CMstrNotAppoint)
                
                '@起票SBがなくなるまで
                For llngCnt = 0 To ltypMasSbList.lngSbListCnt - 1
                    .AddItem(ltypMasSbList.typSbList(llngCnt).strSBName & vbTab & _
                             ltypMasSbList.typSbList(llngCnt).strSbID)             'ｼｽﾃﾑﾌﾞﾛｯｸID&ｼｽﾃﾑﾌﾞﾛｯｸ名
                
                     '@起票SB = 起動SBの場合ﾃﾞﾌｫﾙﾄ表示用Indexを退避する
                    If ltypMasSbList.typSbList(llngCnt).strSbID = pstrSBID Then
                        '@Index退避
                        llngSBID = llngCnt + 1
                    End If
                Next llngCnt
                         
                '@ﾃﾞﾌｫﾙﾄ表示
                .ListIndex = llngSBID
                
            End With
        '@↑2007/09/04 (Tue) 12:00:59 N.Kojima **************************************************
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化
            cmdRegist.Enabled = False                                   '編集ﾎﾞﾀﾝ
            cmdApply.Enabled = False                                    '承認ﾎﾞﾀﾝ
            cmdApplyCancel.Enabled = False                              '承認取消ﾎﾞﾀﾝ
            cmdDiscon.Enabled = False                                   '破棄ﾎﾞﾀﾝ
            cmdMailSend.Enabled = False                                 '確認依頼ﾎﾞﾀﾝ
            cmdNowList.Enabled = True                                   '最新取得ﾎﾞﾀﾝ
            cmdCopy.Enabled = False                                     'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ
            
            '@一覧の初期化
            Call prvvsfExcpList_Init()
            
            '@「閉じる」ﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00V0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfExcpList_Init
    '機　能：異常処理一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/08 (Mon) 14:40:23 S.Deguchi
    '更新日：2005/08/08 (Mon) 14:40:23
    '備　考：
    '　　　：2005/09/15 (Thu) 13:57:14 S.Deguchi    ﾕｰｻﾞｰ要望№0072　依頼先・依頼元担当者/装置/依頼日欄追加
    Private Sub prvvsfExcpList_Init()

        Try

            With vsfExcpList
                .Redraw = False

                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed

                .SelectionMode = SelectionModeEnum.Row
                
                '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                '.FillStyle = flexFillRepeat
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowBigSelection = False
                
                '@ﾏｳｽでｾﾙ範囲選択不可
                .AllowDragging = False
                
                '@ﾌｫﾝﾄｻｲｽﾞ指定(=11)
                '.FontSize = CMlngvsfFontSize

                '@表示しきれない場合の対応(...)
                '.Ellipsis = flexEllipsisEnd
                
                '@ｽｸﾛｰﾙ設定
                .ScrollBars = ScrollBars.Both
                
                '@一覧表の表題設定
                '.Select(CMlngVsfRowTitle, CMlngvsfColNo, CMlngVsfRowTitle, .Cols.Count - 1)
                Dim Ifixedstyle As CellStyle
                Ifixedstyle = .Styles.Add("fixed_style")
                Ifixedstyle.ForeColor = Color.Yellow                                                               '文字色
                Ifixedstyle.BackColor = Color.Navy                                                                 '背景色
                
                'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                With Font
                    Ifixedstyle.Font =New Font(.FontFamily, CMlngvsfFontSize, .Style, .Unit, .GdiCharSet, .GdiVerticalFont)
                End With                                                          

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfColNo, CMstrvsfColNo)                          '№
                .SetData(CMlngVsfRowTitle, CMlngvsfColFlag, CMstrvsfColFlag)                      '異/不
                .SetData(CMlngVsfRowTitle, CMlngvsfColApply, CMstrvsfColApply)                    '適用ﾌﾗｸﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfColEntryTime, CMstrvsfColEntryTime)            '発見日時
                .SetData(CMlngVsfRowTitle, CMlngvsfColProcEmpID, CMstrvsfColProcEmpID)            '担当者ID
                .SetData(CMlngVsfRowTitle, CMlngvsfColProcEmpName, CMstrvsfColProcEmpName)        '担当者名
                .SetData(CMlngVsfRowTitle, CMlngvsfColEmpID, CMstrvsfColEmpID)                    '起案者ID
                .SetData(CMlngVsfRowTitle, CMlngvsfColEmpName, CMstrvsfColEmpName)                '起案者名
                .SetData(CMlngVsfRowTitle, CMlngvsfColExcpName, CMstrvsfColExcpName)              '工程異常名
                .SetData(CMlngVsfRowTitle, CMlngvsfColExcpNo, CMstrvsfColExcpNo)                  '異常処理№
                .SetData(CMlngVsfRowTitle, CMlngvsfColLotID, CMstrvsfColLotID)                    'ﾛｯﾄID
                .SetData(CMlngVsfRowTitle, CMlngvsfColWPID, CMstrvsfColWpID)                      '装置ID
                .SetData(CMlngVsfRowTitle, CMlngvsfColWpName, CMstrvsfColWpName)                  '装置名
                .SetData(CMlngVsfRowTitle, CMlngvsfColFromEmpID, CMstrvsfColFromEmpID)            '依頼元担当者ID
                .SetData(CMlngVsfRowTitle, CMlngvsfColFromEmpName, CMstrvsfColFromEmpName)        '依頼元担当者名
                .SetData(CMlngVsfRowTitle, CMlngvsfColFromEntryTime, CMstrvsfColFromEntryTime)    '依頼日時
                .SetData(CMlngVsfRowTitle, CMlngvsfColEditTime, CMstrvsfColEditTime)              '更新日時
        '@↓2008/09/17 (Wed) T.Inafune No:03121 **************************************************
                .SetData(CMlngVsfRowTitle, CMlngvsfColFindOpID, CMstrvsfColFindOpID)              '大工程
                .SetData(CMlngVsfRowTitle, CMlngvsfColFindStepID, CMstrvsfColFindStepID)          '小工程
                .SetData(CMlngVsfRowTitle, CMlngvsfColDispoName, CMstrvsfColDispoName)            '処置名
                .SetData(CMlngVsfRowTitle, CMlngvsfColDispoWfNum, CMstrvsfColDispoWfNum)          '処置WF数
                .SetData(CMlngVsfRowTitle, CMlngvsfColExcpSitu, CMstrvsfColExcpSitu)              '工程異常発生状況
        '@↑2008/09/17 (Wed) T.Inafune No:03121 **************************************************

                '@列幅設定
                .Cols(CMlngvsfColNo).Width = CMlngvsfWColNo
                .Cols(CMlngvsfColFlag).Width = CMlngvsfWColFlag
                .Cols(CMlngvsfColApply).Width = CMlngvsfWColApply
                .Cols(CMlngvsfColEntryTime).Width = CMlngvsfWColEntryTime
                .Cols(CMlngvsfColProcEmpID).Width = CMlngvsfWColProcEmpID
                .Cols(CMlngvsfColProcEmpName).Width = CMlngvsfWColProcEmpName
                .Cols(CMlngvsfColEmpID).Width = CMlngvsfWColEmpID
                .Cols(CMlngvsfColEmpName).Width = CMlngvsfWColEmpName
                .Cols(CMlngvsfColExcpName).Width = CMlngvsfWColExcpName
                .Cols(CMlngvsfColExcpNo).Width = CMlngvsfWColExcpNo
                .Cols(CMlngvsfColLotID).Width = CMlngvsfWColLotID
                .Cols(CMlngvsfColWPID).Width = CMlngvsfWColWpID
                .Cols(CMlngvsfColWpName).Width = CMlngvsfWColWpName
                .Cols(CMlngvsfColFromEntryTime).Width = CMlngvsfWColFromEntryTime
                .Cols(CMlngvsfColEditTime).Width = CMlngvsfWColEditTime
        '@↓2008/09/17 (Wed) T.Inafune No:03121 **************************************************
                .Cols(CMlngvsfColFindOpID).Width = CMlngvsfWColFindOpID
                .Cols(CMlngvsfColFindStepID).Width = CMlngvsfWColFindStepID
                .Cols(CMlngvsfColDispoName).Width = CMlngvsfWColDispoName
                .Cols(CMlngvsfColDispoWfNum).Width = CMlngvsfWColDispoWfNum
                .Cols(CMlngvsfColExcpSitu).Width = CMlngvsfWColExcpSitu
        '@↑2008/09/17 (Wed) T.Inafune No:03121 **************************************************

                '@非表示設定
                .Cols(CMlngvsfColEmpID).Visible = False                 '起案者ID
                .Cols(CMlngvsfColProcEmpID).Visible = False             '担当者ID
                .Cols(CMlngvsfColWPID).Visible = False                  '装置ID
                .Cols(CMlngvsfColFromEmpID).Visible = False             '依頼元担当者ID
                .Cols(CMlngvsfColFromEmpName).Visible = False           '依頼元担当者名
                .Cols(CMlngvsfColFromEntryTime).Visible = False         '依頼日時
                .Cols(CMlngvsfColEditTime).Visible = False              '更新日時
        '@↓2008/09/17 (Wed) T.Inafune No:03121 **************************************************
        '        .ColHidden(CMlngvsfColFindOpID) = False               '大工程
        '        .ColHidden(CMlngvsfColFindStepID) = False             '小工程
        '        .ColHidden(CMlngvsfColDispoName) = False              '処置名
        '        .ColHidden(CMlngvsfColDispoWfNum) = False             '処置WF数
        '        .ColHidden(CMlngvsfColExcpSitu) = False              '工程異常発生状況
        '@↑2008/09/17 (Wed) T.Inafune No:03121 **************************************************

                '@表示位置の設定(ﾀｲﾄﾙ:中央寄せ中央揃え)

                Dim cellRange As CellRange = .GetCellRange(CMlngvsfRowTitle, CMlngvsfColTitle, .Rows. Count -1, .Cols.Count -1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")                       
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               
                cellRange.Style = headerStyle

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight
                
                .Redraw = True

                '@ﾛｯｸ
                '.Enabled = False
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
        '@↓2007/09/04 (Tue) 16:02:29 N.Kojima **************************************************
                '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝを無効にする
                cmdCopy.Enabled = False
        '@↑2007/09/04 (Tue) 16:02:29 N.Kojima **************************************************
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfExcpList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfExcpList_Disp
    '機　能：異常処理票一覧の表記処理
    '引　数：ltypExcpTroubleList：異常処理一覧格納構造体
    '戻り値：なし
    '作成日：2005/08/08 (Mon) 14:24:14 S.Deguchi
    '更新日：2007/09/04 (Tue) 12:13:02 N.Kojima
    '備　考：
    '　　　：2005/09/15 (Thu) 13:57:14 S.Deguchi    ﾕｰｻﾞｰ要望№0072　担当者/装置欄追加
    '　　　：2007/09/04 (Tue) 12:13:02 N.Kojima     ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの制御追加。(案件№02158)
    Private Sub prvvsfExcpList_Disp(ByRef ltypReportList As ExcpReportList)

        Dim llngDoCnt       As Integer      'ｶｳﾝﾄ
        Dim llngCnt         As Integer      'ﾛｯﾄIDｶｳﾝﾄ
        Dim lstrLotID       As String       'ﾛｯﾄID格納
        Dim lstrProcID      As String       '担当者ID格納
        Dim lstrProcNM      As String       '担当者名格納
        Dim llngHeight      As Integer      'ｽﾛｯﾄ高さ
        Dim llngRowCnt      As Integer      '一行に含まれる行数
        Dim lstrProcNMD     As String       '担当者名格納表示用
        Dim reportListIdx   As Integer      'NSYS
        Dim empListIdx      As Integer      'NSYS
        Dim lotListIdx      As Integer      'NSYS
        
        Try
            'NSYS 不要イベント発生抑止解除
            RemoveHandler vsfExcpList.BeforeRowColChange, AddressOf vsfExcpList_BeforeRowColChange
            RemoveHandler vsfExcpList.RowColChange, AddressOf vsfExcpList_RowColChange
            
            With vsfExcpList

                'NSYS 現在の横スクロール位置を保持
                vsfExcpListScrollPositionX = vsfExcpList.ScrollPosition.X
                
                '@格納ﾃﾞｰﾀがあるか
                If ltypReportList.lngReportListCnt > 0 Then
                
                    '@ｸﾘｱ
                    '.Clear

                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    '@行数設定
                    .Row = -1
                    .Rows.Count = ltypReportList.lngReportListCnt + 1
                    
                    '@工程異常登録内容を表示
                    reportListIdx = 0
                    For llngDoCnt = 1 To ltypReportList.lngReportListCnt
                        '@№設定
                        .SetData(llngDoCnt, CMlngvsfColNo, llngDoCnt)
                        
                        '@工程異常/不適合品を設定
                        If ltypReportList.typReportList(reportListIdx).strDocClass = CMstrTroubleFlag Then
                            .SetData(llngDoCnt, CMlngvsfColFlag, CMstrExcp)
                        Else
                            .SetData(llngDoCnt, CMlngvsfColFlag, CMstrIngong)
                        End If

                        '@発見日時
                        .SetData(llngDoCnt, CMlngvsfColEntryTime, _
                            Format$(CDate(ltypReportList.typReportList(reportListIdx).strFindDate), CPstrDateTimeYMDHM))
                        
                        '@担当者の格納処理
                        lstrProcID = vbNullString                                                       '退避領域初期化
                        lstrProcNM = vbNullString                                                       '退避領域初期化
                        lstrProcNMD = vbNullString                                                      '退避領域初期化
                        
                        If ltypReportList.typReportList(reportListIdx).lnEmpListCnt > 0 Then
                            For empListIdx = 0 To ltypReportList.typReportList(reportListIdx).lnEmpListCnt - 1
                                If empListIdx = 0 Then
                                '@1件目の場合はそのまま変数へ格納
                                    lstrProcID = ltypReportList.typReportList(reportListIdx).typExcpEmpList(empListIdx).strEmpID
                                    
                                    '@担当者名が,13バイト以上の場合か否かで追加処理
                                    If LenB(ltypReportList.typReportList(reportListIdx).typExcpEmpList(empListIdx).strEmpName) > CMlngEmpNameLenB13 Then
                                    '@13Byte以上
                                        lstrProcNM = LeftB(ltypReportList.typReportList(reportListIdx).typExcpEmpList(empListIdx).strEmpName, CMlngEmpNameLenB12)
                                        lstrProcNM = lstrProcNM & CMstrEmpNameLenAfter
                                    Else
                                    '@13Btye以下
                                        lstrProcNM = ltypReportList.typReportList(reportListIdx).typExcpEmpList(empListIdx).strEmpName
                                    End If
                                    
                                    lstrProcNMD = lstrProcNM
                                Else
                                '@2件目以降は変数にｷｬﾘｯｼﾞﾘﾀｰﾝを入れて格納
                                    lstrProcID = lstrProcID _
                                               & vbCrLf _
                                               & ltypReportList.typReportList(reportListIdx).typExcpEmpList(empListIdx).strEmpID
                                    
                                    '@担当者名が,13バイト以上の場合か否かで追加処理
                                    If LenB(ltypReportList.typReportList(reportListIdx).typExcpEmpList(empListIdx).strEmpName) > CMlngEmpNameLenB13 Then
                                    '@13Byte以上
                                        lstrProcNM = LeftB(ltypReportList.typReportList(reportListIdx).typExcpEmpList(empListIdx).strEmpName, CMlngEmpNameLenB12)
                                        lstrProcNM = lstrProcNM & CMstrEmpNameLenAfter
                                    Else
                                    '@13Btye以下
                                        lstrProcNM = ltypReportList.typReportList(reportListIdx).typExcpEmpList(empListIdx).strEmpName
                                    End If
                                    
                                    lstrProcNMD = lstrProcNMD _
                                                & vbCrLf _
                                                & lstrProcNM
                                End If
                            Next empListIdx
                        End If
                        
                        '@担当者ID
                        .SetData(llngDoCnt, CMlngvsfColProcEmpName, lstrProcID)
                        
                        '@担当者名
                        .SetData(llngDoCnt, CMlngvsfColProcEmpName, lstrProcNMD)

                        '@起案者ID
                        .SetData(llngDoCnt, CMlngvsfColEmpID, _
                            ltypReportList.typReportList(reportListIdx).strFindEmpID)
                        
                        '@起案者名
                        .SetData(llngDoCnt, CMlngvsfColEmpName, _
                            ltypReportList.typReportList(reportListIdx).strFindEmpName)
                        
                        '@工程異常名
                        .SetData(llngDoCnt, CMlngvsfColExcpName, _
                            ltypReportList.typReportList(reportListIdx).strExcpItemName)
                        
                        '@異常処理№
                        .SetData(llngDoCnt, CMlngvsfColExcpNo, _
                            ltypReportList.typReportList(reportListIdx).strExcpNo)
                        
                        '@ﾛｯﾄID格納処理
                        lstrLotID = vbNullString                                              '退避領域初期化
                        '@ﾘｽﾄ形式で受けたﾛｯﾄIDを展開する
                        For lotListIdx = 0 To ltypReportList.typReportList(reportListIdx).lngLotListCnt - 1
                            If lotListIdx = 0 Then
                            '@1件目の場合はそのまま変数へ格納
                                lstrLotID = ltypReportList.typReportList(reportListIdx).typExcpLotList(lotListIdx).strLotID
                            Else
                            '@2件目以降は変数にｷｬﾘｯｼﾞﾘﾀｰﾝを入れて格納
                                lstrLotID = lstrLotID _
                                          & vbCrLf _
                                          & ltypReportList.typReportList(reportListIdx).typExcpLotList(lotListIdx).strLotID
                            End If
                        Next lotListIdx
                        .SetData(llngDoCnt, CMlngvsfColLotID, lstrLotID)
                        
                        '@適用ﾌﾗｸﾞ/全処置ﾌﾗｸﾞ判定
                        If ltypReportList.typReportList(reportListIdx).strApprovalFlag = 1 Then
                            .SetData(llngDoCnt, CMlngvsfColApply, CMstrApplyFlag)             '承認済
                        Else
                            If ltypReportList.typReportList(reportListIdx).strAllDisposalFlag = 0 Then
                                .SetData(llngDoCnt, CMlngvsfColApply, CMstrNoDisposalFlag)    '未処置
                            Else
                                .SetData(llngDoCnt, CMlngvsfColApply, CMstrDisposalFlag)      '処置済
                            End If
                        End If
                        
                        '@装置ID
                        .SetData(llngDoCnt, CMlngvsfColWPID, _
                            ltypReportList.typReportList(reportListIdx).strFindWpID)
                        
                        '@装置名
                        .SetData(llngDoCnt, CMlngvsfColWpName, _
                            ltypReportList.typReportList(reportListIdx).strFindWpName)
                        
                        '@依頼元担当者ID
                        .SetData(llngDoCnt, CMlngvsfColFromEmpID, _
                            ltypReportList.typReportList(reportListIdx).strFromEmpID)

                        '@依頼元担当者名
                        .SetData(llngDoCnt, CMlngvsfColFromEmpName, _
                            ltypReportList.typReportList(reportListIdx).strFromEmpName)
                        
                        '@依頼日時
                        .SetData(llngDoCnt, CMlngvsfColFromEntryTime, _
                            ltypReportList.typReportList(reportListIdx).strFromEntryTime)
                        
        '@↓2008/09/17 (Wed) T.Inafune No:03121 **************************************************
                        '@大工程
                        .SetData(llngDoCnt, CMlngvsfColFindOpID, _
                            ltypReportList.typReportList(reportListIdx).strFindOpID)
                            
                        '@小工程
                        .SetData(llngDoCnt, CMlngvsfColFindStepID, _
                            ltypReportList.typReportList(reportListIdx).strFindStepID)
                        
                        '@処置名
                        .SetData(llngDoCnt, CMlngvsfColDispoName, _
                            ltypReportList.typReportList(reportListIdx).strDispoName)
                        
                        '@処置WF数
                        .SetData(llngDoCnt, CMlngvsfColDispoWfNum, _
                            ltypReportList.typReportList(reportListIdx).strDispoWfNum)
                        
                        '@工程異常発生状況
                        .SetData(llngDoCnt, CMlngvsfColExcpSitu, _
                            ltypReportList.typReportList(reportListIdx).strExcpSitu)
                            
        '@↑2008/09/17 (Wed) T.Inafune No:03121 **************************************************

        '@↓2007/12/13 (Thu) 15:14:03 N.Kasai **************************************************
                        '@更新日時
                        .SetData(llngDoCnt, CMlngvsfColEditTime, _
                            ltypReportList.typReportList(reportListIdx).strEditTime)
        '@↑2007/12/13 (Thu) 15:14:03 N.Kasai **************************************************
                       
                        '@1件の異常処理票に含まれるﾛｯﾄと担当者の数を比較する
                        llngRowCnt = 0                                          '初期化
                        If ltypReportList.typReportList(reportListIdx).lnEmpListCnt > _
                           ltypReportList.typReportList(reportListIdx).lngLotListCnt Then
                            '@担当者数を格納
                            llngRowCnt = ltypReportList.typReportList(reportListIdx).lnEmpListCnt
                        Else
                            '@ﾛｯﾄ数を格納
                            llngRowCnt = ltypReportList.typReportList(reportListIdx).lngLotListCnt
                        End If
                        
                        '@ｽﾛｯﾄの高さを設定する
                        If llngRowCnt > 0 Then
                        '@ﾛｯﾄIDが0件以上の場合
                            llngHeight = CMlngVsfHeight * llngRowCnt
                        Else
                        '@ﾛｯﾄIDが0件の場合(本来有りえない)
                            llngHeight = CMlngVsfHHeight
                        End If
                        .Rows(llngDoCnt).Height = llngHeight

                        reportListIdx = reportListIdx + 1

                    Next llngDoCnt
                    
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCols(CMlngvsfColFindOpID, CMlngvsfColDispoWfNum, 6)
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfColNo).TextAlign = TextAlignEnum.RightCenter                     '№
                    .Cols(CMlngvsfColFlag).TextAlign = TextAlignEnum.LeftCenter                    '異/不
                    .Cols(CMlngvsfColApply).TextAlign = TextAlignEnum.LeftCenter                   '承認
                    .Cols(CMlngvsfColEntryTime).TextAlign = TextAlignEnum.LeftCenter               '登録日時
                    .Cols(CMlngvsfColProcEmpID).TextAlign = TextAlignEnum.LeftCenter               '担当者ID
                    .Cols(CMlngvsfColProcEmpName).TextAlign = TextAlignEnum.LeftCenter             '担当者
                    .Cols(CMlngvsfColEmpID).TextAlign = TextAlignEnum.LeftCenter                   '起案者ID
                    .Cols(CMlngvsfColEmpName).TextAlign = TextAlignEnum.LeftCenter                 '起案者
                    .Cols(CMlngvsfColExcpName).TextAlign = TextAlignEnum.LeftCenter                '工程異常名
                    .Cols(CMlngvsfColExcpNo).TextAlign = TextAlignEnum.LeftCenter                  '工程異常№
                    .Cols(CMlngvsfColLotID).TextAlign = TextAlignEnum.LeftCenter                   'ﾛｯﾄID
                    .Cols(CMlngvsfColWpName).TextAlign = TextAlignEnum.LeftCenter                  '装置名
        '@↓2008/09/17 (Wed) T.Inafune No:03121 **************************************************
                    .Cols(CMlngvsfColFindOpID).TextAlign = TextAlignEnum.LeftCenter                '大工程
                    .Cols(CMlngvsfColFindStepID).TextAlign = TextAlignEnum.LeftCenter              '小工程
                    .Cols(CMlngvsfColDispoName).TextAlign = TextAlignEnum.LeftCenter               '処置名
                    .Cols(CMlngvsfColDispoWfNum).TextAlign = TextAlignEnum.RightCenter             '処置WF数
                    .Cols(CMlngvsfColExcpSitu).TextAlign = TextAlignEnum.LeftCenter                '工程異常発生状況
        '@↑2008/09/17 (Wed) T.Inafune No:03121 **************************************************

                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                            '@該当行をｿｰﾄ
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If

                    'NSYS 不要イベント発生抑止解除
                    AddHandler vsfExcpList.BeforeRowColChange, AddressOf vsfExcpList_BeforeRowColChange
                    AddHandler vsfExcpList.RowColChange, AddressOf vsfExcpList_RowColChange
                    
                    '@ｿｰﾄ検索用ｷｰがある場合
                    Dim blnIsSetRow As Boolean = False  'NSYS Rowのｾｯﾄ完了ﾌﾗｸﾞ
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@発見日時と発行№が同じ場合
                            If vsfExcpList.GetData(llngCnt, CMlngvsfColExcpNo) & _
                                vsfExcpList.GetData(llngCnt, CMlngvsfColEntryTime) = _
                                mtypChgSort.strKey Then
                                
                                .Row = llngCnt
                                
                                'NSYS 選択セルをNo.に設定
                                .Col = CMlngvsfColNo

                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                Call pubVsfBeforeSort(vsfExcpList, CMlngvsfColExcpNo & vbTab & CMlngvsfColEntryTime)
                                
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                Call pubVsfAfterSort(vsfExcpList, CMlngvsfColExcpNo & vbTab & CMlngvsfColEntryTime,Nothing,Nothing,True,True,False,False,False)
                                
                                'NSYS Rowのｾｯﾄ完了ﾌﾗｸﾞ
                                blnIsSetRow = True

                                Exit For
                            End If
                        Next llngCnt
                    End If
                    
                    'NSYS Row未ｾｯﾄの場合はﾍｯﾀﾞｰを選択する
                    If blnIsSetRow = False Then
                        .Row = 0
                    End If
                    
        '@↓2007/09/05 (Wed) 10:02:03 N.Kojima **************************************************
        '            '@行列のﾏｳｽでの変更を不可設定にする
        '            .AllowUserResizing =flexResizeNone
                    '@行列のﾏｳｽでの変更可に設定にする
                    .AllowResizing = AllowResizingEnum.Columns
        '@↑2007/09/05 (Wed) 10:02:03 N.Kojima **************************************************
                    
                    'NSYS 退避した横スクロール位置を復元
                    .ScrollPosition = New Point(vsfExcpListScrollPositionX, .ScrollPosition.Y)

                    '@描画ﾛｯｸ解除
                    .Redraw = True
                                
                    '@ﾛｯｸ解除
                    .Enabled = True
                    
        '@↓2007/09/04 (Tue) 12:12:27 N.Kojima **************************************************
                    '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝを有効にする
                    cmdCopy.Enabled = True
        '@↑2007/09/04 (Tue) 12:12:27 N.Kojima **************************************************

                Else
                    '@ｸﾘｱ
                    Call prvvsfExcpList_Init()
                    
                    'NSYS 一覧0件の場合は非活性化
                    vsfExcpList.Enabled = False
                End If
            End With

            '@該当件数
            lblLotCnt.Text = Format$(ltypReportList.lngReportListCnt, CPstrDateFormatKanma)

            '@現在日時表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfExcpList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnExcpList_Sel
    '機　能：異常処理票一覧取得
    '引　数：ltypReportListReq：要求格納構造体
    '　　　：ltypReportList：応答格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2005/08/08 (Mon) 14:23:10 S.Deguchi
    '更新日：2005/08/08 (Mon) 14:23:10
    '備　考：
    Private Function prvblnExcpList_Sel(ByRef ltypReportListReq As ReportListReq, _
                                        ByRef ltypReportList As ExcpReportList) As Boolean


        Dim lblnAns             As Boolean              '結果格納

        Try

            '@初期化
            prvblnExcpList_Sel = False
            
            '@異常処理票一覧情報を取得する
            lblnAns = pubblnExcpReportList_Sel(ltypReportListReq, ltypReportList)

            '@結果判定
            If lblnAns = False Then
                '@失敗の場合には終了
                Exit Function
            Else
                '@成功を返す
                prvblnExcpList_Sel = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnExcpList_Sel"
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfExcpList.BeforeDoubleClick

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
    '機　能 ： 項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles calStart.Enter,
                                                                       calEnd.Enter,
                                                                       cmbSearch.Enter,
                                                                       cmbSBID.Enter,
                                                                       cmdNowList.Enter,
                                                                       txtProcEmpID.Enter,
                                                                       txtEmpID.Enter,
                                                                       vsfExcpList.Enter,
                                                                       cmdClose.Enter,
                                                                       cmdCopy.Enter,
                                                                       cmdMailSend.Enter,
                                                                       cmdDiscon.Enter,
                                                                       cmdApplyCancel.Enter,
                                                                       cmdApply.Enter,
                                                                       cmdRegist.Enter

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
