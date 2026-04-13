'ﾌｧｲﾙ名：xxEN01G0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット流動票　メインフォーム
'作成日：2004/10/18 (Mon) 11:42:41 H.Wajima
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2004-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01G0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01G0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01G0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01G0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01G0)
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
    '======================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2020/03/06 (Fri) 11:39:49 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion                         As String = "06.01"
    Private Const CMstrLocalVersion                         As String = "07.00"
    '@↑2020/03/06 (Fri) 11:39:49 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLot_DetailList_Ver                   As String = "04.00"             '流動票取得
    Private Const CMstrLot_EventComment_Ver                 As String = "01.00"             '履歴ｺﾒﾝﾄ取得
    Private Const CMstrlot_userecp_Ver                      As String = "01.00"             'ﾚｼﾋﾟ情報取得

    '@機能ID
    Private Const CMstrLocalMenuKey                         As String = CPstrKeyEN01G0      'ﾛｰｶﾙﾒﾆｭｰKey

    '@vsfLotDetailListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfLotDetailListColNo                As Integer = 0                  '№
    Private Const CMlngvsfLotDetailListColOPID              As Integer = 1                  '大工程ID
    Private Const CMlngvsfLotDetailListColStepID            As Integer = 2                  '小工程ID
    Private Const CMlngvsfLotDetailListColStartEndTime      As Integer = 3                  '作業開始日時/終了日時
    Private Const CMlngvsfLotDetailListColWPName            As Integer = 4                  '装置名
    Private Const CMlngvsfLotDetailListColPortID            As Integer = 5                  'ﾎﾟｰﾄ名
    Private Const CMlngvsfLotDetailListColRecipeID          As Integer = 6                  'ﾚｼﾋﾟID
    Private Const CMlngvsfLotDetailListColCollectionFlag    As Integer = 7                  'ﾃﾞｰﾀ収集有無
    Private Const CMlngvsfLotDetailListColCarrierID         As Integer = 8                  'ｷｬﾘｱID
    Private Const CMlngvsfLotDetailListColWFNum             As Integer = 9                  'WF枚数
    Private Const CMlngvsfLotDetailListColChipNum           As Integer = 10                 'ﾁｯﾌﾟ良品数
    Private Const CMlngvsfLotDetailListColEmpName           As Integer = 11                 '開始終了作業者名
    Private Const CMlngvsfLotDetailListColCommentFlag       As Integer = 12                 'ﾛｯﾄｺﾒﾝﾄ有無

    '@vsfLotDetailListの定数宣言(表示幅)
    Private Const CMlngvsfLotDetailListColWNo               As Integer = 50                 '№
    Private Const CMlngvsfLotDetailListColWOPID             As Integer = 133                '大工程ID
    Private Const CMlngvsfLotDetailListColWStepID           As Integer = 133                '小工程ID
    Private Const CMlngvsfLotDetailListColWStartEndTime     As Integer = 200                '作業開始/終了日時
    Private Const CMlngvsfLotDetailListColWWPName           As Integer = 133                '装置名
    Private Const CMlngvsfLotDetailListColWPortID           As Integer = 100                'ﾎﾟｰﾄ名
    Private Const CMlngvsfLotDetailListColWRecipeID         As Integer = 163                'ﾚｼﾋﾟID
    Private Const CMlngvsfLotDetailListColWCollectionFlag   As Integer = 133                'ﾃﾞｰﾀ収集有無
    Private Const CMlngvsfLotDetailListColWCarrierID        As Integer = 65                 'ｷｬﾘｱID
    Private Const CMlngvsfLotDetailListColWWFNum            As Integer = 133                'WF枚数
    Private Const CMlngvsfLotDetailListColWChipNum          As Integer = 133                'ﾁｯﾌﾟ良品数
    Private Const CMlngvsfLotDetailListColWEmpName          As Integer = 133                '作業者名
    Private Const CMlngvsfLotDetailListColWCommentFlag      As Integer = 133                'ﾛｯﾄｺﾒﾝﾄ有無

    '@vsfLotDetailListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfLotDetailListColTNo               As String = "№"                '№
    Private Const CMstrvsfLotDetailListColTOPID             As String = "大工程"            '大工程ID
    Private Const CMstrvsfLotDetailListColTStepID           As String = "小工程"            '小工程ID
    Private Const CMstrvsfLotDetailListColTStartEndTime     As String = "上段：作業開始日時" & vbCrLf & "下段：作業終了日時"    '作業開始終了日時
    Private Const CMstrvsfLotDetailListColTLastEventTime    As String = "最終処理日時"      '最終処理日時
    Private Const CMstrvsfLotDetailListColTLastEvent        As String = "最終処理"          '最終処理
    Private Const CMstrvsfLotDetailListColTWPName           As String = "装置名"            '装置名
    Private Const CMstrvsfLotDetailListColTPortID           As String = "ポート名"          'ﾎﾟｰﾄ名
    Private Const CMstrvsfLotDetailListColTRecipeID         As String = "レシピID"          'ﾚｼﾋﾟID
    Private Const CMstrvsfLotDetailListColTCollectionFlag   As String = "データ収集"        'ﾃﾞｰﾀ収集有無
    Private Const CMstrvsfLotDetailListColTCarrierID        As String = "ｷｬﾘｱID"            'ｷｬﾘｱID
    Private Const CMstrvsfLotDetailListColTWFNum            As String = "WF枚数"            'WF枚数
    Private Const CMstrvsfLotDetailListColTChipNum          As String = "チップ"            'ﾁｯﾌﾟ良品数
    Private Const CMstrvsfLotDetailListColTLotPriority      As String = "優"                '優先度
    Private Const CMstrvsfLotDetailListColTEmpName          As String = "上段：開始作業者名" & vbCrLf & "下段：終了作業者名"    '開始作業者名、終了作業者名
    Private Const CMstrvsfLotDetailListColTCommentFlag      As String = "コメント"          'ﾛｯﾄｺﾒﾝﾄ有無

    Private Const CMlngvsfLotDetailListCols                 As Integer = 13                 'ｶﾗﾑ数
    Private Const CMlngvsfLotDetailListTRow                 As Integer = 0                  'ﾀｲﾄﾙ行
    Private Const CMlngvsfLotDetailListTRows                As Integer = 1                  'ﾍｯﾀﾞ行数
    Private Const CMlngvsfLotDetailListHFontSize            As Integer = 12                 'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfLotDetailListHdHeight             As Integer = 36                 '行の高さ(ﾍｯﾀﾞｰのみ)
    Private Const CMlngvsfLotDetailListHeight               As Integer = 48                 '行の高さ
    Private Const CMlngvsfLotDetailListAll                  As Integer = -1                 '表全体
    Private Const CMlngvsfLotDetailListPageRow              As Integer = 8                  '1ﾍﾟｰｼﾞの行数
    Private Const CMlngvsfLotDetailListFrozenCols           As Integer = 3                  '固定列

    '@LotDetailListの検索工順、検索数定数
    Private Const CMstrLotDetailListNum0                    As String = "0"                 '0
    Private Const CMstrLotDetailListNum16                   As String = "16"                '16

    '@有効ｺﾝﾄﾛｰﾙ名
    Private Const CMstrActiveControlNameCarrierID           As String = "txtCarrierID"      'ｷｬﾘｱIDのｺﾝﾄﾛｰﾙ名
    Private Const CMstrActiveControlNameLotID               As String = "txtLotID"          'ﾛｯﾄIDのｺﾝﾄﾛｰﾙ名

    Private Const CMlngCurrentSeqColor                      As Integer = &HFFFF00           '現在工程の背景色

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mlngSortPlanThrowinDate                         As Short                        '投入予定日　0:昇順、1:降順
    Private mlngSortLotID                                   As Short                        'ﾛｯﾄID　　　 0:昇順、1:降順
    Private mlngSortFlowClass                               As Short                        '種別ID      0:昇順、1:降順
    Private mlngSortWfNum                                   As Short                        'WF枚数　　　0:昇順、1:降順
    Private mstrActiveControlName                           As String                       '有効ｺﾝﾄﾛｰﾙ(ｷｬﾘｱID or ﾛｯﾄID)
    Private mstrCurrentSeqNum                               As String                       '現在工順№

    '@退避情報
    Private mstrTaihiCarrierID                              As String                       'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrTaihiLotID                                  As String                       'ﾛｯﾄ情報取得時のﾛｯﾄID(ﾒｯｾｰｼﾞ成功取得時)

    Private mtypLotDetailList                               As LotDetailList                '流動票情報
    Private mblnLotDetailListGet                            As Boolean                      '流動票情報取得ﾌﾗｸﾞ
    Private mlngTopRow                                      As Integer                      '先頭行退避領域
    Private mblnMouseDownFlag                               As Boolean                      'ﾏｳｽﾀﾞｳﾝﾌﾗｸﾞ
    Private mblnTakeOverDispFlg                             As Boolean                      '引継ぎ情報表示済みﾌﾗｸﾞ
    Private buttonProcessing                                As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                        As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnAfterScrollFag                              As Boolean                      'NSYS スクロールフラグ
    Private mblnWindowClose                                 As Boolean                      'NSYS WindowCloseフラグ

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
        pubVsfMouseWheelManager_Set(vsfLotDetailList, cmdUP, cmdDown, cmdLeft, cmdRight)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ Load処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/18 (Mon) 11:44:26 H.Wajima
    '更新日：2004/10/18 (Mon) 11:44:26
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns     As Boolean

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01G0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                
                '@=======================
                '@　ﾌｫｰﾑ終了時処理
                '@=======================
                Call Form_QueryUnload(False, New FormClosingEventArgs(CloseReason.UserClosing,  False))
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If

            '@有効ｺﾝﾄﾛｰﾙ名のｸﾘｱ
            mstrActiveControlName = vbNullString
            
            '@画面初期化
            Call prvfrmxxEN01G0_Init()

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            'NSYS スクロールフラグ
            mblnAfterScrollFag = False

            '@引継ぎ情報表示済みﾌﾗｸﾞにFalseを設定する
            mblnTakeOverDispFlg = False

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
    '機　能：ﾌｫｰﾑ Activate処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/28 (Thu) 09:43:04 H.Wajima
    '更新日：2004/10/28 (Thu) 09:43:04
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@引継ぎ情報表示済みﾌﾗｸﾞの判定
            '@FormLoad後、最初の1回しか処理しない
            If mblnTakeOverDispFlg = True Then
            '@引継ぎ情報が表示済みの場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
            '@引継ぎ情報表示済みﾌﾗｸﾞにTrueを設定する
            mblnTakeOverDispFlg = True

            '@引数のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合

                '@ｷｬﾘｱIDの初期値を設定する
                txtCarrierID.Text = ptypCommonInfo.strCarrierId

                '@ｷｬﾘｱ情報を取得する
                RemoveHandler txtCarrierID.Validating,AddressOf txtCarrierID_Validate
                Call txtCarrierID_Validate(txtCarrierID,New CancelEventArgs(False))
                AddHandler txtCarrierID.Validating,AddressOf txtCarrierID_Validate
                
                With vsfLotDetailList
                    '@流動票一覧が有効の場合
                    If .Enabled = True Then
                        '@流動票一覧にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfLotDetailList)
                    End If
                End With
                
                '@最新取得ﾎﾞﾀﾝを有効にする
                cmdLotSearch.Enabled = True
            Else
                '@ｷｬﾘｱID初期化
                ptypCommonInfo.strCarrierId = vbNullString
            End If

            'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
            'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
            Dim lfuncActivate As Action = Sub()
                Me.Activate()
            End Sub
            Me.BeginInvoke(lfuncActivate)


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

    '関数名：cmdClose_Click
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:42:55 M.Miura
    '更新日：2018/11/16 (Fri) 09:47:55 Y.Yoneyama
    '備　考：
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
    '      ：2018/11/16 (Fri) 09:47:55 Y.Yoneyama   防湿ALD対応
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim llngRet As Integer
        Dim ltypCommonInfo  As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@引継ぎ情報のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合
                
                '@装置別ﾛｯﾄ一覧から引き継いで起動された場合
                If pblnfrmxxEN0150Kbn = True Then
                    '@装置別ﾛｯﾄ一覧を起動する
                    Call pubMenuSelect_Proc(CPstrKeyEN0150)
                    
        '@↓2018/11/16 (Fri) 09:47:55 Y.Yoneyama **************************************************
                '@装置別ﾛｯﾄ(防湿ALD)一覧から引き継いで起動された場合
                ElseIf pblnfrmxxEN0151Kbn = True Then
                    '@装置別ﾛｯﾄ(防湿ALD)一覧を起動する
                    Call pubMenuSelect_Proc(CPstrKeyEN0151)
        '@↑2018/11/16 (Fri) 09:47:55 Y.Yoneyama **************************************************
                    
                Else
                    '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧から引き継いで起動された場合
                    If pblnfrmxxEN00J0Kbn = True Then
                        '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧を起動する
                        Call pubMenuSelect_Proc(CPstrKeyEN00J0)
                    Else
                        '@工程別ﾛｯﾄ一覧から引き継いで起動された場合
                        '@工程別ﾛｯﾄ一覧を起動する
                        Call pubMenuSelect_Proc(CPstrKeyEN0200)
                    End If
                End If
            Else
                '@空白の場合
                '@終了関数を実行する
                llngRet = publngEnd_Proc(CPstrKeyEN01G0, ltypCommonInfo)
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '　　　：UnloadMode：ﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 12:02:02 H.Wajima
    '更新日：2005/11/07 (Mon) 08:44:25 N.Kasai
    '備　考：2004/11/01 (Mon) 15:38:50 T.Kitagawa   閉じるﾎﾞﾀﾝ統合
    '　　　：2005/11/07 (Mon) 08:44:25 N.Kasai      構造体初期化修正
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
                        
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@流動表情報構造体のｸﾘｱ
            If mtypLotDetailList.typDetailList Is Nothing Then
                mtypLotDetailList.typDetailList = New List(Of LotDetailListAry)
            Else
                mtypLotDetailList.typDetailList.Clear()
            End If
        '@↓2005/11/07 (Mon) 08:44:07 N.Kasai **************************************************
        '    '@装置ﾚｼﾋﾟﾘｽﾄ構造体のｸﾘｱ
        '    Erase ptypWPRecipeList.typWPList()
            
            '@装置ﾚｼﾋﾟ画面渡し構造体のｸﾘｱ
            If ptypUseRecpList.typUseRecpAns.typUseWpList Is Nothing Then
                ptypUseRecpList.typUseRecpAns.typUseWpList = New List(Of UseWpList)
            Else
                ptypUseRecpList.typUseRecpAns.typUseWpList.Clear()
            End If
        '@↑2005/11/07 (Mon) 08:44:07 N.Kasai **************************************************
            
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

    '関数名：cmdUp_Click
    '機　能：▲ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 13:46:29 H.Wajima
    '更新日：2004/10/21 (Thu) 13:46:29
    '備　考：
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp.Click
        
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnRet             As Boolean              '戻り値

        Try
            'NSYS スクロールフラグ
            mblnAfterScrollFag = True

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdUp_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfLotDetailList, cmdUP, cmdDown)

            '@流動票最新取得処理を実行する
            lblnRet = prvblnLotDetailListGet_Proc(txtCarrierID.Text, _
                                                    txtLotID.Text, _
                                                    CStr(vsfLotDetailList.TopRow), _
                                                    CMstrLotDetailListNum16, _
                                                    CMstrLotDetailListNum16)
            
            '@戻り値の判定
            If lblnRet = False Then
                '@異常終了の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            Else
                '@正常終了の場合
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            End If

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
    '機　能：▼ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 13:46:52 H.Wajima
    '更新日：2004/10/21 (Thu) 13:46:52
    '備　考：
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Click

        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnRet             As Boolean              '戻り値

        Try
            'NSYS スクロールフラグ
            mblnAfterScrollFag = True

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdDown_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfLotDetailList, cmdUP, cmdDown)
            
            '@流動票最新取得処理を実行する
            lblnRet = prvblnLotDetailListGet_Proc(txtCarrierID.Text, _
                                                    txtLotID.Text, _
                                                    CStr(vsfLotDetailList.TopRow), _
                                                    CMstrLotDetailListNum16, _
                                                    CMstrLotDetailListNum16)
            
            '@戻り値の判定
            If lblnRet = False Then
                '@異常終了の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            Else
                '@正常終了の場合
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            End If
            
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

    '関数名：Form_KeyDown
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：
    '作成日：2004/10/21 (Thu) 13:37:56 H.Wajima
    '更新日：2007/07/06 (Fri) 13:07:29 N.Kasai
    '備　考：
    '　　　：2005/05/06 (Fri) 14:47:48 S.Deguchi    Enterｷｰ押下時の処理を見直し
    '　　　：2007/07/06 (Fri) 13:07:29 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnRet             As Boolean              '戻り値

        Try
            mblnAfterScrollFag = False

            If vsfLotDetailList.Rows.Count > 1 Then
                'NSYS スクロールフラグ
                mblnAfterScrollFag = True
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "Form_KeyDown"

            vsfLotDetailList.Redraw = False

            '@ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfLotDetailList, cmdUP, cmdDown)
            
        '@↓2007/07/06 (Fri) 13:07:20 N.Kasai **************************************************
        '    '@ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ)
        '    Call prvvsfSideKeyDown_Proc(KeyCode, ActiveControl.Name, vsfLotDetailList, cmdLeft, cmdRight)
            '@ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ)
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfLotDetailList, cmdLeft, cmdRight)
            '@↑2007/07/06 (Fri) 13:07:20 N.Kasai **************************************************

            vsfLotDetailList.Redraw = True

            '@ｷｰｺｰﾄﾞの判定
            Select Case e.KeyCode
                Case Keys.Return
                '@Enterｷｰの場合
                    '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙによる処理分岐
                    Select Case ActiveControl.Name
                        Case txtCarrierID.Name
                        '@ｷｬﾘｱIDの場合
                            RemoveHandler txtCarrierID.Validating,AddressOf txtCarrierID_Validate
                            Call txtCarrierID_Validate(txtCarrierID,New CancelEventArgs(False))
                            AddHandler txtCarrierID.Validating,AddressOf txtCarrierID_Validate
                            e.Handled = True
                            
                        Case txtLotID.Name
                        '@ﾛｯﾄIDの場合
                            RemoveHandler txtLotID.Validating,AddressOf txtLotID_Validate
                            Call txtLotID_Validate(txtCarrierID,New CancelEventArgs(False))
                            AddHandler txtLotID.Validating,AddressOf txtLotID_Validate
                            e.Handled = True
                        
                        Case Else
                        '@その他
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
                    
                Case Keys.PageDown,Keys.PageUp
                '@PageDown、PageUpが押された可能性がある場合
                    With vsfLotDetailList
                        If vsfLotDetailList.Rows.Count <= 1 Then
                            Exit Sub
                        End If
                        Select Case .TopRow
                            Case Is > mlngTopRow
                                '@下にｽｸﾛｰﾙされている場合
                                '@ﾚｽﾎﾟﾝｽ取得開始
                                Call pubResponseStart(lstrFormName, lstrEventName)
                                
                                '@流動票最新取得処理を実行する
                                lblnRet = prvblnLotDetailListGet_Proc(vbNullString, _
                                                                        txtLotID.Text, _
                                                                        CStr(vsfLotDetailList.TopRow), _
                                                                        CMstrLotDetailListNum16, _
                                                                        CMstrLotDetailListNum16)
                                
                                '@戻り値の判定
                                If lblnRet = False Then
                                    '@異常終了の場合
                                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                    Call pubResponseCancel(lstrFormName, lstrEventName)
                                Else
                                    '@正常終了の場合
                                    '@ﾚｽﾎﾟﾝｽ取得終了
                                    Call publngResponseEnd(lstrFormName, lstrEventName)
                                End If
                                
                            Case Is < mlngTopRow
                                '@上にｽｸﾛｰﾙされている場合
                                '@ﾚｽﾎﾟﾝｽ取得開始
                                Call pubResponseStart(lstrFormName, lstrEventName)
                                
                                '@流動票最新取得処理を実行する
                                lblnRet = prvblnLotDetailListGet_Proc(vbNullString, _
                                                                        txtLotID.Text, _
                                                                        CStr(vsfLotDetailList.TopRow), _
                                                                        CMstrLotDetailListNum16, _
                                                                        CMstrLotDetailListNum16)
                                
                                '@戻り値の判定
                                If lblnRet = False Then
                                    '@異常終了の場合
                                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                    Call pubResponseCancel(lstrFormName, lstrEventName)
                                Else
                                    '@正常終了の場合
                                    '@ﾚｽﾎﾟﾝｽ取得終了
                                    Call publngResponseEnd(lstrFormName, lstrEventName)
                                End If
                        End Select
                    End With
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

    '関数名：cmdLotSearch_Click
    '機　能：最新取得ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 13:48:25 H.Wajima
    '更新日：2004/10/21 (Thu) 13:48:25
    '備　考：
    Private Sub cmdLotSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotSearch.Click
        
        Dim lstrCarrierID           As String           'ｷｬﾘｱID
        Dim lstrLotID               As String           'ﾛｯﾄID
        Dim lstrStartSeqNum         As String           '検索開始工順
        Dim lblnRet                 As Boolean          '戻り値
        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

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
            lstrFormName = Me.Name
            lstrEventName = "cmdLotSearch_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｷｬﾘｱIDかﾛｯﾄIDのどちらかに値が設定されているか判定
            Select Case True
                Case txtCarrierID.Text <> vbNullString And txtLotID.Text = vbNullString
                    '@ｷｬﾘｱIDだけ値が入力されている場合
                    '@有効ｺﾝﾄﾛｰﾙ名の設定
                    mstrActiveControlName = CMstrActiveControlNameCarrierID
                    '@ｷｬﾘｱIDの設定
                    lstrCarrierID = txtCarrierID.Text
                    '@ﾛｯﾄIDの設定
                    lstrLotID = txtLotID.Text
                    
                Case txtCarrierID.Text = vbNullString And txtLotID.Text <> vbNullString
                    '@ﾛｯﾄIDだけ入力されている場合
                    '@有効ｺﾝﾄﾛｰﾙ名の設定
                    mstrActiveControlName = CMstrActiveControlNameLotID
                    '@ｷｬﾘｱIDの設定
                    lstrCarrierID = txtCarrierID.Text
                    '@ﾛｯﾄIDの設定
                    lstrLotID = txtLotID.Text
                    
                Case Else
                    '@上記以外の場合(ｷｬﾘｱIDを捨ててﾛｯﾄIDを信用する)
                    '@有効ｺﾝﾄﾛｰﾙ名の設定
                    mstrActiveControlName = CMstrActiveControlNameLotID
                    '@ｷｬﾘｱIDの設定
                    lstrCarrierID = vbNullString
                    '@ﾛｯﾄIDの設定
                    lstrLotID = txtLotID.Text
            End Select
            
            With vsfLotDetailList
                '@明細行数の判定
                If .Rows.Count = .Rows.Fixed Then
                    '@明細0件の場合
                    '@検索開始工順に0を設定する
                    lstrStartSeqNum = 0
                Else
                    '@明細が1件以上ある場合
                    '@先頭行の工順を判定する
                    If IsNumeric(.GetData(.TopRow, CMlngvsfLotDetailListColNo)) = True Then
                        '@先頭行の工順が数値の場合
                        '@検索開始工順の設定
                        lstrStartSeqNum = .GetData(.TopRow, CMlngvsfLotDetailListColNo)
                    Else
                        '@先頭行の工順が数値以外の場合
                        '@検索開始工順に0を設定する
                        lstrStartSeqNum = 0
                    End If
                End If
            End With
            
            '@流動票最新取得処理を実行する
            lblnRet = prvblnLotDetailListGet_Proc(lstrCarrierID, _
                                                  lstrLotID, _
                                                  lstrStartSeqNum, _
                                                  CMstrLotDetailListNum16, _
                                                  CMstrLotDetailListNum16)
            
            '@戻り値の判定
            If lblnRet = False Then
            '@異常終了の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            Else
            '@正常終了の場合
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@流動票情報取得ﾌﾗｸﾞにFlaseを設定する
                mblnLotDetailListGet = False
                
                '@流動票一覧にﾌｫｰｶｽｾｯﾄ
                With vsfLotDetailList
                    If .Enabled = True Then
                        '@流動票一覧が有効な場合
                        Call pubSetFocus(vsfLotDetailList)
                    End If
                End With
            End If

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの有効無効判定
            Call prvcmdEnabled_Proc()
            
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

    '関数名：cmdLeft_Click
    '機　能：≪ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 14:14:10 H.Wajima
    '更新日：2007/07/06 (Fri) 13:06:20 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 13:06:20 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub cmdLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click

        Try
            'NSYS スクロールフラグ
            mblnAfterScrollFag = True

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2007/07/06 (Fri) 13:06:18 N.Kasai **************************************************
        '    '@左ｽｸﾛｰﾙ処理
        '    Call prvcmdLeft_Proc(vsfLotDetailList, cmdLeft, cmdRight)
            '@左ｽｸﾛｰﾙﾎﾞﾀﾝ制御
            Call pubVsfCmdLeft(vsfLotDetailList, cmdLeft, cmdRight)
        '@↑2007/07/06 (Fri) 13:06:18 N.Kasai **************************************************

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
    '機　能：≫ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 14:15:05 H.Wajima
    '更新日：2007/07/06 (Fri) 13:05:00 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 13:05:00 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub cmdRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click

        Try
            'NSYS スクロールフラグ
            mblnAfterScrollFag = True

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2007/07/06 (Fri) 13:04:57 N.Kasai **************************************************
        '    '@右ｽｸﾛｰﾙ処理
        '    Call prvcmdRight_Proc(vsfLotDetailList, cmdLeft, cmdRight)
            '@右ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            Call pubVsfCmdRight(vsfLotDetailList, cmdLeft, cmdRight)
        '@↑2007/07/06 (Fri) 13:04:57 N.Kasai **************************************************

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

    '関数名：cmdDown_GotFocus
    '機　能：▼ﾎﾞﾀﾝ GotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/26 (Tue) 09:19:56 H.Wajima
    '更新日：2004/10/26 (Tue) 09:19:56
    '備　考：
    Private Sub cmdDown_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Enter

        Try
            
            '@流動票情報取得ﾌﾗｸﾞの判定
            If mblnLotDetailListGet = True Then
            '@流動票の取得後にﾌｫｰｶｽが当たった場合(ﾛｯﾄIDのValidate処理後)
                '@流動票取得ﾌﾗｸﾞにFalseを設定する
                mblnLotDetailListGet = False
                
                '@流動票一覧にﾌｫｰｶｽをｾｯﾄする
                Call pubSetFocus(vsfLotDetailList)
                
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotComment_Click
    '機　能：ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ ｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 18:03:28 H.Wajima
    '更新日：2005/11/09 (Wed) 14:06:15 N.Kasai
    '備　考：
    '　　　：2005/11/09 (Wed) 14:06:15 N.Kasai      ﾌｫｰｶｽの制御&ﾛｯﾄｺﾒﾝﾄﾍｯﾀﾞ追加
    Private Sub cmdLotComment_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotComment.Click
        
        Dim lblnRet                 As Boolean          '戻り値
        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt                 As Integer          '汎用ｶｳﾝﾀ
        Dim lstrLotID               As String           'ﾛｯﾄID
        Dim lstrCarrierID           As String           'ｷｬﾘｱID
        Dim lstrSeqNum              As String           '工順№
        Dim lstrEntryTime           As String           'ｲﾍﾞﾝﾄ日時
        Dim lstrComments            As String           '履歴ｺﾒﾝﾄ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdLotComment_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            With vsfLotDetailList
                '@ｸﾞﾘｯﾄﾞ選択行の判定
                Select Case .Row
                    Case CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListAll
                    '@ｸﾞﾘｯﾄﾞが未選択か、ﾀｲﾄﾙが選択されている場合
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        Exit Sub
                    Case Else
                    '@選択行の工順№取得
                        lstrSeqNum = .GetData(.Row, CMlngvsfLotDetailListColNo)
                        '@数値ﾁｪｯｸ
                        If Not IsNumeric(lstrSeqNum) Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)
                            
                            Exit Sub
                        End If
                End Select
            End With
                
            With mtypLotDetailList
                '@ﾛｯﾄID
                lstrLotID = txtLotID.Text
                
                '@流動票情報構造体のﾙｰﾌﾟ
                For llngCnt = 0 To .lngDetailListCount - 1
                    With .typDetailList(llngCnt)
                        '@工順№が一致した場合
                        If .strSeqNum = lstrSeqNum Then
                            '@ｺﾒﾝﾄ日時を取得する
                            lstrEntryTime = .strCommentTime
                            
                            Exit For
                        End If
                    End With
                Next llngCnt
            End With

            '@ﾛｯﾄｺﾒﾝﾄを取得する
            lblnRet = pubblnLotEventComment_Sel(CMstrLot_EventComment_Ver, _
                                                pstrSBID, lstrLotID, _
                                                lstrSeqNum, _
                                                lstrEntryTime, _
                                                lstrComments)
            '@戻り値の判定
            If lblnRet = True Then
            '@正常終了の場合
                '@ﾛｯﾄｺﾒﾝﾄ表示ﾌｫｰﾑをﾛｰﾄﾞする
                frmxxEN01G2.Instance = New frmxxEN01G2()
                
        '@↓2005/11/10 (Thu) 15:19:50 N.Kasai **************************************************
                '@ｷｬﾘｱIDを取得
                With vsfLotDetailList
                    If .GetData(.Row, CMlngvsfLotDetailListColCarrierID) <> vbNullString Then                           'ｷｬﾘｱID
                        lstrCarrierID = .GetData(.Row, CMlngvsfLotDetailListColCarrierID)
                    Else
                        lstrCarrierID = txtCarrierID.Text
                    End If
                End With
                
                With frmxxEN01G2.Instance
                    '@ｷｬﾘｱID
                    .lblCarrierID.Text = lstrCarrierID
                    '@ﾛｯﾄID
                    .lblLotID.Text = lstrLotID
                    '@大工程
                    .lblOpID.Text = vsfLotDetailList.GetData(vsfLotDetailList.Row, CMlngvsfLotDetailListColOPID)        '大工程
                    '@小工程
                    .lblStepID.Text = vsfLotDetailList.GetData(vsfLotDetailList.Row, CMlngvsfLotDetailListColStepID)    '小工程
                    '@ﾛｯﾄｺﾒﾝﾄ
                    .txtLotComment.Text = lstrComments
                End With
        '@↑2005/11/10 (Thu) 15:19:50 N.Kasai **************************************************
                
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                '@ﾛｯﾄｺﾒﾝﾄ表示ﾌｫｰﾑを開く
                frmxxEN01G2.Instance.ShowDialog(Me)
                frmxxEN01G2.Instance = Nothing
                
        '@↓2005/11/09 (Wed) 14:06:11 N.Kasai **************************************************
        '        '@ﾀﾌﾞ遷移
        '        SendKeys CPstrSendKeysTab, True
                 '@ﾌｫｰｶｽをｸﾞﾘｯﾄﾞへ
                Call pubSetFocus(vsfLotDetailList)
        '@↑2005/11/09 (Wed) 14:06:11 N.Kasai **************************************************
                
            Else
            '@異常終了の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotComment_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Change
    '機　能：ｷｬﾘｱID Change処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 13:16:25 H.Wajima
    '更新日：2004/10/21 (Thu) 13:16:25
    '備　考：
    Private Sub txtCarrierID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID.Change

        Try
            
            '@有効ｺﾝﾄﾛｰﾙの判定
            If mstrActiveControlName <> CMstrActiveControlNameCarrierID Then
                Exit Sub
            End If
                
            '@ﾍｯﾀﾞ情報初期化
            Call prvHeaderInfoInit_Proc()

            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfLotDetailList_Init()
            
            '@空白の場合
            If txtCarrierID.Text <> vbNullString Then
                '@最新取得ﾎﾞﾀﾝを有効にする
                cmdLotSearch.Enabled = True
            End If
            
            '@ﾎﾞﾀﾝ非活性化
            cmdUP.Enabled = False               '▲ﾎﾞﾀﾝ
            cmdDown.Enabled = False             '▼ﾎﾞﾀﾝ
            cmdLeft.Enabled = False             '≪ﾎﾞﾀﾝ
            cmdRight.Enabled = False            '≫ﾎﾞﾀﾝ
            cmdLotComment.Enabled = False       'ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ
            cmdWPRecipeList.Enabled = False     '装置ﾚｼﾋﾟ表示ﾎﾞﾀﾝ

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_GotFocus
    '機　能：ｷｬﾘｱID GotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 13:42:16 H.Wajima
    '更新日：2004/10/21 (Thu) 13:42:16
    '備　考：
    Private Sub txtCarrierID_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID.Enter

        Try
            
            '@有効ｺﾝﾄﾛｰﾙ名の設定
            mstrActiveControlName = CMstrActiveControlNameCarrierID
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Validate
    '機　能：ｷｬﾘｱID Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 13:42:38 H.Wajima
    '更新日：2004/10/21 (Thu) 13:42:38
    '備　考：
    '　　　：2005/05/06 (Fri) 14:53:29 S.Deguchi    不具合№214の対応で処理見直し
    Private Sub txtCarrierID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierID.Validating
        
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnRet             As Boolean              '戻り値

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "txtCarrierID_Validate"
            
            '@退避ｷｬﾘｱIDの判定
            If txtCarrierID.Text = mstrTaihiCarrierID Then
            '@退避ｷｬﾘｱIDと表示中のｷｬﾘｱIDが同じ場合
                If ActiveControl.Name = txtCarrierID.Name Then
                    '@ﾌｫｰｶｽ処理
                    If vsfLotDetailList.Enabled = True Then
                        '@ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfLotDetailList)
                    Else
                        '@ﾛｯﾄIDへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtLotID)
                    End If
                End If
                '@処理を抜ける
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If txtCarrierID.Text = vbNullString Then
                '@有効ｺﾝﾄﾛｰﾙ名のｸﾘｱ
                mstrActiveControlName = vbNullString
                If ActiveControl.Name = txtCarrierID.Name Then
                    '@ﾌｫｰｶｽ処理
                    If vsfLotDetailList.Enabled = True Then
                        '@ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfLotDetailList)
                    Else
                        '@ﾛｯﾄIDへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtLotID)
                    End If
                End If
                '@処理を抜ける
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrierID.NowByte < txtCarrierID.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"ｷｬﾘｱIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@流動票最新取得処理を実行する
            lblnRet = prvblnLotDetailListGet_Proc(txtCarrierID.Text, _
                                                  vbNullString, _
                                                  CMstrLotDetailListNum0, _
                                                  CMstrLotDetailListNum16, _
                                                  CMstrLotDetailListNum16)
            '@戻り値の判定
            If lblnRet = False Then
            '@異常終了の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@ｷｬﾝｾﾙ
                e.Cancel = True
                
                '@流動票情報取得ﾌﾗｸﾞにTrueを設定する
                mblnLotDetailListGet = True
                
                Exit Sub
            Else
            '@正常終了の場合
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@流動票情報取得ﾌﾗｸﾞにFalseを設定する
                mblnLotDetailListGet = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Change
    '機　能：ﾛｯﾄID Change処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 13:52:12 H.Wajima
    '更新日：2004/10/21 (Thu) 13:52:12
    '備　考：
    Private Sub txtLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotID.Change

        Try
            
            '@有効ｺﾝﾄﾛｰﾙの判定
            If mstrActiveControlName <> CMstrActiveControlNameLotID Then
                Exit Sub
            End If
            
            '@ﾍｯﾀﾞ情報初期化
            Call prvHeaderInfoInit_Proc()
            
            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfLotDetailList_Init()

            If txtLotID.Text <> vbNullString Then
                '@最新取得ﾎﾞﾀﾝを有効にする
                cmdLotSearch.Enabled = True
            End If
            
            '@ﾎﾞﾀﾝ非活性化
            cmdUP.Enabled = False               '▲ﾎﾞﾀﾝ
            cmdDown.Enabled = False             '▼ﾎﾞﾀﾝ
            cmdLeft.Enabled = False             '≪ﾎﾞﾀﾝ
            cmdRight.Enabled = False            '≫ﾎﾞﾀﾝ
            cmdLotComment.Enabled = False       'ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ
            cmdWPRecipeList.Enabled = False     '装置ﾚｼﾋﾟ表示ﾎﾞﾀﾝ
            
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

    '関数名：txtLotID_GotFocus
    '機　能：ﾛｯﾄID GotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 13:51:37 H.Wajima
    '更新日：2004/10/21 (Thu) 13:51:37
    '備　考：
    Private Sub txtLotID_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotID.Enter

        Try
            
            '@流動票情報取得ﾌﾗｸﾞの判定
            If mblnLotDetailListGet = True Then
            '@流動票の取得後にﾌｫｰｶｽが当たった場合(ｷｬﾘｱIDのValidate処理後)
                '@流動票取得ﾌﾗｸﾞにFalseを設定する
                mblnLotDetailListGet = False
                
                If vsfLotDetailList.Enabled = True Then
                    '@流動票一覧にﾌｫｰｶｽをｾｯﾄする
                    Call pubSetFocus(vsfLotDetailList)
                End If
                
                Exit Sub
            End If
            
            '@有効ｺﾝﾄﾛｰﾙ名の設定
            mstrActiveControlName = CMstrActiveControlNameLotID

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotID_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Validate
    '機　能：ﾛｯﾄID Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 13:51:41 H.Wajima
    '更新日：2004/10/21 (Thu) 13:51:41
    '備　考：
    '　　　：2005/05/06 (Fri) 14:53:29 S.Deguchi    不具合№214の対応で処理見直し
    Private Sub txtLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLotID.Validating

        Dim lblnRet                 As Boolean          '戻り値
        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "txtLotID_Validate"
            
            '@退避ﾛｯﾄIDの判定
            If txtLotID.Text = mstrTaihiLotID Then
            '@退避ﾛｯﾄIDと表示中のﾛｯﾄIDが同じ場合
                If ActiveControl.Name = txtLotID.Name Then
                    '@ﾌｫｰｶｽ処理
                    If vsfLotDetailList.Enabled = True Then
                        '@ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfLotDetailList)
                    Else
                        If cmdLotSearch.Enabled = True Then
                            '@最新取得ﾎﾞﾀﾝ
                            Call pubSetFocus(cmdLotSearch)
                        Else
                            '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If
                '@処理を抜ける
                Exit Sub
            End If
            
            '@ﾛｯﾄIDの空白ﾁｪｯｸ
            If txtLotID.Text = vbNullString Then
                '@有効ｺﾝﾄﾛｰﾙ名のｸﾘｱ
                mstrActiveControlName = vbNullString
                If ActiveControl.Name = txtLotID.Name Then
                    '@ﾌｫｰｶｽ処理
                    If vsfLotDetailList.Enabled = True Then
                        '@ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfLotDetailList)
                    Else
                        If cmdLotSearch.Enabled = True Then
                            '@最新取得ﾎﾞﾀﾝ
                            Call pubSetFocus(cmdLotSearch)
                        Else
                            '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If
                Exit Sub
            End If
            
            '@ﾛｯﾄIDの桁ﾁｪｯｸ
            If txtLotID.NowByte < txtLotID.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                
                '@"ロットIDは10桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                e.Cancel = True
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@流動票最新取得処理を実行する
            lblnRet = prvblnLotDetailListGet_Proc(vbNullString, _
                                                  txtLotID.Text, _
                                                  CMstrLotDetailListNum0, _
                                                  CMstrLotDetailListNum16, _
                                                  CMstrLotDetailListNum16)
            
            '@戻り値の判定
            If lblnRet = False Then
            '@異常終了の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            
                '@ｷｬﾝｾﾙ
                e.Cancel = True
                
                '@流動票情報取得ﾌﾗｸﾞにTrueを設定する
                mblnLotDetailListGet = True
            
                Exit Sub
            Else
            '@正常終了の場合
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@流動票情報取得ﾌﾗｸﾞにFalseを設定する
                mblnLotDetailListGet = False
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

    '関数名：vsfLotDetailList_Click
    '機　能：ﾛｯﾄ流動票 Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 10:51:25 H.Wajima
    '更新日：2004/10/25 (Mon) 10:51:25
    '備　考：
    Private Sub vsfLotDetailList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotDetailList.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotDetailList.Rows.Count <= vsfLotDetailList.Rows.Fixed Then
                Return
            End If
            
            '@先頭行の保存
            mlngTopRow = vsfLotDetailList.TopRow
            
            Call pubblnVsfTag_Set(vsfLotDetailList, 1, mlngTopRow)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotDetailList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotSearch_GotFocus
    '機　能：最新取得ﾎﾞﾀﾝ GotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 10:06:07 H.Wajima
    '更新日：2004/11/02 (Tue) 10:06:07
    '備　考：
    Private Sub cmdLotSearch_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotSearch.Enter

        Try
            
            '@流動票情報取得ﾌﾗｸﾞの判定
            If mblnLotDetailListGet = True Then
            '@流動票の取得後にﾌｫｰｶｽが当たった場合(ﾛｯﾄIDのValidate処理後)
                '@流動票取得ﾌﾗｸﾞにFalseを設定する
                mblnLotDetailListGet = False
                
                '@流動票一覧にﾌｫｰｶｽをｾｯﾄする
                With vsfLotDetailList
                    If .Enabled = True Then
                        Call pubSetFocus(vsfLotDetailList)
                    End If
                End With
                
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotSearch_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRight_GotFocus
    '機　能：≫ﾎﾞﾀﾝ GotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/05 (Fri) 11:07:39 H.Wajima
    '更新日：2004/11/05 (Fri) 11:07:39
    '備　考：
    Private Sub cmdRight_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Enter

        Try
            
            '@流動票情報取得ﾌﾗｸﾞの判定
            If mblnLotDetailListGet = True Then
            '@流動票の取得後にﾌｫｰｶｽが当たった場合(ﾛｯﾄIDのValidate処理後)
                '@流動票取得ﾌﾗｸﾞにFalseを設定する
                mblnLotDetailListGet = False
                
                '@流動票一覧にﾌｫｰｶｽをｾｯﾄする
                With vsfLotDetailList
                    If .Enabled = True Then
                        Call pubSetFocus(vsfLotDetailList)
                    End If
                End With
                
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRight_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotDetailList_AfterUserResize
    '機　能：ﾛｯﾄ流動票 AfterUserResize処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2004/11/02 (Tue) 18:14:44 H.Wajima
    '更新日：2004/11/02 (Tue) 18:14:44
    '備　考：
    Private Sub vsfLotDetailList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotDetailList.AfterResizeColumn, vsfLotDetailList.AfterResizeRow

    '    Dim llngMaxCol          As Long     'Col総数
    '    Dim llngloopcount       As Long     'ループカウント
    '    Dim llngWidthAll        As Long     'Colの全幅
    '    Dim llngWidth           As Long     'Colの全
    '    Dim llngHideStartCol    As Long     '隠れているColの開始番号
    '    Dim llngHideWidth       As Long     '隠れているColの幅
    '    Dim llngCnt         A装置別ロット一覧s Long         'ｶｳﾝﾄ

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotDetailList.Rows.Count <= vsfLotDetailList.Rows.Fixed Then
                Return
            End If
            
            
        '@↓2007/07/09 (Mon) 15:22:10 N.Kasai **************************************************
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            Call pubCmdLREnable_Set(vsfLotDetailList, cmdLeft, cmdRight)

            
        '    '@初期設定
        '    llngMaxCol = 0
        '    llngloopcount = 0
        '    llngWidthAll = 0
        '    llngWidth = 0
        '    llngHideStartCol = 0
        '    llngHideWidth = 0
        '
        '    With vsfLotDetailList
        '        '@最大Col番号取得(Col総数-1)
        '        llngMaxCol = .Cols - 1
        '
        '        '@全列数の幅取得
        '        For llngloopcount = 0 To llngMaxCol
        '            llngWidthAll = llngWidthAll + .ColWidth(llngloopcount)
        '        Next llngloopcount
        '
        '        '@隠れているColの開始番号取得
        '        llngHideStartCol = CMlngvsfLotDetailListFrozenCols
        '
        '        '@隠れているｸﾞﾘｯﾄﾞ幅の取得
        '        If llngHideStartCol <> .LeftCol Then
        '            For llngloopcount = llngHideStartCol To .LeftCol
        '                llngHideWidth = llngHideWidth + .ColWidth(llngloopcount)
        '            Next
        '        Else
        '            llngHideWidth = 0
        '        End If
        '
        '        If llngHideWidth = 0 Then
        '            '表示範囲内の幅を取得
        '            llngWidth = llngWidthAll
        '
        '            '@ｸﾞﾘｯﾄﾞ表示の幅が表示範囲内にある場合には左右ｽｸﾛｰﾙﾎﾞﾀﾝを非活性化にする
        '            If .Width >= llngWidth Then
        '                cmdRight.Enabled = False
        '                cmdLeft.Enabled = False
        '            Else
        '            '@ｸﾞﾘｯﾄﾞ表示の幅が表示範囲より大きい場合には右ｽｸﾛｰﾙﾎﾞﾀﾝを活性化にする
        '                cmdRight.Enabled = True
        '                cmdLeft.Enabled = False
        '            End If
        '        Else
        '            '表示範囲内の幅を取得
        '            llngWidth = llngWidthAll + llngHideWidth
        '
        '            '@ｸﾞﾘｯﾄﾞ表示の幅が表示範囲内にある場合には左右ｽｸﾛｰﾙﾎﾞﾀﾝを非活性化にする
        '            If .Width >= llngWidth Then
        '                cmdRight.Enabled = False
        '                cmdLeft.Enabled = False
        '            Else
        '            '@ｸﾞﾘｯﾄﾞ表示の幅が表示範囲より大きい場合には右ｽｸﾛｰﾙﾎﾞﾀﾝを活性化にする
        '                cmdRight.Enabled = True
        '                cmdLeft.Enabled = True
        '            End If
        '        End If
        '    End With
        '@↑2007/07/09 (Mon) 15:22:10 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotDetailList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotDetailList_BeforeRowColChange
    '機　能：ﾛｯﾄ流動票 BeforeRowColChange処理
    '引　数：OldRow：変更前の行番号
    '　　　：OldCol：変更前の列番号
    '　　　：NewRow：変更後の行番号
    '　　　：NewCol：変更後の列番号
    '　　　：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 10:48:37 H.Wajima
    '更新日：2004/11/10 (Wed) 18:06:56 H.Wajima
    '備　考：2004/11/10 (Wed) 18:06:56 H.Wajima 履歴空行対応
    Private Sub vsfLotDetailList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotDetailList.BeforeRowColChange
        
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnRet             As Boolean              '戻り値
        Dim lblnMsgGetStatus    As Boolean              'ﾁｪｯｸｽﾃｰﾀｽ
        Dim lstrMinLastSeqNum   As String               '前回Msg取得時の最小ｷｰ値
        Dim lstrMaxLastSeqNum   As String               '前回Msg取得時の最大ｷｰ値

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotDetailList.Rows.Count <= vsfLotDetailList.Rows.Fixed Then
                Return
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "vsfLotDetailList_BeforeRowColChange"
            
            '@ﾏｳｽで選択行が変更されかどうかを判定
            If mblnMouseDownFlag = False Then
                '@ﾏｳｽ以外で選択行が変更された場合
                
                '@前回取得情報の件数を判定
                If mtypLotDetailList.lngDetailListCount = 0 Then
                    '@0件の場合
                    '@行が変更されたかを判定
                    If e.OldRange.r1 = e.NewRange.r1 Then
                        '@行が変更されていない場合
                        Exit Sub
                    Else
                        '@行が変更された場合
                        '@前回Msg取得時の最小ｷｰ値と最大ｷｰ値に変更前の行を設定する
                        lstrMinLastSeqNum = e.OldRange.r1
                        lstrMaxLastSeqNum = e.OldRange.r1
                    End If
                Else
                    '@0件以外の場合
                    '@前回Msg取得時の最小ｷｰ値と最大ｷｰ値を設定する
                    lstrMinLastSeqNum = mtypLotDetailList.typDetailList(0).strSeqNum
                    lstrMaxLastSeqNum = mtypLotDetailList.typDetailList(mtypLotDetailList.lngDetailListCount - 1).strSeqNum
                End If
                
                '@変更後の行が、0か-1の場合は処理を抜ける
                Select Case e.NewRange.r1
                    Case CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListAll
                        '@0か1の場合
                        Exit Sub
                End Select
                
                '@ｸﾞﾘｯﾄﾞ共通 ﾍﾟｰｼﾞ毎ﾒｯｾｰｼﾞ取得判定処理を実行する
                lblnRet = pubblnvsfPageMsgGet_Chk(e.OldRange.r1, _
                                                    e.NewRange.r1, _
                                                    mlngTopRow, _
                                                    vsfLotDetailList.TopRow, _
                                                    lstrMinLastSeqNum, _
                                                    lstrMaxLastSeqNum, _
                                                    CStr(vsfLotDetailList.GetData(e.NewRange.r1, CMlngvsfLotDetailListColNo)), _
                                                    lblnMsgGetStatus)
                '@戻り値の判定
                If lblnRet = True Then
                '@正常終了の場合
                    '@ｽﾃｰﾀｽの判定
                    If lblnMsgGetStatus = True Then
                        '@ｽﾃｰﾀｽがTrue(再取得必要)の場合
                        
                        '@Msgを再取得する
                        '@ﾚｽﾎﾟﾝｽ取得開始
                        Call pubResponseStart(lstrFormName, lstrEventName)
                        
                        '@流動票最新取得処理を実行する
                        '@前後1ﾍﾟｰｼﾞ分再取得
                        lblnRet = prvblnLotDetailListGet_Proc(vbNullString, _
                                                                txtLotID.Text, _
                                                                e.NewRange.r1, _
                                                                CMstrLotDetailListNum16, _
                                                                CMstrLotDetailListNum16)
                        
                        '@戻り値の判定
                        If lblnRet = False Then
                        '@異常終了の場合
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)
                        Else
                        '@正常終了の場合
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(lstrFormName, lstrEventName)
                        End If
                    End If
                End If
            Else
                '@ﾏｳｽﾀﾞｳﾝﾌﾗｸﾞにFalseを設定する
                mblnMouseDownFlag = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotDetailList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotDetailList_MouseDown
    '機　能：ﾛｯﾄ流動票 MouseDown処理
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：X座標
    '　　　：Y：Y座標
    '戻り値：
    '作成日：2004/10/25 (Mon) 10:51:33 H.Wajima
    '更新日：2004/10/25 (Mon) 10:51:33
    '備　考：
    Private Sub vsfLotDetailList_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfLotDetailList.MouseDown

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotDetailList.Rows.Count <= vsfLotDetailList.Rows.Fixed Then
                Return
            End If
            
            '@ﾏｳｽﾀﾞｳﾝﾌﾗｸﾞにTrueを設定する
            mblnMouseDownFlag = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotDetailList_MouseDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotDetailList_RowColChange
    '機　能：ﾛｯﾄ流動票 RowColChange処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 10:51:41 H.Wajima
    '更新日：2004/10/25 (Mon) 10:51:41
    '備　考：
    Private Sub vsfLotDetailList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotDetailList.RowColChange

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotDetailList.Rows.Count <= vsfLotDetailList.Rows.Fixed Then
                Return
            End If

            '@先頭行の保存
            mlngTopRow = vsfLotDetailList.TopRow
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの有効無効判定
            Call prvcmdEnabled_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotDetailList_RowColChange"
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
    '関数名：prvblnLotDetailListGet_Proc
    '機　能：流動票最新取得処理
    '引　数：lstrCarrierID      ：ｷｬﾘｱID
    '　　　：lstrLotID          ：ﾛｯﾄID
    '　　　：lstrStartSeqNum    ：検索開始工順
    '　　　：lstrBeforeSeqNum   ：後方検索数
    '　　　：lstrAfterSeqNum    ：前方検索数
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 18:03:30 H.Wajima
    '更新日：2004/11/10 (Wed) 18:08:16 H.Wajima
    '備　考：2004/11/10 (Wed) 18:08:16 H.Wajima 履歴空行対応
    Private Function prvblnLotDetailListGet_Proc(ByVal lstrCarrierID As String, _
                                                 ByVal lstrLotID As String, _
                                                 ByVal lstrStartSeqNum As String, _
                                                 ByVal lstrBeforeSeqNum As String, _
                                                 ByVal lstrAfterSeqNum As String) As Boolean

        Dim lblnRet                 As Boolean

        Try
            
            '@当関数の戻りにFalseを設定
            prvblnLotDetailListGet_Proc = False
            
            '@ｷｬﾘｱIDかﾛｯﾄIDのどちらかに値が設定されているか判定
            Select Case True
                Case lstrCarrierID <> vbNullString And lstrLotID = vbNullString, _
                    lstrCarrierID = vbNullString And lstrLotID <> vbNullString
                    '@ｷｬﾘｱIDとﾛｯﾄIDのどちらか一方だけ入力されている場合
                    '@何もしない
                Case Else
                    '@上記以外の場合
                    '@ﾛｯﾄIDを信用する(ｷｬﾘｱIDを空白にする)
                    lstrCarrierID = vbNullString
            End Select
            
            '@=======================
            '@ ﾛｯﾄ流動票取得
            '@=======================
            lblnRet = pubblnLotDetailList_Sel(CMstrLot_DetailList_Ver, _
                                              pstrSBID, _
                                              lstrLotID, _
                                              lstrCarrierID, _
                                              lstrStartSeqNum, _
                                              lstrBeforeSeqNum, _
                                              lstrAfterSeqNum, _
                                              mtypLotDetailList)
            
            '@戻り値の判定
            If lblnRet = True Then
            '@正常終了した場合
                vsfLotDetailList.Redraw = False
                '@行選択
                If lstrStartSeqNum = "0" Then
                '@現在の工順が指定された場合
                    '@画面項目に値を設定
                    Call prvvsfLotDetailList_Disp(mtypLotDetailList, _
                                                  lstrStartSeqNum, _
                                                  lstrBeforeSeqNum, _
                                                  lstrAfterSeqNum, _
                                                  True)
                Else
                '@直接、工順№が指定された場合
                    '@画面項目に値を設定
                    Call prvvsfLotDetailList_Disp(mtypLotDetailList, _
                                                  lstrStartSeqNum, _
                                                  lstrBeforeSeqNum, _
                                                  lstrAfterSeqNum, _
                                                  False)
                End If

                vsfLotDetailList.Redraw = True

                '@退避ｷｬﾘｱID更新
                mstrTaihiCarrierID = mtypLotDetailList.strCarrierId
                
                '@退避ﾛｯﾄID更新
                mstrTaihiLotID = mtypLotDetailList.strLotID
            
                '@当関数の戻りにTrueを設定
                prvblnLotDetailListGet_Proc = True
            Else
            '@異常終了した場合
                '@ﾍｯﾀﾞ情報を初期化する
                Call prvHeaderInfoInit_Proc()
                
                '@一覧を初期化する
                Call prvvsfLotDetailList_Init()
                
                '@最新取得ﾎﾞﾀﾝ無効
                cmdLotSearch.Enabled = False
                
                '@▲▼≪≫ﾎﾞﾀﾝ無効
                cmdUP.Enabled = False
                cmdDown.Enabled = False
                cmdLeft.Enabled = False
                cmdRight.Enabled = False
                
                '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ無効
                cmdLotComment.Enabled = False
                
                '@装置ﾚｼﾋﾟ表示ﾎﾞﾀﾝ無効
                cmdWPRecipeList.Enabled = False
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotDetailListGet_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvvsfLotDetailList_init
    '機　能：ﾛｯﾄ流動票一覧初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/18 (Mon) 11:47:29 H.Wajima
    '更新日：2004/10/18 (Mon) 11:47:29
    '備　考：
    Private Sub prvvsfLotDetailList_Init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfLotDetailList
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@ｸﾞﾘｯﾄﾞの行設定
                .Rows.Count = CMlngvsfLotDetailListTRows

                '@ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMlngvsfLotDetailListCols
                
                '@ﾀｲﾄﾙ行数の初期化
                .Rows.Fixed = CMlngvsfLotDetailListTRows
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                '.FocusRect = FocusRectEnum.None
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed

                With .Font
                    lFixedStyle.Font = New Font(.FontFamily,CMlngvsfLotDetailListHFontSize, .Style, _
                                            .Unit, .GdiCharSet, .GdiVerticalFont)                       'ﾌｫﾝﾄｻｲｽﾞ
                End With
                lFixedStyle.ForeColor = Color.Yellow                                                    '文字色
                lFixedStyle.BackColor = Color.Navy                                                      '背景色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                                      '配置
                                
                '@№
                .Cols(CMlngvsfLotDetailListColNo).TextAlign = TextAlignEnum.RightCenter
                '@大工程
                .Cols(CMlngvsfLotDetailListColOPID).TextAlign = TextAlignEnum.LeftCenter
                '@小工程
                .Cols(CMlngvsfLotDetailListColStepID).TextAlign = TextAlignEnum.LeftCenter
                '@作業開始/終了日時
                .Cols(CMlngvsfLotDetailListColStartEndTime).TextAlign = TextAlignEnum.LeftCenter
                '@装置名
                .Cols(CMlngvsfLotDetailListColWPName).TextAlign = TextAlignEnum.LeftCenter
                '@ﾎﾟｰﾄID
                .Cols(CMlngvsfLotDetailListColPortID).TextAlign = TextAlignEnum.LeftCenter
                '@ﾚｼﾋﾟID
                .Cols(CMlngvsfLotDetailListColRecipeID).TextAlign = TextAlignEnum.LeftCenter
                '@ﾃﾞｰﾀ収集有無
                .Cols(CMlngvsfLotDetailListColCollectionFlag).TextAlign = TextAlignEnum.LeftCenter
                '@ｷｬﾘｱID
                .Cols(CMlngvsfLotDetailListColCarrierID).TextAlign = TextAlignEnum.LeftCenter
                '@WF枚数
                .Cols(CMlngvsfLotDetailListColWFNum).TextAlign = TextAlignEnum.RightCenter
                '@ﾁｯﾌﾟ良品数
                .Cols(CMlngvsfLotDetailListColChipNum).TextAlign = TextAlignEnum.RightCenter
                '@開始作業者名/終了作業者名
                .Cols(CMlngvsfLotDetailListColEmpName).TextAlign = TextAlignEnum.LeftCenter
                '@ﾛｯﾄｺﾒﾝﾄ有無
                .Cols(CMlngvsfLotDetailListColCommentFlag).TextAlign = TextAlignEnum.LeftCenter
                
                '@列幅、ﾀｲﾄﾙ設定
                '@№
                .Cols(CMlngvsfLotDetailListColNo).Width = CMlngvsfLotDetailListColWNo
                .SetData(CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListColNo, CMstrvsfLotDetailListColTNo)
                '@大工程
                .Cols(CMlngvsfLotDetailListColOPID).Width = CMlngvsfLotDetailListColWOPID
                .SetData(CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListColOPID, CMstrvsfLotDetailListColTOPID)
                '@小工程
                .Cols(CMlngvsfLotDetailListColStepID).Width = CMlngvsfLotDetailListColWStepID
                .SetData(CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListColStepID, CMstrvsfLotDetailListColTStepID)
                '@作業開始/終了日時
                .Cols(CMlngvsfLotDetailListColStartEndTime).Width = CMlngvsfLotDetailListColWStartEndTime
                .SetData(CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListColStartEndTime, CMstrvsfLotDetailListColTStartEndTime)
                '@装置名
                .Cols(CMlngvsfLotDetailListColWPName).Width = CMlngvsfLotDetailListColWWPName
                .SetData(CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListColWPName, CMstrvsfLotDetailListColTWPName)
                '@ﾎﾟｰﾄID
                .Cols(CMlngvsfLotDetailListColPortID).Width = CMlngvsfLotDetailListColWPortID
                .SetData(CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListColPortID, CMstrvsfLotDetailListColTPortID)
                '@ﾚｼﾋﾟID
                .Cols(CMlngvsfLotDetailListColRecipeID).Width = CMlngvsfLotDetailListColWRecipeID
                .SetData(CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListColRecipeID, CMstrvsfLotDetailListColTRecipeID)
                '@ﾃﾞｰﾀ収集有無
                .Cols(CMlngvsfLotDetailListColCollectionFlag).Width = CMlngvsfLotDetailListColWCollectionFlag
                .SetData(CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListColCollectionFlag, CMstrvsfLotDetailListColTCollectionFlag)
                '@ｷｬﾘｱID
                .Cols(CMlngvsfLotDetailListColCarrierID).Width = CMlngvsfLotDetailListColWCarrierID
                .SetData(CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListColCarrierID, CMstrvsfLotDetailListColTCarrierID)
                '@WF枚数
                .Cols(CMlngvsfLotDetailListColWFNum).Width = CMlngvsfLotDetailListColWWFNum
                .SetData(CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListColWFNum, CMstrvsfLotDetailListColTWFNum)
                '@ﾁｯﾌﾟ良品数
                .Cols(CMlngvsfLotDetailListColChipNum).Width = CMlngvsfLotDetailListColWChipNum
                .SetData(CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListColChipNum, CMstrvsfLotDetailListColTChipNum)
                '@作業者名
                .Cols(CMlngvsfLotDetailListColEmpName).Width = CMlngvsfLotDetailListColWEmpName
                .SetData(CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListColEmpName, CMstrvsfLotDetailListColTEmpName)
                '@ﾛｯﾄｺﾒﾝﾄ有無
                .Cols(CMlngvsfLotDetailListColCommentFlag).Width = CMlngvsfLotDetailListColWCommentFlag
                .SetData(CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListColCommentFlag, CMstrvsfLotDetailListColTCommentFlag)
                
                '@行の高さ設定
                .Rows(CMlngvsfLotDetailListTRow).Height = CMlngvsfLotDetailListHdHeight     'ﾍｯﾀﾞｰ
                
                '@描画ﾛｯｸ解除
                .Redraw = True
                
                '@固定列
                .Cols.Frozen = CMlngvsfLotDetailListFrozenCols
                
                '@横ｽｸﾛｰﾙ画面初期化処理
                .LeftCol = CMlngvsfLotDetailListFrozenCols
                
                .Cols(CMlngvsfLotDetailListColStartEndTime).StyleNew.Trimming = StringTrimming.None
                .Cols(CMlngvsfLotDetailListColStartEndTime).StyleFixedNew.Trimming = StringTrimming.None
                .Cols(CMlngvsfLotDetailListColEmpName).StyleNew.Trimming = StringTrimming.None
                .Cols(CMlngvsfLotDetailListColEmpName).StyleFixedNew.Trimming = StringTrimming.None

                '@ﾛｯｸ
                .Enabled = False
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotDetailList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotDetailList_Disp
    '機　能：流動票一覧 表示処理
    '引　数：ltypLotDetailList  ：流動票一覧構造体
    '　　　：lstrStartSeqNum    ：ﾒｯｾｰｼﾞ取得時の開始工順№
    '　　　：lstrBeforeSeqNum   ：ﾒｯｾｰｼﾞ取得時の後方件数
    '　　　：lstrAfterSeqNum    ：ﾒｯｾｰｼﾞ取得時の前方件数
    '　　　：lblnTopRowChange   ：True：現在工順に合わせて、先頭行を変更する、False：先頭行を変更しない
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 13:44:53 H.Wajima
    '更新日：2016/02/09 (Tue) 00:17:09 H.Hayashi
    '備　考：
    '　　　：2004/11/10 (Wed) 18:09:48 H.Wajima     履歴空行対応
    '　　　：2004/11/25 (Thu) 16:03:30 H.Wajima     DETAIL_LISTが0件以外で、SEQ_NUMに数値以外の値が返って来た場合のｴﾗｰ対応
    '　　　：2004/12/03 (Fri) 09:59:18 H.Wajima     空白行対応で、条件により正常に表示できない場合の対応
    '　　　：2005/04/27 (Wed) 09:00:42 S.Deguchi    保留,停止の表示を修正
    '　　　：2005/04/27 (Wed) 14:03:16 S.Deguchi    不具合№750の対応で,数量の表示ﾌｫｰﾏｯﾄを修正
    '　　　：2005/11/09 (Wed) 13:37:53 N.Kasai      応答msg変更に伴う修正(RESIPE_LIST廃止、RECIPE_ID追加)
    '　　　：2009/03/24 (Tue) 17:35:19 N.Kojima     送品先とｵｰﾀﾞｰ区分(ﾁｯﾌﾟ電特区分)が異なる場合、背景色をｸﾞﾚｰにする。(案件№03402)
    '　　　：2009/12/03 (Thu) 14:53:00 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub prvvsfLotDetailList_Disp(ByRef ltypLotDetailList As LotDetailList, _
                                         ByVal lstrStartSeqNum As String, _
                                         ByVal lstrBeforeSeqNum As String, _
                                         ByVal lstrAfterSeqNum As String, _
                                         Optional ByVal lblnTopRowChange As Boolean = False)
        
        Dim llngRowCnt          As Integer  '行ｶｳﾝﾀ
        Dim lstrPortName        As String   'ﾎﾟｰﾄ名
        Dim llngLoopCnt         As Integer  'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngLeftCol         As Integer  '横ｽｸﾛｰﾙ位置
        Dim lstrStartTime       As String   '作業開始日時
        Dim lstrEndTime         As String   '作業終了日時
        Dim lstrStartEmpName    As String   '開始作業者名
        Dim lstrEndEmpName      As String   '終了作業者名
        Dim llngStartRow        As Integer  '開始行番号
        Dim llngEndRow          As Integer  '終了行番号
        Dim lstrSbArea          As String   'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        Dim lstrLotGrbClass     As String   'GRB区分(LOT)

        Try
            
            '@横ｽｸﾛｰﾙの表示位置を退避
            llngLeftCol = vsfLotDetailList.LeftCol
                
            With ltypLotDetailList
                
                '@***********************
                '@ ﾍｯﾀﾞｰ情報の表示
                '@***********************
                '@ﾛｯﾄID
                If mstrActiveControlName <> CMstrActiveControlNameLotID Then
                    '@ｷｬﾘｱIDの入力で情報を取得しなかった場合
                    txtLotID.Text = .strLotID
                End If
                
                '@ｷｬﾘｱID
                If mstrActiveControlName <> CMstrActiveControlNameCarrierID Then
                    '@ｷｬﾘｱIDの入力で情報を取得しなかった場合
                    txtCarrierID.Text = .strCarrierId
                End If
                
                '@現在工順№
                mstrCurrentSeqNum = .strCurrentSeqNum
                
                '@現在大工程
                lblOpID.Text = .strOpID
                
                '@現在小工程
                lblStepID.Text = .strStepID
                
                '@ﾌｫｰﾏｯﾄ変更(数量)
                If IsNumeric(.strWfNum) Then
                    lblWFNo.Text = Format$(CInt(.strWfNum), CPstrDateFormatKanma)
                Else
                    lblWFNo.Text = .strWfNum
                End If
                
                '@状態
                lblStatus.Text = .strNowST
                
                '@機種
                lblPd.Text = .strPdId
                
                '@保留
                If .strHoldFlag = CPstrHold1 Then
                    lblHold.Text = CPstrHoldSt & Space(1)
                Else
                    lblHold.Text = vbNullString
                End If
                
                '@停止
                If .strStopFlag = CPstrHold1 Then
                    lblHold.Text = lblHold.Text & CPstrStopSt
                Else
                    lblHold.Text = lblHold.Text
                End If
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ
                lstrSbArea = .strSbArea
                '@GRB区分(LOT)
                lstrLotGrbClass = .strLotGrbClass        
                '@取得日時を表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                
                '@該当件数
                lblLotCnt.Text = .strLastSeqNum
                
                
                '@***********************
                '@ ﾛｯﾄ流動票一覧の初期化
                '@***********************
                With vsfLotDetailList

                    RemoveHandler vsfLotDetailList.BeforeRowColChange,AddressOf vsfLotDetailList_BeforeRowColChange
                    .Rows.Count = CLng(ltypLotDetailList.strLastSeqNum) + 1       '行数
                    AddHandler vsfLotDetailList.BeforeRowColChange,AddressOf vsfLotDetailList_BeforeRowColChange
                    For Count = 1 To .Rows.Count - 1
                        .Rows(Count).Height = CMlngvsfLotDetailListHeight          'ﾍｯﾀﾞｰの幅(高さ)
                    Next
                    .Rows(0).Height = CMlngvsfLotDetailListHdHeight                'ﾃﾞｰﾀ行の幅(高さ)
                    '.AutoSizeMode = flexAutoSizeColWidth                          '列のみ自動調節
                    .AutoSizeCols(CMlngvsfLotDetailListColOPID, _
                              CMlngvsfLotDetailListColCommentFlag, 6)              '自動調節
                    '.ExplorerBar = flexExNone                                     'ｽｸﾛｰﾙ：なし
                    .AllowResizing = AllowResizingEnum.Columns                     '列のみ伸縮可能
                End With
                
                '@検索開始工順№が"0"か
                If lstrStartSeqNum = CPstrZero Then
                    
                    '@開始行番号
                    If CLng(.strCurrentSeqNum) - CLng(lstrAfterSeqNum) < vsfLotDetailList.Rows.Fixed Then
                        '@先頭行より小さくなる場合は先頭行番号を設定
                        llngStartRow = vsfLotDetailList.Rows.Fixed
                    Else
                        '@上記以外の場合
                        llngStartRow = CLng(.strCurrentSeqNum) - CLng(lstrAfterSeqNum)
                    End If
                    
                    '@終了行番号
                    If CLng(.strCurrentSeqNum) + CLng(lstrBeforeSeqNum) >= vsfLotDetailList.Rows.Count Then
                        '@最終行番号よりも大きくなる場合は、最終行を設定
                        llngEndRow = vsfLotDetailList.Rows.Count - 1
                    Else
                        '@上記以外の場合
                        llngEndRow = CLng(.strCurrentSeqNum) + CLng(lstrBeforeSeqNum)
                    End If
                Else
                    '@検索開始工順№が"0"以外か
                
                    '@開始行番号
                    If CLng(lstrStartSeqNum) - CLng(lstrAfterSeqNum) < vsfLotDetailList.Rows.Fixed Then
                        '@先頭行より小さくなる場合は先頭行番号を設定
                        llngStartRow = vsfLotDetailList.Rows.Fixed
                    Else
                        '@上記以外の場合
                        llngStartRow = CLng(lstrStartSeqNum) - CLng(lstrAfterSeqNum)
                    End If
                    
                    '@終了行番号
                    If CLng(lstrStartSeqNum) + CLng(lstrBeforeSeqNum) >= vsfLotDetailList.Rows.Count Then
                        '@最終行番号よりも大きくなる場合は、最終行を設定
                        llngEndRow = vsfLotDetailList.Rows.Count - 1
                    Else
                        '@上記以外の場合
                        llngEndRow = CLng(lstrStartSeqNum) + CLng(lstrBeforeSeqNum)
                    End If
                End If
                
                '@ﾛｯﾄ流動票一覧情報がNULL以外か
                If ltypLotDetailList.lngDetailListCount <> 0 Then
                    '@NULL以外の場合
                    
                    '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                    llngLoopCnt = 0
                    
                    '@行のﾙｰﾌﾟ
                    For llngRowCnt = llngStartRow To llngEndRow
                        
                        '@★ ﾙｰﾌﾟｶｳﾝﾀ値により処理分岐 ★
                        Select Case llngLoopCnt
                            
                            '@〓 ﾙｰﾌﾟｶｳﾝﾀが配列のｲﾝﾃﾞｯｸｽ以外の値を指している場合 〓
                            Case Is > .typDetailList.Count - 1, Is < 0
                                
                                '@=======================
                                '@ 空白行挿入処理
                                '@=======================
                                Call prvvsfLotDetailListSpaceRowIns_Proc(llngRowCnt)
                            
                            
                            '@〓 上記以外の場合 〓
                            Case Else
                            
                                With .typDetailList(llngLoopCnt)
                                    
                                    '@★★ 行番号と工順番号の判定 ★★
                                    Select Case True
                                        
                                        '@〓〓 工順番号が数字以外の場合 〓〓
                                        Case Not IsNumeric(.strSeqNum)
                                            
                                            '@=======================
                                            '@ 空白行挿入処理
                                            '@=======================
                                            Call prvvsfLotDetailListSpaceRowIns_Proc(llngRowCnt)
                                        
                                        
                                        '@〓〓 工順番号と行番号が違う場合 〓〓
                                        Case llngRowCnt < CLng(.strSeqNum)
                                            
                                            '@=======================
                                            '@ 空白行挿入処理
                                            '@=======================
                                            Call prvvsfLotDetailListSpaceRowIns_Proc(llngRowCnt)
                                        
                                        
                                        '@〓〓 工順番号と行番号が違う場合 〓〓
                                        Case llngRowCnt > CLng(.strSeqNum)
                                            
                                            '@=======================
                                            '@ 空白行挿入処理
                                            '@=======================
                                            Call prvvsfLotDetailListSpaceRowIns_Proc(llngRowCnt)
                                            
                                            '@ﾙｰﾌﾟｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                                            llngLoopCnt = llngLoopCnt + 1
                                        
                                        
                                        '@〓〓 行番号と工順番号が同じ場合 〓〓
                                        Case Else
                                        
                                            '@№
                                            vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColNo, .strSeqNum)
                                            
                                            '@現在工程と比較
                                            If CLng(.strSeqNum) = CLng(mstrCurrentSeqNum) Then
                                                '@現在工程の場合
                                                
                                                '@背景色変更(：水色)
                                                Dim newStyle As CellStyle = vsfLotDetailList.Styles.Add("CustomStyle_BackColor_CMlngCurrentSeqColor")
                                                newStyle.BackColor = ColorTranslator.FromWin32(CMlngCurrentSeqColor)
                                                Dim cellRange As CellRange = vsfLotDetailList.GetCellRange(llngRowCnt, CMlngvsfLotDetailListColNo, _
                                                                                       llngRowCnt, CMlngvsfLotDetailListColCommentFlag)
                                                cellRange.Style = newStyle
                                            Else
                                                '@現在工程以外の場合
                                                
                                                '@下記条件の場合、行の背景色をｸﾞﾚｰにする
                                                '@ ①ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ!='7'でChip品限定工程
                                                '@ ②ｼｽﾃﾑﾌﾞﾛｸｴﾘｱ='7'でModule品限定工程
        '                                        If (Mid$(lstrSendSBID, 1, 1) <> CPstrProductChip And .strCdenClass = CPstrChip) Or _
        '                                            (Mid$(lstrSendSBID, 1, 1) = CPstrProductChip And .strCdenClass = CPstrModule) Then
                                                If (lstrSbArea <> CPstrProductChip And .strCdenClass = CPstrChip) Or _
                                                    (lstrSbArea = CPstrProductChip And .strCdenClass = CPstrModule) Then
                                                    
                                                    '@背景色をｸﾞﾚｰにする
                                                    Dim newStyle As CellStyle = vsfLotDetailList.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                                                    Dim cellRange As CellRange = vsfLotDetailList.GetCellRange(llngRowCnt, CMlngvsfLotDetailListColNo, _
                                                                        llngRowCnt, CMlngvsfLotDetailListColCommentFlag)
                                                    cellRange.Style = newStyle
                                                
                                                '@↓2020/01/22 (Wed) 11:38:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                                '@GBR枚葉処理対応
                                                ElseIf (lstrLotGrbClass <> vbNullString And .strDetailGrbClass <> vbNullString And _
                                                        lstrLotGrbClass <> .strDetailGrbClass) Then
                                                    
                                                    '@背景色をｸﾞﾚｰにする
                                                    Dim newStyle As CellStyle = vsfLotDetailList.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                                                    Dim cellRange As CellRange = vsfLotDetailList.GetCellRange(llngRowCnt, CMlngvsfLotDetailListColNo, _
                                                                        llngRowCnt, CMlngvsfLotDetailListColCommentFlag)
                                                    cellRange.Style = newStyle
                                                '@↑2020/01/22 (Wed) 11:38:41 Y.Yoneyama 「.Netへ反映未」 **************************************************                                                    

                                                Else
                                                    '@流動対象工程の場合
                                                
                                                    '@背景色変更(：白)
                                                    Dim newStyle As CellStyle = vsfLotDetailList.Styles.Add("CustomStyle_BackColor_vbWhite")
                                                    newStyle.BackColor = Color.White
                                                    Dim cellRange As CellRange = vsfLotDetailList.GetCellRange(llngRowCnt, CMlngvsfLotDetailListColNo, _
                                                                        llngRowCnt, CMlngvsfLotDetailListColCommentFlag)
                                                    cellRange.Style = newStyle
                                                
                                                End If
                                             End If
                                            
                                            '@大工程ID
                                            vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColOPID, .strOpID)
                                            
                                            '@小工程ID
                                            vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColStepID, .strStepID)
                                            
                                            '@作業開始/終了日時
                                            If .strStartTime = vbNullString Then
                                                '@作業開始日時が空白の場合
                                                
                                                '@ｽﾍﾟｰｽ1文字に置き換える
                                                lstrStartTime = Space(1)
                                            Else
                                                '@作業開始日時が空白以外の場合
                                                lstrStartTime = .strStartTime
                                            End If
                                            
                                            If .strEndTime = vbNullString Then
                                                '@作業終了日時が空白の場合
                                                
                                                '@ｽﾍﾟｰｽ1文字に置き換える
                                                lstrEndTime = Space(1)
                                            Else
                                                '@作業終了日時が空白以外の場合
                                                lstrEndTime = .strEndTime
                                            End If
                                            
                                            '@作業開始日時を設定
                                            vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColStartEndTime, lstrStartTime & vbCrLf & lstrEndTime)
                                            
                                            '@ﾚｼﾋﾟIDを設定
                                            vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColRecipeID, .strRecipeId)
                                            
                                            '@★★★ 装置の個数を判定 ★★★
                                            Select Case .lngWpListCount
                                                
                                                '@〓〓〓 装置が1台の場合 〓〓〓
                                                Case 1
                                                
                                                    '@装置名
                                                    vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColWPName, .typWpList(0).strWpName)
                                                    
                                                    '@***********************
                                                    '@ ﾎﾟｰﾄ名
                                                    '@***********************
                                                    '@★★★★ 作業終了済の工程かどうかを判定 ★★★★
                                                    Select Case CLng(.strSeqNum)
                                                        
                                                        '@〓〓〓〓 作業終了済の工程の場合 〓〓〓〓
                                                        Case Is < CLng(mstrCurrentSeqNum)
                                                        
                                                            '@ﾎﾟｰﾄが1個かどうかを判定
                                                            If .typWpList(0).lngPortIDCount = 1 Then
                                                                '@ﾎﾟｰﾄが1個の場合
                                                                lstrPortName = .typWpList(0).strPortName(0)
                                                            Else
                                                                '@ﾎﾟｰﾄが複数の場合(：ﾎﾟｰﾄ名に空白を設定)
                                                                lstrPortName = vbNullString
                                                            End If
                                                            
                                                            '@ﾎﾟｰﾄIDを設定
                                                            vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColPortID, lstrPortName)
                                                        
                                                        
                                                        '@〓〓〓〓 現在工程の場合 〓〓〓〓
                                                        Case CLng(mstrCurrentSeqNum)
                                                        
                                                            '@作業終了しているかどうかを判定する
                                                            If .strEndTime = vbNullString Then
                                                                
                                                                
                                                                '@★★★★★ ﾛｯﾄ状態により処理分岐 ★★★★★
                                                                Select Case lblStatus.Text
                                                                    
                                                                    '@〓〓〓〓〓 処理中、後処理の場合 〓〓〓〓〓
                                                                    Case CPstrProcessingSt, CPstrAfterProgressSt
                                                                        
                                                                        '@ﾎﾟｰﾄが1個かどうかを判定
                                                                        If .typWpList(0).lngPortIDCount = 1 Then
                                                                            '@ﾎﾟｰﾄが1個の場合
                                                                            lstrPortName = .typWpList(0).strPortName(0)
                                                                        Else
                                                                            '@ﾎﾟｰﾄが複数の場合(：ﾎﾟｰﾄ名に空白を設定)
                                                                            lstrPortName = vbNullString
                                                                        End If
                                                                    
                                                                        '@ﾎﾟｰﾄIDを設定
                                                                        vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColPortID, lstrPortName)
                                                                    
                                                                    
                                                                    '@〓〓〓〓〓 その他の場合 〓〓〓〓〓〓
                                                                    Case Else
                                                                        '@作業終了日時が空白(作業終了していない)場合
                                                                        
                                                                        '@ﾎﾟｰﾄIDに空白を設定
                                                                        vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColPortID, vbNullString)
                                                                
                                                                End Select
                                                            
                                                            Else
                                                                '@作業終了日時が空白以外(作業終了している)場合
                                                                
                                                                '@ﾎﾟｰﾄが1個かどうかを判定
                                                                If .typWpList(0).lngPortIDCount = 1 Then
                                                                    '@ﾎﾟｰﾄが1個の場合
                                                                    lstrPortName = .typWpList(0).strPortName(0)
                                                                Else
                                                                    '@ﾎﾟｰﾄが複数の場合(：ﾎﾟｰﾄ名に空白を設定)
                                                                    lstrPortName = vbNullString
                                                                End If
                                                                
                                                                '@ﾎﾟｰﾄIDを設定
                                                                vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColPortID, lstrPortName)
                                                            End If
                                                        
                                                        
                                                        '@〓〓〓〓 その他の場合 〓〓〓〓
                                                        Case Else
                                                            '@未処理の工程の場合
                                                            
                                                            '@ﾎﾟｰﾄIDに空白を設定
                                                            vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColPortID, vbNullString)
                                                    
                                                    End Select
                                                    
                                                    
                                                '@〓〓〓 装置が2台以上の場合 〓〓〓
                                                Case Is > 1
                                                
                                                    '@「n装置」を表示
                                                    vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColWPName, "【装置：" & CStr(.lngWpListCount) & "台】")
                                                    
                                                    '@ﾎﾟｰﾄIDに空白を設定
                                                    vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColPortID, vbNullString)
                                                                                          
                                                                                          
                                                '@〓〓〓 その他の場合 〓〓〓
                                                Case Else

                                                    '@装置名に空白を設定
                                                    vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColWPName, vbNullString)
                                                    
                                                    '@ﾎﾟｰﾄIDに空白を設定
                                                    vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColPortID, vbNullString)
                                                    
                                            End Select
                                            
                                            '@★★★ ﾃﾞｰﾀ収集有無 ★★★
                                            Select Case .strCollectionFlag
                                            
                                                '@〓〓〓 ﾃﾞｰﾀ収集ありの場合 〓〓〓
                                                Case CPstrOne
                                                
                                                    '@ありを設定
                                                    vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColCollectionFlag, CPstrCollectionDataAri)
                                                
                                                '@〓〓〓 ﾃﾞｰﾀ収集なしの場合 〓〓〓
                                                Case Else

                                                    '@空白を設定
                                                    vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColCollectionFlag, CPstrCollectionDataNashi)
                                            
                                            End Select
                                            
                                            '@ｷｬﾘｱID
                                            vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColCarrierID, .strCarrierId)
                                            
                                            '@WF枚数
                                            If IsNumeric(.strWfNum) Then
                                                vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColWFNum, Format$(CInt(.strWfNum), CPstrDateFormatKanma))
                                            Else
                                                vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColWFNum, .strWfNum)
                                            End If
                                            
                                            '@ﾁｯﾌﾟ良品数
                                            If IsNumeric(.strChipNum) Then
                                                vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColChipNum, Format$(CInt(.strChipNum), CPstrDateFormatKanma))
                                            Else
                                                vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColChipNum, .strChipNum)
                                            End If
                                            
                                            '@開始作業者名、終了作業者名
                                            If .strStartEmpName = vbNullString Then
                                                '@開始作業者名が空白の場合
                                                
                                                '@ｽﾍﾟｰｽ1文字に置き換える
                                                lstrStartEmpName = Space(1)
                                            Else
                                                '@開始作業者名が空白以外の場合
                                                lstrStartEmpName = .strStartEmpName
                                            End If
                                            
                                            If .strEndEmpName = vbNullString Then
                                                '@作業作業者名が空白の場合
                                                
                                                '@ｽﾍﾟｰｽ1文字に置き換える
                                                lstrEndEmpName = Space(1)
                                            Else
                                                '@作業作業者名が空白以外の場合
                                                lstrEndEmpName = .strEndEmpName
                                            End If
                                            
                                            vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColEmpName, lstrStartEmpName & vbCrLf & lstrEndEmpName)
                                            
                                            '@★★★ ﾛｯﾄｺﾒﾝﾄ有無 ★★★
                                            Select Case .strCommentFlag
                                            
                                                '@〓〓〓 ありの場合 〓〓〓
                                                Case CPstrOne

                                                    '@「あり」を設定
                                                    vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColCommentFlag, CPstrAriFlg)
                                                
                                                '@〓〓〓 なしの場合 〓〓〓
                                                Case Else

                                                    '@空白を設定
                                                    vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColCommentFlag, vbNullString)
                                            
                                            End Select
                                                
                                            '@ﾙｰﾌﾟｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                                            llngLoopCnt = llngLoopCnt + 1

                                    End Select

                                End With
                        
                        End Select
                    
                    Next llngRowCnt
                Else
                    '@ﾛｯﾄ流動票一覧情報がNULLの場合
                    
                    For llngRowCnt = llngStartRow To llngEndRow
                    
                        '@=======================
                        '@ 空白行挿入処理
                        '@=======================
                        Call prvvsfLotDetailListSpaceRowIns_Proc(llngRowCnt)

                    Next llngRowCnt
                End If
                
                '@ﾃﾞｰﾀがあるか
                If vsfLotDetailList.Rows.Count = vsfLotDetailList.Rows.Fixed Then
                    '@ﾃﾞｰﾀ行がない場合
                    
                    '@=======================
                    '@ ｸﾞﾘｯﾄﾞ表示の初期化
                    '@=======================
                    Call prvvsfLotDetailList_Init()
                    
                    '@ｺﾝﾄﾛｰﾙ無効
                    vsfLotDetailList.Enabled = False
                    cmdUP.Enabled = False
                    cmdDown.Enabled = False
                    cmdLeft.Enabled = False
                    cmdRight.Enabled = False
                    cmdLotComment.Enabled = False       'ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ
                    cmdWPRecipeList.Enabled = False     '装置ﾚｼﾋﾟ表示ﾎﾞﾀﾝ
                Else
                    '@ﾃﾞｰﾀ行がある場合

                    With vsfLotDetailList

                        '@列幅自動設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCols(CMlngvsfLotDetailListColOPID, _
                                  CMlngvsfLotDetailListColCommentFlag, 6)
                            
                        '@先頭行変更ﾌﾗｸﾞの判定
                        If lblnTopRowChange = True Then
                            
                            '@先頭行変更ﾌﾗｸﾞがTrueの場合
                            If CLng(mstrCurrentSeqNum) <> 0 Then
                                
                                '@最終工程以降かどうかを判定する
                                If CLng(mstrCurrentSeqNum) > CLng(ltypLotDetailList.strLastSeqNum) Then
                                    '@最終工程以降の場合
                                    '@最終工程を選択する
                                    RemoveHandler vsfLotDetailList.BeforeRowColChange,AddressOf vsfLotDetailList_BeforeRowColChange
                                    .Row = 0
                                    AddHandler vsfLotDetailList.BeforeRowColChange,AddressOf vsfLotDetailList_BeforeRowColChange
                                    .Row = CLng(ltypLotDetailList.strLastSeqNum)
                                Else
                                    '@最終工程以前の場合
                                    '@現在工程の行を選択する
                                    RemoveHandler vsfLotDetailList.BeforeRowColChange,AddressOf vsfLotDetailList_BeforeRowColChange
                                    .Row = 0
                                    AddHandler vsfLotDetailList.BeforeRowColChange,AddressOf vsfLotDetailList_BeforeRowColChange
                                    .Row = CLng(mstrCurrentSeqNum)
                                End If
                            Else
                                RemoveHandler vsfLotDetailList.BeforeRowColChange,AddressOf vsfLotDetailList_BeforeRowColChange
                                .Row = 0
                                AddHandler vsfLotDetailList.BeforeRowColChange,AddressOf vsfLotDetailList_BeforeRowColChange

                                '@先頭行を選択する
                                .Row = .Rows.Fixed
                            End If
                            
                            '@=======================
                            '@ ｶﾚﾝﾄ行を真ん中に表示
                            '@=======================
                            Call pubVsfBeforeSort(vsfLotDetailList, CMlngvsfLotDetailListColNo)
                            RemoveHandler vsfLotDetailList.AfterScroll,AddressOf vsfLotDetailList_AfterScroll
                            Call pubVsfAfterSort(vsfLotDetailList, CMlngvsfLotDetailListColNo, cmdUP, cmdDown)
                            AddHandler vsfLotDetailList.AfterScroll,AddressOf vsfLotDetailList_AfterScroll
                        End If
                    End With
                    
                    '@ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ有効
                    vsfLotDetailList.Enabled = True
                    
                    '@=======================
                    '@ 上下ｽｸﾛｰﾙﾎﾞﾀﾝ("▲"、"▼")初期化処理
                    '@=======================
                    Call pubVsfDisp(vsfLotDetailList, cmdUP, cmdDown)
                    
                    With vsfLotDetailList

                        '@退避した横ｽｸﾛｰﾙ位置を復元する
                        .LeftCol = llngLeftCol

                        'NSYS 左右ｽｸﾛｰﾙﾎﾞﾀﾝ使用可否制御
                        Call pubCmdLREnable_Set(vsfLotDetailList, cmdLeft, cmdRight)

                    End With
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotDetailList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN01G0_Init
    '機　能：画面初期設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 11:53:46 H.Wajima
    '更新日：2004/10/21 (Thu) 11:53:46
    '備　考：
    Private Sub prvfrmxxEN01G0_Init()

        Dim lstrFormTitle           As String   'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01G0, _
                                            lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            '@ﾍｯﾀﾞ情報初期化
            Call prvHeaderInfoInit_Proc()

            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfLotDetailList_Init()

            '@ﾎﾞﾀﾝ非活性化
            cmdUP.Enabled = False               '▲ﾎﾞﾀﾝ
            cmdDown.Enabled = False             '▼ﾎﾞﾀﾝ
            cmdLeft.Enabled = False             '≪ﾎﾞﾀﾝ
            cmdRight.Enabled = False            '≫ﾎﾞﾀﾝ
            cmdLotComment.Enabled = False       'ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ
            cmdWPRecipeList.Enabled = False     '装置ﾚｼﾋﾟ表示ﾎﾞﾀﾝ
            
            '@退避ｷｬﾘｱID初期化
            mstrTaihiCarrierID = vbNullString
            '@退避ﾛｯﾄID初期化
            mstrTaihiLotID = vbNullString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01G0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvHeaderInfoInit_Proc
    '機　能：ﾍｯﾀﾞ情報初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 11:55:47 H.Wajima
    '更新日：2004/10/21 (Thu) 11:55:47
    '備　考：
    Private Sub prvHeaderInfoInit_Proc()

        Try
            
            '@流動票取得ﾌﾗｸﾞにFalseを設定する
            mblnLotDetailListGet = False

            '@数量
            lblWFNo.Text = vbNullString
            '@機種
            lblPd.Text = vbNullString
            '@大工程ID
            lblOpID.Text = vbNullString
            '@保留
            lblHold.Text = vbNullString
            '@状態
            lblStatus.Text = vbNullString
            '@小工程
            lblStepID.Text = vbNullString
            '@情報取得日時
            lblNowDate.Text = vbNullString
            '@該当件数
            lblLotCnt.Text = vbNullString
            '@最新取得ﾎﾞﾀﾝ
            cmdLotSearch.Enabled = False
                
            '@有効ｺﾝﾄﾛｰﾙ名の判定
            Select Case mstrActiveControlName
                '@ｷｬﾘｱID
                Case CMstrActiveControlNameCarrierID
                    txtLotID.Text = vbNullString                        'ﾛｯﾄID
                    '@退避ｷｬﾘｱID初期化
                    mstrTaihiCarrierID = vbNullString
                '@ﾛｯﾄID
                Case CMstrActiveControlNameLotID
                    txtCarrierID.Text = vbNullString                    'ｷｬﾘｱID
                    '@退避ﾛｯﾄID初期化
                    mstrTaihiLotID = vbNullString
                Case Else
                    txtLotID.Text = vbNullString                        'ﾛｯﾄID
                    '@退避ﾛｯﾄID初期化
                    mstrTaihiLotID = vbNullString
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvHeaderInfoInit_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2007/07/06 (Fri) 13:08:41 N.Kasai **************************************************
    ''関数名：prvcmdLeft_Proc
    ''機　能：ｸﾞﾘｯﾄﾞの左項目ｽｸﾛｰﾙｸﾘｯｸ処理
    ''引　数：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    ''　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    ''　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    ''戻り値：なし
    ''作成日：2004/07/23 (Fri) 15:17:04 N.Kasai
    ''更新日：2004/07/23 (Fri) 15:17:04
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
    '    With lobjvsfGrid
    '
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
    ''作成日：2004/07/23 (Fri) 15:18:57 N.Kasai
    ''更新日：2004/07/23 (Fri) 15:18:57
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
    '    With lobjvsfGrid
    '
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
    '        llngWidth = llngWidthAll - llngWidthHide + 75
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
    '
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
    ''関数名：prvvsfSideKeyDown_Proc
    ''機　能：ｸﾞﾘｯﾄﾞｷｰ制御
    ''引　数：lintKeyCode：ｷｰｺｰﾄﾞ
    ''　　　：lstrActiveCtlNm：ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名
    ''　　　：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    ''　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    ''　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    ''戻り値：なし
    ''作成日：2004/10/21 (Thu) 16:22:48 H.Wajima
    ''更新日：2004/10/21 (Thu) 16:22:48
    ''備　考：
    'Public Sub prvvsfSideKeyDown_Proc(ByRef lintKeyCode As Integer, _
    '                                  ByVal lstrActiveCtlNm As String, _
    '                                  ByVal lobjvsfGrid As Object, _
    '                                  Optional ByVal lobjcmdLeft As Object = Nothing, _
    '                                  Optional ByVal lobjcmdRight As Object = Nothing)
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
    '    With lobjvsfGrid
    '
    '        Select Case lstrActiveCtlNm
    '            '@ｸﾞﾘｯﾄﾞﾌｫｰｶｽがある場合
    '            Case .Name
    '
    '                Select Case lintKeyCode
    '                   '@ｸﾞﾘｯﾄﾞｷｰ制御([←]ｷｰﾎﾞﾀﾝ)
    '                    Case vbKeyLeft
    '
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
    '
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
    '                        For llngloopcount = 0 To .Cols - 1
    '                            If .ColHidden(llngloopcount) <> True Then
    '                                llngWidthAll = llngWidthAll + .ColWidth(llngloopcount)
    '                            End If
    '                        Next llngloopcount
    '
    '                        '@ｽｸﾛｰﾙ制御用幅計算
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
    '                            If llngActiveCol = .Cols - 1 Then
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
    '        .strProcName = "prvvsfSideKeyDown_Proc"
    '        .strErrMessage = vbNullString
    '    End With
    '
    '    '@共通ｴﾗｰ処理
    '    Call pubOnError_Proc
    '
    'End Sub
    '@↑2007/07/06 (Fri) 13:08:41 N.Kasai **************************************************

    '関数名：pubblnvsfPageMsgGet_Chk
    '機　能：ｸﾞﾘｯﾄﾞ共通 ﾍﾟｰｼﾞ毎ﾒｯｾｰｼﾞ取得判定処理
    '引　数：llngOldRow：変更前行番号(BeforeRowColChangeのOldRow)
    '　　　：llngNewRow：変更後行番号(BeforeRowColChangeのNewRow)
    '　　　：llngLastTopRow：前回TopRow(RowColChange処理に変数にｸﾞﾘｯﾄﾞのTopRowの値を保存しておく)
    '　　　：llngNowTopRow：現在TopRow(関数呼び出し時点のｸﾞﾘｯﾄﾞのTopRow)
    '　　　：lstrMinLastSeqNum：前回Msg取得時の最小ｷｰ値
    '　　　：lstrMaxLastSeqNum：前回Msg取得時の最大ｷｰ値
    '　　　：lstrNewSeqNum：次回Msg取得時のｷｰ値
    '　　　：lblnMsgGetStatus：ﾒｯｾｰｼﾞ再取得要･不要ｽﾃｰﾀｽ(True：再取得必要、False：再取得不要)
    '戻り値：True：正常終了、False：異常終了
    '作成日：2004/10/25 (Mon) 15:42:33 H.Wajima
    '更新日：2004/10/25 (Mon) 15:42:33
    '備　考：ﾍﾟｰｼﾞ毎にMsgを取得して一覧の表示情報を更新する場合に、Msgの再取得が必要かどうかを判定する。
    '　　　：該当のVSFlexGridのBeforeRowColChange処理で、当関数を使用して判定をすること。
    Public Function pubblnvsfPageMsgGet_Chk(ByRef llngOldRow As Integer, _
                                            ByRef llngNewRow As Integer, _
                                            ByRef llngLastTopRow As Integer, _
                                            ByRef llngNowTopRow As Integer, _
                                            ByRef lstrMinLastSeqNum As String, _
                                            ByRef lstrMaxLastSeqNum As String, _
                                            ByRef lstrNewSeqNum As String, _
                                            ByRef lblnMsgGetStatus As Boolean) As Boolean

        Try
                
                '@当関数の戻り値にFalseを設定する
                pubblnvsfPageMsgGet_Chk = False
                
                '@ﾒｯｾｰｼﾞ取得ｽﾃｰﾀｽﾌﾗｸﾞにFalseを設定する
                lblnMsgGetStatus = False
                
                '@変更前行と変更後行の判定
                Select Case llngNewRow
                    Case llngOldRow
                        '@行が変更されていない場合
                        
                    Case Is > llngOldRow
                        '@下向きに移動した場合
                        '@先頭行の判定
                        Select Case llngNowTopRow
                            Case llngLastTopRow
                                '@先頭行が変更されていない場合

                            Case Is > llngLastTopRow
                                '@下向きに移動した場合
                                '@SeqNumの判定
                                Select Case True
                                    Case lstrNewSeqNum = vbNullString, CLng(lstrNewSeqNum) > CLng(lstrMaxLastSeqNum)
                                        '@変更先の行のSeqNumが空か、前回取得した最大SeqNumよりも大きい場合
                                        '@ﾒｯｾｰｼﾞ取得ｽﾃｰﾀｽﾌﾗｸﾞにTrueを設定する
                                        lblnMsgGetStatus = True
                                        
                                End Select
                        End Select
                    
                    Case Is < llngOldRow
                        Select Case llngNowTopRow
                            Case llngLastTopRow
                                '@先頭行が変更されていない場合
                                
                            Case Is < llngLastTopRow
                                '@上向きに移動した場合
                                
                                '@SeqNumの判定
                                Select Case True
                                    Case lstrNewSeqNum = vbNullString, _
                                        CLng(lstrNewSeqNum) < CLng(lstrMinLastSeqNum)
                                        '@変更先の行のSeqNumが空か、前回取得した最小SeqNumよりも小さい場合
                                        
                                        '@ﾒｯｾｰｼﾞ取得ｽﾃｰﾀｽﾌﾗｸﾞにTrueを設定する
                                        lblnMsgGetStatus = True
                                                                        
                                        
                                End Select
                        End Select
                End Select

                '@当関数の戻り値にTrueを設定する
                pubblnvsfPageMsgGet_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "pubblnvsfPageMsgGet_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvcmdEnabled_Proc
    '機　能：ｺﾏﾝﾄﾞﾎﾞﾀﾝ有効無効 初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/28 (Thu) 11:29:22 H.Wajima
    '更新日：2005/11/02 (Wed) 08:53:17 N.Kasai
    '備　考：
    '　　　：2005/11/02 (Wed) 08:53:17 N.Kasai      装置ﾚｼﾋﾟﾎﾞﾀﾝ使用可能条件追加
    Private Sub prvcmdEnabled_Proc()

        Try

            With vsfLotDetailList

                'NSYS データ行がない場合は処理を抜ける
                If .Rows.Count <= .Rows.Fixed Then
                    Return
                End If
                
                '@選択行が、0か-1の場合は処理を抜ける
                Select Case .Row
                    
                    '@0か-1の場合
                    Case CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListAll
                        
                        Exit Sub
                                
                    '@上記以外の場合
                    Case Else

                        '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝの有効・無効判定
                        Select Case .Row
                            
                            '@ﾀｲﾄﾙ行が選択されているか、行が選択されていない場合
                            Case CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListAll
                                
                                '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ無効
                                cmdLotComment.Enabled = False
                            
                            '@上記以外の場合
                            Case Else
                                
                                If .GetData(.Row, CMlngvsfLotDetailListColCommentFlag) = CPstrAriFlg Then
                                    '@選択行のｺﾒﾝﾄ列の内容が「あり」の場合
                                    
                                    '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ有効
                                    cmdLotComment.Enabled = True
                                Else
                                    '@選択行のｺﾒﾝﾄ列の内容が「あり」以外の場合
                                    
                                    '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ無効
                                    cmdLotComment.Enabled = False
                                End If

                        End Select
                        
                        '@装置ﾚｼﾋﾟﾎﾞﾀﾝの有効・無効判定
                        If IsNumeric(.GetData(.Row, CMlngvsfLotDetailListColNo)) = True Then
                            
                            Select Case .Row
                                
                                '@ﾀｲﾄﾙ行が選択されているか、行が選択されていない場合
                                Case CMlngvsfLotDetailListTRow, CMlngvsfLotDetailListAll
                                
                                    '@装置ﾚｼﾋﾟﾎﾞﾀﾝ無効
                                    cmdWPRecipeList.Enabled = False
                                
                                '@上記以外の場合
                                Case Else
                                
                                    '@-----------------------------------------------
                                    '@  装置ﾚｼﾋﾟ表示ﾎﾞﾀﾝ使用可能条件
                                    '@　工程ｽｷｯﾌﾟ以外は全て使用可能(予定、現、実績)
                                    '@-----------------------------------------------
                                    If .GetData(.Row, CMlngvsfLotDetailListColWPName) <> vbNullString Then
                                        '@選択行が未処理の工程の場合
                                        
                                        '@装置ﾚｼﾋﾟﾎﾞﾀﾝ有効
                                        cmdWPRecipeList.Enabled = True
                                    Else
                                        '@選択行が処理済の工程の場合
                                        
                                        '@装置ﾚｼﾋﾟﾎﾞﾀﾝ無効
                                        cmdWPRecipeList.Enabled = False
                                    End If

                            End Select
                        End If
                End Select
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdEnabled_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotDetailListSpaceRowIns_Proc
    '機　能：空白行挿入処理
    '引　数：llngRowCnt：行番号
    '戻り値：なし
    '作成日：2004/11/10 (Wed) 19:29:31 H.Wajima
    '更新日：2004/11/10 (Wed) 19:29:31
    '備　考：
    Private Sub prvvsfLotDetailListSpaceRowIns_Proc(ByVal llngRowCnt As Integer)

        Try
            
            '@№
            vsfLotDetailList.SetData(llngRowCnt, CMlngvsfLotDetailListColNo, llngRowCnt)
                    
            '@現在工程と比較
            If llngRowCnt = CLng(mstrCurrentSeqNum) Then
            '@現在工程の場合
                '@背景色変更
                Dim newStyle As CellStyle = vsfLotDetailList.Styles.Add("CustomStyle_BackColor_CMlngCurrentSeqColor")
                newStyle.BackColor = ColorTranslator.FromWin32(CMlngCurrentSeqColor)
                Dim cellRange As CellRange = vsfLotDetailList.GetCellRange(llngRowCnt, _
                                        CMlngvsfLotDetailListColNo, _
                                        llngRowCnt, _
                                        CMlngvsfLotDetailListColCommentFlag)
                cellRange.Style = newStyle
            Else
            '@現在工程以外の場合
                '@背景色変更
                Dim newStyle2 As CellStyle = vsfLotDetailList.Styles.Add("CustomStyle_BackColor_vbWhite")
                newStyle2.BackColor = Color.White
                Dim cellRange2 As CellRange = vsfLotDetailList.GetCellRange(llngRowCnt, _
                                        CMlngvsfLotDetailListColNo, _
                                        llngRowCnt, _
                                        CMlngvsfLotDetailListColCommentFlag)
                cellRange2.Style = newStyle2
            End If
            
            With vsfLotDetailList
                '@大工程ID
                .SetData(llngRowCnt, CMlngvsfLotDetailListColOPID, vbNullString)
                '@小工程ID
                .SetData(llngRowCnt, CMlngvsfLotDetailListColStepID, vbNullString)
                '@作業開始日時を設定
                .SetData(llngRowCnt, CMlngvsfLotDetailListColStartEndTime, vbNullString)
                '@装置名
                .SetData(llngRowCnt, CMlngvsfLotDetailListColWPName, vbNullString)
                '@ﾎﾟｰﾄ名を設定
                .SetData(llngRowCnt, CMlngvsfLotDetailListColPortID, vbNullString)
                '@ﾚｼﾋﾟIDを設定
                .SetData(llngRowCnt, CMlngvsfLotDetailListColRecipeID, vbNullString)
                '@ﾃﾞｰﾀ収集有無
                .SetData(llngRowCnt, CMlngvsfLotDetailListColCollectionFlag, vbNullString)
                '@ｷｬﾘｱID
                .SetData(llngRowCnt, CMlngvsfLotDetailListColCarrierID, vbNullString)
                '@WF枚数
                .SetData(llngRowCnt, CMlngvsfLotDetailListColWFNum, vbNullString)
                '@ﾁｯﾌﾟ良品数
                .SetData(llngRowCnt, CMlngvsfLotDetailListColChipNum, vbNullString)
                '@開始作業者名、終了作業者名
                .SetData(llngRowCnt, CMlngvsfLotDetailListColEmpName, vbNullString)
                '@ﾛｯﾄｺﾒﾝﾄ有無
                .SetData(llngRowCnt, CMlngvsfLotDetailListColCommentFlag, vbNullString)
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotDetailListSpaceRowIns_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：cmdUseRecpList_Click
    '機　能：装置ﾚｼﾋﾟ表示ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/10/31 (Mon) 11:40:16 N.Kasai
    '更新日：2005/10/31 (Mon) 11:40:16
    '備　考：
    Private Sub cmdWPRecipeList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWPRecipeList.Click

        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns             As Boolean              '戻り値(汎用)
        Dim ltypUseRecpRec      As UseRecpRec           '構造体(要求格納)
        Dim ltypUseRecpAns      As UseRecpAns           '構造体(応答格納)
        Dim ltypUseRecpList     As UseRecpList          '構造体(引き渡し)
        Dim lstrCarrierID       As String               'ｷｬﾘｱID
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdWPRecipeList_Click"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾚｼﾋﾟ情報取得要求構造体格納
            With ltypUseRecpRec
                .strMsgVer = CMstrlot_userecp_Ver                                                              'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                                                                            'SBID
                .strOpID = vsfLotDetailList.GetData(vsfLotDetailList.Row, CMlngvsfLotDetailListColOPID)        '大工程
                .strStepID = vsfLotDetailList.GetData(vsfLotDetailList.Row, CMlngvsfLotDetailListColStepID)    '小工程
                .strLotID = txtLotID.Text                                                                      'ﾛｯﾄID
            End With

            '@【ﾚｼﾋﾟ情報取得】
            lblnAns = pubblnLotUseRecp_Sel(ltypUseRecpRec, ltypUseRecpAns)
            
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            '@画面引渡し構造体の初期化
            ptypUseRecpList = ltypUseRecpList
            
            '@ｷｬﾘｱIDを取得
            With vsfLotDetailList
                If .GetData(.Row, CMlngvsfLotDetailListColCarrierID) <> vbNullString Then                      'ｷｬﾘｱID
                    lstrCarrierID = .GetData(.Row, CMlngvsfLotDetailListColCarrierID)
                Else
                    lstrCarrierID = txtCarrierID.Text
                End If
            End With
            
            '@画面引渡し用構造体に格納
            With ptypUseRecpList
                .strCarrierId = lstrCarrierID               'ｷｬﾘｱID
                .strLotID = txtLotID.Text                   'ﾛｯﾄID
                .strOpID = ltypUseRecpRec.strOpID           '大工程
                .strStepID = ltypUseRecpRec.strStepID       '小工程
                .typUseRecpAns = ltypUseRecpAns             'ﾚｼﾋﾟ情報
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            
            '@装置ﾚｼﾋﾟ表示画面をLoadする
            frmxxEN01G1.Instance = New frmxxEN01G1()

            '@装置ﾚｼﾋﾟ表示画面を表示する
            frmxxEN01G1.Instance.ShowDialog(Me)
            frmxxEN01G1.Instance = Nothing

            '@ﾌｫｰｶｽをｸﾞﾘｯﾄﾞへ
            Call pubSetFocus(vsfLotDetailList)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWPRecipeList_Click"
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfLotDetailList.BeforeDoubleClick

        mblnAfterScrollFag = True
        
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

    '関数名：vsfLotDetailList_AfterScroll
    '機　能：グリッドスクロール時の動作
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/07/24 (Wed) 10:00:00 NSYS
    '備　考：
    Private Sub vsfLotDetailList_AfterScroll(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotDetailList.AfterScroll


        If mblnAfterScrollFag = True Then
            mblnAfterScrollFag = False
            Exit Sub
        End If

        '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
        If Cursor.Current = Cursors.WaitCursor Then
            Exit Sub
        End If

        If e.OldRange.TopRow = e.NewRange.TopRow Then
            'NSYS 上下方向の変化なしの場合、データを読み込まない。
            Exit Sub
        End If

        '@ｽｸﾛｰﾙ後の先頭行保持（ｸﾞﾘｯﾄﾞ）
        Call pubVsfAfterScroll(vsfLotDetailList)

        '@流動票最新取得処理を実行する
        prvblnLotDetailListGet_Proc(txtCarrierID.Text, _
                                                txtLotID.Text, _
                                                CStr(vsfLotDetailList.TopRow), _
                                                CMstrLotDetailListNum16, _
                                                CMstrLotDetailListNum16)
        If vsfLotDetailList.BottomRow = vsfLotDetailList.Rows.Count -1 Then
            cmdDown.Enabled = False
        End If

    End Sub
End Class
