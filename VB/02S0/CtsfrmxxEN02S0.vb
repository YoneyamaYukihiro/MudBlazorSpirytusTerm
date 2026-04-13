'ﾌｧｲﾙ名：xxEN02S0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：Aトレー管理　メインフォーム
'作成日：2018/09/18 (Tue) 15:08:13 T.Oide
'更新日：2019/03/22 (Fri) 09:43:12 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2018-2019, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Collections.Specialized
Imports System.Security.Permissions
Public Class frmxxEN02S0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02S0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02S0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02S0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02S0)
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
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2019/03/06 (Wed) 13:36:52 T.Oide **************************************************
    '@Private Const CMstrLocalVersion                 As String = "01.00"
    Private Const CMstrLocalVersion                 As String = "01.01"
    '@↑2019/03/06 (Wed) 13:36:52 T.Oide **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrAtray_list____Ver            As String = "01.00"     'AﾄﾚｰﾘｽﾄMsgVer
    Private Const CMstratray_Regist__Ver            As String = "01.00"     'Aﾄﾚｰ登録・更新MsgVer
    Private Const CMstrmas_tapeStickGrListVer       As String = "01.00"     'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟﾘｽﾄ取得

    'ｸﾞﾘｯﾄﾞの列数
    Private Const CMlngvsfATrayColCnt               As Integer = 18

    '@vsfLotListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfATrayNoCol                As Integer = 0             '№
    Private Const CMlngvsfATrayEditCol              As Integer = 1             '変更
    Private Const CMlngvsfATrayWashCol              As Integer = 2             '洗浄
    Private Const CMlngvsfATrayAtrayIdCol           As Integer = 3             'AトレーID
    Private Const CMlngvsfATrayStatusCol            As Integer = 4             'ステータス
    Private Const CMlngvsfATrayClassCol             As Integer = 5             'Aトレー区分
    Private Const CMlngvsfATrayTapeStickGrCol       As Integer = 6             'テープ貼りグループ
    Private Const CMlngvsfATrayACarrieCol           As Integer = 7             'Aキャリア
    Private Const CMlngvsfATrayCommentCol           As Integer = 8             'コメント
    Private Const CMlngvsfATrayCommentHCol          As Integer = 9             'コメント本文
    Private Const CMlngvsfATrayWashUseNumCol        As Integer = 10            '洗浄後使用回数
    Private Const CMlngvsfATrayWashUseLimitCol      As Integer = 11            '洗浄後使用回数上限
    Private Const CMlngvsfATrayUseNumCol            As Integer = 12            '累積使用回数
    Private Const CMlngvsfATrayUseLimitCol          As Integer = 13            '累積使用回数上限
    Private Const CMlngvsfATrayStartTimeCol         As Integer = 14            '使用開始日時
    Private Const CMlngvsfATrayCleanTimeCol         As Integer = 15            '最終洗浄日時
    Private Const CMlngvsfATrayEmpNameCol           As Integer = 16            '最終更新者
    Private Const CMlngvsfATrayEditTimeCol          As Integer = 17            '更新日時

    '@vsfATｒaｙListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMlngvsfATrayNoColT               As String = "№"
    Private Const CMlngvsfATrayEditColT             As String = "変更"
    Private Const CMlngvsfATrayWashColT             As String = "洗浄"
    Private Const CMlngvsfATrayAtrayIdColT          As String = "AトレーID"
    Private Const CMlngvsfATrayStatusColT           As String = "ステータス"
    Private Const CMlngvsfATrayClassColT            As String = "Aトレー区分"
    Private Const CMlngvsfATrayTapeStickGrColT      As String = "テープ貼り" & vbCrLf & "グループ"
    Private Const CMlngvsfATrayACarrieColT          As String = "Aキャリア"
    Private Const CMlngvsfATrayCommentColT          As String = "コメント"
    Private Const CMlngvsfATrayCommentColHT         As String = "コメント" & vbCrLf & "本文"
    Private Const CMlngvsfATrayWashUseNumColT       As String = "洗浄後" & vbCrLf & "使用回数"
    Private Const CMlngvsfATrayWashUseLimitColT     As String = "洗浄後使用" & vbCrLf & "回数上限"
    Private Const CMlngvsfATrayUseNumColT           As String = "累積" & vbCrLf & "使用回数"
    Private Const CMlngvsfATrayUseLimitColT         As String = "累積使用" & vbCrLf & "回数上限"
    Private Const CMlngvsfATrayStartTimeColT        As String = "使用開始" & vbCrLf & "日時"
    Private Const CMlngvsfATrayCleanTimeColT        As String = "最終洗浄" & vbCrLf & "日時"
    Private Const CMlngvsfATrayEmpNameColT          As String = "最終更新者"
    Private Const CMlngvsfATrayEditTimeColT         As String = "更新日時"


    '@vsfATｒaｙListの定数宣言(列幅)
    Private Const CMlngvsfATrayNoColW               As Integer = 40           '№
    Private Const CMlngvsfATrayEditColW             As Integer = 42           '変更
    Private Const CMlngvsfATrayWashColW             As Integer = 42           '洗浄
    Private Const CMlngvsfATrayAtrayIdColW          As Integer = 100          'AトレーID
    Private Const CMlngvsfATrayStatusColW           As Integer = 95           'ステータス
    Private Const CMlngvsfATrayClassColW            As Integer = 97           'Aトレー区分
    Private Const CMlngvsfATrayTapeStickGrColW      As Integer = 107          'テープ貼りグループ
    Private Const CMlngvsfATrayACarrieColW          As Integer = 88           'Aキャリア
    Private Const CMlngvsfATrayCommentColW          As Integer = 88           'コメント
    Private Const CMlngvsfATrayCommentColHW         As Integer = 88           'コメント本文
    Private Const CMlngvsfATrayWashUseNumColW       As Integer = 90           '洗浄後使用回数
    Private Const CMlngvsfATrayWashUseLimitColW     As Integer = 90           '洗浄後使用回数上限
    Private Const CMlngvsfATrayUseNumColW           As Integer = 90           '累積使用回数
    Private Const CMlngvsfATrayUseLimitColW         As Integer = 90           '累積使用回数上限
    Private Const CMlngvsfATrayStartTimeColW        As Integer = 125          '使用開始日時
    Private Const CMlngvsfATrayCleanTimeColW        As Integer = 125          '最終洗浄日時
    Private Const CMlngvsfATrayEmpNameColW          As Integer = 125          '最終更新者
    Private Const CMlngvsfATrayEditTimeColW         As Integer = 125          '更新日時

    '@Aﾄﾚｰｽﾃｰﾀｽ
    Private Const CMstrStatusReady                  As String = "0"
    Private Const CMstrStatusReadyName              As String = "使用可"
    Private Const CMstrStatusActive                 As String = "1"
    Private Const CMstrStatusActiveName             As String = "使用中"
    Private Const CMstrStatusProhibit               As String = "2"
    Private Const CMstrStatusProhibitName           As String = "使用不可"
    Private Const CMstrStatusWash                   As String = "3"
    Private Const CMstrStatusWashName               As String = "洗浄中"

    '@vsfATraｙListの定数宣言
    Private Const CMlngGridTitleRow                 As Integer = 0             'ﾀｲﾄﾙ行

    '@ｺﾝﾎﾞ
    Private Const CMlngCmbFontSize                  As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                  As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCMbSelectMode                As Integer = 1                         '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMlngCmbRowHeight                 As Integer = 18                        'ﾘｽﾄ行の高さ
    Private Const CMstrCmbAddedComment              As String = " 項目選択"                '表示 文字列
    Private Const CMlngCmbGridCol0                  As Integer = 0                         '選択列数
    Private Const CMstrCmbCheckOn                   As String = "1"                        'ﾁｪｯｸON
    Private Const CMstrCmbCheckOff                  As String = "0"                        'ﾁｪｯｸOff
    Private Const CMlngCmbGroupCols                 As Integer = 1                         'ｸﾞﾙｰﾌﾟ列数

    '@ﾎﾞﾀﾝIndex
    Private Const CMlngWash                         As Integer = 0                         '洗浄ﾎﾞﾀﾝ
    Private Const CMlngWashComp                     As Integer = 1                         '洗浄完了ﾎﾞﾀﾝ
    Private Const CMlngRegist                       As Integer = 2                         '確定ﾎﾞﾀﾝ

    '@atray.regist__のCLASS_DIVISION
    Private Const CMstrAtrayRegClassDiv_New         As String = "0"                     '新規登録
    Private Const CMstrAtrayRegClassDiv_Edit        As String = "1"                     '更新
    Private Const CMstrAtrayRegClassDiv_Wash        As String = "2"                     '洗浄
    Private Const CMstrAtrayRegClassDiv_WashComp    As String = "3"                     '洗浄完了

    '@ｸﾞﾘｯﾄﾞのｺﾝﾎﾞﾘｽﾄ
    Private Const CMstrStatusList                   As String = "#0;使用可能|#1;使用中|#2;使用不可|#3;洗浄中|"      '@ｽﾃｰﾀｽのｺﾝﾎﾞﾘｽﾄ
    Private Const CMstrAtrayClassList               As String = "#PRODUCT;製品|#MONITOR;モニタ|#DUMMY;ダミー|"      'Aﾄﾚｰ区分のｺﾝﾎﾞﾘｽﾄ

    '@変更列の文字列
    Private Const CMstrEdit                         As String = "変"
    Private Const CMstrNew                          As String = "新"

    '@新規追加、ｺﾋﾟｰ
    Private Const CMstrLineNew                      As String = "New"
    Private Const CMstrLineCopy                     As String = "Copy"

    '@ﾒｯｾｰｼﾞ表示用
    Private Const CMstrGridChgString                As String = "変更"
    '@↓2019/03/06 (Wed) 14:01:10 T.Oide **************************************************
    Private Const CMstrTray                         As String = "トレー情報"
    '@↑2019/03/06 (Wed) 14:01:10 T.Oide **************************************************

    '@項目行
    Private Const CMlngTitleRow                     As Integer = 0             'ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ行

    '@色の定数宣言
    Private Const CMlngBackColorSBlue               As Integer = &HFFFFC0      '選択行の背景色(水色)

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN02S0

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow                   As Integer = 3             'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mstrComments                            As String                   'ｺﾒﾝﾄ退避
    Private mtypChgSort                             As ChgSort                  'ｿｰﾄ保持用
    Private mstrTapeStickGr                         As String                   'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
    Private mstrAtrayClass                          As String                   'Aﾄﾚｰｸﾗｽ
    Private mstrUseLimit                            As String                   '累積上限回数
    Private mstrWashUseLimit                        As String                   '洗浄後上限回数
    Private mblnEventCancelFlag                     As Boolean                  'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
    Private mblnWashFlag                            As Boolean                  '洗浄ﾁｪｯｸﾌﾗｸﾞ
    Private mblnWashCompFlag                        As Boolean                  '洗浄完了ﾌﾗｸﾞ
    Private mblnAtrayDataEditFlag                   As Boolean                  'Aﾄﾚｰﾃﾞｰﾀ編集ﾌﾗｸﾞ
    Private mblnAtrayNewDataFlag                    As Boolean                  '新規Aﾄﾚｰﾃﾞｰﾀﾌﾗｸﾞ
    Private mstrcmbTapeStickGr                      As String                   'ﾊﾟﾈﾙ識別ｺﾝﾎﾞ退避用
    Private mstAtrayId                              As String                   'AﾄﾚｰID
    Private mtypTapeStickList                       As TapeStickGrList          'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟﾘｽﾄ
    Private mstrcmbAtrayClass                       As String                   'Aﾄﾚｰｸﾗｽ
    Private buttonProcessing                        As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                  'NSYS WindowCloseフラグ

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
    '機　能：ACT初期設定および初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:15:22 T.Oide
    '更新日：2019/03/20 (Wed) 10:29:41 T.Oide
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns             As Boolean
        Dim lstrFormName        As String
        Dim lstrEventName       As String

        Try
            
            '@初期化
            lstrFormName = Me.Text
            lstrEventName = "Form_Load()"
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02S0, CMstrLocalVersion)
            
            '@取得結果判定
            If lblnAns = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '================
            '@Aトレー区分ｺﾝﾎﾞ初期化
            '================
            Call prvcmbAtrayClass_Set()
            
            '================
            '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ一覧取得
            '================
            lblnAns = pubblnMasTapeStickGrList_Sel(CMstrmas_tapeStickGrListVer, _
                                                   mtypTapeStickList, pstrSBID)
            '@結果判定
            If lblnAns = False Then
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If

            '@ ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟｺﾝﾎﾞ設定
            Call prvcmbTapStickGr_Disp()

            '================
            '@AトレーID初期化
            '================
            txtA_TrayId.Text = vbNullString

        '@↓2019/03/20 (Wed) 12:09:32 T.Oide **************************************************
            '================
            '@ｺﾒﾝﾄ初期化
            '================
            Call txtComments_init()
        '@↑2019/03/20 (Wed) 12:09:32 T.Oide **************************************************
            
            '================
            '@ｸﾞﾘｯﾄﾞの初期化
            '================
            Call prvvsfATrayList_Init()
            
            '================
            '@変数初期化
            '================
            '@ｿｰﾄ保持用構造体 初期化
            With mtypChgSort
            
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                Else
                    .typChgSortList.Clear
                End If
                
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
                
            End With
            
            '@=======================
            '@ 最新取得ﾎﾞﾀﾝ押下処理
            '@=======================
            Call cmdNowList_Click(cmdNowList,New EventArgs)
            
            '@ボタン有効/無効
            Call prvCmdButtonEnable()
            
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

    '関数名：cmbAtrayClass_Change
    '機　能：再選択された場合ﾘｽﾄをｸﾘｱｰする
    '引　数：なし
    '戻り値：
    '作成日：2018/09/18 (Tue) 15:15:48 T.Oide
    '更新日：2018/09/18 (Tue) 15:15:48
    '備　考：
    Private Sub cmbAtrayClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbAtrayClass.Change

        Try

            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ中か
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If

            '@編集中確認
            If prvChkEdit <> True Then
                mblnEventCancelFlag = True
                '@元に戻す
                cmbAtrayClass.Text = mstrcmbAtrayClass
                mblnEventCancelFlag = False
                Exit Sub
            End If
            
            '@現在値退避
            mstrcmbAtrayClass = cmbAtrayClass.Text
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfATrayList_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbAtrayClass_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbTapeStickGr_Change
    '機　能：再選択された場合ﾘｽﾄをｸﾘｱｰする
    '引　数：なし
    '戻り値：
    '作成日：2018/09/18 (Tue) 15:16:25 T.Oide
    '更新日：2018/09/18 (Tue) 15:16:25
    '備　考：
    Private Sub cmbTapeStickGr_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTapeStickGr.Change

        Try

            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ中か
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            '@編集中確認
            If prvChkEdit <> True Then
                mblnEventCancelFlag = True
                '@元に戻す
                cmbTapeStickGr.Text = mstrcmbTapeStickGr
                mblnEventCancelFlag = False
                Exit Sub
            End If
               
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfATrayList_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbTapeStickGr_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtA_TrayId_Change
    '機　能：検索条件のAトレーIDが変わった場合、ｸﾞﾘｯﾄﾞをｸﾘｱする
    '引　数：なし
    '戻り値：なし
    '作成日：2018/10/04 (Thu) 15:29:58 T.Oide
    '更新日：2018/10/04 (Thu) 15:29:58
    '備　考：
    Private Sub txtA_TrayId_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtA_TrayId.Change

        Try
            
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ中か
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            '@編集中確認
            If prvChkEdit <> True Then
                mblnEventCancelFlag = True
                '@元に戻す
                txtA_TrayId.Text = mstAtrayId
                mblnEventCancelFlag = False
                Exit Sub
            End If
               
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfATrayList_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbTapeStickGr_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：
    '作成日：2018/09/18 (Tue) 15:16:56 T.Oide
    '更新日：2018/09/18 (Tue) 15:16:56
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm         As Boolean
        
        Try          
                        
            'ｵﾌﾞｼﾞｪｸﾄ初期化
            If mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort.typChgSortList.Clear
            End If
            mstrTapeStickGr = vbNullString
            mstrAtrayClass = vbNullString
            mstrUseLimit = vbNullString
            mstrWashUseLimit = vbNullString

            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@=======================
                '@　ACTｵﾌﾞｼﾞｪｸﾄの開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                '@処理結果判定
                If lblnAnsTerm = True Then
                    '@結果：正常の場合
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@=======================
                '@　ﾒﾆｭｰを広げる処理
                '@=======================
                Call pubMenuExpand_Disp()
            End If
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowList_Click
    '機　能：最新取得ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:17:24 T.Oide
    '更新日：2019/03/20 (Wed) 11:58:56 T.Oide
    '備　考：
    Public Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click
        
        Dim ltypAtrayList           As typeAtrayList                'Aﾄﾚｰﾘｽﾄ
        Dim lstrAtrayClass          As List(Of String)              'Aﾄﾚｰ区分
        Dim lstrTapeStickGr         As List(Of String)              'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
        Dim llngCnt                 As Integer                      'ｶｳﾝﾀ
        Dim llngLoopCnt             As Integer                      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lblnRet                 As Boolean                      'ACTﾒｯｾｰｼﾞ取得結果
        Dim lstrFormName            As String                       'ﾌｫｰﾑ名
        Dim lstrEventName           As String                       'ｲﾍﾞﾝﾄ名
        Dim lstrTemp()              As String

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            lstrFormName = Me.Name
            lstrEventName = "cmdNowList_Click"
            
            '@編集中確認
            If prvChkEdit <> True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽﾁｪｯｸｽﾀｰﾄ
            Call pubResponseStart(lstrFormName, lstrEventName)

            '編集ﾌﾗｸﾞ変数初期化
            mblnWashFlag = False
            mblnWashCompFlag = False
            mblnAtrayDataEditFlag = False
            mblnAtrayNewDataFlag = False
            
            
            '@Aﾄﾚｰ区分を配列に格納
            llngCnt = cmbAtrayClass.ValueCount
            If llngCnt > 0 Then
                lstrAtrayClass = New List(Of String)
                lstrTemp = Split(cmbAtrayClass.Value, vbTab)
                For llngLoopCnt = 0 To lstrTemp.Count -1
                    lstrAtrayClass.Add(lstrTemp(llngLoopCnt))
                Next llngLoopCnt
            Else
                llngCnt = 0
                lstrAtrayClass = New List(Of String)
                lstrAtrayClass.Add(vbNullString)
            End If
            
            '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟを配列に格納
            llngCnt = cmbTapeStickGr.ValueCount
            If llngCnt > 0 Then
                lstrTapeStickGr = New List(Of String)
                lstrTemp = Split(cmbTapeStickGr.Value, vbTab)
                For llngLoopCnt = 0 To lstrTemp.Count -1
                    lstrTapeStickGr.Add(lstrTemp(llngLoopCnt))
                Next llngLoopCnt
            Else
                llngCnt = 0
                lstrTapeStickGr = New List(Of String)
                lstrTapeStickGr.Add(vbNullString)
            End If

            '@Aトレー一覧取得
            lblnRet = pubblnAtrayList_Sel(CMstrAtray_list____Ver, _
                                          ltypAtrayList, _
                                          lstrAtrayClass, _
                                          lstrTapeStickGr, _
                                          txtA_TrayId.Text)

            '@取得結果判定
            If lblnRet Then
                '@成功の場合、ﾃﾞｰﾀをｸﾞﾘｯﾄﾞ表示
                Call prvvsfATrayList_Disp(ltypAtrayList)
                txtComments.Enabled = True
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@失敗の場合、ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdNowList)
            End If
            
        '@↓2019/03/20 (Wed) 11:58:51 T.Oide **************************************************
            '@ﾎﾞﾀﾝの有効/無効
            Call prvCmdButtonEnable()
        '@↑2019/03/20 (Wed) 11:58:51 T.Oide **************************************************
            
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

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:18:06 T.Oide
    '更新日：2018/09/18 (Tue) 15:18:06
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim lblnUpd         As Boolean
        Dim ltypCommonInfo  As CommonInfo

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            '@変数初期化
            lblnUpd = False

            '@編集中確認
            If prvChkEdit <> True Then
                Exit Sub
            End If
                        
            '@=======================
            '@　終了処理
            '@=======================
            Call publngEnd_Proc(CPstrKeyEN02S0, ltypCommonInfo)

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

    '関数名：cmdRegist_Click
    '機　能：Aﾄﾚｰ情報変更確定
    '引　数：Index：0：洗浄ﾎﾞﾀﾝ、1:洗浄完了ﾎﾞﾀﾝ、2：確定ﾎﾞﾀﾝ
    '戻り値：なし
    '作成日：2018/10/23 (Tue) 16:53:33 T.Oide
    '更新日：2018/10/23 (Tue) 16:53:33
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist0.Click,cmdRegist1.Click,cmdRegist2.Click

        Dim lblnAns                     As Boolean
        Dim lstrFormName                As String
        Dim lstrEventName               As String
        Dim ltypAtrayRegist             As typAtrayRegist
        Dim Index                       As Integer

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS Index設定
            Select sender.Name

                Case cmdRegist0.Name
                    Index = 0

                Case cmdRegist1.Name
                    Index = 1

                Case cmdRegist2.Name
                    Index = 2

            End select

            '@登録ﾃﾞｰﾀﾁｪｯｸ
            If prvChckData = False Then
                Exit Sub
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_click"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@変更ﾃﾞｰﾀを変数に格納
            Call prvSetAtrayRegist(ltypAtrayRegist, Index)

            '@更新ﾒｯｾｰｼﾞ発行
            lblnAns = pubblnAtrayRegist(CMstratray_Regist__Ver, ltypAtrayRegist)

            '@結果確認
            If lblnAns Then

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0046, CMstrTray)
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)

                '@変更ﾌﾗｸﾞ初期化
                mblnWashFlag = False
                mblnWashCompFlag = False
                mblnAtrayDataEditFlag = False
                mblnAtrayNewDataFlag = False

                '@再表示
                Call cmdNowList_Click(cmdNowList,New EventArgs)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Call pubSetFocus(cmdNowList)

            End If

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

    '関数名：txtComments_Change
    '機　能：ｺﾒﾝﾄ入力
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:19:05 T.Oide
    '更新日：2019/03/20 (Wed) 10:20:45 T.Oide
    '備　考：
    Private Sub txtComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.Change
        
        Dim llngNowByte                 As Integer
        
        Try
            
            '@ﾀｲﾄﾙの場合処理しない
            If vsfATrayList.Row <= CMlngGridTitleRow Then
                Exit Sub
            End If
            
        '@↓2019/03/20 (Wed) 10:20:42 T.Oide **************************************************
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtComments.NowByte
        '@↑2019/03/20 (Wed) 10:20:42 T.Oide **************************************************
            
            '@txt文字数表示
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)
            
            '@ｺﾒﾝﾄをｾｯﾄする
            With vsfATrayList
            
                '@ｸﾞﾘｯﾄﾞのｺﾒﾝﾄとｺﾒﾝﾄの内容が異なるか
                If Trim(.GetData(.Row, CMlngvsfATrayCommentHCol)) <> Trim(txtComments.Text) Then
                    
                    '@ｺﾒﾝﾄの内容をｸﾞﾘｯﾄﾞに反映
                    .SetData(.Row, CMlngvsfATrayCommentHCol, txtComments.Text)    '@ｺﾒﾝﾄ内容をｸﾞﾘｯﾄﾞにｾｯﾄ
                    
                    '@新規以外か
                    If .GetData(.Row, CMlngvsfATrayEditCol) <> CMstrNew Then
                        .SetData(.Row, CMlngvsfATrayEditCol, CMstrEdit)                   '@「変」表示
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                        newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                        Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfATrayCommentCol)
                        cellRange.Style = newStyle '@色を変える
                    End If
                    
                    '@「あり」表示
                    If .GetData(.Row, CMlngvsfATrayCommentHCol) <> vbNullString Then
                        .SetData(.Row, CMlngvsfATrayCommentCol, CPstrAriFlg)
                    Else
                        .SetData(.Row, CMlngvsfATrayCommentCol, vbNullString)
                    End If
                    
                    '@編集ﾌﾗｸﾞｾｯﾄ
                    mblnAtrayDataEditFlag = True
                    
                    '@ﾎﾞﾀﾝの有効/無効
                    Call prvCmdButtonEnable()
                    
                End If
            End With

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '機　能：ｺﾒﾝﾄ ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:19:33 T.Oide
    '更新日：2018/09/18 (Tue) 15:19:33
    '備　考：
    Private Sub txtComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComments.KeyUp
        
        Try
            
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
    '機　能：ｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:19:48 T.Oide
    '更新日：2018/09/18 (Tue) 15:19:48
    '備　考：
    Private Sub txtComments_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_Validate
    '機　能：ｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '引　数：Cansel:ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:20:04 T.Oide
    '更新日：2018/09/18 (Tue) 15:20:04
    '備　考：
    Private Sub txtComments_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtComments.Validating
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞが立ている場合処理中止
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            With vsfATrayList
            
                '@退避したｺﾒﾝﾄと違っているか
                If Trim(mstrComments) <> Trim(txtComments.Text) Then
                
                    .SetData(.Row, CMlngvsfATrayCommentHCol, txtComments.Text)    '@ｸﾞﾘｯﾄﾞにｺﾒﾝﾄｾｯﾄ
                    
                    '@新規以外か
                    If .GetData(.Row, CMlngvsfATrayEditCol) <> CMstrNew Then
                    
                        .SetData(.Row, CMlngvsfATrayEditCol, CMstrEdit)       '@変更表示
                        mblnAtrayDataEditFlag = True                                    '@編集中ﾌﾗｸﾞｾｯﾄ
                        
                    End If
                    
                End If
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ｺﾒﾝﾄ欄ｽｸﾛｰﾙｱｯﾌﾟ
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:20:34 T.Oide
    '更新日：2018/09/18 (Tue) 15:20:34
    '備　考：
    Private Sub cmdSUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSUp.Click
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUp
            Call pubtxtCmdUp_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)
            
            Call pubSetFocus(txtComments)

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
    '機　能：ｺﾒﾝﾄ欄ｽｸﾛｰﾙｱｯﾌﾟ
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:20:56 T.Oide
    '更新日：2018/09/18 (Tue) 15:20:56
    '備　考：
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

            Call pubSetFocus(txtComments)

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

    '関数名：vsfATrayList_AfterSort
    '機　能：ｸﾞﾘｯﾄﾞのｿｰﾄ後処理
    '引　数：col:列 Order:ｿｰﾄ値
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:21:09 T.Oide
    '更新日：2018/09/18 (Tue) 15:21:09
    '備　考：
    Private Sub vsfATrayList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfATrayList.AfterSort
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfATrayList.Rows.Count <= vsfATrayList.Rows.Fixed Then
                Return
            End If
            
            AddHandler vsfATrayList.BeforeRowColChange,AddressOf vsfATrayList_BeforeRowColChange

            '@ｿｰﾄ順を格納
            With mtypChgSort
                .lngCnt = .lngCnt + 1
                Dim typChgSortListTmp As New ChgSortList

                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                typChgSortListTmp.lngCol = e.Col
                typChgSortListTmp.lngOrder = e.Order

                .typChgSortList.Add(typChgSortListTmp)
            End With
            
            '@ｿｰﾄ後処理
            Call pubVsfAfterSort(vsfATrayList, CMlngvsfATrayAtrayIdCol,Nothing, Nothing, False, False, False, False)

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfATｒaｙList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfATrayList_BeforeEdit
    '機　能：ｸﾞﾘｯﾄﾞの変更前処理
    '引　数：Row:行 Col:列 Cancel:ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:21:24 T.Oide
    '更新日：2019/03/06 (Wed) 14:16:44 T.Oide
    '備　考：
    Private Sub vsfATrayList_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfATrayList.BeforeEdit

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfATrayList.Rows.Count <= vsfATrayList.Rows.Fixed Then
                Return
            End If
            
            With vsfATrayList
                
                '@ｶﾗﾑで処理分岐
                Select Case e.Col

                    '@ｺﾒﾝﾄ行の場合
                    Case CMlngvsfATrayCommentCol
                    
                        '@変数にｺﾒﾝﾄを退避
                        mstrComments = .GetData(e.Row, e.Col)
                    
                End Select
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfATｒaｙList_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfATrayList_AfterEdit
    '機　能：Aﾄﾚｰ一覧編集（編集した行に“編集”を表示(編集したことを識別)）
    '引　数：変更行: Row 変更列:Col
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:21:41 T.Oide
    '更新日：2018/09/18 (Tue) 15:21:41
    '備　考：
    Private Sub vsfATrayList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfATrayList.AfterEdit
        
        Dim lstrTitle       As String
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfATrayList.Rows.Count <= vsfATrayList.Rows.Fixed Then
                Return
            End If
            
            With vsfATrayList
                
                '@新規以外か
                If .GetData(.Row, CMlngvsfATrayEditCol) <> CMstrNew Then
                
                    '@新規ﾌﾗｸﾞ、洗浄ﾌﾗｸﾞ、洗浄完了ﾌﾗｸﾞがいずれかTrueの場合編集させない
                    If mblnAtrayNewDataFlag = True Or _
                       mblnWashFlag = True Or _
                       mblnWashCompFlag = True Then
                        
                        '@編集列のﾀｲﾄﾙ取得(ﾒｯｾｰｼﾞ表示用)
                        lstrTitle = .GetData(CMlngTitleRow, e.Col)
                        
                        '@"<TRM156W>$$ 編集中のデータを確定してから[%1]を行ってください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0156, lstrTitle & CMstrGridChgString)
                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                        
                        '@元の値に戻す
                       .SetData(.Row, CMlngvsfATrayTapeStickGrCol, mstrTapeStickGr)
                       .SetData(.Row, CMlngvsfATrayClassCol, mstrAtrayClass)
                       .SetData(.Row, CMlngvsfATrayWashUseLimitCol, mstrWashUseLimit)
                       .SetData(.Row, CMlngvsfATrayUseLimitCol, mstrUseLimit)
                        
                        Exit Sub
                        
                    End If
                    
                End If
            
                '@ｶﾗﾑにより処理分岐
                Select Case .Col
                
                    '@Aﾄﾚｰ区分の場合
                    Case CMlngvsfATrayClassCol
                    
                        '@Aﾄﾚｰ区分が製品以外の場合は、貼りｸﾞﾙｰﾌﾟは空にする
                        If .GetData(e.Row, CMlngvsfATrayClassCol) <> CPstrUseIDProduct Then
                            .SetData(e.Row, CMlngvsfATrayTapeStickGrCol, vbNullString)
                        End If
                
                    '@洗浄後上限回数か累積上限回数の場合
                    Case CMlngvsfATrayWashUseLimitCol, CMlngvsfATrayUseLimitCol
                        
                        '@入力値をﾁｪｯｸ
                        If prvblnInput_Chk(e.Row) = False Then
                        
                            '@NGの場合
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001F)
                            '@<TRM1FW>$$数値を入力してください。
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@入力をｸﾘｱ
                            .SetData(e.Row, e.Col, vbNullString)
                        
                        End If
                        
                End Select
                   
                '@変更前の値と異なるか(ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ、Aﾄﾚｰ区分、洗浄後使用回数上限、累積使用回数上限)
                If mstrTapeStickGr <> .GetData(.Row, CMlngvsfATrayTapeStickGrCol) Or _
                   mstrAtrayClass <> .GetData(.Row, CMlngvsfATrayClassCol) Or _
                   mstrWashUseLimit <> .GetData(.Row, CMlngvsfATrayWashUseLimitCol) Or _
                   mstrUseLimit <> .GetData(.Row, CMlngvsfATrayUseLimitCol) Then
                   
                    '@変更されている場合は、ﾊﾞｯｸｶﾗｰを水色にする
                    Select Case .Col
                        
                        '@ﾄﾚｰ区分
                        Case CMlngvsfATrayClassCol
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                            Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfATrayClassCol)
                            cellRange.Style = newStyle
                        
                        '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                        Case CMlngvsfATrayTapeStickGrCol
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                            Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfATrayTapeStickGrCol)
                            cellRange.Style = newStyle
                        
                        '@洗浄後上限回数
                        Case CMlngvsfATrayWashUseLimitCol
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                            Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfATrayWashUseLimitCol)
                            cellRange.Style = newStyle
                        
                        '@累積上限回数
                        Case CMlngvsfATrayUseLimitCol
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                            Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfATrayUseLimitCol)
                            cellRange.Style = newStyle
                        
                    End Select
                    
                    '@変更列は空か(新規の場合は変えたくないので)
                    If .GetData(.Row, CMlngvsfATrayEditCol) = vbNullString Then
                        
                        '@「変更」を表示
                        .SetData(.Row, CMlngvsfATrayEditCol, CMstrEdit)
                        
                        '@編集ﾌﾗｸﾞをｾｯﾄ
                        mblnAtrayDataEditFlag = True
                    
                    End If
                    
                End If
                
            End With

            '@ﾎﾞﾀﾝ有効/無効
            Call prvCmdButtonEnable()

            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfATｒaｙList_AfterEdit()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfATrayList_AfterUserResize
    '機　能：ｸﾞﾘｯﾄﾞ 列幅変更時処理
    '引　数：Row：行番号
    '　　　：Col：列番号
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:22:32 T.Oide
    '更新日：2018/09/18 (Tue) 15:22:32
    '備　考：
    Private Sub vsfATrayList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfATrayList.AfterResizeColumn, vsfATrayList.AfterResizeRow

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfATrayList.Rows.Count <= vsfATrayList.Rows.Fixed Then
                Return
            End If

            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfATｒaｙList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfATrayList_BeforeRowColChange
    '機　能：ｶﾚﾝﾄ行列変更時処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:22:48 T.Oide
    '更新日：2018/09/18 (Tue) 15:22:48
    '備　考：
    Private Sub vsfATrayList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfATrayList.BeforeRowColChange
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfATrayList.Rows.Count <= vsfATrayList.Rows.Fixed Then
                Return
            End If
            
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞが立ている場合処理中止
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            '@現在行が0以上で且つOld行と違っているか
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
            
                '@ｿｰﾄｷｰを退避
                mtypChgSort.strKey = vsfATrayList.GetData(e.NewRange.r1, CMlngvsfATrayAtrayIdCol)
                
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfATｒaｙList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfATrayList_BeforeSort
    '機　能：ｿｰﾄの前処理
    '引　数：Col：
    '　　　：Order：
    '戻り値：
    '作成日：2018/09/18 (Tue) 15:23:21 T.Oide
    '更新日：2018/09/18 (Tue) 15:23:21
    '備　考：
    Private Sub vsfATrayList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfATrayList.BeforeSort
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfATrayList.Rows.Count <= vsfATrayList.Rows.Fixed Then
                Return
            End If
            
            RemoveHandler vsfATrayList.BeforeRowColChange,AddressOf vsfATrayList_BeforeRowColChange

            '@ｿｰﾄ前のｶﾚﾝﾄKey値の格納処理
            Call pubVsfBeforeSort(vsfATrayList, CMlngvsfATrayAtrayIdCol)
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfATｒaｙList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfATrayList_ChangeEdit
    '機　能：ｸﾞﾘｯﾄﾞｺﾝﾎﾞ変更後、編集状態から抜ける
    '引　数：なし
    '戻り値：
    '作成日：2018/10/16 (Tue) 16:12:52 T.Oide
    '更新日：2018/10/16 (Tue) 16:12:52
    '備　考：
    Private Sub vsfATrayList_ChangeEdit(ByVal sender As Object, ByVal e As EventArgs) Handles vsfATrayList.ChangeEdit

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfATrayList.Rows.Count <= vsfATrayList.Rows.Fixed Then
                Return
            End If
            
            '@ｶﾗﾑにより分岐
            Select Case vsfATrayList.Col
            
                '@Aﾄﾚｰ区分、ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                Case CMlngvsfATrayClassCol, CMlngvsfATrayTapeStickGrCol
                    '@[RIGHT]ｷｰ押下
                    SendKeys.SendWait(CPstrSendKeysRight)
                    
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfATrayList_ChangeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfATrayList_Click
    '機　能：Aﾄﾚｰ一覧編集
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:23:38 T.Oide
    '更新日：2018/09/18 (Tue) 15:23:38
    '備　考：
    '@Private Sub vsfATrayList_Click()
    '@
    '@    Dim llngRowCnt              As Long
    '@    Dim llngCnt                 As Long
    '@    Dim lblnRet                 As Boolean
    '@    Dim lstrCategoryNm          As String
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    With vsfATrayList
    '@
    '@        '@ﾀｲﾄﾙ行でなければ処理実行
    '@        If .Row <> CMlngTitleRow Then
    '@
    '@            '@ﾓｼﾞｭｰﾙ変数退避
    '@            mstrTapeStickGr = .Cell(flexcpText, .Row, CMlngvsfATrayTapeStickGrCol)
    '@            mstrAtrayClass = .Cell(flexcpText, .Row, CMlngvsfATrayClassCol)
    '@            mstrUseLimit = .Cell(flexcpText, .Row, CMlngvsfATrayUseLimitCol)
    '@            mstrWashUseLimit = .Cell(flexcpText, .Row, CMlngvsfATrayWashUseLimitCol)
    '@
    '@            '@選択ｶﾗﾑによって処理分岐
    '@            Select Case .Col
    '@
    '@                '@洗浄列の場合
    '@                Case CMlngvsfATrayWashCol
    '@
    '@                    '@洗浄のﾁｪｯｸ--------------------
    '@                    '@ｽﾃｰﾀｽは｢使用可能｣または「使用不可」で
    '@                    ' 累積使用回数 < 累積上限回数　で
    '@                    ' 洗浄後使用回数 <= 洗浄後上限回数か
    '@                    If (.Cell(flexcpText, .Row, CMlngvsfATrayStatusCol) = CMstrStatusReadyName Or _
    '@                        .Cell(flexcpText, .Row, CMlngvsfATrayStatusCol) = CMstrStatusProhibitName) And _
    '@                        CLng(.Cell(flexcpText, .Row, CMlngvsfATrayUseNumCol)) < CLng((.Cell(flexcpText, .Row, CMlngvsfATrayUseLimitCol)) And _
    '@                        CLng(.Cell(flexcpText, .Row, CMlngvsfATrayWashUseNumCol)) <= CLng(.Cell(flexcpText, .Row, CMlngvsfATrayWashUseLimitCol))) Then
    '@
    '@                        '@チェックはOFFか
    '@                        If .Cell(flexcpChecked, .Row, CMlngvsfATrayWashCol) = flexUnchecked Then
    '@                            '@ﾁｪｯｸOFFの場合--------------------
    '@
    '@                            '@洗浄完了フラグ = Falseで､編集フラグ = False、新規ﾌﾗｸﾞ = Flaseか
    '@                            If mblnWashCompFlag = False And mblnAtrayDataEditFlag = False And mblnAtrayNewDataFlag = False Then
    '@
    '@                                '@ﾁｪｯｸをONにする
    '@                                .Cell(flexcpChecked, .Row, CMlngvsfATrayWashCol) = flexChecked
    '@                                '@編集ﾌﾗｸﾞ(洗浄)をｾｯﾄ
    '@                                mblnWashFlag = True
    '@                            Else
    '@
    '@                                'いずれかのﾌﾗｸﾞがTrueの場合はﾁｪｯｸはOFFのまま
    '@                                '@ﾁｪｯｸをOFFにする
    '@                                .Cell(flexcpChecked, .Row, CMlngvsfATrayWashCol) = flexUnchecked
    '@
    '@                            End If
    '@
    '@                        Else
    '@                            '@ﾁｪｯｸONの場合--------------------
    '@                            If mblnWashCompFlag = False And mblnAtrayDataEditFlag = False And mblnAtrayNewDataFlag = False Then
    '@
    '@                                '@ﾁｪｯｸをOFFにする
    '@                                .Cell(flexcpChecked, .Row, CMlngvsfATrayWashCol) = flexUnchecked
    '@                                '@編集ﾌﾗｸﾞ(洗浄)をﾘｾｯﾄするか判定
    '@                                Call prvWashFlagChk(1)
    '@
    '@                            'Else
    '@
    '@                                'いずれかのﾌﾗｸﾞがTrueの場合→ありえないはず
    '@                                '(ﾌﾗｸﾞがTrueのときﾁｪｯｸはONにならない)
    '@
    '@                            End If
    '@
    '@                        End If
    '@                    End If
    '@
    '@                    '@洗浄完了のﾁｪｯｸ--------------------
    '@                    '@ｽﾃｰﾀｽは｢洗浄中｣か
    '@                    If .Cell(flexcpText, .Row, CMlngvsfATrayStatusCol) = CMstrStatusWashName Then
    '@
    '@                        '@ﾁｪｯｸはOFFか
    '@                        If .Cell(flexcpChecked, .Row, CMlngvsfATrayWashCol) = flexUnchecked Then
    '@                            '@ﾁｪｯｸOFFの場合--------------------
    '@
    '@                            '@洗浄フラグ = Falseで､編集ﾌﾗｸﾞ = False、新規ﾌﾗｸﾞOffか
    '@                            If mblnWashFlag = False And mblnAtrayDataEditFlag = False And mblnAtrayNewDataFlag = False Then
    '@
    '@                                '@ﾁｪｯｸをONにする
    '@                                .Cell(flexcpChecked, .Row, CMlngvsfATrayWashCol) = flexChecked
    '@                                '@編集ﾌﾗｸﾞ(洗浄中)をｾｯﾄ
    '@                                mblnWashCompFlag = True
    '@                            Else
    '@
    '@                                'いずれかのﾌﾗｸﾞがTrueの場合はﾁｪｯｸはOFFのまま
    '@                                '@ﾁｪｯｸをOFFにする
    '@                                .Cell(flexcpChecked, .Row, CMlngvsfATrayWashCol) = flexUnchecked
    '@                            End If
    '@
    '@                        Else
    '@                            '@ﾁｪｯｸONの場合--------------------
    '@                            If mblnWashFlag = False And mblnAtrayDataEditFlag = False And mblnAtrayNewDataFlag = False Then
    '@
    '@                                '@ﾁｪｯｸをOFFにする
    '@                                .Cell(flexcpChecked, .Row, CMlngvsfATrayWashCol) = flexUnchecked
    '@                                '@編集ﾌﾗｸﾞ(洗浄)をﾘｾｯﾄするか判定
    '@                                Call prvWashFlagChk(2)
    '@
    '@                            'Else
    '@
    '@                                'いずれかのﾌﾗｸﾞがTrueの場合→ありえないはず
    '@                                '(ﾌﾗｸﾞがTrueのときﾁｪｯｸはONにならない)
    '@
    '@                            End If
    '@                        End If
    '@                    End If
    '@
    '@                '@AﾄﾚｰIDの場合
    '@                Case CMlngvsfATrayAtrayIdCol
    '@
    '@                    '@新規か
    '@                    If .Cell(flexcpText, .Row, CMlngvsfATrayEditCol) = CMstrNew Then
    '@
    '@                        '@ｾﾙを編集状態にする
    '@                        .EditCell
    '@
    '@                    Else
    '@
    '@                        '@編集不可
    '@                        .Editable = flexEDNone
    '@
    '@                    End If
    '@
    '@                '@Aﾄﾚｰ区分、ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ、洗浄後使用回数上限、使用回数上限列の場合
    '@                Case CMlngvsfATrayClassCol, CMlngvsfATrayTapeStickGrCol, _
    '@                     CMlngvsfATrayWashUseLimitCol, CMlngvsfATrayUseLimitCol
    '@
    '@                    '@状態は｢使用可能｣か
    '@                    If .Cell(flexcpText, .Row, CMlngvsfATrayStatusCol) = CMstrStatusReadyName Then
    '@
    '@                        '@編集ﾌﾗｸﾞ(洗浄)と編集ﾌﾗｸﾞ(洗浄完)がFalseか
    '@                        If mblnWashFlag = False And mblnWashCompFlag = False Then
    '@                            '@ｾﾙを編集状態にする
    '@                            .EditCell
    '@                        End If
    '@
    '@                    Else
    '@
    '@                        '@編集不可
    '@                        .Editable = flexEDNone
    '@
    '@                    End If
    '@
    '@                '@上記以外
    '@                Case Else
    '@
    '@                    '@編集不可
    '@                    .Editable = flexEDNone
    '@
    '@            End Select
    '@
    '@        End If
    '@
    '@        '@ﾎﾞﾀﾝの有効/無効
    '@        Call prvCmdButtonEnable
    '@
    '@    End With
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "vsfATｒaｙList_Click()"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub


    '関数名：vsfATrayList_DblClick
    '機　能：Aﾄﾚｰ一覧編集
    '引　数：なし
    '戻り値：
    '作成日：2019/03/12 (Tue) 15:57:47 T.Oide
    '更新日：2019/03/12 (Tue) 15:57:47
    '備　考：
    Private Sub vsfATrayList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfATrayList.DoubleClick

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfATrayList.Rows.Count <= vsfATrayList.Rows.Fixed Then
                Return
            End If

            With vsfATrayList
            
                '@ﾀｲﾄﾙ行でなければ処理実行
                If .Row > CMlngTitleRow Then
                
                    '@ﾓｼﾞｭｰﾙ変数退避
                    mstrTapeStickGr = .GetData(.Row, CMlngvsfATrayTapeStickGrCol)
                    mstrAtrayClass = .GetData(.Row, CMlngvsfATrayClassCol)
                    mstrUseLimit = .GetData(.Row, CMlngvsfATrayUseLimitCol)
                    mstrWashUseLimit = .GetData(.Row, CMlngvsfATrayWashUseLimitCol)

                    '@選択ｶﾗﾑによって処理分岐
                    Select Case .Col
                        
                        '@洗浄列の場合
                        Case CMlngvsfATrayWashCol

                            '@洗浄のﾁｪｯｸ--------------------
                            '@ｽﾃｰﾀｽは｢使用可能｣または「使用不可」で
                            ' 累積使用回数 < 累積上限回数　で
                            ' 洗浄後使用回数 <= 洗浄後上限回数か
                            If (.GetData(.Row, CMlngvsfATrayStatusCol) = CMstrStatusReadyName Or _
                                .GetData(.Row, CMlngvsfATrayStatusCol) = CMstrStatusProhibitName) And _
                                CLng(.GetData(.Row, CMlngvsfATrayUseNumCol)) < CLng((.GetData(.Row, CMlngvsfATrayUseLimitCol)) And _
                                CLng(.GetData(.Row, CMlngvsfATrayWashUseNumCol)) <= CLng(.GetData(.Row, CMlngvsfATrayWashUseLimitCol))) Then

                                '@チェックはOFFか
                                If .GetCellCheck(.Row, CMlngvsfATrayWashCol) = CheckEnum.Unchecked Then
                                    '@ﾁｪｯｸOFFの場合--------------------

                                    '@洗浄完了フラグ = Falseで､編集フラグ = False、新規ﾌﾗｸﾞ = Flaseか
                                    If mblnWashCompFlag = False And mblnAtrayDataEditFlag = False And mblnAtrayNewDataFlag = False Then

                                        '@ﾁｪｯｸをONにする
                                        .SetCellCheck(.Row, CMlngvsfATrayWashCol, CheckEnum.Checked)
                                        '@編集ﾌﾗｸﾞ(洗浄)をｾｯﾄ
                                        mblnWashFlag = True
                                    Else

                                        'いずれかのﾌﾗｸﾞがTrueの場合はﾁｪｯｸはOFFのまま
                                        '@ﾁｪｯｸをOFFにする
                                        .SetCellCheck(.Row, CMlngvsfATrayWashCol, CheckEnum.Unchecked)

                                    End If

                                Else
                                    '@ﾁｪｯｸONの場合--------------------
                                    If mblnWashCompFlag = False And mblnAtrayDataEditFlag = False And mblnAtrayNewDataFlag = False Then

                                        '@ﾁｪｯｸをOFFにする
                                        .SetCellCheck(.Row, CMlngvsfATrayWashCol, CheckEnum.Unchecked)
                                        '@編集ﾌﾗｸﾞ(洗浄)をﾘｾｯﾄするか判定
                                        Call prvWashFlagChk(1)

                                    'Else

                                        'いずれかのﾌﾗｸﾞがTrueの場合→ありえないはず
                                        '(ﾌﾗｸﾞがTrueのときﾁｪｯｸはONにならない)

                                    End If

                                End If
                            End If

                            '@洗浄完了のﾁｪｯｸ--------------------
                            '@ｽﾃｰﾀｽは｢洗浄中｣か
                            If .GetData(.Row, CMlngvsfATrayStatusCol) = CMstrStatusWashName Then

                                '@ﾁｪｯｸはOFFか
                                If .GetCellCheck(.Row, CMlngvsfATrayWashCol) = CheckEnum.Unchecked Then
                                    '@ﾁｪｯｸOFFの場合--------------------

                                    '@洗浄フラグ = Falseで､編集ﾌﾗｸﾞ = False、新規ﾌﾗｸﾞOffか
                                    If mblnWashFlag = False And mblnAtrayDataEditFlag = False And mblnAtrayNewDataFlag = False Then

                                        '@ﾁｪｯｸをONにする
                                        .SetCellCheck(.Row, CMlngvsfATrayWashCol, CheckEnum.Checked)
                                        '@編集ﾌﾗｸﾞ(洗浄中)をｾｯﾄ
                                        mblnWashCompFlag = True
                                    Else

                                        'いずれかのﾌﾗｸﾞがTrueの場合はﾁｪｯｸはOFFのまま
                                        '@ﾁｪｯｸをOFFにする
                                        .SetCellCheck(.Row, CMlngvsfATrayWashCol, CheckEnum.Unchecked)
                                    End If

                                Else
                                    '@ﾁｪｯｸONの場合--------------------
                                    If mblnWashFlag = False And mblnAtrayDataEditFlag = False And mblnAtrayNewDataFlag = False Then

                                        '@ﾁｪｯｸをOFFにする
                                        .SetCellCheck(.Row, CMlngvsfATrayWashCol, CheckEnum.Unchecked)
                                        '@編集ﾌﾗｸﾞ(洗浄)をﾘｾｯﾄするか判定
                                        Call prvWashFlagChk(2)

                                    'Else

                                        'いずれかのﾌﾗｸﾞがTrueの場合→ありえないはず
                                        '(ﾌﾗｸﾞがTrueのときﾁｪｯｸはONにならない)

                                    End If
                                End If
                            End If

                        '@AﾄﾚｰIDの場合
                        Case CMlngvsfATrayAtrayIdCol

                            '@新規か
                            If .GetData(.Row, CMlngvsfATrayEditCol) = CMstrNew Then

                                '@ｾﾙを編集状態にする
                                If .GetCellStyle(.Row,.Col) Is Nothing Then
                                    .Styles.Editor.BackColor = SystemColors.Window
                                Else
                                    .Styles.Editor.BackColor = .GetCellStyle(.Row,.Col).BackColor
                                End If
                                .StartEditing()
                                
                            Else

                                '@編集不可
                                .AllowEditing = False

                            End If

                        '@Aﾄﾚｰ区分、ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ、洗浄後使用回数上限、使用回数上限列の場合
                        Case CMlngvsfATrayClassCol, CMlngvsfATrayTapeStickGrCol, _
                             CMlngvsfATrayWashUseLimitCol, CMlngvsfATrayUseLimitCol

                            '@状態は｢使用可能｣か
                            If .GetData(.Row, CMlngvsfATrayStatusCol) = CMstrStatusReadyName Then

                                '@編集ﾌﾗｸﾞ(洗浄)と編集ﾌﾗｸﾞ(洗浄完)がFalseか
                                If mblnWashFlag = False And mblnWashCompFlag = False Then
                                    '@ｾﾙを編集状態にする
                                    If .GetCellStyle(.Row,.Col) Is Nothing Then
                                        .Styles.Editor.BackColor = SystemColors.Window
                                    Else
                                        .Styles.Editor.BackColor = .GetCellStyle(.Row,.Col).BackColor
                                    End If
                                    .StartEditing()
                                End If

                            Else

                                '@編集不可
                                .AllowEditing = False

                            End If

                        '@上記以外
                        Case Else

                            '@編集不可
                            .AllowEditing = False

                    End Select
                    
                End If
                
                '@ﾎﾞﾀﾝの有効/無効
                Call prvCmdButtonEnable()
                        
            End With

            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfATｒaｙList_Click()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：vsfATrayList_ComboCloseUp
    '機　能：ｷｬﾘｱｶﾃｺﾞﾘ選択時処理
    '引　数：Row:行 Col:列
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:24:12 T.Oide
    '更新日：2018/09/18 (Tue) 15:24:12
    '備　考：
    Private Sub vsfATrayList_ComboCloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles vsfATrayList.ComboCloseUp
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfATrayList.Rows.Count <= vsfATrayList.Rows.Fixed Then
                Return
            End If
            
            With vsfATrayList
            
                '@Aﾄﾚｰﾘｽﾄ変更後処理
                Call vsfATrayList_ValidateEdit(vsfATrayList, New EventArgs)
            
            End With
                
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfATｒaｙList_ComboCloseUp()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub



    '関数名：vsfATrayList_KeyDown
    '機　能：ｶﾃｺﾞﾘとｽｸﾘｰﾝｻｲｽﾞ退避(治具ﾃﾞｰﾀ変更ﾎﾞﾀﾝの有効制御用)
    '引　数：KeyCode：
    '　　　：Shift：
    '戻り値：
    '作成日：2018/09/18 (Tue) 15:24:28 T.Oide
    '更新日：2018/09/18 (Tue) 15:24:28
    '備　考：
    Private Sub vsfATrayList_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfATrayList.KeyDown

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfATrayList.Rows.Count <= vsfATrayList.Rows.Fixed Then
                Return
            End If

            With vsfATrayList
            
                '@ﾃﾞｰﾀ行の場合
                If .Rows.Fixed <= .Row Then
                
                   '@ﾓｼﾞｭｰﾙ変数に退避
                    mstrTapeStickGr = .GetData(.Row, CMlngvsfATrayTapeStickGrCol)
                    mstrAtrayClass = .GetData(.Row, CMlngvsfATrayClassCol)
                    mstrUseLimit = .GetData(.Row, CMlngvsfATrayUseLimitCol)
                    mstrWashUseLimit = .GetData(.Row, CMlngvsfATrayWashUseLimitCol)

                End If
                
        '@↓2019/03/15 (Fri) 16:39:29 T.Oide **************************************************
        '@        '@新規または変更の場合
        '@        If .Cell(flexcpBackColor, .Row, CMlngvsfATrayEditCol) = CMstrNew Or _
        '@           .Cell(flexcpBackColor, .Row, CMlngvsfATrayEditCol) = CMstrEdit Then
        '@
        '@            '新規か変更で分岐して､さらにカラムで分岐する
        '@
        '@            '@ｷｰｺｰﾄﾞで分岐
        '@            Select Case KeyCode
        '@                Case vbKeySpace     'ｽﾍﾟｰｽは無効
        '@                    KeyCode = 0
        '@
        '@                Case vbKeyDelete, vbKeyBack     'Delete/BackSpaceｷｰの場合
        '@                    '@Nullにする
        '@                    .Cell(flexcpText, .Row, .Col) = vbNullString
        '@                    .EditCell       '編集ﾓｰﾄﾞ
        '@
        '@                Case Else
        '@                    .EditCell       '編集ﾓｰﾄﾞ
        '@            End Select
        '@        End If
        '@
        '@-------------------------------------------------------------------------------------
                
                '@新規または変更の場合
                If .GetData(.Row, CMlngvsfATrayEditCol) = CMstrNew Or _
                   .GetData(.Row, CMlngvsfATrayEditCol) = CMstrEdit Then

                    '@編集可能列か
                    ' 「ﾄﾚｰ区分」「ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ」「洗浄後使用回数上限」「累積使用回数上限」
                    If .Col = CMlngvsfATrayClassCol Or _
                       .Col = CMlngvsfATrayTapeStickGrCol Or _
                       .Col = CMlngvsfATrayWashUseLimitCol Or _
                       .Col = CMlngvsfATrayUseLimitCol Then
                        
                        '新規か変更で分岐して､さらにカラムで分岐する
                    
                        '@ｷｰｺｰﾄﾞで分岐
                        Select Case e.KeyCode
                            Case Keys.Space     'ｽﾍﾟｰｽは無効 
                                e.Handled = True
                            
                            Case Keys.Delete, Keys.Back     'Delete/BackSpaceｷｰの場合
                                '@Nullにする
                                .SetData(.Row, .Col, vbNullString)
                                If .GetCellStyle(.Row,.Col) Is Nothing Then
                                    .Styles.Editor.BackColor = SystemColors.Window
                                Else
                                    .Styles.Editor.BackColor = .GetCellStyle(.Row,.Col).BackColor
                                End If
                                .StartEditing()       '編集ﾓｰﾄﾞ
                            
                            Case Keys.F2            'NSYS F2キー無効
                                e.SuppressKeyPress = True   

                                If .GetCellStyle(.Row,.Col) Is Nothing Then
                                    .Styles.Editor.BackColor = SystemColors.Window
                                Else
                                    .Styles.Editor.BackColor = .GetCellStyle(.Row,.Col).BackColor
                                End If
                                .StartEditing()       '編集ﾓｰﾄﾞ

                            Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.PageUp, Keys.PageDown  'NSYS 編集モードにしない


                            Case Else
                                If .GetCellStyle(.Row,.Col) Is Nothing Then
                                    .Styles.Editor.BackColor = SystemColors.Window
                                Else
                                    .Styles.Editor.BackColor = .GetCellStyle(.Row,.Col).BackColor
                                End If
                                .StartEditing()       '編集ﾓｰﾄﾞ
                        End Select
                        
                    End If
                End If
                
                
        '@↑2019/03/15 (Fri) 16:39:29 T.Oide **************************************************
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfATｒaｙList_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfATrayList_ValidateEdit
    '機　能：ｸﾞﾘｯﾄﾞ幅調整
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:24:58 T.Oide
    '更新日：2018/09/18 (Tue) 15:24:58
    '備　考：
    Private Sub vsfATrayList_ValidateEdit(ByVal sender As Object, ByVal e As EventArgs) Handles vsfATrayList.ValidateEdit

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfATrayList.Rows.Count <= vsfATrayList.Rows.Fixed Then
                Return
            End If
            
            With vsfATrayList
               
                '@あらかじめ幅調整されているか
                If Not mtypChgSort.blnChgWidth Then
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCol(.Col, 6)
                End If
                    
            End With
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfATｒaｙList_ValidateEdit()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfATrayList_EnterCell
    '機　能：Aﾄﾚｰ一覧編集
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:25:51 T.Oide
    '更新日：2018/09/18 (Tue) 15:25:51
    '備　考：
    Private Sub vsfATrayList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfATrayList.EnterCell
        
        Try

            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞが立ている場合処理中止
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
            
            With vsfATrayList
            
                'NSYS 選択行がない場合は処理を抜ける
                If vsfATrayList.Row >= vsfATrayList.Rows.Fixed Then
            
                    '@ﾀｲﾄﾙ行のみでは無いか
                    If .Rows.Count <> (CMlngTitleRow + 1) Then
                
                        '@ｸﾞﾘｯﾄﾞのｺﾒﾝﾄをTXTに反映
                        txtComments.Text = .GetData(.Row, CMlngvsfATrayCommentHCol)
                
                    End If
            
                End If
            End With
            
            '@ボタン有効/無効
            Call prvCmdButtonEnable()

            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfATｒaｙList_EnterCell()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：cmdLineAdd_Click
    '機　能：新規行を追加する
    '引　数：なし
    '戻り値：
    '作成日：2018/10/09 (Tue) 18:23:13 T.Oide
    '更新日：2018/10/09 (Tue) 18:23:13
    '備　考：
    Private Sub cmdLineAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLineAdd.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@洗浄ﾌﾗｸﾞ、洗浄完了ﾌﾗｸﾞ、更新ﾌﾗｸﾞはOnか
            If mblnWashFlag = True Or _
               mblnWashCompFlag = True Or _
               mblnAtrayDataEditFlag = True Then
                
                '@"<TRM156W>$$ 編集中のデータを確定してから[%1]を行ってください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0156, cmdLineAdd.Text)
                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                Exit Sub
                
            End If
            
            '@新規行追加
            Call prvAddRow(CMstrLineNew)
                
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLineAdd_Click()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLineCopy_Click
    '機　能：選択した行をｺﾋﾟｰして行を追加する
    '引　数：なし
    '戻り値：
    '作成日：2018/10/09 (Tue) 18:23:17 T.Oide
    '更新日：2018/10/09 (Tue) 18:23:17
    '備　考：
    Private Sub cmdLineCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLineCopy.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@洗浄ﾌﾗｸﾞ、洗浄完了ﾌﾗｸﾞ、更新ﾌﾗｸﾞはOnか
            If mblnWashFlag = True Or _
               mblnWashCompFlag = True Or _
               mblnAtrayDataEditFlag = True Then
                
                '@"<TRM156W>$$ 編集中のデータを確定してから[%1]を行ってください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0156, cmdLineCopy.Text)
                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                Exit Sub
                
            End If
            
            '@ｺﾋﾟｰして新規行追加
            Call prvAddRow(CMstrLineCopy)
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLineCopy_Click()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLineDel_Click
    '機　能：登録前の行を削除する
    '引　数：なし
    '戻り値：
    '作成日：2018/10/09 (Tue) 18:23:21 T.Oide
    '更新日：2018/10/09 (Tue) 18:23:21
    '備　考：
    Private Sub cmdLineDel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLineDel.Click

        Dim llngCnt         As Integer
        Dim lblnFind        As Boolean

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfATrayList
            
                '@新規行か
                If .GetData(.Row, CMlngvsfATrayEditCol) = CMstrNew Then
                   
                    '@行削除
                    .Redraw = False
                    .RemoveItem(.Row)
                    .Redraw = True 
                    
                End If
                
                '@新規ﾌﾗｸﾞOff判定
                '@ｸﾞﾘｯﾄﾞを回して「新」があるか
                lblnFind = False
                For llngCnt = 1 To .Rows.Count - 1
                
                    '@更新列は「新」か
                    If .GetData(llngCnt, CMlngvsfATrayEditCol) = CMstrNew Then
                        lblnFind = True
                        Exit For
                    End If
                Next
                
                '@「新」はなかったか
                If lblnFind = False Then
                    '@新規ﾌﾗｸﾞOff
                    mblnAtrayNewDataFlag = False
                End If
                
            End With

            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLineDel_Click()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClipCopy_Click
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
    '引　数：なし
    '戻り値：
    '作成日：2017/08/02 (Wed) 15:55:17 T.Oide
    '更新日：2017/08/02 (Wed) 15:55:17
    '備　考：
    Private Sub cmdClipCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClipCopy.Click

        Dim llngRowCnt      As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngColCnt      As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrRET         As String       'ｺﾋﾟｰ文字列
        Dim lstrWk          As String       '文字列編集
        Dim lstrTmp         As String       '一時文字列
        
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
            With vsfATrayList
                  
                '@行
                For llngRowCnt = 0 To .Rows.Count - 1
                    '@列
                    For llngColCnt = 0 To .Cols.Count - 1
                            
                        '@初期化
                        lstrTmp = vbNullString
                            
                        '@列により分岐
                        Select Case llngColCnt
                                
                            '@洗浄の場合
                            Case CMlngvsfATrayWashCol
                                    
                                '@ﾍｯﾀﾞｰ列以外か
                                If llngRowCnt > CMlngTitleRow Then
                                
                                    '@ﾁｪｯｸONか
                                    If .GetCellCheck(llngRowCnt, llngColCnt) = CheckEnum.Checked Then
                                        lstrTmp = CMstrCmbCheckOn
                                    Else
                                        lstrTmp = CMstrCmbCheckOff
                                    End If
                                        
                                Else
                                    lstrTmp = .GetDataDisplay(llngRowCnt, llngColCnt)
                                End If
                                
                            '@ｽﾃｰﾀｽ、Aﾄﾚｰ区分の場合
                            Case CMlngvsfATrayStatusCol, CMlngvsfATrayClassCol
                                '@名称で取得
                                lstrTmp = .GetDataDisplay(llngRowCnt, llngColCnt)
                                    
                            '@以外
                            Case Else
                                lstrTmp = .GetDataDisplay(llngRowCnt, llngColCnt)
                                
                        End Select
                            
                        '@文字列編集変数に値をｾｯﾄ
                        lstrWk = Replace(lstrTmp, vbCrLf, "")
                            
                        '@最終列の場合Tabいらない
                        If llngColCnt = .Cols.Count - 1 Then
                            '@ｺﾋﾟｰ文字列作成
                            lstrRET = lstrRET & lstrWk
                        Else
                            '@ｺﾋﾟｰ文字列作成
                            lstrRET = lstrRET & lstrWk & vbTab
                        End If
            
                    Next llngColCnt
                        
                    '@ｺﾋﾟｰ文字列作成
                    lstrRET = lstrRET & vbCrLf
                        
                Next llngRowCnt
                    
            End With
            
            '@Clipboard にﾃｷｽﾄ文字列を挿入
            Clipboard.SetText(lstrRET)
            
            '@"メッセージコード：C_I41%0$$クリップボードにコピーしました。
            '@(Excel等に Ctrl＋Vキー で貼り付けてください)")
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0041)
            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
            
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClipCopy_Click()"
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

    '関数名：prvvsfATrayList_Init
    '機　能：ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:28:11 T.Oide
    '更新日：2019/03/20 (Wed) 12:14:01 T.Oide
    '備　考：
    Private Sub prvvsfATrayList_Init()

        Dim llngCnt             As Integer
        Dim lstrTapeStickGrList As String

        Try
            
            '@ｸﾞﾘｯﾄﾞ初期化
            With vsfATrayList
            
                mblnEventCancelFlag = True

                .Clear(ClearFlags.Content)
                .Rows.Count = .Rows.Fixed
                .Cols.Count = CMlngvsfATrayColCnt
                .Cols.Frozen = CMlngvsfATrayACarrieCol

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngTitleRow, CMlngvsfATrayNoCol, CMlngvsfATrayNoColT)                      '№
                .SetData(CMlngTitleRow, CMlngvsfATrayEditCol, CMlngvsfATrayEditColT)                  '変更
                .SetData(CMlngTitleRow, CMlngvsfATrayWashCol, CMlngvsfATrayWashColT)                  '洗浄
                .SetData(CMlngTitleRow, CMlngvsfATrayAtrayIdCol, CMlngvsfATrayAtrayIdColT)            'AトレーID
                .SetData(CMlngTitleRow, CMlngvsfATrayStatusCol, CMlngvsfATrayStatusColT)              'ｽﾃｰﾀｽ
                .SetData(CMlngTitleRow, CMlngvsfATrayClassCol, CMlngvsfATrayClassColT)                'Aトレー区分
                .SetData(CMlngTitleRow, CMlngvsfATrayTapeStickGrCol, CMlngvsfATrayTapeStickGrColT)    'テープ貼りグループ
                .SetData(CMlngTitleRow, CMlngvsfATrayACarrieCol, CMlngvsfATrayACarrieColT)            'Aキャリア
                .SetData(CMlngTitleRow, CMlngvsfATrayCommentCol, CMlngvsfATrayCommentColT)            'コメント
                .SetData(CMlngTitleRow, CMlngvsfATrayCommentHCol, CMlngvsfATrayCommentColHT)          'コメント本文
                .SetData(CMlngTitleRow, CMlngvsfATrayWashUseNumCol, CMlngvsfATrayWashUseNumColT)      '洗浄後使用回数
                .SetData(CMlngTitleRow, CMlngvsfATrayWashUseLimitCol, CMlngvsfATrayWashUseLimitColT)  '洗浄後使用回数上限
                .SetData(CMlngTitleRow, CMlngvsfATrayUseNumCol, CMlngvsfATrayUseNumColT)              '累積使用回数
                .SetData(CMlngTitleRow, CMlngvsfATrayUseLimitCol, CMlngvsfATrayUseLimitColT)          '累積使用回数上限
                .SetData(CMlngTitleRow, CMlngvsfATrayStartTimeCol, CMlngvsfATrayStartTimeColT)        '使用開始日時
                .SetData(CMlngTitleRow, CMlngvsfATrayCleanTimeCol, CMlngvsfATrayCleanTimeColT)        '最終洗浄日時
                .SetData(CMlngTitleRow, CMlngvsfATrayEmpNameCol, CMlngvsfATrayEmpNameColT)            '最終更新者
                .SetData(CMlngTitleRow, CMlngvsfATrayEditTimeCol, CMlngvsfATrayEditTimeColT)          '更新日時
                .Rows(0).Height = 33

                '@隠しｶﾗﾑ設定
                .Cols(CMlngvsfATrayCommentHCol).Visible = False                                                     'コメント本文

                '@幅変更ﾌﾗｸﾞがFalseの場合、幅を設定
                If Not mtypChgSort.blnChgWidth Then
                    .Cols(CMlngvsfATrayNoCol).Width = CMlngvsfATrayNoColW                                         '№
                    .Cols(CMlngvsfATrayEditCol).Width = CMlngvsfATrayEditColW                                     '変更
                    .Cols(CMlngvsfATrayWashCol).Width = CMlngvsfATrayWashColW                                     '洗浄
                    .Cols(CMlngvsfATrayAtrayIdCol).Width = CMlngvsfATrayAtrayIdColW                               'AトレーID
                    .Cols(CMlngvsfATrayStatusCol).Width = CMlngvsfATrayStatusColW                                 'ステータス
                    .Cols(CMlngvsfATrayClassCol).Width = CMlngvsfATrayClassColW                                   'Aトレー区分
                    .Cols(CMlngvsfATrayTapeStickGrCol).Width = CMlngvsfATrayTapeStickGrColW                       'テープ貼りグループ
                    .Cols(CMlngvsfATrayACarrieCol).Width = CMlngvsfATrayACarrieColW                               'Aキャリア
                    .Cols(CMlngvsfATrayCommentCol).Width = CMlngvsfATrayCommentColW                               'コメント
                    .Cols(CMlngvsfATrayCommentHCol).Width = CMlngvsfATrayCommentColHW                             'コメント本文
                    .Cols(CMlngvsfATrayWashUseNumCol).Width = CMlngvsfATrayWashUseNumColW                         '洗浄後使用回数
                    .Cols(CMlngvsfATrayWashUseLimitCol).Width = CMlngvsfATrayWashUseLimitColW                     '洗浄後使用回数上限
                    .Cols(CMlngvsfATrayUseNumCol).Width = CMlngvsfATrayUseNumColW                                 '累積使用回数
                    .Cols(CMlngvsfATrayUseLimitCol).Width = CMlngvsfATrayUseLimitColW                             '累積使用回数上限
                    .Cols(CMlngvsfATrayStartTimeCol).Width = CMlngvsfATrayStartTimeColW                           '使用開始日時
                    .Cols(CMlngvsfATrayCleanTimeCol).Width = CMlngvsfATrayCleanTimeColW                           '最終洗浄日時
                    .Cols(CMlngvsfATrayEmpNameCol).Width = CMlngvsfATrayEmpNameColW                               '最終更新者
                    .Cols(CMlngvsfATrayEditTimeCol).Width = CMlngvsfATrayEditTimeColW                             '更新日時
                    
                End If
                
                'NSYS IDictionary化
                Dim lstrColComboList As New ListDictionary
                For Each pair As String In Split(CMstrStatusList, "|")
                    Dim m As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(pair, "#([^;]+);([^|]+)")
                    If m.Success Then
                        lstrColComboList.Add(m.Groups(1).Value, m.Groups(2).Value)
                    End If
                Next

                '@ｽﾃｰﾀｽｺﾝﾎﾞﾘｽﾄ設定
                vsfATrayList.Cols(CMlngvsfATrayStatusCol).DataMap = lstrColComboList
                
                'NSYS IDictionary化
                Dim lstrColComboList2 As New ListDictionary
                For Each pair As String In Split(CMstrAtrayClassList, "|")
                    Dim m As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(pair, "#([^;]+);([^|]+)")
                    If m.Success Then
                        lstrColComboList2.Add(m.Groups(1).Value, m.Groups(2).Value)
                    End If
                Next

                '@Aﾄﾚｰ区分のｺﾝﾎﾞﾘｽﾄ設定
                vsfATrayList.Cols(CMlngvsfATrayClassCol).DataMap = lstrColComboList2
                
                '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟｺﾝﾎﾞﾘｽﾄ作成
                '@取得数ぶん繰返し
                lstrTapeStickGrList = vbNullString
                For llngCnt = 0 To mtypTapeStickList.lngTapeStickGrCnt -1
                    '@ﾘｽﾄを作成
                    lstrTapeStickGrList = lstrTapeStickGrList & mtypTapeStickList.typTapeStickGr(llngCnt).strTapeStickGr & CPstrPipeString
                Next llngCnt
                vsfATrayList.Cols(CMlngvsfATrayTapeStickGrCol).ComboList = lstrTapeStickGrList

                
            End With
            
            '@画面および変数初期化
        '@↓2019/03/20 (Wed) 12:13:34 T.Oide **************************************************
        '@    txtComments.Text = vbNullString
        '@    txtComments.Enabled = False
        '@-------------------------------------------------------------------------------------
            '@ｺﾒﾝﾄ初期化
            Call txtComments_init()
        '@↑2019/03/20 (Wed) 12:13:34 T.Oide **************************************************
            lblGridCnt.Text = vbNullString
            lblNowDate.Text = vbNullString
            mstrComments = vbNullString
            mblnEventCancelFlag = False
            mblnWashFlag = False
            mblnWashCompFlag = False
            mblnAtrayDataEditFlag = False
            mblnAtrayNewDataFlag = False
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfATrayList_Init()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbAtrayClass_Set
    '機　能：ｺﾝﾎﾞﾎﾞｯｸｽ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:27:36 T.Oide
    '更新日：2018/09/18 (Tue) 15:27:36
    '備　考：
    Private Sub prvcmbAtrayClass_Set()

        Try
            
            '@Aトレー区分ｺﾝﾎﾞ設定
            With cmbAtrayClass

                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .Enabled = True                                                 '活性化
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mtypTapeStickList.lngTapeStickGrCnt                '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                            '"選択"文字列
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.GridFont.Style, .GridFont.Unit)    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ  
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .ValueCol = 1
                .BackColor = SystemColors.Window

                '@リスト追加(ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ/ﾘｽﾄIndex/NULL/NULL/ﾁｪｯｸBOXのﾃﾞﾌｫﾙﾄﾁｪｯｸ(1：ON))
                .AddItem(CPstrSpecUseProductName & vbTab & CPstrUseIDProduct & vbTab & vbNullString & vbTab & vbNullString & vbTab & CMstrCmbCheckOn)  '製品
                .AddItem(CPstrSpecUseMonitorName & vbTab & CPstrUseIDMonitor & vbTab & vbNullString & vbTab & vbNullString & vbTab & CMstrCmbCheckOn)  'ﾓﾆﾀｰ
                .AddItem(CPstrSpecUseDummyName & vbTab & CPstrUseIDDummy & vbTab & vbNullString & vbTab & vbNullString & vbTab & CMstrCmbCheckOn)      'ﾀﾞﾐｰ

                '@ﾃｷｽﾄ部分に情報をｾｯﾄ
                .AddedComment = CMstrCmbAddedComment        '" 項目選択"
                .Text = .ListCount & CMstrCmbAddedComment   '"N項目選択"(Nは選択数)
                
                '@種別ｺﾝﾎﾞを有効にする
                .Enabled = True
            
            End With

            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbAtrayClass_Set()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfATrayList_Disp
    '機　能：Aﾄﾚｰ情報一覧表示
    '引　数：typAtrayList   ：Aﾄﾚｰﾘｽﾄ
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:28:37 T.Oide
    '更新日：2018/09/18 (Tue) 15:28:37
    '備　考：
    Private Sub prvvsfATrayList_Disp(ByRef typAtrayList As typeAtrayList)

        Dim llngRowCnt                  As Integer          'ｶｳﾝﾀ
        Dim llngCnt                     As Integer          'ｶｳﾝﾀ(構造体)
        Dim llngSCnt                    As Integer          'ｶｳﾝﾀ(ｿｰﾄ)

        Try
            
            '@変数初期化
            mstrComments = vbNullString
            
            '再表示しない
            vsfATrayList.Redraw = False

            'ｸﾞﾘｯﾄﾞ初期化
            Call prvvsfATrayList_Init()
            
            '@ﾃﾞｰﾀなしの場合は終了
            If typAtrayList.lngAtraytListCnt = 0 Then
                '再表示開始
                vsfATrayList.Redraw = True
                Exit Sub
            End If
            
            'ｸﾞﾘｯﾄﾞの設定
            With vsfATrayList
                
                RemoveHandler vsfATrayList.BeforeRowColChange,AddressOf vsfATrayList_BeforeRowColChange

                .Row = 0

                '@行数設定
                .Rows.Count = typAtrayList.lngAtraytListCnt + 1
                
                '@Aﾄﾚｰﾘｽﾄ分繰り返し
                For llngRowCnt = 1 To typAtrayList.lngAtraytListCnt
                    
                    '@ｸﾞﾘｯﾄﾞの各々の値を設定
                    .SetData(llngRowCnt, CMlngvsfATrayNoCol, llngRowCnt)                                          '№
                    .SetData(llngRowCnt, CMlngvsfATrayEditCol, vbNullString)                                      '変更
                    .SetCellCheck(llngRowCnt, CMlngvsfATrayWashCol, CheckEnum.Unchecked)                          '洗浄ﾁｪｯｸ
                    .SetData(llngRowCnt, CMlngvsfATrayAtrayIdCol, typAtrayList.typAtraytList(llngCnt).strAtrayId) 'AﾄﾚｰID
                    
                    '@Aﾄﾚｰｽﾃｰﾀｽ
                    Select Case typAtrayList.typAtraytList(llngCnt).strAtrayStatus
                        Case CMstrStatusReady
                            .SetData(llngRowCnt, CMlngvsfATrayStatusCol, CMstrStatusReadyName)    '使用可能
                        Case CMstrStatusActive
                            .SetData(llngRowCnt, CMlngvsfATrayStatusCol, CMstrStatusActiveName)   '使用中
                        Case CMstrStatusProhibit
                            .SetData(llngRowCnt, CMlngvsfATrayStatusCol, CMstrStatusProhibitName) '使用不可
                        Case CMstrStatusWash
                            .SetData(llngRowCnt, CMlngvsfATrayStatusCol, CMstrStatusWashName)     '洗浄中
                        Case Else
                            .SetData(llngRowCnt, CMlngvsfATrayStatusCol, vbNullString)            'その他
                    End Select
                    
                    
                    .SetData(llngRowCnt, CMlngvsfATrayClassCol, typAtrayList.typAtraytList(llngCnt).strAtrayClass)        '@Aﾄﾚｰｸﾗｽ
                    .SetData(llngRowCnt, CMlngvsfATrayTapeStickGrCol, typAtrayList.typAtraytList(llngCnt).strTapeStickGr) 'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                    
                    '@AｷｬﾘｱIDは-か
                    If typAtrayList.typAtraytList(llngCnt).strACarrierId = "-" Then
                        .SetData(llngRowCnt, CMlngvsfATrayACarrieCol, vbNullString)
                    Else
                        .SetData(llngRowCnt, CMlngvsfATrayACarrieCol, typAtrayList.typAtraytList(llngCnt).strACarrierId)  'AｷｬﾘｱID
                    End If
                    
                    .SetData(llngRowCnt, CMlngvsfATrayCommentHCol, typAtrayList.typAtraytList(llngCnt).strComments)       'ｺﾒﾝﾄ(中身)
                    
                    '@ｺﾒﾝﾄはNULL以外か
                    If typAtrayList.typAtraytList(llngCnt).strComments <> vbNullString Then
                        .SetData(llngRowCnt, CMlngvsfATrayCommentCol, CPstrAriFlg)                                        'ｺﾒﾝﾄ(あり)
                    End If
                    
                    .SetData(llngRowCnt, CMlngvsfATrayWashUseNumCol, typAtrayList.typAtraytList(llngCnt).strWashUseNum)   '洗浄後使用回数
                    .SetData(llngRowCnt, CMlngvsfATrayWashUseLimitCol, typAtrayList.typAtraytList(llngCnt).strWashUseLimit)   '洗浄後上限回数
                    .SetData(llngRowCnt, CMlngvsfATrayUseNumCol, typAtrayList.typAtraytList(llngCnt).strUseNum)           '累積使用回数
                    .SetData(llngRowCnt, CMlngvsfATrayUseLimitCol, typAtrayList.typAtraytList(llngCnt).strUseLimit)       '累積上限回数
                    .SetData(llngRowCnt, CMlngvsfATrayStartTimeCol, typAtrayList.typAtraytList(llngCnt).strStartTime)     '使用開始日時
                    .SetData(llngRowCnt, CMlngvsfATrayCleanTimeCol, typAtrayList.typAtraytList(llngCnt).strCleanTime)     '最終洗浄日時
                    .SetData(llngRowCnt, CMlngvsfATrayEmpNameCol, typAtrayList.typAtraytList(llngCnt).strEmpName)         '最終更新者
                    .SetData(llngRowCnt, CMlngvsfATrayEditTimeCol, typAtrayList.typAtraytList(llngCnt).strEditTime)       '更新日時
                
                    llngCnt = llngCnt + 1

                Next
                
            End With
            
            If Not mtypChgSort.blnChgWidth Then
                vsfATrayList.AutoSizeCol(CMlngvsfATrayAtrayIdCol, 6)
            End If

            '@ｿｰﾄｶｳﾝﾄは0より大きいか
            If mtypChgSort.lngCnt > 0 Then
            
                For llngSCnt = 0 To mtypChgSort.lngCnt -1
                    vsfATrayList.Cols(mtypChgSort.typChgSortList(llngSCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngSCnt).lngOrder
                    vsfATrayList.Sort(SortFlags.UseColSort, mtypChgSort.typChgSortList(llngSCnt).lngCol)
                Next llngSCnt
                
            End If
            
            AddHandler vsfATrayList.BeforeRowColChange,AddressOf vsfATrayList_BeforeRowColChange

            '@ｿｰﾄｷｰはNULL以外か
            If mtypChgSort.strKey <> vbNullString Then
                For llngSCnt = vsfATrayList.Rows.Fixed To vsfATrayList.Rows.Count - 1
                    If vsfATrayList.GetData(llngSCnt, CMlngvsfATrayAtrayIdCol) = mtypChgSort.strKey Then
                        vsfATrayList.Row = llngSCnt
                        Call pubVsfBeforeSort(vsfATrayList, CMlngvsfATrayAtrayIdCol)
                        Call pubVsfAfterSort(vsfATrayList, CMlngvsfATrayAtrayIdCol,Nothing, Nothing, False, False, True, False)
                    Exit For
                    End If
                Next llngSCnt
            Else
                '@先頭ﾍﾟｰｼﾞ設定
                vsfATrayList.TopRow = CMlngGridTitleRow
                '@ﾀｲﾄﾙ行に設定
                vsfATrayList.Row = CMlngGridTitleRow
            End If
                                    
            '@ｸﾞﾘｯﾄﾞ表示後処理
            Call pubVsfDisp(vsfATrayList)
            
            '再表示開始
            vsfATrayList.Redraw = True
            
            '@ﾗﾍﾞﾙへのｾｯﾄ
            lblGridCnt.Text = typAtrayList.lngAtraytListCnt
            lblNowDate.Text = Format$(Now, CPstrDateFormat)
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfATｒaｙList_Disp()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvSetAtrayRegist
    '機　能：登録・更新内容を構造体に格納する
    '引　数：登録・更新情報 : ltypAtrayRegist
    '引　数：llngButton：0:洗浄、1：洗浄完了、2：確定
    '戻り値：なし
    '作成日：2018/09/18 (Tue) 15:29:11 T.Oide
    '更新日：2019/03/12 (Tue) 16:03:51 T.Oide
    '備　考：
    Private Sub prvSetAtrayRegist(ByRef ltypAtrayRegist As typAtrayRegist, _
                                  ByVal llngButton As Integer)
        
        Dim llngRowCnt              As Integer
        Dim lstrClassDiv            As String
        Dim lstrAtrayClass          As String

        Try
            
            With vsfATrayList
                
                '@処理を判定する
                '@ﾎﾞﾀﾝは「確定」か
                Select Case llngButton
                
                    '@「洗浄」の場合
                    Case CMlngWash
                        lstrClassDiv = CMstrAtrayRegClassDiv_Wash              '洗浄
                    '@「洗浄完了」の場合
                    Case CMlngWashComp
                        lstrClassDiv = CMstrAtrayRegClassDiv_WashComp          '洗浄完了
                    '@「登録」の場合
                    Case CMlngRegist
                    
                        '@ｸﾞﾘｯﾄﾞを回して「新規」か「更新」か判定する
                        For llngRowCnt = 1 To .Rows.Count - 1
                            
                            '@新規か
                            If .GetData(llngRowCnt, CMlngvsfATrayEditCol) = CMstrNew Then
                                lstrClassDiv = CMstrAtrayRegClassDiv_New      '新規登録
                                Exit For                '1回の登録で処理を混ぜないので見つかったらﾙｰﾌﾟ終了
                            End If
                            
                            '@更新か
                            If .GetData(llngRowCnt, CMlngvsfATrayEditCol) = CMstrEdit Then
                                lstrClassDiv = CMstrAtrayRegClassDiv_Edit      '更新
                                Exit For
                            End If
                        Next
                End Select
                
                ltypAtrayRegist.strEmpID = pstrUserID           'ﾕｰｻﾞID
                ltypAtrayRegist.strClassDiv = lstrClassDiv      '処理区分
                
                '@ｸﾞﾘｯﾄﾞの行数分ﾙｰﾌﾟして情報を構造体に格納していく
                For llngRowCnt = 1 To .Rows.Count - 1

                    '@新規か変更かﾁｪｯｸOnの行の情報を格納する
                    If .GetData(llngRowCnt, CMlngvsfATrayEditCol) <> vbNullString Or _
                       .GetCellCheck(llngRowCnt, CMlngvsfATrayWashCol) = CheckEnum.Checked Then
                        
                        '@配列の要素数定義
                        ltypAtrayRegist.lngAtraytListCnt = ltypAtrayRegist.lngAtraytListCnt + 1

                        If ltypAtrayRegist.typAtraytList Is Nothing Then
                            ltypAtrayRegist.typAtraytList = New List(Of typeAtray)
                        End If

                        Dim typAtraytListTmp As New typeAtray

                        '@配列へ変更内容を格納
                        typAtraytListTmp.strAtrayId = _
                                    .GetData(llngRowCnt, CMlngvsfATrayAtrayIdCol)                  'AﾄﾚｰID
                        
                        '@区分を名前からｺｰﾄﾞに変換
                        Select Case .GetDataDisplay(llngRowCnt, CMlngvsfATrayClassCol)

                            '@製品の場合
                            Case CPstrSpecUseProductName
                                lstrAtrayClass = CPstrUseIDProduct

                            '@ﾓﾆﾀｰの場合
                            Case CPstrSpecUseMonitorName
                                lstrAtrayClass = CPstrUseIDMonitor

                            '@ﾀﾞﾐｰの場合
                            Case CPstrSpecUseDummyName
                                lstrAtrayClass = CPstrUseIDDummy

                        End Select

                        typAtraytListTmp.strAtrayClass = lstrAtrayClass 'Aﾄﾚｰ区分


                        typAtraytListTmp.strTapeStickGr = _
                                    .GetData(llngRowCnt, CMlngvsfATrayTapeStickGrCol)              'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                                    
                        typAtraytListTmp.strWashUseLimit = _
                                    .GetData(llngRowCnt, CMlngvsfATrayWashUseLimitCol)             '洗浄後使用回数上限
                                    
                        typAtraytListTmp.strUseLimit = _
                                    .GetData(llngRowCnt, CMlngvsfATrayUseLimitCol)                 '累積使用回数上限

                        typAtraytListTmp.strComments = _
                                    .GetData(llngRowCnt, CMlngvsfATrayCommentHCol)                 'ｺﾒﾝﾄ
                    
                        ltypAtrayRegist.typAtraytList.Add(typAtraytListTmp)

                    End If
                    
                Next
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSetAtrayRegist()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：変更ﾃﾞｰﾀ収集
    '引　数：
    '戻り値：TRUE:成功 FALSE:失敗
    '作成日：2018/09/18 (Tue) 15:29:53 T.Oide
    '更新日：2018/09/18 (Tue) 15:29:53
    '備　考：
    Private Function prvblnInput_Chk(ByVal gridRow As Integer) As Boolean
        
        Try
            
            '@ﾁｪｯｸ結果を初期
            prvblnInput_Chk = False

            '@数値でなかったら異常
            With vsfATrayList
            
                '@対象ｾﾙは空以外か
                If .GetData(gridRow, .Col) <> vbNullString Then
                
                    '@ｶﾗﾑによって処理分岐
                    Select Case .Col
                    
                        '@洗浄後使用回数上限、累積使用回数上限の場合
                        Case CMlngvsfATrayWashUseLimitCol, CMlngvsfATrayUseLimitCol
                        
                            '@ｾﾙの値は数字以外、または、先頭が0ではないか
                            If (.GetData(gridRow, .Col) Like "*[!0-9]*")OrElse _
                                Strings.Left(.GetData(gridRow, .Col), 1) = 0 Then
                                
                                '@不正文字として検出
                                Exit Function
                                
                            End If
                            
                    End Select
                    
                End If
                
            End With
            
            '@ﾁｪｯｸOK
            prvblnInput_Chk = True
            
            Exit Function

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInput_Chk()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvWashFlagChk
    '機　能：編集ﾌﾗｸﾞ(洗浄)をﾘｾｯﾄするか判定
    '引　数：llngChkFlag(1:mblnWashFlag 2:mblnWashCompFlag)
    '戻り値：
    '作成日：2018/09/18 (Tue) 15:30:27 T.Oide
    '更新日：2018/09/18 (Tue) 15:30:27
    '備　考：
    Private Sub prvWashFlagChk(ByVal llngChkFlag As Integer)

        Dim llngRowCnt      As Integer
        Dim lblnChkFlag     As Boolean

        Try
            
            lblnChkFlag = False
            
            '@ｸﾞﾘｯﾄﾞ行分ﾙｰﾌﾟして1件でも洗浄のﾁｪｯｸがONなら｢治具洗浄｣ボタンを有効にする
            For llngRowCnt = 1 To vsfATrayList.Rows.Count - 1
            
                '@ﾁｪｯｸはONか
                If vsfATrayList.GetCellCheck(llngRowCnt, CMlngvsfATrayWashCol) = CheckEnum.Checked Then
                    
                    '@1つでもﾁｪｯｸがあればﾌﾗｸﾞを1にして終了
                    lblnChkFlag = True
                    Exit For
                        
                End If
            Next
            
            '@ﾁｪｯｸﾌﾗｸﾞはFalseのままか(1つもﾁｪｯｸがない)
            If lblnChkFlag = False Then
            
                '@どちらのﾌﾗｸﾞをﾘｾｯﾄするか引数で分ける
                Select Case llngChkFlag
                
                    Case 1
                        '@編集ﾌﾗｸﾞ(洗浄)をｾｯﾄ
                        mblnWashFlag = False
                
                    Case 2
                        '@編集ﾌﾗｸﾞ(洗浄完)をｾｯﾄ
                        mblnWashCompFlag = False
                
                End Select
            
            End If
            
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWashFlagChk()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChkEdit
    '機　能：編集中か確認して編集中ならメッセージ表示
    '引　数：なし
    '戻り値：True：編集中止OK(編集なし)、False：編集中止NG
    '作成日：2018/09/18 (Tue) 15:30:46 T.Oide
    '更新日：2018/09/18 (Tue) 15:30:46
    '備　考：
    Private Function prvChkEdit() As Boolean

        Dim llngAns     As Integer

        Try
            
            '@編集なし、又は、編集中止OK
            prvChkEdit = True

            '@編集中か
            If mblnWashFlag = True Or _
               mblnWashCompFlag = True Or _
               mblnAtrayDataEditFlag = True Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)

                '@"編集中です。 内容を破棄してよろしいですか？"
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                '@要求確認
                If llngAns = vbNo Then
                
                    '@編集中止NG
                    prvChkEdit = False
                    
                    '@装置ﾃﾞｰﾀﾘｽﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfATrayList)
                    
                    Exit Function
                End If
                
            End If
            
            Exit Function

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvChkEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvcmbTapStickGr_Disp
    '機　能：ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟｺﾝﾎﾞ設定
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/06 (Mon) 18:00:56 T.Oide
    '更新日：2019/03/06 (Wed) 13:38:42 T.Oide
    '備　考：
    Private Sub prvcmbTapStickGr_Disp()

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ

        Try

            With cmbTapeStickGr
            
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .Enabled = True                                                 '活性化
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = 1                                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mtypTapeStickList.lngTapeStickGrCnt                '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                            '"選択"文字列
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.GridFont.Style, .GridFont.Unit)    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .BackColor = SystemColors.Window

                '@取得数ぶん繰返し
                For llngCnt = 0 To mtypTapeStickList.lngTapeStickGrCnt -1

        '@↓2019/03/06 (Wed) 13:38:20 T.Oide **************************************************
        '@            '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟｺﾝﾎﾞ内容の設定(ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ/ﾘｽﾄIndex/NULL/NULL/ﾁｪｯｸBOXのﾃﾞﾌｫﾙﾄﾁｪｯｸ(1：ON))
        '@            .AddItem mtypTapeStickList.typTapeStickGr(llngCnt).strTapeStickGr & vbTab & _
        '@                     llngCnt & vbTab & _
        '@                     vbNullString & vbTab & _
        '@                     vbNullString & vbTab & _
        '@                     CMstrCmbCheckOn
        '@-------------------------------------------------------------------------------------
                             
                    '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟｺﾝﾎﾞ内容の設定(ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ/ﾘｽﾄIndex/NULL/NULL/ﾁｪｯｸBOXのﾃﾞﾌｫﾙﾄﾁｪｯｸ(1：ON))
                    .AddItem(mtypTapeStickList.typTapeStickGr(llngCnt).strTapeStickGr & vbTab & _
                             llngCnt & vbTab & _
                             vbNullString & vbTab & _
                             vbNullString & vbTab & _
                             CMstrCmbCheckOff)
        '@↑2019/03/06 (Wed) 13:38:20 T.Oide **************************************************
                                      

                Next llngCnt

                '@ﾃｷｽﾄ部分に情報をｾｯﾄ
                .AddedComment = CMstrCmbAddedComment        '" 項目選択"
        '@↓2019/03/06 (Wed) 13:41:25 T.Oide **************************************************
        '@        .Text = .ListCount & CMstrCmbAddedComment   '"N項目選択"(Nは選択数)
                .Text = CPstrZero & CMstrCmbAddedComment   '"N項目選択"(Nは選択数)
        '@↑2019/03/06 (Wed) 13:41:25 T.Oide **************************************************
                
                
                
                '@種別ｺﾝﾎﾞを有効にする
                .Enabled = True
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbTapStickGr_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvAddRow
    '機　能：ｺﾋﾟｰして新規とVerUpの時ｸﾞﾘｯﾄﾞに行を追加する
    '引　数：strAddClass：Copy or New
    '戻り値：なし
    '作成日：2017/08/02 (Wed) 16:29:33 T.Oide
    '更新日：2017/08/02 (Wed) 16:29:33
    '備　考：
    Private Sub prvAddRow(ByVal strAddClass As String)

        Dim llngCopyRow             As Integer  'ｺﾋﾟｰ元ｲﾝﾃﾞｯｸｽ

        Try

            With vsfATrayList
            
                RemoveHandler vsfATrayList.BeforeEdit,AddressOf vsfATrayList_BeforeEdit
                RemoveHandler vsfATrayList.EnterCell,AddressOf vsfATrayList_EnterCell

                '@ｺﾋﾟｰ元ｲﾝﾃﾞｯｸｽの取得
                llngCopyRow = .Row
                
                If llngCopyRow < .Rows.Fixed Then
                    llngCopyRow = 0
                End If

                .Row = -1

                '@CopyかNewで分岐
                Select Case strAddClass
            
                    Case CMstrLineCopy
                        
                        '@行ｺﾋﾟｰ
                        .AddItem ( _
                            .Rows.Count - 1 & vbTab & _
                            CMstrNew & vbTab & _
                            0 & vbTab & _
                            .GetData(llngCopyRow, CMlngvsfATrayAtrayIdCol) & vbTab & _
                            CMstrStatusReadyName & vbTab & _
                            .GetData(llngCopyRow, CMlngvsfATrayClassCol) & vbTab & _
                            .GetData(llngCopyRow, CMlngvsfATrayTapeStickGrCol) & vbTab & _
                            vbNullString & vbTab & _
                            .GetData(llngCopyRow, CMlngvsfATrayCommentCol) & vbTab & _
                            .GetData(llngCopyRow, CMlngvsfATrayCommentHCol) & vbTab & _
                            0 & vbTab & _
                            .GetData(llngCopyRow, CMlngvsfATrayWashUseLimitCol) & vbTab & _
                            0 & vbTab & _
                            .GetData(llngCopyRow, CMlngvsfATrayUseLimitCol) & vbTab & _
                            vbNullString & vbTab & _
                            vbNullString & vbTab & _
                            vbNullString & vbTab & _
                            vbNullString)
                            
                    Case CMstrLineNew
                    
                        '@行追加
                        .AddItem ( _
                            .Rows.Count - 1 & vbTab & _
                            CMstrNew & vbTab & _
                            0 & vbTab & _
                            vbNullString & vbTab & _
                            CMstrStatusReadyName & vbTab & _
                            vbNullString & vbTab & _
                            vbNullString & vbTab & _
                            vbNullString & vbTab & _
                            vbNullString & vbTab & _
                            vbNullString & vbTab & _
                            0 & vbTab & _
                            vbNullString & vbTab & _
                            0 & vbTab & _
                            vbNullString & vbTab & _
                            vbNullString & vbTab & _
                            vbNullString & vbTab & _
                            vbNullString & vbTab & _
                            vbNullString)

                End Select
                    
                AddHandler vsfATrayList.BeforeEdit,AddressOf vsfATrayList_BeforeEdit
                AddHandler vsfATrayList.EnterCell,AddressOf vsfATrayList_EnterCell

                '@追加した行をを表示
                .Row = .Rows.Count - 1
                .Col = CMlngvsfATrayAtrayIdCol
                .ShowCell(.Row, .Col)
                If .GetCellStyle(.Row,.Col) Is Nothing Then
                    .Styles.Editor.BackColor = SystemColors.Window
                Else
                    .Styles.Editor.BackColor = .GetCellStyle(.Row,.Col).BackColor
                End If
                .StartEditing()

                '@ｺﾒﾝﾄ設定
                txtComments.Text = .GetData(.Row, CMlngvsfATrayCommentHCol)
                
            End With

            '@新規ﾌﾗｸﾞOn
            mblnAtrayNewDataFlag = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvAddRow"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmdButtonEnable
    '機　能：ボタンの有効/無効を制御
    '引　数：なし
    '戻り値：
    '作成日：2018/09/18 (Tue) 15:30:10 T.Oide
    '更新日：2018/09/18 (Tue) 15:30:10
    '備　考：
    Private Sub prvCmdButtonEnable()

        Try
            
            With vsfATrayList

                '@============
                '@ 閉じる
                '@============
                cmdClose.Enabled = True

                '@============
                '@洗浄
                '@============
                '@編集ﾌﾗｸﾞ(洗浄)はTrueか
                If mblnWashFlag = True Then
                    cmdRegist0.Enabled = True
                Else
                    cmdRegist0.Enabled = False
                End If
                
                '@============
                '@洗浄完了
                '@============
                '@編集ﾌﾗｸﾞ(洗浄完了)はTrueか
                If mblnWashCompFlag = True Then
                    cmdRegist1.Enabled = True
                Else
                    cmdRegist1.Enabled = False
                End If
                
                '@============
                '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
                '@============
                cmdClipCopy.Enabled = True
                
                
                '@============
                '@行追加
                ' 洗浄ﾌﾗｸﾞ、洗浄完了ﾌﾗｸﾞ、編集ﾌﾗｸﾞが共にFalseの場合有効
                '@============
                If mblnWashFlag = False And _
                   mblnWashCompFlag = False And _
                   mblnAtrayDataEditFlag = False Then
                    cmdLineAdd.Enabled = True
                Else
                    cmdLineAdd.Enabled = False
                End If
                
                '@============
                '@行ｺﾋﾟｰ
                ' 洗浄ﾌﾗｸﾞ、洗浄完了ﾌﾗｸﾞ、編集ﾌﾗｸﾞが共にFalseの場合有効
                '@============
                If mblnWashFlag = False And _
                   mblnWashCompFlag = False And _
                   mblnAtrayDataEditFlag = False Then
                    cmdLineCopy.Enabled = True
                Else
                    cmdLineCopy.Enabled = False
                End If
                
                '@============
                '@行削除
                ' 「新」の行のみ有効
                '@============
                If .Row >= .Rows.Fixed Then
                    If .GetData(.Row, CMlngvsfATrayEditCol) = CMstrNew Then
                        cmdLineDel.Enabled = True
                    Else
                        cmdLineDel.Enabled = False
                    End If
                Else
                    cmdLineDel.Enabled = False
                End If

                '@============
                '@登録ﾎﾞﾀﾝ
                ' 編集ﾌﾗｸﾞ、または、新規ﾌﾗｸﾞがTrueの場合、有効
                '@============
                If mblnAtrayDataEditFlag = True Or mblnAtrayNewDataFlag = True Then
                    cmdRegist2.Enabled = True
                Else
                    cmdRegist2.Enabled = False
                End If
               
        '@↓2019/03/20 (Wed) 11:55:08 T.Oide **************************************************
                '@============
                '@ｺﾒﾝﾄの有効/無効
                ' ﾀｲﾄﾙ行以外は有効
                '@============
                If vsfATrayList.Row > CMlngGridTitleRow Then
                    txtComments.Enabled = True
                Else
                    txtComments.Enabled = False
                End If
        '@↑2019/03/20 (Wed) 11:55:08 T.Oide **************************************************
            
            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdButtonEnable()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvChckData
    '機　能：登録前ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：OK、Flase：NG
    '作成日：2018/10/24 (Wed) 14:54:09 T.Oide
    '更新日：2018/10/24 (Wed) 14:54:09
    '備　考：
    Private Function prvChckData() As Boolean

        Dim llngCnt         As Integer
        Dim llngCnt2        As Integer
        Dim strCheckId      As String
        Dim lngCheckRow     As Integer

        Try
            
            '@ﾁｪｯｸ結果初期化
            prvChckData = False
            
            With vsfATrayList
                
                '---------------------------------
                '@ﾌﾟﾛﾀﾞｸﾄ品で貼りｸﾞﾙｰﾌﾟNULLはダメ
                '@AﾄﾚｰID、Aﾄﾚｰ区分、洗浄後使用回数上限、累積使用回数上限の空はダメ
                '@ﾓﾆﾀｰの貼りｸﾞﾙｰﾌﾟ設定はだめ
                '---------------------------------
                For llngCnt = 1 To .Rows.Count - 1
                
        '@↓2019/03/06 (Wed) 13:50:20 T.Oide **************************************************
        '@            '@ﾌﾟﾛﾀﾞｸﾄ品で貼りｸﾞﾙｰﾌﾟNULLか
        '@            If .Cell(flexcpText, llngCnt, CMlngvsfATrayAtrayIdCol) = vbNullString Or _
        '@               .Cell(flexcpText, llngCnt, CMlngvsfATrayClassCol) = vbNullString Then
        '@
        '@                '@対象表示
        '@                .Row = llngCnt
        '@                .Col = CMlngvsfATrayTapeStickGrCol
        '@                .ShowCell .Row, .Col
        '@
        '@                '@"<TRM159W>$$AトレーID、Aトレー区分は、空で登録できません。"
        '@                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0159)
        '@                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Caption, True, 16)
        '@-------------------------------------------------------------------------------------
                        
                    '@AﾄﾚｰID、区分、洗浄後使用回数上限、累積使用回数上限はNULLか
                    If .GetData(llngCnt, CMlngvsfATrayAtrayIdCol) = vbNullString Or _
                       .GetData(llngCnt, CMlngvsfATrayClassCol) = vbNullString Or _
                       .GetData(llngCnt, CMlngvsfATrayWashUseLimitCol) = vbNullString Or _
                       .GetData(llngCnt, CMlngvsfATrayUseLimitCol) = vbNullString Then
                        
                        '@対象表示
                        .Row = llngCnt
                        .Col = CMlngvsfATrayTapeStickGrCol
                        .ShowCell(.Row, .Col)
                        
                        '@"<TRM159W>$$AトレーID、Aトレー区分、洗浄後使用回数上限、累積使用回数上限は、空で登録できません。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0159)
                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
        '@↑2019/03/06 (Wed) 13:50:20 T.Oide **************************************************
                        
                        Exit Function
                    End If
                
                    '@ﾌﾟﾛﾀﾞｸﾄ品で貼りｸﾞﾙｰﾌﾟNULLか
                    If .GetData(llngCnt, CMlngvsfATrayClassCol) = CPstrUseIDProduct And _
                       .GetData(llngCnt, CMlngvsfATrayTapeStickGrCol) = vbNullString Then
                    
                        '@対象表示
                        .Row = llngCnt
                        .Col = CMlngvsfATrayTapeStickGrCol
                        .ShowCell(.Row, .Col)
                        
                        '@"<TRM158W>$$Aトレー区分が[製品]の場合、貼りグループを設定してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0158)
                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                        
                        Exit Function
                    End If
                    
        '@↓2019/03/12 (Tue) 17:06:40 T.Oide **************************************************
                    '@ﾓﾆﾀｰで貼りｸﾞﾙｰﾌﾟ<>NULLか
                    If .GetData(llngCnt, CMlngvsfATrayClassCol) <> CPstrUseIDProduct And _
                       .GetData(llngCnt, CMlngvsfATrayTapeStickGrCol) <> vbNullString Then

                        '@対象表示
                        .Row = llngCnt
                        .Col = CMlngvsfATrayTapeStickGrCol
                        .ShowCell(.Row, .Col)

                        '@"<TRM161W>$$Aトレー区分が[モニタ・ダミー]の場合、$テープ貼りグループは設定できません。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0161)
                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)

                        '@貼りｸﾞﾙｰﾌﾟをｸﾘｱ
                        .SetData(llngCnt, CMlngvsfATrayTapeStickGrCol, vbNullString)
                        
                        Exit Function
                    End If
        '@↑2019/03/12 (Tue) 17:06:40 T.Oide **************************************************
                    
                Next
                
                '@AﾄﾚｰIDが重複していないか
                For llngCnt = 1 To .Rows.Count - 1
                
                    '@ﾁｪｯｸID
                    strCheckId = .GetData(llngCnt, CMlngvsfATrayAtrayIdCol)
                    '@ﾁｪｯｸID行
                    lngCheckRow = llngCnt
            
                    '@ｸﾞﾘｯﾄﾞでﾙｰﾌﾟ
                    For llngCnt2 = 1 To .Rows.Count - 1
            
                        '@自分以外の行で同じAﾄﾚｰIDがないか
                        If strCheckId = .GetData(llngCnt2, CMlngvsfATrayAtrayIdCol) And _
                           lngCheckRow <> llngCnt2 Then
            
                            .Row = llngCnt2
                            .Col = CMlngvsfATrayAtrayIdCol
                            .ShowCell(.Row, .Col)
                            
                            '@"<TRM157W>$$AトレーID[%1]は既に登録済です。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0157, strCheckId)
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                            
                            Exit Function
            
                        End If
                        
                    Next
            
                Next
                
            End With

            '@ﾁｪｯｸOK
            prvChckData = True

            Exit Function

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvChckData()"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function


    '関数名：txtComments_init
    '機　能：ｺﾒﾝﾄ初期化
    '引　数：なし
    '戻り値：
    '作成日：2019/03/20 (Wed) 12:10:43 T.Oide
    '更新日：2019/03/20 (Wed) 12:10:43
    '備　考：
    Private Sub txtComments_init()

        Try
            
            '@ｺﾒﾝﾄ初期化
            With txtComments
                '@ﾃｷｽﾄ内容ｸﾘｱ
                .Text = vbNullString
                '@ﾛｯﾄｺﾒﾝﾄの最大文字数を設定する
                .ChrMaxByte = CPlngLotCommentsMaxByte
                '@複数行可能
                .MultiLineEx = True
                '@入力禁止文字
                .NgChr = CPstrSingleQ
            End With
            
            '@文字数表示
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, vbNullString, CPlngLotCommentsMaxByte)
            
            '@ｽｸﾛｰﾙ↑↓ﾎﾞﾀﾝ
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_init()"
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfATrayList.BeforeDoubleClick

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
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfATrayList.KeyDownEdit

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
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfATrayList.SetupEditor

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

End Class
