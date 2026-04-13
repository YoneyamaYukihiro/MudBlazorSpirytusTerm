'ﾌｧｲﾙ名：xxEN01N1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾒﾝﾃﾅﾝｽ履歴確認
'作成日：2005/03/15 (Tue) 16:30:27 N.Kasai
'更新日：2005/12/02 (Fri) 12:08:08 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01N1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01N1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01N1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01N1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01N1)
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
    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    Private Const CMstreq__cmpeventlistVer              As String = "01.00"                 'CMPﾒﾝﾃﾅﾝｽｲﾍﾞﾝﾄ履歴取得

    '@機能名
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN01N1          'ﾛｰｶﾙﾒﾆｭｰKey

    '@vsfCmpNowListの定数宣言（ｶﾗﾑ）
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

    '@vsfCmpNowListの定数宣言（幅）
    Private Const CMlngvsfCmpWNo                        As Integer = 37                      '№
    Private Const CMlngvsfCmpWKb                        As Integer = 2                       '使用可否
    Private Const CMlngvsfCmpWWpName                    As Integer = 166                     '装置名
    Private Const CMlngvsfCmpWH                         As Integer = 2                       'ﾍｯﾄﾞ
    Private Const CMlngvsfCmpWP                         As Integer = 2                       'ﾌﾟﾗﾃﾝ
    Private Const CMlngvsfCmpWPolRate                   As Integer = 66                      '研磨ﾚｰﾄ
    Private Const CMlngvsfCmpWRateCalcDate              As Integer = 200                     'ﾚｰﾄ計算日時
    Private Const CMlngvsfCmpWLotID                     As Integer = 120                     'ﾚｰﾄ計算ﾛｯﾄID
    Private Const CMlngvsfCmpWOpID                      As Integer = 166                     '大工程
    Private Const CMlngvsfCmpWPolTime                   As Integer = 66                      '研磨時間
    Private Const CMlngvsfCmpW1st                       As Integer = 66                      '1st膜厚
    Private Const CMlngvsfCmpW2nd                       As Integer = 66                      '2nd膜厚
    Private Const CMlngvsfCmpWWpID                      As Integer = 66                      '装置ID（非表示）
    Private Const CMlngvsfCmpWAvaiFlag                  As Integer = 66                      '変更可否F（非表示）
    Private Const CMlngvsfCmpWEditTime                  As Integer = 66                      '応答ﾒｯｾｰｼﾞ日時(非表示）
    Private Const CMlngvsfCmpWEventName                 As Integer = 66                      'ｲﾍﾞﾝﾄ名（非表示）
    Private Const CMlngvsfCmpWComments                  As Integer = 66                      '最新ｺﾒﾝﾄ（非表示）

    '@vsfCmpNowListの定数宣言（ﾀｲﾄﾙ）
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

    '@vsfCmpEventListの定数宣言（ｶﾗﾑ）
    Private Const CMlngvsfHisNo                         As Integer = 0                         '№
    Private Const CMlngvsfHisEventName                  As Integer = 1                         'ｲﾍﾞﾝﾄ名
    Private Const CMlngvsfHisEntryTime                  As Integer = 2                         '処理日時
    Private Const CMlngvsfHisEmpName                    As Integer = 3                         '担当者
    Private Const CMlngvsfHisOldPolRate                 As Integer = 4                         '研磨ﾚｰﾄ（変更前）
    Private Const CMlngvsfHisNewPolRate                 As Integer = 5                         '研磨ﾚｰﾄ（変更後）
    Private Const CMlngvsfHisComments                   As Integer = 6                         '最新ｺﾒﾝﾄ（非表示）

    '@vsfCmpEventListの定数宣言（幅）
    Private Const CMlngvsfHisWNo                        As Integer = 37                       '№
    Private Const CMlngvsfHisWEventName                 As Integer = 133                      'ｲﾍﾞﾝﾄ名
    Private Const CMlngvsfHisWEntryTime                 As Integer = 200                      '処理日時
    Private Const CMlngvsfHisWEmpName                   As Integer = 133                      '担当者
    Private Const CMlngvsfHisWOldPolRate                As Integer = 166                      '研磨ﾚｰﾄ（変更前）
    Private Const CMlngvsfHisWNewPolRate                As Integer = 166                      '研磨ﾚｰﾄ（変更後）
    Private Const CMlngvsfHisWComments                  As Integer = 133                      '最新ｺﾒﾝﾄ（非表示）

    '@vsfCmpEventListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrvsfHisNo                         As String = "№"                    '№
    Private Const CMstrvsfHisEventName                  As String = "イベント名"            'ｲﾍﾞﾝﾄ名
    Private Const CMstrvsfHisEntryTime                  As String = "処理日時"              '処理日時
    Private Const CMstrvsfHisEmpName                    As String = "担当者"                '担当者
    Private Const CMstrvsfHisOldPolRate                 As String = "研磨ﾚｰﾄ（変更前）"     '研磨ﾚｰﾄ（変更前）
    Private Const CMstrvsfHisNewPolRate                 As String = "研磨ﾚｰﾄ（変更後）"     '研磨ﾚｰﾄ（変更後）
    Private Const CMstrvsfHisComments                   As String = "メンテナンンスコメント" '最新ｺﾒﾝﾄ（非表示）

    '@ｸﾞﾘｯﾄﾞ基本設定
    Private Const CMlngvsfCmpRowTitle                   As Integer = 0                         'ﾀｲﾄﾙ行（行）
    Private Const CMlngvsfCmpColTitle                   As Integer = 0                         'ﾀｲﾄﾙ行（列）
    Private Const CMlngvsfCmpHFontSize                  As Integer = 11                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfCmpHHeight                    As Integer = 20                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfCmpHeight                     As Integer = 18                        '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfCmpCols                       As Integer = 17                        'CMPｸﾞﾘｯﾄﾞMAXCol数
    Private Const CMlngvsfHisCols                       As Integer = 7                         'HisｸﾞﾘｯﾄﾞMAXCol数
    Private Const CMlngvsfInitRow                       As Integer = 2                         'CMPｸﾞﾘｯﾄﾞ初期値（2）

    '@その他
    Private Const CMstrFormName                         As String = "frmxxEN01N1"           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"             'ｲﾍﾞﾝﾄ名称（ﾌｫｰﾑﾛｰﾄﾞ）
    Private Const CMstrAvailFlagOn                      As String = "1"                     '研磨ﾚｰﾄ使用可否(0：使用不可　1:使用可）
    Private Const CMstrBatu                             As String = "×"                    '「×」表示
    Private Const CMlngDisplayMaxCnt                    As Integer = 500                       '表示最大件数
    Private Const CMstrDisplayMax                       As String = "最大"                  '表示最大件数ｵｰﾊﾞｰ時の文字

    '@ｺﾒﾝﾄｽｸﾛｰﾙ制御用
    Private Const CMlngMaxDispRow                       As Integer = 5                         'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private buttonProcessing                    As Boolean              'NSYS ボタン2度押し対策   
    Private mblnCloseFromControlMenu            As Boolean              'NSYS システムコマンドでの画面クローズ    
    Private mblnWindowClose                     As Boolean              'NSYS WindowCloseフラグ
    Private vsfExcpListRowBeforeSort            As Integer              'NSYS ｿｰﾄ時の選択行退避
    Private vsfExcpListScrollPositionX          As Integer              'NSYS 横ｽｸﾛｰﾙ位置退避
    Private vsfExcpListScrollPositionY          As Integer              'NSYS 縦ｽｸﾛｰﾙ位置退避
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
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 17:00:35 N.Kasai
    '更新日：2005/12/02 (Fri) 13:24:44 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 13:24:44 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean                  '戻り値
        Dim ltypEqCmpEventListRec   As EqcmpeventlistRec        'CMPｲﾍﾞﾝﾄ履歴要求構造体
        Dim ltypEqCmpEventListAns   As EqcmpeventlistAns        'CMPｲﾍﾞﾝﾄ履歴応答構造体

        Try

            '@ﾒｲﾝ画面初期化
            Call prvfrmxxEN01N1_Init()

            '@現在状態の表示
            Call prvvsfCmpNowList_Disp()
            
            '@CMP履歴一覧取得要求構造体格納
            With ltypEqCmpEventListRec
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstreq__cmpeventlistVer
                '@WPID
                .strWpID = ptypCmpRirekeiinfo.strWpID
                '@ﾍｯﾄﾞ
                .strHead = ptypCmpRirekeiinfo.strHead
                '@ﾌﾟﾗﾃﾝ
                .strPlaten = ptypCmpRirekeiinfo.strPlaten
            End With
            
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)

            '@CMPｲﾍﾞﾝﾄ履歴取得
            lblnAns = pubblnEqCmpEventList_Sel(ltypEqCmpEventListRec, ltypEqCmpEventListAns)
            
            '@結果判定
            If lblnAns = True Then
            
                '@ﾛｯﾄｲﾍﾞﾝﾄ履歴格納
                Call prvvsfCmpEventList_Disp(ltypEqCmpEventListAns)

                '@ｲﾍﾞﾝﾄ履歴表示使用可
                txtComments.Enabled = True
                
        '@↓2005/12/02 (Fri) 13:23:41 N.Kojima **************************************************
        '@ｽｸﾛｰﾙ有効制御はﾃｷｽﾄのｲﾍﾞﾝﾄにて行なう為、ｺﾒﾝﾄｱｳﾄ
        '        cmdUp.Enabled = True
        '        cmdDown.Enabled = True
        '@↑2005/12/02 (Fri) 13:23:41 N.Kojima **************************************************
                
                '@該当件数ﾗﾍﾞﾙに取得件数を表示
                If ltypEqCmpEventListAns.lngEqcmpeventlistCnt >= CMlngDisplayMaxCnt Then
                    '@該当件数が500件以上の場合は、"最大 500"を表示する
                    lblListCnt.Text = CMstrDisplayMax & Space(1) & Format$(ltypEqCmpEventListAns.lngEqcmpeventlistCnt, CPstrDateFormatKanma)
                Else
                    lblListCnt.Text = Format$(ltypEqCmpEventListAns.lngEqcmpeventlistCnt, CPstrDateFormatKanma)
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            Else
                '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@該当件数ﾗﾍﾞﾙに取得件数を表示
                lblListCnt.Text = vbNullString
            End If


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
    '機　能：ｴﾝﾀｰで次項目に進む
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：未使用
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 16:59:35 N.Kasai
    '更新日：2005/03/15 (Tue) 16:59:35
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
                       
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKeyを受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If
            
            '@Enterｷｰ押下
            If e.KeyCode = Keys.Return Then
                Select Case ActiveControl.Name

                    '@ｺﾒﾝﾄ欄
                    Case txtComments.Name
                        Exit Sub
                    '@上記以外
                    Case Else
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                End Select
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
    '機　能：ﾌｫｰﾑのｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel    ：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 16:59:52 N.Kasai
    '更新日：2005/03/15 (Tue) 16:59:52
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
           
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
           
            '@ﾌｫｰﾑの初期化
            
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
    '機　能：終了ﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 17:00:09 N.Kasai
    '更新日：2005/03/15 (Tue) 17:00:09
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
            

            

            '@画面を閉じる
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

    '@↓2005/12/02 (Fri) 13:12:58 N.Kojima **************************************************
    '関数名：txtComments_Change
    '機　能：最終ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/02 (Fri) 13:14:21 N.Kojima
    '更新日：2005/12/02 (Fri) 13:14:21
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
    '@↑2005/12/02 (Fri) 13:12:58 N.Kojima **************************************************

    '@↓2005/12/02 (Fri) 10:18:00 N.Kojima **************************************************
    '関数名：txtComments_KeyUp
    '機　能：最終ｺﾒﾝﾄﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/12/02 (Fri) 13:14:39 N.Kojima
    '更新日：2005/12/02 (Fri) 13:14:39
    '備　考：
    Private Sub txtComments_KeyUp(ByVal sender As Object, ByVal e As keyEventArgs) Handles txtComments.KeyUp
        
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
    '@↑2005/12/02 (Fri) 10:18:00 N.Kojima **************************************************

    '@↓2005/12/02 (Fri) 10:20:14 N.Kojima **************************************************
    '関数名：txtComments_MouseUp
    '機　能：最終ｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/12/02 (Fri) 13:15:29 N.Kojima
    '更新日：2005/12/02 (Fri) 13:15:29
    '備　考：
    Private Sub txtComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtComments.MouseUp
        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown, e.Button)
            
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

    '関数名：cmdUp_Click
    '機　能：ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 16:58:04 N.Kasai
    '更新日：2005/12/02 (Fri) 13:22:09 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 13:22:09 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

        '@↓2005/12/02 (Fri) 13:21:16 N.Kojima **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtComments)
        '
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)
        '@↑2005/12/02 (Fri) 13:21:16 N.Kojima **************************************************

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
    '機　能：ｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 16:58:18 N.Kasai
    '更新日：2005/12/02 (Fri) 13:22:30 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 13:22:30 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

        '@↓2005/12/02 (Fri) 13:22:47 N.Kojima **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtComments)
        '
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)
        '@↑2005/12/02 (Fri) 13:22:47 N.Kojima **************************************************

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

    '関数名：vsfCmpEventList_EnterCell
    '機　能：履歴一覧ｸﾞﾘｯﾄﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/16 (Wed) 09:36:11 N.Kasai
    '更新日：2005/03/16 (Wed) 09:36:11
    '備　考：
    Private Sub vsfCmpEventList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfCmpEventList.EnterCell

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfCmpEventList.Rows.Count <= vsfCmpEventList.Rows.Fixed Then
                Return
            End If
            
            
            With vsfCmpEventList
                '@固定行判定
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If
            
                '@該当行のｺﾒﾝﾄ欄を判定し表示
                If .GetData(.Row, CMlngvsfHisComments) <> vbNullString Then
                    '@最終ｺﾒﾝﾄ表示
                    txtComments.Text = .GetData(.Row, CMlngvsfHisComments)
                Else
                    '@最終ｺﾒﾝﾄの初期化
                    txtComments.Text = vbNullString
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCmpEventList_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCmpEventList_Disp
    '機　能：ｲﾍﾞﾝﾄ履歴の表示設定
    '引　数：ltypLotEventList：ｲﾍﾞﾝﾄ履歴応答構造体
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 14:27:11 N.Kasai
    '更新日：2005/12/02 (Fri) 14:15:34 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 14:15:34 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    Private Sub prvvsfCmpEventList_Disp(ByRef ltypEqCmpEventListAns As EqcmpeventlistAns)

        Dim llngCnt         As Integer      'ｶｳﾝﾀ

        Try

            With vsfCmpEventList
            
                '@再描画を行わない
                .Redraw = false
                '@行数設定
                .Rows.Count = ltypEqCmpEventListAns.lngEqcmpeventlistCnt + 1

                'NSYS @ﾀｲﾄﾙ行設定
                .Row = 0
                    
                '@一覧表示情報設定
                For llngCnt = 0 To ltypEqCmpEventListAns.lngEqcmpeventlistCnt-1
                    .SetData(llngCnt+1, CMlngvsfHisNo, llngCnt+1)                                                                          '№
                    .SetData(llngCnt+1, CMlngvsfHisEventName, _
                        ltypEqCmpEventListAns.typEqcmpeventlist(llngCnt).strEventName)                                                 'ｲﾍﾞﾝﾄ名
                    .SetData(llngCnt+1, CMlngvsfHisEntryTime, _
                        ltypEqCmpEventListAns.typEqcmpeventlist(llngCnt).strEntryTime)             '処理日時
                    .SetData(llngCnt+1, CMlngvsfHisEmpName, _
                        ltypEqCmpEventListAns.typEqcmpeventlist(llngCnt).strEmpName)                                                   '担当者
                    .SetData(llngCnt+1, CMlngvsfHisOldPolRate, ltypEqCmpEventListAns.typEqcmpeventlist(llngCnt).strOldPolRate)         '研磨ﾚｰﾄ（変更前）
                    .SetData(llngCnt+1, CMlngvsfHisNewPolRate, ltypEqCmpEventListAns.typEqcmpeventlist(llngCnt).strNewPolRate)         '研磨ﾚｰﾄ（変更後）                                        
                    .SetData(llngCnt+1, CMlngvsfHisComments, _
                        ltypEqCmpEventListAns.typEqcmpeventlist(llngCnt).strComments)                            'ｺﾒﾝﾄ
                    '@高さの設定
                    .Rows(llngCnt+1).Height = CMlngvsfCmpHeight
                Next
                
                '@書式設定
                .Cols(CMlngvsfHisNo).TextAlign = TextAlignEnum.RightCenter                             '右詰の中央揃え（№）
                .Cols(CMlngvsfHisEventName).TextAlign = TextAlignEnum.LeftCenter                       '左詰の中央揃え（ｲﾍﾞﾝﾄ名）
                .Cols(CMlngvsfHisEntryTime).TextAlign = TextAlignEnum.LeftCenter                       '左詰の中央揃え（処理日時）
                .Cols(CMlngvsfHisOldPolRate).TextAlign = TextAlignEnum.RightCenter                     '右詰の中央揃え（研磨ﾚｰﾄ（変更前））
                .Cols(CMlngvsfHisNewPolRate).TextAlign = TextAlignEnum.RightCenter                     '右詰の中央揃え（研磨ﾚｰﾄ（変更後））
                .Cols(CMlngvsfHisComments).TextAlign = TextAlignEnum.LeftCenter                        '左詰の中央揃え（ｺﾒﾝﾄ）
                
                '@ｵｰﾄ幅設定
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngvsfHisNo, .Cols.Count - 1, 6)
                
                '@ﾛｯｸ解除
                .Enabled = True

                '@ﾃﾞｰﾀを画面に直接描画
                .Redraw = True
            End With
           
            '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ欄を使用可
            txtComments.Enabled = True
            
        '@↓2005/12/02 (Fri) 13:24:09 N.Kojima **************************************************
        '@ｽｸﾛｰﾙ有効制御はﾃｷｽﾄのｲﾍﾞﾝﾄにて行なう為、ｺﾒﾝﾄｱｳﾄ
        '    cmdUp.Enabled = True
        '    cmdDown.Enabled = True
        '@↑2005/12/02 (Fri) 13:24:09 N.Kojima **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCmpEventList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN01N1_Init
    '機　能：ﾌｫｰﾑのｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 17:01:45 N.Kasai
    '更新日：2005/03/15 (Tue) 17:01:45
    '備　考：
    Private Sub prvfrmxxEN01N1_Init()

        Try

            'ﾃｷｽﾄ初期化
            txtComments.Text = vbNullString             'ｺﾒﾝﾄ

            '@使用不可
            txtComments.Enabled = False                 'ｺﾒﾝﾄ欄
            txtComments.Locked = True                   'ｺﾒﾝﾄ欄
            cmdUP.Enabled = False                       '▲ﾎﾞﾀﾝ
            cmdDown.Enabled = False                     '▼ﾎﾞﾀﾝ

            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfCmpNowList_Init                  '現在状態ｸﾞﾘｯﾄﾞ
            Call prvvsfCmpEventList_Init                'ｲﾍﾞﾝﾄ履歴ｸﾞﾘｯﾄﾞ

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01N1_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCmpNowList_Init
    '機　能：現在状態CMP一覧ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:25:09 N.Kasai
    '更新日：2005/03/14 (Mon) 16:25:09
    '備　考：
    Private Sub prvvsfCmpNowList_Init()
        Dim headerStyle As CellStyle    'NSYS ヘッダー用追加Style
        Dim cellRange As CellRange      'NSYS 追加Sytle設定範囲

        Try
           
            '@一覧表示の各カラムの幅、タイトルを設定
            With vsfCmpNowList
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                '最大列設定
                .Cols.Count = CMlngvsfCmpCols
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.None
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

                '@列幅設定
                .Cols(CMlngvsfCmpNo).Width = CMlngvsfCmpWNo                                                   'No.
                .Cols(CMlngvsfCmpKb).Width = CMlngvsfCmpWKb                                                   '変更可否
                .Cols(CMlngvsfCmpWpName).Width = CMlngvsfCmpWWpName                                           '装置名
                .Cols(CMlngvsfCmpH).Width = CMlngvsfCmpWH                                                     'ﾍｯﾄﾞ
                .Cols(CMlngvsfCmpP).Width = CMlngvsfCmpWP                                                     'ﾌﾟﾗﾃﾝ
                .Cols(CMlngvsfCmpPolRate).Width = CMlngvsfCmpWPolRate                                         '研磨ﾚｰﾄ
                .Cols(CMlngvsfCmpRateCalcTime).Width = CMlngvsfCmpWRateCalcDate                               'ﾚｰﾄ算出日時
                .Cols(CMlngvsfCmpLotID).Width = CMlngvsfCmpWLotID                                             'ﾚｰﾄ算出ﾛｯﾄID
                .Cols(CMlngvsfCmpOpID).Width = CMlngvsfCmpWOpID                                               '大工程
                .Cols(CMlngvsfCmpPolTime).Width = CMlngvsfCmpWPolTime                                         '研磨時間
                .Cols(CMlngvsfCmp1st).Width = CMlngvsfCmpW1st                                                 '1st膜厚
                .Cols(CMlngvsfCmp2nd).Width = CMlngvsfCmpW2nd                                                 '2nd膜厚
                .Cols(CMlngvsfCmpWpID).Width = CMlngvsfCmpWWpID                                               'WPID
                .Cols(CMlngvsfCmpAvailFlag).Width = CMlngvsfCmpWAvaiFlag                                      '使用可否F
                .Cols(CMlngvsfCmpEditTime).Width = CMlngvsfCmpWEditTime                                       '応答ﾒｯｾｰｼﾞ生成日時
                .Cols(CMlngvsfCmpEventName).Width = CMlngvsfCmpWEventName                                     'ｲﾍﾞﾝﾄ名
                .Cols(CMlngvsfCmpComments).Width = CMlngvsfCmpWComments                                       'ｺﾒﾝﾄ
                
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
                .Cols(CMlngvsfCmpNo).Visible = false                                                            '№
                .Cols(CMlngvsfCmpWpID).Visible  = false                                                          'WPID
                .Cols(CMlngvsfCmpAvailFlag).Visible  = false                                                     '変更可否ﾌﾗｸﾞ
                .Cols(CMlngvsfCmpEditTime).Visible  = false                                                      '応答ﾒｯｾｰｼﾞ生成日時
                .Cols(CMlngvsfCmpEventName).Visible  = false                                                     'ｲﾍﾞﾝﾄ名
                .Cols(CMlngvsfCmpComments).Visible  = false                                                      'ｺﾒﾝﾄ
           
                '@表示位置の設定
                headerStyle.TextAlign = TextAlignEnum.CenterCenter 
                cellRange = .GetCellRange(CMlngvsfCmpRowTitle, CMlngvsfCmpNo, CMlngvsfCmpRowTitle, .Cols.Count - 1)
                cellRange.Style = headerStyle
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngvsfCmpRowTitle).Height = CMlngvsfCmpHHeight
                '@行列のﾏｳｽでの変更を不可にする
                .AllowResizing = AllowResizingEnum.None
                'ﾊｲﾗｲﾄ表示
                .HighLight = HighLightEnum.Never 
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                '@使用不可
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCmpNowList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCmpEventList_Init
    '機　能：CMPｲﾍﾞﾝﾄ履歴一覧ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 17:23:42 N.Kasai
    '更新日：2005/03/15 (Tue) 17:23:42
    '備　考：
    Private Sub prvvsfCmpEventList_Init()
        Dim headerStyle As CellStyle    'NSYS ヘッダー用追加Style
        Dim cellRange As CellRange      'NSYS 追加Sytle設定範囲

        Try
           
            '@一覧表示の各カラムの幅、タイトルを設定
            With vsfCmpEventList
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                '最大列設定
                .Cols.Count = CMlngvsfHisCols
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

                '@列幅設定
                .Cols(CMlngvsfHisNo).Width = CMlngvsfHisWNo                                                   'No.
                .Cols(CMlngvsfHisEventName).Width = CMlngvsfHisWEventName                                     'ｲﾍﾞﾝﾄ名
                .Cols(CMlngvsfHisEntryTime).Width = CMlngvsfHisWEntryTime                                     '処理日時
                .Cols(CMlngvsfHisEmpName).Width = CMlngvsfHisWEmpName                                         '担当者
                .Cols(CMlngvsfHisOldPolRate).Width = CMlngvsfHisWOldPolRate                                   '研磨ﾚｰﾄ（変更前）
                .Cols(CMlngvsfHisNewPolRate).Width = CMlngvsfHisWNewPolRate                                   '研磨ﾚｰﾄ（変更後）
                .Cols(CMlngvsfHisComments).Width = CMlngvsfHisWComments                                       '最新ｺﾒﾝﾄ（非表示）
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfHisNo, CMstrvsfHisNo)                       'No.
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfHisEventName, CMstrvsfHisEventName)         'ｲﾍﾞﾝﾄ名
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfHisEntryTime, CMstrvsfHisEntryTime)         '処理日時
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfHisEmpName, CMstrvsfHisEmpName)             '担当者
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfHisOldPolRate, CMstrvsfHisOldPolRate)       '研磨ﾚｰﾄ（変更前）
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfHisNewPolRate, CMstrvsfHisNewPolRate)       '研磨ﾚｰﾄ（変更後）
                .SetData(CMlngvsfCmpRowTitle, CMlngvsfHisComments, CMstrvsfHisComments)           '最新ｺﾒﾝﾄ（非表示）
               
                '@非表示Col設定
                .Cols(CMlngvsfHisComments).Visible  = false                                                      'ｺﾒﾝﾄ
           
                '@表示位置の設定
                headerStyle.TextAlign = TextAlignEnum.CenterCenter 
                cellRange = .GetCellRange(CMlngvsfCmpRowTitle, CMlngvsfCmpNo, CMlngvsfCmpRowTitle, .Cols.Count - 1)
                cellRange.Style = headerStyle
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngvsfCmpRowTitle).Height = CMlngvsfCmpHHeight
                '@行列のﾏｳｽでの変更を可にする
                .AllowResizing = AllowResizingEnum.Columns
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light 
                '@使用不可
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCmpEventList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCmpNowList_Disp
    '機　能：CMP情報一覧表示
    '引　数：ltypEqcmplistAns：CMP情報一覧取得応答構造体
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 10:39:55 N.Kasai
    '更新日：2005/12/02 (Fri) 14:17:06 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 14:17:06 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    Private Sub prvvsfCmpNowList_Disp()
        
        Dim lstrAvailFlag   As String   '研磨ﾚｰﾄ使用可否ﾌﾗｸﾞ退避(0：使用不可　1:使用可）

        Try
            
            '@現在状態表示
            With vsfCmpNowList
                '@ﾛｯｸ解除
                .Enabled = True
                '@再描画を行わない
                .Redraw = false
                '@行数設定（2行固定）
                .Rows.Count = CMlngvsfInitRow
                
                .SetData(.Rows.Fixed, CMlngvsfCmpNo, .Rows.Fixed)                                              '№
                .SetData(.Rows.Fixed, CMlngvsfCmpWpName, ptypCmpRirekeiinfo.strWpName)                         '装置名
                .SetData(.Rows.Fixed, CMlngvsfCmpH, ptypCmpRirekeiinfo.strHead)                                'ﾍｯﾄﾞ
                .SetData(.Rows.Fixed, CMlngvsfCmpP, ptypCmpRirekeiinfo.strPlaten)                              'ﾌﾟﾗﾃﾝ
                .SetData(.Rows.Fixed, CMlngvsfCmpPolRate, ptypCmpRirekeiinfo.strPolRate)   　　　　　　　　　　'研磨ﾚｰﾄ
                If IsDate(ptypCmpRirekeiinfo.strRateCalcTime)
                    .SetData(.Rows.Fixed, CMlngvsfCmpRateCalcTime, _
                        Format$(Cdate(ptypCmpRirekeiinfo.strRateCalcTime), CPstrDateTimeYMDHMS))               'ﾚｰﾄ計算日時
                End If
                .SetData(.Rows.Fixed, CMlngvsfCmpLotID, ptypCmpRirekeiinfo.strLotID)                           'ﾚｰﾄ計算ﾛｯﾄID
                .SetData(.Rows.Fixed, CMlngvsfCmpOpID, ptypCmpRirekeiinfo.strCmpOpID)                          '大工程
                .SetData(.Rows.Fixed, CMlngvsfCmpPolTime, ptypCmpRirekeiinfo.strPolTime)                       '研磨時間
                .SetData(.Rows.Fixed, CMlngvsfCmp1st, ptypCmpRirekeiinfo.strCmp1st)                            '1st膜厚
                .SetData(.Rows.Fixed, CMlngvsfCmp2nd, ptypCmpRirekeiinfo.strCmp2nd)                            '2nd膜厚
                .SetData(.Rows.Fixed, CMlngvsfCmpWpID, ptypCmpRirekeiinfo.strWpID)                             'WPID
                .SetData(.Rows.Fixed, CMlngvsfCmpAvailFlag, ptypCmpRirekeiinfo.strAvailFlag)                   '変更可否ﾌﾗｸﾞ
                 
                 '@研磨ﾚｰﾄ使用可否ﾌﾗｸﾞ取得(0：使用不可　1:使用可）
                 lstrAvailFlag = ptypCmpRirekeiinfo.strAvailFlag
                 
                 '@使用可否表示&ﾊﾞｯｸｶﾗｰ変更
                 If lstrAvailFlag = CMstrAvailFlagOn Then
                     .SetData(.Rows.Fixed, CMlngvsfCmpKb, vbNullString)      '表示なし
                 Else
                     .SetData(.Rows.Fixed, CMlngvsfCmpKb, CMstrBatu)         '×表示
                 End If
                
                '@ｾﾙ色変更（ｸﾞﾚｰ）
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngvsfCmpColTitle, .Rows.Fixed, .Cols.Count - 1)
                cellRange.Style = newStyle

                '@高さの設定
                .Rows(.Rows.Fixed).Height = CMlngvsfCmpHeight
                            
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
                
                '@ｵｰﾄ幅設定
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngvsfCmpNo, .Cols.Count - 1, 6)
                '@ﾃﾞｰﾀを画面に直接描画
                .Redraw = True

            End With
            
            '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ欄を使用可
            txtComments.Enabled = True
            
        '@↓2005/12/02 (Fri) 13:24:26 N.Kojima **************************************************
        '@ｽｸﾛｰﾙ有効制御はﾃｷｽﾄのｲﾍﾞﾝﾄにて行なう為、ｺﾒﾝﾄｱｳﾄ
        '    cmdUp.Enabled = True
        '    cmdDown.Enabled = True
        '@↑2005/12/02 (Fri) 13:24:26 N.Kojima **************************************************
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCmpNowList_Disp"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Frame1.Paint, fraRireki.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfCmpEventList.BeforeDoubleClick, vsfCmpNowList.BeforeDoubleClick

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

    '関数名：vsfCmpEventList_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2020/05/11 (Mon) 10:00:00 NSYS
    '作成日：2020/05/11 (Mon) 10:00:00 NSYS
    '備　考：
    Private Sub vsfCmpEventList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfCmpEventList.BeforeSort

        Try
            'ソートでRowColChangeを発生しないようにする
            RemoveHandler vsfCmpEventList.EnterCell, AddressOf vsfCmpEventList_EnterCell
            vsfExcpListRowBeforeSort = vsfCmpEventList.Row                  'NSYS ソート前の選択行を保持
            vsfExcpListScrollPositionX = vsfCmpEventList.ScrollPosition.X   'NSYS ソート前の横スクロール位置を保持
            vsfExcpListScrollPositionY = vsfCmpEventList.ScrollPosition.Y   'NSYS ソート前の縦スクロール位置を保持
            vsfCmpEventList.Redraw = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCmpEventList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '関数名：vsfCmpEventList_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：なし
    '戻り値：なし
    '作成日：2020/05/11 (Mon) 10:00:00 NSYS
    '作成日：2020/05/11 (Mon) 10:00:00 NSYS
    '備　考：
    Private Sub vsfCmpEventList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfCmpEventList.AfterSort

        Try

            '保持していた行を再設定
            vsfCmpEventList.Row = vsfExcpListRowBeforeSort
            
            'NSYS ソート前の横スクロール位置を復元
            vsfCmpEventList.ScrollPosition= New Point(vsfExcpListScrollPositionX, vsfExcpListScrollPositionY)

            '該当行のｺﾒﾝﾄ欄を判定し表示
            If vsfCmpEventList.Row > 0 And vsfCmpEventList.GetData(vsfCmpEventList.Row, CMlngvsfHisComments) <> vbNullString Then
                '最終ｺﾒﾝﾄ表示
                txtComments.Text = vsfCmpEventList.GetData(vsfCmpEventList.Row, CMlngvsfHisComments)
            Else
                '最終ｺﾒﾝﾄの初期化
                txtComments.Text = vbNullString
            End If
            
            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfCmpEventList.EnterCell, AddressOf vsfCmpEventList_EnterCell

            vsfCmpEventList.Redraw = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCmpEventList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
End Class
