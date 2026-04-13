'ﾌｧｲﾙ名：xxEN01Z1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：新規登録画面/装置メンテナンス情報登録/更新画面
'作成日：2007/03/12 (Mon) 12:32:28 N.Kojima
'更新日：2008/04/15 (Tue) 15:32:35 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01Z1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01Z1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01Z1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01Z1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01Z1)
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
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN01Z1             'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_McGrouplistVer               As String = "01.00"                    '装置ｸﾞﾙｰﾌﾟ取得
    Private Const CMstreq__areacurlistVer               As String = "02.00"                    'ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置状態情報取得
    Private Const CMstreq__schwpmentechgVer             As String = "03.00"                    '装置停止・ﾒﾝﾃ計画登録更新/削除
    Private Const CMstrrep_chgrepairreportVer           As String = "03.00"                    '故障修理記録票登録/更新
    Private Const CMstrpre_chgpreservereportVer         As String = "01.00"                    '保全記録票登録/更新

    '@vsfMainteListの列順(親画面：装置停止・ﾒﾝﾃ計画)
    Private Const CMlngvsfMntColWPName                  As Integer = 2                         '装置名
    Private Const CMlngvsfMntColStartDate               As Integer = 5                         '開始予定日時
    Private Const CMlngvsfMntColEndDate                 As Integer = 6                         '終了予定日時

    '@vsfMainteListの列順(親画面：保全記録)
    Private Const CMlngvsfPreColWpName                  As Integer = 5                         '装置名
    Private Const CMlngvsfPreColStartDate               As Integer = 12                        '開始(予定)日時
    Private Const CMlngvsfPreColEndDate                 As Integer = 13                        '終了(予定)日時

    '@vsfMainteListの列順(親画面：保全記録票選択)
    Private Const CMlngCM00Z1vsfPreColPreserveStartDate As Integer = 6                         '開始(予定)日時
    Private Const CMlngCM00Z1vsfPreColPreserveEndDate   As Integer = 7                         '終了(予定)日時
    Private Const CMlngCM00Z1vsfPreColWpName            As Integer = 12                        '装置名(非表示)

    '@ｺﾝﾎﾞﾎﾞｯｸｽ共通の定数宣言
    Private Const CMlngCmbFontSize                      As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbRowHeight                     As Integer = 43                        'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                      As Integer = 0                         'ｺﾝﾎﾞ内列数(=0)
    Private Const CMlngCmbDispCols1                     As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbValueCol1                     As Integer = 1                         '値取得個数=1
    Private Const CMlngCmbCheck0                        As Integer = 0                         '装置ﾁｪｯｸ数(ﾃﾞﾌｫﾙﾄ)
    Private Const CMlngCmbGroupCols                     As Integer = 1                         '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMstrCmbCheckOn                       As String = "1"                        'ﾁｪｯｸON
    Private Const CMstrCmbCheckOff                      As String = "0"                        'ﾁｪｯｸOFF
    Private Const CMstrCmbSelect                        As String = " 項目選択"                '表示 文字列
    Private Const CMstrNoSelectString                   As String = "指定なし"                 '装置ｸﾞﾙｰﾌﾟ、装置名指定なし文字

    '@ﾌｫｰﾑﾀｲﾄﾙ
    Private Const CMstrMainteFromTitle                  As String = "装置停止・メンテ計画修正"          'ﾌｫｰﾑのﾀｲﾄﾙ(装置停止・ﾒﾝﾃ計画起動時に使用)
    Private Const CMstrMainteCopyInsertFromTitle        As String = "装置停止・メンテ計画コピー登録"    'ﾌｫｰﾑのﾀｲﾄﾙ(装置停止・ﾒﾝﾃ計画起動時に使用)

    '@停止時間
    Private Const CMstrDatediffMinute                   As String = "n"                        '間隔(分)
    Private Const CMlngMinute60                         As Integer = 60                        '60分(１時間)
    Private Const CMlng100                              As Integer = 100                       '100倍用
    Private Const CMcurStopTimeMin                      As Decimal = 0                         '停止時間の最小値
    Private Const CMcurStopTimeMax                      As Decimal = 99999.99                  '停止時間の最大値

    '@ﾃｷｽﾄ関連定数
    Private Const CMlngMaxDispRow                       As Integer = 6                         'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@親画面の各種ﾎﾞﾀﾝ(新規作成、修正)押下時の引継ぎ用定数
    Private Const CMlngInsertMode                       As Integer = 1                         '新規
    Private Const CMlngCopyInsertMode                   As Integer = 2                         'ｺﾋﾟｰ登録
    Private Const CMlngUpdateMode                       As Integer = 3                         '計画ﾃﾞｰﾀ修正
    Private Const CMlngResultUpdateMode                 As Integer = 5                         '実績ﾃﾞｰﾀ修正

    '@保全ｶﾃｺﾞﾘ
    Private Const CMstrPreventivePreserve               As String = "予防保全"                '保全ｶﾃｺﾞﾘ用
    Private Const CMstrImprovementPreserve              As String = "改良/改善保全"           '保全ｶﾃｺﾞﾘ用
    Private Const CMstrRoutinePreserve                  As String = "ルーチンメンテ"          '保全ｶﾃｺﾞﾘ用

    '@成功ﾒｯｾｰｼﾞ
    Private Const CMstrInsertMsg                        As String = "登録"                     '登録成功MSG
    Private Const CMstrUpdateMsg                        As String = "更新"                     '更新成功MSG
    Private Const CMstrRepairTitle                      As String = "故障修理記録票"           '登録or更新成功MSG
    Private Const CMstrPreserveTitle                    As String = "保全記録票"               '登録or更新成功MSG

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                         As String = "frmxxEN01Z1"                   '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"                     'Form_Load処理
    Private Const CMstrCmbMcGroupValidate               As String = "cmbMcGroup_Validate"           '装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞValidate処理
    Private Const CMstrCmbWpValidate                    As String = "cmbWp_Validate"                '装置名ｺﾝﾎﾞValidate処理
    Private Const CMstrCmbPreserveCategoryValidate      As String = "cmbPreserveCategory_Validate"  '保全ｶﾃｺﾞﾘｺﾝﾎﾞValidate処理
    Private Const CMstrCmdRegistClick                   As String = "cmdRegist_Click"               '確定処理

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '@通信情報格納用ﾓｼﾞｭｰﾙ変数/構造体
    Private mtypMcGroupList                             As McGroupList                      '装置ｸﾞﾙｰﾌﾟﾘｽﾄ格納
    Private mtypWpList                                  As List(Of AreaEquipmentList)       '装置ﾘｽﾄ格納
    Private mlngWpListCnt                               As Integer                          '装置ﾘｽﾄ数
    Private mtypRepairInfoReq                           As RepairInfo                       '故障修理記録票情報取得要求構造体
    Private mtypRepairInfoAns                           As RepairInfoAns                    '故障修理記録票情報取得応答構造体
    Private mtypPreserveInfoReq                         As PreserveInfo                     '保全記録票情報取得要求構造体
    Private mtypPreserveInfoAns                         As PreserveInfoAns                  '保全記録票情報取得応答構造体

    '@退避用ﾓｼﾞｭｰﾙ変数
    Private mstrOldMcGroupID                            As String                           '退避用装置ｸﾞﾙｰﾌﾟID
    Private mstrOldWpID                                 As String                           '退避用装置ID
    Private mstrOldStopTime                             As String                           '退避用停止時間
    Private mstrConnectWpID                             As String                           '引継ぎ装置ID格納用

    '@その他
    Private mblnFormLoadFlag                            As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:1回目/False:1回目以外)
    Private mblnEventSkipFlag                           As Boolean                          'ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞ(True:初期値/False:ｽｷｯﾌﾟ)
    Private mstrInitWpName                              As String                           '一覧画面の装置名

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
        medStartTime.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
        medEndTime.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
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
    '作成日：2007/03/12 (Mon) 12:35:18 N.Kojima
    '更新日：2008/01/15 (Tue) 15:48:35 N.Kojima
    '備　考：
    '　　　：2008/01/15 (Tue) 15:48:35 N.Kojima     計画保全機能追加&機能統合対応。(案件№02332)
    Private Sub Form_Load()
        
        Dim lblnAns             As Boolean              '結果格納
        
        Try
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
                
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = True
            
            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞの初期化(ｽｷｯﾌﾟなし)
            mblnEventSkipFlag = True
                
            '@=====================
            '@　ﾒｲﾝﾌｫｰﾑの初期化処理
            '@=====================
            Call prvFrmxxEN01Z1_Init()
            
            '@=====================
            '@　各ｺﾝﾎﾞの初期化処理
            '@=====================
            Call prvCmbMcGroup_Init             '装置ｸﾞﾙｰﾌﾟ
            Call prvCmbWp_Init                  '装置名
            Call prvCmbPreserveCategory_Init    '保全ｶﾃｺﾞﾘ
                
            '@起動区分が"0:装置停止・ﾒﾝﾃ計画"か
            If plngLoadClass = CPlngNumZero Then
                
                '@★ ﾓｰﾄﾞにより処理分岐 ★
                Select Case ptypEqStopMenteRenkeiInfo.lngInsertMode
                    
                    '@〓 "2:ｺﾋﾟｰ登録" 〓
                    Case CMlngCopyInsertMode
                    
                        '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを変更
                        Me.Text = CMstrMainteCopyInsertFromTitle


                    '@〓 "3:計画ﾃﾞｰﾀ修正"、"5:実績ﾃﾞｰﾀ修正" 〓
                    Case CMlngUpdateMode, CMlngResultUpdateMode
                    
                        '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを変更
                        Me.Text = CMstrMainteFromTitle
                
                End Select
            End If
                
            '@ﾓｰﾄﾞが"3:計画ﾃﾞｰﾀ修正"、"5:実績ﾃﾞｰﾀ修正"か
            '@　※下記の構造体は「装置停止・ﾒﾝﾃ計画」選択時にしかｾｯﾄしないので
            '@　　起動が「装置停止・ﾒﾝﾃ計画」かと言う条件も暗黙で入っています。
            If ptypEqStopMenteRenkeiInfo.lngInsertMode = CMlngResultUpdateMode Or _
                ptypEqStopMenteRenkeiInfo.lngInsertMode = CMlngUpdateMode Then
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                    
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
            Else
                '@装置停止・ﾒﾝﾃ計画の新規登録起動 or 故障修理起動 or 保全記録起動の場合

                
                '@装置状態変更からの起動以外か
                '@　※保全記録票選択画面からの起動の場合は、装置ｸﾞﾙｰﾌﾟ・装置名は引継ぎにて表示する為。
                If pblnUseChangLoadKbn = False Then
                
                    '@【装置ｸﾞﾙｰﾌﾟ取得】ﾒｯｾｰｼﾞ送受信処理(処理区分：全件)
                    lblnAns = pubblnMasMcGroupList_Sel(CMstrmas_McGrouplistVer, _
                                                       CPstrCD02, _
                                                       pstrSBID, _
                                                       mtypMcGroupList)
            
                    '@通信結果判定
                    If lblnAns = True Then
                        '@結果：正常の場合
                        
                        '@装置ｸﾞﾙｰﾌﾟが1件か
                        If mtypMcGroupList.lngMcGroupListCnt = 1 Then
                            '@1件の場合
                        
                            '@【ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置状態情報取得】ﾒｯｾｰｼﾞ送受信処理(CPstrCD20：装置ｸﾞﾙｰﾌﾟ別)
                            lblnAns = pubblnEqAreaCurList_Sel(CMstreq__areacurlistVer, _
                                                              vbNullString, _
                                                              pstrSBID, _
                                                              mtypWpList, _
                                                              mlngWpListCnt, _
                                                              CPstrCD20, _
                                                              mtypMcGroupList.typMcGroupList(0).strMcGroupID)
                                                              
                            '@通信結果判定
                            If lblnAns = False Then
                                '@結果：異常の場合
                                
                                '@Escﾎﾞﾀﾝを有効
                                Me.CancelButton = cmdClose
                                
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                                Exit Sub
                            End If
                        End If
                    Else
                        '@結果：異常の場合
                        
                        '@Escﾎﾞﾀﾝを有効
                        Me.CancelButton = cmdClose
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                        Exit Sub
                    End If
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
                Else
                    '@保全記録票選択画面からの起動の場合
                
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                        
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                End If
            End If
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            Exit Sub
            
        Catch ex As Exception
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
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
    '作成日：2007/03/12 (Mon) 12:44:12 N.Kojima
    '更新日：2008/01/25 (Fri) 16:50:11 N.Kojima
    '備　考：
    '　　　：2008/01/25 (Fri) 16:50:11 N.Kojima     計画保全対応。(案件№02332)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞがTrueか(Trueは初回起動時のみ)
            If mblnFormLoadFlag = True Then
                
                '@Form_Activate処理は初回の1回のみに制御する為、ﾌﾗｸﾞ変更
                mblnFormLoadFlag = False
                
                '@起動区分が"1:故障修理記録"以外か
                If plngLoadClass <> CPlngNumOne Then
                
                    '@停止時間
                    With txtStopTime
                        .BackColor = Color.White    '白
                        .Locked = False             'ﾛｯｸ解除
                        .Enabled = True             '有効
                    End With
                
                    '@終了(予定)日時(年月日)
                    With calEndDate
                        .BackColor = Color.White    '白
                        .Enabled = True             '有効
                    End With
                    '@終了(予定)日時(時間)
                    With medEndTime
                        .BackColor = Color.White    '白
                        .Enabled = True             '有効
                    End With

                    '@ｺﾒﾝﾄの初期化
                    With txtComment
                        .BackColor = Color.White    '白
                        .Locked = False             'ﾛｯｸ解除
                        .Enabled = True             '有効
                    End With
                End If
                
                '@起動区分が"2:保全記録"以外か("0:装置停止・ﾒﾝﾃ計画"or"1:故障修理記録"か)
                If plngLoadClass <> CPlngNumTwo Then
                    
                    '@保全ｶﾃｺﾞﾘｺﾝﾎﾞの制御
                    With cmbPreserveCategory
                        .Enabled = False                         '無効
                        .BackColor = SystemColors.ControlLight   '背景色:ｸﾞﾚｰ
                    End With
                End If
                
                '@★ 起動区分により処理分岐 ★
                Select Case plngLoadClass
                
                    '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                    Case CPlngNumZero
                        
                        '@処理なし
                
                
                    '@〓 "1:故障修理記録" 〓
                    Case CPlngNumOne
                        
                        '@停止時間にNULLをｾｯﾄ
                        txtStopTime.Text = vbNullString
                        
                        '@装置ﾒﾝﾃﾅﾝｽ計画設定ﾌﾚｰﾑを無効にする
                        cmbPreserveCategory.Enabled = False
                        txtStopTime.Enabled = False
                        calEndDate.Enabled = False
                        medEndTime.Enabled = False
                        
                        '@ｺﾒﾝﾄ関連ｺﾝﾄﾛｰﾙを無効にする
                        '@ｺﾒﾝﾄの初期化
                        With txtComment
                            .BackColor = SystemColors.ControlLight           'ｸﾞﾚｰ
                            .Locked = True                                   'ﾛｯｸ
                            .Enabled = False                                 '無効
                        End With
                        cmdCommentUp.Enabled = False            '上ｽｸﾛｰﾙﾎﾞﾀﾝ
                        cmdCommentDown.Enabled = False          '下ｽｸﾛｰﾙﾎﾞﾀﾝ
                
                
                    '@〓 "2:保全記録" 〓
                    Case CPlngNumTwo
                        
                        '@=====================
                        '@　保全ｶﾃｺﾞﾘｺﾝﾎﾞ作成処理
                        '@=====================
                        cmbPreserveCategory.Enabled = True      '有効
                        Call prvcmbPreserveCategory_Disp()

                End Select
                
                
                '@ﾓｰﾄﾞが"3:計画ﾃﾞｰﾀ修正"、"5:実績ﾃﾞｰﾀ修正"か
                '@　※下記の構造体は「装置停止・ﾒﾝﾃ計画」選択時にしかｾｯﾄしないので
                '@　　起動が「装置停止・ﾒﾝﾃ計画」かと言う条件も暗黙で入っています。
                If ptypEqStopMenteRenkeiInfo.lngInsertMode > CMlngCopyInsertMode Then
                    '@"3:計画ﾃﾞｰﾀ修正"、"5:実績ﾃﾞｰﾀ修正"の場合
                    
                    '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを"False:ｽｷｯﾌﾟ"に設定
                    mblnEventSkipFlag = False
                    
                    '@=====================
                    '@　画面情報表示処理
                    '@=====================
                    Call prvFrmxxEN01Z1_Disp()
                    
                    '@全部取消ﾎﾞﾀﾝを無効にする
                    cmdAllClear.Enabled = False
                    
                    '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを"True:Noｽｷｯﾌﾟ"に設定
                    mblnEventSkipFlag = True
                    
                    '@停止ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtComment)
                    
                Else
                    '@装置停止・ﾒﾝﾃ計画の"1:新規登録"、"2:ｺﾋﾟｰ登録"起動 or 故障修理起動 or 保全記録起動の場合
                    
                    
                    '@装置状態変更での起動か
                    '@　※保全記録票選択画面からの起動の場合は、装置ｸﾞﾙｰﾌﾟ・装置名は引継ぎにて表示する為。
                    If pblnUseChangLoadKbn = True Then
                        
                        '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを"False:ｽｷｯﾌﾟ"に設定
                        mblnEventSkipFlag = False
                        
                        '@ｺﾝﾄﾛｰﾙを一度有効にする
                        cmbMcGroup.Enabled = True       '装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ
                        cmbWp.Enabled = True            '装置名ｺﾝﾎﾞ
                        
                        '@******************************
                        '@　各種ｺﾝﾄﾛｰﾙに引継ぎ情報をｾｯﾄ
                        '@******************************
                        '@装置ｸﾞﾙｰﾌﾟ、装置名
                        cmbMcGroup.Text = ptypPreserveConnectInfo.strMcGroupName
                        cmbWp.Text = ptypPreserveConnectInfo.strWpName
                        cmbMcGroup.BackColor = SystemColors.ControlLight
                        cmbWp.BackColor = SystemColors.ControlLight
                        cmbMcGroup.ForeColor = Color.Black
                        cmbWp.ForeColor = Color.Black
                        
                        '@開始(予定)日時(年月日、時間)
                        calStartDate.Value = Format$(CDate(Mid$(ptypPreserveConnectInfo.strEntryTime, 1, 11)), CPstrDateTimeYMD)
                        medStartTime.Text = Format$(CDate(Mid$(ptypPreserveConnectInfo.strEntryTime, 1, 18)), CPstrTimeFormatHM)
                        calStartDate.BackColor = SystemColors.ControlLight
                        medStartTime.BackColor = SystemColors.ControlLight
                        calStartDate.ForeColor = Color.Black
                        medStartTime.ForeColor = Color.Black
                        
                        '@各種ｺﾝﾄﾛｰﾙを無効にする
                        pic1.Enabled = False            'ﾍｯﾀﾞｰ項目(装置ｸﾞﾙｰﾌﾟ、装置名)
                        pic4.Enabled = False            'ﾍｯﾀﾞｰ項目(開始(予定)日時、現在日時取得ﾎﾞﾀﾝ)
                        
                        '@保全ｶﾃｺﾞﾘが有効か
                        If cmbPreserveCategory.Enabled = True Then
                            '@保全ｶﾃｺﾞﾘにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbPreserveCategory)
                        Else
                            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                        
                        '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを"True:Noｽｷｯﾌﾟ"に設定
                        mblnEventSkipFlag = True
                    Else
                        '@保全記録票選択画面からの起動ではない場合
                    
                    
                        '@装置ｸﾞﾙｰﾌﾟが存在するか
                        If mtypMcGroupList.lngMcGroupListCnt <> 0 Then
                            '@装置ｸﾞﾙｰﾌﾟが存在する場合
                                        
                            '@=====================
                            '@　現在日時取得処理
                            '@=====================
                            Call cmdNowDate_Click(cmdNowDate,New EventArgs)
                            
                            '@=====================
                            '@　装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ作成処理
                            '@=====================
                            cmbMcGroup.Enabled = True
                            Call prvCmbMcGroup_Disp()
                            
                            '@装置ｸﾞﾙｰﾌﾟが1件の場合、ﾃﾞﾌｫﾙﾄ表示
                            If cmbMcGroup.ListCount = 1 Then
                                
                                '@=====================
                                '@　装置名ｺﾝﾎﾞ作成処理
                                '@=====================
                                cmbWp.Enabled = True    '有効
                                cmbWp.Clear             'ｸﾘｱ
                                Call prvcmbWp_Disp()
                
                            Else
                                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(cmbMcGroup)
                            End If
                        End If
                        
                        '@ﾓｰﾄﾞが"2:ｺﾋﾟｰ登録"か
                        '@　※下記の構造体は「装置停止・ﾒﾝﾃ計画」選択時にしかｾｯﾄしないので
                        '@　　起動が「装置停止・ﾒﾝﾃ計画」かと言う条件も暗黙で入っています。
                        If ptypEqStopMenteRenkeiInfo.lngInsertMode = CMlngCopyInsertMode Then
                            
                            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを"False:ｽｷｯﾌﾟ"に設定
                            mblnEventSkipFlag = False
                                          
                            '@******************************
                            '@　各種ｺﾝﾄﾛｰﾙに引継ぎ情報をｾｯﾄ
                            '@******************************
                            cmbMcGroup.Text = ptypEqStopMenteRenkeiInfo.strMcGroupName                                  '装置ｸﾞﾙｰﾌﾟ名                                            
                            cmbWp.Text = ptypEqStopMenteRenkeiInfo.strWpName                                            '装置名
                            If IsDate(ptypEqStopMenteRenkeiInfo.strWPStopStart) Then                                    '開始(予定)日時(年月日)
                                calStartDate.Value = Format$(CDate(ptypEqStopMenteRenkeiInfo.strWPStopStart), CPstrDateTimeYMD)    
                            Else
                                calStartDate.Value = ptypEqStopMenteRenkeiInfo.strWPStopStart   
                            End If
                            If IsDate(ptypEqStopMenteRenkeiInfo.strWPStopStart) Then                                    '開始(予定)日時(時間)
                                medStartTime.Text = Format$(CDate(ptypEqStopMenteRenkeiInfo.strWPStopStart), CPstrTimeFormatHM)    
                            Else
                                medStartTime.Text = ptypEqStopMenteRenkeiInfo.strWPStopStart    
                            End If 
                            cmbPreserveCategory.Text = vbNullString                                                     '保全ｶﾃｺﾞﾘ
                            txtStopTime.Text = ptypEqStopMenteRenkeiInfo.strStopTime                                    '停止時間

                            If IsDate(ptypEqStopMenteRenkeiInfo.strWPStopEnd) Then                                      '終了(予定)時間(年月日)
                                calEndDate.Value = Format$(CDate(ptypEqStopMenteRenkeiInfo.strWPStopEnd), CPstrDateTimeYMD)        
                            Else
                                calEndDate.Value = ptypEqStopMenteRenkeiInfo.strWPStopEnd
                            End If
                            If IsDate(ptypEqStopMenteRenkeiInfo.strWPStopEnd) Then                                      '終了(予定)時間(時間)
                                medEndTime.Text = Format$(CDate(ptypEqStopMenteRenkeiInfo.strWPStopEnd), CPstrTimeFormatHM)        
                            Else
                                medEndTime.Text = ptypEqStopMenteRenkeiInfo.strWPStopEnd
                            End If
                            txtComment.Text = ptypEqStopMenteRenkeiInfo.strComments                                     '停止ｺﾒﾝﾄ
                            
                            '@各値を退避     
                            mstrOldWpID = ptypEqStopMenteRenkeiInfo.strWpID         '装置ID
                            mstrConnectWpID = ptypEqStopMenteRenkeiInfo.strWpID     '引継ぎ戻し用装置ID
                            mstrOldStopTime = txtStopTime.Text                      '停止時間
                            
                            '@装置名を有効にする
                            cmbWp.Enabled = True
                          
                            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを"True:Noｽｷｯﾌﾟ"に設定
                            mblnEventSkipFlag = True
                            
                        End If
                        
                        '@ﾓｰﾄﾞが"1:新規登録"or"2:ｺﾋﾟｰ登録"か
                        If ptypEqStopMenteRenkeiInfo.lngInsertMode < CMlngUpdateMode Then
                            '@全部取消ﾎﾞﾀﾝを有効にする
                            cmdAllClear.Enabled = True
                        End If
                    End If
                End If
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
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
    '作成日：2007/03/12 (Mon) 12:46:31 N.Kojima
    '更新日：2008/01/25 (Fri) 16:51:13 N.Kojima
    '備　考：
    '　　　：2008/01/25 (Fri) 16:51:13 N.Kojima     計画保全対応。(案件№02332)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try

            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
                
                '@〓 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ 〓
                Case cmbMcGroup.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                        
                            '@=====================
                            '@　装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞのValidate処理
                            '@=====================
                            RemoveHandler cmbMcGroup.Validating,AddressOf cmbMcGroup_Validate
                            Call cmbMcGroup_Validate(cmbMcGroup,New CancelEventArgs(False))
                            AddHandler cmbMcGroup.Validating,AddressOf cmbMcGroup_Validate
                            e.Handled = True
                    End Select
                
                '@〓 装置名ｺﾝﾎﾞ 〓
                Case cmbWp.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                        
                            '@=====================
                            '@　装置名ｺﾝﾎﾞのValidate処理
                            '@=====================
                            RemoveHandler cmbWp.Validating,AddressOf cmbWp_Validate
                            Call cmbWp_Validate(cmbWp,New CancelEventArgs(False))
                            AddHandler cmbWp.Validating,AddressOf cmbWp_Validate
                            e.Handled = True
                    End Select
                    
                '@〓 開始(予定)日時(年月日)ｶﾚﾝﾀﾞｰｺﾝﾎﾞ 〓
                Case calStartDate.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                        
                            '@=====================
                            '@　開始(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
                            '@=====================
                            RemoveHandler calStartDate.Validating,AddressOf calStartDate_Validate
                            Call calStartDate_Validate(calStartDate,New CancelEventArgs(False))
                            AddHandler calStartDate.Validating,AddressOf calStartDate_Validate
                            e.Handled = True
                    End Select
                
                '@〓 開始(予定)日時(時間)ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ 〓
                Case medStartTime.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                        
                            '@=====================
                            '@　開始(予定)日時ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽのValidate処理
                            '@=====================
                            RemoveHandler medStartTime.Validating,AddressOf medStartTime_Validate
                            Call medStartTime_Validate(medStartTime,New CancelEventArgs(False))
                            AddHandler medStartTime.Validating,AddressOf medStartTime_Validate
                            e.Handled = True
                    End Select
                    
                '@〓 保全ｶﾃｺﾞﾘｺﾝﾎﾞ 〓
                Case cmbPreserveCategory.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                        
                            '@=====================
                            '@　保全ｶﾃｺﾞﾘｺﾝﾎﾞのValidate処理
                            '@=====================
                            RemoveHandler cmbPreserveCategory.Validating,AddressOf cmbPreserveCategory_Validate
                            Call cmbPreserveCategory_Validate(cmbPreserveCategory,New CancelEventArgs(False))
                            AddHandler cmbPreserveCategory.Validating,AddressOf cmbPreserveCategory_Validate
                            e.Handled = True
                    End Select
                    
                '@〓 停止時間ﾃｷｽﾄ 〓
                Case txtStopTime.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                        
                            '@=====================
                            '@　停止時間ﾃｷｽﾄのValidate処理
                            '@=====================
                            RemoveHandler txtStopTime.Validating,AddressOf txtStopTime_Validate
                            Call txtStopTime_Validate(txtStopTime,New CancelEventArgs(False))
                            AddHandler txtStopTime.Validating,AddressOf txtStopTime_Validate
                            e.Handled = True
                    End Select
                    
                '@〓 終了(予定)日時(年月日)ｶﾚﾝﾀﾞｰｺﾝﾎﾞ 〓
                Case calEndDate.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                        
                            '@=====================
                            '@　終了(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
                            '@=====================
                            RemoveHandler calEndDate.Validating,AddressOf calEndDate_Validate
                            Call calEndDate_Validate(calEndDate,New CancelEventArgs(False))
                            AddHandler calEndDate.Validating,AddressOf calEndDate_Validate
                            e.Handled = True
                    End Select
                
                '@〓 終了(予定)日時(時間)ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ 〓
                Case medEndTime.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                        
                            '@=====================
                            '@　終了(予定)日時ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽのValidate処理
                            '@=====================
                            RemoveHandler medEndTime.Validating, AddressOf medEndTime_Validate
                            Call medEndTime_Validate(medEndTime,NEw CancelEventArgs(False))
                            AddHandler medEndTime.Validating, AddressOf medEndTime_Validate
                            e.Handled = True
                    End Select
                    
                '@〓 ｺﾒﾝﾄﾃｷｽﾄ 〓
                Case txtComment.Name
                
                    '@分岐でCase Elseに飛ばないようにする為
                
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
    '作成日：2007/03/12 (Mon) 14:42:27 N.Kojima
    '更新日：2007/03/12 (Mon) 14:42:27
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
            
                '@=======================
                '@　閉じるﾎﾞﾀﾝ押下処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@引継ぎ装置ID格納変数から、引継ぎ構造体の装置IDに値を戻す
            ptypEqStopMenteRenkeiInfo.strWpID = mstrConnectWpID

            
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

    '関数名：cmbMcGroup_Change
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:10:55 N.Kojima
    '更新日：2007/03/12 (Mon) 15:10:55
    '備　考：
    Private Sub cmbMcGroup_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroup.Change

        Try
            
            '@退避領域と同じ値の場合には初期化しない
            If mstrOldMcGroupID <> cmbMcGroup.Value Then
                
                '@=====================
                '@　装置名ｺﾝﾎﾞの初期化処理
                '@=====================
                Call prvCmbWp_Init()
                 
                '@=====================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=====================
                Call prvCmdRegistControl_Proc()
                
                '@退避領域のｸﾘｱ
                mstrOldWpID = vbNullString
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroup_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroup_CloseUp
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:11:10 N.Kojima
    '更新日：2007/03/12 (Mon) 15:11:10
    '備　考：
    Private Sub cmbMcGroup_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroup.CloseUp

        Try

            '@装置ｸﾞﾙｰﾌﾟがNULLか
            If cmbMcGroup.Text <> vbNullString Then
            
                '@=====================
                '@　装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞのValidate処理
                '@=====================
                RemoveHandler cmbMcGroup.Validating,AddressOf cmbMcGroup_Validate
                Call cmbMcGroup_Validate(cmbMcGroup,New CancelEventArgs(True))
                AddHandler cmbMcGroup.Validating,AddressOf cmbMcGroup_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroup_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroup_Validate
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:11:25 N.Kojima
    '更新日：2007/03/12 (Mon) 15:11:25
    '備　考：
    Private Sub cmbMcGroup_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMcGroup.Validating

        Dim lblnAns             As Boolean              '結果格納
        
        Try

            With cmbMcGroup
            
                '@前回ID格納と同じ場合は処理しない
                If .Value = mstrOldMcGroupID Then
                    '@装置名ｺﾝﾎﾞへﾌｫｰｶｽ設定
                    If ActiveControl.Name = cmbMcGroup.Name Then
                        If cmbWp.Enabled = True Then
                            Call pubSetFocus(cmbWp)
                        Else
                            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                    End If

                    Exit Sub
                End If
            
                '@空欄の場合には閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If .Text = vbNullString Then
                    
                    '@Form_Load中は「cmdClose.Cancel=False」でEnabled=Falseなのでﾌｫｰｶｽはｾｯﾄしない
                    If pblnFormLoad <> False Then
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = cmbMcGroup.Name Then
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                    
                    Exit Sub
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmbMcGroupValidate)

                Me.KeyPreview = False

                '@【ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置状態情報取得】ﾒｯｾｰｼﾞ送受信処理(CPstrCD20：装置ｸﾞﾙｰﾌﾟ別)
                lblnAns = pubblnEqAreaCurList_Sel(CMstreq__areacurlistVer, _
                                                  vbNullString, _
                                                  pstrSBID, _
                                                  mtypWpList, _
                                                  mlngWpListCnt, _
                                                  CPstrCD20, _
                                                  .Value)

                Me.KeyPreview = True
                                                  
                '@通信結果判定
                If lblnAns = True Then
                    '@結果：正常の場合

                    '@=====================
                    '@　装置名ｺﾝﾎﾞ作成処理
                    '@=====================
                    cmbWp.Enabled = True    '有効
                    Call prvcmbWp_Disp()

                    '@次項目へｾｯﾄﾌｫｰｶｽ
                    If ActiveControl.Name = cmbMcGroup.Name Then
                        If cmbWp.Enabled = True Then
                            '@装置名にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbWp)
                        Else
                            '@閉じるにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                Else
                    '@結果：異常の場合
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmbMcGroupValidate)
                    
                    '@装置名ｺﾝﾎﾞを使用不可にする
                    cmbWp.Enabled = False
                    
                    '@ﾌｫｰｶｽを保持
                    e.Cancel = True
                    Exit Sub
                End If
                
                '@装置ｸﾞﾙｰﾌﾟを退避
                mstrOldMcGroupID = cmbMcGroup.Value
                
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmbMcGroupValidate)
            
            Exit Sub
            
        Catch ex As Exception

            Me.KeyPreview = True
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmbMcGroupValidate
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWp_Change
    '機　能：装置名ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/03/05 (Wed) 16:25:47 N.Kojima
    '更新日：2008/03/05 (Wed) 16:25:47
    '備　考：
    Private Sub cmbWp_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.Change

        Try
            
            '@退避領域と同じ値の場合には初期化しない
            If mstrOldWpID <> cmbWp.Value Then
                '@退避領域のｸﾘｱ
                mstrOldWpID = vbNullString
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWp_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWp_CloseUp
    '機　能：装置名ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:13:13 N.Kojima
    '更新日：2007/03/12 (Mon) 15:13:13
    '備　考：
    Private Sub cmbWp_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.CloseUp

        Try
            
            '@装置名がNULLか
            If cmbWp.Text <> vbNullString Then

                '@=====================
                '@　装置名ｺﾝﾎﾞのValidate処理を行なう
                '@=====================
                RemoveHandler cmbWp.Validating,AddressOf cmbWp_Validate
                Call cmbWp_Validate(cmbWp,New CancelEventArgs(True))
                AddHandler cmbWp.Validating,AddressOf cmbWp_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWp_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWp_Validate
    '機　能：装置名ｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:13:25 N.Kojima
    '更新日：2007/03/12 (Mon) 15:13:25
    '備　考：
    Private Sub cmbWp_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWp.Validating
            
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@装置IDを退避する
            mstrOldWpID = cmbWp.Value
            
            '@=====================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=====================
            Call prvCmdRegistControl_Proc()
            
            '@開始(予定)日時が有効か
            If ActiveControl.Name = cmbWp.Name Then
                If calStartDate.Enabled = True Then
                    '@開始(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(calStartDate)
                Else
                    '@Form_Load中は「cmdClose.Cancel=False」でEnabled=Falseなのでﾌｫｰｶｽはｾｯﾄしない
                    If pblnFormLoad <> False Then
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmbWpValidate
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStartDate_CalendarSelect
    '機　能：開始(予定)日時ｶﾚﾝﾀﾞｰ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:15:08 N.Kojima
    '更新日：2007/03/12 (Mon) 15:15:08
    '備　考：
    Private Sub calStartDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calStartDate.CalendarSelect

        Try

            '@日付が空の場合はﾌｫｰｶｽを留める
            If calStartDate.Value = CPstrNullDate Then
                Exit Sub
            End If
            
            '@=====================
            '@　開始(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
            '@=====================
            RemoveHandler calStartDate.Validating, AddressOf calStartDate_Validate
            Call calStartDate_Validate(calStartDate,New CancelEventArgs(True))
            AddHandler calStartDate.Validating, AddressOf calStartDate_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStartDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStartDate_Change
    '機　能：開始(予定)日時ｶﾚﾝﾀﾞｰ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:15:29 N.Kojima
    '更新日：2007/03/12 (Mon) 15:15:29
    '備　考：
    Private Sub calStartDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calStartDate.Change

        Try
            
            '@起動区分が"1:故障修理記録"以外か
            If plngLoadClass <> CPlngNumOne Then
            
                '@=====================
                '@　停止時間の計算処理
                '@=====================
                Call prvStopTimeCalc_Proc()
            End If
            
            '@=====================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=====================
            Call prvCmdRegistControl_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStartDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStartDate_Validate
    '機　能：開始(予定)日時ｶﾚﾝﾀﾞｰ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:24:10 N.Kojima
    '更新日：2007/03/12 (Mon) 15:24:10
    '備　考：
    Private Sub calStartDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calStartDate.Validating
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@開始(予定)日時(時間)が有効か
            If ActiveControl.Name = calStartDate.Name Then
                If medStartTime.Enabled = True Then
                    '@開始(予定)日時(時間)へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(medStartTime)
                Else
                    '@閉じるﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmdClose)
                End If
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStartDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：medStartTime_GotFocus
    '機　能：開始(予定)日時ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ　ﾌｫｰｶｽ取得時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:28:23 N.Kojima
    '更新日：2007/03/12 (Mon) 15:28:23
    '備　考：MaskEdBox使用のためﾊｲﾗｲﾄ処理
    Private Sub medStartTime_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles medStartTime.Enter

        Try
            
            '@=======================
            '@　ﾊｲﾗｲﾄ処理
            '@=======================
            Call pubHighlight(medStartTime)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medStartTime_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medStartTime_Change
    '機　能：開始(予定)日時ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:28:40 N.Kojima
    '更新日：2007/03/12 (Mon) 15:28:40
    '備　考：
    Private Sub medStartTime_Change(ByVal sender As Object, ByVal e As EventArgs) Handles medStartTime.TextChanged

        Try
           
            '@起動区分が"1:故障修理記録"以外か
            If plngLoadClass <> CPlngNumOne Then
            
                '@=====================
                '@　停止時間の計算処理
                '@=====================
                Call prvStopTimeCalc_Proc()
            End If
                
            '@=====================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=====================
            Call prvCmdRegistControl_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medStartTime_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medStartTime_Validate
    '機　能：開始(予定)日時ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:30:27 N.Kojima
    '更新日：2007/03/12 (Mon) 15:30:27
    '備　考：
    Private Sub medStartTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles medStartTime.Validating
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@現在日時取得ﾎﾞﾀﾝが有効な場合
            If ActiveControl.Name = medStartTime.Name Then
                If cmdNowDate.Enabled = True Then
                    '@現在日時取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdNowDate)
                Else
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medStartTime_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/01/25 (Fri) 17:04:22 N.Kojima **************************************************
    '関数名：cmbPreserveCategory_CloseUp
    '機　能：保全ｶﾃｺﾞﾘｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/25 (Fri) 17:05:54 N.Kojima
    '更新日：2008/01/25 (Fri) 17:05:54
    '備　考：
    Private Sub cmbPreserveCategory_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPreserveCategory.CloseUp

        Try
            
            '@保全ｶﾃｺﾞﾘがNULLか
            If cmbPreserveCategory.Text <> vbNullString Then

                '@=====================
                '@　保全ｶﾃｺﾞﾘｺﾝﾎﾞのValidate処理
                '@=====================
                RemoveHandler cmbPreserveCategory.Validating,AddressOf cmbPreserveCategory_Validate
                Call cmbPreserveCategory_Validate(cmbPreserveCategory,New CancelEventArgs(True))
                AddHandler cmbPreserveCategory.Validating,AddressOf cmbPreserveCategory_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPreserveCategory_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/25 (Fri) 17:04:22 N.Kojima **************************************************

    '@↓2008/01/25 (Fri) 17:04:17 N.Kojima **************************************************
    '関数名：cmbPreserveCategory_Validate
    '機　能：保全ｶﾃｺﾞﾘｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/01/25 (Fri) 17:06:27 N.Kojima
    '更新日：2008/01/25 (Fri) 17:06:27
    '備　考：
    Private Sub cmbPreserveCategory_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPreserveCategory.Validating
            
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@=====================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=====================
            Call prvCmdRegistControl_Proc()
            
            '@停止時間が有効か
            If ActiveControl.Name = cmbPreserveCategory.Name Then
                If txtStopTime.Enabled = True Then
                    '@停止時間にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtStopTime)
                Else
                    '@Form_Load中は「cmdClose.Cancel=False」でEnabled=Falseなのでﾌｫｰｶｽはｾｯﾄしない
                    If pblnFormLoad <> False Then
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmbPreserveCategoryValidate
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/25 (Fri) 17:04:17 N.Kojima **************************************************

    '@↓2008/01/28 (Mon) 10:37:31 N.Kojima **************************************************
    '関数名：txtStopTime_Change
    '機　能：停止時間ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/28 (Mon) 10:37:36 N.Kojima
    '更新日：2008/01/28 (Mon) 10:37:36
    '備　考：
    Private Sub txtStopTime_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtStopTime.Change

        Try
            
            '@=====================
            '@　終了(予定)日時の計算処理
            '@=====================
            Call prvEndDateCalc_Proc()
            
            '@=====================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=====================
            Call prvCmdRegistControl_Proc()

            '@退避領域と同じ値の場合には初期化しない
            If mstrOldStopTime <> txtStopTime.Text Then
                '@退避領域のｸﾘｱ
                mstrOldStopTime = vbNullString
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtStopTime_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/28 (Mon) 10:37:31 N.Kojima **************************************************

    '@↓2008/01/28 (Mon) 10:37:31 N.Kojima **************************************************
    '関数名：txtStopTime_Validate
    '機　能：停止時間ﾃｷｽﾄ　Validate処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/28 (Mon) 10:37:36 N.Kojima
    '更新日：2008/01/28 (Mon) 10:37:36
    '備　考：
    Private Sub txtStopTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtStopTime.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@前回入力の停止時間と異なるか
            If txtStopTime.Text <> mstrOldStopTime Then
            
                '@=====================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=====================
                Call prvCmdRegistControl_Proc()
                
                '@停止時間を退避
                mstrOldStopTime = txtStopTime.Text
            End If
            
            '@終了(予定)日時が有効か
            If ActiveControl.Name = txtStopTime.Name Then
                If calEndDate.Enabled = True Then
                    '@終了(予定)日時にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(calEndDate)
                Else
                    '@停止ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtComment)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtStopTime_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/28 (Mon) 10:37:31 N.Kojima **************************************************

    '@↓2008/01/28 (Mon) 10:44:01 N.Kojima **************************************************
    '関数名：calEndDate_Change
    '機　能：終了(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/28 (Mon) 10:44:04 N.Kojima
    '更新日：2008/01/28 (Mon) 10:44:04
    '備　考：
    Private Sub calEndDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calEndDate.Change

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=====================
            '@　停止時間の計算処理
            '@=====================
            Call prvStopTimeCalc_Proc()
            
            '@=====================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=====================
            Call prvCmdRegistControl_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calEndDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/28 (Mon) 10:44:01 N.Kojima **************************************************

    '@↓2008/01/28 (Mon) 10:45:00 N.Kojima **************************************************
    '関数名：calEndDate_CalendarSelect
    '機　能：終了(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/28 (Mon) 10:45:22 N.Kojima
    '更新日：2008/01/28 (Mon) 10:45:22
    '備　考：
    Private Sub calEndDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calEndDate.CalendarSelect

        Try
            
            '@終了(予定)日時ｶﾚﾝﾀﾞｰがNULLか
            If calEndDate.Value <> CPstrNullDate Then
            
                '@=====================
                '@　終了(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
                '@=====================
                RemoveHandler calEndDate.Validating,AddressOf calEndDate_Validate
                Call calEndDate_Validate(calEndDate,New CancelEventArgs(True))
                AddHandler calEndDate.Validating,AddressOf calEndDate_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calEndDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/28 (Mon) 10:45:00 N.Kojima **************************************************

    '@↓2008/01/28 (Mon) 10:45:42 N.Kojima **************************************************
    '関数名：calEndDate_Validate
    '機　能：終了(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/01/28 (Mon) 10:45:50 N.Kojima
    '更新日：2008/01/28 (Mon) 10:45:50
    '備　考：
    Private Sub calEndDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calEndDate.Validating
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@終了(予定)日時(時間)が有効か
            If ActiveControl.Name = calEndDate.Name Then
                If medEndTime.Enabled = True Then
                    '@終了(予定)日時(時間)へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(medEndTime)
                Else
                    '@閉じるﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmdClose)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calEndDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/28 (Mon) 10:45:42 N.Kojima **************************************************

    '@↓2008/01/28 (Mon) 10:50:56 N.Kojima **************************************************
    '関数名：medEndTime_GotFocus
    '機　能：終了(予定)日時ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ　ﾌｫｰｶｽ取得時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/28 (Mon) 10:50:59 N.Kojima
    '更新日：2008/01/28 (Mon) 10:50:59
    '備　考：MaskEdBox使用のためﾊｲﾗｲﾄ処理
    Private Sub medEndTime_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles medEndTime.Enter

        Try

            '@=======================
            '@　ﾊｲﾗｲﾄ処理
            '@=======================
            Call pubHighlight(medEndTime)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medEndTime_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/28 (Mon) 10:50:56 N.Kojima **************************************************

    '@↓2008/01/28 (Mon) 10:52:59 N.Kojima **************************************************
    '関数名：medEndTime_Change
    '機　能：終了(予定)日時ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/28 (Mon) 10:53:49 N.Kojima
    '更新日：2008/01/28 (Mon) 10:53:49
    '備　考：
    Private Sub medEndTime_Change(ByVal sender As Object, ByVal e As EventArgs) Handles medEndTime.TextChanged

        Try
            
            '@=====================
            '@　停止時間の計算処理
            '@=====================
            Call prvStopTimeCalc_Proc()
            
            '@=====================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=====================
            Call prvCmdRegistControl_Proc()

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medEndTime_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/28 (Mon) 10:52:59 N.Kojima **************************************************

    '@↓2008/01/28 (Mon) 11:42:35 N.Kojima **************************************************
    '関数名：medEndTime_Validate
    '機　能：終了(予定)時間ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/01/28 (Mon) 11:42:41 N.Kojima
    '更新日：2008/01/28 (Mon) 11:42:41
    '備　考：
    Private Sub medEndTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles medEndTime.Validating
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｺﾒﾝﾄが有効か
            If ActiveControl.Name = medEndTime.Name Then
                If txtComment.Enabled = True Then
                    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtComment)
                Else
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medEndTime_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/28 (Mon) 11:42:35 N.Kojima **************************************************

    '@↓2008/01/15 (Tue) 15:45:51 N.Kojima **************************************************
    '関数名：txtComment_Change
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/15 (Tue) 15:45:57 N.Kojima
    '更新日：2008/01/15 (Tue) 15:45:57
    '備　考：
    Private Sub txtComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComment.Change

        Dim llngNowByte     As Integer  'ﾊﾞｲﾄ数

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞ中は処理中止
            If mblnFormLoadFlag = True Then
                Exit Sub
            End If

            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtComment.NowByte
            
            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

            '@ﾓｰﾄﾞが"5:実績ﾃﾞｰﾀ修正"か
            If ptypEqStopMenteRenkeiInfo.lngInsertMode = CMlngResultUpdateMode Then
                    
                '@ｺﾒﾝﾄが変更されているか
                If ptypEqStopMenteRenkeiInfo.strComments <> txtComment.Text Then
                
                    '@確定ﾎﾞﾀﾝを有効にする
                    cmdRegist.Enabled = True
                End If
            Else
                '@=====================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=====================
                Call prvCmdRegistControl_Proc()
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/15 (Tue) 15:45:51 N.Kojima **************************************************

    '@↓2008/01/15 (Tue) 15:43:05 N.Kojima **************************************************
    '関数名：txtComment_KeyUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2008/01/15 (Tue) 15:43:08 N.Kojima
    '更新日：2008/01/15 (Tue) 15:43:08
    '備　考：
    Private Sub txtComment_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComment.KeyUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/15 (Tue) 15:43:05 N.Kojima **************************************************

    '@↓2008/01/15 (Tue) 15:42:25 N.Kojima **************************************************
    '関数名：txtComment_MouseUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2008/01/15 (Tue) 15:42:28 N.Kojima
    '更新日：2008/01/15 (Tue) 15:42:28
    '備　考：
    Private Sub txtComment_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles txtComment.MouseUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄ変更時処理
            '@=======================
            Call pubtxtChange_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/15 (Tue) 15:42:25 N.Kojima **************************************************

    '@↓2008/01/15 (Tue) 15:45:17 N.Kojima **************************************************
    '関数名：cmdCommentUp_Click
    '機　能：上ｽｸﾛｰﾙ(▲)ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/15 (Tue) 15:45:31 N.Kojima
    '更新日：2008/01/15 (Tue) 15:45:31
    '備　考：
    Private Sub cmdCommentUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentUp.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　上ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubtxtCmdUp_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/15 (Tue) 15:45:17 N.Kojima **************************************************

    '@↓2008/01/15 (Tue) 15:44:34 N.Kojima **************************************************
    '関数名：cmdCommentDown_Click
    '機　能：下ｽｸﾛｰﾙ(▼)ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/15 (Tue) 15:45:03 N.Kojima
    '更新日：2008/01/15 (Tue) 15:45:03
    '備　考：
    Private Sub cmdCommentDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentDown.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　下ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubtxtCmdDown_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/15 (Tue) 15:44:34 N.Kojima **************************************************

    '関数名：cmdNowDate_Click
    '機　能：現在日時取得ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:34:54 N.Kojima
    '更新日：2007/03/12 (Mon) 15:34:54
    '備　考：
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
            calStartDate.Value = Format$(Now, CPstrDateTimeYMD)        '開始(予定)日時(年月日)
            medStartTime.Text = Format$(Now, CPstrTimeFormatHM)        '開始(予定)日時(時間)
            
            '@最新日時のValidationを制御(日付がｴﾗｰとなった場合に即使用できるように制御)
            cmdNowDate.CausesValidation = True
            
            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass
            
                '@〓 "0:装置停止・ﾒﾝﾃ計画"、"2:保全記録" 〓
                Case CPlngNumZero, CPlngNumTwo
                
                    '@停止時間が有効か
                    If txtStopTime.Enabled = True Then
                        Call pubSetFocus(txtStopTime)   '停止時間にﾌｫｰｶｽｾｯﾄ
                    Else
                        Call pubSetFocus(cmdClose)      '閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    End If
                
                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne
                
                    '@確定ﾎﾞﾀﾝが有効か
                    If cmdRegist.Enabled = True Then
                        Call pubSetFocus(cmdRegist)     '確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Else
                        Call pubSetFocus(cmdClose)      '閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    End If
                
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowDate_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 14:44:11 N.Kojima
    '更新日：2007/03/12 (Mon) 14:44:11
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

            '@∇∇∇∇∇∇∇∇∇
            '@　ｱﾝﾛｰﾄﾞ処理
            '@∇∇∇∇∇∇∇∇∇
            Me.Close()
            
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

    '@↓2008/01/15 (Tue) 15:38:44 N.Kojima **************************************************
    '関数名：cmdAllClear_Click
    '機　能：全部取消ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/15 (Tue) 15:38:48 N.Kojima
    '更新日：2008/01/15 (Tue) 15:38:48
    '備　考：
    Private Sub cmdAllClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAllClear.Click

        Dim llngNowByte     As Integer          '現在のﾊﾞｲﾄ数格納

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを"False:ｽｷｯﾌﾟする"に設定
            mblnEventSkipFlag = False
            
            '@装置状態変更以外からの起動か
            '@　※保全記録票選択画面からの起動の場合は、装置ｸﾞﾙｰﾌﾟ・装置名・開始(予定)日時は消さない。
            If pblnUseChangLoadKbn = False Then
            
                '@各種ｺﾝﾄﾛｰﾙの初期化(共通部)
                cmbMcGroup.Text = vbNullString              '装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ
                cmbWp.Text = vbNullString                   '装置名ｺﾝﾎﾞ
                
                '@ﾓｼﾞｭｰﾙ変数の初期化
                mstrOldMcGroupID = vbNullString             '装置ｸﾞﾙｰﾌﾟID退避用
                
                '@=====================
                '@　装置名ｺﾝﾎﾞの初期化処理
                '@=====================
                Call prvCmbWp_Init()
                
                '@通信情報格納用ﾓｼﾞｭｰﾙ変数/構造体の初期化
                
                If mtypWpList Is Nothing Then'装置ﾘｽﾄ格納
                    mtypWpList = New List(Of AreaEquipmentList)
                Else
                    mtypWpList.Clear
                End If
                mlngWpListCnt = 0                           '装置ﾘｽﾄ数
                
                '@各種ｺﾝﾄﾛｰﾙの初期化(共通部)
                calStartDate.Value = vbNullString           '開始(予定)日時(年月日)
                medStartTime.Text = CPstrNullTime           '開始(予定)日時(時間)
            End If
            
            '@各種ｺﾝﾄﾛｰﾙの初期化(装置ﾒﾝﾃﾅﾝｽ計画設定部)
            cmbPreserveCategory.Text = vbNullString     '保全ｶﾃｺﾞﾘｺﾝﾎﾞ
            txtStopTime.Text = CMcurStopTimeMin         '停止時間(0)
            calEndDate.Value = vbNullString             '終了(予定)日時(年月日)("____/__/__")
            medEndTime.Text = CPstrNullTime             '終了(予定)日時(時間)("__:__")

            '@ｺﾒﾝﾄの初期化
            With txtComment
                .ChrMaxByte = CPlngLotCommentsMaxByte   '文字数設定
                .Text = vbNullString                    '表示部初期化
                llngNowByte = .NowByte                  '現状のﾊﾞｲﾄ数を格納
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = _
                    pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            End With
            
            '@=====================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=====================
            Call prvCmdRegistControl_Proc()
            
            '@ﾎﾞﾀﾝの使用不可
            cmdCommentUp.Enabled = False                'ｽｸﾛｰﾙ上
            cmdCommentDown.Enabled = False              'ｽｸﾛｰﾙ下
            cmdAllClear.Enabled = False                 '全部取消ﾎﾞﾀﾝ
            cmdRegist.Enabled = False                   '確定ﾎﾞﾀﾝ

            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを初期化する
            mblnEventSkipFlag = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdAllClear_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/15 (Tue) 15:38:44 N.Kojima **************************************************

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　Click＆押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:07:06 N.Kojima
    '更新日：2008/02/27 (Wed) 14:55:48 N.Kojima
    '備　考：
    '　　　：2008/02/27 (Wed) 14:55:48 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrPreserveNo          As String               '保全記録票№
        Dim lstrRepairNo            As String               '故障修理記録票№
        Dim lstrEditTime            As String               '更新(登録)日時
        Dim ltypEqStopMenteReq      As EqStopMenteReq       '装置停止・ﾒﾝﾃ計画登録構造体

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾓｰﾄﾞが"5:実績ﾃﾞｰﾀ修正"以外の場合
            If ptypEqStopMenteRenkeiInfo.lngInsertMode <> CMlngResultUpdateMode Then
                '@ﾓｰﾄﾞが"5:実績ﾃﾞｰﾀ修正"以外の場合は入力ﾁｪｯｸを行なう
            
                '@=======================
                '@　入力ﾁｪｯｸ処理
                '@=======================
                lblnAns = prvInputItemChk_Proc
                
                '@ﾁｪｯｸ結果判定
                If lblnAns = False Then
                    '@結果：異常の場合
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                    Exit Sub
                End If
            
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
            
            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass
            
                '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                Case CPlngNumZero
                
                    '@****************
                    '@　要求ﾃﾞｰﾀ作成
                    '@****************
                    With ltypEqStopMenteReq
                
                        .strSbID = pstrSBID                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strMsgVer = CMstreq__schwpmentechgVer              'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                                
                        '@★ ﾓｰﾄﾞにより処理分岐 ★
                        Select Case ptypEqStopMenteRenkeiInfo.lngInsertMode
                            
                            '@〓 "1:新規" or "2:ｺﾋﾟｰ登録" 〓
                            Case CMlngInsertMode, CMlngCopyInsertMode
                            
                                .strClassDivision = CPstrCD39                               '処理区分(39:新規)
                                .strWpID = cmbWp.Value                                      '装置ID
                            
                            '@〓 "3:計画ﾃﾞｰﾀ修正" 〓
                            Case CMlngUpdateMode
                            
                                .strClassDivision = CPstrCD06                               '処理区分(06:計画ﾃﾞｰﾀ修正)
                                .strWpID = ptypEqStopMenteRenkeiInfo.strWpID                '装置ID
                            
                            '@〓 "5:実績ﾃﾞｰﾀ修正" 〓
                            Case CMlngResultUpdateMode
                            
                                .strClassDivision = CPstrCD4D                               '処理区分(4D:実績ﾃﾞｰﾀ修正)
                                .strWpID = ptypEqStopMenteRenkeiInfo.strWpID                '装置ID
                                .strWPStopStartOld = vbNullString                           '旧開始予定日
                                .strWPStopStart = ptypEqStopMenteRenkeiInfo.strWPStopStart  '開始日時
                                .strWPStopEnd = ptypEqStopMenteRenkeiInfo.strWPStopEnd      '終了日時
                                .strWPStopRule = CPstrZero                                  '停止ﾙｰﾙ(0)
                                .strWPStopComments = txtComment.Text                        '停止ｺﾒﾝﾄ
                                .strEmpID = pstrUserID                                      '作業者ID
                                .strEditTime = ptypEqStopMenteRenkeiInfo.strEditTime        '最終更新日時
                                .strCategoryID = ptypEqStopMenteRenkeiInfo.strCategoryID    'ｶﾃｺﾞﾘID
                                .strEntryTime = ptypEqStopMenteRenkeiInfo.strEntryTime      '登録日時
                                
                        End Select
                        
                        '@ﾓｰﾄﾞが"5:実績ﾃﾞｰﾀ修正"以外か
                        If ptypEqStopMenteRenkeiInfo.lngInsertMode <> CMlngResultUpdateMode Then
                            '@起動ﾓｰﾄﾞが"5:実績ﾃﾞｰﾀ修正"以外の場合
                            
                            '@旧開始(予定)日時の設定
                            '@旧開始(予定)日時(秒まで表記)がNULLか
                            If ptypEqStopMenteRenkeiInfo.strWPStopStartOld = vbNullString Then
                                '@旧開始(予定)日時(秒まで表記)がNULLの場合
                            
                                '@新規、参照登録の場合は、旧開始(予定)日時へ新開始(予定)日時を設定する
                               .strWPStopStartOld = Format$(CDate(calStartDate.Value & Space(1) & medStartTime.Text), CPstrDateTimeYMDHMS)
                            Else
                                '@旧開始(予定)日時(秒まで表記)がNULL以外の場合
                            
                                '@修正の場合は旧開始(予定)日時をそのまま設定する
                                .strWPStopStartOld = Format$(CDate(ptypEqStopMenteRenkeiInfo.strWPStopStartOld), CPstrDateTimeYMDHMS)
                            End If
                            
                            .strWPStopStart = _
                                Format$(CDate(calStartDate.Value & Space(1) & medStartTime.Text), CPstrDateTimeYMDHMS)     '開始(予定)日時(秒まで表記)
                            .strWPStopEnd = _
                                Format$(CDate(calEndDate.Value & Space(1) & medEndTime.Text), CPstrDateTimeYMDHMS)         '終了(予定)日時(秒まで表記)
                                    
                            '@停止方法(R4-14の対応で当機能は廃止。必要があれば下記ｺﾒﾝﾄ部を復活してください)
                            .strWPStopRule = 0
        '                    '@★ ﾁｪｯｸ状態により処理分岐 ★
        '                    Select Case True
        '
        '                        '@〓 強制停止 〓
        '                        Case optStopRule(CMlngStopRule1).Value = True
        '
        '                            .strWPStopRule = CMlngStopRule1             '強制
        '
        '                        '@〓 ﾛｯﾄ優先停止 〓
        '                        Case optStopRule(CMlngStopRule3).Value = True
        '
        '                            .strWPStopRule = CMlngStopRule3             'ﾛｯﾄ優先
        '
        '                        '@〓 その他(例外) 〓
        '                        Case Else
        '
        '                            .strWPStopRule = 0
        '                    End Select
                
                            .strWPStopComments = txtComment.Text                        '停止ｺﾒﾝﾄ
                            .strEmpID = pstrUserID                                      '作業者ID
                            .strEditTime = ptypEqStopMenteRenkeiInfo.strEditTime        '最終更新日時(新規時にはNullが設定)
                            .strCategoryID = ptypEqStopMenteRenkeiInfo.strCategoryID    'ｶﾃｺﾞﾘID
                            .strEntryTime = ptypEqStopMenteRenkeiInfo.strEntryTime      '登録日時(新規時にはNullが設定)
                        End If
                    End With
                
                    Me.KeyPreview = False
                
                    '@【装置停止・ﾒﾝﾃ計画 登録/更新/削除】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnEqStopMente_Upd(ltypEqStopMenteReq)

                    Me.KeyPreview = True
                    
                    '@通信結果判定
                    If lblnAns = False Then
                        '@結果：異常の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                        Exit Sub
                    End If
                    
                    '@★ ﾓｰﾄﾞにより処理分岐 ★
                    Select Case ptypEqStopMenteRenkeiInfo.lngInsertMode
                        
                        '@〓 "1:新規" or "2:ｺﾋﾟｰ登録" 〓
                        Case CMlngInsertMode, CMlngCopyInsertMode
                        
                            '@表示ﾒｯｾｰｼﾞ変換("<TRM5GI>$$メンテ計画を登録しました。装置[%2]、開始予定日時[%3]")
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005G, CMstrInsertMsg, cmbWp.Text, _
                                                            Format$(CDate(calStartDate.Value & Space(1) & medStartTime.Text), CPstrDateTimeYMDHM))
                        
                        '@〓 "3:計画ﾃﾞｰﾀ修正" 〓
                        Case CMlngUpdateMode
                            
                            '@表示ﾒｯｾｰｼﾞ変換("<TRM5GI>$$メンテ計画を修正しました。装置[%2]、開始予定日時[%3]")
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005G, CMstrUpdateMsg, cmbWp.Text, _
                                                            Format$(CDate(calStartDate.Value & Space(1) & medStartTime.Text), CPstrDateTimeYMDHM))
                        
                        '@〓 "5:実績ﾃﾞｰﾀ修正 〓
                        Case CMlngResultUpdateMode
                            
                            '@表示ﾒｯｾｰｼﾞ変換("<TRM5ZI>$$実績データを修正しました。装置[%1]、開始(予定)日時[%2]")
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005Z, cmbWp.Text, _
                                                            Format$(CDate(calStartDate.Value & Space(1) & medStartTime.Text), CPstrDateTimeYMDHM))
                    End Select
                    '@ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                    
                    '@ﾓｰﾄﾞが"5:実績ﾃﾞｰﾀ修正"以外か
                    If ptypEqStopMenteRenkeiInfo.lngInsertMode <> CMlngResultUpdateMode Then
                        '@ﾓｰﾄﾞが"5:実績ﾃﾞｰﾀ修正"以外の場合
                        
                        '@***********************************
                        '@　装置停止ﾒﾝﾃ計画登録連携情報の設定
                        '@***********************************
                        With ptypEqStopMenteRenkeiInfo
                            .strWpID = cmbWp.Value      '装置ID
                            .strWPStopStart = Format$(CDate(calStartDate.Value & Space(1) & medStartTime.Text), CPstrDateTimeYMDHM)     '開始予定日時
                        End With
                    End If
                    
                    '@∇∇∇∇∇∇∇∇∇
                    '@　ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇
                    Me.Close()
            
            
                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne
            
                    '@*****************
                    '@　要求ﾃﾞｰﾀ作成
                    '@*****************
                    With mtypRepairInfoReq
                
                        .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸID
                        .strEmpID = pstrUserID                      '作業者ID(起案者、更新者、発見者)
                        .strEmpName = pstrUserName                  '作業者名(起案者、更新者、発見者)
                        .strMsgVer = CMstrrep_chgrepairreportVer    'ﾒｯｾｰｼﾞVer
                        .strWpID = cmbWp.Value                      '装置ID
                        .strWpName = cmbWp.Text                     '装置名
                        .strOldUseID = vbNullString                 '変更前装置状態ID
                        .strUseId = vbNullString                    '変更後装置状態ID
                        .strActionID = CPstrOne                     'ｱｸｼｮﾝID(1:新規登録)
                        .strRepairStatus = CPstrZero                '故障修理記録票状態(0:未処置)
                        .strEntryClass = CPstrZero                  '起票区分(0:手動起票)
                        .strRepairStartDate = _
                            calStartDate.Value & CPstrSpace & medStartTime.Text     '開始(予定)日時
                    End With

                    Me.KeyPreview = False
                
                    '@【故障修理記録票登録/更新】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnRepChgRepairReport_Upd(mtypRepairInfoReq, _
                                                           lstrEditTime, _
                                                           lstrRepairNo)

                    Me.KeyPreview = True
                
                    '@通信結果判定
                    If lblnAns = True Then
                        '@結果：正常の場合
                
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                
                        '@ﾒｯｾｰｼﾞを表示する
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Q, CMstrRepairTitle, _
                                                        CMstrInsertMsg, lstrRepairNo)
                        '@pubVsfInfo_Disp("<TRM6QI>$$%1を[%2]しました。%1№[%3]")
                        Call pubVsfInfo_Disp(pstrDMsg)
                
                        '@**************************
                        '@　引継ぎ構造体に情報をｾｯﾄ
                        '@**************************
                        ptypRepairInfo.strSbID = pstrSBID           'ｼｽﾃﾑﾌﾞﾛｯｸID
                        ptypRepairInfo.strEmpID = pstrUserID        '作業者ID(起案者、更新者、発見者)
                        ptypRepairInfo.strEmpName = pstrUserName    '作業者名(起案者、更新者、発見者)
                        ptypRepairInfo.strWpID = cmbWp.Value        '装置ID
                        ptypRepairInfo.strWpName = cmbWp.Text       '装置名
                        ptypRepairInfo.strRepairNo = lstrRepairNo   '故障修理記録票№
                        ptypRepairInfo.strEditTime = lstrEditTime   '登録日時(更新日時、開始(予定)日時)
                        ptypRepairInfo.strEntryClass = CPstrZero    '起票区分(0:手動起票)
                        
                        '@∇∇∇∇∇∇∇∇∇
                        '@　ｱﾝﾛｰﾄﾞ処理
                        '@∇∇∇∇∇∇∇∇∇
                        Me.Close()
                        
                        '@=====================
                        '@　装置ﾒﾝﾃﾅﾝｽ記録票画面を起動する為のFunctionをCall
                        '@=====================
                        lblnAns = prvMainteReport_Disp(CMstrLocalMenuKey)
                        
                        '@処理結果判定
                        If lblnAns = False Then
                            '@装置ﾒﾝﾃﾅﾝｽ記録票画面起動に失敗した場合
                
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000M, CPstrSubFormCM00Z0)
                            '@"<TRM0ME>$$%1画面の自動起動に失敗しました。$装置メンテナンス記録一覧画面より処理票を選択し編集を行なってください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        End If
                    Else
                        '@結果：異常の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                    End If


                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo
            
                    '@*****************
                    '@　要求ﾃﾞｰﾀ作成
                    '@*****************
                    With mtypPreserveInfoReq
                
                        .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸID
                        .strEmpID = pstrUserID                      '作業者ID(起案者、更新者、発見者)
                        .strEmpName = pstrUserName                  '作業者名(起案者、更新者、発見者)
                        .strMsgVer = CMstrpre_chgpreservereportVer  'ﾒｯｾｰｼﾞVer
                        .strOldUseID = vbNullString                 '変更前装置状態ID
                        .strUseId = CPstrMcUseIDPlanMnt             '装置状態ID(ｶﾃｺﾞﾘID)
                        .strActionID = CPstrOne                     'ｱｸｼｮﾝID(1:新規登録)
                        .strPreserveStatus = CPstrZero              '保全記録票状態(0:未処置)
                        .strPreserveStartDate = calStartDate.Value & CPstrSpace & medStartTime.Text     '開始(予定)日時
                        .strPreserveEndDate = calEndDate.Value & CPstrSpace & medEndTime.Text           '終了(予定)日時
                        .strPreserveCategory = cmbPreserveCategory.Value                                '保全ｶﾃｺﾞﾘ
                        .strPreserveComments = txtComment.Text                                          '停止ｺﾒﾝﾄ
                    
                        '@保全記録票選択画面からの起動か
                        '@　※保全記録票選択画面からの起動の場合は装置ｸﾞﾙｰﾌﾟIDを引き継いでくる
                        If pblnUseChangLoadKbn = True Then
                            
                            .strWpID = ptypPreserveConnectInfo.strWpID              '装置ID(引継ぎ構造体ﾃﾞｰﾀからｾｯﾄ)
                            .strWpName = ptypPreserveConnectInfo.strWpName          '装置名(引継ぎ構造体ﾃﾞｰﾀからｾｯﾄ)
                            .strEntryClass = CPstrOne                               '起票区分(1:自動起票)
                            .strEntryTime = ptypPreserveConnectInfo.strEntryTime    '登録日時(装置状態変更日時)
                        Else
                            .strWpID = cmbWp.Value                              '装置ID(ｺﾝﾎﾞからｾｯﾄ)
                            .strWpName = cmbWp.Text                             '装置名(ｺﾝﾎﾞからｾｯﾄ)
                            .strEntryClass = CPstrZero                          '起票区分(0:手動起票)
                        End If
                    
                    End With

                    Me.KeyPreview = False
                
                    '@【保全記録票登録/更新】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnPreChgPreserveReport_Upd(mtypPreserveInfoReq, _
                                                             lstrEditTime, _
                                                             lstrPreserveNo)

                    Me.KeyPreview = True
                
                    '@通信結果判定
                    If lblnAns = True Then
                        '@結果：正常の場合
                
                        '@ﾒｯｾｰｼﾞを表示する
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Q, CMstrPreserveTitle, _
                                                        CMstrInsertMsg, lstrPreserveNo)
                        '@pubVsfInfo_Disp("<TRM6QI>$$%1を[%2]しました。%1№[%3]")
                        Call pubVsfInfo_Disp(pstrDMsg)
                
                        '@**************************
                        '@　引継ぎ構造体に情報をｾｯﾄ
                        '@**************************
                        ptypPreserveInfo.strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸID
                        ptypPreserveInfo.strEmpID = pstrUserID                      '作業者ID(起案者、更新者、発見者)
                        ptypPreserveInfo.strEmpName = pstrUserName                  '作業者名(起案者、更新者、発見者)
                        ptypPreserveInfo.strWpID = mtypPreserveInfoReq.strWpID      '装置ID
                        ptypPreserveInfo.strWpName = mtypPreserveInfoReq.strWpName  '装置名
                        ptypPreserveInfo.strCategoryID = CPstrMcUseIDPlanMnt        'ｶﾃｺﾞﾘID
                        ptypPreserveInfo.strCategoryName = vbNullString             'ｶﾃｺﾞﾘ名
                        ptypPreserveInfo.strPreserveNo = lstrPreserveNo             '保全記録票№
                        ptypPreserveInfo.strEditTime = lstrEditTime                 '登録日時(更新日時、開始(予定)日時)
                        ptypPreserveInfo.strEntryClass = CPstrZero                  '起票区分(0:手動起票)
                        ptypPreserveInfo.strPreserveCategory = _
                            cmbPreserveCategory.Value                               '保全ｶﾃｺﾞﾘ
                        
                        '@保全記録票起票済みﾌﾗｸﾞに"True：登録"をｾｯﾄ
                        pblnPreserveReportRegistFlag = True
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                        
                        '@∇∇∇∇∇∇∇∇∇
                        '@　ｱﾝﾛｰﾄﾞ処理
                        '@∇∇∇∇∇∇∇∇∇
                        Me.Close()
                        
                        '@=====================
                        '@　装置ﾒﾝﾃﾅﾝｽ記録票画面を起動する為のFunctionをCall
                        '@=====================
                        lblnAns = prvMainteReport_Disp(CMstrLocalMenuKey)
                        
                        '@処理結果判定
                        If lblnAns = False Then
                            '@装置ﾒﾝﾃﾅﾝｽ記録票画面起動に失敗した場合
                
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000M, CPstrSubFormCM00Z0)
                            '@"<TRM0ME>$$%1画面の自動起動に失敗しました。$装置メンテナンス記録一覧画面より処理票を選択し編集を行なってください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        End If
                    Else
                        '@結果：異常の場合
                    
                        '@保全記録票起票済みﾌﾗｸﾞに"False：未登録"をｾｯﾄ
                        pblnPreserveReportRegistFlag = False
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                    End If

            End Select

            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmdRegistClick
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

    '関数名：prvFrmxxEN01Z1_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ　初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 14:46:51 N.Kojima
    '更新日：2008/01/15 (Tue) 15:51:24 N.Kojima
    '備　考：
    '　　　：2008/01/15 (Tue) 15:51:24 N.Kojima     計画保全機能追加&機能統合対応。(案件№02332)
    Private Sub prvFrmxxEN01Z1_Init()
        
        Dim llngNowByte         As Integer          '現在のByte格納用
        Dim ltypMcGroupList     As McGroupList      '装置ｸﾞﾙｰﾌﾟ構造体初期化用
        
        Try
            
            '@開始(予定)日時(年月日＆時間)の初期化
            calStartDate.Value = CPstrNullDate          '開始(予定)日時(年月日)
            medStartTime.Text = CPstrNullTime           '開始(予定)日時(時間)
            
            '@終了(予定)日時(年月日)
            With calEndDate
                .Value = CPstrNullDate                  '"____/__/__"
                .BackColor = SystemColors.ControlLight  'ｸﾞﾚｰ
                .Enabled = False                        '無効
            End With
            '@終了(予定)日時(時間)
            With medEndTime
                .Text = CPstrNullTime                   '"__:__"
                .BackColor = SystemColors.ControlLight  'ｸﾞﾚｰ
                .Enabled = False                        '無効
            End With

            '@停止時間
            With txtStopTime
                .Text = Format$(CMcurStopTimeMin, CPstrDoubleFormat2String)     '0.00
                .BackColor = SystemColors.ControlLight  'ｸﾞﾚｰ
                .Locked = False                         'ﾛｯｸ解除
            End With

            '@ｺﾒﾝﾄの初期化
            With txtComment
                .ChrMaxByte = CPlngLotCommentsMaxByte   '文字数設定
                .Text = vbNullString                    '表示部初期化

                '@=======================
                '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換処理)
                '@=======================
                llngNowByte = .NowByte                  '現状のﾊﾞｲﾄ数を格納
                lblLengthCount.Text = _
                    pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            End With
            
            '@ﾓｼﾞｭｰﾙ変数の初期化
            mstrOldMcGroupID = vbNullString             '装置ｸﾞﾙｰﾌﾟID退避用
            mstrOldWpID = vbNullString                  '装置ID退避用
            mstrOldStopTime = vbNullString              '停止時間退避用
            mstrConnectWpID = vbNullString              '引継ぎ装置ID退避用
            
            '@通信情報格納用ﾓｼﾞｭｰﾙ変数/構造体の初期化
            mtypMcGroupList = ltypMcGroupList           '装置ｸﾞﾙｰﾌﾟﾘｽﾄ格納

            If mtypWpList Is Nothing Then               '装置ﾘｽﾄ格納
                mtypWpList = New List(Of AreaEquipmentList)
            Else
                mtypWpList.Clear
            End If
            mlngWpListCnt = 0                           '装置ﾘｽﾄ数

            '@ﾎﾞﾀﾝの使用不可
            cmdCommentUp.Enabled = False                'ｽｸﾛｰﾙ上
            cmdCommentDown.Enabled = False              'ｽｸﾛｰﾙ下
            cmdAllClear.Enabled = False                 '全部取消ﾎﾞﾀﾝ
            cmdRegist.Enabled = False                   '確定ﾎﾞﾀﾝ
            
            '@閉じるﾎﾞﾀﾝはValidate無効
            cmdClose.CausesValidation = False
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN01Z1_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '@↓2008/01/28 (Mon) 10:42:22 N.Kojima **************************************************
    '関数名：prvFrmxxEN01Z1_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/28 (Mon) 10:42:22 N.Kojima
    '更新日：2008/01/28 (Mon) 10:42:22
    '備　考：
    Private Sub prvFrmxxEN01Z1_Disp()
        
        Try
            
            '@各種ｺﾝﾄﾛｰﾙを有効にする
            cmbMcGroup.Enabled = True                       '装置ｸﾞﾙｰﾌﾟ
            cmbWp.Enabled = True                            '装置名
            calStartDate.Enabled = True                     '開始(予定)日時(年月日)
            medStartTime.Enabled = True                     '開始(予定)日時(時間)
            cmbPreserveCategory.Enabled = True              '保全ｶﾃｺﾞﾘ
            txtStopTime.Enabled = True                      '停止時間
            calEndDate.Enabled = True                       '終了(予定)時間(年月日)
            medEndTime.Enabled = True                       '終了(予定)時間(時間)
            txtComment.Enabled = True                       '停止ｺﾒﾝﾄ
            
            '@******************************
            '@　各種ｺﾝﾄﾛｰﾙに引継ぎ情報をｾｯﾄ
            '@******************************
            
            cmbMcGroup.Text = vbNullString                                                              '装置ｸﾞﾙｰﾌﾟ
            cmbWp.Text = ptypEqStopMenteRenkeiInfo.strWpName                                            '装置名
            If IsDate(ptypEqStopMenteRenkeiInfo.strWPStopStart) Then                                    '開始(予定)日時(年月日)
                calStartDate.Value = Format$(CDate(ptypEqStopMenteRenkeiInfo.strWPStopStart), CPstrDateTimeYMD)    
            Else
                calStartDate.Value = ptypEqStopMenteRenkeiInfo.strWPStopStart
            End If
            If IsDate(ptypEqStopMenteRenkeiInfo.strWPStopStart) Then                                    '開始(予定)日時(時間)
                medStartTime.Text = Format$(CDate(ptypEqStopMenteRenkeiInfo.strWPStopStart), CPstrTimeFormatHM)    
            Else
                medStartTime.Text = ptypEqStopMenteRenkeiInfo.strWPStopStart
            End If
            cmbPreserveCategory.Text = vbNullString                                                     '保全ｶﾃｺﾞﾘ
            txtStopTime.Text = ptypEqStopMenteRenkeiInfo.strStopTime                                    '停止時間
            txtComment.Text = ptypEqStopMenteRenkeiInfo.strComments                                     '停止ｺﾒﾝﾄ
            
            '@引継ぎ情報の終了(予定)日時がNULL以外か
            If ptypEqStopMenteRenkeiInfo.strWPStopEnd <> vbNullString Then
            
                '@NULL以外の場合は、引継ぎ値をﾌｫｰﾏｯﾄしてｾｯﾄ
                If IsDate(ptypEqStopMenteRenkeiInfo.strWPStopEnd) Then                                  '終了(予定)時間(年月日)
                    calEndDate.Value = Format$(CDate(ptypEqStopMenteRenkeiInfo.strWPStopEnd), CPstrDateTimeYMD)    
                Else
                    calEndDate.Value = ptypEqStopMenteRenkeiInfo.strWPStopEnd
                End If
                If IsDate(ptypEqStopMenteRenkeiInfo.strWPStopEnd)                                       '終了(予定)時間(時間)
                    medEndTime.Text = Format$(CDate(ptypEqStopMenteRenkeiInfo.strWPStopEnd), CPstrTimeFormatHM)
                Else
                    medEndTime.Text = ptypEqStopMenteRenkeiInfo.strWPStopEnd
                End If
            Else
                '@NULLの場合は、NULLﾌｫｰﾏｯﾄをｾｯﾄ
                calEndDate.Value = CPstrNullDate        '終了(予定)時間(年月日)
                medEndTime.Text = CPstrNullTime         '終了(予定)時間(時間)
            End If
            
            '@停止時間を退避
            mstrOldStopTime = txtStopTime.Text
            
            '@各ｺﾝﾄﾛｰﾙの背景色をｸﾞﾚｰに設定
            cmbMcGroup.BackColor = SystemColors.ControlLight             '装置ｸﾞﾙｰﾌﾟ
            cmbWp.BackColor = SystemColors.ControlLight                  '装置名
            cmbPreserveCategory.BackColor = SystemColors.ControlLight    '保全ｶﾃｺﾞﾘ
            calStartDate.BackColor = SystemColors.ControlLight           '開始(予定)日時(年月日)
            medStartTime.BackColor = SystemColors.ControlLight           '開始(予定)日時(時間)
            
            '@各種ｺﾝﾄﾛｰﾙを無効にする
            cmbMcGroup.Enabled = False              'ﾍｯﾀﾞｰ項目(装置ｸﾞﾙｰﾌﾟ、装置名)
            cmbWP.Enabled = False
            calStartDate.Enabled = False            'ﾍｯﾀﾞｰ項目(開始(予定)日時)
            medStartTime.Enabled = False
            cmbPreserveCategory.Enabled = False     '保全ｶﾃｺﾞﾘ
            
            
            '@ﾓｰﾄﾞが"5:実績ﾃﾞｰﾀ修正"か
            If ptypEqStopMenteRenkeiInfo.lngInsertMode = CMlngResultUpdateMode Then
            
                '@各ｺﾝﾄﾛｰﾙの背景色をｸﾞﾚｰに設定
                calEndDate.BackColor = SystemColors.ControlLight         '終了(予定)日時(年月日)
                medEndTime.BackColor = SystemColors.ControlLight         '終了(予定)日時(時間)
                txtStopTime.BackColor = SystemColors.ControlLight        '停止時間
                txtStopTime.GotBackColor = SystemColors.ControlLight
                txtStopTime.Locked = True
            
                '@停止時間、終了(予定)時間を無効にする
                txtStopTime.Enabled = False
                calEndDate.Enabled = False
                medEndTime.Enabled = False
            End If
            
            '@現在日時取得ﾎﾞﾀﾝを無効にする
            cmdNowDate.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN01Z1_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/28 (Mon) 10:42:22 N.Kojima **************************************************

    '関数名：prvCmbMcGroup_Init
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:37:59 N.Kojima
    '更新日：2007/03/12 (Mon) 15:37:59
    '備　考：
    Private Sub prvCmbMcGroup_Init()

        Try
            
            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ
            With cmbMcGroup
                
                .Enabled = True                                         '有効
                .Clear                                                  'ｸﾘｱ
                .DirectInput = False                                    '直接入力不可
                .Height = CMlngCmbRowHeight                             '高さ
                .RowHeight = CMlngCmbRowHeight                          '高さ(行)
                .DispCols = CMlngCmbDispCols1                           'ｸﾞﾘｯﾄﾞ表示列数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.GridFont.Style, .GridFont.Unit)    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ   
                .ValueCol = CMlngCmbValueCol1                           '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter   '左寄中央揃え
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbMcGroup_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbMcGroup_Disp
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:38:11 N.Kojima
    '更新日：2007/03/12 (Mon) 15:38:11
    '備　考：
    Private Sub prvCmbMcGroup_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ
            With cmbMcGroup

                .Clear      'ｸﾘｱ
                
                '@**************************
                '@　装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞに情報ｾｯﾄ
                '@**************************
                For llngCnt = 0 To mtypMcGroupList.lngMcGroupListCnt -1
                    '@装置ｸﾞﾙｰﾌﾟ名/装置ｸﾞﾙｰﾌﾟID
                    .AddItem(mtypMcGroupList.typMcGroupList(llngCnt).strMcGroupName _
                           & vbTab _
                           & mtypMcGroupList.typMcGroupList(llngCnt).strMcGroupID)
                Next llngCnt
                    
                '@ｺﾝﾎﾞの表示数を指定
                .GroupRows = mtypMcGroupList.lngMcGroupListCnt
                    
                '@装置ｸﾞﾙｰﾌﾟが1件の場合、ﾃﾞﾌｫﾙﾄ表示
                If .ListCount = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbMcGroup_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbWp_Init
    '機　能：装置名ｺﾝﾎﾞ　初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:38:32 N.Kojima
    '更新日：2007/03/12 (Mon) 15:38:32
    '備　考：
    Private Sub prvCmbWp_Init()

        Try

            '@装置名ｺﾝﾎﾞ
            With cmbWp

                .Enabled = False                                             '無効
                .Clear                                                       'ｸﾘｱ
                .DirectInput = False                                         '直接入力不可
                .Height = CMlngCmbRowHeight                                  '高さ
                .RowHeight = CMlngCmbRowHeight                               '高さ(行)
                .DispCols = CMlngCmbDispCols1                                'ｸﾞﾘｯﾄﾞ表示列数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.GridFont.Style, .GridFont.Unit)    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ   
                .ValueCol = CMlngCmbValueCol1                                '値取得列
                .SelectMode = 0                                              '選択ﾓｰﾄﾞ(単数選択ﾓｰﾄﾞ=0)
                .AllSelectButton = True                                      '全選択ﾎﾞﾀﾝ表示
                .GroupCols = CMlngCmbGroupCols                               '列方向のﾚｺｰﾄﾞ数
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter   '左寄中央揃え
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbWp_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbWp_Disp
    '機　能：装置名ｺﾝﾎﾞ　作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/12 (Mon) 15:39:25 N.Kojima
    '更新日：2007/03/12 (Mon) 15:39:25
    '備　考：
    Private Sub prvcmbWp_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try
            
            '@装置名ｺﾝﾎﾞ
            With cmbWp

                .Clear         'ｸﾘｱ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter           '左寄中央揃え
                
                '@**************************
                '@　装置名ｺﾝﾎﾞに情報ｾｯﾄ
                '@**************************
                For llngCnt = 0 To mlngWpListCnt -1
                    '@装置名/装置ID/現在のｶｳﾝﾄ数/装置状態
                    .AddItem(mtypWpList(llngCnt).strWpName & vbTab & _
                              mtypWpList(llngCnt).strWpID & vbTab & _
                              llngCnt & vbTab & _
                              mtypWpList(llngCnt).strWpStatusName)
                Next llngCnt
                
                '@装置名が1件の場合、ﾃﾞﾌｫﾙﾄ表示
                If .ListCount = 1 Then
                    '@1件目表示
                    .ListIndex = 0

                    '@装置名ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbWp)
                Else
                    '@ﾓｰﾄﾞが"2:ｺﾋﾟｰ登録"か
                    If ptypEqStopMenteRenkeiInfo.lngInsertMode = CMlngCopyInsertMode Then
                        
                        For llngCnt = 0 To mlngWpListCnt -1
                            
                            '@引継ぎ装置IDとｺﾝﾎﾞﾘｽﾄの装置IDが同じか
                            If ptypEqStopMenteRenkeiInfo.strWpID = mtypWpList(llngCnt).strWpID Then
                            
                                '@合致した装置名を表示
                                .ListIndex = llngCnt
                                
                                '@引継ぎ装置IDを一旦初期化する(画面終了時に戻す)
                                ptypEqStopMenteRenkeiInfo.strWpID = vbNullString
                            End If
                        Next llngCnt
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbWp_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/01/17 (Thu) 13:38:41 N.Kojima **************************************************
    '関数名：prvcmbPreserveCategory_Init
    '機　能：保全ｶﾃｺﾞﾘｺﾝﾎﾞ　初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/17 (Thu) 13:39:18 N.Kojima
    '更新日：2008/01/25 (Fri) 16:11:49 N.Kojima
    '備　考：
    Private Sub prvCmbPreserveCategory_Init()

        Try

            '@保全ｶﾃｺﾞﾘｺﾝﾎﾞ
            With cmbPreserveCategory

                .Enabled = False                                                '無効
                .Clear                                                          'ｸﾘｱ
                .DirectInput = False                                            '直接入力不可
                .Height = CMlngCmbRowHeight                                     '高さ
                .RowHeight = CMlngCmbRowHeight                                  '高さ(行)
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.GridFont.Style, .GridFont.Unit)    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ   .ValueCol = CMlngCmbValueCol1                           '値取得列
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .SelectMode = 0                                                 '選択ﾓｰﾄﾞ(単数選択ﾓｰﾄﾞ=0)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPreserveCategory_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/17 (Thu) 13:38:41 N.Kojima **************************************************

    '@↓2008/01/17 (Thu) 15:15:24 N.Kojima **************************************************
    '関数名：prvcmbPreserveCategory_Disp
    '機　能：保全ｶﾃｺﾞﾘｺﾝﾎﾞ　作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/17 (Thu) 15:10:40 N.Kojima
    '更新日：2008/01/17 (Thu) 15:10:40
    '備　考：
    Private Sub prvcmbPreserveCategory_Disp()

        Try
            
            '@保全ｶﾃｺﾞﾘｺﾝﾎﾞ
            With cmbPreserveCategory

                .Clear          'ｸﾘｱ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter       '左寄中央揃え
                
                '@**************************
                '@　保全ｶﾃｺﾞﾘｺﾝﾎﾞに情報ｾｯﾄ
                '@**************************
                '@予防保全、改良/改善保全、ﾙｰﾁﾝﾒﾝﾃを固定でｾｯﾄ
                .AddItem(CMstrPreventivePreserve & vbTab & CPlngNumOne)      '予防保全/ID=1
                .AddItem(CMstrImprovementPreserve & vbTab & CPlngNumTwo)     '改良/改善保全/ID=2
                .AddItem(CMstrRoutinePreserve & vbTab & CPlngNumThree)       'ﾙｰﾁﾝﾒﾝﾃ/ID=3
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPreserveCategory_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/17 (Thu) 15:15:24 N.Kojima **************************************************

    '@↓2008/01/15 (Tue) 15:39:51 N.Kojima **************************************************
    '関数名：prvCmdRegistControl_Proc
    '機　能：確定ﾎﾞﾀﾝ制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/15 (Tue) 15:40:00 N.Kojima
    '更新日：2008/01/15 (Tue) 15:40:00
    '備　考：
    Private Sub prvCmdRegistControl_Proc()

        Try

            Dim llngCnt             As Integer              '汎用ｶｳﾝﾀ
            Dim lblnChkErrFlag      As Boolean              'ｴﾗｰﾌﾗｸﾞ(True：ｴﾗｰあり、False:ｴﾗｰなし)
            Dim lstrNowDate         As String               '現在日付格納用
            Dim lstrStartDate       As String               '開始(予定)日時
            Dim lstrEndDate         As String               '終了(予定)日時
            Dim ldblStopMinute      As Double               '停止時間(分)
            Dim lcurStopHour        As Decimal             '時間間隔(時間)少数点

            Dim llngWpNameColNo     As Integer              '列番号格納用(装置名)
            Dim llngStartDateColNo  As Integer              '列番号格納用(開始(予定)日時)
            Dim llngEndDateColNo    As Integer              '列番号格納用(終了(予定)日時)
        '    Dim lctlCheckItem       As Control              'ﾁｪｯｸ元ｺﾝﾄﾛｰﾙ格納用

            '@ｴﾗｰﾌﾗｸﾞの初期化
            lblnChkErrFlag = False
            
            '@----------------
            '@　共通部のﾁｪｯｸ
            '@----------------
            '@装置名、開始(予定)日時(年月日、時間)にNULLがあるか
            If IsDate(calStartDate.Value) = False Or _
                IsDate(medStartTime.Text) = False Or _
                cmbWp.Text = vbNullString Then
                
                '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                lblnChkErrFlag = True
            End If
            
            '@***************************************************
            '@　起動区分が"故障修理記録"の場合は
            '@　開始(予定)日時もﾁｪｯｸする
            '@***************************************************
            If plngLoadClass = CPlngNumOne Then
            
                '@現在日付を格納
                lstrNowDate = Format$(Now, CPstrDateTimeYMDHM)
                
                '@開始(予定)日時が未来日付か
                If IsDate(calStartDate.Value & Space(1) & medStartTime.Text) Then
                    If Format$(CDate(calStartDate.Value & Space(1) & medStartTime.Text), CPstrDateTimeYMDHM) > lstrNowDate Then
                        '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                        lblnChkErrFlag = True
                    End If
                End If
            End If
            
            '@***************************************************
            '@　起動区分が"装置停止・ﾒﾝﾃ計画"or"保全記録"の場合は
            '@　装置ﾒﾝﾃﾅﾝｽ計画設定部もﾁｪｯｸする
            '@***************************************************
            If plngLoadClass <> CPlngNumOne Then
                
                '@停止時間が数値以外、または終了(予定)日時が日付以外か
                If IsNumeric(txtStopTime.Text) = False Or _
                    IsDate(calEndDate.Value) = False Then
                    
                    '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                    lblnChkErrFlag = True
                End If
                
                '@ｴﾗｰﾌﾗｸﾞがOFF(False:ｴﾗｰなし)のままか
                If lblnChkErrFlag = False Then
                    
                    '@日付ﾁｪｯｸ用に「年月日+時間」のﾌｫｰﾏｯﾄに変換する
                    lstrStartDate = Format$(CDate(calStartDate.Value & Space(1) & medStartTime.Text), CPstrDateTimeYMDHM)  '開始予定日時
                    
                    '@終了(予定)日時(時間)が"__:__"以外か
                    If IsDate(medEndTime.Text) = True Then
                        
                        lstrEndDate = Format$(CDate(calEndDate.Value & Space(1) & medEndTime.Text), CPstrDateTimeYMDHM)    '終了予定日時
                    Else
                        '@"__:__"の場合
                    
                        lstrEndDate = Format$(CDate(calEndDate.Value & Space(1) & CPstrDayStartTime), CPstrDateTimeYMDHM)  '終了予定日時
                    End If
                    
                    '@開始(予定)日時と終了(予定)日時の大小ﾁｪｯｸを行う
                    If lstrStartDate >= lstrEndDate Then
                        '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                        lblnChkErrFlag = True
                    End If
                    
                    '@------------------------
                    '@　停止時間のﾁｪｯｸを行う
                    '@------------------------
                    If CDec(txtStopTime.Text) <= 0 Then
                        '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                        lblnChkErrFlag = True
                    End If
                           
                    '@------------------------
                    '@　停止時間の最大値確認
                    '@------------------------
                    '@開始～終了までの時間間隔(分単位)を算出する
                    ldblStopMinute = DateDiff(CMstrDatediffMinute, lstrStartDate, lstrEndDate)
                    '@時間へ変換する(少数第2位迄算出する為に100倍し、切捨て後、100で割る)
                    lcurStopHour = Fix(ldblStopMinute / CMlngMinute60 * 100) / 100
                    
                    '@停止時間の最大値確認
                    If lcurStopHour > CMcurStopTimeMax Then
                        '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                        lblnChkErrFlag = True
                    End If
                
                    '@起動区分が"0:装置停止・ﾒﾝﾃ計画"か
                    If plngLoadClass = CPlngNumZero Then
                    
                        '@親画面の列番号を格納
                        llngWpNameColNo = CMlngvsfMntColWPName              '装置名
                        llngStartDateColNo = CMlngvsfMntColStartDate        '開始(予定)日時
                        llngEndDateColNo = CMlngvsfMntColEndDate            '終了(予定)日時
                        
        '                '@ﾁｪｯｸ元ｺﾝﾄﾛｰﾙに"frmxxEN01Z0:装置ﾒﾝﾃﾅﾝｽ記録票一覧ﾌｫｰﾑ"を格納
        '                Set lctlCheckItem = frmxxEN01Z0
                    Else
                        '@"2:保全記録"の場合
                        
                        '@装置状態変更での起動か
                        '@　※保全記録票選択画面からの起動の場合は、R4-14では重複ﾁｪｯｸは行なわない。
                        If pblnUseChangLoadKbn = True Then
                        
        '@R4-14では自動起票(保全記録票選択⇒新規登録の場合)の重複ﾁｪｯｸは行なわない
        '                    '@親画面の列番号を格納
        '                    llngWpNameColNo = CMlngCM00Z1vsfPreColWpName                '装置名
        '                    llngStartDateColNo = CMlngCM00Z1vsfPreColPreserveStartDate  '開始(予定)日時
        '                    llngEndDateColNo = CMlngCM00Z1vsfPreColPreserveEndDate      '終了(予定)日時
        '
        '                    '@ﾁｪｯｸ元ｺﾝﾄﾛｰﾙに"frmxxCM00Z1:保全記録票選択ﾌｫｰﾑ"を格納
        '                    Set lctlCheckItem = frmxxCM00Z1
                        Else
                            '@親画面の列番号を格納
                            llngWpNameColNo = CMlngvsfPreColWpName              '装置名
                            llngStartDateColNo = CMlngvsfPreColStartDate        '開始(予定)日時
                            llngEndDateColNo = CMlngvsfPreColEndDate            '終了(予定)日時

        '                    '@ﾁｪｯｸ元ｺﾝﾄﾛｰﾙに"frmxxEN01Z0:装置ﾒﾝﾃﾅﾝｽ記録票一覧ﾌｫｰﾑ"を格納
        '                    Set lctlCheckItem = frmxxEN01Z0

                            '@親画面ﾃﾞｰﾀと比較し重複ﾁｪｯｸ
                            With frmxxEN01Z0.Instance.vsfMainteList
                                For llngCnt = 1 To .Rows.Count - 1
                                    '@装置名と開始(予定)日時にてﾁｪｯｸを行う
                                    If .GetData(llngCnt, llngWpNameColNo) = cmbWp.Text And _
                                        .GetData(llngCnt, llngStartDateColNo) = lstrStartDate Then
                                        
                                        '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                                        lblnChkErrFlag = True
                                        Exit For
                                    End If
                                Next llngCnt
                            End With
                        End If
                        
        '                '@親画面ﾃﾞｰﾀと比較し重複ﾁｪｯｸ
        '                With frmxxEN01Z0.vsfMainteList
        '                    For llngCnt = 1 To .Rows - 1
        '                        '@装置名と開始(予定)日時にてﾁｪｯｸを行う
        '                        If .Cell(flexcpText, llngCnt, llngWpNameColNo) = cmbWP.Text And _
        '                            .Cell(flexcpText, llngCnt, llngStartDateColNo) = lstrStartDate Then
        '
        '                            '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
        '                            lblnChkErrFlag = True
        '                            Exit For
        '                        End If
        '                    Next llngCnt
        '                End With
                    End If
                
                
                    '@★ ﾓｰﾄﾞにより処理分岐 ★
                    '@　　※停止開始予定日の重複ﾁｪｯｸを行う①
                    Select Case ptypEqStopMenteRenkeiInfo.lngInsertMode
                        
                        '@〓 "1:新規"、"2:ｺﾋﾟｰ登録" 〓
                        Case CMlngInsertMode, CMlngCopyInsertMode
                            
                            '@親画面ﾃﾞｰﾀと比較し重複ﾁｪｯｸ
                            With frmxxEN01Z0.Instance.vsfMainteList
                                For llngCnt = 1 To .Rows.Count - 1
                                    '@装置名と開始(予定)日時にてﾁｪｯｸを行う
                                    If .GetData(llngCnt, llngWpNameColNo) = cmbWp.Text And _
                                        .GetData(llngCnt, llngStartDateColNo) = lstrStartDate Then
                                        
                                        '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                                        lblnChkErrFlag = True
                                        Exit For
                                    End If
                                Next llngCnt
                            End With
                        
                        
                        '@〓 "3:計画ﾃﾞｰﾀ修正" 〓
                        Case CMlngUpdateMode
                            
                            '@親画面ﾃﾞｰﾀと比較し重複ﾁｪｯｸ
                            With frmxxEN01Z0.Instance.vsfMainteList
                                For llngCnt = 1 To .Rows.Count - 1
                                    '@装置名と開始(予定)日時にてﾁｪｯｸを行う
                                    If .GetData(llngCnt, llngWpNameColNo) = cmbWp.Text And _
                                        .GetData(llngCnt, llngStartDateColNo) = lstrStartDate Then
            
                                        '@変更前ﾚｺｰﾄﾞの判定
                                        If .GetData(llngCnt, llngStartDateColNo) <> _
                                            ptypEqStopMenteRenkeiInfo.strWPStopStartOld Then
                                            '@変更前の開始(予定)日時以外の場合はｴﾗｰとする
                                            '@ (旧開始(予定)日時と新開始(予定)日時が同一の場合はOK)
                                            
                                            '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                                            lblnChkErrFlag = True
                                            Exit For
                                        End If
            
                                    End If
                                Next llngCnt
                            End With
                    End Select
                    
                    
                    '@**************************************
                    '@　停止期間の重複ﾁｪｯｸを行う②
                    '@　　※(排他の関係上、messvrでも同一ﾁｪｯｸをしている)
                    '@**************************************
                    
                    '@装置状態変更以外での起動か
                    '@　※保全記録票選択画面からの起動の場合は、R4-14では重複ﾁｪｯｸは行なわない。
                    If pblnUseChangLoadKbn = False Then
                    
                        '@親画面ﾃﾞｰﾀと比較し重複ﾁｪｯｸ
                        With frmxxEN01Z0.Instance.vsfMainteList
                            
                            For llngCnt = 1 To .Rows.Count - 1
                
                                '@装置名と開始(予定)日時、終了(予定)日時にてﾁｪｯｸを行う(修正時の場合は自ﾚｺｰﾄﾞ以外をﾁｪｯｸする)
                                If .GetData(llngCnt, llngWpNameColNo) = cmbWp.Text And _
                                    .GetData(llngCnt, llngStartDateColNo) <> lstrStartDate And _
                                    .GetData(llngCnt, llngStartDateColNo) <> ptypEqStopMenteRenkeiInfo.strWPStopStartOld Then
                
                                    '@新規の停止予定期間が既存停止期間中の場合
                                    If lstrStartDate >= .GetData(llngCnt, llngStartDateColNo) And _
                                        lstrEndDate <= .GetData(llngCnt, llngEndDateColNo) Then
                                        
                                        '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                                        lblnChkErrFlag = True
                                        Exit For
                                    End If
                                    
                                    '@新規の停止予定期間が既存停止期間中を包含する場合
                                    If lstrStartDate <= .GetData(llngCnt, llngStartDateColNo) And _
                                        lstrEndDate >= .GetData(llngCnt, llngEndDateColNo) Then
                                        
                                        '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                                        lblnChkErrFlag = True
                                        Exit For
                                    End If
                                    
                                    '@新規の停止予定期間が既存の開始(予定)日時を跨ぐ場合
                                    If lstrStartDate <= .GetData(llngCnt, llngStartDateColNo) And _
                                        lstrEndDate >= .GetData(llngCnt, llngStartDateColNo) Then
                                        
                                        '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                                        lblnChkErrFlag = True
                                        Exit For
                                    End If
                                    
                                    '@新規の停止予定期間が既存の終了(予定)日時を跨ぐ場合
                                    If lstrStartDate <= .GetData(llngCnt, llngEndDateColNo) And _
                                        lstrEndDate >= .GetData(llngCnt, llngEndDateColNo) Then
                                        
                                        '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                                        lblnChkErrFlag = True
                                        Exit For
                                    End If
                                End If
                            Next llngCnt
                        End With
                    End If
                End If
            End If

            '@保全記録の場合は、保全ｶﾃｺﾞﾘもﾁｪｯｸ
            If plngLoadClass = CPlngNumTwo Then
                
                '@保全ｶﾃｺﾞﾘが選択されているか
                If cmbPreserveCategory.Text = vbNullString Then
                    '@ｴﾗｰﾌﾗｸﾞを"True：ｴﾗｰあり"に設定
                    lblnChkErrFlag = True
                End If
            End If

            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞが"False：ｴﾗｰなし"か
            If lblnChkErrFlag = False Then
                '@確定ﾎﾞﾀﾝを有効にする
                cmdRegist.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If
            
            '@ﾓｰﾄﾞが"1:新規登録"or"2:ｺﾋﾟｰ登録"か
            If ptypEqStopMenteRenkeiInfo.lngInsertMode < CMlngUpdateMode Then
                '@全部取消ﾎﾞﾀﾝを有効にする
                cmdAllClear.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdRegistControl_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/15 (Tue) 15:39:51 N.Kojima **************************************************

    '@↓2008/01/28 (Mon) 10:42:22 N.Kojima **************************************************
    '関数名：prvEndDateCalc_Proc
    '機　能：終了(予定)日時の計算処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/28 (Mon) 10:42:22 N.Kojima
    '更新日：2008/01/28 (Mon) 10:42:22
    '備　考：
    Private Sub prvEndDateCalc_Proc()

        Dim lstrStartDate           As String           '開始(予定)日時退避用
        Dim lstrEndDate             As String           '終了(予定)日時退避用
        Dim ldblStopMinute          As Double           '停止時間(分)
        
        Try

            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟ"か
            If mblnEventSkipFlag = False Then
                Exit Sub
            End If

            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを"False:ｽｷｯﾌﾟ"に設定
            mblnEventSkipFlag = False
            
            '@***************************************
            '@　終了(予定)日時を設定する
            '@***************************************

            '@--------------------------------
            '@　開始(予定)日時を日付変換する
            '@--------------------------------
            '@開始(予定)日時の日付と時間が定義日付型か("XXXX/XX/XX","XX:XX")
            If IsDate(calStartDate.Value) = True Then
                If IsDate(medStartTime.Text) = True Then
                
                    '@開始予定時間が設定済み
                    lstrStartDate = Format$(CDate(calStartDate.Value & Space(1) & medStartTime.Text), CPstrDateTimeYMDHM)
                Else
                    '@開始予定時間が未設定の場合は"00:00"として扱う
                    lstrStartDate = Format$(CDate(calStartDate.Value & Space(1) & CPstrTimeFormat0H0M), CPstrDateTimeYMDHM)
                End If
            Else
                lstrStartDate = vbNullString
            End If
            
            '@停止時間が数値か
            If IsNumeric(txtStopTime.Text) = True Then
            
                '@停止時間を分に変換する
                ldblStopMinute = Fix(txtStopTime.Text * CMlngMinute60)
            Else
                ldblStopMinute = 0
            End If
            
            '@--------------------------------
            '@　終了(予定)日時に停止時間を加算し、表示する
            '@--------------------------------
            '@終了(予定)日時を計算するべきか判定(終了(予定)日時が定義日付型 and 停止時間が0分以上の場合)
            If IsDate(lstrStartDate) = True And ldblStopMinute > 0 Then
                
                '@終了(予定)日時を計算する
                lstrEndDate = DateAdd(CMstrDatediffMinute, ldblStopMinute, lstrStartDate)
                
                '@終了(予定)日時の範囲を確認する(1900年～2100年)
                If pubblnYearRange_Chk(calStartDate.Value) = True Then
                    '@終了(予定)日時を設定する
                    calEndDate.Value = Format$(CDate(lstrEndDate), CPstrDateTimeYMD)
                    medEndTime.Text = Format$(CDate(lstrEndDate), CPstrTimeFormatHM)
                Else
                    '@終了(予定)日時をｸﾘｱする
                    calEndDate.Value = CPstrNullDate
                    medEndTime.Text = CPstrNullTime
                    '@終了(予定)日時を再ｸﾘｱする(※何故かNullにすると"____/__/__"になるよ？)
                    calEndDate.Value = vbNullString
                End If
            Else
                '@終了(予定)日時をｸﾘｱする
                calEndDate.Value = CPstrNullDate        '年月日
                medEndTime.Text = CPstrNullTime         '時間
                
                '@終了(予定)日時を再ｸﾘｱする(※何故かNullにすると"____/__/__"になるよ？)
                calEndDate.Value = vbNullString
            End If

            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞの初期化
            mblnEventSkipFlag = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvEndDateCalc_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/28 (Mon) 10:42:22 N.Kojima **************************************************

    '@↓2008/01/28 (Mon) 10:42:22 N.Kojima **************************************************
    '関数名：prvStopTimeCalc_Proc
    '機　能：停止時間の計算処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/28 (Mon) 10:42:22 N.Kojima
    '更新日：2008/01/28 (Mon) 10:42:22
    '備　考：
    Private Sub prvStopTimeCalc_Proc()

        Dim lstrStartDate           As String           '開始(予定)日時退避用
        Dim lstrEndDate             As String           '終了(予定)日時退避用
        Dim ldblStopMinute          As Double           '停止時間(分)
        Dim lcurSropHour            As Decimal          '時間間隔(時間)少数点
        
        Try

            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟ"か
            If mblnEventSkipFlag = False Then
                Exit Sub
            End If

            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを"False:ｽｷｯﾌﾟ"に設定
            mblnEventSkipFlag = False
            
            '@***************************************
            '@　停止時間を設定する
            '@***************************************

            '@--------------------------------
            '@　開始(予定)日時を日付変換する
            '@--------------------------------
            '@開始(予定)日時の日付と時間が定義日付型か("XXXX/XX/XX","XX:XX")
            If IsDate(calStartDate.Value) = True Then
                If IsDate(medStartTime.Text) = True Then
                
                    '@開始予定時間が設定済み
                    lstrStartDate = Format$(CDate(calStartDate.Value & Space(1) & medStartTime.Text), CPstrDateTimeYMDHM)
                Else
                    '@開始予定時間が未設定の場合は"00:00"として扱う
                    lstrStartDate = Format$(CDate(calStartDate.Value & Space(1) & CPstrTimeFormat0H0M), CPstrDateTimeYMDHM)
                End If
            Else
                lstrStartDate = vbNullString
            End If
            
            '@--------------------------------
            '@　終了(予定)日時を日付変換する
            '@--------------------------------
            '@終了(予定)日時の日付と時間が定義日付型か
            If IsDate(calEndDate.Value) = True Then
                If IsDate(medEndTime.Text) = True Then
                    
                    '@終了(予定)時間が設定済み
                    lstrEndDate = Format$(CDate(calEndDate.Value & Space(1) & medEndTime.Text), CPstrDateTimeYMDHM)
                Else
                    '@終了(予定)時間が未設定の場合は"00:00"として扱う
                    lstrEndDate = Format$(CDate(calEndDate.Value & Space(1) & CPstrTimeFormat0H0M), CPstrDateTimeYMDHM)
                End If
            Else
                lstrEndDate = vbNullString
            End If
            
            '@--------------------------------
            '@　終了(予定)日時から停止時間を算出する
            '@--------------------------------
            '@停止時間を計算するべきか判定(開始/終了(予定)日時が定義日付型 and 開始(予定)日時が終了(予定)日時以下の場合)
            If (IsDate(lstrStartDate) = True And IsDate(lstrEndDate) = True) And _
                (lstrStartDate <= lstrEndDate) Then
                
                '@開始～終了までの時間間隔(分単位)を算出する
                ldblStopMinute = DateDiff(CMstrDatediffMinute, lstrStartDate, lstrEndDate)
                '@時間へ変換する(少数第2位迄算出する為に100倍し、切捨て後100で割る)
                lcurSropHour = Fix(ldblStopMinute / CMlngMinute60 * 100) / 100
                
                '@停止時間の最大値確認
                If lcurSropHour > CMcurStopTimeMax Then
                    
                    '@停止時間を最大値設定する(99,999.99)※２回連続設定
                    txtStopTime.Text = Format$(CMcurStopTimeMax, CPstrDoubleFormat2String)
                Else
                    '@停止時間を設定する(#,##0.00)
                    txtStopTime.Text = Format$(lcurSropHour, CPstrDoubleFormat2String)
                End If
                
                '@停止時間に含まれているｶﾝﾏが、停止時間の先頭にあるか(NGﾊﾟﾀｰﾝ)
                If InStr(txtStopTime.Text, CPstrComma) <= 0 Then
                    txtStopTime.Text = Format$(CDec(txtStopTime.Text), CPstrDoubleFormat2String)
                End If
                
                '@終了(予定)日時(時間)が"__:__"か
                If medEndTime.Text = CPstrNullTime Then
                    '@"00:00"をｾｯﾄする
                    medEndTime.Text = CPstrDayStartTime
                End If
            Else
                '@停止時間を未設定する
                txtStopTime.Text = Format$(CMcurStopTimeMin, CPstrDoubleFormat2String)    '0.00
            End If

            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞの初期化
            mblnEventSkipFlag = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvStopTimeCalc_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/28 (Mon) 10:42:22 N.Kojima **************************************************

    '@↓2008/01/31 (Thu) 16:26:07 N.Kojima **************************************************
    '関数名：prvMainteReport_Disp
    '機　能：装置ﾒﾝﾃﾅﾝｽ記録票画面起動処理
    '引　数：lstrFunctionKey   ：起動機能ID
    '戻り値：True：正常、False：異常
    '作成日：2008/01/31 (Thu) 16:25:55 N.Kojima
    '更新日：2008/01/31 (Thu) 16:25:55
    '備　考：
    Public Function prvMainteReport_Disp(ByVal lstrFunctionKey As String) As Boolean

        Dim ltypRepairInfo          As RepairInfo       '故障修理記録票用構造体初期化用
        Dim ltypPreserveInfo        As PreserveInfo     '保全記録票用構造体初期化用

        Try

            '@戻り値の初期化
            prvMainteReport_Disp = False

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　装置ﾒﾝﾃﾅﾝｽ記録票画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00Z0.Instance = New frmxxCM00Z0()
            
            '@Form_Loadﾌﾗｸﾞが異常か
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                frmxxCM00Z0.Instance = Nothing
                
                Exit Function
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　装置ﾒﾝﾃﾅﾝｽ記録票画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00Z0.Instance.ShowDialog(Me)
            frmxxCM00Z0.Instance = Nothing
            
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            ptypRepairInfo = ltypRepairInfo
            ptypPreserveInfo = ltypPreserveInfo
            
            '@戻り値にTrue(=正常終了)を設定
            prvMainteReport_Disp = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = lstrFunctionKey
                .strProcName = "prvMainteReport_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function
    '@↑2008/01/31 (Thu) 16:26:07 N.Kojima **************************************************

    '@↓2008/03/03 (Mon) 10:18:05 N.Kojima **************************************************
    '関数名：prvInputItemChk_Proc
    '機　能：入力ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2008/03/03 (Mon) 10:18:20 N.Kojima
    '更新日：2008/04/15 (Tue) 15:31:27 N.Kojima
    '備　考：
    '　　　：2008/04/15 (Tue) 15:31:27 N.Kojima     開始(予定)日時、終了(予定)日時の過去日付ﾁｪｯｸをｺﾒﾝﾄｱｳﾄ。(案件№02811)
    Public Function prvInputItemChk_Proc() As Boolean

        Dim lstrNowDT               As String               '現在日時格納用
        Dim lstrStartDate           As String               '開始(予定)日時格納用
        Dim lstrEndDate             As String               '終了(予定)日時格納用
        Dim lblnErrFlag             As Boolean              'ｴﾗｰﾌﾗｸﾞ(True:ｴﾗｰあり、False:ｴﾗｰなし)

        Try

            '@戻り値の初期化
            prvInputItemChk_Proc = False
            
            '@ｴﾗｰﾌﾗｸﾞの初期化
            lblnErrFlag = False

            '@****************************************************
            '@　共通ﾁｪｯｸ項目(装置名)
            '@****************************************************
            '@装置名が選択されているか
            If cmbWp.Text = vbNullString Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, lblWpTitle.Text)
                '@"<TRM0WW>$$[装置]が設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                '@装置にﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbWp)
                Exit Function
            End If
            

            '@****************************************************
            '@　共通ﾁｪｯｸ項目(開始(予定)日時(年月日))
            '@****************************************************
            '@開始(予定)日時が入力されているか
            If calStartDate.Value <> CPstrNullDate Then
                
                '@開始(予定)日時の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(calStartDate.Value) = False Then
                    '@開始(予定)日時が無効な日付の場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                    lblnErrFlag = True
                Else
                    '@開始(予定)日時が入力されていて、かつ日付が有効な場合
                        
                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                        
                    '@★ 起動区分により処理分岐 ★
                    Select Case plngLoadClass
                        
                        '@〓 "1:故障修理記録" 〓
                        Case CPlngNumOne
                        
                            '@未来日付の場合
                            If Format$(CDate(calStartDate.Value), CPstrDateTimeYMD) > lstrNowDT Then
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                                '@"未来日付は指定できません。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                   
                                '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                                lblnErrFlag = True
                            End If
                            
        '@↓2008/04/15 (Tue) 15:31:19 N.Kojima **************************************************
        '@R5-1にて一旦ｺﾒﾝﾄｱｳﾄ(装置状態の運用が決まれば復活の可能性あり)
        '                '@〓 "2:保全記録" 〓
        '                Case CPlngNumTwo
        '
        '                    '@開始(予定)日時が過去日付か
        '                    If Format$(calStartDate.Value, CPstrDateTimeYMD) < lstrNowDT Then
        '
        '                        '@表示ﾒｯｾｰｼﾞ変換
        '                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
        '                        '@"過去日付は指定できません。"
        '                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN01Z1.Caption, True, 16)
        '
        '                        '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
        '                        lblnErrFlag = True
        '                    End If
        '@↑2008/04/15 (Tue) 15:31:19 N.Kojima **************************************************
                        
                    End Select
                    
                    '@ｴﾗｰﾌﾗｸﾞが"True:ｴﾗｰあり"か
                    If lblnErrFlag = True Then
                    
                        '@開始(予定)日時(年月日)へｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(calStartDate)
                        Exit Function
                    End If
                    
                    '@起動区分が"0:装置停止・ﾒﾝﾃ計画"、"2:保全記録"か
                    If plngLoadClass <> CPlngNumOne Then
                    
                        '@開始(予定)日時 < 終了(予定)日時か
                        If Format$(CDate(calStartDate.Value), CPstrDateTimeYMD) > Format$(CDate(calEndDate.Value), CPstrDateTimeYMD) Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                            '@"<TRM2HW>$$開始日が終了日より大きくなっています。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                            lblnErrFlag = True
                        End If
                    End If
                End If
            Else
                '@開始(予定)日時(年月日)がNULL(____/__/__)の場合
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, lblStartDateTitle.Text)
                '@"<TRM0WW>$$[開始(予定)日時]が設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                lblnErrFlag = True
            End If
            
            '@ｴﾗｰﾌﾗｸﾞが"True:ｴﾗｰあり"か
            If lblnErrFlag = True Then
            
                '@開始(予定)日時(年月日)へｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(calStartDate)
                Exit Function
            End If
            
            
            '@****************************************************
            '@　共通ﾁｪｯｸ項目(開始(予定)日時(時間))
            '@****************************************************
            '@開始(予定)日時(時間)が"__:__"以外か
            If medStartTime.Text <> CPstrNullTime Then
            
                '@時間の有効性ﾁｪｯｸ
                If IsDate(medStartTime.Text) = False Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003C)
                    '@"<TRM3CW>$$時刻の設定が正しくありません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                    lblnErrFlag = True
                Else
                    '@時間が有効な場合
                        
                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMDHM)
                    
                    '@入力された開始(予定)日時(年月日+時間)と終了(予定)日時(年月日+時間)を格納
                    lstrStartDate = calStartDate.Value & CPstrSpace & medStartTime.Text
                    lstrEndDate = calEndDate.Value & CPstrSpace & medEndTime.Text
                        
                    '@★ 起動区分により処理分岐 ★
                    Select Case plngLoadClass
                        
                        '@〓 "1:故障修理記録" 〓
                        Case CPlngNumOne
                        
                            '@開始(予定)日時(年月日+時間)が未来日付の場合
                            If Format$(CDate(lstrStartDate), CPstrDateTimeYMDHM) > lstrNowDT Then
                            
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                                '@"未来日付は指定できません。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                   
                                '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                                lblnErrFlag = True
                            End If
                            
        '@↓2008/04/15 (Tue) 15:31:13 N.Kojima **************************************************
        '@R5-1にて一旦ｺﾒﾝﾄｱｳﾄ(装置状態の運用が決まれば復活の可能性あり)
        '                '@〓 "2:保全記録" 〓
        '                Case CPlngNumTwo
        '
        '                    '@保全記録票選択画面以外からの起動か
        '                    If pblnUseChangLoadKbn = False Then
        '
        '                        '@開始(予定)日時(年月日+時間)が過去日付か
        '                        If Format$(lstrStartDate, CPstrDateTimeYMDHM) < lstrNowDT Then
        '
        '                            '@表示ﾒｯｾｰｼﾞ変換
        '                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
        '                            '@"過去日付は指定できません。"
        '                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN01Z1.Caption, True, 16)
        '
        '                            '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
        '                            lblnErrFlag = True
        '                        End If
        '                    End If
        '@↑2008/04/15 (Tue) 15:31:13 N.Kojima **************************************************
                            
                    End Select

                    '@ｴﾗｰﾌﾗｸﾞが"True:ｴﾗｰあり"か
                    If lblnErrFlag = True Then
                    
                        '@開始(予定)日時(時間)へｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(medStartTime)
                        Exit Function
                    End If

                    '@起動区分が"0:装置停止・ﾒﾝﾃ計画"、"2:保全記録"か
                    If plngLoadClass <> CPlngNumOne Then
                        
                        '@開始(予定)日時(年月日+時間) < 終了(予定)日時(年月日+時間)か
                        If Format$(CDate(lstrStartDate), CPstrDateTimeYMDHM) > Format$(CDate(lstrEndDate), CPstrDateTimeYMDHM) Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                            '@"<TRM2HW>$$開始日が終了日より大きくなっています。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                            lblnErrFlag = True
                        End If
                    End If
                End If
            Else
                '@開始(予定)日時(時間)がNULL(__：__)の場合
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, lblStartDateTitle.Text)
                '@"<TRM0WW>$$[開始(予定)日時]が設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                lblnErrFlag = True
            End If
            
            '@ｴﾗｰﾌﾗｸﾞが"True:ｴﾗｰあり"か
            If lblnErrFlag = True Then
            
                '@開始(予定)日時(時間)へｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(medStartTime)
                Exit Function
            End If
            
            
            '@****************************************************
            '@　装置停止・ﾒﾝﾃ計画、保全記録共通ﾁｪｯｸ項目(終了(予定)日時(年月日))
            '@****************************************************
            '@起動区分が"1:故障修理記録"以外か
            If plngLoadClass <> CPlngNumOne Then

                '@終了(予定)日時が入力されているか
                If calEndDate.Value <> CPstrNullDate Then
                    
                    '@終了(予定)日時の有効性ﾁｪｯｸ
                    If pubblnYearRange_Chk(calEndDate.Value) = False Then
                        '@終了(予定)日時が無効な日付の場合
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                        '@"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                        lblnErrFlag = True
                    Else
                        '@日付が有効な場合
                    
                        '@現在日付取得(年月日)
                        lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                        
        '@↓2008/04/15 (Tue) 15:31:06 N.Kojima **************************************************
        '@R5-1にて一旦ｺﾒﾝﾄｱｳﾄ(装置状態の運用が決まれば復活の可能性あり)
        '                '@起動区分が"2:保全記録"か
        '                If plngLoadClass = CPlngNumTwo Then
        '
        '                    '@終了(予定)日時が過去日付か
        '                    If Format$(calEndDate.Value, CPstrDateTimeYMD) < lstrNowDT Then
        '
        '                        '@ﾓｰﾄﾞが"3:実績ﾃﾞｰﾀ修正"以外、"5:実績ﾃﾞｰﾀ修正"以外か
        '                        If ptypEqStopMenteRenkeiInfo.lngInsertMode <> CMlngResultUpdateMode And _
        '                            ptypEqStopMenteRenkeiInfo.lngInsertMode <> CMlngUpdateMode Then
        '
        '                            '@表示ﾒｯｾｰｼﾞ変換
        '                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
        '                            '@"過去日付は指定できません。"
        '                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN01Z1.Caption, True, 16)
        '
        '                            '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
        '                            lblnErrFlag = True
        '                        End If
        '                    End If
        '                End If
        '@↑2008/04/15 (Tue) 15:31:06 N.Kojima **************************************************
                        
                        '@開始(予定)日時がNULL以外で、かつ「開始(予定)日時 < 終了(予定)日時」か
                        If Format$(CDate(calStartDate.Value), CPstrDateTimeYMD) > Format$(CDate(calEndDate.Value), CPstrDateTimeYMD) And _
                            calStartDate.Value <> CPstrNullDate Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002I)
                            '@"<TRM2IW>$$開始日より過去の日付は指定できません。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                            lblnErrFlag = True
                        End If
                    End If
                Else
                    '@終了(予定)日時(年月日)がNULL(____/__/__)の場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, lblEndDateTitle.Text)
                    '@"<TRM0WW>$$[終了(予定)日時]が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                    lblnErrFlag = True
                End If

                '@ｴﾗｰﾌﾗｸﾞが"True:ｴﾗｰあり"か
                If lblnErrFlag = True Then
                
                    '@終了(予定)日時(年月日)へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(calEndDate)
                    Exit Function
                End If

                
                '@****************************************************
                '@　装置停止・ﾒﾝﾃ計画、保全記録共通ﾁｪｯｸ項目(終了(予定)日時(時間))
                '@****************************************************
                '@終了(予定)日時(時間)が"__:__"以外か
                If medEndTime.Text <> CPstrNullTime Then
                
                    '@時間の有効性ﾁｪｯｸ
                    If IsDate(medEndTime.Text) = False Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003C)
                        '@"<TRM3CW>$$時刻の設定が正しくありません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                        lblnErrFlag = True
                    Else
                        '@時間が有効な場合
                            
                        '@現在日付取得
                        lstrNowDT = Format$(Now, CPstrDateTimeYMDHM)
                        
                        '@入力された開始(予定)日時(年月日+時間)と終了(予定)日時(年月日+時間)を格納
                        lstrStartDate = calStartDate.Value & CPstrSpace & medStartTime.Text
                        lstrEndDate = calEndDate.Value & CPstrSpace & medEndTime.Text
                            
        '@↓2008/04/15 (Tue) 15:31:00 N.Kojima **************************************************
        '@R5-1にて一旦ｺﾒﾝﾄｱｳﾄ(装置状態の運用が決まれば復活の可能性あり)
        '                '@起動区分が"2:保全記録"か
        '                If plngLoadClass = CPlngNumTwo Then
        '
        '                    '@終了(予定)日時が過去日付か
        '                    If Format$(lstrEndDate, CPstrDateTimeYMDHM) < lstrNowDT Then
        '
        '                        '@表示ﾒｯｾｰｼﾞ変換
        '                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
        '                        '@"過去日付は指定できません。"
        '                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN01Z1.Caption, True, 16)
        '
        '                        '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
        '                        lblnErrFlag = True
        '                    End If
        '                End If
        '@↑2008/04/15 (Tue) 15:31:00 N.Kojima **************************************************

                        '@ｴﾗｰﾌﾗｸﾞが"True:ｴﾗｰあり"か
                        If lblnErrFlag = True Then
                        
                            '@終了(予定)日時(時間)へｾｯﾄﾌｫｰｶｽ
                            Call pubSetFocus(medEndTime)
                            Exit Function
                        End If

                        '@開始(予定)日時 < 終了(予定)日時か
                        If Format$(CDate(lstrStartDate), CPstrDateTimeYMDHM) > Format$(CDate(lstrEndDate), CPstrDateTimeYMDHM) Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                            '@"<TRM2HW>$$開始日が終了日より大きくなっています。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                            lblnErrFlag = True
                        End If
                    End If
                Else
                    '@終了(予定)日時(時間)がNULL(____/__/__)の場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, lblEndDateTitle.Text)
                    '@"<TRM0WW>$$[終了(予定)日時]が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    '@ｴﾗｰﾌﾗｸﾞを"True:ｴﾗｰあり"にｾｯﾄ
                    lblnErrFlag = True
                End If
                
                '@ｴﾗｰﾌﾗｸﾞが"True:ｴﾗｰあり"か
                If lblnErrFlag = True Then
                
                    '@終了(予定)日時(時間)へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(medEndTime)
                    Exit Function
                End If
                
                
                '@****************************************************
                '@　保全記録ﾁｪｯｸ項目(ｶﾃｺﾞﾘ)
                '@****************************************************
                '@起動区分が"2:保全記録"か
                If plngLoadClass = CPlngNumTwo Then
                    
                    '@保全ｶﾃｺﾞﾘがNULLか
                    If cmbPreserveCategory.Text = vbNullString Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, lblPreserveCategoryTitle.Text)
                        '@"<TRM0WW>$$[保全カテゴリ]が設定されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                        '@保全ｶﾃｺﾞﾘにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbPreserveCategory)
                        Exit Function
                    End If
                End If
            End If
            
            '@戻り値に"True=ﾁｪｯｸOK"設定
            prvInputItemChk_Proc = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrFormName
                .strProcName = "prvInputItemChk_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function
    '@↑2008/03/03 (Mon) 10:18:05 N.Kojima **************************************************


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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraMainteInfo.Paint

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
    Private Sub textbox_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles medEndTime.Enter, medStartTime.Enter
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
    Private Sub textbox_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles medEndTime.Leave, medStartTime.Leave
        'NSYS マウス選択でのハイライトをキャンセルする
        sender.Tag("OnHighlight") = False
    End Sub

    '関数名：textbox_KeyUp
    '機　能：ハイライト処理用 キーアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles medEndTime.KeyUp, medStartTime.KeyUp
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
    Private Sub textbox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medEndTime.MouseDown, medStartTime.MouseDown
        'NSYS MouseDown時のカーソル位置を保持
        sender.Tag("MouseDownStart") = sender.SelectionStart
    End Sub

    '関数名：textbox_MouseUp
    '機　能：ハイライト処理用 マウスアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medEndTime.MouseUp, medStartTime.MouseUp
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
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
                                                                        cmdNowDate.Enter, 
                                                                        calStartDate.Enter,
                                                                        medStartTime.Enter,
                                                                        cmdCommentDown.Enter,
                                                                        cmdCommentUp.Enter,
                                                                        cmdClose.Enter,
                                                                        cmdRegist.Enter,
                                                                        txtStopTime.Enter,
                                                                        medEndTime.Enter,
                                                                        calEndDate.Enter,
                                                                        cmbPreserveCategory.Enter,
                                                                        cmdAllClear.Enter,
                                                                        cmbMcGroup.Enter,
                                                                        cmbWP.Enter,
                                                                        txtComment.Enter
                             

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name,cmdNowDate.Name,cmdAllClear.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

    Private Sub txtStopTime_Enter(sender As Object, e As EventArgs) Handles txtStopTime.Enter

        Call txtStopTime_Change(txtStopTime,New EventArgs)

    End Sub

End Class
