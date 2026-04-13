'ﾌｧｲﾙ名：xxEN01N0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：CMPメンテナンス　メインフォーム
'作成日：2005/03/14 (Mon) 14:47:31 N.Kasai
'更新日：2008/06/16 (Mon) 16:19:03 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01N0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01N0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01N0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01N0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01N0)
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
    Private Const CMstrLocalVersion                     As String = "02.00"                 '機能ﾊﾞｰｼﾞｮﾝ

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_wplist__Ver                  As String = "05.01"                 '装置一覧取得
    Private Const CMstreq__cmplist_Ver                  As String = "02.00"                 'CMP情報一覧取得
    Private Const CMstreq__chgcmprateVer                As String = "01.00"                 '研磨ﾚｰﾄ変更
    Private Const CMstreq__chgcmpstatVer                As String = "01.00"                 'CMP状態変更

    '@機能名
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN01N0          'ﾛｰｶﾙﾒﾆｭｰKey

    '@vsfCmpListの定数宣言（ｶﾗﾑ）
    Private Const CMlngvsfCmpNo                         As Integer = 0                         '№
    Private Const CMlngvsfCmpKb                         As Integer = 1                         '使用可否
    Private Const CMlngvsfCmpWpName                     As Integer = 2                         '装置名
    Private Const CMlngvsfCmpH                          As Integer = 3                         'ﾍｯﾄﾞ
    Private Const CMlngvsfCmpP                          As Integer = 4                         'ﾌﾟﾗﾃﾝ
    Private Const CMlngvsfCmpPolRate                    As Integer = 5                         '研磨ﾚｰﾄ
    Private Const CMlngvsfCmpRateCalcTime               As Integer = 6                         'ﾚｰﾄ計算日時
    Private Const CMlngvsfCmpLotID                      As Integer = 7                         'ﾚｰﾄ計算ﾛｯﾄID
    Private Const CMlngvsfCmpOpID                       As Integer = 8                         '大工程
    Private Const CMlngvsfCmpPolTime                    As Integer = 9                         '研磨時間
    Private Const CMlngvsfCmp1st                        As Integer = 10                        '1st膜厚
    Private Const CMlngvsfCmp2nd                        As Integer = 11                        '2nd膜厚
    Private Const CMlngvsfCmpWpID                       As Integer = 12                        '装置ID（非表示）
    Private Const CMlngvsfCmpAvailFlag                  As Integer = 13                        '変更可否F（非表示）
    Private Const CMlngvsfCmpEditTime                   As Integer = 14                        '応答ﾒｯｾｰｼﾞ日時(非表示）
    Private Const CMlngvsfCmpEventName                  As Integer = 15                        'ｲﾍﾞﾝﾄ名（非表示）
    Private Const CMlngvsfCmpComments                   As Integer = 16                        '最新ｺﾒﾝﾄ（非表示）

    '@vsfCmpListの定数宣言（幅）
    Private Const CMlngvsfCmpWNo                        As Integer = 37                       '№
    Private Const CMlngvsfCmpWKb                        As Integer = 20                       '使用可否
    Private Const CMlngvsfCmpWWpName                    As Integer = 166                      '装置名
    Private Const CMlngvsfCmpWH                         As Integer = 20                       'ﾍｯﾄﾞ
    Private Const CMlngvsfCmpWP                         As Integer = 20                       'ﾌﾟﾗﾃﾝ
    Private Const CMlngvsfCmpWPolRate                   As Integer = 66                      '研磨ﾚｰﾄ
    Private Const CMlngvsfCmpWRateCalcDate              As Integer = 200                      'ﾚｰﾄ計算日時
    Private Const CMlngvsfCmpWLotID                     As Integer = 120                      'ﾚｰﾄ計算ﾛｯﾄID
    Private Const CMlngvsfCmpWOpID                      As Integer = 166                      '大工程
    Private Const CMlngvsfCmpWPolTime                   As Integer = 66                      '研磨時間
    Private Const CMlngvsfCmpW1st                       As Integer = 66                      '1st膜厚
    Private Const CMlngvsfCmpW2nd                       As Integer = 66                      '2nd膜厚
    Private Const CMlngvsfCmpWWpID                      As Integer = 66                      '装置ID（非表示）
    Private Const CMlngvsfCmpWAvaiFlag                  As Integer = 66                      '変更可否F（非表示）
    Private Const CMlngvsfCmpWEditTime                  As Integer = 66                      '応答ﾒｯｾｰｼﾞ日時(非表示）
    Private Const CMlngvsfCmpWEventName                 As Integer = 66                      'ｲﾍﾞﾝﾄ名（非表示）
    Private Const CMlngvsfCmpWComments                  As Integer = 66                      '最新ｺﾒﾝﾄ（非表示）

    '@vsfCmpListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrvsfCmpTNo                        As String = "№"                    '№
    Private Const CMstrvsfCmpTKb                        As String = CPstrSpace              '使用可否
    Private Const CMlngvsfCmpTWpName                    As String = "装置名"                '装置名
    Private Const CMlngvsfCmpTH                         As String = "H"                     'ﾍｯﾄﾞ
    Private Const CMlngvsfCmpTP                         As String = "P"                     'ﾌﾟﾗﾃﾝ
    Private Const CMlngvsfCmpTPolRate                   As String = "研磨ﾚｰﾄ"               '研磨ﾚｰﾄ
    Private Const CMlngvsfCmpTRateCalcDate              As String = "ﾚｰﾄ計算日時"           'ﾚｰﾄ計算日時
    Private Const CMlngvsfCmpTLotID                     As String = "ﾚｰﾄ計算ﾛｯﾄID"          'ﾚｰﾄ計算ﾛｯﾄID
    Private Const CMlngvsfCmpTOpID                      As String = "大工程"                '大工程
    Private Const CMlngvsfCmpTPolTime                   As String = "研磨時間"              '研磨時間
    Private Const CMlngvsfCmpT1st                       As String = "1st膜厚"               '1st膜厚
    Private Const CMlngvsfCmpT2nd                       As String = "2nd膜厚"               '2nd膜厚
    Private Const CMlngvsfCmpTWpID                      As String = "装置ID"                '装置ID（非表示）
    Private Const CMlngvsfCmpTAvaiFlag                  As String = "変更可否F"             '変更可否F（非表示）
    Private Const CMlngvsfCmpTEditTime                  As String = "応答ﾒｯｾｰｼﾞ日時"        '応答ﾒｯｾｰｼﾞ日時(非表示）
    Private Const CMlngvsfCmpTEventName                 As String = "ｲﾍﾞﾝﾄ名"               'ｲﾍﾞﾝﾄ名（非表示）
    Private Const CMlngvsfCmpTComments                  As String = "最新ｺﾒﾝﾄ"              '最新ｺﾒﾝﾄ（非表示）

    '@ｸﾞﾘｯﾄﾞ基本設定
    Private Const CMlngvsfCmpRowTitle                   As Integer = 0                         'ﾀｲﾄﾙ行（行）
    Private Const CMlngvsfCmpColTitle                   As Integer = 0                         'ﾀｲﾄﾙ行（列）
    Private Const CMlngvsfCmpHFontSize                  As Integer = 11                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfCmpHHeight                    As Integer = 20                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfCmpHeight                     As Integer = 18                       '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfCmpCols                       As Integer = 17                        'CMPｸﾞﾘｯﾄﾞMAXCol数

    '@CMP装置ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                      As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbValueCol                      As Integer = 1                         'ｸﾞﾘｯﾄﾞ値取得列
    Private Const CMlngCmbGroupCols                     As Integer = 1                         '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCMbSelectMode                    As Integer = 0                         '選択ﾓｰﾄﾞ
    Private Const CMlngCmbRowHeight                     As Integer = 18                       'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                      As Integer = 0                         '選択列数
    Private Const CMlngCmbValueCol1                     As Integer = 1                         '値取得列=1
    Private Const CMlngCmbGetCol0                       As Integer = 0                         'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=0
    Private Const CMlngCmbGetCol1                       As Integer = 1                         'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=1

    '@ﾚｽﾎﾟﾝｽ測定用
    Private Const CMstrFormName                         As String = "frmxxEN01N0"           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"             'ｲﾍﾞﾝﾄ名称（ﾌｫｰﾑﾛｰﾄﾞ）
    Private Const CMstrNowListClick                     As String = "cmdNowList_Click"      'ｲﾍﾞﾝﾄ名称（最新取得）
    Private Const CMstrHenkou_Click                     As String = "cmdHenkou_Click"       'ｲﾍﾞﾝﾄ名称（ﾚｰﾄ変更）
    Private Const CMstrKaijyo_Click                     As String = "cmdKaijyo_Click"       'ｲﾍﾞﾝﾄ名称（使用禁止解除）
    Private Const CMstrKinshi_Click                     As String = "cmdKinshi_Click"       'ｲﾍﾞﾝﾄ名称（使用禁止設定）

    '@その他
    Private Const CMstrAvailFlagOn                      As String = "1"                     '研磨ﾚｰﾄ使用可否(0：使用不可　1:使用可）
    Private Const CMstrAvailFlagOff                     As String = "0"                     '研磨ﾚｰﾄ使用可否(0：使用不可　1:使用可）
    Private Const CMstrBatu                             As String = "×"                    '「×」表示
    Private Const CMstrLastComments                     As String = "最終コメント"          '最終ｺﾒﾝﾄｷｬﾌﾟｼｮﾝ初期値
    Private Const CMstrNoSelectString                   As String = "指定なし"              '装置名指定なし文字

    '@ｺﾒﾝﾄｽｸﾛｰﾙ制御用
    Private Const CMlngMaxDispRow                       As Integer = 3                         'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用
    Private mblnFormLoad1st                             As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ（Ture:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み）
    Private mblncmbWplist_ChangeFlag                    As Boolean                          'CMP装置ｺﾝﾎﾞ変更ﾌﾗｸﾞ（Ture:変更あり、False:変更なし）
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

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑActivate処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/16 (Wed) 11:36:13 N.Kasai
    '更新日：2005/03/16 (Wed) 11:36:13
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ（Ture:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み）
            If mblnFormLoad1st = True Then
                '@Form_Loadﾌﾗｸﾞ（True:正常）を判定して画面起動中にｴﾗｰが発生した場合は最新取得を行わない。
                If pblnFormLoad = True Then
                    '@ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ（Ture:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み）
                    mblnFormLoad1st = False
                    '@CMP情報一覧取得
                    Call cmdNowList_Click(Me,New EventArgs())
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

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 13:14:13 N.Kasai
    '更新日：2005/03/15 (Tue) 13:14:13
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns                     As Boolean          '結果格納
        Dim llngWpCnt                   As Integer          '装置数格納

        Try
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01N0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(Me, New CancelEventArgs(False))
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If .typChgSortList Is Nothing 
                  .typChgSortList = New List(Of ChgSortList) 
                Else 
                  .typChgSortList.Clear()
                End If
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
           
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfCmpList_Init()
            
            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call prvfrmxxEN01N0_Init()
            
            '@装置一覧取得（CMP装置）
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, llngWpCnt, pstrSBID, CPstrCD3T)
            
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                Exit Sub
            End If
            
            '@CMP装置ｺﾝﾎﾞﾎﾞｯｸｽ作成
            Call prvcmbWplist_Disp(llngWpCnt)
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            
            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True
            
            '@ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ（Ture:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み）
            mblnFormLoad1st = True
           
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

    '関数名：Form_QueryUnload
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 13:13:43 N.Kasai
    '更新日：2005/03/15 (Tue) 13:13:43
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm             As Boolean              '開放結果格納
        Dim ltypRirekeiNextinfo     As RirekeiNextinfo      '引継ぎ構造体（履歴確認）

        Try
            
                       
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload 
                Call cmdClose_Click(Me, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload 
            End If
            
            '@DoEventsﾌﾗｸﾞが立っている場合
            If pblnTrnFlag = True Then
                e.Cancel = True
                Exit Sub
            End If
            
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
            
            '@引継ぎ構造体ｸﾘｱ
            ptypRirekeiNextinfo = ltypRirekeiNextinfo
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If  mtypChgSort.typChgSortList Is Nothing 
                 mtypChgSort.typChgSortList = New List(Of ChgSortList) 
            Else 
                mtypChgSort.typChgSortList.Clear()
            End If
            
            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄとの関連付けを解除
           
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
    '機　能：ﾌｫｰﾑ　ｷｰ押下時
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift　：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 13:10:18 N.Kasai
    '更新日：2005/03/15 (Tue) 13:10:18
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKeyを受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If
            
            Select Case e.KeyCode
                '@Enterの場合
                Case Keys.Return
                    Select Case ActiveControl.Name
                    
                    '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ
                        Case txtComments.Name
                            Exit Sub
                            
                        '@最終ｺﾒﾝﾄ
                        Case txtLastComments.Name
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

    '関数名：cmbWplist_Change
    '機　能：CMP装置ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:49:28 N.Kasai
    '更新日：2005/03/14 (Mon) 16:49:28
    '備　考：
    Private Sub cmbWplist_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWplist.Change

        Try
                      
            '@CMP装置ｺﾝﾎﾞ変更ﾌﾗｸﾞ（Ture:変更あり、False:変更なし）
            mblncmbWplist_ChangeFlag = True
            
            '@ｿｰﾄ順の初期化
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If  mtypChgSort.typChgSortList Is Nothing 
                    mtypChgSort.typChgSortList = New List(Of ChgSortList) 
                Else 
                    mtypChgSort.typChgSortList.Clear()
                End If
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call prvfrmxxEN01N0_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWplist_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWplist_CloseUp
    '機　能：CMP装置ｺﾝﾎﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:50:14 N.Kasai
    '更新日：2005/03/14 (Mon) 16:50:14
    '備　考：
    Private Sub cmbWplist_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWplist.CloseUp

        Try
                      
            '@選択結果判定
            If cmbWplist.Text <> vbNullString Then
                '@CMP装置変更処理
                RemoveHandler cmbWplist.Validating, AddressOf cmbWplist_Validate 
                Call cmbWplist_Validate(cmbWplist, New CancelEventArgs(True))
                AddHandler cmbWplist.Validating, AddressOf cmbWplist_Validate 
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWplist_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWplist_Validate
    '機　能：CMP装置変更処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:50:36 N.Kasai
    '更新日：2005/03/14 (Mon) 16:50:36
    '備　考：
    Private Sub cmbWplist_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWplist.Validating

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
            '@CMP装置ｺﾝﾎﾞ変更ﾌﾗｸﾞ（Ture:変更あり、False:変更なし）
            If mblncmbWplist_ChangeFlag = False Then
               If ActiveControl.Name = cmbWplist.Name Then 
                 '@ﾌｫｰｶｽの移動
                 If vsfCmpList.Enabled = True Then
                    '@ｸﾞﾘｯﾄﾞ
                    Call pubSetFocus(vsfCmpList)
                 Else
                    '@閉じるﾎﾞﾀﾝ
                    Call pubSetFocus(cmdClose)
                 End If
               End if
                
                Exit Sub
            End If
            
            '@CMP装置ｺﾝﾎﾞ変更ﾌﾗｸﾞ（Ture:変更あり、False:変更なし）
            mblncmbWplist_ChangeFlag = False

            '@最新ﾎﾞﾀﾝ押下処理
            Call cmdNowList_Click(sender,New EventArgs())
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWplist_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHenkou_Click
    '機　能：研磨ﾚｰﾄ変更ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 13:20:34 N.Kasai
    '更新日：2005/03/15 (Tue) 13:20:34
    '備　考：
    Private Sub cmdHenkou_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHenkou.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim typEqchgcmprate         As Eqchgcmprate         '研磨ﾚｰﾄ変更要求格納構造体
        Dim lstrWPName              As String               '成功ﾒｯｾｰｼﾞ(装置名）
        Dim lstrWpOldPolRare        As String               '成功ﾒｯｾｰｼﾞ(変更前研磨ﾚｰﾄ）
        Dim lstrMsg                 As String               '変換後ﾒｯｾｰｼﾞ

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                
                '@一覧にｾｯﾄﾌｫｰｶｽｾｯﾄ
                With vsfCmpList
                    If .Enabled = True Then
                        '@ﾌｫｰｶｽ設定
                        Call pubSetFocus(vsfCmpList)
                    End If
                End With
            
                Exit Sub
            End If
            
            '@研磨ﾚｰﾄ変更要求ﾃﾞｰﾀ格納
            With typEqchgcmprate
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstreq__chgcmprateVer
                '@WPID
                .strWpID = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpWpID)
                '@ﾍｯﾄﾞ
                .strHead = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpH)
                '@ﾌﾟﾗﾃﾝ
                .strPlaten = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpP)
                '@変更後研磨ﾚｰﾄ
                .strPolRate = Format$(Double.Parse(txtNewPolRate.Text), CPstrRate)
                '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ
                .strComments = txtComments.Text
                '@応答ﾒｯｾｰｼﾞ生成日時
                .strEditTime = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpEditTime)
                '@作業者ID
                .strEmpID = pstrUserID
            End With
            
            '@成功ﾒｯｾｰｼﾞ用文字列を格納
            lstrWPName = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpWpName)
            lstrWpOldPolRare = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpPolRate)
            
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrHenkou_Click)
            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し（ﾚｰﾄ変更）
            lblnAns = pubblnEqChgCmpRate_Upd(typEqchgcmprate)
            
            '@結果取得
            If lblnAns = True Then
               
                '@表示ﾒｯｾｰｼﾞ変換("<TRM4II>$$研磨レート（%1 → %2）を変更しました。装置[%3]ヘッド[%4]プラテン[%5]")
                With typEqchgcmprate
                    lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf004I, lstrWpOldPolRare, .strPolRate, lstrWPName, .strHead, .strPlaten)
                End With
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(lstrMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrHenkou_Click)
                
                '@画面情報更新
                Call cmdNowList_Click(sender,New EventArgs())
                
                '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄをｸﾘｱ
                txtComments.Text = vbNullString
                
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrHenkou_Click)
            End If
            
            '@一覧にｾｯﾄﾌｫｰｶｽｾｯﾄ
            With vsfCmpList
                If .Enabled = True Then
                    '@ﾌｫｰｶｽ設定
                    Call pubSetFocus(vsfCmpList)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHenkou_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdKaijyo_Click
    '機　能：使用禁止解除
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 14:59:04 N.Kasai
    '更新日：2005/03/15 (Tue) 14:59:04
    '備　考：
    Private Sub cmdKaijyo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdKaijyo.Click
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim typEqchgcmpstat         As Eqchgcmpstat         'CMP状態変更要求格納構造体
        Dim lstrWPName              As String               '成功ﾒｯｾｰｼﾞ(装置名）
        Dim lstrMsg                 As String               '変換後ﾒｯｾｰｼﾞ

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                '@一覧にｾｯﾄﾌｫｰｶｽｾｯﾄ
                With vsfCmpList
                    If .Enabled = True Then
                        '@ﾌｫｰｶｽ設定
                        Call pubSetFocus(vsfCmpList)
                    End If
                End With
                
                Exit Sub
            End If
            
            '@CMP状態変更要求ﾃﾞｰﾀ格納
            With typEqchgcmpstat
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstreq__chgcmpstatVer
                '@WPID
                .strWpID = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpWpID)
                '@ﾍｯﾄﾞ
                .strHead = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpH)
                '@ﾌﾟﾗﾃﾝ
                .strPlaten = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpP)
                '@研磨ﾚｰﾄ使用可否(0：使用不可　1:使用可）
                .strAvailFlag = CMstrAvailFlagOn
                '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ
                .strComments = txtComments.Text
                '@応答ﾒｯｾｰｼﾞ生成日時
                .strEditTime = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpEditTime)
                '@作業者ID
                .strEmpID = pstrUserID
            End With
            
            '@成功ﾒｯｾｰｼﾞ用文字列を格納
            lstrWPName = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpWpName)
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrKaijyo_Click)
            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し（CMP状態変更）
            lblnAns = pubblnEqChgCmpStat_Upd(typEqchgcmpstat)
            
            '@結果取得
            If lblnAns = True Then
              
                '@表示ﾒｯｾｰｼﾞ変換("<TRM4KI>$$使用禁止解除を行いました。装置[%1]ヘッド[%2]プラテン[%3]")
                With typEqchgcmpstat
                    lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf004K, lstrWPName, .strHead, .strPlaten)
                End With
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(lstrMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrKaijyo_Click)
                
                '@画面情報更新
                Call cmdNowList_Click(sender,New EventArgs())
                
                '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄをｸﾘｱ
                txtComments.Text = vbNullString
                
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrKaijyo_Click)
            End If
            
            '@一覧にｾｯﾄﾌｫｰｶｽｾｯﾄ
            With vsfCmpList
                If .Enabled = True Then
                    '@ﾌｫｰｶｽ設定
                    Call pubSetFocus(vsfCmpList)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdKaijyo_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdKinshi_Click
    '機　能：使用禁止設定ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 15:06:29 N.Kasai
    '更新日：2005/03/15 (Tue) 15:06:29
    '備　考：
    Private Sub cmdKinshi_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdKinshi.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim typEqchgcmpstat         As Eqchgcmpstat         'CMP状態変更要求格納構造体
        Dim lstrWPName              As String               '成功ﾒｯｾｰｼﾞ(装置名）
        Dim lstrMsg                 As String               '変換後ﾒｯｾｰｼﾞ

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
            
                '@一覧にｾｯﾄﾌｫｰｶｽｾｯﾄ
                With vsfCmpList
                    If .Enabled = True Then
                        '@ﾌｫｰｶｽ設定
                        Call pubSetFocus(vsfCmpList)
                    End If
                End With
            
                Exit Sub
            End If
            
            '@CMP状態変更要求ﾃﾞｰﾀ格納
            With typEqchgcmpstat
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstreq__chgcmpstatVer
                '@WPID
                .strWpID = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpWpID)
                '@ﾍｯﾄﾞ
                .strHead = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpH)
                '@ﾌﾟﾗﾃﾝ
                .strPlaten = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpP)
                '@研磨ﾚｰﾄ使用可否(0：使用不可　1:使用可）
                .strAvailFlag = CMstrAvailFlagOff
                '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ
                .strComments = txtComments.Text
                '@応答ﾒｯｾｰｼﾞ生成日時
                .strEditTime = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpEditTime)
                '@作業者ID
                .strEmpID = pstrUserID
            End With
            
            '@成功ﾒｯｾｰｼﾞ用文字列を格納
            lstrWPName = vsfCmpList.GetData(vsfCmpList.Row, CMlngvsfCmpWpName)
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrKinshi_Click)
            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し（CMP状態変更）
            lblnAns = pubblnEqChgCmpStat_Upd(typEqchgcmpstat)
            
            '@結果取得
            If lblnAns = True Then
              
                '@表示ﾒｯｾｰｼﾞ変換("<TRM4JI>$$使用禁止設定を行いました。装置[%1]ヘッド[%2]プラテン[%3]")
                With typEqchgcmpstat
                    lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf004J, lstrWPName, .strHead, .strPlaten)
                End With
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(lstrMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrKinshi_Click)
                
                '@画面情報更新
                Call cmdNowList_Click(sender,New EventArgs())
                
                '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄをｸﾘｱ
                txtComments.Text = vbNullString
                
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrKinshi_Click)
            End If
            
            '@一覧にｾｯﾄﾌｫｰｶｽｾｯﾄ
            With vsfCmpList
                If .Enabled = True Then
                    '@ﾌｫｰｶｽ設定
                    Call pubSetFocus(vsfCmpList)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdKinshi_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRireki_Click
    '機　能：ﾒﾝﾃﾅﾝｽ履歴ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 13:18:08 N.Kasai
    '更新日：2005/03/15 (Tue) 13:18:08
    '備　考：
    Private Sub cmdRireki_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRireki.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
                
            '@引継ぎ構造体に値を格納する。
            With vsfCmpList
                ptypCmpRirekeiinfo.strWpID = .GetData(.Row, CMlngvsfCmpWpID)
                ptypCmpRirekeiinfo.strWpName = .GetData(.Row, CMlngvsfCmpWpName)
                ptypCmpRirekeiinfo.strHead = .GetData(.Row, CMlngvsfCmpH)
                ptypCmpRirekeiinfo.strPlaten = .GetData(.Row, CMlngvsfCmpP)
                ptypCmpRirekeiinfo.strPolRate = .GetData(.Row, CMlngvsfCmpPolRate)
                ptypCmpRirekeiinfo.strRateCalcTime = .GetData(.Row, CMlngvsfCmpRateCalcTime)
                ptypCmpRirekeiinfo.strLotID = .GetData(.Row, CMlngvsfCmpLotID)
                ptypCmpRirekeiinfo.strCmpOpID = .GetData(.Row, CMlngvsfCmpOpID)
                ptypCmpRirekeiinfo.strPolTime = .GetData(.Row, CMlngvsfCmpPolTime)
                ptypCmpRirekeiinfo.strCmp1st = .GetData(.Row, CMlngvsfCmp1st)
                ptypCmpRirekeiinfo.strCmp2nd = .GetData(.Row, CMlngvsfCmp2nd)
                ptypCmpRirekeiinfo.strAvailFlag = .GetData(.Row, CMlngvsfCmpAvailFlag)
            End With
                
            '@変更履歴確認ﾌｫｰﾑ起動
            frmxxEN01N1.Instance.ShowDialog(Me)
            frmxxEN01N1.Instance = Nothing
            
            '@子ﾌｫｰﾑよりﾒｲﾝ画面へ戻った時のﾌｫｰｶｽ設定
            If vsfCmpList.Enabled = True Then
                Call pubSetFocus(vsfCmpList)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRireki_Click"
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
    '作成日：2005/03/15 (Tue) 13:13:21 N.Kasai
    '更新日：2005/03/15 (Tue) 13:13:21
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim llngRet             As Integer              '関数戻り値
        Dim ltypCommonInfo      As CommonInfo           '引継ぎ構造体
        Dim ltypCmpRirekeiinfo  As CmpRirekeiinfo       '引継ぎ構造体(CMP）

        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            
            
            '@引継ぎ構造体のｸﾘｱ
            ptypCmpRirekeiinfo = ltypCmpRirekeiinfo
            
            '@DoEventsﾌﾗｸﾞが立っていない場合
            If pblnTrnFlag = False Then
                '@終了関数を実行する
                llngRet = publngEnd_Proc(CPstrKeyEN01N0, ltypCommonInfo)
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

    '@↓2005/12/02 (Fri) 13:12:58 N.Kojima **************************************************
    '関数名：txtLastComments_Change
    '機　能：最終ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/02 (Fri) 13:14:21 N.Kojima
    '更新日：2005/12/02 (Fri) 13:14:21
    '備　考：
    Private Sub txtLastComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLastComments.Change

        Try
                      
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtLastComments, CMlngMaxDispRow, cmdLUp, cmdLDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLastComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2005/12/02 (Fri) 13:12:58 N.Kojima **************************************************

    '@↓2005/12/02 (Fri) 10:18:00 N.Kojima **************************************************
    '関数名：txtLastComments_KeyUp
    '機　能：最終ｺﾒﾝﾄﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/12/02 (Fri) 13:14:39 N.Kojima
    '更新日：2005/12/02 (Fri) 13:14:39
    '備　考：
    Private Sub txtLastComments_KeyUp(ByVal sender As Object, ByVal e As keyEventArgs) Handles txtLastComments.KeyUp
        
        Try
            
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtLastComments, CMlngMaxDispRow, cmdLUp, cmdLDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLastComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2005/12/02 (Fri) 10:18:00 N.Kojima **************************************************

    '@↓2005/12/02 (Fri) 10:20:14 N.Kojima **************************************************
    '関数名：txtLastComments_MouseUp
    '機　能：最終ｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/12/02 (Fri) 13:15:29 N.Kojima
    '更新日：2005/12/02 (Fri) 13:15:29
    '備　考：
    Private Sub txtLastComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtLastComments.MouseUp

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtLastComments, CMlngMaxDispRow, cmdLUp, cmdLDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLastComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub
    '@↑2005/12/02 (Fri) 10:20:14 N.Kojima **************************************************

    '関数名：txtComments_Change
    '機　能：ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 13:09:37 N.Kasai
    '更新日：2005/12/02 (Fri) 12:15:16 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 12:15:16 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    Private Sub txtComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.Change

        Dim llngNowByte     As Integer  'ｺﾒﾝﾄ桁数

        Try
                         
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtComments.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)

        '@↓2005/12/02 (Fri) 12:16:11 N.Kojima **************************************************
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdMUp, cmdMDown)
        '@↑2005/12/02 (Fri) 12:16:11 N.Kojima **************************************************

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

    '@↓2005/12/02 (Fri) 10:18:00 N.Kojima **************************************************
    '関数名：txtComments_KeyUp
    '機　能：ﾒﾝﾃﾅﾝｽｺﾒﾝﾄﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/12/02 (Fri) 12:58:44 N.Kojima
    '更新日：2005/12/02 (Fri) 12:58:44
    '備　考：
    Private Sub txtComments_KeyUp(ByVal sender As Object, ByVal e As keyEventArgs) Handles txtComments.KeyUp
        
        Try
            
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComments, CMlngMaxDispRow, cmdMUp, cmdMDown)
         
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
    '@↑2005/12/02 (Fri) 10:18:00 N.Kojima **************************************************

    '@↓2005/12/02 (Fri) 10:20:14 N.Kojima **************************************************
    '関数名：txtComments_MouseUp
    '機　能：ﾒﾝﾃﾅﾝｽｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/12/02 (Fri) 12:59:38 N.Kojima
    '更新日：2005/12/02 (Fri) 12:59:38
    '備　考：
    Private Sub txtComments_MouseUp(ByVal sender As Object, ByVal e As mouseEventArgs) Handles txtComments.MouseUp

        Try
            

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdMUp, cmdMDown, e.Button)
            
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
    '@↑2005/12/02 (Fri) 10:20:14 N.Kojima **************************************************

    '関数名：cmdNowList_Click
    '機　能：最新取得ﾎﾞﾀﾝ　押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 12:51:13 N.Kasai
    '更新日：2005/03/15 (Tue) 12:51:13
    '備　考：
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click
        
        Dim lblnAns                 As Boolean          '結果格納
        Dim ltypEqcmplistRec        As EqcmplistRec     'CMP情報一覧取得（要求）情報格納
        Dim ltypEqcmplistAns        As EqcmplistAns     'CMP情報一覧取得（応答）情報格納

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            
            '@ﾞﾀﾝ制御ﾌﾗｸﾞが実行不可の場合(連打対応）
            cmdNowList.Enabled = False

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrNowListClick)
            
            '@応答ﾒｯｾｰｼﾞ格納
            With ltypEqcmplistRec
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstreq__cmplist_Ver
                '@WPID
                .strWpID = cmbWplist.Value
            End With

            '@MSG[CMP情報一覧取得]を実行
            lblnAns = pubblnEqCmpList_Sel(ltypEqcmplistRec, ltypEqcmplistAns)

            '@結果判定
            If lblnAns = True Then
                '@CMP情報一覧取得に成功
                '@件数がありの場合
                If ltypEqcmplistAns.lngCmpListAnsCnt > 0 Then
                    '@検索結果表示
                    Call prvvsfCmpList_Disp(ltypEqcmplistAns)
                    
                    '@ｾｯﾄﾌｫｰｶｽ設定
                    If vsfCmpList.Enabled = True Then
                        'NSYS 最新取得を2回呼ばれない為の対策
                       RemoveHandler cmbWplist.Validating, AddressOf cmbWplist_Validate 
                        Call pubSetFocus(vsfCmpList)
                       AddHandler cmbWplist.Validating, AddressOf cmbWplist_Validate      
                    End If
                End If

                '@情報取得日時表示
                lblGetInfoDate.Text = Format$(Now, CPstrDateFormat)
                '@該当件数ﾗﾍﾞﾙに取得件数を表示
                lblListCnt.Text = Format$(ltypEqcmplistAns.lngCmpListAnsCnt, CPstrDateFormatKanma)

            Else
                '@CMP情報一覧取得に失敗
                
                '@検索結果ﾘｽﾄの初期化
                Call prvvsfCmpList_Init()
                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrNowListClick)
                cmdNowList.Enabled = True
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrNowListClick)
            
            cmdNowList.Enabled = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMUp_Click
    '機　能：ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 13:07:46 N.Kasai
    '更新日：2005/12/02 (Fri) 13:00:39 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 13:00:39 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    Private Sub cmdMUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMUp.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
        '@↓2005/12/02 (Fri) 13:01:02 N.Kojima **************************************************
        '    '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtComments)
        '
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtComments, CMlngMaxDispRow, cmdMUp, cmdMDown)
        '@↑2005/12/02 (Fri) 13:01:02 N.Kojima **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMDown_Click
    '機　能：ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 13:07:37 N.Kasai
    '更新日：2005/12/02 (Fri) 13:01:55 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 13:01:55 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    Private Sub cmdMDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMDown.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

        '@↓2005/12/02 (Fri) 13:02:17 N.Kojima **************************************************
        '    '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtComments)
        '
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtComments, CMlngMaxDispRow, cmdMUp, cmdMDown)
        '@↑2005/12/02 (Fri) 13:02:17 N.Kojima **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLDown_Click
    '機　能：最終ｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:40:50 N.Kasai
    '更新日：2005/12/02 (Fri) 13:08:28 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 13:08:28 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    Private Sub cmdLDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLDown.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

        '@↓2005/12/02 (Fri) 13:08:47 N.Kojima **************************************************
        '    '@最終ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtLastComments)
        '
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtLastComments, CMlngMaxDispRow, cmdLUp, cmdLDown)
        '@↑2005/12/02 (Fri) 13:08:47 N.Kojima **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLUp_Click
    '機　能：最終ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:41:05 N.Kasai
    '更新日：2005/12/02 (Fri) 13:10:46 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 13:10:46 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    Private Sub cmdLUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLUp.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
        '@↓2005/12/02 (Fri) 13:10:09 N.Kojima **************************************************
        '    '@最終ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtLastComments)
        '
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtLastComments, CMlngMaxDispRow, cmdLUp, cmdLDown)
        '@↑2005/12/02 (Fri) 13:10:09 N.Kojima **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtNewPolRate_Change
    '機　能：研磨ﾚｰﾄ（変更後）変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/16 (Wed) 12:42:32 N.Kasai
    '更新日：2005/03/16 (Wed) 12:42:32
    '備　考：
    Private Sub txtNewPolRate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtNewPolRate.Change

        Try
            
            '@入力状況を判定（1文字でも入力している場合）
            If txtNewPolRate.Text <> vbNullString Then
                '@研磨ﾚｰﾄ変更ﾎﾞﾀﾝ使用可
                cmdHenkou.Enabled = True
            Else
                '@研磨ﾚｰﾄ変更ﾎﾞﾀﾝ使用不可
                cmdHenkou.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtNewPolRate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCmpList_AfterSort
    '機　能：検索結果ﾘｽﾄ ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2005/03/16 (Wed) 10:48:23 N.Kasai
    '更新日：2005/03/16 (Wed) 10:48:23
    '備　考：
    Private Sub vsfCmpList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfCmpList.AfterSort

        Try
            AddHandler vsfCmpList.BeforeRowColChange, AddressOf vsfCmpList_BeforeRowColChange 
            AddHandler vsfCmpList.EnterCell, AddressOf vsfCmpList_EnterCell
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfCmpList.Rows.Count <= vsfCmpList.Rows.Fixed Then
                Return
            End If
            

            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                Dim typChgSortListTmp As ChgSortList = New ChgSortList
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納（昇順/降順）
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList.Add(typChgSortListTmp)
            End With
            
            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfAfterSort(vsfCmpList, CMlngvsfCmpNo)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCmpList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCmpList_AfterUserResize
    '機　能：列幅変更後処理
    '引　数：Row：行番号
    '　　　：Col：列番号
    '戻り値：なし
    '作成日：2005/03/16 (Wed) 10:49:22 N.Kasai
    '更新日：2005/03/16 (Wed) 10:49:22
    '備　考：
    Private Sub vsfCmpList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfCmpList.AfterResizeColumn, vsfCmpList.AfterResizeRow

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfCmpList.Rows.Count <= vsfCmpList.Rows.Fixed Then
                Return
            End If           
            
            '@列幅変更ﾌﾗｸﾞ（変更）
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCmpList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCmpList_BeforeRowColChange
    '機　能：行列変更前処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/03/16 (Wed) 10:49:38 N.Kasai
    '更新日：2005/03/16 (Wed) 10:49:38
    '備　考：
    Private Sub vsfCmpList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfCmpList.BeforeRowColChange

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfCmpList.Rows.Count <= vsfCmpList.Rows.Fixed Then
                Return
            End If           
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（№）
                mtypChgSort.strKey = vsfCmpList.GetData(e.NewRange.r1, CMlngvsfCmpNo)
                
                '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄの初期化
                txtComments.Text = vbNullString
                '@変更後ﾚｰﾄの初期化
                txtNewPolRate.Text = vbNullString
                
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCmpList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCmpList_BeforeSort
    '機　能：検索結果ﾘｽﾄ ｿｰﾄ前処理
    '引　数：Col　：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2005/03/16 (Wed) 10:51:07 N.Kasai
    '更新日：2005/03/16 (Wed) 10:51:07
    '備　考：
    Private Sub vsfCmpList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfCmpList.BeforeSort

        Try
            RemoveHandler vsfCmpList.BeforeRowColChange, AddressOf vsfCmpList_BeforeRowColChange 
            RemoveHandler vsfCmpList.EnterCell, AddressOf vsfCmpList_EnterCell
           
            'NSYS データ行がない場合は処理を抜ける
            If vsfCmpList.Rows.Count <= vsfCmpList.Rows.Fixed Then
                Return
            End If
           
            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfBeforeSort(vsfCmpList, CMlngvsfCmpNo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCmpList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfCmpList_EnterCell
    '機　能：ｸﾞﾘｯﾄ ｶﾚﾝﾄ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 15:33:57 N.Kasai
    '更新日：2005/05/31 (Tue) 13:46:48 N.Kasai
    '備　考：
    '　　　：2005/05/31 (Tue) 13:46:48 N.Kasai      不具合№732　研磨ﾚｰﾄが空欄の時は使用禁止解除ﾎﾞﾀﾝは使用不可
    Private Sub vsfCmpList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfCmpList.EnterCell
        
        Dim lstrEventName   As String   'ｲﾍﾞﾝﾄ名を格納

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfCmpList.Rows.Count <= vsfCmpList.Rows.Fixed Then
                Return
            End If
            
            
            With vsfCmpList
            
                '@固定行判定
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If
            
                '@変更列を判定し履歴表示ﾎﾞﾀﾝ使用可否判定
                '@最終ｲﾍﾞﾝﾄ名がある場合は履歴ありと判断する。
                If .GetData(.Row, CMlngvsfCmpEventName) <> vbNullString Then
                    '@ﾒﾝﾃﾅﾝｽ履歴ﾎﾞﾀﾝ使用可
                    cmdRireki.Enabled = True
                    '@最終ｲﾍﾞﾝﾄ名を取得
                    lstrEventName = .GetData(.Row, CMlngvsfCmpEventName)
                    '@最終ｲﾍﾞﾝﾄ名を表示
                    lblLastComments.Text = CMstrLastComments & CPstrBracketLeft & lstrEventName & CPstrBracketRight
                    '@最終ｺﾒﾝﾄ表示
                    txtLastComments.Text = .GetData(.Row, CMlngvsfCmpComments)
                Else
                    '@ﾒﾝﾃﾅﾝｽ履歴ﾎﾞﾀﾝ使用不可
                    cmdRireki.Enabled = False
                    '@最終ｲﾍﾞﾝﾄ名の初期化
                    lblLastComments.Text = CMstrLastComments
                    '@最終ｺﾒﾝﾄの初期化
                    txtLastComments.Text = vbNullString
                End If
            
                '@研磨ﾚｰﾄ変更前表示
                If IsNumeric(.GetData(.Row, CMlngvsfCmpPolRate))
                    lblOldPolRate.Text = Format$(Double.Parse(.GetData(.Row, CMlngvsfCmpPolRate)), CPstrRate)
                End If
                                             
                '@研磨ﾚｰﾄ（変更後）使用可
                txtNewPolRate.Enabled = True
                txtNewPolRate.BackColor = Color.White 
                
                '@研磨ﾚｰﾄ変更ﾎﾞﾀﾝ使用可否判定
                If txtNewPolRate.Text <> vbNullString Then
                    '@研磨ﾚｰﾄ変更ﾎﾞﾀﾝ使用可
                    cmdHenkou.Enabled = True
                Else
                    '@研磨ﾚｰﾄ変更ﾎﾞﾀﾝ使用不可
                    cmdHenkou.Enabled = False
                End If
                
                
                '研磨ﾚｰﾄ使用可否判定　(0：使用不可　1:使用可）
                If .GetData(.Row, CMlngvsfCmpAvailFlag) = CMstrAvailFlagOn Then
                    '使用禁止設定ﾎﾞﾀﾝ使用可
                    cmdKinshi.Enabled = True
                    '@使用禁止解除ﾎﾞﾀﾝ使用不可
                    cmdKaijyo.Enabled = False
                Else
                    '使用禁止設定ﾎﾞﾀﾝ使用不可
                    cmdKinshi.Enabled = False
                    
        '@↓2005/05/31 (Tue) 13:46:40 N.Kasai **************************************************
                    '@研磨ﾚｰﾄが未設定（空白）の場合は解除ﾎﾞﾀﾝ使用不可
                     If .GetData(.Row, CMlngvsfCmpPolRate) = vbNullString Then
                        '@使用禁止解除ﾎﾞﾀﾝ使用可
                        cmdKaijyo.Enabled = False
                    Else
                        '@使用禁止解除ﾎﾞﾀﾝ使用可
                        cmdKaijyo.Enabled = True
                    End If
        '@↑2005/05/31 (Tue) 13:46:40 N.Kasai **************************************************
                End If
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCmpList_EnterCell"
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
    '関数名：prvfrmxxEN01N0_Init
    '機　能：ﾌｫｰﾑのｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:23:54 N.Kasai
    '更新日：2005/03/14 (Mon) 16:23:54
    '備　考：
    Private Sub prvfrmxxEN01N0_Init()

        Dim llngNowByte     As Integer  'NSYS メンテナンスコメント桁数

        Try
            
            '@ﾗﾍﾞﾙ/ﾃｷｽﾄのｸﾘｱ
            lblGetInfoDate.Text = vbNullString       '情報取得日時
            lblListCnt.Text = vbNullString           '該当件数
            lblLastComments.Text = CMstrLastComments '最終ｺﾒﾝﾄｷｬﾌﾟｼｮﾝ
            txtLastComments.Text = vbNullString         '最終ｺﾒﾝﾄ
            txtComments.Text = vbNullString             'ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ
            lblOldPolRate.Text = vbNullString        '変更前
            txtNewPolRate.Text = vbNullString           '変更後
            
            '@ﾊﾞｯｸｶﾗｰ初期設定
            txtNewPolRate.BackColor = System.Drawing.SystemColors.ControlLight      '変更後

            '@ﾃｷｽﾄの使用不可
            txtNewPolRate.Enabled = False               '変更後
            txtComments.Enabled = False                 'ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ
            txtLastComments.Enabled = False             '最終ｺﾒﾝﾄ
            txtLastComments.Locked = True               'MSYS 入力ロック

            'NSYS 現状のメンテナンスコメントのバイト数を格納
            llngNowByte = txtComments.NowByte

            'NSYS 現在のメンテナンスコメントのバイト数を表示
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)

            '@ﾎﾞﾀﾝの使用不可
            cmdHenkou.Enabled = False                   '研磨ﾚｰﾄ変更ﾎﾞﾀﾝ
            cmdKaijyo.Enabled = False                   '使用禁止解除ﾎﾞﾀﾝ
            cmdKinshi.Enabled = False                   '使用禁止設定ﾎﾞﾀﾝ
            cmdRireki.Enabled = False                   'ﾒﾝﾃﾅﾝｽ履歴ﾎﾞﾀﾝ
            cmdMUp.Enabled = False                      'ﾒﾝﾃﾅﾝｽUp
            cmdMDown.Enabled = False                    'ﾒﾝﾃﾅﾝｽDown
            cmdLUp.Enabled = False                      '最終ｺﾒﾝﾄUp
            cmdLDown.Enabled = False                    '最終ｺﾒﾝﾄDown
            
            '@ｸﾞﾘｯﾄﾞの初期化
            With vsfCmpList
                .Rows.Count = .Rows.Fixed
                .Enabled = False
            End With
            
            '@閉じるボタンへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01N0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCmpList_Init
    '機　能：CMP一覧ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:25:09 N.Kasai
    '更新日：2005/03/14 (Mon) 16:25:09
    '備　考：
    Private Sub prvvsfCmpList_Init()
        Dim headerStyle As CellStyle    'NSYS ヘッダー用追加Style
        Dim cellRange As CellRange      'NSYS 追加Sytle設定範囲

        Try
           
            '@一覧表示の各カラムの幅、タイトルを設定
            With vsfCmpList
                '@使用不可
                .Enabled = False
                '@再描画を行わない
                .Redraw = False 
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                '最大列設定
                .Cols.Count = CMlngvsfCmpCols
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn 
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                '.FillStyle = flexFillRepeat
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowBigSelection = False
                '@ﾏｳｽでｾﾙ範囲選択不可
                .AllowDragging = False                
                '@ｾﾙ選択の設定
                .SelectionMode =  SelectionModeEnum.Row 
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号（...）を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                '@一覧表の表題設定
                headerStyle = .Styles.Add("headerStyle_new")
                headerStyle.ForeColor = Color.Yellow            '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                headerStyle.Font =  New Font(headerStyle.Font.FontFamily, CMlngvsfCmpHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)
                headerStyle.Trimming = StringTrimming.None 

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfCmpNo).Width = CMlngvsfCmpWNo                                               'No.
                    .Cols(CMlngvsfCmpKb).Width = CMlngvsfCmpWKb                                               '変更可否
                    .Cols(CMlngvsfCmpWpName).Width = CMlngvsfCmpWWpName                                       '装置名
                    .Cols(CMlngvsfCmpH).Width = CMlngvsfCmpWH                                                 'ﾍｯﾄﾞ
                    .Cols(CMlngvsfCmpP).Width = CMlngvsfCmpWP                                                 'ﾌﾟﾗﾃﾝ
                    .Cols(CMlngvsfCmpPolRate).Width = CMlngvsfCmpWPolRate                                     '研磨ﾚｰﾄ
                    .Cols(CMlngvsfCmpRateCalcTime).Width = CMlngvsfCmpWRateCalcDate                           'ﾚｰﾄ算出日時
                    .Cols(CMlngvsfCmpLotID).Width = CMlngvsfCmpWLotID                                         'ﾚｰﾄ算出ﾛｯﾄID
                    .Cols(CMlngvsfCmpOpID).Width = CMlngvsfCmpWOpID                                           '大工程
                    .Cols(CMlngvsfCmpPolTime).Width = CMlngvsfCmpWPolTime                                     '研磨時間
                    .Cols(CMlngvsfCmp1st).Width = CMlngvsfCmpW1st                                             '1st膜厚
                    .Cols(CMlngvsfCmp2nd).Width = CMlngvsfCmpW2nd                                             '2nd膜厚
                    .Cols(CMlngvsfCmpWpID).Width = CMlngvsfCmpWWpID                                           'WPID
                    .Cols(CMlngvsfCmpAvailFlag).Width = CMlngvsfCmpWAvaiFlag                                  '使用可否F
                    .Cols(CMlngvsfCmpEditTime).Width = CMlngvsfCmpWEditTime                                   '応答ﾒｯｾｰｼﾞ生成日時
                    .Cols(CMlngvsfCmpEventName).Width = CMlngvsfCmpWEventName                                 'ｲﾍﾞﾝﾄ名
                    .Cols(CMlngvsfCmpComments).Width = CMlngvsfCmpWComments                                   'ｺﾒﾝﾄ
                End If
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpNo, CMstrvsfCmpTNo)                      'No.
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpKb, CMstrvsfCmpTKb)                      '変更可否
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpWpName, CMlngvsfCmpTWpName)              '装置名
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpH, CMlngvsfCmpTH)                        'ﾍｯﾄﾞ
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpP, CMlngvsfCmpTP)                        'ﾌﾟﾗﾃﾝ
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpPolRate, CMlngvsfCmpTPolRate)            '研磨ﾚｰﾄ
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpRateCalcTime, CMlngvsfCmpTRateCalcDate)  'ﾚｰﾄ算出日時
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpLotID, CMlngvsfCmpTLotID)                'ﾚｰﾄ算出ﾛｯﾄID
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpOpID, CMlngvsfCmpTOpID)                  '大工程
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpPolTime, CMlngvsfCmpTPolTime)            '研磨時間
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmp1st, CMlngvsfCmpT1st)                    '1st膜厚
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmp2nd, CMlngvsfCmpT2nd)                    '2nd膜厚
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpWpID, CMlngvsfCmpTWpID)                  'WPID
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpAvailFlag, CMlngvsfCmpTAvaiFlag)         '使用可否F
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpEditTime, CMlngvsfCmpTEditTime)          '応答ﾒｯｾｰｼﾞ生成日時
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpEventName, CMlngvsfCmpTEventName)        'ｲﾍﾞﾝﾄ名
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfCmpComments, CMlngvsfCmpTComments)          'ｺﾒﾝﾄ
               
                '@非表示Col設定
                .Cols(CMlngvsfCmpWpID).Visible = false                                                         'WPID
                .Cols(CMlngvsfCmpAvailFlag).Visible = False                                                      '変更可否ﾌﾗｸﾞ
                .Cols(CMlngvsfCmpEditTime).Visible  = false                                                      '応答ﾒｯｾｰｼﾞ生成日時
                .Cols(CMlngvsfCmpEventName).Visible  = false                                                    'ｲﾍﾞﾝﾄ名
                .Cols(CMlngvsfCmpComments).Visible  = false                                                     'ｺﾒﾝﾄ
           
                '@表示位置の設定
                headerStyle.TextAlign = TextAlignEnum.CenterCenter 
                cellRange = .GetCellRange(CMlngvsfCmpRowTitle, CMlngvsfCmpNo, CMlngvsfCmpRowTitle, .Cols.Count - 1)
                cellRange.Style = headerStyle
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngvsfCmpRowTitle).Height = CMlngvsfCmpHHeight
                '@行列のﾏｳｽでの変更を可にする
                .AllowResizing = AllowResizingEnum.Columns
                'ﾊｲﾗｲﾄ表示
                .HighLight = HighLightEnum.Always 
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                '@ﾃﾞｰﾀを画面に直接描画
                .Redraw = True
            End With
            
            '@情報取得日時初期化
            lblGetInfoDate.Text = vbNullString
            '@該当件数ﾗﾍﾞﾙの初期化
            lblListCnt.Text = vbNullString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCmpList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCmpList_Disp
    '機　能：CMP情報一覧表示
    '引　数：ltypEqcmplistAns：CMP情報一覧取得応答構造体
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 10:39:55 N.Kasai
    '更新日：2005/12/02 (Fri) 13:03:53 N.Kojima
    '備　考：
    '　　　：2005/05/07 (Sat) 17:03:04 N.Kojima     ﾚｰﾄ計算ﾛｯﾄIDがNULLの場合は「作業者名」を表示する(不具合№731)
    '　　　：2005/12/02 (Fri) 13:03:53 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    Private Sub prvvsfCmpList_Disp(ByRef ltypEqcmplistAns As EqcmplistAns)

        Dim llngCnt             As Integer  '汎用ｶｳﾝﾄ
        Dim llngCmpCnt          As Integer  'CMPﾘｽﾄｶｳﾝﾄ
        Dim llngHeadCnt         As Integer  'ﾍｯﾀﾞﾌﾟﾗﾃﾝﾘｽﾄｶｳﾝﾄ
        Dim lstrWpId            As String   'WPID退避
        Dim lstrWPName          As String   '装置名退避
        Dim lstrAvailFlag       As String   '研磨ﾚｰﾄ使用可否ﾌﾗｸﾞ退避(0：使用不可　1:使用可）

        Try
            
            '@ｶｳﾝﾀの初期化
            llngCnt = 1
            
            '@一覧表示情報設定
            With vsfCmpList
                '@ﾛｯｸ解除
                .Enabled = True
                '@再描画を行わない
                .Redraw = false
                '@行初期化
                .Rows.Count = .Rows.Fixed
                'NSYS 選択したカレントセルがクリアされない為の対策
                RemoveHandler vsfCmpList.EnterCell,AddressOf vsfCmpList_EnterCell 
                RemoveHandler vsfCmpList.BeforeRowColChange, AddressOf vsfCmpList_BeforeRowColChange 
                '@行数設定
                .Rows.Count = ltypEqcmplistAns.lngCmpListAnsCnt + 1
                .Row = 0
                AddHandler vsfCmpList.EnterCell,AddressOf vsfCmpList_EnterCell
                AddHandler vsfCmpList.BeforeRowColChange, AddressOf vsfCmpList_BeforeRowColChange 

                '@CMP_LIST取得
                For llngCmpCnt = 0 To ltypEqcmplistAns.lngCmpListCnt-1
                    '@装置ID/装置名退避
                    lstrWpId = ltypEqcmplistAns.typCmpList(llngCmpCnt).strWpID              'WPID
                    lstrWPName = ltypEqcmplistAns.typCmpList(llngCmpCnt).strWpName          '装置名
                    
                    '@HEAD_PLATEN_LIST取得
                    For llngHeadCnt = 0 To ltypEqcmplistAns.typCmpList(llngCmpCnt).lngHeadPlatenListCnt-1
                        .SetData(llngCnt, CMlngvsfCmpNo, llngCnt)                                                             '№
                        .SetData(llngCnt, CMlngvsfCmpWpName, lstrWPName)                                                      '装置名
                        .SetData(llngCnt, CMlngvsfCmpH, _
                            ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strHead)                              'ﾍｯﾄﾞ
                        .SetData(llngCnt, CMlngvsfCmpP, _
                            ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strPlaten)                            'ﾌﾟﾗﾃﾝ
                        
                        .SetData(llngCnt, CMlngvsfCmpPolRate, _
                            ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strPolRate)                          '研磨ﾚｰﾄ
                                               
                        If IsDate(ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strRateCalcTime) Then
                           .SetData(llngCnt, CMlngvsfCmpRateCalcTime, _
                              Format$(Cdate(ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strRateCalcTime), _
                                 CPstrDateTimeYMDHMS))                                                                                    'ﾚｰﾄ計算日時
                        End if
                        .SetData(llngCnt, CMlngvsfCmpLotID, _
                            ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strLotID)                             'ﾚｰﾄ計算ﾛｯﾄID
        '@↓2005/05/07 (Sat) 17:00:33 N.Kojima **************************************************
                        '@ﾚｰﾄ計算ﾛｯﾄIDが空白の場合
                        If .GetData(llngCnt, CMlngvsfCmpLotID) = vbNullString Then
                            '@作業者名を表示する
                            .SetData(llngCnt, CMlngvsfCmpLotID, _
                                ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strEmpName)                       '作業者名
                        End If
        '@↑2005/05/07 (Sat) 17:00:33 N.Kojima **************************************************
                        
                        .SetData(llngCnt, CMlngvsfCmpOpID, _
                            ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strCmpOpID)                           '大工程
                        .SetData(llngCnt, CMlngvsfCmpPolTime, _
                            ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strPolTime)                           '研磨時間

                        
                        .SetData(llngCnt, CMlngvsfCmp1st, _
                                    ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strCmp1st)                     '1st膜厚
                        
                                               
                        .SetData(llngCnt, CMlngvsfCmp2nd, _
                                 ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strCmp2nd)                        '2nd膜厚
                        

                                              
                        .SetData(llngCnt, CMlngvsfCmpWpID, lstrWpId)                                                                     'WPID
                        .SetData(llngCnt, CMlngvsfCmpAvailFlag, _
                            ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strAvailFlag)                         '変更可否ﾌﾗｸﾞ
                        .SetData(llngCnt, CMlngvsfCmpEditTime, ltypEqcmplistAns.strEditTime)                                             '応答ﾒｯｾｰｼﾞ生成日時
                        .SetData(llngCnt, CMlngvsfCmpEventName, _
                            ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strEventName)                         'ｲﾍﾞﾝﾄ名
                        .SetData(llngCnt, CMlngvsfCmpComments, _
                            ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strComments)                          'ｺﾒﾝﾄ
                        
                        '@研磨ﾚｰﾄ使用可否ﾌﾗｸﾞ取得(0：使用不可　1:使用可）
                        lstrAvailFlag = ltypEqcmplistAns.typCmpList(llngCmpCnt).typHeadPlatenList(llngHeadCnt).strAvailFlag
                        
                        '@使用可否表示&ﾊﾞｯｸｶﾗｰ変更
                        If lstrAvailFlag = CMstrAvailFlagOn Then
                            '@ﾏｰｸ表示
                            .SetData(llngCnt, CMlngvsfCmpKb, vbNullString)                                        '表示なし
                            '@ｾﾙ色変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White 
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfCmpColTitle, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle              '白色
                        Else
                            '@ﾏｰｸ表示
                            .SetData(llngCnt, CMlngvsfCmpKb, CMstrBatu)                                           '×表示
        '@↓2005/07/22 (Fri) 16:45:11 N.Kasai **************************************************
        '                    '@ｾﾙ色変更
        '                    .Cell(flexcpBackColor, llngCnt, CMlngvsfCmpColTitle, llngCnt, .Cols - 1) = CPlngStopLotColor    'ﾋﾟﾝｸ
                            '@ｾﾙ色変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                            newStyle.BackColor = ColorTranslator.FromWin32( CPlngHoldLotColor)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfCmpColTitle, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle    '黄色
        '@↑2005/07/22 (Fri) 16:45:11 N.Kasai **************************************************
                        End If
                        
                        '@高さの設定
                        .Rows(llngCnt).Height = CMlngvsfCmpHeight
                        
                        '@№のｶｳﾝﾄ
                        llngCnt = llngCnt + 1
                    Next llngHeadCnt
                Next llngCmpCnt
                
                '@書式設定
                .Cols(CMlngvsfCmpNo).TextAlign = TextAlignEnum.RightCenter                     '右詰の中央揃え（№）
                .Cols(CMlngvsfCmpKb).TextAlign = TextAlignEnum.LeftCenter                      '左詰の中央揃え（×/空白）
                .Cols(CMlngvsfCmpWpName).TextAlign = TextAlignEnum.LeftCenter                  '左詰の中央揃え（装置名）
                .Cols(CMlngvsfCmpH).TextAlign = TextAlignEnum.LeftCenter                       '左詰の中央揃え（ﾍｯﾄﾞ）
                .Cols(CMlngvsfCmpP).TextAlign = TextAlignEnum.RightCenter                      '右詰の中央揃え（ﾌﾟﾗﾃﾝ）
                .Cols(CMlngvsfCmpPolRate).TextAlign = TextAlignEnum.RightCenter                '右詰の中央揃え（研磨ﾚｰﾄ）
                .Cols(CMlngvsfCmpRateCalcTime).TextAlign = TextAlignEnum.LeftCenter            '左詰の中央揃え（ﾚｰﾄ計算日時）
                .Cols(CMlngvsfCmpLotID).TextAlign = TextAlignEnum.LeftCenter                   '左詰の中央揃え（ﾚｰﾄ計算ﾛｯﾄID）
                .Cols(CMlngvsfCmpOpID).TextAlign = TextAlignEnum.LeftCenter                    '左詰の中央揃え（大工程）
                .Cols(CMlngvsfCmpPolTime).TextAlign = TextAlignEnum.RightCenter                '右詰の中央揃え（研磨時間）
                .Cols(CMlngvsfCmp1st).TextAlign = TextAlignEnum.RightCenter                    '左詰の中央揃え（1st膜厚）
                .Cols(CMlngvsfCmp2nd).TextAlign = TextAlignEnum.RightCenter                    '右詰の中央揃え（2nd膜厚）
                .Cols(CMlngvsfCmpWpID).TextAlign = TextAlignEnum.LeftCenter                    '左詰の中央揃え（WPID）
                .Cols(CMlngvsfCmpAvailFlag).TextAlign = TextAlignEnum.LeftCenter               '左詰の中央揃え（使用可否F）
                .Cols(CMlngvsfCmpEditTime).TextAlign = TextAlignEnum.LeftCenter                '左詰の中央揃え（生成時間）
                .Cols(CMlngvsfCmpEventName).TextAlign = TextAlignEnum.LeftCenter               '左詰の中央揃え（ｲﾍﾞﾝﾄ名）
                .Cols(CMlngvsfCmpComments).TextAlign = TextAlignEnum.RightCenter               '左詰の中央揃え（ｺﾒﾝﾄ）
                
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@ｵｰﾄ幅設定
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMlngvsfCmpNo, .Cols.Count - 1, 6)
                End If

                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort.lngCnt-1
                        '@該当行をｿｰﾄ
                        .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                    Next llngCnt
                End If

                '@ｿｰﾄ検索用ｷｰ(№）がある場合
                If mtypChgSort.strKey <> vbNullString Then
                     For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@№が同じ場合
                            If .GetData(llngCnt, CMlngvsfCmpNo) = mtypChgSort.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                                Call pubVsfBeforeSort(vsfCmpList, CMlngvsfCmpNo)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                                Call pubVsfAfterSort(vsfCmpList, CMlngvsfCmpNo)
                                Exit For
                            End If
                        Next llngCnt
                Else
                    .Row = CMlngvsfCmpRowTitle           'ｶﾚﾝﾄ行の移動
                    .TopRow = CMlngvsfCmpRowTitle        '行
                End If

                '@ｽﾌﾟﾚｯﾄﾞを初期値へ移動
                .LeftCol = CMlngvsfCmpColTitle           '列
                '@ﾃﾞｰﾀを画面に直接描画
                .Redraw = True
                
            End With
            
            '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ欄を使用可
            txtComments.Enabled = True
            
        '@↓2005/12/02 (Fri) 13:03:43 N.Kojima **************************************************
        '@ｽｸﾛｰﾙ有効制御はﾃｷｽﾄのｲﾍﾞﾝﾄにて行なう為、ｺﾒﾝﾄｱｳﾄ
        '    cmdMUp.Enabled = True
        '    cmdMDown.Enabled = True
        '@↑2005/12/02 (Fri) 13:03:43 N.Kojima **************************************************
            
            '@最終ｺﾒﾝﾄ欄を使用可
            txtLastComments.Enabled = True
            
        '@↓2005/12/02 (Fri) 13:17:22 N.Kojima **************************************************
        '@ｽｸﾛｰﾙ有効制御はﾃｷｽﾄのｲﾍﾞﾝﾄにて行なう為、ｺﾒﾝﾄｱｳﾄ
        '    cmdLUp.Enabled = True
        '    cmdLDown.Enabled = True
        '@↑2005/12/02 (Fri) 13:17:22 N.Kojima **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCmpList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbWplist_Disp
    '機　能：CMP装置ｺﾝﾎﾞﾎﾞｯｸｽ作成
    '引　数：llngWpCnt:装置数
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:51:55 N.Kasai
    '更新日：2005/03/14 (Mon) 16:51:55
    '備　考：
    Private Sub prvcmbWplist_Disp(ByVal llngWpCnt As Integer)
        
        Dim llngCnt     As Integer  'ｶｳﾝﾄ

        Try

            '@CMP装置ｺﾝﾎﾞﾘｽﾄ初期化
            With cmbWplist
                .Clear
                .DirectInput = False                                               '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                   '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                            '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                       'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol                                       'ｸﾞﾘｯﾄﾞ値取得列数
                .GroupCols = CMlngCmbGroupCols                                     '列方向のﾚｺｰﾄﾞ数
                .GroupRows = llngWpCnt + 1                                         '行方向のﾚｺｰﾄﾞ数
                .Font = New Font(.Font.Name, CMlngCmbFontSize,.Font.Style)         'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _ 
                                                          .Font.Style, .Font.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ                      
                .RowHeight = CMlngCmbRowHeight                                     'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter         '左寄中央揃え
                .Enabled = True
                
                '@全件（指定なし）の追加
                .AddItem(CMstrNoSelectString & vbTab & vbNullString)             '指定なし
                
                '@ﾃﾞｰﾀ件数ありの場合
                If llngWpCnt > 0 Then
                    For llngCnt = 0 To llngWpCnt-1
                        .AddItem (ptypWPList(llngCnt).strWpName & vbTab & ptypWPList(llngCnt).strWpID) '装置ID/装置名                                                  
                    Next
                End If

                '@1件目表示(指定なし）
                .ListIndex = 0
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbWplist_Disp"
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfCmpList.BeforeDoubleClick

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

End Class
