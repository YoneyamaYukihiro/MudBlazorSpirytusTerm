'ﾌｧｲﾙ名：xxEN0250.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：工程スキップ　メインフォーム
'作成日：2004/05/11 (Tue) 11:16:14 H.Wajima
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'
'Copyright(C) SEIKO EPSON CORPORATION 2004-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0250
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0250    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0250
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0250
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0250)
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
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 定数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2020/03/06 (Fri) 11:42:50 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion                 As String = "10.00"
    Private Const CMstrLocalVersion                 As String = "11.00"
    '@↑2020/03/06 (Fri) 11:42:50 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 13:03:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer              As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer              As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 13:03:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_nextsteplistVer          As String = "03.01"         'ﾛｯﾄ次工程取得
    Private Const CMstrlot_skipstepVer              As String = "02.00"         'ﾛｯﾄ工程ｽｷｯﾌﾟ
    Private Const CMstrlot_chkskipstepVer           As String = "03.00"         '工程ｽｷｯﾌﾟ可否確認
    Private Const CMstrlot_getrestrictVer           As String = "01.00"         '時間制限取得
    Private Const CMstrlot_actlist_Ver              As String = "01.02"         'ｱｸｼｮﾝ予約ﾘｽﾄ取得
    Private Const CMstrlot_chkchangeorderVer        As String = "01.00"         '量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
    '@↓2014/11/26 (Wed) 10:00:02 H.Hayashi **************************************************
    Private Const CMstrlot_chkovertake              As String = "01.00"         '無機ODF追越制限違反確認
    '@↑2014/11/26 (Wed) 10:00:02 H.Hayashi **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN0250  'ﾛｰｶﾙﾒﾆｭｰKey

    '@ｷｬﾘｱのMAXBYTE数
    Private Const CMlngCarrierMaxLength             As Integer = 6              'ｷｬﾘｱIDの最大桁数

    '@vsfNextEqListの定数宣言(ROW)
    Private Const CMlngNextEqListRowNo              As Integer = 0              '0行目

    '@ｸﾞﾘｯﾄﾞの初期値定数宣言
    Private Const CMstrGridFontName                 As String = "ＭＳ ゴシック"  'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄ名
    Private Const CMlngGridFontSize                 As Integer = 11             'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngGridFixedCols                As Integer = 0              'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngGridFixedRows                As Integer = 1              'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngGridTitleHeight              As Integer = 20             'ﾍｯﾀﾞｰの高さ
    Private Const CMlngGridRowHeight                As Integer = 18             '1明細の高さ
    Private Const CMlngGridPageRows                 As Integer = 7              '1ﾍﾟｰｼﾞのｾﾙの行数
    Private Const CMlngGrid3DBlank                  As Integer = 3              'ｸﾞﾘｯﾄﾞの3D表示の余白
    Private Const CMlngGrid3DBlankWidth             As Integer = 2              'NSYS ｸﾞﾘｯﾄﾞの3D表示の余白(幅)
    Private Const CMlngScrollButtonSize             As Integer = 49             'ｽｸﾛｰﾙﾎﾞﾀﾝのｻｲｽﾞ
    Private Const CMlngGridRowTitle                 As Integer = 0              'ﾀｲﾄﾙ行(行)
    Private Const CMstrDefaultStep                  As String = "○"            'ﾃﾞﾌｫﾙﾄ小工程
    Private Const CMstrDaitaiStep                   As String = "　"            '代替小工程

    '@ｸﾞﾘｯﾄﾞの定数宣言(ColWidth)
    Private Const CMlngGridColWidthOpID             As Integer = 201            '大工程ID
    Private Const CMlngGridColWidthStepID           As Integer = 201            '小工程ID
    Private Const CMlngGridColWidthDefault          As Integer = 67             'ﾃﾞﾌｫﾙﾄ
    Private Const CMlngGridColWidthWPID             As Integer = 273            'WPID

    '@vsfLotPrestateの定数宣言(ｶﾗﾑ)
    Private Const CMlngLotPrestateColOpID           As Integer = 0              '大工程ID
    Private Const CMlngLotPrestateColStepID         As Integer = 1              '小工程ID
    Private Const CMlngLotPrestateColDefault        As Integer = 2              'ﾃﾞﾌｫﾙﾄ
    Private Const CMlngLotPrestateColWPID           As Integer = 3              'WPID

    '@vsfNextStepInfoの定数宣言(ｶﾗﾑ)
    Private Const CMlngNextStepInfoColOpID          As Integer = 0              '大工程ID
    Private Const CMlngNextStepInfoColStepID        As Integer = 1              '小工程ID
    Private Const CMlngNextStepInfoColDefault       As Integer = 2              'ﾃﾞﾌｫﾙﾄ
    Private Const CMlngNextStepInfoColWPID          As Integer = 3              'WPID

    '@ｸﾞﾘｯﾄﾞの幅
    Private Const CMlngGridWidth                    As Integer = CMlngGridColWidthOpID _
                                                    + CMlngGridColWidthStepID _
                                                    + CMlngGridColWidthDefault _
                                                    + CMlngGridColWidthWPID _
                                                    + CMlngGrid3DBlankWidth
    '@ｸﾞﾘｯﾄﾞの高さ
    Private Const CMlngGridHeight                   As Integer = (CMlngGridTitleHeight _
                                                    * CMlngGridFixedRows) _
                                                    + (CMlngGridRowHeight _
                                                    * CMlngGridPageRows) _
                                                    + CMlngGrid3DBlank

    '@vsfLotPrestateの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrLotPrestateColTOpID          As String = "現大工程"      '大工程ID
    Private Const CMstrLotPrestateColTStepID        As String = "現小工程"      '小工程ID
    Private Const CMstrLotPrestateColTDefault       As String = "ﾃﾞﾌｫﾙﾄ"        'ﾃﾞﾌｫﾙﾄ
    Private Const CMstrLotPrestateColTWPID          As String = "装置名"        'WPID

    '@vsfNextStepInfoの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrNextStepInfoColTOpID         As String = "次大工程"      '大工程ID
    Private Const CMstrNextStepInfoColTStepID       As String = "次小工程"      '小工程ID
    Private Const CMstrNextStepInfoColTDefault      As String = "ﾃﾞﾌｫﾙﾄ"        'ﾃﾞﾌｫﾙﾄ
    Private Const CMstrNextStepInfoColTWPID         As String = "装置名"        'WPID

    '@次工程ｽｷｯﾌﾟﾁｪｯｸ
    Private Const CMstrStepSkipResultOK             As String = "OK"
    Private Const CMstrStepSkipResultNG             As String = "NG"

    '最終工程判定用ﾃﾞﾌｫﾙﾄｲﾝﾃﾞｯｸｽ
    Private Const CMlngDefaultIndex                 As Integer = 0              'ﾃﾞﾌｫﾙﾄｲﾝﾃﾞｯｸｽ(最終工程判定)

    '@↓2007/07/19 (Thu) 14:23:08 N.Kasai **************************************************
    ''@ｱｸｼｮﾝ予約ﾀｲﾌﾟ名用
    'Private Const CMstrActTypeLOT                   As String = "ロット"
    'Private Const CMstrActTypePD                    As String = "機種"
    'Private Const CMstrActTypeWP                    As String = "装置"
    'Private Const CMstrActTypeTStep                 As String = "特定工程"
    '
    ''@ｱｸｼｮﾝﾀｲﾌﾟ
    'Private Const CMstrLotActionTypeID0             As String = "0"             'ﾛｯﾄ
    'Private Const CMstrLotActionTypeID1             As String = "1"             '機種
    'Private Const CMstrLotActionTypeID2             As String = "2"             '装置
    'Private Const CMstrLotActionTypeID3             As String = "3"             '特定工程
    '@↑2007/07/19 (Thu) 14:23:08 N.Kasai **************************************************

    '@ｱｸｼｮﾝﾄﾘｶﾞｰ名
    Private Const CMstrEN0030Title                  As String = "作業開始"
    Private Const CMstrEN0060Title                  As String = "作業終了"
    '@ｱｸｼｮﾝﾄﾘｶﾞｰ
    Private Const CMlngTriggerStart                 As Integer = 0              '作業開始
    Private Const CMlngTriggerEnd                   As Integer = 1              '作業終了
    Private Const CMlngTriggerAll                   As Integer = 2              '全ﾀｲﾐﾝｸﾞ

    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    Private mstrLotLastUpdate                       As String                   'ﾛｯﾄ最終更新日時
    Private mstrCarrier                             As String                   'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
    Private mblnTakeOverDispFlg                     As Boolean                  '引継ぎ表示ﾌﾗｸﾞ
    Private mblnLastStepFlg                         As Boolean                  '最終工程ﾌﾗｸﾞ(True:最終工程　False:通常工程)
    Private mstrOpID                                As String                   '現在大工程退避領域
    Private mstrStepID                              As String                   '現在小工程退避領域
    Private mblnFirstLoadFlg                        As Boolean                  'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:読込み済み、False:初回)
    Private mblnValidateFlag                        As Boolean                  'True:Validate完了、False:Validate走行中(ﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
    Private mtypLotCurState                         As Lotprestate              'ﾛｯﾄ情報格納構造体
    Private buttonProcessing                        As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                  'NSYS WindowCloseフラグ

    '*******************************************************************************
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
        pubVsfMouseWheelManager_Set(vsfNextStepInfo, cmdNextUP, cmdNextDown)
        pubVsfMouseWheelManager_Set(vsfLotPrestate, cmdPreUp, cmdPreDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '　　　　　　　　　　　　　* イベントハンドラの記述 *
    '*******************************************************************************
    '================================== Private ====================================
    '関数名：Form_Load
    '機　能：Form_Load処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 11:25:04 H.Wajima
    '更新日：2005/07/04 (Mon) 13:06:08 N.Kojima
    '備　考：
    '　　　：2005/07/04 (Mon) 13:06:08 N.Kojima     OnErr処理追加
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0250, CMstrLocalVersion)
            
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                mblnValidateFlag = True
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(False, New FormClosingEventArgs(New CloseReason,  False))

                Exit Sub
            End If
            
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN0250_Init()
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
            Call prvfrmxxEN0250_CmbInit(False)
            
            '@ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ(True:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み)
            mblnFirstLoadFlg = True
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            '@引継ぎ情報表示済みﾌﾗｸﾞ
            mblnTakeOverDispFlg = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"                  'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 16:46:27 H.Wajima
    '更新日：2005/07/12 (Tue) 09:48:06 N.Kojima
    '備　考：
    '　　　：2005/07/12 (Tue) 09:48:06 N.Kojima     OnErr処理、SetFocus対応追加
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Try
            '@ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ(Ture:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み)
            '@初回ﾛｰﾄﾞのみ最新ﾛｯﾄ一覧を取得する。
            If mblnFirstLoadFlg = True Then
                
                '@ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ(Ture:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み)
                mblnFirstLoadFlg = False
                
                '@引継ぎ情報表示済みﾌﾗｸﾞの判定
                '@FormLoad後、最初の1回しか処理しない
                If mblnTakeOverDispFlg = True Then
                    '@引継ぎ情報が表示済みの場合
                    Exit Sub
                End If
                
                '@引継ぎ情報表示済みﾌﾗｸﾞにTrueを設定する
                mblnTakeOverDispFlg = True
            
                '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                mblnValidateFlag = True
            
                '@引数のｷｬﾘｱIDが空白かどうか判定する
                If ptypCommonInfo.strCarrierId <> vbNullString Then
                    '@空白でない場合
                    '@ｷｬﾘｱIDの初期値を設定する
                    txtCarrier.Text = ptypCommonInfo.strCarrierId
                    '@ｷｬﾘｱ情報を取得する
                    RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                    Call txtCarrier_Validate(False, New CancelEventArgs(True))
                    AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                Else
                    '@装置別ﾛｯﾄ一覧用  ｷｬﾘｱID初期化
                    ptypCommonInfo.strCarrierId = vbNullString
                End If
                    
                'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
                'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
                Dim lfuncActivate As Action = Sub()
                    Me.Activate()
                End Sub
                Me.BeginInvoke(lfuncActivate)
                
            End If

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
                
            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "Form_Activate"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：Form_KeyDown処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：未使用
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 12:34:34 H.Wajima
    '更新日：2005/07/04 (Mon) 11:39:42 N.Kojima
    '備　考：
    '　　　：2005/07/04 (Mon) 11:39:42 N.Kojima     OnErr処理追加、ｸﾞﾘｯﾄﾞ共通関数のKeyDown処理の記述位置変更(不具合№2434)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
        '@↓2005/07/04 (Mon) 11:28:41 N.Kojima **************************************************
        '@SetFocus対応＋ｸﾞﾘｯﾄﾞ共通処理位置変更
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKeyを受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                e.Handled = True
                Exit Sub
            End If
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受付けない
            If Me.Enabled = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                e.Handled = True
                Exit Sub
            End If
            
            '@ｸﾞﾘｯﾄﾞ共通関数のKeyDown処理を実行する
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfLotPrestate, cmdPreUp, cmdPreDown)
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfNextStepInfo, cmdNextUP, cmdNextDown)
        '@↑2005/07/04 (Mon) 11:28:41 N.Kojima **************************************************

            Select Case ActiveControl.Name
                '@ｷｬﾘｱIDの場合はﾛｯﾄ状態を取得する
                Case txtCarrier.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Call txtCarrier_Validate(Me, New CancelEventArgs(True))
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            e.Handled = True
                    End Select
                Case Else
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
            End Select
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"               'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：Form_QueryUnload処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：Unloadﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 11:40:43 H.Wajima
    '更新日：2005/07/14 (Thu) 15:20:21 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 14:38:05 T.Kitagawa   閉じるﾎﾞﾀﾝ統合
    '　　　：2005/07/04 (Mon) 13:07:34 N.Kojima     OnErr処理、SetFocus対応追加
    '　　　：2005/07/14 (Thu) 15:20:21 N.Kojima     Validateﾌﾗｸﾞ処理追加
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm         As Boolean          '開放結果格納
        Dim ltypLotCurState     As Lotprestate      'ﾛｯﾄ情報格納構造体

        Try
            '@↓2005/07/04 (Mon) 16:49:41 N.Kojima **************************************************
            '@ﾌﾗｸﾞ判定(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            If mblnValidateFlag = False Then
                e.Cancel = True
                Exit Sub
            End If
        '@↑2005/07/04 (Mon) 16:49:41 N.Kojima **************************************************

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@構造体の初期化
            mtypLotCurState = ltypLotCurState
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
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
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "Form_QueryUnload"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝClick
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 11:39:53 H.Wajima
    '更新日：2018/11/16 (Fri) 09:47:55 Y.Yoneyama
    '備　考：
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
    '　　　：2005/07/04 (Mon) 13:08:12 N.Kojima     OnErr処理、SetFocus対応追加
    '      ：2018/11/16 (Fri) 09:47:55 Y.Yoneyama   防湿ALD対応
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim llngRet         As Integer  '戻り値
        Dim ltypCommonInfo  As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKeyを受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑﾛｯｸ中は終了させない。
            If Me.Enabled = False Then
                Exit Sub
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
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                llngRet = publngEnd_Proc(CPstrKeyEN0250, ltypCommonInfo)
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "cmdClose_Click"             'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdProcEnd_Click
    '機　能：確定ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/12 (Wed) 17:17:25 H.Wajima
    '更新日：2014/12/02 (Tue) 14:00:05 H.Hayashi
    '備　考：
    '　　　：2005/01/06 (Thu) 11:20:55 N.Kasai      最終工程でもｽｷｯﾌﾟ可
    '　　　：2005/03/31 (Thu) 14:10:06 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/05/17 (Tue) 17:02:34 S.Deguchi    不具合№721の対応で時間制限処理を追加
    '　　　：2005/07/04 (Mon) 13:08:38 N.Kojima     OnErr処理、SetFocus対応追加
    '　　　：2014/12/02 (Tue) 13:31:10 H.Hayashi    組立無機ODF環境のｼｽﾃﾑ環境整備
    Private Sub cmdProcEnd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdProcEnd.Click
        
        Dim lblnAns                 As Boolean          '戻り値
        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrDefaultNextOpID     As String           'ﾃﾞﾌｫﾙﾄ次大工程
        Dim lstrDefaultNextStepID   As String           'ﾃﾞﾌｫﾙﾄ次小工程
        Dim llngCnt                 As Integer          '汎用ｶｳﾝﾀ
        Dim ltypLotGetRestrict      As LotGetRestrict   '時間制限構造体

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
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受付けない
            If Me.Enabled = False Then
                Exit Sub
            End If

            '@画面入力ﾁｪｯｸ
            lblnAns = prvblnProcEndInput_Chk
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@最終工程ﾌﾗｸﾞONの場合は最終工程の為、ﾃﾞﾌｫﾙﾄ工程のﾁｪｯｸは行わない
            If mblnLastStepFlg = False Then
                '@ﾃﾞﾌｫﾙﾄ大工程、ﾃﾞﾌｫﾙﾄ小工程の初期化
                lstrDefaultNextOpID = vbNullString
                lstrDefaultNextStepID = vbNullString
                
                '@ﾃﾞﾌｫﾙﾄ大工程、小工程取得
                With vsfNextStepInfo
                    '@次工程ｸﾞﾘｯﾄﾞの明細行ﾙｰﾌﾟ
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@ﾃﾞﾌｫﾙﾄ列の判定
                        If .GetData(llngCnt, CMlngNextStepInfoColDefault) = CMstrDefaultStep Then
                            '@ﾃﾞﾌｫﾙﾄの場合
                            '@ﾃﾞﾌｫﾙﾄ次大工程の保存
                            lstrDefaultNextOpID = .GetData(llngCnt, CMlngNextStepInfoColOpID)
                            '@ﾃﾞﾌｫﾙﾄ次小工程の保存
                            lstrDefaultNextStepID = .GetData(llngCnt, CMlngNextStepInfoColStepID)
                            Exit For
                        End If
                    Next llngCnt
                End With
                
                '@次工程のﾃﾞﾌｫﾙtが取得できない場合
                If lstrDefaultNextOpID = vbNullString Or lstrDefaultNextStepID = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002S)
                    '@"<TRM2SW>$$デフォルト次工程が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrier)
                    
                    Exit Sub
                End If
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdProcEnd_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)


            '@↓2014/11/26 (Wed) 09:10:31 H.Hayashi **************************************************
                       
            '@起動SBが組立か
            If pstrSBID = CPstrSBID2A0 Then
                '@2A0：組立の場合
                       
                '@=======================
                '@ 無機ODF追越制限違反判定＆権限ﾁｪｯｸ処理
                '@=======================
                lblnAns = prvblnOvertakeAuthority_Chk(mtypLotCurState.strWpID, _
                                                  lblLotID.Text)
                
                '@無機ODF追越制限違反判定＆権限ﾁｪｯｸ処理の戻り値を判定
                If lblnAns = False Then
                    '@処理中断 or 権限なしの場合
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                
                    Exit Sub
                Else
                    '@通常実行 or 権限ありの場合は処理続行
                End If

            End If
            '@↑2014/11/26 (Wed) 09:10:31 H.Hayashi **************************************************
         
         
            '@時間制限取得ﾒｯｾｰｼﾞ処理
            lblnAns = pubblnLotGetRestrict_Sel(pstrSBID, _
                                               CMstrlot_getrestrictVer, _
                                               lblLotID.Text, _
                                               ltypLotGetRestrict)
            '@結果判定
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@=======================
                '@ 時間制限ﾁｪｯｸ
                '@=======================
                lblnAns = prvblnRestrict_Chk(ltypLotGetRestrict)
                
                '@結果判定
                If lblnAns = True Then
                    
                    '@=======================
                    '@ 工程ｽｷｯﾌﾟﾒｯｾｰｼﾞ送信
                    '@=======================
                    lblnAns = prvblnLotSkipStep_Upd(lstrDefaultNextOpID, _
                                                    lstrDefaultNextStepID)

                    '@結果判定
                    If lblnAns = True Then
                        
                        '@ｷｬﾘｱIDのｸﾘｱ
                        txtCarrier.Text = vbNullString
                        
                        '@=======================
                        '@ ﾛｯﾄ情報の初期化
                        '@=======================
                        Call prvfrmxxEN0250_Init()
                        
                        '@=======================
                        '@ ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                        '@=======================
                        Call prvfrmxxEN0250_CmbInit(False)
                    End If
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "cmdProcEnd_Click"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 11:39:11 H.Wajima
    '更新日：2005/07/04 (Mon) 13:09:05 N.Kojima
    '備　考：
    '　　　：2005/07/04 (Mon) 13:09:05 N.Kojima     OnErr処理追加
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change
        
        Try
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN0250_Init()
            
            '@現工程ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfLotPrestate_Init()
            
            '@次工程ｸﾞﾘｯﾄﾞの初期化
            Call prvVsfNextStepInfo_Init()
            
            '@ﾎﾞﾀﾝ状態
            Call prvfrmxxEN0250_CmbInit(False)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "txtCarrier_Change"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱIDValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 11:44:13 H.Wajima
    '更新日：2007/06/01 (Fri) 09:12:15 N.Kasai
    '備　考：
    '　　　：2004/09/07 (Tue) 12:09:34 N.Kasai      確定ﾎﾞﾀﾝの使用可否ﾀｲﾐﾝｸﾞを修正(№674)
    '　　　：2004/09/15 (Wed) 17:15:23 N.Kojima　   例外対応としてﾘｽﾄにNullすら入ってこない場合の処理を追加(№750)
    '　　　：2004/09/28 (Tue) 15:46:01 Y.Yamagishi　SendKeysをｾｯﾄﾌｫｰｶｽに変更
    '　　　：2005/01/06 (Thu) 10:54:39 N.Kasai      最終工程でもｽｷｯﾌﾟ可(不具合/改善№254)
    '　　　：2005/03/23 (Wed) 11:30:42 N.Kasai      工程ｽｷｯﾌﾟﾁｪｯｸ要求MSG変更に伴う修正及び不要通信を行わないようﾁｪｯｸを先頭へ移動
    '　　　：2005/05/18 (Wed) 17:04:18 S.Deguchi    工程ｽｷｯﾌﾟﾁｪｯｸ処理修正
    '　　　：2005/07/04 (Mon) 13:09:30 N.Kojima     OnErr処理、SetFocus対応追加、ｺﾒﾝﾄ行削除(不要通信処理部)
    '　　　：2005/07/13 (Wed) 16:10:03 N.Kojima     ﾌｫｰｶｽ移動処理修正。
    '　　　：2005/07/14 (Thu) 15:15:34 N.Kojima     Valdate中はﾌｫｰﾑをｱﾝﾛｰﾄﾞさせないようにする為のﾌﾗｸﾞ追加。
    '　　　：2007/06/01 (Fri) 09:12:15 N.Kasai      処理号機対応(№01934)
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

    '    Dim mtypLotCurState         As Lotprestate          'ﾛｯﾄ情報格納構造体
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotNextStep         As LotNextStep          '次工程取得ﾃﾞｰﾀ格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrResult              As String               '判定結果
        Dim llngAns                 As Integer              '結果取得
        Dim lstrOpID                As String               '大工程
        Dim lstrStepID              As String               '小工程
        Dim lstrMsgChara            As String               'ﾒｯｾｰｼﾞ文字
        
        Try
            'NSYS 初回ロード時
            If mblnFirstLoadFlg = True Then
                '処理を続行 (引継ぎ時にエラーデータがある場合、エラーが表示されない対策)
            'NSYS 画面を閉じる場合は処理を抜ける
            Else If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@空ENTERの場合はﾌｫｰｶｽ移動のみ
            If Trim(txtCarrier.Text) = vbNullString Then
                '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdClose)
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                e.Cancel = True
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                
                Exit Sub
            End If
            
            '@ﾌﾗｸﾞ判定開始(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            mblnValidateFlag = False
            
            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If Trim(txtCarrier.Text) <> vbNullString And _
                Len(Trim(txtCarrier.Text)) = CMlngCarrierMaxLength And _
                txtCarrier.Text <> mstrCarrier Then
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                lstrFormName = Me.Name
                lstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@ﾛｯﾄ情報の初期化
                Call prvfrmxxEN0250_Init()
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                Call prvfrmxxEN0250_CmbInit(False)
                
                '@変数初期化
                lstrMsgChara = vbNullString
                
                '@次工程ｽｷｯﾌﾟﾁｪｯｸを行う
                lblnAns = pubblnNextStepChk_Chk(CMstrlot_chkskipstepVer, _
                                                txtCarrier.Text, _
                                                lstrResult, _
                                                lstrOpID, _
                                                lstrStepID)
                '@戻り値判定
                If lblnAns = True Then
                
                    '@結果判定
                    '@0:OK,1:制限時間,2:処理号機,3:制限時間と号機記憶
                    Select Case lstrResult
                        
                        '@時間制限設定
                        Case "1"
                        
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)
                            
                            lstrMsgChara = "制限時間"
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005S, lstrOpID, lstrStepID, lstrMsgChara)
                            '@"<TRM5SW>$$大工程[%1]、小工程[%2]では$[%3]が設定されています。$工程スキップを実行すると[%3]の適用外となります。$実行しますか？"
                            llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                            '@要求確認
                            If llngAns = vbNo Then
                                
                                '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                                mblnValidateFlag = True
                                
                                '@ｷｬﾝｾﾙする
                                Exit Sub
                            Else
                                '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                                mstrCarrier = txtCarrier.Text
                                
                                '@再度ﾚｽﾎﾟﾝｽ開始
                                Call pubResponseStart(lstrFormName, lstrEventName)
                            End If
                        
                        '@処理号機設定
                        Case "2"
                            
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)
                            
                            lstrMsgChara = "号機記憶"
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005S, lstrOpID, lstrStepID, lstrMsgChara)
                            '@"<TRM5SW>$$大工程[%1]、小工程[%2]では$[%3]が設定されています。$工程スキップを実行すると[%3]の適用外となります。$実行しますか？"
                            llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                            '@要求確認
                            If llngAns = vbNo Then
                                
                                '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                                mblnValidateFlag = True
                                
                                '@ｷｬﾝｾﾙする
                                Exit Sub
                            Else
                                '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                                mstrCarrier = txtCarrier.Text
                                
                                '@再度ﾚｽﾎﾟﾝｽ開始
                                Call pubResponseStart(lstrFormName, lstrEventName)
                            End If
                        
                        '@時間制限/処理号機設定
                        Case "3"
                        
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)
                            
                            lstrMsgChara = "制限時間及び号機記憶"
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005S, lstrOpID, lstrStepID, lstrMsgChara)
                            '@"<TRM5SW>$$大工程[%1]、小工程[%2]では$[%3]が設定されています。$工程スキップを実行すると[%3]の適用外となります。$実行しますか？"
                            llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                            '@要求確認
                            If llngAns = vbNo Then
                                
                                '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                                mblnValidateFlag = True
                                
                                '@ｷｬﾝｾﾙする
                                Exit Sub
                            Else
                                '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                                mstrCarrier = txtCarrier.Text
                                
                                '@再度ﾚｽﾎﾟﾝｽ開始
                                Call pubResponseStart(lstrFormName, lstrEventName)
                            End If
                        
                        Case Else
                            '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                            mstrCarrier = txtCarrier.Text
                    End Select
                Else
                    
                    '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                    mblnValidateFlag = True
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    Exit Sub
                End If

                '@ﾛｯﾄ情報の取得
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD1C, txtCarrier.Text, mtypLotCurState)
                
                '@結果判定
                If lblnAns = False Then
                    
                    '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                    mblnValidateFlag = True
                    
                    '@退避領域をｸﾘｱ
                    mstrOpID = vbNullString
                    mstrStepID = vbNullString
                    
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    
                    '@ﾊｲﾗｲﾄ表示
                    Call pubHighlight(txtCarrier)
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@処理を抜ける
                    Exit Sub
                Else
                    
                    '@退避領域へ情報をｾｯﾄ
                    mstrOpID = mtypLotCurState.strOpID
                    mstrStepID = mtypLotCurState.strStepID
                End If

                '@最終工程ﾌﾗｸﾞの初期化
                mblnLastStepFlg = False
                
                '上記以外の場合
                '@次工程情報取得
                lblnAns = pubblnLotNextStepList_Sel(CMstrlot_nextsteplistVer, _
                                                    mtypLotCurState.strLotID, _
                                                    mtypLotCurState.strOpID, _
                                                    mtypLotCurState.strStepID, _
                                                    ltypLotNextStep)
                '@取得に成功したら次工程を表示
                If lblnAns = True Then
                
                    '@次工程が最終工程の場合の判定
                    With ltypLotNextStep
                        '@最終工程の判定
                        If .lngNextStepListCnt <> 0 Then
                            If .strNextStepList(CMlngDefaultIndex).strNextOpId = vbNullString And _
                                .strNextStepList(CMlngDefaultIndex).strNextStepId = vbNullString And _
                                .strNextStepList(CMlngDefaultIndex).strStepDivision = vbNullString Then
                                '@大工程、小工程、工程ﾌﾗｸﾞが空白の場合最終工程と判断する。(SV担当確認済み)
                                
                                '@最終工程ﾌﾗｸﾞON
                                mblnLastStepFlg = True
                            Else
                                '@次工程を表示
                                Call prvVsfNextStepInfo_Disp(ltypLotNextStep, ltypLotNextStep.lngNextStepListCnt)
                            End If
                        End If
                    End With
                    
                    '@確定ﾎﾞﾀﾝは使用可
                    cmdProcEnd.Enabled = True
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                Else

                    '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                    mblnValidateFlag = True

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@確定ﾎﾞﾀﾝは使用不可
                    cmdProcEnd.Enabled = False
                    
                    Exit Sub
                End If
                
                '@現工程表示処理
                Call prvfrmxxEN0250_Disp(mtypLotCurState)
                
                '@ｱｸｼｮﾝ予約確認
                Call cmdActionDisp_Click(sender, New EventArgs)
                
            
        '@↓2005/07/13 (Wed) 16:08:10 N.Kojima **************************************************
        '@現工程・次工程がｽｸﾛｰﾙするほどある場合、確定ﾎﾞﾀﾝが有効なら、上下ｽｸﾛｰﾙﾎﾞﾀﾝ押下時に確定ﾎﾞﾀﾝにあてる。

                '@確定ﾎﾞﾀﾝの判定
                If cmdProcEnd.Enabled = True Then
                    '@使用可能の場合
                    '@確定ﾎﾞﾀﾝへﾌｫｰｶｽ設定
                    If ActiveControl.Name = txtCarrier.Name Then
                        Call pubSetFocus(cmdProcEnd)
                    End If
                Else
                    '@ﾌｫｰｶｽを移動する
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
        '@↑2005/07/13 (Wed) 16:08:10 N.Kojima **************************************************

            Else
            
                '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                mblnValidateFlag = True
            
                '@上記以外の場合
                '@入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と同じか判定する
                If txtCarrier.Text = mstrCarrier Then
                    '@確定ﾎﾞﾀﾝの判定
                    If cmdProcEnd.Enabled = True Then
                        '@使用可能の場合
                        '@確定ﾎﾞﾀﾝへﾌｫｰｶｽ設定
                        If ActiveControl.Name = txtCarrier.Name Then
                            Call pubSetFocus(cmdProcEnd)
                        End If
                    Else
                        '@使用不可の場合
                        If ActiveControl.Name = txtCarrier.Name Then
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If
            End If
            
            '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            mblnValidateFlag = True
            
            Exit Sub

        Catch ex As Exception
            
            '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            mblnValidateFlag = True
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "txtCarrier_Validate"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdPreDown_Click
    '機　能：現工程▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/20 (Thu) 15:23:39 N.Kasai
    '更新日：2005/07/04 (Mon) 13:11:04 N.Kojima
    '備　考：
    '　　　：2005/07/04 (Mon) 13:11:04 N.Kojima     OnErr処理追加
    Private Sub cmdPreDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPreDown.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞ共通関数の▼ﾎﾞﾀﾝ処理を実行する
            Call pubVsfCmdDown(vsfLotPrestate, cmdPreUp, cmdPreDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "cmdPreDown_Click"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdPreUp_Click
    '機　能：現工程▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/20 (Thu) 15:23:45 N.Kasai
    '更新日：2005/07/04 (Mon) 13:11:25 N.Kojima
    '備　考：
    '　　　：2005/07/04 (Mon) 13:11:25 N.Kojima     OnErr処理追加
    Private Sub cmdPreUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPreUp.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞ共通関数の▲ﾎﾞﾀﾝ処理を実行する
            Call pubVsfCmdUp(vsfLotPrestate, cmdPreUp, cmdPreDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "cmdPreUp_Click"             'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNextDown_Click
    '機　能：次工程▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/20 (Thu) 15:27:17 N.Kasai
    '更新日：2005/07/04 (Mon) 13:11:47 N.Kojima
    '備　考：
    '　　　：2004/09/14 (Tue) 19:56:54 Y.Yamagishi  不具合改善№436
    '　　　：2005/07/04 (Mon) 13:11:47 N.Kojima     OnErr処理追加
    Private Sub cmdNextDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNextDown.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞ共通関数の▼ﾎﾞﾀﾝ処理を実行する
            Call pubVsfCmdDown(vsfNextStepInfo, cmdNextUP, cmdNextDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "cmdNextDown_Click"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNextUP_Click
    '機　能：次工程▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/20 (Thu) 15:25:30 N.Kasai
    '更新日：2005/07/04 (Mon) 13:12:19 N.Kojima
    '備　考：
    '　　　：2005/07/04 (Mon) 13:12:19 N.Kojima     OnErr処理追加
    Private Sub cmdNextUP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNextUP.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞ共通関数の▲ﾎﾞﾀﾝ処理を実行する
            Call pubVsfCmdUp(vsfNextStepInfo, cmdNextUP, cmdNextDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "cmdNextUP_Click"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdActionDisp_Click
    '機　能：ｱｸｼｮﾝ予約確認ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/16 (Fri) 11:22:13 N.Kasai
    '更新日：2007/02/16 (Fri) 11:22:13 N.Kasai
    '備　考：
    Private Sub cmdActionDisp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdActionDisp.Click
        
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnHoldFlag            As Boolean              '結果取得(True:保留、False:保留なし)
        Dim lstrMsg1                As String               'ﾒｯｾｰｼﾞ文字列
        Dim lstrMsg2                As String               'ﾒｯｾｰｼﾞ文字列
        Dim llngRtn                 As Integer              '汎用戻り値
       
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
            
            With mtypLotCurState
                '@ｱｸｼｮﾝ予約ﾘｽﾄの表示
                lblnAns = prvblncmdActionDisp_Proc(.strLotID, .strOpID, .strStepID, .strPdId, _
                                                        .strMasPdVersion, vbNullString)
            End With
                        
            '@戻り値の判定
            If lblnAns = False Then
            '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞがない場合
                '@ｱｸｼｮﾝ予約ﾎﾞﾀﾝ非活性化
                cmdActionDisp.Enabled = False
            Else
            '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞがある場合
                '@ｱｸｼｮﾝ予約ﾎﾞﾀﾝ活性化
                cmdActionDisp.Enabled = True
                
                '@保留ﾌﾗｸﾞ初期化
                lblnHoldFlag = False
                
                With ptypLotAction
                    For llngCnt = 0 To .lnglstCnt - 1
                        '@ｱｸｼｮﾝ予約保留(0:なし、1:停止、2:保留)
                        '@保留の場合
                        If .typLotActList(llngCnt).strStopHoldFlag = CPstrActionFlag2 Then
                            '@ｱｸｼｮﾝﾄﾘｶﾞｰが作業終了の場合のみ(作業開始は保留解除済みの為)
                            '@作業終了の場合
                            If .typLotActList(llngCnt).strActionTrigger = CMstrEN0060Title Then
                                '@工程名取得
                                lstrMsg1 = .typLotActList(llngCnt).strOpID & CPstrSlash & .typLotActList(llngCnt).strStepID
                                
                                '@同一作業者IDの場合はﾒｯｾｰｼﾞを表示しない
                                llngRtn = InStr(lstrMsg2, .typLotActList(llngCnt).strEmpID)
                                If llngRtn = 0 Then
                                    '@保留担当
                                    lstrMsg2 = lstrMsg2 & "[担当：" & .typLotActList(llngCnt).strEmpID & _
                                                CPstrHiphen & .typLotActList(llngCnt).strEmpName & "]" & vbCrLf
                                End If
                                
                                '@保留あり
                                lblnHoldFlag = True
                            End If
                        End If
                    Next
                    '@保留の有無
                    If lblnHoldFlag = True Then
                        
                        '@最終行がｶﾝﾏの場合
                        If Strings.Right$(lstrMsg2, 2) = vbCrLf Then
                            lstrMsg2 = Strings.Left$(lstrMsg2, Len(lstrMsg2) - 2)
                        End If
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006R, lstrMsg1, lstrMsg2)
                        '@"<TRM6RI>$$工程[%1]にはアクション予約による保留が設定されています。$担当：[%2]"
                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                    End If
                End With

            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdActionDisp_Click"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 関数の記述 *
    '*******************************************************************************
    '================================== Private ====================================
    '関数名：prvfrmxxEN0250_Init
    '機　能：ﾌｫｰﾑ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 11:27:29 H.Wajima
    '更新日：2008/06/12 (Thu) 09:21:29 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 14:56:38 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2005/05/18 (Wed) 14:50:37 S.Deguchi    現在大/小工程の退避領域の初期化処理追加
    '　　　：2005/07/04 (Mon) 13:13:06 N.Kojima     OnErr処理追加
    '　　　：2008/06/12 (Thu) 09:21:29 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN0250_Init()
        
        Dim lstrFormTitle       As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0250, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@各ｺﾝﾄﾛｰﾙの初期化
            lblLotID.Text = vbNullString                             'ﾛｯﾄID
            lblFlowClass.Text = vbNullString                         '流動区分
            lblWFNo.Text = vbNullString                              'FW枚数
            lblStartDayTime.Text = vbNullString                      '開始日時
            lblPdID.Text = vbNullString                              '機種名
            lblS.Text = vbNullString                                 '特殊特性
            lblStatus.Text = vbNullString                            '状態
            lblLotManager.Text = vbNullString                        'ﾛｯﾄ担当者名
            lblTimeLimit.Text = vbNullString                         '時間制約
            '@↓2020/01/07 (Tue) 13:40:12 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString                              'GRB
            lblGRB.BackColor = lblPdID.BackColor
            '@↑2020/01/07 (Tue) 13:40:12 Y.Yoneyama 「.Netへ反映未」 **************************************************

            mstrLotLastUpdate = vbNullString                         'ﾛｯﾄ最終更新日時
            mstrCarrier = vbNullString                               'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
            mstrOpID = vbNullString                                  '現在大工程
            mstrStepID = vbNullString                                '現在小工程

            '@現工程LISTの初期化
            Call prvvsfLotPrestate_Init()
            
            '@次工程LISTの初期化
            Call prvVsfNextStepInfo_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "prvfrmxxEN0250_Init"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0250_CmbInit
    '機　能：各ｺﾏﾝﾄﾞﾎﾞﾀﾝの制御
    '引　数：lblnEnable：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 11:36:26 H.Wajima
    '更新日：2005/07/04 (Mon) 13:13:35 N.Kojima
    '備　考：
    '　　　：2005/07/04 (Mon) 13:13:35 N.Kojima     OnErr処理追加
    Private Sub prvfrmxxEN0250_CmbInit(Optional ByVal lblnEnable As Boolean = False)
        
        Try
            
            '@各ｺﾏﾝﾄﾞﾎﾞﾀﾝのｺﾝﾄﾛｰﾙ
            cmdProcEnd.Enabled = lblnEnable             '確定ﾎﾞﾀﾝ
            cmdActionDisp.Enabled = lblnEnable          'ｱｸｼｮﾝ予約確認ﾎﾞﾀﾝ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "prvfrmxxEN0250_CmbInit"     'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0250_Disp
    '機　能：画面の表示
    '引　数：ltypLotprestate：ﾛｯﾄ情報を格納する構造体
    '戻り値：なし
    '作成日：2004/05/11 (Tue) 12:48:26 H.Wajima
    '更新日：2008/06/12 (Thu) 09:22:04 N.Kojima
    '備　考：
    '　　　：2004/08/25 (Wed) 14:49:46 N.Kasai      CFﾌﾗｸﾞ判定追加、"mm/dd hh:mm:ss"を共通変数化
    '　　　：2004/09/09 (Thu) 20:51:21 Y.Yamagishi  時間制限表示変更(不具合改善№693)
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima     数量表示(TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2004/09/24 (Fri) 11:36:41 Y.Yamagishi  制限時間以上の場合文字色を青に変更(不具合改善№825)
    '　　　：2005/05/16 (Mon) 18:25:57 N.Kojima     処理開始予定の表示不備を修正(不具合№808)
    '　　　：2005/07/04 (Mon) 13:14:02 N.Kojima     OnErr処理追加
    '　　　：2006/06/08 (Thu) 15:24:30 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/12 (Thu) 09:22:04 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN0250_Disp(ByRef ltypLotprestate As Lotprestate)
        
        Try

            '@ﾛｯﾄ情報の表示
            With ltypLotprestate
                lblLotID.Text = .strLotID                                            'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                    '流動区分
                
                '@ﾛｯﾄ状態
                Select Case .strNowST
                    '@「作業待ち」「前処理」の場合
                    Case CPstrWaitWorkSt, CPstrBeforeProgressSt
                        '@日付ﾀｲﾄﾙ設定「処理開始予定」
                        lblStartTime.Text = CPstrDispatchTime
                        If IsDate(.strDispatchStartTime) Then
                            lblStartDayTime.Text = Format$(CDate(.strDispatchStartTime), CPstrDateFormat)  '投入予定日"MM/dd HH:mm:ss"
                        Else
                            lblStartDayTime.Text = .strDispatchStartTime
                        End If
                        
                    '@その他
                    Case Else
                        '@日付ﾀｲﾄﾙ設定「処理開始日時」
                        lblStartTime.Text = CPstrStartTime
                        If IsDate(.strStartTime) Then
                            lblStartDayTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat)          '開始日時"MM/dd HH:mm:ss"
                        Else
                            lblStartDayTime.Text = .strStartTime
                        End If
                End Select
                
                lblPdID.Text = .strPdId                                              '機種名
                lblS.Text = .strSpecialFlg                                           '特殊特性
                lblStatus.Text = .strNowST                                           '状態
                lblLotManager.Text = .strEngEmpName                                  'ﾛｯﾄ担当者名
                '@↓2020/01/07 (Tue) 13:42:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                                          'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblPdID.BackColor)
                '@↑2020/01/07 (Tue) 13:42:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
                 
                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then

                    '@時間制約がﾌﾟﾗｽの場合
                    If CLng(.strLimitTime) >= 0 Then

        '@↓2006/06/08 (Thu) 15:23:57 N.Kojima **************************************************
                        '@制限時間以下or処理時間制限以下の場合
        '                If .strRestrictTypeID = CPstrRestrictTypeID1 Then
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@制限時間先大工程+制限時間先小工程+制限時間
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(Clng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            '@右寄せ
                            lblTimeLimit.TextAlign = ContentAlignment.TopRight
                            
                            '@警告時間が設定されている場合
                            If .strWarnTime <> vbNullString Then
                                '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                If CLng(.strWarnTime) < 0 And CLng(.strLimitTime) >= 0 Then
                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)  '紫色
                                Else
                                    '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                    lblTimeLimit.ForeColor = Color.Black                                    '黒
                                End If
                            End If
                        End If
        '@↑2006/06/08 (Thu) 15:23:57 N.Kojima **************************************************

                    Else
                    '@制限時間がﾏｲﾅｽの場合
                        '@制限時間先大工程+制限時間先小工程+制限時間
                        '@右寄せ
                        lblTimeLimit.TextAlign = ContentAlignment.TopRight
                        '@ForColorの変更
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)    '赤色
                        
        '@↓2006/06/08 (Thu) 15:24:52 N.Kojima **************************************************
                        '@制限時間以下or処理時間制限以下の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(Clng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                        End If
        '@↑2006/06/08 (Thu) 15:24:52 N.Kojima **************************************************
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Replace(Format(Clng(.strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString) & CPstrh
                        End If
                    End If
                End If
                                
                '@枚数表示判定(CF_FLAGを判定し、WF枚数とﾁｯﾌﾟ枚数の表示を切替)
                Select Case .strCfFlag
                    '@CFﾛｯﾄ
                    Case CPstrCF

        '@↓2005/05/26 (Thu) 13:42:28 N.Kasai **************************************************
                        '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                        If .strLpFlag = CPstrLP Then
                            '@大判の場合
                            lblWFNo.Text = .strWfNum                                                'WF枚数
                        Else
                            If IsNumeric(.strChipQuantity) Then
                                lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)   'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity
                            End If
                        End If
        '@↑2005/05/26 (Thu) 13:42:28 N.Kasai **************************************************
                        
                    Case Else
                    '@CFﾛｯﾄ以外
                        '@TPALﾛｯﾄ
                        If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                            If IsNumeric(.strChipQuantity) Then
                                lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)   'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity
                            End If
                        Else
                            '@CF,TPALﾛｯﾄ以外
                            lblWFNo.Text = .strWfNum                                                'WF枚数
                        End If
                End Select
                
                '@退避情報
                mstrLotLastUpdate = .strLotLastUpdate                                   'ﾛｯﾄ最終更新日時
                
                '@現工程ｸﾞﾘｯﾄﾞにﾃﾞｰﾀを設定
                Call prvvsfLotPrestate_Disp(ltypLotprestate, .lngStepListCnt)
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "prvfrmxxEN0250_Disp"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnProcEndInput_Chk
    '機　能：入力確認
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2004/05/12 (Wed) 17:21:02 H.Wajima
    '更新日：2005/07/04 (Mon) 13:14:26 N.Kojima
    '備　考：
    '　　　：2005/01/06 (Thu) 11:26:35 N.Kasai      最終工程でもｽｷｯﾌﾟ可
    '　　　：2005/07/04 (Mon) 13:14:26 N.Kojima     OnErr処理、SetFocus対応追加
    Private Function prvblnProcEndInput_Chk() As Boolean
        
        Try
            
            prvblnProcEndInput_Chk = False
            
            '@ｷｬﾘｱIDの入力ﾁｪｯｸ
            If txtCarrier.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                '@"キャリアIDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                
                Exit Function
            End If
            
            '@ｷｬﾘｱIDが6桁であるかﾁｪｯｸ
            If Len(txtCarrier.Text) <> CMlngCarrierMaxLength Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                
                Exit Function
            End If
            
            '@入力OK
            prvblnProcEndInput_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "prvblnProcEndInput_Chk"     'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvvsfLotPrestate_Init
    '機　能：現工程表示ｸﾞﾘｯﾄの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/17 (Mon) 14:42:21 H.Wajima
    '更新日：2005/07/04 (Mon) 13:14:46 N.Kojima
    '備　考：
    '　　　：2005/07/04 (Mon) 13:14:46 N.Kojima     OnErr処理追加
    Private Sub prvvsfLotPrestate_Init()

        Dim lNormalStyle As CellStyle 'NSYS スタイル定義
        Dim lFixedStyle  As CellStyle 'NSYS スタイル定義

        Try

            With vsfLotPrestate
                'NSYS スタイルを変数に設定
                lNormalStyle = .Styles.Normal 
                lFixedStyle  = .Styles.Fixed

                '@ﾌﾟﾛﾊﾟﾃｨ初期値
                .Clear
                .Cols.Count = CMlngLotPrestateColWPID + 1
                .Rows.Count = CMlngGridFixedRows
                .Cols.Fixed = CMlngGridFixedCols
                .Rows.Fixed = CMlngGridFixedRows
                .SelectionMode = SelectionModeEnum.Row
                .FocusRect = FocusRectEnum.None
                .HighLight = HighLightEnum.Never
                .Font = New Font(CMstrGridFontName, CType(CMlngGridFontSize, Single), .Font.Style)
                .ScrollBars = ScrollBars.None
                .Width = CMlngGridWidth
                .Height = CMlngGridHeight
                
                '@表示位置の設定(ﾃﾞﾌｫﾙﾄ)
                .Cols(CMlngNextStepInfoColDefault).TextAlign = TextAlignEnum.LeftCenter '左詰の中央
                
                '@ｸﾞﾘｯﾄﾞの表題設定
                lFixedStyle.ForeColor = Color.Yellow                                '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)   '背景色
                'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                With .Font
                    lFixedStyle.Font = New Font(.FontFamily, CMlngGridFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                  '文字位置
                lFixedStyle.Trimming = StringTrimming.None                          'NSYS ﾍｯﾀﾞは省略表示なしに設定
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngGridRowTitle, CMlngLotPrestateColOpID, CMstrLotPrestateColTOpID)        '大工程ID
                .SetData(CMlngGridRowTitle, CMlngLotPrestateColStepID, CMstrLotPrestateColTStepID)    '小工程ID
                .SetData(CMlngGridRowTitle, CMlngLotPrestateColDefault, CMstrLotPrestateColTDefault)  'ﾃﾞﾌｫﾙﾄ
                .SetData(CMlngGridRowTitle, CMlngLotPrestateColWPID, CMstrLotPrestateColTWPID)        'WPID
                
                '@列幅の設定
                .Cols(CMlngLotPrestateColOpID).Width = CMlngGridColWidthOpID          '大工程ID
                .Cols(CMlngLotPrestateColStepID).Width = CMlngGridColWidthStepID      '小工程ID
                .Cols(CMlngLotPrestateColDefault).Width = CMlngGridColWidthDefault    'ﾃﾞﾌｫﾙﾄ
                .Cols(CMlngLotPrestateColWPID).Width = CMlngGridColWidthWPID          'WPID
                
                '@結合ｾﾙの設定
                .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll
                .Cols(CMlngLotPrestateColOpID).AllowMerging = True
                .Cols(CMlngLotPrestateColStepID).AllowMerging = True
                .Cols(CMlngLotPrestateColDefault).AllowMerging = True
                
                '@ﾀｲﾄﾙの高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight
                
                '@ﾛｯｸ
                .Enabled = False
            End With
            
            '@▲▼ﾎﾞﾀﾝの非活性化
            cmdPreUp.Enabled = False
            cmdPreDown.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "prvvsfLotPrestate_Init"     'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfNextStepInfo_Init
    '機　能：次工程表示ｸﾞﾘｯﾄの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/17 (Mon) 14:42:21 H.Wajima
    '更新日：2005/07/04 (Mon) 13:15:06 N.Kojima
    '備　考：
    '　　　：2005/07/04 (Mon) 13:15:06 N.Kojima     OnErr処理追加
    Private Sub prvVsfNextStepInfo_Init()
        
        Dim lNormalStyle As CellStyle 'NSYS スタイル定義
        Dim lFixedStyle  As CellStyle 'NSYS スタイル定義

        Try

            With vsfNextStepInfo
                'NSYS スタイルを変数に設定
                lNormalStyle = .Styles.Normal 
                lFixedStyle  = .Styles.Fixed

                '@ﾌﾟﾛﾊﾟﾃｨ初期値
                .Clear
                .Cols.Count = CMlngLotPrestateColWPID + 1
                .Rows.Count = CMlngGridFixedRows
                .Cols.Fixed = CMlngGridFixedCols
                .Rows.Fixed = CMlngGridFixedRows
                .SelectionMode = SelectionModeEnum.Row
                .FocusRect = FocusRectEnum.None
                .HighLight = HighLightEnum.Never
                .Font = New Font(CMstrGridFontName, CType(CMlngGridFontSize, Single), .Font.Style)
                .ScrollBars = ScrollBars.None
                .Width = CMlngGridWidth
                .Height = CMlngGridHeight
                
                '@表示位置の設定(ﾃﾞﾌｫﾙﾄ)
                .Cols(CMlngNextStepInfoColDefault).TextAlign = TextAlignEnum.LeftCenter
                
                '@ｸﾞﾘｯﾄﾞの表題設定
                lFixedStyle.ForeColor = Color.Yellow                                '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)   '背景色     
                'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                With .Font
                    lFixedStyle.Font = New Font(.FontFamily, CMlngGridFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                  '文字位置
                lFixedStyle.Trimming = StringTrimming.None                          'NSYS ﾍｯﾀﾞは省略表示なしに設定
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColOpID, CMstrNextStepInfoColTOpID)          '大工程ID
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColStepID, CMstrNextStepInfoColTStepID)      '小工程ID
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColDefault, CMstrNextStepInfoColTDefault)    'ﾃﾞﾌｫﾙﾄ
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColWPID, CMstrNextStepInfoColTWPID)          'WPID
                
                '@列幅の設定
                .Cols(CMlngLotPrestateColOpID).Width = CMlngGridColWidthOpID          '大工程ID
                .Cols(CMlngLotPrestateColStepID).Width = CMlngGridColWidthStepID      '小工程ID
                .Cols(CMlngLotPrestateColDefault).Width = CMlngGridColWidthDefault    'ﾃﾞﾌｫﾙﾄ
                .Cols(CMlngLotPrestateColWPID).Width = CMlngGridColWidthWPID          'WPID
                
                '@結合ｾﾙの設定
                .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll
                .Cols(CMlngNextStepInfoColOpID).AllowMerging = True
                .Cols(CMlngNextStepInfoColStepID).AllowMerging = True
                .Cols(CMlngNextStepInfoColDefault).AllowMerging = True
                
                '@ﾀｲﾄﾙの高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight
                
                '@ﾛｯｸ
                .Enabled = False
            End With
            
            '@▲▼ﾎﾞﾀﾝの非活性化
            cmdNextUP.Enabled = False
            cmdNextDown.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "prvvsfNextStepInfo_Init"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotPrestate_Disp
    '機　能：現工程ｸﾞﾘｯﾄﾞ情報設定処理
    '引　数：ltypLotPrestate：現工程取得ﾃﾞｰﾀ格納構造体
    '　　　：llngCnt：ﾃﾞｰﾀ件数
    '戻り値：なし
    '作成日：2004/05/19 (Wed) 13:02:38 H.Wajima
    '更新日：2005/07/04 (Mon) 13:15:28 N.Kojima
    '備　考：
    '　　　：2005/07/04 (Mon) 13:15:28 N.Kojima     OnErr処理追加
    Private Sub prvvsfLotPrestate_Disp(ByRef ltypLotprestate As Lotprestate, ByVal llngCnt As Integer)

        Dim lllngWPListCnt  As Integer  'WPListCntｶｳﾝﾀ
        Dim llngStepCnt     As Integer  '小工程ｶｳﾝﾀ
        Dim llngRowCnt      As Integer  '行ｶｳﾝﾀ

        Try
            
            '@一覧表示
            With vsfLotPrestate
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@ｶｳﾝﾀの初期化
                llngRowCnt = .Rows.Fixed
                
                '@小工程ﾙｰﾌﾟ
                For llngStepCnt = 1 To llngCnt
                    '@装置ﾙｰﾌﾟ
                    For lllngWPListCnt = 0 To ltypLotprestate.strSteplist(llngStepCnt - 1).lngWpListCnt - 1
                        '@行数の設定
                        .Rows.Count = llngRowCnt + 1
                        
                        '@大工程
                        .SetData(llngRowCnt, CMlngLotPrestateColOpID, _
                            ltypLotprestate.strSteplist(llngStepCnt - 1).strOpID)
                        
                        '@小工程
                        .SetData(llngRowCnt, CMlngLotPrestateColStepID, _
                            ltypLotprestate.strSteplist(llngStepCnt - 1).strStepID)
                        
                        '@ﾃﾞﾌｫﾙﾄ
                        Select Case ltypLotprestate.strSteplist(llngStepCnt - 1).strStepDivision
                            Case "0"
                                .SetData(llngRowCnt, CMlngLotPrestateColDefault, CMstrDaitaiStep)
                            Case "1"
                                .SetData(llngRowCnt, CMlngLotPrestateColDefault, CMstrDefaultStep)
                            Case Else
                                .SetData(llngRowCnt, CMlngLotPrestateColDefault, vbNullString)
                        End Select
                        
                        '@装置
                        .SetData(llngRowCnt, CMlngLotPrestateColWPID, _
                            ltypLotprestate.strSteplist(llngStepCnt - 1).strWPList(lllngWPListCnt).strWpName)
                        
                        '@ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                        llngRowCnt = llngRowCnt + 1
                    
                    Next lllngWPListCnt
                Next llngStepCnt

                .Cols(CMlngLotPrestateColOpID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngLotPrestateColStepID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngLotPrestateColDefault).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngLotPrestateColWPID).TextAlign = TextAlignEnum.LeftCenter

                '@明細の行の高さ
                .Rows.DefaultSize = CMlngGridRowHeight
                
                '@ﾀｲﾄﾙの行の高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝの表示初期化
                Call pubVsfDisp(vsfLotPrestate, cmdPreUp, cmdPreDown)
                
                '@描画の再開
                .Redraw = True

            End With
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "prvvsfLotPrestate_Disp"     'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfNextStepInfo_Disp
    '機　能：次工程ｸﾞﾘｯﾄﾞ情報設定処理
    '引　数：ltypLotNextStep：次工程取得ﾃﾞｰﾀ格納構造体
    '　　　：llngCnt：ﾃﾞｰﾀ件数
    '戻り値：なし
    '作成日：2004/05/18 (Tue) 12:31:33 N.Kasai
    '更新日：2005/07/04 (Mon) 13:15:48 N.Kojima
    '備　考：
    '　　　：2005/07/04 (Mon) 13:15:48 N.Kojima     OnErr処理追加
    Private Sub prvVsfNextStepInfo_Disp(ByRef ltypLotNextStep As LotNextStep, ByVal llngCnt As Integer)

        Dim lllngWPListCnt  As Integer  'WPListCntｶｳﾝﾀ
        Dim llngStepCnt     As Integer  '小工程ｶｳﾝﾀ
        Dim llngRowCnt      As Integer  '行ｶｳﾝﾀ

        Try
            
            '@一覧表示
            With vsfNextStepInfo
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@ｶｳﾝﾀの初期化
                llngRowCnt = .Rows.Fixed
                '@小工程ﾙｰﾌﾟ
                For llngStepCnt = 1 To llngCnt
                    '@装置ﾙｰﾌﾟ
                    For lllngWPListCnt = 0 To ltypLotNextStep.strNextStepList(llngStepCnt - 1).lngWpListCnt - 1
                        '@行数の設定
                        .Rows.Count = llngRowCnt + 1
                        
                        '@大工程
                        .SetData(llngRowCnt, CMlngNextStepInfoColOpID, _
                            ltypLotNextStep.strNextStepList(llngStepCnt - 1).strNextOpId)
                        
                        '@小工程
                        .SetData(llngRowCnt, CMlngNextStepInfoColStepID, _
                            ltypLotNextStep.strNextStepList(llngStepCnt - 1).strNextStepId)
                        
                        '@ﾃﾞﾌｫﾙﾄ
                        Select Case ltypLotNextStep.strNextStepList(llngStepCnt - 1).strStepDivision
                            Case "0"
                                .SetData(llngRowCnt, CMlngNextStepInfoColDefault, CMstrDaitaiStep)
                            Case "1"
                                .SetData(llngRowCnt, CMlngNextStepInfoColDefault, CMstrDefaultStep)
                            Case Else
                                .SetData(llngRowCnt, CMlngNextStepInfoColDefault, vbNullString)
                        End Select
                        
                        '@装置
                        .SetData(llngRowCnt, CMlngNextStepInfoColWPID, _
                            ltypLotNextStep.strNextStepList(llngStepCnt - 1).strWPList(lllngWPListCnt).strWpName)
                        
                        '@ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                        llngRowCnt = llngRowCnt + 1
                    
                    Next lllngWPListCnt
                Next llngStepCnt

                .Cols(CMlngNextStepInfoColOpID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngNextStepInfoColStepID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngNextStepInfoColDefault).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngNextStepInfoColWPID).TextAlign = TextAlignEnum.LeftCenter
                
                '@明細の行の高さ
                .Rows.DefaultSize = CMlngGridRowHeight
                
                '@ﾀｲﾄﾙの行の高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝの表示初期化
                Call pubVsfDisp(vsfNextStepInfo, cmdNextUP, cmdNextDown)
                
                '@描画の再開
                .Redraw = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "prvvsfNextStepInfo_Disp"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnLotSkipStep_Upd
    '機　能：工程ｽｷｯﾌﾟ処理
    '引　数：lstrDefaultNextOpID：次大工程
    '　　　：lstrDefaultNextStepID：次小工程
    '戻り値：True：成功/False：失敗
    '作成日：2005/05/18 (Wed) 16:09:46 S.Deguchi
    '更新日：2009/03/05 (Thu) 10:35:39 N.Kojima
    '備　考：
    '　　　：2005/07/04 (Mon) 13:16:06 N.Kojima     OnErr処理追加
    '　　　：2007/07/03 (Tue) 14:35:10 N.Kasai      組立自動送品(№01930)
    '　　　：2009/03/05 (Thu) 10:35:39 N.Kojima     量産ｵｰﾀﾞｰ振替ﾁｪｯｸ処理追加。(案件№03402)
    Private Function prvblnLotSkipStep_Upd(ByVal lstrDefaultNextOpID As String, _
                                           ByVal lstrDefaultNextStepID As String) As Boolean

        Dim lblnAns                 As Boolean          '戻り値
        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrActionFlag          As String           'ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ
        Dim lstrSendResult          As String           '送信結果(Null:通常skip、0:完成在庫へ、1:中間在庫へ)
        Dim lstrGuidMsg             As String           'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String           'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String           '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lblnChkChangeOrderAns   As Boolean          '量産ｵｰﾀﾞｰ振替ﾁｪｯｸ戻り値格納用

        Try

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdProcEnd_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@初期化
            prvblnLotSkipStep_Upd = False
            
        '@↓2009/03/05 (Thu) 10:26:20 N.Kojima **************************************************

            '@起動SBが組立か
            If pstrSBID = CPstrSBID2A0 Then
                '@2A0：組立の場合

                '@=======================
                '@ 量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
                '@=======================
                '@【量産ｵｰﾀﾞｰ振替ﾁｪｯｸ】ﾒｯｾｰｼﾞ送受信処理
                lblnChkChangeOrderAns = pubblnLotChkChgOrder_Chk(CMstrlot_chkchangeorderVer, _
                                                                lblLotID.Text, _
                                                                lstrGuidMsg, _
                                                                lstrGuidMsgCode)
            
                '@量産ｵｰﾀﾞｰ振替ﾁｪｯｸ結果が"True：ﾁｪｯｸ処理成功"か
                If lblnChkChangeOrderAns = True Then
            
                    '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞがNULL以外か
                    If lstrGuidMsgCode <> vbNullString Then
            
                        '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                        lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                           CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                           CPstrMsgCrCode & lstrGuidMsg
            
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「上記編集済みｶﾞｲﾀﾞﾝｽMsg」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                End If
            End If

        '@↑2009/03/05 (Thu) 10:26:20 N.Kojima **************************************************


            '@=======================
            '@ 工程ｽｷｯﾌﾟﾒｯｾｰｼﾞ送信
            '@ ※最終更新日時は、確定時に返される値を使う。ﾒｯｾｰｼﾞ関数内で書き換えている
            '@=======================
            '@【ﾛｯﾄ工程ｽｷｯﾌﾟ】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnLotSkipStep_Upd(CMstrlot_skipstepVer, _
                                            lblLotID.Text, _
                                            lstrDefaultNextOpID, _
                                            lstrDefaultNextStepID, _
                                            mstrLotLastUpdate, _
                                            pstrUserID, _
                                            lstrActionFlag, _
                                            lstrSendResult, _
                                            lstrGuidMsg, _
                                            lstrGuidMsgCode)

            '@結果判定
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
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
            
                '@最終工程ﾌﾗｸﾞONの場合は最終工程の為、最終工程用のﾒｯｾｰｼﾞを表示する。
                If mblnLastStepFlg = True Then
                    '@送信結果を判定して成功ﾒｯｾｰｼﾞを表示
                    
                    '@lstrSendResult：(Null：次工程送出)、(0：中間在庫)、(1：完成在庫)、(2：組立送品)
                    Select Case lstrSendResult
                        '@完成在庫へ
                        Case CPstrKansei
                            '@表示ﾒｯｾｰｼﾞ変換("<TRM3UI>$$流動、完了しました。キャリア[%1] ロット[%2]$[完成在庫へ送出]しました。")
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003U, txtCarrier.Text, lblLotID.Text, CPstrKanseiZaiko)
                        
                        '@中間在庫へ
                        Case CPstrChukan
                            '@表示ﾒｯｾｰｼﾞ変換("<TRM3UI>$$流動、完了しました。キャリア[%1] ロット[%2]$[中間在庫へ送出]しました。")
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003U, txtCarrier.Text, lblLotID.Text, CPstrChukanZaiko)
                        
                        '@組立送品(受入在庫)
                        Case CPstrSouhin
                            '@表示ﾒｯｾｰｼﾞ変換("<TRM3UI>$$流動、完了しました。キャリア[%1] ロット[%2]$[組立工程へ送品]しました。")
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003U, txtCarrier.Text, lblLotID.Text, CPstrSouhinZaiko)
                        
                        '@例外(通常skip)
                        Case Else
                            '@表示ﾒｯｾｰｼﾞ変換("<TRM0AI>$$流動、完了しました。キャリア[%1] ロット[%2]")
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000A, txtCarrier.Text, lblLotID.Text)
                    End Select
                   
                    '@ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0047, txtCarrier.Text, lblLotID.Text)
                    '@pubVsfInfo_Disp("メッセージコード：C_I47%0$$工程をスキップしました。キャリア[ %1 ] ロット[ %2 ]")
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@表示ﾒｯｾｰｼﾞ初期化
                    pstrDMsg = vbNullString
                    Select Case lstrActionFlag
                        '@停止の場合
                        Case CPstrActionFlag1
                            '@表示ﾒｯｾｰｼﾞ変換"<TRM2SI>$$アクション予約によりロット[ %1 ] は [停止] されました。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, lblLotID.Text, CPstrStopSt)
                        '@保留の場合
                        Case CPstrActionFlag2
                            '@表示ﾒｯｾｰｼﾞ変換"<TRM2SI>$$アクション予約によりロット[ %1 ] は [保留] されました。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, lblLotID.Text, CPstrHoldSt)
                    End Select
                    
                    '@表示ﾒｯｾｰｼﾞがある場合
                    If pstrDMsg <> vbNullString Then
                        '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                        Call pubVsfInfo_Disp(pstrDMsg)
                    End If
                End If
                
                '@成功を返す
                prvblnLotSkipStep_Upd = True
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnLotSkipStep_Upd"      'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnRestrict_Chk
    '機　能：時間制限取得情報ﾁｪｯｸ
    '引　数：ltypLotGetRestrict：時間制限構造体
    '戻り値：True：続行/False：中止
    '作成日：2005/05/18 (Wed) 11:40:10 S.Deguchi
    '更新日：2006/06/08 (Thu) 15:27:48 N.Kojima
    '備　考：
    '　　　：2005/07/04 (Mon) 13:16:27 N.Kojima     OnErr処理追加
    '　　　：2006/06/08 (Thu) 15:27:48 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    Private Function prvblnRestrict_Chk(ByRef ltypLotGetRestrict As LotGetRestrict) As Boolean

        Dim llngAns         As Integer      '結果格納

        Try
            
            '@初期化
            prvblnRestrict_Chk = False
            
            With ltypLotGetRestrict
                '@現工程が時間制限開始工程の場合
                If mstrOpID = .strFromOpId And mstrStepID = .strFromStepId Then
                    If .strRestrictTypeID <> vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005S, mstrOpID, mstrStepID)
                        '@<TRM5SW>$$大工程[%1], 小工程[%2]では制限時間が設定されています。
                        '@工程スキップを実行すると制限時間の適用外となりますが, 実行しますか？
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                        '@要求確認
                        If llngAns = vbNo Then
                            '@ｷｬﾝｾﾙする
                            Exit Function
                        Else
                        '@「はい」が選択された場合
                            '@続行ﾌﾗｸﾞを返す
                            prvblnRestrict_Chk = True
                        End If
                    Else
                        '@続行ﾌﾗｸﾞを返す
                        prvblnRestrict_Chk = True
                    End If
                Else
                    '@現工程が時間制限終了工程の場合
                    If mstrOpID = .strToOpId And mstrStepID = .strToStepId Then
                        '@時間制限ﾌﾗｸﾞによる処理分岐
                        Select Case .strRestrictTypeID

        '@↓2006/06/08 (Thu) 15:34:40 N.Kojima **************************************************
                            Case CPstrRestrictTypeID1, CPstrRestrictTypeID3
                            '@制限時間以下
                                '@制限時間がﾏｲﾅｽの場合,ﾒｯｾｰｼﾞを表示する
                                If CLng(.strLimitTime) < 0 Then
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003F, lblLotID.Text, mstrOpID, mstrStepID)
                                    '@"<TRM3BW>$$ロット[xxx]は[xxx xxx]までの工程において制限時間を経過しています。処理を継続しますか？"
                                    llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                                    '@要求確認
                                    If llngAns = vbNo Then
                                        '@ｷｬﾝｾﾙする
                                        Exit Function
                                    Else
                                    '@「はい」が選択された場合
                                        '@続行ﾌﾗｸﾞを返す
                                        prvblnRestrict_Chk = True
                                    End If
                                Else
                                    '@続行ﾌﾗｸﾞを返す
                                    prvblnRestrict_Chk = True
                                End If
        '@↑2006/06/08 (Thu) 15:34:40 N.Kojima **************************************************
                                
                            Case CPstrRestrictTypeID2
                            '@制限時間以上
                                '@制限時間がﾏｲﾅｽの場合,ﾒｯｾｰｼﾞを表示する
                                If CLng(.strLimitTime) < 0 Then
                                    '@表示ﾒｯｾｰｼﾞ変換
                                     pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003I, lblLotID.Text, mstrOpID, mstrStepID)
                                     '@"<TRM3IW>$$ロット[xxx]は[xxx xxx]までの工程において制限時間を経過していません。処理を継続しますか？"
                                     llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                                    
                                    '@要求確認
                                    If llngAns = vbNo Then
                                        '@ｷｬﾝｾﾙする
                                    Else
                                    '@「はい」が選択された場合
                                        '@続行ﾌﾗｸﾞを返す
                                        prvblnRestrict_Chk = True
                                    End If
                                Else
                                    '@続行ﾌﾗｸﾞを返す
                                    prvblnRestrict_Chk = True
                                End If
                                
                            Case vbNullString
                            '@制限時間なし
                                '@続行ﾌﾗｸﾞを返す
                                prvblnRestrict_Chk = True
                        End Select
                    Else
                        '@時間制限の開始/終了工程のどちらでもない場合
                        
                        '@続行ﾌﾗｸﾞを返す
                        prvblnRestrict_Chk = True
                    End If
                End If
            End With
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "prvblnRestrict_Chk"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblncmdActionDisp_Proc
    '機　能：ｱｸｼｮﾝ予約表示
    '引　数：lstrLotID：ﾛｯﾄID
    '　　　：lstrOpID：大工程ID
    '　　　：lstrStepID：小工程ID
    '　　　：lstrPDID：機種ID
    '　　　：lstrMasPDVersion：工順ﾊﾞｰｼﾞｮﾝ
    '　　　：lstrWPID：装置ID
    '　　　：ltypLotAction：ｱｸｼｮﾝ予約情報構造体
    '戻り値：True:正常終了、False：異常終了
    '作成日：2007/02/16 (Fri) 13:05:16 N.Kasai
    '更新日：2007/02/16 (Fri) 13:05:16
    '備　考：
    Private Function prvblncmdActionDisp_Proc(ByVal lstrLotID As String, _
                                              ByVal lstrOpID As String, _
                                              ByVal lstrStepID As String, _
                                              ByVal lstrPdID As String, _
                                              ByVal lstrMasPDVersion As String, _
                                              ByVal lstrWpId As String) As Boolean
        
        Dim lblnAns                 As Boolean              'ｱｸｼｮﾝ予約ﾘｽﾄ取得結果格納
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt                 As Integer              'ｶｳﾝﾄ

        Try
            
            '@初期化
            prvblncmdActionDisp_Proc = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "prvblncmdActionDisp_Proc"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@構造体初期化
            ptypLotAction.lnglstCnt = 0
            If IsNothing(ptypLotAction.typLotActList) Then
                ptypLotAction.typLotActList = New List(Of LotActList)
            Else
                ptypLotAction.typLotActList.Clear()
            End If
            
            '@ｱｸｼｮﾝ予約ﾘｽﾄ取得
            lblnAns = pubblnLotActList_Sel(CMstrlot_actlist_Ver, _
                                           lstrLotID, _
                                           lstrOpID, _
                                           lstrStepID, _
                                           lstrPdID, _
                                           lstrMasPDVersion, _
                                           lstrWpId, _
                                           ptypLotAction)
            '@取得に成功したら表示(ｱｸｼｮﾝ予約ﾘｽﾄが0件の場合は何も表示しない)
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)
                
                '@ｱｸｼｮﾝ予約件数判定
                If ptypLotAction.lnglstCnt > 0 Then
                    '@件数あり
                    With ptypLotAction

                        '@ｱｸｼｮﾝ予約がなくなるまで
                        For llngCnt = 0 To .lnglstCnt - 1
                            Dim typActionLotListTmp = .typLotActList(llngCnt)
                            
                            typActionLotListTmp.strLotID = lstrLotID                                'ﾛｯﾄID
                            typActionLotListTmp.strFlowClass = lblFlowClass.Text                    '流動区分
                            
                            '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ判定
                            Select Case .typLotActList(llngCnt).strLotActionTypeID
                                '@ﾛｯﾄの場合
                                Case CPstrLotActionTypeID0
                                    typActionLotListTmp.strLotActionTypeName = CPstrActTypeLOT      'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                                '@機種の場合
                                Case CPstrLotActionTypeID1
                                    typActionLotListTmp.strLotActionTypeName = CPstrActTypePD       'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                                '@装置の場合
                                Case CPstrLotActionTypeID2
                                    typActionLotListTmp.strLotActionTypeName = CPstrActTypeWP       'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                                '@特定工程の場合
                                Case CPstrLotActionTypeID3
                                    typActionLotListTmp.strLotActionTypeName = CPstrActTypeTStep    'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                            End Select
                            
                            '@ｱｸｼｮﾝﾄﾘｶﾞｰ
                            Select Case .typLotActList(llngCnt).strActionTrigger
                                '@作業開始
                                Case CMlngTriggerStart
                                    typActionLotListTmp.strActionTrigger = CMstrEN0030Title
                                '@作業終了
                                Case CMlngTriggerEnd
                                    typActionLotListTmp.strActionTrigger = CMstrEN0060Title
                            End Select
                            
                            typActionLotListTmp.strOpID = lstrOpID                                  '大工程
                            typActionLotListTmp.strStepID = lstrStepID                              '小工程
                            
                            .typLotActList(llngCnt) = typActionLotListTmp
                        Next llngCnt
                    End With
                    
                    '@ｻﾌﾞ画面で確定していない場合
                    If pblnSubDecision = False Then
                        '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面名称設定
                        frmxxCM0040.Instance.Text = CPstrSubDispTitleActionMsg
                        
                        '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ表示画面を表示(ptypLotActionの情報でｱｸｼｮﾝ予約の内容を表示)
                        frmxxCM0040.Instance.ShowDialog(Me)
                        frmxxCM0040.Instance = Nothing
                    Else
                        '@ｻﾌﾞ画面確定ﾌﾗｸﾞ(確定していない)
                        pblnSubDecision = False
                    End If
                    
                    '@設定OK
                    prvblncmdActionDisp_Proc = True
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblncmdActionDisp_Proc"   'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function


    '関数名：prvblnOvertakeAuthority_Chk
    '機　能：無機ODF追越制限権限ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True:成功、False:失敗
    '作成日：2014/11/26 (Wed) 10:56:05 H.Hayashi
    '更新日：
    '備　考：
    Private Function prvblnOvertakeAuthority_Chk(ByVal lstrWpId As String, _
                                        ByRef lstrOvertakeLotId As String) As Boolean
        
        Dim lstrFunctionID          As String       '機能ID
        Dim lstrActionID            As String       'ｱｸｼｮﾝID
        Dim lstrEmpName             As String       '作業者名
        Dim lblnAns                 As Boolean      '戻り値格納用
        Dim llngMsgAns              As Integer      'Msg戻り値
        Dim lstrOvertakeStatus      As String       '追越制限違反状態(0:追越制限違反無し、1:追越制限違反有り)
        Dim lstrFormName            As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        
        Try
            
            '@戻り値を初期化する
            prvblnOvertakeAuthority_Chk = False
            
            '@ﾚｽﾎﾟﾝｽ用設定
            lstrFormName = Me.Name
            lstrEventName = "cmdProcEnd_Click"
            
            '@=======================
            '@ 無機ODF追越制限違反確認
            '@=======================
            lblnAns = pubblnOvertake_Sel(CMstrlot_chkovertake, _
                                         lblLotID.Text, _
                                         lstrWpId, _
                                         lstrOvertakeLotId, _
                                         lstrOvertakeStatus)
            
            '@結果判定
            If lblnAns = False Then

                Exit Function
            Else
                
                '@追越制限違反が存在するか確認

                    
                 If lstrOvertakeStatus = CPstrOvertakeNg Then
                                       
                    '@表示ﾒｯｾｰｼﾞ
                    '@「"<TRM133W>$$ロット[%1]は作業開始前ですが、$本ロットを[%2]致しますか。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0133, lstrOvertakeLotId, "工程スキップ")
                    llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                                  
                                    
                    '@ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
        '            Call pubSetFocus(cmdSelectMaterial)

                    '@要求確認(いいえ選択時は処理終了)
                    If llngMsgAns = vbNo Then

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        Exit Function

                    End If
                Else
                    
                    '@戻り値に"True:権限ﾁｪｯｸOK"をｾｯﾄ
                    prvblnOvertakeAuthority_Chk = True
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    Exit Function
                            
                End If
                
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Function
            End If
                
            '@実行権限の処理を追加
            lstrFunctionID = CMstrLocalMenuKey          '機能ID：EN0250(工程スキップ)
            lstrActionID = CPstrOvertake                'ｱｸｼｮﾝID：ロット追越制御
            lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名：NULL
               
            '@=======================
            '@　実行権限ﾁｪｯｸ処理
            '@=======================
            lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                       lstrActionID, _
                                       pstrUserID, _
                                       pstrUserName, _
                                       pstrSBID)

            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, pstrUserName, lstrActionID)
                '@ﾒｯｾｰｼﾞ表示："<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            
                Exit Function
            End If

            '@戻り値に"True:権限ﾁｪｯｸOK"をｾｯﾄ
            prvblnOvertakeAuthority_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnOvertakeAuthority_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        Finally

            'NSYS lstrOvertakeLotIdが空の場合、ロットIDの値を格納する
            If lstrOvertakeLotId = vbNullString Then
                lstrOvertakeLotId = lblLotID.Text
            End If
            
        End Try
    End Function




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
    
End Class
