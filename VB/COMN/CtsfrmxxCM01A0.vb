'ﾌｧｲﾙ名：xxCM01A0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット情報変更・削除　メインフォーム
'作成日：2007/10/01 (Mon) 11:01:58 N.Kasai
'更新日：2019/01/30 (Wed) 12:51:15 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Imports SEComboBoxEx
Imports SECalendarEx
Public Class frmxxCM01A0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM01A0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM01A0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM01A0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM01A0)
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
    '@現在優先度構造体定数
    '======================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2019/01/30 (Wed) 12:50:34 T.Oide **************************************************
    'Private Const CMstrLocalVersion                 As String = "08.00"
    Private Const CMstrLocalVersion                 As String = "08.02"
    '@↑2019/01/30 (Wed) 12:50:34 T.Oide **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_priolistVer              As String = "01.00"                 'ﾏｽﾀ優先度項目取得
    Private Const CMstrmas_emplist_Ver              As String = "02.00"                 '作業者ﾘｽﾄ取得
    Private Const CMstrmas_sbroutelistVer           As String = "01.00"                 '送品先ﾘｽﾄ取得
    Private Const CMstrpr__orderlistVer             As String = "01.00"                 'P/Rｵｰﾀﾞｰﾘｽﾄ取得
    Private Const CMstrlot_attributeVer             As String = "05.00"                 'ﾛｯﾄ情報取得
    Private Const CMstrlot_chgattributeVer          As String = "04.00"                 'ﾛｯﾄ情報変更
    Private Const CMstrlot_cancelplanVer            As String = "01.00"                 '投入予定ﾛｯﾄ削除
    Private Const CMstrmas_wplist__Ver              As String = "05.01"                 '装置一覧取得

    '@ﾛｰｶﾙ機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN0290

    '@ｺﾒﾝﾄ関連
    Private Const CMlngCommentsMaxByte              As Integer = 2048                      '最大文字数
    Private Const CMlngMaxDispMemoRow               As Integer = 3                         'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@ｺﾝﾎﾞﾎﾞｯｸｽ共通
    Private Const CMlngCmbFontSize                  As Integer = 14                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboRowHeight               As Integer = 43                        '行の高さ
    Private Const CMlngCmbSortAsc                   As Integer = 1                         '昇順(ｿｰﾄ)
    Private Const CMlngCmbDispCols                  As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbAlignLeftCenter           As Integer = 1                         'ｸﾞﾘｯﾄﾞ文字表示位置(左中央)

    Private Const CMlngCmbDispCols1                 As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbGridCol0                  As Integer = 0                         '名称列番=0
    Private Const CMlngCmbGridCol1                  As Integer = 1                         '名称列番=1

    '@P/R区分の定数宣言
    Private Const CMlngOptPrClassP                  As Integer = 0                         'P/R区分(Pｵｰﾀﾞｰ)
    Private Const CMlngOptPrClassR                  As Integer = 1                         'P/R区分(Rｵｰﾀﾞｰ)

    '@表示Msg用文字
    Private Const CMstrDspMsgWfNum                  As String = "数量["
    Private Const CMstrDspMsgLotManager             As String = "ロット担当["
    Private Const CMstrDspMsgDate                   As String = "投入予定日["
    Private Const CMstrDspMsgPrio                   As String = "優先度["
    Private Const CMstrDspMsgPrOrder                As String = "P/Rオーダー["
    Private Const CMstrDspMsgSendSB                 As String = "送品先["
    Private Const CMstrDspMsgLotSendFlag            As String = "送品["
    Private Const CMstrDspMsgShipDate               As String = "送品予定日["
    Private Const CMstrDspMsgPlanAssDate            As String = "組立投入予定日["
    Private Const CMstrDspMsgEndNext                As String = "]、"
    Private Const CMstrDspMsgRight                  As String = "→"
    Private Const CMstrDspMsgFirstPhoto             As String = "1stフォト号機["
    Private Const CMstrfraPrioDispString            As String = "優先度変更"
    Private Const CMstrfraSecPriorityString         As String = " 区間優先設定あり"

    '@有効ｺﾝﾄﾛｰﾙ名
    Private Const CMstrActiveControlNameCarrierID   As String = "txtCarrier"            'ｷｬﾘｱIDのｺﾝﾄﾛｰﾙ名
    Private Const CMstrActiveControlNameLotID       As String = "txtLot"                'ﾛｯﾄIDのｺﾝﾄﾛｰﾙ名

    '@MAXWF数
    Private Const CMlngMaxWF                        As Integer = 25                        'ﾃｷｽﾄﾌﾟﾛﾊﾟﾃｨ
    '@MAXCHIP数
    Private Const CMlngMaxCHIP                      As Integer = 9999                      'ﾃｷｽﾄﾌﾟﾛﾊﾟﾃｨ

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private===========================================
    Private mstrCarrier                         As String                       'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrLot                             As String                       'ﾛｯﾄ情報取得時のﾛｯﾄID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrEventName                       As String                       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

    Private mlngcmbFirstWpIndex                 As Integer                      '1stﾌｫﾄ号機ｺﾝﾎﾞ内容を退避
     
    '@構造体関連
    Private mtypPriorityReasonList              As List(Of typPriorityReasonList)   '優先度ﾘｽﾄ
    Private mlngPriorityReasonListCnt           As Integer                          'ﾛｯﾄ優先度項目のｶｳﾝﾄ
    Private mtypEngEmpList                      As List(Of TechManList)             '作業者ﾘｽﾄ格納用
    Private mlngEngEmpListCnt                   As Integer                          '作業者ﾘｽﾄのｶｳﾝﾄ
    Private mtypPrOrderListAns                  As PrOrderListAns                   'P/Rｵｰﾀﾞｰﾘｽﾄ格納用
    Private mtypSBRouteListAns                  As SendSBListAns                    '送品先ﾘｽﾄ格納用
    Private mtyp
     
    Private mtypLotAttribute                    As LotAttribute                 'ﾛｯﾄ情報格納
    '@変更ﾌﾗｸﾞ
    Private mblnChgWfNumFlag                    As Boolean                      '数量変更有無ﾁｪｯｸﾌﾗｸﾞ(True:変更あり,False:変更なし)
    Private mblnChgLotManagerFlag               As Boolean                      'ﾛｯﾄ担当変更有無ﾁｪｯｸﾌﾗｸﾞ(True:変更あり,False:変更なし)
    Private mblnChgPlanDateFlag                 As Boolean                      '投入予定日変更有無ﾁｪｯｸﾌﾗｸﾞ(True:変更あり,False:変更なし)
    Private mblnChgPrioFlag                     As Boolean                      '優先度変更有無ﾁｪｯｸﾌﾗｸﾞ(True:変更あり,False:変更なし)
    Private mblnChgPrOrderFlag                  As Boolean                      'P/Rｵｰﾀﾞｰ変更有無ﾁｪｯｸﾌﾗｸﾞ(True:変更あり,False:変更なし)
    Private mblnChgSendSBIDFlag                 As Boolean                      '送品先変更有無ﾁｪｯｸﾌﾗｸﾞ(True:変更あり,False:変更なし)
    Private mblnChgLotSendFlag                  As Boolean                      '送品変更有無ﾁｪｯｸﾌﾗｸﾞ(True:変更あり,False:変更なし)
    Private mblnChgPlanShipDateFlag             As Boolean                      '送品予定日変更有無ﾁｪｯｸﾌﾗｸﾞ(True:変更あり,False:変更なし)
    Private mblnChgFirstPhotoFlag               As Boolean                      '1stﾌｫﾄ号機変更有無ﾁｪｯｸﾌﾗｸﾞ(True:変更あり,False:変更なし)
    Private mblnWpListZeroFlag                  As Boolean                      '1stﾌｫﾄ号機変更用装置ﾘｽﾄｾﾞﾛ判定ﾌﾗｸﾞ
    Private mblnChgPlanAssTrowinDateFlag        As Boolean                      '組立投入予定変更有無ﾁｪｯｸﾌﾗｸﾞ(True:変更あり,False:変更なし)

    '@その他ﾌﾗｸﾞ
    Private mblnErrChkFlag                      As Boolean                      'ｴﾗｰﾁｪｯｸﾌﾗｸﾞ
    Private mblnTakeOverDispFlg                 As Boolean                      '引継ぎ表示ﾌﾗｸﾞ
    Private mstrActiveControlName               As String                       '有効ｺﾝﾄﾛｰﾙ(ｷｬﾘｱID or ﾛｯﾄID)
    Private mblnSectionPriorityFlg              As Boolean                      '区間優先ﾌﾗｸﾞ

    Private buttonProcessing                    As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                      'NSYS WindowCloseフラグ

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
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/01 (Mon) 13:17:18 N.Kasai
    '更新日：2008/07/04 (Fri) 13:34:17 M.Koni
    '備　考：
    '　　　：2008/06/10 (Tue) 16:20:08 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/04 (Fri) 13:29:48 M.Koni       1stﾌｫﾄ号機変更対応<案件No.02959>
    Private Sub Form_Load()
        
        Dim lstrGroupID                     As String       '部門ID格納用
        Dim lblnAns                         As Boolean      'ﾛｯﾄ優先度項目取得戻り値(True/False)
        Dim llngWpCnt                       As Integer      '1stﾌｫﾄ号機設定用ｶｳﾝﾀ

        Try
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0290, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                '@ﾌｫｰﾑを閉じる
                Me.Close()
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "Form_Load"
            Call pubResponseStart(Me.Name, mstrEventName)
            
            'NSYS 表示位置設定
            Me.Left = 0 - My.Settings.FormOffset
            Me.Top = 0

            '@画面初期化
            Call prvfrmxxCM01A0_Init()
            
            '@共通ｺﾝﾄﾛｰﾙ初期化
            Call prvControl_Init()
            
            '@ﾚﾁｸﾙ使用装置一覧取得結果
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, llngWpCnt, pstrSBID, CPstrCD2J)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call publngResponseEnd(Me.Name, mstrEventName)
                Exit Sub
            End If
            
            '@ﾚﾁｸﾙ使用装置情報表示（1stﾌｫﾄ号機選択ｺﾝﾎﾞ用）
            Call prvcmbWplist_Disp(llngWpCnt)

            '@優先度ﾏｽﾀﾘｽﾄ取得
            lblnAns = pubblnMasPriolist_Sel(CMstrmas_priolistVer, _
                                            mlngPriorityReasonListCnt, _
                                            mtypPriorityReasonList)
            
            '@戻り値判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            Else
                '@配列の件数ﾁｪｯｸ
                If mlngPriorityReasonListCnt > 0 Then
                    '@優先度ﾏｽﾀﾘｽﾄをｺﾝﾎﾞへｾｯﾄ
                    Call prvPrioInfo_Disp()
                End If
            End If
            
            '@部門IDを設定(STAFF+LINE)
            lstrGroupID = CPstrDeptIDStaff & CPstrAmpersand & CPstrDeptIDLine
            
            '@作業者ﾘｽﾄ(ﾛｯﾄ担当者名)取得
            lblnAns = pubblnMasEmplist_Sel(CMstrmas_emplist_Ver, _
                                           mtypEngEmpList, _
                                           mlngEngEmpListCnt, _
                                           lstrGroupID)

            '@戻り値判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                '@異常の場合終了
                Exit Sub
            Else
                '@配列の件数ﾁｪｯｸ
                If mlngEngEmpListCnt > 0 Then
                    '@ﾛｯﾄ担当をｺﾝﾎﾞへｾｯﾄ
                    Call prvCmbLotManager_Disp()
                End If
            End If
            
            '@P/Rｵｰﾀﾞｰﾘｽﾄ取得
            lblnAns = pubblnPrOrderList_Sel(CMstrpr__orderlistVer, _
                                            mtypPrOrderListAns)

            '@戻り値判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                '@異常の場合終了
                Exit Sub
            Else
                '@配列の件数ﾁｪｯｸ
                If mtypPrOrderListAns.lngPrOrderListCnt > 0 Then
                    '@P/Rｵｰﾀﾞｰｺﾝﾎﾞへｾｯﾄ
                End If
            End If
            
            '@送品先ﾘｽﾄ取得
            lblnAns = pubblnMasSendRouteList_Sel(CMstrmas_sbroutelistVer, _
                                                 mtypSBRouteListAns)

            '@戻り値判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                '@異常の場合終了
                Exit Sub
            Else
                '@配列の件数ﾁｪｯｸ
                If mtypSBRouteListAns.lngSendSBListCnt > 0 Then
                    '@送品先ｺﾝﾎﾞへｾｯﾄ
                    Call prvSendSBID_Disp()
                End If
            End If
            
            '@送品ｺﾝﾎﾞ設定
            Call prvCmbLotSend_Set()

            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            '@引継ぎ情報表示済みﾌﾗｸﾞ
            mblnTakeOverDispFlg = False

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, mstrEventName)

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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/03 (Wed) 13:48:30 N.Kasai
    '更新日：2007/10/03 (Wed)
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@引継ぎ情報表示済みﾌﾗｸﾞの判定
            '@FormLoad後、最初の1回しか処理しない
            If mblnTakeOverDispFlg = True Then
                '@引継ぎ情報が表示済みの場合
                Exit Sub
            End If
            
            '@引継ぎ情報表示済みﾌﾗｸﾞにTrueを設定する
            mblnTakeOverDispFlg = True
            
            '@引数のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@ｷｬﾘｱIDの初期値を設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                '@ｷｬﾘｱ情報を取得する
                RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier,New CancelEventArgs(True))
                AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
            Else
                '@ｷｬﾘｱID初期化
                ptypCommonInfo.strCarrierId = vbNullString
            
                '@引数のﾛｯﾄIDが空白かどうか判定する
                If ptypCommonInfo.strLotID <> vbNullString Then
                    '@ﾛｯﾄIDの初期値を設定する
                    txtLot.Text = ptypCommonInfo.strLotID
                    'NSYS ロットIDにフォーカス移動
                    Call pubSetFocus(txtLot)
                    '@ﾛｯﾄID情報取得
                    RemoveHandler txtLot.Validating,AddressOf txtLot_Validate
                    Call txtLot_Validate(txtLot,New CancelEventArgs(True))
                    AddHandler txtLot.Validating,AddressOf txtLot_Validate
                Else
                    '@ﾛｯﾄID初期化
                    ptypCommonInfo.strLotID = vbNullString
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Activate"
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
    '戻り値：なし
    '作成日：2007/10/03 (Wed) 13:49:10 N.Kasai
    '更新日：2007/10/03 (Wed) 13:49:10
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm             As Boolean          '開放結果格納
        Dim ltypLotAttribute        As LotAttribute     'ﾛｯﾄ情報
        
        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing,AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,New EventArgs)
                AddHandler MyBase.FormClosing,AddressOf Form_QueryUnload
            End If            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            

            '@構造体のｸﾘｱ
            '優先度
            If mtypPriorityReasonList Is Nothing Then
                mtypPriorityReasonList = New List(Of typPriorityReasonList)
            Else
                mtypPriorityReasonList.Clear()
            End If
            'ﾛｯﾄ担当
            If mtypEngEmpList Is Nothing Then
                mtypEngEmpList = New List(Of TechManList)
            Else
                mtypEngEmpList.Clear()
            End If
            'P/Rｵｰﾀﾞｰ
            If mtypPrOrderListAns.typPrOrderList Is Nothing Then
                mtypPrOrderListAns.typPrOrderList = New List(Of PrOrderList)
            Else
                mtypPrOrderListAns.typPrOrderList.Clear()
            End If
            '送品先
            If mtypSBRouteListAns.typSendSBList Is Nothing Then
                mtypSBRouteListAns.typSendSBList = New List(Of SendSBList)
            Else
                mtypSBRouteListAns.typSendSBList.Clear()
            End If
            mtypLotAttribute = ltypLotAttribute         'ﾛｯﾄ情報ｸﾘｱ
            
            mtypPrOrderListAns.lngPrOrderListCnt = 0    'P/Rｵｰﾀﾞｰﾘｽﾄｶｳﾝﾄ
            mtypSBRouteListAns.lngSendSBListCnt = 0     '送品先ﾘｽﾄｶｳﾝﾄ
            
            '@ﾌｫｰﾑ起動区分の確認
            If pblnfrmxxCM01A0Kbn = True Then
                '@ﾌｫｰﾑ起動区分を初期化
                pblnfrmxxCM01A0Kbn = False
            Else
                '@ActInitフラグの判定
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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰｶｽ制御
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2007/10/03 (Wed) 13:51:07 N.Kasai
    '更新日：2007/10/03 (Wed) 13:51:07
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

            Select Case e.KeyCode

                '@Enterｷｰの場合
                Case Keys.Return

                    '@ｷｬﾘｱID入力ﾁｪｯｸ
                    Select Case ActiveControl.Name
                        Case txtCarrier.Name
            
                            '@ｷｬﾘｱValidate処理へ
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Call txtCarrier_Validate(txtCarrier,New CancelEventArgs(True))
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                        '@ﾛｯﾄID入力ﾁｪｯｸ
                        Case txtLot.Name
                            '@ｷｬﾘｱValidate処理へ
                            RemoveHandler txtLot.Validating, AddressOf txtLot_Validate
                            Call txtLot_Validate(txtLot,New CancelEventArgs(True))
                            AddHandler txtLot.Validating, AddressOf txtLot_Validate

                        '@ｺﾒﾝﾄ/欄入力時は改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                        Case txtWorkMemo.Name
                            Exit Sub
                    
                        Case Else
                            '@その他のｺﾝﾄﾛｰﾙ
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

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 11:21:55 T.Sawaguchi
    '更新日：2005/02/15 (Tue) 13:25:37 N.Kojima
    '備　考：
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
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
            
            '@ﾌｫｰﾑ起動区分の確認(子画面として起動中)
            If pblnfrmxxCM01A0Kbn = True Then
                '@ｱﾝﾛｰﾄﾞ
                Me.Close()
            Else
                '@引継ぎ情報のｷｬﾘｱIDが空白かどうか判定する
                If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合
                    '@親ﾌｫｰﾑから呼ばれた場合
                    '@親画面切り替え引継ぎ制御
                    Call pubChangeScreen_Set(Me)
                Else
                '@空白の場合
                    '@終了関数を実行する
                    Call publngEnd_Proc(CPstrKeyEN0290, ltypCommonInfo)
                End If
            End If
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


    '関数名：CmbFirstPhotoWpName_Change
    '機　能：1stﾌｫﾄ装置ｺﾝﾎﾞ　変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/07/09 (Wed) 13:24:19 M.Koni <案件No.02959>
    '更新日：
    '備　考：
    Private Sub CmbFirstPhotoWpName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles CmbFirstPhotoWpName.Change
        
        Try

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ一括制御
            Call prvButtonEnabled_Proc()
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "CmbFirstPhotoWpName_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：CmbFirstPhotoWpName_CloseUp
    '機　能：1stﾌｫﾄ装置ｺﾝﾎﾞ　選択時処理(次ｱｲﾃﾑへのﾌｫｰｶｽ移動)
    '引　数：なし
    '戻り値：なし
    '作成日：2008/07/09 (Wed) 13:24:19 M.Koni <案件No.02959>
    '更新日：
    '備　考：
    Private Sub CmbFirstPhotoWpName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles CmbFirstPhotoWpName.CloseUp
        
        Try
            
             With CmbFirstPhotoWpName
                '@IDが選択されている場合
                .ValueCol = 1
                If .Value <> vbNullString Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "CmbFirstPhotoWpName_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱ変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/12 (Fri) 15:33:08 N.Kasai
    '更新日：2007/10/12 (Fri) 15:33:08 N.Kasai
    '備　考：
    '　　　：2006/03/20 (Mon) 11:21:31 N.Kojima     ﾛｯﾄID入力機能追加に伴い、有効ｺﾝﾄﾛｰﾙの判定処理を追加。(ﾕｰｻﾞｰ要望№0155)
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            
            '@有効ｺﾝﾄﾛｰﾙの判定
            If ActiveControl.Name <> CMstrActiveControlNameCarrierID Then
                Exit Sub
            End If
            
            '@ﾛｯﾄIDｸﾘｱ
            txtLot.Text = vbNullString
            
            '@画面初期化
            Call prvfrmxxCM01A0_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_GotFocus
    '機　能：ｷｬﾘｱIDのﾌｫｰｶｽ取得
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/12 (Fri) 15:33:20 N.Kasai
    '更新日：2007/10/12 (Fri) 15:33:20
    '備　考：
    Private Sub txtCarrier_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Enter

        Try

            '@有効ｺﾝﾄﾛｰﾙ名の設定(ｷｬﾘｱID)
            mstrActiveControlName = CMstrActiveControlNameCarrierID

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　Validate処理(入力確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/10/12 (Fri) 15:33:36 N.Kasai
    '更新日：2008/06/10 (Tue) 16:20:57 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 16:20:57 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAns                         As Boolean              '結果取得(True:正常,False:異常)

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrier.Text) = vbNullString Then
                '@有効ｺﾝﾄﾛｰﾙ名のｸﾘｱ
                mstrActiveControlName = vbNullString
                
                If ActiveControl.Name = txtCarrier.Name Then
                    '@ﾌｫｰｶｽ移動
                    If txtLot.Enabled = True Then
                        '@ﾛｯﾄID欄へ
                        Call pubSetFocus(txtLot)
                    Else
                        '@閉じるﾎﾞﾀﾝへ
                        Call pubSetFocus(cmdClose)
                    End If
                End If

                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                e.Cancel = True
                Exit Sub
            End If
            
            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If txtCarrier.Text <> mstrCarrier Then
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                mstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(Me.Name, mstrEventName)
                
                '@要求ﾒｯｾｰｼﾞ格納
                With mtypLotAttribute
                    .strMsgVer = CMstrlot_attributeVer
                    .strSbID = pstrSBID
                    .strReqCarrierID = txtCarrier.Text
                    .strReqLotID = txtLot.Text
                End With
                
                '@ﾛｯﾄ情報取得
                lblnAns = pubblnLotAttribute_Sel(mtypLotAttribute)
                
                '@結果判定
                If lblnAns = True Then
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, mstrEventName)

                    '@ﾛｯﾄIDを格納
                    txtLot.Text = mtypLotAttribute.strLotID
                    
                    '@画面表示処理
                    Call prvfrmxxCM01A0_Disp()
                    
                    '@ｺﾝﾄﾛｰﾙ制御
                    Call prvEditEnable_Proc()
                    
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
                    Call prvButtonEnabled_Proc()
                        
                    '@ｷｬﾘｱ,ﾛｯﾄID退避
                    mstrCarrier = txtCarrier.Text
                    mstrLot = txtLot.Text
                    
                    If ActiveControl.Name = txtCarrier.Name Then
                        '@ﾌｫｰｶｽの制御
                        Select Case True
                            Case txtWFNum.Enabled
                                 Call pubSetFocus(txtWFNum)
                            Case cmbLotManager.Enabled
                                 Call pubSetFocus(cmbLotManager)
                            Case calThrowinPlanDate.Enabled
                                Call pubSetFocus(calThrowinPlanDate)
                            Case cmbPrioSel.Enabled
                                Call pubSetFocus(cmbPrioSel)
                            Case Else
                                '@閉じるﾎﾞﾀﾝﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(cmdClose)
                        End Select
                    End If
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    Exit Sub
                End If
            Else
                If ActiveControl.Name = txtCarrier.Name Then
                    '@ﾌｫｰｶｽ移動
                    If txtLot.Enabled = True Then
                        '@ﾛｯﾄID欄へ
                        Call pubSetFocus(txtLot)
                    Else
                        '@閉じるﾎﾞﾀﾝへ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            '@有効ｺﾝﾄﾛｰﾙ名のｸﾘｱ
            mstrActiveControlName = vbNullString
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLot_Change
    '機　能：ﾛｯﾄID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/12 (Fri) 15:34:35 N.Kasai
    '更新日：2007/10/12 (Fri) 15:34:35 N.Kasai
    '備　考：
    Private Sub txtLot_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLot.Change

        Try

            '@有効ｺﾝﾄﾛｰﾙの判定
            If ActiveControl.Name <> CMstrActiveControlNameLotID Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDのｸﾘｱ
            txtCarrier.Text = vbNullString
            
            '@画面初期化
            Call prvfrmxxCM01A0_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLot_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLot_GotFocus
    '機　能：ﾛｯﾄIDGotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/12 (Fri) 15:34:46 N.Kasai
    '更新日：2007/10/12 (Fri) 15:34:46 N.Kasai
    '備　考：
    Private Sub txtLot_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtLot.Enter

        Try

            '@有効ｺﾝﾄﾛｰﾙ名の設定
            mstrActiveControlName = CMstrActiveControlNameLotID

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLot_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLot_Validate
    '機　能：ﾛｯﾄIDﾃｷｽﾄ　Validate処理(入力確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/10/12 (Fri) 15:34:56 N.Kasai
    '更新日：2008/06/10 (Tue) 16:21:44 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 16:21:44 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub txtLot_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLot.Validating

        Dim lblnAns     As Boolean              '結果取得(True:正常,False:異常)

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾛｯﾄIDの空白ﾁｪｯｸ
            If Trim$(txtLot.Text) = vbNullString Then
                '@有効ｺﾝﾄﾛｰﾙ名のｸﾘｱ
                mstrActiveControlName = vbNullString
                If ActiveControl.Name = txtLot.Name Then
                    '@閉じるﾎﾞﾀﾝﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
                Exit Sub
            End If
            
            '@ﾛｯﾄIDの桁ﾁｪｯｸ
            If txtLot.NowByte < txtLot.ChrMaxByte Then
                '@<TRM12W>$$ロットIDは10桁で入力してください。
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾛｯﾄ情報の取得(入力ﾛｯﾄIDと前回のﾛｯﾄID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If txtLot.Text <> mstrLot Then
                '@ﾚｽﾎﾟﾝｽ取得開始
                mstrEventName = "txtLot_Validate"
                Call pubResponseStart(Me.Name, mstrEventName)
                
                '@要求ﾒｯｾｰｼﾞ格納
                With mtypLotAttribute
                    .strMsgVer = CMstrlot_attributeVer
                    .strSbID = pstrSBID
                    .strReqCarrierID = txtCarrier.Text
                    .strReqLotID = txtLot.Text
                End With
                
                '@ﾛｯﾄ情報取得
                lblnAns = pubblnLotAttribute_Sel(mtypLotAttribute)
                
                '@結果判定
                If lblnAns = True Then
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
                    '@ｷｬﾘｱIDを格納
                    txtCarrier.Text = mtypLotAttribute.strCarrierId
                    '@画面表示処理
                    Call prvfrmxxCM01A0_Disp()
                    '@ｺﾝﾄﾛｰﾙ制御
                    Call prvEditEnable_Proc()
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
                    Call prvButtonEnabled_Proc()
                    
                    '@ｷｬﾘｱ,ﾛｯﾄID退避
                    mstrCarrier = txtCarrier.Text
                    mstrLot = txtLot.Text
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            
            If ActiveControl.Name = txtLot.Name Then
                '@ﾌｫｰｶｽの制御
                Select Case True
                    Case txtWFNum.Enabled
                         Call pubSetFocus(txtWFNum)
                    Case cmbLotManager.Enabled
                         Call pubSetFocus(cmbLotManager)
                    Case calThrowinPlanDate.Enabled
                        Call pubSetFocus(calThrowinPlanDate)
                    Case cmbPrioSel.Enabled
                        Call pubSetFocus(cmbPrioSel)
                    Case cmbPrOrder.Enabled
                        Call pubSetFocus(cmbPrOrder)
                    Case cmbLotSend.Enabled
                        Call pubSetFocus(cmbLotSend)
                    Case cmbSendSBID.Enabled
                        Call pubSetFocus(cmbSendSBID)
                    Case txtWorkMemo.Enabled
                        Call pubSetFocus(txtWorkMemo)
                    Case Else
                        '@閉じるﾎﾞﾀﾝﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                End Select
            End If

            '@有効ｺﾝﾄﾛｰﾙ名のｸﾘｱ
            mstrActiveControlName = vbNullString
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLot_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPrioSel_Change
    '機　能：優先度ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:26:47 N.Kasai
    '更新日：2007/10/11 (Thu) 13:26:47
    '備　考：
    Private Sub cmbPrioSel_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPrioSel.Change

        Try
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ一括制御
            Call prvButtonEnabled_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPrioSel_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPrioSel_CloseUp
    '機　能：優先度選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:27:22 N.Kasai
    '更新日：2007/10/11 (Thu) 13:27:22
    '備　考：
    Private Sub cmbPrioSel_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPrioSel.CloseUp

        Try

                With cmbPrioSel
                '@優先度IDが選択されている場合
                .ValueCol = 1
                If .Value <> vbNullString Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPrioSel_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbLotManager_Change
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:20:02 N.Kasai
    '更新日：2008/06/10 (Tue) 16:22:21 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 16:22:21 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmbLotManager_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotManager.Change

        Try
                
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ一括制御
            Call prvButtonEnabled_Proc()
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbLotManager_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbLotManager_CloseUp
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:21:15 N.Kasai
    '更新日：2008/06/10 (Tue) 16:22:48 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 16:22:48 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmbLotManager_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotManager.CloseUp

        Try
            
            With cmbLotManager
                '@IDが選択されている場合
                .ValueCol = 1
                If .Value <> vbNullString Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbLotManager_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：calThrowinPlanDate_CalendarSelect
    '機　能：投入予定日選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:22:55 N.Kasai
    '更新日：2007/10/11 (Thu) 13:22:55
    '備　考：
    Private Sub calThrowinPlanDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calThrowinPlanDate.CalendarSelect
        
        Try
            
            '@空白の場合は処理しない
            If calThrowinPlanDate.Value <> CPstrNullDate Then
                '@Validate処理へ
                RemoveHandler calThrowinPlanDate.Validating,AddressOf calThrowinPlanDate_Validate
                Call calThrowinPlanDate_Validate(calThrowinPlanDate,New CancelEventArgs(True))
                AddHandler calThrowinPlanDate.Validating,AddressOf calThrowinPlanDate_Validate

            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "calThrowinPlanDate_CalendarSelect"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calThrowinPlanDate_Change
    '機　能：投入予定日変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:23:17 N.Kasai
    '更新日：2007/10/11 (Thu) 13:23:17
    '備　考：
    Private Sub calThrowinPlanDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calThrowinPlanDate.Change
        
        Try
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ一括制御
            Call prvButtonEnabled_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "calThrowinPlanDate_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calThrowinPlanDate_Validate
    '機　能：投入予定日選択処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:23:50 N.Kasai
    '更新日：2007/10/11 (Thu) 13:23:50
    '備　考：
    Private Sub calThrowinPlanDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calThrowinPlanDate.Validating

        Dim lstrNowDT           As String       '現在日付取得

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞの初期化
            mblnErrChkFlag = False
            
            With calThrowinPlanDate
            
                '@日付が入力されている場合
                If .Value <> CPstrNullDate Then
                    '@日付の有効性ﾁｪｯｸ
                    If pubblnYearRange_Chk(.Value) = False Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                        '@"正しい日付を入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾌｫｰｶｽを移さない
                        e.Cancel = True
                        '@ｴﾗｰﾌﾗｸﾞON
                        mblnErrChkFlag = True
                    Else
                        '@変更後日付が過去日付でも「変更前」=「変更後」の場合はﾁｪｯｸしない
                        If lblBeforePlanThrowDate.Text <> .Value Then
                            '@現在日付取得
                            lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                            
                            '@現在日付より過去の場合
                            If Format$(CDate(.Value), CPstrDateTimeYMD) < lstrNowDT Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                                
                                '@"過去日付は指定できません。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                   
                                '@ﾌｫｰｶｽを移さない
                                e.Cancel = True
                                
                                '@ｴﾗｰﾌﾗｸﾞON
                                mblnErrChkFlag = True
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
                .strProcName = "calThrowinPlanDate_Validate"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calPlanShipDate_CalendarSelect
    '機　能：投入予定日選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:22:55 N.Kasai
    '更新日：2007/11/06 (Tue) 11:45:45 N.Kasai
    '備　考：
    Private Sub calPlanShipDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calPlanShipDate.CalendarSelect
        
        Try
            
            '@空白の場合は処理しない
            If calPlanShipDate.Value <> CPstrNullDate Then
                '@Validate処理へ
                RemoveHandler calPlanShipDate.Validating,AddressOf calPlanShipDate_Validate
                Call calPlanShipDate_Validate(calPlanShipDate,New CancelEventArgs(True))
                AddHandler calPlanShipDate.Validating,AddressOf calPlanShipDate_Validate

            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "calPlanShipDate_CalendarSelect"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2010/05/07 (Fri) 11:08:01 T.Oide **************************************************
    '関数名：calPlanAssThrowinDate_CalendarSelect
    '機　能：組立投入予定日選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/05/07 (Fri) 11:08:51 T.Oide
    '更新日：2010/05/07 (Fri) 11:08:51 T.Oide
    '備　考：
    Private Sub calPlanAssThrowinDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calPlanAssThrowinDate.CalendarSelect
        
        Try
            
            '@空白の場合は処理しない
            If calPlanAssThrowinDate.Value <> CPstrNullDate Then
                '@Validate処理へ
                RemoveHandler calPlanAssThrowinDate.Validating, AddressOf calPlanAssThrowinDate_Validate
                Call calPlanAssThrowinDate_Validate(calPlanAssThrowinDate,New CancelEventArgs(True))
                AddHandler calPlanAssThrowinDate.Validating, AddressOf calPlanAssThrowinDate_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                         '機能ID
                .strProcName = "calPlanAssThrowinDate_CalendarSelect"
                .strErrMessage = vbNullString                           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2010/05/07 (Fri) 11:08:01 T.Oide **************************************************

    '関数名：calPlanShipDate_Change
    '機　能：送品予定日変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:23:17 N.Kasai
    '更新日：2007/11/06 (Tue) 11:45:48 N.Kasai
    '備　考：
    Private Sub calPlanShipDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calPlanShipDate.Change
        
        Try
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ一括制御
            Call prvButtonEnabled_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "calPlanShipDate_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2010/05/07 (Fri) 11:10:10 T.Oide **************************************************
    '関数名：calPlanAssThrowinDate_Change
    '機　能：組立投入予定日変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/05/07 (Fri) 11:10:40 T.Oide
    '更新日：2010/05/07 (Fri) 11:10:40 T.Oide
    '備　考：
    Private Sub calPlanAssThrowinDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calPlanAssThrowinDate.Change
        
        Try
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ一括制御
            Call prvButtonEnabled_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "calPlanAssThrowinDate_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2010/05/07 (Fri) 11:10:10 T.Oide **************************************************

    '関数名：calPlanShipDate_Validate
    '機　能：送品予定日選択処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:23:50 N.Kasai
    '更新日：2007/11/06 (Tue) 11:45:52 N.Kasai
    '備　考：
    '　　　：2008/03/31 (Mon) 13:26:37 Y.Tomiya     ｺﾝﾄﾛｰﾙ名誤記修正(ｼｽﾃﾑ案件No.02695)
    Private Sub calPlanShipDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calPlanShipDate.Validating

        Dim lstrNowDT           As String       '現在日付取得

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞの初期化
            mblnErrChkFlag = False
            
            With calPlanShipDate
            
                '@日付が入力されている場合
                If .Value <> CPstrNullDate Then
                    '@日付の有効性ﾁｪｯｸ
                    If pubblnYearRange_Chk(.Value) = False Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                        '@"正しい日付を入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾌｫｰｶｽを移さない
                        e.Cancel = True
                        '@ｴﾗｰﾌﾗｸﾞON
                        mblnErrChkFlag = True
                    Else
                        '@変更後日付が過去日付でも「変更前」=「変更後」の場合はﾁｪｯｸしない
                        If lblBeforePlanShipDate.Text <> .Value Then
                            '@現在日付取得
                            lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                            
                            '@現在日付より過去の場合
                            If Format$(CDate(.Value), CPstrDateTimeYMD) < lstrNowDT Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                                
                                '@"過去日付は指定できません。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                   
                                '@ﾌｫｰｶｽを移さない
                                e.Cancel = True
                                
                                '@ｴﾗｰﾌﾗｸﾞON
                                mblnErrChkFlag = True
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
                .strProcName = "calPlanShipDate_Validate"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2010/05/07 (Fri) 10:34:20 T.Oide **************************************************
    '関数名：calPlanAssThrowinDate_Validate
    '機　能：組立投入予定日変更後処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2010/05/07 (Fri) 10:34:56 T.Oide
    '更新日：2010/05/07 (Fri) 10:34:56 T.Oide
    '備　考：
    Private Sub calPlanAssThrowinDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calPlanAssThrowinDate.Validating

        Dim lstrNowDT           As String       '現在日付取得

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞの初期化
            mblnErrChkFlag = False
            
            With calPlanAssThrowinDate
            
                '@日付が入力されている場合
                If .Value <> CPstrNullDate Then
                    '@日付の有効性ﾁｪｯｸ
                    If pubblnYearRange_Chk(.Value) = False Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                        '@"正しい日付を入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾌｫｰｶｽを移さない
                        e.Cancel = True
                        '@ｴﾗｰﾌﾗｸﾞON
                        mblnErrChkFlag = True
                    Else
                        '@変更後日付が過去日付でも「変更前」=「変更後」の場合はﾁｪｯｸしない
                        If lblBeforePlanAssThrowinDate.Text <> .Value Then
                            '@現在日付取得
                            lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                            
                            '@現在日付より過去の場合
                            If Format$(CDate(.Value), CPstrDateTimeYMD) < lstrNowDT Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                                
                                '@"過去日付は指定できません。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                   
                                '@ﾌｫｰｶｽを移さない
                                e.Cancel = True
                                
                                '@ｴﾗｰﾌﾗｸﾞON
                                mblnErrChkFlag = True
                            End If
                        End If
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "calPlanAssThrowinDate_Validate"
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2010/05/07 (Fri) 10:34:20 T.Oide **************************************************

    '関数名：optPrClass_Click
    '機　能：P/R区分の選択
    '引　数：Index：　0：Pｵｰﾀﾞｰ、1:Rｵｰﾀﾞｰ
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:30:53 N.Kasai
    '更新日：2007/10/11 (Thu) 13:30:53
    '備　考：
    Private Sub optPrClass_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optPrClass0.CheckedChanged,optPrClass1.CheckedChanged

        Dim llngCnt As Integer      '汎用ｶｳﾝﾀ
        
        Try

            If sender.checked = False Then
                Exit Sub
            End If

            '@P/R区分によりP/Rｵｰﾀﾞｰｺﾝﾎﾞに設定する
            With cmbPrOrder
                
                .Clear
                
                '@P/R区分にて設定内容を変更する
                Select Case sender.Name
                    Case optPrClass0.Name
                    '@Pｵｰﾀﾞｰ
                        For llngCnt = 0 To mtypPrOrderListAns.lngPrOrderListCnt -1
                            '@Pｵｰﾀﾞｰ判定(ｵｰﾀﾞｰID＋ｵｰﾀﾞｰｺﾒﾝﾄ)
                            If Strings.Left$(mtypPrOrderListAns.typPrOrderList(llngCnt).strPROrderID, 1) = CPstrPrOrderClassP Then
                                .AddItem(mtypPrOrderListAns.typPrOrderList(llngCnt).strPROrderID _
                                        & vbTab _
                                        & mtypPrOrderListAns.typPrOrderList(llngCnt).strOrderComments)
                            End If
                        Next
                    
                    Case optPrClass1.Name
                    '@Rｵｰﾀﾞｰ
                        For llngCnt = 0 To mtypPrOrderListAns.lngPrOrderListCnt -1
                            '@Pｵｰﾀﾞｰ判定(ｵｰﾀﾞｰID＋ｵｰﾀﾞｰｺﾒﾝﾄ)
                            If Strings.Left$(mtypPrOrderListAns.typPrOrderList(llngCnt).strPROrderID, 1) = CPstrPrOrderClassR Then
                                .AddItem(mtypPrOrderListAns.typPrOrderList(llngCnt).strPROrderID _
                                        & vbTab _
                                        & mtypPrOrderListAns.typPrOrderList(llngCnt).strOrderComments)
                            End If
                        Next
                End Select
                
                '@P/Rｵｰﾀﾞｰｺﾒﾝﾄもｸﾘｱ
                txtOrderComment.Text = vbNullString
                
                '@P/Rｵｰﾀﾞｰが1件の場合は表示
                If .ListCount = 1 Then
                    .ListIndex = 0
                    
                    '@値取得列をｺﾒﾝﾄに変更
                    .ValueCol = 1
                    '@P/Rｵｰﾀﾞｰｺﾒﾝﾄを表示
                    txtOrderComment.Text = .Value
                    txtOrderComment.Enabled = True
                    '@値取得列を戻す
                    .ValueCol = 0
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optPrClass_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPrOrder_Change
    '機　能：P/Rｵｰﾀﾞｰｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:30:32 N.Kasai
    '更新日：2007/10/11 (Thu) 13:30:32
    '備　考：
    Private Sub cmbPrOrder_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPrOrder.Change
        
        Try

            '@P/Rｵｰﾀﾞｰ項目ﾁｪｯｸ

            '@ﾛｯﾄIDﾁｪｯｸ
            If txtLot.Text <> vbNullString Then

                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ一括制御
                Call prvButtonEnabled_Proc()
            
                '@値取得列をｺﾒﾝﾄに変更
                cmbPrOrder.ValueCol = 1
                '@P/Rｵｰﾀﾞｰｺﾒﾝﾄを表示
                txtOrderComment.Text = cmbPrOrder.Value
                txtOrderComment.Enabled = True
                '@値取得列を戻す
                cmbPrOrder.ValueCol = 0
            End If
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPrOrder_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPrOrder_CloseUp
    '機　能：P/RｵｰﾀﾞｰCloseUp
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:30:18 N.Kasai
    '更新日：2007/10/11 (Thu) 13:30:18 N.Kasai
    '備　考：
    Private Sub cmbPrOrder_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPrOrder.CloseUp
        
        Try
            
             With cmbPrOrder
             
                '@P/Rｵｰﾀﾞｰが選択されている場合
                .ValueCol = 0
                
                If .Value <> vbNullString Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPrOrder_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSendSBID_Change
    '機　能：送品先ｺﾝﾎﾞ　変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:32:47 N.Kasai
    '更新日：2007/10/11 (Thu) 13:32:47 N.Kasai
    '備　考：
    Private Sub cmbSendSBID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSendSBID.Change
        
        Try

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ一括制御
            Call prvButtonEnabled_Proc()
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSendSBID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSendSBID_CloseUp
    '機　能：送品先ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:32:33 N.Kasai
    '更新日：2007/10/11 (Thu) 13:32:33
    '備　考：
    Private Sub cmbSendSBID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSendSBID.CloseUp
        
        Try
            
             With cmbSendSBID
                '@IDが選択されている場合
                .ValueCol = 1
                If .Value <> vbNullString Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSendSBID_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbLotSend_Change
    '機　能：送品ｺﾝﾎﾞ変更
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:33:17 N.Kasai
    '更新日：2007/10/11 (Thu) 13:33:17 N.Kasai
    '備　考：
    Private Sub cmbLotSend_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotSend.Change

        Try

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ一括制御
            Call prvButtonEnabled_Proc()

           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbLotSend_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbLotSend_CloseUp
    '機　能：送品ｺﾝﾎﾞ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:33:24 N.Kasai
    '更新日：2007/10/11 (Thu) 13:33:24 N.Kasai
    '備　考：
    Private Sub cmbLotSend_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotSend.CloseUp

        Try

            With cmbLotSend
                '@IDが選択されている場合
                .ValueCol = 1
                If .Value <> vbNullString Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbLotSend_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtOrderComment_Change
    '機　能：P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:34:31 N.Kasai
    '更新日：2007/10/11 (Thu) 13:34:31
    '備　考：
    Private Sub txtOrderComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtOrderComment.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtOrderComment, CMlngMaxDispMemoRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtOrderComment_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtOrderComment_KeyUp
    '機　能：P/Rｵｰﾀﾞｰｺﾒﾝﾄﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:35:20 N.Kasai
    '更新日：2007/10/11 (Thu) 13:35:20 N.Kasai
    '備　考：
    Private Sub txtOrderComment_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtOrderComment.KeyUp
        
        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtOrderComment, CMlngMaxDispMemoRow, cmdCommentUp, cmdCommentDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtOrderComment_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtOrderComment_MouseUp
    '機　能：P/Rｵｰﾀﾞｰｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:35:31 N.Kasai
    '更新日：2007/10/11 (Thu) 13:35:31
    '備　考：
    Private Sub txtOrderComment_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles txtOrderComment.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtOrderComment, CMlngMaxDispMemoRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtOrderComment_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdCommentUp_Click
    '機　能：P/Rｵｰﾀﾞｰｺﾒﾝﾄの前頁切替(▲ﾎﾞﾀﾝ)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:35:48 N.Kasai
    '更新日：2007/10/11 (Thu) 13:35:48 N.Kasai
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
                
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtOrderComment, CMlngMaxDispMemoRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentDown_Click
    '機　能：P/Rｵｰﾀﾞｰｺﾒﾝﾄの次頁切替(▼ﾎﾞﾀﾝ)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:35:59 N.Kasai
    '更新日：2007/10/11 (Thu) 13:35:59 N.Kasai
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
                
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtOrderComment, CMlngMaxDispMemoRow, cmdCommentUp, cmdCommentDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWFNum_Change
    '機　能：変更後WF枚数の変更後処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:17:29 N.Kasai
    '更新日：2007/10/11 (Thu) 13:17:29 N.Kasai
    '備　考：
    Private Sub txtWFNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWFNum.Change
        
        Try

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ一括制御
            Call prvButtonEnabled_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtWFNum_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWFNum_Validate
    '機　能：変更後WF枚数のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:17:38 N.Kasai
    '更新日：2007/10/11 (Thu) 13:17:38
    '　　　：2008/09/03 (Wed) 12:03:53 T.Sawaguchi  最大WF枚数でﾁｪｯｸする様に変更　(案件03044)
    '備　考：
    Private Sub txtWFNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtWFNum.Validating
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞの初期化
            mblnErrChkFlag = False
            
            '@数量ﾁｪｯｸ
            '@最大WF枚数、WF数量がNULLでない場合
            If mtypLotAttribute.strMaxWFCount <> vbNullString And txtWFNum.Text <> vbNullString Then
                '@数値であるか判定
                If IsNumeric(mtypLotAttribute.strMaxWFCount) = True And IsNumeric(txtWFNum.Text) = True Then
                    
                    '@[WF枚数が機種の最大WF枚数より大きいか] から
                    '@  ｢WF枚数が最大WF枚数25より大きいか」　に変更
                    If CMlngMaxWF < CLng(txtWFNum.Text) Then
                        
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0086, txtWFNum.Text, CMlngMaxWF)
                        '@ﾒｯｾｰｼﾞ：""<TRM86W>$$ウエハ枚数[%1]が最大WF枚数の設定値[%2]を超えています。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾌｫｰｶｽ保持
                        e.Cancel = True
                        
                        '@ｴﾗｰﾌﾗｸﾞON
                        mblnErrChkFlag = True

                        Exit Sub
                    End If
                    
                    '@入力枚数が"0"の場合
                    If CLng(txtWFNum.Text) = 0 Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0015)
                        
                        '@"<TRM15W>$$ウエハ枚数を指定して下さい。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾌｫｰｶｽ保持
                        e.Cancel = True
                        
                        '@ｴﾗｰﾌﾗｸﾞON
                        mblnErrChkFlag = True

                        Exit Sub
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtWFNum_Validate"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：作業ﾒﾓ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:36:19 N.Kasai
    '更新日：2008/05/07 (Wed) 10:39:10 M.Koni
    '備　考：
    '　　　：2008/05/07 (Wed) 10:39:10 M.Koni   <案件No.2836> 作業ﾒﾓの入力判定追加
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change
        
        Dim llngNowByte     As Integer  'ｺﾒﾝﾄ桁数

        Try
               
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtWorkMemo.NowByte
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
                            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ一括制御
            Call prvButtonEnabled_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：作業ﾒﾓｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:36:39 N.Kasai
    '更新日：2007/10/11 (Thu) 13:36:39 N.Kasai
    '備　考：
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：作業ﾒﾓﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:36:49 N.Kasai
    '更新日：2007/10/11 (Thu) 13:36:49 N.Kasai
    '備　考：
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown,)
            
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

    '関数名：cmdMemoUp_Click
    '機　能：ｺﾒﾝﾄの前頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:37:00 N.Kasai
    '更新日：2007/10/11 (Thu) 13:37:00 N.Kasai
    '備　考：
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：ｺﾒﾝﾄの次頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:37:10 N.Kasai
    '更新日：2007/10/11 (Thu) 13:37:10
    '備　考：
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：prvcmbWplist_Disp
    '機　能：ﾚﾁｸﾙ使用装置ｺﾝﾎﾞﾎﾞｯｸｽ作成(1stﾌｫﾄ号機ﾘｽﾄ作成用)
    '引　数：llngWpCnt:装置数
    '戻り値：なし
    '作成日：2008/07/04 (Fri) 13:29:48 M.Koni       新規作成<案件No.02959>
    '更新日：
    '備　考：
    Private Sub prvcmbWplist_Disp(ByVal llngWpCnt As Integer)
        
        Dim llngCnt         As Integer                  '表示ｶｳﾝﾄ

        Try
            
            '@1stﾌｫﾄ号機一覧表示ｺﾝﾎﾞ
            With CmbFirstPhotoWpName
                '@ﾚﾁｸﾙ使用装置ｺﾝﾎﾞﾘｽﾄ初期化
                    .Clear
                    .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                    .GetCol = CMlngCmbGridCol0                                      'ﾃｷｽﾄ表示列
                    .ValueCol = CMlngCmbGridCol1                                    '値取得列
                    .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                    With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                        CmbFirstPhotoWpName.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                            .Unit, .GdiCharSet, .GdiVerticalFont)
                    End With
                    With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                        CmbFirstPhotoWpName.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                            .Unit, .GdiCharSet, .GdiVerticalFont)
                    End With
                    .RowHeight = CMlngComboRowHeight                                '行の高さ
                    .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左中央
                    .Enabled = False                                                '使用不可(ﾃﾞﾌｫﾙﾄ設定)

                    '@配列の件数ﾁｪｯｸ
                    If llngWpCnt <> 0 Then
                        mblnWpListZeroFlag = False
                        For llngCnt = 0 To llngWpCnt -1
                            .AddItem(ptypWPList(llngCnt).strWpName & vbTab & ptypWPList(llngCnt).strWpID)
                        Next llngCnt

                    Else
                        mblnWpListZeroFlag = True
                    End If
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbWplist_Disp[CM01A0]"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotchgattr_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:38:38 N.Kasai
    '更新日：2019/01/30 (Wed) 11:05:43 T.Oide
    '備　考：
    Private Sub cmdLotchgattr_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotchgattr.Click
        
        Dim ltypLotchgAttribute         As LotchgAttribute      'ﾛｯﾄ情報変更削除
        Dim lstrAnsDspMsg               As String               '表示Msg
        Dim lblnAns                     As Boolean              '登録戻り値(True/False)
        Dim lstrFunctionID              As String               '機能ID
        Dim lstrActionID                As String               'ｱｸｼｮﾝID
        Dim lstrEmpName                 As String               '作業者名
        Dim lblnAuthorityChkFlag        As Boolean              '権限ﾁｪｯｸﾌﾗｸﾞ(True:権限ﾁｪｯｸ要,False:権限ﾁｪｯｸ不要)
        Dim lstrWkEmpID                 As String               '作業者ID(退避)
        Dim llngMsgAns                  As Integer              'ﾒｯｾｰｼﾞﾎﾞｯｸｽの結果格納


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

            '@入力/変更内容ﾁｪｯｸ
            lblnAns = prvblnChangeData_Chk
            
            '@変更内容ﾁｪｯｸ判定
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ用ｲﾍﾞﾝﾄ名取得
            mstrEventName = "cmdLotchgattr_Click"
            
            
            '@----------------------------------------------------------------------------------------------
            '@2007/12/07　権限ﾁｪｯｸ内容改定
            '@◇送品先変更
            '@「送品先設定」の権限がある場合のみ、変更可能。
            '@(ﾛｯﾄ担当 = 確定ユーザーの場合でも変更不可)
            '
            '@◇送品予定日変更
            '@「送品予定日変更」の権限がある場合のみ、変更可能。
            '@(ﾛｯﾄ担当 = 確定ユーザーの場合でも変更不可)
            '
            '@◇ロット情報変更/削除
            '@量産オーダ番号がある場合は無条件で権限チェック
            '@ﾛｯﾄ担当 =  確定ユーザー：送品先変更,送品予定日変更を除いて､変更可能｡
            '@ﾛｯﾄ担当 <> 確定ユーザー：送品先変更,送品予定日変更を除いて「変更/削除」の権限がある場合、変更可能。(投入前ロット限定)
            '@----------------------------------------------------------------------------------------------
            
            '@ﾌﾗｸﾞの初期化
            lblnAuthorityChkFlag = False

            lstrWkEmpID = vbNullString
            
            '@優先度変更ﾁｪｯｸ
            If mblnChgWfNumFlag = False And _
               mblnChgLotManagerFlag = False And _
               mblnChgPlanDateFlag = False And _
               mblnChgPrOrderFlag = False And _
               mblnChgSendSBIDFlag = False And _
               mblnChgLotSendFlag = False And _
               mblnChgPlanShipDateFlag = False And _
               mblnChgPlanAssTrowinDateFlag = False And _
               mblnChgPrioFlag = True Then
                 
                '@優先度のみの変更は無条件で権限ﾁｪｯｸなし
                '@権限ﾁｪｯｸ不要
                lblnAuthorityChkFlag = False
            Else
                '@送品先変更あり
                If mblnChgSendSBIDFlag = True Then
                    '@権限ﾁｪｯｸ要
                    lblnAuthorityChkFlag = True
                End If
                '@送品予定日変更
                If mblnChgPlanShipDateFlag = True Then
                    '@権限ﾁｪｯｸ要
                    lblnAuthorityChkFlag = True
                End If

                '@基板投入予定変更
                If mblnChgPlanAssTrowinDateFlag = True Then
                    '@権限ﾁｪｯｸ要
                    lblnAuthorityChkFlag = True
                End If
                
                '@組立投入予定変更
                If mblnChgPlanAssTrowinDateFlag = True Then
                    '@権限ﾁｪｯｸ要
                    lblnAuthorityChkFlag = True
                End If

            End If
            
            If mblnChgPrioFlag And mblnSectionPriorityFlg Then
                '@"<TRM7AI>$$ロット[%1]には区間優先設定がされています。$確定処理を実行すると区間優先設定はクリアされますので、$必要に応じ再設定してください。$よろしいですか？"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007A, txtLot.Text)
                llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
            
                '@結果確認
                If llngMsgAns = vbNo Then
                    '@いいえの場合は処理中止
                    
                    Exit Sub
                End If
            
            End If
            
            '@CPstrWaitThrowSt:"投入待ち"
            If lblStatus.Text = CPstrWaitThrowSt Then
                '@権限ﾁｪｯｸ不要の場合
                If lblnAuthorityChkFlag = False Then
                
                    '@作業者ｺｰﾄﾞ入力
                    frmxxCM0010.Instance.ShowDialog(Me)
                    frmxxCM0010.Instance = Nothing
                    '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
                    If pstrUserID = vbNullString Then
                        '@未入力の場合、投入中止
                        Exit Sub
                    End If
                
                    '@変更前のﾛｯﾄ担当と作業者IDが異なる場合は、権限ﾁｪｯｸ要
                    If mtypLotAttribute.strEngEmpId <> vbNullString And _
                       mtypLotAttribute.strEngEmpId <> pstrUserID Then
                        '@作業者ID退避
                        lstrWkEmpID = pstrUserID
                        '@権限ﾁｪｯｸ要
                        lblnAuthorityChkFlag = True
                    End If
                End If
            End If

            '@作業者ID入力判定
            If lblnAuthorityChkFlag = True Then
                
                If lstrWkEmpID <> vbNullString Then
                
                    '@ﾊﾟｽﾜｰﾄﾞ付き作業者ID
                    With frmxxCM0020.Instance
                        .txtUserID.Text = lstrWkEmpID
                        .txtUserID.Enabled = False
                        .ShowDialog(Me)
                        frmxxCM0020.Instance = Nothing
                    End With
                Else
                
                    '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
                    frmxxCM0020.Instance.ShowDialog(Me)
                    frmxxCM0020.Instance = Nothing
                End If
                
                '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
                If pstrUserID = vbNullString Then
                    '@未入力の場合、投入中止
                    Exit Sub
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, mstrEventName)
                
                '@変更前の送品先と変更後送品先が異なる場合は、権限ﾁｪｯｸ
                If mtypLotAttribute.strSendSBName <> cmbSendSBID.Text Then
                
                    '@実行権限の処理を追加
                    lstrFunctionID = CPstrKeyEN0290                 '機能ID：EN0290
                    
        '@↓2019/01/30 (Wed) 09:59:50 T.Oide **************************************************
        '@            '@起動SBに従い、ｱｸｼｮﾝIDを設定する
        '@            If pstrSBID = CPstrSBID1A0 Then
        '@                '@基板起動の場合
        '@                lstrActionID = CPstr1A0ChangeSendSB     'ｱｸｼｮﾝID：基板送品先設定
        '@            Else
        '@                '@組立起動の場合
        '@                lstrActionID = CPstr2A0ChangeSendSB     'ｱｸｼｮﾝID：組立送品先設定
        '@            End If
        '@------------------------------------------------------------------------------------
                    '@起動SBに従い、ｱｸｼｮﾝIDを設定
                    Select Case pstrSBID
                    
                        '@基板起動の場合
                        Case CPstrSBID1A0
                            lstrActionID = CPstr1A0ChangeSendSB     'ｱｸｼｮﾝID：基板送品先設定
                        
                        '@組立起動の場合
                        Case CPstrSBID2A0
                            lstrActionID = CPstr2A0ChangeSendSB     'ｱｸｼｮﾝID：組立送品先設定
                        
                        '@組立起動の場合
                        Case CPstrSBID3A0
                            lstrActionID = CPstr3A0ChangeSendSB     'ｱｸｼｮﾝID：防湿膜ALD送品先設定
                    
                    End Select
        '@↑2019/01/30 (Wed) 09:59:50 T.Oide **************************************************
                    
                    lstrEmpName = vbNullString                      'ﾕｰｻﾞｰ名
                
                    '@実行権限ﾁｪｯｸ
                    lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, pstrUserID, lstrEmpName, pstrSBID)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, mstrEventName)
                
                        '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                        '@警告ﾒｯｾｰｼﾞ
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                        Exit Sub
                    End If
                End If
                
                '@送品予定日変更の場合は権限ﾁｪｯｸ
                If mblnChgPlanShipDateFlag = True Then
                    '@実行権限の処理を追加
                    lstrFunctionID = CPstrKeyEN0290             '機能ID：EN0290
                    lstrActionID = CPstrPlanShipAuth            'ｱｸｼｮﾝID：送品予定日変更
                    lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
                
                    '@実行権限ﾁｪｯｸ
                    lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, pstrUserID, lstrEmpName, pstrSBID)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, mstrEventName)
                
                        '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                        '@警告ﾒｯｾｰｼﾞ
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                        Exit Sub
                    End If
                End If
                
                '@組立投入予定日変更の場合は権限ﾁｪｯｸ
                If mblnChgPlanAssTrowinDateFlag = True Then
                    '@実行権限の処理を追加
                    lstrFunctionID = CPstrKeyEN0290             '機能ID：EN0290
                    lstrActionID = CPstrPlanAssembleAuth        'ｱｸｼｮﾝID：組立投入予定変更
                    lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
                
                    '@実行権限ﾁｪｯｸ
                    lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, pstrUserID, lstrEmpName, pstrSBID)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, mstrEventName)
                
                        '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                        '@警告ﾒｯｾｰｼﾞ
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                        Exit Sub
                    End If
                End If

                '@送品先/送品予定日/優先度変更は対象外
                If mblnChgWfNumFlag = True Or _
                   mblnChgLotManagerFlag = True Or _
                   mblnChgPlanDateFlag = True Or _
                   mblnChgPrOrderFlag = True Or _
                   mblnChgLotSendFlag = True Then
                
                    '@変更前のﾛｯﾄ担当と作業者IDが異なる場合は、権限ﾁｪｯｸ
                    If mtypLotAttribute.strEngEmpId <> vbNullString And _
                       mtypLotAttribute.strEngEmpId <> pstrUserID Then
                        
                        '@実行権限の処理を追加
                        lstrFunctionID = CPstrKeyEN0290             '機能ID：EN0290
                        lstrActionID = CPstrLotChgPlan              'ｱｸｼｮﾝID：変更/削除
                        lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
                    
                        '@実行権限ﾁｪｯｸ
                        lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, pstrUserID, lstrEmpName, pstrSBID)
                        '@結果判定
                        If lblnAns = False Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, mstrEventName)
                    
                            '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                            '@警告ﾒｯｾｰｼﾞ
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                            Exit Sub
                        End If
                    End If
                End If
                
            Else
            
                '@CPstrWaitThrowSt:"投入待ち"　and 権限ﾁｪｯｸ不要の場合
                If lblStatus.Text = CPstrWaitThrowSt And lblnAuthorityChkFlag = False Then
                    '@上位条件で作業者ID入力済み
                Else
                    '@作業者ｺｰﾄﾞ入力
                    frmxxCM0010.Instance.ShowDialog(Me)
                    frmxxCM0010.Instance = Nothing
                    
                     '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
                    If pstrUserID = vbNullString Then
                        '@未入力の場合、投入中止
                        Exit Sub
                    End If
                End If
               
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, mstrEventName)
            End If
            
            
            '@送信ﾃﾞｰﾀ作成
            With ltypLotchgAttribute
                .strMsgVer = CMstrlot_chgattributeVer                   'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strLotID = txtLot.Text                                 'ﾛｯﾄID
               
                '@CFﾌﾗｸﾞ判定
                Select Case mtypLotAttribute.strCfFlag
                    '@大版
                    Case "0"
                        .strPlanThrowinQuantity = txtWFNum.Text
                    '@小版
                    Case "1"
                        '@CFﾛｯﾄの場合
                        If mtypLotAttribute.strLpFlag = "0" Then
                            '@CFﾛｯﾄの場合はWF枚数をそのまま返却
                            .strPlanThrowinQuantity = mtypLotAttribute.strWfNum
                        Else
                            '@ODFﾛｯﾄの場合
                            .strPlanThrowinQuantity = txtWFNum.Text
                        End If
                    '@TPALﾛｯﾄ
                    Case "2"
                        '@CFﾛｯﾄの場合はWF枚数をそのまま返却
                        .strPlanThrowinQuantity = mtypLotAttribute.strWfNum
                End Select
                
                '@ﾛｯﾄ担当がNULLか
                If cmbLotManager.Value = vbNullString Then
                    .strEngEmpId = mtypLotAttribute.strEngEmpId         'mtypLotAttributeの情報を格納
                Else
                    .strEngEmpId = cmbLotManager.Value                  '選択ﾛｯﾄ担当(ID)を格納
                End If
                
                '@日付のﾁｪｯｸ
                If calThrowinPlanDate.Value <> CPstrNullDate Then
                    .strPlanThrowinDate = calThrowinPlanDate.Value      '投入予定日
                Else
                    .strPlanThrowinDate = vbNullString                  '投入予定日(空白)
                End If
                
                '@優先度が選択されていない場合は区間優先度が表示されていることを想定
                If cmbPrioSel.Value = vbNullString Then
                    .strLotPriority = mtypLotAttribute.strLotPriority   '区間優先度
                Else
                    .strLotPriority = cmbPrioSel.Value                  '優先度ID
                End If
                
                '@PRｵｰﾀﾞ
                If cmbPrOrder.Value = vbNullString Then
                    .strPROrderID = mtypLotAttribute.strPROrderID       'P/RｵｰﾀﾞｰIDがNullなら，mtypLotAttributeの情報を採用
                Else
                    .strPROrderID = cmbPrOrder.Value                    'P/RｵｰﾀﾞｰID
                End If
                
                .strLotSendFlag = cmbLotSend.Value                      '送品ﾌﾗｸﾞ
                .strSendSBID = cmbSendSBID.Value                        '送品先ID
                
                '@日付のﾁｪｯｸ
                If calPlanShipDate.Value <> CPstrNullDate Then
                    .strPlanShipDate = calPlanShipDate.Value            '送品予定日
                Else
                    .strPlanShipDate = vbNullString                     '送品予定日(空白)
                End If
                
                .strComments = txtWorkMemo.Text                         'ｺﾒﾝﾄ
                .strEmpID = pstrUserID                                  '作業者ID
                .strLotLastUpdate = mtypLotAttribute.strLotLastUpdate   'ﾛｯﾄ最終更新日時

                '@1stﾌｫﾄ号機のﾃﾞｰﾀ設定(WP_IDを渡す)
                If CmbFirstPhotoWpName.Value <> vbNullString Then
                    .strFirstPhotoWpID = CmbFirstPhotoWpName.Value
                Else
                    .strFirstPhotoWpID = vbNullString
                End If

                '@組立投入予定日のﾃﾞｰﾀ設定
                If calPlanAssThrowinDate.Value <> CPstrNullDate Then
                    .strPlanAssThrowinDate = calPlanAssThrowinDate.Value
                Else
                    .strPlanAssThrowinDate = vbNullString
                End If

            End With
            
            '@ﾛｯﾄ情報変更
            lblnAns = pubblnLotChgAttribute_Upd(ltypLotchgAttribute)
            
            '@戻り値判定
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)

                '@表示用Msg作成
                lstrAnsDspMsg = prvstrDispMsg_Proc

                '@Msg表示
                If lstrAnsDspMsg <> vbNullString Then
                    '@ｷｬﾘｱIDがNULLか判定し、Msg表示形式を変える
                    If txtCarrier.Text <> vbNullString Then
                    '@ｷｬﾘｱID <> NULL
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM5CI>$$%1に変更しました。キャリア[%2] ロット[%3]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005C, lstrAnsDspMsg, txtCarrier.Text, txtLot.Text)
                        Call pubVsfInfo_Disp(pstrDMsg)
                    Else
                    '@ｷｬﾘｱID = NULL
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM5EI>$$%1に変更しました。ロット[%2]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005E, lstrAnsDspMsg, txtLot.Text)
                        Call pubVsfInfo_Disp(pstrDMsg)
                    End If
                Else
                    '@その他の場合(例外ｴﾗｰ対応)
                    '@"<TRM10I>$$ロット情報を変更しました。ロット[%1]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0010, txtLot.Text)
                    '@ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                End If
                
                '@画面初期化
                Call prvfrmxxCM01A0_Init()
                
                '@ｷｬﾘｱID,ﾛｯﾄIDの初期化
                txtCarrier.Text = vbNullString
                txtLot.Text = vbNullString
            Else
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
				'@画面初期化
				Call prvfrmxxCM01A0_Init()
				'@ｷｬﾘｱID,ﾛｯﾄIDの初期化
                txtCarrier.Text = vbNullString
                txtLot.Text = vbNullString
				'@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
				Call pubSetFocus(txtCarrier)
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotchgattr_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCancelPlan_Click
    '機　能：削除ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/12 (Fri) 10:29:30 N.Kasai
    '更新日：2013/11/28 (Thu) 13:07:51 T.Inafune
    '備　考：
    Private Sub cmdCancelPlan_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelPlan.Click
        Dim lblnAns                     As Boolean          '登録戻り値(True/False)
        Dim lstrFunctionID              As String           '機能ID
        Dim lstrActionID                As String           'ｱｸｼｮﾝID
        Dim lstrEmpName                 As String           '作業者名
        Dim lblnAuthorityChkFlag        As Boolean          '権限ﾁｪｯｸﾌﾗｸﾞ(True:権限ﾁｪｯｸ要,False:権限ﾁｪｯｸ不要)
        Dim ltypLotCancelPlan           As LotCancelPlan    '投入予定ﾛｯﾄ削除要求格納
        
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@権限ﾁｪｯｸ要
            lblnAuthorityChkFlag = True
                
            '@ｵｰﾀﾞ№が存在し、分割子ﾛｯﾄの場合は
            '@作業者IDﾊﾟｽﾜｰﾄﾞなし、権限ﾁｪｯｸなし
            If mtypLotAttribute.strOrderNum <> vbNullString And _
                 mtypLotAttribute.strDivideFlag = "1" Then
                lblnAuthorityChkFlag = False
            End If
            
            '@権限ﾁｪｯｸ要/不要判定
            If lblnAuthorityChkFlag = False Then
                '@作業者ｺｰﾄﾞ入力
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
            Else
                '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
                frmxxCM0020.Instance.ShowDialog(Me)
                frmxxCM0020.Instance = Nothing
            End If
            
            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、変更中止
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "cmdCancelPlan_Click"
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@権限ﾁｪｯｸの有無ﾌﾗｸﾞ(True:権限ﾁｪｯｸ要,False:権限ﾁｪｯｸ不要)
            If lblnAuthorityChkFlag = True Then
                
        '@↓2013/11/28 (Thu) 11:22:19 T.Inafune **************************************************
                '@変更前のﾛｯﾄ担当と作業者IDが異なる場合は、権限ﾁｪｯｸ
        '@        If mtypLotAttribute.strEngEmpID <> vbNullString And _
        '@           mtypLotAttribute.strEngEmpID <> pstrUserID Then
                If mtypLotAttribute.strEngEmpId <> pstrUserID Then
                
                    '@実行権限の処理を追加
                    lstrFunctionID = CPstrKeyEN0290             '機能ID：EN0290
                    '@PR/ES品の場合の権限ﾁｪｯｸ追加
                    If mtypLotAttribute.strFlowClass = CPstrFlowClassPR Or _
                       mtypLotAttribute.strFlowClass = CPstrFlowClassES Then
                        lstrActionID = CPstrProductLotThrowRsv      'ｱｸｼｮﾝID:量産ロット登録
                    Else
                        lstrActionID = CPstrLotChgPlan              'ｱｸｼｮﾝID：投入予定ロット変更/削除
                    End If
                    
                    lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
        '@↑2013/11/28 (Thu) 11:22:19 T.Inafune **************************************************
                
                    '@実行権限ﾁｪｯｸ
                    lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, pstrUserID, lstrEmpName, pstrSBID)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, mstrEventName)
        '@↓2013/11/28 (Thu) 12:15:06 T.Inafune **************************************************
                        '@表示ﾒｯｾｰｼﾞ変換
        '@                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrLotChgPlan)
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
        '@↑2013/11/28 (Thu) 12:15:06 T.Inafune **************************************************
                        '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                        Exit Sub
                    End If
                End If
            End If
            
            '@要求ﾃﾞｰﾀ格納
            With ltypLotCancelPlan
                .strMsgVer = CMstrlot_cancelplanVer
                .strSbID = pstrSBID
                .strLotID = txtLot.Text
                .strLotLastUpdate = mtypLotAttribute.strLotLastUpdate
                .strEmpID = pstrUserID
            End With
            
            '@投入予定ﾛｯﾄ削除
            lblnAns = pubblnLotCancelPlan_Del(ltypLotCancelPlan)
                                              
            '@結果判定
            If lblnAns = True Then
                '@<TRM5AI>$$投入予定ロット[%1]を削除しました。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005A, txtLot.Text)
                '@ｽﾃｰﾀｽﾊﾞｰ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                '@画面初期化
                Call prvfrmxxCM01A0_Init()
                '@ﾛｯﾄIDの初期化
                txtLot.Text = vbNullString
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                
                Exit Sub
            End If

            '@ﾛｯﾄIDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtLot)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCancelPlan_Click"
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
    '関数名：prvfrmxxCM01A0_Init
    '機　能：ﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/01 (Mon) 13:24:42 N.Kasai
    '更新日：2016/02/08 (Mon) 23:10:23 H.Hayashi
    '備　考：
    '　　　：2008/06/10 (Tue) 15:09:13 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/04 (Fri) 13:38:47 M.Koni       1stﾌｫﾄ号機設定変更対応 <案件No.02959>
    '　　　：2010/05/06 (Thu) 15:30:14 T.Oide       組立投入予定日追加対応<案件No.04021>
    '　　　：2011/10/05 (Wed) 14:07:37 T.Oide       R8-4区間優先対応＜REQ-1109＞
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub prvfrmxxCM01A0_Init()

        Dim lstrFormTitle   As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0290, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
                  
            '@各種ﾗﾍﾞﾙの初期化
            lblFlowClass.Text = vbNullString                 '流動区分
            lblPdID.Text = vbNullString                      '機種名
        '@↓2016/01/25 (Mon) 00:28:26 H.Hayashi **************************************************
            lblGrbClass.Text = vbNullString                  'GRB区分
        '@↑2016/01/25 (Mon) 00:28:26 H.Hayashi **************************************************
            lblStatus.Text = vbNullString                    '状態
            lblOpID.Text = vbNullString                      '大工程名
            lblStepID.Text = vbNullString                    '小工程名
            lblTimeLimit.Text = vbNullString                 '時間制限
            lblStartTime.Text = vbNullString                 '開始日時
            lblEntryID.Text = vbNullString                   'ｴﾝﾄﾘID
            lblEntryName.Text = vbNullString                 'ｴﾝﾄﾘ名
            lblS.Text = vbNullString                         '特殊特性
            
            '@処理開始予定ﾀｲﾄﾙ設定
            lblStartTimeTitle.Text = CPstrDispatchTime       '処理開始予定
            
            
            '@ﾌﾚｰﾑ
            fraWFNum.Text = "数量変更"
            
            '@変更前
            lblBeforeWFNum.Text = vbNullString               '数量
            lblBeforeLotManager.Text = vbNullString          'ﾛｯﾄ担当者名
            lblBeforePlanThrowDate.Text = vbNullString       '投入予定日
            lblBeforePrio.Text = vbNullString                '優先度
            lblBeforePrOrder.Text = vbNullString             'P/Rｵｰﾀﾞｰ
            lblBeforeLotSend.Text = vbNullString             '送品
            lblBeforeSendSBID.Text = vbNullString            '送品先
            lblBeforePlanShipDate.Text = vbNullString        '送品予定日
            lblBeforeFirstPhotoWpName.Text = vbNullString    '1stﾌｫﾄ装置名
        '@↓2010/05/06 (Thu) 15:49:46 T.Oide **************************************************
            lblBeforePlanAssThrowinDate.Text = vbNullString  '組立送品予定日
        '@↑2010/05/06 (Thu) 15:49:46 T.Oide **************************************************
            
            '@変更後
            With txtWFNum
                .Text = vbNullString                            '数量
                .Enabled = False
            End With
            
            With cmbLotManager
                .ListIndex = -1                                 'ﾛｯﾄ担当
                .Enabled = False
            End With
            
            With calThrowinPlanDate
                .Value = vbNullString                           '変更後投入予定日
                .Enabled = False
            End With
            
            With cmbPrioSel
                .ListIndex = -1                                 '優先度
                .Enabled = False
            End With
            
        '@↓2011/10/05 (Wed) 14:07:30 T.Oide **************************************************
            With fraPrio
                .Text = CMstrfraPrioDispString
                .ForeColor = Color.Black
            End With
        '@↑2011/10/05 (Wed) 14:07:30 T.Oide **************************************************
            
            With cmbPrOrder
                .ListIndex = -1                                 'P/Rｵｰﾀﾞｰ
                .Enabled = False
            End With
            
            With cmbLotSend
                .ListIndex = -1                                 '送品
                .Enabled = False
            End With
            
            With cmbSendSBID
                .ListIndex = -1                                 '送品先
                .Enabled = False
            End With
            
            With calPlanShipDate
                .Value = vbNullString                           '変更後送品予定日
                .Enabled = False
            End With
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optPrClass0.Checked = False                         '変更後P/R区分(P)
            optPrClass1.Checked = False                         '変更後P/R区分(R)
            
            '@P/Rｵｰﾀﾞｺﾒﾝﾄ
            With txtOrderComment
                .Text = vbNullString
                .Locked = True
                .Enabled = False
            End With

            With CmbFirstPhotoWpName
                .ListIndex = -1                                 '1stフォト装置
                .Enabled = False
            End With

        '@↓2010/05/06 (Thu) 15:53:01 T.Oide **************************************************
            With calPlanAssThrowinDate
                .Value = vbNullString                           '組立送品予定日
                .Enabled = False
            End With
        '@↑2010/05/06 (Thu) 15:53:01 T.Oide **************************************************

            '@ｺﾒﾝﾄ
            With txtWorkMemo
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString
                .Enabled = False
            End With
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, txtWorkMemo.NowByte, CPlngLotCommentsMaxByte)
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ
            cmdCommentUp.Enabled = False            'P/Rｵｰﾀﾞｰ上ｽｸﾛｰﾙﾎﾞﾀﾝ(▲)
            cmdCommentDown.Enabled = False          'P/Rｵｰﾀﾞｰ上ｽｸﾛｰﾙﾎﾞﾀﾝ(▼)
            cmdMemoUp.Enabled = False               '作業ﾒﾓ上ｽｸﾛｰﾙﾎﾞﾀﾝ(▲)
            cmdMemoDown.Enabled = False             '作業ﾒﾓ上ｽｸﾛｰﾙﾎﾞﾀﾝ(▼)
            cmdLotchgattr.Enabled = False           '確定ﾎﾞﾀﾝ
            cmdCancelPlan.Enabled = False           '削除ﾎﾞﾀﾝ
            
            '@ｶﾚﾝﾀﾞｰ
            calThrowinPlanDate.Enabled = False
            calPlanShipDate.Enabled = False
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期化
            optPrClass0.Enabled = False             '変更後P/R区分(P)
            optPrClass1.Enabled = False             '変更後P/R区分(R)

            '@終了ﾎﾞﾀﾝ
            cmdClose.CausesValidation = False
            
            '@退避変数の初期化
            mstrCarrier = vbNullString
            mstrLot = vbNullString
            
        '@↓2011/10/03 (Mon) 10:28:21 Y.Yoneyama **************************************************
            '@区間優先ﾌﾗｸﾞの初期化
            mblnSectionPriorityFlg = False
        '@↑2011/10/03 (Mon) 10:28:21 Y.Yoneyama **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM01A0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvEditEnable_Proc
    '機　能：各変更項目の一括制御
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 09:30:18 N.Kasai
    '更新日：2019/01/30 (Wed) 09:52:51 T.Oide
    '備　考：
    Private Sub prvEditEnable_Proc()

        Try

            '@ﾛｯﾄ状態判定
            Select Case lblStatus.Text
            
                Case CPstrWaitThrowSt, CPstrWaitWorkSt, CPstrBeforeProgressSt, CPstrProcessingSt, CPstrAfterProgressSt, CPstrEndWorkSt
                    '@投入待ち,作業待ち,前処理,処理中,後処理,作業終了
                    '@編集可能
                Case Else
                    Exit Sub
            End Select
            
            '@----------------
            '@　数量制御
            '@----------------
            '@投入後は使用不可
            '@流動区分:PR/ESの場合は使用不可
            '@組立-受入在庫の場合は使用不可(ｷｬﾘｱと紐付いていることを条件とする)
            '@CPstrWaitThrowSt:"投入待ち"
            '@分割子ﾛｯﾄ(ｵｰﾀﾞ№なし)の場合は数量0の為
            
            If lblStatus.Text <> CPstrWaitThrowSt Then
                txtWFNum.Enabled = False
            Else
                '@分割子ﾛｯﾄの場合は数量変更不可
                If txtWFNum.Text = "0" Then
                    txtWFNum.Enabled = False
                Else
                    '@起動区分判定
                    If pstrSBID = CPstrSBID1A0 Then

                        '@流動区分判定
                        Select Case lblFlowClass.Text
                            '@PR,ESの場合
                            Case CPstrFlowClassPR, CPstrFlowClassES
                                txtWFNum.Enabled = False
                            Case Else
                                txtWFNum.Enabled = True
                        End Select

                    Else
                        If mtypLotAttribute.strCarrierId <> vbNullString Then
                            txtWFNum.Enabled = False
                        Else
                            txtWFNum.Enabled = True
                        End If
                    End If
                End If
            End If
            
            '@----------------
            '@　ﾛｯﾄ担当制御
            '@----------------
            '@流動区分:PR/ESの場合は使用不可
                    
            '@★ 流動区分により処理分岐 ★
            Select Case lblFlowClass.Text
                
                '@〓 PR or ES 〓
                Case CPstrFlowClassPR, CPstrFlowClassES
                    
                    cmbLotManager.Enabled = False       'ﾛｯﾄ担当：無効
                    
                '@〓 その他(試作/実験ﾛｯﾄ、ﾀﾞﾐｰﾛｯﾄ等) 〓
                Case Else
                
                    cmbLotManager.Enabled = True        'ﾛｯﾄ担当：有効
            End Select
           
           
            '@----------------
            '@　投入予定日制御
            '@----------------
            '@投入後は使用不可
            '@流動区分:PR/ESの場合は使用不可⇒制限解除(2021/12/13米山)
            '以前はBacchusからの投入予定日を取得していた為、変更不可であったが
            'GNSに以降後は投入予定は無いので変更可能とする
            
            '@CPstrWaitThrowSt:"投入待ち"
            If lblStatus.Text <> CPstrWaitThrowSt Then
                calThrowinPlanDate.Enabled = False
            Else
                calThrowinPlanDate.Enabled = True
                
                ''@流動区分判定
                'Select Case lblFlowClass.Text
                '    '@PR,ESの場合
                '    Case CPstrFlowClassPR, CPstrFlowClassES
                '        calThrowinPlanDate.Enabled = False
                '    Case Else
                '        calThrowinPlanDate.Enabled = True
                'End Select
            End If

            
            '@----------------
            '@　優先度制御
            '@----------------
            '@投入前は使用不可
            
            '@CPstrWaitThrowSt:"投入待ち"
            If lblStatus.Text = CPstrWaitThrowSt Then
                cmbPrioSel.Enabled = False
            Else
                cmbPrioSel.Enabled = True
            End If
            
            
            '@----------------
            '@　P/Rｵｰﾀﾞ制御
            '@----------------
            '@流動区分:PR/ESの場合は使用不可
            '@流動区分:「品確」「ﾓﾆﾀ」「ﾀﾞﾐｰ」の場合使用不可
            '@TFT基板orODF対向基板の場合は使用可
            
            '@流動区分判定
            Select Case lblFlowClass.Text
            
                '@「PR」「ES」の場合使用不可
                Case CPstrFlowClassPR, CPstrFlowClassES
                    
                    optPrClass0.Enabled = False            '変更後P/R区分
                    optPrClass1.Enabled = False            '変更後P/R区分
                    cmbPrOrder.Enabled = False                              'P/Rｵｰﾀﾞｰ
            
                '@「品確」「ﾓﾆﾀ」「ﾀﾞﾐｰ」の場合使用不可
                Case CPstrFillerDummy, CPstrSideDummy, CPstrExtraDummy, CPstrFlowClassMO, CPstrFlowClassQU
                    
                    optPrClass0.Enabled = False                         '変更後P/R区分
                    optPrClass1.Enabled = False                         '変更後P/R区分
                    cmbPrOrder.Enabled = False                          'P/Rｵｰﾀﾞｰ
                
                Case Else
                    
                    '@TFT基板orODF対向基板の場合は使用可
                    If (mtypLotAttribute.strCfFlag = "0") Or (mtypLotAttribute.strLpFlag = "1") Then
                        optPrClass0.Enabled = True                          '変更後P/R区分
                        optPrClass1.Enabled = True                          '変更後P/R区分
                        cmbPrOrder.Enabled = True                           'P/Rｵｰﾀﾞｰ
                    Else
                        optPrClass0.Enabled = False                         '変更後P/R区分
                        optPrClass1.Enabled = False                         '変更後P/R区分
                        cmbPrOrder.Enabled = False                          'P/Rｵｰﾀﾞｰ
                    End If
            End Select

            
            '@----------------
            '@　送品変更制御
            '@----------------
            '@流動区分:PR/ESの場合は送品あり固定で使用不可
            '@種別が「品確」「ﾓﾆﾀ」「ﾀﾞﾐｰ」の場合送品なし固定で使用不可

            '@送品ｺﾝﾎﾞ一括制御
            Call prvCmbLotSend_Disp(lblFlowClass.Text)
            
            
            '@----------------
            '@　送品先変更
            '@----------------
            '@流動区分:PR/ESの場合は使用可能である。但し、組立投入前まで
            '@CFﾛｯﾄの場合も変更不可(どうせ親ﾛｯﾄに貼り合わせ)
            '@ｵｰﾀﾞ№の有無
            
             If (lblFlowClass.Text = CPstrFlowClassPR Or _
                lblFlowClass.Text = CPstrFlowClassES) And mtypLotAttribute.strCfFlag = "0" Then
                
                '@組立/ﾛｯﾄ状態が「投入待ち」の場合(受入在庫のこと)
                '@CPstrWaitThrowSt:"投入待ち"
                cmbSendSBID.Enabled = True

            Else
                cmbSendSBID.Enabled = False
            End If
            
            
            '@----------------
            '@　送品予定日制御
            '@----------------
            '@投入前は使用不可
            '@製品区分が製品以外の場合は使用不可
            '@QU,MO,DM等のロットは送品予定日が変更できないこと
            '@特殊流動中のロット(A,R、MなどのS以外のロット)は送品予定日は変更できないこと
            '@TPALロットに対しての送品予定日の変更はできないこと
            '@ODF(CF側)ロットが基板であれば送品予定日の変更はできること
            '@ODF(CF側)ロットが組立であれば送品予定日の変更はできないこと
            
            '◇完成 , 送品予定日の設定 / 変更対象
            '1A0 TFT基板(CF_FLA = 0, LP_FLAG = 0)
            '1A0 対向基板(CF_FLAG = 1, LP_FLAG = 1)
            '2A0 TFT基板(CF_FLAG = 0, LP_FLAG = 0)
            '
            '◇対象外
            '2A0 対向基板(TPAL)(CF_FLAG = 1, LP_FLAG = 0)
            '2A0 対向基板(ODF)(CF_FLAG = 1, LP_FLAG = 1)

            
            '@ﾎﾞﾀﾝ使用可(初期値)
            calPlanShipDate.Enabled = True
            
            '@CPstrWaitThrowSt:"投入待ち"
            If lblStatus.Text = CPstrWaitThrowSt Then
                calPlanShipDate.Enabled = False
            End If
            
            '@製品区分の判定
            If mtypLotAttribute.strUseId <> CPstrProduct Then
                calPlanShipDate.Enabled = False
            End If
            
            '@処理区分判定
            Select Case lblFlowClass.Text
                '@種別が「品確」「ﾓﾆﾀ」「ﾀﾞﾐｰ」の場合使用不可
                Case CPstrFillerDummy, CPstrSideDummy, CPstrExtraDummy, CPstrFlowClassMO, CPstrFlowClassQU
                    calPlanShipDate.Enabled = False
            End Select
            
            '@特殊ﾛｯﾄの判定
            Select Case Mid$(txtLot.Text, 8, 1)
                '通常ﾛｯﾄ
                Case "S"
                    '@制限なし
                Case Else
                    '@特殊流動中のロット(A,R、MなどのS以外のロット)
                    calPlanShipDate.Enabled = False
            End Select
            
            '@CFﾌﾗｸﾞ判定
            Select Case mtypLotAttribute.strCfFlag
                '@CFﾛｯﾄ
                Case CPstrCF
                    '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                    
                    If mtypLotAttribute.strLpFlag = CPstrLP Then
                        '@大版の場合
                        '@組立の場合
                        If pstrSBID = CPstrSBID2A0 Then
                            calPlanShipDate.Enabled = False
                        End If
                    Else
                        '@小版の場合
                        calPlanShipDate.Enabled = False
                    End If
                
                '@TPALﾛｯﾄ
                Case CPstrTPAL
                    calPlanShipDate.Enabled = False
                    
            End Select
            
            '@----------------
            '@　作業ﾒﾓ
            '@----------------
            txtWorkMemo.Enabled = True


            '@----------------
            '@　1stﾌｫﾄ号機制御
            '@----------------
            '基板工程のみ有効。
            '編成可能な流動区分のみ有効。
            '　→　本当は，M_FLOW_CLASS.LOT_ORGANIZE_FLAG=1(編成可能)か否かを見たいが，この画面では，
            '　　　情報採取していないため，情報採取している，LOT.FLOW_CLASS を逐次判断する。
            '
            'なお，ﾚﾁｸﾙ使用装置ﾘｽﾄがｾﾞﾛの場合は，有効としない。
            '
            CmbFirstPhotoWpName.Enabled = False

            '装置ﾘｽﾄがｾﾞﾛが判断
            If mblnWpListZeroFlag = False Then
                '@工程判定
                If pstrSBID = CPstrSBID1A0 Then
                    '流動区分判定
                    Select Case lblFlowClass.Text
                
                            Case CPstrFlowClassTS
                                 CmbFirstPhotoWpName.Enabled = True
                            Case CPstrFlowClassWS
                                 CmbFirstPhotoWpName.Enabled = True
                            Case CPstrFlowClassZZ
                                 CmbFirstPhotoWpName.Enabled = True
                            Case CPstrFlowClassGG
                                 CmbFirstPhotoWpName.Enabled = True
                            Case CPstrFlowClassSY
                                 CmbFirstPhotoWpName.Enabled = True
                    End Select
                End If
            End If


            '@----------------
            '@　組立送品予定日
            '@----------------
            '@投入前は使用不可
            '@製品区分が製品以外の場合は使用不可
            '@QU,MO,DM等のロットは送品予定日が変更できないこと
            '@特殊流動中のロット(A,R、MなどのS以外のロット)は送品予定日は変更できないこと
            '@組立は対象外
            
            '◇完成 , 送品予定日の設定 / 変更対象
            '1A0 TFT基板(CF_FLA = 0, LP_FLAG = 0)
            '1A0 対向基板(CF_FLAG = 1, LP_FLAG = 1)
            '
            '◇対象外
            '2A0、3A0

            '@有効/無効(初期値)
            calPlanAssThrowinDate.Enabled = True
            
            '@CPstrWaitThrowSt:"投入待ち"
            If lblStatus.Text = CPstrWaitThrowSt Then
                calPlanAssThrowinDate.Enabled = False
            End If
            
            '@製品区分の判定
            If mtypLotAttribute.strUseId <> CPstrProduct Then
                calPlanAssThrowinDate.Enabled = False
            End If
            
            '@処理区分判定
            Select Case lblFlowClass.Text
                '@種別が「品確」「ﾓﾆﾀ」「ﾀﾞﾐｰ」の場合使用不可
                Case CPstrFillerDummy, CPstrSideDummy, CPstrExtraDummy, CPstrFlowClassMO, CPstrFlowClassQU
                    calPlanAssThrowinDate.Enabled = False
            End Select
            
            '@特殊ﾛｯﾄの判定
            Select Case Mid$(txtLot.Text, 8, 1)
                '通常ﾛｯﾄ
                Case "S"
                    '@制限なし
                Case Else
                    '@特殊流動中のロット(A,R、MなどのS以外のロット)
                    calPlanAssThrowinDate.Enabled = False
            End Select
            
        '@↓2019/01/30 (Wed) 09:49:22 T.Oide **************************************************
        '@    '@組立では非表示
        '@    If pstrSBID = CPstrSBID2A0 Then
        '@        calPlanAssThrowinDate.Enabled = False
        '@    End If
        '@------------------------------------------------------------------------------------
            '@組立、ALDでは無効
            If pstrSBID = CPstrSBID2A0 Or pstrSBID = CPstrSBID3A0 Then
                calPlanAssThrowinDate.Enabled = False
            End If
        '@↑2019/01/30 (Wed) 09:49:22 T.Oide **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvEditEnable_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvControl_Init
    '機　能：共通ｺﾝﾎﾞ/ｶﾚﾝﾀﾞ初期化
    '引　数：objcmbName：ｺﾝﾄﾛｰﾙ名
    '戻り値：なし
    '作成日：2007/10/01 (Mon) 17:08:23 N.Kasai
    '更新日：2007/10/12 (Fri) 17:19:44 N.Kasai
    '備　考：
    Private Sub prvControl_Init()

        Dim lctlControl     As Control      'ｺﾝﾄﾛｰﾙ名称
        Dim lctlCalender    As Control      'ｺﾝﾄﾛｰﾙ名称
        
        Try
            
            '@ｺﾝﾎﾞﾎﾞｯｸｽの初期化
            Dim all As Control() = GetAllControls(Me)
            For Each lctlControl In all
                '@ﾌｫｰﾑ上のｺﾝﾄﾛｰﾙに対して処理を行う
                If TypeOf lctlControl Is SEComboBoxEx.ComboBoxEx Then
                    '@ｺﾝﾄﾛｰﾙがComboBoxExの場合
                    With CType(lctlcontrol, SEComboBoxEx.ComboBoxEx)
                        '@ｺﾝﾎﾞﾎﾞｯｸｽ初期化
                        .Clear                                      'ｸﾘｱ
                        .DispCols = CMlngCmbDispCols                'ｸﾞﾘｯﾄﾞ表示列数
                        .GetCol = 0                                 'ﾃｷｽﾄ表示列
                        .ValueCol = 1                               '値取得列
                        .DirectInput = False                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                        .Text = vbNullString                        '初期化
                        With .Font                                  'ﾌｫﾝﾄｻｲｽﾞ
                             CType(lctlcontrol, SEComboBoxEx.ComboBoxEx).Font = New Font(.FontFamily, CMlngCmbFontSize, .Style)
                        End With
                        With .GridFont                              'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                             CType(lctlcontrol, SEComboBoxEx.ComboBoxEx).GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style)
                        End With
                        .RowHeight = CMlngComboRowHeight            'ｸﾞﾘｯﾄﾞの高さ
                        .ColAlignment(0) = CMlngCmbAlignLeftCenter  'ｸﾞﾘｯﾄﾞ表示位置(左中央)
                        .ListIndex = -1                             '内容初期化
                        .BackColor = SystemColors.Window            'ﾘｽﾄ背景色
                        .Enabled = False                            '使用不可
                    End With
                End If
            Next
            
            '@ｶﾚﾝﾀﾞｰ設定の初期化
            For Each lctlCalender In all
                '@ﾌｫｰﾑ上のｺﾝﾄﾛｰﾙに対して処理を行う
                If TypeOf lctlCalender Is SECalendarEx.CalendarEx Then
                    '@ｶﾚﾝﾀﾞｰ設定
                    With CType(lctlCalender, SECalendarEx.CalendarEx)
                        .CalendarHeight = CPlngClHeight             '高さ
                        .CalendarWidth = CPlngClWidth               '幅
                        With .DayFont                               'ﾌｫﾝﾄｻｲｽﾞ
                            CType(lctlCalender, SECalendarEx.CalendarEx).DayFont = _
                                New Font(.FontFamily, CPlngClFontSize, .Style)
                        End With
                        With .TitleFont                              'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                            CType(lctlCalender, SECalendarEx.CalendarEx).TitleFont = _
                                New Font(.FontFamily, CPlngClTlFontSize, .Style)
                        End With
                        With .GridFont                              'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                            CType(lctlCalender, SECalendarEx.CalendarEx).GridFont = _
                                New Font(.FontFamily, CPlngClGridFontSize, .Style)
                        End With
                    End With
                End If
            Next
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvControl_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM01A0_Disp
    '機　能：ﾛｯﾄ情報の表示
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 11:12:07 N.Kasai
    '更新日：2016/02/08 (Mon) 23:10:59 H.Hayashi
    '備　考：
    '　　　：2008/06/10 (Tue) 15:10:15 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/04 (Fri) 13:44:00 M.Koni       1stﾌｫﾄ号機設定変更対応 <案件No.02959>
    '　　　：2010/05/06 (Thu) 15:30:14 T.Oide       組立投入予定日追加対応<案件No.04021>
    '　　　：2011/10/05 (Wed) 10:45:28 T.Oide       R8-04 区間優先設定対応<REQ-1109>
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub prvfrmxxCM01A0_Disp()
        
        Dim llngCnt     As Integer      'ｶｳﾝﾀ
        Dim lblnFlg     As Boolean      '判定ﾌﾗｸﾞ
        
        Try
            
            '@ﾛｯﾄ情報の表示
            With mtypLotAttribute
                
                '@有効ｺﾝﾄﾛｰﾙ名の判定
                Select Case mstrActiveControlName
                    '@ｷｬﾘｱID
                    Case CMstrActiveControlNameCarrierID
                        txtLot.Text = .strLotID                 'ﾛｯﾄID
                    
                    '@ﾛｯﾄID
                    Case CMstrActiveControlNameLotID
                        txtCarrier.Text = .strCarrierId         'ｷｬﾘｱID
                    
                    '@どちらか判断不正
                    Case Else
                        txtCarrier.Text = .strCarrierId         'ｷｬﾘｱID
                        txtLot.Text = .strLotID                 'ﾛｯﾄID
                End Select
                
                lblFlowClass.Text = .strFlowClass            '流動区分
                lblPdID.Text = .strPdId                      '機種名
        '@↓2016/01/25 (Mon) 00:29:17 H.Hayashi **************************************************
                lblGrbClass.Text = .strGrbClass              'GRB区分
        '@↑2016/01/25 (Mon) 00:29:17 H.Hayashi **************************************************
                lblStatus.Text = .strNowST                   '状態
                lblOpID.Text = .strOpID                      '大工程名
                lblStepID.Text = .strStepID                  '小工程名
                lblS.Text = .strSpecialFlag                  '特殊特性
                lblEntryID.Text = .strEntryID                'ｴﾝﾄﾘID
                lblEntryName.Text = .strEntryName            'ｴﾝﾄﾘ名
                 
                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then

                    '@時間制約がﾌﾟﾗｽの場合
                    If CLng(.strLimitTime) >= 0 Then
                        
                        '@制限時間以下or処理時間制限以下の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@制限時間先大工程+制限時間先小工程+制限時間
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            If IsNumeric(.strLimitTime) Then
                                lblTimeLimit.Text = Format(CInt(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            Else
                                lblTimeLimit.Text = .strLimitTime & CPstrh
                            End If
                            '@右寄せ
                            lblTimeLimit.TextAlign = ContentAlignment.TopRight
                            
                            '@警告時間が設定されている場合
                            If .strWarnTime <> vbNullString Then
                                '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                If CLng(.strWarnTime) < 0 And CLng(.strLimitTime) >= 0 Then
                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)    '紫色
                                Else
                                     '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                    lblTimeLimit.ForeColor = Color.Black    '黒
                                End If
                            End If
                        End If
                        
                    Else
                        '@制限時間がﾏｲﾅｽの場合
                        
                        '@制限時間先大工程+制限時間先小工程+制限時間
                        '@右寄せ
                        lblTimeLimit.TextAlign = ContentAlignment.TopRight
                        '@ForColorの変更
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)    '赤色
                        
                        '@制限時間以下or処理時間制限以下の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            If IsNumeric(.strLimitTime) Then
                                lblTimeLimit.Text = Format(CInt(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            Else
                                lblTimeLimit.Text = .strLimitTime & CPstrh
                            End If
                        End If
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            If IsNumeric(.strLimitTime) Then
                                lblTimeLimit.Text = Replace(Format(CInt(.strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString) & CPstrh
                            Else
                                lblTimeLimit.Text = Replace(.strLimitTime, CPstrReplaceMinus, vbNullString) & CPstrh
                            End If
                        End If
                    End If
                End If
                
                '@ﾛｯﾄ状態
                Select Case .strNowST
                
                    '@「作業待ち」「前処理」の場合
                    Case CPstrWaitWorkSt, CPstrBeforeProgressSt
                        
                        '@日付ﾀｲﾄﾙ設定「処理開始予定」
                        lblStartTimeTitle.Text = CPstrDispatchTime
                        If IsDate(.strDispatchStartTime) Then
                            lblStartTime.Text = Format$(CDate(.strDispatchStartTime), CPstrDateFormat)  '投入予定日"mm/dd hh:mm:ss"
                        Else
                            lblStartTime.Text = .strDispatchStartTime
                        End If
                    '@その他
                    Case Else
                        
                        '@日付ﾀｲﾄﾙ設定「処理開始日時」
                        lblStartTimeTitle.Text = CPstrStartTime
                        If IsDate(.strStartTime) Then
                            lblStartTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat)          '開始日時"mm/dd hh:mm:ss"
                        Else
                            lblStartTime.Text = .strStartTime
                        End If
                End Select

                
                '@------------
                '@　数量
                '@------------

                '@枚数表示判定(CF_FLAGを判定し、WF枚数とﾁｯﾌﾟ枚数の表示を切替)
                Select Case .strCfFlag
                
                    '@CFﾛｯﾄ
                    Case CPstrCF
                        
                        '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                        If .strLpFlag = CPstrLP Then
                            '@大判の場合
                            lblBeforeWFNum.Text = .strWfNum          'WF枚数
                            txtWFNum.NumMax = CMlngMaxWF
                            txtWFNum.Text = .strWfNum                'WF枚数
                            fraWFNum.Text = "数量変更(WF)"
                        Else
                            lblBeforeWFNum.Text = .strChipQuantity   'ﾁｯﾌﾟ枚数
                            txtWFNum.NumMax = CMlngMaxCHIP
                            txtWFNum.Text = .strChipQuantity         'ﾁｯﾌﾟ枚数
                            fraWFNum.Text = "数量変更(CHIP)"
                        End If
                    
                    '@TPALﾛｯﾄ
                    Case CPstrTPAL
                    
                        lblBeforeWFNum.Text = .strChipQuantity      'ﾁｯﾌﾟ枚数
                        txtWFNum.NumMax = CMlngMaxCHIP
                        txtWFNum.Text = .strChipQuantity            'ﾁｯﾌﾟ枚数
                        fraWFNum.Text = "数量変更(CHIP)"
                        
                    '@CFﾛｯﾄ以外
                    Case Else
                        
                        '@CF,TPALﾛｯﾄ以外
                        lblBeforeWFNum.Text = .strWfNum             'WF枚数
                        txtWFNum.NumMax = CMlngMaxWF
                        txtWFNum.Text = .strWfNum                   'WF枚数
                        fraWFNum.Text = "数量変更(WF)"
                End Select
                
                '@------------
                '@　ﾛｯﾄ担当者
                '@------------
                lblBeforeLotManager.Text = .strEngEmpName        '変更前ﾛｯﾄ担当者名
                cmbLotManager.Text = lblBeforeLotManager.Text    '変更後ﾛｯﾄ担当者
                
                
                '@------------
                '@　投入予定日
                '@------------
                If IsDate(.strPlanThrowinDate) Then
                    lblBeforePlanThrowDate.Text = Format$(CDate(.strPlanThrowinDate), CPstrDateTimeYMD)
                Else
                    lblBeforePlanThrowDate.Text = .strPlanThrowinDate
                End If
                If IsDate(.strPlanThrowinDate) Then
                    calThrowinPlanDate.Value = Format$(CDate(.strPlanThrowinDate), CPstrDateTimeYMD)
                Else
                    calThrowinPlanDate.Value = .strPlanThrowinDate
                End If
                
                '@------------
                '@　優先度
                '@------------
                '@優先度ｺﾝﾎﾞのみ値を結合してｺﾝﾎﾞ表示しているどうもmetaだとtextに値を入れても
                '@認識してくれないようだ(ミウ様の端末のみ事象発生)
                '@ｺﾝﾎﾞのvalueからlistindexで判定する。
                
                lblBeforePrio.Text = .strLotPriority & CPstrSpace & .strLotPriorityName
                
        '@↓2011/10/05 (Wed) 10:45:10 T.Oide **************************************************
                If .strSecPriorityFlag = 1 Then
                    fraPrio.Text = CMstrfraPrioDispString & CMstrfraSecPriorityString           '優先度変更　区間優先設定あり
                    fraPrio.ForeColor = Color.Red                                               '赤色表示
                    mblnSectionPriorityFlg = True
                Else
                    fraPrio.Text = CMstrfraPrioDispString                                       '優先度変更
                    fraPrio.ForeColor = Color.Black                                             '黒色表示
                    mblnSectionPriorityFlg = False
                End If
        '@↑2011/10/05 (Wed) 10:45:10 T.Oide **************************************************
                
                lblnFlg = False
                For llngCnt = 0 To mtypPriorityReasonList.Count -1
                    '@ｺﾝﾎﾞ検索
                    If mtypPriorityReasonList(llngCnt).strMasPriorityId = .strLotPriority Then
                        '@一致
                        lblnFlg = True
                        Exit For
                    End If
                Next
                '@ﾘｽﾄｲﾝﾃﾞｯｸｽ指定
                If lblnFlg = True Then
                    cmbPrioSel.ListIndex = llngCnt
                Else
                    cmbPrioSel.Text = .strLotPriority & CPstrSpace & .strLotPriorityName
                End If
                
                
                '@------------
                '@　P/Rｵｰﾀﾞ
                '@------------
                lblBeforePrOrder.Text = .strPROrderID            '変更前P/RｵｰﾀﾞｰID
                '@変更後にﾃﾞﾌｫﾙﾄ値として、変更前のﾃﾞｰﾀを格納
                Select Case Strings.Left$(.strPROrderID, 1)
                    '@Pｵｰﾀﾞｰ,ｵｰﾀﾞｰなし
                    Case CPstrPrOrderClassP, vbNullString
                        optPrClass0.Checked = True
                    '@Rｵｰﾀﾞｰ
                    Case CPstrPrOrderClassR
                        optPrClass1.Checked = True
                End Select
                cmbPrOrder.Text = lblBeforePrOrder.Text          '変更後P/Rｵｰﾀﾞｰ
                
                '@------------
                '@　送品
                '@------------
                Select Case .strLotSendFlag
                    Case CPlngLotSendNasi
                        lblBeforeLotSend.Text = CPstrNasiFlg
                        cmbLotSend.ListIndex = CPlngLotSendNasi
                    Case CPlngLotSendAri
                        lblBeforeLotSend.Text = CPstrAriFlg
                        cmbLotSend.ListIndex = CPlngLotSendAri
                    Case Else
                        lblBeforeLotSend.Text = vbNullString
                        cmbLotSend.ListIndex = -1
                End Select
                

                '@------------
                '@　送品先
                '@------------
                lblBeforeSendSBID.Text = .strSendSBName          '変更前送品先
                cmbSendSBID.Text = lblBeforeSendSBID.Text        '変更後送品先(ﾃﾞﾌｫﾙﾄ)

                
                '@------------
                '@　送品予定日
                '@------------
                If IsDate(.strPlanShipDate) Then
                    lblBeforePlanShipDate.Text = Format$(CDate(.strPlanShipDate), CPstrDateTimeYMD)
                Else
                    lblBeforePlanShipDate.Text = .strPlanShipDate
                End If
                If IsDate(.strPlanShipDate) Then
                    calPlanShipDate.Value = Format$(CDate(.strPlanShipDate), CPstrDateTimeYMD)
                Else
                    calPlanShipDate.Value = .strPlanShipDate
                End If
                
                '@------------
                '@　1ﾌｫﾄ装置
                '@------------
                lblBeforeFirstPhotoWpName.Text = .strFirstPhotoWpName        '変更前1stﾌｫﾄ号機
                CmbFirstPhotoWpName.Text = lblBeforeFirstPhotoWpName.Text    '変更後1stﾌｫﾄ号機ﾃﾞﾌｫﾙﾄ表示

                
        '@↓2010/05/06 (Thu) 15:39:03 T.Oide **************************************************
                '@------------
                '@　組立投入予定日
                '@------------
                If IsDate(.strPlanAssThrowinDate) Then
                    lblBeforePlanAssThrowinDate.Text = Format$(CDate(.strPlanAssThrowinDate), CPstrDateTimeYMD)     '組立投入予定日
                Else
                    lblBeforePlanAssThrowinDate.Text = .strPlanAssThrowinDate
                End If
                If IsDate(.strPlanAssThrowinDate) Then
                    calPlanAssThrowinDate.Value = Format$(CDate(.strPlanAssThrowinDate), CPstrDateTimeYMD)          '組立投入予定日ﾃﾞﾌｫﾙﾄ表示
                Else
                    calPlanAssThrowinDate.Value = .strPlanAssThrowinDate
                End If
        '@↑2010/05/06 (Thu) 15:39:03 T.Oide **************************************************
                
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM01A0_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvPrioInfo_Disp
    '機　能：優先度ﾏｽﾀﾘｽﾄをｺﾝﾎﾞへｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 15:08:34 T.Sawaguchi
    '更新日：2004/05/25 (Tue) 13:25:01 S.Deguchi
    '備　考：配列のﾁｪｯｸは上流工程でﾁｪｯｸ済み
    Private Sub prvPrioInfo_Disp()
        
        Dim llngCnt     As Integer  'ｶｳﾝﾄ

        Try
            
            '@優先度ｾｯﾄ
            With cmbPrioSel
                
                .Clear
                
                For llngCnt = 0 To mtypPriorityReasonList.Count -1
                    '@優先度ID＋""＋優先度名
                    .AddItem(mtypPriorityReasonList(llngCnt).strMasPriorityId & CPstrSpace & _
                             mtypPriorityReasonList(llngCnt).strMasPriorityName & vbTab & _
                             mtypPriorityReasonList(llngCnt).strMasPriorityId)
                Next llngCnt
                
                '@優先度が１件の場合
                If .ListCount = 1 Then
                    '@１件目表示
                    .ListIndex = 0
                End If
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvPrioInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbLotManager_Disp
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/02 (Wed) 11:32:32 M.Matsuura
    '更新日：2008/06/10 (Tue) 16:18:21 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 16:18:21 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvCmbLotManager_Disp()
        
        Dim llngCnt     As Integer  'ｶｳﾝﾄ

        Try

            With cmbLotManager
            
                .Clear      'ｸﾘｱ
                
                For llngCnt = 0 To mtypEngEmpList.Count -1
                
                    '@ｺﾝﾎﾞ内容設定：ﾛｯﾄ担当者名＋ﾛｯﾄ担当者ID
                    .AddItem(mtypEngEmpList(llngCnt).strTechManName & vbTab & _
                             mtypEngEmpList(llngCnt).strTechManID)
                Next
                
                '@ﾛｯﾄ担当が1件か
                If .ListCount = 1 Then
                
                    '@ﾃﾞﾌｫﾙﾄで表示する
                    .ListIndex = 0
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbLotManager_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvSendSBID_Disp
    '機　能：送品先ﾘｽﾄをｺﾝﾎﾞへｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/09/08 (Fri) 17:03:22 N.Kojima
    '更新日：2006/09/08 (Fri) 17:03:22
    '備　考：
    Private Sub prvSendSBID_Disp()
        
        Dim llngCnt     As Integer  'ｶｳﾝﾄ

        Try
            
            '@優先度ｾｯﾄ
            With mtypSBRouteListAns
                
                cmbSendSBID.Clear
                
                For llngCnt = 0 To .lngSendSBListCnt -1
                    '@送品先名(和名)/送品先ID/ｲﾝﾃﾞｯｸｽ
                    cmbSendSBID.AddItem(.typSendSBList(llngCnt).strSendSBName & vbTab & _
                                        .typSendSBList(llngCnt).strSendSBID & vbTab & _
                                        llngCnt)
                Next llngCnt
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSendSBID_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnChangeData_Chk
    '機　能：変更ﾃﾞｰﾀﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True:変更あり、False:変更なし
    '作成日：2007/10/12 (Fri) 10:33:12 N.Kasai
    '更新日：2011/10/03 (Mon) 11:41:50 Y.Yoneyama
    '備　考：
    '　　　：2008/06/10 (Tue) 15:11:41 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/09 (Wed) 15:46:45 M.Koni       1stﾌｫﾄ号機変更対応<案件No.02959>
    '　　　：2010/05/06 (Thu) 15:30:14 T.Oide       組立投入予定日追加対応<案件No.04021>
    Private Function prvblnChangeData_Chk() As Boolean
        
        Dim lstrNowDT   As String   '現在日付
        Dim lblnCngFlag As Boolean  '変更ﾌﾗｸﾞ
        
        Try
            
            '@戻り値初期化
            prvblnChangeData_Chk = False
            
            '@各ﾌﾗｸﾞの初期化
            lblnCngFlag = False
            
            mblnChgWfNumFlag = False
            mblnChgLotManagerFlag = False
            mblnChgPlanDateFlag = False
            mblnChgPrioFlag = False
            mblnChgPrOrderFlag = False
            mblnChgLotSendFlag = False
            mblnChgSendSBIDFlag = False
            mblnChgPlanShipDateFlag = False
            mblnChgFirstPhotoFlag = False
        '@↓2010/05/06 (Thu) 17:57:56 T.Oide **************************************************
            mblnChgPlanAssTrowinDateFlag = False
        '@↑2010/05/06 (Thu) 17:57:56 T.Oide **************************************************

            '@数量変更ﾁｪｯｸ(CFﾛｯﾄの場合)
            If mtypLotAttribute.strCfFlag = "1" And mtypLotAttribute.strLpFlag = "0" Then
                '@変更なし
                '@CFﾛｯﾄの場合はCHIP数量を表示しています。変更は不可です。
            Else
                '@数量変更
                If lblBeforeWFNum.Text <> txtWFNum.Text Then
                    mblnChgWfNumFlag = True
                    lblnCngFlag = True
                End If
            End If
            
            '@ﾛｯﾄ担当者変更
            If lblBeforeLotManager.Text <> cmbLotManager.Text And _
                cmbLotManager.Text <> vbNullString Then
                mblnChgLotManagerFlag = True
                lblnCngFlag = True
            End If
            
            '@投入予定日変更
            
            '@日付のﾁｪｯｸ
            If calThrowinPlanDate.Value <> CPstrNullDate Then
                If IsDate(lblBeforePlanThrowDate.Text) Then
                    If Format$(CDate(lblBeforePlanThrowDate.Text), CPstrDateTimeYMD) <> Format$(CDate(calThrowinPlanDate.Value), CPstrDateTimeYMD) Then
                        mblnChgPlanDateFlag = True
                        lblnCngFlag = True
                    End If
                Else
                    mblnChgPlanDateFlag = True
                    lblnCngFlag = True
                End If
            End If
            
            '@優先度変更
            If lblBeforePrio.Text <> cmbPrioSel.Text Then
                mblnChgPrioFlag = True
                lblnCngFlag = True
            End If
            
            '@P/Rｵｰﾀﾞｰ変更
            If lblBeforePrOrder.Text <> cmbPrOrder.Text Then
                mblnChgPrOrderFlag = True
                lblnCngFlag = True
            End If
            
            '@送品変更
            If lblBeforeLotSend.Text <> cmbLotSend.Text Then
                mblnChgLotSendFlag = True
                lblnCngFlag = True
            End If
            
            '@送品先変更
            If lblBeforeSendSBID.Text <> cmbSendSBID.Text Then
                mblnChgSendSBIDFlag = True
                lblnCngFlag = True
            End If
            
            
            '@送品予定日変更
            
            '@日付のﾁｪｯｸ
            If calPlanShipDate.Value <> CPstrNullDate Then
                If IsDate(lblBeforePlanShipDate.Text) Then
                    If Format$(CDate(lblBeforePlanShipDate.Text), CPstrDateTimeYMD) <> Format$(CDate(calPlanShipDate.Value), CPstrDateTimeYMD) Then
                        mblnChgPlanShipDateFlag = True
                        lblnCngFlag = True
                    End If
                Else
                    mblnChgPlanShipDateFlag = True
                        lblnCngFlag = True
                End If
            End If
            

            If txtWorkMemo.Text <> vbNullString Then lblnCngFlag = True

            '@1stﾌｫﾄ号機変更
            If lblBeforeFirstPhotoWpName.Text <> CmbFirstPhotoWpName.Text Then
                mblnChgFirstPhotoFlag = True
                lblnCngFlag = True
            End If
            
            '@組立投入予定日変更
            If calPlanAssThrowinDate.Value <> CPstrNullDate Then
                If IsDate(lblBeforePlanAssThrowinDate.Text) Then
                    If Format$(CDate(lblBeforePlanAssThrowinDate.Text), CPstrDateTimeYMD) <> Format$(CDate(calPlanAssThrowinDate.Value), CPstrDateTimeYMD) Then
                        mblnChgPlanAssTrowinDateFlag = True
                        lblnCngFlag = True
                    End If
                Else
                    mblnChgPlanAssTrowinDateFlag = True
                    lblnCngFlag = True
                End If
            End If
            
            '@変更内容のﾁｪｯｸ
            If lblnCngFlag = False Then
                '@"<TRM6OW>$$変更後の値が変更前の値と同じです。設定を見直してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006O)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Function
            End If
            
            '@ｵｰﾀﾞ№なし、ﾛｯﾄ状態が投入前の場合
            If mtypLotAttribute.strOrderNum = vbNullString Then
                '@CPstrWaitThrowSt:"投入待ち"
                If lblStatus.Text = CPstrWaitThrowSt Then
                    If IsDate(calThrowinPlanDate.Value) Then
                        If IsDate(lblBeforePlanThrowDate.Text)
                            If Format$(CDate(lblBeforePlanThrowDate.Text), CPstrDateTimeYMD) <> Format$(CDate(calThrowinPlanDate.Value), CPstrDateTimeYMD) Then
                                '@現在日付取得
                                lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                        
                                '@現在日付より過去の場合
                                If Format$(CDate(calThrowinPlanDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                                    '@"過去日付は指定できません。"
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    '@投入予定日にﾌｫｰｶｽをｾｯﾄ
                                    If calThrowinPlanDate.Enabled = True Then
                                        Call pubSetFocus(calThrowinPlanDate)
                                    End If
                                    Exit Function
                                End If
                            End If
                        Else
                            '@現在日付取得
                            lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                        
                            '@現在日付より過去の場合
                            If Format$(CDate(calThrowinPlanDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                                '@"過去日付は指定できません。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                '@投入予定日にﾌｫｰｶｽをｾｯﾄ
                                If calThrowinPlanDate.Enabled = True Then
                                    Call pubSetFocus(calThrowinPlanDate)
                                End If
                                Exit Function
                            End If
                        End If
                    End If
                End If
            End If
            
            '@ｴﾗｰなし
            prvblnChangeData_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "prvblnChangeData_Chk"           'Function名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvButtonEnabled_Proc
    '機　能：ｺﾏﾝﾄﾞﾎﾞﾀﾝの一括制御
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/11 (Thu) 13:15:59 N.Kasai
    '更新日：2011/10/04 (Tue) 11:39:04 Y.Yoneyama
    '備　考：
    '　　　：2008/05/02 (Fri) 11:06:17 M.Koni       <案件No.2836> 作業ﾒﾓの入力判定追加
    '　　　：2008/06/10 (Tue) 15:12:19 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/07 (Mon) 09:39:31 M.Koni       1stﾌｫﾄ号機変更対応<案件No.02959>
    '　　　：2010/05/06 (Thu) 15:30:14 T.Oide       組立投入予定日追加対応<案件No.04021>
    Private Sub prvButtonEnabled_Proc()
        
        Dim lblnChangeFlag      As Boolean      '変更ﾌﾗｸﾞ(True:変更あり、False:変更なし)
        Dim lblnNgFlag          As Boolean      'ｴﾗｰ判定(True:ｴﾗｰあり、False:ｴﾗｰなし)
        Dim lstrNowDT           As String       '日付用変数
        
        Try
            
            '@------------------
            '@　確定ﾎﾞﾀﾝの制御
            '@------------------
            '@変更前と変更後の値を比較する。
            '@変更がある場合は使用可能
            
            '@判定変数初期化
            lblnChangeFlag = False
            
            '@ｴﾗｰﾌﾗｸﾞ(ｴﾗｰなし)
            lblnNgFlag = False
            
            '@数量
            If lblBeforeWFNum.Text <> txtWFNum.Text Then
                
                '@空白or0の場合はNG
                If txtWFNum.Text = vbNullString Or txtWFNum.Text = "0" Then
                    lblnNgFlag = True
                Else
                    lblnChangeFlag = True
                End If
            End If
            
            '@ﾛｯﾄ担当者
            If lblBeforeLotManager.Text <> cmbLotManager.Text Then
                lblnChangeFlag = True
            End If
            
            '@投入予定日
            If calThrowinPlanDate.Value <> CPstrNullDate Then
                If lblBeforePlanThrowDate.Text <> calThrowinPlanDate.Value Then
                    lblnChangeFlag = True
            
                    '@過去日付の場合はNG
                    '@ｵｰﾀﾞ№なし、ﾛｯﾄ状態が投入前の場合
                    If mtypLotAttribute.strOrderNum = vbNullString Then
                        '@CPstrWaitThrowSt:"投入待ち"
                        If lblStatus.Text = CPstrWaitThrowSt Then
                            '@現在日付取得
                            lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                            
                            '@現在日付より過去の場合
                            If IsDate(calThrowinPlanDate.Value) Then
                                If Format$(CDate(calThrowinPlanDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                                    lblnNgFlag = True
                                End If
                            Else
                                lblnNgFlag = True
                            End If
                        End If
                    End If
                End If
            Else
                '@NULLに変更された場合
                If lblBeforePlanThrowDate.Text <> vbNullString Then
                    lblnNgFlag = True
                End If
            End If
            
            
            '@優先度
            If lblBeforePrio.Text <> cmbPrioSel.Text Then
                lblnChangeFlag = True
            End If
            
            '@P/Rｵｰﾀﾞ
            If lblBeforePrOrder.Text <> cmbPrOrder.Text Then
                '@未選択の場合はNG
                If cmbPrOrder.ListIndex = -1 Then
                    lblnNgFlag = True
                Else
                    lblnChangeFlag = True
                End If
                
            End If
            
            '@送品
            If lblBeforeLotSend.Text <> cmbLotSend.Text Then
                lblnChangeFlag = True
            End If
            
            '@送品先
            If lblBeforeSendSBID.Text <> cmbSendSBID.Text Then
                lblnChangeFlag = True
            End If
            
            '@送品予定日
            If calPlanShipDate.Value <> CPstrNullDate Then
                If lblBeforePlanShipDate.Text <> calPlanShipDate.Value Then
                    lblnChangeFlag = True
                    
                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                    
                    '@現在日付より過去の場合
                    If IsDate(calPlanShipDate.Value) Then
                        If Format$(CDate(calPlanShipDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                            '@過去日付の場合はNG
                            lblnNgFlag = True
                        End If
                    Else
                        lblnNgFlag = True
                    End If
                End If
            Else
                '@NULLに変更された場合
                If lblBeforePlanShipDate.Text <> vbNullString Then
                    lblnNgFlag = True
                End If
            End If

            If txtWorkMemo.Text <> vbNullString Then lblnChangeFlag = True

            '@1stﾌｫﾄ号機
            If lblBeforeFirstPhotoWpName.Text <> CmbFirstPhotoWpName.Text Then
                lblnChangeFlag = True
            End If

        '@↓2010/05/07 (Fri) 11:13:47 T.Oide **************************************************
            '@組立投入予定日
            If calPlanAssThrowinDate.Value <> CPstrNullDate Then
                If lblBeforePlanAssThrowinDate.Text <> calPlanAssThrowinDate.Value Then
                    lblnChangeFlag = True
                    
                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                    
                    '@現在日付より過去の場合
                    If IsDate(calPlanAssThrowinDate.Value) Then
                        If Format$(CDate(calPlanAssThrowinDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                            '@過去日付の場合はNG
                            lblnNgFlag = True
                        End If
                    Else
                        lblnNgFlag = True
                    End If
                End If
            Else
                '@NULLに変更された場合
                If lblBeforePlanAssThrowinDate.Text <> vbNullString Then
                    lblnNgFlag = True
                End If
            End If
        '@↑2010/05/07 (Fri) 11:13:47 T.Oide **************************************************


            '@確定ﾎﾞﾀﾝ
            '@変更あり、ｴﾗｰなしの場合
            If lblnChangeFlag = True And lblnNgFlag = False Then
                cmdLotchgattr.Enabled = True
            Else
                cmdLotchgattr.Enabled = False
            End If
            
            '@------------------
            '@削除ﾎﾞﾀﾝの制御
            '@------------------
            '@投入前であること
            '@ｵｰﾀﾞ№なし(但し、分割子ﾛｯﾄの場合は削除可能)
            '@組立受け入れ在庫の場合は削除不可
            
            '@CPstrWaitThrowSt:"投入待ち"
            If lblStatus.Text = CPstrWaitThrowSt Then
        '@↓2013/11/27 (Wed) 19:28:34 T.Inafune **************************************************
                '@ｵｰﾀﾞ№あり
        '@        If mtypLotAttribute.strOrderNum <> vbNullString Then
        '@            '@分割ﾌﾗｸﾞ(子)の場合
        '@            If mtypLotAttribute.strDivideFlag = "1" Then
        '@                cmdCancelPlan.Enabled = True
        '@            Else
        '@                cmdCancelPlan.Enabled = False
        '@            End If
        '@        Else
                    '@ｷｬﾘｱIDに紐付くﾛｯﾄの場合(受入在庫)
        '@            If mtypLotAttribute.strCarrierID <> vbNullString Then
        '@                cmdCancelPlan.Enabled = False
        '@            Else
                        cmdCancelPlan.Enabled = True
        '@            End If
        '@        End If
        '@↑2013/11/27 (Wed) 19:28:34 T.Inafune **************************************************
            Else
                cmdCancelPlan.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnRegistButton_Chk"     'Function名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvstrDispMsg_Proc
    '機　能：変更ﾃﾞｰﾀ表示Msg作成
    '引　数：なし
    '戻り値：変更ﾃﾞｰﾀ表示Msg
    '作成日：2007/10/12 (Fri) 12:13:47 N.Kasai
    '更新日：2010/05/06 (Thu) 18:02:56 T.Oide
    '備　考：
    '　　　：2008/06/10 (Tue) 15:13:09 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/09 (Wed) 15:38:59 M.Koni       1stﾌｫﾄ号機設定変更対応 <案件No.02959>
    '　　　：2010/05/06 (Thu) 15:30:14 T.Oide       組立投入予定日追加対応<案件No.04021>
    Private Function prvstrDispMsg_Proc() As String
        
        Try
                
            '@表示Msg用変数のｸﾘｱ
            prvstrDispMsg_Proc = vbNullString
            
            
            '@数量の変更ﾁｪｯｸ
            If mblnChgWfNumFlag = True Then
                '@表示Msgの作成 　"数量[xxx→xxx]、
                prvstrDispMsg_Proc = prvstrDispMsg_Proc & CMstrDspMsgWfNum & lblBeforeWFNum.Text & CMstrDspMsgRight & _
                                                                                 txtWFNum.Text & CMstrDspMsgEndNext
            End If
            
            '@ﾛｯﾄ担当者の変更ﾁｪｯｸ
            If mblnChgLotManagerFlag = True Then
                '@表示Msgの作成 　"ﾛｯﾄ担当[xxx→xxx]、
                prvstrDispMsg_Proc = prvstrDispMsg_Proc & CMstrDspMsgLotManager & lblBeforeLotManager.Text & CMstrDspMsgRight & _
                                                                                 cmbLotManager.Text & CMstrDspMsgEndNext
            End If
            
            '@投入予定の変更ﾁｪｯｸ
            If mblnChgPlanDateFlag = True Then
                '@表示Msgの作成 　"投入予定日[xxx→xxx]、
                prvstrDispMsg_Proc = prvstrDispMsg_Proc & CMstrDspMsgDate & lblBeforePlanThrowDate.Text & CMstrDspMsgRight & _
                                                                                 calThrowinPlanDate.Value & CMstrDspMsgEndNext
            End If

            '@優先度の変更ﾁｪｯｸ
            If mblnChgPrioFlag = True Then
                '@表示Msgの作成 　"優先度[xxx→xxx]、
                prvstrDispMsg_Proc = prvstrDispMsg_Proc & CMstrDspMsgPrio & lblBeforePrio.Text & CMstrDspMsgRight & _
                                                                                 cmbPrioSel.Text & CMstrDspMsgEndNext
            End If
            
            '@P/Rｵｰﾀﾞｰの変更ﾁｪｯｸ
            If mblnChgPrOrderFlag = True Then
                '@表示Msgの作成 　"P/Rオーダー[[xxx→xxx]、
                prvstrDispMsg_Proc = prvstrDispMsg_Proc & CMstrDspMsgPrOrder & lblBeforePrOrder.Text & CMstrDspMsgRight & _
                                                                                 cmbPrOrder.Text & CMstrDspMsgEndNext
            End If
            
            '@送品先の変更ﾁｪｯｸ
            If mblnChgSendSBIDFlag = True Then
                '@表示Msgの作成 　"送品先[[xxx→xxx]、
                prvstrDispMsg_Proc = prvstrDispMsg_Proc & CMstrDspMsgSendSB & lblBeforeSendSBID.Text & CMstrDspMsgRight & _
                                                                                 cmbSendSBID.Text & CMstrDspMsgEndNext
            End If
            
            '@送品の変更ﾁｪｯｸ
            If mblnChgLotSendFlag = True Then
                '@表示Msgの作成 　"送品[[xxx→xxx]、
                prvstrDispMsg_Proc = prvstrDispMsg_Proc & CMstrDspMsgLotSendFlag & lblBeforeLotSend.Text & CMstrDspMsgRight & _
                                                                                 cmbLotSend.Text & CMstrDspMsgEndNext
            End If
            
            
            '@送品予定の変更ﾁｪｯｸ
            If mblnChgPlanShipDateFlag = True Then
                '@表示Msgの作成 　"送品予定日[xxx→xxx]、
                prvstrDispMsg_Proc = prvstrDispMsg_Proc & CMstrDspMsgShipDate & lblBeforePlanShipDate.Text & CMstrDspMsgRight & _
                                                                                 calPlanShipDate.Value & CMstrDspMsgEndNext
            End If

            '@1stﾌｫﾄ号機の変更ﾁｪｯｸ
            If mblnChgFirstPhotoFlag = True Then
                '@表示Msgの作成 　"1stフォト号機[xxx→xxx]、
                prvstrDispMsg_Proc = prvstrDispMsg_Proc & CMstrDspMsgFirstPhoto & lblBeforeFirstPhotoWpName.Text & CMstrDspMsgRight & _
                                                                                 CmbFirstPhotoWpName.Text & CMstrDspMsgEndNext
            End If


        '@↓2010/05/06 (Thu) 18:03:41 T.Oide **************************************************
            '@組立投入予定の変更ﾁｪｯｸ
            If mblnChgPlanAssTrowinDateFlag = True Then
                '@表示Msgの作成 　"組立投入予定日[xxx→xxx]、
                prvstrDispMsg_Proc = prvstrDispMsg_Proc & CMstrDspMsgPlanAssDate & lblBeforePlanAssThrowinDate.Text & CMstrDspMsgRight & _
                                                                                 calPlanAssThrowinDate.Value & CMstrDspMsgEndNext
            End If
        '@↑2010/05/06 (Thu) 18:03:41 T.Oide **************************************************




            
            '@最後に表示Msgの微調整をする
            If prvstrDispMsg_Proc <> vbNullString Then
                prvstrDispMsg_Proc = Strings.Left$(prvstrDispMsg_Proc, Len(prvstrDispMsg_Proc) - 1)       '、を削除する
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvstrDispMsg_Proc"         'Function名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvcmbLotSend_Set
    '機　能：送品ｺﾝﾎﾞ設定
    '引　数：なし
    '戻り値：なし
    '作成日：2006/10/31 (Tue) 13:28:23 N.Kasai
    '更新日：2006/10/31 (Tue) 13:28:23
    '備　考：
    Private Sub prvCmbLotSend_Set()

        Try

            '@ｺﾝﾎﾞ作成
            With cmbLotSend
                .ValueCol = 1
                .AddItem(CPstrNasiFlg & vbTab & CPlngLotSendNasi)
                .AddItem(CPstrAriFlg & vbTab & CPlngLotSendAri)
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbLotSend_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbLotSend_Disp
    '機　能：送品ｺﾝﾎﾞ強制設定
    '引　数：lstrFlowClass：種別
    '戻り値：なし
    '作成日：2006/10/31 (Tue) 14:51:33 N.Kasai
    '更新日：2011/04/26 (Tue) 17:14:25 T.Oide
    '備　考：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
    Private Sub prvCmbLotSend_Disp(ByVal lstrFlowClass As String)

        Try
            
            '@例外処理
            If lstrFlowClass = vbNullString Then
                cmbLotSend.Enabled = False
                Exit Sub
            End If

            '@流動区分によって処理分岐
            Select Case lstrFlowClass
            
                '@PR、ES
                Case CPstrFlowClassPR, CPstrFlowClassES
                    
                    '@基板ﾛｯﾄor組立TFTﾛｯﾄの場合
                    If (pstrSBID = CPstrSBID1A0) Or (mtypLotAttribute.strCfFlag = "0") Then
                        '@送品あり固定
                        With cmbLotSend
                            .Enabled = False
                             .ListIndex = 1
                        End With
                    Else
                        '@ｺﾝﾎﾞ使用不可
                        cmbLotSend.Enabled = False
                    End If
                    
        '@↓2011/04/26 (Tue) 16:58:23 T.Oide **************************************************
        '@        '@ﾀﾞﾐｰ、ﾓﾆﾀ、品格
        '@        Case CPstrFillerDummy, CPstrSideDummy, CPstrExtraDummy, CPstrFlowClassMO, CPstrFlowClassQU
        '@            '@送品なし固定
        '@            With cmbLotSend
        '@                .Enabled = False
        '@                .ListIndex = 0
        '@            End With
                    
                '@ﾀﾞﾐｰ、ﾓﾆﾀ
                Case CPstrFillerDummy, CPstrSideDummy, CPstrExtraDummy, CPstrFlowClassMO
                    
                    '@送品なし固定
                    With cmbLotSend
                        .Enabled = False
                        .ListIndex = 0
                    End With
                 
                '@品確
                Case CPstrFlowClassQU
                    
                    '@送品は変更可
                    cmbLotSend.Enabled = True
                    
        '@↑2011/04/26 (Tue) 16:58:23 T.Oide **************************************************
                
                '@その他
                Case Else
                    
                    '@基板ﾛｯﾄorTFTﾛｯﾄは使用可
                    If (pstrSBID = CPstrSBID1A0) Or (mtypLotAttribute.strCfFlag = "0") Then
                        '@ｺﾝﾎﾞ使用可能
                        cmbLotSend.Enabled = True
                    Else
                        '@ｺﾝﾎﾞ使用不可
                        cmbLotSend.Enabled = False
                    End If
            
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbLotSend_Disp"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Frame1.Paint, Frame2.Paint, fraLotManager.Paint, fraLotSend.Paint, fraPlanAssThrowinDate.Paint, fraPlanThrowDate.Paint, fraPrOrder.Paint, fraPrio.Paint, fraSendSB.Paint, fraWFNum.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
                                                                       calPlanAssThrowinDate.Enter,
                                                                       CmbFirstPhotoWpName.Enter, 
                                                                       calPlanShipDate.Enter, 
                                                                       cmdCancelPlan.Enter, 
                                                                       calThrowinPlanDate.Enter, 
                                                                       txtWFNum.Enter, 
                                                                       cmbLotSend.Enter, 
                                                                       cmbSendSBID.Enter, 
                                                                       cmdCommentDown.Enter, 
                                                                       cmdCommentUp.Enter, 
                                                                       optPrClass1.Enter,
                                                                       optPrClass0.Enter,
                                                                       cmbPrOrder.Enter, 
                                                                       cmbLotManager.Enter, 
                                                                       cmdMemoDown.Enter, 
                                                                       cmdMemoUp.Enter, 
                                                                       txtCarrier.Enter, 
                                                                       cmdClose.Enter, 
                                                                       cmdLotchgattr.Enter, 
                                                                       txtWorkMemo.Enter, 
                                                                       cmbPrioSel.Enter, 
                                                                       txtLot.Enter, 
                                                                       txtOrderComment.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub
End Class
