'ﾌｧｲﾙ名：xxCM00S0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾒｰﾙ送信画面
'作成日：2005/04/27 (Wed) 10:51:01 N.Kasai
'更新日：2007/02/13 (Tue) 16:26:33 N.Kojima
'備　考：
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00S0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00S0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00S0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00S0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00S0)
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
    Private Const CMstrLocalVersion                 As String = "04.00"         '機能ﾊﾞｰｼﾞｮﾝ

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN01O0  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CPstrguid_sendmessageVer          As String = "01.00"         'ﾒｰﾙ送信
    Private Const CMstrmasdepartmentlistVer         As String = "01.01"         '部署名取得

    '@vsfMailListの定数宣言（ｶﾗﾑ）
    Private Const CMvsfMailListCol1                 As Integer = 0              '表示1
    Private Const CMvsfMailListCol2                 As Integer = 1              '表示2
    Private Const CMvsfMailListCol3                 As Integer = 2              '表示3
    Private Const CMvsfMailListCol4                 As Integer = 3              '表示4
    Private Const CMvsfMailListCol5                 As Integer = 4              '表示5

    '@vsfMailListの定数宣言（表示幅）
    Private Const CMvsfMailListWCol1                As Integer = 160            '表示1
    Private Const CMvsfMailListWCol2                As Integer = 160            '表示2
    Private Const CMvsfMailListWCol3                As Integer = 160            '表示3
    Private Const CMvsfMailListWCol4                As Integer = 160            '表示4
    Private Const CMvsfMailListWCol5                As Integer = 160            '表示5

    '@その他ｸﾞﾘｯﾄの定数
    Private Const CMvsfMailListCol                  As Integer = 5              'ｶﾗﾑ数
    Private Const CMvsfMailListTRow                 As Integer = 0              'ﾀｲﾄﾙ行
    Private Const CMvsfMailListHeight               As Integer = 43             '行の高さ
    Private Const CMvsfMailListFontSize             As Integer = 12             'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfMailPageRows              As Integer = 3              'ﾍﾟｰｼﾞRows

    '@ﾚｽﾎﾟﾝｽ用定数
    Private Const CMstrFormName                     As String = "frmxxCM00S0"           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                     As String = "Form_Load"             'ｲﾍﾞﾝﾄ名称（ﾌｫｰﾑﾛｰﾄﾞ）
    Private Const CMstrSendMailClick                As String = "cmdSendMail_Click"     'ｲﾍﾞﾝﾄ名称（送信ﾎﾞﾀﾝ）

    '@その他定数
    Private Const CMlngMaxDispRow                   As Integer = 13                     'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private buttonProcessing                        As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                  'NSYS WindowCloseフラグ

    Private ReadOnly flexRDDirect                   As Boolean = True           'NSYS Redraw用
    Private ReadOnly flexRDNone                     As Boolean = False          'NSYS Redraw用

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
        pubVsfMouseWheelManager_Set(vsfMailList, cmdUp, cmdDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 19:16:21 N.Kasai
    '更新日：2005/05/09 (Mon) 19:16:21
    '備　考：
    '　　　：2005/09/21 (Wed) 15:58:22 S.Deguchi    ﾕｰｻﾞｰ要望№0072の対応で引継構造体処理を追加
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypDepartmentInfo      As DepartmentInfo       '初期化用構造体

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01O0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@ﾌﾗｸﾞ初期化(ﾃﾞﾌｫﾙﾄTrueで確定ﾎﾞﾀﾝが押下された時のみFalse)
            pblnCancel = True
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
               
            '@画面初期化
            Call prvfrmxxCM00S0_Init()

            '@起動時には初期化しておく
            ptypDepartmentList = ltypDepartmentInfo
            
            '@部署名を取得する
            lblnAns = pubblnMasDepartmentList_Sel(CMstrmasdepartmentlistVer, _
                                                  ptypDepartmentList)
            '@結果判定
            If lblnAns = False Then
            '@処理を終了して画面に戻る
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)

                Exit Sub
            End If

            'NSYS テキストボックスの初期化
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            If pblnfrmxxEN0050kbn = True Then
                lblLengthCount0.Text = pubstrMsgReplace_Set(CPstrCommentLength, txtsubject.NowByte, CPlngMailSubjectMaxByte)
                '@1500文字制限
                lblLengthCount1.Text = pubstrMsgReplace_Set(CPstrCommentLength, txtMailContents.NowByte, CPlngMailContentsMaxByteConnect)
            Else
                lblLengthCount0.Text = pubstrMsgReplace_Set(CPstrCommentLength, txtsubject.NowByte, CPlngMailSubjectMaxByte)
                '@2000文字制限
                lblLengthCount1.Text = pubstrMsgReplace_Set(CPstrCommentLength, txtMailContents.NowByte, CPlngMailContentsMaxByte)
            End If
            Call pubtxtChange_Proc(txtMailContents, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            'NSYS ﾌｫｰﾑ左上表示
            With Me
                StartPosition = FormStartPosition.Manual 
                .Left = -My.Settings.FormOffset
                .Top = 0
            End With

            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True
            
            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効
             Me.CancelButton = cmdClose

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
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 10:20:24 N.Kojima
    '更新日：2004/07/29 (Thu) 19:37:42 N.Kojima
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfMailList, cmdUP, cmdDown)
            
            '@Enterｷｰの場合
            Select Case e.KeyCode
                Case Keys.Return
                    Select Case ActiveControl.Name
                        '@ﾃｷｽﾄﾌｨｰﾙﾄﾞの場合
                        Case txtMailContents.Name
                            'ﾌｫｰｶｽの移動なし（改行）
                            Exit Sub
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

    '関数名：Form_QueryUnload
    '機　能：画面終了
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：終了方法
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 19:27:17 N.Kasai
    '更新日：2007/02/06 (Tue) 21:03:49 N.Kojima
    '備　考：
    '　　　：2007/02/06 (Tue) 21:03:49 N.Kojima     故障修理記録関連画面からの起動追加に伴い、処理修正。(案件№01602)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm             As Boolean              '開放結果格納

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
        '@↓2007/02/06 (Tue) 21:07:21 N.Kojima **************************************************
            '@ﾌｫｰﾑ起動区分の確認
        '    If pblnfrmxxEN0050kbn = True Or pblnfrmxxEN00V0kbn = True Then
            If pblnfrmxxEN0050kbn = True Or pblnfrmxxEN00V0kbn = True Or _
                pblnfrmxxEN01Z0kbn = True Or pblnfrmxxCM00Z0kbn = True Then
            
            Else
                '@起動ﾌﾗｸﾞを初期化
                pblnFormLoad = False
                
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
            End If
        '@↑2007/02/06 (Tue) 21:07:21 N.Kojima **************************************************
            
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
    '作成日：2005/05/09 (Mon) 19:18:58 N.Kasai
    '更新日：2007/02/06 (Tue) 21:03:49 N.Kojima
    '備　考：
    '　　　：2007/02/06 (Tue) 21:03:49 N.Kojima     故障修理記録関連画面からの起動追加に伴い、処理修正。(案件№01602)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfoDummy     As CommonInfo   'ﾀﾞﾐｰ構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@引継処理ﾌﾗｸﾞを立てる(起動成功＆送信ｷｬﾝｾﾙ)
            plngfrmxxCM00S0Kbn = 1
            
        '@↓2007/02/06 (Tue) 21:05:06 N.Kojima **************************************************
            '@親ﾌｫｰﾑから呼ばれた場合
        '    If pblnfrmxxEN0050kbn = True Or pblnfrmxxEN00V0kbn = True Then
            If pblnfrmxxEN0050kbn = True Or pblnfrmxxEN00V0kbn = True Or _
                pblnfrmxxEN01Z0kbn = True Or pblnfrmxxCM00Z0kbn = True Then
                '@ｱﾝﾛｰﾄﾞ
                Me.Close()
            Else
                '@空白の場合
                '@終了関数を実行する
                Call publngEnd_Proc(CPstrKeyEN01O0, ltypCommonInfoDummy)
            End If
        '@↑2007/02/06 (Tue) 21:05:06 N.Kojima **************************************************

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

    '関数名：cmdSendMail_Click
    '機　能：ﾒｰﾙ送信
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/06 (Fri) 15:15:52 N.Kasai
    '更新日：2007/02/20 (Tue) 09:21:49 N.Kojima
    '備　考：
    '　　　：2005/09/20 (Tue) 16:41:16 S.Deguchi    工程異常/不適合品処理票からの場合処理を追加
    '　　　：2005/11/21 (Mon) 16:01:35 S.Deguchi    ﾕｰｻﾞｰ要望№0121の対応で処理を全面的に変更(単独起動以外はここで,送信しない)
    '　　　：2007/02/06 (Tue) 21:03:49 N.Kojima     故障修理記録関連画面からの起動追加に伴い、処理修正。(案件№01602)
    '　　　：2007/02/20 (Tue) 09:21:49 N.Kojima     故障修理記録票機能追加に伴い、ﾜｰｸﾌﾛｰ登録処理を統合。(案件№01774)
    Private Sub cmdSendMail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSendMail.Click

        Dim lblnAns                 As Boolean                  '結果取得(True:正常,False:異常)
        Dim llngCnt                 As Integer                  '汎用ｶｳﾝﾀ
        Dim lstrMsg                 As String                   'ﾒｯｾｰｼﾞ内容格納
        Dim ltypSendMailList        As SendMailList             '宛先人格納構造体
        Dim ltypSendMessageList     As SendMessageList          '初期化用構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@宛先ﾁｪｯｸ(50件以上か否か判定)
            If ptypSendMailList.lngSendMailCnt > 50 Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006R)

                '@"<TRM6RW>$$C宛先に50件以上指定することはできません。$設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
        '@↓2007/02/06 (Tue) 21:05:26 N.Kojima **************************************************
            '@引継処理ﾌﾗｸﾞを立てる(起動成功＆送信処理)
        '    If pblnfrmxxEN0050kbn = True Or pblnfrmxxEN00V0kbn = True Then
            If pblnfrmxxEN0050kbn = True Or pblnfrmxxEN00V0kbn = True Or _
                pblnfrmxxEN01Z0kbn = True Or pblnfrmxxCM00Z0kbn = True Then
                '@起動成功＆送信OK
                plngfrmxxCM00S0Kbn = 2
            End If
        '@↑2007/02/06 (Tue) 21:05:26 N.Kojima **************************************************
            
            '@ﾒｰﾙ送信要求ﾃﾞｰﾀ格納
            With ptypSendMessageList
                '@APOｺｰﾄﾞｶｳﾝﾄ
                .lngMessageListCnt = 0
                '@APOﾘｽﾄ（初期化）
                If .typMessageList Is Nothing Then
                    .typMessageList = New List(Of MessageList)
                End If
                
                '@ﾒｰﾙﾘｽﾄｶｳﾝﾄ
                If ptypSendMailList.lngSendMailCnt > 0 Then
                    '@ﾘｽﾄｶｳﾝﾄ格納
                    .lngMailListCnt = ptypSendMailList.lngSendMailCnt
                    'ｴﾘｱ確保
                    If .typMailList Is Nothing Then
                        .typMailList = New List(Of MailList)
                    Else
                        .typMailList.Clear()
                    End If

                    '@ﾒﾙｱﾄﾞ格納
                    Dim typMailListTmp As MailList = New MailList
                    For llngCnt = 0 To .lngMailListCnt -1

                        typMailListTmp = New MailList

                        typMailListTmp.strMailAddress = ptypSendMailList.typSendMail(llngCnt).strMail1

                        .typMailList.Add(typMailListTmp)

                    Next llngCnt
                End If
                
                '@送信者ID
                .strSendEmpID = pstrUserID
                '@送信者名
                .strSendEmpName = pstrUserName
                '@ﾎﾟｯﾌﾟｱｯﾌﾟﾒｯｾｰｼﾞ内容
                .strMessage = vbNullString
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CPstrguid_sendmessageVer
                '@ﾒｰﾙ件名
                .strMailSubject = txtsubject.Text
                '@ﾒｰﾙ本文（先頭に送信者名を表示）
                .strMailContents = CPstrMailSENDER & pstrUserName & vbCrLf & txtMailContents.Text
            End With
            
            '@ﾛｯﾄ保留から起動した場合の処理を追加
            If pblnfrmxxEN0050kbn = True Then
                '@ﾒｰﾙ本文を修正(ﾛｯﾄ保留画面で再度作り直すので,ここでは,ﾃｷｽﾄの内容のみに変更)
                ptypSendMessageList.strMailContents = txtMailContents.Text
                
                '@ｱﾝﾛｰﾄﾞ
                Me.Close()
                
                Exit Sub
            End If
            
        '@↓2007/02/19 (Mon) 13:36:52 N.Kojima **************************************************
            '@工程異常/不適合品処理票からの場合処理を追加
            If pblnfrmxxEN00V0kbn = True Then
                '@ﾜｰｸﾌﾛｰ登録構造体にﾃﾞｰﾀ格納
        '        With ptypExcpWorkFlow
                With ptypWorkFlow
                    '@異常処理№,起案IDは既にｾｯﾄされているはずなので,省略
                    .strMsgVer = vbNullString                                   'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ(この段階ではNull)
                    .strFromEmpID = pstrUserID                                  '依頼元ID
                    .strFromEmpName = pstrUserName                              '依頼元名称
                    
                    .lngEmpListCnt = ptypSendMailList.lngSendMailCnt            '宛先(担当者)数
                    
                    '@領域確保
                    If .typEmpList Is Nothing Then
                        .typEmpList = New List(Of ExcpToEmpList)
                    Else
                        .typEmpList.Clear()
                    End If

                    Dim typEmpListTmp As ExcpToEmpList = New ExcpToEmpList
                    For llngCnt = 0 To .lngEmpListCnt -1

                        typEmpListTmp = New ExcpToEmpList

                        typEmpListTmp.strToEmpID = ptypSendMailList.typSendMail(llngCnt).strId       '宛先ID
                        typEmpListTmp.strToEmpName  = ptypSendMailList.typSendMail(llngCnt).strName  '宛先名

                        .typEmpList.Add(typEmpListTmp)

                    Next llngCnt
                End With
                
                '@ｱﾝﾛｰﾄﾞ
                Me.Close()
                
                Exit Sub
            End If
        '@↑2007/02/19 (Mon) 13:36:52 N.Kojima **************************************************
            
        '@↓2007/02/06 (Tue) 21:08:10 N.Kojima **************************************************
            '@故障修理記録票関連画面からの起動時の処理を追加
            If pblnfrmxxEN01Z0kbn = True Or pblnfrmxxCM00Z0kbn = True Then
                '@ﾜｰｸﾌﾛｰ登録構造体にﾃﾞｰﾀ格納
                With ptypWorkFlow
                    '@異常処理№,起案IDは既にｾｯﾄされているはずなので,省略
                    .strMsgVer = vbNullString                                   'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ(この段階ではNull)
                    .strFromEmpID = pstrUserID                                  '依頼元ID
                    .strFromEmpName = pstrUserName                              '依頼元名称
                    .lngEmpListCnt = ptypSendMailList.lngSendMailCnt            '宛先(担当者)数
                    
                    '@領域確保
                    If .typEmpList Is Nothing Then
                        .typEmpList = New List(Of ExcpToEmpList)
                    Else
                        .typEmpList.Clear()
                    End If

                    Dim typEmpListTmp As ExcpToEmpList = New ExcpToEmpList
                    For llngCnt = 0 To .lngEmpListCnt -1

                        typEmpListTmp = New ExcpToEmpList

                        typEmpListTmp.strToEmpID  = ptypSendMailList.typSendMail(llngCnt).strId       '宛先ID
                        typEmpListTmp.strToEmpName  = ptypSendMailList.typSendMail(llngCnt).strName   '宛先名

                        .typEmpList.Add(typEmpListTmp)

                    Next llngCnt
                End With
                
                '@ｱﾝﾛｰﾄﾞ
                Me.Close()
                
                Exit Sub
            End If
        '@↑2007/02/06 (Tue) 21:08:10 N.Kojima **************************************************
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrSendMailClick)
            
            '@ﾒｯｾｰｼﾞ送信【ﾒｰﾙ送信】
            lblnAns = pubblnGuidSendMessage_Sel(ptypSendMessageList)
            '@結果取得
            If lblnAns = True Then
                '@表示ﾒｯｾｰｼﾞ変換("<TRM4SI>$$メールの送信を受け付けました。")
                lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf004S)
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(lstrMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrSendMailClick)
                
                '@宛先のｸﾘｱ
                ptypSendMailList = ltypSendMailList
                
                '@件名、本文のｸﾘｱ
                With ptypMailInfo
                    .strMailSubject = vbNullString
                    .strMailContents = vbNullString
                End With
                
                '@ﾒｰﾙ内容の初期化
                ptypSendMessageList = ltypSendMessageList
                
                '@画面初期化
                Call prvfrmxxCM00S0_Init()
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrSendMailClick)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSendMail_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMailChoice_Click
    '機　能：宛先検索ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 19:13:14 N.Kasai
    '更新日：2005/05/09 (Mon) 19:13:14
    '備　考：
    Private Sub cmdMailChoice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMailChoice.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@宛先検索画面起動
            frmxxCM00S1.Instance.ShowDialog(Me)
            frmxxCM00S1.Instance = Nothing
            
            '@宛先ｸﾞﾘｯﾄﾞ表示
            Call prvMailList_Disp()
            
            '@送信ﾎﾞﾀﾝ制御
            Call prvcmdSendMail_Chk()
            
            '@削除ﾎﾞﾀﾝ使用不可
            cmdMailDel.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMailChoice_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMailDel_Click
    '機　能：宛先削除ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 19:15:20 N.Kasai
    '更新日：2006/03/02 (Thu) 18:25:53 N.Kojima
    '備　考：
    '　　　：2006/03/02 (Thu) 18:25:53 N.Kojima     削除対象外ﾃﾞｰﾀ格納処理に「宛先人ID」を追加。(運用障害№737対応)
    Private Sub cmdMailDel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMailDel.Click
        
        Dim llngDelindex        As Integer              '削除対象ｾﾙ番号
        Dim llngAddindex        As Integer              '格納対象index
        Dim ltypSendMailList    As SendMailList         '宛先人構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@宛先格納構造体を退避
            ltypSendMailList = ptypSendMailList
            
            '@宛先格納構造体をｸﾘｱ
            If ptypSendMailList.typSendMail Is Nothing Then
                ptypSendMailList.typSendMail = New List(Of SendMail)
            End If
            
            '@格納件数の判定
            If ptypSendMailList.lngSendMailCnt > 1 Then
                '@領域確保
                If ptypSendMailList.typSendMail Is Nothing Then
                    ptypSendMailList.typSendMail = New List(Of SendMail)
                End If
            End If
            
            With vsfMailList
                '@削除対象ｾﾙ番号を取得
                llngDelindex = (.Row * 5) + .Col
            End With
            
            With ptypSendMailList
               '@削除（ﾃﾞｰﾀｶｳﾝﾄから1件減算する。）
               .lngSendMailCnt = ltypSendMailList.lngSendMailCnt -1
               
               '@格納対象indexの初期化
               llngAddindex = 0

        'NSYS リスト化したため、値を詰めなおす必要がないので削除 start
        '       '@ﾃﾞｰﾀ格納構造体から削除ﾃﾞｰﾀを除くﾃﾞｰﾀを再入替えする。
        '       Dim typSendMailTmp As SendMail = New SendMail
        '       For llngCnt = 0 To ltypSendMailList.lngSendMailCnt -1
        '           '@削除対象index判定
        '           If llngCnt <> llngDelindex Then
        '               '@削除対象外ﾃﾞｰﾀを再格納

        '               typSendMailTmp = .typSendMail(llngAddindex)
                       
        '               typSendMailTmp.strMail1 = ltypSendMailList.typSendMail(llngCnt).strMail1     'ﾒｰﾙｱﾄﾞﾚｽ1
        ''@↓2006/03/02 (Thu) 18:27:07 N.Kojima **************************************************
        '               typSendMailTmp.strId = ltypSendMailList.typSendMail(llngCnt).strId           '宛先人ID
        ''@↑2006/03/02 (Thu) 18:27:07 N.Kojima **************************************************
        '               typSendMailTmp.strName = ltypSendMailList.typSendMail(llngCnt).strName       '宛先人名

        '               .typSendMail(llngAddindex) = typSendMailTmp
            
        '               '@構造体格納indexｶｳﾝﾄup
        '               llngAddindex = llngAddindex + 1
                       
        '               '@ﾃﾞｰﾀ件数=格納件数が同じ場合は処理抜け
        '               If llngAddindex = .lngSendMailCnt + 1 Then
        '                   Exit For
        '               End If
        '           End If
        '       Next

                'NSYS RemoveAt処理のみで上記と同様の動作をする
                ltypSendMailList.typSendMail.RemoveAt(llngDelindex) 
        'NSYS end
            
                '@全削除の場合はｸﾞﾘｯﾄﾞの初期化
                If .lngSendMailCnt = 0 Then
                    '@ｸﾞﾘｯﾄﾞ初期化
                    vsfMailList.Rows.Count = vsfMailList.Rows.Fixed
                Else
                    '宛先ｸﾞﾘｯﾄﾞ表示
                    Call prvMailList_Disp()
                End If
            End With
            
            '@削除ﾎﾞﾀﾝ使用不可
            cmdMailDel.Enabled = False
            
            '@送信ﾎﾞﾀﾝ制御
            Call prvcmdSendMail_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMailDel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtsubject_Change
    '機　能：件名ｺﾒﾝﾄ変更
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 19:29:54 N.Kasai
    '更新日：2005/05/09 (Mon) 19:29:54
    '備　考：
    Private Sub txtsubject_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtsubject.Change

        Dim llngNowByte      As Integer  '現在のﾊﾞｲﾄ数

        Try
           
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtsubject.NowByte

            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount0.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                             llngNowByte, _
                                                             CPlngMailSubjectMaxByte)
            
            '@送信ﾎﾞﾀﾝ制御
            Call prvcmdSendMail_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtsubject_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMailContents_Change
    '機　能：本文ｺﾒﾝﾄ変更
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 19:29:16 N.Kasai
    '更新日：2005/05/09 (Mon) 19:29:16
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub txtMailContents_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtMailContents.Change

        Dim llngNowByte      As Integer  '現在のﾊﾞｲﾄ数

        Try
           
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtMailContents.NowByte

            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            If pblnfrmxxEN0050kbn = True Then
                '@1500文字制限
                lblLengthCount1.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                                 llngNowByte, _
                                                                 CPlngMailContentsMaxByteConnect)
            Else
                '@2000文字制限
                lblLengthCount1.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                                 llngNowByte, _
                                                                 CPlngMailContentsMaxByte)
            End If
            
            '@送信ﾎﾞﾀﾝ制御
            Call prvcmdSendMail_Chk()
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtMailContents, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMailContents_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMailContents_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 14:32:58 S.Deguchi
    '更新日：2005/11/22 (Tue) 14:32:58
    '備　考：
    Private Sub txtMailContents_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtMailContents.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtMailContents, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMailContents_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMailContents_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 14:33:35 S.Deguchi
    '更新日：2005/11/22 (Tue) 14:33:35
    '備　考：
    Private Sub txtMailContents_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtMailContents.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtMailContents, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMailContents_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtDown_Click
    '機　能：次頁ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 19:08:11 N.Kasai
    '更新日：2005/05/09 (Mon) 19:08:11
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
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtMailContents, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
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

    '関数名：cmdTxtUp_Click
    '機　能：前頁ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 19:08:13 N.Kasai
    '更新日：2005/05/09 (Mon) 19:08:13
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
                
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtMailContents, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
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

    '関数名：cmdUp_Click
    '機　能：前頁（Mail)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 19:30:54 N.Kasai
    '更新日：2005/05/09 (Mon) 19:30:54
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

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdUp(vsfMailList, cmdUP, cmdDown)
            
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
    '機　能：次頁（Mail)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 19:31:05 N.Kasai
    '更新日：2005/05/09 (Mon) 19:31:05
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
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdDown(vsfMailList, cmdUP, cmdDown, False)
                
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

    '関数名：vsfMailList_EnterCell
    '機　能：宛先ｸﾞﾘｯﾄﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/10 (Tue) 08:57:30 N.Kasai
    '更新日：2005/05/10 (Tue) 08:57:30
    '備　考：
    Private Sub vsfMailList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMailList.EnterCell

        Dim lstrName        As String           '選択行の宛先名を格納

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfMailList.Rows.Count <= vsfMailList.Rows.Fixed Then
                Return
            End If
            
            With vsfMailList
                '@0件の場合は処理なし
                If .Row < 0 Then
                    Exit Sub
                End If
                
                '@選択行を取得
                lstrName = .GetData(.Row, .Col)
                
                '@選択行が空白以外の場合は削除ﾎﾞﾀﾝの使用可
                If lstrName <> vbNullString Then
                    cmdMailDel.Enabled = True
                Else
                    cmdMailDel.Enabled = False
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMailList_EnterCell"
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
    '関数名：prvfrmxxCM00S0_Init
    '機　能：画面初期設定
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 19:31:47 N.Kasai
    '更新日：2007/02/06 (Tue) 21:03:49 N.Kojima
    '備　考：
    '　　　：2005/11/18 (Fri) 17:03:54 S.Deguchi    画面ﾀｲﾄﾙｾｯﾄ処理を修正
    '　　　：2007/02/06 (Tue) 21:03:49 N.Kojima     故障修理記録関連画面からの起動追加に伴い、処理修正。(案件№01602)
    Private Sub prvfrmxxCM00S0_Init()
        
        Dim lstrFormTitle   As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        
        Try
            
        '@↓2007/02/06 (Tue) 21:15:06 N.Kojima **************************************************
            '@画面ﾀｲﾄﾙｾｯﾄ処理
            If pblnfrmxxEN0050kbn = True Then
                '@保留画面から遷移
                
                '@ﾀｲﾄﾙ：保留ﾛｯﾄﾒｰﾙ送信
                Me.Text = CPstrSubFormCM00S0HOLD
            Else
                If pblnfrmxxEN00V0kbn = True Then
                    '@工程異常/不適合品処理票一覧画面から遷移
                    
                    '@ﾀｲﾄﾙ：工程異常処理票　兼　不適合品処理票確認依頼
                    Me.Text = CPstrSubFormCM00S0EXCP
                Else
                    If pblnfrmxxEN01Z0kbn = True Or pblnfrmxxCM00Z0kbn = True Then
                        '@故障修理記録票一覧or故障修理記録票登録／更新画面から遷移
                    
                        '@ﾀｲﾄﾙ：故障修理記録票確認依頼
                        Me.Text = CPstrSubFormEN01Z0
                    Else
                        '@単独起動
                        '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
                        Call pubMenuItemCorrelation_Set(CPstrKeyEN01O0, lstrFormTitle)
            
                        '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
                        Me.Text = lstrFormTitle
                    End If
                End If
            End If
        '@↑2007/02/06 (Tue) 21:15:06 N.Kojima **************************************************
            
            '@ptypMailInfo(ﾒｰﾙ構造体）より引継ぎ情報が存在する場合は初期ｾｯﾄする。
            '@ﾃｷｽﾄﾌｨｰﾙﾄﾞ
            If ptypMailInfo.strMailSubject <> vbNullString Then
                '@件名
                With txtsubject
                    .Text = ptypMailInfo.strMailSubject
                    .ChrMaxByte = CPlngMailSubjectMaxByte
                    .MultiLineEx = False
                End With
                
                '@単独起動か否かで処理分岐
                If pblnfrmxxEN0050kbn = True Then
                '@保留画面から遷移
                    '@本文
                    With txtMailContents
                        .Text = ptypMailInfo.strMailContents
                        .ChrMaxByte = CPlngMailContentsMaxByteConnect
                    End With
                Else
                '@単独起動
                    '@本文
                    With txtMailContents
                        .Text = ptypMailInfo.strMailContents
                        .ChrMaxByte = CPlngMailContentsMaxByte
                    End With
                End If
                
                '@ｸﾞﾘｯﾄﾞ表示の初期化
                Call prvMailList_init()
                
                '@宛先ｸﾞﾘｯﾄﾞ表示
                Call prvMailList_Disp()
                
                '@送信ﾎﾞﾀﾝ制御
                Call prvcmdSendMail_Chk()
            
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ
                cmdMailDel.Enabled = False              '削除ﾎﾞﾀﾝ
            Else
                '@件名
                With txtsubject
                    .Text = vbNullString
                    .ChrMaxByte = CPlngMailSubjectMaxByte
                    .MultiLineEx = False
                End With
                
                '@本文
                With txtMailContents
                    .Text = vbNullString
                    .ChrMaxByte = CPlngMailContentsMaxByte
                End With
                
                '@ｸﾞﾘｯﾄﾞ表示の初期化
                Call prvMailList_init()
                
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ
                cmdMailDel.Enabled = False              '削除ﾎﾞﾀﾝ
                cmdSendMail.Enabled = False             '送信ﾎﾞﾀﾝ
                cmdUP.Enabled = False                   '前頁(宛先）
                cmdDown.Enabled = False                 '次頁(宛先）
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00S0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMailList_init
    '機　能：vsfMailListの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 19:32:59 N.Kasai
    '更新日：2005/05/09 (Mon) 19:32:59
    '備　考：
    Private Sub prvMailList_init()

        Dim lNormalStyle    As CellStyle 'NSYS スタイル定義

        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfMailList

                '@描画ﾛｯｸ
                .Redraw = flexRDNone
                
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear
                
                '@ｸﾞﾘｯﾄﾞの行設定
                .Rows.Count = CMvsfMailListTRow
                
                '@ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMvsfMailListCol
                
                '@ｾﾙ選択の設定（ｾﾙ単位)
                .SelectionMode = SelectionModeEnum.Cell

                lNormalStyle = .Styles.Normal
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号（...）を文字列の最後に表示 'NSYS 混在不可の為削除
                'lNormalStyle.Trimming = StringTrimming.EllipsisCharacter
                
                '@文章を折り返して表示する
                lNormalStyle.WordWrap = True
                
                '@列の調整を可能にする
                '.AutoSizeMode = flexAutoSizeColWidth    '列幅（ﾃﾞﾌｫﾙﾄ）
                
                '@行列のﾏｳｽでの変更を不可にする
                .AllowResizing = AllowResizingEnum.None
                
                'ﾊｲﾗｲﾄ表示
                .HighLight = HighLightEnum.Always
                
                '@列幅設定
                .Cols(CMvsfMailListCol1).Width = CMvsfMailListWCol1
                .Cols(CMvsfMailListCol2).Width = CMvsfMailListWCol2
                .Cols(CMvsfMailListCol3).Width = CMvsfMailListWCol3
                .Cols(CMvsfMailListCol4).Width = CMvsfMailListWCol4
                .Cols(CMvsfMailListCol5).Width = CMvsfMailListWCol5
                
                '@再描画
                .Redraw = flexRDDirect
                
                '@ﾛｯｸ
                .Enabled = False
                
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ
                cmdUP.Enabled = False                   '前頁
                cmdDown.Enabled = False                 '次頁
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMailList_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMailList_Disp
    '機　能：宛先一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/09 (Mon) 19:37:17 N.Kasai
    '更新日：2005/05/09 (Mon) 19:37:17
    '備　考：
    Private Sub prvMailList_Disp()

        Dim llngCntRow          As Integer  'ｶｳﾝﾄ(Row)
        Dim llngCntCol          As Integer  'ｶｳﾝﾄ(Col)
        Dim llngIndex           As Integer  'ﾃﾞｰﾀｶｳﾝﾄ（index）
        Dim llngMax             As Integer  '最大対象件数
        Dim llngAns             As Integer  '計算用変数（除算）
        Dim llngCalc            As Integer  '計算用変数（Rows）

        Try

            With vsfMailList
                '@0件の場合
                If ptypSendMailList.lngSendMailCnt = 0 Then
                    '@ﾛｯｸ
                    .Enabled = False
                    
                    '@描画なし
                    .Redraw = flexRDNone
                    
                    '@ﾘｽﾄ行数格納
                    .Rows.Count = .Rows.Fixed
                    
                    '@直接描画なし
                    .Redraw = flexRDDirect
                    
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用不可
                    cmdUP.Enabled = False
                    cmdDown.Enabled = False
                    
                    Exit Sub
                End If
                
                '@件数ありの場合
                '@ｸﾞﾘｯﾄﾞのﾛｯｸ解除
                .Enabled = True
                '@描画なし
                .Redraw = flexRDNone
                '@ﾘｽﾄ行数格納
                .Rows.Count = .Rows.Fixed
                
                '@↓Rows計算-----------
                Select Case True
                    '@対象件数がMaxCol以下の場合
                    Case ptypSendMailList.lngSendMailCnt <= CMvsfMailListCol
                        '@行数を反映
                        .Rows.Count = 1
                    
                    '@対象件数がMaxCol以上の場合
                    Case ptypSendMailList.lngSendMailCnt > CMvsfMailListCol
                        '@対象件数から最大Colで除算し、余りを算出
                        llngAns = ptypSendMailList.lngSendMailCnt Mod CMvsfMailListCol
                        
                        '@計算結果判定
                        If llngAns = 0 Then
                            '@最大Colで除算し割り切れる場合
                            llngCalc = (ptypSendMailList.lngSendMailCnt \ CMvsfMailListCol)
                        Else
                            '@最大Colで除算し割り切れない場合
                            llngCalc = (ptypSendMailList.lngSendMailCnt \ CMvsfMailListCol) + 1
                        End If
                        
                        '@算出後の行数を反映
                        .Rows.Count = llngCalc
                End Select
                '@↑Rows計算-----------
                
                '@↓ﾃﾞｰﾀ格納処理-----------
                '@ﾃﾞｰﾀｶｳﾝﾄの初期化（index)
                llngIndex = 1
                
                '@対象件数を格納
                llngMax = ptypSendMailList.lngSendMailCnt
                
                '@件数なしの場合は処理なし
                If llngMax = 0 Then
                    Exit Sub
                End If
                
                '@ｸﾞﾘｯﾄﾞにﾃﾞｰﾀを反映
                '@行ﾙｰﾌﾟ
                For llngCntRow = 1 To .Rows.Count
                    '@ﾍｯﾀﾞｰの高さ設定
                    .Rows(llngCntRow - 1).Height = CMvsfMailListHeight

                    '@列ﾙｰﾌﾟ
                    For llngCntCol = 1 To .Cols.Count
                        '@宛先ｸﾞﾘｯﾄﾞに反映
                        .SetData(llngCntRow - 1, llngCntCol - 1 ,ptypSendMailList.typSendMail(llngIndex -1).strName) 'ﾕｰｻﾞ名
                        
                        '@最大件数の判定
                        If llngIndex < llngMax Then
                            llngIndex = llngIndex + 1
                        Else
                            Exit For
                        End If
                    Next llngCntCol
                Next llngCntRow
                '@↑ﾃﾞｰﾀ格納処理-----------
            
                '@ｽｸﾛｰﾙﾎﾞﾀﾝ設定
                '@頁先頭行が一覧先頭行の場合
                If .TopRow = .Rows.Fixed Then
                    '@ﾛｯｸ
                    cmdUP.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdUP.Enabled = True
                End If
                
                '@最終行が表示頁にある場合
                If .TopRow + CMlngvsfMailPageRows >= .Rows.Count Then
                    '@ﾛｯｸ
                    cmdDown.Enabled = False
                Else
                    '@ﾛｯｸ解除
                    cmdDown.Enabled = True
                End If

                'NSYS 選択状態を解除
                .Row = -1

                '@直接描画
                .Redraw = flexRDDirect

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMailList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdSendMail_Chk
    '機　能：送信ﾎﾞﾀﾝ制御ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/10 (Tue) 10:15:01 N.Kasai
    '更新日：2005/05/10 (Tue) 10:15:01
    '備　考：
    Private Sub prvcmdSendMail_Chk()

        Try
            
            '@送信ﾎﾞﾀﾝ無効
            cmdSendMail.Enabled = False
            
            '@件名の入力判定
            If txtsubject.Text = vbNullString Then
                Exit Sub
            End If
            
            '@本文の入力判定
            If txtMailContents.Text = vbNullString Then
                 Exit Sub
            End If
            
            '@宛先ｸﾞﾘｯﾄﾞに1つでもﾃﾞｰﾀがない場合はNG
            With vsfMailList
                If .Rows.Count = .Rows.Fixed Then
                    Exit Sub
                End If
            End With
            
            '@送信ﾎﾞﾀﾝ有効
            cmdSendMail.Enabled = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdSendMail_Chk"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraMail.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
