'ﾌｧｲﾙ名：xxCM0090.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：投入予定ロット一覧　メインフォーム
'作成日：2004/02/18 (Wed) 17:33:31 M.Miura
'更新日：2013/12/10 (Tue) 16:04:01 T.Oide
'備　考：0040 ﾛｯﾄ投入(基板)、0120 ﾛｯﾄ編成(保留/払出WF) で使用
'　　　：親ﾌｫｰﾑへの値渡しは Public で宣言(ptypLotRlst)
'　　　：2005/06/07 (Tue) 13:44:14 S.Deguchi    不具合№756の対応でﾌｫｰｶｽ処理修正(まだ途中)
'　　　：2006/01/11 (Wed) 10:23:00 T.Kitagawa   ﾕｰｻﾞｰ要望№0134に伴い、種別がESの場合は予定変更可能とする
'　　　：2007/07/27 (Fri) 10:37:10 N.Kasai      ｿｰｽ整備
'　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM0090
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM0090    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM0090
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM0090
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM0090)
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
    '@↓2020/03/06 (Fri) 10:41:59 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion                     As String = "04.00"         '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                     As String = "04.01"         '機能ﾊﾞｰｼﾞｮﾝ
    '@↑2020/03/06 (Fri) 10:41:59 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN00P0  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2019/12/19 (Thu) 19:13:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_rsvlist_Ver                  As String = "02.01"         '投入予定ﾛｯﾄ一覧
    Private Const CMstrlot_rsvlist_Ver                  As String = "03.00"         '投入予定ﾛｯﾄ一覧
    '@↑2019/12/19 (Thu) 19:13:02 Y.Yoneyama 「.Netへ反映未」 **************************************************

    Private Const CMstrmas_flowlistVer                  As String = "04.00"         '種別区分一覧取得

    '@vsfResvLotListの定数宣言(ｶﾗﾑ)
    Private Const CMvsfResvLotListColNo                 As Integer = 0              '№
    Private Const CMvsfResvLotListColPlanThrowinDate    As Integer = 1              '投入予定日
    Private Const CMvsfResvLotListColPdID               As Integer = 2              '機種ID
    Private Const CMvsfResvLotListColLotID              As Integer = 3              'ﾛｯﾄID
    Private Const CMvsfResvLotListColFlowClass          As Integer = 4              '種別ID
    Private Const CMvsfResvLotListColWfNum              As Integer = 5              'WF枚数
    Private Const CMvsfResvLotListColLotManagerName     As Integer = 6              'ﾛｯﾄ担当者名
    Private Const CMvsfResvLotListColLotManagerID       As Integer = 7              'ﾛｯﾄ担当者ｺｰﾄﾞ(非表示)
    Private Const CMvsfResvLotListColPdVersion          As Integer = 8              'PDﾊﾞｰｼﾞｮﾝ(非表示)
    '@↓2019/12/19 (Thu) 18:43:52 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMvsfResvLotListColGRB                As Integer = 9              'GRB
    '@↑2019/12/19 (Thu) 18:43:52 Y.Yoneyama 「.Netへ反映未」 **************************************************
    '@↓2020/03/24 (Tue) 10:42:31 T.Oide 「.Netへ反映未」 **************************************************
    Private Const CMvsfResvLotListColLMSFlag            As Integer = 10             'ﾚｰｻﾞｰﾏｰｶｽｷｯﾌﾟﾌﾗｸﾞ
    '@↑2020/03/24 (Tue) 10:42:31 T.Oide 「.Netへ反映未」 **************************************************

    '@vsfResvLotListの定数宣言(表示幅)
    Private Const CMvsfResvLotListColWNo                As Integer = 60             '№
    Private Const CMvsfResvLotListColWPlanThrowinDate   As Integer = 160            '投入予定日
    Private Const CMvsfResvLotListColWPdID              As Integer = 100            '機種ID
    Private Const CMvsfResvLotListColWLotID             As Integer = 150            'ﾛｯﾄID
    Private Const CMvsfResvLotListColWFlowClass         As Integer = 80             '種別ID
    Private Const CMvsfResvLotListColWWfNum             As Integer = 100            'WF枚数
    Private Const CMvsfResvLotListColWLotManagerName    As Integer = 180            'ﾛｯﾄ担当者名
    '@↓2019/12/19 (Thu) 18:44:35 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMvsfResvLotListColWGRB               As Integer = 60             'GRB
    '@↑2019/12/19 (Thu) 18:44:35 Y.Yoneyama 「.Netへ反映未」 **************************************************
    '@↓2020/03/24 (Tue) 10:42:31 T.Oide 「.Netへ反映未」 **************************************************
    Private Const CMvsfResvLotListColWLMSFlag           As Integer = 60             'ﾚｰｻﾞｰﾏｰｶｽｷｯﾌﾟﾌﾗｸﾞ
    '@↑2020/03/24 (Tue) 10:42:31 T.Oide 「.Netへ反映未」 **************************************************

    '@vsfResvLotListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMvsfResvLotListColTNo                As String = " №"
    Private Const CMvsfResvLotListColTLotID             As String = "ロットID"
    Private Const CMvsfResvLotListColTPdID              As String = "機種"
    Private Const CMvsfResvLotListColTFlowClass         As String = "種別"
    Private Const CMvsfResvLotListColTPlanThrowinDate   As String = "投入予定日"
    Private Const CMvsfResvLotListColTWfNum             As String = "WF枚数"
    Private Const CMvsfResvLotListColTLotManagerName    As String = "ロット担当"
    '@↓2019/12/19 (Thu) 18:44:58 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMvsfResvLotListColTGRB               As String = "GRB"
    '@↑2019/12/19 (Thu) 18:44:58 Y.Yoneyama 「.Netへ反映未」 **************************************************
    '@↓2020/03/24 (Tue) 10:42:31 T.Oide 「.Netへ反映未」 **************************************************
    Private Const CMvsfResvLotListColTLMSFlag           As String = "ﾚｰｻﾞｰﾏｰｶｽｷｯﾌﾟﾌﾗｸﾞ"
    '@↑2020/03/24 (Tue) 10:42:31 T.Oide 「.Netへ反映未」 **************************************************

    '@vsfResvLotListの定数宣言(その他)
    '@↓2020/03/24 (Tue) 10:46:43 T.Oide 「.Netへ反映未」 **************************************************
    '@↓2019/12/19 (Thu) 18:45:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMvsfResvLotListColm                  As Integer = 9              'ｶﾗﾑ数
    Private Const CMvsfResvLotListColm                  As Integer = 11             'ｶﾗﾑ数
    '@↑2019/12/19 (Thu) 18:45:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
    '@↑2020/03/24 (Tue) 10:46:43 T.Oide 「.Netへ反映未」 **************************************************
    Private Const CMvsfResvLotListTRow                  As Integer = 0              'ﾀｲﾄﾙ行
    Private Const CMlngVsfColTitle                      As Integer = 0              'ﾀｲﾄﾙ列
    Private Const CMvsfResvLotListRows                  As Integer = 11             '行数
    Private Const CMvsfResvLotListHFontSize             As Integer = 12             'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMvsfResvLotListHdHeight              As Integer = 27             '行の高さ(ﾍｯﾀﾞｰのみ)
    Private Const CMvsfResvLotListHeight                As Integer = 43             '行の高さ
    Private Const CMvsfResvLotListAll                   As Integer = -1             '表全体

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 16             'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 16             'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                      As Integer = 1              'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCMbSelectMode                    As Integer = 1              '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMlngCmbRowHeight                     As Integer = 30             'ﾘｽﾄ行の高さ
    Private Const CMstrCmbAddedComment                  As String = " 項目選択"
    Private Const CMstrCmbAddedCommentNone              As String = "0 項目選択"

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypChgSort                                 As ChgSort                  'ｿｰﾄ保持用
    Private mtypDivisionList                            As List(Of DivisionList)    '種別一覧格納用
    Private mlngDivisionCnt                             As Integer                  '種別ﾘｽﾄのｶｳﾝﾄ
    Private mblnFormLoadFlag                            As Boolean                  'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：初回起動/False：初回起動以外)
    Private mstrEventName                               As String                   'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
    Private mstrTaihiClassName                          As String                   '選択種別ID退避領域
    Private mblnCmdClassNameChanged                     As Boolean                  'NSYS 種別変更フラグ
    Private buttonProcessing                            As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                  'NSYS WindowCloseフラグ

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
        mblnCmdClassNameChanged = False

        Form_Load()

        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfResvLotList, cmdUp, cmdDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:43:29 M.Miura
    '更新日：2005/11/17 (Thu) 17:13:09 N.Kojima
    '備　考：
    '　　　：2004/10/15 (Fri) 10:54:36 M.Miura　    ｿｰﾄ保持用構造体初期化を追加
    '　　　：2004/11/29 (Mon) 14:29:00 S.Deguchi    該当件数0件時,ﾊﾟﾌﾞﾘｯｸﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞをFalseのまま処理を終了させる
    '　　　：2004/12/06 (Mon) 17:52:19 N.Kasai      起動元ﾌｫｰﾑ判定(品確、ﾓﾆﾀｰ・ﾀﾞﾐｰから呼ばれた場合の判定)を変更　№300
    '　　　：2005/08/01 (Mon) 13:08:39 N.Kasai      L/R表示追加
    '　　　：2005/08/17 (Wed) 15:39:33 N.Kojima     投入予定ﾛｯﾄ変更/削除から戻った場合の処理追加。(不具合№2946)
    '　　　：2005/11/17 (Thu) 17:13:09 N.Kojima     ﾛｯﾄ編成からの起動時の流動区分一覧取得処理を追加。(ﾕｰｻﾞｰ要望№0114)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '投入予定ﾛｯﾄ一覧取得の結果格納

        Try
            
            '@機能ﾊﾞｰｼﾞｮﾝﾁｪｯｸ
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00P0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                Exit Sub
            End If

            '@ﾌﾗｸﾞ初期化(ﾃﾞﾌｫﾙﾄTrueで確定ﾎﾞﾀﾝが押下された時のみFalse)
            pblnCancel = True
            
            '@ﾌﾗｸﾞ初期化
            mblnFormLoadFlag = False
            
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰ,退避用を初期化
                .strKey = vbNullString
                pstrChgSort = vbNullString
            End With

            'NSYS 表示位置設定
            Top = 0
            Left = -My.Settings.FormOffset
            
            '@画面初期化
            Call prvfrmxxCM0090_Init()
                
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            mstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@---------------
            '@起動元ﾌｫｰﾑ判定
            '@---------------
            '@ﾛｯﾄ編成からの起動区分を設定
            If pblnfrmxxEN0120Kbn = True Then
                '@流動区分一覧取得【CPstrCD40：試作実験品のみ取得】
                lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                                mtypDivisionList, _
                                                mlngDivisionCnt, _
                                                pstrSBID, _
                                                CPstrCD40)
            Else
                '@上記以外からの起動
                '@流動区分一覧取得【CPstrCD02：全て取得】
                lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                                mtypDivisionList, _
                                                mlngDivisionCnt, _
                                                pstrSBID, _
                                                CPstrCD02)
            End If
            
            '@結果判定
            If lblnAns = True Then
                
                '@種別情報表示
                Call prvCmbClassName_Disp()
                
                '@画面引継ぎﾌﾗｸﾞにより処理を分岐させる
                '@親ﾌｫｰﾑから起動の場合
                If pstrfrmxxCM0090Kbn <> vbNullString Then
                    
                    '@ﾛｯﾄ分割画面からの起動【CPstrCD0N:分割】
                    If pstrfrmxxCM0090Kbn = CPstrCD0N Then
                        
                        '@ﾛｯﾄ一覧表示
                        lblnAns = prvblnlotrlst_Sel()
                        '@結果判定
                        If lblnAns = False Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, mstrEventName)
                            Exit Sub
                        Else
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(Me.Name, mstrEventName)
                            '@退避領域へ種別ID一覧を格納
                            mstrTaihiClassName = cmbClassName.Value
                        End If
            
                        With vsfResvLotList
                            '@該当ﾃﾞｰﾀがなかった場合
                            If .Rows.Count <= .Rows.Fixed Then
                                '@Form_Loadﾌﾗｸﾞ(異常)
                                pblnFormLoad = False
                                '@種別使用不可
                                cmbClassName.Enabled = False
                                
                                '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                                '@"<TRM29I>$$該当件数 ： %1 件"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, CPstrZero)
                                '@ｲﾝﾌｫﾒｰｼｮﾝ表示
                                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                            Else
                                '@ﾌﾗｸﾞ立て
                                mblnFormLoadFlag = True
                            End If
                        End With
                        
                        '@処理を終了させる
                        Exit Sub
                    Else
                        '@親画面起動でﾛｯﾄ分割以外からの起動
                        
                        '@ﾛｯﾄ一覧表示
                        lblnAns = prvblnlotrlst_Sel()
                        '@結果判定
                        If lblnAns = False Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, mstrEventName)
                            Exit Sub
                        Else
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(Me.Name, mstrEventName)
                            '@退避領域へ種別ID一覧を格納
                            mstrTaihiClassName = cmbClassName.Value
                        End If
                        
                        With vsfResvLotList
                            '@該当ﾃﾞｰﾀがなかった場合
                            If .Rows.Count <= .Rows.Fixed Then
                                '@種別使用不可
                                cmbClassName.Enabled = False
                                '@Form_Loadﾌﾗｸﾞ(異常)
                                pblnFormLoad = False
                                
                                '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                                '@"<TRM29I>$$該当件数 ： %1 件"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, CPstrZero)
                                '@ｲﾝﾌｫﾒｰｼｮﾝ表示
                                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                
                                Exit Sub
                            Else
                                '@ﾌﾗｸﾞ立て
                                mblnFormLoadFlag = True
                            End If
                        End With
                    End If
                Else
                    '@単独起動の場合
                    '@最新取得ﾎﾞﾀﾝを非活性化
                    cmdLotSearch.Enabled = False
                    '@確定ﾎﾞﾀﾝを非表示にする
                    cmdChoice.Visible = False
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
                End If
            Else
                '@流動区分一覧取得に失敗
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            End If
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"
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
    '作成日：2005/06/07 (Tue) 14:02:06 S.Deguchi
    '更新日：2005/08/23 (Tue) 13:10:34 N.Kojima
    '備　考：
    '　　　：2005/08/23 (Tue) 13:10:34 N.Kojima     引継ぎ戻り時のﾌｫｰｶｽ位置の処理追加。(不具合№2946)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@起動時のみ処理
            If mblnFormLoadFlag = True Then
                '@ﾌﾗｸﾞ戻し
                mblnFormLoadFlag = False
                
                '@ﾌｫｰｶｽ処理
                If vsfResvLotList.Enabled = True Then
                    '@一覧ﾀｲﾄﾙへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfResvLotList)
                Else
                    If cmbClassName.Enabled = True Then
                        '@種別ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbClassName)
                    Else
                        '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_Activate"          '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/03/10 (Wed) 14:14:13 M.Miura
    '更新日：2004/07/06 (Tue) 16:53:12 Y.Yamagishi
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
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
                e.Handled = True
                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If

            '@ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfResvLotList, cmdUP, cmdDown)
            
            '@確定ﾎﾞﾀﾝが非表示の場合
            If cmdChoice.Visible = False Then
                '@Enterｷｰの場合
                Select Case e.KeyCode
                    Case Keys.Return
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                End Select
            Else
                '@Enterｷｰの場合
                Select Case e.KeyCode
                    Case Keys.Return
                        '@一覧にﾌｫｰｶｽがある場合
                        If ActiveControl.Name = vsfResvLotList.Name Then
                            '@ﾃﾞｰﾀ行の場合
                            If vsfResvLotList.Row >= vsfResvLotList.Rows.Fixed Then
                                '@確定処理
                                Call cmdChoice_Click(cmdChoice, New EventArgs)
                            End If
                        Else
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                        End If
                End Select
            End If
            
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
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '　　　：UnloadMode：ﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 09:24:55 H.Wajima
    '更新日：2005/08/12 (Fri) 16:47:05 N.Kojima
    '備　考：
    '　　　：2004/09/03 (Fri) 13:52:31 H.Wajima　   配列の解放処理追加
    '　　　：2004/10/15 (Fri) 11:01:29 M.Miura　    ｿｰﾄ保持用構造体のｸﾘｱを追加
    '　　　：2004/11/01 (Mon) 15:07:52 N.Kasai      閉じるﾎﾞﾀﾝ統合
    '　　　：2005/08/12 (Fri) 16:24:19 N.Kojima     種別の退避処理追加(不具合№2946)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納
        
        Try
            
            '@引継ぎ戻り時の自動表示の為、種別の選択数、種別を格納
            plngFlowClass = cmbClassName.ValueCount                     '選択件数
            pstrFlowClassList = Split(cmbClassName.Value, vbTab)        '選択種別
            pstrChgSort = mtypChgSort.strKey                            'ｶﾚﾝﾄ行検索ｷｰを格納

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@配列の解放
            mtypDivisionList = Nothing
            mtypChgSort.typChgSortList = Nothing
            
            '@自ﾌｫｰﾑ起動の場合はACT開放後、終了する
            If pstrfrmxxCM0090Kbn = vbNullString Then
                '@ActInitﾌﾗｸﾞの判定
                If pblnActInitFlg = True Then
                    '@Actを自前で初期化した場合
                    
                    '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                    lblnAnsTerm = pubblnAct_Term()
                    If lblnAnsTerm = True Then
                        '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                    End If
                Else
                    '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                    Call pubMenuExpand_Disp()
                End If
            End If
            
            '@ﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrfrmxxCM0090Kbn = vbNullString
            
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
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:42:55 M.Miura
    '更新日：2005/08/12 (Fri) 16:24:19 N.Kojima
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

            mblnCloseFromControlMenu = False
            
            '@親ﾌｫｰﾑ起動の場合
            If pstrfrmxxCM0090Kbn <> vbNullString Then
                '@ﾌｫｰﾑを閉じる
                Me.Close()
            Else
                '@終了関数を実行する
                Call publngEnd_Proc(CPstrKeyEN00P0, ltypCommonInfo)
            End If

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

    '関数名：cmdChoice_Click
    '機　能：ﾛｯﾄ選択(確定ﾎﾞﾀﾝ)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/02 (Tue) 12:44:04 M.Miura
    '更新日：2008/06/10 (Tue) 17:09:16 N.Kojima
    '備　考：
    '　　　：2004/09/06 (Mon) 20:26:32 N.Kasai　    PDﾊﾞｰｼﾞｮﾝ格納追加
    '　　　：2008/06/10 (Tue) 17:09:16 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmdChoice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChoice.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            With vsfResvLotList
            
                '@行が選択されていない場合は格納しない
                If .Row >= 1 Then
                
                    '@basxxCM0030 Public ptypLotRlst As typLotRlst へ格納
                    ptypLotRlst.strLotID = .GetData(.Row, CMvsfResvLotListColLotID)                       'ﾛｯﾄID
                    ptypLotRlst.strFlowClass = .GetData(.Row, CMvsfResvLotListColFlowClass)               '種別ID
                    ptypLotRlst.strPdId = .GetData(.Row, CMvsfResvLotListColPdID)                         '機種ID
                    ptypLotRlst.strWfNum = .GetData(.Row, CMvsfResvLotListColWfNum)                       'WF枚数
                    ptypLotRlst.strPlanThrowinDate = .GetData(.Row, CMvsfResvLotListColPlanThrowinDate)   '投入予定日
                    ptypLotRlst.strEngEmpName = .GetData(.Row, CMvsfResvLotListColLotManagerName)         'ﾛｯﾄ担当者名
                    ptypLotRlst.strMasVer = .GetData(.Row, CMvsfResvLotListColPdVersion)                  'PDﾊﾞｰｼﾞｮﾝ
                    '@↓2020/03/24 (Tue) 11:07:52 T.Oide 「.Netへ反映未」 **************************************************
                    ptypLotRlst.strLaserMarkerSkipFlag = .GetData(.Row, CMvsfResvLotListColLMSFlag)       'ﾚｰｻﾞｰﾏｰｶｽｷｯﾌﾟﾌﾗｸﾞ
                    '@↑2020/03/24 (Tue) 11:07:52 T.Oide 「.Netへ反映未」 **************************************************
                    
                    '@ｷｬﾝｾﾙﾌﾗｸﾞ設定
                    pblnCancel = False
                    
                    '@ﾌｫｰﾑを閉じる
                    Me.Close()
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdChoice_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdChangePlan_Click
    '機　能：予定変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/09 (Tue) 11:38:38 N.Kojima
    '更新日：2005/08/24 (Wed) 16:20:35 N.Kojima
    '備　考：
    Private Sub cmdChangePlan_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChangePlan.Click

        Dim ltypOldCommonInfo   As CommonInfo   '引継ぎ構造体の退避領域
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@引継ぎ構造体の退避
            ltypOldCommonInfo = ptypCommonInfo

            '@子ﾌｫｰﾑの表示情報を変数に格納
            With ptypCommonInfo
                '@引継ぎ情報ｾｯﾄ
                .strCarrierId = vbNullString
                .strLotID = vsfResvLotList.GetData(vsfResvLotList.Row, CMvsfResvLotListColLotID)       'ﾛｯﾄID
            End With
            
        '@↓2007/10/12 (Fri) 16:44:30 N.Kasai **************************************************
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False

            '@ﾛｯﾄ情報変更・削除(子画面起動中)
            pblnfrmxxCM01A0Kbn = True

            '@子画面をﾛｰﾄﾞ
            frmxxCM01A0.Instance = New frmxxCM01A0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM01A0.Instance = Nothing
                '@引継ぎｷｬﾘｱ情報の復元
                ptypCommonInfo = ltypOldCommonInfo
                Exit Sub
            End If
            '@子画面起動
            frmxxCM01A0.Instance.ShowDialog(Me)
            frmxxCM01A0.Instance = Nothing
            '@ﾛｯﾄ情報変更・削除(初期化)
            pblnfrmxxCM01A0Kbn = False
            
        '@↑2007/10/12 (Fri) 16:44:30 N.Kasai **************************************************

            
            
        '''    '@Form_Loadﾌﾗｸﾞ(異常)
        '''    pblnFormLoad = False
            
        '''    '@投入予定ﾛｯﾄ変更/削除
        '''    pblnfrmxxCM00W0Kbn = True
        '''
        '''    '@子画面をﾛｰﾄﾞ
        '''    Load frmxxCM00W0
        '''
        '''    '@ﾒﾆｭｰｷｰから機能の関連情報を取得する
        '''    Call pubMenuItemCorrelation_Set(CPstrKeyEN01R0, lstrTitle)
        '''
        '''    '@投入予定ﾛｯﾄ変更/削除
        '''    frmxxCM00W0.Caption = lstrTitle
        '''
        '''    '@Form_Loadﾌﾗｸﾞが異常の場合
        '''    If pblnFormLoad = False Then
        '''        '@異常の場合は子画面終了
        '''        Unload frmxxCM00W0
        '''
        '''        '@引継ぎｷｬﾘｱ情報の復元
        '''        ptypCommonInfo = ltypOldCommonInfo
        '''
        '''        Exit Sub
        '''    End If
        '''
        '''    '@子画面起動
        '''    Call frmxxCM00W0.Show(vbModal)

        '''        pblnfrmxxCM00W0Kbn = False

            '@引継ぎｷｬﾘｱ情報の復元
            ptypCommonInfo = ltypOldCommonInfo
            
            '@最新情報を取得し直す
            Call cmdLotSearch_Click(cmdLotSearch, New EventArgs)
            
            '@ｸﾞﾘｯﾄﾞが有効か
            If vsfResvLotList.Enabled = True Then
                '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfResvLotList)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdChangePlan_Click"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotSearch_Click
    '機　能：投入予定一覧検索
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:58:24 M.Miura
    '更新日：2004/07/15 (Thu) 18:23:10 N.Kojima
    '備　考：
    Private Sub cmdLotSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotSearch.Click

        Dim lblnAns             As Boolean      '戻り値

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "cmdLotSearch_Click"
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@投入予定一覧検索
            lblnAns = prvblnlotrlst_Sel()
            '@結果判定
            If lblnAns = False Then
                '@ｴﾗｰの場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)

                '@ｸﾞﾘｯﾄﾞ表示の初期化
                Call prvvsfResvLotList_init()

                'NSYS 予定変更ボタンを無効にする
                cmdChangePlan.Enabled = False

                Exit Sub
            End If
            
            '@退避領域へ種別ID一覧を格納
            mstrTaihiClassName = cmbClassName.Value

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, mstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdLotSearch_Click"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbClassName_Change
    '機　能：種別変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 14:04:25 Y.Yamagishi
    '更新日：2005/08/17 (Wed) 15:34:15 N.Kojima
    '備　考：
    '　　　：2004/10/15 (Fri) 10:55:18 M.Miura　    ｶﾚﾝﾄ行検索ｷｰ初期化を追加
    '　　　：2005/08/17 (Wed) 15:34:15 N.Kojima     投入予定ﾛｯﾄ変更/削除からの戻りの場合は、ｶﾚﾝﾄ行の検索ｷｰを初期化しない。(不具合№2946)
    Private Sub cmbClassName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbClassName.Change
        
        Try
            
            'NSYS 種別変更フラグ設定
            mblnCmdClassNameChanged = True

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = Nothing
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰ,退避用を初期化
                .strKey = vbNullString
                pstrChgSort = vbNullString
            End With

            '@画面初期化
            Call prvfrmxxCM0090_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbClassName_Change"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbClassName_CloseUp
    '機　能：種別のCloseUp
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 14:04:55 Y.Yamagishi
    '更新日：2004/07/06 (Tue) 14:04:55
    '備　考：
    Private Sub cmbClassName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbClassName.CloseUp
        
        Try

            '@cmbClassNameのValidateｲﾍﾞﾝﾄ呼び出す
            RemoveHandler cmbClassName.Validating, AddressOf cmbClassName_Validate
            Call cmbClassName_Validate(cmbClassName, New CancelEventArgs)
            AddHandler cmbClassName.Validating, AddressOf cmbClassName_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbClassName_CloseUp"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbClassName_Validate
    '機　能：種別のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 14:05:12 Y.Yamagishi
    '更新日：2004/07/06 (Tue) 14:05:12
    '備　考：
    Private Sub cmbClassName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbClassName.Validating
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            'NSYS 種別変更フラグ確認
            If mblnCmdClassNameChanged = False Then
                Exit Sub
            Else
                mblnCmdClassNameChanged = False
            End If

            '@種別の選択状況による処理分岐
            '@種別選択がされていない,「0 項目選択」の場合
            If cmbClassName.Text = vbNullString Or _
               cmbClassName.Text = CMstrCmbAddedCommentNone Then
                '@画面初期化
                Call prvfrmxxCM0090_Init()
                '@ﾛｯｸ
                cmdLotSearch.Enabled = False
                Exit Sub
            Else
            '@種別選択がされている場合
                '@ﾛｯｸ解除
                cmdLotSearch.Enabled = True
                
                '@種別選択で内容が変更されていない場合
                If cmbClassName.Value = mstrTaihiClassName Then
                    '@次項目へｾｯﾄﾌｫｰｶｽ
                    Exit Sub
                End If
                    
                '@最新情報取得(投入予定一覧)処理へ
                Call cmdLotSearch_Click(cmdLotSearch, New EventArgs)
                
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbClassName_Validate"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUP_Click
    '機　能：前ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/02 (Tue) 09:24:33 M.Miura
    '更新日：2004/03/02 (Tue) 09:24:33
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
            Call pubVsfCmdUp(vsfResvLotList, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
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
    '機　能：次ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/02 (Tue) 09:34:18 M.Miura
    '更新日：2004/03/02 (Tue) 09:34:18
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
            Call pubVsfCmdDown(vsfResvLotList, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdDown_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfResvLotList_AfterSort
    '機　能：ソート後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 15:07:53 M.Miura
    '更新日：2004/10/15 (Fri) 10:56:06 M.Miura
    '備　考：
    '　　　：2004/10/15 (Fri) 10:56:06 M.Miura　    ｿｰﾄ順の格納を追加
    Private Sub vsfResvLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfResvLotList.AfterSort
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfResvLotList.Rows.Count <= vsfResvLotList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If

                Dim ltypChgSortListTmp As ChgSortList
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                '@ｿｰﾄ列番号を格納
                ltypChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納(昇順/降順)
                ltypChgSortListTmp.lngOrder = e.Order

                .typChgSortList.Add(ltypChgSortListTmp)
            End With

            '@ｶﾚﾝﾄ行の設定(ｸﾞﾘｯﾄﾞ、保持列 [ 投入予定日、ﾛｯﾄID ]、前頁、次頁 )
            Call pubVsfAfterSort(vsfResvLotList, _
                                 CMvsfResvLotListColPlanThrowinDate & vbTab & CMvsfResvLotListColLotID, _
                                 cmdUP, _
                                 cmdDown)
            
            'NSYS ソート時にBeforeRowColChangeイベントが発生し、検索キー mtypChgSort.strKey
            'NSYS および 確定ﾎﾞﾀﾝcmdChoice.Enabled が設定されるのを避けるため
            'NSYS 元に戻す
            AddHandler vsfResvLotList.BeforeRowColChange, AddressOf vsfResvLotList_BeforeRowColChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfResvLotList_AfterSort"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfResvLotList_BeforeSort
    '機　能：ソート前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 15:02:56 M.Miura
    '更新日：2004/04/14 (Wed) 15:02:56
    '備　考：
    Private Sub vsfResvLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfResvLotList.BeforeSort
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfResvLotList.Rows.Count <= vsfResvLotList.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列 [ 投入予定日、ﾛｯﾄID ] )
            Call pubVsfBeforeSort(vsfResvLotList, _
                                  CMvsfResvLotListColPlanThrowinDate & vbTab & CMvsfResvLotListColLotID)
            
            'NSYS ソート時にBeforeRowColChangeイベントが発生し、検索キー mtypChgSort.strKey
            'NSYS および 確定ﾎﾞﾀﾝcmdChoice.Enabled が設定されるのを避けるため
            RemoveHandler vsfResvLotList.BeforeRowColChange, AddressOf vsfResvLotList_BeforeRowColChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfResvLotList_BeforeSort"  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfResvLotList_BeforeRowColChange
    '機　能：行列変更前処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙt値
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 10:57:09 M.Miura
    '更新日：2007/08/21 (Tue) 11:44:58 N.Kasai
    '備　考：
    '　　　：2005/08/09 (Tue) 12:15:09 N.Kojima     選択行が"PR/ES"かの判定を追加等。(不具合№2946)
    '　　　：2006/01/11 (Wed) 10:26:16 T.Kitagawa   ﾕｰｻﾞｰ要望№0134に伴い、種別がESの場合は予定変更可能とする
    '　　　：2006/09/14 (Thu) 11:47:35 N.Kojima     "PR"ﾛｯﾄ選択時も予定変更ﾎﾞﾀﾝを押下可能とする。(案件№01452)
    '　　　：2007/08/21 (Tue) 11:44:58 N.Kasai      №02119
    Private Sub vsfResvLotList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfResvLotList.BeforeRowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfResvLotList.Rows.Count <= vsfResvLotList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
            '@投入予定日が変更出来るようになったので、検索ｷｰはﾛｯﾄIDのみ
                
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ﾛｯﾄID)
                mtypChgSort.strKey = vsfResvLotList.GetData(e.NewRange.r1, CMvsfResvLotListColLotID)
                                     
                With cmdChoice
                    '@確定ﾎﾞﾀﾝが表示されていて無効の場合
                    If .Visible = True And .Enabled = False Then
                        '@確定ﾎﾞﾀﾝを有効
                        .Enabled = True
                    End If
                End With
            End If

        '@↓2007/08/21 (Tue) 11:30:12 N.Kasai **************************************************
        '    With vsfResvLotList
        '        '@ﾘｽﾄｶｳﾝﾄが1件以上存在する場合
        '        If .Rows > 1 Then
        '            '@予定変更ﾎﾞﾀﾝを有効
        '            cmdChangePlan.Enabled = True
        '        Else
        '            '@予定変更ﾎﾞﾀﾝを無効
        '            cmdChangePlan.Enabled = False
        '        End If
        '    End With
        '@↑2007/08/21 (Tue) 11:30:12 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                     '機能ID
                .strProcName = "vsfResvLotList_BeforeRowColChange"  '処理名
                .strErrMessage = vbNullString                       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfResvLotList_DblClick
    '機　能：ﾛｯﾄ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 12:30:35 M.Miura
    '更新日：2007/08/21 (Tue) 11:18:42 N.Kasai
    '備　考：
    '　　　：2005/08/09 (Tue) 11:37:09 N.Kojima     確定ﾎﾞﾀﾝが非表示の場合は、DblClickで「予定変更」処理を呼ぶ。(不具合№2946)
    '　　　：2006/01/11 (Wed) 10:28:02 T.Kitagawa   ﾕｰｻﾞｰ要望№0134に伴い、種別がESの場合は予定変更可能とする
    '　　　：2006/09/14 (Thu) 11:49:08 N.Kojima     "PR"ﾛｯﾄﾀﾞﾌﾞﾙｸﾘｯｸ処理時でも「投入予定ﾛｯﾄ変更/削除」画面を起動する。(案件№01452)
    '　　　：2007/08/21 (Tue) 11:18:42 N.Kasai      №02119
    Private Sub vsfResvLotList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfResvLotList.DoubleClick
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfResvLotList.Rows.Count <= vsfResvLotList.Rows.Fixed Then
                Return
            End If

            With vsfResvLotList
        '@↓2007/08/21 (Tue) 11:18:38 N.Kasai **************************************************
                '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
                If .MouseRow <= 0 Then
                    Exit Sub
                '@最終余白部分ｸﾘｯｸ
                ElseIf .MouseRow > .Rows.Count - 1 Then
                    Exit Sub
                End If
                '@該当行が未選択
                If .Row < 1 Then
                    Exit Sub
                End If
            
                '@確定ﾎﾞﾀﾝが表示されている場合
                If cmdChoice.Visible = True Then
                    '@選択確定
                    Call cmdChoice_Click(cmdChoice, New EventArgs)
                Else
                    '@予定変更ﾎﾞﾀﾝ押下処理をCALL
                    Call cmdChangePlan_Click(cmdChangePlan, New EventArgs)
                End If
        '@↑2007/08/21 (Tue) 11:18:38 N.Kasai **************************************************
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfResvLotList_DblClick"    '処理名
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

    '関数名：prvfrmxxCM0090_Init
    '機　能：画面初期設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:46:48 M.Miura
    '更新日：2009/02/25 (Wed) 19:33:56 N.Kojima
    '備　考：
    '　　　：2004/08/03 (Tue) 15:58:42 S.Deguchi    画面ｻｲｽﾞがFullに変更によりｽﾀｰﾄ位置を削除
    '　　　：2004/10/04 (Mon) 10:33:23 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2005/08/09 (Tue) 11:21:16 N.Kojima     予定変更ﾎﾞﾀﾝ追加に伴い、初期化処理追加(不具合№2946)
    '　　　：2009/02/25 (Wed) 19:33:56 N.Kojima     ﾁｯﾌﾟ品判別説明ﾗﾍﾞﾙの制御処理追加。(案件№03402)
    Private Sub prvfrmxxCM0090_Init()

        Dim lstrFormTitle           As String   'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00P0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
                
            '@情報取得日時初期化
            lblNowDate.Text = vbNullString
                
            '@該当件数ｸﾘｱ
            lblLotCnt.Text = vbNullString
                        
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
                lblTitleChip.Visible = True                 'ﾁｯﾌﾟ品説明
                lblTFT.Visible = False
                lblCF.Visible = False

            '@1A0：基板の場合
            ElseIf pstrSBID = CPstrSBID1A0 Then
                lblTFT.BackColor = ColorTranslator.FromWin32(CPlngLColor)
                lblCF.BackColor = ColorTranslator.FromWin32(CPlngRColor)
                lblTitleL.Visible = False
                lblTitleR.Visible = False
                lblTitleChip.Visible = False                'ﾁｯﾌﾟ品説明
                lblTFT.Visible = True
                lblCF.Visible = True
                
            Else
                lblTitleL.Visible = False
                lblTitleR.Visible = False
                lblTitleChip.Visible = False                'ﾁｯﾌﾟ品説明
                lblTFT.Visible = False
                lblCF.Visible = False
            End If
                
            '@各種ｺﾝﾄﾛｰﾙを無効に
            cmdUP.Enabled = False                           '前ﾍﾟｰｼﾞ
            cmdDown.Enabled = False                         '次ﾍﾟｰｼﾞ
            cmdChoice.Enabled = False                       '選択確定
            cmdChangePlan.Enabled = False                   '予定変更
            
            '@選択種別ID退避領域ｸﾘｱ
            mstrTaihiClassName = vbNullString

            If mblnCmdClassNameChanged = False Then
                '@ｸﾞﾘｯﾄﾞ表示の初期化
                Call prvvsfResvLotList_init()
            End If
            
            '@閉じるのCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM0090_Init"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfResvLotList_init
    '機　能：vsfResvLotListの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/23 (Mon) 10:51:38 M.Miura
    '更新日：2008/06/10 (Tue) 17:14:02 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 17:14:02 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvvsfResvLotList_init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfResvLotList
                '@描画ﾛｯｸ
                .Redraw = False

                '@ｸﾞﾘｯﾄﾞの行設定
                .Rows.Count = CMvsfResvLotListTRow + 1

                .Row = -1

                '@ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMvsfResvLotListColm
                
                '@投入日を日付ﾀｲﾌﾟに設定
                .Cols(CMvsfResvLotListColPlanThrowinDate).DataType = GetType(DateTime)
                .Cols(CMvsfResvLotListColWfNum).DataType = GetType(Int32)

                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.None
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                With .Font                                            'ﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMvsfResvLotListHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                lFixedStyle.ForeColor = Color.Yellow                   '文字色
                lFixedStyle.BackColor = Color.Navy                     '背景色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter     '配置
                lFixedStyle.Trimming  = StringTrimming.None            'NSYS ﾍｯﾀﾞは省略表示なしに設定
                
                .Cols(CMvsfResvLotListColPlanThrowinDate).TextAlign = TextAlignEnum.LeftCenter     '投入予定日(左中央寄せ)
                .Cols(CMvsfResvLotListColPdID).TextAlign = TextAlignEnum.LeftCenter                '機種(左中央寄せ)
                .Cols(CMvsfResvLotListColLotID).TextAlign = TextAlignEnum.LeftCenter               'ﾛｯﾄID(左中央寄せ)
                .Cols(CMvsfResvLotListColFlowClass).TextAlign = TextAlignEnum.LeftCenter           '種別(左中央寄せ)
                .Cols(CMvsfResvLotListColWfNum).TextAlign = TextAlignEnum.RightCenter              'WF枚数(右中央寄せ)
                .Cols(CMvsfResvLotListColLotManagerName).TextAlign = TextAlignEnum.LeftCenter      'ﾛｯﾄ担当(左中央寄せ)
                .Cols(CMvsfResvLotListColLotManagerID).TextAlign = TextAlignEnum.LeftCenter        'ﾛｯﾄ担当者ｺｰﾄﾞ(左中央寄せ)
                '@↓2019/12/19 (Thu) 18:46:06 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMvsfResvLotListColGRB).TextAlign = TextAlignEnum.LeftCenter                 'GRB(左中央寄せ)
                '@↑2019/12/19 (Thu) 18:46:06 Y.Yoneyama 「.Netへ反映未」 **************************************************
                '@↓2020/03/24 (Tue) 10:48:30 T.Oide 「.Netへ反映未」 **************************************************
                .Cols(CMvsfResvLotListColLMSFlag).TextAlign = TextAlignEnum.LeftCenter             'ﾚｰｻﾞｰﾏｰｶｽｷｯﾌﾟﾌﾗｸﾞ(左中央寄せ)
                '@↑2020/03/24 (Tue) 10:48:30 T.Oide 「.Netへ反映未」 **************************************************

                '@列幅設定
                .Cols(CMvsfResvLotListColNo).Width = CMvsfResvLotListColWNo
                .Cols(CMvsfResvLotListColPdID).Width = CMvsfResvLotListColWPdID
                .Cols(CMvsfResvLotListColLotID).Width = CMvsfResvLotListColWLotID
                .Cols(CMvsfResvLotListColFlowClass).Width = CMvsfResvLotListColWFlowClass
                .Cols(CMvsfResvLotListColPlanThrowinDate).Width = CMvsfResvLotListColWPlanThrowinDate
                .Cols(CMvsfResvLotListColWfNum).Width = CMvsfResvLotListColWWfNum
                .Cols(CMvsfResvLotListColLotManagerName).Width = CMvsfResvLotListColWLotManagerName
                '@↓2019/12/19 (Thu) 18:46:30 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMvsfResvLotListColGRB).Width = CMvsfResvLotListColWGRB
                '@↑2019/12/19 (Thu) 18:46:30 Y.Yoneyama 「.Netへ反映未」 **************************************************
                '@↓2020/03/24 (Tue) 10:49:35 T.Oide 「.Netへ反映未」 **************************************************
                .Cols(CMvsfResvLotListColLMSFlag).Width = CMvsfResvLotListColWLMSFlag
                '@↑2020/03/24 (Tue) 10:49:35 T.Oide 「.Netへ反映未」 **************************************************
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMvsfResvLotListTRow, CMvsfResvLotListColNo, CMvsfResvLotListColTNo)
                .SetData(CMvsfResvLotListTRow, CMvsfResvLotListColPdID, CMvsfResvLotListColTPdID)
                .SetData(CMvsfResvLotListTRow, CMvsfResvLotListColLotID, CMvsfResvLotListColTLotID)
                .SetData(CMvsfResvLotListTRow, CMvsfResvLotListColFlowClass, CMvsfResvLotListColTFlowClass)
                .SetData(CMvsfResvLotListTRow, CMvsfResvLotListColPlanThrowinDate, CMvsfResvLotListColTPlanThrowinDate)
                .SetData(CMvsfResvLotListTRow, CMvsfResvLotListColWfNum, CMvsfResvLotListColTWfNum)
                .SetData(CMvsfResvLotListTRow, CMvsfResvLotListColLotManagerName, CMvsfResvLotListColTLotManagerName)
                '@↓2019/12/19 (Thu) 18:46:55 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .SetData(CMvsfResvLotListTRow, CMvsfResvLotListColGRB, CMvsfResvLotListColTGRB)
                '@↑2019/12/19 (Thu) 18:46:55 Y.Yoneyama 「.Netへ反映未」 **************************************************
                '@↓2020/03/24 (Tue) 10:50:20 T.Oide 「.Netへ反映未」 **************************************************
                .SetData(CMvsfResvLotListTRow, CMvsfResvLotListColLMSFlag, CMvsfResvLotListColTLMSFlag)
                '@↑2020/03/24 (Tue) 10:50:20 T.Oide 「.Netへ反映未」 **************************************************
                
                '@隠しCol設定
                .Cols(CMvsfResvLotListColLotManagerID).Visible = False          'ﾛｯﾄ担当者ID(非表示)
                .Cols(CMvsfResvLotListColPdVersion).Visible = False             'PDﾊﾞｰｼﾞｮﾝ(非表示)
                '@↓2020/03/24 (Tue) 10:50:59 T.Oide 「.Netへ反映未」 **************************************************
                .Cols(CMvsfResvLotListColLMSFlag).Visible = False               'ﾚｰｻﾞｰﾏｰｶｽｷｯﾌﾟﾌﾗｸﾞ(非表示)
                '@↑2020/03/24 (Tue) 10:50:59 T.Oide 「.Netへ反映未」 **************************************************
                
                '@行の高さ設定
                .Rows(CMvsfResvLotListTRow).Height = CMvsfResvLotListHdHeight            'ﾍｯﾀﾞｰ
                
                '@描画ﾛｯｸ解除
                .Redraw = True
                
                '@ﾛｯｸ
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfResvLotList_init"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfResvLotList_Disp
    '機　能：取得した投入予定ﾛｯﾄ一覧表示
    '引　数：ltypLotRlst()  ：投入予定ﾛｯﾄ一覧が格納された構造体
    '　　　：llngcnt        ：構造体の配列の数
    '戻り値：なし
    '作成日：2004/03/01 (Mon) 16:19:28 M.Miura
    '更新日：2009/12/01 (Tue) 20:15:18 H.Hayashi
    '備　考：
    '　　　：2004/10/15 (Fri) 11:09:25 M.Miura　    ｿｰﾄ順の保持表示、ｶﾚﾝﾄ行設定を追加
    '　　　：2004/10/18 (Mon) 14:41:46 Y.Yamagishi  0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    '　　　：2008/06/10 (Tue) 17:16:58 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/25 (Wed) 11:52:25 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。(案件№03402)
    '　　　：2009/12/01 (Tue) 20:15:18 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    Private Sub prvvsfResvLotList_Disp(ByRef ltypLotRlst As List(Of typLotRlst), ByVal llngCnt As Integer)

        Dim llngDoCnt       As Integer      'Doの回数ｶｳﾝﾄ
        Dim newStyle        As CellStyle    'NSYS セルスタイル
        Dim cellRange       As CellRange    'NSYS セルレンジ
        Dim llngListCnt     As Integer      'NSYS リストのカウント
        Dim lblnRowSelected As Boolean      'NSYS 行選択がある場合 True

        Try
            
            '@変数初期化
            llngDoCnt = 1
            
            '@一覧表示
            With vsfResvLotList
                
                '@描画ﾛｯｸ
                .Redraw = False

                'NSYS BeforeRowColChangeイベントを抑止し、ボタンの状態変更やｿｰﾄ検索用ｷｰ設定を抑える
                RemoveHandler vsfResvLotList.BeforeRowColChange, AddressOf vsfResvLotList_BeforeRowColChange

                'NSYS クリア
                .Row = -1
                .Rows.Count = .Rows.Fixed

                '行設定
                .Rows.Count = llngCnt + 1
                
                '@一覧表示
                Do While .Rows.Count > llngDoCnt
                    llngListCnt = llngDoCnt - 1
                    .SetData(llngDoCnt, CMvsfResvLotListColLotID, _
                        ltypLotRlst(llngListCnt).strLotID)                                  'ﾛｯﾄID
                    .SetData(llngDoCnt, CMvsfResvLotListColFlowClass, _
                        ltypLotRlst(llngListCnt).strFlowClass)                              '種別ID
                    .SetData(llngDoCnt, CMvsfResvLotListColPlanThrowinDate, _
                        CDate(ltypLotRlst(llngListCnt).strPlanThrowinDate))                 '投入予定日
                    .SetData(llngDoCnt, CMvsfResvLotListColWfNum, _
                        ltypLotRlst(llngListCnt).strWfNum)                                  'WF枚数
                    .SetData(llngDoCnt, CMvsfResvLotListColLotManagerName, _
                        ltypLotRlst(llngListCnt).strEngEmpName)                             'ﾛｯﾄ担当者名
                    .SetData(llngDoCnt, CMvsfResvLotListColLotManagerID, _
                        ltypLotRlst(llngListCnt).strEngEmpId)                               'ﾛｯﾄ担当者ID
                    .SetData(llngDoCnt, CMvsfResvLotListColPdID, _
                        ltypLotRlst(llngListCnt).strPdId)                                   '機種ID
                    .SetData(llngDoCnt, CMvsfResvLotListColPdVersion, _
                        ltypLotRlst(llngListCnt).strMasVer)                                 'PDﾊﾞｰｼﾞｮﾝ
                    .SetData(llngDoCnt, CMvsfResvLotListColGRB, _
                        ltypLotRlst(llngListCnt).strGRBClass)                                 'GRB
                    .SetData(llngDoCnt, CMvsfResvLotListColLMSFlag, _
                        ltypLotRlst(llngListCnt).strLaserMarkerSkipFlag)                      'ﾚｰｻﾞｰﾏｰｶｽｷｯﾌﾟﾌﾗｸﾞ                       

                    '@L/Rによる文字色変更
                    Select Case ltypLotRlst(llngListCnt).strLcDirection
                        Case CPstrPDIDL
                             '@ｾﾙ背景色変更
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngLColor)                     'Lｶﾗｰ(水色)
                            cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        Case CPstrPDIDR
                             '@ｾﾙ背景色変更
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngRColor)                     'Rｶﾗｰ(ﾋﾟﾝｸ)
                            cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        Case Else
                            '@ｾﾙ背景色変更
                            newStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White                                                '初期(白)
                            cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                    End Select
                    
                    '@GRB背景色
                    newStyle = .Styles.Add("GRBColor" + llngDoCnt.ToString)
                    newStyle.BackColor = pubGRBBackColor(ltypLotRlst(llngListCnt).strGRBClass, .GetCellStyle(llngDoCnt, CMvsfResvLotListColLotID).BackColor)
                    cellRange = .GetCellRange(llngDoCnt, CMvsfResvLotListColGRB)
                    cellRange.Style = newStyle

                    If pstrSBID = CPstrSBID1A0
                        If ltypLotRlst(llngListCnt).strFlowClass = CPstrFlowClassPR Or _
                            ltypLotRlst(llngListCnt).strFlowClass = CPstrFlowClassES Then

                            '量産品の場合TFT/対向基板で色変更
                            If ltypLotRlst(llngListCnt).strCFFlag = CPstrFlagOff  Then
                                '@ｾﾙ背景色変更
                                newStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngLColor)                     '水色
                                cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle
                            ElseIf ltypLotRlst(llngListCnt).strCFFlag = CPstrFlagOn  Then
                                '@ｾﾙ背景色変更
                                newStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngRColor)                     'ﾋﾟﾝｸ
                                cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle
                            Else
                                '@ｾﾙ背景色変更
                                newStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                                newStyle.BackColor = Color.White                                                '初期(白)
                                cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle
                            End If
                        Else
                            '@ｾﾙ背景色変更
                            newStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White                                                '初期(白)
                            cellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        End If
                    End If

                    '@-----------------------------------------------
                    '@ ﾌｫﾝﾄ色の設定(組立限定機能)
                    '@　①ﾁｯﾌﾟ品LOT：青色
                    '@-----------------------------------------------
                    If pstrSBID = CPstrSBID2A0 And _
                        ltypLotRlst(llngListCnt).strSbArea = CPstrProductChip Then
                        
                        '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
                        '@文字色を青色に変更
                        Select Case ltypLotRlst(llngListCnt).strLcDirection
                            Case CPstrPDIDL
                                 '@ｾﾙ背景色変更
                                newStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor_ForeColor_vbBlue")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngLColor)                     'Lｶﾗｰ(水色)
                                newStyle.ForeColor = Color.Blue
                                cellRange = .GetCellRange(llngDoCnt, CMvsfResvLotListColNo, _
                                                          llngDoCnt, CMvsfResvLotListColPdVersion)
                                cellRange.Style = newStyle
                            Case CPstrPDIDR
                                 '@ｾﾙ背景色変更
                                newStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor_ForeColor_vbBlue")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngRColor)                     'Rｶﾗｰ(ﾋﾟﾝｸ)
                                newStyle.ForeColor = Color.Blue
                                cellRange = .GetCellRange(llngDoCnt, CMvsfResvLotListColNo, _
                                                          llngDoCnt, CMvsfResvLotListColPdVersion)
                                cellRange.Style = newStyle
                            Case Else
                                '@ｾﾙ背景色変更
                                newStyle = .Styles.Add("CustomStyle_BackColor_vbWhite_ForeColor_vbBlue")
                                newStyle.BackColor = Color.White                                                '初期(白)
                                newStyle.ForeColor = Color.Blue
                                cellRange = .GetCellRange(llngDoCnt, CMvsfResvLotListColNo, _
                                                          llngDoCnt, CMvsfResvLotListColPdVersion)
                                cellRange.Style = newStyle
                        End Select
                        
                    End If
                    
                    '@ｶｳﾝﾀｱｯﾌﾟ
                    llngDoCnt = llngDoCnt + 1
                Loop

                If .Rows.Count > 1 Then

                    Dim laryColSort(CMvsfResvLotListColLotID)   As SortFlags
                    Dim llngColCnt                              As Integer

                    'NSYS 前回の「投入予定日」～「ﾛｯﾄID」列ごとのソート状態を保存
                    For llngColCnt = CMvsfResvLotListColPlanThrowinDate To CMvsfResvLotListColLotID
                        laryColSort(llngColCnt) = .Cols(llngColCnt).Sort
                    Next

                    'NSYS ソートの操作によりカラムのソート情報が変更されている場合があるためリセットする
                    .Cols(CMvsfResvLotListColPlanThrowinDate).Sort = SortFlags.Ascending     '投入予定日：昇順
                    .Cols(CMvsfResvLotListColPdID).Sort = SortFlags.None                     '機種ID：なし
                    .Cols(CMvsfResvLotListColLotID).Sort = SortFlags.Ascending               'ﾛｯﾄID：昇順

                    '@投入予定日の降順に並替え
                    .Sort(SortFlags.UseColSort, CMvsfResvLotListColPlanThrowinDate, CMvsfResvLotListColLotID)
                    'NSYS VB6に合わせソートインジケーターを消すため
                    .Sort(SortFlags.None, CMvsfResvLotListColPlanThrowinDate, CMvsfResvLotListColLotID)
                    
                    'NSYS 前回の列ごとのソート状態を復元
                    For llngColCnt = CMvsfResvLotListColPlanThrowinDate To CMvsfResvLotListColLotID
                        .Cols(llngColCnt).Sort = laryColSort(llngColCnt)
                    Next

                    'NSYS 「No.」列初回ソート時は常に昇順ソートされるため、ソート情報をリセットする
                    .Cols(CMvsfResvLotListColNo).Sort = SortFlags.None                       'No.：なし

                Else
                    '@ﾛｯｸ
                    cmdChoice.Enabled = False
                    '@情報取得日時表示
                    lblNowDate.Text = Format$(Now, CPstrDateFormat)
                    '@該当ﾃﾞｰﾀが存在しない場合
                    lblLotCnt.Text = 0
                End If

                '@№設定
                For llngDoCnt = 1 To .Rows.Count - 1
                    .SetData(llngDoCnt, CMvsfResvLotListColNo, llngDoCnt)
                Next llngDoCnt
                
                '@行の高さ設定
                .Rows.DefaultSize = CMvsfResvLotListHeight                        '表全体
                .Rows(CMvsfResvLotListTRow).Height = CMvsfResvLotListHdHeight     'ﾍｯﾀﾞｰ
                
                If .Rows.Count > 1 Then
                
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                            '@該当行をｿｰﾄ
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    'NSYS 行選択ない設定で初期化
                    lblnRowSelected = False
                    
                    '@ｿｰﾄ検索用ｷｰがある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ﾛｯﾄIDが同じ場合
                            If .GetData(llngCnt, CMvsfResvLotListColLotID) = mtypChgSort.strKey Then
                                '@行設定
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列 [ 投入予定日、ﾛｯﾄID ] )
                                Call pubVsfBeforeSort(vsfResvLotList, _
                                                      CMvsfResvLotListColPlanThrowinDate & vbTab & CMvsfResvLotListColLotID)
                                                      
                                '@ｶﾚﾝﾄ行の設定(ｸﾞﾘｯﾄﾞ、保持列 [ 投入予定日、ﾛｯﾄID ]、前頁、次頁 )
                                Call pubVsfAfterSort(vsfResvLotList, _
                                                     CMvsfResvLotListColPlanThrowinDate & vbTab & CMvsfResvLotListColLotID, _
                                                     cmdUP, _
                                                     cmdDown)
                                
                                'NSYS 行選択あり
                                lblnRowSelected = True
                                Exit For
                            End If
                        Next llngCnt
                    End If

                    'NSYS 行選択ない場合
                    If lblnRowSelected = False Then
                        '@ｶﾚﾝﾄ行初期化
                        .Row = .Rows.Fixed - 1
                        .TopRow = .Rows.Fixed

                        'NSYS BeforeRowColChangeイベントを抑止しているので、ここで設定する
                        cmdChoice.Enabled = False
                        cmdChangePlan.Enabled = False
                    End If
                End If
                
                '@ｶﾚﾝﾄ列初期化
                .Col = .Cols.Fixed
                
                '@前ﾍﾟｰｼﾞ、次ﾍﾟｰｼﾞ、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                If .Rows.Count > CMvsfResvLotListRows Then
                    cmdUP.Enabled = True
                    cmdDown.Enabled = True
                Else
                    cmdUP.Enabled = False
                    cmdDown.Enabled = False
                End If
                
                '@情報取得日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                '@該当件数設定
                lblLotCnt.Text = Format$(.Rows.Count - 1, CPstrDateFormatKanma)
                
                '@描画ﾛｯｸ解除
                .Redraw = True
                
                'NSYS イベントハンドラーを元に戻す
                AddHandler vsfResvLotList.BeforeRowColChange, AddressOf vsfResvLotList_BeforeRowColChange
                
                '@ﾛｯｸ解除
                .Enabled = True
            
                '@ﾌｫｰﾑが表示されている場合
                If .Visible = True And .Rows.Count > 1 Then
                    RemoveHandler cmbClassName.Validating, AddressOf cmbClassName_Validate
                    '@表にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfResvLotList)
                    AddHandler cmbClassName.Validating, AddressOf cmbClassName_Validate
                End If
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfResvLotList_Disp"     '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvblnlotrlst_Sel
    '機　能：投入予定ﾛｯﾄ一覧検索
    '引　数：True：正常、False：異常
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 17:00:16 M.Miura
    '更新日：2004/09/06 (Mon) 09:25:26 H.Wajima
    '備　考：
    '　　　：2004/09/06 (Mon) 09:25:26 H.Wajima     ﾒﾓﾘﾘｰｸ対策修正
    '　　　：2004/09/15 (Wed) 16:46:55 S.Deguchi    構造体のｸﾘｱ処理追加
    '　　　：2004/09/16 (Thu) 13:21:01 S.Deguchi    件数取得処理修正
    Private Function prvblnlotrlst_Sel() As Boolean

        Dim llngCnt                 As Integer              'ｶｳﾝﾀ変数
        Dim llngcFlowClassCnt       As Integer              '種別配列ｶｳﾝﾄ
        Dim ltypLotRlst             As List(Of typLotRlst)  '投入予定ﾛｯﾄ一覧格納用の構造体
        Dim ltypLotresvlist         As Lotresvlist          '投入予定一覧取得格納用の構造体
        Dim lstrTemp()              As String               '一時保管用変数
        Dim lblnAns                 As Boolean              '戻り値

        Try
            
            '@初期化
            prvblnlotrlst_Sel = False
            
            '@投入予定ﾛｯﾄ変更/削除から戻った場合
            If pblnfrmxxCM01A0Kbn = True Then
        '    If pblnfrmxxCM00W0Kbn = True Then
            
                '@ｺﾝﾎﾞに前回選択件数格納
                cmbClassName.Text = plngFlowClass & CMstrCmbAddedComment
                '@引継ぎ区分を初期化
                pblnfrmxxCM01A0Kbn = False
        '        pblnfrmxxCM00W0Kbn = False

            Else
                '@Public変数の初期化
                plngFlowClass = 0                               '選択件数
                Erase pstrFlowClassList                         '選択種別
            End If
            
            '@種別が空欄,「0 項目選択」の場合
            If cmbClassName.Text = vbNullString Or _
                    cmbClassName.Text = CMstrCmbAddedCommentNone Then
                '@"<TRM18W>$$装置名が設定されていません。設定を見直してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0018)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Function
            Else
                '@種別が選択されている場合
                '@種別別在庫ﾛｯﾄ一覧取得
                llngcFlowClassCnt = cmbClassName.ValueCount     '選択件数の取得
                
                '@投入予定一覧取得ﾃﾞｰﾀ作成
                With ltypLotresvlist
                    '@構造体のｸﾘｱ
                    .typFlowClassList = New List(Of FlowClassList)(llngcFlowClassCnt)
                                
                    '@選択項目数が0以上の場合,引数設定
                    If llngcFlowClassCnt > 0 Then
                        '@選択種別取得
                        lstrTemp = Split(cmbClassName.Value, vbTab)
                        For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)
                            Dim ltypFlowClassListTmp As FlowClassList
                            '@種別にﾁｪｯｸが付いている場合
                            ltypFlowClassListTmp.strFlowClass = lstrTemp(llngCnt)     '流動区分(種別)
                            .typFlowClassList.Add(ltypFlowClassListTmp)
                        Next
                        '@処理区分
                        .strClassDivision = pstrfrmxxCM0090Kbn
                        '@ﾛｯﾄID
                        .strLotID = pstrLotID
                    End If
                End With
            End If
                
            '@=======================
            '@ 投入予定ﾛｯﾄ一覧取得結果
            '@=======================
            lblnAns = pubblnLotRsvlist__Sel(CMstrlot_rsvlist_Ver, ltypLotRlst, llngcFlowClassCnt, ltypLotresvlist)
            
            '@結果判定
            If lblnAns = False Then
                '@Form_Loadﾌﾗｸﾞ(異常)
                pblnFormLoad = False
                Exit Function
            Else
                '@Form_Loadﾌﾗｸﾞ(正常)
                pblnFormLoad = True
            End If
            
            '@=======================
            '@ 取得した投入予定ﾛｯﾄ一覧表示
            '@=======================
            Call prvvsfResvLotList_Disp(ltypLotRlst, llngcFlowClassCnt)
            
            '@該当ﾃﾞｰﾀが存在するか
            If vsfResvLotList.Rows.Count > 1 Then
                '@ｸﾞﾘｯﾄﾞﾎﾞﾀﾝ制御、保持値ｸﾘｱ
                Call pubVsfDisp(vsfResvLotList, cmdUP, cmdDown)

            End If

            '@成功を返す
            prvblnlotrlst_Sel = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnlotrlst_Sel"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCmbClassName_Disp
    '機　能：種別ﾘｽﾄ設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 13:50:22 Y.Yamagishi
    '更新日：2005/11/17 (Thu) 15:10:19 N.Kojima
    '備　考：
    '　　　：2005/08/17 (Wed) 10:29:48 N.Kojima     投入予定ﾛｯﾄ変更/削除からの戻り時の設定を行う。(不具合№2946)
    '　　　：2005/11/17 (Thu) 15:10:19 N.Kojima     ﾛｯﾄ編成から起動された場合、試作実験品のみ格納。(ﾕｰｻﾞｰ要望№0114)
    Private Sub prvCmbClassName_Disp()

        Dim llngCnt                 As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngDivCnt              As Integer      '種別ｶｳﾝﾄ
        Dim llngFlowClassCnt        As Integer      '前回選択種別退避領域の文字列長格納用
        Dim lblnCheckFlag           As Boolean      '前回選択種別ﾁｪｯｸﾌﾗｸﾞ

        Try
            
            '@種別ｶｳﾝﾄ初期化
            llngDivCnt = 0
            
            '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)
            With cmbClassName
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .DirectInput = False                        '直接入力(False)
                .SelectMode = CMlngCMbSelectMode            '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                     '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = 1                              '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngDivisionCnt                '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment        '"選択"文字列
                .RowHeight = CMlngCmbRowHeight              'ﾘｽﾄ行の高さ
                With .Font                                  'ﾌｫﾝﾄｻｲｽﾞ
                    cmbClassName.Font = _
                        New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                              'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbClassName.GridFont = _
                        New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngDivisionCnt - 1
                    
                    '@EN0120から呼ばれた場合
                    If pblnfrmxxEN0120Kbn = True Then
                        
                        .AddItem(mtypDivisionList(llngCnt).strDivisionID & _
                                 vbTab & _
                                 llngCnt & _
                                 vbTab & vbNullString & vbTab & vbNullString & vbTab & "1")              'ID/Index

                        llngDivCnt = llngDivCnt + 1
                    Else
                        '@親ﾌｫｰﾑから呼ばれている場合には,下記処理(全て選択)を行う
                        If pstrfrmxxCM0090Kbn <> vbNullString Then
                            .AddItem(mtypDivisionList(llngCnt).strDivisionID & _
                                     vbTab & _
                                     llngCnt & _
                                     vbTab & vbNullString & vbTab & vbNullString & vbTab & "1")              'ID/Index

                            llngDivCnt = llngDivCnt + 1
                        Else
                        '@投入予定ﾛｯﾄ変更/削除から戻った場合の処理追加
                            
                            '@投入予定ﾛｯﾄ変更削除から呼ばれた場合
                            If pblnfrmxxCM01A0Kbn = True Then
        '                    If pblnfrmxxCM00W0Kbn = True Then

                                '@前回選択件数分ﾙｰﾌﾟ
                                For llngFlowClassCnt = 0 To UBound(pstrFlowClassList)
                                    '@前回選択種別と同じか
                                    If mtypDivisionList(llngCnt).strDivisionID = pstrFlowClassList(llngFlowClassCnt) Then
                                        '@前回選択あり
                                        lblnCheckFlag = True
                                        Exit For
                                    Else
                                        '@前回選択なし
                                        lblnCheckFlag = False
                                    End If
                                Next llngFlowClassCnt
                                
                                '@ﾁｪｯｸﾌﾗｸﾞがTrueか
                                If lblnCheckFlag = True Then
                                    '@選択状態でﾘｽﾄを作成
                                    .AddItem(mtypDivisionList(llngCnt).strDivisionID & _
                                             vbTab & _
                                             llngCnt & _
                                             vbTab & vbNullString & vbTab & vbNullString & vbTab & "1")          'ID/Index

                                Else
                                    '@選択なしでﾘｽﾄ作成
                                    .AddItem(mtypDivisionList(llngCnt).strDivisionID & _
                                             vbTab & llngCnt)                                                    'ID/Index
                                End If
                                
                            Else
                                '@自ﾌｫｰﾑ起動の場合には選択処理なしでﾘｽﾄ作成
                                .AddItem(mtypDivisionList(llngCnt).strDivisionID & _
                                         vbTab & llngCnt)                                                        'ID/Index
                            End If
                        End If
                    End If
                Next

                '@親ﾌｫｰﾑから呼ばれている場合には,下記処理(全て選択)を行う
                If pstrfrmxxCM0090Kbn <> vbNullString Then
                    .GroupRows = llngDivCnt                    '行方向のﾚｺｰﾄﾞ数
                    .Text = llngDivCnt & CMstrCmbAddedComment
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvCmbClassName_Disp"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfResvLotList_EnterCell
    '機　能：ｸﾞﾘｯﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/21 (Tue) 11:28:53 N.Kasai
    '更新日：2007/08/21 (Tue) 11:28:53
    '備　考：
    Private Sub vsfResvLotList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfResvLotList.EnterCell


        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfResvLotList.Rows.Count <= vsfResvLotList.Rows.Fixed Then
                Return
            End If

            With vsfResvLotList
                '@ﾘｽﾄｶｳﾝﾄが1件以上存在する場合
                If .Row > 0 Then
                    '@予定変更ﾎﾞﾀﾝを有効
                    cmdChangePlan.Enabled = True
                Else
                    '@予定変更ﾎﾞﾀﾝを無効
                    cmdChangePlan.Enabled = False
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfResvLotList_EnterCell"   '処理名
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
        Const WM_SYSCOMMAND           As Integer  = &H0112
        Const WM_CLOSE                As Integer  = &H0010
        Const WM_ENDSESSION           As Integer  = &H0016
        Const SC_MOVE                 As Long     = &HF010L
        Const SC_CLOSE                As Long     = &HF060L
        Dim   lblnSysCommandScClose   As Boolean = False    'NSYS コントロールメニュー SC_CLOSE処理時 True
        Dim   lblnWMClose             As Boolean  = False   'NSYS WM_CLOSE処理時 True

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
