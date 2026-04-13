'ﾌｧｲﾙ名：xxEN0230.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：部材管理ﾒｲﾝﾌｫｰﾑ
'作成日：2004/05/06 (Thu) 16:05:39 Y.Yamagishi
'更新日：2011/12/26 (Mon) 14:06:51 T.Oide
'備　考：
'　　　：2005/04/18 (Mon) 11:34:48 S.Deguchi    不具合№688の対応でﾒｯｾｰｼﾞ変更の修正(inv_.cngstateにTag追加＜Null＞)
'　　　：2007/08/22 (Wed) 10:50:54 N.Kasai      ｿｰｽ整備
'　　　：2011/12/26 (Mon) 14:06:51 T.Oide       REQ-1115 払出、不良の区分け
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0230
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0230    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0230
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0230
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0230)
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
    '====================================Private============================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2012/01/24 (Tue) 11:37:32 T.Oide **************************************************
    'Private Const CMstrLocalVersion                     As String = "03.03"
    Private Const CMstrLocalVersion                     As String = "03.04"
    '@↑2012/01/24 (Tue) 11:37:32 T.Oide **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrinv_changstateVer                As String = "03.01"                 '部材状態変更
    Private Const CMstrinv_partlistVer                  As String = "02.00"                 '部材一覧取得
    Private Const CMstrmas_partlistVer                  As String = "03.00"                 '部材ﾘｽﾄ
    Private Const CMstrmas_reasoncodeVer                As String = "02.00"                 '理由ｺｰﾄﾞ取得
    Private Const CMstrmas_vendclasslistVer             As String = "02.00"                 'ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄ取得

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN0230          'ﾛｰｶﾙﾒﾆｭｰKey

    '@vsfPartLotListの定数宣言（ｶﾗﾑ）
    Private Const CMlngvsfPartLLColNo                   As Integer = 0                      '№
    Private Const CMlngvsfPartLLColStatus               As Integer = 1                      '状態
    Private Const CMlngvsfPartLLColLotID                As Integer = 2                      '在庫ID
    Private Const CMlngvsfPartLLColPrLotID              As Integer = 3                      '製造ﾛｯﾄID
    Private Const CMlngvsfPartLLColNum                  As Integer = 4                      '数量
    Private Const CMlngvsfPartLLColDate                 As Integer = 5                      '受入日時
    Private Const CMlngvsfPartLLColEmpID                As Integer = 6                      '受入担当
    Private Const CMlngvsfPartLLColCFLotID              As Integer = 7                      '出荷ﾛｯﾄID
    Private Const CMlngvsfPartLLColBoardThickness       As Integer = 8                      '板厚
    Private Const CMlngvsfPartLLColReworkCount          As Integer = 9                      'ﾘﾜｰｸ回数
    Private Const CMlngvsfPartLLColWKLotLastUpdate      As Integer = 10                     '最終更新日時(非表示)
    Private Const CMlngvsfPartLLColWKReasonCode         As Integer = 11                     '理由ｺｰﾄﾞ(非表示)
    Private Const CMlngvsfPartLLColWKReasonCodeName     As Integer = 12                     '理由名称(非表示)

    '@vsfPartLotListの定数宣言（幅）
    Private Const CMlngvsfPartLLColWNo                  As Integer = 40                     '№
    Private Const CMlngvsfPartLLColWStatus              As Integer = 27                     '状態
    Private Const CMlngvsfPartLLColWBoardThickness      As Integer = 53                     '板厚
    Private Const CMlngvsfPartLLColWRegeneration        As Integer = 53                     'ﾘﾜｰｸ回数
    Private Const CMlngvsfPartLLColWWKLotLastUpdate     As Integer = 38                     '最終更新日時(非表示)
    Private Const CMlngvsfPartLLColWWKReasonCode        As Integer = 38                     '理由ｺｰﾄﾞ(非表示)
    Private Const CMlngvsfPartLLColWWKReasonCodeName    As Integer = 38                     '理由名称(非表示)

    '@vsfPartLotListの定数宣言（幅）：1A0
    Private Const CMlngvsfPartLL1A0ColWLotID            As Integer = 153                    '在庫ID
    Private Const CMlngvsfPartLL1A0ColWPrLotID          As Integer = 153                    '製造ﾛｯﾄID
    Private Const CMlngvsfPartLL1A0ColWNum              As Integer = 153                    '数量
    Private Const CMlngvsfPartLL1A0ColWDate             As Integer = 187                    '受入日時
    Private Const CMlngvsfPartLL1A0ColWEmpID            As Integer = 144                    '受入担当
    Private Const CMlngvsfPartLL1A0ColWCFLotID          As Integer = 173                    '出荷ﾛｯﾄID(非表示)
    '@vsfPartLotListの定数宣言（幅）：2A0
    Private Const CMlngvsfPartLLColWLotID               As Integer = 113                    '在庫ID
    Private Const CMlngvsfPartLLColWPrLotID             As Integer = 113                    '製造ﾛｯﾄID
    Private Const CMlngvsfPartLLColWNum                 As Integer = 110                    '数量
    Private Const CMlngvsfPartLLColWDate                As Integer = 147                    '受入日時
    Private Const CMlngvsfPartLLColWEmpID               As Integer = 144                    '受入担当
    Private Const CMlngvsfPartLLColWCFLotID             As Integer = 113                    '出荷ﾛｯﾄID

    '@vsfPartLotListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrvsfPartLLColTNo                  As String = "№"                    '№
    Private Const CMstrvsfPartLLColTStatus              As String = ""                      '状態
    Private Const CMstrvsfPartLLColTLotID               As String = "在庫ID"                '在庫ID
    Private Const CMstrvsfPartLLColTPrLotID             As String = "製造ロットID"          '製造ﾛｯﾄID
    Private Const CMstrvsfPartLLColTNum                 As String = "数量"                  '数量
    Private Const CMstrvsfPartLLColTDate                As String = "受入日時"              '受入日時
    Private Const CMstrvsfPartLLColTEmpID               As String = "受入担当"              '受入担当
    Private Const CMstrvsfPartLLColTCFLotID             As String = "出荷ロットID"          '出荷ﾛｯﾄID
    Private Const CMstrvsfPartLLColTBoardThickness      As String = "板厚"                  '板厚
    Private Const CMstrvsfPartLLColTRegeneration        As String = "ﾘﾜｰｸ"                  'ﾘﾜｰｸ回数

    '@ｸﾞﾘｯﾄﾞ関連その他
    Private Const CMlngvsfPartLLRowTitle                As Integer = 0                      'ﾀｲﾄﾙ行（行）
    Private Const CMlngvsfPartLLColTitle                As Integer = 0                      'ﾀｲﾄﾙ行（列）
    Private Const CMlngvsfmlngSortCol                   As Integer = 0                      'ｿｰﾄ列初期値
    Private Const CMlngvsfmlngOrderCol                  As Integer = 0                      'ｿｰﾄ方法初期値
    Private Const CMlngvsfPartLLHFontSize               As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfPartLLHHeight                 As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfPartLLHeight                  As Integer = 18                     '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfCellPaintColorStart           As Integer = 0                      'ｾﾙの背景色塗りつぶし開始列

    '@部品種別Combo
    Private Const CMlngGetIDValueCol                    As Integer = 1                      'ID取得Col数

    '@部品Combo
    Private Const CMlngGetPartIDValueCol                As Integer = 0                      '部品ID取得Col数

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName                   As Integer = 1                      '名称列番
    Private Const CMlngCmbGridColID                     As Integer = 0                      'ID列番（非表示項目）
    Private Const CMlngCmbDispCols                      As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbDispCols2                     As Integer = 2                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                     As Integer = 18                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbHeight                        As Integer = 28                     '高さ
    Private Const CMlngCmbValueCol                      As Integer = 0                      '値取得列
    Private Const CMlngCmbGetCol                        As Integer = 2                      '値表示列
    Private Const CMlngCmbClearListIndex                As Integer = -1                     'ﾃｷｽﾄ値初期化
    Private Const CMlngCmbListIdx0                      As Integer = 0                      'ｺﾝﾎﾞのListIndex（0）
    Private Const CMlngCmbCnt1                          As Integer = 1                      'ｺﾝﾎﾞのList件数（1件）

    '@処理区分ｵﾌﾟｼｮﾝﾎﾞﾀﾝIndex
    '@↓2011/12/26 (Mon) 14:07:54 T.Oide **************************************************
    '@Private Const CMlngLotReceiveFlg                    As Long = 0                         '例外受入
    '@Private Const CMlngLotTakeFlg                       As Long = 1                         '払出
    '@Private Const CMlngLotHoldFlg                       As Long = 2                         '保留
    '@Private Const CMlngLotReleaseFlg                    As Long = 3                         '保留解除

    Private Const CMlngLotReceiveFlg                    As Integer = 0                      '例外受入
    Private Const CMlngLotScrapFlg                      As Integer = 1                      '不良
    Private Const CMlngLotTakeFlg                       As Integer = 2                      '払出
    Private Const CMlngLotHoldFlg                       As Integer = 3                      '保留
    Private Const CMlngLotReleaseFlg                    As Integer = 4                      '保留解除
    Private Const CMlngLotDivertFlg                     As Integer = 5                      '実験転用
    '@↑2011/12/26 (Mon) 14:07:54 T.Oide **************************************************

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow                       As Integer = 4                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@↓2012/01/19 (Thu) 16:54:45 T.Oide **************************************************
    '@部品種別設定用
    Private Const CMstrCFName                           As String = "対向基板"              '対向基板
    Private Const CMstrEN00B0FormName                   As String = "CFロット編成"          'CFロット編成
    '@↑2012/01/19 (Thu) 16:54:45 T.Oide **************************************************


    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtyppartlist                                As List (Of PartClassList)          '部品ﾘｽﾄ
    Private mtypMasReceiveItemList                      As MasItemList                      '「例外受入」理由ｺｰﾄﾞﾘｽﾄ
    '@↓2011/12/26 (Mon) 14:39:45 T.Oide **************************************************
    Private mtypMasScrapItemList                        As MasItemList                      '「不良」理由ｺｰﾄﾞﾘｽﾄ
    '@↑2011/12/26 (Mon) 14:39:45 T.Oide **************************************************
    Private mtypMasTakeItemList                         As MasItemList                      '「払出」理由ｺｰﾄﾞﾘｽﾄ
    Private mtypMasHoldItemList                         As MasItemList                      '「保留」理由ｺｰﾄﾞﾘｽﾄ
    Private mtypMasReleaseItemList                      As MasItemList                      '「保留解除」理由ｺｰﾄﾞﾘｽﾄ
    Private mstrLotEventID                              As String                           'ﾛｯﾄｲﾍﾞﾝﾄID
    Private mcurNum                                     As Long                             '受入数合計
    Private mlngSortCol                                 As Integer                          'ｿｰﾄ列格納
    Private mlngSortOrder                               As Integer                          'ｿｰﾄ方法格納
    Private mblncmbPartFlag                             As Boolean                          '部品変更ﾌﾗｸﾞ
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用
    Private mstrEventName                               As String                           'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
    Private mblnFormLoad1st                             As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ（Ture:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み）
    Private mblnLoadFlag                                As Boolean                          '起動ﾌﾗｸﾞﾛｰｶﾙ（True：起動、False：終了）
    Private mstrPartClass                               As String                           '部品種別退避領域
    Private mstrPart                                    As String                           '部品退避領域
    '@↓2011/12/26 (Mon) 14:48:17 T.Oide **************************************************
    Private mstrTaihiLotScrapSetID                      As String                           'ﾛｯﾄ情報取得時の不良項目ｾｯﾄID
    Private mblnCmbPartChangeEventCancelFlag            As Boolean                          'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
    '@↑2011/12/26 (Mon) 14:48:17 T.Oide **************************************************
    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ
    Private mbln1stFormLoad                             As Boolean                          'NSYS FormLoadフラグ
    Private mblnInvPartList                             As Boolean                          'NSYS 部材一覧取得成功/失敗ﾌﾗｸﾞ
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

        'NSYS 部材一覧取得成功/失敗ﾌﾗｸﾞ
        mblnInvPartList = True

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
    '作成日：2004/05/06 (Thu) 16:36:29 Y.Yamagishi
    '更新日：2006/05/11 (Thu) 13:25:19 M.Miura
    '備　考：2004/10/15 (Fri) 16:48:10 N.Kasai  ｿｰﾄ順保持機能追加
    '　　　：2006/05/11 (Thu) 13:25:19 M.Miura  不具合№3395 部品種別、部品ｺﾝﾎﾞ1件の場合は一覧表示する
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim ltypVenderlist      As VenderList           'ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄ
        
        Try
            
            '@Form_Loadﾌﾗｸﾞ（True：正常、False：異常）（初期化）
            mblnLoadFlag = False
            
            'NSYS FormLoadフラグ（Form_Load時のみTrue）
            mbln1stFormLoad= True
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@ﾌｫｰﾑ位置を設定
            Me.Top = 0
            Me.Left = 0 - My.Settings.FormOffset
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0230, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call prvfrmxxEN0230_Init(True)
            
            '@ﾛｯﾄ一覧の初期化(幅設定する)
            Call prvvsfPartLotList_Init()
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            mstrEventName = "Form_Load"
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@部品種別情報の取得【CPstrCD02：全て】
            lblnAns = pubblnVendClassList_Sel(CMstrmas_vendclasslistVer, CPstrCD02, ltypVenderlist)
            '@結果判定
            If lblnAns = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            End If
            
            '@「保留解除」理由情報取得処理【CPstrCD2X：理由ｺｰﾄﾞ取得(解除)】
            lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, CPstrCD2X, mtypMasReleaseItemList)
            '@結果判定
            If lblnAns = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            End If
            
            '@「例外受入」理由情報取得処理【CPstrCD2Y：理由ｺｰﾄﾞ取得(受入)】
            lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, CPstrCD2Y, mtypMasReceiveItemList)
            '@結果判定
            If lblnAns = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            End If
            
        '@↓2011/12/26 (Mon) 14:41:57 T.Oide **************************************************
            '@「不良」理由情報取得処理【CPstrCD4Q：理由ｺｰﾄﾞ取得(在庫不良)】
            lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, CPstrCD4Q, mtypMasScrapItemList)
            '@結果判定
            If lblnAns = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            End If
        '@↑2011/12/26 (Mon) 14:41:57 T.Oide **************************************************
            
            '@「払出」理由情報取得処理【CPstrCD2V：理由ｺｰﾄﾞ取得(払出)】
            lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, CPstrCD2V, mtypMasTakeItemList)
            '@結果判定
            If lblnAns = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            End If
            
            '@「保留」理由情報取得処理【CPstrCD2U：理由ｺｰﾄﾞ取得(保留)】
            lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, CPstrCD2U, mtypMasHoldItemList)
            '@結果判定
            If lblnAns = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            End If
            
            '@部品種別情報表示
            Call prvcmbPartClass_Disp(ltypVenderlist)
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, mstrEventName)

            
            '@ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ（True:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み）
            mblnFormLoad1st = True
            '@起動ﾌﾗｸﾞﾛｰｶﾙ初期化（True：起動、False：終了）
            mblnLoadFlag = True
            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True
            
            'NSYS FormLoadフラグ（Form_Load時のみTrue）
            mbln1stFormLoad= False

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"                  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/11 (Thu) 13:11:10 M.Miura
    '更新日：2012/01/19 (Thu) 16:38:45 T.Oide
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

    '@↓2012/01/20 (Fri) 13:07:08 T.Oide **************************************************
        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ
    '@↑2012/01/20 (Fri) 13:07:08 T.Oide **************************************************

        Try
            
            '@ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ（Ture:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み）
            '@初回ﾛｰﾄﾞのみ最新ﾛｯﾄ一覧を取得する。
            If mblnFormLoad1st = True Then
                '@画面起動中にｴﾗｰが発生した場合は最新取得を行わない。
                If mblnLoadFlag = True Then
                    '@ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ（Ture:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み）
                    mblnFormLoad1st = False
                    
                    '@制御をOSに渡す
                    '@ﾌｫｰﾑﾛｰﾄﾞ中の通信に負荷がかかった場合にﾌｫｰﾑに制御を渡す
                    '@ｲﾍﾞﾝﾄを抑止する為、ﾌｫｰﾑをﾛｯｸする。
                    'DoEvents
                    
                    '@Escﾎﾞﾀﾝを有効
                    '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
                    Me.CancelButton = cmdClose
                    
                    With ptypOnErrorInfo
                        '@ｴﾗｰ発生箇所の設定
                        .strErrPositionDetail = "⇔Form_Activate"
                        
                        With cmbPartClass
                            '@部品種別が1件の場合
                            If .ListCount = CMlngCmbCnt1 Then
                                '@部品種別を初期表示する
                                .ListIndex = CMlngCmbListIdx0
                                '@部品種別_Validate処理
                                RemoveHandler cmbPartClass.Validating, AddressOf cmbPartClass_Validate
                                Call cmbPartClass_Validate(cmbPartClass, New CancelEventArgs(True))
                                AddHandler cmbPartClass.Validating, AddressOf cmbPartClass_Validate
                            End If
                        End With
                        
                        '@ｴﾗｰ発生箇所の初期化
                        .strErrPositionDetail = vbNullString
                    End With
                End If
                
        '@↓2012/01/19 (Thu) 16:38:51 T.Oide **************************************************

                '@「CFﾛｯﾄ編成」から起動した場合は情報を初期表示する
                If ptypInvPart.strParentForm = CMstrEN00B0FormName Then
                
                    With ptypInvPart
                    
                        '@部品種別=対向基板選択
                        cmbPartClass.Text = CMstrCFName
                        
                        '@部品一覧を取得するためにcmbPartClass_CloseUpを呼ぶ
                        Call cmbPartClass_CloseUp(cmbPartClass, New EventArgs)
                        
                        '@部品=親ﾌｫｰﾑで選択中の部品を選択
                        llngCnt = 0
                        Do While cmbPart.ListCount > llngCnt
                            
                            '@ｺﾝﾎﾞの値変更
                            cmbPart.ListIndex = llngCnt
                            
                            'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞON(1回目はﾁｪﾝｼﾞｲﾍﾞﾝﾄが走って欲しいのでこの位置に入れる)
                            mblnCmbPartChangeEventCancelFlag = True
                            
                            '@同じ部品か
                            If cmbPart.Value = .strPartID Then
                                Exit Do
                            End If
                            llngCnt = llngCnt + 1
                        Loop
                        
                        '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞOFF
                        mblnCmbPartChangeEventCancelFlag = False
                                                            
                        '@部材情報取得(CloseUpを呼ぶ)
                        Call cmbPart_CloseUp(cmbPart, New EventArgs)
                        
                        '@ｸﾞﾘｯﾄﾞの一覧から選択中の在庫IDを選択
                        Call pubGridFocus_Set(vsfPartLotList, .strInvLotId, CMlngvsfPartLLColLotID, cmdClose)
                        
                    End With
                    
                    '不良をﾁｪｯｸONにする(理由一覧の入替えが入る)
                    optKubun1.Checked = True
                    
                End If
        '@↑2012/01/19 (Thu) 16:38:51 T.Oide **************************************************
                
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_Activate"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/05/07 (Fri) 12:49:54 Y.Yamagishi
    '更新日：2006/05/11 (Thu) 16:24:51 M.Miura
    '備　考：2006/05/11 (Thu) 16:24:51 M.Miura 部品種別ｺﾝﾎﾞでのEnter処理追加
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If
            
            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理判別
            Select Case ActiveControl.Name
                '@部品種別の場合
                Case cmbPartClass.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@部品種別Validate処理へ
                            RemoveHandler cmbPartClass.Validating, AddressOf cmbPartClass_Validate
                            Call cmbPartClass_Validate(cmbPartClass, New CancelEventArgs(True))
                            AddHandler cmbPartClass.Validating, AddressOf cmbPartClass_Validate
                            e.Handled = True
                        Case Else
                    End Select
                    
                '@部品種別の場合
                Case cmbPart.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@部品種別Validate処理へ
                            RemoveHandler cmbPart.Validating, AddressOf cmbPart_Validate
                            Call cmbPart_Validate(cmbPart, New CancelEventArgs(True))
                            AddHandler cmbPart.Validating, AddressOf cmbPart_Validate
                            e.Handled = True
                        Case Else
                    End Select
                    
                '@作業ﾒﾓの場合には処理抜け
                Case txtWorkMemo.Name
                    Exit Sub

                '@部品種別以外の場合
                Case Else
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@入力ﾁｪｯｸ
                            Call prvcmdRegist_Chk()
                            '@次項目へｾｯﾄﾌｫｰｶｽ
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
            End Select

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"               '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/05/06 (Thu) 16:47:29 Y.Yamagishi
    '更新日：2004/11/01 (Mon) 15:10:42 T.Kitagawa
    '備　考：2004/10/15 (Fri) 17:17:55 N.Kasai  ｿｰﾄ順保持構造体ｸﾘｱ追加
    '　　　：2004/11/01 (Mon) 15:10:42 T.Kitagawa　閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納
        
        Try
                        
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            mtypChgSort.typChgSortList = New List(Of ChgSortList)
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
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_QueryUnload"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 16:47:52 Y.Yamagishi
    '更新日：2004/05/06 (Thu) 16:47:52
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
            Call publngEnd_Proc(CPstrKeyEN0230, ltypCommonInfo)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 16:06:35 Y.Yamagishi
    '更新日：2011/12/27 (Tue) 11:31:05 T.Oide
    '備　考：2004/10/05 (Tue) 14:59:47 T.Kitagawa   変更時は変更在庫ﾛｯﾄを先頭行（TopRow）にはしない（不具合№200）
    '　　　：2005/03/31 (Thu) 14:10:06 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/04/18 (Mon) 11:34:48 S.Deguchi    不具合№688の対応でﾒｯｾｰｼﾞ変更の修正(inv_.cngstateにTag追加＜Null＞)
    '　　　：2005/06/22 (Wed) 10:31:56 S.Deguchi    不具合№837の対応で,ENTRY_TIMEに最終更新日をｾｯﾄ
    '　　　：2005/12/06 (Tue) 11:27:24 S.Deguchi    不具合№3306の対応で,全数払出処理時に処置欄を初期化する処理を追加
    '　　　：2011/12/27 (Tue) 11:31:05 T.Oide       REQ-1115 払出、不良の区分け対応
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypChangeStateList     As ChangeStateList      '部材状態変更構造体
        Dim ltypPartLotList         As List(Of PartLotList) '部材一覧取得情報格納
        Dim llngPartLotListCnt      As Integer              '部材一覧取得件数格納
        Dim lstrMsg                 As String               '変換後ﾒｯｾｰｼﾞ
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        
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
            
            '@画面入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@部品受入ﾃﾞｰﾀ格納
            With ltypChangeStateList
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                .strSbID = pstrSBID
                '@処理区分(33:部材払出処理/保留・保留解除では見ていないのでそのまま)
                .strClassDivison = CPstrCD33
                '@部品ID
                .strVenderClassId = cmbPartClass.Value
                '@在庫ﾛｯﾄID
                .strLotID = vsfPartLotList.GetData(vsfPartLotList.Row, CMlngvsfPartLLColLotID)
                '@ﾛｯﾄｲﾍﾞﾝﾄID
                .strLotEventId = mstrLotEventID
                '@変更ID
                cmbReason.ValueCol = 0
                .strReasonCode = cmbReason.Value
                '@数量ﾁｪｯｸ
                If txtNum.Text <> vbNullString Then
                    '@数量が空白以外の場合
                    .strNum = txtNum.Text
                Else
                    '@数量が空白の場合
                    .strNum = vbNullString
                End If
                '@ｺﾒﾝﾄﾁｪｯｸ
                If txtWorkMemo.Text <> vbNullString Then
                    '@ｺﾒﾝﾄが空白以外の場合
                    .strComments = txtWorkMemo.Text
                Else
                    '@ｺﾒﾝﾄが空白の場合
                    .strComments = vbNullString
                End If
                '@作業者ID
                .strEmpID = pstrUserID
                '@最終更新日
                .strLotLastUpdate = vsfPartLotList.GetData(vsfPartLotList.Row, CMlngvsfPartLLColWKLotLastUpdate)
                '@FWﾘｽﾄｶｳﾝﾄ
                .lngWfListCnt = 0
                '@保留期限
                .strHoldTermDate = vbNullString
                '@保留責任者
                .strHoldEmpID = vbNullString
                '@登録日時
                .strEntryTime = vsfPartLotList.GetData(vsfPartLotList.Row, CMlngvsfPartLLColWKLotLastUpdate)
            End With
            
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
            mstrEventName = "cmdRegist_Click"
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnInvChangState_Upd(CMstrinv_changstateVer, _
                                              ltypChangeStateList, _
                                              lstrGuidMsg, _
                                              lstrGuidMsgCode)
            '@結果取得
            If lblnAns = True Then
                
                '@ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ表示制御
                Call pubGuidMsg_Set(lstrGuidMsgCode, lstrGuidMsg, Me)
                
                '@成功ﾒｯｾｰｼﾞ表示
                cmbPart.ValueCol = CMlngGetPartIDValueCol
                
                '@初期化
                lstrMsg = vbNullString
                
                '@更新後ﾒｯｾｰｼﾞ表示
                Select Case True
                    '@処理区分が「例外受入」の場合
                    Case optKubun0.Checked = True
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@pubVsfInfo_Disp( "メッセージコード：<TRM42I>$$部材状態を変更しました。部品[%1] 在庫ID[%2] 処理区分[%3] 数量[%4]")
                        lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf0042, _
                                                       cmbPart.Value, _
                                                       vsfPartLotList.GetData(vsfPartLotList.Row, CMlngvsfPartLLColLotID), _
                                                       optKubun0.Text, _
                                                       txtNum.Text)

        '@↓2011/12/27 (Tue) 13:04:44 T.Oide **************************************************
                    '@処理区分が「不良」の場合
                    Case optKubun1.Checked = True
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@pubVsfInfo_Disp( "メッセージコード：<TRM42I>$$部材状態を変更しました。部品[%1] 在庫ID[%2] 処理区分[%3] 数量[%4]")
                        lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf0042, _
                                                       cmbPart.Value, _
                                                       vsfPartLotList.GetData(vsfPartLotList.Row, CMlngvsfPartLLColLotID), _
                                                       optKubun1.Text, _
                                                       txtNum.Text)
        '@↑2011/12/27 (Tue) 13:04:44 T.Oide **************************************************

                    '@処理区分が「払出」の場合
                    Case optKubun2.Checked = True
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@pubVsfInfo_Disp( "メッセージコード：<TRM42I>$$部材状態を変更しました。部品[%1] 在庫ID[%2] 処理区分[%3] 数量[%4]")
                        lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf0042, _
                                                       cmbPart.Value, _
                                                       vsfPartLotList.GetData(vsfPartLotList.Row, CMlngvsfPartLLColLotID), _
                                                       optKubun2.Text, _
                                                       txtNum.Text)
                    
                    '@処理区分が「保留」の場合
                    Case optKubun3.Checked = True
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@pubVsfInfo_Disp("メッセージコード：<TRM43I>$$部材状態を変更しました。部品[%1] 在庫ID[%2] 処理区分[%3]")
                        lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf0043, _
                                                       cmbPart.Value, _
                                                       vsfPartLotList.GetData(vsfPartLotList.Row, CMlngvsfPartLLColLotID), _
                                                       optKubun3.Text)
                    
                    '@処理区分が「保留解除」の場合
                    Case optKubun4.Checked = True
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@pubVsfInfo_Disp("メッセージコード：<TRM43I>$$部材状態を変更しました。部品[%1] 在庫ID[%2] 処理区分[%3]")
                        lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf0043, _
                                                       cmbPart.Value, _
                                                       vsfPartLotList.GetData(vsfPartLotList.Row, CMlngvsfPartLLColLotID), _
                                                       optKubun4.Text)
                End Select
                        
                '@上記ﾒｯｾｰｼﾞがある場合,ｽﾃｰﾀｽﾊﾞｰに表示
                If lstrMsg <> vbNullString Then
                    '@ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(lstrMsg)
                End If
                
                '@画面情報更新
                lblnAns = prvblnInvPartList_Sel(ltypPartLotList, llngPartLotListCnt)
                '@結果判定
                If lblnAns = True Then

                    '@部材一覧表示情報
                    Call prvvsfPartLotList_Disp(ltypPartLotList, llngPartLotListCnt)
                
                    '@行選択がされている場合か否かで処理分岐
                    If vsfPartLotList.Row <= 0 Then
                        '@区分ｵﾌﾟｼｮﾝﾎﾞﾀﾝ初期化
                        optKubun0.Checked = False      '例外受入
        '@↓2011/12/27 (Tue) 11:32:35 T.Oide **************************************************
                        optKubun1.Checked = False      '不良
        '@↑2011/12/27 (Tue) 11:32:35 T.Oide **************************************************
                        optKubun2.Checked = False      '払出
                        optKubun3.Checked = False      '保留
                        optKubun4.Checked = False      '保留解除
        '@↓2011/12/27 (Tue) 11:32:26 T.Oide **************************************************
                        optKubun5.Checked = False     '実験転用
        '@↑2011/12/27 (Tue) 11:32:26 T.Oide **************************************************

                        '@区分ｵﾌﾟｼｮﾝﾎﾞﾀﾝ使用不可
                        optKubun0.Enabled = False      '例外受入
        '@↓2011/12/27 (Tue) 11:32:35 T.Oide **************************************************
                        optKubun1.Enabled = False      '不良
        '@↑2011/12/27 (Tue) 11:32:35 T.Oide **************************************************
                        optKubun2.Enabled = False      '払出
                        optKubun3.Enabled = False      '保留
                        optKubun4.Enabled = False      '保留解除
        '@↓2011/12/27 (Tue) 11:32:26 T.Oide **************************************************
                        optKubun5.Enabled = False      '実験転用
        '@↑2011/12/27 (Tue) 11:32:26 T.Oide **************************************************

                        
                        '@入力項目初期化
                        txtNum.Text = vbNullString
                        txtWorkMemo.Text = vbNullString
                        
                        '@入力項目使用不可
                        txtNum.Enabled = False
                        txtNum.BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
                        txtWorkMemo.Enabled = False
                        cmdWorkMemoUp.Enabled = False
                        cmdWorkMemoDown.Enabled = False
                        txtWorkMemo.BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
                        
                        '@理由Combo使用不可
                        cmbReason.Enabled = False
                        cmbReason.ListIndex = -1
                        cmbReason.BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
                    End If
                Else
                '@部材一覧取得に失敗
                    '@部材一覧表示情報初期化
                    Call prvvsfPartLotList_Init()
                    
                    'NSYS 部材一覧取得成功/失敗ﾌﾗｸﾞ
                    mblnInvPartList = True

                    '@理由ｺﾝﾎﾞﾎﾞｯｸｽｸﾘｱ
                    cmbReason.Clear
            
                    '@数量ｸﾘｱ
                    txtNum.Text = vbNullString

                    '@作業ﾒﾓｸﾘｱ
                    txtWorkMemo.Text = vbNullString
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    Exit Sub
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
            End If
            
            With vsfPartLotList
                If .Rows.Count > 1 Then
                    '@部材一覧にｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(vsfPartLotList)
                End If
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdRegist_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCopy_Click
    '機　能：EXCELに貼り付ける際に、ｾﾙの先頭の文字列が、
    '　　　　「－」、「＋」の場合は、自動計算されるので、罫線文字におきかえる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/12 (Wed) 14:54:09 Y.Yamagishi
    '更新日：2004/10/29 (Fri) 15:35:31 Y.Yamagishi
    '備　考：2004/10/21 (Thu) 14:00:46 Y.Yamagishi　1行の最後はCR+LFが入っているのでTABｺｰﾄﾞは不要(不具合改善№146)
    '　　　：2004/10/29 (Fri) 15:35:31 Y.Yamagishi　不具合改善№146対応
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
            
            With vsfPartLotList
                '@一覧をｺﾋﾟｰする
                For llngRowCnt = 0 To .Rows.Count - 1
                    For llngColCnt = 0 To .Cols.Count - 1
                        '@列が非表示でない場合
                        If .Cols(llngColCnt).Visible Then
                        
                            '@文字列編集変数に値をｾｯﾄ
                            lstrWk = .GetDataDisplay(llngRowCnt, llngColCnt)
                            
                            '@先頭の文字列が「-」「+」の場合は罫線文字に置き換える
                            If Mid$(lstrWk, 1, 1) = CPstrMinus Then
                                Mid$(lstrWk, 1, 1) = CPstrMinusWide
                            End If
                            If Mid$(lstrWk, 1, 1) = CPstrPlus Then
                                Mid$(lstrWk, 1, 1) = CPstrPlusWide
                            End If
                            
                            '@最終列の場合Tabいらない
                            If llngColCnt = CMlngvsfPartLLColReworkCount Then
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

    '関数名：cmdNowList_Click
    '機　能：部材一覧取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/07 (Fri) 13:49:46 Y.Yamagishi
    '更新日：2011/12/27 (Tue) 11:34:58 T.Oide
    '備　考：2004/09/28 (Tue) 11:43:46 N.Kasai      処理区分3F追加（№969）
    '　　　：2004/10/15 (Fri) 17:14:21 N.Kasai      ｿｰﾄ順保持機能追加
    '　　　：2004/10/18 (Mon) 17:06:57 Y.Yamagishi  0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    '　　　：2005/06/27 (Mon) 08:51:43 S.Deguchi    軽微なｴﾗｰ対応
    '　　　：2011/12/27 (Tue) 11:35:09 T.Oide       REQ-1115 不良、払出の区分け対応
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click
        
        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypPartLotList         As List(Of PartLotList) '部材一覧取得情報格納
        Dim llngPartLotListCnt      As Integer              '部材一覧取得件数格納

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
            
            mstrEventName = "cmdNowList_Click"
            
            '@初期化
            mcurNum = 0                                      '受入数合計
            lblNum.Text = vbNullString                       '受入数合計
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@最新取得ﾎﾞﾀﾝのﾛｯｸ
            cmdNowList.Enabled = False
            
            '@部材一覧情報取得
            lblnAns = prvblnInvPartList_Sel(ltypPartLotList, llngPartLotListCnt)
            '@結果判定
            If lblnAns = True Then
                '@最新取得ﾎﾞﾀﾝのﾛｯｸ
                cmdNowList.Enabled = True
                
                '@部材一覧表示情報
                Call prvvsfPartLotList_Disp(ltypPartLotList, llngPartLotListCnt)
            Else
            '@部材一覧取得に失敗
                '@最新取得ﾎﾞﾀﾝのﾛｯｸ
                cmdNowList.Enabled = True
                
                '@部材一覧表示情報初期化
                Call prvvsfPartLotList_Init()
                
                'NSYS 部材一覧取得成功/失敗ﾌﾗｸﾞ
                mblnInvPartList = True

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                
                Call pubSetFocus(cmbPart)
                
                Exit Sub
            End If
                
            '@区分ｵﾌﾟｼｮﾝﾎﾞﾀﾝ初期化
            optKubun0.Checked = False        '例外受入
        '@↓2011/12/27 (Tue) 11:32:35 T.Oide **************************************************
            optKubun1.Checked = False        '不良
        '@↑2011/12/27 (Tue) 11:32:35 T.Oide **************************************************
            optKubun2.Checked = False        '払出
            optKubun3.Checked = False        '保留
            optKubun4.Checked = False        '保留解除
        '@↓2011/12/27 (Tue) 11:32:26 T.Oide **************************************************
            optKubun5.Checked = False        '実験転用
        '@↑2011/12/27 (Tue) 11:32:26 T.Oide **************************************************
            
            '@区分ｵﾌﾟｼｮﾝﾎﾞﾀﾝ使用不可
            optKubun0.Enabled = False        '例外受入
        '@↓2011/12/27 (Tue) 11:32:35 T.Oide **************************************************
            optKubun1.Enabled = False        '不良
        '@↑2011/12/27 (Tue) 11:32:35 T.Oide **************************************************
            optKubun2.Enabled = False        '払出
            optKubun3.Enabled = False        '保留
            optKubun4.Enabled = False        '保留解除
        '@↓2011/12/27 (Tue) 11:32:26 T.Oide **************************************************
            optKubun5.Enabled = False        '実験転用
        '@↑2011/12/27 (Tue) 11:32:26 T.Oide **************************************************

            
            '@入力項目初期化
            txtNum.Text = vbNullString
            txtWorkMemo.Text = vbNullString
            
            '@入力項目使用不可
            txtNum.Enabled = False
            txtNum.BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
            txtWorkMemo.Enabled = False
            cmdWorkMemoUp.Enabled = False
            cmdWorkMemoDown.Enabled = False
            txtWorkMemo.BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
            
            '@理由Combo使用不可
            cmbReason.Enabled = False
            cmbReason.BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, mstrEventName)
            
            '@行変更時処理
            Call vsfPartLotList_EnterCell(vsfPartLotList, e)

            '@ﾌｫｰｶｽｾｯﾄ
            With vsfPartLotList
                If .Enabled = True Then
                    '@一覧へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfPartLotList)
                Else
                    If cmdNowList.Enabled = True Then
                        '@最新取得へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdNowList)
                    Else
                        '@閉じるへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End With
                
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdNowList_Click"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
                
        End Try
    End Sub

    '関数名：cmbPartClass_Change
    '機　能：部品種別変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/07 (Fri) 11:39:44 Y.Yamagishi
    '更新日：2004/05/07 (Fri) 11:39:44
    '備　考：
    Private Sub cmbPartClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPartClass.Change

        Try
            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call prvfrmxxEN0230_Init(False)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbPartClass_Change"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbPartClass_CloseUp
    '機　能：部品種別のCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/07 (Fri) 13:20:19 Y.Yamagishi
    '更新日：2006/05/11 (Thu) 16:24:51 M.Miura
    '備　考：2006/05/11 (Thu) 16:24:51 M.Miura　　　不具合№3395 同一部品種別選択時は最新を取得しない
    Private Sub cmbPartClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPartClass.CloseUp
            
        Try
            
            If cmbPartClass.Text <> vbNullString Then
                '@退避領域と比較して同じ場合には処理抜け
                If mstrPartClass = cmbPartClass.Text Then
                    '@次項目へｾｯﾄﾌｫｰｶｽ
                    If cmbPart.Enabled = True Then
                        Call pubSetFocus(cmbPart)
                    Else
                        Call pubSetFocus(cmdClose)
                    End If
                    
                    Exit Sub
                End If
                '@部材ｺﾝﾎﾞをｸﾘｱ
                cmbPart.ListIndex = CMlngCmbClearListIndex
                
                '@部品種別_Validate処理
                RemoveHandler cmbPartClass.Validating, AddressOf cmbPartClass_Validate
                Call cmbPartClass_Validate(cmbPartClass, New CancelEventArgs(True))
                AddHandler cmbPartClass.Validating, AddressOf cmbPartClass_Validate
            End If
          
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbPartClass_CloseUp"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
          
        End Try
    End Sub

    '関数名：cmbPartClass_Validate
    '機　能：部品種別_Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/07 (Fri) 12:38:11 Y.Yamagishi
    '更新日：2006/05/11 (Thu) 16:31:36 M.Miura
    '備　考：2004/09/06 (Mon) 18:52:32 N.Kasai　    pubblnMasPartList_Sel Ver3.0対応
    '　　　：2005/12/12 (Mon) 16:28:56 S.Deguchi    部品一覧が0件の場合の処理を追加
    '　　　：2006/05/11 (Thu) 16:31:36 M.Miura　　　不具合№3395 ｺﾝﾎﾞで前回と同じ物を選択時は抜ける
    Private Sub cmbPartClass_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPartClass.Validating
            
        Dim llngpartcnt         As Integer              '部品数
        Dim lblnClassAns        As Boolean              '部品情報取得処理結果
        Dim ltypMasPartlist     As MasPartlist          '部材ｺｰﾄﾞﾘｽﾄ要求構造体

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            mstrEventName = "cmbPartClass_Validate"
            
            '@選択されていない場合
            If cmbPartClass.Text = vbNullString Then
                If ActiveControl.Name = cmbPartClass.Name Then
                    '@閉じるﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmdClose)
                End If
                
                Exit Sub
            Else
                '@部品ｺﾝﾎﾞﾎﾞｯｸｽ使用可能
                cmbPart.Enabled = True
            End If
            
            '@退避領域と比較して同じ場合には処理抜け
            If mstrPartClass = cmbPartClass.Text Then
                If ActiveControl.Name = cmbPartClass.Name Then
                    '@次項目へｾｯﾄﾌｫｰｶｽ
                    If cmbPart.Enabled = True Then
                        Call pubSetFocus(cmbPart)
                    Else
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                Exit Sub
            End If
            
            '@部品ﾘｽﾄ取得
            If cmbPart.Text = vbNullString Then
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, mstrEventName)
                
                '@部材ｺｰﾄﾞﾘｽﾄ要求構造体へ格納
                With ltypMasPartlist
                    .strSbID = pstrSBID                     '処理区分
                    .strMsgVer = CMstrmas_partlistVer       'ﾒｯｾｰｼﾞVersion
                    .strPdId = vbNullString                 '機種ID(取得できない為）
                    .strMasPdVersion = vbNullString         'PDVersion(取得できない為）
                    
                    '@ﾍﾞﾝﾀﾞｰｸﾗｽ取得
                    cmbPartClass.ValueCol = CMlngGetIDValueCol
                    .strVenderClassId = cmbPartClass.Value  '部品ID(部材ID)
                End With
                                
                '@部材ｺｰﾄﾞ、ﾍﾞﾝﾀﾞｰ取得
                lblnClassAns = pubblnMasPartList_Sel(ltypMasPartlist, _
                                                     llngpartcnt, _
                                                     mtyppartlist)
                '@結果判定
                If lblnClassAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    
                    '@部品種別退避をｸﾘｱ
                    mstrPartClass = vbNullString
                    Exit Sub
                Else
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
                    
                    '@部品情報表示
                    Call prvcmbPart_Disp(mtyppartlist, llngpartcnt)
                    
                    '@部品情報の件数ﾁｪｯｸ（件数によって処理を分岐）
                    Select Case llngpartcnt
                        Case 0
                        '@取得件数が0件
                            '@部品ｺﾝﾎﾞをｸﾘｱして非活性化
                            cmbPart.Text = vbNullString
                            cmbPart.Enabled = False
                            '@部品種別退避をｸﾘｱ
                            mstrPartClass = vbNullString
                            mstrPart = vbNullString
                            
                        Case 1
                        '@取得件数が1件
                            cmbPart.ListIndex = llngpartcnt - 1                             '取得した1件を表示
                        
                            RemoveHandler cmbPart.Validating, AddressOf cmbPart_Validate
                            Call cmbPart_Validate(cmbPart, New CancelEventArgs(False))      '部品のValidateｲﾍﾞﾝﾄを呼び出す
                            AddHandler cmbPart.Validating, AddressOf cmbPart_Validate
                            '@部品種別を退避
                            mstrPartClass = cmbPartClass.Text
                        Case Else
                        '@取得件数が1件以上
                            '@入力ﾁｪｯｸ
                            Call prvcmdRegist_Chk()
                            If ActiveControl.Name = cmbPartClass.Name Then
                                '@部品Comboへｾｯﾄﾌｫｰｶｽ
                                Call pubSetFocus(cmbPart)
                            End If
                            '@部品種別を退避
                            mstrPartClass = cmbPartClass.Text
                    End Select
                End If
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbPartClass_Validate"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPart_Change
    '機　能：部品変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/07 (Fri) 13:24:54 Y.Yamagishi
    '更新日：2012/01/20 (Fri) 13:23:18 T.Oide
    '備　考：
    Private Sub cmbPart_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPart.Change

        Dim llngNowByte As Integer  '現在のﾊﾞｲﾄ数格納

        Try
        '@↓2012/01/20 (Fri) 13:23:12 T.Oide **************************************************
            If mblnCmbPartChangeEventCancelFlag = True Then
                Exit Sub
            End If
        '@↑2012/01/20 (Fri) 13:23:12 T.Oide **************************************************

            '@理由Comboのｸﾘｱ
            cmbReason.Clear
            
            '@入力項目初期化
            txtNum.Text = vbNullString
            
            '@作業ﾒﾓ初期化
            With txtWorkMemo
                '@表示最大文字数
                .ChrMaxByte = CPlngLotCommentsMaxByte
                
                '@ﾃｷｽﾄ部初期化
                .Text = vbNullString
                
                '@現状のﾊﾞｲﾄ数を格納
                llngNowByte = .NowByte
                
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            End With
            
            '@理由Combo使用不可
            cmbReason.Enabled = False
            cmbReason.BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
            
            '@入力項目使用不可
            txtNum.Enabled = False
            txtNum.BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
            
            '@作業ﾒﾓ使用不可
            txtWorkMemo.Enabled = False
            cmdWorkMemoUp.Enabled = False
            cmdWorkMemoDown.Enabled = False

            txtWorkMemo.BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
            
            '@ｿｰﾄ列初期化
            mlngSortCol = CMlngvsfmlngSortCol
            
            '@ｿｰﾄ方法初期化
            mlngSortOrder = CMlngvsfmlngOrderCol
            
            '@区分ｵﾌﾟｼｮﾝﾎﾞﾀﾝ初期化
            optKubun0.Checked = False            '例外受入
        '@↓2011/12/26 (Mon) 17:18:07 T.Oide **************************************************
            optKubun1.Checked = False            '不良
        '@↑2011/12/26 (Mon) 17:18:07 T.Oide **************************************************
            optKubun2.Checked = False            '払出
            optKubun3.Checked = False            '保留
            optKubun4.Checked = False            '保留解除
        '@↓2011/12/26 (Mon) 17:17:57 T.Oide **************************************************
            optKubun5.Checked = False            '実験転用
        '@↑2011/12/26 (Mon) 17:17:57 T.Oide **************************************************
            
            '@区分ｵﾌﾟｼｮﾝﾎﾞﾀﾝ使用不可
            optKubun0.Enabled = False            '例外受入
        '@↓2011/12/26 (Mon) 17:19:03 T.Oide **************************************************
            optKubun1.Enabled = False            '不良
        '@↑2011/12/26 (Mon) 17:19:03 T.Oide **************************************************
            optKubun2.Enabled = False            '払出
            optKubun3.Enabled = False            '保留
            optKubun4.Enabled = False            '保留解除
        '@↓2011/12/26 (Mon) 17:18:54 T.Oide **************************************************
            optKubun5.Enabled = False            '実験転用
        '@↑2011/12/26 (Mon) 17:18:54 T.Oide **************************************************
            
            '@部材一覧初期化処理
            Call prvvsfPartLotList_Init()
            
            '@ｺﾝﾄﾛｰﾙ制御
            cmdNowList.Enabled = True            '最新取得ﾎﾞﾀﾝ有効
            cmdCopy.Enabled = False              'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ無効
            cmdRegist.Enabled = False            '確定ﾎﾞﾀﾝ無効
            
            '部材ｺﾝﾎﾞ変更ﾌﾗｸﾞON
            mblncmbPartFlag = True
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbPart_Change"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbPart_CloseUp
    '機　能：部品Validate処理呼び出し
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/07 (Fri) 13:26:37 Y.Yamagishi
    '更新日：2004/05/07 (Fri) 13:26:37
    '備　考：
    Private Sub cmbPart_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPart.CloseUp

        Try
            '@部品Validate処理呼び出し
            RemoveHandler cmbPart.Validating, AddressOf cmbPart_Validate
            Call cmbPart_Validate(cmbPart, New CancelEventArgs(True))
            AddHandler cmbPart.Validating, AddressOf cmbPart_Validate
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbPart_CloseUp"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbPart_Validate
    '機　能：部品Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/07 (Fri) 11:33:01 Y.Yamagishi
    '更新日：2006/05/11 (Thu) 16:24:51 M.Miura
    '備　考：2006/05/11 (Thu) 16:24:51 M.Miura 不具合№3395 ﾌｫｰｶｽ制御追加
    Private Sub cmbPart_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPart.Validating
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@部品種別、部品ｺﾝﾎﾞﾎﾞｯｸｽが選択されていない場合には処理抜け
            If cmbPart.Text = vbNullString Or cmbPartClass.Text = vbNullString Then
                Exit Sub
            End If
            
            '@部材を変更しない場合は最新を取得しない
            If mblncmbPartFlag = True Then
                
                '@ﾎﾞﾀﾝ押下処理の実行
                Call cmdNowList_Click(cmdNowList, New EventArgs)           '最新取得ﾎﾞﾀﾝ
                
                '@入力ﾁｪｯｸ
                Call prvcmdRegist_Chk()
                
                '@最新取得ﾎﾞﾀﾝ使用可能
                cmdNowList.Enabled = True
                
                '@部材変更ﾌﾗｸﾞ初期化
                mblncmbPartFlag = False
            Else
                If ActiveControl.Name = cmbPart.Name Then
                    '@一覧が有効な場合
                    If vsfPartLotList.Enabled = True Then
                        '@ﾌｫｰｶｽを一覧に移動
                        Call pubSetFocus(vsfPartLotList)
                    Else
                        '@最新取得ﾎﾞﾀﾝが有効な場合
                        If cmdNowList.Enabled = True Then
                            '@ﾌｫｰｶｽを最新取得ﾎﾞﾀﾝに移動
                            Call pubSetFocus(cmdNowList)
                        Else
                            '@ﾌｫｰｶｽを閉じるﾎﾞﾀﾝに移動
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbPart_Validate"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：optKubun_Click
    '機　能：処理区分ｵﾌﾟｼｮﾝﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ値
    '戻り値：なし
    '作成日：2004/05/12 (Wed) 14:50:33 Y.Yamagishi
    '更新日：2011/12/26 (Mon) 14:36:45 T.Oide
    '備　考：
    '　　　：2005/06/22 (Wed) 15:07:37 S.Deguchi    各理由が1つしかない場合,表示する処理追加
    '　　　：2011/12/26 (Mon) 14:36:45 T.Oide       REQ-1115 不良、払出の区別追加
    Private Sub optKubun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optKubun0.CheckedChanged, optKubun1.CheckedChanged, optKubun2.CheckedChanged, optKubun3.CheckedChanged, optKubun4.CheckedChanged, optKubun5.CheckedChanged
        
        
        Try

            'NSYS チェックが付いていない場合処理を抜ける
            If sender.Checked = False Then
                Exit Sub
            End If
            
            '@理由ｸﾘｱ
            cmbReason.Clear
                
            '@数量ｸﾘｱ
            txtNum.Text = vbNullString
            
            '@処理区分により、数量使用可能を判定する
            'Select Case Index
        '@↓2011/12/26 (Mon) 14:12:44 T.Oide **************************************************
        '@        '@例外受入、払出
        '@        Case CMlngLotReceiveFlg To CMlngLotTakeFlg
        '@            '@数量使用可
        '@            txtNum.Enabled = True
        '@            txtNum.BackColor = CPlngEnableTrueColor
        '@
        '@        '@保留、保留解除
        '@        Case CMlngLotHoldFlg To CMlngLotReleaseFlg
        '@            '@数量使用不可
        '@            txtNum.Enabled = False
        '@            txtNum.BackColor = CPlngEnableFalseColor

            '@例外受入、不良、払出、実験品転用
            If sender Is optKubun0 Or sender Is optKubun1 Or sender Is optKubun2 Or sender Is optKubun5
                
                '@数量使用可
                txtNum.Enabled = True
                txtNum.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                    
            '@保留、保留解除
            Else If sender Is optKubun3 Or sender Is optKubun4
                '@数量使用不可
                txtNum.Enabled = False
                txtNum.BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
        '@↑2011/12/26 (Mon) 14:12:44 T.Oide **************************************************
            End If
            
            '@理由ｺﾝﾎﾞﾎﾞｯｸｽ使用可
            cmbReason.Enabled = True
            cmbReason.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
            
            '@作業ﾒﾓ使用可
            txtWorkMemo.Enabled = True
            txtWorkMemo.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
            
            '@ﾛｯﾄｲﾍﾞﾝﾄID初期化
            mstrLotEventID = vbNullString

            '@理由情報取得処理
            '@処理区分が「例外受入」の場合
            If sender Is optKubun0 Then
                '@理由情報表示処理
                 Call prvcmbReason_Disp(mtypMasReceiveItemList)
                
        '@↓2011/12/26 (Mon) 14:38:32 T.Oide **************************************************
                '@処理区分が「不良」の場合
            Else If sender Is optKubun1 Then
                '@理由情報表示処理
                 Call prvcmbReason_Disp(mtypMasScrapItemList)
        '@↑2011/12/26 (Mon) 14:38:32 T.Oide **************************************************
                
            '@処理区分が「払出」の場合
            Else If sender Is optKubun2 Then
                '@理由情報表示処理
                 Call prvcmbReason_Disp(mtypMasTakeItemList)
                     
            '@処理区分が「保留」の場合
            Else If sender Is optKubun3 Then
                '@理由情報表示処理
                 Call prvcmbReason_Disp(mtypMasHoldItemList)
                     
            '@処理区分が「保留解除」の場合
            Else If sender Is optKubun4 Then
                '@理由情報表示処理
                 Call prvcmbReason_Disp(mtypMasReleaseItemList)
            End If

            '@各理由が1行しかない場合,表示する
            If cmbReason.ListCount = 1 Then
                cmbReason.ListIndex = 0
            End If
            
            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optKubun_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtNum_Change
    '機　能：数量変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 14:23:46 M.Miura
    '更新日：2004/06/02 (Wed) 14:23:46
    '備　考：
    Private Sub txtNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtNum.Change

        Try
            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtNum_Change"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtNum_Validate
    '機　能：数量Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 15:17:30 Y.Yamagishi
    '更新日：2004/05/21 (Fri) 10:54:43 T.Kitagawa
    '備　考：
    Private Sub txtNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtNum.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
            '処理区分が「払出」の場合
            If optKubun2.Checked = True Then
                If IsNumeric(txtNum.Text) = True Then
                    '@数量が現在数量より大きい場合
                    If txtNum.Text > vsfPartLotList.GetData(vsfPartLotList.Row, CMlngvsfPartLLColNum) Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0062)
                        
                        '@"数量には現在数量より小さい値を入力してください。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@数量入力欄へｾｯﾄﾌｫｰｶｽ
                        e.Cancel = True
                    End If
                End If
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtNum_Validate"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbReason_Change
    '機　能：理由変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 15:19:02 Y.Yamagishi
    '更新日：2004/05/11 (Tue) 15:19:02
    '備　考：
    Private Sub cmbReason_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbReason.Change
            
        Try
            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbReason_Change"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbReason_CloseUp
    '機　能：理由ｺﾝﾎﾞﾎﾞｯｸｽCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/13 (Thu) 10:35:40 Y.Yamagishi
    '更新日：2004/05/13 (Thu) 10:35:40
    '備　考：
    Private Sub cmbReason_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbReason.CloseUp
        
        Try
            '@理由ｺﾝﾎﾞﾎﾞｯｸｽが選択されているか
            If cmbReason.ListIndex >= 0 Then
                '@次項目へｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(txtWorkMemo)
                
                '@入力ﾁｪｯｸ
                Call prvcmdRegist_Chk()
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbReason_CloseUp"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbReason_Validate
    '機　能：理由Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 15:19:02 Y.Yamagishi
    '更新日：2004/05/11 (Tue) 15:19:02
    '備　考：
    Private Sub cmbReason_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbReason.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbReason_Validate"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfPartLotList_AfterSort
    '機　能：ﾛｯﾄ一覧AfterSort処理
    '引　数：Col：ｿｰﾄ列
    '　　　：Order：ｿｰﾄ方法
    '戻り値：なし
    '作成日：2004/05/14 (Fri) 16:13:33 Y.Yamagishi
    '更新日：2004/05/14 (Fri) 16:13:33
    '備　考：
    Private Sub vsfPartLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfPartLotList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfPartLotList.Rows.Count <= vsfPartLotList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄされた列を格納
            mlngSortCol = e.Col
            
            '@ｿｰﾄ方法を格納
            mlngSortOrder = e.Order
            
            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                Dim ltypChgSortList As ChgSortList
                '@ｿｰﾄ列番号を格納
                ltypChgSortList.lngCol = e.Col
                
                '@並び替え方法を格納（昇順/降順）
                ltypChgSortList.lngOrder = e.Order
                .typChgSortList.Add(ltypChgSortList)
            End With
            
            AddHandler vsfPartLotList.BeforeRowColChange, AddressOf vsfPartLotList_BeforeRowColChange
            AddHandler vsfPartLotList.EnterCell,AddressOf vsfPartLotList_EnterCell
            
            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfAfterSort(vsfPartLotList, CMlngvsfPartLLRowTitle)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfPartLotList_AfterSort"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPartLotList_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 17:16:28 N.Kasai
    '更新日：2004/10/15 (Fri) 17:16:28
    '備　考：
    Private Sub vsfPartLotList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfPartLotList.BeforeRowColChange
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfPartLotList.Rows.Count <= vsfPartLotList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（在庫ID）
                mtypChgSort.strKey = vsfPartLotList.GetData(e.NewRange.r1, _
                                                         CMlngvsfPartLLColLotID)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                     '機能ID
                .strProcName = "vsfPartLotList_BeforeRowColChange"  '処理名
                .strErrMessage = vbNullString                       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPartLotList_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/05/21 (Fri) 14:16:39 Y.Yamagishi
    '更新日：2004/05/21 (Fri) 14:16:39
    '備　考：
    Private Sub vsfPartLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfPartLotList.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfPartLotList.Rows.Count <= vsfPartLotList.Rows.Fixed Then
                Return
            End If
            
            RemoveHandler vsfPartLotList.BeforeRowColChange, AddressOf vsfPartLotList_BeforeRowColChange
            RemoveHandler vsfPartLotList.EnterCell,AddressOf vsfPartLotList_EnterCell

            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfBeforeSort(vsfPartLotList, CMlngvsfPartLLRowTitle)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfPartLotList_BeforeSort"  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPartLotList_EnterCell
    '機　能：ｸﾞﾘｯﾄﾞのEnterCell時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/07 (Fri) 17:37:55 Y.Yamagishi
    '更新日：2011/12/27 (Tue) 11:37:57 T.Oide
    '備　考：
    '　　　：2005/06/27 (Mon) 08:52:15 S.Deguchi    ﾀｲﾄﾙしか表示していない場合には,処理を行わないようにする処理を追加
    '　　　：2011/12/27 (Tue) 11:35:09 T.Oide       REQ-1115 不良、払出の区分け対応
    Private Sub vsfPartLotList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfPartLotList.EnterCell
        
        Dim llngDoCnt   As Integer  'ｶｳﾝﾄ
        Dim llngCnt     As Integer  'ｶｳﾝﾄ

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfPartLotList.Rows.Count <= vsfPartLotList.Rows.Fixed Then
                Return
            End If

            '@理由ｺﾝﾎﾞﾎﾞｯｸｽｸﾘｱ
            cmbReason.Clear
            
            '@数量ｸﾘｱ
            txtNum.Text = vbNullString
            '@作業ﾒﾓｸﾘｱ
            txtWorkMemo.Text = vbNullString

            With vsfPartLotList
                '@ﾀｲﾄﾙ以外
                If .Row <> 0 Then
                    '@ﾛｯﾄの状態ﾁｪｯｸ
                    If .GetData(.Row, CMlngvsfPartLLColNo) <> vbNullString Then
                        '保留の場合
                        If .GetData(.Row, CMlngvsfPartLLColStatus) = CPstrHo Then
                            '@保留解除ｵﾌﾟｼｮﾝﾎﾞﾀﾝ使用可能
                            optKubun4.Enabled = True                '保留解除
                            
                            '@保留解除を初期ｾｯﾄ
                            optKubun4.Checked = True
                            
                            '@保留解除以外のｵﾌﾟｼｮﾝﾎﾞﾀﾝ使用不可
                            optKubun0.Enabled = False               '例外受入
        '@↓2011/12/27 (Tue) 11:32:35 T.Oide **************************************************
                            optKubun1.Enabled = False               '不良
        '@↑2011/12/27 (Tue) 11:32:35 T.Oide **************************************************
                            optKubun2.Enabled = False               '払出
                            optKubun3.Enabled = False               '保留
        '@↓2011/12/27 (Tue) 11:32:26 T.Oide **************************************************
                            optKubun5.Enabled = False               '実験転用
        '@↑2011/12/27 (Tue) 11:32:26 T.Oide **************************************************
                            
                            '@ｶｳﾝﾀの初期化
                            llngDoCnt = 1
                            llngCnt = 1
                            
                            '@理由ｺﾝﾎﾞﾎﾞｯｸｽに保留理由&保留理由名をｾｯﾄ
                            cmbReason.Text = .GetData(.Row, CMlngvsfPartLLColWKReasonCode) & _
                                             " " & _
                                             .GetData(.Row, CMlngvsfPartLLColWKReasonCodeName)
                                    
                            '@保留理由使用不可
                            cmbReason.Enabled = False
                        Else
                            '@ﾘｽﾄのﾍｯﾀﾞｰ以外が選択せれている場合
                            If .Row <> 0 Then
                                '@保留解除以外のｵﾌﾟｼｮﾝﾎﾞﾀﾝ使用可能
                                optKubun0.Enabled = True                '例外受入
        '@↓2011/12/27 (Tue) 11:32:35 T.Oide **************************************************
                                optKubun1.Enabled = True                '不良
        '@↑2011/12/27 (Tue) 11:32:35 T.Oide **************************************************
                                optKubun2.Enabled = True                '払出
                                optKubun3.Enabled = True                '保留
        '@↓2011/12/27 (Tue) 11:32:26 T.Oide **************************************************
                                optKubun5.Enabled = False                '実験転用(ﾌｪｰｽﾞ1では常に無効)
        '@↑2011/12/27 (Tue) 11:32:26 T.Oide **************************************************
                                
                                '@例外受入を初期ｾｯﾄ
        '@↓2012/01/20 (Fri) 14:00:45 T.Oide **************************************************
                                'optKubun(CMlngLotReceiveFlg).Value = True
                                optKubun1.Checked = True
        '@↑2012/01/20 (Fri) 14:00:45 T.Oide **************************************************
                                
                                '@保留解除ｵﾌﾟｼｮﾝﾎﾞﾀﾝ使用不可
                                optKubun4.Enabled = False               '保留解除
                    
                                '@理由ｺﾝﾎﾞﾎﾞｯｸｽｸﾘｯｸ時処理
        '@↓2012/01/20 (Fri) 14:07:30 T.Oide **************************************************
                                'Call optKubun_Click(CMlngLotReceiveFlg)
                                Call optKubun_Click(optKubun1, New EventArgs)
        '@↑2012/01/20 (Fri) 14:07:30 T.Oide **************************************************
                                
                                
                            End If
                        End If
                    End If
                End If
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfPartLotList_EnterCell"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：作業ﾒﾓのChange処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/15 (Sat) 11:08:07 Y.Yamagishi
    '更新日：2004/05/15 (Sat) 11:08:07
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Try
            Dim llngNowByte As Integer 'ﾊﾞｲﾄ数
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                          llngNowByte, _
                                                          CPlngLotCommentsMaxByte)

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtWorkMemo_Change"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2005/12/01 (Thu) 11:03:51 S.Deguchi **************************************************
    '関数名：txtWorkMemo_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/12/01 (Thu) 11:01:52 S.Deguchi
    '更新日：2005/12/01 (Thu) 11:01:52
    '備　考：
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/12/01 (Thu) 11:02:50 S.Deguchi
    '更新日：2005/12/01 (Thu) 11:02:50
    '備　考：
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2005/12/01 (Thu) 11:03:51 S.Deguchi **************************************************

    '関数名：cmdWorkMemoUp_Click
    '機　能：作業ﾒﾓ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/16 (Fri) 09:20:24 Y.Yamagishi
    '更新日：2004/07/16 (Fri) 09:20:24
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdWorkMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkMemoUp.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdWorkMemoUp_Click"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWorkMemoDown_Click
    '機　能：作業ﾒﾓ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/16 (Fri) 09:20:29 Y.Yamagishi
    '更新日：2004/07/16 (Fri) 09:20:29
    '備　考：
    '　　　：2005/12/01 (Thu) 10:58:39 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdWorkMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkMemoDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdWorkMemoDown_Click"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvfrmxxEN0230_Init
    '機　能：ﾒｲﾝﾌｫｰﾑの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 16:39:36 Y.Yamagishi
    '更新日：2004/10/04 (Mon) 14:50:00 H.Wajima
    '備　考：2004/10/04 (Mon) 14:50:00 H.Wajima    ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    Private Sub prvfrmxxEN0230_Init(ByVal lblnRtn As String)
        
        Dim lctlControl     As Control                      'ｺﾝﾄﾛｰﾙ名称取得用変数
        Dim llngNowByte     As Integer                      '現在のﾊﾞｲﾄ数格納
        Dim lstrFormTitle   As String                       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        
        Try
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0230, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            If lblnRtn = True Then
                '@部品種別初期化
                cmbPartClass.Clear
            End If
            
            '@受入数合計初期化
            mcurNum = 0
            lblNum.Text = vbNullString
            
            '@部品種別以外Comboのｸﾘｱ
            cmbPart.Clear
            cmbReason.Clear
            '@部材ｺﾝﾎﾞ変更ﾌﾗｸﾞ初期化
            mblncmbPartFlag = False
            
            '@区分ｵﾌﾟｼｮﾝﾎﾞﾀﾝ初期化
            optKubun0.Checked = False            '例外受入
        '@↓2011/12/26 (Mon) 14:50:56 T.Oide **************************************************
            optKubun1.Checked = False            '不良
        '@↑2011/12/26 (Mon) 14:50:56 T.Oide **************************************************
            optKubun2.Checked = False            '払出
            optKubun3.Checked = False            '保留
            optKubun4.Checked = False            '保留解除
        '@↓2011/12/26 (Mon) 14:50:56 T.Oide **************************************************
            optKubun5.Checked = False            '実験転用
        '@↑2011/12/26 (Mon) 14:50:56 T.Oide **************************************************
                
            '@入力項目初期化
            txtNum.Text = vbNullString
            
            '@作業ﾒﾓ初期化
            With txtWorkMemo
                '@表示最大文字数
                .ChrMaxByte = CPlngLotCommentsMaxByte
                
                '@ﾃｷｽﾄ部初期化
                .Text = vbNullString
                
                '@現状のﾊﾞｲﾄ数を格納
                llngNowByte = .NowByte
                
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            End With
            
            '@部品種別以外Combo使用不可
            cmbPart.Enabled = False
            cmbReason.Enabled = False
            cmbReason.BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
            
            '@区分ｵﾌﾟｼｮﾝﾎﾞﾀﾝ使用不可
            optKubun0.Enabled = False          '例外受入
        '@↓2011/12/26 (Mon) 14:50:56 T.Oide **************************************************
            optKubun1.Enabled = False          '不良
        '@↑2011/12/26 (Mon) 14:50:56 T.Oide **************************************************
            optKubun2.Enabled = False          '払出
            optKubun3.Enabled = False          '保留
            optKubun4.Enabled = False          '保留解除
        '@↓2011/12/26 (Mon) 14:50:56 T.Oide **************************************************
            optKubun5.Enabled = False          '実験転用
        '@↑2011/12/26 (Mon) 14:50:56 T.Oide **************************************************
            
            
            '@入力項目使用不可
            txtNum.Enabled = False
            txtNum.BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
            txtWorkMemo.Enabled = False
            cmdWorkMemoUp.Enabled = False
            cmdWorkMemoDown.Enabled = False
            txtWorkMemo.BackColor = ColorTranslator.FromWin32(CPlngEnableFalseColor)
            
            '@ｺﾝﾄﾛｰﾙ制御
            cmdNowList.Enabled = False         '最新取得ﾎﾞﾀﾝ無効
            cmdCopy.Enabled = False            'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ無効
            cmdRegist.Enabled = False          '確定ﾎﾞﾀﾝ無効
                
            '@ComboBox設定(外枠設定のみ)
            For Each lctlControl In Me.Controls
                If TypeOf lctlControl Is SEComboBoxEx.ComboBoxEx Then
                    With CType(lctlcontrol, SEComboBoxEx.ComboBoxEx)
                        '@初期化
                        .DirectInput = False                                                '直接入力(Flase)
                        .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                         .Font.Style, .Font.Unit)                           'ﾌｫﾝﾄｻｲｽﾞ
                        .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                             .GridFont.Style, .GridFont.Unit)               'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                        .Height = CMlngCmbRowHeight                                         'ﾘｽﾄ行の高さ
                    End With
                End If
            Next
            
            
            '@構造体初期化（ｿｰﾄ順保持）
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
        '@↓2011/12/26 (Mon) 14:50:24 T.Oide **************************************************
            '@変数初期化
            mstrTaihiLotScrapSetID = vbNullString                       'ﾛｯﾄ情報取得時の不良項目ｾｯﾄID
        '@↑2011/12/26 (Mon) 14:50:24 T.Oide **************************************************
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN0230_Init"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvvsfPartLotList_Init
    '機　能：部材一覧表示情報初期化
    '引　数：lblnWidhtChg（True：幅設定する、False：幅設定しない）
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 16:48:25 Y.Yamagishi
    '更新日：2004/05/06 (Thu) 16:48:25
    '備　考：
    Private Sub prvvsfPartLotList_Init()
        
        Try
            
            '@一覧表示の各ｶﾗﾑの幅,ﾀｲﾄﾙを設定
            With vsfPartLotList
                .Redraw = False

                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                '@水平ｽｸﾛｰﾙﾊﾞｰなし
                .ScrollBars = ScrollBars.Vertical
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.None
                '@幅の変更はしない
                .AllowResizing = AllowResizingEnum.None
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                                        '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)           '背景色
                lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CMlngvsfPartLLHFontSize, _
                                            lFixedStyle.Font.Style, lFixedStyle.Font.Unit)  'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                
                
                '@列幅設定
                '@処理区分判定
                If pstrSBID = CPstrSBID1A0 Then
                    '@基板工程の場合
                    .Cols(CMlngvsfPartLLColLotID).Width = CMlngvsfPartLL1A0ColWLotID
                    .Cols(CMlngvsfPartLLColPrLotID).Width = CMlngvsfPartLL1A0ColWPrLotID
                    .Cols(CMlngvsfPartLLColNum).Width = CMlngvsfPartLL1A0ColWNum
                    .Cols(CMlngvsfPartLLColDate).Width = CMlngvsfPartLL1A0ColWDate
                    .Cols(CMlngvsfPartLLColEmpID).Width = CMlngvsfPartLL1A0ColWEmpID
                    .Cols(CMlngvsfPartLLColCFLotID).Width = CMlngvsfPartLL1A0ColWCFLotID
                Else
                    '@組立工程の場合
                    .Cols(CMlngvsfPartLLColLotID).Width = CMlngvsfPartLLColWLotID
                    .Cols(CMlngvsfPartLLColPrLotID).Width = CMlngvsfPartLLColWPrLotID
                    .Cols(CMlngvsfPartLLColNum).Width = CMlngvsfPartLLColWNum
                    .Cols(CMlngvsfPartLLColDate).Width = CMlngvsfPartLLColWDate
                    .Cols(CMlngvsfPartLLColEmpID).Width = CMlngvsfPartLLColWEmpID
                    .Cols(CMlngvsfPartLLColCFLotID).Width = CMlngvsfPartLLColWCFLotID
                End If
                
                .Cols(CMlngvsfPartLLColNo).Width = CMlngvsfPartLLColWNo
                .Cols(CMlngvsfPartLLColStatus).Width = CMlngvsfPartLLColWStatus
                .Cols(CMlngvsfPartLLColBoardThickness).Width = CMlngvsfPartLLColWBoardThickness
                .Cols(CMlngvsfPartLLColReworkCount).Width = CMlngvsfPartLLColWRegeneration
                .Cols(CMlngvsfPartLLColWKLotLastUpdate).Width = CMlngvsfPartLLColWWKLotLastUpdate
                .Cols(CMlngvsfPartLLColWKReasonCode).Width = CMlngvsfPartLLColWWKReasonCode
                .Cols(CMlngvsfPartLLColWKReasonCodeName).Width = CMlngvsfPartLLColWWKReasonCodeName
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfPartLLRowTitle, CMlngvsfPartLLColNo, CMstrvsfPartLLColTNo)                           'No.
                .SetData(CMlngvsfPartLLRowTitle, CMlngvsfPartLLColPrLotID, CMstrvsfPartLLColTPrLotID)                 '製造ﾛｯﾄID
                .SetData(CMlngvsfPartLLRowTitle, CMlngvsfPartLLColNum, CMstrvsfPartLLColTNum)                         '受入数
                .SetData(CMlngvsfPartLLRowTitle, CMlngvsfPartLLColDate, CMstrvsfPartLLColTDate)                       '受入日時
                .SetData(CMlngvsfPartLLRowTitle, CMlngvsfPartLLColEmpID, CMstrvsfPartLLColTEmpID)                     '受入担当
                .SetData(CMlngvsfPartLLRowTitle, CMlngvsfPartLLColCFLotID, CMstrvsfPartLLColTCFLotID)                 '出荷ﾛｯﾄID
                .SetData(CMlngvsfPartLLRowTitle, CMlngvsfPartLLColReworkCount, CMstrvsfPartLLColTRegeneration)        '板厚
                .SetData(CMlngvsfPartLLRowTitle, CMlngvsfPartLLColBoardThickness, CMstrvsfPartLLColTBoardThickness)   'ﾘﾜｰｸ回数
                .SetData(CMlngvsfPartLLRowTitle, CMlngvsfPartLLColLotID, CMstrvsfPartLLColTLotID)                     '在庫ﾛｯﾄID
                .SetData(CMlngvsfPartLLRowTitle, CMlngvsfPartLLColStatus, CMstrvsfPartLLColTStatus)                   '状態

                '@隠しCol設定
                .Cols(CMlngvsfPartLLColWKLotLastUpdate).Visible = False
                .Cols(CMlngvsfPartLLColWKReasonCode).Visible = False
                .Cols(CMlngvsfPartLLColWKReasonCodeName).Visible = False
                
                '@処理区分判定
                If pstrSBID = CPstrSBID1A0 Then
                    '@基板工程の場合
                    .Cols(CMlngvsfPartLLColCFLotID).Visible = False
                    .Cols(CMlngvsfPartLLColReworkCount).Visible = False
                    .Cols(CMlngvsfPartLLColBoardThickness).Visible = False
                Else
                    '@組立工程の場合
                    .Cols(CMlngvsfPartLLColCFLotID).Visible = True
                    .Cols(CMlngvsfPartLLColReworkCount).Visible = True
                    .Cols(CMlngvsfPartLLColBoardThickness).Visible = True
                End If
                
                '@表示位置の設定
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfPartLLRowTitle, CMlngvsfPartLLColTitle,.Rows.Count - 1, .Cols.Count - 2)
                Dim headerStyle As CellStyle = .Styles.Add("textalign")
                headerStyle.TextAlign = TextAlignEnum.CenterCenter              '中央寄せ中央揃え
                cellRange.Style = headerStyle

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngvsfPartLLRowTitle).Height = CMlngvsfPartLLHHeight    '高さ
                
                '@情報取得日時初期化
                lblNowDate.Text = vbNullString
                
                '@該当件数ﾗﾍﾞﾙの初期化
                lblLotCnt.Text = vbNullString
                '@ﾛｯｸ
                If mbln1stFormLoad = True OrElse mblnInvPartList = False Then
                    .Enabled = False
                End If

                .Redraw = True
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfPartLotList_Init"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvcmbPartClass_Disp
    '機　能：部品種別情報表示
    '引　数：ltypVenderList：取得情報格納ﾃﾞｰﾀ
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 17:17:27 Y.Yamagishi
    '更新日：2004/05/06 (Thu) 17:17:27 Y.Yamagishi
    Private Sub prvcmbPartClass_Disp(ByRef ltypVenderlist As VenderList)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbPartClass
                '@部品種別情報初期化
                .Clear
                .Height = CMlngCmbHeight                                        '高さ
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol                                    '値取得列
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
                
                '@部品種別情報ｾｯﾄ
                For llngCnt = 0 To ltypVenderlist.lngVenderClassListCnt - 1
                    .AddItem(ltypVenderlist.typVenderClassList(llngCnt).strVenderClassName _
                           & vbTab _
                           & ltypVenderlist.typVenderClassList(llngCnt).strVenderClassId)        '部品名&部品ID
                Next llngCnt
                
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbPartClass_Disp"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPart_Disp
    '機　能：部品情報表示
    '引　数：mtypClassList() ：取得情報格納ﾃﾞｰﾀ
    '　　　：llngpartcnt：取得情報ﾃﾞｰﾀ数
    '戻り値：なし
    '作成日：2004/05/07 (Fri) 12:47:49 Y.Yamagishi
    '更新日：2004/06/10 (Thu) 15:24:02 T.Kitagawa
    '備　考：
    Private Sub prvcmbPart_Disp(ByRef mtyppartlist As List(Of PartClassList), ByVal llngpartcnt As Integer)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        
        Try

            With cmbPart
                '@部品情報初期化
                .Clear
                .Height = CMlngCmbHeight                                        '高さ
                .DispCols = CMlngCmbDispCols2                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol                                    '値取得列
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
                .ColAlignment(CMlngCmbGridColID) = TextAlignEnum.LeftCenter     '左寄中央揃え
                
                '@部品情報ｾｯﾄ
                For llngCnt = 0 To llngpartcnt - 1
                    '@'「部品ID」&「部品名」&「部品ID 部品名」
                    .AddItem(mtyppartlist(llngCnt).strPartCode _
                           & vbTab _
                           & mtyppartlist(llngCnt).strPartName _
                           & vbTab _
                           & mtyppartlist(llngCnt).strPartCode & CPstrSpace & mtyppartlist(llngCnt).strPartName)
                Next llngCnt
                .GetCol = CMlngCmbGetCol                                        '値表示列
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbPart_Disp"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbReasonreceivecode_Disp
    '機　能：理由表示処理
    '引　数：mtypMasItemList()：取得情報格納ﾃﾞｰﾀ
    '　　　：llngpartcnt：取得情報ﾃﾞｰﾀ数
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 10:52:10 Y.Yamagishi
    '更新日：2004/05/11 (Tue) 10:52:10
    '備　考：
    Private Sub prvcmbReason_Disp(ByRef mtypMasItemList As MasItemList)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbReason
                '@部品情報初期化
                .Clear
                .Height = CMlngCmbHeight                                        '高さ
                .DispCols = CMlngCmbDispCols2                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol                                    '値取得列
                .GetCol = CMlngCmbGetCol                                        '値表示列
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
                .ColAlignment(CMlngCmbGridColID) = TextAlignEnum.LeftCenter     '左寄中央揃え
                
                '@ﾛｯﾄｲﾍﾞﾝﾄIDｾｯﾄ
                mstrLotEventID = mtypMasItemList.strLotEventId
                vsfPartLotList.Redraw = False
                '@部品情報ｾｯﾄ
                For llngCnt = 0 To mtypMasItemList.lngListCnt - 1
                    .AddItem(mtypMasItemList.typeMasItem(llngCnt).strItemID & _
                             vbTab & _
                             mtypMasItemList.typeMasItem(llngCnt).strItemName & _
                             vbTab & _
                             mtypMasItemList.typeMasItem(llngCnt).strItemID & CPstrSpace & mtypMasItemList.typeMasItem(llngCnt).strItemName)  '「ｺｰﾄﾞID」&「理由名」&「ｺｰﾄﾞID 理由名」
                Next llngCnt
                vsfPartLotList.Redraw = True
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbReason_Disp"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdRegist_Chk
    '機　能：確定ﾎﾞﾀﾝの活性化ﾁｪｯｸ･制御
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/07 (Fri) 13:16:20 Y.Yamagishi
    '更新日：2004/05/07 (Fri) 13:16:20
    '備　考：
    Private Sub prvcmdRegist_Chk()

        Dim lblnFlg     As Boolean      'ﾌﾗｸﾞ処理(True:確定ﾎﾞﾀﾝ活性化,False:確定ﾎﾞﾀﾝ非活性化)
        Dim lblnFlg2    As Boolean      '処理区分ﾁｪｯｸﾌﾗｸﾞ
        
        Try
            
            '@初期化
            lblnFlg = True

            '@部品種別ﾁｪｯｸ
            If cmbPartClass.Text = vbNullString Then
                lblnFlg = False
            End If
                
            '@部品ﾁｪｯｸ
            If cmbPart.Text = vbNullString Then
                lblnFlg = False
            End If
                
            '@処理区分ﾁｪｯｸ
            If optKubun0.Checked = True Then
                lblnFlg2 = True
            End If
            If optKubun1.Checked = True Then
                lblnFlg2 = True
            End If
            If optKubun2.Checked = True Then
                lblnFlg2 = True
            End If
            If optKubun3.Checked = True Then
                lblnFlg2 = True
            End If
            If optKubun4.Checked = True Then
                lblnFlg2 = True
            End If


            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝにﾁｪｯｸがある場合
            If lblnFlg2 = False Then
                lblnFlg = False
            End If
                
            '@数量ﾁｪｯｸ
            If txtNum.Enabled = True Then
                If txtNum.Text = vbNullString Then
                    lblnFlg = False
                End If
            End If
                
            '@理由ﾁｪｯｸ
            '@保留解除以外必須入力
            If optKubun3.Checked = False Then
                If cmbReason.Text = vbNullString Then
                    lblnFlg = False
                End If
            End If
                
            '@最終結果判定
            If lblnFlg = True Then
                cmdRegist.Enabled = True
            Else
                cmdRegist.Enabled = False
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmdRegist_Chk"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfPartLotList_Disp
    '機　能：部材一覧表示情報表示
    '引　数：ltypLotList：格納ﾃﾞｰﾀ
    '　　　：ltypLotListCnt：ﾃﾞｰﾀ件数
    '戻り値：なし
    '作成日：2004/05/07 (Fri) 17:22:06 Y.Yamagishi
    '更新日：2004/10/15 (Fri) 17:19:17 N.Kasai
    '備　考：2004/10/15 (Fri) 17:19:17 N.Kasai      ｿｰﾄ順保持機能追加
    '　　　：2005/12/06 (Tue) 11:26:15 S.Deguchi    不具合№3306の対応でﾃﾞｰﾀが存在する場合の処理に,退避合計数の初期化処理を追加
    Private Sub prvvsfPartLotList_Disp(ByRef ltypPartLotList As List(Of PartLotList), _
                                       ByVal ltypPartLotListCnt As Integer)
        
        Dim llngDoCnt   As Integer  'ｶｳﾝﾄ
        Dim llngCnt     As Integer  'ｶｳﾝﾄ
        Dim llngCnt2    As Integer  'ｶｳﾝﾄ
        
        Try
            
            With vsfPartLotList
                '@初期化
                RemoveHandler vsfPartLotList.BeforeRowColChange,AddressOf vsfPartLotList_BeforeRowColChange
                .Rows.Count = .Rows.Fixed
                AddHandler vsfPartLotList.BeforeRowColChange,AddressOf vsfPartLotList_BeforeRowColChange
                '@数量計算値を初期化
                mcurNum = 0
                
                If ltypPartLotListCnt = 0 Then
                    '@格納ﾃﾞｰﾀがない場合
                    '@ﾛｯｸ
                    .Enabled = False
                    '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ使用不可
                    cmdCopy.Enabled = False
                Else
                    '@格納ﾃﾞｰﾀがある場合
                    '@描画ﾛｯｸ
                    .Redraw = False

                    RemoveHandler vsfPartLotList.BeforeRowColChange,AddressOf vsfPartLotList_BeforeRowColChange
                    RemoveHandler vsfPartLotList.EnterCell,AddressOf vsfPartLotList_EnterCell
                    
                    '@行数設定
                    .Rows.Count = ltypPartLotListCnt + 1
                    
                    .Row = 0

                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 0
                    
                    '@部材一覧表示情報設定
                    Do While .Rows.Count - 1 > llngDoCnt
                        .SetData(llngDoCnt + 1, CMlngvsfPartLLColPrLotID, ltypPartLotList(llngDoCnt).strProductionLotId)        '製造ﾛｯﾄID
                        
                        If ltypPartLotList(llngDoCnt).strNum <> vbNullString Then
                            .SetData(llngDoCnt + 1, CMlngvsfPartLLColNum, Format$(CLng(ltypPartLotList(llngDoCnt).strNum), CPstrDateFormatKanma))   '受入数
                        Else
                            .SetData(llngDoCnt + 1, CMlngvsfPartLLColNum, ltypPartLotList(llngDoCnt).strNum)                                        '受入数
                        End If
                        
                        '@数量が空白の場合
                        If ltypPartLotList(llngDoCnt).strNum = vbNullString Then
                            mcurNum = mcurNum + 0
                        Else
                            mcurNum = mcurNum + ltypPartLotList(llngDoCnt).strNum                                               '受入数合計
                        End If
                        
                        .SetData(llngDoCnt + 1, CMlngvsfPartLLColDate, ltypPartLotList(llngDoCnt).strDate)                      '受入日時
                            
                        .SetData(llngDoCnt + 1, CMlngvsfPartLLColEmpID, ltypPartLotList(llngDoCnt).strEmpName)                  '受入担当
                            
                        .SetData(llngDoCnt + 1, CMlngvsfPartLLColCFLotID, ltypPartLotList(llngDoCnt).strShippingLotID)          '出荷ﾛｯﾄID
                            
                        .SetData(llngDoCnt + 1, CMlngvsfPartLLColBoardThickness, ltypPartLotList(llngDoCnt).strThicknessCode)   '板厚
                        
                        '@出荷ﾛｯﾄIDが空白ではない場合
                        If .GetData(llngDoCnt + 1, CMlngvsfPartLLColCFLotID) <> vbNullString Then
                            .SetData(llngDoCnt + 1, CMlngvsfPartLLColReworkCount, ltypPartLotList(llngDoCnt).strReworkCount)    'ﾘﾜｰｸ回数
                        End If
                        
                        .SetData(llngDoCnt + 1, CMlngvsfPartLLColLotID, ltypPartLotList(llngDoCnt).strLotID)                    '在庫ﾛｯﾄID
                        
                        '@状態が保留の場合は”保”を設定し、正常の場合は状態列は空白にする
                        If ltypPartLotList(llngDoCnt).strCurrentStatus = CPstrHoldSt Then
                            .SetData(llngDoCnt + 1, CMlngvsfPartLLColStatus, CPstrHo)                                           '状態
                        End If
                        
                        .SetData(llngDoCnt + 1, CMlngvsfPartLLColWKLotLastUpdate, ltypPartLotList(llngDoCnt).strLotLastUpdate)  '最終更新日時(非表示)
                        
                        '@状態が保留の場合
                        If ltypPartLotList(llngDoCnt).strCurrentStatus = CPstrHoldSt Then
                            .SetData(llngDoCnt + 1, CMlngvsfPartLLColWKReasonCode, ltypPartLotList(llngDoCnt).strReasonCode)    '理由ｺｰﾄﾞ(非表示)
                            
                            '@初期値ｾｯﾄ
                            llngCnt2 = 0
                            
                            '@保留名を取得
                            Do While mtypMasHoldItemList.lngListCnt - 1 >= llngCnt2
                                '@保留ｺｰﾄﾞIDが同じ場合
                                If ltypPartLotList(llngDoCnt).strReasonCode _
                                    = mtypMasHoldItemList.typeMasItem(llngCnt2).strItemID Then
                                    
                                    '@ﾘｽﾄに理由名(非表示)追加
                                    .SetData(llngDoCnt + 1, CMlngvsfPartLLColWKReasonCodeName, mtypMasHoldItemList.typeMasItem(llngCnt2).strItemName)   '理由名
                                                                                                    
                                End If
                                llngCnt2 = llngCnt2 + 1
                            Loop
                        End If
                        
                        '@ｾﾙ色変更(白色)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        Dim cellRange As CellRange = .GetCellRange(llngDoCnt + 1, CMlngvsfPartLLColTitle, llngDoCnt + 1, .Cols.Count - 2)
                        cellRange.Style = newStyle

                        '@ﾌｫﾝﾄ色変更(黒色)
                        newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack")
                        newStyle.ForeColor = Color.Black
                        cellRange = .GetCellRange(llngDoCnt + 1, CMlngvsfPartLLColTitle, llngDoCnt + 1, .Cols.Count - 2)
                        cellRange.Style = newStyle
                        
                        '@状態判定（ﾛｯﾄ保留）
                        If ltypPartLotList(llngDoCnt).strCurrentStatus = CPstrHoldSt Then
                            '@ﾊﾞｯｸｶﾗｰ変更(黄色)
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            cellRange = .GetCellRange(llngDoCnt + 1, CMlngvsfCellPaintColorStart, _
                                                   llngDoCnt + 1, .Cols.Count - 2)
                            cellRange.Style = newStyle                    '黄色
                        End If
                                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt + 1).Height = CMlngvsfPartLLHeight
                        
                        llngDoCnt = llngDoCnt + 1
                    Loop
                        
                    '@行表示
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        .Rows(llngCnt).Visible = True
                    Next llngCnt
                    
                    '@№設定
                    For llngDoCnt = 1 To .Rows.Count - 1
                        .SetData(llngDoCnt, CMlngvsfPartLLColNo, llngDoCnt)
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height = CMlngvsfPartLLHeight
                        '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                        .Cols(CMlngvsfPartLLColNo).TextAlign = TextAlignEnum.RightCenter      '右中央
                    Next llngDoCnt
                    
                    Dim llngRow As Integer = .Row
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                        .Row = llngRow
                    End If
                    
                    AddHandler vsfPartLotList.BeforeRowColChange,AddressOf vsfPartLotList_BeforeRowColChange
                    AddHandler vsfPartLotList.EnterCell,AddressOf vsfPartLotList_EnterCell

                    '@ｿｰﾄ検索用ｷｰ（在庫ID）がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@在庫IDが同じ場合
                            If .GetData(llngCnt, CMlngvsfPartLLColLotID) = mtypChgSort.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                                Call pubVsfBeforeSort(vsfPartLotList, CMlngvsfPartLLColNo)
                                
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                                Call pubVsfAfterSort(vsfPartLotList, CMlngvsfPartLLColNo)
                                
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        .TopRow = 0    '行
                        .Row = 0       'ｶﾚﾝﾄ行の移動
                    End If
                    '@描画ﾛｯｸ解除
                    .Redraw = True
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                    '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ使用可
                    cmdCopy.Enabled = True
                End If
                
                '@受入数合計を表示
                lblNum.Text = Format$(CLng(mcurNum), CPstrDateFormatKanma)

                '@情報取得日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
            
                '@該当件数ﾗﾍﾞﾙに取得件数を表示
                lblLotCnt.Text = Format(CInt(ltypPartLotListCnt), CPstrDateFormatKanma)
                
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfPartLotList_Disp"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：確定時の入力ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2004/05/12 (Wed) 12:27:15 Y.Yamagishi
    '更新日：2011/12/27 (Tue) 13:13:02 T.Oide
    '備　考：
    Private Function prvblnInput_Chk() As Boolean
        
        Try
            
            '@初期化
            prvblnInput_Chk = False
                                          
            '@部品種別選択ﾁｪｯｸ
            If cmbPartClass.Text = vbNullString Then
                '@"<TRM47W>$$部品種別が選択されていません。設定を見直してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0047)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@部品種別へｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbPartClass)
                Exit Function
            End If
            
            '@部品選択ﾁｪｯｸ
            If cmbPart.Text = vbNullString Then
                '@"<TRM48W>$$部品が選択されていません。設定を見直してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0048)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@部品へｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbPart)
                Exit Function
            End If
            
            '@数量の入力ﾁｪｯｸ
            '@数量が使用可能の場合
            If txtNum.Enabled = True Then
                If txtNum.Text = vbNullString Then
                    '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@数量入力欄へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(txtNum)
                    Exit Function
                End If
            End If

        '@↓2011/12/27 (Tue) 13:13:45 T.Oide **************************************************
        '@    '@処理区分選択ﾁｪｯｸ
        '@    If optKubun(CMlngLotReceiveFlg).Value = False And optKubun(CMlngLotTakeFlg).Value = False And _
        '@      optKubun(CMlngLotHoldFlg).Value = False And optKubun(CMlngLotReleaseFlg).Value = False Then
            
            '@処理区分選択ﾁｪｯｸ
            If optKubun0.Checked = False And _
               optKubun1.Checked = False And _
               optKubun2.Checked = False And _
               optKubun3.Checked = False And _
               optKubun4.Checked = False And _
               optKubun5.Checked = False Then
        '@↑2011/12/27 (Tue) 13:13:45 T.Oide **************************************************
              
                '@"<TRM64W>$$「処理区分」が設定されていません。設定を見直してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0064)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@処理区分(例外受入)へｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(optKubun0)
                Exit Function
            End If
                
            '@理由ｺｰﾄﾞ選択ﾁｪｯｸ
            '@保留解除以外必須入力
            If optKubun4.Checked = False Then
                If cmbReason.Text = vbNullString Then
                    '@"<TRM65W>$$「理由コード」が設定されていません。設定を見直してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0065)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@理由ｺｰﾄﾞへｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbReason)
                    Exit Function
                End If
            End If
            
            '@入力OK
            prvblnInput_Chk = True
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnInput_Chk"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvblnInvPartList_Sel
    '機　能：部材一覧情報取得処理
    '引　数：ltypPartLotList()：部材一覧取得情報格納
    '　　　：llngPartLotListCnt：部材一覧取得件数格納
    '戻り値：
    '作成日：2005/06/22 (Wed) 12:31:21 S.Deguchi
    '更新日：2005/06/22 (Wed) 12:31:21
    '備　考：
    Private Function prvblnInvPartList_Sel(ByRef ltypPartLotList As List(Of PartLotList), _
                                           ByRef llngPartLotListCnt As Integer) As Boolean

        Dim lblnAns         As Boolean          '汎用結果格納
        
        Try

            '@初期化
            prvblnInvPartList_Sel = False
            
            'NSYS 部材一覧取得成功/失敗ﾌﾗｸﾞ
            mblnInvPartList = False
            
            '@MSG[部材一覧]の実行【CPstrCD0A：部品ｺｰﾄﾞ別、CPstrCD0G：ﾍﾞﾝﾀﾞｰｸﾗｽID、CPstrCD3F：完成在庫以外】
            lblnAns = pubblnInvPartList_Sel(CMstrinv_partlistVer, _
                                            CPstrCD0A & CPstrCD0G & CPstrCD3F, _
                                            cmbPart.Value, _
                                            cmbPartClass.Value, _
                                            ltypPartLotList, _
                                            llngPartLotListCnt)
            '@結果判定
            If lblnAns = True Then
                '@一覧取得成功
                'NSYS 部材一覧取得成功
                mblnInvPartList = True

                '@成功を返す
                prvblnInvPartList_Sel = True
            Else
                '@部材一覧取得に失敗
                Exit Function
            End If

            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnInvPartList_Sel"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '@↓2012/01/24 (Tue) 12:11:18 T.Oide **************************************************共通関数pubGridFocus_Setに変更
    '@'関数名：prvFocus_Set
    '@'機　能：ﾌｫｰｶｽの戻り位置を設定
    '@'引　数：lobjControl: VSFlexGridオブジェクト
    '@'　　　：lstrKeyID：KeyID
    '@'　　　：llngKeyColNo：KeyIDのCol位置
    '@'　　　：llngTopRow：先頭行
    '@'戻り値：なし
    '@'作成日：2004/07/28 (Wed) 11:04:48 N.Kasai
    '@'更新日：2004/07/28 (Wed) 19:21:36 N.Kasai
    '@'備　考：ﾛｯﾄNoを検索してHitした場合は該当行にﾌｫｰｶｽｾｯﾄする。ない場合はｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
    '@Private Sub prvFocus_Set(ByVal lobjControl As VSFlexGrid, _
    '@                         ByVal lstrKeyID As String, _
    '@                         ByVal llngKeyColNo As Long, _
    '@                         ByVal llngTopRow As Long)
    '@
    '@    Dim llngRowCnt     As Long         'ｶｳﾝﾄ
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    With lobjControl
    '@        '@確定ﾎﾞﾀﾝ押下前のﾌｫｰｶｽ位置を検索
    '@        For llngRowCnt = 0 To .Rows - 1
    '@            '@ﾛｯﾄNo検索
    '@            If .Cell(flexcpText, llngRowCnt, llngKeyColNo) = lstrKeyID Then
    '@
    '@                '@行の選択範囲を設定
    '@                .Row = llngRowCnt
    '@
    '@                '@選択行を表示
    '@                .ShowCell llngRowCnt, llngKeyColNo
    '@                Exit Sub
    '@            End If
    '@        Next llngRowCnt
    '@
    '@        '@ﾌｫｰｶｽｾｯﾄ
    '@        '@明細行が１件もない場合ﾌｫｰｶｽの戻り位置を制御
    '@        If .Enabled = False Then
    '@            Call pubSetFocus(cmdClose)
    '@        Else
    '@            Call pubSetFocus(lobjControl)
    '@        End If
    '@    End With
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "prvFocus_Set"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2012/01/24 (Tue) 12:11:18 T.Oide **************************************************



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
End Class