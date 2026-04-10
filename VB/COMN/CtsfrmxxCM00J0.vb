'ﾌｧｲﾙ名：xxCM00J0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：分割元ロットID一覧/コピー元ロットID一覧　メインフォーム
'作成日：2004/02/18 (Wed) 17:33:31 M.Miura
'更新日：2011/05/09 (Mon) 09:42:14 T.Oide
'備　考：2008/09/04 (Thu) 09:58:08 T.Sawaguchi  異機種間ｺﾋﾟｰを禁止の為、機種ｺﾝﾎﾞを選択不可　(案件03141)
'　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00J0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00J0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00J0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00J0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00J0)
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
    '                                      *定数の記述*
    '***************************************************************************************
    '========================================Private========================================
    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM00J0              'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_travlistVer              As String = "03.01"                     '工順元ﾛｯﾄ一覧
    '@↓2011/05/09 (Mon) 10:45:39 T.Oide **************************************************
    'Private Const CMstrmas_flowlistVer              As String = "03.00"                     '種別区分一覧取得
    Private Const CMstrmas_flowlistVer              As String = "04.00"                     '種別区分一覧取得
    '@↑2011/05/09 (Mon) 10:45:39 T.Oide **************************************************
    '@↓2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    'Private Const CMstrmas_pdlist__Ver              As String = "02.02"                     '機種区分一覧取得
    Private Const CMstrmas_pdlist__Ver              As String = "03.00"                     '機種区分一覧取得
    '@↑2011/05/09 (Mon) 10:14:02 T.Oide **************************************************

    '@vsfLotPlanListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfLotListColNo              As Integer = 0                          '№
    Private Const CMlngvsfLotListColPlanDate        As Integer = 1                          '投入予実
    Private Const CMlngvsfLotListColLotID           As Integer = 2                          'ﾛｯﾄID
    Private Const CMlngvsfLotListColFlowClass       As Integer = 3                          '種別
    Private Const CMlngvsfLotListColStatus          As Integer = 4                          'ﾛｯﾄ状態
    Private Const CMlngvsfLotListColLotManagerName  As Integer = 5                          'ﾛｯﾄ担当者名
    Private Const CMlngvsfLotListColEntryID         As Integer = 6                          'ｴﾝﾄﾘ
    Private Const CMlngvsfLotListColPdID            As Integer = 7                          '機種ID
    Private Const CMlngvsfLotListColLotManagerID    As Integer = 8                          'ﾛｯﾄ担当者ID
    Private Const CMlngvsfLotListColEntryName       As Integer = 9                          'ｴﾝﾄﾘ名

    '@vsfLotListの定数宣言(表示幅)
    Private Const CMlngvsfLotListColWNo             As Integer = 40                         '№
    Private Const CMlngvsfLotListColWPlanDate       As Integer = 113                        '投入予実
    Private Const CMlngvsfLotListColWLotID          As Integer = 120                        'ﾛｯﾄID
    Private Const CMlngvsfLotListColWFlowClass      As Integer = 47                         '種別
    Private Const CMlngvsfLotListColWStatus         As Integer = 100                        'ﾛｯﾄ状態
    Private Const CMlngvsfLotListColWLotManagerName As Integer = 153                        'ﾛｯﾄ担当者名
    Private Const CMlngvsfLotListColWEntryID        As Integer = 117                        'ｴﾝﾄﾘ
    Private Const CMlngvsfLotListColWPdID           As Integer = 47                         '機種ID(非表示)
    Private Const CMlngvsfLotListColWLotManagerID   As Integer = 153                        'ﾛｯﾄ担当者ID(非表示)
    Private Const CMlngvsfLotListColWEntryName      As Integer = 77                         'ｴﾝﾄﾘ名

    '@vsfLotListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfLotListColNo              As String = "№"                        '№
    Private Const CMstrvsfLotListColPlanDate        As String = "投入予実"                   '投入予実
    Private Const CMstrvsfLotListColLotID           As String = "ロットID"                   'ﾛｯﾄID
    Private Const CMstrvsfLotListColFlowClass       As String = "種別"                      '種別
    Private Const CMstrvsfLotListColStatus          As String = "ロット状態"                'ﾛｯﾄ状態
    Private Const CMstrvsfLotListColLotManagerName  As String = "ロット担当"                'ﾛｯﾄ担当者名
    Private Const CMstrvsfLotListColEntryID         As String = "エントリ"                  'ｴﾝﾄﾘ
    Private Const CMstrvsfLotListColPDID            As String = "機種"                      '機種
    Private Const CMstrvsfLotListColLotManagerID    As String = "ロット担当者ID"            'ﾛｯﾄ担当者ID
    Private Const CMstrvsfLotListColEntryName       As String = "エントリ名"                'ｴﾝﾄﾘ名

    '@vsfLotListの定数宣言
    Private Const CMlngvsfLotListStartCol           As Integer = 0                          '開始列
    Private Const CMlngvsfLotListStartRow           As Integer = 0                          '開始行
    Private Const CMlngvsfLotListColm               As Integer = 10                         'ｶﾗﾑ数
    Private Const CMlngvsfLotListHFontSize          As Integer = 12                         'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ

    '@vsfLotListのﾛｯﾄ状態定数宣言
    Private Const CMstrBeforeFlow                   As String = "流動前"                    'ﾛｯﾄ状態：流動前
    Private Const CMstrFlow                         As String = "流動"                      'ﾛｯﾄ状態：流動中
    Private Const CMstrStop                         As String = "停止"                      'ﾛｯﾄ状態：停止中
    Private Const CMstrEnd                          As String = "終了"                      'ﾛｯﾄ状態：終了

    '@ｺﾝﾎﾞﾎﾞｯｸｽ定数宣言
    Private Const CMlngComboDispCols1               As Integer = 1                          '表示列数
    Private Const CMlngComboDispCols2               As Integer = 2                          '表示列数
    Private Const CMlngComboGetCol                  As Integer = 0                          '値取得列
    Private Const CMlngCmbGetCol5                   As Integer = 5                          'ﾊﾞｯｸｶﾗｰ格納Col
    Private Const CMlngComboFontSize                As Integer = 16                         'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboGridFontSize            As Integer = 16                         'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboRowHeight               As Integer = 43                         '行高さ
    Private Const CMlngComboAlignLeftCenter         As Integer = 1                          '左中央
    Private Const CMlngCmbEntryDispCols             As Integer = 2                          '表示列数

    '@横ｽｸﾛｰﾙ活性化ﾌﾗｸﾞの定数宣言
    Private Const CMlngSideScrollOnFlag             As Integer = 1                          '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag            As Integer = 2                          '横ｽｸﾛｰﾙ非活性化
    
    Private FrozenCols                              As Integer = 3                          'NSYS FrozenCols

    '***************************************************************************************
    '                                      *変数の記述*
    '***************************************************************************************
    '========================================Private========================================
    Private mintCalender                            As Short                                '0：開始日ｶﾚﾝﾀﾞｰ、1：終了日ｶﾚﾝﾀﾞｰ
    Private mtypLotList                             As List(Of typOpLotLst)                 '工順元ﾛｯﾄ一覧格納用
    Private mlngLotListCnt                          As Integer                              '工順元ﾛｯﾄ一覧件数
    Private mlngSideScrollFlag                      As Integer                              '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
    Private mtypChgSort                             As ChgSort                              'ｿｰﾄ保持用
    Private mtypProductList                         As List(Of ProductList)                 '機種一覧格納
    Private mlngProductCnt                          As Integer                              '機種一覧ｶｳﾝﾄ
    Private mtypDivisionList                        As List(Of DivisionList)                '種別一覧格納
    Private mlngDivisionCnt                         As Integer                              '種別一覧ｶｳﾝﾄ
    Private buttonProcessing                        As Boolean                              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                              'NSYS WindowCloseフラグ
    Private RowFlag                                 As Boolean                              'NSYS 選択行判定

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
        pubVsfMouseWheelManager_Set(vsfLotList, cmdUp, cmdDown, cmdLeft, cmdRight)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '***************************************************************************************
    '========================================Private========================================
    '関数名：Form_Load
    '機　能：初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/23 (Mon) 10:50:05 M.Miura
    '更新日：2005/08/01 (Mon) 13:21:27 N.Kasai
    '備　考：2004/10/15 (Fri) 09:59:28 M.Miura　　　ｿｰﾄ保持用構造体の初期化を追加
    '　　　：2005/08/01 (Mon) 13:21:27 N.Kasai  　　L/R表示追加
    '　　　：2008/09/05 (Fri) 06:24:08 T.Sawaguchi  異機種間ｺﾋﾟｰを禁止の為、機種ｺﾝﾎﾞを選択不可　(案件03141)
    Private Sub Form_Load()
        
        Dim lstrFormName        As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns             As Boolean      '汎用戻り値
        Dim lstrClassDivision   As String       '作成処理区分
        
        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            RowFlag = False
            '@暗黙でFormが表示されたかどうかを判定する
            If Not Me Is Me Then
            '@暗黙で表示されていない場合
                '@暗黙でFormをLoad
                _instance = New frmxxCM00J0
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@画面初期化
            Call prvFrmxxCM00J0_Init()
            
            '@ﾌｫｰﾑ,ｲﾍﾞﾝﾄ名称の取得
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@機種区分一覧取得
            lstrClassDivision = ptypCM00J0.strClassDivisionPdlist
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          lstrClassDivision, _
                                          mtypProductList, _
                                          mlngProductCnt, _
                                          pstrSBID)
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
                '@取得件数による処理
                If mlngProductCnt > 0 Then
                    '@機種ｺﾝﾎﾞ表示
                    Call prvcmbProductList_Disp()
                End If
            Else
            '@失敗の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@終了
                Exit Sub
            End If
            
            '@種別区分一覧取得
            lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                            mtypDivisionList, _
                                            mlngDivisionCnt, _
                                            pstrSBID, _
                                            CPstrCD02)
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
                '@取得件数による処理
                If mlngDivisionCnt > 0 Then
                    '@機種ｺﾝﾎﾞ表示
                    Call prvcmbDivisionList_Disp()
                End If
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
            '@失敗の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@終了
                Exit Sub
            End If
            
            '@親ﾌｫｰﾑからの情報をｾｯﾄ
            With ptypCM00J0
                '@機種ｺﾝﾎﾞのｲﾝﾃﾞｯｸｽ判定
                Select Case .lngListIndex
                    '@設定なしの場合
                    Case -1
                        '機種IDありの場合
                        If .strPdId <> vbNullString Then
                            '@親ﾌｫｰﾑの機種を選択
                            With cmbProduct
                                '@ｺﾝﾎﾞに値を表示
                                .Text = ptypCM00J0.strPdId
                                
        '@↓2008/09/05 (Fri) 06:20:48 T.Sawaguchi 案件03141 **************************
                                '@分割ﾛｯﾄID採番指定で呼ばれた時も機種ｺﾝﾎﾞを選択不可にする。
                                '@値取得(ﾊﾞｯｸｶﾗｰ値)
                                cmbProduct.ValueCol = CMlngCmbGetCol5
                                '@ﾊﾞｯｸｶﾗｰ値による背景色変更処理
                                If cmbProduct.Value <> vbNullString Then
                                    '@ﾊﾞｯｸｶﾗｰ反映
                                    cmbProduct.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(cmbProduct.Value))
                                Else
                                    cmbProduct.BackColor = Color.White
                                End If

                                '@投入予定工順登録(組立)から工順作成ﾁｪｯｸから呼ばれたかを判断
                                If ptypCM00J0.strUserProcessFlag = vbNullString Then
                                    '@機種ｺﾝﾎﾞは選択不可にする。
                                    cmbProduct.Enabled = False
                                Else
                                    '@機種ｺﾝﾎﾞは選択不可にする。
                                    cmbProduct.Enabled = True
                                End If
        '@↑2008/09/05 (Fri) 06:20:48 T.Sawaguchi 案件03141 **************************
                                                        
                                '@ﾌｫｰｶｽを次項目へ移動
                                .TabIndex = cmdClose.TabIndex + 1
                            End With
                        End If
                    
                    '@設定ありの場合
                    Case Else
                        '@機種ｺﾝﾎﾞにﾘｽﾄｲﾝﾃﾞｯｸｽを設定
                        cmbProduct.ListIndex = .lngListIndex
                        
                        '@値取得(ﾊﾞｯｸｶﾗｰ値)
                        cmbProduct.ValueCol = CMlngCmbGetCol5
                        '@ﾊﾞｯｸｶﾗｰ値による背景色変更処理
                        If cmbProduct.Value <> vbNullString Then
                            '@ﾊﾞｯｸｶﾗｰ反映
                            cmbProduct.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(cmbProduct.Value))
                        Else
                            cmbProduct.BackColor = Color.White
                        End If

        '@↓2008/09/04 (Thu) 14:56:25 T.Sawaguchi 案件03005 **************************
                        '@投入予定工順登録(組立)から工順作成ﾁｪｯｸから呼ばれたかを判断
                        If .strUserProcessFlag = vbNullString Then
                            '@機種ｺﾝﾎﾞは選択不可にする。
                            cmbProduct.Enabled = False
                        Else
                            '@機種ｺﾝﾎﾞは選択不可にする。
                            cmbProduct.Enabled = True
                        End If
        '@↑2008/09/04 (Thu) 14:56:25 T.Sawaguchi 案件03005 **************************
                        '@ﾌｫｰｶｽを次項目へ移動
                        cmbProduct.TabIndex = cmdClose.TabIndex + 1
                End Select
            End With
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
            '@Form_Loadﾌﾗｸﾞ(正常)
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

    '関数名：Form_KeyDown
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 12:37:01 M.Miura
    '更新日：2007/07/05 (Thu) 10:47:51 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 10:47:51 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If
            
            '@ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfLotList, cmdUP, cmdDown)
            
        '@↓2007/07/05 (Thu) 10:47:46 N.Kasai **************************************************
            '@ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ)
        '    Call prvSideKeyDown_Proc(KeyCode, ActiveControl.Name, vsfLotList, cmdLeft, cmdRight)
            '@ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ)
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfLotList, cmdLeft, cmdRight)
        '@↑2007/07/05 (Thu) 10:47:46 N.Kasai **************************************************
            
            '@ｸﾞﾘｯﾄﾞ以外の場合
            If ActiveControl.Name <> vsfLotList.Name Then
                Select Case e.KeyCode
                    '@Enterｷｰの場合
                    Case Keys.Return
                        '@次項目にﾌｫｰｶｽｾｯﾄ
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                End Select
            Else
                '@Enterｷｰの場合
                If e.KeyCode = Keys.Return AndAlso ActiveControl IsNot vsfLotList.Editor Then
                    '@確定ﾎﾞﾀﾝが無効の場合
                    If cmdRegist.Enabled = False Then
                        '@次項目にﾌｫｰｶｽｾｯﾄ
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    Else
                        '@ﾃﾞｰﾀ行の場合
                        If vsfLotList.Rows.Count > vsfLotList.Rows.Fixed Then
                            '@確定処理
                            Call cmdRegist_Click(Me, New EventArgs())
                        End If
                    End If
                End If
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
    '機　能：ﾌｫｰﾑのｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/05/25 (Tue) 14:05:05 S.Deguchi
    '更新日：2004/10/15 (Fri) 10:09:25 M.Miura
    '備　考：2004/10/15 (Fri) 10:09:25 M.Miura　ｿｰﾄ保持用構造体のｸﾘｱを追加
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

            'NSYS カレンダーを閉じたとき処理を抜ける
            If e.CloseReason = CloseReason.None Then
                e.Cancel = True
                Exit Sub
            End If

            '構造体のｸﾘｱ
            If Not mtypLotList Is Nothing Then
                mtypLotList.Clear()
            End If
            If Not mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList.Clear()
            End If
            If Not mtypProductList Is Nothing Then
                mtypProductList.Clear()
            End If
            If Not mtypDivisionList Is Nothing Then
                mtypDivisionList.Clear()
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

    '関数名：cmdClose_Click
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/23 (Mon) 10:49:19 M.Miura
    '更新日：2004/02/23 (Mon) 10:49:19
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
            
            '@ﾌｫｰﾑを閉じる
            Me.Close()
            
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

    '関数名：cmdLotSearch_Click
    '機　能：工順元Lot一覧取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/18 (Wed) 22:10:04 M.Miura
    '更新日：2004/02/18 (Wed) 22:10:04
    '備　考：
    Private Sub cmdLotSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotSearch.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            If vsfLotList.Row > 0 Then
                RowFlag = True
            Else
                RowFlag = False
            End If
            
            '@工順元Lot一覧取得処理へ
            Call prvblnLoTtravList_Sel()
            
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

    '関数名：cmdRegist_Click
    '機　能：frmxxEN0020にﾛｯﾄIDを表示する
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/23 (Mon) 10:47:31 M.Miura
    '更新日：2006/10/31 (Tue) 15:15:43 N.Kasai
    '備　考：
    '　　　：2006/10/31 (Tue) 15:15:43 N.Kasai      種別も引継ぎ
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@行が選択されていない場合は格納しない
            If vsfLotList.Row >= 1 Then
                ptypCM00J0.strLotID = vsfLotList.GetData(vsfLotList.Row, CMlngvsfLotListColLotID)          'ﾛｯﾄID
                ptypCM00J0.strFlowClass = vsfLotList.GetData(vsfLotList.Row, CMlngvsfLotListColFlowClass)  '種別
            End If
            
            '@ﾌｫｰﾑを閉じる
            Me.Close()
            
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

    '関数名：cmbProduct_Change
    '機　能：機種変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/01 (Fri) 16:56:45 N.Kasai
    '更新日：2004/10/15 (Fri) 10:23:20 M.Miura
    '備　考：2004/10/15 (Fri) 10:23:20 M.Miura　ｶﾚﾝﾄ行検索ｷｰの初期化
    Private Sub cmbProduct_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProduct.Change

        Try
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfLotList_Init()
            
            '@ﾎﾞﾀﾝﾁｪｯｸ
            Call prvcmdLotSearchEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProduct_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProduct_CloseUp
    '機　能：機種のCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/19 (Wed) 14:16:01 Y.Yamagishi
    '更新日：2004/09/30 (Thu) 19:49:41 M.Miura
    '備　考：2004/09/30 (Thu) 19:49:41 M.Miura　選択されていない場合は留まるように修正
    Private Sub cmbProduct_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProduct.CloseUp
        
        Try
            
            '@選択されていない場合は留まる
            If cmbProduct.Text = vbNullString Then
                Exit Sub
            End If

            '@機種のValidate処理
            RemoveHandler cmbProduct.Validating, AddressOf cmbProduct_Validate
            Call cmbProduct_Validate(Me, New CancelEventArgs(True))
            AddHandler cmbProduct.Validating, AddressOf cmbProduct_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProduct_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProduct_Validate
    '機　能：機種のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/19 (Wed) 13:48:44 Y.Yamagishi
    '更新日：2004/10/01 (Fri) 14:53:52 N.Kasai
    '備　考：2004/10/01 (Fri) 14:53:52 N.Kasai  mstrcmbProductを追加
    Private Sub cmbProduct_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbProduct.Validating

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@値取得(ﾊﾞｯｸｶﾗｰ値)
            cmbProduct.ValueCol = CMlngCmbGetCol5
            
            If cmbProduct.Value <> vbNullString Then
                '@ﾊﾞｯｸｶﾗｰ反映
                cmbProduct.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(cmbProduct.Value))
            Else
                cmbProduct.BackColor = Color.White
            End If
            
            If ActiveControl.Name = cmbProduct.Name Then
            
                '@ﾌｫｰｶｽ処理
                If cmbDivision.Enabled = True Then
                    Call pubSetFocus(cmbDivision)
                Else
                    '@機種を選択しているか否かでﾌｫｰｶｽを変更
                    If cmbProduct.Text = vbNullString Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProduct_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivision_Change
    '機　能：種別変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/01 (Fri) 16:56:17 N.Kasai
    '更新日：2004/10/15 (Fri) 10:23:50 M.Miura
    '備　考：2004/10/15 (Fri) 10:23:50 M.Miura　ｶﾚﾝﾄ行検索ｷｰの初期化
    Private Sub cmbDivision_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDivision.Change

        Try
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfLotList_Init()
            
            '@ﾎﾞﾀﾝﾁｪｯｸ
            Call prvcmdLotSearchEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbDivision_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivision_CloseUp
    '機　能：種別のCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/19 (Wed) 14:16:01 Y.Yamagishi
    '更新日：2004/09/30 (Thu) 19:48:59 M.Miura
    '備　考：2004/09/30 (Thu) 19:48:59 M.Miura　選択されていない場合は留まるように修正
    Private Sub cmbDivision_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDivision.CloseUp

        Try
            
            '@選択されていない場合は留まる
            If cmbDivision.Text = vbNullString Then
                Exit Sub
            End If

            '@機種のValidate処理
            RemoveHandler cmbDivision.Validating, AddressOf cmbDivision_Validate
            Call cmbDivision_Validate(Me, New CancelEventArgs(True))
            AddHandler cmbDivision.Validating, AddressOf cmbDivision_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbDivision_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivision_Validate
    '機　能：種別のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/19 (Wed) 13:48:44 Y.Yamagishi
    '更新日：2004/10/01 (Fri) 14:55:11 N.Kasai
    '備　考：2004/10/01 (Fri) 14:55:11 N.Kasai  mstrcmbDivision追加
    Private Sub cmbDivision_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbDivision.Validating

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If ActiveControl.Name = cmbDivision.Name Then
                '@ﾌｫｰｶｽ処理
                If dtpStartDate.Enabled = True Then
                    Call pubSetFocus(dtpStartDate)
                Else
                    '@機種を選択しているか否かでﾌｫｰｶｽを変更
                    If cmbDivision.Text = vbNullString Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbDivision_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpStartDate_CalendarSelect
    '機　能：開始ｶﾚﾝﾀﾞｰ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/01 (Fri) 14:13:09 N.Kasai
    '更新日：2004/10/01 (Fri) 14:13:09
    '備　考：
    Private Sub dtpStartDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles dtpStartDate.CalendarSelect

        Try
            
            '@ｶﾚﾝﾀﾞｰ変更処理へ
            RemoveHandler dtpStartDate.Validating, AddressOf dtpStartDate_Validate
            Call dtpStartDate_Validate(Me, New CancelEventArgs(True))
            AddHandler dtpStartDate.Validating, AddressOf dtpStartDate_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "dtpStartDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpStartDate_Change
    '機　能：開始日付変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/01 (Fri) 16:57:32 N.Kasai
    '更新日：2004/10/15 (Fri) 10:24:19 M.Miura
    '備　考：2004/10/15 (Fri) 10:24:19 M.Miura　ｶﾚﾝﾄ行検索ｷｰの初期化
    Private Sub dtpStartDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles dtpStartDate.Change

        Try
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfLotList_Init()
            
            '@ﾎﾞﾀﾝﾁｪｯｸ
            Call prvcmdLotSearchEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "dtpStartDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpStartDate_Validate
    '機　能：開始日のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/19 (Wed) 13:48:44 Y.Yamagishi
    '更新日：2004/10/01 (Fri) 14:56:17 N.Kasai
    '備　考：2004/10/01 (Fri) 14:56:17 N.Kasai  mstrdtpStartDateを追加
    Private Sub dtpStartDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles dtpStartDate.Validating

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@日付の有効性ﾁｪｯｸ
            '@日付が入力されている場合
            If dtpStartDate.Value <> CPstrNullDate Then
                '@日付ではない場合
                If pubblnYearRange_Chk(dtpStartDate.Value) = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                    
                    Exit Sub
                End If
                If ActiveControl.Name = dtpStartDate.Name Then

                    '@ﾌｫｰｶｽ移動
                    If dtpEndDate.Enabled = True Then
                        Call pubSetFocus(dtpEndDate)
                    End If
                End If

            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "dtpStartDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpEndDate_CalendarSelect
    '機　能：終了ｶﾚﾝﾀﾞｰ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/01 (Fri) 14:12:29 N.Kasai
    '更新日：2004/10/15 (Fri) 10:24:50 M.Miura
    '備　考：2004/10/15 (Fri) 10:24:50 M.Miura　ｶﾚﾝﾄ行検索ｷｰの初期化
    Private Sub dtpEndDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles dtpEndDate.CalendarSelect

        Try
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｶﾚﾝﾀﾞｰ変更処理へ
            RemoveHandler dtpEndDate.Validating, AddressOf dtpEndDate_Validate
            Call dtpEndDate_Validate(Me, New CancelEventArgs(True))
            AddHandler dtpEndDate.Validating, AddressOf dtpEndDate_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "dtpEndDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpEndDate_Change
    '機　能：終了日付変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/01 (Fri) 16:57:10 N.Kasai
    '更新日：2004/10/15 (Fri) 10:33:06 M.Miura
    '備　考：2004/10/15 (Fri) 10:33:06 M.Miura　ｶﾚﾝﾄ行検索ｷｰの初期化
    Private Sub dtpEndDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles dtpEndDate.Change

        Try
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfLotList_Init()
            
            '@ﾎﾞﾀﾝﾁｪｯｸ
            Call prvcmdLotSearchEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "dtpEndDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpEndDate_Validate
    '機　能：終了日のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/19 (Wed) 13:48:44 Y.Yamagishi
    '更新日：2004/10/01 (Fri) 14:57:51 N.Kasai
    '備　考：2004/10/01 (Fri) 14:57:51 N.Kasai  mstrdtpEndDateを追加
    Private Sub dtpEndDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles dtpEndDate.Validating

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@日付の有効性ﾁｪｯｸ
            '@日付が入力されている場合
            If dtpEndDate.Value <> CPstrNullDate Then
                '@日付ではない場合
                If pubblnYearRange_Chk(dtpEndDate.Value) = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                    Exit Sub
                End If
                
                '@開始日が指定されている場合大小ﾁｪｯｸ
                If dtpStartDate.Value <> CPstrNullDate Then
                    '@日付
                    If dtpStartDate.Value > dtpEndDate.Value Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                        '@"開始日が終了日より大きくなっています。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@ﾌｫｰｶｽを移さない
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                If ActiveControl.Name = dtpEndDate.Name Then

                    '@ﾌｫｰｶｽ移動
                    If cmdLotSearch.Enabled = True Then
                        Call pubSetFocus(cmdLotSearch)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "dtpEndDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 16:49:21 M.Miura
    '更新日：2004/10/15 (Fri) 10:02:29 M.Miura
    '備　考：2004/10/15 (Fri) 10:02:29 M.Miura　ｿｰﾄ順の格納を保持
    Private Sub vsfLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .typChgSortList.Add(New ChgSortList())
                .lngCnt = .lngCnt + 1

                'NSYS ローカル変数にコピー
                Dim typChgSortListTmp As ChgSortList = .typChgSortList(.lngCnt -1)
                
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                
                '@並び替え方法を格納(昇順/降順)
                typChgSortListTmp.lngOrder = e.Order

                'NSYS ローカル変数からリストへコピー
                .typChgSortList(.lngCnt -1) = typChgSortListTmp

            End With
            
            '@ｶﾚﾝﾄ行の設定(ｸﾞﾘｯﾄﾞ、保持列 [ ﾛｯﾄID ] )
            Call pubVsfAfterSort(vsfLotList, CMlngvsfLotListColLotID, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_AfterUserResize
    '機　能：列変更時処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 10:15:49 M.Miura
    '更新日：2007/07/09 (Mon) 12:13:27 N.Kasai
    '備　考：2004/10/15 (Fri) 10:01:34 M.Miura　列幅変更ﾌﾗｸﾞ変更の追加
    '　　　：2007/07/09 (Mon) 12:13:27 N.Kasai  ｸﾞﾘｯﾄﾞ共通化
    Private Sub vsfLotList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotList.AfterResizeColumn, vsfLotList.AfterResizeRow

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort.blnChgWidth = True
            
        '@↓2007/07/09 (Mon) 12:14:34 N.Kasai **************************************************
        '    With vsfLotList
        '        '@全列数の幅取得(非表示項目は含めない)
        '        For llngCnt = 0 To .Cols - 1
        '            '@非表示列ではない場合
        '            If .ColHidden(llngCnt) <> True Then
        '                llngWidthAll = llngWidthAll + .ColWidth(llngCnt)
        '            End If
        '        Next llngCnt
        '
        '        '@ｸﾞﾘｯﾄﾞ幅と比較して横ｽｸﾛｰﾙﾎﾞﾀﾝを活性化するか判断
        '        If .Width - llngWidthAll >= 0 Then
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=2:非活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOffFlag
        '
        '            '@右ｽｸﾛｰﾙ非活性化
        '            cmdRight.Enabled = False
        '        Else
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=1:活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOnFlag
        '
        '            '@右ｽｸﾛｰﾙ活性化
        '            cmdRight.Enabled = True
        '        End If
        '    End With
            
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            Call pubCmdLREnable_Set(vsfLotList, cmdLeft, cmdRight)
            
        '@↑2007/07/09 (Mon) 12:14:34 N.Kasai **************************************************

            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_BeforeRowColChange
    '機　能：行列変更前処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 10:04:23 M.Miura
    '更新日：2004/10/15 (Fri) 10:04:23
    '備　考：
    Private Sub vsfLotList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotList.BeforeRowColChange
                                              
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.TopRow <> e.NewRange.TopRow And e.NewRange.TopRow > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｬﾘｱID)
                mtypChgSort.strKey = vsfLotList.GetData(e.NewRange.TopRow, CMlngvsfLotListColLotID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 16:47:19 M.Miura
    '更新日：2004/04/14 (Wed) 16:47:19
    '備　考：
    Private Sub vsfLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列 [ ﾛｯﾄID ] )
            Call pubVsfBeforeSort(vsfLotList, CMlngvsfLotListColLotID)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_DblClick
    '機　能：一覧ﾀﾞﾌﾞﾙｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 12:40:15 M.Miura
    '更新日：2004/03/10 (Wed) 12:40:15
    '備　考：
    Private Sub vsfLotList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.DoubleClick

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸした場合
            If vsfLotList.MouseRow = 0 Then
                Exit Sub
            End If
            
            '@選択確定処理
            Call cmdRegist_Click(Me, New EventArgs())
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_EnterCell
    '機　能：ｸﾞﾘｯﾄﾞ移動
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/26 (Tue) 15:57:04 N.Kasai
    '更新日：2005/07/26 (Tue) 15:57:04
    '備　考：
    Private Sub vsfLotList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.EnterCell

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If
            
            '@確定ﾎﾞﾀﾝ使用可否判定
            With vsfLotList
                If .Row > 0 Then
                    '@使用可
                    cmdRegist.Enabled = True
                Else
                    '@使用不可
                    cmdRegist.Enabled = False
                End If
            End With


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUP_Click
    '機　能：前ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 10:54:28 M.Miura
    '更新日：2004/03/10 (Wed) 10:54:28
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

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfLotList, cmdUP, cmdDown)
            
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
    '機　能：次ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 10:54:42 M.Miura
    '更新日：2004/03/10 (Wed) 10:54:42
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

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfLotList, cmdUP, cmdDown)
            
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

    '関数名：cmdLeft_Click
    '機　能：左一項目移動
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 18:01:00 S.Deguchi
    '更新日：2007/07/05 (Thu) 10:49:37 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 10:49:37 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub cmdLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2007/07/05 (Thu) 10:49:32 N.Kasai **************************************************
            '@左ｽｸﾛｰﾙ処理←
        '    Call prvcmdLeft_Proc(vsfLotList, cmdLeft, cmdRight)
            Call pubVsfCmdLeft(vsfLotList, cmdLeft, cmdRight)
        '@↑2007/07/05 (Thu) 10:49:32 N.Kasai **************************************************

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
    '機　能：右一項目移動
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/13 (Tue) 18:01:02 S.Deguchi
    '更新日：2007/07/05 (Thu) 10:50:04 N.Kasai
    '備　考：
    '　　　：2007/07/05 (Thu) 10:50:04 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub cmdRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2007/07/05 (Thu) 10:50:01 N.Kasai **************************************************
            '@右ｽｸﾛｰﾙ処理→
        '    Call prvcmdRight_Proc(vsfLotList, cmdLeft, cmdRight)
            Call pubVsfCmdRight(vsfLotList, cmdLeft, cmdRight)
        '@↑2007/07/05 (Thu) 10:50:01 N.Kasai **************************************************

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

    '***************************************************************************************
    '                              　　    *関数の記述*
    '***************************************************************************************
    '========================================Private========================================
    '関数名：prvFrmxxCM00J0_Init
    '機　能：画面初期設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/18 (Wed) 15:58:23 M.Miura
    '更新日：2009/12/09 (Wed) 12:54:15 H.Hayashi
    '備　考：
    '　　　：2005/07/26 (Tue) 10:22:56 N.Kasai      L/R色追加
    '　　　：2009/02/25 (Wed) 19:33:56 N.Kojima     ﾁｯﾌﾟ品判別説明ﾗﾍﾞﾙの制御処理追加。(案件№03402)
    '      ：2009/12/09 (Wed) 12:55:12 H.Hayashi    基板の場合ﾁｯﾌﾟ品説明の非表示に対応。
    Private Sub prvFrmxxCM00J0_Init()
        
        Dim lctlControl         As Control                              'ｺﾝﾄﾛｰﾙ名称
        Dim lstrStartDate       As String                               '開始日設定
        Dim lstrEndDate         As String                               '終了日設定
        
        Try
            
            '@-----------------------
            '@ ﾗﾍﾞﾙ初期設定
            '@-----------------------
            '@起動SBが組立か
            If pstrSBID = CPstrSBID2A0 Then
                '@2A0：組立の場合
            
                lblTitleL.BackColor = ColorTranslator.FromWin32(CPlngLColor)    '機種L
                lblTitleR.BackColor = ColorTranslator.FromWin32(CPlngRColor)    '機種R
                lblTitleL.Visible = True
                lblTitleR.Visible = True
                lblTitleChip.Visible = True                             'ﾁｯﾌﾟ品説明
            Else
                '@1A0：基板の場合
            
                lblTitleL.Visible = False
                lblTitleR.Visible = False
        '@↓2009/12/09 (Wed) 12:53:14 H.Hayashi **************************************************
        '        lblTitleChip.Visible = True                             'ﾁｯﾌﾟ品説明
                lblTitleChip.Visible = False                            'ﾁｯﾌﾟ品説明
        '@↑2009/12/09 (Wed) 12:53:14 H.Hayashi **************************************************
            End If
            
            '@情報取得日時初期化
            lblNowDate.Text = vbNullString
            
            '@該当件数初期化
            lblLotCnt.Text = vbNullString
            
            '@終了日設定
            lstrEndDate = Format$(Now, CPstrDateTimeYMD)

            '@開始日設定(１ヶ月前を設定)
            lstrStartDate = Format$(DateAdd("m", -1, lstrEndDate), CPstrDateTimeYMD)
            
            '@ﾌﾗｸﾞの初期化
            mlngSideScrollFlag = 0
            
            'ｺﾝﾄﾛｰﾙの初期化
            '@ｺﾝﾎﾞﾎﾞｯｸｽの初期化
            Dim all As Control() = GetAllControls(Me)
            For Each lctlControl In all
                '@ﾌｫｰﾑ上のｺﾝﾄﾛｰﾙに対して処理を行う
                If TypeOf lctlControl Is SEComboBoxEx.ComboBoxEx Then
                    '@ｺﾝﾄﾛｰﾙがComboBoxExの場合
                    With CType(lctlControl, SEComboBoxEx.ComboBoxEx)
                        '@ｺﾝﾎﾞﾎﾞｯｸｽ初期化
                        .DirectInput = False                            'ﾃｷｽﾄ直接入力
                        .DispCols = CMlngComboDispCols1                 '表示列数
                        .GetCol = CMlngComboGetCol                      '値取得列
                        .Font = New Font(.Font.FontFamily, CType(CMlngComboFontSize, Single))           'ﾌｫﾝﾄｻｲｽﾞ
                        .GridFont = New Font(.Font.FontFamily, CType(CMlngComboGridFontSize, Single))   'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                        .RowHeight = CMlngComboRowHeight                '行高さ
                    End With
                End If
            Next
            
            '@開始日ｶﾚﾝﾀﾞｰの初期化
            Call pubblnCalendar_Init(dtpStartDate, CPlngCalModeFlow, lstrStartDate)
            
            '@終了日ｶﾚﾝﾀﾞｰの初期化
            Call pubblnCalendar_Init(dtpEndDate, CPlngCalModeFlow, lstrEndDate)
            
            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfLotList_Init()
            
            '@ﾍﾟｰｼﾞ切替ﾎﾞﾀﾝﾛｯｸ
            cmdUP.Enabled = False                                       'ﾍﾟｰｼﾞｱｯﾌﾟ
            cmdDown.Enabled = False                                     'ﾍﾟｰｼﾞﾀﾞｳﾝ
            cmdRight.Enabled = False                                    '右ｽｸﾛｰﾙ
            cmdLeft.Enabled = False                                     '左ｽｸﾛｰﾙ
            
            '@検索ﾎﾞﾀﾝ使用不可
            cmdLotSearch.Enabled = False
            
            '@確定ﾎﾞﾀﾝﾛｯｸ
            cmdRegist.Enabled = False

            'NSYS 初期画面位置設定
            Me.Left = 0 - My.Settings.FormOffset
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxCM00J0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbProductList_Disp
    '機　能：機種ｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/08 (Tue) 14:33:35 S.Deguchi
    '更新日：2005/11/08 (Tue) 14:33:35
    '備　考：
    Private Sub prvcmbProductList_Disp()

        Dim llngCnt     '汎用ｶｳﾝﾀ
        
        Try

            '@機種ｺﾝﾎﾞ作成
            With cmbProduct
                For llngCnt = 0 To mlngProductCnt - 1
                    '@ｱｲﾃﾑ追加
                    .AddItem(mtypProductList(llngCnt).strProductID _
                           & vbTab _
                           & vbNullString _
                           & vbTab _
                           & vbNullString _
                           & vbTab _
                           & vbNullString _
                           & vbTab _
                           & mtypProductList(llngCnt).strForeColor _
                           & vbTab _
                           & mtypProductList(llngCnt).strBackColor)
                Next llngCnt
            
                '@機種が１件の場合は表示
                If .ListCount = 1 Then
                    .ListIndex = 0
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbProductList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbDivisionList_Disp
    '機　能：種別ｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/08 (Tue) 14:42:13 S.Deguchi
    '更新日：2005/11/08 (Tue) 14:42:13
    '備　考：
    Private Sub prvcmbDivisionList_Disp()

        Dim llngCnt     '汎用ｶｳﾝﾀ
        
        Try

            '@機種ｺﾝﾎﾞ作成
            With cmbDivision
                For llngCnt = 0 To mlngDivisionCnt - 1
                    '@ｱｲﾃﾑ追加
                    .AddItem(mtypDivisionList(llngCnt).strDivisionID)
                Next llngCnt
            
                '@機種が１件の場合は表示
                If .ListCount = 1 Then
                    .ListIndex = 0
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbDivisionList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotList_Init
    '機　能：vsfLotListの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/23 (Mon) 10:51:38 M.Miura
    '更新日：2008/06/10 (Tue) 13:56:28 N.Kojima
    '備　考：
    '　　　：2004/10/15 (Fri) 10:10:14 M.Miura　    列幅変更判定追加
    '　　　：2008/06/10 (Tue) 13:56:28 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvvsfLotList_Init()

        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfLotList
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@ｸﾞﾘｯﾄﾞの幅設
                .Rows.Count = 1
                .Cols.Count = CMlngvsfLotListColm
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@一覧表の表題設定
                .SelectionMode = SelectionModeEnum.Row
                .Select(CMlngvsfLotListStartRow, CMlngvsfLotListStartCol, CMlngvsfLotListStartRow, .Cols.Count - 1)
                .Styles.Fixed.ForeColor = Color.Yellow                                                                  '文字色
                .Styles.Fixed.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                                     '背景色
                .Styles.Fixed.Font = New Font(.Font.Name, CType(CMlngvsfLotListHFontSize, Single))                      'ﾌｫﾝﾄｻｲｽﾞ
                
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfLotListColNo).Width = CMlngvsfLotListColWNo                                           '№
                    .Cols(CMlngvsfLotListColPlanDate).Width = CMlngvsfLotListColWPlanDate                               '投入予実
                    .Cols(CMlngvsfLotListColLotID).Width = CMlngvsfLotListColWLotID                                     'ﾛｯﾄID
                    .Cols(CMlngvsfLotListColFlowClass).Width = CMlngvsfLotListColWFlowClass                             '種別
                    .Cols(CMlngvsfLotListColStatus).Width = CMlngvsfLotListColWStatus                                   'ﾛｯﾄ状態
                    .Cols(CMlngvsfLotListColLotManagerName).Width = CMlngvsfLotListColWLotManagerName                   'ﾛｯﾄ担当者名
                    .Cols(CMlngvsfLotListColEntryID).Width = CMlngvsfLotListColWEntryID                                 'ｴﾝﾄﾘID
                    .Cols(CMlngvsfLotListColPdID).Width = CMlngvsfLotListColWPdID                                       '機種
                    .Cols(CMlngvsfLotListColLotManagerID).Width = CMlngvsfLotListColWLotManagerID                       'ﾛｯﾄ担当者ID
                    .Cols(CMlngvsfLotListColEntryName).Width = CMlngvsfLotListColWEntryName                             'ｴﾝﾄﾘ名
                End If
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfLotListColNo, CMlngvsfLotListColNo, CMstrvsfLotListColNo)                        '№
                .SetData(CMlngvsfLotListColNo, CMlngvsfLotListColPlanDate, CMstrvsfLotListColPlanDate)            '投入予実
                .SetData(CMlngvsfLotListColNo, CMlngvsfLotListColLotID, CMstrvsfLotListColLotID)                  'ﾛｯﾄID
                .SetData(CMlngvsfLotListColNo, CMlngvsfLotListColFlowClass, CMstrvsfLotListColFlowClass)          '種別
                .SetData(CMlngvsfLotListColNo, CMlngvsfLotListColStatus, CMstrvsfLotListColStatus)                'ﾛｯﾄ状態
                .SetData(CMlngvsfLotListColNo, CMlngvsfLotListColLotManagerName, CMstrvsfLotListColLotManagerName) 'ﾛｯﾄ担当者名
                .SetData(CMlngvsfLotListColNo, CMlngvsfLotListColEntryID, CMstrvsfLotListColEntryID)              'ｴﾝﾄﾘID
                .SetData(CMlngvsfLotListColNo, CMlngvsfLotListColPdID, CMstrvsfLotListColPDID)                    '機種
                .SetData(CMlngvsfLotListColNo, CMlngvsfLotListColLotManagerID, CMstrvsfLotListColLotManagerID)    'ﾛｯﾄ担当者ID
                .SetData(CMlngvsfLotListColNo, CMlngvsfLotListColEntryName, CMstrvsfLotListColEntryName)          'ｴﾝﾄﾘ名
                
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@ｵｰﾄｻｲｽﾞを設定(幅)
                    '.AutoSizeMode = flexAutoSizeColWidth
                End If
                
                '@固定列設定(ﾛｯﾄID)
                .Cols.Frozen = CMlngvsfLotListColLotID + 1
                
                .Styles.Fixed.Trimming = StringTrimming.None
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@非表示設定
                .Cols(CMlngvsfLotListColPdID).Visible = False           '機種
                .Cols(CMlngvsfLotListColLotManagerID).Visible = False   'ﾛｯﾄ担当者ID
                
                '@列幅変更可
                .AllowResizing = AllowResizingEnum.Columns
                
                '@描画ﾛｯｸ解除
                .Redraw = True
                
                '@ﾛｯｸ
                .Enabled = False
                
            End With
            
            cmdUP.Enabled = False                                   'ｽｸﾛｰﾙ上
            cmdDown.Enabled = False                                 'ｽｸﾛｰﾙ下
            cmdLeft.Enabled = False                                 'ｽｸﾛｰﾙ左
            cmdRight.Enabled = False                                'ｽｸﾛｰﾙ右
            cmdRegist.Enabled = False                               '確定ﾎﾞﾀﾝ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：分割元ﾛｯﾄID一覧/ｺﾋﾟｰ元ﾛｯﾄID一覧作成処理
    '引　数：ltypOpLotLst() ：分割元ﾛｯﾄID/ｺﾋﾟｰ元ﾛｯﾄID格納構造体
    '　　　：llngCnt        ：構造体の配列の数
    '戻り値：なし
    '作成日：2004/02/18 (Wed) 18:17:48 M.Miura
    '更新日：2009/12/02 (Wed) 10:48:56 H.Hayashi
    '備　考：
    '　　　：2004/10/19 (Tue) 10:25:11 Y.Yamagishi　ﾒｯｾｰｼﾞﾎﾞｯｸｽの0件表示をしない(不具合改善対応№87)
    '　　　：2005/08/01 (Mon) 13:23:54 N.Kasai      L/R表示追加
    '　　　：2007/07/09 (Mon) 13:02:05 N.Kasai      ｸﾞﾘｯﾄﾞ共通化
    '　　　：2008/06/10 (Tue) 13:43:25 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/25 (Wed) 11:52:25 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。(案件№03402)
    '　　　：2009/12/02 (Wed) 10:48:56 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    Private Sub prvvsfLotList_Disp(ByRef ltypOpLotLst As List(Of typOpLotLst), ByVal llngCnt As Integer)
        
        Dim llngDoCnt           As Integer      'Doの回数ｶｳﾝﾄ
        Dim lstrLotStatus       As String       '流動状態格納

        Try
            
            '@***********************
            '@　ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ作成
            '@***********************
            With vsfLotList

                .Redraw = True        '描画ﾛｯｸ
                .Rows.Count = llngCnt + 1         '行数設定
                
                '@ｶｳﾝﾀの初期化
                llngDoCnt = 1
                Dim newStyleL As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor")
                newStyleL.BackColor = ColorTranslator.FromWin32(CPlngLColor)
                Dim newStyleR As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor")
                newStyleR.BackColor = ColorTranslator.FromWin32(CPlngRColor)
                Dim newStyleW As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                newStyleW.BackColor = Color.White
                Dim cellRangeL As CellRange
                Dim cellRangeR As CellRange
                Dim cellRangeW As CellRange
                Do While .Rows.Count > llngDoCnt

                    .SetData(llngDoCnt, CMlngvsfLotListColNo, llngDoCnt)                         '№
                    If ltypOpLotLst(llngDoCnt - 1).strEntryDate <> vbNullString Then
                        .SetData(llngDoCnt, CMlngvsfLotListColPlanDate, _
                                 Format$(CType(ltypOpLotLst(llngDoCnt - 1).strEntryDate,Date), CPstrDateTimeYMD))     '投入予実
                    Else
                        .SetData(llngDoCnt, CMlngvsfLotListColPlanDate, ltypOpLotLst(llngDoCnt - 1).strEntryDate)
                    End If
                    
                    .SetData(llngDoCnt, CMlngvsfLotListColLotID, _
                        ltypOpLotLst(llngDoCnt - 1).strLotID)                                    'ﾛｯﾄID
                    .SetData(llngDoCnt, CMlngvsfLotListColFlowClass, _
                        ltypOpLotLst(llngDoCnt - 1).strDivisionID)                               '種別
                    
                    '@★ ﾛｯﾄ状態ﾌﾗｸﾞにより処理分岐 ★
                    Select Case ltypOpLotLst(llngDoCnt - 1).strLotStatusFLG
                    
                        '@〓 0：流動前 〓
                        Case 0
                        
                            lstrLotStatus = CMstrBeforeFlow
                        
                        '@〓 1：流動中 〓
                        Case 1
                            
                            lstrLotStatus = CMstrFlow
                        
                        '@〓 2：停止 〓
                        Case 2
                            
                            lstrLotStatus = CMstrStop
                        
                        '@〓 3：ﾛｯﾄ終了 〓
                        Case 3
                            
                            lstrLotStatus = CMstrEnd
                        
                        '@〓 その他 〓
                        Case Else
                            
                            lstrLotStatus = vbNullString
                    
                    End Select
                    .SetData(llngDoCnt, CMlngvsfLotListColStatus, lstrLotStatus)    'ﾛｯﾄ状態

                    .SetData(llngDoCnt, CMlngvsfLotListColLotManagerName, _
                        ltypOpLotLst(llngDoCnt - 1).strTexhManNmae)                 'ﾛｯﾄ担当者名
                    .SetData(llngDoCnt, CMlngvsfLotListColEntryID, _
                        ltypOpLotLst(llngDoCnt - 1).strEntryID)                     'ｴﾝﾄﾘ
                    .SetData(llngDoCnt, CMlngvsfLotListColPdID, _
                        ltypOpLotLst(llngDoCnt - 1).strProductID)                   '機種
                    .SetData(llngDoCnt, CMlngvsfLotListColLotManagerID, _
                        ltypOpLotLst(llngDoCnt - 1).strEmpID)                       'ﾛｯﾄ担当者ID
                    .SetData(llngDoCnt, CMlngvsfLotListColEntryName, _
                        ltypOpLotLst(llngDoCnt - 1).strEntryName)                   'ｴﾝﾄﾘ名
                    
                    '@★ L/Rﾌﾗｸﾞ(液晶方向)により処理分岐 ★　※組立限定機能
                    Select Case ltypOpLotLst(llngDoCnt - 1).strLcDirection
                        
                        '@〓 L 〓
                        Case CPstrPDIDL
                        
                            '@ｾﾙ背景色を水色(Lｶﾗｰ)に変更
                            cellRangeL = .GetCellRange(llngDoCnt, CMlngvsfLotListStartCol, llngDoCnt, .Cols.Count - 1)
                            cellRangeL.Style = newStyleL
                        
                        '@〓 R 〓
                        Case CPstrPDIDR
                        
                            '@ｾﾙ背景色をﾋﾟﾝｸ(Rｶﾗｰ)に変更
                            cellRangeR = .GetCellRange(llngDoCnt, CMlngvsfLotListStartCol, llngDoCnt, .Cols.Count - 1)
                            cellRangeR.Style = newStyleR
                        
                        '@〓 その他 〓
                        Case Else
                        
                            '@ｾﾙ背景色を白(通常ｶﾗｰ)に変更
                            cellRangeW = .GetCellRange(llngDoCnt, CMlngvsfLotListStartCol, llngDoCnt, .Cols.Count - 1)
                            cellRangeW.Style = newStyleW

                    End Select
                    
        '@↓2009/02/24 (Tue) 15:48:35 N.Kojima **************************************************

                    '@-----------------------------------------------
                    '@ ﾌｫﾝﾄ色の設定(組立限定機能)
                    '@　①ﾁｯﾌﾟ品LOT：青色
                    '@-----------------------------------------------
        '@↓2009/12/02 (Wed) 10:50:12 H.Hayashi **************************************************
                    '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"か
        '           If pstrSBID = CPstrSBID2A0 And _
        '               Left$(ltypOpLotLst(llngDoCnt).strSendSBID, 1) = CPstrProductChip Then
                    
                    If pstrSBID = CPstrSBID2A0 And _
                        ltypOpLotLst(llngDoCnt - 1).strSbArea = CPstrProductChip Then
                        
                        '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
        '@↑2009/12/02 (Wed) 10:50:12 H.Hayashi **************************************************
                        
                        '@文字色を青色に変更
                        Dim newStyleLB As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor_ForeColor_vbBlue")
                        newStyleLB.BackColor = ColorTranslator.FromWin32(CPlngLColor)
                        newStyleLB.ForeColor = Color.Blue

                        Dim newStyleRB As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor_ForeColor_vbBlue")
                        newStyleRB.BackColor = ColorTranslator.FromWin32(CPlngRColor)
                        newStyleRB.ForeColor = Color.Blue

                        Dim newStyleWB As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite_ForeColor_vbBlue")
                        newStyleWB.BackColor = Color.White
                        newStyleWB.ForeColor = Color.Blue

                        Dim cellRangeLB As CellRange
                        Dim cellRangeRB As CellRange
                        Dim cellRangeWB As CellRange

                        Select Case ltypOpLotLst(llngDoCnt - 1).strLcDirection
                        
                            '@〓 L 〓
                            Case CPstrPDIDL
                                
                                '@ｾﾙ背景色を水色(Lｶﾗｰ)に変更
                                cellRangeLB = .GetCellRange(llngDoCnt, CMlngvsfLotListColNo, llngDoCnt, CMlngvsfLotListColEntryName)
                                cellRangeLB.Style = newStyleLB
                            
                            '@〓 R 〓
                            Case CPstrPDIDR
                            
                                '@ｾﾙ背景色をﾋﾟﾝｸ(Rｶﾗｰ)に変更
                                cellRangeRB = .GetCellRange(llngDoCnt, CMlngvsfLotListColNo, llngDoCnt, CMlngvsfLotListColEntryName)
                                cellRangeRB.Style = newStyleRB
                            
                            '@〓 その他 〓
                            Case Else
                            
                                '@ｾﾙ背景色を白(通常ｶﾗｰ)に変更
                                cellRangeWB = .GetCellRange(llngDoCnt, CMlngvsfLotListColNo, llngDoCnt, CMlngvsfLotListColEntryName)
                                cellRangeWB.Style = newStyleWB

                        End Select
                        
                    End If

        '@↑2009/02/24 (Tue) 15:48:35 N.Kojima **************************************************
                    
                    '@ﾙｰﾌﾟｶｳﾝﾀを+1する
                    llngDoCnt = llngDoCnt + 1
                Loop
                
                If .Rows.Count > .Rows.Fixed Then
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '@ｵｰﾄｻｲｽﾞ設定
                        .AutoSizeCols(CMlngvsfLotListColPlanDate, CMlngvsfLotListColEntryName, 7)
                    End If
                End If
                
                '@ﾃﾞｰﾀ行が存在するか
                If .Rows.Count > 1 Then
                    
                    '@ｸﾞﾘｯﾄﾞ選択の初期化(ｸﾞﾘｯﾄﾞ共通化関数)
                    Call pubVsfDisp(vsfLotList, cmdUP, cmdDown)
                    
                    '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                    Call pubCmdLREnable_Set(vsfLotList, cmdLeft, cmdRight)
                    
                    Dim laryColSort(CMlngvsfLotListColPdID) As SortFlags
                    Dim llngColCnt                          As Integer
    
                    'NSYS 前回の「投入予定日」～「機種ID」(非表示)列ごとのソート状態を保存
                    For llngColCnt = CMlngvsfLotListColPlanDate To CMlngvsfLotListColPdID
                        laryColSort(llngColCnt) = .Cols(llngColCnt).Sort
                    Next

                    '@投入予定日の降順に設定
                    .Cols(CMlngvsfLotListColPlanDate).Sort = SortFlags.Descending
                    .Cols(CMlngvsfLotListColLotID).Sort = SortFlags.Ascending
                    .Cols(CMlngvsfLotListColPdID).Sort = SortFlags.Ascending
                    .Cols(CMlngvsfLotListColFlowClass).Sort = SortFlags.Ascending
                    .Cols(CMlngvsfLotListColLotManagerName).Sort = SortFlags.Ascending
                    
                    'NSYS 「投入予定日」～「機種ID」(非表示)列をソート
                    .Sort(SortFlags.UseColSort, CMlngvsfLotListColPlanDate, CMlngvsfLotListColPdID)

                    'NSYS 前回の列ごとのソート状態を復元
                    For llngColCnt = CMlngvsfLotListColPlanDate To CMlngvsfLotListColPdID
                        .Cols(llngColCnt).Sort = laryColSort(llngColCnt)
                    Next
                    
                Else
                    '@確定ﾎﾞﾀﾝﾛｯｸ
                    cmdRegist.Enabled = False
                    
                    '@情報取得日時表示
                    lblNowDate.Text = Format$(Now, CPstrDateFormat)
                    
                    '@該当件数初期化
                    lblLotCnt.Text = 0
                    
                    Exit Sub
                End If
                
                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort.lngCnt - 1
                        '@該当行をｿｰﾄ
                        RemoveHandler vsfLotList.BeforeRowColChange,AddressOf vsfLotList_BeforeRowColChange
                        .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        AddHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange
                    Next llngCnt
                End If
                
                '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がある場合
                If mtypChgSort.strKey <> vbNullString And RowFlag = True Then
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@ｷｬﾘｱID、大工程、小工程が同じ場合
                        If .GetData(llngCnt, CMlngvsfLotListColLotID) = mtypChgSort.strKey Then
                            '@行指定
                            RemoveHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange
                            .Row = llngCnt
                            AddHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange
                            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列 [ ﾛｯﾄID ] )
                            Call pubVsfBeforeSort(vsfLotList, CMlngvsfLotListColLotID)
                            
                            '@ｶﾚﾝﾄ行の設定(ｸﾞﾘｯﾄﾞ、保持列 [ ﾛｯﾄID ] )
                            Call pubVsfAfterSort(vsfLotList, CMlngvsfLotListColLotID, cmdUP, cmdDown)
                            
                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@ｶﾚﾝﾄ行を初期化
                    RemoveHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange
                    .Row = .Rows.Fixed - 1
                    AddHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange
                    .TopRow = .Rows.Fixed
                End If
                
                '@ｶﾚﾝﾄ列を初期化
                .Col = .Cols.Fixed
                .LeftCol = .Cols.Fixed
                        
                '@情報取得日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                
                '@該当件数表示
                lblLotCnt.Text = .Rows.Count - 1
                
                '@描画ﾛｯｸ解除
                .Redraw = True
                
                '@ﾛｯｸ解除
                .Enabled = True
                
                '@ﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfLotList)
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnLoTtravList_Sel
    '機　能：工順元Lot一覧取得
    '引　数：なし
    '戻り値：True:成功/False:失敗
    '作成日：2004/02/18 (Wed) 17:45:57 M.Miura
    '更新日：2004/07/15 (Thu) 18:02:42 N.Kojima
    '備　考：
    Private Function prvblnLoTtravList_Sel() As Boolean

        Dim lstrStartDT         As String       '開始日
        Dim lstrEndDt           As String       '終了日
        Dim lstrProductID       As String       '機種ID
        Dim lstrDivisionID      As String       '種別ID
        Dim lstrClassDivision   As String       '処理区分
        Dim lblnAnsLot          As Boolean      '工順元ﾛｯﾄ一覧取得結果(True:成功/False:失敗)
        Dim lstrFormName        As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        
        Try
                
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Function
            End If
            
            '@初期化
            prvblnLoTtravList_Sel = False

            '@条件退避
            lstrProductID = cmbProduct.Text         '機種
            lstrDivisionID = cmbDivision.Text       '種別
            lstrStartDT = dtpStartDate.Value        '開始日
            lstrEndDt = dtpEndDate.Value            '終了日
            
            '@処理区分格納
            lstrClassDivision = ptypCM00J0.strClassDivisionTravlist

            '@機種確認
            If lstrProductID = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0013)
                
                '@"機種が指定されていません。機種を指定してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽ処理
                Call pubSetFocus(cmbDivision)
                
                Exit Function
            End If
            
            '@種別確認
            If lstrDivisionID = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0014)
                
                '@"種別が指定されていません。種別を指定してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽ処理
                Call pubSetFocus(cmbDivision)
                
                Exit Function
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "prvblnLoTtravList_Sel"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@=======================
            '@ 工順元LOT一覧取得
            '@=======================
            lblnAnsLot = pubblnLotTravlist_Sel(lstrClassDivision, _
                                               CMstrlot_travlistVer, _
                                               lstrProductID, _
                                               lstrDivisionID, _
                                               lstrStartDT, _
                                               lstrEndDt, _
                                               mtypLotList, _
                                               mlngLotListCnt)
            '@結果判定
            If lblnAnsLot = False Then
            '@失敗の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Function
            Else
                
                '@取得したｺﾋﾟｰ元LOTID一覧表示
                Call prvvsfLotList_Disp(mtypLotList, mlngLotListCnt)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@成功を返す
                prvblnLoTtravList_Sel = True
            End If
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLoTtravList_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvcmdLotSearchEnabled_Chk
    '機　能：検索条件ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/19 (Wed) 13:52:57 Y.Yamagishi
    '更新日：2004/05/19 (Wed) 13:52:57
    '備　考：
    Private Sub prvcmdLotSearchEnabled_Chk()

        Try

            '@機種入力ﾁｪｯｸ
            If cmbProduct.Text = vbNullString Then
                '@検索ﾎﾞﾀﾝ使用不可
                cmdLotSearch.Enabled = False
                
                Exit Sub
            End If
            
            '@種別入力ﾁｪｯｸ
            If cmbDivision.Text = vbNullString Then
                '@検索ﾎﾞﾀﾝ使用不可
                cmdLotSearch.Enabled = False
                
                Exit Sub
            End If
            
            '@開始日入力ﾁｪｯｸ
            If dtpStartDate.Value = CPstrNullDate Then
                '検索ﾎﾞﾀﾝ使用不可
                cmdLotSearch.Enabled = False
                
                Exit Sub
            End If
               
            If dtpStartDate.Value <> CPstrNullDate Then
                '@日付ではない場合
                If pubblnYearRange_Chk(dtpStartDate.Value) = False Then
                    '検索ﾎﾞﾀﾝ使用不可
                    cmdLotSearch.Enabled = False
                    
                    Exit Sub
                End If
            End If
               
            '@検索ﾎﾞﾀﾝ使用可
            cmdLotSearch.Enabled = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdLotSearchEnabled_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2007/07/05 (Thu) 10:51:42 N.Kasai **************************************************
    ''関数名：prvcmdLeft_Proc
    ''機　能：ｸﾞﾘｯﾄﾞの左項目ｽｸﾛｰﾙｸﾘｯｸ処理
    ''引　数：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    ''　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    ''　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    ''戻り値：なし
    ''作成日：2004/07/14 (Wed) 09:19:53 S.Deguchi
    ''更新日：2004/07/14 (Wed) 09:19:53
    ''備　考：
    'Public Sub prvcmdLeft_Proc(ByVal lobjvsfGrid As Object, _
    '                           Optional ByVal lobjcmdLeft As Object = Nothing, _
    '                           Optional ByVal lobjcmdRight As Object = Nothing)
    '
    '    Dim llngLeftCol         As Long     '画面表示最左Col番号
    '    Dim llngLeftColCal      As Long     '計算後の最左Col番号
    '    Dim llngRightCol        As Long     '画面表示最右Col番号
    '    Dim llngMinCol          As Long     '固定Col数
    '    Dim llngMaxCol          As Long     'Col総数
    '    Dim llngHideStartCol    As Long     '表示変動開始Col番号
    '    Dim llngRow             As Long     '取得Row番号
    '    Dim llngloopcount       As Long     'ループカウント
    '    Dim llngWidthAll        As Long     'Col全体の幅
    '    Dim llngWidthHide       As Long     'ｽｸﾛｰﾙで隠れたColの幅
    '    Dim llngWidth           As Long     'Colの幅
    '
    '    On Error GoTo Error_Handler
    '
    '    '@初期設定
    '    llngLeftCol = 0
    '    llngLeftColCal = 0
    '    llngRightCol = 0
    '    llngMinCol = 0
    '    llngMaxCol = 0
    '    llngHideStartCol = 0
    '    llngloopcount = 0
    '    llngWidthAll = 0
    '    llngWidthHide = 0
    '    llngWidth = 0
    '
    '    '@横ｽｸﾛｰﾙ発生ﾌﾗｸﾞによる処理分岐
    '    If mlngSideScrollFlag = CMlngSideScrollOffFlag Then
    '        Exit Sub
    '    End If
    '
    '    With lobjvsfGrid
    '        '@画面表示最左Col番号取得
    '        llngLeftCol = .LeftCol
    '
    '        '@画面表示最右Col番号取得
    '        llngRightCol = .RightCol
    '
    '        '@固定Col番号取得(=.FrozenCols:固定列数 -1)
    '        llngMinCol = .FrozenCols - 1
    '
    '        '@ｽｸﾛｰﾙで隠れるCol番号取得
    '        llngHideStartCol = llngMinCol + 1
    '
    '        '@一覧ｽｸﾛｰﾙ制御
    '        '@ｸﾞﾘｯﾄﾞの固定列より,可動する列(最左)が小さい場合
    '        If llngLeftCol > llngMinCol Then
    '            llngLeftColCal = llngLeftCol - 1
    '            .ShowCell llngRow, llngLeftColCal
    '        Else
    '            '@ｸﾞﾘｯﾄﾞの固定列と,可動する列(最左)が同じ場合
    '            If llngLeftCol = llngMinCol Then
    '                llngLeftColCal = llngLeftCol
    '                .ShowCell llngRow, llngLeftColCal
    '            End If
    '        End If
    '
    '        '@最大Col番号取得(非表示項目含まない)
    '        For llngloopcount = 0 To .Cols - 1
    '            If .ColHidden(llngloopcount) <> True Then
    '                llngMaxCol = llngMaxCol + 1
    '            End If
    '        Next llngloopcount
    '
    '        '@全列数の幅取得(非表示項目は含めない)
    '        For llngloopcount = 0 To .Cols - 1
    '            If .ColHidden(llngloopcount) <> True Then
    '                llngWidthAll = llngWidthAll + .ColWidth(llngloopcount)
    '            End If
    '        Next llngloopcount
    '
    '        '@ｽｸﾛｰﾙで隠れた列の幅を取得
    '        For llngloopcount = llngHideStartCol To llngLeftColCal - 1
    '            llngWidthHide = llngWidthHide + .ColWidth(llngloopcount)
    '        Next llngloopcount
    '
    '        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御(右側)
    '        llngWidth = llngWidthAll - llngWidthHide
    '        '@ｸﾞﾘｯﾄﾞの全体幅より、表示使用としている全列幅が大きい場合
    '        If .Width - llngWidth <= 0 Then
    '            lobjcmdRight.Enabled = True
    '        Else
    '            lobjcmdRight.Enabled = False
    '        End If
    '
    '        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御(左側)
    '        '@可動する列(最左)と,隠れている列が同じ場合
    '        If llngLeftColCal = llngHideStartCol Then
    '            lobjcmdLeft.Enabled = False
    '        Else
    '            lobjcmdLeft.Enabled = True
    '        End If
    '
    '        '@ﾌｫｰｶｽをｾｯﾄ
    '        Call pubSetFocus(lobjvsfGrid)
    '    End With
    '
    '    Exit Sub
    '
    'Error_Handler:
    '
    '    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '    With ptypOnErrorInfo
    '        .strMenuKey = CMstrLocalMenuKey
    '        .strProcName = "prvcmdLeft_Proc"
    '        .strErrMessage = vbNullString
    '    End With
    '
    '    '@共通ｴﾗｰ処理
    '    Call pubOnError_Proc
    '
    'End Sub
    '
    ''関数名：prvcmdRight_Proc
    ''機　能：ｸﾞﾘｯﾄﾞの右項目ｽｸﾛｰﾙｸﾘｯｸ処理
    ''引　数：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    ''　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    ''　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    ''戻り値：なし
    ''作成日：2004/07/14 (Wed) 09:19:56 S.Deguchi
    ''更新日：2004/07/14 (Wed) 09:19:56
    ''備　考：
    'Public Sub prvcmdRight_Proc(ByVal lobjvsfGrid As Object, _
    '                            Optional ByVal lobjcmdLeft As Object = Nothing, _
    '                            Optional ByVal lobjcmdRight As Object = Nothing)
    '
    '    Dim llngLeftCol         As Long     '画面表示最左Col番号
    '    Dim llngLeftColCal      As Long     '計算後の最左Col番号
    '    Dim llngMinCol          As Long     '固定Col数
    '    Dim llngMaxCol          As Long     'Col総数
    '    Dim llngHideStartCol    As Long     '表示変動開始Col番号
    '    Dim llngloopcount       As Long     'ループカウント
    '    Dim llngWidthAll        As Long     'Col全体の幅
    '    Dim llngWidthHide       As Long     'ｽｸﾛｰﾙで隠れたColの幅
    '    Dim llngWidth           As Long     'Colの幅
    '
    '    On Error GoTo Error_Handler
    '
    '    '@初期設定
    '    llngLeftCol = 0
    '    llngLeftColCal = 0
    '    llngMinCol = 0
    '    llngMaxCol = 0
    '    llngHideStartCol = 0
    '    llngloopcount = 0
    '    llngWidthAll = 0
    '    llngWidthHide = 0
    '    llngWidth = 0
    '
    '    '@横ｽｸﾛｰﾙ発生ﾌﾗｸﾞによる処理分岐
    '    If mlngSideScrollFlag = CMlngSideScrollOffFlag Then
    '        Exit Sub
    '    End If
    '
    '    With lobjvsfGrid
    '        '@ｽｸﾛｰﾙ制御(最終列直前まで)
    '        llngLeftCol = .LeftCol
    '        llngLeftColCal = llngLeftCol + 1
    '        .LeftCol = llngLeftColCal
    '
    '        '@固定Col番号取得(=.FrozenCols:固定列数 -1)
    '        llngMinCol = .FrozenCols - 1
    '
    '        '@ｽｸﾛｰﾙで隠れるCol番号取得
    '        llngHideStartCol = llngMinCol + 1
    '
    '        '@最大Col番号取得(非表示項目含まない)
    '        For llngloopcount = 0 To .Cols - 1
    '            If .ColHidden(llngloopcount) <> True Then
    '                llngMaxCol = llngMaxCol + 1
    '            End If
    '        Next llngloopcount
    '
    '        '@全列数の幅取得(非表示項目は含めない)
    '        For llngloopcount = 0 To .Cols - 1
    '            If .ColHidden(llngloopcount) <> True Then
    '                llngWidthAll = llngWidthAll + .ColWidth(llngloopcount)
    '            End If
    '        Next llngloopcount
    '
    '        '@ｽｸﾛｰﾙで隠れた列の幅を取得
    '        For llngloopcount = llngHideStartCol To llngLeftCol
    '            llngWidthHide = llngWidthHide + .ColWidth(llngloopcount)
    '        Next llngloopcount
    '
    '        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御(右側)
    '        llngWidth = llngWidthAll - llngWidthHide
    '        '@ｸﾞﾘｯﾄﾞの全体幅より、表示使用としている全列幅が大きい場合
    '        If .Width - llngWidth <= 0 Then
    '            lobjcmdRight.Enabled = True
    '        Else
    '            lobjcmdRight.Enabled = False
    '        End If
    '
    '        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御(左側)
    '        '@可動する列(最左)と,隠れている列が同じ場合
    '        If llngLeftColCal = llngHideStartCol Then
    '            lobjcmdLeft.Enabled = False
    '        Else
    '            lobjcmdLeft.Enabled = True
    '        End If
    '
    '        '@ﾌｫｰｶｽをｾｯﾄ
    '        Call pubSetFocus(lobjvsfGrid)
    '    End With
    '
    '    Exit Sub
    '
    'Error_Handler:
    '
    '    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '    With ptypOnErrorInfo
    '        .strMenuKey = CMstrLocalMenuKey
    '        .strProcName = "prvcmdRight_Proc"
    '        .strErrMessage = vbNullString
    '    End With
    '
    '    '@共通ｴﾗｰ処理
    '    Call pubOnError_Proc
    '
    'End Sub
    '
    ''関数名：prvSideKeyDown_Proc
    ''機　能：ｸﾞﾘｯﾄﾞｷｰ制御
    ''引　数：lintKeyCode：ｷｰｺｰﾄﾞ
    ''　　　：lstrActiveCtlNm：ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名
    ''　　　：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    ''　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    ''　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    ''戻り値：なし
    ''作成日：2004/07/14 (Wed) 09:35:55 S.Deguchi
    ''更新日：2004/07/14 (Wed) 09:35:55
    ''備　考：
    'Public Sub prvSideKeyDown_Proc(ByRef lintKeyCode As Integer, _
    '                               ByVal lstrActiveCtlNm As String, _
    '                               ByVal lobjvsfGrid As Object, _
    '                               Optional ByVal lobjcmdLeft As Object = Nothing, _
    '                               Optional ByVal lobjcmdRight As Object = Nothing)
    '
    '    Dim llngRow             As Long     'ｶｳﾝﾄ
    '    Dim llngActiveCol       As Long     'ﾌｫｰｶｽがあたっているCol番号
    '    Dim llngLeftCol         As Long     '画面表示最左Col番号
    '    Dim llngLeftColCal      As Long     '計算後の最左Col番号
    '    Dim llngMinCol          As Long     '固定Col数(最小Col数)
    '    Dim llngMaxCol          As Long     'Col総数
    '    Dim llngHideStartCol    As Long     '表示変動開始Col番号
    '    Dim llngLoopCol         As Long     'ﾙｰﾌﾟｶｳﾝﾄ用Col番号
    '    Dim llngloopcount       As Long     'ﾙｰﾌﾟｶｳﾝﾄ
    '    Dim llngWidthAll        As Long     'Col全体の幅
    '    Dim llngWidthHide       As Long     'ｽｸﾛｰﾙで隠れるColの幅
    '    Dim llngWidth           As Long     'Colの幅(計算結果)
    '
    '    On Error GoTo Error_Handler
    '
    '    '@初期設定
    '    llngLeftCol = 0
    '    llngLeftColCal = 0
    '    llngMinCol = 0
    '    llngMaxCol = 0
    '    llngHideStartCol = 0
    '    llngLoopCol = 0
    '    llngloopcount = 0
    '    llngWidthAll = 0
    '    llngWidthHide = 0
    '    llngWidth = 0
    '
    '    '@横ｽｸﾛｰﾙ発生ﾌﾗｸﾞによる処理分岐
    '    If mlngSideScrollFlag = CMlngSideScrollOffFlag Then
    '        Exit Sub
    '    End If
    '
    '    With lobjvsfGrid
    '        Select Case lstrActiveCtlNm
    '            '@ｸﾞﾘｯﾄﾞﾌｫｰｶｽがある場合
    '            Case .Name
    '                Select Case lintKeyCode
    '                   '@ｸﾞﾘｯﾄﾞｷｰ制御([←]ｷｰﾎﾞﾀﾝ)
    '                    Case vbKeyLeft
    '                        '@画面表示最左Col番号取得
    '                        llngLeftCol = .LeftCol
    '
    '                        '@ﾌｫｰｶｽがあたっているCol番号取得
    '                        llngActiveCol = .Col
    '
    '                        '@固定Col番号取得(.FrozenCols:固定列数 -1)
    '                        llngMinCol = .FrozenCols - 1
    '
    '                        '@ｽｸﾛｰﾙで隠れるCol番号取得
    '                        llngHideStartCol = llngMinCol + 1
    '
    '                        '@最大Col番号取得(非表示項目含まない)
    '                        For llngloopcount = 0 To .Cols - 1
    '                            If .ColHidden(llngloopcount) <> True Then
    '                                llngMaxCol = llngMaxCol + 1
    '                            End If
    '                        Next llngloopcount
    '
    '                        '@全列数の幅取得(非表示項目は含めない)
    '                        For llngloopcount = 0 To llngMaxCol - 1
    '                            If .ColHidden(llngloopcount) <> True Then
    '                                llngWidthAll = llngWidthAll + .ColWidth(llngloopcount)
    '                            End If
    '                        Next llngloopcount
    '
    '                        '@ｽｸﾛｰﾙで隠れた列の幅を取得
    '                        For llngloopcount = llngHideStartCol To llngLeftCol - 1
    '                            llngWidthHide = llngWidthHide + .ColWidth(llngloopcount)
    '                        Next llngloopcount
    '
    '                        '@表示されている列の幅を取得
    '                        llngWidth = llngWidthAll - llngWidthHide
    '
    '                        '@ｽｸﾛｰﾙ制御
    '                        '@ﾌｫｰｶｽｾﾙの列場所による処理分岐
    '                        If llngActiveCol = llngLeftCol Then
    '                            If llngLeftCol > llngMinCol Then
    '                                llngLeftColCal = llngLeftCol - 1
    '                                .ShowCell llngRow, llngLeftColCal
    '                            Else
    '                                If llngLeftCol = llngMinCol Then
    '                                    llngLeftColCal = llngLeftCol
    '                                    .ShowCell llngRow, llngLeftColCal
    '                                End If
    '                            End If
    '                            lobjcmdRight.Enabled = True
    '                            lobjcmdLeft.Enabled = True
    '                        End If
    '
    '                        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御
    '                        '@ﾌｫｰｶｽｾﾙの列場所による処理分岐
    '                        If llngActiveCol = llngMinCol + 1 Then
    '                            lobjcmdLeft.Enabled = False
    '                            lobjcmdRight.Enabled = True
    '                        Else
    '                            If llngActiveCol = llngMaxCol Then
    '                                lobjcmdLeft.Enabled = True
    '                                lobjcmdRight.Enabled = False
    '                            End If
    '                        End If
    '
    '                   '@ｸﾞﾘｯﾄﾞｷｰ制御([→]ｷｰﾎﾞﾀﾝ)
    '                    Case vbKeyRight
    '                        '@画面表示最左Col番号取得
    '                        llngLeftCol = .LeftCol
    '
    '                        '@ﾌｫｰｶｽがあたっているCol番号取得
    '                        llngActiveCol = .Col
    '
    '                        '@固定Col番号取得(.FrozenCols:固定列数 -1)
    '                        llngMinCol = .FrozenCols - 1
    '
    '                        '@最大Col番号取得(非表示項目含まない)
    '                        For llngloopcount = 0 To .Cols - 1
    '                            If .ColHidden(llngloopcount) <> True Then
    '                                llngMaxCol = llngMaxCol + 1
    '                            End If
    '                        Next llngloopcount
    '
    '                        '@全列数の幅取得(非表示項目は含めない)
    '                        For llngloopcount = 0 To llngMaxCol - 1
    '                            If .ColHidden(llngloopcount) <> True Then
    '                                llngWidthAll = llngWidthAll + .ColWidth(llngloopcount)
    '                            End If
    '                        Next llngloopcount
    '
    '                        'ｽｸﾛｰﾙ制御用幅計算
    '                        If llngActiveCol + 1 >= llngMaxCol Then
    '                            llngLoopCol = llngMaxCol
    '                        Else
    '                            llngLoopCol = llngActiveCol + 1
    '                        End If
    '
    '                        '@ｽｸﾛｰﾙ制御
    '                        If .Width <= llngWidthAll Then
    '                            '@ﾌｫｰｶｽがあたっているｾﾙが固定列以下の場合には左右ﾎﾞﾀﾝ活性化
    '                            If llngActiveCol <= llngMinCol Then
    '                                llngLeftCol = .LeftCol
    '                                .LeftCol = llngLeftCol
    '                            Else
    '                                llngLeftCol = .LeftCol
    '                                llngLeftColCal = llngLeftCol + 1
    '                                .LeftCol = llngLeftColCal
    '                            End If
    '
    '                            lobjcmdRight.Enabled = True
    '                            lobjcmdLeft.Enabled = True
    '                        End If
    '
    '                        '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御
    '                        If llngActiveCol = llngMinCol Then
    '                            lobjcmdLeft.Enabled = False
    '                            lobjcmdRight.Enabled = True
    '                        Else
    '                            If llngActiveCol = llngMaxCol Then
    '                                lobjcmdLeft.Enabled = True
    '                                lobjcmdRight.Enabled = False
    '                            End If
    '                        End If
    '
    '                        '@ﾌｫｰｶｽをｾｯﾄ
    '                        Call pubSetFocus(lobjvsfGrid)
    '                End Select
    '        End Select
    '    End With
    '
    '    Exit Sub
    '
    'Error_Handler:
    '
    '    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '    With ptypOnErrorInfo
    '        .strMenuKey = CMstrLocalMenuKey
    '        .strProcName = "prvSideKeyDown_Proc"
    '        .strErrMessage = vbNullString
    '    End With
    '
    '    '@共通ｴﾗｰ処理
    '    Call pubOnError_Proc
    '
    'End Sub
    '@↑2007/07/05 (Thu) 10:51:42 N.Kasai **************************************************


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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfLotList.BeforeDoubleClick

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
