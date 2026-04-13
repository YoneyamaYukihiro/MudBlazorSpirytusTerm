'ﾌｧｲﾙ名：xxEN01X0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾛｯﾄ工順変更
'作成日：2006/05/12 (Fri) 09:14:09 N.Kasai
'更新日：2018/07/02 (Mon) 10:05:59 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01X0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01X0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01X0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01X0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01X0)
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
    '                                   * 定数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    'Private Const CMstrLocalVersion             As String = "14.01"
    Private Const CMstrLocalVersion             As String = "14.03"

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrprocprocchglistVer       As String = "03.00"                     '工順変更中ﾛｯﾄ工順変更
    Private Const CMstrprocprocchgstatusVer     As String = "03.01"                     '工順状態変更
    Private Const CMstrproccancelproceditVer    As String = "01.00"                     '工順編集取消し
    Private Const CMstrproceventlistVer         As String = "01.00"                     'ﾛｯﾄｲﾍﾞﾝﾄ履歴取得
    Private Const CMstrmas_empname_Ver          As String = "02.01"                     '作業者名取得

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN01X0              'ﾛｰｶﾙ機能ID

    '@ｸﾞﾘｯﾄﾞのｶﾗﾑ定数
    Private Const CMlngTHeight                  As Integer = 20                            'ﾀｲﾄﾙの高さ
    Private Const CMlngRHeight                  As Integer = 18                            '1明細の高さ
    Private Const CMlngTRow                     As Integer = 0                             'ﾀｲﾄﾙ行
    Private Const CMlngMaxCols                  As Integer = 29                            '最大列数

    '@vsfProcCngListの定数宣言(幅)
    Private Const CMlngvsfwLotListNo                As Integer = 37                           '№
    Private Const CMlngvsfwLotListKb                As Integer = 37                           '保留/停止
    Private Const CMlngvsfwLotListLotID             As Integer = 95                           'ﾛｯﾄID
    Private Const CMlngvsfwLotListOpID              As Integer = 90                           '大工程
    Private Const CMlngvsfwLotListStepID            As Integer = 90                           '小工程
    Private Const CMlngvsfwLotListLotStatus         As Integer = 76                           '状態
    Private Const CMlngvsfwLotListLotPos            As Integer = 93                           'ﾛｯﾄ位置
    Private Const CMlngvsfwLotListEditStatus        As Integer = 93                           '編集状態
    Private Const CMlngvsfwLotListEmpName           As Integer = 93                           '編集者
    Private Const CMlngvsfwLotListEditTime          As Integer = 109                          '最終更新日時
    Private Const CMlngvsfwLotListProcName          As Integer = 193                          'ﾕｰｻﾞｰﾌﾟﾛｾｽ名
    Private Const CMlngvsfwLotListPdID              As Integer = 54                           '機種
    Private Const CMlngvsfwLotListCarrierID         As Integer = 67                           'ｷｬﾘｱID
    Private Const CMlngvsfwLotListEmpID             As Integer = 67                           '編集者ID
    Private Const CMlngvsfwLotListComments          As Integer = 67                           'ｺﾒﾝﾄ
    Private Const CMlngvsfwLotListHistoryFlag       As Integer = 67                           '変更履歴読込ﾌﾗｸﾞ
    Private Const CMlngvsfwLotListHistory           As Integer = 67                           '変更履歴
    Private Const CMlngvsfwLotListKindFlag          As Integer = 67                           '種別
    Private Const CMlngvsfwLotListFlowClass         As Integer = 67                           '流動区分
    Private Const CMlngvsfwLotListLotHold           As Integer = 67                           '保留区分
    Private Const CMlngvsfwLotListLotStop           As Integer = 67                           '停止区分
    Private Const CMlngvsfwLotListLcDirection       As Integer = 67                           '液晶方向
    Private Const CMlngvsfwLotListReworkFlag        As Integer = 67                           'ﾘﾜｰｸﾌﾗｸﾞ
    Private Const CMlngvsfwLotListProcFlag          As Integer = 67                           'ﾛｯﾄ種別ﾌﾗｸﾞ
    Private Const CMlngvsfwLotListWfCarryFlag       As Integer = 67                           'WF移載中ﾌﾗｸﾞ
    Private Const CMlngvsfwLotListProhibitedFlag    As Integer = 67                           'ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ禁止(0:可、1:不可)
    Private Const CMlngvsfwLotListProhibitedEmp     As Integer = 67                           '禁止設定者
    Private Const CMlngvsfwLotListProhibitedDept    As Integer = 67                           '禁止設定者部署
    Private Const CMlngvsfwLotListLotLastUpdate     As Integer = 67                           '最終更新日時

    '@vsfProcCngListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsftLotListNo                    As String = "№"
    Private Const CMstrvsftLotListKb                    As String = ""
    Private Const CMstrvsftLotListLotID                 As String = "ロットID"
    Private Const CMstrvsftLotListOpID                  As String = "大工程"
    Private Const CMstrvsftLotListStepID                As String = "小工程"
    Private Const CMstrvsftLotListLotStatus             As String = "状態"
    Private Const CMstrvsftLotListLotPos                As String = "ロット位置"
    Private Const CMstrvsftLotListEditStatus            As String = "編集状態"
    Private Const CMstrvsftLotListEmpName               As String = "編集者"
    Private Const CMstrvsftLotListEditTime              As String = "最終更新日時"
    Private Const CMstrvsftLotListProcName              As String = "ユーザープロセス名"
    Private Const CMstrvsftLotListPdID                  As String = "機種"
    Private Const CMstrvsftLotListCarrierID             As String = "キャリアID"
    Private Const CMstrvsftLotListEmpID                 As String = "編集者ID"
    Private Const CMstrvsftLotListComments              As String = "ｺﾒﾝﾄ"
    Private Const CMstrvsftLotListHistoryFlag           As String = "変更履歴読込ﾌﾗｸﾞ"
    Private Const CMstrvsftLotListHistory               As String = "変更履歴"
    Private Const CMstrvsftLotListKindFlag              As String = "種別"""
    Private Const CMstrvsftLotListFlowClass             As String = "流動区分"
    Private Const CMstrvsftLotListLotHold               As String = "保留区分"
    Private Const CMstrvsftLotListLotStop               As String = "停止区分"
    Private Const CMstrvsftLotListLcDirection           As String = "液晶方向"
    Private Const CMstrvsftLotListReworkFlag            As String = "ﾘﾜｰｸﾌﾗｸﾞ"
    Private Const CMstrvsftLotListProcFlag              As String = "ﾛｯﾄ種別ﾌﾗｸﾞ"
    Private Const CMstrvsftLotListWfCarryFlag           As String = "WF移載中ﾌﾗｸﾞ"
    Private Const CMstrvsftLotListProhibitedFlag        As String = "VerUp"
    Private Const CMstrvsftLotListProhibitedEmp         As String = "禁止設定者"
    Private Const CMstrvsftLotListProhibitedDept        As String = "禁止設定者部署"
    Private Const CMstrvsftLotListLotLastUpdate         As String = "最終更新日時(lot_staus)"

    '@編集状態
    Private Const CMstrStateNotEdit             As String = "未編集"
    Private Const CMstrStateEditing             As String = "編集中"
    Private Const CMstrStateEditEnd             As String = "編集済み"
    Private Const CMstrStateApplyEnd            As String = "適用済み"
    Private Const CMstrEditStatus1              As String = "1"                         '編集中
    Private Const CMstrEditStatus2              As String = "2"                         '編集済み
    Private Const CMstrEditStatus3              As String = "3"                         '適用済み

    '@使用ﾌﾗｸﾞ
    Private Const CMstrUseFlag0                 As String = "0"                         '未使用
    Private Const CMstrUseFlag1                 As String = "1"                         '使用中
    Private Const CMstrUseFlag2                 As String = "2"                         '適用済
    Private Const CMstrUseFlag1Name             As String = "使用中"

    '@種別ﾌﾗｸﾞ
    Private Const CMstrKindFlag1                As String = "1"                         'ﾛｯﾄ工順変更
    Private Const CMstrKindFlag2                As String = "2"                         '組立工順一時保存

    '@ﾘﾜｰｸﾌﾗｸﾞ
    Private Const CMstrReworkFlgOn              As String = "1"                         'ﾘﾜｰｸﾌﾗｸﾞON
    Private Const CMstrLotReworkFlgOn2          As String = "2"                         '追加ﾌﾗｸﾞON

    '@保留/停止区分表示文字
    Private Const CMstrHo                       As String = "保"                        '保留表示
    Private Const CMstrTei                      As String = "停"                        '停止表示
    Private Const CMstrRi                       As String = "リ"                        'ﾘﾜｰｸ表示
    Private Const CMstrTsui                     As String = "追"                        '追加表示
    Private Const CMstrSen                      As String = "先"                        '先行表示
    Private Const CMstrIsai                     As String = "移"                        '移載表示

    '@変更履歴読込情報定数
    Private Const CMstrHistoryFlg1              As String = "1"                         '読込済
    Private Const CMstrHistoryCntNo             As String = "回目 "
    Private Const CMstrHistoryDeteFormat        As String = "yyyy/MM/dd HH:mm分"
    Private Const CMstrHistoryCntNow            As String = "今回分"
    Private Const CMstrHistoryChgName           As String = "－"

    '@ｺﾒﾝﾄｽｸﾛｰﾙ制御用
    Private Const CMlngMaxDispRow               As Integer = 6                             'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@ﾒｯｾｰｼﾞBOX & 通信ﾒｯｾｰｼﾞ
    Private Const CMstrCmdEditMsg               As String = "編集"
    Private Const CMstrCmdDeleteMsg             As String = "削除"
    Private Const CMstrCmdReturnMsg             As String = "差し戻し"
    Private Const CMstrCmdApplyMsg              As String = "適用"
    Private Const CMstrSameMsg1                 As String = "同"
    Private Const CMstrSameMsg0                 As String = "別"
    Private Const CMstrUserIDTitle              As String = "ユーザーID"

    '@その他
    '***************************************************************************************
    '                                   * 変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    Private mblnFormLoadFlag                    As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mtypProcChgList                     As ProcChgList                      '工順変更中ﾛｯﾄ工順構造体
    Private mtypChgSort                         As ChgSort                          'ｿｰﾄ保持用
    Private buttonProcessing                    As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                          'NSYS WindowCloseフラグ

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
    '                              * イベントハンドラの記述 *
    '***************************************************************************************
    '======================================Private==========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 11:28:30 N.Kasai
    '更新日：2006/05/12 (Fri) 11:28:30
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean          '結果格納

        Try

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01X0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(False, New FormClosingEventArgs(New CloseReason,  False))
                
                Exit Sub
            End If
            
            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call prvfrmxxEN01X0_Init()

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化
            mblnFormLoadFlag = False
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 11:28:47 N.Kasai
    '更新日：2006/05/12 (Fri) 11:28:47
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理判別
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
                
                '@最新取得
                Call cmdSearch_Click(cmdSearch,New EventArgs)
                
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Activate"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ｴﾝﾀｰで次項目に進む
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：未使用
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:33:17 N.Kasai
    '更新日：2006/05/12 (Fri) 12:33:17
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

             Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    Select Case ActiveControl.Name
                        '@ﾕｰｻﾞIDにﾌｫｰｶｽがある場合
                        Case txtUserID.Name
                            RemoveHandler txtUserID.Validating, AddressOf txtUserID_Validate
                            Call txtUserID_Validate(sender,New CancelEventArgs(True))
                            AddHandler txtUserID.Validating, AddressOf txtUserID_Validate

                        '@一覧にﾌｫｰｶｽがある場合
                        Case vsfProcCngList.Name
                            With vsfProcCngList
                                '@ﾃﾞｰﾀ行の場合
                                If .Row >= .Rows.Fixed Then
                                    '@編集ﾎﾞﾀﾝの押下
                                    If cmdEdit.Enabled = True Then
                                        '@編集ﾎﾞﾀﾝ処理へ
                                        Call cmdEdit_Click(cmdEdit,New EventArgs)
                                    End If
                                End If
                            End With
                        
                        '@その他
                        Case Else
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
            End Select

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌｫｰﾑのｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 15:22:51 N.Kasai
    '更新日：2006/05/12 (Fri) 15:22:51
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm         As Boolean      '開放結果格納
        Dim ltypProcChgList     As ProcChgList  '工順変更中ﾛｯﾄ一覧
        
        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
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

            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄとの関連付けを解除

            '@構造体のｸﾘｱ
            mtypProcChgList = ltypProcChgList   '工順変更中ﾛｯﾄ一覧
            
            'Erase mtypChgSort.typChgSortList()  'ｿｰﾄ保持用
            If mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort.typChgSortList.Clear
            End If

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：閉じるﾎﾞﾀﾝ押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:30:15 N.Kasai
    '更新日：2006/05/12 (Fri) 12:30:15
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim llngRet         As Integer
        Dim ltypCommonInfo  As CommonInfo
       
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS 不要なﾊﾞﾘﾃﾞｰﾄ回避ﾌﾗｸﾞ
            mblnCloseFromControlMenu = True

            '@終了関数を実行する
            llngRet = publngEnd_Proc(CPstrKeyEN01X0, ltypCommonInfo)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotChoice_Click
    '機　能：工順変更ﾛｯﾄ選択ﾎﾞﾀﾝ押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:37:11 N.Kasai
    '更新日：2006/05/12 (Fri) 12:37:11
    '備　考：
    Private Sub cmdLotChoice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotChoice.Click
        
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
            
            '@ﾛｯﾄ一覧画面表示
            RemoveHandler vsfProcCngList.EnterCell,AddressOf vsfProcCngList_EnterCell
            frmxxEN01X1.Instance.ShowDialog(Me)
            frmxxEN01X1.Instance = Nothing
            AddHandler vsfProcCngList.EnterCell,AddressOf vsfProcCngList_EnterCell

            '@工順変更中ﾛｯﾄが存在する場合は使用可能
            With vsfProcCngList
                If .Rows.Count > 1 Then
                    '@№の再設定
                    Call prvNo_Set()
                    
                    '@ｸﾞﾘｯﾄﾞ活性化
                    .Enabled = True
                    
                    '@列幅の自動調整
                    .AutoSizeCols(CPlngvsfProcCngListNo, .Cols.Count - 1, 6)
                    
                    '@ｶﾚﾝﾄ行へﾌｫｰｶｽ設定
                    If .Row >= 1 Then
                        .ShowCell(.Row, CPlngvsfProcCngListNo)
                        
                        '@ｶﾚﾝﾄ行ﾁｪｯｸ
                        Call vsfProcCngList_EnterCell(sender,e)
                        
                        '@ﾌｫｰｶｽ設定(ｸﾞﾘｯﾄﾞ)
                        If cmdEdit.Enabled = True Then
                            Call pubSetFocus(vsfProcCngList)
                        End If
                    End If
                End If
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdLotChoice_Click"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：CmdEdit_Click
    '機　能：編集ﾎﾞﾀﾝ押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/27 (Tue) 11:44:28 N.Kasai
    '更新日：2006/10/19 (Thu) 08:53:17 M.Miura
    '備　考：2006/10/19 (Thu) 08:53:17 M.Miura      保/停区分の結合表示(案件№01565)
    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEdit.Click
        
        Dim lblnAns                 As Boolean              '結果格納
        Dim llngMsgAns              As Integer              '結果格納(確認Msgﾎﾞｯｸｽ)
        Dim lblnEditCheckFlg        As Boolean              '編集ﾁｪｯｸﾌﾗｸﾞ(False:編集NG、True:編集OK)
        Dim ltypProcchgstatusReq    As ProcchgstatusReq     '要求格納構造体
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)

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
            
            '@初期化
            lblnEditCheckFlg = True         '編集OK
             
            If vsfProcCngList.Row < 1 Then
                Exit Sub
            End If
            
            '@選択済み行の編集者が存在する場合
            If vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpID) <> vbNullString Then
                '@編集者と選択行の編集者を比較する。
                If txtUserID.Text <> vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpID) Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002E, _
                                                    CMstrSameMsg0, _
                                                    vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpName), _
                                                    CMstrStateEditing, _
                                                    CMstrCmdEditMsg)
                    
                    '@"<TRM2EW>$$ロットは現在、%1ユーザー[%2]にて%3です。%4してもよろしいですか？"
                    '@"ロットは現在、別ユーザー[.strEmpName]にて編集中です。編集してもよろしいですか？"
                    llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                    '@要求確認
                    If llngMsgAns = vbNo Then
                        Exit Sub
                    End If
                End If
            End If
            
            '@移載予約中ﾛｯﾄの場合
            If vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListWfCarryFlag) = "1" Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005X)
                
                '@"<TRM5XI>$$移載予約中のロットを編集します。$ロット工順コピー機能で枚葉レシピのコピーは利用できませんがよろしいですか？"
                llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                '@要求確認
                If llngMsgAns = vbNo Then
                    Exit Sub
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "CmdEdit_Click"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            
            '@要求構造体に値を格納(ｱｸｼｮﾝｺｰﾄﾞ1:編集、2:削除、3:差戻し、4:適用)
            With ltypProcchgstatusReq
                .strSbID = pstrSBID
                .strMsgVer = CMstrprocprocchgstatusVer
                .strAction = "1"
                .strLotID = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotID)
                .strEmpID = txtUserID.Text
                .strLotLastUpdate = vbNullString
        '        .strVerUpProhibitedFlag = vbNullString
            End With
            
            '@MSG【工順状態変更】
            lblnAns = pubblnProcProcchgstatus_Upd(ltypProcchgstatusReq)
            
            '@登録結果の判定
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)
                
                '@編集者名を書きかえる
                vsfProcCngList.SetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpName, lblUserName.Text)
                vsfProcCngList.SetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpID, txtUserID.Text)
                
                '@ﾌﾟﾛｾｽ編集画面表示へ情報を渡す
                pstrLotID = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotID)                       'LotID(画面間の引渡し用)
                pstrEN01X0KindFlag = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListKindFlag)           '種別(1:工順変更、2:組立工順一時保存)
                pstrEN01X0PdId = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListPdID)                   '機種ID
                pstrUserID = txtUserID.Text                                                                                     'ﾕｰｻﾞID
                pstrFlowClass = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListFlowClass)               'FlowClass(画面間の引渡し用)
                pstrEN01X0ProcFlag = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListProcFlag)           'ﾛｯﾄ種別ﾌﾗｸﾞ(0:通常ﾛｯﾄ、1:特殊ﾛｯﾄ)
                pstrProhibitedEmp = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListProhibitedEmp)       '禁止担当者
                pstrProhibitedDept = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListProhibitedDept)     '禁止担当部署
                pstrVerUpProhibited = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListProhibitedFlag)    '禁止設(0:可、1:不可)

                
                '@Form_Loadﾌﾗｸﾞ(異常)
                pblnFormLoad = False
                 
                '@ﾌﾟﾛｾｽ編集画面をﾛｰﾄﾞ
                frmxxEN01X2.Instance = New frmxxEN01X2()
                
                '@Form_Loadﾌﾗｸﾞが異常の場合
                If pblnFormLoad = False Then
                
                    '@異常の場合は子画面終了
                    frmxxEN01X2.Instance = Nothing
                    
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(Me.Name, lstrEventName)
                    
                    '@工順編集取消ﾒｯｾｰｼﾞ送信処理呼び出し
                    lblnAns = pubblnProcCancelProcEdit_Upd(pstrSBID, _
                                                       CMstrproccancelproceditVer, _
                                                       vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotID), _
                                                       txtUserID.Text)
                    '@登録結果の判定
                    If lblnAns = True Then
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(Me.Name, lstrEventName)
                    Else
                        '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                        Call pubResponseCancel(Me.Name, lstrEventName)
                        Exit Sub
                    End If
                    
                    Exit Sub
                End If
            
                '@ﾌﾟﾛｾｽ編集画面を表示
                frmxxEN01X2.Instance.ShowDialog(Me)
                frmxxEN01X2.Instance = Nothing
                
                '@ﾌｫｰﾑの初期化
                frmxxEN01X2.Instance = Nothing
                pstrLotID = vbNullString                'ﾛｯﾄID
                pstrEN01X0KindFlag = vbNullString       '種別(1:ﾛｯﾄ工順変更、2:組立工順一時保存)
                pstrEN01X0PdId = vbNullString           '機種
        '        pstrUserID = vbNullString               'ﾕｰｻﾞID
                pstrFlowClass = vbNullString            'FlowClass(画面間の引渡し用)
                pstrEN01X0ProcFlag = vbNullString       'ﾛｯﾄ種別ﾌﾗｸﾞ(0:通常ﾛｯﾄ、1:特殊ﾛｯﾄ)
                pstrProhibitedEmp = vbNullString        '禁止担当者
                pstrProhibitedDept = vbNullString       '禁止担当部署
                pstrVerUpProhibited = vbNullString      '禁止設(0:可、1:不可)
                
                
                '@未編集色の場合は設定(背景を戻す)
                '@液晶方向
                Select Case vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLcDirection)
                    Case "L"
                        Dim newStyle As CellStyle = vsfProcCngList.Styles.Add("CustomStyle_BackColor_CPlngLColor")
                        newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngLColor))
                        Dim cellRange As CellRange = vsfProcCngList.GetCellRange(vsfProcCngList.Row, CPlngvsfProcCngListNo, _
                                                vsfProcCngList.Row, vsfProcCngList.Cols.Count - 1)
                        cellRange.Style = newStyle              '青色
                    Case "R"
                       Dim newStyle As CellStyle = vsfProcCngList.Styles.Add("CustomStyle_BackColor_CPlngRColor")
                       newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngRColor))
                       Dim cellRange As CellRange = vsfProcCngList.GetCellRange(vsfProcCngList.Row, CPlngvsfProcCngListNo, _
                                                vsfProcCngList.Row, vsfProcCngList.Cols.Count - 1)
                       cellRange.Style = newStyle              'ﾋﾞﾝｸ色
                    Case Else
                        Dim newStyle As CellStyle = vsfProcCngList.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        Dim cellRange As CellRange = vsfProcCngList.GetCellRange(vsfProcCngList.Row, CPlngvsfProcCngListNo, _
                                                vsfProcCngList.Row, vsfProcCngList.Cols.Count - 1)
                        cellRange.Style = newStyle                  '白色
                End Select
                
                '@保留の場合
                If vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotHold) = "1" Then
                     Dim newStyle As CellStyle = vsfProcCngList.Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                     newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngHoldLotColor))
                     Dim cellRange As CellRange = vsfProcCngList.GetCellRange(vsfProcCngList.Row, CPlngvsfProcCngListNo, _
                                                 vsfProcCngList.Row, vsfProcCngList.Cols.Count - 1)
                     cellRange.Style = newStyle       '黄色
                    
        '@↓2006/10/19 (Thu) 08:53:17 M.Miura 案件№01565 **************************************************
        ''            If vsfProcCngList.Cell(flexcpText, vsfProcCngList.Row, CPlngvsfProcCngListKb) = vbNullString Then
        ''                vsfProcCngList.Cell(flexcpText, vsfProcCngList.Row, CPlngvsfProcCngListKb) = CMstrHo            '保
        ''            End If

                    If vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListKb) = vbNullString Then
                        '@保/停区分が空の場合
                        vsfProcCngList.SetData(vsfProcCngList.Row, CPlngvsfProcCngListKb, CMstrHo)            '保
                    Else
                        '@保/停区分に設定されている場合
                        If vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListKb) _
                           Like "*" & CMstrHo & "*" = False Then
                            '@保/停区分に「保」が含まれていない場合
                            '@保/停区分に「保」を追加
                            vsfProcCngList.SetData(vsfProcCngList.Row, CPlngvsfProcCngListKb, _
                            pubstrColKbn_Set(CMstrHo, vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListKb)))   '「保」表示
                        End If
                    End If
        '@↓2006/10/19 (Thu) 08:53:17 M.Miura 案件№01565 **************************************************
                End If
                
                '@停止の場合
                If vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotStop) = "1" Then
                     Dim newStyle As CellStyle = vsfProcCngList.Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                     newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngHoldLotColor))
                     Dim cellRange As CellRange = vsfProcCngList.GetCellRange(vsfProcCngList.Row, CPlngvsfProcCngListNo, _
                                                 vsfProcCngList.Row, vsfProcCngList.Cols.Count - 1)
                     cellRange.Style = newStyle       '黄色
                End If
                
                vsfProcCngList.AutoSizeCols(0, vsfProcCngList.Cols.Count - 1, 6)
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, lstrEventName)
                
                '@工順編集取消ﾒｯｾｰｼﾞ送信処理呼び出し(工順変更編集者の作業IDをｾｯﾄ)
                lblnAns = pubblnProcCancelProcEdit_Upd(pstrSBID, _
                                                   CMstrproccancelproceditVer, _
                                                   vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotID), _
                                                   pstrUserID)
                '@登録結果の判定
                If lblnAns = True Then
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, lstrEventName)
                Else
                    '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                    Call pubResponseCancel(Me.Name, lstrEventName)
                    Exit Sub
                End If
                
                '@各ﾎﾞﾀﾝの制御
                Call vsfProcCngList_EnterCell(sender,e)
                If cmdEdit.Enabled = True Then
                    Call pubSetFocus(cmdEdit)
                    'NSYS 正常処理後最新取得ﾎﾞﾀﾝが有効の場合はﾌｫｰｶｽを移動
                ElseIf cmdSearch.Enabled = True Then
                    Call pubSetFocus(cmdSearch)
                End If

            Else
                '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                Call pubResponseCancel(Me.Name, lstrEventName)

                'NSYS 正常処理後最新取得ﾎﾞﾀﾝが有効の場合はﾌｫｰｶｽを移動
                If cmdSearch.Enabled = True Then
                    Call pubSetFocus(cmdSearch)
                End If
                
                Exit Sub
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "CmdEdit_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdDelete_Click
    '機　能：編集情報削除ﾎﾞﾀﾝ押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 13:10:15 N.Kasai
    '更新日：2006/05/12 (Fri) 13:10:15
    '備　考：
    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
        
        Dim lblnAns                 As Boolean          '結果格納
        Dim llngMsgAns              As Integer          '結果格納(確認Msgﾎﾞｯｸｽ)
        Dim lblnEditCheckFlg        As Boolean          '編集ﾁｪｯｸﾌﾗｸﾞ
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)
        Dim ltypProcchgstatusReq    As ProcchgstatusReq '要求格納構造体
        
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
            
            If vsfProcCngList.Row < 1 Then
                Exit Sub
            End If
            
            '@初期化
            lblnEditCheckFlg = True         '編集OK

            '@選択済み行の編集者が存在する場合
            If vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpID) <> vbNullString Then
                '@編集者と選択行の編集者を比較する。
                If txtUserID.Text <> vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpID) Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002E, _
                                                    CMstrSameMsg0, _
                                                    vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpName), _
                                                    CMstrStateEditing, _
                                                    CMstrCmdDeleteMsg)
                    
                    '@"<TRM2EW>$$ロットは現在、%1ユーザー[%2]にて%3です。%4してもよろしいですか？"
                    '@"ロットは現在、別ユーザー[.strEmpName]にて編集中です。削除してもよろしいですか？"
                    llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                    '@要求確認
                    If llngMsgAns = vbYes Then
                        lblnEditCheckFlg = True         '編集OK
                    Else
                        lblnEditCheckFlg = False        '編集NG
                    End If
                End If
            End If
            
            With vsfProcCngList
                '@編集状態が「未編集」の場合
                If .GetData(.Row, CPlngvsfProcCngListEditStatus) = CMstrStateNotEdit Then
                    
                    '@工順変更中ﾛｯﾄﾘｽﾄの行削除
                    .Redraw = False
                    .RemoveItem(.Row)
                    .Redraw = True   
                    
                    '@№の再設定
                    Call prvNo_Set()
                    
                    '@検索keyの初期化
                    mtypChgSort.strKey = vbNullString
                    
                    '@工順変更中ﾛｯﾄが存在しない場合は使用不可
                    If .Rows.Count = 1 Then
                        .Enabled = False
                        cmdDelete.Enabled = False
                        cmdEdit.Enabled = False
                        txtComments.Text = vbNullString
                        vsfProcCngList.AutoSizeCols(0, vsfProcCngList.Cols.Count - 1, 6)
                    Else
                        .Row = CMlngTRow           'ｶﾚﾝﾄ行の移動
                        '@各ﾎﾞﾀﾝの制御
                        Call vsfProcCngList_EnterCell(sender,e)
                        txtComments.Text = vbNullString

                        'NSYS 正常処理後最新取得ﾎﾞﾀﾝが有効の場合はﾌｫｰｶｽを移動
                        If cmdSearch.Enabled = True Then
                            Call pubSetFocus(cmdSearch)
                        End If
                    End If
                    
                    Exit Sub
                End If
            End With
            
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdDelete_Click"
            Call pubResponseStart(Me.Name, lstrEventName)

            '@要求構造体に値を格納(ｱｸｼｮﾝｺｰﾄﾞ1:編集、2:削除、3:差戻し、4:適用)
            With ltypProcchgstatusReq
                .strSbID = pstrSBID
                .strMsgVer = CMstrprocprocchgstatusVer
                .strAction = "2"
                .strLotID = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotID)
                .strEmpID = pstrUserID
                .strLotLastUpdate = vbNullString
        '        .strVerUpProhibitedFlag = vbNullString
            End With
            
            '@MSG【工順状態変更】
            lblnAns = pubblnProcProcchgstatus_Upd(ltypProcchgstatusReq)

            '@登録結果の判定
            If lblnAns = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001S, _
                                                CMstrCmdDeleteMsg, _
                                                vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotID))
                '@成功ﾒｯｾｰｼﾞ表示
                '@pubVsfInfo_Disp("メッセージコード<TRM1SI>$$ロット工順変更を削除しました。ロット[%2]")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                With vsfProcCngList
                
                    '@工順変更中ﾛｯﾄﾘｽﾄの行削除
                    .Redraw = False  
                    .RemoveItem(.Row)
                    .Redraw = True   
                    '@№の再設定
                    Call prvNo_Set()
                    
                    '@検索keyの初期化
                    mtypChgSort.strKey = vbNullString
                    
                    '@工順変更中ﾛｯﾄが存在しない場合は使用不可
                    If .Rows.Count = 1 Then
                        .Enabled = False
                        cmdDelete.Enabled = False
                        cmdEdit.Enabled = False
                        txtComments.Text = vbNullString
                        vsfProcCngList.AutoSizeCols(0, vsfProcCngList.Cols.Count - 1, 6)
                    Else
                        .Row = CMlngTRow           'ｶﾚﾝﾄ行の移動
                        '@各ﾎﾞﾀﾝの制御
                        Call vsfProcCngList_EnterCell(sender,e)
                        txtComments.Text = vbNullString

                        'NSYS 正常処理後最新取得ﾎﾞﾀﾝが有効の場合はﾌｫｰｶｽを移動
                        If cmdSearch.Enabled = True Then
                            Call pubSetFocus(cmdSearch)
                        End If
                    End If
                
                End With
               
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)
            Else
                '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                Exit Sub
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdDelete_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdReturn_Click
    '機　能：差し戻しﾎﾞﾀﾝ押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 13:20:02 N.Kasai
    '更新日：2006/05/12 (Fri) 13:20:02
    '備　考：特にﾛｯﾄの排他ﾁｪｯｸはしない
    Private Sub cmdReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdReturn.Click
        
        Dim lblnAns                 As Boolean          '結果格納
        Dim llngMsgAns              As Integer          '結果格納(確認Msgﾎﾞｯｸｽ)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)
        Dim ltypProcchgstatusReq    As ProcchgstatusReq '要求格納構造体
        Dim lblnEditCheckFlg        As Boolean          '編集ﾁｪｯｸﾌﾗｸﾞ
        
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
            
            If vsfProcCngList.Row < 1 Then
                Exit Sub
            End If
            
            '@初期化
            lblnEditCheckFlg = True         '編集OK

            '@選択済み行の編集者が存在する場合
            If vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpID) <> vbNullString Then
                '@編集者と選択行の編集者を比較する。
                If txtUserID.Text <> vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpID) Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002E, _
                                                    CMstrSameMsg0, _
                                                    vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpName), _
                                                    CMstrStateEditEnd, _
                                                    CMstrCmdReturnMsg)
                    
                    '@"<TRM2EW>$$ロットは現在、%1ユーザー[%2]にて%3です。%4してもよろしいですか？"
                    '@"ロットは現在、別ユーザー[.strEmpName]にて編集済みです。差し戻ししてもよろしいですか？"
                    llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                    '@要求確認
                    If llngMsgAns = vbYes Then
                        lblnEditCheckFlg = True         '編集OK
                    Else
                        lblnEditCheckFlg = False        '編集NG
                    End If
                End If
            End If
            
            '@編集ﾁｪｯｸﾌﾗｸﾞの確認
            If lblnEditCheckFlg = False Then
                Exit Sub
            End If
            
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdReturn_Click"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@要求構造体に値を格納(ｱｸｼｮﾝｺｰﾄﾞ1:編集、2:削除、3:差戻し、4:適用)
            With ltypProcchgstatusReq
                .strSbID = pstrSBID
                .strMsgVer = CMstrprocprocchgstatusVer
                .strAction = "3"
                .strLotID = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotID)
                .strEmpID = pstrUserID
                .strLotLastUpdate = vbNullString
        '        .strVerUpProhibitedFlag = vbNullString
            End With
            
            
            With vsfProcCngList
            
                '@MSG【工順状態変更】
                lblnAns = pubblnProcProcchgstatus_Upd(ltypProcchgstatusReq)
                
                '@登録結果の判定
                If lblnAns = True Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001S, _
                                                    CMstrCmdReturnMsg, _
                                                    .GetData(.Row, CPlngvsfProcCngListLotID))
                    '@成功ﾒｯｾｰｼﾞ表示
                    '@pubVsfInfo_Disp("メッセージコード<TRM1SI>$$ロット工順変更を差し戻ししました。ロット[%2]")
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@工順変更中ﾛｯﾄﾘｽﾄの編集状態変更(編集中へ)
                    .SetData(.Row, CPlngvsfProcCngListEditStatus, CMstrStateEditing)
                    '@差し戻し担当者へ変更
                    .SetData(.Row, CPlngvsfProcCngListEmpID, pstrUserID)
                    .SetData(.Row, CPlngvsfProcCngListEmpName, pstrUserName)
                    
                    '@各ﾎﾞﾀﾝの制御
                    Call vsfProcCngList_EnterCell(sender,e)
                    If cmdReturn.Enabled = True Then
                        Call pubSetFocus(cmdReturn)
                    Else
                        If cmdSearch.Enabled = True Then
                            Call pubSetFocus(cmdSearch)
                        End If
                    End If
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, lstrEventName)
                Else
                    '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                    Call pubResponseCancel(Me.Name, lstrEventName)
                    Exit Sub
                End If
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdReturn_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdSearch_Click
    '機　能：最新取得ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/22 (Mon) 14:11:26 N.Kasai
    '更新日：2006/05/22 (Mon) 14:11:26
    '備　考：
    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click

        Dim lblnAns                 As Boolean          '結果格納
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngRow                 As Integer          '検索結果
        Dim llngMsgAns              As Integer          'ﾒｯｾｰｼﾞ戻り値
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@未編集の行を検索
            llngRow = vsfProcCngList.FindRow(CMstrStateNotEdit, vsfProcCngList.Rows.Fixed, CPlngvsfProcCngListEditStatus, False)
            
            '@検索結果
            If llngRow <> -1 Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0049)
                '@"<TRM49I>$$最新取得を実行すると、未編集のロットはクリアされます。$よろしいですか？"
                llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)
                
                '@ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値判定
                If llngMsgAns = vbNo Then       '「いいえ」を選択
                    Exit Sub
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdSearch_Click"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@=======================
            '@ 工順変更中ﾛｯﾄ工順取得
            '@=======================
            '@【工順変更中ﾛｯﾄ工順取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnProcProcChgList_Sel(pstrSBID, CMstrprocprocchglistVer, mtypProcChgList)
            
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                Exit Sub
            End If
            
            '@=======================
            '@ 工順変更中ﾛｯﾄ表示
            '@=======================
            Call prvfrmxxEN01X0_Disp(mtypProcChgList)
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdSearch_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdApply_Click
    '機　能：適用ﾎﾞﾀﾝ押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 13:58:48 N.Kasai
    '更新日：2007/04/05 (Thu) 15:28:28 N.Kasai
    '備　考：
    '　　　：2007/04/05 (Thu) 15:28:28 N.Kasai  流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ(№01831)
    Private Sub cmdApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdApply.Click

        Dim lblnAns                 As Boolean          '結果格納
        Dim llngMsgAns              As Integer          '結果格納(確認Msgﾎﾞｯｸｽ)
        Dim lblnEditCheckFlg        As Boolean          '編集ﾁｪｯｸﾌﾗｸﾞ(False:編集NG、True:編集OK)
        Dim lstrResult              As String           '編集適用応答ﾌﾗｸﾞ
        Dim lstrGuidMsg             As String           'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String           'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String           '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrKindFlag            As String           '1:ﾛｯﾄ工順変更、2:組立工順一時保存
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)
        Dim ltypProcchgstatusReq    As ProcchgstatusReq '工順ﾛｯﾄ状態変更要求
        Dim lstrFunctionID          As String           '機能ID：EN01X0
        Dim lstrActionID            As String           'ｱｸｼｮﾝID：工順変更適用
        
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
            
            If vsfProcCngList.Row < 1 Then
                Exit Sub
            End If
            
            '@種別ﾌﾗｸﾞを退避(1:ﾛｯﾄ工順変更、2:組立工順一時保存)
            lstrKindFlag = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListKindFlag)

             '@初期化
            lblnEditCheckFlg = True         '編集OK

            '@選択済み行の編集者が存在する場合
            If vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpID) <> vbNullString Then
                '@編集者と選択行の編集者を比較する。
                If txtUserID.Text <> vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpID) Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002E, _
                                                    CMstrSameMsg0, _
                                                    vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListEmpName), _
                                                    CMstrStateEditEnd, _
                                                    CMstrCmdApplyMsg)
                    
                    '@"<TRM2EW>$$ロットは現在、%1ユーザー[%2]にて%3です。%4してもよろしいですか？"
                    '@"ロットは現在、別ユーザー[.strEmpName]にて編集済みです。適用してもよろしいですか？"
                    llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                    '@要求確認
                    If llngMsgAns = vbYes Then
                        lblnEditCheckFlg = True         '編集OK
                    Else
                        lblnEditCheckFlg = False        '編集NG
                    End If
                End If
            End If
            
            '@編集ﾁｪｯｸﾌﾗｸﾞの確認
            If lblnEditCheckFlg = False Then
                Exit Sub
            End If
            
        '@↓2007/11/20 (Tue) 14:13:57 N.Kasai **************************************************
        '    '@処理判別(1:ﾛｯﾄ工順変更、2:組立工順一時保存)
        '    If lstrKindFlag = CMstrKindFlag1 Then
        '        '@流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ禁止有無確認
        '        With vsfProcCngList
        '            '@ﾒｯｾｰｼﾞ表示用ﾃﾞｰﾀ格納
        '            lstrLotID = .Cell(flexcpText, .Row, CPlngvsfProcCngListLotID)
        '            lstrProhibitedEmp = .Cell(flexcpText, .Row, CPlngvsfProcCngListProhibitedEmp)
        '            lstrProhibitedDept = .Cell(flexcpText, .Row, CPlngvsfProcCngListProhibitedDept)
        '
        '            If .Cell(flexcpText, .Row, CPlngvsfProcCngListProhibitedFlag) = "1" Then
        '                '@既に流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟが禁止の場合
        '                '@表示ﾒｯｾｰｼﾞ変換
        '                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006U, lstrLotID, lstrProhibitedDept & " " & lstrProhibitedEmp)
        '                '@ﾒｯｾｰｼﾞ表示"<TRM6UI>$$ロット[%1]は、[%2]$により流動票バージョンアップ禁止設定されています。"
        '                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Caption, True, 16)
        '                lstrVerUpProhibited = "1"
        '            Else
        '                '@表示ﾒｯｾｰｼﾞ変換
        '                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006V, lstrLotID)
        '                '@ﾒｯｾｰｼﾞ表示"<TRM6VI>$$ロット[%1]に対して、流動票バージョンアップの$禁止を設定しますか？"
        '                llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Caption, True, 16)
        '
        '                '@要求確認
        '                If llngMsgAns = vbYes Then
        '                    '@流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ禁止設定
        '                    lstrVerUpProhibited = "1"
        '                Else
        '                    '@流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ禁止なし
        '                    lstrVerUpProhibited = vbNullString
        '                End If
        '            End If
        '        End With
        '    Else
        '        '@組立工順の場合
        '        lstrVerUpProhibited = vbNullString
        '    End If
        '@↑2007/11/20 (Tue) 14:13:57 N.Kasai **************************************************
            
            
            '@流動区分判定
            Select Case vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListFlowClass)
                
                '@「PR」、「ES」の場合は権限ﾁｪｯｸを行う
                Case CPstrFlowClassPR, CPstrFlowClassES
                    '@作業者ｺｰﾄﾞ入力(ﾊﾟｽﾜｰﾄﾞ付き)
                    frmxxCM0020.Instance.ShowDialog(Me)
                    frmxxCM0020.Instance = Nothing
                    
                    '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
                    If pblnCancel = True Then
                        Exit Sub
                    End If
                    
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    lstrEventName = "cmdApply_Click"
                    Call pubResponseStart(Me.Name, lstrEventName)
                    
                    '@実行権限の処理を追加
                    lstrFunctionID = CPstrKeyEN01X0     '機能ID：EN01X0
                    lstrActionID = CPstrChangeApply     'ｱｸｼｮﾝID：工順変更適用
                
                    '@実行権限ﾁｪｯｸ
                    lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, pstrUserID, pstrUserName, pstrSBID)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, lstrEventName)
                
                        '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, pstrUserName, lstrActionID)
                        '@警告ﾒｯｾｰｼﾞ
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                        Exit Sub
                    End If
                    
                Case Else
                    '@作業者ｺｰﾄﾞ入力
                    frmxxCM0010.Instance.ShowDialog(Me)
                    frmxxCM0010.Instance = Nothing
                    
                    '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
                    If pblnCancel = True Then
                        Exit Sub
                    End If
                    
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    lstrEventName = "cmdApply_Click"
                    Call pubResponseStart(Me.Name, lstrEventName)

            End Select
            
            '@要求構造体に値を格納(ｱｸｼｮﾝｺｰﾄﾞ1:編集、2:削除、3:差戻し、4:適用)
            With ltypProcchgstatusReq
                .strSbID = pstrSBID
                .strMsgVer = CMstrprocprocchgstatusVer
                .strAction = "4"
                .strLotID = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotID)
                .strEmpID = pstrUserID
                .strLotLastUpdate = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotLastUpdate)
        '        .strVerUpProhibitedFlag = lstrVerUpProhibited
            End With
            
            '@MSG【工順状態変更】
            lblnAns = pubblnProcProcchgstatus_Upd(ltypProcchgstatusReq, lstrResult, lstrGuidMsg, lstrGuidMsgCode)
            
            '@登録結果の判定
            If lblnAns = True Then
                '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っている場合
                If lstrGuidMsgCode <> vbNullString Then
                    
                    '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                    lstrEditGuidance = CPstrWarMsgCode _
                                     & CPstrGuidanceMsg _
                                     & CPstrMsgCrCode _
                                     & CPstrGuidanceCode _
                                     & CPstrBracketLeft _
                                     & lstrGuidMsgCode _
                                     & CPstrBracketRight _
                                     & CPstrMsgCrCode _
                                     & lstrGuidMsg
                    
                    '@ﾒｯｾｰｼﾞ表示"編集済みｶﾞｲﾀﾞﾝｽMsg"
                    pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                    '@ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If
                
                '@応答結果による処理判別
                If lstrResult = "0" Then
                    
                    With vsfProcCngList
                        '@適用OK
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001S, _
                                                        CMstrCmdApplyMsg, _
                                                        .GetData(.Row, CPlngvsfProcCngListLotID))
                        '@成功ﾒｯｾｰｼﾞ表示
                        '@pubVsfInfo_Disp("メッセージコード<TRM1SI>$$ロット工順変更を適用しました。ロット[%2]")
                        Call pubVsfInfo_Disp(pstrDMsg)
                        
                        '@処理判別(1:ﾛｯﾄ工順変更、2:組立工順一時保存)
                        If lstrKindFlag = CMstrKindFlag1 Then
                            '@工順変更
                            '@工順変更中ﾛｯﾄﾘｽﾄの行削除
                            .Redraw = False  
                            .RemoveItem(.Row)
                            .Redraw = True    
                    
                            '@№の再設定
                            Call prvNo_Set()
                            
                            '@検索keyの初期化
                            mtypChgSort.strKey = vbNullString
                    
                            '@工順変更中ﾛｯﾄが存在しない場合は使用不可
                            If .Rows.Count = 1 Then
                                .Enabled = False
                                cmdApply.Enabled = False    '適用
                                cmdReturn.Enabled = False   '差し戻し
                                cmdDelete.Enabled = False   '削除
                                txtComments.Text = vbNullString
                            Else
                                .Row = CMlngTRow           'ｶﾚﾝﾄ行の移動
                                '@各ﾎﾞﾀﾝの制御
                                Call vsfProcCngList_EnterCell(sender,e)
                                txtComments.Text = vbNullString
                            End If
                        Else
                            '@ﾕｰｻﾞｰﾌﾟﾛｾｽ
                            '@ﾕｰｻﾞｰﾌﾟﾛｾｽ適用後処理
                            Call prvUserProcessApply_Proc(.GetData(.Row, CPlngvsfProcCngListLotID), _
                                                      .GetData(.Row, CPlngvsfProcCngListProcName), .Row)
                                                      
                            '@各ﾎﾞﾀﾝの制御
                            Call vsfProcCngList_EnterCell(sender,e)
                        End If
                    End With
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, lstrEventName)
                Else
                    '@適用NG
                    '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                    Call pubResponseCancel(Me.Name, lstrEventName)

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004E, _
                                                    vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotID))
                    '@成功ﾒｯｾｰｼﾞ表示
                    '@pubVsfInfo_Disp("<TRM4EI>$$ロット[%1]はロット終了されています。$工順編集した情報を削除しますか？")
                    llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                    '@要求確認
                    If llngMsgAns = vbYes Then
                    '@削除する
                        '@ﾚｽﾎﾟﾝｽ取得開始
                        Call pubResponseStart(Me.Name, lstrEventName)
                        
                        '@要求構造体に値を格納(ｱｸｼｮﾝｺｰﾄﾞ1:編集、2:削除、3:差戻し、4:適用)
                        With ltypProcchgstatusReq
                            .strSbID = pstrSBID
                            .strMsgVer = CMstrprocprocchgstatusVer
                            .strAction = "2"
                            .strLotID = vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotID)
                            .strEmpID = pstrUserID
                            .strLotLastUpdate = vbNullString
        '                    .strVerUpProhibitedFlag = vbNullString
                        End With
                        
                        '@MSG【工順状態変更】
                        lblnAns = pubblnProcProcchgstatus_Upd(ltypProcchgstatusReq)

                        '@登録結果の判定
                        If lblnAns = True Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001S, _
                                                            CMstrCmdDeleteMsg, _
                                                            vsfProcCngList.GetData(vsfProcCngList.Row, CPlngvsfProcCngListLotID))
                            '@成功ﾒｯｾｰｼﾞ表示
                            '@pubVsfInfo_Disp("メッセージコード<TRM1SI>$$ロット工順変更を削除しました。ロット[%2]")
                            Call pubVsfInfo_Disp(pstrDMsg)

                            '@工順変更中ﾛｯﾄﾘｽﾄの行削除
                            vsfProcCngList.Redraw = False 
                            vsfProcCngList.RemoveItem(vsfProcCngList.Row)
                            vsfProcCngList.Redraw = True   

                            '@№の再設定
                            Call prvNo_Set()

                            '@工順変更中ﾛｯﾄが存在しない場合は使用不可
                            If vsfProcCngList.Rows.Count <= 1 Then
                                vsfProcCngList.Enabled = False
                                cmdApply.Enabled = False    '適用
                                cmdReturn.Enabled = False   '差し戻し
                                cmdDelete.Enabled = False   '削除
                                txtComments.Text = vbNullString
                            End If

                            '@各ﾎﾞﾀﾝの制御
                            Call vsfProcCngList_EnterCell(sender,e)
                            txtComments.Text = vbNullString
                            If cmdDelete.Enabled = True Then
                                Call pubSetFocus(cmdDelete)
                            End If

                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(Me.Name, lstrEventName)
                        Else
                            '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                            Call pubResponseCancel(Me.Name, lstrEventName)

                            Exit Sub
                        End If
                    Else
                        '@削除しない
                        '@各ﾎﾞﾀﾝの制御
                        Call vsfProcCngList_EnterCell(sender,e)
                        If cmdApply.Enabled = True Then
                            Call pubSetFocus(cmdApply)
                        End If
                    End If
                End If
            Else
                '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                Exit Sub
            End If

            'NSYS 正常処理後最新取得ﾎﾞﾀﾝが有効の場合はﾌｫｰｶｽを移動
            If cmdSearch.Enabled = True Then
                Call pubSetFocus(cmdSearch)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdApply_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：工順変更ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:43:38 N.Kasai
    '更新日：2006/05/12 (Fri) 12:43:38
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
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdUp_Click"                '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：工順変更ｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:44:00 N.Kasai
    '更新日：2006/05/12 (Fri) 12:44:00
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
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdDown_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_Change
    '機　能：ｺﾒﾝﾄ欄変更
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:44:27 N.Kasai
    '更新日：2006/05/12 (Fri) 12:44:27
    '備　考：
    Private Sub txtComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)
            
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
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:46:37 N.Kasai
    '更新日：2006/05/12 (Fri) 12:46:37
    '備　考：
    Private Sub txtComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComments.KeyUp
        
        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComments, CMlngMaxDispRow, cmdUP, cmdDown)
         
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
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:46:52 N.Kasai
    '更新日：2006/05/12 (Fri) 12:46:52
    '備　考：
    Private Sub txtComments_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)
            
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

    '関数名：txtUserID_Validate
    '機　能：ﾕｰｻﾞ名取得処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:47:47 N.Kasai
    '更新日：2006/05/12 (Fri) 12:47:47
    '備　考：
    Private Sub txtUserID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtUserID.Validating
        
        Dim lblnAns             As Boolean      '戻り値
        Dim lstrEmpName         As String       'ﾕｰｻﾞ名
        Dim lstrEventName       As String       'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ﾕｰｻﾞIDが使用不可の場合はｽｷｯﾌﾟ
            If txtUserID.Enabled = False Then
                Exit Sub
            End If
            
            '@ﾕｰｻﾞIDが空の場合、何もしない
            If txtUserID.Text = vbNullString Then
                Exit Sub
            Else
                '@ﾕｰｻﾞｰIDの桁ﾁｪｯｸ
                If txtUserID.NowByte < txtUserID.ChrMaxByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003K, CMstrUserIDTitle)
                    '@"[ユーザーID]は7桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    'NSYS フォーカスを元のままにする
                    If sender.Name = txtUserID.Name Then
                        sender.Focus()
                    Else
                        e.Cancel = True
                    End If

                    Exit Sub
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "txtUserID_Validate"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@ﾕｰｻﾞ名を取得
            lblnAns = pubblnMasEmpName_Sel(CMstrmas_empname_Ver, txtUserID.Text, lstrEmpName)
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)
                If lstrEmpName <> vbNullString Then
                    '@ﾕｰｻﾞ名を表示
                    lblUserName.Text = lstrEmpName
                    
                    '@ﾕｰｻﾞID変更不可
                    txtUserID.Enabled = False
                    
                    '@各ﾎﾞﾀﾝの制御
                    Call prvfrmxxEN01X0_CmdInit(True)
                End If
            Else
                '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                e.Cancel = True
                
                Exit Sub
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtUserID_Validate"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfProcCngList_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:48:25 N.Kasai
    '更新日：2006/05/12 (Fri) 12:48:25
    '備　考：
    Private Sub vsfProcCngList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfProcCngList.AfterSort

        Try
            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfProcCngList.BeforeRowColChange, AddressOf vsfProcCngList_BeforeRowColChange
            AddHandler vsfProcCngList.EnterCell, AddressOf vsfProcCngList_EnterCell

            'NSYS データ行がない場合は処理を抜ける
            If vsfProcCngList.Rows.Count <= vsfProcCngList.Rows.Fixed Then
                Return
            End If
            
            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                Dim tmpChgSortList As ChgSortList = New ChgSortList()

                '@ｿｰﾄ列番号を格納
                tmpChgSortList.lngCol = e.Col
                '@並び替え方法を格納(昇順/降順)
                tmpChgSortList.lngOrder = e.Order

                .typChgSortList.Add(tmpChgSortList)
            End With
            
            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
            Call pubVsfAfterSort(vsfProcCngList, CPlngvsfProcCngListLotID)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfProcCngList_AfterSort"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfProcCngList_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞ行移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/07/21 (Fri) 13:02:25 N.Kasai
    '更新日：2006/07/21 (Fri) 13:02:25
    '備　考：
    Private Sub vsfProcCngList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfProcCngList.BeforeRowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfProcCngList.Rows.Count <= vsfProcCngList.Rows.Fixed Then
                Return
            End If

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ﾛｯﾄID)
                mtypChgSort.strKey = vsfProcCngList.GetData(e.NewRange.r1, CPlngvsfProcCngListLotID)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                         '機能ID
                .strProcName = "vsfProcCngList_BeforeRowColChange"      '処理名
                .strErrMessage = vbNullString                           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfProcCngList_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:48:40 N.Kasai
    '更新日：2006/05/12 (Fri) 12:48:40
    '備　考：
    Private Sub vsfProcCngList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfProcCngList.BeforeSort

        Try
            'ソートでRowColChangeを発生しないようにする
            RemoveHandler vsfProcCngList.BeforeRowColChange, AddressOf vsfProcCngList_BeforeRowColChange
            RemoveHandler vsfProcCngList.EnterCell, AddressOf vsfProcCngList_EnterCell

            'NSYS データ行がない場合は処理を抜ける
            If vsfProcCngList.Rows.Count <= vsfProcCngList.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfProcCngList, CPlngvsfProcCngListLotID)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfProcCngList_BeforeSort"  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfProcCngList_DblClick
    '機　能：工順変更中ﾛｯﾄﾘｽﾄ　ﾀﾞﾌﾞﾙｸﾘｯｸ時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:49:11 N.Kasai
    '更新日：2006/05/12 (Fri) 12:49:11
    '備　考：
    Private Sub vsfProcCngList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfProcCngList.DoubleClick

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfProcCngList.Rows.Count <= vsfProcCngList.Rows.Fixed Then
                Return
            End If

            '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
            If vsfProcCngList.MouseRow = 0 Then
                Exit Sub
            End If
            
            '@ﾌﾟﾛｾｽ編集画面表示
            If cmdEdit.Enabled = True Then
                Call cmdEdit_Click(sender,e)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfProcCngList_DblClick"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfProcCngList_EnterCell
    '機　能：工順変更中ﾛｯﾄﾘｽﾄ ｶﾚﾝﾄ移動
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:51:15 N.Kasai
    '更新日：2006/05/12 (Fri) 12:51:15
    '備　考：
    Private Sub vsfProcCngList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfProcCngList.EnterCell

        Dim lblnAns             As Boolean          '戻り値
        Dim ltypProcEventList   As ProcEventList    'ﾛｯﾄｲﾍﾞﾝﾄ履歴構造体
        Dim lstrEventName       As String           'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfProcCngList.Rows.Count <= vsfProcCngList.Rows.Fixed Then
                Return
            End If
            
            '@ﾃﾞｰﾀ件数が0件の場合
            If vsfProcCngList.Rows.Count = 1 Then
                Exit Sub
            End If
            '@ｸﾞﾘｯﾄﾞ使用不可の場合
            If vsfProcCngList.Enabled = False Then
                Exit Sub
            End If
            
            If vsfProcCngList.Row < 1 Then
                '@各ﾎﾞﾀﾝの制御
                Call prvfrmxxEN01X0_CmdInit(True)
                Exit Sub
            End If
            
            With vsfProcCngList
                '@変更履歴読込み判定
                If .GetData(.Row, CPlngvsfProcCngListHistoryFlag) = vbNullString Then
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    lstrEventName = "vsfProcCngList_EnterCell"
                    Call pubResponseStart(Me.Name, lstrEventName)
                    
                    '@ﾛｯﾄｲﾍﾞﾝﾄ履歴取得
                    lblnAns = pubblnProcEventList_Sel(pstrSBID, _
                                                     CMstrproceventlistVer, _
                                                     .GetData(.Row, CPlngvsfProcCngListLotID), _
                                                     ltypProcEventList)
                    If lblnAns = True Then
                        '@ﾛｯﾄｲﾍﾞﾝﾄ履歴格納
                        Call prvLotEventHistory_Set(ltypProcEventList)
                        
                        '@ﾛｯﾄｲﾍﾞﾝﾄ履歴格納済設定
                        .SetData(.Row, CPlngvsfProcCngListHistoryFlag, CMstrHistoryFlg1)
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(Me.Name, lstrEventName)
                    Else
                        '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                        Call pubResponseCancel(Me.Name, lstrEventName)
                    End If
                End If
                
                '@工順変更ｺﾒﾝﾄの表示(今回分＋前回の降順)
                If .GetData(.Row, CPlngvsfProcCngListComments) <> vbNullString Then
                    txtComments.Text = CMstrHistoryChgName _
                                     & Space(1) _
                                     & CMstrHistoryCntNow _
                                     & Space(1) _
                                     & .GetData(.Row, CPlngvsfProcCngListEmpName) _
                                     & Space(1) _
                                     & CMstrHistoryChgName _
                                     & vbCrLf _
                                     & .GetData(.Row, CPlngvsfProcCngListComments) _
                                     & vbCrLf _
                                     & .GetData(.Row, CPlngvsfProcCngListHistory)
                Else
                    txtComments.Text = .GetData(.Row, CPlngvsfProcCngListHistory)
                End If
                
                '@各ﾎﾞﾀﾝの制御
                Call prvfrmxxEN01X0_CmdInit(True)
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfProcCngList_EnterCell"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                                   * 関数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    '関数名：prvfrmxxEN01X0_Init
    '機　能：ﾌｫｰﾑのｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 15:25:22 N.Kasai
    '更新日：2009/03/05 (Thu) 13:51:10 N.Kojima
    '備　考：
    '　　　：2007/04/05 (Thu) 15:39:43 N.Kasai      流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ(№01831)
    '　　　：2009/03/05 (Thu) 13:51:10 N.Kojima     ﾁｯﾌﾟ品判別説明ﾗﾍﾞﾙの制御処理追加。(案件№03402)
    Private Sub prvfrmxxEN01X0_Init()

        Dim lstrFormTitle   As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        
        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01X0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            
        '@↓2009/03/05 (Thu) 13:49:48 N.Kojima **************************************************
            
            '@-----------------------
            '@ ﾗﾍﾞﾙﾊﾞｯｸｶﾗｰ設定
            '@-----------------------
            '@起動SBが"2A0：組立"か
            If pstrSBID = CPstrSBID2A0 Then
                '@2A0：組立の場合
            
                lblTitleL.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngLColor))           '機種L
                lblTitleR.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngRColor))           '機種R
                lblTitleL.Visible = True
                lblTitleR.Visible = True
                lblTitleChip.Visible = True                 'ﾁｯﾌﾟ品説明
            Else
                '@1A0：基板の場合

                lblTitleL.Visible = False
                lblTitleR.Visible = False
                lblTitleChip.Visible = False                'ﾁｯﾌﾟ品説明
            End If

        '@↑2009/03/05 (Thu) 13:49:48 N.Kojima **************************************************
            
            '@保留停止色
            lblTitleHT.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngHoldLotColor))    '保留/停止
            
            
            '@内容のｸﾘｱ
            txtUserID.Text = vbNullString
            lblUserName.Text = vbNullString
            txtComments.Text = vbNullString
            lblGetInfoDate.Text = vbNullString
            lblListCnt.Text = vbNullString
            txtComments.Locked = True

           '@ﾕｰｻﾞｰID初期化
            With txtUserID
                .FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
                .ChrMaxByte = CPlngEmpIDLength
                .ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
            End With
            
            '@ｽｸﾛｰﾙﾎﾞﾀﾝの初期化
            cmdUP.Enabled = False
            cmdDown.Enabled = False
            
            '@ﾎﾞﾀﾝの使用不可
            Call prvfrmxxEN01X0_CmdInit(False)
            
            '@工順変更中ﾛｯﾄ一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfProcCngList

                '@描画ﾛｯｸ
                .Redraw = False
                
                '@ｸﾘｱ
                .Clear(ClearFlags.UserData)

                '@ｸﾞﾘｯﾄﾞの行設定
                .Rows.Count = CMlngTRow + 1

                '@ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMlngMaxCols
                
                '@固定行の設定
                .Cols.Frozen = CPlngvsfProcCngListOpID
                
                '@ﾏｳｽよる列ｻｲｽﾞ変更の可
                .AllowResizing = AllowResizingEnum.Columns
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.None

                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                   '文字色
                lFixedStyle.BackColor = Color.Navy                     '背景色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter

                '@文章を折り返しなし
                .Styles.Normal.WordWrap = False
                
                '@列の調整を可能にする
                '.AutoSizeMode = flexAutoSizeColWidth

                '@表示位置設定
                .Cols(CPlngvsfProcCngListNo).TextAlign = TextAlignEnum.RightCenter                                 '№
                .Cols(CPlngvsfProcCngListLotID).TextAlign = TextAlignEnum.LeftCenter                               'ﾛｯﾄID
                .Cols(CPlngvsfProcCngListOpID).TextAlign = TextAlignEnum.LeftCenter                                '大工程
                .Cols(CPlngvsfProcCngListStepID).TextAlign = TextAlignEnum.LeftCenter                              '小工程
                .Cols(CPlngvsfProcCngListLotStatus).TextAlign = TextAlignEnum.LeftCenter                           '状態
                .Cols(CPlngvsfProcCngListLotPos).TextAlign = TextAlignEnum.LeftCenter                              'ﾛｯﾄ位置
                .Cols(CPlngvsfProcCngListEditStatus).TextAlign = TextAlignEnum.LeftCenter                          '編集状態
                .Cols(CPlngvsfProcCngListEmpName).TextAlign = TextAlignEnum.LeftCenter                             '編集者
                .Cols(CPlngvsfProcCngListEditTime).TextAlign = TextAlignEnum.LeftCenter                            '最終更新日時
                .Cols(CPlngvsfProcCngListProcName).TextAlign = TextAlignEnum.LeftCenter                            'ﾕｰｻﾞｰﾌﾟﾛｾｽ名
                .Cols(CPlngvsfProcCngListPdID).TextAlign = TextAlignEnum.LeftCenter                                '機種
                .Cols(CPlngvsfProcCngListCarrierID).TextAlign = TextAlignEnum.LeftCenter                           'ｷｬﾘｱID
                .Cols(CPlngvsfProcCngListEmpID).TextAlign = TextAlignEnum.LeftCenter                               '編集者ID
                .Cols(CPlngvsfProcCngListComments).TextAlign = TextAlignEnum.LeftCenter                            'ｺﾒﾝﾄ
                .Cols(CPlngvsfProcCngListHistoryFlag).TextAlign = TextAlignEnum.LeftCenter                         '変更履歴読込ﾌﾗｸﾞ
                .Cols(CPlngvsfProcCngListHistory).TextAlign = TextAlignEnum.LeftCenter                             '変更履歴
                .Cols(CPlngvsfProcCngListKindFlag).TextAlign = TextAlignEnum.LeftCenter                            '種別
                .Cols(CPlngvsfProcCngListFlowClass).TextAlign = TextAlignEnum.LeftCenter                           '流動区分
                .Cols(CPlngvsfProcCngListLotHold).TextAlign = TextAlignEnum.LeftCenter                             '保留区分
                .Cols(CPlngvsfProcCngListLotStop).TextAlign = TextAlignEnum.LeftCenter                             '停止区分
                .Cols(CPlngvsfProcCngListLcDirection).TextAlign = TextAlignEnum.LeftCenter                         '液晶方向
                .Cols(CPlngvsfProcCngListReworkFlag).TextAlign = TextAlignEnum.LeftCenter                          'ﾘﾜｰｸﾌﾗｸﾞ
                .Cols(CPlngvsfProcCngListProcFlag).TextAlign = TextAlignEnum.LeftCenter                            'ﾛｯﾄ種別ﾌﾗｸﾞ
                .Cols(CPlngvsfProcCngListWfCarryFlag).TextAlign = TextAlignEnum.LeftCenter                         'WF移載中ﾌﾗｸﾞ
        '@↓2007/04/05 (Thu) 11:07:09 N.Kasai **************************************************
                .Cols(CPlngvsfProcCngListProhibitedFlag).TextAlign = TextAlignEnum.LeftCenter                      'VerUp禁止(0:可、1:不可)
                .Cols(CPlngvsfProcCngListProhibitedEmp).TextAlign = TextAlignEnum.LeftCenter                       '禁止設定者
                .Cols(CPlngvsfProcCngListProhibitedDept).TextAlign = TextAlignEnum.LeftCenter                      '禁止設定者部署
                .Cols(CPlngvsfProcCngListLotLastUpdate).TextAlign = TextAlignEnum.LeftCenter                       '最終更新日時(lot_status)
        '@↑2007/04/05 (Thu) 11:07:09 N.Kasai **************************************************
                
                '@列幅設定
                .Cols(CPlngvsfProcCngListNo).Width = CMlngvsfwLotListNo                                       '№
                .Cols(CPlngvsfProcCngListLotID).Width = CMlngvsfwLotListLotID                                 'ﾛｯﾄID
                .Cols(CPlngvsfProcCngListOpID).Width = CMlngvsfwLotListOpID                                   '大工程
                .Cols(CPlngvsfProcCngListStepID).Width = CMlngvsfwLotListStepID                               '小工程
                .Cols(CPlngvsfProcCngListLotStatus).Width = CMlngvsfwLotListLotStatus                         '状態
                .Cols(CPlngvsfProcCngListLotPos).Width = CMlngvsfwLotListLotPos                               'ﾛｯﾄ位置
                .Cols(CPlngvsfProcCngListEditStatus).Width = CMlngvsfwLotListEditStatus                       '編集状態
                .Cols(CPlngvsfProcCngListEmpName).Width = CMlngvsfwLotListEmpName                             '編集者
                .Cols(CPlngvsfProcCngListEditTime).Width = CMlngvsfwLotListEditTime                           '最終更新日時
                .Cols(CPlngvsfProcCngListProcName).Width = CMlngvsfwLotListProcName                           'ﾕｰｻﾞｰﾌﾟﾛｾｽ名
                .Cols(CPlngvsfProcCngListPdID).Width = CMlngvsfwLotListPdID                                   '機種
                .Cols(CPlngvsfProcCngListCarrierID).Width = CMlngvsfwLotListCarrierID                         'ｷｬﾘｱID
                .Cols(CPlngvsfProcCngListEmpID).Width = CMlngvsfwLotListEmpID                                 '編集者ID
                .Cols(CPlngvsfProcCngListComments).Width = CMlngvsfwLotListComments                           'ｺﾒﾝﾄ
                .Cols(CPlngvsfProcCngListHistoryFlag).Width = CMlngvsfwLotListHistoryFlag                     '変更履歴読込ﾌﾗｸﾞ
                .Cols(CPlngvsfProcCngListHistory).Width = CMlngvsfwLotListHistory                             '変更履歴
                .Cols(CPlngvsfProcCngListKindFlag).Width = CMlngvsfwLotListKindFlag                           '種別
                .Cols(CPlngvsfProcCngListFlowClass).Width = CMlngvsfwLotListFlowClass                         '流動区分
                .Cols(CPlngvsfProcCngListLotHold).Width = CMlngvsfwLotListFlowClass                           '保留区分
                .Cols(CPlngvsfProcCngListLotStop).Width = CMlngvsfwLotListFlowClass                           '停止区分
                .Cols(CPlngvsfProcCngListLcDirection).Width = CMlngvsfwLotListFlowClass                       '液晶方向
                .Cols(CPlngvsfProcCngListReworkFlag).Width = CMlngvsfwLotListReworkFlag                       'ﾘﾜｰｸﾌﾗｸﾞ
                .Cols(CPlngvsfProcCngListProcFlag).Width = CMlngvsfwLotListProcFlag                           'ﾛｯﾄ種別ﾌﾗｸﾞ
                .Cols(CPlngvsfProcCngListWfCarryFlag).Width = CMlngvsfwLotListWfCarryFlag                     'WF移載中ﾌﾗｸﾞ
        '@↓2007/04/05 (Thu) 11:09:28 N.Kasai **************************************************
                .Cols(CPlngvsfProcCngListProhibitedFlag).Width = CMlngvsfwLotListProhibitedFlag               'VerUp禁止(0:可、1:不可)
                .Cols(CPlngvsfProcCngListProhibitedEmp).Width = CMlngvsfwLotListProhibitedEmp                 '禁止設定者
                .Cols(CPlngvsfProcCngListProhibitedDept).Width = CMlngvsfwLotListProhibitedDept               '禁止設定者部署
                .Cols(CPlngvsfProcCngListLotLastUpdate).Width = CMlngvsfwLotListLotLastUpdate                 '最終更新日時(lot_status)
        '@↑2007/04/05 (Thu) 11:09:28 N.Kasai **************************************************
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngTRow, CPlngvsfProcCngListNo, CMstrvsftLotListNo)                    '№
                .SetData(CMlngTRow, CPlngvsfProcCngListLotID, CMstrvsftLotListLotID)              'ﾛｯﾄID
                .SetData(CMlngTRow, CPlngvsfProcCngListOpID, CMstrvsftLotListOpID)                '大工程
                .SetData(CMlngTRow, CPlngvsfProcCngListStepID, CMstrvsftLotListStepID)            '小工程
                .SetData(CMlngTRow, CPlngvsfProcCngListLotStatus, CMstrvsftLotListLotStatus)      '状態
                .SetData(CMlngTRow, CPlngvsfProcCngListLotPos, CMstrvsftLotListLotPos)            'ﾛｯﾄ位置
                .SetData(CMlngTRow, CPlngvsfProcCngListEditStatus, CMstrvsftLotListEditStatus)    '編集状態
                .SetData(CMlngTRow, CPlngvsfProcCngListEmpName, CMstrvsftLotListEmpName)          '編集者
                .SetData(CMlngTRow, CPlngvsfProcCngListEditTime, CMstrvsftLotListEditTime)        '最終更新日時
                .SetData(CMlngTRow, CPlngvsfProcCngListProcName, CMstrvsftLotListProcName)        'ﾕｰｻﾞｰﾌﾟﾛｾｽ名
                .SetData(CMlngTRow, CPlngvsfProcCngListPdID, CMstrvsftLotListPdID)                '機種
                .SetData(CMlngTRow, CPlngvsfProcCngListCarrierID, CMstrvsftLotListCarrierID)      'ｷｬﾘｱID
                .SetData(CMlngTRow, CPlngvsfProcCngListEmpID, CMstrvsftLotListEmpID)              '編集者ID
                .SetData(CMlngTRow, CPlngvsfProcCngListComments, CMstrvsftLotListComments)        'ｺﾒﾝﾄ
                .SetData(CMlngTRow, CPlngvsfProcCngListHistoryFlag, CMstrvsftLotListHistoryFlag)  '変更履歴読込ﾌﾗｸﾞ
                .SetData(CMlngTRow, CPlngvsfProcCngListHistory, CMstrvsftLotListHistory)          '変更履歴
                .SetData(CMlngTRow, CPlngvsfProcCngListKindFlag, CMstrvsftLotListKindFlag)        '種別
                .SetData(CMlngTRow, CPlngvsfProcCngListFlowClass, CMstrvsftLotListFlowClass)      '流動区分
                .SetData(CMlngTRow, CPlngvsfProcCngListLotHold, CMstrvsftLotListLotHold)          '保留区分
                .SetData(CMlngTRow, CPlngvsfProcCngListLotStop, CMstrvsftLotListLotStop)          '停止区分
                .SetData(CMlngTRow, CPlngvsfProcCngListLcDirection, CMstrvsftLotListLcDirection)  '液晶方向
                .SetData(CMlngTRow, CPlngvsfProcCngListReworkFlag, CMstrvsftLotListReworkFlag)    'ﾘﾜｰｸﾌﾗｸﾞ
                .SetData(CMlngTRow, CPlngvsfProcCngListProcFlag, CMstrvsftLotListProcFlag)        'ﾛｯﾄ種別ﾌﾗｸﾞ
                .SetData(CMlngTRow, CPlngvsfProcCngListWfCarryFlag, CMstrvsftLotListWfCarryFlag)  'WF移載中ﾌﾗｸﾞ
                
        '@↓2007/04/05 (Thu) 11:11:14 N.Kasai **************************************************
                .SetData(CMlngTRow, CPlngvsfProcCngListProhibitedFlag, CMstrvsftLotListProhibitedFlag)    'VerUp禁止(0:可、1:不可)
                .SetData(CMlngTRow, CPlngvsfProcCngListProhibitedEmp, CMstrvsftLotListProhibitedEmp)      '禁止設定者
                .SetData(CMlngTRow, CPlngvsfProcCngListProhibitedDept, CMstrvsftLotListProhibitedDept)    '禁止設定者部署
                .SetData(CMlngTRow, CPlngvsfProcCngListLotLastUpdate, CMstrvsftLotListLotLastUpdate)      '最終更新日時(lot_status)
        '@↑2007/04/05 (Thu) 11:11:14 N.Kasai **************************************************
                
                '@ﾍｯﾀﾞｰの高さ設定
                .Rows(CMlngTRow).Height = CMlngTHeight
                
                '@非表示列
                .Cols(CPlngvsfProcCngListEmpID).Visible = False             '編集者ID
                .Cols(CPlngvsfProcCngListComments).Visible = False          'ｺﾒﾝﾄ
                .Cols(CPlngvsfProcCngListHistoryFlag).Visible = False       '変更履歴読込ﾌﾗｸﾞ
                .Cols(CPlngvsfProcCngListHistory).Visible = False           '変更履歴読込ﾌﾗｸﾞ
                .Cols(CPlngvsfProcCngListKindFlag).Visible = False          '種別
                .Cols(CPlngvsfProcCngListFlowClass).Visible = False         '流動区分
                .Cols(CPlngvsfProcCngListLotHold).Visible = False           '保留区分
                .Cols(CPlngvsfProcCngListLotStop).Visible = False           '停止区分
                .Cols(CPlngvsfProcCngListLcDirection).Visible = False       '液晶方向
                .Cols(CPlngvsfProcCngListReworkFlag).Visible = False        'ﾘﾜｰｸﾌﾗｸﾞ
                .Cols(CPlngvsfProcCngListProcFlag).Visible = False          'ﾛｯﾄ種別ﾌﾗｸﾞ
                .Cols(CPlngvsfProcCngListWfCarryFlag).Visible = False       'WF移載中ﾌﾗｸﾞ
                .Cols(CPlngvsfProcCngListProhibitedFlag).Visible = False    'VerUp禁止
                .Cols(CPlngvsfProcCngListProhibitedEmp).Visible = False     '禁止設定者
                .Cols(CPlngvsfProcCngListProhibitedDept).Visible = False    '禁止設定者部署
                .Cols(CPlngvsfProcCngListLotLastUpdate).Visible = False     '最終更新日時
                
                '@描画ﾛｯｸ解除
                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False

            End With
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN01X0_Init"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN01X0_CmdInit
    '機　能：各ｺﾏﾝﾄﾞﾎﾞﾀﾝの制御
    '引　数：lblnEnable：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:31:22 N.Kasai
    '更新日：2006/05/12 (Fri) 12:31:22
    '備　考：
    Private Sub prvfrmxxEN01X0_CmdInit(Optional ByVal lblnEnable As Boolean = False)
        
        Try
                
            '@ﾎﾞﾀﾝ初期化
            cmdLotChoice.Enabled = False        '工順変更ﾛｯﾄ選択
            cmdEdit.Enabled = False             '編集
            cmdDelete.Enabled = False           '編集情報削除
            cmdReturn.Enabled = False           '差戻し
            cmdApply.Enabled = False            '適用
            
            '@使用可の場合は状態に応じて制御
            If lblnEnable = True Then
                If txtUserID.Enabled = False Then
                    cmdLotChoice.Enabled = True     '工順変更ﾛｯﾄ選択
                    With vsfProcCngList
                        If .Enabled = True And .Row >= 1 Then
                            '@種別により分岐する
                            Select Case .GetData(.Row, CPlngvsfProcCngListKindFlag)
                                '@ﾛｯﾄ工順変更
                                Case CMstrKindFlag1
                                    Select Case .GetData(.Row, CPlngvsfProcCngListEditStatus)
                                        '@未編集
                                        Case CMstrStateNotEdit
                                            cmdEdit.Enabled = True          '編集(可能)
                                            cmdReturn.Enabled = False       '差戻(不可)
                                            cmdApply.Enabled = False        '適用(不可)
                                        
                                        '@編集中
                                        Case CMstrStateEditing
                                            cmdEdit.Enabled = True          '編集(可能)
                                            cmdReturn.Enabled = False       '差戻(不可)
                                            cmdApply.Enabled = False        '適用(不可)
                                        
                                        '@編集済
                                        Case CMstrStateEditEnd
                                            cmdEdit.Enabled = False         '編集(不可)
                                            cmdReturn.Enabled = True        '差戻(可能)
                                            cmdApply.Enabled = True         '適用(可能)
                                    End Select
                                    
                                    '@削除ﾎﾞﾀﾝは同一ﾕｰｻﾞｰのみ可能とする
                                    If .GetData(.Row, CPlngvsfProcCngListEmpID) = txtUserID.Text Then
                                        cmdDelete.Enabled = True        '編集情報削除
                                    End If
                                    
                                '@ﾕｰｻﾞﾌﾟﾛｾｽ工順変更
                                Case CMstrKindFlag2
                                    Select Case .GetData(.Row, CPlngvsfProcCngListEditStatus)
                                        '@未編集
                                        Case CMstrStateNotEdit
                                            cmdEdit.Enabled = True          '編集(可能)
                                            cmdReturn.Enabled = False       '差戻(不可)
                                            cmdApply.Enabled = False        '適用(不可)
                                        
                                        '@編集中
                                        Case CMstrStateEditing
                                            cmdEdit.Enabled = True          '編集(可能)
                                            cmdReturn.Enabled = False       '差戻(不可)
                                            cmdApply.Enabled = False        '適用(不可)
                                        
                                        '編集済
                                        Case CMstrStateEditEnd
                                            cmdEdit.Enabled = False         '編集(不可)
                                            cmdReturn.Enabled = True        '差戻(可能)
                                            cmdApply.Enabled = True         '適用(可能)
                                        
                                        '@適用済
                                        Case CMstrStateApplyEnd
                                            cmdEdit.Enabled = False         '編集(不可)
											'kkw 組立試作流動表電子化
                                            cmdReturn.Enabled = True       '差戻(可能)
                                            cmdApply.Enabled = False        '適用(不可)
                                    End Select
                                    
                                    '@削除ﾎﾞﾀﾝは同一ﾕｰｻﾞｰのみ可能とする
                                    If .GetData(.Row, CPlngvsfProcCngListEmpID) = txtUserID.Text Then
                                        cmdDelete.Enabled = True        '編集情報削除
                                    End If
                            End Select
                        End If
                    End With
                End If
            End If
                
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN01X0_CmdInit"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
                
        End Try
    End Sub

    '関数名：prvfrmxxEN01X0_Disp
    '機　能：ﾌｫｰﾑにﾃﾞｰﾀを表示する
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:25:43 N.Kasai
    '更新日：2009/12/02 (Wed) 22:26:18 H.Hayashi
    '備　考：
    '　　　：2006/10/19 (Thu) 08:53:17 M.Miura      保/停区分の結合表示(案件№01565)
    '　　　：2007/04/05 (Thu) 15:40:58 N.Kasai      流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ(№01831)
    '　　　：2009/03/05 (Thu) 14:13:47 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。(案件№03402)
    '　　　：2009/12/02 (Wed) 22:26:18 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    Private Sub prvfrmxxEN01X0_Disp(ByRef ltypProcChgList As ProcChgList)
        
        Dim llngCnt     As Integer              'ｶｳﾝﾀ
        Dim newStyle    As CellStyle            'NSYS スタイル
        Dim cellRange   As CellRange            'NSYS セルレンジ
        Dim newStyleB   As CellStyle            'NSYS 前景色青
        Dim newStyleR   As CellStyle            'NSYS 背景色赤

        Try
            'NSYS 不要イベント発生抑止解除
            RemoveHandler vsfProcCngList.BeforeRowColChange, AddressOf vsfProcCngList_BeforeRowColChange
            RemoveHandler vsfProcCngList.EnterCell,AddressOf vsfProcCngList_EnterCell

            '@ｺﾒﾝﾄｸﾘｱ
            txtComments.Text = vbNullString
            
            '@工順変更中ﾛｯﾄﾘｽﾄの表示
            With ltypProcChgList
                
                '@--------------------
                '@ 取得件数が0件の場合
                '@--------------------
                If .lngProcChgCnt = 0 Then
                    '@ｸﾞﾘｯﾄﾞの初期化
                    vsfProcCngList.Clear(ClearFlags.UserData)
                    vsfProcCngList.Rows.Count = vsfProcCngList.Rows.Fixed
                    '@列幅の自動調整
                    vsfProcCngList.AutoSizeCols(CPlngvsfProcCngListNo, vsfProcCngList.Cols.Count - 1, 6)
                    '@情報取得日時表示
                    lblGetInfoDate.Text = Format$(Now, CPstrDateFormat)
                    '@該当件数ﾗﾍﾞﾙに取得件数を表示
                    lblListCnt.Text = Format$(ltypProcChgList.lngProcChgCnt, CPstrDateFormatKanma)
                            
                    '@ｸﾞﾘｯﾄﾞ使用不可
                    vsfProcCngList.Enabled = False
                    
                    Exit Sub
                End If
                
                '@--------------------
                '@ 取得件数が0件以外の場合
                '@--------------------
                
                '@ｸﾞﾘｯﾄﾞの初期化
                vsfProcCngList.Clear(ClearFlags.UserData)
                
                '@行数初期化
                vsfProcCngList.Rows.Count = vsfProcCngList.Rows.Fixed
                
                '@行数の設定
                vsfProcCngList.Rows.Count = .lngProcChgCnt + 1
                        
                '@描画ﾛｯｸ
                vsfProcCngList.Redraw = False
                
                '@ﾀｲﾄﾙ設定
                For llngCnt = 1 To .lngProcChgCnt
                    
                    With .typProcChg(llngCnt -1)
                        
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListNo, llngCnt)                       '№
                        
                        Select Case .strLcDirection
                            Case "L"
                                newStyle = vsfProcCngList.Styles.Add("CustomStyle_BackColor_CPlngLColor" + llngCnt.ToString)
                                newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngLColor))
                                cellRange = vsfProcCngList.GetCellRange(llngCnt, CPlngvsfProcCngListNo, llngCnt, vsfProcCngList.Cols.Count - 1)
                                cellRange.Style = newStyle
                            Case "R"
                                newStyle = vsfProcCngList.Styles.Add("CustomStyle_BackColor_CPlngRColor" + llngCnt.ToString)
                                newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngRColor))
                                cellRange = vsfProcCngList.GetCellRange(llngCnt, CPlngvsfProcCngListNo, llngCnt, vsfProcCngList.Cols.Count - 1)
                                cellRange.Style = newStyle
                            Case Else
                                newStyle = vsfProcCngList.Styles.Add("CustomStyle_BackColor_White" + llngCnt.ToString)
                                newStyle.BackColor = Color.White
                                cellRange = vsfProcCngList.GetCellRange(llngCnt, CPlngvsfProcCngListNo, llngCnt, vsfProcCngList.Cols.Count - 1)
                                cellRange.Style = newStyle
                        End Select
                        
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListLcDirection, .strLcDirection)
                        
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListKb, vbNullString)
                        If .strLotHoldFlag = "1" Then
                            '@"保"表示
                            vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListKb, _
                            pubstrColKbn_Set(vsfProcCngList.GetData(llngCnt, CPlngvsfProcCngListKb), CMstrHo))    '「保」表示
                            newStyle = vsfProcCngList.Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" + llngCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngHoldLotColor))
                            cellRange = vsfProcCngList.GetCellRange(llngCnt, CPlngvsfProcCngListNo, llngCnt, vsfProcCngList.Cols.Count - 1)
                            cellRange.Style = newStyle
                        End If
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListLotHold, .strLotHoldFlag)
                        
                        If .strLotStopFlag = "1" Then
                            '@"停"表示
                            vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListKb, _
                            pubstrColKbn_Set(vsfProcCngList.GetData(llngCnt, CPlngvsfProcCngListKb), CMstrTei))   '「停」表示
                            newStyle = vsfProcCngList.Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" + llngCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngHoldLotColor))
                            cellRange = vsfProcCngList.GetCellRange(llngCnt, CPlngvsfProcCngListNo, llngCnt, vsfProcCngList.Cols.Count - 1)
                            cellRange.Style = newStyle
                        End If
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListLotStop, .strLotStopFlag)
                        
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListLotID, .strLotID)                  'ﾛｯﾄID
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListOpID, .strOpID)                    '大工程
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListStepID, .strStepID)                '小工程
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListLotStatus, .strCurrentStatusName)  'ﾛｯﾄ状態
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListLotPos, .strLotPos)                'ﾛｯﾄ位置
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListEditStatus, .strEditStatus)        '編集状態
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListEmpName, .strEmpName)              '編集者
                        'NSYS 最終更新日時 日付変換可能か判断後にﾌｫｰﾏｯﾄ
                        If IsDate(.strEditTime) = True Then                                                   '最終更新日時
                            vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListEditTime, _
                                                                Format$(CDate(.strEditTime), CPstrDateTimeYMDHM))               
                        Else
                            vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListEditTime,.strEditTime)
                        End If
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListEmpID, .strEmpID)                  '編集者
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListProcName, .strUserPrcName)         'ﾕｰｻﾞｰﾌﾟﾛｾｽ名
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListPdID, .strPdId)                    '機種
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListCarrierID, .strCarrierId)          'ｷｬﾘｱID
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListComments, .strComments)            'ｺﾒﾝﾄ
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListHistoryFlag, vbNullString)         '変更履歴読込ﾌﾗｸﾞ
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListHistory, vbNullString)             '変更履歴
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListKindFlag, .strKindFlag)            '種別
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListFlowClass, .strFlowClass)          '流動区分
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListReworkFlag, .strReworkFlag)        'ﾘﾜｰｸﾌﾗｸﾞ(0:なし、1:ﾘﾜｰｸ、2:追加)
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListProcFlag, .strProcFlag)            'ﾛｯﾄ種別(0:通常、1:特殊)
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListWfCarryFlag, .strWfCarryFlag)      'WF移載中ﾌﾗｸﾞ(0:なし、1:移載中)
                        
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListProhibitedFlag, .strVerUpProhibitedFlag)   'VerUp禁止(0:可、1:不可)
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListProhibitedEmp, .strProhibitedEmpName)      '禁止設定者
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListProhibitedDept, .strProhibitedDeptName)    '禁止設定者部署
                        vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListLotLastUpdate, .strLotLastUpdate)          '最終更新日時(lot_status)
                        
                        '@ﾌﾗｸﾞ判定(ﾘﾜｰｸ/追加)
                        Select Case .strReworkFlag
                            Case CMstrReworkFlgOn
                                '@"リ"表示
                                vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListKb, _
                                pubstrColKbn_Set(vsfProcCngList.GetData(llngCnt, CPlngvsfProcCngListKb), CMstrRi))      '「停」表示
                            Case CMstrLotReworkFlgOn2
                                '@"追"表示
                                vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListKb, _
                                pubstrColKbn_Set(vsfProcCngList.GetData(llngCnt, CPlngvsfProcCngListKb), CMstrTsui))    '「停」表示
                        End Select
                        
                        '@WF移載中の場合
                        If .strWfCarryFlag = "1" Then
                            '@"移"表示
                            vsfProcCngList.SetData(llngCnt, CPlngvsfProcCngListKb, _
                            pubstrColKbn_Set(vsfProcCngList.GetData(llngCnt, CPlngvsfProcCngListKb), CMstrIsai))    '「停」表示
                        End If
                        
                        '@-----------------------------------------------
                        '@ ﾌｫﾝﾄ色の設定(組立限定機能)
                        '@　①ﾁｯﾌﾟ品LOT：青色
                        '@-----------------------------------------------
                        '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"か
                        If pstrSBID = CPstrSBID2A0 And _
                            .strSbArea = CPstrProductChip Then
                            
                            '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
                            '@文字色を青色に変更
                            newStyleB = vsfProcCngList.Styles.Add("CustomStyle_ForeColor_vbBlue" + llngCnt.ToString)
                            newStyleB.ForeColor = Color.Blue
                            newStyleB.BackColor = newStyle.BackColor
                            cellRange = vsfProcCngList.GetCellRange(llngCnt, CPlngvsfProcCngListNo, _
                                                llngCnt, CPlngvsfProcCngListLotLastUpdate)
                            cellRange.Style = newStyleB
                            newStyle = newStyleB
                        End If
                        
        '@↓2017/07/20 (Thu) 12:54:34 Y.Yoneyama **************************************************
                        '工順変更回数がある場合
                        If CLng(.strFlowChangeCount) > 0 Then
                            newStyleR = vsfProcCngList.Styles.Add("CustomStyle_BackColor_CPlngVbColorRed" + llngCnt.ToString)
                            newStyleR.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngVbColorRed))
                            newStyleR.ForeColor = newStyle.ForeColor
                            cellRange = vsfProcCngList.GetCellRange(llngCnt, CPlngvsfProcCngListNo, llngCnt, CPlngvsfProcCngListNo)
                            cellRange.Style = newStyleR
                        Else
                        
                        End If
        '@↑2017/07/20 (Thu) 12:54:34 Y.Yoneyama **************************************************
                        
                        '@高さ設定
                        vsfProcCngList.Rows(llngCnt).Height = CMlngRHeight
                    End With
                Next llngCnt
                
                '@列幅の自動調整
                vsfProcCngList.AutoSizeCols(CPlngvsfProcCngListNo, vsfProcCngList.Cols.Count - 1, 6)
                
                '@再描画
                vsfProcCngList.Redraw = True
            End With
            
            
            '@ﾕｰｻﾞによりｿｰﾄされている場合
            If mtypChgSort.lngCnt > 0 Then
                '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                For llngCnt = 0 To mtypChgSort.lngCnt -1
                    '@該当行をｿｰﾄ
                    vsfProcCngList.Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                Next llngCnt
            End If
            
            'NSYS 不要イベント発生抑止解除
            AddHandler vsfProcCngList.BeforeRowColChange, AddressOf vsfProcCngList_BeforeRowColChange
            AddHandler vsfProcCngList.EnterCell,AddressOf vsfProcCngList_EnterCell

            '@ｿｰﾄ検索用ｷｰ(№)がある場合
            If mtypChgSort.strKey <> vbNullString Then
                Dim blnIsSetRowNo As Boolean = False
                For llngCnt = vsfProcCngList.Rows.Fixed To vsfProcCngList.Rows.Count - 1
                    '@№が同じ場合
                    If vsfProcCngList.GetData(llngCnt, CPlngvsfProcCngListLotID) = mtypChgSort.strKey Then
                        vsfProcCngList.Row = llngCnt
                        '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                        Call pubVsfBeforeSort(vsfProcCngList, CPlngvsfProcCngListLotID)
                        
                        '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                        Call pubVsfAfterSort(vsfProcCngList, CPlngvsfProcCngListLotID)
                        
                        'NSYS RowNo.セット済み
                        blnIsSetRowNo = True

                        Exit For
                    End If
                Next llngCnt

                'NSYS ｿｰﾄｷｰ一致するものが無い場合は行選択しない
                If blnIsSetRowNo = False Then
                    vsfProcCngList.Row = CMlngTRow
                End If

            Else
                vsfProcCngList.Row = CMlngTRow           'ｶﾚﾝﾄ行の移動
                vsfProcCngList.TopRow = CMlngTRow        '行
            End If
            
            '@情報取得日時表示
            lblGetInfoDate.Text = Format$(Now, CPstrDateFormat)

            '@該当件数ﾗﾍﾞﾙに取得件数を表示
            lblListCnt.Text = Format$(ltypProcChgList.lngProcChgCnt, CPstrDateFormatKanma)
            
            '@ｸﾞﾘｯﾄﾞ使用可
            vsfProcCngList.Enabled = True

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN01X0_Disp"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvNo_Set
    '機　能：Noを振りなおす
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:28:04 N.Kasai
    '更新日：2006/05/12 (Fri) 12:28:04
    '備　考：
    Private Sub prvNo_Set()
        
        Dim llngRow As Integer 'ｸﾞﾘｯﾄの行
        
        Try

            With vsfProcCngList
                '@№を表示する
                For llngRow = 1 To .Rows.Count - 1
                    .SetData(llngRow, CPlngvsfProcCngListNo, llngRow)
                Next
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvNo_Set"                  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLotEventHistory_Set
    '機　能：ﾛｯﾄ工順変更履歴の設定
    '引　数：ltypLotEventList：ﾛｯﾄｲﾍﾞﾝﾄ履歴構造体
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 12:28:51 N.Kasai
    '更新日：2006/05/12 (Fri) 12:28:51
    '備　考：
    Private Sub prvLotEventHistory_Set(ByRef ltypProcEventList As ProcEventList)

        Dim llngCnt             As Integer          'ｶｳﾝﾀ
        Dim lstrHistory         As String           'ﾛｯﾄ履歴内容
        Dim tmpStrEntryTIme     As String           'NSYS 日付変換用

        Try
            
            With ltypProcEventList
                '@ﾛｯﾄｲﾍﾞﾝﾄ履歴格納
                lstrHistory = vbNullString
                '@最新履歴から格納する
                For llngCnt = .lngProcEventCnt -1 To 0 Step -1
                    With .typProcEvent(llngCnt)

                        'NSYS strEntryTieの日付変換
                        If IsDate(.strEntryTime) = True Then
                            tmpStrEntryTIme = Format$(CDate(.strEntryTime), CMstrHistoryDeteFormat)
                        Else
                            tmpStrEntryTIme = .strEntryTime
                        End If

                        '@？回目を設定
                        lstrHistory = lstrHistory _
                                    & CMstrHistoryChgName _
                                    & Space(1) _
                                    & StrConv(CStr(llngCnt +1), vbNarrow) _
                                    & CMstrHistoryCntNo
                        
                        '@日時分&作業者名を設定
                        lstrHistory = lstrHistory _
                                    & tmpStrEntryTIme _
                                    & Space(1) _
                                    & .strEmpName _
                                    & Space(1) _
                                    & CMstrHistoryChgName _
                                    & vbCrLf
                        
                        '@履歴内容を設定
                        If .strComments <> vbNullString Then
                            lstrHistory = lstrHistory _
                                        & .strComments _
                                        & vbCrLf
                        End If
                    End With
                Next llngCnt
            End With
            
            '@ﾛｯﾄｲﾍﾞﾝﾄ履歴格納
            vsfProcCngList.SetData(vsfProcCngList.Row, CPlngvsfProcCngListHistory, lstrHistory)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvLotEventHistory_Set"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvUserProcessApply_Proc
    '機　能：ﾕｰｻﾞｰﾌﾟﾛｾｽ適用後処理
    '引　数：lstrUserProcessID：ﾕｰｻﾞｰﾌﾟﾛｾｽID
    '　　　：lstrUserProcessName：ﾕｰｻﾞｰﾌﾟﾛｾｽ名
    '　　　：llngSelectRow：選択行
    '戻り値：なし
    '作成日：2006/05/12 (Fri) 14:32:16 N.Kasai
    '更新日：2006/05/12 (Fri) 14:32:16
    '備　考：
    Private Sub prvUserProcessApply_Proc(ByVal lstrUserProcessID As String, _
                                         ByVal lstrUserProcessName As String, _
                                         ByVal llngSelectRow As Integer)

        Dim ltypProcChgList         As ProcChgList      '工順変更中ﾛｯﾄ工順構造体
        Dim lblnAns                 As Boolean          '結果格納
        Dim llngCnt                 As Integer          '汎用ﾙｰﾌﾟｶｳﾝﾀ
        
        Try
            
            '@工順変更中ﾛｯﾄ工順取得
            lblnAns = pubblnProcProcChgList_Sel(pstrSBID, CMstrprocprocchglistVer, ltypProcChgList)
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
                With ltypProcChgList
                    For llngCnt = 0 To .lngProcChgCnt -1
                        '@適用したﾕｰｻﾞｰﾌﾟﾛｾｽを探す
                        If .typProcChg(llngCnt).strLotID = lstrUserProcessID _
                                    And .typProcChg(llngCnt).strUserPrcName = lstrUserProcessName Then
                            
                            '@適用したﾌﾟﾛｾｽ情報を上書きする
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListLotID, _
                                                                .typProcChg(llngCnt).strLotID)                   'ﾛｯﾄID
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListOpID, _
                                                                .typProcChg(llngCnt).strOpID)                    '大工程
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListStepID, _
                                                                .typProcChg(llngCnt).strStepID)                  '小工程
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListLotStatus, _
                                                                .typProcChg(llngCnt).strCurrentStatusName)       '状態
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListLotPos, _
                                                                .typProcChg(llngCnt).strLotPos)                  'ﾛｯﾄ位置
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListEditStatus, _
                                                                .typProcChg(llngCnt).strEditStatus)              '編集状態
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListEmpName, _
                                                                .typProcChg(llngCnt).strEmpName)                 '編集者
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListEditTime, _
                                                                .typProcChg(llngCnt).strEditTime)                '最終更新日時
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListEmpID, _
                                                                .typProcChg(llngCnt).strEmpID)                   '編集者ID
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListProcName, _
                                                                .typProcChg(llngCnt).strUserPrcName)             'ﾕｰｻﾞｰﾌﾟﾛｾｽ名
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListComments, _
                                                                .typProcChg(llngCnt).strComments)                'ｺﾒﾝﾄ
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListHistoryFlag, _
                                                                vbNullString)                                    '変更履歴読込ﾌﾗｸﾞ
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListHistory, _
                                                                vbNullString)                                    '変更履歴
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListKindFlag, _
                                                                .typProcChg(llngCnt).strKindFlag)                '種別
                            vsfProcCngList.SetData(llngSelectRow, CPlngvsfProcCngListFlowClass, _
                                                                .typProcChg(llngCnt).strFlowClass)               '流動区分
                        End If
                    Next llngCnt
                End With
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvUserProcessApply_Proc"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraLotList.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfProcCngList.BeforeDoubleClick

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
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles txtUserID.Enter,
                                                                       cmdSearch.Enter,
                                                                       vsfProcCngList.Enter,
                                                                       txtComments.Enter,
                                                                       cmdUp.Enter,
                                                                       cmdDown.Enter,
                                                                       cmdClose.Enter,
                                                                       cmdLotChoice.Enter,
                                                                       cmdEdit.Enter,
                                                                       cmdDelete.Enter,
                                                                       cmdReturn.Enter,
                                                                       cmdApply.Enter

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
