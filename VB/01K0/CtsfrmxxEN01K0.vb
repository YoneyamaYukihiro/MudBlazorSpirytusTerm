'ﾌｧｲﾙ名：xxEN01K0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：流動票バージョンアップ　メインフォーム
'作成日：2004/11/18 (Thu) 10:45:37 N.Kasai
'更新日：2011/09/28 (Wed) 16:43:36 Y.Yoneyama
'備　考：
'　　　：2005/04/05 (Tue) 09:14:54 S.Deguchi    不具合№621確定ﾁｪｯｸで「投入待ち」の場合もﾒｯｾｰｼﾞを表示しないように修正
'　　　：2005/06/01 (Wed) 10:27:20 S.Deguchi    不具合№832の対応でｺﾒﾝﾄ書式変更
'　　　：2005/06/02 (Thu) 12:38:22 S.Deguchi    不具合№781の対応で種別をｺﾝﾎﾞ一覧へ変更対応
'　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01K0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01K0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01K0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01K0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01K0)
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
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2020/03/27 (Fri) 13:57:32 T.Oide 「.Netへ反映未」 **************************************************
    '@'Private Const CMstrLocalVersion                     As String = "08.00"
    Private Const CMstrLocalVersion                     As String = "08.01"
    '@↑2020/03/27 (Fri) 13:57:32 T.Oide 「.Netへ反映未」 **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_flowlistVer                  As String = "04.00"                 '種別区分一覧取得
    Private Const CMstrmas_pdlist__Ver                  As String = "03.00"                 '機種区分一覧取得
    Private Const CMstrmas_pdentrylistVer               As String = "03.00"                 'ﾏｽﾀ工順一覧取得
    Private Const CMstrlot_chgtrvlistVer                As String = "05.01"                 '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ対象一覧
    Private Const CMstrlot_chgtravelerVer               As String = "02.00"                 '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ
    Private Const CMstrlot_chgtrvprohibitVer            As String = "01.00"                 '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ状態変更
    Private Const CMstrlot_chksecpriorityVer            As String = "01.00"                 'ﾛｯﾄ区間優先状態ﾁｪｯｸ
    '@↓2020/03/27 (Fri) 14:11:25 T.Oide 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_chkContEtApcVer            As String = "01.00"                 'CONTｴｯﾁｬｰAPC(2M-1P)ﾁｪｯｸ
    '@↑2020/03/27 (Fri) 14:11:25 T.Oide 「.Netへ反映未」 **************************************************


    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN01K0          'ﾛｰｶﾙ機能ID

    '@vsfSearchResultの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfSearchColNo                   As Integer = 0                      '№
    Private Const CMlngvsfSearchColKb                   As Integer = 1                      '保/停/リ/入/代/移表示ｴﾘｱ
    Private Const CMlngvsfSearchColKb2                  As Integer = 2                      '入/代/移
    Private Const CMlngvsfSearchColProcChange           As Integer = 3                      '工順変更有無
    Private Const CMlngvsfSearchColVerChange            As Integer = 4                      '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ有無
    Private Const CMlngvsfSearchColProhibit             As Integer = 5                      '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ禁止有無
    Private Const CMlngvsfSearchColEntryID              As Integer = 6                      'ｴﾝﾄﾘID
    Private Const CMlngvsfSearchColLotID                As Integer = 7                      'ﾛｯﾄID
    Private Const CMlngvsfSearchColPdID                 As Integer = 8                      '機種ID
    Private Const CMlngvsfSearchColFlowClass            As Integer = 9                      '種別
    Private Const CMlngvsfSearchColCarrierID            As Integer = 10                     'ｷｬﾘｱID
    Private Const CMlngvsfSearchColOpID                 As Integer = 11                     '大工程
    Private Const CMlngvsfSearchColStepID               As Integer = 12                     '小工程
    Private Const CMlngvsfSearchColNowSt                As Integer = 13                     '状態
    Private Const CMlngvsfSearchColPriority             As Integer = 14                     '優先順位
    Private Const CMlngvsfSearchColReworkCount          As Integer = 15                     'ﾘﾜｰｸ実績
    Private Const CMlngvsfSearchColLotPos               As Integer = 16                     'ﾛｯﾄ位置
    Private Const CMlngvsfSearchColLotManagerName       As Integer = 17                     'ﾛｯﾄ担当
    Private Const CMlngvsfSearchColProhibitEmpName      As Integer = 18                     '禁止設定者
    Private Const CMlngvsfSearchColLotLastUpdate        As Integer = 19                     '最終更新日
    Private Const CMlngvsfSearchColWfRecipeFlag         As Integer = 20                     'WF個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
    Private Const CMlngvsfSearchColLotRecipeFlag        As Integer = 21                     'ﾛｯﾄ個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
    Private Const CMlngvsfSearchColCommitFlag           As Integer = 22                     '号機指定
    Private Const CMlngvsfSearchColMasEntryID           As Integer = 23                     'ﾏｽﾀ最新ｴﾝﾄﾘID
    Private Const CMlngvsfSearchColProhibitDeptName     As Integer = 24                     '禁止設定部署名
    Private Const CMlngvsfSearchColLotComments          As Integer = 25                     'ｺﾒﾝﾄ有無
    Private Const CMlngvsfSearchColSamplingFlag         As Integer = 26                     'ｻﾝﾌﾟﾘﾝｸﾞﾌﾗｸﾞ

    '@vsfSearchResultの定数宣言(幅)
    Private Const CMlngvsfSearchColWNo                  As Integer = 37                     '№
    Private Const CMlngvsfSearchColWKb                  As Integer = 20                     '保/停区分
    Private Const CMlngvsfSearchColWKb2                 As Integer = 20                     '入/代/移
    Private Const CMlngvsfSearchColWProcChange          As Integer = 80                     '工順変更有無
    Private Const CMlngvsfSearchColWVerChange           As Integer = 80                     '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ有無
    Private Const CMlngvsfSearchColWProhibit            As Integer = 80                     '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ禁止有無
    Private Const CMlngvsfSearchColWEntryID             As Integer = 113                    'ｴﾝﾄﾘID
    Private Const CMlngvsfSearchColWLotID               As Integer = 113                    'ﾛｯﾄID
    Private Const CMlngvsfSearchColWPdID                As Integer = 133                    '機種ID
    Private Const CMlngvsfSearchColWFlowClass           As Integer = 27                     '種別
    Private Const CMlngvsfSearchColWCarrierID           As Integer = 113                    'ｷｬﾘｱID
    Private Const CMlngvsfSearchColWOpID                As Integer = 133                    '大工程
    Private Const CMlngvsfSearchColWStepID              As Integer = 133                    '小工程
    Private Const CMlngvsfSearchColWNowSt               As Integer = 100                    '状態
    Private Const CMlngvsfSearchColWPriority            As Integer = 25                     '優先順位
    Private Const CMlngvsfSearchColWReworkCount         As Integer = 133                    'ﾘﾜｰｸ実績
    Private Const CMlngvsfSearchColWLotPos              As Integer = 133                    'ﾛｯﾄ位置
    Private Const CMlngvsfSearchColWLotManagerName      As Integer = 133                    'ﾛｯﾄ担当
    Private Const CMlngvsfSearchColWProhibitEmpName     As Integer = 133                    '禁止設定者
    Private Const CMlngvsfSearchColWLotLastUpdate       As Integer = 133                    '最終更新日
    Private Const CMlngvsfSearchColWWfRecipeFlag        As Integer = 133                    'WF個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
    Private Const CMlngvsfSearchColWLotRecipeFlag       As Integer = 133                    'ﾛｯﾄ個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
    Private Const CMlngvsfSearchColWCommitFlag          As Integer = 133                    '号機指定
    Private Const CMlngvsfSearchColWMasEntryID          As Integer = 133                    'ﾏｽﾀ最新ｴﾝﾄﾘID
    Private Const CMlngvsfSearchColWProhibitDeptName    As Integer = 133                    '禁止設定部署名
    Private Const CMlngvsfSearchColWLotComments         As Integer = 133                    'ｺﾒﾝﾄ有無
    Private Const CMlngvsfSearchColWSamplingFlag        As Integer = 133                    'ｻﾝﾌﾟﾘﾝｸﾞﾌﾗｸﾞ

    '@vsfSearchResultの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfSearchColTNo                  As String = "№"
    Private Const CMstrvsfSearchColTKb                  As String = CPstrSpace              '保/停区分
    Private Const CMstrvsfSearchColTKb2                 As String = CPstrSpace              '入/代/移
    Private Const CMstrvsfSearchColTProcChange          As String = "工順変更"
    Private Const CMstrvsfSearchColTVerChange           As String = "流動票UP"
    Private Const CMstrvsfSearchColTProhibit            As String = "VerUp"
    Private Const CMstrvsfSearchColTEntryID             As String = "エントリ"
    Private Const CMstrvsfSearchColTLotID               As String = "ロットID"
    Private Const CMlngvsfSearchColTPdID                As String = "機種"
    Private Const CMstrvsfSearchColTFlowClass           As String = "種"
    Private Const CMstrvsfSearchColTCarrierID           As String = "キャリアID"
    Private Const CMstrvsfSearchColTOpID                As String = "大工程"
    Private Const CMstrvsfSearchColTStepID              As String = "小工程"
    Private Const CMstrvsfSearchColTNowSt               As String = "状態"
    Private Const CMstrvsfSearchColTPriority            As String = "優"
    Private Const CMstrvsfSearchColTReworkCount         As String = "リ実"                  'ﾘﾜｰｸ実績
    Private Const CMstrvsfSearchColTLotPos              As String = "ロット位置"
    Private Const CMstrvsfSearchColTLotManagerName      As String = "ロット担当"
    Private Const CMstrvsfSearchColTProhibitEmpName     As String = "禁止設定者"
    Private Const CMstrvsfSearchColTLotComments         As String = "コメント"
    Private Const CMlngvsfSearchColTLotLastUpdate       As String = "最終更新日"
    Private Const CMlngvsfSearchColTWfRecipeFlag        As String = "WF個別ﾚｼﾋﾟ"
    Private Const CMlngvsfSearchColTLotRecipeFlag       As String = "ﾛｯﾄ個別ﾚｼﾋﾟ"
    Private Const CMlngvsfSearchColTMasEntryID          As String = "ﾏｽﾀ最新ｴﾝﾄﾘ"
    Private Const CMlngvsfSearchColTCommitFlag          As String = "号機指定"
    Private Const CMlngvsfSearchColTProhibitDeptName    As String = "禁止設定者部署"
    Private Const CMlngvsfSearchColTSamplingFlag        As String = "ｻﾝﾌﾟﾘﾝｸﾞﾌﾗｸﾞ"

    Private Const CMlngvsfSearchRowTitle                As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngvsfSearchColTitle                As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngvsfSearchHFontSize               As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfSearchHHeight                 As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfSearchHeight                  As Integer = 18                     '1ｽﾛｯﾄの高さ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbRowHeight                     As Integer = 18                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbDispCols1                     As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbValueCol0                     As Integer = 0                      '値取得個数=0
    Private Const CMlngCmbGridCol0                      As Integer = 0                      '名称列番=0
    Private Const CMlngCmbGridCol1                      As Integer = 1                      '名称列番=1
    Private Const CMlngCmbGetCol5                       As Integer = 5                      'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=5(ﾊﾞｯｸｶﾗｰ)

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                      As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbDispCol2                      As Integer = 2                      'ｸﾞﾘｯﾄﾞ表示列数=2
    Private Const CMlngCmbGroupCols                     As Integer = 1                      '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCMbSelectMode                    As Integer = 1                      '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMstrCmbAddedComment                  As String = " 項目選択"             '表示 文字列
    Private Const CMstrCmbAddedCommentNone              As String = "0 項目選択"            '表示 文字列「選択なし」

    '@ﾚｽﾎﾟﾝｽ測定用
    Private Const CMstrFormName                         As String = "frmxxEN01K0"                           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"                             'ｲﾍﾞﾝﾄ名称(ﾌｫｰﾑﾛｰﾄﾞ)
    Private Const CMstrCmbPdValidate                    As String = "cmbPD_Validate"                        'ｲﾍﾞﾝﾄ名称(機種取得)
    Private Const CMstrCmbFlowClassValidate             As String = "cmbFlowClass_Validate"                 'ｲﾍﾞﾝﾄ名称(種別取得)
    Private Const CMstrCmdSearchClick                   As String = "cmdSearch_Click"                       'ｲﾍﾞﾝﾄ名称(最新取得)
    Private Const CMstrCmdRegistClick                   As String = "cmdRegist_Click"                       'ｲﾍﾞﾝﾄ名称(確定)
    Private Const CMstrBeforeRowColChange               As String = "vsfSearchResult_BeforeRowColChange"    'ｲﾍﾞﾝﾄ名称(ｴﾝﾄﾘ取得)
    Private Const CMstrcmdProhibitClick                 As String = "cmdProhibit_Click"                     'ｲﾍﾞﾝﾄ名称(Ver禁止設定)
    Private Const CMstrcmdCancelProhibitClick           As String = "cmdCancelProhibit_Click"               'ｲﾍﾞﾝﾄ名称(Ver禁止解除)

    '@その他
    Private Const CMstrLotHoldFlgOn                     As String = "1"                     '保留ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrLotStopFlgOn                     As String = "1"                     '停止ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrProcChangeFlgOn                  As String = "1"                     '工順変更ﾌﾗｸﾞON
    Private Const CMstrWFRecipeFlgOn                    As String = "1"                     'WFﾚｼﾋﾟﾌﾗｸﾞON
    Private Const CMstrLotRecipeFlgOn                   As String = "1"                     'LOTﾚｼﾋﾟﾌﾗｸﾞON
    Private Const CMstrCommitFlgOn                      As String = "1"                     '号機指定ON
    Private Const CMstrAltFlgOn                         As String = "1"                     '代替ON
    Private Const CMstrSwapFlgOn                        As String = "1"                     '入替ON
    Private Const CMstrReworkFlgOn                      As String = "1"                     'ﾘﾜｰｸON
    Private Const CMstrReworkFlgOn2                     As String = "2"                     '追加ﾌﾗｸﾞON
    Private Const CMstrWFCarryFlgOn                     As String = "1"                     '移載ON

    Private Const CMstrEntryTimeFormat                  As String = CPstrDateTimeY2MDHM     '適用日時ﾌｫｰﾏｯﾄ
    Private Const CMstrHo                               As String = "保"                    '保留表示
    Private Const CMstrTei                              As String = "停"                    '停止表示
    Private Const CMstrKin                              As String = "禁"                    '禁止表示
    Private Const CMstrDai                              As String = "代"                    '代替表示
    Private Const CMstrIre                              As String = "入"                    '入替表示
    Private Const CMstrRi                               As String = "リ"                    'ﾘﾜｰｸ表示
    Private Const CMstrIsa                              As String = "移"                    '移載表示
    Private Const CMstrTui                              As String = "追"                    '追加表示


    Private Const CMstrProhibitON                       As String = "1"                     '禁止設定
    Private Const CMstrProhibitOFF                      As String = "0"                     '禁止解除

    '@ﾒｯｾｰｼﾞ編集用
    Private Const CMstrLotWa                            As String = "このロットは"
    Private Const CMstrGoukiZumi                        As String = "[装置予約が設定済]"
    Private Const CMstrRecipeZumi                       As String = "[個別レシピが設定済]"
    Private Const CMstrJikoutei                         As String = "$のため流動票バージョンアップは次工程から適用されます。"
    Private Const CMstrKaigyou                          As String = "$$"
    Private Const CMstrLotBunkatu                       As String = "ロットが分割されています｡$親と子ロットのエントリが相違する可能性があります｡"
    Private Const CMstrJikanSeigen                      As String = "ロットは現在時間制限が設定されています。時間制限はクリアされます。"
    Private Const CMstrBracketLeft                      As String = "["
    Private Const CMstrBracketRight                     As String = "]"
    Private Const CMstrMsgProhibitON                    As String = "禁止設定"
    Private Const CMstrMsgProhibitOFF                   As String = "禁止解除"

    '@判定定数
    Private Const CMlngSearch0                          As Integer = 0                      '検索条件(機種/種別/流動区分)
    Private Const CMlngSearch1                          As Integer = 1                      '検索条件(ﾛｯﾄID)
    Private Const CMlngFlowClass0                       As Integer = 0                      '流動区分(流動前)
    Private Const CMlngFlowClass1                       As Integer = 1                      '流動区分(流動中)
    Private Const CMlngLotMaxLeng                       As Integer = 10                     'ﾛｯﾄIDMax桁
    Private Const CMlngLotMinLeng                       As Integer = 2                      'ﾛｯﾄIDMin桁

    '@文字制限
    Private Const CMlngKeyBackSpace                     As Integer = 8                      'ﾊﾞｯｸｽﾍﾟｰｽのｱｽｷｰｺｰﾄﾞ
    Private Const CMlngKeyReturn                        As Integer = 13                     'ｴﾝﾀｰｷｰのｱｽｷｰｺｰﾄﾞ
    Private Const CMlngKeyAsciiAster                    As Integer = 42                     'ｱｽｷｰｺｰﾄﾞ-*
    Private Const CMlngKeyAsciiNum0                     As Integer = 48                     'ｱｽｷｰｺｰﾄﾞ-0
    Private Const CMlngKeyAsciiNum9                     As Integer = 57                     'ｱｽｷｰｺｰﾄﾞ-9
    Private Const CMlngKeyAsciiUppA                     As Integer = 65                     'ｱｽｷｰｺｰﾄﾞ-A
    Private Const CMlngKeyAsciiUppZ                     As Integer = 90                     'ｱｽｷｰｺｰﾄﾞ-Z
    Private Const CMlngKeyAsciiUnderBar                 As Integer = 95                     'ｱｽｷｰｺｰﾄﾞ-_
    Private Const CMlngKeyAsciiLowA                     As Integer = 97                     'ｱｽｷｰｺｰﾄﾞ-a
    Private Const CMlngKeyAsciiLowZ                     As Integer = 122                    'ｱｽｷｰｺｰﾄﾞ-z
    Private Const CMstrUnderBar                         As String = "_"                     'ｱﾝｽｺ
    Private Const CMstrAsciiAster                       As String = "*"                     'ｱｽﾀｰ

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow                       As Integer = 3                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mblncmbPdValidateEvent                      As Boolean                          '機種Validate発生ﾌﾗｸﾞ(Ture:発生、False:発生なし)
    Private mblntxtLotIdValidateEvent                   As Boolean                          'ﾛｯﾄIDValidate発生ﾌﾗｸﾞ(Ture:発生、False:発生なし)
    Private mblntxtLotIdChangeEvent                     As Boolean                          'ﾛｯﾄIDChange発生ﾌﾗｸﾞ(Ture:発生、False:発生なし)
    Private mblnMouseDownEvent                          As Boolean                          '最新取得ﾎﾞﾀﾝﾏｳｽﾀﾞｳﾝ発生ﾌﾗｸﾞ(Ture:発生、False:発生なし)
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用

    Private mtypChgTrvListAns                           As List(Of ChgTrvListAns)           'ﾛｯﾄ一覧取得(応答)情報格納
    Private mlngLotListCnt                              As Integer                          'ﾛｯﾄ一覧取得件数
    Private mtypProductList                             As List(Of ProductList)             '機種ﾘｽﾄ構造体
    Private mlngProductCnt                              As Integer                          '機種ﾘｽﾄ数
    Private mtypFlowClassList                           As List(Of DivisionList)            '種別ﾘｽﾄ構造体
    Private mlngFlowClassCnt                            As Integer                          '種別ﾘｽﾄ数

    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ

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
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 10:49:19 N.Kasai
    '更新日：2009/02/25 (Wed) 20:06:10 N.Kojima
    '備　考：
    '　　　：2005/08/01 (Mon) 13:51:03 N.Kasai      L/R表示追加
    '　　　：2007/07/03 (Tue) 09:12:53 N.Kasai      機種ｺﾝﾎﾞ複数選択(№02006)
    '　　　：2009/02/25 (Wed) 20:06:10 N.Kojima     ﾁｯﾌﾟ品判別説明ﾗﾍﾞﾙの制御処理追加。(案件№03402)
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean          '結果格納
        Dim lstrClassDivision       As String           '処理区分
        
        
        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Me.Left = 0 - My.Settings.FormOffset
            Me.Top = 0
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01K0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
        '@↓2009/02/25 (Wed) 20:05:49 N.Kojima **************************************************

            '@-----------------------
            '@ ﾗﾍﾞﾙﾊﾞｯｸｶﾗｰ設定
            '@-----------------------
            '@起動SBが組立か
            If pstrSBID = CPstrSBID2A0 Then
                '@2A0：組立の場合
            
                lblTitleL.BackColor = ColorTranslator.FromWin32(CPlngLColor)           '機種L
                lblTitleR.BackColor = ColorTranslator.FromWin32(CPlngRColor)           '機種R
                lblTitleL.Visible = True
                lblTitleR.Visible = True
                lblTitleChip.Visible = True                                            'ﾁｯﾌﾟ品限定
            Else
                '@1A0：基板の場合
            
                lblTitleL.Visible = False
                lblTitleR.Visible = False
                lblTitleChip.Visible = False                                           'ﾁｯﾌﾟ品限定
            End If

        '@↑2009/02/25 (Wed) 20:05:49 N.Kojima **************************************************
            
            lblTitleHT.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)        '保留/停止
            
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If IsNothing(.typChgSortList) Then 
                    .typChgSortList = New List(Of ChgSortList)
                Else
                    .typChgSortList.Clear()
                End If
                
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call prvfrmxxEN01K0_Init()

            '@機種区分一覧取得(画面ｻｲｽﾞ指定なし-すべて)
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          CPstrCD2A & CPstrCD02, _
                                          mtypProductList, _
                                          mlngProductCnt, _
                                          pstrSBID)
            '@結果判定
            If lblnAns = True Then
                '@機種情報表示
                Call prvcmbPd_Disp()
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@流動区分一覧取得【全て】
            lstrClassDivision = CPstrCD02
            lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                            mtypFlowClassList, _
                                            mlngFlowClassCnt, _
                                            pstrSBID, _
                                            lstrClassDivision)
            '@結果判定
            If lblnAns = True Then
                '@取得情報を種別一覧へｾｯﾄ
                Call prvcmbFlowClassList_Disp()
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰ押下時
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift　：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:02:06 N.Kasai
    '更新日：2005/01/06 (Thu) 13:53:03 N.Kasai
    '備　考：
    '　　　：2004/11/29 (Mon) 10:12:53 N.Kasai  @DoEventsﾌﾗｸﾞ判定追加
    '　　　：2005/01/06 (Thu) 13:53:03 N.Kasai  ﾛｯﾄIDでENTERを押下時の条件を追加
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
            
            Select Case e.KeyCode
                '@Enterの場合
                Case Keys.Return
                    Select Case ActiveControl.Name
                    
                        '@一覧にﾌｫｰｶｽがある場合
                        Case vsfSearchResult.Name
                            With vsfSearchResult
                                '@ﾃﾞｰﾀ行の場合
                                If .Row >= .Rows.Fixed Then
                                    '@確定ﾎﾞﾀﾝへ
                                    If cmdRegist.Enabled = True Then
                                        Call pubSetFocus(cmdRegist)
                                    Else
                                        If txtComments.Enabled = True Then
                                            Call pubSetFocus(txtComments)
                                        End If
                                    End If
                                End If
                            End With
                            
                        '@機種
                        Case cmbPD.Name
                            RemoveHandler cmbPd.Validating, AddressOf cmbPd_Validate
                            Call cmbPd_Validate(cmbPd, New CancelEventArgs(False))
                            AddHandler cmbPd.Validating, AddressOf cmbPd_Validate
                            e.Handled = True
                            
                        '@種別
                        Case cmbFlowClass.Name
                            RemoveHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_Validate
                            Call cmbFlowClass_Validate(cmbFlowClass, New CancelEventArgs(False))
                            AddHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_Validate
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                            
                        '@ﾛｯﾄID
                        Case txtLotID.Name
                            '@ﾛｯﾄIDが空白の場合はﾀﾌﾞ移動のみ
                            If txtLotID.Text = vbNullString Then
                                SendKeys.SendWait(CPstrSendKeysTab)
                            Else
                                '@ﾛｯﾄValidateｲﾍﾞﾝﾄ
                                RemoveHandler txtLotID.Validating, AddressOf txtLotID_Validate
                                Call txtLotID_Validate(txtLotID, New CancelEventArgs(False))
                                AddHandler txtLotID.Validating, AddressOf txtLotID_Validate

                                '@ﾛｯﾄID変更ﾌﾗｸﾞOFFの場合
                                If mblntxtLotIdChangeEvent = False Then
                                    If cmdSearch.Enabled = True Then
                                        Call pubSetFocus(cmdSearch)
                                    End If
                                Else
                                    '@ﾌｫｰｶｽの移動(ｸﾞﾘｯﾄﾞへ)
                                    If vsfSearchResult.Enabled = True Then
                                        Call pubSetFocus(vsfSearchResult)
                                    End If
                                End If
                            End If
                            
                        '@作業ﾒﾓ
                        Case txtComments.Name
                            Exit Sub
                            
                        '@ｴﾝﾄﾘｺﾒﾝﾄ
                        Case txtEntrytComments.Name
                            Exit Sub
                        
                        '@上記以外
                        Case Else
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
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 10:50:28 N.Kasai
    '更新日：2004/11/29 (Mon) 10:11:25 N.Kasai
    '備　考：
    '　　　：2004/11/29 (Mon) 10:11:25 N.Kasai  DoEventsﾌﾗｸﾞ判定追加
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm             As Boolean              '開放結果格納
        Dim ltypRirekeiNextinfo     As RirekeiNextinfo      '引継ぎ構造体(履歴確認)

        Try

            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
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
            
            '@引継ぎ構造体ｸﾘｱ
            ptypRirekeiNextinfo = ltypRirekeiNextinfo
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If IsNothing(mtypChgSort.typChgSortList) Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort.typChgSortList.Clear()
            End If
              
            '@ﾛｯﾄ一覧取得(応答)情報格納ｸﾘｱ
            If IsNothing(mtypChgTrvListAns) Then
                mtypChgTrvListAns = New List(Of ChgTrvListAns)
            Else
                mtypChgTrvListAns.Clear()
            End If
            mlngLotListCnt = 0
            
            '@機種格納構造体ｸﾘｱ
            If IsNothing(mtypProductList) Then
                mtypProductList = New List(Of ProductList)
            Else
                mtypProductList.Clear()
            End If
            mlngProductCnt = 0
            
            '@種別格納構造体ｸﾘｱ
            If IsNothing(mtypFlowClassList) Then
                mtypFlowClassList = New List(Of DivisionList)
            Else
                mtypFlowClassList.Clear()
            End If
            mlngFlowClassCnt = 0
            
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

    '関数名：optFlowClass_Click
    '機　能：種別　ｸﾘｯｸ時
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:04:33 N.Kasai
    '更新日：2004/11/18 (Thu) 11:04:33
    '備　考：
    Private Sub optFlowClass_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optFlowClass0.Click, optFlowClass1.Click

        Try

            '@検索結果ﾘｽﾄの初期化
            Call prvvsfSearchResult_Init()
            
            '@ﾎﾞﾀﾝの使用不可
            cmdRegist.Enabled = False      '確定ﾎﾞﾀﾝ
            
            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearchEnabled_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optFlowClass_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optSearch_Click
    '機　能：検索条件選択　ｸﾘｯｸ時
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:23:16 N.Kasai
    '更新日：2005/08/02 (Tue) 14:15:22 N.Kasai
    '備　考：
    '　　　：2005/08/02 (Tue) 14:15:22 N.Kasai      ｺﾝﾎﾞｲﾝﾃﾞｯｸｽｸﾘｱ追加
    Private Sub optSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optSearch0.Click, optSearch1.Click

        Try

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@検索結果ﾘｽﾄの初期化
            Call prvvsfSearchResult_Init()
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False      '確定ﾎﾞﾀﾝ
            
            '@検索ﾎﾞﾀﾝの使用許可
            Call prvcmdSearchEnabled_Set()
            
            Select Case ActiveControl.Name
                '@機種・種別が選択された場合
                Case optSearch0.Name
                    '@機種・種別使用可
                    cmbPD.Enabled = True
                    cmbFlowClass.Enabled = False
                    cmbPD.BackColor = Color.White
                    cmbFlowClass.BackColor = SystemColors.ControlLight
                    optFlowClass0.Enabled = True
                    optFlowClass1.Enabled = True
                    optFlowClass0.Checked = True
                    fraKisyu.Enabled = True
                    
                    '@ﾛｯﾄID使用不可
                    txtLotID.Text = vbNullString
                    txtLotID.Enabled = False
                    txtLotID.BackColor = SystemColors.ControlLight
                    
                '@ﾛｯﾄIDが選択された場合
                Case optSearch1.Name
                    '@機種・種別使用不可
                    cmbPD.ListIndex = -1
                    cmbPD.Text = vbNullString
                    cmbPD.Enabled = False
                    cmbPD.BackColor = SystemColors.ControlLight
                    
                    cmbFlowClass.Text = vbNullString
                    cmbFlowClass.Enabled = False
                    cmbFlowClass.BackColor = SystemColors.ControlLight
                    
                    optFlowClass0.Checked = False
                    optFlowClass1.Checked = False
                    optFlowClass0.Enabled = False
                    optFlowClass1.Enabled = False
                    fraKisyu.Enabled = False
                    
                    '@ﾛｯﾄID使用可
                    txtLotID.Enabled = True
                    txtLotID.BackColor = Color.White
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optSearch_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：chkNewVersion_Click
    '機　能：最新ﾊﾞｰｼﾞｮﾝ表示ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2007/04/04 (Wed) 14:58:10 N.Kasai
    '更新日：2007/04/04 (Wed) 14:58:10
    '備　考：
    Private Sub chkNewVersion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkNewVersion.CheckedChanged

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞが使用可能状態の場合
            If vsfSearchResult.Enabled = True Then
                 
                '@=======================
                '@ 検索結果表示
                '@=======================
                Call prvvsfSearchLotList_Disp()
                
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
                Call vsfSearchResult_EnterCell(vsfSearchResult, New EventArgs)
                
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "chkNewVersion_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_Change
    '機　能：機種 変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:24:43 N.Kasai
    '更新日：2005/10/05 (Wed) 10:44:40 N.Kojima
    '備　考：
    '　　　：2005/10/05 (Wed) 10:44:40 N.Kojima     ﾛｯﾄ詳細情報表示ﾎﾞﾀﾝの無効化処理追加。(ﾕｰｻﾞｰ要望№0088)
    Private Sub cmbPd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.Change

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@検索結果ﾘｽﾄの初期化
            Call prvvsfSearchResult_Init()
            
            '@ﾎﾞﾀﾝの使用不可
            cmdRegist.Enabled = False
            cmdSearch.Enabled = False
            cmdWPHistory.Enabled = False
            cmdLotDisp.Enabled = False
            cmdCancelProhibit.Enabled = False
            cmdProhibit.Enabled = False
            
            '@種別の初期化
            cmbFlowClass.Clear
            cmbFlowClass.Text = vbNullString
            
            '@ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ後ｴﾝﾄﾘ表示の初期化
            lblEntryID.Text = vbNullString
            lblEntryName.Text = vbNullString
            lblApplyTime.Text = vbNullString
            txtEntrytComments.Text = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPd_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_CloseUp
    '機　能：機種 選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:24:59 N.Kasai
    '更新日：2007/07/02 (Mon) 16:52:40 N.Kasai
    '備　考：
    '　　　：2007/07/02 (Mon) 16:52:40 N.Kasai  機種ｺﾝﾎﾞ複数選択
    Private Sub cmbPd_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.CloseUp

        Try
            
            '@空欄 or 0項目以外の場合
            If cmbPD.Text <> vbNullString And _
                cmbPD.Text <> CMstrCmbAddedCommentNone Then
                '@Validate処理
                RemoveHandler cmbPD.Validating, AddressOf cmbPd_Validate
                Call cmbPd_Validate(cmbPD, New CancelEventArgs(True))
                AddHandler cmbPD.Validating, AddressOf cmbPd_Validate
            Else
                cmbFlowClass.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPd_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_Validate
    '機　能：機種 Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:25:19 N.Kasai
    '更新日：2007/07/02 (Mon) 16:53:39 N.Kasai
    '備　考：
    '　　　：2005/08/01 (Mon) 14:22:25 N.Kasai      L/R表示追加
    '　　　：2007/07/02 (Mon) 16:53:39 N.Kasai      機種ｺﾝﾎﾞ複数選択
    Private Sub cmbPd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPd.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@機種ｺﾝﾎﾞ選択可否
            If cmbPD.Text = vbNullString Or _
                cmbPD.Text = CMstrCmbAddedCommentNone Then
                '@空欄 or 0項目の場合
                Exit Sub
            End If
            
            '@取得情報を種別一覧へｾｯﾄ
            Call prvcmbFlowClassList_Disp()
            
            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearchEnabled_Set()

            '@種別を有効にする
            cmbFlowClass.Enabled = True
            cmbFlowClass.BackColor = Color.White
            If ActiveControl.Name = cmbPd.Name Then
                Call pubSetFocus(cmbFlowClass)
            End If
            '@種別へ強制ﾌｫｰｶｽ設定
            mblncmbPdValidateEvent = True
            
            
        '@↓2007/07/02 (Mon) 16:55:24 N.Kasai **************************************************
        '    '@未選択の場合は処理しない
        '    If cmbPD.Text = vbNullString Then
        '        Exit Sub
        '    End If
            
            '@前回機種ID格納と同じ場合は処理しない
            '@ｺﾝﾎﾞValueCol設定
        '    cmbPD.ValueCol = CMlngCmbValueCol0
        '    If cmbPD.Value = mstrProductID And cmbFlowClass.ListCount > 0 Then
        '
        '        If cmbFlowClass.Enabled = True Then
        '            Call pubSetFocus(cmbFlowClass)
        '        End If
        '
        '        Exit Sub
        '    End If
            
        '    '@値取得(ﾊﾞｯｸｶﾗｰ値)
        '    cmbPD.ValueCol = CMlngCmbGetCol5
        '
        '    If cmbPD.Value <> vbNullString Then
        '        '@ﾊﾞｯｸｶﾗｰ反映
        '        cmbPD.BackColor = cmbPD.Value
        '    Else
        '        cmbPD.BackColor = vbWhite
        '    End If
            
        '    '@ﾚｽﾎﾟﾝｽ取得開始
        '    Call pubResponseStart(CMstrFormName, CMstrCmbPdValidate)
        '
        '    '@種別区分一覧取得
        '    lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
        '                                    ltypFlowClassList(), _
        '                                    llngFlowClassCnt, _
        '                                    pstrSBID, _
        '                                    CPstrCD04, _
        '                                    cmbPD.Text)
        '    '@結果判定
        '    If lblnAns = True Then
        '        '@取得情報を種別一覧へｾｯﾄ
        '        Call prvcmbFlowClassList_Disp(ltypFlowClassList(), llngFlowClassCnt)
        '
        '        '@機種名退避
        '        mstrProductID = cmbPD.Text
        '
        '        '@機種ｴﾝﾄﾘ最新取得
        '        lblnAns = prvMasEntryList_Sel
        '        '@結果判定
        '        If lblnAns = False Then
        '            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
        '            Call pubResponseCancel(CMstrFormName, CMstrCmbPdValidate)
        '        End If
        '    Else
        '        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
        '        Call pubResponseCancel(CMstrFormName, CMstrCmbPdValidate)
        '        Exit Sub
        '    End If

        '    '@最新取得ﾎﾞﾀﾝの使用許可
        '    Call prvcmdSearchEnabled_Set
            
        '    '@ﾚｽﾎﾟﾝｽ取得終了
        '    Call publngResponseEnd(CMstrFormName, CMstrCmbPdValidate)

        '    '@種別を有効にする
        '    cmbFlowClass.Enabled = True
        '    cmbFlowClass.BackColor = vbWhite
        '    Call pubSetFocus(cmbFlowClass)
        '    '@種別へ強制ﾌｫｰｶｽ設定
        '    mblncmbPdValidateEvent = True
        '@↑2007/07/02 (Mon) 16:55:24 N.Kasai **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPd_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbFlowClass_Change
    '機　能：種別ｺﾝﾎﾞ　変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:25:49 N.Kasai
    '更新日：2004/11/18 (Thu) 11:25:49
    '備　考：
    Private Sub cmbFlowClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.Change

        Try

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@検索結果ﾘｽﾄの初期化
            Call prvvsfSearchResult_Init()
            
            '@ﾎﾞﾀﾝの使用不可
            cmdRegist.Enabled = False
            
            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearchEnabled_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbFlowClass_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbFlowClass_CloseUp
    '機　能：種別の選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:26:20 N.Kasai
    '更新日：2004/11/18 (Thu) 11:26:20
    '備　考：
    Private Sub cmbFlowClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.CloseUp

        Try

            '@Validate処理へ
            If cmbFlowClass.Text <> vbNullString Then
                RemoveHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_Validate
                Call cmbFlowClass_Validate(cmbFlowClass, New CancelEventArgs(True))
                AddHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_Validate
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbFlowClass_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbFlowClass_Validate
    '機　能：種別のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:26:43 N.Kasai
    '更新日：2004/11/18 (Thu) 11:26:43
    '備　考：
    Private Sub cmbFlowClass_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbFlowClass.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If

            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearchEnabled_Set()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbFlowClass_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Change
    '機　能：ﾛｯﾄID　変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:30:04 N.Kasai
    '更新日：2004/11/18 (Thu) 11:30:04
    '備　考：
    Private Sub txtLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotID.Change

        Try

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@検索結果ﾘｽﾄの初期化
            Call prvvsfSearchResult_Init()
            
            '@ﾎﾞﾀﾝの使用不可
            cmdRegist.Enabled = False
            
            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearchEnabled_Set()
            
            '@ﾛｯﾄID変更ﾌﾗｸﾞON
            mblntxtLotIdChangeEvent = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_KeyPress
    '機　能：ﾛｯﾄID　ｷｰ押下時
    '引　数：KeyAscii：ｱｽｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:30:39 N.Kasai
    '更新日：2004/11/18 (Thu) 11:30:39
    '備　考：
    Private Sub txtLotID_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtLotID.KeyPress

        Try
          
            '@全角の入力を制御(記号可)
            Select Case Asc(e.KeyChar)
                '@0～9、A～Z、ﾊﾞｯｸｽﾍﾟｰｽ、ｴﾝﾀｰ、*、_　入力可
                Case CMlngKeyAsciiNum0 To CMlngKeyAsciiNum9, _
                     CMlngKeyAsciiUppA To CMlngKeyAsciiUppZ, _
                     CMlngKeyAsciiLowA To CMlngKeyAsciiLowZ, _
                     CMlngKeyBackSpace, CMlngKeyReturn, _
                     CMlngKeyAsciiAster, CMlngKeyAsciiUnderBar
                '@それ以外は入力不可
                Case Else
                    e.Handled = True 'ｷｰ無効
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotID_KeyPress"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Validate
    '機　能：ﾛｯﾄIDのValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:31:00 N.Kasai
    '更新日：2005/01/06 (Thu) 14:32:53 N.Kasai
    '備　考：mblntxtLotIdChangeEvent：ﾛｯﾄIDの2重読み込みを抑止する。
    '　　　：mblnMouseDownEvent：ﾛｯﾄIDは最新ﾎﾞﾀﾝを経由せず明細を表示することが可能な為、下記の場合のみ
    '　　　：mblntxtLotIdChangeEvent = Trueで最新ﾎﾞﾀﾝﾏｳｽｸﾘｯｸの場合ｲﾍﾞﾝﾄを発生させない。
    '　　　：2005/01/06 (Thu) 14:32:53 N.Kasai  ﾌﾗｸﾞ判定追加(mblntxtLotIdChangeEvent、mblnMouseDownEvent)
    Private Sub txtLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLotID.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If

            If txtLotID.Text <> vbNullString Then
                If Len(txtLotID.Text) < CMlngLotMinLeng Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001H)
                    '@「ロットIDは2桁以上入力してください。」
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    e.Cancel = True
                    Exit Sub
                End If
                
                '@ﾛｯﾄID変更ﾌﾗｸﾞON
                If mblntxtLotIdChangeEvent = True Then
                    '@最新取得
                    Call cmdSearch_Click(cmdSearch, EventArgs.Empty)
                    '@ﾛｯﾄID変更ﾌﾗｸﾞOFF
                    mblntxtLotIdChangeEvent = False
                    '@ﾏｳｽﾀﾞｳﾝﾌﾗｸﾞOFF
                    mblnMouseDownEvent = False
                        
                    '@ﾌｫｰｶｽの設定
                    If vsfSearchResult.Enabled = True Then
                        If ActiveControl.Name = txtLotID.Name Then
                            Call pubSetFocus(vsfSearchResult)
                        End If
                        '@一覧へ強制ﾌｫｰｶｽ設定
                        mblntxtLotIdValidateEvent = True
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名: cmdSearch_GotFocus
    '機 能: 最新取得ボタン フォーカス取得
    '引 数: なし
    '戻り値: なし
    '作成日：2004/11/18 (Thu) 11:31:46 N.Kasai
    '更新日：2004/11/18 (Thu) 11:31:46
    '備 考: 一覧グリッドにフォーカスがあたらない為､強引にフォーカス設定する
    Private Sub cmdSearch_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Enter

        Try

            '@ﾛｯﾄIDのValidate発生ﾌﾗｸﾞの場合
            If mblntxtLotIdValidateEvent = True Then
                If vsfSearchResult.Enabled = True Then
                    If ActiveControl.Name = cmdSearch.Name
                        '@ｸﾞﾘｯﾄﾞへﾌｫｰｶｽ設定
                        Call pubSetFocus(vsfSearchResult)
                    End If
                    mblntxtLotIdValidateEvent = False
                End If
            End If
            
            '@ﾏｳｽﾀﾞｳﾝｲﾍﾞﾝﾄ初期化
            mblnMouseDownEvent = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSearch_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSearch_MouseDown
    '機　能：最新取得ﾎﾞﾀﾝﾏｳｽｸﾘｯｸｲﾍﾞﾝﾄ
    '引　数：Button：未使用
    '　　　：Shift：未使用
    '　　　：X：未使用
    '　　　：Y：未使用
    '戻り値：なし
    '作成日：2004/11/29 (Mon) 11:30:27 N.Kasai
    '更新日：2005/01/06 (Thu) 13:23:29 N.Kasai
    '備　考：一覧グリッドにフォーカスがあたらない為､強引にフォーカス設定する(cmdSearch_GotFocusに関連)
    '　　　：2005/01/06 (Thu) 13:23:29 N.Kasai  ﾌﾗｸﾞ初期化に条件を追加
    Private Sub cmdSearch_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmdSearch.MouseDown

        Try
            
            '@機種を選択してﾏｳｽで最新取得ﾎﾞﾀﾝ押下する場合のみﾌﾗｸﾞを初期化する。
            '@機種とﾛｯﾄ指定で検索する場合があり機種の場合は検索ﾎﾞﾀﾝを押下して明細取得する。
            '@ﾛｯﾄ指定の場合は前方一致検索が可能の為、最新ﾎﾞﾀﾝを経由せずValidateEventで明細を取得する為下記の記述が必要
            
            If mblnMouseDownEvent = True Then
                '@ﾛｯﾄIDのValidate発生ﾌﾗｸﾞ初期化
                mblntxtLotIdValidateEvent = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSearch_MouseDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSearch_Click
    '機　能：最新取得ﾎﾞﾀﾝ　押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:32:18 N.Kasai
    '更新日：2007/07/03 (Tue) 09:16:42 N.Kasai
    '備　考：
    '　　　：2007/07/03 (Tue) 09:16:42 N.Kasai  機種複数選択(№02006)
    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
        
        Dim lblnAns                 As Boolean          '結果格納
        Dim ltypChgTrvListRec       As ChgTrvListRec    'ﾛｯﾄ一覧取得(要求)情報格納
        Dim lstrLotFlowStatusID     As String           '流動区分
        Dim lstrLotID               As String           'ﾛｯﾄID
        Dim lstrTemp                As Object           '一時取得
        Dim llngCnt                 As Integer          '汎用ｶｳﾝﾀ

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
            
            '@検索ﾁｪｯｸ
            If prvSearch_Chk = False Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdSearchClick)
                                    
            '@検索条件の判定
            Select Case True
                '@機種ID・種別ID・流動中/流動前をｷｰにして返す
                Case optSearch0.Checked = True
                    '@流動区分(種別ID)
                    Select Case True
                        Case optFlowClass0.Checked = True
                            lstrLotFlowStatusID = Trim(str(CMlngFlowClass0))  '流動前
                        Case optFlowClass1.Checked = True
                            lstrLotFlowStatusID = Trim(str(CMlngFlowClass1))  '流動中
                    End Select
                '@ﾛｯﾄIDｷｰにして返す
                Case optSearch1.Checked = True
                    '@ﾛｯﾄIDが10桁ない場合
                    If Len(txtLotID.Text) < CMlngLotMaxLeng Then
                        '@ﾛｯﾄID + "*"
                        lstrLotID = txtLotID.Text & CMstrAsciiAster
                    Else
                        lstrLotID = txtLotID.Text
                    End If
            End Select
            
            '@応答ﾒｯｾｰｼﾞ格納
            With ltypChgTrvListRec
                .strSbID = pstrSBID
                .strMsgVer = CMstrlot_chgtrvlistVer
                
                '@機種/種別指定
                If optSearch0.Checked = True Then
                    
                    '@機種指定
                    .lngPdCnt = cmbPD.ValueCount                                'Classｶｳﾝﾄ数
                    '@種別区分構造体作成
                    If IsNothing(.typPdList) Then
                        .typPdList = New List(Of PDList)
                    Else
                        .typPdList.Clear()
                    End If
                    Do While (.typPdList.Count - 1 < .lngPdCnt)
                        .typPdList.Add(New PDList)
                    Loop

                    Dim typPdListtmp As PDList = New PDList

                    lstrTemp = Split(cmbPD.Value, vbTab)
                    For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)
                        typPdListtmp.strPdId = lstrTemp(llngCnt)                '種別ID
                        .typPdList(llngCnt) = typPdListtmp
                    Next llngCnt
                
                    '@種別指定
                    .lngFlowClassListCnt = cmbFlowClass.ValueCount              'Classｶｳﾝﾄ数
                    '@種別区分構造体作成
                    If IsNothing(.typFlowClassList) Then
                        .typFlowClassList = New List(Of DivisionList)
                    Else
                        .typFlowClassList.Clear()
                    End If
                    Do While (.typFlowClassList.Count - 1 < .lngFlowClassListCnt)
                        .typFlowClassList.Add(New DivisionList)
                    Loop

                    Dim typFlowClassListtmp As DivisionList = New DivisionList

                    lstrTemp = Split(cmbFlowClass.Value, vbTab)
                    For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)
                        typFlowClassListtmp.strDivisionID = lstrTemp(llngCnt)   '種別ID
                        .typFlowClassList(llngCnt) = typFlowClassListtmp
                    Next llngCnt
                Else
                    '@ﾛｯﾄ指定
                    .lngPdCnt = 0
                    .lngFlowClassListCnt = 0
                End If
                
                .strLotFlowStatusID = lstrLotFlowStatusID
                .strLotID = lstrLotID
            End With
            
            '@ﾛｯﾄ一覧取得(応答)情報格納ｸﾘｱ
            If IsNothing(mtypChgTrvListAns) Then
                mtypChgTrvListAns = New List(Of ChgTrvListAns)
            Else
                mtypChgTrvListAns.Clear()
            End If
            mlngLotListCnt = 0
            
            '@=======================
            '@ MSG[流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ対象一覧]を実行
            '@=======================
            lblnAns = pubblnChgTrvlist_Sel(ltypChgTrvListRec, mtypChgTrvListAns, mlngLotListCnt)
            
            '@結果判定
            If lblnAns = True Then
            '@ﾛｯﾄ一覧取得に成功
                
                '@件数がありの場合
                If mlngLotListCnt > 0 Then
                
                    '@=======================
                    '@ 検索結果表示
                    '@=======================
                    Call prvvsfSearchLotList_Disp()
                Else
                    '@検索結果ﾘｽﾄの初期化
                    Call prvvsfSearchResult_Init()
                    '@該当件数
                    lblListCnt.Text = 0
                End If
                
                '@情報取得日時表示
                lblGetInfoDate.Text = Format$(Now, CPstrDateFormat)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdSearchClick)
            Else
                '@ﾛｯﾄ一覧取得に失敗
                '@検索結果ﾘｽﾄの初期化
                Call prvvsfSearchResult_Init()
                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdSearchClick)
                
            End If

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用可否制御
            Call prvcmdButtonEnabled_Set()
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSearch_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSearchResult_AfterSort
    '機　能：検索結果ﾘｽﾄ ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:46:34 N.Kasai
    '更新日：2004/11/18 (Thu) 11:46:34 N.Kasai
    '備　考：
    Private Sub vsfSearchResult_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfSearchResult.AfterSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSearchResult.Rows.Count <= vsfSearchResult.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)
                Else
                    .typChgSortList.Clear()
                End If
                Do While (.typChgSortList.Count - 1 < .lngCnt)
                    .typChgSortList.Add(New ChgSortList)
                Loop

                Dim typChgSortListtmp As ChgSortList = New ChgSortList

                '@ｿｰﾄ列番号を格納
                typChgSortListtmp.lngCol = e.Col
                
                '@並び替え方法を格納(昇順/降順)
                typChgSortListtmp.lngOrder = e.Order
                .typChgSortList(.lngCnt) = typChgSortListtmp

                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
            End With
            
            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfAfterSort(vsfSearchResult, CMlngvsfSearchColLotID)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSearchResult_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSearchResult_AfterUserResize
    '機　能：列幅変更後処理
    '引　数：Row：行番号
    '　　　：Col：列番号
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:46:53 N.Kasai
    '更新日：2004/11/18 (Thu) 11:46:53 N.Kasai
    '備　考：
    Private Sub vsfSearchResult_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfSearchResult.AfterResizeColumn, vsfSearchResult.AfterResizeRow

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSearchResult.Rows.Count <= vsfSearchResult.Rows.Fixed Then
                Return
            End If
            
            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSearchResult_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSearchResult_BeforeRowColChange
    '機　能：行列変更前処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:47:13 N.Kasai
    '更新日：2007/07/02 (Mon) 17:05:24 N.Kasai
    '備　考：
    '　　　：2007/07/02 (Mon) 17:05:24 N.Kasai  機種ｺﾝﾎﾞ複数選択
    Private Sub vsfSearchResult_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfSearchResult.BeforeRowColChange
        
        Dim lblnAns             As Boolean              '汎用戻り値
        Dim lstrOldPdID         As String               '旧行の機種IDを格納
        Dim lstrNewPdID         As String               '新行の機種IDを格納

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSearchResult.Rows.Count <= vsfSearchResult.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ﾛｯﾄID)
                mtypChgSort.strKey = vsfSearchResult.GetData(e.NewRange.r1, CMlngvsfSearchColLotID)
                
                '@新旧の機種IDを取得
                lstrOldPdID = vsfSearchResult.GetData(e.OldRange.r1, CMlngvsfSearchColPdID)
                lstrNewPdID = vsfSearchResult.GetData(e.NewRange.r1, CMlngvsfSearchColPdID)
                
                '@新旧の機種IDを取得して相違した場合最新のｴﾝﾄﾘ情報を取得する。
                If lstrOldPdID <> lstrNewPdID Then
                    
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrBeforeRowColChange)
                    
                    '@機種ｴﾝﾄﾘ、部材取得
                    lblnAns = prvMasEntryList_Sel(e.NewRange.r1)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrBeforeRowColChange)
                    Else
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrBeforeRowColChange)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSearchResult_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSearchResult_BeforeSort
    '機　能：検索結果ﾘｽﾄ ｿｰﾄ前処理
    '引　数：Col　：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:52:45 N.Kasai
    '更新日：2004/11/18 (Thu) 11:52:45
    '備　考：
    Private Sub vsfSearchResult_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfSearchResult.BeforeSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSearchResult.Rows.Count <= vsfSearchResult.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfSearchResult, CMlngvsfSearchColLotID)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSearchResult_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSearchResult_EnterCell
    '機　能：検索結果ｸﾞﾘｯﾄ ｶﾚﾝﾄ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:53:31 N.Kasai
    '更新日：2006/12/12 (Tue) 13:58:51 N.Kasai
    '備　考：
    '　　　：2005/10/05 (Wed) 10:05:35 N.Kojima     ﾛｯﾄ詳細情報表示ﾎﾞﾀﾝの有効無効制御を追加。(ﾕｰｻﾞｰ要望№0088)
    '　　　：2006/12/12 (Tue) 13:58:51 N.Kasai      №01415
    Private Sub vsfSearchResult_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSearchResult.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSearchResult.Rows.Count <= vsfSearchResult.Rows.Fixed Then
                Return
            End If
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用可否制御
            Call prvcmdButtonEnabled_Set()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSearchResult_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_Change
    '機　能：作業ﾒﾓ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:29:37 N.Kasai
    '更新日：2005/12/02 (Fri) 16:03:13 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 16:03:13 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub txtComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.Change

        Dim llngNowByte     As Integer  'ｺﾒﾝﾄ桁数

        Try
               
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtComments.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_KeyUp
    '機　能：作業ﾒﾓｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:47:07 N.Kasai
    '更新日：2005/11/29 (Tue) 13:47:07
    '備　考：
    Private Sub txtComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComments.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtComments_MouseUp
    '機　能：作業ﾒﾓﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:48:44 N.Kasai
    '更新日：2005/11/29 (Tue) 13:48:44
    '備　考：
    Private Sub txtComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtComments.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSUp_Click
    '機　能：作業ﾒﾓ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:38:43 N.Kasai
    '更新日：2005/12/02 (Fri) 16:02:04 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 16:02:04 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdSUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSUp.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSDown_Click
    '機　能：作業ﾒﾓ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:39:56 N.Kasai
    '更新日：2004/11/18 (Thu) 11:39:56
    '備　考：
    '　　　：2005/12/02 (Fri) 16:02:04 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdSDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSDown.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtEntrytComments_Change
    '機　能：ｴﾝﾄﾘｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:12:03 N.Kasai
    '更新日：2005/11/29 (Tue) 14:12:03
    '備　考：
    Private Sub txtEntrytComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtEntrytComments.Change

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtEntrytComments, CMlngMaxDispRow, cmdEUp, cmdEDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtEntrytComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtEntrytComments_KeyUp
    '機　能：ｴﾝﾄﾘｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:47:07 N.Kasai
    '更新日：2005/11/29 (Tue) 13:47:07
    '備　考：
    Private Sub txtEntrytComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtEntrytComments.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtEntrytComments, CMlngMaxDispRow, cmdEUp, cmdEDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtEntrytComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtEntrytComments_MouseUp
    '機　能：ｴﾝﾄﾘｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:48:44 N.Kasai
    '更新日：2005/11/29 (Tue) 13:48:44
    '備　考：
    Private Sub txtEntrytComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtEntrytComments.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtEntrytComments, CMlngMaxDispRow, cmdEUp, cmdEDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtEntrytComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdEDown_Click
    '機　能：ｴﾝﾄﾘｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:40:50 N.Kasai
    '更新日：2005/12/02 (Fri) 16:14:22 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 16:14:22 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdEDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEDown.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtEntrytComments, CMlngMaxDispRow, cmdEUp, cmdEDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdEDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdEUp_Click
    '機　能：ｴﾝﾄﾘｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:41:05 N.Kasai
    '更新日：2005/12/02 (Fri) 16:14:46 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 16:14:46 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdEUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEUp.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtEntrytComments, CMlngMaxDispRow, cmdEUp, cmdEDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdEUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　ｸﾘｯｸ時
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/16 (Tue) 13:03:42 N.Kasai
    '更新日：2004/11/30 (Tue) 08:42:28 N.Kasai
    '備　考：
    '　　　：2004/11/30 (Tue) 08:42:28 N.Kasai  確定ﾎﾞﾀﾝ押下後の「変更履歴」ﾎﾞﾀﾝ使用可否制御追加
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypChgTraveler         As ChgTraveler          '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ要求格納構造体
        Dim ltypAnsTraveler         As AnsTraveler          '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ応答格納構造体
        Dim lstrMsg                 As String               '変換後ﾒｯｾｰｼﾞ
        Dim lstrMsgWork             As String               'ﾒｯｾｰｼﾞ内容変換
        Dim llngReqCnt              As Integer              '要求ｶｳﾝﾀ
        Dim llngMsgAns              As Integer              'ﾒｯｾｰｼﾞﾎﾞｯｸｽの結果格納
        Dim lstrResult              As String               '区間優先度判定結果格納

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
            
            '@画面入力ﾁｪｯｸ
            lblnAns = prvblnKakutei_Check
            If lblnAns = False Then
                Exit Sub
            End If
                        
            '@***********************
            '@ ﾛｯﾄに区間優先度設定があるかﾁｪｯｸ
            '@***********************
            lblnAns = prvblnLotSectionPriority_Chk(CMstrlot_chksecpriorityVer, vsfSearchResult.GetData(vsfSearchResult.Row, CMlngvsfSearchColLotID), lstrResult)
            
            '@確定時ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@結果「1」の場合継続or中断のﾒｯｾｰｼﾞ表示
            If lstrResult = CPstrOne Then
            
                '@"<TRM7AI>$$ロット[%1]には区間優先設定がされています。$確定処理を実行すると区間優先設定はクリアされますので、$必要に応じ再設定してください。$よろしいですか？"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007A, vsfSearchResult.GetData(vsfSearchResult.Row, CMlngvsfSearchColLotID))
                llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
            
                '@結果確認
                If llngMsgAns = vbNo Then
                    '@いいえの場合は処理中止
                    Exit Sub
                End If
                
            End If
            
            '@↓2020/03/27 (Fri) 13:54:24 T.Oide 「.Netへ反映未」 **************************************************
            '@***********************
            '@ CONT-ET_APCの2M-1P中ではないかチェック
            '@***********************
            lblnAns = prvblnContEtApc_Chk(CMstrlot_chkContEtApcVer, vsfSearchResult.GetData(vsfSearchResult.Row, CMlngvsfSearchColLotID), lstrResult)
    
            '@確定時ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
                Exit Sub
            End If
    
            '@結果「0:VerUpOK」以外の場合、中断のﾒｯｾｰｼﾞ表示
            Select Case lstrResult

                '@流動表VerUp禁止区間中
                Case CPstrOne
        
                    '@"<TRM7YI>$$ロット[%1]はCONTエッチャーAPCの区間中であるため流動表VerUpできません。"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007Y, vsfSearchResult.GetData(vsfSearchResult.Row, CMlngvsfSearchColLotID))
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@処理中止
                    Exit Sub
            
                '@ﾁｪｯｸ処理に失敗
                Case CPstrNine
        
                    '@"<TRMY0W>$$システムエラーが発生しました。システム担当者に連絡してください。"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0, vsfSearchResult.GetData(vsfSearchResult.Row, CMlngvsfSearchColLotID))
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@処理中止
                    Exit Sub
        
            End Select
            '@↑2020/03/27 (Fri) 13:54:24 T.Oide 「.Netへ反映未」 **************************************************

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ｶｳﾝﾀにﾃﾞﾌｫﾙﾄ値を設定(今後、複数登録する可能性がある為ﾘｽﾄ構造とした経緯あり。現在は単発更新)
            llngReqCnt = 0
            
            '@流動票対象ﾃﾞｰﾀ格納
            With ltypChgTraveler
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                .strSbID = pstrSBID
                
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstrlot_chgtravelerVer
                
                '@作業者ID
                .strEmpID = pstrUserID
                
                If IsNothing(.typChgTravelerList) Then
                    .typChgTravelerList = New List(Of ChgTravelerList)
                Else
                    .typChgTravelerList.Clear()
                End If
                Do While (.typChgTravelerList.Count - 1 < llngReqCnt)
                    .typChgTravelerList.Add(New ChgTravelerList)
                Loop

                Dim typChgTravelerListtmp As ChgTravelerList = New ChgTravelerList
                
                '@ﾛｯﾄID
                typChgTravelerListtmp.strLotID = _
                    vsfSearchResult.GetData(vsfSearchResult.Row, CMlngvsfSearchColLotID)
                
                '@作業ﾒﾓ
                typChgTravelerListtmp.strComments = txtComments.Text
                
                '@最終更新日
                typChgTravelerListtmp.strLotLastUpdate = _
                    vsfSearchResult.GetData(vsfSearchResult.Row, CMlngvsfSearchColLotLastUpdate)
                    
                '@ｻﾝﾌﾟﾘﾝｸﾞﾌﾗｸﾞ
                If chkSamplingFlag.Checked = True Then
                    typChgTravelerListtmp.strSamplingFlag = 1
                Else
                    typChgTravelerListtmp.strSamplingFlag = 0
                End If

                .typChgTravelerList(llngReqCnt) = typChgTravelerListtmp
                    
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)        
            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnLotChgTraveler_Upd(ltypChgTraveler, ltypAnsTraveler)
            
            '@結果取得
            If lblnAns = True Then
                
                '@ﾒｯｾｰｼﾞ内容編集
                With ltypAnsTraveler.typAnsTravelerList(llngReqCnt)
                    lstrMsgWork = .strOpID & CPstrMinus & .strStepID
                End With
               
                '@表示ﾒｯｾｰｼﾞ変換("<TRM3JI>$$工程[%1]より流動票バージョンアップを適用しました。ロット[%2]")
                lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf003J, lstrMsgWork, ltypAnsTraveler.typAnsTravelerList(llngReqCnt).strLotID)
                       
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(lstrMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                
                '@画面情報更新
                Call cmdSearch_Click(cmdSearch, EventArgs.Empty)
                
                '@作業ﾒﾓをｸﾘｱ
                txtComments.Text = vbNullString
                
            Else
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
            End If
            
            '@一覧にｾｯﾄﾌｫｰｶｽｾｯﾄ
            With vsfSearchResult
                If .Enabled = True Then
                    '@ﾌｫｰｶｽ設定
                    Call pubSetFocus(vsfSearchResult)
                End If
            End With
            
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

    '関数名：cmdCancelProhibit_Click
    '機　能：VerUp禁止解除
    '引　数：なし
    '戻り値：なし
    '作成日：2007/04/03 (Tue) 17:05:54 N.Kasai
    '更新日：2007/04/03 (Tue) 17:05:54
    '備　考：
    Private Sub cmdCancelProhibit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelProhibit.Click

        Dim lblnAns                     As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrMsg                     As String               '変換後ﾒｯｾｰｼﾞ
        Dim ltypLotChgtrvprohibitReq    As LotChgtrvprohibitReq '要求ﾃﾞｰﾀ
        Dim lstrLotID                   As String
        Dim lstrProhibitEmpName         As String
        Dim lstrProhibitDeptName        As String
        Dim llngMsgAns                  As Integer
        
        
        
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
            
            With vsfSearchResult
                lstrLotID = .GetData(.Row, CMlngvsfSearchColLotID)
                lstrProhibitEmpName = .GetData(.Row, CMlngvsfSearchColProhibitEmpName)
                lstrProhibitDeptName = .GetData(.Row, CMlngvsfSearchColProhibitDeptName)
            End With
            
            '@ｲﾝﾌｫﾒｰｼｮﾝ文字列の編集
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006T, lstrLotID, lstrProhibitDeptName & " " & lstrProhibitEmpName)
            '@"<TRM6TI>$$ロット[%1]は、[%2]$により流動票バージョンアップ禁止設定されています。$禁止を解除しますか？"
            llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)

            '@ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値判定
            If llngMsgAns = vbNo Then
                Exit Sub
            End If
            
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@要求ﾃﾞｰﾀ格納
            With ltypLotChgtrvprohibitReq
                '@MSGﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstrlot_chgtrvprohibitVer
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                .strSbID = pstrSBID
                '@ﾛｯﾄID
                .strLotID = vsfSearchResult.GetData(vsfSearchResult.Row, CMlngvsfSearchColLotID)
                '@禁止解除
                .strVerUpProhibitedFlag = CMstrProhibitOFF
                '@最終更新日時
                .strLotLastUpdate = vsfSearchResult.GetData(vsfSearchResult.Row, CMlngvsfSearchColLotLastUpdate)
                '@作業者ID
                .strEmpID = pstrUserID
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrcmdCancelProhibitClick)
 
            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnLotChgtrvprohibit_Upd(ltypLotChgtrvprohibitReq)
            
            '@結果取得
            If lblnAns = True Then
                
                '@表示ﾒｯｾｰｼﾞ変換("<TRM6SI>$$流動票バージョンアップ[%1]しました。$ロット[%2]")
                lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf006S, CMstrMsgProhibitOFF, ltypLotChgtrvprohibitReq.strLotID)
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(lstrMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, CMstrcmdCancelProhibitClick)
                
                '@画面情報更新
                Call cmdSearch_Click(cmdSearch, EventArgs.Empty)
                
                '@作業ﾒﾓをｸﾘｱ
                txtComments.Text = vbNullString
                
            Else
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrcmdCancelProhibitClick)
            End If
            
            '@一覧にｾｯﾄﾌｫｰｶｽｾｯﾄ
            With vsfSearchResult
                If .Enabled = True Then
                    '@ﾌｫｰｶｽ設定
                    Call pubSetFocus(vsfSearchResult)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdProhibit_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Sub

    '関数名：cmdProhibit_Click
    '機　能：VerUp禁止設定ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2007/04/03 (Tue) 16:32:08 N.Kasai
    '更新日：2007/04/03 (Tue) 16:32:08
    '備　考：
    Private Sub cmdProhibit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdProhibit.Click

        Dim lblnAns                     As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrMsg                     As String               '変換後ﾒｯｾｰｼﾞ
        Dim ltypLotChgtrvprohibitReq    As LotChgtrvprohibitReq '要求ﾃﾞｰﾀ
        
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
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@要求ﾃﾞｰﾀ格納
            With ltypLotChgtrvprohibitReq
                '@MSGﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstrlot_chgtrvprohibitVer
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                .strSbID = pstrSBID
                '@ﾛｯﾄID
                .strLotID = vsfSearchResult.GetData(vsfSearchResult.Row, CMlngvsfSearchColLotID)
                '@禁止設定
                .strVerUpProhibitedFlag = CMstrProhibitON
                '@最終更新日時
                .strLotLastUpdate = vsfSearchResult.GetData(vsfSearchResult.Row, CMlngvsfSearchColLotLastUpdate)
                '@作業者ID
                .strEmpID = pstrUserID
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrcmdProhibitClick)

            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnLotChgtrvprohibit_Upd(ltypLotChgtrvprohibitReq)
            
            '@結果取得
            If lblnAns = True Then
                
                '@表示ﾒｯｾｰｼﾞ変換("<TRM6SI>$$流動票バージョンアップ[%1]しました。$ロット[%2]")
                lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf006S, CMstrMsgProhibitON, ltypLotChgtrvprohibitReq.strLotID)
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(lstrMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, CMstrcmdProhibitClick)
                
                '@画面情報更新
                Call cmdSearch_Click(cmdSearch, EventArgs.Empty)
                
                '@作業ﾒﾓをｸﾘｱ
                txtComments.Text = vbNullString
                
            Else
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrcmdProhibitClick)
            End If
            
            '@一覧にｾｯﾄﾌｫｰｶｽｾｯﾄ
            With vsfSearchResult
                If .Enabled = True Then
                    '@ﾌｫｰｶｽ設定
                    Call pubSetFocus(vsfSearchResult)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdProhibit_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWPHistory_Click
    '機　能：変更履歴確認ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 10:53:33 N.Kasai
    '更新日：2007/04/10 (Tue) 12:38:35 N.Kasai
    '備　考：
    '　　　：2007/04/10 (Tue) 12:38:35 N.Kasai  変更履歴画面修正
    Private Sub cmdWPHistory_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWPHistory.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@引継ぎ構造体に値を格納する。
            With ptypRirekeiNextinfo
                .strLotID = vsfSearchResult.GetData(vsfSearchResult.Row, CMlngvsfSearchColLotID)   'ﾛｯﾄID
            End With
            
            '@変更履歴確認ﾌｫｰﾑ起動
            frmxxEN01K1.Instance.ShowDialog(Me)
            frmxxEN01K1.Instance = Nothing
            
            '@子ﾌｫｰﾑよりﾒｲﾝ画面へ戻った時のﾌｫｰｶｽ設定
            If vsfSearchResult.Enabled = True Then
                Call pubSetFocus(vsfSearchResult)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWPHistory_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotDisp_Click
    '機　能：ﾛｯﾄ情報詳細表示
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/29 (Thu) 16:46:37 N.Kojima
    '更新日：2005/09/29 (Thu) 16:46:37
    '備　考：
    Private Sub cmdLotDisp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotDisp.Click
        
        Dim lstrTitle               As String       'ﾀｲﾄﾙ
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@Form_Loadﾌﾗｸﾞ(True：正常、False：異常)
            pblnFormLoad = False
            
            '@ﾌｫｰﾑ起動区分設定
            pblnfrmxxCM00R0Kbn = True
            
            With ptypCommonInfo
                '@ﾛｯﾄID引継ぎ
                .strLotID = vsfSearchResult.GetData(vsfSearchResult.Row, CMlngvsfSearchColLotID)       'ﾛｯﾄID
            
                '@ﾒﾆｭｰｷｰから機能の関連情報を取得する
                Call pubMenuItemCorrelation_Set(CPstrKeyEN01C0, lstrTitle)
                
                '@ﾀｲﾄﾙｾｯﾄ
                frmxxCM00R0.Instance.Text = lstrTitle
                 
                '@Form_Loadﾌﾗｸﾞが異常の場合
                If pblnFormLoad = False Then
                    '@異常の場合は子画面終了
                    frmxxCM00R0.Instance = Nothing
                    
                    '@Form_Loadﾌﾗｸﾞ(正常)
                    pblnFormLoad = True
                    
                    Exit Sub
                End If
                
                '@閉じるﾎﾞﾀﾝを無効(閉じる連打で落ちるのを回避)
                cmdClose.Enabled = False
                
                '@ﾛｯﾄ詳細情報画面起動
                frmxxCM00R0.Instance.ShowDialog(Me)
                frmxxCM00R0.Instance = Nothing
                
                '@Form_Loadﾌﾗｸﾞ(True：正常、False：異常)
                pblnFormLoad = True
                
                '@閉じるﾎﾞﾀﾝを有効(閉じる連打で落ちるのを回避)
                cmdClose.Enabled = True
                
            End With
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdLotDisp_Click"       '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 10:59:56 N.Kasai
    '更新日：2004/11/29 (Mon) 10:13:45 N.Kasai
    '備　考：
    '　　　：2004/11/29 (Mon) 10:13:45 N.Kasai  DoEventsﾌﾗｸﾞ判定追加
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo  As CommonInfo           '引継ぎ構造体

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            '@終了関数を実行する
            Call publngEnd_Proc(CPstrKeyEN01K0, ltypCommonInfo)
            
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

    '***************************************************************************************
    '                                   * 関数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    '関数名：prvfrmxxEN01K0_Init
    '機　能：ﾌｫｰﾑのｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:55:42 N.Kasai
    '更新日：2005/10/05 (Wed) 10:03:17 N.Kojima
    '備　考：
    '　　　：2005/10/05 (Wed) 10:03:17 N.Kojima     ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝの初期化処理追加。(ﾕｰｻﾞｰ要望№0088)
    Private Sub prvfrmxxEN01K0_Init()
        
        Dim llngNowByte As Integer
        
        Try
            
            '@内容のｸﾘｱ
            optSearch0.Checked = True
            optFlowClass0.Checked = True
            txtLotID.Text = vbNullString
            lblGetInfoDate.Text = vbNullString
            lblListCnt.Text = vbNullString
            txtComments.Text = vbNullString
            lblEntryID.Text = vbNullString
            lblEntryName.Text = vbNullString
            lblApplyTime.Text = vbNullString
            txtEntrytComments.Text = vbNullString
            
            '@作業ﾒﾓ/ｴﾝﾄﾘｺﾒﾝﾄ使用不可
            txtComments.Enabled = False
            txtEntrytComments.Enabled = False
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtComments.NowByte
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            cmdSUp.Enabled = False
            cmdSDown.Enabled = False
            cmdEUp.Enabled = False
            cmdEDown.Enabled = False
            
            '@機種・種別使用可
            cmbPD.Enabled = True
            cmbFlowClass.Enabled = False
            cmbPD.BackColor = Color.White
            cmbFlowClass.BackColor = SystemColors.ControlLight
            fraKisyu.Enabled = True
            
            '最新ﾊﾞｰｼﾞｮﾝ
            chkNewVersion.Enabled = True
            chkNewVersion.Checked = False
            
            '@ﾛｯﾄID使用不可
            txtLotID.Enabled = False
            txtLotID.BackColor = SystemColors.ControlLight
            
            '@検索結果ﾘｽﾄの初期化
            Call prvvsfSearchResult_Init()
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False           '確定ﾎﾞﾀﾝ
            cmdSearch.Enabled = False           '最新取得ﾎﾞﾀﾝ
            cmdWPHistory.Enabled = False        '履歴表示ﾎﾞﾀﾝ
            cmdLotDisp.Enabled = False          'ﾛｯﾄ詳細情報表示ﾎﾞﾀﾝ
            cmdProhibit.Enabled = False         'VerUp禁止設定
            cmdCancelProhibit.Enabled = False   'VerUp禁止解除
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01K0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvSearch_Chk
    '機　能：最新取得ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：成功　False：失敗
    '作成日：2004/11/18 (Thu) 11:57:52 N.Kasai
    '更新日：2005/08/03 (Wed) 15:51:10 N.Kasai
    '備　考：
    '　　　：2005/08/03 (Wed) 15:51:10 N.Kasai      ｺﾝﾎﾞValueColの値を明示的に
    Private Function prvSearch_Chk() As Boolean

        Try
            
            '@初期化
            prvSearch_Chk = False
            
            Select Case True
                '@機種・種別の場合
                Case optSearch0.Checked
                    '@機種ﾁｪｯｸ:ｺﾝﾎﾞValueCol設定
                    cmbPD.ValueCol = CMlngCmbValueCol0
                    If cmbPD.Text = CMstrCmbAddedCommentNone _
                        Or cmbPD.Text = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0013)
                        '@"機種が指定されていません。機種を指定してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Call pubSetFocus(cmbPD)
                        Exit Function
                    End If
                    
                    '@種別ﾁｪｯｸ:ｺﾝﾎﾞValueCol設定
                    cmbFlowClass.ValueCol = CMlngCmbValueCol0
                    If cmbFlowClass.Value = CMstrCmbAddedCommentNone Or _
                        cmbFlowClass.Value = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0014)
                        '@"種別が指定されていません。種別を指定してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Call pubSetFocus(cmbFlowClass)
                        Exit Function
                    End If
                    
                '@ﾛｯﾄIDの場合
                Case optSearch1.Checked
                    If Len(txtLotID.Text) < CMlngLotMinLeng Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001H)
                        '@「ロットIDは2桁以上入力してください。」
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Call pubSetFocus(txtLotID)
                        Exit Function
                    End If
               
            End Select
            
            '@成功
            prvSearch_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSearch_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvvsfSearchResult_Init
    '機　能：ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:58:35 N.Kasai
    '更新日：2008/06/11 (Wed) 15:49:22 N.Kojima
    '備　考：
    '　　　：2005/10/05 (Wed) 10:22:41 N.Kojima     ﾛｯﾄ詳細情報表示ﾎﾞﾀﾝの無効化処理追加。(ﾕｰｻﾞｰ要望№0088)
    '　　　：2008/06/11 (Wed) 15:49:22 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvvsfSearchResult_Init()

        Try
            
            '@ﾏｳｽﾀﾞｳﾝﾌﾗｸﾞON(初期化)
            mblnMouseDownEvent = True
            
            '@一覧表示の各カラムの幅、タイトルを設定
            With vsfSearchResult

                'NSYS 描画ﾛｯｸ
                .Redraw = False

                '@初期行数設定
                .Rows.Count = 1

                '@一覧表の表題設定
                .Select(CMlngvsfSearchRowTitle, CMlngvsfSearchColNo, CMlngvsfSearchRowTitle, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                                            '文字色
                lFixedStyle.BackColor = Color.Navy                                              '背景色
                lFixedStyle.Font = New Font(.Font.Name, CMlngvsfSearchHFontSize, .Font.Style)   'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfSearchColNo).Width = CMlngvsfSearchColWNo
                    .Cols(CMlngvsfSearchColKb).Width = CMlngvsfSearchColWKb
                    .Cols(CMlngvsfSearchColKb2).Width = CMlngvsfSearchColWKb2
                    .Cols(CMlngvsfSearchColProcChange).Width = CMlngvsfSearchColWProcChange
                    .Cols(CMlngvsfSearchColVerChange).Width = CMlngvsfSearchColWVerChange
                    .Cols(CMlngvsfSearchColProhibit).Width = CMlngvsfSearchColWProhibit
                    .Cols(CMlngvsfSearchColEntryID).Width = CMlngvsfSearchColWEntryID
                    .Cols(CMlngvsfSearchColLotID).Width = CMlngvsfSearchColWLotID
                    .Cols(CMlngvsfSearchColPdID).Width = CMlngvsfSearchColWPdID
                    .Cols(CMlngvsfSearchColFlowClass).Width = CMlngvsfSearchColWFlowClass
                    .Cols(CMlngvsfSearchColCarrierID).Width = CMlngvsfSearchColWCarrierID
                    .Cols(CMlngvsfSearchColOpID).Width = CMlngvsfSearchColWOpID
                    .Cols(CMlngvsfSearchColStepID).Width = CMlngvsfSearchColWStepID
                    .Cols(CMlngvsfSearchColNowSt).Width = CMlngvsfSearchColWNowSt
                    .Cols(CMlngvsfSearchColPriority).Width = CMlngvsfSearchColWPriority
                    .Cols(CMlngvsfSearchColReworkCount).Width = CMlngvsfSearchColWReworkCount
                    .Cols(CMlngvsfSearchColLotPos).Width = CMlngvsfSearchColWLotPos
                    .Cols(CMlngvsfSearchColLotManagerName).Width = CMlngvsfSearchColWLotManagerName
                    .Cols(CMlngvsfSearchColProhibitEmpName).Width = CMlngvsfSearchColWProhibitEmpName
                    .Cols(CMlngvsfSearchColLotComments).Width = CMlngvsfSearchColWLotComments
                End If
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColNo, CMstrvsfSearchColTNo)                                   'No.
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColKb, CMstrvsfSearchColTKb)                                   '保/停/リ
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColKb2, CMstrvsfSearchColTKb2)                                 '入/代/移
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColProcChange, CMstrvsfSearchColTProcChange)                   '工順変更有無
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColVerChange, CMstrvsfSearchColTVerChange)                     '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ有無
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColProhibit, CMstrvsfSearchColTProhibit)                       '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ禁止有無
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColEntryID, CMstrvsfSearchColTEntryID)                         'ｴﾝﾄﾘID
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColLotID, CMstrvsfSearchColTLotID)                             'ﾛｯﾄID
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColPdID, CMlngvsfSearchColTPdID)                               '機種ID
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColFlowClass, CMstrvsfSearchColTFlowClass)                     '種別
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColCarrierID, CMstrvsfSearchColTCarrierID)                     'ｷｬﾘｱID
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColOpID, CMstrvsfSearchColTOpID)                               '大工程
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColStepID, CMstrvsfSearchColTStepID)                           '小工程
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColNowSt, CMstrvsfSearchColTNowSt)                             '状態
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColPriority, CMstrvsfSearchColTPriority)                       '優先度
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColReworkCount, CMstrvsfSearchColTReworkCount)                 'ﾘﾜｰｸ実績
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColLotPos, CMstrvsfSearchColTLotPos)                           'ﾛｯﾄ位置
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColLotManagerName, CMstrvsfSearchColTLotManagerName)           'ﾛｯﾄ担当
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColProhibitEmpName, CMstrvsfSearchColTProhibitEmpName)         '禁止設定者
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColLotComments, CMstrvsfSearchColTLotComments)                 'ｺﾒﾝﾄ
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColLotLastUpdate, CMlngvsfSearchColTLotLastUpdate)             '最終更新日
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColWfRecipeFlag, CMlngvsfSearchColTWfRecipeFlag)               'WF個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColLotRecipeFlag, CMlngvsfSearchColTLotRecipeFlag)             'ﾛｯﾄ個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColCommitFlag, CMlngvsfSearchColTCommitFlag)                   '号機指定
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColMasEntryID, CMlngvsfSearchColTMasEntryID)                   'ﾏｽﾀ最新ｴﾝﾄﾘ
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColProhibitDeptName, CMlngvsfSearchColTProhibitDeptName)       '禁止設定者部署
                .SetData(CMlngvsfSearchRowTitle, CMlngvsfSearchColSamplingFlag, CMlngvsfSearchColTSamplingFlag)               'ｻﾝﾌﾟﾘﾝｸﾞﾌﾗｸﾞ
                
                'NSYS 描画ﾛｯｸ
                .Redraw = True

                '@表示位置の設定
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngvsfSearchRowTitle).Height = CMlngvsfSearchHHeight    '高さ
                
                '@ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Row
                
                '@ﾏｳｽによる列ｻｲｽﾞ変更の可／不可設定
                .AllowResizing = AllowResizingEnum.Columns

                '@固定列の設定(ｷｬﾘｱIDまで)
                .Cols.Frozen = CMlngvsfSearchColCarrierID + 1
                
                '@非表示列の設定
                .Cols(CMlngvsfSearchColKb2).Visible = False                     '最終更新日
                .Cols(CMlngvsfSearchColLotLastUpdate).Visible = False           '入/代/移
                .Cols(CMlngvsfSearchColWfRecipeFlag).Visible = False            'WF個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
                .Cols(CMlngvsfSearchColLotRecipeFlag).Visible = False           'ﾛｯﾄ個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
                .Cols(CMlngvsfSearchColCommitFlag).Visible = False              '号機指定
                .Cols(CMlngvsfSearchColMasEntryID).Visible = False              'ﾏｽﾀ最新ｴﾝﾄﾘ
                .Cols(CMlngvsfSearchColProhibitDeptName).Visible = False        '禁止設定者部署
                .Cols(CMlngvsfSearchColSamplingFlag).Visible = False            'ｻﾝﾌﾟﾘﾝｸﾞﾌﾗｸﾞ
                
                '@情報取得日時初期化
                lblGetInfoDate.Text = vbNullString

                '@該当件数ﾗﾍﾞﾙの初期化
                lblListCnt.Text = vbNullString
                .ScrollPosition = New Point(0,0)
                
                '@使用不可
                .Enabled = False
            End With
            
            '@ｴﾝﾄﾘ情報ｸﾘｱ
            lblEntryID.Text = vbNullString
            lblEntryName.Text = vbNullString
            lblApplyTime.Text = vbNullString
            txtEntrytComments.Text = vbNullString
            
            '@作業ﾒﾓ/ｴﾝﾄﾘｺﾒﾝﾄ使用不可
            '@ｺﾒﾝﾄ初期化判定(条件が未設定の場合)
            If (cmbPD.Text = CMstrCmbAddedCommentNone Or cmbPD.Text = vbNullString) _
                    And txtLotID.Text = vbNullString Then
                txtComments.Text = vbNullString
                txtComments.Enabled = False
                txtEntrytComments.Enabled = False
                cmdSUp.Enabled = False
                cmdSDown.Enabled = False
                cmdEUp.Enabled = False
                cmdEDown.Enabled = False
            End If
            '@ﾎﾞﾀﾝ使用不可
            cmdWPHistory.Enabled = False        '変更履歴確認ﾎﾞﾀﾝ
            cmdLotDisp.Enabled = False          'ﾛｯﾄ詳細情報表示ﾎﾞﾀﾝ
            cmdCancelProhibit.Enabled = False
            cmdProhibit.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSearchResult_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSearchLotList_Disp
    '機　能：検索結果表示
    '引　数：ltypChgTrvListAns()：ﾛｯﾄ一覧取得情報格納
    '　　　：llngLotListCnt：ﾛｯﾄ一覧取得件数格納
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 12:00:11 N.Kasai
    '更新日：2009/12/01 (Tue) 18:02:54 H.Hayashi
    '備　考：
    '　　　：2004/11/29 (Mon) 10:15:16 N.Kasai      DoEventsﾌﾗｸﾞ判定追加
    '　　　：2005/08/01 (Mon) 13:56:39 N.Kasai      L/R表示追加
    '　　　：2005/10/05 (Wed) 11:39:14 N.Kojima     ﾛｯﾄ詳細情報表示ﾎﾞﾀﾝの有効無効制御追加。(ﾕｰｻﾞｰ要望№0088)
    '　　　：2005/12/02 (Fri) 16:11:16 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2006/05/12 (Fri) 13:18:50 T.Kitagawa   制限時間の表示を分合計から時間と分で分割表示する(#,##0時間 #0分)(ﾕｰｻﾞ要望№0186)
    '　　　：2006/06/08 (Thu) 15:22:43 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2006/12/12 (Tue) 14:00:33 N.Kasai      №01415
    '　　　：2008/06/11 (Wed) 15:49:55 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/25 (Wed) 12:08:46 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。(案件№03402)
    '　　　：2009/12/01 (Tue) 18:02:54 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    Private Sub prvvsfSearchLotList_Disp()

        Dim llngCnt                     As Integer      'ｶｳﾝﾄ
        Dim llngDataCnt                 As Integer      'ﾃﾞｰﾀｶｳﾝﾄ
        Dim ltypChgTrvListAns           As List(Of ChgTrvListAns)
        Dim llngLotListCnt              As Integer
        Dim newStyle                    As CellStyle    'NSYS Color
        Dim oldStyle                    As CellStyle    'NSYS Color1
        
        Try
            
            '@最新ﾊﾞｰｼﾞｮﾝを表示しない場合
            If chkNewVersion.Checked = True Then

                'NSYS ﾃﾞｰﾀｶｳﾝﾄ初期化
                llngDataCnt = 0

                '@実ﾃﾞｰﾀ検索
                For llngCnt = 0 To mlngLotListCnt - 1
                    '@ﾛｯﾄのｴﾝﾄﾘID = ﾏｽﾀの最新ｴﾝﾄﾘIDは表示しない
                    If mtypChgTrvListAns(llngCnt).strEntryID <> mtypChgTrvListAns(llngCnt).strMasEntryID Then
                        '@配列の再定義
                        If llngDataCnt = 0 Then
                            If IsNothing(ltypChgTrvListAns) Then
                                ltypChgTrvListAns = New List(Of ChgTrvListAns)
                            Else
                                ltypChgTrvListAns.Clear
                            End If
                        End If
                        '@ﾃﾞｰﾀ格納
                        ltypChgTrvListAns.Add(mtypChgTrvListAns(llngCnt))
                        '@ﾃﾞｰﾀ件数ｶｳﾝﾄ
                        llngDataCnt = llngDataCnt + 1
                    End If
                Next
                '@ﾃﾞｰﾀ件数反映
                llngLotListCnt = llngDataCnt
            Else
                '@全件表示
                ltypChgTrvListAns = mtypChgTrvListAns
                llngLotListCnt = mlngLotListCnt
            End If
            
            With vsfSearchResult
                
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@行数設定
                RemoveHandler vsfSearchResult.EnterCell, AddressOf vsfSearchResult_EnterCell
                RemoveHandler vsfSearchResult.BeforeRowColChange, AddressOf vsfSearchResult_BeforeRowColChange
                .Rows.Count = .Rows.Fixed
                .Rows.Count = llngLotListCnt + 1
                .Row = 0
                AddHandler vsfSearchResult.BeforeRowColChange, AddressOf vsfSearchResult_BeforeRowColChange
                AddHandler vsfSearchResult.EnterCell, AddressOf vsfSearchResult_EnterCell

                '@ｴﾘｱ装置用途情報設定
                For llngCnt = 1 To llngLotListCnt
                    
                    '@ｾﾙ色変更
                    newStyle = .Styles.Add("CustomStyle_BackColor_vbWhite" & llngCnt)
                    newStyle.BackColor = Color.White
                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfSearchColTitle, llngCnt, .Cols.Count - 1)
                    cellRange.Style = newStyle    '白色
                    
                    '@ﾌｫﾝﾄ色変更
                    Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack" & llngCnt)
                    newStyle2.ForeColor = Color.Black
                    Dim cellRange2 As CellRange = .GetCellRange(llngCnt, CMlngvsfSearchColTitle, llngCnt, .Cols.Count - 1)
                    cellRange2.Style = newStyle2  '黒色
                    
                    .SetData(llngCnt, CMlngvsfSearchColNo, llngCnt)                                                           '№
                    .SetData(llngCnt, CMlngvsfSearchColEntryID, ltypChgTrvListAns(llngCnt - 1).strEntryID)                    'ｴﾝﾄﾘID
                    .SetData(llngCnt, CMlngvsfSearchColLotID, ltypChgTrvListAns(llngCnt - 1).strLotID)                        'ﾛｯﾄID
                    .SetData(llngCnt, CMlngvsfSearchColPdID, ltypChgTrvListAns(llngCnt - 1).strPdId)                          '機種ID
                    .SetData(llngCnt, CMlngvsfSearchColFlowClass, ltypChgTrvListAns(llngCnt - 1).strFlowClass)                '種別
                    .SetData(llngCnt, CMlngvsfSearchColCarrierID, ltypChgTrvListAns(llngCnt - 1).strCarrierId)                'ｷｬﾘｱID
                    .SetData(llngCnt, CMlngvsfSearchColPriority, ltypChgTrvListAns(llngCnt - 1).strLotPriority)               '優先順位
                    .SetData(llngCnt, CMlngvsfSearchColOpID, ltypChgTrvListAns(llngCnt - 1).strOpID)                          '大工程
                    .SetData(llngCnt, CMlngvsfSearchColStepID, ltypChgTrvListAns(llngCnt - 1).strStepID)                      '小工程
                    .SetData(llngCnt, CMlngvsfSearchColNowSt, ltypChgTrvListAns(llngCnt - 1).strNowST)                        'ﾛｯﾄ現在状態
                    .SetData(llngCnt, CMlngvsfSearchColLotPos, ltypChgTrvListAns(llngCnt - 1).strCurrentPositionName)         'ﾛｯﾄ位置
                    .SetData(llngCnt, CMlngvsfSearchColLotManagerName, ltypChgTrvListAns(llngCnt - 1).strEngEmpName)          'ﾛｯﾄ担当
                    .SetData(llngCnt, CMlngvsfSearchColProhibitEmpName, ltypChgTrvListAns(llngCnt - 1).strProhibitedEmpName)  '禁止担当者
                    
                    
                    '@工順変更有無の表示
                    If ltypChgTrvListAns(llngCnt - 1).strProcChangeFlag = CMstrProcChangeFlgOn Then
                        .SetData(llngCnt, CMlngvsfSearchColProcChange, CPstrAriFlg)                                           '工順変更有
                    Else
                        .SetData(llngCnt, CMlngvsfSearchColProcChange, vbNullString)                                          '工順変更無
                    End If
                  
                    '@流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ有無の表示
                    If ltypChgTrvListAns(llngCnt - 1).strVersionChangeFlag = CMstrProcChangeFlgOn Then
                        .SetData(llngCnt, CMlngvsfSearchColVerChange, CPstrAriFlg)                                            '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ有
                    Else
                        .SetData(llngCnt, CMlngvsfSearchColVerChange, vbNullString)                                           '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ無
                    End If
                    
                    '@ﾛｯﾄｺﾒﾝﾄ有無の表示
                    If ltypChgTrvListAns(llngCnt - 1).strLotCommentsFlg = CPstrAriFlg Then
                        .SetData(llngCnt, CMlngvsfSearchColLotComments, CPstrAriFlg)                                          'ﾛｯﾄｺﾒﾝﾄ有
                    Else
                        .SetData(llngCnt, CMlngvsfSearchColLotComments, vbNullString)                                         'ﾛｯﾄｺﾒﾝﾄ無
                    End If
                    
                    '@ﾘﾜｰｸ実績の表示
                    If ltypChgTrvListAns(llngCnt - 1).strReworkCount > "0" Then
                        .SetData(llngCnt, CMlngvsfSearchColReworkCount, CPstrAriFlg)                                          'ﾘﾜｰｸ実績あり
                    Else
                        .SetData(llngCnt, CMlngvsfSearchColReworkCount, vbNullString)                                         'なし
                    End If
                    
                    '@----------------------------------------------------------------------------------
                    '@ 背景色の優先順位　VerUp禁止(赤) > VerUp不可(灰) > 保留/停止(黄) > L/R色(青/ﾋﾟﾝｸ)
                    '@----------------------------------------------------------------------------------
                    '@L/Rによる文字色変更
                    Select Case ltypChgTrvListAns(llngCnt - 1).strLcDirection
                        
                        Case CPstrPDIDL
                             '@ｾﾙ背景色変更                                                
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor" & llngCnt)
                            newStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(CPlngLColor)              'Lｶﾗｰ(水色)
                            cellRange = .GetCellRange(llngCnt, CMlngvsfSearchColTitle, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        Case CPstrPDIDR
                             '@ｾﾙ背景色変更                                                        
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor" & llngCnt)
                            newStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(CPlngRColor)              'Rｶﾗｰ(ﾋﾟﾝｸ)
                            cellRange = .GetCellRange(llngCnt, CMlngvsfSearchColTitle, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        Case Else
                            '@ｾﾙ背景色変更                                                            
                            newStyle = .Styles.Add("CustomStyle_BackColor_vbWhite" & llngCnt)
                            newStyle.BackColor = Color.White                                                        '初期(白)
                            cellRange = .GetCellRange(llngCnt, CMlngvsfSearchColTitle, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                    End Select
                    
                    '@ﾌﾗｸﾞ判定(ﾛｯﾄ保留)
                    If ltypChgTrvListAns(llngCnt - 1).strLotHoldFlag = CMstrLotHoldFlgOn Then
                        '@ｾﾙの色変更
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" & llngCnt)
                        newStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(CPlngHoldLotColor)
                        cellRange = .GetCellRange(llngCnt, CMlngvsfSearchColTitle, llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle                                                                  '保留Lotｶﾗｰ
                        '@保留/停止列に表示
                        .SetData(llngCnt, CMlngvsfSearchColKb, _
                                    pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfSearchColKb), CMstrHo))
                    End If
                    
                    '@ﾌﾗｸﾞ判定(ﾛｯﾄ停止)
                    If ltypChgTrvListAns(llngCnt - 1).strLotStopFlag = CMstrLotStopFlgOn Then
                        '@ｾﾙ色変更
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" & llngCnt)
                        newStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(CPlngHoldLotColor)
                        cellRange = .GetCellRange(llngCnt, CMlngvsfSearchColTitle, llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle                                                                  '停止Lotｶﾗｰ(黄色)
                        '@保留/停止列に表示
                        .SetData(llngCnt, CMlngvsfSearchColKb, _
                                    pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfSearchColKb), CMstrTei))
                    End If
                    
                    '@ﾌﾗｸﾞ判定(ﾘﾜｰｸ/追加)
                    Select Case ltypChgTrvListAns(llngCnt - 1).strReworkFlag
                        Case CMstrReworkFlgOn
                            '@"リ"表示
                            .SetData(llngCnt, CMlngvsfSearchColKb, _
                                pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfSearchColKb), CMstrRi))                  'リ
                        Case CMstrReworkFlgOn2
                            '@"追"表示
                            .SetData(llngCnt, CMlngvsfSearchColKb, _
                                pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfSearchColKb), CMstrTui))                 '追
                    End Select
                    
                    '@入替中
                    If ltypChgTrvListAns(llngCnt - 1).strSwapFlag = CMstrSwapFlgOn Then
                        '@ｾﾙの色変更
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray" & llngCnt)
                        newStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(CPlngGridGray)                '灰色
                        cellRange = .GetCellRange(llngCnt, CMlngvsfSearchColTitle, llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle   
                        '@入替/代替/移載列(非表示、確定ﾎﾞﾀﾝ制御用)
                        .SetData(llngCnt, CMlngvsfSearchColKb2, CMstrIre)                                           '入
                        '@保留/停止列に表示
                        .SetData(llngCnt, CMlngvsfSearchColKb, _
                                    pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfSearchColKb), CMstrIre))
                    
                    End If
                    
                    '@代替中
                    If ltypChgTrvListAns(llngCnt - 1).strAltFlag = CMstrAltFlgOn Then
                        '@ｾﾙの色変更
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray" & llngCnt)
                        newStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(CPlngGridGray)                '灰色
                        cellRange = .GetCellRange(llngCnt, CMlngvsfSearchColTitle, llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle   
                        '@入替/代替/移載列(非表示、確定ﾎﾞﾀﾝ制御用)
                        .SetData(llngCnt, CMlngvsfSearchColKb2, CMstrDai)                                           '代
                        '@保留/停止列に表示
                        .SetData(llngCnt, CMlngvsfSearchColKb, _
                                    pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfSearchColKb), CMstrDai))
                    End If
                    
                    '@移載中
                    If ltypChgTrvListAns(llngCnt - 1).strWfCarryFlag = CMstrWFCarryFlgOn Then
                        '@ｾﾙの色変更
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray" & llngCnt)
                        newStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(CPlngGridGray)
                        cellRange = .GetCellRange(llngCnt, CMlngvsfSearchColTitle, llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle                                                                  '灰色
                        '@入替/代替/移載列(非表示、確定ﾎﾞﾀﾝ制御用)
                        .SetData(llngCnt, CMlngvsfSearchColKb2, CMstrIsa)                                           '移
                        '@保留/停止列に表示
                        .SetData(llngCnt, CMlngvsfSearchColKb, _
                                    pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfSearchColKb), CMstrIsa))
                    End If
                    
                    '@流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ禁止有無の表示
                    If ltypChgTrvListAns(llngCnt - 1).strVerUpProhibitedFlag = CMstrProhibitON Then
                        '@ｾﾙの色変更
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngVbColorRed" & llngCnt)
                        newStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(CPlngVbColorRed)
                        cellRange = .GetCellRange(llngCnt, CMlngvsfSearchColTitle, llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle                                                                  '赤色
                        '@流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ列に表示
                        .SetData(llngCnt, CMlngvsfSearchColProhibit, CMstrKin)                                      '禁
                    Else
                        .SetData(llngCnt, CMlngvsfSearchColProhibit, vbNullString)                                  '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ可
                    End If

                    .SetData(llngCnt, CMlngvsfSearchColLotLastUpdate, ltypChgTrvListAns(llngCnt - 1).strLotLastUpdate)            '最終更新日
                    .SetData(llngCnt, CMlngvsfSearchColWfRecipeFlag, ltypChgTrvListAns(llngCnt - 1).strWfRecipeFlag)              'WF個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
                    .SetData(llngCnt, CMlngvsfSearchColLotRecipeFlag, ltypChgTrvListAns(llngCnt - 1).strLotRecipeFlag)            'ﾛｯﾄ個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
                    .SetData(llngCnt, CMlngvsfSearchColCommitFlag, ltypChgTrvListAns(llngCnt - 1).strCommitFlag)                  '号機指定
                    .SetData(llngCnt, CMlngvsfSearchColMasEntryID, ltypChgTrvListAns(llngCnt - 1).strMasEntryID)                  'ﾏｽﾀ最新ｴﾝﾄﾘ
                    .SetData(llngCnt, CMlngvsfSearchColProhibitDeptName, ltypChgTrvListAns(llngCnt - 1).strProhibitedDeptName)    '禁止設定者部署
                    
                    '@ﾏｽﾀの流動票未来工程にｻﾝﾌﾟﾘﾝｸﾞ設定が存在する場合は1
                    .SetData(llngCnt, CMlngvsfSearchColSamplingFlag, ltypChgTrvListAns(llngCnt - 1).strSamplingFlag)              'ｻﾝﾌﾟﾘﾝｸﾞﾌﾗｸﾞ

        '@↓2009/02/24 (Tue) 15:48:35 N.Kojima **************************************************

                    '@-----------------------------------------------
                    '@ ﾌｫﾝﾄ色の設定(組立限定機能)
                    '@　①ﾁｯﾌﾟ品LOT：青色
                    '@-----------------------------------------------
        '@↓2009/12/01 (Tue) 18:04:25 H.Hayashi **************************************************
                    '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"か
        '            If pstrSBID = CPstrSBID2A0 And _
        '                Left$(ltypChgTrvListAns(llngCnt).strSendSBID, 1) = CPstrProductChip Then
                    
                    If pstrSBID = CPstrSBID2A0 And _
                        ltypChgTrvListAns(llngCnt - 1).strSbArea = CPstrProductChip Then
                        
                        '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
        '@↑2009/12/01 (Tue) 18:04:25 H.Hayashi **************************************************

                        oldStyle = .GetCellStyle(llngCnt, CMlngvsfSearchColNo)
                        If oldStyle IsNot Nothing Then
                            newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue_BackColor_#" & _
                                                                       oldStyle.BackColor.ToArgb.ToString("X"))
                            newStyle.BackColor = oldStyle.BackColor
                        Else
                            newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue")
                        End If
                        '@文字色を青色に変更
                        newStyle.ForeColor = Color.Blue
                        cellRange = .GetCellRange(llngCnt, CMlngvsfSearchColNo, _
                            llngCnt, CMlngvsfSearchColSamplingFlag)
                        cellRange.Style = newStyle
                    
                    End If

        '@↑2009/02/24 (Tue) 15:48:35 N.Kojima **************************************************

                    '@高さの設定
                    .Rows(llngCnt).Height = CMlngvsfSearchHeight
                        
                Next llngCnt
                
                '@書式設定
                .Cols(CMlngvsfSearchColNo).TextAlign = TextAlignEnum.RightCenter                   '右詰の中央揃え(№)
                .Cols(CMlngvsfSearchColKb).TextAlign = TextAlignEnum.LeftCenter                    '左詰の中央揃え(保/停/リ/入/代/移)
                .Cols(CMlngvsfSearchColKb2).TextAlign = TextAlignEnum.LeftCenter                   '左詰の中央揃え(入/代/移)
                .Cols(CMlngvsfSearchColProcChange).TextAlign = TextAlignEnum.LeftCenter            '左詰の中央揃え(工順変更有無)
                .Cols(CMlngvsfSearchColVerChange).TextAlign = TextAlignEnum.LeftCenter             '左詰の中央揃え(流動票UP有無)
                .Cols(CMlngvsfSearchColProhibit).TextAlign = TextAlignEnum.LeftCenter              '左詰の中央揃え(VerUp禁止有無)
                .Cols(CMlngvsfSearchColEntryID).TextAlign = TextAlignEnum.LeftCenter               '左詰の中央揃え(ｴﾝﾄﾘID)
                .Cols(CMlngvsfSearchColLotID).TextAlign = TextAlignEnum.LeftCenter                 '左詰の中央揃え(ﾛｯﾄID)
                .Cols(CMlngvsfSearchColPdID).TextAlign = TextAlignEnum.LeftCenter                  '左詰の中央揃え(機種)
                .Cols(CMlngvsfSearchColFlowClass).TextAlign = TextAlignEnum.LeftCenter             '左詰の中央揃え(種別)
                .Cols(CMlngvsfSearchColCarrierID).TextAlign = TextAlignEnum.LeftCenter             '左詰の中央揃え(ｷｬﾘｱID)
                .Cols(CMlngvsfSearchColOpID).TextAlign = TextAlignEnum.LeftCenter                  '左詰の中央揃え(大工程)
                .Cols(CMlngvsfSearchColStepID).TextAlign = TextAlignEnum.LeftCenter                '左詰の中央揃え(小工程)
                .Cols(CMlngvsfSearchColNowSt).TextAlign = TextAlignEnum.LeftCenter                 '左詰の中央揃え(状態)
                .Cols(CMlngvsfSearchColPriority).TextAlign = TextAlignEnum.RightCenter             '右詰の中央揃え(優先順位)
                .Cols(CMlngvsfSearchColReworkCount).TextAlign = TextAlignEnum.LeftCenter           '左詰の中央揃え(ﾘﾜｰｸ実績)
                .Cols(CMlngvsfSearchColLotPos).TextAlign = TextAlignEnum.LeftCenter                '左詰の中央揃え(ﾛｯﾄ位置)
                .Cols(CMlngvsfSearchColLotManagerName).TextAlign = TextAlignEnum.LeftCenter        '左詰の中央揃え(ﾛｯﾄ担当)
                .Cols(CMlngvsfSearchColProhibitEmpName).TextAlign = TextAlignEnum.LeftCenter       '左詰の中央揃え(禁止設定者)
                .Cols(CMlngvsfSearchColLotComments).TextAlign = TextAlignEnum.LeftCenter           '左詰の中央揃え(ｺﾒﾝﾄ有無)
                
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@ｵｰﾄ幅設定
                    .AutoSizeCols(CMlngvsfSearchColNo, .Cols.Count - 1, 9)
                End If

                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort.lngCnt - 1
                        '@該当行をｿｰﾄ
                        RemoveHandler vsfSearchResult.EnterCell, AddressOf vsfSearchResult_EnterCell
                        RemoveHandler vsfSearchResult.BeforeRowColChange, AddressOf vsfSearchResult_BeforeRowColChange
                        .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                        .Sort(SortFlags.UseColSort, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        AddHandler vsfSearchResult.EnterCell, AddressOf vsfSearchResult_EnterCell
                        AddHandler vsfSearchResult.BeforeRowColChange, AddressOf vsfSearchResult_BeforeRowColChange
                    Next llngCnt
                End If

                '@描画ﾛｯｸ解除
                .Redraw = True

                '@ｿｰﾄ検索用ｷｰ(ﾛｯﾄID)がある場合
                If mtypChgSort.strKey <> vbNullString Then
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@ﾛｯﾄIDが同じ場合
                        If .GetData(llngCnt, CMlngvsfSearchColLotID) = mtypChgSort.strKey Then
                            .Row = llngCnt
                            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                            Call pubVsfBeforeSort(vsfSearchResult, CMlngvsfSearchColLotID)
                            
                            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                            Call pubVsfAfterSort(vsfSearchResult, CMlngvsfSearchColLotID)
                            
                            Exit For
                        End If
                    Next llngCnt
                Else
                    .Row = CMlngvsfSearchRowTitle                   'ｶﾚﾝﾄ行の移動
                    .TopRow = CMlngvsfSearchRowTitle                '行
                End If

                '@ｽﾌﾟﾚｯﾄﾞを初期値へ移動
                .LeftCol = CMlngvsfSearchColTitle                   '列

                '@ﾛｯｸ解除
                .Enabled = True

                '@ｾｯﾄﾌｫｰｶｽ処理でEnabled=Falseの場合には、Trueにする
                If .Enabled = True Then
                    Call pubSetFocus(vsfSearchResult)
                End If
            End With
            
            '@作業ﾒﾓ欄を使用可
            txtComments.Enabled = True
            
            '@該当件数ﾗﾍﾞﾙに取得件数を表示
            lblListCnt.Text = Format$(llngLotListCnt, CPstrDateFormatKanma)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSearchLotList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPd_Disp
    '機　能：機種Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 12:09:37 N.Kasai
    '更新日：2007/07/02 (Mon) 14:14:54 N.Kasai
    '備　考：
    '　　　：2005/08/01 (Mon) 14:20:05 N.Kasai      L/R表示追加
    '　　　：2007/07/02 (Mon) 14:14:54 N.Kasai      複数選択へ変更
    Private Sub prvcmbPd_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try
            
        '@↓2007/07/03 (Tue) 09:22:24 N.Kasai **************************************************
            With cmbPD
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .DirectInput = False                                                                                '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                                                    '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                                                             '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                                                        'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                                                                      '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngProductCnt                                                                         '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                                                                '"選択"文字列
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)   'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                                                      'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter                                          '左寄中央揃え
                    
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngProductCnt - 1
                    .AddItem(mtypProductList(llngCnt).strProductID & vbTab & llngCnt)                               'ID/Index
                Next llngCnt
            End With
            
        '    With cmbPD
        '        '@ｽｸﾘｰﾝｻｲｽﾞ初期化
        '        .Clear
        '        .BackColor = vbWhite                                            'ﾊﾞｯｸｶﾗｰ(ｼﾛ)
        '        .Height = CMlngCmbRowHeight                                     '高さ
        '        .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
        '        .ValueCol = CMlngCmbValueCol0                                   '値取得列
        '        .Cols(CMlngCmbGridCol0) = flexAlignLeftCenter                   '左寄中央揃え
        '        .Cols(CMlngCmbGridCol1) = flexAlignLeftCenter                   '左寄中央揃え
        '
        '        '@機種情報ｾｯﾄ
        '        For llngCnt = 1 To llngProducttCnt
        '                '@機種ｺﾝﾎﾞ格納('機種ID&機種名称)
        '                .AddItem ltypProductList(llngCnt).strProductID _
        '                                & vbTab _
        '                                & ltypProductList(llngCnt).strProductName _
        '                                & vbTab _
        '                                & vbNullString _
        '                                & vbTab _
        '                                & vbNullString _
        '                                & vbTab _
        '                                & ltypProductList(llngCnt).strForeColor _
        '                                & vbTab _
        '                                & ltypProductList(llngCnt).strBackColor
        '        Next llngCnt
        '    End With
        '@↑2007/07/03 (Tue) 09:22:24 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPd_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdSearchEnabled_Set
    '機　能：最新取得ﾎﾞﾀﾝ　使用許可
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 12:10:02 N.Kasai
    '更新日：2007/07/02 (Mon) 16:48:51 N.Kasai
    '備　考：
    '　　　：2007/07/02 (Mon) 16:48:51 N.Kasai  機種ｺﾝﾎﾞ複数選択
    Private Sub prvcmdSearchEnabled_Set()

        Try
            
            '@初期化
            cmdSearch.Enabled = False
            
            Select Case True
                '@機種・種別
                Case optSearch0.Checked
                    
                    '@機種
                    If cmbPD.Text = CMstrCmbAddedCommentNone _
                        Or cmbPD.Text = vbNullString Then
                        Exit Sub
                    End If
                    
                    '@種別
                    If cmbFlowClass.Text = CMstrCmbAddedCommentNone _
                        Or cmbFlowClass.Text = vbNullString Then
                        Exit Sub
                    End If
                
                '@ﾛｯﾄID
                Case optSearch1.Checked
                    '@ﾛｯﾄID2桁以上
                    If Len(txtLotID.Text) < CMlngLotMinLeng Then
                        Exit Sub
                    End If
                    '@「_」でないこと
                    '@ﾛｯﾄID1桁目
                    If Strings.Left(txtLotID.Text, 1) = CMstrUnderBar Then
                        Exit Sub
                    End If
                    '@ﾛｯﾄID2桁目
                    If Mid(txtLotID.Text, CMlngLotMaxLeng, 1) = CMstrUnderBar Then
                        Exit Sub
                    End If
            End Select
               
            '@最新取得ﾎﾞﾀﾝ使用可
            cmdSearch.Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdSearchEnabled_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMasEntryList_Sel
    '機　能：最新ｴﾝﾄﾘ表示処理
    '引　数：llngNewRow：該当行
    '戻り値：True:正常、False:異常
    '作成日：2004/11/18 (Thu) 12:11:16 N.Kasai
    '更新日：2005/12/02 (Fri) 16:20:34 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 16:20:34 N.Kasai      ｽｸﾛｰﾙ連動
    Private Function prvMasEntryList_Sel(Optional ByVal llngNewRow As Integer = 0) As Boolean

        Dim lblnAns                     As Boolean              '戻り値(True/False)
        Dim ltypEntryList               As List(Of EntryList)   'ﾏｽﾀ工順取得構造体
        Dim llngEntryListCnt            As Integer              'ﾏｽﾀ工順取得件数
        Dim lstrProductID               As String               'ﾛｰｶﾙ機種変数格納
        Dim lstrClassDivision           As String               '処理区分

        Try
            
            prvMasEntryList_Sel = False
            
            '@機種設定(明細行から機種IDを取得)
            lstrProductID = vsfSearchResult.GetData(llngNewRow, CMlngvsfSearchColPdID)
            
            '@機種ｴﾝﾄﾘ取得
            lstrClassDivision = CPstrCD07   'ClassDivision 07:ｴﾝﾄﾘIDの適用日が最新のものを検索する
            lblnAns = pubblnmasPdEntryList_Sel(CMstrmas_pdentrylistVer, _
                                               lstrProductID, _
                                               ltypEntryList, _
                                               llngEntryListCnt, _
                                               pstrSBID, lstrClassDivision)
            '@結果判定
            If lblnAns = False Then
                Exit Function
            End If
                    
            '@機種ｴﾝﾄﾘが取得できた場合のみ(最新の機種ｴﾝﾄﾘ情報が１件返ってくる)
            If llngEntryListCnt > 0 Then
                '@ﾃﾞﾌｫﾙﾄ値を代入
                llngEntryListCnt = 0
                '@ｴﾝﾄﾘID表示処理
                lblEntryID.Text = ltypEntryList(llngEntryListCnt).strEntryID                                                    'ｴﾝﾄﾘID
                lblEntryName.Text = ltypEntryList(llngEntryListCnt).strEntryName                                                'ｴﾝﾄﾘ名称
                If IsDate(ltypEntryList(llngEntryListCnt).strEntryApplyTime) Then
                    lblApplyTime.Text = Format$(CDate(ltypEntryList(llngEntryListCnt).strEntryApplyTime), CMstrEntryTimeFormat) '適用日時
                Else
                    lblApplyTime.Text = ltypEntryList(llngEntryListCnt).strEntryApplyTime
                End If
                txtEntrytComments.Text = ltypEntryList(llngEntryListCnt).strEntryComments                                       'ｴﾝﾄﾘｺﾒﾝﾄ
                '@ｴﾝﾄﾘｺﾒﾝﾄを使用可
                txtEntrytComments.Enabled = True
                txtEntrytComments.Locked =  True
            End If
            
            prvMasEntryList_Sel = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMasEntryList_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnKakutei_Check
    '機　能：確定ﾎﾞﾀﾝ押下ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:正常、False:異常
    '作成日：2004/11/18 (Thu) 12:52:28 N.Kasai
    '更新日：2007/04/05 (Thu) 15:19:06 N.Kasai
    '備　考：※ｲﾝﾌｫﾒｰｼｮﾝﾒｯｾｰｼﾞは条件によって文字結合で編集して１MSGBOXで表示する。結合文字数が多く
    '　　　　　既存のﾒｯｾｰｼﾞﾎﾞｯｸｽでは改行の制御ができない為、当処理で文字を編集しています。
    '　　　：2005/04/05 (Tue) 09:14:54 S.Deguchi    不具合№621確定ﾁｪｯｸで「投入待ち」の場合もﾒｯｾｰｼﾞを表示しないように修正
    '　　　：2007/01/30 (Tue) 14:32:58 N.Kasai      №01398　   時間制限ｸﾘｱﾒｯｾｰｼﾞ内容を削除
    '　　　：2007/04/05 (Thu) 15:19:06 N.Kasai      №01831     流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ禁止
    Private Function prvblnKakutei_Check() As Boolean

        Dim lstrNowST       As String       'ﾛｯﾄ状態格納
        Dim lstrCommit      As String       '号機設定格納
        Dim lstrWfRecipe    As String       'WFﾚｼﾋﾟ格納
        Dim lstrLotRecipe   As String       'ﾛｯﾄﾚｼﾋﾟ格納
        Dim lstrWk          As String       'ﾒｯｾｰｼﾞ内容格納

        Try

            '@初期化
            prvblnKakutei_Check = False
            
            With vsfSearchResult
            
                '@ﾛｯﾄ状態が「作業待ち」以外の場合
                
                '@ﾛｯﾄ状態取得
                lstrNowST = .GetData(.Row, CMlngvsfSearchColNowSt)
                '@状態の判定処理(流動前の場合は空白のため空白も考慮)
                If lstrNowST <> vbNullString Then
                    '@「作業待ち」判定
                    If CPstrWaitWorkSt <> lstrNowST Then
                        '@「投入待ち」判定
                        If lstrNowST <> CPstrWaitThrowSt Then
                            lstrWk = CMstrBracketLeft & lstrNowST & CMstrBracketRight
                        End If
                    End If
                End If
                
                '@ｶﾚﾝﾄ工程に装置予約が設定されている場合
                
                '@号機指定取得
                lstrCommit = .GetData(.Row, CMlngvsfSearchColCommitFlag)
                '@号機指定の有無判定
                If CMstrCommitFlgOn = lstrCommit Then
                    lstrWk = lstrWk & CMstrGoukiZumi    '[装置予約が設定済]
                End If
            
                '@ｶﾚﾝﾄ工程に個別ﾚｼﾋﾟが設定されている場合
                
                '@ﾚｼﾋﾟ指定取得(WF/LOT)
                lstrWfRecipe = .GetData(.Row, CMlngvsfSearchColWfRecipeFlag)
                lstrLotRecipe = .GetData(.Row, CMlngvsfSearchColLotRecipeFlag)
                '@個別ﾚｼﾋﾟ指定有無判定
                If CMstrWFRecipeFlgOn = lstrWfRecipe Or CMstrLotRecipeFlgOn = lstrLotRecipe Then
                     lstrWk = lstrWk & CMstrRecipeZumi  '[個別レシピが設定済]
                End If
                
                '@ｲﾝﾌｫﾒｰｼｮﾝ文字列の有無判定
                If lstrWk <> vbNullString Then
                    '@"このロットは"　"$のため流動票バージョンアップは次工程から適用されます。"
                    lstrWk = CMstrLotWa & lstrWk & CMstrJikoutei
                End If
                
        '@↓2007/04/05 (Thu) 15:18:44 N.Kasai **************************************************
                '分割情報は必要なし
                '@ﾛｯﾄが分割されている場合
                '@"ロットが分割されています｡$子または親ロットは別途、流動票バージョンアップが必要です｡"
                '@分割ﾌﾗｸﾞ取得
        '        lstrDivide = .Cell(flexcpText, .Row, CMlngvsfSearchColDivideFlag)
        '        '@分割ﾌﾗｸﾞ有無判定
        '        If CMstrDivideFlgOn = lstrDivide Then
        '            If lstrWk <> vbNullString Then
        '                lstrWk = lstrWk & CMstrKaigyou & CMstrLotBunkatu
        '            Else
        '                lstrWk = CMstrLotBunkatu
        '            End If
        '        End If
        '@↑2007/04/05 (Thu) 15:18:44 N.Kasai **************************************************
                
        '@↓2007/01/30 (Tue) 14:32:49 N.Kasai **************************************************
        '        '@時間制限が設定されている場合
        '        '@"ロットは現在時間制限が設定されています。時間制限はクリアされます。"
        '        '@時間制限取得
        '        lstrLimitTime = .Cell(flexcpText, .Row, CMlngvsfSearchColLimitTime)
        '        '@時間制限の有無判定
        '        If lstrLimitTime <> vbNullString Then
        '            If lstrWk <> vbNullString Then
        '                lstrWk = lstrWk & CMstrKaigyou & CMstrJikanSeigen
        '            Else
        '                lstrWk = lstrWk & CMstrJikanSeigen
        '            End If
        '        End If
        '@↑2007/01/30 (Tue) 14:32:49 N.Kasai **************************************************
                
                '@ｲﾝﾌｫﾒｰｼｮﾝ文字列の有無判定
                If lstrWk <> vbNullString Then
                    '@CPstrMsgInf003I(改行できない為、定数が使用できない。但し、番号を採番する為に定数を設定する。)
                    lstrWk = "<TRM3II>$$" & lstrWk
                    '@ｲﾝﾌｫﾒｰｼｮﾝ文字列の編集
                    pstrDMsg = pubstrMsgReplace_Set(lstrWk)
                    '@ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                End If
            End With
            
            '@成功
            prvblnKakutei_Check = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnKakutei_Check"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvcmbFlowClassList_Disp
    '機　能：種別一覧情報ｾｯﾄ
    '引　数：ltypFlowClassList()：種別取得構造体
    '　　　：llngFlowClassCnt：種別取得数
    '戻り値：なし
    '作成日：2005/06/02 (Thu) 12:42:14 S.Deguchi
    '更新日：2007/07/03 (Tue) 10:15:51 N.Kasai
    '備　考：
    Private Sub prvcmbFlowClassList_Disp()

        Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ

        Try

            '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)
            With cmbFlowClass
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .DirectInput = False                                                                                '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                                                    '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                                                             '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                                                        'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = 1                                                                                      '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngFlowClassCnt                                                                       '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                                                                '"選択"文字列
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)   'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                                                      'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter                                          '左寄中央揃え
                
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngFlowClassCnt - 1
                    .AddItem(mtypFlowClassList(llngCnt).strDivisionID & _
                             vbTab & _
                             llngCnt)                                                                               'ID/Index
                Next llngCnt
            
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbFlowClassList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdButtonEnabled_Set
    '機　能：更新ﾎﾞﾀﾝ使用可否制御
    '引　数：なし
    '戻り値：なし
    '作成日：2007/04/10 (Tue) 12:35:35 N.Kasai
    '更新日：2007/04/10 (Tue) 12:35:35
    '備　考：
    Private Sub prvcmdButtonEnabled_Set()

        Try
            
                With vsfSearchResult
                '@固定行判定
                If .Row < 1 Then
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用不可
                    cmdWPHistory.Enabled = False
                    cmdLotDisp.Enabled = False
                    cmdProhibit.Enabled = False
                    cmdCancelProhibit.Enabled = False
                    cmdRegist.Enabled = False
                    
                    '@ｴﾝﾄﾘ情報ｸﾘｱ
                    If cmbPD.Text = vbNullString Then
                        lblEntryID.Text = vbNullString
                        lblEntryName.Text = vbNullString
                        lblApplyTime.Text = vbNullString
                        txtEntrytComments.Text = vbNullString
                    End If
                    
                    Exit Sub
                End If
                
                '@------------------------
                '@変更履歴表示ﾎﾞﾀﾝ制御
                '@------------------------
                '@変更列を判定し履歴表示ﾎﾞﾀﾝ使用可否判定(工順変更/流動票UP有無が空白ではないか)
                If .GetData(.Row, CMlngvsfSearchColProcChange) <> vbNullString Or _
                        .GetData(.Row, CMlngvsfSearchColVerChange) <> vbNullString Then
                    '@使用可
                    cmdWPHistory.Enabled = True
                Else
                    '@使用不可
                    cmdWPHistory.Enabled = False
                End If
                
                '@------------------------
                '@ﾛｯﾄ詳細情報ﾎﾞﾀﾝ制御
                '@------------------------
                '@変更列を判定しﾛｯﾄ詳細情報表示ﾎﾞﾀﾝ使用可否判定(LotIDが空白ではないか)
                If .GetData(.Row, CMlngvsfSearchColLotID) <> vbNullString Then
                    '@使用可
                    cmdLotDisp.Enabled = True
                Else
                    '@使用不可
                    cmdLotDisp.Enabled = False
                End If
                
                '@------------------------
                '@VerUp禁止設定ﾎﾞﾀﾝ制御
                '@------------------------
                '@禁止設定済み
                If .GetData(.Row, CMlngvsfSearchColProhibit) <> vbNullString Then
                    '@使用不可
                    cmdProhibit.Enabled = False
                Else
                    '@使用可
                    cmdProhibit.Enabled = True
                End If
                
                '@------------------------
                '@VerUp禁止解除ﾎﾞﾀﾝ制御
                '@------------------------
                '@禁止設定済み
                If .GetData(.Row, CMlngvsfSearchColProhibit) <> vbNullString Then
                    '@使用可
                    cmdCancelProhibit.Enabled = True
                Else
                    '@使用不可
                    cmdCancelProhibit.Enabled = False
                End If
                
                '@------------------------
                '@確定ﾎﾞﾀﾝ制御
                '@------------------------
                '@入/代/移が設定済み
                If .GetData(.Row, CMlngvsfSearchColKb2) <> vbNullString Then
                    '@使用不可
                    cmdRegist.Enabled = False
                Else
                    '@禁止設定済み
                    If .GetData(.Row, CMlngvsfSearchColProhibit) <> vbNullString Then
                        '@使用不可
                        cmdRegist.Enabled = False
                    Else
                        '@使用可
                        cmdRegist.Enabled = True
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdButtonEnabled_Set"
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

        Select Case m.Msg
            Case WM_ENDSESSION
                'OSのシャットダウンで閉じられようとしている場合
                mblnCloseFromControlMenu = True
                lblnSysCommandScClose = True

            Case WM_SYSCOMMAND
                Select Case (m.WParam.ToInt64() And &HFFF0L)
                    Case SC_CLOSE
                        '[×]ボタン、コントロールメニューの「閉じる」、
                        'コントロールボックスのダブルクリック、
                        'Atl+F4などにより閉じられようとしている場合
                        mblnCloseFromControlMenu = True

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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraAfterVerUpEntry.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfSearchResult.BeforeDoubleClick

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

        End If

    End Sub

End Class
