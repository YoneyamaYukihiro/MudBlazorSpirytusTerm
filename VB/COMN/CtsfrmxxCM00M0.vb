'ﾌｧｲﾙ名：xxCM00M0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：投入予定ロット登録　メインフォーム
'作成日：2004/02/18 (Wed) 13:35:14 M.Miura
'更新日：2014/11/25 (Tue) 09:16:51 T.Oide
'備　考：
'　　　：2005/05/13 (Fri) 10:00:21 S.Deguchi    ATLAS連携対応で量産種別"PR"を表示しない処理を追加
'　　　：2005/12/21 (Wed) 12:07:55 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(ﾕｰｻﾞｰ要望№0134)
'　　　：2008/08/19 (Tue) 10:08:36 M.Koni       CF/TPﾛｯﾄの分割抑制 <案件No.02938>
'　　　：2008/09/03 (Wed) 07:07:53 T.Sawaguchi  工順なしﾌｨｰﾙﾄﾞを削除,異機種間ｺﾋﾟｰを禁止　(案件03141)
'　　　：2008/09/03 (Wed) 11:31:58 T.Sawaguchi  最大WF枚数でﾁｪｯｸ　(案件03044)
'　　　：2008/09/22 (Mon) 06:24:03 T.Sawaguchi  新規登録か、ﾛｯﾄ指定のﾁｪｯｸ追加 (案件No03141)
'　　　：2011/04/27 (Wed) 11:51:34 T.Oide       CHR0001319 QUを組立に送品可能にする
'　　　：2013/11/26 (Tue) 13:56:55 T.Oide       GNS対応(本機能で量産品の登録も可能にする)
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Imports SEComboBoxEx
Public Class frmxxCM00M0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00M0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00M0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00M0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00M0)
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
    '======================================Private===========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2020/03/06 (Fri) 10:49:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion             As String = "12.00"
    Private Const CMstrLocalVersion             As String = "12.01"
    '@↑2020/03/06 (Fri) 10:49:41 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_emplist_Ver          As String = "02.00"     '作業者ﾘｽﾄ取得
    Private Const CMstrmas_flowlistVer          As String = "04.00"     '種別区分一覧取得
    Private Const CMstrmas_pdentrylistVer       As String = "03.00"     'ﾏｽﾀ工順一覧
    Private Const CMstrmas_pdlist__Ver          As String = "03.00"     '機種区分一覧取得
    Private Const CMstrlot_throwrsvVer          As String = "03.00"     '投入予約登録
    Private Const CMstrlot_approveVer           As String = "01.04"     '投入ﾛｯﾄ承認要求
    '@↓2020/01/15 (Wed) 14:03:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer          As String = "03.04"     'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer          As String = "04.00"     'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:03:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrpr__orderlistVer         As String = "01.00"     'P/Rｵｰﾀﾞｰﾘｽﾄ取得

    '@ｺﾝﾄﾛｰﾙ名 1ﾌｫｰﾑで2機能あり(投入予定ﾛｯﾄ登録/投入予定分割登録)
    '@通常は定数として使用するが複数機能である為、ﾌｫｰﾑ起動時に値を設定する。
    Private CMstrLocalMenuKey                   As String               'ﾒﾆｭｰKey

    '@frmxxCM00M0の定数宣言
    Private Const CMlngPdIDLength               As Integer = 3             '機種文字数
    Private Const CMfrmxxCM00M0Height           As Integer = 681           'ﾌｫｰﾑの高さ
    Private Const CMfrmxxCM00M0Width            As Integer = 1001          'ﾌｫｰﾑの幅
    Private Const CMlngIndex                    As Integer = 1             'ｽﾃｰﾀｽﾊﾞｰ表示ｲﾝﾃﾞｯｸｽ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ定数宣言
    Private Const CMlngComboDispCols1           As Integer = 1             '表示列数
    Private Const CMlngComboDispCols2           As Integer = 2             '表示列数
    Private Const CMlngComboGetCol              As Integer = 0             '値取得列
    Private Const CMlngComboFontSize            As Integer = 16            'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboGridFontSize        As Integer = 16            'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboRowHeight           As Integer = 43            '行高さ
    Private Const CMlngComboAlignLeftCenter     As Integer = 1             '左中央
    Private Const CMlngCmbEntryDispCols         As Integer = 2             '表示列数

    '@ｺﾒﾝﾄ欄
    Private Const CMlngLotCommentsMaxByte       As Integer = 512           'ｺﾒﾝﾄの最大入力ﾊﾞｲﾄ数
    Private Const CMlngLotIDByte                As Integer = 10            'ﾛｯﾄIDﾊﾞｲﾄ数
    '@ｺﾒﾝﾄｽｸﾛｰﾙ制御用
    Private Const CMlngMaxDispRow               As Integer = 3             'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@ﾌﾟﾛﾀﾞｸﾄﾘｽﾄの配列要素数
    Private Const CMlngcmbPd                    As Integer = 1             'ﾌﾟﾛﾀﾞｸﾄﾘｽﾄの配列要素数

    '@処理ﾌﾗｸﾞ
    Private Const CMlngCreateInfo               As Integer = 1             '入力ﾁｪｯｸﾌﾗｸﾞ(1:ﾛｯﾄ作成基礎情報)
    Private Const CMlngOrderInfo                As Integer = 2             '入力ﾁｪｯｸﾌﾗｸﾞ(2:ﾛｯﾄ工順情報)

    Private Const CMlngBackColor                As Integer = &H8000000F    'ｺﾝﾄﾛｰﾙのﾊﾞｯｸｶﾗｰ
    Private Const CMstrWFDefault                As String = "0"         'WF枚数ｾﾞﾛ入力時比較用定数

    '@起動区分の定数宣言
    Private Const CMlngPDEntryALL               As Integer = 1             '機種ｴﾝﾄﾘ表示用("1":全件取得)

    '@P/R区分の定数宣言
    Private Const CMlngOptPrClassP              As Integer = 0             'P/R区分(Pｵｰﾀﾞｰ)
    Private Const CMlngOptPrClassR              As Integer = 1             'P/R区分(Rｵｰﾀﾞｰ)

    '@その他
    Private Const CMlngMaxWfCount               As Integer = 25            'MAXWF枚数

    '@↓2013/11/26 (Tue) 18:23:33 T.Oide **************************************************
    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    '@「投入ロット数」のコンボBoxのMaxの数を変更したい場合はここを修正
    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    Private Const CMlngLotCount                 As Integer = 10            '投入ロット数のMax数
    '@↑2013/11/26 (Tue) 18:23:33 T.Oide **************************************************

    '@ﾌｫｰﾑ起動区分定数宣言
    Private Const CMlngfrmCM00M0Flag0           As Integer = 0             '0:投入予定ﾛｯﾄ登録で起動
    Private Const CMlngfrmCM00M0Flag1           As Integer = 1             '1:分割予定ﾛｯﾄ登録で起動

    '@ﾚｽﾎﾟﾝｽ計測用
    Private Const CMstrFormName                 As String = "frmxxCM00M0"       '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                 As String = "Form_Load"         'ｲﾍﾞﾝﾄ名定数(ﾌｫｰﾑﾛｰﾄﾞ処理)
    Private Const CMstrCmbPdValidate            As String = "cmbPd_Validate"    'ｲﾍﾞﾝﾄ名定数(機種ｺﾝﾎﾞのValidate処理)
    Private Const CMstrCmdRegistClick           As String = "cmdRegist_Click"   'ｲﾍﾞﾝﾄ名定数(確定ﾎﾞﾀﾝ押下処理)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private===========================================
    Private mstrPdName                          As String               '機種名退避領域
    Private mstrDivideLotID                     As String               '分割元ﾛｯﾄID退避領域
    Private mstrCopyLotID                       As String               '工順ｺﾋﾟｰﾛｯﾄID退避領域
    Private mlngPdEntryMaxWFCount               As Integer              '現在選択されている機種ｴﾝﾄﾘの最大WF枚数
    Private mtypPdList                          As List(Of ProductList) '機種一覧格納用
    Private mlngPdCnt                           As Integer              '機種一覧ｶｳﾝﾄ
    Private mtypDivisionList                    As List(Of DivisionList)'種別一覧格納用
    Private mlngDivisionCnt                     As Integer              '種別一覧ｶｳﾝﾄ
    Private mtypLotManagerList                  As List(Of TechManList) 'ﾛｯﾄ担当一覧格納用
    Private mlngLotManagerListCnt               As Integer              'ﾛｯﾄ担当一覧ｶｳﾝﾄ
    Private mtypPrOrderListAns                  As PrOrderListAns       'P/Rｵｰﾀﾞｰ一覧格納用
    Private mtypLotReserve                      As LotReserve           '投入予約渡し用
    Private mtypLotCurState                     As Lotprestate          'ﾛｯﾄ情報格納構造体
    Private mblnFormLoadFlag                    As Boolean              'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mblnOptButtonEventControlFlag       As Boolean              'ｵﾌﾟｼｮﾝﾎﾞﾀﾝｲﾍﾞﾝﾄ制御ﾌﾗｸﾞ(True：ｽｷｯﾌﾟ、False：初期値)
    Private mstrDivideLotPdID                   As String               '分割LOTの機種
    '@↓2013/11/26 (Tue) 16:21:42 T.Oide **************************************************
    Private mblnEventCancelFlag                 As Boolean              'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
    '@↑2013/11/26 (Tue) 16:21:42 T.Oide **************************************************
    Private ReadOnly vbButtonFace               As Color = SystemColors.ControlLight 'NSYS vbButtonFace定義
    Private ReadOnly vbWhite                    As Color = Color.White               'NSYS vbWhite定義
    Private buttonProcessing                    As Boolean                           'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                           'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                           'NSYS WindowCloseフラグ


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
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/23 (Mon) 10:34:04 M.Miura
    '更新日：2008/06/04 (Wed) 15:20:10 N.Kojima
    '備　考：
    '　　　：2004/08/26 (Thu) 15:39:22 N.Kojima     数値の比較はlong型で行うように修正(138行目)。
    '　　　：2004/08/31 (Tue) 11:07:14 M.Miura      機種の最大ｽﾛｯﾄ数がNullの場合はｺﾝﾎﾞにｾｯﾄしないように修正
    '　　　：2005/06/23 (Thu) 15:19:22 S.Deguchi    表示系の処理をｱｸﾃｨﾍﾞｲﾄへ移す
    '　　　：2005/09/15 (Thu) 14:08:23 N.Kasai      ﾒﾆｭｰkeyをｾｯﾄ
    '　　　：2005/12/02 (Fri) 11:34:34 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    '　　　：2005/12/21 (Wed) 12:11:11 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(ﾕｰｻﾞｰ要望№0134)
    '　　　：2008/06/04 (Wed) 15:20:10 N.Kojima     技術担当をﾛｯﾄ担当に変更、ｿｰｽ整備。(案件№02884)
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean               '戻り値
        Dim lblnAnsProduct          As Boolean               '機種一覧取得戻り値(True/False)
        Dim lblnAnsLotManager       As Boolean               'ﾛｯﾄ担当一覧取得戻り値(True/False)
        Dim lblnAnsPrOrder          As Boolean               'P/Rｵｰﾀﾞｰ一覧取得戻り値(True/False)
        Dim lstrClassDivision       As String                '作成処理区分

        Try
            
            '@★ 画面起動区分により処理分岐 ★
            Select Case plngfrmxxCM00M0Kbn
            
                '@〓 0:投入予定ﾛｯﾄ登録 〓
                Case CMlngfrmCM00M0Flag0

                    '@機能Ver判定用、OnErr用にﾒﾆｭｰkeyをｾｯﾄ
                    CMstrLocalMenuKey = CPstrKeyEN0020
                    
                '@〓 その他 〓
                Case Else

                    '@機能Ver判定用、OnErr用にﾒﾆｭｰkeyをｾｯﾄ
                    CMstrLocalMenuKey = CPstrKeyEN01F0

            End Select
            
            '@=======================
            '@　機能ﾊﾞｰｼﾞｮﾝの判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CMstrLocalMenuKey, CMstrLocalVersion)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@=======================
                '@　ﾒｲﾝﾒﾆｭｰ画面拡張処理
                '@=======================
                Call pubMenuExpand_Disp()
                
                '@=======================
                '@　ﾌｫｰﾑ終了時処理
                '@=======================
                Call Form_QueryUnload(False, New FormClosingEventArgs(CloseReason.UserClosing,  False))
                
                Exit Sub
            End If

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@=======================
            '@　各種初期化処理(画面ｺﾝﾄﾛｰﾙ、変数等)
            '@=======================
            Call prvFrmxxCM00M0_Init()
            
            '@作業ﾒﾓ用上下ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
            cmdWorkMemoUp.Enabled = False           '▲ﾎﾞﾀﾝ
            cmdWorkMemoDown.Enabled = False         '▼ﾎﾞﾀﾝ
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False

            'NSYS 配列初期化
            If mtypPdList Is Nothing Then 
                mtypPdList = New List(Of ProductList) 
            Else 
                mtypPdList.Clear()
            End If

            If mtypLotManagerList Is Nothing Then 
                mtypLotManagerList = New List(Of TechManList) 
            Else 
                mtypLotManagerList.Clear()
            End If
            
            '@★ 画面起動区分により処理分岐 ★
            '@　 ※起動区分が"0：投入予定ﾛｯﾄ登録"の場合のみ通信を行なう。
            Select Case plngfrmxxCM00M0Kbn
            
                '@〓 0:投入予定ﾛｯﾄ登録 〓
                Case CMlngfrmCM00M0Flag0
            
        '            '@処理区分に"2A02:画面ｻｲｽﾞ指定無し"をｾｯﾄ
        '            lstrClassDivision = CPstrCD2A & CPstrCD02
                    '@処理区分に"2A1Y:ﾊﾟﾈﾙｻｲｽﾞ指定無し & TPAL CF以外"をｾｯﾄ
                    lstrClassDivision = CPstrCD2A & CPstrCD1Y
                    
                    '@【機種区分一覧取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAnsProduct = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                                         lstrClassDivision, _
                                                         mtypPdList, _
                                                         mlngPdCnt, _
                                                         pstrSBID)
                
                    '@機種区分一覧取得結果判定
                    If lblnAnsProduct = False Then
                        '@結果：異常の場合
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                        Exit Sub
                    End If
                        
                        
                    '@【作業者ﾘｽﾄ(ﾛｯﾄ担当)取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAnsLotManager = pubblnMasEmplist_Sel(CMstrmas_emplist_Ver, _
                                                             mtypLotManagerList, _
                                                             mlngLotManagerListCnt)
                
                    '@作業者ﾘｽﾄ(ﾛｯﾄ担当)取得結果判定
                    If lblnAnsLotManager = False Then
                        '@結果：異常の場合
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                        Exit Sub
                    End If
                    
                    
                    '@【P/Rｵｰﾀﾞｰ一覧取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAnsPrOrder = pubblnPrOrderList_Sel(CMstrpr__orderlistVer, _
                                                           mtypPrOrderListAns)
                    
                    '@P/Rｵｰﾀﾞｰ一覧取得結果判定
                    If lblnAnsPrOrder = False Then
                        '@結果：異常の場合
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                        Exit Sub
                    End If
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
                    
                    
                '@〓 その他 〓
                Case Else

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrFormLoad)

            End Select
            
            '@送品ｺﾝﾎﾞ作成(Form_loadでのみ行なう為、Function化しない)
            With cmbLotSend
                
                .ValueCol = 1       '値取得列：あり/なし
                
                .AddItem(CPstrNasiFlg & vbTab & CPlngLotSendNasi)    '0/なし
                .AddItem(CPstrAriFlg & vbTab & CPlngLotSendAri)      '1/あり
            
                .Enabled = False    '無効
            End With
            
            '@Form_Loadﾌﾗｸﾞに"True:正常起動"をｾｯﾄ
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
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/23 (Thu) 12:50:44 S.Deguchi
    '更新日：2013/11/26 (Tue) 18:26:08 T.Oide
    '備　考：
    '　　　：2005/12/21 (Wed) 12:07:55 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加
    '　　　：2008/06/04 (Wed) 15:40:08 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2013/11/26 (Tue) 18:26:08 T.Oide       GNS対応
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False:未表示"か
            If mblnFormLoadFlag = False Then
            
                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True:表示済"をｾｯﾄ
                mblnFormLoadFlag = True
                
                
                '@★ 画面起動区分により処理分岐 ★
                '@　 ※起動区分が"0：投入予定ﾛｯﾄ登録"の場合のみ下記のｺﾝﾎﾞ作成処理を行う。
                Select Case plngfrmxxCM00M0Kbn
                
                    '@〓 0:投入予定ﾛｯﾄ登録 〓
                    Case CMlngfrmCM00M0Flag0
                
                        '@=======================
                        '@　機種ｺﾝﾎﾞ作成処理
                        '@=======================
                        Call prvcmbPd_Disp()
                        
                        '@=======================
                        '@　ﾛｯﾄ担当ｺﾝﾎﾞ作成処理
                        '@=======================
                        Call prvCmbLotManager_Disp()
                                        
                    '@〓 その他 〓
                    Case Else
            
                        '@特に処理なし

                End Select

        '@↓2013/11/26 (Tue) 18:26:05 T.Oide **************************************************
                '@=======================
                '@　ﾛｯﾄ投入数のｺﾝﾎﾞ作成
                '@=======================
                Call prvcmbLotThrowinNum_Init()
        '@↑2013/11/26 (Tue) 18:26:05 T.Oide **************************************************
            
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
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 12:55:16 M.Miura
    '更新日：2008/06/05 (Thu) 10:37:44 N.Kojima
    '備　考：
    '　　　：2005/12/21 (Wed) 12:07:55 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(ﾕｰｻﾞｰ要望№0134)
    '　　　：2008/06/05 (Thu) 10:37:44 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
                       
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
                
                '@〓 作業ﾒﾓ 〓
                Case txtWorkMemo.Name
                
                    '@作業ﾒﾓは改行できるように何もしない
                    Exit Sub
                
                '@〓 機種 〓
                Case cmbPD.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                        
                            '@=======================
                            '@　機種ｺﾝﾎﾞのValidate処理
                            '@=======================
                            RemoveHandler cmbPd.Validating, AddressOf cmbPd_Validate 
                            Call cmbPd_Validate(cmbPd,New CancelEventArgs(True))
                            AddHandler cmbPd.Validating, AddressOf cmbPd_Validate
                            'NSYS 何も選択されていない場合はフォーカス移動
                            If cmbPD.Text = vbNullString Then
                                Call pubSetFocus(cmdPlanList)
                            End If
                            e.Handled = True
                    End Select
                
                
                '@〓 種別 〓
                Case cmbDivision.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                        
                            '@=======================
                            '@　種別ｺﾝﾎﾞのValidate処理
                            '@=======================
                            RemoveHandler cmbDivision.Validating, AddressOf cmbDivision_Validate
                            Call cmbDivision_Validate(cmbDivision,New CancelEventArgs(True))
                            AddHandler cmbDivision.Validating, AddressOf cmbDivision_Validate
                            e.Handled = True
                    End Select
                
                
                '@〓 WF枚数 〓
                Case txtWFNum.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                        
                            '@=======================
                            '@　WF枚数ﾃｷｽﾄのValidate処理
                            '@=======================
                            RemoveHandler txtWFNum.Validating, AddressOf txtWFNum_Validate
                            Call txtWFNum_Validate(txtWFNum,New CancelEventArgs(True))
                            AddHandler txtWFNum.Validating, AddressOf txtWFNum_Validate
                            e.Handled = True
                    End Select
                
                
                '@〓 投入予定日 〓
                Case calStartDate.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                            
                            '@=======================
                            '@　投入予定日ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
                            '@=======================
                            RemoveHandler calStartDate.Validating, AddressOf calStartDate_Validate
                            Call calStartDate_Validate(calStartDate,New CancelEventArgs(True))
                            AddHandler calStartDate.Validating, AddressOf calStartDate_Validate
                            e.Handled = True
                    End Select
                    
                    
                '@〓 ﾛｯﾄ担当 〓
                Case cmbLotManager.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                            
                            '@=======================
                            '@　ﾛｯﾄ担当ｺﾝﾎﾞのValidate処理
                            '@=======================
                            RemoveHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate
                            Call cmbLotManager_Validate(cmbLotManager,New CancelEventArgs(True))
                            AddHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate
                            e.Handled = True
                    End Select
                
                
                '@〓 P/Rｵｰﾀﾞｰ 〓
                Case cmbPrOrder.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode

                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return

                            '@=======================
                            '@　P/RｵｰﾀﾞｰｺﾝﾎﾞのValidate処理
                            '@=======================
                            RemoveHandler cmbPrOrder.Validating, AddressOf cmbPrOrder_Validate
                            Call cmbPrOrder_Validate(cmbPrOrder,New CancelEventArgs(True))
                            AddHandler cmbPrOrder.Validating, AddressOf cmbPrOrder_Validate
                            e.Handled = True
                    End Select
                
                
                '@〓 分割元ﾛｯﾄID 〓
                Case txtDivideLotID.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode
                    
                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                            
                            '@=======================
                            '@　分割元ﾛｯﾄIDﾃｷｽﾄのValidate処理
                            '@=======================
                            RemoveHandler txtDivideLotID.Validating, AddressOf txtDivideLotID_Validate
                            Call txtDivideLotID_Validate(txtDivideLotID, New CancelEventArgs(True))
                            AddHandler txtDivideLotID.Validating, AddressOf txtDivideLotID_Validate
                            e.Handled = True
                    End Select
                
                
                '@〓 ｺﾋﾟｰ元ﾛｯﾄID 〓
                Case txtCopyLotID.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode

                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return

                            '@=======================
                            '@　ｺﾋﾟｰ元ﾛｯﾄIDﾃｷｽﾄのValidate処理
                            '@=======================
                            RemoveHandler txtCopyLotID.Validating, AddressOf txtCopyLotID_Validate
                            Call txtCopyLotID_Validate(txtCopyLotID, New CancelEventArgs(True))
                            AddHandler txtCopyLotID.Validating, AddressOf txtCopyLotID_Validate
                            e.Handled = True
                    End Select
                
                
                '@〓 その他 〓
                Case Else

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode

                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return
                            
                            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
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
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：True:ｷｬﾝｾﾙ、False:未ｷｬﾝｾﾙ
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/02/18 (Wed) 17:31:14 K.Takano
    '更新日：2008/06/05 (Thu) 10:49:49 N.Kojima
    '備　考：
    '　　　：2004/10/26 (Tue) 17:34:08 T.Kitagawa   DoEvents対応
    '　　　：2004/11/01 (Mon) 15:29:20 N.Kasai      閉じるﾎﾞﾀﾝ統合
    '　　　：2005/12/21 (Wed) 12:09:09 T.Kitagawa   Rｵｰﾀﾞｰ一覧格納構造体ｸﾘｱ追加
    '　　　：2008/06/05 (Thu) 10:49:49 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      'ACT開放結果格納

        Try
                        
            '@以下の条件の場合、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
           
            
            '@"×"ﾎﾞﾀﾝでの終了か
            If mblnCloseFromControlMenu Then
            
                '@=======================
                '@　閉じるﾎﾞﾀﾝ押下時処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(e, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@各種ﾓｼﾞｭｰﾙ構造体(配列)の初期化
            '機種格納配列
            If mtypPdList Is Nothing Then
                mtypPdList = New List(Of ProductList)
            Else
                mtypPdList.Clear
            End If
            '種別格納配列
            If mtypDivisionList Is Nothing Then
                mtypDivisionList = New List(Of DivisionList)
            Else
                mtypDivisionList.Clear
            End If
            'ﾛｯﾄ担当格納配列
            If mtypLotManagerList Is Nothing Then
                mtypLotManagerList = New List(Of TechManList)
            Else
                mtypLotManagerList.Clear
            End If
            'P/Rｵｰﾀﾞｰ格納配列
            If mtypPrOrderListAns.typPrOrderList Is Nothing Then
                mtypPrOrderListAns.typPrOrderList = New List(Of PrOrderList)
            Else
                mtypPrOrderListAns.typPrOrderList.Clear
            End If
            
            '@Act初期化ﾌﾗｸﾞが"True:初期化済"か
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@=======================
                '@　ACTｵﾌﾞｼﾞｪｸﾄ開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                '@処理結果判定
                If lblnAnsTerm = True Then
                    '@結果：正常の場合
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@Act初期化ﾌﾗｸﾞが"False:未初期化"の場合
            
                '@=======================
                '@　ﾒｲﾝﾒﾆｭｰ画面拡張処理
                '@=======================
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

    '関数名：optNew_Click
    '機　能：新規ﾛｯﾄID採番ｵﾌﾟｼｮﾝﾎﾞﾀﾝ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 18:45:57 K.Takano
    '更新日：2008/06/06 (Fri) 14:29:22 N.Kojima
    '備　考：
    '　　　：2005/06/23 (Thu) 13:09:41 S.Deguchi    退避領域のｸﾘｱ処理を追加
    '　　　：2005/12/21 (Wed) 12:07:55 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(ﾕｰｻﾞｰ要望№0134)
    '　　　：2006/04/03 (Mon) 09:18:42 N.Kojima     P/Rｵｰﾀﾞｰｺﾒﾝﾄ追加に伴い処理追加(ﾕｰｻﾞｰ要望№0174)
    '　　　：2006/10/31 (Tue) 13:44:56 N.Kasai      送品ｺﾝﾎﾞ追加
    '　　　：2008/06/06 (Fri) 14:29:22 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub optNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optNew.CheckedChanged

        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try            
            
            '@***********************
            '@　各種ｺﾝﾄﾛｰﾙの有効/無効制御、背景色設定を行なう
            '@***********************
            
            '@-----------------------
            '@　新規ﾛｯﾄID採番関連制御
            '@-----------------------
            cmbPD.Enabled = True                          '機種：有効
            cmbPD.BackColor = vbWhite                     '機種：背景色は白
            cmbDivision.Enabled = False                   '種別：無効
            cmbDivision.BackColor = vbWhite               '種別：背景色は白
            txtWFNum.Text = vbNullString                  'WF枚数：NULL
            txtWFNum.Enabled = False                      'WF枚数：無効
            txtWFNum.BackColor = vbWhite                  'WF枚数：背景色は白
            calStartDate.Value = _
                Format$(Now, CPstrDateTimeYMD)            '投入予定日：現在日
            calStartDate.Enabled = False                  '投入予定日：無効
            calStartDate.BackColor = vbWhite              '投入予定日：背景色は白
            cmbLotManager.Enabled = False                 'ﾛｯﾄ担当：無効
            cmbLotManager.BackColor = vbWhite             'ﾛｯﾄ担当：背景色は白

            '@P/Rｵｰﾀﾞｰ関連の制御
            fraPrClass.Enabled = False                              'P/R区分：無効
            optPrClass0.Enabled = False            'P：無効
            optPrClass1.Enabled = False            'R：無効
            optPrClass0.Checked  = False           'P：ﾁｪｯｸなし
            optPrClass1.Checked = False            'R：ﾁｪｯｸなし
            cmbPrOrder.Enabled = False                              'P/Rｵｰﾀﾞｰ：無効
            cmbPrOrder.BackColor = ColorTranslator.FromWin32(&H80000005)                'P/Rｵｰﾀﾞｰ：背景色は白
            
            '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄の制御
            txtOrderComment.Text = vbNullString             'NULL
            txtOrderComment.Enabled = False                 '無効
            txtOrderComment.Locked = True                   'ﾛｯｸ
            
            '@送品をｸﾘｱ
            cmbLotSend.ListIndex = -1
            
            
            '@-----------------------
            '@　分割ﾛｯﾄID採番関連制御
            '@-----------------------
            txtDivideLotID.Text = vbNullString              '分割元ﾛｯﾄID：NULL
            txtDivideLotID.Enabled = False                  '分割元ﾛｯﾄID：無効
            txtDivideLotID.BackColor = vbButtonFace         '分割元ﾛｯﾄID：背景色はｸﾞﾚｰ
            cmdDivideLotID.Enabled = False                  '分割元ﾛｯﾄIDﾎﾞﾀﾝ：無効
            cmdDivideLotID.BackColor = vbButtonFace         '分割元ﾛｯﾄIDﾎﾞﾀﾝ：背景色はｸﾞﾚｰ


            '@-----------------------
            '@　ﾛｯﾄ工順情報関連制御
            '@-----------------------
            '@ｴﾝﾄﾘ情報をｸﾘｱ
            lblEntryID.Text = vbNullString               'ｴﾝﾄﾘ
            lblEntryName.Text = vbNullString             'ｴﾝﾄﾘ名


            '@退避領域のｸﾘｱ
            mstrPdName = vbNullString
            
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optNew_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_Change
    '機　能：機種ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/23 (Thu) 10:27:56 S.Deguchi
    '更新日：2013/11/26 (Tue) 19:05:03 T.Oide
    '備　考：
    '　　　：2006/01/10 (Tue) 13:22:53 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(ﾕｰｻﾞｰ要望№0134)
    '　　　：2006/04/03 (Mon) 09:21:53 N.Kojima     P/Rｵｰﾀﾞｰｺﾒﾝﾄ追加に伴い処理追加(ﾕｰｻﾞｰ要望№0174)
    '　　　：2008/06/05 (Thu) 11:00:42 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2013/11/26 (Tue) 19:05:03 T.Oide       GNS対応
    Private Sub cmbPd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.Change

        Try
            
            '@機種退避領域と機種ｺﾝﾎﾞの選択機種が異なるか
            If mstrPdName <> cmbPD.Text Then
                '@異なる場合

                '@各種ｺﾝﾄﾛｰﾙをｸﾘｱする
                cmbDivision.Clear                           '種別
                txtWFNum.Text = vbNullString                'WF枚数
                calStartDate.Value = CPstrNullDate          '投入予定日
                cmbLotManager.ListIndex = -1                'ﾛｯﾄ担当
                cmbLotSend.ListIndex = -1                   '送品
                lblEntryID.Text = vbNullString              'ｴﾝﾄﾘ
                lblEntryName.Text = vbNullString            'ｴﾝﾄﾘ名
            End If
            
            '@P/Rｵｰﾀﾞｰｵﾌﾟｼｮﾝﾎﾞﾀﾝ、P/Rｵｰﾀﾞｰｺﾝﾎﾞを無効にする
            fraPrClass.Enabled = False
            optPrClass0.Enabled = False    'P
            optPrClass1.Enabled = False    'R
            optPrClass0.Checked = False
            optPrClass1.Checked = False
            cmbPrOrder.Enabled = False
            cmbPrOrder.ListIndex = -1
            
            '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄の制御
            With txtOrderComment
                .Text = vbNullString    'NULL
                .Enabled = True         '有効
                .Locked = True          'ﾛｯｸ
            End With
            
        '@↓2013/11/26 (Tue) 19:04:59 T.Oide **************************************************
            '@投入ロット数を1に初期化
            cmbLotThrowinNum.ListIndex = 0
        '@↑2013/11/26 (Tue) 19:04:59 T.Oide **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPd_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_CloseUp
    '機　能：機種ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/13 (Thu) 12:34:46 M.Miura
    '更新日：2008/06/05 (Thu) 11:05:55 N.Kojima
    '備　考：
    '　　　：2008/06/05 (Thu) 11:05:55 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmbPd_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.CloseUp

        Try
                   
            '@=======================
            '@　機種ｺﾝﾎﾞのValidate処理
            '@=======================
            RemoveHandler cmbPd.Validating, AddressOf cmbPd_Validate
            Call cmbPd_Validate(cmbPd, New CancelEventArgs(True))
            AddHandler cmbPd.Validating, AddressOf cmbPd_Validate
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPd_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_Validate
    '機　能：機種ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 10:10:15 S.Deguchi
    '更新日：2008/06/05 (Thu) 11:06:50 N.Kojima
    '備　考：
    '　　　：2004/09/01 (Wed) 17:14:24 Y.Yamagishi　機種ｴﾝﾄﾘごとに最大WF枚数を表示
    '　　　：2004/09/10 (Fri) 12:07:05 Y.Yamagishi　何も選択されていない場合は抜ける処理追加
    '　　　：2005/05/13 (Fri) 10:03:54 S.Deguchi    種別で"PR"は表示しないように修正
    '　　　：2005/12/21 (Wed) 12:07:55 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(ﾕｰｻﾞｰ要望№0134)
    '　　　：2006/04/03 (Mon) 09:22:57 N.Kojima     P/Rｵｰﾀﾞｰｺﾒﾝﾄ追加に伴い処理追加(ﾕｰｻﾞｰ要望№0174)
    '　　　：2006/11/13 (Mon) 15:40:01 N.Kasai      送品ｺﾝﾎﾞｸﾘｱ
    '　　　：2008/06/05 (Thu) 11:06:50 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmbPd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPd.Validating

        Dim lblnAns         As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            '@何も選択されていない場合は処理を抜ける
            '(NSYS cmdPlanListに移動した際のValidateが実行されていない場合も条件に該当させる)
            If cmbPD.Text = vbNullString Then
                '@次へﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = cmbPD.Name Then
                    Call pubSetFocus(cmdPlanList)
                End If 
                Exit Sub
            End If
                
            '@機種がNULLか
            If cmbPD.Text = vbNullString Then
            
                '@投入予定一覧にﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = cmbPD.Name Then
                    Call pubSetFocus(cmdPlanList)
                End if
                Exit Sub
            Else
                '@機種がNULL以外の場合
                
                '@選択機種が退避機種と同じか
                If mstrPdName = cmbPD.Text Then
                    '@同じ場合
                    If ActiveControl.Name = cmbPD.Name Then
                        '@種別が有効か
                        If cmbDivision.Enabled = True Then
                   
                            '@種別にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbDivision)
                        Else
                           '@種別が無効な場合
                   
                           '@投入予定日にﾌｫｰｶｽｾｯﾄ
                           Call pubSetFocus(cmdPlanList)
                        End If
                    End if
                    Exit Sub
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmbPdValidate)
            
            '@【流動区分一覧取得】ﾒｯｾｰｼﾞ送受信処理　※流動区分=種別は同意義です。
            lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                            mtypDivisionList, _
                                            mlngDivisionCnt, _
                                            pstrSBID, _
                                            CPstrCD04, _
                                            cmbPD.Text)
            
            '@流動区分一覧取得結果判定
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@=======================
                '@　種別ｺﾝﾎﾞ作成処理
                '@=======================
                Call prvCmbFlowList_Disp()
                
                '@=======================
                '@　ﾏｽﾀ工順取得＆表示処理
                '@=======================
                Call prvMasEntryList_Sel()
            Else
                '@結果：異常の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmbPdValidate)
                Exit Sub
            End If
            
            '@新規ﾛｯﾄID採番部のｺﾝﾄﾛｰﾙを有効にする
            cmbDivision.Enabled = True              '種別
            txtWFNum.Enabled = True                 'WF枚数
            calStartDate.Enabled = True             '投入予定日
            cmbLotManager.Enabled = True            'ﾛｯﾄ担当
            
            
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmbPdValidate)
                
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If
            
            '@種別が有効か
            If ActiveControl.Name = cmbPD.Name Then
                If cmbDivision.Enabled = True Then
                   '@種別へﾌｫｰｶｽｾｯﾄ
                   Call pubSetFocus(cmbDivision)
                Else
                  '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                   Call pubSetFocus(cmdClose)
                End If
            End If 
            '@選択機種を退避(次回選択時の比較用)
            mstrPdName = cmbPD.Text
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmbPdValidate)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPd_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivision_Change
    '機　能：種別ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 19:30:19 M.Miura
    '更新日：2013/11/26 (Tue) 14:15:07 T.Oide
    '備　考：
    '　　　：2006/04/03 (Mon) 09:13:50 N.Kojima     P/Rｵｰﾀﾞｰｺﾒﾝﾄ追加に伴い処理追加(ﾕｰｻﾞｰ要望№0174)
    '　　　：2008/06/06 (Fri) 15:12:36 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmbDivision_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDivision.Change

        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
           
            '@★ 種別により処理分岐 ★
            Select Case cmbDivision.Text
            
                '@〓 WS,TS,ZZ,GG 〓
                Case CPstrFlowClassWS, CPstrFlowClassTS, CPstrFlowClassZZ, CPstrFlowClassGG
                    
                    '@***********************
                    '@　PR/ES以外、品確・ﾓﾆﾀ・ﾀﾞﾐｰ以外は、P/Rｵｰﾀﾞｰ必須とする(TS,WS,ZZ,GG等)
                    '@***********************
                    
                    '@P/Rｵｰﾀﾞｰ関連（有効）
                    fraPrClass.Enabled = True                       'P/R区分：有効
                    optPrClass0.Enabled = True                      '"P"：有効
                    optPrClass1.Enabled = True                      '"R"：有効
                    optPrClass0.Checked = True                      'ﾃﾞﾌｫﾙﾄは"P"にﾁｪｯｸ
                    cmbPrOrder.Enabled = True                       'P/Rｵｰﾀﾞｰ：有効
                    
                    '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄を有効にする
                    txtOrderComment.Enabled = True

        '@↓2013/11/26 (Tue) 14:14:24 T.Oide **************************************************
                    '@ロット担当者を有効にする
                    cmbLotManager.Enabled = True
        '@↑2013/11/26 (Tue) 14:14:24 T.Oide **************************************************
                    
                '@〓 以外 〓
                Case Else
                
                    '@P/Rｵｰﾀﾞｰ関連（無効）
                    fraPrClass.Enabled = False                      'P/R区分：無効
                    optPrClass0.Enabled = False                     '"P"：有効
                    optPrClass1.Enabled = False                     '"R"：有効
                    optPrClass0.Checked = False                     '"P"：ﾁｪｯｸなし
                    optPrClass1.Checked = False                     '"R"：ﾁｪｯｸなし
                    cmbPrOrder.Enabled = False                      'P/Rｵｰﾀﾞｰ：無効
                    cmbPrOrder.ListIndex = -1                       'P/Rｵｰﾀﾞｰ：ｸﾘｱ
                    
                    '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄をｸﾘｱし、無効にする
                    txtOrderComment.Text = vbNullString
                    txtOrderComment.Enabled = False

        '@↓2013/11/26 (Tue) 14:14:24 T.Oide **************************************************
                    '@ロット担当者を無効で空にする
                    cmbLotManager.ListIndex = -1
                    cmbLotManager.Enabled = False
        '@↑2013/11/26 (Tue) 14:14:24 T.Oide **************************************************

            End Select
            
            '@種別がNULL以外か
            If cmbDivision.Text <> vbNullString Then

                '@送品を有効にする
                cmbLotSend.Enabled = True
            End If
            
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If

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
    '機　能：種別ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/13 (Thu) 12:37:43 M.Miura
    '更新日：2008/06/09 (Mon) 13:27:08 N.Kojima
    '備　考：
    '　　　：2004/09/30 (Thu) 19:55:01 N.Kasai      ﾌｫｰｶｽ制御追加
    '　　　：2008/06/09 (Mon) 13:27:08 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmbDivision_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDivision.CloseUp

        Try
                       
            '@種別がNULL以外か
            If cmbDivision.Text <> vbNullString Then
            
                '@=======================
                '@　種別ｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbDivision.Validating, AddressOf cmbDivision_Validate
                Call cmbDivision_Validate(cmbDivision, New CancelEventArgs(True))
                AddHandler cmbDivision.Validating, AddressOf cmbDivision_Validate
            End If
            
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
    '機　能：種別ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 10:22:18 S.Deguchi
    '更新日：2008/06/09 (Mon) 13:28:46 N.Kojima
    '備　考：
    '　　　：2006/10/31 (Tue) 14:02:03 N.Kasai      送品ｺﾝﾎﾞ設定
    '　　　：2008/06/09 (Mon) 13:28:46 N.Kojima     ｿｰｽ整備。(案件№02884)
        Private Sub cmbDivision_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbDivision.Validating
        
        Dim lblnAns     As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
                       
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If
            
            '@WF枚数が有効か
            If txtWFNum.Enabled = True Then
                'NSYS IF判定追加
                 If ActiveControl.Name = cmbDivision.Name Then
                     '@WF枚数へｾｯﾄﾌｫｰｶｽ
                     Call pubSetFocus(txtWFNum)
                 End If
            End If
            
            '@=======================
            '@　送品ｺﾝﾎﾞ設定処理
            '@=======================
            Call prvCmbLotSend_Set()
            
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

    '関数名：cmbLotThrowinNum_CloseUp
    '機　能：フォーカスを次のオブジェクトに移動
    '引　数：なし
    '戻り値：なし
    '作成日：2013/11/26 (Tue) 18:44:08 T.Oide
    '更新日：2013/11/26 (Tue) 18:44:08
    '備　考：
    Private Sub cmbLotThrowinNum_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotThrowinNum.CloseUp

        Try
            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
            SendKeys.SendWait(CPstrSendKeysTab)
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbLotThrowinNum_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtWFNum_Change
    '機　能：WF枚数ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 19:26:14 M.Miura
    '更新日：2008/06/09 (Mon) 13:29:58 N.Kojima
    '備　考：
    '　　　：2008/06/09 (Mon) 13:29:58 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub txtWFNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWFNum.Change

        Dim lblnAns     As Boolean      '戻り値

        Try
                        
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWFNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWFNum_Validate
    '機　能：WF枚数　Validate処理(入力確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 13:14:48 M.Miura
    '更新日：2008/06/06 (Fri) 11:29:07 N.Kojima
    '備　考：
    '　　　：2008/06/06 (Fri) 11:29:07 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2008/09/03 (Wed) 07:52:53 T.Sawaguchi  最大WF枚数でﾁｪｯｸする様に変更　(案件03044)
    Private Sub txtWFNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtWFNum.Validating

        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
           
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
            '@ﾏｽﾀ工順ｵﾌﾟｼｮﾝﾎﾞﾀﾝが"ﾁｪｯｸあり"か
            If optMster.Checked = True Then
                
        '@↓2008/09/03 (Wed) 07:32:28 T.Sawaguchi 案件03044 **************************
                '@[WF枚数が機種の最大WF枚数より大きいか] から
                '@｢WF枚数が最大WF枚数25より大きいか」　に変更
                If CLng(txtWFNum.Text) > CMlngMaxWfCount Then

                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0086, txtWFNum.Text, CMlngMaxWfCount)
                    '@ﾒｯｾｰｼﾞ："<TRM86W>$$ウエハ枚数[%1]が最大WF枚数の設定値[%2]を超えています。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
        '@↑2008/09/03 (Wed) 07:32:28 T.Sawaguchi 案件03044 **************************

                    e.Cancel = True
                    Exit Sub
                End If
            Else
                '@ﾏｽﾀ工順ｵﾌﾟｼｮﾝﾎﾞﾀﾝが"ﾁｪｯｸなし"の場合
                
        '@↓2008/09/03 (Wed) 07:32:28 T.Sawaguchi 案件03044 **************************
                '@[WF枚数が機種の最大WF枚数より大きいか] から
                '@｢WF枚数が最大WF枚数25より大きいか」　に変更
                If CLng(txtWFNum.Text) > CMlngMaxWfCount Then
                    
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0086, txtWFNum.Text, CMlngMaxWfCount)
                    '@ﾒｯｾｰｼﾞ："<TRM86W>$$ウエハ枚数[%1]が最大WF枚数の設定値[%2]を超えています。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
        '@↑2008/09/03 (Wed) 07:32:28 T.Sawaguchi 案件03044 **************************
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If
            
            '@投入予定日が有効か
            If calStartDate.Enabled = True Then
                '@投入予定日へｾｯﾄﾌｫｰｶｽ
                'NSYS IF判定追加
                If ActiveControl.Name = txtWFNum.Name Then
                    Call pubSetFocus(calStartDate)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWFNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStartDate_CalendarSelect
    '機　能：投入予定日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　ｶﾚﾝﾀﾞｰ選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/13 (Thu) 12:40:29 M.Miura
    '更新日：2008/06/09 (Mon) 13:31:45 N.Kojima
    '備　考：
    '　　　：2004/10/01 (Fri) 14:41:25 N.Kasai      空白のﾁｪｯｸ追加
    '　　　：2008/06/09 (Mon) 13:31:45 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub calStartDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calStartDate.CalendarSelect

        Try
                       
            '@投入予定日が"____/__/__"以外か
            If calStartDate.Value <> CPstrNullDate Then
                
                '@=======================
                '@　投入予定日ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler calStartDate.Validating, AddressOf calStartDate_Validate
                Call calStartDate_Validate(True, New CancelEventArgs)
                AddHandler calStartDate.Validating, AddressOf calStartDate_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStartDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStartDate_Change
    '機　能：投入予定日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 19:31:42 M.Miura
    '更新日：2008/06/09 (Mon) 13:33:16 N.Kojima
    '備　考：
    '　　　：2008/06/09 (Mon) 13:33:16 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub calStartDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calStartDate.Change

        Dim lblnAns     As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
                        
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStartDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStartDate_Validate
    '機　能：投入予定日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 10:27:30 S.Deguchi
    '更新日：2008/06/09 (Mon) 13:34:22 N.Kojima
    '備　考：
    '　　　：2008/06/09 (Mon) 13:34:22 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub calStartDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calStartDate.Validating

        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)
        Dim lstrNowDT           As String       '現在日付取得

        Try
           
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            

            '@日付が"____/__/__"以外か
            If calStartDate.Value <> CPstrNullDate Then
            
                '@日付が有効日付か(1900/01/01～2100/12/31か)　※1900/_1/01等も不可
                If pubblnYearRange_Chk(calStartDate.Value) = False Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@ﾒｯｾｰｼﾞ："<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽを保持
                    e.Cancel = True
                    Exit Sub
                Else
                    '@有効日付の場合
                
                    '@現在日付を取得する
                    lstrNowDT = Format(Now, CPstrDateTimeYMD)
                    
                    '@日付が現在日付より過去か
                    If Format(CDate(calStartDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                        '@ﾒｯｾｰｼﾞ："<TRM10W>$$過去の日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                           
                        '@ﾌｫｰｶｽを保持
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
            
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If

            If cmbLotManager.Enabled = True Then
                If ActiveControl.Name = calStartDate.Name Then
                    '@ﾛｯﾄ担当へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbLotManager)
                End if
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStartDate_Validate"
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
    '作成日：2004/05/13 (Thu) 12:39:16 M.Miura
    '更新日：2008/06/09 (Mon) 14:10:05 N.Kojima
    '備　考：
    '　　　：2004/09/30 (Thu) 19:56:18 N.Kasai　    ﾌｫｰｶｽ制御追加
    '　　　：2008/06/09 (Mon) 14:10:05 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmbLotManager_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotManager.CloseUp

        Try
                        
            '@ﾛｯﾄ担当がNULL以外か
            If cmbLotManager.Text <> vbNullString Then
            
                '@=======================
                '@　ﾛｯﾄ担当ｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate
                Call cmbLotManager_Validate(True, New CancelEventArgs)
                AddHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate
            End If
            
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

    '関数名：cmbLotManager_Change
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 19:33:43 M.Miura
    '更新日：2008/06/09 (Mon) 15:57:12 N.Kojima
    '備　考：
    '　　　：2004/10/01 (Fri) 10:26:57 M.Miura　    技術担当が有効な場合の条件追加
    '　　　：2008/06/09 (Mon) 15:57:12 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmbLotManager_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotManager.Change
        
        Dim lblnAns     As Boolean      '戻り値

        Try
                       
        '@↓2013/11/26 (Tue) 16:27:30 T.Oide **************************************************
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞがTrueの場合は処理しない
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
        '@↑2013/11/26 (Tue) 16:27:30 T.Oide **************************************************
            
            
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                
                '@ﾛｯﾄ担当が有効か
                If cmbLotManager.Enabled = True Then
                
        '@↓2013/11/26 (Tue) 16:28:07 T.Oide **************************************************
        '@            '@ﾛｯﾄ担当にﾌｫｰｶｽｾｯﾄ
        '@            Call pubSetFocus(cmbLotManager)
        '@
                    '@ﾛｯﾄ担当にﾌｫｰｶｽｾｯﾄ
                    mblnEventCancelFlag = True 
                      Call pubSetFocus(cmbLotManager)
                    mblnEventCancelFlag = False
        '@↑2013/11/26 (Tue) 16:28:07 T.Oide **************************************************
                    
                End If
            End If

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

    '関数名：cmbLotManager_Validate
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 10:30:46 S.Deguchi
    '更新日：2008/06/09 (Mon) 16:01:55 N.Kojima
    '備　考：
    '　　　：2005/12/21 (Wed) 12:07:55 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(ﾕｰｻﾞｰ要望№0134)
    '　　　：2008/06/09 (Mon) 16:01:55 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmbLotManager_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbLotManager.Validating

        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
                
                '@P/R区分の"P"、"R"ｵﾌﾟｼｮﾝﾎﾞﾀﾝが有効か
                If optPrClass0.Enabled = True And _
                    optPrClass1.Enabled = True Then
                    
                    '@★ ﾁｪｯｸされているｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
                    Select Case True
                    
                        '@〓 "P"ｵﾌﾟｼｮﾝﾎﾞﾀﾝ 〓
                        Case optPrClass0.Checked  = True
                            If ActiveControl.name = cmbLotManager.Name Then
                                '@"P"ｵﾌﾟｼｮﾝﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(optPrClass0)
                            End if
                        '@〓 "R"ｵﾌﾟｼｮﾝﾎﾞﾀﾝ 〓
                        Case optPrClass1.Checked = True
                            If ActiveControl.name = cmbLotManager.Name Then
                                '@"P"ｵﾌﾟｼｮﾝﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(optPrClass1)
                            End if
                    End Select
                    
                Else
                    '@"P"、"R"ｵﾌﾟｼｮﾝﾎﾞﾀﾝが(両方orどちらか一方)無効な場合
                    
                    '@ﾏｽﾀ工順ｵﾌﾟｼｮﾝﾎﾞﾀﾝが有効か
                    If optMster.Enabled = True Then
                         If ActiveControl.name = cmbLotManager.Name Then 
                            '@ﾏｽﾀ工順ｵﾌﾟｼｮﾝﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(optMster)
                        End if
                    End If
                End If
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            
                '@"P"、"R"ｵﾌﾟｼｮﾝﾎﾞﾀﾝが両方有効か
                If optPrClass0.Enabled = True And _
                    optPrClass1.Enabled = True Then
                    
                    '@★ ﾁｪｯｸされているｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
                    Select Case True
                    
                        '@〓 "P"ｵﾌﾟｼｮﾝﾎﾞﾀﾝ 〓
                        Case optPrClass0.Checked = True
                            If ActiveControl.name = cmbLotManager.Name Then
                                '@"P"ｵﾌﾟｼｮﾝﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(optPrClass0)
                            End if
                        '@〓 "R"ｵﾌﾟｼｮﾝﾎﾞﾀﾝ 〓
                        Case optPrClass1.Checked = True
                            If ActiveControl.name = cmbLotManager.Name Then
                                '@"R"ｵﾌﾟｼｮﾝﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(optPrClass1)
                            End if
                    End Select
                Else
                    '@"P"、"R"ｵﾌﾟｼｮﾝﾎﾞﾀﾝが(両方orどちらか一方)無効な場合
                    If ActiveControl.name = cmbLotManager.Name Then 
                        '@作業ﾒﾓへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtWorkMemo)
                    End if
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbLotManager_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optPrClass_Click
    '機　能：P/R区分("P"or"R"ｵﾌﾟｼｮﾝﾎﾞﾀﾝ)　選択時処理
    '引　数：Index：　0：Pｵｰﾀﾞｰ、1:Rｵｰﾀﾞｰ
    '戻り値：なし
    '作成日：2005/12/21 (Wed) 13:33:20 T.Kitagawa
    '更新日：2008/06/09 (Mon) 16:26:03 N.Kojima
    '備　考：
    '　　　：2006/04/03 (Mon) 10:16:42 N.Kojima     P/Rｵｰﾀﾞｰｺﾒﾝﾄ追加に伴い処理追加(ﾕｰｻﾞｰ要望№0174)
    '　　　：2008/06/09 (Mon) 16:26:03 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub optPrClass_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optPrClass0.CheckedChanged, optPrClass1.CheckedChanged


        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ
        
        Try            
            With cmbPrOrder
                
                .Clear      'ｸﾘｱ

                '@★ ﾁｪｯｸされているｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
                Select Case True
                    
                    '@〓 "P"ｵﾌﾟｼｮﾝﾎﾞﾀﾝ 〓
                    Case optPrClass0.Checked

                        For llngCnt = 0 To mtypPrOrderListAns.lngPrOrderListCnt-1
                        
                            '@ｵｰﾀﾞｰﾘｽﾄのﾃﾞｰﾀの左1文字が"P"か
                            If Strings.Left$(mtypPrOrderListAns.typPrOrderList(llngCnt).strPROrderID, 1) = CPstrPrOrderClassP Then
                                
                                '@ｺﾝﾎﾞ内容設定：ｵｰﾀﾞｰID/ｵｰﾀﾞｰｺﾒﾝﾄ
                                .AddItem(mtypPrOrderListAns.typPrOrderList(llngCnt).strPROrderID _
                                        & vbTab _
                                        & mtypPrOrderListAns.typPrOrderList(llngCnt).strOrderComments)

                            End If
                        Next
                        
                        
                    '@〓 "R"ｵﾌﾟｼｮﾝﾎﾞﾀﾝ 〓
                    Case optPrClass1.Checked

                        For llngCnt = 0 To mtypPrOrderListAns.lngPrOrderListCnt-1
                        
                            '@ｵｰﾀﾞｰﾘｽﾄのﾃﾞｰﾀの左1文字が"R"か
                            If Strings.Left$(mtypPrOrderListAns.typPrOrderList(llngCnt).strPROrderID, 1) = CPstrPrOrderClassR Then
                                
                                '@ｺﾝﾎﾞ内容設定：ｵｰﾀﾞｰID/ｵｰﾀﾞｰｺﾒﾝﾄ
                                .AddItem(mtypPrOrderListAns.typPrOrderList(llngCnt).strPROrderID _
                                        & vbTab _
                                        & mtypPrOrderListAns.typPrOrderList(llngCnt).strOrderComments)
                            
                            End If
                        Next
                End Select
                
                '@P/RｵｰﾀﾞｰｺﾒﾝﾄにNULLを設定
                txtOrderComment.Text = vbNullString
                
                '@P/Rｵｰﾀﾞｰが1件か
                If .ListCount = 1 Then
                
                    '@ﾃﾞﾌｫﾙﾄで表示する
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
    '機　能：P/Rｵｰﾀﾞｰｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/21 (Wed) 13:19:49 T.Kitagawa
    '更新日：2008/06/09 (Mon) 16:32:25 N.Kojima
    '備　考：
    '　　　：2006/04/03 (Mon) 10:19:45 N.Kojima     P/Rｵｰﾀﾞｰｺﾒﾝﾄ追加に伴い処理追加(ﾕｰｻﾞｰ要望№0174)
    '　　　：2006/08/07 (Mon) 15:08:38 T.Kitagawa   P/Rｵｰﾀﾞｰ変更時は必須ﾁｪｯｸNGでもｺﾒﾝﾄ表示させる(案件№01362関連)
    '　　　：2008/06/09 (Mon) 16:32:25 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmbPrOrder_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPrOrder.Change
        
        Dim lblnAns As Boolean  '戻り値

        Try
                        
            '@P/Rｵｰﾀﾞｰｺﾒﾝﾄを表示
            '@値取得列をｺﾒﾝﾄに変更
            cmbPrOrder.ValueCol = 1
            txtOrderComment.Text = cmbPrOrder.Value
            txtOrderComment.Enabled = True
            '@値取得列を戻す
            cmbPrOrder.ValueCol = 0
             
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                
                '@P/Rｵｰﾀﾞｰが有効か
                If cmbPrOrder.Enabled = True Then
                    '@P/Rｵｰﾀﾞｰにﾌｫｰｶｽｾｯﾄ
                   'NSYS IF判定追加
                    If ActiveControl.Name = cmbPrOrder.Name Or ActiveControl.Name = optPrClass0.Name  Or ActiveControl.Name = optPrClass1.Name Then
                        Call pubSetFocus(cmbPrOrder)
                    End If
                End If
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
    '機　能：P/Rｵｰﾀﾞｰｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/21 (Wed) 13:12:15 T.Kitagawa
    '更新日：2008/06/09 (Mon) 16:30:59 N.Kojima
    '備　考：
    '　　　：2008/06/09 (Mon) 16:30:59 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmbPrOrder_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPrOrder.CloseUp

        Try
                       
            '@P/RｵｰﾀﾞｰｺﾝﾎﾞがNULL以外か
            If cmbPrOrder.Text <> vbNullString Then
            
                '@=======================
                '@　P/RｵｰﾀﾞｰｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbPrOrder.Validating, AddressOf cmbPrOrder_Validate
                Call cmbPrOrder_Validate(cmbPrOrder, New CancelEventArgs(True))
                AddHandler cmbPrOrder.Validating, AddressOf cmbPrOrder_Validate
            End If
            
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

    '関数名：cmbPrOrder_Validate
    '機　能：P/Rｵｰﾀﾞｰｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/12/21 (Wed) 13:22:45 T.Kitagawa
    '更新日：2008/06/09 (Mon) 16:34:28 N.Kojima
    '備　考：
    '　　　：2006/11/07 (Tue) 10:26:08 N.Kasai      送品先ｺﾝﾎﾞ追加(№01500)
    '　　　：2008/06/09 (Mon) 16:34:28 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmbPrOrder_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPrOrder.Validating

        Dim lblnAns     As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
                       
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
                
                '@送品が有効か
                If cmbLotSend.Enabled = True Then
                    If ActiveControl.Name = cmbPrOrder.Name 
                        '@送品にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbLotSend)
                    End if
                End If

            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                
                '@送品が有効か
                If cmbLotSend.Enabled = True Then
                    '@送品にﾌｫｰｶｽｾｯﾄ
                    'NSYS IF判定追加
                    If ActiveControl.Name = cmbPrOrder.Name Then
                        Call pubSetFocus(cmbLotSend)
                    End If
                Else
                    '@作業ﾒﾓにﾌｫｰｶｽｾｯﾄ
                   If ActiveControl.Name = cmbPrOrder.Name Then
                        Call pubSetFocus(txtWorkMemo)
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPrOrder_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtOrderComment_Change
    '機　能：P/Rｵｰﾀﾞｰｺﾒﾝﾄﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/31 (Fri) 16:55:22 N.Kojima
    '更新日：2008/06/10 (Tue) 09:39:04 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 09:39:04 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub txtOrderComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtOrderComment.Change

        Try
                        
            '@=======================
            '@　ﾃｷｽﾄ変更処理(共通処理)
            '@=======================
            Call pubtxtChange_Proc(txtOrderComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            
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
    '機　能：P/Rｵｰﾀﾞｰｺﾒﾝﾄﾃｷｽﾄ　ｷｰ押上時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2006/03/31 (Fri) 16:58:22 N.Kojima
    '更新日：2008/06/10 (Tue) 09:40:18 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 09:40:18 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub txtOrderComment_KeyUp(ByVal sender As Object, ByVal e As keyEventArgs) Handles txtOrderComment.KeyUp
        
        Try
            
            '@=======================
            '@　ﾃｷｽﾄｷｰ押上時処理(共通処理)
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtOrderComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
         
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
    '機　能：P/Rｵｰﾀﾞｰｺﾒﾝﾄﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2006/03/31 (Fri) 16:59:11 N.Kojima
    '更新日：2008/06/10 (Tue) 09:41:40 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 09:41:40 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub txtOrderComment_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtOrderComment.MouseUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄ変更時処理(共通処理)
            '@=======================
            Call pubtxtChange_Proc(txtOrderComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown, e.Button)
            
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
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(P/Rｵｰﾀﾞｰｺﾒﾝﾄ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/31 (Fri) 17:20:05 N.Kojima
    '更新日：2008/06/10 (Tue) 09:43:01 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 09:43:01 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmdCommentUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentUp.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ﾃｷｽﾄ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通処理)
            '@=======================
            Call pubtxtCmdUp_Proc(txtOrderComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            
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
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(P/Rｵｰﾀﾞｰｺﾒﾝﾄ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/31 (Fri) 17:21:14 N.Kojima
    '更新日：2008/06/10 (Tue) 09:46:07 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 09:46:07 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmdCommentDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                            
            '@=======================
            '@　ﾃｷｽﾄ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通処理)
            '@=======================
            Call pubtxtCmdDown_Proc(txtOrderComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

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

    '関数名：cmbLotSend_Change
    '機　能：送品ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/07 (Tue) 10:28:39 N.Kasai
    '更新日：2008/06/09 (Mon) 16:37:08 N.Kojima
    '備　考：
    '　　　：2008/06/09 (Mon) 16:37:08 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmbLotSend_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotSend.Change

        Dim lblnAns     As Boolean      '戻り値

        Try
                        
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合

                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                
                '@ﾛｯﾄ担当が有効か
                If cmbLotManager.Enabled = True Then
                    If ActiveControl.Name = txtWorkMemo.Name Then
                        '@ﾛｯﾄ担当にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbLotManager)
                    End if
                End If
            End If

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
    '機　能：送品ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/07 (Tue) 10:28:59 N.Kasai
    '更新日：2008/06/09 (Mon) 16:38:12 N.Kojima
    '備　考：
    '　　　：2008/06/09 (Mon) 16:38:12 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmbLotSend_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotSend.CloseUp

        Try
                       
            '@送品がNULL以外か
            If cmbLotSend.Text <> vbNullString Then
            
                '@=======================
                '@　送品ｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbLotSend.Validating, AddressOf cmbLotSend_Validate 
                Call cmbLotSend_Validate(cmbLotSend, New CancelEventArgs(True))
                AddHandler cmbLotSend.Validating, AddressOf cmbLotSend_Validate 
            End If
            
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

    '関数名：cmbLotSend_Validate
    '機　能：送品ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/11/07 (Tue) 10:29:17 N.Kasai
    '更新日：2008/06/09 (Mon) 16:39:15 N.Kojima
    '備　考：
    '　　　：2008/06/09 (Mon) 16:39:15 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmbLotSend_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbLotSend.Validating

        Dim lblnAns     As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
                       
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
                
                '@ﾏｽﾀ工順が有効か
                If optMster.Enabled = True Then
                    '@ﾏｽﾀ工順にﾌｫｰｶｽｾｯﾄ
                    'NSYS IF判定追加
                    If ActiveControl.Name = cmbLotSend.Name Then
                        Call pubSetFocus(optMster)
                    End If
                End If
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                
                '@作業ﾒﾓへｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = cmbLotManager.Name Then
                    Call pubSetFocus(txtWorkMemo)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbLotSend_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optDivide_Click
    '機　能：分割ﾛｯﾄID採番ｵﾌﾟｼｮﾝﾎﾞﾀﾝ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 18:47:11 K.Takano
    '更新日：2008/06/09 (Mon) 17:11:34 N.Kojima
    '備　考：
    '　　　：2005/06/23 (Thu) 13:10:07 S.Deguchi    退避領域のｸﾘｱ処理を追加
    '　　　：2005/12/21 (Wed) 12:07:55 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(ﾕｰｻﾞｰ要望№0134)
    '　　　：2006/04/03 (Mon) 09:19:45 N.Kojima     P/Rｵｰﾀﾞｰｺﾒﾝﾄ追加に伴い処理追加(ﾕｰｻﾞｰ要望№0174)
    '　　　：2006/10/31 (Tue) 13:39:31 N.Kasai      送品ｺﾝﾎﾞ追加
    '　　　：2008/06/09 (Mon) 17:11:34 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub optDivide_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optDivide.CheckedChanged

        Dim lblnAns     As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            
            '@***********************
            '@　各種ｺﾝﾄﾛｰﾙの有効/無効制御、背景色設定を行なう
            '@***********************
            
            '@-----------------------
            '@　新規ﾛｯﾄID採番関連制御(無効)
            '@-----------------------
            cmbPD.ListIndex = -1                            '機種：ｸﾘｱ
            cmbPD.Enabled = False                           '機種：無効
            cmbPD.BackColor = vbButtonFace                  '機種：背景色はｸﾞﾚｰ
            cmbDivision.ListIndex = -1                      '種別：ｸﾘｱ
            cmbDivision.Enabled = False                     '種別：無効
            cmbDivision.BackColor = vbButtonFace            '種別：背景色はｸﾞﾚｰ
            txtWFNum.Text = 0                               'WF枚数：0
            txtWFNum.Enabled = False                        'WF枚数：無効
            txtWFNum.BackColor = vbButtonFace               'WF枚数：背景色はｸﾞﾚｰ
            calStartDate.Value = _
                Format$(Now, CPstrDateTimeYMD)              '投入予定日：現在日
            calStartDate.Enabled = False                    '投入予定日：無効
            calStartDate.BackColor = vbButtonFace           '投入予定日：背景色はｸﾞﾚｰ
            cmbLotManager.ListIndex = -1                    'ﾛｯﾄ担当：ｸﾘｱ
            cmbLotManager.Enabled = False                   'ﾛｯﾄ担当：無効
            cmbLotManager.BackColor = vbButtonFace          'ﾛｯﾄ担当：背景色はｸﾞﾚｰ
            
            '@P/Rｵｰﾀﾞｰ関連の制御
            fraPrClass.Enabled = False                      'P/R区分ﾌﾚｰﾑ：無効
            optPrClass0.Enabled = False                     'P：無効
            optPrClass1.Enabled = False                     'R：無効
            optPrClass0.Checked  = False                    'P：ﾁｪｯｸなし
            optPrClass1.Checked  = False                    'R：ﾁｪｯｸなし
            cmbPrOrder.ListIndex = -1                       'P/Rｵｰﾀﾞｰ：ｸﾘｱ
            cmbPrOrder.Enabled = False                      'P/Rｵｰﾀﾞｰ：無効
            cmbPrOrder.BackColor = vbButtonFace             'P/Rｵｰﾀﾞｰ：背景色はｸﾞﾚｰ
            
            '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄の制御
            txtOrderComment.Text = vbNullString             'P/Rｵｰﾀﾞｰｺﾒﾝﾄ：NULL
            txtOrderComment.Enabled = False                 'P/Rｵｰﾀﾞｰｺﾒﾝﾄ：無効
            txtOrderComment.Locked = True                   'P/Rｵｰﾀﾞｰｺﾒﾝﾄ：ﾛｯｸ
            
            '@送品関連の制御
            cmbLotSend.Enabled = False                      '送品：無効
            cmbLotSend.ListIndex = -1                       '送品：ｸﾘｱ
            
            
            '@-----------------------
            '@　分割ﾛｯﾄID採番関連制御(有効)
            '@-----------------------
            txtDivideLotID.Enabled = True                   '分割元ﾛｯﾄID：有効
            txtDivideLotID.BackColor = vbWhite              '分割元ﾛｯﾄID：背景色は白
            cmdDivideLotID.Enabled = True                   '分割元ﾛｯﾄIDﾎﾞﾀﾝ：有効
            cmdDivideLotID.BackColor = vbWhite              '分割元ﾛｯﾄIDﾎﾞﾀﾝ：背景色は白


            '@退避領域のｸﾘｱ
            mstrPdName = vbNullString


            '@-----------------------
            '@　ﾏｽﾀ工順
            '@-----------------------
            lblEntryID.Text = vbNullString                 'ｴﾝﾄﾘ
            lblEntryName.Text = vbNullString               'ｴﾝﾄﾘ名
          
          
            '@-----------------------
            '@　工順ｺﾋﾟｰ
            '@-----------------------
            optCopy.Checked  = True                        'ﾁｪｯｸあり
            
            
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optDivide_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtDivideLotID_Change
    '機　能：分割元ﾛｯﾄIDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 19:18:54 M.Miura
    '更新日：2008/06/09 (Mon) 16:41:17 N.Kojima
    '備　考：
    '　　　：2004/09/26 (Sun) 18:54:53 H.Wajima     分割予定ﾛｯﾄ登録対応
    '　　　：2008/06/09 (Mon) 16:41:17 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub txtDivideLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtDivideLotID.Change

        Try
            
            '@分割元ﾛｯﾄID退避用変数を初期化
            mstrDivideLotID = vbNullString
            
            '@ｴﾝﾄﾘ情報の初期化
            lblEntryID.Text = vbNullString           'ｴﾝﾄﾘ
            lblEntryName.Text = vbNullString         'ｴﾝﾄﾘ名
            
            '@★ 起動区分により処理分岐 ★
            Select Case plngfrmxxCM00M0Kbn
                
                '@〓 0：投入予定ﾛｯﾄ登録 〓
                Case CMlngfrmCM00M0Flag0
                
                    '@分割元ﾛｯﾄIDの入力桁数が0Byte以上か
                    If Len(txtDivideLotID.Text) > 0 Then
                    
                        '@=======================
                        '@　ﾛｯﾄ工順情報ﾌｨｰﾙﾄﾞ使用可/不可設定処理
                        '@=======================
                        Call prvLotProcessInfoFieldControl_Proc()
                    Else
                        '@分割元ﾛｯﾄIDの入力桁数が0Byte以下の場合
                    
                        '@=======================
                        '@　ﾛｯﾄ工順情報ﾌｨｰﾙﾄﾞ使用不可設定処理
                        '@=======================
                        Call prvLotProcessInfoFieldDisable_Proc()
                    End If
                
                
                '@〓 その他：分割予定ﾛｯﾄ登録 〓
                Case Else
                    
                    '@=======================
                    '@　ﾛｯﾄ工順情報分割ﾛｯﾄ登録時処理
                    '@=======================
                    Call prvLotDivideObjectControl_Proc()

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtDivideLotID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtDivideLotID_Validate
    '機　能：分割元ﾛｯﾄIDﾃｷｽﾄ　Validate処理(入力確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 13:22:14 M.Miura
    '更新日：2008/06/09 (Mon) 16:45:40 N.Kojima
    '備　考：
    '　　　：2006/10/31 (Tue) 15:41:38 N.Kasai      送品ｺﾝﾎﾞ対応
    '　　　：2008/06/09 (Mon) 16:45:40 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2008/09/05 (Fri) 08:18:36 T.Sawaguchi  異機種間ｺﾋﾟｰ禁止(案件№03141)
    '　　　：2008/10/17 (Fri) 07:59:52 T.Sawaguchi  異機種間ｺﾋﾟｰ禁止ﾊﾞｸﾞ修正：記述削除(案件№03229)
    Private Sub txtDivideLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtDivideLotID.Validating

        Dim llngCnt             As Integer      'ｶｳﾝﾀ変数
        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK、False:NG)
        Dim lblnProFlg          As Boolean      '機種一致ﾌﾗｸﾞ(一致あり:True、なし:False)
        Dim lblnAnsLot          As Boolean      '結果取得(True:正常、False:異常)
        Dim lblnFlgAns          As Boolean      '結果取得(True:正常、False:異常)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose Then
                Exit Sub
            End If 
            
            '@分割元ﾛｯﾄIDが前回入力値と同じか
            If mstrDivideLotID = txtDivideLotID.Text Then
            
                '@分割元ﾛｯﾄIDﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                'NSYS IF判定追加
                If ActiveControl.Name = txtDivideLotID.Name Then
                    Call pubSetFocus(cmdDivideLotID)
                End If
                
                Exit Sub
            End If
                
         '@↓2008/09/05 (Fri) 08:18:36 T.Sawaguchi 案件03141 **************************
                '@機種変数の初期化
            mstrDivideLotPdID = vbNullString
        '@↑2008/09/05 (Fri) 08:18:36 T.Sawaguchi 案件03141 **************************

                
            '@機種一致ﾌﾗｸﾞを初期化する
            lblnProFlg = False
            
            '@分割元ﾛｯﾄID採番にﾁｪｯｸされているか
            If optDivide.Checked = True Then
            
                For llngCnt = 0 To mlngPdCnt-1
                    
                    '@分割元ﾛｯﾄIDの上3桁が機種ID一覧に存在するかﾁｪｯｸ
                    If Strings.Left(txtDivideLotID.Text, CMlngPdIDLength) = mtypPdList(llngCnt).strProductID Then
                        
                        '@機種一致ﾌﾗｸﾞに"True：機種一致あり"をｾｯﾄ
                        lblnFlgAns = True
                        Exit For
                    Else
                        '@存在しない場合
                    
                        '@機種一致ﾌﾗｸﾞに"False：機種一致なし"をｾｯﾄ
                        lblnFlgAns = False
                    End If
                Next
            End If
            
            '@分割元ﾛｯﾄIDが10桁か
            If Len(txtDivideLotID.Text) = CMlngLotIDByte Then
                
                '@【ﾛｯﾄ現在状態取得】ﾒｯｾｰｼﾞ送受信処理   ※処理区分：分割元ロットID(流動前、流動中)
                lblnAnsLot = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                   CPstrCD36, _
                                                   vbNullString, _
                                                   mtypLotCurState, _
                                                   txtDivideLotID.Text)
                
                '@ﾛｯﾄ現在状態取得結果判定
                If lblnAnsLot = True Then
                    '@ﾛｯﾄ現在状態取得結果：正常の場合
                    
        '@↓2008/09/05 (Fri) 06:08:52 T.Sawaguchi 案件03141 **************************
                    '@分割元ﾛｯﾄIDの機種をｾｯﾄ
                    mstrDivideLotPdID = mtypLotCurState.strPdId
        '@↑2008/09/05 (Fri) 06:08:52 T.Sawaguchi 案件03141 **************************
                    '@入力分割元ﾛｯﾄIDを退避領域に格納
                    mstrDivideLotID = txtDivideLotID.Text
                    
                    '@-----------------------
                    '@　送品ｺﾝﾎﾞの設定
                    '@-----------------------
                    '@★ 送品ﾌﾗｸﾞにより処理分岐 ★
                    Select Case mtypLotCurState.strLotSendFlag
                    
                        '@〓 0：送品なし 〓
                        Case CPlngLotSendNasi
                        
                            '@送品に"なし"を表示する
                            cmbLotSend.ListIndex = 0
                            
                        '@〓 1：送品あり 〓
                        Case CPlngLotSendAri
                        
                            '@送品に"あり"を表示する
                            cmbLotSend.ListIndex = 1
                        
                        '@〓 その他 〓
                        Case Else
                        
                            '@送品にNULLを表示
                            cmbLotSend.ListIndex = -1
                            
                    End Select
                    
                    '@機種一致ﾌﾗｸﾞが"True：機種一致あり"か
                    If lblnFlgAns = True Then
                    
                        '@=======================
                        '@　ﾏｽﾀ工順取得＆表示処理
                        '@=======================
                        Call prvMasEntryList_Sel()
                    Else
                        '@機種一致ﾌﾗｸﾞが"False：機種一致なし"か
                    
                        '@ｴﾝﾄﾘ情報をｸﾘｱ
                        lblEntryID.Text = vbNullString       'ｴﾝﾄﾘ
                        lblEntryName.Text = vbNullString     'ｴﾝﾄﾘ名
                    End If
                    
                    
                    '@=======================
                    '@　入力ﾁｪｯｸ処理
                    '@=======================
                    lblnAns = prvblnInput_Chk(CMlngCreateInfo)
                    
                    '@処理結果判定
                    If lblnAns = True Then
                        '@結果：正常の場合
                        
                        '@=======================
                        '@　確定ﾎﾞﾀﾝ制御処理
                        '@=======================
                        Call prvCmdRegistControl_Proc()
                    Else
                        '@結果：異常の場合
                    
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    End If
                    
                    '@分割ﾛｯﾄIDﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmdDivideLotID)
                Else
                    '@ｴﾝﾄﾘ情報をｸﾘｱ
                    lblEntryID.Text = vbNullString           'ｴﾝﾄﾘ
                    lblEntryName.Text = vbNullString         'ｴﾝﾄﾘ名
                    
                    '@ﾌｫｰｶｽ保持
                    e.Cancel = True
                    Exit Sub
                End If
                        
            Else
                '@分割元ﾛｯﾄIDが10桁以外の場合
            
                '@分割元ﾛｯﾄIDがNULL以外か
                If txtDivideLotID.Text <> vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                    '@ﾒｯｾｰｼﾞ："<TRM12W>$$ロットIDは10桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    '@ﾌｫｰｶｽ保持
                    e.Cancel = True
                    
                    '@確定ﾎﾞﾀﾝを無効にする
                    cmdRegist.Enabled = False
                    
                Else
                    '@分割元ﾛｯﾄIDがNULLの場合
                
                    '@=======================
                    '@　入力ﾁｪｯｸ処理
                    '@=======================
                    lblnAns = prvblnInput_Chk(CMlngCreateInfo)
                    
                    '@処理結果判定
                    If lblnAns = True Then
                        '@結果：正常の場合
                    
                        '@=======================
                        '@　確定ﾎﾞﾀﾝ制御処理
                        '@=======================
                        Call prvCmdRegistControl_Proc()
                    Else
                        '@結果：異常の場合
                    
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    End If
                    
                    '@分割ﾛｯﾄIDﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmdDivideLotID)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtDivideLotID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDivideLotID_Click
    '機　能：分割元ﾛｯﾄIDﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/21 (Wed) 15:58:59 Y.Yamagishi
    '更新日：2008/08/07 (Thu) 14:12:06 M.Koni
    '備　考：
    '　　　：2004/09/24 (Fri) 09:12:02 Y.Yamagishi　分割元ﾛｯﾄID退避処理追加
    '　　　：2005/06/23 (Thu) 15:17:35 S.Deguchi    分割元ﾛｯﾄID未取得時に既選択情報が消えるのを修正
    '　　　：2006/10/31 (Tue) 15:17:58 N.Kasai      送品ｺﾝﾎﾞ対応
    '　　　：2008/06/09 (Mon) 17:01:57 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2008/08/06 (Wed) 16:37:38 M.Koni       PD_LIST検索条件変更 <案件No.02938>
    '　　　：2008/09/05 (Fri) 07:54:52 T.Sawaguchi  異機種間ｺﾋﾟｰ禁止(案件№03141)
    '　　　：2008/10/17 (Fri) 07:59:52 T.Sawaguchi  異機種間ｺﾋﾟｰ禁止ﾊﾞｸﾞ修正(案件№03229)
    Private Sub cmdDivideLotID_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDivideLotID.Click
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
  
            
            '@Form_Loadﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            '@***********************
            '@　引継ぎﾃﾞｰﾀ作成
            '@***********************
            With ptypCM00J0
                .lngListIndex = -1
        '@↓2008/08/06 (Wed) 16:37:38 M.Koni **************************************************
        '        .strClassDivisionPdlist = CPstrCD2A & CPstrCD02         '機種ﾘｽﾄ取得時の処理区分：2A02
                .strClassDivisionPdlist = CPstrCD2A & CPstrCD1Y         '機種ﾘｽﾄ取得時の処理区分：2A1Y
        '@↑2008/08/06 (Wed) 16:37:38 M.Koni **************************************************
                .strClassDivisionTravlist = CPstrCD36                   'ﾛｯﾄ現在状態取得時の取得時の処理区分：流動終了以外
                
        '@↓2008/09/05 (Fri) 07:53:10 T.Sawaguchi 案件03141 **************************
                '@.strPdID = Left(frmxxCM00M0.txtDivideLotID.Text, 3)     '機種ID
                
            '@↓2008/10/16 (Thu) 17:13:16 T.Sawaguchi 案件03229 **************************
                '@ｺﾋﾟｰ元ﾛｯﾄIDがある場合は機種を渡すが、無い場合はNULLにする。
                If Me.txtDivideLotID.Text = vbNullString Then
                    mstrDivideLotPdID = vbNullString
                End If
            '@↑2008/10/16 (Thu) 17:13:16 T.Sawaguchi 案件03229 **************************
                        
                .strPdId = mstrDivideLotPdID                           '@分割元ﾛｯﾄIDの機種をｾｯﾄ
                .strLotID = vbNullString                                'ﾛｯﾄID
                .strUserProcessFlag = vbNullString                      '投入予定工順登録(組立)から工順作成ﾁｪｯｸから呼ばれた場合のﾌﾗｸﾞ
        '@↑2008/09/05 (Fri) 07:53:10 T.Sawaguchi 案件03141 **************************
            End With

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　分割元ﾛｯﾄID検索画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00J0.Instance = New frmxxCM00J0()

            '@分割元ﾛｯﾄID検索画面のﾌｫｰﾑ名称の設定
            frmxxCM00J0.Instance.Text = CPstrSubDispTitleDiviLotSel

            '@子画面のLoad処理にて、Form_Loadﾌﾗｸﾞが"False：異常"のままか
            If pblnFormLoad = False Then
            
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00J0.Instance = Nothing
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　分割元ﾛｯﾄID検索画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00J0.Instance.ShowDialog(Me)
            frmxxCM00J0.Instance = Nothing

            '@(引継ぎ構造体の)ﾛｯﾄIDがNULL以外か
            If ptypCM00J0.strLotID <> vbNullString Then
            
                '@ﾛｯﾄIDを分割元ﾛｯﾄIDにｾｯﾄ
                txtDivideLotID.Text = ptypCM00J0.strLotID
                
                '@=======================
                '@　分割元ﾛｯﾄIDのValidate処理
                '@=======================
                RemoveHandler txtDivideLotID.Validating , AddressOf txtDivideLotID_Validate
                Call txtDivideLotID_Validate(txtDivideLotID, New CancelEventArgs(True))
                AddHandler txtDivideLotID.Validating , AddressOf txtDivideLotID_Validate
            End If

            '@分割元ﾛｯﾄIDがNULL以外か
            If txtDivideLotID.Text <> vbNullString Then
            
                '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
        '        '@機種をｾｯﾄ
        '        mstrDivideLotPdID = ptypCM00J0.strReturnPdid
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDivideLotID_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optMster_Click
    '機　能：ﾏｽﾀ工順ｵﾌﾟｼｮﾝﾎﾞﾀﾝ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/23 (Mon) 10:35:49 M.Miura
    '更新日：2008/06/10 (Tue) 08:40:06 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 08:40:06 N.Kojima
    Private Sub optMster_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optMster.CheckedChanged

        Dim lblnAns         As Boolean          '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御ﾌﾗｸﾞが"True：ｽｷｯﾌﾟ"か
            If mblnOptButtonEventControlFlag = True Then
                Exit Sub
            End If
            
            '@-----------------------
            '@　ﾏｽﾀ工順制御
            '@-----------------------
            '@新規ﾛｯﾄID採番にﾁｪｯｸされているか
            If optNew.Checked  = True Then
            
                '@機種がNULL以外か
                If cmbPD.Text <> vbNullString Then
                    '@ｴﾝﾄﾘﾎﾞﾀﾝを有効にする
                    cmdEntry.Enabled = True
                Else
                    '@ｴﾝﾄﾘﾎﾞﾀﾝを無効にする
                    cmdEntry.Enabled = False
                End If
            End If

            '@-----------------------
            '@　工順ｺﾋﾟｰ制御(無効)
            '@-----------------------
            txtCopyLotID.Enabled = False                '工順ｺﾋﾟｰﾛｯﾄID：無効
            txtCopyLotID.BackColor = vbButtonFace       '工順ｺﾋﾟｰﾛｯﾄID：背景色はｸﾞﾚｰ
            cmdCopyLotID.Enabled = False                '工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ：無効
            

            '@分割ﾛｯﾄID採番にﾁｪｯｸされているか
            If optDivide.Checked  = True Then
            
                '@分割元ﾛｯﾄIDがNULL以外か
                If txtDivideLotID.Text <> vbNullString Then
                    '@ｴﾝﾄﾘﾎﾞﾀﾝを有効にする
                    cmdEntry.Enabled = True
                Else
                    '@ｴﾝﾄﾘﾎﾞﾀﾝを無効にする
                    cmdEntry.Enabled = False
                End If
            End If
            
            
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngOrderInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optMster_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdEntry_Click
    '機　能：ｴﾝﾄﾘﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 14:17:09 Y.Yamagishi
    '更新日：2008/06/10 (Tue) 11:14:16 N.Kojima
    '備　考：
    '　　　：2004/08/27 (Fri) 10:35:04 N.Kojima     起動区分指定を「"1":全件取得」指定に変更
    '　　　：2008/06/10 (Tue) 11:14:16 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmdEntry_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEntry.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@新規ﾛｯﾄID採番にﾁｪｯｸされているか
            If optNew.Checked = True Then
                '@機種IDを退避
                pstrPDID = cmbPD.Text
            Else
                '@機種IDの退避
                pstrPDID = Strings.Left$(txtDivideLotID.Text, 3)
            End If
            
            '@起動区分を指定("1":全件取得)
            plngfrmxxCM00F0Kbn = CMlngPDEntryALL
            
            '@引継ぎﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrEntryID = vbNullString          'ｴﾝﾄﾘ
            pstrEntryName = vbNullString        'ｴﾝﾄﾘ名
            pstrMaxWFCount = vbNullString       '最大WF枚数
            
            '@Form_Loadﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　機種ｴﾝﾄﾘ選択画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00F0.Instance = New frmxxCM00F0()
            
            '@子画面のLoad処理にて、Form_Loadﾌﾗｸﾞが"False：異常"のままか
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00F0.Instance = Nothing
                
                Exit Sub
            End If
            
            '@機種ｴﾝﾄﾘ選択画面のﾌｫｰﾑ名称を設定
            frmxxCM00F0.Instance.Text = CPstrSubDispTitlePDEntryList
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　機種ｴﾝﾄﾘ選択画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00F0.Instance.ShowDialog(Me)
            frmxxCM00F0.Instance = Nothing
            
            
            '@ｴﾝﾄﾘ名(ﾊﾟﾌﾞﾘｯｸ変数)がNULL以外か　※子画面にてｴﾝﾄﾘが選択されたか
            If pstrEntryName <> vbNullString Then
                
                '@子画面の選択情報を反映
                lblEntryID.Text = pstrEntryID            'ｴﾝﾄﾘ
                lblEntryName.Text = pstrEntryName        'ｴﾝﾄﾘ名
                
                '@新規ﾛｯﾄID採番にﾁｪｯｸされているか
                If optNew.Checked = True Then
                
                    '@WF枚数をｾｯﾄ
                    txtWFNum.Text = pstrMaxWFCount
                    
                    '@ｴﾝﾄﾘに紐付く最大WF枚数を退避
                    mlngPdEntryMaxWFCount = txtWFNum.Text
                End If
                
                '@確定ﾎﾞﾀﾝを有効にする
                cmdRegist.Enabled = True
                
                '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdRegist)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdEntry_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optCopy_Click
    '機　能：工順ｺﾋﾟｰｵﾌﾟｼｮﾝﾎﾞﾀﾝ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/23 (Mon) 10:35:17 M.Miura
    '更新日：2008/06/10 (Tue) 08:35:25 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 08:35:25 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub optCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optCopy.CheckedChanged
        
        Dim lblnAns     As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try            
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御ﾌﾗｸﾞが"True：ｽｷｯﾌﾟ"か
            If mblnOptButtonEventControlFlag = True Then
                Exit Sub
            End If
            
            '@-----------------------
            '@　ﾏｽﾀ工順制御(無効)
            '@-----------------------
            cmdEntry.Enabled = False            'ｴﾝﾄﾘﾎﾞﾀﾝ：無効
            
            '@-----------------------
            '@　工順ｺﾋﾟｰ制御(有効)
            '@-----------------------
            txtCopyLotID.Enabled = True         '工順ｺﾋﾟｰﾛｯﾄID：有効
            txtCopyLotID.BackColor = vbWhite    '工順ｺﾋﾟｰﾛｯﾄID：背景色は白
            cmdCopyLotID.Enabled = True         '工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ：有効
            
            
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngOrderInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optCopy_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCopyLotID_Change
    '機　能：工順ｺﾋﾟｰﾛｯﾄIDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 19:35:44 M.Miura
    '更新日：2008/06/10 (Tue) 09:11:53 N.Kojima
    '備　考：
    '　　　：2004/09/26 (Sun) 19:07:24 H.Wajima     分割予定ﾛｯﾄ登録対応
    '　　　：2008/06/10 (Tue) 09:11:53 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub txtCopyLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCopyLotID.Change
        
        Dim lblnAns     As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
                        
            '@工順ｺﾋﾟｰﾛｯﾄID退避領域の初期化
            mstrCopyLotID = vbNullString
             
            '@★ 起動区分により処理分岐 ★
            Select Case plngfrmxxCM00M0Kbn
                
                '@〓 0：投入予定ﾛｯﾄ登録 〓
                Case CMlngfrmCM00M0Flag0
                    
                    '@=======================
                    '@　入力ﾁｪｯｸ処理
                    '@=======================
                    lblnAns = prvblnInput_Chk(CMlngOrderInfo)
                    
                    '@処理結果判定
                    If lblnAns = True Then
                        '@結果：正常の場合
                        
                        '@=======================
                        '@　確定ﾎﾞﾀﾝ制御処理
                        '@=======================
                        Call prvCmdRegistControl_Proc()
                    Else
                        '@結果：異常の場合
                    
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    End If
                    
                
                '@〓 その他：分割予定ﾛｯﾄ登録 〓
                Case Else
                
                    '@工順ｺﾋﾟｰﾛｯﾄIDがNULLか
                    If txtCopyLotID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    Else
                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdRegist.Enabled = True
                    End If
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCopyLotID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCopyLotID_Validate
    '機　能：工順ｺﾋﾟｰﾛｯﾄIDﾃｷｽﾄ　Validate処理(入力確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 13:24:22 M.Miura
    '更新日：2008/06/10 (Tue) 09:20:38 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 09:20:38 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2008/09/03 (Wed) 11:34:03 T.Sawaguchi  異機種間ｺﾋﾟｰを禁止 (案件No03141)
    '　　　：2008/09/22 (Mon) 06:24:03 T.Sawaguchi  新規登録か、ﾛｯﾄ指定のﾁｪｯｸ追加 (案件No03141)

    Private Sub txtCopyLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCopyLotID.Validating
        
        Dim lblnAns         As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)
        Dim lblnAnsLot      As Boolean      '結果取得(True:正常,False:異常)

        Try
            
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            

            '@起動区分が"0：投入予定ﾛｯﾄ登録"か
            If plngfrmxxCM00M0Kbn = CMlngfrmCM00M0Flag0 Then

                '@入力工順ｺﾋﾟｰﾛｯﾄIDが前回入力値と同じか
                If mstrCopyLotID = txtCopyLotID.Text Then
                    '@工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdCopyLotID)
                    Exit Sub
                End If
                
                '@工順ｺﾋﾟｰにﾁｪｯｸされているか
                If optCopy.Checked = True Then
                
                    '@工順ｺﾋﾟｰﾛｯﾄIDが10桁以外、かつNULL以外の場合
                    If Len(txtCopyLotID.Text) <> CMlngLotIDByte And _
                        txtCopyLotID.Text <> vbNullString Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                        '@ﾒｯｾｰｼﾞ："<TRM12W>$$ロットIDは10桁で入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾌｫｰｶｽ保持
                        e.Cancel = True
                    Else
                    
                        '@工順ｺﾋﾟｰﾛｯﾄIDが10桁、またはNULLの場合
                        '@工順ｺﾋﾟｰﾛｯﾄIDがNULL以外か
                        If txtCopyLotID.Text <> vbNullString Then
                            
                        
                            '@【ﾛｯﾄ現在状態取得】ﾒｯｾｰｼﾞ送受信処理   ※処理区分：0Q(ﾛｯﾄ工順)
                            lblnAnsLot = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                               CPstrCD0Q, _
                                                               vbNullString, _
                                                               mtypLotCurState, _
                                                               txtCopyLotID.Text)

                            '@ﾛｯﾄ現在状態取得結果判定
                            If lblnAnsLot = True Then
                                '@ﾛｯﾄ現在状態取得結果：正常の場合
                            
        '@↓2008/09/22 (Mon) 06:24:42 T.Sawaguchi 案件03141 **************************
                                '@工順ｺﾋﾟｰﾛｯﾄIDの機種が違う場合は、ｴﾗｰとして投入予約不可とする。
                                '@選択された機種と親機種をﾁｪｯｸする。
                                
                                '@新規登録か工順ｺﾋﾟｰを判定する　9/22　追加)
                                If optNew.Checked = True Then
                                    
                                    '@新規登録で工順ｺﾋﾟｰをする場合
                                    If mtypLotCurState.strPdId <> cmbPD.Text Then
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005J)
                                        '@ﾒｯｾｰｼﾞ： "<TRM5JW>$$機種が異なります。同一機種のロットを設定してください。"
                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                                        '@ﾌｫｰｶｽ保持
                                        e.Cancel = True
                                        Exit Sub
                                    End If
                                Else
                                    
                                    '@ﾛｯﾄId指定で工順ｺﾋﾟｰをする場合
                                    If mtypLotCurState.strPdId <> mstrDivideLotPdID Then 'mbPd.Text Then
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005J)
                                        '@ﾒｯｾｰｼﾞ： "<TRM5JW>$$機種が異なります。同一機種のロットを設定してください。"
                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                                        '@ﾌｫｰｶｽ保持
                                        e.Cancel = True
                                        Exit Sub
                                    End If
                                End If
        '@↑2008/09/22 (Mon) 06:24:42 T.Sawaguchi 案件03141 **************************
                            
                            
                                '@工順ｺﾋﾟｰﾛｯﾄIDを退避する
                                mstrCopyLotID = txtCopyLotID.Text
                                
                                '@=======================
                                '@　入力ﾁｪｯｸ処理
                                '@=======================
                                lblnAns = prvblnInput_Chk(CMlngOrderInfo)
                                
                                '@処理結果判定
                                If lblnAns = True Then
                                    '@結果：正常の場合
                                
                                    '@=======================
                                    '@　確定ﾎﾞﾀﾝ制御処理
                                    '@=======================
                                    Call prvCmdRegistControl_Proc()
                                Else
                                    '@結果：異常の場合
                                
                                    '@確定ﾎﾞﾀﾝを無効にする
                                    cmdRegist.Enabled = False
                                End If
                                
                                '@工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                                'NSYS IF判定追加
                                 If ActiveControl.Name = txtCopyLotID.Name Then
                                   Call pubSetFocus(cmdCopyLotID)
                                 End If
                                
                            Else
                                '@ﾛｯﾄ現在状態取得結果：異常の場合
                            
                                '@ﾌｫｰｶｽ保持
                                e.Cancel = True
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCopyLotID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCopyLotID_Click
    '機　能：工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/18 (Wed) 20:57:17 M.Miura
    '更新日：2008/08/07 (Thu) 14:09:18 M.Koni
    '備　考：
    '　　　：2004/09/24 (Fri) 09:11:03 Y.Yamagishi  工順ｺﾋﾟｰﾛｯﾄID退避処理追加
    '　　　：2005/06/23 (Thu) 15:17:35 S.Deguchi    工順ｺﾋﾟｰﾛｯﾄID未取得時に既選択情報が消えるのを修正
    '　　　：2008/06/10 (Tue) 09:29:53 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2008/08/06 (Wed) 16:38:47 M.Koni       PD_LIST検索条件変更 <案件No.02938>
    '　　　：2008/09/05 (Fri) 06:28:27 T.Sawaguchi  異機種間ｺﾋﾟｰ禁止の為工順ｺﾋﾟｰﾛｯﾄIDのﾁｪｯｸを追加　(案件03141)

    Private Sub cmdCopyLotID_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopyLotID.Click
        
        Dim lblnAns     As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
                
            '@Form_Loadﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            '@***********************
            '@　引継ぎﾃﾞｰﾀ作成
            '@***********************
            With ptypCM00J0
                .lngListIndex = cmbPD.ListIndex
        '@↓2008/08/06 (Wed) 16:38:47 M.Koni **************************************************
        '        .strClassDivisionPdlist = CPstrCD2A & CPstrCD02     '機種ﾘｽﾄ取得時の処理区分：2A02
                .strClassDivisionPdlist = CPstrCD2A & CPstrCD1Y     '機種ﾘｽﾄ取得時の処理区分：2A1Y
        '@↑2008/08/06 (Wed) 16:38:47 M.Koni **************************************************
                .strClassDivisionTravlist = CPstrCD02               'ﾛｯﾄ現在状態取得時の取得時の処理区分：02
        '@↓2008/09/05 (Fri) 06:28:27 T.Sawaguchi 案件03141 **************************
                '.strPdID = vbNullString                             '機種ID：NULL
                .strPdId = mstrDivideLotPdID                        '分割元ﾛｯﾄIDの機種
        '@↑2008/09/05 (Fri) 06:28:27 T.Sawaguchi 案件03141 **************************
                .strLotID = vbNullString                            'ﾛｯﾄID：NULL
                .strUserProcessFlag = vbNullString                   '投入予定工順登録(組立)から工順作成ﾁｪｯｸから呼ばれた場合のﾌﾗｸﾞ
            End With


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　ｺﾋﾟｰ元ﾛｯﾄID検索画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00J0.Instance = New frmxxCM00J0()

            '@ｺﾋﾟｰ元ﾛｯﾄID検索画面のﾌｫｰﾑ名称の設定
            frmxxCM00J0.Instance.Text = CPstrSubDispTitleCopyLotSel

            '@子画面のLoad処理にて、Form_Loadﾌﾗｸﾞが"False：異常"のままか
            If pblnFormLoad = False Then
            
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00J0.Instance = Nothing
                
                Exit Sub
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　ｺﾋﾟｰ元ﾛｯﾄID検索画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00J0.Instance.ShowDialog(Me)
            frmxxCM00J0.Instance = Nothing
            
            '@(引継ぎ構造体の)ﾛｯﾄIDがNULL以外か
            If ptypCM00J0.strLotID <> vbNullString Then
                
                '@工順ｺﾋﾟｰﾛｯﾄIDにｾｯﾄ
                txtCopyLotID.Text = ptypCM00J0.strLotID
                
                '@退避用工順ｺﾋﾟｰﾛｯﾄIDに格納
                mstrCopyLotID = txtCopyLotID.Text
            End If
            
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk(CMlngOrderInfo)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@=======================
                '@　確定ﾎﾞﾀﾝ制御処理
                '@=======================
                Call prvCmdRegistControl_Proc()
            Else
                '@結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If

            '@工順ｺﾋﾟｰﾛｯﾄIDがNULL以外か
            If txtCopyLotID.Text <> vbNullString Then
                '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCopyLotID_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：txtWorkMemo_Change
    '機　能：作業ﾒﾓﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 14:26:41 N.Kasai
    '更新日：2008/06/10 (Tue) 09:46:58 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 11:01:07 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    '　　　：2008/06/10 (Tue) 09:46:58 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Dim llngNowByte         As Integer      'ﾊﾞｲﾄ数格納用

        Try
                       
            '@現在のﾊﾞｲﾄ数を格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@=======================
            '@　ﾃｷｽﾄ変更時処理(共通処理)
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)
            
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
    '機　能：作業ﾒﾓﾃｷｽﾄ　ｷｰ押上時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/12/02 (Fri) 10:18:12 N.Kojima
    '更新日：2008/06/10 (Tue) 09:48:48 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 09:48:48 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As keyEventArgs) Handles txtWorkMemo.KeyUp
        
        Try
                       
            '@=======================
            '@　ﾃｷｽﾄｷｰ押上時処理(共通処理)
            '@=======================
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
    '機　能：作業ﾒﾓﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2005/12/02 (Fri) 10:20:52 N.Kojima
    '更新日：2008/06/10 (Tue) 09:50:09 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 09:50:09 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try
                        
            '@=======================
            '@　ﾃｷｽﾄ変更時処理(共通処理)
            '@=======================
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

    '関数名：cmdWorkMemoUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:52:32 M.Miura
    '更新日：2008/06/10 (Tue) 09:53:50 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 10:14:00 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    '　　　：2008/06/10 (Tue) 09:53:50 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmdWorkMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkMemoUp.Click
        
        Try
                       
            '@=======================
            '@　ﾃｷｽﾄ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通処理)
            '@=======================
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkMemoUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWorkMemoDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:53:27 M.Miura
    '更新日：2008/06/10 (Tue) 09:54:52 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 10:15:32 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    '　　　：2008/06/10 (Tue) 09:54:52 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmdWorkMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkMemoDown.Click

        Try
                            
            '@=======================
            '@　ﾃｷｽﾄ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通処理)
            '@=======================
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkMemoDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdPlanList_Click
    '機　能：投入予定一覧表示ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/23 (Mon) 10:33:35 M.Miura
    '更新日：2008/06/10 (Tue) 09:55:33 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 09:55:33 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmdPlanList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPlanList.Click

        Try
            
            '@Form_Loadﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            '@子画面で使用する起動区分"0M：新規"をｾｯﾄ
            pstrfrmxxCM0090Kbn = CPstrCD0M
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　投入予定ﾛｯﾄ一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0090.Instance = New frmxxCM0090()
            
            '@投入予定ﾛｯﾄ一覧画面のﾌｫｰﾑ名称を設定
            frmxxCM0090.Instance.Text = CPstrSubDispTitleLotThrwList
            
            '@子画面のLoad処理にて、Form_Loadﾌﾗｸﾞが"False：異常"のままか
            If pblnFormLoad = False Then
            
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0090.Instance = Nothing
                
                Exit Sub
            End If
            
            '@投入予定一覧画面の確定ﾎﾞﾀﾝを非表示にする
            frmxxCM0090.Instance.cmdChoice.Visible = False
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　投入予定ﾛｯﾄ一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0090.Instance.ShowDialog(Me)
            frmxxCM0090.Instance = Nothing
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPlanList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/18 (Wed) 21:49:23 T.Sawaguchi
    '更新日：2013/11/26 (Tue) 17:41:14 T.Oide
    '備　考：
    '　　　：2004/10/22 (Fri) 13:50:41 K.Takano     分割時は機種IDを送らないように変更(組立流動対応)
    '　　　：2005/12/21 (Wed) 12:07:55 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(ﾕｰｻﾞｰ要望№0134)
    '　　　：2006/10/31 (Tue) 15:46:11 N.Kasai      送品ﾌﾗｸﾞ対応(案件№01500)
    '　　　：2008/06/10 (Tue) 10:00:58 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2013/11/26 (Tue) 17:41:14 T.Oide       GNS対応
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean      '戻り値格納用(True/False)
        Dim lstrFunctionID          As String       '機能ID: EN00U0
        Dim lstrActionID            As String       'ｱｸｼｮﾝID：処置登録
        Dim llngCnt                 As Integer      'ｶｳﾝﾀｰ

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@=======================
            '@　確定時ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnLotReserve_Chk
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With mtypLotReserve
            
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸID：起動SB
                
                '@=======================
                '@　処理区分設定処理
                '@=======================
                .strClassDivision = prvstrClassDivision_Set
            
                '@分割ﾛｯﾄID採番にﾁｪｯｸされているか
                If optDivide.Checked = True Then
                    .strPdId = vbNullString                 '機種ID：NULL(分割では機種IDを送らない(組立流動対応))
                    .strWfNum = CMstrWFDefault              'WF枚数：0(分割ではWF枚数を送らない)
                Else
                    .strPdId = cmbPD.Text                   '機種ID：選択機種
                    .strWfNum = txtWFNum.Text               'WF枚数：入力WF枚数
                End If

                .strFlowClass = cmbDivision.Text            '流動区分
                .strEngEmpId = cmbLotManager.Value          'ﾛｯﾄ担当
                .strPlanThrowinDate = calStartDate.Value    '投入予定日
                .strCopySeqLotID = txtCopyLotID.Text        '工順ｺﾋﾟｰﾛｯﾄID
                .strPROrderID = cmbPrOrder.Text             'P/Rｵｰﾀﾞｰ
                .strLotSendFlag = cmbLotSend.Value          '送品ﾌﾗｸﾞ(0:送品なし、1:送品あり)
                .strDivideLotID = txtDivideLotID.Text       '分割元ﾛｯﾄID
                .strMasVer = lblEntryID.Text             'ｴﾝﾄﾘ
                .strComment = txtWorkMemo.Text              '作業ﾒﾓ
            End With
            
        '@↓2013/11/26 (Tue) 16:56:19 T.Oide **************************************************
        '@    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        '@    '@　作業者ｺｰﾄﾞ入力画面　表示処理
        '@    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        '@    Call frmxxCM0010.Show(vbModal)
        '@
        '@    '@取消ﾎﾞﾀﾝが押された場合は処理終了
        '@    If pblnCancel = True Then
        '@        Exit Sub
        '@    End If
        '@------------------------------------------------------------------------------------
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            
            '@PR、ES以外か
            If (cmbDivision.Text = CPstrFlowClassPR Or cmbDivision.Text = CPstrFlowClassES) = True Then
                '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
                frmxxCM0020.Instance.ShowDialog(Me)
                frmxxCM0020.Instance = Nothing
                
                '@取消ﾎﾞﾀﾝが押された場合は処理終了
                If pblnCancel = True Then
                    Exit Sub
                End If
                
                '@実行権限の処理を追加
                lstrFunctionID = CPstrKeyEN0020             '機能ID: EN0020
                lstrActionID = CPstrProductLotThrowRsv      'ｱｸｼｮﾝID：量産Lot登録
            
                '@実行権限ﾁｪｯｸ
                lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, pstrUserID, pstrUserName, pstrSBID)
                
                '@結果判定
                If lblnAns = False Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, pstrUserName, lstrActionID)
                    '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                    Exit Sub
                End If
            
            '@PR、ES以外
            Else
                '@作業者ｺｰﾄﾞ入力
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
                
                '@取消ﾎﾞﾀﾝが押された場合は処理終了
                If pblnCancel = True Then
                    Exit Sub
                End If
            End If

            '@ｲﾝﾌｫﾒｰｼｮﾝ画面起動
            frmxxCM00X0.Instance = New frmxxCM00X0()
            
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定
            frmxxCM00X0.Instance.Text = Me.Text                    'ﾀｲﾄﾙ表示
            frmxxCM00X0.Instance.lblInfomation1.Text = vbNullString   '表示ﾒｯｾｰｼﾞ初期化

            frmxxCM00X0.Instance.Size = New Size(448, 149)
            frmxxCM00X0.Instance.Show(Me) 

            '@ロット投入呼出(「投入ロット数」回)
            For llngCnt = 1 To cmbLotThrowinNum.Value
                
                '@新規ロットIDの登録か
                If optNew.Checked = True Then
                    '@表示ﾒｯｾｰｼﾞ変換([機種：%1] [%2/%3]処理中")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007H, cmbPD.Text, llngCnt, cmbLotThrowinNum.Value)
                Else
                    '@表示ﾒｯｾｰｼﾞ変換([分割ロットID] [%1/%2]処理中")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007I, llngCnt, cmbLotThrowinNum.Value)
                End If
                
                '@進捗メッセージ表示
                frmxxCM00X0.Instance.lblInfomation1.Text = pstrDMsg    
                '@ｲﾝﾌｫﾒｰｼｮﾝﾌｫｰﾑを先行して描画する為、記述しています。
                 frmxxCM00X0.Instance.Refresh()
            
                '@投入予定ロット登録
                Call prvLotTrowinRsv()

            Next
            
            '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
            frmxxCM00X0.Instance = Nothing
            
        '@--------------------------下記は別関数化(prvLotTrowinRsv)------------------------------
        '@    '@ﾚｽﾎﾟﾝｽ取得開始
        '@    Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
        '@
        '@    '@作業確定者IDを設定
        '@    mtypLotReserve.strEmpID = pstrUserID
        '@
        '@    '@ﾛｯﾄIDをｸﾘｱ
        '@    lblLotID.Caption = vbNullString
        '@
        '@    '@【ﾛｯﾄ投入予約】ﾒｯｾｰｼﾞ送受信処理
        '@    lblnAns = pubblnLotThrowrsv_Ins(CMstrlot_throwrsvVer, _
        '@                                    mtypLotReserve)
        '@
        '@    '@ﾛｯﾄ投入予約結果判定
        '@    If lblnAns = True Then
        '@        '@ﾛｯﾄ投入予約結果：正常の場合
        '@
        '@        '@ﾛｯﾄIDを表示する
        '@        lblLotID.Caption = mtypLotReserve.strLotID
        '@
        '@        '@【ﾛｯﾄ予約承認】ﾒｯｾｰｼﾞ送受信処理
        '@        lblnAns = pubblnLotApprove_Ins(CMstrlot_approveVer, _
        '@                                       mtypLotReserve)
        '@
        '@        '@ﾛｯﾄ予約承認結果判定
        '@        If lblnAns = True Then
        '@            '@ﾛｯﾄ予約承認結果：正常の場合
        '@
        '@            '@表示ﾒｯｾｰｼﾞ変換
        '@            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0003, lblLotID.Caption)
        '@            '@ﾒｯｾｰｼﾞ："<TRM03I>$$投入予定ロット[%1]を登録しました。"
        '@            Call pubVsfInfo_Disp(pstrDMsg)
        '@
        '@            '@ﾚｽﾎﾟﾝｽ取得終了
        '@            Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
        '@
        '@            '@作業ﾒﾓをｸﾘｱする
        '@            txtWorkMemo.Text = vbNullString
        '@
        '@            Exit Sub
        '@        End If
        '@    End If
        '@
        '@    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
        '@    Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
        '@↑2013/11/26 (Tue) 18:57:54 T.Oide **************************************************
            
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

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/23 (Mon) 10:32:18 M.Miura
    '更新日：2008/06/05 (Thu) 10:57:23 N.Kojima
    '備　考：
    '　　　：2004/09/26 (Sun) 17:08:25 H.Wajima     分割予定ﾛｯﾄ登録機能追加対応
    '　　　：2004/10/26 (Tue) 17:32:34 T.Kitagawa   DoEvents対応
    '　　　：2008/06/05 (Thu) 10:57:23 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                    
            '@∇∇∇∇∇∇∇∇∇∇∇
            '@　ｱﾝﾛｰﾄﾞ処理
            '@∇∇∇∇∇∇∇∇∇∇∇
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

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvFrmxxCM00M0_Init
    '機　能：各種初期化処理(画面ｺﾝﾄﾛｰﾙ、変数等)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/18 (Wed) 15:28:03 M.Miura
    '更新日：2013/11/26 (Tue) 18:34:22 T.Oide
    '備　考：
    '　　　：2004/09/26 (Sun) 17:41:20 H.Wajima     分割予定ﾛｯﾄ登録対応
    '　　　：2004/10/04 (Mon) 11:12:24 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理追加
    '　　　：2005/12/21 (Wed) 12:07:55 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(ﾕｰｻﾞｰ要望№0134)
    '　　　：2006/04/03 (Mon) 09:07:42 N.Kojima     P/Rｵｰﾀﾞｰｺﾒﾝﾄ追加に伴い処理追加(ﾕｰｻﾞｰ要望№0174)
    '　　　：2006/10/31 (Tue) 14:32:03 N.Kasai      送品ｺﾝﾎﾞ
    '　　　：2008/06/04 (Wed) 15:29:25 N.Kojima     技術担当をﾛｯﾄ担当に変更、ｿｰｽ整備。(案件№02884)
    '　　　：2013/11/26 (Tue) 18:34:22 T.Oide       GNS対応
    Private Sub prvFrmxxCM00M0_Init()
        
        Dim lctlControl             As Control      'ｺﾝﾄﾛｰﾙ名称
        Dim llngNowByte             As Integer      'ﾊﾞｲﾄ数を格納
        Dim lstrFormTitle           As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@画面ｻｲｽﾞの初期値設定
            With Me
                .Height = CMfrmxxCM00M0Height       '高さ
                .Width = CMfrmxxCM00M0Width         '幅
            End With
            
            '@退避用変数の初期化
            mstrPdName = vbNullString               '機種
            mstrCopyLotID = vbNullString            'ｺﾋﾟｰﾛｯﾄID
            mstrDivideLotID = vbNullString          '分割ﾛｯﾄID
            mblnOptButtonEventControlFlag = False   'ｵﾌﾟｼｮﾝﾎﾞﾀﾝｲﾍﾞﾝﾄ制御ﾌﾗｸﾞ(True：ｽｷｯﾌﾟ、False：初期値)
            
            '@★ 起動区分により処理分岐 ★
            Select Case plngfrmxxCM00M0Kbn
            
                '@〓 0：投入予定ﾛｯﾄ登録 〓
                Case CMlngfrmCM00M0Flag0
                
                    '@=======================
                    '@　ﾒﾆｭｰ関連付け処理(ﾌｫｰﾑ名、引継ぎﾌﾗｸﾞetc･･･)
                    '@=======================
                    Call pubMenuItemCorrelation_Set(CPstrKeyEN0020, lstrFormTitle)
                    '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
                    Me.Text = lstrFormTitle
                    
                    
                    '@ﾛｯﾄ作成基礎情報初期値設定
                    '@-----------------------
                    '@　新規ﾛｯﾄID採番
                    '@-----------------------
                    optNew.Enabled = True                                   '新規ﾛｯﾄID採番ｵﾌﾟｼｮﾝﾎﾞﾀﾝ：有効
                    optNew.Checked  = True                                  'ﾁｪｯｸあり
                    
                    cmbPD.ListIndex = -1                                    '機種：ﾘｽﾄｸﾘｱ
                    cmbDivision.ListIndex = -1                              '種別：ﾘｽﾄｸﾘｱ
                    'NSYS 初期表示の活性状態設定
                    'NSYS 種別
                    cmbDivision.Enabled = False                             
                    'NSYS WF枚数
                    txtWFNum.Enabled = False 
                    'NSYS投入カレンダー
                    calStartDate.Enabled = False 
                    'NSYSロット担当
                    cmbLotManager.Enabled = False 
                    'NSYS PrOrder
                    cmbPrOrder.Enabled = False 

                    '@投入予定日ｶﾚﾝﾀﾞｰｺﾝﾎﾞの初期設定(各種ｻｲｽﾞは流動系ｻｲｽﾞ)
                    With calStartDate
                        .Value = Format$(Now, CPstrDateTimeYMD)                     '表示：現在日
                        .CalendarHeight = CPlngClHeight                             '高さ
                        .CalendarWidth = CPlngClWidth                               '幅
                        .DayFont       = New Font(.DayFont.FontFamily, Ctype(CPlngClFontSize, Single), .DayFont.Style)    'ﾌｫﾝﾄｻｲｽﾞ
                        .TitleFont     = New Font(.TitleFont.FontFamily, Ctype(CPlngClTlFontSize, Single), .TitleFont.Style)  'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                        .GridFont      = New Font(.GridFont.FontFamily, Ctype(CPlngClGridFontSize, Single), .GridFont.Style)'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    End With
                    
                    cmbLotManager.ListIndex = -1                            'ﾛｯﾄ担当：ﾘｽﾄｸﾘｱ
                    fraPrClass.Enabled = False                              'P/R区分ﾌﾚｰﾑ：無効
                    optPrClass0.Enabled = False                             'P/R区分：P=無効
                    optPrClass1.Enabled = False                             'R/R区分：R=無効
                    optPrClass0.Checked = False                             'P/R区分：P=ﾁｪｯｸなし
                    optPrClass1.Checked = False                             'P/R区分：R=ﾁｪｯｸなし
                    
                    '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄、上下ｽｸﾛｰﾙﾎﾞﾀﾝの初期化
                    txtOrderComment.Text = vbNullString                     'P/Rｵｰﾀﾞｰｺﾒﾝﾄ：NULL
                    txtOrderComment.Enabled = False                         '無効
                    txtOrderComment.Locked = True                           'ﾛｯｸ
                    cmdCommentUp.Enabled = False                            '上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ：無効
                    cmdCommentDown.Enabled = False                          '下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ：無効
                    
                    
                    '@-----------------------
                    '@　分割ﾛｯﾄID採番
                    '@-----------------------
                    optDivide.Enabled = True                                                '分割ﾛｯﾄID採番ｵﾌﾟｼｮﾝﾎﾞﾀﾝ：有効
                    optDivide.Checked = False                                               'ﾁｪｯｸなし
                    With txtDivideLotID
                        .Enabled = False                                                    '使用不可
                        .Text = vbNullString                                                '分割元ﾛｯﾄID：NULL
                        .FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num      '英数字のみ
                        .ChrLowerUpper =SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper        '大文字のみ 
                        .BackColor = vbButtonFace
                    End With
                    cmdDivideLotID.Enabled = False                                          '分割元ﾛｯﾄIDﾎﾞﾀﾝ：無効
                    
                    
                    
                    '@ﾛｯﾄ工順情報はﾛｯﾄ作成基礎情報が選択、入力されるまで全て無効
                    '@-----------------------
                    '@　工順ｺﾋﾟｰ
                    '@-----------------------
                    optCopy.Enabled = False                                                 '工順ｺﾋﾟｰｵﾌﾟｼｮﾝﾎﾞﾀﾝ：無効
                    optCopy.TabStop = True                                                  'ﾀﾌﾞｽﾄｯﾌﾟする
                    With txtCopyLotID
                        .Enabled = False                                                    '工順ｺﾋﾟｰﾛｯﾄID：無効
                        .BackColor = vbButtonFace                                           '背景色：ｸﾞﾚｰ
                        .FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num      '英数字のみ
                        .ChrLowerUpper =SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper        '大文字のみ
                     End With
                    cmdCopyLotID.Enabled = False                                            '工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ：無効
                
                
                '@〓 その他：分割予定ﾛｯﾄ登録 〓
                Case Else

                    '@=======================
                    '@　ﾒﾆｭｰ関連付け処理(ﾌｫｰﾑ名、引継ぎﾌﾗｸﾞetc･･･)
                    '@=======================
                    Call pubMenuItemCorrelation_Set(CPstrKeyEN01F0, lstrFormTitle)
                    '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
                    Me.Text = lstrFormTitle
                    
                    
                    '@ﾛｯﾄ作成基礎情報初期値設定
                    '@-----------------------
                    '@　新規ﾛｯﾄID採番
                    '@-----------------------
                    optNew.Enabled = False                                  '新規ﾛｯﾄID採番ｵﾌﾟｼｮﾝﾎﾞﾀﾝ：無効
                    optNew.Checked = False                                  'ﾁｪｯｸなし
                    cmbPD.Enabled = False
                    cmbDivision.Enabled = False 
                    txtWFNum.Enabled = False 
                    calStartDate.Enabled = False
                    cmbLotManager.Enabled = False 
                    optPrClass0.Enabled = False 
                    optPrClass1.Enabled = False 
                    cmbPrOrder.Enabled = False 
                    
                    'NSYS WF枚数値設定
                    txtWFNum.Text = 0

                    '@NSYS 投入予定日ｶﾚﾝﾀﾞｰｺﾝﾎﾞの初期設定(各種ｻｲｽﾞは流動系ｻｲｽﾞ)
                    With calStartDate
                        .Value = Format$(Now, CPstrDateTimeYMD)                     '表示：現在日
                        .CalendarHeight = CPlngClHeight                             '高さ
                        .CalendarWidth = CPlngClWidth                               '幅
                        .DayFont       = New Font(.DayFont.FontFamily, Ctype(CPlngClFontSize, Single), .DayFont.Style)    'ﾌｫﾝﾄｻｲｽﾞ
                        .TitleFont     = New Font(.TitleFont.FontFamily, Ctype(CPlngClTlFontSize, Single), .TitleFont.Style)  'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                        .GridFont      = New Font(.GridFont.FontFamily, Ctype(CPlngClGridFontSize, Single), .GridFont.Style)'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    End With

                    '@送品の初期化
                    cmbLotSend.Enabled = False
                    
                    '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄、上下ｽｸﾛｰﾙﾎﾞﾀﾝの初期化
                    txtOrderComment.Text = vbNullString                     'P/Rｵｰﾀﾞｰｺﾒﾝﾄ：NULL
                    txtOrderComment.Enabled = False                         '無効
                    txtOrderComment.Locked = True                           'ﾛｯｸ
                    cmdCommentUp.Enabled = False                            '上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ：無効
                    cmdCommentDown.Enabled = False                          '下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ：無効

                    'NSYS 各コントロールの色設定
                    cmbPD.BackColor = vbButtonFace 
                    cmbDivision.BackColor = vbButtonFace 
                    txtWFNum.BackColor = vbButtonFace 
                    calStartDate.BackColor = vbButtonFace 
                    cmbLotManager.BackColor = vbButtonFace 
                    cmbPrOrder.BackColor = vbButtonFace 
                    cmbLotSend.BackColor = vbButtonFace 
                    
                    '@-----------------------
                    '@　分割ﾛｯﾄID採番
                    '@-----------------------
                    With optDivide
                        .Enabled = False                                    '分割ﾛｯﾄID採番ｵﾌﾟｼｮﾝﾎﾞﾀﾝ：無効
                        .Checked = True                                       'ﾁｪｯｸあり
                        .TabIndex = False                                   'ﾀﾌﾞｽﾄｯﾌﾟしない
                    End With
                    
                    With txtDivideLotID
                        .Text = vbNullString                                                '分割元ﾛｯﾄID：NULL
                        .FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num      '英数字のみ
                        .ChrLowerUpper =SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper        '大文字のみ
                    End With
                    cmdDivideLotID.Enabled = True                                           '分割元ﾛｯﾄIDﾎﾞﾀﾝ：有効
                    
                    
                    '@ﾛｯﾄ工順情報はﾛｯﾄ作成基礎情報が選択、入力されるまで全て無効
                    '@-----------------------
                    '@　工順ｺﾋﾟｰ
                    '@-----------------------
                    optCopy.Enabled = False                                                 '工順ｺﾋﾟｰｵﾌﾟｼｮﾝﾎﾞﾀﾝ：無効
                    optCopy.TabStop = False                                                 'ﾀﾌﾞｽﾄｯﾌﾟしない
                    With txtCopyLotID
                        .Enabled = False                                                    '工順ｺﾋﾟｰﾛｯﾄID：無効
                        .BackColor = vbButtonFace                                           '背景色：ｸﾞﾚｰ
                        .FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num      '英数字のみ
                        .ChrLowerUpper =SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper        '大文字のみ
                    End With
                    cmdCopyLotID.Enabled = False                                            '工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ：無効
                    
            End Select
               'NSYS 確定ボタンのValidate制御
               cmdRegist.CausesValidation = False     
                
            '@ｺﾝﾎﾞ文字表示位置設定(左中央)
            cmbPD.ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter            '機種
            cmbDivision.ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter      '種別
            cmbLotManager.ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter    'ﾛｯﾄ担当
            cmbPrOrder.ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter       'P/Rｵｰﾀﾞｰ
        '@↓2013/11/26 (Tue) 18:33:15 T.Oide **************************************************
            cmbLotThrowinNum.ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter '投入ロット数
        '@↑2013/11/26 (Tue) 18:33:15 T.Oide **************************************************
            
            '@-----------------------
            '@　ﾏｽﾀ工順
            '@-----------------------
            optMster.Enabled = False                'ﾏｽﾀ工順ｵﾌﾟｼｮﾝﾎﾞﾀﾝ：無効
            cmdEntry.Enabled = False                'ｴﾝﾄﾘﾎﾞﾀﾝ：無効

                
            '@-----------------------
            '@　作業ﾒﾓ
            '@-----------------------
            With txtWorkMemo

                .ChrMaxByte = CPlngLotCommentsMaxByte   '最大入力可能Byte数を格納
                .Text = vbNullString                    'NULLを格納
                llngNowByte = .NowByte                  '現状のﾊﾞｲﾄ数を格納
                
                '@=======================
                '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換)
                '@=======================
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            End With
            
            
            '@-----------------------
            '@　ｺﾝﾎﾞの初期設定
            '@-----------------------
            '@ﾌｫｰﾑ上の全てのｺﾝﾎﾞﾎﾞｯｸｽに対して処理を行う
            Dim all As Control() = GetAllControls(Me)
            For Each lctlControl In all
                '@ﾌｫｰﾑ上のｺﾝﾄﾛｰﾙに対して処理を行う
                If TypeOf lctlControl Is ComboBoxEx Then
                    '@ｺﾝﾄﾛｰﾙがComboBoxExの場合
                    With CType(lctlControl,SEComboBoxEx.ComboBoxEx)
                        '@ｺﾝﾎﾞﾎﾞｯｸｽ初期化
                        .DirectInput = False                                                                                'ﾃｷｽﾄ直接入力
                        .DispCols = CMlngComboDispCols1                                                                     '表示列数
                        .GetCol = CMlngComboGetCol                                                                          '値取得列
                        .Font = New Font(.Font.FontFamily, CType(CMlngComboFontSize, Single), .Font.Style)                   'ﾌｫﾝﾄｻｲｽﾞ
                        .GridFont = New Font(.GridFont.FontFamily, CType(CMlngComboGridFontSize, Single), .GridFont.Style)   'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                        .RowHeight = CMlngComboRowHeight                                                                     '行高さ
                    End With
                End If
            Next
            
            '@ﾛｯﾄIDをｸﾘｱする
            lblLotID.Text = vbNullString
            
            '@各種ﾎﾞﾀﾝのCausesValidationをFalse
            cmdClose.CausesValidation = False       '閉じるﾎﾞﾀﾝ
            cmdPlanList.CausesValidation = False    '投入予定一覧ﾎﾞﾀﾝ
            
            '@各種ﾎﾞﾀﾝを無効にする
            cmdEntry.Enabled = False                'ｴﾝﾄﾘﾎﾞﾀﾝ
            cmdRegist.Enabled = False               '確定ﾎﾞﾀﾝ

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxCM00M0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：入力(選択)ﾁｪｯｸ処理(ﾛｯﾄ作成基礎情報)
    '引　数：llngCheckFlag  ：ﾁｪｯｸﾌﾗｸﾞ(1:ﾛｯﾄ作成基礎情報、2:ﾛｯﾄ工順情報)
    '戻り値：True:ﾁｪｯｸOK、False:ﾁｪｯｸNG
    '作成日：2004/04/15 (Thu) 09:55:35 M.Miura
    '更新日：2013/11/26 (Tue) 15:45:57 T.Oide
    '備　考：
    '　　　：2004/09/26 (Sun) 18:57:39 H.Wajima     分割予定ﾛｯﾄ登録対応
    '　　　：2005/12/21 (Wed) 12:07:55 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(ﾕｰｻﾞｰ要望№0134)
    '　　　：2006/11/07 (Tue) 08:58:18 N.Kasai      送品ｺﾝﾎﾞ追加(№01500)
    '　　　：2008/06/05 (Thu) 16:35:18 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2013/11/26 (Tue) 15:45:57 T.Oide       GNS対応
    Private Function prvblnInput_Chk(ByVal llngCheckFlag As Integer) As Boolean

        Dim lstrNowDT               As String       'ｼｽﾃﾑ日付
        Dim lblnFlgAns              As Boolean      '分割元ﾛｯﾄIDの上3桁が機種ID一覧に存在

        Try
            
            '@戻り値、ﾌﾗｸﾞの初期化
            prvblnInput_Chk = True
            lblnFlgAns = True
            
            '@★ 起動区分により処理分岐 ★
            Select Case plngfrmxxCM00M0Kbn
            
                '@〓 0：投入予定ﾛｯﾄ登録 〓
                Case CMlngfrmCM00M0Flag0

                    '@新規ﾛｯﾄ採番か
                    If optNew.Checked = True Then
                        
                        '@機種がNULLか
                        If cmbPD.Value = vbNullString Then
                        
                            '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                            prvblnInput_Chk = False
                        End If
                        
                        '@種別がNULLか
                        If cmbDivision.Value = vbNullString And prvblnInput_Chk = True Then
                            
                            '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                            prvblnInput_Chk = False
                        End If
                        
                        '@WF枚数がNULL、または"0"か
                        If (txtWFNum.Text = vbNullString Or txtWFNum.Text = CPstrZero) And _
                            prvblnInput_Chk = True Then
                            
                            '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                            prvblnInput_Chk = False
                        End If
                        
                        '@現在までのﾁｪｯｸでｴﾗｰになっていないか
                        If prvblnInput_Chk = True Then
                        
                            '@現在日付を取得(YYYY/MM/DDのﾌｫｰﾏｯﾄ)
                            lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                            
                            '@投入予定日が日付か
                            If IsDate(calStartDate.Value) = True Then
                                
                                '@投入予定日が過去日付か(過去日付は不可)
                                If calStartDate.Value < lstrNowDT Then
                                
                                    '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                                    prvblnInput_Chk = False
                                End If
                            Else
                                '@日付型ではない場合
                            
                                '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                                prvblnInput_Chk = False
                            End If
                        End If
                        
        '@↓2013/11/26 (Tue) 15:44:48 T.Oide **************************************************
        '@                '@ﾛｯﾄ担当がNULLか
        '@                If cmbLotManager.Value = vbNullString And prvblnInput_Chk = True Then
        '@
        '@                    '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
        '@                    prvblnInput_Chk = False
        '@                End If
        '@-------------------------------------------------------------------------------------
                        
                        '@PRとES以外か
                        If (cmbDivision.Text = CPstrFlowClassPR Or cmbDivision.Text = CPstrFlowClassES) = False Then
                            '@ﾛｯﾄ担当がNULLか
                            If cmbLotManager.Value = vbNullString And prvblnInput_Chk = True Then
                            
                                '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                                prvblnInput_Chk = False
                            End If
                        End If
        '@↑2013/11/26 (Tue) 15:44:48 T.Oide **************************************************
                        
                        '@P/Rｵｰﾀﾞｰが有効で、かつNULLか
                        If (cmbPrOrder.Enabled = True And cmbPrOrder.Value = vbNullString) And _
                            prvblnInput_Chk = True Then
                            
                            '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                            prvblnInput_Chk = False
                        End If
                        
                        '@送品ﾁｪｯｸ
                        If (cmbLotSend.Enabled = True And cmbLotSend.Value = vbNullString) And _
                            prvblnInput_Chk = True Then
                            
                            '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                            prvblnInput_Chk = False
                        End If
                        
                        '@戻り値が"False：ﾁｪｯｸNG"か
                        If prvblnInput_Chk = False Then
                            
                            '@1つでもﾁｪｯｸNGがあった場合は、ﾛｯﾄ工順情報を選択させない
                            
                            '@=======================
                            '@　ﾛｯﾄ工順情報ﾌｨｰﾙﾄﾞ使用不可設定処理
                            '@=======================
                            Call prvLotProcessInfoFieldDisable_Proc()
                            
                            Exit Function
                        End If
                        
                        '@ﾁｪｯｸNGが1つもなく、かつ引継ぎﾌﾗｸﾞが"1:ﾛｯﾄ作成基礎情報"か
                        If llngCheckFlag = CMlngCreateInfo Then
                            
                            '@=======================
                            '@　ﾛｯﾄ工順情報ﾌｨｰﾙﾄﾞ使用可設定処理
                            '@=======================
                            Call prvLotProcessInfoFieldControl_Proc()
                        End If
                    End If
                    
                    
                    '@分割ﾛｯﾄID採番にﾁｪｯｸされているか
                    If optDivide.Checked = True Then
                        
                        '@分割元ﾛｯﾄIDがNULLか
                        If txtDivideLotID.Text = vbNullString Then
                        
                            '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                            prvblnInput_Chk = False
                            
                            '@=======================
                            '@　ﾛｯﾄ工順情報ﾌｨｰﾙﾄﾞ使用不可設定処理
                            '@=======================
                            Call prvLotProcessInfoFieldDisable_Proc()
                            
                            Exit Function
                            
                        End If
                        
                        '@分割元ﾛｯﾄIDが10桁以外か
                        If Len(txtDivideLotID.Text) <> 10 Then
                        
                            '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                            prvblnInput_Chk = False
                            
                            '@=======================
                            '@　ﾛｯﾄ工順情報ﾌｨｰﾙﾄﾞ使用不可設定処理
                            '@=======================
                            Call prvLotProcessInfoFieldDisable_Proc()
                            
                            Exit Function
                        Else
                            '@分割元ﾛｯﾄIDが10桁の場合
                            '@引継ぎﾌﾗｸﾞが"1:ﾛｯﾄ作成基礎情報"か
                            If llngCheckFlag = CMlngCreateInfo Then
                                
                                '@ﾏｽﾀ工順が未選択か
                                If optMster.Checked = False Then
                                    
                                    '@=======================
                                    '@　ﾛｯﾄ工順情報ﾌｨｰﾙﾄﾞ使用可/不可設定処理(分割ﾛｯﾄID採番の場合)
                                    '@=======================
                                    Call prvLotProcessInfoFieldControl_Proc()
                                    
                                    '@工順ｺﾋﾟｰｵﾌﾟｼｮﾝﾎﾞﾀﾝにﾁｪｯｸする
                                    optCopy.Checked = True
                                        
                                    '@ｺﾋﾟｰ元ﾛｯﾄIDがNULLか
                                    If txtCopyLotID.Text = vbNullString Then
                                    
                                        '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                                        prvblnInput_Chk = False
                                        Exit Function
                                    End If
                                        
                                    '@ｺﾋﾟｰ元ﾛｯﾄIDの桁数が10桁以外か
                                    If Len(txtCopyLotID.Text) <> 10 Then

                                        '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                                        prvblnInput_Chk = False
                                        Exit Function
                                    End If
                                Else
                                    '@ﾏｽﾀ工順が選択されている場合
                                
                                    '@=======================
                                    '@　ﾛｯﾄ工順情報ﾌｨｰﾙﾄﾞ使用可/不可設定処理(分割ﾛｯﾄID採番の場合)
                                    '@=======================
                                    Call prvLotProcessInfoFieldControl_Proc()
                                End If

                            End If
                        End If
                        
                        '@戻り値が"False：ﾁｪｯｸNG"か
                        If prvblnInput_Chk = False Then
                            
                            '@=======================
                            '@　ﾛｯﾄ工順情報ﾌｨｰﾙﾄﾞ使用不可設定処理
                            '@=======================
                            Call prvLotProcessInfoFieldDisable_Proc()
                            
                            Exit Function
                        End If
                    End If
                    
                    '@引継ぎﾌﾗｸﾞが"2:ﾛｯﾄ工順情報"か
                    If llngCheckFlag = CMlngOrderInfo Then

                        '@工順ｺﾋﾟｰにﾁｪｯｸされているか
                        If optCopy.Checked = True Then
                        
                            '@ｺﾋﾟｰﾛｯﾄIDがNULLか
                            If txtCopyLotID.Text = vbNullString Then
                            
                                '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                                prvblnInput_Chk = False
                                Exit Function
                            End If
                            
                            '@ｺﾋﾟｰﾛｯﾄIDの桁数が10桁以外か
                            If Len(txtCopyLotID.Text) <> 10 Then
                            
                                '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                                prvblnInput_Chk = False
                                Exit Function
                            End If
                    
                        End If
                    
                        '@ﾏｽﾀ工順にﾁｪｯｸされているか
                        If optMster.Checked = True Then
                        
                            '@ｴﾝﾄﾘIDがNULLか
                            If lblEntryID.Text = vbNullString Then
                            
                                '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                                prvblnInput_Chk = False
                                Exit Function
                            End If
                        End If
                        
                    End If
                    
                    
                '@〓 その他：分割予定ﾛｯﾄ登録 〓
                Case Else
                    
                    '@=======================
                    '@　ﾛｯﾄ工順情報分割ﾛｯﾄ登録時処理
                    '@=======================
                    Call prvLotDivideObjectControl_Proc()
                        
                    '@分割元ﾛｯﾄIDの桁数が10桁か
                    If Len(txtDivideLotID.Text) = 10 Then
                        '@分割元ﾛｯﾄIDが10桁の場合
                        
                        '@分割元ﾛｯﾄIDを工順ｺﾋﾟｰﾛｯﾄIDにｺﾋﾟｰ
                        txtCopyLotID.Text = txtDivideLotID.Text
                    Else
                        '@分割元ﾛｯﾄIDが10桁以外の場合
                    
                        '@工順ｺﾋﾟｰﾛｯﾄIDにNULLをｾｯﾄ
                        txtCopyLotID.Text = vbNullString
                        
                        '@戻り値に"False：ﾁｪｯｸNG"をｾｯﾄ
                        prvblnInput_Chk = False
                        Exit Function
                    End If
            End Select

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

    '関数名：prvLotProcessInfoFieldControl_Proc
    '機　能：ﾛｯﾄ工順情報使用処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/21 (Wed) 17:08:16 Y.Yamagishi
    '更新日：2004/04/21 (Wed) 17:08:16
    '備　考：
    Private Sub prvLotProcessInfoFieldControl_Proc()
        
        Try
            
            '@***********************
            '@　ﾛｯﾄ工順情報ﾌｨｰﾙﾄﾞ内ｺﾝﾄﾛｰﾙを制御する
            '@　　※ﾛｯﾄ工順情報はﾛｯﾄ作成基礎情報が選択、入力されるまで全て無効
            '@***********************
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：ｽｷｯﾌﾟ"をｾｯﾄ
            mblnOptButtonEventControlFlag = True
            
            '@分割ﾛｯﾄID採番にﾁｪｯｸされているか
            If optDivide.Checked = True Then
            
                '@-----------------------
                '@　ﾏｽﾀ工順ﾌｨｰﾙﾄﾞ
                '@-----------------------
                optMster.Enabled = True                 'ﾏｽﾀ工順ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
                optMster.Checked = False                  'ﾁｪｯｸなし
                cmdEntry.Enabled = False                'ｴﾝﾄﾘﾎﾞﾀﾝ
            
                '@-----------------------
                '@　工順ｺﾋﾟｰﾌｨｰﾙﾄﾞ
                '@-----------------------
                optCopy.Enabled = True                  '工順ｺﾋﾟｰｵﾌﾟｼｮﾝﾎﾞﾀﾝ
                '@工順ｺﾋﾟｰにﾁｪｯｸがついていないか
                If optCopy.Checked = False Then
                    optCopy.Checked= True
                End If

                With txtCopyLotID                       'ﾛｯﾄID
                    .Enabled = True                     '有効
                    .BackColor = vbWhite                '背景=白
                End With
                cmdCopyLotID.Enabled = True             '工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ

            Else
                '@分割ﾛｯﾄID採番以外の場合(新規ロットID採番)
            
                '@-----------------------
                '@　ﾏｽﾀ工順ﾌｨｰﾙﾄﾞ
                '@-----------------------
                optMster.Enabled = True                 'ﾏｽﾀ工順選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
                optMster.Checked = True                   'ﾁｪｯｸあり
                cmdEntry.Enabled = True                 'ｴﾝﾄﾘﾎﾞﾀﾝ
            
                '@-----------------------
                '@　工順ｺﾋﾟｰﾌｨｰﾙﾄﾞ
                '@-----------------------
                optCopy.Enabled = True                  '工順ｺﾋﾟｰｵﾌﾟｼｮﾝﾎﾞﾀﾝ
                optCopy.Checked = False                   'ﾁｪｯｸなし
                With txtCopyLotID                       'ﾛｯﾄID
                    .Enabled = False                    '無効
                    .BackColor = vbButtonFace           '背景=灰色
                End With
                cmdCopyLotID.Enabled = False            '工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ

        '@↓2013/11/26 (Tue) 15:58:30 T.Oide **************************************************

                '@PR、ESの場合(最新のマスター工順のみとする)
                If (cmbDivision.Text = CPstrFlowClassPR Or cmbDivision.Text = CPstrFlowClassES) = True Then
            
                    '@-----------------------
                    '@　ﾏｽﾀ工順ﾌｨｰﾙﾄﾞ
                    '@-----------------------
                    '@最新のエントリIDのみ選択可能
                    optMster.Enabled = False            'ﾏｽﾀ工順選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
                    cmdEntry.Enabled = False            'ｴﾝﾄﾘﾎﾞﾀﾝ
                    
                    '@-----------------------
                    '@　工順ｺﾋﾟｰﾌｨｰﾙﾄﾞ
                    '@-----------------------
                    optCopy.Enabled = False             '工順ｺﾋﾟｰ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
                    With txtCopyLotID                   'ﾛｯﾄID
                        .Text = vbNullString
                    End With
                    
                End If
        '@↑2013/11/26 (Tue) 15:58:30 T.Oide **************************************************

            End If
                
            '@ﾛｯﾄIDをｸﾘｱする
            lblLotID.Text = vbNullString
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御ﾌﾗｸﾞに"False：ｽｷｯﾌﾟしない"をｾｯﾄ
            mblnOptButtonEventControlFlag = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLotProcessInfoFieldControl_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLotProcessInfoFieldDisable_Proc
    '機　能：ﾛｯﾄ工順情報ﾌｨｰﾙﾄﾞ使用不可設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/21 (Wed) 17:08:16 Y.Yamagishi
    '更新日：2008/06/05 (Thu) 16:40:36 N.Kojima
    '備　考：
    '　　　：2008/06/05 (Thu) 16:40:36 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub prvLotProcessInfoFieldDisable_Proc()

        Try
            
            '@***********************
            '@　ﾛｯﾄ工順情報ﾌｨｰﾙﾄﾞ内ｺﾝﾄﾛｰﾙを無効にする
            '@***********************

            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：ｽｷｯﾌﾟ"をｾｯﾄ
            mblnOptButtonEventControlFlag = True

            '@-----------------------
            '@　ﾏｽﾀ工順ﾌｨｰﾙﾄﾞ
            '@-----------------------
            optMster.Enabled = False                'ﾏｽﾀ工順選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optMster.Checked = False                  'ﾁｪｯｸなし
            cmdEntry.Enabled = False                'ｴﾝﾄﾘﾎﾞﾀﾝ
            
            '@分割ﾛｯﾄID採番選択か
            If optDivide.Checked = True Then
                '@各種情報をｸﾘｱ
                lblEntryID.Text = vbNullString   'ｴﾝﾄﾘID
                lblEntryName.Text = vbNullString 'ｴﾝﾄﾘ名
            End If
            
            '@-----------------------
            '@　工順ｺﾋﾟｰﾌｨｰﾙﾄﾞ
            '@-----------------------
            optCopy.Enabled = False                 '工順ｺﾋﾟｰ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optCopy.Checked = False                   'ﾁｪｯｸなし
            With txtCopyLotID                       'ﾛｯﾄID
                .Text = vbNullString
                .Enabled = False
                .BackColor = vbButtonFace
            End With
            cmdCopyLotID.Enabled = False            '工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ
            
            '@ﾛｯﾄIDをｸﾘｱ
            lblLotID.Text = vbNullString
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御ﾌﾗｸﾞに"False：ｽｷｯﾌﾟしない"をｾｯﾄ
            mblnOptButtonEventControlFlag = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLotProcessInfoFieldDisable_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLotDivideObjectControl_Proc
    '機　能：ﾛｯﾄ工順情報分割ﾛｯﾄ登録時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/26 (Sun) 17:57:34 H.Wajima
    '更新日：2008/06/06 (Fri) 09:40:58 N.Kojima
    '備　考：
    '　　　：2008/06/06 (Fri) 09:40:58 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2008/09/03 (Wed) 07:07:53 T.Sawaguchi  工順なしﾌｨｰﾙﾄﾞを削除　(案件03141)
    Private Sub prvLotDivideObjectControl_Proc()

        Try
            
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：ｽｷｯﾌﾟ"をｾｯﾄ
            mblnOptButtonEventControlFlag = True
            
            '@-----------------------
            '@　ﾏｽﾀ工順ﾌｨｰﾙﾄﾞ
            '@-----------------------
            '@無効
            optMster.Enabled = False                　'ﾏｽﾀ工順ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optMster.Checked = False                  'ﾁｪｯｸなし
            cmdEntry.Enabled = False                　'ｴﾝﾄﾘﾎﾞﾀﾝ
            '@分割ﾛｯﾄID採番の場合
            If optDivide.Checked = True Then
                lblEntryID.Text = vbNullString   　　 'ｴﾝﾄﾘID
                lblEntryName.Text = vbNullString      'ｴﾝﾄﾘ名
            End If
            'ﾏｽﾀ工順ﾌﾚｰﾑ
            cmdEntry.Enabled = false
            
            '@-----------------------
            '@　工順ｺﾋﾟｰﾌｨｰﾙﾄﾞ
            '@-----------------------
            optCopy.Enabled = False                   '工順ｺﾋﾟｰｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optCopy.Checked = True                    'ﾁｪｯｸあり
            With txtCopyLotID                         'ﾛｯﾄID
                .Text = vbNullString
                .Enabled = True
                .BackColor = vbButtonFace
                .Locked = True
                .GotHighLight = False
                .GotBackColor = vbButtonFace
                .TabStop = False
            End With
            cmdCopyLotID.Enabled = False            '工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ
            
            '@ﾛｯﾄIDをｸﾘｱ
            lblLotID.Text = vbNullString

            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御ﾌﾗｸﾞに"False：ｽｷｯﾌﾟしない"をｾｯﾄ
            mblnOptButtonEventControlFlag = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLotDivideObjectControl_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMasEntryList_Sel
    '機　能：ﾏｽﾀ工順取得＆表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/27 (Thu) 09:39:42 S.Deguchi
    '更新日：2008/06/05 (Thu) 14:53:37 N.Kojima
    '備　考：
    '　　　：2004/08/31 (Tue) 17:14:30 Y.Yamagishi  WF枚数取得
    '　　　：2004/10/26 (Tue) 17:31:05 T.Kitagawa　 DoEvents対応
    '　　　：2005/06/23 (Thu) 10:34:51 S.Deguchi    情報取得結果NGの場合,退避領域をｸﾘｱする処理を追加
    '　　　：2008/06/05 (Thu) 14:53:37 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub prvMasEntryList_Sel()

        Dim lblnAns                     As Boolean            '戻り値(True/False)
        Dim ltypEntryList               As List(of EntryList) 'ﾏｽﾀ工順取得構造体
        Dim llngEntryListCnt            As Integer            'ﾏｽﾀ工順取得件数
        Dim lstrPdID                    As String             '機種格納用

        Try
            'NSYS配列初期化
            If ltypEntryList Is Nothing Then 
                ltypEntryList  = New List(Of EntryList) 
            Else 
                ltypEntryList.Clear()
            End If
            
            '@★ 有効(選択されている)ｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case True
            
                '@〓 新規ﾛｯﾄID採番ｵﾌﾟｼｮﾝﾎﾞﾀﾝ 〓
                Case optNew.Checked
                
                    '@選択機種を格納
                    lstrPdID = cmbPD.Text
                
                '@〓 分割ﾛｯﾄID採番ｵﾌﾟｼｮﾝﾎﾞﾀﾝ 〓
                Case optDivide.Checked
                    
                    '@分割元ﾛｯﾄIDがNULL以外か
                    If txtDivideLotID.Text <> vbNullString Then
                    
                        '@ﾛｯﾄIDの左3桁を機種とし格納する
                        lstrPdID = Strings.Left(txtDivideLotID.Text, CMlngPdIDLength)
                    End If
            End Select
            
            '@機種がNULLか
            If lstrPdID = vbNullString Then
            
                Exit Sub
            Else
                '@機種が退避領域と同じでｴﾝﾄﾘIDがNULL以外の場合
                If lstrPdID = mstrPdName And lblEntryID.Text <> vbNullString Then
                
                    '@処理を抜ける
                    Exit Sub
                Else
                    '@機種が退避領域の機種と異なり、かつｴﾝﾄﾘIDがNULLの場合
                    
                    '@【ﾏｽﾀ工順一覧取得】ﾒｯｾｰｼﾞ送受信処理　★最新1件のみ取得
                    lblnAns = pubblnmasPdEntryList_Sel(CMstrmas_pdentrylistVer, _
                                                       lstrPdID, _
                                                       ltypEntryList, _
                                                       llngEntryListCnt, _
                                                       pstrSBID, _
                                                       CPstrCD07)

                    '@ﾏｽﾀ工順一覧取得結果判定
                    If lblnAns = False Then
                        '@結果：異常の場合
                    
                        '@機種退避領域をｸﾘｱする
                        mstrPdName = vbNullString
                        Exit Sub
                    End If
                End If
            End If
                    
            '@最新のｴﾝﾄﾘが取得出来たか
            If llngEntryListCnt <> 0 Then
            
                '@各種表示
                lblEntryID.Text = ltypEntryList(llngEntryListCnt-1).strEntryID         'ｴﾝﾄﾘID
                lblEntryName.Text = ltypEntryList(llngEntryListCnt-1).strEntryName     'ｴﾝﾄﾘ名
                
                '@機種を退避する
                mstrPdName = lstrPdID
                
                '@新規ﾛｯﾄID採番か
                If optNew.Checked = True Then

                    '@WF枚数に値をｾｯﾄする
                    txtWFNum.Text = ltypEntryList(llngEntryListCnt-1).strMaxWFCount
                    '@ｴﾝﾄﾘに紐付く最大WF枚数を退避
                    mlngPdEntryMaxWFCount = txtWFNum.Text
                End If
            Else
                '@最新ｴﾝﾄﾘが取得出来なかった場合
                
                '@新規ﾛｯﾄID採番か
                If optNew.Checked = True Then

                    '@WF枚数に値をｾｯﾄする
                    txtWFNum.Text = cmbPD.Value
                End If
            End If
                    
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMasEntryList_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbFlowList_Disp
    '機　能：種別ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/13 (Fri) 10:20:54 S.Deguchi
    '更新日：2013/11/26 (Tue) 13:55:23 T.Oide
    '備　考：
    '　　　：2008/06/06 (Fri) 12:51:19 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub prvCmbFlowList_Disp()

        Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ

        Try

            With cmbDivision
            
                .Clear      'ｸﾘｱ
            
                '@種別ﾃﾞｰﾀ数が1件以上存在するか
                If mlngDivisionCnt > 0 Then
                
                    For llngCnt = 0 To mlngDivisionCnt-1
                    
        '@↓2013/11/26 (Tue) 13:55:43 T.Oide **************************************************
        '@                '@種別が"PR"以外or"ES"以外か
        '@                If mtypDivisionList(llngCnt).strDivisionID <> CPstrFlowClassPR And _
        '@                    mtypDivisionList(llngCnt).strDivisionID <> CPstrFlowClassES Then
        '@
        '@                    '@ｺﾝﾎﾞ内容設定：種別
        '@                    .AddItem mtypDivisionList(llngCnt).strDivisionID
        '@                End If
        '@-------------------------------------------------------------------------------------
                        
                        '@ｺﾝﾎﾞ内容設定：種別
                        .AddItem(mtypDivisionList(llngCnt).strDivisionID)
        '@↑2013/11/26 (Tue) 13:55:43 T.Oide **************************************************

                    Next llngCnt
            
                    '@種別が1件の場合は表示
                    If .ListCount = 1 Then
                        
                        '@ﾃﾞﾌｫﾙﾄで表示する
                        .ListIndex = 0
                        
                        '@=======================
                        '@　送品ｺﾝﾎﾞ設定処理
                        '@=======================
                        Call prvCmbLotSend_Set()
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbFlowList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbPd_Disp
    '機　能：機種ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/23 (Thu) 10:46:41 S.Deguchi
    '更新日：2008/06/06 (Fri) 15:23:40 N.Kojima
    '備　考：
    '　　　：2008/06/06 (Fri) 15:23:40 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub prvcmbPd_Disp()

        Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ

        Try


            With cmbPD
            
                '@機種が1件以上存在するか
                If mlngPdCnt > 0 Then
                
                    For llngCnt = 0 To mlngPdCnt-1
                    
                        '@最大WF枚数が数値か
                        If IsNumeric(mtypPdList(llngCnt).strMaxWFCount) = True Then
                        
                            '@最大WF枚数が25枚以上か
                            If CLng(mtypPdList(llngCnt).strMaxWFCount) > CMlngMaxWfCount Then
                            
                                '@最大WF枚数にNULLをｾｯﾄする
                                Dim mtypPdListtmp As ProductList = New ProductList
                                mtypPdListtmp = mtypPdList(llngCnt)
                                mtypPdListtmp.strMaxWFCount = vbNullString 
                                mtypPdList(llngCnt) = mtypPdListtmp
                            End If
                        
                            '@ｺﾝﾎﾞ内容設定：機種ID/最大WF枚数
                            .AddItem(mtypPdList(llngCnt).strProductID _
                                   & vbTab _
                                   & mtypPdList(llngCnt).strMaxWFCount)
                        End If
                    Next
                
                    '@機種が1件か
                    If .ListCount = 1 Then
                    
                        '@ﾃﾞﾌｫﾙﾄで表示する
                        .ListIndex = 0
                    End If
                End If
                
                '@値取得列を最大WF枚数列に設定
                .ValueCol = CMlngComboDispCols1
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbPd_Disp"
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
    '作成日：2005/06/23 (Thu) 10:53:17 S.Deguchi
    '更新日：2008/06/09 (Mon) 13:18:29 N.Kojima
    '備　考：
    '　　　：2008/06/09 (Mon) 13:18:29 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub prvCmbLotManager_Disp()

        Dim llngCnt As Integer      '汎用ｶｳﾝﾀ

        Try

            '@ｺﾝﾎﾞ作成
            With cmbLotManager
            
                For llngCnt = 0 To mlngLotManagerListCnt-1
                            
                    '@ｺﾝﾎﾞ内容設定：ﾛｯﾄ担当者名/ﾛｯﾄ担当者ID
                    .AddItem(mtypLotManagerList(llngCnt).strTechManName _
                           & vbTab _
                           & mtypLotManagerList(llngCnt).strTechManID)
                Next
                
                '@値取得列をﾛｯﾄ担当者ID列に設定
                .ValueCol = CMlngComboDispCols1
                
                '@ﾛｯﾄ担当が1件の場合は表示
                If .ListCount = 1 Then
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

    '関数名：prvCmbLotSend_Set
    '機　能：送品ｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/10/31 (Tue) 14:51:33 N.Kasai
    '更新日：2013/11/26 (Tue) 15:19:41 T.Oide
    '備　考：
    '　　　：2008/06/06 (Fri) 12:53:58 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
    '　　　：2013/11/26 (Tue) 15:19:41 T.Oide       GNS対応
    Private Sub prvCmbLotSend_Set()

        Try
            
            '@種別がNULLか
            If cmbDivision.Value = vbNullString Then
                Exit Sub
            End If
            
            '@★ 種別により処理分岐 ★
            Select Case cmbDivision.Value
                    
                '@〓 ﾀﾞﾐｰ(SD,FD,ED)、ﾓﾆﾀ(MO) 〓
                Case CPstrFillerDummy, CPstrSideDummy, CPstrExtraDummy, CPstrFlowClassMO
                    
                    '@「送品なし」に固定(変更不可)
                    With cmbLotSend
                        .Enabled = False    '無効
                        .ListIndex = 0      'なし
                    End With
                
                '@〓 品確(QU) 〓
                Case CPstrFlowClassQU
                
                    '送品の設定は空か
                    If cmbLotSend.ListIndex = -1 Then
                        '@「送品なし」(変更可)
                        With cmbLotSend
                            .Enabled = True     '有効
                            .ListIndex = 0      'なし
                        End With
                    End If
                
        '@↓2013/11/26 (Tue) 15:21:23 T.Oide **************************************************
        '@        '@〓 その他(TS,WS,ZZ等)
        '@        Case Else
        '@
        '@            '@送品ｺﾝﾎﾞを有効にする
        '@            cmbLotSend.Enabled = True
        '@------------------------------------------------------------------------------------
                
                '@〓 WS,TS,ZZ,GG 〓
                Case CPstrFlowClassWS, CPstrFlowClassTS, CPstrFlowClassZZ, CPstrFlowClassGG
                
                    '@送品を有効で無選択にする
                    cmbLotSend.ListIndex = -1
                    cmbLotSend.Enabled = True
                
                '@〓 以外(PR、ES) 〓
                Case Else
                
                    '@送品を"あり"で無効にする
                    cmbLotSend.ListIndex = 1
                    cmbLotSend.Enabled = False
                
        '@↑2013/11/26 (Tue) 15:21:23 T.Oide **************************************************
                
                    
            End Select
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbLotSend_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/06/10 (Tue) 12:52:12 N.Kojima **************************************************
    '関数名：prvCmdRegistControl_Proc
    '機　能：確定ﾎﾞﾀﾝ制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/06 (Fri) 14:46:20 N.Kojima
    '更新日：2008/06/06 (Fri) 14:46:20
    '備　考：
    Private Sub prvCmdRegistControl_Proc()

        Try
            
            '@ﾏｽﾀ工順にﾁｪｯｸされているか
            If optMster.Checked = True Then
            
                '@ｴﾝﾄﾘIDがNULLか
                If lblEntryID.Text = vbNullString Then
                
                    '@確定ﾎﾞﾀﾝを無効にする
                    cmdRegist.Enabled = False
                    Exit Sub
                End If
            End If
            
            '@確定ﾎﾞﾀﾝを有効にする
            cmdRegist.Enabled = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdRegistControl_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/06/10 (Tue) 12:52:12 N.Kojima **************************************************

    '関数名：prvstrClassDivision_Set
    '機　能：処理区分設定
    '引　数：なし
    '戻り値：処理区分計算値
    '作成日：2004/04/14 (Wed) 09:38:33 K.Takano
    '更新日：2008/06/10 (Tue) 10:13:48 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 10:13:48 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2008/09/03 (Wed) 07:07:53 T.Sawaguchi  工順なしﾌｨｰﾙﾄﾞを削除　(案件03141)
    Private Function prvstrClassDivision_Set() As String
        
        Dim lstrKbn         As String       '処理区分4桁
                                            '①　0M0Q：新規/ﾛｯﾄ工順
                                            '②　0MOR：新規/ﾏｽﾀ工順
                                            '③　0MOS：新規/工順なし
                                            '④　0NOQ：分割/ﾛｯﾄ工順
                                            '⑤　0NOR：分割/ﾏｽﾀ工順
                                            '⑥　0NOS：分割/工順なし
                                            
        Try
                                                
            '@***********************
            '@　ﾛｯﾄ作成基礎情報
            '@***********************
            '@★ ﾁｪｯｸされているｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
            Select Case True
            
                '@〓 新規ﾛｯﾄID採番 〓
                Case optNew.Checked 
                
                    lstrKbn = CPstrCD0M                 '0M
                    
                '@〓 分割ﾛｯﾄID採番 〓
                Case optDivide.Checked 
                
                    lstrKbn = CPstrCD0N                 '0N
            End Select
            
            
            '@***********************
            '@　ﾛｯﾄ工順情報
            '@***********************
             '@★ ﾁｪｯｸされているｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
            Select Case True
                '@〓 工順ｺﾋﾟｰ 〓
                Case optCopy.Checked 
                
                    lstrKbn = lstrKbn & CPstrCD0Q       '(0M or 0N)+0Q
                    
                '@〓 ﾏｽﾀ工順 〓
                Case optMster.Checked 
                
                    lstrKbn = lstrKbn & CPstrCD0R       '(0M or 0N)+0R
                
            End Select
            
            '@戻り値に設定した処理区分を格納
            prvstrClassDivision_Set = Trim(lstrKbn)
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvstrClassDivision_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnLotReserve_Chk
    '機　能：確定時ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2004/02/20 (Fri) 09:37:11 M.Miura
    '更新日：2011/05/06 (Fri) 15:53:48 T.Oide
    '備　考：
    '　　　：2005/12/21 (Wed) 12:07:55 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(ﾕｰｻﾞｰ要望№0134)
    '　　　：2008/06/10 (Tue) 11:28:24 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
    Private Function prvblnLotReserve_Chk() As Boolean

        Dim lstrStartDT             As String       '投入予定日格納用
        Dim lstrNowDT               As String       '現在日付格納用
    '@↓2011/05/06 (Fri) 15:54:47 T.Oide **************************************************
        Dim lstrAns                 As String       '確認結果
    '@↑2011/05/06 (Fri) 15:54:47 T.Oide **************************************************

        Try
            
            '@戻り値の初期化
            prvblnLotReserve_Chk = False
            
            '@-----------------------
            '@　新規ﾛｯﾄID採番
            '@-----------------------
            '@新規ﾛｯﾄID採番にﾁｪｯｸされているか
            If optNew.Checked = True Then
                
                '@機種がNULLか
                If cmbPD.Value = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0013)
                    '@ﾒｯｾｰｼﾞ："<TRM13W>$$機種が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@機種にﾌｫｰｶｽｾｯﾄし、処理終了
                    Call pubSetFocus(cmbPD)
                    Exit Function
                End If
                
                '@種別がNULLか
                If cmbDivision.Value = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0014)
                    '@ﾒｯｾｰｼﾞ："<TRM14W>$$種別が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@種別にﾌｫｰｶｽｾｯﾄし、処理終了
                    Call pubSetFocus(cmbDivision)
                    Exit Function
                End If
                
                '@WF枚数がNULL、または"0"か
                If txtWFNum.Text = vbNullString Or txtWFNum.Text = "0" Then
                   
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0015)
                    '@ﾒｯｾｰｼﾞ："<TRM15W>$$ウエハ枚数を指定して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@WF枚数にﾌｫｰｶｽｾｯﾄし、処理終了
                    Call pubSetFocus(txtWFNum)
                    Exit Function
                End If
                
                '@投入予定日を格納
                lstrStartDT = Format$(CDate(calStartDate.Value), CPstrDateTimeYMD)
                '@現在日付を格納
                lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                
                '@投入予定日が日付型か
                If IsDate(lstrStartDT) = True Then
                    
                    '@投入予定日が現在日より過去か
                    If lstrStartDT < lstrNowDT Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                        '@ﾒｯｾｰｼﾞ："<TRM10W>$$過去の日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@投入予定日にﾌｫｰｶｽｾｯﾄし、処理終了
                        Call pubSetFocus(calStartDate)
                        Exit Function
                    End If
                Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                    '@ﾒｯｾｰｼﾞ："<TRM16W>$$設定されていない項目があります。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@投入予定日にﾌｫｰｶｽｾｯﾄし、処理終了
                    Call pubSetFocus(calStartDate)
                    Exit Function
                End If
                
        '@↓2013/11/26 (Tue) 16:11:42 T.Oide **************************************************
        '@        '@ﾛｯﾄ担当がNULLか
        '@        If cmbLotManager.Value = vbNullString Then
        '@
        '@            '@表示ﾒｯｾｰｼﾞ変換
        '@            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0017)
        '@            '@ﾒｯｾｰｼﾞ："<TRM17W>$$ロット担当が設定されていません。設定を見直してください。"
        '@            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM00M0.Caption, True, 16)
        '@
        '@            '@ﾛｯﾄ担当にﾌｫｰｶｽｾｯﾄし、処理終了
        '@            Call pubSetFocus(cmbLotManager)
        '@            Exit Function
        '@        End If
        '@---------------------------------------------------------------------------------------

                '@PRとES以外でロット担当NULLか
                If ((cmbDivision.Text = CPstrFlowClassPR Or _
                     cmbDivision.Text = CPstrFlowClassES) = False And _
                     cmbLotManager.Value = vbNullString) Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0017)
                    '@ﾒｯｾｰｼﾞ："<TRM17W>$$ロット担当が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾛｯﾄ担当にﾌｫｰｶｽｾｯﾄし、処理終了
                    Call pubSetFocus(cmbLotManager)
                    Exit Function
                    
                End If
        '@↑2013/11/26 (Tue) 16:11:42 T.Oide **************************************************
            
                '@P/Rｵｰﾀﾞｰが有効で、かつNULLか
                If cmbPrOrder.Enabled = True And cmbPrOrder.Value = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007L)
                    '@ﾒｯｾｰｼﾞ："<TRM7LW>$$P/Rオーダーが設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@P/Rｵｰﾀﾞｰにﾌｫｰｶｽｾｯﾄし、処理終了
                    Call pubSetFocus(cmbPrOrder)
                    Exit Function
                End If
                
                '@送品がNULLか(-1：NULL)
                If cmbLotSend.ListIndex = -1 Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008Z)
                    '@ﾒｯｾｰｼﾞ："<TRM8ZW>$$送品が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@送品にﾌｫｰｶｽｾｯﾄし、処理終了
                    Call pubSetFocus(cmbLotSend)
                    Exit Function
                End If
                
            End If
            

            '@-----------------------
            '@　分割ﾛｯﾄID採番
            '@-----------------------
            '@分割ﾛｯﾄID採番にﾁｪｯｸされているか
            If optDivide.Checked = True Then
                
                '@分割元ﾛｯﾄIDがNULLか
                If txtDivideLotID.Text = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                    '@ﾒｯｾｰｼﾞ："<TRM16W>$$設定されていない項目があります。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@送品にﾌｫｰｶｽｾｯﾄし、処理終了
                    Call pubSetFocus(txtDivideLotID)
                    Exit Function
                End If
                
                '@分割元ﾛｯﾄIDが10桁以外か
                If Len(txtDivideLotID.Text) <> CMlngLotIDByte Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                    '@ﾒｯｾｰｼﾞ："<TRM12W>$$ロットIDは10桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@分割元ﾛｯﾄIDにﾌｫｰｶｽｾｯﾄし、処理終了
                    Call pubSetFocus(txtDivideLotID)
                    Exit Function
                End If
            End If
            
            
            '@-----------------------
            '@　ﾏｽﾀ工順
            '@-----------------------
            '@ﾏｽﾀ工順にﾁｪｯｸされているか
            If optMster.Checked = True Then
            
                '@ﾛｯﾄ予約送信ﾃﾞｰﾀ格納構造体にｴﾝﾄﾘを格納する
                mtypLotReserve.strMasVer = lblEntryID.Text
                
                '@ｴﾝﾄﾘがNULLか
                If mtypLotReserve.strMasVer = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                    '@ﾒｯｾｰｼﾞ："<TRM16W>$$設定されていない項目があります。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ｴﾝﾄﾘﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄし、処理終了
                    Call pubSetFocus(cmdEntry)
                    Exit Function
                End If
                
                '@ﾛｯﾄ予約送信ﾃﾞｰﾀ格納構造体の工順ｺﾋﾟｰﾛｯﾄIDをｸﾘｱする
                mtypLotReserve.strCopySeqLotID = vbNullString
            End If
            

            '@-----------------------
            '@　工順ｺﾋﾟｰ
            '@-----------------------
            '@工順ｺﾋﾟｰにﾁｪｯｸされているか
            If optCopy.Checked = True Then
            
                '@工順ｺﾋﾟｰﾛｯﾄIDがNULLか
                If txtCopyLotID.Text = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                    '@ﾒｯｾｰｼﾞ："<TRM16W>$$設定されていない項目があります。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@工順ｺﾋﾟｰﾛｯﾄIDにﾌｫｰｶｽｾｯﾄし、処理終了
                    Call pubSetFocus(txtCopyLotID)
                    Exit Function
                End If
                
                '@工順ｺﾋﾟｰﾛｯﾄIDが10桁以外か
                If Len(txtCopyLotID.Text) <> CMlngLotIDByte Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                    '@ﾒｯｾｰｼﾞ："<TRM12W>$$ロットIDは10桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@工順ｺﾋﾟｰﾛｯﾄIDにﾌｫｰｶｽｾｯﾄし、処理終了
                    Call pubSetFocus(txtCopyLotID)
                    Exit Function
                End If
                
                '@ﾛｯﾄ予約送信ﾃﾞｰﾀ格納構造体の情報をｸﾘｱする
                mtypLotReserve.strMasVer = vbNullString             'ｴﾝﾄﾘ
                mtypLotReserve.strCopySeqLotID = txtCopyLotID.Text  '工順ｺﾋﾟｰﾛｯﾄID
                
            End If
            
        '@↓2011/05/06 (Fri) 15:37:11 T.Oide **************************************************
            'QUで送品[あり]か
            If cmbDivision.Text = CPstrFlowClassQU And cmbLotSend.Value = 1 Then
            
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0109)
                    '@ﾒｯｾｰｼﾞ："<TRM14W>$$品確ロットで送品[あり]が選択されています。よろしいですか?"
                    lstrAns = publngMsgBoxInfo(pstrDMsg, vbOKCancel, Me.Text, True, 16)
                    
                    If lstrAns = vbCancel Then
                        '@処理終了
                        Exit Function
                    End If
            End If
        '@↑2011/05/06 (Fri) 15:37:11 T.Oide **************************************************
            
            
            '@戻り値に"True：成功"をｾｯﾄする
            prvblnLotReserve_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotReserve_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function


    '関数名：prvcmbLotThrowinNum_Init
    '機　能：投入ロット数のコンボリストを作成する
    '引　数：なし
    '戻り値：
    '作成日：2013/11/26 (Tue) 18:27:10 T.Oide
    '更新日：2013/11/26 (Tue) 18:27:10
    '備　考：
    Private Sub prvcmbLotThrowinNum_Init()

        Dim llngCnt     As Integer

        Try

            '@CMlngLotCountの回数繰返
            For llngCnt = 1 To CMlngLotCount
                cmbLotThrowinNum.AddItem(llngCnt)
            Next

            '@投入ロット数を1に初期化
            cmbLotThrowinNum.ListIndex = 0

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotReserve_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLotTrowinRsv
    '機　能：投入予定ロット登録
    '引　数：なし
    '戻り値：
    '作成日：2013/11/26 (Tue) 18:55:37 T.Oide
    '更新日：2013/11/26 (Tue) 18:55:37
    '備　考：
    Private Sub prvLotTrowinRsv()
        
        Dim lblnAns                 As Boolean      '戻り値格納用(True/False)

        Try
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
            
            '@作業確定者IDを設定
            mtypLotReserve.strEmpID = pstrUserID
            
            '@ﾛｯﾄIDをｸﾘｱ
            lblLotID.Text = vbNullString
            
            '@【ﾛｯﾄ投入予約】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnLotThrowrsv_Ins(CMstrlot_throwrsvVer, _
                                            mtypLotReserve)
            
            '@ﾛｯﾄ投入予約結果判定
            If lblnAns = True Then
                '@ﾛｯﾄ投入予約結果：正常の場合
            
                '@ﾛｯﾄIDを表示する
                lblLotID.Text = mtypLotReserve.strLotID
                        
                '@【ﾛｯﾄ予約承認】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnLotApprove_Ins(CMstrlot_approveVer, _
                                               mtypLotReserve)
                
                '@ﾛｯﾄ予約承認結果判定
                If lblnAns = True Then
                    '@ﾛｯﾄ予約承認結果：正常の場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0003, lblLotID.Text)
                    '@ﾒｯｾｰｼﾞ："<TRM03I>$$投入予定ロット[%1]を登録しました。"
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)

                    '@作業ﾒﾓをｸﾘｱする
                    txtWorkMemo.Text = vbNullString
                    
                    Exit Sub
                End If
            Else
            
                '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
            End If
            
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraCopy.Paint, fraDivide.Paint, fraMster.Paint, fraNew.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
