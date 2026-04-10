'ﾌｧｲﾙ名：xxCM00H0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：工程異常処理票 兼 不適合品処理票　メインフォーム
'作成日：2005/08/02 (Tue) 15:57:18 S.Deguchi
'更新日：2011/05/09 (Mon) 09:41:32 T.Oide
'備　考：改造の為､新規作成
'　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00H0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00H0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00H0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00H0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00H0)
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
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM00H0          'ﾛｰｶﾙ機能ID

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ定数宣言
    '@↓2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    'Private Const CMstrmas_pdlist__Ver              As String = "02.02"                 '機種区分一覧取得
    Private Const CMstrmas_pdlist__Ver              As String = "03.00"                 '機種区分一覧取得
    '@↑2011/05/09 (Mon) 10:14:02 T.Oide **************************************************

    Private Const CMstrmas_wplist__Ver              As String = "05.01"                 '装置一覧取得
    Private Const CMstrmas_useoplistVer             As String = "02.00"                 '大工程ﾏｽﾀ取得
    Private Const CMstrmas_troubleitemlistVer       As String = "01.00"                 '異常処理項目名取得
    Private Const CMstrlot_steplistVer              As String = "03.00"                 '小工程取得
    Private Const CMstrExcpReportInfoVer            As String = "01.00"                 '工程異常/不適合品処理票取得

    '@vsfLotListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfColNo                     As Integer = 0                      '№
    Private Const CMlngvsfColHoldSign               As Integer = 1                      '"保"
    Private Const CMlngvsfColLotID                  As Integer = 2                      'ﾛｯﾄID
    Private Const CMlngvsfColWF                     As Integer = 3                      '対象WF
    Private Const CMlngvsfColHold                   As Integer = 4                      '保留
    Private Const CMlngvsfColReject                 As Integer = 5                      '廃却
    Private Const CMlngvsfColReadjust               As Integer = 6                      '手直し流動
    Private Const CMlngvsfColRevision               As Integer = 7                      '修正流動
    Private Const CMlngvsfColNormal                 As Integer = 8                      '通常流動
    Private Const CMlngvsfColTest                   As Integer = 9                      '評価流動
    Private Const CMlngvsfColSpecial                As Integer = 10                     '特採流動
    Private Const CMlngvsfColTotal                  As Integer = 11                     'WF数
    Private Const CMlngvsfColDispose                As Integer = 12                     '処置
    Private Const CMlngvsfColDisposeFlag            As Integer = 13                     '処置ﾌﾗｸﾞ
    Private Const CMlngvsfColHoldFlag               As Integer = 14                     '保留
    Private Const CMlngvsfColAppend                 As Integer = 15                     '追加
    Private Const CMlngvsfColTarget                 As Integer = 16                     '対象枚数
    Private Const CMlngvsfColLastUpdate             As Integer = 17                     '最終更新日時

    Private Const CMlngvsfToEmpName                 As Integer = 0                      '確認依頼先名

    '@vsfLotListの定数宣言(幅)
    Private Const CMlngvsfWColNo                    As Integer = 57                     '№
    Private Const CMlngvsfWColHoldSign              As Integer = 57                     '"保"
    Private Const CMlngvsfWColLotID                 As Integer = 136                    'ﾛｯﾄID
    Private Const CMlngvsfWColWF                    As Integer = 136                    '対象WF
    Private Const CMlngvsfWColHold                  As Integer = 72                     '保留
    Private Const CMlngvsfWColReject                As Integer = 72                     '廃却
    Private Const CMlngvsfWColReadjust              As Integer = 72                     '手直し流動
    Private Const CMlngvsfWColRevision              As Integer = 72                     '修正流動
    Private Const CMlngvsfWColNormal                As Integer = 72                     '通常流動
    Private Const CMlngvsfWColTest                  As Integer = 72                     '評価流動
    Private Const CMlngvsfWColSpecial               As Integer = 72                     '特採流動
    Private Const CMlngvsfWColTotal                 As Integer = 72                     'WF数
    Private Const CMlngvsfWColDispose               As Integer = 72                     '処置
    Private Const CMlngvsfWColDisposeFlag           As Integer = 72                     '処置ﾌﾗｸﾞ
    Private Const CMlngvsfWColHoldFlag              As Integer = 72                     '保留
    Private Const CMlngvsfWColAppend                As Integer = 72                     '追加
    Private Const CMlngvsfWColTarget                As Integer = 72                     '対象枚数
    Private Const CMlngvsfWColLastUpdate            As Integer = 72                     '最終更新日時

    '@vsfLotListの定数宣言(ｶﾗﾑ)
    Private Const CMstrvsfColNo                     As String = "№"                    '№
    Private Const CMstrvsfColHoldSign               As String = "　"                    '"保"
    Private Const CMstrvsfColLotID                  As String = "ロットID"              'ﾛｯﾄID
    Private Const CMstrvsfColWF                     As String = "　対象　"              '対象WF
    Private Const CMstrvsfColHold                   As String = "　保留　"              '保留
    Private Const CMstrvsfColReject                 As String = "　廃却　"              '廃却
    Private Const CMstrvsfColReadjust               As String = "手直流動"              '手直し流動
    Private Const CMstrvsfColRevision               As String = "修正流動"              '修正流動
    Private Const CMstrvsfColNormal                 As String = "通常流動"              '通常流動
    Private Const CMstrvsfColTest                   As String = "評価流動"              '評価流動
    Private Const CMstrvsfColSpecial                As String = "特採流動"              '特採流動
    Private Const CMstrvsfColTotal                  As String = "合計"                  '合計
    Private Const CMstrvsfColDispose                As String = "処置"                  '処置
    Private Const CMstrvsfColDisposeFlag            As String = "処置ﾌﾗｸﾞ"              '処置ﾌﾗｸﾞ
    Private Const CMstrvsfColHoldFlag               As String = "保留"                  '保留
    Private Const CMstrvsfColAppend                 As String = "追加"                  '追加
    Private Const CMstrvsfColTarget                 As String = "対象"                  '対象枚数
    Private Const CMstrvsfColLastUpdate             As String = "更新"                  '最終更新日時

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                  As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                  As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                 As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfFontSize                  As Integer = 11                     'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                   As Integer = 19                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                    As Integer = 19                     '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfHFontSizeBig              As Integer = 12                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfFontSizeBig               As Integer = 14                     'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfHHeightBig                As Integer = 21                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfHeightBig                 As Integer = 43                     '1ｽﾛｯﾄの高さ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols1                 As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbDispCols2                 As Integer = 2                      'ｸﾞﾘｯﾄﾞ表示列数=2
    Private Const CMlngCmbValueCol1                 As Integer = 1                      '値取得個数=1
    Private Const CMlngCmbValueCol2                 As Integer = 2                      '値取得個数=2
    Private Const CMlngCmbValueCol3                 As Integer = 3                      '値取得個数=3
    Private Const CMlngCmbRowHeight                 As Integer = 22                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                  As Integer = 0                      '名称列番=0
    Private Const CMlngCmbGridCol1                  As Integer = 1                      '名称列番=1
    Private Const CMlngCmbGroupCol                  As Integer = 2                      'ｸﾞﾙｰﾌﾟCol
    Private Const CMlngCmbGroupRow                  As Integer = 0                      'ｸﾞﾙｰﾌﾟRow
    Private Const CMlngCmbGetCol5                   As Integer = 5                      'ﾊﾞｯｸｶﾗｰ格納Col
    Private Const CmlngMaxRows                      As Integer = 25                     '一覧ｺﾝﾎﾞの最大値

    '@Index定数宣言
    Private Const CMlngIndex0                       As Integer = 0                      'Index=0
    Private Const CMlngIndex1                       As Integer = 1                      'Index=1/(１)標準と異なった作業を行なった
    Private Const CMlngIndex2                       As Integer = 2                      '(２)管理図上で異常が発生(連・限界線逸脱・他)
    Private Const CMlngIndex3                       As Integer = 3                      '(３)設備・機械・装置に異常が発生した
    Private Const CMlngIndex4                       As Integer = 4                      '(４)計測器の異常発生、異常を発見
    Private Const CMlngIndex5                       As Integer = 5                      '(５)停電・断水・雷・主要設備故障・火災・他で製品品質に影響
    Private Const CMlngIndex6                       As Integer = 6                      '(６)作業環境の異常：ﾊﾟｰﾃｨｸﾙ・異臭・温湿度・照度他が発生
    Private Const CMlngIndex7                       As Integer = 7                      '(７)その他
    '@↓2017/07/21 (Fri) 11:28:15 Y.Yoneyama **************************************************
    Private Const CMlngIndex8                       As Integer = 8                      '(8)不良率管理値超過による異常発生
    '@↑2017/07/21 (Fri) 11:28:15 Y.Yoneyama **************************************************

    '@TabのIndex定数宣言
    Private Const CMlngssTab1                       As Integer = 0                      '工程異常処置欄1～3
    Private Const CMlngssTab2                       As Integer = 1                      '工程異常処置欄4
    Private Const CMlngssTab3                       As Integer = 2                      '工程異常処置欄5～6
    Private Const CMlngssTab4                       As Integer = 3                      '不適合品処置欄1～2
    Private Const CMlngssTab5                       As Integer = 4                      '不適合品処置欄3～5
    Private Const CMlngssTab6                       As Integer = 5                      '登録情報処置

    '@ﾁｪｯｸのTrue/False定数宣言
    Private Const CMlngchkNoCheck                   As Integer = 0                      '未ﾁｪｯｸ
    Private Const CMlngchkCheck                     As Integer = 1                      'ﾁｪｯｸ済

    '@和名の定数宣言
    Private Const CMstrHoldSign                     As String = "保"                    '保
    Private Const CMstrSumi                         As String = "済"                    '済
    Private Const CMstrlblMisyochi                  As String = "未処置"                '未処置
    Private Const CMstrlblSyochiSumi                As String = "処置決定済"            '処置済
    Private Const CMstrlblSyouninSumi               As String = "承認済"                '承認済
    Private Const CMstrCauseNo                      As String = "原因不明"              '原因不明
    Private Const CMstrTroubleName                  As String = "工程異常処理票"
    Private Const CMstrIncongName                   As String = "不適合品処理票"
    Private Const CMstrBrank                        As String = " "                     'ﾌﾞﾗﾝｸ：半角ｽﾍﾟｰｽ1つ
    Private Const CMstrSrash                        As String = "/"                     'ｽﾗｯｼｭ

    '@単位の定数宣言
    Private Const CMstrtxtUnitWF                    As String = "wf"                    'WF
    Private Const CMstrtxtUnitChip                  As String = "chip"                  'Chip
    Private Const CMstrtxtUnitWFNo                  As String = "1"                     'WF
    Private Const CMstrtxtUnitChipNo                As String = "2"                     'Chip

    '@ﾌﾗｸﾞの定数宣言
    Private Const CMstrCFFlag_WF                    As String = "0"                     'CFﾌﾗｸﾞ：WF(0)
    Private Const CMstrCFFlag_CF                    As String = "1"                     'CFﾌﾗｸﾞ：CF(1)
    Private Const CMstrCFFlag_All                   As String = "2"                     'CFﾌﾗｸﾞ：ALL(2)
    Private Const CMstrIncongFlag0                  As String = "0"                     '不適合品発生有無：無
    Private Const CMstrIncongFlag1                  As String = "1"                     '不適合品発生有無：有
    Private Const CMstrApply                        As String = "1"                     '承認ﾌﾗｸﾞ
    Private Const CMstrEdit                         As String = "0"                     '編集ﾌﾗｸﾞ
    Private Const CMstrHoldFlag                     As String = "1"                     '保留ﾌﾗｸﾞ
    Private Const CMstrWkNo                         As String = "0"                     '未処置
    Private Const CMstrWk                           As String = "1"                     '処置済
    Private Const CMstrItemType0                    As String = "0"                     '原因系列取得用ItemType
    Private Const CMstrItemType4                    As String = "4"                     '原因区分取得用ItemType
    Private Const CMstrConnectApply                 As String = "2"                     '承認済
    Private Const CMstrConnectApplyNo               As String = "1"                     '未承認

    '@その他の定数宣言
    Private Const CMlngTimeFormat16                 As Integer = 16                     '時間ﾌｫｰﾏｯﾄ用定数(YYYY/MM/DD HH:MM:16桁)

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDisp7Row                  As Integer = 7                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ｺﾒﾝﾄ7行入力欄)
    Private Const CMlngMaxDisp4Row                  As Integer = 4                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ｺﾒﾝﾄ4行入力欄)

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mstrSBID                                As String                           '登録時のｼｽﾃﾑﾌﾞﾛｯｸ
    Private mtypExcpReport                          As ExcpReport                       '工程異常/不適合品処理票情報退避構造体
    Private mblnFormLoadFlag                        As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mtypProductList                         As List(Of ProductList)             '機種格納変数
    Private mlngProductListCnt                      As Integer                          '機種格納数
    Private mtypMasOpList                           As MasOpList                        '大工程情報格納
    Private mtypMasStepList                         As MasStepList                      '小工程情報格納
    Private mtypWpList                              As List(Of WpList)                  '装置一覧格納用
    Private mlngWpListCnt                           As Integer                          '装置一覧件数
    Private mtypTroubleItemList1                    As TroubleItemInfo                  '異常処置項目名取得ﾘｽﾄ(系列)
    Private mtypTroubleItemList2                    As TroubleItemInfo                  '異常処置項目名取得ﾘｽﾄ(区分)
    Private mstrOpID                                As String                           '大工程退避領域
    Private mstrStepID                              As String                           '小工程退避領域
    Private mstrWpID                                As String                           '装置ID退避領域
    Private mstrWpName                              As String                           '装置名退避領域
    Private mstrApplyFlag                           As String                           '承認ﾌﾗｸﾞ退避領域
    Private mstrCauseWpID                           As String                           '原因装置ID退避領域
    Private mstrCauseWpName                         As String                           '原因装置名退避領域
    Private mblnEditFlag                            As Boolean                          '編集ﾌﾗｸﾞ
    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                          'NSYS WindowCloseフラグ
    Private mblnTabSelectDisabled                   As Boolean                          'NSYS TabControlの変更許可
    Private mblnMessegeFlag                         As Boolean                          'NSYS メッセージフラグ
    Private vsfLotListRowBeforeSort                 As Integer                          'NSYS ソート直前の選択行
    Private vsfLotListRowBeforeSortScrollPosition   As Point                            'NSYS ソート直前のスクロール位置
    Private mstrOpt3_7umuClickName                  As String                           'NSYS 前回チェックしたオプションボタン名

    Private Sub cmdLotWkCorrect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotWkCorrect.Click

        Dim ltypExcpReportFormat    As ExcpReport           '初期化用構造体
        Dim ltypExcpReport          As ExcpReport           '要求&応答構造体
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns                 As Boolean              '汎用戻り値

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

            '@全ての内容を保存
            Call prvtab1_Set()
            Call prvtab2_Set()
            Call prvtab3_Set()
            Call prvtab4_Set()
            Call prvtab5_Set()
            Call prvtab6_Set()

            '@引継ぎﾌﾗｸﾞをTrue設定
            pblnfrmxxCM00H1Kbn = True
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体の初期化
            ptypExcpReport = ltypExcpReportFormat
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体へ置換
            ptypExcpReport = mtypExcpReport
            
            '@選択ﾛｯﾄを退避
            pstrLotID = vsfLotList.GetData(vsfLotList.Row, CMlngvsfColLotID)
            
            '@子画面の起動
            frmxxCM00H1.Instance = New frmxxCM00H1()
            
            If pblnfrmxxCM00H1Kbn = False Then
                '@子画面をｱﾝﾛｰﾄﾞする
                frmxxCM00H1.Instance = Nothing
                
                '@処理抜け
                Exit Sub
            Else
                '@ﾌｫｰﾑを表示
                frmxxCM00H1.Instance.ShowDialog(Me)
                frmxxCM00H1.Instance = Nothing
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "cmdLotWkCorrect_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@ﾊﾟﾌﾞﾘｯｸの内容をﾓｼﾞｭｰﾙへ変換
            mtypExcpReport = ptypExcpReport
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体の初期化
            ptypExcpReport = ltypExcpReportFormat

            '@要求&応答構造体へ要求情報をｾｯﾄ
            With ltypExcpReport
                .strSbID = mstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strExcpNo = mtypExcpReport.strExcpNo       '異常処理№
                .strMsgVer = CMstrExcpReportInfoVer         'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
            End With
            
            '@工程異常/不適合品処理票一覧情報取得
            lblnAns = pubblnExcpReportInfo_Sel(ltypExcpReport)
            '@結果判定
            If lblnAns = True Then
                '@ﾓｼﾞｭｰﾙ構造体へ情報をｾｯﾄ
                mtypExcpReport = ltypExcpReport
                
                '@表示処理
                Call prvtab6_Disp()
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotWk_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

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
        txtDummy.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
        medFindTimeDisp.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
        medFindTime.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
        Form_Load()

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：Form_Load
    '機　能：起動処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/05 (Fri) 09:58:11 S.Deguchi
    '更新日：2005/08/05 (Fri) 09:58:11
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean              '結果判定
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypExcpReport          As ExcpReport           '要求&応答構造体
        Dim lstrClassDivision       As String               '処理区分
        Dim lstrItemType            As String               '取得ﾀｲﾌﾟ

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
            Call prvfrmxxCM00H0_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸを作成
            mstrSBID = ptypExcpEditList.strSbID
            
            '@要求&応答構造体へ要求情報をｾｯﾄ
            With ltypExcpReport
                .strSbID = mstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strExcpNo = ptypExcpEditList.strExcpNo     '異常処理№
                .strMsgVer = CMstrExcpReportInfoVer         'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
            End With
            
            '@工程異常/不適合品処理票一覧情報取得
            lblnAns = pubblnExcpReportInfo_Sel(ltypExcpReport)
            '@結果判定
            If lblnAns = True Then
                '@ﾓｼﾞｭｰﾙ構造体へ情報をｾｯﾄ
                mtypExcpReport = ltypExcpReport
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose

                Exit Sub
            End If
            
            '@承認ﾌﾗｸﾞをﾓｼﾞｭｰﾙ変数へ退避
            mstrApplyFlag = mtypExcpReport.strApprovalFlag
            
            '@承認済の状態の場合は内容が変更できない為下記の通信は行わない
            '@2) 機種一覧情報取得   (mas_.pdlist__)        : 0.669(s), 画面サイズ指定無/全て
            '@3) 大工程一覧情報取得 (mas_.useoplist)       : 1.346(s), 全て
            '@4) 小工程一覧情報取得 (lot_.steplist)        : 1.188(s), 大工程指定(LOT_TRAVELER全てより)
            '@5) 装置一覧情報取得   (mas_.wplist__)        : 0.171(s), 全て
            '@6) 異常項目情報取得   (mas_.troubleitemlist) : 0.015(s), 原因系列取得

            If mstrApplyFlag <> CMstrApply Then
            
                '@Tab1：工程異常処置欄1～3の情報取得
                '@取得した工程異常/不適合品の構成ﾛｯﾄにより取得する機種を設定する
                Select Case ptypExcpEditList.strCFLotFlag
                    Case CMstrCFFlag_WF
                    '@WFのみ
                        lstrClassDivision = CPstrCD2A & CPstrCD30
                    
                    Case CMstrCFFlag_CF
                    '@CFのみ
                        lstrClassDivision = CPstrCD2A & CPstrCD31
                    
                    Case Else
                    '@全て・その他
            '@↓2007/12/11 (Tue) 11:35:09 N.Kasai **************************************************
            '            lstrClassDivision = CPstrCD2A & CPstrCD02
                        '@製品機種/全て
                        lstrClassDivision = CPstrCD4A & CPstrCD02
            '@↑2007/12/11 (Tue) 11:35:09 N.Kasai **************************************************
                End Select
                '@機種情報取得処理
                lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, lstrClassDivision, _
                                              mtypProductList, _
                                              mlngProductListCnt, _
                                              mstrSBID)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
                
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                    
                    Exit Sub
                End If
                
                '@大工程ﾏｽﾀ取得
                
            '@↓2007/12/11 (Tue) 11:35:03 N.Kasai **************************************************
            '    lstrClassDivision = CPstrCD02
                '@製品機種で使用している大工程
                lstrClassDivision = CPstrCD2T
            '@↑2007/12/11 (Tue) 11:35:03 N.Kasai **************************************************
                
            
                lblnAns = pubblnMasUseOpList_Sel(mstrSBID, _
                                                 CMstrmas_useoplistVer, _
                                                 lstrClassDivision, _
                                                 mtypMasOpList)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
                
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                    
                    Exit Sub
                End If
                
                '@小工程取得
                lblnAns = prvblnLotStepList_Sel(mtypExcpReport.strFindOpID)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
                
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                    
                    Exit Sub
                End If
                
                '@装置一覧取得
                lstrClassDivision = CPstrCD02
                lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, _
                                           mlngWpListCnt, _
                                           mstrSBID, _
                                           lstrClassDivision)
                '@結果判定
                If lblnAns = True Then
                    '@ﾓｼﾞｭｰﾙ構造体へ情報をｾｯﾄ
                    mtypWpList = ptypWPList
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
                
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                    
                    Exit Sub
                End If
                
                '@Tab1：登録情報処置の情報取得
                '@原因系列取得
                lstrItemType = CMstrItemType0
                lblnAns = pubblnMasTroubleItemList_Sel(CMstrmas_troubleitemlistVer, _
                                                       lstrItemType, _
                                                       mtypTroubleItemList1)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                    
                    Exit Sub
                End If
                
                '@原因区分取得
                lstrItemType = CMstrItemType4
                lblnAns = pubblnMasTroubleItemList_Sel(CMstrmas_troubleitemlistVer, _
                                                       lstrItemType, _
                                                       mtypTroubleItemList2)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                    
                    Exit Sub
                End If
            End If

            'ﾀﾌﾞをｵｰﾅｰﾄﾞﾛｰする
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            '引継ﾌﾗｸﾞに成功をｾｯﾄ
            pblnfrmxxCM00H0Kbn = True
            
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
    '関数名：TabControl_DrawItem
    '機　能：tabControlの描画ｲﾍﾞﾝﾄをﾊﾝﾄﾞﾙする
    '引　数：sender：ｲﾍﾞﾝﾄ発行元ｵﾌﾞｼﾞｪｸﾄ
    '　　　：e     ：DrawItemｲﾍﾞﾝﾄ引数
    '戻り値：なし
    Private Sub TabControls_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles tabControl.DrawItem

        Try
            '@対象のTabControlを取得
            Dim lTabControl As TabControl = CType(sender, TabControl)
            '@ﾀﾌﾞﾍﾟｰｼﾞのﾃｷｽﾄを取得
            Dim lstrTabText As String = lTabControl.TabPages(e.Index).Text

            '@書式の設定
            Dim lStringFormat As New StringFormat
            lStringFormat.Alignment = StringAlignment.Center
            lStringFormat.LineAlignment = StringAlignment.Center

            '@ﾀﾌﾞのﾃｷｽﾄと背景描画用のﾌﾞﾗｼ
            Dim lbrsForeBrush, lbrsBackBrush As SolidBrush

            '@不適合品処理票の場合
            If opt3_7umu1.Checked = True Then

                '@ﾀﾌﾞの選択状態によって色付けを変更する
                If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                    '@選択中ﾀﾌﾞの場合
                    lbrsForeBrush = New SolidBrush(Color.Black)
                    lbrsBackBrush = New SolidBrush(Color.White)

                Else
                    '@選択されていないﾀﾌﾞの場合
                    lbrsForeBrush = New SolidBrush(Color.Black)
                    lbrsBackBrush = New SolidBrush(SystemColors.ButtonFace)

                End If
            Else
                If e.Index = CMlngssTab4 orelse e.Index = CMlngssTab5 Then
                    '@不適合品処理票ﾀﾌﾞは使用不可表示
                    lbrsForeBrush = New SolidBrush(Color.Gray)
                    lbrsBackBrush = New SolidBrush(SystemColors.ButtonFace)
                Else
                    If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                    '@選択中ﾀﾌﾞの場合
                    lbrsForeBrush = New SolidBrush(Color.Black)
                    lbrsBackBrush = New SolidBrush(Color.White)

                    Else
                        '@選択されていないﾀﾌﾞの場合
                        lbrsForeBrush = New SolidBrush(Color.Black)
                        lbrsBackBrush = New SolidBrush(SystemColors.ButtonFace)

                    End If
                End If
            End If

            '@背景の描画
            e.Graphics.FillRectangle(lbrsBackBrush, e.Bounds)
            '@ﾃｷｽﾄの描画
            e.Graphics.DrawString(lstrTabText, e.Font, lbrsForeBrush, RectangleF.op_Implicit(e.Bounds), lStringFormat)

            '@確保領域を開放
            lStringFormat.Dispose()
            lbrsForeBrush.Dispose()
            lbrsBackBrush.Dispose()

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "StbRecipe_DrawItem"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/08 (Mon) 17:23:14 S.Deguchi
    '更新日：2005/08/08 (Mon) 17:23:14
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞのよる処理判別
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞ変更
                mblnFormLoadFlag = True
                
                '@機種ｺﾝﾎﾞ情報をｾｯﾄ
                Call prvcmbPdIDList_Disp()
                
                '@大工程ｺﾝﾎﾞ情報をｾｯﾄ
                Call prvcmbOpIDList_Disp()
                
                '@小工程ｺﾝﾎﾞ情報をｾｯﾄ
                Call prvcmbStepIDList_Disp()
                
                '@装置ｺﾝﾎﾞ情報をｾｯﾄ
                Call prvcmbWpIDList_Disp()
                
                '@原因系列Combo作成
                Call prvcmbCauseSeries_Disp()
                
                '@原因区分Combo作成
                Call prvcmbCauseKubun_Disp()
                
                '@原因装置ｺﾝﾎﾞ情報をｾｯﾄ
                Call prvcmbCauseWpIDList_Disp()
                
                '@工程異常/不適合品処理票情報をｾｯﾄ
                Call prvtab1_Disp()
                Call prvtab2_Disp()
                Call prvtab3_Disp()
                Call prvtab4_Disp()
                Call prvtab5_Disp()
                Call prvtab6_Disp()
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
                
                '@適用済みか否かでﾌｫｰｶｽ処理他を変更する
                If mstrApplyFlag = CMstrEdit Then
                    '@初期ﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtTelNo)
                Else
                    '@ﾛｯｸ処理起動
                    Call prvtab1_Lock()
                    Call prvtab2_Lock()
                    Call prvtab3_Lock()
                    Call prvtab4_Lock()
                    Call prvtab5_Lock()
                    Call prvtab6_Lock()
                    
                    '@確定ﾎﾞﾀﾝの非活性化
                    cmdRegist.Enabled = False
                    
                    '@ﾌｫｰｶｽ:Tab
                    Call pubSetFocus(tabControl)
                End If
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
    '作成日：2005/08/05 (Fri) 16:41:58 S.Deguchi
    '更新日：2005/08/05 (Fri) 16:41:58
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
            '@##########ssTab1##########
                Case cmbPdID.Name                                       '機種
                    Select Case e.KeyCode
                        '@Enterの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler cmbPdID.Validating,AddressOf cmbPdID_Validate
                            Call cmbPdID_Validate(sender,New CancelEventArgs(False))
                            AddHandler cmbPdID.Validating,AddressOf cmbPdID_Validate
                    End Select
                    
                Case calFindDate.Name                                   '発見日時(日付)
                    Select Case e.KeyCode
                        '@Enterの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler calFindDate.Validating,AddressOf calFindDate_Validate
                            Call calFindDate_Validate(sender,New CancelEventArgs(False))
                            AddHandler calFindDate.Validating,AddressOf calFindDate_Validate
                            e.Handled = True
                    End Select
                    
                Case medFindTime.Name                                   '発見日時(時間)
                    Select Case e.KeyCode
                        '@Enterの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler medFindTime.Validating,AddressOf medFindTime_Validate
                            Call medFindTime_Validate(sender,New CancelEventArgs(False))
                            AddHandler medFindTime.Validating,AddressOf medFindTime_Validate
                            e.Handled = True
                    End Select
                    
                Case cmbOpID.Name                                       '大工程
                    Select Case e.KeyCode
                        '@Enterの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler cmbOpID.Validating,AddressOf cmbOpID_Validate
                            Call cmbOpID_Validate(sender,New CancelEventArgs(False))
                            AddHandler cmbOpID.Validating,AddressOf cmbOpID_Validate
                    End Select
                
                Case cmbStepID.Name                                     '小工程
                    Select Case e.KeyCode
                        '@Enterの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler cmbStepID.Validating,AddressOf cmbStepID_Validate
                            Call cmbStepID_Validate(sender,New CancelEventArgs(False))
                            AddHandler cmbStepID.Validating,AddressOf cmbStepID_Validate
                    End Select
                
                Case cmbWpID.Name                                       '装置
                    Select Case e.KeyCode
                        '@Enterの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler cmbWpID.Validating,AddressOf cmbWpID_Validate
                            Call cmbWpID_Validate(sender,New CancelEventArgs(False))
                            AddHandler cmbWpID.Validating,AddressOf cmbWpID_Validate
                    End Select
                
                Case txt3_6Comments0.Name                   '3.(6)
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                
                Case txt3_7Comments.Name                                '3.(7)
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                
            '@##########ssTab2##########
                Case txt4Comments0.Name                     '4.技術
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                    
                Case txt4Comments1.Name                     '4.製造
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                    
                Case txt4Comments2.Name                     '4.その他
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                
            '@##########ssTab3##########
                Case txt5Comments0.Name                     '5.技術
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                    
                Case txt5Comments1.Name                     '5.製造
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                    
                Case txt5Comments2.Name                     '5.その他
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                
                Case txt6Comments0.Name                     '6.技術
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                    
                Case txt6Comments1.Name                     '6.製造
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                    
                Case txt6Comments2.Name                     '6.その他
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                
            '@##########ssTab4##########
                Case txt3_6Comments1.Name
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                
                Case txtInc1Comments0.Name                  'Inc1.技術
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                    
                Case txtInc1Comments1.Name                  'Inc1.製造
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                    
                Case txtInc1Comments2.Name                  'Inc1.その他
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                
            '@##########ssTab5##########
                Case txtInc4Comments.Name                               'Inc4
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                
                Case txtInc5Comments.Name                               'Inc5
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                
            '@##########ssTab6##########
                Case cmbCauseKubun.Name                                 '原因区分
                    Select Case e.KeyCode
                        '@Enterの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler cmbCauseKubun.Validating,AddressOf cmbCauseKubun_Validate
                            Call cmbCauseKubun_Validate(sender,New CancelEventArgs(False))
                            AddHandler cmbCauseKubun.Validating,AddressOf cmbCauseKubun_Validate
                    End Select
                
                Case cmbCauseSeries.Name                                '原因系列
                    Select Case e.KeyCode
                        '@Enterの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler cmbCauseSeries.Validating,AddressOf cmbCauseSeries_Validate
                            Call cmbCauseSeries_Validate(sender,New CancelEventArgs(False))
                            AddHandler cmbCauseSeries.Validating,AddressOf cmbCauseSeries_Validate
                    End Select
                    
                Case cmbCauseKubun.Name                                 '原因区分
                    Select Case e.KeyCode
                        '@Enterの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler cmbCauseKubun.Validating,AddressOf cmbCauseKubun_Validate
                            Call cmbCauseKubun_Validate(sender,New CancelEventArgs(False))
                            AddHandler cmbCauseKubun.Validating,AddressOf cmbCauseKubun_Validate
                    End Select
                
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
    '作成日：2005/08/05 (Fri) 16:50:28 S.Deguchi
    '更新日：2005/08/05 (Fri) 16:50:28
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim ltypDepartmentList      As DepartmentInfo       '部署/所属格納構造体
        Dim ltypDeptEmpList         As DeptEmpInfo          'ﾕｰｻﾞ格納構造体
        Dim ltypSendMailList        As SendMailList         '宛先人格納構造体
        Dim ltypMailInfo            As MailInfo             'ﾒｰﾙ送信画面引継ぎ構造体
        Dim ltypExcpReport          As ExcpReport           '引継構造体
    '@↓2005/10/05 (Wed) 08:50:20 S.Deguchi **************************************************
        Dim ltypExcpEditList        As ExcpEdit             '初期化用引継構造体
    '@↑2005/10/05 (Wed) 08:50:20 S.Deguchi **************************************************

        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾓｼﾞｭｰﾙ構造体をｸﾘｱ
            '@ﾒｰﾙ関連一式の構造体をｸﾘｱする。
            ptypDepartmentList = ltypDepartmentList
            ptypDeptEmpList = ltypDeptEmpList
            ptypSendMailList = ltypSendMailList
            ptypMailInfo = ltypMailInfo

            ptypDepartmentList.typDepartmentList = New List(Of DepartmentList)
            ptypDeptEmpList.typDeptEmpList = New List(Of DeptEmpList)
            ptypSendMailList.typSendMail = New List(Of SendMail)

            '@子画面引継に使用した(かもしれない)構造体の初期化
            ptypExcpReport = ltypExcpReport
            
        '@↓2005/10/05 (Wed) 08:50:30 S.Deguchi **************************************************
            '@引継構造体の初期化
            ptypExcpEditList = ltypExcpEditList
        '@↑2005/10/05 (Wed) 08:50:30 S.Deguchi **************************************************
            
            '@ﾓｼﾞｭｰﾙ変数,構造体の初期化
            mtypExcpReport = ltypExcpReport
            mtypProductList = New List(Of ProductList)
            mtypMasOpList.typMasOpId = New List(Of MasOpId)
            mtypWpList = New List(Of WpList)
            mtypMasStepList.typMasStepId = New List(Of MasStepId)
            mtypTroubleItemList1.typTroubleItemList = New List(Of TroubleItemList)
            mtypTroubleItemList2.typTroubleItemList = New List(Of TroubleItemList)
            
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
    '機　能：閉じるﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/17 (Tue) 08:41:29 S.Deguchi
    '更新日：2004/08/17 (Tue) 08:41:29
    '備　考：
    '　　　：2005/03/11 (Fri) 15:41:12 S.Deguchi    内容破棄ﾒｯｾｰｼﾞを削除
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

    '関数名：cmdMail_Click
    '機　能：ﾒｰﾙ送信ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 14:18:31 N.Kasai
    '更新日：2005/05/09 (Mon) 14:18:31
    '備　考：
    '　　　：2005/11/21 (Mon) 10:21:20 S.Deguchi    ﾎﾞﾀﾝが一覧へ移動の為,ｺﾒﾝﾄｱｳﾄ。後に削除
    Private Sub cmdMail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMail.Click
            
    '    Dim lstrLotAll      As String       '対象ﾛｯﾄIDを格納
    '    Dim llngCnt         As Long         '汎用ｶｳﾝﾄ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '    '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
        '    If Screen.MousePointer = vbHourglass Then
        '        Exit Sub
        '    End If
        '
        '    '@ﾒｰﾙ内容取得
        '    '@既に入力済みの場合は再読込みしない
        '    With ptypMailInfo
        '        If .strMailContents & .strMailSubject = vbNullString Then
        '            '@件数判定
        '            If mtypExcpReport.lngExcpReportLotListCnt > 0 Then
        '                '@初期化
        '                lstrLotAll = vbNullString
        '
        '                '@ﾛｯﾄIDを取得する
        '                For llngCnt = 1 To mtypExcpReport.lngExcpReportLotListCnt
        '                    '@複数ﾛｯﾄ判定(複数存在の場合は","表示
        '                    If llngCnt = 1 Then
        '                        lstrLotAll = mtypExcpReport.typExcpLotList(llngCnt).strLotID                        'ﾛｯﾄID
        '                    Else
        '                        lstrLotAll = lstrLotAll & "," & mtypExcpReport.typExcpLotList(llngCnt).strLotID     'ﾛｯﾄID
        '                    End If
        '                Next llngCnt
        '            End If
        '
        '            '@ﾒｰﾙ内容格納
        '            With ptypMailInfo
        '                '@件名文字列作成
        '                .strMailSubject = CPstrMailSendTitleExcp & _
        '                                  Replace(CPstrMailSubjectExcp, "%1", mtypExcpReport.strExcpNo)
        '
        '                '@##########ﾒｰﾙ本文固定表記##########
        '                '@送信者：XXXXXXXXXX
        '                '@発行№：XXXXXXXXXX
        '                '@工程異常名：XXXXXXXXXX
        '                '@対象ロット№：XXXXXXXXXX
        '                '@対象装置：XXXXXXXXXX
        '                '@##########ﾒｰﾙ本文固定表記##########
        '                '@本文文字列作成
        '                .strMailContents = CPstrMailExcpNo & mtypExcpReport.strExcpNo & vbCrLf & _
        '                                   CPstrMailExcpName & mtypExcpReport.strExcpItemName & vbCrLf & _
        '                                   CPstrMailLOT_S & lstrLotAll & vbCrLf & _
        '                                   CPstrMailWP & mtypExcpReport.strFindWpName
        '            End With
        '        End If
        '    End With
        '
        '    '@親ﾌｫｰﾑより起動
        '    pblnfrmxxCM00S0Kbn = True
        '
        '    '@子画面の起動
        '    Call Load(frmxxCM00S0)
        '
        '    '@子画面ﾀｲﾄﾙ変更
        '    frmxxCM00S0.Caption = CPstrSubFormCM00S0
        '
        '    '@ﾒｰﾙ送信画面起動
        '    frmxxCM00S0.Show vbModal
        '
        '    '@親ﾌｫｰﾑより起動初期化
        '    pblnfrmxxCM00S0Kbn = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMail_Click"
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
    '作成日：2005/08/09 (Tue) 10:44:10 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:44:10
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg

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

            '@必須項目入力ﾁｪｯｸ処理
            '@(7)が選択されている場合
            If opt2Excp7.Checked = True Then
                '@ﾃｷｽﾄがNullの場合はﾒｯｾｰｼﾞ表示
                If txt2Comments.Text = vbNullString Then
                    '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005K)
                    
                    '@<TRM5KW>$$工程異常項目で「(７)その他」が選択されています。$必須入力項目ですので入力して下さい。
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽｾｯﾄ
                    If txt2Comments.Enabled = True Then
                        Call pubSetFocus(txt2Comments)
                    End If
                    
                    Exit Sub
                End If
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
            
            '@全てのTabの情報をSet
            Call prvtab1_Set()
            Call prvtab2_Set()
            Call prvtab3_Set()
            Call prvtab4_Set()
            Call prvtab5_Set()
            Call prvtab6_Set()
            
            '@更新者情報をｾｯﾄ
            With mtypExcpReport
                .strEmpID = pstrUserID
                .strEmpName = pstrUserName
            End With

            '@工程異常/不適合品処理票情報登録
            lblnAns = pubblnExcpChgReport_Upd(mtypExcpReport, lstrGuidMsg, lstrGuidMsgCode)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                Exit Sub
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

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            '@登録完了ﾒｯｾｰｼﾞを表示する
            If mtypExcpReport.strIncongFlag = CMstrIncongFlag0 Then
            '@工程異常処理票の場合
                '@表示ﾒｯｾｰｼﾞ変換：<TRM1GI>$$工程異常処理票を登録しました。異常処理№[%1]
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001G, mtypExcpReport.strExcpNo)
            Else
            '@不適合品処理票の場合
                '@表示ﾒｯｾｰｼﾞ変換：<TRM1UI>$$不適合品処理票を登録しました。異常処理№[%1]
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001U, mtypExcpReport.strExcpNo)
            End If
            
            '@成功ﾒｯｾｰｼﾞ表示
            Call pubVsfInfo_Disp(pstrDMsg)

            '@ﾊﾟﾌﾞﾘｯｸ起動変数から処理を分岐
            If pblnfrmxxCM00H0Kbn = True Then
                '@登録ﾌｫｰﾑを閉じる
                Me.Close()
            End If

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

    '関数名：tabControl_Click
    '機　能：ﾀﾌﾞ制御
    '引　数：PreviousTab：ｱｸﾃｨﾌﾞTab
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 10:45:30 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:45:30
    '備　考：
    Private Sub tabControl_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tabControl.SelectedIndexChanged

        Try
            '@編集ﾌﾗｸﾞが立っていない場合処理続行
            If mblnEditFlag = True Then
                Exit Sub
            End If
            
             '@選択ﾀﾌﾞ別処理
            Select Case tabControl.SelectedIndex
                Case CMlngssTab1
                '@工程異常処置欄1-3
                    '@表示処理へ
                    Call prvtab1_Disp()
                    
                    '@表示Tabの変更で登録/更新構造体へ情報を更新する
                    Call prvtab2_Set()
                    Call prvtab3_Set()
                    Call prvtab4_Set()
                    Call prvtab5_Set()
                    Call prvtab6_Set()
                
                    '@承認ﾌﾗｸﾞが立っているか否かで処理分岐
                    If mstrApplyFlag = CMstrEdit Then
                    '@編集可能の場合
                        frassTab1.Enabled = True
                        frassTab2.Enabled = False
                        frassTab3.Enabled = False
                        frassTab4.Enabled = False
                        frassTab5.Enabled = False
                        frassTab6.Enabled = False
                    Else
                    '@承認済みの場合
                        Call prvtab1_Lock()
                        Call prvtab2_Lock()
                        Call prvtab3_Lock()
                        Call prvtab4_Lock()
                        Call prvtab5_Lock()
                        Call prvtab6_Lock()
                        
                        '@確定ﾎﾞﾀﾝ非活性化
                        cmdRegist.Enabled = False
                        
                        Exit Sub
                    End If
            
                Case CMlngssTab2
                '@工程異常処置欄4
                    '@表示処理へ
                    Call prvtab2_Disp()
                
                    '@表示Tabの変更で登録/更新構造体へ情報を更新する
                    Call prvtab1_Set()
                    Call prvtab3_Set()
                    Call prvtab4_Set()
                    Call prvtab5_Set()
                    Call prvtab6_Set()
                
                    '@承認ﾌﾗｸﾞが立っているか否かで処理分岐
                    If mstrApplyFlag = CMstrEdit Then
                    '@編集可能の場合
                        frassTab1.Enabled = False
                        frassTab2.Enabled = True
                        frassTab3.Enabled = False
                        frassTab4.Enabled = False
                        frassTab5.Enabled = False
                        frassTab6.Enabled = False
                    Else
                    '@承認済みの場合
                        Call prvtab1_Lock()
                        Call prvtab2_Lock()
                        Call prvtab3_Lock()
                        Call prvtab4_Lock()
                        Call prvtab5_Lock()
                        Call prvtab6_Lock()
                        
                        '@確定ﾎﾞﾀﾝ非活性化
                        cmdRegist.Enabled = False
                        
                        Exit Sub
                    End If
            
                Case CMlngssTab3
                '@工程異常処置欄5-6
                    '@表示処理へ
                    Call prvtab3_Disp()
                
                    '@表示Tabの変更で登録/更新構造体へ情報を更新する
                    Call prvtab1_Set()
                    Call prvtab2_Set()
                    Call prvtab4_Set()
                    Call prvtab5_Set()
                    Call prvtab6_Set()
                
                    '@承認ﾌﾗｸﾞが立っているか否かで処理分岐
                    If mstrApplyFlag = CMstrEdit Then
                    '@編集可能の場合
                        frassTab1.Enabled = False
                        frassTab2.Enabled = False
                        frassTab3.Enabled = True
                        frassTab4.Enabled = False
                        frassTab5.Enabled = False
                        frassTab6.Enabled = False
                    Else
                    '@承認済みの場合
                        Call prvtab1_Lock()
                        Call prvtab2_Lock()
                        Call prvtab3_Lock()
                        Call prvtab4_Lock()
                        Call prvtab5_Lock()
                        Call prvtab6_Lock()
                        
                        '@確定ﾎﾞﾀﾝ非活性化
                        cmdRegist.Enabled = False
                        
                        Exit Sub
                    End If
            
                Case CMlngssTab4
                '@不適合品処置欄1-2
                    '@表示処理へ
                    Call prvtab4_Disp()
                
                    '@表示Tabの変更で登録/更新構造体へ情報を更新する
                    Call prvtab1_Set()
                    Call prvtab2_Set()
                    Call prvtab3_Set()
                    Call prvtab5_Set()
                    Call prvtab6_Set()
                
                    '@承認ﾌﾗｸﾞが立っているか否かで処理分岐
                    If mstrApplyFlag = CMstrEdit Then
                    '@編集可能の場合
                        frassTab1.Enabled = False
                        frassTab2.Enabled = False
                        frassTab3.Enabled = False
                        frassTab4.Enabled = True
                        frassTab5.Enabled = False
                        frassTab6.Enabled = False
                    Else
                    '@承認済みの場合
                        Call prvtab1_Lock()
                        Call prvtab2_Lock()
                        Call prvtab3_Lock()
                        Call prvtab4_Lock()
                        Call prvtab5_Lock()
                        Call prvtab6_Lock()
                        
                        '@確定ﾎﾞﾀﾝ非活性化
                        cmdRegist.Enabled = False
                        
                        Exit Sub
                    End If
            
                Case CMlngssTab5
                '@不適合品処置欄3-5
                    '@表示処理へ
                    Call prvtab5_Disp()
                
                    '@表示Tabの変更で登録/更新構造体へ情報を更新する
                    Call prvtab1_Set()
                    Call prvtab2_Set()
                    Call prvtab3_Set()
                    Call prvtab4_Set()
                    Call prvtab6_Set()
                
                    '@承認ﾌﾗｸﾞが立っているか否かで処理分岐
                    If mstrApplyFlag = CMstrEdit Then
                    '@編集可能の場合
                        frassTab1.Enabled = False
                        frassTab2.Enabled = False
                        frassTab3.Enabled = False
                        frassTab4.Enabled = False
                        frassTab5.Enabled = True
                        frassTab6.Enabled = False
                    Else
                    '@承認済みの場合
                        Call prvtab1_Lock()
                        Call prvtab2_Lock()
                        Call prvtab3_Lock()
                        Call prvtab4_Lock()
                        Call prvtab5_Lock()
                        Call prvtab6_Lock()
                        
                        '@確定ﾎﾞﾀﾝ非活性化
                        cmdRegist.Enabled = False
                        
                        Exit Sub
                    End If
            
                Case CMlngssTab6
                '@登録情報処置
                    '@表示処理へ
                    Call prvtab6_Disp()
                    
                    '@表示Tabの変更で登録/更新構造体へ情報を更新する
                    Call prvtab1_Set()
                    Call prvtab2_Set()
                    Call prvtab3_Set()
                    Call prvtab4_Set()
                    Call prvtab5_Set()
                    
                    '@承認ﾌﾗｸﾞが立っているか否かで処理分岐
                    If mstrApplyFlag = CMstrEdit Then
                    '@編集可能の場合
                        frassTab1.Enabled = False
                        frassTab2.Enabled = False
                        frassTab3.Enabled = False
                        frassTab4.Enabled = False
                        frassTab5.Enabled = False
                        frassTab6.Enabled = True
                    Else
                    '@承認済みの場合
                        Call prvtab1_Lock()
                        Call prvtab2_Lock()
                        Call prvtab3_Lock()
                        Call prvtab4_Lock()
                        Call prvtab5_Lock()
                        Call prvtab6_Lock()
                        
                        '@確定ﾎﾞﾀﾝ非活性化
                        cmdRegist.Enabled = False
                        
                        Exit Sub
                    End If
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

    '########################################################################################：Tab工程異常処置欄1～3
    '関数名：cmdTrouble_Click
    '機　能：工程異常名取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 11:20:14 S.Deguchi
    '更新日：2005/08/09 (Tue) 11:20:14
    '備　考：
    Private Sub cmdTrouble_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTrouble.Click

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

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@引継ぎのﾊﾟﾌﾞﾘｯｸ変数にﾌｫｰﾑのﾀｲﾄﾙをｾｯﾄ
            pstrExcpName = CPstrSubFormCM00H3T
            
            '@工程異常名変更ﾌｫｰﾑを開く
            frmxxCM00H3.Instance = New frmxxCM00H3()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                
                '@異常の場合は子画面終了
                frmxxCM00H3.Instance = Nothing
                
                Exit Sub
            End If
               
            '@工程異常名変更ﾌｫｰﾑを表示する
            frmxxCM00H3.Instance.ShowDialog(Me)
            frmxxCM00H3.Instance = Nothing
            
            '@取得した工程異常名をﾗﾍﾞﾙにｾｯﾄする
            If pstrExcpName <> vbNullString Then
                lbl1Name.Text = pstrExcpName
            End If

            '@ﾗﾍﾞﾙが空欄以外の場合には次項目へﾌｫｰｶｽｾｯﾄ/空欄はそのまま
            If lbl1Name.Text <> vbNullString Then
                '@次項目にﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTrouble_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：opt2Excp_Click
    '機　能：工程異常項目の選択処理
    '引　数：Index：1～6:選択のみ/7:選択でﾃｷｽﾄを使用可能にする
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 11:21:26 S.Deguchi
    '更新日：2005/08/09 (Tue) 11:21:26
    '備　考：
    Private Sub opt2Excp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles opt2Excp1.CheckedChanged, _
                                                                                     opt2Excp2.CheckedChanged, _
                                                                                     opt2Excp3.CheckedChanged, _
                                                                                     opt2Excp4.CheckedChanged, _
                                                                                     opt2Excp5.CheckedChanged, _
                                                                                     opt2Excp6.CheckedChanged, _
                                                                                     opt2Excp7.CheckedChanged, _
                                                                                     opt2Excp8.CheckedChanged

        Dim llngOptIdx As Integer    'NSYS 選択オプションボタンIndex

        Try
            'NSYS Falseは処理を抜ける
            If sender.checked = False Then
                Exit Sub
            End If

            'NSYS 選択オプションボタンIndexを取得
            If IsNumeric(Strings.Right(sender.name,1)) Then
                llngOptIdx = CLng(Strings.Right(sender.name,1))
            Else
                Exit Sub
            End If

            '@選択されたIndexが「7(その他)」の場合
            If llngOptIdx = CMlngIndex7 Then
                '@入力欄を使用可能にする
                txt2Comments.Enabled = True
                
                '@入力欄のCauseValidationをFalse設定
                txt2Comments.CausesValidation = False

                '@ﾊﾞｯｸｶﾗｰを色変え
                txt2Comments.BackColor = ColorTranslator.FromWin32(&HC0C0FF)
                txt2Comments.GotBackColor = ColorTranslator.FromWin32(&HC0C0FF)
            Else
                '@入力欄をｸﾘｱして,使用不可にする
                txt2Comments.Text = vbNullString
                txt2Comments.Enabled = False
            
                '@入力欄のCauseValidationをTrue設定
                txt2Comments.CausesValidation = True

                '@ﾊﾞｯｸｶﾗｰを色戻し
                txt2Comments.BackColor = ColorTranslator.FromWin32(&H80000005)
                txt2Comments.GotBackColor = ColorTranslator.FromWin32(&H80000005)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "opt2Excp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPdID_CloseUp
    '機　能：機種CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 15:52:48 S.Deguchi
    '更新日：2004/06/14 (Mon) 15:52:48
    '備　考：
    Private Sub cmbPdID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPdID.CloseUp

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            If cmbPdID.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbPdID.Validating,AddressOf cmbPdID_Validate
                Call cmbPdID_Validate(sender,New CancelEventArgs(True))
                AddHandler cmbPdID.Validating,AddressOf cmbPdID_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPdID_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPdID_Validate
    '機　能：機種Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 11:46:32 S.Deguchi
    '更新日：2005/08/09 (Tue) 11:46:32
    '備　考：
    Private Sub cmbPdID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPdID.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@値取得(ﾊﾞｯｸｶﾗｰ値)
            cmbPdID.ValueCol = CMlngCmbGetCol5
            
            If cmbPdID.Value <> vbNullString Then
                '@ﾊﾞｯｸｶﾗｰ反映
                cmbPdID.BackColor = ColorTranslator.FromWin32(cmbPdID.Value)
            Else
                '@ﾊﾞｯｸｶﾗｰ白
                cmbPdID.BackColor = SystemColors.Window
            End If

            '@ﾌｫｰｶｽ処理
            '@発見日時へﾌｫｰｶｽｾｯﾄ
            If ActiveControl.Name = cmbPdID.Name Then
                Call pubSetFocus(calFindDate)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPdID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFindDate_CalendarSelect
    '機　能：発見日時選択
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 11:37:30 S.Deguchi
    '更新日：2005/08/09 (Tue) 11:37:30
    '備　考：
    Private Sub calFindDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calFindDate.CalendarSelect

        Try
            '@日付が選択されている場合
            If calFindDate.Value <> CPstrNullDate Then
                '@Validate処理に飛ぶ
                RemoveHandler calFindDate.Validating,AddressOf calFindDate_Validate
                Call calFindDate_Validate(sender,New CancelEventArgs(True))
                AddHandler calFindDate.Validating,AddressOf calFindDate_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calFindDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFindDate_Validate
    '機　能：発見日時Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 11:37:21 S.Deguchi
    '更新日：2005/08/09 (Tue) 11:37:21
    '備　考：
    Private Sub calFindDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calFindDate.Validating
        
        Dim lstrNowDT As String     '現在日時の退避

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@日付の有効性ﾁｪｯｸ
            
            If pubblnYearRange_Chk(calFindDate.Value) = False Then
                '@日付が入力されていない(空欄)場合
                If calFindDate.Value = CPstrNullDate Then
                    Exit Sub
                End If
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006M)
                '@"発見日時の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                'NSYS メッセージ表示中フラグTrueにしフォーカス移動しない
                mblnMessegeFlag = True
                sender.Focus()
                
                '@発見年月日入力欄にｾｯﾄﾌｫｰｶｽ
                e.Cancel = True
                mblnTabSelectDisabled = False
            Else
                '@現在日付取得
                lstrNowDT = Format$(Now(), CPstrDateTimeYMD)
                '@未来日付の場合
                If Format$(CDate(calFindDate.Value), CPstrDateTimeYMD) > lstrNowDT Then
                   '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                    '@"未来日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    'NSYS メッセージ表示中フラグTrueにしフォーカス移動しない
                    mblnMessegeFlag = True
                    sender.Focus()
                    
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                    mblnTabSelectDisabled = False
                Else
                    '@発見時間にﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = calFindDate.Name Then
                        Call pubSetFocus(medFindTime)
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calFindDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medFindTime_GotFocus
    '機　能：ﾌｫｰｶｽ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 11:34:29 S.Deguchi
    '更新日：2005/08/09 (Tue) 11:34:29
    '備　考：
    Private Sub medFindTime_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles medFindTime.GotFocus

        Try
            '@ﾊｲﾗｲﾄ処理
            Call pubHighlight(medFindTime)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medFindTime_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medFindTime_Validate
    '機　能：受入日時Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 11:27:39 S.Deguchi
    '更新日：2005/08/09 (Tue) 11:27:39
    '備　考：
    Private Sub medFindTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles medFindTime.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@時間の有効性ﾁｪｯｸ
            If IsDate(medFindTime.Text) = False Then
                '@時間入力されていない(空欄)場合
                If Replace(Trim (medFindTime.Text),":",vbNullString) = vbNullString Then
                    Exit Sub
                End If
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006M)
                '@"発見日時の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                'NSYS メッセージ表示中フラグTrueにしフォーカス移動しない
                mblnMessegeFlag = True
                sender.Focus()
                
                '@受入時間入力欄にｾｯﾄﾌｫｰｶｽ
                e.Cancel = True
                mblnTabSelectDisabled = False
            Else
                '@次項目へﾌｫｰｶｽｾｯﾄ
                If vsfLotNo0.Enabled = True Then
                    '@対象ﾛｯﾄ№
                    If ActiveControl.Name = medFindTime.Name Then
                        Call pubSetFocus(vsfLotNo0)
                    End If
                Else
                    '@大工程
                    If ActiveControl.Name = medFindTime.Name Then
                        Call pubSetFocus(cmbOpID)
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medFindTime_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOpID_Change
    '機　能：大工程変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 13:43:17 S.Deguchi
    '更新日：2004/08/25 (Wed) 13:43:17
    '備　考：
    Private Sub cmbOpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOpID.Change

        Try
            '@大工程が変更された場合には,小工程はｸﾘｱする
            If cmbOpID.Text = vbNullString Then
                cmbStepID.Enabled = False
            End If
            
            '@小工程のﾃｷｽﾄをｸﾘｱする
            cmbStepID.Text = vbNullString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOpID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOpID_CloseUp
    '機　能：大工程CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 13:43:20 S.Deguchi
    '更新日：2004/08/25 (Wed) 13:43:20
    '備　考：
    Private Sub cmbOpID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOpID.CloseUp

        Try
            If cmbOpID.Text <> vbNullString Then
                '@大工程Validate処理へ
                RemoveHandler cmbOpID.Validating,AddressOf cmbOpID_Validate
                Call cmbOpID_Validate(sender,New CancelEventArgs(False))
                AddHandler cmbOpID.Validating,AddressOf cmbOpID_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOpID_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOpID_Validate
    '機　能：大工程Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 13:43:22 S.Deguchi
    '更新日：2004/08/25 (Wed) 13:43:22
    '備　考：
    Private Sub cmbOpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbOpID.Validating

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "cmbOpID_Validate"
            
            '@選択されていない場合
            If cmbOpID.Text = vbNullString Then
                If cmbStepID.Enabled = True Then
                    '@小工程へｾｯﾄﾌｫｰｶｽ
                    If ActiveControl.Name = cmbOpID.Name Then
                        Call pubSetFocus(cmbStepID)
                    End if
                Else
                    '@装置
                    If ActiveControl.Name = cmbOpID.Name Then
                        Call pubSetFocus(cmbWpID)
                    End If
                End If
                
                Exit Sub
            Else
                '@小工程ｺﾝﾎﾞﾎﾞｯｸｽ使用可能
                cmbStepID.Enabled = True
            End If
            
            '@小工程ﾘｽﾄ取得(選択されている大工程と退避領域の大工程が異なる場合行う)
            If cmbOpID.Text <> mstrOpID Then
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, lstrEventName)
                
                '@小工程取得
                lblnAns = prvblnLotStepList_Sel(cmbOpID.Text)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
                                
                    Exit Sub
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)

                '@取得した小工程が0件の場合にはﾒｯｾｰｼﾞを表示して使用不可にする
                If mtypMasStepList.lngMasStepCnt = 0 Then
                    '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002P)
                    
                    '@「大工程に対する小工程が存在しません。設定を見直してください。」
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@小工程ｺﾝﾎﾞﾎﾞｯｸｽ使用不可
                    cmbStepID.Enabled = False

                    'NSYS メッセージ表示中フラグTrueにしフォーカス移動しない
                    mblnMessegeFlag = True
                    sender.Focus()
                    
                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                    mblnTabSelectDisabled = False

                    Exit Sub
                Else
                    '@退避領域に値をｾｯﾄ
                    mstrOpID = cmbOpID.Text
                    
                    '@小工程ｺﾝﾎﾞ作成
                    Call prvcmbStepIDList_Disp()
                    
                    '@小工程が1件のみの場合にはﾃｷｽﾄにｾｯﾄする
                    If mtypMasStepList.lngMasStepCnt = 1 Then
                        '@小工程名称をｾｯﾄ
                        cmbStepID.ListIndex = 0
                        
                        '@小工程のValidate処理を動かす
                        RemoveHandler cmbStepID.Validating,AddressOf cmbStepID_Validate
                        Call cmbStepID_Validate(sender,New CancelEventArgs(False))
                        AddHandler cmbStepID.Validating,AddressOf cmbStepID_Validate
                        
                        '@装置へﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = cmbOpID.Name Then
                            Call pubSetFocus(cmbWpID)
                        End If
                    Else
                        If cmbStepID.Enabled = True Then
                            '@小工程へｾｯﾄﾌｫｰｶｽ
                            If ActiveControl.Name = cmbOpID.Name Then
                                Call pubSetFocus(cmbStepID)
                            End If
                        Else
                            '@装置へﾌｫｰｶｽｾｯﾄ
                            If ActiveControl.Name = cmbOpID.Name Then
                                Call pubSetFocus(cmbWpID)
                            End If
                        End If
                    End If
                End If
            Else
                '@退避領域と同じ場合には,ﾌｫｰｶｽ移動
                If cmbStepID.Enabled = True Then
                    '@小工程へｾｯﾄﾌｫｰｶｽ
                    If ActiveControl.Name = cmbOpID.Name Then
                        Call pubSetFocus(cmbStepID)
                    End If
                Else
                    '@装置へﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbOpID.Name Then
                        Call pubSetFocus(cmbWpID)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOpID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStepID_CloseUp
    '機　能：小工程CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 13:44:13 S.Deguchi
    '更新日：2004/08/25 (Wed) 13:44:13
    '備　考：
    Private Sub cmbStepID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStepID.CloseUp

        Try
            If cmbStepID.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbStepID.Validating,AddressOf cmbStepID_Validate
                Call cmbStepID_Validate(sender,new CancelEventArgs(False))
                AddHandler cmbStepID.Validating,AddressOf cmbStepID_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStepID_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStepID_Validate
    '機　能：小工程Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 13:44:15 S.Deguchi
    '更新日：2004/08/25 (Wed) 13:44:15
    '備　考：
    Private Sub cmbStepID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbStepID.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@空欄以外には,情報ｾｯﾄでﾌｫｰｶｽ移動
            If cmbStepID.Text <> vbNullString Then
                '@退避領域に値をｾｯﾄ
                mstrStepID = cmbStepID.Text
            End If
                
            '@装置へﾌｫｰｶｽｾｯﾄ
            If ActiveControl.Name = cmbStepID.Name Then
                Call pubSetFocus(cmbWpID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStepID_Validate"
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
    '作成日：2004/08/25 (Wed) 13:44:13 S.Deguchi
    '更新日：2004/08/25 (Wed) 13:44:13
    '備　考：
    Private Sub cmbWpID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpID.CloseUp

        Try
            If cmbWpID.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbWpID.Validating,AddressOf cmbWpID_Validate
                Call cmbWpID_Validate(sender,new CancelEventArgs(False))
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
    '作成日：2004/08/25 (Wed) 13:44:15 S.Deguchi
    '更新日：2004/08/25 (Wed) 13:44:15
    '備　考：
    Private Sub cmbWpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWpID.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@空欄以外には,情報ｾｯﾄでﾌｫｰｶｽ移動
            If cmbWpID.Text <> vbNullString Then
                '@退避領域に値をｾｯﾄ
                '@装置ID
                cmbWpID.ValueCol = CMlngCmbValueCol1
                mstrWpID = cmbWpID.Value
                
                '@装置名
                mstrWpName = cmbWpID.Text
            End If
                
            '@次項目へﾌｫｰｶｽｾｯﾄ
            If ActiveControl.Name = cmbWpID.Name Then
                Call pubSetFocus(txt3_6Comments0)
            End If

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

    '関数名：cmd3_6Up_Click
    '機　能：次頁改行
    '引　数：Index：0:工程異常処置欄3(6)/1：不適合品処置欄2(6)
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 13:00:48 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:55:18 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:55:18 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmd3_6Up_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd3_6Up0.Click,cmd3_6Up1.Click

        Dim llngObjIdx As Integer    'NSYS 処理コントロール種別

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If
            
        '@↓2005/12/05 (Mon) 13:55:13 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txt3_6Comments(Index))
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP

            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtCmdUp_Proc(txt3_6Comments0, CMlngMaxDisp7Row, cmd3_6Up0, cmd3_6Down0)
                Case CMlngIndex1
                    Call pubtxtCmdUp_Proc(txt3_6Comments1, CMlngMaxDisp7Row, cmd3_6Up1, cmd3_6Down1)
            End Select

        '@↑2005/12/05 (Mon) 13:55:13 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd3_6Up_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmd3_6Down_Click
    '機　能：前頁改行
    '引　数：Index：0:工程異常処置欄3(6)/1：不適合品処置欄2(6)
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 13:00:45 S.Deguchi
    '更新日：2005/12/05 (Mon) 13:56:07 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 13:56:07 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmd3_6Down_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd3_6Down0.Click,cmd3_6Down1.Click

        Dim llngObjIdx As Integer    'NSYS 処理コントロール種別

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

        '@↓2005/12/05 (Mon) 13:56:05 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txt3_6Comments(Index))
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtCmdDown_Proc(txt3_6Comments0, CMlngMaxDisp7Row, cmd3_6Up0, cmd3_6Down0)
                Case CMlngIndex1
                    Call pubtxtCmdDown_Proc(txt3_6Comments1, CMlngMaxDisp7Row, cmd3_6Up1, cmd3_6Down1)
            End Select

        '@↑2005/12/05 (Mon) 13:56:05 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd3_6Down_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt3_6Comments_Change
    '機　能：ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txt3_6Comments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txt3_6Comments0.Change,txt3_6Comments1.Change

        Dim llngObjIdx As Integer    'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If
            
            '@ﾃｷｽﾄ変更処理
            Select llngObjIdx
                Case CMlngIndex0 
                    Call pubtxtChange_Proc(txt3_6Comments0, CMlngMaxDisp7Row, cmd3_6Up0, cmd3_6Down0)
                Case CMlngIndex1
                    Call pubtxtChange_Proc(txt3_6Comments1, CMlngMaxDisp7Row, cmd3_6Up1, cmd3_6Down1)
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt3_6Comments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt3_6Comments_KeyUp
    '機　能：ｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txt3_6Comments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt3_6Comments0.KeyUp,txt3_6Comments1.KeyUp

        Dim llngObjIdx As Integer    'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtKeyUp_Proc(e.KeyCode, txt3_6Comments0, CMlngMaxDisp7Row, cmd3_6Up0, cmd3_6Down0)
                Case CMlngIndex1
                    Call pubtxtKeyUp_Proc(e.KeyCode, txt3_6Comments1, CMlngMaxDisp7Row, cmd3_6Up1, cmd3_6Down1)
            End Select
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt3_6Comments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt3_6Comments_MouseUp
    '機　能：ｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txt3_6Comments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txt3_6Comments0.MouseUp,txt3_6Comments1.MouseUp

        Dim llngObjIdx As Integer    'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            '@ﾃｷｽﾄ変更処理
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtChange_Proc(txt3_6Comments0, CMlngMaxDisp7Row, cmd3_6Up0, cmd3_6Down0, e.Button)
                Case CMlngIndex1
                    Call pubtxtChange_Proc(txt3_6Comments1, CMlngMaxDisp7Row, cmd3_6Up1, cmd3_6Down1, e.Button)
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt3_6Comments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：opt3_7umu_Click
    '機　能：3.(7)不適合品発生有無
    '引　数：Index：0：工程異常処置のみ/1：不適合品処置追加
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 13:06:04 S.Deguchi
    '更新日：2005/08/09 (Tue) 13:06:04
    '備　考：
    Private Sub opt3_7umu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles opt3_7umu0.Click,opt3_7umu1.Click

        Dim llngAns     As Integer      '汎用戻り値
        Dim llngObjIdx  As Integer      'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            'NSYS 同一ラジオボタン選択時は処理をしない
            If sender.Name = mstrOpt3_7umuClickName Then
                Exit Sub
            Else
                mstrOpt3_7umuClickName = sender.Name
            End If
            
            '@編集ﾌﾗｸﾞが立っていない場合処理続行
            If mblnEditFlag = False Then
                '@選択処理で使用可能Tabを制御する
                If llngObjIdx = CMlngIndex0 Then
                '@無を選択した場合
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004Y, CMstrIncongName, CMstrTroubleName)
                    '@"<TRM4YI>不適合品処理票から工程異常処理票へ変更を行います。よろしいですか？"
                    llngAns = publngMsgBox(pstrDMsg & vbCrLf, vbQuestion, Me.Text, True, 16, False)
                    '@ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値判定
                    If llngAns = vbNo Then
                        '@編集ﾌﾗｸﾞを立てる
                        mblnEditFlag = True
                        
                        opt3_7umu1.Checked = True
                        mstrOpt3_7umuClickName= opt3_7umu1.Name 'NSYS チェックONラジオボタン名変更
                        
                        '@編集ﾌﾗｸﾞを戻す
                        mblnEditFlag = False
                        
                        Exit Sub
                    End If
                    
                    '@不適合品処置欄Tabを使用不可にする
                    tabControl.TabPages(CMlngssTab4).Enabled = False        '不適合品処置欄1～2
                    tabControl.TabPages(CMlngssTab5).Enabled = False        '不適合品処置欄3～5

                    'NSYS タブ不適合品処置欄1～2、不適合品処置欄3～5無効
                    mblnTabSelectDisabled = True

					'使用不可タブの見た目を変える
					tabControl.Refresh
                    
                    '@不適合品として登録(更新)した内容をｸﾘｱする
                    Call prvtab4_Clear()
                    Call prvtab5_Clear()
                Else
                '@有を選択した場合
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004Y, CMstrTroubleName, CMstrIncongName)
                    '@"<TRM4YI>工程異常処理票から不適合品処理票へ変更を行います。よろしいですか？"
                    llngAns = publngMsgBox(pstrDMsg & vbCrLf, vbQuestion, Me.Text, True, 16, False)
                    '@ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値判定
                    If llngAns = vbNo Then
                        '@編集ﾌﾗｸﾞを立てる
                        mblnEditFlag = True
                        
                        opt3_7umu0.Checked = True
                        mstrOpt3_7umuClickName = opt3_7umu0.Name 'NSYS チェックONラジオボタン名変更
                        
                        '@編集ﾌﾗｸﾞを戻す
                        mblnEditFlag = False
                        
                        Exit Sub
                    End If
                    
                    '@不適合品処置欄Tabを使用加納にする
                    tabControl.TabPages(CMlngssTab4).Enabled = True         '不適合品処置欄1～2
                    tabControl.TabPages(CMlngssTab5).Enabled = True         '不適合品処置欄3～5

                    'NSYS タブ不適合品処置欄1～2、不適合品処置欄3～5有効
                    mblnTabSelectDisabled = True

					'使用不可タブの見た目を変える
					tabControl.Refresh

                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "opt3_7umu_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmd3_7Up_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 13:00:48 S.Deguchi
    '更新日：2005/08/09 (Tue) 13:00:48
    '備　考：
    Private Sub cmd3_7Up_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd3_7Up.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/12/05 (Mon) 14:19:31 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txt3_7Comments)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txt3_7Comments, CMlngMaxDisp4Row, cmd3_7Up, cmd3_7Down)
        '@↑2005/12/05 (Mon) 14:19:31 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd3_7Up_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmd3_7Down_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 13:00:45 S.Deguchi
    '更新日：2005/12/05 (Mon) 14:21:24 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 14:21:24 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmd3_7Down_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd3_7Down.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 14:21:21 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txt3_7Comments)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txt3_7Comments, CMlngMaxDisp4Row, cmd3_7Up, cmd3_7Down)
        '@↑2005/12/05 (Mon) 14:21:21 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd3_7Down_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt3_7Comments_Change
    '機　能：異常内容詳細ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txt3_7Comments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txt3_7Comments.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txt3_7Comments, CMlngMaxDisp4Row, cmd3_7Up, cmd3_7Down)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt3_7Comments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt3_7Comments_KeyUp
    '機　能：異常内容詳細ｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txt3_7Comments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt3_7Comments.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txt3_7Comments, CMlngMaxDisp4Row, cmd3_7Up, cmd3_7Down)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt3_7Comments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt3_7Comments_MouseUp
    '機　能：異常内容詳細ｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txt3_7Comments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txt3_7Comments.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txt3_7Comments, CMlngMaxDisp4Row, cmd3_7Up, cmd3_7Down, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt3_7Comments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '########################################################################################：Tab工程異常処置欄4
    '関数名：cmd4Up_Click
    '機　能：次頁改行
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:16:34 S.Deguchi
    '更新日：2005/12/05 (Mon) 15:25:57 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 15:25:57 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmd4Up_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd4Up0.Click, cmd4Up1.Click, cmd4Up2.Click

        Dim llngObjIdx  As Integer      'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 15:25:54 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txt4Comments(Index))
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtCmdUp_Proc(txt4Comments0, CMlngMaxDisp4Row, cmd4Up0, cmd4Down0)
                Case CMlngIndex1
                    Call pubtxtCmdUp_Proc(txt4Comments1, CMlngMaxDisp4Row, cmd4Up1, cmd4Down1)
                Case CMlngIndex2
                    Call pubtxtCmdUp_Proc(txt4Comments2, CMlngMaxDisp4Row, cmd4Up2, cmd4Down2)
            End Select
        '@↑2005/12/05 (Mon) 15:25:54 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd4Up_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmd4Down_Click
    '機　能：前頁改行
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:16:29 S.Deguchi
    '更新日：2005/12/05 (Mon) 15:26:58 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 15:26:58 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmd4Down_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd4Down0.Click, cmd4Down1.Click, cmd4Down2.Click

        Dim llngObjIdx  As Integer      'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 15:26:56 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txt4Comments(Index))
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtCmdDown_Proc(txt4Comments0, CMlngMaxDisp4Row, cmd4Up0, cmd4Down0)
                Case CMlngIndex1
                    Call pubtxtCmdDown_Proc(txt4Comments1, CMlngMaxDisp4Row, cmd4Up1, cmd4Down1)
                Case CMlngIndex2
                    Call pubtxtCmdDown_Proc(txt4Comments2, CMlngMaxDisp4Row, cmd4Up2, cmd4Down2)
            End Select
            
        '@↑2005/12/05 (Mon) 15:26:56 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd4Down_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt4Comments_Change
    '機　能：ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txt4Comments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txt4Comments0.Change, txt4Comments1.Change, txt4Comments2.Change

        Dim llngObjIdx  As Integer      'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            '@ﾃｷｽﾄ変更処理
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtChange_Proc(txt4Comments0, CMlngMaxDisp4Row, cmd4Up0, cmd4Down0)
                Case CMlngIndex1
                    Call pubtxtChange_Proc(txt4Comments1, CMlngMaxDisp4Row, cmd4Up1, cmd4Down1)
                Case CMlngIndex2
                    Call pubtxtChange_Proc(txt4Comments2, CMlngMaxDisp4Row, cmd4Up2, cmd4Down2)
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt4Comments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt4Comments_KeyUp
    '機　能：ｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txt4Comments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt4Comments0.KeyUp, txt4Comments1.KeyUp, txt4Comments2.KeyUp

        Dim llngObjIdx  As Integer      'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtKeyUp_Proc(e.KeyCode, txt4Comments0, CMlngMaxDisp4Row, cmd4Up0, cmd4Down0)
                Case CMlngIndex1
                    Call pubtxtKeyUp_Proc(e.KeyCode, txt4Comments1, CMlngMaxDisp4Row, cmd4Up1, cmd4Down1)
                Case CMlngIndex2
                    Call pubtxtKeyUp_Proc(e.KeyCode, txt4Comments2, CMlngMaxDisp4Row, cmd4Up2, cmd4Down2)
            End Select
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt4Comments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt4Comments_MouseUp
    '機　能：ｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txt4Comments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txt4Comments0.MouseUp, txt4Comments1.MouseUp, txt4Comments2.MouseUp

        Dim llngObjIdx  As Integer      'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            '@ﾃｷｽﾄ変更処理
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtChange_Proc(txt4Comments0, CMlngMaxDisp4Row, cmd4Up0, cmd4Down0, e.Button)
                Case CMlngIndex1
                    Call pubtxtChange_Proc(txt4Comments1, CMlngMaxDisp4Row, cmd4Up1, cmd4Down1, e.Button)
                Case CMlngIndex2
                    Call pubtxtChange_Proc(txt4Comments2, CMlngMaxDisp4Row, cmd4Up2, cmd4Down2, e.Button)
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt4Comments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmd4Sign_Click
    '機　能：ｻｲﾝ処理
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：
    '作成日：2005/08/09 (Tue) 17:20:19 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:19
    '備　考：
    Private Sub cmd4Sign_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd4Sign0.Click, cmd4Sign1.Click, cmd4Sign2.Click

        Dim lblnAns         As Boolean          '結果判定
        Dim lstrDateTime    As String           '時間取得
        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

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
            
            '@ｻｲﾝ機能関数へ
            lblnAns = prvblncmdSign_Set(lstrDateTime)
            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@ﾗﾍﾞﾙ/構造体に情報ｾｯﾄ
            With mtypExcpReport
                Select Case lstrBtnIdx
                    Case CMlngIndex0
                    '@技術
                        .strTechInflDate = lstrDateTime             '入力日付
                        .strTechInflEmpID = pstrUserID              '入力担当者ID
                        .strTechInflEmpName = pstrUserName          '入力担当者名
                    
                    Case CMlngIndex1
                    '@製造
                        .strManuInflDate = lstrDateTime             '入力日付
                        .strManuInflEmpID = pstrUserID              '入力担当者ID
                        .strManuInflEmpName = pstrUserName          '入力担当者名
                    
                    Case CMlngIndex2
                    '@その他
                        .strOthrInflDate = lstrDateTime             '入力日付
                        .strOthrInflEmpID = pstrUserID              '入力担当者ID
                        .strOthrInflEmpName = pstrUserName          '入力担当者名
                End Select
            End With

            'NSYS 日付型変換
            Dim lstrDateTmp As String
            If IsDate(lstrDateTime) Then
                lstrDateTmp = Format$(CDate(lstrDateTime), CPstrDateTimeYMD)
            Else
                lstrDateTmp = lstrDateTime
            End If

            CType(Me.frassTab2.Controls("lbl4Sign" & llngObjIdx.ToString), Label).Text = lstrDateTmp & vbCrLf & pstrUserName

            '@ｷｬﾝｾﾙﾎﾞﾀﾝを活性化
            CType(Me.frassTab2.Controls("cmd4Cancel" & llngObjIdx.ToString), Button).Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd4Sign_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmd4Cancel_Click
    '機　能：ｻｲﾝｷｬﾝｾﾙ処理
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:20:06 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:06
    '備　考：
    Private Sub cmd4Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd4Cancel0.Click, cmd4Cancel1.Click, cmd4Cancel2.Click

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾗﾍﾞﾙ/構造体を空欄にする
            With mtypExcpReport
                Select Case llngObjIdx
                    Case CMlngIndex0
                    '@技術
                        .strTechInflDate = vbNullString             '入力日付
                        .strTechInflEmpID = vbNullString            '入力担当者ID
                        .strTechInflEmpName = vbNullString          '入力担当者名
                    
                    Case CMlngIndex1
                    '@製造
                        .strManuInflDate = vbNullString             '入力日付
                        .strManuInflEmpID = vbNullString            '入力担当者ID
                        .strManuInflEmpName = vbNullString          '入力担当者名
                    
                    Case CMlngIndex2
                    '@その他
                        .strOthrInflDate = vbNullString             '入力日付
                        .strOthrInflEmpID = vbNullString            '入力担当者ID
                        .strOthrInflEmpName = vbNullString          '入力担当者名
                End Select
            End With
            CType( Me.frassTab2.Controls("lbl4Sign" & llngObjIdx.ToString), Label).Text = vbNullString
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝを非活性化
            CType( Me.frassTab2.Controls("cmd4Cancel" & llngObjIdx.ToString), Button).Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd4Cancel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '########################################################################################：Tab工程異常処置欄5～6
    '関数名：cmd5Up_Click
    '機　能：次頁改行
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:16:34 S.Deguchi
    '更新日：2005/12/05 (Mon) 16:54:00 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 16:54:00 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmd5Up_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd5Up0.Click, cmd5Up1.Click, cmd5Up2.Click

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 16:53:56 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txt5Comments(Index))
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtCmdUp_Proc(txt5Comments0, CMlngMaxDisp4Row, cmd5Up0, cmd5Down0)
                Case CMlngIndex1
                    Call pubtxtCmdUp_Proc(txt5Comments1, CMlngMaxDisp4Row, cmd5Up1, cmd5Down1)
                Case CMlngIndex2
                    Call pubtxtCmdUp_Proc(txt5Comments2, CMlngMaxDisp4Row, cmd5Up2, cmd5Down2)
            End Select
        '@↑2005/12/05 (Mon) 16:53:56 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd5Up_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmd5Down_Click
    '機　能：前頁改行
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:16:29 S.Deguchi
    '更新日：2005/12/05 (Mon) 16:54:57 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 16:54:57 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmd5Down_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd5Down0.Click, cmd5Down1.Click, cmd5Down2.Click

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 16:54:54 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txt5Comments(Index))
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtCmdDown_Proc(txt5Comments0, CMlngMaxDisp4Row, cmd5Up0, cmd5Down0)
                Case CMlngIndex1
                    Call pubtxtCmdDown_Proc(txt5Comments1, CMlngMaxDisp4Row, cmd5Up1, cmd5Down1)
                Case CMlngIndex2
                    Call pubtxtCmdDown_Proc(txt5Comments2, CMlngMaxDisp4Row, cmd5Up2, cmd5Down2)
            End Select
        '@↑2005/12/05 (Mon) 16:54:54 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd5Down_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt5Comments_Change
    '機　能：ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txt5Comments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txt5Comments0.Change, txt5Comments1.Change, txt5Comments2.Change

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            '@ﾃｷｽﾄ変更処理
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtChange_Proc(txt5Comments0, CMlngMaxDisp4Row, cmd5Up0, cmd5Down0)
                Case CMlngIndex1
                    Call pubtxtChange_Proc(txt5Comments1, CMlngMaxDisp4Row, cmd5Up1, cmd5Down1)
                Case CMlngIndex2
                    Call pubtxtChange_Proc(txt5Comments2, CMlngMaxDisp4Row, cmd5Up2, cmd5Down2)
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt5Comments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt5Comments_KeyUp
    '機　能：ｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txt5Comments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt5Comments0.KeyUp, txt5Comments1.KeyUp, txt5Comments2.KeyUp

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtKeyUp_Proc(e.KeyCode, txt5Comments0, CMlngMaxDisp4Row, cmd5Up0, cmd5Down0)
                Case CMlngIndex1
                    Call pubtxtKeyUp_Proc(e.KeyCode, txt5Comments1, CMlngMaxDisp4Row, cmd5Up1, cmd5Down1)
                Case CMlngIndex2
                    Call pubtxtKeyUp_Proc(e.KeyCode, txt5Comments2, CMlngMaxDisp4Row, cmd5Up2, cmd5Down2)
            End Select
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt5Comments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt5Comments_MouseUp
    '機　能：ｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txt5Comments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txt5Comments0.MouseUp, txt5Comments1.MouseUp, txt5Comments2.MouseUp

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            '@ﾃｷｽﾄ変更処理
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtChange_Proc(txt5Comments0, CMlngMaxDisp4Row, cmd5Up0, cmd5Down0, e.Button)
                Case CMlngIndex1
                    Call pubtxtChange_Proc(txt5Comments1, CMlngMaxDisp4Row, cmd5Up1, cmd5Down1, e.Button)
                Case CMlngIndex2
                    Call pubtxtChange_Proc(txt5Comments2, CMlngMaxDisp4Row, cmd5Up2, cmd5Down2, e.Button)
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt5Comments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：cmd5Sign_Click
    '機　能：ｻｲﾝ処理
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：
    '作成日：2005/08/09 (Tue) 17:20:19 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:19
    '備　考：
    Private Sub cmd5Sign_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd5Sign0.Click, cmd5Sign1.Click, cmd5Sign2.Click

        Dim lblnAns         As Boolean          '結果判定
        Dim lstrDateTime    As String           '時間取得
        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

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
            
            '@ｻｲﾝ機能関数へ
            lblnAns = prvblncmdSign_Set(lstrDateTime)
            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@ﾗﾍﾞﾙ/構造体に情報ｾｯﾄ
            With mtypExcpReport
                Select Case llngObjIdx
                    Case CMlngIndex0
                    '@技術
                        .strTechInvestDate = lstrDateTime           '入力日付
                        .strTechInvestEmpID = pstrUserID            '入力担当者ID
                        .strTechInvestEmpName = pstrUserName        '入力担当者名
                    
                    Case CMlngIndex1
                    '@製造
                        .strManuInvestDate = lstrDateTime           '入力日付
                        .strManuInvestEmpID = pstrUserID            '入力担当者ID
                        .strManuInvestEmpName = pstrUserName        '入力担当者名
                    
                    Case CMlngIndex2
                    '@その他
                        .strOthrInvestDate = lstrDateTime           '入力日付
                        .strOthrInvestEmpID = pstrUserID            '入力担当者ID
                        .strOthrInvestEmpName = pstrUserName        '入力担当者名
                End Select
            End With

            'NSYS 日付型変換
            Dim lstrDateTmp As String
            If IsDate(lstrDateTime) Then
                lstrDateTmp = Format$(CDate(lstrDateTime), CPstrDateTimeYMD)
            Else
                lstrDateTmp = lstrDateTime
            End If

            CType(Me.frassTab3.Controls("lbl5Sign" & llngObjIdx.ToString),Label).Text = lstrDateTmp & vbCrLf & pstrUserName

            '@ｷｬﾝｾﾙﾎﾞﾀﾝを活性化
            CType(Me.frassTab3.Controls("cmd5Cancel" & llngObjIdx.ToString),Button).Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd5Sign_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmd5Cancel_Click
    '機　能：ｻｲﾝｷｬﾝｾﾙ処理
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:20:06 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:06
    '備　考：
    Private Sub cmd5Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd5Cancel0.Click, cmd5Cancel1.Click, cmd5Cancel2.Click

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾗﾍﾞﾙ/構造体を空欄にする
            With mtypExcpReport
                Select Case llngObjIdx
                    Case CMlngIndex0
                    '@技術
                        .strTechInvestDate = vbNullString             '入力日付
                        .strTechInvestEmpID = vbNullString            '入力担当者ID
                        .strTechInvestEmpName = vbNullString          '入力担当者名
                    
                    Case CMlngIndex1
                    '@製造
                        .strManuInvestDate = vbNullString             '入力日付
                        .strManuInvestEmpID = vbNullString            '入力担当者ID
                        .strManuInvestEmpName = vbNullString          '入力担当者名
                    
                    Case CMlngIndex2
                    '@その他
                        .strOthrInvestDate = vbNullString             '入力日付
                        .strOthrInvestEmpID = vbNullString            '入力担当者ID
                        .strOthrInvestEmpName = vbNullString          '入力担当者名
                End Select
            End With

            CType(Me.frassTab3.Controls("lbl5Sign" & llngObjIdx.ToString),Label).Text = vbNullString
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝを非活性化
            CType(Me.frassTab3.Controls("cmd5Cancel" & llngObjIdx.ToString),Button).Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd5Cancel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmd6Up_Click
    '機　能：次頁改行
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:16:34 S.Deguchi
    '更新日：2005/12/05 (Mon) 17:00:24 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 17:00:24 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmd6Up_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd6Up0.Click, cmd6Up1.Click, cmd6Up2.Click

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 16:59:01 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txt6Comments(Index))
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtCmdUp_Proc(txt6Comments0, CMlngMaxDisp4Row, cmd6Up0, cmd6Down0)
                Case CMlngIndex1
                    Call pubtxtCmdUp_Proc(txt6Comments1, CMlngMaxDisp4Row, cmd6Up1, cmd6Down1)
                Case CMlngIndex2
                    Call pubtxtCmdUp_Proc(txt6Comments2, CMlngMaxDisp4Row, cmd6Up2, cmd6Down2)
            End Select
        '@↑2005/12/05 (Mon) 16:59:01 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd6Up_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmd6Down_Click
    '機　能：前頁改行
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:16:29 S.Deguchi
    '更新日：2005/12/05 (Mon) 17:00:01 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 17:00:01 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmd6Down_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd6Down0.Click, cmd6Down1.Click, cmd6Down2.Click

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 16:59:58 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txt6Comments(Index))
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtCmdDown_Proc(txt6Comments0, CMlngMaxDisp4Row, cmd6Up0, cmd6Down0)
                Case CMlngIndex1
                    Call pubtxtCmdDown_Proc(txt6Comments1, CMlngMaxDisp4Row, cmd6Up1, cmd6Down1)
                Case CMlngIndex2
                    Call pubtxtCmdDown_Proc(txt6Comments2, CMlngMaxDisp4Row, cmd6Up2, cmd6Down2)
            End Select
        '@↑2005/12/05 (Mon) 16:59:58 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd6Down_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt6Comments_Change
    '機　能：ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txt6Comments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txt6Comments0.Change, txt6Comments1.Change, txt6Comments2.Change

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If
            
            '@ﾃｷｽﾄ変更処理
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtChange_Proc(txt6Comments0, CMlngMaxDisp4Row, cmd6Up0, cmd6Down0)
                Case CMlngIndex1
                    Call pubtxtChange_Proc(txt6Comments1, CMlngMaxDisp4Row, cmd6Up1, cmd6Down1)
                Case CMlngIndex2
                    Call pubtxtChange_Proc(txt6Comments2, CMlngMaxDisp4Row, cmd6Up2, cmd6Down2)
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt6Comments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt6Comments_KeyUp
    '機　能：ｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txt6Comments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt6Comments0.KeyUp, txt6Comments1.KeyUp, txt6Comments2.KeyUp

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtKeyUp_Proc(e.KeyCode, txt6Comments0, CMlngMaxDisp4Row, cmd6Up0, cmd6Down0)
                Case CMlngIndex1
                    Call pubtxtKeyUp_Proc(e.KeyCode, txt6Comments1, CMlngMaxDisp4Row, cmd6Up1, cmd6Down1)
                Case CMlngIndex2
                    Call pubtxtKeyUp_Proc(e.KeyCode, txt6Comments2, CMlngMaxDisp4Row, cmd6Up2, cmd6Down2)
            End Select
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt6Comments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txt6Comments_MouseUp
    '機　能：ｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txt6Comments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txt6Comments0.MouseUp, txt6Comments1.MouseUp, txt6Comments2.MouseUp

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            '@ﾃｷｽﾄ変更処理
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtChange_Proc(txt6Comments0, CMlngMaxDisp4Row, cmd6Up0, cmd6Down0, e.Button)
                Case CMlngIndex1
                    Call pubtxtChange_Proc(txt6Comments1, CMlngMaxDisp4Row, cmd6Up1, cmd6Down1, e.Button)
                Case CMlngIndex2
                    Call pubtxtChange_Proc(txt6Comments2, CMlngMaxDisp4Row, cmd6Up2, cmd6Down2, e.Button)
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txt6Comments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmd6Sign_Click
    '機　能：ｻｲﾝ処理
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：
    '作成日：2005/08/09 (Tue) 17:20:19 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:19
    '備　考：
    Private Sub cmd6Sign_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd6Sign0.Click, cmd6Sign1.Click, cmd6Sign2.Click

        Dim lblnAns         As Boolean          '結果判定
        Dim lstrDateTime    As String           '時間取得
        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

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
            
            '@ｻｲﾝ機能関数へ
            lblnAns = prvblncmdSign_Set(lstrDateTime)
            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@ﾗﾍﾞﾙ/構造体に情報ｾｯﾄ
            With mtypExcpReport
                Select Case llngObjIdx
                    Case CMlngIndex0
                    '@技術
                        .strTechIndicateDate = lstrDateTime             '入力日付
                        .strTechIndicateEmpID = pstrUserID              '入力担当者ID
                        .strTechIndicateEmpName = pstrUserName          '入力担当者名
                    
                    Case CMlngIndex1
                    '@製造
                        .strManuIndicateDate = lstrDateTime             '入力日付
                        .strManuIndicateEmpID = pstrUserID              '入力担当者ID
                        .strManuIndicateEmpName = pstrUserName          '入力担当者名
                    
                    Case CMlngIndex2
                    '@その他
                        .strOthrIndicateDate = lstrDateTime             '入力日付
                        .strOthrIndicateEmpID = pstrUserID              '入力担当者ID
                        .strOthrIndicateEmpName = pstrUserName          '入力担当者名
                End Select
            End With

            'NSYS 日付型変換
            Dim lstrDateTmp As String
            If IsDate(lstrDateTime) Then
                lstrDateTmp = Format$(CDate(lstrDateTime), CPstrDateTimeYMD)
            Else
                lstrDateTmp = lstrDateTime
            End If

            CType(Me.frassTab3.Controls("lbl6Sign" & llngObjIdx.ToString),Label).Text = lstrDateTmp & vbCrLf & pstrUserName

            '@ｷｬﾝｾﾙﾎﾞﾀﾝを活性化
            CType(Me.frassTab3.Controls("cmd6Cancel" & llngObjIdx.ToString),Button).Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd6Sign_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmd6Cancel_Click
    '機　能：ｻｲﾝｷｬﾝｾﾙ処理
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:20:06 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:06
    '備　考：
    Private Sub cmd6Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd6Cancel0.Click, cmd6Cancel1.Click, cmd6Cancel2.Click

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾗﾍﾞﾙ/構造体を空欄にする
            With mtypExcpReport
                Select Case llngObjIdx
                    Case CMlngIndex0
                    '@技術
                        .strTechIndicateDate = vbNullString             '入力日付
                        .strTechIndicateEmpID = vbNullString            '入力担当者ID
                        .strTechIndicateEmpName = vbNullString          '入力担当者名
                    
                    Case CMlngIndex1
                    '@製造
                        .strManuIndicateDate = vbNullString             '入力日付
                        .strManuIndicateEmpID = vbNullString            '入力担当者ID
                        .strManuIndicateEmpName = vbNullString          '入力担当者名
                    
                    Case CMlngIndex2
                    '@その他
                        .strOthrIndicateDate = vbNullString             '入力日付
                        .strOthrIndicateEmpID = vbNullString            '入力担当者ID
                        .strOthrIndicateEmpName = vbNullString          '入力担当者名
                End Select
            End With
            CType(Me.frassTab3.Controls("lbl6Sign" & llngObjIdx.ToString),Label).Text = vbNullString
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝを非活性化
            CType(Me.frassTab3.Controls("cmd6Cancel" & llngObjIdx.ToString),Button).Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd6Cancel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '########################################################################################：Tab不適合品処置欄1～2
    '関数名：cmdIncong_Click
    '機　能：不良特性名取得
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 09:22:42 S.Deguchi
    '更新日：2005/08/10 (Wed) 09:22:42
    '備　考：
    Private Sub cmdIncong_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdIncong.Click

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

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@引継ぎのﾊﾟﾌﾞﾘｯｸ変数にﾌｫｰﾑのﾀｲﾄﾙをｾｯﾄ
            pstrExcpName = CPstrSubFormCM00H3I
            
            '@工程異常名変更ﾌｫｰﾑを開く
            frmxxCM00H3.Instance = New frmxxCM00H3()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                
                '@異常の場合は子画面終了
                frmxxCM00H3.Instance = Nothing
                
                Exit Sub
            End If
               
            '@工程異常名変更ﾌｫｰﾑを表示する
            frmxxCM00H3.Instance.ShowDialog(Me)
            frmxxCM00H3.Instance = Nothing
            
            '@取得した工程異常名をﾗﾍﾞﾙにｾｯﾄする
            If pstrExcpName <> vbNullString Then
                lblIncName.Text = pstrExcpName
            End If

            '@ﾗﾍﾞﾙが空欄以外の場合には次項目へﾌｫｰｶｽｾｯﾄ/空欄はそのまま
            If lblIncName.Text <> vbNullString Then
                '@次項目にﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdIncong_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdInc1Up_Click
    '機　能：次頁改行
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:16:34 S.Deguchi
    '更新日：2005/12/05 (Mon) 17:11:44 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 17:11:44 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdInc1Up_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInc1Up0.Click, cmdInc1Up1.Click, cmdInc1Up2.Click

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 17:12:36 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtInc1Comments(Index))
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtCmdUp_Proc(txtInc1Comments0, CMlngMaxDisp4Row, cmdInc1Up0, cmdInc1Down0)
                Case CMlngIndex1
                    Call pubtxtCmdUp_Proc(txtInc1Comments1, CMlngMaxDisp4Row, cmdInc1Up1, cmdInc1Down1)
                Case CMlngIndex2
                    Call pubtxtCmdUp_Proc(txtInc1Comments2, CMlngMaxDisp4Row, cmdInc1Up2, cmdInc1Down2)
            End Select
        '@↑2005/12/05 (Mon) 17:12:36 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdInc1Up_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdInc1Down_Click
    '機　能：前頁改行
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:16:29 S.Deguchi
    '更新日：2005/12/05 (Mon) 17:12:01 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 17:12:01 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdInc1Down_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInc1Down0.Click, cmdInc1Down1.Click, cmdInc1Down2.Click

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 17:13:30 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtInc1Comments(Index))
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtCmdDown_Proc(txtInc1Comments0, CMlngMaxDisp4Row, cmdInc1Up0, cmdInc1Down0)
                Case CMlngIndex1
                    Call pubtxtCmdDown_Proc(txtInc1Comments1, CMlngMaxDisp4Row, cmdInc1Up1, cmdInc1Down1)
                Case CMlngIndex2
                    Call pubtxtCmdDown_Proc(txtInc1Comments2, CMlngMaxDisp4Row, cmdInc1Up2, cmdInc1Down2)
            End Select
        '@↑2005/12/05 (Mon) 17:13:30 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdInc1Down_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtInc1Comments_Change
    '機　能：ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtInc1Comments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtInc1Comments0.Change, txtInc1Comments1.Change, txtInc1Comments2.Change

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If
            
            '@ﾃｷｽﾄ変更処理
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtChange_Proc(txtInc1Comments0, CMlngMaxDisp4Row, cmdInc1Up0, cmdInc1Down0)
                Case CMlngIndex1
                    Call pubtxtChange_Proc(txtInc1Comments1, CMlngMaxDisp4Row, cmdInc1Up1, cmdInc1Down1)
                Case CMlngIndex2
                    Call pubtxtChange_Proc(txtInc1Comments2, CMlngMaxDisp4Row, cmdInc1Up2, cmdInc1Down2)
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInc1Comments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtInc1Comments_KeyUp
    '機　能：ｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtInc1Comments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtInc1Comments0.KeyUp, txtInc1Comments1.KeyUp, txtInc1Comments2.KeyUp

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtKeyUp_Proc(e.KeyCode, txtInc1Comments0, CMlngMaxDisp4Row, cmdInc1Up0, cmdInc1Down0)
                Case CMlngIndex1
                    Call pubtxtKeyUp_Proc(e.KeyCode, txtInc1Comments1, CMlngMaxDisp4Row, cmdInc1Up1, cmdInc1Down1)
                Case CMlngIndex2
                    Call pubtxtKeyUp_Proc(e.KeyCode, txtInc1Comments2, CMlngMaxDisp4Row, cmdInc1Up2, cmdInc1Down2)
            End Select
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInc1Comments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtInc1Comments_MouseUp
    '機　能：ｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txtInc1Comments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtInc1Comments0.MouseUp, txtInc1Comments1.MouseUp, txtInc1Comments2.MouseUp

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            '@ﾃｷｽﾄ変更処理
            Select llngObjIdx
                Case CMlngIndex0
                    Call pubtxtChange_Proc(txtInc1Comments0, CMlngMaxDisp4Row, cmdInc1Up0, cmdInc1Down0, e.Button)
                Case CMlngIndex1
                    Call pubtxtChange_Proc(txtInc1Comments1, CMlngMaxDisp4Row, cmdInc1Up1, cmdInc1Down1, e.Button)
                Case CMlngIndex2
                    Call pubtxtChange_Proc(txtInc1Comments2, CMlngMaxDisp4Row, cmdInc1Up2, cmdInc1Down2, e.Button)
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInc1Comments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdInc1Sign_Click
    '機　能：ｻｲﾝ処理
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：
    '作成日：2005/08/09 (Tue) 17:20:19 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:19
    '備　考：
    Private Sub cmdInc1Sign_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInc1Sign0.Click, cmdInc1Sign1.Click, cmdInc1Sign2.Click

        Dim lblnAns         As Boolean          '結果判定
        Dim lstrDateTime    As String           '時間取得
        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

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
            
            '@ｻｲﾝ機能関数へ
            lblnAns = prvblncmdSign_Set(lstrDateTime)
            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@ﾗﾍﾞﾙ/構造体に情報ｾｯﾄ
            With mtypExcpReport
                Select Case llngObjIdx
                    Case CMlngIndex0
                    '@技術
                        .strTechCheckDate = lstrDateTime            '入力日付
                        .strTechCheckEmpID = pstrUserID             '入力担当者ID
                        .strTechCheckEmpName = pstrUserName         '入力担当者名
                    
                    Case CMlngIndex1
                    '@製造
                        .strManuCheckDate = lstrDateTime            '入力日付
                        .strManuCheckEmpID = pstrUserID             '入力担当者ID
                        .strManuCheckEmpName = pstrUserName         '入力担当者名
                    
                    Case CMlngIndex2
                    '@その他
                        .strOthrCheckDate = lstrDateTime            '入力日付
                        .strOthrCheckEmpID = pstrUserID             '入力担当者ID
                        .strOthrCheckEmpName = pstrUserName         '入力担当者名
                End Select
            End With

            'NSYS 日付型変換
            Dim lstrDateTmp As String
            If IsDate(lstrDateTime) Then
                lstrDateTmp = Format$(CDate(lstrDateTime), CPstrDateTimeYMD)
            Else
                lstrDateTmp = lstrDateTime
            End If

            CType(Me.frassTab4.Controls("lblInc1Sign" & llngObjIdx.ToString),Label).Text = lstrDateTmp & vbCrLf & pstrUserName

            '@ｷｬﾝｾﾙﾎﾞﾀﾝを活性化
            CType(Me.frassTab4.Controls("cmdInc1Cancel" & llngObjIdx.ToString),Button).Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdInc1Sign_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdInc1Cancel_Click
    '機　能：ｻｲﾝｷｬﾝｾﾙ処理
    '引　数：Index：0:技術/1：製造/2：その他
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:20:06 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:06
    '備　考：
    Private Sub cmdInc1Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInc1Cancel0.Click, cmdInc1Cancel1.Click, cmdInc1Cancel2.Click

        Dim llngObjIdx      As Integer          'NSYS 処理コントロール種別

        Try
            'NSYS 処理コントロール名の最後尾1桁を取得し数値変換
            Dim lstrBtnIdx = Strings.Right$(sender.Name,1)
            If IsNumeric(lstrBtnIdx) Then
                llngObjIdx = CLng(lstrBtnIdx)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾗﾍﾞﾙ/構造体を空欄にする
            With mtypExcpReport
                Select Case llngObjIdx
                    Case CMlngIndex0
                    '@技術
                        .strTechCheckDate = vbNullString             '入力日付
                        .strTechCheckEmpID = vbNullString            '入力担当者ID
                        .strTechCheckEmpName = vbNullString          '入力担当者名
                    
                    Case CMlngIndex1
                    '@製造
                        .strManuCheckDate = vbNullString             '入力日付
                        .strManuCheckEmpID = vbNullString            '入力担当者ID
                        .strManuCheckEmpName = vbNullString          '入力担当者名
                    
                    Case CMlngIndex2
                    '@その他
                        .strOthrCheckDate = vbNullString             '入力日付
                        .strOthrCheckEmpID = vbNullString            '入力担当者ID
                        .strOthrCheckEmpName = vbNullString          '入力担当者名
                End Select
            End With
            CType(Me.frassTab4.Controls("lblInc1Sign" & llngObjIdx.ToString),Label).Text = vbNullString
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝを非活性化
            CType(Me.frassTab4.Controls("cmdInc1Cancel" & llngObjIdx.ToString),Button).Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdInc1Cancel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '########################################################################################：Tab不適合品処置欄3～5
    '関数名：cmdInc3Sign_Click
    '機　能：ｻｲﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:20:19 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:19
    '備　考：
    Private Sub cmdInc3Sign_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInc3Sign.Click

        Dim lblnAns         As Boolean          '結果判定
        Dim lstrDateTime    As String           '時間取得

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
            
            '@ｻｲﾝ機能関数へ
            lblnAns = prvblncmdSign_Set(lstrDateTime)
            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@ﾗﾍﾞﾙ/構造体に情報ｾｯﾄ
            With mtypExcpReport
                .strIncongJudgeDate = lstrDateTime         '入力日付
                .strIncongJudgeEmpID = pstrUserID           '入力担当者ID
                .strIncongJudgeEmpName = pstrUserName       '入力担当者名
            End With

            'NSYS 日付型変換
            Dim lstrDateTimeTmp As String
            If IsDate(lstrDateTime) Then
                lstrDateTimeTmp = Format$(CDate(lstrDateTime), CPstrDateTimeYMD)
            Else
                lstrDateTimeTmp = lstrDateTime
            End If

            lblInc3Sign.Text = lstrDateTimeTmp & vbCrLf & pstrUserName

            '@ｷｬﾝｾﾙﾎﾞﾀﾝを活性化
            cmdInc3Cancel.Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdInc3Sign_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdInc3Cancel_Click
    '機　能：ｻｲﾝｷｬﾝｾﾙ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:20:06 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:06
    '備　考：
    Private Sub cmdInc3Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInc3Cancel.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾗﾍﾞﾙ/構造体を空欄にする
            With mtypExcpReport
                .strIncongJudgeDate = vbNullString          '入力日付
                .strIncongJudgeEmpID = vbNullString         '入力担当者ID
                .strIncongJudgeEmpName = vbNullString       '入力担当者名
            End With
            lblInc3Sign.Text = vbNullString
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝを非活性化
            cmdInc3Cancel.Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdInc3Cancel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdInc4Up_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 13:00:48 S.Deguchi
    '更新日：2005/12/05 (Mon) 17:17:56 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 17:17:56 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdInc4Up_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInc4Up.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/12/05 (Mon) 17:18:58 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtInc4Comments)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtInc4Comments, CMlngMaxDisp4Row, cmdInc4Up, cmdInc4Down)
        '@↑2005/12/05 (Mon) 17:18:58 N.Kasai **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdInc4Up_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdInc4Down_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 13:00:45 S.Deguchi
    '更新日：2005/12/05 (Mon) 17:18:11 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 17:18:11 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdInc4Down_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInc4Down.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 17:19:55 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtInc4Comments)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtInc4Comments, CMlngMaxDisp4Row, cmdInc4Up, cmdInc4Down)
        '@↑2005/12/05 (Mon) 17:19:55 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdInc4Down_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtInc4Comments_Change
    '機　能：ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtInc4Comments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtInc4Comments.Change

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtInc4Comments, CMlngMaxDisp4Row, cmdInc4Up, cmdInc4Down)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInc4Comments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtInc4Comments_KeyUp
    '機　能：ｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtInc4Comments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtInc4Comments.KeyUp

        Try
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtInc4Comments, CMlngMaxDisp4Row, cmdInc4Up, cmdInc4Down)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInc4Comments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtInc4Comments_MouseUp
    '機　能：ｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtInc4Comments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtInc4Comments.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtInc4Comments, CMlngMaxDisp4Row, cmdInc4Up, cmdInc4Down, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInc4Comments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：cmdInc4Sign_Click
    '機　能：ｻｲﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:20:19 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:19
    '備　考：
    Private Sub cmdInc4Sign_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInc4Sign.Click

        Dim lblnAns         As Boolean          '結果判定
        Dim lstrDateTime    As String           '時間取得

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
            
            '@ｻｲﾝ機能関数へ
            lblnAns = prvblncmdSign_Set(lstrDateTime)
            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@ﾗﾍﾞﾙ/構造体に情報ｾｯﾄ
            With mtypExcpReport
                .strDispoIndicateDate = lstrDateTime         '入力日付
                .strDispoIndicateEmpID = pstrUserID           '入力担当者ID
                .strDispoIndicateEmpName = pstrUserName       '入力担当者名
            End With

            'NSYS 日付型変換
            Dim lstrDateTimeTmp As String
            If IsDate(lstrDateTime) Then
                lstrDateTimeTmp = Format$(CDate(lstrDateTime), CPstrDateTimeYMD)
            Else
                lstrDateTimeTmp = lstrDateTime
            End If
            lblInc4Sign.Text = lstrDateTimeTmp & vbCrLf & pstrUserName

            '@ｷｬﾝｾﾙﾎﾞﾀﾝを活性化
            cmdInc4Cancel.Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdInc4Sign_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdInc4Cancel_Click
    '機　能：ｻｲﾝｷｬﾝｾﾙ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:20:06 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:06
    '備　考：
    Private Sub cmdInc4Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInc4Cancel.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾗﾍﾞﾙ/構造体を空欄にする
            With mtypExcpReport
                .strDispoIndicateDate = vbNullString          '入力日付
                .strDispoIndicateEmpID = vbNullString         '入力担当者ID
                .strDispoIndicateEmpName = vbNullString       '入力担当者名
            End With
            lblInc4Sign.Text = vbNullString
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝを非活性化
            cmdInc4Cancel.Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdInc4Cancel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdinc5Up_Click
    '機　能：次頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 13:00:48 S.Deguchi
    '更新日：2005/12/05 (Mon) 17:23:22 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 17:23:22 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdinc5Up_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdinc5Up.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/12/05 (Mon) 17:24:33 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtInc5Comments)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtInc5Comments, CMlngMaxDisp4Row, cmdInc5Up, cmdInc5Down)
        '@↑2005/12/05 (Mon) 17:24:33 N.Kasai **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdinc5Up_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdinc5Down_Click
    '機　能：前頁改行
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 13:00:45 S.Deguchi
    '更新日：2005/12/05 (Mon) 17:23:45 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 17:23:45 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdinc5Down_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdinc5Down.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/05 (Mon) 17:25:20 N.Kasai **************************************************
        '    '@ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtInc5Comments)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtInc5Comments, CMlngMaxDisp4Row, cmdInc5Up, cmdInc5Down)
        '@↑2005/12/05 (Mon) 17:25:20 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdinc5Down_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtInc5Comments_Change
    '機　能：ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtInc5Comments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtInc5Comments.Change

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtInc5Comments, CMlngMaxDisp4Row, cmdInc5Up, cmdInc5Down)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInc5Comments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtInc5Comments_KeyUp
    '機　能：ｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtInc5Comments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtInc5Comments.KeyUp

        Try
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtInc5Comments, CMlngMaxDisp4Row, cmdInc5Up, cmdInc5Down)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInc5Comments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtInc5Comments_MouseUp
    '機　能：ｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/12/05 (Mon) 10:00:18 N.Kasai
    '更新日：2005/12/05 (Mon) 10:00:18
    '備　考：
    Private Sub txtInc5Comments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtInc5Comments.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtInc5Comments, CMlngMaxDisp4Row, cmdInc5Up, cmdInc5Down, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInc5Comments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdInc5Sign_Click
    '機　能：ｻｲﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:20:19 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:19
    '備　考：
    Private Sub cmdInc5Sign_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInc5Sign.Click

        Dim lblnAns         As Boolean          '結果判定
        Dim lstrDateTime    As String           '時間取得

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
            
            '@ｻｲﾝ機能関数へ
            lblnAns = prvblncmdSign_Set(lstrDateTime)
            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@ﾗﾍﾞﾙ/構造体に情報ｾｯﾄ
            With mtypExcpReport
                .strImproDate = lstrDateTime         '入力日付
                .strImproEmpID = pstrUserID           '入力担当者ID
                .strImproEmpName = pstrUserName       '入力担当者名
            End With

            'NSYS 日付型変換
            Dim lstrDateTimeTmp As String
            If IsDate(lstrDateTime) Then
                lstrDateTimeTmp = Format$(CDate(lstrDateTime), CPstrDateTimeYMD)
            Else
                lstrDateTimeTmp = lstrDateTime
            End If
            lblInc5Sign.Text = lstrDateTimeTmp & vbCrLf & pstrUserName

            '@ｷｬﾝｾﾙﾎﾞﾀﾝを活性化
            cmdInc5Cancel.Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdInc5Sign_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdInc5Cancel_Click
    '機　能：ｻｲﾝｷｬﾝｾﾙ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 17:20:06 S.Deguchi
    '更新日：2005/08/09 (Tue) 17:20:06
    '備　考：
    Private Sub cmdInc5Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInc5Cancel.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾗﾍﾞﾙ/構造体を空欄にする
            With mtypExcpReport
                .strImproDate = vbNullString          '入力日付
                .strImproEmpID = vbNullString         '入力担当者ID
                .strImproEmpName = vbNullString       '入力担当者名
            End With
            lblInc5Sign.Text = vbNullString
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝを非活性化
            cmdInc5Cancel.Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdInc5Cancel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '########################################################################################：Tab登録情報処置
    '関数名：cmdLotAdd_Click
    '機　能：ﾛｯﾄ入力処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 15:32:22 S.Deguchi
    '更新日：2005/08/10 (Wed) 15:32:22
    '備　考：
    Private Sub cmdLotAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotAdd.Click

        Dim ltypExcpReportFormat    As ExcpReport           '初期化用構造体
        Dim ltypExcpReport          As ExcpReport           '要求&応答構造体
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns                 As Boolean              '汎用戻り値
        
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

            '@全ての内容を保存
            Call prvtab1_Set()
            Call prvtab2_Set()
            Call prvtab3_Set()
            Call prvtab4_Set()
            Call prvtab5_Set()
            Call prvtab6_Set()
            
            '@引継ぎﾌﾗｸﾞをTrue設定
            pblnfrmxxCM00H1Kbn = True
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体の初期化
            ptypExcpReport = ltypExcpReportFormat
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体へ置換
            ptypExcpReport = mtypExcpReport
            
            '@選択ﾛｯﾄを退避(Null)
            pstrLotID = vbNullString
            
            '@子画面の起動
            frmxxCM00H1.Instance = New frmxxCM00H1()
            
            If pblnfrmxxCM00H1Kbn = False Then
                '@子画面をｱﾝﾛｰﾄﾞする
                frmxxCM00H1.Instance = Nothing
                
                '@処理抜け
                Exit Sub
            Else
                '@ﾌｫｰﾑを表示
                frmxxCM00H1.Instance.ShowDialog(Me)
                frmxxCM00H1.Instance = Nothing
            End If

            '@登録したか否かで判別(ﾛｯﾄのｶｳﾝﾄで判別)
            If ptypExcpReport.lngExcpReportLotListCnt _
                = mtypExcpReport.lngExcpReportLotListCnt Then
                '@処理終了
                Exit Sub
            End If

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "cmdLotAdd_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@ﾊﾟﾌﾞﾘｯｸの内容をﾓｼﾞｭｰﾙへ変換
            mtypExcpReport = ptypExcpReport
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体の初期化
            ptypExcpReport = ltypExcpReportFormat
            
            '@要求&応答構造体へ要求情報をｾｯﾄ
            With ltypExcpReport
                .strSbID = mstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strExcpNo = mtypExcpReport.strExcpNo       '異常処理№
                .strMsgVer = CMstrExcpReportInfoVer         'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
            End With
            
            '@工程異常/不適合品処理票一覧情報取得
            lblnAns = pubblnExcpReportInfo_Sel(ltypExcpReport)
            '@結果判定
            If lblnAns = True Then
                '@ﾓｼﾞｭｰﾙ構造体へ情報をｾｯﾄ
                mtypExcpReport = ltypExcpReport
                
                '@表示処理
                Call prvtab6_Disp()
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotAdd_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotWk_Click
    '機　能：ﾛｯﾄ処置決定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 15:32:24 S.Deguchi
    '更新日：2005/08/10 (Wed) 15:32:24
    '備　考：
    Private Sub cmdLotWk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotWk.Click

        Dim ltypExcpReportFormat    As ExcpReport           '初期化用構造体
        Dim ltypExcpReport          As ExcpReport           '要求&応答構造体
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns                 As Boolean              '汎用戻り値

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

            '@全ての内容を保存
            Call prvtab1_Set()
            Call prvtab2_Set()
            Call prvtab3_Set()
            Call prvtab4_Set()
            Call prvtab5_Set()
            Call prvtab6_Set()

            '@引継ぎﾌﾗｸﾞをTrue設定
            pblnfrmxxCM00H1Kbn = True
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体の初期化
            ptypExcpReport = ltypExcpReportFormat
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体へ置換
            ptypExcpReport = mtypExcpReport
            
            '@選択ﾛｯﾄを退避
            pstrLotID = vsfLotList.GetData(vsfLotList.Row, CMlngvsfColLotID)
            
            '@子画面の起動
            frmxxCM00H1.Instance = New frmxxCM00H1()
            
            If pblnfrmxxCM00H1Kbn = False Then
                '@子画面をｱﾝﾛｰﾄﾞする
                frmxxCM00H1.Instance = Nothing
                
                '@処理抜け
                Exit Sub
            Else
                '@ﾌｫｰﾑを表示
                frmxxCM00H1.Instance.ShowDialog(Me)
                frmxxCM00H1.Instance = Nothing
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "cmdLotWk_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@ﾊﾟﾌﾞﾘｯｸの内容をﾓｼﾞｭｰﾙへ変換
            mtypExcpReport = ptypExcpReport
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体の初期化
            ptypExcpReport = ltypExcpReportFormat

            '@要求&応答構造体へ要求情報をｾｯﾄ
            With ltypExcpReport
                .strSbID = mstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strExcpNo = mtypExcpReport.strExcpNo       '異常処理№
                .strMsgVer = CMstrExcpReportInfoVer         'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
            End With
            
            '@工程異常/不適合品処理票一覧情報取得
            lblnAns = pubblnExcpReportInfo_Sel(ltypExcpReport)
            '@結果判定
            If lblnAns = True Then
                '@ﾓｼﾞｭｰﾙ構造体へ情報をｾｯﾄ
                mtypExcpReport = ltypExcpReport
                
                '@表示処理
                Call prvtab6_Disp()
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotWk_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWpWk_Click
    '機　能：装置異常処置終了
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 15:33:22 S.Deguchi
    '更新日：2006/12/01 (Fri) 11:31:21 T.Kitagawa
    '備　考：
    '　　　：2006/11/29 (Wed) 15:44:30 T.Kitagawa　ﾊﾟｽﾜｰﾄﾞ確認機能追加(案件№01581)
    Private Sub cmdWpWk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWpWk.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrFunctionID          As String
        Dim lstrActionID            As String               'ｱｸｼｮﾝID
        Dim lstrEmpID               As String               '作業者ID
        Dim lstrEmpName             As String               '作業者名
        Dim lstrSBID                As String               'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg

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

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "cmdTreatEnd_Click"
            
        '@↓2006/12/01 (Fri) 11:32:04 T.Kitagawa **************************************************
        '    '@作業者ｺｰﾄﾞ入力
        '    frmxxCM0010.Show vbModal
            '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing
        '@↑2006/12/01 (Fri) 11:32:04 T.Kitagawa **************************************************
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)

            '@Tab6の内容を一時的に保存
            Call prvtab6_Set()

            '@実行権限の処理を追加
            lstrFunctionID = CPstrKeyEN00U0             '機能ID: EN00U0
            lstrActionID = CPstrAuthority               'ｱｸｼｮﾝID：処置登録
            lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
            lstrEmpName = pstrUserName                  'ﾕｰｻﾞｰ名
            lstrSBID = mstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ

            '@実行権限ﾁｪｯｸ
            lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, lstrEmpID, lstrEmpName, lstrSBID)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrAuthority)
                '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                Exit Sub
            End If

            '@更新処理動作
            With mtypExcpReport
                .strAllDisposalFlag = CMstrApply        '処置ﾌﾗｸﾞ:1
                .strEmpID = pstrUserID                  '更新者ID
                .strEmpName = pstrUserName              '更新者名
            End With
            
            '@工程異常/不適合品処理票情報登録
            lblnAns = prvblnExcpChgReport_Upd(mtypExcpReport, lstrGuidMsg, lstrGuidMsgCode)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                Exit Sub
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
            If mtypExcpReport.strIncongFlag = CMstrIncongFlag0 Then
            '@工程異常処理票の場合
                '@表示ﾒｯｾｰｼﾞ変換：<TRM1GI>$$工程異常処理票を登録しました。異常処理№[%1]
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001G, mtypExcpReport.strExcpNo)
            Else
            '@不適合品処理票の場合
                '@表示ﾒｯｾｰｼﾞ変換：<TRM1UI>$$不適合品処理票を登録しました。異常処理№[%1]
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001U, mtypExcpReport.strExcpNo)
            End If
            
            '@成功ﾒｯｾｰｼﾞ表示
            Call pubVsfInfo_Disp(pstrDMsg)
            
            '@画面更新処理
            Call prvtab6_Disp()
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWpWk_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWorkMiss_Click
    '機　能：作業ミス報告書作成画面に遷移
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 13:03:47 S.Deguchi
    '更新日：2005/08/10 (Wed) 13:03:47
    '備　考：
    Private Sub cmdWorkMiss_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkMiss.Click

        Dim llngCnt     As Integer      'ｶｳﾝﾄ

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
            
            '@更新処理を行う
            Call prvtab1_Set()
            Call prvtab2_Set()
            Call prvtab3_Set()
            Call prvtab4_Set()
            Call prvtab5_Set()
            Call prvtab6_Set()
            
            '@引継ぎ情報をﾊﾟﾌﾞﾘｯｸ構造体にｾｯﾄ
            With ptypWkReportConnect
                .strSbID = mstrSBID                                         '登録ｼｽﾃﾑﾌﾞﾛｯｸ
                
                If mstrApplyFlag = CMstrApply Then
                    .strExcpInsFlag = CMstrConnectApply                     '承認ﾌﾗｸﾞ(=2：承認済)
                Else
                    .strExcpInsFlag = CMstrConnectApplyNo                   '承認ﾌﾗｸﾞ(=1：未承認)
                End If
                
                .strGenDate = mtypExcpReport.strFindDate                    '発見日時
                .strFindEmpName = mtypExcpReport.strFindEmpName             '発見者名
                .strExcpNo = mtypExcpReport.strExcpNo                       '異常処理№
                .strFindOpIDName = mtypExcpReport.strFindOpID               '大工程
                .strFindStepIDName = mtypExcpReport.strFindStepID           '小工程
                .strFindWpName = mtypExcpReport.strFindWpName               '装置名
                .strPdId = mtypExcpReport.strTargetPDID                     '機種名
                
                .lngLotListCnt = mtypExcpReport.lngExcpReportLotListCnt     'ﾘｽﾄｶｳﾝﾄ
                
                If .lngLotListCnt > 0 Then
                    '@領域確保
                    .typLotList = New List(Of CauseLotList)
                    '@情報ｾｯﾄ
                    For llngCnt = 0 To .lngLotListCnt - 1

                        'NSYS 編集用構造体初期化
                        Dim typLotListTmp As CauseLotList = New CauseLotList

                        typLotListTmp.strLotID = _
                            mtypExcpReport.typExcpLotList(llngCnt).strLotID                     'ﾛｯﾄID
                        
                        .strGenDeptID = mtypExcpReport.strFindDeptID                            '発生職場ID
                        
                        .strGenDeptName = mtypExcpReport.strFindDeptName                        '発生職場名
                        
                        .strGenEmpName = mtypExcpReport.strFindEmpName                          '発生者名
                            
                        typLotListTmp.strWFReserveQuantity = _
                            mtypExcpReport.typExcpLotList(llngCnt).strReserveQuantity           '保留
                            
                        typLotListTmp.strWFAbandonQuantity = _
                            mtypExcpReport.typExcpLotList(llngCnt).strAbandonQuantity           '廃却
                            
                        typLotListTmp.strWFAmendQuantity = _
                            mtypExcpReport.typExcpLotList(llngCnt).strAmendQuantity             '手直し
                            
                        typLotListTmp.strWFCorrectQuantity = _
                            mtypExcpReport.typExcpLotList(llngCnt).strCorrectQuantity           '矯正
                            
                        typLotListTmp.strWFEvalQuantity = _
                            mtypExcpReport.typExcpLotList(llngCnt).strEvalQuantity              '評価
                            
                        typLotListTmp.strWFUsualQuantity = _
                            mtypExcpReport.typExcpLotList(llngCnt).strUsualQuantity             '通常
                            
                        typLotListTmp.strWFTakeQuantity = _
                            mtypExcpReport.typExcpLotList(llngCnt).strTakeQuantity              '特採
                            
                        typLotListTmp.strWFTotalQuantity = _
                            mtypExcpReport.typExcpLotList(llngCnt).strTotalQuantity             '合計

                        'NSYS 編集済み構造体追加
                        .typLotList.add(typLotListTmp)
                    Next llngCnt
                End If
            End With
            
            '@引継ぎﾌﾗｸﾞをFalse設定
            pblnfrmxxCM00H2Kbn = False
            
            '@子画面の起動
            frmxxCM00H2.Instance = New frmxxCM00H2()
            
            If pblnfrmxxCM00H2Kbn = False Then
                '@子画面をｱﾝﾛｰﾄﾞする
                frmxxCM00H2.Instance = Nothing
                
                '@処理抜け
                Exit Sub
            Else
                '@ﾌｫｰﾑを表示
                frmxxCM00H2.Instance.ShowDialog(Me)
                frmxxCM00H2.Instance = Nothing
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkMiss_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCauseNo_Click
    '機　能：原因不明ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 13:02:21 S.Deguchi
    '更新日：2005/08/10 (Wed) 13:02:21
    '備　考：
    Private Sub cmdCauseNo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCauseNo.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾃｷｽﾄに「原因不明」文字をｾｯﾄする
            cmbCauseWpID.Text = CMstrCauseNo                    '原因装置
            cmbCauseSeries.Text = CMstrCauseNo                  '原因系列
            cmbCauseKubun.Text = CMstrCauseNo                   '原因区分
            
            '@退避領域にも「原因不明」をｾｯﾄする
            mstrCauseWpID = vbNullString
            mstrCauseWpName = CMstrCauseNo
            
            '@作業ﾐｽﾎﾞﾀﾝ活性化処理
            Call prvcmdWorkMissEnabled_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCauseNo_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCauseWpID_CloseUp
    '機　能：装置CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 13:44:13 S.Deguchi
    '更新日：2004/08/25 (Wed) 13:44:13
    '備　考：
    Private Sub cmbCauseWpID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCauseWpID.CloseUp

        Try
            If cmbCauseWpID.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbCauseWpID.Validating,AddressOf cmbCauseWpID_Validate
                Call cmbCauseWpID_Validate(sender,New CancelEventArgs(False))
                AddHandler cmbCauseWpID.Validating,AddressOf cmbCauseWpID_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCauseWpID_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCauseWpID_Validate
    '機　能：装置Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 13:44:15 S.Deguchi
    '更新日：2004/08/25 (Wed) 13:44:15
    '備　考：
    Private Sub cmbCauseWpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbCauseWpID.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@空欄以外には,情報ｾｯﾄでﾌｫｰｶｽ移動
            If cmbCauseWpID.Text <> vbNullString Then
                '@退避領域に値をｾｯﾄ
                '@装置ID
                cmbCauseWpID.ValueCol = CMlngCmbValueCol1
                mstrCauseWpID = cmbCauseWpID.Value
                
                '@装置名
                mstrCauseWpName = cmbCauseWpID.Text
            End If
            
            '@作業ﾐｽﾎﾞﾀﾝ活性化処理
            Call prvcmdWorkMissEnabled_Proc()
            
            '@次項目へﾌｫｰｶｽｾｯﾄ
            If ActiveControl.Name = cmbCauseWpID.Name Then
                Call pubSetFocus(cmbCauseSeries)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCauseWpID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCauseSeries_CloseUp
    '機　能：原因系列CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 15:34:56 S.Deguchi
    '更新日：2005/08/10 (Wed) 15:34:56
    '備　考：
    Private Sub cmbCauseSeries_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCauseSeries.CloseUp

        Try
            If cmbCauseSeries.Text <> vbNullString Then
                '@原因系列Validate処理へ
                RemoveHandler cmbCauseSeries.Validating,AddressOf cmbCauseSeries_Validate
                Call cmbCauseSeries_Validate(sender,New CancelEventArgs(False))
                AddHandler cmbCauseSeries.Validating,AddressOf cmbCauseSeries_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCauseSeries_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCauseSeries_Validate
    '機　能：原因系列Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 15:34:58 S.Deguchi
    '更新日：2005/08/10 (Wed) 15:34:58
    '備　考：
    Private Sub cmbCauseSeries_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbCauseSeries.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@作業ﾐｽﾎﾞﾀﾝ活性化処理
            Call prvcmdWorkMissEnabled_Proc()

            '@次項目へﾌｫｰｶｽｾｯﾄ
            If ActiveControl.Name = cmbCauseSeries.Name Then
                Call pubSetFocus(cmbCauseKubun)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCauseSeries_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCauseKubun_CloseUp
    '機　能：原因区分CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 15:35:47 S.Deguchi
    '更新日：2005/08/10 (Wed) 15:35:47
    '備　考：
    Private Sub cmbCauseKubun_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCauseKubun.CloseUp

        Try
            If cmbCauseKubun.Text <> vbNullString Then
                '@原因区分Validate処理へ
                RemoveHandler cmbCauseKubun.Validating,AddressOf cmbCauseKubun_Validate
                Call cmbCauseKubun_Validate(sender,New CancelEventArgs(False))
                AddHandler cmbCauseKubun.Validating,AddressOf cmbCauseKubun_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCauseKubun_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCauseKubun_Validate
    '機　能原因区分Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 15:35:49 S.Deguchi
    '更新日：2005/08/10 (Wed) 15:35:49
    '備　考：
    Private Sub cmbCauseKubun_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbCauseKubun.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@作業ﾐｽﾎﾞﾀﾝ活性化処理
            Call prvcmdWorkMissEnabled_Proc()

            '@次項目へﾌｫｰｶｽｾｯﾄ
            If ActiveControl.Name = cmbCauseKubun.Name Then
                Call pubSetFocus(cmdRegist)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCauseKubun_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_RowColChange
    '機　能：ﾛｯﾄ処置決定ﾘｽﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 14:12:03 S.Deguchi
    '更新日：2007/12/19 (Wed) 09:54:57 N.Kasai
    '備　考：
    '　　　：2007/12/19 (Wed) 09:54:57 N.Kasai  ﾛｯﾄ処置訂正ﾎﾞﾀﾝ追加
    Private Sub vsfLotList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.RowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@選択行が処置済みの場合か否かで処理分岐
            With vsfLotList
                '@ﾀｲﾄﾙ以外
                If .Row > 0 Then
                    If .GetData(.Row, CMlngvsfColDispose) = CMstrSumi Then
                        '@ﾛｯﾄ処置決定ﾎﾞﾀﾝ非活性化
                        cmdLotWk.Enabled = False
                        
                        '@承認済み以外の場合
                        If mtypExcpReport.strApprovalFlag = CMstrEdit Then
                            '@ﾛｯﾄ処置訂正ﾎﾞﾀﾝ使用可
                             cmdLotWkCorrect.Enabled = True
                        Else
                            '@ﾛｯﾄ処置訂正ﾎﾞﾀﾝ使用不可
                            cmdLotWkCorrect.Enabled = False
                        End If
                    Else
                        '@ﾛｯﾄ処置決定ﾎﾞﾀﾝ活性化
                        cmdLotWk.Enabled = True
                        '@ﾛｯﾄ処置訂正ﾎﾞﾀﾝ使用不可
                        cmdLotWkCorrect.Enabled = False
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_BeforeSort
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '戻り値：なし
    '作成日：2020/04/25 (Sat) 11:00:00 NSYS
    '更新日：2020/04/25 (Sat) 11:00:00 NSYS
    '備　考：
    '　　　：2020/04/25 (Sat) 11:00:00 NSYS Handles処理新規追加
    Private Sub vsfLotList_BeforeSort(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.BeforeSort

        Try
            'ソート前のスクロール位置退避
            vsfLotListRowBeforeSortScrollPosition = vsfLotList.ScrollPosition

            '再描画抑止（Aftersort実行までFalse）
            vsfLotList.Redraw = False

            '不要なHandler処理を抑止
            RemoveHandler vsfLotList.RowColChange, AddressOf vsfLotList_RowColChange
            vsfLotListRowBeforeSort = vsfLotList.Row

            'データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                     '機能ID
                .strProcName = "vsfLotList_BeforeSort"              '処理名
                .strErrMessage = vbNullString                       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try

    End Sub

    '関数名：vsfAreaEquipment_AfterSort
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '戻り値：なし
    '作成日：2020/04/25 (Sat) 11:00:00 NSYS
    '更新日：2020/04/25 (Sat) 11:00:00 NSYS
    '備　考：
    '　　　：2020/04/25 (Sat) 11:00:00 NSYS Handles処理新規追加
    Private Sub vsfLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.AfterSort

        Try
            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfLotList.RowColChange, AddressOf vsfLotList_RowColChange

            'ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If vsfLotListRowBeforeSort <  vsfLotList.Rows.Fixed Then
                vsfLotList.Row = 0
            Else
                vsfLotList.Row = vsfLotListRowBeforeSort
            End If

            '再描画実行
            vsfLotList.Redraw = True

            'スクロール位置をソート前の状態に戻す
            vsfLotList.ScrollPosition = vsfLotListRowBeforeSortScrollPosition

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "vsfLotList_AfterSort"     '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try

    End Sub

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：prvfrmxxCM00H0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/05 (Fri) 15:01:37 S.Deguchi
    '更新日：2005/12/06 (Tue) 10:06:35 N.Kasai
    '備　考：
    '　　　：2005/12/06 (Tue) 10:06:35 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub prvfrmxxCM00H0_Init()
        
        Try

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = CPstrSubFormCM00H0

        '@↓2005/12/06 (Tue) 10:06:31 N.Kasai **************************************************
            '@工程異常処置欄1～3の初期化
            Call prvtab1_Init()
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期設定
            cmd3_6Up0.Enabled = False                               '3(6)のｺﾒﾝﾄｽｸﾛｰﾙﾎﾞﾀﾝ使用不可
            cmd3_6Down0.Enabled = False                             '3(6)のｺﾒﾝﾄｽｸﾛｰﾙﾎﾞﾀﾝ使用不可
            cmd3_7Up.Enabled = False                                '3(7)のｺﾒﾝﾄｽｸﾛｰﾙﾎﾞﾀﾝ使用不可
            cmd3_7Down.Enabled = False                              '3(7)のｺﾒﾝﾄｽｸﾛｰﾙﾎﾞﾀﾝ使用不可
            
            '@工程異常処置欄4の初期化
            Call prvtab2_Init()
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期設定
            cmd4Up0.Enabled = False                                 '4.技術：ｽｸﾛｰﾙｱｯﾌﾟ
            cmd4Down0.Enabled = False                               '4.技術：ｽｸﾛｰﾙﾀﾞｳﾝ
            cmd4Up1.Enabled = False                                 '4.製造：ｽｸﾛｰﾙｱｯﾌﾟ
            cmd4Down1.Enabled = False                               '4.製造：ｽｸﾛｰﾙﾀﾞｳﾝ
            cmd4Up2.Enabled = False                                 '4.その他：ｽｸﾛｰﾙｱｯﾌﾟ
            cmd4Down2.Enabled = False                               '4.その他：ｽｸﾛｰﾙﾀﾞｳﾝ
            
            '@工程異常処置欄5～6の初期化
            Call prvtab3_Init()
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期設定
            cmd5Up0.Enabled = False                                 '5.技術：ｽｸﾛｰﾙｱｯﾌﾟ
            cmd5Down0.Enabled = False                               '5.技術：ｽｸﾛｰﾙﾀﾞｳﾝ
            cmd5Up1.Enabled = False                                 '5.製造：ｽｸﾛｰﾙｱｯﾌﾟ
            cmd5Down1.Enabled = False                               '5.製造：ｽｸﾛｰﾙﾀﾞｳﾝ
            cmd5Up2.Enabled = False                                 '5.その他：ｽｸﾛｰﾙｱｯﾌﾟ
            cmd5Down2.Enabled = False                               '5.その他：ｽｸﾛｰﾙﾀﾞｳﾝ

            cmd6Up0.Enabled = False                                 '6.技術：ｽｸﾛｰﾙｱｯﾌﾟ
            cmd6Down0.Enabled = False                               '6.技術：ｽｸﾛｰﾙﾀﾞｳﾝ
            cmd6Up1.Enabled = False                                 '6.製造：ｽｸﾛｰﾙｱｯﾌﾟ
            cmd6Down1.Enabled = False                               '6.製造：ｽｸﾛｰﾙﾀﾞｳﾝ
            cmd6Up2.Enabled = False                                 '6.その他：ｽｸﾛｰﾙｱｯﾌﾟ
            cmd6Down2.Enabled = False                               '6.その他：ｽｸﾛｰﾙﾀﾞｳﾝ
            
            '@不適合品処置欄1～2の初期化
            Call prvtab4_Init()
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期設定
            cmdInc1Up0.Enabled = False                              'Inc1.技術：ｽｸﾛｰﾙｱｯﾌﾟ
            cmdInc1Down0.Enabled = False                            'Inc1.技術：ｽｸﾛｰﾙﾀﾞｳﾝ
            cmdInc1Up1.Enabled = False                              'Inc1.製造：ｽｸﾛｰﾙｱｯﾌﾟ
            cmdInc1Down1.Enabled = False                            'Inc1.製造：ｽｸﾛｰﾙﾀﾞｳﾝ
            cmdInc1Up2.Enabled = False                              'Inc1.その他：ｽｸﾛｰﾙｱｯﾌﾟ
            cmdInc1Down2.Enabled = False                            'Inc1.その他：ｽｸﾛｰﾙﾀﾞｳﾝ
            cmd3_6Up0.Enabled = False                               'Inc2(6)のｺﾒﾝﾄｽｸﾛｰﾙﾎﾞﾀﾝ活性化
            cmd3_6Down0.Enabled = False                             'Inc2(6)のｺﾒﾝﾄｽｸﾛｰﾙﾎﾞﾀﾝ活性化
            
            '@不適合品処置欄3～5の初期化
            Call prvtab5_Init()
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期設定
            cmdInc4Up.Enabled = False                               'Inc4：ｽｸﾛｰﾙｱｯﾌﾟ
            cmdInc4Down.Enabled = False                             'Inc4：ｽｸﾛｰﾙﾀﾞｳﾝ
            cmdInc5Up.Enabled = False                               'Inc5：ｽｸﾛｰﾙｱｯﾌﾟ
            cmdInc5Down.Enabled = False                             'Inc5：ｽｸﾛｰﾙｱｯﾌﾟ
        '@↑2005/12/06 (Tue) 10:06:31 N.Kasai **************************************************
            
            '@登録情報処置の初期化
            Call prvtab6_Init()
            
            '@表示Tab制御
            tabControl.TabPages(CMlngssTab1).Select
            
            '@表示しているTab以外はﾌｫｰｶｽを移動しないように制御する
            frassTab1.Enabled = True
            frassTab2.Enabled = False
            frassTab3.Enabled = False
            frassTab4.Enabled = False
            frassTab5.Enabled = False
            frassTab6.Enabled = False
            
            '@「閉じる」ﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00H0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab1_Init
    '機　能：工程異常処置欄1～3の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/05 (Fri) 15:35:27 S.Deguchi
    '更新日：2005/12/06 (Tue) 09:31:41 N.Kasai
    '備　考：
    '　　　：2005/09/20 (Tue) 14:48:51 S.Deguchi    ﾕｰｻﾞｰ要望№0072の対応で確認依頼先情報を初期化する処理を追加
    '　　　：2005/12/06 (Tue) 09:31:41 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub prvtab1_Init()

        Try

            '@大元のﾌﾚｰﾑを活性化する
            frassTab1.Enabled = True
            
            '@ﾗﾍﾞﾙの初期化
            lblNo.Text = vbNullString                            '異常処理票№
            lblpost.Text = vbNullString                          '発見職場
            lblName.Text = vbNullString                          '発見者名
            lblUpdate.Text = vbNullString                        '更新日時
            lblUndateName.Text = vbNullString                    '更新者名
            lbl1Name.Text = vbNullString                         '工程異常名
        '@↓2005/09/20 (Tue) 14:57:25 S.Deguchi **************************************************
            lblFromDate.Text = vbNullString                      '確認依頼日時
            lblFromEmpName.Text = vbNullString                   '確認依頼元
        '@↑2005/09/20 (Tue) 14:57:25 S.Deguchi **************************************************
            
            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txtTelNo.Text = vbNullString                         '電話番号
            txt2Comments.Text = vbNullString                     '2 その他入力欄
            txt2Comments.Enabled = False                         '2 その他入力欄を非活性化(optの7番選択時活性化)
            txt3_30.Text = vbNullString                          '3(3) 対象数量・%
            txt3_30.Locked = True                                'NSYS デザイナーのプロパティ設定のLockは別属性のためInitで明示的にLockする
            txt3_6Comments0.Text = vbNullString                  '3(6) 工程異常発生状況
            txt3_7Comments.Text = vbNullString                   '3(7) 異常内容・詳細ｺﾒﾝﾄ
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期設定
            opt2Excp1.Checked = False                            '2(1)
            opt2Excp2.Checked = False                            '2(2)
            opt2Excp3.Checked = False                            '2(3)
            opt2Excp4.Checked = False                            '2(4)
            opt2Excp5.Checked = False                            '2(5)
            opt2Excp6.Checked = False                            '2(6)
            opt2Excp7.Checked = False                            '2(7)
        '@↓2017/07/21 (Fri) 11:29:27 Y.Yoneyama **************************************************
            opt2Excp8.Checked = False                            '2(8)
        '@↑2017/07/21 (Fri) 11:29:27 Y.Yoneyama **************************************************
            opt3_7umu0.Checked = False                           '3(7) 工程異常
            opt3_7umu1.Checked = False                           '3(7) 不適合品発生
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期設定
            cmdTrouble.Enabled = True                            '工程異常名取得ﾎﾞﾀﾝ
        '@↓2005/12/06 (Tue) 09:31:35 N.Kasai **************************************************
        '    cmd3_6Up(CMlngIndex0).Enabled = True                    '3(6)のｺﾒﾝﾄｽｸﾛｰﾙﾎﾞﾀﾝ活性化
        '    cmd3_6Down(CMlngIndex0).Enabled = True                  '3(6)のｺﾒﾝﾄｽｸﾛｰﾙﾎﾞﾀﾝ活性化
        '    cmd3_7Up.Enabled = True                                 '3(7)のｺﾒﾝﾄｽｸﾛｰﾙﾎﾞﾀﾝ活性化
        '    cmd3_7Down.Enabled = True                               '3(7)のｺﾒﾝﾄｽｸﾛｰﾙﾎﾞﾀﾝ活性化
        '@↑2005/12/06 (Tue) 09:31:35 N.Kasai **************************************************
            
        '@↓2005/09/20 (Tue) 14:58:09 S.Deguchi **************************************************
            '@確認依頼先の初期化
            With vsfToEmpName
                .Clear                                              '内容ｸﾘｱ
                .Rows.Count = 0                                     '行=0
                .Cols.Count = 0                                     '列=0
            End With
        '@↑2005/09/20 (Tue) 14:58:09 S.Deguchi **************************************************
            
            '@対象LotNoの初期化
            With vsfLotNo0
                .Clear                                              '内容ｸﾘｱ
                .Rows.Count = 0                                     '行=0
                .Cols.Count = 0                                     '列=0
            End With
            
            '@ｺﾝﾎﾞﾎﾞｯｸｽの初期化
            cmbPdID.Clear
            cmbOpID.Clear
            cmbStepID.Clear
            cmbWpID.Clear
            
            '@ｶﾚﾝﾀﾞｰの初期化
            Call pubblnCalendar_Init(calFindDate, CPlngCalModeTool)
            
            '@ﾌｫﾝﾄをそろえる
            calFindDate.Font =  New Font(calFindDate.Font.FontFamily, CMlngCmbFontSize, calFindDate.Font.Style,calFindDate.Font.Unit, calFindDate.Font.GdiCharSet, calFindDate.Font.GdiVerticalFont)
            
            '@時間ﾏｽｸｴﾃﾞｨｯﾄの初期化
            medFindTime.Text = "00:00"
            
            '@大元のﾌﾚｰﾑを非活性化する
            frassTab1.Enabled = False
            
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
    '機　能：工程異常処置欄4の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/05 (Fri) 15:38:31 S.Deguchi
    '更新日：2005/12/06 (Tue) 09:34:57 N.Kasai
    '備　考：
    '　　　：2005/12/06 (Tue) 09:34:57 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub prvtab2_Init()

        Try

            '@大元のﾌﾚｰﾑを活性化する
            frassTab2.Enabled = True
            
            '@ﾗﾍﾞﾙの初期化
            lbl4Sign0.Text = vbNullString                                        '4.技術
            lbl4Sign1.Text = vbNullString                                        '4.製造
            lbl4Sign2.Text = vbNullString                                        '4.その他
            
            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txt4Comments0.Text = vbNullString                                    '4.技術
            txt4Comments1.Text = vbNullString                                    '4.製造
            txt4Comments2.Text = vbNullString                                    '4.その他
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期設定
            opt4ProcInfl0.Checked = True                                         '4.無
            opt4ProcInfl1.Checked = False                                        '4.有
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期設定
            cmd4Sign0.Enabled = True                                             '4.技術：ｻｲﾝ
            cmd4Cancel0.Enabled = False                                          '4.技術：ｷｬﾝｾﾙ
            cmd4Sign1.Enabled = True                                             '4.製造：ｻｲﾝ
            cmd4Cancel1.Enabled = False                                          '4.製造：ｷｬﾝｾﾙ
            cmd4Sign2.Enabled = True                                             '4.その他：ｻｲﾝ
            cmd4Cancel2.Enabled = False                                          '4.その他：ｷｬﾝｾﾙ
            
        '@↓2005/12/06 (Tue) 09:35:23 N.Kasai **************************************************
        '    cmd4Up(CMlngIndex0).Enabled = True                                      '4.技術：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmd4Down(CMlngIndex0).Enabled = True                                    '4.技術：ｽｸﾛｰﾙﾀﾞｳﾝ
        '    cmd4Up(CMlngIndex1).Enabled = True                                      '4.製造：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmd4Down(CMlngIndex1).Enabled = True                                    '4.製造：ｽｸﾛｰﾙﾀﾞｳﾝ
        '    cmd4Up(CMlngIndex2).Enabled = True                                      '4.その他：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmd4Down(CMlngIndex2).Enabled = True                                    '4.その他：ｽｸﾛｰﾙﾀﾞｳﾝ
        '@↑2005/12/06 (Tue) 09:35:23 N.Kasai **************************************************
            
            '@大元のﾌﾚｰﾑを非活性化する
            frassTab2.Enabled = False

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

    '関数名：prvtab3_Init
    '機　能：工程異常処置欄5～6の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/05 (Fri) 15:38:34 S.Deguchi
    '更新日：2005/12/06 (Tue) 09:36:54 N.Kasai
    '備　考：
    '　　　：2005/12/06 (Tue) 09:36:54 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub prvtab3_Init()

        Try

            '@大元のﾌﾚｰﾑを活性化する
            frassTab3.Enabled = True
            
            '@ﾗﾍﾞﾙの初期化
            lbl5Sign0.Text = vbNullString                                        '5.技術
            lbl5Sign1.Text = vbNullString                                        '5.製造
            lbl5Sign2.Text = vbNullString                                        '5.その他
            lbl6Sign0.Text = vbNullString                                        '6.技術
            lbl6Sign1.Text = vbNullString                                        '6.製造
            lbl6Sign2.Text = vbNullString                                        '6.その他
            
            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txt5Comments0.Text = vbNullString                                    '5.技術
            txt5Comments1.Text = vbNullString                                    '5.製造
            txt5Comments2.Text = vbNullString                                    '5.その他
            txt6Comments0.Text = vbNullString                                    '6.技術
            txt6Comments1.Text = vbNullString                                    '6.製造
            txt6Comments2.Text = vbNullString                                    '6.その他
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期設定
            cmd5Sign0.Enabled = True                                             '5.技術：ｻｲﾝ
            cmd5Cancel0.Enabled = False                                          '5.技術：ｷｬﾝｾﾙ
            cmd5Sign1.Enabled = True                                             '5.製造：ｻｲﾝ
            cmd5Cancel1.Enabled = False                                          '5.製造：ｷｬﾝｾﾙ
            cmd5Sign2.Enabled = True                                             '5.その他：ｻｲﾝ
            cmd5Cancel2.Enabled = False                                          '5.その他：ｷｬﾝｾﾙ
            
        '@↓2005/12/06 (Tue) 09:39:08 N.Kasai **************************************************
        '    cmd5Up(CMlngIndex0).Enabled = True                                      '5.技術：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmd5Down(CMlngIndex0).Enabled = True                                    '5.技術：ｽｸﾛｰﾙﾀﾞｳﾝ
        '    cmd5Up(CMlngIndex1).Enabled = True                                      '5.製造：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmd5Down(CMlngIndex1).Enabled = True                                    '5.製造：ｽｸﾛｰﾙﾀﾞｳﾝ
        '    cmd5Up(CMlngIndex2).Enabled = True                                      '5.その他：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmd5Down(CMlngIndex2).Enabled = True                                    '5.その他：ｽｸﾛｰﾙﾀﾞｳﾝ
        '@↑2005/12/06 (Tue) 09:39:08 N.Kasai **************************************************

            cmd6Sign0.Enabled = True                                             '6.技術：ｻｲﾝ
            cmd6Cancel0.Enabled = False                                          '6.技術：ｷｬﾝｾﾙ
            cmd6Sign1.Enabled = True                                             '6.製造：ｻｲﾝ
            cmd6Cancel1.Enabled = False                                          '6.製造：ｷｬﾝｾﾙ
            cmd6Sign2.Enabled = True                                             '6.その他：ｻｲﾝ
            cmd6Cancel2.Enabled = False                                          '6.その他：ｷｬﾝｾﾙ
            
        '@↓2005/12/06 (Tue) 09:39:12 N.Kasai **************************************************
        '    cmd6Up(CMlngIndex0).Enabled = True                                      '6.技術：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmd6Down(CMlngIndex0).Enabled = True                                    '6.技術：ｽｸﾛｰﾙﾀﾞｳﾝ
        '    cmd6Up(CMlngIndex1).Enabled = True                                      '6.製造：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmd6Down(CMlngIndex1).Enabled = True                                    '6.製造：ｽｸﾛｰﾙﾀﾞｳﾝ
        '    cmd6Up(CMlngIndex2).Enabled = True                                      '6.その他：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmd6Down(CMlngIndex2).Enabled = True                                    '6.その他：ｽｸﾛｰﾙﾀﾞｳﾝ
        '@↑2005/12/06 (Tue) 09:39:12 N.Kasai **************************************************
                
            '@大元のﾌﾚｰﾑを非活性化する
            frassTab3.Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab3_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab4_Init
    '機　能：不適合品処置欄1～2の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/05 (Fri) 15:38:37 S.Deguchi
    '更新日：2005/12/06 (Tue) 10:02:24 N.Kasai
    '備　考：
    '　　　：2005/12/06 (Tue) 10:02:24 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub prvtab4_Init()

        Try

            '@大元のﾌﾚｰﾑを活性化する
            frassTab4.Enabled = True
            
            '@ﾗﾍﾞﾙの初期化
            lblIncName.Text = vbNullString                                           '不良特性名
            lblInc1Sign0.Text = vbNullString                                         'Inc1.技術
            lblInc1Sign1.Text = vbNullString                                         'Inc1.製造
            lblInc1Sign2.Text = vbNullString                                         'Inc1.その他
            
            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txtInc1Comments0.Text = vbNullString                                     'Inc1.技術
            txtInc1Comments1.Text = vbNullString                                     'Inc1.製造
            txtInc1Comments2.Text = vbNullString                                     'Inc1.その他
            txt3_31.Text = vbNullString                                              'Inc2(3) 対象数量・%
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期設定
            optComformNo10.Checked = False                                           'Inc1.無
            optComformNo11.Checked = True                                            'Inc1.有
            optComformNo20.Checked = False                                           'Inc2.無
            optComformNo21.Checked = True                                            'Inc2.有
              
        '@↓2017/07/21 (Fri) 13:15:44 Y.Yoneyama **************************************************
            '@非表示
            optComformNo20.Checked = False
            optComformNo21.Checked = False
        '@↑2017/07/21 (Fri) 13:15:44 Y.Yoneyama **************************************************
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期設定
            cmdInc1Sign0.Enabled = True                                              'Inc1.技術：ｻｲﾝ
            cmdInc1Cancel0.Enabled = False                                           'Inc1.技術：ｷｬﾝｾﾙ
            cmdInc1Sign1.Enabled = True                                              'Inc1.製造：ｻｲﾝ
            cmdInc1Cancel1.Enabled = False                                           'Inc1.製造：ｷｬﾝｾﾙ
            cmdInc1Sign2.Enabled = True                                              'Inc1.その他：ｻｲﾝ
            cmdInc1Cancel2.Enabled = False                                           'Inc1.その他：ｷｬﾝｾﾙ
            
        '@↓2005/12/06 (Tue) 10:02:44 N.Kasai **************************************************
        '    cmdInc1Up(CMlngIndex0).Enabled = True                                       'Inc1.技術：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmdInc1Down(CMlngIndex0).Enabled = True                                     'Inc1.技術：ｽｸﾛｰﾙﾀﾞｳﾝ
        '    cmdInc1Up(CMlngIndex1).Enabled = True                                       'Inc1.製造：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmdInc1Down(CMlngIndex1).Enabled = True                                     'Inc1.製造：ｽｸﾛｰﾙﾀﾞｳﾝ
        '    cmdInc1Up(CMlngIndex2).Enabled = True                                       'Inc1.その他：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmdInc1Down(CMlngIndex2).Enabled = True                                     'Inc1.その他：ｽｸﾛｰﾙﾀﾞｳﾝ
        '    cmd3_6Up(CMlngIndex0).Enabled = True                                        'Inc2(6)のｺﾒﾝﾄｽｸﾛｰﾙﾎﾞﾀﾝ活性化
        '    cmd3_6Down(CMlngIndex0).Enabled = True                                      'Inc2(6)のｺﾒﾝﾄｽｸﾛｰﾙﾎﾞﾀﾝ活性化
        '@↑2005/12/06 (Tue) 10:02:44 N.Kasai **************************************************
            
            '@対象LotNoの初期化
            With vsfLotNo1
                .Clear                                              '内容ｸﾘｱ
                .Rows.Count = 0                                     '行=0
                .Cols.Count = 0                                     '列=0
            End With
            
            '@ｺﾝﾎﾞﾎﾞｯｸｽの初期化
            cmbPdIDDisp.Clear
            cmbOpIDDisp.Clear
            cmbStepIDDisp.Clear
            cmbWpIDDisp.Clear
            
            '@ｶﾚﾝﾀﾞｰの初期化
            Call pubblnCalendar_Init(calFindDateDisp, CPlngCalModeTool)
            
            '@時間ﾏｽｸｴﾃﾞｨｯﾄの初期化
            medFindTimeDisp.Text = "00:00"
            
            '@大元のﾌﾚｰﾑを非活性化する
            frassTab4.Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab4_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab5_Init
    '機　能：不適合品処置欄3～5の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/05 (Fri) 15:38:40 S.Deguchi
    '更新日：2005/12/06 (Tue) 10:04:36 N.Kasai
    '備　考：
    '　　　：2005/12/06 (Tue) 10:04:36 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub prvtab5_Init()

        Try

            '@大元のﾌﾚｰﾑを活性化する
            frassTab5.Enabled = True
            
            '@ﾗﾍﾞﾙの初期化
            lblIncName.Text = vbNullString                                           '不良特性名
            lblInc3Sign.Text = vbNullString                                          'Inc3
            lblInc4Sign.Text = vbNullString                                          'Inc4
            lblInc5Sign.Text = vbNullString                                          'Inc5
            
            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txtInc4Comments.Text = vbNullString                                      'Inc4
            txtInc5Comments.Text = vbNullString                                      'Inc5
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期設定
            opt3Gen0.Checked = True                                                  'Inc3.a
            opt3Gen1.Checked = False                                                 'Inc3.b
            opt3Gen2.Checked = False                                                 'Inc3.c
        '@↓2017/07/21 (Fri) 11:45:39 Y.Yoneyama **************************************************
            opt3Gen3.Checked = False                                                 'Inc3.d
        '@↑2017/07/21 (Fri) 11:45:39 Y.Yoneyama **************************************************
            optCut0.Checked = True                                                   '低減
            optCut1.Checked = False                                                  '削減
            
            '@ﾁｪｯｸﾎﾞｯｸｽの初期設定
            chk4Treat1.Checked = False                                               '廃却
            chk4Treat2.Checked = False                                               '手直し
            chk4Treat3.Checked = False                                               '特採
            chk4Treat4.Checked = False                                               '通常
            chk4Treat5.Checked = False                                               '修正
            chk4Treat6.Checked = False                                               '評価
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期設定
            cmdInc3Sign.Enabled = True                                               'Inc3：ｻｲﾝ
            cmdInc3Cancel.Enabled = False                                            'Inc3：ｷｬﾝｾﾙ
            cmdInc4Sign.Enabled = True                                               'Inc4：ｻｲﾝ
            cmdInc4Cancel.Enabled = False                                            'Inc4：ｷｬﾝｾﾙ
            cmdInc5Sign.Enabled = True                                               'Inc5：ｻｲﾝ
            cmdInc5Cancel.Enabled = False                                            'Inc5：ｷｬﾝｾﾙ
            
        '@↓2005/12/06 (Tue) 10:04:31 N.Kasai **************************************************
        '    cmdInc4Up.Enabled = True                                                    'Inc4：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmdInc4Down.Enabled = True                                                  'Inc4：ｽｸﾛｰﾙﾀﾞｳﾝ
        '    cmdInc5Up.Enabled = True                                                    'Inc5：ｽｸﾛｰﾙｱｯﾌﾟ
        '    cmdInc5Down.Enabled = True                                                  'Inc5：ｽｸﾛｰﾙｱｯﾌﾟ
        '@↑2005/12/06 (Tue) 10:04:31 N.Kasai **************************************************
            
            '@大元のﾌﾚｰﾑを非活性化する
            frassTab5.Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab5_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab6_Init
    '機　能：登録情報処置の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/05 (Fri) 15:38:42 S.Deguchi
    '更新日：2005/08/05 (Fri) 15:38:42
    '備　考：
    Private Sub prvtab6_Init()

        Try

            '@大元のﾌﾚｰﾑを活性化する
            frassTab6.Enabled = True

            '@ﾛｯﾄ処置決定欄の初期化
            Call prvvsfLotList_Init()

            'NSYS グリッドの無効化
            vsfLotList.Enabled = False

            '@ﾗﾍﾞﾙの初期設定
            lblDispose.Text = CMstrlblMisyochi

            '@ｺﾝﾎﾞﾎﾞｯｸｽの初期設定
            cmbCauseWpID.Clear                                  '原因装置
            cmbCauseSeries.Clear                                '原因系列
            cmbCauseKubun.Clear                                 '原因区分

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期設定
            cmdLotAdd.Enabled = True                            'ﾛｯﾄ入力
            cmdLotWk.Enabled = False                            'ﾛｯﾄ処置決定
            cmdLotWkCorrect.Enabled = False                     'ﾛｯﾄ処置訂正
            cmdWpWk.Enabled = False                             '装置異常処理終了
            cmdWorkMiss.Enabled = False                         '作業ﾐｽ報告書
            cmdCauseNo.Enabled = True                           '原因不明
            
            '@大元のﾌﾚｰﾑを非活性化する
            frassTab6.Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab6_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab1_Disp
    '機　能：工程異常処置欄1～3の表示
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:05 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:05
    '備　考：
    '　　　：2005/09/20 (Tue) 14:48:51 S.Deguchi    ﾕｰｻﾞｰ要望№0072の対応で確認依頼先情報をｾｯﾄする処理を追加
    Private Sub prvtab1_Disp()

        Dim llngCnt         As Integer          '汎用ｶｳﾝﾀ
        Dim lblnEnabled     As Boolean          '存在ﾁｪｯｸ
        Dim lstrTempString  As String           '内部処理用一時変数

        Try
            
            '@大元のﾌﾚｰﾑを活性化する
            frassTab1.Enabled = True

            '@構造体の情報をｺﾝﾄﾛｰﾙへ配置する
            With mtypExcpReport
                '@発行№
                lblNo.Text = .strExcpNo
                
                '@発見職場
                lblpost.Text = .strFindDeptName
                
                '@発見者名
                lblName.Text = .strFindEmpName
                
                '@更新日時(㍉秒を削除,年月日時分ﾌｫｰﾏｯﾄで)
                Dim lblUpdateTmp As String = Strings.Left$(.strEditTime, CMlngTimeFormat16)
                If IsDate(lblUpdateTmp) Then
                    lblUpdate.Text = Format$(CDate(lblUpdateTmp), CPstrDateTimeYMDHM)
                Else
                    lblUpdate.Text = lblUpdateTmp
                End If
                
                '@更新者
                lblUndateName.Text = .strEmpName
                
        '@↓2005/09/20 (Tue) 14:56:09 S.Deguchi **************************************************
                '@確認依頼日(㍉秒を削除,年月日時分ﾌｫｰﾏｯﾄで)
                Dim lblFromDateTmp As String = Strings.Left$(ptypExcpEditList.strFromEntryTime, CMlngTimeFormat16)
                If IsDate(lblFromDateTmp) Then 
                    lblFromDate.Text = Format$(CDate(lblFromDateTmp), CPstrDateTimeYMDHM)
                Else
                    lblFromDate.Text = lblFromDateTmp
                End If
                
                '@確認依頼元
                lblFromEmpName.Text = ptypExcpEditList.strFromEmpName
                
                '@確認依頼先
                If ptypExcpEditList.lnEmpListCnt > 0 Then
                    '@行数設定
                    vsfToEmpName.Rows.Count = ptypExcpEditList.lnEmpListCnt
                    'NSYS 表示時は行選択させない
                    vsfToEmpName.Row = -1
                    
                    '@列数設定
                    vsfToEmpName.Cols.Count = 1
                    
                    '@確認依頼先名称をｾｯﾄ
                    'NSYS ヘッダー行無しのためグリッド0行目からデータセットする
                    For llngCnt = 0 To ptypExcpEditList.lnEmpListCnt - 1
                        vsfToEmpName.SetData(llngCnt, CMlngvsfToEmpName , ptypExcpEditList.typExcpEmpList(llngCnt).strEmpName)
                    Next llngCnt
                End If
        '@↑2005/09/20 (Tue) 14:56:09 S.Deguchi **************************************************
                
                '@発見者Tel
                txtTelNo.Text = .strFindTelNo
                
                '@工程異常名
                lbl1Name.Text = .strExcpItemName
                
                '@工程異常項目
                Select Case .strExcpItemNo
                    Case CMlngIndex1
                    '@(1)の場合
                        opt2Excp1.Checked = True                    '工程異常項目(1)
                        txt2Comments.Text = vbNullString            '(7)その他の文字列
                        
                    Case CMlngIndex2
                    '@(2)の場合
                        opt2Excp2.Checked = True                    '工程異常項目(2)
                        txt2Comments.Text = vbNullString            '(7)その他の文字列
                
                    Case CMlngIndex3
                    '@(3)の場合
                        opt2Excp3.Checked = True                    '工程異常項目(3)
                        txt2Comments.Text = vbNullString            '(7)その他の文字列
                
                    Case CMlngIndex4
                    '@(4)の場合
                        opt2Excp4.Checked = True                    '工程異常項目(4)
                        txt2Comments.Text = vbNullString            '(7)その他の文字列
                
                    Case CMlngIndex5
                    '@(5)の場合
                        opt2Excp5.Checked = True                    '工程異常項目(5)
                        txt2Comments.Text = vbNullString            '(7)その他の文字列
                
                    Case CMlngIndex6
                    '@(6)の場合
                        opt2Excp6.Checked = True                    '工程異常項目(6)
                        txt2Comments.Text = vbNullString            '(7)その他の文字列
                
                    Case CMlngIndex7
                    '@(7)の場合
                        opt2Excp7.Checked = True                    '工程異常項目(7)
                        txt2Comments.Text = .strExcpItemOthr        '(7)その他の文字列
                    
        '@↓2017/07/21 (Fri) 11:30:09 Y.Yoneyama **************************************************
                    Case CMlngIndex8
                    '@(6)の場合
                        opt2Excp8.Checked = True                    '工程異常項目(8)
                        txt2Comments.Text = vbNullString            '(7)その他の文字列
        '@↑2017/07/21 (Fri) 11:30:09 Y.Yoneyama **************************************************
                    
                    Case Else
                    '@その他の場合(Null/0等)
                        opt2Excp1.Checked = False                   '工程異常項目(1)
                        opt2Excp2.Checked = False                   '工程異常項目(2)
                        opt2Excp3.Checked = False                   '工程異常項目(3)
                        opt2Excp4.Checked = False                   '工程異常項目(4)
                        opt2Excp5.Checked = False                   '工程異常項目(5)
                        opt2Excp6.Checked = False                   '工程異常項目(6)
                        opt2Excp7.Checked = False                   '工程異常項目(7)
        '@↓2017/07/21 (Fri) 11:37:15 Y.Yoneyama **************************************************
                        opt2Excp8.Checked = False                   '工程異常項目(8)
        '@↑2017/07/21 (Fri) 11:37:15 Y.Yoneyama **************************************************
                        txt2Comments.Text = vbNullString            '(7)その他の文字列
                End Select
                
                '@取得機種のｾｯﾄ
                If .strTargetPDID = vbNullString Then
                    '@ｺﾝﾄﾛｰﾙ活性化
                    cmbPdID.Enabled = True
                    
                    '@ｺﾝﾄﾛｰﾙのﾃｷｽﾄ部にNullをｾｯﾄ
                    cmbPdID.Text = vbNullString
                Else
                    If mlngProductListCnt > 0 Then
                        '@存在ﾁｪｯｸの為,変数初期化
                        lblnEnabled = False
                        
                        '@存在ﾁｪｯｸ
                        For llngCnt = 0 To mlngProductListCnt - 1
                            If mtypProductList(llngCnt).strProductID = .strTargetPDID Then
                                '@存在
                                lblnEnabled = True
                                
                                Exit For
                            End If
                        Next llngCnt
                        
                        '@存在する場合
                        If lblnEnabled = True Then
                            '@取得情報をｾｯﾄ
                            cmbPdID.Text = .strTargetPDID
                        Else
                            '@ｺﾝﾄﾛｰﾙのﾃｷｽﾄ部にNullをｾｯﾄ
                            cmbPdID.Text = vbNullString
                        End If
                    Else
                        '@直接表示
                        cmbPdID.Text = .strTargetPDID
                    End If
                End If
                
                'NSYS 設定用対象数量数値変換
                Dim strTargetQuantityTmp As String
                If IsNumeric(.strTargetQuantity) Then
                    strTargetQuantityTmp = Format$(CLng(.strTargetQuantity), CPstrDateFormatKanma)
                Else
                    strTargetQuantityTmp = .strTargetQuantity
                End If

                '@対象数量(FORMAT：数量 単位)
                If .strTargetUnit = CMstrtxtUnitWFNo Then
                    txt3_30.Text = strTargetQuantityTmp & CMstrBrank & CMstrtxtUnitWF
                Else
                    txt3_30.Text = strTargetQuantityTmp & CMstrBrank & CMstrtxtUnitChip
                End If
                
                '@発見日時
                If IsDate(.strFindDate) Then
                    lstrTempString = Format$(CDate(.strFindDate), CPstrDateTimeYMD)
                    calFindDate.Value = lstrTempString
                    lstrTempString = Format$(CDate(.strFindDate), CPstrTimeFormatHM)
                    medFindTime.Text = lstrTempString
                Else
                    calFindDate.Value = .strFindDate
                    medFindTime.Text = .strFindDate
                End If
                
                '@対象Lot№
                If .lngExcpReportLotListCnt > 0 Then
                    '@描画ﾛｯｸ
                    vsfLotNo0.Redraw = False
                    
                    '@ｸﾘｱ
                    vsfLotNo0.Clear
                    
                    '@列設定
                    vsfLotNo0.Cols.Count = 1
                    
                    '@行設定
                    vsfLotNo0.Rows.Count = .lngExcpReportLotListCnt
                    vsfLotNo0.Row = -1
                    
                    '@ｸﾞﾘｯﾄﾞにﾛｯﾄIDをｾｯﾄ
                    'NSYS ヘッダー行無しのためグリッド0行目からデータセットする
                    For llngCnt = 0 To .lngExcpReportLotListCnt - 1
                        vsfLotNo0.SetData(llngCnt, CMlngvsfColNo,.typExcpLotList(llngCnt).strLotID)
                        '@高さ設定
                        vsfLotNo0.Rows(llngCnt).Height = CMlngVsfHHeight
                    Next llngCnt
                
                    '@描画ﾛｯｸ解除
                    vsfLotNo0.Redraw = True
                    
                    '@活性化
                    vsfLotNo0.Enabled = True
                Else
                    '@ｺﾝﾄﾛｰﾙの非活性化
                    With vsfLotNo0
                        .Enabled = False
                        .Clear
                    End With
                End If
            
                '@大工程
                If .strFindOpID <> vbNullString Then
                    '@取得大工程に対して存在ﾁｪｯｸ
                    If mtypMasOpList.lngMasOpCnt > 0 Then
                        '@存在ﾁｪｯｸの為,変数初期化
                        lblnEnabled = False
                        
                        '@存在ﾁｪｯｸ
                        For llngCnt = 0 To mtypMasOpList.lngMasOpCnt - 1
                            If mtypMasOpList.typMasOpId(llngCnt).strOpID = .strFindOpID Then
                                '@存在
                                lblnEnabled = True
                                
                                Exit For
                            End If
                        Next llngCnt
                        
                        '@存在する場合
                        If lblnEnabled = True Then
                            '@取得情報をｾｯﾄ
                            cmbOpID.Text = .strFindOpID
                            
                            '@退避領域へ情報をｾｯﾄ
                            mstrOpID = .strFindOpID
                        Else
                            '@ｺﾝﾄﾛｰﾙのﾃｷｽﾄ部にNullをｾｯﾄ
                            cmbOpID.Text = vbNullString
                        End If
                    Else
                        '@直接表示
                        cmbOpID.Text = .strFindOpID
                        '@退避領域へ情報をｾｯﾄ
                        mstrOpID = .strFindOpID
                    End If
                Else
                    '@ｺﾝﾄﾛｰﾙのﾃｷｽﾄ部にNullをｾｯﾄ
                    cmbOpID.Text = vbNullString
                End If
                
                '@小工程
                If .strFindStepID <> vbNullString Then
                    '@取得小工程に対して存在ﾁｪｯｸ
                    If mtypMasStepList.lngMasStepCnt > 0 Then
                        '@存在ﾁｪｯｸの為,変数初期化
                        lblnEnabled = False
                        
                        '@存在ﾁｪｯｸ
                        For llngCnt = 0 To mtypMasStepList.lngMasStepCnt - 1
                            If mtypMasStepList.typMasStepId(llngCnt).strStepID = .strFindStepID Then
                                '@存在
                                lblnEnabled = True
                                
                                Exit For
                            End If
                        Next llngCnt
                        
                        '@存在する場合
                        If lblnEnabled = True Then
                            '@取得情報をｾｯﾄ
                            cmbStepID.Text = .strFindStepID
                        
                            '@退避領域へ情報をｾｯﾄ
                            mstrStepID = .strFindStepID
                        Else
                            '@ｺﾝﾄﾛｰﾙのﾃｷｽﾄ部にNullをｾｯﾄ
                            cmbStepID.Text = vbNullString
                        End If
                    Else
                        '@直接表示
                        cmbStepID.Text = .strFindStepID
                        '@退避領域へ情報をｾｯﾄ
                        mstrStepID = .strFindStepID
                    End If
                Else
                    '@ｺﾝﾄﾛｰﾙのﾃｷｽﾄ部にNullをｾｯﾄ
                    cmbStepID.Text = vbNullString
                End If
                
                '@装置
                If .strFindWpID <> vbNullString And .strFindWpName <> vbNullString Then
                    '@取得装置に対して存在ﾁｪｯｸ
                    If mlngWpListCnt > 0 Then
                        '@存在ﾁｪｯｸの為,変数初期化
                        lblnEnabled = False
                        
                        '@存在ﾁｪｯｸ
                        For llngCnt = 0 To mlngWpListCnt - 1
                            If mtypWpList(llngCnt).strWpName = .strFindWpName Then
                                '@存在
                                lblnEnabled = True
                                
                                Exit For
                            End If
                        Next llngCnt
                        
                        '@存在する場合
                        If lblnEnabled = True Then
                            '@取得情報をｾｯﾄ
                            cmbWpID.Text = .strFindWpName
                        
                            '@退避領域へ情報をｾｯﾄ
                            mstrWpID = .strFindWpID
                            mstrWpName = .strFindWpName
                        Else
                            '@ｺﾝﾄﾛｰﾙのﾃｷｽﾄ部にNullをｾｯﾄ
                            cmbWpID.Text = vbNullString
                        End If
                    Else
                        '@直接表示
                        '@取得情報をｾｯﾄ
                        cmbWpID.Text = .strFindWpName
                    
                        '@退避領域へ情報をｾｯﾄ
                        mstrWpID = .strFindWpID
                        mstrWpName = .strFindWpName
                    
                    
                    End If
                Else
                    '@ｺﾝﾄﾛｰﾙのﾃｷｽﾄ部にNullをｾｯﾄ
                    cmbWpID.Text = vbNullString
                End If
                
                '@3.(6)工程異常発生状況
                txt3_6Comments0.Text = .strExcpSituation
                        
                '@3.(7)不適合品発生有無
                '@編集ﾌﾗｸﾞを立てる
                mblnEditFlag = True
                
                Select Case .strIncongFlag
                    Case CMstrIncongFlag0
                    '@無
                        opt3_7umu0.Checked = True
                        Call opt3_7umu_Click(opt3_7umu0,New EventArgs()) 'NSYS クリック処理を手動実行
                        tabControl.TabPages(CMlngssTab4).Enabled = False
                        tabControl.TabPages(CMlngssTab5).Enabled = False

                        'NSYS タブ不適合品処置欄1～2、不適合品処置欄3～5無効
                        mblnTabSelectDisabled = True
                    
                        '@装置で起案している場合
                        If .lngExcpReportLotListCnt = 0 Then
                        '@不適合品への変更を不可とする
                            opt3_7umu1.Enabled = False
                        Else
                        '@不適合品への変更を可能とする
                            opt3_7umu1.Enabled = True
                        End If
                        
                    Case CMstrIncongFlag1
                    '@有
                        opt3_7umu1.Checked = True
                        Call opt3_7umu_Click(opt3_7umu1,New EventArgs()) 'NSYS クリック処理を手動実行
                        tabControl.TabPages(CMlngssTab4).Enabled = True
                        tabControl.TabPages(CMlngssTab5).Enabled = True

                        'NSYS タブ不適合品処置欄1～2、不適合品処置欄3～5有効
                        mblnTabSelectDisabled = True
                End Select
            
                '@編集ﾌﾗｸﾞを戻す
                mblnEditFlag = False
                
                '@3.(7)不適合品発生有無・詳細ｺﾒﾝﾄ
                txt3_7Comments.Text = .strExcpDetailComments
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
    '機　能：工程異常処置欄4の表示
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:08 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:08
    '備　考：
    Private Sub prvtab2_Disp()

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
        
        Try

            '@大元のﾌﾚｰﾑを活性化する
            frassTab2.Enabled = True

            '@構造体の情報をｺﾝﾄﾛｰﾙへ配置する
            With mtypExcpReport
                '@後工程/信頼性影響
                Select Case .strInflFlag
                    Case CMlngIndex0
                    '@無
                        opt4ProcInfl0.Checked = True
                    Case CMlngIndex1
                    '@有
                        opt4ProcInfl1.Checked = True
                End Select
                
                '@確認内容
                txt4Comments0.Text = .strTechInflContents                                           '技術

                'NSYS 日付型変換
                Dim strTechInflDateTmp As String
                If IsDate(.strTechInflDate) Then
                    strTechInflDateTmp = Format$(CDate(.strTechInflDate), CPstrDateTimeYMD)
                Else
                    strTechInflDateTmp = .strTechInflDate
                End If

                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strTechInflEmpName <> vbNullString Then
                    lbl4Sign0.Text = strTechInflDateTmp & vbCrLf & .strTechInflEmpName
                End If
                
                txt4Comments1.Text = .strManuInflContents                               '製造

                'NSYS 日付型変換
                Dim strManuInflDateTmp As String
                If IsDate(.strManuInflDate) Then
                    strManuInflDateTmp = Format$(CDate(.strManuInflDate), CPstrDateTimeYMD)
                Else
                    strManuInflDateTmp = .strManuInflDate
                End If

                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strManuInflEmpName <> vbNullString Then
                    lbl4Sign1.Text = strManuInflDateTmp & vbCrLf & .strManuInflEmpName
                End If
                
                txt4Comments2.Text = .strOthrInflContents                               'その他

                'NSYS 日付型変換
                Dim strOthrInflDateTmp As String
                If IsDate(.strOthrInflDate) Then
                    strOthrInflDateTmp = Format$(CDate(.strOthrInflDate), CPstrDateTimeYMD)
                Else
                    strOthrInflDateTmp = .strOthrInflDate
                End If

                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strOthrInflEmpName <> vbNullString Then
                    lbl4Sign2.Text = strOthrInflDateTmp & vbCrLf & .strOthrInflEmpName
                End If
                
                '@ｻｲﾝ/ｷｬﾝｾﾙﾎﾞﾀﾝの制御
                For llngCnt = CMlngIndex0 To CMlngIndex2
                    If CType(Me.frassTab2.Controls("lbl4Sign" & llngCnt.ToString),Label).Text <> vbNullString Then
                    '@ｻｲﾝが存在する場合
                        '@ｻｲﾝﾎﾞﾀﾝの活性化
                        CType(Me.frassTab2.Controls("cmd4Sign" & llngCnt.ToString),Button).Enabled = True
                        '@ｷｬﾝｾﾙﾎﾞﾀﾝの活性化
                        CType(Me.frassTab2.Controls("cmd4Cancel" & llngCnt.ToString),Button).Enabled = True
                    Else
                    '@ｻｲﾝが存在しない場合
                        '@ｻｲﾝﾎﾞﾀﾝの活性化
                        CType(Me.frassTab2.Controls("cmd4Sign" & llngCnt.ToString),Button).Enabled = True
                        '@ｷｬﾝｾﾙﾎﾞﾀﾝの非活性化
                        CType(Me.frassTab2.Controls("cmd4Cancel" & llngCnt.ToString),Button).Enabled = False
                    End If
                Next llngCnt
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

    '関数名：prvtab3_Disp
    '機　能：工程異常処置欄5～6の表示
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:10 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:10
    '備　考：
    Private Sub prvtab3_Disp()

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ

        Try

            '@大元のﾌﾚｰﾑを活性化する
            frassTab3.Enabled = True

            '@構造体の情報をｺﾝﾄﾛｰﾙへ配置する
            With mtypExcpReport
                '@原因
                txt5Comments0.Text = .strTechInvestContents                               '技術

                'NSYS 日付型変換
                Dim strTechInvestDateTmp As String
                If IsDate(.strTechInvestDate) Then
                    strTechInvestDateTmp = Format$(CDate(.strTechInvestDate), CPstrDateTimeYMD)
                Else
                    strTechInvestDateTmp = .strTechInvestDate
                End If

                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strTechInvestEmpName <> vbNullString Then
                    lbl5Sign0.Text = strTechInvestDateTmp & vbCrLf & .strTechInvestEmpName
                End If
                
                txt5Comments1.Text = .strManuInvestContents                               '製造

                'NSYS 日付型変換
                Dim strManuInvestDateTmp As String
                If IsDate(.strManuInvestDate) Then
                    strManuInvestDateTmp = Format$(CDate(.strManuInvestDate), CPstrDateTimeYMD)
                Else
                    strManuInvestDateTmp = .strManuInvestDate
                End If

                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strManuInvestEmpName <> vbNullString Then
                    lbl5Sign1.Text = strManuInvestDateTmp & vbCrLf & .strManuInvestEmpName
                End If
                
                txt5Comments2.Text = .strOthrInvestContents                               'その他

                'NSYS 日付型変換
                Dim strOthrInvestDateTmp As String
                If IsDate(.strOthrInvestDate) Then
                    strOthrInvestDateTmp = Format$(CDate(.strOthrInvestDate), CPstrDateTimeYMD)
                Else
                    strOthrInvestDateTmp = .strOthrInvestDate
                End If

                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strOthrInvestEmpName <> vbNullString Then
                    lbl5Sign2.Text = strOthrInvestDateTmp & vbCrLf & .strOthrInvestEmpName
                End If
                
                '@ｻｲﾝ/ｷｬﾝｾﾙﾎﾞﾀﾝの制御
                For llngCnt = CMlngIndex0 To CMlngIndex2
                    If CType(Me.frassTab3.Controls("lbl5Sign" & llngCnt.ToString),Label).Text <> vbNullString Then
                    '@ｻｲﾝが存在する場合
                        '@ｻｲﾝﾎﾞﾀﾝの活性化
                        CType(Me.frassTab3.Controls("cmd5Sign" & llngCnt.ToString),Button).Enabled = True
                        '@ｷｬﾝｾﾙﾎﾞﾀﾝの活性化
                        CType(Me.frassTab3.Controls("cmd5Cancel" & llngCnt.ToString),Button).Enabled = True
                    Else
                    '@ｻｲﾝが存在しない場合
                        '@ｻｲﾝﾎﾞﾀﾝの活性化
                        CType(Me.frassTab3.Controls("cmd5Sign" & llngCnt.ToString),Button).Enabled = True
                        '@ｷｬﾝｾﾙﾎﾞﾀﾝの非活性化
                        CType(Me.frassTab3.Controls("cmd5Cancel" & llngCnt.ToString),Button).Enabled = False
                    End If
                Next llngCnt
            
                '@指示内容・指示帳票名
                txt6Comments0.Text = .strTechIndicateContents                               '技術

                'NSYS 日付型変換
                Dim strTechIndicateDateTmp As String
                If IsDate(.strTechIndicateDate) Then
                    strTechIndicateDateTmp = Format$(CDate(.strTechIndicateDate), CPstrDateTimeYMD)
                Else
                    strTechIndicateDateTmp = .strTechIndicateDate
                End If

                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strTechIndicateEmpName <> vbNullString Then
                    lbl6Sign0.Text = strTechIndicateDateTmp & vbCrLf & .strTechIndicateEmpName
                End If
                
                txt6Comments1.Text = .strManuIndicateContents                               '製造

                'NSYS 日付型変換
                Dim strManuIndicateDateTmp As String
                If IsDate(.strManuIndicateDate) Then
                    strManuIndicateDateTmp = Format$(CDate(.strManuIndicateDate), CPstrDateTimeYMD)
                Else
                    strManuIndicateDateTmp = .strManuIndicateDate
                End If

                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strManuIndicateEmpName <> vbNullString Then
                    lbl6Sign1.Text = strManuIndicateDateTmp & vbCrLf & .strManuIndicateEmpName
                End If
                
                txt6Comments2.Text = .strOthrIndicateContents                               'その他

                'NSYS 日付型変換
                Dim strOthrIndicateDateTmp As String
                If IsDate(.strOthrIndicateDate) Then
                    strOthrIndicateDateTmp = Format$(CDate(.strOthrIndicateDate), CPstrDateTimeYMD)
                Else
                    strOthrIndicateDateTmp = .strOthrIndicateDate
                End If

                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strOthrIndicateEmpName <> vbNullString Then
                    lbl6Sign2.Text = strOthrIndicateDateTmp & vbCrLf & .strOthrIndicateEmpName
                End If
                
                '@ｻｲﾝ/ｷｬﾝｾﾙﾎﾞﾀﾝの制御
                For llngCnt = CMlngIndex0 To CMlngIndex2
                    If CType(Me.frassTab3.Controls("lbl6Sign" & llngCnt.ToString),Label).Text <> vbNullString Then
                    '@ｻｲﾝが存在する場合
                        '@ｻｲﾝﾎﾞﾀﾝの活性化
                        CType(Me.frassTab3.Controls("cmd6Sign" & llngCnt.ToString),Button).Enabled = True
                        '@ｷｬﾝｾﾙﾎﾞﾀﾝの活性化
                        CType(Me.frassTab3.Controls("cmd6Cancel" & llngCnt.ToString),Button).Enabled = True
                    Else
                    '@ｻｲﾝが存在しない場合
                        '@ｻｲﾝﾎﾞﾀﾝの活性化
                        CType(Me.frassTab3.Controls("cmd6Sign" & llngCnt.ToString),Button).Enabled = True
                        '@ｷｬﾝｾﾙﾎﾞﾀﾝの非活性化
                        CType(Me.frassTab3.Controls("cmd6Cancel" & llngCnt.ToString),Button).Enabled = False
                    End If
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab3_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab4_Disp
    '機　能：不適合品処置欄1～2の表示
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:13 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:13
    '備　考：
    Private Sub prvtab4_Disp()

        Dim llngCnt         As Integer          '汎用ｶｳﾝﾀ
        Dim lstrTempString  As String           '内部処理用一時変数
        
        Try

            '@大元のﾌﾚｰﾑを活性化する
            frassTab4.Enabled = True

            '@構造体の情報をｺﾝﾄﾛｰﾙへ配置する
            With mtypExcpReport
                lblIncName.Text = .strIncongItemName             '不良特性名
                
                '@確認根拠
                txtInc1Comments0.Text = .strTechCheckContents                               '技術

                'NSYS 日付型変換
                Dim strTechCheckDateTmp As String
                If IsDate(.strTechCheckDate) Then
                    strTechCheckDateTmp = Format$(CDate(.strTechCheckDate), CPstrDateTimeYMD)
                Else
                    strTechCheckDateTmp = .strTechCheckDate
                End If

                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strTechCheckEmpName <> vbNullString Then
                    lblInc1Sign0.Text = strTechCheckDateTmp & vbCrLf & .strTechCheckEmpName
                End If
                
                txtInc1Comments1.Text = .strManuCheckContents                               '製造

                'NSYS 日付変換
                Dim strManuCheckDateTmp As String
                If IsDate(.strManuCheckDate) Then
                    strManuCheckDateTmp = Format$(CDate(.strManuCheckDate), CPstrDateTimeYMD)
                Else
                    strManuCheckDateTmp = .strManuCheckDate
                End If

                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strManuCheckEmpName <> vbNullString Then
                    lblInc1Sign1.Text = strManuCheckDateTmp & vbCrLf & .strManuCheckEmpName
                End If
                
                txtInc1Comments2.Text = .strOthrCheckContents                               'その他

                'NSYS 日付型変換
                Dim strOthrCheckDateTmp As String
                If IsDate(.strOthrCheckDate) Then
                    strOthrCheckDateTmp = Format$(CDate(.strOthrCheckDate), CPstrDateTimeYMD)
                Else
                    strOthrCheckDateTmp = .strOthrCheckDate
                End If

                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strOthrCheckEmpName <> vbNullString Then
                    lblInc1Sign2.Text = strOthrCheckDateTmp & vbCrLf & .strOthrCheckEmpName
                End If
                
                '@ｻｲﾝ/ｷｬﾝｾﾙﾎﾞﾀﾝの制御
                For llngCnt = CMlngIndex0 To CMlngIndex2
                    If CType(Me.frassTab4.Controls("lblInc1Sign" & llngCnt.ToString),Label).Text <> vbNullString Then
                    '@ｻｲﾝが存在する場合
                        '@ｻｲﾝﾎﾞﾀﾝの活性化
                        CType(Me.frassTab4.Controls("cmdInc1Sign" & llngCnt.ToString),Button).Enabled = True
                        '@ｷｬﾝｾﾙﾎﾞﾀﾝの活性化
                        CType(Me.frassTab4.Controls("cmdInc1Cancel" & llngCnt.ToString),Button).Enabled = True
                    Else
                    '@ｻｲﾝが存在しない場合
                        '@ｻｲﾝﾎﾞﾀﾝの活性化
                        CType(Me.frassTab4.Controls("cmdInc1Sign" & llngCnt.ToString),Button).Enabled = True
                        '@ｷｬﾝｾﾙﾎﾞﾀﾝの非活性化
                        CType(Me.frassTab4.Controls("cmdInc1Cancel" & llngCnt.ToString),Button).Enabled = False
                    End If
                Next llngCnt
                
                '@取得機種のｾｯﾄ
                cmbPdIDDisp.Text = .strTargetPDID
                
                '@対象数量(FORMAT：数量 単位)
                If .strTargetUnit = CMstrtxtUnitWFNo Then
                    txt3_31.Text = .strTargetQuantity & CMstrBrank & CMstrtxtUnitWF
                Else
                    txt3_31.Text = .strTargetQuantity & CMstrBrank & CMstrtxtUnitChip
                End If
                
                '@発見日時
                If IsDate(.strFindDate) Then
                    lstrTempString = Format$(CDate(.strFindDate), CPstrDateTimeYMD)
                    calFindDateDisp.Value = lstrTempString
                    lstrTempString = Format$(CDate(.strFindDate), CPstrTimeFormatHM)
                    medFindTimeDisp.Text = lstrTempString
                Else
                    lstrTempString = .strFindDate
                    medFindTimeDisp.Text = .strFindDate
                End If
                
                '@対象Lot№
                If .lngExcpReportLotListCnt > 0 Then
                    '@描画ﾛｯｸ
                    vsfLotNo1.Redraw = False
                    
                    '@ｸﾘｱ
                    vsfLotNo1.Clear
                    
                    '@列設定
                    vsfLotNo1.Cols.Count = 1
                    
                    '@行設定
                    vsfLotNo1.Rows.Count = .lngExcpReportLotListCnt
                    vsfLotNo1.Row = - 1
                    
                    '@ｸﾞﾘｯﾄﾞにﾛｯﾄIDをｾｯﾄ
                    'NSYS ヘッダー行無しのためグリッド0行目からデータセットする
                    For llngCnt = 0 To .lngExcpReportLotListCnt - 1
                        vsfLotNo1.SetData(llngCnt, CMlngvsfColNo, .typExcpLotList(llngCnt).strLotID)
                        '@高さ設定
                        vsfLotNo1.Rows(llngCnt).Height = CMlngVsfHHeight
                    Next llngCnt
                
                    '@描画ﾛｯｸ解除
                    vsfLotNo1.Redraw = True
                    
                    '@活性化
                    vsfLotNo1.Enabled = True
                Else
                    '@ｺﾝﾄﾛｰﾙの非活性化
                    With vsfLotNo1
                        .Enabled = False
                        .Clear
                    End With
                End If
            
                '@大工程
                cmbOpIDDisp.Text = .strFindOpID
                
                '@小工程
                cmbStepIDDisp.Text = .strFindStepID
                
                '@装置
                cmbWpIDDisp.Text = .strFindWpName
                
                '@3.(6)工程異常発生状況
                txt3_6Comments1.Text = .strExcpSituation
                txt3_6Comments1.Locked = True
            
                fraInc2.Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab4_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab5_Disp
    '機　能：不適合品処置欄3～5の表示
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:15 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:15
    '備　考：
    Private Sub prvtab5_Disp()

        Try

            '@大元のﾌﾚｰﾑを活性化する
            frassTab5.Enabled = True

            '@構造体の情報をｺﾝﾄﾛｰﾙへ配置する
            With mtypExcpReport
                '@3 不適合品発生量
                If .strIncongJudgeVolume = vbNullString Then
                    opt3Gen0.Checked = True                                         '規定以上(ﾁｪｯｸ)
                    opt3Gen1.Checked = False                                        '規定以下
                    opt3Gen2.Checked = False                                        'その他
        '@↓2017/07/21 (Fri) 11:46:05 Y.Yoneyama **************************************************
                    opt3Gen3.Checked = False                                        'd
        '@↑2017/07/21 (Fri) 11:46:05 Y.Yoneyama **************************************************
                Else
                    If .strIncongJudgeVolume = CMlngIndex1 Then
                        opt3Gen0.Checked = True                                     '規定以上(ﾁｪｯｸ)
                        opt3Gen1.Checked = False                                    '規定以下
                        opt3Gen2.Checked = False                                    'その他
        '@↓2017/07/21 (Fri) 12:37:38 Y.Yoneyama **************************************************
                        opt3Gen3.Checked = False                                    'd
        '@↑2017/07/21 (Fri) 12:37:38 Y.Yoneyama **************************************************
                    End If
                    If .strIncongJudgeVolume = CMlngIndex2 Then
                        opt3Gen0.Checked = False                                    '規定以上(ﾁｪｯｸ)
                        opt3Gen1.Checked = True                                     '規定以下
                        opt3Gen2.Checked = False                                    'その他
        '@↓2017/07/21 (Fri) 12:37:38 Y.Yoneyama **************************************************
                        opt3Gen3.Checked = False                                    'd
        '@↑2017/07/21 (Fri) 12:37:38 Y.Yoneyama **************************************************
                    End If
                    If .strIncongJudgeVolume = CMlngIndex3 Then
                        opt3Gen0.Checked = False                                    '規定以上(ﾁｪｯｸ)
                        opt3Gen1.Checked = False                                    '規定以下
                        opt3Gen2.Checked = True                                     'その他
        '@↓2017/07/21 (Fri) 12:37:38 Y.Yoneyama **************************************************
                        opt3Gen3.Checked = False                                    'd
        '@↑2017/07/21 (Fri) 12:37:38 Y.Yoneyama **************************************************
                    End If
        '@↓2017/07/21 (Fri) 12:36:48 Y.Yoneyama **************************************************
                    If .strIncongJudgeVolume = CMlngIndex4 Then
                        opt3Gen0.Checked = False                                    'a
                        opt3Gen1.Checked = False                                    'b
                        opt3Gen2.Checked = False                                    'c
                        opt3Gen3.Checked = True                                     'd
                    End If
        '@↑2017/07/21 (Fri) 12:36:48 Y.Yoneyama **************************************************
                End If

                'NSYS 日付型変換
                Dim strIncongJudgeDateTmp As String
                If IsDate(.strIncongJudgeDate) Then
                    strIncongJudgeDateTmp = Format$(CDate(.strIncongJudgeDate), CPstrDateTimeYMD)
                Else
                    strIncongJudgeDateTmp = .strIncongJudgeDate
                End If
                
                '@3 ｻｲﾝ
                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strIncongJudgeEmpName <> vbNullString Then
                    lblInc3Sign.Text = strIncongJudgeDateTmp & vbCrLf & .strIncongJudgeEmpName
                End If
                
                '@ｻｲﾝ/ｷｬﾝｾﾙﾎﾞﾀﾝの制御
                If lblInc3Sign.Text <> vbNullString Then
                '@ｻｲﾝが存在する場合
                    '@ｻｲﾝﾎﾞﾀﾝの活性化
                    cmdInc3Sign.Enabled = True
                    '@ｷｬﾝｾﾙﾎﾞﾀﾝの活性化
                    cmdInc3Cancel.Enabled = True
                Else
                '@ｻｲﾝが存在しない場合
                    '@ｻｲﾝﾎﾞﾀﾝの活性化
                    cmdInc3Sign.Enabled = True
                    '@ｷｬﾝｾﾙﾎﾞﾀﾝの非活性化
                    cmdInc3Cancel.Enabled = False
                End If
            
                '@4 現品処理方法
                If .strDispoScrapFlag = vbNullString Then           '廃却
                     chk4Treat1.Checked = False                     '未ﾁｪｯｸ
                Else
                    If .strDispoScrapFlag = CMlngIndex0 Then
                        chk4Treat1.Checked = False                  '未ﾁｪｯｸ
                    Else
                        chk4Treat1.Checked = True                   'ﾁｪｯｸ
                    End If
                End If
                
                If .strDispoMdifyFlag = vbNullString Then           '手直し
                    chk4Treat2.Checked = False                      '未ﾁｪｯｸ
                Else
                    If .strDispoMdifyFlag = CMlngIndex0 Then
                        chk4Treat2.Checked = False                  '未ﾁｪｯｸ
                    Else
                        chk4Treat2.Checked = True                   'ﾁｪｯｸ
                    End If
                End If
                
                If .strDispoPickFlag = vbNullString Then            '特採
                    chk4Treat3.Checked = False                      '未ﾁｪｯｸ
                Else
                    If .strDispoPickFlag = CMlngIndex0 Then
                        chk4Treat3.Checked = False                  '未ﾁｪｯｸ
                    Else
                        chk4Treat3.Checked = True                   'ﾁｪｯｸ
                    End If
                End If
                
                If .strDispoRegularFlag = vbNullString Then         '通常
                    chk4Treat4.Checked = False                      '未ﾁｪｯｸ
                Else
                    If .strDispoRegularFlag = CMlngIndex0 Then
                        chk4Treat4.Checked = False                  '未ﾁｪｯｸ
                    Else
                        chk4Treat4.Checked = True                   'ﾁｪｯｸ
                    End If
                End If
                
                If .strDispoAmendFlag = vbNullString Then           '修正
                    chk4Treat5.Checked = False                      '未ﾁｪｯｸ
                Else
                    If .strDispoAmendFlag = CMlngIndex0 Then
                        chk4Treat5.Checked = False                  '未ﾁｪｯｸ
                    Else
                        chk4Treat5.Checked = True                   'ﾁｪｯｸ
                    End If
                End If
                
                If .strDispoRatingFlag = vbNullString Then          '評価
                    chk4Treat6.Checked = False                      '未ﾁｪｯｸ
                Else
                    If .strDispoRatingFlag = CMlngIndex0 Then
                        chk4Treat6.Checked = False                  '未ﾁｪｯｸ
                    Else
                        chk4Treat6.Checked = True                   'ﾁｪｯｸ
                    End If
                End If
                
                txtInc4Comments.Text = .strDispoContents            '帳票名

                'NSYS 日付型変換
                Dim strDispoIndicateDateTmp As String
                If IsDate(.strDispoIndicateDate) Then
                    strDispoIndicateDateTmp = Format$(CDate(.strDispoIndicateDate), CPstrDateTimeYMD)
                Else
                    strDispoIndicateDateTmp = .strDispoIndicateDate
                End If
            
                '@4 ｻｲﾝ
                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strDispoIndicateEmpName <> vbNullString Then
                    lblInc4Sign.Text = strDispoIndicateDateTmp & vbCrLf & .strDispoIndicateEmpName
                End If
                
                '@ｻｲﾝ/ｷｬﾝｾﾙﾎﾞﾀﾝの制御
                If lblInc4Sign.Text <> vbNullString Then
                '@ｻｲﾝが存在する場合
                    '@ｻｲﾝﾎﾞﾀﾝの活性化
                    cmdInc4Sign.Enabled = True
                    '@ｷｬﾝｾﾙﾎﾞﾀﾝの活性化
                    cmdInc4Cancel.Enabled = True
                Else
                '@ｻｲﾝが存在しない場合
                    '@ｻｲﾝﾎﾞﾀﾝの活性化
                    cmdInc4Sign.Enabled = True
                    '@ｷｬﾝｾﾙﾎﾞﾀﾝの非活性化
                    cmdInc4Cancel.Enabled = False
                End If
            
                '@5 継続的改善
                Select Case .strImproKind                       '改善取り組み
                    Case CMlngIndex1
                        optCut0.Checked = True
                        optCut1.Checked = False
                    Case CMlngIndex2
                        optCut0.Checked = False
                        optCut1.Checked = True
                End Select
                txtInc5Comments.Text = .strImproContents        '改善ｺﾒﾝﾄ
            
                '@5 ｻｲﾝ
                '@ｻｲﾝの名称が存在する場合のみﾗﾍﾞﾙへｾｯﾄ
                If .strImproEmpName <> vbNullString Then

                    'NSYS 日付型変換
                    Dim strImproDateTmp As String
                    If IsDate(.strImproDate) Then
                        strImproDateTmp = Format$(CDate(.strImproDate), CPstrDateTimeYMD)
                    Else
                        strImproDateTmp = .strImproDate
                    End If
                    lblInc5Sign.Text = strImproDateTmp & vbCrLf & .strImproEmpName
                End If
                
                '@ｻｲﾝ/ｷｬﾝｾﾙﾎﾞﾀﾝの制御
                If lblInc5Sign.Text <> vbNullString Then
                '@ｻｲﾝが存在する場合
                    '@ｻｲﾝﾎﾞﾀﾝの活性化
                    cmdInc5Sign.Enabled = True
                    '@ｷｬﾝｾﾙﾎﾞﾀﾝの活性化
                    cmdInc5Cancel.Enabled = True
                Else
                '@ｻｲﾝが存在しない場合
                    '@ｻｲﾝﾎﾞﾀﾝの活性化
                    cmdInc5Sign.Enabled = True
                    '@ｷｬﾝｾﾙﾎﾞﾀﾝの非活性化
                    cmdInc5Cancel.Enabled = False
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab5_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab6_Disp
    '機　能：登録情報処置の表示
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:18 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:18
    '備　考：
    Private Sub prvtab6_Disp()

        Try

            '@大元のﾌﾚｰﾑを活性化する
            frassTab6.Enabled = True

            '@構造体の情報をｺﾝﾄﾛｰﾙへ配置する
            With mtypExcpReport
                '@ﾛｯﾄﾘｽﾄを設定
                Call prvvsfLotList_Disp()
                
                '@状態を表示
                Select Case .strApprovalFlag
                    Case CMstrApply
                    '@適用済みの場合
                        lblDispose.Text = CMstrlblSyouninSumi                '承認済み
                        
                    Case Else
                    '@未適用の場合
                        Select Case .strAllDisposalFlag
                            Case CMstrApply
                            '@処置済みの場合
                                lblDispose.Text = CMstrlblSyochiSumi         '処置済み
                
                            Case Else
                            '@未処置の場合
                                lblDispose.Text = CMstrlblMisyochi           '未処置
                        End Select
                End Select
                
                If .lngExcpReportLotListCnt > 0 Then
                '@ﾛｯﾄが存在する場合
                    cmdWpWk.Enabled = False                                     '装置異常処置終了ﾎﾞﾀﾝ
                Else
                '@ﾛｯﾄが存在しない場合
                    '@処置済みか否かでﾎﾞﾀﾝ制御
                    If .strAllDisposalFlag = CMstrApply Then
                        cmdWpWk.Enabled = False                                 '装置異常処置終了ﾎﾞﾀﾝ
                    Else
                        cmdWpWk.Enabled = True                                  '装置異常処置終了ﾎﾞﾀﾝ
                    End If
                End If
            
                cmbCauseWpID.Text = .strCauseWpName                             '原因装置
                cmbCauseSeries.Text = .strCauseSeriesName                       '原因系列
                cmbCauseKubun.Text = .strCauseClassName                         '原因区分
                
                mstrCauseWpID = .strCauseWpID                                   '原因装置ID
                mstrCauseWpName = .strCauseWpName                               '原因装置名
                
                '@ﾎﾞﾀﾝの非活性化
                cmdLotWk.Enabled = False                                        'ﾛｯﾄ処置決定ﾎﾞﾀﾝ
                cmdLotWkCorrect.Enabled = False                                 'ﾛｯﾄ処置訂正ﾎﾞﾀﾝ
                
                '@作業ﾐｽﾎﾞﾀﾝ活性化処理
                Call prvcmdWorkMissEnabled_Proc()
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab6_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab1_Set
    '機　能：工程異常処置欄1～3の情報格納
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:05 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:05
    '備　考：
    Private Sub prvtab1_Set()

        Dim llngCnt As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@画面情報を構造体へ格納する
            With mtypExcpReport
                .strFindTelNo = txtTelNo.Text                   '発見職場Tel
                .strExcpItemName = lbl1Name.Text             '工程異常名
                
                '@工程異常項目
        '@↓2017/07/21 (Fri) 11:39:20 Y.Yoneyama **************************************************
                'For llngCnt = CMlngIndex1 To CMlngIndex7
                For llngCnt = CMlngIndex1 To CMlngIndex8
        '@↑2017/07/21 (Fri) 11:39:20 Y.Yoneyama **************************************************
                    '@ｵﾌﾟｼｮﾝ選択による情報ｾｯﾄ
                    If CType(Me.fra2.Controls("opt2Excp" & llngCnt.ToString),RadioButton).Checked = True Then
                        .strExcpItemNo = llngCnt
                        
                        If llngCnt = CMlngIndex7 Then           'その他ｺﾒﾝﾄ
                            .strExcpItemOthr = txt2Comments.Text
                        Else
                            .strExcpItemOthr = vbNullString
                        End If
                    End If
                Next llngCnt
                
                '@機種
                .strTargetPDID = cmbPdID.Text
                
                '@発見日時
                .strFindDate = calFindDate.Value & CMstrBrank & medFindTime.Text & ":00"
                
                '@大工程
                .strFindOpID = cmbOpID.Text
                
                '@小工程
                .strFindStepID = cmbStepID.Text
                
                '@装置
                .strFindWpID = mstrWpID
                .strFindWpName = mstrWpName
                
                '@工程異常発生状況
                .strExcpSituation = txt3_6Comments0.Text
                
                '@不適合品発生有無
                Select Case True
                    Case opt3_7umu0.Checked
                    '@工程異常処理票
                        .strIncongFlag = CMlngIndex0
                        .strDocClass = CMstrIncongFlag0
                        
                    Case opt3_7umu1.Checked
                    '@不適合品処理票
                        .strIncongFlag = CMlngIndex1
                        .strDocClass = CMstrIncongFlag1
                End Select
                
                .strExcpDetailComments = txt3_7Comments.Text
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
    '機　能：工程異常処置欄4の情報格納
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:08 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:08
    '備　考：
    Private Sub prvtab2_Set()

        Try

            '@画面情報を構造体へ格納する
            With mtypExcpReport
                '@後工程/信頼性影響
                If opt4ProcInfl0.Checked = True Then
                    .strInflFlag = CMlngIndex0
                Else
                    .strInflFlag = CMlngIndex1
                End If
                
                '@確認内容
                .strTechInflContents = txt4Comments0.Text                                           '技術
                .strManuInflContents = txt4Comments1.Text                                           '製造
                .strOthrInflContents = txt4Comments2.Text                                           'その他
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

    '関数名：prvtab3_Set
    '機　能：工程異常処置欄5～6の情報格納
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:10 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:10
    '備　考：
    Private Sub prvtab3_Set()

        Try

            '@画面情報を構造体へ格納する
            With mtypExcpReport
                '@原因
                .strTechInvestContents = txt5Comments0.Text                                         '技術
                .strManuInvestContents = txt5Comments1.Text                                         '製造
                .strOthrInvestContents = txt5Comments2.Text                                         'その他
            
                '@指示内容・指示帳票名
                .strTechIndicateContents = txt6Comments0.Text                                       '技術
                .strManuIndicateContents = txt6Comments1.Text                                       '製造
                .strOthrIndicateContents = txt6Comments2.Text                                       'その他
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab3_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab4_Set
    '機　能：不適合品処置欄1～2の情報格納
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:13 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:13
    '備　考：
    Private Sub prvtab4_Set()

        Try

            '@画面情報を構造体へ格納する
            With mtypExcpReport
                .strIncongItemName = lblIncName.Text                                             '不良特性名

                '@確認根拠
                .strTechCheckContents = txtInc1Comments0.Text                                    '技術
                .strManuCheckContents = txtInc1Comments1.Text                                    '製造
                .strOthrCheckContents = txtInc1Comments2.Text                                    'その他
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab4_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab5_Set
    '機　能：不適合品処置欄3～5の情報格納
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:15 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:15
    '備　考：
    Private Sub prvtab5_Set()

        Try

            '@画面情報を構造体へ格納する
            With mtypExcpReport
                '@3 不適合品発生量
                If opt3Gen0.Checked = True Then                         'a
                    .strIncongJudgeVolume = CMlngIndex1
                End If
                If opt3Gen1.Checked = True Then                         'b
                    .strIncongJudgeVolume = CMlngIndex2
                End If
                If opt3Gen2.Checked = True Then                         'c
                    .strIncongJudgeVolume = CMlngIndex3
                End If
        '@↓2017/07/21 (Fri) 11:44:57 Y.Yoneyama **************************************************
                If opt3Gen3.Checked = True Then                         'd
                    .strIncongJudgeVolume = CMlngIndex4
                End If
        '@↑2017/07/21 (Fri) 11:44:57 Y.Yoneyama **************************************************
                
                '@4 現品処理方法
                Dim lstrBoolKind As String
                '廃却
                If chk4Treat1.Checked Then
                    lstrBoolKind = "1"
                Else
                    lstrBoolKind = "0"
                End If
                .strDispoScrapFlag = lstrBoolKind

                '手直し
                If chk4Treat2.Checked Then
                    lstrBoolKind = "1"
                Else
                    lstrBoolKind = "0"
                End If
                .strDispoMdifyFlag = lstrBoolKind

                '特採
                If chk4Treat3.Checked Then
                    lstrBoolKind = "1"
                Else
                    lstrBoolKind = "0"
                End If
                .strDispoPickFlag = lstrBoolKind

                '通常
                If chk4Treat4.Checked Then
                    lstrBoolKind = "1"
                Else
                    lstrBoolKind = "0"
                End If
                .strDispoRegularFlag = lstrBoolKind

                '修正
                If chk4Treat5.Checked Then
                    lstrBoolKind = "1"
                Else
                    lstrBoolKind = "0"
                End If
                .strDispoAmendFlag = lstrBoolKind

                '評価
                If chk4Treat6.Checked Then
                    lstrBoolKind = "1"
                Else
                    lstrBoolKind = "0"
                End If
                .strDispoRatingFlag = lstrBoolKind
                
                '@4 帳票名
                .strDispoContents = txtInc4Comments.Text
                
                '@継続的改善
                If optCut0.Checked = True Then                          '低減
                    .strImproKind = CMlngIndex1
                End If
                If optCut1.Checked = True Then                          '低減
                    .strImproKind = CMlngIndex2
                End If
                .strImproContents = txtInc5Comments.Text                'ｺﾒﾝﾄ
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab5_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab6_Set
    '機　能：登録情報処置の情報格納
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:18 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:18
    '備　考：
    Private Sub prvtab6_Set()

        Dim llngCnt             As Integer          '汎用ｶｳﾝﾀ
        Dim lblnDispose         As Boolean          '処置ﾌﾗｸﾞ
        Dim llngTargetNum       As Integer          '対象数量計算値格納変数

        Try

            '@画面情報を構造体へ格納する
            With mtypExcpReport
                .strCauseWpID = mstrCauseWpID                                   '原因装置ID
                .strCauseWpName = mstrCauseWpName                               '原因装置名
                .strCauseSeriesName = cmbCauseSeries.Text                       '原因系列
                .strCauseClassName = cmbCauseKubun.Text                         '原因区分
                        
                '@ﾛｯﾄの情報を格納する
                '@内容を一度ｸﾘｱする
                .typExcpLotList = New List(Of ExcpLot)
                .lngExcpReportLotListCnt = 0
                
                '@ﾛｯﾄ情報が存在する場合
                If vsfLotList.Rows.Count > 1 Then
                    '@領域を再度確保する
                    .lngExcpReportLotListCnt = vsfLotList.Rows.Count - 1
                    'ReDim Preserve .typExcpLotList(.lngExcpReportLotListCnt)
                    '@領域内へ情報を格納
                    For llngCnt = 1 To vsfLotList.Rows.Count - 1

                        'NSYS 編集用構造体初期化
                        Dim typExcpLotListTmp As ExcpLot

                        typExcpLotListTmp.strLotID _
                            = vsfLotList.GetData(llngCnt, CMlngvsfColLotID)                                        'ﾛｯﾄID

                        '対象枚数
                        Dim strTargetQuantityTmp As String = vsfLotList.GetData(llngCnt, CMlngvsfColTarget)
                        If IsNumeric(strTargetQuantityTmp) Then
                            strTargetQuantityTmp = Format$(CLng(vsfLotList.GetData(llngCnt, CMlngvsfColTarget)), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strTargetQuantity = strTargetQuantityTmp
                        
                        '保留
                        Dim strReserveQuantityTmp As String = vsfLotList.GetData(llngCnt, CMlngvsfColHold)
                        If IsNumeric(strReserveQuantityTmp) Then
                            strReserveQuantityTmp = Format$(CLng(vsfLotList.GetData(llngCnt, CMlngvsfColHold)), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strReserveQuantity = strReserveQuantityTmp
                        
                        '廃却
                        Dim strAbandonQuantityTmp As String = vsfLotList.GetData(llngCnt, CMlngvsfColReject)
                        If IsNumeric(strAbandonQuantityTmp) Then
                            strAbandonQuantityTmp = Format$(CLng(vsfLotList.GetData(llngCnt, CMlngvsfColReject)), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strAbandonQuantity = strAbandonQuantityTmp
                        
                        '手直
                        Dim strAmendQuantityTmp As String = vsfLotList.GetData(llngCnt, CMlngvsfColReadjust)
                        If IsNumeric(strAmendQuantityTmp) Then
                            strAmendQuantityTmp = Format$(CLng(vsfLotList.GetData(llngCnt, CMlngvsfColReadjust)), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strAmendQuantity = strAmendQuantityTmp

                        '修正
                        Dim strCorrectQuantityTmp As String = vsfLotList.GetData(llngCnt, CMlngvsfColRevision)
                        If IsNumeric(strCorrectQuantityTmp) Then
                            strCorrectQuantityTmp = Format$(CLng(vsfLotList.GetData(llngCnt, CMlngvsfColRevision)), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strCorrectQuantity = strCorrectQuantityTmp
                        
                        '通常
                        Dim strUsualQuantityTmp As String = vsfLotList.GetData(llngCnt, CMlngvsfColNormal)
                        If IsNumeric(strUsualQuantityTmp) Then
                            strUsualQuantityTmp = Format$(CLng(vsfLotList.GetData(llngCnt, CMlngvsfColNormal)), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strUsualQuantity = strUsualQuantityTmp
                        
                        '評価
                        Dim strEvalQuantityTmp As String = vsfLotList.GetData(llngCnt, CMlngvsfColTest)
                        If IsNumeric(strEvalQuantityTmp) Then
                            strEvalQuantityTmp = Format$(CLng(vsfLotList.GetData(llngCnt, CMlngvsfColTest)), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strEvalQuantity = strEvalQuantityTmp
                        
                        '特採
                        Dim strTakeQuantityTmp As String = vsfLotList.GetData(llngCnt, CMlngvsfColSpecial)
                        If IsNumeric(strTakeQuantityTmp) Then
                            strTakeQuantityTmp = Format$(CLng(vsfLotList.GetData(llngCnt, CMlngvsfColSpecial)), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strTakeQuantity = strTakeQuantityTmp
                        
                        '合計
                        Dim strTotalQuantityTmp As String = vsfLotList.GetData(llngCnt, CMlngvsfColTotal)
                        If IsNumeric(strTotalQuantityTmp) Then
                            strTotalQuantityTmp = Format$(CLng(vsfLotList.GetData(llngCnt, CMlngvsfColTotal)), CPstrNoKanmaFormat)

                            '対象数量計算
                            llngTargetNum = llngTargetNum + strTotalQuantityTmp
                        End If
                        typExcpLotListTmp.strTotalQuantity = strTotalQuantityTmp
            
                        typExcpLotListTmp.strDisposalFlag _
                            = vsfLotList.GetData(llngCnt, CMlngvsfColDisposeFlag)                                  '処置ﾌﾗｸﾞ
            
                        typExcpLotListTmp.strHoldFlag _
                            = vsfLotList.GetData(llngCnt, CMlngvsfColHoldFlag)                                     '保留ﾌﾗｸﾞ
            
                        typExcpLotListTmp.strAppendFlag _
                            = vsfLotList.GetData(llngCnt, CMlngvsfColAppend)                                       '追加
            
                        typExcpLotListTmp.strEditTime _
                            = vsfLotList.GetData(llngCnt, CMlngvsfColLastUpdate)                                   '最終更新日時
            
                        'NSYS 編集済み構造体追加
                        .typExcpLotList.Add(typExcpLotListTmp)

                    Next llngCnt
                    
                    '@対象数量計算値
                    .strTargetQuantity = llngTargetNum
                    
                    '@処置の状態を取得
                    lblnDispose = False                         '初期化
                    For llngCnt = 1 To vsfLotList.Rows.Count - 1
                        If vsfLotList.GetData(llngCnt, CMlngvsfColDisposeFlag) <> CMstrWk Then
                            '@ﾌﾗｸﾞを立てる
                            lblnDispose = True
                            
                            Exit For
                        End If
                    Next llngCnt
                    
                    '@ﾌﾗｸﾞによる判別
                    If lblnDispose = True Then
                        '@未処置
                        .strAllDisposalFlag = CMlngIndex0
                    Else
                        '@処置済
                        .strAllDisposalFlag = CMlngIndex1
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab6_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab1_Lock
    '機　能：工程異常処置欄1～3のｺﾝﾄﾛｰﾙﾛｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:05 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:05
    '備　考：
    Private Sub prvtab1_Lock()

        Try

            '@ｺﾝﾄﾛｰﾙのﾛｯｸ処理
            '@電話番号ｺﾝﾄﾛｰﾙのﾛｯｸ
            txtTelNo.Locked = True
            
            '@工程異常名取得ﾎﾞﾀﾝ
            cmdTrouble.Enabled = False
            
            '@工程異常項目のﾛｯｸ
            fra2.Enabled = False
            
            '@その他のﾃｷｽﾄﾎﾞｯｸｽをﾛｯｸ
            txt2Comments.Locked = True
            
            '@機種ｺﾝﾎﾞのﾛｯｸ
            cmbPdID.Enabled = False
            
            '@対象数量のﾛｯｸ
            txt3_30.Locked = True
            
            '@発見日時のﾛｯｸ
            calFindDate.Enabled = False
            medFindTime.Enabled = False
            
            '@大工程のﾛｯｸ
            cmbOpID.Enabled = False
            
            '@小工程のﾛｯｸ
            cmbStepID.Enabled = False
            
            '@装置のﾛｯｸ
            cmbWpID.Enabled = False
            
            '@ｺﾒﾝﾄ欄のﾛｯｸ
            txt3_6Comments0.Locked = True
            
            '@不適合品発生有無
            fra3_7.Enabled = False
            
            '@ｺﾒﾝﾄ欄のﾛｯｸ
            txt3_7Comments.Locked = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：工程異常処置欄4のｺﾝﾄﾛｰﾙﾛｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:08 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:08
    '備　考：
    Private Sub prvtab2_Lock()

        Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ
        
        Try

            '@ｺﾝﾄﾛｰﾙのﾛｯｸ処理
            '@後工程/信頼性影響
            fraAf.Enabled = False
            
            '@ｻｲﾝ/ｷｬﾝｾﾙﾎﾞﾀﾝ・ｺﾒﾝﾄ欄
            For llngCnt = CMlngIndex0 To CMlngIndex2
                CType(Me.frassTab2.Controls("txt4Comments" & llngCnt.ToString),SETextBoxEx.TextBoxEx).Locked = True
                CType(Me.frassTab2.Controls("cmd4Sign" & llngCnt.ToString),Button).Enabled = False
                CType(Me.frassTab2.Controls("cmd4Cancel" & llngCnt.ToString),Button).Enabled = False
            Next llngCnt
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab2_Lock"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab3_Lock
    '機　能：工程異常処置欄5～6のｺﾝﾄﾛｰﾙﾛｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:10 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:10
    '備　考：
    Private Sub prvtab3_Lock()

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ

        Try

            '@ｺﾝﾄﾛｰﾙのﾛｯｸ処理
            '@原因
            '@ｻｲﾝ/ｷｬﾝｾﾙﾎﾞﾀﾝ・ｺﾒﾝﾄ欄
            For llngCnt = CMlngIndex0 To CMlngIndex2
                CType(Me.frassTab3.Controls("txt5Comments" & llngCnt.ToString),SETextBoxEx.TextBoxEx).Locked = True
                CType(Me.frassTab3.Controls("cmd5Sign" & llngCnt.ToString),Button).Enabled = False
                CType(Me.frassTab3.Controls("cmd5Cancel" & llngCnt.ToString),Button).Enabled = False
            Next llngCnt

            '@指示内容・指示帳票名
            '@ｻｲﾝ/ｷｬﾝｾﾙﾎﾞﾀﾝ・ｺﾒﾝﾄ欄
            For llngCnt = CMlngIndex0 To CMlngIndex2
                CType(Me.frassTab3.Controls("txt6Comments" & llngCnt.ToString),SETextBoxEx.TextBoxEx).Locked = True
                CType(Me.frassTab3.Controls("cmd6Sign" & llngCnt.ToString),Button).Enabled = False
                CType(Me.frassTab3.Controls("cmd6Cancel" & llngCnt.ToString),Button).Enabled = False
            Next llngCnt

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab3_Lock"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab4_Lock
    '機　能：不適合品処置欄1～2のｺﾝﾄﾛｰﾙﾛｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:13 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:13
    '備　考：
    Private Sub prvtab4_Lock()

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ

        Try

            '@ｺﾝﾄﾛｰﾙのﾛｯｸ処理
            cmdIncong.Enabled = False                       '不良特性名
            
            '@確認根拠
            '@ｻｲﾝ/ｷｬﾝｾﾙﾎﾞﾀﾝ・ｺﾒﾝﾄ欄
            For llngCnt = CMlngIndex0 To CMlngIndex2
                CType(Me.frassTab4.Controls("txtInc1Comments" & llngCnt.ToString),SETextBoxEx.TextBoxEx).Locked = True
                CType(Me.frassTab4.Controls("cmdInc1Sign" & llngCnt.ToString),Button).Enabled = False
                CType(Me.frassTab4.Controls("cmdInc1Cancel" & llngCnt.ToString),Button).Enabled = False
            Next llngCnt
            
            '@機種ｺﾝﾎﾞのﾛｯｸ
            cmbPdIDDisp.Enabled = False
            
            '@対象数量のﾛｯｸ
            txt3_31.Locked = True
            
            '@発見日時のﾛｯｸ
            calFindDateDisp.Enabled = False
            medFindTimeDisp.Enabled = False
            
            '@大工程のﾛｯｸ
            cmbOpIDDisp.Enabled = False
            
            '@小工程のﾛｯｸ
            cmbStepIDDisp.Enabled = False
            
            '@装置のﾛｯｸ
            cmbWpIDDisp.Enabled = False
            
            '@ｺﾒﾝﾄ欄のﾛｯｸ
            txt3_6Comments1.Locked = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab4_Lock"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab5_Lock
    '機　能：不適合品処置欄3～5のｺﾝﾄﾛｰﾙﾛｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:15 S.Deguchi
    '更新日：2005/08/09 (Tue) 10:51:15
    '備　考：
    Private Sub prvtab5_Lock()

        Try

            '@ｺﾝﾄﾛｰﾙのﾛｯｸ処理
            fraGen.Enabled = False                      '3.確認
            cmdInc3Sign.Enabled = False                 '3.ｻｲﾝ
            cmdInc3Cancel.Enabled = False               'ｷｬﾝｾﾙ
            
            fra4.Enabled = False                        '4.ﾌﾗｸﾞ
            txtInc4Comments.Locked = True
            cmdInc4Sign.Enabled = False                 '4.ｻｲﾝ
            cmdInc4Cancel.Enabled = False               'ｷｬﾝｾﾙ
            
            fraCut.Enabled = False                      '5.削減/低減
            txtInc5Comments.Locked = True
            cmdInc5Sign.Enabled = False                 '5.ｻｲﾝ
            cmdInc5Cancel.Enabled = False               'ｷｬﾝｾﾙ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab5_Lock"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab6_Lock
    '機　能：登録情報処置のｺﾝﾄﾛｰﾙﾛｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2005/08/09 (Tue) 10:51:18 S.Deguchi
    '更新日：2008/02/20 (Wed) 09:45:53 M.Koni
    '備　考：
    '　　　：2008/02/20 (Wed) 09:45:53 M.Koni        prvtab6_Lock() Disable化追加。(案件No.02547)
    Private Sub prvtab6_Lock()

        Try

            '@ｺﾝﾄﾛｰﾙのﾛｯｸ処理
            cmdLotAdd.Enabled = False                   'ﾛｯﾄ入力
            cmdLotWk.Enabled = False                    'ﾛｯﾄ処置決定
            cmdLotWkCorrect.Enabled = False             'ﾛｯﾄ処置訂正
            cmdWpWk.Enabled = False                     '装置処置
            
            cmdWorkMiss.Enabled = True                  '作業ﾐｽ報告書
            cmdCauseNo.Enabled = False                  '原因不明
            
            fraCause.Enabled = False                    '原因関連
            
            '@各種ｺﾝﾄﾛｰﾙ無効化
            cmbCauseWpID.Enabled = False                '「原因装置」ｺﾝﾎﾞ
            cmbCauseSeries.Enabled = False              '「原因系列」ｺﾝﾎﾞ
            cmbCauseKubun.Enabled = False               '「原因区分」ｺﾝﾎﾞ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab6_Lock"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab4_Clear
    '機　能：不適合品処置欄1～2の登録内容のｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 13:30:55 S.Deguchi
    '更新日：2005/08/09 (Tue) 13:30:55
    '備　考：
    Private Sub prvtab4_Clear()

        Try

            '@構造体の内容をｸﾘｱする
            With mtypExcpReport
                .strIncongItemName = vbNullString           '不良特性名

                '@確認根拠
                .strTechCheckContents = vbNullString        '技術
                .strTechCheckDate = vbNullString            '入力日付
                .strTechCheckEmpID = vbNullString           '入力担当者ID
                .strTechCheckEmpName = vbNullString         '入力担当者名
                    
                .strManuCheckContents = vbNullString        '製造
                .strManuCheckDate = vbNullString            '入力日付
                .strManuCheckEmpID = vbNullString           '入力担当者ID
                .strManuCheckEmpName = vbNullString         '入力担当者名
                    
                .strOthrCheckContents = vbNullString        'その他
                .strOthrCheckDate = vbNullString            '入力日付
                .strOthrCheckEmpID = vbNullString           '入力担当者ID
                .strOthrCheckEmpName = vbNullString         '入力担当者名
            End With

            '@画面情報をｸﾘｱする
            Call prvtab4_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab4_Clear"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtab5_Clear
    '機　能：不適合品処置欄3～5の登録内容のｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 13:30:58 S.Deguchi
    '更新日：2005/08/09 (Tue) 13:30:58
    '備　考：
    Private Sub prvtab5_Clear()

        Try

            '@構造体の内容をｸﾘｱする
            With mtypExcpReport
                .strIncongJudgeVolume = CMlngIndex0         '不適合品発生量・率確認

                .strIncongJudgeDate = vbNullString          '入力日付
                .strIncongJudgeEmpID = vbNullString         '入力担当者ID
                .strIncongJudgeEmpName = vbNullString       '入力担当者名

                .strDispoScrapFlag = CMlngIndex0            '廃却
                .strDispoMdifyFlag = CMlngIndex0            '手直
                .strDispoPickFlag = CMlngIndex0             '特採
                .strDispoRegularFlag = CMlngIndex0          '通常
                .strDispoAmendFlag = CMlngIndex0            '修正
                .strDispoRatingFlag = CMlngIndex0           '評価
                
                .strDispoContents = vbNullString            '処理
                .strDispoIndicateDate = vbNullString        '入力日付
                .strDispoIndicateEmpID = vbNullString       '入力担当者ID
                .strDispoIndicateEmpName = vbNullString     '入力担当者名
                    
                .strImproKind = CMlngIndex0                 '改善取組
                .strImproContents = vbNullString            '改善内容
                .strImproDate = vbNullString                '入力日付
                .strImproEmpID = vbNullString               '入力担当者ID
                .strImproEmpName = vbNullString             '入力担当者名
            End With

            '@画面情報をｸﾘｱする
            Call prvtab5_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtab5_Clear"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotList_Init
    '機　能：ﾛｯﾄ処置決定欄の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/10 (Tue) 10:07:17 S.Deguchi
    '更新日：2004/08/10 (Tue) 10:07:17
    '備　考：
    Private Sub prvvsfLotList_Init()

        Try

            With vsfLotList
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                '.ExplorerBar = flexExSortShow
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                '.FillStyle = flexFillRepeat
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowBigSelection = False
                
                '@ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Row
                
                '@ﾌｫﾝﾄｻｲｽﾞ指定(=11)
                .Styles.Normal.Font = New Font(.Font.FontFamily, CMlngvsfFontSizeBig, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)

                '@一覧表の表題設定
                '@表示位置の設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_vsfLotList_Header")
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfColNo, CMlngVsfRowTitle, .Cols.Count - 1)
                newStyle.TextAlign = TextAlignEnum.CenterCenter                                                                                   'ﾀｲﾄﾙ(中央寄せ中央揃え)
                newStyle.Font = New Font(.Font.FontFamily, CMlngvsfHFontSizeBig, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont) 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                cellRange.Style = newStyle

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfColNo, CMstrvsfColNo)                      '№
                .SetData(CMlngVsfRowTitle, CMlngvsfColHoldSign, CMstrvsfColHoldSign)          '保
                .SetData(CMlngVsfRowTitle, CMlngvsfColLotID, CMstrvsfColLotID)                'ﾛｯﾄID
                .SetData(CMlngVsfRowTitle, CMlngvsfColWF, CMstrvsfColWF)                      '対象WF
                .SetData(CMlngVsfRowTitle, CMlngvsfColHold, CMstrvsfColHold)                  '保留
                .SetData(CMlngVsfRowTitle, CMlngvsfColReject, CMstrvsfColReject)              '廃却
                .SetData(CMlngVsfRowTitle, CMlngvsfColReadjust, CMstrvsfColReadjust)          '手直し流動
                .SetData(CMlngVsfRowTitle, CMlngvsfColRevision, CMstrvsfColRevision)          '修正流動
                .SetData(CMlngVsfRowTitle, CMlngvsfColNormal, CMstrvsfColNormal)              '通常流動
                .SetData(CMlngVsfRowTitle, CMlngvsfColTest, CMstrvsfColTest)                  '評価流動
                .SetData(CMlngVsfRowTitle, CMlngvsfColSpecial, CMstrvsfColSpecial)            '特採流動
                .SetData(CMlngVsfRowTitle, CMlngvsfColTotal, CMstrvsfColTotal)                '合計
                .SetData(CMlngVsfRowTitle, CMlngvsfColDispose, CMstrvsfColDispose)            '処置
                .SetData(CMlngVsfRowTitle, CMlngvsfColDisposeFlag, CMstrvsfColDisposeFlag)    '処置ﾌﾗｸﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfColHoldFlag, CMstrvsfColHoldFlag)          '保留ﾌﾗｸﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfColAppend, CMstrvsfColAppend)              '追加
                .SetData(CMlngVsfRowTitle, CMlngvsfColTarget, CMstrvsfColTarget)              '対象枚数
                .SetData(CMlngVsfRowTitle, CMlngvsfColLastUpdate, CMstrvsfColLastUpdate)      '最終更新日時

                '@列幅設定
                .Cols(CMlngvsfColNo).Width = CMlngvsfWColNo                   '№
                .Cols(CMlngvsfColHoldSign).Width = CMlngvsfWColHoldSign       '保
                .Cols(CMlngvsfColLotID).Width = CMlngvsfWColLotID             'ﾛｯﾄID
                .Cols(CMlngvsfColWF).Width = CMlngvsfWColWF                   '対象WF
                .Cols(CMlngvsfColHold).Width = CMlngvsfWColHold               '保留
                .Cols(CMlngvsfColReject).Width = CMlngvsfWColReject           '廃却
                .Cols(CMlngvsfColReadjust).Width = CMlngvsfWColReadjust       '手直し流動
                .Cols(CMlngvsfColRevision).Width = CMlngvsfWColRevision       '修正流動
                .Cols(CMlngvsfColNormal).Width = CMlngvsfWColNormal           '通常流動
                .Cols(CMlngvsfColTest).Width = CMlngvsfWColTest               '評価流動
                .Cols(CMlngvsfColSpecial).Width = CMlngvsfWColSpecial         '特採流動
                .Cols(CMlngvsfColTotal).Width = CMlngvsfWColTotal             '合計
                .Cols(CMlngvsfColDispose).Width = CMlngvsfWColDispose         '処置
                .Cols(CMlngvsfColDisposeFlag).Width = CMlngvsfWColDisposeFlag '処置ﾌﾗｸﾞ
                .Cols(CMlngvsfColHoldFlag).Width = CMlngvsfWColHoldFlag       '保留ﾌﾗｸﾞ
                .Cols(CMlngvsfColAppend).Width = CMlngvsfWColAppend           '追加
                .Cols(CMlngvsfColTarget).Width = CMlngvsfWColHoldFlag         '対象枚数
                .Cols(CMlngvsfColLastUpdate).Width = CMlngvsfWColAppend       '最終更新日時
                
                '@非表示列の設定
                .Cols(CMlngvsfColTotal).Visible = False
                .Cols(CMlngvsfColHoldFlag).Visible = False
                .Cols(CMlngvsfColDisposeFlag).Visible = False
                .Cols(CMlngvsfColAppend).Visible = False
                .Cols(CMlngvsfColTarget).Visible = False
                .Cols(CMlngvsfColLastUpdate).Visible = False
                
                '@列幅設定
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngvsfColNo, CMlngvsfColDispose, 6)
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngvsfHHeightBig                                       '高さ
                
                '@列データタイプ設定
                .Cols(CMlngvsfColNo).DataType = GetType(Int32)
                .Cols(CMlngvsfColWF).DataType = GetType(Int32)
                .Cols(CMlngvsfColHold).DataType = GetType(Int32)
                .Cols(CMlngvsfColReject).DataType = GetType(Int32)
                .Cols(CMlngvsfColReadjust).DataType = GetType(Int32)
                .Cols(CMlngvsfColRevision).DataType = GetType(Int32)
                .Cols(CMlngvsfColNormal).DataType = GetType(Int32)
                .Cols(CMlngvsfColTest).DataType = GetType(Int32)
                .Cols(CMlngvsfColSpecial).DataType = GetType(Int32)

                '@ﾛｯｸ
                'NSYS Initの外部へ移動
                '.Enabled = False
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light

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

    '関数名：prvvsfLotList_Disp
    '機　能：ﾛｯﾄ処置決定欄の新規登録時設定
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 13:39:05 S.Deguchi
    '更新日：2008/04/08 (Tue) 15:44:53 M.Koni
    '備　考：
    '　　　：2008/04/08 (Tue) 15:45:10 M.Koni       登録情報処理画面の「対象」の欄の表示方法変更 <案件No.02755>
    Private Sub prvvsfLotList_Disp()

        Dim llngDoCnt   As Integer  'ｶｳﾝﾄ

        Try
            
            With vsfLotList
                If mtypExcpReport.lngExcpReportLotListCnt <> 0 Then
                '@格納ﾃﾞｰﾀがあるの場合

                    '@描画ﾛｯｸ
                    .Redraw = False

                    '@まず初期化
                    Call prvvsfLotList_Init()
            
                    '@行数設定
                    RemoveHandler vsfLotList.RowColChange,AddressOf vsfLotList_RowColChange
                    .Rows.Count = mtypExcpReport.lngExcpReportLotListCnt + 1
                    .Row = 0 'NSYS ヘッダー選択
                    AddHandler vsfLotList.RowColChange,AddressOf vsfLotList_RowColChange
                    
                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1

                    Do While .Rows.Count > llngDoCnt
                        '@ﾛｯﾄ一覧表示情報設定
                        .SetData(llngDoCnt, CMlngvsfColNo, llngDoCnt)                 '通し番号

                        .SetData(llngDoCnt, CMlngvsfColLotID, _
                            mtypExcpReport.typExcpLotList(llngDoCnt - 1).strLotID)                   'ﾛｯﾄID

                        '保留
                        Dim strReserveQuantityTmp As String = vbNullString
                        If IsNumeric(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strReserveQuantity) Then
                            strReserveQuantityTmp = Format$(CLng(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strReserveQuantity), CPstrDateFormatKanma)
                        End If
                        .SetData(llngDoCnt, CMlngvsfColHold, strReserveQuantityTmp)

                        '廃却
                        Dim strAbandonQuantityTmp As String = vbNullString
                        If IsNumeric(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strAbandonQuantity) Then
                            strAbandonQuantityTmp = Format$(CLng(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strAbandonQuantity), CPstrDateFormatKanma)
                        End If
                        .SetData(llngDoCnt, CMlngvsfColReject, strAbandonQuantityTmp)

                        '手直し流動
                        Dim strAmendQuantityTmp As String = vbNullString
                        If IsNumeric(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strAmendQuantity) Then
                            strAmendQuantityTmp = Format$(CLng(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strAmendQuantity), CPstrDateFormatKanma)
                        End If
                        .SetData(llngDoCnt, CMlngvsfColReadjust, strAmendQuantityTmp)

                        '修正流動
                        Dim strCorrectQuantityTmp As String = vbNullString
                        If IsNumeric(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strCorrectQuantity) Then
                            strCorrectQuantityTmp = Format$(CLng(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strCorrectQuantity), CPstrDateFormatKanma)
                        End If
                        .SetData(llngDoCnt, CMlngvsfColRevision, strCorrectQuantityTmp)

                        '通常流動
                        Dim strUsualQuantityTmp As String = vbNullString
                        If IsNumeric(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strUsualQuantity) Then
                            strUsualQuantityTmp = Format$(CLng(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strUsualQuantity), CPstrDateFormatKanma)
                        End If
                        .SetData(llngDoCnt, CMlngvsfColNormal, strUsualQuantityTmp)

                        '評価流動
                        Dim strEvalQuantityTmp As String = vbNullString
                        If IsNumeric(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strEvalQuantity) Then
                            strEvalQuantityTmp = Format$(CLng(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strEvalQuantity), CPstrDateFormatKanma)
                        End If
                        .SetData(llngDoCnt, CMlngvsfColTest, strEvalQuantityTmp)

                        '特採流動
                        Dim strTakeQuantityTmp As String = vbNullString
                        If IsNumeric(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strTakeQuantity) Then
                            strTakeQuantityTmp = Format$(CLng(mtypExcpReport.typExcpLotList(llngDoCnt - 1).strTakeQuantity), CPstrDateFormatKanma)
                        End If
                        .SetData(llngDoCnt, CMlngvsfColSpecial, strTakeQuantityTmp)

                        '@対象がNullの場合には,"0"をｾｯﾄ
                        If mtypExcpReport.typExcpLotList(llngDoCnt - 1).strTargetQuantity <> vbNullString Then
                            .SetData(llngDoCnt, CMlngvsfColTarget, _
                                mtypExcpReport.typExcpLotList(llngDoCnt - 1).strTargetQuantity)    '対象
                        Else
                            .SetData(llngDoCnt, CMlngvsfColTarget, "0")                            '対象
                        End If
                        
                        '@合計数量がNullの場合には"0"をｾｯﾄ
                        If mtypExcpReport.typExcpLotList(llngDoCnt - 1).strTotalQuantity <> vbNullString Then
                            .SetData(llngDoCnt, CMlngvsfColTotal, _
                                mtypExcpReport.typExcpLotList(llngDoCnt - 1).strTotalQuantity)     '合計
                        Else
                            .SetData(llngDoCnt, CMlngvsfColTotal, "0")                             '合計
                        End If

                        .SetData(llngDoCnt, CMlngvsfColHoldFlag, _
                            mtypExcpReport.typExcpLotList(llngDoCnt - 1).strHoldFlag)              '保留ﾌﾗｸﾞ

                        .SetData(llngDoCnt, CMlngvsfColAppend, CMlngIndex0)                        '追加ﾌﾗｸﾞ(:0=初期化)

                        .SetData(llngDoCnt, CMlngvsfColDisposeFlag, _
                            mtypExcpReport.typExcpLotList(llngDoCnt - 1).strDisposalFlag)          '処置ﾌﾗｸﾞ

                        '@保留ﾏｰｸ表示
                        Select Case mtypExcpReport.typExcpLotList(llngDoCnt - 1).strHoldFlag
                            Case CMstrHoldFlag
                                .SetData(llngDoCnt, CMlngvsfColHoldSign, CMstrHoldSign)   '保留
                            Case Else
                                .SetData(llngDoCnt, CMlngvsfColHoldSign, vbNullString)    'Null
                        End Select
                        
                        '@処置
                        Select Case mtypExcpReport.typExcpLotList(llngDoCnt - 1).strDisposalFlag
                            Case CMstrWkNo
                                .SetData(llngDoCnt, CMlngvsfColDispose, vbNullString) '未処置

                            Case CMstrWk
                                .SetData(llngDoCnt, CMlngvsfColDispose, CMstrSumi)    '処置済

                            Case Else
                                .SetData(llngDoCnt, CMlngvsfColDispose, vbNullString) '未処置(初期設定)
                        End Select

        '@↓2008/04/07 (Mon) 15:51:30 M.Koni **************************************************
                        '@対象(対象数量 / 合計数量)
        '                .Cell(flexcpText, llngDoCnt, CMlngvsfColWF) = _
        '                    Format$(.Cell(flexcpText, llngDoCnt, CMlngvsfColTarget), CPstrDateFormatKanma) & _
        '                    CMstrSrash & _
        '                    Format$(.Cell(flexcpText, llngDoCnt, CMlngvsfColTotal), CPstrDateFormatKanma)
                        'NSYS 数値変換
                        Dim lstrColWFTmp As String = .GetData(llngDoCnt, CMlngvsfColTarget)
                        If IsNumeric(lstrColWFTmp) Then
                            lstrColWFTmp = Format$(CLng(.GetData(llngDoCnt, CMlngvsfColTarget)), CPstrDateFormatKanma)
                        End If
                        .SetData(llngDoCnt, CMlngvsfColWF, lstrColWFTmp)
        '@↑2008/04/07 (Mon) 15:51:30 M.Koni **************************************************
                        
                        '@保留ﾌﾗｸﾞで判別
                        If mtypExcpReport.typExcpLotList(llngDoCnt - 1).strHoldFlag = CMstrHoldFlag Then
                            '@ﾊﾞｯｸｶﾗｰを黄色に設定
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" & llngDoCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        Else
                            '@ﾊﾞｯｸｶﾗｰを白に設定
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite" & llngDoCnt.ToString)
                            newStyle.BackColor = SystemColors.Window
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        End If
                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height = CMlngvsfHeightBig

                        '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                    Loop
            
                    '@列幅設定
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMlngvsfColNo, CMlngvsfColDispose, 6)
            
                    '@書式設定
                    .Cols(CMlngvsfColNo).TextAlign = TextAlignEnum.RightCenter
                    .Cols(CMlngvsfColLotID).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(CMlngvsfColWF).TextAlign = TextAlignEnum.RightCenter
                    .Cols(CMlngvsfColHold).TextAlign = TextAlignEnum.RightCenter
                    .Cols(CMlngvsfColReject).TextAlign = TextAlignEnum.RightCenter
                    .Cols(CMlngvsfColReadjust).TextAlign = TextAlignEnum.RightCenter
                    .Cols(CMlngvsfColRevision).TextAlign = TextAlignEnum.RightCenter
                    .Cols(CMlngvsfColNormal).TextAlign = TextAlignEnum.RightCenter
                    .Cols(CMlngvsfColTest).TextAlign = TextAlignEnum.RightCenter
                    .Cols(CMlngvsfColSpecial).TextAlign = TextAlignEnum.RightCenter
                    .Cols(CMlngvsfColDispose).TextAlign = TextAlignEnum.LeftCenter
                    
                    '@行列のﾏｳｽでの変更を不可設定にする
                    .AllowResizing = AllowResizingEnum.None
                                
                    '@描画ﾛｯｸ解除
                    .Redraw = True
                                            
                    '@ﾛｯｸ解除
                    .Enabled = True
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPdIDList_Disp
    '機　能：機種Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 08:50:41 S.Deguchi
    '更新日：2005/08/09 (Tue) 08:50:41
    '備　考：
    Private Sub prvcmbPdIDList_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbPdID
                '@機種ｺﾝﾎﾞ初期化
                .Clear
                .Height = CMlngCmbRowHeight                                     '高さ
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .DirectInput = False                                            '直接入力不可
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .BackColor = SystemColors.Window                                'ﾊﾞｯｸｶﾗｰ(白)

                '@機種情報ｾｯﾄ('機種ID&機種ID名称 & PDﾊﾞｰｼﾞｮﾝ & Null & ForeColor & BackColor)
                For llngCnt = 0 To mlngProductListCnt - 1
                    .AddItem(mtypProductList(llngCnt).strProductID & _
                            vbTab & _
                            mtypProductList(llngCnt).strProductName & _
                            vbTab & _
                            mtypProductList(llngCnt).strMasPdVersion & _
                            vbTab & _
                            vbNullString & _
                            vbTab & _
                            mtypProductList(llngCnt).strForeColor & _
                            vbTab & _
                            mtypProductList(llngCnt).strBackColor)
                Next llngCnt
                
                '@1件しか存在しない場合、ﾃﾞﾌｫﾙﾄ表示
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
                .strProcName = "prvcmbPdIDList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbOpIDList_Disp
    '機　能：依頼先大工程のｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 08:50:41 S.Deguchi
    '更新日：2005/08/09 (Tue) 08:50:41
    '備　考：
    Private Sub prvcmbOpIDList_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbOpID
                '@大工程ｺﾝﾎﾞ初期化
                .Clear
                .DirectInput = False                                            '直接入力不可
                .Height = CMlngCmbRowHeight                                     '高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .BackColor = SystemColors.Window                                'ﾊﾞｯｸｶﾗｰ(白)
                If mtypMasOpList.lngMasOpCnt > CmlngMaxRows Then                'ｸﾞﾙｰﾌﾟ
                    .GroupRows = CmlngMaxRows
                Else
                    .GroupRows = mtypMasOpList.lngMasOpCnt
                End If
                
                '@大工程情報ｾｯﾄ
                For llngCnt = 0 To mtypMasOpList.lngMasOpCnt - 1
                    .AddItem(mtypMasOpList.typMasOpId(llngCnt).strOpID)
                Next llngCnt
            
                '@1件しか存在しない場合、ﾃﾞﾌｫﾙﾄ表示
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
                .strProcName = "prvcmbOpIDList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbStepIDList_Disp
    '機　能：小工程ｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 08:50:41 S.Deguchi
    '更新日：2005/08/09 (Tue) 08:50:41
    '備　考：
    Private Sub prvcmbStepIDList_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbStepID
                '@小工程ｺﾝﾎﾞ初期化
                .Clear
                .DirectInput = False                                            '直接入力不可
                .Height = CMlngCmbRowHeight                                     '高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .BackColor = SystemColors.Window                                'ﾊﾞｯｸｶﾗｰ(白)
                If mtypMasStepList.lngMasStepCnt > CmlngMaxRows Then            'ｸﾞﾙｰﾌﾟ
                    .GroupRows = CmlngMaxRows
                Else
                    .GroupRows = mtypMasStepList.lngMasStepCnt
                End If
                
                '@小工程情報ｾｯﾄ
                For llngCnt = 0 To mtypMasStepList.lngMasStepCnt - 1
                    .AddItem(mtypMasStepList.typMasStepId(llngCnt).strStepID)
                Next llngCnt
            
                '@1件しか存在しない場合、ﾃﾞﾌｫﾙﾄ表示
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
                .strProcName = "prvcmbStepIDList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbWpIDList_Disp
    '機　能：装置Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 08:53:13 S.Deguchi
    '更新日：2005/08/09 (Tue) 08:53:13
    '備　考：
    Private Sub prvcmbWpIDList_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbWpID
                '@装置ｺﾝﾎﾞ初期化
                .Clear
                .RowHeight = CMlngCmbRowHeight                                  '高さ
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbGridCol1                                    '値取得列
                .DirectInput = False                                            '直接入力不可
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左中央
                .BackColor = SystemColors.Window                                'ﾊﾞｯｸｶﾗｰ(白)
                If mlngWpListCnt > CmlngMaxRows Then                            'ｸﾞﾙｰﾌﾟ
                    .GroupRows = CmlngMaxRows
                Else
                    .GroupRows = mtypMasStepList.lngMasStepCnt
                End If

                '@装置情報ｾｯﾄ(装置名＆装置ID)
                For llngCnt = 0 To mlngWpListCnt - 1
                    .AddItem(mtypWpList(llngCnt).strWpName & _
                             vbTab & _
                             mtypWpList(llngCnt).strWpID)
                Next llngCnt
            
                '@1件しか存在しない場合、ﾃﾞﾌｫﾙﾄ表示
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
                .strProcName = "prvcmbWpIDList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbCauseSeries_Disp
    '機　能：原因系列ｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 11:03:36 S.Deguchi
    '更新日：2005/08/09 (Tue) 11:03:36
    '備　考：
    Private Sub prvcmbCauseSeries_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbCauseSeries
                '@原因系列ｺﾝﾎﾞ初期化
                .Clear
                .DirectInput = False                                                '直接入力不可
                .Height = CMlngCmbRowHeight                                         '高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter          '左寄中央揃え
                .BackColor = SystemColors.Window                                    'ﾊﾞｯｸｶﾗｰ(白)
                If mtypTroubleItemList1.lngTroubleItemListCnt > CmlngMaxRows Then   'ｸﾞﾙｰﾌﾟ
                    .GroupRows = CmlngMaxRows
                Else
                    .GroupRows = mtypTroubleItemList1.lngTroubleItemListCnt
                End If
                
                '@原因系列情報ｾｯﾄ
                For llngCnt = 0 To mtypTroubleItemList1.lngTroubleItemListCnt - 1
                    .AddItem(mtypTroubleItemList1.typTroubleItemList(llngCnt).strItemName)
                Next llngCnt
                
                '@1件しか存在しない場合、ﾃﾞﾌｫﾙﾄ表示
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
                .strProcName = "prvcmbCauseSeries_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbCauseKubun_Disp
    '機　能：原因区分ｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 11:03:44 S.Deguchi
    '更新日：2005/08/09 (Tue) 11:03:44
    '備　考：
    Private Sub prvcmbCauseKubun_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbCauseKubun
                '@原因系列ｺﾝﾎﾞ初期化
                .Clear
                .DirectInput = False                                                '直接入力不可
                .Height = CMlngCmbRowHeight                                         '高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter          '左寄中央揃え
                .BackColor = SystemColors.Window                                    'ﾊﾞｯｸｶﾗｰ(白)
                If mtypTroubleItemList2.lngTroubleItemListCnt > CmlngMaxRows Then   'ｸﾞﾙｰﾌﾟ
                    .GroupRows = CmlngMaxRows
                Else
                    .GroupRows = mtypTroubleItemList2.lngTroubleItemListCnt
                End If
                
                '@原因系列情報ｾｯﾄ
                For llngCnt = 0 To mtypTroubleItemList2.lngTroubleItemListCnt - 1
                    .AddItem(mtypTroubleItemList2.typTroubleItemList(llngCnt).strItemName)
                Next llngCnt
            
                '@1件しか存在しない場合、ﾃﾞﾌｫﾙﾄ表示
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
                .strProcName = "prvcmbCauseKubun_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbCauseWpIDList_Disp
    '機　能：装置Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 08:53:13 S.Deguchi
    '更新日：2005/08/09 (Tue) 08:53:13
    '備　考：
    Private Sub prvcmbCauseWpIDList_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbCauseWpID
                '@装置ｺﾝﾎﾞ初期化
                .Clear
                .RowHeight = CMlngCmbRowHeight                                  '高さ
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbGridCol1                                    '値取得列
                .DirectInput = False                                            '直接入力不可
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左中央
                .BackColor = SystemColors.Window                                'ﾊﾞｯｸｶﾗｰ(白)
                If mlngWpListCnt > CmlngMaxRows Then                            'ｸﾞﾙｰﾌﾟ
                    .GroupRows = CmlngMaxRows
                Else
                    .GroupRows = mtypMasStepList.lngMasStepCnt
                End If

                '@装置情報ｾｯﾄ(装置名＆装置ID)
                For llngCnt = 0 To mlngWpListCnt - 1
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
                .strProcName = "prvcmbCauseWpIDList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnLotStepList_Sel
    '機　能：小工程取得処理
    '引　数：lstrOpID：大工程
    '戻り値：True：成功/False：失敗
    '作成日：2005/08/09 (Tue) 15:08:19 S.Deguchi
    '更新日：2008/02/25 (Mon) 18:23:26 M.Koni
    '備　考：
    '　　　：2008/01/22 (Tue) 10:28:07 N.Kojima     lot_.steplistの要求に"LOT_LIST"追加に関連して処理修正。(案件№02405)
    '　　　：2008/02/25 (Mon) 18:23:41 M.Koni       ﾛｯﾄﾘｽﾄが0件の場合の対応を追加。(案件No.02657)
    Private Function prvblnLotStepList_Sel(ByVal lstrOpID As String) As Boolean

        Dim lstrClassDivision   As String             'ClassDivision置換
        Dim lblnAns             As Boolean            '結果格納
        Dim llngCnt             As Integer            '汎用ｶｳﾝﾀ
        Dim llngLotCnt          As Integer            'ﾛｯﾄｶｳﾝﾄ
        Dim ltypLotList         As List(Of LotIdList) 'ﾛｯﾄﾘｽﾄ(引数合わせ用)

        Try

            '@初期化
            prvblnLotStepList_Sel = False
            
            '@処理区分=4E(工程情報のみ)を新規に設定し、この場合はアクション予約の情報を取得せず
            '@応答MsgのACTION_FLAGは常に""(空)で返却するようにする。
            lstrClassDivision = CPstrCD4E
            
            '@ﾛｯﾄﾘｽﾄのﾃﾞｰﾀ件数が1件以上あるか
            If mtypExcpReport.lngExcpReportLotListCnt <> 0 Then
                
                '@ﾛｯﾄﾘｽﾄを作成
                With vsfLotNo0
                    '@配列の定義
                    ltypLotList = New List(Of LotIdList)
                    For llngCnt = 0 To mtypExcpReport.lngExcpReportLotListCnt - 1

                        'NSYS 編集用構造体初期化
                        Dim ltypLotListTmp As LotIdList

                        '@ﾛｯﾄIDを格納
                        ltypLotListTmp.strLotID = mtypExcpReport.typExcpLotList(llngCnt).strLotID
                        llngLotCnt = llngLotCnt + 1

                        'NSYS 編集済み構造体追加
                        ltypLotList.Add(ltypLotListTmp)

                    Next llngCnt
                End With
            End If

            '@【小工程取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnLotStepList_Sel(mstrSBID, _
                                            CMstrlot_steplistVer, _
                                            lstrClassDivision, _
                                            ltypLotList, _
                                            mtypMasStepList, _
                                            lstrOpID, _
                                            llngLotCnt)

            '@結果判定
            If lblnAns = False Then
                Exit Function
            End If

            '@成功を返す
            prvblnLotStepList_Sel = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotStepList_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvcmdSign_Set
    '機　能：ｻｲﾝ機能の関数
    '引　数：なし
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/24 (Tue) 21:09:44 S.Deguchi
    '更新日：2004/08/24 (Tue) 21:09:44
    '備　考：
    Private Function prvblncmdSign_Set(ByRef lstrDateTime As String) As Boolean

        Try

            '@初期化
            prvblncmdSign_Set = False
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.Text = CPstrSubDispTitleSign
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Function
            Else
                '@時間取得
                lstrDateTime = Now
                
                '@成功
                prvblncmdSign_Set = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblncmdSign_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnExcpChgReport_Upd
    '機　能：工程異常/不適合品処理票登録処理
    '引　数：ltypExcpReport：登録構造体
    '　　　：lstrGuidMsg     ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：成功/False：失敗
    '作成日：2005/08/11 (Thu) 15:35:44 S.Deguchi
    '更新日：2005/08/11 (Thu) 15:35:44
    '備　考：
    Private Function prvblnExcpChgReport_Upd(ByRef ltypExcpReport As ExcpReport, _
                                             ByRef lstrGuidMsg As String, _
                                             ByRef lstrGuidMsgCode As String) As Boolean

        Dim lblnAns                 As Boolean              '結果格納

        Try

            '@初期化
            prvblnExcpChgReport_Upd = False
            
            '@工程異常/不適合品処理票情報登録
            lblnAns = pubblnExcpChgReport_Upd(ltypExcpReport, lstrGuidMsg, lstrGuidMsgCode)
            '@結果判定
            If lblnAns = False Then
                Exit Function
            End If
            
            '@成功を返す
            prvblnExcpChgReport_Upd = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnExcpChgReport_Upd"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvcmdWorkMissEnabled_Proc
    '機　能：作業ﾐｽ報告書ﾎﾞﾀﾝ活性化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/01 (Thu) 13:38:58 S.Deguchi
    '更新日：2005/09/01 (Thu) 13:38:58
    '備　考：
    Private Sub prvcmdWorkMissEnabled_Proc()

        Try

            '@原因装置/原因系列/原因区分が全て設定されている場合,作業ﾐｽﾎﾞﾀﾝ活性化
            If cmbCauseWpID.Text <> vbNullString And _
               cmbCauseSeries.Text <> vbNullString And _
               cmbCauseKubun.Text <> vbNullString Then
                '@作業ﾐｽ報告書ﾎﾞﾀﾝを活性化
                cmdWorkMiss.Enabled = True
            Else
                '@作業ﾐｽ報告書ﾎﾞﾀﾝを非活性化
                cmdWorkMiss.Enabled = False
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnExcpChgReport_Upd"
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfLotList.BeforeDoubleClick, vsfLotNo0.BeforeDoubleClick, vsfToEmpName.BeforeDoubleClick

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

            'サイズを自動調整しない
        End If

    End Sub

    '関数名：textbox_Enter
    '機　能：ハイライト処理用 フォーカス取得イベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles medFindTime.Enter, medFindTimeDisp.Enter, txtDummy.Enter
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
    Private Sub textbox_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles medFindTime.Leave, medFindTimeDisp.Leave, txtDummy.Leave
        'NSYS マウス選択でのハイライトをキャンセルする
        sender.Tag("OnHighlight") = False
    End Sub

    '関数名：textbox_KeyUp
    '機　能：ハイライト処理用 キーアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles medFindTime.KeyUp, medFindTimeDisp.KeyUp, txtDummy.KeyUp
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
    Private Sub textbox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medFindTime.MouseDown, medFindTimeDisp.MouseDown, txtDummy.MouseDown
        'NSYS MouseDown時のカーソル位置を保持
        sender.Tag("MouseDownStart") = sender.SelectionStart
    End Sub

    '関数名：textbox_MouseUp
    '機　能：ハイライト処理用 マウスアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medFindTime.MouseUp, medFindTimeDisp.MouseUp, txtDummy.MouseUp
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

    '関数名：TabControl_Selecting
    '機　能：Tabページ切替キャンセル
    '作成日：2019/09/24 (Thu) 20:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub prvTabControl_Selecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles tabControl.Selecting
        
        Select Case tabControl.SelectedIndex
            Case CMlngssTab4
                If Tab3.Enabled = False Then
                    e.Cancel = True
                End If

            Case CMlngssTab5
                If Tab4.Enabled = False Then
                    e.Cancel = True
                End If

        End Select
    End Sub

    '関数名：tabList_Deselecting
    '機　能：タブの選択が解除される前に発生するイベント処理
    '引　数：sender：イベント発生源のオブジェクト
    '        e     ：イベント補足情報
    '戻り値：なし
    '作成日：2018/10/12 (Fri) NSYS
    '更新日：
    '備　考：
    Private Sub tabList_Deselecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles _
        tabControl.Deselecting

        '処理中の場合またはタブ切り替えが無効の場合はタブ選択をキャンセルする
        If Me.buttonProcessing = True OrElse mblnTabSelectDisabled = True Then
            Select Case tabControl.SelectedIndex
                Case CMlngssTab1
                    '@(7)が選択されている場合
                    If opt2Excp7.Checked = True Then
                        '@ﾃｷｽﾄがNullの場合はﾒｯｾｰｼﾞ表示
                        If txt2Comments.Text = vbNullString Then
                            '@編集ﾌﾗｸﾞを立てる
                            mblnEditFlag = True
                        
                            '@Tabを戻す
                            'tabControl.Tab = PreviousTab
                        
                            '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005K)
                        
                            '@<TRM5KW>$$工程異常項目で「(７)その他」が選択されています。$必須入力項目ですので入力して下さい。
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            'NSYS メッセージ表示中フラグTrueにしフォーカス移動しない
                            mblnMessegeFlag = True
                            sender.Focus()
                        
                            '@ﾌｫｰｶｽｾｯﾄ
                            If txt2Comments.Enabled = True Then
                                Call pubSetFocus(txt2Comments)
                            End If
                        
                            '@編集ﾌﾗｸﾞを戻す
                            mblnEditFlag = False
                        
                        End If
                    End If
                
                    '@発見日時が空欄の場合
                    If calFindDate.Value = CPstrNullDate Then
                    '@空欄の場合には,ﾒｯｾｰｼﾞ表示
                        '@編集ﾌﾗｸﾞを立てる
                        mblnEditFlag = True
                    
                        '@Tabを戻す
                        'tabControl.Tab = PreviousTab
                    
                        '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006M)
                    
                        '@発見日時の設定が正しくありません。設定を見直してください。
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        'NSYS メッセージ表示中フラグTrueにしフォーカス移動しない
                        mblnMessegeFlag = True
                        sender.Focus()
                    
                        '@ﾌｫｰｶｽｾｯﾄ
                        If calFindDate.Enabled = True Then
                            Call pubSetFocus(calFindDate)
                        End If
                    
                        '@編集ﾌﾗｸﾞを戻す
                        mblnEditFlag = False
                    
                    End If

                Case CMlngssTab4
                    If Tab3.Enabled = False Then
                        e.Cancel = True
                    End If

                Case CMlngssTab5
                    If Tab4.Enabled = False Then
                        e.Cancel = True
                    End If
            End Select
        End If

        'NSYS メッセージが表示された場合はタブ選択をキャンセルする
        If mblnMessegeFlag = True Then
            e.Cancel = True
        End If
        mblnMessegeFlag = False
        mblnTabSelectDisabled = True

    End Sub

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
        calFindDate.Enter,calFindDateDisp.Enter,chk4Treat1.Enter,chk4Treat2.Enter,chk4Treat3.Enter,chk4Treat4.Enter,chk4Treat5.Enter,chk4Treat6.Enter, _ 
        cmbCauseKubun.Enter,cmbCauseSeries.Enter,cmbCauseWpID.Enter,cmbOpID.Enter,cmbOpIDDisp.Enter,cmbPdID.Enter,cmbPdIDDisp.Enter,cmbStepID.Enter, _ 
        cmbStepIDDisp.Enter,cmbWpID.Enter,cmbWpIDDisp.Enter,cmd3_6Down0.Enter,cmd3_6Down1.Enter,cmd3_6Up0.Enter,cmd3_6Up1.Enter,cmd3_7Down.Enter, _ 
        cmd3_7Up.Enter,cmd4Cancel0.Enter,cmd4Cancel1.Enter,cmd4Cancel2.Enter,cmd4Down0.Enter,cmd4Down1.Enter,cmd4Down2.Enter,cmd4Sign0.Enter,cmd4Sign1.Enter, _ 
        cmd4Sign2.Enter,cmd4Up0.Enter,cmd4Up1.Enter,cmd4Up2.Enter,cmd5Cancel0.Enter,cmd5Cancel1.Enter,cmd5Cancel2.Enter,cmd5Down0.Enter,cmd5Down1.Enter, _ 
        cmd5Down2.Enter,cmd5Sign0.Enter,cmd5Sign1.Enter,cmd5Sign2.Enter,cmd5Up0.Enter,cmd5Up1.Enter,cmd5Up2.Enter,cmd6Cancel0.Enter,cmd6Cancel1.Enter, _ 
        cmd6Cancel2.Enter,cmd6Down0.Enter,cmd6Down1.Enter,cmd6Down2.Enter,cmd6Sign0.Enter,cmd6Sign1.Enter,cmd6Sign2.Enter,cmd6Up0.Enter,cmd6Up1.Enter, _ 
        cmd6Up2.Enter,cmdCauseNo.Enter,cmdClose.Enter,cmdInc1Cancel0.Enter,cmdInc1Cancel1.Enter,cmdInc1Cancel2.Enter,cmdInc1Down0.Enter,cmdInc1Down1.Enter, _ 
        cmdInc1Down2.Enter,cmdInc1Sign0.Enter,cmdInc1Sign1.Enter,cmdInc1Sign2.Enter,cmdInc1Up0.Enter,cmdInc1Up1.Enter,cmdInc1Up2.Enter,cmdInc3Cancel.Enter, _ 
        cmdInc3Sign.Enter,cmdInc4Cancel.Enter,cmdInc4Down.Enter,cmdInc4Sign.Enter,cmdInc4Up.Enter,cmdInc5Cancel.Enter,cmdInc5Down.Enter,cmdInc5Sign.Enter, _ 
        cmdInc5Up.Enter,cmdIncong.Enter,cmdLotAdd.Enter,cmdLotWk.Enter,cmdLotWkCorrect.Enter,cmdMail.Enter,cmdRegist.Enter,cmdTrouble.Enter,cmdWorkMiss.Enter, _ 
        cmdWpWk.Enter,medFindTime.Enter,opt2Excp1.Enter, _ 
        opt2Excp2.Enter,opt2Excp3.Enter,opt2Excp4.Enter,opt2Excp5.Enter,opt2Excp6.Enter,opt2Excp7.Enter,opt2Excp8.Enter,opt3_7umu0.Enter,opt3_7umu1.Enter, _ 
        opt3Gen0.Enter,opt3Gen1.Enter,opt3Gen2.Enter,opt3Gen3.Enter,opt4ProcInfl0.Enter,opt4ProcInfl1.Enter,optComformNo10.Enter,optComformNo11.Enter, _ 
        optComformNo20.Enter,optComformNo21.Enter,optCut0.Enter,optCut1.Enter,tabControl.Enter, _ 
        txt2Comments.Enter,txt3_30.Enter,txt3_31.Enter,txt3_6Comments0.Enter,txt3_6Comments1.Enter,txt3_7Comments.Enter,txt4Comments0.Enter,txt4Comments1.Enter, _ 
        txt4Comments2.Enter,txt5Comments0.Enter,txt5Comments1.Enter,txt5Comments2.Enter,txt6Comments0.Enter,txt6Comments1.Enter,txt6Comments2.Enter,txtDummy.Enter, _ 
        txtInc1Comments0.Enter,txtInc1Comments1.Enter,txtInc1Comments2.Enter,txtInc4Comments.Enter,txtInc5Comments.Enter,txtTelNo.Enter,vsfLotList.Enter, _ 
        vsfLotNo0.Enter,vsfLotNo1.Enter,vsfToEmpName.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            Case tabControl.Name
                If Me.ActiveControl.Name = tabControl.Name Then
                    Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
                End If
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
