'ﾌｧｲﾙ名：xxMN0000.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：メニュー画面
'作成日：2004/04/13 (Tue) 18:09:44 T.Oide
'更新日：2008/07/14 (Mon) 13:21:28 N.Kojima
'備　考：ﾒﾆｭｰから起動するｸﾘｱを追加する場合は、備考欄に
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxMN0000
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxMN0000    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxMN0000
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxMN0000
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxMN0000)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    '*******************************************************************************
    '　　　　　　　　　　　　　　 　　* 型の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '@ﾒﾆｭｰ一覧
    Private Structure MenuItem
        Dim strTitle            As String       'ﾒﾆｭｰﾀｲﾄﾙ
        Dim strKey              As String       'ﾒﾆｭｰｷｰ
        Dim lngCarrTakeOver     As Integer      'ｷｬﾘｱID引継ぎﾌﾗｸﾞ(0: なし､1: あり)
        Dim lngTab              As Integer      '格納ﾀﾌﾞ
    End Structure

    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 定数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrFormMN0000         'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrutilrefmenu_Ver              As String = "01.00"                 'お気に入り取得
    Private Const CMstrutilregmenu_Ver              As String = "01.00"                 'お気に入り登録

    '@ﾒﾆｭｰ情報
    Private Const CMstrMenuIdFlow                   As String = "MENUFLOW"              'ﾕｰｻﾞｰID/流動系ｺｰﾄﾞ
    Private Const CMstrMenuIdTool                   As String = "MENUTOOL"              'ﾕｰｻﾞｰID/ﾂｰﾙ系ｺｰﾄﾞ
    Private Const CMstrSpcWeb                       As String = "品質管理ツール、WEB"    '表示ﾒｯｾｰｼﾞ用

    '@ﾒﾆｭｰ画面のｻｲｽﾞ関連
    Private Const CMlngMenuNarrowLeft               As Integer = CPlngAppliWideWidth    'ﾒﾆｭｰのLeft(小)
    Private Const CMlngMenuNarrowWidth              As Integer = 840                    'ﾒﾆｭｰのWidth(小)

    Private Const CMlngStatusHeightMargin           As Integer = 105                    'ﾒｯｾｰｼﾞのﾌｫｰﾑとｸﾞﾘｯﾄﾞの高さの差
    Private Const CMlngStatusWidthMargin            As Integer = 1560                   'ﾒｯｾｰｼﾞのﾌｫｰﾑとｸﾞﾘｯﾄﾞの幅の差
    Private Const CMlngStatusBigUpDownSize          As Integer = 735                    'ﾒｯｾｰｼﾞの▲▼ﾎﾞﾀﾝのｻｲｽﾞ(大)
    Private Const CMlngStatusSmallUpDownSize        As Integer = 375                    'ﾒｯｾｰｼﾞの▲▼ﾎﾞﾀﾝのｻｲｽﾞ(小)
    Private Const CMlngStatusSizeButtonTopMargin    As Integer = 805                    'ﾒｯｾｰｼﾞの最大・最小ﾎﾞﾀﾝのTop
    Private Const CMlngStatusSizeButtonLeftMargin   As Integer = 870                    'ﾒｯｾｰｼﾞの最大・最小ﾎﾞﾀﾝのｸﾞﾘｯﾄﾞからのLeftの差
    Private Const CMlngStatusSizeButtonSize         As Integer = 480                    'ﾒｯｾｰｼﾞの最大・最小ﾎﾞﾀﾝのｻｲｽﾞ

    '@ﾒﾆｭｰﾊﾞｰｶﾗｰ
    Private Const CMlngDeveBackColor                As Integer = &HFF&                  '開発("D")
    Private Const CMlngReleaseBackColor             As Integer = &H80CED3D6             'ﾘﾘｰｽ("R")
    Private Const CMlngMstEqBackColor               As Integer = &HFF0000               'ﾏｽﾀ、装置("E"、"T")

    '@ｳｨﾝﾄﾞｳをｳｨﾝﾄﾞｳﾘｽﾄの一番上に配置する
    Private Const HWND_TOPMOST = (-1)

    '@ｳｨﾝﾄﾞｳの現在のｻｲｽﾞを保持する
    Private Const SWP_NOSIZE = &H1&

    '@ｳｨﾝﾄﾞｳの現在位置を保持する
    Private Const SWP_NOMOVE = &H2&

    '@ﾌﾟﾛｾｽ関連API用
    Private Const STILL_ACTIVE = &H103&

    '@ｸﾘｱｹｰｼｮﾝをｸﾛｰｽﾞする時
    '@ｳｨﾝﾄﾞｳに送られるﾒｯｾｰｼﾞ
    Private Const WM_CLOSE As Integer = &H10
    Private Const WM_QUIT As Integer = &H12

    '@ﾌｫｰﾑ名
    Private Const CMstrfrmxxMN0001                  As String = "frmxxMN0001"           'お気に入り登録画面ﾌｫｰﾑ名
    Private Const CMstrfrmxxCM0100                  As String = "frmxxCM0100"           'お気に入り登録画面ﾌｫｰﾑ名

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                     As String = "frmxxMN0000"           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                     As String = "Form_Load"             'Form_Load処理
    Private Const CMstrPrvMenuFavoritesGet          As String = "prvMenuFavorites_Get"  'お気に入り取得処理
    Private Const CMstrPrvRegMenuSet                As String = "prvRegMenu_Set"        'お気に入り登録処理

    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    Private mblnFormLoadedFlag                      As Boolean                          'ﾌｫｰﾑ起動済ﾌﾗｸﾞ(True：表示済、False：未表示)
    Private mblnDeActivateFlag                      As Boolean                          'ﾌｫｰﾑ無効処理実行ﾌﾗｸﾞ(True：実行済、False：未実行)
    Private mtypMenuItem                            As List(Of MenuItem)                'ﾒﾆｭｰ項目
    Private mintButton                              As Integer                          'ﾏｳｽﾎﾞﾀﾝ

    '@IMEﾓｰﾄﾞの指定に使用
    Private mlnghDefaultContext                     As Integer

    '@その他
    Private mblnDoEventsFlag                        As Boolean                          'DoEvents処理ﾌﾗｸﾞ(True:実行せず/False実行)
    Private mlngExeWebDispFlag                      As Integer                          'EXE、WEB起動判定ﾌﾗｸﾞ(0：未起動、1：EXE,WEB起動済)
    Private mlngExeWebDispItemCnt                   As Integer                          'EXE、WEB起動ﾒﾆｭｰ項目数
    Private mtypExeWebDispItem                      As List(Of MenuItem)                'EXE、WEB起動ﾒﾆｭｰ項目格納用配列

    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策

    Private cmdvsfFlows()                           As System.Windows.Forms.Button      'NSYS 流動系動的ボタン
    Private cmdvsfTools()                           As System.Windows.Forms.Button      'NSYS ツール系動的ボタン
    Private cmdvsfFavoritess()                      As System.Windows.Forms.Button      'NSYS お気に入り動的ボタン

    Private mfrmRootForm                            As Form                             'NSYS 非表示の共通ルートフォーム

    Private mblnActivateAfterShown                  As Boolean                          'NSYS Shownの後のActivateの場合True

    '*******************************************************************************
    '　　　　　　　　　　　　　      * ＡＰＩの記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '@IMEﾓｰﾄﾞを指定する
    '@指定したｳｨﾝﾄﾞｳにIMEｺﾝﾃｷｽﾄﾊﾝﾄﾞﾙを関連付ける
    Private Declare Function ImmAssociateContext Lib "Imm32.dll" (ByVal hwnd As Integer, ByVal hIMC As Integer) As Integer
    '@現在関連付けられているIMEｺﾝﾃｷｽﾄﾊﾝﾄﾞﾙを得る
    Private Declare Function ImmGetContext Lib "Imm32.dll" (ByVal hwnd As Integer) As Integer

    '@ｸﾗｽ名又はｷｬﾌﾟｼｮﾝﾀｲﾄﾙを与えて
    '@ｳｨﾝﾄﾞｳのﾊﾝﾄﾞﾙを取得する
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    '@ﾌﾟﾛｾｽﾊﾝﾄﾞﾙ関連
    Private Declare Function GetExitCodeProcess Lib "kernel32" (ByVal hProcess As IntPtr, ByRef lpExitCode As UInteger) As Boolean

    '*******************************************************************************
    '　　　　　　　　　　　　　* イベントハンドラの記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 18:10:02 T.Oide
    '更新日：2008/06/23 (Mon) 14:42:14 N.Kojima
    '備　考：
    '　　　：2004/09/16 (Thu) 13:08:05 H.Wajima     初期表示で、ﾒﾆｭｰが閉じた状態になるよう変更
    '　　　：2004/10/08 (Fri) 13:22:00 N.Kojima     ﾒﾆｭｰﾊﾞｰの色を起動ﾓｰﾄﾞにより分ける(不具合№1059)
    '　　　：2004/11/04 (Thu) 17:18:26 M.Miura　    ｷｬﾘｱID引継ぎﾌﾗｸﾞを有効を追加(不具合№190)
    '　　　：2005/02/07 (Mon) 15:25:04 S.Deguchi    ﾛｸﾞｲﾝ情報登録処理追加(不具合№435)
    '　　　：2008/06/23 (Mon) 14:42:14 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub Form_Load() Handles Me.Load
        
        Dim llngRet                 As Integer      '戻り値(整数値)
        Dim lblnAnsInit             As Boolean      'ACT初期化結果
        Dim lblnRet                 As Integer      '戻り値
        Dim ltypDummyCommonInfo     As CommonInfo   'ﾀﾞﾐｰ引継ぎ情報

        Try
            'NSYS 1つのインスタンスを使用するため、自フォームを設定
            _instance = Me

            'NSYS 非表示の共通ルートフォーム 生成
            mfrmRootForm = New Form()
            mfrmRootForm.Name = "Invisible Root Form"
            mfrmRootForm.Text = "Invisible Root Form"

            'NSYS オーナーをルートフォームに設定
            Me.Owner = mfrmRootForm
            
            '@FormLoad済ﾌﾗｸﾞに"False：未完"をｾｯﾄ
            mblnFormLoadedFlag = False
            
            '@お気に入り編集ﾌﾗｸﾞに"False：編集なし"をｾｯﾄ
            pblnFavoritesEdit = False
            
            '@=======================
            '@　ｺﾏﾝﾄﾞﾗｲﾝ引数取得＆ﾁｪｯｸ処理
            '@=======================
            lblnRet = pubblnCommand_Chk
            
            '@ｺﾏﾝﾄﾞﾗｲﾝ引数取得＆ﾁｪｯｸ処理結果判定
            If lblnRet = False Then
                '@ｺﾏﾝﾄﾞﾗｲﾝ引数取得＆ﾁｪｯｸ処理結果：異常の場合
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrMessageName = "起動"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0070)
                '@ﾒｯｾｰｼﾞ："<TRM70W>$$起動時の情報が不足しています。システム担当者に連絡してください。"
                Call publngMsgBox(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                Me.Close()
                
                End
            Else
                '@ｺﾏﾝﾄﾞﾗｲﾝ引数取得＆ﾁｪｯｸ処理結果：正常の場合
                
                '@★ 起動ﾓｰﾄﾞにより処理分岐 ★
                Select Case pstrCommand
                
                    '@〓 D：開発 〓
                    Case CPstrDeveStatus
                        
                        '@ﾒﾆｭｰ拡張ﾎﾞﾀﾝの設定
                        cmdExpand.BackColor = ColorTranslator.FromWin32(CMlngDeveBackColor)     '背景色：赤
                        cmdExpand.BackgroundImage = picMenuBarChar1.Image                       '開発用のﾛｺﾞを貼り付ける
                        
                    '@〓 R：運用 〓
                    Case CPstrReleStatus
                    
                        '@ﾒﾆｭｰ拡張ﾎﾞﾀﾝの設定
                        cmdExpand.BackColor = ColorTranslator.FromWin32(CMlngReleaseBackColor)  '背景色：ｸﾞﾚｰ
                        cmdExpand.BackgroundImage = picMenuBarChar3.Image                       '運用用のﾛｺﾞを貼り付ける
                        
                    '@〓 T、E：ﾃｽﾄor装置検収 〓
                    Case Else
                        
                        cmdExpand.BackColor = ColorTranslator.FromWin32(CMlngMstEqBackColor)    '背景色：青
                        cmdExpand.BackgroundImage = picMenuBarChar2.Image                       'ﾃｽﾄ用のﾛｺﾞを貼り付ける
                End Select
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@=======================
            '@　ACTの初期化処理( + ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰ起動処理)
            '@=======================
            lblnAnsInit = pubblnAct_Init
            
            '@ACTの初期化処理結果判定
            If lblnAnsInit = False Then
                '@ACTの初期化処理：異常(失敗)の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ﾒﾆｭｰのｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                Me.Close()
                
                Exit Sub
            End If
            
            '@ｷｬﾘｱID引継ぎﾌﾗｸﾞに1：有効(引継ぎ)"をｾｯﾄ
            plngTakingOverFlag = CPlngMenuCarrTakeOverOn
            
            '@=======================
            '@　機能情報取得処理
            '@=======================
            lblnRet = pubblnFuncInfo_Set
            
            '@機能情報取得処理結果判定
            If lblnRet = False Then
                '@機能情報取得処理：異常(失敗)の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ﾒﾆｭｰのｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                Me.Close()
                
                Exit Sub
            End If
            
            '@=======================
            '@　ﾒﾆｭｰｸﾞﾘｯﾄﾞの初期化処理
            '@=======================
            Call prvVsfGrid_Init(Me)
            
            '@=======================
            '@　ﾒﾆｭｰ項目の設定処理
            '@=======================
            lblnRet = prvblnMenuItem_Set
            
            '@ﾒﾆｭｰ項目の設定処理結果判定
            If lblnRet = False Then
                '@ﾒﾆｭｰ項目の設定処理結果：異常(失敗)の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000D)
                '@「<TRM0DE>$$ﾒﾆｭｰ項目が取得できません。 システム担当者に連絡して下さい。」ﾒｯｾｰｼﾞ表示
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, CPstrMenuFormCaption, True, 16)
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ﾒﾆｭｰのｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                Me.Close()
                
                Exit Sub
            End If
            
            '@=======================
            '@　ﾒﾆｭｰｸﾞﾘｯﾄﾞ項目設定処理
            '@=======================
            Call prvMenuGrid_Edit(Me)
            
            '@***********************
            '@　ｸﾞﾘｯﾄﾞ共通関数で上下ﾎﾞﾀﾝを初期化
            '@***********************
            '@=======================
            '@　流動系ﾀﾌﾞ
            '@=======================
            Call pubVsfDisp(vsfFlow, cmdFlowUp, cmdFlowDown)
            
            '@=======================
            '@　ﾂｰﾙ系ﾀﾌﾞ
            '@=======================
            Call pubVsfDisp(vsfTool, cmdToolUp, cmdToolDown)
            
            '@=======================
            '@　お気に入りﾀﾌﾞ
            '@=======================
            Call pubVsfDisp(vsfFavorites, cmdFavoritesUp, cmdFavoritesDown)
            
            '@=======================
            '@　ｺﾏﾝﾄﾞﾎﾞﾀﾝの設定処理
            '@=======================
            Call prvGridMenuButton_Init()
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰ　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰ　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            'NSYS pubblnAct_Init() によりすでに表示されている
            'NSYS ステータス画面のオーナーをルートフォームにする
            frmxxCM0100.Instance.Owner = mfrmRootForm
            
            '@=======================
            '@　お知らせ画面表示処理
            '@=======================
            llngRet = publngStart_Proc(CPstrKeyMN0002, False, ltypDummyCommonInfo, mfrmRootForm)
            
            '@お知らせ画面表示処理結果判定
            If llngRet = CPlngErrorStatusCD Then
                '@お知らせ画面表示処理結果：異常(失敗)の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ﾒﾆｭｰのｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                Me.Close()
                
                Exit Sub
            End If
            
        '@↓2008/07/14 (Mon) 11:12:24 N.Kojima **************************************************
        '    '@FormLoad済ﾌﾗｸﾞに"True：起動済"をｾｯﾄ
        '    mblnFormLoadedFlag = True
        '@↑2008/07/14 (Mon) 11:12:24 N.Kojima **************************************************
            
            '@EXE＆WEB起動判定ﾌﾗｸﾞ、ｶｳﾝﾀの初期化
            mlngExeWebDispFlag = 0
            mlngExeWebDispItemCnt = 0
            
            '@初期起動ﾌﾟﾛｸﾞﾗﾑを指定する
            vsfFlow.SetData(0, CPlngMenuExecuteCol, CPlngMenuExecuteFlg)
            
            '@起動中ﾌﾟﾛｸﾞﾗﾑ名を初期化する
            pstrExecuteMenuKey = CPstrKeyMN0002
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set()
            
            '@***********************
            '@　初期表示ﾀﾌﾞ設定
            '@***********************
            '@お気に入りﾀﾌﾞに項目が設定されていないか
            If vsfFavorites.GetData(0, CPlngMenuKeyCol) = vbNullString Then
                '@お気に入りに項目が設定されていない場合
                
                '@流動系ﾀﾌﾞを初期表示する
                tabMenu.SelectedIndex = CPlngMenuTabFlow
            Else
                '@お気に入りに項目が設定されている場合
                
                '@お気に入りﾀﾌﾞを初期表示する
                tabMenu.SelectedIndex = CPlngMenuTabFavorites
            End If
            
            '@初期表示のため、強制的にLeftを設定する
            '@ﾒﾆｭｰが閉じた状態→CPlngAppliNarrowWidth、ﾒﾆｭｰが開いた状態→CPlngAppliWideWidthで設定できます。
            Me.Left = CPlngAppliNarrowWidth
            
            '@=======================
            '@　ﾒﾆｭｰｻｲｽﾞ変更処理
            '@=======================
            Call pubMenuExpand_Disp(False)
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)

            'NSYS VB6ではこの時点で ActiveControl は Nothing だが、.NETで Nothing にすると
            '     どこにもフォーカスがない状態になるので、明示的に cmdExpandボタンにセットする
            Me.ActiveControl = cmdExpand

            'NSYS 静的イベントハンドラ追加
            AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

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

    '@↓2008/07/07 (Mon) 13:00:14 N.Kojima **************************************************
    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/07/07 (Mon) 11:40:21 N.Kojima
    '更新日：2008/07/07 (Mon) 11:40:21
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Dim lblnDispFlag        As Boolean      'WEB、EXE表示判定ﾌﾗｸﾞ(True：表示、False：非表示)
        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ
        Dim llngRet             As Integer      '汎用戻り値格納用
        Dim llngExitCode        As Integer      '終了ｺｰﾄﾞ
        Dim ltypMousePos        As Point        'NSYS マウスカーソル位置

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞ済ﾌﾗｸﾞが"False：未表示"か(1回目のActivateはﾌｫｰﾑﾛｰﾄﾞ済ﾌﾗｸﾞを"True"にして終了)
            If mblnFormLoadedFlag = False Then

                '@FormLoad済ﾌﾗｸﾞに"True：表示済"をｾｯﾄ
                mblnFormLoadedFlag = True
                Exit Sub
            End If

            'NSYS 起動直後、メニュー画面をアクティブ画面にする処理でメニューが展開しないようにする。
            'NSYS VB.NET では、Activate → Deactivate → Shown の順でイベントが発生し、起動直後、お知らせ画面がアクティブになる。
            'NSYS そこで、Shown の中で Me.Activate する。その時、再び Activate イベント(2回目)が発生する。
            If mblnActivateAfterShown = True Then

                mblnActivateAfterShown = False
                Exit Sub
            End If

            'NSYS 非クライアント領域(タイトルバー等)でのマウスダウン時
            ltypMousePos = PointToClient(MousePosition)
            If ltypMousePos.Y < 0 AndAlso 0 <= ltypMousePos.X AndAlso ltypMousePos.X < Width Then
                'NSYS 処理を行わない
                Exit Sub
            End If

            '@ﾌｫｰﾑ無効処理実行ﾌﾗｸﾞが"True：実行済"か
            If mblnDeActivateFlag = True Then
                
                '@上記ﾌﾗｸﾞがTrueの場合はForm_Deactivateでﾒﾆｭｰ伸縮処理を完了しているので、処理抜け
                Exit Sub
            End If
            
            '@ﾌｫｰﾑﾛｰﾄﾞ済ﾌﾗｸﾞが"True：表示済"か(2回目以降の場合)
            If mblnFormLoadedFlag = True Then

                lblnDispFlag = False

                '@WEBが表示されているか
                If IsWindow(plngInetExphWnd) <> 0 Then

                    '@WEB、EXE表示判定ﾌﾗｸﾞに"True：表示"をｾｯﾄ
                    lblnDispFlag = True
                End If
                
                '@EXEが起動されているか
                If ptypExeInfoCnt > 0 Then

                    For llngCnt = 0 To ptypExeInfo.Count - 1

                        '@=======================
                        '@　起動ﾌﾟﾛｾｽの存在判定処理
                        '@=======================
                        llngRet = GetExitCodeProcess(ptypExeInfo(llngCnt).lnghProcess, llngExitCode)

                        '@起動ﾌﾟﾛｾｽがｱｸﾃｨﾌﾞか
                        If llngExitCode = STILL_ACTIVE Then

                            '@WEB、EXE表示判定ﾌﾗｸﾞに"True：表示"をｾｯﾄ
                            lblnDispFlag = True
                        End If
                    Next llngCnt
                End If


                '@WEB、EXEが起動中以外か
                If lblnDispFlag = False Then

                    '@ﾒﾆｭｰが縮まっているか
                    If Me.Left >= CPlngAppliNarrowWidth Then
                        '@ﾒﾆｭｰが縮まっている場合

                        '@=======================
                        '@　ﾒﾆｭｰの伸縮処理
                        '@=======================
                        Call pubMenuExpand_Disp(False)
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
    '@↑2008/07/07 (Mon) 13:00:14 N.Kojima **************************************************

    '関数名：Form_Deactivate
    '機　能：ﾌｫｰﾑ　無効時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 17:01:47 H.Wajima
    '更新日：2008/06/23 (Mon) 16:17:12 N.Kojima
    '備　考：
    '　　　：2008/06/23 (Mon) 16:17:12 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub Form_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Deactivate

        'NSYS この関数は、Form_ActivateApp と連動して動作するので、メンテナンス時は合わせて修正すること

        Try
            
            If Form.ActiveForm Is Me Then
                '@ﾌｫｰﾑ無効処理実行ﾌﾗｸﾞを初期化する
                mblnDeActivateFlag = False
            
                '@ﾌﾟﾛｸﾞﾗﾑ(画面)が起動していない場合は抜ける
                If pstrExecuteMenuKey = vbNullString Then
                    Exit Sub
                End If
            
                '@ﾒﾆｭｰ画面の幅が広がっているか
                If Me.Left <= CPlngAppliNarrowWidth Then
                    '@ﾒﾆｭｰが広がっていない場合
                
                    '@=======================
                    '@　ﾒﾆｭｰｻｲｽﾞ変更処理
                    '@=======================
                    Call pubMenuExpand_Disp(False)
                
                    '@ﾌｫｰﾑ無効処理実行ﾌﾗｸﾞに"True：実行済"をｾｯﾄする
                    mblnDeActivateFlag = True
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Deactivate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：使用しない
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 15:09:21 H.Wajima
    '更新日：2005/04/07 (Thu) 11:12:15 N.Kasai
    '備　考：
    '　　　：2004/10/28 (Thu) 17:11:56 N.Kojima     ﾌｫｰﾑﾛｰﾄﾞ中に終了ｺﾏﾝﾄﾞを入力された場合の対応を追加
    '　　　：2005/04/07 (Thu) 11:12:15 N.Kasai      ﾏｳｽﾎﾟｲﾝﾀ条件追加
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Dim lintKeyCode         As Short        'ｷｰｺｰﾄﾞ

        Try
            
            '@DoEventsﾌﾗｸﾞが"True：DoEvent実行中"か
            If mblnDoEventsFlag = True Then
            
                '@"Alt+F4"ｷｰ押下を無効にする
                If e.KeyData = (Keys.F4 Or Keys.Alt) Then
                    e.Handled = True
                    Exit Sub
                End If
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If
            
            '@KeyCodeを退避する
            lintKeyCode = e.KeyCode
            
            '@★ 選択ﾀﾌﾞ(TabIndex)により処理分岐 ★
            Select Case tabMenu.SelectedIndex
            
                '@〓 0：流動系ﾀﾌﾞ 〓
                Case CPlngMenuTabFlow
                    
                    If ActiveControl IsNot vsfFlow.Editor Then
                        '@=======================
                        '@　ｸﾞﾘｯﾄﾞｷｰﾀﾞｳﾝ処理(共通関数)
                        '@=======================
                        Call pubVsf_KeyDown(e, ActiveControl.Name, vsfFlow, cmdFlowUp, cmdFlowDown, False)
                    
                        '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                        Select Case ActiveControl.Name
                    
                            '@〓〓 流動系ﾀﾌﾞのｸﾞﾘｯﾄﾞ 〓〓
                            Case vsfFlow.Name

                                '@★★★ 押されたｷｰにより処理分岐 ★★★
                                '@　(PageUp、PageDownのｷｰｺｰﾄﾞは、ｸﾞﾘｯﾄﾞ共通関数で初期化されるので、退避したｷｰｺｰﾄﾞを使用)
                                Select Case lintKeyCode
                            
                                    '@〓〓〓 Enter or Space 〓〓〓
                                    Case Keys.Return, Keys.Space
                                    
                                        '@=======================
                                        '@　ｺﾏﾝﾄﾞﾎﾞﾀﾝ押下処理
                                        '@=======================
                                        Call prvGridMenuButtonPush_Proc()
                                    
                                        '@=======================
                                        '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
                                        '@=======================
                                        Call pubGridMenuButton_Set()
                                 
                                    '@〓〓〓 ↑(上ｶｰｿﾙｷｰ) 〓〓〓
                                    Case Keys.Up

                                        '@流動系ｸﾞﾘｯﾄﾞの選択行が先頭行か
                                        If vsfFlow.Row = vsfFlow.Rows.Fixed Then
                                            '@ｸﾞﾘｯﾄﾞの先頭行が選択されている場合
                                        
                                            '@ﾀﾌﾞにﾌｫｰｶｽを移動する
                                            Call pubSetFocus(tabMenu)
                                        Else
                                            '@ｸﾞﾘｯﾄﾞの先頭行以外が選択されている場合
                                        
                                            '@=======================
                                            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
                                            '@=======================
                                            Call pubGridMenuButton_Set()
                                        End If
                                  
                                    '@〓〓〓 ↓(下ｶｰｿﾙｷｰ) or PageUp or PageDown 〓〓〓
                                    Case Keys.Down, Keys.PageUp, Keys.PageDown
                                    
                                        '@=======================
                                        '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
                                        '@=======================
                                        Call pubGridMenuButton_Set()
                                    
                                End Select
                        End Select
                    End If
                
                
                '@〓 1：ﾂｰﾙ系ﾀﾌﾞ 〓
                Case CPlngMenuTabTool

                    If ActiveControl IsNot vsfTool.Editor Then
                        '@=======================
                        '@　ｸﾞﾘｯﾄﾞｷｰﾀﾞｳﾝ処理(共通関数)
                        '@=======================
                        Call pubVsf_KeyDown(e, ActiveControl.Name, vsfTool, cmdToolUp, cmdToolDown, False)
                    
                        '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                        Select Case ActiveControl.Name
                    
                            '@〓〓 ﾂｰﾙ系ﾀﾌﾞのｸﾞﾘｯﾄﾞ 〓〓
                            Case vsfTool.Name

                                '@★★★ 押されたｷｰにより処理分岐 ★★★
                                '@　(PageUp、PageDownのｷｰｺｰﾄﾞは、ｸﾞﾘｯﾄﾞ共通関数で初期化されるので、退避したｷｰｺｰﾄﾞを使用)
                                Select Case lintKeyCode
                            
                                    '@〓〓〓 Enter or Space 〓〓〓
                                    Case Keys.Return, Keys.Space
                                    
                                        '@=======================
                                        '@　ｺﾏﾝﾄﾞﾎﾞﾀﾝ押下処理
                                        '@=======================
                                        Call prvGridMenuButtonPush_Proc()
                                    
                                        '@=======================
                                        '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
                                        '@=======================
                                        Call pubGridMenuButton_Set()
                                
                                    '@〓〓〓 ↑(上ｶｰｿﾙｷｰ) 〓〓〓
                                    Case Keys.Up

                                        '@ﾂｰﾙ系ｸﾞﾘｯﾄﾞの選択行が先頭行か
                                        If vsfTool.Row = vsfTool.Rows.Fixed Then
                                            '@ｸﾞﾘｯﾄﾞの先頭行が選択されている場合
                                        
                                            '@ﾀﾌﾞにﾌｫｰｶｽを移動する
                                            Call pubSetFocus(tabMenu)
                                        Else
                                            '@ｸﾞﾘｯﾄﾞの先頭行以外が選択されている場合
                                        
                                            '@=======================
                                            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
                                            '@=======================
                                            Call pubGridMenuButton_Set()
                                        End If
                                
                                    '@〓〓〓 ↓(下ｶｰｿﾙｷｰ) or PageUp or PageDown 〓〓〓
                                    Case Keys.Down, Keys.PageUp, Keys.PageDown

                                        '@=======================
                                        '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
                                        '@=======================
                                        Call pubGridMenuButton_Set()
                                    
                                End Select
                        End Select
                    End If


                '@〓 2：お気に入りﾀﾌﾞ 〓
                Case CPlngMenuTabFavorites

                    If ActiveControl IsNot vsfFavorites.Editor Then
                        '@=======================
                        '@　ｸﾞﾘｯﾄﾞｷｰﾀﾞｳﾝ処理(共通関数)
                        '@=======================
                        Call pubVsf_KeyDown(e, ActiveControl.Name, vsfFavorites, cmdFavoritesUp, cmdFavoritesDown, False)
                    
                        '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                        Select Case ActiveControl.Name
                        
                            '@〓〓 お気に入りﾀﾌﾞのｸﾞﾘｯﾄﾞ 〓〓
                            Case vsfFavorites.Name

                                '@★★★ 押されたｷｰにより処理分岐 ★★★
                                '@　(PageUp、PageDownのｷｰｺｰﾄﾞは、ｸﾞﾘｯﾄﾞ共通関数で初期化されるので、退避したｷｰｺｰﾄﾞを使用)
                                Select Case lintKeyCode
                            
                                    '@〓〓〓 Enter or Space 〓〓〓
                                    Case Keys.Return, Keys.Space
                                    
                                        '@=======================
                                        '@　ｺﾏﾝﾄﾞﾎﾞﾀﾝ押下処理
                                        '@=======================
                                        Call prvGridMenuButtonPush_Proc()
                                    
                                        '@=======================
                                        '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
                                        '@=======================
                                        Call pubGridMenuButton_Set()
                                
                                    '@〓〓〓 ↑(上ｶｰｿﾙｷｰ) 〓〓〓
                                    Case Keys.Up

                                        '@お気に入りｸﾞﾘｯﾄﾞの選択行が先頭行か
                                        If vsfFavorites.Row = vsfFavorites.Rows.Fixed Then
                                            '@ｸﾞﾘｯﾄﾞの先頭行が選択されている場合
                                        
                                            '@ﾀﾌﾞにﾌｫｰｶｽを移動する
                                            Call pubSetFocus(tabMenu)
                                        Else
                                            '@ｸﾞﾘｯﾄﾞの先頭行以外が選択されている場合
                                        
                                            '@=======================
                                            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
                                            '@=======================
                                            Call pubGridMenuButton_Set()
                                        End If
                                
                                    '@〓〓〓 ↓(下ｶｰｿﾙｷｰ) or PageUp or PageDown 〓〓〓
                                    Case Keys.Down, Keys.PageUp, Keys.PageDown
                                    
                                        '@=======================
                                        '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
                                        '@=======================
                                        Call pubGridMenuButton_Set()
                                    
                                End Select
                        End Select
                    End If
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
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 17:11:43 T.Oide
    '更新日：2008/06/23 (Mon) 16:37:34 N.Kojima
    '備　考：
    '　　　：2005/02/07 (Mon) 16:37:49 S.Deguchi    ﾛｸﾞｲﾝ情報登録処理追加
    '　　　：2005/03/29 (Tue) 14:06:47 N.Kasai      ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合は終了を受け付けない
    '　　　：2008/06/23 (Mon) 16:37:34 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim ltypCommonInfo          As CommonInfo   '引継ぎ構造体
        Dim lblnAnsTerm             As Boolean      '開放結果格納
        Dim lblnDispFlag            As Boolean      'WEB、EXE表示判定ﾌﾗｸﾞ(True：表示、False：非表示)
        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim llngRet                 As Integer      '汎用戻り値格納用
        Dim llngExitCode            As Integer      '終了ｺｰﾄﾞ

        Try
            
            '@子ﾌｫｰﾑが起動中に終了ﾎﾞﾀﾝを押下された場合の対応(DoEvents使用の画面の場合この条件がないとｲﾝﾃﾞｯｸｽｴﾗｰ)
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                '@処理終了
                e.Cancel = True
                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞ済みﾌﾗｸﾞが"True：表示済"か
            If mblnFormLoadedFlag = True Then
                '@ﾌｫｰﾑがﾛｰﾄﾞ済みの場合
            
                '@WEBが表示されているか
                If IsWindow(plngInetExphWnd) <> 0 Then
                
                    '@WEB、EXE表示判定ﾌﾗｸﾞに"True：表示"をｾｯﾄ
                    lblnDispFlag = True
                End If
                
                If ptypExeInfoCnt > 0 Then
                
                    For llngCnt = 0 To ptypExeInfo.Count - 1
                        
                        '@=======================
                        '@　起動ﾌﾟﾛｾｽの存在判定処理
                        '@=======================
                        llngRet = GetExitCodeProcess(ptypExeInfo(llngCnt).lnghProcess, llngExitCode)
                        
                        '@起動ﾌﾟﾛｾｽがｱｸﾃｨﾌﾞか
                        If llngExitCode = STILL_ACTIVE Then
                        
                            '@WEB、EXE表示判定ﾌﾗｸﾞに"True：表示"をｾｯﾄ
                            lblnDispFlag = True
                        End If
                    Next llngCnt
                End If
            
                '@WEB、EXEが起動中か
                If lblnDispFlag = True Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf00ZZ, CMstrSpcWeb)
                    '@ﾒｯｾｰｼﾞ："<TRMZZI>$$[%1]を起動しているか確認し、起動している場合は$[%1]を終了してからメニューを終了してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, CPstrMenuFormCaption, True, 16)
                    
                    '@処理終了
                    e.Cancel = True
                    Exit Sub
                End If
            
            
                '@お気に入り編集ﾌﾗｸﾞが"True：編集あり"か
                If pblnFavoritesEdit = True Then
                    '@お気に入り情報が変更されている場合
                    
                    '@=======================
                    '@　お気に入り登録処理
                    '@=======================
                    Call prvRegMenu_Set()
                End If
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰとお知らせ画面のｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0100.Instance = Nothing
                frmxxMN0002.Instance = Nothing
                
                '@=======================
                '@　起動中のﾌﾟﾛｸﾞﾗﾑを終了(無条件終了を指定)
                '@=======================
                llngRet = prvlngPrgAllEnd_Proc(ltypCommonInfo, True)
            
            End If
            
            
            '@各種構造体or配列を初期化する
            If Not ptypFuncInfo.typFunctionList Is Nothing Then
                ptypFuncInfo.typFunctionList.Clear()      '機能情報格納配列
            End If

            If Not ptypExeInfo Is Nothing Then
                ptypExeInfo.Clear()                       'EXE起動用配列
            End If

            If Not mtypMenuItem Is Nothing Then
                mtypMenuItem.Clear()                      'ﾒﾆｭｰ項目格納用配列
            End If

            If Not mtypExeWebDispItem Is Nothing Then
                mtypExeWebDispItem.Clear()                'EXE、WEB起動ﾒﾆｭｰ項目
            End If

            ptypExeInfoCnt = 0
            
            '@各種ﾓｼﾞｭｰﾙ変数を初期化する
            mlngExeWebDispFlag = 0
            mlngExeWebDispItemCnt = 0

        '    '@IE用のｵﾌﾞｼﾞｪｸﾄを解放する
        '    Set pobjInetExp = Nothing
            
            '@=======================
            '@　ACTｵﾌﾞｼﾞｪｸﾄの開放処理
            '@=======================
            lblnAnsTerm = pubblnAct_Term

        '    '@ﾒﾆｭｰ項目配列を解放する
        '    Erase mtypMenuItem
            
            '@各種ｵﾌﾞｼﾞｪｸﾄとの関連付けを解除
        '    pobjInetExp = Nothing               'IE用のｵﾌﾞｼﾞｪｸﾄ
            
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

    '関数名：tabMenu_Click
    '機　能：ﾒﾆｭｰﾀﾌﾞ　Click時処理
    '引　数：PreviousTab：使用しない
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 15:19:30 H.Wajima
    '更新日：2008/06/23 (Mon) 16:47:14 N.Kojima
    '備　考：
    '　　　：2008/06/23 (Mon) 16:47:14 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub tabMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tabMenu.SelectedIndexChanged

        Try

            '@★ 選択されたﾀﾌﾞ(TabIndex)により処理分岐 ★
            Select Case tabMenu.SelectedIndex
                
                '@〓 0：流動系ﾀﾌﾞ 〓
                Case CPlngMenuTabFlow

                    '@各種ｸﾞﾘｯﾄﾞの有効/無効制御
                    vsfFlow.Enabled = True          '流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ：有効
                    vsfTool.Enabled = False         'ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ：無効
                    vsfFavorites.Enabled = False    'お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ：無効
                    
                    '@流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞを未選択状態にする
                    If vsfFlow.Row = CPlngMenuVSFlexGridUnChoosing Then
                        vsfFlow.Row = 0
                    Else
                        vsfFlow.Row = vsfFlow.TopRow
                    End If
                
                
                '@〓 1：ﾂｰﾙ系ﾀﾌﾞ 〓
                Case CPlngMenuTabTool

                    '@各種ｸﾞﾘｯﾄﾞの有効/無効制御
                    vsfTool.Enabled = True          'ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ：有効
                    vsfFlow.Enabled = False         '流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ：無効
                    vsfFavorites.Enabled = False    'お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ：無効
                    
                    '@ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞを未選択状態にする
                    If vsfTool.Row = CPlngMenuVSFlexGridUnChoosing Then
                        vsfTool.Row = 0
                    Else
                        vsfTool.Row = vsfTool.TopRow
                    End If
                
                
                '@〓 2：お気に入りﾀﾌﾞ 〓
                Case CPlngMenuTabFavorites

                    '@各種ｸﾞﾘｯﾄﾞの有効/無効制御
                    vsfFavorites.Enabled = True     'お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ：有効
                    vsfFlow.Enabled = False         '流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ：無効
                    vsfTool.Enabled = False         'ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ：無効
                    
                    '@お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞを未選択状態にする
                    If vsfFavorites.Row = CPlngMenuVSFlexGridUnChoosing Then
                        vsfFavorites.Row = 0
                    Else
                        vsfFavorites.Row = vsfFavorites.TopRow
                    End If

            End Select
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "tabMenu_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：tabMenu_KeyDown
    '機　能：ﾒﾆｭｰﾀﾌﾞ　ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：Shiftｷｰの状態
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 15:20:03 H.Wajima
    '更新日：2008/06/23 (Mon) 16:53:21 N.Kojima
    '備　考：
    '　　　：2008/06/23 (Mon) 16:53:21 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub tabMenu_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles tabMenu.KeyDown

        Dim llngTopRow          As Integer  '先頭行

        Try
            
            '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
            Select Case e.KeyCode
            
                '@〓 ↓(下ｶｰｿﾙｷｰ) 〓
                Case Keys.Down
                    
                    '@★★ 選択ﾀﾌﾞ(TabIndex)により処理分岐 ★★
                    Select Case tabMenu.SelectedIndex
                    
                        '@〓 0：流動系ﾀﾌﾞ 〓
                        Case CPlngMenuTabFlow
                            
                            If vsfFlow.Row < 0 OrElse ActiveControl Is tabMenu Then
                                '@=======================
                                '@　ｸﾞﾘｯﾄﾞ共通関数がRowHiddenを使用しているため、共通関数で先頭行を取得。
                                '@=======================
                                llngTopRow = pubstrVsfTag_Get(vsfFlow, 1)
                            
                                '@流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞの先頭行を設定し、ﾌｫｰｶｽをｾｯﾄ
                                vsfFlow.Row = llngTopRow
                                Call pubSetFocus(vsfFlow)

                                'NSYS グリッドが ActiveControl の場合、グリッドでもキー処理が行われるのを防ぐため
                                If Me.ActiveControl Is vsfFlow Then
                                    e.Handled = True
                                End If
                            End If
                        
                        
                        '@〓 1：ﾂｰﾙ系ﾀﾌﾞ 〓
                        Case CPlngMenuTabTool

                            If vsfTool.Row < 0 OrElse ActiveControl Is tabMenu Then
                                '@=======================
                                '@　ｸﾞﾘｯﾄﾞ共通関数がRowHiddenを使用しているため、共通関数で先頭行を取得。
                                '@=======================
                                llngTopRow = pubstrVsfTag_Get(vsfTool, 1)
                            
                                '@ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞの先頭行を設定し、ﾌｫｰｶｽをｾｯﾄ
                                vsfTool.Row = llngTopRow
                                Call pubSetFocus(vsfTool)

                                'NSYS グリッドが ActiveControl の場合、グリッドでもキー処理が行われるのを防ぐため
                                If Me.ActiveControl Is vsfTool Then
                                    e.Handled = True
                                End If
                            End If
                        
                        
                        '@〓 2：お気に入りﾀﾌﾞ 〓
                        Case CPlngMenuTabFavorites

                            If vsfFavorites.Row < 0 OrElse ActiveControl Is tabMenu Then
                                '@=======================
                                '@　ｸﾞﾘｯﾄﾞ共通関数がRowHiddenを使用しているため、共通関数で先頭行を取得。
                                '@=======================
                                llngTopRow = pubstrVsfTag_Get(vsfFavorites, 1)
                            
                                '@お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞの先頭行を設定し、ﾌｫｰｶｽをｾｯﾄ
                                vsfFavorites.Row = llngTopRow
                                Call pubSetFocus(vsfFavorites)

                                'NSYS グリッドが ActiveControl の場合、グリッドでもキー処理が行われるのを防ぐため
                                If Me.ActiveControl Is vsfFavorites Then
                                    e.Handled = True
                                End If
                            End If

                    End Select

            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "tabMenu_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdExpand_Click
    '機　能：ﾒﾆｭｰ伸縮ﾎﾞﾀﾝ　Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 18:21:14 T.Oide
    '更新日：2008/06/23 (Mon) 17:01:33 N.Kojima
    '備　考：
    '　　　：2005/04/07 (Thu) 11:15:01 N.Kasai      ﾏｳｽﾎﾟｲﾝﾀｰ制御追加
    '　　　：2008/06/23 (Mon) 17:01:33 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub cmdExpand_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdExpand.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@=======================
            '@　ﾒﾆｭｰの伸縮処理
            '@=======================
            Call pubMenuExpand_Disp(False)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdExpand_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdExpand_GotFocus
    '機　能：ﾒﾆｭｰ伸縮ﾎﾞﾀﾝ　ﾌｫｰｶｽ取得時処理
    '引　数：なし
    '戻り値：
    '作成日：2008/06/23 (Mon) 17:00:37 N.Kojima
    '更新日：2008/07/14 (Mon) 13:21:21 N.Kojima
    '備　考：
    Private Sub cmdExpand_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cmdExpand.Enter
        
        Dim llngCnt             As Integer  '汎用ｶｳﾝﾀ
        Dim llngMatchFlag       As Integer  '適合ﾌﾗｸﾞ(1：1ﾌｫｰﾑのみ適合、2：2ﾌｫｰﾑとも適合)
        
        Try
            
            '@適合ﾌﾗｸﾞを初期化
            llngMatchFlag = 0
            
            '@ﾛｰﾄﾞ中のﾌｫｰﾑ分(Forms.Count)、"お知らせ"ﾌｫｰﾑがあるか検索
            For llngCnt = 0 To Application.OpenForms.Count - 1
            
                '@ﾛｰﾄﾞ中のﾌｫｰﾑ名に"お知らせ"が存在し、かつﾒﾆｭｰが縮まっているか
                If Application.OpenForms(llngCnt).Name = CPstrKeyMN0002 And _
                    Me.Left >= CPlngAppliNarrowWidth Then
                
                    '@=======================
                    '@　ﾒﾆｭｰの伸縮処理
                    '@=======================
                    Call pubMenuExpand_Disp(False)
                    
                    '@"お知らせ"がある場合は、処理終了
                    Exit Sub
                Else
                    
                    '@起動中ﾌｫｰﾑ名が"frmxxMN0000(ﾒﾆｭｰ)"、または"frmxxCM0100(ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰ)"か
                    If Application.OpenForms(llngCnt).Name = CMstrFormName Or _
                        Application.OpenForms(llngCnt).Name = CMstrfrmxxCM0100 Then
                            
                        '@適合ﾌﾗｸﾞが"1：1ﾌｫｰﾑのみ適合"状態か
                        If llngMatchFlag = 1 Then
                        
                            '@適合ﾌﾗｸﾞが"2：2ﾌｫｰﾑとも適合"をｾｯﾄ
                            llngMatchFlag = 2
                        Else
                            '@適合ﾌﾗｸﾞに"1：1ﾌｫｰﾑのみ適合"をｾｯﾄ
                            llngMatchFlag = 1
                        End If
                    End If
                End If
            Next llngCnt
            
            '@ﾌｫｰﾑ無効処理実行ﾌﾗｸﾞが"True：実行済"か
            If mblnDeActivateFlag = True Then
                
                '@上記ﾌﾗｸﾞがTrueの場合はForm_Deactivateでﾒﾆｭｰ伸縮処理を完了しているので、処理抜け
                Exit Sub
            End If
            
            '@起動中ﾌｫｰﾑが2ﾌｫｰﾑで、かつ適合ﾌﾗｸﾞが"2：2ﾌｫｰﾑとも適合"、かつﾒﾆｭｰが縮まっているか
            If Application.OpenForms.Count = 2 And _
                llngMatchFlag = 2 And _
                Me.Left >= CPlngAppliNarrowWidth Then
            
                '@=======================
                '@　ﾒﾆｭｰの伸縮処理
                '@=======================
                Call pubMenuExpand_Disp(False)
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdExpand_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFlow_Click
    '機　能：流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 09:01:13 H.Wajima
    '更新日：2008/06/23 (Mon) 17:06:59 N.Kojima
    '備　考：
    '　　　：2008/06/23 (Mon) 17:06:59 N.Kojima     ｿｰｽ整備。(案件№03004)
    Public Sub vsfFlow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFlow.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            'NSYS データ行がない場合は処理を抜ける
            If vsfFlow.Rows.Count <= vsfFlow.Rows.Fixed Then
                Return
            End If
            
            '@ｸﾞﾘｯﾄﾞ上で右Clickされたか
            If mintButton = MouseButtons.Right Then
                '@右ｸﾘｯｸされた場合
                
                '@ﾏｳｽﾎﾞﾀﾝ判定用変数の初期化
                mintButton = 0
                Exit Sub
            End If
            
            '@ｸﾘｯｸされた行を選択する
            vsfFlow.Row = vsfFlow.MouseRow
            
            '@=======================
            '@　ｺﾏﾝﾄﾞﾎﾞﾀﾝ押下処理
            '@=======================
            Call prvGridMenuButtonPush_Proc()
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set(vsfFlow.MouseRow)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFlow_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFlow_GotFocus
    '機　能：流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ　ﾌｫｰｶｽ取得時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 18:02:45 H.Wajima
    '更新日：2008/06/23 (Mon) 17:11:15 N.Kojima
    '備　考：
    '　　　：2008/06/23 (Mon) 17:11:15 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub vsfFlow_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFlow.Enter

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFlow.Rows.Count <= vsfFlow.Rows.Fixed Then
                Return
            End If
            
            '@流動系ｸﾞﾘｯﾄﾞが未選択状態か
            If vsfFlow.Row = CPlngMenuVSFlexGridUnChoosing Then

                '@ﾃﾞﾌｫﾙﾄとして先頭行を選択状態にする
                vsfFlow.Row = 0
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFlow_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFlow_MouseDown
    '機　能：流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ　ﾏｳｽﾎﾞﾀﾝ押下時処理
    '引　数：Button ：ﾎﾞﾀﾝ値
    '　　　：Shift  ：未使用
    '　　　：X      ：未使用
    '　　　：Y      ：未使用
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 12:41:33 H.Wajima
    '更新日：2008/06/23 (Mon) 17:13:53 N.Kojima
    '備　考：
    '　　　：2008/06/23 (Mon) 17:13:53 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub vsfFlow_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfFlow.MouseDown
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFlow.Rows.Count <= vsfFlow.Rows.Fixed Then
                Return
            End If
            
            '@Button値(左ﾎﾞﾀﾝ(1)or右ﾎﾞﾀﾝ(2)orﾎｲｰﾙ(4))を格納する
            mintButton = e.Button
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFlow_MouseDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFlow_MouseMove
    '機　能：流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ　ﾏｳｽ移動時処理
    '引　数：Button ：未使用
    '　　　：Shift  ：未使用
    '　　　：x      ：未使用
    '　　　：y      ：未使用
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 15:36:02 H.Wajima
    '更新日：2008/06/23 (Mon) 17:18:16 N.Kojima
    '備　考：
    '　　　：2008/06/23 (Mon) 17:18:16 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub vsfFlow_MouseMove(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFlow.MouseMove

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFlow.Rows.Count <= vsfFlow.Rows.Fixed Then
                Return
            End If
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞのﾏｳｽ移動時処理(3ｸﾞﾘｯﾄﾞ共通処理)
            '@=======================
            Call pubMenuGridMouseMove_Proc(vsfFlow, ToolTip)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFlow_MouseMove"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdVsfFlow_Click
    '機　能：流動系ﾒﾆｭｰﾎﾞﾀﾝ　Click時処理
    '引　数：Index：ﾎﾞﾀﾝのIndex
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 09:00:14 H.Wajima
    '更新日：2008/06/23 (Mon) 17:23:48 N.Kojima
    '備　考：
    '　　　：2008/06/23 (Mon) 17:23:48 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub cmdVsfFlow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfFlow.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@FormLoad済ﾌﾗｸﾞが"False：未完"か
            If mblnFormLoadedFlag = False Then

                '@処理終了
                Exit Sub
            End If
            
            '@=======================
            '@　ﾌﾟﾛｸﾞﾗﾑ切り替え処理
            '@=======================
            Call prvPrgSwitch_Proc(vsfFlow, Short.Parse(CType(sender, Button).Tag))
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set(vsfFlow.Row)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdVsfFlow_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdFlowUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ)　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 15:05:05 H.Wajima
    '更新日：2008/06/23 (Mon) 17:20:15 N.Kojima
    '備　考：
    '　　　：2008/06/23 (Mon) 17:20:15 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub cmdFlowUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFlowUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通関数)
            '@=======================
            Call pubVsfCmdUp(vsfFlow, cmdFlowUp, cmdFlowDown)
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdFlowUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdFlowDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ)　Click時処理
    '引　数：なし
    '戻り値：
    '作成日：2004/04/30 (Fri) 15:04:30 H.Wajima
    '更新日：2008/06/23 (Mon) 17:21:58 N.Kojima
    '備　考：
    '　　　：2008/06/23 (Mon) 17:21:58 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub cmdFlowDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFlowDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通関数)
            '@=======================
            Call pubVsfCmdDown(vsfFlow, cmdFlowUp, cmdFlowDown, False)
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdFlowDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfTool_Click
    '機　能：ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 15:37:01 H.Wajima
    '更新日：2008/06/23 (Mon) 17:28:37 N.Kojima
    '備　考：
    '　　　：2008/06/23 (Mon) 17:28:37 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub vsfTool_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfTool.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            'NSYS データ行がない場合は処理を抜ける
            If vsfTool.Rows.Count <= vsfTool.Rows.Fixed Then
                Return
            End If
            
            '@ｸﾞﾘｯﾄﾞ上で右Clickされたか
            If mintButton = MouseButtons.Right Then

                '@ﾏｳｽﾎﾞﾀﾝ判定用変数の初期化
                mintButton = 0
                Exit Sub
            End If
                
            '@ｸﾘｯｸされた行を選択する
            vsfFavorites.Row = vsfFavorites.MouseRow
            
            '@=======================
            '@　ｺﾏﾝﾄﾞﾎﾞﾀﾝ押下処理
            '@=======================
            Call prvGridMenuButtonPush_Proc()
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set(vsfTool.MouseRow)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTool_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfTool_GotFocus
    '機　能：ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ　ﾌｫｰｶｽ取得時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 18:03:20 H.Wajima
    '更新日：2008/06/24 (Tue) 11:33:52 N.Kojima
    '備　考：
    '　　　：2008/06/24 (Tue) 11:33:52 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub vsfTool_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfTool.Enter

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfTool.Rows.Count <= vsfTool.Rows.Fixed Then
                Return
            End If
            
            '@ｸﾞﾘｯﾄﾞの行が未選択状態か
            If vsfTool.Row = CPlngMenuVSFlexGridUnChoosing Then

                '@ﾃﾞﾌｫﾙﾄとして先頭行を選択する
                vsfTool.Row = 0
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTool_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfTool_MouseDown
    '機　能：ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ　ﾏｳｽﾎﾞﾀﾝ押下時処理
    '引　数：Button ：ﾎﾞﾀﾝ値
    '　　　：Shift  ：未使用
    '　　　：X      ：未使用
    '　　　：Y      ：未使用
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 12:40:19 H.Wajima
    '更新日：2008/06/24 (Tue) 11:37:02 N.Kojima
    '備　考：
    '　　　：2008/06/24 (Tue) 11:37:02 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub vsfTool_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfTool.MouseDown

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfTool.Rows.Count <= vsfTool.Rows.Fixed Then
                Return
            End If
            
            '@Button値(左ﾎﾞﾀﾝ(1)or右ﾎﾞﾀﾝ(2)orﾎｲｰﾙ(4))を格納する
            mintButton = e.Button
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTool_MouseDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfTool_MouseMove
    '機　能：ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ　ﾏｳｽ操作時処理
    '引　数：Button ：未使用
    '　　　：Shift  ：未使用
    '　　　：x      ：未使用
    '　　　：y      ：未使用
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 15:37:57 H.Wajima
    '更新日：2008/06/24 (Tue) 11:38:03 N.Kojima
    '備　考：
    '　　　：2008/06/24 (Tue) 11:38:03 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub vsfTool_MouseMove(ByVal sender As Object, ByVal e As EventArgs) Handles vsfTool.MouseMove

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfTool.Rows.Count <= vsfTool.Rows.Fixed Then
                Return
            End If
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞのﾏｳｽ移動時処理(3ｸﾞﾘｯﾄﾞ共通処理)
            '@=======================
            Call pubMenuGridMouseMove_Proc(vsfTool, ToolTip)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTool_MouseMove"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdVsfTool_Click
    '機　能：ﾂｰﾙ系ﾒﾆｭｰﾎﾞﾀﾝ　Click時処理
    '引　数：Index：ﾎﾞﾀﾝのInex
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 09:00:16 H.Wajima
    '更新日：2004/04/30 (Fri) 09:00:16
    '備　考：
    Private Sub cmdVsfTool_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfTool.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@FormLoad済ﾌﾗｸﾞが"False：未完"か
            If mblnFormLoadedFlag = False Then

                '@処理終了
                Exit Sub
            End If
            
            '@=======================
            '@　ﾌﾟﾛｸﾞﾗﾑ切り替え処理
            '@=======================
            Call prvPrgSwitch_Proc(vsfTool, CShort(CType(sender, Button).Tag))
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set(vsfTool.Row)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdVsfTool_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdToolUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ)　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 15:07:41 H.Wajima
    '更新日：2008/06/24 (Tue) 11:43:44 N.Kojima
    '備　考：
    '　　　：2008/06/24 (Tue) 11:43:44 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub cmdToolUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdToolUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通関数)
            '@=======================
            Call pubVsfCmdUp(vsfTool, cmdToolUp, cmdToolDown)
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdToolUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdToolDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ)　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 15:07:25 H.Wajima
    '更新日：2008/06/24 (Tue) 11:45:07 N.Kojima
    '備　考：
    '　　　：2008/06/24 (Tue) 11:45:07 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub cmdToolDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdToolDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通関数)
            '@=======================
            Call pubVsfCmdDown(vsfTool, cmdToolUp, cmdToolDown, False)
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdToolDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFavorites_Click
    '機　能：お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 09:01:18 H.Wajima
    '更新日：2008/06/24 (Tue) 12:31:46 N.Kojima
    '備　考：
    '　　　：2008/06/24 (Tue) 12:31:46 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub vsfFavorites_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFavorites.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            'NSYS データ行がない場合は処理を抜ける
            If vsfFavorites.Rows.Count <= vsfFavorites.Rows.Fixed Then
                Return
            End If
            
            '@ｸﾞﾘｯﾄﾞ上で右Clickされたか
            If mintButton = MouseButtons.Right Then

                '@ﾏｳｽﾎﾞﾀﾝ判定用変数の初期化
                mintButton = 0
                Exit Sub
            End If
                
            '@ｸﾘｯｸされた行を選択する
            vsfFavorites.Row = vsfFavorites.MouseRow
            
            '@=======================
            '@　ｺﾏﾝﾄﾞﾎﾞﾀﾝ押下処理
            '@=======================
            Call prvGridMenuButtonPush_Proc()
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set(vsfFavorites.MouseRow)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFavorites_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFavorites_GotFocus
    '機　能：お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ　ﾌｫｰｶｽ取得時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 18:01:48 H.Wajima
    '更新日：2008/06/24 (Tue) 13:24:31 N.Kojima
    '備　考：
    '　　　：2008/06/24 (Tue) 13:24:31 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub vsfFavorites_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFavorites.Enter

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFavorites.Rows.Count <= vsfFavorites.Rows.Fixed Then
                Return
            End If

            '@ｸﾞﾘｯﾄﾞの行が未選択状態か
            If vsfFavorites.Row = CPlngMenuVSFlexGridUnChoosing Then

                '@ﾃﾞﾌｫﾙﾄとして先頭行を選択する
                vsfFavorites.Row = 0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFavorites_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFavorites_MouseDown
    '機　能：お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ　ﾏｳｽﾎﾞﾀﾝ押下時処理
    '引　数：Button ：ﾎﾞﾀﾝ値
    '　　　：Shift  ：未使用
    '　　　：X      ：未使用
    '　　　：Y      ：未使用
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 12:38:26 H.Wajima
    '更新日：2008/06/24 (Tue) 13:32:07 N.Kojima
    '備　考：
    '　　　：2008/06/24 (Tue) 13:32:07 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub vsfFavorites_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfFavorites.MouseDown

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFavorites.Rows.Count <= vsfFavorites.Rows.Fixed Then
                Return
            End If
            
            '@Button値(左ﾎﾞﾀﾝ(1)or右ﾎﾞﾀﾝ(2)orﾎｲｰﾙ(4))を格納する
            mintButton = e.Button
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFavorites_MouseDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFavorites_MouseMove
    '機　能：お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ　ﾏｳｽ操作時処理
    '引　数：Button ：使用しない
    '　　　：Shift  ：使用しない
    '　　　：x      ：使用しない
    '　　　：y      ：使用しない
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 09:01:16 H.Wajima
    '更新日：2008/06/24 (Tue) 13:33:03 N.Kojima
    '備　考：
    '　　　：2008/06/24 (Tue) 13:33:03 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub vsfFavorites_MouseMove(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFavorites.MouseMove

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFavorites.Rows.Count <= vsfFavorites.Rows.Fixed Then
                Return
            End If
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞのﾏｳｽ移動時処理(3ｸﾞﾘｯﾄﾞ共通処理)
            '@=======================
            Call pubMenuGridMouseMove_Proc(vsfFavorites, ToolTip)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFavorites_MouseMove"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdVsfFavorites_Click
    '機　能：お気に入りﾒﾆｭｰﾎﾞﾀﾝ　Click時処理
    '引　数：Index：ﾎﾞﾀﾝのIndex
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 09:00:19 H.Wajima
    '更新日：2008/06/24 (Tue) 13:35:07 N.Kojima
    '備　考：
    '　　　：2008/06/24 (Tue) 13:35:07 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub cmdVsfFavorites_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfFavorites.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@FormLoad済ﾌﾗｸﾞが"False：未完"か
            If mblnFormLoadedFlag = False Then

                '@処理終了
                Exit Sub
            End If
            
            '@=======================
            '@　ﾌﾟﾛｸﾞﾗﾑ切り替え処理
            '@=======================
            Call prvPrgSwitch_Proc(vsfFavorites, CShort(CType(sender, Button).Tag))
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set(vsfFavorites.Row)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdVsfFavorites_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdFavoritesUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ)　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 15:03:54 H.Wajima
    '更新日：2008/06/24 (Tue) 13:37:00 N.Kojima
    '備　考：
    '　　　：2008/06/24 (Tue) 13:37:00 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub cmdFavoritesUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFavoritesUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@　ｸﾞﾘｯﾄﾞ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通関数)
            '@=======================
            Call pubVsfCmdUp(vsfFavorites, cmdFavoritesUp, cmdFavoritesDown)
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdFavoritesUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdFavoritesDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ)　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 15:03:26 H.Wajima
    '更新日：2008/06/24 (Tue) 13:38:12 N.Kojima
    '備　考：
    '　　　：2008/06/24 (Tue) 13:38:12 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub cmdFavoritesDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFavoritesDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通関数)
            '@=======================
            Call pubVsfCmdDown(vsfFavorites, cmdFavoritesUp, cmdFavoritesDown, False)
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdFavoritesDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdFavorites_Click
    '機　能：お気に入りの整理ﾎﾞﾀﾝ　Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 11:18:40 H.Wajima
    '更新日：2008/06/24 (Tue) 13:39:48 N.Kojima
    '備　考：
    '　　　：2004/09/24 (Fri) 16:39:56 H.Wajima     お気に入りの整理から戻った時に、その前に起動していた機能の
    '　　　：                                       行が表示されて電球ｱｲｺﾝが表示されるように変更(№828の影響で修正)
    '　　　：2008/06/24 (Tue) 13:39:48 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub cmdFavorites_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFavorites.Click
        
        Dim lctlControl                 As Control      'ｺﾝﾄﾛｰﾙ
        Dim lblnAgreementFlg            As Boolean      '起動中画面判定ﾌﾗｸﾞ(True：あり、False：なし)
        Dim llngCnt                     As Integer      '汎用ｶｳﾝﾀ
        Dim llngRow                     As Integer      '行番号

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@お気に入り編集ﾌﾗｸﾞに"True：編集あり"をｾｯﾄ
            pblnFavoritesEdit = True
            
            '@***********************
            '@　お気に入りの項目から起動されたﾒﾆｭｰが起動中かどうかを判定する
            '@***********************
            With vsfFavorites
                
                '@起動中画面判定ﾌﾗｸﾞに"False：起動中画面なし"をｾｯﾄ
                lblnAgreementFlg = False
                
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                
                    '@お気に入りのﾒﾆｭｰｸﾞﾘｯﾄﾞに起動中ﾌﾗｸﾞが立っている行があるか
                    If .GetData(llngCnt, CPlngMenuExecuteCol) = CPlngMenuExecuteFlg Then

                        '@起動中画面判定ﾌﾗｸﾞに"True：起動中画面あり"をｾｯﾄ
                        lblnAgreementFlg = True
                        Exit For
                    End If
                Next llngCnt
            End With
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　お気に入り登録画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxMN0001.Instance = New frmxxMN0001()
            
            With frmxxMN0001.Instance
                '@ﾌｫｰﾑを最前面に表示する
                .BringToFront()
                '@ﾌｫｰﾑの位置とｻｲｽﾞを指定
                .SetBounds(0 - My.Settings.FormOffset, 0, CPlngAppliWideWidth, CPlngAppliHeight)
                '@流動系ﾀﾌﾞを初期表示する
                .tabMenu1.SelectedIndex = CPlngMenuTabFlow
            End With
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞの項目設定処理
            '@=======================
            Call prvMenuGrid_Edit(frmxxMN0001.Instance)
            
            
            '@お気に入りｸﾞﾘｯﾄﾞの中身を、お気に入りの整理画面のお気に入りｸﾞﾘｯﾄﾞにｺﾋﾟｰする
            With vsfFavorites
                frmxxMN0001.Instance.vsfFavorites.Redraw = False
            
                '@お気に入り登録の行数とお気に入りﾒﾆｭｰの行数を合わせる
                frmxxMN0001.Instance.vsfFavorites.Rows.Count = .Rows.Count
                
                '@お気に入り登録のｸﾞﾘｯﾄﾞをｸﾘｱする
                frmxxMN0001.Instance.vsfFavorites.Clear
                
                '@お気に入りﾒﾆｭｰの内容を、お気に入り登録ｸﾞﾘｯﾄﾞにｺﾋﾟｰする
                For rowCnt As Integer = 0 To .Rows.Count - 1
                    For colCnt As Integer = 0 To .Cols.Count - 1
                        frmxxMN0001.Instance.vsfFavorites.SetData(rowCnt, colCnt, .GetData(rowCnt, colCnt))
                    Next
                Next
                
                '@お気に入り登録
                For llngCnt = 0 To frmxxMN0001.Instance.vsfFavorites.Rows.Count - 1
                
                    '@お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞの内容が"SPACE"か
                    If frmxxMN0001.Instance.vsfFavorites.GetData(llngCnt, CPlngMenuKeyCol) = CPstrMenuKeySpace Then

                        '@お気に入り登録ｸﾞﾘｯﾄﾞに"〓〓〓空白行〓〓〓"を格納
                        frmxxMN0001.Instance.vsfFavorites.SetData(llngCnt, CPlngMenuTitleCol, CPlngFavoritesEditCaptionSpace)
                    End If
                Next llngCnt
                
                '@行の高さを設定
                frmxxMN0001.Instance.vsfFavorites.Rows.DefaultSize = CPlngMenuGridRowHeight
                
                frmxxMN0001.Instance.vsfFavorites.Redraw = True
            End With
            
            
            '@ｸﾞﾘｯﾄﾞ共通関数でお気に入り登録画面の上下ｽｸﾛｰﾙﾎﾞﾀﾝを初期化
            With frmxxMN0001.Instance
                
                '@=======================
                '@　流動系
                '@=======================
                Call pubVsfDisp(.vsfFlow, .cmdFlowUp, .cmdFlowDown)
                
                '@=======================
                '@　ﾂｰﾙ系
                '@=======================
                Call pubVsfDisp(.vsfTool, .cmdToolUp, .cmdToolDown)
                
                '@=======================
                '@　お気に入り
                '@=======================
                Call pubVsfDisp(.vsfFavorites, .cmdFavoritesUp, .cmdFavoritesDown)
            End With
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfGrid_init(frmxxMN0001.Instance)
            
            '@=======================
            '@　ﾒﾆｭｰ伸縮処理
            '@=======================
            Call cmdExpand_Click(cmdExpand, EventArgs.Empty)
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　お気に入り登録画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxMN0001.Instance.ShowDialog(Me)
            frmxxMN0001.Instance = Nothing
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfGrid_init(Me)

            '@起動中ﾌﾟﾛｸﾞﾗﾑ退避変数がNULL以外か
            If pstrExecuteMenuKey <> vbNullString Then

                With vsfFavorites
                
                    '@行番号変数に"-1：未選択"をｾｯﾄ
                    llngRow = CPlngMenuVSFlexGridUnChoosing

                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    
                        '@お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞのﾌﾟﾛｸﾞﾗﾑ名と、起動中ﾌﾟﾛｸﾞﾗﾑ退避変数が同じか
                        If .GetData(llngCnt, CPlngMenuKeyCol) = pstrExecuteMenuKey Then

                            '@一致行を選択する
                            llngRow = llngCnt
                            Exit For
                        End If
                    Next llngCnt
                    
                    '@一致行が"-1：ｸﾞﾘｯﾄﾞ外"以外か
                    If llngRow <> CPlngMenuVSFlexGridUnChoosing Then

                        '@一致行が表示されるように先頭行を設定する
                        .TopRow = (llngRow \ CPlngMenuGridPageRows) * CPlngMenuGridPageRows
                    End If
                    
                    '@=======================
                    '@　先頭行設定＆ﾎﾞﾀﾝ設定処理
                    '@=======================
                    Call pubVsfDisp(vsfFavorites, cmdFavoritesUp, cmdFavoritesDown)

                End With
            End If
            
            '@=======================
            '@　ﾒﾆｭｰ伸縮処理
            '@=======================
            'NSYS お気に入り登録を閉じたタイミングで、Form_Activate が呼び出され、メニューが拡大するため不要
            'Call cmdExpand_Click(cmdExpand, EventArgs.Empty)
            
            '@=======================
            '@　各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
            '@=======================
            Call pubGridMenuButton_Set()
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞ共通処理(ｸﾞﾘｯﾄﾞの表示位置・上下ｽｸﾛｰﾙﾎﾞﾀﾝを初期化)
            '@=======================
            Call pubVsfDisp(vsfFavorites, cmdFavoritesUp, cmdFavoritesDown)
            
            
            '@***********************
            '@　起動中ﾌﾗｸﾞが立っているお気に入りが消される場合があるので、その対応処理。
            '@***********************
            '@起動中のﾌﾟﾛｸﾞﾗﾑが存在しないか
            If lblnAgreementFlg = False Then

                '@ｺﾝﾄﾛｰﾙを解放し、処理終了
                lctlControl = Nothing
                Exit Sub
            End If
            
            '@起動中ﾌﾟﾛｸﾞﾗﾑ退避変数がNULLか
            If pstrExecuteMenuKey = vbNullString Then

                '@ｺﾝﾄﾛｰﾙを解放し、処理終了
                lctlControl = Nothing
                Exit Sub
            End If
            
            '@お気に入りのｸﾞﾘｯﾄﾞに起動中のｸﾘｱと同じﾒﾆｭｰｷｰの項目があるかどうかを確認する
            With vsfFavorites
            
                '@起動中画面判定ﾌﾗｸﾞに"False：起動中画面なし"をｾｯﾄ
                lblnAgreementFlg = False

                For llngCnt = 0 To .Rows.Count - 1
                
                    '@お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞのﾌﾟﾛｸﾞﾗﾑ名と、起動中ﾌﾟﾛｸﾞﾗﾑ退避変数が同じか
                    If .GetData(llngCnt, CPlngMenuKeyCol) = pstrExecuteMenuKey Then

                        '@起動中画面判定ﾌﾗｸﾞに"True：起動中画面あり"をｾｯﾄ
                        lblnAgreementFlg = True
                        Exit For
                    End If
                Next llngCnt
            End With
            
            '@起動中画面判定ﾌﾗｸﾞが"True：起動中画面あり"か
            If lblnAgreementFlg = True Then

                '@ｺﾝﾄﾛｰﾙを解放し、処理終了
                lctlControl = Nothing
                Exit Sub
            Else
                '@起動中画面判定ﾌﾗｸﾞが"False：起動中画面なし"か
                
                '@frmxxMN0000上のｺﾝﾄﾛｰﾙを検索
                For Each lctlControl In GetAllControls(Me)
                
                    '@ｺﾝﾄﾛｰﾙがｸﾞﾘｯﾄﾞか(流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ、ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ、お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞの3つがﾋｯﾄするはず)
                    If TypeOf lctlControl Is C1FlexGrid Then

                        With CType(lctlControl, C1FlexGrid)
                        
                            '@検索したｺﾝﾄﾛｰﾙが流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ or ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞか
                            If lctlControl.Name = vsfFlow.Name Or lctlControl.Name = vsfTool.Name Then

                                For llngCnt = 0 To .Rows.Count - 1
                                
                                    '@お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞのﾌﾟﾛｸﾞﾗﾑ名と、起動中ﾌﾟﾛｸﾞﾗﾑ退避変数が同じか
                                    If .GetData(llngCnt, CPlngMenuKeyCol) = pstrExecuteMenuKey Then

                                        '@対象ﾌﾟﾛｸﾞﾗﾑの行に起動中ﾌﾗｸﾞ"1：起動中"をｾｯﾄ
                                        .SetData(llngCnt, CPlngMenuExecuteCol, CPlngMenuExecuteFlg)
                                        
                                        '@ｺﾝﾄﾛｰﾙを解放し、処理終了
                                        lctlControl = Nothing
                                        Exit Sub
                                    End If
                                Next llngCnt
                            End If
                        End With
                    End If
                Next
            End If
            
            '@ｺﾝﾄﾛｰﾙを解放する
            lctlControl = Nothing

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdFavorites_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：Index：使用しない
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 15:02:00 H.Wajima
    '更新日：2008/06/23 (Mon) 16:34:58 N.Kojima
    '備　考：
    '　　　：2008/06/23 (Mon) 16:34:58 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose0.Click, cmdClose1.Click, cmdClose2.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@∇∇∇∇∇∇∇∇∇∇∇
            '@　ﾒﾆｭｰ画面のｱﾝﾛｰﾄﾞ処理
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

    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 関数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================

    '関数名：prvVsfGrid_Init
    '機　能：ﾒﾆｭｰ画面ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：lstrFormName：対象ﾌｫｰﾑ名
    '戻り値：
    '作成日：2004/05/12 (Wed) 10:34:44 H.Wajima
    '更新日：2008/06/25 (Wed) 14:17:09 N.Kojima
    '備　考：
    '　　　：2008/06/25 (Wed) 14:17:09 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub prvVsfGrid_Init(ByVal lfrmForm As Form)

        Dim lctlControl     As Control      'ｺﾝﾄﾛｰﾙ

        Try
            
            '@引数で指定されたﾌｫｰﾑ(frmxxMN0000 or frmxxMN0001)上のｺﾝﾄﾛｰﾙを検索
            For Each lctlControl In GetAllControls(lfrmForm)
            
                '@ｺﾝﾄﾛｰﾙがｸﾞﾘｯﾄﾞか
                '@　①lfrmForm=frmxxMN0000：流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ、ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ、お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞの3つがﾋｯﾄするはず
                '@　②lfrmForm=frmxxMN0001：編集前お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ、編集後お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞの2つがﾋｯﾄするはず
                If TypeOf lctlControl Is C1FlexGrid Then
                
                    With CType(lctlControl, C1FlexGrid)
                        .Redraw = False
                    
                        '@各種ﾌﾟﾛﾊﾟﾃｨの設定
                        .Cols.Fixed = 0
                        .Rows.Fixed = 0
                        .Cols.Count = CPlngMenuGridCols
                        .Rows.DefaultSize = CPlngMenuGridRowHeight
                        .ScrollBars = ScrollBars.None
                        
                        '@★ 引数のﾌｫｰﾑ名により処理分岐 ★
                        Select Case lfrmForm.Name
                        
                            '@〓 frmxxMN0000：ﾒﾆｭｰﾌｫｰﾑ 〓
                            Case Me.Name
                                
                                '@列幅の設定
                                .Cols(CPlngMenuKeyCol).Width = CPlngMenuKeyColWidth
                                .Cols(CPlngMenuTitleCol).Width = CPlngMenuTitleColWidth
                                
                            '@〓 frmxxMN0001：お気に入り登録ﾌｫｰﾑ 〓
                            Case frmxxMN0001.Instance.Name
                            
                                .Cols(CPlngMenuKeyCol).Width = 0
                                .Cols(CPlngMenuTitleCol).Width = CPlngMenuTitleColWidth + CPlngMenuGridButtonSize
                        End Select
                        
                        .FocusRect = FocusRectEnum.None
                        .HighLight = HighLightEnum.WithFocus
                        .SelectionMode = SelectionModeEnum.Row
                        
                        '@IMEﾓｰﾄﾞをOFF固定にする
                        ImeMode = ImeMode.Off
                        'NSYS フラグ列を非表示
                        .Cols(CPlngMenuExecuteCol).Visible = False
                        .Cols(CPlngMenuCarrTakeOver).Visible = False
                        .Redraw = True
                    End With
                End If
            Next
                
            '@ｺﾝﾄﾛｰﾙを解放する
            lctlControl = Nothing
            lfrmForm = Nothing
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfGrid_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvGridMenuButton_Init
    '機　能：各種ﾒﾆｭｰﾎﾞﾀﾝの初期化処理
    '引　数：なし
    '戻り値：
    '作成日：2004/05/12 (Wed) 11:07:24 H.Wajima
    '更新日：2008/06/25 (Wed) 14:39:52 N.Kojima
    '備　考：
    '　　　：2008/06/25 (Wed) 14:39:52 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub prvGridMenuButton_Init()
        
        Dim llngCnt             As Integer  '汎用ｶｳﾝﾀ

        Try

            'NSYS グリッドに配置するボタンコントロール配列の作成（14つ作成）
            Me.cmdvsfFlows = New Button(13) {}
            Me.cmdvsfTools = New Button(13) {}
            Me.cmdvsfFavoritess = New Button(13) {}


            '@ｸﾞﾘｯﾄﾞの表示行数分(ｺﾏﾝﾄﾞﾎﾞﾀﾝの数分)処理を繰り返す
            For llngCnt = 0 To CPlngMenuGridPageRows - 1
                
                If llngCnt = 0 Then
                    'NSYS 1つ目のボタンを配列に紐づけ
                    Me.cmdvsfFlows(0) = Me.cmdVsfFlow
                    Me.cmdvsfTools(0) = Me.cmdVsfTool
                    Me.cmdvsfFavoritess(0) = Me.cmdVsfFavorites
                Else
                    cmdvsfFlows(llngCnt) = New Button
                    cmdvsfTools(llngCnt) = New Button
                    cmdvsfFavoritess(llngCnt) = New Button
                    AddHandler Me.cmdvsfFlows(llngCnt).Click, AddressOf Me.cmdVsfFlow_Click
                    AddHandler Me.cmdvsfTools(llngCnt).Click, AddressOf Me.cmdVsfTool_Click
                    AddHandler Me.cmdvsfFavoritess(llngCnt).Click, AddressOf Me.cmdVsfFavorites_Click
                End If

                '@=======================
                '@　流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ
                '@=======================
                With cmdvsfFlows(llngCnt)
                
                    '@ｶｳﾝﾀが0以外の場合
                    If llngCnt <> 0 Then
                    
                        'NSYS プロパティをコピー
                        CopyProperties_Button(cmdvsfFlows(llngCnt), cmdvsfFlows(0))
                        .Visible = True                         '表示する
                    End If
                    .Top = CPlngMenuKeyColWidth * llngCnt - 2   '表示位置：1つ上のﾎﾞﾀﾝの下
                    .Height = CPlngMenuGridButtonSize           '高さ
                    .Width = CPlngMenuGridButtonSize            '幅
                    .TabStop = False                            'ﾀﾌﾞでのﾌｫｰｶｽ取得：しない
                    'NSYS Tagにインデックスを保持
                    .Tag = llngCnt
                End With
                
                '@=======================
                '@　ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ
                '@=======================
                With cmdvsfTools(llngCnt)
                
                    '@ｶｳﾝﾀが0以外の場合
                    If llngCnt <> 0 Then

                        'NSYS プロパティをコピー
                        CopyProperties_Button(cmdvsfTools(llngCnt), cmdvsfTools(0))
                        .Visible = True                         '表示する
                    End If
                    .Top = CPlngMenuKeyColWidth * llngCnt - 2   '表示位置：1つ上のﾎﾞﾀﾝの下
                    .Height = CPlngMenuGridButtonSize           '高さ
                    .Width = CPlngMenuGridButtonSize            '幅
                    .TabStop = False                            'ﾀﾌﾞでのﾌｫｰｶｽ取得：しない
                    'NSYS Tagにインデックスを保持
                    .Tag = llngCnt
                End With
                
                '@=======================
                '@　お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ
                '@=======================
                With cmdvsfFavoritess(llngCnt)
                
                    '@ｶｳﾝﾀが0以外の場合
                    If llngCnt <> 0 Then

                        'NSYS プロパティをコピー
                        CopyProperties_Button(cmdvsfFavoritess(llngCnt), cmdvsfFavoritess(0))
                        .Visible = True                         '表示する
                    End If
                    .Top = CPlngMenuKeyColWidth * llngCnt - 2   '表示位置：1つ上のﾎﾞﾀﾝの下
                    .Height = CPlngMenuGridButtonSize           '高さ
                    .Width = CPlngMenuGridButtonSize            '幅
                    .TabStop = False                            'ﾀﾌﾞでのﾌｫｰｶｽ取得：しない
                    'NSYS Tagにインデックスを保持
                    .Tag = llngCnt
                End With

            Next llngCnt

            'NSYS ボタンをグリッドに追加
            fravsfFlow.Controls.AddRange(Me.cmdvsfFlows)
            fravsfTool.Controls.AddRange(Me.cmdvsfTools)
            fravsfFavorites.Controls.AddRange(Me.cmdvsfFavoritess)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGridMenuButton_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：pubGridMenuButton_Set
    '機　能：各種ﾒﾆｭｰﾎﾞﾀﾝの設定処理
    '引　数：llngAppointRow：行指定(ﾏｳｽでｸﾘｯｸした場合は、行を指定する)
    '戻り値：なし
    '作成日：2004/04/23 (Fri) 09:41:27 H.Wajima
    '更新日：2008/06/24 (Tue) 14:39:28 N.Kojima
    '備　考：
    '　　　：2004/09/06 (Mon) 11:31:51 H.Wajima     お気に入りの整理で、項目数が減った場合に行番号が残るので、初期化処理を追加。
    '　　　：2008/06/24 (Tue) 14:39:28 N.Kojima     ｿｰｽ整備。(案件№03004)
    Public Sub pubGridMenuButton_Set(Optional ByVal llngAppointRow As Integer = -2)
        
        Dim lctlControl                 As Control      'ｺﾝﾄﾛｰﾙ
        Dim lblnAgreementFlg            As Boolean      'ﾀﾌﾞとｸﾞﾘｯﾄﾞの一致判定ﾌﾗｸﾞ(True：一致、False：不一致)
        Dim lintButtonIndex             As Short        'ﾎﾞﾀﾝのｲﾝﾃﾞｯｸｽ
        Dim llngTopRow                  As Integer      'ｸﾞﾘｯﾄﾞの先頭行格納用
        Dim llngCnt                     As Integer      '汎用ｶｳﾝﾀ
        Dim llngRow                     As Integer      '行番号格納用

        Try
            
            vsfFlow.SuspendLayout

            '@***********************
            '@　ﾎﾞﾀﾝの画像・ｷｬﾌﾟｼｮﾝを初期化する
            '@　※ｸﾞﾘｯﾄﾞの1ﾍﾟｰｼﾞの行数分(ﾎﾞﾀﾝの数分)処理を繰り返す
            '@***********************
            For llngCnt = 0 To CPlngMenuGridPageRows - 1
            
                '@流動系ﾒﾆｭｰ
                With cmdVsfFlows(llngCnt)
                    .BackgroundImage = Nothing
                    .Text = vbNullString
                End With
                
                '@ﾂｰﾙ系ﾒﾆｭｰ
                With cmdVsfTools(llngCnt)
                    .BackgroundImage = Nothing
                    .Text = vbNullString
                End With
                
                '@お気に入りﾒﾆｭｰ
                With cmdVsfFavoritess(llngCnt)
                    .BackgroundImage = Nothing
                    .Text = vbNullString
                End With

            Next llngCnt
            
            
            '@frmxxMN0000上のｺﾝﾄﾛｰﾙを検索
            Dim all As Control() = GetAllControls(Me)
            For Each lctlControl In all
                
                '@ｺﾝﾄﾛｰﾙがｸﾞﾘｯﾄﾞか(流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ、ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ、お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞの3つがﾋｯﾄするはず)
                If TypeOf lctlControl Is C1FlexGrid Then

                    With CType(lctlControl, C1FlexGrid)
                    
                        '@ﾀﾌﾞとｸﾞﾘｯﾄﾞの一致判定ﾌﾗｸﾞを初期化する
                        lblnAgreementFlg = False
                        
                        '@★ 選択ﾀﾌﾞにより処理分岐 ★
                        Select Case tabMenu.SelectedIndex
                        
                            '@〓 0：流動系ﾀﾌﾞ 〓
                            Case CPlngMenuTabFlow
                            
                                '@検索にﾋｯﾄしたｸﾞﾘｯﾄﾞが流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞか
                                If .Name = vsfFlow.Name Then

                                    '@ﾀﾌﾞとｸﾞﾘｯﾄﾞの一致判定ﾌﾗｸﾞに"True：一致"をｾｯﾄ
                                    lblnAgreementFlg = True
                                End If
                                
                                '@***********************
                                '@　ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝに番号を設定する
                                '@***********************
                                '@=======================
                                '@　先頭行取得処理
                                '@=======================
                                llngTopRow = pubstrVsfTag_Get(vsfFlow, 1)

                                '@流動系ﾒﾆｭｰﾎﾞﾀﾝのｲﾝﾃﾞｯｸｽ分ﾙｰﾌﾟ
                                For llngCnt = 0 To cmdvsfFlows.Count - 1
                                
                                    '@ﾒﾆｭｰｷｰがNULL以外か
                                    If vsfFlow.GetData(llngTopRow + llngCnt, CPlngMenuKeyCol) <> vbNullString Then
                                        
                                        '@ﾎﾞﾀﾝの画像が未設定か
                                        If cmdVsfFlows(llngCnt).BackgroundImage Is Nothing Then

                                            '@ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝに行番号を設定する
                                            cmdVsfFlows(llngCnt).Text = llngTopRow + llngCnt + 1
                                        End If
                                    End If
                                Next llngCnt
                            
                            
                            '@〓 1：ﾂｰﾙ系ﾀﾌﾞ 〓
                            Case CPlngMenuTabTool
                            
                                '@検索にﾋｯﾄしたｸﾞﾘｯﾄﾞがﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞか
                                If .Name = vsfTool.Name Then

                                    '@ﾀﾌﾞとｸﾞﾘｯﾄﾞの一致判定ﾌﾗｸﾞに"True：一致"をｾｯﾄ
                                    lblnAgreementFlg = True
                                End If
                                
                                '@***********************
                                '@　ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝに番号を設定する
                                '@***********************
                                '@=======================
                                '@　先頭行取得処理
                                '@=======================
                                llngTopRow = pubstrVsfTag_Get(vsfTool, 1)
                                
                                '@ﾂｰﾙ系ﾒﾆｭｰﾎﾞﾀﾝのｲﾝﾃﾞｯｸｽ分ﾙｰﾌﾟ
                                For llngCnt = 0 To cmdvsfTools.Count - 1
                                
                                    '@ﾒﾆｭｰｷｰがNULL以外か
                                    If vsfTool.GetData(llngTopRow + llngCnt, CPlngMenuKeyCol) <> vbNullString Then

                                        '@ﾎﾞﾀﾝの画像が未設定か
                                        If cmdVsfTools(llngCnt).BackgroundImage Is Nothing Then

                                            '@ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝに行番号を設定する
                                            cmdVsfTools(llngCnt).Text = llngTopRow + llngCnt + 1
                                        End If
                                    End If
                                Next llngCnt
                            
                            
                            '@〓 2：お気に入りﾀﾌﾞ 〓
                            Case CPlngMenuTabFavorites
                            
                                '@検索にﾋｯﾄしたｸﾞﾘｯﾄﾞがお気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞか
                                If .Name = vsfFavorites.Name Then

                                    '@ﾀﾌﾞとｸﾞﾘｯﾄﾞの一致判定ﾌﾗｸﾞに"True：一致"をｾｯﾄ
                                    lblnAgreementFlg = True
                                End If
                        
                                '@***********************
                                '@　ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝに番号を設定する
                                '@***********************
                                '@=======================
                                '@　先頭行取得処理
                                '@=======================
                                llngTopRow = pubstrVsfTag_Get(vsfFavorites, 1)

                                '@お気に入りﾒﾆｭｰﾎﾞﾀﾝのｲﾝﾃﾞｯｸｽ分ﾙｰﾌﾟ
                                For llngCnt = 0 To cmdvsfFavoritess.Count - 1
                                
                                    '@ﾒﾆｭｰｷｰがNULL以外か
                                    If vsfFavorites.GetData(llngTopRow + llngCnt, CPlngMenuKeyCol) <> vbNullString Then

                                        '@ﾎﾞﾀﾝの画像が未設定か
                                        If cmdVsfFavoritess(llngCnt).BackgroundImage Is Nothing Then

                                            '@ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝに行番号を設定する
                                            cmdVsfFavoritess(llngCnt).Text = llngTopRow + llngCnt + 1
                                        End If
                                    End If
                                Next llngCnt
                        End Select
                        
                        
        '@↓2008/06/30 (Mon) 13:36:52 N.Kojima **************************************************
                        '@ﾀﾌﾞとｸﾞﾘｯﾄﾞの一致判定ﾌﾗｸﾞが"True：一致"、かつ起動中ﾌﾟﾛｸﾞﾗﾑ退避領域(工程管理用orWEB用)がNULL以外か
        '                If lblnAgreementFlg = True And pstrExecuteMenuKey <> vbNullString Then
                        If lblnAgreementFlg = True And (pstrExecuteMenuKey <> vbNullString Or _
                            pstrExecuteWebMenuKey <> vbNullString Or pstrExecuteExeMenuKey <> vbNullString) Then
        '@↑2008/06/30 (Mon) 13:36:52 N.Kojima **************************************************

                            With CType(lctlControl, C1FlexGrid)
                            
                                '@行番号格納変数に"-1：未選択(ｸﾞﾘｯﾄﾞ外)"をｾｯﾄ
                                llngRow = CPlngMenuVSFlexGridUnChoosing
                                
                                '@起動中ﾌﾟﾛｸﾞﾗﾑを検索
                                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                                    
                                    '@EXE用ﾌﾟﾛｸﾞﾗﾑ退避領域がNULL以外か
                                    If pstrExecuteExeMenuKey <> vbNullString Then
                                        '@EXEﾒﾆｭｰ(EX****)起動の場合
                                    
                                        '@ﾒﾆｭｰｸﾞﾘｯﾄﾞのﾒﾆｭｰｷｰ(ﾌﾟﾛｸﾞﾗﾑ名)と起動中ﾌﾟﾛｸﾞﾗﾑ名が同じか
                                        If .GetData(llngCnt, CPlngMenuKeyCol) = pstrExecuteExeMenuKey Then
            
                                            '@該当行を選択行に設定し、ﾙｰﾌﾟ処理終了
                                            llngRow = llngCnt
                                            Exit For
                                        End If
                                    Else
                                        '@EXE用ﾌﾟﾛｸﾞﾗﾑ退避領域がNULLの場合
                                    
                                        '@WEB用ﾌﾟﾛｸﾞﾗﾑ退避領域がNULL以外か
                                        If pstrExecuteWebMenuKey <> vbNullString Then
                                            '@WEBﾒﾆｭｰ(WB****)起動の場合
                                        
                                            '@ﾒﾆｭｰｸﾞﾘｯﾄﾞのﾒﾆｭｰｷｰ(ﾌﾟﾛｸﾞﾗﾑ名)と起動中ﾌﾟﾛｸﾞﾗﾑ名が同じか
                                            If .GetData(llngCnt, CPlngMenuKeyCol) = pstrExecuteWebMenuKey Then
                
                                                '@該当行を選択行に設定し、ﾙｰﾌﾟ処理終了
                                                llngRow = llngCnt
                                                Exit For
                                            End If
                                        Else
                                            '@工程管理ﾒﾆｭｰ(EN****)起動の場合
                                        
                                            '@ﾒﾆｭｰｸﾞﾘｯﾄﾞのﾒﾆｭｰｷｰ(ﾌﾟﾛｸﾞﾗﾑ名)と起動中ﾌﾟﾛｸﾞﾗﾑ名が同じか
                                            If .GetData(llngCnt, CPlngMenuKeyCol) = pstrExecuteMenuKey Then
                
                                                '@該当行を選択行に設定し、ﾙｰﾌﾟ処理終了
                                                llngRow = llngCnt
                                                Exit For
                                            End If
                                        End If
                                    End If
                                Next llngCnt
                                
                                '@行番号格納変数が"-1：未選択(ｸﾞﾘｯﾄﾞ外)"か：起動中ﾌﾟﾛｸﾞﾗﾑの行を格納しているか
                                If llngRow <> CPlngMenuVSFlexGridUnChoosing Then
                                    
                                    '@★ 選択行により処理分岐 ★
                                    Select Case llngRow
                                    
                                        '@〓 選択行が表示されている場合(先頭行(N)から(先頭行(N)+14-1)以内) 〓
                                        Case llngTopRow To llngTopRow + CPlngMenuGridPageRows - 1
                                            
                                            '@何番目のﾎﾞﾀﾝが選択行に該当するかを求める
                                            lintButtonIndex = llngRow - llngTopRow
                                            
                                            '@★★ 選択ﾀﾌﾞにより処理分岐 ★★
                                            Select Case tabMenu.SelectedIndex
                                            
                                                '@〓〓 流動系ﾀﾌﾞ 〓〓
                                                Case CPlngMenuTabFlow

                                                    '@選択行のﾎﾞﾀﾝに画像を設定する
                                                    With cmdVsfFlows(lintButtonIndex)
                                                        .Text = vbNullString
                                                        .BackgroundImage = picMenu.Image
                                                    End With
                                                    
                                                '@〓〓 ﾂｰﾙ系ﾀﾌﾞ 〓〓
                                                Case CPlngMenuTabTool

                                                    '@選択行のﾎﾞﾀﾝに画像を設定する
                                                    With cmdVsfTools(lintButtonIndex)
                                                        .Text = vbNullString
                                                        .BackgroundImage = picMenu.Image
                                                    End With
                                                    
                                                '@〓〓 流動系ﾀﾌﾞ 〓〓
                                                Case CPlngMenuTabFavorites

                                                    '@選択行のﾎﾞﾀﾝに画像を設定する
                                                    With cmdVsfFavoritess(lintButtonIndex)
                                                        .Text = vbNullString
                                                        .BackgroundImage = picMenu.Image
                                                    End With
                                            End Select
                                    End Select
                                    
                                End If
                            End With
                        End If
                    End With
                End If
            Next
            vsfFlow.ResumeLayout

            '@ｺﾝﾄﾛｰﾙを解放する
            lctlControl = Nothing

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "pubGridMenuButton_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvGridMenuButtonPush_Proc
    '機　能：各種ﾒﾆｭｰﾎﾞﾀﾝの押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 09:04:59 H.Wajima
    '更新日：2008/06/25 (Wed) 08:42:08 N.Kojima
    '備　考：ｸﾞﾘｯﾄﾞの行が指定されたときに、対応するﾒﾆｭｰﾎﾞﾀﾝの押下処理を行う
    '　　　：2008/06/25 (Wed) 08:42:08 N.Kojima     ｿｰｽ整備。(案件№03004)
    Public Sub prvGridMenuButtonPush_Proc()

        Dim lctlControl                 As Control  'ｺﾝﾄﾛｰﾙ
        Dim lblnAgreementFlg            As Boolean  'ﾀﾌﾞとｸﾞﾘｯﾄﾞの一致判定ﾌﾗｸﾞ(True：一致、False：不一致)
        Dim llngTopRow                  As Integer  'ｸﾞﾘｯﾄﾞのTopRow
        Dim lintButtonIndex             As Short    'ﾎﾞﾀﾝのｲﾝﾃﾞｯｸｽ

        Try
            
            '@frmxxMN0000上のｺﾝﾄﾛｰﾙを検索
            Dim all As Control() = GetAllControls(Me)
            For Each lctlControl In all
            
                '@ｺﾝﾄﾛｰﾙがｸﾞﾘｯﾄﾞか(流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ、ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ、お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞの3つがﾋｯﾄするはず)
                If TypeOf lctlControl Is C1FlexGrid Then

                    With CType(lctlControl, C1FlexGrid)
                    
                        '@ﾀﾌﾞとｸﾞﾘｯﾄﾞの一致判定ﾌﾗｸﾞを初期化する
                        lblnAgreementFlg = False
                        
                        '@★ 選択ﾀﾌﾞにより処理分岐 ★
                        Select Case tabMenu.SelectedIndex
                        
                            '@〓 0：流動系ﾀﾌﾞ 〓
                            Case CPlngMenuTabFlow
                                
                                '@検索にﾋｯﾄしたｸﾞﾘｯﾄﾞが流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞか
                                If .Name = vsfFlow.Name Then

                                    '@一致ﾌﾗｸﾞにTrueを設定
                                    lblnAgreementFlg = True
                                End If
                                
                            '@〓 1：ﾂｰﾙ系ﾀﾌﾞ 〓
                            Case CPlngMenuTabTool
                                
                                '@検索にﾋｯﾄしたｸﾞﾘｯﾄﾞがﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞか
                                If .Name = vsfTool.Name Then

                                    '@ﾀﾌﾞとｸﾞﾘｯﾄﾞの一致判定ﾌﾗｸﾞに"True：一致"をｾｯﾄ
                                    lblnAgreementFlg = True
                                End If
                                
                            '@〓 2：お気に入りﾀﾌﾞ 〓
                            Case CPlngMenuTabFavorites

                                '@検索にﾋｯﾄしたｸﾞﾘｯﾄﾞがお気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞか
                                If .Name = vsfFavorites.Name Then

                                    '@ﾀﾌﾞとｸﾞﾘｯﾄﾞの一致判定ﾌﾗｸﾞに"True：一致"をｾｯﾄ
                                    lblnAgreementFlg = True
                                End If
                        End Select
                        
                        '@ﾀﾌﾞとｸﾞﾘｯﾄﾞの一致判定ﾌﾗｸﾞが"True：一致"か
                        If lblnAgreementFlg = True Then
                            
                            '@選択ｸﾞﾘｯﾄﾞが"Row=-1：未選択状態"か
                            If .Row = CPlngMenuVSFlexGridUnChoosing Then
                            
                                '@ﾃﾞﾌｫﾙﾄで先頭行を選択する
                                .Row = 0
                            End If
                            
                            '@★ 選択ｸﾞﾘｯﾄﾞにより処理分岐 ★
                            Select Case lctlControl.Name
                                
                                '@〓 流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ 〓
                                Case vsfFlow.Name
                                    
                                    '@=======================
                                    '@　ｸﾞﾘｯﾄﾞ共通関数がRowHiddenを使用しているため、共通関数で先頭行を取得
                                    '@=======================
                                    llngTopRow = pubstrVsfTag_Get(vsfFlow, 1)
                                    
                                    '@何番目のﾎﾞﾀﾝが押されたかを求める
                                    lintButtonIndex = .Row - llngTopRow
                                    
                                    '@=======================
                                    '@　流動系ﾒﾆｭｰﾎﾞﾀﾝの押下処理
                                    '@=======================
                                    '@ﾌﾟﾛｸﾞﾗﾑ切り替え処理を実行する
                                    Call prvPrgSwitch_Proc(vsfFlow, lintButtonIndex)
                                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ設定処理
                                    Call pubGridMenuButton_Set(vsfFlow.Row)
                                    
                                
                                '@〓 ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ 〓
                                Case vsfTool.Name
                                    
                                    '@=======================
                                    '@　ｸﾞﾘｯﾄﾞ共通関数がRowHiddenを使用しているため、共通関数で先頭行を取得
                                    '@=======================
                                    llngTopRow = pubstrVsfTag_Get(vsfTool, 1)
                                    
                                    '@何番目のﾎﾞﾀﾝが押されたかを求める
                                    lintButtonIndex = .Row - llngTopRow
                                    
                                    '@=======================
                                    '@　ﾂｰﾙ系ﾒﾆｭｰﾎﾞﾀﾝの押下処理
                                    '@=======================
                                    '@ﾌﾟﾛｸﾞﾗﾑ切り替え処理を実行する
                                    Call prvPrgSwitch_Proc(vsfTool, lintButtonIndex)
                                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ設定処理
                                    Call pubGridMenuButton_Set(vsfTool.Row)
                                    
                                    
                                '@〓 お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ 〓
                                Case vsfFavorites.Name
                                    
                                    '@=======================
                                    '@　ｸﾞﾘｯﾄﾞ共通関数がRowHiddenを使用しているため、共通関数で先頭行を取得
                                    '@=======================
                                    llngTopRow = pubstrVsfTag_Get(vsfFavorites, 1)
                                    
                                    '@何番目のﾎﾞﾀﾝが押されたかを求める
                                    lintButtonIndex = .Row - llngTopRow
                                    
                                    '@=======================
                                    '@　お気に入りﾒﾆｭｰﾎﾞﾀﾝの押下処理
                                    '@=======================
                                    '@ﾌﾟﾛｸﾞﾗﾑ切り替え処理を実行する
                                    Call prvPrgSwitch_Proc(vsfFavorites, lintButtonIndex)
                                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ設定処理
                                    Call pubGridMenuButton_Set(vsfFavorites.Row)

                            End Select
                        End If
                    End With
                End If
            Next
            
            '@ｺﾝﾄﾛｰﾙを解放する
            lctlControl = Nothing

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGridMenuButtonPush_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvlngPrgStart_Proc
    '機　能：ﾌﾟﾛｸﾞﾗﾑ開始処理
    '引　数：vsfControl     ：対象となるｸﾞﾘｯﾄﾞ
    '　　　：ltypCommonInfo ：引継ぎ情報構造体
    '戻り値：なし
    '作成日：2004/04/21 (Wed) 17:36:29 H.Wajima
    '更新日：2008/06/23 (Mon) 14:32:25 N.Kojima
    '備　考：
    '　　　：2004/09/30 (Thu) 10:04:28 H.Wajima     ﾌﾟﾛｸﾞﾗﾑの起動が異常終了した場合に起動中ﾌﾟﾛｸﾞﾗﾑ名の初期化処理を追加。
    '　　　：2004/10/14 (Thu) 10:10:33 H.Wajima     Web系機能を起動した場合、起動中機能を終了しないよう変更。
    '　　　：2004/10/28 (Thu) 17:11:15 N.Kojima     ﾌｫｰﾑﾛｰﾄﾞ中に終了ｺﾏﾝﾄﾞを入力された場合の対応を追加。
    '　　　：2008/06/23 (Mon) 14:32:25 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Function prvlngPrgStart_Proc(ByVal vsfControl As C1FlexGrid, ByRef ltypCommonInfo As CommonInfo) As Integer

        Dim llngRet                 As Integer      '戻り値(整数値)
        Dim lstrMenuKey             As String       'ﾒﾆｭｰｷｰ

        Try
            
            '@ﾒﾆｭｰ画面の左端が機能画面にかぶっているか(10935以下か)
            If Me.Left <= CPlngAppliNarrowWidth Then
                '@ﾒﾆｭｰの幅が広いとき
                
                '@=======================
                '@　ﾒﾆｭｰの伸縮処理
                '@=======================
                Call pubMenuExpand_Disp(False)
            End If
            
            '@***********************
            '@　選択されたﾌﾟﾛｸﾞﾗﾑを起動する
            '@***********************
            With vsfControl
            
                '@ｸﾞﾘｯﾄﾞの選択行から、ﾒﾆｭｰｷｰを取得
                lstrMenuKey = .GetData(.Row, CPlngMenuKeyCol)
                
                '@★ 取得ﾒﾆｭｰｷｰにより処理分岐 ★
                Select Case lstrMenuKey
                    
                    '@〓 SPACE(空白行が選択されている場合) 〓
                    Case CPstrMenuKeySpace

                        '@戻り値にﾌﾟﾛｸﾞﾗﾑ正常終了ｺｰﾄﾞ"0"をｾｯﾄ
                        llngRet = CPlngNormalStatusCD
                        
                    '@〓 EX****(EXE起動ﾂｰﾙの場合) 〓
                    Case CPstrMenuKeyExecuteLower To CPstrMenuKeyExecuteUpper
                        
                        '@=======================
                        '@　EXEﾌｧｲﾙ起動処理
                        '@=======================
                        llngRet = publngExeFile_Exec(lstrMenuKey)
                        
                    '@〓 WB****(WEBﾌﾞﾗｳｻﾞ起動ﾂｰﾙの場合) 〓
                    Case CPstrMenuKeyWebLower To CPstrMenuKeyWebUpper
                        
                        '@=======================
                        '@　WEBﾌﾞﾗｳｻﾞ起動処理
                        '@=======================
                        llngRet = publngWebBrowser_Exec(lstrMenuKey)
                    
                    '@〓 EN****(工程管理機能IDの場合) 〓
                    Case Else
                        
                        '@ﾌｫｰﾑﾛｰﾄﾞ中に終了ｺﾏﾝﾄﾞを入力された場合の対応
                        '@DoEventsﾌﾗｸﾞをtrueに
                        mblnDoEventsFlag = True
                        
                        '@=======================
                        '@　共通起動処理(工程管理)
                        '@=======================
                        llngRet = publngStart_Proc(lstrMenuKey, False, ltypCommonInfo, mfrmRootForm)
                        
                        '@DoEventsﾌﾗｸﾞをFalseに
                        mblnDoEventsFlag = False
                        
                End Select
                
                '@各種起動処理の戻り値が"0：正常起動"か
                If llngRet = CPlngNormalStatusCD Then
                
        '@↓2008/06/23 (Mon) 10:20:54 N.Kojima **************************************************

                    '@★ 取得ﾒﾆｭｰｷｰにより処理分岐 ★
                    Select Case lstrMenuKey
                    
                        '@〓 EX****(EXEの場合) 〓
                        Case CPstrMenuKeyExecuteLower To CPstrMenuKeyExecuteUpper

                            '@EXE系機能の場合
                            pstrExecuteExeMenuKey = .GetData(.Row, CPlngMenuKeyCol)
                            pstrExecuteWebMenuKey = vbNullString

                        '@〓 WB****(WEBﾌﾞﾗｳｻﾞ起動ﾂｰﾙの場合) 〓
                        Case CPstrMenuKeyWebLower To CPstrMenuKeyWebUpper

                            '@WEB系機能の場合
                            pstrExecuteWebMenuKey = .GetData(.Row, CPlngMenuKeyCol)
                            pstrExecuteExeMenuKey = vbNullString
                            
                        '@〓 WB****以外(工程管理機能ID、EXEの場合) 〓
                        Case Else

                            '@起動中ﾌﾟﾛｸﾞﾗﾑ名を保存し、WEB用の退避変数はｸﾘｱする
                            pstrExecuteMenuKey = .GetData(.Row, CPlngMenuKeyCol)
                            pstrExecuteWebMenuKey = vbNullString
                            pstrExecuteExeMenuKey = vbNullString
                    End Select
        '@↑2008/06/23 (Mon) 10:20:54 N.Kojima **************************************************

                Else
                    '@"0：正常終了ｺｰﾄﾞ"以外の値の場合
                    
                    '@起動中ﾌﾟﾛｸﾞﾗﾑ名退避変数を初期化する
                    pstrExecuteMenuKey = vbNullString           '工程管理ﾒﾆｭｰ用
                    pstrExecuteWebMenuKey = vbNullString        'WEB用
                    pstrExecuteExeMenuKey = vbNullString        'EXE用
                    
                    '@=======================
                    '@　ﾌﾟﾛｸﾞﾗﾑ終了処理
                    '@=======================
                    llngRet = publngEnd_Proc(.GetData(.Row, CPlngMenuKeyCol), ltypCommonInfo)
                End If
                
            End With
            
            '@ｺﾝﾄﾛｰﾙを解放する
            vsfControl = Nothing
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = ""
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvPrgSwitch_Proc
    '機　能：ﾌﾟﾛｸﾞﾗﾑ切り替え処理
    '引　数：vsfControl ：対象となるｸﾞﾘｯﾄﾞ
    '　　　：Index      ：現在の行
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 10:08:27 H.Wajima
    '更新日：2008/06/25 (Wed) 11:38:13 N.Kojima
    '備　考：
    '　　　：2004/09/26 (Sun) 13:21:52 N.Kasai　    strToCarrierIDを追加
    '　　　：2004/10/14 (Thu) 10:11:34 H.Wajima     Web系機能を起動した場合、起動中機能を終了しないよう変更
    '　　　：2004/10/27 (Wed) 10:30:38 M.Miura　    引継ぎ戻りﾒﾆｭｰｷｰの退避の場所を移動(特殊流動から引継ぎ戻りができない為)
    '　　　：2004/11/04 (Thu) 09:47:22 M.Miura　    引継ぎﾁｪｯｸﾎﾞｯｸｽを変数に変更(お気に入り登録画面に移動の為)(不具合№190)
    '　　　：2005/01/06 (Thu) 15:03:21 H.Wajima     ﾌﾟﾛｸﾞﾗﾑ終了処理に次起動機能IDを引数として追加
    '　　　：2005/01/18 (Tue) 13:00:11 H.Wajima     作業終了→特殊流動のｷｬﾘｱID引継ぎﾊﾟﾀｰﾝを例外処理に変更
    '　　　：2008/06/25 (Wed) 11:38:13 N.Kojima     ｿｰｽ整備。(案件№03004)
    Public Sub prvPrgSwitch_Proc(ByVal vsfControl As C1FlexGrid, ByVal Index As Short)

        Dim llngTopRow              As Integer      '先頭行
        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim llngRet                 As Integer      '戻り値格納用
        Dim llngCarrTakeOver        As Integer      'ｷｬﾘｱID引継ぎﾌﾗｸﾞ
        Dim llngDummy               As Integer      'ﾀﾞﾐｰ(Long)
        Dim lstrDummy               As String       'ﾀﾞﾐｰ(String)
        Dim lstrMenuKey             As String       'ﾒﾆｭｰｷｰ
        Dim lstrExecuteForm         As String       '実行中ﾌｫｰﾑ名
        Dim lstrTitle               As String       'ﾀｲﾄﾙ
        Dim lstrExeWebMenuTitle     As String       'Exe、Webﾒﾆｭｰﾀｲﾄﾙ格納用
        Dim lstrFromMenuKey         As String       '実行中ﾒﾆｭｰｷｰ退避
        Dim lblnFormVisible         As Boolean      'ﾌｫｰﾑ表示ﾌﾗｸﾞ(True：表示中、False：非表示)
        Dim lblnAgreementFlg        As Boolean      'ﾀﾌﾞ一致判定ﾌﾗｸﾞ(True：一致、False：不一致)
        Dim ltypCommonInfo          As CommonInfo   '引継ぎ情報格納

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰを砂時計に変更する
            Cursor.Current = Cursors.WaitCursor

            '@=======================
            '@　ｸﾞﾘｯﾄﾞ共通関数がRowHiddenを使用しているため、共通関数で先頭行を取得
            '@=======================
            llngTopRow = pubstrVsfTag_Get(vsfControl, 1)

            '@引継ぎ情報構造体を初期化する
            With ltypCommonInfo
                .strCarrierId = vbNullString
                .strDivision = vbNullString
                .strLotID = vbNullString
                .strOpID = vbNullString
                .strStepID = vbNullString
                .strWpID = vbNullString
                .strWpName = vbNullString
                .strToCarrierId = vbNullString
            End With


            With vsfControl
            
                '@★ 対象ｸﾞﾘｯﾄﾞにより処理分岐 ★
                Select Case vsfControl.Name
                
                    '@〓 流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ 〓
                    Case vsfFlow.Name
                        
                        '@選択ﾀﾌﾞが流動系ﾀﾌﾞか
                        If tabMenu.SelectedIndex = CPlngMenuTabFlow Then
                        
                            '@ﾀﾌﾞ一致判定ﾌﾗｸﾞに"True：一致"をｾｯﾄ
                            lblnAgreementFlg = True
                        Else
                            '@ﾀﾌﾞ一致判定ﾌﾗｸﾞに"False：不一致"をｾｯﾄ
                            lblnAgreementFlg = False
                        End If
                    
                    '@〓 ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ 〓
                    Case vsfTool.Name
                    
                        '@選択ﾀﾌﾞがﾂｰﾙ系ﾀﾌﾞか
                        If tabMenu.SelectedIndex = CPlngMenuTabTool Then
                        
                            '@ﾀﾌﾞ一致判定ﾌﾗｸﾞに"True：一致"をｾｯﾄ
                            lblnAgreementFlg = True
                        Else
                            '@ﾀﾌﾞ一致判定ﾌﾗｸﾞに"False：不一致"をｾｯﾄ
                            lblnAgreementFlg = False
                        End If
                        
                    '@〓 お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ 〓
                    Case vsfFavorites.Name
                    
                        '@選択ﾀﾌﾞがお気に入りﾀﾌﾞか
                        If tabMenu.SelectedIndex = CPlngMenuTabFavorites Then
                        
                            '@ﾀﾌﾞ一致判定ﾌﾗｸﾞに"True：一致"をｾｯﾄ
                            lblnAgreementFlg = True
                        Else
                            '@ﾀﾌﾞ一致判定ﾌﾗｸﾞに"False：不一致"をｾｯﾄ
                            lblnAgreementFlg = False
                        End If
                End Select
                
                '@ﾀﾌﾞ一致判定ﾌﾗｸﾞが"True：一致"か
                If lblnAgreementFlg = True Then

                    '@"先頭行+ﾒﾆｭｰﾎﾞﾀﾝのｲﾝﾃﾞｯｸｽ"の行を選択行に設定
                    .Row = llngTopRow + Index
                    
                    '@選択行のﾒﾆｭｰｷｰ(機能ID)、ﾒﾆｭｰﾀｲﾄﾙを格納する
                    lstrMenuKey = .GetData(.Row, CPlngMenuKeyCol)
                    lstrExeWebMenuTitle = .GetData(.Row, CPlngMenuTitleCol)
                    
                    '@選択行のﾒﾆｭｰｷｰ(機能ID)が"SPACE"orNULLか
                    If lstrMenuKey = CPstrMenuKeySpace Or lstrMenuKey = vbNullString Then

                        '@★ 選択ｸﾞﾘｯﾄﾞにより処理分岐 ★
                        Select Case vsfControl.Name
                        
                            '@〓 流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ 〓
                            Case vsfFlow.Name
                                
                                '@=======================
                                '@　流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ用の上下ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                                '@=======================
                                Call pubVsfDisp(vsfControl, cmdFlowUp, cmdFlowDown)
                            
                            '@〓 ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ 〓
                            Case vsfTool.Name
                            
                                '@=======================
                                '@　ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ用の上下ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                                '@=======================
                                Call pubVsfDisp(vsfControl, cmdToolUp, cmdToolDown)
                            
                            '@〓 お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ 〓
                            Case vsfFavorites.Name
                            
                                '@=======================
                                '@　お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ用の上下ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                                '@=======================
                                Call pubVsfDisp(vsfControl, cmdFavoritesUp, cmdFavoritesDown)
                        
                        End Select
                        
                        '@ﾏｳｽﾎﾟｲﾝﾀｰを元に戻す
                        Cursor.Current = Cursors.Default
                        
                        '@ｺﾝﾄﾛｰﾙを解放し、処理終了
                        vsfControl = Nothing
                        Exit Sub
                    End If
                    
                    
                    '@起動中ﾌﾟﾛｸﾞﾗﾑ退避変数がNULL以外か
                    If pstrExecuteMenuKey <> vbNullString Then
                        
                        '@★ 起動中ﾌﾟﾛｸﾞﾗﾑ(機能ID)により処理分岐 ★
                        Select Case pstrExecuteMenuKey
                            
                            '@〓 ﾏｽﾀ系(機能ID：EX0010) or 品質管理ﾂｰﾙ(機能ID：EX0020) 〓
                            Case CPstrMenuKeyMMenu, CPstrMenuKeySpc

                                '@起動中ﾌﾟﾛｸﾞﾗﾑ退避変数が選択行のﾒﾆｭｰｷｰ(機能ID)と異なるか　※2重起動の判定
                                If pstrExecuteMenuKey <> lstrMenuKey Then
                                    '@起動中のﾒﾆｭｰ名と起動するﾒﾆｭｰが違う場合
                                    
                                    '@=======================
                                    '@　起動中ﾌﾟﾛｸﾞﾗﾑ終了処理
                                    '@=======================
                                    llngRet = prvlngPrgAllEnd_Proc(ltypCommonInfo)
                                End If
                                
        '@↓2004/08/25 (Wed) 20:22:42 H.Wajima **************************************************
        '@別のﾂｰﾙを起動したときに、IEを終了さｾﾙ場合は復活
        '                    '@〓 WEB系(機能ID：EX****) 〓
        '                    Case CPstrMenuKeyWebLower To CPstrMenuKeyWebUpper
        '                        '@WEBﾂｰﾙの場合
        '                        '@二重起動の判定
        '                        If pstrExecuteMenuKey <> lstrMenuKey Then
        '                            '@起動中のﾒﾆｭｰ名と起動するﾒﾆｭｰが違う場合
        '                            If IsWindow(plngInetExphWnd) Then
        '                                '@IEが表示されている場合
        '                                '@IEを非表示にする
        '                                pobjInetExp.Visible = False
        '                                pobjInetExp.Quit
        '                            End If
        '                            '@ｳｨﾝﾄﾞｳﾊﾝﾄﾞﾙを初期化する
        '                            plngInetExphWnd = 0
        '                            '@IEのｵﾌﾞｼﾞｪｸﾄを解放する
        '                            Set pobjInetExp = Nothing
        '                        End If
        '@↑2004/08/25 (Wed) 20:22:42 H.Wajima **************************************************
                            
                            '@〓 工程管理系、WEB系、EXE系(機能ID：EN****、WB****、EX****(EX0010は除く)) 〓
                            Case Else

                                '@★ 選択行のﾒﾆｭｰｷｰ(機能ID)により処理分岐 ★
                                Select Case lstrMenuKey
                                    
                                    '@〓 EXE系(機能ID：EX****) or WEB系(機能ID：WB****) 〓
                                    Case CPstrMenuKeyExecuteLower To CPstrMenuKeyExecuteUpper, _
                                            CPstrMenuKeyWebLower To CPstrMenuKeyWebUpper
                                        
                                        '@処理なし
                                        
        '@↓2008/07/01 (Tue) 14:22:18 N.Kojima **************************************************
        '
        '                                '@ﾒﾆｭｰｷｰ格納可否ﾌﾗｸﾞを初期化する
        '                                lblnMenuKeyMatchFlag = False
        '
        '                                '@★★ EXE＆WEB起動判定ﾌﾗｸﾞにより処理分岐 ★★
        '                                Select Case mlngExeWebDispFlag
        '
        '                                    '@〓〓 0：EXE、WEB共に未起動 〓〓
        '                                    Case 0
        '
        '                                        '@EXE、WEBが起動していない場合は、"1：EXE、WEB起動済"をｾｯﾄ
        '                                        mlngExeWebDispFlag = 1
        '                                        mlngExeWebDispItemCnt = 1
        '
        '                                        '@EXE起動ﾒﾆｭｰ格納用に配列領域を確保
        '                                        ReDim mtypExeWebDispItem(mlngExeWebDispItemCnt)
        '
        '                                        '@ﾒﾆｭｰｷｰ、ﾒﾆｭｰﾀｲﾄﾙを格納
        '                                        mtypExeWebDispItem(mlngExeWebDispItemCnt).strKey = lstrMenuKey
        '                                        mtypExeWebDispItem(mlngExeWebDispItemCnt).strTitle = lstrExeWebMenuTitle
        '
        '
        '                                    '@〓〓 1：EXE、WEB起動済 〓〓
        '                                    Case 1
        '
        '                                        '@***********************
        '                                        '@　起動する機能がEXE or WEB起動の場合、EXE＆WEB起動判定ﾌﾗｸﾞに値をｾｯﾄ
        '                                        '@***********************
        '                                        For llngCnt2 = 1 To mlngExeWebDispItemCnt
        '
        '                                            '@EXE、WEB起動ﾒﾆｭｰ格納配列内に選択ﾒﾆｭｰｷｰが存在しないか
        '                                            If mtypExeWebDispItem(llngCnt2).strKey <> lstrMenuKey Then
        '
        '                                                '@ﾒﾆｭｰｷｰ格納可否判定ﾌﾗｸﾞに"True：格納する"をｾｯﾄ
        '                                                lblnMenuKeyMatchFlag = True
        '                                            Else
        '                                                '@ﾒﾆｭｰｷｰ格納可否判定ﾌﾗｸﾞに"False：格納しない"をｾｯﾄ
        '                                                lblnMenuKeyMatchFlag = False
        '                                                Exit For
        '                                            End If
        '                                        Next llngCnt2
        '
        '                                        '@ﾒﾆｭｰｷｰ一致判定ﾌﾗｸﾞが"True：格納する"か
        '                                        If lblnMenuKeyMatchFlag = True Then
        '
        '                                            '@起動ｶｳﾝﾄを+1する
        '                                            mlngExeWebDispItemCnt = mlngExeWebDispItemCnt + 1
        '
        '                                            '@EXE起動ﾒﾆｭｰ格納用に配列領域を確保
        '                                            ReDim Preserve mtypExeWebDispItem(mlngExeWebDispItemCnt)
        '
        '                                            '@ﾒﾆｭｰｷｰ、ﾒﾆｭｰﾀｲﾄﾙを格納
        '                                            mtypExeWebDispItem(mlngExeWebDispItemCnt).strKey = lstrMenuKey
        '                                            mtypExeWebDispItem(mlngExeWebDispItemCnt).strTitle = lstrExeWebMenuTitle
        '                                        End If
        '
        '                                End Select
        '@↑2008/07/01 (Tue) 14:22:18 N.Kojima **************************************************
                                    
                                    
                                    '@〓 工程管理系(機能ID：EN****) 〓
                                    Case Else
                                        
                                        '@=======================
                                        '@　機能毎関連情報取得処理
                                        '@=======================
                                        Call pubMenuItemCorrelation_Set(pstrExecuteMenuKey, lstrDummy, llngDummy, lstrExecuteForm)
                                        
                                        '@ﾌｫｰﾑ表示ﾌﾗｸﾞを初期化する
                                        lblnFormVisible = False
                
                                        '@表示中のﾌｫｰﾑを検索
                                        For Each frmOpenFrom In Application.OpenForms
                                        
                                            '@表示中のﾌｫｰﾑ名と機能情報取得で取得したﾌｫｰﾑ名が同じか
                                            If frmOpenFrom.Name = lstrExecuteForm Or _
                                                frmOpenFrom.Name = pstrExecuteMenuKey Then

                                                '@ﾌｫｰﾑ表示ﾌﾗｸﾞに"True：表示中"をｾｯﾄし、ﾙｰﾌﾟ処理終了
                                                lblnFormVisible = True
                                                Exit For
                                            End If
                                        Next
                                        
                                        '@ﾌｫｰﾑ表示ﾌﾗｸﾞが"True：表示中"か
                                        If lblnFormVisible = True Then

                                            '@起動中ﾌﾟﾛｸﾞﾗﾑ退避変数が選択行のﾒﾆｭｰｷｰ(機能ID)と同じか　※2重起動の判定
                                            If pstrExecuteMenuKey = lstrMenuKey Then

                                                '@ﾏｳｽﾎﾟｲﾝﾀｰを元に戻す
                                                Cursor.Current = Cursors.Default
                                                
                                                '@ｺﾝﾄﾛｰﾙを解放し、処理終了
                                                vsfControl = Nothing
                                                Exit Sub
                                            End If
                                            
                                            '@起動中ﾌﾟﾛｸﾞﾗﾑ(ﾒﾆｭｰｷｰ：機能ID)を退避
                                            lstrFromMenuKey = pstrExecuteMenuKey
                                            
                                            '@呼び元ﾒﾆｭｰｷｰを格納
                                            ltypCommonInfo.strFromMenuKey = lstrFromMenuKey
                                            
                                            '@=======================
                                            '@　起動中ﾌﾟﾛｸﾞﾗﾑ終了処理
                                            '@=======================
                                            llngRet = prvlngPrgAllEnd_Proc(ltypCommonInfo, , lstrMenuKey)
                
                                            '@ｷｬﾘｱID引継ぎﾌﾗｸﾞが"1：ｷｬﾘｱIDを引き継ぐ"か
                                            If plngCarrTakeOver = CPlngMenuCarrTakeOverOn Then
                                            
                                                '@ｷｬﾘｱID引継ぎﾌﾗｸﾞが"0：ｷｬﾘｱIDを引き継ぎ不可"か
                                                If plngTakingOverFlag = CPlngMenuCarrTakeOverDisable Then
                
                                                    '@引継ぎ情報構造体を初期化する
                                                    With ltypCommonInfo
                                                        .strCarrierId = vbNullString
                                                        .strDivision = vbNullString
                                                        .strLotID = vbNullString
                                                        .strOpID = vbNullString
                                                        .strStepID = vbNullString
                                                        .strWpID = vbNullString
                                                        .strWpName = vbNullString
                                                        .strToCarrierId = vbNullString
                                                    End With
                                                End If
                                            Else
                                                '@ｷｬﾘｱID引継ぎﾌﾗｸﾞが"1：ｷｬﾘｱIDを引き継ぐ"以外の場合
                                                '@　※EN0150等への戻りの場合のみ例外判定
                                                
                                                '@=======================
                                                '@　機能毎関連情報取得処理
                                                '@=======================
                                                Call pubMenuItemCorrelation_Set(lstrFromMenuKey, lstrTitle, llngCarrTakeOver)
                                                
                                                '@★ 取得したｷｬﾘｱID引継ぎﾌﾗｸﾞにより処理分岐 ★
                                                Select Case llngCarrTakeOver
                                                
                                                    '@〓 1：次機能へ引継ぎあり、前機能から引継ぎなし or
                                                    '@　 3：次機能へ引継ぎあり、前機能から引継ぎあり 〓
                                                    Case CPlngMenuCarrTakeOver1, CPlngMenuCarrTakeOver3

                                                        '@=======================
                                                        '@　機能毎関連情報取得処理
                                                        '@=======================
                                                        Call pubMenuItemCorrelation_Set(lstrMenuKey, lstrTitle, llngCarrTakeOver)
                                                        
                                                        '@★★ 取得したｷｬﾘｱID引継ぎﾌﾗｸﾞにより処理分岐 ★★
                                                        Select Case llngCarrTakeOver
                                                            
                                                            '@〓 2：次機能へ引継ぎなし、前機能から引継ぎあり 〓
                                                            Case CPlngMenuCarrTakeOver2

                                                                '@起動中ﾌﾟﾛｸﾞﾗﾑのﾒﾆｭｰｷｰ(機能ID)が"EN0060：作業終了"で、
                                                                '@かつ特殊流動以外が選択されている場合
                                                                If lstrFromMenuKey = CPstrKeyEN0060 And _
                                                                   lstrMenuKey <> CPstrKeyEN00Y0 Then
                                                                   
                                                                    '@引継ぎ情報構造体を初期化する
                                                                    With ltypCommonInfo
                                                                        .strCarrierId = vbNullString
                                                                        .strDivision = vbNullString
                                                                        .strLotID = vbNullString
                                                                        .strOpID = vbNullString
                                                                        .strStepID = vbNullString
                                                                        .strWpID = vbNullString
                                                                        .strWpName = vbNullString
                                                                        .strToCarrierId = vbNullString
                                                                    End With
                                                                End If
                                                            
                                                            
                                                            '@〓 3：次機能へ引継ぎあり、前機能から引継ぎあり 〓
                                                            Case CPlngMenuCarrTakeOver3

                                                                '@引継ぎ構造体を初期化しない
                                                            
                                                            
                                                            '@〓 その他 〓
                                                            Case Else

                                                                '@引継ぎ情報構造体を初期化する
                                                                With ltypCommonInfo
                                                                    .strCarrierId = vbNullString
                                                                    .strDivision = vbNullString
                                                                    .strLotID = vbNullString
                                                                    .strOpID = vbNullString
                                                                    .strStepID = vbNullString
                                                                    .strWpID = vbNullString
                                                                    .strWpName = vbNullString
                                                                    .strToCarrierId = vbNullString
                                                                End With
                                                        End Select
                                                    
                                                    
                                                    '@〓 その他 〓
                                                    Case Else
                                                        
                                                        '@***********************
                                                        '@　例外処理の判定
                                                        '@***********************
                                                        '@作業終了→特殊流動(ﾘﾜｰｸ・追加・先行)の場合は例外処理
                                                        If lstrFromMenuKey = CPstrKeyEN0060 And _
                                                            lstrMenuKey = CPstrKeyEN00Y0 Then
                                                            '@作業終了→特殊流動の場合
                                                            
                                                            '@引継ぎ情報構造体を初期化しない
                                                        Else
                                                            '@作業終了→特殊流動以外の場合
                                                            
                                                            '@引継ぎ情報構造体を初期化する
                                                            With ltypCommonInfo
                                                                .strCarrierId = vbNullString
                                                                .strDivision = vbNullString
                                                                .strLotID = vbNullString
                                                                .strOpID = vbNullString
                                                                .strStepID = vbNullString
                                                                .strWpID = vbNullString
                                                                .strWpName = vbNullString
                                                                .strToCarrierId = vbNullString
                                                            End With
                                                        End If
                                                End Select
                                            End If
                                        End If
                                End Select
                        End Select
                    End If
                    
                    
                    '@★ 選択行のﾒﾆｭｰｷｰ(機能ID)により処理分岐 ★
                    Select Case lstrMenuKey
                    
                        '@〓 NULL 〓
                        Case vbNullString

                            '@空白行の場合、ｷｬﾘｱID引継ぎﾌﾗｸﾞに"0：ｷｬﾘｱIDを引き継がない"をｾｯﾄ
                            plngCarrTakeOver = CPlngMenuCarrTakeOverOff
                         
                         
                        '@〓 WEB,EXE系(機能ID：WB****,EX****) 〓
                        Case CPstrMenuKeyWebLower To CPstrMenuKeyWebUpper, _
                                CPstrMenuKeyExecuteLower To CPstrMenuKeyExecuteUpper
                            
                            '@=======================
                            '@　ﾌﾟﾛｸﾞﾗﾑ起動処理
                            '@=======================
                            llngRet = prvlngPrgStart_Proc(vsfControl, ltypCommonInfo)
                        
                        
                        '@〓 工程管理系(機能ID：EN****) 〓
                        Case Else

                            '@★★ ｷｬﾘｱID引継ぎﾌﾗｸﾞにより処理分岐 ★★
                            Select Case .GetData(.Row, CPlngMenuCarrTakeOver)
                            
                                '@〓 1：次機能へ引継ぎあり、前機能から引継ぎなし or
                                '@　 3：次機能へ引継ぎあり、前機能から引継ぎあり 〓
                                Case CPlngMenuCarrTakeOver1, CPlngMenuCarrTakeOver3
                                    
                                    '@ｷｬﾘｱID引継ぎﾌﾗｸﾞに"1：ｷｬﾘｱIDを引き継ぐ"をｾｯﾄ
                                    plngCarrTakeOver = CPlngMenuCarrTakeOverOn
                                    
                                    
                                '@〓 その他(0、2、5、6) 〓
                                Case Else

                                    '@ｷｬﾘｱID引継ぎﾌﾗｸﾞに"0：ｷｬﾘｱIDを引き継ぐ"をｾｯﾄ
                                    plngCarrTakeOver = CPlngMenuCarrTakeOverOff
                            End Select
                            
                            '@***********************
                            '@　各ｸﾞﾘｯﾄﾞの起動中ﾌﾗｸﾞをｸﾘｱ
                            '@***********************
                            '@流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ
                            For llngCnt = vsfFlow.Rows.Fixed To vsfFlow.Rows.Count - 1
                            
                                '@起動中ﾌﾗｸﾞに"0：停止中"をｾｯﾄする
                                vsfFlow.SetData(llngCnt, CPlngMenuExecuteCol, CPlngMenuSuspendFlg)
                            Next llngCnt
                            
                            '@ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ
                            For llngCnt = vsfTool.Rows.Fixed To vsfTool.Rows.Count - 1
                            
                                '@起動中ﾌﾗｸﾞに"0：停止中"をｾｯﾄする
                                vsfTool.SetData(llngCnt, CPlngMenuExecuteCol, CPlngMenuSuspendFlg)
                            Next llngCnt
                            
                            '@お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ
                            For llngCnt = vsfFavorites.Rows.Fixed To vsfFavorites.Rows.Count - 1
                            
                                '@起動中ﾌﾗｸﾞに"0：停止中"をｾｯﾄする
                                vsfFavorites.SetData(llngCnt, CPlngMenuExecuteCol, CPlngMenuSuspendFlg)
                            Next llngCnt
                            
                            '@選択行の起動中ﾌﾗｸﾞ列に"1：起動中"をｾｯﾄ
                            .SetData(.Row, CPlngMenuExecuteCol, CPlngMenuExecuteFlg)
                            
                            '@=======================
                            '@　ﾌﾟﾛｸﾞﾗﾑ起動処理
                            '@=======================
                            llngRet = prvlngPrgStart_Proc(vsfControl, ltypCommonInfo)

                    End Select
                End If
            End With
            
            '@★ 選択ｸﾞﾘｯﾄﾞにより処理分岐 ★
            Select Case vsfControl.Name
            
                '@〓 流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ 〓
                Case vsfFlow.Name
                    
                    '@=======================
                    '@　流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ用の上下ｽｸﾛｰﾙﾎﾞﾀﾝを制御
                    '@=======================
                    Call pubVsfDisp(vsfControl, cmdFlowUp, cmdFlowDown)
                    
                    
                '@〓 ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ 〓
                Case vsfTool.Name
                
                    '@=======================
                    '@　ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ用の上下ｽｸﾛｰﾙﾎﾞﾀﾝを制御
                    '@=======================
                    Call pubVsfDisp(vsfControl, cmdToolUp, cmdToolDown)
                    
                    
                '@〓 お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ 〓
                Case vsfFavorites.Name
                
                    '@=======================
                    '@　お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞ用の上下ｽｸﾛｰﾙﾎﾞﾀﾝを制御
                    '@=======================
                    Call pubVsfDisp(vsfControl, cmdFavoritesUp, cmdFavoritesDown)

            End Select

            '@ﾏｳｽﾎﾟｲﾝﾀｰを元に戻す
            Cursor.Current = Cursors.Default
            
            '@ｺﾝﾄﾛｰﾙを解放する
            vsfControl = Nothing
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvPrgSwitch_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvlngPrgAllEnd_Proc
    '機　能：起動中ﾌﾟﾛｸﾞﾗﾑ終了処理(全ﾌﾟﾛｸﾞﾗﾑ対応)
    '引　数：ltypCommonInfo         ：引継ぎ情報構造体
    '　　　：lblnUnConditionalEnd   ：無条件終了ﾌﾗｸﾞ(False：起動中ﾌﾗｸﾞがONのﾌﾟﾛｸﾞﾗﾑを終了、True：開いているﾌｫｰﾑを全て終了)
    '　　　：lstrNextMenuKey        ：次起動機能ID
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 16:56:54 H.Wajima
    '更新日：2008/06/25 (Wed) 09:17:41 N.Kojima
    '備　考：ｷｬﾘｱID以外も引継ぎ情報として構造体に入れて渡す
    '　　　：2005/01/06 (Thu) 15:00:46 H.Wajima     次起動機能IDの判定を追加
    '　　　：2008/06/25 (Wed) 09:17:41 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Function prvlngPrgAllEnd_Proc(ByRef ltypCommonInfo As CommonInfo, _
                                          Optional ByVal lblnUnConditionalEnd As Boolean = False, _
                                          Optional ByVal lstrNextMenuKey As String = vbNullString) As Integer

        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim llngRet                 As Integer      '戻り値格納用
        Dim lctlControl             As Control      'ｺﾝﾄﾛｰﾙ名格納用
        Dim lstrMenuKey             As String       'ﾒﾆｭｰｷｰ(機能ID)
        Dim lstrDummy               As String       'ﾀﾞﾐｰ(String)
        Dim ltypDummy               As CommonInfo   'ﾀﾞﾐｰ(構造体)
        Dim llngDummy               As Integer      'ﾀﾞﾐｰ(Long)
        Dim lstrFormName            As String       'ﾌｫｰﾑ名
        Dim frmOpenFrom             As Form

        Try
            
            '@frmxxMN0000上のｺﾝﾄﾛｰﾙを検索
            Dim all As Control() = GetAllControls(Me)
            For Each lctlControl In all
            
                '@ｺﾝﾄﾛｰﾙがｸﾞﾘｯﾄﾞか(流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ、ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ、お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞの3つがﾋｯﾄするはず)
                If TypeOf lctlControl Is C1FlexGrid Then

                    With CType(lctlControl, C1FlexGrid)

                        '@無条件終了ﾌﾗｸﾞが"False：起動中ﾌﾗｸﾞONのﾌﾟﾛｸﾞﾗﾑを終了"か
                        If lblnUnConditionalEnd = False Then
                            
                            '@***********************
                            '@　現在起動中のﾌﾟﾛｸﾞﾗﾑを終了する
                            '@***********************

                            '@現在起動中のﾌﾟﾛｸﾞﾗﾑを検索
                            For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            
                                '@起動中ﾌﾗｸﾞが"1：起動中"か
                                If .GetData(llngCnt, CPlngMenuExecuteCol) = CPlngMenuExecuteFlg Then
                                    
                                    '@=======================
                                    '@　ﾌﾟﾛｸﾞﾗﾑ名指定終了処理
                                    '@=======================
                                    llngRet = publngEnd_Proc(.GetData(llngCnt, CPlngMenuKeyCol), ltypCommonInfo, lstrNextMenuKey)
                                    
                                    '@ﾌﾟﾛｸﾞﾗﾑ名指定終了処理結果判定
                                    If llngRet = CPlngErrorStatusCD Then
                                        '@ﾌﾟﾛｸﾞﾗﾑ名指定終了処理結果：異常(失敗)の場合
                                        
                                        '@ｺﾝﾄﾛｰﾙを解放し、処理終了
                                        lctlControl = Nothing
                                        Exit Function
                                    End If
                                End If
                            Next llngCnt

                            For llngCnt = .Rows.Fixed To .Rows.Count - 1
                                '@起動中ﾌﾗｸﾞを初期化する
                                .SetData(llngCnt, CPlngMenuExecuteCol, CPlngMenuSuspendFlg)
                            Next llngCnt
                        Else
                            '@無条件終了ﾌﾗｸﾞが"True：起動中ﾌﾟﾛｸﾞﾗﾑを全て終了"の場合
                            
                            For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            
                                '@ﾒﾆｭｰｷｰ(機能ID)を変数に格納する
                                lstrMenuKey = .GetData(llngCnt, CPlngMenuKeyCol)
                                
                                '@★ ﾒﾆｭｰｷｰ(機能ID)により処理分岐 ★
                                Select Case lstrMenuKey
                                
        '@↓2004/08/25 (Wed) 20:22:08 H.Wajima **************************************************
        '@別のﾂｰﾙを起動したときにIEを終了さｾﾙ場合は復活
        '                            Case CPstrMenuKeyWebLower To CPstrMenuKeyWebUpper
        '                                '@WEBﾂｰﾙの場合
        '                                If IsWindow(plngInetExphWnd) Then
        '                                    '@IEが表示されている場合
        '                                    '@IEを非表示にする
        '                                    pobjInetExp.Visible = False
        '                                    pobjInetExp.Quit
        '                                End If
        '                                '@ｳｨﾝﾄﾞｳﾊﾝﾄﾞﾙを初期化する
        '                                plngInetExphWnd = 0
        '                                '@IEのｵﾌﾞｼﾞｪｸﾄを解放する
        '                                Set pobjInetExp = Nothing
        '@↑2004/08/25 (Wed) 20:22:08 H.Wajima **************************************************
                                    
                                    '@〓 工程管理機能、WEB、EXE　共通 〓
                                    Case Else
                                    
                                        '@=======================
                                        '@　機能毎関連情報取得処理
                                        '@=======================
                                        Call pubMenuItemCorrelation_Set(lstrMenuKey, lstrDummy, llngDummy, lstrFormName)
                                        
                                        '@ﾛｰﾄﾞ中のﾌｫｰﾑ分(Forms.Count)、該当するﾌｫｰﾑがあるか検索
                                        For Each frmOpenFrom In Application.OpenForms
                                        
                                            '@ﾛｰﾄﾞ中のﾌｫｰﾑ名とｸﾞﾘｯﾄﾞのﾌｫｰﾑ名が同じか
                                            If frmOpenFrom.Name = lstrFormName Then
                                                
                                                '@=======================
                                                '@　ﾌﾟﾛｸﾞﾗﾑ名指定終了処理
                                                '@=======================
                                                llngRet = publngEnd_Proc(lstrMenuKey, ltypDummy, lstrNextMenuKey)
                                                
                                                '@ﾙｰﾌﾟ処理終了
                                                Exit For
                                            End If
                                        Next
                                End Select
                            Next llngCnt
                            
                            '@=======================
                            '@　ﾌﾟﾛｸﾞﾗﾑ名指定終了処理
                            '@=======================
                            llngRet = publngEnd_Proc(CPstrMenuKeyMMenu, ltypCommonInfo, lstrNextMenuKey)
                        End If
                    End With
                End If
            Next
            
            '@起動中ﾌﾟﾛｸﾞﾗﾑ名退避変数を初期化する
            pstrExecuteMenuKey = vbNullString           '工程管理ﾒﾆｭｰｷｰ(機能ID)退避用変数
            pstrExecuteWebMenuKey = vbNullString        'WEBﾒﾆｭｰｷｰ(機能ID)退避用変数
            pstrExecuteExeMenuKey = vbNullString        'EXEﾒﾆｭｰｷｰ(機能ID)退避用変数

            '@ｺﾝﾄﾛｰﾙを解放する
            lctlControl = Nothing

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvlngPrgAllEnd_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnMenuItem_Set
    '機　能：MenuItem配列ﾒﾆｭｰ項目設定処理
    '引　数：なし
    '戻り値：True:正常終了、False:異常終了
    '作成日：2004/04/23 (Fri) 16:16:29 H.Wajima
    '更新日：2008/06/23 (Mon) 14:33:00 N.Kojima
    '備　考：
    '　　　：2008/06/23 (Mon) 14:33:00 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Function prvblnMenuItem_Set() As Boolean

        Dim llngFlowCount       As Integer  '流動系ﾒﾆｭｰ件数格納用
        Dim llngToolCount       As Integer  'ﾂｰﾙ系ﾒﾆｭｰ件数格納用
        Dim llngFavoritesCount  As Integer  'お気に入りﾒﾆｭｰ件数格納用

        Try
            
            '@戻り値に"False：初期値"をｾｯﾄ
            prvblnMenuItem_Set = False
            
            '@=======================
            '@　流動系ﾀﾌﾞのﾒﾆｭｰ情報設定処理
            '@=======================
            Call prvMenuItem_Get(CPlngMenuTabFlow, llngFlowCount)
            
            '@=======================
            '@　ﾂｰﾙ系ﾀﾌﾞのﾒﾆｭｰ情報設定処理
            '@=======================
            Call prvMenuItem_Get(CPlngMenuTabTool, llngToolCount)
            
            '@=======================
            '@　お気に入りﾀﾌﾞのﾒﾆｭｰ情報設定処理
            '@=======================
            Call prvMenuItem_Get(CPlngMenuTabFavorites, llngFavoritesCount)
            
            '@流動系ﾒﾆｭｰ数＋ﾂｰﾙ系ﾒﾆｭｰ数＋お気に入りﾒﾆｭｰ数が"0"か
            If llngFlowCount + llngToolCount + llngFavoritesCount = 0 Then
            
                '@処理終了
                Exit Function
            End If
            
            '@=======================
            '@　無効機能のﾁｪｯｸ処理
            '@=======================
            Call prvDeleteMenuItem_Chk()
            
            '@戻り値に"True：ﾒﾆｭｰ項目設定成功"をｾｯﾄ
            prvblnMenuItem_Set = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnMenuItem_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvMenuItem_Get
    '機　能：お気に入りを配列に格納する
    '引　数：llngTab        ：ﾀﾌﾞ(0:流動系、1:ﾂｰﾙ系、3:お気に入り)
    '　　　：llngListCount  ：取得件数
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:57:43 H.Wajima
    '更新日：2008/06/25 (Wed) 09:29:24 N.Kojima
    '備　考：
    '　　　：2004/11/04 (Thu) 09:44:54 M.Miura      引継ぎﾁｪｯｸﾎﾞｯｸｽを変数に変更(お気に入り登録画面に移動の為)(不具合№190)
    '　　　：2008/02/25 (Mon) 16:41:20 M.Koni       Environ関数の型変換対応。(不具合No.02510)
    '　　　：2008/06/25 (Wed) 09:29:24 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub prvMenuItem_Get(ByVal llngTab As Integer, ByRef llngListCount As Integer)
        
        Dim llngCnt                     As Integer          '汎用ｶｳﾝﾀ
        Dim llngCarrTakeOver            As Integer          'ｷｬﾘｱID引継ぎﾌﾗｸﾞ
        Dim llngSeqNum                  As Integer          '順番
        Dim llngArrayStartPos           As Integer          '配列開始位置
        Dim llngUBound                  As Integer          '配列数領域
        Dim llngFavoriteListCount       As Integer          'お気に入り件数
        Dim ltyprefmenu_                As refmenu_         'お気に入りﾘｽﾄ
        Dim lstrTitle                   As String           'ﾀｲﾄﾙ
        Dim lstrLoginID                 As String           'ﾛｸﾞｲﾝﾕｰｻﾞｰ名
        Dim lstrMenuKind                As String           'ﾒﾆｭｰ種別
        Dim lblnAns                     As Boolean          '戻り値格納領域

        Try
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvMenuFavoritesGet)
            
            '@★ 引数で渡されたﾀﾌﾞにより処理分岐 ★
            Select Case llngTab
                
                '@〓 0：流動系ﾀﾌﾞ 〓
                Case CPlngMenuTabFlow

                    '@ﾛｸﾞｲﾝﾕｰｻﾞｰ名に流動系定数("MENUFLOW")を設定する
                    lstrLoginID = CMstrMenuIdFlow
                
                '@〓 1：ﾂｰﾙ系ﾀﾌﾞ 〓
                Case CPlngMenuTabTool

                    '@ﾛｸﾞｲﾝIDにﾂｰﾙ系定数("MENUTOOL")を設定する
                    lstrLoginID = CMstrMenuIdTool
                
                '@〓 2：お気に入りﾀﾌﾞ 〓
                Case CPlngMenuTabFavorites
                    
                    '@=======================
                    '@　ﾛｸﾞｲﾝﾕｰｻﾞｰ名を取得処理
                    '@=======================
                    lstrLoginID = StrConv(Environ(CPstrEnvironUserName), vbLowerCase + vbNarrow)
            
            End Select
            
            '@ﾒﾆｭｰ種別(ｼｽﾃﾑﾌﾞﾛｯｸID+端末区分("M"or"S"or"A"))
            lstrMenuKind = pstrSBID & CPstrMenuKindSeparator & pstrTerminalMode
            
            '@【お気に入り取得】ﾒｯｾｰｼﾞ送受信処理
            ltyprefmenu_ = New refmenu_
            If ltyprefmenu_.typFavoriteList Is Nothing
                ltyprefmenu_.typFavoriteList = New List(Of FavoriteList)
            End If
            lblnAns = pubblnUtilRefMenuFavor_Sel(CMstrutilrefmenu_Ver, _
                                                 lstrLoginID, _
                                                 lstrMenuKind, _
                                                 llngFavoriteListCount, _
                                                 ltyprefmenu_)
            
            '@お気に入り取得結果判定
            If lblnAns = True Then
                '@お気に入り取得結果：正常の場合
                
                '@取得件数を退避
                llngListCount = llngFavoriteListCount
            
                '@お気に入りﾃﾞｰﾀが0件か
                If llngFavoriteListCount = 0 Then
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call publngResponseEnd(CMstrFormName, CMstrPrvMenuFavoritesGet)
                    
                    '@配列を解放し、処理終了
                    ltyprefmenu_.typFavoriteList.Clear()
                    Exit Sub
                End If
                
                '@お気に入りﾀﾌﾞが選択されているか
                If llngTab = CPlngMenuTabFavorites Then

                    '@ｷｬﾘｱID引継ぎﾌﾗｸﾞに固定で"1：ｷｬﾘｱIDを引き継ぐ"をｾｯﾄ
                    plngTakingOverFlag = CPlngMenuCarrTakeOverOn
                End If
                        
                '@★ 引数で渡されたﾀﾌﾞにより処理分岐 ★
                If mtypMenuItem Is Nothing
                    mtypMenuItem = New List(Of MenuItem)
                End If
                Select Case llngTab
                
                    '@〓 0：流動系ﾀﾌﾞ 〓
                    Case CPlngMenuTabFlow
                    
                        llngUBound = 0
                        '@配列領域の確保
                        For i As Integer = 0 To llngFavoriteListCount - 1
                            mtypMenuItem.Add(New MenuItem)
                        Next
                    
                    '@〓 1：ﾂｰﾙ系ﾀﾌﾞ or 2：お気に入りﾀﾌﾞ 〓
                    Case Else

                        llngUBound = mtypMenuItem.Count
                        '@配列数を拡張する
                        For i As Integer = 0 To llngFavoriteListCount - 1
                            mtypMenuItem.Add(New MenuItem)
                        Next
                End Select
                
                '@配列の開始位置に拡張前の配列配列数を設定する
                llngArrayStartPos = llngUBound
                
                '@取得したﾒﾆｭｰ項目情報を配列に格納する
                For llngCnt = 0 To llngFavoriteListCount - 1
                
                    With ltyprefmenu_.typFavoriteList(llngCnt)
                        
                        '@連番が数値ではない場合は抜ける
                        If IsNumeric(.strSeqNum) = False Then
                            Exit For
                        End If
                        
                        '@連番を格納する
                        llngSeqNum = .strSeqNum
                        
                        '@=======================
                        '@　機能毎関連情報取得処理　※機能名(ﾒﾆｭｰｷｰ)からﾒﾆｭｰ名、ｷｬﾘｱID引継ぎﾌﾗｸﾞを取得
                        '@=======================
                        Call pubMenuItemCorrelation_Set(.strFunctionID, lstrTitle, llngCarrTakeOver)

                        Dim mtypMenuItemTmp As MenuItem = mtypMenuItem(llngArrayStartPos + llngSeqNum)
                        mtypMenuItemTmp.strKey = .strFunctionID                'ﾒﾆｭｰｷｰ(機能ID)
                        mtypMenuItemTmp.strTitle = lstrTitle                   'ﾒﾆｭｰ名(機能名)
                        mtypMenuItemTmp.lngCarrTakeOver = llngCarrTakeOver     'ｷｬﾘｱID引継ぎﾌﾗｸﾞ
                        mtypMenuItemTmp.lngTab = llngTab                       'ﾀﾌﾞ
                        mtypMenuItem(llngArrayStartPos + llngSeqNum) = mtypMenuItemTmp
                    End With
                Next llngCnt
            Else
                '@お気に入り取得結果：異常(失敗)の場合
                
                '@ｷｬﾘｱID引継ぎ状態に初期値を設定する
                plngTakingOverFlag = CPlngMenuCarrTakeOverOn
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvMenuFavoritesGet)
                
                '@配列を解放し、処理終了
                ltyprefmenu_.typFavoriteList.Clear()
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrPrvMenuFavoritesGet)
            
            '@配列を解放する
            ltyprefmenu_.typFavoriteList.Clear()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMenuItem_Get"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMenuGrid_Edit
    '機　能：ﾒﾆｭｰのｸﾞﾘｯﾄﾞに、MenuItem配列の値を設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/23 (Fri) 16:16:54 H.Wajima
    '更新日：2008/06/25 (Wed) 11:24:27 N.Kojima
    '備　考：
    '　　　：2004/09/24 (Fri) 16:43:50 H.Wajima     ﾒﾆｭｰ画面の項目数が1ﾍﾟｰｼﾞの行数の倍数でない場合、1ﾍﾟｰｼﾞの倍数になるまで
    '　　　：                                       空白行で埋めるように変更。(№828)
    '　　　：2008/06/25 (Wed) 11:24:27 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub prvMenuGrid_Edit(ByVal lfrmForm As Form)
        
        Dim lctlControl         As Control      'ｺﾝﾄﾛｰﾙ
        Dim llngMenuCnt         As Integer      'ﾒﾆｭｰ件数ｶｳﾝﾀ
        Dim llngRowCnt          As Integer      'ｸﾞﾘｯﾄﾞの行ｶｳﾝﾀ
        Dim llngTabNo           As Integer      'ﾀﾌﾞ番号
        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ

        Try
            
            '@frmxxMN0000上のｺﾝﾄﾛｰﾙを検索
            Dim all As Control() = GetAllControls(lfrmForm)
            For Each lctlControl In all
                
                '@ｺﾝﾄﾛｰﾙがｸﾞﾘｯﾄﾞか(流動系ﾒﾆｭｰｸﾞﾘｯﾄﾞ、ﾂｰﾙ系ﾒﾆｭｰｸﾞﾘｯﾄﾞ、お気に入りﾒﾆｭｰｸﾞﾘｯﾄﾞの3つがﾋｯﾄするはず)
                If TypeOf lctlControl Is C1FlexGrid Then
                
                    '@★ ﾒﾆｭｰｸﾞﾘｯﾄﾞにより処理分岐 ★
                    Select Case lctlControl.Name
                    
                        '@〓 0：流動系ﾀﾌﾞ 〓
                        Case vsfFlow.Name

                            '@流動系のﾀﾌﾞ番号を使用する
                            llngTabNo = CPlngMenuTabFlow
                            
                        '@〓 1：ﾂｰﾙ系ﾀﾌﾞ 〓
                        Case vsfTool.Name

                            '@ﾂｰﾙ系のﾀﾌﾞ番号を使用する
                            llngTabNo = CPlngMenuTabTool
                            
                        '@〓 2：お気に入りﾀﾌﾞ 〓
                        Case vsfFavorites.Name

                            '@お気に入りのﾀﾌﾞ番号を使用する
                            llngTabNo = CPlngMenuTabFavorites
                    End Select
                    
                    '@ﾒﾆｭｰ件数ｶｳﾝﾀの初期化
                    llngMenuCnt = 0
                    
                    '@配列の件数分処理をﾙｰﾌﾟ
                    For llngCnt = 0 To mtypMenuItem.Count - 1
                    
                        '@配列のﾀﾌﾞ番号との上記で格納したﾒﾆｭｰｸﾞﾘｯﾄﾞのﾀﾌﾞ番号が同じか
                        If mtypMenuItem(llngCnt).lngTab = llngTabNo Then

                            '@ﾒﾆｭｰ件数ｶｳﾝﾀを+1する
                            llngMenuCnt = llngMenuCnt + 1
                        End If
                    Next llngCnt
                    
                    '@***********************
                    '@　行数設定
                    '@***********************
                    With CType(lctlControl, C1FlexGrid)
                        .Redraw = False
                        
                        '@ﾒﾆｭｰ件数がと1ﾍﾟｰｼﾞの最大行数より少ないか
                        If llngMenuCnt < CPlngMenuGridPageRows Then
                            '@ﾒﾆｭｰ件数が1ﾍﾟｰｼﾞの最大行数より少ない場合
                            
                            '@ｸﾞﾘｯﾄﾞの行数を1ﾍﾟｰｼﾞの最大行数に設定する
                            .Rows.Count = CPlngMenuGridPageRows
                        Else
                            '@ﾒﾆｭｰ件数が1ﾍﾟｰｼﾞの最大行数よりも多い場合
                            
                            '@1ﾍﾟｰｼﾞの最大行数がﾒﾆｭｰ件数で割り切れるか
                            If llngMenuCnt Mod CPlngMenuGridPageRows = 0 Then
                                '@割り切れる場合
                                
                                '@ｸﾞﾘｯﾄﾞの行数を、ﾒﾆｭｰ件数に設定する
                                .Rows.Count = llngMenuCnt
                            Else
                                '@余りがある場合
                                
                                '@末尾の行に空白行を追加し、1ﾍﾟｰｼﾞの最大行数の倍数になるようにする
                                .Rows.Count = (llngMenuCnt \ CPlngMenuGridPageRows + 1) * CPlngMenuGridPageRows
                            End If
                        End If
                        
                        '@行の高さ設定
                        .Rows.DefaultSize = CPlngMenuGridRowHeight
                        
                        '@ｸﾞﾘｯﾄﾞの行ｶｳﾝﾀを初期化
                        llngRowCnt = 0
                        
                        '@***********************
                        '@　配列からｸﾞﾘｯﾄﾞにﾒﾆｭｰ項目を格納する
                        '@***********************
                        For llngCnt = 0 To mtypMenuItem.Count - 1
                        
                            '@配列のﾀﾌﾞ番号との上記で格納したﾒﾆｭｰｸﾞﾘｯﾄﾞのﾀﾌﾞ番号が同じか
                            If mtypMenuItem(llngCnt).lngTab = llngTabNo Then

                                '@ﾒﾆｭｰｷｰ(機能ID)
                                .SetData(llngRowCnt, CPlngMenuKeyCol, mtypMenuItem(llngCnt).strKey)
                                '@ﾒﾆｭｰ名(機能名)
                                .SetData(llngRowCnt, CPlngMenuTitleCol, mtypMenuItem(llngCnt).strTitle)
                                '@起動中ﾌﾗｸﾞ
                                .SetData(llngRowCnt, CPlngMenuExecuteCol, CPlngMenuSuspendFlg)
                                '@ｷｬﾘｱID引継ぎﾌﾗｸﾞ
                                .SetData(llngRowCnt, CPlngMenuCarrTakeOver, mtypMenuItem(llngCnt).lngCarrTakeOver)
                                
                                '@ｶｳﾝﾀを+1する
                                llngRowCnt = llngRowCnt + 1
                            End If
                        Next llngCnt
                        
                        '@ﾌｫｰﾑがお気に入り登録画面か
                        If lfrmForm.Name = CMstrfrmxxMN0001 Then

                            For llngCnt = 0 To .Rows.Count - 1
                            
                                '@ﾒﾆｭｰｷｰ(機能ID)が"SPACE"か
                                If .GetData(llngCnt, CPlngMenuKeyCol) = CPstrMenuKeySpace Then

                                    '@ﾒﾆｭｰのﾀｲﾄﾙに空白行が判別できる文字(〓〓〓空白行〓〓〓)を挿入する
                                    .SetData(llngCnt, CPlngMenuTitleCol, CPlngFavoritesEditCaptionSpace)
                                End If
                            Next llngCnt
                        End If
                        .Redraw = True
                    End With
                End If
            Next
            
            '@ｺﾝﾄﾛｰﾙを解放する
            lctlControl = Nothing
            lfrmForm = Nothing
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMenuGrid_Edit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvDeleteMenuItem_Chk
    '機　能：削除ﾒﾆｭｰ項目ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/30 (Fri) 18:43:54 H.Wajima
    '更新日：2008/06/25 (Wed) 16:20:03 N.Kojima
    '備　考：
    '　　　：2008/06/25 (Wed) 16:20:03 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub prvDeleteMenuItem_Chk()
        
        Dim llngCnt                     As Integer      '汎用ｶｳﾝﾀ
        Dim llngCnt2                    As Integer      '汎用ｶｳﾝﾀ2
        Dim llngCarrTakeOver            As Integer      '引継ぎﾌﾗｸﾞ(1：ｷｬﾘｱID引継ぎあり、0：ｷｬﾘｱID引継ぎなし)
        Dim lstrTitle                   As String       '機能名格納用
        Dim lstrEnableFlag              As String       '有効ﾌﾗｸﾞ(1：有効、0：無効)
        Dim lblnCompareFlg              As Boolean      '照合ﾌﾗｸﾞ(True：同じ、False：異なる)

        Try
            
            '@***********************
            '@　廃止機能対応
            '@***********************
            
            '@配列の件数分処理をﾙｰﾌﾟ
            For llngCnt = 0 To mtypMenuItem.Count - 1
                
                '@=======================
                '@　機能毎関連情報取得処理
                '@=======================
                Call pubMenuItemCorrelation_Set(mtypMenuItem(llngCnt).strKey, lstrTitle, , , lstrEnableFlag)
                
                '@有効/無効ﾌﾗｸﾞが"False：無効"か(無効機能か)
                If lstrEnableFlag = CPstrEnableFlagFalse Then

                    '@=======================
                    '@　機能毎関連情報取得処理
                    '@=======================
                    Call pubMenuItemCorrelation_Set(CPstrMenuKeySpace, lstrTitle, llngCarrTakeOver)
                    
                    Dim mtypMenuItemTmp As MenuItem = mtypMenuItem(llngCnt)
                    With mtypMenuItemTmp
                        .strKey = CPstrMenuKeySpace             '"SPACE"
                        .lngCarrTakeOver = llngCarrTakeOver     'ｷｬﾘｱID引継ぎﾌﾗｸﾞ
                        .strTitle = lstrTitle                   '機能名
                    End With
                    mtypMenuItem(llngCnt) = mtypMenuItemTmp
                    
                    '@お気に入り編集ﾌﾗｸﾞに"True：編集あり"をｾｯﾄ
                    pblnFavoritesEdit = True
                End If
            Next llngCnt
            
            '@=======================
            '@　機能毎関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrMenuKeySpace, lstrTitle, llngCarrTakeOver)
            
            '@配列の件数分処理をﾙｰﾌﾟ
            For llngCnt = 0 To mtypMenuItem.Count - 1
                
                '@配列のﾀﾌﾞ情報が"2：お気に入り"か
                If mtypMenuItem(llngCnt).lngTab = CPlngMenuTabFavorites Then

                    '@照合ﾌﾗｸﾞを初期化する
                    lblnCompareFlg = False
                    
                    '@配列の件数分処理をﾙｰﾌﾟ
                    For llngCnt2 = 0 To mtypMenuItem.Count - 1
                    
                        '@配列のﾀﾌﾞ情報が"0：流動系ﾀﾌﾞ"or"1：ﾂｰﾙ系ﾀﾌﾞ"か
                        If mtypMenuItem(llngCnt2).lngTab = CPlngMenuTabFlow Or _
                            mtypMenuItem(llngCnt2).lngTab = CPlngMenuTabTool Then
                            
                            '@お気に入り配列のﾒﾆｭｰｷｰ(機能ID)と、流動系(ﾂｰﾙ系)配列のﾒﾆｭｰｷｰ(機能ID)が同じか
                            If mtypMenuItem(llngCnt).strKey = mtypMenuItem(llngCnt2).strKey Then

                                '@照合ﾌﾗｸﾞに"True：同じ"をｾｯﾄし、ﾙｰﾌﾟ処理終了
                                lblnCompareFlg = True
                                Exit For
                            End If
                        End If
                    Next llngCnt2
                    
                    '@照合ﾌﾗｸﾞが"False：異なる"か(お気に入りに存在するﾃﾞｰﾀが流動系・ﾂｰﾙ系に存在しない場合)
                    If lblnCompareFlg = False Then
                        
                        '@***********************
                        '@　お気に入りのﾃﾞｰﾀを空白行に置き換える
                        '@***********************
                        Dim mtypMenuItemTmp As MenuItem = mtypMenuItem(llngCnt)
                        With mtypMenuItemTmp
                            .strKey = CPstrMenuKeySpace             '"SPACE"をｾｯﾄ
                            .lngCarrTakeOver = llngCarrTakeOver     'ｷｬﾘｱID引継ぎﾌﾗｸﾞ
                            .strTitle = lstrTitle                   '機能名
                        End With
                        mtypMenuItem(llngCnt) = mtypMenuItemTmp
                        
                        '@お気に入り編集ﾌﾗｸﾞに"True：編集あり"をｾｯﾄ
                        pblnFavoritesEdit = True
                    End If
                End If
            Next llngCnt
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvDeleteMenuItem_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvRegMenu_Set
    '機　能：お気に入り登録処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/29 (Thu) 10:52:59 H.Wajima
    '更新日：2008/06/25 (Wed) 13:21:55 N.Kojima
    '備　考：
    '　　　：2004/11/04 (Thu) 10:06:52 M.Miura      引継ぎﾁｪｯｸﾎﾞｯｸｽを変数に変更(お気に入り登録画面に移動の為)(不具合№190)
    '　　　：2008/02/25 (Mon) 16:46:06 M.Koni       Environ関数の型変換対応。(不具合No.02510)
    '　　　：2008/06/25 (Wed) 13:21:55 N.Kojima     ｿｰｽ整備。(案件№03004)
    Private Sub prvRegMenu_Set()

        Dim ltypRegMenu_        As regmenu_     'ﾒﾆｭｰ登録構造体
        Dim lblnAns             As Boolean      '戻り値格納用
        Dim lstrLoginID         As String       'ﾛｸﾞｲﾝID
        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ
        Dim llngListCount       As Integer      'ﾒﾆｭｰ件数

        Try
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvRegMenuSet)
            
            '@=======================
            '@　お気に入りの行数計算処理
            '@=======================
            Call pubMenuFavoritesCount_proc(vsfFavorites, llngListCount)
            
            '@お気に入りが1件以上存在するか
            If llngListCount <> 0 Then
                
                '@配列領域の確保(件数分確保)
                ltypRegMenu_.typFavoriteList = New List(Of FavoriteList)(llngListCount)
            Else
                '@お気に入りが0件の場合
                
                '@配列領域の確保(1件分確保)
                ltypRegMenu_.typFavoriteList = New List(Of FavoriteList)(1)
                ltypRegMenu_.typFavoriteList.Add(New FavoriteList)
            End If
                
            '@***********************
            '@　送信ﾃﾞｰﾀ作成(0件時、該当件数あり時共通)
            '@***********************
            '@ﾛｸﾞｲﾝID名を取得する
            lstrLoginID = StrConv(Environ(CPstrEnvironUserName), vbLowerCase + vbNarrow)

            With ltypRegMenu_
            
                '@ﾛｸﾞｲﾝIDがNULL以外か
                If lstrLoginID <> vbNullString Then
                
                    '@Environで取得したﾛｸﾞｲﾝIDをｾｯﾄ
                    .strLogInID = lstrLoginID
                Else
                    '@NULLの場合
                
                    '@ﾛｸﾞｲﾝIDにNULLをｾｯﾄ
                    .strLogInID = vbNullString
                End If
                
                '@ﾒﾆｭｰ種別をｾｯﾄ(ｼｽﾃﾑﾌﾞﾛｯｸID；端末区分("M"、"S"、"A"))
                .strMenuKind = pstrSBID & CPstrMenuKindSeparator & pstrTerminalMode
                
                '@ｷｬﾘｱID引継ぎﾌﾗｸﾞに固定で"1：ｷｬﾘｱIDを引き継ぐ"をｾｯﾄ
                .strTakingOverFlag = CPlngMenuCarrTakeOverOn
            End With
                
                
            '@お気に入りが1件以上存在するか　※ここは該当件数がある場合と無い場合とで処理が異なる。
            If llngListCount <> 0 Then
            
                '@***********************
                '@　送信ﾃﾞｰﾀ作成(該当件数あり)
                '@***********************
                With vsfFavorites

                    For llngCnt = 0 To llngListCount - 1
                        ltypRegMenu_.typFavoriteList.Add(New FavoriteList)
                    
                        '@ﾒﾆｭｰｷｰ(機能ID)がNULL以外か
                        If .GetData(llngCnt, CPlngMenuKeyCol) <> vbNullString Then

                            Dim typFavoriteListTmp = New FavoriteList
                            With typFavoriteListTmp
                                
                                .strSeqNum = llngCnt                                                        '順番に行番号をｾｯﾄ
                                .strFunctionID = vsfFavorites.GetData(llngCnt, CPlngMenuKeyCol)    'ｸﾞﾘｯﾄﾞのﾒﾆｭｰｷｰ(機能ID)をｾｯﾄ
                            End With
                            ltypRegMenu_.typFavoriteList(llngCnt) = typFavoriteListTmp
                        Else
                            '@ﾒﾆｭｰｷｰ(機能ID)がNULLの場合
                            
                            '@ﾙｰﾌﾟ処理終了
                            Exit For
                        End If
                    Next llngCnt
                End With
                
            Else
                '@お気に入りが0件の場合

                '@***********************
                '@　送信ﾃﾞｰﾀ作成(0件)
                '@***********************
                Dim typFavoriteListTmp = New FavoriteList
                With typFavoriteListTmp
                    
                    .strSeqNum = vbNullString               '順番に行番号をｾｯﾄ
                    .strFunctionID = vbNullString           '機能名にｸﾞﾘｯﾄﾞのﾒﾆｭｰｷｰ(機能ID)をｾｯﾄ
                End With
                ltypRegMenu_.typFavoriteList(llngCnt) = typFavoriteListTmp
            End If
                
            '@=======================
            '@　お気に入り登録処理
            '@=======================
            lblnAns = pubblnUtilRegMenuFavor_Upd(CMstrutilregmenu_Ver, ltypRegMenu_)
                
            '@お気に入り登録処理結果判定
            If lblnAns = True Then
                '@お気に入り登録処理結果：正常の場合
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvRegMenuSet)
            Else
                '@お気に入り登録処理結果：異常(失敗)の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvRegMenuSet)
            End If
            
            '@配列領域の初期化
            ltypRegMenu_.typFavoriteList.Clear
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRegMenu_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '未使用機能NSYS↓
    ''@↓2008/06/25 (Wed) 16:44:24 N.Kojima **************************************************
    ''@2008/06/25現在、未使用。必要に応じ復活させてください。
    ''関数名：prvMakeFilename
    ''機　能：ﾊﾟｽ付のﾌｧｲﾙ名からﾌｧｲﾙ名を切り出す
    ''引　数：lstrInFileName：入力ﾊﾟｽ名
    ''　　　：lstrOutFileName：出力ﾌｧｲﾙ名
    ''戻り値：なし
    ''作成日：2004/08/17 (Tue) 21:29:10 K.Himori
    ''更新日：2004/08/17 (Tue) 21:29:10
    ''備　考：
    'Private Sub prvMakeFilename(ByVal lstrInFileName As String, ByRef lstrOutFileName As String)

    '    Dim llngCnt1    As Long     '汎用ｶｳﾝﾀ1
    '    Dim llngCnt2    As Long     '汎用ｶｳﾝﾀ2

    '    On Error GoTo Error_Handler

    '    '@元ﾊﾟｽ名を後ろから判定
    '    For llngCnt1 = Len(lstrInFileName) To 1 Step -1
    '        llngCnt2 = llngCnt2 + 1
    '        '@\が見つかったらﾙｰﾌﾟを抜ける
    '        If Mid(lstrInFileName, llngCnt1, 1) = "\" Then
    '            Exit For
    '        End If
    '    Next

    '    '@見つかった\から後ろの文字列をﾌｧｲﾙ名として返す
    '    lstrOutFileName = Right(lstrInFileName, llngCnt2 - 1)

    '    Exit Sub

    'Error_Handler:

    '    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '    With ptypOnErrorInfo
    '        .strMenuKey = CMstrLocalMenuKey
    '        .strProcName = "prvMakeFilename"
    '        .strErrMessage = vbNullString
    '    End With

    '    '@共通ｴﾗｰ処理
    '    Call pubOnError_Proc

    'End Sub
    ''@↑2008/06/25 (Wed) 16:44:24 N.Kojima **************************************************
    '未使用機能NSYS↑

    '未使用機能NSYS↓
    ''@↓2008/06/25 (Wed) 16:43:39 N.Kojima **************************************************
    ''@2008/06/25現在、未使用。必要に応じ復活させてください。
    ''関数名：prvHwndAcquire
    ''機　能：外部EXEのﾊﾝﾄﾞﾙ取得及び終了処理
    ''引　数：lstrCaptionName    ：ｷｬﾌﾟｼｮﾝ名
    ''　　　：ｌstrClassName     ：ｸﾗｽ名
    ''戻り値：なし
    ''作成日：2004/05/28 (Fri) 14:49:08 H.Wajima
    ''更新日：2008/06/25 (Wed) 16:42:06 N.Kojima
    ''備　考：ｷｬﾌﾟｼｮﾝ名とｸﾗｽ名の両方が指定されている場合は、ｷｬﾌﾟｼｮﾝ名を優先する
    ''　　　：2008/06/25 (Wed) 16:42:06 N.Kojima     ｿｰｽ整備。(案件№03004)
    'Private Sub prvHwndAcquire(Optional lstrCaptionName As String = vbNullString, _
    '                           Optional lstrClassName As String = vbNullString)

    '    Dim llnghwnd                As Long     'ｳｨﾝﾄﾞｳﾊﾝﾄﾞﾙ格納用
    '    Dim llngRet                 As Long     '戻り値格納用

    '    On Error GoTo Error_Handler

    '    '@ﾊﾟﾗﾒｰﾀの判定
    '    If Len(lstrClassName) Then
    '        '@ｸﾗｽ名を与えてﾊﾝﾄﾞﾙを取得
    '        '@起動中ならﾊﾝﾄﾞﾙが返り、起動していなければ'0'が返る
    '        llnghwnd = FindWindow(lstrClassName, vbNullString)

    '    Else
    '        If Len(lstrCaptionName) Then
    '            '@ｷｬﾌﾟｼｮﾝ名を与えてﾊﾝﾄﾞﾙを取得する場合
    '            '@lstrCaptionName = "Microsoft Excel - Book1" 　'電卓の場合　 "電卓"
    '            llnghwnd = FindWindow(vbNullString, lstrCaptionName)
    '        End If
    '    End If

    '    '@指定のﾊﾝﾄﾞﾙに終了のﾒｯｾｰｼﾞを送る
    '    llngRet = SendMessage(llnghwnd, WM_CLOSE, 0&, 0&)

    '    Exit Sub

    'Error_Handler:

    '    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '    With ptypOnErrorInfo
    '        .strMenuKey = CMstrLocalMenuKey
    '        .strProcName = "prvHwndAcquire"
    '        .strErrMessage = vbNullString
    '    End With

    '    '@共通ｴﾗｰ処理
    '    Call pubOnError_Proc

    'End Sub
    ''@↑2008/06/25 (Wed) 16:43:39 N.Kojima **************************************************
    '未使用機能NSYS↑


    '***************************************************************************************
    '                              * NSYS 追加　関数 *
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：CopyProperties_Button
    '機　能：ボタンのプロパティ全コピー
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/28 (Wed) 15:00:00 NSYS
    '更新日：
    '備　考：※Cursorは画面が処理中で砂時計になるためコピーしない
    Private Sub CopyProperties_Button(ByRef ReplicaControl As Button, ByVal OriginalControl As Button)
        
        ReplicaControl.Name = OriginalControl.Name
        ReplicaControl.AccessibleDescription = OriginalControl.AccessibleDescription
        ReplicaControl.AccessibleName = OriginalControl.AccessibleName
        ReplicaControl.AccessibleRole = OriginalControl.AccessibleRole
        ReplicaControl.AllowDrop = OriginalControl.AllowDrop
        ReplicaControl.Anchor = OriginalControl.Anchor
        ReplicaControl.AutoEllipsis = OriginalControl.AutoEllipsis
        ReplicaControl.AutoSize = OriginalControl.AutoSize
        ReplicaControl.AutoSizeMode = OriginalControl.AutoSizeMode
        ReplicaControl.BackColor = OriginalControl.BackColor
        ReplicaControl.BackgroundImage = OriginalControl.BackgroundImage
        ReplicaControl.BackgroundImageLayout = OriginalControl.BackgroundImageLayout
        ReplicaControl.CausesValidation = OriginalControl.CausesValidation
        ReplicaControl.ContextMenuStrip = OriginalControl.ContextMenuStrip
        ReplicaControl.DialogResult = OriginalControl.DialogResult
        ReplicaControl.Dock = OriginalControl.Dock
        ReplicaControl.Enabled = OriginalControl.Enabled
        ReplicaControl.FlatStyle = OriginalControl.FlatStyle
        ReplicaControl.Font = OriginalControl.Font
        ReplicaControl.ForeColor = OriginalControl.ForeColor
        ReplicaControl.Image = OriginalControl.Image
        ReplicaControl.ImageAlign = OriginalControl.ImageAlign
        ReplicaControl.ImageIndex = OriginalControl.ImageIndex
        ReplicaControl.ImageKey = OriginalControl.ImageKey
        ReplicaControl.ImageList = OriginalControl.ImageList
        ReplicaControl.Location = OriginalControl.Location
        ReplicaControl.Margin = OriginalControl.Margin
        ReplicaControl.MaximumSize = OriginalControl.MaximumSize
        ReplicaControl.MinimumSize = OriginalControl.MinimumSize
        ReplicaControl.Padding = OriginalControl.Padding
        ReplicaControl.Parent = OriginalControl.Parent
        ReplicaControl.RightToLeft = OriginalControl.RightToLeft
        ReplicaControl.Size = OriginalControl.Size
        ReplicaControl.TabIndex = OriginalControl.TabIndex
        ReplicaControl.TabStop = OriginalControl.TabStop
        ReplicaControl.Tag = OriginalControl.Tag
        ReplicaControl.Text = OriginalControl.Text
        ReplicaControl.TextAlign = OriginalControl.TextAlign
        ReplicaControl.TextImageRelation = OriginalControl.TextImageRelation
        ReplicaControl.UseCompatibleTextRendering = OriginalControl.UseCompatibleTextRendering
        ReplicaControl.UseMnemonic = OriginalControl.UseMnemonic
        ReplicaControl.UseVisualStyleBackColor = OriginalControl.UseVisualStyleBackColor
        ReplicaControl.UseWaitCursor = OriginalControl.UseWaitCursor
        ReplicaControl.Visible = OriginalControl.Visible

    End Sub

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
        Const WM_ACTIVATEAPP    As Integer  = &H001C

        If m.Msg = WM_ACTIVATEAPP Then
            Form_ActivateApp(m)

        End If

        MyBase.WndProc(m)
    End Sub


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraCarrier.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

    '関数名：Form_ActivateApp
    '機　能：WindowsメッセージのWM_ACTIVATEAPPを処理する。Deactivate同等の処理を行う
    '引　数：m：Windowsメッセージ
    '戻り値：なし
    '作成日：2019/06/21 (Fri) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub Form_ActivateApp(m As Message)

        'NSYS この関数は、Form_Deactivate と連動して動作するので、メンテナンス時は合わせて修正すること

        'NSYS wParam: TRUE if the window is being activated; FALSE if the window is being deactivated.
        'NSYS アプリとしてはアクティブ化されたが、アクティブ化したフォームは自分以外の場合、
        '     Deactivate と同じ動作をする (VB6互換)
        If m.WParam.ToInt64 <> 0 AndAlso Form.ActiveForm IsNot Me Then

            '@ﾌｫｰﾑ無効処理実行ﾌﾗｸﾞを初期化する
            mblnDeActivateFlag = False
            
            '@PGが起動していない場合は抜ける
            If pstrExecuteMenuKey = vbNullString Then
                Exit Sub
            End If
            
            If Me.Left <= CPlngAppliNarrowWidth Then
                'NSYS pubMenuExpand_Disp() を呼び出すと、内部的にForm_Activateが呼び出されるため
                '     先にフラグを設定する
                '@ﾌｫｰﾑ無効処理実行ﾌﾗｸﾞに"True：実行済"をｾｯﾄする
                mblnDeActivateFlag = True

                '@ﾒﾆｭｰの幅が広いとき
                '@ﾒﾆｭｰの伸縮
                Call pubMenuExpand_Disp(False)
                
            End If
        End If
    End Sub

    '関数名：flex_AfterScroll
    '機　能：グリッドスクロール後処理
    '引　数：sender：イベント発生源のオブジェクト
    '　　　：e  ：イベントに関連する補足情報
    '戻り値：なし
    '作成日：2019/07/03 (Wed) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flex_AfterScroll(sender As Object, e As EventArgs) Handles vsfFlow.AfterScroll, _
                                                                            vsfTool.AfterScroll, _
                                                                            vsfFavorites.AfterScroll

        Dim lobjGrid        As C1FlexGrid
        Dim lobjCmdUp       As Button
        Dim lobjCmdDown     As Button
        Dim llngTopRow      As Integer
        Dim lstrTag         As String

        lobjGrid = CType(sender, C1FlexGrid)

        lstrTag = pubstrVsfTag_Get(lobjGrid, 1)

        ' NSYS 数値変換可能かチェック
        Try
            llngTopRow = CInt(lstrTag)
        Catch ex As Exception
            llngTopRow = Nothing
        End Try
 
        'NSYS TagのTopRowと.TopRowが異なる場合、調整を行う
        If IsNothing(llngTopRow) OrElse llngTopRow <> lobjGrid.TopRow Then
            Select Case lobjGrid.Name
                Case vsfFlow.Name
                    '@流動系
                    lobjCmdUp = cmdFlowUp
                    lobjCmdDown = cmdFlowDown
                Case vsfTool.Name
                    '@ﾂｰﾙ系
                    lobjCmdUp = cmdToolUp
                    lobjCmdDown = cmdToolDown
                Case vsfFavorites.Name
                    '@お気に入り
                    lobjCmdUp = cmdFavoritesUp
                    lobjCmdDown = cmdFavoritesDown
            End Select
            
            'NSYS ｸﾞﾘｯﾄﾞ表示後処理（グリッド共通仕様）を実行する
            Call pubVsfDisp(lobjGrid, lobjCmdUp, lobjCmdDown)
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの状態を変更する
            Call pubGridMenuButton_Set()
        End If
    End Sub

    '関数名：Form_Shown
    '機　能：フォーム表示直後時
    '引　数：sender：イベント発生源のオブジェクト
    '　　　：e  ：イベントに関連する補足情報
    '戻り値：なし
    '作成日：2020/10/14 (Wed) 15:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        'NSYS 起動直後、メニュー画面をアクティブ画面にする
        mblnActivateAfterShown = True
        Me.Activate

    End Sub

End Class
