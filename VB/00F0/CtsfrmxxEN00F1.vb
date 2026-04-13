'ﾌｧｲﾙ名：xxEN00F1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：在庫保留/保留解除(在庫管理サブフォーム)
'作成日：2004/06/29 (Tue) 11:03:06 N.Kasai
'更新日：2008/06/24 (Tue) 15:59:21 N.Kojima
'備　考：
'　　　：2005/04/18 (Mon) 09:56:03 S.Deguchi    不具合№688の対応で複数保留用画面ﾚｲｱｳﾄ変更
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00F1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00F1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00F1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00F1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00F1)
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
    '@機能ID
    Private Const CMstrLocalMenuKey                         As String = CPstrKeyEN00F1      'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_holdinfoVer                      As String = "03.00"             'ﾛｯﾄ保留情報
    Private Const CMstrlot_hold____Ver                      As String = "02.01"             'ﾛｯﾄ保留設定
    Private Const CMstrlot_holdreleaseVer                   As String = "03.00"             'ﾛｯﾄ保留解除
    Private Const CMstrinv_changstateVer                    As String = "03.01"             '在庫状態変更
    Private Const CMstrmas_reasoncodeVer                    As String = "02.00"             '理由ｺｰﾄﾞ取得
    Private Const CMstrmas_emplist_Ver                      As String = "02.00"             '保留責任者ﾘｽﾄ取得
    Private Const CMstrmas_roleemplistVer                   As String = "01.00"             '職制社員ﾘｽﾄ取得

    Private Const CMlngHold                                 As Integer = 0                  '保留起動
    Private Const CMlngHoldRelease                          As Integer = 1                  '保留解除
    Private Const CMlngIndex                                As Integer = 1                  'ｽﾃｰﾀｽﾊﾞｰﾒｯｾｰｼﾞｲﾝﾃﾞｯｸｽ
    Private Const CMlngChrMaxByteHold                       As Integer = 1500               'ｺﾒﾝﾄﾊﾞｲﾄ数制限(保留)
    Private Const CMlngChrMaxByteCancel                     As Integer = 2048               'ｺﾒﾝﾄﾊﾞｲﾄ数制限(保留解除)
    Private Const CMstrRestrictFlag0                        As String = "0"                 '制限ﾌﾗｸﾞ(=0)
    Private Const CMstrRestrictFlag1                        As String = "1"                 '制限ﾌﾗｸﾞ(=1)
    Private Const CMstrRestrictFlag2                        As String = "2"                 '制限ﾌﾗｸﾞ(=2)
    Private Const CMlngMaxDispRow                           As Integer = 3                  'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@保留理由ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                          As Integer = 11                 'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                      As Integer = 11                 'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColHoldName                   As Integer = 0                  '保留理由列番
    Private Const CMlngCmbGridColHoldID                     As Integer = 1                  '保留理由ID列番(非表示項目)
    Private Const CMlngCmbSortAsc                           As Integer = 1                  '昇順(ｿｰﾄ)
    Private Const CMlngCmbDispCols                          As Integer = 1                  'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                         As Integer = 18                 'ﾘｽﾄ行の高さ
    Private Const CMlngCmbFirstListIndex                    As Integer = 0                  '1件目のﾃﾞｰﾀ表示用
    Private Const CMlngTab1                                 As Integer = 1                  'ﾀﾌﾞﾌﾗｸﾞ(0:受入　1:保留　2:中間　3:完成)

    '@ﾛｯﾄｲﾍﾞﾝﾄID
    Private Const CMstrHoldID                               As String = "8"                 '保留ｺｰﾄﾞ(="8")
    Private Const CMstrHoldCancelID                         As String = "9"                 '保留解除ｺｰﾄﾞ(="9")

    '@表示ﾒｯｾｰｼﾞ
    Private Const CMstrHold                                 As String = "保留責任者"
    Private Const CMstrLotManager                           As String = "ロット担当"
    Private Const CMstrEmp                                  As String = "作業者"

    '@ﾌｫｰﾏｯﾄ定数宣言
    Private Const CMlngFormatStart                          As Integer = 1                     'Mid取得先頭数(=1)
    Private Const CMlngFormatMid9                           As Integer = 9                     'Mid取得=9文字

    '@vsfLotHoldListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfLotHoldListColNo                  As Integer = 0                     '№
    Private Const CMlngvsfLotHoldListColHoldSDate           As Integer = 1                     '保留開始日
    Private Const CMlngvsfLotHoldListColEntryTime           As Integer = 2                     '保留日(詳細表記用)
    Private Const CMlngvsfLotHoldListColHoldEDate           As Integer = 3                     '保留期限
    Private Const CMlngvsfLotHoldListColHoldEDateL          As Integer = 4                     '保留期限(西暦表示)
    Private Const CMlngvsfLotHoldListColHoldTerm            As Integer = 5                     '保留期間
    Private Const CMlngvsfLotHoldListColHoldReasonID        As Integer = 6                     '保留理由ID
    Private Const CMlngvsfLotHoldListColHoldReason          As Integer = 7                     '保留理由
    Private Const CMlngvsfLotHoldListColHoldEmpID           As Integer = 8                     '保留責任者ID
    Private Const CMlngvsfLotHoldListColHoldEmpName         As Integer = 9                     '保留責任者名
    Private Const CMlngvsfLotHoldListColHoldComments        As Integer = 10                    '保留ｺﾒﾝﾄ内容
    Private Const CMlngvsfLotHoldListColRestrictFlag        As Integer = 11                    '制限ﾌﾗｸﾞ

    '@vsfLotHoldListの定数宣言(表示幅)
    Private Const CMlngvsfLotHoldListColWNo             As Integer = 33                     '№
    Private Const CMlngvsfLotHoldListColWHoldSDate      As Integer = 140                    '保留開始日
    Private Const CMlngvsfLotHoldListColWEntryTime      As Integer = 140                    '保留日(詳細表記用)
    Private Const CMlngvsfLotHoldListColWHoldEDate      As Integer = 140                    '保留期限
    Private Const CMlngvsfLotHoldListColWHoldEDateL     As Integer = 140                    '保留期限(西暦表示)
    Private Const CMlngvsfLotHoldListColWHoldTerm       As Integer = 140                    '保留期間
    Private Const CMlngvsfLotHoldListColWHoldReasonID   As Integer = 140                    '保留理由ID
    Private Const CMlngvsfLotHoldListColWHoldReason     As Integer = 140                    '保留理由
    Private Const CMlngvsfLotHoldListColWHoldEmpID      As Integer = 140                    '保留責任者ID
    Private Const CMlngvsfLotHoldListColWHoldEmpName    As Integer = 140                    '保留責任者名
    Private Const CMlngvsfLotHoldListColWHoldComments   As Integer = 140                    '保留ｺﾒﾝﾄ内容
    Private Const CMlngvsfLotHoldListColWRestrictFlag   As Integer = 140                    '制限ﾌﾗｸﾞ

    '@vsfLotHoldListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfLotHoldListColNo                  As String = "№"                '№
    Private Const CMstrvsfLotHoldListColHoldSDate           As String = "保留開始日"        '保留開始日
    Private Const CMstrvsfLotHoldListColEntryTime           As String = "EntryTime"         '保留日(詳細表記用)
    Private Const CMstrvsfLotHoldListColHoldEDate           As String = "保留期限"          '保留期限
    Private Const CMstrvsfLotHoldListColHoldEDateL          As String = "期限西暦"          '保留期限(西暦表示)
    Private Const CMstrvsfLotHoldListColHoldTerm            As String = "保留期間"          '保留期間
    Private Const CMstrvsfLotHoldListColHoldReasonID        As String = "保留理由ID"        '保留理由ID
    Private Const CMstrvsfLotHoldListColHoldReason          As String = "保留理由"          '保留理由
    Private Const CMstrvsfLotHoldListColHoldEmpID           As String = "保留責任者ID"      '保留責任者ID
    Private Const CMstrvsfLotHoldListColHoldEmpName         As String = "保留責任者"        '保留責任者名
    Private Const CMstrvsfLotHoldListColHoldComments        As String = "保留内容"          '保留ｺﾒﾝﾄ内容
    Private Const CMstrvsfLotHoldListColRestrictFlag        As String = "制限フラグ"        '制限ﾌﾗｸﾞ

    '@vsfLotHoldListのその他定数宣言
    Private Const CMlngvsfLotHoldListRowTitle               As Integer = 0                     '行ﾀｲﾄﾙ
    Private Const CMlngvsfLotHoldListColTitle               As Integer = 0                     '列ﾀｲﾄﾙ
    Private Const CMlngvsfLotHoldListHHeight                As Integer = 20                    'ﾍｯﾀﾞｰ高さ
    Private Const CMlngvsfLotHoldListHeight                 As Integer = 24                    '行高さ
    Private Const CMlngvsfLotHoldListHFontSize              As Integer = 11                    'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ：11
    Private Const CMlngvsfLotHoldListFontSize               As Integer = 11                    'ﾌｫﾝﾄｻｲｽﾞ：11

    '@その他定数宣言
    Private Const CMlngEmpMaxByte7                          As Integer = 7                     '作業者ID：文字列数

    '@画面ﾀｲﾄﾙ表示定数宣言
    Private Const CMstrHoldLabelTitle                       As String = "保留コメント"
    Private Const CMstrHoldReleaseLabelTitle                As String = "保留解除コメント"
    Private Const CMstrHoldFrameTitle                       As String = "保留設定"
    Private Const CMstrHoldReleaseFrameTitle                As String = "保留解除設定"

    Private ReadOnly vbWindowBackground As Color = SystemColors.Window                      'NSYS Windowsの背景色
    Private ReadOnly vbButtonFace As Color = SystemColors.ControlLight                      'NSYS ボタンの背景色

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mlngHoldMode                                    As Integer                      '保留ﾓｰﾄﾞ(0：保留、1：保留解除)
    Private mstrClassDivision                               As String                       '処理区分(14：保留設定、15：保留解除)
    Private mstrLotLastUpdate                               As String                       'ﾛｯﾄ最終更新日時
    Private mstrCarrier                                     As String                       'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mtypMasItemList                                 As MasItemList                  '保留理由構造体
    Private mlngTabFlag                                     As Integer                      'ﾀﾌﾞﾌﾗｸﾞ(0:受入　1:保留　2:中間　3:完成)
    Private mblnCngtxtEmpID                                 As Boolean                      '保留担当者ID変更ﾌﾗｸﾞ
    Private mblnFormLoadFlag                                As Boolean                      'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：起動時以外/False：起動時のみ)
    Private mtypLotHoldInfoList                             As LotHoldInfoList              'ﾛｯﾄ保留情報取得構造体
    Private mtypHoldEmpList                                 As List(Of TechManList)                  '保留責任者ﾘｽﾄ格納用
    Private mlngHoldEmpListCnt                              As Integer                      '保留責任者ﾘｽﾄｶｳﾝﾄ
    Private mstrHoldEmpID                                   As String                       '保留責任者ID退避領域
    Private mstrLotManagerID                                As String                       'ﾛｯﾄ担当者ID格納領域
    Private mstrLotManagerName                              As String                       'ﾛｯﾄ担当者名格納領域
    Private mstrPDID                                        As String                       '機種格納領域
    Private mstrOpID                                        As String                       '大工程格納領域
    Private mstrStepID                                      As String                       '小工程格納領域

    Private buttonProcessing                                As Boolean                      'NSYS ボタン2度押し対策
    Private mblnWindowClose                                 As Boolean                      'NSYS WindowCloseフラグ 
    Private mblnCloseFromControlMenu                        As Boolean                          'NSYS システムコマンドでの画面クローズ  
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
    '機　能：画面起動
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 19:47:33 N.Kasai
    '更新日：2004/06/29 (Tue) 19:47:33
    '備　考：
    Private Sub Form_Load()
        
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns                 As Boolean              'ﾛｯﾄ保留理由取得戻り値(True/False)

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@画面初期化
            Call prvfrmxxEN00F1_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@ﾛｯﾄ保留情報の取得
            lblnAns = pubblnLotHoldinfo_Sel(CMstrlot_holdinfoVer,
                                            ptypHoldConnect.strLotID,
                                            mtypLotHoldInfoList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If
                        
            '@ﾛｯﾄ保留理由取得結果
            lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer,
                                             CPstrCD2U,
                                             mtypMasItemList)
            '@結果判定
            If lblnAns = False Then
            '@失敗の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@異常の場合終了
                Exit Sub
            End If

            '@【作業者ﾘｽﾄ(保留責任者ﾘｽﾄ)取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasEmplist_Sel(CMstrmas_emplist_Ver, _
                                           mtypHoldEmpList, _
                                           mlngHoldEmpListCnt)
            '@結果判定
            If lblnAns = False Then
            '@失敗の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@異常の場合終了
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

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

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/07 (Thu) 08:32:38 S.Deguchi
    '更新日：2005/07/07 (Thu) 08:32:38
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@保留Combo作成
                Call prvcmbMasHoldList_Disp()

                '@保留ﾘｽﾄ設定
                Call prvvsfLotHoldList_Disp(mtypLotHoldInfoList)
            
                '@画面表示処理
                Call prvfrmxxEN00F1_Disp()
                
                '@ｾｯﾄﾌｫｰｶｽ処理
                If vsfLotHoldList.Enabled = True Then
                    '@保留一覧へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfLotHoldList)
                Else
                    If cmbMasHold.Enabled = True Then
                        '@保留理由へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbMasHold)
                    End If
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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰｶｽ制御
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:15:32 N.Kasai
    '更新日：2004/06/30 (Wed) 13:15:32
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

            '@ｸﾞﾘｯﾄﾞｷｰ制御
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfLotHoldList)
            
            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    Select Case ActiveControl.Name
                        '@保留/保留解除ｺﾒﾝﾄ
                        Case txtHoldComment.Name
                            '@保留/保留解除ｺﾒﾝﾄは改行がある為、Enterでﾌｫｰｶｽ移動しない
                            Exit Sub
                    End Select
                    
                    SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True
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
    '機　能：ﾌｫｰﾑの終了
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:17:15 N.Kasai
    '更新日：2004/06/30 (Wed) 13:17:15
    '備　考：
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
            
            '@ﾓｼﾞｭｰﾙ構造体の解放
            If mtypMasItemList.typeMasItem IsNot Nothing Then
                mtypMasItemList.typeMasItem.Clear()
                mtypMasItemList.typeMasItem = Nothing
            End If

            If mtypLotHoldInfoList.typHoldInfoList IsNot Nothing Then
            mtypLotHoldInfoList.typHoldInfoList.Clear()
                mtypLotHoldInfoList.typHoldInfoList = Nothing
            End If

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
            
            '@ｵﾌﾞｼﾞｪｸﾄの開放
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
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:16:50 N.Kasai
    '更新日：2004/06/30 (Wed) 13:16:50
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
           
            '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞしてﾌﾟﾛｸﾞﾗﾑ終了
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

    '関数名：cmdRegist_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:02:35 N.Kasai
    '更新日：2006/11/29 (Wed) 17:45:55 T.Kitagawa
    '備　考：
    '　　　：2005/03/31 (Thu) 14:10:06 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/04/18 (Mon) 11:25:42 S.Deguchi    在庫状態変更Msgの送信ﾒｯｾｰｼﾞにTag(登録日時)追加
    '　　　：2006/11/29 (Wed) 17:45:55 T.Kitagawa　 ﾊﾟｽﾜｰﾄﾞ確認機能追加(案件№01581)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean          '登録戻り値(True/False)
        
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
            
            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnInput_Chk()
            '@結果判定
            If lblnAns = False Then
                '@不正項目あり
                Exit Sub
            End If

            '@処理による呼出関数の分岐
            Select Case mlngTabFlag
                Case CMlngTab1
                '@保留ﾛｯﾄ在庫処理
                    '@保留ﾓｰﾄﾞによる処理分岐
                    Select Case mlngHoldMode
                        Case CMlngHold
                        '@保留の場合
                            '@ﾒｰﾙ引継情報格納処理
                            lblnAns = prvblnMailConnectInfo_Set()
                            '@結果判定
                            If lblnAns = False Then
                            '@失敗の場合
                                Exit Sub
                            End If
                        
                            '@引継起動ﾌﾗｸﾞの設定
                            pblnfrmxxEN0050kbn = True                                   '保留画面からﾒｰﾙ送信画面を起動
                            pblnfrmxxEN00V0kbn = False
                    
                            '@引継処理ﾌﾗｸﾞの初期化
                            plngfrmxxCM00S0Kbn = 0
                    
                            '@起動ﾌﾗｸﾞの初期化
                            pblnFormLoad = False
                    
                            '@ﾒｰﾙ送信画面起動
                            frmxxCM00S0.Instance = New frmxxCM00S0()
                    
                            '@起動ﾌﾗｸﾞから表示判別
                            If pblnFormLoad = True Then
                            '@成功の場合
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
                                    '@保留確定処理実行
                                    lblnAns = prvblnLotHold_Proc()
                                    '@結果判定
                                    If lblnAns = True Then
                                    '@成功の場合
                                        '@引継起動ﾌﾗｸﾞの初期化
                                        pblnfrmxxEN0050kbn = False
                                        pblnfrmxxEN00V0kbn = False
                                    
                                        '@引継処理ﾌﾗｸﾞの初期化
                                        plngfrmxxCM00S0Kbn = 0
                                    
                                        '@起動ﾌﾗｸﾞを戻す
                                        pblnFormLoad = True
                                        
                                        '@ｻﾌﾞ画面を閉じる
                                        Call cmdClose_Click(cmdClose, New EventArgs)
                                    End If
                    
                                Case Else
                                '@起動失敗,起動成功＆閉じる,他
                                    '@引継起動ﾌﾗｸﾞの初期化
                                    pblnfrmxxEN0050kbn = False
                                    pblnfrmxxEN00V0kbn = False
                                
                                    '@引継処理ﾌﾗｸﾞの初期化
                                    plngfrmxxCM00S0Kbn = 0
                                
                                    '@起動ﾌﾗｸﾞを戻す
                                    pblnFormLoad = True
                                        
                                    Exit Sub
                            End Select
                        
                        Case CMlngHoldRelease
                        '@保留解除の場合
                            
                            '@作業者ｺｰﾄﾞ入力
                            With vsfLotHoldList
                                '@保留理由により，実行権限のﾁｪｯｸを行う(リワーク)
                                If .GetData(.Row, CMlngvsfLotHoldListColHoldReasonID) = CPstrReworkReasonCode Then
                                    '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
                                    frmxxCM0020.Instance.ShowDialog(Me)
                                    frmxxCM0020.Instance = Nothing
                                Else
                                    '@作業者ｺｰﾄﾞ入力
                                    frmxxCM0010.Instance.ShowDialog(Me)
                                    frmxxCM0010.Instance = Nothing
                                End If
                            End With
                        
                            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
                            If pstrUserID = vbNullString Then
                                '@未入力の場合、投入中止
                                Exit Sub
                            End If
                        
                            '@保留解除確定処理実行
                            lblnAns = prvblnLotHoldCancel_Proc()
                            '@結果判定
                            If lblnAns = True Then
                            '@成功の場合
                                '@ｻﾌﾞ画面を閉じる
                                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                            End If
                    End Select
                    
                Case Else
                '@保留在庫以外
                    '@保留ﾓｰﾄﾞによる処理分岐
                    Select Case mlngHoldMode
                        Case CMlngHold
                        '@保留の場合
                            '@ﾒｰﾙ引継情報格納処理
                            lblnAns = prvblnMailConnectInfo_Set()
                            '@結果判定
                            If lblnAns = False Then
                            '@失敗の場合
                                Exit Sub
                            End If
                        
                            '@引継起動ﾌﾗｸﾞの設定
                            pblnfrmxxEN0050kbn = True                                   '保留画面からﾒｰﾙ送信画面を起動
                            pblnfrmxxEN00V0kbn = False
                    
                            '@引継処理ﾌﾗｸﾞの初期化
                            plngfrmxxCM00S0Kbn = 0
                    
                            '@起動ﾌﾗｸﾞの初期化
                            pblnFormLoad = False
                    
                            '@ﾒｰﾙ送信画面起動
                            frmxxCM00S0.Instance = New frmxxCM00S0()
                    
                            '@起動ﾌﾗｸﾞから表示判別
                            If pblnFormLoad = True Then
                            '@成功の場合
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
                                    '@保留確定処理実行
                                    lblnAns = prvblnInvHold_Proc()
                                    '@結果判定
                                    If lblnAns = True Then
                                    '@成功の場合
                                        '@引継起動ﾌﾗｸﾞの初期化
                                        pblnfrmxxEN0050kbn = False
                                        pblnfrmxxEN00V0kbn = False
                                    
                                        '@引継処理ﾌﾗｸﾞの初期化
                                        plngfrmxxCM00S0Kbn = 0
                                    
                                        '@起動ﾌﾗｸﾞを戻す
                                        pblnFormLoad = True
                                        
                                        '@ｻﾌﾞ画面を閉じる
                                        Call cmdClose_Click(cmdClose, EventArgs.Empty)
                                    End If
                    
                                Case Else
                                '@起動失敗,起動成功＆閉じる,他
                                    '@引継起動ﾌﾗｸﾞの初期化
                                    pblnfrmxxEN0050kbn = False
                                    pblnfrmxxEN00V0kbn = False
                                
                                    '@引継処理ﾌﾗｸﾞの初期化
                                    plngfrmxxCM00S0Kbn = 0
                                
                                    '@起動ﾌﾗｸﾞを戻す
                                    pblnFormLoad = True
                                    
                                    Exit Sub
                            End Select
                        
                        Case CMlngHoldRelease
                        '@保留解除の場合
                            '@作業者ｺｰﾄﾞ入力
                            frmxxCM0010.Instance.ShowDialog(Me)
                            frmxxCM0010.Instance = Nothing
                        
                            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
                            If pstrUserID = vbNullString Then
                                '@未入力の場合、投入中止
                                Exit Sub
                            End If
                        
                            '@在庫保留解除確定処理実行
                            lblnAns = prvblnInvHoldCancel_Proc()
                            '@結果判定
                            If lblnAns = True Then
                            '@成功の場合
                                '@ｻﾌﾞ画面を閉じる
                                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                            End If
                    End Select
            End Select
            
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

    '関数名：cmbMasHold_Change
    '機　能：保留理由変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:22:11 N.Kasai
    '更新日：2004/06/30 (Wed) 13:22:11
    '備　考：
    Private Sub cmbMasHold_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMasHold.Change

        Try

            '@確定ﾎﾞﾀﾝ使用可否制御
            Call prvcmdRegistEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMasHold_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMasHold_CloseUp
    '機　能：保留理由選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:23:01 N.Kasai
    '更新日：2004/06/30 (Wed) 13:23:01
    '備　考：
    Private Sub cmbMasHold_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMasHold.CloseUp

        Try

            With cmbMasHold
                '@取得列を保留理由IDに設定
                .ValueCol = 1
                '@保留理由IDが選択されている場合
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
                .strProcName = "cmbMasHold_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpHoldTermDate_Change
    '機　能：保留期限変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:26:08 N.Kasai
    '更新日：2004/06/30 (Wed) 13:26:08
    '備　考：
    Private Sub dtpHoldTermDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles dtpHoldTermDate.Change

        Try

            '@確定ﾎﾞﾀﾝ使用可否制御
            Call prvcmdRegistEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "dtpHoldTermDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpHoldTermDate_CalendarSelect
    '機　能：保留期限選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:26:08 N.Kasai
    '更新日：2004/06/30 (Wed) 13:26:08
    '備　考：
    Private Sub dtpHoldTermDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles dtpHoldTermDate.CalendarSelect

        Try

            '@日付の場合
            If IsDate(dtpHoldTermDate.Value) = True Then
                '@次項目にﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "dtpHoldTermDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpHoldTermDate_Validate
    '機　能：保留期限の入力ﾁｪｯｸ
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:27:22 N.Kasai
    '更新日：2004/06/30 (Wed) 13:27:22
    '備　考：
    '　　　：2005/11/17 (Thu) 11:44:21 S.Deguchi    ﾕｰｻﾞｰ要望№0121の対応で､保留期限の最大値を1ヶ月に設定
    Private Sub dtpHoldTermDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles dtpHoldTermDate.Validating

        Dim lstrLimitDate   As String       '保留期限(現在日+1ヶ月)計算値
        Dim lstrNowDT       As String       '現在日付取得

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@日付が入力されていない(空欄)場合
            If dtpHoldTermDate.Value <> CPstrNullDate Then
                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(dtpHoldTermDate.Value) = False Then
                    'NSYS エラーメッセージ表示時のちらつき防止
                    sender.Focus()

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)

                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@保留期限にｾｯﾄﾌｫｰｶｽ
                    e.Cancel = True
                Else
                    If mlngHoldMode = CMlngHold Then
                    '@保留期限ﾁｪｯｸ
                        lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                        '@保留設定する場合
                        If Format(CDate(dtpHoldTermDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                            'NSYS エラーメッセージ表示時のちらつき防止
                            sender.Focus()

                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                            
                            '@"過去日付は指定できません。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@保留期限にｾｯﾄﾌｫｰｶｽ
                            e.Cancel = True
                        Else
        '@↓2005/11/17 (Thu) 11:50:07 S.Deguchi **************************************************
                        '@未来日付の場合
                            '@1ヵ月後の日付を計算
                            lstrLimitDate = Format$(CDate(DateAdd("m", 1, lstrNowDT)), CPstrDateTimeYMD)
                            
                            '@比較
                            If dtpHoldTermDate.Value > lstrLimitDate Then
                                'NSYS エラーメッセージ表示時のちらつき防止
                                sender.Focus()

                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000H)
                                
                                '@"保留期限を1ヶ月以上設定することはできません。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@保留期限にｾｯﾄﾌｫｰｶｽ
                                e.Cancel = True
                            End If
        '@↑2005/11/17 (Thu) 11:50:07 S.Deguchi **************************************************
                        End If
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "dtpHoldTermDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2005/11/17 (Thu) 15:29:40 S.Deguchi **************************************************
    '関数名：cmbHoldEmpName_Change
    '機　能：保留責任者Change処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/17 (Thu) 15:04:45 S.Deguchi
    '更新日：2005/11/17 (Thu) 15:04:45
    '備　考：
    Private Sub cmbHoldEmpName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbHoldEmpName.Change
        
        Try

            '@保留責任者退避領域を初期化
            mstrHoldEmpID = vbNullString
            
            '@確定ﾎﾞﾀﾝ使用可否制御
            Call prvcmdRegistEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbHoldEmpName_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbHoldEmpName_CloseUp
    '機　能：保留責任者CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/17 (Thu) 15:04:48 S.Deguchi
    '更新日：2005/11/17 (Thu) 15:04:48
    '備　考：
    Private Sub cmbHoldEmpName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbHoldEmpName.CloseUp

        Try

            '@Validate処理へ
            RemoveHandler cmbHoldEmpName.Validating, AddressOf cmbHoldEmpName_Validate
            Call cmbHoldEmpName_Validate(cmbHoldEmpName, New CancelEventArgs(True))
            AddHandler cmbHoldEmpName.Validating, AddressOf cmbHoldEmpName_Validate
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbHoldEmpName_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbHoldEmpName_Validate
    '機　能：保留責任者Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/11/17 (Thu) 15:04:50 S.Deguchi
    '更新日：2005/11/17 (Thu) 15:04:50
    '備　考：
    Private Sub cmbHoldEmpName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbHoldEmpName.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            With cmbHoldEmpName
                If .Text <> vbNullString Then
                '@空欄以外の場合
                    .ValueCol = 1
                    '@保留責任者退避領域へｾｯﾄ
                    mstrHoldEmpID = .Value
                Else
                '@空欄の場合
                    '@初期化
                    mstrHoldEmpID = vbNullString
                End If
            End With
            
            '@ｾｯﾄﾌｫｰｶｽ処理
            If ActiveControl.Name = cmbHoldEmpName.Name Then
	            If cmdRegist.Enabled = True Then
	                '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
	                Call pubSetFocus(cmdRegist)
	            Else
	                '@保留一覧が使用可能な場合か否かで処理分岐
	                If vsfLotHoldList.Enabled = True Then
	                    '@保留一覧にﾌｫｰｶｽｾｯﾄ
	                    Call pubSetFocus(vsfLotHoldList)
	                Else
	                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
	                    Call pubSetFocus(cmdClose)
	                End If
	            End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbHoldEmpName_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2005/11/17 (Thu) 15:29:40 S.Deguchi **************************************************

    '関数名：txtHoldComment_Change
    '機　能：保留ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:23:19 N.Kasai
    '更新日：2004/06/30 (Wed) 13:23:19
    '備　考：

    Private Sub txtHoldComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtHoldComment.Change

        Dim llngNowByte         As Integer  '現在のﾊﾞｲﾄ数

        Try

            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtHoldComment.NowByte
            
        '@↓2005/11/18 (Fri) 16:14:45 S.Deguchi **************************************************
            With txtHoldComment
                Select Case mlngHoldMode
                    Case CMlngHold
                    '@保留起動
                        .ChrMaxByte = CMlngChrMaxByteHold
                        
                        '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                        llngNowByte = .NowByte                                  '現状のﾊﾞｲﾄ数を格納
                        lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength,
                                                                      llngNowByte,
                                                                      CMlngChrMaxByteHold)
                        
                    Case CMlngHoldRelease
                    '@保留解除起動
                        .ChrMaxByte = CMlngChrMaxByteCancel
                        
                        '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                        llngNowByte = .NowByte                                  '現状のﾊﾞｲﾄ数を格納
                        lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength,
                                                                      llngNowByte,
                                                                      CMlngChrMaxByteCancel)
                End Select
            End With

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtHoldComment, CMlngMaxDispRow, cmdHoldTxtUp, cmdHoldTxtDown)
        '@↑2005/11/18 (Fri) 16:14:45 S.Deguchi **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHoldComment_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldComment_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:18:37 S.Deguchi
    '更新日：2005/11/22 (Tue) 13:18:37
    '備　考：
    Private Sub txtHoldComment_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHoldComment.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtHoldComment, CMlngMaxDispRow, cmdHoldTxtUp, cmdHoldTxtDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHoldComment_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldComment_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:19:54 S.Deguchi
    '更新日：2005/11/22 (Tue) 13:19:54
    '備　考：
    Private Sub txtHoldComment_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtHoldComment.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtHoldComment, CMlngMaxDispRow, cmdHoldTxtUp, cmdHoldTxtDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2005/11/22 (Tue) 13:28:46 S.Deguchi **************************************************
    '関数名：txtHoldCommentView_Change
    '機　能：保留ｺﾒﾝﾄﾋﾞｭｰ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:26:29 S.Deguchi
    '更新日：2005/11/22 (Tue) 13:26:29
    '備　考：
    Private Sub txtHoldCommentView_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtHoldCommentView.Change

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtHoldCommentView, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHoldCommentView_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldCommentView_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:27:19 S.Deguchi
    '更新日：2005/11/22 (Tue) 13:27:19
    '備　考：
    Private Sub txtHoldCommentView_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHoldCommentView.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtHoldCommentView, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHoldCommentView_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldCommentView_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:19:54 S.Deguchi
    '更新日：2005/11/22 (Tue) 13:19:54
    '備　考：
    Private Sub txtHoldCommentView_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtHoldCommentView.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtHoldCommentView, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHoldCommentView_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2005/11/22 (Tue) 13:28:46 S.Deguchi **************************************************

    '関数名：cmdTxtUp_Click
    '機　能：ｺﾒﾝﾄの前頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:21 Y.Yamagishi
    '更新日：2004/04/14 (Wed) 10:18:17 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/22 (Tue) 13:23:52 S.Deguchi **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtHoldCommentView)
        '
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtHoldCommentView, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
        '@↑2005/11/22 (Tue) 13:23:52 S.Deguchi **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTxtUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtDown_Click
    '機　能：ｺﾒﾝﾄの次頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:36 Y.Yamagishi
    '更新日：2004/04/14 (Wed) 10:18:23 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/22 (Tue) 13:24:40 S.Deguchi **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtHoldCommentView)
        '
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtHoldCommentView, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
        '@↑2005/11/22 (Tue) 13:24:40 S.Deguchi **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTxtDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHoldTxtUp_Click
    '機　能：ｺﾒﾝﾄの前頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:21 Y.Yamagishi
    '更新日：2004/04/14 (Wed) 10:18:17 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdHoldTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHoldTxtUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/22 (Tue) 13:15:26 S.Deguchi **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtHoldComment)
        '
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtHoldComment, CMlngMaxDispRow, cmdHoldTxtUp, cmdHoldTxtDown)
        '@↑2005/11/22 (Tue) 13:15:26 S.Deguchi **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHoldTxtUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHoldTxtDown_Click
    '機　能：ｺﾒﾝﾄの次頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:36 Y.Yamagishi
    '更新日：2004/04/14 (Wed) 10:18:23 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdHoldTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHoldTxtDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/22 (Tue) 13:16:40 S.Deguchi **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtHoldComment)
        '
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtHoldComment, CMlngMaxDispRow, cmdHoldTxtUp, cmdHoldTxtDown)
        '@↑2005/11/22 (Tue) 13:16:40 S.Deguchi **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHoldTxtDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotHoldList_EnterCell
    '機　能：一覧選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/13 (Wed) 16:37:01 S.Deguchi
    '更新日：2005/04/13 (Wed) 16:37:01
    '備　考：
    Private Sub vsfLotHoldList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotHoldList.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotHoldList.Rows.Count <= vsfLotHoldList.Rows.Fixed Then
                Return
            End If
            
            '@ｺﾒﾝﾄが存在する場合(保留/保留解除で処理分岐なし)
            With vsfLotHoldList
                '@ﾀｲﾄﾙ以外
                If .Row <> 0 Then
                    '@保留ｺﾒﾝﾄ列がNullでない場合
                    If .GetData(.Row, CMlngvsfLotHoldListColHoldComments) <> vbNullString Then
                        '@ｺﾒﾝﾄ反映
                        txtHoldCommentView.Text = .GetData(.Row, CMlngvsfLotHoldListColHoldComments)
                        txtHoldCommentView.Enabled = True
                    Else
                        '@ｺﾒﾝﾄ反映
                        txtHoldCommentView.Text = vbNullString
                        txtHoldCommentView.Enabled = False
                    End If

                    '@起動区分による処理対応
                    Select Case mlngHoldMode
                        '@保留設定
                        Case CMlngHold
                        '@処理なし
                        
                        '@保留解除
                        Case CMlngHoldRelease
                        '@選択した内容を設定ﾌﾚｰﾑへ反映
                            '@保留理由
                            With cmbMasHold
                                '@ｸﾘｱ
                                .Clear()
                                '@ﾘｽﾄに追加
                                .AddItem(vsfLotHoldList.GetData(vsfLotHoldList.Row, CMlngvsfLotHoldListColHoldReason) _
                                       & vbTab _
                                       & vsfLotHoldList.GetData(vsfLotHoldList.Row, CMlngvsfLotHoldListColHoldReasonID))
                                '@ﾃｷｽﾄ部分へ表示
                                .ListIndex = CMlngCmbFirstListIndex
                            End With
                            
                            '@保留期限
                            dtpHoldTermDate.Value = vsfLotHoldList.GetData(vsfLotHoldList.Row, 
                                                                                   CMlngvsfLotHoldListColHoldEDateL)
                            
                            '@保留責任者
                            cmbHoldEmpName.Text = vsfLotHoldList.GetData(vsfLotHoldList.Row, CMlngvsfLotHoldListColHoldEmpName)
                            mstrHoldEmpID = vsfLotHoldList.GetData(vsfLotHoldList.Row, CMlngvsfLotHoldListColHoldEmpID)
                    End Select
                End If
            End With

            '@確定ﾎﾞﾀﾝ使用可否制御
            Call prvcmdRegistEnabled_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotHoldList_EnterCell"
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
    '関数名：prvfrmxxEN00F1_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:35:43 N.Kasai
    '更新日：2008/06/11 (Wed) 11:33:24 N.Kojima
    '備　考：
    '　　　：2005/04/18 (Mon) 09:56:03 S.Deguchi    不具合№688対応で初期化処理全面見直し
    '　　　：2008/06/11 (Wed) 11:33:24 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN00F1_Init()

        Dim llngNowByte As Integer                                          'ﾊﾞｲﾄ数格納

        Try
            
            '@初期値設定
            lblCarrier.Text = vbNullString                                   'ｷｬﾘｱID
            lblLotID.Text = vbNullString                                     'ﾛｯﾄID
            lblFlowClass.Text = vbNullString                                 '種別ｺｰﾄﾞ
            dtpHoldTermDate.Value = vbNullString                                '保留期限
            txtHoldComment.Text = vbNullString                                  '保留ｺﾒﾝﾄ
            txtHoldCommentView.Text = vbNullString                              '保留ｺﾒﾝﾄ(View)
            mstrLotLastUpdate = vbNullString                                    'ﾛｯﾄ最終更新日時
            mstrHoldEmpID = vbNullString                                        '保留責任者ID
            mstrLotManagerID = vbNullString                                     'ﾛｯﾄ担当者ID格納領域
            mstrLotManagerName = vbNullString                                   'ﾛｯﾄ担当者名格納領域
            mstrPDID = vbNullString                                             '機種格納領域
            mstrOpID = vbNullString                                             '大工程格納領域
            mstrStepID = vbNullString                                           '小工程格納領域

            '@保留ﾘｽﾄ初期化
            Call prvvsfLotHoldList_Init()
            
            '@保留ｺﾒﾝﾄ表示ﾃｷｽﾄﾎﾞｯｸｽ設定
            With txtHoldCommentView
                .MultiLineEx = True                                             '複数行表示
                .Locked = True                                                  'ﾛｯｸ
                .BackColor = vbButtonFace                                       '背景色灰色
                .GotBackColor = vbButtonFace                                    '背景色灰色
            End With
            
            '@保留期限ｶﾚﾝﾀﾞｰ設定
            Call pubblnCalendar_Init(dtpHoldTermDate, CPlngCalModeTool, CPstrNullDate)

        '@↓2005/11/18 (Fri) 16:09:07 S.Deguchi **************************************************
            '@保留(保留解除)ｺﾒﾝﾄ初期化
            With txtHoldComment
                .Text = vbNullString                                            'Null表示
                .MultiLineEx = True                                             '複数行表示可能制御
                .Enabled = False                                                '非活性化
                
                Select Case mlngHoldMode
                    Case CMlngHold
                    '@保留起動
                        .ChrMaxByte = CMlngChrMaxByteHold
                        
                        '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                        llngNowByte = .NowByte                                  '現状のﾊﾞｲﾄ数を格納
                        lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                                      llngNowByte, _
                                                                      CMlngChrMaxByteHold)
                        
                    Case CMlngHoldRelease
                    '@保留解除起動
                        .ChrMaxByte = CMlngChrMaxByteCancel
                        
                        '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                        llngNowByte = .NowByte                                  '現状のﾊﾞｲﾄ数を格納
                        lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                                      llngNowByte, _
                                                                      CMlngChrMaxByteCancel)
                End Select
                
                '@ﾊﾞｲﾄ数非表示
                lblLengthCount.Visible = False
            End With
        '@↑2005/11/18 (Fri) 16:09:07 S.Deguchi **************************************************

            '@ﾛｯｸ
            txtHoldCommentView.Enabled = False                                  '保留ｺﾒﾝﾄ表示欄
            cmdTxtUp.Enabled = False                                            '保留ｺﾒﾝﾄ表示欄ｽｸﾛｰﾙｱｯﾌﾟﾎﾞﾀﾝ
            cmdTxtDown.Enabled = False                                          '保留ｺﾒﾝﾄ表示欄ｽｸﾛｰﾙﾀﾞｳﾝﾎﾞﾀﾝ
            cmbMasHold.Enabled = False                                          '保留理由ｺﾝﾎﾞ
            dtpHoldTermDate.Enabled = False                                     '保留期限
            txtHoldComment.Enabled = False                                      '保留/保留解除ｺﾒﾝﾄ入力欄
            cmdHoldTxtUp.Enabled = False                                        '保留/保留解除ｺﾒﾝﾄ入力欄ｽｸﾛｰﾙｱｯﾌﾟﾎﾞﾀﾝ
            cmdHoldTxtDown.Enabled = False                                      '保留/保留解除ｺﾒﾝﾄ入力欄ｽｸﾛｰﾙﾀﾞｳﾝﾎﾞﾀﾝ
            cmdRegist.Enabled = False                                           '確定ﾎﾞﾀﾝ
            
            '@閉じるﾎﾞﾀﾝのValidateｲﾍﾞﾝﾄを解除
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00F1_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN00F1_Disp
    '機　能：ﾍｯﾀﾞ情報の表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/12 (Fri) 16:21:34 M.Miura
    '更新日：2008/06/11 (Wed) 11:33:52 N.Kojima
    '備　考：親ﾌｫｰﾑから構造体渡し
    '　　　：2004/10/15 (Fri) 12:15:30 N.Kasai      保留解除の場合担当者名をﾏｽﾀから取得ではなく構造体より取得する。
    '　　　：2005/04/15 (Fri) 14:48:01 S.Deguchi    不具合№688対応で処理見直し(常にlot_.holdinfoを取得するように修正)
    '　　　：2005/04/18 (Mon) 09:56:03 S.Deguchi    不具合№688対応で処理見直し(処理区分による処理を見直し)
    '　　　：2005/11/21 (Mon) 16:46:36 S.Deguchi    ﾕｰｻﾞｰ要望№0121の対応で引継構造体にｶﾗﾑ追加の対応
    '　　　：2008/06/11 (Wed) 11:33:52 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN00F1_Disp()

        Dim lstrTempDate            As String                               '現在日退避(XXXX/YY/ZZ)
        Dim lstrNowDT               As String 

        Try

            '@引継ぎﾍｯﾀﾞ情報の表示・退避
            With ptypHoldConnect
                lblCarrier.Text = .strCarrierId                              'ｷｬﾘｱID
                lblLotID.Text = .strLotID                                    'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                            '流動区分
                mlngHoldMode = .strLotHoldFlg                                   '保留区分
                mstrLotLastUpdate = .strLastUpdate                              '最終更新日時
                mlngTabFlag = .lngTabFlag                                       'ﾀﾌﾞﾌﾗｸﾞ(0:受入　1:保留　2:中間　3:完成)
                mstrHoldEmpID = .strHoldEmpID                                   '保留責任者
                mstrLotManagerID = .strEngEmpId                                 'ﾛｯﾄ担当者ID
                mstrLotManagerName = .strEngEmpName                             'ﾛｯﾄ担当者名
                mstrPDID = .strPdId                                             '機種
                mstrOpID = .strOpID                                             '大工程
                mstrStepID = .strStepID                                         '小工程
            End With
            
            '@引継ぎ情報の表示
            With ptypHoldConnect
                '@処理区分(保留/保留解除を判定し表示内容を変更する)
                Select Case mlngHoldMode
                    Case CMlngHold
                        '@保留設定
                        mstrClassDivision = CPstrCD14
                        
                        '@ﾌﾚｰﾑ名称の設定
                        fraHold.Text = CPstrSubFormEN00F1Hold
                        fraHoldSet.Text = CMstrHoldFrameTitle
                        lblTitleHoldComment.Text = CMstrHoldLabelTitle
                        lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                        '@保留期限ｾｯﾄ
                        If .strFlowClass = CPstrFlowClassES Or .strFlowClass = CPstrFlowClassPR Then
                            lstrTempDate = Format$(DateAdd("d", 2, lstrNowDT), CPstrDateTimeYMD)                    '2日後計算値
                        Else
                            lstrTempDate = Format$(DateAdd("d", 7, lstrNowDT), CPstrDateTimeYMD)                    '1週間後計算値
                        End If
                        dtpHoldTermDate.Value = Format$(CDate(lstrTempDate), CPstrDateTimeYMD)
                        
                        '@ﾛｯｸ解除
                        cmbMasHold.Enabled = True                               '保留理由
                        dtpHoldTermDate.Enabled = True                          '保留期限
                        cmbHoldEmpName.Enabled = True                           '保留責任者
                        
                        '@背景色設定
                        cmbMasHold.BackColor = Color.White                          '保留理由
                        dtpHoldTermDate.BackColor = Color.White                     '保留期限
                        cmbHoldEmpName.BackColor = Color.White                      '保留責任者
                        
                    Case CMlngHoldRelease
                        '@保留解除設定
                        mstrClassDivision = CPstrCD15
                        
                        '@ﾌﾚｰﾑ名称の設定
                        fraHold.Text = CPstrSubFormEN00F1Cancel
                        fraHoldSet.Text = CMstrHoldReleaseFrameTitle
                        lblTitleHoldComment.Text = CMstrHoldReleaseLabelTitle
                        
                        '@ﾛｯｸ
                        cmbMasHold.Enabled = False                              '保留理由
                        dtpHoldTermDate.Enabled = False                         '保留期限
                        cmbHoldEmpName.Enabled = False                          '保留責任者
                        
                        '@背景色設定
                        cmbMasHold.BackColor = vbButtonFace                     '保留理由
                        dtpHoldTermDate.BackColor = vbButtonFace                '保留期限
                        cmbHoldEmpName.BackColor = vbButtonFace                 '保留責任者
                End Select
                
                '@保留責任者ｸﾘｱ
                cmbHoldEmpName.Text = vbNullString
                
                '@保留責任者Combo設定
                Call prvCmbHoldEmpName_Disp()
                
                '@保留/保留解除ｺﾒﾝﾄ欄設定
                With txtHoldComment
                    .BackColor = vbWindowBackground
                    .GotBackColor = vbWindowBackground
                    .Locked = False
                    .Enabled = True
                End With
                
                '@保留/保留解除ｺﾒﾝﾄﾊﾞｲﾄ数表示
                lblLengthCount.Visible = True
                
                '@保留/保留解除ﾄﾊﾞｲﾄ数設定
                Call txtHoldComment_Change(txtHoldComment, New EventArgs)
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00F1_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：ﾛｯﾄ保留/解除前ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 19:03:15 M.Miura
    '更新日：2004/06/18 (Fri) 11:21:01 N.Kojima
    '備　考：
    Private Function prvblnInput_Chk() As Boolean
        
		Dim lstrNowDT   As String   '現在日付取得

        Try
            
            prvblnInput_Chk = False
            
            '@ﾛｯﾄIDﾁｪｯｸ
            If lblLotID.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0022)
                
                '@"ロットIDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Function
            End If
            
            '@保留理由ﾁｪｯｸ
            If cmbMasHold.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0025)
                
                '@"保留理由が設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@保留理由にﾌｫｰｶｽｾｯﾄ
                If cmbMasHold.Enabled = True Then
                    Call pubSetFocus(cmbMasHold)
                End If
                
                Exit Function
            End If
            
            '@保留にする場合
            If mlngHoldMode = CMlngHold Then
            '@保留期限ﾁｪｯｸ
                lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                '@保留設定する場合
                If Format$(CDate(dtpHoldTermDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                    
                    '@"過去日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@保留理由にﾌｫｰｶｽｾｯﾄ
                    If dtpHoldTermDate.Enabled = True Then
                        Call pubSetFocus(dtpHoldTermDate)
                    End If
                    
                    Exit Function
                End If
                
                '@保留責任者IDﾁｪｯｸ
                If cmbHoldEmpName.Text = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000B)
                    
                    '@"保留責任者が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@保留責任者にﾌｫｰｶｽｾｯﾄ
                    If cmbHoldEmpName.Enabled = True Then
                        Call pubSetFocus(cmbHoldEmpName)
                    End If
                    
                    Exit Function
                End If
            End If
            
            '@成功を返す
            prvblnInput_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInput_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvcmdRegistEnabled_Chk
    '機　能：入力項目ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/23 (Wed) 09:08:51 M.Miura
    '更新日：2004/06/23 (Wed) 09:08:51
    '備　考：
    '　　　：2005/04/18 (Mon) 09:56:03 S.Deguchi    不具合№688対応で起動区分処理対応で処理全面見直し
    Private Sub prvcmdRegistEnabled_Chk()

        Try

            '@保留解除の場合
            If mlngHoldMode = CMlngHoldRelease Then
                With vsfLotHoldList
                    '@ﾀｲﾄﾙ以外
                    If .Row <> 0 Then
                        '@制限ﾌﾗｸﾞが"1"以外の場合
                        If .GetData(.Row, CMlngvsfLotHoldListColRestrictFlag) <> CMstrRestrictFlag1 Then
                            '@確定ﾎﾞﾀﾝ使用可
                            cmdRegist.Enabled = True
                            Exit Sub
                        Else
                            '@確定ﾎﾞﾀﾝ使用不可
                            cmdRegist.Enabled = False
                            Exit Sub
                        End If
                    End If
                End With
            Else
                '@保留理由、保留日付ﾁｪｯｸ
                If cmbMasHold.Text <> vbNullString And
                   IsDate(dtpHoldTermDate.Value) = True And
                   cmbHoldEmpName.Text <> vbNullString Then

                    '@確定ﾎﾞﾀﾝ使用可
                    cmdRegist.Enabled = True
                Else
                    '@確定ﾎﾞﾀﾝ使用不可
                    cmdRegist.Enabled = False
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdRegistEnabled_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotHoldList_Init
    '機　能：保留情報一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/12 (Tue) 11:16:22 S.Deguchi
    '更新日：2005/04/12 (Tue) 11:16:22
    '備　考：
    Private Sub prvvsfLotHoldList_Init()

        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfLotHoldList
                '@ｸﾘｱ
                .Clear()
                
                '@ﾏｳｽでｾﾙ範囲選択不可
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                .SelectionMode = SelectionModeEnum.Row
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.None
                
                '@一覧表の表題設定
                Dim cellRange As CellRange
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                cellRange = .GetCellRange(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColTitle, .Rows.Count - 1, .Cols.Count - 1)
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                                      '中央表示
                lFixedStyle.ForeColor = Color.Yellow                                                    '文字色
                lFixedStyle.BackColor = Color.Navy                                                      '背景色
                With .Font
                    lFixedStyle.Font = New Font(.FontFamily, CMlngvsfLotHoldListHFontSize,.Style)       'ﾌｫﾝﾄｻｲｽﾞ
                End With
                cellRange.Style = lFixedStyle
                .Rows(CMlngvsfLotHoldListRowTitle).Height = CMlngvsfLotHoldListHHeight                  '高さ
                        
                'ﾀｲﾄﾙ,列幅設定
                '@№
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColNo, CMstrvsfLotHoldListColNo)
                .Cols(CMlngvsfLotHoldListColNo).Width = CMlngvsfLotHoldListColWNo
                
                '@保留開始日
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldSDate, CMstrvsfLotHoldListColHoldSDate)
                .Cols(CMlngvsfLotHoldListColHoldSDate).Width = CMlngvsfLotHoldListColWHoldSDate
                
                '@保留日(EntryTime)
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColEntryTime, CMstrvsfLotHoldListColEntryTime)
                .Cols(CMlngvsfLotHoldListColEntryTime).Width = CMlngvsfLotHoldListColWEntryTime
                
                '@保留期限
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldEDate, CMstrvsfLotHoldListColHoldEDate)
                .Cols(CMlngvsfLotHoldListColHoldEDate).Width = CMlngvsfLotHoldListColWHoldEDate
                
                '@保留期限(西暦表記)
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldEDateL, CMstrvsfLotHoldListColHoldEDateL)
                .Cols(CMlngvsfLotHoldListColHoldEDateL).Width = CMlngvsfLotHoldListColWHoldEDateL
                
                '@保留期間
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldTerm, CMstrvsfLotHoldListColHoldTerm)
                .Cols(CMlngvsfLotHoldListColHoldTerm).Width = CMlngvsfLotHoldListColWHoldTerm
                
                '@保留理由ID
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldReasonID, CMstrvsfLotHoldListColHoldReasonID)
                .Cols(CMlngvsfLotHoldListColHoldReasonID).Width = CMlngvsfLotHoldListColWHoldReasonID
                
                '@保留理由
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldReason, CMstrvsfLotHoldListColHoldReason)
                .Cols(CMlngvsfLotHoldListColHoldReason).Width = CMlngvsfLotHoldListColWHoldReason
                
                '@保留責任者ID
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldEmpID, CMstrvsfLotHoldListColHoldEmpID)
                .Cols(CMlngvsfLotHoldListColHoldEmpID).Width = CMlngvsfLotHoldListColWHoldEmpID
                
                '@保留責任者名
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldEmpName, CMstrvsfLotHoldListColHoldEmpName)
                .Cols(CMlngvsfLotHoldListColHoldEmpName).Width = CMlngvsfLotHoldListColWHoldEmpName
                
                '@保留内容
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldComments, CMstrvsfLotHoldListColHoldComments)
                .Cols(CMlngvsfLotHoldListColHoldComments).Width = CMlngvsfLotHoldListColWHoldComments
                
                '@制限ﾌﾗｸﾞ
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColRestrictFlag, CMstrvsfLotHoldListColRestrictFlag)
                .Cols(CMlngvsfLotHoldListColRestrictFlag).Width = CMlngvsfLotHoldListColWRestrictFlag
                
                '@列位置の設定
                .Cols(CMlngvsfLotHoldListColNo).TextAlign = TextAlignEnum.GeneralCenter                 '№
                .Cols(CMlngvsfLotHoldListColHoldSDate).TextAlign = TextAlignEnum.GeneralCenter          '保留開始日
                .Cols(CMlngvsfLotHoldListColEntryTime).TextAlign = TextAlignEnum.GeneralCenter          '保留日(EntryTime)
                .Cols(CMlngvsfLotHoldListColHoldEDate).TextAlign = TextAlignEnum.GeneralCenter          '保留期限
                .Cols(CMlngvsfLotHoldListColHoldEDateL).TextAlign = TextAlignEnum.GeneralCenter         '保留期限(西暦表記)
                .Cols(CMlngvsfLotHoldListColHoldReasonID).TextAlign = TextAlignEnum.GeneralCenter       '保留理由ID
                .Cols(CMlngvsfLotHoldListColHoldReason).TextAlign = TextAlignEnum.GeneralCenter         '保留理由
                .Cols(CMlngvsfLotHoldListColHoldEmpID).TextAlign = TextAlignEnum.GeneralCenter          '保留責任者ID
                .Cols(CMlngvsfLotHoldListColHoldEmpName).TextAlign = TextAlignEnum.GeneralCenter        '保留責任者
                .Cols(CMlngvsfLotHoldListColHoldComments).TextAlign = TextAlignEnum.GeneralCenter       'ｺﾒﾝﾄ内容
                .Cols(CMlngvsfLotHoldListColRestrictFlag).TextAlign = TextAlignEnum.GeneralCenter       '制限ﾌﾗｸﾞ
                
                '@非表示列設定
                .Cols(CMlngvsfLotHoldListColEntryTime).Visible = False                                  '保留日(EntryTime)
                .Cols(CMlngvsfLotHoldListColHoldEDateL).Visible = False                                 '保留期限(西暦表記)
                .Cols(CMlngvsfLotHoldListColHoldReasonID).Visible = False                               '保留理由ID
                .Cols(CMlngvsfLotHoldListColHoldEmpID).Visible = False                                  '保留責任者ID
                .Cols(CMlngvsfLotHoldListColHoldComments).Visible = False                               'ｺﾒﾝﾄ内容
                .Cols(CMlngvsfLotHoldListColRestrictFlag).Visible = False                               '制限ﾌﾗｸﾞ
                        
                '@ﾛｯｸ
                .Enabled = False
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotHoldList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotHoldList_Disp
    '機　能：保留情報一覧の表示
    '引　数：ltypLotHoldInfoList：保留ﾘｽﾄ構造体
    '戻り値：なし
    '作成日：2005/04/13 (Wed) 17:52:38 S.Deguchi
    '更新日：2005/04/13 (Wed) 17:52:38
    '備　考：
    Private Sub prvvsfLotHoldList_Disp(ByRef ltypLotHoldInfoList As LotHoldInfoList)
        
        Dim llngDoCnt       As Integer      'ﾙｰﾌﾟｶｳﾝﾀ

        Try

            With vsfLotHoldList
                '@ﾘｽﾄが0件の場合には,処理を行わない
                If ltypLotHoldInfoList.lngHoldInfoListCnt = 0 Then
                    '@一覧内容を初期化
                    .Rows.Count = .Rows.Fixed
                    
                    '@ﾛｯｸ
                    .Enabled = False
                    
                    '@処理抜け
                    Exit Sub
                End If
                
                '@表示をとめる
                .Redraw = False
                
                RemoveHandler vsfLotHoldList.EnterCell, AddressOf vsfLotHoldList_EnterCell

                '@表示列を固定列のみ(初期化処理)
                .Rows.Count = .Rows.Fixed
                
                '@行数設定
                .Rows.Count = ltypLotHoldInfoList.lngHoldInfoListCnt + 1
                .Row = 0
                '@ｶｳﾝﾀの初期化
                llngDoCnt = 0
                
                '@ﾛｯﾄ一覧表示情報設定
                Do While .Rows.Count - 1 > llngDoCnt
                    .SetData(llngDoCnt + 1, CMlngvsfLotHoldListColNo, llngDoCnt + 1)                                                '№
                
                    .SetData(llngDoCnt + 1, CMlngvsfLotHoldListColHoldSDate,
                        Format$(CDate(ltypLotHoldInfoList.typHoldInfoList(llngDoCnt).strHoldTime), CPstrDateFormatMDHM))            '保留開始日
                        
                    .SetData(llngDoCnt + 1, CMlngvsfLotHoldListColEntryTime,
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt).strEntryTime)                                         '保留日(EntryTime)
                        
                    .SetData(llngDoCnt + 1, CMlngvsfLotHoldListColHoldEDate,
                        Format$(CDate(ltypLotHoldInfoList.typHoldInfoList(llngDoCnt).strHoldTermDate), CPstrDateTimeMD))            '保留期限

                    .SetData(llngDoCnt + 1, CMlngvsfLotHoldListColHoldEDateL,
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt).strHoldTermDate)                                      '保留期限(西暦表記)

                    .SetData(llngDoCnt + 1, CMlngvsfLotHoldListColHoldTerm,
                        Mid(ltypLotHoldInfoList.typHoldInfoList(llngDoCnt).strHoldStayDate,
                            CMlngFormatStart,
                            CMlngFormatMid9))                                                                                '保留期間

                    .SetData(llngDoCnt + 1, CMlngvsfLotHoldListColHoldReasonID,
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt).strHoldReasonID)                                      '保留理由ID

                    .SetData(llngDoCnt + 1, CMlngvsfLotHoldListColHoldReason,
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt).strHoldReasonName)                                    '保留理由

                    .SetData(llngDoCnt + 1, CMlngvsfLotHoldListColHoldEmpID,
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt).strHoldEmpID)                                         '保留責任者ID

                    .SetData(llngDoCnt + 1, CMlngvsfLotHoldListColHoldEmpName,
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt).strHoldEmpName)                                       '保留責任者

                    .SetData(llngDoCnt + 1, CMlngvsfLotHoldListColHoldComments,
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt).strHoldComment)                                       '保留ｺﾒﾝﾄ

                    .SetData(llngDoCnt + 1, CMlngvsfLotHoldListColRestrictFlag,
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt).strRestrictFlag)                                      '制限ﾌﾗｸﾞ

                    '@ｽﾛｯﾄの高さの設定
                    .Rows(llngDoCnt + 1).Height = CMlngvsfLotHoldListHeight
                    
                    '@ﾌｫﾝﾄ設定
                    .Font = New Font(.Font.Name, CType(CMlngvsfLotHoldListFontSize, Single))
                    
                    '@起動区分が保留解除の場合
                    If mlngHoldMode = CMlngHoldRelease Then
                        '@制限ﾌﾗｸﾞが"1"の場合
                        If .GetData(llngDoCnt + 1, CMlngvsfLotHoldListColRestrictFlag) = CMstrRestrictFlag1 Then
                            '@背景色を薄いｸﾞﾚｰ表記へ変更
                            Dim newstyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                            newstyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt + 1, CMlngvsfLotHoldListColNo, llngDoCnt + 1, .Cols.Count - 1)
                            cellRange.Style = newstyle
                        End If
                    End If
                    
                    '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                    llngDoCnt = llngDoCnt + 1
                Loop
            
                '@列位置の設定
                .Cols(CMlngvsfLotHoldListColNo).TextAlign = TextAlignEnum.RightCenter              '№
                .Cols(CMlngvsfLotHoldListColHoldSDate).TextAlign = TextAlignEnum.LeftCenter        '保留開始日
                .Cols(CMlngvsfLotHoldListColEntryTime).TextAlign = TextAlignEnum.LeftCenter        '保留日(EntryTime)
                .Cols(CMlngvsfLotHoldListColHoldEDate).TextAlign = TextAlignEnum.LeftCenter        '保留期限
                .Cols(CMlngvsfLotHoldListColHoldTerm).TextAlign = TextAlignEnum.LeftCenter         '保留期間
                .Cols(CMlngvsfLotHoldListColHoldReasonID).TextAlign = TextAlignEnum.LeftCenter     '保留理由ID
                .Cols(CMlngvsfLotHoldListColHoldReason).TextAlign = TextAlignEnum.LeftCenter       '保留理由
                .Cols(CMlngvsfLotHoldListColHoldEmpID).TextAlign = TextAlignEnum.LeftCenter        '保留責任者ID
                .Cols(CMlngvsfLotHoldListColHoldEmpName).TextAlign = TextAlignEnum.LeftCenter      '保留責任者
                .Cols(CMlngvsfLotHoldListColHoldComments).TextAlign = TextAlignEnum.LeftCenter     'ｺﾒﾝﾄ内容
                .Cols(CMlngvsfLotHoldListColRestrictFlag).TextAlign = TextAlignEnum.LeftCenter     '制限ﾌﾗｸﾞ
                
                '@列のｵｰﾄｻｲｽﾞ設定
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCol(CMlngvsfLotHoldListColNo, 6)                '№
                .AutoSizeCol(CMlngvsfLotHoldListColHoldSDate, 6)         '保留開始日
                .AutoSizeCol(CMlngvsfLotHoldListColEntryTime, 6)         '保留日(EntryTime)
                .AutoSizeCol(CMlngvsfLotHoldListColHoldEDate, 6)         '保留期限
                .AutoSizeCol(CMlngvsfLotHoldListColHoldTerm, 10)         '保留期間
                .AutoSizeCol(CMlngvsfLotHoldListColHoldReasonID, 6)      '保留理由ID
                .AutoSizeCol(CMlngvsfLotHoldListColHoldReason, 6)        '保留理由
                .AutoSizeCol(CMlngvsfLotHoldListColHoldEmpID, 6)         '保留責任者ID
                .AutoSizeCol(CMlngvsfLotHoldListColHoldEmpName, 6)       '保留責任者
                .AutoSizeCol(CMlngvsfLotHoldListColHoldComments, 6)      'ｺﾒﾝﾄ内容
                .AutoSizeCol(CMlngvsfLotHoldListColRestrictFlag, 6)      '制限ﾌﾗｸﾞ

                AddHandler vsfLotHoldList.EnterCell, AddressOf vsfLotHoldList_EnterCell
                
                '@再描画
                .Redraw = True
            
                '@ﾛｯｸ解除
                .Enabled = True
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotHoldList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbMasHoldList_Disp
    '機　能：保留理由Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/07 (Thu) 08:48:57 S.Deguchi
    '更新日：2005/07/07 (Thu) 08:48:57
    '備　考：
    Private Sub prvcmbMasHoldList_Disp()
        
        Dim llngCnt         As Integer          '汎用ｶｳﾝﾀ

        Try
                        
            '@保留理由ｾｯﾄ
            With cmbMasHold
                .Clear()
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColHoldName                               'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColHoldID                               '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Text = vbNullString                                            '初期化
                .Font = New Font(.Font.Name, CType(CMlngCmbFontSize, Single))           'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.Name, CType(CMlngCmbGridFontSize, Single))   'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColHoldName) = TextAlignEnum.LeftCenter       '左寄中央揃え
                
                For llngCnt = 0 To mtypMasItemList.lngListCnt - 1
                    .AddItem(mtypMasItemList.typeMasItem(llngCnt).strItemName _
                           & vbTab _
                           & mtypMasItemList.typeMasItem(llngCnt).strItemID)
                Next llngCnt
                
                '@保留理由が1件の場合
                If .ListCount = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbMasHoldList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbHoldEmpName_Disp
    '機　能：保留責任者ｺﾝﾎﾞﾘｽﾄｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/17 (Thu) 13:19:11 S.Deguchi
    '更新日：2005/11/17 (Thu) 13:19:11
    '備　考：
    Private Sub prvCmbHoldEmpName_Disp()

        Dim llngCnt As Integer      '汎用ｶｳﾝﾀ

        Try

            '@ｺﾝﾎﾞ作成
            With cmbHoldEmpName
                .Clear()
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColHoldName                               'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColHoldID                               '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Text = vbNullString                                            '初期化
                .Font = New Font(.Font.Name, CType(CMlngCmbFontSize, Single))               'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.Name, CType(CMlngCmbGridFontSize, Single))       'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColHoldName) = TextAlignEnum.LeftCenter           '左寄中央揃え
                
                For llngCnt = 0 To mlngHoldEmpListCnt - 1
                
                    '@ｺﾝﾎﾞ内容設定：保留責任者名/保留責任者ID
                    .AddItem(mtypHoldEmpList(llngCnt).strTechManName _
                           & vbTab _
                           & mtypHoldEmpList(llngCnt).strTechManID)
                Next
                
                '@保留責任者が1件の場合は表示
                If .ListCount = 1 Then
                    .ListIndex = 0
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbHoldEmpName_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2005/11/17 (Thu) 13:19:11 S.Deguchi **************************************************

    '@↓2005/11/22 (Tue) 10:27:11 S.Deguchi **************************************************
    '関数名：prvblnInvHold_Proc
    '機　能：在庫保留確定処理
    '引　数：なし
    '戻り値：True：成功/False：失敗
    '作成日：2005/11/22 (Tue) 10:23:59 S.Deguchi
    '更新日：2005/11/22 (Tue) 10:23:59
    '備　考：
    Private Function prvblnInvHold_Proc() As Boolean

        Dim lblnAns                 As Boolean              '登録戻り値(True/False)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypChangeStateList     As ChangeStateList      '在庫状態変更
        Dim lstrMailTemp            As String               'ﾒｰﾙ本文作成用退避領域
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrAns                 As String               'ﾒｰﾙｱﾄﾞﾚｽ取得

        Try

            '@初期化
            prvblnInvHold_Proc = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "prvblnInvHold_Proc"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@作業者IDからﾒｰﾙｱﾄﾞﾚｽ取得処理
            lstrAns = pubstrMailAddress_Sel(ptypSendMessageList.strSendEmpID)
            '@結果判定
            If lstrAns = vbNullString Then
            '@成功の場合
                '@ｱﾄﾞﾚｽが存在していない場合
                '@ﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005N, CMstrEmp, ptypSendMessageList.strSendEmpName)

                '@pubVsfInfo_Disp("[%1 %2]のメールアドレスが取得できず、$[%2]へメール送信できませんでした。")
                Call pubVsfInfo_Disp(pstrDMsg)
            Else
                '@領域の件数を増やす
                ptypSendMessageList.lngMailListCnt = ptypSendMessageList.lngMailListCnt + 1

                '@領域確保
                If ptypSendMessageList.typMailList Is Nothing Then
                    ptypSendMessageList.typMailList = New List(Of MailList)
                End If
                Do While (ptypSendMessageList.typMailList.Count < ptypSendMessageList.lngMailListCnt)
                    ptypSendMessageList.typMailList.Add(New MailList)
                Loop
                Dim typMailListtmp = New MailList
                '@ﾒｰﾙｱﾄﾞﾚｽ
                typMailListtmp.strMailAddress = lstrAns
                ptypSendMessageList.typMailList(ptypSendMessageList.lngMailListCnt - 1) = typMailListtmp
            End If
            
            With ltypChangeStateList
                '@保留設定する場合
                .strSbID = pstrSBID                                                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strClassDivison = vbNullString                                             '処理区分
                .strVenderClassId = vbNullString                                            '部品ID(Null)
                .strLotID = lblLotID.Text                                                'ﾛｯﾄID
                .strLotEventId = CMstrHoldID                                                'ﾛｯﾄｲﾍﾞﾝﾄID
                .strReasonCode = cmbMasHold.Value                                           '保留理由ID
                .strNum = vbNullString                                                      '数量(Null)
                .strComments = txtHoldComment.Text                                          'ｺﾒﾝﾄ
                .strEmpID = pstrUserID                                                      '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate                                       '最終更新日時
                
                If Not IsNothing(.typWfList) Then
                    .typWfList.Clear()                                         'WFﾘｽﾄ(Null)：初期化
                    .typWfList = Nothing
                End If
                
                .strHoldTermDate = dtpHoldTermDate.Value                                    '保留期限
                .strHoldEmpID = mstrHoldEmpID                                               '保留責任者
                .strEntryTime = vbNullString                                                '登録日時(Null)
            End With
            
            '@在庫WFﾘｽﾄ更新処理
            lblnAns = pubblnInvChangState_Upd(CMstrinv_changstateVer,
                                              ltypChangeStateList,
                                              lstrGuidMsg,
                                              lstrGuidMsgCode)
            '@結果判定
            If lblnAns = True Then
                '@成功ﾒｯｾｰｼﾞ
                If lblCarrier.Text = vbNullString Then
                    '@pubVsfInfo_Disp("メッセージコード：C_I08%0$$ロット[ %1 ]を保留しました。")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000Y, lblLotID.Text)
                Else
                    '@pubVsfInfo_Disp("メッセージコード：C_I08%0$$ロット[ %2 ]を保留しました。キャリア[ %1 ]")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0008, lblCarrier.Text, lblLotID.Text)
                End If

                '@pubVsfInfo_Disp("メッセージコード：C_I08%0$$ロット[ %2 ]を保留しました。キャリア[ %1 ]")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ﾒｰﾙ送信処理開始
                '@初期化
                lstrMailTemp = vbNullString

                '@ﾒｰﾙ自動挿入情報を作成
                '@##########ﾒｰﾙ本文固定表記##########
                '@送信者：XXXXXXXXXX
                '@ロット№：XXXXXXXXXX
                '@機種：XXXXXXXXXX
                '@大工程：XXXXXXXXXX
                '@小工程：XXXXXXXXXX
                '@保留理由：XXXXXXXXXX
                '@保留日時：XXXXXXXXXX
                '@保留期限：XXXXXXXXXX
                '@メール本文：
                '@＜内容＞
                '@##########ﾒｰﾙ本文固定表記##########

                '@ﾒｰﾙ本文作成
                lstrMailTemp = CPstrMailSENDER & ptypSendMessageList.strSendEmpName & vbCrLf &
                               CPstrMailLOT & lblLotID.Text & vbCrLf &
                               CPstrMailPDID & mstrPDID & vbCrLf &
                               CPstrMailOPID & mstrOpID & vbCrLf &
                               CPstrMailSTEPID & mstrStepID & vbCrLf &
                               CPstrMailHOLDREASON & cmbMasHold.Text & vbCrLf &
                               CPstrMailSENDDATE & Format(CDate(ltypChangeStateList.strHoldDate), CPstrDateTimeYMDHMS) & vbCrLf &
                               CPstrMailHOLDTERMDATE & Format(CDate(dtpHoldTermDate.Value), CPstrDateTimeYMD) & vbCrLf &
                               CPstrMailHOLDComments & vbCrLf &
                               ptypSendMessageList.strMailContents

                '@ﾒｰﾙ本文差換
                ptypSendMessageList.strMailContents = lstrMailTemp

                '@ﾒｯｾｰｼﾞ送信【ﾒｰﾙ送信】
                lblnAns = pubblnGuidSendMessage_Sel(ptypSendMessageList)
                '@結果判定
                If lblnAns = True Then
                '@成功の場合
                    '@表示ﾒｯｾｰｼﾞ変換("<TRM4SI>$$メールの送信を受け付けました。")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004S)

                    '@ﾒｯｾｰｼﾞ表示
                   Call pubVsfInfo_Disp(pstrDMsg)
                End If
            Else
            '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Function
            End If
            
            '@成功を返す
            prvblnInvHold_Proc = True
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInvHold_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnInvHoldCancel_Proc
    '機　能：在庫保留解除確定処理
    '引　数：なし
    '戻り値：True：成功/False：失敗
    '作成日：2005/11/22 (Tue) 10:24:47 S.Deguchi
    '更新日：2005/11/22 (Tue) 10:24:47
    '備　考：
    Private Function prvblnInvHoldCancel_Proc() As Boolean

        Dim lblnAns                 As Boolean          '登録戻り値(True/False)
        Dim ltypChangeStateList     As ChangeStateList  '在庫状態変更
        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrGuidMsg             As String           'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String           'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String           '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        
        Try

            '@初期化
            prvblnInvHoldCancel_Proc = False

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "prvblnInvHoldCancel_Proc"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@在庫ﾛｯﾄの状態変更
            With ltypChangeStateList
            '@保留解除設定する場合
                '@在庫状態変更設定ﾃﾞｰﾀ作成
                .strSbID = pstrSBID                                                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strClassDivison = vbNullString                                             '処理区分
                .strVenderClassId = vbNullString                                            '部品ID(Null)
                .strLotID = lblLotID.Text                                                'ﾛｯﾄID
                .strLotEventId = CMstrHoldCancelID                                          'ﾛｯﾄｲﾍﾞﾝﾄID
                .strReasonCode = cmbMasHold.Value                                           '保留理由ID
                .strNum = vbNullString                                                      '数量(Null)
                .strComments = txtHoldComment.Text                                          'ｺﾒﾝﾄ
                .strEmpID = pstrUserID                                                      '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate                                       '最終更新日時
                
                If Not IsNothing(.typWfList) Then
                    .typWfList.Clear()                                                      'WFﾘｽﾄ(Null)
                    .typWfList = Nothing
                End If
                
                .strHoldTermDate = dtpHoldTermDate.Value                                    '保留期限
                .strHoldEmpID = mstrHoldEmpID                                               '保留責任者
                .strEntryTime = vsfLotHoldList.GetData(vsfLotHoldList.Row,
                                                       CMlngvsfLotHoldListColEntryTime)        '登録日時
            End With
            
            '@在庫WFﾘｽﾄ更新処理
            lblnAns = pubblnInvChangState_Upd(CMstrinv_changstateVer, _
                                              ltypChangeStateList, _
                                              lstrGuidMsg, _
                                              lstrGuidMsgCode)
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
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
                
                '@保留解除ﾒｯｾｰｼﾞ表示
                If lblCarrier.Text = vbNullString Then
                    '@pubVsfInfo_Disp("メッセージコード：C_I08%0$$ロット[ %1 ]を保留解除しました。")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000Z, lblLotID.Text)
                Else
                    '@pubVsfInfo_Disp("メッセージコード：C_I09%0$$ロット[ %2 ]を保留解除しました。キャリア[ %1 ]")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0009, lblCarrier.Text, lblLotID.Text)
                End If
                
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
            '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            
                Exit Function
            End If

            '@成功を返す
            prvblnInvHoldCancel_Proc = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInvHoldCancel_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnLotHold_Proc
    '機　能：ﾛｯﾄ保留確定処理
    '引　数：なし
    '戻り値：True：成功/False：失敗
    '作成日：2005/11/22 (Tue) 10:24:53 S.Deguchi
    '更新日：2005/11/22 (Tue) 10:24:53
    '備　考：
    Private Function prvblnLotHold_Proc() As Boolean

        Dim lblnAns                 As Boolean              '登録戻り値(True/False)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypLotHoldset          As LotHoldset           'ﾛｯﾄ保留設定要求格納用
        Dim lstrMailTemp            As String               'ﾒｰﾙ本文作成用退避領域
        Dim lstrAns                 As String               'ﾒｰﾙｱﾄﾞﾚｽ取得

        Try

            '@初期化
            prvblnLotHold_Proc = False

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "prvblnLotHold_Proc"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@作業者IDからﾒｰﾙｱﾄﾞﾚｽ取得処理
            lstrAns = pubstrMailAddress_Sel(ptypSendMessageList.strSendEmpID)
            '@結果判定
            If lstrAns = vbNullString Then
            '@成功の場合
                '@ｱﾄﾞﾚｽが存在していない場合
                '@ﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005N, CMstrEmp, ptypSendMessageList.strSendEmpName)

                '@pubVsfInfo_Disp("[%1 %2]のメールアドレスが取得できず、$[%2]へメール送信できませんでした。")
                Call pubVsfInfo_Disp(pstrDMsg)
            Else
                '@領域の件数を増やす
                ptypSendMessageList.lngMailListCnt = ptypSendMessageList.lngMailListCnt + 1

                '@領域確保
                If ptypSendMessageList.typMailList Is Nothing Then
                    ptypSendMessageList.typMailList = New List(Of MailList)
                End If
                Do While (ptypSendMessageList.typMailList.Count < ptypSendMessageList.lngMailListCnt)
                    ptypSendMessageList.typMailList.Add(New MailList)
                Loop

                Dim typSendMailTmp = New MailList
                '@ﾒｰﾙｱﾄﾞﾚｽ
                typSendMailTmp.strMailAddress = lstrAns
                ptypSendMessageList.typMailList(ptypSendMessageList.lngMailListCnt - 1) = typSendMailTmp
            End If
            
            '@ﾛｯﾄ保留設定ﾃﾞｰﾀ作成
            With ltypLotHoldset
                .strLotID = lblLotID.Text                            'ﾛｯﾄID
                .strHoldReasonID = cmbMasHold.Value                     '保留理由ID
                .strHoldComment = txtHoldComment.Text                   '保留ｺﾒﾝﾄ
                
                If dtpHoldTermDate.Value <> CPstrNullDate Then          '保留期限
                    .strHoldTermDate = dtpHoldTermDate.Value
                Else
                    .strHoldTermDate = vbNullString
                End If
                
                .strHoldEmpID = mstrHoldEmpID                           '保留責任者ID
                .strEmpID = ptypSendMessageList.strSendEmpID            '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate                   'ﾛｯﾄ最終更新日時
            End With
            
            '@ﾛｯﾄ保留処理
            lblnAns = pubblnLotHold_Ins(CMstrlot_hold____Ver, ltypLotHoldset)
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
                '@成功ﾒｯｾｰｼﾞ
                If lblCarrier.Text = vbNullString Then
                    '@pubVsfInfo_Disp("メッセージコード：C_I08%0$$ロット[ %1 ]を保留しました。")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000Y, lblLotID.Text)
                Else
                    '@pubVsfInfo_Disp("メッセージコード：C_I08%0$$ロット[ %2 ]を保留しました。キャリア[ %1 ]")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0008, lblCarrier.Text, lblLotID.Text)
                End If

                '@pubVsfInfo_Disp("メッセージコード：C_I08%0$$ロット[ %2 ]を保留しました。キャリア[ %1 ]")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ﾒｰﾙ送信処理開始
                '@初期化
                lstrMailTemp = vbNullString

                '@ﾒｰﾙ自動挿入情報を作成
                '@##########ﾒｰﾙ本文固定表記##########
                '@送信者：XXXXXXXXXX
                '@ロット№：XXXXXXXXXX
                '@機種：XXXXXXXXXX
                '@大工程：XXXXXXXXXX
                '@小工程：XXXXXXXXXX
                '@保留理由：XXXXXXXXXX
                '@保留日時：XXXXXXXXXX
                '@保留期限：XXXXXXXXXX
                '@メール本文：
                '@＜内容＞
                '@##########ﾒｰﾙ本文固定表記##########

                '@ﾒｰﾙ本文作成
                lstrMailTemp = CPstrMailSENDER & ptypSendMessageList.strSendEmpName & vbCrLf & _
                               CPstrMailLOT & lblLotID.Text & vbCrLf & _
                               CPstrMailPDID & mstrPDID & vbCrLf & _
                               CPstrMailOPID & mstrOpID & vbCrLf & _
                               CPstrMailSTEPID & mstrStepID & vbCrLf & _
                               CPstrMailHOLDREASON & cmbMasHold.Text & vbCrLf & _
                               CPstrMailSENDDATE & Format(CDate(ltypLotHoldset.strHoldEditTime), CPstrDateTimeYMDHMS) & vbCrLf & _
                               CPstrMailHOLDTERMDATE & Format(CDate(dtpHoldTermDate.Value), CPstrDateTimeYMD) & vbCrLf & _
                               CPstrMailHOLDComments & vbCrLf & _
                               ptypSendMessageList.strMailContents

                '@ﾒｰﾙ本文差換
                ptypSendMessageList.strMailContents = lstrMailTemp

                '@ﾒｯｾｰｼﾞ送信【ﾒｰﾙ送信】
                lblnAns = pubblnGuidSendMessage_Sel(ptypSendMessageList)
                '@結果判定
                If lblnAns = True Then
                '@成功の場合
                    '@表示ﾒｯｾｰｼﾞ変換("<TRM4SI>$$メールの送信を受け付けました。")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004S)

                    '@ﾒｯｾｰｼﾞ表示
                   Call pubVsfInfo_Disp(pstrDMsg)
                End If
            Else
            '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Function
            End If
            
            '@成功を返す
            prvblnLotHold_Proc = True

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotHold_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnLotHoldCancel_Proc
    '機　能：ﾛｯﾄ保留解除確定処理
    '引　数：なし
    '戻り値：True：成功/False：失敗
    '作成日：2005/11/22 (Tue) 10:24:56 S.Deguchi
    '更新日：2005/11/22 (Tue) 10:24:56
    '備　考：
    Private Function prvblnLotHoldCancel_Proc() As Boolean

        Dim lblnAns                 As Boolean          '登録戻り値(True/False)
        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrFunctionID          As String           '機能ID
        Dim lstrActionID            As String           'ｱｸｼｮﾝID
        Dim lstrEmpID               As String           '作業者ID
        Dim lstrEmpName             As String           '作業者名
        Dim lstrSBID                As String           'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim ltypLotHoldRelesset     As LotHoldRelesset  'ﾛｯﾄ保留解除要求格納用
        Dim lstrGuidMsg             As String           'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String           'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String           '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg

        Try

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "prvblnLotHoldCancel_Proc"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@初期化
            prvblnLotHoldCancel_Proc = False
            
            '@保留理由により，実行権限のﾁｪｯｸを行う(リワーク)
            With vsfLotHoldList
                If .GetData(.Row, CMlngvsfLotHoldListColHoldReasonID) = CPstrReworkReasonCode Then
                    '@実行権限の処理
                    lstrFunctionID = CPstrKeyEN00F0                         '機能ID: EN00F0
                    lstrActionID = CPstrReworkHoldCancel                    'ｱｸｼｮﾝID：ﾘﾜｰｸ保留解除
                    lstrEmpID = pstrUserID                                  'ﾕｰｻﾞｰID
                    lstrEmpName = pstrUserName                              'ﾕｰｻﾞｰ名
                    lstrSBID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
            
                    '@実行権限ﾁｪｯｸ
                    lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, lstrEmpID, lstrEmpName, lstrSBID)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrReworkHoldCancel)
                        
                        '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                        Exit Function
                    End If
                End If
            End With
            
            '@ﾛｯﾄ保留解除ﾃﾞｰﾀ作成
            With ltypLotHoldRelesset
                .strLotID = lblLotID.Text                            'ﾛｯﾄID
                .strHoldReleseComment = txtHoldComment.Text             '保留解除ｺﾒﾝﾄ
                .strEmpID = pstrUserID                                  '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate                   'ﾛｯﾄ最終更新日時
                '@登録日時
                .strEntryTime = vsfLotHoldList.GetData(vsfLotHoldList.Row, 
                                                       CMlngvsfLotHoldListColEntryTime)
            End With
            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し(保留解除)
            lblnAns = pubblnLotReleaseHold_Upd(CMstrlot_holdreleaseVer, _
                                               ltypLotHoldRelesset, _
                                               lstrGuidMsg, _
                                               lstrGuidMsgCode)
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
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
            
                '@保留解除ﾒｯｾｰｼﾞ表示
                If lblCarrier.Text = vbNullString Then
                    '@pubVsfInfo_Disp("メッセージコード：C_I08%0$$ロット[ %1 ]を保留解除しました。")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000Z, lblLotID.Text)
                Else
                    '@pubVsfInfo_Disp("メッセージコード：C_I09%0$$ロット[ %2 ]を保留解除しました。キャリア[ %1 ]")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0009, lblCarrier.Text, lblLotID.Text)
                End If
                
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
            '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Function
            End If
            
            '@成功を返す
            prvblnLotHoldCancel_Proc = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotHoldCancel_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnMailConnectInfo_Set
    '機　能：ﾒｰﾙ引継情報の格納処理
    '引　数：なし
    '戻り値：True：成功/False：失敗
    '作成日：2005/11/22 (Tue) 09:00:00 S.Deguchi
    '更新日：2008/06/11 (Wed) 11:25:07 N.Kojima
    '備　考：
    '　　　：2005/12/14 (Wed) 13:16:30 S.Deguchi    技術担当者が空欄の場合にはｱﾄﾞﾚｽ取得処理を行わないように修正
    '　　　：2008/06/11 (Wed) 11:25:07 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Function prvblnMailConnectInfo_Set() As Boolean

        Dim lblnAns                 As Boolean              '登録戻り値(True/False)
        Dim llngCnt                 As Integer              'ｶｳﾝﾄ
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypMasRoleEmpListReq   As MasRoleEmpListReq    '職制社員ﾘｽﾄ要求構造体
        Dim ltypMasRoleEmpListAns   As MasRoleEmpListAns    '職制社員ﾘｽﾄ応答構造体
        Dim lblnMailAddressChk      As Boolean              'ﾒｰﾙｱﾄﾞﾚｽﾁｪｯｸ(True：ｱﾄﾞﾚｽ有/False：ｱﾄﾞﾚｽ無)
        Dim llngGetAdoress          As Integer              '取得ｱﾄﾞﾚｽ件数
        Dim lstrAns                 As String               'ｱﾄﾞﾚｽ返却値
        Dim lblnDChkFlag            As Boolean              '重複ﾁｪｯｸﾌﾗｸﾞ
        Dim llngCnt2                As Integer
        
        Try

            '@関数初期化
            prvblnMailConnectInfo_Set = False

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "prvblnMailConnectInfo_Set"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ﾒｰﾙ引継内容格納
            With ptypMailInfo
                '@初期化
                .strMailContents = vbNullString
                .strMailSubject = vbNullString

                '@ﾒｰﾙｱﾄﾞﾚｽﾘｽﾄの初期化
                If Not IsNothing(ptypSendMailList.typSendMail) Then
                    ptypSendMailList.typSendMail.Clear()
                    ptypSendMailList.typSendMail = Nothing
                End If

                ptypSendMailList.lngSendMailCnt = 0

                '@件名格納：ロット保留(%1)
                .strMailSubject = Replace(CPstrMailSubjectHold, "%1", lblLotID.Text)

                '@本文格納：ロット保留コメント内容
                .strMailContents = txtHoldComment.Text

                '@ｱﾄﾞﾚｽ格納
                '@作業長情報取得引数ｾｯﾄ
                With ltypMasRoleEmpListReq
                    .strMsgVer = CMstrmas_roleemplistVer        'MsgVer
                    .strRole = CPstrRoleForeman                 '職制：作業長
                    .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                End With

                '@作業長情報取得処理
                lblnAns = pubblnMasRoleEmpList_Sel(ltypMasRoleEmpListReq, ltypMasRoleEmpListAns)
                '@結果判定
                If lblnAns = True Then
                '@成功の場合
                    '@初期化
                    lblnMailAddressChk = False
                    
                    '@取得件数でﾙｰﾌﾟを廻し,1件でもｱﾄﾞﾚｽが存在すれば続行
                    For llngCnt = 0 To ltypMasRoleEmpListAns.lngRoleEmpListCnt -1
                        If ltypMasRoleEmpListAns.typRoleEmpList(llngCnt).strMailAddress <> vbNullString Then
                            '@存在ﾁｪｯｸﾌﾗｸﾞを立てる
                            lblnMailAddressChk = True
                            
                            '@処理抜け
                            Exit For
                        End If
                    Next llngCnt
                    
                    '@存在ﾁｪｯｸから処理分岐
                    If lblnMailAddressChk = False Then
                    '@ｱﾄﾞﾚｽが存在しない場合
                        '@ﾒｯｾｰｼﾞを表示する
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007G, CPstrRoleForeman)
                    
                        '@pubVsfInfo_Disp("[作業長]のメールアドレスが取得できませんでした。")
                        Call pubVsfInfo_Disp(pstrDMsg)
                    Else
                    '@ｱﾄﾞﾚｽが存在する場合
                        '@初期化
                        llngGetAdoress = 0
                        
                        '@ﾙｰﾌﾟを廻してｱﾄﾞﾚｽがある場合のみ領域を確保,情報を格納
                        For llngCnt = 0 To ltypMasRoleEmpListAns.lngRoleEmpListCnt -1
                            '@ｱﾄﾞﾚｽ存在ﾁｪｯｸ
                            If ltypMasRoleEmpListAns.typRoleEmpList(llngCnt).strMailAddress <> vbNullString Then
                                '@取得件数を格納
                                ptypSendMailList.lngSendMailCnt = ptypSendMailList.lngSendMailCnt + 1
                                llngGetAdoress = ptypSendMailList.lngSendMailCnt
                    
                                '@取得件数分領域を確保
                                If ptypSendMailList.typSendMail Is Nothing Then
                                    ptypSendMailList.typSendMail = New List(Of SendMail)
                                End If

                                Dim typSendMailtmp = New SendMail
                                '@作業長ID
                                typSendMailtmp.strID = ltypMasRoleEmpListAns.typRoleEmpList(llngCnt).strEmpID
                                '@作業長名
                                typSendMailtmp.strName = ltypMasRoleEmpListAns.typRoleEmpList(llngCnt).strEmpName
                                '@ﾒｰﾙｱﾄﾞﾚｽ
                                typSendMailtmp.strMail1 = ltypMasRoleEmpListAns.typRoleEmpList(llngCnt).strMailAddress
                                ptypSendMailList.typSendMail.Add(typSendMailtmp)
                
                            End If
                        Next llngCnt
                    End If
                Else
                '@失敗の場合
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    Exit Function
                End If
                
                '@ﾛｯﾄ担当者IDがNULLか
                If mstrLotManagerID = vbNullString Then
                
                    '@ﾛｯﾄ担当者IDが空欄の場合には処理ｽｷｯﾌﾟ
                    
                Else
                    '@ﾛｯﾄ担当者ｱﾄﾞﾚｽ取得
                    lstrAns = pubstrMailAddress_Sel(mstrLotManagerID)
                    
                    '@結果判定
                    If lstrAns = vbNullString Then
                    '@成功の場合
                        '@ｱﾄﾞﾚｽが存在していない場合
                        '@ﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000Z, CMstrLotManager, mstrLotManagerName)
            
                        '@pubVsfInfo_Disp("[△△ ○○]のメールアドレスが取得できませんでした。")
                        Call pubVsfInfo_Disp(pstrDMsg)
                    Else
                    '@ｱﾄﾞﾚｽ取得できた場合
                        '@既に格納されたｱﾄﾞﾚｽでない場合のみ格納
                        lblnDChkFlag = False
                        For llngCnt = 0 To ptypSendMailList.lngSendMailCnt - 1
                            If lstrAns = ptypSendMailList.typSendMail(llngCnt).strMail1 Then
                                lblnDChkFlag = True
                                
                                Exit For
                            End If
                        Next llngCnt
                        
                        If lblnDChkFlag = False Then
                            'NSYS 現在の領域の件数を保持
                            llngCnt2 = ptypSendMailList.lngSendMailCnt

                            '@領域の件数を増やす
                            ptypSendMailList.lngSendMailCnt = ptypSendMailList.lngSendMailCnt + 1
                
                            '@領域確保
                            If ptypSendMailList.typSendMail Is Nothing Then
                                ptypSendMailList.typSendMail = New List(Of SendMail)
                            End If
                            Do While (ptypSendMailList.typSendMail.Count < ptypSendMailList.lngSendMailCnt)
                                ptypSendMailList.typSendMail.Add(New SendMail)
                            Loop
                
                            Dim typSendMailtmp = New SendMail

                            For llngCnt = llngCnt2 To ptypSendMailList.lngSendMailCnt - 1
                            '@作業者ID
	                            typSendMailtmp.strID = mstrLotManagerID
	                
	                            '@作業者名
	                            typSendMailtmp.strName = mstrLotManagerName
	                
	                            '@ﾒｰﾙｱﾄﾞﾚｽ
								typSendMailtmp.strMail1 = lstrAns
	                                ptypSendMailList.typSendMail(llngCnt) = typSendMailtmp
                            Next llngCnt
                            
                        End If
                    End If
                End If
                
                '@保留責任者IDがNULLか
                If mstrHoldEmpID = vbNullString Then
                
                    '@保留担当者IDが空欄の場合には処理ｽｷｯﾌﾟ：本来ありえない
                    
                Else
                    '@保留責任者ｱﾄﾞﾚｽ取得
                    lstrAns = pubstrMailAddress_Sel(mstrHoldEmpID)
                    '@結果判定
                    If lstrAns = vbNullString Then
                    '@成功の場合
                        '@ｱﾄﾞﾚｽが存在していない場合
                        '@ﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000Z, CMstrHold, cmbHoldEmpName.Text)
            
                        '@pubVsfInfo_Disp("[△△ ○○]のメールアドレスが取得できませんでした。")
                        Call pubVsfInfo_Disp(pstrDMsg)
                    Else
                    '@ｱﾄﾞﾚｽ取得できた場合
                        '@既に格納されたｱﾄﾞﾚｽでない場合のみ格納
                        lblnDChkFlag = False
                        For llngCnt = 0 To ptypSendMailList.lngSendMailCnt - 1
                            If lstrAns = ptypSendMailList.typSendMail(llngCnt).strMail1 Then
                                lblnDChkFlag = True
                                
                                Exit For
                            End If
                        Next llngCnt
                        
                        If lblnDChkFlag = False Then
                            'NSYS 現在の領域の件数を保持
                            llngCnt2 = ptypSendMailList.lngSendMailCnt

                            '@領域の件数を増やす
                            ptypSendMailList.lngSendMailCnt = ptypSendMailList.lngSendMailCnt + 1
                
                            '@領域確保
                            If ptypSendMailList.typSendMail Is Nothing Then
                                ptypSendMailList.typSendMail = New List(Of SendMail)
                            End If
                            Do While (ptypSendMailList.typSendMail.Count < ptypSendMailList.lngSendMailCnt)
                                ptypSendMailList.typSendMail.Add(New SendMail)
                            Loop

                            '@領域確保
                            Dim typSendMailTmp = New SendMail
                
                            For llngCnt = llngCnt2 To ptypSendMailList.lngSendMailCnt - 1
                            '@作業者ID
                                typSendMailTmp.strID = mstrHoldEmpID
                
                            '@作業者名
                                typSendMailTmp.strName = cmbHoldEmpName.Text
                
                            '@ﾒｰﾙｱﾄﾞﾚｽ
                                typSendMailTmp.strMail1 = lstrAns
                                ptypSendMailList.typSendMail(llngCnt) = typSendMailTmp
                            Next llngCnt
                            
                        End If
                    End If
                End If
            End With

            '@成功を返す
            prvblnMailConnectInfo_Set = True

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnMailConnectInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function
    '@↑2005/11/22 (Tue) 10:27:11 S.Deguchi **************************************************


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

        End Select

        MyBase.WndProc(m)

        If lblnSysCommandScClose = True Then
            'NSYS SC_CLOSE 処理後 WM_CLOSE が発生しないでキャンセルされることもあるため、フラグを戻す
            'NSYS WM_CLOSE が発生していれば、すでにこの時点では画面は閉じている
            mblnCloseFromControlMenu = False
        End If
        'If lblnWMClose = True Then
        '    'NSYS WM_CLOSE 処理後 終了がキャンセルされることもあるため、フラグを戻す
        '    'NSYS 終了処理されれば、すでにこの時点では画面は閉じている
        '    mblnWindowClose = False
        'End If
    End Sub


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraHold.Paint, fraHoldList.Paint, fraHoldSet.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
